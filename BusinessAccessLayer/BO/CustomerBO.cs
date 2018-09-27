using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessAccessLayer.BO
{
    public class CustomerBO
    {
        private string _customerCode;
        private string _customerName;
        private string _fatherName;
        private string _motherName;
        private string _sex;
        private string _phone;
        private string _nationality;
        private string _boId;
        private int _acType;
        private int _boCategory;
        private DateTime _birthDate;
        private string _occupation;
        private string _residence;
        private string _address1;
        private string _address2;
        private string _address3;
        private string _city;
        private string _district;
        private string _country;
        private string _postalCode;
        private string _email;
        private string _fax;
        private int _statementCycle;
        private string _passportNo;
        private string _passportIssuePlace;
        private DateTime? _passportIssueDate;
        private DateTime? _passportExpiryDate;
        private int _bankId;
        private int _branchId;
        private string _bankName;
        private string _branchName;
        private string _accountNo;
        private int _edc;
        private string _tin;
        private string _sWIFT_Code;
        private string _iBAN;
        private int _taxExemption;
        private string _secoundHolder;
        private string _routing_No;
        private DateTime? _bO_Open_Date;

        private string _firstHolder_NID;
        private string _secondHolder_NID;
        private string _thirdHolder_NID;


        public DateTime? BO_Open_Date
        {
            get { return _bO_Open_Date; }
            set { _bO_Open_Date = value; }
        }

        public string SecoundHolder
        {
            get { return _secoundHolder; }
            set { _secoundHolder = value; }
        }



        public CustomerBO()
        {
            _customerCode = "";
            _customerName = "";
            _fatherName = "";
            _sex = "";
            _address1 = "";
            _phone = "";
            _nationality = "";
            _boId = "";
            _acType = 0;
            _statementCycle = 0;
            _boCategory = 0;
            _taxExemption = 0;
            _edc = 0;
            _passportIssueDate = null;
            _passportExpiryDate = null;
            _secoundHolder = "";
            _routing_No = string.Empty;
            _sWIFT_Code = string.Empty;
            _iBAN = string.Empty;
            _bankId = 0;
            _branchId = 0;


            _firstHolder_NID = string.Empty;
            _secondHolder_NID = string.Empty;
            _thirdHolder_NID = string.Empty;
        }

        public string CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }

        public string CustomerName
        {
            get { return _customerName; }
            set { _customerName = value; }
        }

        public string FatherName
        {
            get { return _fatherName; }
            set { _fatherName = value; }
        }
        public string Sex
        {
            get { return _sex; }
            set { _sex = value; }
        }
        public string Address1
        {
            get { return _address1; }
            set { _address1 = value; }
        }
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }
        public string Nationality
        {
            get { return _nationality; }
            set { _nationality = value; }
        }
        public string BoId
        {
            get { return _boId; }
            set { _boId = value; }
        }
        public int BoTypeID
        {
            get { return _acType; }
            set { _acType = value; }
        }

        public string MotherName
        {
            get { return _motherName; }
            set { _motherName = value; }
        }

        public int BoCategoryID
        {
            get { return _boCategory; }
            set { _boCategory = value; }
        }

        public DateTime BirthDate
        {
            get { return _birthDate; }
            set { _birthDate = value; }
        }

        public string Occupation
        {
            get { return _occupation; }
            set { _occupation = value; }
        }

        public string Residence
        {
            get { return _residence; }
            set { _residence = value; }
        }

        public string Address2
        {
            get { return _address2; }
            set { _address2 = value; }
        }

        public string Address3
        {
            get { return _address3; }
            set { _address3 = value; }
        }

        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        public string District
        {
            get { return _district; }
            set { _district = value; }
        }

        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }

        public string PostalCode
        {
            get { return _postalCode; }
            set { _postalCode = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string Fax
        {
            get { return _fax; }
            set { _fax = value; }
        }

        public int StatementCycleID
        {
            get { return _statementCycle; }
            set { _statementCycle = value; }
        }

        public string PassportNo
        {
            get { return _passportNo; }
            set { _passportNo = value; }
        }

        public string PassportIssuePlace
        {
            get { return _passportIssuePlace; }
            set { _passportIssuePlace = value; }
        }

        public DateTime? PassportIssueDate
        {
            get { return _passportIssueDate; }
            set { _passportIssueDate = value; }
        }

        public DateTime? PassportExpiryDate
        {
            get { return _passportExpiryDate; }
            set { _passportExpiryDate = value; }
        }

        public string BankName
        {
            get { return _bankName; }
            set { _bankName = value; }
        }

        public string BranchName
        {
            get { return _branchName; }
            set { _branchName = value; }
        }

        public string AccountNo
        {
            get { return _accountNo; }
            set { _accountNo = value; }
        }

        public int Edc
        {
            get { return _edc; }
            set { _edc = value; }
        }

        public string Tin
        {
            get { return _tin; }
            set { _tin = value; }
        }

        public int TaxExemption
        {
            get { return _taxExemption; }
            set { _taxExemption = value; }
        }

        public string Routing_No
        {
            get { return _routing_No; }
            set { _routing_No = value; }
        }

        public string IBAN
        {
            get { return _iBAN; }
            set { _iBAN = value; }
        }

        public string SWIFT_Code
        {
            get { return _sWIFT_Code; }
            set { _sWIFT_Code = value; }
        }

        public int BranchId
        {
            get { return _branchId; }
            set { _branchId = value; }
        }

        public int BankId
        {
            get { return _bankId; }
            set { _bankId = value; }
        }

        public string firstHolder_NID
        {
            get { return _firstHolder_NID; }
            set { _firstHolder_NID = value; }
        }

        public string secondHolder_NID
        {
            get { return _secondHolder_NID; }
            set { _secondHolder_NID = value; }
        }

        public string thirdHolder_NID
        {
            get { return _thirdHolder_NID; }
            set { _thirdHolder_NID = value; }
        }
    }


    #region "Collection of Customer"
    public class CustomerCollectionBO : System.Collections.CollectionBase
    {

        public CustomerCollectionBO()
        {
            base.InnerList.Clear();
        }

        public virtual void Add(CustomerBO oItem)
        {
            base.InnerList.Add(oItem);
        }

        public virtual CustomerBO this[int index]
        {
            get
            {
                return (CustomerBO)(base.InnerList[index]);
            }
            set
            {

                base.InnerList[index] = value;
            }
        }

    }

    #endregion

    #region "Collection of Modified Customer"
    public class ModifiedCustomersQueryBO : System.Collections.CollectionBase
    {

        public ModifiedCustomersQueryBO()
        {
            base.InnerList.Clear();
        }

        public virtual void Add(string item)
        {
            base.InnerList.Add(item);
        }

        public virtual string this[int index]
        {
            get
            {
                return (string)(base.InnerList[index]);
            }
            set
            {

                base.InnerList[index] = value;
            }
        }

    }

    #endregion
}
