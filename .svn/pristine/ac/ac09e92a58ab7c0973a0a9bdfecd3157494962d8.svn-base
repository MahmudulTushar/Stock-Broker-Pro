using System;
using System.Data;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using BusinessAccessLayer.BO;

namespace StockbrokerProNewArch
{
    public partial class CheckRequisitionApproval : Form
    {
        private PaymentInfoBO paymentInfoBo;
        private int _rejectionReqID;
        public static string _rejectionCustCode;
        public  string _custCodeForInfo;
        public CheckRequisitionApproval()
        {
            InitializeComponent();
        }
        private void LoadDataIntoGrid()
        {
            CheckRequisitionBAL checkRequisition = new CheckRequisitionBAL();
            DataTable datatable = checkRequisition.GetAllRequisitionForApproval();
            dtgCheckRequisitionInfo.DataSource = datatable;
            this.dtgCheckRequisitionInfo.Columns[0].Visible = false;
            dtgCheckRequisitionInfo.Columns[3].DefaultCellStyle.Format = "N";
            dtgCheckRequisitionInfo.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dtgCheckRequisitionInfo.Columns[4].DefaultCellStyle.Format = "dd-MMM-yyyy";
            dtgCheckRequisitionInfo.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            if(dtgCheckRequisitionInfo.Rows.Count<=0)
                ClearAll();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            LoadDataIntoGrid();
        }

        private void CheckRequisitionApproval_Load(object sender, EventArgs e)
        {
            LoadDataIntoGrid();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if(dtgCheckRequisitionInfo.Rows.Count<=0)
            {
                MessageBox.Show("No customer has been select for Approved", "Invalid Selection.");
                return;
            }
            if (MessageBox.Show("Do you want to continue to Approved selected Cheque?", "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    LoadDataFromGrid();
                    CheckRequisitionBAL checkRequisitionBal = new CheckRequisitionBAL();
                    checkRequisitionBal.ApprovedSingleCheck(paymentInfoBo);
                    MessageBox.Show("Cheque Requisition successfully Approved.");
                    LoadDataIntoGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Approved unsuccessfull. Error Occured: " + ex.Message);
                }
            }
        }

        private void LoadDataFromGrid()
        {
            paymentInfoBo=new PaymentInfoBO();
            foreach (DataGridViewRow row in this.dtgCheckRequisitionInfo.SelectedRows)
            {
                if (dtgCheckRequisitionInfo[0, row.Index].Value != DBNull.Value)
                    paymentInfoBo.RequisitionId = Convert.ToInt32(dtgCheckRequisitionInfo[0, row.Index].Value);
                paymentInfoBo.CustCode = dtgCheckRequisitionInfo[1, row.Index].Value.ToString();
                if (dtgCheckRequisitionInfo[3, row.Index].Value != DBNull.Value)
                    paymentInfoBo.Amount = (float)Convert.ToDouble(dtgCheckRequisitionInfo[3, row.Index].Value);
                if (dtgCheckRequisitionInfo[4, row.Index].Value != DBNull.Value)
                {
                    paymentInfoBo.RecievedDate = Convert.ToDateTime(dtgCheckRequisitionInfo[4, row.Index].Value);
                    paymentInfoBo.PaymentMediaDate = Convert.ToDateTime(dtgCheckRequisitionInfo[4, row.Index].Value);
                }
                paymentInfoBo.DepositWithdraw = "Withdraw";
                paymentInfoBo.PaymentMedia = "Check";
                paymentInfoBo.PaymentApprovedBy = GlobalVariableBO._userName;

                lblRecord.Text = "Total Record : " + dtgCheckRequisitionInfo.Rows.Count;
            }           
        }

        private void btnAcceptAll_Click(object sender, EventArgs e)
        {
            if (dtgCheckRequisitionInfo.Rows.Count <= 0)
            {
                MessageBox.Show("No customer has been select for Approved", "Invalid Selection.");
                return;
            }
            if (MessageBox.Show("Do you want to continue to Approved All selected Cheque?", "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    foreach (DataGridViewRow row in dtgCheckRequisitionInfo.Rows)
                    {
                        paymentInfoBo = new PaymentInfoBO();
                        if (dtgCheckRequisitionInfo[0, row.Index].Value != DBNull.Value)
                            paymentInfoBo.RequisitionId = Convert.ToInt32(dtgCheckRequisitionInfo[0, row.Index].Value);
                        paymentInfoBo.CustCode = dtgCheckRequisitionInfo[1, row.Index].Value.ToString();
                        if (dtgCheckRequisitionInfo[3, row.Index].Value != DBNull.Value)
                            paymentInfoBo.Amount = Convert.ToInt32(dtgCheckRequisitionInfo[3, row.Index].Value);
                        if (dtgCheckRequisitionInfo[4, row.Index].Value != DBNull.Value)
                        {
                            paymentInfoBo.RecievedDate = Convert.ToDateTime(dtgCheckRequisitionInfo[4, row.Index].Value);
                            paymentInfoBo.PaymentMediaDate =Convert.ToDateTime(dtgCheckRequisitionInfo[4, row.Index].Value);
                        }
                        paymentInfoBo.DepositWithdraw = "Withdraw";
                        paymentInfoBo.PaymentMedia = "Check";
                        CheckRequisitionBAL checkRequisitionBal = new CheckRequisitionBAL();
                        checkRequisitionBal.ApprovedSingleCheck(paymentInfoBo);
                    }
                    MessageBox.Show("All Cheque Requisition successfully Approved.");
                    LoadDataIntoGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Approved unsuccessfull. Error Occured: " + ex.Message);
                }
            }
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            if (dtgCheckRequisitionInfo.Rows.Count <= 0)
            {
                MessageBox.Show("No customer has been select for Reject", "Invalid Selection.");
                return;
            }
            if (MessageBox.Show("Do you want to continue to Reject selected Cheque?", "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    LoadDataFromGridForReject();
                    CheckRequisitionBAL checkRequisitionBal = new CheckRequisitionBAL();
                    RejectionReason rejectionReason = new RejectionReason();
                    rejectionReason.ShowDialog();
                    checkRequisitionBal.RejectSingleCheck(_rejectionReqID, RejectionReason._rejectionReason);
                    MessageBox.Show("Cheque Requisition has Rejected.");
                    LoadDataIntoGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Rejection unsuccessfull. Error Occured: " + ex.Message);
                }
            }
        }
        private void LoadDataFromGridForReject()
        {
            paymentInfoBo = new PaymentInfoBO();
            foreach (DataGridViewRow row in this.dtgCheckRequisitionInfo.SelectedRows)
            {
                if (dtgCheckRequisitionInfo[0, row.Index].Value != DBNull.Value)
                    _rejectionReqID = Convert.ToInt32(dtgCheckRequisitionInfo[0, row.Index].Value);
                _rejectionCustCode= dtgCheckRequisitionInfo[1, row.Index].Value.ToString();
            }
        }

