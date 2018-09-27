using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessAccessLayer.BO
{
    public class IncomeEntryBO
    {
        private int _ReceiptNo;
        private string _VoucherSLNo;
        private DateTime _RcvDate;
        private string _RcvFrom;
        private int _ClientCode;
        private string _Dr_Cr;
        private double _Dr_Amount;
        private double _Cr_Amount;
        private string _Purpose;
        private string _TrnType;
        private string _AccHead;
        private string _AccSubHead;
        private string _RoutingNo;
        private string _BankName;
        private string _BankBranchName;
        private string _DistrictName;
        private string _ChequeNo;
        private DateTime _PayDate;
        private string _Status;
        private int _BrokerBranchID;
        private DateTime _EntryDate;
        private string _EntryBy;
        private DateTime _UpdateDate;
        private string _UpdateBy;

        private int? _SessionID;
        private string _SessionName;
        private int? _BasicInfoID;

        public IncomeEntryBO()
        {
            _ReceiptNo = 0;
            _VoucherSLNo = string.Empty;
            _RcvDate = DateTime.MinValue;
            _RcvFrom = string.Empty;
            _ClientCode = 0;
            _Dr_Cr = string.Empty;
            _Dr_Amount = 0.00;
            _Cr_Amount = 0.00;
            _Purpose = string.Empty;
            _TrnType = string.Empty;
            _AccHead = string.Empty;
            _AccSubHead = string.Empty;
            _RoutingNo = string.Empty;
            _BankName = string.Empty;
            _BankBranchName = string.Empty;
            _DistrictName = string.Empty;
            _ChequeNo = string.Empty;
            _PayDate = DateTime.MinValue;
            _Status = string.Empty;
            _BrokerBranchID = 0;
            _EntryDate = DateTime.MinValue;
            _EntryBy = string.Empty;
            _UpdateDate = DateTime.MinValue;
            _UpdateBy = string.Empty;


            _SessionID = null;
            _SessionName = string.Empty;
            _BasicInfoID = null;
        }

        public int ReceiptNo
        {
            get { return _ReceiptNo; }
            set { _ReceiptNo = value; }
        }
        public string VoucherSLNo
        {
            get { return _VoucherSLNo; }
            set { _VoucherSLNo = value; }
        }

        public DateTime RcvDate
        {
            get { return _RcvDate; }
            set { _RcvDate = value; }
        }

        public string RcvFrom
        {
            get { return _RcvFrom; }
            set { _RcvFrom = value; }
        }

        public int ClientCode
        {
            get { return _ClientCode; }
            set { _ClientCode = value; }
        }

        public string Dr_Cr
        {
            get { return _Dr_Cr; }
            set { _Dr_Cr = value; }
        }

        public double Dr_Amount
        {
            get { return _Dr_Amount; }
            set { _Dr_Amount = value; }
        }

        public double Cr_Amount
        {
            get { return _Cr_Amount; }
            set { _Cr_Amount = value; }
        }

        public string Purpose
        {
            get { return _Purpose; }
            set { _Purpose = value; }
        }

        public string TrnType
        {
            get { return _TrnType; }
            set { _TrnType = value; }
        }

        public string AccHead
        {
            get { return _AccHead; }
            set { _AccHead = value; }
        }

        public string AccSubHead
        {
            get { return _AccSubHead; }
            set { _AccSubHead = value; }
        }

        public string RoutingNo
        {
            get { return _RoutingNo; }
            set { _RoutingNo = value; }
        }

        public string BankName
        {
            get { return _BankName; }
            set { _BankName = value; }
        }

        public string BankBranchName
        {
            get { return _BankBranchName; }
            set { _BankBranchName = value; }
        }

        public string DistrictName
        {
            get { return _DistrictName; }
            set { _DistrictName = value; }
        }

        public string ChequeNo
        {
            get { return _ChequeNo; }
            set { _ChequeNo = value; }
        }

        public DateTime PayDate
        {
            get { return _PayDate; }
            set { _PayDate = value; }
        }

        public string Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        public int BrokerBranchID
        {
            get { return _BrokerBranchID; }
            set { _BrokerBranchID = value; }
        }

        public DateTime EntryDate
        {
            get { return _EntryDate; }
            set { _EntryDate = value; }
        }

        public string EntryBy
        {
            get { return _EntryBy; }
            set { _EntryBy = value; }
        }

        public DateTime UpdateDate
        {
            get { return _UpdateDate; }
            set { _UpdateDate = value; }
        }

        public string UpdateBy
        {
            get { return _UpdateBy; }
            set { _UpdateBy = value; }
        }

        //_SessionID = 0;
        //    _SessionName
        //_BasicInfoID

        public int? SessionID
        {
            get { return _SessionID; }
            set { _SessionID = value; }
        }
        public string SessionName
        {
            get { return _SessionName; }
            set { _SessionName = value; }
        }
        public int? BasicInfoID
        {
            get { return _BasicInfoID; }
            set { _BasicInfoID = value; }
        }
    }
}
