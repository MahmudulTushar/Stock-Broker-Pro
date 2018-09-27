namespace StockbrokerProNewArch
{
    partial class frmAccountCloseRequest
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtClientID = new System.Windows.Forms.TextBox();
            this.ddlSearchBy = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtClientBalance = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtShareBalence = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtClientName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtClientBOID = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtClientCode = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.dtpRequestDate = new System.Windows.Forms.DateTimePicker();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtClientID);
            this.groupBox1.Controls.Add(this.ddlSearchBy);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(12, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(326, 156);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Client Information";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(231, 89);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(77, 41);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search Client";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(103, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(10, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = ":";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(103, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = ":";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.DimGray;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(18, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Client Code ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtClientID
            // 
            this.txtClientID.Location = new System.Drawing.Point(116, 59);
            this.txtClientID.Name = "txtClientID";
            this.txtClientID.Size = new System.Drawing.Size(192, 21);
            this.txtClientID.TabIndex = 2;
            // 
            // ddlSearchBy
            // 
            this.ddlSearchBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlSearchBy.FormattingEnabled = true;
            this.ddlSearchBy.Items.AddRange(new object[] {
            "Client Code",
            "BO ID"});
            this.ddlSearchBy.Location = new System.Drawing.Point(116, 33);
            this.ddlSearchBy.Name = "ddlSearchBy";
            this.ddlSearchBy.Size = new System.Drawing.Size(192, 21);
            this.ddlSearchBy.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DimGray;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(18, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search By ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.txtClientBalance);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.txtShareBalence);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.txtClientName);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtClientBOID);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtClientCode);
            this.panel1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(349, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(347, 151);
            this.panel1.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(129, 117);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(8, 13);
            this.label13.TabIndex = 10;
            this.label13.Text = ":";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(129, 92);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(8, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = ":";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.DimGray;
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(18, 113);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(106, 21);
            this.label14.TabIndex = 8;
            this.label14.Text = "Current Balance";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtClientBalance
            // 
            this.txtClientBalance.BackColor = System.Drawing.Color.LightGray;
            this.txtClientBalance.Location = new System.Drawing.Point(141, 113);
            this.txtClientBalance.Name = "txtClientBalance";
            this.txtClientBalance.Size = new System.Drawing.Size(192, 21);
            this.txtClientBalance.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(129, 67);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(8, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = ":";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.DimGray;
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(18, 88);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(106, 21);
            this.label12.TabIndex = 8;
            this.label12.Text = "Existing  Share ";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtShareBalence
            // 
            this.txtShareBalence.BackColor = System.Drawing.Color.LightGray;
            this.txtShareBalence.Location = new System.Drawing.Point(141, 88);
            this.txtShareBalence.Name = "txtShareBalence";
            this.txtShareBalence.Size = new System.Drawing.Size(192, 21);
            this.txtShareBalence.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(129, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(8, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = ":";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.DimGray;
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(18, 63);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(106, 21);
            this.label10.TabIndex = 8;
            this.label10.Text = "Client Name ";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtClientName
            // 
            this.txtClientName.BackColor = System.Drawing.Color.LightGray;
            this.txtClientName.Location = new System.Drawing.Point(141, 63);
            this.txtClientName.Name = "txtClientName";
            this.txtClientName.Size = new System.Drawing.Size(192, 21);
            this.txtClientName.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(129, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(8, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = ":";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.DimGray;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(18, 38);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 21);
            this.label8.TabIndex = 8;
            this.label8.Text = "Client BO ID ";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtClientBOID
            // 
            this.txtClientBOID.BackColor = System.Drawing.Color.LightGray;
            this.txtClientBOID.Location = new System.Drawing.Point(141, 38);
            this.txtClientBOID.Name = "txtClientBOID";
            this.txtClientBOID.Size = new System.Drawing.Size(192, 21);
            this.txtClientBOID.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.DimGray;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(18, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 21);
            this.label6.TabIndex = 5;
            this.label6.Text = "Client Code ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtClientCode
            // 
            this.txtClientCode.BackColor = System.Drawing.Color.LightGray;
            this.txtClientCode.Location = new System.Drawing.Point(141, 13);
            this.txtClientCode.Name = "txtClientCode";
            this.txtClientCode.Size = new System.Drawing.Size(192, 21);
            this.txtClientCode.TabIndex = 6;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.dtpRequestDate);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(12, 166);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(684, 135);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "BO Close Information";
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(126, 25);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(8, 13);
            this.label15.TabIndex = 12;
            this.label15.Text = ":";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.DimGray;
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(18, 21);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(106, 21);
            this.label16.TabIndex = 11;
            this.label16.Text = "Request Date";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpRequestDate
            // 
            this.dtpRequestDate.CustomFormat = "dd MMM yyyy";
            this.dtpRequestDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpRequestDate.Location = new System.Drawing.Point(143, 21);
            this.dtpRequestDate.Name = "dtpRequestDate";
            this.dtpRequestDate.Size = new System.Drawing.Size(127, 21);
            this.dtpRequestDate.TabIndex = 3;
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.DimGray;
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(18, 45);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(106, 21);
            this.label17.TabIndex = 12;
            this.label17.Text = "Payment Media";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(127, 49);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(8, 13);
            this.label18.TabIndex = 13;
            this.label18.Text = ":";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Client Code",
            "BO ID"});
            this.comboBox1.Location = new System.Drawing.Point(143, 46);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(127, 21);
            this.comboBox1.TabIndex = 3;
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(127, 73);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(8, 13);
            this.label19.TabIndex = 15;
            this.label19.Text = ":";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.Color.DimGray;
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(18, 69);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(106, 21);
            this.label20.TabIndex = 14;
            this.label20.Text = "Voucher No";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(143, 70);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(127, 21);
            this.textBox1.TabIndex = 3;
            // 
            // frmAccountCloseRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 494);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frmAccountCloseRequest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Account Close Request";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtClientID;
        private System.Windows.Forms.ComboBox ddlSearchBy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtClientCode;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtClientBalance;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtShareBalence;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtClientName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtClientBOID;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DateTimePicker dtpRequestDate;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label20;
    }
}