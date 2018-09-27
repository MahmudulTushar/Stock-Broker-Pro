using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using BusinessAccessLayer.BO;

namespace StockbrokerProNewArch
{
    public partial class BranchForm : Form
    {
        public BranchForm()
        {
            InitializeComponent();
        }
        private GlobalVariableBO.ModeSelection currentMode = GlobalVariableBO.ModeSelection.NewMode;
        private int _nBranchIdForUpdate = 0;
        private void BranchForm_Load(object sender, EventArgs e)
        {
            LoadDataIntoGrid();
            ClearAll();
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            currentMode = GlobalVariableBO.ModeSelection.NewMode;
            gbBranchEntry.Text = "Branch Entry";
            btnNew.Enabled = false;
            btnNew.BackColor = Color.Gray;
            btnUpdate.Enabled = true;
            btnUpdate.ResetBackColor();
            ClearAll();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            currentMode = GlobalVariableBO.ModeSelection.UpdateMode;
            gbBranchEntry.Text = "Update branch Information";
            btnUpdate.Enabled = false;
            btnUpdate.BackColor = Color.Gray;
            btnNew.Enabled = true;
            btnNew.ResetBackColor();
            LoadDataForUpdate();
        }

        private void LoadDataForUpdate()
        {
            foreach (DataGridViewRow row in this.dtgBranchInfo.SelectedRows)
            {
                _nBranchIdForUpdate = Convert.ToInt32(dtgBranchInfo[0, row.Index].Value);
                txtBranchName.Text = dtgBranchInfo[1, row.Index].Value.ToString();
                txtAddress.Text = dtgBranchInfo[2, row.Index].Value.ToString();
                txtTelephone.Text = dtgBranchInfo[3, row.Index].Value.ToString();
                txtFax.Text = dtgBranchInfo[4, row.Index].Value.ToString();
                txtEmail.Text = dtgBranchInfo[5, row.Index].Value.ToString();
                txtWeb.Text = dtgBranchInfo[6, row.Index].Value.ToString();
                if (dtgBranchInfo[7, row.Index].Value != DBNull.Value)
                    dtOpenDate.Value = Convert.ToDateTime(dtgBranchInfo[7, row.Index].Value);
                
            }
        }

        private void btnSaveBranch_Click(object sender, EventArgs e)
        {
            SaveBranchInfo();
        }
        private void SaveBranchInfo()
        {
            try
            {
                BranchManagementBO branchBO = new BranchManagementBO();
                branchBO.BranchName = txtBranchName.Text;
                branchBO.BranchAddress = txtAddress.Text;
                branchBO.TelePhone = txtTelephone.Text;
                branchBO.Fax = txtFax.Text;
                branchBO.Email = txtEmail.Text;
                branchBO.Web = txtWeb.Text;
                //string openDateString = dtOpenDate.Text;
                branchBO.BranchOpeningdate = dtOpenDate.Value;
                BranchManagementBAL branchMngBAL = new BranchManagementBAL();
                switch (currentMode)
                {
                    case GlobalVariableBO.ModeSelection.NewMode:
                        try
                        {
                            if (IsValidateField())
                            {
                                branchMngBAL.Insert(branchBO);
                                LoadDataIntoGrid();
                                MessageBox.Show(branchBO.BranchName + " Branch has successfully saved.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("New Branch Creation unsuccessful because of the error :" + ex.Message);
                        }
                        break;
                    case GlobalVariableBO.ModeSelection.UpdateMode:
                        try
                        {
                            branchMngBAL.Update(branchBO, _nBranchIdForUpdate);
                            LoadDataIntoGrid();
                            MessageBox.Show(branchBO.BranchName + " Branch Information has successfully updated.");

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Branch information update unsuccessful because of the error :" + ex.Message);
                        }
                        break;
                    case GlobalVariableBO.ModeSelection.NoneMode:
                        MessageBox.Show("You have select none mode.Please select a mode.");
                        break;
                }
            }
            catch (Exception exc)
            {

                MessageBox.Show(exc.Message);
            }
        }

        private bool IsValidateField()
        {
            if (IsDuplicateBranchName())
            {
                MessageBox.Show("Branch Name Allready exist.Please try a different Branch Name.");
                return false;
            }
           

            else
            {
                return true;
            }
        }
       
        private bool IsDuplicateBranchName()
        {
            BranchManagementBAL branchBAL = new BranchManagementBAL();
            if (branchBAL.CheckBranchDuplicate(txtBranchName.Text))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void LoadDataIntoGrid()
        {
            BranchManagementBAL branchMngBAL = new BranchManagementBAL();
            DataTable datatable = branchMngBAL.GetAllBranches();
            dtgBranchInfo.DataSource = datatable;
            this.dtgBranchInfo.Columns[0].Visible = false;
            this.dtgBranchInfo.Columns[8].Visible = false;
            this.dtgBranchInfo.Columns[9].Visible = false;
            this.dtgBranchInfo.Columns[10].Visible = false;
            dtgBranchInfo.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

        }
        private void ClearAll()
        {
            txtBranchName.Text = "";
            txtAddress.Text = "";
            dtOpenDate.Value = DateTime.Today;
           
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtgBranchInfo_SelectionChanged(object sender, EventArgs e)
        {
            if (currentMode == GlobalVariableBO.ModeSelection.UpdateMode)
            {
                LoadDataForUpdate();
            }
        }

    }
}
