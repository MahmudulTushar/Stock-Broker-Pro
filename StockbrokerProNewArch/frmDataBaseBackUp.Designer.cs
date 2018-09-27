namespace StockbrokerProNewArch
{
    partial class frmDataBaseBackUp
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
            this.btnBrowes = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnBackUp = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.flbBackup = new System.Windows.Forms.FolderBrowserDialog();
            this.timerProgress = new System.Windows.Forms.Timer(this.components);
            this.prgBackuplProgress = new System.Windows.Forms.ProgressBar();
            this.cmbDataBaseName = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.ComboBoxserverName = new System.Windows.Forms.ComboBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBackUpName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnBrowes
            // 
            this.btnBrowes.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnBrowes.Location = new System.Drawing.Point(350, 156);
            this.btnBrowes.Name = "btnBrowes";
            this.btnBrowes.Size = new System.Drawing.Size(24, 20);
            this.btnBrowes.TabIndex = 5;
            this.btnBrowes.Text = "...";
            this.btnBrowes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBrowes.Click += new System.EventHandler(this.btnBrowes_Click);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(147, 156);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(200, 20);
            this.txtPath.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label4.Location = new System.Drawing.Point(2, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(383, 34);
            this.label4.TabIndex = 10;
            this.label4.Text = "DataBase  Backup";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnBackUp
            // 
            this.btnBackUp.Location = new System.Drawing.Point(147, 188);
            this.btnBackUp.Name = "btnBackUp";
            this.btnBackUp.Size = new System.Drawing.Size(75, 23);
            this.btnBackUp.TabIndex = 11;
            this.btnBackUp.Text = "BackUp";
            this.btnBackUp.UseVisualStyleBackColor = true;
            this.btnBackUp.Click += new System.EventHandler(this.btnBackUp_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(228, 188);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Gray;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(7, 156);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label1.Size = new System.Drawing.Size(113, 20);
            this.label1.TabIndex = 39;
            this.label1.Text = "Location";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(129, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(10, 13);
            this.label5.TabIndex = 43;
            this.label5.Text = ":";
            // 
            // timerProgress
            // 
            this.timerProgress.Interval = 500;
            this.timerProgress.Tick += new System.EventHandler(this.timerProgress_Tick);
            // 
            // prgBackuplProgress
            // 
            this.prgBackuplProgress.BackColor = System.Drawing.Color.Red;
            this.prgBackuplProgress.ForeColor = System.Drawing.Color.Red;
            this.prgBackuplProgress.Location = new System.Drawing.Point(1, 42);
            this.prgBackuplProgress.Name = "prgBackuplProgress";
            this.prgBackuplProgress.Size = new System.Drawing.Size(384, 18);
            this.prgBackuplProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.prgBackuplProgress.TabIndex = 45;
            this.prgBackuplProgress.Visible = false;
            // 
            // cmbDataBaseName
            // 
            this.cmbDataBaseName.FormattingEnabled = true;
            this.cmbDataBaseName.Location = new System.Drawing.Point(147, 98);
            this.cmbDataBaseName.Name = "cmbDataBaseName";
            this.cmbDataBaseName.Size = new System.Drawing.Size(200, 21);
            this.cmbDataBaseName.TabIndex = 46;
            this.cmbDataBaseName.SelectedIndexChanged += new System.EventHandler(this.cmbDataBaseName_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(127, 102);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(10, 13);
            this.label7.TabIndex = 48;
            this.label7.Text = ":";
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Gray;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(5, 99);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label8.Size = new System.Drawing.Size(116, 20);
            this.label8.TabIndex = 47;
            this.label8.Text = "DataBase Name";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(127, 73);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(10, 13);
            this.label9.TabIndex = 51;
            this.label9.Text = ":";
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Gray;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(5, 70);
            this.label10.Name = "label10";
            this.label10.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label10.Size = new System.Drawing.Size(116, 20);
            this.label10.TabIndex = 50;
            this.label10.Text = "Server Name";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ComboBoxserverName
            // 
            this.ComboBoxserverName.FormattingEnabled = true;
            this.ComboBoxserverName.Location = new System.Drawing.Point(147, 69);
            this.ComboBoxserverName.Name = "ComboBoxserverName";
            this.ComboBoxserverName.Size = new System.Drawing.Size(200, 21);
            this.ComboBoxserverName.TabIndex = 49;
            this.ComboBoxserverName.SelectedIndexChanged += new System.EventHandler(this.ComboBoxserverName_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Gray;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(5, 128);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label2.Size = new System.Drawing.Size(116, 20);
            this.label2.TabIndex = 52;
            this.label2.Text = "BackUp Name";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(128, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 13);
            this.label3.TabIndex = 53;
            this.label3.Text = ":";
            // 
            // txtBackUpName
            // 
            this.txtBackUpName.Location = new System.Drawing.Point(147, 127);
            this.txtBackUpName.Name = "txtBackUpName";
            this.txtBackUpName.Size = new System.Drawing.Size(202, 20);
            this.txtBackUpName.TabIndex = 54;
            // 
            // frmDataBaseBackUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(398, 226);
            this.Controls.Add(this.txtBackUpName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.ComboBoxserverName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbDataBaseName);
            this.Controls.Add(this.prgBackuplProgress);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnBackUp);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnBrowes);
            this.Controls.Add(this.txtPath);
            this.Name = "frmDataBaseBackUp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DataBase BackUp";
            this.Load += new System.EventHandler(this.frmDataBaseBackUp_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBrowes;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnBackUp;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.FolderBrowserDialog flbBackup;
        private System.Windows.Forms.Timer timerProgress;
        private System.Windows.Forms.ProgressBar prgBackuplProgress;
        private System.Windows.Forms.ComboBox cmbDataBaseName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox ComboBoxserverName;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBackUpName;
    }
}