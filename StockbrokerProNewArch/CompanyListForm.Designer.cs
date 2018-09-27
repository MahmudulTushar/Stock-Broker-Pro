namespace StockbrokerProNewArch
{
    partial class CompanyListForm
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxNonCDBL = new System.Windows.Forms.ListBox();
            this.listBoxCDBL = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNonCDBL = new System.Windows.Forms.Label();
            this.lblCDBL = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.Red;
            this.btnAdd.Location = new System.Drawing.Point(177, 207);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(44, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = ">>";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.ForeColor = System.Drawing.Color.Red;
            this.btnRemove.Location = new System.Drawing.Point(177, 236);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(44, 23);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.Text = "<<";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DimGray;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Chartreuse;
            this.label1.Location = new System.Drawing.Point(33, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "Non-CDBL Instrument";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listBoxNonCDBL
            // 
            this.listBoxNonCDBL.ForeColor = System.Drawing.Color.SaddleBrown;
            this.listBoxNonCDBL.FormattingEnabled = true;
            this.listBoxNonCDBL.Location = new System.Drawing.Point(32, 47);
            this.listBoxNonCDBL.Name = "listBoxNonCDBL";
            this.listBoxNonCDBL.Size = new System.Drawing.Size(137, 368);
            this.listBoxNonCDBL.TabIndex = 0;
            // 
            // listBoxCDBL
            // 
            this.listBoxCDBL.ForeColor = System.Drawing.Color.SaddleBrown;
            this.listBoxCDBL.FormattingEnabled = true;
            this.listBoxCDBL.Location = new System.Drawing.Point(234, 47);
            this.listBoxCDBL.Name = "listBoxCDBL";
            this.listBoxCDBL.Size = new System.Drawing.Size(136, 368);
            this.listBoxCDBL.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.DimGray;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Chartreuse;
            this.label2.Location = new System.Drawing.Point(234, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "CDBL Instrument";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNonCDBL
            // 
            this.lblNonCDBL.BackColor = System.Drawing.Color.Gray;
            this.lblNonCDBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNonCDBL.ForeColor = System.Drawing.Color.White;
            this.lblNonCDBL.Location = new System.Drawing.Point(32, 415);
            this.lblNonCDBL.Name = "lblNonCDBL";
            this.lblNonCDBL.Size = new System.Drawing.Size(137, 36);
            this.lblNonCDBL.TabIndex = 4;
            this.lblNonCDBL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCDBL
            // 
            this.lblCDBL.BackColor = System.Drawing.Color.Gray;
            this.lblCDBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCDBL.ForeColor = System.Drawing.Color.White;
            this.lblCDBL.Location = new System.Drawing.Point(234, 415);
            this.lblCDBL.Name = "lblCDBL";
            this.lblCDBL.Size = new System.Drawing.Size(136, 34);
            this.lblCDBL.TabIndex = 4;
            this.lblCDBL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CompanyListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 461);
            this.Controls.Add(this.listBoxCDBL);
            this.Controls.Add(this.listBoxNonCDBL);
            this.Controls.Add(this.lblCDBL);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblNonCDBL);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "CompanyListForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Instrument Share Type Change";
            this.Load += new System.EventHandler(this.CompanyListForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxNonCDBL;
        private System.Windows.Forms.ListBox listBoxCDBL;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNonCDBL;
        private System.Windows.Forms.Label lblCDBL;
    }
}