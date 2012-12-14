﻿using System;
using System.Collections.Generic;
using EllieWare.Interfaces;

namespace EllieWare.Transfer.FTP
{
  public abstract class FtpFactoryBase
  {
    #region Implementation of IFactory

    public abstract string Title { get; }
    public abstract string Description { get; }

    public string Keywords
    {
      get
      {
        return "ftp, transfer";
      }
    }

    public IEnumerable<string> Categories
    {
      get
      {
        return new[]
                     {
                       "File Transfer"
                     };
      }
    }

    public abstract Type CreatedType { get; }
    public abstract IRunnable Create(object root, ICallback callback, IParameterManager mgr);

    #endregion
  }
}
