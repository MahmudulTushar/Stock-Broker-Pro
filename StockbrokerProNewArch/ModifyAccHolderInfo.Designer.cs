namespace StockbrokerProNewArch
{
    partial class ModifyAccHolderInfo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnFileLocationBrowser = new System.Windows.Forms.Button();
            this.txtFileLocation = new System.Windows.Forms.TextBox();
            this.ofdFileOpen = new System.Windows.Forms.OpenFileDialog();
            this.err = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStartImport = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbProText = new System.Windows.Forms.Label();
            this.dgvErrors = new System.Windows.Forms.DataGridView();
            this.progress = new System.Windows.Forms.ProgressBar();
            this.dgdAdditionalView = new System.Windows.Forms.DataGridView();
            this.btnPOA = new System.Windows.Forms.Button();
            this.btnNominee = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnNominee2 = new System.Windows.Forms.Button();
            this.sn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ErrorDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.err)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvErrors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgdAdditionalView)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFileLocationBrowser
            // 
            this.btnFileLocationBrowser.Location = new System.Drawing.Point(653, 24);
            this.btnFileLocationBrowser.Name = "btnFileLocationBrowser";
            this.btnFileLocationBrowser.Size = new System.Drawing.Size(34, 23);
            this.btnFileLocationBrowser.TabIndex = 11;
            this.btnFileLocationBrowser.Text = "...";
            this.btnFileLocationBrowser.UseVisualStyleBackColor = true;
            this.btnFileLocationBrowser.Click += new System.EventHandler(this.btnFileLocationBrowser_Click);
            // 
            // txtFileLocation
            // 
            this.txtFileLocation.Location = new System.Drawing.Point(139, 26);
            this.txtFileLocation.Name = "txtFileLocation";
            this.txtFileLocation.Size = new System.Drawing.Size(497, 20);
            this.txtFileLocation.TabIndex = 9;
            // 
            // ofdFileOpen
            // 
            this.ofdFileOpen.Filter = "txt files (*.txt)|*.txt";
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
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(799, 63);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "CDBL File Location";
            // 
            // btnStartImport
            // 
            this.btnStartImport.Location = new System.Drawing.Point(697, 24);
            this.btnStartImport.Name = "btnStartImport";
            this.btnStartImport.Size = new System.Drawing.Size(88, 23);
            this.btnStartImport.TabIndex = 10;
            this.btnStartImport.Text = "Start Import";
            this.btnStartImport.UseVisualStyleBackColor = true;
            this.btnStartImport.Click += new System.EventHandler(this.btnStartImport_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lbProText);
            this.groupBox3.Controls.Add(this.dgvErrors);
            this.groupBox3.Controls.Add(this.progress);
            this.groupBox3.Location = new System.Drawing.Point(12, 454);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(799, 175);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            // 
            // lbProText
            // 
            this.lbProText.AutoSize = true;
            this.lbProText.ForeColor = System.Drawing.Color.DimGray;
            this.lbProText.Location = new System.Drawing.Point(11, 11);
            this.lbProText.Name = "lbProText";
            this.lbProText.Size = new System.Drawing.Size(65, 13);
            this.lbProText.TabIndex = 18;
            this.lbProText.Text = "No Progress";
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
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvErrors.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvErrors.Location = new System.Drawing.Point(3, 56);
            this.dgvErrors.MultiSelect = false;
            this.dgvErrors.Name = "dgvErrors";
            this.dgvErrors.RowHeadersVisible = false;
            this.dgvErrors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvErrors.Size = new System.Drawing.Size(790, 105);
            this.dgvErrors.TabIndex = 17;
            this.dgvErrors.TabStop = false;
            // 
            // progress
            // 
            this.progress.Location = new System.Drawing.Point(8, 34);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(778, 10);
            this.progress.TabIndex = 16;
            // 
            // dgdAdditionalView
            // 
            this.dgdAdditionalView.AllowUserToAddRows = false;
            this.dgdAdditionalView.AllowUserToDeleteRows = false;
            this.dgdAdditionalView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgdAdditionalView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgdAdditionalView.Location = new System.Drawing.Point(13, 38);
            this.dgdAdditionalView.Name = "dgdAdditionalView";
            this.dgdAdditionalView.Size = new System.Drawing.Size(772, 280);
            this.dgdAdditionalView.TabIndex = 0;
            // 
            // btnPOA
            // 
            this.btnPOA.Location = new System.Drawing.Point(14, 327);
            this.btnPOA.Name = "btnPOA";
            this.btnPOA.Size = new System.Drawing.Size(91, 23);
            this.btnPOA.TabIndex = 1;
            this.btnPOA.Text = "Update POA";
            this.btnPOA.UseVisualStyleBackColor = true;
            this.btnPOA.Click += new System.EventHandler(this.btnPOA_Click);
            // 
            // btnNominee
            // 
            this.btnNominee.Location = new System.Drawing.Point(115, 327);
            this.btnNominee.Name = "btnNominee";
            this.btnNominee.Size = new System.Drawing.Size(101, 23);
            this.btnNominee.TabIndex = 1;
            this.btnNominee.Text = "Update Nominee";
            this.btnNominee.UseVisualStyleBackColor = true;
            this.btnNominee.Click += new System.EventHandler(this.btnNominee_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnNominee2);
            this.groupBox2.Controls.Add(this.btnNominee);
            this.groupBox2.Controls.Add(this.btnPOA);
            this.groupBox2.Controls.Add(this.dgdAdditionalView);
            this.groupBox2.Location = new System.Drawing.Point(12, 81);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(799, 367);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Update Nominee   and Power of Attorney ";
            // 
            // btnNominee2
            // 
            this.btnNominee2.Location = new System.Drawing.Point(231, 327);
            this.btnNominee2.Name = "btnNominee2";
            this.btnNominee2.Size = new System.Drawing.Size(101, 23);
            this.btnNominee2.TabIndex = 2;
            this.btnNominee2.Text = "Update Nominee2";
            this.btnNominee2.UseVisualStyleBackColor = true;
            this.btnNominee2.Click += new System.EventHandler(this.btnNominee2_Click);
            // 
            // sn
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            this.sn.DefaultCellStyle = dataGridViewCellStyle5;
            this.sn.Frozen = true;
            this.sn.HeaderText = "SN";
            this.sn.Name = "sn";
            this.sn.ReadOnly = true;
            this.sn.Width = 47;
            // 
            // CustomerCode
            // 
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.DarkGreen;
            this.CustomerCode.DefaultCellStyle = dataGridViewCellStyle6;
            this.CustomerCode.HeaderText = "Error Location";
            this.CustomerCode.Name = "CustomerCode";
            this.CustomerCode.ReadOnly = true;
            // 
            // ErrorDescription
            // 
            this.ErrorDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Red;
            this.ErrorDescription.DefaultCellStyle = dataGridViewCellStyle7;
            this.ErrorDescription.HeaderText = "Error Description";
            this.ErrorDescription.Name = "ErrorDescription";
            // 
            // ModifyAccHolderInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 640);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "ModifyAccHolderInfo";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modified Account Holders Upload";
            this.Load += new System.EventHandler(this.ModifyAccHolderInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.err)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvErrors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgdAdditionalView)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFileLocationBrowser;
        private System.Windows.Forms.TextBox txtFileLocation;
        private System.Windows.Forms.OpenFileDialog ofdFileOpen;
        private System.Windows.Forms.ErrorProvider err;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStartImport;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lbProText;
        private System.Windows.Forms.DataGridView dgvErrors;
        private System.Windows.Forms.ProgressBar progress;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnNominee;
        private System.Windows.Forms.Button btnPOA;
        private System.Windows.Forms.DataGridView dgdAdditionalView;
        private System.Windows.Forms.Button btnNominee2;
        private System.Windows.Forms.DataGridViewTextBoxColumn sn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ErrorDescription;
    }
}