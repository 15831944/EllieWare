﻿//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;
using EllieWare.Interfaces;
using SpaceClaim.Api.V10;
using SpaceClaim.Api.V10.Geometry;
using SpaceClaim.Api.V10.Modeler;
using Point = SpaceClaim.Api.V10.Geometry.Point;

namespace SheetMetalEstimator
{
  public partial class SheetMetalEstimator : UserControl, IMutableRunnable
  {
    private readonly IRobotWare mRoot;
    private readonly ICallback mCallback;
    private readonly IParameterManager mParamMgr;

    public SheetMetalEstimator()
    {
      InitializeComponent();
    }

    public SheetMetalEstimator(IRobotWare root, ICallback callback, IParameterManager mgr) :
      this()
    {
      mRoot = root;
      mCallback = callback;
      mParamMgr = mgr;
    }

    public XmlSchema GetSchema()
    {
      return null;
    }

    public void ReadXml(XmlReader reader)
    {
      ExcelFilePath.Text = reader.GetAttribute("ExcelFilePath");
      var isChecked = reader.GetAttribute("OptGenerateDXF");
      OptGenerateDXF.Checked = bool.Parse(isChecked);
    }

    public void WriteXml(XmlWriter writer)
    {
      writer.WriteAttributeString("ExcelFilePath", ExcelFilePath.Text);
      writer.WriteAttributeString("OptGenerateDXF", OptGenerateDXF.Checked.ToString(CultureInfo.InvariantCulture));
    }

    public string Summary
    {
      get
      {
        return "Estimate area and cut length of a flattened sheet metal part";
      }
    }

    public Control ConfigurationUserInterface
    {
      get
      {
        return this;
      }
    }

    public bool CanRun
    {
      get
      {
        if (Window.ActiveWindow == null || Window.ActiveWindow.Document == null)
        {
          return false;
        }

        return GetFlatPart(Window.ActiveWindow.Document) != null;
      }
    }

    private Part GetFlatPart(Document doc)
    {
      var parts = doc.Parts;
      var allFlatParts = from thisPart in parts where thisPart.FlatPattern != null select thisPart;

      return allFlatParts.SingleOrDefault();
    }

    private SurfaceEvaluation EvalCentre(Face face)
    {
      var surface = face.Geometry;
      var box = face.BoxUV;
      var centre = box.Center;
      var surfEval = surface.Evaluate(centre);

      return surfEval;
    }

    private Point GetCentrePoint(Face face)
    {
      var centre = EvalCentre(face).Point;

      return centre;
    }

    private Direction GetCentreNormal(Face face)
    {
      var normal = EvalCentre(face).Normal;

      return normal;
    }

    // returns size of a arbitrarily oriented, minimal bounding box for the face
    private SizeF GetMinimalBoundingBoxSize(Face face)
    {
      var origin = GetCentrePoint(face);
      var normal = GetCentreNormal(face);
      var frame = Frame.Create(origin, normal);
      var proj = Matrix.CreateMapping(frame);
      var projInv = proj.Inverse;
      var line = Line.Create(origin, normal);
      var minArea = Double.MaxValue;

      var minBox = Box.Create(Point.Origin);
      for (var i = 0; i <= 180; i += 5)
      {
        var angleRad = i / Math.PI / 180;
        var rotation = Matrix.CreateRotation(line, angleRad);
        var bbox = face.GetBoundingBox(rotation);
        var invBbox = projInv * bbox;
        var area = invBbox.Size.X * invBbox.Size.Y;
        if (area < minArea)
        {
          minArea = area;
          minBox = invBbox;
        }
      }

      return new SizeF((float)minBox.Size.X, (float)minBox.Size.Y);
    }

    private bool CreateFlatPatternDXF(string dxfFilePath, Body firstBody)
    {
      var largestFace = firstBody.Faces.OrderBy(x => x.Area).Last();
      var tempDoc = Document.Create();
      var tempPart = tempDoc.MainPart;
      var tempMasterUnused = DesignBody.Create(tempPart, "Flat Pattern", firstBody);
      var largestSurface = largestFace.Geometry;
      var box = largestFace.BoxUV;
      var centre = box.Center;
      var surfEval = largestSurface.Evaluate(centre);
      var normal = surfEval.Normal;
      var origin = surfEval.Point;
      var frame = Frame.Create(origin, normal);
      var viewProj = Matrix.CreateMapping(frame);
      var viewProjInv = viewProj.Inverse;
      var firstTempWindow = Window.GetWindows(tempDoc).First();

      firstTempWindow.SetProjection(viewProjInv, true, false);

      // this is the API causing the problems :-(
      //firstTempWindow.Export(WindowExportFormat.AutoCadDxf, dxfFilePath);

      //var allTempWindows = Window.GetWindows(tempDoc);
      //foreach (var thisWindow in allTempWindows)
      //{
      //  thisWindow.Close();
      //}

      return true;
    }

