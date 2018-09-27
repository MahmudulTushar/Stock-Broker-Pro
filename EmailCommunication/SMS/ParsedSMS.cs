using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElectronicCommunication.SMS
{
    public enum Database_Action { Add, Delete, Update };
    public struct Database_Details {
            public string TableName;
            public string FieldName;
            public string Value;
            public string Condition;
            public string RowNumber;
            public Database_Action Action;  
            };
    public class ParsedSMS
    {
        public ParsedSMS()
        {
            _databaseDetais = new List<Database_Details>();
        }
        private string _FromMobileNo;
        private string _CompanyShortName;
        private string[]  _Cust_Code;
        private string _PaymentType;
        private string _RefundType;
        private string _SMSText;
        private string _SMSDateTime;
        private string _SMSReceiveDateTime;
        private string _ServiceName;
        private List<Database_Details> _databaseDetais;


        public string SMSReceiveDateTime
        {
            get { return _SMSReceiveDateTime; }
            set { _SMSReceiveDateTime = value; }
        }
        public string RefundType
        {
            get { return _RefundType; }
            set { _RefundType = value; }
        }
        public string PaymentType
        {
            get { return _PaymentType; }
            set { _PaymentType = value; }
        }
        public string[] Cust_Code
        {
            get { return _Cust_Code; }
            set { _Cust_Code = value; }
        }
        public string CompanyShortName
        {
            get { return _CompanyShortName; }
            set { _CompanyShortName = value; }
        }
        public List<Database_Details> DatabaseDetais
        {
            get { return _databaseDetais; }
            set { _databaseDetais = value; }
        }      

        public string FromMobileNo
        {
            get { return _FromMobileNo; }
            set { _FromMobileNo = value; }
        }
        public string SMSText
        {
            get { return _SMSText; }
            set { _SMSText = value; }
        }
        public string SMSDateTime
        {
            get { return _SMSDateTime; }
            set { _SMSDateTime = value; }
        }
        public string ServiceName
        {
            get { return _ServiceName; }
            set { _ServiceName = value; }
        }
       
    }
}
