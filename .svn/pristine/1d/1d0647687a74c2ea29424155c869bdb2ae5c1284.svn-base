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
    public partial class BranchClosingForm : Form
    {
        public BranchClosingForm()
        {
            InitializeComponent();
        }

        private void BranchClosingForm_Load(object sender, EventArgs e)
        {
            LoadBranchName();
        }

        private void LoadBranchName()
        {
            BranchManagementBAL branchBAL = new BranchManagementBAL();
            DataTable dtData = branchBAL.LoadDDLClosableBranch();
            ddlBranchName.DataSource = dtData;
            ddlBranchName.DisplayMember = "Branch_Name";
            ddlBranchName.ValueMember = "Branch_ID";
            if (ddlBranchName.HasChildren)
                ddlBranchName.SelectedIndex = 0;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to continue to close the Branch: "+ddlBranchName.Text+"?", "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                try
                {
                    BranchManagementBAL branchBAL = new BranchManagementBAL();
                    int branchId = Convert.ToInt32(ddlBranchName.SelectedValue);
                    branchBAL.CloseBranch(branchId);
                    MessageBox.Show(ddlBranchName.Text + " Branch has closed successfully.");
                    LoadBranchName();
                }
                catch (Exception exc)
                {

                    MessageBox.Show("Fail to close the Branch. Error: " + exc.Message);
                }
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
