namespace StockbrokerProNewArch
{
    partial class frmEmployeeApproved
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmployeeApproved));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvEmployeeInfo = new System.Windows.Forms.DataGridView();
            this.lblTotalEmployee = new System.Windows.Forms.Label();
            this.lblTotalJobPosition = new System.Windows.Forms.Label();
            this.lblTotalDepartment = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnApprovedAll = new System.Windows.Forms.Button();
            this.btnReject = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnReload = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployeeInfo)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.dgvEmployeeInfo);
            this.groupBox2.Location = new System.Drawing.Point(13, 59);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(574, 356);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SlateGray;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(568, 24);
            this.label1.TabIndex = 8;
            this.label1.Text = "Total Record : 0";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dgvEmployeeInfo
            // 
            this.dgvEmployeeInfo.AllowUserToAddRows = false;
            this.dgvEmployeeInfo.AllowUserToDeleteRows = false;
            this.dgvEmployeeInfo.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.DarkRed;
            this.dgvEmployeeInfo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvEmployeeInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEmployeeInfo.BackgroundColor = System.Drawing.Color.LightSteelBlue;
            this.dgvEmployeeInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEmployeeInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvEmployeeInfo.ColumnHeadersHeight = 30;
            this.dgvEmployeeInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LavenderBlush;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.DarkRed;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEmployeeInfo.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvEmployeeInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvEmployeeInfo.EnableHeadersVisualStyles = false;
            this.dgvEmployeeInfo.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dgvEmployeeInfo.Location = new System.Drawing.Point(3, 40);
            this.dgvEmployeeInfo.MultiSelect = false;
            this.dgvEmployeeInfo.Name = "dgvEmployeeInfo";
            this.dgvEmployeeInfo.ReadOnly = true;
            this.dgvEmployeeInfo.RowHeadersVisible = false;
            this.dgvEmployeeInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmployeeInfo.Size = new System.Drawing.Size(568, 313);
            this.dgvEmployeeInfo.TabIndex = 0;
            this.dgvEmployeeInfo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvEmployeeInfo_MouseClick);
            // 
            // lblTotalEmployee
            // 
            this.lblTotalEmployee.BackColor = System.Drawing.Color.AliceBlue;
            this.lblTotalEmployee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalEmployee.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblTotalEmployee.Location = new System.Drawing.Point(407, 9);
            this.lblTotalEmployee.Name = "lblTotalEmployee";
            this.lblTotalEmployee.Size = new System.Drawing.Size(147, 23);
            this.lblTotalEmployee.TabIndex = 2;
            this.lblTotalEmployee.Tag = "";
            this.lblTotalEmployee.Text = "Total Employee : 0";
            this.lblTotalEmployee.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalJobPosition
            // 
            this.lblTotalJobPosition.BackColor = System.Drawing.Color.AliceBlue;
            this.lblTotalJobPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalJobPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalJobPosition.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblTotalJobPosition.Location = new System.Drawing.Point(213, 9);
            this.lblTotalJobPosition.Name = "lblTotalJobPosition";
            this.lblTotalJobPosition.Size = new System.Drawing.Size(144, 23);
            this.lblTotalJobPosition.TabIndex = 2;
            this.lblTotalJobPosition.Text = "Total Designation : 0";
            this.lblTotalJobPosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalDepartment
            // 
            this.lblTotalDepartment.BackColor = System.Drawing.Color.AliceBlue;
            this.lblTotalDepartment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalDepartment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblTotalDepartment.Location = new System.Drawing.Point(17, 9);
            this.lblTotalDepartment.Name = "lblTotalDepartment";
            this.lblTotalDepartment.Size = new System.Drawing.Size(145, 23);
            this.lblTotalDepartment.TabIndex = 0;
            this.lblTotalDepartment.Text = "Total Department : 0";
            this.lblTotalDepartment.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.Transparent;
            this.btnConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnConfirm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfirm.Location = new System.Drawing.Point(437, 421);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(84, 25);
            this.btnConfirm.TabIndex = 3;
            this.btnConfirm.Text = "Approved";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Brown;
            this.button1.Location = new System.Drawing.Point(523, 421);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(64, 25);
            this.button1.TabIndex = 4;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnApprovedAll
            // 
            this.btnApprovedAll.BackColor = System.Drawing.Color.Transparent;
            this.btnApprovedAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApprovedAll.ForeColor = System.Drawing.Color.ForestGreen;
            this.btnApprovedAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnApprovedAll.Location = new System.Drawing.Point(83, 421);
            this.btnApprovedAll.Name = "btnApprovedAll";
            this.btnApprovedAll.Size = new System.Drawing.Size(89, 25);
            this.btnApprovedAll.TabIndex = 5;
            this.btnApprovedAll.Text = "Approved All";
            this.btnApprovedAll.UseVisualStyleBackColor = false;
            this.btnApprovedAll.Click += new System.EventHandler(this.btnApprovedAll_Click);
            // 
            // btnReject
            // 
            this.btnReject.BackColor = System.Drawing.Color.Transparent;
            this.btnReject.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReject.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnReject.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReject.Location = new System.Drawing.Point(13, 421);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(70, 25);
            this.btnReject.TabIndex = 6;
            this.btnReject.Text = "Reject";
            this.btnReject.UseVisualStyleBackColor = false;
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.AliceBlue;
            this.panel1.Controls.Add(this.lblTotalEmployee);
            this.panel1.Controls.Add(this.lblTotalDepartment);
            this.panel1.Controls.Add(this.lblTotalJobPosition);
            this.panel1.Location = new System.Drawing.Point(13, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(571, 41);
            this.panel1.TabIndex = 7;
            // 
            // btnReload
            // 
            this.btnReload.BackColor = System.Drawing.Color.Transparent;
            this.btnReload.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReload.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btnReload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReload.Location = new System.Drawing.Point(346, 421);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(86, 25);
            this.btnReload.TabIndex = 8;
            this.btnReload.Text = "Reload Data";
            this.btnReload.UseVisualStyleBackColor = false;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // frmEmployeeApproved
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(238)))));
            this.ClientSize = new System.Drawing.Size(598, 451);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnReject);
            this.Controls.Add(this.btnApprovedAll);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmEmployeeApproved";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Employee Unapproved  Leave List";
            this.Load += new System.EventHandler(this.frmEmployeeHoldiday_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployeeInfo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvEmployeeInfo;
        private System.Windows.Forms.Label lblTotalEmployee;
        private System.Windows.Forms.Label lblTotalJobPosition;
        private System.Windows.Forms.Label lblTotalDepartment;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnApprovedAll;
        private System.Windows.Forms.Button btnReject;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnReload;
    }
}