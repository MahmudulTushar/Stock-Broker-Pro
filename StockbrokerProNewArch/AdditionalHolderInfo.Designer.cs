namespace StockbrokerProNewArch
{
    partial class AdditionalHolderInfo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ofdFileOpen = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFileLocationBrowser = new System.Windows.Forms.Button();
            this.err = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnStartImport = new System.Windows.Forms.Button();
            this.txtFileLocation = new System.Windows.Forms.TextBox();
            this.dgvErrors = new System.Windows.Forms.DataGridView();
            this.sn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ErrorDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbProText = new System.Windows.Forms.Label();
            this.progress = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.err)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvErrors)).BeginInit();
            this.SuspendLayout();
            // 
            // ofdFileOpen
            // 
            this.ofdFileOpen.Filter = "txt files (*.txt)|*.txt";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "CDBL File Location";
            // 
            // btnFileLocationBrowser
            // 
            this.btnFileLocationBrowser.Location = new System.Drawing.Point(410, 24);
            this.btnFileLocationBrowser.Name = "btnFileLocationBrowser";
            this.btnFileLocationBrowser.Size = new System.Drawing.Size(34, 23);
            this.btnFileLocationBrowser.TabIndex = 11;
            this.btnFileLocationBrowser.Text = "...";
            this.btnFileLocationBrowser.UseVisualStyleBackColor = true;
            this.btnFileLocationBrowser.Click += new System.EventHandler(this.btnFileLocationBrowser_Click);
            // 
            // err
            // 
            this.err.ContainerControl = this;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnStartImport);
            this.groupBox1.Controls.Add(this.btnFileLocationBrowser);
            this.groupBox1.Controls.Add(this.txtFileLocation);
            this.groupBox1.Location = new System.Drawing.Point(12, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(557, 63);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select CDBL File";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(123, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = ":";
            // 
            // btnStartImport
            // 
            this.btnStartImport.Location = new System.Drawing.Point(450, 24);
            this.btnStartImport.Name = "btnStartImport";
            this.btnStartImport.Size = new System.Drawing.Size(88, 23);
            this.btnStartImport.TabIndex = 10;
            this.btnStartImport.Text = "Start Import";
            this.btnStartImport.UseVisualStyleBackColor = true;
            this.btnStartImport.Click += new System.EventHandler(this.btnStartImport_Click);
            // 
            // txtFileLocation
            // 
            this.txtFileLocation.Location = new System.Drawing.Point(139, 26);
            this.txtFileLocation.Name = "txtFileLocation";
            this.txtFileLocation.Size = new System.Drawing.Size(245, 20);
            this.txtFileLocation.TabIndex = 9;
            // 
            // dgvErrors
            // 
            this.dgvErrors.AllowUserToAddRows = false;
            this.dgvErrors.AllowUserToDeleteRows = false;
            this.dgvErrors.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvErrors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvErrors.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sn,
            this.CustomerCode,
            this.ErrorDescription});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvErrors.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvErrors.Location = new System.Drawing.Point(12, 125);
            this.dgvErrors.MultiSelect = false;
            this.dgvErrors.Name = "dgvErrors";
            this.dgvErrors.RowHeadersVisible = false;
            this.dgvErrors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvErrors.Size = new System.Drawing.Size(557, 105);
            this.dgvErrors.TabIndex = 14;
            this.dgvErrors.TabStop = false;
            // 
            // sn
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            this.sn.DefaultCellStyle = dataGridViewCellStyle1;
            this.sn.Frozen = true;
            this.sn.HeaderText = "SN";
            this.sn.Name = "sn";
            this.sn.ReadOnly = true;
            this.sn.Width = 47;
            // 
            // CustomerCode
            // 
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DarkGreen;
            this.CustomerCode.DefaultCellStyle = dataGridViewCellStyle2;
            this.CustomerCode.HeaderText = "Customer Code";
            this.CustomerCode.Name = "CustomerCode";
            this.CustomerCode.ReadOnly = true;
            // 
            // ErrorDescription
            // 
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Red;
            this.ErrorDescription.DefaultCellStyle = dataGridViewCellStyle3;
            this.ErrorDescription.HeaderText = "Error Description";
            this.ErrorDescription.Name = "ErrorDescription";
            this.ErrorDescription.Width = 400;
            // 
            // lbProText
            // 
            this.lbProText.AutoSize = true;
            this.lbProText.ForeColor = System.Drawing.Color.DimGray;
            this.lbProText.Location = new System.Drawing.Point(12, 88);
            this.lbProText.Name = "lbProText";
            this.lbProText.Size = new System.Drawing.Size(65, 13);
            this.lbProText.TabIndex = 15;
            this.lbProText.Text = "No Progress";
            // 
            // progress
            // 
            this.progress.Location = new System.Drawing.Point(12, 108);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(557, 10);
            this.progress.TabIndex = 13;
            // 
            // AdditionalHolderInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 239);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvErrors);
            this.Controls.Add(this.lbProText);
            this.Controls.Add(this.progress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "AdditionalHolderInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Additional Holder File Upload";
            this.Load += new System.EventHandler(this.AdditionalHolderInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.err)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvErrors)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog ofdFileOpen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFileLocationBrowser;
        private System.Windows.Forms.ErrorProvider err;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnStartImport;
        private System.Windows.Forms.TextBox txtFileLocation;
        private System.Windows.Forms.DataGridView dgvErrors;
        private System.Windows.Forms.DataGridViewTextBoxColumn sn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ErrorDescription;
        private System.Windows.Forms.Label lbProText;
        private System.Windows.Forms.ProgressBar progress;
    }
}