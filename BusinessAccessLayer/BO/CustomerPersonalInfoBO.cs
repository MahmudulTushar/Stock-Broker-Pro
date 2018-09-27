using System;

namespace BusinessAccessLayer.BO
{
    public class CustomerPersonalInfoBO
    {
        //Cust_Code, Account_Holder, Guardian, Relation_ID, 
        //Fathers_Name, Mothers_Name, DOB, Gender, Occupation_ID, 
        //National_ID, Applicant_Type_ID, Entry_Date, Entry_By
        private string _custCode;
        private string _accountHolder;
        private string _fatherName;
        private string _motherName;
        private DateTime _dOB;
        private string _gender;
        private string _occupation;
        private string _nationalID;
        private DateTime _entryDate;
        private string _entryBy;

        public CustomerPersonalInfoBO()
        {
            _custCode = "";
            _accountHolder = "";
            _fatherName = "";
            _motherName = "";
            //_dOB = "";
            _gender = "";
            _occupation ="";
            _nationalID = "";
            _entryDate = DateTime.Today;
            _entryBy = "";
        }

        public string CustCode
        {
            get { return _custCode; }
            set { _custCode = value; }
        }

        public string AccountHolder
        {
            get { return _accountHolder; }
            set { _accountHolder = value; }
        }

        public string FatherName
        {
            get { return _fatherName; }
            set { _fatherName = value; }
        }

        public string MotherName
        {
            get { return _motherName; }
            set { _motherName = value; }
        }

        public DateTime DOB
        {
            get { return _dOB; }
            set { _dOB = value; }
        }

        public string Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        public string Occupation
        {
            get { return _occupation; }
            set { _occupation = value; }
        }

        public string NationalID
        {
            get { return _nationalID; }
            set { _nationalID = value; }
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
