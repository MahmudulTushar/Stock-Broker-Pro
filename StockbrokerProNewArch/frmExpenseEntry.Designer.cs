namespace StockbrokerProNewArch
{
    partial class frmExpenseEntry
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory defaultGridFilterFactory2 = new GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExpenseEntry));
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txtExpenseDescription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbCategory = new System.Windows.Forms.GroupBox();
            this.ddlExpenseFrequency = new System.Windows.Forms.ComboBox();
            this.ddlCategoryName = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblTotalRecord = new System.Windows.Forms.Label();
            this.dgvExpense = new System.Windows.Forms.DataGridView();
            this.btnNew = new System.Windows.Forms.Button();
            this.dataGridFilterExtender1 = new GridViewExtensions.DataGridFilterExtender(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSaveExpense = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.gbCategory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpense)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFilterExtender1)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(161, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 13);
            this.label3.TabIndex = 49;
            this.label3.Text = ":";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Gray;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(17, 80);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label4.Size = new System.Drawing.Size(137, 20);
            this.label4.TabIndex = 50;
            this.label4.Text = "Expense Frequency";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(126, 144);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(77, 25);
            this.btnUpdate.TabIndex = 83;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txtExpenseDescription
            // 
            this.txtExpenseDescription.Location = new System.Drawing.Point(186, 54);
            this.txtExpenseDescription.MaxLength = 50;
            this.txtExpenseDescription.Name = "txtExpenseDescription";
            this.txtExpenseDescription.Size = new System.Drawing.Size(197, 20);
            this.txtExpenseDescription.TabIndex = 48;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Gray;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(17, 54);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label1.Size = new System.Drawing.Size(137, 20);
            this.label1.TabIndex = 50;
            this.label1.Text = "Expense Description";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gbCategory
            // 
            this.gbCategory.Controls.Add(this.ddlExpenseFrequency);
            this.gbCategory.Controls.Add(this.ddlCategoryName);
            this.gbCategory.Controls.Add(this.label6);
            this.gbCategory.Controls.Add(this.label3);
            this.gbCategory.Controls.Add(this.label2);
            this.gbCategory.Controls.Add(this.label4);
            this.gbCategory.Controls.Add(this.txtExpenseDescription);
            this.gbCategory.Controls.Add(this.label1);
            this.gbCategory.Controls.Add(this.label10);
            this.gbCategory.ImeMode = System.Windows.Forms.ImeMode.On;
            this.gbCategory.Location = new System.Drawing.Point(12, 12);
            this.gbCategory.Name = "gbCategory";
            this.gbCategory.Size = new System.Drawing.Size(406, 120);
            this.gbCategory.TabIndex = 81;
            this.gbCategory.TabStop = false;
            this.gbCategory.Text = "Category";
            // 
            // ddlExpenseFrequency
            // 
            this.ddlExpenseFrequency.FormattingEnabled = true;
            this.ddlExpenseFrequency.Location = new System.Drawing.Point(186, 81);
            this.ddlExpenseFrequency.Name = "ddlExpenseFrequency";
            this.ddlExpenseFrequency.Size = new System.Drawing.Size(197, 21);
            this.ddlExpenseFrequency.TabIndex = 51;
            // 
            // ddlCategoryName
            // 
            this.ddlCategoryName.FormattingEnabled = true;
            this.ddlCategoryName.Location = new System.Drawing.Point(186, 23);
            this.ddlCategoryName.Name = "ddlCategoryName";
            this.ddlCategoryName.Size = new System.Drawing.Size(197, 21);
            this.ddlCategoryName.TabIndex = 51;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(160, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(10, 13);
            this.label6.TabIndex = 49;
            this.label6.Text = ":";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(160, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 13);
            this.label2.TabIndex = 49;
            this.label2.Text = ":";
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Gray;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(17, 28);
            this.label10.Name = "label10";
            this.label10.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label10.Size = new System.Drawing.Size(137, 20);
            this.label10.TabIndex = 50;
            this.label10.Text = "Category Name";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotalRecord
            // 
            this.lblTotalRecord.BackColor = System.Drawing.Color.DimGray;
            this.lblTotalRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRecord.ForeColor = System.Drawing.Color.Chartreuse;
            this.lblTotalRecord.Location = new System.Drawing.Point(204, 175);
            this.lblTotalRecord.Name = "lblTotalRecord";
            this.lblTotalRecord.Size = new System.Drawing.Size(212, 20);
            this.lblTotalRecord.TabIndex = 85;
            this.lblTotalRecord.Text = "Total : 0";
            this.lblTotalRecord.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // dgvExpense
            // 
            this.dgvExpense.AllowUserToAddRows = false;
            this.dgvExpense.AllowUserToDeleteRows = false;
            this.dgvExpense.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Navy;
            this.dgvExpense.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvExpense.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvExpense.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvExpense.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvExpense.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvExpense.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvExpense.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvExpense.Location = new System.Drawing.Point(12, 215);
            this.dgvExpense.MultiSelect = false;
            this.dgvExpense.Name = "dgvExpense";
            this.dgvExpense.ReadOnly = true;
            this.dgvExpense.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvExpense.RowHeadersVisible = false;
            this.dgvExpense.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvExpense.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvExpense.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvExpense.Size = new System.Drawing.Size(406, 207);
            this.dgvExpense.TabIndex = 77;
            this.dgvExpense.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvExpense_CellClick);
            this.dgvExpense.SelectionChanged += new System.EventHandler(this.dgvExpense_SelectionChanged);
            // 
            // btnNew
            // 
            this.btnNew.Enabled = false;
            this.btnNew.Location = new System.Drawing.Point(45, 144);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(78, 25);
            this.btnNew.TabIndex = 84;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // dataGridFilterExtender1
            // 
            this.dataGridFilterExtender1.DataGridView = this.dgvExpense;
            defaultGridFilterFactory2.CreateDistinctGridFilters = false;
            defaultGridFilterFactory2.DefaultGridFilterType = typeof(GridViewExtensions.GridFilters.TextGridFilter);
            defaultGridFilterFactory2.DefaultShowDateInBetweenOperator = false;
            defaultGridFilterFactory2.DefaultShowNumericInBetweenOperator = false;
            defaultGridFilterFactory2.HandleEnumerationTypes = true;
            defaultGridFilterFactory2.MaximumDistinctValues = 20;
            this.dataGridFilterExtender1.FilterFactory = defaultGridFilterFactory2;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.DimGray;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Chartreuse;
            this.label5.Location = new System.Drawing.Point(12, 175);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.label5.Size = new System.Drawing.Size(201, 20);
            this.label5.TabIndex = 78;
            this.label5.Text = "Expense List";
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
            this.btnCancel.TabIndex = 80;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Close";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSaveExpense
            // 
            this.btnSaveExpense.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveExpense.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnSaveExpense.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveExpense.Image")));
            this.btnSaveExpense.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveExpense.Location = new System.Drawing.Point(206, 144);
            this.btnSaveExpense.Name = "btnSaveExpense";
            this.btnSaveExpense.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnSaveExpense.Size = new System.Drawing.Size(91, 25);
            this.btnSaveExpense.TabIndex = 79;
            this.btnSaveExpense.TabStop = false;
            this.btnSaveExpense.Text = "Save";
            this.btnSaveExpense.UseVisualStyleBackColor = true;
            this.btnSaveExpense.Click += new System.EventHandler(this.btnSaveExpense_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnDelete.Image = global::StockbrokerProNewArch.Properties.Resources.Close_2_icon;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(340, 428);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(78, 25);
            this.btnDelete.TabIndex = 82;
            this.btnDelete.Text = "Cancel";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // frmExpenseEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 466);
            this.Controls.Add(this.gbCategory);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnSaveExpense);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblTotalRecord);
            this.Controls.Add(this.dgvExpense);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnNew);
            this.MaximizeBox = false;
            this.Name = "frmExpenseEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Expense Entry";
            this.Load += new System.EventHandler(this.frmExpenseEntry_Load);
            this.gbCategory.ResumeLayout(false);
            this.gbCategory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpense)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFilterExtender1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSaveExpense;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox txtExpenseDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbCategory;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblTotalRecord;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dgvExpense;
        private System.Windows.Forms.Button btnNew;
        private GridViewExtensions.DataGridFilterExtender dataGridFilterExtender1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox ddlCategoryName;
        private System.Windows.Forms.ComboBox ddlExpenseFrequency;
    }
}