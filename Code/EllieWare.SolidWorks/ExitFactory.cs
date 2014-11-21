﻿//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//

using System;
using System.Collections.Generic;
using EllieWare.Common;
using EllieWare.Interfaces;

namespace EllieWare.SolidWorks
{
  public class ExitFactory : FactoryBase
  {
    public override string Title
    {
      get
      {
        return "Shuts down SolidWorks";
      }
    }

    public override string Description
    {
      get
      {
        return "Shuts down SolidWorks";
      }
    }

    public override string Keywords
    {
      get
      {
        return "SolidWorks, exit";
      }
    }

    public override IEnumerable<string> Categories
    {
      get
      {
        return new[]
                     {
                       "SolidWorks"
                     };
      }
    }

    public override Type CreatedType
    {
      get
      {
        return typeof(Exit);
      }
    }

    public override IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new Exit(root, callback, mgr);
    }
  }
}
