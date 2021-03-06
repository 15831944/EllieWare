﻿//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using EllieWare.Interfaces;

namespace EllieWare.Logging
{
  public class LoggingFactory : LoggingFactoryBase
  {
    public override string Title
    {
      get
      {
        return "Log a message";
      }
    }

    public override string Description
    {
      get
      {
        return "Log messages to the output window";
      }
    }

    public override Type CreatedType
    {
      get
      {
        return typeof (Logging);
      }
    }

    public override IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new Logging(root, callback, mgr);
    }
  }
}
