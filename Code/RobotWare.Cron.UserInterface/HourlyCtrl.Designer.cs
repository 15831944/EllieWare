﻿//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
namespace RobotWare.Cron.UserInterface
{
  partial class HourlyCtrl
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
      System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      System.Windows.Forms.Label label1;
      this.OptHours = new System.Windows.Forms.RadioButton();
      this.OptTime = new System.Windows.Forms.RadioButton();
      this.HourlyValue = new System.Windows.Forms.NumericUpDown();
      this.HourlyTimeValue = new System.Windows.Forms.DateTimePicker();
      tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      label1 = new System.Windows.Forms.Label();
      tableLayoutPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.HourlyValue)).BeginInit();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      tableLayoutPanel1.ColumnCount = 3;
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel1.Controls.Add(this.OptHours, 0, 0);
      tableLayoutPanel1.Controls.Add(this.OptTime, 0, 1);
      tableLayoutPanel1.Controls.Add(this.HourlyValue, 1, 0);
      tableLayoutPanel1.Controls.Add(label1, 2, 0);
      tableLayoutPanel1.Controls.Add(this.HourlyTimeValue, 1, 1);
      tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 2;
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.Size = new System.Drawing.Size(347, 217);
      tableLayoutPanel1.TabIndex = 0;
      // 
      // OptHours
      // 
      this.OptHours.AutoSize = true;
      this.OptHours.Checked = true;
      this.OptHours.Location = new System.Drawing.Point(3, 3);
      this.OptHours.Name = "OptHours";
      this.OptHours.Size = new System.Drawing.Size(52, 17);
      this.OptHours.TabIndex = 0;
      this.OptHours.TabStop = true;
      this.OptHours.Text = "Every";
      this.OptHours.UseVisualStyleBackColor = true;
      this.OptHours.CheckedChanged += new System.EventHandler(this.FireExpressionChangedInternal);
      // 
      // OptTime
      // 
      this.OptTime.AutoSize = true;
      this.OptTime.Location = new System.Drawing.Point(3, 29);
      this.OptTime.Name = "OptTime";
      this.OptTime.Size = new System.Drawing.Size(35, 17);
      this.OptTime.TabIndex = 3;
      this.OptTime.TabStop = true;
      this.OptTime.Text = "At";
      this.OptTime.UseVisualStyleBackColor = true;
      this.OptTime.CheckedChanged += new System.EventHandler(this.FireExpressionChangedInternal);
      // 
      // HourlyValue
      // 
      this.HourlyValue.Dock = System.Windows.Forms.DockStyle.Top;
      this.HourlyValue.Location = new System.Drawing.Point(61, 3);
      this.HourlyValue.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
      this.HourlyValue.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.HourlyValue.Name = "HourlyValue";
      this.HourlyValue.Size = new System.Drawing.Size(238, 20);
      this.HourlyValue.TabIndex = 1;
      this.HourlyValue.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.HourlyValue.ValueChanged += new System.EventHandler(this.FireExpressionChangedInternal);
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Location = new System.Drawing.Point(305, 3);
      label1.Margin = new System.Windows.Forms.Padding(3);
      label1.Name = "label1";
      label1.Size = new System.Drawing.Size(39, 13);
      label1.TabIndex = 2;
      label1.Text = "hour(s)";
      // 
      // HourlyTimeValue
      // 
      this.HourlyTimeValue.CustomFormat = "HH:mm";
      this.HourlyTimeValue.Dock = System.Windows.Forms.DockStyle.Top;
      this.HourlyTimeValue.Enabled = false;
      this.HourlyTimeValue.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
      this.HourlyTimeValue.Location = new System.Drawing.Point(61, 29);
      this.HourlyTimeValue.Name = "HourlyTimeValue";
      this.HourlyTimeValue.ShowUpDown = true;
      this.HourlyTimeValue.Size = new System.Drawing.Size(238, 20);
      this.HourlyTimeValue.TabIndex = 4;
      this.HourlyTimeValue.ValueChanged += new System.EventHandler(this.FireExpressionChangedInternal);
      // 
      // HourlyCtrl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(tableLayoutPanel1);
      this.Name = "HourlyCtrl";
      this.Size = new System.Drawing.Size(347, 217);
      tableLayoutPanel1.ResumeLayout(false);
      tableLayoutPanel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.HourlyValue)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.RadioButton OptHours;
    private System.Windows.Forms.RadioButton OptTime;
    private System.Windows.Forms.NumericUpDown HourlyValue;
    private System.Windows.Forms.DateTimePicker HourlyTimeValue;
  }
}
