namespace Reports
{
    partial class frmIPOSummaryOfTheApplications
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbsessionName = new System.Windows.Forms.ComboBox();
            this.btnShow = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Session Name";
            // 
            // cmbsessionName
            // 
            this.cmbsessionName.FormattingEnabled = true;
            this.cmbsessionName.Location = new System.Drawing.Point(91, 23);
            this.cmbsessionName.Name = "cmbsessionName";
            this.cmbsessionName.Size = new System.Drawing.Size(183, 21);
            this.cmbsessionName.TabIndex = 1;
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(13, 54);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(114, 23);
            this.btnShow.TabIndex = 2;
            this.btnShow.Text = "IPO Summary Report";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(197, 54);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmIPOSummaryOfTheApplications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 86);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.cmbsessionName);
            this.Controls.Add(this.label1);
            this.Name = "frmIPOSummaryOfTheApplications";
            this.Text = "frmIPOSummaryOfTheApplications";
            this.Load += new System.EventHandler(this.frmIPOSummaryOfTheApplications_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbsessionName;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Button btnClose;
    }
}