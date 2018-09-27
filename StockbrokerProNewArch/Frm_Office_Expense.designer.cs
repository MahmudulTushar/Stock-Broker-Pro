namespace StockbrokerProNewArch
{
    partial class Frm_Office_Expense
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
            this.radMD = new System.Windows.Forms.RadioButton();
            this.radDMD = new System.Windows.Forms.RadioButton();
            this.radCash = new System.Windows.Forms.RadioButton();
            this.radCheque = new System.Windows.Forms.RadioButton();
            this.txtAmt = new System.Windows.Forms.TextBox();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtAccountNo = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.bttNew = new System.Windows.Forms.Button();
            this.bttSave = new System.Windows.Forms.Button();
            this.cmbBankName = new System.Windows.Forms.ComboBox();
            this.txtDate = new System.Windows.Forms.DateTimePicker();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBranceh = new System.Windows.Forms.TextBox();
            this.labBranceh = new System.Windows.Forms.Label();
            this.txtRoutingNo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtChequeNo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtvoucher = new System.Windows.Forms.TextBox();
            this.DataGrid = new System.Windows.Forms.DataGridView();
            this.dataGridFilterExtender1 = new GridViewExtensions.DataGridFilterExtender(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpSearchDateWise = new System.Windows.Forms.DateTimePicker();
            this.lblCount = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFilterExtender1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // radMD
            // 
            this.radMD.AutoSize = true;
            this.radMD.Location = new System.Drawing.Point(2, 4);
            this.radMD.Margin = new System.Windows.Forms.Padding(2);
            this.radMD.Name = "radMD";
            this.radMD.Size = new System.Drawing.Size(42, 17);
            this.radMD.TabIndex = 1;
            this.radMD.TabStop = true;
            this.radMD.Text = "MD";
            this.radMD.UseVisualStyleBackColor = true;
            // 
            // radDMD
            // 
            this.radDMD.AutoSize = true;
            this.radDMD.Location = new System.Drawing.Point(63, 4);
            this.radDMD.Margin = new System.Windows.Forms.Padding(2);
            this.radDMD.Name = "radDMD";
            this.radDMD.Size = new System.Drawing.Size(50, 17);
            this.radDMD.TabIndex = 3;
            this.radDMD.TabStop = true;
            this.radDMD.Text = "DMD";
            this.radDMD.UseVisualStyleBackColor = true;
            // 
            // radCash
            // 
            this.radCash.AutoSize = true;
            this.radCash.Location = new System.Drawing.Point(2, 3);
            this.radCash.Margin = new System.Windows.Forms.Padding(2);
            this.radCash.Name = "radCash";
            this.radCash.Size = new System.Drawing.Size(49, 17);
            this.radCash.TabIndex = 3;
            this.radCash.TabStop = true;
            this.radCash.Text = "Cash";
            this.radCash.UseVisualStyleBackColor = true;
            this.radCash.CheckedChanged += new System.EventHandler(this.radCash_CheckedChanged);
            // 
            // radCheque
            // 
            this.radCheque.AutoSize = true;
            this.radCheque.Location = new System.Drawing.Point(64, 4);
            this.radCheque.Margin = new System.Windows.Forms.Padding(2);
            this.radCheque.Name = "radCheque";
            this.radCheque.Size = new System.Drawing.Size(62, 17);
            this.radCheque.TabIndex = 5;
            this.radCheque.TabStop = true;
            this.radCheque.Text = "Cheque";
            this.radCheque.UseVisualStyleBackColor = true;
            this.radCheque.CheckedChanged += new System.EventHandler(this.radCheque_CheckedChanged_1);
            // 
            // txtAmt
            // 
            this.txtAmt.Location = new System.Drawing.Point(74, 70);
            this.txtAmt.Margin = new System.Windows.Forms.Padding(2);
            this.txtAmt.Name = "txtAmt";
            this.txtAmt.Size = new System.Drawing.Size(133, 20);
            this.txtAmt.TabIndex = 2;
            this.txtAmt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmt_KeyPress);
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(74, 121);
            this.txtRemarks.Margin = new System.Windows.Forms.Padding(2);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(133, 20);
            this.txtRemarks.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Date :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 97);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Media :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 49);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Pay By :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 73);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Amount :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 124);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Remarks :";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtAccountNo);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.bttNew);
            this.panel2.Controls.Add(this.bttSave);
            this.panel2.Controls.Add(this.cmbBankName);
            this.panel2.Controls.Add(this.txtDate);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.txtBranceh);
            this.panel2.Controls.Add(this.labBranceh);
            this.panel2.Controls.Add(this.txtRoutingNo);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txtChequeNo);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.txtvoucher);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtRemarks);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtAmt);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(5, 12);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(573, 230);
            this.panel2.TabIndex = 22;
            // 
            // txtAccountNo
            // 
            this.txtAccountNo.Location = new System.Drawing.Point(310, 95);
            this.txtAccountNo.Name = "txtAccountNo";
            this.txtAccountNo.Size = new System.Drawing.Size(255, 20);
            this.txtAccountNo.TabIndex = 36;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(240, 98);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 13);
            this.label11.TabIndex = 35;
            this.label11.Text = "Account No";
            // 
            // bttNew
            // 
            this.bttNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bttNew.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bttNew.Location = new System.Drawing.Point(254, 187);
            this.bttNew.Margin = new System.Windows.Forms.Padding(2);
            this.bttNew.Name = "bttNew";
            this.bttNew.Size = new System.Drawing.Size(64, 28);
            this.bttNew.TabIndex = 27;
            this.bttNew.Text = "Refresh";
            this.bttNew.UseVisualStyleBackColor = true;
            this.bttNew.Click += new System.EventHandler(this.button4_Click);
            // 
            // bttSave
            // 
            this.bttSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bttSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bttSave.Location = new System.Drawing.Point(186, 187);
            this.bttSave.Margin = new System.Windows.Forms.Padding(2);
            this.bttSave.Name = "bttSave";
            this.bttSave.Size = new System.Drawing.Size(64, 28);
            this.bttSave.TabIndex = 24;
            this.bttSave.Text = "save";
            this.bttSave.UseVisualStyleBackColor = true;
            this.bttSave.Click += new System.EventHandler(this.bttSave_Click);
            // 
            // cmbBankName
            // 
            this.cmbBankName.FormattingEnabled = true;
            this.cmbBankName.Location = new System.Drawing.Point(310, 44);
            this.cmbBankName.Name = "cmbBankName";
            this.cmbBankName.Size = new System.Drawing.Size(255, 21);
            this.cmbBankName.TabIndex = 34;
            this.cmbBankName.SelectionChangeCommitted += new System.EventHandler(this.cmbBankName_SelectionChangeCommitted);
            // 
            // txtDate
            // 
            this.txtDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtDate.Location = new System.Drawing.Point(74, 19);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(134, 20);
            this.txtDate.TabIndex = 33;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.radMD);
            this.panel3.Controls.Add(this.radDMD);
            this.panel3.Location = new System.Drawing.Point(74, 43);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(134, 23);
            this.panel3.TabIndex = 30;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radCash);
            this.panel1.Controls.Add(this.radCheque);
            this.panel1.Location = new System.Drawing.Point(74, 93);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(133, 24);
            this.panel1.TabIndex = 29;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(240, 153);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 13);
            this.label9.TabIndex = 28;
            this.label9.Text = "Cheque No";
            // 
            // txtBranceh
            // 
            this.txtBranceh.Location = new System.Drawing.Point(310, 69);
            this.txtBranceh.Margin = new System.Windows.Forms.Padding(2);
            this.txtBranceh.Name = "txtBranceh";
            this.txtBranceh.Size = new System.Drawing.Size(255, 20);
            this.txtBranceh.TabIndex = 22;
            // 
            // labBranceh
            // 
            this.labBranceh.AutoSize = true;
            this.labBranceh.Location = new System.Drawing.Point(225, 72);
            this.labBranceh.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labBranceh.Name = "labBranceh";
            this.labBranceh.Size = new System.Drawing.Size(78, 13);
            this.labBranceh.TabIndex = 27;
            this.labBranceh.Text = "Branceh Name";
            // 
            // txtRoutingNo
            // 
            this.txtRoutingNo.Location = new System.Drawing.Point(310, 124);
            this.txtRoutingNo.Margin = new System.Windows.Forms.Padding(2);
            this.txtRoutingNo.Name = "txtRoutingNo";
            this.txtRoutingNo.Size = new System.Drawing.Size(255, 20);
            this.txtRoutingNo.TabIndex = 23;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(237, 48);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 26;
            this.label7.Text = "Bank Name";
            // 
            // txtChequeNo
            // 
            this.txtChequeNo.Location = new System.Drawing.Point(310, 150);
            this.txtChequeNo.Margin = new System.Windows.Forms.Padding(2);
            this.txtChequeNo.Name = "txtChequeNo";
            this.txtChequeNo.Size = new System.Drawing.Size(255, 20);
            this.txtChequeNo.TabIndex = 24;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(241, 126);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "Routing No";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(237, 24);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "Voucher No";
            // 
            // txtvoucher
            // 
            this.txtvoucher.Location = new System.Drawing.Point(310, 19);
            this.txtvoucher.Margin = new System.Windows.Forms.Padding(2);
            this.txtvoucher.Name = "txtvoucher";
            this.txtvoucher.ReadOnly = true;
            this.txtvoucher.Size = new System.Drawing.Size(100, 20);
            this.txtvoucher.TabIndex = 16;
            // 
            // DataGrid
            // 
            this.DataGrid.AllowUserToAddRows = false;
            this.DataGrid.AllowUserToDeleteRows = false;
            this.DataGrid.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.DataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGrid.Location = new System.Drawing.Point(5, 68);
            this.DataGrid.Margin = new System.Windows.Forms.Padding(2);
            this.DataGrid.Name = "DataGrid";
            this.DataGrid.ReadOnly = true;
            this.DataGrid.RowTemplate.Height = 24;
            this.DataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGrid.Size = new System.Drawing.Size(574, 245);
            this.DataGrid.TabIndex = 23;
            // 
            // dataGridFilterExtender1
            // 
            this.dataGridFilterExtender1.DataGridView = this.DataGrid;
            defaultGridFilterFactory1.CreateDistinctGridFilters = false;
            defaultGridFilterFactory1.DefaultGridFilterType = typeof(GridViewExtensions.GridFilters.TextGridFilter);
            defaultGridFilterFactory1.DefaultShowDateInBetweenOperator = false;
            defaultGridFilterFactory1.DefaultShowNumericInBetweenOperator = false;
            defaultGridFilterFactory1.HandleEnumerationTypes = true;
            defaultGridFilterFactory1.MaximumDistinctValues = 20;
            this.dataGridFilterExtender1.FilterFactory = defaultGridFilterFactory1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpSearchDateWise);
            this.groupBox1.Controls.Add(this.lblCount);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.DataGrid);
            this.groupBox1.Location = new System.Drawing.Point(7, 258);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(585, 322);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            // 
            // dtpSearchDateWise
            // 
            this.dtpSearchDateWise.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpSearchDateWise.Location = new System.Drawing.Point(62, 21);
            this.dtpSearchDateWise.Name = "dtpSearchDateWise";
            this.dtpSearchDateWise.Size = new System.Drawing.Size(104, 20);
            this.dtpSearchDateWise.TabIndex = 31;
            this.dtpSearchDateWise.ValueChanged += new System.EventHandler(this.dtpSearchDateWise_ValueChanged);
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.BackColor = System.Drawing.Color.Gainsboro;
            this.lblCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCount.ForeColor = System.Drawing.Color.Maroon;
            this.lblCount.Location = new System.Drawing.Point(549, 24);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(19, 13);
            this.lblCount.TabIndex = 33;
            this.lblCount.Text = "00";
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Gainsboro;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Maroon;
            this.label14.Location = new System.Drawing.Point(502, 24);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(41, 13);
            this.label14.TabIndex = 32;
            this.label14.Text = "Count :";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Gainsboro;
            this.label13.Location = new System.Drawing.Point(11, 24);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(47, 13);
            this.label13.TabIndex = 30;
            this.label13.Text = "Search :";
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.Gainsboro;
            this.label12.Location = new System.Drawing.Point(5, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(574, 29);
            this.label12.TabIndex = 29;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Location = new System.Drawing.Point(7, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(585, 248);
            this.groupBox2.TabIndex = 35;
            this.groupBox2.TabStop = false;
            // 
            // Frm_Office_Expense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 585);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Frm_Office_Expense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cash Deposit";
            this.Load += new System.EventHandler(this.Frm_Office_Expense_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFilterExtender1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton radMD;
        private System.Windows.Forms.RadioButton radDMD;
        private System.Windows.Forms.RadioButton radCash;
        private System.Windows.Forms.RadioButton radCheque;
        private System.Windows.Forms.TextBox txtAmt;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView DataGrid;
        private System.Windows.Forms.Button bttSave;
        private System.Windows.Forms.Button bttNew;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtvoucher;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtBranceh;
        private System.Windows.Forms.Label labBranceh;
        private System.Windows.Forms.TextBox txtRoutingNo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtChequeNo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker txtDate;
        private System.Windows.Forms.ComboBox cmbBankName;
        private System.Windows.Forms.TextBox txtAccountNo;
        private System.Windows.Forms.Label label11;
        private GridViewExtensions.DataGridFilterExtender dataGridFilterExtender1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker dtpSearchDateWise;
        private System.Windows.Forms.Label label13;
    }
}