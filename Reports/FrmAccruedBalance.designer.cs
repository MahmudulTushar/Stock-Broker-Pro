namespace Reports
{
    partial class FrmAccruedBalance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAccruedBalance));
            this.btnReport = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtCustCode = new System.Windows.Forms.TextBox();
            this.label199 = new System.Windows.Forms.Label();
            this.txtAccountHolderName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAccountHolderBOId = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ddlSearchCustomer = new System.Windows.Forms.ComboBox();
            this.label198 = new System.Windows.Forms.Label();
            this.txtSearchCustomer = new System.Windows.Forms.TextBox();
            this.rbIndividual = new System.Windows.Forms.RadioButton();
            this.rbAll = new System.Windows.Forms.RadioButton();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnReport
            // 
            this.btnReport.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.Image = ((System.Drawing.Image)(resources.GetObject("btnReport.Image")));
            this.btnReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReport.Location = new System.Drawing.Point(217, 220);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(122, 24);
            this.btnReport.TabIndex = 6;
            this.btnReport.Text = "Get Report";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtToDate);
            this.groupBox2.Controls.Add(this.dtFromDate);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 160);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(327, 54);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Period";
            // 
            // dtToDate
            // 
            this.dtToDate.CustomFormat = "dd-MMM-yyyy";
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToDate.Location = new System.Drawing.Point(201, 21);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(110, 20);
            this.dtToDate.TabIndex = 3;
            // 
            // dtFromDate
            // 
            this.dtFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(69, 21);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(101, 20);
            this.dtFromDate.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(176, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "TO";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "FROM ";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtCustCode);
            this.groupBox3.Controls.Add(this.label199);
            this.groupBox3.Controls.Add(this.txtAccountHolderName);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.txtAccountHolderBOId);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(327, 142);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            // 
            // txtCustCode
            // 
            this.txtCustCode.Location = new System.Drawing.Point(149, 65);
            this.txtCustCode.Name = "txtCustCode";
            this.txtCustCode.ReadOnly = true;
            this.txtCustCode.Size = new System.Drawing.Size(166, 20);
            this.txtCustCode.TabIndex = 88;
            // 
            // label199
            // 
            this.label199.AutoSize = true;
            this.label199.Location = new System.Drawing.Point(15, 69);
            this.label199.Name = "label199";
            this.label199.Size = new System.Drawing.Size(79, 13);
            this.label199.TabIndex = 87;
            this.label199.Text = "Customer Code";
            // 
            // txtAccountHolderName
            // 
            this.txtAccountHolderName.Location = new System.Drawing.Point(149, 88);
            this.txtAccountHolderName.Name = "txtAccountHolderName";
            this.txtAccountHolderName.ReadOnly = true;
            this.txtAccountHolderName.Size = new System.Drawing.Size(166, 20);
            this.txtAccountHolderName.TabIndex = 86;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 13);
            this.label1.TabIndex = 85;
            this.label1.Text = "Name of Account Holder";
            // 
            // txtAccountHolderBOId
            // 
            this.txtAccountHolderBOId.Location = new System.Drawing.Point(149, 112);
            this.txtAccountHolderBOId.Name = "txtAccountHolderBOId";
            this.txtAccountHolderBOId.ReadOnly = true;
            this.txtAccountHolderBOId.Size = new System.Drawing.Size(166, 20);
            this.txtAccountHolderBOId.TabIndex = 84;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(15, 114);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(120, 13);
            this.label14.TabIndex = 83;
            this.label14.Text = "Account Holder\'s BO ID";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ddlSearchCustomer);
            this.groupBox1.Controls.Add(this.label198);
            this.groupBox1.Controls.Add(this.txtSearchCustomer);
            this.groupBox1.Location = new System.Drawing.Point(9, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(306, 53);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select";
            // 
            // ddlSearchCustomer
            // 
            this.ddlSearchCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlSearchCustomer.FormattingEnabled = true;
            this.ddlSearchCustomer.Items.AddRange(new object[] {
            "Customer Code",
            "BO Id"});
            this.ddlSearchCustomer.Location = new System.Drawing.Point(18, 20);
            this.ddlSearchCustomer.Name = "ddlSearchCustomer";
            this.ddlSearchCustomer.Size = new System.Drawing.Size(121, 21);
            this.ddlSearchCustomer.TabIndex = 1;
            // 
            // label198
            // 
            this.label198.AutoSize = true;
            this.label198.Location = new System.Drawing.Point(143, 23);
            this.label198.Name = "label198";
            this.label198.Size = new System.Drawing.Size(10, 13);
            this.label198.TabIndex = 1;
            this.label198.Text = ":";
            // 
            // txtSearchCustomer
            // 
            this.txtSearchCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchCustomer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtSearchCustomer.Location = new System.Drawing.Point(158, 20);
            this.txtSearchCustomer.Name = "txtSearchCustomer";
            this.txtSearchCustomer.Size = new System.Drawing.Size(142, 20);
            this.txtSearchCustomer.TabIndex = 0;
            this.txtSearchCustomer.TextChanged += new System.EventHandler(this.txtSearchCustomer_TextChanged);
            this.txtSearchCustomer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchCustomer_KeyDown);
            // 
            // rbIndividual
            // 
            this.rbIndividual.AutoSize = true;
            this.rbIndividual.Location = new System.Drawing.Point(12, 224);
            this.rbIndividual.Name = "rbIndividual";
            this.rbIndividual.Size = new System.Drawing.Size(70, 17);
            this.rbIndividual.TabIndex = 7;
            this.rbIndividual.TabStop = true;
            this.rbIndividual.Text = "Individual";
            this.rbIndividual.UseVisualStyleBackColor = true;
            this.rbIndividual.CheckedChanged += new System.EventHandler(this.rbIndividual_CheckedChanged);
            // 
            // rbAll
            // 
            this.rbAll.AutoSize = true;
            this.rbAll.Location = new System.Drawing.Point(104, 224);
            this.rbAll.Name = "rbAll";
            this.rbAll.Size = new System.Drawing.Size(82, 17);
            this.rbAll.TabIndex = 8;
            this.rbAll.TabStop = true;
            this.rbAll.Text = "All Togather";
            this.rbAll.UseVisualStyleBackColor = true;
            // 
            // FrmAccruedBalance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 259);
            this.Controls.Add(this.rbAll);
            this.Controls.Add(this.rbIndividual);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Name = "FrmAccruedBalance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmAccruedBalance";
            this.Load += new System.EventHandler(this.FrmAccruedBalance_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtCustCode;
        private System.Windows.Forms.Label label199;
        private System.Windows.Forms.TextBox txtAccountHolderName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAccountHolderBOId;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox ddlSearchCustomer;
        private System.Windows.Forms.Label label198;
        private System.Windows.Forms.TextBox txtSearchCustomer;
        private System.Windows.Forms.RadioButton rbIndividual;
        private System.Windows.Forms.RadioButton rbAll;
    }
}