﻿using System.IO;
using EllieWare.Common;
using EllieWare.Interfaces;

namespace EllieWare.IO
{
  public class DirectoryCreate : SingleItemIOBase
  {
    public DirectoryCreate()
    {
    }

    public DirectoryCreate(object root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr, BrowserTypes.BothDirectory)
    {
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Create {0}", SourceFilePathResolvedValue);

        return descrip;
      }
    }

    public override bool Run()
    {
      Directory.CreateDirectory(SourceFilePathResolvedValue);

      return true;
    }
  }
}
