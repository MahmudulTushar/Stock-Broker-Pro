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

namespace StockbrokerProNewArch
{
    public partial class CheckRequisition : Form
    {
        private string _boID = "";
        private string _custCode = "";
        private float _pendingRequisition = 0;
        private int _requisitionId;
        private string _requisitionStatus;
        
        private int  OnlineOrderNo;
        private DateTime? OnlineEntry_Date;
        
        public CheckRequisition()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            SearchCustomerInformation();
        }
        private void SearchCustomerInformation()
        {
            if (txtSearchCustomer.Text.Trim() != "")
            {
                txtlastTradeDate.Text = "";
                DataTable custDateTable = new DataTable();
                DataTable requisitionAmntDT=new DataTable();
                CheckRequisitionBAL checkRequisitionBal=new CheckRequisitionBAL();
                CustomerInfoBAL customerInfoBAL = new CustomerInfoBAL();

                PaymentInfoBAL paymentInfo = new PaymentInfoBAL();
                CommonBAL commbal = new CommonBAL();
                txtAccruedBalance.Text = paymentInfo.GetCurrentBalaneforAccrued(txtSearchCustomer.Text).ToString("N");
                txtAvailableWithBalance.Text = commbal.GetCurrentAvailAbleBalanceForWithdraw(txtSearchCustomer.Text).ToString("N"); 

                if (ddlSearchCustomer.SelectedItem.Equals("BO Id"))
                {
                    _boID = txtSearchCustomer.Text;
                    requisitionAmntDT= checkRequisitionBal.GetPendingRequisitionByBO(_boID);
                    if (requisitionAmntDT.Rows.Count > 0)
                        txtRequisitionBalance.Text = requisitionAmntDT.Rows[0][0].ToString();
                    custDateTable = customerInfoBAL.GetCustInfoByBOID(_boID);
                    if (custDateTable.Rows.Count > 0)
                    {
                        PaymentInfoBAL paymentInfoBal = new PaymentInfoBAL();
                        string _custCode = custDateTable.Rows[0][0].ToString();

                        txtCurrentBalance.Text = paymentInfoBal.GetCurrentBalane(_custCode).ToString("N");
                        txtMaturedBalance.Text = paymentInfoBal.GetMaturedBalane(_custCode).ToString("N");
                        txtCustCode.Text = custDateTable.Rows[0]["Cust_Code"].ToString();
                        txtAccountHolderName.Text = custDateTable.Rows[0]["Cust_Name"].ToString();
                        txtAccountHolderBOId.Text = custDateTable.Rows[0]["BO_ID"].ToString();
                        txtlastTradeDate.Text = custDateTable.Rows[0]["LTD"].ToString();
                        txtStatus.Text = custDateTable.Rows[0]["Status"].ToString();
                        LoadAvailAmount();
                    }
                    else
                    {
                        MessageBox.Show("No customer found.");
                        return;
                    }
                }
                else
                {
                    
                    txtAccruedBalance.Text = paymentInfo.GetCurrentBalaneforAccrued(txtSearchCustomer.Text).ToString("N");
                    txtAvailableWithBalance.Text = commbal.GetCurrentAvailAbleBalanceForWithdraw(txtSearchCustomer.Text).ToString("N"); 
                    _custCode = txtSearchCustomer.Text;
                    requisitionAmntDT = checkRequisitionBal.GetPendingRequisitionByCustCode(_custCode);
                    if (requisitionAmntDT.Rows.Count > 0)
                        txtRequisitionBalance.Text = requisitionAmntDT.Rows[0][0].ToString();
                    custDateTable = customerInfoBAL.GetCustInfoByCustCode(_custCode);
                    if (custDateTable.Rows.Count > 0)
                    {

                        PaymentInfoBAL paymentInfoBal = new PaymentInfoBAL();
                        txtCurrentBalance.Text = paymentInfoBal.GetCurrentBalane(_custCode).ToString("N");
                        txtMaturedBalance.Text = paymentInfoBal.GetMaturedBalane(_custCode).ToString("N");
                        txtCustCode.Text = custDateTable.Rows[0]["Cust_Code"].ToString();
                        txtAccountHolderName.Text = custDateTable.Rows[0]["Cust_Name"].ToString();
                        txtAccountHolderBOId.Text = custDateTable.Rows[0]["BO_ID"].ToString();
                        txtlastTradeDate.Text = custDateTable.Rows[0]["LTD"].ToString();
                        txtStatus.Text = custDateTable.Rows[0]["Status"].ToString();
                        LoadAvailAmount();

                    }
                    else
                    {
                        MessageBox.Show("No customer found.");
                        return;
                    }
                }

                if (Convert.ToDouble(txtCurrentBalance.Text) <= 0)
                {
                    txtCurrentBalance.BackColor = System.Drawing.Color.Red;
                }
                else
                {
                    txtCurrentBalance.BackColor = System.Drawing.Color.GreenYellow;
                }

                if (Convert.ToDouble(txtMaturedBalance.Text) <= 0)
                {
                    txtMaturedBalance.BackColor = System.Drawing.Color.Red;
                }
                else
                {
                    txtMaturedBalance.BackColor = System.Drawing.Color.GreenYellow;
                }
                txtAmount.Focus();
            }
        }

