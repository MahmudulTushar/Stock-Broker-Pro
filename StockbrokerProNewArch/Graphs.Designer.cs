namespace StockbrokerProNewArch
{
    partial class Graphs
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
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkLastValue = new System.Windows.Forms.CheckBox();
            this.chkTotalVolume = new System.Windows.Forms.CheckBox();
            this.chkTotalTrade = new System.Windows.Forms.CheckBox();
            this.chkClosePrice = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.zg1 = new ZedGraph.ZedGraphControl();
            this.btnDrawGraph = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ddlCompanyName = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ddlGraphStyle = new System.Windows.Forms.ComboBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "To";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkLastValue);
            this.groupBox2.Controls.Add(this.chkTotalVolume);
            this.groupBox2.Controls.Add(this.chkTotalTrade);
            this.groupBox2.Controls.Add(this.chkClosePrice);
            this.groupBox2.Location = new System.Drawing.Point(16, 237);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(161, 227);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Graph For";
            // 
            // chkLastValue
            // 
            this.chkLastValue.AutoSize = true;
            this.chkLastValue.ForeColor = System.Drawing.Color.Black;
            this.chkLastValue.Location = new System.Drawing.Point(26, 97);
            this.chkLastValue.Name = "chkLastValue";
            this.chkLastValue.Size = new System.Drawing.Size(76, 17);
            this.chkLastValue.TabIndex = 0;
            this.chkLastValue.Text = "Last Value";
            this.chkLastValue.UseVisualStyleBackColor = true;
            // 
            // chkTotalVolume
            // 
            this.chkTotalVolume.AutoSize = true;
            this.chkTotalVolume.ForeColor = System.Drawing.Color.Blue;
            this.chkTotalVolume.Location = new System.Drawing.Point(26, 74);
            this.chkTotalVolume.Name = "chkTotalVolume";
            this.chkTotalVolume.Size = new System.Drawing.Size(111, 17);
            this.chkTotalVolume.TabIndex = 0;
            this.chkTotalVolume.Text = "Last Total Volume";
            this.chkTotalVolume.UseVisualStyleBackColor = true;
            // 
            // chkTotalTrade
            // 
            this.chkTotalTrade.AutoSize = true;
            this.chkTotalTrade.ForeColor = System.Drawing.Color.Green;
            this.chkTotalTrade.Location = new System.Drawing.Point(26, 51);
            this.chkTotalTrade.Name = "chkTotalTrade";
            this.chkTotalTrade.Size = new System.Drawing.Size(104, 17);
            this.chkTotalTrade.TabIndex = 0;
            this.chkTotalTrade.Text = "Last Total Trade";
            this.chkTotalTrade.UseVisualStyleBackColor = true;
            // 
            // chkClosePrice
            // 
            this.chkClosePrice.AutoSize = true;
            this.chkClosePrice.Checked = true;
            this.chkClosePrice.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkClosePrice.ForeColor = System.Drawing.Color.Red;
            this.chkClosePrice.Location = new System.Drawing.Point(26, 28);
            this.chkClosePrice.Name = "chkClosePrice";
            this.chkClosePrice.Size = new System.Drawing.Size(102, 17);
            this.chkClosePrice.TabIndex = 0;
            this.chkClosePrice.Text = "Last Close Price";
            this.chkClosePrice.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpDateTo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpDateFrom);
            this.groupBox1.Location = new System.Drawing.Point(16, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(161, 99);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Date Range";
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.CalendarForeColor = System.Drawing.Color.Green;
            this.dtpDateTo.CustomFormat = "dd MMM, yyyy";
            this.dtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateTo.Location = new System.Drawing.Point(54, 54);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(94, 20);
            this.dtpDateTo.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(112, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "(From)";
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.CalendarForeColor = System.Drawing.Color.Green;
            this.dtpDateFrom.CustomFormat = "dd MMM, yyyy";
            this.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateFrom.Location = new System.Drawing.Point(12, 28);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(94, 20);
            this.dtpDateFrom.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.zg1);
            this.panel2.Location = new System.Drawing.Point(209, 13);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(677, 511);
            this.panel2.TabIndex = 3;
            // 
            // zg1
            // 
            this.zg1.EditButtons = System.Windows.Forms.MouseButtons.Left;
            this.zg1.Location = new System.Drawing.Point(3, 3);
            this.zg1.Name = "zg1";
            this.zg1.PanModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.None)));
            this.zg1.ScrollGrace = 0;
            this.zg1.ScrollMaxX = 0;
            this.zg1.ScrollMaxY = 0;
            this.zg1.ScrollMaxY2 = 0;
            this.zg1.ScrollMinX = 0;
            this.zg1.ScrollMinY = 0;
            this.zg1.ScrollMinY2 = 0;
            this.zg1.Size = new System.Drawing.Size(669, 503);
            this.zg1.TabIndex = 2;
            // 
            // btnDrawGraph
            // 
            this.btnDrawGraph.Location = new System.Drawing.Point(16, 470);
            this.btnDrawGraph.Name = "btnDrawGraph";
            this.btnDrawGraph.Size = new System.Drawing.Size(161, 25);
            this.btnDrawGraph.TabIndex = 3;
            this.btnDrawGraph.Text = "Draw Graph";
            this.btnDrawGraph.UseVisualStyleBackColor = true;
            this.btnDrawGraph.Click += new System.EventHandler(this.btnDrawGraph_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ddlCompanyName);
            this.groupBox4.Location = new System.Drawing.Point(16, 117);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(161, 54);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Instrument";
            // 
            // ddlCompanyName
            // 
            this.ddlCompanyName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlCompanyName.ForeColor = System.Drawing.Color.Green;
            this.ddlCompanyName.FormattingEnabled = true;
            this.ddlCompanyName.Location = new System.Drawing.Point(12, 19);
            this.ddlCompanyName.Name = "ddlCompanyName";
            this.ddlCompanyName.Size = new System.Drawing.Size(136, 21);
            this.ddlCompanyName.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnDrawGraph);
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(9, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(194, 511);
            this.panel1.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ddlGraphStyle);
            this.groupBox3.Location = new System.Drawing.Point(16, 177);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(161, 54);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Graph Styles";
            // 
            // ddlGraphStyle
            // 
            this.ddlGraphStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlGraphStyle.ForeColor = System.Drawing.Color.Green;
            this.ddlGraphStyle.FormattingEnabled = true;
            this.ddlGraphStyle.Items.AddRange(new object[] {
            "By Drawing Curve",
            "By Drawing Bar"});
            this.ddlGraphStyle.Location = new System.Drawing.Point(12, 19);
            this.ddlGraphStyle.Name = "ddlGraphStyle";
            this.ddlGraphStyle.Size = new System.Drawing.Size(136, 21);
            this.ddlGraphStyle.TabIndex = 0;
            // 
            // Graphs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 537);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "Graphs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Analysis on Instrument";
            this.Load += new System.EventHandler(this.Graphs_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkLastValue;
        private System.Windows.Forms.CheckBox chkTotalVolume;
        private System.Windows.Forms.CheckBox chkTotalTrade;
        private System.Windows.Forms.CheckBox chkClosePrice;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpDateTo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpDateFrom;
        private System.Windows.Forms.Panel panel2;
        private ZedGraph.ZedGraphControl zg1;
        private System.Windows.Forms.Button btnDrawGraph;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox ddlCompanyName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox ddlGraphStyle;
    }
}