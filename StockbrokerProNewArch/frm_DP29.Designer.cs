namespace StockbrokerProNewArch
{
    partial class frm_DP29
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory defaultGridFilterFactory1 = new GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_DP29));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStartImport = new System.Windows.Forms.Button();
            this.btnFileLocationBrowser = new System.Windows.Forms.Button();
            this.txtFileLocation = new System.Windows.Forms.TextBox();
            this.progress = new System.Windows.Forms.ProgressBar();
            this.lbProText = new System.Windows.Forms.Label();
            this.dgvErrors = new System.Windows.Forms.DataGridView();
            this.sn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ErrorDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ofdFileOpen = new System.Windows.Forms.OpenFileDialog();
            this.err = new System.Windows.Forms.ErrorProvider(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvClientInfo = new System.Windows.Forms.DataGridView();
            this.dgvExtension = new GridViewExtensions.DataGridFilterExtender(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvErrors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.err)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExtension)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnStartImport);
            this.groupBox1.Controls.Add(this.btnFileLocationBrowser);
            this.groupBox1.Controls.Add(this.txtFileLocation);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(650, 47);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select CDBL File";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(89, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = ":";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "File Location";
            // 
            // btnStartImport
            // 
            this.btnStartImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartImport.Location = new System.Drawing.Point(525, 19);
            this.btnStartImport.Name = "btnStartImport";
            this.btnStartImport.Size = new System.Drawing.Size(103, 23);
            this.btnStartImport.TabIndex = 10;
            this.btnStartImport.Text = "Start Import";
            this.btnStartImport.UseVisualStyleBackColor = true;
            this.btnStartImport.Click += new System.EventHandler(this.btnStartImport_Click);
            // 
            // btnFileLocationBrowser
            // 
            this.btnFileLocationBrowser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFileLocationBrowser.Location = new System.Drawing.Point(478, 19);
            this.btnFileLocationBrowser.Name = "btnFileLocationBrowser";
            this.btnFileLocationBrowser.Size = new System.Drawing.Size(40, 23);
            this.btnFileLocationBrowser.TabIndex = 11;
            this.btnFileLocationBrowser.Text = "...";
            this.btnFileLocationBrowser.UseVisualStyleBackColor = true;
            this.btnFileLocationBrowser.Click += new System.EventHandler(this.btnFileLocationBrowser_Click);
            // 
            // txtFileLocation
            // 
            this.txtFileLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFileLocation.Location = new System.Drawing.Point(103, 21);
            this.txtFileLocation.Name = "txtFileLocation";
            this.txtFileLocation.Size = new System.Drawing.Size(367, 20);
            this.txtFileLocation.TabIndex = 9;
            // 
            // progress
            // 
            this.progress.Location = new System.Drawing.Point(12, 74);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(650, 10);
            this.progress.TabIndex = 17;
            // 
            // lbProText
            // 
            this.lbProText.AutoSize = true;
            this.lbProText.ForeColor = System.Drawing.Color.SlateGray;
            this.lbProText.Location = new System.Drawing.Point(299, 58);
            this.lbProText.Name = "lbProText";
            this.lbProText.Size = new System.Drawing.Size(76, 13);
            this.lbProText.TabIndex = 19;
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
            this.CustomerName,
            this.ErrorDescription});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.SaddleBrown;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvErrors.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvErrors.Location = new System.Drawing.Point(12, 90);
            this.dgvErrors.MultiSelect = false;
            this.dgvErrors.Name = "dgvErrors";
            this.dgvErrors.RowHeadersVisible = false;
            this.dgvErrors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvErrors.Size = new System.Drawing.Size(650, 123);
            this.dgvErrors.TabIndex = 18;
            this.dgvErrors.TabStop = false;
            // 
            // sn
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.DarkGreen;
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
            this.CustomerCode.HeaderText = "Customer BO ID";
            this.CustomerCode.Name = "CustomerCode";
            this.CustomerCode.ReadOnly = true;
            // 
            // CustomerName
            // 
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.DarkGreen;
            this.CustomerName.DefaultCellStyle = dataGridViewCellStyle3;
            this.CustomerName.HeaderText = "CustomerName";
            this.CustomerName.Name = "CustomerName";
            // 
            // ErrorDescription
            // 
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Red;
            this.ErrorDescription.DefaultCellStyle = dataGridViewCellStyle4;
            this.ErrorDescription.HeaderText = "Error Description";
            this.ErrorDescription.Name = "ErrorDescription";
            this.ErrorDescription.Width = 400;
            // 
            // ofdFileOpen
            // 
            this.ofdFileOpen.Filter = "txt files (*.txt)|*.txt";
            // 
            // err
            // 
            this.err.ContainerControl = this;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(8, 216);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Client BO Information";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(160, 223);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(502, 1);
            this.label4.TabIndex = 22;
            this.label4.Text = "label4";
            // 
            // dgvClientInfo
            // 
            this.dgvClientInfo.AllowUserToAddRows = false;
            this.dgvClientInfo.AllowUserToDeleteRows = false;
            this.dgvClientInfo.AllowUserToResizeRows = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Navy;
            this.dgvClientInfo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvClientInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvClientInfo.BackgroundColor = System.Drawing.Color.LightGray;
            this.dgvClientInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientInfo.Cursor = System.Windows.Forms.Cursors.AppStarting;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.SaddleBrown;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvClientInfo.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvClientInfo.GridColor = System.Drawing.Color.LightGray;
            this.dgvClientInfo.Location = new System.Drawing.Point(12, 270);
            this.dgvClientInfo.MultiSelect = false;
            this.dgvClientInfo.Name = "dgvClientInfo";
            this.dgvClientInfo.ReadOnly = true;
            this.dgvClientInfo.RowHeadersVisible = false;
            this.dgvClientInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClientInfo.Size = new System.Drawing.Size(650, 161);
            this.dgvClientInfo.TabIndex = 23;
            // 
            // dgvExtension
            // 
            this.dgvExtension.AutoAdjustGridPosition = true;
            this.dgvExtension.AutoRefreshMode = GridViewExtensions.RefreshMode.OnEnter;
            this.dgvExtension.DataGridView = this.dgvClientInfo;
            defaultGridFilterFactory1.CreateDistinctGridFilters = false;
            defaultGridFilterFactory1.DefaultGridFilterType = typeof(GridViewExtensions.GridFilters.TextGridFilter);
            defaultGridFilterFactory1.DefaultShowDateInBetweenOperator = false;
            defaultGridFilterFactory1.DefaultShowNumericInBetweenOperator = false;
            defaultGridFilterFactory1.HandleEnumerationTypes = true;
            defaultGridFilterFactory1.MaximumDistinctValues = 20;
            this.dgvExtension.FilterFactory = defaultGridFilterFactory1;
            this.dgvExtension.GridFilterBound += new GridViewExtensions.GridFilterEventHandler(this.dgvExtension_GridFilterBound);
            this.dgvExtension.AfterFiltersChanged += new System.EventHandler(this.dgvExtension_AfterFiltersChanged);
            this.dgvExtension.BeforeFiltersChanging += new System.EventHandler(this.dgvExtension_BeforeFiltersChanging);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.SaddleBrown;
            this.button1.Location = new System.Drawing.Point(378, 438);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 25);
            this.button1.TabIndex = 25;
            this.button1.Text = "Process";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.SaddleBrown;
            this.button2.Location = new System.Drawing.Point(474, 438);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(90, 25);
            this.button2.TabIndex = 26;
            this.button2.Text = "Check";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(570, 438);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnCancel.Size = new System.Drawing.Size(90, 25);
            this.btnCancel.TabIndex = 54;
            this.btnCancel.Text = "Close";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // frm_DP29
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 468);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.dgvClientInfo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.progress);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lbProText);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvErrors);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.SaddleBrown;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frm_DP29";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BO File Upload || BO-DP29";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvErrors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.err)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExtension)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStartImport;
        private System.Windows.Forms.Button btnFileLocationBrowser;
        private System.Windows.Forms.TextBox txtFileLocation;
        private System.Windows.Forms.ProgressBar progress;
        private System.Windows.Forms.Label lbProText;
        private System.Windows.Forms.DataGridView dgvErrors;
        private System.Windows.Forms.OpenFileDialog ofdFileOpen;
        private System.Windows.Forms.ErrorProvider err;
        private System.Windows.Forms.DataGridViewTextBoxColumn sn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ErrorDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvClientInfo;
        private System.Windows.Forms.Label label4;
        private GridViewExtensions.DataGridFilterExtender dgvExtension;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnCancel;
    }
}