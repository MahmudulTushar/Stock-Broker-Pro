namespace StockbrokerProNewArch
{
    partial class frmAssetConfirmation
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
            this.dgvUnSettledAsset = new System.Windows.Forms.DataGridView();
            this.label18 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtExtra = new System.Windows.Forms.TextBox();
            this.cmbCatagory = new System.Windows.Forms.ComboBox();
            this.cmbSubCategory = new System.Windows.Forms.ComboBox();
            this.cmbAssetType = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lblCancel = new System.Windows.Forms.Label();
            this.txtLifeTime = new System.Windows.Forms.TextBox();
            this.lblSave = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.txtAssetType = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.txtDepAmount = new System.Windows.Forms.TextBox();
            this.txtSalvageValue = new System.Windows.Forms.TextBox();
            this.txtSalvageRate = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.txtCost = new System.Windows.Forms.TextBox();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.txtCatagory = new System.Windows.Forms.TextBox();
            this.txtAssetName = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.dtpPurchaseDate = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label23 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnSettledAsset)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvUnSettledAsset
            // 
            this.dgvUnSettledAsset.AllowUserToAddRows = false;
            this.dgvUnSettledAsset.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUnSettledAsset.Location = new System.Drawing.Point(6, 19);
            this.dgvUnSettledAsset.Name = "dgvUnSettledAsset";
            this.dgvUnSettledAsset.ReadOnly = true;
            this.dgvUnSettledAsset.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUnSettledAsset.Size = new System.Drawing.Size(731, 299);
            this.dgvUnSettledAsset.TabIndex = 0;
            this.dgvUnSettledAsset.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUnSettledAsset_CellClick);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Lucida Calligraphy", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label18.Location = new System.Drawing.Point(215, 11);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(327, 31);
            this.label18.TabIndex = 19;
            this.label18.Text = "Asset Settlement Form";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtExtra);
            this.groupBox1.Controls.Add(this.cmbCatagory);
            this.groupBox1.Controls.Add(this.cmbSubCategory);
            this.groupBox1.Controls.Add(this.cmbAssetType);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.lblCancel);
            this.groupBox1.Controls.Add(this.txtLifeTime);
            this.groupBox1.Controls.Add(this.lblSave);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.label26);
            this.groupBox1.Controls.Add(this.label27);
            this.groupBox1.Controls.Add(this.txtAssetType);
            this.groupBox1.Controls.Add(this.label25);
            this.groupBox1.Controls.Add(this.label24);
            this.groupBox1.Controls.Add(this.txtDepAmount);
            this.groupBox1.Controls.Add(this.txtSalvageValue);
            this.groupBox1.Controls.Add(this.txtSalvageRate);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.txtCost);
            this.groupBox1.Controls.Add(this.txtRate);
            this.groupBox1.Controls.Add(this.txtQuantity);
            this.groupBox1.Controls.Add(this.txtCatagory);
            this.groupBox1.Controls.Add(this.txtAssetName);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.dtpPurchaseDate);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 76);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(743, 186);
            this.groupBox1.TabIndex = 41;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Asset Information";
            // 
            // txtExtra
            // 
            this.txtExtra.Location = new System.Drawing.Point(325, 156);
            this.txtExtra.Name = "txtExtra";
            this.txtExtra.Size = new System.Drawing.Size(142, 20);
            this.txtExtra.TabIndex = 86;
            // 
            // cmbCatagory
            // 
            this.cmbCatagory.FormattingEnabled = true;
            this.cmbCatagory.Location = new System.Drawing.Point(316, 156);
            this.cmbCatagory.Name = "cmbCatagory";
            this.cmbCatagory.Size = new System.Drawing.Size(142, 21);
            this.cmbCatagory.TabIndex = 85;
            // 
            // cmbSubCategory
            // 
            this.cmbSubCategory.FormattingEnabled = true;
            this.cmbSubCategory.Location = new System.Drawing.Point(306, 156);
            this.cmbSubCategory.Name = "cmbSubCategory";
            this.cmbSubCategory.Size = new System.Drawing.Size(142, 21);
            this.cmbSubCategory.TabIndex = 84;
            // 
            // cmbAssetType
            // 
            this.cmbAssetType.FormattingEnabled = true;
            this.cmbAssetType.Location = new System.Drawing.Point(297, 156);
            this.cmbAssetType.Name = "cmbAssetType";
            this.cmbAssetType.Size = new System.Drawing.Size(142, 21);
            this.cmbAssetType.TabIndex = 83;
            this.cmbAssetType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbAssetType_KeyPress);
            this.cmbAssetType.TextChanged += new System.EventHandler(this.cmbAssetType_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label9.Location = new System.Drawing.Point(649, 123);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 15);
            this.label9.TabIndex = 82;
            this.label9.Text = "Per year";
            // 
            // lblCancel
            // 
            this.lblCancel.AutoSize = true;
            this.lblCancel.Font = new System.Drawing.Font("Matura MT Script Capitals", 15.75F, System.Drawing.FontStyle.Italic);
            this.lblCancel.ForeColor = System.Drawing.Color.Navy;
            this.lblCancel.Location = new System.Drawing.Point(625, 149);
            this.lblCancel.Name = "lblCancel";
            this.lblCancel.Size = new System.Drawing.Size(75, 28);
            this.lblCancel.TabIndex = 81;
            this.lblCancel.Text = "Cancel";
            this.lblCancel.MouseLeave += new System.EventHandler(this.lblCancel_MouseLeave);
            this.lblCancel.Click += new System.EventHandler(this.lblCancel_Click);
            this.lblCancel.MouseHover += new System.EventHandler(this.lblCancel_MouseHover);
            // 
            // txtLifeTime
            // 
            this.txtLifeTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLifeTime.Location = new System.Drawing.Point(501, 97);
            this.txtLifeTime.Name = "txtLifeTime";
            this.txtLifeTime.Size = new System.Drawing.Size(142, 20);
            this.txtLifeTime.TabIndex = 69;
            this.txtLifeTime.TextChanged += new System.EventHandler(this.txtLifeTime_TextChanged);
            this.txtLifeTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLifeTime_KeyPress);
            // 
            // lblSave
            // 
            this.lblSave.AutoSize = true;
            this.lblSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(175)))), ((int)(((byte)(207)))));
            this.lblSave.Font = new System.Drawing.Font("Matura MT Script Capitals", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSave.ForeColor = System.Drawing.Color.Navy;
            this.lblSave.Location = new System.Drawing.Point(547, 149);
            this.lblSave.Name = "lblSave";
            this.lblSave.Size = new System.Drawing.Size(69, 28);
            this.lblSave.TabIndex = 80;
            this.lblSave.Text = "Settle";
            this.lblSave.MouseLeave += new System.EventHandler(this.lblSave_MouseLeave);
            this.lblSave.Click += new System.EventHandler(this.lblSave_Click);
            this.lblSave.MouseHover += new System.EventHandler(this.lblSave_MouseHover);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(419, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 15);
            this.label7.TabIndex = 47;
            this.label7.Text = "Life Time";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(484, 99);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(11, 15);
            this.label19.TabIndex = 64;
            this.label19.Text = ":";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label26.Location = new System.Drawing.Point(649, 99);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(36, 15);
            this.label26.TabIndex = 77;
            this.label26.Text = "Years";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label27.Location = new System.Drawing.Point(649, 49);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(18, 15);
            this.label27.TabIndex = 78;
            this.label27.Text = "%";
            // 
            // txtAssetType
            // 
            this.txtAssetType.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtAssetType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAssetType.Location = new System.Drawing.Point(149, 47);
            this.txtAssetType.Name = "txtAssetType";
            this.txtAssetType.ReadOnly = true;
            this.txtAssetType.Size = new System.Drawing.Size(142, 20);
            this.txtAssetType.TabIndex = 76;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(128, 49);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(11, 15);
            this.label25.TabIndex = 75;
            this.label25.Text = ":";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(59, 49);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(63, 15);
            this.label24.TabIndex = 74;
            this.label24.Text = "Asset Type";
            // 
            // txtDepAmount
            // 
            this.txtDepAmount.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtDepAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDepAmount.Location = new System.Drawing.Point(501, 121);
            this.txtDepAmount.Name = "txtDepAmount";
            this.txtDepAmount.ReadOnly = true;
            this.txtDepAmount.Size = new System.Drawing.Size(142, 20);
            this.txtDepAmount.TabIndex = 73;
            // 
            // txtSalvageValue
            // 
            this.txtSalvageValue.BackColor = System.Drawing.SystemColors.Window;
            this.txtSalvageValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalvageValue.Location = new System.Drawing.Point(501, 72);
            this.txtSalvageValue.Name = "txtSalvageValue";
            this.txtSalvageValue.Size = new System.Drawing.Size(142, 20);
            this.txtSalvageValue.TabIndex = 71;
            this.txtSalvageValue.TextChanged += new System.EventHandler(this.txtSalvageValue_TextChanged);
            // 
            // txtSalvageRate
            // 
            this.txtSalvageRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalvageRate.Location = new System.Drawing.Point(501, 47);
            this.txtSalvageRate.Name = "txtSalvageRate";
            this.txtSalvageRate.Size = new System.Drawing.Size(142, 20);
            this.txtSalvageRate.TabIndex = 70;
            this.txtSalvageRate.TextChanged += new System.EventHandler(this.txtSalvageRate_TextChanged);
            this.txtSalvageRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSalvageRate_KeyPress);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(484, 124);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(11, 15);
            this.label22.TabIndex = 67;
            this.label22.Text = ":";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(484, 74);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(11, 15);
            this.label21.TabIndex = 66;
            this.label21.Text = ":";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(397, 74);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(81, 15);
            this.label20.TabIndex = 65;
            this.label20.Text = "Salvage Value";
            // 
            // txtCost
            // 
            this.txtCost.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCost.Location = new System.Drawing.Point(501, 22);
            this.txtCost.Name = "txtCost";
            this.txtCost.ReadOnly = true;
            this.txtCost.Size = new System.Drawing.Size(142, 20);
            this.txtCost.TabIndex = 63;
            // 
            // txtRate
            // 
            this.txtRate.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRate.Location = new System.Drawing.Point(149, 147);
            this.txtRate.Name = "txtRate";
            this.txtRate.ReadOnly = true;
            this.txtRate.Size = new System.Drawing.Size(142, 20);
            this.txtRate.TabIndex = 62;
            this.txtRate.TextChanged += new System.EventHandler(this.txtRate_TextChanged);
            // 
            // txtQuantity
            // 
            this.txtQuantity.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantity.Location = new System.Drawing.Point(149, 121);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.ReadOnly = true;
            this.txtQuantity.Size = new System.Drawing.Size(142, 20);
            this.txtQuantity.TabIndex = 61;
            this.txtQuantity.TextChanged += new System.EventHandler(this.txtQuantity_TextChanged);
            this.txtQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantity_KeyPress);
            // 
            // txtCatagory
            // 
            this.txtCatagory.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtCatagory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCatagory.Location = new System.Drawing.Point(149, 96);
            this.txtCatagory.Name = "txtCatagory";
            this.txtCatagory.ReadOnly = true;
            this.txtCatagory.Size = new System.Drawing.Size(142, 20);
            this.txtCatagory.TabIndex = 60;
            // 
            // txtAssetName
            // 
            this.txtAssetName.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtAssetName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAssetName.Location = new System.Drawing.Point(149, 72);
            this.txtAssetName.Name = "txtAssetName";
            this.txtAssetName.ReadOnly = true;
            this.txtAssetName.Size = new System.Drawing.Size(142, 20);
            this.txtAssetName.TabIndex = 59;
            this.txtAssetName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAssetName_KeyPress);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(128, 123);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(11, 15);
            this.label17.TabIndex = 58;
            this.label17.Text = ":";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(484, 49);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(11, 15);
            this.label16.TabIndex = 57;
            this.label16.Text = ":";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(128, 149);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(11, 15);
            this.label15.TabIndex = 56;
            this.label15.Text = ":";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(484, 24);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(11, 15);
            this.label14.TabIndex = 55;
            this.label14.Text = ":";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(128, 98);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(11, 15);
            this.label13.TabIndex = 54;
            this.label13.Text = ":";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(128, 74);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(11, 15);
            this.label12.TabIndex = 53;
            this.label12.Text = ":";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(128, 24);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(11, 15);
            this.label11.TabIndex = 52;
            this.label11.Text = ":";
            // 
            // dtpPurchaseDate
            // 
            this.dtpPurchaseDate.CalendarTitleBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dtpPurchaseDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpPurchaseDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPurchaseDate.Location = new System.Drawing.Point(149, 22);
            this.dtpPurchaseDate.Name = "dtpPurchaseDate";
            this.dtpPurchaseDate.Size = new System.Drawing.Size(142, 20);
            this.dtpPurchaseDate.TabIndex = 51;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(403, 123);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 15);
            this.label10.TabIndex = 50;
            this.label10.Text = "Depreciation";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(403, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 15);
            this.label8.TabIndex = 48;
            this.label8.Text = "Salvage Rate";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(447, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 15);
            this.label6.TabIndex = 46;
            this.label6.Text = "Cost";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(91, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 15);
            this.label5.TabIndex = 45;
            this.label5.Text = "Rate";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(67, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 15);
            this.label4.TabIndex = 44;
            this.label4.Text = "Quantity";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(67, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 15);
            this.label3.TabIndex = 43;
            this.label3.Text = "Catagory";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(39, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 15);
            this.label2.TabIndex = 42;
            this.label2.Text = "Purchase Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(53, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 15);
            this.label1.TabIndex = 41;
            this.label1.Text = "Asset Name";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvUnSettledAsset);
            this.groupBox2.Location = new System.Drawing.Point(12, 268);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(743, 329);
            this.groupBox2.TabIndex = 42;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Unsettled Data";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.Navy;
            this.label23.Location = new System.Drawing.Point(611, 57);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(86, 16);
            this.label23.TabIndex = 83;
            this.label23.Text = "Asset Entry";
            this.label23.MouseLeave += new System.EventHandler(this.label23_MouseLeave);
            this.label23.Click += new System.EventHandler(this.label23_Click);
            this.label23.MouseHover += new System.EventHandler(this.label23_MouseHover);
            // 
            // frmAssetConfirmation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(175)))), ((int)(((byte)(207)))));
            this.ClientSize = new System.Drawing.Size(767, 606);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label18);
            this.Name = "frmAssetConfirmation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asset Settlement";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmAssetConfirmation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnSettledAsset)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUnSettledAsset;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txtDepAmount;
        private System.Windows.Forms.TextBox txtSalvageValue;
        private System.Windows.Forms.TextBox txtSalvageRate;
        private System.Windows.Forms.TextBox txtLifeTime;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtCost;
        private System.Windows.Forms.TextBox txtRate;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.TextBox txtCatagory;
        private System.Windows.Forms.TextBox txtAssetName;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dtpPurchaseDate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtAssetType;
        private System.Windows.Forms.ComboBox cmbAssetType;
        private System.Windows.Forms.ComboBox cmbSubCategory;
        private System.Windows.Forms.ComboBox cmbCatagory;
        private System.Windows.Forms.Label lblCancel;
        private System.Windows.Forms.Label lblSave;
        private System.Windows.Forms.TextBox txtExtra;
    }
}