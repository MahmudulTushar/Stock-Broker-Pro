namespace Reports
{
    partial class ClientConfirmationOfficeCopyViewer
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
            this.crvClientConfirmationOfficeCopyViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvClientConfirmationOfficeCopyViewer
            // 
            this.crvClientConfirmationOfficeCopyViewer.ActiveViewIndex = -1;
            this.crvClientConfirmationOfficeCopyViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvClientConfirmationOfficeCopyViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvClientConfirmationOfficeCopyViewer.Location = new System.Drawing.Point(0, 0);
            this.crvClientConfirmationOfficeCopyViewer.Name = "crvClientConfirmationOfficeCopyViewer";
            this.crvClientConfirmationOfficeCopyViewer.SelectionFormula = "";
            this.crvClientConfirmationOfficeCopyViewer.Size = new System.Drawing.Size(768, 533);
            this.crvClientConfirmationOfficeCopyViewer.TabIndex = 0;
            this.crvClientConfirmationOfficeCopyViewer.ViewTimeSelectionFormula = "";
            // 
            // ClientConfirmationOfficeCopyViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 533);
            this.Controls.Add(this.crvClientConfirmationOfficeCopyViewer);
            this.Name = "ClientConfirmationOfficeCopyViewer";
            this.Text = "Client Confirmation Office Copy";
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crvClientConfirmationOfficeCopyViewer;

    }
}