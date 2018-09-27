namespace Reports
{
    partial class InstruWiseBuyReportViewer
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
            this.crvInstruWiseBuyList = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvInstruWiseBuyList
            // 
            this.crvInstruWiseBuyList.ActiveViewIndex = -1;
            this.crvInstruWiseBuyList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvInstruWiseBuyList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvInstruWiseBuyList.Location = new System.Drawing.Point(0, 0);
            this.crvInstruWiseBuyList.Name = "crvInstruWiseBuyList";
            this.crvInstruWiseBuyList.SelectionFormula = "";
            this.crvInstruWiseBuyList.Size = new System.Drawing.Size(947, 522);
            this.crvInstruWiseBuyList.TabIndex = 0;
            this.crvInstruWiseBuyList.ViewTimeSelectionFormula = "";
            // 
            // InstruWiseBuyReportViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 522);
            this.Controls.Add(this.crvInstruWiseBuyList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "InstruWiseBuyReportViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Instrumentwise Buy Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crvInstruWiseBuyList;

    }
}