﻿//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using EllieWare.Interfaces;

namespace EllieWare.Common
{
  public class Parameter : IParameter
  {
    public string DisplayName { get; set; }
    public object ParameterValue { get; set; }

    public virtual string Summary
    {
      get
      {
        // TODO   support other data types ie number, array of string aka object
        // TODO   use CultureInfo.InvariantCulture for numbers
        return DisplayName + " --> " + ParameterValue;
      }
    }

    public Parameter()
    {
    }

    public Parameter(string name, object paramValue)
    {
      DisplayName = name;
      ParameterValue = paramValue;
    }
  }
}
