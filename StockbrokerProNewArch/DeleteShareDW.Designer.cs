namespace StockbrokerProNewArch
{
    partial class DeleteShareDW
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeleteShareDW));
            GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory defaultGridFilterFactory1 = new GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.dtgShareDWSearchData = new System.Windows.Forms.DataGridView();
            this.dtRecievedDate = new System.Windows.Forms.DateTimePicker();
            this.btnGo = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.txtVoucherNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCustCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chbCustCode = new System.Windows.Forms.CheckBox();
            this.ChbRecievedDate = new System.Windows.Forms.CheckBox();
            this.chbVoucher = new System.Windows.Forms.CheckBox();
            this.chbDW = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ddlDepositWithdraw = new System.Windows.Forms.ComboBox();
            this.btnProcessShareDW = new System.Windows.Forms.Button();
            this.lblRecord = new System.Windows.Forms.Label();
            this.dataGridFilterExtender1 = new GridViewExtensions.DataGridFilterExtender(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgShareDWSearchData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFilterExtender1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnClose.Location = new System.Drawing.Point(556, 355);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 25);
            this.btnClose.TabIndex = 122;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(476, 355);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnDelete.Size = new System.Drawing.Size(78, 26);
            this.btnDelete.TabIndex = 121;
            this.btnDelete.TabStop = false;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.DimGray;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Chartreuse;
            this.label5.Location = new System.Drawing.Point(11, 63);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.label5.Size = new System.Drawing.Size(617, 23);
            this.label5.TabIndex = 120;
            this.label5.Text = "Share D/W ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtgShareDWSearchData
            // 
            this.dtgShareDWSearchData.AllowUserToAddRows = false;
            this.dtgShareDWSearchData.AllowUserToDeleteRows = false;
            this.dtgShareDWSearchData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgShareDWSearchData.BackgroundColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgShareDWSearchData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgShareDWSearchData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgShareDWSearchData.Location = new System.Drawing.Point(11, 106);
            this.dtgShareDWSearchData.MultiSelect = false;
            this.dtgShareDWSearchData.Name = "dtgShareDWSearchData";
            this.dtgShareDWSearchData.ReadOnly = true;
            this.dtgShareDWSearchData.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dtgShareDWSearchData.RowHeadersVisible = false;
            this.dtgShareDWSearchData.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dtgShareDWSearchData.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgShareDWSearchData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgShareDWSearchData.Size = new System.Drawing.Size(617, 243);
            this.dtgShareDWSearchData.TabIndex = 119;
            // 
            // dtRecievedDate
            // 
            this.dtRecievedDate.CustomFormat = "dd MMM yyyy";
            this.dtRecievedDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtRecievedDate.Location = new System.Drawing.Point(413, 38);
            this.dtRecievedDate.Name = "dtRecievedDate";
            this.dtRecievedDate.Size = new System.Drawing.Size(141, 20);
            this.dtRecievedDate.TabIndex = 0;
            this.dtRecievedDate.Value = new System.DateTime(2010, 9, 23, 0, 0, 0, 0);
            this.dtRecievedDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCustCode_KeyDown);
            // 
            // btnGo
            // 
            this.btnGo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGo.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnGo.Image = ((System.Drawing.Image)(resources.GetObject("btnGo.Image")));
            this.btnGo.Location = new System.Drawing.Point(561, 14);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(67, 44);
            this.btnGo.TabIndex = 114;
            this.btnGo.TabStop = false;
            this.btnGo.Text = "Search";
            this.btnGo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(98, 40);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(10, 13);
            this.label21.TabIndex = 138;
            this.label21.Text = ":";
            // 
            // txtVoucherNo
            // 
            this.txtVoucherNo.Location = new System.Drawing.Point(114, 36);
            this.txtVoucherNo.Name = "txtVoucherNo";
            this.txtVoucherNo.Size = new System.Drawing.Size(141, 20);
            this.txtVoucherNo.TabIndex = 137;
            this.txtVoucherNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCustCode_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(98, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 13);
            this.label1.TabIndex = 142;
            this.label1.Text = ":";
            // 
            // txtCustCode
            // 
            this.txtCustCode.Location = new System.Drawing.Point(114, 13);
            this.txtCustCode.Name = "txtCustCode";
            this.txtCustCode.Size = new System.Drawing.Size(141, 20);
            this.txtCustCode.TabIndex = 141;
            this.txtCustCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCustCode_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(397, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 13);
            this.label3.TabIndex = 144;
            this.label3.Text = ":";
            // 
            // chbCustCode
            // 
            this.chbCustCode.AutoSize = true;
            this.chbCustCode.ForeColor = System.Drawing.Color.Navy;
            this.chbCustCode.Location = new System.Drawing.Point(11, 15);
            this.chbCustCode.Name = "chbCustCode";
            this.chbCustCode.Size = new System.Drawing.Size(80, 17);
            this.chbCustCode.TabIndex = 145;
            this.chbCustCode.Text = "Client Code";
            this.chbCustCode.UseVisualStyleBackColor = true;
            this.chbCustCode.CheckedChanged += new System.EventHandler(this.chbCustCode_CheckedChanged);
            // 
            // ChbRecievedDate
            // 
            this.ChbRecievedDate.AutoSize = true;
            this.ChbRecievedDate.ForeColor = System.Drawing.Color.Navy;
            this.ChbRecievedDate.Location = new System.Drawing.Point(284, 37);
            this.ChbRecievedDate.Name = "ChbRecievedDate";
            this.ChbRecievedDate.Size = new System.Drawing.Size(98, 17);
            this.ChbRecievedDate.TabIndex = 146;
            this.ChbRecievedDate.Text = "Recieved Date";
            this.ChbRecievedDate.UseVisualStyleBackColor = true;
            this.ChbRecievedDate.CheckedChanged += new System.EventHandler(this.ChbRecievedDate_CheckedChanged);
            // 
            // chbVoucher
            // 
            this.chbVoucher.AutoSize = true;
            this.chbVoucher.ForeColor = System.Drawing.Color.Navy;
            this.chbVoucher.Location = new System.Drawing.Point(11, 40);
            this.chbVoucher.Name = "chbVoucher";
            this.chbVoucher.Size = new System.Drawing.Size(86, 17);
            this.chbVoucher.TabIndex = 147;
            this.chbVoucher.Text = "Voucher No.";
            this.chbVoucher.UseVisualStyleBackColor = true;
            this.chbVoucher.CheckedChanged += new System.EventHandler(this.chbVoucher_CheckedChanged);
            // 
            // chbDW
            // 
            this.chbDW.AutoSize = true;
            this.chbDW.ForeColor = System.Drawing.Color.Navy;
            this.chbDW.Location = new System.Drawing.Point(284, 15);
            this.chbDW.Name = "chbDW";
            this.chbDW.Size = new System.Drawing.Size(112, 17);
            this.chbDW.TabIndex = 148;
            this.chbDW.Text = "Deposit/Withdraw";
            this.chbDW.UseVisualStyleBackColor = true;
            this.chbDW.CheckedChanged += new System.EventHandler(this.chbDW_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(396, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 13);
            this.label2.TabIndex = 149;
            this.label2.Text = ":";
            // 
            // ddlDepositWithdraw
            // 
            this.ddlDepositWithdraw.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlDepositWithdraw.FormattingEnabled = true;
            this.ddlDepositWithdraw.Items.AddRange(new object[] {
            "Deposit",
            "Withdraw"});
            this.ddlDepositWithdraw.Location = new System.Drawing.Point(412, 14);
            this.ddlDepositWithdraw.Name = "ddlDepositWithdraw";
            this.ddlDepositWithdraw.Size = new System.Drawing.Size(141, 21);
            this.ddlDepositWithdraw.TabIndex = 150;
            this.ddlDepositWithdraw.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCustCode_KeyDown);
            // 
            // btnProcessShareDW
            // 
            this.btnProcessShareDW.Enabled = false;
            this.btnProcessShareDW.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcessShareDW.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnProcessShareDW.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProcessShareDW.Location = new System.Drawing.Point(399, 356);
            this.btnProcessShareDW.Name = "btnProcessShareDW";
            this.btnProcessShareDW.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnProcessShareDW.Size = new System.Drawing.Size(71, 25);
            this.btnProcessShareDW.TabIndex = 151;
            this.btnProcessShareDW.Text = "Process";
            this.btnProcessShareDW.UseVisualStyleBackColor = true;
            this.btnProcessShareDW.Click += new System.EventHandler(this.btnProcessShareDW_Click);
            // 
            // lblRecord
            // 
            this.lblRecord.BackColor = System.Drawing.Color.DimGray;
            this.lblRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecord.ForeColor = System.Drawing.Color.Chartreuse;
            this.lblRecord.Location = new System.Drawing.Point(515, 63);
            this.lblRecord.Name = "lblRecord";
            this.lblRecord.Size = new System.Drawing.Size(113, 23);
            this.lblRecord.TabIndex = 152;
            this.lblRecord.Text = "Total Record : 0";
            this.lblRecord.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dataGridFilterExtender1
            // 
            this.dataGridFilterExtender1.DataGridView = this.dtgShareDWSearchData;
            defaultGridFilterFactory1.CreateDistinctGridFilters = false;
            defaultGridFilterFactory1.DefaultGridFilterType = typeof(GridViewExtensions.GridFilters.TextGridFilter);
            defaultGridFilterFactory1.DefaultShowDateInBetweenOperator = false;
            defaultGridFilterFactory1.DefaultShowNumericInBetweenOperator = false;
            defaultGridFilterFactory1.HandleEnumerationTypes = true;
            defaultGridFilterFactory1.MaximumDistinctValues = 20;
            this.dataGridFilterExtender1.FilterFactory = defaultGridFilterFactory1;
            // 
            // DeleteShareDW
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 389);
            this.Controls.Add(this.lblRecord);
            this.Controls.Add(this.ddlDepositWithdraw);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnProcessShareDW);
            this.Controls.Add(this.chbDW);
            this.Controls.Add(this.chbVoucher);
            this.Controls.Add(this.ChbRecievedDate);
            this.Controls.Add(this.chbCustCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.dtRecievedDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCustCode);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.txtVoucherNo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dtgShareDWSearchData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "DeleteShareDW";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Delete Share D/W";
            this.Load += new System.EventHandler(this.DeleteShareDW_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgShareDWSearchData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFilterExtender1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dtgShareDWSearchData;
        private System.Windows.Forms.DateTimePicker dtRecievedDate;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtVoucherNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCustCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chbCustCode;
        private System.Windows.Forms.CheckBox ChbRecievedDate;
        private System.Windows.Forms.CheckBox chbVoucher;
        private System.Windows.Forms.CheckBox chbDW;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ddlDepositWithdraw;
        private System.Windows.Forms.Button btnProcessShareDW;
        private System.Windows.Forms.Label lblRecord;
        private GridViewExtensions.DataGridFilterExtender dataGridFilterExtender1;
    }
}