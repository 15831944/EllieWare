﻿//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Collections.Generic;

namespace EllieWare.Interfaces
{
  /// <summary>
  /// Base interface for all batch parameters
  /// </summary>
  public interface IBatchParameter : IParameter
  {
    /// <summary>
    /// A list of strings from the specific implementation/specialization of IBatchParameter
    /// </summary>
    IEnumerable<string> ResolvedValues { get; }
  }
}
