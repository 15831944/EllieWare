﻿//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using EllieWare.Interfaces;
using SpaceClaim.Api.V10;

namespace EllieWare.SpaceClaim
{
  public class ClearSelection : SpaceClaimMutableRunnableBase
  {
    public ClearSelection()
    {
    }

    public ClearSelection(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Clear the current selection(s)");

        return descrip;
      }
    }

    protected override bool DoRun()
    {
      Window.ActiveWindow.ActiveContext.Selection = null;

      return true;
    }
  }
}
