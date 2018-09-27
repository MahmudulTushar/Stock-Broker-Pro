using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessAccessLayer.BO
{
    public class SMSConfEdit
    {
        private string _smsId;
        private string _customer;
        private string _buySell;
        private string _instrument;
        private decimal _tradeQty;
        private decimal _tradePrice;
        private string _mobileNo;

        public string Customer
        {
            get { return _customer; }
            set { _customer = value; }
        }

        public string BuySell
        {
            get { return _buySell; }
            set { _buySell = value; }
        }

        public string Instrument
        {
            get { return _instrument; }
            set { _instrument = value; }
        }

        public decimal TradeQty
        {
            get { return _tradeQty; }
            set { _tradeQty = value; }
        }

        public decimal TradePrice
        {
            get { return _tradePrice; }
            set { _tradePrice = value; }
        }

        public string MobileNo
        {
            get { return _mobileNo; }
            set { _mobileNo = value; }
        }

        public string SmsId
        {
            get { return _smsId; }
            set { _smsId = value; }
        }
    }
}
