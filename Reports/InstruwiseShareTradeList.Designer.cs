namespace Reports
{
    partial class InstruwiseShareTradeList
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ddlCompanyShortCode = new System.Windows.Forms.ComboBox();
            this.dtStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtEndDate = new System.Windows.Forms.DateTimePicker();
            this.btnViewReport = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Gray;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(9, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Statr Date :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Gray;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(8, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "End Date :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Gray;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(10, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Instrument Shotr Name :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ddlCompanyShortCode
            // 
            this.ddlCompanyShortCode.FormattingEnabled = true;
            this.ddlCompanyShortCode.Location = new System.Drawing.Point(163, 17);
            this.ddlCompanyShortCode.Name = "ddlCompanyShortCode";
            this.ddlCompanyShortCode.Size = new System.Drawing.Size(121, 21);
            this.ddlCompanyShortCode.TabIndex = 3;
            // 
            // dtStartDate
            // 
            this.dtStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtStartDate.Location = new System.Drawing.Point(163, 51);
            this.dtStartDate.Name = "dtStartDate";
            this.dtStartDate.Size = new System.Drawing.Size(121, 20);
            this.dtStartDate.TabIndex = 4;
            // 
            // dtEndDate
            // 
            this.dtEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtEndDate.Location = new System.Drawing.Point(163, 83);
            this.dtEndDate.Name = "dtEndDate";
            this.dtEndDate.Size = new System.Drawing.Size(121, 20);
            this.dtEndDate.TabIndex = 5;
            // 
            // btnViewReport
            // 
            this.btnViewReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnViewReport.Location = new System.Drawing.Point(12, 128);
            this.btnViewReport.Name = "btnViewReport";
            this.btnViewReport.Size = new System.Drawing.Size(282, 42);
            this.btnViewReport.TabIndex = 6;
            this.btnViewReport.Text = "Report";
            this.btnViewReport.UseVisualStyleBackColor = true;
            this.btnViewReport.Click += new System.EventHandler(this.btnViewReport_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ddlCompanyShortCode);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtEndDate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtStartDate);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(295, 120);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // InstruwiseShareTradeList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 179);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnViewReport);
            this.Name = "InstruwiseShareTradeList";
            this.Text = "InstruwiseShareTradeListReport";
            this.Load += new System.EventHandler(this.InstruwiseShareTradeListReportViewer_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ddlCompanyShortCode;
        private System.Windows.Forms.DateTimePicker dtStartDate;
        private System.Windows.Forms.DateTimePicker dtEndDate;
        private System.Windows.Forms.Button btnViewReport;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}