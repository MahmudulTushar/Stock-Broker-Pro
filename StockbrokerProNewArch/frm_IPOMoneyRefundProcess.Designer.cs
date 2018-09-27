namespace StockbrokerProNewArch
{
    partial class frm_IPOMoneyRefundProcess
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
            this.dg_MoneyRefund = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Process = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.lbl_Count_Grid = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dg_MoneyRefund)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_SessionID
            // 
            this.txt_SessionID.Location = new System.Drawing.Point(12, 13);
            this.txt_SessionID.Name = "txt_SessionID";
            this.txt_SessionID.Size = new System.Drawing.Size(33, 20);
            this.txt_SessionID.TabIndex = 27;
            this.txt_SessionID.Visible = false;
            // 
            // txt_SessionName
            // 
            this.txt_SessionName.Location = new System.Drawing.Point(495, 12);
            this.txt_SessionName.Name = "txt_SessionName";
            this.txt_SessionName.Size = new System.Drawing.Size(283, 20);
            this.txt_SessionName.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(407, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Session Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(65, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Company Name";
            // 
            // cmb_SessionName
            // 
            this.cmb_SessionName.FormattingEnabled = true;
            this.cmb_SessionName.Location = new System.Drawing.Point(146, 12);
            this.cmb_SessionName.Name = "cmb_SessionName";
            this.cmb_SessionName.Size = new System.Drawing.Size(236, 21);
            this.cmb_SessionName.TabIndex = 23;
            this.cmb_SessionName.SelectedIndexChanged += new System.EventHandler(this.cmb_SessionName_SelectedIndexChanged);
            // 
            // btn_GetApplication
            // 
            this.btn_GetApplication.Location = new System.Drawing.Point(715, 38);
            this.btn_GetApplication.Name = "btn_GetApplication";
            this.btn_GetApplication.Size = new System.Drawing.Size(99, 23);
            this.btn_GetApplication.TabIndex = 22;
            this.btn_GetApplication.Text = "Get Refund List";
            this.btn_GetApplication.UseVisualStyleBackColor = true;
            this.btn_GetApplication.Click += new System.EventHandler(this.btn_GetApplication_Click);
            // 
            // dg_MoneyRefund
            // 
            this.dg_MoneyRefund.AllowUserToAddRows = false;
            this.dg_MoneyRefund.AllowUserToDeleteRows = false;
            this.dg_MoneyRefund.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dg_MoneyRefund.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_MoneyRefund.Location = new System.Drawing.Point(12, 65);
            this.dg_MoneyRefund.Name = "dg_MoneyRefund";
            this.dg_MoneyRefund.ReadOnly = true;
            this.dg_MoneyRefund.RowHeadersVisible = false;
            this.dg_MoneyRefund.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_MoneyRefund.Size = new System.Drawing.Size(802, 419);
            this.dg_MoneyRefund.TabIndex = 28;
            this.dg_MoneyRefund.DataSourceChanged += new System.EventHandler(this.dg_MoneyRefund_DataSourceChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_Process);
            this.panel1.Controls.Add(this.btn_Close);
            this.panel1.Location = new System.Drawing.Point(11, 508);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(803, 46);
            this.panel1.TabIndex = 29;
            // 
            // btn_Process
            // 
            this.btn_Process.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Process.ForeColor = System.Drawing.Color.Navy;
            this.btn_Process.Location = new System.Drawing.Point(645, 12);
            this.btn_Process.Name = "btn_Process";
            this.btn_Process.Size = new System.Drawing.Size(75, 23);
            this.btn_Process.TabIndex = 42;
            this.btn_Process.TabStop = false;
            this.btn_Process.Text = "Process";
            this.btn_Process.UseVisualStyleBackColor = true;
            this.btn_Process.Click += new System.EventHandler(this.btn_Process_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Close.ForeColor = System.Drawing.Color.Navy;
            this.btn_Close.Location = new System.Drawing.Point(723, 12);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(68, 23);
            this.btn_Close.TabIndex = 41;
            this.btn_Close.TabStop = false;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // lbl_Count_Grid
            // 
            this.lbl_Count_Grid.AutoSize = true;
            this.lbl_Count_Grid.Location = new System.Drawing.Point(13, 489);
            this.lbl_Count_Grid.Name = "lbl_Count_Grid";
            this.lbl_Count_Grid.Size = new System.Drawing.Size(0, 13);
            this.lbl_Count_Grid.TabIndex = 30;
            // 
            // frm_IPOMoneyRefundProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 557);
            this.Controls.Add(this.lbl_Count_Grid);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dg_MoneyRefund);
            this.Controls.Add(this.txt_SessionID);
            this.Controls.Add(this.txt_SessionName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmb_SessionName);
            this.Controls.Add(this.btn_GetApplication);
            this.Name = "frm_IPOMoneyRefundProcess";
            this.Text = "Money Refund";
            this.Load += new System.EventHandler(this.frm_IPOMoneyRefundProcess_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg_MoneyRefund)).EndInit();
            this.panel1.ResumeLayout(false);
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
        private System.Windows.Forms.DataGridView dg_MoneyRefund;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_Process;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Label lbl_Count_Grid;
    }
}