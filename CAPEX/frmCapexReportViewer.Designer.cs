namespace CAPEX
{
    partial class frmCapexReportViewer
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
            this.crvReportView = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvReportView
            // 
            this.crvReportView.ActiveViewIndex = -1;
            this.crvReportView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvReportView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvReportView.Location = new System.Drawing.Point(0, 0);
            this.crvReportView.Name = "crvReportView";
            this.crvReportView.SelectionFormula = "";
            this.crvReportView.Size = new System.Drawing.Size(535, 416);
            this.crvReportView.TabIndex = 0;
            this.crvReportView.ViewTimeSelectionFormula = "";
            // 
            // frmReportViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 416);
            this.Controls.Add(this.crvReportView);
            this.Name = "frmReportViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmReportViewer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crvReportView;

    }
}