using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using BusinessAccessLayer.BO;

namespace StockbrokerProNewArch
{
    public partial class ExpenseApproval : Form
    {
        public ExpenseApproval()
        {
            InitializeComponent();
        }

        private void DepositApproval_Load(object sender, EventArgs e)
        {
            LoadGridData();
        }

        private void LoadGridData()
        {
            OpexBAL opexBal = new OpexBAL();
            DataTable datatable = opexBal.GetExpenseApproveList();
            dtgDepositInfo.DataSource = datatable;
            dtgDepositInfo.Columns[9].Visible = false;
            dtgDepositInfo.Columns[2].DefaultCellStyle.Format = "N";
            dtgDepositInfo.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            
            dtgDepositInfo.Columns[5].DefaultCellStyle.Format = "dd-MMM-yyyy";
            dtgDepositInfo.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgDepositInfo.Columns[6].DefaultCellStyle.Format = "MMM-yyyy";
            dtgDepositInfo.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            lblTotalDep.Text = "Total Requests : " + dtgDepositInfo.Rows.Count;
        }

        private void btnViewVoucharImage_Click(object sender, EventArgs e)
        {
            int index = dtgDepositInfo.SelectedRows[0].Index;
            if (index < 0)
                return;
            if (dtgDepositInfo.Rows[index].Cells["Expense_ID"].Value == DBNull.Value)
            {
                MessageBox.Show("Empty Image","Vouchar Image Message",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }

            if (dtgDepositInfo.Rows.Count > 0)
            {
                int ExpenseId =Int32.Parse(dtgDepositInfo.Rows[index].Cells["Expense_ID"].Value.ToString());
                OpexBAL objOpex = new OpexBAL();
                byte[] ImageBytes = objOpex.GetVoucherByte(ExpenseId);


                if (ImageBytes !=null &&ImageBytes.Length != 0)
                {
                    MemoryStream ms = new MemoryStream(ImageBytes);
                    ImageViewer imageViewer = new ImageViewer(Image.FromStream(ms));
                    imageViewer.Show();
                }
                else
                {
                    MessageBox.Show("Voucher Image-Not Found.", "Vouchar Image Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (dtgDepositInfo.Rows.Count <= 0)
            {
                MessageBox.Show("Approve list is Empty!", "Approve Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("Sure you want to approve?", "Approve Question", MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    int index = dtgDepositInfo.SelectedRows[0].Index;
                    if(index <0 )
                        return;
                    string expenseId = dtgDepositInfo.Rows[index].Cells["Expense_ID"].Value.ToString();
                    
                    OpexBAL opexBal = new OpexBAL();
                    opexBal.ApproveSelectedExpense(expenseId);
                    MessageBox.Show("Successfully Approved.","Approve Message",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    LoadGridData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Approved unsuccessfull. Error Occured: " + ex.Message);
                }
            }
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            if (dtgDepositInfo.Rows.Count <= 0)
            {
                MessageBox.Show("Approve list is Empty!", "Approve Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("Do you want to continue to Reject selected Deposit?", "Question", MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    DepRejectionReason rejectionReason = new DepRejectionReason();
                    rejectionReason.ShowDialog();

                    int index = dtgDepositInfo.SelectedRows[0].Index;
                    if (index < 0)
                        return;
                    string expenseId = dtgDepositInfo.Rows[index].Cells["Expense_ID"].Value.ToString();
                    string rejectReason = rejectionReason.txtRejectionReason.Text;
                    OpexBAL opexBal = new OpexBAL();
                    opexBal.RejectSelectedExpense(expenseId,rejectReason);

                    MessageBox.Show("Selected Expense has been Rejected","Reject Message",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    LoadGridData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Rejection unsuccessfull. Error Occured: " + ex.Message);
                }
            }
        }

        private void btnRejectAll_Click(object sender, EventArgs e)
        {
            if (dtgDepositInfo.Rows.Count <= 0)
            {
                MessageBox.Show("No customer has been select for Reject", "Invalid Selection.");
                return;
            }
            if (MessageBox.Show("Do you want to continue to Reject All selected Deposit?", "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    DepRejectionReason rejectionReason = new DepRejectionReason();
                    rejectionReason.ShowDialog();
                    foreach (DataGridViewRow row in dtgDepositInfo.Rows)
                    {
                        int index = row.Index;
                        string expenseId = dtgDepositInfo.Rows[index].Cells["Expense_ID"].Value.ToString();
                        string rejectReason = rejectionReason.txtRejectionReason.Text;
                        OpexBAL opexBal = new OpexBAL();
                        opexBal.RejectSelectedExpense(expenseId, rejectReason);
                    }
                   MessageBox.Show("All Selected Expense has been Rejected.");
                    LoadGridData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Rejection unsuccessfull. Error Occured: " + ex.Message);
                }
            }
        }

        private void btnAcceptAll_Click(object sender, EventArgs e)
        {
            if (dtgDepositInfo.Rows.Count <= 0)
            {
                MessageBox.Show("No customer has been select for Approved", "Invalid Selection.");
                return;
            }
            if (MessageBox.Show("Do you want to continue to Approved All selected Deposit?", "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    foreach (DataGridViewRow row in dtgDepositInfo.Rows)
                    {
                        int index = row.Index;
                        string expenseId = dtgDepositInfo.Rows[index].Cells["Expense_ID"].Value.ToString();

                        OpexBAL opexBal = new OpexBAL();
                        opexBal.ApproveSelectedExpense(expenseId);
                    }
                    MessageBox.Show("All expense request has been approved successfully.","Approve Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    LoadGridData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Approved unsuccessfull. Error Occured: " + ex.Message);
                }
            }
        }

        private void btnFetch_Click(object sender, EventArgs e)
        {
            try
            {
                LoadGridData();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
