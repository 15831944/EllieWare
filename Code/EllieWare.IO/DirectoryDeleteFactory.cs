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

namespace EllieWare.IO
{
  public class DirectoryDeleteFactory : IOFactoryBase, IFactory
  {
    public override string Title
    {
      get
      {
        return "Delete a directory";
      }
    }

    public override string Description
    {
      get
      {
        return "Delete a directory and any subdirectories and files";
      }
    }

    public override Type CreatedType
    {
      get
      {
        return typeof(DirectoryDelete);
      }
    }

    public override IRunnable Create(IEnumerable<object> roots, ICallback callback, IParameterManager mgr)
    {
      return new DirectoryDelete(roots, callback, mgr);
    }
  }
}
