namespace StockbrokerProNewArch
{
    partial class WebSmsRegistration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WebSmsRegistration));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("SMS");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Email");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Trade Confirmation", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("SMS");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Email");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Eft Withdraw", new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("SMS");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Email");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Money Withdraw", new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8});
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("SMS");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Email");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Money Deposit", new System.Windows.Forms.TreeNode[] {
            treeNode10,
            treeNode11});
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.dtgRegisterInfo = new System.Windows.Forms.DataGridView();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtWeb = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtEcharge = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSms = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtCustCode = new System.Windows.Forms.TextBox();
            this.label199 = new System.Windows.Forms.Label();
            this.txtAccountHolderName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAccountHolderBOId = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dtRegDate = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.txtClientCode = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMobileNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tr_Trade_Confirmation = new System.Windows.Forms.TreeView();
            this.tr_Eft_Withdraw = new System.Windows.Forms.TreeView();
            this.chkECharge = new System.Windows.Forms.CheckBox();
            this.tr_Money_Withdraw = new System.Windows.Forms.TreeView();
            this.tr_Money_Deposit = new System.Windows.Forms.TreeView();
            this.chkSmsTrade = new System.Windows.Forms.CheckBox();
            this.chkWeb = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.btn_WebUplod = new System.Windows.Forms.Button();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgRegisterInfo)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.dtgRegisterInfo);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(674, 339);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "View Registered Clients";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DimGray;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Chartreuse;
            this.label1.Location = new System.Drawing.Point(2, 3);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.label1.Size = new System.Drawing.Size(666, 24);
            this.label1.TabIndex = 9;
            this.label1.Text = "All Registered Clients";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtgRegisterInfo
            // 
            this.dtgRegisterInfo.AllowUserToAddRows = false;
            this.dtgRegisterInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgRegisterInfo.BackgroundColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgRegisterInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgRegisterInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgRegisterInfo.Location = new System.Drawing.Point(2, 22);
            this.dtgRegisterInfo.MultiSelect = false;
            this.dtgRegisterInfo.Name = "dtgRegisterInfo";
            this.dtgRegisterInfo.ReadOnly = true;
            this.dtgRegisterInfo.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dtgRegisterInfo.RowHeadersVisible = false;
            this.dtgRegisterInfo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dtgRegisterInfo.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgRegisterInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgRegisterInfo.Size = new System.Drawing.Size(667, 296);
            this.dtgRegisterInfo.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btn_WebUplod);
            this.tabPage1.Controls.Add(this.btn_Cancel);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.btnUpdate);
            this.tabPage1.Controls.Add(this.btnNew);
            this.tabPage1.Controls.Add(this.btnSave);
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(674, 339);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Service Entry";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cancel.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btn_Cancel.Location = new System.Drawing.Point(295, 307);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(90, 25);
            this.btn_Cancel.TabIndex = 93;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtWeb);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtEcharge);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtSms);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Location = new System.Drawing.Point(352, 108);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(310, 94);
            this.groupBox1.TabIndex = 92;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Account Holder\'s Information";
            // 
            // txtWeb
            // 
            this.txtWeb.BackColor = System.Drawing.Color.LightGray;
            this.txtWeb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWeb.ForeColor = System.Drawing.Color.Maroon;
            this.txtWeb.Location = new System.Drawing.Point(135, 16);
            this.txtWeb.Name = "txtWeb";
            this.txtWeb.ReadOnly = true;
            this.txtWeb.Size = new System.Drawing.Size(154, 20);
            this.txtWeb.TabIndex = 79;
            this.txtWeb.TabStop = false;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Gray;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(12, 16);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label8.Size = new System.Drawing.Size(117, 20);
            this.label8.TabIndex = 78;
            this.label8.Text = "Web Service";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtEcharge
            // 
            this.txtEcharge.AcceptsTab = true;
            this.txtEcharge.BackColor = System.Drawing.Color.LightGray;
            this.txtEcharge.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEcharge.ForeColor = System.Drawing.Color.DimGray;
            this.txtEcharge.Location = new System.Drawing.Point(135, 64);
            this.txtEcharge.Name = "txtEcharge";
            this.txtEcharge.ReadOnly = true;
            this.txtEcharge.Size = new System.Drawing.Size(154, 20);
            this.txtEcharge.TabIndex = 77;
            this.txtEcharge.TabStop = false;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Gray;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(12, 64);
            this.label9.Name = "label9";
            this.label9.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label9.Size = new System.Drawing.Size(117, 20);
            this.label9.TabIndex = 76;
            this.label9.Text = "SMS Trade";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSms
            // 
            this.txtSms.BackColor = System.Drawing.Color.LightGray;
            this.txtSms.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSms.ForeColor = System.Drawing.Color.DimGray;
            this.txtSms.Location = new System.Drawing.Point(135, 40);
            this.txtSms.Name = "txtSms";
            this.txtSms.ReadOnly = true;
            this.txtSms.Size = new System.Drawing.Size(154, 20);
            this.txtSms.TabIndex = 75;
            this.txtSms.TabStop = false;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Gray;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(12, 40);
            this.label10.Name = "label10";
            this.label10.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label10.Size = new System.Drawing.Size(117, 20);
            this.label10.TabIndex = 74;
            this.label10.Text = "SMS Service";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtCustCode);
            this.groupBox2.Controls.Add(this.label199);
            this.groupBox2.Controls.Add(this.txtAccountHolderName);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtAccountHolderBOId);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(352, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(310, 98);
            this.groupBox2.TabIndex = 92;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Account Holder\'s Information";
            // 
            // txtCustCode
            // 
            this.txtCustCode.BackColor = System.Drawing.Color.LightGray;
            this.txtCustCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustCode.ForeColor = System.Drawing.Color.Maroon;
            this.txtCustCode.Location = new System.Drawing.Point(75, 15);
            this.txtCustCode.Name = "txtCustCode";
            this.txtCustCode.ReadOnly = true;
            this.txtCustCode.Size = new System.Drawing.Size(214, 20);
            this.txtCustCode.TabIndex = 79;
            this.txtCustCode.TabStop = false;
            // 
            // label199
            // 
            this.label199.BackColor = System.Drawing.Color.Gray;
            this.label199.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label199.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label199.ForeColor = System.Drawing.Color.White;
            this.label199.Location = new System.Drawing.Point(12, 15);
            this.label199.Name = "label199";
            this.label199.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label199.Size = new System.Drawing.Size(57, 20);
            this.label199.TabIndex = 78;
            this.label199.Text = "Code";
            this.label199.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAccountHolderName
            // 
            this.txtAccountHolderName.BackColor = System.Drawing.Color.LightGray;
            this.txtAccountHolderName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccountHolderName.ForeColor = System.Drawing.Color.DimGray;
            this.txtAccountHolderName.Location = new System.Drawing.Point(75, 63);
            this.txtAccountHolderName.Name = "txtAccountHolderName";
            this.txtAccountHolderName.ReadOnly = true;
            this.txtAccountHolderName.Size = new System.Drawing.Size(214, 20);
            this.txtAccountHolderName.TabIndex = 77;
            this.txtAccountHolderName.TabStop = false;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Gray;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 63);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label2.Size = new System.Drawing.Size(57, 20);
            this.label2.TabIndex = 76;
            this.label2.Text = "Name";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAccountHolderBOId
            // 
            this.txtAccountHolderBOId.BackColor = System.Drawing.Color.LightGray;
            this.txtAccountHolderBOId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccountHolderBOId.ForeColor = System.Drawing.Color.DimGray;
            this.txtAccountHolderBOId.Location = new System.Drawing.Point(75, 39);
            this.txtAccountHolderBOId.Name = "txtAccountHolderBOId";
            this.txtAccountHolderBOId.ReadOnly = true;
            this.txtAccountHolderBOId.Size = new System.Drawing.Size(214, 20);
            this.txtAccountHolderBOId.TabIndex = 75;
            this.txtAccountHolderBOId.TabStop = false;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Gray;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(12, 39);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label7.Size = new System.Drawing.Size(57, 20);
            this.label7.TabIndex = 74;
            this.label7.Text = "BO ID";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.Image")));
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.Location = new System.Drawing.Point(104, 307);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnUpdate.Size = new System.Drawing.Size(90, 25);
            this.btnUpdate.TabIndex = 90;
            this.btnUpdate.TabStop = false;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnNew
            // 
            this.btnNew.Enabled = false;
            this.btnNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(8, 307);
            this.btnNew.Name = "btnNew";
            this.btnNew.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnNew.Size = new System.Drawing.Size(90, 25);
            this.btnNew.TabIndex = 89;
            this.btnNew.TabStop = false;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(200, 307);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnSave.Size = new System.Drawing.Size(90, 25);
            this.btnSave.TabIndex = 91;
            this.btnSave.TabStop = false;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dtRegDate);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.txtClientCode);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.txtRemarks);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.txtMobileNo);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.txtEmail);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Location = new System.Drawing.Point(13, 10);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(333, 192);
            this.groupBox4.TabIndex = 88;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Info Entry";
            // 
            // dtRegDate
            // 
            this.dtRegDate.Checked = false;
            this.dtRegDate.CustomFormat = "dd MMM yyyy";
            this.dtRegDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtRegDate.Location = new System.Drawing.Point(117, 160);
            this.dtRegDate.Name = "dtRegDate";
            this.dtRegDate.Size = new System.Drawing.Size(96, 20);
            this.dtRegDate.TabIndex = 88;
            this.dtRegDate.Value = new System.DateTime(2010, 9, 23, 0, 0, 0, 0);
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Gray;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(5, 160);
            this.label11.Name = "label11";
            this.label11.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label11.Size = new System.Drawing.Size(104, 20);
            this.label11.TabIndex = 90;
            this.label11.Text = "Reg Date";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtClientCode
            // 
            this.txtClientCode.ForeColor = System.Drawing.Color.Black;
            this.txtClientCode.Location = new System.Drawing.Point(117, 13);
            this.txtClientCode.Name = "txtClientCode";
            this.txtClientCode.Size = new System.Drawing.Size(195, 20);
            this.txtClientCode.TabIndex = 87;
            this.txtClientCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtClientCode_KeyDown);
            this.txtClientCode.Leave += new System.EventHandler(this.txtClientCode_Leave);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Gray;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(7, 13);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label6.Size = new System.Drawing.Size(104, 20);
            this.label6.TabIndex = 86;
            this.label6.Text = "Client Code";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtRemarks
            // 
            this.txtRemarks.ForeColor = System.Drawing.Color.Black;
            this.txtRemarks.Location = new System.Drawing.Point(117, 90);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(195, 63);
            this.txtRemarks.TabIndex = 85;
            this.txtRemarks.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEmail_KeyDown);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Gray;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(7, 91);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label5.Size = new System.Drawing.Size(104, 20);
            this.label5.TabIndex = 84;
            this.label5.Text = "Remarks";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMobileNo
            // 
            this.txtMobileNo.ForeColor = System.Drawing.Color.Black;
            this.txtMobileNo.Location = new System.Drawing.Point(117, 65);
            this.txtMobileNo.Name = "txtMobileNo";
            this.txtMobileNo.Size = new System.Drawing.Size(195, 20);
            this.txtMobileNo.TabIndex = 83;
            this.txtMobileNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEmail_KeyDown);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Gray;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(7, 65);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label4.Size = new System.Drawing.Size(104, 20);
            this.label4.TabIndex = 82;
            this.label4.Text = "Mobile No.";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtEmail
            // 
            this.txtEmail.ForeColor = System.Drawing.Color.Black;
            this.txtEmail.Location = new System.Drawing.Point(117, 39);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(195, 20);
            this.txtEmail.TabIndex = 81;
            this.txtEmail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEmail_KeyDown);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Gray;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(7, 39);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label3.Size = new System.Drawing.Size(104, 20);
            this.label3.TabIndex = 80;
            this.label3.Text = "E-mail";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tr_Trade_Confirmation);
            this.groupBox3.Controls.Add(this.tr_Eft_Withdraw);
            this.groupBox3.Controls.Add(this.chkECharge);
            this.groupBox3.Controls.Add(this.tr_Money_Withdraw);
            this.groupBox3.Controls.Add(this.tr_Money_Deposit);
            this.groupBox3.Controls.Add(this.chkSmsTrade);
            this.groupBox3.Controls.Add(this.chkWeb);
            this.groupBox3.Location = new System.Drawing.Point(13, 215);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(650, 86);
            this.groupBox3.TabIndex = 87;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Select Service Content";
            // 
            // tr_Trade_Confirmation
            // 
            this.tr_Trade_Confirmation.CheckBoxes = true;
            this.tr_Trade_Confirmation.Location = new System.Drawing.Point(408, 16);
            this.tr_Trade_Confirmation.Name = "tr_Trade_Confirmation";
            treeNode1.Name = "Sms_Trade_Confirmation";
            treeNode1.Text = "SMS";
            treeNode2.Name = "Email_Trade_Confirmation";
            treeNode2.Text = "Email";
            treeNode3.Name = "Trade_Confirmation";
            treeNode3.Text = "Trade Confirmation";
            this.tr_Trade_Confirmation.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3});
            this.tr_Trade_Confirmation.Scrollable = false;
            this.tr_Trade_Confirmation.Size = new System.Drawing.Size(143, 60);
            this.tr_Trade_Confirmation.TabIndex = 9;
            this.tr_Trade_Confirmation.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tr_Trade_Confirmation_AfterCheck);
            // 
            // tr_Eft_Withdraw
            // 
            this.tr_Eft_Withdraw.CheckBoxes = true;
            this.tr_Eft_Withdraw.Enabled = false;
            this.tr_Eft_Withdraw.Location = new System.Drawing.Point(282, 16);
            this.tr_Eft_Withdraw.Name = "tr_Eft_Withdraw";
            treeNode4.Name = "Sms_Eft_Withdraw";
            treeNode4.Text = "SMS";
            treeNode5.Name = "Email_Eft_Withdraw";
            treeNode5.Text = "Email";
            treeNode6.Name = "Eft_Withdraw";
            treeNode6.Text = "Eft Withdraw";
            this.tr_Eft_Withdraw.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode6});
            this.tr_Eft_Withdraw.Scrollable = false;
            this.tr_Eft_Withdraw.Size = new System.Drawing.Size(121, 60);
            this.tr_Eft_Withdraw.TabIndex = 8;
            this.tr_Eft_Withdraw.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tr_Eft_Withdraw_AfterCheck);
            // 
            // chkECharge
            // 
            this.chkECharge.AutoSize = true;
            this.chkECharge.Location = new System.Drawing.Point(557, 59);
            this.chkECharge.Name = "chkECharge";
            this.chkECharge.Size = new System.Drawing.Size(70, 17);
            this.chkECharge.TabIndex = 2;
            this.chkECharge.Text = "E-Charge";
            this.chkECharge.UseVisualStyleBackColor = true;
            this.chkECharge.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEmail_KeyDown);
            // 
            // tr_Money_Withdraw
            // 
            this.tr_Money_Withdraw.CheckBoxes = true;
            this.tr_Money_Withdraw.Location = new System.Drawing.Point(145, 16);
            this.tr_Money_Withdraw.Name = "tr_Money_Withdraw";
            treeNode7.Name = "Sms_Money_Withdraw";
            treeNode7.Text = "SMS";
            treeNode8.Name = "Email_Money_Withdraw";
            treeNode8.Text = "Email";
            treeNode9.Name = "Money_Withdraw";
            treeNode9.Text = "Money Withdraw";
            this.tr_Money_Withdraw.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode9});
            this.tr_Money_Withdraw.Scrollable = false;
            this.tr_Money_Withdraw.Size = new System.Drawing.Size(131, 60);
            this.tr_Money_Withdraw.TabIndex = 7;
            this.tr_Money_Withdraw.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tr_Money_Withdraw_AfterCheck);
            // 
            // tr_Money_Deposit
            // 
            this.tr_Money_Deposit.CheckBoxes = true;
            this.tr_Money_Deposit.Location = new System.Drawing.Point(9, 16);
            this.tr_Money_Deposit.Name = "tr_Money_Deposit";
            treeNode10.Name = "Sms_Money_Deposit";
            treeNode10.Text = "SMS";
            treeNode11.Name = "Email_Money_Deposit";
            treeNode11.Text = "Email";
            treeNode12.Name = "Money_Deposit";
            treeNode12.Text = "Money Deposit";
            this.tr_Money_Deposit.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode12});
            this.tr_Money_Deposit.Scrollable = false;
            this.tr_Money_Deposit.Size = new System.Drawing.Size(131, 60);
            this.tr_Money_Deposit.TabIndex = 6;
            this.tr_Money_Deposit.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tr_Money_Deposit_AfterCheck);
            // 
            // chkSmsTrade
            // 
            this.chkSmsTrade.AutoSize = true;
            this.chkSmsTrade.Location = new System.Drawing.Point(557, 38);
            this.chkSmsTrade.Name = "chkSmsTrade";
            this.chkSmsTrade.Size = new System.Drawing.Size(80, 17);
            this.chkSmsTrade.TabIndex = 1;
            this.chkSmsTrade.Text = "SMS Trade";
            this.chkSmsTrade.UseVisualStyleBackColor = true;
            this.chkSmsTrade.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEmail_KeyDown);
            // 
            // chkWeb
            // 
            this.chkWeb.AutoSize = true;
            this.chkWeb.Location = new System.Drawing.Point(557, 16);
            this.chkWeb.Name = "chkWeb";
            this.chkWeb.Size = new System.Drawing.Size(51, 17);
            this.chkWeb.TabIndex = 0;
            this.chkWeb.Text = "WEB";
            this.chkWeb.UseVisualStyleBackColor = true;
            this.chkWeb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEmail_KeyDown);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(594, 376);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnCancel.Size = new System.Drawing.Size(90, 30);
            this.btnCancel.TabIndex = 92;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Close";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(6, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(682, 365);
            this.tabControl1.TabIndex = 0;
            // 
            // btn_WebUplod
            // 
            this.btn_WebUplod.Location = new System.Drawing.Point(406, 307);
            this.btn_WebUplod.Name = "btn_WebUplod";
            this.btn_WebUplod.Size = new System.Drawing.Size(108, 23);
            this.btn_WebUplod.TabIndex = 94;
            this.btn_WebUplod.Text = "Web UpDate";
            this.btn_WebUplod.UseVisualStyleBackColor = true;
            this.btn_WebUplod.Click += new System.EventHandler(this.btn_WebUplod_Click);
            // 
            // WebSmsRegistration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 410);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "WebSmsRegistration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Web & Sms Registration";
            this.Load += new System.EventHandler(this.WebSmsRegistration_Load);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgRegisterInfo)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dtgRegisterInfo;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox4;
        public System.Windows.Forms.TextBox txtClientCode;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtMobileNo;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkECharge;
        private System.Windows.Forms.CheckBox chkWeb;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.DateTimePicker dtRegDate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.TextBox txtCustCode;
        private System.Windows.Forms.Label label199;
        public System.Windows.Forms.TextBox txtAccountHolderName;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtAccountHolderBOId;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox txtWeb;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox txtEcharge;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.TextBox txtSms;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox chkSmsTrade;
        private System.Windows.Forms.TreeView tr_Money_Deposit;
        private System.Windows.Forms.TreeView tr_Money_Withdraw;
        private System.Windows.Forms.TreeView tr_Eft_Withdraw;
        private System.Windows.Forms.TreeView tr_Trade_Confirmation;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_WebUplod;


    }
}