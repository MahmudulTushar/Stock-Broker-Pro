namespace StockbrokerProNewArch
{
    partial class ImageMainForm
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
            this.mspImageUploader = new System.Windows.Forms.MenuStrip();
            this.singleImageUploaderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountHolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.signatureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.othersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.batchImageUploaderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.photoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.signatureToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.imageViewerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.phToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.signatureToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.othersToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.applicationFormGenerationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.mspImageUploader.SuspendLayout();
            this.SuspendLayout();
            // 
            // mspImageUploader
            // 
            this.mspImageUploader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mspImageUploader.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.singleImageUploaderToolStripMenuItem,
            this.batchImageUploaderToolStripMenuItem,
            this.imageViewerToolStripMenuItem,
            this.applicationFormGenerationToolStripMenuItem});
            this.mspImageUploader.Location = new System.Drawing.Point(0, 0);
            this.mspImageUploader.MdiWindowListItem = this.batchImageUploaderToolStripMenuItem;
            this.mspImageUploader.Name = "mspImageUploader";
            this.mspImageUploader.Size = new System.Drawing.Size(784, 24);
            this.mspImageUploader.TabIndex = 0;
            this.mspImageUploader.Text = "menuStrip1";
            // 
            // singleImageUploaderToolStripMenuItem
            // 
            this.singleImageUploaderToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accountHolderToolStripMenuItem,
            this.signatureToolStripMenuItem,
            this.toolStripSeparator1,
            this.othersToolStripMenuItem});
            this.singleImageUploaderToolStripMenuItem.Name = "singleImageUploaderToolStripMenuItem";
            this.singleImageUploaderToolStripMenuItem.Size = new System.Drawing.Size(126, 20);
            this.singleImageUploaderToolStripMenuItem.Text = "Single Image Uploader";
            // 
            // accountHolderToolStripMenuItem
            // 
            this.accountHolderToolStripMenuItem.Name = "accountHolderToolStripMenuItem";
            this.accountHolderToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.accountHolderToolStripMenuItem.Text = "Single Photo Upload";
            this.accountHolderToolStripMenuItem.Click += new System.EventHandler(this.accountHolderToolStripMenuItem_Click);
            // 
            // signatureToolStripMenuItem
            // 
            this.signatureToolStripMenuItem.Name = "signatureToolStripMenuItem";
            this.signatureToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.signatureToolStripMenuItem.Text = "Single Signature Upload";
            this.signatureToolStripMenuItem.Click += new System.EventHandler(this.signatureToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(185, 6);
            // 
            // othersToolStripMenuItem
            // 
            this.othersToolStripMenuItem.Name = "othersToolStripMenuItem";
            this.othersToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.othersToolStripMenuItem.Text = "Others";
            this.othersToolStripMenuItem.Click += new System.EventHandler(this.othersToolStripMenuItem_Click);
            // 
            // batchImageUploaderToolStripMenuItem
            // 
            this.batchImageUploaderToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.photoToolStripMenuItem,
            this.signatureToolStripMenuItem1});
            this.batchImageUploaderToolStripMenuItem.Name = "batchImageUploaderToolStripMenuItem";
            this.batchImageUploaderToolStripMenuItem.Size = new System.Drawing.Size(125, 20);
            this.batchImageUploaderToolStripMenuItem.Text = "Batch Image Uploader";
            // 
            // photoToolStripMenuItem
            // 
            this.photoToolStripMenuItem.Name = "photoToolStripMenuItem";
            this.photoToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.photoToolStripMenuItem.Text = "Batch Photo Upload";
            this.photoToolStripMenuItem.Click += new System.EventHandler(this.photoToolStripMenuItem_Click);
            // 
            // signatureToolStripMenuItem1
            // 
            this.signatureToolStripMenuItem1.Name = "signatureToolStripMenuItem1";
            this.signatureToolStripMenuItem1.Size = new System.Drawing.Size(187, 22);
            this.signatureToolStripMenuItem1.Text = "Batch Signature Upload";
            this.signatureToolStripMenuItem1.Click += new System.EventHandler(this.signatureToolStripMenuItem1_Click);
            // 
            // imageViewerToolStripMenuItem
            // 
            this.imageViewerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.phToolStripMenuItem,
            this.signatureToolStripMenuItem2,
            this.othersToolStripMenuItem1});
            this.imageViewerToolStripMenuItem.Name = "imageViewerToolStripMenuItem";
            this.imageViewerToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.imageViewerToolStripMenuItem.Text = "Image Viewer";
            // 
            // phToolStripMenuItem
            // 
            this.phToolStripMenuItem.Name = "phToolStripMenuItem";
            this.phToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.phToolStripMenuItem.Text = "Photo";
            this.phToolStripMenuItem.Click += new System.EventHandler(this.phToolStripMenuItem_Click);
            // 
            // signatureToolStripMenuItem2
            // 
            this.signatureToolStripMenuItem2.Name = "signatureToolStripMenuItem2";
            this.signatureToolStripMenuItem2.Size = new System.Drawing.Size(119, 22);
            this.signatureToolStripMenuItem2.Text = "Signature";
            this.signatureToolStripMenuItem2.Click += new System.EventHandler(this.signatureToolStripMenuItem2_Click);
            // 
            // othersToolStripMenuItem1
            // 
            this.othersToolStripMenuItem1.Name = "othersToolStripMenuItem1";
            this.othersToolStripMenuItem1.Size = new System.Drawing.Size(119, 22);
            this.othersToolStripMenuItem1.Text = "Others";
            this.othersToolStripMenuItem1.Click += new System.EventHandler(this.othersToolStripMenuItem1_Click);
            // 
            // applicationFormGenerationToolStripMenuItem
            // 
            this.applicationFormGenerationToolStripMenuItem.Name = "applicationFormGenerationToolStripMenuItem";
            this.applicationFormGenerationToolStripMenuItem.Size = new System.Drawing.Size(152, 20);
            this.applicationFormGenerationToolStripMenuItem.Text = "Application Form Generation";
            this.applicationFormGenerationToolStripMenuItem.Click += new System.EventHandler(this.applicationFormGenerationToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 462);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(784, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ImageMainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BackgroundImage = global::StockbrokerProNewArch.Properties.Resources.quattordici;
            this.ClientSize = new System.Drawing.Size(784, 484);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.mspImageUploader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mspImageUploader;
            this.Name = "ImageMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Images and Document Management";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ImageMainForm_Load);
            this.mspImageUploader.ResumeLayout(false);
            this.mspImageUploader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mspImageUploader;
        private System.Windows.Forms.ToolStripMenuItem singleImageUploaderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem batchImageUploaderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageViewerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountHolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem photoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem signatureToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem phToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem signatureToolStripMenuItem2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem othersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem othersToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem applicationFormGenerationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem signatureToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;

    }
}

