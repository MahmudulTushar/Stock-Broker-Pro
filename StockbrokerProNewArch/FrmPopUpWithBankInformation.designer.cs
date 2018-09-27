namespace StockbrokerProNewArch
{
    partial class FrmPopUpWithBankInformation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPopUpWithBankInformation));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtChequeNo = new System.Windows.Forms.TextBox();
            this.dtpPayDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.clCmbBankNameForWithdraw = new URT.ComboBox.ColumnCombo();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(7, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bank Name :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(9, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Cheque No :";
            // 
            // txtChequeNo
            // 
            this.txtChequeNo.Location = new System.Drawing.Point(82, 47);
            this.txtChequeNo.Name = "txtChequeNo";
            this.txtChequeNo.Size = new System.Drawing.Size(269, 20);
            this.txtChequeNo.TabIndex = 1;
            this.txtChequeNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtChequeNo_KeyPress);
            // 
            // dtpPayDate
            // 
            this.dtpPayDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPayDate.Location = new System.Drawing.Point(420, 19);
            this.dtpPayDate.Name = "dtpPayDate";
            this.dtpPayDate.Size = new System.Drawing.Size(103, 20);
            this.dtpPayDate.TabIndex = 2;
            this.dtpPayDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpPayDate_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(357, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Pay Date :";
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(380, 94);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "    Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(461, 94);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "     Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.groupBox1.Controls.Add(this.clCmbBankNameForWithdraw);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dtpPayDate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtChequeNo);
            this.groupBox1.ForeColor = System.Drawing.Color.Red;
            this.groupBox1.Location = new System.Drawing.Point(8, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(528, 79);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cheque Information";
            // 
            // clCmbBankNameForWithdraw
            // 
            this.clCmbBankNameForWithdraw.BackColor = System.Drawing.SystemColors.Window;
            this.clCmbBankNameForWithdraw.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.clCmbBankNameForWithdraw.DropDownWidth = 17;
            this.clCmbBankNameForWithdraw.Font = new System.Drawing.Font("Verdana", 9F);
            this.clCmbBankNameForWithdraw.Location = new System.Drawing.Point(82, 16);
            this.clCmbBankNameForWithdraw.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.clCmbBankNameForWithdraw.Name = "clCmbBankNameForWithdraw";
            this.clCmbBankNameForWithdraw.Size = new System.Drawing.Size(269, 23);
            this.clCmbBankNameForWithdraw.TabIndex = 82;
            this.clCmbBankNameForWithdraw.ViewColumn = 0;
            this.clCmbBankNameForWithdraw.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.clCmbBankNameForWithdraw_KeyPress);
            // 
            // FrmPopUpWithBankInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 126);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmPopUpWithBankInformation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cheque Information For Head Wise Withdrawal";
            this.Load += new System.EventHandler(this.FrmPopUpWithBankInformation_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtChequeNo;
        private System.Windows.Forms.DateTimePicker dtpPayDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private URT.ComboBox.ColumnCombo clCmbBankNameForWithdraw;
    }
}