﻿//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Collections.Generic;
using EllieWare.Interfaces;

namespace EllieWare.SpaceClaim
{
  public class FaceCurvatureRemoveFactory : IFactory
  {
    public string Title
    {
      get
      {
        return "Remove all faces below a threshold curvature";
      }
    }

    public string Description
    {
      get
      {
        return "Remove all faces below a threshold curvature";
      }
    }

    public string Keywords
    {
      get
      {
        return "SpaceClaim, area, geometry";
      }
    }

    public IEnumerable<string> Categories
    {
      get
      {
        return new[]
                     {
                       "SpaceClaim"
                     };
      }
    }

    public Type CreatedType
    {
      get
      {
        return typeof(FaceCurvatureRemove);
      }
    }

    public IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new FaceCurvatureRemove(root, callback, mgr);
    }
  }
}
