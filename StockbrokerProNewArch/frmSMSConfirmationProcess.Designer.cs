namespace StockbrokerProNewArch
{
    partial class frmSMSConfirmationProcess
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
            GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory defaultGridFilterFactory1 = new GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory();
            this.label13 = new System.Windows.Forms.Label();
            this.btnSmsConfirmation = new System.Windows.Forms.Button();
            this.dtgTradeFile = new System.Windows.Forms.DataGridView();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCheck = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.lbCodeBOError = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtgGroupMismatch = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbISINError = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbCompanyCatError = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lbCustCodeError = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.labelBOErr = new System.Windows.Forms.Label();
            this.lbCompShortCodeError = new System.Windows.Forms.ListBox();
            this.lbBOError = new System.Windows.Forms.ListBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.dataGridFilterExtender1 = new GridViewExtensions.DataGridFilterExtender(this.components);
            this.btn_SendEmail = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgTradeFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgGroupMismatch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFilterExtender1)).BeginInit();
            this.SuspendLayout();
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.DimGray;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Chartreuse;
            this.label13.Location = new System.Drawing.Point(0, 0);
            this.label13.Name = "label13";
            this.label13.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.label13.Size = new System.Drawing.Size(862, 23);
            this.label13.TabIndex = 136;
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSmsConfirmation
            // 
            this.btnSmsConfirmation.Enabled = false;
            this.btnSmsConfirmation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSmsConfirmation.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnSmsConfirmation.Location = new System.Drawing.Point(5, 300);
            this.btnSmsConfirmation.Name = "btnSmsConfirmation";
            this.btnSmsConfirmation.Size = new System.Drawing.Size(76, 28);
            this.btnSmsConfirmation.TabIndex = 135;
            this.btnSmsConfirmation.Text = "Send SMS";
            this.btnSmsConfirmation.UseVisualStyleBackColor = true;
            this.btnSmsConfirmation.Click += new System.EventHandler(this.btnSmsConfirmation_Click);
            // 
            // dtgTradeFile
            // 
            this.dtgTradeFile.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightCyan;
            this.dtgTradeFile.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgTradeFile.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgTradeFile.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgTradeFile.EnableHeadersVisualStyles = false;
            this.dtgTradeFile.GridColor = System.Drawing.Color.Silver;
            this.dtgTradeFile.Location = new System.Drawing.Point(0, 43);
            this.dtgTradeFile.MultiSelect = false;
            this.dtgTradeFile.Name = "dtgTradeFile";
            this.dtgTradeFile.RowHeadersVisible = false;
            this.dtgTradeFile.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgTradeFile.Size = new System.Drawing.Size(862, 251);
            this.dtgTradeFile.TabIndex = 134;
            this.dtgTradeFile.TabStop = false;
            this.dtgTradeFile.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgTradeFile_CellClick);
            this.dtgTradeFile.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgTradeFile_CellContentClick);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnCancel.Location = new System.Drawing.Point(770, 300);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(81, 28);
            this.btnCancel.TabIndex = 133;
            this.btnCancel.Text = "Close";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheck.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnCheck.Location = new System.Drawing.Point(684, 300);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(80, 28);
            this.btnCheck.TabIndex = 132;
            this.btnCheck.Text = "Check";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Gray;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(199, 359);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 20);
            this.label7.TabIndex = 153;
            this.label7.Text = " Code-BO Miss";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbCodeBOError
            // 
            this.lbCodeBOError.FormattingEnabled = true;
            this.lbCodeBOError.Location = new System.Drawing.Point(199, 379);
            this.lbCodeBOError.Name = "lbCodeBOError";
            this.lbCodeBOError.Size = new System.Drawing.Size(120, 121);
            this.lbCodeBOError.TabIndex = 152;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.DimGray;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Chartreuse;
            this.label5.Location = new System.Drawing.Point(9, 336);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.label5.Size = new System.Drawing.Size(841, 23);
            this.label5.TabIndex = 151;
            this.label5.Text = "Missing Information";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtgGroupMismatch
            // 
            this.dtgGroupMismatch.AllowUserToAddRows = false;
            this.dtgGroupMismatch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgGroupMismatch.Location = new System.Drawing.Point(641, 378);
            this.dtgGroupMismatch.Name = "dtgGroupMismatch";
            this.dtgGroupMismatch.ReadOnly = true;
            this.dtgGroupMismatch.RowHeadersVisible = false;
            this.dtgGroupMismatch.Size = new System.Drawing.Size(209, 121);
            this.dtgGroupMismatch.TabIndex = 150;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Gray;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(641, 359);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(209, 20);
            this.label6.TabIndex = 149;
            this.label6.Text = "Group Mismatch ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Gray;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(451, 359);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 20);
            this.label3.TabIndex = 148;
            this.label3.Text = "ISIN";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbISINError
            // 
            this.lbISINError.FormattingEnabled = true;
            this.lbISINError.Location = new System.Drawing.Point(451, 377);
            this.lbISINError.Name = "lbISINError";
            this.lbISINError.Size = new System.Drawing.Size(91, 121);
            this.lbISINError.TabIndex = 147;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Gray;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(547, 359);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 20);
            this.label2.TabIndex = 146;
            this.label2.Text = "Group";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbCompanyCatError
            // 
            this.lbCompanyCatError.FormattingEnabled = true;
            this.lbCompanyCatError.Location = new System.Drawing.Point(547, 377);
            this.lbCompanyCatError.Name = "lbCompanyCatError";
            this.lbCompanyCatError.Size = new System.Drawing.Size(88, 121);
            this.lbCompanyCatError.TabIndex = 145;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Gray;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(9, 359);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 20);
            this.label4.TabIndex = 144;
            this.label4.Text = "Account Code";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbCustCodeError
            // 
            this.lbCustCodeError.FormattingEnabled = true;
            this.lbCustCodeError.Location = new System.Drawing.Point(9, 378);
            this.lbCustCodeError.Name = "lbCustCodeError";
            this.lbCustCodeError.Size = new System.Drawing.Size(87, 121);
            this.lbCustCodeError.TabIndex = 143;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Gray;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(325, 359);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(120, 20);
            this.label8.TabIndex = 142;
            this.label8.Text = "Company";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelBOErr
            // 
            this.labelBOErr.BackColor = System.Drawing.Color.Gray;
            this.labelBOErr.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelBOErr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBOErr.ForeColor = System.Drawing.Color.White;
            this.labelBOErr.Location = new System.Drawing.Point(103, 359);
            this.labelBOErr.Name = "labelBOErr";
            this.labelBOErr.Size = new System.Drawing.Size(91, 20);
            this.labelBOErr.TabIndex = 141;
            this.labelBOErr.Text = "BO ID";
            this.labelBOErr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbCompShortCodeError
            // 
            this.lbCompShortCodeError.FormattingEnabled = true;
            this.lbCompShortCodeError.Location = new System.Drawing.Point(325, 378);
            this.lbCompShortCodeError.Name = "lbCompShortCodeError";
            this.lbCompShortCodeError.Size = new System.Drawing.Size(120, 121);
            this.lbCompShortCodeError.TabIndex = 140;
            // 
            // lbBOError
            // 
            this.lbBOError.FormattingEnabled = true;
            this.lbBOError.Location = new System.Drawing.Point(102, 378);
            this.lbBOError.Name = "lbBOError";
            this.lbBOError.Size = new System.Drawing.Size(91, 121);
            this.lbBOError.TabIndex = 139;
            // 
            // btnEdit
            // 
            this.btnEdit.Enabled = false;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnEdit.Location = new System.Drawing.Point(171, 300);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(80, 28);
            this.btnEdit.TabIndex = 132;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // dataGridFilterExtender1
            // 
            this.dataGridFilterExtender1.DataGridView = this.dtgTradeFile;
            defaultGridFilterFactory1.CreateDistinctGridFilters = false;
            defaultGridFilterFactory1.DefaultGridFilterType = typeof(GridViewExtensions.GridFilters.TextGridFilter);
            defaultGridFilterFactory1.DefaultShowDateInBetweenOperator = false;
            defaultGridFilterFactory1.DefaultShowNumericInBetweenOperator = false;
            defaultGridFilterFactory1.HandleEnumerationTypes = true;
            defaultGridFilterFactory1.MaximumDistinctValues = 20;
            this.dataGridFilterExtender1.FilterFactory = defaultGridFilterFactory1;
            // 
            // btn_SendEmail
            // 
            this.btn_SendEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_SendEmail.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btn_SendEmail.Location = new System.Drawing.Point(87, 300);
            this.btn_SendEmail.Name = "btn_SendEmail";
            this.btn_SendEmail.Size = new System.Drawing.Size(78, 28);
            this.btn_SendEmail.TabIndex = 155;
            this.btn_SendEmail.Text = "Send Email";
            this.btn_SendEmail.UseVisualStyleBackColor = true;
            this.btn_SendEmail.Click += new System.EventHandler(this.btn_SendEmail_Click);
            // 
            // frmSMSConfirmationProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 332);
            this.Controls.Add(this.btn_SendEmail);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lbCodeBOError);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtgGroupMismatch);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbISINError);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbCompanyCatError);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbCustCodeError);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.labelBOErr);
            this.Controls.Add(this.lbCompShortCodeError);
            this.Controls.Add(this.lbBOError);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btnSmsConfirmation);
            this.Controls.Add(this.dtgTradeFile);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnCheck);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frmSMSConfirmationProcess";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SMS Confirmation Process";
            this.Load += new System.EventHandler(this.frmSMSConfirmationProcess_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgTradeFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgGroupMismatch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFilterExtender1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnSmsConfirmation;
        private System.Windows.Forms.DataGridView dtgTradeFile;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox lbCodeBOError;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dtgGroupMismatch;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lbISINError;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lbCompanyCatError;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lbCustCodeError;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labelBOErr;
        private System.Windows.Forms.ListBox lbCompShortCodeError;
        private System.Windows.Forms.ListBox lbBOError;
        private System.Windows.Forms.Button btnEdit;
        private GridViewExtensions.DataGridFilterExtender dataGridFilterExtender1;
        private System.Windows.Forms.Button btn_SendEmail;
    }
}