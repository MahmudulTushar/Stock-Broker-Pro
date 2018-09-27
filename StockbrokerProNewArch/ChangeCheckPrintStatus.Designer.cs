namespace StockbrokerProNewArch
{
    partial class ChangeCheckPrintStatus
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory defaultGridFilterFactory1 = new GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory();
            this.label5 = new System.Windows.Forms.Label();
            this.dtgCheckPrintingHistory = new System.Windows.Forms.DataGridView();
            this.btnChangeStatus = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblTotalRecord = new System.Windows.Forms.Label();
            this.dgvExtension = new GridViewExtensions.DataGridFilterExtender(this.components);
            this.dtSearchDate = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCheckPrintingHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExtension)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.DimGray;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Chartreuse;
            this.label5.Location = new System.Drawing.Point(3, 3);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.label5.Size = new System.Drawing.Size(707, 26);
            this.label5.TabIndex = 64;
            this.label5.Text = "Cheque Requisition Date :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtgCheckPrintingHistory
            // 
            this.dtgCheckPrintingHistory.AllowUserToAddRows = false;
            this.dtgCheckPrintingHistory.AllowUserToDeleteRows = false;
            this.dtgCheckPrintingHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgCheckPrintingHistory.BackgroundColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgCheckPrintingHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dtgCheckPrintingHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCheckPrintingHistory.Location = new System.Drawing.Point(2, 49);
            this.dtgCheckPrintingHistory.MultiSelect = false;
            this.dtgCheckPrintingHistory.Name = "dtgCheckPrintingHistory";
            this.dtgCheckPrintingHistory.ReadOnly = true;
            this.dtgCheckPrintingHistory.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dtgCheckPrintingHistory.RowHeadersVisible = false;
            this.dtgCheckPrintingHistory.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dtgCheckPrintingHistory.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgCheckPrintingHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgCheckPrintingHistory.Size = new System.Drawing.Size(709, 399);
            this.dtgCheckPrintingHistory.TabIndex = 63;
            // 
            // btnChangeStatus
            // 
            this.btnChangeStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangeStatus.ForeColor = System.Drawing.Color.DarkRed;
            this.btnChangeStatus.Location = new System.Drawing.Point(507, 453);
            this.btnChangeStatus.Name = "btnChangeStatus";
            this.btnChangeStatus.Size = new System.Drawing.Size(130, 23);
            this.btnChangeStatus.TabIndex = 65;
            this.btnChangeStatus.Text = "Change Status Re-print";
            this.btnChangeStatus.UseVisualStyleBackColor = true;
            this.btnChangeStatus.Click += new System.EventHandler(this.btnChangeStatus_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.DarkRed;
            this.btnCancel.Location = new System.Drawing.Point(641, 453);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(69, 23);
            this.btnCancel.TabIndex = 66;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblTotalRecord
            // 
            this.lblTotalRecord.BackColor = System.Drawing.Color.DimGray;
            this.lblTotalRecord.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRecord.ForeColor = System.Drawing.Color.Chartreuse;
            this.lblTotalRecord.Location = new System.Drawing.Point(557, 7);
            this.lblTotalRecord.Name = "lblTotalRecord";
            this.lblTotalRecord.Size = new System.Drawing.Size(153, 18);
            this.lblTotalRecord.TabIndex = 67;
            this.lblTotalRecord.Text = "Total Record : 0";
            this.lblTotalRecord.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dgvExtension
            // 
            this.dgvExtension.DataGridView = this.dtgCheckPrintingHistory;
            defaultGridFilterFactory1.CreateDistinctGridFilters = false;
            defaultGridFilterFactory1.DefaultGridFilterType = typeof(GridViewExtensions.GridFilters.TextGridFilter);
            defaultGridFilterFactory1.DefaultShowDateInBetweenOperator = false;
            defaultGridFilterFactory1.DefaultShowNumericInBetweenOperator = false;
            defaultGridFilterFactory1.HandleEnumerationTypes = true;
            defaultGridFilterFactory1.MaximumDistinctValues = 20;
            this.dgvExtension.FilterFactory = defaultGridFilterFactory1;
            // 
            // dtSearchDate
            // 
            this.dtSearchDate.CalendarFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtSearchDate.CustomFormat = "dd-MMM-yyyy";
            this.dtSearchDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtSearchDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtSearchDate.Location = new System.Drawing.Point(164, 6);
            this.dtSearchDate.Name = "dtSearchDate";
            this.dtSearchDate.Size = new System.Drawing.Size(138, 21);
            this.dtSearchDate.TabIndex = 69;
            this.dtSearchDate.ValueChanged += new System.EventHandler(this.dtSearchDate_ValueChanged);
            // 
            // ChangeCheckPrintStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 487);
            this.Controls.Add(this.lblTotalRecord);
            this.Controls.Add(this.dtSearchDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnChangeStatus);
            this.Controls.Add(this.dtgCheckPrintingHistory);
            this.Controls.Add(this.btnCancel);
            this.MaximizeBox = false;
            this.Name = "ChangeCheckPrintStatus";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change Cheque Printing Status";
            this.Load += new System.EventHandler(this.ChangeCheckPrintStatus_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgCheckPrintingHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExtension)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dtgCheckPrintingHistory;
        private System.Windows.Forms.Button btnChangeStatus;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblTotalRecord;
        private GridViewExtensions.DataGridFilterExtender dgvExtension;
        private System.Windows.Forms.DateTimePicker dtSearchDate;
    }
}