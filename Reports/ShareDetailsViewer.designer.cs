namespace Reports
{
    partial class ShareDetailsViewer
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
            this.crvShareDetailsReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvShareDetailsReportViewer
            // 
            this.crvShareDetailsReportViewer.ActiveViewIndex = -1;
            this.crvShareDetailsReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvShareDetailsReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvShareDetailsReportViewer.Location = new System.Drawing.Point(0, 0);
            this.crvShareDetailsReportViewer.Name = "crvShareDetailsReportViewer";
            this.crvShareDetailsReportViewer.SelectionFormula = "";
            this.crvShareDetailsReportViewer.Size = new System.Drawing.Size(944, 541);
            this.crvShareDetailsReportViewer.TabIndex = 0;
            this.crvShareDetailsReportViewer.ViewTimeSelectionFormula = "";
            // 
            // ShareDetailsViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 541);
            this.Controls.Add(this.crvShareDetailsReportViewer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "ShareDetailsViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Share Details Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crvShareDetailsReportViewer;

    }
}