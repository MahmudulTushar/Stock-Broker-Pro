namespace StockbrokerProNewArch
{
    partial class UserForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory defaultGridFilterFactory1 = new GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory();
            this.btnNew = new System.Windows.Forms.Button();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.dtgUserInfo = new System.Windows.Forms.DataGridView();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtContactNo = new System.Windows.Forms.TextBox();
            this.gbUserEntry = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.ddlRoleName = new System.Windows.Forms.ComboBox();
            this.ddlBranchName = new System.Windows.Forms.ComboBox();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.rdoInactive = new System.Windows.Forms.RadioButton();
            this.rdoActive = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtEmployeeCode = new System.Windows.Forms.TextBox();
            this.lblTotalUser = new System.Windows.Forms.Label();
            this.dataGridFilterExtender1 = new GridViewExtensions.DataGridFilterExtender(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgUserInfo)).BeginInit();
            this.gbUserEntry.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFilterExtender1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNew
            // 
            this.btnNew.Enabled = false;
            this.btnNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(229, 461);
            this.btnNew.Name = "btnNew";
            this.btnNew.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnNew.Size = new System.Drawing.Size(90, 25);
            this.btnNew.TabIndex = 1;
            this.btnNew.TabStop = false;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(194, 100);
            this.txtRemarks.MaxLength = 150;
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(126, 22);
            this.txtRemarks.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Gray;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(21, 150);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label8.Size = new System.Drawing.Size(150, 20);
            this.label8.TabIndex = 82;
            this.label8.Text = "Status";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Gray;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(21, 99);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label7.Size = new System.Drawing.Size(150, 20);
            this.label7.TabIndex = 81;
            this.label7.Text = "Remarks";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnReset.Image = ((System.Drawing.Image)(resources.GetObject("btnReset.Image")));
            this.btnReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReset.Location = new System.Drawing.Point(517, 461);
            this.btnReset.Name = "btnReset";
            this.btnReset.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnReset.Size = new System.Drawing.Size(90, 25);
            this.btnReset.TabIndex = 4;
            this.btnReset.TabStop = false;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.Image")));
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.Location = new System.Drawing.Point(325, 461);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnUpdate.Size = new System.Drawing.Size(90, 25);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.TabStop = false;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // dtgUserInfo
            // 
            this.dtgUserInfo.AllowUserToAddRows = false;
            this.dtgUserInfo.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Navy;
            this.dtgUserInfo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgUserInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgUserInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgUserInfo.ColumnHeadersHeight = 34;
            this.dtgUserInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgUserInfo.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtgUserInfo.EnableHeadersVisualStyles = false;
            this.dtgUserInfo.GridColor = System.Drawing.Color.LightGray;
            this.dtgUserInfo.Location = new System.Drawing.Point(12, 252);
            this.dtgUserInfo.MultiSelect = false;
            this.dtgUserInfo.Name = "dtgUserInfo";
            this.dtgUserInfo.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgUserInfo.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dtgUserInfo.RowHeadersVisible = false;
            this.dtgUserInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgUserInfo.Size = new System.Drawing.Size(690, 205);
            this.dtgUserInfo.TabIndex = 6;
            this.dtgUserInfo.TabStop = false;
            this.dtgUserInfo.SelectionChanged += new System.EventHandler(this.dtgUserInfo_SelectionChanged);
            this.dtgUserInfo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgUserInfo_CellContentClick);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(613, 461);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnCancel.Size = new System.Drawing.Size(90, 25);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(421, 461);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnSave.Size = new System.Drawing.Size(90, 25);
            this.btnSave.TabIndex = 3;
            this.btnSave.TabStop = false;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtContactNo
            // 
            this.txtContactNo.Location = new System.Drawing.Point(194, 75);
            this.txtContactNo.MaxLength = 150;
            this.txtContactNo.Name = "txtContactNo";
            this.txtContactNo.Size = new System.Drawing.Size(126, 20);
            this.txtContactNo.TabIndex = 7;
            // 
            // gbUserEntry
            // 
            this.gbUserEntry.Controls.Add(this.label5);
            this.gbUserEntry.Controls.Add(this.txtAddress);
            this.gbUserEntry.Controls.Add(this.label6);
            this.gbUserEntry.Controls.Add(this.label4);
            this.gbUserEntry.Controls.Add(this.txtName);
            this.gbUserEntry.Controls.Add(this.txtContactNo);
            this.gbUserEntry.Controls.Add(this.label7);
            this.gbUserEntry.Controls.Add(this.txtRemarks);
            this.gbUserEntry.Location = new System.Drawing.Point(360, 12);
            this.gbUserEntry.Name = "gbUserEntry";
            this.gbUserEntry.Size = new System.Drawing.Size(342, 130);
            this.gbUserEntry.TabIndex = 0;
            this.gbUserEntry.TabStop = false;
            this.gbUserEntry.Text = "Personal Details";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Gray;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(21, 51);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label5.Size = new System.Drawing.Size(150, 20);
            this.label5.TabIndex = 102;
            this.label5.Text = "Address";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(194, 50);
            this.txtAddress.MaxLength = 200;
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(126, 22);
            this.txtAddress.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Gray;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(21, 74);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label6.Size = new System.Drawing.Size(150, 20);
            this.label6.TabIndex = 101;
            this.label6.Text = "Contact Number";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Gray;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(21, 28);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label4.Size = new System.Drawing.Size(150, 20);
            this.label4.TabIndex = 100;
            this.label4.Text = "Name";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(194, 27);
            this.txtName.MaxLength = 50;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(126, 20);
            this.txtName.TabIndex = 5;
            // 
            // ddlRoleName
            // 
            this.ddlRoleName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlRoleName.FormattingEnabled = true;
            this.ddlRoleName.Items.AddRange(new object[] {
            "1",
            "2"});
            this.ddlRoleName.Location = new System.Drawing.Point(194, 101);
            this.ddlRoleName.Name = "ddlRoleName";
            this.ddlRoleName.Size = new System.Drawing.Size(126, 21);
            this.ddlRoleName.TabIndex = 3;
            // 
            // ddlBranchName
            // 
            this.ddlBranchName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlBranchName.FormattingEnabled = true;
            this.ddlBranchName.Items.AddRange(new object[] {
            "1",
            "2"});
            this.ddlBranchName.Location = new System.Drawing.Point(194, 127);
            this.ddlBranchName.Name = "ddlBranchName";
            this.ddlBranchName.Size = new System.Drawing.Size(126, 21);
            this.ddlBranchName.TabIndex = 4;
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Location = new System.Drawing.Point(194, 70);
            this.txtConfirmPassword.MaxLength = 20;
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.Size = new System.Drawing.Size(126, 20);
            this.txtConfirmPassword.TabIndex = 2;
            this.txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(194, 46);
            this.txtPassword.MaxLength = 20;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(126, 20);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(194, 22);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(126, 20);
            this.txtUserName.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Gray;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(21, 126);
            this.label11.Name = "label11";
            this.label11.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label11.Size = new System.Drawing.Size(150, 20);
            this.label11.TabIndex = 99;
            this.label11.Text = "Branch Name";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Gray;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(21, 69);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label3.Size = new System.Drawing.Size(150, 20);
            this.label3.TabIndex = 98;
            this.label3.Text = "Confirm Password";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Gray;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(21, 46);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label2.Size = new System.Drawing.Size(150, 20);
            this.label2.TabIndex = 97;
            this.label2.Text = "Password";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Gray;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(21, 23);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label1.Size = new System.Drawing.Size(150, 20);
            this.label1.TabIndex = 96;
            this.label1.Text = "User Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Gray;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(21, 102);
            this.label9.Name = "label9";
            this.label9.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label9.Size = new System.Drawing.Size(150, 20);
            this.label9.TabIndex = 89;
            this.label9.Text = "Role Name";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rdoInactive
            // 
            this.rdoInactive.AutoSize = true;
            this.rdoInactive.Location = new System.Drawing.Point(255, 152);
            this.rdoInactive.Name = "rdoInactive";
            this.rdoInactive.Size = new System.Drawing.Size(57, 17);
            this.rdoInactive.TabIndex = 10;
            this.rdoInactive.Text = "Closed";
            this.rdoInactive.UseVisualStyleBackColor = true;
            // 
            // rdoActive
            // 
            this.rdoActive.AutoSize = true;
            this.rdoActive.Location = new System.Drawing.Point(194, 152);
            this.rdoActive.Name = "rdoActive";
            this.rdoActive.Size = new System.Drawing.Size(55, 17);
            this.rdoActive.TabIndex = 9;
            this.rdoActive.Text = "Active";
            this.rdoActive.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ddlRoleName);
            this.groupBox1.Controls.Add(this.ddlBranchName);
            this.groupBox1.Controls.Add(this.txtUserName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtConfirmPassword);
            this.groupBox1.Controls.Add(this.rdoInactive);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.rdoActive);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(342, 184);
            this.groupBox1.TabIndex = 100;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "User Setup";
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.DimGray;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Chartreuse;
            this.label10.Location = new System.Drawing.Point(12, 209);
            this.label10.Name = "label10";
            this.label10.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.label10.Size = new System.Drawing.Size(691, 23);
            this.label10.TabIndex = 101;
            this.label10.Text = "All Users List";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtEmployeeCode);
            this.groupBox2.Location = new System.Drawing.Point(360, 143);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(343, 53);
            this.groupBox2.TabIndex = 102;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Employee Code";
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.Gray;
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(21, 21);
            this.label12.Name = "label12";
            this.label12.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label12.Size = new System.Drawing.Size(114, 20);
            this.label12.TabIndex = 83;
            this.label12.Text = "Employee Code :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtEmployeeCode
            // 
            this.txtEmployeeCode.Location = new System.Drawing.Point(141, 21);
            this.txtEmployeeCode.MaxLength = 150;
            this.txtEmployeeCode.Multiline = true;
            this.txtEmployeeCode.Name = "txtEmployeeCode";
            this.txtEmployeeCode.Size = new System.Drawing.Size(179, 20);
            this.txtEmployeeCode.TabIndex = 82;
            // 
            // lblTotalUser
            // 
            this.lblTotalUser.BackColor = System.Drawing.Color.DimGray;
            this.lblTotalUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalUser.ForeColor = System.Drawing.Color.Chartreuse;
            this.lblTotalUser.Location = new System.Drawing.Point(527, 209);
            this.lblTotalUser.Name = "lblTotalUser";
            this.lblTotalUser.Size = new System.Drawing.Size(175, 23);
            this.lblTotalUser.TabIndex = 103;
            this.lblTotalUser.Text = "Total User : 0";
            this.lblTotalUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dataGridFilterExtender1
            // 
            this.dataGridFilterExtender1.DataGridView = this.dtgUserInfo;
            defaultGridFilterFactory1.CreateDistinctGridFilters = false;
            defaultGridFilterFactory1.DefaultGridFilterType = typeof(GridViewExtensions.GridFilters.TextGridFilter);
            defaultGridFilterFactory1.DefaultShowDateInBetweenOperator = false;
            defaultGridFilterFactory1.DefaultShowNumericInBetweenOperator = false;
            defaultGridFilterFactory1.HandleEnumerationTypes = true;
            defaultGridFilterFactory1.MaximumDistinctValues = 20;
            this.dataGridFilterExtender1.FilterFactory = defaultGridFilterFactory1;
            // 
            // UserForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 491);
            this.Controls.Add(this.lblTotalUser);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.dtgUserInfo);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gbUserEntry);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "UserForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add/Update User Information";
            this.Load += new System.EventHandler(this.UserForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgUserInfo)).EndInit();
            this.gbUserEntry.ResumeLayout(false);
            this.gbUserEntry.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFilterExtender1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.DataGridView dtgUserInfo;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtContactNo;
        private System.Windows.Forms.GroupBox gbUserEntry;
        private System.Windows.Forms.RadioButton rdoInactive;
        private System.Windows.Forms.RadioButton rdoActive;
        private System.Windows.Forms.ComboBox ddlRoleName;
        private System.Windows.Forms.ComboBox ddlBranchName;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtEmployeeCode;
        private System.Windows.Forms.Label lblTotalUser;
        private GridViewExtensions.DataGridFilterExtender dataGridFilterExtender1;
    }
}