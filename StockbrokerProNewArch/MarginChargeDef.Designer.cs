namespace StockbrokerProNewArch
{
    partial class MarginChargeDef
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MarginChargeDef));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtgChargeInfo = new System.Windows.Forms.DataGridView();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.txtChargeRate = new System.Windows.Forms.TextBox();
            this.ddlPlanName = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEffectiveCount = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dtEffectiveDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgChargeInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(20, 146);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(390, 2);
            this.panel1.TabIndex = 126;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.DimGray;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Chartreuse;
            this.label13.Location = new System.Drawing.Point(28, 193);
            this.label13.Name = "label13";
            this.label13.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.label13.Size = new System.Drawing.Size(379, 23);
            this.label13.TabIndex = 125;
            this.label13.Text = "Charge History (Displaying Latest 1000 Data)";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(186, 118);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(10, 13);
            this.label12.TabIndex = 119;
            this.label12.Text = ":";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(186, 70);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(10, 13);
            this.label9.TabIndex = 124;
            this.label9.Text = ":";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(186, 46);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(10, 13);
            this.label8.TabIndex = 122;
            this.label8.Text = ":";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(186, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(10, 13);
            this.label7.TabIndex = 123;
            this.label7.Text = ":";
            // 
            // dtgChargeInfo
            // 
            this.dtgChargeInfo.AllowUserToAddRows = false;
            this.dtgChargeInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgChargeInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgChargeInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgChargeInfo.Location = new System.Drawing.Point(28, 216);
            this.dtgChargeInfo.MultiSelect = false;
            this.dtgChargeInfo.Name = "dtgChargeInfo";
            this.dtgChargeInfo.ReadOnly = true;
            this.dtgChargeInfo.RowHeadersVisible = false;
            this.dtgChargeInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgChargeInfo.Size = new System.Drawing.Size(379, 196);
            this.dtgChargeInfo.TabIndex = 117;
            this.dtgChargeInfo.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(317, 157);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnCancel.Size = new System.Drawing.Size(90, 25);
            this.btnCancel.TabIndex = 116;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Close";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(221, 157);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnSave.Size = new System.Drawing.Size(90, 25);
            this.btnSave.TabIndex = 115;
            this.btnSave.TabStop = false;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Gray;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(28, 66);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label6.Size = new System.Drawing.Size(150, 20);
            this.label6.TabIndex = 118;
            this.label6.Text = "Effective Count";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(202, 115);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(201, 20);
            this.txtRemarks.TabIndex = 112;
            // 
            // txtChargeRate
            // 
            this.txtChargeRate.Location = new System.Drawing.Point(202, 43);
            this.txtChargeRate.Name = "txtChargeRate";
            this.txtChargeRate.Size = new System.Drawing.Size(201, 20);
            this.txtChargeRate.TabIndex = 107;
            this.txtChargeRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtChargeRate_KeyPress);
            // 
            // ddlPlanName
            // 
            this.ddlPlanName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlPlanName.FormattingEnabled = true;
            this.ddlPlanName.Items.AddRange(new object[] {
            "GA"});
            this.ddlPlanName.Location = new System.Drawing.Point(202, 18);
            this.ddlPlanName.Name = "ddlPlanName";
            this.ddlPlanName.Size = new System.Drawing.Size(201, 21);
            this.ddlPlanName.TabIndex = 105;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Gray;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(28, 114);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label4.Size = new System.Drawing.Size(150, 20);
            this.label4.TabIndex = 110;
            this.label4.Text = "Remarks";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Gray;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(28, 41);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label2.Size = new System.Drawing.Size(150, 20);
            this.label2.TabIndex = 106;
            this.label2.Text = "Charge Rate";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Gray;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(28, 17);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label1.Size = new System.Drawing.Size(150, 20);
            this.label1.TabIndex = 104;
            this.label1.Text = "Plan Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtEffectiveCount
            // 
            this.txtEffectiveCount.Location = new System.Drawing.Point(202, 67);
            this.txtEffectiveCount.Name = "txtEffectiveCount";
            this.txtEffectiveCount.Size = new System.Drawing.Size(201, 20);
            this.txtEffectiveCount.TabIndex = 127;
            this.txtEffectiveCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEffectiveCount_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(186, 95);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(10, 13);
            this.label10.TabIndex = 130;
            this.label10.Text = ":";
            // 
            // dtEffectiveDate
            // 
            this.dtEffectiveDate.CustomFormat = "dd/MM/yyyy";
            this.dtEffectiveDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtEffectiveDate.Location = new System.Drawing.Point(202, 91);
            this.dtEffectiveDate.Name = "dtEffectiveDate";
            this.dtEffectiveDate.Size = new System.Drawing.Size(201, 20);
            this.dtEffectiveDate.TabIndex = 129;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Gray;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(28, 90);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label5.Size = new System.Drawing.Size(150, 20);
            this.label5.TabIndex = 128;
            this.label5.Text = "Effective Date";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MarginChargeDef
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 418);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dtEffectiveDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtEffectiveCount);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dtgChargeInfo);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.txtChargeRate);
            this.Controls.Add(this.ddlPlanName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "MarginChargeDef";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GA Margin Charge ";
            this.Load += new System.EventHandler(this.MarginChargeDef_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgChargeInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dtgChargeInfo;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.TextBox txtChargeRate;
        private System.Windows.Forms.ComboBox ddlPlanName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEffectiveCount;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtEffectiveDate;
        private System.Windows.Forms.Label label5;
    }
}