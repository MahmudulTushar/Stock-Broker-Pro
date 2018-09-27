namespace Reports
{
    partial class CustShareSummeryViewer
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
            this.crvShareSummeryReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvShareSummeryReportViewer
            // 
            this.crvShareSummeryReportViewer.ActiveViewIndex = -1;
            this.crvShareSummeryReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvShareSummeryReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvShareSummeryReportViewer.Location = new System.Drawing.Point(0, 0);
            this.crvShareSummeryReportViewer.Name = "crvShareSummeryReportViewer";
            this.crvShareSummeryReportViewer.SelectionFormula = "";
            this.crvShareSummeryReportViewer.Size = new System.Drawing.Size(930, 525);
            this.crvShareSummeryReportViewer.TabIndex = 0;
            this.crvShareSummeryReportViewer.ViewTimeSelectionFormula = "";
            // 
            // CustShareSummeryViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 525);
            this.Controls.Add(this.crvShareSummeryReportViewer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "CustShareSummeryViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Share Summery Viewer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crvShareSummeryReportViewer;

    }
}