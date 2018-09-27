namespace StockbrokerProNewArch
{
    partial class BrokerInfoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BrokerInfoForm));
            this.dtOpenDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtCDBLParticipantID = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.ddlExchangeName = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtTradeID = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtBrokerBOId = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ofdLogo = new System.Windows.Forms.OpenFileDialog();
            this.ofdDirectorSign = new System.Windows.Forms.OpenFileDialog();
            this.ofdDefaultSign = new System.Windows.Forms.OpenFileDialog();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnLogoUpload = new System.Windows.Forms.Button();
            this.picLogoImage = new System.Windows.Forms.PictureBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnUploadDirSign = new System.Windows.Forms.Button();
            this.picDirectorSign = new System.Windows.Forms.PictureBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnDefaultSign = new System.Windows.Forms.Button();
            this.picDefaultSign = new System.Windows.Forms.PictureBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoImage)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDirectorSign)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDefaultSign)).BeginInit();
            this.SuspendLayout();
            // 
            // dtOpenDate
            // 
            this.dtOpenDate.CustomFormat = "dd-MMM-yyyy";
            this.dtOpenDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtOpenDate.Location = new System.Drawing.Point(202, 145);
            this.dtOpenDate.Name = "dtOpenDate";
            this.dtOpenDate.Size = new System.Drawing.Size(102, 20);
            this.dtOpenDate.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Gray;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(46, 145);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label2.Size = new System.Drawing.Size(150, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Opening Date";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Gray;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(46, 25);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label1.Size = new System.Drawing.Size(150, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Broker House Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.txtCDBLParticipantID);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.ddlExchangeName);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtTradeID);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtBrokerBOId);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dtOpenDate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(443, 186);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Brokerage Information Setup";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(202, 25);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(201, 20);
            this.txtName.TabIndex = 0;
            // 
            // txtCDBLParticipantID
            // 
            this.txtCDBLParticipantID.Location = new System.Drawing.Point(202, 97);
            this.txtCDBLParticipantID.Name = "txtCDBLParticipantID";
            this.txtCDBLParticipantID.Size = new System.Drawing.Size(102, 20);
            this.txtCDBLParticipantID.TabIndex = 3;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.Gray;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(46, 97);
            this.label12.Name = "label12";
            this.label12.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label12.Size = new System.Drawing.Size(150, 20);
            this.label12.TabIndex = 26;
            this.label12.Text = "CDBL Participant ID";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ddlExchangeName
            // 
            this.ddlExchangeName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlExchangeName.FormattingEnabled = true;
            this.ddlExchangeName.Items.AddRange(new object[] {
            "DSE",
            "CSE"});
            this.ddlExchangeName.Location = new System.Drawing.Point(202, 121);
            this.ddlExchangeName.Name = "ddlExchangeName";
            this.ddlExchangeName.Size = new System.Drawing.Size(102, 21);
            this.ddlExchangeName.TabIndex = 4;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Gray;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(46, 121);
            this.label11.Name = "label11";
            this.label11.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label11.Size = new System.Drawing.Size(150, 20);
            this.label11.TabIndex = 24;
            this.label11.Text = "Exchange Name";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTradeID
            // 
            this.txtTradeID.Location = new System.Drawing.Point(202, 73);
            this.txtTradeID.Name = "txtTradeID";
            this.txtTradeID.Size = new System.Drawing.Size(102, 20);
            this.txtTradeID.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Gray;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(46, 73);
            this.label10.Name = "label10";
            this.label10.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label10.Size = new System.Drawing.Size(150, 20);
            this.label10.TabIndex = 22;
            this.label10.Text = "Trading ID";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtBrokerBOId
            // 
            this.txtBrokerBOId.Location = new System.Drawing.Point(202, 49);
            this.txtBrokerBOId.MaxLength = 8;
            this.txtBrokerBOId.Name = "txtBrokerBOId";
            this.txtBrokerBOId.Size = new System.Drawing.Size(102, 20);
            this.txtBrokerBOId.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Gray;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(46, 49);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label5.Size = new System.Drawing.Size(150, 20);
            this.label5.TabIndex = 15;
            this.label5.Text = "Broker BO ID (8 digit)";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ofdLogo
            // 
            this.ofdLogo.FileName = "openFileDialog1";
            this.ofdLogo.Filter = "Image Files (*.bmp, *.jpg)|*.bmp;*.jpg";
            // 
            // ofdDirectorSign
            // 
            this.ofdDirectorSign.FileName = "openFileDialog1";
            this.ofdDirectorSign.Filter = "Image Files (*.bmp, *.jpg)|*.bmp;*.jpg";
            // 
            // ofdDefaultSign
            // 
            this.ofdDefaultSign.FileName = "openFileDialog1";
            this.ofdDefaultSign.Filter = "Image Files (*.bmp, *.jpg)|*.bmp;*.jpg";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnLogoUpload);
            this.groupBox3.Controls.Add(this.picLogoImage);
            this.groupBox3.Location = new System.Drawing.Point(13, 204);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(145, 163);
            this.groupBox3.TabIndex = 22;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Logo";
            // 
            // btnLogoUpload
            // 
            this.btnLogoUpload.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogoUpload.ForeColor = System.Drawing.Color.DimGray;
            this.btnLogoUpload.Image = ((System.Drawing.Image)(resources.GetObject("btnLogoUpload.Image")));
            this.btnLogoUpload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogoUpload.Location = new System.Drawing.Point(20, 125);
            this.btnLogoUpload.Name = "btnLogoUpload";
            this.btnLogoUpload.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnLogoUpload.Size = new System.Drawing.Size(100, 25);
            this.btnLogoUpload.TabIndex = 0;
            this.btnLogoUpload.TabStop = false;
            this.btnLogoUpload.Text = "Change";
            this.btnLogoUpload.UseVisualStyleBackColor = true;
            this.btnLogoUpload.Click += new System.EventHandler(this.btnLogoUpload_Click);
            // 
            // picLogoImage
            // 
            this.picLogoImage.Location = new System.Drawing.Point(20, 19);
            this.picLogoImage.Name = "picLogoImage";
            this.picLogoImage.Size = new System.Drawing.Size(100, 100);
            this.picLogoImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogoImage.TabIndex = 17;
            this.picLogoImage.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnUploadDirSign);
            this.groupBox4.Controls.Add(this.picDirectorSign);
            this.groupBox4.Location = new System.Drawing.Point(164, 204);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(143, 163);
            this.groupBox4.TabIndex = 22;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Signature of Director";
            // 
            // btnUploadDirSign
            // 
            this.btnUploadDirSign.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUploadDirSign.ForeColor = System.Drawing.Color.DimGray;
            this.btnUploadDirSign.Image = ((System.Drawing.Image)(resources.GetObject("btnUploadDirSign.Image")));
            this.btnUploadDirSign.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUploadDirSign.Location = new System.Drawing.Point(21, 125);
            this.btnUploadDirSign.Name = "btnUploadDirSign";
            this.btnUploadDirSign.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnUploadDirSign.Size = new System.Drawing.Size(100, 25);
            this.btnUploadDirSign.TabIndex = 0;
            this.btnUploadDirSign.TabStop = false;
            this.btnUploadDirSign.Text = "Change";
            this.btnUploadDirSign.UseVisualStyleBackColor = true;
            this.btnUploadDirSign.Click += new System.EventHandler(this.btnUploadDirSign_Click);
            // 
            // picDirectorSign
            // 
            this.picDirectorSign.Location = new System.Drawing.Point(21, 19);
            this.picDirectorSign.Name = "picDirectorSign";
            this.picDirectorSign.Size = new System.Drawing.Size(100, 100);
            this.picDirectorSign.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picDirectorSign.TabIndex = 19;
            this.picDirectorSign.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnDefaultSign);
            this.groupBox5.Controls.Add(this.picDefaultSign);
            this.groupBox5.Location = new System.Drawing.Point(313, 204);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(143, 163);
            this.groupBox5.TabIndex = 22;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Default Signature";
            // 
            // btnDefaultSign
            // 
            this.btnDefaultSign.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDefaultSign.ForeColor = System.Drawing.Color.DimGray;
            this.btnDefaultSign.Image = ((System.Drawing.Image)(resources.GetObject("btnDefaultSign.Image")));
            this.btnDefaultSign.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDefaultSign.Location = new System.Drawing.Point(22, 125);
            this.btnDefaultSign.Name = "btnDefaultSign";
            this.btnDefaultSign.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnDefaultSign.Size = new System.Drawing.Size(100, 25);
            this.btnDefaultSign.TabIndex = 0;
            this.btnDefaultSign.TabStop = false;
            this.btnDefaultSign.Text = "Change";
            this.btnDefaultSign.UseVisualStyleBackColor = true;
            this.btnDefaultSign.Click += new System.EventHandler(this.btnDefaultSign_Click);
            // 
            // picDefaultSign
            // 
            this.picDefaultSign.Location = new System.Drawing.Point(22, 19);
            this.picDefaultSign.Name = "picDefaultSign";
            this.picDefaultSign.Size = new System.Drawing.Size(100, 100);
            this.picDefaultSign.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picDefaultSign.TabIndex = 21;
            this.picDefaultSign.TabStop = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.Image")));
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.Location = new System.Drawing.Point(264, 373);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnUpdate.Size = new System.Drawing.Size(96, 25);
            this.btnUpdate.TabIndex = 0;
            this.btnUpdate.TabStop = false;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(366, 373);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnCancel.Size = new System.Drawing.Size(90, 25);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Close";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // BrokerInfoForm
            // 
            this.AcceptButton = this.btnUpdate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 403);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "BrokerInfoForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Brokerage Information Setup";
            this.Load += new System.EventHandler(this.BrokerInfoForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogoImage)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picDirectorSign)).EndInit();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picDefaultSign)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.OpenFileDialog ofdLogo;
        private System.Windows.Forms.OpenFileDialog ofdDirectorSign;
        private System.Windows.Forms.OpenFileDialog ofdDefaultSign;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnLogoUpload;
        private System.Windows.Forms.Button btnUploadDirSign;
        private System.Windows.Forms.Button btnDefaultSign;
        public System.Windows.Forms.PictureBox picDefaultSign;
        public System.Windows.Forms.PictureBox picDirectorSign;
        public System.Windows.Forms.PictureBox picLogoImage;
        public System.Windows.Forms.DateTimePicker dtOpenDate;
        public System.Windows.Forms.TextBox txtBrokerBOId;
        public System.Windows.Forms.ComboBox ddlExchangeName;
        public System.Windows.Forms.TextBox txtTradeID;
        public System.Windows.Forms.TextBox txtCDBLParticipantID;
        public System.Windows.Forms.TextBox txtName;
    }
}