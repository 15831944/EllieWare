﻿//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
namespace EllieWare.Batch
{
  partial class BatchRunnerCtrl
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      this.BatchMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.BatchFile = new System.Windows.Forms.ToolStripMenuItem();
      this.BatchDirectory = new System.Windows.Forms.ToolStripMenuItem();
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.mSpecs = new EllieWare.Support.RefreshingListBox();
      this.CmdAdd = new System.Windows.Forms.Button();
      this.CmdDelete = new System.Windows.Forms.Button();
      this.CmdDown = new System.Windows.Forms.Button();
      this.CmdEdit = new System.Windows.Forms.Button();
      this.CmdUp = new System.Windows.Forms.Button();
      this.CmdBatchParameter = new wyDay.Controls.SplitButton();
      this.BatchSummary = new System.Windows.Forms.TextBox();
      this.BatchMenuStrip.SuspendLayout();
      this.tableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // BatchMenuStrip
      // 
      this.BatchMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BatchFile,
            this.BatchDirectory});
      this.BatchMenuStrip.Name = "contextMenuStrip1";
      this.BatchMenuStrip.Size = new System.Drawing.Size(132, 48);
      // 
      // BatchFile
      // 
      this.BatchFile.Name = "BatchFile";
      this.BatchFile.Size = new System.Drawing.Size(131, 22);
      this.BatchFile.Text = "File...";
      this.BatchFile.Click += new System.EventHandler(this.BatchFile_Click);
      // 
      // BatchDirectory
      // 
      this.BatchDirectory.Name = "BatchDirectory";
      this.BatchDirectory.Size = new System.Drawing.Size(131, 22);
      this.BatchDirectory.Text = "Directory...";
      this.BatchDirectory.Click += new System.EventHandler(this.BatchDirectory_Click);
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.ColumnCount = 2;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.tableLayoutPanel1.Controls.Add(this.mSpecs, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.CmdAdd, 1, 0);
      this.tableLayoutPanel1.Controls.Add(this.CmdDelete, 1, 1);
      this.tableLayoutPanel1.Controls.Add(this.CmdDown, 1, 4);
      this.tableLayoutPanel1.Controls.Add(this.CmdEdit, 1, 2);
      this.tableLayoutPanel1.Controls.Add(this.CmdUp, 1, 3);
      this.tableLayoutPanel1.Controls.Add(this.CmdBatchParameter, 1, 6);
      this.tableLayoutPanel1.Controls.Add(this.BatchSummary, 0, 6);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 7;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(498, 447);
      this.tableLayoutPanel1.TabIndex = 7;
      // 
      // mSpecs
      // 
      this.mSpecs.DisplayMember = "Summary";
      this.mSpecs.Dock = System.Windows.Forms.DockStyle.Fill;
      this.mSpecs.FormattingEnabled = true;
      this.mSpecs.Location = new System.Drawing.Point(3, 3);
      this.mSpecs.Name = "mSpecs";
      this.tableLayoutPanel1.SetRowSpan(this.mSpecs, 6);
      this.mSpecs.Size = new System.Drawing.Size(411, 412);
      this.mSpecs.TabIndex = 0;
      this.mSpecs.SelectedIndexChanged += new System.EventHandler(this.Steps_SelectedIndexChanged);
      this.mSpecs.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Specs_MouseDoubleClick);
      // 
      // CmdAdd
      // 
      this.CmdAdd.Dock = System.Windows.Forms.DockStyle.Top;
      this.CmdAdd.Location = new System.Drawing.Point(420, 3);
      this.CmdAdd.Name = "CmdAdd";
      this.CmdAdd.Size = new System.Drawing.Size(75, 23);
      this.CmdAdd.TabIndex = 1;
      this.CmdAdd.Text = "Add...";
      this.CmdAdd.UseVisualStyleBackColor = true;
      this.CmdAdd.Click += new System.EventHandler(this.CmdAdd_Click);
      // 
      // CmdDelete
      // 
      this.CmdDelete.Dock = System.Windows.Forms.DockStyle.Top;
      this.CmdDelete.Enabled = false;
      this.CmdDelete.Location = new System.Drawing.Point(420, 32);
      this.CmdDelete.Name = "CmdDelete";
      this.CmdDelete.Size = new System.Drawing.Size(75, 23);
      this.CmdDelete.TabIndex = 2;
      this.CmdDelete.Text = "Delete";
      this.CmdDelete.UseVisualStyleBackColor = true;
      this.CmdDelete.Click += new System.EventHandler(this.CmdDelete_Click);
      // 
      // CmdDown
      // 
      this.CmdDown.Dock = System.Windows.Forms.DockStyle.Top;
      this.CmdDown.Location = new System.Drawing.Point(420, 119);
      this.CmdDown.Name = "CmdDown";
      this.CmdDown.Size = new System.Drawing.Size(75, 23);
      this.CmdDown.TabIndex = 5;
      this.CmdDown.Text = "Down";
      this.CmdDown.UseVisualStyleBackColor = true;
      this.CmdDown.Click += new System.EventHandler(this.CmdDown_Click);
      // 
      // CmdEdit
      // 
      this.CmdEdit.Dock = System.Windows.Forms.DockStyle.Top;
      this.CmdEdit.Enabled = false;
      this.CmdEdit.Location = new System.Drawing.Point(420, 61);
      this.CmdEdit.Name = "CmdEdit";
      this.CmdEdit.Size = new System.Drawing.Size(75, 23);
      this.CmdEdit.TabIndex = 3;
      this.CmdEdit.Text = "Edit...";
      this.CmdEdit.UseVisualStyleBackColor = true;
      this.CmdEdit.Click += new System.EventHandler(this.CmdEdit_Click);
      // 
      // CmdUp
      // 
      this.CmdUp.Dock = System.Windows.Forms.DockStyle.Top;
      this.CmdUp.Location = new System.Drawing.Point(420, 90);
      this.CmdUp.Name = "CmdUp";
      this.CmdUp.Size = new System.Drawing.Size(75, 23);
      this.CmdUp.TabIndex = 4;
      this.CmdUp.Text = "Up";
      this.CmdUp.UseVisualStyleBackColor = true;
      this.CmdUp.Click += new System.EventHandler(this.CmdUp_Click);
      // 
      // CmdBatchParameter
      // 
      this.CmdBatchParameter.ContextMenuStrip = this.BatchMenuStrip;
      this.CmdBatchParameter.Location = new System.Drawing.Point(420, 421);
      this.CmdBatchParameter.Name = "CmdBatchParameter";
      this.CmdBatchParameter.Size = new System.Drawing.Size(73, 23);
      this.CmdBatchParameter.SplitMenuStrip = this.BatchMenuStrip;
      this.CmdBatchParameter.TabIndex = 7;
      this.CmdBatchParameter.Text = "Batch";
      this.CmdBatchParameter.UseVisualStyleBackColor = true;
      this.CmdBatchParameter.Click += new System.EventHandler(this.BatchParameter_Click);
      // 
      // BatchSummary
      // 
      this.BatchSummary.Dock = System.Windows.Forms.DockStyle.Fill;
      this.BatchSummary.Location = new System.Drawing.Point(3, 421);
      this.BatchSummary.Name = "BatchSummary";
      this.BatchSummary.ReadOnly = true;
      this.BatchSummary.Size = new System.Drawing.Size(411, 20);
      this.BatchSummary.TabIndex = 8;
      // 
      // BatchRunnerCtrl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.tableLayoutPanel1);
      this.Name = "BatchRunnerCtrl";
      this.Size = new System.Drawing.Size(498, 447);
      this.BatchMenuStrip.ResumeLayout(false);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tableLayoutPanel1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button CmdAdd;
    private System.Windows.Forms.Button CmdDelete;
    private System.Windows.Forms.Button CmdEdit;
    private System.Windows.Forms.Button CmdUp;
    private System.Windows.Forms.Button CmdDown;
    private System.Windows.Forms.TextBox BatchSummary;
    public EllieWare.Support.RefreshingListBox mSpecs;
    private System.Windows.Forms.ContextMenuStrip BatchMenuStrip;
    private System.Windows.Forms.ToolStripMenuItem BatchFile;
    private System.Windows.Forms.ToolStripMenuItem BatchDirectory;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private wyDay.Controls.SplitButton CmdBatchParameter;
  }
}
