namespace DseReports
{
    partial class frmBO_Modification_Report_DSE_21_5
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
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btnViewReport = new System.Windows.Forms.Button();
            this.txtCustCode_BOID = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.ddlCust_BOID = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpFromDate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpToDate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(196, 79);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Report Date";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = "dd-MM-yyyy";
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(79, 19);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(90, 20);
            this.dtpFromDate.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "From Date :";
            // 
            // dtpToDate
            // 
            this.dtpToDate.CustomFormat = "dd-MM-yyyy";
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(79, 45);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(90, 20);
            this.dtpToDate.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "To Date :";
            // 
            // btnViewReport
            // 
            this.btnViewReport.Location = new System.Drawing.Point(69, 122);
            this.btnViewReport.Name = "btnViewReport";
            this.btnViewReport.Size = new System.Drawing.Size(74, 23);
            this.btnViewReport.TabIndex = 12;
            this.btnViewReport.Text = "View Report";
            this.btnViewReport.UseVisualStyleBackColor = true;
            this.btnViewReport.Click += new System.EventHandler(this.btnViewReport_Click);
            // 
            // txtCustCode_BOID
            // 
            this.txtCustCode_BOID.Location = new System.Drawing.Point(104, 12);
            this.txtCustCode_BOID.Name = "txtCustCode_BOID";
            this.txtCustCode_BOID.Size = new System.Drawing.Size(90, 20);
            this.txtCustCode_BOID.TabIndex = 15;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(149, 122);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(59, 23);
            this.btnClose.TabIndex = 16;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ddlCust_BOID
            // 
            this.ddlCust_BOID.FormattingEnabled = true;
            this.ddlCust_BOID.Items.AddRange(new object[] {
            "Cust Code",
            "BO ID"});
            this.ddlCust_BOID.Location = new System.Drawing.Point(25, 12);
            this.ddlCust_BOID.Name = "ddlCust_BOID";
            this.ddlCust_BOID.Size = new System.Drawing.Size(73, 21);
            this.ddlCust_BOID.TabIndex = 17;
            // 
            // frmBO_Modification_Report_DSE_21_5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 155);
            this.Controls.Add(this.ddlCust_BOID);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtCustCode_BOID);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnViewReport);
            this.MaximizeBox = false;
            this.Name = "frmBO_Modification_Report_DSE_21_5";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BO Modification Report DSE_21_5";
            this.Load += new System.EventHandler(this.frmBO_Modification_Report_DSE_21_5_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnViewReport;
        private System.Windows.Forms.TextBox txtCustCode_BOID;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ComboBox ddlCust_BOID;
    }
}