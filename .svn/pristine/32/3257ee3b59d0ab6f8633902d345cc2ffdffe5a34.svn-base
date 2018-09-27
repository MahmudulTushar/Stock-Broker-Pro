using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;

namespace StockbrokerProNewArch
{
    public partial class frmRoleWithUserPrevillize : Form
    {
        public frmRoleWithUserPrevillize()
        {
            InitializeComponent();
        }

        public List<string> username=new List<string>();
        List<bool> result;
        int increment;
        private int menuID;
        private string menuName;
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
        private void GetResourceList()
        {
            UserManagementBAL objUserManagementBAL = new UserManagementBAL();
            DataTable data = new DataTable();
            data = objUserManagementBAL.GetMenuList();
            for (int i = 0; i < data.Rows.Count; i++)
            {
                int x = dgvRoleWithUserPrevillize.Rows.Add();
                dgvRoleWithUserPrevillize.Rows[x].Cells["MenuID"].Value = data.Rows[i]["MenuID"].ToString();
                dgvRoleWithUserPrevillize.Rows[x].Cells["MenuName"].Value = data.Rows[i]["MenuName"].ToString();
            }
        }

        private void frmRoleWithUserPrevillize_Load(object sender, EventArgs e)
        {
            LoadRoleName();
            GetResourceList();
        }

        private void dgvRoleWithUserPrevillize_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if ((e.ColumnIndex == 3) && (dgvRoleWithUserPrevillize.Rows[e.RowIndex].Cells["Select"].EditedFormattedValue != null) && ((bool)dgvRoleWithUserPrevillize.Rows[e.RowIndex].Cells["Select"].EditedFormattedValue == true))
            {
                username = new List<string>();
                menuID = Int32.Parse(dgvRoleWithUserPrevillize.Rows[e.RowIndex].Cells["MenuID"].Value.ToString());
                //menuName = dgvRoleWithUserPrevillize.Rows[e.RowIndex].Cells["MenuName"].Value.ToString();
        //        frmAddUser adduser = new frmAddUser(ddlRoleName.Text, dgvRoleWithUserPrevillize.Rows[e.RowIndex].Cells["MenuID"].Value.ToString());
       //         adduser.Show();

            }
        }
        private List<bool> DuplicateCheck()
        {
            RoleWithUserPrevillizeBAL roluser = new RoleWithUserPrevillizeBAL();
            result = roluser.IsExists(username, ddlRoleName.Text, menuID);
            return result;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            RoleWithUserPrevillizeBAL rolewithuser = new RoleWithUserPrevillizeBAL();
            string name = "";
            List<bool> exist;
            increment = 0;
            exist = DuplicateCheck();
            try
            {
                foreach (bool duplicate in exist)
                {
                    name = username[increment];
                    if (duplicate == false)
                    {
                        if (
                            MessageBox.Show(@"Do you want to Save ?", @"Save information",
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            rolewithuser.SaveData(ddlRoleName.Text, menuID, name);
                        }
                    }
                    else
                    {
                        MessageBox.Show(@"Data already Restricted", @"Restrict check",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    increment++;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }
    }
}
