using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using BusinessAccessLayer.BO;
using DataAccessLayer;
using System.Data.SqlClient;
using BusinessAccessLayer.Constants;



namespace StockbrokerProNewArch
{
    public partial class frm_IPONRB_Application : Form
    {
        private enum FormName { NRBDeposit, NRBWithdraw }
        private FormName CurrentFormName;

        IPOProcessBAL Bal = new IPOProcessBAL();
        CustomerInfoBAL C_Bal = new CustomerInfoBAL();
        DataTable DtBank = new DataTable();
        DataTable dt_Charge = new DataTable();       
        DataTable dt_Currency_Symbol = new DataTable(); 


        string _cust_Code = "";
        string _bank_Name = "";
        int _bank_ID = 0;
        int _company_ID = 0;        
        string _fd_NO = "";
        string _currency = "";
        decimal _amount = 0.0M;
        decimal Single_Amount = 0.0M;
        decimal _charge = 0.0M;
        string _voucher_no = "";
        int _Refund_Method = 0;
        string _money_trans_name = "";
        int _money_trans_id = 0;
        string _Charge_Trans_Type = "";
        decimal decimalTryParse = 0.0M;
        double doubleTryParse = 0.00;
        string _status = "";
        string _Bo_Status = "";
        string _recidency = "";
        string _nrbApplicationstatus = "";
        double TotalCharge = 0.00;
        string Date = null;
        
        double IPoAccountBalance = 0.00;
        double ApplicationChargeAmount = 0.00;

        public frm_IPONRB_Application(string p_FromName)
        {
            InitializeComponent();
            if (p_FromName == Indication_Forms_Title.IPONRBMoneyDepositAndApplication)
            {
                TabNRBDeposit.SelectedIndex = 0;
                CurrentFormName = FormName.NRBDeposit;
                this.Text = "NRB Application Information (Draft Deposit)";
            }
            else if (p_FromName == Indication_Forms_Title.IPONRBMoneyWithDrawAndApplication)
            {
                TabNRBDeposit.SelectedIndex = 1;
                CurrentFormName = FormName.NRBWithdraw;
                this.Text = "NRB Application Information (Draft Withdraw)";
            }
        }

