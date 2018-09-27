using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using DataAccessLayer;

namespace StockbrokerProNewArch
{
    public partial class FromCategoryEntry : Form
    {

        //select * from SBP_Expense_Category_Type
        //select * from SBP_Expense_Category_Lookup
        //select * from SBP_Expense_Lookup
        //select * from SBP_Expense_Sub_Category_Type


        DbConnection _dbConnection = new DbConnection();
        CategoryEntryBAL catEBAL = new CategoryEntryBAL();
        public FromCategoryEntry()
        {
            InitializeComponent();
        }

        private void FromCategoryEntry_Load(object sender, EventArgs e)
        {
            LoadCmbCategoryType();
            LoadcmbCatagoryForSub();
            LoadcmbFrequencyName();
            LoadcmbExpenseType();

            LoaddgvSubCategory();
            LoadDgvCategoryEntry();
            txtCategoryName.Text = "";
        }

      

        private void LoadDgvCategoryEntry()
        {
            dgvCategoryEntry.DataSource = catEBAL.getCategoryTypeInformation();            
        }

        private void LoadCmbCategoryType()
        {
            DataTable dt;           
            dt = catEBAL.getCategoryType();
            cmbCategoryType.DataSource = dt;
            cmbCategoryType.DisplayMember = "Category_Type";
            cmbCategoryType.ValueMember = "ID";
            cmbCategoryType.Text = "Select Category Type";
        }

        private void LoadcmbCatagoryForSub()
        {
            DataTable dt;
            dt = catEBAL.getCategoryTypeForSub();
            cmbCatagoryForSub.DataSource = dt;
            cmbCatagoryForSub.DisplayMember = "Name";
            cmbCatagoryForSub.ValueMember = "ID";
            cmbCatagoryForSub.Text = "Select Category Name";

        }

        private void LoadcmbFrequencyName()
        {
            DataTable dt;
            dt = catEBAL.getFrequencyName();
            cmbFrequencyName.DataSource = dt;
            cmbFrequencyName.DisplayMember = "FName";
            cmbFrequencyName.ValueMember = "ID";
            cmbFrequencyName.Text = "Select Frequency Name";
        }

        private void LoadcmbExpenseType()
        {
            DataTable dt;
            dt = catEBAL.getExpenseType();
            cmbExpenseType.DataSource = dt;
            cmbExpenseType.DisplayMember = "expType";
            cmbExpenseType.ValueMember = "ID";
            cmbExpenseType.Text = "Select Expense Type";
        }

        private void LoaddgvSubCategory()
        {
            dgvSubCategory.DataSource = catEBAL.getSubCategoryType();   
        }
        private bool validationProcessForCategoryEntry()
        {
            if (cmbCategoryType.Text == "Select Category Type")
            {
                MessageBox.Show("Please Select Category Type.","Information...",MessageBoxButtons.OK,MessageBoxIcon.Information);
                cmbCategoryType.Focus();
                return true;
            }
            else if(txtCategoryName.Text == string.Empty)
            {
                MessageBox.Show("Please Write New Category Name.","Information...",MessageBoxButtons.OK,MessageBoxIcon.Information);
                txtCategoryName.Focus();
                return true;
            }
            else return false;
        }
       

        private void btnSaveCategoryEntry_Click(object sender, EventArgs e)
        {
            if (validationProcessForCategoryEntry())
                return;
            catEBAL.SaveCategoryType(txtCategoryName.Text.Trim()
                                    , cmbCategoryType.SelectedValue.ToString());

            MessageBox.Show("Saved Information Successfully...");
            FromCategoryEntry_Load(sender, e);
        }

