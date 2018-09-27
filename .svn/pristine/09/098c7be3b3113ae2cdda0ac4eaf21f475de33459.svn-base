using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using BusinessAccessLayer.Constants;
 

namespace StockbrokerProNewArch
{
    public partial class frm_IPOTransactionChargeTaken : Form
    {
        decimal Total_Balance = 0.0M;
        decimal Total_Approved_Pending_Balance = 0.0M;
        decimal Withdraw_Pending_Balance = 0.0M;
        decimal Deposit_Pending_Balance = 0.0M;
        string Deposit_Transaction_Name = "";
        string Withdraw_Transaction_Name = "";
        private string[] Deposit = {"Cash","TRIPO","TRTA"};
        private string[] ChargType_Check = { Indication_TransactioBasedCharge.BankClearing };
        private string[] ChargType_NonCheck = { Indication_TransactioBasedCharge.BankClearing,Indication_TransactioBasedCharge.IPOApp };

        private double _amountToDeposit;

        public double AmountToDeposit
        {
            get { return _amountToDeposit; }
            set { _amountToDeposit = value; }
        }

        private string _chargeType;

        public string ChargeType
        {
            get { return _chargeType; }
            set { _chargeType = value; }
        }

        private bool _isChargeTaken;

        public bool IsChargeTaken
        {
            get { return _isChargeTaken; }
            set { _isChargeTaken = value; }
        }

       private string _chargeName;

        public string ChargeName
        {
            get { return _chargeName; }
            set { _chargeName = value; }
        }

        private string _transferCode;

        public string TransferCode
        {
            get { return _transferCode; }
            set { _transferCode = value; }
        }
        private string _chargedCustCode;

        public string ChargedCustCode
        {
            get { return _chargedCustCode; }
            set { _chargedCustCode = value; }
        }
        private double _amount;

        public double Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }
        private string _voucherNo;

        public string VoucherNo
        {
            get { return _voucherNo; }
            set { _voucherNo = value; }
        }
        private string _remarks;

        public string Remarks
        {
            get { return _remarks; }
            set { _remarks = value; }
        }
        private DateTime _receivedDate;

        public DateTime ReceivedDate
        {
            get { return _receivedDate; }
            set { _receivedDate = value; }
        }

        private string _transReason;

        public string TransReason
        {
            get { return _transReason; }
            set { _transReason = value; }
        }

        private string _referenceNo;

        public string ReferenceNo
        {
            get { return _referenceNo; }
            set { _referenceNo = value; }
        }

        private string _media;
        public string Payment_Media
        {
            get { return _media; }
            set { _media = value; }
        }

        private int _mediaID;

        public int Payment_MediaID
        {
            get { return _mediaID; }
            set { _mediaID = value; }
        }



        
        public frm_IPOTransactionChargeTaken()
        {
            InitializeComponent();
        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {
            try
            {
                _chargedCustCode =txt_ChargedCode_ForCheque.Text ;
                _amount = Convert.ToDouble(txt_Amount.Text);
                _voucherNo = txt_VoucherNo.Text;
                _remarks = txt_Remarks.Text;
                _receivedDate = dtp_Received_Date.Value.Date;               
                _media = cmbPaymentMediaForCharge.Text;
                _mediaID = Convert.ToInt32(cmbPaymentMediaForCharge.SelectedValue);
                _transferCode = txt_TransferFromCode.Text;
                _isChargeTaken = true;
                _chargeType = cmb_ChargeType.Text;
                try
                {                    
                   CheckParnetChild();
                   this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frm_IPOTransactionChargeTaken_Load(object sender, EventArgs e)
        {
            LoadDepositCombo();
            LoadChargeType(_chargeType);
            txt_TransferFromCode.Text = _transferCode;
            txt_ChargedCode_ForCheque.Text = _chargedCustCode;
            txt_Amount.Text = Convert.ToString(_amount);
            txt_VoucherNo.Text = _voucherNo;
            txt_Remarks.Text = _remarks;
            dtp_Received_Date.Value = _receivedDate.Date;           
            cmb_ChargeType.SelectedItem = _chargeType;
            cmbPaymentMediaForCharge.SelectedValue=1 ;            
        }

        public void LoadChargeType(string P_ChargeType)
        {
            if (P_ChargeType != Indication_TransactioBasedCharge.BankClearing)
                cmb_ChargeType.Items.Add(Indication_TransactioBasedCharge.IPOApp);
            else
            {
                cmb_ChargeType.Items.Add(Indication_TransactioBasedCharge.IPOApp);
                cmb_ChargeType.Items.Add(Indication_TransactioBasedCharge.BankClearing);
            }
        }

        public void LoadDepositCombo()
        {           
            DataTable dt = new DataTable();
            DataTable MappedDt = new DataTable();
            IPOProcessBAL ipoBal = new IPOProcessBAL();
            dt = ipoBal.GetIPOMoneyTransType();
            MappedDt = dt.Clone();
            foreach (DataRow dr in dt.Rows)
                if (Deposit.Contains(dr["Name"].ToString()))
                    MappedDt.Rows.Add(dr.ItemArray);


            cmbPaymentMediaForCharge.DataSource = MappedDt.Rows.Cast<DataRow>()
                .Select(t => new { Key = Convert.ToInt32(t["ID"]), Value = Convert.ToString(t["Name"]) })
                .OrderBy(t => t.Value).ToList();
            cmbPaymentMediaForCharge.ValueMember = "Key";
            cmbPaymentMediaForCharge.DisplayMember = "Value";

        }

        
        private void txt_ChargeCustCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CheckParnetChild();
                Set_TransferCode_Balance();                
            }
        }

        private void Set_TransferCode_Balance()
        {
            if (cmbPaymentMediaForCharge.Text == Indication_IPOPaymentTransaction.TRIPO)
            {
                IPOApprovalBAL bal = new IPOApprovalBAL();
                txt_Balance.Text =Convert.ToString( bal.GetIPOCustomerBalance(txt_TransferFromCode.Text));
            }
            else if (cmbPaymentMediaForCharge.Text == Indication_IPOPaymentTransaction.TRTA)
            {
                PaymentInfoBAL bal = new PaymentInfoBAL();
                txt_Balance.Text = Convert.ToString(bal.GetCurrentBalane(txt_TransferFromCode.Text));
            }
            
        }

        private void cmbPaymentMediaForCharge_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPaymentMediaForCharge.Text == "TRTA" || cmbPaymentMediaForCharge.Text == "TRIPO")
            {
                txt_TransferFromCode.Enabled = true;                
            }
            else
            {
                txt_TransferFromCode.Enabled = false;                
            }
        }

