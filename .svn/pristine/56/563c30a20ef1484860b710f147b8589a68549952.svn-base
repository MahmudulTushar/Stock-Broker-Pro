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
    public partial class RoleCreation : Form
    {
        private GlobalVariableBO.ModeSelection currentMode = GlobalVariableBO.ModeSelection.NewMode;
        
        public RoleCreation()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            currentMode = GlobalVariableBO.ModeSelection.NewMode;
            btnNew.Enabled = false;
            btnNew.BackColor = Color.Gray;
            btnUpdate.Enabled = true;
            btnUpdate.ResetBackColor();
            ClearAll();
            EnableAll();
            
        }

        private void EnableAll()
        {
           
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            currentMode = GlobalVariableBO.ModeSelection.UpdateMode;
            DisableAll();
            btnUpdate.Enabled = false;
            btnUpdate.BackColor = Color.Gray;
            btnNew.Enabled = true;
            btnNew.ResetBackColor();
            ClearAll();
            LoadDataForUpdate();
        }

        private void DisableAll()
        {
            
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveRoleInfo();
            LoadGridData();
        }

        private void LoadGridData()
        {
            RoleManagementBAL roleManagementBal = new RoleManagementBAL();
            DataTable roledataTable = roleManagementBal.GetGridData();
            dtgUserInfo.DataSource = roledataTable;
            dtgUserInfo.Columns["Create Date"].DefaultCellStyle.Format = "dd MMMM yyyy";
            dtgUserInfo.Columns["Create Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            lblTotalRecord.Text = "Total Record : " + dtgUserInfo.Rows.Count.ToString();

        }

        private void SaveRoleInfo()
        {
            if (txtRoleName.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter a role name");
                return;
            }
            try
            {
                RoleManagementBO roleManagementBo = new RoleManagementBO();
                roleManagementBo.RoleName = txtRoleName.Text;
                roleManagementBo.Description = txtDescription.Text;
                roleManagementBo.CreationDate = dtCreationDate.Value;
                switch (currentMode)
                {
                    case GlobalVariableBO.ModeSelection.NewMode:
                        try
                        {
                            //if (IsInputValid())
                            //{
                            RoleManagementBAL roleManagementBal = new RoleManagementBAL();
                            roleManagementBal.Insert(roleManagementBo);
                            MessageBox.Show("New Role has Saved Successfully.");
                            ClearAll();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Fail to save New Role because of the Error : " + ex.Message);
                        }
                        break;
                    case GlobalVariableBO.ModeSelection.UpdateMode:
                        try
                        {
                            //if (IsInputValid())
                            //{
                            RoleManagementBAL roleManagementBal = new RoleManagementBAL();
                            roleManagementBal.Update(roleManagementBo);
                            MessageBox.Show("Role Information updated Successfully.");
                            ClearAll();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Fail to updated Role Information because of the Error : " + ex.Message);
                        }
                        break;
                }

            }
            catch (Exception exc)
            {

                MessageBox.Show(exc.Message);
            }
        
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearAll();
            txtRoleName.Focus();

        }

        private void ClearAll()
        {
            txtDescription.Text = "";
            txtRoleName.Text = "";
            dtCreationDate.Value = DateTime.Today;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RoleCreation_Load(object sender, EventArgs e)
        {
            LoadGridData();
            txtRoleName.Focus();
        }

        private void dtgUserInfo_SelectionChanged(object sender, EventArgs e)
        {
            if (currentMode == GlobalVariableBO.ModeSelection.UpdateMode)
            {
                LoadDataForUpdate();
            }
        }

        private void LoadDataForUpdate()
        {
            foreach (DataGridViewRow row in this.dtgUserInfo.SelectedRows)
            {
                txtRoleName.Text = dtgUserInfo[0, row.Index].Value.ToString();
                txtDescription.Text = dtgUserInfo[1, row.Index].Value.ToString();
                if (dtgUserInfo[2, row.Index].Value != DBNull.Value)
                    dtCreationDate.Value = Convert.ToDateTime(dtgUserInfo[2, row.Index].Value);

            }
        }

       

       
    }
}
