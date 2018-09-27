namespace NewArch
{
    partial class frmImgShow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImgShow));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtSearchCode = new System.Windows.Forms.TextBox();
            this.lblSearchCode = new System.Windows.Forms.Label();
            this.btnViewImage = new System.Windows.Forms.Button();
            this.ddlSearchBy = new System.Windows.Forms.ComboBox();
            this.lblSearchBy = new System.Windows.Forms.Label();
            this.ddlSearchPattern = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblImgViewer = new System.Windows.Forms.Label();
            this.picImgView = new System.Windows.Forms.PictureBox();
            this.lblSearchPersonName = new System.Windows.Forms.Label();
            this.lblSearchCategory = new System.Windows.Forms.Label();
            this.lblBOID = new System.Windows.Forms.Label();
            this.lblCustomerCod = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImgView)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.txtSearchCode);
            this.groupBox1.Controls.Add(this.lblSearchCode);
            this.groupBox1.Controls.Add(this.btnViewImage);
            this.groupBox1.Controls.Add(this.ddlSearchBy);
            this.groupBox1.Controls.Add(this.lblSearchBy);
            this.groupBox1.Controls.Add(this.ddlSearchPattern);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(10, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(291, 150);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Input";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.SlateGray;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(205, 101);
            this.btnClose.Name = "btnClose";
            this.btnClose.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnClose.Size = new System.Drawing.Size(68, 25);
            this.btnClose.TabIndex = 83;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtSearchCode
            // 
            this.txtSearchCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchCode.Location = new System.Drawing.Point(119, 75);
            this.txtSearchCode.Name = "txtSearchCode";
            this.txtSearchCode.Size = new System.Drawing.Size(164, 20);
            this.txtSearchCode.TabIndex = 6;
            this.txtSearchCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchCode_KeyDown);
            // 
            // lblSearchCode
            // 
            this.lblSearchCode.AutoSize = true;
            this.lblSearchCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchCode.ForeColor = System.Drawing.Color.White;
            this.lblSearchCode.Location = new System.Drawing.Point(9, 77);
            this.lblSearchCode.Name = "lblSearchCode";
            this.lblSearchCode.Size = new System.Drawing.Size(104, 13);
            this.lblSearchCode.TabIndex = 5;
            this.lblSearchCode.Text = "Customer Code : ";
            // 
            // btnViewImage
            // 
            this.btnViewImage.BackColor = System.Drawing.Color.Transparent;
            this.btnViewImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewImage.ForeColor = System.Drawing.Color.SlateGray;
            this.btnViewImage.Image = ((System.Drawing.Image)(resources.GetObject("btnViewImage.Image")));
            this.btnViewImage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnViewImage.Location = new System.Drawing.Point(136, 101);
            this.btnViewImage.Name = "btnViewImage";
            this.btnViewImage.Size = new System.Drawing.Size(63, 25);
            this.btnViewImage.TabIndex = 4;
            this.btnViewImage.Text = "View";
            this.btnViewImage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnViewImage.UseVisualStyleBackColor = false;
            this.btnViewImage.Click += new System.EventHandler(this.button1_Click);
            // 
            // ddlSearchBy
            // 
            this.ddlSearchBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlSearchBy.FormattingEnabled = true;
            this.ddlSearchBy.Items.AddRange(new object[] {
            "Customer Code",
            "Customer BO ID"});
            this.ddlSearchBy.Location = new System.Drawing.Point(119, 49);
            this.ddlSearchBy.Name = "ddlSearchBy";
            this.ddlSearchBy.Size = new System.Drawing.Size(164, 21);
            this.ddlSearchBy.TabIndex = 3;
            this.ddlSearchBy.SelectedIndexChanged += new System.EventHandler(this.ddlSearchBy_SelectedIndexChanged);
            // 
            // lblSearchBy
            // 
            this.lblSearchBy.AutoSize = true;
            this.lblSearchBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchBy.ForeColor = System.Drawing.Color.White;
            this.lblSearchBy.Location = new System.Drawing.Point(13, 51);
            this.lblSearchBy.Name = "lblSearchBy";
            this.lblSearchBy.Size = new System.Drawing.Size(73, 13);
            this.lblSearchBy.TabIndex = 2;
            this.lblSearchBy.Text = "Search By :";
            // 
            // ddlSearchPattern
            // 
            this.ddlSearchPattern.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlSearchPattern.FormattingEnabled = true;
            this.ddlSearchPattern.Items.AddRange(new object[] {
            "1st Account Holder",
            "2nd Account Holder",
            "1st Nominee",
            "2nd Nominee",
            "1st Gurdian",
            "2nd Gurdian",
            "Power OF Attorney",
            "Authorzied Person"});
            this.ddlSearchPattern.Location = new System.Drawing.Point(120, 23);
            this.ddlSearchPattern.Name = "ddlSearchPattern";
            this.ddlSearchPattern.Size = new System.Drawing.Size(164, 21);
            this.ddlSearchPattern.TabIndex = 1;
            this.ddlSearchPattern.SelectedIndexChanged += new System.EventHandler(this.ddlSearchPattern_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(10, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search Pattern :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.lblImgViewer);
            this.groupBox2.Controls.Add(this.picImgView);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(12, 169);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(544, 316);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Image Preview";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(366, 294);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Click on Image for full size";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // lblImgViewer
            // 
            this.lblImgViewer.AutoSize = true;
            this.lblImgViewer.BackColor = System.Drawing.Color.Transparent;
            this.lblImgViewer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImgViewer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblImgViewer.Location = new System.Drawing.Point(231, 152);
            this.lblImgViewer.Name = "lblImgViewer";
            this.lblImgViewer.Size = new System.Drawing.Size(90, 13);
            this.lblImgViewer.TabIndex = 1;
            this.lblImgViewer.Text = "Image Preview";
            // 
            // picImgView
            // 
            this.picImgView.BackColor = System.Drawing.Color.Transparent;
            this.picImgView.Dock = System.Windows.Forms.DockStyle.Top;
            this.picImgView.Location = new System.Drawing.Point(3, 16);
            this.picImgView.Name = "picImgView";
            this.picImgView.Size = new System.Drawing.Size(538, 278);
            this.picImgView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picImgView.TabIndex = 0;
            this.picImgView.TabStop = false;
            // 
            // lblSearchPersonName
            // 
            this.lblSearchPersonName.AutoSize = true;
            this.lblSearchPersonName.ForeColor = System.Drawing.Color.White;
            this.lblSearchPersonName.Location = new System.Drawing.Point(6, 83);
            this.lblSearchPersonName.Name = "lblSearchPersonName";
            this.lblSearchPersonName.Size = new System.Drawing.Size(107, 13);
            this.lblSearchPersonName.TabIndex = 3;
            this.lblSearchPersonName.Text = "Name : ..............";
            // 
            // lblSearchCategory
            // 
            this.lblSearchCategory.AutoSize = true;
            this.lblSearchCategory.ForeColor = System.Drawing.Color.White;
            this.lblSearchCategory.Location = new System.Drawing.Point(6, 108);
            this.lblSearchCategory.Name = "lblSearchCategory";
            this.lblSearchCategory.Size = new System.Drawing.Size(107, 13);
            this.lblSearchCategory.TabIndex = 2;
            this.lblSearchCategory.Text = "Search: .............";
            // 
            // lblBOID
            // 
            this.lblBOID.AutoSize = true;
            this.lblBOID.ForeColor = System.Drawing.Color.White;
            this.lblBOID.Location = new System.Drawing.Point(6, 59);
            this.lblBOID.Name = "lblBOID";
            this.lblBOID.Size = new System.Drawing.Size(105, 13);
            this.lblBOID.TabIndex = 1;
            this.lblBOID.Text = "BO ID: ..............";
            // 
            // lblCustomerCod
            // 
            this.lblCustomerCod.AutoSize = true;
            this.lblCustomerCod.ForeColor = System.Drawing.Color.White;
            this.lblCustomerCod.Location = new System.Drawing.Point(6, 31);
            this.lblCustomerCod.Name = "lblCustomerCod";
            this.lblCustomerCod.Size = new System.Drawing.Size(104, 13);
            this.lblCustomerCod.TabIndex = 0;
            this.lblCustomerCod.Text = "Code : ..............";
            this.lblCustomerCod.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblSearchPersonName);
            this.groupBox4.Controls.Add(this.lblCustomerCod);
            this.groupBox4.Controls.Add(this.lblSearchCategory);
            this.groupBox4.Controls.Add(this.lblBOID);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.Color.White;
            this.groupBox4.Location = new System.Drawing.Point(312, 10);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(244, 152);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Search Information";
            // 
            // frmImgShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(566, 498);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frmImgShow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Image Browser";
            this.Load += new System.EventHandler(this.frmImgShow_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImgView)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox ddlSearchBy;
        private System.Windows.Forms.Label lblSearchBy;
        private System.Windows.Forms.ComboBox ddlSearchPattern;
        private System.Windows.Forms.Button btnViewImage;
        private System.Windows.Forms.Label lblImgViewer;
        private System.Windows.Forms.PictureBox picImgView;
        private System.Windows.Forms.TextBox txtSearchCode;
        private System.Windows.Forms.Label lblSearchCode;
        private System.Windows.Forms.Label lblCustomerCod;
        private System.Windows.Forms.Label lblBOID;
        private System.Windows.Forms.Label lblSearchPersonName;
        private System.Windows.Forms.Label lblSearchCategory;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label2;
    }
}