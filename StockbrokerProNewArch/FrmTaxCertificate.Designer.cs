namespace StockbrokerProNewArch
{
    partial class FrmTaxCertificate
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
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.rdbRegister = new System.Windows.Forms.RadioButton();
            this.rdbOther = new System.Windows.Forms.RadioButton();
            this.rdbboopen = new System.Windows.Forms.RadioButton();
            this.rdbParentChild = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEmailID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCustCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rdbSummaryLedger = new System.Windows.Forms.RadioButton();
            this.rdbTradeIPOConfirmation = new System.Windows.Forms.RadioButton();
            this.rdbPortolio = new System.Windows.Forms.RadioButton();
            this.rdbTaxCertificate = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.txtEmailID);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtAmount);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtCustomerName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtCustCode);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(9, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(454, 232);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.rdbRegister);
            this.groupBox5.Controls.Add(this.rdbOther);
            this.groupBox5.Controls.Add(this.rdbboopen);
            this.groupBox5.Controls.Add(this.rdbParentChild);
            this.groupBox5.Location = new System.Drawing.Point(8, 113);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(438, 50);
            this.groupBox5.TabIndex = 99;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Email Address ";
            // 
            // rdbRegister
            // 
            this.rdbRegister.AutoSize = true;
            this.rdbRegister.Location = new System.Drawing.Point(140, 18);
            this.rdbRegister.Name = "rdbRegister";
            this.rdbRegister.Size = new System.Drawing.Size(92, 17);
            this.rdbRegister.TabIndex = 3;
            this.rdbRegister.TabStop = true;
            this.rdbRegister.Text = "Register Email";
            this.rdbRegister.UseVisualStyleBackColor = true;
            this.rdbRegister.CheckedChanged += new System.EventHandler(this.rdbRegister_CheckedChanged);
            // 
            // rdbOther
            // 
            this.rdbOther.AutoSize = true;
            this.rdbOther.Location = new System.Drawing.Point(310, 19);
            this.rdbOther.Name = "rdbOther";
            this.rdbOther.Size = new System.Drawing.Size(79, 17);
            this.rdbOther.TabIndex = 2;
            this.rdbOther.TabStop = true;
            this.rdbOther.Text = "Other Email";
            this.rdbOther.UseVisualStyleBackColor = true;
            this.rdbOther.CheckedChanged += new System.EventHandler(this.rdbOther_CheckedChanged);
            // 
            // rdbboopen
            // 
            this.rdbboopen.AutoSize = true;
            this.rdbboopen.Location = new System.Drawing.Point(237, 18);
            this.rdbboopen.Name = "rdbboopen";
            this.rdbboopen.Size = new System.Drawing.Size(68, 17);
            this.rdbboopen.TabIndex = 1;
            this.rdbboopen.TabStop = true;
            this.rdbboopen.Text = "BO Email";
            this.rdbboopen.UseVisualStyleBackColor = true;
            this.rdbboopen.CheckedChanged += new System.EventHandler(this.rdbboopen_CheckedChanged);
            // 
            // rdbParentChild
            // 
            this.rdbParentChild.AutoSize = true;
            this.rdbParentChild.Location = new System.Drawing.Point(32, 18);
            this.rdbParentChild.Name = "rdbParentChild";
            this.rdbParentChild.Size = new System.Drawing.Size(110, 17);
            this.rdbParentChild.TabIndex = 0;
            this.rdbParentChild.TabStop = true;
            this.rdbParentChild.Text = "Parent Child Email";
            this.rdbParentChild.UseVisualStyleBackColor = true;
            this.rdbParentChild.CheckedChanged += new System.EventHandler(this.rdbParentChild_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtToDate);
            this.groupBox2.Controls.Add(this.dtFromDate);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(8, 169);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(438, 54);
            this.groupBox2.TabIndex = 98;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Period";
            // 
            // dtToDate
            // 
            this.dtToDate.CustomFormat = "dd/MM/yyyy";
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToDate.Location = new System.Drawing.Point(237, 21);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(110, 20);
            this.dtToDate.TabIndex = 3;
            // 
            // dtFromDate
            // 
            this.dtFromDate.CustomFormat = "dd/MM/yyyy";
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(105, 21);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(101, 20);
            this.dtFromDate.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(212, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "TO";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(52, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "FROM ";
            // 
            // txtEmailID
            // 
            this.txtEmailID.BackColor = System.Drawing.Color.PowderBlue;
            this.txtEmailID.Location = new System.Drawing.Point(142, 91);
            this.txtEmailID.Name = "txtEmailID";
            this.txtEmailID.Size = new System.Drawing.Size(229, 20);
            this.txtEmailID.TabIndex = 97;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Gray;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Location = new System.Drawing.Point(16, 91);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label4.Size = new System.Drawing.Size(120, 20);
            this.label4.TabIndex = 96;
            this.label4.Text = "Email ID";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAmount
            // 
            this.txtAmount.BackColor = System.Drawing.Color.PowderBlue;
            this.txtAmount.Location = new System.Drawing.Point(142, 66);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.ReadOnly = true;
            this.txtAmount.Size = new System.Drawing.Size(113, 20);
            this.txtAmount.TabIndex = 95;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Gray;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(16, 66);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label2.Size = new System.Drawing.Size(120, 20);
            this.label2.TabIndex = 94;
            this.label2.Text = "Amount";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.BackColor = System.Drawing.Color.PowderBlue;
            this.txtCustomerName.Location = new System.Drawing.Point(142, 41);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.ReadOnly = true;
            this.txtCustomerName.Size = new System.Drawing.Size(229, 20);
            this.txtCustomerName.TabIndex = 93;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Gray;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(16, 40);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label1.Size = new System.Drawing.Size(120, 20);
            this.label1.TabIndex = 92;
            this.label1.Text = "Customer Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCustCode
            // 
            this.txtCustCode.BackColor = System.Drawing.Color.PowderBlue;
            this.txtCustCode.Location = new System.Drawing.Point(142, 17);
            this.txtCustCode.Name = "txtCustCode";
            this.txtCustCode.Size = new System.Drawing.Size(113, 20);
            this.txtCustCode.TabIndex = 91;
            this.txtCustCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCustCode_KeyDown);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Gray;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Location = new System.Drawing.Point(16, 16);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label3.Size = new System.Drawing.Size(120, 20);
            this.label3.TabIndex = 90;
            this.label3.Text = "Cust Code";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnClose);
            this.groupBox3.Controls.Add(this.btnRefresh);
            this.groupBox3.Controls.Add(this.btnSend);
            this.groupBox3.Location = new System.Drawing.Point(8, 311);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(454, 50);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(266, 16);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(185, 16);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(104, 16);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 0;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rdbSummaryLedger);
            this.groupBox4.Controls.Add(this.rdbTradeIPOConfirmation);
            this.groupBox4.Controls.Add(this.rdbPortolio);
            this.groupBox4.Controls.Add(this.rdbTaxCertificate);
            this.groupBox4.Location = new System.Drawing.Point(7, 235);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(454, 73);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            // 
            // rdbSummaryLedger
            // 
            this.rdbSummaryLedger.AutoSize = true;
            this.rdbSummaryLedger.ForeColor = System.Drawing.Color.White;
            this.rdbSummaryLedger.Location = new System.Drawing.Point(215, 43);
            this.rdbSummaryLedger.Name = "rdbSummaryLedger";
            this.rdbSummaryLedger.Size = new System.Drawing.Size(139, 17);
            this.rdbSummaryLedger.TabIndex = 3;
            this.rdbSummaryLedger.TabStop = true;
            this.rdbSummaryLedger.Text = "Summary Ledger Report";
            this.rdbSummaryLedger.UseVisualStyleBackColor = true;
            this.rdbSummaryLedger.CheckedChanged += new System.EventHandler(this.rdbSummaryLedger_CheckedChanged);
            // 
            // rdbTradeIPOConfirmation
            // 
            this.rdbTradeIPOConfirmation.AutoSize = true;
            this.rdbTradeIPOConfirmation.ForeColor = System.Drawing.Color.White;
            this.rdbTradeIPOConfirmation.Location = new System.Drawing.Point(215, 20);
            this.rdbTradeIPOConfirmation.Name = "rdbTradeIPOConfirmation";
            this.rdbTradeIPOConfirmation.Size = new System.Drawing.Size(172, 17);
            this.rdbTradeIPOConfirmation.TabIndex = 2;
            this.rdbTradeIPOConfirmation.TabStop = true;
            this.rdbTradeIPOConfirmation.Text = "Trade/IPO Confirmation Report";
            this.rdbTradeIPOConfirmation.UseVisualStyleBackColor = true;
            this.rdbTradeIPOConfirmation.CheckedChanged += new System.EventHandler(this.rdbTradeIPOConfirmation_CheckedChanged);
            // 
            // rdbPortolio
            // 
            this.rdbPortolio.AutoSize = true;
            this.rdbPortolio.ForeColor = System.Drawing.Color.White;
            this.rdbPortolio.Location = new System.Drawing.Point(60, 43);
            this.rdbPortolio.Name = "rdbPortolio";
            this.rdbPortolio.Size = new System.Drawing.Size(101, 17);
            this.rdbPortolio.TabIndex = 1;
            this.rdbPortolio.TabStop = true;
            this.rdbPortolio.Text = "Portfolio  Report";
            this.rdbPortolio.UseVisualStyleBackColor = true;
            this.rdbPortolio.CheckedChanged += new System.EventHandler(this.rdbPortolio_CheckedChanged);
            // 
            // rdbTaxCertificate
            // 
            this.rdbTaxCertificate.AutoSize = true;
            this.rdbTaxCertificate.ForeColor = System.Drawing.Color.White;
            this.rdbTaxCertificate.Location = new System.Drawing.Point(60, 20);
            this.rdbTaxCertificate.Name = "rdbTaxCertificate";
            this.rdbTaxCertificate.Size = new System.Drawing.Size(93, 17);
            this.rdbTaxCertificate.TabIndex = 0;
            this.rdbTaxCertificate.TabStop = true;
            this.rdbTaxCertificate.Text = "Tax Certificate";
            this.rdbTaxCertificate.UseVisualStyleBackColor = true;
            this.rdbTaxCertificate.CheckedChanged += new System.EventHandler(this.rdbTaxCertificate_CheckedChanged);
            // 
            // FrmTaxCertificate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(471, 370);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmTaxCertificate";
            this.Text = "Customer Report";
            this.Load += new System.EventHandler(this.FrmTaxCertificate_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCustCode;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEmailID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rdbSummaryLedger;
        private System.Windows.Forms.RadioButton rdbTradeIPOConfirmation;
        private System.Windows.Forms.RadioButton rdbPortolio;
        private System.Windows.Forms.RadioButton rdbTaxCertificate;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton rdbRegister;
        private System.Windows.Forms.RadioButton rdbOther;
        private System.Windows.Forms.RadioButton rdbboopen;
        private System.Windows.Forms.RadioButton rdbParentChild;
    }
}