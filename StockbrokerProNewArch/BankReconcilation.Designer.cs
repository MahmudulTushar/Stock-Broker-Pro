namespace StockbrokerProNewArch
{
    partial class BankReconcilation
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory defaultGridFilterFactory1 = new GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory();
            this.dtgBankData = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStartImport = new System.Windows.Forms.Button();
            this.btnFileLocationBrowser = new System.Windows.Forms.Button();
            this.txtFileLocation = new System.Windows.Forms.TextBox();
            this.ofdFileOpen = new System.Windows.Forms.OpenFileDialog();
            this.btnReport = new System.Windows.Forms.Button();
            this.dgvErrors = new System.Windows.Forms.DataGridView();
            this.sn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ErrorDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbProText = new System.Windows.Forms.Label();
            this.progress = new System.Windows.Forms.ProgressBar();
            this.err = new System.Windows.Forms.ErrorProvider(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridFilterExtender1 = new GridViewExtensions.DataGridFilterExtender(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBankData)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvErrors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.err)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFilterExtender1)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgBankData
            // 
            this.dtgBankData.AllowUserToAddRows = false;
            this.dtgBankData.AllowUserToDeleteRows = false;
            this.dtgBankData.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Navy;
            this.dtgBankData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgBankData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtgBankData.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dtgBankData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Green;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgBankData.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtgBankData.GridColor = System.Drawing.Color.Gainsboro;
            this.dtgBankData.Location = new System.Drawing.Point(13, 272);
            this.dtgBankData.MultiSelect = false;
            this.dtgBankData.Name = "dtgBankData";
            this.dtgBankData.ReadOnly = true;
            this.dtgBankData.RowHeadersVisible = false;
            this.dtgBankData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgBankData.Size = new System.Drawing.Size(557, 160);
            this.dtgBankData.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnStartImport);
            this.groupBox1.Controls.Add(this.btnFileLocationBrowser);
            this.groupBox1.Controls.Add(this.txtFileLocation);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(16, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(554, 53);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Bank Pdf File";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(105, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = ":";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(19, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "File Location";
            // 
            // btnStartImport
            // 
            this.btnStartImport.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartImport.ForeColor = System.Drawing.Color.Black;
            this.btnStartImport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStartImport.Location = new System.Drawing.Point(435, 19);
            this.btnStartImport.Name = "btnStartImport";
            this.btnStartImport.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnStartImport.Size = new System.Drawing.Size(104, 25);
            this.btnStartImport.TabIndex = 1;
            this.btnStartImport.Text = "Start Import";
            this.btnStartImport.UseVisualStyleBackColor = true;
            this.btnStartImport.Click += new System.EventHandler(this.btnStartImport_Click);
            // 
            // btnFileLocationBrowser
            // 
            this.btnFileLocationBrowser.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFileLocationBrowser.ForeColor = System.Drawing.Color.Black;
            this.btnFileLocationBrowser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFileLocationBrowser.Location = new System.Drawing.Point(395, 19);
            this.btnFileLocationBrowser.Name = "btnFileLocationBrowser";
            this.btnFileLocationBrowser.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnFileLocationBrowser.Size = new System.Drawing.Size(34, 25);
            this.btnFileLocationBrowser.TabIndex = 0;
            this.btnFileLocationBrowser.Text = "...";
            this.btnFileLocationBrowser.UseVisualStyleBackColor = true;
            this.btnFileLocationBrowser.Click += new System.EventHandler(this.btnFileLocationBrowser_Click);
            // 
            // txtFileLocation
            // 
            this.txtFileLocation.Location = new System.Drawing.Point(122, 22);
            this.txtFileLocation.Name = "txtFileLocation";
            this.txtFileLocation.Size = new System.Drawing.Size(267, 21);
            this.txtFileLocation.TabIndex = 0;
            // 
            // ofdFileOpen
            // 
            this.ofdFileOpen.FileName = ".pdf";
            this.ofdFileOpen.Filter = "pdf files (*.pdf)|*.pdf";
            // 
            // btnReport
            // 
            this.btnReport.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.ForeColor = System.Drawing.Color.Black;
            this.btnReport.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReport.Location = new System.Drawing.Point(464, 438);
            this.btnReport.Name = "btnReport";
            this.btnReport.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnReport.Size = new System.Drawing.Size(109, 25);
            this.btnReport.TabIndex = 5;
            this.btnReport.Text = "Cheque Missmatch";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // dgvErrors
            // 
            this.dgvErrors.AllowUserToAddRows = false;
            this.dgvErrors.AllowUserToDeleteRows = false;
            this.dgvErrors.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvErrors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvErrors.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sn,
            this.CustomerCode,
            this.ErrorDescription});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvErrors.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvErrors.Location = new System.Drawing.Point(13, 123);
            this.dgvErrors.MultiSelect = false;
            this.dgvErrors.Name = "dgvErrors";
            this.dgvErrors.RowHeadersVisible = false;
            this.dgvErrors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvErrors.Size = new System.Drawing.Size(557, 105);
            this.dgvErrors.TabIndex = 17;
            this.dgvErrors.TabStop = false;
            // 
            // sn
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            this.sn.DefaultCellStyle = dataGridViewCellStyle3;
            this.sn.Frozen = true;
            this.sn.HeaderText = "SN";
            this.sn.Name = "sn";
            this.sn.ReadOnly = true;
            this.sn.Width = 47;
            // 
            // CustomerCode
            // 
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.DarkGreen;
            this.CustomerCode.DefaultCellStyle = dataGridViewCellStyle4;
            this.CustomerCode.HeaderText = "Cheque No.";
            this.CustomerCode.Name = "CustomerCode";
            this.CustomerCode.ReadOnly = true;
            // 
            // ErrorDescription
            // 
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Red;
            this.ErrorDescription.DefaultCellStyle = dataGridViewCellStyle5;
            this.ErrorDescription.HeaderText = "Error Description";
            this.ErrorDescription.Name = "ErrorDescription";
            this.ErrorDescription.Width = 400;
            // 
            // lbProText
            // 
            this.lbProText.AutoSize = true;
            this.lbProText.ForeColor = System.Drawing.Color.DimGray;
            this.lbProText.Location = new System.Drawing.Point(13, 67);
            this.lbProText.Name = "lbProText";
            this.lbProText.Size = new System.Drawing.Size(65, 13);
            this.lbProText.TabIndex = 18;
            this.lbProText.Text = "No Progress";
            // 
            // progress
            // 
            this.progress.Location = new System.Drawing.Point(13, 87);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(557, 10);
            this.progress.TabIndex = 16;
            // 
            // err
            // 
            this.err.ContainerControl = this;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.Location = new System.Drawing.Point(349, 438);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.button1.Size = new System.Drawing.Size(109, 25);
            this.button1.TabIndex = 19;
            this.button1.Text = "Balance Missmatch";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridFilterExtender1
            // 
            this.dataGridFilterExtender1.DataGridView = this.dtgBankData;
            defaultGridFilterFactory1.CreateDistinctGridFilters = false;
            defaultGridFilterFactory1.DefaultGridFilterType = typeof(GridViewExtensions.GridFilters.TextGridFilter);
            defaultGridFilterFactory1.DefaultShowDateInBetweenOperator = false;
            defaultGridFilterFactory1.DefaultShowNumericInBetweenOperator = false;
            defaultGridFilterFactory1.HandleEnumerationTypes = true;
            defaultGridFilterFactory1.MaximumDistinctValues = 20;
            this.dataGridFilterExtender1.FilterFactory = defaultGridFilterFactory1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Reconcilation Error ";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(135, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(435, 1);
            this.label4.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(14, 235);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(154, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Reconcilation Information";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(173, 243);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(390, 1);
            this.label6.TabIndex = 24;
            // 
            // BankReconcilation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 469);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbProText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvErrors);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.progress);
            this.Controls.Add(this.dtgBankData);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "BankReconcilation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bank Reconcilation";
            this.Load += new System.EventHandler(this.BankReconcilation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgBankData)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvErrors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.err)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFilterExtender1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgBankData;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStartImport;
        private System.Windows.Forms.Button btnFileLocationBrowser;
        private System.Windows.Forms.TextBox txtFileLocation;
        private System.Windows.Forms.OpenFileDialog ofdFileOpen;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.DataGridView dgvErrors;
        private System.Windows.Forms.Label lbProText;
        private System.Windows.Forms.ProgressBar progress;
        private System.Windows.Forms.ErrorProvider err;
        private System.Windows.Forms.DataGridViewTextBoxColumn sn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ErrorDescription;
        private System.Windows.Forms.Button button1;
        private GridViewExtensions.DataGridFilterExtender dataGridFilterExtender1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
    }
}