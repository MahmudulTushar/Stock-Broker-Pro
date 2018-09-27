namespace StockbrokerProNewArch
{
    partial class FrmShareConvertion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmShareConvertion));
            GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory defaultGridFilterFactory2 = new GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory();
            GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory defaultGridFilterFactory3 = new GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtFilepath = new System.Windows.Forms.TextBox();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lblFormCompany = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvLoadFileData = new System.Windows.Forms.DataGridView();
            this.dataGridFilterExtender1 = new GridViewExtensions.DataGridFilterExtender(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFilePathToCompany = new System.Windows.Forms.TextBox();
            this.btnSelectFileToCompany = new System.Windows.Forms.Button();
            this.dgvToCompany = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.lblToCompany = new System.Windows.Forms.Label();
            this.dataGridFilterExtender2 = new GridViewExtensions.DataGridFilterExtender(this.components);
            this.btnProcess = new System.Windows.Forms.Button();
            this.cmbToCompany = new System.Windows.Forms.ComboBox();
            this.cmbFromCompany = new System.Windows.Forms.ComboBox();
            this.dgvErro = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clCC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clBo_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbCompanySelection = new System.Windows.Forms.GroupBox();
            this.pnlCompanySelection = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRationFirst = new System.Windows.Forms.TextBox();
            this.txtRatioSecond = new System.Windows.Forms.TextBox();
            this.cbIfEqual = new System.Windows.Forms.CheckBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.pnlProcess = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtShareWithdrawRate = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.pnlSelectFile = new System.Windows.Forms.Panel();
            this.pnlError = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoadFileData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFilterExtender1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvToCompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFilterExtender2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvErro)).BeginInit();
            this.gbCompanySelection.SuspendLayout();
            this.pnlCompanySelection.SuspendLayout();
            this.pnlProcess.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.pnlSelectFile.SuspendLayout();
            this.pnlError.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFilepath
            // 
            this.txtFilepath.Enabled = false;
            this.txtFilepath.Location = new System.Drawing.Point(125, 40);
            this.txtFilepath.Name = "txtFilepath";
            this.txtFilepath.Size = new System.Drawing.Size(425, 20);
            this.txtFilepath.TabIndex = 0;
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Image = ((System.Drawing.Image)(resources.GetObject("btnSelectFile.Image")));
            this.btnSelectFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelectFile.Location = new System.Drawing.Point(17, 38);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(102, 26);
            this.btnSelectFile.TabIndex = 1;
            this.btnSelectFile.Text = "    Select File";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // lblFormCompany
            // 
            this.lblFormCompany.AutoSize = true;
            this.lblFormCompany.ForeColor = System.Drawing.Color.Maroon;
            this.lblFormCompany.Location = new System.Drawing.Point(598, 45);
            this.lblFormCompany.Name = "lblFormCompany";
            this.lblFormCompany.Size = new System.Drawing.Size(13, 13);
            this.lblFormCompany.TabIndex = 6;
            this.lblFormCompany.Text = "0";
            this.lblFormCompany.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(556, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Count :";
            // 
            // dgvLoadFileData
            // 
            this.dgvLoadFileData.AllowUserToAddRows = false;
            this.dgvLoadFileData.AllowUserToDeleteRows = false;
            this.dgvLoadFileData.BackgroundColor = System.Drawing.Color.Silver;
            this.dgvLoadFileData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoadFileData.Location = new System.Drawing.Point(17, 99);
            this.dgvLoadFileData.Name = "dgvLoadFileData";
            this.dgvLoadFileData.ReadOnly = true;
            this.dgvLoadFileData.Size = new System.Drawing.Size(606, 136);
            this.dgvLoadFileData.TabIndex = 3;
            // 
            // dataGridFilterExtender1
            // 
            this.dataGridFilterExtender1.DataGridView = this.dgvLoadFileData;
            defaultGridFilterFactory2.CreateDistinctGridFilters = false;
            defaultGridFilterFactory2.DefaultGridFilterType = typeof(GridViewExtensions.GridFilters.TextGridFilter);
            defaultGridFilterFactory2.DefaultShowDateInBetweenOperator = false;
            defaultGridFilterFactory2.DefaultShowNumericInBetweenOperator = false;
            defaultGridFilterFactory2.HandleEnumerationTypes = true;
            defaultGridFilterFactory2.MaximumDistinctValues = 20;
            this.dataGridFilterExtender1.FilterFactory = defaultGridFilterFactory2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtFilepath);
            this.panel1.Controls.Add(this.dgvLoadFileData);
            this.panel1.Controls.Add(this.btnSelectFile);
            this.panel1.Controls.Add(this.lblFormCompany);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(11, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(641, 247);
            this.panel1.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Silver;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(606, 23);
            this.label3.TabIndex = 8;
            this.label3.Text = "From Company";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtFilePathToCompany);
            this.panel2.Controls.Add(this.btnSelectFileToCompany);
            this.panel2.Controls.Add(this.dgvToCompany);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.lblToCompany);
            this.panel2.Location = new System.Drawing.Point(11, 259);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(641, 248);
            this.panel2.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Silver;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(606, 23);
            this.label4.TabIndex = 8;
            this.label4.Text = "To Company";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtFilePathToCompany
            // 
            this.txtFilePathToCompany.Enabled = false;
            this.txtFilePathToCompany.Location = new System.Drawing.Point(125, 40);
            this.txtFilePathToCompany.Name = "txtFilePathToCompany";
            this.txtFilePathToCompany.Size = new System.Drawing.Size(425, 20);
            this.txtFilePathToCompany.TabIndex = 0;
            // 
            // btnSelectFileToCompany
            // 
            this.btnSelectFileToCompany.Image = ((System.Drawing.Image)(resources.GetObject("btnSelectFileToCompany.Image")));
            this.btnSelectFileToCompany.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelectFileToCompany.Location = new System.Drawing.Point(17, 38);
            this.btnSelectFileToCompany.Name = "btnSelectFileToCompany";
            this.btnSelectFileToCompany.Size = new System.Drawing.Size(102, 26);
            this.btnSelectFileToCompany.TabIndex = 1;
            this.btnSelectFileToCompany.Text = "    Select File";
            this.btnSelectFileToCompany.UseVisualStyleBackColor = true;
            this.btnSelectFileToCompany.Click += new System.EventHandler(this.btnSelectFileToCompany_Click);
            // 
            // dgvToCompany
            // 
            this.dgvToCompany.AllowUserToAddRows = false;
            this.dgvToCompany.AllowUserToDeleteRows = false;
            this.dgvToCompany.BackgroundColor = System.Drawing.Color.Silver;
            this.dgvToCompany.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvToCompany.Location = new System.Drawing.Point(17, 99);
            this.dgvToCompany.Name = "dgvToCompany";
            this.dgvToCompany.ReadOnly = true;
            this.dgvToCompany.Size = new System.Drawing.Size(606, 136);
            this.dgvToCompany.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Maroon;
            this.label6.Location = new System.Drawing.Point(556, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Count :";
            // 
            // lblToCompany
            // 
            this.lblToCompany.AutoSize = true;
            this.lblToCompany.ForeColor = System.Drawing.Color.Maroon;
            this.lblToCompany.Location = new System.Drawing.Point(598, 43);
            this.lblToCompany.Name = "lblToCompany";
            this.lblToCompany.Size = new System.Drawing.Size(13, 13);
            this.lblToCompany.TabIndex = 6;
            this.lblToCompany.Text = "0";
            this.lblToCompany.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dataGridFilterExtender2
            // 
            this.dataGridFilterExtender2.DataGridView = this.dgvToCompany;
            defaultGridFilterFactory3.CreateDistinctGridFilters = false;
            defaultGridFilterFactory3.DefaultGridFilterType = typeof(GridViewExtensions.GridFilters.TextGridFilter);
            defaultGridFilterFactory3.DefaultShowDateInBetweenOperator = false;
            defaultGridFilterFactory3.DefaultShowNumericInBetweenOperator = false;
            defaultGridFilterFactory3.HandleEnumerationTypes = true;
            defaultGridFilterFactory3.MaximumDistinctValues = 20;
            this.dataGridFilterExtender2.FilterFactory = defaultGridFilterFactory3;
            // 
            // btnProcess
            // 
            this.btnProcess.Image = ((System.Drawing.Image)(resources.GetObject("btnProcess.Image")));
            this.btnProcess.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProcess.Location = new System.Drawing.Point(147, 463);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(122, 26);
            this.btnProcess.TabIndex = 10;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // cmbToCompany
            // 
            this.cmbToCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbToCompany.FormattingEnabled = true;
            this.cmbToCompany.Location = new System.Drawing.Point(125, 36);
            this.cmbToCompany.Name = "cmbToCompany";
            this.cmbToCompany.Size = new System.Drawing.Size(229, 21);
            this.cmbToCompany.TabIndex = 3;
            // 
            // cmbFromCompany
            // 
            this.cmbFromCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFromCompany.FormattingEnabled = true;
            this.cmbFromCompany.Location = new System.Drawing.Point(125, 9);
            this.cmbFromCompany.Name = "cmbFromCompany";
            this.cmbFromCompany.Size = new System.Drawing.Size(229, 21);
            this.cmbFromCompany.TabIndex = 2;
            // 
            // dgvErro
            // 
            this.dgvErro.AllowUserToAddRows = false;
            this.dgvErro.AllowUserToDeleteRows = false;
            this.dgvErro.AllowUserToOrderColumns = true;
            this.dgvErro.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvErro.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvErro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvErro.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.clCC,
            this.clBo_ID,
            this.cl});
            this.dgvErro.Location = new System.Drawing.Point(11, 9);
            this.dgvErro.Name = "dgvErro";
            this.dgvErro.ReadOnly = true;
            this.dgvErro.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvErro.Size = new System.Drawing.Size(641, 93);
            this.dgvErro.TabIndex = 12;
            // 
            // Column1
            // 
            dataGridViewCellStyle6.NullValue = null;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle6;
            this.Column1.HeaderText = "Sl";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 50;
            // 
            // clCC
            // 
            this.clCC.HeaderText = "Cust_Code";
            this.clCC.Name = "clCC";
            this.clCC.ReadOnly = true;
            this.clCC.Width = 70;
            // 
            // clBo_ID
            // 
            this.clBo_ID.HeaderText = "BO_ID";
            this.clBo_ID.Name = "clBo_ID";
            this.clBo_ID.ReadOnly = true;
            this.clBo_ID.Width = 70;
            // 
            // cl
            // 
            this.cl.HeaderText = "Message";
            this.cl.Name = "cl";
            this.cl.ReadOnly = true;
            this.cl.Width = 400;
            // 
            // gbCompanySelection
            // 
            this.gbCompanySelection.BackColor = System.Drawing.Color.Silver;
            this.gbCompanySelection.Controls.Add(this.pnlCompanySelection);
            this.gbCompanySelection.Location = new System.Drawing.Point(9, 6);
            this.gbCompanySelection.Name = "gbCompanySelection";
            this.gbCompanySelection.Size = new System.Drawing.Size(402, 103);
            this.gbCompanySelection.TabIndex = 15;
            this.gbCompanySelection.TabStop = false;
            this.gbCompanySelection.Text = "Company Selection";
            // 
            // pnlCompanySelection
            // 
            this.pnlCompanySelection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCompanySelection.Controls.Add(this.label8);
            this.pnlCompanySelection.Controls.Add(this.cmbToCompany);
            this.pnlCompanySelection.Controls.Add(this.cmbFromCompany);
            this.pnlCompanySelection.Controls.Add(this.label7);
            this.pnlCompanySelection.Location = new System.Drawing.Point(17, 19);
            this.pnlCompanySelection.Name = "pnlCompanySelection";
            this.pnlCompanySelection.Size = new System.Drawing.Size(372, 70);
            this.pnlCompanySelection.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.DarkGray;
            this.label8.Location = new System.Drawing.Point(16, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 23);
            this.label8.TabIndex = 17;
            this.label8.Text = "  To Company :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.DarkGray;
            this.label7.Location = new System.Drawing.Point(16, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 23);
            this.label7.TabIndex = 16;
            this.label7.Text = "  From Company :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtRationFirst
            // 
            this.txtRationFirst.Enabled = false;
            this.txtRationFirst.Location = new System.Drawing.Point(59, 9);
            this.txtRationFirst.Name = "txtRationFirst";
            this.txtRationFirst.Size = new System.Drawing.Size(48, 20);
            this.txtRationFirst.TabIndex = 12;
            this.txtRationFirst.Text = "1";
            this.txtRationFirst.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtRatioSecond
            // 
            this.txtRatioSecond.Location = new System.Drawing.Point(127, 9);
            this.txtRatioSecond.Name = "txtRatioSecond";
            this.txtRatioSecond.Size = new System.Drawing.Size(48, 20);
            this.txtRatioSecond.TabIndex = 13;
            this.txtRatioSecond.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtRatioSecond.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRatioSecond_KeyPress);
            // 
            // cbIfEqual
            // 
            this.cbIfEqual.AutoSize = true;
            this.cbIfEqual.Location = new System.Drawing.Point(59, 39);
            this.cbIfEqual.Name = "cbIfEqual";
            this.cbIfEqual.Size = new System.Drawing.Size(96, 17);
            this.cbIfEqual.TabIndex = 15;
            this.cbIfEqual.Text = "Check If Equal";
            this.cbIfEqual.UseVisualStyleBackColor = true;
            this.cbIfEqual.CheckedChanged += new System.EventHandler(this.cbIfEqual_CheckedChanged);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(3, 497);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(413, 10);
            this.progressBar1.TabIndex = 13;
            // 
            // pnlProcess
            // 
            this.pnlProcess.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlProcess.Controls.Add(this.groupBox2);
            this.pnlProcess.Controls.Add(this.progressBar1);
            this.pnlProcess.Controls.Add(this.gbCompanySelection);
            this.pnlProcess.Controls.Add(this.btnProcess);
            this.pnlProcess.Location = new System.Drawing.Point(681, 12);
            this.pnlProcess.Name = "pnlProcess";
            this.pnlProcess.Size = new System.Drawing.Size(422, 519);
            this.pnlProcess.TabIndex = 14;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Silver;
            this.groupBox2.Controls.Add(this.panel4);
            this.groupBox2.Controls.Add(this.panel3);
            this.groupBox2.Location = new System.Drawing.Point(9, 119);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(402, 109);
            this.groupBox2.TabIndex = 18;
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
            this.panel4.Size = new System.Drawing.Size(183, 74);
            this.panel4.TabIndex = 1;
            // 
            // txtShareWithdrawRate
            // 
            this.txtShareWithdrawRate.Location = new System.Drawing.Point(9, 35);
            this.txtShareWithdrawRate.Name = "txtShareWithdrawRate";
            this.txtShareWithdrawRate.Size = new System.Drawing.Size(165, 20);
            this.txtShareWithdrawRate.TabIndex = 15;
            this.txtShareWithdrawRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtShareWithdrawRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtShareWithdrawRate_KeyPress);
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.DarkGray;
            this.label13.Location = new System.Drawing.Point(9, 12);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(165, 23);
            this.label13.TabIndex = 0;
            this.label13.Text = "Each Share Price for Withdraw";
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
            this.panel3.Size = new System.Drawing.Size(183, 75);
            this.panel3.TabIndex = 0;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(108, 6);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(16, 24);
            this.label12.TabIndex = 14;
            this.label12.Text = ":";
            // 
            // pnlSelectFile
            // 
            this.pnlSelectFile.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlSelectFile.Controls.Add(this.panel2);
            this.pnlSelectFile.Controls.Add(this.panel1);
            this.pnlSelectFile.Location = new System.Drawing.Point(10, 12);
            this.pnlSelectFile.Name = "pnlSelectFile";
            this.pnlSelectFile.Size = new System.Drawing.Size(665, 519);
            this.pnlSelectFile.TabIndex = 15;
            // 
            // pnlError
            // 
            this.pnlError.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlError.Controls.Add(this.dgvErro);
            this.pnlError.Location = new System.Drawing.Point(10, 538);
            this.pnlError.Name = "pnlError";
            this.pnlError.Size = new System.Drawing.Size(665, 109);
            this.pnlError.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.DarkGray;
            this.label2.Location = new System.Drawing.Point(3, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 23);
            this.label2.TabIndex = 18;
            this.label2.Text = "  Ratio :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmShareConvertion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1114, 656);
            this.Controls.Add(this.pnlError);
            this.Controls.Add(this.pnlSelectFile);
            this.Controls.Add(this.pnlProcess);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmShareConvertion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Share Convertion Form";
            this.Load += new System.EventHandler(this.FrmShareConvertion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoadFileData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFilterExtender1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvToCompany)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFilterExtender2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvErro)).EndInit();
            this.gbCompanySelection.ResumeLayout(false);
            this.pnlCompanySelection.ResumeLayout(false);
            this.pnlProcess.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.pnlSelectFile.ResumeLayout(false);
            this.pnlError.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtFilepath;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridView dgvLoadFileData;
        private GridViewExtensions.DataGridFilterExtender dataGridFilterExtender1;
        private System.Windows.Forms.Label lblFormCompany;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblToCompany;
        private System.Windows.Forms.TextBox txtFilePathToCompany;
        private System.Windows.Forms.DataGridView dgvToCompany;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSelectFileToCompany;
        private GridViewExtensions.DataGridFilterExtender dataGridFilterExtender2;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.ComboBox cmbFromCompany;
        private System.Windows.Forms.ComboBox cmbToCompany;
        private System.Windows.Forms.DataGridView dgvErro;
        private System.Windows.Forms.TextBox txtRationFirst;
        private System.Windows.Forms.TextBox txtRatioSecond;
        private System.Windows.Forms.GroupBox gbCompanySelection;
        private System.Windows.Forms.CheckBox cbIfEqual;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Panel pnlProcess;
        private System.Windows.Forms.Panel pnlSelectFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clCC;
        private System.Windows.Forms.DataGridViewTextBoxColumn clBo_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtShareWithdrawRate;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel pnlError;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel pnlCompanySelection;
        private System.Windows.Forms.Label label2;
    }
}