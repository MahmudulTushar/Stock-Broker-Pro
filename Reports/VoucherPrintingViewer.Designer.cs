namespace Reports
{
    partial class ClientVoucherPrintingViewer
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
            this.crvClientVoucherViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvClientVoucherViewer
            // 
            this.crvClientVoucherViewer.ActiveViewIndex = -1;
            this.crvClientVoucherViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvClientVoucherViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvClientVoucherViewer.Location = new System.Drawing.Point(0, 0);
            this.crvClientVoucherViewer.Name = "crvClientVoucherViewer";
            this.crvClientVoucherViewer.SelectionFormula = "";
            this.crvClientVoucherViewer.Size = new System.Drawing.Size(934, 528);
            this.crvClientVoucherViewer.TabIndex = 0;
            this.crvClientVoucherViewer.ViewTimeSelectionFormula = "";
            // 
            // ClientVoucherPrintingViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 528);
            this.Controls.Add(this.crvClientVoucherViewer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "ClientVoucherPrintingViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Client Voucher Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crvClientVoucherViewer;

    }
}