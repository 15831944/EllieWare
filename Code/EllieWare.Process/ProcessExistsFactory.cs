﻿using System;
using EllieWare.Interfaces;

namespace EllieWare.Process
{
  public class ProcessExistsFactory : ProcessFactoryBase, IFactory
  {
    public string Title
    {
      get
      {
        return "Check if a process is running";
      }
    }

    public string Description
    {
      get
      {
        return "Check if a process is running or not";
      }
    }

    public Type CreatedType
    {
      get
      {
        return typeof(ProcessExists);
      }
    }

    public IRunnable Create(object root, ICallback callback, IParameterManager mgr)
    {
      return new ProcessExists(root, callback, mgr);
    }
  }
}