namespace StockbrokerProNewArch
{
    partial class CDBLShareReconcile
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStartImport = new System.Windows.Forms.Button();
            this.btnFileLocationBrowser = new System.Windows.Forms.Button();
            this.txtFileLocation = new System.Windows.Forms.TextBox();
            this.ofdFileOpen = new System.Windows.Forms.OpenFileDialog();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdo_MissMatch = new System.Windows.Forms.RadioButton();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.rdoSattlement = new System.Windows.Forms.RadioButton();
            this.rdoShareSummery = new System.Windows.Forms.RadioButton();
            this.rdoCustomerwise = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblISINDate = new System.Windows.Forms.Label();
            this.lblTradeDate = new System.Windows.Forms.Label();
            this.lblCurrentDate = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnStartImport);
            this.groupBox1.Controls.Add(this.btnFileLocationBrowser);
            this.groupBox1.Controls.Add(this.txtFileLocation);
            this.groupBox1.Location = new System.Drawing.Point(2, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(607, 72);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Trade File";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label2.Location = new System.Drawing.Point(105, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = ":";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label1.Location = new System.Drawing.Point(19, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "File Location";
            // 
            // btnStartImport
            // 
            this.btnStartImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartImport.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnStartImport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStartImport.Location = new System.Drawing.Point(398, 23);
            this.btnStartImport.Name = "btnStartImport";
            this.btnStartImport.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnStartImport.Size = new System.Drawing.Size(104, 25);
            this.btnStartImport.TabIndex = 1;
            this.btnStartImport.Text = "Start Import";
            this.btnStartImport.UseVisualStyleBackColor = true;
            this.btnStartImport.Click += new System.EventHandler(this.btnStartImport_Click);
            // 
            // btnFileLocationBrowser
            // 
            this.btnFileLocationBrowser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFileLocationBrowser.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnFileLocationBrowser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFileLocationBrowser.Location = new System.Drawing.Point(358, 23);
            this.btnFileLocationBrowser.Name = "btnFileLocationBrowser";
            this.btnFileLocationBrowser.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnFileLocationBrowser.Size = new System.Drawing.Size(34, 25);
            this.btnFileLocationBrowser.TabIndex = 0;
            this.btnFileLocationBrowser.Text = "...";
            this.btnFileLocationBrowser.UseVisualStyleBackColor = true;
            this.btnFileLocationBrowser.Click += new System.EventHandler(this.btnFileLocationBrowser_Click);
            // 
            // txtFileLocation
            // 
            this.txtFileLocation.Location = new System.Drawing.Point(122, 26);
            this.txtFileLocation.Name = "txtFileLocation";
            this.txtFileLocation.Size = new System.Drawing.Size(230, 20);
            this.txtFileLocation.TabIndex = 0;
            // 
            // ofdFileOpen
            // 
            this.ofdFileOpen.FileName = "trades.txt";
            this.ofdFileOpen.Filter = "txt files (*.txt)|*.txt";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdo_MissMatch);
            this.groupBox2.Controls.Add(this.btnClose);
            this.groupBox2.Controls.Add(this.btnReport);
            this.groupBox2.Controls.Add(this.rdoSattlement);
            this.groupBox2.Controls.Add(this.rdoShareSummery);
            this.groupBox2.Controls.Add(this.rdoCustomerwise);
            this.groupBox2.Location = new System.Drawing.Point(2, 82);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(607, 50);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mismatch Report";
            // 
            // rdo_MissMatch
            // 
            this.rdo_MissMatch.AutoSize = true;
            this.rdo_MissMatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdo_MissMatch.Location = new System.Drawing.Point(7, 19);
            this.rdo_MissMatch.Name = "rdo_MissMatch";
            this.rdo_MissMatch.Size = new System.Drawing.Size(89, 17);
            this.rdo_MissMatch.TabIndex = 5;
            this.rdo_MissMatch.TabStop = true;
            this.rdo_MissMatch.Text = "Miss Match";
            this.rdo_MissMatch.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(508, 15);
            this.btnClose.Name = "btnClose";
            this.btnClose.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnClose.Size = new System.Drawing.Size(92, 25);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnReport
            // 
            this.btnReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReport.Location = new System.Drawing.Point(415, 15);
            this.btnReport.Name = "btnReport";
            this.btnReport.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnReport.Size = new System.Drawing.Size(87, 25);
            this.btnReport.TabIndex = 3;
            this.btnReport.Text = "Report";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // rdoSattlement
            // 
            this.rdoSattlement.AutoSize = true;
            this.rdoSattlement.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoSattlement.Location = new System.Drawing.Point(329, 20);
            this.rdoSattlement.Name = "rdoSattlement";
            this.rdoSattlement.Size = new System.Drawing.Size(85, 17);
            this.rdoSattlement.TabIndex = 2;
            this.rdoSattlement.TabStop = true;
            this.rdoSattlement.Text = "Settlement";
            this.rdoSattlement.UseVisualStyleBackColor = true;
            // 
            // rdoShareSummery
            // 
            this.rdoShareSummery.AutoSize = true;
            this.rdoShareSummery.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoShareSummery.Location = new System.Drawing.Point(211, 20);
            this.rdoShareSummery.Name = "rdoShareSummery";
            this.rdoShareSummery.Size = new System.Drawing.Size(112, 17);
            this.rdoShareSummery.TabIndex = 1;
            this.rdoShareSummery.TabStop = true;
            this.rdoShareSummery.Text = "Share Summary";
            this.rdoShareSummery.UseVisualStyleBackColor = true;
            // 
            // rdoCustomerwise
            // 
            this.rdoCustomerwise.AutoSize = true;
            this.rdoCustomerwise.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoCustomerwise.Location = new System.Drawing.Point(96, 20);
            this.rdoCustomerwise.Name = "rdoCustomerwise";
            this.rdoCustomerwise.Size = new System.Drawing.Size(109, 17);
            this.rdoCustomerwise.TabIndex = 0;
            this.rdoCustomerwise.TabStop = true;
            this.rdoCustomerwise.Text = "Customer Wise";
            this.rdoCustomerwise.UseVisualStyleBackColor = true;
           
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblISINDate);
            this.groupBox3.Controls.Add(this.lblTradeDate);
            this.groupBox3.Controls.Add(this.lblCurrentDate);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(2, 133);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(607, 50);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            // 
            // lblISINDate
            // 
            this.lblISINDate.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblISINDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblISINDate.Location = new System.Drawing.Point(483, 16);
            this.lblISINDate.Name = "lblISINDate";
            this.lblISINDate.Size = new System.Drawing.Size(100, 20);
            this.lblISINDate.TabIndex = 5;
            this.lblISINDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTradeDate
            // 
            this.lblTradeDate.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblTradeDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTradeDate.Location = new System.Drawing.Point(305, 16);
            this.lblTradeDate.Name = "lblTradeDate";
            this.lblTradeDate.Size = new System.Drawing.Size(97, 20);
            this.lblTradeDate.TabIndex = 4;
            this.lblTradeDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCurrentDate
            // 
            this.lblCurrentDate.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblCurrentDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentDate.Location = new System.Drawing.Point(94, 16);
            this.lblCurrentDate.Name = "lblCurrentDate";
            this.lblCurrentDate.Size = new System.Drawing.Size(101, 20);
            this.lblCurrentDate.TabIndex = 3;
            this.lblCurrentDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(417, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "ISIN Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(203, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Last Trade Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Current Date";
            // 
            // CDBLShareReconcile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 185);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "CDBLShareReconcile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CDBL Share Reconcile";
            this.Load += new System.EventHandler(this.CDBLShareReconcile_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStartImport;
        private System.Windows.Forms.Button btnFileLocationBrowser;
        private System.Windows.Forms.TextBox txtFileLocation;
        private System.Windows.Forms.OpenFileDialog ofdFileOpen;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.RadioButton rdoSattlement;
        private System.Windows.Forms.RadioButton rdoShareSummery;
        private System.Windows.Forms.RadioButton rdoCustomerwise;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCurrentDate;
        private System.Windows.Forms.Label lblISINDate;
        private System.Windows.Forms.Label lblTradeDate;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.RadioButton rdo_MissMatch;
    }
}