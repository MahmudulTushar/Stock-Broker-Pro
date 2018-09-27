namespace Reports
{
    partial class frmViewCustomerInfo
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
            this.crvCustomerInfo = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvCustomerInfo
            // 
            this.crvCustomerInfo.ActiveViewIndex = -1;
            this.crvCustomerInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvCustomerInfo.DisplayGroupTree = false;
            this.crvCustomerInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvCustomerInfo.Location = new System.Drawing.Point(0, 0);
            this.crvCustomerInfo.Name = "crvCustomerInfo";
            this.crvCustomerInfo.SelectionFormula = "";
            this.crvCustomerInfo.Size = new System.Drawing.Size(887, 553);
            this.crvCustomerInfo.TabIndex = 1;
            this.crvCustomerInfo.ViewTimeSelectionFormula = "";
            // 
            // frmViewCustomerInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 553);
            this.Controls.Add(this.crvCustomerInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmViewCustomerInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Account Holders Information Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crvCustomerInfo;
    }
}