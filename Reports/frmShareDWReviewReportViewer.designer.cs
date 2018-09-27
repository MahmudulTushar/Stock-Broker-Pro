namespace Reports
{
    partial class frmShareDWReviewReportViewer
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
            this.crvShareReview = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvShareReview
            // 
            this.crvShareReview.ActiveViewIndex = -1;
            this.crvShareReview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvShareReview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvShareReview.Location = new System.Drawing.Point(0, 0);
            this.crvShareReview.Name = "crvShareReview";
            this.crvShareReview.SelectionFormula = "";
            this.crvShareReview.Size = new System.Drawing.Size(919, 482);
            this.crvShareReview.TabIndex = 0;
            this.crvShareReview.ViewTimeSelectionFormula = "";
            // 
            // frmShareDWReviewReportViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 482);
            this.Controls.Add(this.crvShareReview);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmShareDWReviewReportViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Share D\\W Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crvShareReview;
    }
}