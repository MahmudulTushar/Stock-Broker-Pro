namespace NewArch
{
    partial class frmBatchPOAImgUploader
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBatchPOAImgUploader));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblUploadProgress = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblErrorImg = new System.Windows.Forms.Label();
            this.lblDuplicateImage = new System.Windows.Forms.Label();
            this.lblUploadimage = new System.Windows.Forms.Label();
            this.lblTotalImage = new System.Windows.Forms.Label();
            this.pgbUpload = new System.Windows.Forms.ProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnStartUpload = new System.Windows.Forms.Button();
            this.btnBrowseDirectory = new System.Windows.Forms.Button();
            this.txtImgDirectoryLocation = new System.Windows.Forms.TextBox();
            this.lblImgDireLocation = new System.Windows.Forms.Label();
            this.lblImageDirctoryTitle = new System.Windows.Forms.Label();
            this.fbdImageUpload = new System.Windows.Forms.FolderBrowserDialog();
            this.oflErrImgPath = new System.Windows.Forms.OpenFileDialog();
            this.btnClose = new System.Windows.Forms.Button();
            this.dtgImUploadDirInfo = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgImUploadDirInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUploadProgress
            // 
            this.lblUploadProgress.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUploadProgress.ForeColor = System.Drawing.Color.Black;
            this.lblUploadProgress.Location = new System.Drawing.Point(18, 74);
            this.lblUploadProgress.Name = "lblUploadProgress";
            this.lblUploadProgress.Size = new System.Drawing.Size(503, 20);
            this.lblUploadProgress.TabIndex = 39;
            this.lblUploadProgress.Text = "label2";
            this.lblUploadProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblUploadProgress.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblErrorImg);
            this.groupBox2.Controls.Add(this.lblDuplicateImage);
            this.groupBox2.Controls.Add(this.lblUploadimage);
            this.groupBox2.Controls.Add(this.lblTotalImage);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(18, 121);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(503, 60);
            this.groupBox2.TabIndex = 38;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Upload Summary";
            // 
            // lblErrorImg
            // 
            this.lblErrorImg.AutoSize = true;
            this.lblErrorImg.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorImg.ForeColor = System.Drawing.Color.Black;
            this.lblErrorImg.Location = new System.Drawing.Point(331, 30);
            this.lblErrorImg.Name = "lblErrorImg";
            this.lblErrorImg.Size = new System.Drawing.Size(35, 13);
            this.lblErrorImg.TabIndex = 3;
            this.lblErrorImg.Text = "label6";
            // 
            // lblDuplicateImage
            // 
            this.lblDuplicateImage.AutoSize = true;
            this.lblDuplicateImage.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDuplicateImage.ForeColor = System.Drawing.Color.Black;
            this.lblDuplicateImage.Location = new System.Drawing.Point(224, 30);
            this.lblDuplicateImage.Name = "lblDuplicateImage";
            this.lblDuplicateImage.Size = new System.Drawing.Size(35, 13);
            this.lblDuplicateImage.TabIndex = 2;
            this.lblDuplicateImage.Text = "label5";
            // 
            // lblUploadimage
            // 
            this.lblUploadimage.AutoSize = true;
            this.lblUploadimage.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUploadimage.ForeColor = System.Drawing.Color.Black;
            this.lblUploadimage.Location = new System.Drawing.Point(105, 30);
            this.lblUploadimage.Name = "lblUploadimage";
            this.lblUploadimage.Size = new System.Drawing.Size(35, 13);
            this.lblUploadimage.TabIndex = 1;
            this.lblUploadimage.Text = "label4";
            // 
            // lblTotalImage
            // 
            this.lblTotalImage.AutoSize = true;
            this.lblTotalImage.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalImage.ForeColor = System.Drawing.Color.Black;
            this.lblTotalImage.Location = new System.Drawing.Point(10, 30);
            this.lblTotalImage.Name = "lblTotalImage";
            this.lblTotalImage.Size = new System.Drawing.Size(35, 13);
            this.lblTotalImage.TabIndex = 0;
            this.lblTotalImage.Text = "label3";
            // 
            // pgbUpload
            // 
            this.pgbUpload.Location = new System.Drawing.Point(18, 96);
            this.pgbUpload.Name = "pgbUpload";
            this.pgbUpload.Size = new System.Drawing.Size(503, 18);
            this.pgbUpload.TabIndex = 37;
            this.pgbUpload.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnStartUpload);
            this.groupBox1.Controls.Add(this.btnBrowseDirectory);
            this.groupBox1.Controls.Add(this.txtImgDirectoryLocation);
            this.groupBox1.Controls.Add(this.lblImgDireLocation);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(509, 60);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Image Upload";
            // 
            // btnStartUpload
            // 
            this.btnStartUpload.Enabled = false;
            this.btnStartUpload.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartUpload.Image = ((System.Drawing.Image)(resources.GetObject("btnStartUpload.Image")));
            this.btnStartUpload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStartUpload.Location = new System.Drawing.Point(405, 22);
            this.btnStartUpload.Name = "btnStartUpload";
            this.btnStartUpload.Size = new System.Drawing.Size(89, 23);
            this.btnStartUpload.TabIndex = 2;
            this.btnStartUpload.Text = "Start Upload";
            this.btnStartUpload.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStartUpload.UseVisualStyleBackColor = true;
            this.btnStartUpload.Click += new System.EventHandler(this.btnStartUpload_Click);
            // 
            // btnBrowseDirectory
            // 
            this.btnBrowseDirectory.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseDirectory.Image = ((System.Drawing.Image)(resources.GetObject("btnBrowseDirectory.Image")));
            this.btnBrowseDirectory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBrowseDirectory.Location = new System.Drawing.Point(355, 22);
            this.btnBrowseDirectory.Name = "btnBrowseDirectory";
            this.btnBrowseDirectory.Size = new System.Drawing.Size(44, 23);
            this.btnBrowseDirectory.TabIndex = 2;
            this.btnBrowseDirectory.Text = "  ...";
            this.btnBrowseDirectory.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBrowseDirectory.UseVisualStyleBackColor = true;
            this.btnBrowseDirectory.Click += new System.EventHandler(this.btnBrowseDirectory_Click);
            // 
            // txtImgDirectoryLocation
            // 
            this.txtImgDirectoryLocation.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImgDirectoryLocation.Location = new System.Drawing.Point(76, 24);
            this.txtImgDirectoryLocation.Name = "txtImgDirectoryLocation";
            this.txtImgDirectoryLocation.ReadOnly = true;
            this.txtImgDirectoryLocation.Size = new System.Drawing.Size(273, 21);
            this.txtImgDirectoryLocation.TabIndex = 1;
            // 
            // lblImgDireLocation
            // 
            this.lblImgDireLocation.AutoSize = true;
            this.lblImgDireLocation.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImgDireLocation.Location = new System.Drawing.Point(19, 27);
            this.lblImgDireLocation.Name = "lblImgDireLocation";
            this.lblImgDireLocation.Size = new System.Drawing.Size(47, 13);
            this.lblImgDireLocation.TabIndex = 0;
            this.lblImgDireLocation.Text = "Location";
            // 
            // lblImageDirctoryTitle
            // 
            this.lblImageDirctoryTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblImageDirctoryTitle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImageDirctoryTitle.ForeColor = System.Drawing.Color.Black;
            this.lblImageDirctoryTitle.Location = new System.Drawing.Point(11, 209);
            this.lblImageDirctoryTitle.Name = "lblImageDirctoryTitle";
            this.lblImageDirctoryTitle.Size = new System.Drawing.Size(510, 26);
            this.lblImageDirctoryTitle.TabIndex = 33;
            this.lblImageDirctoryTitle.Text = "Error Log Information : Power of Attornay Photo";
            this.lblImageDirctoryTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // oflErrImgPath
            // 
            this.oflErrImgPath.FileName = "openFileDialog1";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(459, 348);
            this.btnClose.Name = "btnClose";
            this.btnClose.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnClose.Size = new System.Drawing.Size(61, 25);
            this.btnClose.TabIndex = 83;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dtgImUploadDirInfo
            // 
            this.dtgImUploadDirInfo.AllowUserToAddRows = false;
            this.dtgImUploadDirInfo.AllowUserToDeleteRows = false;
            this.dtgImUploadDirInfo.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Blue;
            this.dtgImUploadDirInfo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgImUploadDirInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgImUploadDirInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dtgImUploadDirInfo.BackgroundColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgImUploadDirInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgImUploadDirInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgImUploadDirInfo.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtgImUploadDirInfo.GridColor = System.Drawing.Color.Silver;
            this.dtgImUploadDirInfo.Location = new System.Drawing.Point(11, 235);
            this.dtgImUploadDirInfo.MultiSelect = false;
            this.dtgImUploadDirInfo.Name = "dtgImUploadDirInfo";
            this.dtgImUploadDirInfo.ReadOnly = true;
            this.dtgImUploadDirInfo.RowHeadersVisible = false;
            this.dtgImUploadDirInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgImUploadDirInfo.Size = new System.Drawing.Size(510, 107);
            this.dtgImUploadDirInfo.TabIndex = 84;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(9, 348);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(321, 13);
            this.label2.TabIndex = 89;
            this.label2.Text = "*** Image File Name Should be 12345 Where 12345=Client Code";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(369, 348);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.button1.Size = new System.Drawing.Size(84, 25);
            this.button1.TabIndex = 90;
            this.button1.TabStop = false;
            this.button1.Text = "View Photo";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 13);
            this.label1.TabIndex = 91;
            this.label1.Text = ":";
            // 
            // frmBatchPOAImgUploader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 381);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtgImUploadDirInfo);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblUploadProgress);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.pgbUpload);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblImageDirctoryTitle);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frmBatchPOAImgUploader";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Power OF Attornay Image Uploader";
            this.Load += new System.EventHandler(this.frmBatchPOAImgUploader_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgImUploadDirInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUploadProgress;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblErrorImg;
        private System.Windows.Forms.Label lblDuplicateImage;
        private System.Windows.Forms.Label lblUploadimage;
        private System.Windows.Forms.Label lblTotalImage;
        private System.Windows.Forms.ProgressBar pgbUpload;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnStartUpload;
        private System.Windows.Forms.Button btnBrowseDirectory;
        private System.Windows.Forms.TextBox txtImgDirectoryLocation;
        private System.Windows.Forms.Label lblImgDireLocation;
        private System.Windows.Forms.Label lblImageDirctoryTitle;
        private System.Windows.Forms.FolderBrowserDialog fbdImageUpload;
        private System.Windows.Forms.OpenFileDialog oflErrImgPath;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dtgImUploadDirInfo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
    }
}