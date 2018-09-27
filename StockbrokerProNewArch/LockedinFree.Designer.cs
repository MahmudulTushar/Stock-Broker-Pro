namespace StockbrokerProNewArch
{
    partial class LockedinFree
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LockedinFree));
            this.txtLockedinQty = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.ddlCompShortCode = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFree = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtLockedinQty
            // 
            this.txtLockedinQty.Location = new System.Drawing.Point(179, 70);
            this.txtLockedinQty.Name = "txtLockedinQty";
            this.txtLockedinQty.ReadOnly = true;
            this.txtLockedinQty.Size = new System.Drawing.Size(89, 20);
            this.txtLockedinQty.TabIndex = 47;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Gray;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(21, 70);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label6.Size = new System.Drawing.Size(140, 20);
            this.label6.TabIndex = 46;
            this.label6.Text = "Lockedin Qty";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.Location = new System.Drawing.Point(179, 46);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.ReadOnly = true;
            this.txtCompanyName.Size = new System.Drawing.Size(159, 20);
            this.txtCompanyName.TabIndex = 45;
            // 
            // ddlCompShortCode
            // 
            this.ddlCompShortCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlCompShortCode.FormattingEnabled = true;
            this.ddlCompShortCode.Items.AddRange(new object[] {
            "Howla",
            "Laga",
            "Tax"});
            this.ddlCompShortCode.Location = new System.Drawing.Point(179, 21);
            this.ddlCompShortCode.Name = "ddlCompShortCode";
            this.ddlCompShortCode.Size = new System.Drawing.Size(159, 21);
            this.ddlCompShortCode.TabIndex = 0;
            this.ddlCompShortCode.SelectedIndexChanged += new System.EventHandler(this.ddlCompShortCode_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Gray;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(21, 46);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label2.Size = new System.Drawing.Size(140, 20);
            this.label2.TabIndex = 43;
            this.label2.Text = "Company Name";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Gray;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(21, 21);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label1.Size = new System.Drawing.Size(140, 20);
            this.label1.TabIndex = 42;
            this.label1.Text = "Company Short Code";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnFree
            // 
            this.btnFree.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFree.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnFree.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFree.Location = new System.Drawing.Point(106, 124);
            this.btnFree.Name = "btnFree";
            this.btnFree.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnFree.Size = new System.Drawing.Size(174, 25);
            this.btnFree.TabIndex = 1;
            this.btnFree.Text = "Free Lockedin Share";
            this.btnFree.UseVisualStyleBackColor = true;
            this.btnFree.Click += new System.EventHandler(this.btnFree_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(286, 124);
            this.btnClose.Name = "btnClose";
            this.btnClose.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnClose.Size = new System.Drawing.Size(89, 25);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ddlCompShortCode);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtLockedinQty);
            this.groupBox1.Controls.Add(this.txtCompanyName);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(363, 106);
            this.groupBox1.TabIndex = 48;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Unlock Lockedin Shares";
            // 
            // LockedinFree
            // 
            this.AcceptButton = this.btnFree;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 162);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnFree);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "LockedinFree";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Unlock Lockedin Shares";
            this.Load += new System.EventHandler(this.LockedinFree_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtLockedinQty;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.ComboBox ddlCompShortCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFree;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}