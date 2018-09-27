namespace Reports
{
    partial class frmIPOApplicationForPublicIssue
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
            this.CmbCustCode = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CmbCompanyCode = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbSelectSignature = new System.Windows.Forms.ComboBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.CmbCompany = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // CmbCustCode
            // 
            this.CmbCustCode.FormattingEnabled = true;
            this.CmbCustCode.Location = new System.Drawing.Point(132, 21);
            this.CmbCustCode.Name = "CmbCustCode";
            this.CmbCustCode.Size = new System.Drawing.Size(121, 21);
            this.CmbCustCode.TabIndex = 0;
            this.CmbCustCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbCustCode_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CmbCompany);
            this.groupBox1.Controls.Add(this.CmbCustCode);
            this.groupBox1.Controls.Add(this.CmbCompanyCode);
            this.groupBox1.Location = new System.Drawing.Point(12, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 74);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Code and Company Name";
            // 
            // CmbCompanyCode
            // 
            this.CmbCompanyCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCompanyCode.FormattingEnabled = true;
            this.CmbCompanyCode.Items.AddRange(new object[] {
            "Cust Code",
            "Company Name",
            "Code and Company"});
            this.CmbCompanyCode.Location = new System.Drawing.Point(6, 21);
            this.CmbCompanyCode.Name = "CmbCompanyCode";
            this.CmbCompanyCode.Size = new System.Drawing.Size(104, 21);
            this.CmbCompanyCode.TabIndex = 1;
            this.CmbCompanyCode.SelectedIndexChanged += new System.EventHandler(this.CmbCompanyCode_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(24, 152);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Show";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(176, 152);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Close";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbSelectSignature);
            this.groupBox2.Location = new System.Drawing.Point(12, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(260, 60);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Signature or Without Signature";
            // 
            // cmbSelectSignature
            // 
            this.cmbSelectSignature.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSelectSignature.FormattingEnabled = true;
            this.cmbSelectSignature.Items.AddRange(new object[] {
            "Signature",
            "Without Signature"});
            this.cmbSelectSignature.Location = new System.Drawing.Point(32, 24);
            this.cmbSelectSignature.Name = "cmbSelectSignature";
            this.cmbSelectSignature.Size = new System.Drawing.Size(167, 21);
            this.cmbSelectSignature.TabIndex = 0;
            // 
            // CmbCompany
            // 
            this.CmbCompany.FormattingEnabled = true;
            this.CmbCompany.Location = new System.Drawing.Point(132, 48);
            this.CmbCompany.Name = "CmbCompany";
            this.CmbCompany.Size = new System.Drawing.Size(121, 21);
            this.CmbCompany.TabIndex = 2;
            // 
            // frmIPOApplicationForPublicIssue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 183);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmIPOApplicationForPublicIssue";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmIpoApplicationForPublicIssue";
            this.Load += new System.EventHandler(this.FrmIpoApplicationForPublicIssue_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox CmbCustCode;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox CmbCompanyCode;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbSelectSignature;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ComboBox CmbCompany;
    }
}