using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessAccessLayer.BO
{
   
    public class PayinBO
    {
        private DateTime _sattlementDate;
        public DateTime SattlementDate
        {
            get { return _sattlementDate; }
            set { _sattlementDate = value; }
        }

        private string _customerCode;
        public String CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }

        private string _boId;
        public String BOId
        {
            get { return _boId; }
            set { _boId = value; }
        }

        private string _companyISIN;
        public String CompanyISIN
        {
            get { return _companyISIN; }
            set { _companyISIN = value; }
        }

        private string _tradeQnty;
        public String TradeQty
        {
            get { return _tradeQnty; }
            set { _tradeQnty = value; }
        }

        private string _paylog;
        public String Paylog
        {
            get { return _paylog; }
            set { _paylog = value; }
        }

        private string _counterBoid;
        public String CounterBOID
        {
            get { return _counterBoid; }
            set { _counterBoid = value; }
        }

        private string _custromerCodeFrom;
        public String CustomerCodeFrom
        {
            get { return _custromerCodeFrom; }
            set { _custromerCodeFrom = value; }
        }

        private float _previousQuantity;

        public float PreviousQuantity
        {
            get { return _previousQuantity; }
            set { _previousQuantity = value; }
        }
        
    }
}
