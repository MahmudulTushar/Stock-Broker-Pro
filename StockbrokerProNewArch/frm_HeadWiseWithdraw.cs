using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using System.Threading;
using BusinessAccessLayer.BO;

namespace StockbrokerProNewArch
{
    public partial class frm_HeadWiseWithdraw : Form
    {
        //select top 1 * from [SBP_Payment] order by Payment_ID desc
        //select top 1 * from SBP_Transactions where BuySellFlag='W' order by EventTime desc
        //select top 1 * from SBP_IPO_Application_BasicInfo order by id desc
        //select top 6 * from dbo.SBP_Payment_OOC order by Payment_OOC_ID desc
        //select top 1 * from SBP_IncomeEntry order by ReceiptNo desc

        IncomeEntryBAL BAL = new IncomeEntryBAL();
        double doubleTryParse;
        public static bool isProgress;

        public frm_HeadWiseWithdraw()
        {
            InitializeComponent();
        }

        private void frm_HeadWiseWithdraw_Load(object sender, EventArgs e)
        {
            pnlPaymentMedia.Enabled = true;
            panel2.Enabled = false;
            ep.Clear();

            inserting0();
            LoaddgvWithdrawHistory();
            sumOfCollectedAmount();

            txtWithdrawalAmount.Select();
            txtWithdrawalAmount.Focus();
        }

        private void LoaddgvWithdrawHistory()
        {
            DataTable dt;
            dt = BAL.GetWithdrawalHistory();
            dgvWithdrawHistory.DataSource = dt;
        }

        private void lilblCancel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frm_HeadWiseWithdraw_Load(sender, e);
        }

        private void sumOfCollectedAmount()
        {
            double NewInterest = 0;
            if (double.TryParse(txtNewInterest.Text.Trim(), out doubleTryParse))
                NewInterest = doubleTryParse;

            double NewCommission = 0;
            if (double.TryParse(txtNewCommission.Text.Trim(), out doubleTryParse))
                NewCommission = doubleTryParse;

            double NewIPOCharge = 0;
            if (double.TryParse(txtNewIPOCharge.Text.Trim(), out doubleTryParse))
                NewIPOCharge = doubleTryParse;

            double NewBOOpeningCharge = 0;
            if (double.TryParse(txtNewBOOpeningCharge.Text.Trim(), out doubleTryParse))
                NewBOOpeningCharge = doubleTryParse;

            double NewBOCloseCharge = 0;
            if (double.TryParse(txtNewBOCloseCharge.Text.Trim(), out doubleTryParse))
                NewBOCloseCharge = doubleTryParse;

            double NewTaxCharge = 0;
            if (double.TryParse(txtNewTaxCharge.Text.Trim(), out doubleTryParse))
                NewTaxCharge = doubleTryParse;

            double NewTransmissionCharge = 0;
            if (double.TryParse(txtNewTransmissionCharge.Text.Trim(), out doubleTryParse))
                NewTransmissionCharge = doubleTryParse;

            double NewDemetCharge = 0;
            if (double.TryParse(txtNewDemetCharge.Text.Trim(), out doubleTryParse))
                NewDemetCharge = doubleTryParse;

            double NewCustodian = 0;
            if (double.TryParse(txtNewCustodian.Text.Trim(), out doubleTryParse))
                NewCustodian = doubleTryParse;

            double NewBankInterest = 0;
            if (double.TryParse(txtNewBankInterest.Text.Trim(), out doubleTryParse))
                NewBankInterest = doubleTryParse;

            //
            double NewTaxCharge_Bank = 0;
            if (double.TryParse(txtNewTaxCertBank.Text.Trim(), out doubleTryParse))
                NewTaxCharge_Bank = doubleTryParse;

            double NewTransmissionCharge_Bank = 0;
            if (double.TryParse(txtNewTrnsBank.Text.Trim(), out doubleTryParse))
                NewTransmissionCharge_Bank = doubleTryParse;

            double NewDemetCharge_Bank = 0;
            if (double.TryParse(txtNewDemetBank.Text.Trim(), out doubleTryParse))
                NewDemetCharge_Bank = doubleTryParse;

            double NewCustodianCharge_Bank = 0;
            if (double.TryParse(txtNewCustodianBank.Text.Trim(), out doubleTryParse))
                NewCustodianCharge_Bank = doubleTryParse;
            //

            txtCollectedAmount.Text = Convert.ToString(NewInterest
                                                     + NewCommission
                                                     + NewIPOCharge
                                                     + NewBOOpeningCharge
                                                     + NewBOCloseCharge
                                                     + NewTaxCharge
                                                     + NewTransmissionCharge
                                                     + NewDemetCharge
                                                     + NewCustodian
                                                     + NewBankInterest
                                                     + NewTaxCharge_Bank
                                                     + NewTransmissionCharge_Bank
                                                     + NewDemetCharge_Bank
                                                     + NewCustodianCharge_Bank);
        }

