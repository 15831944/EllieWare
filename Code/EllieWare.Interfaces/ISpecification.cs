﻿//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Collections.Generic;
using System.Xml.Serialization;

namespace EllieWare.Interfaces
{
  /// <summary>
  /// A <see cref="IParameterManager"/> and a series of <see cref="IRunnable"/> steps which are serializable
  /// </summary>
  public interface ISpecification : IXmlSerializable
  {
    /// <summary>
    /// A <see cref="IParameterManager"/> from which each <see cref="IRunnable"/> step can get its <see cref="ISerializableParameter"/>
    /// </summary>
    IParameterManager ParameterManager { get; }

    /// <summary>
    /// A series of <see cref="IRunnable"/> steps which are run in order
    /// </summary>
    List<IRunnable> Steps { get; }
  }
}
