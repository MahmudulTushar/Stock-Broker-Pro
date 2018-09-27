namespace Reports
{
    partial class frmCommonDateReport
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
            this.rbtCustomize = new System.Windows.Forms.RadioButton();
            this.rbtYearly = new System.Windows.Forms.RadioButton();
            this.rbtMonthly = new System.Windows.Forms.RadioButton();
            this.rbtnDaily = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnView = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ddlBranchList = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtCustomize);
            this.groupBox1.Controls.Add(this.rbtYearly);
            this.groupBox1.Controls.Add(this.rbtMonthly);
            this.groupBox1.Controls.Add(this.rbtnDaily);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.groupBox1.Location = new System.Drawing.Point(11, 86);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(334, 85);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Report Catagory";
            // 
            // rbtCustomize
            // 
            this.rbtCustomize.AllowDrop = true;
            this.rbtCustomize.AutoSize = true;
            this.rbtCustomize.ForeColor = System.Drawing.Color.Black;
            this.rbtCustomize.Location = new System.Drawing.Point(176, 49);
            this.rbtCustomize.Name = "rbtCustomize";
            this.rbtCustomize.Size = new System.Drawing.Size(124, 17);
            this.rbtCustomize.TabIndex = 3;
            this.rbtCustomize.TabStop = true;
            this.rbtCustomize.Text = "Customize Report";
            this.rbtCustomize.UseVisualStyleBackColor = true;
            this.rbtCustomize.CheckedChanged += new System.EventHandler(this.rbtCustomize_CheckedChanged);
            // 
            // rbtYearly
            // 
            this.rbtYearly.AutoSize = true;
            this.rbtYearly.ForeColor = System.Drawing.Color.Black;
            this.rbtYearly.Location = new System.Drawing.Point(40, 49);
            this.rbtYearly.Name = "rbtYearly";
            this.rbtYearly.Size = new System.Drawing.Size(106, 17);
            this.rbtYearly.TabIndex = 2;
            this.rbtYearly.TabStop = true;
            this.rbtYearly.Text = "Yearly  Report";
            this.rbtYearly.UseVisualStyleBackColor = true;
            this.rbtYearly.CheckedChanged += new System.EventHandler(this.rbtYearly_CheckedChanged);
            // 
            // rbtMonthly
            // 
            this.rbtMonthly.AutoSize = true;
            this.rbtMonthly.ForeColor = System.Drawing.Color.Black;
            this.rbtMonthly.Location = new System.Drawing.Point(176, 26);
            this.rbtMonthly.Name = "rbtMonthly";
            this.rbtMonthly.Size = new System.Drawing.Size(111, 17);
            this.rbtMonthly.TabIndex = 1;
            this.rbtMonthly.TabStop = true;
            this.rbtMonthly.Text = "Monthly Report";
            this.rbtMonthly.UseVisualStyleBackColor = true;
            this.rbtMonthly.CheckedChanged += new System.EventHandler(this.rbtMonthly_CheckedChanged);
            // 
            // rbtnDaily
            // 
            this.rbtnDaily.AutoSize = true;
            this.rbtnDaily.Checked = true;
            this.rbtnDaily.ForeColor = System.Drawing.Color.Black;
            this.rbtnDaily.Location = new System.Drawing.Point(40, 26);
            this.rbtnDaily.Name = "rbtnDaily";
            this.rbtnDaily.Size = new System.Drawing.Size(95, 17);
            this.rbtnDaily.TabIndex = 0;
            this.rbtnDaily.TabStop = true;
            this.rbtnDaily.Text = "Daily Report";
            this.rbtnDaily.UseVisualStyleBackColor = true;
            this.rbtnDaily.CheckedChanged += new System.EventHandler(this.rbtnDaily_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtpTo);
            this.groupBox2.Controls.Add(this.dtpFrom);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.groupBox2.Location = new System.Drawing.Point(11, 176);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(334, 53);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Time Interval";
            // 
            // dtpTo
            // 
            this.dtpTo.CustomFormat = "dd-MMM-yyyy";
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(202, 19);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(99, 20);
            this.dtpTo.TabIndex = 3;
            // 
            // dtpFrom
            // 
            this.dtpFrom.CustomFormat = "dd-MMM-yyyy";
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(71, 19);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(100, 20);
            this.dtpFrom.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(171, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "To :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(31, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "From :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnView
            // 
            this.btnView.BackColor = System.Drawing.Color.Transparent;
            this.btnView.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.btnView.FlatAppearance.BorderSize = 4;
            this.btnView.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnView.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnView.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.ForeColor = System.Drawing.Color.Black;
            this.btnView.Location = new System.Drawing.Point(11, 235);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(334, 47);
            this.btnView.TabIndex = 2;
            this.btnView.Text = "View Report";
            this.btnView.UseVisualStyleBackColor = false;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ddlBranchList);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.groupBox3.Location = new System.Drawing.Point(11, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(334, 79);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Report Information";
            // 
            // ddlBranchList
            // 
            this.ddlBranchList.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ddlBranchList.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ddlBranchList.BackColor = System.Drawing.Color.White;
            this.ddlBranchList.ForeColor = System.Drawing.Color.Black;
            this.ddlBranchList.FormattingEnabled = true;
            this.ddlBranchList.Location = new System.Drawing.Point(91, 47);
            this.ddlBranchList.Name = "ddlBranchList";
            this.ddlBranchList.Size = new System.Drawing.Size(209, 21);
            this.ddlBranchList.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(27, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "BRANCH :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoEllipsis = true;
            this.label3.BackColor = System.Drawing.Color.Gainsboro;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(30, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(271, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Daily Expenditure Report";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmCommonDateReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(354, 286);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frmCommonDateReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCommonDateReport";
            this.Load += new System.EventHandler(this.frmCommonDateReport_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtCustomize;
        private System.Windows.Forms.RadioButton rbtYearly;
        private System.Windows.Forms.RadioButton rbtMonthly;
        private System.Windows.Forms.RadioButton rbtnDaily;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ddlBranchList;
        private System.Windows.Forms.Label label4;
    }
}