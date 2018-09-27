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
using DataAccessLayer;

namespace StockbrokerProNewArch
{
    public partial class FrmIncomeEntry : Form
    {
        //private DbConnection _dbConnection;
        Bank_Branch_ComboBAL RoutingBal = new Bank_Branch_ComboBAL();
        ExpenseTransactionBAL etBAL = new ExpenseTransactionBAL();
        IncomeEntryBAL incEntBAL = new IncomeEntryBAL();
        public FrmIncomeEntry()
        {
            InitializeComponent();
        }
        private void FrmIncomeEntry_Load(object sender, EventArgs e)
        {
            Starting();
            ReceiptNo();
            LoadGridData();
            LoadcmbAccountHead();

            //pnl_IPOChargeInformation.Visible = false;
            pnlOtherInformation.Visible = false;
            //pnlOtherInformation.Visible = false;

            //lblAccHead.Visible = false;
            //lblAccSubHead.Visible = false;
        }

        private void LoadcmbAccountHead()
        {
            DataTable dt;
            dt = incEntBAL.getHeadCode();
            cmbAccountHead.ViewColumn = 0;
            cmbAccountHead.Data = dt;
        }

        string x = "";
        private void LoadRoutingNo()
        {
            cmbRoutingNo.DataSource = RoutingBal.GetRoutingInfo();
            cmbRoutingNo.DisplayMember = "Routing_No";
            cmbRoutingNo.ValueMember = "Routing_No";
            cmbRoutingNo.Text = "Select Routing No";

            x = cmbRoutingNo.SelectedValue.ToString();
        }
        private void cmbRoutingNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            x = cmbRoutingNo.SelectedValue.ToString();
            string query = @"SELECT [Bank_Name],
                                    [Branch_Name],
                                    [District_Name]
                                    FROM SBP_Bank_Branch_Routing_Info 
                                    where Routing_No=" + x + @"
                                    ORDER BY [Routing_No]";
            dt = etBAL.Get_Data(query);
            txtBankName.Text = dt.Rows[0]["Bank_Name"].ToString();
            txtBranchName.Text = dt.Rows[0]["Branch_Name"].ToString();
            txtDistrictName.Text = dt.Rows[0]["District_Name"].ToString();
        }

        private void LoadGridData()
        {
            string sqlQuery = @"SELECT [ReceiptNo] as 'Receipt_No'      
                                      ,convert(varchar(10),[RcvDate],120) as 'Receive_Date'
                                      ,[RcvFrom] as 'Provider_Name'
                                      ,[ClientCode] as 'Client_Code'     
                                      ,[Dr_Amount] as 'Amount'     
                                      ,[Purpose]
                                      ,[TrnType] as 'Type'            
                                      ,[BankName] as 'Bank_Name'         
                                      ,[ChequeNo] as 'Cheque_No'
                                      ,convert(varchar(10),[PayDate],120) as 'Pay_Date'
                                      ,[Status]     
                                  FROM [SBP_Database].[dbo].[SBP_IncomeEntry]
                                  where VoucherSLNo =''
                                  order by ReceiptNo desc";
            dgvIncome.DataSource = etBAL.Get_Data(sqlQuery);
            lblCount.Text = Convert.ToString(dgvIncome.Rows.Count);
        }

