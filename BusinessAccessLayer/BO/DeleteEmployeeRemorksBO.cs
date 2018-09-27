using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessAccessLayer.BO
{
   public  class DeleteEmployeeRemorksBO
   {

       private string _employeeCode;
       public String EmployeeCode
       {
           get { return _employeeCode; }
           set { _employeeCode = value; }
       }

       private string _remarks;
       public String Remarks
       {
           get { return _remarks; }
           set { _remarks = value; }
       }
   }
}
