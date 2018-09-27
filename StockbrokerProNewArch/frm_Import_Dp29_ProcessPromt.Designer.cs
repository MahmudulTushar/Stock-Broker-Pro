namespace StockbrokerProNewArch
{
    partial class frm_Import_Dp29_ProcessPromt
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
            this.dgvColumnSelect = new System.Windows.Forms.DataGridView();
            this.btn_Ok = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.chk_SelectAll = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.columnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isUpdated = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColumnSelect)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvColumnSelect
            // 
            this.dgvColumnSelect.AllowUserToAddRows = false;
            this.dgvColumnSelect.AllowUserToDeleteRows = false;
            this.dgvColumnSelect.AllowUserToResizeColumns = false;
            this.dgvColumnSelect.AllowUserToResizeRows = false;
            this.dgvColumnSelect.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvColumnSelect.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnName,
            this.isUpdated});
            this.dgvColumnSelect.Location = new System.Drawing.Point(3, 21);
            this.dgvColumnSelect.Name = "dgvColumnSelect";
            this.dgvColumnSelect.RowHeadersVisible = false;
            this.dgvColumnSelect.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvColumnSelect.Size = new System.Drawing.Size(255, 216);
            this.dgvColumnSelect.TabIndex = 0;
            // 
            // btn_Ok
            // 
            this.btn_Ok.Location = new System.Drawing.Point(13, 266);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(75, 23);
            this.btn_Ok.TabIndex = 2;
            this.btn_Ok.Text = "OK";
            this.btn_Ok.UseVisualStyleBackColor = true;
            this.btn_Ok.Click += new System.EventHandler(this.btn_Ok_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(175, 266);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 3;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // chk_SelectAll
            // 
            this.chk_SelectAll.AutoSize = true;
            this.chk_SelectAll.Location = new System.Drawing.Point(188, 243);
            this.chk_SelectAll.Name = "chk_SelectAll";
            this.chk_SelectAll.Size = new System.Drawing.Size(70, 17);
            this.chk_SelectAll.TabIndex = 4;
            this.chk_SelectAll.Text = "Select All";
            this.chk_SelectAll.UseVisualStyleBackColor = true;
            this.chk_SelectAll.CheckedChanged += new System.EventHandler(this.chk_SelectAll_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select ";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(94, 266);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Refresh";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // columnName
            // 
            this.columnName.DataPropertyName = "columnName";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.columnName.DefaultCellStyle = dataGridViewCellStyle1;
            this.columnName.HeaderText = "ColumnName";
            this.columnName.Name = "columnName";
            this.columnName.ReadOnly = true;
            this.columnName.Width = 162;
            // 
            // isUpdated
            // 
            this.isUpdated.DataPropertyName = "isUpdated";
            this.isUpdated.HeaderText = "Updated?";
            this.isUpdated.Name = "isUpdated";
            this.isUpdated.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.isUpdated.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.isUpdated.Width = 89;
            // 
            // frm_Import_Dp29_ProcessPromt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 295);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chk_SelectAll);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Ok);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvColumnSelect);
            this.Name = "frm_Import_Dp29_ProcessPromt";
            this.Text = "Data Select";
            ((System.ComponentModel.ISupportInitialize)(this.dgvColumnSelect)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvColumnSelect;
        private System.Windows.Forms.Button btn_Ok;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.CheckBox chk_SelectAll;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isUpdated;
    }
}