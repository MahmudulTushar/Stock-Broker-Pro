namespace DseReports
{
    partial class frmClient_Account_Status_Report_DSE_24_12
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtClientCode = new System.Windows.Forms.TextBox();
            this.b = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbBranchName = new System.Windows.Forms.ComboBox();
            this.Ro = new System.Windows.Forms.Label();
            this.txtRowNumber = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpTradeDate = new System.Windows.Forms.DateTimePicker();
            this.btnShow = new System.Windows.Forms.Button();
            this.btnclose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.b.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtRowNumber);
            this.groupBox1.Controls.Add(this.Ro);
            this.groupBox1.Controls.Add(this.txtClientCode);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(11, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 83);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Client Code Info";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Client Code";
            // 
            // txtClientCode
            // 
            this.txtClientCode.Location = new System.Drawing.Point(84, 19);
            this.txtClientCode.Name = "txtClientCode";
            this.txtClientCode.Size = new System.Drawing.Size(110, 20);
            this.txtClientCode.TabIndex = 1;
            // 
            // b
            // 
            this.b.Controls.Add(this.cmbBranchName);
            this.b.Controls.Add(this.label2);
            this.b.Location = new System.Drawing.Point(11, 88);
            this.b.Name = "b";
            this.b.Size = new System.Drawing.Size(200, 48);
            this.b.TabIndex = 1;
            this.b.TabStop = false;
            this.b.Text = "Branch Info";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Branch Name";
            // 
            // cmbBranchName
            // 
            this.cmbBranchName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBranchName.FormattingEnabled = true;
            this.cmbBranchName.Location = new System.Drawing.Point(84, 16);
            this.cmbBranchName.Name = "cmbBranchName";
            this.cmbBranchName.Size = new System.Drawing.Size(110, 21);
            this.cmbBranchName.TabIndex = 1;
            // 
            // Ro
            // 
            this.Ro.AutoSize = true;
            this.Ro.Location = new System.Drawing.Point(8, 53);
            this.Ro.Name = "Ro";
            this.Ro.Size = new System.Drawing.Size(69, 13);
            this.Ro.TabIndex = 2;
            this.Ro.Text = "Row Number";
            // 
            // txtRowNumber
            // 
            this.txtRowNumber.Location = new System.Drawing.Point(83, 53);
            this.txtRowNumber.Name = "txtRowNumber";
            this.txtRowNumber.Size = new System.Drawing.Size(111, 20);
            this.txtRowNumber.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtpTradeDate);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(11, 142);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 44);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Date Info";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Trade Date";
            // 
            // dtpTradeDate
            // 
            this.dtpTradeDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTradeDate.Location = new System.Drawing.Point(73, 16);
            this.dtpTradeDate.Name = "dtpTradeDate";
            this.dtpTradeDate.Size = new System.Drawing.Size(105, 20);
            this.dtpTradeDate.TabIndex = 1;
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(11, 192);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(77, 23);
            this.btnShow.TabIndex = 3;
            this.btnShow.Text = "Show Report";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // btnclose
            // 
            this.btnclose.Location = new System.Drawing.Point(136, 192);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(75, 23);
            this.btnclose.TabIndex = 4;
            this.btnclose.Text = "Close";
            this.btnclose.UseVisualStyleBackColor = true;
            // 
            // frmClient_Account_Status_Report_DSE_24_12
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(220, 221);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.b);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmClient_Account_Status_Report_DSE_24_12";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmClient_Account_Status_Report_DSE_24_12";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.b.ResumeLayout(false);
            this.b.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtClientCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox b;
        private System.Windows.Forms.TextBox txtRowNumber;
        private System.Windows.Forms.Label Ro;
        private System.Windows.Forms.ComboBox cmbBranchName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dtpTradeDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Button btnclose;
    }
}