        private void Starting()
        {
            cmbTransactionType.Text = "Select Transaction Type";

            txtReceiveFrom.Text = "";
            //txtClientCode.Text = "";
            txtAmount.Text = "";
            txtPurpose.Text = "";
            txtBankName.Text = "";
            txtBranchName.Text = "";
            txtDistrictName.Text = "";
            txtChequeNo.Text = "";

            cmbAccountHead.Text = "";
            cmbRoutingNo.Enabled = false;
            cmbRoutingNo.DataSource = null;
            txtBankName.Enabled = false;
            txtBranchName.Enabled = false;
            txtDistrictName.Enabled = false;
            txtChequeNo.Enabled = false;
            dtpPayDate.Enabled = false;

            //txtReceiveFrom.Focus();
            cmbAccountHead.Select();
            cmbAccountHead.Focus();
            btnSave.Enabled = true;
            btnDelete.Enabled = false;
        }
        private bool Checkvalidation()
        {
            double dp;

            //double amt = 0.00;
            //if (double.TryParse(txtAmount.Text.Trim(), out dp))
            //    amt = dp;

            //if (txtReceiveFrom.Text == "")
            //{
            //    MessageBox.Show("Please Write Provider Name...");
            //    txtReceiveFrom.Focus();
            //    return true;
            //}

            if (txtAmount.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please insert Amount...");
                txtAmount.Text = string.Empty;
                txtAmount.Focus();
                return true;
            }
            else if (!double.TryParse(txtAmount.Text.Trim(), out dp))
            {
                MessageBox.Show("Please Write Correct Formate...");
                txtAmount.Focus();
                return true;
            }
            else if (Convert.ToDouble(txtAmount.Text.Trim()) <= 0)
            {
                MessageBox.Show("Please Increase Amount...");
                txtAmount.Focus();
                return true;
            }

            //else if (txtAmount.Text.Trim() != string.Empty && amt == 0)
            //{
            //    MessageBox.Show("Please Increase Amount...");
            //    txtAmount.Focus();
            //    return true;
            //}

            //else if (txtPurpose.Text == "")
            //{
            //    MessageBox.Show("Please insert Purpose...");
            //    txtPurpose.Focus();
            //    return true;
            //}

            //else if (lblAccSubHead.Text == "I002i" && cmbIPOCompany.DataSource == null)
            //{
            //    MessageBox.Show("Not allowed to deposit as IPO Charge");
            //    cmbAccountHead.Focus();
            //    return true;
            //}

            else if (cmbTransactionType.Text == "Select Transaction Type")
            {
                MessageBox.Show("Please Select Transaction Type...");
                cmbTransactionType.Focus();
                return true;
            }
            else if (cmbTransactionType.Text == "Cehque" && cmbRoutingNo.Text == "Select Routing No")
            {
                MessageBox.Show("Please Choose Routing No...");
                cmbRoutingNo.Focus();
                return true;
            }


            else if (cmbTransactionType.Text == "Cehque" && txtChequeNo.Text == "")
            {
                MessageBox.Show("Please Insert Cheque No...");
                txtChequeNo.Focus();
                return true;
            }
            //else if(dtpPayDate.Value < dtpReceiveDate.Value )
            //{
            //    MessageBox.Show("The Pay Date is before than the Entry Date ");
            //    dtpPayDate.Focus();
            //    return true;
            //}

            else return false;
        }
        private void ReceiptNo()
        {
            string query = @"select count_big('ReceiptNo+1') as 'RctNo' from [SBP_Database].[dbo].[SBP_IncomeEntry]";
            DataTable dt = etBAL.Get_Data(query);

            //lblReceiptNo.Text = dt.Rows[0]["RctNo"].ToString();
        }
        private IncomeEntryBO InitializeBO()
        {
            IncomeEntryBO incEnBO = new IncomeEntryBO();
            ExpenseTransactionBAL BAL = new ExpenseTransactionBAL();

            //1.
            //int ClientCode = 0;
            //if(!string.IsNullOrEmpty(txtClientCode.Text))            
            //    ClientCode = Convert.ToInt32(txtClientCode.Text);


            //2.
            double doubleTryParse;
            double DAm = 0.00;
            if (double.TryParse(txtAmount.Text, out doubleTryParse))
                DAm = doubleTryParse;

            incEnBO.VoucherSLNo = "";
            incEnBO.RcvDate = Convert.ToDateTime(dtpReceiveDate.Value.ToShortDateString());
            incEnBO.RcvFrom = txtReceiveFrom.Text.Trim();
            //incEnBO.ClientCode = ClientCode;
            incEnBO.Dr_Cr = "Deposit";
            incEnBO.Dr_Amount = DAm;
            incEnBO.Cr_Amount = 0.00;
            incEnBO.Purpose = txtPurpose.Text.Trim();
            incEnBO.TrnType = cmbTransactionType.Text;
            incEnBO.AccHead = lblAccHead.Text;
            incEnBO.AccSubHead = lblAccSubHead.Text;
            incEnBO.RoutingNo = cmbRoutingNo.Text.Trim();
            incEnBO.BankName = txtBankName.Text.Trim();
            incEnBO.BankBranchName = txtBranchName.Text.Trim();
            incEnBO.DistrictName = txtDistrictName.Text.Trim();
            incEnBO.ChequeNo = txtChequeNo.Text.Trim();
            incEnBO.PayDate = dtpPayDate.Value;
            incEnBO.Status = "Pending";
            incEnBO.BrokerBranchID = GlobalVariableBO._branchId;
            incEnBO.EntryDate = GlobalVariableBO._currentServerDate;
            incEnBO.EntryBy = GlobalVariableBO._userName;
            incEnBO.UpdateDate = Convert.ToDateTime(GlobalVariableBO._currentServerDate.ToString("dd/MMM/yyy"));
            incEnBO.UpdateBy = GlobalVariableBO._userName;

            //incEnBO.SessionID = Convert.ToInt32(lblSessionID.Text.Trim());
            //incEnBO.SessionName = lblSessionName.Text.Trim();
            //incEnBO.BasicInfoID = BAL.GetNextIDOfIPO_AppBasicInfo();

            return incEnBO;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            IncomeEntryBO incEnBO = new IncomeEntryBO();
            if (Checkvalidation())
                return;

            etBAL.saveNewIncomeAtSBP_IncomeEntry(InitializeBO());
            MessageBox.Show("New Income Saved Successfully....", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Starting();
            ReceiptNo();
            LoadGridData();
        }

        private void cmbTransactionType_TextChanged(object sender, EventArgs e)
        {
            if (cmbTransactionType.Text == "Cehque")
            {
                LoadRoutingNo();
                cmbRoutingNo.Enabled = true;
                //txtBankName.Enabled = true;
                //txtBranchName.Enabled = true;
                //txtDistrictName.Enabled = true;
                txtChequeNo.Enabled = true;
                dtpPayDate.Enabled = true;
            }
            else if (cmbTransactionType.Text == "Cash")
            {

                cmbRoutingNo.Enabled = false;
                txtBankName.Enabled = false;
                txtBranchName.Enabled = false;
                txtDistrictName.Enabled = false;
                txtChequeNo.Enabled = false;
                dtpPayDate.Enabled = false;

                cmbRoutingNo.DataSource = null;
                txtBankName.Text = "";
                txtBranchName.Text = "";
                txtChequeNo.Text = "";
                dtpPayDate.Text = "";
            }
        }
        private void cmbAccountHead_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                txtAmount.Focus();
            }
        }
        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                txtReceiveFrom.Focus();
            }
        }
        private void txtReceiveFrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                //txtClientCode.Focus();
                txtPurpose.Focus();
            }
        }

        //private void txtClientCode_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == 13)
        //    {
        //        e.Handled = true;
        //        txtAmount.Focus();
        //    }            
        //}

    

        private void txtPurpose_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                cmbTransactionType.Focus();
            }
        }

        private void cmbTransactionType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                txtBankName.Focus();
            }
        }

        private void txtBankName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                txtChequeNo.Focus();
            }
        }

        private void txtAccountNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                dtpPayDate.Focus();
            }
        }

        private void dtpPayDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                btnSave.Focus();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Starting();
            ReceiptNo();
            LoadGridData();
        }


        private void dgvIncome_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnDelete.Enabled = true;
            btnSave.Enabled = false;

            int index = dgvIncome.SelectedRows[0].Index;
            if (index < 0)
                return;
            int RctID = Convert.ToInt32(dgvIncome.Rows[index].Cells["Receipt_No"].Value.ToString());

            DataTable dt = new DataTable();
            string SearchQuery = @"SELECT  [RcvDate]
                                          ,[RcvFrom]
                                          --,[ClientCode]
                                          ,[Dr_Amount]
                                          ,[Purpose]
                                          ,[TrnType]
                                          ,[RoutingNo]
                                          ,[BankName]
                                          ,[BankBranchName]
                                          ,[DistrictName]
                                          ,[ChequeNo]
                                          ,[PayDate]
                                      FROM [SBP_Database].[dbo].[SBP_IncomeEntry]
                                      where ReceiptNo=" + RctID + "";
            dt = etBAL.Get_Data(SearchQuery);

            //lblReceiptNo.Text=dt.Rows[0][0].ToString();
            dtpReceiveDate.Value = Convert.ToDateTime(dt.Rows[0][0].ToString());
            txtReceiveFrom.Text = dt.Rows[0][1].ToString();
            //txtClientCode.Text = dt.Rows[0][2].ToString();
            txtAmount.Text = dt.Rows[0][3].ToString();
            txtPurpose.Text = dt.Rows[0][4].ToString();
            cmbTransactionType.Text = dt.Rows[0][5].ToString();
            cmbRoutingNo.Text = dt.Rows[0][6].ToString();
            txtBankName.Text = dt.Rows[0][7].ToString();
            txtBranchName.Text = dt.Rows[0][8].ToString();
            txtDistrictName.Text = dt.Rows[0][9].ToString();
            txtChequeNo.Text = dt.Rows[0][10].ToString();
            //dtpPayDate.Value = Convert.ToDateTime(dt.Rows[0][11].ToString());
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Want To Delete??", "Deletion Alert!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    int index = dgvIncome.SelectedRows[0].Index;
                    if (index < 0)
                        return;
                    int RctID = Convert.ToInt32(dgvIncome.Rows[index].Cells["Receipt_No"].Value.ToString());

                    DataTable dt = new DataTable();
                    string SearchQuery = @"select Status from SBP_IncomeEntry where ReceiptNo=" + RctID + "";
                    dt = etBAL.Get_Data(SearchQuery);

                    if (dt.Rows[0]["Status"].ToString() == "Pending")
                    {
                        ExpenseApprovalBAL expenseApprovalBAL = new ExpenseApprovalBAL();
                        expenseApprovalBAL.DeleteIncome(RctID);
                        MessageBox.Show("Successfully Deleted.", "Deletion Message...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("It isn't possible to Delete...", "Deletion Alert!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    Starting();
                    ReceiptNo();
                    LoadGridData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Income Approval Denied. The Error : '" + ex + "'");
                }
            }
        }

        DataTable dt_SessionInformation = new DataTable();
        private void cmbAccountHead_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAccountHead.SelectedIndex > -1)
            {
                lblAccHead.Text = cmbAccountHead["HeadCode"].ToString();
                lblAccSubHead.Text = cmbAccountHead["HeadSubCode"].ToString();
            }

            //if (lblAccSubHead.Text == "I002i")
            //{
            //    dt_SessionInformation = incEntBAL.GetOpenIPOCompanySessionName();

            //    if (dt_SessionInformation.Rows.Count <= 0)
            //    {
            //        MessageBox.Show("No IPO Company Session Is Open...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //    else
            //    {
            //        pnl_IPOChargeInformation.Visible = true;
            //        pnlOtherInformation.Visible = false;


            //        cmbIPOCompany.DataSource = dt_SessionInformation;

            //        cmbIPOCompany.DisplayMember = "IPOSession_Name";
            //        cmbIPOCompany.ValueMember = "ID";

            //        lblSessionID.Text = cmbIPOCompany.SelectedValue.ToString();
            //        lblSessionName.Text = cmbIPOCompany.Text.Trim();
            //    }
            //}
            //else
            //{
            //    pnl_IPOChargeInformation.Visible = false;
            //    cmbIPOCompany.DataSource = null;
            //}
        }

        //private void cmbIPOCompany_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (cmbIPOCompany.DataSource == null)
        //    {
        //        lblSessionID.Text = string.Empty;
        //        lblSessionName.Text = string.Empty;
        //    }
        //    else
        //    {
        //        lblSessionID.Text = cmbIPOCompany.SelectedValue.ToString();
        //        lblSessionName.Text = cmbIPOCompany.Text.Trim();   
        //    }            
        //}
    }
}
