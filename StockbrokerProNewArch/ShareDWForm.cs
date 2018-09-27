using System;
using System.Data;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using BusinessAccessLayer.BO;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;


namespace StockbrokerProNewArch
{
    public partial class ShareDWForm : Form
    {
        private List<KeyValuePair<string, string>> DepositTypeMapper;
        private List<KeyValuePair<string,string>> ShareDwTypeMapper;
        private List<KeyValuePair<string, string>> ShareTypeMapper;
        private string _custCode = "";
        private string _boID = "";

        private enum FormMode { DefaultMode, WithdrawMode,DepositMode,LockInMode,NonCdblMode,CdblMode };

        public ShareDWForm()
        {
            InitializeComponent();
            Init_DepositTypeMapper();
            Init_ShareDwTypeMapper();
            Init_ShareTypeMapper();
            LoadDepositType();
            LoadShareDwType();
            LoadShareType();
        }
       
      
        private void ShareDWForm_Load(object sender, EventArgs e)
        {
          
            LoadFunction();
            Init();
            txtSearchCustomer.Focus();
            LoadShareDWData();

        }
        private void Init_ShareDwTypeMapper()
        {
            ShareDwTypeMapper = new List<KeyValuePair<string, string>>();
            ShareDwTypeMapper.Add(new KeyValuePair<string,string>(BusinessAccessLayer.Constants.Indication_ShareTransactionMode.Deposit,"Deposit"));
            ShareDwTypeMapper.Add(new KeyValuePair<string, string>(BusinessAccessLayer.Constants.Indication_ShareTransactionMode.Withdraw, "Withdraw"));
        }
        private void Init_ShareTypeMapper()
        {
            ShareTypeMapper = new List<KeyValuePair<string, string>>();
            ShareTypeMapper.Add(new KeyValuePair<string, string>(BusinessAccessLayer.Constants.Indication_ShareType.CdblType, "Cdbl"));
            ShareTypeMapper.Add(new KeyValuePair<string, string>(BusinessAccessLayer.Constants.Indication_ShareType.NonCdblType, "Non-CDBL"));
        }
        private void Init_DepositTypeMapper()
        {
            DepositTypeMapper = new List<KeyValuePair<string, string>>();
            DepositTypeMapper.Add(new KeyValuePair<string,string>(BusinessAccessLayer.Constants.Indication_ShareDepositType.Ipo, "IPO"));
            DepositTypeMapper.Add(new KeyValuePair<string,string>(BusinessAccessLayer.Constants.Indication_ShareDepositType.Bonus, "Bonus"));
            DepositTypeMapper.Add(new KeyValuePair<string,string>(BusinessAccessLayer.Constants.Indication_ShareDepositType.Right, "Right"));
            DepositTypeMapper.Add(new KeyValuePair<string,string>(BusinessAccessLayer.Constants.Indication_ShareDepositType.Demat, "Demat"));
            DepositTypeMapper.Add(new KeyValuePair<string,string>(BusinessAccessLayer.Constants.Indication_ShareDepositType.LockIn, "Lock In"));
            DepositTypeMapper.Add(new KeyValuePair<string,string>(BusinessAccessLayer.Constants.Indication_ShareDepositType.LinkedAcc, "Transfer (Linked)"));
            DepositTypeMapper.Add(new KeyValuePair<string,string>(BusinessAccessLayer.Constants.Indication_ShareDepositType.Amalgamation, "Amalgamation"));
            DepositTypeMapper.Add(new KeyValuePair<string,string>(BusinessAccessLayer.Constants.Indication_ShareDepositType.Remat, "Remat"));
            DepositTypeMapper.Add(new KeyValuePair<string,string>(BusinessAccessLayer.Constants.Indication_ShareDepositType.Other, "Other"));

         }
        private void LoadShareType()
        {
            ddlShareType.DataSource = ShareTypeMapper.Select(t => new { Key = t.Key, Value = t.Value }).ToList();
            ddlShareType.DisplayMember = "Value";
            ddlShareType.ValueMember = "Key";
        }
        private void LoadShareDwType()
        {
            ddlDepositWithdraw.DataSource = ShareDwTypeMapper.Select(t => new { Key = t.Key, Value = t.Value }).ToList();
            ddlDepositWithdraw.DisplayMember = "Value";
            ddlDepositWithdraw.ValueMember = "Key";
        }
        private void LoadDepositType()
        {
           ddlDepositType.DataSource = DepositTypeMapper.Select(t => new { Key = t.Key, Value = t.Value }).ToList();
           ddlDepositType.DisplayMember = "Value";
           ddlDepositType.ValueMember = "Key";            
        }
        private void Init()
        {
            ddlShareType.SelectedIndex = 0;
            ddlSearchCustomer.SelectedIndex = 0;
            ddlDepositWithdraw.SelectedIndex = 0;
            ddlDepositType.SelectedIndex = 0;
            ddlCompanyName.SelectedIndex = 0;
            txtNoScript.Enabled = (ddlShareType.SelectedItem.Equals("Non-CDBL"));
        }

