namespace StockbrokerProNewArch
{
    partial class frm_IPOAppExport
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
            this.txt_SessionID = new System.Windows.Forms.TextBox();
            this.txt_SessionName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmb_SessionName = new System.Windows.Forms.ComboBox();
            this.btn_GetApplication = new System.Windows.Forms.Button();
            this.btn_Browse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFileLocation = new System.Windows.Forms.TextBox();
            this.dgApplicationExport = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Process_Csv = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_Password = new System.Windows.Forms.TextBox();
            this.txt_FileNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Process_Text = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.lbl_Count_Grid = new System.Windows.Forms.Label();
            this.cmbcategory = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgApplicationExport)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_SessionID
            // 
            this.txt_SessionID.Location = new System.Drawing.Point(10, 7);
            this.txt_SessionID.Name = "txt_SessionID";
            this.txt_SessionID.Size = new System.Drawing.Size(33, 20);
            this.txt_SessionID.TabIndex = 21;
            this.txt_SessionID.Visible = false;
            // 
            // txt_SessionName
            // 
            this.txt_SessionName.Location = new System.Drawing.Point(506, 7);
            this.txt_SessionName.Name = "txt_SessionName";
            this.txt_SessionName.Size = new System.Drawing.Size(283, 20);
            this.txt_SessionName.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(425, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Session Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(72, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Company Name";
            // 
            // cmb_SessionName
            // 
            this.cmb_SessionName.FormattingEnabled = true;
            this.cmb_SessionName.Location = new System.Drawing.Point(153, 6);
            this.cmb_SessionName.Name = "cmb_SessionName";
            this.cmb_SessionName.Size = new System.Drawing.Size(236, 21);
            this.cmb_SessionName.TabIndex = 17;
            this.cmb_SessionName.SelectedIndexChanged += new System.EventHandler(this.cmb_SessionName_SelectedIndexChanged);
            // 
            // btn_GetApplication
            // 
            this.btn_GetApplication.Location = new System.Drawing.Point(730, 38);
            this.btn_GetApplication.Name = "btn_GetApplication";
            this.btn_GetApplication.Size = new System.Drawing.Size(99, 23);
            this.btn_GetApplication.TabIndex = 16;
            this.btn_GetApplication.Text = "Get Application";
            this.btn_GetApplication.UseVisualStyleBackColor = true;
            this.btn_GetApplication.Click += new System.EventHandler(this.btn_GetApplication_Click);
            // 
            // btn_Browse
            // 
            this.btn_Browse.Location = new System.Drawing.Point(773, 14);
            this.btn_Browse.Name = "btn_Browse";
            this.btn_Browse.Size = new System.Drawing.Size(33, 23);
            this.btn_Browse.TabIndex = 15;
            this.btn_Browse.Text = "...";
            this.btn_Browse.UseVisualStyleBackColor = true;
            this.btn_Browse.Click += new System.EventHandler(this.btn_Browse_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Folder Location";
            // 
            // txtFileLocation
            // 
            this.txtFileLocation.Location = new System.Drawing.Point(119, 16);
            this.txtFileLocation.Name = "txtFileLocation";
            this.txtFileLocation.Size = new System.Drawing.Size(648, 20);
            this.txtFileLocation.TabIndex = 13;
            // 
            // dgApplicationExport
            // 
            this.dgApplicationExport.AllowUserToAddRows = false;
            this.dgApplicationExport.AllowUserToDeleteRows = false;
            this.dgApplicationExport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgApplicationExport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgApplicationExport.Location = new System.Drawing.Point(10, 74);
            this.dgApplicationExport.Name = "dgApplicationExport";
            this.dgApplicationExport.ReadOnly = true;
            this.dgApplicationExport.RowHeadersVisible = false;
            this.dgApplicationExport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgApplicationExport.Size = new System.Drawing.Size(819, 334);
            this.dgApplicationExport.TabIndex = 22;
            this.dgApplicationExport.DataSourceChanged += new System.EventHandler(this.dgApplicationExport_DataSourceChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_Process_Csv);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txt_Password);
            this.panel1.Controls.Add(this.txt_FileNo);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btn_Process_Text);
            this.panel1.Controls.Add(this.btn_Close);
            this.panel1.Controls.Add(this.txtFileLocation);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btn_Browse);
            this.panel1.Location = new System.Drawing.Point(10, 430);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(819, 82);
            this.panel1.TabIndex = 23;
            // 
            // btn_Process_Csv
            // 
            this.btn_Process_Csv.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Process_Csv.ForeColor = System.Drawing.Color.Navy;
            this.btn_Process_Csv.Location = new System.Drawing.Point(518, 40);
            this.btn_Process_Csv.Name = "btn_Process_Csv";
            this.btn_Process_Csv.Size = new System.Drawing.Size(106, 23);
            this.btn_Process_Csv.TabIndex = 45;
            this.btn_Process_Csv.TabStop = false;
            this.btn_Process_Csv.Text = "Process Csv";
            this.btn_Process_Csv.UseVisualStyleBackColor = true;
            this.btn_Process_Csv.Click += new System.EventHandler(this.btn_Process_Csv_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Enabled = false;
            this.label5.Location = new System.Drawing.Point(301, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 44;
            this.label5.Text = "Password";
            // 
            // txt_Password
            // 
            this.txt_Password.Enabled = false;
            this.txt_Password.Location = new System.Drawing.Point(360, 42);
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.PasswordChar = '*';
            this.txt_Password.Size = new System.Drawing.Size(128, 20);
            this.txt_Password.TabIndex = 43;
            // 
            // txt_FileNo
            // 
            this.txt_FileNo.Location = new System.Drawing.Point(119, 42);
            this.txt_FileNo.Name = "txt_FileNo";
            this.txt_FileNo.Size = new System.Drawing.Size(158, 20);
            this.txt_FileNo.TabIndex = 42;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 41;
            this.label2.Text = "File Name";
            // 
            // btn_Process_Text
            // 
            this.btn_Process_Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Process_Text.ForeColor = System.Drawing.Color.Navy;
            this.btn_Process_Text.Location = new System.Drawing.Point(630, 40);
            this.btn_Process_Text.Name = "btn_Process_Text";
            this.btn_Process_Text.Size = new System.Drawing.Size(106, 23);
            this.btn_Process_Text.TabIndex = 40;
            this.btn_Process_Text.TabStop = false;
            this.btn_Process_Text.Text = "Process Txt";
            this.btn_Process_Text.UseVisualStyleBackColor = true;
            this.btn_Process_Text.Click += new System.EventHandler(this.btn_Process_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Close.ForeColor = System.Drawing.Color.Navy;
            this.btn_Close.Location = new System.Drawing.Point(739, 40);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(68, 23);
            this.btn_Close.TabIndex = 39;
            this.btn_Close.TabStop = false;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // lbl_Count_Grid
            // 
            this.lbl_Count_Grid.AutoSize = true;
            this.lbl_Count_Grid.Location = new System.Drawing.Point(14, 413);
            this.lbl_Count_Grid.Name = "lbl_Count_Grid";
            this.lbl_Count_Grid.Size = new System.Drawing.Size(0, 13);
            this.lbl_Count_Grid.TabIndex = 24;
            // 
            // cmbcategory
            // 
            this.cmbcategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbcategory.FormattingEnabled = true;
            this.cmbcategory.Items.AddRange(new object[] {
            "RB",
            "NRB"});
            this.cmbcategory.Location = new System.Drawing.Point(506, 35);
            this.cmbcategory.Name = "cmbcategory";
            this.cmbcategory.Size = new System.Drawing.Size(90, 21);
            this.cmbcategory.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(451, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "Category";
            // 
            // frm_IPOAppExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 516);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbcategory);
            this.Controls.Add(this.lbl_Count_Grid);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgApplicationExport);
            this.Controls.Add(this.txt_SessionID);
            this.Controls.Add(this.txt_SessionName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmb_SessionName);
            this.Controls.Add(this.btn_GetApplication);
            this.Name = "frm_IPOAppExport";
            this.Text = "Application Export";
            this.Load += new System.EventHandler(this.frm_IPOAppExport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgApplicationExport)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_SessionID;
        private System.Windows.Forms.TextBox txt_SessionName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmb_SessionName;
        private System.Windows.Forms.Button btn_GetApplication;
        private System.Windows.Forms.Button btn_Browse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFileLocation;
        private System.Windows.Forms.DataGridView dgApplicationExport;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_Process_Text;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox txt_FileNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_Password;
        private System.Windows.Forms.Button btn_Process_Csv;
        private System.Windows.Forms.Label lbl_Count_Grid;
        private System.Windows.Forms.ComboBox cmbcategory;
        private System.Windows.Forms.Label label6;
    }
}