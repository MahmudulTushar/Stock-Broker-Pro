using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BusinessAccessLayer.BO
{
   public class EmployeePersonalInfoBO
    {
        private string _employeeCode;
        public String EmployeeCode
        {
            get { return _employeeCode; }
            set { _employeeCode = value; }
        }

        private string _employeeName;
        public String EmployeeName
        {
            get { return _employeeName; }
            set { _employeeName = value; }
        }

       private string _fatherName;
       public String FatherName
       {
           get { return _fatherName; }
           set { _fatherName = value; }
       }

       private string _MotherName;
       public String MotherName
       {
           get { return _MotherName; }
           set { _MotherName = value; }
       }

        private string _address;
        public String Address
        {

            get { return _address; }
            set { _address = value; }
        }

        private string _gender;
        public String Gender
        {

            get { return _gender; }
            set { _gender = value; }
        }

        private DateTime _dob;
        public DateTime DOB
        {
            get { return _dob; }
            set { _dob = value; }
        }

        private string _fillingStatus;
        public String FillingStatus
        {
            get { return _fillingStatus; }
            set { _fillingStatus = value; }
        }

        private string _bloodGroup;
        public String BloodGroup
        {
            get { return _bloodGroup; }
            set { _bloodGroup = value; }
        }

        private string _nationality;
        public String Nationality
        {
            get { return _nationality; }
            set { _nationality = value; }
        }

        private string _nationalID;
        public String NationalID
        {
            get { return _nationalID; }
            set { _nationalID = value; }
        }

        private string _ContactNumber;
        public String ContactNumber
        {
            get { return _ContactNumber; }
            set { _ContactNumber = value; }
        }

        private string _homePhone;
        public String HomePhone
        {
            get { return _homePhone; }
            set { _homePhone = value; }
        }

        private string _emailAddress;
        public String EmailAddress
        {
            get { return _emailAddress; }
            set { _emailAddress = value; }
        }

       private string _PassportNo;
       public String PassportNo
       {
           get { return _PassportNo; }
           set { _PassportNo = value; }
       }

       private string _alternativePhoneNumber;
       public String AlternativePhoneNumber
       {
           get { return _alternativePhoneNumber; }
           set { _alternativePhoneNumber = value; }
       }

       private string _referenceName;
       public String ReferenceName
       {
           get { return _referenceName; }
           set { _referenceName = value; }
       }

       private string _referenceProfession;
       public String ReferenceProfession
       {
           get { return _referenceProfession; }
           set { _referenceProfession = value; }
       }

       private string _referencePhoneNumber;
       public String ReferencePhoneNumber
       {
           get { return _referencePhoneNumber; }
           set { _referencePhoneNumber = value; }
       }

       private string _referenceEmailAddress;
       public String ReferenceEmailAddress
       {
           get { return _referenceEmailAddress; }
           set { _referenceEmailAddress = value; }
       }

       private string _referenceAddress;
       public String ReferenceAddress
       {
           get { return _referenceAddress; }
           set { _referenceAddress = value; }
       }

       private string _employeeTitle;
       public String EmployeeTitle
       {
           get { return _employeeTitle; }
           set { _employeeTitle = value; }
       }

    }
}
