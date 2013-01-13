﻿//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using EllieWare.Interfaces;

namespace EllieWare.Common
{
  public partial class FileSaveDialog : Form
  {
    private readonly IRobotWare mRoot;

    public FileSaveDialog()
    {
      InitializeComponent();
    }

    public FileSaveDialog(IRobotWare root) :
      this()
    {
      mRoot = root;
      mFileNames.DataSource = mRoot.Specifications.ToList();
    }

    public string FileName
    {
      set
      {
         mFileNames.Text = value;
      }
      get
      {
        return mFileNames.Text;
      }
    }

    private void FileSaveDialog_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (DialogResult == DialogResult.Cancel)
      {
        return;
      }

      var lowerCaseFileNames = from thisFileName in mRoot.Specifications select thisFileName.ToLower(CultureInfo.CurrentCulture);
      if (lowerCaseFileNames.Contains(FileName.ToLower(CultureInfo.CurrentCulture)))
      {
        var msg = string.Format("{0} already exists.\nDo you want to overwrite?", FileName);
        var retVal = MessageBox.Show(msg, "Confirm", MessageBoxButtons.OKCancel,
                                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
        if (retVal == DialogResult.Cancel)
        {
          e.Cancel = true;
          return;
        }
      }
    }

    private void FileSaveDialog_Shown(object sender, EventArgs e)
    {
      mFileNames.Focus();
    }
  }
}
