namespace StockbrokerProNewArch
{
    partial class Frm_HeadCodeEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_HeadCodeEntry));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbBasicHead = new System.Windows.Forms.TabPage();
            this.btnSaveBasicHead = new System.Windows.Forms.Button();
            this.dgvHeadCodeEntry = new System.Windows.Forms.DataGridView();
            this.cmbHeadType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtHeadName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbSubHead = new System.Windows.Forms.TabPage();
            this.txtSubHeadDesc = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbHeadTypeForSub = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSaveSubHead = new System.Windows.Forms.Button();
            this.dgvSubHeadName = new System.Windows.Forms.DataGridView();
            this.cmbbasicHeadName = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSubHeadName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tbBasicHead.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHeadCodeEntry)).BeginInit();
            this.tbSubHead.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubHeadName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbBasicHead);
            this.tabControl1.Controls.Add(this.tbSubHead);
            this.tabControl1.Location = new System.Drawing.Point(13, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(455, 392);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tbBasicHead
            // 
            this.tbBasicHead.BackColor = System.Drawing.SystemColors.Control;
            this.tbBasicHead.Controls.Add(this.btnSaveBasicHead);
            this.tbBasicHead.Controls.Add(this.dgvHeadCodeEntry);
            this.tbBasicHead.Controls.Add(this.cmbHeadType);
            this.tbBasicHead.Controls.Add(this.label2);
            this.tbBasicHead.Controls.Add(this.txtHeadName);
            this.tbBasicHead.Controls.Add(this.label1);
            this.tbBasicHead.Location = new System.Drawing.Point(4, 22);
            this.tbBasicHead.Name = "tbBasicHead";
            this.tbBasicHead.Padding = new System.Windows.Forms.Padding(3);
            this.tbBasicHead.Size = new System.Drawing.Size(447, 366);
            this.tbBasicHead.TabIndex = 0;
            this.tbBasicHead.Text = "Basic Head Entry";
            // 
            // btnSaveBasicHead
            // 
            this.btnSaveBasicHead.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveBasicHead.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveBasicHead.Image")));
            this.btnSaveBasicHead.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveBasicHead.Location = new System.Drawing.Point(354, 334);
            this.btnSaveBasicHead.Name = "btnSaveBasicHead";
            this.btnSaveBasicHead.Size = new System.Drawing.Size(87, 23);
            this.btnSaveBasicHead.TabIndex = 7;
            this.btnSaveBasicHead.Text = "   Save";
            this.btnSaveBasicHead.UseVisualStyleBackColor = true;
            this.btnSaveBasicHead.Click += new System.EventHandler(this.btnSaveBasicHead_Click);
            // 
            // dgvHeadCodeEntry
            // 
            this.dgvHeadCodeEntry.AllowUserToAddRows = false;
            this.dgvHeadCodeEntry.AllowUserToDeleteRows = false;
            this.dgvHeadCodeEntry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHeadCodeEntry.Location = new System.Drawing.Point(20, 73);
            this.dgvHeadCodeEntry.Name = "dgvHeadCodeEntry";
            this.dgvHeadCodeEntry.ReadOnly = true;
            this.dgvHeadCodeEntry.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHeadCodeEntry.Size = new System.Drawing.Size(421, 255);
            this.dgvHeadCodeEntry.TabIndex = 6;
            // 
            // cmbHeadType
            // 
            this.cmbHeadType.FormattingEnabled = true;
            this.cmbHeadType.Items.AddRange(new object[] {
            "Asset",
            "Expense",
            "Income",
            "Liability"});
            this.cmbHeadType.Location = new System.Drawing.Point(126, 14);
            this.cmbHeadType.Name = "cmbHeadType";
            this.cmbHeadType.Size = new System.Drawing.Size(140, 21);
            this.cmbHeadType.TabIndex = 5;
            this.cmbHeadType.SelectedIndexChanged += new System.EventHandler(this.cmbHeadType_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label2.Location = new System.Drawing.Point(20, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Head Type :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtHeadName
            // 
            this.txtHeadName.Location = new System.Drawing.Point(127, 44);
            this.txtHeadName.Name = "txtHeadName";
            this.txtHeadName.Size = new System.Drawing.Size(223, 20);
            this.txtHeadName.TabIndex = 3;
            this.txtHeadName.TextChanged += new System.EventHandler(this.txtHeadName_TextChanged);
            this.txtHeadName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHeadName_KeyPress);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label1.Location = new System.Drawing.Point(20, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Basic Head Name :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbSubHead
            // 
            this.tbSubHead.BackColor = System.Drawing.SystemColors.Control;
            this.tbSubHead.Controls.Add(this.txtSubHeadDesc);
            this.tbSubHead.Controls.Add(this.label8);
            this.tbSubHead.Controls.Add(this.cmbHeadTypeForSub);
            this.tbSubHead.Controls.Add(this.label7);
            this.tbSubHead.Controls.Add(this.btnSaveSubHead);
            this.tbSubHead.Controls.Add(this.dgvSubHeadName);
            this.tbSubHead.Controls.Add(this.cmbbasicHeadName);
            this.tbSubHead.Controls.Add(this.label5);
            this.tbSubHead.Controls.Add(this.txtSubHeadName);
            this.tbSubHead.Controls.Add(this.label6);
            this.tbSubHead.Location = new System.Drawing.Point(4, 22);
            this.tbSubHead.Name = "tbSubHead";
            this.tbSubHead.Padding = new System.Windows.Forms.Padding(3);
            this.tbSubHead.Size = new System.Drawing.Size(447, 366);
            this.tbSubHead.TabIndex = 1;
            this.tbSubHead.Text = "Sub Head Entry";
            // 
            // txtSubHeadDesc
            // 
            this.txtSubHeadDesc.Location = new System.Drawing.Point(126, 81);
            this.txtSubHeadDesc.Name = "txtSubHeadDesc";
            this.txtSubHeadDesc.Size = new System.Drawing.Size(228, 20);
            this.txtSubHeadDesc.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label8.Location = new System.Drawing.Point(19, 82);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 20);
            this.label8.TabIndex = 19;
            this.label8.Text = "Description :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbHeadTypeForSub
            // 
            this.cmbHeadTypeForSub.FormattingEnabled = true;
            this.cmbHeadTypeForSub.Items.AddRange(new object[] {
            "Asset",
            "Expense",
            "Income",
            "Liability"});
            this.cmbHeadTypeForSub.Location = new System.Drawing.Point(126, 12);
            this.cmbHeadTypeForSub.Name = "cmbHeadTypeForSub";
            this.cmbHeadTypeForSub.Size = new System.Drawing.Size(127, 21);
            this.cmbHeadTypeForSub.TabIndex = 15;
            this.cmbHeadTypeForSub.SelectedIndexChanged += new System.EventHandler(this.cmbHeadTypeForSub_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label7.Location = new System.Drawing.Point(19, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 20);
            this.label7.TabIndex = 14;
            this.label7.Text = "Head Type :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSaveSubHead
            // 
            this.btnSaveSubHead.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveSubHead.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveSubHead.Image")));
            this.btnSaveSubHead.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveSubHead.Location = new System.Drawing.Point(343, 334);
            this.btnSaveSubHead.Name = "btnSaveSubHead";
            this.btnSaveSubHead.Size = new System.Drawing.Size(87, 23);
            this.btnSaveSubHead.TabIndex = 13;
            this.btnSaveSubHead.Text = "   Save";
            this.btnSaveSubHead.UseVisualStyleBackColor = true;
            this.btnSaveSubHead.Click += new System.EventHandler(this.btnSaveSubHead_Click);
            // 
            // dgvSubHeadName
            // 
            this.dgvSubHeadName.AllowUserToAddRows = false;
            this.dgvSubHeadName.AllowUserToDeleteRows = false;
            this.dgvSubHeadName.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSubHeadName.Location = new System.Drawing.Point(19, 107);
            this.dgvSubHeadName.Name = "dgvSubHeadName";
            this.dgvSubHeadName.ReadOnly = true;
            this.dgvSubHeadName.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSubHeadName.Size = new System.Drawing.Size(411, 221);
            this.dgvSubHeadName.TabIndex = 12;
            // 
            // cmbbasicHeadName
            // 
            this.cmbbasicHeadName.FormattingEnabled = true;
            this.cmbbasicHeadName.Items.AddRange(new object[] {
            "Asset",
            "Expense",
            "Income",
            "Liability"});
            this.cmbbasicHeadName.Location = new System.Drawing.Point(126, 35);
            this.cmbbasicHeadName.Name = "cmbbasicHeadName";
            this.cmbbasicHeadName.Size = new System.Drawing.Size(180, 21);
            this.cmbbasicHeadName.TabIndex = 11;
            this.cmbbasicHeadName.SelectedIndexChanged += new System.EventHandler(this.cmbbasicHeadName_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label5.Location = new System.Drawing.Point(19, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Basic Head Name :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSubHeadName
            // 
            this.txtSubHeadName.Location = new System.Drawing.Point(126, 58);
            this.txtSubHeadName.Name = "txtSubHeadName";
            this.txtSubHeadName.Size = new System.Drawing.Size(228, 20);
            this.txtSubHeadName.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label6.Location = new System.Drawing.Point(19, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 20);
            this.label6.TabIndex = 8;
            this.label6.Text = "Sub Head Name :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(263, 334);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "   Save";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(20, 73);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(330, 255);
            this.dataGridView1.TabIndex = 6;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Asset",
            "Expense",
            "Income",
            "Liability"});
            this.comboBox1.Location = new System.Drawing.Point(126, 14);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(140, 21);
            this.comboBox1.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label3.Location = new System.Drawing.Point(20, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Head Type :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(127, 44);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(223, 20);
            this.textBox1.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label4.Location = new System.Drawing.Point(20, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Head Name :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Frm_HeadCodeEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 413);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_HeadCodeEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Head Code Entry Form";
            this.Load += new System.EventHandler(this.Frm_HeadCodeEntry_Load);
            this.tabControl1.ResumeLayout(false);
            this.tbBasicHead.ResumeLayout(false);
            this.tbBasicHead.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHeadCodeEntry)).EndInit();
            this.tbSubHead.ResumeLayout(false);
            this.tbSubHead.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubHeadName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbBasicHead;
        private System.Windows.Forms.TabPage tbSubHead;
        private System.Windows.Forms.TextBox txtHeadName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbHeadType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvHeadCodeEntry;
        private System.Windows.Forms.Button btnSaveBasicHead;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnSaveSubHead;
        private System.Windows.Forms.DataGridView dgvSubHeadName;
        private System.Windows.Forms.ComboBox cmbbasicHeadName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSubHeadName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbHeadTypeForSub;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSubHeadDesc;
        private System.Windows.Forms.Label label8;
    }
}