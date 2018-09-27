using System;

namespace BusinessAccessLayer.BO
{
    public class ShareDWBO_Conversion
    {
        private int _shareDWId;
        private string _custCode;
        private string _companyShortCode;
        private int _quantity;
        private string _depositWithdraw;
        private DateTime _recordDate;
        private DateTime _received_Date;
        private DateTime _effectiveDate;
        private int _lockedInQuantity;
        private int _availableQuantity;
        private DateTime _lockedin_Expiry_Date;
        private string _voucherNo;
        private int _noScript;
        private string _depositType;
        private string _shareType;
        private float _issuePrice;
        private float _issueAmount;
        private float _cdblCharge;

        private string _BO_ID;
        private string _CustName;
        private int _DB_ShareBalance;
        private float _DB_ShareAfterRatio;
        private float _DB_FracPoint;
        private float _DB_NewShareRate;
        private float _DB_TotalShareValue;
        private float _DB_FractureValue;
        private float _DB_NewInvestment;

        private string _OtherCompanyShortCode;
        private int _OtherShareQty;


        public ShareDWBO_Conversion()
        {
            _shareDWId = 0;
            _custCode = "";
            _companyShortCode = "";
            _quantity = 0;
            _depositWithdraw = "";
            _voucherNo = "";
            _noScript = 0;
            _depositType = "";
            _shareType = "";
            _issuePrice = 0;
            _issueAmount = 0;
            _lockedInQuantity = 0;
            _availableQuantity = 0;

            _BO_ID = string.Empty;
            _CustName = string.Empty;
            _DB_ShareBalance = 0;
            _DB_ShareAfterRatio = 0;
            _DB_FracPoint = 0;
            _DB_NewShareRate = 0;
            _DB_TotalShareValue = 0;
            _DB_FractureValue = 0;
            _DB_NewInvestment = 0;

            _OtherCompanyShortCode = string.Empty;
            _OtherShareQty = 0;
        }

        public int ShareDwId
        {
            get { return _shareDWId; }
            set { _shareDWId = value; }
        }

        public string CustCode
        {
            get { return _custCode; }
            set { _custCode = value; }
        }

        public string CompanyShortCode
        {
            get { return _companyShortCode; }
            set { _companyShortCode = value; }
        }

        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        public string DepositWithdraw
        {
            get { return _depositWithdraw; }
            set { _depositWithdraw = value; }
        }

        public DateTime RecordDate
        {
            get { return _recordDate; }
            set { _recordDate = value; }
        }
        public DateTime Received_Date
        {
            get { return _received_Date; }
            set { _received_Date = value; }
        }

        public int LockedInQuantity
        {
            get { return _lockedInQuantity; }
            set { _lockedInQuantity = value; }
        }

        public int AvailableQuantity
        {
            get { return _availableQuantity; }
            set { _availableQuantity = value; }
        }

        public DateTime Lockedin_Expiry_Date
        {
            get { return _lockedin_Expiry_Date; }
            set { _lockedin_Expiry_Date = value; }
        }
        public string VoucherNo
        {
            get { return _voucherNo; }
            set { _voucherNo = value; }
        }

        public int NoScript
        {
            get { return _noScript; }
            set { _noScript = value; }
        }

        public float IssuePrice
        {
            get { return _issuePrice; }
            set { _issuePrice = value; }
        }

        public float IssueAmount
        {
            get { return _issueAmount; }
            set { _issueAmount = value; }
        }

        public float CDBLCharge
        {
            get { return _cdblCharge; }
            set { _cdblCharge = value; }
        }

        public string DepositType
        {
            get { return _depositType; }
            set { _depositType = value; }
        }

        public string ShareType
        {
            get { return _shareType; }
            set { _shareType = value; }
        }

        public DateTime EffectiveDate
        {
            get { return _effectiveDate; }
            set { _effectiveDate = value; }
        }

        public string BO_ID
        {
            get { return _BO_ID; }
            set { _BO_ID = value; }
        }
        public string CustName
        {
            get { return _CustName; }
            set { _CustName = value; }
        }
        public int DB_ShareBalance
        {
            get { return _DB_ShareBalance; }
            set { _DB_ShareBalance = value; }
        }

        public float DB_ShareAfterRatio
        {
            get { return _DB_ShareAfterRatio; }
            set { _DB_ShareAfterRatio = value; }
        }
        public float DB_FracPoint
        {
            get { return _DB_FracPoint; }
            set { _DB_FracPoint = value; }
        }
        public float DB_NewShareRate
        {
            get { return _DB_NewShareRate; }
            set { _DB_NewShareRate = value; }
        }
        public float DB_TotalShareValue
        {
            get { return _DB_TotalShareValue; }
            set { _DB_TotalShareValue = value; }
        }

        public float DB_FractureValue
        {
            get { return _DB_FractureValue; }
            set { _DB_FractureValue = value; }
        }

        public float DB_NewInvestment
        {
            get { return _DB_NewInvestment; }
            set { _DB_NewInvestment = value; }
        }


        public string OtherCompanyShortCode
        {
            get { return _OtherCompanyShortCode; }
            set { _OtherCompanyShortCode = value; }
        }
        public int OtherShareQty
        {
            get { return _OtherShareQty; }
            set { _OtherShareQty = value; }
        }

    }
    #region
    public class ShareDWBO_Conversion_Collection : System.Collections.CollectionBase
    {
        public ShareDWBO_Conversion_Collection()
        {
            base.InnerList.Clear();
        }
        public virtual void ADD(ShareDWBO_Conversion Item)
        {
            base.InnerList.Add(Item);
        }
        public virtual ShareDWBO_Conversion this[int index]
        {
            get
            {
                return (ShareDWBO_Conversion)(base.InnerList[index]);
            }
            set
            {
                base.InnerList[index] = value;
            }
        }
    }
    #endregion
}
