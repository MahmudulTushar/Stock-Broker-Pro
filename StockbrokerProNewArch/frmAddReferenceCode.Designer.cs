namespace StockbrokerProNewArch
{
    partial class frmAddReferenceCode
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtClientStatus = new System.Windows.Forms.TextBox();
            this.txtBOID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFinalCustCode = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblClientCode = new System.Windows.Forms.Label();
            this.txtClientCode = new System.Windows.Forms.TextBox();
            this.btnAddCode = new System.Windows.Forms.Button();
            this.dgvReferenceCode = new System.Windows.Forms.DataGridView();
            this.ddlCriteriaID = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReferenceCode)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtClientStatus);
            this.groupBox2.Controls.Add(this.txtBOID);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtFinalCustCode);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtName);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(10, 52);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(265, 114);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Client Information";
            // 
            // txtClientStatus
            // 
            this.txtClientStatus.BackColor = System.Drawing.Color.Gainsboro;
            this.txtClientStatus.ForeColor = System.Drawing.Color.SlateGray;
            this.txtClientStatus.Location = new System.Drawing.Point(118, 87);
            this.txtClientStatus.Name = "txtClientStatus";
            this.txtClientStatus.Size = new System.Drawing.Size(141, 20);
            this.txtClientStatus.TabIndex = 3;
            // 
            // txtBOID
            // 
            this.txtBOID.BackColor = System.Drawing.Color.Gainsboro;
            this.txtBOID.ForeColor = System.Drawing.Color.SlateGray;
            this.txtBOID.Location = new System.Drawing.Point(118, 39);
            this.txtBOID.Name = "txtBOID";
            this.txtBOID.Size = new System.Drawing.Size(141, 20);
            this.txtBOID.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.DimGray;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(9, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Client Code   :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.DimGray;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(9, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Client Name  :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFinalCustCode
            // 
            this.txtFinalCustCode.BackColor = System.Drawing.Color.Gainsboro;
            this.txtFinalCustCode.ForeColor = System.Drawing.Color.SlateGray;
            this.txtFinalCustCode.Location = new System.Drawing.Point(118, 15);
            this.txtFinalCustCode.Name = "txtFinalCustCode";
            this.txtFinalCustCode.Size = new System.Drawing.Size(141, 20);
            this.txtFinalCustCode.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.DimGray;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(9, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 20);
            this.label6.TabIndex = 2;
            this.label6.Text = "Client Status :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.DimGray;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(9, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Client BOID   :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.Gainsboro;
            this.txtName.ForeColor = System.Drawing.Color.SlateGray;
            this.txtName.Location = new System.Drawing.Point(118, 63);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(141, 20);
            this.txtName.TabIndex = 3;
            // 
            // lblClientCode
            // 
            this.lblClientCode.BackColor = System.Drawing.Color.DimGray;
            this.lblClientCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClientCode.ForeColor = System.Drawing.Color.White;
            this.lblClientCode.Location = new System.Drawing.Point(19, 26);
            this.lblClientCode.Name = "lblClientCode";
            this.lblClientCode.Size = new System.Drawing.Size(103, 20);
            this.lblClientCode.TabIndex = 3;
            this.lblClientCode.Text = "Client Code :";
            this.lblClientCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtClientCode
            // 
            this.txtClientCode.Location = new System.Drawing.Point(128, 26);
            this.txtClientCode.Name = "txtClientCode";
            this.txtClientCode.Size = new System.Drawing.Size(141, 20);
            this.txtClientCode.TabIndex = 0;
            this.txtClientCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtClientCode_KeyDown);
            // 
            // btnAddCode
            // 
            this.btnAddCode.Location = new System.Drawing.Point(47, 172);
            this.btnAddCode.Name = "btnAddCode";
            this.btnAddCode.Size = new System.Drawing.Size(75, 23);
            this.btnAddCode.TabIndex = 5;
            this.btnAddCode.Text = "Add";
            this.btnAddCode.UseVisualStyleBackColor = true;
            this.btnAddCode.Click += new System.EventHandler(this.btnAddCode_Click);
            // 
            // dgvReferenceCode
            // 
            this.dgvReferenceCode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReferenceCode.Location = new System.Drawing.Point(10, 201);
            this.dgvReferenceCode.Name = "dgvReferenceCode";
            this.dgvReferenceCode.Size = new System.Drawing.Size(265, 150);
            this.dgvReferenceCode.TabIndex = 6;
            // 
            // ddlCriteriaID
            // 
            this.ddlCriteriaID.FormattingEnabled = true;
            this.ddlCriteriaID.Location = new System.Drawing.Point(127, 27);
            this.ddlCriteriaID.Name = "ddlCriteriaID";
            this.ddlCriteriaID.Size = new System.Drawing.Size(143, 21);
            this.ddlCriteriaID.TabIndex = 0;
            this.ddlCriteriaID.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(138, 172);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmAddReferenceCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 354);
            this.Controls.Add(this.ddlCriteriaID);
            this.Controls.Add(this.dgvReferenceCode);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAddCode);
            this.Controls.Add(this.txtClientCode);
            this.Controls.Add(this.lblClientCode);
            this.Controls.Add(this.groupBox2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(305, 388);
            this.MinimumSize = new System.Drawing.Size(305, 388);
            this.Name = "frmAddReferenceCode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Reference Code";
            this.Load += new System.EventHandler(this.frmAddReferenceCode_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAddReferenceCode_FormClosed);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReferenceCode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtClientStatus;
        private System.Windows.Forms.TextBox txtBOID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFinalCustCode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblClientCode;
        private System.Windows.Forms.TextBox txtClientCode;
        private System.Windows.Forms.Button btnAddCode;
        private System.Windows.Forms.DataGridView dgvReferenceCode;
        private System.Windows.Forms.ComboBox ddlCriteriaID;
        private System.Windows.Forms.Button btnClose;
    }
}