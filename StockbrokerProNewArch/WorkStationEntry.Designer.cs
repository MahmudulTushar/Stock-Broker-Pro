namespace StockbrokerProNewArch
{
    partial class WorkStationEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkStationEntry));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSaveWorkStation = new System.Windows.Forms.Button();
            this.gbWorkStationEntry = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtWorkStationName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ddlBranchName = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtgWorkStation = new System.Windows.Forms.DataGridView();
            this.lblRecord = new System.Windows.Forms.Label();
            this.gbWorkStationEntry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgWorkStation)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.Image")));
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.Location = new System.Drawing.Point(112, 123);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnUpdate.Size = new System.Drawing.Size(90, 25);
            this.btnUpdate.TabIndex = 45;
            this.btnUpdate.TabStop = false;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnNew
            // 
            this.btnNew.Enabled = false;
            this.btnNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(16, 123);
            this.btnNew.Name = "btnNew";
            this.btnNew.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnNew.Size = new System.Drawing.Size(90, 25);
            this.btnNew.TabIndex = 44;
            this.btnNew.TabStop = false;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(304, 123);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnCancel.Size = new System.Drawing.Size(90, 25);
            this.btnCancel.TabIndex = 47;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSaveWorkStation
            // 
            this.btnSaveWorkStation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveWorkStation.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnSaveWorkStation.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveWorkStation.Image")));
            this.btnSaveWorkStation.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveWorkStation.Location = new System.Drawing.Point(208, 123);
            this.btnSaveWorkStation.Name = "btnSaveWorkStation";
            this.btnSaveWorkStation.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnSaveWorkStation.Size = new System.Drawing.Size(90, 25);
            this.btnSaveWorkStation.TabIndex = 46;
            this.btnSaveWorkStation.TabStop = false;
            this.btnSaveWorkStation.Text = "Save";
            this.btnSaveWorkStation.UseVisualStyleBackColor = true;
            this.btnSaveWorkStation.Click += new System.EventHandler(this.btnSaveBranch_Click);
            // 
            // gbWorkStationEntry
            // 
            this.gbWorkStationEntry.Controls.Add(this.label2);
            this.gbWorkStationEntry.Controls.Add(this.label1);
            this.gbWorkStationEntry.Controls.Add(this.label3);
            this.gbWorkStationEntry.Controls.Add(this.txtWorkStationName);
            this.gbWorkStationEntry.Controls.Add(this.label4);
            this.gbWorkStationEntry.Controls.Add(this.ddlBranchName);
            this.gbWorkStationEntry.Location = new System.Drawing.Point(12, 12);
            this.gbWorkStationEntry.Name = "gbWorkStationEntry";
            this.gbWorkStationEntry.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gbWorkStationEntry.Size = new System.Drawing.Size(387, 100);
            this.gbWorkStationEntry.TabIndex = 48;
            this.gbWorkStationEntry.TabStop = false;
            this.gbWorkStationEntry.Text = "Workstation Information";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(155, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 13);
            this.label2.TabIndex = 49;
            this.label2.Text = ":";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Gray;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(25, 58);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label1.Size = new System.Drawing.Size(124, 20);
            this.label1.TabIndex = 48;
            this.label1.Text = "Branch Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(155, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 13);
            this.label3.TabIndex = 46;
            this.label3.Text = ":";
            // 
            // txtWorkStationName
            // 
            this.txtWorkStationName.Location = new System.Drawing.Point(168, 23);
            this.txtWorkStationName.MaxLength = 50;
            this.txtWorkStationName.Name = "txtWorkStationName";
            this.txtWorkStationName.Size = new System.Drawing.Size(194, 20);
            this.txtWorkStationName.TabIndex = 45;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Gray;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(25, 23);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label4.Size = new System.Drawing.Size(124, 20);
            this.label4.TabIndex = 47;
            this.label4.Text = "Workstation Name";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ddlBranchName
            // 
            this.ddlBranchName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlBranchName.FormattingEnabled = true;
            this.ddlBranchName.Location = new System.Drawing.Point(168, 54);
            this.ddlBranchName.Name = "ddlBranchName";
            this.ddlBranchName.Size = new System.Drawing.Size(194, 21);
            this.ddlBranchName.TabIndex = 44;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.DimGray;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Chartreuse;
            this.label5.Location = new System.Drawing.Point(9, 154);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.label5.Size = new System.Drawing.Size(390, 22);
            this.label5.TabIndex = 50;
            this.label5.Text = "All Workstations List";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtgWorkStation
            // 
            this.dtgWorkStation.AllowUserToAddRows = false;
            this.dtgWorkStation.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgWorkStation.BackgroundColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgWorkStation.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgWorkStation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgWorkStation.Location = new System.Drawing.Point(9, 176);
            this.dtgWorkStation.MultiSelect = false;
            this.dtgWorkStation.Name = "dtgWorkStation";
            this.dtgWorkStation.ReadOnly = true;
            this.dtgWorkStation.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dtgWorkStation.RowHeadersVisible = false;
            this.dtgWorkStation.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dtgWorkStation.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgWorkStation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgWorkStation.Size = new System.Drawing.Size(390, 131);
            this.dtgWorkStation.TabIndex = 49;
            this.dtgWorkStation.SelectionChanged += new System.EventHandler(this.dtgWorkStation_SelectionChanged);
            // 
            // lblRecord
            // 
            this.lblRecord.BackColor = System.Drawing.Color.DimGray;
            this.lblRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecord.ForeColor = System.Drawing.Color.Chartreuse;
            this.lblRecord.Location = new System.Drawing.Point(253, 154);
            this.lblRecord.Name = "lblRecord";
            this.lblRecord.Size = new System.Drawing.Size(143, 22);
            this.lblRecord.TabIndex = 51;
            this.lblRecord.Text = "Total Workstation : 0";
            this.lblRecord.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // WorkStationEntry
            // 
            this.AcceptButton = this.btnSaveWorkStation;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 321);
            this.Controls.Add(this.lblRecord);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtgWorkStation);
            this.Controls.Add(this.gbWorkStationEntry);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSaveWorkStation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "WorkStationEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Branchwise Workstation Information";
            this.Load += new System.EventHandler(this.WorkStationEntry_Load);
            this.gbWorkStationEntry.ResumeLayout(false);
            this.gbWorkStationEntry.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgWorkStation)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSaveWorkStation;
        private System.Windows.Forms.GroupBox gbWorkStationEntry;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtWorkStationName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox ddlBranchName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dtgWorkStation;
        private System.Windows.Forms.Label lblRecord;

    }
}