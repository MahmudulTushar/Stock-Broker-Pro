namespace Reports
{
    partial class SpotTradeSummeryReportViewer
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
            this.crvSpotTradeSummery = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvSpotTradeSummery
            // 
            this.crvSpotTradeSummery.ActiveViewIndex = -1;
            this.crvSpotTradeSummery.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvSpotTradeSummery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvSpotTradeSummery.Location = new System.Drawing.Point(0, 0);
            this.crvSpotTradeSummery.Name = "crvSpotTradeSummery";
            this.crvSpotTradeSummery.SelectionFormula = "";
            this.crvSpotTradeSummery.Size = new System.Drawing.Size(979, 517);
            this.crvSpotTradeSummery.TabIndex = 0;
            this.crvSpotTradeSummery.ViewTimeSelectionFormula = "";
            // 
            // SpotTradeSummeryReportViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 517);
            this.Controls.Add(this.crvSpotTradeSummery);
            this.Name = "SpotTradeSummeryReportViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Spot Trade Summery Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crvSpotTradeSummery;

    }
}