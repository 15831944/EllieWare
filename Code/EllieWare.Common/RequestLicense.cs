﻿//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Windows.Forms;

namespace EllieWare.Common
{
  public partial class RequestLicense : Form
  {
    public RequestLicense()
    {
      InitializeComponent();
    }

    public RequestLicense(string appName, Version appVer) :
      this()
    {
      Product.Text = appName;
      Version.Text = appVer.ToString(3);
    }

    private void RequestLicense_Shown(object sender, EventArgs e)
    {
      UserName.Focus();
    }
  }
}