        private void CheckParnetChild()
        {
            //Validation();
            if (cmbPaymentMediaForCharge.Text == Indication_IPOPaymentTransaction.TRTA || cmbPaymentMediaForCharge.Text == Indication_IPOPaymentTransaction.TRIPO)
            {
                if (_chargedCustCode != _transferCode)
                {
                    IPOProcessBAL Bal = new IPOProcessBAL();
                    string Going_Parent = "";
                    string Given_Parent = "";
                    string[] Cust_Code_Parent_Child = new string[] { txt_TransferFromCode.Text };
                    string[] Charge_taken_Cust_Code = _chargedCustCode.Split(',').ToArray();
                    DataTable dtCheck_Parent_Child_From_Charge_Going = Bal.GetParentCodeFromChildCode(Charge_taken_Cust_Code);
                    DataTable dt_Check_Parent_Child_Charge_Given = Bal.GetParentCodeFromChildCode(Cust_Code_Parent_Child);

                    if (dtCheck_Parent_Child_From_Charge_Going.Rows.Count > 0)
                        Going_Parent = dtCheck_Parent_Child_From_Charge_Going.Rows[0][0].ToString();
                    else
                        throw new Exception("Invalid Parent child Grouping=" + _chargedCustCode);
                    if (dt_Check_Parent_Child_Charge_Given.Rows.Count > 0)
                        Given_Parent = dt_Check_Parent_Child_Charge_Given.Rows[0][0].ToString();
                    else
                        throw new Exception("Invalid Parent Child Grouping=" + string.Join(",", Cust_Code_Parent_Child));

                    
                    if (Going_Parent != Given_Parent)
                    {
                        throw new Exception("Invalid Parent Child"); 
                    }
                    else
                    {                        
                        EntryBlanceChecking(string.Join(",", Cust_Code_Parent_Child), Convert.ToDecimal(_amount));
                    }
                    
                }
            }
             
        }

        private void Validation()
        {
            if (cmbPaymentMediaForCharge.Text == string.Empty)
            {
                throw new Exception("Select Your Payemnt Media First");

            }
            if (txt_Amount.Text == "0" || txt_Amount.Text == string.Empty)
            {
                throw new Exception("provide your Require Charge");

            }
        }
        
