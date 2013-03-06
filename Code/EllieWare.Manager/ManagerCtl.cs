﻿//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using AutoUpdaterDotNET;
using CrashReporterDotNET;
using EllieWare.Common;
using EllieWare.Interfaces;

namespace EllieWare.Manager
{
  public partial class ManagerCtl : UserControl, IHost
  {
    private readonly IRobotWare mRoot;

    public ManagerCtl()
    {
      InitializeComponent();
    }

    public ManagerCtl(IRobotWare root) :
      this()
    {
      mRoot = root;
      if (!mRoot.IsLicensed)
      {
        DoRequestLicense();
      }

      // http://crashreporterdotnet.codeplex.com/documentation
      Application.ThreadException += ApplicationThreadException;

      // http://autoupdaterdotnet.codeplex.com/documentation
      const string EllieWare = @"http://www.EllieWare.com";
      var appCast = mRoot.ApplicationName.Replace(' ', '_') + ".xml";
      var appCastUrl = EllieWare + @"/" + appCast;
      AutoUpdater.Start(appCastUrl, mRoot.ApplicationName, mRoot.Version);

      RefreshSpecificationsList();
      UpdateButtons();
    }

    #region IHost

    public void RefreshSpecificationsList()
    {
      RefreshSpecificationsList(SearchBox.Text.ToLower(CultureInfo.CurrentCulture));
    }

    #endregion

    private void ApplicationThreadException(object sender, ThreadExceptionEventArgs e)
    {
      var reportCrash = new ReportCrash
                              {
                                ToEmail = "support@EllieWare.com"
                              };

      reportCrash.Send(e.Exception);
    }

    private void DoRequestLicense()
    {
      var dlg = new RequestLicense(mRoot);
      if (dlg.ShowDialog() == DialogResult.OK)
      {
        // attempt to register with provided info
        Licensing.LicenseManager.Register(mRoot.ApplicationName, mRoot.Version, dlg.UserName.Text, dlg.LicenseCode.Text);

        var isLicensed = mRoot.IsLicensed;
        var msg = string.Format(isLicensed ? "Successfully registered:" + Environment.NewLine +
                                             "  " + mRoot.ApplicationName
                                  : "Information incorrect - product not registered");
        MessageBox.Show(msg, mRoot.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
      }
    }

    private string GetSelectedSpecificationPath()
    {
      var slvi = (SpecificationFileListViewItem) mSpecs.SelectedItems[0];

      return slvi.FilePath;
    }

    private void CmdNew_Click(object sender, EventArgs e)
    {
      var dlg = new Editor(this, mRoot, string.Empty);
      dlg.ShowDialog();

      UpdateButtons();
    }

    private void CmdEdit_Click(object sender, EventArgs e)
    {
      var dlg = new Editor(this, mRoot, GetSelectedSpecificationPath());
      dlg.ShowDialog();

      UpdateButtons();
    }

    private void CmdRun_Click(object sender, EventArgs e)
    {
      Run(GetSelectedSpecificationPath());

      UpdateButtons();
    }

    private void Run(string filePath)
    {
      var dlg = new Editor(this, mRoot, filePath);
      dlg.Show(this);
      dlg.Run();
    }

    private void RefreshSpecificationsList(string searchTxt)
    {
      mSpecs.Items.Clear();

      var filteredSpecsWithExten = from specWithExtn in mRoot.Specifications
                                   let specNoExtn = Path.GetFileNameWithoutExtension(specWithExtn)
                                   where specNoExtn.ToLower(CultureInfo.CurrentCulture).Contains(searchTxt)
                                   select specWithExtn;

      foreach (var specWithExtn in filteredSpecsWithExten)
      {
        var lvi = new SpecificationFileListViewItem(mRoot, specWithExtn);
        mSpecs.Items.Add(lvi);
      }

      UpdateButtons();
    }

    private void UpdateButtons()
    {
      CmdEdit.Enabled = CmdDelete.Enabled = FileOperations.Enabled = CmdRun.Enabled = mSpecs.SelectedItems.Count > 0;

      if (mSpecs.SelectedItems.Count > 0)
      {
        CmdDelete.Enabled = FileOperations.Enabled = Utils.IsLocalSpecification(mRoot, GetSelectedSpecificationPath());
      } 
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
      var dlg = new AboutBox(mRoot.ApplicationName);
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
      var fullPath = Path.Combine(mRoot.UserSpecificationFolder, fileName);
      var number = 1;
      while (File.Exists(fullPath))
      {
        fileName = String.Concat(string.Format("{0} - Copy ({1})", fileRoot, ++number), extension);
        fullPath = Path.Combine(mRoot.UserSpecificationFolder, fileName);
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

    private void CmdHelp_Click(object sender, EventArgs e)
    {
      // TODO   help for RobotWare plugins
      // help file lives next to assy
      var assy = Assembly.GetExecutingAssembly();
      var assyPath = assy.Location;
      var assyDir = Path.GetDirectoryName(assyPath);
      var helpFilePath = Path.Combine(assyDir, "EllieWare.RobotWare.chm");

      // create an invisible form as help window parent,
      // so help file is not topmost
      Help.ShowHelp(new Form(), helpFilePath);
    }

    private void FileOpRename_Click(object sender, EventArgs e)
    {
      var selSpecPath = GetSelectedSpecificationPath();
      var dlg = new FileSaveDialog(mRoot) { FileName = Path.GetFileNameWithoutExtension(selSpecPath) };
      if (dlg.ShowDialog() != DialogResult.OK)
      {
        return;
      }

      var filePathNoExtn = Path.Combine(mRoot.UserSpecificationFolder, dlg.FileName);
      var filePath = Path.ChangeExtension(filePathNoExtn, EllieWare.Interfaces.FileExtensions.MacroFileExtension);

      if (File.Exists(filePath))
      {
        File.Delete(filePath);
      }
      File.Move(selSpecPath, filePath);
      RefreshSpecificationsList(SearchBox.Text.ToLower(CultureInfo.CurrentCulture));
    }
  }
}
