namespace Reports
{
    partial class CustPositiveBalViewer
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
            this.crvCustPositiveBalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvCustPositiveBalReportViewer
            // 
            this.crvCustPositiveBalReportViewer.ActiveViewIndex = -1;
            this.crvCustPositiveBalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvCustPositiveBalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvCustPositiveBalReportViewer.Location = new System.Drawing.Point(0, 0);
            this.crvCustPositiveBalReportViewer.Name = "crvCustPositiveBalReportViewer";
            this.crvCustPositiveBalReportViewer.SelectionFormula = "";
            this.crvCustPositiveBalReportViewer.Size = new System.Drawing.Size(884, 538);
            this.crvCustPositiveBalReportViewer.TabIndex = 0;
            this.crvCustPositiveBalReportViewer.ViewTimeSelectionFormula = "";
            // 
            // CustPositiveBalViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 538);
            this.Controls.Add(this.crvCustPositiveBalReportViewer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "CustPositiveBalViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer with Positive Balance";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crvCustPositiveBalReportViewer;

    }
}