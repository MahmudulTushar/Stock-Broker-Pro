namespace StockbrokerProNewArch
{
    partial class LatestSharePriceNew
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtgLatestSharePrice = new System.Windows.Forms.DataGridView();
            this.Company1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LTP1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Separator1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Company2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LTP2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Separator2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Company3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LTP3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Separator3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Company4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LTP4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Separator4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Company5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LTP5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Separator5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Company6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LTP6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timerRefreshment = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgLatestSharePrice)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgLatestSharePrice
            // 
            this.dtgLatestSharePrice.AllowUserToAddRows = false;
            this.dtgLatestSharePrice.AllowUserToDeleteRows = false;
            this.dtgLatestSharePrice.AllowUserToResizeColumns = false;
            this.dtgLatestSharePrice.AllowUserToResizeRows = false;
            this.dtgLatestSharePrice.BackgroundColor = System.Drawing.Color.DimGray;
            this.dtgLatestSharePrice.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgLatestSharePrice.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgLatestSharePrice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgLatestSharePrice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Company1,
            this.LTP1,
            this.Separator1,
            this.Company2,
            this.LTP2,
            this.Separator2,
            this.Company3,
            this.LTP3,
            this.Separator3,
            this.Company4,
            this.LTP4,
            this.Separator4,
            this.Company5,
            this.LTP5,
            this.Separator5,
            this.Company6,
            this.LTP6});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(200)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgLatestSharePrice.DefaultCellStyle = dataGridViewCellStyle7;
            this.dtgLatestSharePrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgLatestSharePrice.Location = new System.Drawing.Point(0, 0);
            this.dtgLatestSharePrice.MultiSelect = false;
            this.dtgLatestSharePrice.Name = "dtgLatestSharePrice";
            this.dtgLatestSharePrice.ReadOnly = true;
            this.dtgLatestSharePrice.RowHeadersVisible = false;
            this.dtgLatestSharePrice.Size = new System.Drawing.Size(992, 516);
            this.dtgLatestSharePrice.TabIndex = 0;
            this.dtgLatestSharePrice.SelectionChanged += new System.EventHandler(this.dtgLatestSharePrice_SelectionChanged);
            // 
            // Company1
            // 
            this.Company1.HeaderText = "Company";
            this.Company1.Name = "Company1";
            this.Company1.ReadOnly = true;
            // 
            // LTP1
            // 
            this.LTP1.HeaderText = "LTP";
            this.LTP1.Name = "LTP1";
            this.LTP1.ReadOnly = true;
            this.LTP1.Width = 65;
            // 
            // Separator1
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.DimGray;
            this.Separator1.DefaultCellStyle = dataGridViewCellStyle2;
            this.Separator1.HeaderText = "";
            this.Separator1.Name = "Separator1";
            this.Separator1.ReadOnly = true;
            this.Separator1.Width = 5;
            // 
            // Company2
            // 
            this.Company2.HeaderText = "Company";
            this.Company2.Name = "Company2";
            this.Company2.ReadOnly = true;
            // 
            // LTP2
            // 
            this.LTP2.HeaderText = "LTP";
            this.LTP2.Name = "LTP2";
            this.LTP2.ReadOnly = true;
            this.LTP2.Width = 65;
            // 
            // Separator2
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.DimGray;
            this.Separator2.DefaultCellStyle = dataGridViewCellStyle3;
            this.Separator2.HeaderText = "";
            this.Separator2.Name = "Separator2";
            this.Separator2.ReadOnly = true;
            this.Separator2.Width = 5;
            // 
            // Company3
            // 
            this.Company3.HeaderText = "Company";
            this.Company3.Name = "Company3";
            this.Company3.ReadOnly = true;
            // 
            // LTP3
            // 
            this.LTP3.HeaderText = "LTP";
            this.LTP3.Name = "LTP3";
            this.LTP3.ReadOnly = true;
            this.LTP3.Width = 65;
            // 
            // Separator3
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.DimGray;
            this.Separator3.DefaultCellStyle = dataGridViewCellStyle4;
            this.Separator3.HeaderText = "";
            this.Separator3.Name = "Separator3";
            this.Separator3.ReadOnly = true;
            this.Separator3.Width = 5;
            // 
            // Company4
            // 
            this.Company4.HeaderText = "Company";
            this.Company4.Name = "Company4";
            this.Company4.ReadOnly = true;
            // 
            // LTP4
            // 
            this.LTP4.HeaderText = "LTP";
            this.LTP4.Name = "LTP4";
            this.LTP4.ReadOnly = true;
            this.LTP4.Width = 65;
            // 
            // Separator4
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.DimGray;
            this.Separator4.DefaultCellStyle = dataGridViewCellStyle5;
            this.Separator4.HeaderText = "";
            this.Separator4.Name = "Separator4";
            this.Separator4.ReadOnly = true;
            this.Separator4.Width = 5;
            // 
            // Company5
            // 
            this.Company5.HeaderText = "Company";
            this.Company5.Name = "Company5";
            this.Company5.ReadOnly = true;
            // 
            // LTP5
            // 
            this.LTP5.HeaderText = "LTP";
            this.LTP5.Name = "LTP5";
            this.LTP5.ReadOnly = true;
            this.LTP5.Width = 65;
            // 
            // Separator5
            // 
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.DimGray;
            this.Separator5.DefaultCellStyle = dataGridViewCellStyle6;
            this.Separator5.HeaderText = "";
            this.Separator5.Name = "Separator5";
            this.Separator5.ReadOnly = true;
            this.Separator5.Width = 5;
            // 
            // Company6
            // 
            this.Company6.HeaderText = "Company";
            this.Company6.Name = "Company6";
            this.Company6.ReadOnly = true;
            // 
            // LTP6
            // 
            this.LTP6.HeaderText = "LTP";
            this.LTP6.Name = "LTP6";
            this.LTP6.ReadOnly = true;
            this.LTP6.Width = 65;
            // 
            // timerRefreshment
            // 
            this.timerRefreshment.Tick += new System.EventHandler(this.timerRefreshment_Tick);
            // 
            // LatestSharePriceNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 516);
            this.Controls.Add(this.dtgLatestSharePrice);
            this.MaximizeBox = false;
            this.Name = "LatestSharePriceNew";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Latest Share Price Viewer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.LatestSharePriceNew_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgLatestSharePrice)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgLatestSharePrice;
        private System.Windows.Forms.Timer timerRefreshment;
        private System.Windows.Forms.DataGridViewTextBoxColumn Company1;
        private System.Windows.Forms.DataGridViewTextBoxColumn LTP1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Separator1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Company2;
        private System.Windows.Forms.DataGridViewTextBoxColumn LTP2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Separator2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Company3;
        private System.Windows.Forms.DataGridViewTextBoxColumn LTP3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Separator3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Company4;
        private System.Windows.Forms.DataGridViewTextBoxColumn LTP4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Separator4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Company5;
        private System.Windows.Forms.DataGridViewTextBoxColumn LTP5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Separator5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Company6;
        private System.Windows.Forms.DataGridViewTextBoxColumn LTP6;
    }
}