﻿//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using EllieWare.Interfaces;

namespace EllieWare.Common
{
  public class SerializableBatchParameter : BatchParameter, ISerializableBatchParameter
  {
    public SerializableBatchParameter() :
      base()
    {
    }

    public SerializableBatchParameter(string name, string paramValue) :
      base(name, paramValue)
    {
    }

    public override string Summary
    {
      get
      {
        var summ = string.Format("{0} -- > {1}", DisplayName, ParameterValue);

        return summ;
      }
    }
    public override IEnumerable<string> ResolvedValues
    {
      get
      {
        return new List<string>();
      }
    }

    public XmlSchema GetSchema()
    {
      return null;
    }

    public virtual void ReadXml(XmlReader reader)
    {
      DisplayName = reader.GetAttribute("DisplayName");

      var typeStr = reader.GetAttribute("ValueType");
      var objType = Type.GetType(typeStr);
      var objData = reader.GetAttribute("Value");
      ParameterValue = XmlSerializationHelpers.XmlDeserializeFromString(objData, objType);
    }

    public virtual void WriteXml(XmlWriter writer)
    {
      writer.WriteAttributeString("DisplayName", DisplayName);

      var objType = ParameterValue.GetType();
      writer.WriteAttributeString("ValueType", objType.ToString());

      var objData = XmlSerializationHelpers.XmlSerializeToString(ParameterValue);
      writer.WriteAttributeString("Value", objData);
    }
  }
}
