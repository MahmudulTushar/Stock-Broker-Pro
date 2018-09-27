using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessAccessLayer.BO
{
   public class Employee_HolidayBO
   {
       private string _employeeCode;
       public String EmployeeCode
       {
           get { return _employeeCode; }
           set { _employeeCode = value; }
       }

       private int _yearlyHoliday;
       public int YearlyHoliday
       {
           get { return _yearlyHoliday; }
           set { _yearlyHoliday = value; }
       }

       private int _yearlyHolidayTaken;
       public int YearlyHolidayTaken
       {
           get { return _yearlyHolidayTaken; }
           set { _yearlyHolidayTaken = value; }
       }

       private int _sickLeave;
       public int SickLeave
       {
           get { return _sickLeave; }
           set { _sickLeave = value; }
       }

       private int _sickLeaveTaken;
       public int SickLeaveTaken
       {
           get { return _sickLeaveTaken; }
           set { _sickLeaveTaken = value; }
       }

       private int _maternityPolicy;
       public int MaternityPolicy
       {
           get { return _maternityPolicy; }
           set { _maternityPolicy = value; }
       }

       private string _remarks;
       public String Remarks
       {
           get { return _remarks; }
           set { _remarks = value; }
       }

       private int _paternityPolicy;
       public int PaternityPolicy
       {
           get { return _paternityPolicy; }
           set { _paternityPolicy = value; }
       }

   }
}
