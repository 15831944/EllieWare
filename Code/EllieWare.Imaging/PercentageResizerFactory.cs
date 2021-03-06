﻿//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using EllieWare.Interfaces;

namespace EllieWare.Imaging
{
  public class PercentageResizerFactory : ImagingFactoryBase
  {
    public override string Title
    {
      get
      {
        return "Resize an image by a percentage";
      }
    }

    public override string Description
    {
      get
      {
        return "Resize an image by a percentage of the original size, maintaining the aspect ratio";
      }
    }

    public override Type CreatedType
    {
      get
      {
        return typeof(PercentageResizer);
      }
    }

    public override IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new PercentageResizer(root, callback, mgr);
    }
  }
}
