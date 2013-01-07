﻿//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using EllieWare.Common;
using EllieWare.Interfaces;

namespace EllieWare.Batch
{
  public partial class BatchRunner : MutableRunnableBase, IHost
  {
    private readonly List<string> mSpecFileNames = new List<string>();

    public BatchRunner() :
      base()
    {
      InitializeComponent();
    }

    public BatchRunner(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
      InitializeComponent();

      mSpecs.DataSource = mSpecFileNames;
    }

    #region Implementation of IXmlSerializable

    public override void ReadXml(XmlReader reader)
    {
      var specFileListStr = reader.GetAttribute("SpecificationFileNames");
      var tempList = (List<string>)XmlSerializationHelpers.XmlDeserializeFromString(specFileListStr, mSpecFileNames.GetType());
      mSpecFileNames.AddRange(tempList);

      UpdateUserInterface();
    }

    public override void WriteXml(XmlWriter writer)
    {
      var specFileList = XmlSerializationHelpers.XmlSerializeToString(mSpecFileNames);
      writer.WriteAttributeString("SpecificationFileNames", specFileList);
    }

    #endregion

    #region Implementation of IRunnable

    public override string Summary
    {
      get
      {
        return "TODO    Summary";
      }
    }

    public override Control ConfigurationUserInterface
    {
      get
      {
        return this;
      }
    }

    public override bool Run()
    {
      // TODO   Run
      return true;
    }

    #endregion

    private string GetSelectedSpecificationPath()
    {
      var pathNoExtn = Path.Combine(mRoot.UserSpecificationFolder, (string)mSpecs.SelectedValue);
      var retVal = Path.ChangeExtension(pathNoExtn, Utils.MacroFileExtension);

      return retVal;
    }

    private void UpdateButtons()
    {
      CmdUp.Enabled = CmdDown.Enabled = CmdDelete.Enabled = CmdEdit.Enabled = mSpecFileNames.Count > 0;

      var selIndex = mSpecs.SelectedIndex;
      CmdUp.Enabled &= (selIndex > 0);
      CmdDown.Enabled &= (selIndex < mSpecs.Items.Count - 1);
    }

    private void UpdateUserInterface()
    {
      mSpecs.RefreshItems();
      UpdateButtons();
    }

    private void CmdAdd_Click(object sender, EventArgs e)
    {
      var dlg = new MacroFileSelector(mRoot);
      if (dlg.ShowDialog() == DialogResult.Cancel)
      {
        return;
      }

      mSpecFileNames.Add(Path.GetFileNameWithoutExtension(dlg.SelectedSpecificationPath));

      UpdateUserInterface();

      mSpecs.SelectedIndex = mSpecFileNames.Count - 1;

      FireConfigurationChanged();
    }

    private void CmdDelete_Click(object sender, EventArgs e)
    {
      var selIndex = mSpecs.SelectedIndex;
      if (selIndex == -1)
      {
        return;
      }

      mSpecFileNames.RemoveAt(selIndex);

      UpdateUserInterface();

      FireConfigurationChanged();
    }

    private void EditSelectedSpecification()
    {
      var dlg = new Editor(this, mRoot, GetSelectedSpecificationPath());
      dlg.ShowDialog();
    }

    private void CmdEdit_Click(object sender, EventArgs e)
    {
      EditSelectedSpecification();
    }

    private void CmdUp_Click(object sender, EventArgs e)
    {
      var selIndex = mSpecs.SelectedIndex;
      if (selIndex <= 0)
      {
        return;
      }

      var tmp = mSpecFileNames[selIndex];
      mSpecFileNames[selIndex] = mSpecFileNames[selIndex - 1];
      mSpecFileNames[selIndex - 1] = tmp;

      UpdateUserInterface();

      mSpecs.SelectedIndex = selIndex - 1;

      FireConfigurationChanged();
    }

    private void CmdDown_Click(object sender, EventArgs e)
    {
      var selIndex = mSpecs.SelectedIndex;
      if (selIndex == mSpecs.Items.Count - 1)
      {
        return;
      }

      var tmp = mSpecFileNames[selIndex];
      mSpecFileNames[selIndex] = mSpecFileNames[selIndex + 1];
      mSpecFileNames[selIndex + 1] = tmp;

      UpdateUserInterface();

      mSpecs.SelectedIndex = selIndex + 1;

      FireConfigurationChanged();
    }

    private void Steps_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (mSpecs.SelectedIndex == -1)
      {
        return;
      }

      UpdateButtons();
    }

    public void RefreshSpecificationsList()
    {
      // nothing to refresh in UI, so ignore
    }

    private void Specs_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      var selIndex = mSpecs.SelectedIndex;
      if (selIndex == -1)
      {
        return;
      }

      EditSelectedSpecification();
    }
  }
}