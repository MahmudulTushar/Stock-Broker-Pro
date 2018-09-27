using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessAccessLayer.BO
{
   public class Taken_HolidayBO
   {
       private string _employeeCode;
       public String EmployeeCode
       {
           get { return _employeeCode; }
           set { _employeeCode = value; }
       }

       private string _holidayType;
       public String HolidayType
       {
           get { return _holidayType; }
           set { _holidayType = value; }
       }

       private DateTime _startDate;
       public DateTime StartDate
       {
           get { return _startDate; }
           set { _startDate = value; }
       }

       private int _holiday;
       public int Holiday
       {
           get { return _holiday; }
           set { _holiday = value; }
       }

       private string _remarks;
       public String Remarks
       {
           get { return _remarks; }
           set { _remarks = value; }
       }

       private string _reason;
       public String Reason
       {
           get { return _reason; }
           set { _reason = value; }
       }
   }
}
