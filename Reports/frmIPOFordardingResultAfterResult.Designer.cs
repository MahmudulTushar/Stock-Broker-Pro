namespace Reports
{
    partial class frmIPOFordardingResultAfterResult
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
            this.cmbSessionName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAppliationNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnShowReport = new System.Windows.Forms.Button();
            this.BtnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(12, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Session Name";
            // 
            // cmbSessionName
            // 
            this.cmbSessionName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbSessionName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSessionName.FormattingEnabled = true;
            this.cmbSessionName.Location = new System.Drawing.Point(93, 70);
            this.cmbSessionName.Name = "cmbSessionName";
            this.cmbSessionName.Size = new System.Drawing.Size(179, 21);
            this.cmbSessionName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Application No";
            // 
            // txtAppliationNo
            // 
            this.txtAppliationNo.Location = new System.Drawing.Point(93, 109);
            this.txtAppliationNo.Name = "txtAppliationNo";
            this.txtAppliationNo.Size = new System.Drawing.Size(179, 20);
            this.txtAppliationNo.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.MediumBlue;
            this.label3.Location = new System.Drawing.Point(29, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(198, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Forwarding Letter After Result\r\n";
            // 
            // btnShowReport
            // 
            this.btnShowReport.Location = new System.Drawing.Point(93, 150);
            this.btnShowReport.Name = "btnShowReport";
            this.btnShowReport.Size = new System.Drawing.Size(90, 23);
            this.btnShowReport.TabIndex = 5;
            this.btnShowReport.Text = "Show Report";
            this.btnShowReport.UseVisualStyleBackColor = true;
            this.btnShowReport.Click += new System.EventHandler(this.btnShowReport_Click);
            // 
            // BtnClose
            // 
            this.BtnClose.Location = new System.Drawing.Point(190, 150);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(75, 23);
            this.BtnClose.TabIndex = 6;
            this.BtnClose.Text = "Close";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // frmIPOFordardingResultAfterResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(284, 192);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.btnShowReport);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAppliationNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbSessionName);
            this.Controls.Add(this.label1);
            this.Name = "frmIPOFordardingResultAfterResult";
            this.Text = "frmIPOFordardingResultAfterResult";
            this.Load += new System.EventHandler(this.frmIPOFordardingResultAfterResult_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbSessionName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAppliationNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnShowReport;
        private System.Windows.Forms.Button BtnClose;
    }
}