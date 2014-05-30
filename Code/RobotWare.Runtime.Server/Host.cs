﻿//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Diagnostics;
using System.Security.Permissions;
using System.Threading;
using System.Windows.Forms;
using AutoUpdaterDotNET;
using CrashReporterDotNET;
using EllieWare.Common;
using EllieWare.Interfaces;
using Quartz;

namespace RobotWare.Runtime.Server
{
  [EventLogPermission(SecurityAction.Demand)]
  public class Host : ICallback, IJob
  {
    private const string ApplicationName = "RobotWare Runtime for Windows Server";

    private readonly IRobotWare mRoot = new RobotWareWrapper(ApplicationName);

    public Host()
    {
      if (!mRoot.IsLicensed)
      {
        return;
      }

      // http://crashreporterdotnet.codeplex.com/documentation
      Application.ThreadException += ApplicationThreadException;

      // http://autoupdaterdotnet.codeplex.com/documentation
      const string EllieWare = @"http://www.EllieWare.com";
      var appCast = mRoot.ApplicationName.Replace(' ', '_') + ".xml";
      var appCastUrl = EllieWare + @"/" + appCast;
      AutoUpdater.Start(appCastUrl, mRoot.ApplicationName, mRoot.Version);
    }

    private void ApplicationThreadException(object sender, ThreadExceptionEventArgs e)
    {
      var reportCrash = new ReportCrash
                              {
                                ToEmail = "support@EllieWare.com"
                              };

      reportCrash.Send(e.Exception);
    }

    public void Log(LogLevel level, string message)
    {
      // map RobotWare levels to Windows levels
      var winLevel = EventLogEntryType.Error;
      switch (level)
      {
        case LogLevel.Debug:
        case LogLevel.Information:
          winLevel = EventLogEntryType.Information;
          break;

        case LogLevel.Warning:
          winLevel = EventLogEntryType.Warning;
          break;

        case LogLevel.Severe:
        case LogLevel.Critical:
          winLevel = EventLogEntryType.Error;
          break;

        default:
          throw new ArgumentOutOfRangeException("Unknown enum value:" + level.ToString());
      }

      if (!EventLog.SourceExists(ApplicationName))
      {
        EventLog.CreateEventSource(ApplicationName, "Application");
      }

      EventLog.WriteEntry(ApplicationName, message, winLevel);
    }

    public void Execute(IJobExecutionContext context)
    {
      // From:
      //    http://www.quartz-scheduler.net/documentation/quartz-2.x/tutorial/more-about-jobs.html
      //
      // Finally, we need to inform you of a few details of the IJob.Execute(..) method. The only type of exception
      // that you should throw from the execute method is the JobExecutionException. Because of this, you should
      // generally wrap the entire contents of the execute method with a 'try-catch' block. You should also spend
      // some time looking at the documentation for the JobExecutionException, as your job can use it to provide
      // the scheduler various directives as to how you want the exception to be handled.
      try
      {
        var logger = Common.Logging.LogManager.GetLogger(typeof(Host));
        var macroFilePath = context.MergedJobDataMap.GetString("MacroFilePath");
        var engine = new Engine(mRoot, this, macroFilePath);

        logger.Trace(string.Format("{0} running {1} ...", ApplicationName, macroFilePath));
        var bRet = engine.Run();
        logger.Trace(string.Format("{0} finished {1} : {2}", ApplicationName, macroFilePath, bRet ? "Succeeded" : "Failed"));
      }
      catch (Exception ex)
      {
        throw new JobExecutionException(ex);
      }
    }
  }
}
