﻿//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using EllieWare.Support;

namespace EllieWare.Common
{
  partial class ParametersEditor
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
      System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
      System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
      System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
      System.Windows.Forms.ToolTip ParametersEditorTips;
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ParametersEditor));
      this.CmdAdd = new System.Windows.Forms.Button();
      this.CmdEdit = new System.Windows.Forms.Button();
      this.CmdDelete = new System.Windows.Forms.Button();
      this.CmdCancel = new System.Windows.Forms.Button();
      this.CmdOK = new System.Windows.Forms.Button();
      this.ParametersDisplay = new EllieWare.Support.RefreshingListBox();
      tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
      tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
      tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
      ParametersEditorTips = new System.Windows.Forms.ToolTip(this.components);
      tableLayoutPanel1.SuspendLayout();
      tableLayoutPanel2.SuspendLayout();
      tableLayoutPanel4.SuspendLayout();
      tableLayoutPanel3.SuspendLayout();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      tableLayoutPanel1.AutoSize = true;
      tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      tableLayoutPanel1.ColumnCount = 1;
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel1.Controls.Add(this.CmdAdd, 0, 0);
      tableLayoutPanel1.Controls.Add(this.CmdEdit, 0, 1);
      tableLayoutPanel1.Controls.Add(this.CmdDelete, 0, 2);
      tableLayoutPanel1.Location = new System.Drawing.Point(518, 3);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 3;
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.Size = new System.Drawing.Size(46, 138);
      tableLayoutPanel1.TabIndex = 8;
      // 
      // CmdAdd
      // 
      this.CmdAdd.Image = global::EllieWare.Common.Properties.Resources.add_32x32;
      this.CmdAdd.Location = new System.Drawing.Point(3, 3);
      this.CmdAdd.Name = "CmdAdd";
      this.CmdAdd.Size = new System.Drawing.Size(40, 40);
      this.CmdAdd.TabIndex = 0;
      ParametersEditorTips.SetToolTip(this.CmdAdd, "Add...");
      this.CmdAdd.UseVisualStyleBackColor = true;
      this.CmdAdd.Click += new System.EventHandler(this.CmdAdd_Click);
      // 
      // CmdEdit
      // 
      this.CmdEdit.Enabled = false;
      this.CmdEdit.Image = global::EllieWare.Common.Properties.Resources.pencil_32x32;
      this.CmdEdit.Location = new System.Drawing.Point(3, 49);
      this.CmdEdit.Name = "CmdEdit";
      this.CmdEdit.Size = new System.Drawing.Size(40, 40);
      this.CmdEdit.TabIndex = 1;
      ParametersEditorTips.SetToolTip(this.CmdEdit, "Edit...");
      this.CmdEdit.UseVisualStyleBackColor = true;
      this.CmdEdit.Click += new System.EventHandler(this.CmdEdit_Click);
      // 
      // CmdDelete
      // 
      this.CmdDelete.Enabled = false;
      this.CmdDelete.Image = global::EllieWare.Common.Properties.Resources.delete_32x32;
      this.CmdDelete.Location = new System.Drawing.Point(3, 95);
      this.CmdDelete.Name = "CmdDelete";
      this.CmdDelete.Size = new System.Drawing.Size(40, 40);
      this.CmdDelete.TabIndex = 2;
      ParametersEditorTips.SetToolTip(this.CmdDelete, "Delete");
      this.CmdDelete.UseVisualStyleBackColor = true;
      this.CmdDelete.Click += new System.EventHandler(this.CmdDelete_Click);
      // 
      // tableLayoutPanel2
      // 
      tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      tableLayoutPanel2.ColumnCount = 4;
      tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel2.Controls.Add(tableLayoutPanel4, 2, 2);
      tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 1, 2);
      tableLayoutPanel2.Controls.Add(this.ParametersDisplay, 0, 0);
      tableLayoutPanel2.Controls.Add(tableLayoutPanel1, 3, 0);
      tableLayoutPanel2.Location = new System.Drawing.Point(12, 12);
      tableLayoutPanel2.Name = "tableLayoutPanel2";
      tableLayoutPanel2.RowCount = 3;
      tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel2.Size = new System.Drawing.Size(567, 329);
      tableLayoutPanel2.TabIndex = 9;
      // 
      // tableLayoutPanel4
      // 
      tableLayoutPanel4.AutoSize = true;
      tableLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      tableLayoutPanel4.ColumnCount = 1;
      tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel4.Controls.Add(this.CmdCancel, 0, 0);
      tableLayoutPanel4.Location = new System.Drawing.Point(431, 297);
      tableLayoutPanel4.Name = "tableLayoutPanel4";
      tableLayoutPanel4.RowCount = 1;
      tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel4.Size = new System.Drawing.Size(81, 29);
      tableLayoutPanel4.TabIndex = 10;
      // 
      // CmdCancel
      // 
      this.CmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.CmdCancel.Location = new System.Drawing.Point(3, 3);
      this.CmdCancel.Name = "CmdCancel";
      this.CmdCancel.Size = new System.Drawing.Size(75, 23);
      this.CmdCancel.TabIndex = 0;
      this.CmdCancel.Text = "Cancel";
      this.CmdCancel.UseVisualStyleBackColor = true;
      // 
      // tableLayoutPanel3
      // 
      tableLayoutPanel3.AutoSize = true;
      tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      tableLayoutPanel3.ColumnCount = 1;
      tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel3.Controls.Add(this.CmdOK, 0, 0);
      tableLayoutPanel3.Location = new System.Drawing.Point(344, 297);
      tableLayoutPanel3.Name = "tableLayoutPanel3";
      tableLayoutPanel3.RowCount = 1;
      tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      tableLayoutPanel3.Size = new System.Drawing.Size(81, 29);
      tableLayoutPanel3.TabIndex = 10;
      // 
      // CmdOK
      // 
      this.CmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.CmdOK.Enabled = false;
      this.CmdOK.Location = new System.Drawing.Point(3, 3);
      this.CmdOK.Name = "CmdOK";
      this.CmdOK.Size = new System.Drawing.Size(75, 23);
      this.CmdOK.TabIndex = 0;
      this.CmdOK.Text = "OK";
      this.CmdOK.UseVisualStyleBackColor = true;
      // 
      // ParametersDisplay
      // 
      tableLayoutPanel2.SetColumnSpan(this.ParametersDisplay, 3);
      this.ParametersDisplay.DisplayMember = "Summary";
      this.ParametersDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ParametersDisplay.FormattingEnabled = true;
      this.ParametersDisplay.Location = new System.Drawing.Point(3, 3);
      this.ParametersDisplay.Name = "ParametersDisplay";
      this.ParametersDisplay.Size = new System.Drawing.Size(509, 268);
      this.ParametersDisplay.Sorted = true;
      this.ParametersDisplay.TabIndex = 0;
      this.ParametersDisplay.SelectedIndexChanged += new System.EventHandler(this.Parameters_SelectedIndexChanged);
      this.ParametersDisplay.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ParametersDisplay_MouseDoubleClick);
      // 
      // ParametersEditor
      // 
      this.AcceptButton = this.CmdOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.CmdCancel;
      this.ClientSize = new System.Drawing.Size(591, 353);
      this.Controls.Add(tableLayoutPanel2);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "ParametersEditor";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Parameters Editor";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ParametersEditor_FormClosing);
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ParametersEditor_FormClosed);
      this.Load += new System.EventHandler(this.ParametersEditor_Load);
      tableLayoutPanel1.ResumeLayout(false);
      tableLayoutPanel2.ResumeLayout(false);
      tableLayoutPanel2.PerformLayout();
      tableLayoutPanel4.ResumeLayout(false);
      tableLayoutPanel3.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button CmdDelete;
    private System.Windows.Forms.Button CmdAdd;
    private System.Windows.Forms.Button CmdCancel;
    private System.Windows.Forms.Button CmdOK;
    private RefreshingListBox ParametersDisplay;
    private System.Windows.Forms.Button CmdEdit;
  }
}