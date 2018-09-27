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
    public partial class RoleDeletion : Form
    {
        public RoleDeletion()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteRoleName();
        }

        private void DeleteRoleName()
        {
            try
            {
                if (dtgUserInfo.Rows.Count > 0)
                {
                    string roleName = dtgUserInfo.SelectedRows[0].Cells[0].Value.ToString();
                    RoleManagementBAL objRoleManagementBal = new RoleManagementBAL();

                    if (MessageBox.Show("Do You want to Delete the " + roleName + "\nRole Name From the List?", "Role Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        objRoleManagementBal.DeleteToRoleName(roleName);
                        MessageBox.Show("Secessfully Delete the" + roleName + " Role Name.", "Role Deletion",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadGridData();
                    }
                }

                else
                {
                    MessageBox.Show("No Role Name is Exists.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void RoleDeletion_Load(object sender, EventArgs e)
        {
            LoadGridData();
        }
        private void LoadGridData()
        {
            try
            {
                RoleManagementBAL roleManagementBal = new RoleManagementBAL();
                DataTable roledataTable = roleManagementBal.GetGridData();
                dtgUserInfo.DataSource = roledataTable;
                dtgUserInfo.Columns["Create Date"].DefaultCellStyle.Format = "dd MMMM yyyy";
                dtgUserInfo.Columns["Create Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                lblTotalRecord.Text = "Total Record : " + dtgUserInfo.Rows.Count.ToString();

            }
            catch (Exception ex )
            {

                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           
        }

    }
}
