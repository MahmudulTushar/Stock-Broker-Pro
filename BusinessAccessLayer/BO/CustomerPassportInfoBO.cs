using System;

namespace BusinessAccessLayer.BO
{
    public class CustomerPassportInfoBO
    {
        private string _custCode;
        private string _passportNo;
        private string _issuePlace;
        private DateTime _issueDate;
        private DateTime _expireDate;
        private DateTime _entryDate;
        private string _entryBy;

        public CustomerPassportInfoBO()
        {
            _custCode = "";
            _passportNo = "";
            _issuePlace = "";
            //_issueDate = ;
            //_expireDate = "";
            _entryDate = DateTime.Today;
            _entryBy = "";
        }

        public string CustCode
        {
            get { return _custCode; }
            set { _custCode = value; }
        }

        public string PassportNo
        {
            get { return _passportNo; }
            set { _passportNo = value; }
        }

        public string IssuePlace
        {
            get { return _issuePlace; }
            set { _issuePlace = value; }
        }

        public DateTime IssueDate
        {
            get { return _issueDate; }
            set { _issueDate = value; }
        }

        public DateTime ExpireDate
        {
            get { return _expireDate; }
            set { _expireDate = value; }
        }

        public DateTime EntryDate
        {
            get { return _entryDate; }
            set { _entryDate = value; }
        }

        public string EntryBy
        {
            get { return _entryBy; }
            set { _entryBy = value; }
        }
    }
}
