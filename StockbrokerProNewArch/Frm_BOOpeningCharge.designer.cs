namespace StockbrokerProNewArch
{
    partial class Frm_BOOpeningCharge
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_BOOpeningCharge));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txtCDBLCharge = new System.Windows.Forms.TextBox();
            this.txtHouseCharge = new System.Windows.Forms.TextBox();
            this.txtTotalCharge = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvChargeHistory = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChargeHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(6, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(496, 161);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.Controls.Add(this.btnUpdate);
            this.panel2.Controls.Add(this.txtCDBLCharge);
            this.panel2.Controls.Add(this.txtHouseCharge);
            this.panel2.Controls.Add(this.txtTotalCharge);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(5, 39);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(485, 115);
            this.panel2.TabIndex = 2;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.Image")));
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.Location = new System.Drawing.Point(368, 76);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(105, 23);
            this.btnUpdate.TabIndex = 9;
            this.btnUpdate.Text = "    Save";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txtCDBLCharge
            // 
            this.txtCDBLCharge.Location = new System.Drawing.Point(150, 77);
            this.txtCDBLCharge.Name = "txtCDBLCharge";
            this.txtCDBLCharge.Size = new System.Drawing.Size(212, 20);
            this.txtCDBLCharge.TabIndex = 8;
            this.txtCDBLCharge.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCDBLCharge.TextChanged += new System.EventHandler(this.txtCDBLCharge_TextChanged);
            this.txtCDBLCharge.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCDBLCharge_KeyPress);
            // 
            // txtHouseCharge
            // 
            this.txtHouseCharge.Location = new System.Drawing.Point(150, 50);
            this.txtHouseCharge.Name = "txtHouseCharge";
            this.txtHouseCharge.Size = new System.Drawing.Size(212, 20);
            this.txtHouseCharge.TabIndex = 7;
            this.txtHouseCharge.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtHouseCharge.TextChanged += new System.EventHandler(this.txtHouseCharge_TextChanged);
            this.txtHouseCharge.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHouseCharge_KeyPress);
            // 
            // txtTotalCharge
            // 
            this.txtTotalCharge.Location = new System.Drawing.Point(150, 23);
            this.txtTotalCharge.Name = "txtTotalCharge";
            this.txtTotalCharge.Size = new System.Drawing.Size(212, 20);
            this.txtTotalCharge.TabIndex = 6;
            this.txtTotalCharge.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotalCharge.TextChanged += new System.EventHandler(this.txtTotalCharge_TextChanged);
            this.txtTotalCharge.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTotalCharge_KeyPress);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Silver;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(128, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 23);
            this.label7.TabIndex = 5;
            this.label7.Text = ":";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Silver;
            this.label8.Location = new System.Drawing.Point(15, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 23);
            this.label8.TabIndex = 4;
            this.label8.Text = "Total House Charge";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Silver;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(128, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 23);
            this.label5.TabIndex = 3;
            this.label5.Text = ":";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Silver;
            this.label6.Location = new System.Drawing.Point(15, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 23);
            this.label6.TabIndex = 2;
            this.label6.Text = "Total CDBL Charge";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Silver;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(128, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 23);
            this.label4.TabIndex = 1;
            this.label4.Text = ":";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Silver;
            this.label3.Location = new System.Drawing.Point(15, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 23);
            this.label3.TabIndex = 0;
            this.label3.Text = "Total Charge";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.DarkGray;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(486, 5);
            this.label2.TabIndex = 1;
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Silver;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(486, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "BO Opening Charge";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.dgvChargeHistory);
            this.panel3.Location = new System.Drawing.Point(6, 179);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(496, 198);
            this.panel3.TabIndex = 3;
            // 
            // dgvChargeHistory
            // 
            this.dgvChargeHistory.AllowUserToAddRows = false;
            this.dgvChargeHistory.AllowUserToDeleteRows = false;
            this.dgvChargeHistory.AllowUserToOrderColumns = true;
            this.dgvChargeHistory.BackgroundColor = System.Drawing.Color.LightGray;
            this.dgvChargeHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChargeHistory.Location = new System.Drawing.Point(5, 30);
            this.dgvChargeHistory.Name = "dgvChargeHistory";
            this.dgvChargeHistory.ReadOnly = true;
            this.dgvChargeHistory.Size = new System.Drawing.Size(485, 161);
            this.dgvChargeHistory.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Silver;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(5, 4);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(486, 23);
            this.label9.TabIndex = 3;
            this.label9.Text = "Charge History";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Frm_BOOpeningCharge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(508, 382);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "Frm_BOOpeningCharge";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BO Opening Charge Defination";
            this.Load += new System.EventHandler(this.Frm_BOOpeningCharge_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChargeHistory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox txtCDBLCharge;
        private System.Windows.Forms.TextBox txtHouseCharge;
        private System.Windows.Forms.TextBox txtTotalCharge;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvChargeHistory;
        private System.Windows.Forms.Label label9;
    }
}