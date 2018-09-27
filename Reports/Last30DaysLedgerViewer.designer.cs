namespace Reports
{
    partial class Last30DaysLedgerViewer
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
            this.crvLast30DaysLedgerReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvLast30DaysLedgerReportViewer
            // 
            this.crvLast30DaysLedgerReportViewer.ActiveViewIndex = -1;
            this.crvLast30DaysLedgerReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvLast30DaysLedgerReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvLast30DaysLedgerReportViewer.Location = new System.Drawing.Point(0, 0);
            this.crvLast30DaysLedgerReportViewer.Name = "crvLast30DaysLedgerReportViewer";
            this.crvLast30DaysLedgerReportViewer.SelectionFormula = "";
            this.crvLast30DaysLedgerReportViewer.Size = new System.Drawing.Size(929, 535);
            this.crvLast30DaysLedgerReportViewer.TabIndex = 0;
            this.crvLast30DaysLedgerReportViewer.ViewTimeSelectionFormula = "";
            // 
            // Last30DaysLedgerViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 535);
            this.Controls.Add(this.crvLast30DaysLedgerReportViewer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Last30DaysLedgerViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Last 30 Days Share Ledger Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crvLast30DaysLedgerReportViewer;

    }
}