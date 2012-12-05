﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;
using EllieWare.Common;
using EllieWare.Interfaces;

namespace EllieWare.Logging
{
  public partial class Logging : MutableRunnableBase
  {
    public Logging()
    {
      InitializeComponent();
    }

    public Logging(object root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
      InitializeComponent();

      mLevel.SelectedIndex = 0;
    }

    public override string Description
    {
      get
      {
        var level = (LogLevel) mLevel.SelectedIndex;
        return string.Format("{0} : {1}", level, mMessage.Text);
      }
    }

    public override Control ConfigurationUserInterface
    {
      get
      {
        return this;
      }
    }

    public override bool Run()
    {
      mCallback.Log((LogLevel)mLevel.SelectedIndex, mMessage.Text);

      return true;
    }

    public override void ReadXml(XmlReader reader)
    {
      var levelStr = reader.GetAttribute("Level");
      var levelNum = int.Parse(levelStr, NumberStyles.Integer, CultureInfo.InvariantCulture);
      mLevel.SelectedIndex = levelNum;
      mMessage.Text = reader.GetAttribute("Message");
    }

    public override void WriteXml(XmlWriter writer)
    {
      writer.WriteAttributeString("Level", mLevel.SelectedIndex.ToString(CultureInfo.InvariantCulture));
      writer.WriteAttributeString("Message", mMessage.Text);
    }

    private void Level_SelectedIndexChanged(object sender, EventArgs e)
    {
      FireConfigurationChanged();
    }

    private void Message_TextChanged(object sender, EventArgs e)
    {
      FireConfigurationChanged();
    }
  }
}
