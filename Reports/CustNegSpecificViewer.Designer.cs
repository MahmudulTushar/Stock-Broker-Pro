namespace Reports
{
    partial class CustNegSpecificViewer
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
            this.crvCustNegSpecificReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvCustNegSpecificReportViewer
            // 
            this.crvCustNegSpecificReportViewer.ActiveViewIndex = -1;
            this.crvCustNegSpecificReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvCustNegSpecificReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvCustNegSpecificReportViewer.Location = new System.Drawing.Point(0, 0);
            this.crvCustNegSpecificReportViewer.Name = "crvCustNegSpecificReportViewer";
            this.crvCustNegSpecificReportViewer.SelectionFormula = "";
            this.crvCustNegSpecificReportViewer.Size = new System.Drawing.Size(951, 525);
            this.crvCustNegSpecificReportViewer.TabIndex = 0;
            this.crvCustNegSpecificReportViewer.ViewTimeSelectionFormula = "";
            // 
            // CustNegSpecificViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 525);
            this.Controls.Add(this.crvCustNegSpecificReportViewer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "CustNegSpecificViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer with Negetive Balance";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crvCustNegSpecificReportViewer;

    }
}