namespace StockbrokerProNewArch
{
    partial class HideCustomer
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HideCustomer));
            GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory defaultGridFilterFactory2 = new GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory();
            this.label5 = new System.Windows.Forms.Label();
            this.dtgHiddenCustomer = new System.Windows.Forms.DataGridView();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnResetBasicInfo = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblCriteriaName = new System.Windows.Forms.Label();
            this.ddlCriteriaID = new System.Windows.Forms.ComboBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.ddlSearchCustomer = new System.Windows.Forms.ComboBox();
            this.txtSearchCustomer = new System.Windows.Forms.TextBox();
            this.ddlResourceName = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.ddlUserName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtCustCode = new System.Windows.Forms.TextBox();
            this.label199 = new System.Windows.Forms.Label();
            this.txtAccountHolderName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAccountHolderBOId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvExtension = new GridViewExtensions.DataGridFilterExtender(this.components);
            this.lblRecord = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgHiddenCustomer)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExtension)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.DimGray;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Chartreuse;
            this.label5.Location = new System.Drawing.Point(11, 268);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.label5.Size = new System.Drawing.Size(430, 22);
            this.label5.TabIndex = 9;
            this.label5.Text = "All Hidden List";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtgHiddenCustomer
            // 
            this.dtgHiddenCustomer.AllowUserToAddRows = false;
            this.dtgHiddenCustomer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgHiddenCustomer.BackgroundColor = System.Drawing.Color.Silver;
            this.dtgHiddenCustomer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgHiddenCustomer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgHiddenCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgHiddenCustomer.Location = new System.Drawing.Point(11, 308);
            this.dtgHiddenCustomer.MultiSelect = false;
            this.dtgHiddenCustomer.Name = "dtgHiddenCustomer";
            this.dtgHiddenCustomer.ReadOnly = true;
            this.dtgHiddenCustomer.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dtgHiddenCustomer.RowHeadersVisible = false;
            this.dtgHiddenCustomer.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dtgHiddenCustomer.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgHiddenCustomer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgHiddenCustomer.Size = new System.Drawing.Size(430, 169);
            this.dtgHiddenCustomer.TabIndex = 8;
            this.dtgHiddenCustomer.TabStop = false;
            this.dtgHiddenCustomer.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgHiddenCustomer_CellClick);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(311, 237);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnCancel.Size = new System.Drawing.Size(84, 25);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Close";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnRemove.Image = ((System.Drawing.Image)(resources.GetObject("btnRemove.Image")));
            this.btnRemove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRemove.Location = new System.Drawing.Point(141, 237);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnRemove.Size = new System.Drawing.Size(82, 25);
            this.btnRemove.TabIndex = 11;
            this.btnRemove.TabStop = false;
            this.btnRemove.Text = "Delete";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Enabled = false;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(57, 237);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnAdd.Size = new System.Drawing.Size(82, 25);
            this.btnAdd.TabIndex = 12;
            this.btnAdd.TabStop = false;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
          //  this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnResetBasicInfo
            // 
            this.btnResetBasicInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetBasicInfo.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnResetBasicInfo.Image = ((System.Drawing.Image)(resources.GetObject("btnResetBasicInfo.Image")));
            this.btnResetBasicInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnResetBasicInfo.Location = new System.Drawing.Point(227, 237);
            this.btnResetBasicInfo.Name = "btnResetBasicInfo";
            this.btnResetBasicInfo.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnResetBasicInfo.Size = new System.Drawing.Size(82, 25);
            this.btnResetBasicInfo.TabIndex = 42;
            this.btnResetBasicInfo.TabStop = false;
            this.btnResetBasicInfo.Text = "Reset";
            this.btnResetBasicInfo.UseVisualStyleBackColor = true;
            this.btnResetBasicInfo.Click += new System.EventHandler(this.btnResetBasicInfo_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblCriteriaName);
            this.groupBox1.Controls.Add(this.ddlCriteriaID);
            this.groupBox1.Controls.Add(this.btnGo);
            this.groupBox1.Controls.Add(this.ddlSearchCustomer);
            this.groupBox1.Controls.Add(this.txtSearchCustomer);
            this.groupBox1.Controls.Add(this.ddlResourceName);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.ddlUserName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(428, 109);
            this.groupBox1.TabIndex = 81;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Account Selection";
            // 
            // lblCriteriaName
            // 
            this.lblCriteriaName.BackColor = System.Drawing.Color.DimGray;
            this.lblCriteriaName.ForeColor = System.Drawing.Color.White;
            this.lblCriteriaName.Location = new System.Drawing.Point(11, 78);
            this.lblCriteriaName.Name = "lblCriteriaName";
            this.lblCriteriaName.Size = new System.Drawing.Size(115, 23);
            this.lblCriteriaName.TabIndex = 71;
            this.lblCriteriaName.Visible = false;
            // 
            // ddlCriteriaID
            // 
            this.ddlCriteriaID.FormattingEnabled = true;
            this.ddlCriteriaID.Location = new System.Drawing.Point(138, 77);
            this.ddlCriteriaID.Name = "ddlCriteriaID";
            this.ddlCriteriaID.Size = new System.Drawing.Size(129, 21);
            this.ddlCriteriaID.TabIndex = 70;
            // 
            // btnGo
            // 
            this.btnGo.Image = ((System.Drawing.Image)(resources.GetObject("btnGo.Image")));
            this.btnGo.Location = new System.Drawing.Point(274, 77);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(42, 23);
            this.btnGo.TabIndex = 69;
            this.btnGo.TabStop = false;
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Visible = false;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // ddlSearchCustomer
            // 
            this.ddlSearchCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlSearchCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ddlSearchCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlSearchCustomer.ForeColor = System.Drawing.Color.DarkGreen;
            this.ddlSearchCustomer.FormattingEnabled = true;
            this.ddlSearchCustomer.Items.AddRange(new object[] {
            "Customer Code",
            "BO Id"});
            this.ddlSearchCustomer.Location = new System.Drawing.Point(11, 78);
            this.ddlSearchCustomer.Name = "ddlSearchCustomer";
            this.ddlSearchCustomer.Size = new System.Drawing.Size(115, 21);
            this.ddlSearchCustomer.TabIndex = 68;
            this.ddlSearchCustomer.TabStop = false;
            // 
            // txtSearchCustomer
            // 
            this.txtSearchCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchCustomer.ForeColor = System.Drawing.Color.DarkGreen;
            this.txtSearchCustomer.Location = new System.Drawing.Point(138, 79);
            this.txtSearchCustomer.Name = "txtSearchCustomer";
            this.txtSearchCustomer.Size = new System.Drawing.Size(129, 20);
            this.txtSearchCustomer.TabIndex = 67;
            this.txtSearchCustomer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchCustomer_KeyDown);
            // 
            // ddlResourceName
            // 
            this.ddlResourceName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlResourceName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ddlResourceName.FormattingEnabled = true;
            this.ddlResourceName.Location = new System.Drawing.Point(138, 50);
            this.ddlResourceName.Name = "ddlResourceName";
            this.ddlResourceName.Size = new System.Drawing.Size(244, 21);
            this.ddlResourceName.TabIndex = 65;
            this.ddlResourceName.SelectedIndexChanged += new System.EventHandler(this.ddlResourceName_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.DimGray;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(11, 50);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(115, 21);
            this.label9.TabIndex = 64;
            this.label9.Text = "Resource Name :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ddlUserName
            // 
            this.ddlUserName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlUserName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ddlUserName.FormattingEnabled = true;
            this.ddlUserName.Location = new System.Drawing.Point(138, 19);
            this.ddlUserName.Name = "ddlUserName";
            this.ddlUserName.Size = new System.Drawing.Size(244, 21);
            this.ddlUserName.TabIndex = 66;
            this.ddlUserName.SelectedIndexChanged += new System.EventHandler(this.ddlUserName_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DimGray;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(11, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 21);
            this.label1.TabIndex = 63;
            this.label1.Text = "User Name  :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtCustCode);
            this.groupBox2.Controls.Add(this.label199);
            this.groupBox2.Controls.Add(this.txtAccountHolderName);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtAccountHolderBOId);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(13, 127);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(428, 103);
            this.groupBox2.TabIndex = 82;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Account Holder\'s Information";
            // 
            // txtCustCode
            // 
            this.txtCustCode.BackColor = System.Drawing.Color.LightGray;
            this.txtCustCode.ForeColor = System.Drawing.Color.Black;
            this.txtCustCode.Location = new System.Drawing.Point(175, 20);
            this.txtCustCode.Name = "txtCustCode";
            this.txtCustCode.ReadOnly = true;
            this.txtCustCode.Size = new System.Drawing.Size(150, 20);
            this.txtCustCode.TabIndex = 79;
            this.txtCustCode.TabStop = false;
            // 
            // label199
            // 
            this.label199.BackColor = System.Drawing.Color.Gray;
            this.label199.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label199.ForeColor = System.Drawing.Color.White;
            this.label199.Location = new System.Drawing.Point(9, 20);
            this.label199.Name = "label199";
            this.label199.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label199.Size = new System.Drawing.Size(152, 20);
            this.label199.TabIndex = 78;
            this.label199.Text = "Account Code";
            this.label199.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAccountHolderName
            // 
            this.txtAccountHolderName.BackColor = System.Drawing.Color.LightGray;
            this.txtAccountHolderName.ForeColor = System.Drawing.Color.Black;
            this.txtAccountHolderName.Location = new System.Drawing.Point(175, 68);
            this.txtAccountHolderName.Name = "txtAccountHolderName";
            this.txtAccountHolderName.ReadOnly = true;
            this.txtAccountHolderName.Size = new System.Drawing.Size(150, 20);
            this.txtAccountHolderName.TabIndex = 77;
            this.txtAccountHolderName.TabStop = false;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Gray;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(9, 68);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label2.Size = new System.Drawing.Size(152, 20);
            this.label2.TabIndex = 76;
            this.label2.Text = "Account Holder\'s Name";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAccountHolderBOId
            // 
            this.txtAccountHolderBOId.BackColor = System.Drawing.Color.LightGray;
            this.txtAccountHolderBOId.ForeColor = System.Drawing.Color.Black;
            this.txtAccountHolderBOId.Location = new System.Drawing.Point(175, 44);
            this.txtAccountHolderBOId.Name = "txtAccountHolderBOId";
            this.txtAccountHolderBOId.ReadOnly = true;
            this.txtAccountHolderBOId.Size = new System.Drawing.Size(150, 20);
            this.txtAccountHolderBOId.TabIndex = 75;
            this.txtAccountHolderBOId.TabStop = false;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Gray;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(9, 44);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label3.Size = new System.Drawing.Size(152, 20);
            this.label3.TabIndex = 74;
            this.label3.Text = "Account Holder\'s BO ID";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvExtension
            // 
            this.dgvExtension.DataGridView = this.dtgHiddenCustomer;
            defaultGridFilterFactory2.CreateDistinctGridFilters = false;
            defaultGridFilterFactory2.DefaultGridFilterType = typeof(GridViewExtensions.GridFilters.TextGridFilter);
            defaultGridFilterFactory2.DefaultShowDateInBetweenOperator = false;
            defaultGridFilterFactory2.DefaultShowNumericInBetweenOperator = false;
            defaultGridFilterFactory2.HandleEnumerationTypes = true;
            defaultGridFilterFactory2.MaximumDistinctValues = 20;
            this.dgvExtension.FilterFactory = defaultGridFilterFactory2;
            // 
            // lblRecord
            // 
            this.lblRecord.BackColor = System.Drawing.Color.DimGray;
            this.lblRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecord.ForeColor = System.Drawing.Color.Chartreuse;
            this.lblRecord.Location = new System.Drawing.Point(309, 268);
            this.lblRecord.Name = "lblRecord";
            this.lblRecord.Size = new System.Drawing.Size(121, 20);
            this.lblRecord.TabIndex = 84;
            this.lblRecord.Text = "Total Record : 0";
            this.lblRecord.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // HideCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 490);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnResetBasicInfo);
            this.Controls.Add(this.lblRecord);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtgHiddenCustomer);
            this.MaximizeBox = false;
            this.Name = "HideCustomer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hide Accounts From Dashboard";
            this.Load += new System.EventHandler(this.HideCustomer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgHiddenCustomer)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExtension)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dtgHiddenCustomer;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnResetBasicInfo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.TextBox txtCustCode;
        private System.Windows.Forms.Label label199;
        public System.Windows.Forms.TextBox txtAccountHolderName;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtAccountHolderBOId;
        private System.Windows.Forms.Label label3;
        private GridViewExtensions.DataGridFilterExtender dgvExtension;
        private System.Windows.Forms.Label lblRecord;
        private System.Windows.Forms.ComboBox ddlResourceName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox ddlUserName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGo;
        public System.Windows.Forms.ComboBox ddlSearchCustomer;
        public System.Windows.Forms.TextBox txtSearchCustomer;
        private System.Windows.Forms.ComboBox ddlCriteriaID;
        private System.Windows.Forms.Label lblCriteriaName;
    }
}