    private bool DoRun()
    {
      var doc = Window.ActiveWindow.Document;
      var flatPart = GetFlatPart(doc);
      var flatPattern = flatPart.FlatPattern;
      var flatDesBodies = flatPattern.FlatBodies;
      var allDesBodies = new List<DesignBody>(flatDesBodies);
      var anchorDesFace = flatPattern.AnchorFace;
      var bendDesBodies = from thisDesFace in flatPattern.BendFaces select thisDesFace.Parent;

      allDesBodies.Add(anchorDesFace.Parent);
      allDesBodies.AddRange(bendDesBodies);

      var allBodies = (from desBody in allDesBodies select desBody.Shape.Copy()).ToList();
      var firstBody = allBodies.First();

      allBodies.Remove(firstBody);
      firstBody.Unite(allBodies);

      var orderedFaces = firstBody.Faces.OrderBy(x => x.Area).ToList();
      var largestFace = orderedFaces[orderedFaces.Count - 1];
      var opositeLargestFace = orderedFaces[orderedFaces.Count - 2];
      var larSize = GetMinimalBoundingBoxSize(largestFace);
      var separation = largestFace.GetClosestSeparation(opositeLargestFace);
      var thickness = separation.Distance;
      var lengthUnit = doc.Units.Length;
      var lengthFactor = lengthUnit.ConversionFactor;
      var areaFactor = lengthFactor * lengthFactor;
      var area = largestFace.Area;
      var perimeter = largestFace.Perimeter;
      var numHoles = largestFace.Loops.Where(x => !x.IsOuter).Count();
      var msg = string.Format("{0},{1},{2},{3},{4},{5},{6},{7}",
                              Path.GetFileName(doc.Path),
                              Math.Round(area * areaFactor, 1),
                              Math.Round(perimeter * lengthFactor, 1),
                              flatPattern.BendFaces.Count(),
                              numHoles,
                              Math.Round(thickness * lengthFactor, 2),
                              Math.Round(larSize.Width * lengthFactor, 1),
                              Math.Round(larSize.Height * lengthFactor, 1));
      var path = ExcelFilePath.Text;

      if (!File.Exists(path))
      {
        const string header = @"Part Name,Area,Perimeter,No of Bends,No of Holes/Piercings,Thickness,LAR Width,LAR Height";

        using (var sw = File.CreateText(path))
        {
          sw.WriteLine(header);
        }
      }

      using (var sw = File.AppendText(path))
      {
        sw.WriteLine(msg);
      }

      if (OptGenerateDXF.Checked)
      {
        var dxfFilePath = Path.ChangeExtension(doc.Path, ".dxf");
        CreateFlatPatternDXF(dxfFilePath, firstBody);
      }

      return true;
    }

    public bool Run()
    {
      var evt = new AutoResetEvent(false);
      var retVal = false;

      WriteBlock.AppendTask(() =>
        {
          try
          {
            retVal = DoRun();
          }
          finally
          {
            evt.Set();
          }
        });

      return evt.WaitOne(60 * 60 * 1000) && retVal;
    }

    public event EventHandler ConfigurationChanged;

    private void FireConfigurationChanged()
    {
      if (ConfigurationChanged != null)
      {
        ConfigurationChanged(this, new EventArgs());
      }
    }

    private void ExcelFilePath_TextChanged(object sender, EventArgs e)
    {
      FireConfigurationChanged();
    }

    private void OptGenerateDXF_CheckedChanged(object sender, EventArgs e)
    {
      FireConfigurationChanged();
    }

    private void BtnBrowse_Click(object sender, EventArgs e)
    {
      if (DlgOpenFile.ShowDialog() != DialogResult.OK)
      {
        return;
      }

      ExcelFilePath.Text = DlgOpenFile.FileName;
    }
  }
}
