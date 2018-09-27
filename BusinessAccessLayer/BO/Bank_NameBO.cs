using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessAccessLayer.BO
{
    public class Bank_NameBO
    {
        public Bank_NameBO()
        {
            _bank_Code = "";
            _bank_Name = string.Empty;
            _description = string.Empty;
        }

        private string _bank_Code;
        private string _bank_Name;
        private string _description;

        public string Bank_Code
        {
            get { return _bank_Code; }
            set { _bank_Code = value; }
        }

        public string BankName
        {
            get { return _bank_Name; }
            set { _bank_Name = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
    }
}