        private void inserting0()
        {
            txtCollectedAmount.Text = "0.00";
            txtNewInterest.Text = "0.00";
            txtNewCommission.Text = "0.00";
            txtNewIPOCharge.Text = "0.00";
            txtNewBOOpeningCharge.Text = "0.00";
            txtNewBOCloseCharge.Text = "0.00";
            txtNewTaxCharge.Text = "0.00";
            txtNewTransmissionCharge.Text = "0.00";
            txtNewDemetCharge.Text = "0.00";
            txtNewCustodian.Text = "0.00";
            txtNewBankInterest.Text = "0.00";
            txtNewTaxCertBank.Text = "0.00";
            txtNewTrnsBank.Text = "0.00";
            txtNewDemetBank.Text = "0.00";
            txtNewCustodianBank.Text = "0.00";
            txtCollectedAmount.Text = "0.00";


            txtExistingBalance.Text = "0.00";
            txtExInterest.Text = "0.00";
            txtExCommission.Text = "0.00";
            txtExIPOCharge.Text = "0.00";
            txtExBOOpeningCharge.Text = "0.00";
            txtExBOCloseCharge.Text = "0.00";
            txtExTaxCharge.Text = "0.00";
            txtExTransmissionCharge.Text = "0.00";
            txtExDemetCharge.Text = "0.00";
            txtExCustodian.Text = "0.00";
            txtExBankInterest.Text = "0.00";
            txtExTaxCertBank.Text = "0.00";
            txtExTrnsBank.Text = "0.00";
            txtExDemetBank.Text = "0.00";
            txtExCustodianBank.Text = "0.00";

            txtWithdrawalAmount.Text = "0.00";

            txtVoucherNo.Text = string.Empty;
            cbCash.Checked = false;
            cbCheque.Checked = false;
        }

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

        private bool PrepareValidation()
        {           
            double WithdrawalAmount = 0;
            if (double.TryParse(txtWithdrawalAmount.Text.Trim(), out doubleTryParse))
                WithdrawalAmount = doubleTryParse;

            if (!double.TryParse(txtWithdrawalAmount.Text.Trim(), out doubleTryParse))
            {
                MessageBox.Show("Please Write Withdrawal Amount With Correct Formate...", "Information!");
                txtWithdrawalAmount.Focus();
                return true;
            }
            else if (WithdrawalAmount == 0)
            {
                MessageBox.Show("Please Write Withdrawal Amount...", "Information!");
                txtWithdrawalAmount.Text = "";
                txtWithdrawalAmount.Focus();
                return true;
            }
            else if (!(cbCash.Checked == true || cbCheque.Checked == true))
            {
                MessageBox.Show("Please Select Cash Or Cheque As Payment Media.", "Information!!");
                return true;
            }
            else if (cbCheque.Checked == true && PopUpBO._BankName == string.Empty)
            {
                MessageBox.Show("Should Set Cheque Information..." + "\r\n" + "Instruction: Check Re-again 'Cheque'");
                ep.SetError(cbCheque, "Check Re-again");
                return true;
            }

            else return false;
        }

