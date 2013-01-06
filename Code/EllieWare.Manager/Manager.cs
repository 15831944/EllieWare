﻿//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using EllieWare.Common;

namespace EllieWare.Manager
{
  public partial class Manager : Form, IHost
  {
    private readonly IEnumerable<object> mRoots;
    private readonly IRobotWare mRobotWare;

    public Manager()
    {
      InitializeComponent();
    }

    public Manager(IEnumerable<object> roots) :
      this()
    {
      mRoots = roots;

      mRobotWare = roots.Where(x => x is IRobotWare).Single() as IRobotWare;
      if (!mRobotWare.IsLicensed)
      {
        var dlg = new RequestLicense(mRobotWare.ApplicationName);
        if (dlg.ShowDialog() == DialogResult.OK)
        {
          // attempt to register with provided info
          Licensing.LicenseManager.Register(mRobotWare.ApplicationName, dlg.UserName.Text, dlg.LicenseCode.Text);

          var isLicensed = mRobotWare.IsLicensed;
          var msg = string.Format(isLicensed ? "Successfully registered:" + Environment.NewLine +
                                                  "  " + mRobotWare.ApplicationName + Environment.NewLine +
                                                  "to:" + Environment.NewLine +
                                                  "  " + dlg.UserName
                                                  : "Information incorrect - product not registered");
          MessageBox.Show(msg, mRobotWare.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }
      }
      
      SpecificationsFolder = mRobotWare.UserSpecificationFolder;

      RefreshSpecificationsList();
      UpdateButtons();
    }

    private string GetSelectedSpecificationPath()
    {
      var pathNoExtn = Path.Combine(SpecificationsFolder, mSpecs.SelectedItems[0].Text);
      var retVal = Path.ChangeExtension(pathNoExtn, Utils.MacroFileExtension);

      return retVal;
    }

    private void CmdNew_Click(object sender, EventArgs e)
    {
      var dlg = new Editor(this, mRoots, string.Empty);
      dlg.ShowDialog();

      UpdateButtons();
    }

    private void CmdEdit_Click(object sender, EventArgs e)
    {
      var dlg = new Editor(this, mRoots, GetSelectedSpecificationPath());
      dlg.ShowDialog();

      UpdateButtons();
    }

    private void CmdRun_Click(object sender, EventArgs e)
    {
      Run(GetSelectedSpecificationPath());

      UpdateButtons();
    }

    private void CmdDebug_Click(object sender, EventArgs e)
    {
      var dlg = new Editor(this, mRoots, GetSelectedSpecificationPath());
      dlg.ShowDialog();

      UpdateButtons();
    }

    #region IHost

    public void Run(string filePath)
    {
      var dlg = new Editor(this, mRoots, filePath);
      dlg.Show(this);
      dlg.Run();
    }

    public void RefreshSpecificationsList()
    {
      RefreshSpecificationsList(string.Empty);
    }

    public string SpecificationsFolder { get; private set; }

    public IEnumerable<string> Specifications
    {
      get
      {
        var allSpecsWithExtn = Directory.EnumerateFiles(SpecificationsFolder, "*" + Utils.MacroFileExtension);
        var allSpecsNoExten = from specWithExtn in allSpecsWithExtn select Path.GetFileNameWithoutExtension(specWithExtn);

        return allSpecsNoExten;
      }
    }

    #endregion

    private void RefreshSpecificationsList(string searchTxt)
    {
      mSpecs.Items.Clear();

      var filteredSpecsNoExten = from specNoExtn in Specifications where (specNoExtn.ToLower(CultureInfo.CurrentCulture).Contains(searchTxt)) select new ListViewItem(specNoExtn);
      mSpecs.Items.AddRange(filteredSpecsNoExten.ToArray());
    }

    private void UpdateButtons()
    {
      CmdEdit.Enabled = CmdDelete.Enabled = CmdRun.Enabled = CmdDebug.Enabled = FileOperations.Enabled = mSpecs.SelectedItems.Count > 0;
    }

    private void Specs_SelectedIndexChanged(object sender, EventArgs e)
    {
      UpdateButtons();
    }

    private void CmdDelete_Click(object sender, EventArgs e)
    {
      var selFilePath = GetSelectedSpecificationPath();
      File.Delete(selFilePath);
      RefreshSpecificationsList();
      UpdateButtons();
    }

    private void Specs_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      CmdEdit_Click(sender, e);
    }

    private void CmdAbout_Click(object sender, EventArgs e)
    {
      var dlg = new AboutBox(mRobotWare.ApplicationName);
      dlg.ShowDialog();
    }

    private void Search_TextChanged(object sender, EventArgs e)
    {
      RefreshSpecificationsList(SearchBox.Text.ToLower(CultureInfo.CurrentCulture));
    }

    private void FileOperations_Opening(object sender, System.ComponentModel.CancelEventArgs e)
    {
      UpdateButtons();
    }

    private void FileOpCopy_Click(object sender, EventArgs e)
    {
      var selSpecPath = GetSelectedSpecificationPath();
      var fileRoot = Path.GetFileNameWithoutExtension(selSpecPath);
      var extension = Path.GetExtension(selSpecPath);
      var fileName = String.Concat(string.Format("{0} - Copy", fileRoot), extension);
      var fullPath = Path.Combine(SpecificationsFolder, fileName);
      var number = 1;
      while (File.Exists(fullPath))
      {
        fileName = String.Concat(string.Format("{0} - Copy ({1})", fileRoot, ++number), extension);
        fullPath = Path.Combine(SpecificationsFolder, fileName);
      }

      File.Copy(selSpecPath, fullPath);
      RefreshSpecificationsList(SearchBox.Text.ToLower(CultureInfo.CurrentCulture));
    }

    private void FileOpDelete_Click(object sender, EventArgs e)
    {
      File.Delete(GetSelectedSpecificationPath());
      RefreshSpecificationsList(SearchBox.Text.ToLower(CultureInfo.CurrentCulture));
    }

    private void FileOpShow_Click(object sender, EventArgs e)
    {
      var selectionArgs = @"/select, " + "\"" + GetSelectedSpecificationPath() + "\"";

      Process.Start("explorer.exe", selectionArgs);
    }
  }
}
