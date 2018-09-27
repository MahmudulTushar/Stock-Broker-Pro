using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using BusinessAccessLayer.BO;

namespace StockbrokerProNewArch
{
    public partial class frmExpense_CategoryEntry : Form
    {
        public frmExpense_CategoryEntry()
        {
            InitializeComponent();
        }
        private GlobalVariableBO.ModeSelection currentMode = GlobalVariableBO.ModeSelection.NewMode;
        private int _CategoryIdForUpdate = 0;
        private int _CategoryIdForDelete = 0;
        private void btnCancel_Click(object sender, EventArgs e)
        {
             this.Close();
        }

        private void btnSaveCategory_Click(object sender, EventArgs e)
        {
            SaveCategoryInfo();
        }

        private Expense_CategoryEntryBO InitializeCategoryEntryBO()
        {
            Expense_CategoryEntryBO categoryEntryBo=new Expense_CategoryEntryBO();
            categoryEntryBo.Category_Name = txtCategory.Text.Trim();
            categoryEntryBo.Category_Type_ID = Convert.ToInt32(ddlCategorytype.SelectedValue.ToString());
            categoryEntryBo.Sub_Category = txtSubCategory.Text.Trim();
            return categoryEntryBo;
        }
        private void SaveCategoryInfo()
        {
            try
            {
                Expense_CategoryEntryBO categoryEntryBO=new Expense_CategoryEntryBO();
                categoryEntryBO = InitializeCategoryEntryBO();

                Expense_CategoryEntryBAL CategoryBal = new Expense_CategoryEntryBAL();
                switch (currentMode)
                {
                    case GlobalVariableBO.ModeSelection.NewMode:
                        try
                        {
                            if (IsValidateField())
                            {
                                CategoryBal.SaveCategory(categoryEntryBO);
                                MessageBox.Show("Category Saved Successfully", "Successfully Saved.");
                                ClearAll();
                                LoadDataIntoGrid();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Category Saved unsuccessful because of the error :" + ex.Message);
                        }
                        break;
                    case GlobalVariableBO.ModeSelection.UpdateMode:
                        try
                        {
                            CategoryBal.Update(categoryEntryBO, _CategoryIdForUpdate);
                            MessageBox.Show("Category has successfully updated.", "Success.");
                            LoadDataIntoGrid();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Category update unsuccessful because of the error :" + ex.Message);
                        }
                        break;
                    case GlobalVariableBO.ModeSelection.NoneMode:
                        MessageBox.Show("You have select none mode.Please select a mode.");
                        break;
                }

            }
            catch (Exception exp)
            {
                MessageBox.Show("Error Occured."+exp.Message);
            }
        }
        private bool IsValidateField()
        {
            if (IsDuplicateCategory())
            {
                MessageBox.Show("Category Information Allready exist.");
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool IsDuplicateCategory()
        {
            Expense_CategoryEntryBAL CategoryBal = new Expense_CategoryEntryBAL();
            if (CategoryBal.CheckCategoryDuplicate(txtCategory.Text.Trim()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        private void frmCategoryEntry_Load(object sender, EventArgs e)
        {
            LoadComboData();
            LoadDataIntoGrid();
            ClearAll();
        }

        private void LoadComboData()
        {
            Expense_CategoryEntryBAL CategoryBal = new Expense_CategoryEntryBAL();
            DataTable datatable = CategoryBal.GetAllCategoryType();
            ddlCategorytype.ValueMember = datatable.Columns[0].ToString();
            ddlCategorytype.DisplayMember = datatable.Columns[1].ToString();
            ddlCategorytype.DataSource = datatable;
        }
        private void LoadDataIntoGrid()
        {
            Expense_CategoryEntryBAL CategoryBal = new Expense_CategoryEntryBAL();
            DataTable datatable = CategoryBal.GetAllCategory();
            dgvCategory.DataSource = datatable;
            dgvCategory.Columns[0].Visible = false;
            dgvCategory.Columns[2].Visible = false;
            lblTotalRecord.Text = "Total: " + dgvCategory.Rows.Count;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            currentMode = GlobalVariableBO.ModeSelection.NewMode;
            gbCategory.Text = "Category Entry";
            btnNew.Enabled = false;
            btnNew.BackColor = Color.Gray;
            btnUpdate.Enabled = true;
            btnUpdate.ResetBackColor();
            ClearAll();
        }

        private void ClearAll()
        {
            txtCategory.Text = "";
            ddlCategorytype.SelectedIndex = -1;
            txtSubCategory.Text = string.Empty;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            currentMode = GlobalVariableBO.ModeSelection.UpdateMode;
            gbCategory.Text = "Edit Category";
            btnUpdate.Enabled = false;
            btnUpdate.BackColor = Color.Gray;
            btnNew.Enabled = true;
            btnNew.ResetBackColor();
            LoadDataForUpdate();
        
        }

        private void LoadDataForUpdate()
        {
            foreach (DataGridViewRow row in this.dgvCategory.SelectedRows)
            {
                _CategoryIdForUpdate = Convert.ToInt32(dgvCategory[0, row.Index].Value);
                txtCategory.Text = dgvCategory[1, row.Index].Value.ToString();
                ddlCategorytype.SelectedValue = dgvCategory[2, row.Index].Value.ToString();
                txtSubCategory.Text = dgvCategory[4, row.Index].Value.ToString();
            }
        }

        private void dgvCategory_SelectionChanged(object sender, EventArgs e)
        {

            if (currentMode == GlobalVariableBO.ModeSelection.UpdateMode)
            {
                LoadDataForUpdate();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Expense_CategoryEntryBAL CategoryBal = new Expense_CategoryEntryBAL();
            if (_CategoryIdForDelete != 0)
            {
                if (DialogResult.Yes == MessageBox.Show("Do you want to delete?", "Delete confirmation", MessageBoxButtons.YesNo))
                {
                    CategoryBal.DeleteCategory(_CategoryIdForDelete);
                    MessageBox.Show("Delete Successfull", "Delete confirmation");
                    LoadDataIntoGrid();
                }
            }
            else
            {
                MessageBox.Show("Please select an item to delete", "Delete item check");
            }
        }

        private void dgvCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                DataGridViewRow dr = dgvCategory.CurrentRow;
                _CategoryIdForDelete = Convert.ToInt32(dr.Cells[0].Value.ToString());

            }
            catch (Exception)
            {
                _CategoryIdForDelete = 0;
            }

        }
    }
}
