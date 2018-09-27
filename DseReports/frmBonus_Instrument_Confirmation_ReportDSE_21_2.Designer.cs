namespace DseReports
{
    partial class frmBonus_Instrument_Confirmation_ReportDSE_21_2
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
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.btnViewReport = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdbAll = new System.Windows.Forms.RadioButton();
            this.rdbByCustCode = new System.Windows.Forms.RadioButton();
            this.rdbByBOID = new System.Windows.Forms.RadioButton();
            this.txtByBOID = new System.Windows.Forms.TextBox();
            this.txtByCustCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ddlInstrumentID = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = "dd-MM-yyyy";
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(96, 19);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(112, 20);
            this.dtpFromDate.TabIndex = 2;
            // 
            // btnViewReport
            // 
            this.btnViewReport.Location = new System.Drawing.Point(69, 250);
            this.btnViewReport.Name = "btnViewReport";
            this.btnViewReport.Size = new System.Drawing.Size(85, 23);
            this.btnViewReport.TabIndex = 6;
            this.btnViewReport.Text = "View Report";
            this.btnViewReport.UseVisualStyleBackColor = true;
            this.btnViewReport.Click += new System.EventHandler(this.btnViewReport_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpFromDate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpToDate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 165);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(253, 79);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Date Range";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "From Date :";
            // 
            // dtpToDate
            // 
            this.dtpToDate.CustomFormat = "dd-MM-yyyy";
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(96, 45);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(112, 20);
            this.dtpToDate.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "To Date :";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(160, 250);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(59, 23);
            this.btnClose.TabIndex = 17;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdbAll);
            this.groupBox3.Controls.Add(this.rdbByCustCode);
            this.groupBox3.Controls.Add(this.rdbByBOID);
            this.groupBox3.Controls.Add(this.txtByBOID);
            this.groupBox3.Controls.Add(this.txtByCustCode);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(253, 88);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Cust Info";
            // 
            // rdbAll
            // 
            this.rdbAll.AutoSize = true;
            this.rdbAll.Checked = true;
            this.rdbAll.Location = new System.Drawing.Point(8, 16);
            this.rdbAll.Name = "rdbAll";
            this.rdbAll.Size = new System.Drawing.Size(36, 17);
            this.rdbAll.TabIndex = 28;
            this.rdbAll.TabStop = true;
            this.rdbAll.Text = "All";
            this.rdbAll.UseVisualStyleBackColor = true;
            this.rdbAll.CheckedChanged += new System.EventHandler(this.rdbAll_CheckedChanged);
            // 
            // rdbByCustCode
            // 
            this.rdbByCustCode.AutoSize = true;
            this.rdbByCustCode.Location = new System.Drawing.Point(8, 37);
            this.rdbByCustCode.Name = "rdbByCustCode";
            this.rdbByCustCode.Size = new System.Drawing.Size(89, 17);
            this.rdbByCustCode.TabIndex = 27;
            this.rdbByCustCode.Text = "By Cust Code";
            this.rdbByCustCode.UseVisualStyleBackColor = true;
            this.rdbByCustCode.CheckedChanged += new System.EventHandler(this.rdbByCustCode_CheckedChanged);
            // 
            // rdbByBOID
            // 
            this.rdbByBOID.AutoSize = true;
            this.rdbByBOID.Location = new System.Drawing.Point(8, 60);
            this.rdbByBOID.Name = "rdbByBOID";
            this.rdbByBOID.Size = new System.Drawing.Size(66, 17);
            this.rdbByBOID.TabIndex = 26;
            this.rdbByBOID.Text = "By BOID";
            this.rdbByBOID.UseVisualStyleBackColor = true;
            this.rdbByBOID.CheckedChanged += new System.EventHandler(this.rdbByBOID_CheckedChanged);
            // 
            // txtByBOID
            // 
            this.txtByBOID.Enabled = false;
            this.txtByBOID.Location = new System.Drawing.Point(103, 59);
            this.txtByBOID.Name = "txtByBOID";
            this.txtByBOID.Size = new System.Drawing.Size(142, 20);
            this.txtByBOID.TabIndex = 24;
            this.txtByBOID.TextChanged += new System.EventHandler(this.txtByBOID_TextChanged);
            // 
            // txtByCustCode
            // 
            this.txtByCustCode.Enabled = false;
            this.txtByCustCode.Location = new System.Drawing.Point(103, 36);
            this.txtByCustCode.Name = "txtByCustCode";
            this.txtByCustCode.Size = new System.Drawing.Size(142, 20);
            this.txtByCustCode.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Instrument ID :";
            // 
            // ddlInstrumentID
            // 
            this.ddlInstrumentID.FormattingEnabled = true;
            this.ddlInstrumentID.Location = new System.Drawing.Point(103, 21);
            this.ddlInstrumentID.Name = "ddlInstrumentID";
            this.ddlInstrumentID.Size = new System.Drawing.Size(142, 21);
            this.ddlInstrumentID.TabIndex = 19;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ddlInstrumentID);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(12, 106);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(253, 53);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Instrument Info";
            // 
            // frmBonus_Instrument_Confirmation_ReportDSE_21_2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 285);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnViewReport);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(289, 323);
            this.MinimumSize = new System.Drawing.Size(289, 323);
            this.Name = "frmBonus_Instrument_Confirmation_ReportDSE_21_2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bonus Instrument Confirmation Report  DSE_21_2";
            this.Load += new System.EventHandler(this.frmBonus_Instrument_Confirmation_ReportDSE_21_2_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Button btnViewReport;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rdbAll;
        private System.Windows.Forms.RadioButton rdbByCustCode;
        private System.Windows.Forms.RadioButton rdbByBOID;
        private System.Windows.Forms.TextBox txtByBOID;
        private System.Windows.Forms.TextBox txtByCustCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ddlInstrumentID;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}