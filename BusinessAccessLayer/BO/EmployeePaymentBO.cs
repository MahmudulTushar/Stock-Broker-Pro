using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessAccessLayer.BO
{
   public class EmployeePaymentBO
   {
       private string _employeeCode;
       public String EmployeeCode
       {
           get { return _employeeCode; }
           set { _employeeCode = value; }
       }

       private DateTime _joinDate;
       public DateTime JoinDate
       {
           get { return _joinDate; }
           set { _joinDate = value; }
       }

       private DateTime _DischargeDate;
       public DateTime DischargedDate
       {
           get { return _DischargeDate; }
           set { _DischargeDate = value; }
       }

       private string _departjment;
       public  String Department
       {
           get { return _departjment; }
           set { _departjment = value; }
       }

       private string _jobPosition;
       public String JoinPosition
       {
           get { return _jobPosition; }
           set { _jobPosition = value; }
       }


       private string _jobResponsiblity;
       public String JobResponsibility
       {
           get { return _jobResponsiblity; }
           set { _jobResponsiblity = value; }
       }

       private string _paymenrtBy;
       public String PaymentBy
       {
           get { return _paymenrtBy; }
           set { _paymenrtBy = value; }
       }

       private string _bankName;
       public String BankName
       {
           get { return _bankName; }
           set { _bankName = value; }
       }

       private string _accountNo;
       public String AccountNo
       {
           get { return _accountNo; }
           set { _accountNo = value; }
       }

       private string _bankBranchName;
       public String BankBranchName
       {
           get { return _bankBranchName; }
           set { _bankBranchName = value; }
       }

       private float _basicSalary;
       public float  BasicSalary
       {
           get { return _basicSalary; }
           set { _basicSalary = value; }
       }

       private float _houseRent;
       public float HouseRent
       {
           get { return _houseRent; }
           set { _houseRent = value; }
       }

       private float _medical;
       public float Medical
       {
           get { return _medical; }
           set { _medical = value; }
       }

       private float _mobileBill;
       public float MobileBill
       {
           get { return _mobileBill; }
           set { _mobileBill = value; }

       }

       private float _insurace;
       public float Insurance
       {
           get { return _insurace; }
           set { _insurace = value; }
       }

       private float _allowance;
       public float Allowance
       {
           get { return _allowance; }
           set { _allowance = value; }
       }

       private float _prodfund;
       public float ProFund
       {
           get { return _prodfund; }
           set { _prodfund = value; }
       }

       private float _others;
       public float Others
       {
           get { return _others; }
           set { _others = value; }
       }

       private float _overtime;
       public float OverTime
       {
           get { return _overtime; }
           set { _overtime = value; }
       }

       private string _banchName;
       public  String BanchName
       {
           get { return _banchName; }
           set { _banchName = value; }
       }

       private string _reportTo;
       public String ReportTo
       {
           get { return _reportTo; }
           set { _reportTo = value; }
       }

       private string _recuritBy;
       public String RecuritBy
       {
           get { return _recuritBy; }
           set { _recuritBy = value; }
       }

       private string _tinNumber;
       public String TinNumber
       {
           get { return _tinNumber; }
           set { _tinNumber = value; }
       }


   }
}
