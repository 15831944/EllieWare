﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using EllieWare.Common;
using EllieWare.Interfaces;

namespace EllieWare.Manager
{
  public partial class Editor : Form
  {
    private readonly IHostEx mHost;
    private readonly object mRoot;
    private readonly ICallbackEx mCallback;
    private ISpecification mSpecification;
    private string mFilePath;
    private readonly Adder mAddDlg;
    private readonly List<IFactory> mFactories = new List<IFactory>();

    private int mCurrentStep;

    public Editor()
    {
      InitializeComponent();
    }

    public Editor(IHostEx host, object root, ICallbackEx callback, string filePath) :
      this()
    {
      mHost = host;
      mRoot = root;
      mCallback = callback;
      mFilePath = filePath;

      InitialiseFactories();

      mAddDlg = new Adder(mFactories);
      mSpecification = new Specification(mRoot, mCallback, mFactories);
      mSteps.DataSource = mSpecification.Steps;

      LoadFromFile();
      ConnectChangeListeners();
      UpdateUserInterface();

      if (!string.IsNullOrEmpty(mFilePath))
      {
        UpdateTitle();
      }
    }

    private void UpdateTitle()
    {
      Text = string.Format("Editor - {0}", Path.GetFileNameWithoutExtension(mFilePath));
    }

    private void InitialiseFactories()
    {
      var callAssyLoc = Assembly.GetCallingAssembly().Location;
      var callAssyDir = Path.GetDirectoryName(callAssyLoc);
      var dllFiles = Directory.EnumerateFiles(callAssyDir, "*.dll");
      foreach (var thisDllFile in dllFiles)
      {
        try
        {
          var assy = Assembly.LoadFrom(thisDllFile);
          var factories = from t in assy.GetTypes()
                          where t.GetInterfaces().Contains(typeof(IFactory))
                          select Activator.CreateInstance(t) as IFactory;
          mFactories.AddRange(factories);
        }
        catch (BadImageFormatException)
        {
          // might not be a .NET dll but how?
        }
      }
    }

    private void ConnectChangeListeners()
    {
      var changeableSteps = mSpecification.Steps.OfType<IMutableRunnable>();
      foreach (var mutableRunnable in changeableSteps)
      {
        mutableRunnable.ConfigurationChanged += OnConfigurationChanged;
      }
    }

    private void LoadFromFile()
    {
      if (string.IsNullOrEmpty(mFilePath))
      {
        // new file
        return;
      }

      using (var fs = new FileStream(mFilePath, FileMode.Open))
      {
        var reader = XmlReader.Create(fs);
        mSpecification.ReadXml(reader);
      }
    }

    private void SaveToFile()
    {
      using (var fs = new FileStream(mFilePath, FileMode.Create))
      {
        var xs = new XmlSerializer(typeof(Specification));
        xs.Serialize(fs, mSpecification);
      }

      CmdSave.Enabled = false;
    }

    private void CmdSave_Click(object sender, EventArgs e)
    {
      if (string.IsNullOrEmpty(mFilePath))
      {
        // new file, so get file name
        var dlg = new FileSaveDialog(mHost);
        if (dlg.ShowDialog() != DialogResult.OK)
        {
          // user cancelled
          return;
        }

        var filePath = Path.Combine(mHost.SpecificationsFolder, dlg.FileName);
        mFilePath = Path.ChangeExtension(filePath, Manager.MacroFileExtension);

        UpdateTitle();
      }
      SaveToFile();

      mHost.RefreshSpecificationsList();
    }

    private void Steps_SelectedIndexChanged(object sender, EventArgs e)
    {
      mStepsContainer.Panel2.Controls.Clear();
      var step = (IRunnable)mSteps.SelectedItem;
      mStepsContainer.Panel2.Controls.Add(step.ConfigurationUserInterface);
      step.ConfigurationUserInterface.Dock = DockStyle.Fill;

      UpdateButtons();
    }

    private void SetupForRun()
    {
      mCallback.Clear();
      mCallback.Show();
      mCallback.Log(LogLevel.Information, "Started");
      mCallback.AllowClose = false;
    }

    private void ReportFailure()
    {
      mCallback.Log(LogLevel.Critical, "Error!");

      var step = (IRunnable)mSteps.Items[mCurrentStep];
      mCallback.Log(LogLevel.Critical, "  " + step.Description);
    }

    public void Run()
    {
      if (mCurrentStep == 0)
      {
        SetupForRun();
      }

      // if user presses Run while Step(ping), run from current step
      for (; mCurrentStep < mSteps.Items.Count; mCurrentStep++)
      {
        if (!Run(mCurrentStep))
        {
          ReportFailure();

          break;
        }
      }

      TearDownForRun();
    }

