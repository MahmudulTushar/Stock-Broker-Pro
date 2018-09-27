using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessAccessLayer.BAL
{
   public class OPexPurposeBO
    {

       private string _opexPurpose;
       public String OpexPurpose
       {
           get { return _opexPurpose; }
           set { _opexPurpose = value; }
       }

       private string _expenseType;
       public String ExpenseType
       {
           get { return _expenseType; }
           set { _expenseType = value; }
       }
    }
}