        private bool validationProcessForSub()
        {
            if (cmbCatagoryForSub.Text == "Select Category Name")
            {
                MessageBox.Show("Please Select Category Name.", "Information...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbCatagoryForSub.Focus();
                return true;
            }
            else if (cmbFrequencyName.Text == "Select Frequency Name")
            {
                MessageBox.Show("Please Select Frequency Name.","Information...",MessageBoxButtons.OK,MessageBoxIcon.Information);
                cmbFrequencyName.Focus();
                return true;
            }
            else if (cmbExpenseType.Text == "Select Expense Type")
            {
                MessageBox.Show("Please Select Expense Type.", "Information...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbExpenseType.Focus();
                return true;
            }
            else if (txtSubCategoryName.Text == string.Empty)
            {
                MessageBox.Show("Please Write Sub Category Name.", "Information...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSubCategoryName.Focus();
                return true;
            }
            else return false;
        }

        private void btnSaveForSub_Click(object sender, EventArgs e)
        {
            if (validationProcessForSub())
                return;

            try
            {
                int cID = Convert.ToInt32(cmbCatagoryForSub.SelectedValue.ToString());
                string CName = txtSubCategoryName.Text.Trim();
                int fID = Convert.ToInt32(cmbFrequencyName.SelectedValue.ToString());
                int expTypeID = Convert.ToInt32(cmbExpenseType.SelectedValue.ToString());              

                catEBAL.SaveCategoryName(cID, CName, fID, expTypeID);
                MessageBox.Show("Saved Information Successfully...");
                txtSubCategoryName.Text = "";
                LoaddgvSubCategory();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Save Denied Because : "+ex);
            }
        }

        private void btnRefreshSub_Click(object sender, EventArgs e)
        {
            LoadcmbCatagoryForSub();
            LoadcmbFrequencyName();
            LoadcmbExpenseType();
            LoaddgvSubCategory();
            txtSubCategoryName.Text = "";
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        
        {
            if (tabControl1.SelectedTab.Name == "tbCategoryEntry")
            {
                //MessageBox.Show("This is Category Entry page");
            }
            else if(tabControl1.SelectedTab.Name == "tbSubCategoryEntry")
            {
                //MessageBox.Show("This is Sub Category Entry page");
                btnRefreshSub_Click(sender, e);
            }
            else if (tabControl1.SelectedTab.Name == "tbSub_SubCategoryEntry")
            {
                btnRefreshSubSub_Click(sender, e);
            }
        }

        //private void btnRefreshSubSub_Click(object sender, EventArgs e)
        //{
        //    txtSubSubExpense.Text = "";
        //    LoadcmbExpenseName();
        //    LoaddgvSubSubExpenseName();
        //}

        private void LoadcmbExpenseName()
        {
            DataTable dt;
            dt = catEBAL.getExpenseNameForSub();
            cmbExpenseName.DataSource = dt;
            cmbExpenseName.DisplayMember = "ExpenseName";
            cmbExpenseName.ValueMember = "ID";
            cmbExpenseName.Text = "Select Expense Name";
        }


        private void LoaddgvSubSubExpenseName()
        {
            dgvSubSubExpenseName.DataSource = catEBAL.getSubSubExpenseName();
        }

        private bool validationForSubSub()
        {
            if (cmbExpenseName.Text == "Select Expense Name")
            {
                MessageBox.Show("Please Select Expense Name.", "Information...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbExpenseName.Focus();
                return true;
            }
            else if (txtSubSubExpense.Text == string.Empty)
            {
                MessageBox.Show("Please Write Sub Expense Name.", "Information...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSubSubExpense.Focus();
                return true;
            }
            else return false;
        }


        private void btnSaveSubSub_Click(object sender, EventArgs e)
        {
            if (validationForSubSub())
                return;

            try
            {
                DataTable dt;
                int expID = Convert.ToInt32(cmbExpenseName.SelectedValue.ToString());
                int catID = 0;
                string CatIDQuery = @"select Category_ID from SBP_Expense_Lookup where Expense_ID=" + expID + "";
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(CatIDQuery);
                catID = Convert.ToInt32(dt.Rows[0][0].ToString());

                catEBAL.SaveSubExpenseName(expID, txtSubSubExpense.Text.Trim(), catID);
                MessageBox.Show("Saved Information Successfully...");
                btnRefreshSubSub_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Save Denied. Because : " + ex);
            }
        }
        private void btnRefreshSubSub_MouseHover(object sender, EventArgs e)
        {
            btnRefreshSubSub.FlatStyle = FlatStyle.Flat;             
            btnRefreshSubSub.FlatAppearance.BorderColor = Color.Red;
            btnRefreshSubSub.FlatAppearance.BorderSize = 1; 
        }

        private void btnRefreshSubSub_MouseLeave(object sender, EventArgs e)
        {
            btnRefreshSubSub.FlatStyle = FlatStyle.Standard;
            btnRefreshSubSub.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonFace;
            btnRefreshSubSub.FlatAppearance.BorderSize = 1;  
        }

        private void btnRefreshSubSub_Click(object sender, EventArgs e)
        {
            txtSubSubExpense.Text = "";
            LoadcmbExpenseName();
            LoaddgvSubSubExpenseName();
        }
    }
}