    private void TearDownForRun()
    {
      mCurrentStep = 0;
      mCallback.AllowClose = true;
      mCallback.Log(LogLevel.Information, "Finished");
    }

    private void CmdRun_Click(object sender, EventArgs e)
    {
      Run();
    }

    private void CmdStep_Click(object sender, EventArgs e)
    {
      if (mCurrentStep >= mSteps.Items.Count)
      {
        mSteps.SelectedIndex = 0;

        TearDownForRun();

        return;
      }

      if (mCurrentStep == 0)
      {
        SetupForRun();
      }

      mSteps.SelectedIndex = mCurrentStep;
      if (!Run(mCurrentStep))
      {
        ReportFailure();
      }

      mCurrentStep++;
    }

    private bool Run(int stepNum)
    {
      var step = (IRunnable)mSteps.Items[stepNum];

      return step.Run();
    }

    private void UpdateButtons()
    {
      CmdDelete.Enabled = CmdRun.Enabled = CmdStep.Enabled = CmdUp.Enabled = CmdDown.Enabled = mSpecification.Steps.Count > 0;

      var selIndex = mSteps.SelectedIndex;
      CmdUp.Enabled &= (selIndex > 0);
      CmdDown.Enabled &= (selIndex < mSteps.Items.Count - 1);
    }

    private void UpdateUserInterface()
    {
      mSteps.RefreshItems();
      UpdateButtons();
    }

    private void OnConfigurationChanged(object sender, EventArgs e)
    {
      var selIndex = mSteps.SelectedIndex;
      if (selIndex == -1)
      {
        return;
      }

      try
      {
        // ListBox.RefreshItems causes change in selection, so temporarily disable
        // while we update the UI description for this step
        mSteps.SelectedIndexChanged -= Steps_SelectedIndexChanged;
        mSteps.RefreshItem(selIndex);
      }
      finally
      {
        mSteps.SelectedIndexChanged += Steps_SelectedIndexChanged;
      }

      CmdSave.Enabled = true;
    }

    private void CmdAdd_Click(object sender, EventArgs e)
    {
      if (mAddDlg.ShowDialog() != DialogResult.OK)
      {
        return;
      }

      var selFactory = mAddDlg.SelectedFactory;
      var step = selFactory.Create(mRoot, mCallback, mSpecification.ParameterManager);

      var changeableStep = step as IMutableRunnable;
      if (changeableStep != null)
      {
        changeableStep.ConfigurationChanged += OnConfigurationChanged;
      }

      mSpecification.Steps.Add(step);
      CmdSave.Enabled = true;

      UpdateUserInterface();

      mSteps.SelectedIndex = mSteps.Items.Count - 1;
    }

    private void CmdDelete_Click(object sender, EventArgs e)
    {
      var selIndex = mSteps.SelectedIndex;
      if (selIndex == -1)
      {
        return;
      }

      mSpecification.Steps.RemoveAt(selIndex);
      CmdSave.Enabled = true;
      mStepsContainer.Panel2.Controls.Clear();
      UpdateUserInterface();
    }

    private void CmdUp_Click(object sender, EventArgs e)
    {
      var selIndex = mSteps.SelectedIndex;
      if (selIndex <= 0)
      {
        return;
      }

      var tmp = mSpecification.Steps[selIndex];
      mSpecification.Steps[selIndex] = mSpecification.Steps[selIndex - 1];
      mSpecification.Steps[selIndex - 1] = tmp;
      CmdSave.Enabled = true;

      UpdateUserInterface();

      mSteps.SelectedIndex = selIndex - 1;
    }

    private void CmdDown_Click(object sender, EventArgs e)
    {
      var selIndex = mSteps.SelectedIndex;
      if (selIndex == mSteps.Items.Count - 1)
      {
        return;
      }

      var tmp = mSpecification.Steps[selIndex];
      mSpecification.Steps[selIndex] = mSpecification.Steps[selIndex + 1];
      mSpecification.Steps[selIndex + 1] = tmp;
      CmdSave.Enabled = true;

      UpdateUserInterface();

      mSteps.SelectedIndex = selIndex + 1;
    }

    private void CmdHelp_Click(object sender, EventArgs e)
    {
      // TODO   help
    }

    private void Editor_FormClosed(object sender, FormClosedEventArgs e)
    {
      mCallback.AllowClose = true;
    }
  }
}
