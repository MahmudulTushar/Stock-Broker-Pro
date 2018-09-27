namespace StockbrokerProNewArch
{
    partial class LockWindow2
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
            this.PasswordPanel = new System.Windows.Forms.Panel();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnLogIn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.PasswordPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // PasswordPanel
            // 
            this.PasswordPanel.BackColor = System.Drawing.Color.LightSteelBlue;
            this.PasswordPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PasswordPanel.Controls.Add(this.label1);
            this.PasswordPanel.Controls.Add(this.txtPassword);
            this.PasswordPanel.Controls.Add(this.btnLogIn);
            this.PasswordPanel.Location = new System.Drawing.Point(4, 4);
            this.PasswordPanel.Name = "PasswordPanel";
            this.PasswordPanel.Size = new System.Drawing.Size(200, 100);
            this.PasswordPanel.TabIndex = 1;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(12, 28);
            this.txtPassword.MaxLength = 20;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(177, 20);
            this.txtPassword.TabIndex = 30;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // btnLogIn
            // 
            this.btnLogIn.BackColor = System.Drawing.Color.LightSlateGray;
            this.btnLogIn.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogIn.ForeColor = System.Drawing.Color.White;
            this.btnLogIn.Location = new System.Drawing.Point(62, 54);
            this.btnLogIn.Name = "btnLogIn";
            this.btnLogIn.Size = new System.Drawing.Size(72, 26);
            this.btnLogIn.TabIndex = 31;
            this.btnLogIn.Text = "unlock";
            this.btnLogIn.UseVisualStyleBackColor = false;
            this.btnLogIn.Click += new System.EventHandler(this.btnLogIn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "Password";
            // 
            // LockWindow2
            // 
            this.AcceptButton = this.btnLogIn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(205, 107);
            this.ControlBox = false;
            this.Controls.Add(this.PasswordPanel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LockWindow2";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.LockWindow2_Load);
            this.PasswordPanel.ResumeLayout(false);
            this.PasswordPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PasswordPanel;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogIn;
        private System.Windows.Forms.Label label1;
    }
}