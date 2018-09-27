using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessAccessLayer.BO
{
    
    
    public static class IPO_Deposit_Withdraw_Return_BO
    {
        public struct IPO_Customer_Amount_Obj
        {
            public string Cust_Code;
            public double Amount;
            public int Id;
        };

        private static List<IPO_Customer_Amount_Obj> _custAmountList=new List<IPO_Customer_Amount_Obj>();

        public static List<IPO_Customer_Amount_Obj> CustAmountList
        {
            get { return _custAmountList; }
            set { _custAmountList = value; }
        }

        private static DateTime _recdate;

        public static DateTime Recdate
        {
            get { return IPO_Deposit_Withdraw_Return_BO._recdate; }
            set { IPO_Deposit_Withdraw_Return_BO._recdate = value; }
        }


        private static string _p_Media;

        public static string P_Media
        {
            get { return IPO_Deposit_Withdraw_Return_BO._p_Media; }
            set { IPO_Deposit_Withdraw_Return_BO._p_Media = value; }
        }

       
        private static string _p_MediaNo;

        public static string P_MediaNo
        {
            get { return IPO_Deposit_Withdraw_Return_BO._p_MediaNo; }
            set { IPO_Deposit_Withdraw_Return_BO._p_MediaNo = value; }
        }

        private static DateTime _p_Mediadate;

        public static DateTime P_Mediadate
        {
            get { return IPO_Deposit_Withdraw_Return_BO._p_Mediadate; }
            set { IPO_Deposit_Withdraw_Return_BO._p_Mediadate = value; }
        }
        private static string _bank_Code;

        public static string Bank_Code
        {
            get { return IPO_Deposit_Withdraw_Return_BO._bank_Code; }
            set { IPO_Deposit_Withdraw_Return_BO._bank_Code = value; }
        }
        private static int _bank_ID;

        public static int Bank_ID
        {
            get { return _bank_ID; }
            set { _bank_ID = value; }
        }
        private static string _bank_Name;

        public static string Bank_Name
        {
            get { return IPO_Deposit_Withdraw_Return_BO._bank_Name; }
            set { IPO_Deposit_Withdraw_Return_BO._bank_Name = value; }
        }
        private static int _branch_ID;

        public static int Branch_ID
        {
            get { return _branch_ID; }
            set { _branch_ID = value; }
        }
        private static string _branch_Code;

        public static string Branch_Code
        {
            get { return IPO_Deposit_Withdraw_Return_BO._branch_Code; }
            set { IPO_Deposit_Withdraw_Return_BO._branch_Code = value; }
        }
        private static string _bank_Branch;

        public static string Bank_Branch
        {
            get { return IPO_Deposit_Withdraw_Return_BO._bank_Branch; }
            set { IPO_Deposit_Withdraw_Return_BO._bank_Branch = value; }
        }
        private static string _routingNo;

        public static string RoutingNo
        {
            get { return IPO_Deposit_Withdraw_Return_BO._routingNo; }
            set { IPO_Deposit_Withdraw_Return_BO._routingNo = value; }
        }
        private static string _bankAccNo;

        public static string BankAccNo
        {
            get { return IPO_Deposit_Withdraw_Return_BO._bankAccNo; }
            set { IPO_Deposit_Withdraw_Return_BO._bankAccNo = value; }
        }
        private static string _received_By;

        public static string Received_By
        {
            get { return IPO_Deposit_Withdraw_Return_BO._received_By; }
            set { IPO_Deposit_Withdraw_Return_BO._received_By = value; }
        }
        private static string _dW;

        public static string DW
        {
            get { return IPO_Deposit_Withdraw_Return_BO._dW; }
            set { IPO_Deposit_Withdraw_Return_BO._dW = value; }
        }
        private static string _approved_By;

        public static string Approved_By
        {
            get { return IPO_Deposit_Withdraw_Return_BO._approved_By; }
            set { IPO_Deposit_Withdraw_Return_BO._approved_By = value; }
        }
        private static DateTime _appv_Date;

        public static DateTime Appv_Date
        {
            get { return IPO_Deposit_Withdraw_Return_BO._appv_Date; }
            set { IPO_Deposit_Withdraw_Return_BO._appv_Date = value; }
        }
        private static string _voucher;

        public static string Voucher
        {
            get { return IPO_Deposit_Withdraw_Return_BO._voucher; }
            set { IPO_Deposit_Withdraw_Return_BO._voucher = value; }
        }
        private static string _transReason;

        public static string TransReason
        {
            get { return IPO_Deposit_Withdraw_Return_BO._transReason; }
            set { IPO_Deposit_Withdraw_Return_BO._transReason = value; }
        }

    }
}
