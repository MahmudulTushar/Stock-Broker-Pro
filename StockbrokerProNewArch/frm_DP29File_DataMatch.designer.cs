namespace StockbrokerProNewArch
{
    partial class frm_DP29File_DataMatch
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
            GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory defaultGridFilterFactory1 = new GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSchemabrowse = new System.Windows.Forms.TextBox();
            this.btnSchemabrowse = new System.Windows.Forms.Button();
            this.btncheck = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDataFileBrowse = new System.Windows.Forms.TextBox();
            this.btnDataFileBrowse = new System.Windows.Forms.Button();
            this.btnStartImport = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dbcSelectColumn = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnFind = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStop = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnLoadPrvData = new System.Windows.Forms.Button();
            this.btnMismatch = new System.Windows.Forms.Button();
            this.btnChange = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnLoadDP29 = new System.Windows.Forms.Button();
            this.btnForceClose = new System.Windows.Forms.Button();
            this.ChkSelectAll = new System.Windows.Forms.CheckBox();
            this.clbColumnName = new System.Windows.Forms.CheckedListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dgdDisplayData = new System.Windows.Forms.DataGridView();
            this.cbSelectAllListboxItem = new System.Windows.Forms.CheckBox();
            this.cmbFilterValue = new System.Windows.Forms.ComboBox();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSetting = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.DataMismatchBackgroudworker = new System.ComponentModel.BackgroundWorker();
            this.DataUpdate_backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.cmbReport = new System.Windows.Forms.ComboBox();
            this.dataGridFilterExtender1 = new GridViewExtensions.DataGridFilterExtender(this.components);
            this.groupBox1.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgdDisplayData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFilterExtender1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "File Location";
            // 
            // txtSchemabrowse
            // 
            this.txtSchemabrowse.BackColor = System.Drawing.SystemColors.Info;
            this.txtSchemabrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSchemabrowse.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txtSchemabrowse.Location = new System.Drawing.Point(102, 18);
            this.txtSchemabrowse.Name = "txtSchemabrowse";
            this.txtSchemabrowse.ReadOnly = true;
            this.txtSchemabrowse.Size = new System.Drawing.Size(547, 23);
            this.txtSchemabrowse.TabIndex = 1;
            this.txtSchemabrowse.Text = "Please Select DP29_V6 Column Name File";
            // 
            // btnSchemabrowse
            // 
            this.btnSchemabrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSchemabrowse.Location = new System.Drawing.Point(662, 17);
            this.btnSchemabrowse.Name = "btnSchemabrowse";
            this.btnSchemabrowse.Size = new System.Drawing.Size(99, 25);
            this.btnSchemabrowse.TabIndex = 2;
            this.btnSchemabrowse.Text = "Browse";
            this.btnSchemabrowse.UseVisualStyleBackColor = true;
            this.btnSchemabrowse.Click += new System.EventHandler(this.btnSchemabrowse_Click);
            // 
            // btncheck
            // 
            this.btncheck.Enabled = false;
            this.btncheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncheck.Location = new System.Drawing.Point(772, 17);
            this.btncheck.Name = "btncheck";
            this.btncheck.Size = new System.Drawing.Size(99, 25);
            this.btncheck.TabIndex = 2;
            this.btncheck.Text = "Check";
            this.btncheck.UseVisualStyleBackColor = true;
            this.btncheck.Click += new System.EventHandler(this.btncheck_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "File Location";
            // 
            // txtDataFileBrowse
            // 
            this.txtDataFileBrowse.BackColor = System.Drawing.SystemColors.Info;
            this.txtDataFileBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDataFileBrowse.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txtDataFileBrowse.Location = new System.Drawing.Point(102, 55);
            this.txtDataFileBrowse.Name = "txtDataFileBrowse";
            this.txtDataFileBrowse.ReadOnly = true;
            this.txtDataFileBrowse.Size = new System.Drawing.Size(547, 23);
            this.txtDataFileBrowse.TabIndex = 1;
            this.txtDataFileBrowse.Text = "Please Select DP29_V6 Data File";
            // 
            // btnDataFileBrowse
            // 
            this.btnDataFileBrowse.Enabled = false;
            this.btnDataFileBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDataFileBrowse.Location = new System.Drawing.Point(662, 54);
            this.btnDataFileBrowse.Name = "btnDataFileBrowse";
            this.btnDataFileBrowse.Size = new System.Drawing.Size(99, 25);
            this.btnDataFileBrowse.TabIndex = 2;
            this.btnDataFileBrowse.Text = "Browse";
            this.btnDataFileBrowse.UseVisualStyleBackColor = true;
            this.btnDataFileBrowse.Click += new System.EventHandler(this.btnDataFileBrowse_Click);
            // 
            // btnStartImport
            // 
            this.btnStartImport.Enabled = false;
            this.btnStartImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartImport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnStartImport.Location = new System.Drawing.Point(772, 54);
            this.btnStartImport.Name = "btnStartImport";
            this.btnStartImport.Size = new System.Drawing.Size(99, 25);
            this.btnStartImport.TabIndex = 2;
            this.btnStartImport.Text = "Start Import";
            this.btnStartImport.UseVisualStyleBackColor = true;
            this.btnStartImport.Click += new System.EventHandler(this.btnStartImport_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSchemabrowse);
            this.groupBox1.Controls.Add(this.btnStartImport);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btncheck);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnDataFileBrowse);
            this.groupBox1.Controls.Add(this.txtDataFileBrowse);
            this.groupBox1.Controls.Add(this.btnSchemabrowse);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(877, 100);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // dbcSelectColumn
            // 
            this.dbcSelectColumn.BackColor = System.Drawing.Color.White;
            this.dbcSelectColumn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dbcSelectColumn.FormattingEnabled = true;
            this.dbcSelectColumn.Items.AddRange(new object[] {
            "Select Column Name"});
            this.dbcSelectColumn.Location = new System.Drawing.Point(337, 133);
            this.dbcSelectColumn.Name = "dbcSelectColumn";
            this.dbcSelectColumn.Size = new System.Drawing.Size(205, 24);
            this.dbcSelectColumn.TabIndex = 11;
            this.dbcSelectColumn.SelectedIndexChanged += new System.EventHandler(this.dbcSelectColumn_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(557, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Value";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(223, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Select Column";
            // 
            // btnFind
            // 
            this.btnFind.Enabled = false;
            this.btnFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFind.Location = new System.Drawing.Point(808, 134);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 10;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.toolStripStatusCount,
            this.toolStripProgressBar,
            this.toolStripStop});
            this.statusStrip.Location = new System.Drawing.Point(0, 590);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(900, 22);
            this.statusStrip.TabIndex = 13;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(85, 17);
            this.toolStripStatusLabel.Text = "Show Message";
            // 
            // toolStripStatusCount
            // 
            this.toolStripStatusCount.Margin = new System.Windows.Forms.Padding(30, 3, 0, 2);
            this.toolStripStatusCount.Name = "toolStripStatusCount";
            this.toolStripStatusCount.Size = new System.Drawing.Size(13, 17);
            this.toolStripStatusCount.Text = "0";
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Margin = new System.Windows.Forms.Padding(35, 3, 1, 3);
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(500, 16);
            // 
            // toolStripStop
            // 
            this.toolStripStop.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedOuter;
            this.toolStripStop.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripStop.ForeColor = System.Drawing.Color.Red;
            this.toolStripStop.Name = "toolStripStop";
            this.toolStripStop.Size = new System.Drawing.Size(37, 17);
            this.toolStripStop.Text = "STOP";
            this.toolStripStop.Visible = false;
            this.toolStripStop.Click += new System.EventHandler(this.toolStripStop_Click);
            // 
            // btnLoadPrvData
            // 
            this.btnLoadPrvData.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadPrvData.Location = new System.Drawing.Point(537, 514);
            this.btnLoadPrvData.Name = "btnLoadPrvData";
            this.btnLoadPrvData.Size = new System.Drawing.Size(113, 25);
            this.btnLoadPrvData.TabIndex = 2;
            this.btnLoadPrvData.Text = "Load Mismatch";
            this.btnLoadPrvData.UseVisualStyleBackColor = true;
            this.btnLoadPrvData.Click += new System.EventHandler(this.btnLoadPrvData_Click);
            // 
            // btnMismatch
            // 
            this.btnMismatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMismatch.Location = new System.Drawing.Point(451, 513);
            this.btnMismatch.Name = "btnMismatch";
            this.btnMismatch.Size = new System.Drawing.Size(80, 25);
            this.btnMismatch.TabIndex = 2;
            this.btnMismatch.Text = "Mismatch";
            this.btnMismatch.UseVisualStyleBackColor = true;
            this.btnMismatch.Click += new System.EventHandler(this.btnMismatch_Click);
            // 
            // btnChange
            // 
            this.btnChange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnChange.Enabled = false;
            this.btnChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChange.Location = new System.Drawing.Point(450, 545);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(80, 25);
            this.btnChange.TabIndex = 2;
            this.btnChange.Text = "Update";
            this.btnChange.UseVisualStyleBackColor = false;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // btnReport
            // 
            this.btnReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.Location = new System.Drawing.Point(824, 545);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(68, 25);
            this.btnReport.TabIndex = 2;
            this.btnReport.Text = "Report";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // btnLoadDP29
            // 
            this.btnLoadDP29.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadDP29.Location = new System.Drawing.Point(537, 546);
            this.btnLoadDP29.Name = "btnLoadDP29";
            this.btnLoadDP29.Size = new System.Drawing.Size(113, 25);
            this.btnLoadDP29.TabIndex = 2;
            this.btnLoadDP29.Text = "Load DP29";
            this.btnLoadDP29.UseVisualStyleBackColor = true;
            this.btnLoadDP29.Click += new System.EventHandler(this.btnLoadDP29_Click);
            // 
            // btnForceClose
            // 
            this.btnForceClose.BackColor = System.Drawing.Color.Red;
            this.btnForceClose.Enabled = false;
            this.btnForceClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnForceClose.Location = new System.Drawing.Point(657, 515);
            this.btnForceClose.Name = "btnForceClose";
            this.btnForceClose.Size = new System.Drawing.Size(158, 25);
            this.btnForceClose.TabIndex = 2;
            this.btnForceClose.Text = "Force Close";
            this.btnForceClose.UseVisualStyleBackColor = false;
            this.btnForceClose.Click += new System.EventHandler(this.btnForceClose_Click);
            // 
            // ChkSelectAll
            // 
            this.ChkSelectAll.AutoSize = true;
            this.ChkSelectAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkSelectAll.Location = new System.Drawing.Point(15, 148);
            this.ChkSelectAll.Name = "ChkSelectAll";
            this.ChkSelectAll.Size = new System.Drawing.Size(85, 21);
            this.ChkSelectAll.TabIndex = 15;
            this.ChkSelectAll.Text = "Select All";
            this.ChkSelectAll.UseVisualStyleBackColor = true;
            this.ChkSelectAll.CheckedChanged += new System.EventHandler(this.ChkSelectAll_CheckedChanged);
            // 
            // clbColumnName
            // 
            this.clbColumnName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clbColumnName.FormattingEnabled = true;
            this.clbColumnName.Location = new System.Drawing.Point(10, 513);
            this.clbColumnName.Name = "clbColumnName";
            this.clbColumnName.Size = new System.Drawing.Size(266, 58);
            this.clbColumnName.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkRed;
            this.label5.Location = new System.Drawing.Point(30, 493);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(246, 17);
            this.label5.TabIndex = 17;
            this.label5.Text = "Select Column name want to change *";
            // 
            // dgdDisplayData
            // 
            this.dgdDisplayData.AllowUserToAddRows = false;
            this.dgdDisplayData.AllowUserToDeleteRows = false;
            this.dgdDisplayData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgdDisplayData.Location = new System.Drawing.Point(12, 198);
            this.dgdDisplayData.Name = "dgdDisplayData";
            this.dgdDisplayData.Size = new System.Drawing.Size(877, 292);
            this.dgdDisplayData.TabIndex = 4;
            // 
            // cbSelectAllListboxItem
            // 
            this.cbSelectAllListboxItem.AutoSize = true;
            this.cbSelectAllListboxItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSelectAllListboxItem.Location = new System.Drawing.Point(13, 495);
            this.cbSelectAllListboxItem.Name = "cbSelectAllListboxItem";
            this.cbSelectAllListboxItem.Size = new System.Drawing.Size(15, 14);
            this.cbSelectAllListboxItem.TabIndex = 18;
            this.cbSelectAllListboxItem.UseVisualStyleBackColor = true;
            this.cbSelectAllListboxItem.CheckedChanged += new System.EventHandler(this.cbSelectAllListboxItem_CheckedChanged);
            // 
            // cmbFilterValue
            // 
            this.cmbFilterValue.BackColor = System.Drawing.Color.White;
            this.cmbFilterValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFilterValue.FormattingEnabled = true;
            this.cmbFilterValue.Location = new System.Drawing.Point(607, 133);
            this.cmbFilterValue.Name = "cmbFilterValue";
            this.cmbFilterValue.Size = new System.Drawing.Size(189, 24);
            this.cmbFilterValue.TabIndex = 11;
            // 
            // txtTo
            // 
            this.txtTo.Location = new System.Drawing.Point(385, 513);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(60, 20);
            this.txtTo.TabIndex = 19;
            // 
            // txtFrom
            // 
            this.txtFrom.Location = new System.Drawing.Point(285, 512);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Size = new System.Drawing.Size(71, 20);
            this.txtFrom.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(359, 515);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "To";
            // 
            // btnSetting
            // 
            this.btnSetting.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetting.Location = new System.Drawing.Point(282, 546);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(163, 25);
            this.btnSetting.TabIndex = 2;
            this.btnSetting.Text = "Setting(For Developer)";
            this.btnSetting.UseVisualStyleBackColor = true;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Maroon;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnClose.Location = new System.Drawing.Point(824, 515);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(68, 25);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // DataMismatchBackgroudworker
            // 
            this.DataMismatchBackgroudworker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.DataMismatchBackgroudworker_DoWork);
            this.DataMismatchBackgroudworker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.DataMismatchBackgroudworker_RunWorkerCompleted);
            this.DataMismatchBackgroudworker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.DataMismatchBackgroudworker_ProgressChanged);
            // 
            // DataUpdate_backgroundWorker
            // 
            this.DataUpdate_backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.DataUpdate_backgroundWorker_DoWork);
            this.DataUpdate_backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.DataUpdate_backgroundWorker_RunWorkerCompleted);
            this.DataUpdate_backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.DataUpdate_backgroundWorker_ProgressChanged);
            // 
            // cmbReport
            // 
            this.cmbReport.BackColor = System.Drawing.Color.White;
            this.cmbReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbReport.FormattingEnabled = true;
            this.cmbReport.Items.AddRange(new object[] {
            "Select One",
            "Summary"});
            this.cmbReport.Location = new System.Drawing.Point(660, 547);
            this.cmbReport.Name = "cmbReport";
            this.cmbReport.Size = new System.Drawing.Size(155, 24);
            this.cmbReport.TabIndex = 11;
            // 
            // dataGridFilterExtender1
            // 
            this.dataGridFilterExtender1.DataGridView = this.dgdDisplayData;
            defaultGridFilterFactory1.CreateDistinctGridFilters = false;
            defaultGridFilterFactory1.DefaultGridFilterType = typeof(GridViewExtensions.GridFilters.TextGridFilter);
            defaultGridFilterFactory1.DefaultShowDateInBetweenOperator = false;
            defaultGridFilterFactory1.DefaultShowNumericInBetweenOperator = false;
            defaultGridFilterFactory1.HandleEnumerationTypes = true;
            defaultGridFilterFactory1.MaximumDistinctValues = 20;
            this.dataGridFilterExtender1.FilterFactory = defaultGridFilterFactory1;
            // 
            // frm_DP29File_DataMatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(900, 612);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtFrom);
            this.Controls.Add(this.txtTo);
            this.Controls.Add(this.cbSelectAllListboxItem);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.clbColumnName);
            this.Controls.Add(this.ChkSelectAll);
            this.Controls.Add(this.dgdDisplayData);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.cmbReport);
            this.Controls.Add(this.cmbFilterValue);
            this.Controls.Add(this.dbcSelectColumn);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSetting);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnForceClose);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.btnMismatch);
            this.Controls.Add(this.btnLoadDP29);
            this.Controls.Add(this.btnLoadPrvData);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "frm_DP29File_DataMatch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_DP29File_DataMatch";
            this.Load += new System.EventHandler(this.frm_DP29File_DataMatch_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgdDisplayData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFilterExtender1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSchemabrowse;
        private System.Windows.Forms.Button btnSchemabrowse;
        private System.Windows.Forms.Button btncheck;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDataFileBrowse;
        private System.Windows.Forms.Button btnDataFileBrowse;
        private System.Windows.Forms.Button btnStartImport;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox dbcSelectColumn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.Button btnLoadPrvData;
        private System.Windows.Forms.Button btnMismatch;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusCount;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.Button btnLoadDP29;
        private System.Windows.Forms.Button btnForceClose;
        private System.Windows.Forms.CheckBox ChkSelectAll;
        private System.Windows.Forms.CheckedListBox clbColumnName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgdDisplayData;
        private System.Windows.Forms.CheckBox cbSelectAllListboxItem;
        private System.Windows.Forms.ComboBox cmbFilterValue;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStop;
        private System.Windows.Forms.Button btnSetting;
        private System.Windows.Forms.Button btnClose;
        private System.ComponentModel.BackgroundWorker DataMismatchBackgroudworker;
        private System.ComponentModel.BackgroundWorker DataUpdate_backgroundWorker;
        private System.Windows.Forms.ComboBox cmbReport;
        private GridViewExtensions.DataGridFilterExtender dataGridFilterExtender1;
    }
}