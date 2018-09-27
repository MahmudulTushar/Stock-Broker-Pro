using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessAccessLayer.BO
{
    public class AdditionalInfoBO
    {
        private string _custCode;
        private string _firstHolderName;
        private string _purposeCode;
        private string _serialNo;
        private string _additionalHolderName;
        private string _institution;
        private string _institutionName;
        private string _address1;
        private string _address2;
        private string _address3;
        private string _city;
        private string _division;
        private string _country;
        private string _postCode;
        private string _phone;
        private string _email;
        private string _fax;
        private DateTime _effetiveFrom;
        private DateTime _effectiveTo;
        private DateTime _entryDate;
        private string _passportNo;
        private DateTime _passportIssueDate ;
        private DateTime _passportExpireDate;
        private string _passportIssuePlace;
        private string _relationShip;
        private float _percentage;
        private string _nationalID;

        public AdditionalInfoBO()
        {
            _effetiveFrom = DateTime.MinValue;
            _effectiveTo = DateTime.MinValue;
            _entryDate = DateTime.MinValue;
            _passportIssueDate = DateTime.MinValue;
            _passportExpireDate = DateTime.MinValue;
        }

        public string FirstHolderName
        {
            get { return _firstHolderName; }
            set { _firstHolderName = value; }
        }

        public string PurposeCode
        {
            get { return _purposeCode; }
            set { _purposeCode = value; }
        }

        public string SerialNo
        {
            get { return _serialNo; }
            set { _serialNo = value; }
        }

        public string AdditionalHolderName
        {
            get { return _additionalHolderName; }
            set { _additionalHolderName = value; }
        }

        public string Institution
        {
            get { return _institution; }
            set { _institution = value; }
        }

        public string InstitutionName
        {
            get { return _institutionName; }
            set { _institutionName = value; }
        }

        public string Address1
        {
            get { return _address1; }
            set { _address1 = value; }
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

        public string Division
        {
            get { return _division; }
            set { _division = value; }
        }

        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }

        public string PostCode
        {
            get { return _postCode; }
            set { _postCode = value; }
        }

        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
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

        public DateTime EffetiveFrom
        {
            get { return _effetiveFrom; }
            set { _effetiveFrom = value; }
        }

        public DateTime EffectiveTo
        {
            get { return _effectiveTo; }
            set { _effectiveTo = value; }
        }

        public DateTime EntryDate
        {
            get { return _entryDate; }
            set { _entryDate = value; }
        }

        public string PassportNo
        {
            get { return _passportNo; }
            set { _passportNo = value; }
        }

        public DateTime PassportIssueDate
        {
            get { return _passportIssueDate; }
            set { _passportIssueDate = value; }
        }

        public DateTime PassportExpireDate
        {
            get { return _passportExpireDate; }
            set { _passportExpireDate = value; }
        }

        public string PassportIssuePlace
        {
            get { return _passportIssuePlace; }
            set { _passportIssuePlace = value; }
        }

        public string RelationShip
        {
            get { return _relationShip; }
            set { _relationShip = value; }
        }

        public float Percentage
        {
            get { return _percentage; }
            set { _percentage = value; }
        }

        public string CustCode
        {
            get { return _custCode; }
            set { _custCode = value; }
        }

        public string NationalID
        {
            get { return _nationalID; }
            set { _nationalID = value; }
        }

    }
    public class AdditionalInfoCollectionBO : System.Collections.CollectionBase
    {

        public AdditionalInfoCollectionBO()
        {
            base.InnerList.Clear();
        }

        public virtual void Add(AdditionalInfoBO oItem)
        {
            base.InnerList.Add(oItem);
        }

        public virtual AdditionalInfoBO this[int index]
        {
            get
            {
                return (AdditionalInfoBO)(base.InnerList[index]);
            }
            set
            {

                base.InnerList[index] = value;
            }
        }

    }
}
