namespace Reports
{
    partial class TodayCustBalanceViewer
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
            this.crvTodayCustBalanceReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvTodayCustBalanceReportViewer
            // 
            this.crvTodayCustBalanceReportViewer.ActiveViewIndex = -1;
            this.crvTodayCustBalanceReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvTodayCustBalanceReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvTodayCustBalanceReportViewer.Location = new System.Drawing.Point(0, 0);
            this.crvTodayCustBalanceReportViewer.Name = "crvTodayCustBalanceReportViewer";
            this.crvTodayCustBalanceReportViewer.SelectionFormula = "";
            this.crvTodayCustBalanceReportViewer.Size = new System.Drawing.Size(952, 528);
            this.crvTodayCustBalanceReportViewer.TabIndex = 0;
            this.crvTodayCustBalanceReportViewer.ViewTimeSelectionFormula = "";
            // 
            // TodayCustBalanceViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 528);
            this.Controls.Add(this.crvTodayCustBalanceReportViewer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "TodayCustBalanceViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Today\'s Balance Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crvTodayCustBalanceReportViewer;

    }
}