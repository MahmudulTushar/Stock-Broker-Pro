namespace StockbrokerProNewArch
{
    partial class frmPreDefineAmountOfLiabilities
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPreDefineAmountOfLiabilities));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory defaultGridFilterFactory1 = new GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgvPaybleExpense = new System.Windows.Forms.DataGridView();
            this.btnView = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.rbMonthly = new System.Windows.Forms.RadioButton();
            this.rbYearly = new System.Windows.Forms.RadioButton();
            this.txtPaymentAmount = new System.Windows.Forms.TextBox();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rbHalfYearly = new System.Windows.Forms.RadioButton();
            this.rbQuarterly = new System.Windows.Forms.RadioButton();
            this.cmbLiabilitiesName = new URT.ComboBox.ColumnCombo();
            this.label9 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.dtpSettledDate = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLiabilitiesName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGridFilterExtender1 = new GridViewExtensions.DataGridFilterExtender(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaybleExpense)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFilterExtender1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(394, 116);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(96, 25);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgvPaybleExpense
            // 
            this.dgvPaybleExpense.AllowUserToAddRows = false;
            this.dgvPaybleExpense.AllowUserToDeleteRows = false;
            this.dgvPaybleExpense.BackgroundColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPaybleExpense.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPaybleExpense.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.MistyRose;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.DarkRed;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPaybleExpense.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPaybleExpense.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvPaybleExpense.Location = new System.Drawing.Point(7, 58);
            this.dgvPaybleExpense.Name = "dgvPaybleExpense";
            this.dgvPaybleExpense.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPaybleExpense.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPaybleExpense.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPaybleExpense.Size = new System.Drawing.Size(587, 213);
            this.dgvPaybleExpense.TabIndex = 5;
            // 
            // btnView
            // 
            this.btnView.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnView.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.ForeColor = System.Drawing.Color.Black;
            this.btnView.Image = ((System.Drawing.Image)(resources.GetObject("btnView.Image")));
            this.btnView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnView.Location = new System.Drawing.Point(396, 277);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(96, 25);
            this.btnView.TabIndex = 6;
            this.btnView.Text = "View";
            this.btnView.UseVisualStyleBackColor = false;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.Black;
            this.btnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.Image")));
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.Location = new System.Drawing.Point(498, 277);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(96, 25);
            this.btnUpdate.TabIndex = 7;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // rbMonthly
            // 
            this.rbMonthly.AutoSize = true;
            this.rbMonthly.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbMonthly.Location = new System.Drawing.Point(149, 42);
            this.rbMonthly.Name = "rbMonthly";
            this.rbMonthly.Size = new System.Drawing.Size(62, 17);
            this.rbMonthly.TabIndex = 9;
            this.rbMonthly.TabStop = true;
            this.rbMonthly.Text = "Monthly";
            this.rbMonthly.UseVisualStyleBackColor = true;
            this.rbMonthly.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rbMonthly_KeyPress);
            // 
            // rbYearly
            // 
            this.rbYearly.AutoSize = true;
            this.rbYearly.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbYearly.Location = new System.Drawing.Point(13, 19);
            this.rbYearly.Name = "rbYearly";
            this.rbYearly.Size = new System.Drawing.Size(54, 17);
            this.rbYearly.TabIndex = 10;
            this.rbYearly.TabStop = true;
            this.rbYearly.Text = "Yearly";
            this.rbYearly.UseVisualStyleBackColor = true;
            this.rbYearly.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rbYearly_KeyPress);
            // 
            // txtPaymentAmount
            // 
            this.txtPaymentAmount.Location = new System.Drawing.Point(110, 91);
            this.txtPaymentAmount.Name = "txtPaymentAmount";
            this.txtPaymentAmount.Size = new System.Drawing.Size(208, 20);
            this.txtPaymentAmount.TabIndex = 11;
            this.txtPaymentAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPaymentAmount_KeyPress);
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(110, 116);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(208, 20);
            this.txtRemarks.TabIndex = 12;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.cmbLiabilitiesName);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.dtpSettledDate);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtLiabilitiesName);
            this.groupBox1.Controls.Add(this.txtPaymentAmount);
            this.groupBox1.Controls.Add(this.txtRemarks);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(599, 147);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = "";
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(94, 66);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(10, 20);
            this.label11.TabIndex = 87;
            this.label11.Text = ":";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(94, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(10, 20);
            this.label4.TabIndex = 86;
            this.label4.Text = ":";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(94, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 20);
            this.label3.TabIndex = 85;
            this.label3.Text = ":";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(94, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 20);
            this.label2.TabIndex = 84;
            this.label2.Text = ":";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rbYearly);
            this.groupBox4.Controls.Add(this.rbHalfYearly);
            this.groupBox4.Controls.Add(this.rbQuarterly);
            this.groupBox4.Controls.Add(this.rbMonthly);
            this.groupBox4.Location = new System.Drawing.Point(348, 42);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(246, 69);
            this.groupBox4.TabIndex = 83;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Select Period";
            // 
            // rbHalfYearly
            // 
            this.rbHalfYearly.AutoSize = true;
            this.rbHalfYearly.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbHalfYearly.Location = new System.Drawing.Point(149, 19);
            this.rbHalfYearly.Name = "rbHalfYearly";
            this.rbHalfYearly.Size = new System.Drawing.Size(76, 17);
            this.rbHalfYearly.TabIndex = 10;
            this.rbHalfYearly.TabStop = true;
            this.rbHalfYearly.Text = "Half Yearly";
            this.rbHalfYearly.UseVisualStyleBackColor = true;
            this.rbHalfYearly.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rbYearly_KeyPress);
            // 
            // rbQuarterly
            // 
            this.rbQuarterly.AutoSize = true;
            this.rbQuarterly.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbQuarterly.Location = new System.Drawing.Point(13, 42);
            this.rbQuarterly.Name = "rbQuarterly";
            this.rbQuarterly.Size = new System.Drawing.Size(67, 17);
            this.rbQuarterly.TabIndex = 10;
            this.rbQuarterly.TabStop = true;
            this.rbQuarterly.Text = "Quarterly";
            this.rbQuarterly.UseVisualStyleBackColor = true;
            this.rbQuarterly.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rbYearly_KeyPress);
            // 
            // cmbLiabilitiesName
            // 
            this.cmbLiabilitiesName.BackColor = System.Drawing.SystemColors.Window;
            this.cmbLiabilitiesName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbLiabilitiesName.DropDownWidth = 17;
            this.cmbLiabilitiesName.Font = new System.Drawing.Font("Verdana", 9F);
            this.cmbLiabilitiesName.Location = new System.Drawing.Point(110, 65);
            this.cmbLiabilitiesName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbLiabilitiesName.Name = "cmbLiabilitiesName";
            this.cmbLiabilitiesName.Size = new System.Drawing.Size(208, 23);
            this.cmbLiabilitiesName.TabIndex = 82;
            this.cmbLiabilitiesName.ViewColumn = 0;
            this.cmbLiabilitiesName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbLiabilitiesName_KeyPress);
            this.cmbLiabilitiesName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbLiabilitiesName_KeyDown);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(1, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(598, 23);
            this.label9.TabIndex = 9;
            this.label9.Text = "Define Liabilities";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.Black;
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.Location = new System.Drawing.Point(498, 116);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(96, 25);
            this.btnClear.TabIndex = 16;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // dtpSettledDate
            // 
            this.dtpSettledDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpSettledDate.Location = new System.Drawing.Point(110, 41);
            this.dtpSettledDate.Name = "dtpSettledDate";
            this.dtpSettledDate.Size = new System.Drawing.Size(119, 20);
            this.dtpSettledDate.TabIndex = 15;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(6, 91);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(87, 20);
            this.label12.TabIndex = 14;
            this.label12.Text = "Amount";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 20);
            this.label1.TabIndex = 14;
            this.label1.Text = "Remarks";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 66);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(87, 20);
            this.label10.TabIndex = 14;
            this.label10.Text = "Liability Name";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 20);
            this.label5.TabIndex = 14;
            this.label5.Text = "Date";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtLiabilitiesName
            // 
            this.txtLiabilitiesName.Location = new System.Drawing.Point(9, 8);
            this.txtLiabilitiesName.Name = "txtLiabilitiesName";
            this.txtLiabilitiesName.Size = new System.Drawing.Size(153, 20);
            this.txtLiabilitiesName.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnUpdate);
            this.groupBox2.Controls.Add(this.btnView);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.dgvPaybleExpense);
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(4, 153);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(599, 307);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.label8.ForeColor = System.Drawing.Color.GreenYellow;
            this.label8.Location = new System.Drawing.Point(527, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(13, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.label7.ForeColor = System.Drawing.Color.GreenYellow;
            this.label7.Location = new System.Drawing.Point(484, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Count :";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(7, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(587, 23);
            this.label6.TabIndex = 6;
            this.label6.Text = "Payble Liabilities";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridFilterExtender1
            // 
            this.dataGridFilterExtender1.DataGridView = this.dgvPaybleExpense;
            defaultGridFilterFactory1.CreateDistinctGridFilters = false;
            defaultGridFilterFactory1.DefaultGridFilterType = typeof(GridViewExtensions.GridFilters.TextGridFilter);
            defaultGridFilterFactory1.DefaultShowDateInBetweenOperator = false;
            defaultGridFilterFactory1.DefaultShowNumericInBetweenOperator = false;
            defaultGridFilterFactory1.HandleEnumerationTypes = true;
            defaultGridFilterFactory1.MaximumDistinctValues = 20;
            this.dataGridFilterExtender1.FilterFactory = defaultGridFilterFactory1;
            // 
            // frmPreDefineAmountOfLiabilities
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(608, 467);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPreDefineAmountOfLiabilities";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Liabilities Entry Form";
            this.Load += new System.EventHandler(this.frmPreDefineAmountOfLiabilities_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaybleExpense)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFilterExtender1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgvPaybleExpense;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.RadioButton rbMonthly;
        private System.Windows.Forms.RadioButton rbYearly;
        private System.Windows.Forms.TextBox txtPaymentAmount;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtLiabilitiesName;
        private System.Windows.Forms.DateTimePicker dtpSettledDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label9;
        private URT.ComboBox.ColumnCombo cmbLiabilitiesName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RadioButton rbQuarterly;
        private System.Windows.Forms.RadioButton rbHalfYearly;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private GridViewExtensions.DataGridFilterExtender dataGridFilterExtender1;
    }
}