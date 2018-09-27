namespace StockbrokerProNewArch
{
    partial class frmNoDepreciation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNoDepreciation));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory defaultGridFilterFactory1 = new GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDeprciation = new System.Windows.Forms.TextBox();
            this.ddlCatagory = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnAddCatagory = new System.Windows.Forms.Button();
            this.lblDays = new System.Windows.Forms.Label();
            this.ddlAssetList = new System.Windows.Forms.ComboBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtSalvageValue = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPurchasePrice = new System.Windows.Forms.TextBox();
            this.dtpServicesDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpPurchaseDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvAssetInfo = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblDepriciationAmount = new System.Windows.Forms.Label();
            this.lblSalaveAmount = new System.Windows.Forms.Label();
            this.lblPurposeAmount = new System.Windows.Forms.Label();
            this.lblTotalRecord = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.dataGridFilterExtender1 = new GridViewExtensions.DataGridFilterExtender(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssetInfo)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFilterExtender1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtDeprciation);
            this.groupBox1.Controls.Add(this.ddlCatagory);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.btnAddCatagory);
            this.groupBox1.Controls.Add(this.lblDays);
            this.groupBox1.Controls.Add(this.ddlAssetList);
            this.groupBox1.Controls.Add(this.btnRefresh);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.txtSalvageValue);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtPurchasePrice);
            this.groupBox1.Controls.Add(this.dtpServicesDate);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dtpPurchaseDate);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtQuantity);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(11, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(637, 175);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fixed Asset Information";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(531, 109);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(20, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "%";
            // 
            // txtDeprciation
            // 
            this.txtDeprciation.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDeprciation.Location = new System.Drawing.Point(461, 104);
            this.txtDeprciation.Name = "txtDeprciation";
            this.txtDeprciation.Size = new System.Drawing.Size(64, 21);
            this.txtDeprciation.TabIndex = 8;
            this.txtDeprciation.Text = "10";
            this.txtDeprciation.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDeprciation.TextChanged += new System.EventHandler(this.txtDeprciation_TextChanged);
            // 
            // ddlCatagory
            // 
            this.ddlCatagory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlCatagory.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlCatagory.FormattingEnabled = true;
            this.ddlCatagory.Location = new System.Drawing.Point(116, 24);
            this.ddlCatagory.Name = "ddlCatagory";
            this.ddlCatagory.Size = new System.Drawing.Size(174, 21);
            this.ddlCatagory.TabIndex = 1;
            this.ddlCatagory.SelectedIndexChanged += new System.EventHandler(this.ddlCatagory_SelectedIndexChanged);
            this.ddlCatagory.SelectedValueChanged += new System.EventHandler(this.ddlCatagory_SelectedValueChanged);
            this.ddlCatagory.TextChanged += new System.EventHandler(this.ddlCatagory_TextChanged);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.DimGray;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.ForeColor = System.Drawing.SystemColors.Window;
            this.label9.Location = new System.Drawing.Point(15, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 20);
            this.label9.TabIndex = 19;
            this.label9.Text = "Category";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnAddCatagory
            // 
            this.btnAddCatagory.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCatagory.Location = new System.Drawing.Point(296, 23);
            this.btnAddCatagory.Name = "btnAddCatagory";
            this.btnAddCatagory.Size = new System.Drawing.Size(31, 23);
            this.btnAddCatagory.TabIndex = 18;
            this.btnAddCatagory.Text = "0";
            this.btnAddCatagory.UseVisualStyleBackColor = true;
            this.btnAddCatagory.Click += new System.EventHandler(this.btnAddCatagory_Click);
            // 
            // lblDays
            // 
            this.lblDays.BackColor = System.Drawing.SystemColors.Window;
            this.lblDays.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDays.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDays.Location = new System.Drawing.Point(555, 105);
            this.lblDays.Name = "lblDays";
            this.lblDays.Size = new System.Drawing.Size(69, 20);
            this.lblDays.TabIndex = 16;
            this.lblDays.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ddlAssetList
            // 
            this.ddlAssetList.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlAssetList.FormattingEnabled = true;
            this.ddlAssetList.Location = new System.Drawing.Point(116, 52);
            this.ddlAssetList.Name = "ddlAssetList";
            this.ddlAssetList.Size = new System.Drawing.Size(174, 21);
            this.ddlAssetList.TabIndex = 2;
            this.ddlAssetList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ddlAssetList_KeyDown);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.Transparent;
            this.btnRefresh.ForeColor = System.Drawing.Color.Black;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.Location = new System.Drawing.Point(206, 137);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 9;
            this.btnRefresh.Text = "   Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Transparent;
            this.btnAdd.ForeColor = System.Drawing.Color.Black;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(125, 137);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "   Save";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtSalvageValue
            // 
            this.txtSalvageValue.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalvageValue.Location = new System.Drawing.Point(461, 79);
            this.txtSalvageValue.Name = "txtSalvageValue";
            this.txtSalvageValue.Size = new System.Drawing.Size(163, 21);
            this.txtSalvageValue.TabIndex = 7;
            this.txtSalvageValue.Text = "0.00";
            this.txtSalvageValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSalvageValue.TextChanged += new System.EventHandler(this.txtDeprciation_TextChanged);
            this.txtSalvageValue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSalvageValue_KeyDown);
            this.txtSalvageValue.Validating += new System.ComponentModel.CancelEventHandler(this.txtSalvageValue_Validating);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.DimGray;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(355, 105);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 20);
            this.label7.TabIndex = 4;
            this.label7.Text = "Depreciation";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.DimGray;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(355, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 20);
            this.label6.TabIndex = 8;
            this.label6.Text = "Salvage Value";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPurchasePrice
            // 
            this.txtPurchasePrice.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPurchasePrice.Location = new System.Drawing.Point(461, 52);
            this.txtPurchasePrice.Name = "txtPurchasePrice";
            this.txtPurchasePrice.Size = new System.Drawing.Size(163, 21);
            this.txtPurchasePrice.TabIndex = 6;
            this.txtPurchasePrice.Text = "0.00";
            this.txtPurchasePrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPurchasePrice.TextChanged += new System.EventHandler(this.txtDeprciation_TextChanged);
            this.txtPurchasePrice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPurchasePrice_KeyDown);
            this.txtPurchasePrice.Validating += new System.ComponentModel.CancelEventHandler(this.txtPurchasePrice_Validating);
            // 
            // dtpServicesDate
            // 
            this.dtpServicesDate.CalendarFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpServicesDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpServicesDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpServicesDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpServicesDate.Location = new System.Drawing.Point(116, 106);
            this.dtpServicesDate.Name = "dtpServicesDate";
            this.dtpServicesDate.Size = new System.Drawing.Size(174, 21);
            this.dtpServicesDate.TabIndex = 4;
            this.dtpServicesDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpServicesDate_KeyDown);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.DimGray;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(355, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Purchase Price";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpPurchaseDate
            // 
            this.dtpPurchaseDate.CalendarFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpPurchaseDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpPurchaseDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpPurchaseDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPurchaseDate.Location = new System.Drawing.Point(116, 80);
            this.dtpPurchaseDate.Name = "dtpPurchaseDate";
            this.dtpPurchaseDate.Size = new System.Drawing.Size(174, 21);
            this.dtpPurchaseDate.TabIndex = 3;
            this.dtpPurchaseDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpPurchaseDate_KeyDown);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.DimGray;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.ForeColor = System.Drawing.SystemColors.Window;
            this.label4.Location = new System.Drawing.Point(15, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Services Date";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantity.Location = new System.Drawing.Point(461, 26);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(163, 21);
            this.txtQuantity.TabIndex = 5;
            this.txtQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQuantity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQuantity_KeyDown);
            this.txtQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantity_KeyPress);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.DimGray;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.ForeColor = System.Drawing.SystemColors.Window;
            this.label3.Location = new System.Drawing.Point(15, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Purchase Date";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.DimGray;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(355, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Quantity";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DimGray;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(15, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Asset Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvAssetInfo);
            this.groupBox3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.Black;
            this.groupBox3.Location = new System.Drawing.Point(11, 188);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(637, 222);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Highlight Information";
            // 
            // dgvAssetInfo
            // 
            this.dgvAssetInfo.AllowUserToAddRows = false;
            this.dgvAssetInfo.AllowUserToDeleteRows = false;
            this.dgvAssetInfo.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Blue;
            this.dgvAssetInfo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAssetInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAssetInfo.BackgroundColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAssetInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAssetInfo.ColumnHeadersHeight = 42;
            this.dgvAssetInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAssetInfo.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvAssetInfo.EnableHeadersVisualStyles = false;
            this.dgvAssetInfo.GridColor = System.Drawing.Color.LightGray;
            this.dgvAssetInfo.Location = new System.Drawing.Point(3, 35);
            this.dgvAssetInfo.MultiSelect = false;
            this.dgvAssetInfo.Name = "dgvAssetInfo";
            this.dgvAssetInfo.ReadOnly = true;
            this.dgvAssetInfo.RowHeadersVisible = false;
            this.dgvAssetInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAssetInfo.Size = new System.Drawing.Size(631, 178);
            this.dgvAssetInfo.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.SlateGray;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(14, 463);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(632, 1);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblDepriciationAmount);
            this.groupBox2.Controls.Add(this.lblSalaveAmount);
            this.groupBox2.Controls.Add(this.lblPurposeAmount);
            this.groupBox2.Controls.Add(this.lblTotalRecord);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(17, 410);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(631, 43);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Summary Information";
            // 
            // lblDepriciationAmount
            // 
            this.lblDepriciationAmount.AutoSize = true;
            this.lblDepriciationAmount.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepriciationAmount.ForeColor = System.Drawing.Color.Black;
            this.lblDepriciationAmount.Location = new System.Drawing.Point(449, 20);
            this.lblDepriciationAmount.Name = "lblDepriciationAmount";
            this.lblDepriciationAmount.Size = new System.Drawing.Size(35, 13);
            this.lblDepriciationAmount.TabIndex = 14;
            this.lblDepriciationAmount.Text = "label8";
            // 
            // lblSalaveAmount
            // 
            this.lblSalaveAmount.AutoSize = true;
            this.lblSalaveAmount.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalaveAmount.ForeColor = System.Drawing.Color.Black;
            this.lblSalaveAmount.Location = new System.Drawing.Point(292, 20);
            this.lblSalaveAmount.Name = "lblSalaveAmount";
            this.lblSalaveAmount.Size = new System.Drawing.Size(35, 13);
            this.lblSalaveAmount.TabIndex = 2;
            this.lblSalaveAmount.Text = "label8";
            // 
            // lblPurposeAmount
            // 
            this.lblPurposeAmount.AutoSize = true;
            this.lblPurposeAmount.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPurposeAmount.ForeColor = System.Drawing.Color.Black;
            this.lblPurposeAmount.Location = new System.Drawing.Point(117, 20);
            this.lblPurposeAmount.Name = "lblPurposeAmount";
            this.lblPurposeAmount.Size = new System.Drawing.Size(35, 13);
            this.lblPurposeAmount.TabIndex = 1;
            this.lblPurposeAmount.Text = "label8";
            // 
            // lblTotalRecord
            // 
            this.lblTotalRecord.AutoSize = true;
            this.lblTotalRecord.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRecord.ForeColor = System.Drawing.Color.Black;
            this.lblTotalRecord.Location = new System.Drawing.Point(14, 20);
            this.lblTotalRecord.Name = "lblTotalRecord";
            this.lblTotalRecord.Size = new System.Drawing.Size(35, 13);
            this.lblTotalRecord.TabIndex = 0;
            this.lblTotalRecord.Text = "label8";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(573, 471);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "  Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dataGridFilterExtender1
            // 
            this.dataGridFilterExtender1.DataGridView = this.dgvAssetInfo;
            defaultGridFilterFactory1.CreateDistinctGridFilters = false;
            defaultGridFilterFactory1.DefaultGridFilterType = typeof(GridViewExtensions.GridFilters.TextGridFilter);
            defaultGridFilterFactory1.DefaultShowDateInBetweenOperator = false;
            defaultGridFilterFactory1.DefaultShowNumericInBetweenOperator = false;
            defaultGridFilterFactory1.HandleEnumerationTypes = true;
            defaultGridFilterFactory1.MaximumDistinctValues = 20;
            this.dataGridFilterExtender1.FilterFactory = defaultGridFilterFactory1;
            // 
            // frmNoDepreciation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 500);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frmNoDepreciation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add New Capex Information";
            this.Load += new System.EventHandler(this.frmNoDepreciation_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssetInfo)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFilterExtender1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpServicesDate;
        private System.Windows.Forms.DateTimePicker dtpPurchaseDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSalvageValue;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPurchasePrice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvAssetInfo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ComboBox ddlAssetList;
        private System.Windows.Forms.Label lblDays;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblDepriciationAmount;
        private System.Windows.Forms.Label lblSalaveAmount;
        private System.Windows.Forms.Label lblPurposeAmount;
        private System.Windows.Forms.Label lblTotalRecord;
        private System.Windows.Forms.Button btnAddCatagory;
        private System.Windows.Forms.ComboBox ddlCatagory;
        private System.Windows.Forms.Label label9;
        private GridViewExtensions.DataGridFilterExtender dataGridFilterExtender1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtDeprciation;
    }
}