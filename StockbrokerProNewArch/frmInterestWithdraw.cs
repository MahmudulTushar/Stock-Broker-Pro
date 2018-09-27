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
    public partial class frmInterestWithdraw : Form
    {
        public enum FormState { DefauldMode, TransactionShown, TransactionNotShown, Checked_Changed_Withdraw, Checked_NotWithdraw, Checked_Changed_FromDate, Checked_Changed_ToDate };
        private DateTime CurrentDate;
        
        public frmInterestWithdraw()
        {
            InitializeComponent();
        }
       
        private void FormStateExecution(FormState st)
        {
            switch (st)
            {
                case FormState.DefauldMode:
                    txtCustCode.Enabled = true;
                    txtWithdrawAmount.Enabled = false;
                    chk_WithdrawAmount.Checked = false;
                    dtp_FromDate.Enabled = false;
                    chk_FromDate.Checked = false;
                    dtp_Todate.Enabled = false;
                    chk_ToDate.Checked = false;
                    btn_ShowTransaction.Enabled = true;
                    btn_Cancel.Enabled = false;
                    btn_Process.Enabled = false;
                    break;
                case FormState.TransactionNotShown:
                    btn_Process.Enabled = false;
                    btn_ShowTransaction.Enabled = true;
                    btn_Cancel.Enabled = false;
                    txtWithdrawAmount.Enabled = chk_WithdrawAmount.Checked;
                    dtp_FromDate.Enabled = chk_FromDate.Checked;
                    dtp_Todate.Enabled = chk_ToDate.Checked;
                    break;
                case FormState.TransactionShown:
                    btn_Process.Enabled = true;
                    btn_ShowTransaction.Enabled = false;
                    btn_Cancel.Enabled = true;
                    chk_WithdrawAmount.Checked = false;
                    txtWithdrawAmount.Enabled = false;
                    chk_FromDate.Checked = false;
                    dtp_FromDate.Enabled = false;
                    chk_ToDate.Checked = false;
                    dtp_Todate.Enabled = false;
                    break;
                case FormState.Checked_Changed_Withdraw:
                    txtWithdrawAmount.Enabled = chk_WithdrawAmount.Checked;
                    break;
                case FormState.Checked_Changed_FromDate:
                    dtp_FromDate.Enabled = chk_FromDate.Checked;
                    break;
                case FormState.Checked_Changed_ToDate:
                    dtp_Todate.Enabled = chk_ToDate.Checked;
                    break;             
            }
        }
        private void SetValueAccordingCustCode()
        {
            double doubleTryParse;
            string CustCode = string.Empty;
            double WithDrawAmount = 0.00;
            
            DateTime FromDate=new DateTime();
            DateTime ToDate=new DateTime();
            CustCode = txtCustCode.Text;
            
            InterestWithdrawBAL withBal = new InterestWithdrawBAL();
           
            if (!chk_FromDate.Checked)
            {
                FromDate = withBal.GetFirstDateOfInterestTrans(CustCode, CurrentDate);
            }
            if (!chk_ToDate.Checked)
            {
                ToDate = withBal.GetLastDateOfInterestTrans(CustCode, CurrentDate);
            }
            if (!chk_WithdrawAmount.Checked)
            {
                WithDrawAmount = withBal.GetSummaryTotalInterestAmount(CustCode, FromDate, ToDate);
            }
            dtp_FromDate.Value = FromDate;
            dtp_Todate.Value = ToDate;
            txtWithdrawAmount.Text = Convert.ToString(WithDrawAmount);
        }
        private void ClearAll()
        {
           
            //txtCustCode.Text = string.Empty;
            txtWithdrawAmount.Text = string.Empty;
            dtp_FromDate.Value = CurrentDate;
            dtp_Todate.Value = CurrentDate;
            dgv_Transaction.DataSource = null;
            dgv_SummaryTrans.DataSource = null;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double doubleTryParse;
                string CustCode=string.Empty;
                double WithDrawAmount=0.00;

                DateTime FromDate=new DateTime();
                DateTime ToDate=new DateTime();
                
                CustCode = txtCustCode.Text;

                Cursor.Current = Cursors.WaitCursor;

                InterestWithdrawBAL withBal = new InterestWithdrawBAL();
                
                FromDate = dtp_FromDate.Value.Date;
                ToDate = dtp_Todate.Value.Date;
                if (double.TryParse(txtWithdrawAmount.Text, out doubleTryParse))
                    WithDrawAmount = doubleTryParse;
    
                dgv_Transaction.DataSource = withBal.GetInterestTransaction(CustCode, WithDrawAmount, FromDate, ToDate);
                dgv_Transaction.Show();

                DataTable dt = new DataTable();
                dt = withBal.GetSummaryInterestTransaction(CustCode, WithDrawAmount, FromDate, ToDate);
                double diff = 0;
                diff = withBal.GetEstimated_RecalculationDiff(CustCode, WithDrawAmount, FromDate, ToDate);
                if (dt.Rows.Count > 0)
                    dt.Rows[0]["Estimated_RecalculationDifference"] = diff;
                dgv_SummaryTrans.DataSource = dt;
                dgv_SummaryTrans.Show();
                FormStateExecution(FormState.TransactionShown);
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Process_Click(object sender, EventArgs e)
        {
            InterestWithdrawBAL withBal= new InterestWithdrawBAL(); ;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                double doubleTryParse;
                string CustCode = string.Empty;
                double WithDrawAmount = 0.00;
                DateTime FromDate;
                DateTime ToDate;
                CustCode = txtCustCode.Text;

                if (double.TryParse(txtWithdrawAmount.Text, out doubleTryParse))
                    WithDrawAmount = doubleTryParse;
                FromDate = dtp_FromDate.Value.Date;
                ToDate = dtp_Todate.Value.Date;
                
                withBal.ConnectDatabase();
                
                int id=withBal.InsertIneterestWithdrawLog_UITransApplied(CustCode, FromDate, ToDate, WithDrawAmount, txt_Reference.Text, "");
                withBal.InterestWithdrawProcess_UITransApplied(CustCode, WithDrawAmount, FromDate, ToDate,id);
               
                withBal.Commit();
                MessageBox.Show("Successfully Done!!");
                FormStateExecution(FormState.DefauldMode);
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                withBal.RollBack();
                MessageBox.Show(ex.Message);
            }
            finally
            {
                withBal.CloseDatabase();
            }

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCustCode_TextChanged(object sender, EventArgs e)
        {
            FormStateExecution(FormState.TransactionNotShown);           
        }

        private void txtWithdrawAmount_TextChanged(object sender, EventArgs e)
        {
            FormStateExecution(FormState.TransactionNotShown);
        }

        private void dtp_FromDate_ValueChanged(object sender, EventArgs e)
        {

            try
            {
                CommonBAL cmBal = new CommonBAL();

                DateTime FromDate = cmBal.GetCompanyStartDate();
                DateTime ToDate = DateTime.Today;
                var CustCode = txtCustCode.Text;
                InterestWithdrawBAL intBal = new InterestWithdrawBAL();
                if (chk_FromDate.Checked)
                {
                    FormStateExecution(FormState.TransactionNotShown);
                    FromDate = dtp_FromDate.Value.Date;
                    if (chk_ToDate.Checked)
                        ToDate = dtp_Todate.Value.Date;
                    if (!chk_WithdrawAmount.Checked)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        txtWithdrawAmount.Text = Convert.ToString(intBal.GetSummaryTotalInterestAmount(txtCustCode.Text, FromDate, ToDate));
                        Cursor.Current = Cursors.Default;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void dtp_Todate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                CommonBAL cmBal = new CommonBAL();

                DateTime FromDate = cmBal.GetCompanyStartDate();
                DateTime ToDate = DateTime.Today;
                var CustCode = txtCustCode.Text;
                InterestWithdrawBAL intBal = new InterestWithdrawBAL();
                if (chk_ToDate.Checked)
                {
                    FormStateExecution(FormState.TransactionNotShown);
                    if (chk_FromDate.Checked)
                        FromDate = dtp_FromDate.Value.Date;
                    ToDate = dtp_Todate.Value.Date;
                    if (!chk_WithdrawAmount.Checked)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        txtWithdrawAmount.Text = Convert.ToString(intBal.GetSummaryTotalInterestAmount(txtCustCode.Text, FromDate, ToDate));
                        Cursor.Current = Cursors.Default;
                    }
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void frmInterestWithdraw_Load(object sender, EventArgs e)
        {
            CommonBAL comBal=new CommonBAL();
            FormStateExecution(FormState.DefauldMode);
            CurrentDate = comBal.GetCurrentServerDate();
        }

        private void chk_WithdrawAmount_CheckedChanged(object sender, EventArgs e)
        {
            FormStateExecution(FormState.Checked_Changed_Withdraw);
        }

        private void chk_FromDate_CheckedChanged(object sender, EventArgs e)
        {
            FormStateExecution(FormState.Checked_Changed_FromDate);            
        }

        private void chk_ToDate_CheckedChanged(object sender, EventArgs e)
        {
            FormStateExecution(FormState.Checked_Changed_ToDate);
        }

        private void txtCustCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                ClearAll();
                Cursor.Current = Cursors.WaitCursor;
                SetValueAccordingCustCode();
                FormStateExecution(FormState.TransactionNotShown);
                Cursor.Current = Cursors.Default;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ClearAll();
            FormStateExecution(FormState.DefauldMode);
        }

        

    }
}
