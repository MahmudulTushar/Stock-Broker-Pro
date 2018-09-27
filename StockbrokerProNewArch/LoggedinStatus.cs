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
    public partial class LoggedinStatus : Form
    {
        public LoggedinStatus()
        {
            InitializeComponent();
        }

        private void LoggedinStatus_Load(object sender, EventArgs e)
        {
            LoadLoggedinUsers();
        }
        private void LoadLoggedinUsers()
        {
            LoginManagementBAL loginManagementBal = new LoginManagementBAL();
            dgvLoggedinUsers.DataSource = loginManagementBal.LoadLoggedinUsers();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            
            if (dgvLoggedinUsers.SelectedRows.Count > 0)
            {
                string userName = dgvLoggedinUsers.SelectedRows[0].Cells[0].Value.ToString();
                
                if (DialogResult.No == MessageBox.Show("Sure you want to logged out user'" + userName + "'?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    return;

                try
                {
                    LoginManagementBAL loginManagementBal = new LoginManagementBAL();
                    loginManagementBal.UpdateLoggedinStatus(userName, 0);
                    MessageBox.Show(userName + " has been logged out successfully.", "Success Message",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadLoggedinUsers();
                }
                catch(Exception exception)
                {
                    MessageBox.Show("Fail to update Loggedin Status. Because: " + exception.Message);
                }
            }
            
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadLoggedinUsers();
        }
    }
}