        private void btnRejectAll_Click(object sender, EventArgs e)
        {
            if (dtgCheckRequisitionInfo.Rows.Count <= 0)
            {
                MessageBox.Show("No customer has been select for Reject", "Invalid Selection.");
                return;
            }
            if (MessageBox.Show("Do you want to continue to Reject All selected Cheque?", "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    _rejectionCustCode = "All Selected";
                    RejectionReason rejectionReason = new RejectionReason();
                    rejectionReason.ShowDialog();
                    foreach (DataGridViewRow row in dtgCheckRequisitionInfo.Rows)
                    {
                        if (dtgCheckRequisitionInfo[0, row.Index].Value != DBNull.Value)
                            _rejectionReqID = Convert.ToInt32(dtgCheckRequisitionInfo[0, row.Index].Value);
                        CheckRequisitionBAL checkRequisitionBal = new CheckRequisitionBAL();
                        checkRequisitionBal.RejectSingleCheck(_rejectionReqID, RejectionReason._rejectionReason);
                    }
                    MessageBox.Show("All Cheque Requisition has Rejected.");
                    LoadDataIntoGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Rejection unsuccessfull. Error Occured: " + ex.Message);
                }
            }
        }

        private void dtgCheckRequisitionInfo_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.dtgCheckRequisitionInfo.SelectedRows)
            {
                _custCodeForInfo = dtgCheckRequisitionInfo[1, row.Index].Value.ToString();
            }
            LoadCustInfo(_custCodeForInfo);

        }

        private void LoadCustInfo(string custCodeForInfo)
        {
            if (dtgCheckRequisitionInfo.Rows.Count <= 0)
            {
                ClearAll();
                return;
            }
            CheckRequisitionBAL checkRequisitionBal = new CheckRequisitionBAL();
            DataTable dataTable = new DataTable();
            dataTable = checkRequisitionBal.RetrieveCustInfo(custCodeForInfo);
            if (dataTable.Rows.Count > 0)
            {
                if (dataTable.Rows[0][0] != DBNull.Value)
                    txtLastTradeDate.Text = dataTable.Rows[0][0].ToString();
                if (dataTable.Rows[0][1] != DBNull.Value)
                    txtLastTradeAmount.Text = Convert.ToDecimal(dataTable.Rows[0][1].ToString()).ToString("N");
                if (dataTable.Rows[0][2] != DBNull.Value)
                    txtCurrentBalance.Text = Convert.ToDecimal(dataTable.Rows[0][2].ToString()).ToString("N");
                if (dataTable.Rows[0][3] != DBNull.Value)
                    txtMaturedBalance.Text = Convert.ToDecimal(dataTable.Rows[0][3].ToString()).ToString("N");
                if (dataTable.Rows[0][4] != DBNull.Value)
                    txtRequisitionBalance.Text = Convert.ToDecimal(dataTable.Rows[0][4].ToString()).ToString("N");
                if (dataTable.Rows[0][5] != DBNull.Value)
                    txtAccStatus.Text = dataTable.Rows[0][5].ToString();
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

            if (txtAccStatus.Text.Equals("Closed"))
            {
                txtAccStatus.BackColor = System.Drawing.Color.Red;
            }
            else
            {
                txtAccStatus.BackColor = System.Drawing.Color.GreenYellow;
            }
        }

        private void ClearAll()
        {
            txtRequisitionBalance.Text = "";
            txtLastTradeDate.Text = "";
            txtLastTradeAmount.Text = "";
            txtMaturedBalance.Text = "";
            txtMaturedBalance.BackColor = System.Drawing.Color.LightGray;
            txtCurrentBalance.Text = "";
            txtCurrentBalance.BackColor = System.Drawing.Color.LightGray;
           
        }
    }
}
