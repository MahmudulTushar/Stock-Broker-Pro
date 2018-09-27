namespace StockbrokerProNewArch
{
    partial class frm_IPOTransactionChargeTaken
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
            this.txt_TransferFromCode = new System.Windows.Forms.TextBox();
            this.txt_Amount = new System.Windows.Forms.TextBox();
            this.txt_VoucherNo = new System.Windows.Forms.TextBox();
            this.dtp_Received_Date = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_Remarks = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_Submit = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbPaymentMediaForCharge = new System.Windows.Forms.ComboBox();
            this.txt_Balance = new System.Windows.Forms.TextBox();
            this.cmb_ChargeType = new System.Windows.Forms.ComboBox();
            this.txt_ChargedCode_ForCheque = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Transfer From";
            // 
            // txt_TransferFromCode
            // 
            this.txt_TransferFromCode.Location = new System.Drawing.Point(114, 39);
            this.txt_TransferFromCode.Name = "txt_TransferFromCode";
            this.txt_TransferFromCode.Size = new System.Drawing.Size(108, 20);
            this.txt_TransferFromCode.TabIndex = 1;
            this.txt_TransferFromCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_ChargeCustCode_KeyDown);
            // 
            // txt_Amount
            // 
            this.txt_Amount.Location = new System.Drawing.Point(156, 65);
            this.txt_Amount.Name = "txt_Amount";
            this.txt_Amount.ReadOnly = true;
            this.txt_Amount.Size = new System.Drawing.Size(141, 20);
            this.txt_Amount.TabIndex = 2;
            this.txt_Amount.Leave += new System.EventHandler(this.txt_Amount_Leave);
            // 
            // txt_VoucherNo
            // 
            this.txt_VoucherNo.Location = new System.Drawing.Point(157, 117);
            this.txt_VoucherNo.Name = "txt_VoucherNo";
            this.txt_VoucherNo.ReadOnly = true;
            this.txt_VoucherNo.Size = new System.Drawing.Size(140, 20);
            this.txt_VoucherNo.TabIndex = 3;
            // 
            // dtp_Received_Date
            // 
            this.dtp_Received_Date.Enabled = false;
            this.dtp_Received_Date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_Received_Date.Location = new System.Drawing.Point(157, 91);
            this.dtp_Received_Date.Name = "dtp_Received_Date";
            this.dtp_Received_Date.Size = new System.Drawing.Size(140, 20);
            this.dtp_Received_Date.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Received_Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(101, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Amount";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(78, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Voucher No";
            // 
            // txt_Remarks
            // 
            this.txt_Remarks.Location = new System.Drawing.Point(156, 143);
            this.txt_Remarks.Name = "txt_Remarks";
            this.txt_Remarks.Size = new System.Drawing.Size(140, 20);
            this.txt_Remarks.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(93, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Remarks";
            // 
            // btn_Submit
            // 
            this.btn_Submit.Location = new System.Drawing.Point(53, 196);
            this.btn_Submit.Name = "btn_Submit";
            this.btn_Submit.Size = new System.Drawing.Size(75, 23);
            this.btn_Submit.TabIndex = 10;
            this.btn_Submit.Text = "Save";
            this.btn_Submit.UseVisualStyleBackColor = true;
            this.btn_Submit.Click += new System.EventHandler(this.btn_Submit_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(142, 196);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 11;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            // 
            // btn_Close
            // 
            this.btn_Close.Location = new System.Drawing.Point(232, 196);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(75, 23);
            this.btn_Close.TabIndex = 12;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Payment Media";
            // 
            // cmbPaymentMediaForCharge
            // 
            this.cmbPaymentMediaForCharge.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaymentMediaForCharge.FormattingEnabled = true;
            this.cmbPaymentMediaForCharge.Items.AddRange(new object[] {
            "Cash",
            "TRTA",
            "TRIPO"});
            this.cmbPaymentMediaForCharge.Location = new System.Drawing.Point(114, 12);
            this.cmbPaymentMediaForCharge.Name = "cmbPaymentMediaForCharge";
            this.cmbPaymentMediaForCharge.Size = new System.Drawing.Size(108, 21);
            this.cmbPaymentMediaForCharge.TabIndex = 14;
            this.cmbPaymentMediaForCharge.SelectedIndexChanged += new System.EventHandler(this.cmbPaymentMediaForCharge_SelectedIndexChanged);
            // 
            // txt_Balance
            // 
            this.txt_Balance.Enabled = false;
            this.txt_Balance.Location = new System.Drawing.Point(228, 39);
            this.txt_Balance.Name = "txt_Balance";
            this.txt_Balance.Size = new System.Drawing.Size(112, 20);
            this.txt_Balance.TabIndex = 16;
            // 
            // cmb_ChargeType
            // 
            this.cmb_ChargeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_ChargeType.FormattingEnabled = true;
            this.cmb_ChargeType.Location = new System.Drawing.Point(228, 12);
            this.cmb_ChargeType.Name = "cmb_ChargeType";
            this.cmb_ChargeType.Size = new System.Drawing.Size(112, 21);
            this.cmb_ChargeType.TabIndex = 17;
            this.cmb_ChargeType.SelectedIndexChanged += new System.EventHandler(this.cmb_ChargeType_SelectedIndexChanged);
            // 
            // txt_ChargedCode_ForCheque
            // 
            this.txt_ChargedCode_ForCheque.Location = new System.Drawing.Point(303, 65);
            this.txt_ChargedCode_ForCheque.Name = "txt_ChargedCode_ForCheque";
            this.txt_ChargedCode_ForCheque.Size = new System.Drawing.Size(23, 20);
            this.txt_ChargedCode_ForCheque.TabIndex = 18;
            this.txt_ChargedCode_ForCheque.Visible = false;
            // 
            // frm_IPOTransactionChargeTaken
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 228);
            this.Controls.Add(this.txt_ChargedCode_ForCheque);
            this.Controls.Add(this.cmb_ChargeType);
            this.Controls.Add(this.txt_Balance);
            this.Controls.Add(this.cmbPaymentMediaForCharge);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Submit);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_Remarks);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtp_Received_Date);
            this.Controls.Add(this.txt_VoucherNo);
            this.Controls.Add(this.txt_Amount);
            this.Controls.Add(this.txt_TransferFromCode);
            this.Controls.Add(this.label1);
            this.Name = "frm_IPOTransactionChargeTaken";
            this.Text = "IPO Transaction Based Charge";
            this.Load += new System.EventHandler(this.frm_IPOTransactionChargeTaken_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_TransferFromCode;
        private System.Windows.Forms.TextBox txt_Amount;
        private System.Windows.Forms.TextBox txt_VoucherNo;
        private System.Windows.Forms.DateTimePicker dtp_Received_Date;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_Remarks;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_Submit;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbPaymentMediaForCharge;
        private System.Windows.Forms.TextBox txt_Balance;
        private System.Windows.Forms.ComboBox cmb_ChargeType;
        private System.Windows.Forms.TextBox txt_ChargedCode_ForCheque;
    }
}