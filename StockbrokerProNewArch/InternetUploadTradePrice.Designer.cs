namespace StockbrokerProNewArch
{
    partial class InternetUploadTradePrice
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
            GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory defaultGridFilterFactory1 = new GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory();
            this.btnUpload = new System.Windows.Forms.Button();
            this.dgvPriceData = new System.Windows.Forms.DataGridView();
            this.btnFetch = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnCheck = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbComapnyName = new System.Windows.Forms.ListBox();
            this.dataGridFilterExtender1 = new GridViewExtensions.DataGridFilterExtender(this.components);
            this.ofdFileOpen = new System.Windows.Forms.OpenFileDialog();
            this.lblTotalItem = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPriceData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFilterExtender1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUpload
            // 
            this.btnUpload.Enabled = false;
            this.btnUpload.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpload.Location = new System.Drawing.Point(12, 446);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(119, 23);
            this.btnUpload.TabIndex = 5;
            this.btnUpload.Text = "Upload To Server";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // dgvPriceData
            // 
            this.dgvPriceData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPriceData.Location = new System.Drawing.Point(12, 24);
            this.dgvPriceData.Name = "dgvPriceData";
            this.dgvPriceData.Size = new System.Drawing.Size(744, 412);
            this.dgvPriceData.TabIndex = 4;
            // 
            // btnFetch
            // 
            this.btnFetch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFetch.Location = new System.Drawing.Point(564, 446);
            this.btnFetch.Name = "btnFetch";
            this.btnFetch.Size = new System.Drawing.Size(115, 23);
            this.btnFetch.TabIndex = 3;
            this.btnFetch.Text = "Fetch Price Data";
            this.btnFetch.UseVisualStyleBackColor = true;
            this.btnFetch.Click += new System.EventHandler(this.btnFetch_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(682, 446);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheck.Location = new System.Drawing.Point(483, 446);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(75, 23);
            this.btnCheck.TabIndex = 7;
            this.btnCheck.Text = "Check";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DimGray;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Chartreuse;
            this.label1.Location = new System.Drawing.Point(476, 480);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.label1.Size = new System.Drawing.Size(120, 23);
            this.label1.TabIndex = 114;
            this.label1.Text = "Company Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbComapnyName
            // 
            this.lbComapnyName.FormattingEnabled = true;
            this.lbComapnyName.Location = new System.Drawing.Point(476, 503);
            this.lbComapnyName.Name = "lbComapnyName";
            this.lbComapnyName.Size = new System.Drawing.Size(120, 95);
            this.lbComapnyName.TabIndex = 113;
            // 
            // dataGridFilterExtender1
            // 
            this.dataGridFilterExtender1.DataGridView = this.dgvPriceData;
            defaultGridFilterFactory1.CreateDistinctGridFilters = false;
            defaultGridFilterFactory1.DefaultGridFilterType = typeof(GridViewExtensions.GridFilters.TextGridFilter);
            defaultGridFilterFactory1.DefaultShowDateInBetweenOperator = false;
            defaultGridFilterFactory1.DefaultShowNumericInBetweenOperator = false;
            defaultGridFilterFactory1.HandleEnumerationTypes = true;
            defaultGridFilterFactory1.MaximumDistinctValues = 20;
            this.dataGridFilterExtender1.FilterFactory = defaultGridFilterFactory1;
            // 
            // ofdFileOpen
            // 
            this.ofdFileOpen.FileName = "trades.txt";
            this.ofdFileOpen.Filter = "txt files (*.txt)|*.txt";
            // 
            // lblTotalItem
            // 
            this.lblTotalItem.AutoSize = true;
            this.lblTotalItem.Location = new System.Drawing.Point(137, 451);
            this.lblTotalItem.Name = "lblTotalItem";
            this.lblTotalItem.Size = new System.Drawing.Size(0, 13);
            this.lblTotalItem.TabIndex = 116;
            // 
            // InternetUploadTradePrice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 479);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTotalItem);
            this.Controls.Add(this.lbComapnyName);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.dgvPriceData);
            this.Controls.Add(this.btnFetch);
            this.MaximizeBox = false;
            this.Name = "InternetUploadTradePrice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Upload Trade Price From DSE Site";
            this.Load += new System.EventHandler(this.InternetUploadTradePrice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPriceData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFilterExtender1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.DataGridView dgvPriceData;
        private System.Windows.Forms.Button btnFetch;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbComapnyName;
        private GridViewExtensions.DataGridFilterExtender dataGridFilterExtender1;
        private System.Windows.Forms.OpenFileDialog ofdFileOpen;
        private System.Windows.Forms.Label lblTotalItem;
    }
}