namespace StockbrokerProNewArch
{
    partial class CompanySelectionForPrice
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
            this.listBoxVisibleCompany = new System.Windows.Forms.ListBox();
            this.listBoxHiddenCompany = new System.Windows.Forms.ListBox();
            this.lblVisible = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblHidden = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxVisibleCompany
            // 
            this.listBoxVisibleCompany.ForeColor = System.Drawing.Color.SaddleBrown;
            this.listBoxVisibleCompany.FormattingEnabled = true;
            this.listBoxVisibleCompany.Location = new System.Drawing.Point(30, 33);
            this.listBoxVisibleCompany.Name = "listBoxVisibleCompany";
            this.listBoxVisibleCompany.Size = new System.Drawing.Size(136, 459);
            this.listBoxVisibleCompany.TabIndex = 8;
            // 
            // listBoxHiddenCompany
            // 
            this.listBoxHiddenCompany.ForeColor = System.Drawing.Color.SaddleBrown;
            this.listBoxHiddenCompany.FormattingEnabled = true;
            this.listBoxHiddenCompany.Location = new System.Drawing.Point(222, 33);
            this.listBoxHiddenCompany.Name = "listBoxHiddenCompany";
            this.listBoxHiddenCompany.Size = new System.Drawing.Size(137, 459);
            this.listBoxHiddenCompany.TabIndex = 5;
            // 
            // lblVisible
            // 
            this.lblVisible.BackColor = System.Drawing.Color.Gray;
            this.lblVisible.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVisible.ForeColor = System.Drawing.Color.White;
            this.lblVisible.Location = new System.Drawing.Point(30, 492);
            this.lblVisible.Name = "lblVisible";
            this.lblVisible.Size = new System.Drawing.Size(136, 34);
            this.lblVisible.TabIndex = 9;
            this.lblVisible.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.DimGray;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Chartreuse;
            this.label2.Location = new System.Drawing.Point(30, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 21);
            this.label2.TabIndex = 10;
            this.label2.Text = "Visible Company";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHidden
            // 
            this.lblHidden.BackColor = System.Drawing.Color.Gray;
            this.lblHidden.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHidden.ForeColor = System.Drawing.Color.White;
            this.lblHidden.Location = new System.Drawing.Point(222, 492);
            this.lblHidden.Name = "lblHidden";
            this.lblHidden.Size = new System.Drawing.Size(137, 36);
            this.lblHidden.TabIndex = 11;
            this.lblHidden.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DimGray;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Chartreuse;
            this.label1.Location = new System.Drawing.Point(223, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 21);
            this.label1.TabIndex = 12;
            this.label1.Text = "Hidden Company ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnRemove
            // 
            this.btnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.ForeColor = System.Drawing.Color.Red;
            this.btnRemove.Location = new System.Drawing.Point(172, 225);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(44, 23);
            this.btnRemove.TabIndex = 7;
            this.btnRemove.Text = "<<";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.Red;
            this.btnAdd.Location = new System.Drawing.Point(172, 196);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(44, 23);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = ">>";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // CompanySelectionForPrice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 532);
            this.Controls.Add(this.listBoxVisibleCompany);
            this.Controls.Add(this.listBoxHiddenCompany);
            this.Controls.Add(this.lblVisible);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblHidden);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.MaximizeBox = false;
            this.Name = "CompanySelectionForPrice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Company Selection for Latest Price";
            this.Load += new System.EventHandler(this.CompanySelectionForPrice_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxVisibleCompany;
        private System.Windows.Forms.ListBox listBoxHiddenCompany;
        private System.Windows.Forms.Label lblVisible;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblHidden;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAdd;
    }
}