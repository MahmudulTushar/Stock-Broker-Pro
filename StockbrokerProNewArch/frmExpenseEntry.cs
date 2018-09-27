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
    public partial class frmExpenseEntry : Form
    {
        public frmExpenseEntry()
        {
            InitializeComponent();
        }
        private GlobalVariableBO.ModeSelection currentMode = GlobalVariableBO.ModeSelection.NewMode;
        private int _ExpenseIdForUpdate = 0;
        private int _ExpenseIdForDelete = 0;
        private void btnCancel_Click(object sender, EventArgs e)
        {
             this.Close();
        }

        private void btnSaveExpense_Click(object sender, EventArgs e)
        {
            SaveExpenseInfo();
        }

        private ExpenseEntryBO InitializeExpenseEntryBO()
        {
            ExpenseEntryBO expenseEntryBO = new ExpenseEntryBO();
            expenseEntryBO.Category_ID= Convert.ToInt32(ddlCategoryName.SelectedValue.ToString());
            expenseEntryBO.Expense_Description =txtExpenseDescription.Text.Trim();
            expenseEntryBO.Expense_Frequency = ddlExpenseFrequency.SelectedValue.ToString();
            return expenseEntryBO;
        }
        private void SaveExpenseInfo()
        {
            try
            {
                ExpenseEntryBO expenseEntryBO = new ExpenseEntryBO();
                expenseEntryBO = InitializeExpenseEntryBO();

                ExpenseEntryBAL expenseEntryBALBal = new ExpenseEntryBAL();
                switch (currentMode)
                {
                    case GlobalVariableBO.ModeSelection.NewMode:
                        try
                        {
                            //if (IsValidateField())
                            //{
                                expenseEntryBALBal.SaveExpense(expenseEntryBO);
                                MessageBox.Show("Expense Saved Successfully", "Successfully Saved.");
                                ClearAll();
                                LoadDataIntoGrid();
                           // }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Expense Saved unsuccessful because of the error :" + ex.Message);
                        }
                        break;
                    case GlobalVariableBO.ModeSelection.UpdateMode:
                        try
                        {
                            expenseEntryBALBal.Update(expenseEntryBO, _ExpenseIdForUpdate);
                            MessageBox.Show("Expense has successfully updated.", "Success.");
                            LoadDataIntoGrid();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Expense update unsuccessful because of the error :" + ex.Message);
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
            if (IsDuplicateExpense())
            {
                MessageBox.Show("Category Information Allready exist.");
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool IsDuplicateExpense()
        {
            ExpenseEntryBAL expenseEntryBALBal = new ExpenseEntryBAL();
            if (expenseEntryBALBal.CheckExpenseDuplicate(Convert.ToInt32(ddlCategoryName.SelectedValue.ToString())))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void LoadComboData()
        {
            ExpenseEntryBAL expenseEntryBALBal = new ExpenseEntryBAL();
            DataTable dtCategory=new DataTable();
            DataTable dtExpenseFrequency=new DataTable();
            dtCategory = expenseEntryBALBal.GetCategory();
            dtExpenseFrequency = expenseEntryBALBal.GetExpenseFrequency();

            ddlCategoryName.ValueMember = dtCategory.Columns[0].ToString();
            ddlCategoryName.DisplayMember = dtCategory.Columns[2].ToString();

            ddlExpenseFrequency.ValueMember = dtExpenseFrequency.Columns[0].ToString();
            ddlExpenseFrequency.DisplayMember = dtExpenseFrequency.Columns[1].ToString();

            ddlCategoryName.DataSource = dtCategory;
            ddlExpenseFrequency.DataSource = dtExpenseFrequency;
        }
        private void frmExpenseEntry_Load(object sender, EventArgs e)
        {
            LoadComboData();
            LoadDataIntoGrid();
            ClearAll();
        }

        private void LoadDataIntoGrid()
        {
            ExpenseEntryBAL expenseEntryBALBal = new ExpenseEntryBAL();
            DataTable datatable = expenseEntryBALBal.GetAllExpense();
            dgvExpense.DataSource = datatable;
            dgvExpense.Columns[0].Visible = false;
            dgvExpense.Columns[3].Visible = false;
            lblTotalRecord.Text = "Total: " + dgvExpense.Rows.Count;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            currentMode = GlobalVariableBO.ModeSelection.NewMode;
            gbCategory.Text = "Expense Entry";
            btnNew.Enabled = false;
            btnNew.BackColor = Color.Gray;
            btnUpdate.Enabled = true;
            btnUpdate.ResetBackColor();
            ClearAll();
        }

        private void ClearAll()
        {
            ddlCategoryName.SelectedIndex = -1;
            txtExpenseDescription.Text = string.Empty;
            ddlExpenseFrequency.SelectedIndex = -1;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            currentMode = GlobalVariableBO.ModeSelection.UpdateMode;
            gbCategory.Text = "Edit Expense";
            btnUpdate.Enabled = false;
            btnUpdate.BackColor = Color.Gray;
            btnNew.Enabled = true;
            btnNew.ResetBackColor();
            LoadDataForUpdate();
        
        }

        private void LoadDataForUpdate()
        {
            foreach (DataGridViewRow row in this.dgvExpense.SelectedRows)
            {
                _ExpenseIdForUpdate = Convert.ToInt32(dgvExpense[0, row.Index].Value);
                ddlCategoryName.Text = dgvExpense[1, row.Index].Value.ToString();
                txtExpenseDescription.Text = dgvExpense[2, row.Index].Value.ToString();
                ddlExpenseFrequency.SelectedValue = dgvExpense[3, row.Index].Value.ToString();
            }
        }

        private void dgvExpense_SelectionChanged(object sender, EventArgs e)
        {

            if (currentMode == GlobalVariableBO.ModeSelection.UpdateMode)
            {
                LoadDataForUpdate();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ExpenseEntryBAL expenseEntryBALBal = new ExpenseEntryBAL();
            if (_ExpenseIdForDelete != 0)
            {
                if (DialogResult.Yes == MessageBox.Show("Do you want to delete?", "Delete confirmation", MessageBoxButtons.YesNo))
                {
                    expenseEntryBALBal.DeleteExpense(_ExpenseIdForDelete);
                    MessageBox.Show("Delete Successfull", "Delete confirmation");
                    LoadDataIntoGrid();
                }
            }
            else
            {
                MessageBox.Show("Please select an item to delete", "Delete item check");
            }
        }

        private void dgvExpense_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                DataGridViewRow dr = dgvExpense.CurrentRow;
                _ExpenseIdForDelete = Convert.ToInt32(dr.Cells[0].Value.ToString());

            }
            catch (Exception)
            {
                _ExpenseIdForDelete = 0;
            }

        }
    }
}
