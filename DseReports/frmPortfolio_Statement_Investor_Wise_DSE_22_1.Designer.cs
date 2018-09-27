namespace DseReports
{
    partial class frmPortfolio_Statement_Investor_Wise_DSE_22_1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbInvestorId = new System.Windows.Forms.ComboBox();
            this.Btnshow = new System.Windows.Forms.Button();
            this.btnclose = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbExchangeName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dtpReportDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Client Code";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbInvestorId);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 47);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Client Code Info";
            // 
            // cmbInvestorId
            // 
            this.cmbInvestorId.FormattingEnabled = true;
            this.cmbInvestorId.Location = new System.Drawing.Point(88, 19);
            this.cmbInvestorId.Name = "cmbInvestorId";
            this.cmbInvestorId.Size = new System.Drawing.Size(93, 21);
            this.cmbInvestorId.TabIndex = 1;
            // 
            // Btnshow
            // 
            this.Btnshow.Location = new System.Drawing.Point(8, 168);
            this.Btnshow.Name = "Btnshow";
            this.Btnshow.Size = new System.Drawing.Size(82, 23);
            this.Btnshow.TabIndex = 2;
            this.Btnshow.Text = "Show Report";
            this.Btnshow.UseVisualStyleBackColor = true;
            this.Btnshow.Click += new System.EventHandler(this.Btnshow_Click);
            // 
            // btnclose
            // 
            this.btnclose.Location = new System.Drawing.Point(128, 168);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(75, 23);
            this.btnclose.TabIndex = 3;
            this.btnclose.Text = "Close";
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbExchangeName);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(3, 65);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 45);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Exchange Info";
            // 
            // cmbExchangeName
            // 
            this.cmbExchangeName.FormattingEnabled = true;
            this.cmbExchangeName.Items.AddRange(new object[] {
            "All",
            "DSE",
            "CSE"});
            this.cmbExchangeName.Location = new System.Drawing.Point(88, 16);
            this.cmbExchangeName.Name = "cmbExchangeName";
            this.cmbExchangeName.Size = new System.Drawing.Size(93, 21);
            this.cmbExchangeName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Exchange Name";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dtpReportDate);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(3, 116);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 44);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Date Info";
            // 
            // dtpReportDate
            // 
            this.dtpReportDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpReportDate.Location = new System.Drawing.Point(88, 18);
            this.dtpReportDate.Name = "dtpReportDate";
            this.dtpReportDate.Size = new System.Drawing.Size(93, 20);
            this.dtpReportDate.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Report Date";
            // 
            // frmPortfolio_Statement_Investor_Wise_DSE_22_1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(205, 196);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.Btnshow);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmPortfolio_Statement_Investor_Wise_DSE_22_1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPortfolio_Statement_Investor_Wise_DSE_22_1";
            this.Load += new System.EventHandler(this.frmPortfolio_Statement_Investor_Wise_DSE_22_1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Btnshow;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.ComboBox cmbInvestorId;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbExchangeName;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DateTimePicker dtpReportDate;
        private System.Windows.Forms.Label label3;
    }
}