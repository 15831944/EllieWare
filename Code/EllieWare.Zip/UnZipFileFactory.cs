﻿//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Collections.Generic;
using EllieWare.Interfaces;

namespace EllieWare.Zip
{
  public class UnZipFileFactory : ZipFactoryBase, IFactory
  {
    public string Title
    {
      get
      {
        return "Uncompress a zip archive into a directory";
      }
    }

    public string Description
    {
      get
      {
        return "Uncompress a zip archive into a directory";
      }
    }

    public Type CreatedType
    {
      get
      {
        return typeof(UnZipFile);
      }
    }

    public IRunnable Create(IEnumerable<object> roots, ICallback callback, IParameterManager mgr)
    {
      return new UnZipFile(roots, callback, mgr);
    }
  }
}
