namespace DseReports
{
    partial class frmBroker_Comission_Report_DSE_24_1
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
            this.cmbselection = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbtrader = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbbranch = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbexchange = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.btnShow = new System.Windows.Forms.Button();
            this.btnClsoe = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbselection);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cmbtrader);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbbranch);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbexchange);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(10, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 127);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selection Type";
            // 
            // cmbselection
            // 
            this.cmbselection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbselection.FormattingEnabled = true;
            this.cmbselection.Items.AddRange(new object[] {
            "All",
            "Exchange",
            "Branch",
            "Trader"});
            this.cmbselection.Location = new System.Drawing.Point(95, 18);
            this.cmbselection.Name = "cmbselection";
            this.cmbselection.Size = new System.Drawing.Size(99, 21);
            this.cmbselection.TabIndex = 7;
            this.cmbselection.SelectedIndexChanged += new System.EventHandler(this.cmbselection_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Selection Type";
            // 
            // cmbtrader
            // 
            this.cmbtrader.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbtrader.FormattingEnabled = true;
            this.cmbtrader.Location = new System.Drawing.Point(95, 97);
            this.cmbtrader.Name = "cmbtrader";
            this.cmbtrader.Size = new System.Drawing.Size(99, 21);
            this.cmbtrader.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Trader";
            // 
            // cmbbranch
            // 
            this.cmbbranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbbranch.FormattingEnabled = true;
            this.cmbbranch.Location = new System.Drawing.Point(95, 69);
            this.cmbbranch.Name = "cmbbranch";
            this.cmbbranch.Size = new System.Drawing.Size(99, 21);
            this.cmbbranch.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Branch Name";
            // 
            // cmbexchange
            // 
            this.cmbexchange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbexchange.FormattingEnabled = true;
            this.cmbexchange.Items.AddRange(new object[] {
            "All",
            "DSE",
            "CSE"});
            this.cmbexchange.Location = new System.Drawing.Point(95, 43);
            this.cmbexchange.Name = "cmbexchange";
            this.cmbexchange.Size = new System.Drawing.Size(99, 21);
            this.cmbexchange.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Exchange Name";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtpEnd);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.dtpStart);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(10, 142);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 80);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Date Range";
            // 
            // dtpEnd
            // 
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEnd.Location = new System.Drawing.Point(101, 45);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(93, 20);
            this.dtpEnd.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "End Date";
            // 
            // dtpStart
            // 
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStart.Location = new System.Drawing.Point(101, 19);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(93, 20);
            this.dtpStart.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Start Date";
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(10, 228);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(79, 23);
            this.btnShow.TabIndex = 4;
            this.btnShow.Text = "Show Report";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // btnClsoe
            // 
            this.btnClsoe.Location = new System.Drawing.Point(135, 228);
            this.btnClsoe.Name = "btnClsoe";
            this.btnClsoe.Size = new System.Drawing.Size(75, 23);
            this.btnClsoe.TabIndex = 5;
            this.btnClsoe.Text = "Close";
            this.btnClsoe.UseVisualStyleBackColor = true;
            this.btnClsoe.Click += new System.EventHandler(this.btnClsoe_Click_1);
            // 
            // frmBroker_Comission_Report_DSE_24_1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(218, 257);
            this.Controls.Add(this.btnClsoe);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmBroker_Comission_Report_DSE_24_1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmBroker_Comission_Report_DSE_24_1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbtrader;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbbranch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbexchange;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Button btnClsoe;
        private System.Windows.Forms.ComboBox cmbselection;
        private System.Windows.Forms.Label label6;
    }
}