        private void LoadFunction()
        {
            LoadCompany();          
        }

        private void LoadCompany()
        {
            LoadDDLBAL loadDDLBAL = new LoadDDLBAL();
            DataTable dtData = loadDDLBAL.LoadDDL("SBP_Company");
            ddlCompanyName.DataSource = dtData;
            ddlCompanyName.DisplayMember = "Comp_Short_Code";
            ddlCompanyName.ValueMember = "Comp_Short_Code";
            if (ddlCompanyName.HasChildren)
                ddlCompanyName.SelectedIndex = 0;
        }

        private void SearchCustomerInformation()
        {
            if(txtSearchCustomer.Text.Trim()!="")
                ShowSearchCustInfo();
        }

        private void ModeExecution(FormMode mode)
        {
            switch (mode)
            {
                case FormMode.DefaultMode:
                    txtSearchCustomer.Enabled = true;
                    ddlDepositWithdraw.Enabled=true;
                    ddlCompanyName.Enabled=true;
                    txtQuantity.Enabled=true;
                    dtRecordDate.Enabled=true;
                    dtEffectiveDate.Enabled=true;
                    ddlDepositType.Enabled=true;
                    txtLockedInQty.Enabled=false;                   
                    txtAvailableQty.Enabled=false;                   
                    dtExpiryDate.Enabled=false;
                    ddlShareType.Enabled=true;
                    txtNoScript.Enabled=true;
                    txtIssuePrice.Enabled=true;
                    txtVoucherNo.Enabled = true;
                    break;
                
                case FormMode.LockInMode:
                    txtSearchCustomer.Enabled = true;
                    ddlDepositWithdraw.Enabled = true;
                    ddlCompanyName.Enabled = true;
                    txtQuantity.Enabled = true;
                    dtRecordDate.Enabled = true;
                    dtEffectiveDate.Enabled = true;
                    ddlDepositType.Enabled = true;
                    txtLockedInQty.Enabled = true;
                    
                    txtAvailableQty.Enabled = false;
                    dtExpiryDate.Enabled = true;
                    ddlShareType.Enabled = true;
                    txtNoScript.Enabled = true;
                    txtIssuePrice.Enabled = true;
                    txtVoucherNo.Enabled = true;
                    break;
                case FormMode.DepositMode:
                    LoadDepositType();
                    LoadShareType();
                    ddlDepositType.SelectedIndex = 0;
                    ddlShareType.SelectedIndex = 0;
                    ddlDepositType.Enabled = true;
                    ddlShareType.Enabled = true;                    
                    break;
                case FormMode.WithdrawMode:
                    LoadDepositType();
                    LoadShareType();
                    ddlDepositType.SelectedIndex = -1;
                    ddlShareType.SelectedIndex = -1;
                    ddlDepositType.Enabled = false;
                    txtLockedInQty.Enabled = false;
                    txtAvailableQty.Enabled = false;
                    dtExpiryDate.Enabled = false;
                    ddlShareType.Enabled = false;
                
                    break;
                case FormMode.CdblMode:
                    txtNoScript.Enabled = false;
                    break;
                case FormMode.NonCdblMode:
                    txtNoScript.Enabled = true;
                    break;


            }
        }

