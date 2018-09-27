namespace StockbrokerProNewArch
{
    partial class FrmIPOTotalApplicationList
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
            this.cmbsessionIdByName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnshowreport = new System.Windows.Forms.Button();
            this.btnclose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbsessionIdByName
            // 
            this.cmbsessionIdByName.FormattingEnabled = true;
            this.cmbsessionIdByName.Location = new System.Drawing.Point(12, 38);
            this.cmbsessionIdByName.Name = "cmbsessionIdByName";
            this.cmbsessionIdByName.Size = new System.Drawing.Size(180, 21);
            this.cmbsessionIdByName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Total Application List of IPO";
            // 
            // btnshowreport
            // 
            this.btnshowreport.Location = new System.Drawing.Point(12, 65);
            this.btnshowreport.Name = "btnshowreport";
            this.btnshowreport.Size = new System.Drawing.Size(83, 23);
            this.btnshowreport.TabIndex = 2;
            this.btnshowreport.Text = "Show Report\r\n";
            this.btnshowreport.UseVisualStyleBackColor = true;
            this.btnshowreport.Click += new System.EventHandler(this.btnshowreport_Click);
            // 
            // btnclose
            // 
            this.btnclose.Location = new System.Drawing.Point(117, 65);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(75, 23);
            this.btnclose.TabIndex = 3;
            this.btnclose.Text = "Close\r\n";
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // FrmIPOTotalApplicationList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 96);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.btnshowreport);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbsessionIdByName);
            this.Name = "FrmIPOTotalApplicationList";
            this.Text = "FrmIPOTotalApplicationList";
            this.Load += new System.EventHandler(this.FrmIPOTotalApplicationList_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbsessionIdByName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnshowreport;
        private System.Windows.Forms.Button btnclose;
    }
}