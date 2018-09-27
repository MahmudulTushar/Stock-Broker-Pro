namespace StockbrokerProNewArch
{
    partial class DepRejectionReason
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
            this.lblMsg = new System.Windows.Forms.Label();
            this.txtRejectionReason = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblMsg
            // 
            this.lblMsg.BackColor = System.Drawing.Color.Gray;
            this.lblMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsg.ForeColor = System.Drawing.Color.White;
            this.lblMsg.Location = new System.Drawing.Point(3, 7);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lblMsg.Size = new System.Drawing.Size(286, 20);
            this.lblMsg.TabIndex = 56;
            this.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtRejectionReason
            // 
            this.txtRejectionReason.Location = new System.Drawing.Point(3, 28);
            this.txtRejectionReason.Multiline = true;
            this.txtRejectionReason.Name = "txtRejectionReason";
            this.txtRejectionReason.Size = new System.Drawing.Size(286, 47);
            this.txtRejectionReason.TabIndex = 55;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(104, 78);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(83, 23);
            this.btnOk.TabIndex = 54;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 53;
            // 
            // DepRejectionReason
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 106);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.txtRejectionReason);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "DepRejectionReason";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rejection Reason";
            this.Load += new System.EventHandler(this.DepRejectionReason_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMsg;
        public System.Windows.Forms.TextBox txtRejectionReason;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label label1;
    }
}