        private void ShowSearchCustInfo()
        {
            DataTable custDateTable = new DataTable();
            CustomerInfoBAL customerInfoBAL = new CustomerInfoBAL();
            if (ddlSearchCustomer.SelectedItem.Equals("BO Id"))
            {
                _boID = txtSearchCustomer.Text;
                custDateTable = customerInfoBAL.GetCustInfoByBOID(_boID);
                if (custDateTable.Rows.Count > 0)
                {
                    txtCustCode.Text = custDateTable.Rows[0]["Cust_Code"].ToString();
                    txtAccountHolderName.Text = custDateTable.Rows[0]["Cust_Name"].ToString();
                    txtAccountHolderBOId.Text = custDateTable.Rows[0]["BO_ID"].ToString();
                    txtLastTradeDate.Text = custDateTable.Rows[0]["LTD"].ToString();
                    txtBOStatus.Text = custDateTable.Rows[0]["BO_Status"].ToString();
                    txtAccountStatus.Text = custDateTable.Rows[0]["Status"].ToString();
                    txtBOStatus.BackColor = txtBOStatus.Text == @"Closed" ? Color.Red : Color.Blue;
                    txtAccountStatus.BackColor = txtAccountStatus.Text == @"Closed" ? Color.Red : Color.Blue;

                }
                else
                {
                    MessageBox.Show("No customer found.");
                }
            }
            else
            {
                _custCode = txtSearchCustomer.Text;
                custDateTable = customerInfoBAL.GetCustInfoByCustCode(_custCode);
                if (custDateTable.Rows.Count > 0)
                {
                    txtCustCode.Text = custDateTable.Rows[0]["Cust_Code"].ToString();
                    txtAccountHolderName.Text = custDateTable.Rows[0]["Cust_Name"].ToString();
                    txtAccountHolderBOId.Text = custDateTable.Rows[0]["BO_ID"].ToString();
                    txtLastTradeDate.Text = custDateTable.Rows[0]["LTD"].ToString();
                    txtBOStatus.Text = custDateTable.Rows[0]["BO_Status"].ToString();
                    txtAccountStatus.Text = custDateTable.Rows[0]["Status"].ToString();
                    txtBOStatus.BackColor = txtBOStatus.Text == @"Closed" ? Color.Red : Color.Blue;
                    txtAccountStatus.BackColor = txtAccountStatus.Text == @"Closed" ? Color.Red : Color.Blue;
                }
                else
                {
                    MessageBox.Show("No customer found.");
                }
            }
        }

        private void txtSearchCustomer_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonBAL commonBal = new CommonBAL();
            commonBal.NumberValidate(txtCustCode.Text, e);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ClearAll()
        {
            txtVoucherNo.Text = "";
            txtSearchCustomer.Text = "";
            txtQuantity.Text = "";
            txtNoScript.Text = "";
            txtIssuePrice.Text = "";
            txtCustCode.Text = "";
            txtAccountHolderName.Text = "";
            txtAccountHolderBOId.Text = "";
            txtLockedInQty.Text = string.Empty;
            txtAvailableQty.Text = string.Empty;
            dtRecordDate.Value = DateTime.Now;
            dtEffectiveDate.Value = DateTime.Now;
            ddlShareType.SelectedIndex = 0;
            ddlSearchCustomer.SelectedIndex = 0;
            ddlDepositWithdraw.SelectedIndex = 0;
            ddlDepositType.SelectedIndex = 0;
            ddlCompanyName.SelectedIndex = 0;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtBOStatus.Text.Equals("Closed"))
            {
                MessageBox.Show(@"This Customer's BO closed", @"BO ID check", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                
                LoadShareInfo();
            }
        }

        private void LoadShareInfo()
        {
            if (ddlSearchCustomer.SelectedIndex == 0)
            {
                if (txtCustCode.Text.ToUpper() != txtSearchCustomer.Text.ToUpper())
                {
                    SearchCustomerInformation();
                    return;
                }
            }
            else
            {
                if (txtAccountHolderBOId.Text != txtSearchCustomer.Text)
                {
                    SearchCustomerInformation();
                    return;
                }
            }
            if (ddlDepositWithdraw.Text == BusinessAccessLayer.Constants.Indication_ShareTransactionMode.Withdraw)
            {
                if (CheckShareBalance())
                {
                    SaveShareInfo();
                }
                else
                {
                    return;
                }
            }
            else
            {
                SaveShareInfo();
            }
        }

