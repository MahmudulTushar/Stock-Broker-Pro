namespace StockbrokerProNewArch
{
    partial class ImageViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageViewer));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbZoomIn = new System.Windows.Forms.ToolStripButton();
            this.tsbZoomOut = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbRotateLeft = new System.Windows.Forms.ToolStripButton();
            this.imgPanel = new System.Windows.Forms.Panel();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbZoomIn,
            this.tsbZoomOut,
            this.toolStripSeparator1,
            this.tsbRotateLeft});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(773, 46);
            this.toolStrip1.TabIndex = 0;
            // 
            // tsbZoomIn
            // 
            this.tsbZoomIn.AutoSize = false;
            this.tsbZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbZoomIn.Image = ((System.Drawing.Image)(resources.GetObject("tsbZoomIn.Image")));
            this.tsbZoomIn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbZoomIn.Name = "tsbZoomIn";
            this.tsbZoomIn.Size = new System.Drawing.Size(50, 50);
            this.tsbZoomIn.Text = "Zoom In";
            this.tsbZoomIn.Click += new System.EventHandler(this.tsbZoomIn_Click);
            // 
            // tsbZoomOut
            // 
            this.tsbZoomOut.AutoSize = false;
            this.tsbZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbZoomOut.Image = ((System.Drawing.Image)(resources.GetObject("tsbZoomOut.Image")));
            this.tsbZoomOut.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbZoomOut.Name = "tsbZoomOut";
            this.tsbZoomOut.Size = new System.Drawing.Size(50, 50);
            this.tsbZoomOut.Text = "Zoom Out";
            this.tsbZoomOut.Click += new System.EventHandler(this.tsbZoomOut_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 46);
            // 
            // tsbRotateLeft
            // 
            this.tsbRotateLeft.AutoSize = false;
            this.tsbRotateLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRotateLeft.Image = ((System.Drawing.Image)(resources.GetObject("tsbRotateLeft.Image")));
            this.tsbRotateLeft.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbRotateLeft.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRotateLeft.Name = "tsbRotateLeft";
            this.tsbRotateLeft.Size = new System.Drawing.Size(50, 50);
            this.tsbRotateLeft.Text = "Rotate Left";
            this.tsbRotateLeft.Click += new System.EventHandler(this.tsbRotateLeft_Click);
            // 
            // imgPanel
            // 
            this.imgPanel.AutoScroll = true;
            this.imgPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imgPanel.Location = new System.Drawing.Point(0, 46);
            this.imgPanel.Name = "imgPanel";
            this.imgPanel.Size = new System.Drawing.Size(773, 473);
            this.imgPanel.TabIndex = 2;
            this.imgPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.imgPanel_Paint);
            // 
            // ImageViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(773, 519);
            this.Controls.Add(this.imgPanel);
            this.Controls.Add(this.toolStrip1);
            this.Name = "ImageViewer";
            this.Text = "Image Viewer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ImageViewer_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Panel imgPanel;
        private System.Windows.Forms.ToolStripButton tsbZoomIn;
        private System.Windows.Forms.ToolStripButton tsbZoomOut;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbRotateLeft;
    }
}