        private void btnPrepare_Click(object sender, EventArgs e)
        {            
            if (PrepareValidation())
                return;

            IncomeEntryBAL incEntBAL = new IncomeEntryBAL();
            DataTable Dtable;
            Thread thd = new Thread(waitWindowThread);
            isProgress = true;
            thd.Start();

            DateTime Todate = DateTime.Now;
            Dtable = incEntBAL.IncomeSummeryForWithdraw(Todate);

            double ExInte = Convert.ToDouble(Dtable.Rows[0][0].ToString());
            txtExInterest.Text = string.Format("{0:0.00}", ExInte);

            double ExCommissio = Convert.ToDouble(Dtable.Rows[0][2].ToString());
            txtExCommission.Text = string.Format("{0:0.00}", ExCommissio);

            //double HCharge = 0;
            //if (double.TryParse(txtHouseCharge.Text, out doubleTryparse))
            //    HCharge = doubleTryparse;

            double ExIPOCha = 0.00;
            if (double.TryParse(Dtable.Rows[0][1].ToString(), out doubleTryParse))
                ExIPOCha = Convert.ToDouble(Dtable.Rows[0][1].ToString());
                txtExIPOCharge.Text = string.Format("{0:0.00}", ExIPOCha);


            //ExIPOCha = Convert.ToDouble(Dtable.Rows[0][1].ToString());
            //txtExIPOCharge.Text = string.Format("{0:0.00}", ExIPOCha);

            double OpCha = Convert.ToDouble((Dtable.Rows[0][3]).ToString());
            txtExBOOpeningCharge.Text = string.Format("{0:0.00}", OpCha);

            double ExBOCl = Convert.ToDouble((Dtable.Rows[0][4]).ToString());
            txtExBOCloseCharge.Text = string.Format("{0:0.00}", ExBOCl);

            double ExTaxCh = Convert.ToDouble((Dtable.Rows[0][5]).ToString());
            txtExTaxCharge.Text = string.Format("{0:0.00}", ExTaxCh);

            double ExTransmi = Convert.ToDouble((Dtable.Rows[0][6]).ToString());
            txtExTransmissionCharge.Text = string.Format("{0:0.00}", ExTransmi);

            double ExDemetCha = Convert.ToDouble((Dtable.Rows[0][7]).ToString());
            txtExDemetCharge.Text = string.Format("{0:0.00}", ExDemetCha);

            double ExCusto = Convert.ToDouble((Dtable.Rows[0][8]).ToString());
            txtExCustodian.Text = string.Format("{0:0.00}", ExCusto);

            double ExBankIn = Convert.ToDouble((Dtable.Rows[0][9]).ToString());
            txtExBankInterest.Text = string.Format("{0:0.00}", ExBankIn);

            double ExTaxCharge_Bank = Convert.ToDouble((Dtable.Rows[0][10]).ToString());
            txtExTaxCertBank.Text = string.Format("{0:0.00}", ExTaxCharge_Bank);

            double ExistingBalance = Math.Round(Convert.ToDouble(Dtable.Rows[0][0]), 2)
                                    + Math.Round(Convert.ToDouble(Dtable.Rows[0][2]), 2)
                                    + Math.Round(Convert.ToDouble(Dtable.Rows[0][1]), 2)
                                    + Math.Round(Convert.ToDouble(Dtable.Rows[0][3]), 2)
                                    + Math.Round(Convert.ToDouble(Dtable.Rows[0][4]), 2)
                                    + Math.Round(Convert.ToDouble(Dtable.Rows[0][5]), 2)
                                    + Math.Round(Convert.ToDouble(Dtable.Rows[0][6]), 2)
                                    + Math.Round(Convert.ToDouble(Dtable.Rows[0][7]), 2)
                                    + Math.Round(Convert.ToDouble(Dtable.Rows[0][8]), 2)
                                    + Math.Round(Convert.ToDouble(Dtable.Rows[0][9]), 2)
                                    + Math.Round(Convert.ToDouble(Dtable.Rows[0][10]), 2);

            //txtExistingBalance.Text = Convert.ToString(Math.Round(ExistingBalance,2));
            txtExistingBalance.Text = string.Format("{0:0.00}", ExistingBalance);

            pnlPaymentMedia.Enabled = false;
            panel2.Enabled = true;
            panel3.Enabled = true;
            txtNewInterest.Focus();           

            isProgress = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtNewInterest.Text = "0.00";
            txtNewCommission.Text = "0.00";
            txtNewIPOCharge.Text = "0.00";
            txtNewBOOpeningCharge.Text = "0.00";
            txtNewBOCloseCharge.Text = "0.00";
            txtNewTaxCharge.Text = "0.00";
            txtNewTransmissionCharge.Text = "0.00";
            txtNewDemetCharge.Text = "0.00";
            txtNewCustodian.Text = "0.00";
            txtNewBankInterest.Text = "0.00";
            txtNewTaxCertBank.Text = "0.00";
            txtNewTrnsBank.Text = "0.00";
            txtNewDemetBank.Text = "0.00";
            txtNewCustodianBank.Text = "0.00";
        }

        private void txtWithdrawalAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                double withdCharge = 0;
                if (double.TryParse(txtWithdrawalAmount.Text.Trim(), out doubleTryParse))
                    withdCharge = doubleTryParse;