        private bool CheckShareBalance()
        {
            if (!CompanyShareDoesExist())
            {
                MessageBox.Show(@"This company's share does not exist to withdraw for this client.");
                return false;
            }
            if (!ShareQtyDoesAvail())
            {
                MessageBox.Show(@"Share quantity exceeds the share Balance to withdraw for this client.");
                return false;
            }
            return true;
            
        }

        private bool ShareQtyDoesAvail()
        {
            ShareDWBAL shareDwbal = new ShareDWBAL();
            if (!shareDwbal.CheckShareQtyDoesAvail(Convert.ToInt32(txtQuantity.Text),txtCustCode.Text,ddlCompanyName.Text))
            {
                return false;
            }
            else
            {
                return true;
            }
           
        }

        private void SetValue_TxtAvailable()
        {
            if (Convert.ToString(ddlDepositType.SelectedValue) == BusinessAccessLayer.Constants.Indication_ShareDepositType.LockIn)
            {
                int Temp_1;
                int Temp_2;
                if (int.TryParse(txtQuantity.Text, out Temp_1) && int.TryParse(txtLockedInQty.Text, out Temp_2))
                {
                    txtAvailableQty.Text = Convert.ToString(Temp_1 - Temp_2);
                }
                else
                    txtAvailableQty.Text = string.Empty;
            }
        }

