using System;

namespace BusinessAccessLayer.BO
{
    public class Guardian1InfoBO
    {
        private string _guardian1Name;
        private string _guardian1Address;
        private string _guardian1City;
        private string _guardian1PostCode;
        private string _guardian1Division;
        private string _guardian1Country;
        private string _guardian1Telephone;
        private string _guardian1Mobile;
        private string _guardian1Fax;
        private string _guardian1Email;
        private string _guardian1Relation;
        private DateTime _guardian1DOBofMinor;
        private DateTime _guardian1MaturityDateMinor;
        private string _guardian1PassportNo;
        private string _guardian1IssuePlace;
        private DateTime _guardian1IssueDate;
        private DateTime _guardian1ExpireDate;
        private string _guardian1Residency;
        private string _guardian1Nationality;
        private DateTime _guardian1DOB;
        
        public Guardian1InfoBO()
        {
            _guardian1Name = "";
            _guardian1Address = "";
            _guardian1City = "";
            _guardian1PostCode = "";
            _guardian1Division = "";
            _guardian1Country = "";
            _guardian1Telephone = "";
            _guardian1Mobile = "";
            _guardian1Fax = "";
            _guardian1Email = "";
            _guardian1Relation = "";
            //_guardian1DOBofMinor = "";
            //_guardian1MaturityDateMinor = "";
            _guardian1PassportNo = "";
            _guardian1IssuePlace = "";
            //_guardian1IssueDate = "";
            //_guardian1ExpireDate = "";
            _guardian1Residency = "";
            _guardian1Nationality = "";
            //_guardian1DOB = "";
        }

        public string Guardian1Name
        {
            get { return _guardian1Name; }
            set { _guardian1Name = value; }
        }

        public string Guardian1Address
        {
            get { return _guardian1Address; }
            set { _guardian1Address = value; }
        }

        public string Guardian1City
        {
            get { return _guardian1City; }
            set { _guardian1City = value; }
        }

        public string Guardian1PostCode
        {
            get { return _guardian1PostCode; }
            set { _guardian1PostCode = value; }
        }

        public string Guardian1Division
        {
            get { return _guardian1Division; }
            set { _guardian1Division = value; }
        }

        public string Guardian1Country
        {
            get { return _guardian1Country; }
            set { _guardian1Country = value; }
        }

        public string Guardian1Telephone
        {
            get { return _guardian1Telephone; }
            set { _guardian1Telephone = value; }
        }

        public string Guardian1Mobile
        {
            get { return _guardian1Mobile; }
            set { _guardian1Mobile = value; }
        }

        public string Guardian1Fax
        {
            get { return _guardian1Fax; }
            set { _guardian1Fax = value; }
        }

        public string Guardian1Email
        {
            get { return _guardian1Email; }
            set { _guardian1Email = value; }
        }

        public string Guardian1Relation
        {
            get { return _guardian1Relation; }
            set { _guardian1Relation = value; }
        }

        public DateTime Guardian1DoBofMinor
        {
            get { return _guardian1DOBofMinor; }
            set { _guardian1DOBofMinor = value; }
        }

        public DateTime Guardian1MaturityDateMinor
        {
            get { return _guardian1MaturityDateMinor; }
            set { _guardian1MaturityDateMinor = value; }
        }

        public string Guardian1PassportNo
        {
            get { return _guardian1PassportNo; }
            set { _guardian1PassportNo = value; }
        }

        public string Guardian1IssuePlace
        {
            get { return _guardian1IssuePlace; }
            set { _guardian1IssuePlace = value; }
        }

        public DateTime Guardian1IssueDate
        {
            get { return _guardian1IssueDate; }
            set { _guardian1IssueDate = value; }
        }

        public DateTime Guardian1ExpireDate
        {
            get { return _guardian1ExpireDate; }
            set { _guardian1ExpireDate = value; }
        }

        public string Guardian1Residency
        {
            get { return _guardian1Residency; }
            set { _guardian1Residency = value; }
        }

        public string Guardian1Nationality
        {
            get { return _guardian1Nationality; }
            set { _guardian1Nationality = value; }
        }

        public DateTime Guardian1DOB
        {
            get { return _guardian1DOB; }
            set { _guardian1DOB = value; }
        }
    }
}
