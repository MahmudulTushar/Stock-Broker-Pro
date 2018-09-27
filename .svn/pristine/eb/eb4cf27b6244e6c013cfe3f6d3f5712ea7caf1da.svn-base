using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using BusinessAccessLayer.BO;

namespace StockbrokerProNewArch
{
    public partial class UserForm : Form
    {
        public UserForm()
        {
            InitializeComponent();
        }
        private GlobalVariableBO.ModeSelection currentMode = GlobalVariableBO.ModeSelection.NewMode;
        private void UserForm_Load(object sender, EventArgs e)
        {
            LoadFunctions();
            ClearAll();
            Init();
        }

        private void Init()
        {
            ddlBranchName.SelectedIndex = 0;
            ddlRoleName.SelectedIndex = 0;
            rdoActive.Checked = true;
            txtUserName.Focus();
        }

        private void LoadFunctions()
        {
            LoadDataIntoGrid();
            LoadRoleName();
            LoadBranches();

        }

        private void LoadRoleName()
        {
            LoadDDLBAL loadDDLBAL = new LoadDDLBAL();
            DataTable dtData = loadDDLBAL.LoadDDL("SBP_Roles");
            ddlRoleName.DataSource = dtData;
            ddlRoleName.DisplayMember = "Role_Name";
            ddlRoleName.ValueMember = "Role_Name";
            if (ddlRoleName.HasChildren)
                ddlRoleName.SelectedIndex = 0;
        }

        private void LoadBranches()
        {
            LoadDDLBAL loadDDLBAL = new LoadDDLBAL();
            DataTable dtData = loadDDLBAL.LoadBranchesDDL();
            ddlBranchName.DataSource = dtData;
            ddlBranchName.DisplayMember = "Branch_Name";
            ddlBranchName.ValueMember = "Branch_ID";
            if (ddlBranchName.HasChildren)
                ddlBranchName.SelectedIndex = 0;
        }

       

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveUserInformation();
        }

        private void SaveUserInformation()
        {
            try
            {
                UserManagementBO userBO = new UserManagementBO();
                userBO.UserName = txtUserName.Text;
                userBO.RoleName = ddlRoleName.SelectedValue.ToString();
                userBO.Password = txtPassword.Text;
                userBO.Name = txtName.Text;
                userBO.Address = txtAddress.Text;
                userBO.ContactNo = txtContactNo.Text;
                userBO.Remarks = txtRemarks.Text;
                if (rdoActive.Checked)
                    userBO.IsActive = 1;
                else
                    userBO.IsActive = 0;
                userBO.BranchId = Convert.ToInt32(ddlBranchName.SelectedValue);
                userBO.EmployeeCode = txtEmployeeCode.Text;

                UserManagementBAL usrMngBAL = new UserManagementBAL();
                switch (currentMode)
                {
                    case GlobalVariableBO.ModeSelection.NewMode:
                        try
                        {
                            if (IsValidInput())
                            {
                                usrMngBAL.Insert(userBO);
                                LoadDataIntoGrid();
                                MessageBox.Show(userBO.UserName + " has successfully saved.");
                                ClearAll();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("New User Creation unsuccessful because of the error :" + ex.Message);
                        }
                        break;
                    case GlobalVariableBO.ModeSelection.UpdateMode:
                        try
                        {
                            if (IsValidInputForUpdate())
                            {
                                usrMngBAL.Update(userBO);
                                LoadDataIntoGrid();
                                MessageBox.Show(userBO.UserName + " has successfully updated.");
                            }
                        }
                        catch (Exception exc)
                        {
                            MessageBox.Show("User information update unsuccessful because of the error :" + exc.Message);
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

        private bool IsValidInput()
        {
            if (IsDuplicateUserName())
            {
                MessageBox.Show("User Name Allready exist.Please try a different User Name.");
                return false;
            }
            else if (!string.Equals(txtPassword.Text, txtConfirmPassword.Text))
            {
                MessageBox.Show("Re-enter valid password.");
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool IsDuplicateUserName()
        {
            UserManagementBAL userBAL = new UserManagementBAL();
            if (userBAL.CheckUserDuplicate(txtUserName.Text))
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
            UserManagementBAL userBAL = new UserManagementBAL();
            DataTable userdataTable = userBAL.GetGridData();
            dtgUserInfo.DataSource = userdataTable;
            this.dtgUserInfo.Columns[1].Visible = false;
            this.dtgUserInfo.Columns[9].Visible = false;
            dtgUserInfo.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            lblTotalUser.Text = "Total User : " + dtgUserInfo.Rows.Count.ToString();
        }


        private bool IsValidInputForUpdate()
        {
            if (!string.Equals(txtPassword.Text, txtConfirmPassword.Text))
            {
                MessageBox.Show("Re-enter valid password.");
                return false;
            }
            else
            {
                return true;
            }
        }
        private void ClearAll()
        {
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
            txtName.Text = "";
            txtAddress.Text = "";
            txtContactNo.Text = "";
            txtRemarks.Text = "";
            txtEmployeeCode.Text = "";
            ddlBranchName.SelectedIndex = 0;
            ddlRoleName.SelectedIndex = 0;
            rdoActive.Checked = false;
            rdoInactive.Checked = false;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtUserName.ReadOnly = false;
            currentMode = GlobalVariableBO.ModeSelection.NewMode;
            btnNew.Enabled = false;
            btnNew.BackColor = Color.Gray;
            btnUpdate.Enabled = true;
            btnUpdate.ResetBackColor();
            gbUserEntry.Text = "User Entry";
            ClearAll();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            currentMode = GlobalVariableBO.ModeSelection.UpdateMode;
            btnUpdate.Enabled = false;
            btnUpdate.BackColor = Color.Gray;
            btnNew.Enabled = true;
            btnNew.ResetBackColor();
            gbUserEntry.Text = "Update User Information";
            LoadDataForUpdate();
        }

        private void LoadDataForUpdate()
        {
            foreach (DataGridViewRow row in this.dtgUserInfo.SelectedRows)
            {
                txtUserName.ReadOnly = true;
                txtUserName.Text = dtgUserInfo[0, row.Index].Value.ToString();
                txtPassword.Text = dtgUserInfo[1, row.Index].Value.ToString();
                txtConfirmPassword.Text = dtgUserInfo[1, row.Index].Value.ToString();
                ddlRoleName.SelectedValue = dtgUserInfo[2, row.Index].Value;
                int ddlValue =Convert.ToInt32(dtgUserInfo[9, row.Index].Value);
                ddlBranchName.SelectedValue = ddlValue;
                txtName.Text = dtgUserInfo[4, row.Index].Value.ToString();
                txtAddress.Text = dtgUserInfo[5, row.Index].Value.ToString();
                txtContactNo.Text = dtgUserInfo[6, row.Index].Value.ToString();
                txtRemarks.Text = dtgUserInfo[7, row.Index].Value.ToString();


                if (dtgUserInfo[8, row.Index].Value.ToString().Equals("Active"))
                {
                    rdoActive.Checked = true;
                }
                else
                {
                    rdoInactive.Checked = true;
                }

                txtEmployeeCode.Text = dtgUserInfo[10, row.Index].Value.ToString();
             }
        }

        private void dtgUserInfo_SelectionChanged(object sender, EventArgs e)
        {
            if (currentMode == GlobalVariableBO.ModeSelection.UpdateMode)
            {
               LoadDataForUpdate();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearAll();
            txtUserName.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtgUserInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
