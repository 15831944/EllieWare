﻿//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Drawing;
using SerpentWare.Common;
using SerpentWare.Common.Properties;
using SerpentWare.Interfaces;
using SpaceClaim.Api.V10;
using SpaceClaim.Api.V10.Extensibility;

namespace SerpentWare.SpaceClaim
{
  public class PythonCapsule : CommandCapsule
  {
    private const string ApplicationName = "SerpentWare for SpaceClaim";

    private readonly ISerpentWare mLicenseWrapper = new SerpentWareSpaceClaim(ApplicationName);

    public PythonCapsule()
      : base("SerpentWare.SpaceClaim.Console", "Python", Resources.python_32x32, "Run a Python script")
    {
    }

    protected override void OnUpdate(Command command)
    {
      command.IsEnabled = true;
    }

    protected sealed override void OnExecute(Command command, ExecutionContext context, Rectangle buttonRect)
    {
      var dlg = new PyConsole(mLicenseWrapper);
      dlg.ShowDialog();
    }
  }
}