        //Added By Md.Rashedul Hasan
        /// <summary>
        /// Withdraw Balance Checking For withdraw Transaction
        /// </summary>
        /// <param name="cust_code"></param>
        /// <param name="Distributed_Amount"></param>
        private void EntryBlanceChecking(string cust_code, decimal Distributed_Amount)
        {
            IPOProcessBAL ACBal = new IPOProcessBAL();
            string[] Total_withdraw_transaction_Name = null;
            string[] Total_Deposit_transaction_Name = null;
            string[] Total_Withdraw_Pending = null;
            string[] Total_Deposit_Pending = null;
            string[] Previous_Balance = null;
            string[] Present_Approve_Pending_Balance = null;
            DataTable dt = new DataTable();
            dt = ACBal.GetIPOAccountInformation(cust_code);
            if (dt.Rows.Count > 0)
            {
                Total_Balance = 0.0M;
                Total_Approved_Pending_Balance = 0.0M;
                Withdraw_Pending_Balance = 0.0M;
                Deposit_Pending_Balance = 0.0M;

                Previous_Balance = dt.Rows.OfType<DataRow>().Select(c => Convert.ToString(c["Presenct_Balance"])).ToArray(); ;
                Total_withdraw_transaction_Name = dt.Rows.OfType<DataRow>().Select(c => Convert.ToString(c["Withdraw_Pending_Transaction_Name"])).ToArray();
                Total_Deposit_transaction_Name = dt.Rows.Cast<DataRow>().Select(c => Convert.ToString(c["Deposit_Pending_Transaction_Name"])).ToArray();
                //Deposit_Transaction_Name = dt.Rows[0]["Deposit_Pending_Transaction_Name"].ToString();
                //Withdraw_Transaction_Name = dt.Rows[0]["Withdraw_Pending_Transaction_Name"].ToString();
                Withdraw_Transaction_Name = string.Join(",", Total_withdraw_transaction_Name);
                Deposit_Transaction_Name = string.Join(",", Total_Deposit_transaction_Name);

                Present_Approve_Pending_Balance = dt.Rows.Cast<DataRow>().Select(c => Convert.ToString(c["ApprovePendingBalance"])).ToArray();
                Total_Withdraw_Pending = dt.Rows.OfType<DataRow>().Select(c => Convert.ToString(c["Withdraw_Pending"])).ToArray();
                Total_Deposit_Pending = dt.Rows.OfType<DataRow>().Select(c => Convert.ToString(c["Deposit_Pending"])).ToArray();

                for (int i = 0; i < Previous_Balance.Length; i++)
                {
                    decimal Hold = 0.0M;
                    if (Previous_Balance[i] != "")
                    {
                        Hold = Convert.ToDecimal(Previous_Balance[i]);
                        Total_Balance = Hold;
                    }
                }
                for (int i = 0; i < Present_Approve_Pending_Balance.Length; i++)
                {
                    decimal P_Hold = 0.0M;
                    if (Present_Approve_Pending_Balance[i] != "")
                    {
                        P_Hold = Convert.ToDecimal(Present_Approve_Pending_Balance[i]);
                        Total_Approved_Pending_Balance = P_Hold;
                    }
                }
                for (int i = 0; i < Total_Withdraw_Pending.Length; i++)
                {
                    decimal W_con = 0.0M;
                    string W_Pending = Total_Withdraw_Pending[i];
                    if (W_Pending == "")
                    {
                        W_Pending = "0";
                        W_con = W_con + Convert.ToDecimal(W_Pending);
                    }
                    else
                    {
                        W_con = W_con + Convert.ToDecimal(W_Pending);
                    }
                    Withdraw_Pending_Balance = Withdraw_Pending_Balance + W_con;
                }
                for (int i = 0; i < Total_Deposit_Pending.Length; i++)
                {
                    decimal D_con = 0.0M;
                    //Convert.ToDecimal(D_Pending);

                    string D_Pending = Total_Deposit_Pending[i];
                    if (D_Pending == "")
                    {
                        D_Pending = "0";
                        D_con = D_con + Convert.ToDecimal(D_Pending);
                    }
                    else
                    {
                        D_con = D_con + Convert.ToDecimal(D_Pending);
                    }
                    Deposit_Pending_Balance = Deposit_Pending_Balance + D_con;
                }
                //Convert.ToDecimal(dt.Rows[0]["Withdraw_Pending"]);
                if ((Total_Balance - Withdraw_Pending_Balance) < Distributed_Amount)
                {
                    throw new Exception("Your previous Balance =" + Total_Balance + "\n available withdrawal Balance = " + Total_Approved_Pending_Balance + "\n Total Pendding deposit Amount = " + Deposit_Pending_Balance + " Deposit Transaction Pending By: " + Deposit_Transaction_Name + "\n Total Withdraw Balance = " + Withdraw_Pending_Balance + " Withdraw Transaction Pending By: " + Withdraw_Transaction_Name + "\n For This Cust Code= " + cust_code);
                }
            }

        }

        private void txt_Amount_Leave(object sender, EventArgs e)
        {
            try
            {
                Validation();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmb_ChargeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmb_ChargeType.Text==Indication_TransactioBasedCharge.IPOApp)
            {
                IPOProcessBAL bal = new IPOProcessBAL();
                txt_Amount.Text = Convert.ToString(bal.GetIPO_ChargeDef().Rows.Count > 0 ? Convert.ToDouble(bal.GetIPO_ChargeDef().Rows[0]["TotalCharge"]) : 0.00);

            }
            else if (cmb_ChargeType.Text == Indication_TransactioBasedCharge.BankClearing)
            {
                PaymentInfoBAL bal = new PaymentInfoBAL();
                txt_Amount.Text=Convert.ToString(bal.GetTransactionBasedCharges_ChargeAmount(Indication_TransactioBasedCharge.BankClearing, _amountToDeposit));
            }

            
        }

       
    }
}
