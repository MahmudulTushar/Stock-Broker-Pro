namespace StockbrokerProNewArch
{
    partial class StockSplitUpload
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
            this.err = new System.Windows.Forms.ErrorProvider(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.ofdFileOpen = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStartImport = new System.Windows.Forms.Button();
            this.btnFileLocationBrowser = new System.Windows.Forms.Button();
            this.txtFileLocation = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.err)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // err
            // 
            this.err.ContainerControl = this;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(89, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = ":";
            // 
            // ofdFileOpen
            // 
            this.ofdFileOpen.FileName = "17DP70UX.txt";
            this.ofdFileOpen.Filter = "txt files (*.txt)|*.txt";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnStartImport);
            this.groupBox1.Controls.Add(this.btnFileLocationBrowser);
            this.groupBox1.Controls.Add(this.txtFileLocation);
            this.groupBox1.Location = new System.Drawing.Point(9, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(502, 56);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Stock Split File";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "File Location";
            // 
            // btnStartImport
            // 
            this.btnStartImport.Location = new System.Drawing.Point(392, 19);
            this.btnStartImport.Name = "btnStartImport";
            this.btnStartImport.Size = new System.Drawing.Size(88, 23);
            this.btnStartImport.TabIndex = 10;
            this.btnStartImport.Text = "Start Import";
            this.btnStartImport.UseVisualStyleBackColor = true;
            this.btnStartImport.Click += new System.EventHandler(this.btnStartImport_Click);
            // 
            // btnFileLocationBrowser
            // 
            this.btnFileLocationBrowser.Location = new System.Drawing.Point(352, 19);
            this.btnFileLocationBrowser.Name = "btnFileLocationBrowser";
            this.btnFileLocationBrowser.Size = new System.Drawing.Size(34, 23);
            this.btnFileLocationBrowser.TabIndex = 11;
            this.btnFileLocationBrowser.Text = "...";
            this.btnFileLocationBrowser.UseVisualStyleBackColor = true;
            this.btnFileLocationBrowser.Click += new System.EventHandler(this.btnFileLocationBrowser_Click);
            // 
            // txtFileLocation
            // 
            this.txtFileLocation.Location = new System.Drawing.Point(105, 21);
            this.txtFileLocation.Name = "txtFileLocation";
            this.txtFileLocation.Size = new System.Drawing.Size(241, 20);
            this.txtFileLocation.TabIndex = 9;
            // 
            // StockSplitUpload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 79);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "StockSplitUpload";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock Split Upload";
            ((System.ComponentModel.ISupportInitialize)(this.err)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ErrorProvider err;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStartImport;
        private System.Windows.Forms.Button btnFileLocationBrowser;
        private System.Windows.Forms.TextBox txtFileLocation;
        private System.Windows.Forms.OpenFileDialog ofdFileOpen;
    }
}