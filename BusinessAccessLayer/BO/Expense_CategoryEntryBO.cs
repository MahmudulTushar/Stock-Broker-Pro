using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessAccessLayer.BO
{
    public class Expense_CategoryEntryBO
    {
        private string _category_Name;
        private int _category_Type_ID;
        private string _sub_Category;
        
        public Expense_CategoryEntryBO()
        {
            _category_Name = string.Empty;
            _category_Type_ID = 0;
            _sub_Category = string.Empty;
        }

        public string Category_Name
        {
            get { return _category_Name; }
            set { _category_Name = value; }
        }

        public int Category_Type_ID
        {
            get { return _category_Type_ID; }
            set { _category_Type_ID = value; }
        }

        public string Sub_Category
        {
            get { return _sub_Category; }
            set { _sub_Category = value; }
        }
    }
}
