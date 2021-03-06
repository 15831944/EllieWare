﻿//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using ComboxExtended;

namespace EllieWare.Common
{
  partial class FileSaveDialog
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      System.Windows.Forms.Button CmdCancel;
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileSaveDialog));
      this.CmdOK = new System.Windows.Forms.Button();
      this.mImages = new System.Windows.Forms.ImageList(this.components);
      this.mFileNames = new ComboxExtended.ImagedComboBox();
      tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      CmdCancel = new System.Windows.Forms.Button();
      tableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      tableLayoutPanel1.ColumnCount = 3;
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel1.Controls.Add(this.mFileNames, 0, 0);
      tableLayoutPanel1.Controls.Add(CmdCancel, 2, 1);
      tableLayoutPanel1.Controls.Add(this.CmdOK, 1, 1);
      tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 2;
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.Size = new System.Drawing.Size(399, 59);
      tableLayoutPanel1.TabIndex = 3;
      // 
      // CmdCancel
      // 
      CmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      CmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      CmdCancel.Location = new System.Drawing.Point(321, 33);
      CmdCancel.Name = "CmdCancel";
      CmdCancel.Size = new System.Drawing.Size(75, 23);
      CmdCancel.TabIndex = 2;
      CmdCancel.Text = "Cancel";
      CmdCancel.UseVisualStyleBackColor = true;
      // 
      // CmdOK
      // 
      this.CmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.CmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.CmdOK.Location = new System.Drawing.Point(240, 33);
      this.CmdOK.Name = "CmdOK";
      this.CmdOK.Size = new System.Drawing.Size(75, 23);
      this.CmdOK.TabIndex = 1;
      this.CmdOK.Text = "OK";
      this.CmdOK.UseVisualStyleBackColor = true;
      // 
      // mImages
      // 
      this.mImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("mImages.ImageStream")));
      this.mImages.TransparentColor = System.Drawing.Color.Transparent;
      this.mImages.Images.SetKeyName(0, "house_16x16.png");
      this.mImages.Images.SetKeyName(1, "clients_16x16.png");
      // 
      // mFileNames
      // 
      this.mFileNames.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      tableLayoutPanel1.SetColumnSpan(this.mFileNames, 3);
      this.mFileNames.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
      this.mFileNames.FormattingEnabled = true;
      this.mFileNames.Location = new System.Drawing.Point(3, 3);
      this.mFileNames.Name = "mFileNames";
      this.mFileNames.Size = new System.Drawing.Size(393, 21);
      this.mFileNames.TabIndex = 0;
      this.mFileNames.TextChanged += new System.EventHandler(this.FileNames_TextChanged);
      // 
      // FileSaveDialog
      // 
      this.AcceptButton = this.CmdOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = CmdCancel;
      this.ClientSize = new System.Drawing.Size(423, 83);
      this.Controls.Add(tableLayoutPanel1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.MaximumSize = new System.Drawing.Size(5000, 121);
      this.MinimumSize = new System.Drawing.Size(300, 121);
      this.Name = "FileSaveDialog";
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Save";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FileSaveDialog_FormClosing);
      this.Shown += new System.EventHandler(this.FileSaveDialog_Shown);
      tableLayoutPanel1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private ImagedComboBox mFileNames;
    private System.Windows.Forms.Button CmdOK;
    private System.Windows.Forms.ImageList mImages;
  }
}