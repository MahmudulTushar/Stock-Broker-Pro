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
    public partial class FrmReceivedOfficeExpenseDelete : Form
    {
        BO_Opening_InformationBAL BoDeleteBal = new BO_Opening_InformationBAL();
        public FrmReceivedOfficeExpenseDelete()
        {
            InitializeComponent();
        }
        private void FrmReceivedOfficeExpenseDelete_Load(object sender, EventArgs e)
        {
            GridViewLoad();                      
        }

        private void GridViewLoad()
        {
            //DateTime searchDate = dtpSearchDate.Value;
            ExpenseTransactionBAL etBal = new ExpenseTransactionBAL();
            dgvSearchInformation.DataSource = etBal.getReceivedOfficeExpenseDataWithoutValue();
            lblCount.Text = Convert.ToString(dgvSearchInformation.Rows.Count);
        }

         private void btnSearch_Click(object sender, EventArgs e)
         {
             DateTime searchDate = dtpSearchDate.Value;
             ExpenseTransactionBAL etBal = new ExpenseTransactionBAL();
             dgvSearchInformation.DataSource = etBal.getReceivedOfficeExpenseData(searchDate);
             lblCount.Text = Convert.ToString(dgvSearchInformation.Rows.Count);

             btnDelete.Enabled = true;             
         }

         private void btnDelete_Click(object sender, EventArgs e)
         {
             if (MessageBox.Show("Sure you want to delete?", "Warning!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
             {
                 ExpenseApprovalBAL expenseApprovalBAL = new ExpenseApprovalBAL();
                 try
                 {
                     int index = dgvSearchInformation.SelectedRows[0].Index;
                     if (index < 0)
                         return;
                     //DateTime RcvDate = Convert.ToDateTime(dgvSearchInformation.Rows[index].Cells["Date"].Value.ToString());
                     // string searchDate = Convert.ToString(dtpSearchDateWise.Value.ToString("yyyy-MM-dd"));
                     DateTime Rdate = Convert.ToDateTime(dgvSearchInformation.Rows[index].Cells["Date"].Value.ToString());
                     string voucher_No = dgvSearchInformation.Rows[index].Cells["Voucher_No"].Value.ToString();

                     expenseApprovalBAL.DeleteReceivedOfficeExpense(Rdate, voucher_No);
                     MessageBox.Show("The Data Is Deleted Successfully...", "Approval Message...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     btnSearch_Click(sender, e);
                 }
                 catch (Exception ex)
                 {
                     MessageBox.Show("Income Approval Denied. The Error : '" + ex + "'");
                 }
             }             
         }

         private void btnClose_Click(object sender, EventArgs e)
         {
             this.Close();
         }
    }
}
