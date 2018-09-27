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
    public partial class UserDeletion : Form
    {
        public UserDeletion()
        {
            InitializeComponent();
        }

        private void blnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UserDeletion_Load(object sender, EventArgs e)
        {
            LoadDataIntoGrid();
        }

        private void LoadDataIntoGrid()
        {
            try
            {
                UserManagementBAL userBAL = new UserManagementBAL();
                DataTable userdataTable = userBAL.GetGridData();
                dtgUserInfo.DataSource = userdataTable;
                this.dtgUserInfo.Columns[1].Visible = false;
                this.dtgUserInfo.Columns[9].Visible = false;
                dtgUserInfo.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                lblTotalUser.Text = "Total User : " + dtgUserInfo.Rows.Count.ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           
        }

        private void DeleteRoleName()
        {
            try
            {
                if (dtgUserInfo.Rows.Count > 0)
                {
                    string userName = dtgUserInfo.SelectedRows[0].Cells[0].Value.ToString();
                    UserManagementBAL objuserManagementBal =new UserManagementBAL();

                    if (MessageBox.Show("Do You want to Delete the " + userName + "\n User Name From the List?", "User Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        objuserManagementBal.DeleteUserInfo(userName);
                        MessageBox.Show("Secessfully Delete the" + userName + " User Name.", "User Deletion",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataIntoGrid();
                    }
                }

                else
                {
                    MessageBox.Show("No User Name is Exists.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteRoleName();
        }

        private void dtgUserInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
