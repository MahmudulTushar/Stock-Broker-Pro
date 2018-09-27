using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using DataAccessLayer;
using BusinessAccessLayer.BO;
using System.Timers;

namespace StockbrokerProNewArch
{
    public partial class Frm_HeadCodeEntry : Form
    {
        CategoryEntryBAL BAL = new CategoryEntryBAL();

        string tabStatus = "Basic";
        string prefix = string.Empty;
        public Frm_HeadCodeEntry()
        {
            InitializeComponent();
        }

        private void Frm_HeadCodeEntry_Load(object sender, EventArgs e)
        {
            txtHeadName.Text = "";
            cmbbasicHeadName.Enabled = false;
            txtSubHeadName.Enabled = false;
            txtSubHeadDesc.Enabled = false;
            LoadComboBox();
            LoadDataGrid();
        }

        private void LoadComboBox()
        {
            if (tabStatus == "Basic")
            {
                cmbHeadType.Text = "---Select Head Type---";
            }
            else if (tabStatus == "Sub")
            {
                cmbHeadTypeForSub.Text = "---Select Head Type---";
            }
        }

        private void LoadDataGrid()
        {
            if (tabStatus == "Basic")
            {
                DataTable dt;
                dt = BAL.getExistingHeadCode();
                dgvHeadCodeEntry.DataSource = dt;
            }
            else if (tabStatus == "Sub")
            {
                DataTable dt;
                dt = BAL.getExistingSubHeadInformation();
                dgvSubHeadName.DataSource = dt;

                DataTable data = new DataTable();
                cmbbasicHeadName.DataSource = data;
                txtSubHeadName.Text = string.Empty;
                txtSubHeadDesc.Text = string.Empty;
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Name == "tbBasicHead")
            {
                tabStatus = "Basic";
                Frm_HeadCodeEntry_Load(sender, e);
            }
            else if (tabControl1.SelectedTab.Name == "tbSubHead")
            {
                tabStatus = "Sub";
                Frm_HeadCodeEntry_Load(sender, e);
            }
        }

        private void btnSaveBasicHead_Click(object sender, EventArgs e)
        {
            if (CheckValidation())
                return;

            if (MessageBox.Show("Want To Save?", "Confirmation...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                DataTable dt;
                string HeadCode = string.Empty;
                dt = BAL.getNextHeadCode(prefix);
                HeadCode = dt.Rows[0]["NextHeadCode"].ToString();
                if (HeadCode.Length == 1)
                {
                    HeadCode = prefix + "00" + HeadCode;
                }
                else if (HeadCode.Length == 2)
                {
                    HeadCode = prefix + "0" + HeadCode;
                }
                else if (HeadCode.Length > 2)
                {
                    HeadCode = prefix + HeadCode;
                }
                string BasicHead = txtHeadName.Text.Trim();
                DateTime EntryDate = Convert.ToDateTime(GlobalVariableBO._currentServerDate.ToString("dd/MM/yyyy"));


                BAL.SaveNewHeadCode(HeadCode, BasicHead, EntryDate);
                MessageBox.Show("Head Code Saved Successfully");
                Frm_HeadCodeEntry_Load(sender, e);
            }
            else
            {
                //
            }
        }

        private bool CheckValidation()
        {
            if (cmbHeadType.Text == "---Select Head Type---")
            {
                MessageBox.Show("Please Select Head Type First...", "Information!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbHeadType.Focus();
                return true;
            }
            else if (string.IsNullOrEmpty(txtHeadName.Text.Trim()))
            {
                errorProvider1.SetError(txtHeadName, "Please Write Head Name...");
                txtHeadName.Focus();
                return true;
            }
            else return false;
        }

        private void txtHeadName_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtHeadName.Text.Trim()))
                errorProvider1.Clear();
        }