        private void LoadAvailAmount()
        {
            if (float.Parse(txtCurrentBalance.Text) < 0)
            {
                lblAmnt.Text = "0";

            }
            else if (double.Parse(txtAvailableWithBalance.Text) > 0 && txtRequisitionBalance.Text.Trim() != "")
            {
                lblAmnt.Text =Convert.ToString((double.Parse(txtCurrentBalance.Text) - double.Parse(txtRequisitionBalance.Text))-double.Parse(txtAccruedBalance.Text));
            }
            else if (double.Parse(txtAvailableWithBalance.Text) > 0 && txtRequisitionBalance.Text.Trim() == "")

            {
                lblAmnt.Text = Convert.ToString(double.Parse(txtAvailableWithBalance.Text));
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void ClearAll()
        {
            txtStatus.Text = "";
            txtSearchCustomer.Text = "";
            txtRemarks.Text = "";
            txtMaturedBalance.Text = "";
            txtlastTradeDate.Text = "";
            txtCustCode.Text = "";
            txtCurrentBalance.Text = "";
            txtAmount.Text = "";
            txtAccountHolderName.Text = "";
            txtAccountHolderBOId.Text = "";
            txtRequisitionBalance.Text = "";
            ddlBranchName.SelectedIndex = 0;
            ddlSearchCustomer.SelectedIndex = 0;
            lblAmnt.Text = "0";
            OnlineOrderNo = 0;
            OnlineEntry_Date = null;
        }

        private void CheckRequisition_Load(object sender, EventArgs e)
        {
            txtSearchCustomer.Focus();
            ddlSearchCustomer.SelectedIndex = 0;
            lblAmnt.Text = "0";
            LoadBranch();
            LoadDataIntoGrid();
        }
        private void LoadDataIntoGrid()
        {
            CheckRequisitionBAL checkRequisitionBal = new CheckRequisitionBAL();
            DataTable datatable = checkRequisitionBal.GetGridData(dtCheckRequisitionDate.Value);
            dtgCheckRequisitionInfo.DataSource = datatable;
            this.dtgCheckRequisitionInfo.Columns[0].Visible = false;
            dtgCheckRequisitionInfo.Columns[3].DefaultCellStyle.Format = "N";
            dtgCheckRequisitionInfo.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            lblTotalDep.Text = "Total Requisition: " + dtgCheckRequisitionInfo.Rows.Count.ToString();
        }

        private void LoadBranch()
        {
            LoadDDLBAL loadDDLBAL = new LoadDDLBAL();
            DataTable dtData = loadDDLBAL.LoadBranchesDDL();
            ddlBranchName.DataSource = dtData;
            ddlBranchName.DisplayMember = "Branch_Name";
            ddlBranchName.ValueMember = "Branch_ID";
            if (ddlBranchName.HasChildren)
                ddlBranchName.SelectedIndex = 0;          
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            LoadSaveInformation();
        }
        private void LoadSaveInformation()
        {
            if (ddlSearchCustomer.SelectedIndex == 0)
            {
                if (txtCustCode.Text != txtSearchCustomer.Text)
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
            if (txtStatus.Text.Equals("Closed"))
            {
                if (DialogResult.No ==MessageBox.Show("This is a Closed Account. Sure you want to continue?", "Closed Account", MessageBoxButtons.YesNo, MessageBoxIcon.Question,MessageBoxDefaultButton.Button2))
                {
                    ClearAll();
                    txtSearchCustomer.Focus();
                    return;
                }
            }
            SavePaymentInfo();
        }

        private void SavePaymentInfo()
        {
            if(txtRequisitionBalance.Text.Trim()!="")
                _pendingRequisition = float.Parse(txtRequisitionBalance.Text);
            if (txtSearchCustomer.Text.Trim() == "")
            {
                MessageBox.Show("Please Fill the Customer Code.");
                return;
            }
            if (txtAmount.Text.Trim() == "")
            {
                MessageBox.Show("Please Fill the Amount.");
                return;
            }
            if(txtAmount.Text.Trim()=="0")
            {
                MessageBox.Show("Please Enter Valid Amount.");
                return;
            }

            if (txtSearchCustomer.Text.Trim() != "90")
            {
                if (Convert.ToDouble(txtAvailableWithBalance.Text) < Convert.ToDouble(txtAmount.Text) + _pendingRequisition)
                {
                    MessageBox.Show("Insufficient Balance! Please check.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            try
            {
                CheckRequisitionBO checkRequisitionBo = new CheckRequisitionBO();
                checkRequisitionBo.CustCode = txtCustCode.Text;
                if (!String.IsNullOrEmpty(txtAmount.Text.Trim()))
                    checkRequisitionBo.Amount = float.Parse(txtAmount.Text);
                checkRequisitionBo.Remarks = txtRemarks.Text;
                checkRequisitionBo.RequisitionDate = dtRecievedDate.Value;
                checkRequisitionBo.BranchId =Convert.ToInt32(ddlBranchName.SelectedValue);
                checkRequisitionBo.OnlineOrderNo = OnlineOrderNo;
                if (OnlineEntry_Date != null)
                    checkRequisitionBo.OnlineEntry_Date = OnlineEntry_Date.Value;
                CheckRequisitionBAL checkRequisitionBal = new CheckRequisitionBAL();
                
                checkRequisitionBal.Insert(checkRequisitionBo);
                MessageBox.Show("Cheque Requisition Information Saved Successfully.");
                LoadDataIntoGrid();
                ClearAll();
                txtSearchCustomer.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fail to save Cheque Requisition Information because of the Error : " + ex.Message);
            }
        }

        private void ddlSearchCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "Return")
            {
                SearchCustomerInformation();
            }
        }

        private void txtAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "Return")
            {
                LoadSaveInformation();
            }
        }

        private void dtCheckRequisitionDate_ValueChanged(object sender, EventArgs e)
        {
            LoadDataIntoGrid();
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonBAL commonBal = new CommonBAL();
            commonBal.NumberValidate(txtAmount.Text, e);
        }

        private void btnRequisitionCancel_Click(object sender, EventArgs e)
        {
            if (dtgCheckRequisitionInfo.Rows.Count <= 0)
            {
                MessageBox.Show("No customer has select for Cancel Requisition", "Invalid Selection.");
                return;
            }
            if (_requisitionStatus != "Pending")
            {
                MessageBox.Show("The Selected Cheque has allready " + _requisitionStatus + ". It Can not be Cancel.",
                                "Invalid Selection.");
                return;
            }
            if (MessageBox.Show("Do you want to continue to cancel the Requisition?", "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    LoadDataFromGrid();
                    CheckRequisitionBAL checkRequisitionBal = new CheckRequisitionBAL();
                    checkRequisitionBal.CancelCheckRequisition(_requisitionId);
                    MessageBox.Show("Cheque Requisition successfully Canceled.");
                    LoadDataIntoGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Cheque Requisition Cancel unsuccessfull. Error Occured: " + ex.Message);
                }
            }
        }

        private void LoadDataFromGrid()
        {
           
            foreach (DataGridViewRow row in this.dtgCheckRequisitionInfo.SelectedRows)
            {
                if (dtgCheckRequisitionInfo[0, row.Index].Value != DBNull.Value)
                    _requisitionId = Convert.ToInt32(dtgCheckRequisitionInfo[0, row.Index].Value);
                _requisitionStatus = dtgCheckRequisitionInfo[5, row.Index].Value.ToString();
            }
           
        }

        private void dtgCheckRequisitionInfo_SelectionChanged(object sender, EventArgs e)
        {
            LoadDataFromGrid();
        }

        // Delegate Method LocalAgent

        private void WebDataCasting(CheckRequisitionBO bo)
        {
            CommonBAL bal = new CommonBAL();
            txtSearchCustomer.Text = bo.CustCode;
            txtAmount.Text = bo.Amount.ToString().Trim();
            txtRemarks.Text = bo.Remarks;
            ddlBranchName.SelectedIndex= - 1;
            dtRecievedDate.Value = bal.GetCurrentServerDate();
            OnlineOrderNo = bo.OnlineOrderNo;
            OnlineEntry_Date = bo.OnlineEntry_Date;
            if (bo.BranchId != 0 && bo.BranchId != null)
            {
                ddlBranchName.SelectedValue = bo.BranchId;
            }
            
            SearchCustomerInformation();
        }

        private void btnWebData_Click_1(object sender, EventArgs e)
        {
            frmWeb2014DataForward frm = new frmWeb2014DataForward("Money Withdraw Forward Check Requisition");
            frm.cr_Delegate = new frmWeb2014DataForward.DataToCheckRequisition(WebDataCasting);
            frm.Show();
        }


    }
}
