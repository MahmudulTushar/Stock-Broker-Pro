namespace StockbrokerProNewArch
{
    partial class frmCustomerAccInfo
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
            this.crvPdfReport = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvPdfReport
            // 
            this.crvPdfReport.ActiveViewIndex = -1;
            this.crvPdfReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvPdfReport.DisplayGroupTree = false;
            this.crvPdfReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvPdfReport.Location = new System.Drawing.Point(0, 0);
            this.crvPdfReport.Name = "crvPdfReport";
            this.crvPdfReport.SelectionFormula = "";
            this.crvPdfReport.Size = new System.Drawing.Size(953, 583);
            this.crvPdfReport.TabIndex = 2;
            this.crvPdfReport.ViewTimeSelectionFormula = "";
            // 
            // frmCustomerAccInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 583);
            this.Controls.Add(this.crvPdfReport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmCustomerAccInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCustomerAccInfo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crvPdfReport;



    }
}

