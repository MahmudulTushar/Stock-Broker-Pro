namespace StockbrokerProNewArch
{
    partial class CustWiseShareReconcileViewer
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
            this.crvCustShareReconcile = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvCustShareReconcile
            // 
            this.crvCustShareReconcile.ActiveViewIndex = -1;
            this.crvCustShareReconcile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvCustShareReconcile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvCustShareReconcile.Location = new System.Drawing.Point(0, 0);
            this.crvCustShareReconcile.Name = "crvCustShareReconcile";
            this.crvCustShareReconcile.SelectionFormula = "";
            this.crvCustShareReconcile.Size = new System.Drawing.Size(921, 536);
            this.crvCustShareReconcile.TabIndex = 0;
            this.crvCustShareReconcile.ViewTimeSelectionFormula = "";
            // 
            // CustWiseShareReconcileViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 536);
            this.Controls.Add(this.crvCustShareReconcile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "CustWiseShareReconcileViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customerwise CDBL Mismatch Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crvCustShareReconcile;

    }
}