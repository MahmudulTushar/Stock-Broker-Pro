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
    public partial class LockedinFree : Form
    {
        public LockedinFree()
        {
            InitializeComponent();
        }

        private void LockedinFree_Load(object sender, EventArgs e)
        {
            LoadCompanyDDL();
        }

        private void LoadCompanyDDL()
        {
            LoadDDLBAL loadDDLBAL = new LoadDDLBAL();
            DataTable dtData = loadDDLBAL.LoadDDL("SBP_Company");
            ddlCompShortCode.DataSource = dtData;
            ddlCompShortCode.DisplayMember = "Comp_Short_Code";
            ddlCompShortCode.ValueMember = "Comp_Short_Code";
            if (ddlCompShortCode.HasChildren)
                ddlCompShortCode.SelectedIndex = -1;
        }

        private void ddlCompShortCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCompanyName();
            LoadLockedinQty();
        }

        private void LoadLockedinQty()
        {
            txtLockedinQty.Text = "";
            DataTable LockedinQtyDataTable = new DataTable();
            ShareDWBAL shareDwbal = new ShareDWBAL();
            if (ddlCompShortCode.SelectedIndex != -1)
                LockedinQtyDataTable = shareDwbal.GetLockedinQty(ddlCompShortCode.Text);
            if (LockedinQtyDataTable.Rows.Count > 0)
            {
                txtLockedinQty.Text = LockedinQtyDataTable.Rows[0]["LockedinQty"].ToString();

            }
        }

        private void LoadCompanyName()
        {
            txtCompanyName.Text = "";
            DataTable companyDataTable = new DataTable();
            ShareDWBAL shareDwbal = new ShareDWBAL();
            if (ddlCompShortCode.SelectedIndex != -1)
                companyDataTable = shareDwbal.GetCompanyName(ddlCompShortCode.Text);
            if (companyDataTable.Rows.Count > 0)
            {
                txtCompanyName.Text = companyDataTable.Rows[0]["Comp_Name"].ToString();
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFree_Click(object sender, EventArgs e)
        {
            if (txtLockedinQty.Text.Trim() != "")
            {
                FreeLockedinShare();
            }
            else
            {
                 MessageBox.Show("There is no lockedin Share For this Compnay.", "Message");
            }
        }

        private void FreeLockedinShare()
        {
            if (MessageBox.Show("Do you want to continue?", "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    ShareDWBAL shareDwbal = new ShareDWBAL();
                    shareDwbal.FreeLockedInShare(ddlCompShortCode.Text);
                    MessageBox.Show("Lockedin share of " + txtCompanyName.Text + " has been Free.");
                    txtLockedinQty.Text = "";
                    txtCompanyName.Text = "";
                    ddlCompShortCode.SelectedIndex = 0;
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Error Occured: " + exc.Message);
                }
            }
        }
    }
}
