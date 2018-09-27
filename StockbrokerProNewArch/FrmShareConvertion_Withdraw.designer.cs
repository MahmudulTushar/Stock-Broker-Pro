namespace StockbrokerProNewArch
{
    partial class FrmShareConvertion_Withdraw
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmShareConvertion_Withdraw));
            GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory defaultGridFilterFactory1 = new GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory();
            GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory defaultGridFilterFactory2 = new GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory();
            this.pnlCompanyInformation = new System.Windows.Forms.Panel();
            this.dgvFileInformation = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtShareWithdrawRate = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.cbIfEqual = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtRationFirst = new System.Windows.Forms.TextBox();
            this.txtRatioSecond = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnProcess = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmbDepositCompany = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbWithCompany = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlErrorInformation = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.lblErrorCount = new System.Windows.Forms.Label();
            this.dgvErrorInformation = new System.Windows.Forms.DataGridView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.dataGridFilterExtender1 = new GridViewExtensions.DataGridFilterExtender(this.components);
            this.dataGridFilterExtender2 = new GridViewExtensions.DataGridFilterExtender(this.components);
            this.ep1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlCompanyInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFileInformation)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlErrorInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvErrorInformation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFilterExtender1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFilterExtender2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ep1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlCompanyInformation
            // 
            this.pnlCompanyInformation.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlCompanyInformation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlCompanyInformation.Controls.Add(this.dgvFileInformation);
            this.pnlCompanyInformation.Controls.Add(this.label4);
            this.pnlCompanyInformation.Controls.Add(this.txtFilePath);
            this.pnlCompanyInformation.Controls.Add(this.btnSelectFile);
            this.pnlCompanyInformation.Controls.Add(this.label6);
            this.pnlCompanyInformation.Controls.Add(this.lblCount);
            this.pnlCompanyInformation.Location = new System.Drawing.Point(12, 12);
            this.pnlCompanyInformation.Name = "pnlCompanyInformation";
            this.pnlCompanyInformation.Size = new System.Drawing.Size(842, 294);
            this.pnlCompanyInformation.TabIndex = 11;
            // 
            // dgvFileInformation
            // 
            this.dgvFileInformation.AllowUserToAddRows = false;
            this.dgvFileInformation.AllowUserToDeleteRows = false;
            this.dgvFileInformation.BackgroundColor = System.Drawing.Color.Silver;
            this.dgvFileInformation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFileInformation.Location = new System.Drawing.Point(13, 109);
            this.dgvFileInformation.Name = "dgvFileInformation";
            this.dgvFileInformation.ReadOnly = true;
            this.dgvFileInformation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFileInformation.Size = new System.Drawing.Size(810, 167);
            this.dgvFileInformation.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Silver;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(813, 23);
            this.label4.TabIndex = 8;
            this.label4.Text = "Withdraw File Information";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtFilePath
            // 
            this.txtFilePath.Enabled = false;
            this.txtFilePath.Location = new System.Drawing.Point(121, 41);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(629, 20);
            this.txtFilePath.TabIndex = 0;
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Image = ((System.Drawing.Image)(resources.GetObject("btnSelectFile.Image")));
            this.btnSelectFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelectFile.Location = new System.Drawing.Point(13, 39);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(102, 26);
            this.btnSelectFile.TabIndex = 1;
            this.btnSelectFile.Text = "    Select File";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Maroon;
            this.label6.Location = new System.Drawing.Point(756, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Count :";
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.ForeColor = System.Drawing.Color.Maroon;
            this.lblCount.Location = new System.Drawing.Point(798, 44);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(13, 13);
            this.lblCount.TabIndex = 6;
            this.lblCount.Text = "0";
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(12, 312);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(842, 146);
            this.panel1.TabIndex = 12;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Silver;
            this.groupBox2.Controls.Add(this.panel4);
            this.groupBox2.Controls.Add(this.panel3);
            this.groupBox2.Location = new System.Drawing.Point(13, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(402, 118);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Standerization";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.txtShareWithdrawRate);
            this.panel4.Controls.Add(this.label13);
            this.panel4.Location = new System.Drawing.Point(13, 21);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(183, 81);
            this.panel4.TabIndex = 1;
            // 
            // txtShareWithdrawRate
            // 
            this.txtShareWithdrawRate.Location = new System.Drawing.Point(14, 39);
            this.txtShareWithdrawRate.Name = "txtShareWithdrawRate";
            this.txtShareWithdrawRate.Size = new System.Drawing.Size(153, 20);
            this.txtShareWithdrawRate.TabIndex = 15;
            this.txtShareWithdrawRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtShareWithdrawRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtShareWithdrawRate_KeyPress);
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.DarkGray;
            this.label13.Location = new System.Drawing.Point(14, 16);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(153, 23);
            this.label13.TabIndex = 0;
            this.label13.Text = "Each Share Price for Deposit";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.cbIfEqual);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.txtRationFirst);
            this.panel3.Controls.Add(this.txtRatioSecond);
            this.panel3.Location = new System.Drawing.Point(202, 20);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(183, 82);
            this.panel3.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.DarkGray;
            this.label2.Location = new System.Drawing.Point(3, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 23);
            this.label2.TabIndex = 18;
            this.label2.Text = "  Ratio :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbIfEqual
            // 
            this.cbIfEqual.AutoSize = true;
            this.cbIfEqual.Location = new System.Drawing.Point(59, 51);
            this.cbIfEqual.Name = "cbIfEqual";
            this.cbIfEqual.Size = new System.Drawing.Size(96, 17);
            this.cbIfEqual.TabIndex = 15;
            this.cbIfEqual.Text = "Check If Equal";
            this.cbIfEqual.UseVisualStyleBackColor = true;
            this.cbIfEqual.CheckedChanged += new System.EventHandler(this.cbIfEqual_CheckedChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(108, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(16, 24);
            this.label12.TabIndex = 14;
            this.label12.Text = ":";
            // 
            // txtRationFirst
            // 
            this.txtRationFirst.Enabled = false;
            this.txtRationFirst.Location = new System.Drawing.Point(59, 19);
            this.txtRationFirst.Name = "txtRationFirst";
            this.txtRationFirst.Size = new System.Drawing.Size(48, 20);
            this.txtRationFirst.TabIndex = 12;
            this.txtRationFirst.Text = "1";
            this.txtRationFirst.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtRatioSecond
            // 
            this.txtRatioSecond.Location = new System.Drawing.Point(127, 19);
            this.txtRatioSecond.Name = "txtRatioSecond";
            this.txtRatioSecond.Size = new System.Drawing.Size(48, 20);
            this.txtRatioSecond.TabIndex = 13;
            this.txtRatioSecond.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            //this.txtRatioSecond.TextChanged += new System.EventHandler(this.txtRatioSecond_TextChanged);
            this.txtRatioSecond.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRatioSecond_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Silver;
            this.groupBox1.Controls.Add(this.btnProcess);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Location = new System.Drawing.Point(421, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(402, 118);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            // 
            // btnProcess
            // 
            this.btnProcess.Image = ((System.Drawing.Image)(resources.GetObject("btnProcess.Image")));
            this.btnProcess.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProcess.Location = new System.Drawing.Point(274, 82);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(122, 26);
            this.btnProcess.TabIndex = 20;
            this.btnProcess.Text = "  Start Withdraw";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Silver;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.cmbDepositCompany);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.cmbWithCompany);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(6, 8);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(390, 68);
            this.panel2.TabIndex = 20;
            // 
            // cmbDepositCompany
            // 
            this.cmbDepositCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepositCompany.FormattingEnabled = true;
            this.cmbDepositCompany.Location = new System.Drawing.Point(121, 37);
            this.cmbDepositCompany.Name = "cmbDepositCompany";
            this.cmbDepositCompany.Size = new System.Drawing.Size(246, 21);
            this.cmbDepositCompany.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.DarkGray;
            this.label3.Location = new System.Drawing.Point(13, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 23);
            this.label3.TabIndex = 25;
            this.label3.Text = "Deposit Company :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbWithCompany
            // 
            this.cmbWithCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWithCompany.FormattingEnabled = true;
            this.cmbWithCompany.Location = new System.Drawing.Point(121, 10);
            this.cmbWithCompany.Name = "cmbWithCompany";
            this.cmbWithCompany.Size = new System.Drawing.Size(246, 21);
            this.cmbWithCompany.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DarkGray;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 23);
            this.label1.TabIndex = 21;
            this.label1.Text = "Withdraw Company :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlErrorInformation
            // 
            this.pnlErrorInformation.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlErrorInformation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlErrorInformation.Controls.Add(this.label5);
            this.pnlErrorInformation.Controls.Add(this.lblErrorCount);
            this.pnlErrorInformation.Controls.Add(this.dgvErrorInformation);
            this.pnlErrorInformation.Location = new System.Drawing.Point(12, 464);
            this.pnlErrorInformation.Name = "pnlErrorInformation";
            this.pnlErrorInformation.Size = new System.Drawing.Size(842, 184);
            this.pnlErrorInformation.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Maroon;
            this.label5.Location = new System.Drawing.Point(740, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Count :";
            // 
            // lblErrorCount
            // 
            this.lblErrorCount.AutoSize = true;
            this.lblErrorCount.ForeColor = System.Drawing.Color.Maroon;
            this.lblErrorCount.Location = new System.Drawing.Point(782, 162);
            this.lblErrorCount.Name = "lblErrorCount";
            this.lblErrorCount.Size = new System.Drawing.Size(13, 13);
            this.lblErrorCount.TabIndex = 8;
            this.lblErrorCount.Text = "0";
            this.lblErrorCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvErrorInformation
            // 
            this.dgvErrorInformation.AllowUserToAddRows = false;
            this.dgvErrorInformation.AllowUserToDeleteRows = false;
            this.dgvErrorInformation.BackgroundColor = System.Drawing.Color.Silver;
            this.dgvErrorInformation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvErrorInformation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dgvErrorInformation.Location = new System.Drawing.Point(13, 28);
            this.dgvErrorInformation.Name = "dgvErrorInformation";
            this.dgvErrorInformation.ReadOnly = true;
            this.dgvErrorInformation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvErrorInformation.Size = new System.Drawing.Size(810, 128);
            this.dgvErrorInformation.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // dataGridFilterExtender1
            // 
            this.dataGridFilterExtender1.DataGridView = this.dgvFileInformation;
            defaultGridFilterFactory1.CreateDistinctGridFilters = false;
            defaultGridFilterFactory1.DefaultGridFilterType = typeof(GridViewExtensions.GridFilters.TextGridFilter);
            defaultGridFilterFactory1.DefaultShowDateInBetweenOperator = false;
            defaultGridFilterFactory1.DefaultShowNumericInBetweenOperator = false;
            defaultGridFilterFactory1.HandleEnumerationTypes = true;
            defaultGridFilterFactory1.MaximumDistinctValues = 20;
            this.dataGridFilterExtender1.FilterFactory = defaultGridFilterFactory1;
            // 
            // dataGridFilterExtender2
            // 
            this.dataGridFilterExtender2.DataGridView = this.dgvErrorInformation;
            defaultGridFilterFactory2.CreateDistinctGridFilters = false;
            defaultGridFilterFactory2.DefaultGridFilterType = typeof(GridViewExtensions.GridFilters.TextGridFilter);
            defaultGridFilterFactory2.DefaultShowDateInBetweenOperator = false;
            defaultGridFilterFactory2.DefaultShowNumericInBetweenOperator = false;
            defaultGridFilterFactory2.HandleEnumerationTypes = true;
            defaultGridFilterFactory2.MaximumDistinctValues = 20;
            this.dataGridFilterExtender2.FilterFactory = defaultGridFilterFactory2;
            // 
            // ep1
            // 
            this.ep1.ContainerControl = this;
            this.ep1.Icon = ((System.Drawing.Icon)(resources.GetObject("ep1.Icon")));
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Sl";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 50;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Cust_Code";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 70;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "BO_ID";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 70;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Message";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 550;
            // 
            // FrmShareConvertion_Withdraw
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 660);
            this.Controls.Add(this.pnlErrorInformation);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlCompanyInformation);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmShareConvertion_Withdraw";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Share Convertion_Withdraw";
            this.Load += new System.EventHandler(this.FrmShareConvertion_Withdraw_Load);
            this.pnlCompanyInformation.ResumeLayout(false);
            this.pnlCompanyInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFileInformation)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.pnlErrorInformation.ResumeLayout(false);
            this.pnlErrorInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvErrorInformation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFilterExtender1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFilterExtender2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ep1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlCompanyInformation;
        private System.Windows.Forms.DataGridView dgvFileInformation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtShareWithdrawRate;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbIfEqual;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtRationFirst;
        private System.Windows.Forms.TextBox txtRatioSecond;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cmbWithCompany;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlErrorInformation;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblErrorCount;
        private System.Windows.Forms.DataGridView dgvErrorInformation;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ComboBox cmbDepositCompany;
        private System.Windows.Forms.Label label3;
        private GridViewExtensions.DataGridFilterExtender dataGridFilterExtender1;
        private GridViewExtensions.DataGridFilterExtender dataGridFilterExtender2;
        private System.Windows.Forms.ErrorProvider ep1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}