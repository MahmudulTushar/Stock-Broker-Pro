namespace StockbrokerProNewArch
{
    partial class ShareLimit
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnShareLimit = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(234, 29);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnCancel.Size = new System.Drawing.Size(109, 25);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnShareLimit
            // 
            this.btnShareLimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShareLimit.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnShareLimit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnShareLimit.Location = new System.Drawing.Point(12, 29);
            this.btnShareLimit.Name = "btnShareLimit";
            this.btnShareLimit.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnShareLimit.Size = new System.Drawing.Size(216, 25);
            this.btnShareLimit.TabIndex = 4;
            this.btnShareLimit.Text = "Generate Share Limit File";
            this.btnShareLimit.UseVisualStyleBackColor = true;
            this.btnShareLimit.Click += new System.EventHandler(this.btnShareLimit_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 12);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(331, 11);
            this.progressBar1.TabIndex = 6;
            // 
            // ShareLimit
            // 
            this.AcceptButton = this.btnShareLimit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 67);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnShareLimit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "ShareLimit";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Share Limit File Generation";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnShareLimit;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}