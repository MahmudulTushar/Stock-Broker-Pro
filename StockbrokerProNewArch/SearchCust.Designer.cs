namespace StockbrokerProNewArch
{
    partial class SearchCust
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtgCustInfo = new System.Windows.Forms.DataGridView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBankName = new System.Windows.Forms.TextBox();
            this.chbBankName = new System.Windows.Forms.CheckBox();
            this.chbAll = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.txtBankAccNo = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtFatherName = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.chbBankAccNo = new System.Windows.Forms.CheckBox();
            this.chbMobile = new System.Windows.Forms.CheckBox();
            this.chbDate = new System.Windows.Forms.CheckBox();
            this.chbAddress = new System.Windows.Forms.CheckBox();
            this.chbFatherName = new System.Windows.Forms.CheckBox();
            this.chbName = new System.Windows.Forms.CheckBox();
            this.lblSearchResult = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCustInfo)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgCustInfo
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgCustInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgCustInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCustInfo.Location = new System.Drawing.Point(12, 204);
            this.dtgCustInfo.Name = "dtgCustInfo";
            this.dtgCustInfo.RowHeadersVisible = false;
            this.dtgCustInfo.Size = new System.Drawing.Size(695, 287);
            this.dtgCustInfo.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(524, 147);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnSearch.Size = new System.Drawing.Size(90, 25);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(617, 147);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnCancel.Size = new System.Drawing.Size(90, 25);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtBankName);
            this.groupBox1.Controls.Add(this.chbBankName);
            this.groupBox1.Controls.Add(this.chbAll);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtTo);
            this.groupBox1.Controls.Add(this.dtFrom);
            this.groupBox1.Controls.Add(this.txtMobile);
            this.groupBox1.Controls.Add(this.txtBankAccNo);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.txtFatherName);
            this.groupBox1.Controls.Add(this.txtAddress);
            this.groupBox1.Controls.Add(this.chbBankAccNo);
            this.groupBox1.Controls.Add(this.chbMobile);
            this.groupBox1.Controls.Add(this.chbDate);
            this.groupBox1.Controls.Add(this.chbAddress);
            this.groupBox1.Controls.Add(this.chbFatherName);
            this.groupBox1.Controls.Add(this.chbName);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(695, 129);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Criteria";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Navy;
            this.label7.Location = new System.Drawing.Point(496, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(10, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = ":";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Navy;
            this.label6.Location = new System.Drawing.Point(496, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(10, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = ":";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Navy;
            this.label5.Location = new System.Drawing.Point(496, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(10, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = ":";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Navy;
            this.label9.Location = new System.Drawing.Point(155, 94);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(10, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = ":";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(155, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(10, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = ":";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(155, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = ":";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(155, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = ":";
            // 
            // txtBankName
            // 
            this.txtBankName.Location = new System.Drawing.Point(512, 40);
            this.txtBankName.Name = "txtBankName";
            this.txtBankName.Size = new System.Drawing.Size(162, 20);
            this.txtBankName.TabIndex = 39;
            // 
            // chbBankName
            // 
            this.chbBankName.AutoSize = true;
            this.chbBankName.ForeColor = System.Drawing.Color.Navy;
            this.chbBankName.Location = new System.Drawing.Point(371, 41);
            this.chbBankName.Name = "chbBankName";
            this.chbBankName.Size = new System.Drawing.Size(97, 17);
            this.chbBankName.TabIndex = 38;
            this.chbBankName.Text = "By Bank Name";
            this.chbBankName.UseVisualStyleBackColor = true;
            this.chbBankName.CheckedChanged += new System.EventHandler(this.chbBankName_CheckedChanged);
            // 
            // chbAll
            // 
            this.chbAll.AutoSize = true;
            this.chbAll.ForeColor = System.Drawing.Color.Navy;
            this.chbAll.Location = new System.Drawing.Point(591, 95);
            this.chbAll.Name = "chbAll";
            this.chbAll.Size = new System.Drawing.Size(70, 17);
            this.chbAll.TabIndex = 37;
            this.chbAll.Text = "Select All";
            this.chbAll.UseVisualStyleBackColor = true;
            this.chbAll.CheckedChanged += new System.EventHandler(this.chbAll_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(271, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 36;
            this.label1.Text = "To";
            // 
            // dtTo
            // 
            this.dtTo.CustomFormat = "dd/MM/yyyy";
            this.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTo.Location = new System.Drawing.Point(297, 90);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(96, 20);
            this.dtTo.TabIndex = 35;
            // 
            // dtFrom
            // 
            this.dtFrom.CustomFormat = "dd/MM/yyyy";
            this.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFrom.Location = new System.Drawing.Point(171, 90);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(94, 20);
            this.dtFrom.TabIndex = 34;
            // 
            // txtMobile
            // 
            this.txtMobile.Location = new System.Drawing.Point(512, 16);
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(162, 20);
            this.txtMobile.TabIndex = 33;
            // 
            // txtBankAccNo
            // 
            this.txtBankAccNo.Location = new System.Drawing.Point(512, 64);
            this.txtBankAccNo.Name = "txtBankAccNo";
            this.txtBankAccNo.Size = new System.Drawing.Size(162, 20);
            this.txtBankAccNo.TabIndex = 32;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(171, 17);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(162, 20);
            this.txtName.TabIndex = 31;
            // 
            // txtFatherName
            // 
            this.txtFatherName.Location = new System.Drawing.Point(171, 41);
            this.txtFatherName.Name = "txtFatherName";
            this.txtFatherName.Size = new System.Drawing.Size(162, 20);
            this.txtFatherName.TabIndex = 30;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(171, 65);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(162, 20);
            this.txtAddress.TabIndex = 29;
            // 
            // chbBankAccNo
            // 
            this.chbBankAccNo.AutoSize = true;
            this.chbBankAccNo.ForeColor = System.Drawing.Color.Navy;
            this.chbBankAccNo.Location = new System.Drawing.Point(371, 64);
            this.chbBankAccNo.Name = "chbBankAccNo";
            this.chbBankAccNo.Size = new System.Drawing.Size(108, 17);
            this.chbBankAccNo.TabIndex = 28;
            this.chbBankAccNo.Text = "By Bank Acc No.";
            this.chbBankAccNo.UseVisualStyleBackColor = true;
            this.chbBankAccNo.CheckedChanged += new System.EventHandler(this.chbBankAccNo_CheckedChanged);
            // 
            // chbMobile
            // 
            this.chbMobile.AutoSize = true;
            this.chbMobile.ForeColor = System.Drawing.Color.Navy;
            this.chbMobile.Location = new System.Drawing.Point(371, 19);
            this.chbMobile.Name = "chbMobile";
            this.chbMobile.Size = new System.Drawing.Size(72, 17);
            this.chbMobile.TabIndex = 27;
            this.chbMobile.Text = "By Mobile";
            this.chbMobile.UseVisualStyleBackColor = true;
            this.chbMobile.CheckedChanged += new System.EventHandler(this.chbMobile_CheckedChanged);
            // 
            // chbDate
            // 
            this.chbDate.AutoSize = true;
            this.chbDate.ForeColor = System.Drawing.Color.Navy;
            this.chbDate.Location = new System.Drawing.Point(21, 93);
            this.chbDate.Name = "chbDate";
            this.chbDate.Size = new System.Drawing.Size(140, 17);
            this.chbDate.TabIndex = 26;
            this.chbDate.Text = "By Customer Open Date";
            this.chbDate.UseVisualStyleBackColor = true;
            this.chbDate.CheckedChanged += new System.EventHandler(this.chbDate_CheckedChanged);
            // 
            // chbAddress
            // 
            this.chbAddress.AutoSize = true;
            this.chbAddress.ForeColor = System.Drawing.Color.Navy;
            this.chbAddress.Location = new System.Drawing.Point(21, 66);
            this.chbAddress.Name = "chbAddress";
            this.chbAddress.Size = new System.Drawing.Size(79, 17);
            this.chbAddress.TabIndex = 25;
            this.chbAddress.Text = "By Address";
            this.chbAddress.UseVisualStyleBackColor = true;
            this.chbAddress.CheckedChanged += new System.EventHandler(this.chbAddress_CheckedChanged);
            // 
            // chbFatherName
            // 
            this.chbFatherName.AutoSize = true;
            this.chbFatherName.ForeColor = System.Drawing.Color.Navy;
            this.chbFatherName.Location = new System.Drawing.Point(21, 42);
            this.chbFatherName.Name = "chbFatherName";
            this.chbFatherName.Size = new System.Drawing.Size(109, 17);
            this.chbFatherName.TabIndex = 24;
            this.chbFatherName.Text = "By Father\'s Name";
            this.chbFatherName.UseVisualStyleBackColor = true;
            this.chbFatherName.CheckedChanged += new System.EventHandler(this.chbFatherName_CheckedChanged);
            // 
            // chbName
            // 
            this.chbName.AutoSize = true;
            this.chbName.ForeColor = System.Drawing.Color.Navy;
            this.chbName.Location = new System.Drawing.Point(21, 19);
            this.chbName.Name = "chbName";
            this.chbName.Size = new System.Drawing.Size(69, 17);
            this.chbName.TabIndex = 23;
            this.chbName.Text = "By Name";
            this.chbName.UseVisualStyleBackColor = true;
            this.chbName.CheckedChanged += new System.EventHandler(this.chbName_CheckedChanged);
            // 
            // lblSearchResult
            // 
            this.lblSearchResult.BackColor = System.Drawing.Color.DimGray;
            this.lblSearchResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchResult.ForeColor = System.Drawing.Color.Chartreuse;
            this.lblSearchResult.Location = new System.Drawing.Point(12, 181);
            this.lblSearchResult.Name = "lblSearchResult";
            this.lblSearchResult.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblSearchResult.Size = new System.Drawing.Size(695, 23);
            this.lblSearchResult.TabIndex = 107;
            this.lblSearchResult.Text = "Search Result";
            this.lblSearchResult.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SearchCust
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 503);
            this.Controls.Add(this.lblSearchResult);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dtgCustInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "SearchCust";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Search Customer";
            this.Load += new System.EventHandler(this.SearchCust_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgCustInfo)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgCustInfo;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.TextBox txtMobile;
        private System.Windows.Forms.TextBox txtBankAccNo;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtFatherName;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.CheckBox chbBankAccNo;
        private System.Windows.Forms.CheckBox chbMobile;
        private System.Windows.Forms.CheckBox chbDate;
        private System.Windows.Forms.CheckBox chbAddress;
        private System.Windows.Forms.CheckBox chbFatherName;
        private System.Windows.Forms.CheckBox chbName;
        private System.Windows.Forms.CheckBox chbAll;
        private System.Windows.Forms.TextBox txtBankName;
        private System.Windows.Forms.CheckBox chbBankName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblSearchResult;
        private System.Windows.Forms.Label label9;
    }
}