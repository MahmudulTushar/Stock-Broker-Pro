namespace StockbrokerProNewArch
{
    partial class frmProcess_List
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
            GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory defaultGridFilterFactory1 = new GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProcess_List));
            this.dtpEntry_Date = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label97 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label96 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtProcessID = new System.Windows.Forms.TextBox();
            this.txtProcessName = new System.Windows.Forms.TextBox();
            this.dgvCashBackSessionInfo = new System.Windows.Forms.DataGridView();
            this.dataGridFilterExtender1 = new GridViewExtensions.DataGridFilterExtender(this.components);
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnSaveBasicInfo = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnResetBasicInfo = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCashBackSessionInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFilterExtender1)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpEntry_Date
            // 
            this.dtpEntry_Date.CustomFormat = "dd-MM-yyyy";
            this.dtpEntry_Date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEntry_Date.Location = new System.Drawing.Point(202, 95);
            this.dtpEntry_Date.Name = "dtpEntry_Date";
            this.dtpEntry_Date.Size = new System.Drawing.Size(196, 20);
            this.dtpEntry_Date.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(189, 99);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(10, 13);
            this.label10.TabIndex = 79;
            this.label10.Text = ":";
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Gray;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(27, 95);
            this.label9.Name = "label9";
            this.label9.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label9.Size = new System.Drawing.Size(156, 20);
            this.label9.TabIndex = 78;
            this.label9.Text = "Entry Date";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnClose.Image = global::StockbrokerProNewArch.Properties.Resources.Close_2_icon;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(347, 152);
            this.btnClose.Name = "btnClose";
            this.btnClose.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnClose.Size = new System.Drawing.Size(78, 25);
            this.btnClose.TabIndex = 26;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpEntry_Date);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label97);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label96);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Controls.Add(this.txtProcessID);
            this.groupBox1.Controls.Add(this.txtProcessName);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(413, 134);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Process List Info";
            // 
            // label97
            // 
            this.label97.AutoSize = true;
            this.label97.Location = new System.Drawing.Point(190, 74);
            this.label97.Name = "label97";
            this.label97.Size = new System.Drawing.Size(10, 13);
            this.label97.TabIndex = 57;
            this.label97.Text = ":";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(190, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(10, 13);
            this.label4.TabIndex = 58;
            this.label4.Text = ":";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(190, 50);
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
            this.label96.Location = new System.Drawing.Point(28, 71);
            this.label96.Name = "label96";
            this.label96.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label96.Size = new System.Drawing.Size(156, 20);
            this.label96.TabIndex = 54;
            this.label96.Text = "Description";
            this.label96.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Gray;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(28, 21);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label3.Size = new System.Drawing.Size(156, 20);
            this.label3.TabIndex = 55;
            this.label3.Text = "Process ID";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Gray;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(28, 47);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label1.Size = new System.Drawing.Size(156, 20);
            this.label1.TabIndex = 55;
            this.label1.Text = "Process Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(203, 72);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(196, 20);
            this.txtDescription.TabIndex = 0;
            // 
            // txtProcessID
            // 
            this.txtProcessID.Enabled = false;
            this.txtProcessID.Location = new System.Drawing.Point(203, 21);
            this.txtProcessID.Name = "txtProcessID";
            this.txtProcessID.Size = new System.Drawing.Size(196, 20);
            this.txtProcessID.TabIndex = 0;
            this.txtProcessID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProcessID_KeyDown);
            this.txtProcessID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProcessID_KeyPress);
            // 
            // txtProcessName
            // 
            this.txtProcessName.Location = new System.Drawing.Point(203, 47);
            this.txtProcessName.Name = "txtProcessName";
            this.txtProcessName.Size = new System.Drawing.Size(196, 20);
            this.txtProcessName.TabIndex = 0;
            // 
            // dgvCashBackSessionInfo
            // 
            this.dgvCashBackSessionInfo.AllowUserToAddRows = false;
            this.dgvCashBackSessionInfo.AllowUserToDeleteRows = false;
            this.dgvCashBackSessionInfo.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.dgvCashBackSessionInfo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCashBackSessionInfo.BackgroundColor = System.Drawing.Color.Gray;
            this.dgvCashBackSessionInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCashBackSessionInfo.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCashBackSessionInfo.GridColor = System.Drawing.Color.LightGray;
            this.dgvCashBackSessionInfo.Location = new System.Drawing.Point(12, 198);
            this.dgvCashBackSessionInfo.MultiSelect = false;
            this.dgvCashBackSessionInfo.Name = "dgvCashBackSessionInfo";
            this.dgvCashBackSessionInfo.ReadOnly = true;
            this.dgvCashBackSessionInfo.RowHeadersVisible = false;
            this.dgvCashBackSessionInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCashBackSessionInfo.Size = new System.Drawing.Size(413, 162);
            this.dgvCashBackSessionInfo.TabIndex = 28;
            this.dgvCashBackSessionInfo.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvCashBackSessionInfo_DataBindingComplete);
            this.dgvCashBackSessionInfo.SelectionChanged += new System.EventHandler(this.dgvCashBackSessionInfo_SelectionChanged);
            // 
            // dataGridFilterExtender1
            // 
            this.dataGridFilterExtender1.DataGridView = this.dgvCashBackSessionInfo;
            defaultGridFilterFactory1.CreateDistinctGridFilters = false;
            defaultGridFilterFactory1.DefaultGridFilterType = typeof(GridViewExtensions.GridFilters.TextGridFilter);
            defaultGridFilterFactory1.DefaultShowDateInBetweenOperator = false;
            defaultGridFilterFactory1.DefaultShowNumericInBetweenOperator = false;
            defaultGridFilterFactory1.HandleEnumerationTypes = true;
            defaultGridFilterFactory1.MaximumDistinctValues = 20;
            this.dataGridFilterExtender1.FilterFactory = defaultGridFilterFactory1;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.Image")));
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.Location = new System.Drawing.Point(168, 152);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnUpdate.Size = new System.Drawing.Size(90, 25);
            this.btnUpdate.TabIndex = 25;
            this.btnUpdate.TabStop = false;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnSaveBasicInfo
            // 
            this.btnSaveBasicInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveBasicInfo.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnSaveBasicInfo.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveBasicInfo.Image")));
            this.btnSaveBasicInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveBasicInfo.Location = new System.Drawing.Point(89, 152);
            this.btnSaveBasicInfo.Name = "btnSaveBasicInfo";
            this.btnSaveBasicInfo.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnSaveBasicInfo.Size = new System.Drawing.Size(76, 25);
            this.btnSaveBasicInfo.TabIndex = 23;
            this.btnSaveBasicInfo.TabStop = false;
            this.btnSaveBasicInfo.Text = "Save";
            this.btnSaveBasicInfo.UseVisualStyleBackColor = true;
            this.btnSaveBasicInfo.Click += new System.EventHandler(this.btnSaveBasicInfo_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnDelete.Image = global::StockbrokerProNewArch.Properties.Resources.Close_2_icon;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(347, 355);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnDelete.Size = new System.Drawing.Size(87, 25);
            this.btnDelete.TabIndex = 24;
            this.btnDelete.TabStop = false;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(12, 152);
            this.btnNew.Name = "btnNew";
            this.btnNew.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnNew.Size = new System.Drawing.Size(75, 25);
            this.btnNew.TabIndex = 30;
            this.btnNew.TabStop = false;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnResetBasicInfo
            // 
            this.btnResetBasicInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetBasicInfo.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnResetBasicInfo.Image = ((System.Drawing.Image)(resources.GetObject("btnResetBasicInfo.Image")));
            this.btnResetBasicInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnResetBasicInfo.Location = new System.Drawing.Point(260, 152);
            this.btnResetBasicInfo.Name = "btnResetBasicInfo";
            this.btnResetBasicInfo.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnResetBasicInfo.Size = new System.Drawing.Size(81, 25);
            this.btnResetBasicInfo.TabIndex = 31;
            this.btnResetBasicInfo.TabStop = false;
            this.btnResetBasicInfo.Text = "Reset";
            this.btnResetBasicInfo.UseVisualStyleBackColor = true;
            this.btnResetBasicInfo.Click += new System.EventHandler(this.btnResetBasicInfo_Click);
            // 
            // frmProcess_List
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 380);
            this.Controls.Add(this.btnResetBasicInfo);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSaveBasicInfo);
            this.Controls.Add(this.dgvCashBackSessionInfo);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClose);
            this.MaximizeBox = false;
            this.Name = "frmProcess_List";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Process List";
            this.Load += new System.EventHandler(this.frmProcess_List_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCashBackSessionInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFilterExtender1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpEntry_Date;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnSaveBasicInfo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label97;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label96;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtProcessName;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dgvCashBackSessionInfo;
        private GridViewExtensions.DataGridFilterExtender dataGridFilterExtender1;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnResetBasicInfo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtProcessID;
    }
}