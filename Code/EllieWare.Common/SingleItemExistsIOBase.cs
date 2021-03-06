﻿//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using EllieWare.Interfaces;

namespace EllieWare.Common
{
  public abstract class SingleItemExistsIOBase : MutableRunnableBase<SingleItemExistsIOBaseCtrl>
  {
    public SingleItemExistsIOBase()
    {
    }

    public SingleItemExistsIOBase(IRobotWare root, ICallback callback, IParameterManager mgr, BrowserTypes browsers) :
      base(root, callback, mgr)
    {
      mControl.Initialise(root, callback, mgr, browsers);
    }
  }
}
