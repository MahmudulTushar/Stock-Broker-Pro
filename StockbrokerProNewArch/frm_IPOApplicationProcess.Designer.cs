namespace StockbrokerProNewArch
{
    partial class frm_IPOApplicationProcess
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
            GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory defaultGridFilterFactory1 = new GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory();
            GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory defaultGridFilterFactory2 = new GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory();
            this.dgvEligibleCustomer = new System.Windows.Forms.DataGridView();
            this.CustCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cust_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApplyMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDoubleForward = new System.Windows.Forms.Button();
            this.btnSingleForward = new System.Windows.Forms.Button();
            this.btnsingleBackword = new System.Windows.Forms.Button();
            this.btnDoubleBackWard = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_Premium = new System.Windows.Forms.TextBox();
            this.txtSessName = new System.Windows.Forms.TextBox();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSessNoOfShare = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSessAmount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnImageVerify = new System.Windows.Forms.Button();
            this.btnVerify = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_Process = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txt_Cust_Code_ForReturnTransferParent = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmb_RefundType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEligibleClient = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cmb_CompanyName = new System.Windows.Forms.ComboBox();
            this.dgv_FinalCheck = new System.Windows.Forms.DataGridView();
            this.F_CustCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.F_CustName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.F_Balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.F_ApplyMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvExtension = new GridViewExtensions.DataGridFilterExtender(this.components);
            this.dataGridFilterExtender1 = new GridViewExtensions.DataGridFilterExtender(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEligibleCustomer)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_FinalCheck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExtension)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFilterExtender1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvEligibleCustomer
            // 
            this.dgvEligibleCustomer.AllowUserToAddRows = false;
            this.dgvEligibleCustomer.AllowUserToDeleteRows = false;
            this.dgvEligibleCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEligibleCustomer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CustCode,
            this.Cust_Name,
            this.Balance,
            this.ApplyMoney});
            this.dgvEligibleCustomer.Location = new System.Drawing.Point(16, 189);
            this.dgvEligibleCustomer.Name = "dgvEligibleCustomer";
            this.dgvEligibleCustomer.ReadOnly = true;
            this.dgvEligibleCustomer.RowHeadersVisible = false;
            this.dgvEligibleCustomer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEligibleCustomer.Size = new System.Drawing.Size(369, 392);
            this.dgvEligibleCustomer.TabIndex = 14;
            this.dgvEligibleCustomer.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEligibleCustomer_CellClick);
            // 
            // CustCode
            // 
            this.CustCode.DataPropertyName = "Cust_Code";
            this.CustCode.HeaderText = "Code";
            this.CustCode.Name = "CustCode";
            this.CustCode.ReadOnly = true;
            this.CustCode.Width = 50;
            // 
            // Cust_Name
            // 
            this.Cust_Name.DataPropertyName = "Cust_Name";
            this.Cust_Name.HeaderText = "Name";
            this.Cust_Name.Name = "Cust_Name";
            this.Cust_Name.ReadOnly = true;
            this.Cust_Name.Width = 150;
            // 
            // Balance
            // 
            this.Balance.DataPropertyName = "Balance";
            this.Balance.HeaderText = "Balance";
            this.Balance.Name = "Balance";
            this.Balance.ReadOnly = true;
            this.Balance.Width = 80;
            // 
            // ApplyMoney
            // 
            this.ApplyMoney.DataPropertyName = "ApplyMoney";
            this.ApplyMoney.HeaderText = "Apply Money";
            this.ApplyMoney.Name = "ApplyMoney";
            this.ApplyMoney.ReadOnly = true;
            // 
            // btnDoubleForward
            // 
            this.btnDoubleForward.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDoubleForward.Location = new System.Drawing.Point(392, 241);
            this.btnDoubleForward.Name = "btnDoubleForward";
            this.btnDoubleForward.Size = new System.Drawing.Size(47, 33);
            this.btnDoubleForward.TabIndex = 17;
            this.btnDoubleForward.Text = ">>";
            this.btnDoubleForward.UseVisualStyleBackColor = true;
            this.btnDoubleForward.Click += new System.EventHandler(this.btnDoubleForward_Click);
            // 
            // btnSingleForward
            // 
            this.btnSingleForward.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSingleForward.Location = new System.Drawing.Point(392, 280);
            this.btnSingleForward.Name = "btnSingleForward";
            this.btnSingleForward.Size = new System.Drawing.Size(47, 33);
            this.btnSingleForward.TabIndex = 18;
            this.btnSingleForward.Text = ">";
            this.btnSingleForward.UseVisualStyleBackColor = true;
            this.btnSingleForward.Click += new System.EventHandler(this.btnSingleForward_Click);
            // 
            // btnsingleBackword
            // 
            this.btnsingleBackword.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsingleBackword.Location = new System.Drawing.Point(392, 323);
            this.btnsingleBackword.Name = "btnsingleBackword";
            this.btnsingleBackword.Size = new System.Drawing.Size(47, 33);
            this.btnsingleBackword.TabIndex = 20;
            this.btnsingleBackword.Text = "<";
            this.btnsingleBackword.UseVisualStyleBackColor = true;
            this.btnsingleBackword.Click += new System.EventHandler(this.btnsingleBackword_Click);
            // 
            // btnDoubleBackWard
            // 
            this.btnDoubleBackWard.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDoubleBackWard.Location = new System.Drawing.Point(392, 367);
            this.btnDoubleBackWard.Name = "btnDoubleBackWard";
            this.btnDoubleBackWard.Size = new System.Drawing.Size(47, 33);
            this.btnDoubleBackWard.TabIndex = 19;
            this.btnDoubleBackWard.Text = "<<";
            this.btnDoubleBackWard.UseVisualStyleBackColor = true;
            this.btnDoubleBackWard.Click += new System.EventHandler(this.btnDoubleBackWard_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txt_Premium);
            this.panel1.Controls.Add(this.txtSessName);
            this.panel1.Controls.Add(this.txtTotalAmount);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtSessNoOfShare);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtSessAmount);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(416, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(398, 149);
            this.panel1.TabIndex = 24;
            // 
            // txt_Premium
            // 
            this.txt_Premium.Location = new System.Drawing.Point(127, 119);
            this.txt_Premium.Name = "txt_Premium";
            this.txt_Premium.ReadOnly = true;
            this.txt_Premium.Size = new System.Drawing.Size(124, 20);
            this.txt_Premium.TabIndex = 34;
            // 
            // txtSessName
            // 
            this.txtSessName.Location = new System.Drawing.Point(127, 10);
            this.txtSessName.Name = "txtSessName";
            this.txtSessName.ReadOnly = true;
            this.txtSessName.Size = new System.Drawing.Size(124, 20);
            this.txtSessName.TabIndex = 30;
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Location = new System.Drawing.Point(127, 93);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.ReadOnly = true;
            this.txtTotalAmount.Size = new System.Drawing.Size(124, 20);
            this.txtTotalAmount.TabIndex = 33;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Session Name";
            // 
            // txtSessNoOfShare
            // 
            this.txtSessNoOfShare.Location = new System.Drawing.Point(127, 67);
            this.txtSessNoOfShare.Name = "txtSessNoOfShare";
            this.txtSessNoOfShare.ReadOnly = true;
            this.txtSessNoOfShare.Size = new System.Drawing.Size(124, 20);
            this.txtSessNoOfShare.TabIndex = 32;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(72, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Amount";
            // 
            // txtSessAmount
            // 
            this.txtSessAmount.Location = new System.Drawing.Point(127, 41);
            this.txtSessAmount.Name = "txtSessAmount";
            this.txtSessAmount.ReadOnly = true;
            this.txtSessAmount.Size = new System.Drawing.Size(124, 20);
            this.txtSessAmount.TabIndex = 31;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(51, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "No of Share";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(48, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "TotalAmount";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(68, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "Premium";
            // 
            // btnImageVerify
            // 
            this.btnImageVerify.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImageVerify.ForeColor = System.Drawing.Color.Navy;
            this.btnImageVerify.Location = new System.Drawing.Point(469, 12);
            this.btnImageVerify.Name = "btnImageVerify";
            this.btnImageVerify.Size = new System.Drawing.Size(75, 23);
            this.btnImageVerify.TabIndex = 36;
            this.btnImageVerify.Text = "Verify";
            this.btnImageVerify.UseVisualStyleBackColor = true;
            this.btnImageVerify.Click += new System.EventHandler(this.btnImageVerify_Click);
            // 
            // btnVerify
            // 
            this.btnVerify.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerify.ForeColor = System.Drawing.Color.Navy;
            this.btnVerify.Location = new System.Drawing.Point(553, 13);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(75, 23);
            this.btnVerify.TabIndex = 35;
            this.btnVerify.Text = "Report";
            this.btnVerify.UseVisualStyleBackColor = true;
            this.btnVerify.Visible = false;
            this.btnVerify.Click += new System.EventHandler(this.btnVerify_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnVerify);
            this.panel2.Controls.Add(this.btnImageVerify);
            this.panel2.Controls.Add(this.btn_Process);
            this.panel2.Controls.Add(this.btn_Close);
            this.panel2.Location = new System.Drawing.Point(16, 588);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(798, 46);
            this.panel2.TabIndex = 25;
            // 
            // btn_Process
            // 
            this.btn_Process.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Process.ForeColor = System.Drawing.Color.Navy;
            this.btn_Process.Location = new System.Drawing.Point(633, 12);
            this.btn_Process.Name = "btn_Process";
            this.btn_Process.Size = new System.Drawing.Size(75, 23);
            this.btn_Process.TabIndex = 40;
            this.btn_Process.TabStop = false;
            this.btn_Process.Text = "Process";
            this.btn_Process.UseVisualStyleBackColor = true;
            this.btn_Process.Click += new System.EventHandler(this.btn_Process_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Close.ForeColor = System.Drawing.Color.Navy;
            this.btn_Close.Location = new System.Drawing.Point(711, 12);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(68, 23);
            this.btn_Close.TabIndex = 39;
            this.btn_Close.TabStop = false;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txt_Cust_Code_ForReturnTransferParent);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.cmb_RefundType);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.btnEligibleClient);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.cmb_CompanyName);
            this.panel3.Location = new System.Drawing.Point(16, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(394, 149);
            this.panel3.TabIndex = 26;
            // 
            // txt_Cust_Code_ForReturnTransferParent
            // 
            this.txt_Cust_Code_ForReturnTransferParent.Location = new System.Drawing.Point(140, 73);
            this.txt_Cust_Code_ForReturnTransferParent.Name = "txt_Cust_Code_ForReturnTransferParent";
            this.txt_Cust_Code_ForReturnTransferParent.Size = new System.Drawing.Size(114, 20);
            this.txt_Cust_Code_ForReturnTransferParent.TabIndex = 30;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(96, 76);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 29;
            this.label8.Text = "Code :";
            // 
            // cmb_RefundType
            // 
            this.cmb_RefundType.FormattingEnabled = true;
            this.cmb_RefundType.Location = new System.Drawing.Point(140, 45);
            this.cmb_RefundType.Name = "cmb_RefundType";
            this.cmb_RefundType.Size = new System.Drawing.Size(208, 21);
            this.cmb_RefundType.TabIndex = 28;
            this.cmb_RefundType.SelectedIndexChanged += new System.EventHandler(this.cmb_RefundType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Refund Type";
            // 
            // btnEligibleClient
            // 
            this.btnEligibleClient.Location = new System.Drawing.Point(282, 116);
            this.btnEligibleClient.Name = "btnEligibleClient";
            this.btnEligibleClient.Size = new System.Drawing.Size(109, 23);
            this.btnEligibleClient.TabIndex = 26;
            this.btnEligibleClient.Text = "Eligible Client Show";
            this.btnEligibleClient.UseVisualStyleBackColor = true;
            this.btnEligibleClient.Click += new System.EventHandler(this.btnEligibleClient_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(50, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "Company Name";
            // 
            // cmb_CompanyName
            // 
            this.cmb_CompanyName.FormattingEnabled = true;
            this.cmb_CompanyName.Location = new System.Drawing.Point(140, 18);
            this.cmb_CompanyName.Name = "cmb_CompanyName";
            this.cmb_CompanyName.Size = new System.Drawing.Size(208, 21);
            this.cmb_CompanyName.TabIndex = 24;
            this.cmb_CompanyName.SelectedIndexChanged += new System.EventHandler(this.cmb_CompanyName_SelectedIndexChanged);
            // 
            // dgv_FinalCheck
            // 
            this.dgv_FinalCheck.AllowUserToAddRows = false;
            this.dgv_FinalCheck.AllowUserToDeleteRows = false;
            this.dgv_FinalCheck.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_FinalCheck.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.F_CustCode,
            this.F_CustName,
            this.F_Balance,
            this.F_ApplyMoney});
            this.dgv_FinalCheck.Location = new System.Drawing.Point(445, 188);
            this.dgv_FinalCheck.Name = "dgv_FinalCheck";
            this.dgv_FinalCheck.ReadOnly = true;
            this.dgv_FinalCheck.RowHeadersVisible = false;
            this.dgv_FinalCheck.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_FinalCheck.Size = new System.Drawing.Size(369, 392);
            this.dgv_FinalCheck.TabIndex = 27;
            this.dgv_FinalCheck.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFinalCheck_CellClick);
            // 
            // F_CustCode
            // 
            this.F_CustCode.DataPropertyName = "Cust_Code";
            this.F_CustCode.HeaderText = "Code";
            this.F_CustCode.Name = "F_CustCode";
            this.F_CustCode.ReadOnly = true;
            this.F_CustCode.Width = 50;
            // 
            // F_CustName
            // 
            this.F_CustName.DataPropertyName = "Cust_Name";
            this.F_CustName.HeaderText = "Name";
            this.F_CustName.Name = "F_CustName";
            this.F_CustName.ReadOnly = true;
            this.F_CustName.Width = 150;
            // 
            // F_Balance
            // 
            this.F_Balance.DataPropertyName = "Balance";
            this.F_Balance.HeaderText = "Balance";
            this.F_Balance.Name = "F_Balance";
            this.F_Balance.ReadOnly = true;
            this.F_Balance.Width = 80;
            // 
            // F_ApplyMoney
            // 
            this.F_ApplyMoney.DataPropertyName = "ApplyMoney";
            this.F_ApplyMoney.HeaderText = "Apply Money";
            this.F_ApplyMoney.Name = "F_ApplyMoney";
            this.F_ApplyMoney.ReadOnly = true;
            // 
            // dgvExtension
            // 
            this.dgvExtension.DataGridView = this.dgvEligibleCustomer;
            defaultGridFilterFactory1.CreateDistinctGridFilters = false;
            defaultGridFilterFactory1.DefaultGridFilterType = typeof(GridViewExtensions.GridFilters.TextGridFilter);
            defaultGridFilterFactory1.DefaultShowDateInBetweenOperator = false;
            defaultGridFilterFactory1.DefaultShowNumericInBetweenOperator = false;
            defaultGridFilterFactory1.HandleEnumerationTypes = true;
            defaultGridFilterFactory1.MaximumDistinctValues = 20;
            this.dgvExtension.FilterFactory = defaultGridFilterFactory1;
            this.dgvExtension.FilterTextVisible = false;
            // 
            // dataGridFilterExtender1
            // 
            this.dataGridFilterExtender1.DataGridView = this.dgv_FinalCheck;
            defaultGridFilterFactory2.CreateDistinctGridFilters = false;
            defaultGridFilterFactory2.DefaultGridFilterType = typeof(GridViewExtensions.GridFilters.TextGridFilter);
            defaultGridFilterFactory2.DefaultShowDateInBetweenOperator = false;
            defaultGridFilterFactory2.DefaultShowNumericInBetweenOperator = false;
            defaultGridFilterFactory2.HandleEnumerationTypes = true;
            defaultGridFilterFactory2.MaximumDistinctValues = 20;
            this.dataGridFilterExtender1.FilterFactory = defaultGridFilterFactory2;
            this.dataGridFilterExtender1.FilterTextVisible = false;
            // 
            // frm_IPOApplicationProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 640);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgv_FinalCheck);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnsingleBackword);
            this.Controls.Add(this.btnDoubleBackWard);
            this.Controls.Add(this.btnSingleForward);
            this.Controls.Add(this.btnDoubleForward);
            this.Controls.Add(this.dgvEligibleCustomer);
            this.Name = "frm_IPOApplicationProcess";
            this.Text = "IPO Application Process";
            this.Load += new System.EventHandler(this.IpoApplicationProcess_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEligibleCustomer)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_FinalCheck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExtension)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFilterExtender1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEligibleCustomer;
        private System.Windows.Forms.Button btnDoubleForward;
        private System.Windows.Forms.Button btnSingleForward;
        private System.Windows.Forms.Button btnsingleBackword;
        private System.Windows.Forms.Button btnDoubleBackWard;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txt_Premium;
        private System.Windows.Forms.TextBox txtSessName;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSessNoOfShare;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSessAmount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_Process;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cmb_RefundType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEligibleClient;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmb_CompanyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cust_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Balance;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApplyMoney;
        private System.Windows.Forms.DataGridView dgv_FinalCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn F_CustCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn F_CustName;
        private System.Windows.Forms.DataGridViewTextBoxColumn F_Balance;
        private System.Windows.Forms.DataGridViewTextBoxColumn F_ApplyMoney;
        private System.Windows.Forms.TextBox txt_Cust_Code_ForReturnTransferParent;
        private System.Windows.Forms.Label label8;
        private GridViewExtensions.DataGridFilterExtender dgvExtension;
        private GridViewExtensions.DataGridFilterExtender dataGridFilterExtender1;
        private System.Windows.Forms.Button btnVerify;
        private System.Windows.Forms.Button btnImageVerify;
    }
}