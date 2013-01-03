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

namespace EllieWare.Imaging
{
  public class ConversionFactory : ImagingFactoryBase, IFactory
  {
    public override string Title
    {
      get
      {
        return "Convert an image";
      }
    }

    public override string Description
    {
      get
      {
        return "Convert an image from one format to another";
      }
    }

    public override Type CreatedType
    {
      get
      {
        return typeof(Conversion);
      }
    }

    public override IRunnable Create(IEnumerable<object> roots, ICallback callback, IParameterManager mgr)
    {
      return new Conversion(roots, callback, mgr);
    }
  }
}
