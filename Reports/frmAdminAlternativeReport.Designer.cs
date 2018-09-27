namespace Reports
{
    partial class frmAdminAlternativeReport
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
            this.btn_TodayCustBalance = new System.Windows.Forms.Button();
            this.btn_TodayCustMoneyBalance = new System.Windows.Forms.Button();
            this.btn_TodayCustShareBalance = new System.Windows.Forms.Button();
            this.btn_PaymentReveiw = new System.Windows.Forms.Button();
            this.chk_AccountView = new System.Windows.Forms.CheckBox();
            this.dtp_PaymentReview_FromDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_Reason = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtp_PaymentReveiw_ToDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.chk_SortedByCustCode = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtp_TodayBalanceDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_TodayCustBalance
            // 
            this.btn_TodayCustBalance.Location = new System.Drawing.Point(21, 44);
            this.btn_TodayCustBalance.Name = "btn_TodayCustBalance";
            this.btn_TodayCustBalance.Size = new System.Drawing.Size(158, 23);
            this.btn_TodayCustBalance.TabIndex = 0;
            this.btn_TodayCustBalance.Text = "Todays Cust Total Balance";
            this.btn_TodayCustBalance.UseVisualStyleBackColor = true;
            this.btn_TodayCustBalance.Click += new System.EventHandler(this.btn_TodayCustBalance_Click);
            // 
            // btn_TodayCustMoneyBalance
            // 
            this.btn_TodayCustMoneyBalance.Location = new System.Drawing.Point(21, 74);
            this.btn_TodayCustMoneyBalance.Name = "btn_TodayCustMoneyBalance";
            this.btn_TodayCustMoneyBalance.Size = new System.Drawing.Size(158, 23);
            this.btn_TodayCustMoneyBalance.TabIndex = 1;
            this.btn_TodayCustMoneyBalance.Text = "Todays Cust Money Balance";
            this.btn_TodayCustMoneyBalance.UseVisualStyleBackColor = true;
            this.btn_TodayCustMoneyBalance.Click += new System.EventHandler(this.btn_TodayCustMoneyBalance_Click);
            // 
            // btn_TodayCustShareBalance
            // 
            this.btn_TodayCustShareBalance.Location = new System.Drawing.Point(21, 104);
            this.btn_TodayCustShareBalance.Name = "btn_TodayCustShareBalance";
            this.btn_TodayCustShareBalance.Size = new System.Drawing.Size(158, 23);
            this.btn_TodayCustShareBalance.TabIndex = 2;
            this.btn_TodayCustShareBalance.Text = "Todays Cust Share Balance";
            this.btn_TodayCustShareBalance.UseVisualStyleBackColor = true;
            this.btn_TodayCustShareBalance.Click += new System.EventHandler(this.btn_TodayCustShareBalance_Click);
            // 
            // btn_PaymentReveiw
            // 
            this.btn_PaymentReveiw.Location = new System.Drawing.Point(21, 113);
            this.btn_PaymentReveiw.Name = "btn_PaymentReveiw";
            this.btn_PaymentReveiw.Size = new System.Drawing.Size(158, 23);
            this.btn_PaymentReveiw.TabIndex = 3;
            this.btn_PaymentReveiw.Text = "Payment Review Sorted";
            this.btn_PaymentReveiw.UseVisualStyleBackColor = true;
            this.btn_PaymentReveiw.Click += new System.EventHandler(this.btn_PaymentReveiw_Click);
            // 
            // chk_AccountView
            // 
            this.chk_AccountView.AutoSize = true;
            this.chk_AccountView.Location = new System.Drawing.Point(21, 75);
            this.chk_AccountView.Name = "chk_AccountView";
            this.chk_AccountView.Size = new System.Drawing.Size(112, 17);
            this.chk_AccountView.TabIndex = 4;
            this.chk_AccountView.Text = "As Accounts View";
            this.chk_AccountView.UseVisualStyleBackColor = true;
            // 
            // dtp_PaymentReview_FromDate
            // 
            this.dtp_PaymentReview_FromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_PaymentReview_FromDate.Location = new System.Drawing.Point(74, 18);
            this.dtp_PaymentReview_FromDate.Name = "dtp_PaymentReview_FromDate";
            this.dtp_PaymentReview_FromDate.Size = new System.Drawing.Size(89, 20);
            this.dtp_PaymentReview_FromDate.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtp_PaymentReveiw_ToDate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.chk_SortedByCustCode);
            this.groupBox1.Controls.Add(this.dtp_PaymentReview_FromDate);
            this.groupBox1.Controls.Add(this.btn_PaymentReveiw);
            this.groupBox1.Controls.Add(this.chk_AccountView);
            this.groupBox1.Location = new System.Drawing.Point(12, 164);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 150);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Payment Review";
            // 
            // txt_Reason
            // 
            this.txt_Reason.Location = new System.Drawing.Point(68, 320);
            this.txt_Reason.Multiline = true;
            this.txt_Reason.Name = "txt_Reason";
            this.txt_Reason.Size = new System.Drawing.Size(144, 72);
            this.txt_Reason.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "To Date";
            // 
            // dtp_PaymentReveiw_ToDate
            // 
            this.dtp_PaymentReveiw_ToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_PaymentReveiw_ToDate.Location = new System.Drawing.Point(74, 45);
            this.dtp_PaymentReveiw_ToDate.Name = "dtp_PaymentReveiw_ToDate";
            this.dtp_PaymentReveiw_ToDate.Size = new System.Drawing.Size(89, 20);
            this.dtp_PaymentReveiw_ToDate.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "From Date";
            // 
            // chk_SortedByCustCode
            // 
            this.chk_SortedByCustCode.AutoSize = true;
            this.chk_SortedByCustCode.Location = new System.Drawing.Point(21, 93);
            this.chk_SortedByCustCode.Name = "chk_SortedByCustCode";
            this.chk_SortedByCustCode.Size = new System.Drawing.Size(142, 17);
            this.chk_SortedByCustCode.TabIndex = 6;
            this.chk_SortedByCustCode.Text = "Assending By Cust Code";
            this.chk_SortedByCustCode.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtp_TodayBalanceDate);
            this.groupBox2.Controls.Add(this.btn_TodayCustBalance);
            this.groupBox2.Controls.Add(this.btn_TodayCustMoneyBalance);
            this.groupBox2.Controls.Add(this.btn_TodayCustShareBalance);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 146);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Customer Report";
            // 
            // dtp_TodayBalanceDate
            // 
            this.dtp_TodayBalanceDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_TodayBalanceDate.Location = new System.Drawing.Point(21, 14);
            this.dtp_TodayBalanceDate.Name = "dtp_TodayBalanceDate";
            this.dtp_TodayBalanceDate.Size = new System.Drawing.Size(158, 20);
            this.dtp_TodayBalanceDate.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 323);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Reason :";
            // 
            // frmAdminAlternativeReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 403);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_Reason);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmAdminAlternativeReport";
            this.Text = "Admin Alternative";
            this.Load += new System.EventHandler(this.frmAdminAlternativeReport_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_TodayCustBalance;
        private System.Windows.Forms.Button btn_TodayCustMoneyBalance;
        private System.Windows.Forms.Button btn_TodayCustShareBalance;
        private System.Windows.Forms.Button btn_PaymentReveiw;
        private System.Windows.Forms.CheckBox chk_AccountView;
        private System.Windows.Forms.DateTimePicker dtp_PaymentReview_FromDate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dtp_TodayBalanceDate;
        private System.Windows.Forms.CheckBox chk_SortedByCustCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtp_PaymentReveiw_ToDate;
        private System.Windows.Forms.TextBox txt_Reason;
        private System.Windows.Forms.Label label3;
    }
}