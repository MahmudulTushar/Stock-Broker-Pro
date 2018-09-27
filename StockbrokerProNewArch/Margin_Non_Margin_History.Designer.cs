namespace StockbrokerProNewArch
{
    partial class Margin_Non_Margin_History
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridFilterExtender1 = new GridViewExtensions.DataGridFilterExtender(this.components);
            this.dg_AllCompany = new System.Windows.Forms.DataGridView();
            this.btn_MarginUPdate = new System.Windows.Forms.Button();
            this.Btt_Exportdata = new System.Windows.Forms.Button();
            this.btt_ExportPDF = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFilterExtender1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg_AllCompany)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridFilterExtender1
            // 
            this.dataGridFilterExtender1.DataGridView = this.dg_AllCompany;
            defaultGridFilterFactory1.CreateDistinctGridFilters = false;
            defaultGridFilterFactory1.DefaultGridFilterType = typeof(GridViewExtensions.GridFilters.TextGridFilter);
            defaultGridFilterFactory1.DefaultShowDateInBetweenOperator = false;
            defaultGridFilterFactory1.DefaultShowNumericInBetweenOperator = false;
            defaultGridFilterFactory1.HandleEnumerationTypes = true;
            defaultGridFilterFactory1.MaximumDistinctValues = 20;
            this.dataGridFilterExtender1.FilterFactory = defaultGridFilterFactory1;
            // 
            // dg_AllCompany
            // 
            this.dg_AllCompany.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dg_AllCompany.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_AllCompany.Location = new System.Drawing.Point(10, 36);
            this.dg_AllCompany.Margin = new System.Windows.Forms.Padding(4);
            this.dg_AllCompany.Name = "dg_AllCompany";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dg_AllCompany.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dg_AllCompany.RowHeadersWidth = 60;
            this.dg_AllCompany.RowTemplate.Height = 24;
            this.dg_AllCompany.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_AllCompany.Size = new System.Drawing.Size(755, 330);
            this.dg_AllCompany.TabIndex = 7;
            // 
            // btn_MarginUPdate
            // 
            this.btn_MarginUPdate.Location = new System.Drawing.Point(448, 5);
            this.btn_MarginUPdate.Name = "btn_MarginUPdate";
            this.btn_MarginUPdate.Size = new System.Drawing.Size(99, 32);
            this.btn_MarginUPdate.TabIndex = 2;
            this.btn_MarginUPdate.Text = "Update";
            this.btn_MarginUPdate.UseVisualStyleBackColor = true;
            this.btn_MarginUPdate.Click += new System.EventHandler(this.btn_MarginUPdate_Click);
            // 
            // Btt_Exportdata
            // 
            this.Btt_Exportdata.Location = new System.Drawing.Point(551, 5);
            this.Btt_Exportdata.Margin = new System.Windows.Forms.Padding(2);
            this.Btt_Exportdata.Name = "Btt_Exportdata";
            this.Btt_Exportdata.Size = new System.Drawing.Size(94, 32);
            this.Btt_Exportdata.TabIndex = 4;
            this.Btt_Exportdata.Text = "Export Excel";
            this.Btt_Exportdata.UseVisualStyleBackColor = true;
            this.Btt_Exportdata.Click += new System.EventHandler(this.Btt_Exportdata_Click);
            // 
            // btt_ExportPDF
            // 
            this.btt_ExportPDF.Location = new System.Drawing.Point(647, 5);
            this.btt_ExportPDF.Name = "btt_ExportPDF";
            this.btt_ExportPDF.Size = new System.Drawing.Size(100, 32);
            this.btt_ExportPDF.TabIndex = 5;
            this.btt_ExportPDF.Text = "Export PDF";
            this.btt_ExportPDF.UseVisualStyleBackColor = true;
            this.btt_ExportPDF.Click += new System.EventHandler(this.btt_ExportPDF_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.Btt_Exportdata);
            this.panel1.Controls.Add(this.btn_MarginUPdate);
            this.panel1.Controls.Add(this.btt_ExportPDF);
            this.panel1.Location = new System.Drawing.Point(9, 372);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(756, 43);
            this.panel1.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(331, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 32);
            this.button1.TabIndex = 6;
            this.button1.Text = "P/E Ratio";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Margin_Non_Margin_History
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 425);
            this.Controls.Add(this.dg_AllCompany);
            this.Controls.Add(this.panel1);
            this.Name = "Margin_Non_Margin_History";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Margin Non Margin History";
            this.Load += new System.EventHandler(this.Frm_AllCompanyList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFilterExtender1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg_AllCompany)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private GridViewExtensions.DataGridFilterExtender dataGridFilterExtender1;
        private System.Windows.Forms.Button btn_MarginUPdate;
        private System.Windows.Forms.Button Btt_Exportdata;
        private System.Windows.Forms.Button btt_ExportPDF;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dg_AllCompany;
        private System.Windows.Forms.Button button1;
    }
}