        private void cmbHeadType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHeadType.Text == "---Select Head Type---")
            {
                prefix = "Nothing";
            }
            else if (cmbHeadType.Text == "Asset")
            {
                prefix = "A";
            }
            else if (cmbHeadType.Text == "Expense")
            {
                prefix = "E";
            }
            else if (cmbHeadType.Text == "Income")
            {
                prefix = "I";
            }
            else if (cmbHeadType.Text == "Liability")
            {
                prefix = "L";
            }
            txtHeadName.Focus();
        }

        private void txtHeadName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                btnSaveBasicHead.Focus();
            }
        }


        private void cmbHeadTypeForSub_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHeadTypeForSub.Text == "---Select Head Type---")
            {
                prefix = "Nothing";
            }
            else if (cmbHeadTypeForSub.Text == "Asset")
            {
                prefix = "A";
            }
            else if (cmbHeadTypeForSub.Text == "Expense")
            {
                prefix = "E";
            }
            else if (cmbHeadTypeForSub.Text == "Income")
            {
                prefix = "I";
            }
            else if (cmbHeadTypeForSub.Text == "Liability")
            {
                prefix = "L";
            }

            DataTable dt;
            dt = BAL.getHeadNameByHeadType(prefix);
            if (dt.Rows.Count > 0)
            {
                cmbbasicHeadName.Enabled = true;
                txtSubHeadName.Enabled = true;
                txtSubHeadDesc.Enabled = true;

                cmbbasicHeadName.Text = "Select";
                cmbbasicHeadName.DataSource = dt;
                cmbbasicHeadName.DisplayMember = "BH";
                cmbbasicHeadName.ValueMember = "HC";
                errorProvider1.Clear();
                cmbbasicHeadName.Focus();
            }
            else
            {
                DataTable data = new DataTable();
                cmbbasicHeadName.DataSource = data;

                cmbbasicHeadName.Enabled = false;
                txtSubHeadName.Enabled = false;
                txtSubHeadDesc.Enabled = false;
                txtSubHeadName.Text = string.Empty;
                txtSubHeadDesc.Text = string.Empty;
                errorProvider1.SetError(cmbbasicHeadName, "First Register Basic Head..");
            }
        }


        string HCodeForSub = string.Empty;
        private void cmbbasicHeadName_SelectedIndexChanged(object sender, EventArgs e)
        {
            HCodeForSub = cmbbasicHeadName.SelectedValue.ToString();
            cmbbasicHeadName.Text = "---Select Basic Head---";
        }
        private bool ValidationSubHead()
        {
            if (cmbHeadTypeForSub.Text == "---Select Head Type---")
            {
                MessageBox.Show("Please Select Head Type...");
                cmbHeadTypeForSub.Focus();
                return true;
            }
            else if (cmbbasicHeadName.DataSource == null)
            {
                MessageBox.Show("First Register Basic Head..");
                return true;
            }
            else if (cmbbasicHeadName.Text == "---Select Basic Head---")
            {
                MessageBox.Show("Please Select Basic Head...");
                cmbbasicHeadName.Focus();
                return true;
            }
            else if (txtSubHeadName.Text == string.Empty)
            {
                MessageBox.Show("Please Write Sub_Head Name...");
                txtSubHeadName.Focus();
                return true;
            }
            else return false;
        }
        private void btnSaveSubHead_Click(object sender, EventArgs e)
        {
            if (ValidationSubHead())
                return;

            if (MessageBox.Show("Want To Save '" + txtSubHeadName.Text.Trim() + "' As Sub_Head?", "Confirmation..", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                int romDisit;
                string BHeadNameForSub = cmbbasicHeadName.Text.Trim();
                romDisit = BAL.getNextRomanDigitCode(HCodeForSub);

                String[] roman = new String[] { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
                int[] decimals = new int[] { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };

                string romanvalue = String.Empty;
                for (int i = 0; i < 13; i++)
                {
                    while (romDisit >= decimals[i])
                    {
                        romDisit -= decimals[i];
                        romanvalue += roman[i];
                    }
                }
                string HeadSubCode = HCodeForSub + romanvalue.ToLower();
                string SubHName = txtSubHeadName.Text.Trim();
                string HeadDescription = txtSubHeadDesc.Text.Trim();

                BAL.SaveNewSubHeadName(HCodeForSub, BHeadNameForSub, HeadSubCode, SubHName, HeadDescription);
                MessageBox.Show("Sub Head Name Saved Successfully...", "Confirmation...");
                Frm_HeadCodeEntry_Load(sender, e);
            }            
        }
    }
}
