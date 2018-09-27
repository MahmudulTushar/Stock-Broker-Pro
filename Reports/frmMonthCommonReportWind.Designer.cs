namespace Reports
{
    partial class frmMonthCommonReportWind
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.rbtYearly = new System.Windows.Forms.RadioButton();
            this.rbtMonthly = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ddlBranchList = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnReport = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Tan;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.rbtYearly);
            this.panel1.Controls.Add(this.rbtMonthly);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(378, 63);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Tan;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(22, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(326, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Monthly Expenditre Report";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rbtYearly
            // 
            this.rbtYearly.AutoSize = true;
            this.rbtYearly.BackColor = System.Drawing.Color.Transparent;
            this.rbtYearly.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtYearly.ForeColor = System.Drawing.Color.Crimson;
            this.rbtYearly.Location = new System.Drawing.Point(200, 34);
            this.rbtYearly.Name = "rbtYearly";
            this.rbtYearly.Size = new System.Drawing.Size(148, 19);
            this.rbtYearly.TabIndex = 2;
            this.rbtYearly.TabStop = true;
            this.rbtYearly.Text = "Yearly Expense Report";
            this.rbtYearly.UseVisualStyleBackColor = false;
            this.rbtYearly.CheckedChanged += new System.EventHandler(this.rbtMonthly_CheckedChanged);
            // 
            // rbtMonthly
            // 
            this.rbtMonthly.AutoSize = true;
            this.rbtMonthly.BackColor = System.Drawing.Color.Transparent;
            this.rbtMonthly.Checked = true;
            this.rbtMonthly.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtMonthly.ForeColor = System.Drawing.Color.Crimson;
            this.rbtMonthly.Location = new System.Drawing.Point(22, 34);
            this.rbtMonthly.Name = "rbtMonthly";
            this.rbtMonthly.Size = new System.Drawing.Size(160, 19);
            this.rbtMonthly.TabIndex = 1;
            this.rbtMonthly.TabStop = true;
            this.rbtMonthly.Text = "Monthly Expense Report ";
            this.rbtMonthly.UseVisualStyleBackColor = false;
            this.rbtMonthly.CheckedChanged += new System.EventHandler(this.rbtMonthly_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ddlBranchList);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dtpToDate);
            this.groupBox1.Controls.Add(this.dtpFromDate);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.groupBox1.Location = new System.Drawing.Point(7, 71);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(359, 107);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Time Period";
            // 
            // ddlBranchList
            // 
            this.ddlBranchList.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ddlBranchList.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ddlBranchList.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlBranchList.FormattingEnabled = true;
            this.ddlBranchList.Location = new System.Drawing.Point(139, 25);
            this.ddlBranchList.Name = "ddlBranchList";
            this.ddlBranchList.Size = new System.Drawing.Size(160, 21);
            this.ddlBranchList.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Peru;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(56, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Branch      :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpToDate
            // 
            this.dtpToDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpToDate.CustomFormat = "MMMM-yyyy";
            this.dtpToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(139, 76);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(160, 20);
            this.dtpToDate.TabIndex = 3;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFromDate.CustomFormat = "MMMM-yyyy";
            this.dtpFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(139, 50);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(160, 20);
            this.dtpFromDate.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Peru;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(56, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "To Date    :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Peru;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(56, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "From Date :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnReport
            // 
            this.btnReport.BackColor = System.Drawing.Color.Tan;
            this.btnReport.FlatAppearance.BorderColor = System.Drawing.Color.Peru;
            this.btnReport.FlatAppearance.BorderSize = 5;
            this.btnReport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.BurlyWood;
            this.btnReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.BurlyWood;
            this.btnReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReport.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.Location = new System.Drawing.Point(7, 184);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(359, 54);
            this.btnReport.TabIndex = 2;
            this.btnReport.Text = "Report";
            this.btnReport.UseVisualStyleBackColor = false;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // frmMonthCommonReportWind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.BurlyWood;
            this.ClientSize = new System.Drawing.Size(378, 243);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frmMonthCommonReportWind";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Monthly Opex Report";
            this.Load += new System.EventHandler(this.frmMonthCommonReportWind_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbtYearly;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.RadioButton rbtMonthly;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ddlBranchList;
        private System.Windows.Forms.Label label4;
    }
}