                if (withdCharge == 0)
                {
                    MessageBox.Show("Please Write/Check Withdrawal Amount...", "Information!");
                    txtWithdrawalAmount.Focus();
                }
                else
                {
                    e.Handled = true;
                    cbCash.Focus();
                    cbCash.Checked = true;
                }
            }
        }

        private void cbCash_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                btnPrepare.Focus();
            }
        }
        private void cbCheque_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                btnPrepare.Focus();
            }
        }
        private void btnPrepare_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPrepare_Click(sender, e);
            }
        }
        private void txtNewInterest_KeyPress(object sender, KeyPressEventArgs e)
            {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                sumOfCollectedAmount();
                txtNewCommission.Focus();
            }
        }

        private void txtNewCommission_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                sumOfCollectedAmount();
                txtNewIPOCharge.Focus();
            }
        }

        private void txtNewIPOCharge_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                sumOfCollectedAmount();
                txtNewBOOpeningCharge.Focus();
            }
        }

        private void txtNewBOOpeningCharge_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                sumOfCollectedAmount();
                txtNewBOCloseCharge.Focus();
            }
        }

        private void txtNewBOCloseCharge_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                sumOfCollectedAmount();
                txtNewTaxCharge.Focus();
            }
        }

        private void txtNewTaxCharge_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                sumOfCollectedAmount();
                txtNewTransmissionCharge.Focus();
            }
        }

        private void txtNewTransmissionCharge_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                sumOfCollectedAmount();
                txtNewDemetCharge.Focus();
            }
        }

        private void txtNewDemetCharge_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                sumOfCollectedAmount();
                txtNewCustodian.Focus();
            }
        }

        private void txtNewCustodian_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                sumOfCollectedAmount();
                txtNewBankInterest.Focus();
            }
        }

        private void txtNewBankInterest_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                sumOfCollectedAmount();
                txtNewTaxCertBank.Focus();
            }
        }
        private void txtNewTaxCertBank_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                sumOfCollectedAmount();
                txtNewTrnsBank.Focus();
            }
        }
        private void txtNewTrnsBank_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                sumOfCollectedAmount();
                txtNewDemetBank.Focus();
            }
        }

        private void txtNewDemetBank_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                sumOfCollectedAmount();
                txtNewCustodianBank.Focus();
            }
        }

        private void txtNewCustodianBank_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                sumOfCollectedAmount();
                txtVoucherNo.Focus();
            }
        }
        private void txtVoucherNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                sumOfCollectedAmount();
                btnWithdraw.Focus();
            }
        }

        double NewInterest = 0;
        private void txtNewInterest_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(txtNewInterest.Text.Trim(), out doubleTryParse))
            {
                NewInterest = doubleTryParse;
                sumOfCollectedAmount();
            }
            else if (!double.TryParse(txtNewInterest.Text.Trim(), out doubleTryParse) && txtNewInterest.Text == string.Empty)
            {
                sumOfCollectedAmount();
            }
            else if (!double.TryParse(txtNewInterest.Text.Trim(), out doubleTryParse) && txtNewInterest.Text != string.Empty)
            {
                sumOfCollectedAmount();
                MessageBox.Show("Write Correct Formate...");
            }

            if (NewInterest > Convert.ToDouble(txtExInterest.Text == "" ? 0 : Convert.ToDouble(txtExInterest.Text)))
            {
                MessageBox.Show("Please, Rewrite..." + "\r\n" + "It Exceeds The Existing Balance...", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewInterest.Text = "";
                txtNewInterest.Focus();
            }
        }

        double NewCommission = 0;
        private void txtNewCommission_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(txtNewCommission.Text.Trim(), out doubleTryParse))
            {
                NewCommission = doubleTryParse;
                sumOfCollectedAmount();
            }
            else if (!double.TryParse(txtNewCommission.Text.Trim(), out doubleTryParse) && txtNewCommission.Text == string.Empty)
            {
                sumOfCollectedAmount();
            }
            else if (!double.TryParse(txtNewCommission.Text.Trim(), out doubleTryParse) && txtNewCommission.Text != string.Empty)
            {
                sumOfCollectedAmount();
                MessageBox.Show("Write Correct Formate...");
            }
            if (NewCommission > Convert.ToDouble(txtExCommission.Text == "" ? 0 : Convert.ToDouble(txtExCommission.Text)))
            {
                MessageBox.Show("Please, Rewrite..." + "\r\n" + "It Exceeds The Existing Balance...", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewCommission.Text = "";
                txtNewCommission.Focus();
            }
        }

        double NewIPOCharge = 0;
        private void txtNewIPOCharge_TextChanged(object sender, EventArgs e)
        {

            if (double.TryParse(txtNewIPOCharge.Text.Trim(), out doubleTryParse))
            {
                NewIPOCharge = doubleTryParse;
                sumOfCollectedAmount();
            }
            else if (!double.TryParse(txtNewIPOCharge.Text.Trim(), out doubleTryParse) && txtNewIPOCharge.Text == string.Empty)
            {
                sumOfCollectedAmount();
            }
            else if (!double.TryParse(txtNewIPOCharge.Text.Trim(), out doubleTryParse) && txtNewIPOCharge.Text != string.Empty)
            {
                sumOfCollectedAmount();
                MessageBox.Show("Write Correct Formate...");
            }
            if (NewIPOCharge > Convert.ToDouble(txtExIPOCharge.Text == "" ? 0 : Convert.ToDouble(txtExIPOCharge.Text)))
            {
                MessageBox.Show("Please, Rewrite..." + "\r\n" + "It Exceeds The Existing Balance...", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewIPOCharge.Text = "";
                txtNewIPOCharge.Focus();
            }
        }

        double NewBOOpeningCharge = 0;
        private void txtNewBOOpeningCharge_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(txtNewBOOpeningCharge.Text.Trim(), out doubleTryParse))
            {
                NewBOOpeningCharge = doubleTryParse;
                sumOfCollectedAmount();
            }
            else if (!double.TryParse(txtNewBOOpeningCharge.Text.Trim(), out doubleTryParse) && txtNewBOOpeningCharge.Text == string.Empty)
            {
                sumOfCollectedAmount();
            }
            else if (!double.TryParse(txtNewBOOpeningCharge.Text.Trim(), out doubleTryParse) && txtNewBOOpeningCharge.Text != string.Empty)
            {
                sumOfCollectedAmount();
                MessageBox.Show("Write Correct Formate...");
            }
            if (NewBOOpeningCharge > Convert.ToDouble(txtExBOOpeningCharge.Text == "" ? 0 : Convert.ToDouble(txtExBOOpeningCharge.Text)))
            {
                MessageBox.Show("Please, Rewrite..." + "\r\n" + "It Exceeds The Existing Balance...", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewBOOpeningCharge.Text = "";
                txtNewBOOpeningCharge.Focus();
            }
        }

        double NewBOCloseCharge = 0;
        private void txtNewBOCloseCharge_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(txtNewBOCloseCharge.Text.Trim(), out doubleTryParse))
            {
                NewBOCloseCharge = doubleTryParse;
                sumOfCollectedAmount();
            }
            else if (!double.TryParse(txtNewBOCloseCharge.Text.Trim(), out doubleTryParse) && txtNewBOCloseCharge.Text == string.Empty)
            {
                sumOfCollectedAmount();
            }
            else if (!double.TryParse(txtNewBOCloseCharge.Text.Trim(), out doubleTryParse) && txtNewBOCloseCharge.Text != string.Empty)
            {
                sumOfCollectedAmount();
                MessageBox.Show("Write Correct Formate...");
            }

            if (NewBOCloseCharge > Convert.ToDouble(txtExBOCloseCharge.Text == "" ? 0 : Convert.ToDouble(txtExBOCloseCharge.Text)))
            {
                MessageBox.Show("Please, Rewrite..." + "\r\n" + "It Exceeds The Existing Balance...", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewBOCloseCharge.Text = "";
                txtNewBOCloseCharge.Focus();
            }
        }

        double NewTaxCharge = 0;
        private void txtNewTaxCharge_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(txtNewTaxCharge.Text.Trim(), out doubleTryParse))
            {
                NewTaxCharge = doubleTryParse;
                sumOfCollectedAmount();
            }
            else if (!double.TryParse(txtNewTaxCharge.Text.Trim(), out doubleTryParse) && txtNewTaxCharge.Text == string.Empty)
            {
                sumOfCollectedAmount();
            }
            else if (!double.TryParse(txtNewTaxCharge.Text.Trim(), out doubleTryParse) && txtNewTaxCharge.Text != string.Empty)
            {
                sumOfCollectedAmount();
                MessageBox.Show("Write Correct Formate...");
            }

            if (NewTaxCharge > Convert.ToDouble(txtExTaxCharge.Text == "" ? 0 : Convert.ToDouble(txtExTaxCharge.Text)))
            {
                MessageBox.Show("Please, Rewrite..." + "\r\n" + "It Exceeds The Existing Balance...", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewTaxCharge.Text = "";
                txtNewTaxCharge.Focus();
            }
        }

        double NewTransmissionCharge = 0;
        private void txtNewTransmissionCharge_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(txtNewTransmissionCharge.Text.Trim(), out doubleTryParse))
            {
                NewTransmissionCharge = doubleTryParse;
                sumOfCollectedAmount();
            }
            else if (!double.TryParse(txtNewTransmissionCharge.Text.Trim(), out doubleTryParse) && txtNewTransmissionCharge.Text == string.Empty)
            {
                sumOfCollectedAmount();
            }
            else if (!double.TryParse(txtNewTransmissionCharge.Text.Trim(), out doubleTryParse) && txtNewTransmissionCharge.Text != string.Empty)
            {
                sumOfCollectedAmount();
                MessageBox.Show("Write Correct Formate...");
            }

            if (NewTransmissionCharge > Convert.ToDouble(txtExTransmissionCharge.Text == "" ? 0 : Convert.ToDouble(txtExTransmissionCharge.Text)))
            {
                MessageBox.Show("Please, Rewrite..." + "\r\n" + "It Exceeds The Existing Balance...", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewTransmissionCharge.Text = "";
                txtNewTransmissionCharge.Focus();
            }
        }

        double NewDemetCharge = 0;
        private void txtNewDemetCharge_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(txtNewDemetCharge.Text.Trim(), out doubleTryParse))
            {
                NewDemetCharge = doubleTryParse;
                sumOfCollectedAmount();
            }
            else if (!double.TryParse(txtNewDemetCharge.Text.Trim(), out doubleTryParse) && txtNewDemetCharge.Text == string.Empty)
            {
                sumOfCollectedAmount();
            }
            else if (!double.TryParse(txtNewDemetCharge.Text.Trim(), out doubleTryParse) && txtNewDemetCharge.Text != string.Empty)
            {
                sumOfCollectedAmount();
                MessageBox.Show("Write Correct Formate...");
            }

            if (NewDemetCharge > Convert.ToDouble(txtExDemetCharge.Text == "" ? 0 : Convert.ToDouble(txtExDemetCharge.Text)))
            {
                MessageBox.Show("Please, Rewrite..." + "\r\n" + "It Exceeds The Existing Balance...", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewDemetCharge.Text = "";
                txtNewDemetCharge.Focus();
            }
        }

        double NewCustodian = 0;
        private void txtNewCustodian_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(txtNewCustodian.Text.Trim(), out doubleTryParse))
            {
                NewCustodian = doubleTryParse;
                sumOfCollectedAmount();
            }
            else if (!double.TryParse(txtNewCustodian.Text.Trim(), out doubleTryParse) && txtNewCustodian.Text == string.Empty)
            {
                sumOfCollectedAmount();
            }
            else if (!double.TryParse(txtNewCustodian.Text.Trim(), out doubleTryParse) && txtNewCustodian.Text != string.Empty)
            {
                sumOfCollectedAmount();
                MessageBox.Show("Write Correct Formate...");
            }

            if (NewCustodian > Convert.ToDouble(txtExCustodian.Text == "" ? 0 : Convert.ToDouble(txtExCustodian.Text)))
            {
                MessageBox.Show("Please, Rewrite..." + "\r\n" + "It Exceeds The Existing Balance...", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewCustodian.Text = "";
                txtNewCustodian.Focus();
            }
        }

        double NewBankInterest = 0;
        private void txtNewBankInterest_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(txtNewBankInterest.Text.Trim(), out doubleTryParse))
            {
                NewBankInterest = doubleTryParse;
                sumOfCollectedAmount();
            }
            else if (!double.TryParse(txtNewBankInterest.Text.Trim(), out doubleTryParse) && txtNewBankInterest.Text == string.Empty)
            {
                sumOfCollectedAmount();
            }
            else if (!double.TryParse(txtNewBankInterest.Text.Trim(), out doubleTryParse) && txtNewBankInterest.Text != string.Empty)
            {
                sumOfCollectedAmount();
                MessageBox.Show("Write Correct Formate...");
            }

            if (NewBankInterest > Convert.ToDouble(txtExBankInterest.Text == "" ? 0 : Convert.ToDouble(txtExBankInterest.Text)))
            {
                MessageBox.Show("Please, Rewrite..." + "\r\n" + "It Exceeds The Existing Balance...", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewBankInterest.Text = "";
                txtNewBankInterest.Focus();
            }
        }

        double NewTaxCarCharg_Bankk = 0;
        private void txtNewTaxCertBank_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(txtNewTaxCertBank.Text.Trim(), out doubleTryParse))
            {
                NewTaxCarCharg_Bankk = doubleTryParse;
                sumOfCollectedAmount();
            }
            else if (!double.TryParse(txtNewTaxCertBank.Text.Trim(), out doubleTryParse) && txtNewTaxCertBank.Text == string.Empty)
            {
                sumOfCollectedAmount();
            }
            else if (!double.TryParse(txtNewTaxCertBank.Text.Trim(), out doubleTryParse) && txtNewTaxCertBank.Text != string.Empty)
            {
                sumOfCollectedAmount();
                MessageBox.Show("Write Correct Formate...");
            }

            if (NewTaxCarCharg_Bankk > Convert.ToDouble(txtNewTaxCertBank.Text == "" ? 0 : Convert.ToDouble(txtNewTaxCertBank.Text)))
            {
                MessageBox.Show("Please, Rewrite..." + "\r\n" + "It Exceeds The Existing Balance...", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewTaxCertBank.Text = "";
                txtNewTaxCertBank.Focus();
            }
        }

        double NewTrnsCharge_Bankk = 0;
        private void txtNewTrnsBank_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(txtNewTrnsBank.Text.Trim(), out doubleTryParse))
            {
                NewTrnsCharge_Bankk = doubleTryParse;
                sumOfCollectedAmount();
            }
            else if (!double.TryParse(txtNewTrnsBank.Text.Trim(), out doubleTryParse) && txtNewTrnsBank.Text == string.Empty)
            {
                sumOfCollectedAmount();
            }
            else if (!double.TryParse(txtNewTrnsBank.Text.Trim(), out doubleTryParse) && txtNewTrnsBank.Text != string.Empty)
            {
                sumOfCollectedAmount();
                MessageBox.Show("Write Correct Formate...");
            }

            if (NewTrnsCharge_Bankk > Convert.ToDouble(txtNewTrnsBank.Text == "" ? 0 : Convert.ToDouble(txtNewTrnsBank.Text)))
            {
                MessageBox.Show("Please, Rewrite..." + "\r\n" + "It Exceeds The Existing Balance...", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewTrnsBank.Text = "";
                txtNewTrnsBank.Focus();
            }
        }

        double NewDemetCharge_Bankk = 0;
        private void txtNewDemetBank_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(txtNewDemetBank.Text.Trim(), out doubleTryParse))
            {
                NewDemetCharge_Bankk = doubleTryParse;
                sumOfCollectedAmount();
            }
            else if (!double.TryParse(txtNewDemetBank.Text.Trim(), out doubleTryParse) && txtNewDemetBank.Text == string.Empty)
            {
                sumOfCollectedAmount();
            }
            else if (!double.TryParse(txtNewDemetBank.Text.Trim(), out doubleTryParse) && txtNewDemetBank.Text != string.Empty)
            {
                sumOfCollectedAmount();
                MessageBox.Show("Write Correct Formate...");
            }

            if (NewDemetCharge_Bankk > Convert.ToDouble(txtNewDemetBank.Text == "" ? 0 : Convert.ToDouble(txtNewDemetBank.Text)))
            {
                MessageBox.Show("Please, Rewrite..." + "\r\n" + "It Exceeds The Existing Balance...", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewDemetBank.Text = "";
                txtNewDemetBank.Focus();
            }
        }

        double NewCustodianCharge_Bankk = 0;
        private void txtNewCustodianBank_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(txtNewCustodianBank.Text.Trim(), out doubleTryParse))
            {
                NewCustodianCharge_Bankk = doubleTryParse;
                sumOfCollectedAmount();
            }
            else if (!double.TryParse(txtNewCustodianBank.Text.Trim(), out doubleTryParse) && txtNewCustodianBank.Text == string.Empty)
            {
                sumOfCollectedAmount();
            }
            else if (!double.TryParse(txtNewCustodianBank.Text.Trim(), out doubleTryParse) && txtNewCustodianBank.Text != string.Empty)
            {
                sumOfCollectedAmount();
                MessageBox.Show("Write Correct Formate...");
            }

            if (NewCustodianCharge_Bankk > Convert.ToDouble(txtNewCustodianBank.Text == "" ? 0 : Convert.ToDouble(txtNewCustodianBank.Text)))
            {
                MessageBox.Show("Please, Rewrite..." + "\r\n" + "It Exceeds The Existing Balance...", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewCustodianBank.Text = "";
                txtNewCustodianBank.Focus();
            }
        }

        private void txtCollectedAmount_TextChanged(object sender, EventArgs e)
        {
            double WithdrawalTk = 0;
            if (!string.IsNullOrEmpty(txtWithdrawalAmount.Text.Trim()))
                WithdrawalTk = Convert.ToDouble(txtWithdrawalAmount.Text.Trim());

            double collectedTk = 0;
            if (!string.IsNullOrEmpty(txtCollectedAmount.Text.Trim()))
                collectedTk = Convert.ToDouble(txtCollectedAmount.Text.Trim());

            if (collectedTk > WithdrawalTk)
            {
                MessageBox.Show("Impossible transaction because Collected Amount is grater than Withdrawal amount...");
            }
        }
        private bool saveValidation()
        {
            double WithdrawalTk = 0;
            if (!string.IsNullOrEmpty(txtWithdrawalAmount.Text.Trim()))
                WithdrawalTk = Convert.ToDouble(txtWithdrawalAmount.Text.Trim());

            double collectedTk = 0;
            if (!string.IsNullOrEmpty(txtCollectedAmount.Text.Trim()))
                collectedTk = Convert.ToDouble(txtCollectedAmount.Text.Trim());

            DataTable dtVoucher = BAL.VoucherDuplicacyCheck(txtVoucherNo.Text.Trim(), Convert.ToDateTime(DateTime.Now.ToString("yyyy/MMM/dd")));

            if (txtVoucherNo.Text == string.Empty)
            {
                MessageBox.Show("Please, Write Voucher No....", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtVoucherNo.Focus();
                return true;
            }
            else if (dtVoucher.Rows.Count > 0)
            {
                MessageBox.Show("Pleace, Check Voucher No....", "Alert!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtVoucherNo.Focus();
                return true;
            }

            else if (collectedTk < WithdrawalTk)
            {
                MessageBox.Show("Increase Collected Money For Transaction...");
                return true;
            }
            else if (collectedTk > WithdrawalTk)
            {
                MessageBox.Show("Collected Amount Exceeds The Withdrawal Amount...");
                return true;
            }
            else return false;
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        
        {
            if (saveValidation())
                return;

            string trnType = string.Empty;
            string trnTypeID = string.Empty;
            if (cbCash.Checked)
            {
                trnType = "Cash";
                trnTypeID = "1";
            }
            else
            {
                trnType = "Cheque";
                trnTypeID = "2";
            }


            if (MessageBox.Show("Want to continue withdrawal process?", "Confirmation..", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    string VoucherNo = txtVoucherNo.Text.Trim();

                    BAL.ConnectDatabase();
                    BAL.StartTransaction();

                    if (NewInterest > 0) BAL.saveInterestWithdraw_SBP_Payment(NewInterest);
                    if (NewCommission > 0) BAL.saveCommission_SBP_Transactions(NewCommission, VoucherNo);
                    if (NewIPOCharge > 0) BAL.saveIPOTotaCharge_SBP_IPO_Application_BasicInfo(NewIPOCharge, VoucherNo, trnType, trnTypeID);
                    if (NewBOOpeningCharge > 0) BAL.saveBOOpeningCharge_SBP_Payment_OOC(NewBOOpeningCharge, VoucherNo);
                    if (NewBOCloseCharge > 0) BAL.saveBOClosingCharge_SBP_Payment_OOC(NewBOCloseCharge, VoucherNo);
                    if (NewTaxCharge > 0) BAL.saveTaxCertificateCharge_SBP_Payment_OOC(NewTaxCharge, VoucherNo);
                    if (NewTransmissionCharge > 0) BAL.saveTransmissionCharge_SBP_Payment_OOC(NewTransmissionCharge, VoucherNo);
                    if (NewDemetCharge > 0) BAL.saveDemetCharge_SBP_Payment_OOC(NewDemetCharge, VoucherNo);
                    if (NewCustodian > 0) BAL.saveCustodianCharge_SBP_Payment_OOC(NewCustodian, VoucherNo);
                    if (NewBankInterest > 0) BAL.saveBankInterestCharge_SBP_Payment_OOC(NewBankInterest, VoucherNo);
                    if (NewTaxCarCharg_Bankk > 0) BAL.SaveTaxCerCharge_Bank(NewTaxCarCharg_Bankk, VoucherNo, trnType);

                    BAL.SaveWithdrawHistory(InitiallizeBO());

                    BAL.CommitTransaction();
                    MessageBox.Show("Withdrawal Process Successfully Completed...");
                    frm_HeadWiseWithdraw_Load(sender, e);
                }
                catch (Exception ex)
                {
                    BAL.RollBackTransaction();
                    throw ex;
                }
                finally
                {
                    BAL.CloseDatabase();
                }
            }
            else
            {
                //
            }
        }
        private HeadWiseWithdrawalBO InitiallizeBO()
        {
            HeadWiseWithdrawalBO HBO = new HeadWiseWithdrawalBO();

            HBO.VoucherNo = txtVoucherNo.Text.Trim();
            HBO.WithdrawDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MMM/dd"));
            HBO.Interest = NewInterest;
            HBO.Commission = NewCommission;
            HBO.IPOCharge = NewIPOCharge;
            HBO.BOOpeningCharge = NewBOOpeningCharge;
            HBO.BOCloseCharge = NewBOCloseCharge;
            HBO.TaxCharge = NewTaxCharge;
            HBO.TransmissionCharge = NewTransmissionCharge;
            HBO.DemetCharge = NewDemetCharge;
            HBO.Custodian = NewCustodian;
            HBO.BankInteres = NewBankInterest;
            HBO.TaxChargeBank = NewTaxCarCharg_Bankk;
            HBO.TransmissionChargeBank = NewTrnsCharge_Bankk;
            HBO.DemetChargeBank = NewDemetCharge_Bankk;
            HBO.CustodianChargeBank = NewCustodianCharge_Bankk;

            if (cbCash.Checked)
            {
                HBO.PaymentMedia = cbCash.Text;
            }
            else
            {
                HBO.PaymentMedia = cbCheque.Text;
            }

            HBO.WBankName = PopUpBO._BankName;
            HBO.WChequeNo = PopUpBO._ChequeNo;

            if (HBO.PaymentMedia == "Cash")
            {
                HBO.WPayDate = "null";                
            }
            else
            { 
                HBO.WPayDate ="'" +PopUpBO._Paydate.ToShortDateString()+"'";
            }

            HBO.UserName = GlobalVariableBO._userName;
            HBO.EntryDate = DateTime.Now;
            return HBO;
        }

        private void btnCancelProcess_Click(object sender, EventArgs e)
        {
            frm_HeadWiseWithdraw_Load(sender, e);
        }

        private void cbCash_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCash.Checked == true)
            {
                ep.Clear();
                cbCheque.Checked = false;
                PopUpBO._BankName = string.Empty;
                PopUpBO._ChequeNo = string.Empty;
                PopUpBO._Paydate = DateTime.MinValue;
            }
        }

        private void cbCheque_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCheque.Checked == true)
            {
                cbCash.Checked = false;
                ep.Clear();
                FrmPopUpWithBankInformation frm = new FrmPopUpWithBankInformation();
                frm.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //CONVERT(VARCHAR(10),GETDATE(),110)
            DateTime Serverdate;
            DateTime ConvertedDate;
            Serverdate = GlobalVariableBO._currentServerDate;
            ConvertedDate = Convert.ToDateTime(GlobalVariableBO._currentServerDate.ToString("yyyy-MM-dd"));


            BAL.Test_Commission(33, ConvertedDate);
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            Frm_DashBoard_ForIncomeHead frm = new Frm_DashBoard_ForIncomeHead();
            frm.ShowDialog();
        }   
    }
}
