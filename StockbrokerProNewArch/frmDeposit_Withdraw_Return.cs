using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using BusinessAccessLayer.BAL;
using BusinessAccessLayer.BO;
using System.Windows.Forms;
using BusinessAccessLayer.Constants;
namespace StockbrokerProNewArch
{
    public partial class frmdeposit_withdraw_Return : Form
    {
        string _custcode;
        string _paymentID;
        string _paymentmedia;
        string _deposit_withdraw;
        public frmdeposit_withdraw_Return(string CustCode, string Deposit_Withdraw, string PaymentMedia)
        {
            InitializeComponent();
            _custcode = CustCode;
            _paymentmedia = PaymentMedia;
            _deposit_withdraw = Deposit_Withdraw;
        }

        private void frmEFT_Return_Load(object sender, EventArgs e)
        {
            DW_Return_InfoBAL eftReturnInfoBAL = new DW_Return_InfoBAL();
            DataTable data = new DataTable();
            //string _payment_Media_Temp;
            //string[] temp;
            //temp = _paymentmedia.Split('R');
            //_payment_Media_Temp = temp[0]; //_paymentmedia.Substring(0, 3);
            if (_paymentmedia.ToUpper().Trim() == ("EFTReturn").ToUpper().Trim())
            {
                if (_deposit_withdraw.ToUpper().Trim() != ("Deposit").ToUpper().Trim())
                    data = eftReturnInfoBAL.Get_DW_ReturnInformation(_paymentmedia.Replace(Indication_PaymentTransaction.Return_Indicator, ""), _deposit_withdraw, _custcode);
            }
            else
            {
                data = eftReturnInfoBAL.Get_DW_ReturnInformation(_paymentmedia.Replace(Indication_PaymentTransaction.Return_Indicator, ""), _deposit_withdraw, _custcode);
            }
            dgvDWReturnInfo.DataSource = data;
            if (data.Rows.Count > 0)
            {
                dgvDWReturnInfo.Columns[0].Visible = false;
                dgvDWReturnInfo.Columns[11].Visible = false;
                dgvDWReturnInfo.Columns[13].Visible = false;
                dgvDWReturnInfo.Columns[14].Visible = false;
                dgvDWReturnInfo.Columns[16].Visible = false;
                dgvDWReturnInfo.Columns[17].Visible = false;
                dgvDWReturnInfo.Columns[18].Visible = false;
                dgvDWReturnInfo.Columns[19].Visible = false;
                dgvDWReturnInfo.Columns[20].Visible = false;
                dgvDWReturnInfo.Columns[21].Visible = false;
                dgvDWReturnInfo.Columns[22].Visible = false;
                dgvDWReturnInfo.Columns[23].Visible = false;
                dgvDWReturnInfo.Columns[24].Visible = false;
                dgvDWReturnInfo.Columns[25].Visible = false;
            }
            DeselectFirstRow();

        }

