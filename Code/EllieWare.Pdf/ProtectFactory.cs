﻿//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using EllieWare.Interfaces;

namespace EllieWare.Pdf
{
  public class ProtectFactory : PdfFactoryBase
  {
    public override string Title
    {
      get
      {
        return "Password protect a PDF file";
      }
    }

    public override string Description
    {
      get
      {
        return "Password protect a PDF file and set various security options";
      }
    }

    public override string Keywords
    {
      get
      {
        return base.Keywords + ", password, permission, owner, user, security, encryption";
      }
    }

    public override Type CreatedType
    {
      get
      {
        return typeof(Protect);
      }
    }

    public override IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new Protect(root, callback, mgr);
    }
  }
}
