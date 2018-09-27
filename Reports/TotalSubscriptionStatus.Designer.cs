namespace StockbrokerProNewArch
{
    partial class TotalSubscriptionStatus
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
            this.CmbsessionIdByName = new System.Windows.Forms.ComboBox();
            this.btnSubscriptionstatus = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnclose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CmbsessionIdByName
            // 
            this.CmbsessionIdByName.FormattingEnabled = true;
            this.CmbsessionIdByName.Location = new System.Drawing.Point(10, 43);
            this.CmbsessionIdByName.Name = "CmbsessionIdByName";
            this.CmbsessionIdByName.Size = new System.Drawing.Size(242, 21);
            this.CmbsessionIdByName.TabIndex = 0;
            // 
            // btnSubscriptionstatus
            // 
            this.btnSubscriptionstatus.Location = new System.Drawing.Point(11, 74);
            this.btnSubscriptionstatus.Name = "btnSubscriptionstatus";
            this.btnSubscriptionstatus.Size = new System.Drawing.Size(151, 23);
            this.btnSubscriptionstatus.TabIndex = 1;
            this.btnSubscriptionstatus.Text = "Subscription Status";
            this.btnSubscriptionstatus.UseVisualStyleBackColor = true;
            this.btnSubscriptionstatus.Click += new System.EventHandler(this.btnSubscriptionstatus_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(42, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Total Subscription Status\r\n";
            // 
            // btnclose
            // 
            this.btnclose.Location = new System.Drawing.Point(176, 74);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(75, 23);
            this.btnclose.TabIndex = 3;
            this.btnclose.Text = "Close";
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // TotalSubscriptionStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 103);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSubscriptionstatus);
            this.Controls.Add(this.CmbsessionIdByName);
            this.Name = "TotalSubscriptionStatus";
            this.Text = "TotalSubscriptionStatus";
            this.Load += new System.EventHandler(this.TotalSubscriptionStatus_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CmbsessionIdByName;
        private System.Windows.Forms.Button btnSubscriptionstatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnclose;
    }
}