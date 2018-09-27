namespace StockbrokerProNewArch
{
    partial class BranchForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BranchForm));
            this.dtgBranchInfo = new System.Windows.Forms.DataGridView();
            this.txtBranchName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.dtOpenDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.gbBranchEntry = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtWeb = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtFax = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTelephone = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSaveBranch = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBranchInfo)).BeginInit();
            this.gbBranchEntry.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgBranchInfo
            // 
            this.dtgBranchInfo.AllowUserToAddRows = false;
            this.dtgBranchInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtgBranchInfo.BackgroundColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgBranchInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgBranchInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgBranchInfo.GridColor = System.Drawing.Color.LightGray;
            this.dtgBranchInfo.Location = new System.Drawing.Point(12, 273);
            this.dtgBranchInfo.MultiSelect = false;
            this.dtgBranchInfo.Name = "dtgBranchInfo";
            this.dtgBranchInfo.ReadOnly = true;
            this.dtgBranchInfo.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dtgBranchInfo.RowHeadersVisible = false;
            this.dtgBranchInfo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dtgBranchInfo.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgBranchInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgBranchInfo.Size = new System.Drawing.Size(417, 132);
            this.dtgBranchInfo.TabIndex = 6;
            this.dtgBranchInfo.SelectionChanged += new System.EventHandler(this.dtgBranchInfo_SelectionChanged);
            // 
            // txtBranchName
            // 
            this.txtBranchName.Location = new System.Drawing.Point(163, 22);
            this.txtBranchName.MaxLength = 50;
            this.txtBranchName.Name = "txtBranchName";
            this.txtBranchName.Size = new System.Drawing.Size(228, 20);
            this.txtBranchName.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Gray;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(20, 165);
            this.label11.Name = "label11";
            this.label11.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label11.Size = new System.Drawing.Size(113, 20);
            this.label11.TabIndex = 42;
            this.label11.Text = "Opening Date";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Gray;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(20, 46);
            this.label10.Name = "label10";
            this.label10.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label10.Size = new System.Drawing.Size(113, 20);
            this.label10.TabIndex = 40;
            this.label10.Text = "Address";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(163, 46);
            this.txtAddress.MaxLength = 500;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(228, 20);
            this.txtAddress.TabIndex = 1;
            // 
            // dtOpenDate
            // 
            this.dtOpenDate.CustomFormat = "dd-MMM-yyyy";
            this.dtOpenDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtOpenDate.Location = new System.Drawing.Point(163, 165);
            this.dtOpenDate.Name = "dtOpenDate";
            this.dtOpenDate.Size = new System.Drawing.Size(96, 20);
            this.dtOpenDate.TabIndex = 6;
            this.dtOpenDate.Value = new System.DateTime(2010, 9, 23, 0, 0, 0, 0);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Gray;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(20, 22);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label4.Size = new System.Drawing.Size(113, 20);
            this.label4.TabIndex = 38;
            this.label4.Text = "Branch Name";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gbBranchEntry
            // 
            this.gbBranchEntry.Controls.Add(this.label14);
            this.gbBranchEntry.Controls.Add(this.txtWeb);
            this.gbBranchEntry.Controls.Add(this.label15);
            this.gbBranchEntry.Controls.Add(this.label12);
            this.gbBranchEntry.Controls.Add(this.txtEmail);
            this.gbBranchEntry.Controls.Add(this.label13);
            this.gbBranchEntry.Controls.Add(this.label8);
            this.gbBranchEntry.Controls.Add(this.txtFax);
            this.gbBranchEntry.Controls.Add(this.label9);
            this.gbBranchEntry.Controls.Add(this.label6);
            this.gbBranchEntry.Controls.Add(this.txtTelephone);
            this.gbBranchEntry.Controls.Add(this.label7);
            this.gbBranchEntry.Controls.Add(this.label3);
            this.gbBranchEntry.Controls.Add(this.label2);
            this.gbBranchEntry.Controls.Add(this.label1);
            this.gbBranchEntry.Controls.Add(this.txtBranchName);
            this.gbBranchEntry.Controls.Add(this.label4);
            this.gbBranchEntry.Controls.Add(this.dtOpenDate);
            this.gbBranchEntry.Controls.Add(this.txtAddress);
            this.gbBranchEntry.Controls.Add(this.label10);
            this.gbBranchEntry.Controls.Add(this.label11);
            this.gbBranchEntry.Location = new System.Drawing.Point(12, 7);
            this.gbBranchEntry.Name = "gbBranchEntry";
            this.gbBranchEntry.Size = new System.Drawing.Size(417, 194);
            this.gbBranchEntry.TabIndex = 0;
            this.gbBranchEntry.TabStop = false;
            this.gbBranchEntry.Text = "Branch Information";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(149, 145);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(10, 13);
            this.label14.TabIndex = 53;
            this.label14.Text = ":";
            // 
            // txtWeb
            // 
            this.txtWeb.Location = new System.Drawing.Point(162, 141);
            this.txtWeb.MaxLength = 50;
            this.txtWeb.Name = "txtWeb";
            this.txtWeb.Size = new System.Drawing.Size(228, 20);
            this.txtWeb.TabIndex = 5;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.Gray;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(19, 141);
            this.label15.Name = "label15";
            this.label15.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label15.Size = new System.Drawing.Size(113, 20);
            this.label15.TabIndex = 54;
            this.label15.Text = "Web";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(150, 122);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(10, 13);
            this.label12.TabIndex = 50;
            this.label12.Text = ":";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(163, 118);
            this.txtEmail.MaxLength = 50;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(228, 20);
            this.txtEmail.TabIndex = 4;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Gray;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(20, 118);
            this.label13.Name = "label13";
            this.label13.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label13.Size = new System.Drawing.Size(113, 20);
            this.label13.TabIndex = 51;
            this.label13.Text = "E-mail";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(150, 98);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(10, 13);
            this.label8.TabIndex = 47;
            this.label8.Text = ":";
            // 
            // txtFax
            // 
            this.txtFax.Location = new System.Drawing.Point(163, 94);
            this.txtFax.MaxLength = 50;
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(228, 20);
            this.txtFax.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Gray;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(20, 94);
            this.label9.Name = "label9";
            this.label9.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label9.Size = new System.Drawing.Size(113, 20);
            this.label9.TabIndex = 48;
            this.label9.Text = "Fax";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(150, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(10, 13);
            this.label6.TabIndex = 44;
            this.label6.Text = ":";
            // 
            // txtTelephone
            // 
            this.txtTelephone.Location = new System.Drawing.Point(163, 70);
            this.txtTelephone.MaxLength = 50;
            this.txtTelephone.Name = "txtTelephone";
            this.txtTelephone.Size = new System.Drawing.Size(228, 20);
            this.txtTelephone.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Gray;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(20, 70);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label7.Size = new System.Drawing.Size(113, 20);
            this.label7.TabIndex = 45;
            this.label7.Text = "Telephone";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(150, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = ":";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(150, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = ":";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(150, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = ":";
            // 
            // btnSaveBranch
            // 
            this.btnSaveBranch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveBranch.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnSaveBranch.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveBranch.Image")));
            this.btnSaveBranch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveBranch.Location = new System.Drawing.Point(243, 210);
            this.btnSaveBranch.Name = "btnSaveBranch";
            this.btnSaveBranch.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnSaveBranch.Size = new System.Drawing.Size(90, 25);
            this.btnSaveBranch.TabIndex = 0;
            this.btnSaveBranch.TabStop = false;
            this.btnSaveBranch.Text = "Save";
            this.btnSaveBranch.UseVisualStyleBackColor = true;
            this.btnSaveBranch.Click += new System.EventHandler(this.btnSaveBranch_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(339, 210);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnCancel.Size = new System.Drawing.Size(90, 25);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnNew
            // 
            this.btnNew.Enabled = false;
            this.btnNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(51, 210);
            this.btnNew.Name = "btnNew";
            this.btnNew.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnNew.Size = new System.Drawing.Size(90, 25);
            this.btnNew.TabIndex = 2;
            this.btnNew.TabStop = false;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.Image")));
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.Location = new System.Drawing.Point(147, 210);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnUpdate.Size = new System.Drawing.Size(90, 25);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.TabStop = false;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.DimGray;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Chartreuse;
            this.label5.Location = new System.Drawing.Point(12, 250);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.label5.Size = new System.Drawing.Size(417, 23);
            this.label5.TabIndex = 7;
            this.label5.Text = "All Branches List";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BranchForm
            // 
            this.AcceptButton = this.btnSaveBranch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 413);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.gbBranchEntry);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.dtgBranchInfo);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSaveBranch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "BranchForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add/Update Branch Information ";
            this.Load += new System.EventHandler(this.BranchForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgBranchInfo)).EndInit();
            this.gbBranchEntry.ResumeLayout(false);
            this.gbBranchEntry.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgBranchInfo;
        private System.Windows.Forms.TextBox txtBranchName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.DateTimePicker dtOpenDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox gbBranchEntry;
        private System.Windows.Forms.Button btnSaveBranch;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTelephone;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtWeb;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtFax;
        private System.Windows.Forms.Label label9;
    }
}