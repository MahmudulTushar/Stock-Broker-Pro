namespace StockbrokerProNewArch
{
    partial class frmExpense_CategoryEntry
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
            GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory defaultGridFilterFactory1 = new GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExpense_CategoryEntry));
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.gbCategory = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSubCategory = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dgvCategory = new System.Windows.Forms.DataGridView();
            this.btnNew = new System.Windows.Forms.Button();
            this.dataGridFilterExtender1 = new GridViewExtensions.DataGridFilterExtender(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblTotalRecord = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnSaveHoliday = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.ddlCategorytype = new System.Windows.Forms.ComboBox();
            this.gbCategory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFilterExtender1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCategory
            // 
            this.txtCategory.Location = new System.Drawing.Point(160, 28);
            this.txtCategory.MaxLength = 50;
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(223, 20);
            this.txtCategory.TabIndex = 48;
            // 
            // gbCategory
            // 
            this.gbCategory.Controls.Add(this.ddlCategorytype);
            this.gbCategory.Controls.Add(this.label6);
            this.gbCategory.Controls.Add(this.label3);
            this.gbCategory.Controls.Add(this.label2);
            this.gbCategory.Controls.Add(this.txtSubCategory);
            this.gbCategory.Controls.Add(this.label4);
            this.gbCategory.Controls.Add(this.label1);
            this.gbCategory.Controls.Add(this.txtCategory);
            this.gbCategory.Controls.Add(this.label10);
            this.gbCategory.ImeMode = System.Windows.Forms.ImeMode.On;
            this.gbCategory.Location = new System.Drawing.Point(12, 12);
            this.gbCategory.Name = "gbCategory";
            this.gbCategory.Size = new System.Drawing.Size(420, 120);
            this.gbCategory.TabIndex = 71;
            this.gbCategory.TabStop = false;
            this.gbCategory.Text = "Category";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(138, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(10, 13);
            this.label6.TabIndex = 49;
            this.label6.Text = ":";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(139, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 13);
            this.label3.TabIndex = 49;
            this.label3.Text = ":";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(138, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 13);
            this.label2.TabIndex = 49;
            this.label2.Text = ":";
            // 
            // txtSubCategory
            // 
            this.txtSubCategory.Location = new System.Drawing.Point(160, 80);
            this.txtSubCategory.MaxLength = 50;
            this.txtSubCategory.Name = "txtSubCategory";
            this.txtSubCategory.Size = new System.Drawing.Size(223, 20);
            this.txtSubCategory.TabIndex = 48;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Gray;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(17, 80);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label4.Size = new System.Drawing.Size(113, 20);
            this.label4.TabIndex = 50;
            this.label4.Text = "Sub Category";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Gray;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(18, 54);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label1.Size = new System.Drawing.Size(113, 20);
            this.label1.TabIndex = 50;
            this.label1.Text = "Category Type";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Gray;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(17, 28);
            this.label10.Name = "label10";
            this.label10.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label10.Size = new System.Drawing.Size(113, 20);
            this.label10.TabIndex = 50;
            this.label10.Text = "Category Name";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvCategory
            // 
            this.dgvCategory.AllowUserToAddRows = false;
            this.dgvCategory.AllowUserToDeleteRows = false;
            this.dgvCategory.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Navy;
            this.dgvCategory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCategory.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvCategory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCategory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCategory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCategory.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCategory.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvCategory.Location = new System.Drawing.Point(12, 215);
            this.dgvCategory.MultiSelect = false;
            this.dgvCategory.Name = "dgvCategory";
            this.dgvCategory.ReadOnly = true;
            this.dgvCategory.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvCategory.RowHeadersVisible = false;
            this.dgvCategory.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvCategory.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCategory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCategory.Size = new System.Drawing.Size(420, 207);
            this.dgvCategory.TabIndex = 67;
            this.dgvCategory.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCategory_CellClick);
            this.dgvCategory.SelectionChanged += new System.EventHandler(this.dgvCategory_SelectionChanged);
            // 
            // btnNew
            // 
            this.btnNew.Enabled = false;
            this.btnNew.Location = new System.Drawing.Point(45, 144);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(78, 25);
            this.btnNew.TabIndex = 74;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // dataGridFilterExtender1
            // 
            this.dataGridFilterExtender1.DataGridView = this.dgvCategory;
            defaultGridFilterFactory1.CreateDistinctGridFilters = false;
            defaultGridFilterFactory1.DefaultGridFilterType = typeof(GridViewExtensions.GridFilters.TextGridFilter);
            defaultGridFilterFactory1.DefaultShowDateInBetweenOperator = false;
            defaultGridFilterFactory1.DefaultShowNumericInBetweenOperator = false;
            defaultGridFilterFactory1.HandleEnumerationTypes = true;
            defaultGridFilterFactory1.MaximumDistinctValues = 20;
            this.dataGridFilterExtender1.FilterFactory = defaultGridFilterFactory1;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.DimGray;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Chartreuse;
            this.label5.Location = new System.Drawing.Point(12, 175);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.label5.Size = new System.Drawing.Size(420, 20);
            this.label5.TabIndex = 68;
            this.label5.Text = "Category List";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(303, 144);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnCancel.Size = new System.Drawing.Size(92, 25);
            this.btnCancel.TabIndex = 70;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Close";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblTotalRecord
            // 
            this.lblTotalRecord.BackColor = System.Drawing.Color.DimGray;
            this.lblTotalRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRecord.ForeColor = System.Drawing.Color.Chartreuse;
            this.lblTotalRecord.Location = new System.Drawing.Point(220, 175);
            this.lblTotalRecord.Name = "lblTotalRecord";
            this.lblTotalRecord.Size = new System.Drawing.Size(212, 16);
            this.lblTotalRecord.TabIndex = 75;
            this.lblTotalRecord.Text = "Total : 0";
            this.lblTotalRecord.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(126, 144);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(77, 25);
            this.btnUpdate.TabIndex = 73;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnSaveHoliday
            // 
            this.btnSaveHoliday.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveHoliday.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnSaveHoliday.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveHoliday.Image")));
            this.btnSaveHoliday.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveHoliday.Location = new System.Drawing.Point(206, 144);
            this.btnSaveHoliday.Name = "btnSaveHoliday";
            this.btnSaveHoliday.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnSaveHoliday.Size = new System.Drawing.Size(91, 25);
            this.btnSaveHoliday.TabIndex = 69;
            this.btnSaveHoliday.TabStop = false;
            this.btnSaveHoliday.Text = "Save";
            this.btnSaveHoliday.UseVisualStyleBackColor = true;
            this.btnSaveHoliday.Click += new System.EventHandler(this.btnSaveCategory_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnDelete.Image = global::StockbrokerProNewArch.Properties.Resources.Close_2_icon;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(354, 428);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(78, 25);
            this.btnDelete.TabIndex = 72;
            this.btnDelete.Text = "Cancel";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // ddlCategorytype
            // 
            this.ddlCategorytype.FormattingEnabled = true;
            this.ddlCategorytype.Location = new System.Drawing.Point(160, 55);
            this.ddlCategorytype.Name = "ddlCategorytype";
            this.ddlCategorytype.Size = new System.Drawing.Size(121, 21);
            this.ddlCategorytype.TabIndex = 51;
            // 
            // frmCategoryEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 463);
            this.Controls.Add(this.gbCategory);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnSaveHoliday);
            this.Controls.Add(this.lblTotalRecord);
            this.Controls.Add(this.dgvCategory);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnCancel);
            this.MaximizeBox = false;
            this.Name = "frmCategoryEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Category Entry";
            this.Load += new System.EventHandler(this.frmCategoryEntry_Load);
            this.gbCategory.ResumeLayout(false);
            this.gbCategory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFilterExtender1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.GroupBox gbCategory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dgvCategory;
        private System.Windows.Forms.Button btnNew;
        private GridViewExtensions.DataGridFilterExtender dataGridFilterExtender1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblTotalRecord;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnSaveHoliday;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSubCategory;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ddlCategorytype;
    }
}