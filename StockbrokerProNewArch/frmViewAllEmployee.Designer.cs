namespace StockbrokerProNewArch
{
    partial class frmViewAllEmployee
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmViewAllEmployee));
            GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory defaultGridFilterFactory1 = new GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvEmployeeInfo = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblTotalEmployee = new System.Windows.Forms.Label();
            this.lblTotalJobPosition = new System.Windows.Forms.Label();
            this.lblTotalDepartment = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnConfirmSalary = new System.Windows.Forms.Button();
            this.dataGridFilterExtender1 = new GridViewExtensions.DataGridFilterExtender(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployeeInfo)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFilterExtender1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvEmployeeInfo);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(664, 401);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Highlight Information";
            // 
            // dgvEmployeeInfo
            // 
            this.dgvEmployeeInfo.AllowUserToAddRows = false;
            this.dgvEmployeeInfo.AllowUserToDeleteRows = false;
            this.dgvEmployeeInfo.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.dgvEmployeeInfo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvEmployeeInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvEmployeeInfo.BackgroundColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEmployeeInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvEmployeeInfo.ColumnHeadersHeight = 42;
            this.dgvEmployeeInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEmployeeInfo.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvEmployeeInfo.EnableHeadersVisualStyles = false;
            this.dgvEmployeeInfo.GridColor = System.Drawing.Color.Silver;
            this.dgvEmployeeInfo.Location = new System.Drawing.Point(3, 39);
            this.dgvEmployeeInfo.MultiSelect = false;
            this.dgvEmployeeInfo.Name = "dgvEmployeeInfo";
            this.dgvEmployeeInfo.ReadOnly = true;
            this.dgvEmployeeInfo.RowHeadersVisible = false;
            this.dgvEmployeeInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmployeeInfo.Size = new System.Drawing.Size(658, 350);
            this.dgvEmployeeInfo.TabIndex = 0;
            this.dgvEmployeeInfo.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvEmployeeInfo_CellMouseClick);
            this.dgvEmployeeInfo.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmployeeInfo_CellContentDoubleClick);
            this.dgvEmployeeInfo.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvEmployeeInfo_CellMouseDoubleClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblTotalEmployee);
            this.groupBox2.Controls.Add(this.lblTotalJobPosition);
            this.groupBox2.Controls.Add(this.lblTotalDepartment);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(15, 417);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(661, 58);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Summery Information";
            // 
            // lblTotalEmployee
            // 
            this.lblTotalEmployee.BackColor = System.Drawing.Color.Gray;
            this.lblTotalEmployee.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotalEmployee.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalEmployee.ForeColor = System.Drawing.Color.AliceBlue;
            this.lblTotalEmployee.Location = new System.Drawing.Point(487, 22);
            this.lblTotalEmployee.Name = "lblTotalEmployee";
            this.lblTotalEmployee.Size = new System.Drawing.Size(147, 23);
            this.lblTotalEmployee.TabIndex = 2;
            this.lblTotalEmployee.Text = "label1";
            this.lblTotalEmployee.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalJobPosition
            // 
            this.lblTotalJobPosition.BackColor = System.Drawing.Color.Gray;
            this.lblTotalJobPosition.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotalJobPosition.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalJobPosition.ForeColor = System.Drawing.Color.AliceBlue;
            this.lblTotalJobPosition.Location = new System.Drawing.Point(256, 22);
            this.lblTotalJobPosition.Name = "lblTotalJobPosition";
            this.lblTotalJobPosition.Size = new System.Drawing.Size(147, 23);
            this.lblTotalJobPosition.TabIndex = 2;
            this.lblTotalJobPosition.Text = "label1";
            this.lblTotalJobPosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalDepartment
            // 
            this.lblTotalDepartment.BackColor = System.Drawing.Color.Gray;
            this.lblTotalDepartment.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotalDepartment.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalDepartment.ForeColor = System.Drawing.Color.AliceBlue;
            this.lblTotalDepartment.Location = new System.Drawing.Point(21, 22);
            this.lblTotalDepartment.Name = "lblTotalDepartment";
            this.lblTotalDepartment.Size = new System.Drawing.Size(147, 23);
            this.lblTotalDepartment.TabIndex = 0;
            this.lblTotalDepartment.Text = "label1";
            this.lblTotalDepartment.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.Location = new System.Drawing.Point(609, 485);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(67, 29);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "   Exit";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnConfirmSalary
            // 
            this.btnConfirmSalary.BackColor = System.Drawing.Color.Transparent;
            this.btnConfirmSalary.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmSalary.ForeColor = System.Drawing.Color.Black;
            this.btnConfirmSalary.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfirmSalary.Location = new System.Drawing.Point(502, 485);
            this.btnConfirmSalary.Name = "btnConfirmSalary";
            this.btnConfirmSalary.Size = new System.Drawing.Size(103, 29);
            this.btnConfirmSalary.TabIndex = 3;
            this.btnConfirmSalary.UseVisualStyleBackColor = false;
            this.btnConfirmSalary.Click += new System.EventHandler(this.btnConfirmSalary_Click);
            // 
            // dataGridFilterExtender1
            // 
            this.dataGridFilterExtender1.DataGridView = this.dgvEmployeeInfo;
            defaultGridFilterFactory1.CreateDistinctGridFilters = false;
            defaultGridFilterFactory1.DefaultGridFilterType = typeof(GridViewExtensions.GridFilters.TextGridFilter);
            defaultGridFilterFactory1.DefaultShowDateInBetweenOperator = false;
            defaultGridFilterFactory1.DefaultShowNumericInBetweenOperator = false;
            defaultGridFilterFactory1.HandleEnumerationTypes = true;
            defaultGridFilterFactory1.MaximumDistinctValues = 20;
            this.dataGridFilterExtender1.FilterFactory = defaultGridFilterFactory1;
            // 
            // frmViewAllEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(688, 518);
            this.Controls.Add(this.btnConfirmSalary);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.Color.DarkSeaGreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmViewAllEmployee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Salary Confirmation : Employee Information";
            this.Load += new System.EventHandler(this.frmViewAllEmployee_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployeeInfo)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFilterExtender1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvEmployeeInfo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblTotalEmployee;
        private System.Windows.Forms.Label lblTotalJobPosition;
        private System.Windows.Forms.Label lblTotalDepartment;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnConfirmSalary;
        private GridViewExtensions.DataGridFilterExtender dataGridFilterExtender1;
    }
}