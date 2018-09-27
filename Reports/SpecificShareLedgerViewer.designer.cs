namespace Reports
{
    partial class SpecificShareLedgerViewer
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
            this.crvSpecificShareLedgerReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvSpecificShareLedgerReportViewer
            // 
            this.crvSpecificShareLedgerReportViewer.ActiveViewIndex = -1;
            this.crvSpecificShareLedgerReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvSpecificShareLedgerReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvSpecificShareLedgerReportViewer.Location = new System.Drawing.Point(0, 0);
            this.crvSpecificShareLedgerReportViewer.Name = "crvSpecificShareLedgerReportViewer";
            this.crvSpecificShareLedgerReportViewer.SelectionFormula = "";
            this.crvSpecificShareLedgerReportViewer.Size = new System.Drawing.Size(950, 560);
            this.crvSpecificShareLedgerReportViewer.TabIndex = 0;
            this.crvSpecificShareLedgerReportViewer.ViewTimeSelectionFormula = "";
            // 
            // SpecificShareLedgerViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 560);
            this.Controls.Add(this.crvSpecificShareLedgerReportViewer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "SpecificShareLedgerViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Share Ledger of Specific Period Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crvSpecificShareLedgerReportViewer;

    }
}