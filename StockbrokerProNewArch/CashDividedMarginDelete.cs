using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.BO;
using BusinessAccessLayer.BAL;
using System.Threading;

namespace StockbrokerProNewArch
{
    public partial class CashDividedMarginDelete : Form
    {

        public static bool IsProgressed;
        private CashDividedMarginLoanBAL cashDividedMarginLoanBAL = new CashDividedMarginLoanBAL();
        private CashDividedMarginLoanBO cashDividedMarginLoanBO = new CashDividedMarginLoanBO();
        private DataTable dt = new DataTable();
        public CashDividedMarginDelete()
        {
            InitializeComponent();
        }

        private void CashDividedMarginDelete_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        public void LoadData()
        {
            dtgBankData.DataSource = cashDividedMarginLoanBAL.LoadDataforReturn();
            dtgBankData.Columns[0].Visible = false;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            DialogResult myResult;
            myResult = MessageBox.Show("Are you really delete the item?", "Delete Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (myResult == DialogResult.OK)
            {
                Delete();
                cashDividedMarginLoanBAL.DeletePayment(cashDividedMarginLoanBO);
                cashDividedMarginLoanBAL.DeletePaymentPosting(cashDividedMarginLoanBO);
                cashDividedMarginLoanBAL.UpdateCashDividedMarginLoanDepositReturn(cashDividedMarginLoanBO);
                MessageBox.Show("Data Delete Successfully.", "Delete Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
           
           
        }

        public void Delete()
        {
            string CustCode = string.Empty;
            int Count = 0;
            foreach (DataRow dr in dt.Rows)
            {   
                if(Count > 0)
                   CustCode = CustCode + "," + dr[0].ToString();
                else
                    CustCode =dr[0].ToString();
                Count++;
            }
            cashDividedMarginLoanBO.ListCustCode = CustCode;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtgBankData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Thread thrd = new Thread(WaitWindow_Thread);
            IsProgressed = true;
            thrd.Start();
            var selectedRows = dtgBankData.SelectedRows;
            if (selectedRows.Count > 0)
            {
                cashDividedMarginLoanBO.CashDividedMarginLoanId = Convert.ToInt16(selectedRows[0].Cells["CashDividedofMarginLoanId"].Value);
                cashDividedMarginLoanBO.PercentageCash = Convert.ToDecimal(selectedRows[0].Cells["Percentage"].Value.ToString());
                cashDividedMarginLoanBO.FaceValue = Convert.ToDecimal(selectedRows[0].Cells["FaceValue"].Value.ToString());
                cashDividedMarginLoanBO.MDName = selectedRows[0].Cells["MD_Name"].Value.ToString();
                cashDividedMarginLoanBO.Address = selectedRows[0].Cells["Company_Address"].Value.ToString();
                cashDividedMarginLoanBO.CompanyName = selectedRows[0].Cells["CompanyName"].Value.ToString();
                cashDividedMarginLoanBO.RecordDate = Convert.ToDateTime(selectedRows[0].Cells["RecordDate"].Value.ToString());
                cashDividedMarginLoanBO.PhoneNo = selectedRows[0].Cells["PhoneNo"].Value.ToString();
                cashDividedMarginLoanBO.Email1 = selectedRows[0].Cells["Email1"].Value.ToString();
                cashDividedMarginLoanBO.Email2 = selectedRows[0].Cells["Email2"].Value.ToString();
                cashDividedMarginLoanBO.ReturnDate = Convert.ToDateTime(selectedRows[0].Cells["ReturnDate"].Value.ToString());
                dt = cashDividedMarginLoanBAL.GetCashDividedCustCodeFind(cashDividedMarginLoanBO.RecordDate, Convert.ToDecimal(cashDividedMarginLoanBO.FaceValue), Convert.ToDecimal(cashDividedMarginLoanBO.PercentageCash), cashDividedMarginLoanBO.CompanyName);
            }       
            IsProgressed = false;
        }

        public void LoadGride()
        {
            var selectedRows = dtgBankData.SelectedRows;
            if (selectedRows.Count > 0)
            {
                cashDividedMarginLoanBO.CashDividedMarginLoanId = Convert.ToInt16(selectedRows[0].Cells["CashDividedofMarginLoanId"].Value);
                cashDividedMarginLoanBO.PercentageCash = Convert.ToDecimal(selectedRows[0].Cells["Percentage"].Value.ToString());
                cashDividedMarginLoanBO.FaceValue = Convert.ToDecimal(selectedRows[0].Cells["FaceValue"].Value.ToString());
                cashDividedMarginLoanBO.MDName = selectedRows[0].Cells["MD_Name"].Value.ToString();
                cashDividedMarginLoanBO.Address = selectedRows[0].Cells["Company_Address"].Value.ToString();
                cashDividedMarginLoanBO.CompanyName = selectedRows[0].Cells["CompanyName"].Value.ToString();
                cashDividedMarginLoanBO.RecordDate = Convert.ToDateTime(selectedRows[0].Cells["RecordDate"].Value.ToString());
                cashDividedMarginLoanBO.PhoneNo = selectedRows[0].Cells["PhoneNo"].Value.ToString();
                cashDividedMarginLoanBO.Email1 = selectedRows[0].Cells["Email1"].Value.ToString();
                cashDividedMarginLoanBO.Email2 = selectedRows[0].Cells["Email2"].Value.ToString();
                cashDividedMarginLoanBO.ReturnDate = Convert.ToDateTime(selectedRows[0].Cells["ReturnDate"].Value.ToString());
                dt = cashDividedMarginLoanBAL.GetCashDividedCustCodeFind(cashDividedMarginLoanBO.RecordDate, Convert.ToDecimal(cashDividedMarginLoanBO.FaceValue), Convert.ToDecimal(cashDividedMarginLoanBO.PercentageCash), cashDividedMarginLoanBO.CompanyName);
            }
        }

        private void WaitWindow_Thread()
        {
            WaitWindow waitWindow = new WaitWindow();
            waitWindow.Show();
            while (IsProgressed)
            {
                waitWindow.Refresh();
            }
            waitWindow.Close();
        }
    }
}
