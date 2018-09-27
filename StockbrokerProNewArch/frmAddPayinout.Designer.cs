namespace StockbrokerProNewArch
{
    partial class frmAddPayinout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddPayinout));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtFinalCustomerCode = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtISIN = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBOId = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTradeqty = new System.Windows.Forms.TextBox();
            this.ddlCompanyShortCode = new System.Windows.Forms.ComboBox();
            this.txtCustomerCode = new System.Windows.Forms.TextBox();
            this.dtpSattlementDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtFinalCustomerCode);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtISIN);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtBOId);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtTradeqty);
            this.groupBox1.Controls.Add(this.ddlCompanyShortCode);
            this.groupBox1.Controls.Add(this.txtCustomerCode);
            this.groupBox1.Controls.Add(this.dtpSattlementDate);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.ForeColor = System.Drawing.Color.DarkGreen;
            this.groupBox1.Location = new System.Drawing.Point(7, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(464, 141);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sattlement Information";
            // 
            // txtFinalCustomerCode
            // 
            this.txtFinalCustomerCode.Location = new System.Drawing.Point(311, 54);
            this.txtFinalCustomerCode.MaxLength = 16;
            this.txtFinalCustomerCode.Name = "txtFinalCustomerCode";
            this.txtFinalCustomerCode.ReadOnly = true;
            this.txtFinalCustomerCode.Size = new System.Drawing.Size(137, 20);
            this.txtFinalCustomerCode.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.DimGray;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Yellow;
            this.label9.Location = new System.Drawing.Point(261, 55);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 19);
            this.label9.TabIndex = 14;
            this.label9.Text = "Code  :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Location = new System.Drawing.Point(261, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(187, 1);
            this.label8.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.DarkRed;
            this.label7.Location = new System.Drawing.Point(259, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(137, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Final Sattlement Information";
            // 
            // txtISIN
            // 
            this.txtISIN.Location = new System.Drawing.Point(312, 105);
            this.txtISIN.MaxLength = 16;
            this.txtISIN.Name = "txtISIN";
            this.txtISIN.ReadOnly = true;
            this.txtISIN.Size = new System.Drawing.Size(136, 20);
            this.txtISIN.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.DimGray;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Yellow;
            this.label6.Location = new System.Drawing.Point(262, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 19);
            this.label6.TabIndex = 10;
            this.label6.Text = "ISIN   :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtBOId
            // 
            this.txtBOId.Location = new System.Drawing.Point(312, 80);
            this.txtBOId.MaxLength = 16;
            this.txtBOId.Name = "txtBOId";
            this.txtBOId.ReadOnly = true;
            this.txtBOId.Size = new System.Drawing.Size(136, 20);
            this.txtBOId.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.DimGray;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Yellow;
            this.label5.Location = new System.Drawing.Point(262, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 19);
            this.label5.TabIndex = 8;
            this.label5.Text = "BO ID :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTradeqty
            // 
            this.txtTradeqty.Location = new System.Drawing.Point(123, 108);
            this.txtTradeqty.MaxLength = 16;
            this.txtTradeqty.Name = "txtTradeqty";
            this.txtTradeqty.Size = new System.Drawing.Size(111, 20);
            this.txtTradeqty.TabIndex = 7;
            // 
            // ddlCompanyShortCode
            // 
            this.ddlCompanyShortCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlCompanyShortCode.FormattingEnabled = true;
            this.ddlCompanyShortCode.Location = new System.Drawing.Point(123, 79);
            this.ddlCompanyShortCode.Name = "ddlCompanyShortCode";
            this.ddlCompanyShortCode.Size = new System.Drawing.Size(111, 21);
            this.ddlCompanyShortCode.TabIndex = 6;
            this.ddlCompanyShortCode.SelectedIndexChanged += new System.EventHandler(this.ddlCompanyShortCode_SelectedIndexChanged);
            this.ddlCompanyShortCode.ValueMemberChanged += new System.EventHandler(this.ddlCompanyShortCode_ValueMemberChanged);
            // 
            // txtCustomerCode
            // 
            this.txtCustomerCode.Location = new System.Drawing.Point(123, 54);
            this.txtCustomerCode.MaxLength = 16;
            this.txtCustomerCode.Name = "txtCustomerCode";
            this.txtCustomerCode.Size = new System.Drawing.Size(111, 20);
            this.txtCustomerCode.TabIndex = 5;
            this.txtCustomerCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCustomerCode_KeyDown);
            // 
            // dtpSattlementDate
            // 
            this.dtpSattlementDate.CustomFormat = "dd-MM-yyyy";
            this.dtpSattlementDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSattlementDate.Location = new System.Drawing.Point(123, 28);
            this.dtpSattlementDate.Name = "dtpSattlementDate";
            this.dtpSattlementDate.Size = new System.Drawing.Size(111, 20);
            this.dtpSattlementDate.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.DimGray;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Yellow;
            this.label4.Location = new System.Drawing.Point(15, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Trade Qty             :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.DimGray;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Yellow;
            this.label3.Location = new System.Drawing.Point(15, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Comp-Short-Code :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.DimGray;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Yellow;
            this.label2.Location = new System.Drawing.Point(15, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Customer Code     :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DimGray;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(15, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sattlement Date    :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.Enabled = false;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.Location = new System.Drawing.Point(174, 172);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(62, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.DarkRed;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.Location = new System.Drawing.Point(242, 172);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(59, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmAddPayinout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 202);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frmAddPayinout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Save New Sattlement";
            this.Load += new System.EventHandler(this.frmAddPayinout_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCustomerCode;
        private System.Windows.Forms.DateTimePicker dtpSattlementDate;
        private System.Windows.Forms.TextBox txtTradeqty;
        private System.Windows.Forms.ComboBox ddlCompanyShortCode;
        private System.Windows.Forms.TextBox txtISIN;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBOId;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtFinalCustomerCode;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
    }
}