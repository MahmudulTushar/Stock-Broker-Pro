namespace StockbrokerProNewArch
{
    partial class SattleProcess
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label13 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnGeneratePayInFile = new System.Windows.Forms.Button();
            this.dtgTradeFile = new System.Windows.Forms.DataGridView();
            this.lbCustCodeError = new System.Windows.Forms.ListBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCheck = new System.Windows.Forms.Button();
            this.lbCompShortCodeError = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgTradeFile)).BeginInit();
            this.SuspendLayout();
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.DimGray;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Chartreuse;
            this.label13.Location = new System.Drawing.Point(6, 6);
            this.label13.Name = "label13";
            this.label13.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.label13.Size = new System.Drawing.Size(791, 23);
            this.label13.TabIndex = 131;
            this.label13.Text = "Trade File\'s Data";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Gray;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(148, 291);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 20);
            this.label4.TabIndex = 125;
            this.label4.Text = "Company";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Gray;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(24, 291);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 20);
            this.label5.TabIndex = 123;
            this.label5.Text = "Account Code";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnGeneratePayInFile
            // 
            this.btnGeneratePayInFile.Enabled = false;
            this.btnGeneratePayInFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGeneratePayInFile.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnGeneratePayInFile.Location = new System.Drawing.Point(6, 228);
            this.btnGeneratePayInFile.Name = "btnGeneratePayInFile";
            this.btnGeneratePayInFile.Size = new System.Drawing.Size(135, 28);
            this.btnGeneratePayInFile.TabIndex = 122;
            this.btnGeneratePayInFile.Text = "Generate Pay In File";
            this.btnGeneratePayInFile.UseVisualStyleBackColor = true;
            this.btnGeneratePayInFile.Click += new System.EventHandler(this.btnGeneratePayInFile_Click);
            // 
            // dtgTradeFile
            // 
            this.dtgTradeFile.AllowUserToAddRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightCyan;
            this.dtgTradeFile.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dtgTradeFile.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgTradeFile.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dtgTradeFile.EnableHeadersVisualStyles = false;
            this.dtgTradeFile.GridColor = System.Drawing.Color.Silver;
            this.dtgTradeFile.Location = new System.Drawing.Point(6, 29);
            this.dtgTradeFile.MultiSelect = false;
            this.dtgTradeFile.Name = "dtgTradeFile";
            this.dtgTradeFile.ReadOnly = true;
            this.dtgTradeFile.RowHeadersVisible = false;
            this.dtgTradeFile.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgTradeFile.Size = new System.Drawing.Size(791, 193);
            this.dtgTradeFile.TabIndex = 120;
            this.dtgTradeFile.TabStop = false;
            // 
            // lbCustCodeError
            // 
            this.lbCustCodeError.FormattingEnabled = true;
            this.lbCustCodeError.Location = new System.Drawing.Point(24, 311);
            this.lbCustCodeError.Name = "lbCustCodeError";
            this.lbCustCodeError.Size = new System.Drawing.Size(115, 121);
            this.lbCustCodeError.TabIndex = 117;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnCancel.Location = new System.Drawing.Point(716, 228);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(81, 28);
            this.btnCancel.TabIndex = 116;
            this.btnCancel.Text = "Close";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheck.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnCheck.Location = new System.Drawing.Point(630, 228);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(80, 28);
            this.btnCheck.TabIndex = 115;
            this.btnCheck.Text = "Check";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click_1);
            // 
            // lbCompShortCodeError
            // 
            this.lbCompShortCodeError.FormattingEnabled = true;
            this.lbCompShortCodeError.Location = new System.Drawing.Point(148, 311);
            this.lbCompShortCodeError.Name = "lbCompShortCodeError";
            this.lbCompShortCodeError.Size = new System.Drawing.Size(120, 121);
            this.lbCompShortCodeError.TabIndex = 113;
            // 
            // SattleProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 260);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnGeneratePayInFile);
            this.Controls.Add(this.dtgTradeFile);
            this.Controls.Add(this.lbCustCodeError);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.lbCompShortCodeError);
            this.MaximizeBox = false;
            this.Name = "SattleProcess";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settlement Transfer-Process";
            this.Load += new System.EventHandler(this.PayInProcessOld_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgTradeFile)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnGeneratePayInFile;
        private System.Windows.Forms.DataGridView dtgTradeFile;
        private System.Windows.Forms.ListBox lbCustCodeError;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.ListBox lbCompShortCodeError;
    }
}