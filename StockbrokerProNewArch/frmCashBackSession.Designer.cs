namespace StockbrokerProNewArch
{
    partial class frmCashBackSession
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory defaultGridFilterFactory2 = new GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCashBackSession));
            this.dtpSession_Start_Date = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvCashBackSessionInfo = new System.Windows.Forms.DataGridView();
            this.dataGridFilterExtender1 = new GridViewExtensions.DataGridFilterExtender(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpSession_End_Date = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label97 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label96 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtSessionName = new System.Windows.Forms.TextBox();
            this.btnSaveBasicInfo = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpMonthSelector = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpYearSelector = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCashBackSessionInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFilterExtender1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpSession_Start_Date
            // 
            this.dtpSession_Start_Date.CustomFormat = "dd-MM-yyyy";
            this.dtpSession_Start_Date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSession_Start_Date.Location = new System.Drawing.Point(186, 94);
            this.dtpSession_Start_Date.Name = "dtpSession_Start_Date";
            this.dtpSession_Start_Date.Size = new System.Drawing.Size(84, 20);
            this.dtpSession_Start_Date.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(173, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(10, 13);
            this.label4.TabIndex = 79;
            this.label4.Text = ":";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Gray;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(11, 94);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label3.Size = new System.Drawing.Size(156, 20);
            this.label3.TabIndex = 78;
            this.label3.Text = "Session Start Date";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvCashBackSessionInfo
            // 
            this.dgvCashBackSessionInfo.AllowUserToAddRows = false;
            this.dgvCashBackSessionInfo.AllowUserToDeleteRows = false;
            this.dgvCashBackSessionInfo.AllowUserToResizeRows = false;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCashBackSessionInfo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle15;
            this.dgvCashBackSessionInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvCashBackSessionInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCashBackSessionInfo.DefaultCellStyle = dataGridViewCellStyle16;
            this.dgvCashBackSessionInfo.GridColor = System.Drawing.Color.LightGray;
            this.dgvCashBackSessionInfo.Location = new System.Drawing.Point(12, 250);
            this.dgvCashBackSessionInfo.MultiSelect = false;
            this.dgvCashBackSessionInfo.Name = "dgvCashBackSessionInfo";
            this.dgvCashBackSessionInfo.ReadOnly = true;
            this.dgvCashBackSessionInfo.RowHeadersVisible = false;
            this.dgvCashBackSessionInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCashBackSessionInfo.Size = new System.Drawing.Size(460, 174);
            this.dgvCashBackSessionInfo.TabIndex = 21;
            this.dgvCashBackSessionInfo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCashBackSessionInfo_CellClick);
            this.dgvCashBackSessionInfo.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvCashBackSessionInfo_DataBindingComplete);
            this.dgvCashBackSessionInfo.SelectionChanged += new System.EventHandler(this.dgvCashBackSessionInfo_SelectionChanged);
            // 
            // dataGridFilterExtender1
            // 
            this.dataGridFilterExtender1.DataGridView = this.dgvCashBackSessionInfo;
            defaultGridFilterFactory2.CreateDistinctGridFilters = false;
            defaultGridFilterFactory2.DefaultGridFilterType = typeof(GridViewExtensions.GridFilters.TextGridFilter);
            defaultGridFilterFactory2.DefaultShowDateInBetweenOperator = false;
            defaultGridFilterFactory2.DefaultShowNumericInBetweenOperator = false;
            defaultGridFilterFactory2.HandleEnumerationTypes = true;
            defaultGridFilterFactory2.MaximumDistinctValues = 20;
            this.dataGridFilterExtender1.FilterFactory = defaultGridFilterFactory2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpYearSelector);
            this.groupBox1.Controls.Add(this.dtpMonthSelector);
            this.groupBox1.Controls.Add(this.dtpSession_End_Date);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.dtpSession_Start_Date);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtRemarks);
            this.groupBox1.Controls.Add(this.label26);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label97);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label96);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Controls.Add(this.txtSessionName);
            this.groupBox1.Location = new System.Drawing.Point(27, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(427, 186);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cashback Session";
            // 
            // dtpSession_End_Date
            // 
            this.dtpSession_End_Date.CustomFormat = "dd-MM-yyyy";
            this.dtpSession_End_Date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSession_End_Date.Location = new System.Drawing.Point(186, 120);
            this.dtpSession_End_Date.Name = "dtpSession_End_Date";
            this.dtpSession_End_Date.Size = new System.Drawing.Size(84, 20);
            this.dtpSession_End_Date.TabIndex = 80;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(173, 123);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(10, 13);
            this.label8.TabIndex = 82;
            this.label8.Text = ":";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Gray;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(11, 120);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label7.Size = new System.Drawing.Size(156, 20);
            this.label7.TabIndex = 81;
            this.label7.Text = "Session End Date";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(186, 146);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(195, 20);
            this.txtRemarks.TabIndex = 3;
            // 
            // label26
            // 
            this.label26.BackColor = System.Drawing.Color.Gray;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.White;
            this.label26.Location = new System.Drawing.Point(11, 145);
            this.label26.Name = "label26";
            this.label26.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label26.Size = new System.Drawing.Size(156, 20);
            this.label26.TabIndex = 72;
            this.label26.Text = "Remarks";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(172, 150);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(10, 13);
            this.label13.TabIndex = 50;
            this.label13.Text = ":";
            // 
            // label97
            // 
            this.label97.AutoSize = true;
            this.label97.Location = new System.Drawing.Point(173, 44);
            this.label97.Name = "label97";
            this.label97.Size = new System.Drawing.Size(10, 13);
            this.label97.TabIndex = 57;
            this.label97.Text = ":";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(173, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 13);
            this.label2.TabIndex = 58;
            this.label2.Text = ":";
            // 
            // label96
            // 
            this.label96.BackColor = System.Drawing.Color.Gray;
            this.label96.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label96.ForeColor = System.Drawing.Color.White;
            this.label96.Location = new System.Drawing.Point(11, 41);
            this.label96.Name = "label96";
            this.label96.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label96.Size = new System.Drawing.Size(156, 20);
            this.label96.TabIndex = 54;
            this.label96.Text = "Description";
            this.label96.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Gray;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(11, 17);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label1.Size = new System.Drawing.Size(156, 20);
            this.label1.TabIndex = 55;
            this.label1.Text = "Session Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(186, 42);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(235, 20);
            this.txtDescription.TabIndex = 0;
            // 
            // txtSessionName
            // 
            this.txtSessionName.Location = new System.Drawing.Point(186, 17);
            this.txtSessionName.Name = "txtSessionName";
            this.txtSessionName.Size = new System.Drawing.Size(235, 20);
            this.txtSessionName.TabIndex = 0;
            // 
            // btnSaveBasicInfo
            // 
            this.btnSaveBasicInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveBasicInfo.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnSaveBasicInfo.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveBasicInfo.Image")));
            this.btnSaveBasicInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveBasicInfo.Location = new System.Drawing.Point(246, 204);
            this.btnSaveBasicInfo.Name = "btnSaveBasicInfo";
            this.btnSaveBasicInfo.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnSaveBasicInfo.Size = new System.Drawing.Size(68, 25);
            this.btnSaveBasicInfo.TabIndex = 15;
            this.btnSaveBasicInfo.TabStop = false;
            this.btnSaveBasicInfo.Text = "Save";
            this.btnSaveBasicInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveBasicInfo.UseVisualStyleBackColor = true;
            this.btnSaveBasicInfo.Click += new System.EventHandler(this.btnSaveBasicInfo_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(330, 204);
            this.btnClose.Name = "btnClose";
            this.btnClose.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnClose.Size = new System.Drawing.Size(69, 25);
            this.btnClose.TabIndex = 19;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnDelete.Image = global::StockbrokerProNewArch.Properties.Resources.Close_2_icon;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(327, 430);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnDelete.Size = new System.Drawing.Size(145, 25);
            this.btnDelete.TabIndex = 16;
            this.btnDelete.TabStop = false;
            this.btnDelete.Text = "Cancel Session";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Gray;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(11, 67);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label6.Size = new System.Drawing.Size(156, 20);
            this.label6.TabIndex = 54;
            this.label6.Text = "Month Year Selector";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(173, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(10, 13);
            this.label5.TabIndex = 57;
            this.label5.Text = ":";
            // 
            // dtpMonthSelector
            // 
            this.dtpMonthSelector.CustomFormat = "MMM";
            this.dtpMonthSelector.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMonthSelector.Location = new System.Drawing.Point(243, 68);
            this.dtpMonthSelector.Name = "dtpMonthSelector";
            this.dtpMonthSelector.ShowUpDown = true;
            this.dtpMonthSelector.Size = new System.Drawing.Size(56, 20);
            this.dtpMonthSelector.TabIndex = 83;
            this.dtpMonthSelector.ValueChanged += new System.EventHandler(this.dtpMonthSelector_ValueChanged);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Gray;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(186, 68);
            this.label9.Name = "label9";
            this.label9.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label9.Size = new System.Drawing.Size(51, 20);
            this.label9.TabIndex = 54;
            this.label9.Text = "Month ";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Gray;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(312, 68);
            this.label10.Name = "label10";
            this.label10.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label10.Size = new System.Drawing.Size(39, 20);
            this.label10.TabIndex = 54;
            this.label10.Text = "Year";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpYearSelector
            // 
            this.dtpYearSelector.CustomFormat = "yyyy";
            this.dtpYearSelector.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpYearSelector.Location = new System.Drawing.Point(357, 68);
            this.dtpYearSelector.Name = "dtpYearSelector";
            this.dtpYearSelector.ShowUpDown = true;
            this.dtpYearSelector.Size = new System.Drawing.Size(56, 20);
            this.dtpYearSelector.TabIndex = 83;
            this.dtpYearSelector.ValueChanged += new System.EventHandler(this.dtpYearSelector_ValueChanged);
            // 
            // frmCashBackSession
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 458);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvCashBackSessionInfo);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSaveBasicInfo);
            this.Controls.Add(this.btnClose);
            this.MaximizeBox = false;
            this.Name = "frmCashBackSession";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cash Back Session";
            this.Load += new System.EventHandler(this.frmCashBackSession_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCashBackSessionInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFilterExtender1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpSession_Start_Date;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvCashBackSessionInfo;
        private GridViewExtensions.DataGridFilterExtender dataGridFilterExtender1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label97;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label96;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSessionName;
        private System.Windows.Forms.Button btnSaveBasicInfo;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DateTimePicker dtpSession_End_Date;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpYearSelector;
        private System.Windows.Forms.DateTimePicker dtpMonthSelector;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
    }
}