        private bool CompanyShareDoesExist()
        {
            ShareDWBAL shareDwbal = new ShareDWBAL();
            if (!shareDwbal.CheckShareDoesExist(ddlCompanyName.Text,txtCustCode.Text))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        
        private void SaveShareInfo()
        {

            int intTryParse;

            if (txtSearchCustomer.Text.Trim() == "")
            {
                MessageBox.Show(@"Please Fill the customer code.");
                return;
            }
            if (txtQuantity.Text.Trim() == "")
            {
                MessageBox.Show(@"Please Fill the Share Quantity Field.");
                return;
            }
            if (ddlDepositWithdraw.Text == @"Deposit" && txtIssuePrice.Text.Trim() == "")
            {
                MessageBox.Show(@"Please Fill the Issue Price Field.");
                return;
            }
            try
            {
                
                ShareDWBO shareDwbo = new ShareDWBO();
                LockInShareBAL lockbal=new LockInShareBAL();
                shareDwbo.CustCode = txtCustCode.Text;
                if (ddlCompanyName.SelectedIndex != -1)
                    shareDwbo.CompanyShortCode = ddlCompanyName.SelectedValue.ToString();
                if (!String.IsNullOrEmpty(txtQuantity.Text.Trim()))
                    shareDwbo.Quantity =Convert.ToInt32(txtQuantity.Text);
                if (ddlDepositWithdraw.SelectedIndex != -1)
                    shareDwbo.DepositWithdraw = ddlDepositWithdraw.SelectedValue.ToString();
                shareDwbo.RecordDate = dtRecordDate.Value;
                shareDwbo.Received_Date = dtEffectiveDate.Value;
                shareDwbo.EffectiveDate = dtEffectiveDate.Value;
                shareDwbo.VoucherNo = txtVoucherNo.Text;
                if (ddlDepositType.SelectedValue == BusinessAccessLayer.Constants.Indication_ShareDepositType.LockIn)
                {
                    if(int.TryParse(txtLockedInQty.Text,out intTryParse))
                        shareDwbo.LockedInQuantity=intTryParse;
                    if (int.TryParse(txtAvailableQty.Text, out intTryParse))
                        shareDwbo.AvailableQuantity = intTryParse;
                    shareDwbo.Lockedin_Expiry_Date = dtExpiryDate.Value;
                }                
                if (!String.IsNullOrEmpty(txtNoScript.Text.Trim()))
                    shareDwbo.NoScript = Convert.ToInt32(txtNoScript.Text);
                if (ddlDepositType.SelectedIndex != -1)
                    shareDwbo.DepositType = ddlDepositType.SelectedValue.ToString();
                if (ddlShareType.SelectedIndex != -1)
                    shareDwbo.ShareType = ddlShareType.SelectedValue.ToString();
                if (!String.IsNullOrEmpty(txtIssuePrice.Text.Trim()))
                    shareDwbo.IssuePrice = float.Parse(txtIssuePrice.Text);
                shareDwbo.IssueAmount = shareDwbo.IssuePrice*shareDwbo.Quantity;
                ShareDWBAL shareDwbal = new ShareDWBAL();
                if (shareDwbo.DepositType == BusinessAccessLayer.Constants.Indication_ShareDepositType.LockIn)
                    lockbal.Validate_LockInQty(shareDwbo.Quantity, shareDwbo.LockedInQuantity, shareDwbo.AvailableQuantity);
                shareDwbal.Insert(shareDwbo);
                MessageBox.Show(@"Share Deposit/Withdraw Information Saved Successfully.");
                ClearAll();
                LoadShareDWData();
            }
            catch (Exception exc)
            {

                MessageBox.Show(exc.Message);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonBAL commonBal = new CommonBAL();
            commonBal.NumberValidate(txtQuantity.Text, e);
        }

      
        private void txtNoScript_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonBAL commonBal = new CommonBAL();
            commonBal.NumberValidate(txtNoScript.Text, e);
        }

        private void txtIssuePrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonBAL commonBal = new CommonBAL();
            commonBal.NumberValidate(txtIssuePrice.Text, e);
        }
        private void ddlDepositWithdraw_SelectedIndexChanged(object sender, EventArgs e)
        {
                        
            if (ddlDepositWithdraw.Text == BusinessAccessLayer.Constants.Indication_ShareTransactionMode.Withdraw)
            {
                //LoadDepositType();
                //LoadShareType();
                //ddlShareType.SelectedIndex = -1;
                //ddlShareType.Enabled = false;
                //ddlDepositType.SelectedIndex = -1;
                //ddlDepositType.Enabled = false;
                ModeExecution(FormMode.WithdrawMode);
            }
            else if (ddlDepositWithdraw.Text == BusinessAccessLayer.Constants.Indication_ShareTransactionMode.Deposit)
            {
                //LoadDepositType();
                //LoadShareType();
                //ddlShareType.SelectedIndex = 0;
                //ddlShareType.Enabled = true;
                //ddlDepositType.SelectedIndex = 0;
                //ddlDepositType.Enabled = true;               
                ModeExecution(FormMode.DepositMode);
            }
            
        }
        private void txtSearchCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "Return")
            {
                SearchCustomerInformation();
            }
        }

        private void btnGo_Click_1(object sender, EventArgs e)
        {
            SearchCustomerInformation();
        }

        private void ddlShareType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToString(ddlShareType.SelectedItem) == BusinessAccessLayer.Constants.Indication_ShareType.NonCdblType)
                ModeExecution(FormMode.NonCdblMode);
            else if ((Convert.ToString(ddlShareType.SelectedItem) == BusinessAccessLayer.Constants.Indication_ShareType.CdblType))
                ModeExecution(FormMode.CdblMode);
        }
        private void ddlDepositWithdraw_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "Return")
            {
                LoadShareInfo();
            }

        }

        private void LoadShareDWData()
        {
            try
            {
                ShareDWBAL objShareDWBAL = new ShareDWBAL();
                DataTable data = new DataTable();
                data = objShareDWBAL.GetShareDWInfoData(dateTimePicker1.Value);
                dgvShareDW.DataSource = data;
                dgvShareDW.Columns["Issue Price"].DefaultCellStyle.Format = "N";
                dgvShareDW.Columns["Issue Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                dgvShareDW.Columns["Issue Amount"].DefaultCellStyle.Format = "N";
                dgvShareDW.Columns["Issue Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                dgvShareDW.Columns["Record Date"].DefaultCellStyle.Format = "dd-MMM-yyyy";
                dgvShareDW.Columns["Record Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;



            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            LoadShareDWData();
        }

        private void ddlDepositType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToString(ddlDepositType.SelectedValue) == BusinessAccessLayer.Constants.Indication_ShareDepositType.LockIn)
            {
                ModeExecution(FormMode.LockInMode);
                SetValue_TxtAvailable();
            }
            else
            {
                ModeExecution(FormMode.DefaultMode);
                txtAvailableQty.Text = string.Empty;
            }
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            SetValue_TxtAvailable();
        }

        private void txtLockedInQty_TextChanged(object sender, EventArgs e)
        {
            SetValue_TxtAvailable();
        }
    }
}
