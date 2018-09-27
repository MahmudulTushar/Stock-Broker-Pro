namespace StockbrokerProNewArch
{
    partial class VoucherViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VoucherViewer));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblImgViewer = new System.Windows.Forms.Label();
            this.picImgView = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.txtVoucherNo = new System.Windows.Forms.TextBox();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImgView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblImgViewer);
            this.groupBox3.Controls.Add(this.picImgView);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.Black;
            this.groupBox3.Location = new System.Drawing.Point(26, 113);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(598, 396);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Voucher Viewer ";
            // 
            // lblImgViewer
            // 
            this.lblImgViewer.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblImgViewer.ForeColor = System.Drawing.Color.White;
            this.lblImgViewer.Location = new System.Drawing.Point(199, 186);
            this.lblImgViewer.Name = "lblImgViewer";
            this.lblImgViewer.Size = new System.Drawing.Size(200, 25);
            this.lblImgViewer.TabIndex = 2;
            this.lblImgViewer.Text = "Voucher Viewer";
            this.lblImgViewer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picImgView
            // 
            this.picImgView.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.picImgView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picImgView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picImgView.Location = new System.Drawing.Point(3, 17);
            this.picImgView.Name = "picImgView";
            this.picImgView.Size = new System.Drawing.Size(592, 376);
            this.picImgView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picImgView.TabIndex = 1;
            this.picImgView.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtVoucherNo);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.btnView);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(29, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(588, 56);
            this.groupBox1.TabIndex = 94;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Voucher No.";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.SlateGray;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(455, 17);
            this.btnClose.Name = "btnClose";
            this.btnClose.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnClose.Size = new System.Drawing.Size(101, 25);
            this.btnClose.TabIndex = 86;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnView
            // 
            this.btnView.ForeColor = System.Drawing.Color.SlateGray;
            this.btnView.Location = new System.Drawing.Point(331, 18);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(96, 25);
            this.btnView.TabIndex = 85;
            this.btnView.Text = "View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // txtVoucherNo
            // 
            this.txtVoucherNo.Location = new System.Drawing.Point(136, 21);
            this.txtVoucherNo.Name = "txtVoucherNo";
            this.txtVoucherNo.Size = new System.Drawing.Size(178, 20);
            this.txtVoucherNo.TabIndex = 87;
            // 
            // VoucherViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 520);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Name = "VoucherViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Voucher Viewer";
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picImgView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblImgViewer;
        private System.Windows.Forms.PictureBox picImgView;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtVoucherNo;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnView;
    }
}