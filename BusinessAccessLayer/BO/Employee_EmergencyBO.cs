using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessAccessLayer.BO
{
   public class Employee_EmergencyBO
   {
       private string _employeeCode;
       public String EmployeeCode
       {
           get { return _employeeCode; }
           set { _employeeCode = value; }
       }

       private string _medicalDisability;
       public String MedicalDisability
       {
           get { return _medicalDisability; }
           set { _medicalDisability = value; }
       }

       private string _bloodGroup;
       public String BloodGroup
       {
           get { return _bloodGroup; }
           set { _bloodGroup = value; }
       }

       private string _contactPersonName;
       public String ContactPersonName
       {
           get { return _contactPersonName; }
           set { _contactPersonName = value; }
       }

       private string _relationShip;
       public String RelationShip
       {
           get { return _relationShip; }
           set { _relationShip = value; }
       }

       private string _address;
       public String Adddress
       {
           get { return _address; }
           set { _address = value; }
       }

       private string _contactNumber;
       public String ContactNumber
       {
           get { return _contactNumber; }
           set { _contactNumber = value; }
       }

       private string _medicalInsurance;
       public String MedicalInsurance
       {
           get { return _medicalInsurance; }
           set { _medicalInsurance = value; }
       }

       private string _spedcialInstruction;
       public String SpecialInstruction
       {
           get { return _spedcialInstruction; }
           set { _spedcialInstruction = value; }
       }
   }
}
