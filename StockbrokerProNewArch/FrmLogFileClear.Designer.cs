namespace StockbrokerProNewArch
{
    partial class FrmLogFileClear
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
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.ComboBoxserverName = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbDataBaseName = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label4.Location = new System.Drawing.Point(-2, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(383, 34);
            this.label4.TabIndex = 11;
            this.label4.Text = "Log Clear";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(140, 59);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(10, 13);
            this.label9.TabIndex = 57;
            this.label9.Text = ":";
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Gray;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(18, 56);
            this.label10.Name = "label10";
            this.label10.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label10.Size = new System.Drawing.Size(116, 20);
            this.label10.TabIndex = 56;
            this.label10.Text = "Server Name";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ComboBoxserverName
            // 
            this.ComboBoxserverName.FormattingEnabled = true;
            this.ComboBoxserverName.Location = new System.Drawing.Point(160, 55);
            this.ComboBoxserverName.Name = "ComboBoxserverName";
            this.ComboBoxserverName.Size = new System.Drawing.Size(200, 21);
            this.ComboBoxserverName.TabIndex = 55;
            this.ComboBoxserverName.SelectedIndexChanged += new System.EventHandler(this.ComboBoxserverName_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(140, 95);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(10, 13);
            this.label7.TabIndex = 54;
            this.label7.Text = ":";
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Gray;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(18, 92);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label8.Size = new System.Drawing.Size(116, 20);
            this.label8.TabIndex = 53;
            this.label8.Text = "DataBase Name";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbDataBaseName
            // 
            this.cmbDataBaseName.FormattingEnabled = true;
            this.cmbDataBaseName.Location = new System.Drawing.Point(160, 91);
            this.cmbDataBaseName.Name = "cmbDataBaseName";
            this.cmbDataBaseName.Size = new System.Drawing.Size(200, 21);
            this.cmbDataBaseName.TabIndex = 52;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(241, 136);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 59;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btClear
            // 
            this.btClear.Location = new System.Drawing.Point(160, 136);
            this.btClear.Name = "btClear";
            this.btClear.Size = new System.Drawing.Size(75, 23);
            this.btClear.TabIndex = 58;
            this.btClear.Text = "Clear";
            this.btClear.UseVisualStyleBackColor = true;
            this.btClear.Click += new System.EventHandler(this.btClear_Click);
            // 
            // FrmLogFileClear
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(382, 194);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btClear);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.ComboBoxserverName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbDataBaseName);
            this.Controls.Add(this.label4);
            this.Name = "FrmLogFileClear";
            this.Text = "Log File Clear";
            this.Load += new System.EventHandler(this.FrmLogFileClear_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox ComboBoxserverName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbDataBaseName;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btClear;
    }
}