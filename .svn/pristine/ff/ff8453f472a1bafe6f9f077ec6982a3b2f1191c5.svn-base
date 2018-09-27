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
    public partial class FrmIncomeApprov : Form
    {
        public FrmIncomeApprov()
        {
            InitializeComponent();
        }

        private void FrmIncomeApprov_Load(object sender, EventArgs e)
        {
            LoadGridView();
        }

        private void LoadGridView()
        {
            ExpenseTransactionBAL etBAL = new ExpenseTransactionBAL();
            string query = @"SELECT [ReceiptNo] as 'Receipt_No'
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
                                  ,[AccHead]
                              FROM [SBP_IncomeEntry]    
                              where Status='Pending'
                              order by ReceiptNo desc";
            dgvApproval.DataSource = etBAL.Get_Data(query);

            //dgvApproval.Columns["BInfo_ID"].Visible = false;

            lblCount.Text = Convert.ToString(dgvApproval.Rows.Count);
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (dgvApproval.Rows.Count <= 0)
            {
                MessageBox.Show("Approve list is Empty!", "Approval Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Want To Approve??", "Approval Alert!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) 
            {
                try
                {
                    int index = dgvApproval.SelectedRows[0].Index;
                    if (index < 0)
                        return;
                    int RctID = Convert.ToInt32(dgvApproval.Rows[index].Cells["Receipt_No"].Value.ToString());
                    //int BasicInfoID = Convert.ToInt32(dgvApproval.Rows[index].Cells["BInfo_ID"].Value.ToString());

                    string appvDate = GlobalVariableBO._currentServerDate.ToString("yyyy/MM/dd");

                    ExpenseApprovalBAL expenseApprovalBAL = new ExpenseApprovalBAL();
                    expenseApprovalBAL.ApproveSelectedIncome(RctID, appvDate);
                    MessageBox.Show("Successfully Approved.", "Approval Message...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadGridView();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Income Approval Denied. The Error : '"+ex+"'");
                }
            }
        }
        int x = 0;
        string ReceiptNos;
        private void btnApproveAll_Click(object sender, EventArgs e)
        {
            if (dgvApproval.Rows.Count <= 0)
            {
                MessageBox.Show("Approve List Is Empty!", "Approval Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Want To Approve All??", "Approval Alert!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    ReceiptNos = string.Empty;
                    x = 0;
                    foreach (DataGridViewRow row in dgvApproval.Rows)
                    {
                        int index = row.Index;
                        int RctID = Convert.ToInt32(dgvApproval.Rows[index].Cells["Receipt_No"].Value.ToString());
                        if (x == 0)
                        {
                            ReceiptNos = dgvApproval.Rows[index].Cells["Receipt_No"].Value.ToString();
                            ReceiptNos = "'" + ReceiptNos + "'";
                        }
                        else if (x > 0)
                        {
                            ReceiptNos = ReceiptNos + ",'" + dgvApproval.Rows[index].Cells["Receipt_No"].Value.ToString();
                            ReceiptNos = ReceiptNos + "'";
                        }
                        x++;
                        //int index = row.Index;
                        //int RctID = Convert.ToInt32(dgvApproval.Rows[index].Cells["Receipt_No"].Value.ToString());

                        //ExpenseApprovalBAL expenseApprovalBAL = new ExpenseApprovalBAL();
                        //expenseApprovalBAL.ApproveSelectedIncome(RctID);
                    }
                    ExpenseApprovalBAL expenseApprovalBAL = new ExpenseApprovalBAL();
                    string appvDate = GlobalVariableBO._currentServerDate.ToString("yyyy/MM/dd");
                    expenseApprovalBAL.ApproveAllSelectedIncome(ReceiptNos, appvDate);
                    MessageBox.Show("All Data Approved Successfully.", "Approval Message...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadGridView();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Income Approval All Denied. The Error : '" + ex + "'");
                }
            }
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            if (dgvApproval.Rows.Count <= 0)
            {
                MessageBox.Show("Reject List Is Empty!", "Rejection Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Want To Reject??", "Rejection Alert!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    int index = dgvApproval.SelectedRows[0].Index;
                    if (index < 0)
                        return;
                    int RctID = Convert.ToInt32(dgvApproval.Rows[index].Cells["Receipt_No"].Value.ToString());
                    string appvDate = GlobalVariableBO._currentServerDate.ToString("yyyy/MM/dd");

                    ExpenseApprovalBAL expenseApprovalBAL = new ExpenseApprovalBAL();
                    expenseApprovalBAL.RejectSelectedIncom(RctID, appvDate);
                    MessageBox.Show("Successfully Rejected.", "Rejection Message...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadGridView();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Income Rejection Denied. The Error : '" + ex + "'");
                }
            }
        }

        private void btnRejectAll_Click(object sender, EventArgs e)
        {
            if (dgvApproval.Rows.Count <= 0)
            {
                MessageBox.Show("Reject List Is Empty!", "Rejection Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Want To Reject All??", "Rejection Alert!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    ReceiptNos = string.Empty;
                    x = 0;
                    foreach (DataGridViewRow row in dgvApproval.Rows)
                    {
                        int index = row.Index;
                        int RctID = Convert.ToInt32(dgvApproval.Rows[index].Cells["Receipt_No"].Value.ToString());
                        if (x == 0)
                        {
                            ReceiptNos = dgvApproval.Rows[index].Cells["Receipt_No"].Value.ToString();
                            ReceiptNos = "'" + ReceiptNos + "'";
                        }
                        else if (x > 0)
                        {
                            ReceiptNos = ReceiptNos + ",'" + dgvApproval.Rows[index].Cells["Receipt_No"].Value.ToString();
                            ReceiptNos = ReceiptNos + "'";
                        }
                        x++;
                        //int index = row.Index;
                        //int RctID = Convert.ToInt32(dgvApproval.Rows[index].Cells["Receipt_No"].Value.ToString());

                        //ExpenseApprovalBAL expenseApprovalBAL = new ExpenseApprovalBAL();
                        //expenseApprovalBAL.ApproveSelectedIncome(RctID);
                    }
                    ExpenseApprovalBAL expenseApprovalBAL = new ExpenseApprovalBAL();
                    string appvDate = GlobalVariableBO._currentServerDate.ToString("yyyy/MM/dd");
                    expenseApprovalBAL.RejectAllSelectedIncome(ReceiptNos, appvDate);
                    MessageBox.Show("All Data Rejected Successfully.", "Rejection Message...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadGridView();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Income Rejection All Denied. The Error : '" + ex + "'");
                }
            }
        }
    }
}
