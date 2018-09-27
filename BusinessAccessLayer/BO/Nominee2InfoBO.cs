using System;

namespace BusinessAccessLayer.BO
{
    public class Nominee2InfoBO
    {
        private string _nominee2Name;
        private string _nominee2Address;
        private string _nominee2City;
        private string _nominee2PostCode;
        private string _nominee2Division;
        private string _nominee2Country;
        private string _nominee2Telephone;
        private string _nominee2Mobile;
        private string _nominee2Fax;
        private string _nominee2Email;
        private string _nominee2Relation;
        private float _nominee2Percentage;
        private string _nominee2PassportNo;
        private string _nominee2IssuePlace;
        private DateTime? _nominee2IssueDate;
        private DateTime? _nominee2ExpireDate;
        private string _nominee2Residency;
        private string _nominee2Nationality;
        private string _nominee2NationalID;
        private DateTime? _nominee2DOB;
        
        public Nominee2InfoBO()
        {
            _nominee2Name = "";
            _nominee2Address = "";
            _nominee2City = "";
            _nominee2PostCode = "";
            _nominee2Division = "";
            _nominee2Country = "";
            _nominee2Telephone = "";
            _nominee2Mobile = "";
            _nominee2Fax = "";
            _nominee2Email = "";
            _nominee2Relation = "";
            _nominee2Percentage = 0;
            _nominee2PassportNo = "";
            _nominee2IssuePlace = "";
            _nominee2IssueDate = null;
            _nominee2ExpireDate = null;
            _nominee2Residency = "";
            _nominee2Nationality = "";
            _nominee2DOB = null;
            _nominee2NationalID = "";

        }

        public string Nominee2Name
        {
            get { return _nominee2Name; }
            set { _nominee2Name = value; }
        }

        public string Nominee2Address
        {
            get { return _nominee2Address; }
            set { _nominee2Address = value; }
        }

        public string Nominee2City
        {
            get { return _nominee2City; }
            set { _nominee2City = value; }
        }

        public string Nominee2PostCode
        {
            get { return _nominee2PostCode; }
            set { _nominee2PostCode = value; }
        }

        public string Nominee2Division
        {
            get { return _nominee2Division; }
            set { _nominee2Division = value; }
        }

        public string Nominee2Country
        {
            get { return _nominee2Country; }
            set { _nominee2Country = value; }
        }

        public string Nominee2Telephone
        {
            get { return _nominee2Telephone; }
            set { _nominee2Telephone = value; }
        }

        public string Nominee2Mobile
        {
            get { return _nominee2Mobile; }
            set { _nominee2Mobile = value; }
        }

        public string Nominee2Fax
        {
            get { return _nominee2Fax; }
            set { _nominee2Fax = value; }
        }

        public string Nominee2Email
        {
            get { return _nominee2Email; }
            set { _nominee2Email = value; }
        }

        public string Nominee2Relation
        {
            get { return _nominee2Relation; }
            set { _nominee2Relation = value; }
        }

        public float Nominee2Percentage
        {
            get { return _nominee2Percentage; }
            set { _nominee2Percentage = value; }
        }

        public string Nominee2PassportNo
        {
            get { return _nominee2PassportNo; }
            set { _nominee2PassportNo = value; }
        }

        public string Nominee2IssuePlace
        {
            get { return _nominee2IssuePlace; }
            set { _nominee2IssuePlace = value; }
        }

        public DateTime? Nominee2IssueDate
        {
            get { return _nominee2IssueDate; }
            set { _nominee2IssueDate = value; }
        }

        public DateTime? Nominee2ExpireDate
        {
            get { return _nominee2ExpireDate; }
            set { _nominee2ExpireDate = value; }
        }

        public string Nominee2Residency
        {
            get { return _nominee2Residency; }
            set { _nominee2Residency = value; }
        }

        public string Nominee2Nationality
        {
            get { return _nominee2Nationality; }
            set { _nominee2Nationality = value; }
        }

        public DateTime? Nominee2Dob
        {
            get { return _nominee2DOB; }
            set { _nominee2DOB = value; }
        }

        public string Nominee2NationalId
        {
            get { return _nominee2NationalID; }
            set { _nominee2NationalID = value; }
        }
    }
}
