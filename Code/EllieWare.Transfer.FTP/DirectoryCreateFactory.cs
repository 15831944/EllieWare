﻿//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using EllieWare.Interfaces;

namespace EllieWare.Transfer.FTP
{
  public class DirectoryCreateFactory : FtpFactoryBase
  {
    public override string Title
    {
      get
      {
        return "FTP directory creator";
      }
    }

    public override string Description
    {
      get
      {
        return "Create a directory on an FTP site";
      }
    }

    public override Type CreatedType
    {
      get
      {
        return typeof(DirectoryCreate);
      }
    }

    public override IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new DirectoryCreate(root, callback, mgr);
    }
  }
}