        private void DeselectFirstRow()
        {
            //if (dgvDWReturnInfo.RowCount > 0)
            //    dgvDWReturnInfo.Rows[0].Selected = false;
        }
        private void dgvEFTReturnInfo_SelectionChanged(object sender, EventArgs e)
        {
           // EFT_ReturnBO eftReturnBO = new EFT_ReturnBO();
            int RowIndex;
            try
            {
                //if (_paymentmedia == "EFT Return")
                //{
                    RowIndex = dgvDWReturnInfo.CurrentRow.Index;
                    _paymentID = dgvDWReturnInfo["Payment_ID", RowIndex].Value.ToString();
                    Deposit_Withdraw_ReturnBO.Pid = _paymentID;
                    Deposit_Withdraw_ReturnBO.Code = dgvDWReturnInfo["Cust_Code", RowIndex].Value.ToString();
                    Deposit_Withdraw_ReturnBO.Amount = Convert.ToDouble(dgvDWReturnInfo["Amount", RowIndex].Value.ToString());
                    Deposit_Withdraw_ReturnBO.Recdate = Convert.ToDateTime(dgvDWReturnInfo["Received_Date", RowIndex].Value);
                    Deposit_Withdraw_ReturnBO.P_Media = dgvDWReturnInfo["Payment_Media", RowIndex].Value.ToString();
                    Deposit_Withdraw_ReturnBO.P_MediaNo = dgvDWReturnInfo["Payment_Media_No", RowIndex].Value.ToString();
                    Deposit_Withdraw_ReturnBO.P_Mediadate = Convert.ToDateTime(dgvDWReturnInfo["Payment_Media_Date", RowIndex].Value);
                    Deposit_Withdraw_ReturnBO.Bank_ID =dgvDWReturnInfo["Bank_ID", RowIndex].Value.ToString()==""?0:Convert.ToInt32(dgvDWReturnInfo["Bank_ID", RowIndex].Value.ToString());
                    Deposit_Withdraw_ReturnBO.Bank_Name = dgvDWReturnInfo["Bank_Name", RowIndex].Value.ToString();
                    Deposit_Withdraw_ReturnBO.Branch_ID =dgvDWReturnInfo["Branch_ID", RowIndex].Value.ToString()==""?0:Convert.ToInt32( dgvDWReturnInfo["Branch_ID", RowIndex].Value.ToString());
                    Deposit_Withdraw_ReturnBO.Bank_Branch = dgvDWReturnInfo["Bank_Branch", RowIndex].Value.ToString();
                    Deposit_Withdraw_ReturnBO.RoutingNo = dgvDWReturnInfo["RoutingNo", RowIndex].Value.ToString();
                    Deposit_Withdraw_ReturnBO.BankAccNo = dgvDWReturnInfo["BankAccNo", RowIndex].Value.ToString();
                    Deposit_Withdraw_ReturnBO.DW = dgvDWReturnInfo["Deposit_Withdraw", RowIndex].Value.ToString();
                    //  eftReturnBO.Appv_Date = Convert.ToDateTime(dgvEFTReturnInfo[10, e.RowIndex].Value);
                    Deposit_Withdraw_ReturnBO.Voucher = dgvDWReturnInfo["Vouchar_SN", RowIndex].Value.ToString();
                  //  EFT_ReturnBO.TransReason = "Return_" + _paymentID.ToString();
                //}
                //else if (_paymentmedia == "Cheque Return")
                //{
                //    RowIndex = dgvEFTReturnInfo.CurrentRow.Index;
                //    _paymentID = Convert.ToInt32(dgvEFTReturnInfo[0, RowIndex].Value);
                //    Cheque_ReturnBO.Pid = _paymentID;
                //    Cheque_ReturnBO.Code = dgvEFTReturnInfo[1, RowIndex].Value.ToString();
                //    Cheque_ReturnBO.Amount = Convert.ToDouble(dgvEFTReturnInfo[2, RowIndex].Value.ToString());
                //    Cheque_ReturnBO.Recdate = Convert.ToDateTime(dgvEFTReturnInfo[3, RowIndex].Value);
                //    Cheque_ReturnBO.P_Media = dgvEFTReturnInfo[4, RowIndex].Value.ToString();
                //    Cheque_ReturnBO.P_MediaNo = dgvEFTReturnInfo[5, RowIndex].Value.ToString();
                //    Cheque_ReturnBO.Bank_Name = dgvEFTReturnInfo[6, RowIndex].Value.ToString();
                //    Cheque_ReturnBO.Bank_Branch = dgvEFTReturnInfo[7, RowIndex].Value.ToString();
                //    Cheque_ReturnBO.RoutingNo = dgvEFTReturnInfo[8, RowIndex].Value.ToString();
                //    Cheque_ReturnBO.BankAccNo = dgvEFTReturnInfo[9, RowIndex].Value.ToString();
                //    //  eftReturnBO.DW = dgvEFTReturnInfo[9, e.RowIndex].Value.ToString();
                //    //  eftReturnBO.Appv_Date = Convert.ToDateTime(dgvEFTReturnInfo[10, e.RowIndex].Value);
                //    Cheque_ReturnBO.Voucher = dgvEFTReturnInfo[10, RowIndex].Value.ToString();
                //   // Cheque_ReturnBO.TransReason = "Return_" + _paymentID.ToString();
                //}
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        private void ValueForwardingToParent()
        {
            PaymentForm pmtform = (PaymentForm)Application.OpenForms["PaymentForm"];
            pmtform.SetDW_ReturnInformation();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (dgvDWReturnInfo.Rows.Count > 0)
            {
                ValueForwardingToParent();
                this.Close();
            }
        }

        private void frmdeposit_withdraw_Return_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (dgvDWReturnInfo.Rows.Count > 0)
            //    ValueForwardingToParent();
        }

        private void dgvDWReturnInfo_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDWReturnInfo.Rows.Count > 0)
            {
                ValueForwardingToParent();
                this.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
