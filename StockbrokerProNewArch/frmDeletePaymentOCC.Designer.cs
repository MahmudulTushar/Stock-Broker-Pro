namespace StockbrokerProNewArch
{
    partial class frmDeletePaymentOCC
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory defaultGridFilterFactory1 = new GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.cboPurpose = new System.Windows.Forms.ComboBox();
            this.dtpPaymentDate = new System.Windows.Forms.DateTimePicker();
            this.chbPurpose = new System.Windows.Forms.CheckBox();
            this.txtVoucherNo = new System.Windows.Forms.TextBox();
            this.ChbDate = new System.Windows.Forms.CheckBox();
            this.txtClientCode = new System.Windows.Forms.TextBox();
            this.chbVoucherNo = new System.Windows.Forms.CheckBox();
            this.chbClientCode = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtRejectedReason = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotalRecord = new System.Windows.Forms.Label();
            this.dgvPaymentOOcInfo = new System.Windows.Forms.DataGridView();
            this.btnDelete = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dgvExtension = new GridViewExtensions.DataGridFilterExtender(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaymentOOcInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExtension)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnGo);
            this.groupBox1.Controls.Add(this.cboPurpose);
            this.groupBox1.Controls.Add(this.dtpPaymentDate);
            this.groupBox1.Controls.Add(this.chbPurpose);
            this.groupBox1.Controls.Add(this.txtVoucherNo);
            this.groupBox1.Controls.Add(this.ChbDate);
            this.groupBox1.Controls.Add(this.txtClientCode);
            this.groupBox1.Controls.Add(this.chbVoucherNo);
            this.groupBox1.Controls.Add(this.chbClientCode);
            this.groupBox1.Location = new System.Drawing.Point(12, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(354, 156);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnGo
            // 
            this.btnGo.BackColor = System.Drawing.Color.Transparent;
            this.btnGo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGo.ForeColor = System.Drawing.Color.Black;
            this.btnGo.Location = new System.Drawing.Point(258, 126);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 7;
            this.btnGo.Text = "Search";
            this.btnGo.UseVisualStyleBackColor = false;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // cboPurpose
            // 
            this.cboPurpose.Enabled = false;
            this.cboPurpose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPurpose.ForeColor = System.Drawing.Color.Navy;
            this.cboPurpose.FormattingEnabled = true;
            this.cboPurpose.Location = new System.Drawing.Point(123, 99);
            this.cboPurpose.Name = "cboPurpose";
            this.cboPurpose.Size = new System.Drawing.Size(210, 21);
            this.cboPurpose.TabIndex = 1;
            // 
            // dtpPaymentDate
            // 
            this.dtpPaymentDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpPaymentDate.Enabled = false;
            this.dtpPaymentDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpPaymentDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPaymentDate.Location = new System.Drawing.Point(123, 73);
            this.dtpPaymentDate.Name = "dtpPaymentDate";
            this.dtpPaymentDate.Size = new System.Drawing.Size(210, 20);
            this.dtpPaymentDate.TabIndex = 5;
            // 
            // chbPurpose
            // 
            this.chbPurpose.AutoSize = true;
            this.chbPurpose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbPurpose.ForeColor = System.Drawing.Color.Navy;
            this.chbPurpose.Location = new System.Drawing.Point(12, 101);
            this.chbPurpose.Name = "chbPurpose";
            this.chbPurpose.Size = new System.Drawing.Size(104, 17);
            this.chbPurpose.TabIndex = 6;
            this.chbPurpose.Text = "Purpose       :";
            this.chbPurpose.UseVisualStyleBackColor = true;
            this.chbPurpose.CheckedChanged += new System.EventHandler(this.chbClientCode_CheckedChanged);
            // 
            // txtVoucherNo
            // 
            this.txtVoucherNo.Enabled = false;
            this.txtVoucherNo.Location = new System.Drawing.Point(123, 48);
            this.txtVoucherNo.Name = "txtVoucherNo";
            this.txtVoucherNo.Size = new System.Drawing.Size(210, 20);
            this.txtVoucherNo.TabIndex = 3;
            // 
            // ChbDate
            // 
            this.ChbDate.AutoSize = true;
            this.ChbDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChbDate.ForeColor = System.Drawing.Color.Navy;
            this.ChbDate.Location = new System.Drawing.Point(12, 76);
            this.ChbDate.Name = "ChbDate";
            this.ChbDate.Size = new System.Drawing.Size(105, 17);
            this.ChbDate.TabIndex = 4;
            this.ChbDate.Text = "Date            :";
            this.ChbDate.UseVisualStyleBackColor = true;
            this.ChbDate.CheckedChanged += new System.EventHandler(this.chbClientCode_CheckedChanged);
            // 
            // txtClientCode
            // 
            this.txtClientCode.Enabled = false;
            this.txtClientCode.Location = new System.Drawing.Point(123, 23);
            this.txtClientCode.Name = "txtClientCode";
            this.txtClientCode.Size = new System.Drawing.Size(210, 20);
            this.txtClientCode.TabIndex = 1;
            // 
            // chbVoucherNo
            // 
            this.chbVoucherNo.AutoSize = true;
            this.chbVoucherNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbVoucherNo.ForeColor = System.Drawing.Color.Navy;
            this.chbVoucherNo.Location = new System.Drawing.Point(12, 50);
            this.chbVoucherNo.Name = "chbVoucherNo";
            this.chbVoucherNo.Size = new System.Drawing.Size(105, 17);
            this.chbVoucherNo.TabIndex = 2;
            this.chbVoucherNo.Text = " Voucher No :";
            this.chbVoucherNo.UseVisualStyleBackColor = true;
            this.chbVoucherNo.CheckedChanged += new System.EventHandler(this.chbClientCode_CheckedChanged);
            // 
            // chbClientCode
            // 
            this.chbClientCode.AutoSize = true;
            this.chbClientCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbClientCode.ForeColor = System.Drawing.Color.Navy;
            this.chbClientCode.Location = new System.Drawing.Point(12, 25);
            this.chbClientCode.Name = "chbClientCode";
            this.chbClientCode.Size = new System.Drawing.Size(107, 17);
            this.chbClientCode.TabIndex = 0;
            this.chbClientCode.Text = "Client Code   :";
            this.chbClientCode.UseVisualStyleBackColor = true;
            this.chbClientCode.CheckedChanged += new System.EventHandler(this.chbClientCode_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtRejectedReason);
            this.groupBox2.Location = new System.Drawing.Point(382, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(320, 160);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Rejected Reason";
            // 
            // txtRejectedReason
            // 
            this.txtRejectedReason.BackColor = System.Drawing.Color.AliceBlue;
            this.txtRejectedReason.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRejectedReason.ForeColor = System.Drawing.Color.Navy;
            this.txtRejectedReason.Location = new System.Drawing.Point(18, 25);
            this.txtRejectedReason.Multiline = true;
            this.txtRejectedReason.Name = "txtRejectedReason";
            this.txtRejectedReason.ReadOnly = true;
            this.txtRejectedReason.Size = new System.Drawing.Size(281, 119);
            this.txtRejectedReason.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblTotalRecord);
            this.panel1.Location = new System.Drawing.Point(12, 173);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(690, 26);
            this.panel1.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(3, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "Payment OCC Overview";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotalRecord
            // 
            this.lblTotalRecord.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRecord.ForeColor = System.Drawing.Color.Black;
            this.lblTotalRecord.Location = new System.Drawing.Point(555, 2);
            this.lblTotalRecord.Name = "lblTotalRecord";
            this.lblTotalRecord.Size = new System.Drawing.Size(131, 20);
            this.lblTotalRecord.TabIndex = 2;
            this.lblTotalRecord.Text = "Total Record : 0";
            this.lblTotalRecord.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dgvPaymentOOcInfo
            // 
            this.dgvPaymentOOcInfo.AllowUserToAddRows = false;
            this.dgvPaymentOOcInfo.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dgvPaymentOOcInfo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPaymentOOcInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvPaymentOOcInfo.BackgroundColor = System.Drawing.Color.Silver;
            this.dgvPaymentOOcInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPaymentOOcInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPaymentOOcInfo.ColumnHeadersHeight = 26;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPaymentOOcInfo.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPaymentOOcInfo.GridColor = System.Drawing.Color.LightGray;
            this.dgvPaymentOOcInfo.Location = new System.Drawing.Point(12, 219);
            this.dgvPaymentOOcInfo.MultiSelect = false;
            this.dgvPaymentOOcInfo.Name = "dgvPaymentOOcInfo";
            this.dgvPaymentOOcInfo.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPaymentOOcInfo.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPaymentOOcInfo.RowHeadersVisible = false;
            this.dgvPaymentOOcInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPaymentOOcInfo.Size = new System.Drawing.Size(690, 189);
            this.dgvPaymentOOcInfo.TabIndex = 7;
            this.dgvPaymentOOcInfo.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvPaymentOOcInfo_CellMouseClick);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.Black;
            this.btnDelete.Location = new System.Drawing.Point(544, 410);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(78, 23);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(628, 410);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvExtension
            // 
            this.dgvExtension.DataGridView = this.dgvPaymentOOcInfo;
            defaultGridFilterFactory1.CreateDistinctGridFilters = false;
            defaultGridFilterFactory1.DefaultGridFilterType = typeof(GridViewExtensions.GridFilters.TextGridFilter);
            defaultGridFilterFactory1.DefaultShowDateInBetweenOperator = false;
            defaultGridFilterFactory1.DefaultShowNumericInBetweenOperator = false;
            defaultGridFilterFactory1.HandleEnumerationTypes = true;
            defaultGridFilterFactory1.MaximumDistinctValues = 20;
            this.dgvExtension.FilterFactory = defaultGridFilterFactory1;
            // 
            // frmDeletePaymentOCC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 435);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvPaymentOOcInfo);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frmDeletePaymentOCC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Delete Other Credits & Charges || Stock Broker Pro";
            this.Load += new System.EventHandler(this.frmDeletePaymentOCC_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaymentOOcInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExtension)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtClientCode;
        private System.Windows.Forms.CheckBox chbClientCode;
        private System.Windows.Forms.TextBox txtVoucherNo;
        private System.Windows.Forms.CheckBox chbVoucherNo;
        private System.Windows.Forms.CheckBox ChbDate;
        private System.Windows.Forms.DateTimePicker dtpPaymentDate;
        private System.Windows.Forms.ComboBox cboPurpose;
        private System.Windows.Forms.CheckBox chbPurpose;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtRejectedReason;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTotalRecord;
        private System.Windows.Forms.DataGridView dgvPaymentOOcInfo;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button button1;
        private GridViewExtensions.DataGridFilterExtender dgvExtension;
        private System.Windows.Forms.Label label1;
    }
}