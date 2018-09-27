using System;

namespace BusinessAccessLayer.BO
{
    public class CustomerCloseInfoBO
    {
        private string _custCode;
        private double _closingBalance;
        private double _closingCharge;
        private string _voucherNo;
        private DateTime _closingDate;
        public CustomerCloseInfoBO()
        {
            _custCode = "";
            _closingBalance = 0;
            _closingCharge = 0;
            _voucherNo = "";

        }

        public string CustCode
        {
            get { return _custCode; }
            set { _custCode = value; }
        }

        public double ClosingBalance
        {
            get { return _closingBalance; }
            set { _closingBalance = value; }
        }

        public double ClosingCharge
        {
            get { return _closingCharge; }
            set { _closingCharge = value; }
        }

        public string VoucherNo
        {
            get { return _voucherNo; }
            set { _voucherNo = value; }
        }

        public DateTime ClosingDate
        {
            get { return _closingDate; }
            set { _closingDate = value; }
        }

        public string PaymentMedia
        {
            get { return _paymentMedia; }
            set { _paymentMedia = value; }
        }

        private string _paymentMedia;
    }
}
