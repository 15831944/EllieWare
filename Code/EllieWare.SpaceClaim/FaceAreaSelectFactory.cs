﻿//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Collections.Generic;
using EllieWare.Common;
using EllieWare.Interfaces;

namespace EllieWare.SpaceClaim
{
  public class FaceAreaSelectFactory : FactoryBase
  {
    public override string Title
    {
      get
      {
        return "Select all faces below a threshold area";
      }
    }

    public override string Description
    {
      get
      {
        return "Select all faces below a threshold area";
      }
    }

    public override string Keywords
    {
      get
      {
        return "SpaceClaim, area, geometry";
      }
    }

    public override IEnumerable<string> Categories
    {
      get
      {
        return new[]
                     {
                       "SpaceClaim"
                     };
      }
    }

    public override Type CreatedType
    {
      get
      {
        return typeof(FaceAreaSelect);
      }
    }

    public override IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new FaceAreaSelect(root, callback, mgr);
    }
  }
}