        private void frm_IPONRB_Application_Load(object sender, EventArgs e)
        {
            try
            {
                dg_AddNRBCustomers.AllowUserToAddRows = false;
                dg_AddNRBCustomers.RowHeadersVisible = false;
                if (CurrentFormName == FormName.NRBDeposit)
                {
                    LoadComboData();
                    Load_GridData();
                    BtnRefresh.Visible = false;
                    btnCancel.Visible = true;
                }
                else if (CurrentFormName == FormName.NRBWithdraw)
                {
                    LoadComboData();
                    Load_GridData();
                    btnCancel.Enabled = false;
                    btnCancel.Visible = false;
                    txtWithdrawcustCode.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       

        private void LoadComboData()
        {
            try
            {
                if (CurrentFormName == FormName.NRBDeposit)
                {
                    
                    DataTable DtEligible_Company = new DataTable();
                    DataTable dt_Currency = new DataTable();
                    DataTable dt_Refund = new DataTable();
                    DataTable dt_TransType = new DataTable();
                    DataTable dt_Charge_TransType = new DataTable();

                    DtBank = Bal.GetAllBankName();
                     
                    //cmbBankName.DataSource = DtBank.Rows.Cast<DataRow>().Select(c => c["Bank_Name"]).Distinct().ToList();
                    var bank = DtBank.Rows.Cast<DataRow>()
                        .Select(t => new { Name = t["Bank_Name"], ID = t["Bank_Code"] }).Distinct().ToList();
                        //.Select(c => new { key=c.Name,vlaue=c.ID})
                    
                    cmbBankName.DisplayMember = "Name";
                    cmbBankName.ValueMember = "ID";
                    cmbBankName.DataSource = bank;
                    //cmbBankName.SelectedIndex = -1;

                    DtEligible_Company = Bal.GetCompanyList_EligibleFor_Application();
                    cmbCompanyName.DataSource = DtEligible_Company;
                    cmbCompanyName.DisplayMember = "Company_Short_Code";
                    cmbCompanyName.ValueMember = "Company_Id";

                    dt_TransType = Bal.GetIPOMoneyTransType();
                    cmbTrnastype.DataSource = dt_TransType;
                    cmbTrnastype.DisplayMember = "Name";
                    cmbTrnastype.ValueMember = "ID";
                    cmbTrnastype.SelectedIndex = 8;

                    dt_Charge_TransType = Bal.GetIPOMoneyTransType();
                    cmbChargeTransType.DataSource = dt_Charge_TransType;
                    cmbChargeTransType.DisplayMember = "Name";
                    cmbChargeTransType.ValueMember = "ID";
                    cmbChargeTransType.SelectedIndex = 0;

                    dt_Currency = Bal.GetAllCurrency_Name();
                    lblUSD.Text = dt_Currency.Rows[0]["EUR"].ToString();
                    lblGBP.Text = dt_Currency.Rows[0]["GBP"].ToString();
                    lblEUR.Text = dt_Currency.Rows[0]["USD"].ToString();

                    dt_Refund = Bal.GetRefundMethod();
                    cmbNRBRefund.DataSource = dt_Refund;
                    cmbNRBRefund.DisplayMember = "Name";
                    cmbNRBRefund.ValueMember = "ID";
                    cmbNRBRefund.SelectedIndex = 5;

                    if (DtEligible_Company.Rows.Count > 0)
                    {
                        dt_Currency_Symbol = Bal.GetNRB_CurrnecyAmount_Symbol((int)cmbCompanyName.SelectedValue);
                        H_lblEuro.Text = dt_Currency_Symbol.Rows[0]["EUR_Symbol"].ToString();
                        H_Lbl_Pound.Text = dt_Currency_Symbol.Rows[0]["GBP_Symbol"].ToString();
                        H_LblDollar.Text = dt_Currency_Symbol.Rows[0]["USD_Symbol"].ToString();
                    }
                    else
                    {
                        H_lblEuro.Text = "";
                        H_Lbl_Pound.Text = "";
                        H_LblDollar.Text = "";
                        MessageBox.Show("IPO Application Eligible Company Not found");
                    }
                    dt_Charge = Bal.GetIPO_ChargeDef();
                    txtNRBCharge.Text = dt_Charge.Rows[0]["TotalCharge"].ToString();
                    ApplicationChargeAmount = Convert.ToDouble(dt_Charge.Rows[0]["TotalCharge"].ToString());
                    dtpReceiveDate.Value = GlobalVariableBO._currentServerDate.Date;
                    //txtDepositWithdraw.Text = "Deposit";
                    Disable_Amount_Textbox();                    
                    //Load_GridData();
                    Txt_CustCode.Focus();
                }
                else if (CurrentFormName == FormName.NRBWithdraw)
                {
                    DataTable dt = new DataTable();
                    dt = Bal.GetCompanyShortCodeAndSessionID();
                    cmbRefundCompanyName.DataSource = dt;
                    cmbRefundCompanyName.DisplayMember = "Code";
                    cmbRefundCompanyName.ValueMember = "ID";
                }
            }
            catch (Exception ex)
            {
                throw new Exception (ex.Message);
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            //btnsave_Click(sender, e);
            try
            {
                if (CurrentFormName == FormName.NRBDeposit)
                {
                    Validation();
                    
                    _bank_Name = cmbBankName.Text;
                    _bank_ID = Convert.ToInt32(cmbBankName.SelectedValue);
                    _company_ID = Convert.ToInt32(cmbCompanyName.SelectedValue);
                    _fd_NO = txtFDNO.Text;
                    _Refund_Method = Convert.ToInt32(cmbNRBRefund.SelectedValue);
                    _voucher_no = txt_NRB_Voucher_No.Text;
                    if (decimal.TryParse(txtNRBCharge.Text, out decimalTryParse))
                    {
                        _charge = decimalTryParse;
                    }
                    _money_trans_id = Convert.ToInt32(cmbTrnastype.SelectedValue);
                    _Charge_Trans_Type = cmbChargeTransType.Text;
                    _money_trans_name = cmbTrnastype.Text;
                    try
                    {
                        Bal.ConnectDatabase();
                        foreach (DataGridViewRow row in dg_AddNRBCustomers.Rows)
                        {
                            _cust_Code = Convert.ToString(row.Cells["N_Cust_Code"].Value);
                            Bal.Insert_NRB_IPO_Money_Transaction(_cust_Code, _bank_Name, _bank_ID, cmbBankBranch.Text, _company_ID, GlobalVariableBO._currentServerDate.Date, Convert.ToDateTime(Date), _fd_NO, _currency, Single_Amount, _amount, _charge, _voucher_no, _money_trans_name, _money_trans_id, _Charge_Trans_Type);
                            Bal.Insert_NRB_IPO_Application_Process(_company_ID, _cust_Code, _Refund_Method, _voucher_no, _currency, _fd_NO);
                            
                        }
                        Bal.Commit();
                        if (dg_AddNRBCustomers.Rows.Count > 0)
                        {
                            dg_AddNRBCustomers.Rows.Clear();
                        }

                    }
                    catch (Exception ex)
                    {
                        Bal.RollBack();
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        Bal.CloseDatabase();

                    }
                    MessageBox.Show("Save Successfully");
                    ClearAll();
                    Disable_Amount_Textbox();
                    Load_GridData();
                    txt_Successful.Text = "Total Count : " + dg_NRB.Rows.Count;
                    txt_Unsuccessful.Text = "Total Application Count : " + dg_AddNRBCustomers.Rows.Count;
                }
                else if (CurrentFormName == FormName.NRBWithdraw)
                {
                    try
                    {
                        Dictionary<string, string> dict = Dg_NRB_Refund.Rows.Cast<DataGridViewRow>().ToDictionary(c => Convert.ToString(c.Cells["R_code"].Value), t => Convert.ToString(t.Cells["WarrantNo"].Value));
                        foreach (KeyValuePair<string, string> value in dict)
                        {
                            if (string.IsNullOrEmpty(value.Value))
                            {
                                throw new Exception ("Warrant no. is needed for "+value.Key+" customer");
                            }
                        }
                        
                        foreach (DataGridViewRow dr in Dg_NRB_Refund.Rows)
                        {
                            string CollectedName = dr.Cells["R_Reciver_Name"].Value.ToString();
                            string id = dr.Cells["R_ID"].Value.ToString();
                            string WarrantNo = Convert.ToString(dr.Cells["WarrantNo"].Value);
                            //Dg_NRB_Refund.SelectedRows.Cast<DataGridViewRow>().Select(c => Convert.ToString(c.Cells["ID"].Value)).ToArray();
                            Bal.GetNRBRefundStatusUpdate(id, CollectedName,WarrantNo);
                            
                        }
                        MessageBox.Show("Refund Successfully");
                        if (Dg_NRB_Refund.Rows.Count > 0)
                        {
                            Dg_NRB_Refund.Rows.Clear();
                        }
                        
                        Load_GridData();
                         
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                if (CurrentFormName == FormName.NRBDeposit)
                {
                    Load_GridData();
                    MessageBox.Show(ex.Message);
                }
                else if (CurrentFormName == FormName.NRBWithdraw)
                {
                    Load_GridData();
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void ChkUsd_CheckedChanged(object sender, EventArgs e)
        {
            CurrencyCalculation();
        }

        private void ChkEUR_CheckedChanged(object sender, EventArgs e)
        {
            CurrencyCalculation();
        }

        private void chkGBP_CheckedChanged(object sender, EventArgs e)
        {
            CurrencyCalculation();
        }
        private void CurrencyCalculation()
        {

            if (chkGBP.Checked)
            {
                //txtGBP.Enabled = true;
                ChkUsd.Checked = false;
                ChkEUR.Checked = false;
                txtUsd.Enabled = false;
                txtEUR.Enabled = false;
                _amount = Convert.ToDecimal(Bal.Get_NRB_IPO_Amount(cmbCompanyName.Text, lblGBP.Text));
                Single_Amount = _amount;
                if (dg_AddNRBCustomers.Rows.Count == 2)
                {
                    _amount = _amount * 2;
                    txtGBP.Text = Convert.ToString(_amount);
                }
                else if (dg_AddNRBCustomers.Rows.Count == 1)
                {
                    txtGBP.Text = Convert.ToString(_amount);
                }
                else if (dg_AddNRBCustomers.Rows.Count == 0)
                {
                    txtGBP.Text = "";
                }
                _currency = lblGBP.Text;

                if (!string.IsNullOrEmpty(txtFDNO.Text))
                {
                    txt_NRB_Voucher_No.Focus();
                }
            }
            else
            {
                txtGBP.Enabled = false;
                txtGBP.Text = "";
            }
            if (ChkEUR.Checked)
            {
                //txtEUR.Enabled = true;
                chkGBP.Checked = false;
                ChkUsd.Checked = false;
                txtGBP.Enabled = false;
                txtUsd.Enabled = false;
                _currency = lblEUR.Text;
                _amount = Convert.ToDecimal(Bal.Get_NRB_IPO_Amount(cmbCompanyName.Text, lblEUR.Text));
                Single_Amount = _amount;
                if (dg_AddNRBCustomers.Rows.Count == 2)
                {
                    _amount = _amount * 2;
                    txtEUR.Text = Convert.ToString(_amount);
                }
                else if (dg_AddNRBCustomers.Rows.Count == 1)
                {
                    txtEUR.Text = Convert.ToString(_amount);
                }
                else if (dg_AddNRBCustomers.Rows.Count == 0)
                {
                    txtEUR.Text = "";
                }
                if (!string.IsNullOrEmpty(txtFDNO.Text))
                {
                    txt_NRB_Voucher_No.Focus();
                }
                

            }
            else
            {
                txtEUR.Enabled = false;
                txtEUR.Text = "";
            }
            if (ChkUsd.Checked)
            {
                //txtUsd.Enabled = true;
                chkGBP.Checked = false;
                ChkEUR.Checked = false;
                txtGBP.Enabled = false;
                txtEUR.Enabled = false;
                _amount = Convert.ToDecimal(Bal.Get_NRB_IPO_Amount(cmbCompanyName.Text, lblUSD.Text).ToString());
                Single_Amount = _amount;
                _currency = lblUSD.Text;
                if (dg_AddNRBCustomers.Rows.Count == 2)
                {
                    _amount = _amount * 2;
                    txtUsd.Text = Convert.ToString(_amount);
                }
                else if (dg_AddNRBCustomers.Rows.Count == 1)
                {
                    txtUsd.Text = Convert.ToString(_amount);
                }
                else if (dg_AddNRBCustomers.Rows.Count == 0)
                {
                    txtUsd.Text = "";
                }
                if (!string.IsNullOrEmpty(txtFDNO.Text))
                {
                    txt_NRB_Voucher_No.Focus();
                }
                 
            }
            else
            {
                txtUsd.Enabled = false;
                txtUsd.Text = "";
            }


        }
        
        private void Txt_CustCode_KeyDown(object sender, KeyEventArgs e)
        {
            
            try
            {
                string cust_code_Pass = "";           
                if (e.KeyCode == Keys.Enter)
                {
                    cust_code_Pass = Txt_CustCode.Text.Trim();
                    //ClearAll(); 
                    if (string.IsNullOrEmpty(cust_code_Pass))
                    {
                        if (dg_AddNRBCustomers.Rows.Count > 0)
                        {
                            MouseFocus();
                            //MessageBox.Show("Cust Code Already in Grid");
                        }
                        else
                        {
                            Txt_CustCode.Focus();
                        }
                    }
                    else
                    {
                        if (dg_AddNRBCustomers.Rows.Cast<DataGridViewRow>()
                            .Where(c => Convert.ToString(c.Cells["N_Cust_Code"].Value) == cust_code_Pass).Count() > 0)
                        {
                            MessageBox.Show("Cust Code Already in Grid");
                        }
                        else
                        {
                            if (dg_AddNRBCustomers.Rows.Count == 2)
                            {
                                MouseFocus();
                                MessageBox.Show("You are able to add maximum 2 customers at the same time. \nYou cross your entry limit", "Cross Entry Limit.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(cust_code_Pass))
                                {
                                    CheckCustomerAppliedOrNOT(cust_code_Pass);
                                    ChechCustomerCode(cust_code_Pass);
                                    CurrencyCalculation();
                                }
                            }
                        }
                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        

        private void MouseFocus()
        {
            if (chkBankSelection.Checked)
            {
                Txt_CustCode.Text = "";
                txtFDNO.Focus();
            }
            else
            {
                Txt_CustCode.Text = "";
                cmbBankName.Focus();
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        private void ClearAll()
        {
             
            Txt_CustCode.Text = "";             
            txtFDNO.Text = "";
            ChkNRBAccountPay.Checked = false;
            chkCharge.Checked = false;
            txtNrbAccountBalanace.Text = "";
            //txtNRBCharge.Text = "";
            chkCharge.Checked = false;
            if (chkvoucherNo.Checked == false)
            {
                txt_NRB_Voucher_No.Text = "";
                chkGBP.Checked = false;
                ChkUsd.Checked = false;
                ChkEUR.Checked = false;
                txtUsd.Text = "";
                txtEUR.Text = "";
                txtGBP.Text = "";
                _currency = "";
            }
            txtUsd.Text = "";
            txtEUR.Text = "";
            txtGBP.Text = "";
            _currency = "";
            
            if (!(chkBankSelection.Checked))
            {
                cmbBankName.Text = "";
                cmbBankBranch.Text = "";
                txtrouting.Text = "";
                dtp_DraftDate.Value = DateTime.Today;
            }
            _Charge_Trans_Type = "";
            if (cmbCompanyName.SelectedIndex > 0)
            {
                LoadHeaderCurrency((int)cmbCompanyName.SelectedValue);
            }
            Txt_CustCode.Focus();
        }
        private void LoadHeaderCurrency(int CompanyID)
        {
            dt_Currency_Symbol = Bal.GetNRB_CurrnecyAmount_Symbol(CompanyID);
            H_lblEuro.Text = dt_Currency_Symbol.Rows[0]["EUR_Symbol"].ToString();
            H_Lbl_Pound.Text = dt_Currency_Symbol.Rows[0]["GBP_Symbol"].ToString();
            H_LblDollar.Text = dt_Currency_Symbol.Rows[0]["USD_Symbol"].ToString();
        }
        private void Disable_Amount_Textbox()
        {
            if (CurrentFormName == FormName.NRBDeposit)
            {
                txtEUR.Enabled = false;
                txtGBP.Enabled = false;
                txtUsd.Enabled = false;
                txtNRBCharge.Enabled = false;
                lblSuccessful.Visible = false;
                lbltakenByClient.Visible = false;
                LblUnsuccessful.Visible = false;
                txt_takenByClient.Visible = false;
            }
            else if (CurrentFormName == FormName.NRBWithdraw)
            {
                lblSuccessful.Visible = false;
                lbltakenByClient.Visible = false;
                LblUnsuccessful.Visible = false;
                txt_takenByClient.Visible = true;
            }
        }

        private void cmbCompanyName_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearAll();
            Disable_Amount_Textbox();

        }
        /// <summary>
        /// Todays Transaction data
        /// Added By Md.Rashedul Hasan
        /// </summary>
        private void Load_GridData()
        {
            DataTable dt = new DataTable();
            if (CurrentFormName == FormName.NRBDeposit)
            {
                dt = Bal.Get_NRB_IPO_Application_Data(dtpReceiveDate.Value.Date);
                dg_NRB.DataSource = dt;
                dg_NRB.Columns["Trn_ID"].Visible = false;
                dg_NRB.Columns["App_ID"].Visible = false;
                dg_NRB.Columns["BasicInfo_ID"].Visible = false;
                txt_Successful.Text = "Total Application Count : " + dg_NRB.Rows.Count;
            }
            else if (CurrentFormName == FormName.NRBWithdraw)
            {
                //dt = Bal.Get_NRB_DraftReturnData();
                //dg_NRB.DataSource = dt;
                 
                //dg_NRB.Columns["Trn_ID"].Visible = false;
                //dg_NRB.Columns["App_ID"].Visible = false;
                //dg_NRB.Columns["BasicInfo_ID"].Visible = false;
                //if (dg_NRB.Rows.Count > 0)
                //{
                //    txt_Successful.Text = "NRB Successful : " + dg_NRB.Rows.Cast<DataGridViewRow>().AsEnumerable().Where(c => Convert.ToString(c.Cells["App_Status"].Value) == "Successfull").Count().ToString();
                //    txt_Unsuccessful.Text = "NRB UnSuccessful : " + dg_NRB.Rows.Cast<DataGridViewRow>().AsEnumerable().Where(c => Convert.ToString(c.Cells["App_Status"].Value) == "Unsuccessfull").Count().ToString();
                //    txt_takenByClient.Text ="NRB Draft Withdraw : "+ dg_NRB.Rows.Cast<DataGridViewRow>().AsEnumerable().Where(c => Convert.ToString(c.Cells["NRB_Status"].Value) == "Taken By Client").Count().ToString();                      
                        
                //}
                SuccessfulUnsuccessfulDraft();

            }
            dg_NRB.AutoResizeColumns();
            dg_NRB.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dg_NRB.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            //dg_NRB.AllowUserToOrderColumns = true;
            //dg_NRB.AllowUserToResizeColumns = true;

             
        }

        private void ChechCustomerCode(string code)
        {
            DataTable dt_CustInof = new DataTable();
            dt_CustInof = C_Bal.GetCustInfoByCustCode(code);
            if (dt_CustInof.Rows.Count > 0)
            {
                _status = dt_CustInof.Rows[0]["Status"].ToString();
                _Bo_Status = dt_CustInof.Rows[0]["BO_Status"].ToString();
                _recidency = dt_CustInof.Rows[0]["Recidency"].ToString();

                if (_status != "Active")
                {
                    Txt_CustCode.Text="";
                    throw new Exception("Account is closed : "+code);
                    
                }
                else if (_Bo_Status != "Active")
                {
                    Txt_CustCode.Text = "";
                    throw new Exception("Account Bo is closed : "+code);
                   
                }
                    //else if (_recidency == "Resident"||string.IsNullOrEmpty(_recidency))
                else if (_recidency == "Resident")
                {
                    Txt_CustCode.Text = "";
                    throw new Exception("Client Is resident And client Must be Non resident : "+code);
                    
                }
                else if (string.IsNullOrEmpty(_recidency))
                {
                    throw new Exception("Recidency Information Is not update For this client : "+code);
                }
                else
                {
                    if (Txt_CustCode.Text == code)
                    {
                       string N_Cust_Code = dt_CustInof.Rows[0]["Cust_Code"].ToString();
                       string N_BoId = dt_CustInof.Rows[0]["BO_Id"].ToString();
                        string N_Cust_Name = dt_CustInof.Rows[0]["Cust_Name"].ToString();
                        string N_Resident = dt_CustInof.Rows[0]["Recidency"].ToString();
                        dg_AddNRBCustomers.Rows.Add(new string[] {N_Cust_Code,N_Cust_Name,N_BoId,N_Resident });

                        if (dg_AddNRBCustomers.Rows.Count >= 2)
                        {
                            if (chkBankSelection.Checked)
                            {
                                Txt_CustCode.Text = "";
                                txtFDNO.Focus();
                            }
                            else
                            {
                                Txt_CustCode.Text = "";
                                cmbBankName.Focus();
                            }
                        }
                        else
                        {
                            Txt_CustCode.Text = "";
                            Txt_CustCode.Focus();
                        }
                        txt_Unsuccessful.Text = "Total Count : " + dg_AddNRBCustomers.Rows.Count;
                    }
                }
            }
            else
            {
                Txt_CustCode.Focus();
                MessageBox.Show("Invalid Customer Code", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Validation()
        {
            double CashAmount = 0.00;
            double FromAccountAmount=0.00;
            
            if (double.TryParse(txtNRBCharge.Text, out doubleTryParse))
            {
                CashAmount = doubleTryParse;
            }
            if(double.TryParse(txtNrbAccountBalanace.Text,out doubleTryParse))
            {
                FromAccountAmount=doubleTryParse;
            }
            if (dg_AddNRBCustomers.Rows.Count==0)
            {
                throw new Exception("NRB Cust code is required");
            }
            if (string.IsNullOrEmpty(cmbBankName.Text))
            {
                throw new Exception("Bank Name is Required");
            }
            if (string.IsNullOrEmpty(txt_NRB_Voucher_No.Text))
            {
                throw new Exception("voucher no is required");
            }
            if (string.IsNullOrEmpty(txtFDNO.Text))
            {
                throw new Exception("Fd No is required");
            }
            if (!DtBank.Rows.Cast<DataRow>().Any(x => Convert.ToString(x["Bank_Name"]) == cmbBankName.Text))
            {
                cmbBankName.Focus();
                cmbBankBranch.DataSource = null;
                throw new Exception("Bank Name is incorrect");
            }

            if (string.IsNullOrEmpty(cmbBankBranch.Text))
            {

                throw new Exception("Bank Branch Name is invalid \n Please provide valid Bank Branch Name");

            }
            
            if (txtUsd.Text != "")
            {
                if (_amount != (Convert.ToDecimal(txtUsd.Text)))
                {
                    throw new Exception("Usd Amount Is Invalid \n Amount Will be: "+_amount+"$");
                }
            }
            if (txtGBP.Text != "")
            {
                if (_amount != (Convert.ToDecimal(txtGBP.Text)))
                {
                    throw new Exception("GBP Amount Is Invalid \n Amount Will be: " + _amount + "£");
                }
            }
            if (txtEUR.Text != "")
            {
                if (_amount != (Convert.ToDecimal(txtEUR.Text)))
                {
                    throw new Exception("EUR Amount Is Invalid \n Amount Will be: " + _amount + "€");
                }
            }
            
           
            if (txtUsd.Text == "" && txtGBP.Text == "" && txtEUR.Text == "")
            {
                throw new Exception("Currency Amount Is Required");
            }
           
            if (ChkNRBAccountPay.Checked)
            {
                if (FromAccountAmount < Convert.ToDouble(dt_Charge.Rows[0]["TotalCharge"]))
                {
                    throw new Exception("Min charge amount " + ApplicationChargeAmount.ToString() + " is require.");
                }
                foreach (DataGridViewRow row in dg_AddNRBCustomers.Rows)
                {
                    IPoAccountBalance = IPOAccpuntInformation(Convert.ToString(row.Cells["N_Cust_Code"].Value));
                    if (FromAccountAmount > IPoAccountBalance)
                    {
                        throw new Exception("" + Convert.ToString(row.Cells["N_Cust_Code"].Value) + " Have not sufficient Balance \n your balance is : " + IPoAccountBalance);
                    }
                }
            }
             
            if (chkCharge.Checked)
            {
                if (FromAccountAmount > IPoAccountBalance)
                {
                    throw new Exception("You Have not sufficient Balance \n your balance is : " + IPoAccountBalance);
                }
                foreach (DataGridViewRow row in dg_AddNRBCustomers.Rows)
                {
                    IPoAccountBalance = IPOAccpuntInformation(Convert.ToString(row.Cells["N_Cust_Code"].Value));
                    if (FromAccountAmount > IPoAccountBalance)
                    {
                        throw new Exception("" + Convert.ToString(row.Cells["N_Cust_Code"].Value) + " Have not sufficient Balance \n your balance is : " + IPoAccountBalance);
                    }
                }
            }
            
            if ((FromAccountAmount + CashAmount) < ApplicationChargeAmount)
            {
                throw new Exception("Min charge amount " + ApplicationChargeAmount.ToString() + " is require.");
            }
        }

        private void chkCharge_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCharge.Checked)
            {
                txtNRBCharge.Enabled = true;
                txtNRBCharge.Text = "";
                txtNRBCharge.Focus();
            }
            else
            {
                txtNRBCharge.Enabled = false;
                txtNRBCharge.Text = dt_Charge.Rows[0]["TotalCharge"].ToString();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            int ID = dg_NRB.SelectedRows.Cast<DataGridViewRow>().Select(c => Convert.ToInt32(c.Cells["Trn_ID"].Value)).First();
            string App_Status = dg_NRB.SelectedRows.Cast<DataGridViewRow>().Select(c => Convert.ToString(c.Cells["App_Status"].Value)).First();
            try
            {
                if (App_Status.Trim() == "Pending")
                {
                    if (DialogResult.Yes == MessageBox.Show("Are you Sure you want to delete this data", "", MessageBoxButtons.YesNo))
                    {
                        Bal.GetNRB_DeleteData(ID);
                        MessageBox.Show("Delete Successfully", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Load_GridData();
                    }
                }
                else
                {
                    throw new Exception("you can not Delete Approve Transaction");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        

        private void cmbBankName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    cmbBankBranch.Focus();
                    string BankCode = cmbBankName.SelectedValue.ToString();
                    if (!string.IsNullOrEmpty(BankCode))
                    {
                        LoadBranch(BankCode);
                    }
                }
                catch (Exception)
                {
                    cmbBankBranch.DataSource = null;
                    txtrouting.Text = "";
                }
            }
        }

        private void TabNRBDeposit_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (CurrentFormName == FormName.NRBDeposit)
            {
                if (e.TabPage.Name == "NRBWithdraw")
                {
                    e.Cancel = true;

                }
            }
            else if (CurrentFormName == FormName.NRBWithdraw)
            {
                if (e.TabPage.Name == "NRBDeposit")
                {
                    e.Cancel = true;
                }
            }
        }

        private void txtWithdrawcustCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    txtvoucherno.Text = string.Empty;
                    _nrbApplicationstatus = Bal.CheckNrbAccountStatus(txtWithdrawcustCode.Text, (int)cmbRefundCompanyName.SelectedValue,txtvoucherno.Text);
                    if (_nrbApplicationstatus.Trim() != "Unsuccessful")
                    {
                        txtWithdrawcustCode.Focus();
                        throw new Exception("Draft is not Eligible For withdraw \n Draft status is: (" + _nrbApplicationstatus + ")");
                    }
                    else
                    {
                        txtreceiverName.Focus();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void dg_NRB_DataSourceChanged(object sender, EventArgs e)
        {
            
        }

        private void Dg_NRB_Refund_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Dg_NRB_Refund.CommitEdit(DataGridViewDataErrorContexts.Commit);
            if (Dg_NRB_Refund.Columns[e.ColumnIndex].Name == "Remove")
            {
                Dg_NRB_Refund.Rows.RemoveAt(e.RowIndex);
                CurrencyCalculation();
            }
            //RowCheckBoxClick();
            //if (Dg_NRB_Refund.Columns[e.ColumnIndex].Name == "WarrantNo")
            //{
            //    this.Dg_NRB_Refund.Rows[e.RowIndex].Selected = true;
            //    this.Dg_NRB_Refund.Rows[e.RowIndex].Cells["WarrantNo"].ReadOnly = false;
            //}
            //else
            //{
            //    this.Dg_NRB_Refund.Rows[e.RowIndex].Selected = false;
            //    this.Dg_NRB_Refund.Rows[e.RowIndex].Cells["WarrantNo"].ReadOnly = true;
            //}
            
        }

        private void Dg_NRB_Refund_DataSourceChanged(object sender, EventArgs e)
        {
            label22.Text = "Count : " + Dg_NRB_Refund.Rows.Count;
        }

        private void txtreceiverName_KeyDown(object sender, KeyEventArgs e)
        {            
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (string.IsNullOrEmpty(txtreceiverName.Text))
                    {
                        txtreceiverName.Focus();
                        MessageBox.Show("Cell No is required");
                    }
                    else
                    {
                        RefundCode();
                    }
                }

            }
            
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RefundCode()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = Bal.Get_NRB_DraftReturnData(txtWithdrawcustCode.Text, (int)cmbRefundCompanyName.SelectedValue, txtvoucherno.Text);
                if (dt.Rows.Count > 0)
                {
                    if (Dg_NRB_Refund.Rows.Count > 0)
                    {
                        if (Dg_NRB_Refund.Rows.Cast<DataGridViewRow>().Select(c => Convert.ToString(c.Cells["Voucher"].Value)).ToList().Distinct()
                            != (dt.Rows.Cast<DataRow>().Select(c => Convert.ToString(c["Voucher_No"])).AsEnumerable().Distinct()))
                        {
                            MessageBox.Show("Different vouch or Duplicatie voucher no is not possible");
                        }
                    }
                    else
                    {
                        foreach (DataRow dr in dt.Rows)
                        {

                            string R_Reciver_Name = txtreceiverName.Text ?? string.Empty;
                            string R_ID = dr["ID"].ToString() ?? string.Empty;
                            string R_code = dr["Code"].ToString() ?? string.Empty;
                            string R_Draft_status = dr["Draft Status"].ToString();
                            string R_Name = dr["Client_Name"].ToString() ?? string.Empty;
                            string R_Bo_ID = dr["Bo_ID"].ToString() ?? string.Empty;
                            string R_DD_No = dr["DD No"].ToString() ?? string.Empty;
                            string R_Currency = dr["Currency"].ToString() ?? string.Empty;
                            string R_Amount = dr["Amount"].ToString() ?? string.Empty;
                            string R_Comp_code = dr["Comp_code"].ToString() ?? string.Empty;
                            string R_Bank_Name = dr["Bank_Name"].ToString() ?? string.Empty;
                            string R_Resident = dr["Resident"].ToString() ?? string.Empty;
                            string Voucher = dr["Voucher_No"].ToString() ?? string.Empty;
                            string WarrantNo = "";
                            Dg_NRB_Refund.Rows.Add(new object[] { R_ID, Voucher, R_code, R_DD_No, WarrantNo, R_Name, R_Bo_ID, R_Draft_status, R_Bank_Name, R_Currency, R_Amount, R_Comp_code, R_Resident, R_Reciver_Name });
                        }
                        Dg_NRB_Refund.FirstDisplayedScrollingRowIndex = Dg_NRB_Refund.Rows.IndexOf(Dg_NRB_Refund.Rows.Cast<DataGridViewRow>().Last());
                        //Dg_NRB_Refund.Rows.OfType<DataGridViewRow>().Last().Selected = true;
                        txtreceiverName.Text = "";
                        txtWithdrawcustCode.Text = "";
                        txtWithdrawcustCode.Focus();
                        label22.Text = "Count : " + Dg_NRB_Refund.Rows.Count;
                        //Dg_NRB_Refund.Rows[0].Selected = true;
                        Dg_NRB_Refund.Columns["WarrantNo"].DefaultCellStyle.BackColor = Color.White;
                        //Dg_NRB_Refund.Rows[0].Cells["WarrantNo"].EditType.
                    }
                }
                else
                {
                    if (Dg_NRB_Refund.Rows.Count > 0)
                    {
                        Dg_NRB_Refund.Rows.Clear();
                    }
                    label22.Text = "Count : " + Dg_NRB_Refund.Rows.Count;
                    MessageBox.Show("Available Withdraw Code is not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        
        private void LoadBranch(string BankCode)
        {
            DataTable dt = new DataTable();
            dt = Bal.GetAllBankName();
            if (!string.IsNullOrEmpty(BankCode))
            {
                cmbBankBranch.DataSource = dt.Rows.Cast<DataRow>()
                    .Where(c => Convert.ToString(c["Bank_Code"]) == BankCode)
                    .Select(t => new { BranchName = t["Branch_Name"], ID = t["ID"] }).ToList();

                cmbBankBranch.DisplayMember = "BranchName";
                cmbBankBranch.ValueMember = "ID";
                cmbBankBranch.SelectedIndex = -1;
            }
        }

        
        private void cmbBankName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //string BankCode = cmbBankName.SelectedValue.ToString();
            //if (!string.IsNullOrEmpty(BankCode))
            //{
            //    LoadBranch(BankCode);
            //}

            //try
            //{
            //    cmbBankBranch.Focus();
            //    string BankCode = cmbBankName.SelectedValue.ToString();
            //    if (!string.IsNullOrEmpty(BankCode))
            //    {
            //        LoadBranch(BankCode);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    cmbBankBranch.DataSource = null;
            //    txtrouting.Text = "";
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void cmbBankBranch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    string BankCode = cmbBankName.SelectedValue.ToString();
                    string BranchId = cmbBankBranch.SelectedValue.ToString();
                    if (!(string.IsNullOrEmpty(BankCode) && string.IsNullOrEmpty(BranchId)))
                    {
                        GetRoutingNo(BranchId, BankCode);
                    }
                    txtFDNO.Focus();
                }
                catch (Exception)
                {
                    txtrouting.Text = "";
                    MessageBox.Show("Bank Branch Name is invalid \n Please provide valid Bank Branch Name", "Branch Name Problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cmbBankBranch_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //try
            //{
            //    string BankCode = cmbBankName.SelectedValue.ToString();
            //    string BranchId = cmbBankBranch.SelectedValue.ToString();
            //    if (!(string.IsNullOrEmpty(BankCode) && string.IsNullOrEmpty(BranchId)))
            //    {
            //        GetRoutingNo(BranchId, BankCode);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    txtrouting.Text = "";
            //    MessageBox.Show(ex.Message);
            //}
            
        }
        private void GetRoutingNo(string BranchId,string BankCode)
        {
            if (!string.IsNullOrEmpty(BranchId))
            {
                DataTable dt = new DataTable();
                dt = Bal.GetAllBankName();
                string routing = dt.Rows.Cast<DataRow>()
                    .Where(c => Convert.ToString(c["ID"]) == BranchId
                        && Convert.ToString(c["Bank_Code"]) == BankCode)
                    .Select(c => Convert.ToString(c["Routing_No"])).FirstOrDefault();
                txtrouting.Text = routing;
            }
        }

        private void txtvoucherno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    //_nrbApplicationstatus = Bal.CheckNrbAccountStatus(txtWithdrawcustCode.Text, (int)cmbRefundCompanyName.SelectedValue, txtvoucherno.Text);
                    //if (_nrbApplicationstatus.Trim() != "Unsuccessful")
                    //{
                    txtWithdrawcustCode.Text = string.Empty;
                        txtreceiverName.Focus();
                    //    throw new Exception("Draft is not Eligible For withdraw \n Draft status is: (" + _nrbApplicationstatus + ")");
                    //}
                    //else
                    //{
                    //    txtreceiverName.Focus();
                    //}
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            if (Dg_NRB_Refund.Rows.Count > 0)
            {
                Dg_NRB_Refund.DataSource = null;
                Dg_NRB_Refund.ClearSelection();
                Dg_NRB_Refund.Rows.Clear();
                label22.Text = "";                
                Txt_CustCode.Text = "";
                txtvoucherno.Text = "";
                
            }
        }

        private void txtreceiverName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '+')
            {
                e.Handled = true;
            }
        }

        private void cmbBankName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbBankBranch.Focus();
                if (cmbBankName.SelectedIndex != -1)
                {
                    string BankCode = cmbBankName.SelectedValue.ToString();
                    if (!string.IsNullOrEmpty(BankCode))
                    {
                        LoadBranch(BankCode);
                    }
                }
            }
            catch (Exception)
            {
                cmbBankBranch.DataSource = null;
                txtrouting.Text = "";
                MessageBox.Show("Bank Name is incorrect Please Provide Valid Bank Name", "Bank Name Problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbBankName_Leave(object sender, EventArgs e)
        {
            if (!DtBank.Rows.Cast<DataRow>().Any(x => Convert.ToString(x["Bank_Name"]) == cmbBankName.Text))
            {
                cmbBankName.Focus();
                cmbBankBranch.DataSource = null;
                MessageBox.Show("Bank Name is incorrect Please Provide Valid Bank Name","Bank Name Problem",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void cmbBankBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string BankCode = cmbBankName.SelectedValue.ToString();
                string BranchId = cmbBankBranch.SelectedValue.ToString();
                if (!(string.IsNullOrEmpty(BankCode) && string.IsNullOrEmpty(BranchId)))
                {
                    GetRoutingNo(BranchId, BankCode);
                }
            }
            catch (Exception)
            {
                txtrouting.Text = "";
                //MessageBox.Show(ex.Message);
            }
        }

        private void cmbBankBranch_Leave(object sender, EventArgs e)
        {
            if (!DtBank.Rows.Cast<DataRow>().Where(c => Convert.ToString(c["Bank_Name"]) == cmbBankName.Text)
                .Select(c => Convert.ToString(c["Branch_Name"])).Any(c => c.Contains(cmbBankBranch.Text)))
            {                
                cmbBankBranch.Focus();
                txtrouting.Text = "";
                MessageBox.Show("Bank Branch Name is invalid \n Please provide valid Bank Branch Name","Bank Branch Name Problem",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void Dg_NRB_Refund_SelectionChanged(object sender, EventArgs e)
        {
            
            if (Dg_NRB_Refund.Rows.Count > 0)
            {
                string voucher_no = Dg_NRB_Refund.Rows[0].Cells["Voucher"].Value.ToString();
                foreach (DataGridViewRow row in Dg_NRB_Refund.Rows)
                {
                    if (row.Cells["Voucher"].Value.ToString() == voucher_no)
                    {
                        row.Cells["WarrantNo"].Selected = true;
                        row.Cells["WarrantNo"].Style.BackColor = Color.Bisque;
                    }
                }
            }
            
        }
       

        private void chkvoucherNo_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxSelection();
        }

        private void txtFDNO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FD_NO_EntryChecking();
                if (chkvoucherNo.Checked && (chkGBP.Checked || ChkUsd.Checked || ChkEUR.Checked))
                {
                    btnsave.Focus();
                }
            }
        }

        private void txt_NRB_Voucher_No_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnsave.Focus();
            }
        }

        private void CheckBoxSelection()
        {
            if (chkvoucherNo.Checked == false)
            {
                txt_NRB_Voucher_No.Text = "";
                if (ChkUsd.Checked)
                {
                    ChkUsd.Checked = false;
                }
                if (ChkEUR.Checked)
                {
                    ChkEUR.Checked = false;
                }
                if (chkGBP.Checked)
                {
                    chkGBP.Checked = false;
                }
            }
        }

        private void txtFDNO_Leave(object sender, EventArgs e)
        {
            try
            {
                FD_NO_EntryChecking();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void FD_NO_EntryChecking()
        {
            if (string.IsNullOrEmpty(txtFDNO.Text.Trim()))
            {
                txtFDNO.Focus();
                MessageBox.Show("Provide your DD NO ", "Empty DD NO ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DataTable dt = new DataTable();
                dt = Bal.GetIPO_NRB_DraftInformation(Convert.ToString(cmbCompanyName.SelectedValue), "");
                if (dt.Rows.Cast<DataRow>().Select(c => Convert.ToString(c["FD_NO"])).Contains(txtFDNO.Text))
                {
                    if (dt.Rows.Cast<DataRow>().Where(c => Convert.ToString(c["FD_NO"]) == Convert.ToString(txtFDNO.Text))
                        .Select(c => Convert.ToString(c["FD_NO"])).Count() >= 2)
                    {
                        if (DialogResult.Yes == MessageBox.Show("FD NO available this ipo ('" + cmbCompanyName.Text + "') \n Do you wish to save duplicate FD NO : " + txtFDNO.Text + " ?", "FD Number Checking", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                        {
                            if (chkvoucherNo.Checked && (chkGBP.Checked || ChkUsd.Checked || ChkEUR.Checked))
                            {
                                btnsave.Focus();
                            }
                        }
                        else
                        {
                            txtFDNO.Focus();
                        }
                    }
                    else
                    {
                        if (chkvoucherNo.Checked && (chkGBP.Checked || ChkUsd.Checked || ChkEUR.Checked))
                        {
                            btnsave.Focus();
                        }
                    }

                }
            }
        }

        private double IPOAccpuntInformation(string custcode)
        {
            double TotalCharge = 0.00;
            double TotalBalance = 0.00;
            double TotalLockAmount = 0.00;
            double PresentBalance = 0.00;
            try
            {
                
                IPOProcessBAL bal = new IPOProcessBAL();
                DataTable dt = new DataTable();
                
                dt = bal.GetIPOAccountInformation(custcode);
                TotalCharge = Convert.ToDouble(dt_Charge.Rows[0]["TotalCharge"].ToString());
                TotalBalance = Convert.ToDouble(dt.Rows.Cast<DataRow>().Select(c => Convert.ToDouble(c["Presenct_Balance"])).Sum());
                TotalLockAmount = Convert.ToDouble(dt.Rows.Cast<DataRow>().Select(c => Convert.ToDouble(c["LockAmount"])).Sum());
                if ((TotalBalance - TotalLockAmount) < TotalCharge)
                {
                    txtNrbAccountBalanace.Text = TotalBalance.ToString("N");
                    MessageBox.Show(""+custcode+" Current account Balance Is less then total Charge Amount \n your Present Balance is " + TotalBalance + " and Required Balance is "+TotalCharge+"", "Account Balance", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    txtNrbAccountBalanace.Text = TotalBalance.ToString("N");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            PresentBalance = (TotalBalance - TotalLockAmount);
            return PresentBalance;
        }
        private double IPOAccpunt_MoneyBalance(string custcode)
        {
            double TotalCharge = 0.00;
            double TotalBalance = 0.00;
            double TotalLockAmount = 0.00;
            double PresentBalance = 0.00;
            try
            {

                IPOProcessBAL bal = new IPOProcessBAL();
                DataTable dt = new DataTable();

                dt = bal.GetIPOAccountInformation(custcode);
                TotalCharge = Convert.ToDouble(dt_Charge.Rows[0]["TotalCharge"].ToString());
                TotalBalance = Convert.ToDouble(dt.Rows.Cast<DataRow>().Select(c => Convert.ToDouble(c["Presenct_Balance"])).Sum());
                TotalLockAmount = Convert.ToDouble(dt.Rows.Cast<DataRow>().Select(c => Convert.ToDouble(c["LockAmount"])).Sum());                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            PresentBalance = (TotalBalance - TotalLockAmount);
            return PresentBalance;
        }
        private void ChkNRBAccountPay_CheckedChanged(object sender, EventArgs e)
        {
            double AccountBalance = 0.00;
            double Total_Charge=0.00;
            Total_Charge = Convert.ToDouble(dt_Charge.Rows[0]["TotalCharge"].ToString());
            if (ChkNRBAccountPay.Checked)
            {
                //AccountBalance=IPOAccpuntInformation(Txt_CustCode.Text.Trim());
                
                chkCharge.Enabled = false;
                chkCharge.Checked = false;
                txtNRBCharge.Text = "";
                foreach (DataGridViewRow row in dg_AddNRBCustomers.Rows)
                {
                    AccountBalance = IPOAccpuntInformation(Convert.ToString(row.Cells["N_Cust_Code"].Value));
                    if (AccountBalance < Total_Charge)
                    {
                        txtNrbAccountBalanace.Text = AccountBalance.ToString();
                        ChkNRBAccountPay.BackColor = Color.Red;
                        txtNrbAccountBalanace.BackColor = Color.Red;
                        label23.BackColor = Color.Red;
                        txtNrbAccountBalanace.ForeColor = Color.White;
                        
                    }
                    else
                    {
                        txtNrbAccountBalanace.Text = Total_Charge.ToString();
                        ChkNRBAccountPay.BackColor = Color.Green;
                        txtNrbAccountBalanace.BackColor = Color.Green;
                        label23.BackColor = Color.Green;
                    }
                }
            }
            else
            {
                //IPOAccpuntInformation(Txt_CustCode.Text.Trim());
                txtNrbAccountBalanace.Text = "";
                txtNRBCharge.Text = Total_Charge.ToString();
                chkCharge.Enabled = true;
                txtNrbAccountBalanace.BackColor = Color.White;
                label23.BackColor = Color.Gray;
                ChkNRBAccountPay.BackColor = Color.Gray;
            }
        }

        private void txtNRBCharge_TextChanged(object sender, EventArgs e)
        {     
            double charge=Convert.ToDouble(dt_Charge.Rows[0]["TotalCharge"].ToString());
            if (txtNRBCharge.Text == string.Empty)
            {
                TotalCharge = 0.00;
            }
            else
            {
                TotalCharge =Convert.ToDouble(txtNRBCharge.Text);
                txtNrbAccountBalanace.Text = (charge - TotalCharge).ToString();
            }
        }
        

        private void chkBankSelection_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBankSelection.Checked==false)
            {
                cmbBankName.SelectedIndex = -1;
                cmbBankBranch.SelectedIndex = -1;
                dtp_DraftDate.Value = DateTime.Today;
                txtrouting.Text = "";
                cmbBankName.Focus();
            }
            else if (chkBankSelection.Checked == true)
            {
                dtp_DraftDate.Value = Convert.ToDateTime(Date);
            }
        }

        private void dg_AddNRBCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex == 4)
            //{
            //    dg_AddNRBCustomers.Rows.RemoveAt(e.RowIndex);
            //}
            //Dg_NRB_Refund.CommitEdit(DataGridViewDataErrorContexts.Commit);
            if (dg_AddNRBCustomers.Columns[e.ColumnIndex].Name == "Delete")
            {
                dg_AddNRBCustomers.Rows.RemoveAt(e.RowIndex);
                CurrencyCalculation();

            }
            
        }

        private void cmbCompanyName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                LoadHeaderCurrency(Convert.ToInt32(cmbCompanyName.SelectedValue));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Company Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtp_DraftDate_ValueChanged(object sender, EventArgs e)
        {
            Date = dtp_DraftDate.Value.Date.ToShortDateString();
        }
        private void CheckCustomerAppliedOrNOT(string cus_code)
        {
            string sessionID = "";
            //string NRB_CustCoe = "";
            string NRB_ApplicationCode = "";
            DataTable dtcompany = new DataTable();
            DataTable dtApplicationBasic = new DataTable();
            DataTable dtNrb = new DataTable();
            dtcompany = Bal.GetCompanyList_EligibleFor_Application();
            sessionID = dtcompany.Rows.Cast<DataRow>()
                .Where(c => Convert.ToString(c["Company_Short_Code"]) == cmbCompanyName.Text.Trim())
                .Select(s => Convert.ToString(s["Session_ID"])).FirstOrDefault();
            dtApplicationBasic = Bal.GetIPOApplicationTableDataByCustCode_SessionID_Check_IsAlreadyApply(cus_code, sessionID);
            //dtNrb = Bal.GetIPO_NRB_DraftInformation(Convert.ToString(cmbCompanyName.SelectedValue));
            //NRB_CustCoe = dtNrb.Rows.Cast<DataRow>().Where(c => Convert.ToString(c["Intended_IPOSession_ID"]) == sessionID
            //                                            && Convert.ToString(c["Cust_Code"]) == cus_code)
            //                                        .Select(c => Convert.ToString(c["Cust_Code"])).FirstOrDefault();
            NRB_ApplicationCode = dtApplicationBasic.Rows.Cast<DataRow>()
                .Where(c => Convert.ToString(c["IPOSession_ID"]) == sessionID
                                                        && Convert.ToString(c["Cust_Code"]) == cus_code)
                                                    .Select(c => Convert.ToString(c["Cust_Code"])).FirstOrDefault();
            if (!string.IsNullOrEmpty(NRB_ApplicationCode))
            {
               throw new Exception("Already Applied " + cus_code + "");
            }


        }

        
        private void RowCheckBoxClick()
        {
            foreach (DataGridViewRow Row in Dg_NRB_Refund.Rows)
            {
                if (((Row.Cells["WarrantNo"].Value) == null) || Row.Cells["WarrantNo"].Value != null)
                {
                    this.Dg_NRB_Refund.Rows[Row.Index].Cells["WarrantNo"].Selected = true;
                    this.Dg_NRB_Refund.Rows[Row.Index].Cells["WarrantNo"].ReadOnly = false;
                    //Row.DefaultCellStyle.SelectionBackColor = Color.LightSlateGray;
                    //this.Dg_NRB_Refund.Columns["WarrantNo"].DefaultCellStyle.BackColor = Color.LightSlateGray;
                    Row.Cells["WarrantNo"].Style.BackColor = Color.Bisque;
                }
                else
                {
                    this.Dg_NRB_Refund.Rows[Row.Index].Selected = false;
                    this.Dg_NRB_Refund.Rows[Row.Index].Cells["WarrantNo"].ReadOnly = true;
                }
            }
        }

        private void Dg_NRB_Refund_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                //RowCheckBoxClick();
            }
        }

        private void cmbRefundCompanyName_SelectedIndexChanged(object sender, EventArgs e)
        {
            SuccessfulUnsuccessfulDraft();            
        }
        private void SuccessfulUnsuccessfulDraft()
        {
            btnCancel.Visible = false;
            DataTable dt = new DataTable();
            DataTable dt_Company = new DataTable();
            dt_Company = Bal.GetCompanyShortCodeAndSessionID();
            dt = Bal.Get_NRB_DraftReturnData();

            string sessionId = cmbRefundCompanyName.Text;
            var AccordingToSession = dt.Rows.Cast<DataRow>().Where(c => Convert.ToString(c["Session"]) == Convert.ToString(sessionId)).ToList();
            if (AccordingToSession.Count > 0)
            {
                dg_NRB.DataSource = AccordingToSession.CopyToDataTable();
                dg_NRB.Columns["Trn_ID"].Visible = false;
                dg_NRB.Columns["App_ID"].Visible = false;
                dg_NRB.Columns["BasicInfo_ID"].Visible = false;
                if (dg_NRB.Rows.Count > 0)
                {
                    txt_Successful.Text = "NRB Successful : " + dg_NRB.Rows.Cast<DataGridViewRow>().AsEnumerable().Where(c => Convert.ToString(c.Cells["App_Status"].Value) == "Successfull").Count().ToString();
                    txt_Unsuccessful.Text = "NRB UnSuccessful : " + dg_NRB.Rows.Cast<DataGridViewRow>().AsEnumerable().Where(c => Convert.ToString(c.Cells["App_Status"].Value) == "Unsuccessfull").Count().ToString();
                    txt_takenByClient.Text = "NRB Draft Withdraw : " + dg_NRB.Rows.Cast<DataGridViewRow>().AsEnumerable().Where(c => Convert.ToString(c.Cells["NRB_Status"].Value) == "Taken By Client").Count().ToString();

                }
            }
            else
            {
                dg_NRB.DataSource = null;
                txt_Successful.Text = "NRB Successful : " + dg_NRB.Rows.Cast<DataGridViewRow>().AsEnumerable().Where(c => Convert.ToString(c.Cells["App_Status"].Value) == "Successfull").Count().ToString();
                txt_Unsuccessful.Text = "NRB UnSuccessful : " + dg_NRB.Rows.Cast<DataGridViewRow>().AsEnumerable().Where(c => Convert.ToString(c.Cells["App_Status"].Value) == "Unsuccessfull").Count().ToString();
                txt_takenByClient.Text = "NRB Draft Withdraw : " + dg_NRB.Rows.Cast<DataGridViewRow>().AsEnumerable().Where(c => Convert.ToString(c.Cells["NRB_Status"].Value) == "Taken By Client").Count().ToString();

            }
        }

        private void Dg_NRB_Refund_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btnsave.Focus();
            }
        }
    }
}
