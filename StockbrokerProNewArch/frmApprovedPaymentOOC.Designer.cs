namespace StockbrokerProNewArch
{
    partial class frmApprovedPaymentOCC
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory defaultGridFilterFactory1 = new GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.ddlBranchList = new System.Windows.Forms.ComboBox();
            this.lblTotalRecord = new System.Windows.Forms.Label();
            this.dgvPaymentOOcInfo = new System.Windows.Forms.DataGridView();
            this.btnRejectedAll = new System.Windows.Forms.Button();
            this.btnApprovedAll = new System.Windows.Forms.Button();
            this.btnRejected = new System.Windows.Forms.Button();
            this.btnApproved = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnReload = new System.Windows.Forms.Button();
            this.dgvExtension = new GridViewExtensions.DataGridFilterExtender(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaymentOOcInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExtension)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.ddlBranchList);
            this.panel1.Controls.Add(this.lblTotalRecord);
            this.panel1.Location = new System.Drawing.Point(12, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(833, 26);
            this.panel1.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Branch :";
            // 
            // ddlBranchList
            // 
            this.ddlBranchList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlBranchList.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ddlBranchList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlBranchList.FormattingEnabled = true;
            this.ddlBranchList.Location = new System.Drawing.Point(61, 2);
            this.ddlBranchList.Name = "ddlBranchList";
            this.ddlBranchList.Size = new System.Drawing.Size(161, 21);
            this.ddlBranchList.TabIndex = 18;
            this.ddlBranchList.ValueMemberChanged += new System.EventHandler(this.ddlBranchList_ValueMemberChanged);
            this.ddlBranchList.SelectedValueChanged += new System.EventHandler(this.ddlBranchList_SelectedValueChanged);
            // 
            // lblTotalRecord
            // 
            this.lblTotalRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRecord.ForeColor = System.Drawing.Color.White;
            this.lblTotalRecord.Location = new System.Drawing.Point(692, 2);
            this.lblTotalRecord.Name = "lblTotalRecord";
            this.lblTotalRecord.Size = new System.Drawing.Size(131, 20);
            this.lblTotalRecord.TabIndex = 2;
            this.lblTotalRecord.Text = "Total Record : 0";
            this.lblTotalRecord.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dgvPaymentOOcInfo
            // 
            this.dgvPaymentOOcInfo.AllowUserToAddRows = false;
            this.dgvPaymentOOcInfo.AllowUserToDeleteRows = false;
            this.dgvPaymentOOcInfo.AllowUserToResizeRows = false;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.DarkBlue;
            this.dgvPaymentOOcInfo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvPaymentOOcInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvPaymentOOcInfo.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvPaymentOOcInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPaymentOOcInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvPaymentOOcInfo.ColumnHeadersHeight = 28;
            this.dgvPaymentOOcInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPaymentOOcInfo.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgvPaymentOOcInfo.GridColor = System.Drawing.Color.Silver;
            this.dgvPaymentOOcInfo.Location = new System.Drawing.Point(12, 55);
            this.dgvPaymentOOcInfo.MultiSelect = false;
            this.dgvPaymentOOcInfo.Name = "dgvPaymentOOcInfo";
            this.dgvPaymentOOcInfo.ReadOnly = true;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPaymentOOcInfo.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvPaymentOOcInfo.RowHeadersVisible = false;
            this.dgvPaymentOOcInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPaymentOOcInfo.Size = new System.Drawing.Size(833, 437);
            this.dgvPaymentOOcInfo.TabIndex = 9;
            // 
            // btnRejectedAll
            // 
            this.btnRejectedAll.BackColor = System.Drawing.Color.Transparent;
            this.btnRejectedAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRejectedAll.ForeColor = System.Drawing.Color.Black;
            this.btnRejectedAll.Location = new System.Drawing.Point(12, 498);
            this.btnRejectedAll.Name = "btnRejectedAll";
            this.btnRejectedAll.Size = new System.Drawing.Size(91, 23);
            this.btnRejectedAll.TabIndex = 11;
            this.btnRejectedAll.Text = "Rejected All";
            this.btnRejectedAll.UseVisualStyleBackColor = false;
            this.btnRejectedAll.Click += new System.EventHandler(this.btnRejectedAll_Click);
            // 
            // btnApprovedAll
            // 
            this.btnApprovedAll.BackColor = System.Drawing.Color.Transparent;
            this.btnApprovedAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApprovedAll.ForeColor = System.Drawing.Color.Black;
            this.btnApprovedAll.Location = new System.Drawing.Point(107, 498);
            this.btnApprovedAll.Name = "btnApprovedAll";
            this.btnApprovedAll.Size = new System.Drawing.Size(91, 23);
            this.btnApprovedAll.TabIndex = 12;
            this.btnApprovedAll.Text = "Approved All";
            this.btnApprovedAll.UseVisualStyleBackColor = false;
            this.btnApprovedAll.Click += new System.EventHandler(this.btnApprovedAll_Click);
            // 
            // btnRejected
            // 
            this.btnRejected.BackColor = System.Drawing.Color.Transparent;
            this.btnRejected.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRejected.ForeColor = System.Drawing.Color.Black;
            this.btnRejected.Location = new System.Drawing.Point(695, 498);
            this.btnRejected.Name = "btnRejected";
            this.btnRejected.Size = new System.Drawing.Size(79, 23);
            this.btnRejected.TabIndex = 14;
            this.btnRejected.Text = "Rejected";
            this.btnRejected.UseVisualStyleBackColor = false;
            this.btnRejected.Click += new System.EventHandler(this.btnRejected_Click);
            // 
            // btnApproved
            // 
            this.btnApproved.BackColor = System.Drawing.Color.Transparent;
            this.btnApproved.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApproved.ForeColor = System.Drawing.Color.Black;
            this.btnApproved.Location = new System.Drawing.Point(611, 498);
            this.btnApproved.Name = "btnApproved";
            this.btnApproved.Size = new System.Drawing.Size(80, 23);
            this.btnApproved.TabIndex = 13;
            this.btnApproved.Text = "Approved";
            this.btnApproved.UseVisualStyleBackColor = false;
            this.btnApproved.Click += new System.EventHandler(this.btnApproved_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(778, 498);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(71, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnReload
            // 
            this.btnReload.BackColor = System.Drawing.Color.Transparent;
            this.btnReload.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReload.ForeColor = System.Drawing.Color.Black;
            this.btnReload.Location = new System.Drawing.Point(204, 498);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(80, 23);
            this.btnReload.TabIndex = 16;
            this.btnReload.Text = "Reload";
            this.btnReload.UseVisualStyleBackColor = false;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // dgvExtension
            // 
            this.dgvExtension.DataGridView = this.dgvPaymentOOcInfo;
            defaultGridFilterFactory1.CreateDistinctGridFilters = false;
            defaultGridFilterFactory1.DefaultGridFilterType = typeof(GridViewExtensions.GridFilters.TextGridFilter);
            defaultGridFilterFactory1.DefaultShowDateInBetweenOperator = false;
            defaultGridFilterFactory1.DefaultShowNumericInBetweenOperator = false;
            defaultGridFilterFactory1.HandleEnumerationTypes = true;
            defaultGridFilterFactory1.MaximumDistinctValues = 20;
            this.dgvExtension.FilterFactory = defaultGridFilterFactory1;
            // 
            // frmApprovedPaymentOCC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 529);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnRejected);
            this.Controls.Add(this.btnApproved);
            this.Controls.Add(this.btnApprovedAll);
            this.Controls.Add(this.btnRejectedAll);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvPaymentOOcInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frmApprovedPaymentOCC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Approved Others Charges & Credits";
            this.Load += new System.EventHandler(this.frmApprovedPaymentOCC_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaymentOOcInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExtension)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTotalRecord;
        private System.Windows.Forms.DataGridView dgvPaymentOOcInfo;
        private System.Windows.Forms.Button btnRejectedAll;
        private System.Windows.Forms.Button btnApprovedAll;
        private System.Windows.Forms.Button btnRejected;
        private System.Windows.Forms.Button btnApproved;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox ddlBranchList;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Label label1;
        private GridViewExtensions.DataGridFilterExtender dgvExtension;
    }
}