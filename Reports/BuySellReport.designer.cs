namespace Reports
{
    partial class BuySellReport
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
            this.btnBuySellNetAmount = new System.Windows.Forms.Button();
            this.dtTransactionDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoInstruWise = new System.Windows.Forms.RadioButton();
            this.rdoCustwise = new System.Windows.Forms.RadioButton();
            this.btnSellList = new System.Windows.Forms.Button();
            this.btnBuyList = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBuySellNetAmount
            // 
            this.btnBuySellNetAmount.Location = new System.Drawing.Point(36, 117);
            this.btnBuySellNetAmount.Name = "btnBuySellNetAmount";
            this.btnBuySellNetAmount.Size = new System.Drawing.Size(180, 23);
            this.btnBuySellNetAmount.TabIndex = 1;
            this.btnBuySellNetAmount.Text = "Buy\\Sell Summery [Net Amount]";
            this.btnBuySellNetAmount.UseVisualStyleBackColor = true;
            this.btnBuySellNetAmount.Click += new System.EventHandler(this.btnBuySellNetAmount_Click);
            // 
            // dtTransactionDate
            // 
            this.dtTransactionDate.CustomFormat = "dd/MM/yyyy";
            this.dtTransactionDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTransactionDate.Location = new System.Drawing.Point(129, 8);
            this.dtTransactionDate.Name = "dtTransactionDate";
            this.dtTransactionDate.Size = new System.Drawing.Size(104, 20);
            this.dtTransactionDate.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Transaction Date";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoInstruWise);
            this.groupBox1.Controls.Add(this.rdoCustwise);
            this.groupBox1.Controls.Add(this.btnSellList);
            this.groupBox1.Controls.Add(this.btnBuyList);
            this.groupBox1.Location = new System.Drawing.Point(16, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(225, 79);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // rdoInstruWise
            // 
            this.rdoInstruWise.AutoSize = true;
            this.rdoInstruWise.Location = new System.Drawing.Point(6, 48);
            this.rdoInstruWise.Name = "rdoInstruWise";
            this.rdoInstruWise.Size = new System.Drawing.Size(101, 17);
            this.rdoInstruWise.TabIndex = 8;
            this.rdoInstruWise.TabStop = true;
            this.rdoInstruWise.Text = "Instrument Wise";
            this.rdoInstruWise.UseVisualStyleBackColor = true;
            // 
            // rdoCustwise
            // 
            this.rdoCustwise.AutoSize = true;
            this.rdoCustwise.Location = new System.Drawing.Point(7, 22);
            this.rdoCustwise.Name = "rdoCustwise";
            this.rdoCustwise.Size = new System.Drawing.Size(96, 17);
            this.rdoCustwise.TabIndex = 7;
            this.rdoCustwise.TabStop = true;
            this.rdoCustwise.Text = "Customer Wise";
            this.rdoCustwise.UseVisualStyleBackColor = true;
            // 
            // btnSellList
            // 
            this.btnSellList.Location = new System.Drawing.Point(113, 45);
            this.btnSellList.Name = "btnSellList";
            this.btnSellList.Size = new System.Drawing.Size(106, 23);
            this.btnSellList.TabIndex = 6;
            this.btnSellList.Text = "[Sell] Share List";
            this.btnSellList.UseVisualStyleBackColor = true;
            this.btnSellList.Click += new System.EventHandler(this.btnSellList_Click);
            // 
            // btnBuyList
            // 
            this.btnBuyList.Location = new System.Drawing.Point(113, 16);
            this.btnBuyList.Name = "btnBuyList";
            this.btnBuyList.Size = new System.Drawing.Size(106, 23);
            this.btnBuyList.TabIndex = 5;
            this.btnBuyList.Text = "[Buy] Share List";
            this.btnBuyList.UseVisualStyleBackColor = true;
            this.btnBuyList.Click += new System.EventHandler(this.btnBuyList_Click);
            // 
            // BuySellReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 148);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtTransactionDate);
            this.Controls.Add(this.btnBuySellNetAmount);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "BuySellReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buy/Sell Share";
            this.Load += new System.EventHandler(this.BuySellReport_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBuySellNetAmount;
        private System.Windows.Forms.DateTimePicker dtTransactionDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoInstruWise;
        private System.Windows.Forms.RadioButton rdoCustwise;
        private System.Windows.Forms.Button btnSellList;
        private System.Windows.Forms.Button btnBuyList;
    }
}