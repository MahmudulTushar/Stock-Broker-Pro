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
    public partial class frm_Ipo_CheckReturn : Form
    {
        private string[] _codes ;
        private string _deposit_Withdraw;
        private string _payment_Media;
        public frm_Ipo_CheckReturn(string[] cust_codes,string Deposit_Withdraw,string Payment_Media)
        {
            InitializeComponent();
            _codes = cust_codes;
            _deposit_Withdraw = Deposit_Withdraw;
            _payment_Media = Payment_Media;
        }

        

        private void frm_Ipo_CheckReturn_Load(object sender, EventArgs e)
        {
            IPOProcessBAL bal = new IPOProcessBAL();
            dgvCheckReturninfo.DataSource = bal.GetCheckReturnInfo(_codes);
            dgvCheckReturninfo.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvCheckReturninfo.Columns["ID"].Visible = false;
            dgvCheckReturninfo.Columns["Money_TransactionType_ID"].Visible = false;
            dgvCheckReturninfo.Columns["Intended_IPOSession_ID"].Visible = false;
            dgvCheckReturninfo.Columns["Intended_IPOSession_Name"].Visible = false;
            dgvCheckReturninfo.Columns["Approval_Status"].Visible = false;
            dgvCheckReturninfo.Columns["Rejected_Reason"].Visible = false;
            dgvCheckReturninfo.Columns["Entry_Branch_Name"].Visible = false;
            dgvCheckReturninfo.Columns["Bank_ID"].Visible = false;
            dgvCheckReturninfo.Columns["BankName"].Visible = false;
            dgvCheckReturninfo.Columns["Branch_ID"].Visible = false;
            dgvCheckReturninfo.Columns["Branch_Name"].Visible = false;
            dgvCheckReturninfo.Columns["Remarks"].Visible = false;
            dgvCheckReturninfo.Columns["Bank_Acc_No"].Visible = false;
            dgvCheckReturninfo.Columns["Trans_Reason"].Visible = false;
            //dgvCheckReturninfo.Columns["Cheque_Date"].Visible = false;
            
        }

        private void Populate_CheckReturnInfo()
        {
            //int RowIndex;
            try
            {

               
                string[] ID = dgvCheckReturninfo.Rows.Cast<DataGridViewRow>()
                    .Select(T => Convert.ToString(T.Cells["ID"].Value)).Distinct().ToArray();
                 
                    //RowIndex = dgvCheckReturninfo.CurrentRow.Index;
                   DataGridViewRow[] temp = dgvCheckReturninfo.SelectedRows.Cast<DataGridViewRow>().ToArray();
                   foreach (var id in temp)
                   {
                       IPO_Deposit_Withdraw_Return_BO.IPO_Customer_Amount_Obj obj = new IPO_Deposit_Withdraw_Return_BO.IPO_Customer_Amount_Obj();
                       obj.Amount = Convert.ToDouble(id.Cells["IPO_Mone_Bal"].Value);
                       obj.Cust_Code =   Convert.ToString(id.Cells["Cust_Code"].Value);
                       obj.Id = Convert.ToInt32(id.Cells["ID"].Value);
                       IPO_Deposit_Withdraw_Return_BO.CustAmountList.Add(obj);                       
                   }
                    
                
                IPO_Deposit_Withdraw_Return_BO.Branch_ID = Convert.ToInt32(dgvCheckReturninfo.Rows[0].Cells["Branch_ID"].Value);
                IPO_Deposit_Withdraw_Return_BO.Bank_ID = Convert.ToInt32(dgvCheckReturninfo.Rows[0].Cells["Bank_ID"].Value);
                IPO_Deposit_Withdraw_Return_BO.Bank_Branch = Convert.ToString(dgvCheckReturninfo.Rows[0].Cells["Branch_Name"].Value);
                IPO_Deposit_Withdraw_Return_BO.Voucher = Convert.ToString(dgvCheckReturninfo.Rows[0].Cells["Voucher_No"].Value);
                IPO_Deposit_Withdraw_Return_BO.Bank_Name = Convert.ToString(dgvCheckReturninfo.Rows[0].Cells["BankName"].Value);
                IPO_Deposit_Withdraw_Return_BO.BankAccNo = Convert.ToString(dgvCheckReturninfo.Rows[0].Cells["Bank_Acc_No"].Value);
                //IPO_Deposit_Withdraw_Return_BO.Branch_Code = Convert.ToString(dgvCheckReturninfo["Routing_No", RowIndex].Value);
                IPO_Deposit_Withdraw_Return_BO.RoutingNo = Convert.ToString(dgvCheckReturninfo.Rows[0].Cells["Routing_No"].Value);
                IPO_Deposit_Withdraw_Return_BO.P_Media = Convert.ToString(dgvCheckReturninfo.Rows[0].Cells["Deposit_Withdraw"].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ClearBO()
        {
            IPO_Deposit_Withdraw_Return_BO.CustAmountList.Clear();
            IPO_Deposit_Withdraw_Return_BO.Bank_Name = string.Empty;
            
        }
    

        private void ValueForwardingToParent()
        {
            frm_IPOPaymentForm pmtform = (frm_IPOPaymentForm)Application.OpenForms["frm_IPOPaymentForm"];
            pmtform.SetDW_ReturnInformation();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (dgvCheckReturninfo.Rows.Count > 0)
            {
                ClearBO();
                Populate_CheckReturnInfo();
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
            if (dgvCheckReturninfo.Rows.Count > 0)
            {
                ValueForwardingToParent();
                this.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvCheckReturninfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Convert.ToString(dg_IpoApproval.Rows[e.RowIndex].Cells["Customer"].Value);
            if (e.RowIndex > 0 && e.RowIndex <= dgvCheckReturninfo.Rows.Count)
            {
                dgvCheckReturninfo.ClearSelection();
                string Routing = Convert.ToString(dgvCheckReturninfo.Rows[e.RowIndex].Cells["Routing_No"].Value);
                string Checkno = Convert.ToString(dgvCheckReturninfo.Rows[e.RowIndex].Cells["Cheque_No"].Value);
                string VoucherNo = Convert.ToString(dgvCheckReturninfo.Rows[e.RowIndex].Cells["Voucher_No"].Value);
                SelectedSameVoucher(Routing, Checkno, VoucherNo);
            }
        }

        private void SelectedSameVoucher(string routing,string CheckNo, string VoucherNo)
        {
            for (int i = 0; i < dgvCheckReturninfo.Rows.Count; i++)
            {
                if (Convert.ToString(dgvCheckReturninfo.Rows[i].Cells["Voucher_No"].Value) == VoucherNo&&Convert.ToString(dgvCheckReturninfo.Rows[i].Cells["Cheque_No"].Value)==CheckNo
                    && Convert.ToString(dgvCheckReturninfo.Rows[i].Cells["Routing_No"].Value)==routing)
                    dgvCheckReturninfo.Rows[i].Selected = true;
            }
            dgvCheckReturninfo.MultiSelect = true;
        }
    }
}
