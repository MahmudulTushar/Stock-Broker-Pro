namespace StockbrokerProNewArch
{
    partial class Frm_Current_Cash_Rpt
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Btt_ViewRpt = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.FormDate = new System.Windows.Forms.DateTimePicker();
            this.ToDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ToDate);
            this.groupBox2.Controls.Add(this.FormDate);
            this.groupBox2.Controls.Add(this.Btt_ViewRpt);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(8, 8);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(310, 135);
            this.groupBox2.TabIndex = 55;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Report";
            // 
            // Btt_ViewRpt
            // 
            this.Btt_ViewRpt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btt_ViewRpt.Location = new System.Drawing.Point(169, 91);
            this.Btt_ViewRpt.Name = "Btt_ViewRpt";
            this.Btt_ViewRpt.Size = new System.Drawing.Size(102, 27);
            this.Btt_ViewRpt.TabIndex = 63;
            this.Btt_ViewRpt.Text = "Show Report";
            this.Btt_ViewRpt.UseVisualStyleBackColor = true;
            this.Btt_ViewRpt.Click += new System.EventHandler(this.Btt_ViewRpt_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(48, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 45;
            this.label6.Text = "From Date :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(48, 66);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 13);
            this.label9.TabIndex = 48;
            this.label9.Text = "TO Date :";
            // 
            // FormDate
            // 
            this.FormDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FormDate.Location = new System.Drawing.Point(128, 28);
            this.FormDate.Name = "FormDate";
            this.FormDate.Size = new System.Drawing.Size(143, 19);
            this.FormDate.TabIndex = 64;
            // 
            // ToDate
            // 
            this.ToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ToDate.Location = new System.Drawing.Point(128, 66);
            this.ToDate.Name = "ToDate";
            this.ToDate.Size = new System.Drawing.Size(143, 19);
            this.ToDate.TabIndex = 65;
            // 
            // Frm_Current_Cash_Rpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 154);
            this.Controls.Add(this.groupBox2);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Frm_Current_Cash_Rpt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_Current_Cash_Rpt";
            this.Load += new System.EventHandler(this.Frm_Current_Cash_Rpt_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button Btt_ViewRpt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker ToDate;
        private System.Windows.Forms.DateTimePicker FormDate;
    }
}