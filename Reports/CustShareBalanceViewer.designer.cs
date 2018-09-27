namespace Reports
{
    partial class CustShareBalanceViewer
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
            this.crvCustShareBalanceReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvCustShareBalanceReportViewer
            // 
            this.crvCustShareBalanceReportViewer.ActiveViewIndex = -1;
            this.crvCustShareBalanceReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvCustShareBalanceReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvCustShareBalanceReportViewer.Location = new System.Drawing.Point(0, 0);
            this.crvCustShareBalanceReportViewer.Name = "crvCustShareBalanceReportViewer";
            this.crvCustShareBalanceReportViewer.SelectionFormula = "";
            this.crvCustShareBalanceReportViewer.Size = new System.Drawing.Size(883, 500);
            this.crvCustShareBalanceReportViewer.TabIndex = 0;
            this.crvCustShareBalanceReportViewer.ViewTimeSelectionFormula = "";
            // 
            // CustShareBalanceViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 500);
            this.Controls.Add(this.crvCustShareBalanceReportViewer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "CustShareBalanceViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Share Balance Viewer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crvCustShareBalanceReportViewer;

    }
}