﻿namespace Reports
{
    partial class ShareListViewer
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
            this.CrvShareList = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // CrvShareList
            // 
            this.CrvShareList.ActiveViewIndex = -1;
            this.CrvShareList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CrvShareList.DisplayGroupTree = false;
            this.CrvShareList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CrvShareList.Location = new System.Drawing.Point(0, 0);
            this.CrvShareList.Name = "CrvShareList";
            this.CrvShareList.SelectionFormula = "";
            this.CrvShareList.Size = new System.Drawing.Size(921, 541);
            this.CrvShareList.TabIndex = 1;
            this.CrvShareList.ViewTimeSelectionFormula = "";
            // 
            // ShareListViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 541);
            this.Controls.Add(this.CrvShareList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "ShareListViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Share List Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ReportForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer CrvShareList;
    }
}