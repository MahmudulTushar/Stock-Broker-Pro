using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessAccessLayer.BO
{
   public class EmployeeDoucmentBO
   {

       private string _employeeCode;
       public String EmployeeCode
       {
           get { return _employeeCode; }
           set { _employeeCode = value; }
       }

       private byte[] _Image;
       public Byte[] Image
       {
           get { return _Image; }
           set { _Image = value; }
       }

       private byte[] _doucment;
       public Byte[] Doucment
       {
           get { return _doucment; }
           set { _doucment = value; }
       }

   }
}
