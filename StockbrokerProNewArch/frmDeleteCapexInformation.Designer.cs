namespace StockbrokerProNewArch
{
    partial class frmDeleteCapexInformation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDeleteCapexInformation));
            GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory defaultGridFilterFactory2 = new GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblDepriciationAmount = new System.Windows.Forms.Label();
            this.lblSalaveAmount = new System.Windows.Forms.Label();
            this.lblPurposeAmount = new System.Windows.Forms.Label();
            this.lblTotalRecord = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvAssetInfo = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.dataGridFilterExtender1 = new GridViewExtensions.DataGridFilterExtender(this.components);
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssetInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFilterExtender1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblDepriciationAmount);
            this.groupBox2.Controls.Add(this.lblSalaveAmount);
            this.groupBox2.Controls.Add(this.lblPurposeAmount);
            this.groupBox2.Controls.Add(this.lblTotalRecord);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(13, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(642, 43);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Summary Information";
            // 
            // lblDepriciationAmount
            // 
            this.lblDepriciationAmount.AutoSize = true;
            this.lblDepriciationAmount.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepriciationAmount.ForeColor = System.Drawing.Color.Black;
            this.lblDepriciationAmount.Location = new System.Drawing.Point(462, 21);
            this.lblDepriciationAmount.Name = "lblDepriciationAmount";
            this.lblDepriciationAmount.Size = new System.Drawing.Size(35, 13);
            this.lblDepriciationAmount.TabIndex = 14;
            this.lblDepriciationAmount.Text = "label8";
            // 
            // lblSalaveAmount
            // 
            this.lblSalaveAmount.AutoSize = true;
            this.lblSalaveAmount.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalaveAmount.ForeColor = System.Drawing.Color.Black;
            this.lblSalaveAmount.Location = new System.Drawing.Point(296, 21);
            this.lblSalaveAmount.Name = "lblSalaveAmount";
            this.lblSalaveAmount.Size = new System.Drawing.Size(35, 13);
            this.lblSalaveAmount.TabIndex = 2;
            this.lblSalaveAmount.Text = "label8";
            // 
            // lblPurposeAmount
            // 
            this.lblPurposeAmount.AutoSize = true;
            this.lblPurposeAmount.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPurposeAmount.ForeColor = System.Drawing.Color.Black;
            this.lblPurposeAmount.Location = new System.Drawing.Point(155, 21);
            this.lblPurposeAmount.Name = "lblPurposeAmount";
            this.lblPurposeAmount.Size = new System.Drawing.Size(35, 13);
            this.lblPurposeAmount.TabIndex = 1;
            this.lblPurposeAmount.Text = "label8";
            // 
            // lblTotalRecord
            // 
            this.lblTotalRecord.AutoSize = true;
            this.lblTotalRecord.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRecord.ForeColor = System.Drawing.Color.Black;
            this.lblTotalRecord.Location = new System.Drawing.Point(23, 21);
            this.lblTotalRecord.Name = "lblTotalRecord";
            this.lblTotalRecord.Size = new System.Drawing.Size(35, 13);
            this.lblTotalRecord.TabIndex = 0;
            this.lblTotalRecord.Text = "label8";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvAssetInfo);
            this.groupBox3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.Black;
            this.groupBox3.Location = new System.Drawing.Point(10, 56);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(645, 329);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Highlight Information";
            // 
            // dgvAssetInfo
            // 
            this.dgvAssetInfo.AllowUserToAddRows = false;
            this.dgvAssetInfo.AllowUserToDeleteRows = false;
            this.dgvAssetInfo.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.DarkRed;
            this.dgvAssetInfo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvAssetInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvAssetInfo.BackgroundColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAssetInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvAssetInfo.ColumnHeadersHeight = 42;
            this.dgvAssetInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.DarkRed;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAssetInfo.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvAssetInfo.EnableHeadersVisualStyles = false;
            this.dgvAssetInfo.GridColor = System.Drawing.Color.LightGray;
            this.dgvAssetInfo.Location = new System.Drawing.Point(3, 39);
            this.dgvAssetInfo.MultiSelect = false;
            this.dgvAssetInfo.Name = "dgvAssetInfo";
            this.dgvAssetInfo.ReadOnly = true;
            this.dgvAssetInfo.RowHeadersVisible = false;
            this.dgvAssetInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAssetInfo.Size = new System.Drawing.Size(636, 280);
            this.dgvAssetInfo.TabIndex = 0;
            this.dgvAssetInfo.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvAssetInfo_CellMouseDoubleClick);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.LightSlateGray;
            this.label1.Location = new System.Drawing.Point(13, 394);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(638, 1);
            this.label1.TabIndex = 16;
            this.label1.Text = "label1";
            // 
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.Color.Transparent;
            this.btnRemove.Enabled = false;
            this.btnRemove.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.ForeColor = System.Drawing.Color.Black;
            this.btnRemove.Location = new System.Drawing.Point(490, 401);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(80, 23);
            this.btnRemove.TabIndex = 17;
            this.btnRemove.Text = "Delete";
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(576, 401);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "  Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dataGridFilterExtender1
            // 
            this.dataGridFilterExtender1.DataGridView = this.dgvAssetInfo;
            defaultGridFilterFactory2.CreateDistinctGridFilters = false;
            defaultGridFilterFactory2.DefaultGridFilterType = typeof(GridViewExtensions.GridFilters.TextGridFilter);
            defaultGridFilterFactory2.DefaultShowDateInBetweenOperator = false;
            defaultGridFilterFactory2.DefaultShowNumericInBetweenOperator = false;
            defaultGridFilterFactory2.HandleEnumerationTypes = true;
            defaultGridFilterFactory2.MaximumDistinctValues = 20;
            this.dataGridFilterExtender1.FilterFactory = defaultGridFilterFactory2;
            // 
            // frmDeleteCapexInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 430);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frmDeleteCapexInformation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Delete Capex Information";
            this.Load += new System.EventHandler(this.frmDeleteCapexInformation_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssetInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFilterExtender1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblDepriciationAmount;
        private System.Windows.Forms.Label lblSalaveAmount;
        private System.Windows.Forms.Label lblPurposeAmount;
        private System.Windows.Forms.Label lblTotalRecord;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvAssetInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnClose;
        private GridViewExtensions.DataGridFilterExtender dataGridFilterExtender1;
    }
}