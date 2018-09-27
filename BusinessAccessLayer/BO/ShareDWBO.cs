using System;

namespace BusinessAccessLayer.BO
{
    public class ShareDWBO
    {
        private long _shareDWId;
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
        private float _FracValue;
       
        public ShareDWBO()
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
            _FracValue = 0;
        }
      
        public long ShareDwId
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
        public float FracValue
        {
            get { return _FracValue; }
            set { _FracValue = value; }
        }
    }
    #region
    public class ShareDWBO_Collection : System.Collections.CollectionBase
    {
        public ShareDWBO_Collection()
        {
            base.InnerList.Clear();
        }
        public virtual void ADD(ShareDWBO Item)
        {
            base.InnerList.Add(Item);
        }
        public virtual ShareDWBO this[int index]
        {
            get
            {
                return (ShareDWBO)(base.InnerList[index]);
            }
            set
            {
                base.InnerList[index] = value;
            }
        }
    }
    #endregion
}
