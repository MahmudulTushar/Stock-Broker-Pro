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
    public partial class frmExpense_Frequency_Entry : Form
    {
        public frmExpense_Frequency_Entry()
        {
            InitializeComponent();
        }
        private GlobalVariableBO.ModeSelection currentMode = GlobalVariableBO.ModeSelection.NewMode;
        private int _OccTypeIdForUpdate = 0;
        private int _OccTypeIdForDelete = 0;
        private void btnCancel_Click(object sender, EventArgs e)
        {
             this.Close();
        }

        private void btnSaveOCCType_Click(object sender, EventArgs e)
        {
            SaveOCCTypeInfo();
        }

        private void SaveOCCTypeInfo()
        {
            try
            {
                Expense_Frequency_EntryBAL expense_FrequencyBal = new Expense_Frequency_EntryBAL();
                switch (currentMode)
                {
                    case GlobalVariableBO.ModeSelection.NewMode:
                        try
                        {
                            if (IsValidateField())
                            {
                                expense_FrequencyBal.SaveCategory(txtOCCType.Text.Trim());
                                MessageBox.Show("OCC Type Saved Successfully", "Successfully Saved.");
                                ClearAll();
                                LoadDataIntoGrid();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("OCC Type Saved unsuccessful because of the error :" + ex.Message);
                        }
                        break;
                    case GlobalVariableBO.ModeSelection.UpdateMode:
                        try
                        {
                            expense_FrequencyBal.Update(txtOCCType.Text.Trim(), _OccTypeIdForUpdate);
                            MessageBox.Show("OCC Type has successfully updated.", "Success.");
                            LoadDataIntoGrid();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("OCC Type update unsuccessful because of the error :" + ex.Message);
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
            if (IsDuplicateOCCType())
            {
                MessageBox.Show("OCC Type Information Allready exist.");
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool IsDuplicateOCCType()
        {
            Expense_Frequency_EntryBAL OCCTypeBal = new Expense_Frequency_EntryBAL();
            if (OCCTypeBal.CheckOCCTypeDuplicate(txtOCCType.Text.Trim()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        private void frmAddOCCType_Load(object sender, EventArgs e)
        {
            LoadDataIntoGrid();
            ClearAll();
        }

        private void LoadDataIntoGrid()
        {
            Expense_Frequency_EntryBAL OCCTypeBal = new Expense_Frequency_EntryBAL();
            DataTable datatable = OCCTypeBal.GetAllOCCType();
            dgvOCCType.DataSource = datatable;
            dgvOCCType.Columns[0].Visible = false;
            label5.Text = "OCCT ype : " + dgvOCCType.Rows.Count;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            currentMode = GlobalVariableBO.ModeSelection.NewMode;
            gbOCCType.Text = "OCC Type Entry";
            btnNew.Enabled = false;
            btnNew.BackColor = Color.Gray;
            btnUpdate.Enabled = true;
            btnUpdate.ResetBackColor();
            ClearAll();
        }

        private void ClearAll()
        {
            txtOCCType.Text = "";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            currentMode = GlobalVariableBO.ModeSelection.UpdateMode;
            gbOCCType.Text = "Edit OCC Type";
            btnUpdate.Enabled = false;
            btnUpdate.BackColor = Color.Gray;
            btnNew.Enabled = true;
            btnNew.ResetBackColor();
            LoadDataForUpdate();
        
        }

        private void LoadDataForUpdate()
        {
            foreach (DataGridViewRow row in this.dgvOCCType.SelectedRows)
            {
                _OccTypeIdForUpdate = Convert.ToInt32(dgvOCCType[0, row.Index].Value);
                if (dgvOCCType[1, row.Index].Value != DBNull.Value)
                txtOCCType.Text = dgvOCCType[1, row.Index].Value.ToString();
            }
        }

        private void dgvOCCType_SelectionChanged(object sender, EventArgs e)
        {

            if (currentMode == GlobalVariableBO.ModeSelection.UpdateMode)
            {
                LoadDataForUpdate();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Expense_Frequency_EntryBAL OCCTypeBal = new Expense_Frequency_EntryBAL();
            if (_OccTypeIdForDelete != 0)
            {
                if (DialogResult.Yes == MessageBox.Show("Do you want to delete?", "Delete confirmation", MessageBoxButtons.YesNo))
                {
                    OCCTypeBal.DeleteOCCType(_OccTypeIdForDelete);
                    MessageBox.Show("Delete Successfull", "Delete confirmation");
                    LoadDataIntoGrid();
                }
            }
            else
            {
                MessageBox.Show("Please select an item to delete", "Delete item check");
            }
        }

        private void dgvOCCType_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                DataGridViewRow dr = dgvOCCType.CurrentRow;
                _OccTypeIdForDelete = Convert.ToInt32(dr.Cells[0].Value.ToString());

            }
            catch (Exception)
            {
                _OccTypeIdForDelete = 0;
            }

        }
    }
}
