namespace Reports
{
    partial class TodaySummeryReport
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
            this.lblTransDate = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnTodaysTotalbalance = new System.Windows.Forms.Button();
            this.btnCustMoneybalance = new System.Windows.Forms.Button();
            this.btnCustShareBalance = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Transaction Date :";
            // 
            // lblTransDate
            // 
            this.lblTransDate.AutoSize = true;
            this.lblTransDate.Location = new System.Drawing.Point(123, 13);
            this.lblTransDate.Name = "lblTransDate";
            this.lblTransDate.Size = new System.Drawing.Size(32, 13);
            this.lblTransDate.TabIndex = 1;
            this.lblTransDate.Text = "[msg]";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnTodaysTotalbalance);
            this.groupBox1.Controls.Add(this.btnCustMoneybalance);
            this.groupBox1.Controls.Add(this.btnCustShareBalance);
            this.groupBox1.Location = new System.Drawing.Point(18, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(183, 108);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // btnTodaysTotalbalance
            // 
            this.btnTodaysTotalbalance.Location = new System.Drawing.Point(6, 69);
            this.btnTodaysTotalbalance.Name = "btnTodaysTotalbalance";
            this.btnTodaysTotalbalance.Size = new System.Drawing.Size(170, 23);
            this.btnTodaysTotalbalance.TabIndex = 7;
            this.btnTodaysTotalbalance.Text = "Today\'s Total Balance";
            this.btnTodaysTotalbalance.UseVisualStyleBackColor = true;
            this.btnTodaysTotalbalance.Click += new System.EventHandler(this.btnTodaysTotalbalance_Click);
            // 
            // btnCustMoneybalance
            // 
            this.btnCustMoneybalance.Location = new System.Drawing.Point(6, 42);
            this.btnCustMoneybalance.Name = "btnCustMoneybalance";
            this.btnCustMoneybalance.Size = new System.Drawing.Size(170, 23);
            this.btnCustMoneybalance.TabIndex = 6;
            this.btnCustMoneybalance.Text = "Customer [Money] Balance";
            this.btnCustMoneybalance.UseVisualStyleBackColor = true;
            this.btnCustMoneybalance.Click += new System.EventHandler(this.btnCustMoneybalance_Click);
            // 
            // btnCustShareBalance
            // 
            this.btnCustShareBalance.Location = new System.Drawing.Point(6, 14);
            this.btnCustShareBalance.Name = "btnCustShareBalance";
            this.btnCustShareBalance.Size = new System.Drawing.Size(170, 23);
            this.btnCustShareBalance.TabIndex = 5;
            this.btnCustShareBalance.Text = "Customer [Share] Balance";
            this.btnCustShareBalance.UseVisualStyleBackColor = true;
            this.btnCustShareBalance.Click += new System.EventHandler(this.btnCustShareBalance_Click);
            // 
            // TodaySummeryReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(211, 151);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblTransDate);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "TodaySummeryReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Today\'s Summery Report";
            this.Load += new System.EventHandler(this.TodaySummeryReport_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTransDate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnTodaysTotalbalance;
        private System.Windows.Forms.Button btnCustMoneybalance;
        private System.Windows.Forms.Button btnCustShareBalance;
    }
}