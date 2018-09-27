namespace Reports
{
    partial class CustomerSummeryLedger
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
            this.txtCustCode = new System.Windows.Forms.TextBox();
            this.label199 = new System.Windows.Forms.Label();
            this.txtAccountHolderName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAccountHolderBOId = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ddlSearchCustomer = new System.Windows.Forms.ComboBox();
            this.label198 = new System.Windows.Forms.Label();
            this.txtSearchCustomer = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnReport = new System.Windows.Forms.Button();
            this.gpPeriod = new System.Windows.Forms.GroupBox();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.gpPeriod.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCustCode);
            this.groupBox1.Controls.Add(this.label199);
            this.groupBox1.Controls.Add(this.txtAccountHolderName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtAccountHolderBOId);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(13, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(320, 158);
            this.groupBox1.TabIndex = 96;
            this.groupBox1.TabStop = false;
            // 
            // txtCustCode
            // 
            this.txtCustCode.Location = new System.Drawing.Point(147, 77);
            this.txtCustCode.Name = "txtCustCode";
            this.txtCustCode.ReadOnly = true;
            this.txtCustCode.Size = new System.Drawing.Size(166, 20);
            this.txtCustCode.TabIndex = 102;
            // 
            // label199
            // 
            this.label199.AutoSize = true;
            this.label199.Location = new System.Drawing.Point(13, 81);
            this.label199.Name = "label199";
            this.label199.Size = new System.Drawing.Size(79, 13);
            this.label199.TabIndex = 101;
            this.label199.Text = "Customer Code";
            // 
            // txtAccountHolderName
            // 
            this.txtAccountHolderName.Location = new System.Drawing.Point(147, 100);
            this.txtAccountHolderName.Name = "txtAccountHolderName";
            this.txtAccountHolderName.ReadOnly = true;
            this.txtAccountHolderName.Size = new System.Drawing.Size(166, 20);
            this.txtAccountHolderName.TabIndex = 100;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 13);
            this.label1.TabIndex = 99;
            this.label1.Text = "Name of Account Holder";
            // 
            // txtAccountHolderBOId
            // 
            this.txtAccountHolderBOId.Location = new System.Drawing.Point(147, 124);
            this.txtAccountHolderBOId.Name = "txtAccountHolderBOId";
            this.txtAccountHolderBOId.ReadOnly = true;
            this.txtAccountHolderBOId.Size = new System.Drawing.Size(166, 20);
            this.txtAccountHolderBOId.TabIndex = 98;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(13, 126);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(120, 13);
            this.label14.TabIndex = 97;
            this.label14.Text = "Account Holder\'s BO ID";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ddlSearchCustomer);
            this.groupBox2.Controls.Add(this.label198);
            this.groupBox2.Controls.Add(this.txtSearchCustomer);
            this.groupBox2.Location = new System.Drawing.Point(7, 18);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(306, 55);
            this.groupBox2.TabIndex = 96;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Select";
            // 
            // ddlSearchCustomer
            // 
            this.ddlSearchCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlSearchCustomer.FormattingEnabled = true;
            this.ddlSearchCustomer.Items.AddRange(new object[] {
            "Customer Code",
            "BO Id"});
            this.ddlSearchCustomer.Location = new System.Drawing.Point(9, 21);
            this.ddlSearchCustomer.Name = "ddlSearchCustomer";
            this.ddlSearchCustomer.Size = new System.Drawing.Size(121, 21);
            this.ddlSearchCustomer.TabIndex = 1;
            // 
            // label198
            // 
            this.label198.AutoSize = true;
            this.label198.Location = new System.Drawing.Point(131, 25);
            this.label198.Name = "label198";
            this.label198.Size = new System.Drawing.Size(10, 13);
            this.label198.TabIndex = 1;
            this.label198.Text = ":";
            // 
            // txtSearchCustomer
            // 
            this.txtSearchCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchCustomer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtSearchCustomer.Location = new System.Drawing.Point(147, 22);
            this.txtSearchCustomer.Name = "txtSearchCustomer";
            this.txtSearchCustomer.Size = new System.Drawing.Size(142, 20);
            this.txtSearchCustomer.TabIndex = 0;
            this.txtSearchCustomer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchCustomer_KeyDown);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnReport);
            this.groupBox4.Location = new System.Drawing.Point(140, 225);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(80, 66);
            this.groupBox4.TabIndex = 97;
            this.groupBox4.TabStop = false;
            // 
            // btnReport
            // 
            this.btnReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.Location = new System.Drawing.Point(6, 14);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(68, 44);
            this.btnReport.TabIndex = 4;
            this.btnReport.Text = "Report";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // gpPeriod
            // 
            this.gpPeriod.Controls.Add(this.dtToDate);
            this.gpPeriod.Controls.Add(this.dtFromDate);
            this.gpPeriod.Controls.Add(this.label3);
            this.gpPeriod.Controls.Add(this.label2);
            this.gpPeriod.Location = new System.Drawing.Point(13, 171);
            this.gpPeriod.Name = "gpPeriod";
            this.gpPeriod.Size = new System.Drawing.Size(320, 54);
            this.gpPeriod.TabIndex = 98;
            this.gpPeriod.TabStop = false;
            this.gpPeriod.Text = "Period";
            // 
            // dtToDate
            // 
            this.dtToDate.CustomFormat = "dd-MMM-yyyy";
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToDate.Location = new System.Drawing.Point(203, 21);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(110, 20);
            this.dtToDate.TabIndex = 3;
            // 
            // dtFromDate
            // 
            this.dtFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(42, 21);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(116, 20);
            this.dtFromDate.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(167, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "TO";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "FROM ";
            // 
            // CustomerSummeryLedger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 297);
            this.Controls.Add(this.gpPeriod);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "CustomerSummeryLedger";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer Summery Ledger";
            this.Load += new System.EventHandler(this.CustomerSummeryLedger_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.gpPeriod.ResumeLayout(false);
            this.gpPeriod.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCustCode;
        private System.Windows.Forms.Label label199;
        private System.Windows.Forms.TextBox txtAccountHolderName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAccountHolderBOId;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox ddlSearchCustomer;
        private System.Windows.Forms.Label label198;
        private System.Windows.Forms.TextBox txtSearchCustomer;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.GroupBox gpPeriod;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}