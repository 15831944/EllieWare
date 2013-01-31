﻿//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using EllieWare.Interfaces;
using SpaceClaim.Api.V10;
using SpaceClaim.Api.V10.Geometry;

namespace EllieWare.SpaceClaim
{
  public abstract class FaceCurvatureBase : FaceAreaBase
  {
    public FaceCurvatureBase() :
      base()
    {
      Initialise();
    }

    public FaceCurvatureBase(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
      Initialise();
    }

    private void Initialise()
    {
      AreaLabel.Text = "Curvature Threshold:";
      AreaUnits.Text = string.Format("{0}", (Window.ActiveWindow != null) ? Window.ActiveWindow.Units.Length.Symbol : "mm");
      AreaThreshold.Value = 1;
    }

    protected override sealed bool IsSmallFace(DesignFace desFace)
    {
      // faces below a threshold curvature
      var face = desFace.Shape;
      var surfShape = (ISurfaceShape)face;
      var surf = surfShape.Geometry;
      var surfParams = surf.Parameterization;
      var uParam = surfParams.U;
      var vParam = surfParams.V;

      if (!uParam.Bounds.Start.HasValue || !uParam.Bounds.End.HasValue ||
          !vParam.Bounds.Start.HasValue || !vParam.Bounds.End.HasValue)
      {
        // parameterisation infinite in some direction
        return false;
      }

      var midU = (uParam.Bounds.Start.Value + uParam.Bounds.End.Value) / 2d;
      var midV = (vParam.Bounds.Start.Value + vParam.Bounds.End.Value) / 2d;
      var midParam = PointUV.Create(midU, midV);
      var eval = surf.Evaluate(midParam);
      var minCurve = eval.MinCurvature;
      var doc = desFace.Document;
      var lengthFactor = doc.Units.Length.ConversionFactor;

      return minCurve * lengthFactor < (double)AreaThreshold.Value;
    }
  }
}
