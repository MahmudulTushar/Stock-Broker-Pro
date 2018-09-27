namespace NewArch
{
    partial class frmBatch2ndNomineeImgUploader
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBatch2ndNomineeImgUploader));
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnStartUpload = new System.Windows.Forms.Button();
            this.btnBrowseDirectory = new System.Windows.Forms.Button();
            this.txtImgDirectoryLocation = new System.Windows.Forms.TextBox();
            this.lblImgDireLocation = new System.Windows.Forms.Label();
            this.lblImageCount = new System.Windows.Forms.Label();
            this.dtgImUploadDirInfo = new System.Windows.Forms.DataGridView();
            this.lblImageDirctoryTitle = new System.Windows.Forms.Label();
            this.oflErrImgPath = new System.Windows.Forms.OpenFileDialog();
            this.fbdImageUpload = new System.Windows.Forms.FolderBrowserDialog();
            this.btnClose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgImUploadDirInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUploadProgress
            // 
            this.lblUploadProgress.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUploadProgress.ForeColor = System.Drawing.Color.Black;
            this.lblUploadProgress.Location = new System.Drawing.Point(12, 81);
            this.lblUploadProgress.Name = "lblUploadProgress";
            this.lblUploadProgress.Size = new System.Drawing.Size(515, 20);
            this.lblUploadProgress.TabIndex = 32;
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
            this.groupBox2.Location = new System.Drawing.Point(12, 129);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(515, 60);
            this.groupBox2.TabIndex = 31;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Upload Summary";
            // 
            // lblErrorImg
            // 
            this.lblErrorImg.AutoSize = true;
            this.lblErrorImg.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorImg.ForeColor = System.Drawing.Color.Black;
            this.lblErrorImg.Location = new System.Drawing.Point(365, 29);
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
            this.lblDuplicateImage.Location = new System.Drawing.Point(251, 29);
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
            this.lblUploadimage.Location = new System.Drawing.Point(146, 29);
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
            this.lblTotalImage.Location = new System.Drawing.Point(44, 29);
            this.lblTotalImage.Name = "lblTotalImage";
            this.lblTotalImage.Size = new System.Drawing.Size(35, 13);
            this.lblTotalImage.TabIndex = 0;
            this.lblTotalImage.Text = "label3";
            // 
            // pgbUpload
            // 
            this.pgbUpload.Location = new System.Drawing.Point(12, 102);
            this.pgbUpload.Name = "pgbUpload";
            this.pgbUpload.Size = new System.Drawing.Size(515, 18);
            this.pgbUpload.TabIndex = 30;
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
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(515, 60);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Image Upload";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = ":";
            // 
            // btnStartUpload
            // 
            this.btnStartUpload.Enabled = false;
            this.btnStartUpload.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartUpload.Image = ((System.Drawing.Image)(resources.GetObject("btnStartUpload.Image")));
            this.btnStartUpload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStartUpload.Location = new System.Drawing.Point(411, 23);
            this.btnStartUpload.Name = "btnStartUpload";
            this.btnStartUpload.Size = new System.Drawing.Size(94, 23);
            this.btnStartUpload.TabIndex = 1;
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
            this.btnBrowseDirectory.Location = new System.Drawing.Point(363, 23);
            this.btnBrowseDirectory.Name = "btnBrowseDirectory";
            this.btnBrowseDirectory.Size = new System.Drawing.Size(44, 23);
            this.btnBrowseDirectory.TabIndex = 0;
            this.btnBrowseDirectory.Text = "  ...";
            this.btnBrowseDirectory.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBrowseDirectory.UseVisualStyleBackColor = true;
            this.btnBrowseDirectory.Click += new System.EventHandler(this.btnBrowseDirectory_Click);
            // 
            // txtImgDirectoryLocation
            // 
            this.txtImgDirectoryLocation.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImgDirectoryLocation.Location = new System.Drawing.Point(71, 24);
            this.txtImgDirectoryLocation.Name = "txtImgDirectoryLocation";
            this.txtImgDirectoryLocation.ReadOnly = true;
            this.txtImgDirectoryLocation.Size = new System.Drawing.Size(287, 21);
            this.txtImgDirectoryLocation.TabIndex = 1;
            // 
            // lblImgDireLocation
            // 
            this.lblImgDireLocation.AutoSize = true;
            this.lblImgDireLocation.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImgDireLocation.Location = new System.Drawing.Point(11, 27);
            this.lblImgDireLocation.Name = "lblImgDireLocation";
            this.lblImgDireLocation.Size = new System.Drawing.Size(47, 13);
            this.lblImgDireLocation.TabIndex = 0;
            this.lblImgDireLocation.Text = "Location";
            // 
            // lblImageCount
            // 
            this.lblImageCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImageCount.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblImageCount.Location = new System.Drawing.Point(15, 192);
            this.lblImageCount.Name = "lblImageCount";
            this.lblImageCount.Size = new System.Drawing.Size(233, 23);
            this.lblImageCount.TabIndex = 28;
            this.lblImageCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.RoyalBlue;
            this.dtgImUploadDirInfo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgImUploadDirInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgImUploadDirInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dtgImUploadDirInfo.BackgroundColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
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
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgImUploadDirInfo.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtgImUploadDirInfo.GridColor = System.Drawing.Color.LightGray;
            this.dtgImUploadDirInfo.Location = new System.Drawing.Point(12, 244);
            this.dtgImUploadDirInfo.MultiSelect = false;
            this.dtgImUploadDirInfo.Name = "dtgImUploadDirInfo";
            this.dtgImUploadDirInfo.RowHeadersVisible = false;
            this.dtgImUploadDirInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgImUploadDirInfo.Size = new System.Drawing.Size(515, 104);
            this.dtgImUploadDirInfo.TabIndex = 27;
            // 
            // lblImageDirctoryTitle
            // 
            this.lblImageDirctoryTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblImageDirctoryTitle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImageDirctoryTitle.ForeColor = System.Drawing.Color.Black;
            this.lblImageDirctoryTitle.Location = new System.Drawing.Point(12, 218);
            this.lblImageDirctoryTitle.Name = "lblImageDirctoryTitle";
            this.lblImageDirctoryTitle.Size = new System.Drawing.Size(515, 26);
            this.lblImageDirctoryTitle.TabIndex = 26;
            this.lblImageDirctoryTitle.Text = "Error Log Information : 2nd Nominee Photo";
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
            this.btnClose.Location = new System.Drawing.Point(462, 359);
            this.btnClose.Name = "btnClose";
            this.btnClose.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnClose.Size = new System.Drawing.Size(65, 25);
            this.btnClose.TabIndex = 0;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(12, 359);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(321, 13);
            this.label2.TabIndex = 85;
            this.label2.Text = "*** Image File Name Should be 12345 Where 12345=Client Code";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(380, 359);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.button1.Size = new System.Drawing.Size(79, 25);
            this.button1.TabIndex = 86;
            this.button1.TabStop = false;
            this.button1.Text = "View Photo";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmBatch2ndNomineeImgUploader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 393);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblUploadProgress);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.pgbUpload);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblImageCount);
            this.Controls.Add(this.dtgImUploadDirInfo);
            this.Controls.Add(this.lblImageDirctoryTitle);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frmBatch2ndNomineeImgUploader";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "2nd Nominee Batch Image Uploader";
            this.Load += new System.EventHandler(this.frmBatch2ndNomineeImgUploader_Load);
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
        private System.Windows.Forms.Label lblImageCount;
        private System.Windows.Forms.DataGridView dtgImUploadDirInfo;
        private System.Windows.Forms.Label lblImageDirctoryTitle;
        private System.Windows.Forms.OpenFileDialog oflErrImgPath;
        private System.Windows.Forms.FolderBrowserDialog fbdImageUpload;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
    }
}