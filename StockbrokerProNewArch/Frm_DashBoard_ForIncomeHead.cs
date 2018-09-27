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
using System.Threading;

namespace StockbrokerProNewArch
{
    public partial class Frm_DashBoard_ForIncomeHead : Form
    {
        public Frm_DashBoard_ForIncomeHead()
        {
            InitializeComponent();
        }

        IncomeEntryBAL BAL = new IncomeEntryBAL();

        private void Frm_DashBoard_ForIncomeHead_Load(object sender, EventArgs e)
        {
            AllCheckBoxClear();
            AllTextBoxClear();
        }
        private void AllCheckBoxClear()
        {
            ChkExInterest.Checked = false;
            ChkExCommission.Checked = false;
            ChkExIPOCharge.Checked = false;
            ChkExBOOpeningCharge.Checked = false;
            ChkExBOCloseCharge.Checked = false;
            ChkExTaxCharge.Checked = false;
            ChkExTransmissionCharge.Checked = false;
            ChkExDemetCharge.Checked = false;
            ChkExCustodian.Checked = false;
            ChkExBankInterest.Checked = false;

            ChkExTaxChargeBank.Checked = false;
            ChkExTransmissionChargeBank.Checked = false;
            ChkExDemetChargeBank.Checked = false;
            ChkExCustodianBank.Checked = false;

            ChkAll.Checked = false;
        }

        private void CheckAllCheckBox()
        {
            ChkExInterest.Checked = true;
            ChkExCommission.Checked = true;
            ChkExIPOCharge.Checked = true;
            ChkExBOOpeningCharge.Checked = true;
            ChkExBOCloseCharge.Checked = true;
            ChkExTaxCharge.Checked = true;
            ChkExTransmissionCharge.Checked = true;
            ChkExDemetCharge.Checked = true;
            ChkExCustodian.Checked = true;
            ChkExBankInterest.Checked = true;

            ChkExTaxChargeBank.Checked = true;
            ChkExTransmissionChargeBank.Checked = true;
            ChkExDemetChargeBank.Checked = true;
            ChkExCustodianBank.Checked = true;

            ChkAll.Checked = true;
        }


        private void AllTextBoxClear()
        {
            txtExInterest.Text = string.Empty;
            txtExCommission.Text = string.Empty;
            txtExIPOCharge.Text = string.Empty;
            txtExBOOpeningCharge.Text = string.Empty;
            txtExBOCloseCharge.Text = string.Empty;
            txtExTaxCharge.Text = string.Empty;
            txtExTransmissionCharge.Text = string.Empty;
            txtExDemetCharge.Text = string.Empty;
            txtExCustodian.Text = string.Empty;
            txtExBankInterest.Text = string.Empty;

            txtExTaxCertificatChargeBank.Text = string.Empty;
            txtExTransChargeBank.Text = string.Empty;
            txtExDemetChargeBank.Text = string.Empty;
            txtExCustodianChargeBank.Text = string.Empty;

        }

        private void ChkExInterest_CheckedChanged(object sender, EventArgs e)
         {
             if (ChkExInterest.Checked == true)
             {
                 Thread thd = new Thread(waitWindowThread);
                 isProgress = true;
                 thd.Start();
                 txtExInterest.Text = string.Format("{0:0.00}", BAL.Dashboard_InterestBalance(GlobalVariableBO._currentServerDate.ToString("yyyy-MM-dd")));
                 isProgress = false;
             }
             else
             {
                 txtExInterest.Text = string.Empty;
             }
        }

