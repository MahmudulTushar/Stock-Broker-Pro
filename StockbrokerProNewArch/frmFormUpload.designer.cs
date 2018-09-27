namespace NewArch
{
    partial class frmFormUpload
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFormUpload));
            this.ofdImgLocation = new System.Windows.Forms.OpenFileDialog();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label199 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAccountHolderBOId = new System.Windows.Forms.TextBox();
            this.txtCustCode = new System.Windows.Forms.TextBox();
            this.txtAccountHolderName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.label198 = new System.Windows.Forms.Label();
            this.ddlSearchCustomer = new System.Windows.Forms.ComboBox();
            this.txtSearchCustomer = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnFormUpload = new System.Windows.Forms.Button();
            this.btnFormBrowse = new System.Windows.Forms.Button();
            this.txtImgLocation = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtImgPurpose = new System.Windows.Forms.TextBox();
            this.lblImgPurpose = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ofdImgLocation
            // 
            this.ofdImgLocation.FileName = "Form File Dialog";
            this.ofdImgLocation.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.JPEG;*.PNG)|*.BMP;*.JPG;*.GIF;*.JPEG;*.PNG";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label199);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.txtAccountHolderBOId);
            this.groupBox3.Controls.Add(this.txtCustCode);
            this.groupBox3.Controls.Add(this.txtAccountHolderName);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(234, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(366, 94);
            this.groupBox3.TabIndex = 80;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Selected Account Information";
            // 
            // label199
            // 
            this.label199.BackColor = System.Drawing.Color.Gray;
            this.label199.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label199.ForeColor = System.Drawing.Color.White;
            this.label199.Location = new System.Drawing.Point(17, 16);
            this.label199.Name = "label199";
            this.label199.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label199.Size = new System.Drawing.Size(149, 20);
            this.label199.TabIndex = 61;
            this.label199.Text = "Account Code";
            this.label199.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Gray;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(17, 39);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label2.Size = new System.Drawing.Size(149, 20);
            this.label2.TabIndex = 34;
            this.label2.Text = "Account Holder\'s Name";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAccountHolderBOId
            // 
            this.txtAccountHolderBOId.BackColor = System.Drawing.Color.LightGray;
            this.txtAccountHolderBOId.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccountHolderBOId.ForeColor = System.Drawing.Color.Navy;
            this.txtAccountHolderBOId.Location = new System.Drawing.Point(187, 63);
            this.txtAccountHolderBOId.Name = "txtAccountHolderBOId";
            this.txtAccountHolderBOId.ReadOnly = true;
            this.txtAccountHolderBOId.Size = new System.Drawing.Size(160, 21);
            this.txtAccountHolderBOId.TabIndex = 2;
            this.txtAccountHolderBOId.TabStop = false;
            // 
            // txtCustCode
            // 
            this.txtCustCode.BackColor = System.Drawing.Color.LightGray;
            this.txtCustCode.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustCode.ForeColor = System.Drawing.Color.Navy;
            this.txtCustCode.Location = new System.Drawing.Point(187, 16);
            this.txtCustCode.Name = "txtCustCode";
            this.txtCustCode.ReadOnly = true;
            this.txtCustCode.Size = new System.Drawing.Size(160, 21);
            this.txtCustCode.TabIndex = 62;
            this.txtCustCode.TabStop = false;
            // 
            // txtAccountHolderName
            // 
            this.txtAccountHolderName.BackColor = System.Drawing.Color.LightGray;
            this.txtAccountHolderName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccountHolderName.ForeColor = System.Drawing.Color.Navy;
            this.txtAccountHolderName.Location = new System.Drawing.Point(187, 39);
            this.txtAccountHolderName.Name = "txtAccountHolderName";
            this.txtAccountHolderName.ReadOnly = true;
            this.txtAccountHolderName.Size = new System.Drawing.Size(160, 21);
            this.txtAccountHolderName.TabIndex = 35;
            this.txtAccountHolderName.TabStop = false;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Gray;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(17, 63);
            this.label9.Name = "label9";
            this.label9.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label9.Size = new System.Drawing.Size(149, 20);
            this.label9.TabIndex = 0;
            this.label9.Text = "Account Holder\'s BO ID";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.btnGo);
            this.groupBox4.Controls.Add(this.label198);
            this.groupBox4.Controls.Add(this.ddlSearchCustomer);
            this.groupBox4.Controls.Add(this.txtSearchCustomer);
            this.groupBox4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(13, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(214, 94);
            this.groupBox4.TabIndex = 79;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Account Selection";
            // 
            // btnGo
            // 
            this.btnGo.Image = ((System.Drawing.Image)(resources.GetObject("btnGo.Image")));
            this.btnGo.Location = new System.Drawing.Point(156, 53);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(42, 23);
            this.btnGo.TabIndex = 62;
            this.btnGo.TabStop = false;
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // label198
            // 
            this.label198.AutoSize = true;
            this.label198.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label198.Location = new System.Drawing.Point(12, 31);
            this.label198.Name = "label198";
            this.label198.Size = new System.Drawing.Size(51, 13);
            this.label198.TabIndex = 61;
            this.label198.Text = "Select By";
            // 
            // ddlSearchCustomer
            // 
            this.ddlSearchCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlSearchCustomer.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlSearchCustomer.FormattingEnabled = true;
            this.ddlSearchCustomer.Items.AddRange(new object[] {
            "Customer Code",
            "BO Id"});
            this.ddlSearchCustomer.Location = new System.Drawing.Point(77, 28);
            this.ddlSearchCustomer.Name = "ddlSearchCustomer";
            this.ddlSearchCustomer.Size = new System.Drawing.Size(121, 21);
            this.ddlSearchCustomer.TabIndex = 1;
            // 
            // txtSearchCustomer
            // 
            this.txtSearchCustomer.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchCustomer.ForeColor = System.Drawing.Color.DarkGreen;
            this.txtSearchCustomer.Location = new System.Drawing.Point(16, 55);
            this.txtSearchCustomer.Name = "txtSearchCustomer";
            this.txtSearchCustomer.Size = new System.Drawing.Size(134, 21);
            this.txtSearchCustomer.TabIndex = 2;
            this.txtSearchCustomer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchCustomer_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnFormUpload);
            this.groupBox1.Controls.Add(this.btnFormBrowse);
            this.groupBox1.Controls.Add(this.txtImgLocation);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtImgPurpose);
            this.groupBox1.Controls.Add(this.lblImgPurpose);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(15, 114);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(585, 90);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Form Upload";
            // 
            // btnFormUpload
            // 
            this.btnFormUpload.Enabled = false;
            this.btnFormUpload.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFormUpload.Image = ((System.Drawing.Image)(resources.GetObject("btnFormUpload.Image")));
            this.btnFormUpload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFormUpload.Location = new System.Drawing.Point(456, 47);
            this.btnFormUpload.Name = "btnFormUpload";
            this.btnFormUpload.Size = new System.Drawing.Size(85, 25);
            this.btnFormUpload.TabIndex = 5;
            this.btnFormUpload.Text = "Upload";
            this.btnFormUpload.UseVisualStyleBackColor = true;
            this.btnFormUpload.Click += new System.EventHandler(this.btnFormUpload_Click);
            // 
            // btnFormBrowse
            // 
            this.btnFormBrowse.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFormBrowse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFormBrowse.Location = new System.Drawing.Point(412, 48);
            this.btnFormBrowse.Name = "btnFormBrowse";
            this.btnFormBrowse.Size = new System.Drawing.Size(37, 23);
            this.btnFormBrowse.TabIndex = 1;
            this.btnFormBrowse.Text = "  ...";
            this.btnFormBrowse.UseVisualStyleBackColor = true;
            this.btnFormBrowse.Click += new System.EventHandler(this.btnFormBrowse_Click);
            // 
            // txtImgLocation
            // 
            this.txtImgLocation.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImgLocation.Location = new System.Drawing.Point(191, 49);
            this.txtImgLocation.Name = "txtImgLocation";
            this.txtImgLocation.ReadOnly = true;
            this.txtImgLocation.Size = new System.Drawing.Size(210, 21);
            this.txtImgLocation.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(67, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Form File Location";
            // 
            // txtImgPurpose
            // 
            this.txtImgPurpose.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImgPurpose.Location = new System.Drawing.Point(191, 24);
            this.txtImgPurpose.Name = "txtImgPurpose";
            this.txtImgPurpose.Size = new System.Drawing.Size(210, 21);
            this.txtImgPurpose.TabIndex = 1;
            // 
            // lblImgPurpose
            // 
            this.lblImgPurpose.AutoSize = true;
            this.lblImgPurpose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImgPurpose.Location = new System.Drawing.Point(67, 27);
            this.lblImgPurpose.Name = "lblImgPurpose";
            this.lblImgPurpose.Size = new System.Drawing.Size(75, 13);
            this.lblImgPurpose.TabIndex = 2;
            this.lblImgPurpose.Text = "Form Purpose ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(171, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(10, 13);
            this.label4.TabIndex = 87;
            this.label4.Text = ":";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(171, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 13);
            this.label3.TabIndex = 86;
            this.label3.Text = ":";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(514, 210);
            this.btnClose.Name = "btnClose";
            this.btnClose.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnClose.Size = new System.Drawing.Size(86, 26);
            this.btnClose.TabIndex = 85;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(63, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(10, 13);
            this.label5.TabIndex = 88;
            this.label5.Text = ":";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(173, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(10, 13);
            this.label6.TabIndex = 88;
            this.label6.Text = ":";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(173, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(10, 13);
            this.label7.TabIndex = 88;
            this.label7.Text = ":";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(172, 67);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(10, 13);
            this.label8.TabIndex = 88;
            this.label8.Text = ":";
            // 
            // frmFormUpload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 242);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frmFormUpload";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form Uploader";
            this.Load += new System.EventHandler(this.frmFormUpload_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog ofdImgLocation;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label199;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtAccountHolderBOId;
        public System.Windows.Forms.TextBox txtCustCode;
        public System.Windows.Forms.TextBox txtAccountHolderName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Label label198;
        public System.Windows.Forms.ComboBox ddlSearchCustomer;
        public System.Windows.Forms.TextBox txtSearchCustomer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnFormUpload;
        private System.Windows.Forms.Button btnFormBrowse;
        private System.Windows.Forms.TextBox txtImgLocation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtImgPurpose;
        private System.Windows.Forms.Label lblImgPurpose;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
    }
}