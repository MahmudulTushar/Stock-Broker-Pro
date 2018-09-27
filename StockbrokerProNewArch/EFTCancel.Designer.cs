namespace StockbrokerProNewArch
{
    partial class EFTCancel
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
            GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory defaultGridFilterFactory3 = new GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory();
            GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory defaultGridFilterFactory1 = new GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory();
            this.dgEFTFileInfo = new System.Windows.Forms.DataGridView();
            this.btnshow = new System.Windows.Forms.Button();
            this.dataGridFilterExtender1 = new GridViewExtensions.DataGridFilterExtender(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgEFTIssue = new System.Windows.Forms.DataGridView();
            this.IssueID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.File_No_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Req_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Req_Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bank_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Branch_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Routing_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bank_Account_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Account_Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEFTFileNo = new System.Windows.Forms.TextBox();
            this.dataGridFilterExtender3 = new GridViewExtensions.DataGridFilterExtender(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.CmbSelection = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgEFTFileInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFilterExtender1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgEFTIssue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFilterExtender3)).BeginInit();
            this.SuspendLayout();
            // 
            // dgEFTFileInfo
            // 
            this.dgEFTFileInfo.AllowUserToAddRows = false;
            this.dgEFTFileInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgEFTFileInfo.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgEFTFileInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgEFTFileInfo.Location = new System.Drawing.Point(8, 97);
            this.dgEFTFileInfo.Name = "dgEFTFileInfo";
            this.dgEFTFileInfo.ReadOnly = true;
            this.dgEFTFileInfo.RowHeadersVisible = false;
            this.dgEFTFileInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgEFTFileInfo.Size = new System.Drawing.Size(422, 62);
            this.dgEFTFileInfo.TabIndex = 0;
            this.dgEFTFileInfo.DataSourceChanged += new System.EventHandler(this.dgEFTFileInfo_DataSourceChanged);
            // 
            // btnshow
            // 
            this.btnshow.Location = new System.Drawing.Point(11, 194);
            this.btnshow.Name = "btnshow";
            this.btnshow.Size = new System.Drawing.Size(75, 23);
            this.btnshow.TabIndex = 2;
            this.btnshow.Text = "Show";
            this.btnshow.UseVisualStyleBackColor = true;
            this.btnshow.Click += new System.EventHandler(this.btnshow_Click);
            // 
            // dataGridFilterExtender1
            // 
            this.dataGridFilterExtender1.DataGridView = this.dgEFTFileInfo;
            defaultGridFilterFactory3.CreateDistinctGridFilters = false;
            defaultGridFilterFactory3.DefaultGridFilterType = typeof(GridViewExtensions.GridFilters.TextGridFilter);
            defaultGridFilterFactory3.DefaultShowDateInBetweenOperator = false;
            defaultGridFilterFactory3.DefaultShowNumericInBetweenOperator = false;
            defaultGridFilterFactory3.HandleEnumerationTypes = true;
            defaultGridFilterFactory3.MaximumDistinctValues = 20;
            this.dataGridFilterExtender1.FilterFactory = defaultGridFilterFactory3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 553);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 7;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(200, 551);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // IsSelect
            // 
            this.IsSelect.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.IsSelect.HeaderText = "";
            this.IsSelect.Name = "IsSelect";
            // 
            // dgEFTIssue
            // 
            this.dgEFTIssue.AllowUserToAddRows = false;
            this.dgEFTIssue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgEFTIssue.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IssueID,
            this.Value,
            this.Code,
            this.Remarks,
            this.File_No_ID,
            this.Req_ID,
            this.Req_Type,
            this.Amount,
            this.Bank_Name,
            this.Branch_Name,
            this.Routing_No,
            this.Bank_Account_No,
            this.Account_Type});
            this.dgEFTIssue.Location = new System.Drawing.Point(8, 259);
            this.dgEFTIssue.Name = "dgEFTIssue";
            this.dgEFTIssue.RowHeadersVisible = false;
            this.dgEFTIssue.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgEFTIssue.Size = new System.Drawing.Size(422, 282);
            this.dgEFTIssue.TabIndex = 11;
            this.dgEFTIssue.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgEFTIssue_CellValueChanged);
            this.dgEFTIssue.DataSourceChanged += new System.EventHandler(this.dgEFTIssue_DataSourceChanged);
            // 
            // IssueID
            // 
            this.IssueID.HeaderText = "IssueID";
            this.IssueID.Name = "IssueID";
            // 
            // Value
            // 
            this.Value.HeaderText = "Select";
            this.Value.Name = "Value";
            this.Value.Width = 40;
            // 
            // Code
            // 
            this.Code.HeaderText = "Code";
            this.Code.Name = "Code";
            this.Code.Width = 50;
            // 
            // Remarks
            // 
            this.Remarks.HeaderText = "Remarks";
            this.Remarks.Name = "Remarks";
            // 
            // File_No_ID
            // 
            this.File_No_ID.HeaderText = "File_No_ID";
            this.File_No_ID.Name = "File_No_ID";
            // 
            // Req_ID
            // 
            this.Req_ID.HeaderText = "Req_ID";
            this.Req_ID.Name = "Req_ID";
            // 
            // Req_Type
            // 
            this.Req_Type.HeaderText = "Req_Type";
            this.Req_Type.Name = "Req_Type";
            // 
            // Amount
            // 
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            // 
            // Bank_Name
            // 
            this.Bank_Name.HeaderText = "Bank_Name";
            this.Bank_Name.Name = "Bank_Name";
            // 
            // Branch_Name
            // 
            this.Branch_Name.HeaderText = "Branch_Name";
            this.Branch_Name.Name = "Branch_Name";
            // 
            // Routing_No
            // 
            this.Routing_No.HeaderText = "Routing_No";
            this.Routing_No.Name = "Routing_No";
            // 
            // Bank_Account_No
            // 
            this.Bank_Account_No.HeaderText = "Bank_Account_No";
            this.Bank_Account_No.Name = "Bank_Account_No";
            // 
            // Account_Type
            // 
            this.Account_Type.HeaderText = "Account_Type";
            this.Account_Type.Name = "Account_Type";
            this.Account_Type.Width = 50;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "EFT File No";
            // 
            // txtEFTFileNo
            // 
            this.txtEFTFileNo.Location = new System.Drawing.Point(86, 43);
            this.txtEFTFileNo.Name = "txtEFTFileNo";
            this.txtEFTFileNo.Size = new System.Drawing.Size(178, 20);
            this.txtEFTFileNo.TabIndex = 15;
            this.txtEFTFileNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEFTFileNo_KeyDown);
            // 
            // dataGridFilterExtender3
            // 
            this.dataGridFilterExtender3.DataGridView = this.dgEFTIssue;
            defaultGridFilterFactory1.CreateDistinctGridFilters = false;
            defaultGridFilterFactory1.DefaultGridFilterType = typeof(GridViewExtensions.GridFilters.TextGridFilter);
            defaultGridFilterFactory1.DefaultShowDateInBetweenOperator = false;
            defaultGridFilterFactory1.DefaultShowNumericInBetweenOperator = false;
            defaultGridFilterFactory1.HandleEnumerationTypes = true;
            defaultGridFilterFactory1.MaximumDistinctValues = 20;
            this.dataGridFilterExtender3.FilterFactory = defaultGridFilterFactory1;
            this.dataGridFilterExtender3.FilterTextVisible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(8, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            // 
            // CmbSelection
            // 
            this.CmbSelection.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CmbSelection.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbSelection.FormattingEnabled = true;
            this.CmbSelection.Items.AddRange(new object[] {
            "Cancel",
            "Delete"});
            this.CmbSelection.Location = new System.Drawing.Point(119, 9);
            this.CmbSelection.Name = "CmbSelection";
            this.CmbSelection.Size = new System.Drawing.Size(121, 21);
            this.CmbSelection.TabIndex = 18;
            // 
            // EFTCancel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(442, 582);
            this.Controls.Add(this.CmbSelection);
            this.Controls.Add(this.txtEFTFileNo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgEFTIssue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgEFTFileInfo);
            this.Controls.Add(this.btnshow);
            this.Name = "EFTCancel";
            this.Text = "EFTCancel";
            this.Load += new System.EventHandler(this.EFTCancel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgEFTFileInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFilterExtender1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgEFTIssue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFilterExtender3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgEFTFileInfo;
        private System.Windows.Forms.Button btnshow;
        private GridViewExtensions.DataGridFilterExtender dataGridFilterExtender1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsSelect;
        private System.Windows.Forms.DataGridView dgEFTIssue;
        private System.Windows.Forms.DataGridViewTextBoxColumn IssueID;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Value;
        private System.Windows.Forms.DataGridViewTextBoxColumn Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn File_No_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Req_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Req_Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bank_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Branch_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Routing_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bank_Account_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Account_Type;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEFTFileNo;
        private GridViewExtensions.DataGridFilterExtender dataGridFilterExtender3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CmbSelection;
    }
}