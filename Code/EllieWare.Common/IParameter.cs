﻿//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
namespace EllieWare.Common
{
  public interface IParameter
  {
    string DisplayName { get; set; }
    object ParameterValue { get; set; }
    string Summary { get; }
  }
}