        private void ChkExCommission_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkExCommission.Checked == true)
            {
                Thread thd = new Thread(waitWindowThread);
                isProgress = true;
                thd.Start();
                txtExCommission.Text = string.Format("{0:0.00}", BAL.Dashboard_CommissionBalance(GlobalVariableBO._currentServerDate.ToString("yyyy-MM-dd")));
                isProgress = false;
            }
            else
            {
                txtExCommission.Text = string.Empty;
            }
        }

        private void ChkExIPOCharge_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkExIPOCharge.Checked == true)
            {
                Thread thd = new Thread(waitWindowThread);
                isProgress = true;
                thd.Start();
                txtExIPOCharge.Text = string.Format("{0:0.00}", BAL.Dashboard_IPOChargeBalance(GlobalVariableBO._currentServerDate.ToString("yyyy-MM-dd")));
                isProgress = false;
            }
            else
            {
                txtExIPOCharge.Text = string.Empty;
            }
            
        }

        private void ChkExBOOpeningCharge_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkExBOOpeningCharge.Checked == true)
            {
                Thread thd = new Thread(waitWindowThread);
                isProgress = true;
                thd.Start();
                txtExBOOpeningCharge.Text = string.Format("{0:0.00}", BAL.Dashboard_BO_OpChargeBalance(GlobalVariableBO._currentServerDate.ToString("yyyy-MM-dd")));
                isProgress = false;
            }
            else
            {
                txtExBOOpeningCharge.Text = string.Empty;
            }
        }

        private void ChkExBOCloseCharge_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkExBOCloseCharge.Checked == true)
            {
                Thread thd = new Thread(waitWindowThread);
                isProgress = true;
                thd.Start();
                txtExBOCloseCharge.Text = string.Format("{0:0.00}", BAL.Dashboard_BO_CloseChargeBalance(GlobalVariableBO._currentServerDate.ToString("yyyy-MM-dd")));
                isProgress = false;
            }
            else
            {
                txtExBOCloseCharge.Text = string.Empty;
            }
        }

        private void ChkExTaxCharge_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkExTaxCharge.Checked == true)
            {
                Thread thd = new Thread(waitWindowThread);
                isProgress = true;
                thd.Start();
                txtExTaxCharge.Text = string.Format("{0:0.00}", BAL.Dashboard_TaxChargeBalance(GlobalVariableBO._currentServerDate.ToString("yyyy-MM-dd")));
                isProgress = false;
            }
            else
            {
                txtExTaxCharge.Text = string.Empty;
            }
        }

        private void ChkExTransmissionCharge_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkExTransmissionCharge.Checked == true)
            {
                Thread thd = new Thread(waitWindowThread);
                isProgress = true;
                thd.Start();
                txtExTransmissionCharge.Text = string.Format("{0:0.00}", BAL.Dashboard_TransmissionChargeBalance(GlobalVariableBO._currentServerDate.ToString("yyyy-MM-dd")));
                isProgress = false;
            }
            else
            {
                txtExTransmissionCharge.Text = string.Empty;
            }
        }

        private void ChkExDemetCharge_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkExDemetCharge.Checked == true)
            {
                Thread thd = new Thread(waitWindowThread);
                isProgress = true;
                thd.Start();
                txtExDemetCharge.Text = string.Format("{0:0.00}", BAL.Dashboard_DemetChargeBalance(GlobalVariableBO._currentServerDate.ToString("yyyy-MM-dd")));
                isProgress = false;
            }
            else 
            {
                txtExDemetCharge.Text = string.Empty;
            }
        }

        private void ChkExCustodian_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkExCustodian.Checked == true)
            {
                Thread thd = new Thread(waitWindowThread);
                isProgress = true;
                thd.Start();
                txtExCustodian.Text = string.Format("{0:0.00}", BAL.Dashboard_CustodianChargeBalance(GlobalVariableBO._currentServerDate.ToString("yyyy-MM-dd")));
                isProgress = false;
            }
            else
            {
                txtExCustodian.Text = string.Empty;
            }
        }

        private void ChkExBankInterest_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkExBankInterest.Checked == true)
            {
                Thread thd = new Thread(waitWindowThread);
                isProgress = true;
                thd.Start();
                txtExBankInterest.Text = string.Format("{0:0.00}", BAL.Dashboard_BankInterestChargeBalance(GlobalVariableBO._currentServerDate.ToString("yyyy-MM-dd")));
                isProgress = false;
            }
            else
            {
                txtExBankInterest.Text = string.Empty;
            }
        }

        private void ChkExTaxChargeBank_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkExTaxChargeBank.Checked == true)
            {
                //MessageBox.Show("Yet Not Ready....");
                Thread thd = new Thread(waitWindowThread);
                isProgress = true;
                thd.Start();
                txtExTaxCertificatChargeBank.Text = string.Format("{0:0.00}", BAL.Dashboard_TaxCharge_Bank_Balance(GlobalVariableBO._currentServerDate.ToString("yyyy-MM-dd")));
                isProgress = false;
            }
            else
            {
                txtExTaxCertificatChargeBank.Text = string.Empty;
            }
        }
        private void ChkExTransmissionChargeBank_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkExTransmissionChargeBank.Checked == true)
            {
                MessageBox.Show("Yet Not Ready....");
            }
            else
            {
                txtExTransChargeBank.Text = string.Empty;
            }
        }

        private void ChkExDemetChargeBank_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkExDemetChargeBank.Checked == true)
            {
                MessageBox.Show("Yet Not Ready....");
            }
            else
            {
                txtExDemetChargeBank.Text = string.Empty;
            }
        }

        private void ChkExCustodianBank_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkExCustodianBank.Checked == true)
            {
                MessageBox.Show("Yet Not Ready....");
            }
            else
            {
                txtExCustodianChargeBank.Text = string.Empty;
            }
        }


        private void ChkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkAll.Checked == true)
            {
                CheckAllCheckBox();
            }
            else
            { 
                //
            }
        }

        public static bool isProgress;
        private void waitWindowThread()
        {
            WaitWindow ww = new WaitWindow();
            ww.Show();
            while (isProgress)
            {
                ww.Refresh();
            }
            ww.Close();
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            AllCheckBoxClear();
            AllTextBoxClear();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
