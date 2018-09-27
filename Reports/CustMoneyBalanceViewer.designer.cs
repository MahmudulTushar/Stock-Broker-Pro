namespace Reports
{
    partial class CustMoneyBalanceViewer
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
            this.crvCustMoneyBalanceReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvCustMoneyBalanceReportViewer
            // 
            this.crvCustMoneyBalanceReportViewer.ActiveViewIndex = -1;
            this.crvCustMoneyBalanceReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvCustMoneyBalanceReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvCustMoneyBalanceReportViewer.Location = new System.Drawing.Point(0, 0);
            this.crvCustMoneyBalanceReportViewer.Name = "crvCustMoneyBalanceReportViewer";
            this.crvCustMoneyBalanceReportViewer.SelectionFormula = "";
            this.crvCustMoneyBalanceReportViewer.Size = new System.Drawing.Size(903, 516);
            this.crvCustMoneyBalanceReportViewer.TabIndex = 0;
            this.crvCustMoneyBalanceReportViewer.ViewTimeSelectionFormula = "";
            // 
            // CustMoneyBalanceViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 516);
            this.Controls.Add(this.crvCustMoneyBalanceReportViewer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "CustMoneyBalanceViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Money Balance Viewer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crvCustMoneyBalanceReportViewer;

    }
}