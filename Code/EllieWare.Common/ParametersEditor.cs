﻿//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using EllieWare.Interfaces;
using EllieWare.Support;

namespace EllieWare.Common
{
  public partial class ParametersEditor : Form
  {
    private bool mIsDirty;

    public ParametersEditor()
    {
      InitializeComponent();
    }

    public ParametersEditor(IParameterManager paramMgr) :
      this()
    {
      ParametersDisplay.Items.Clear();
      foreach (var displayName in paramMgr.Parameters)
      {
        ParametersDisplay.Items.Add(displayName);
      }
    }

    public IEnumerable<IParameter> Parameters
    {
      get
      {
        return ParametersDisplay.Items.Cast<IParameter>();
      }
    }

    private void EditSelectedParameter()
    {
      var selParam = (IParameter)ParametersDisplay.SelectedItem;
      var dlg = new AddEditParameter(Parameters, selParam);
      if (dlg.ShowDialog() != DialogResult.OK)
      {
        return;
      }

      selParam.ParameterValue = dlg.Parameter.ParameterValue;
      ParametersDisplay.RefreshItem(ParametersDisplay.SelectedIndex);
      CmdOK.Enabled = mIsDirty = true;
    }

    private void CmdAdd_Click(object sender, EventArgs e)
    {
      var dlg = new AddEditParameter(Parameters);
      if (dlg.ShowDialog() != DialogResult.OK)
      {
        return;
      }

      ParametersDisplay.Items.Add(dlg.Parameter);
      CmdOK.Enabled = mIsDirty = true;
    }

    private void CmdEdit_Click(object sender, EventArgs e)
    {
      EditSelectedParameter();
    }

    private void CmdDelete_Click(object sender, EventArgs e)
    {
      ParametersDisplay.Items.RemoveAt(ParametersDisplay.SelectedIndex);
      CmdOK.Enabled = mIsDirty = true;
    }

    private void Parameters_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (ParametersDisplay.SelectedIndex == -1)
      {
        CmdEdit.Enabled = CmdDelete.Enabled = false;

        return;
      }

      // cannot edit or delete batch parameters
      var isBatchParam = ParametersDisplay.SelectedItem is IBatchParameter;
      CmdEdit.Enabled = CmdDelete.Enabled = !isBatchParam;
    }

    private void ParametersDisplay_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      if (ParametersDisplay.SelectedIndex == -1)
      {
        return;
      }

      EditSelectedParameter();
    }

    private void ParametersEditor_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (!mIsDirty || DialogResult == DialogResult.OK)
      {
        return;
      }

      var msg = string.Format("You have unsaved changes.\nDo you want to save them?");
      var retVal = MessageBox.Show(msg, "Confirm", MessageBoxButtons.YesNoCancel,
                                   MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
      if (retVal == DialogResult.Cancel)
      {
        e.Cancel = true;
        return;
      }
      if (retVal == DialogResult.Yes)
      {
        DialogResult = DialogResult.OK;
        return;
      }
    }

    private void ParametersEditor_Load(object sender, EventArgs e)
    {
      WindowPersister.Restore(Assembly.GetExecutingAssembly(), this);
    }

    private void ParametersEditor_FormClosed(object sender, FormClosedEventArgs e)
    {
      WindowPersister.Record(Assembly.GetExecutingAssembly(), this);
    }
  }
}
