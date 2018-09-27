using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessAccessLayer.BO
{

    public class Bank_Branch_RoutingBO
    {
        public Bank_Branch_RoutingBO()
        {
            _bank_ID = 0;
            _bank_Code = string.Empty;
            _bank_Name = string.Empty;
            _branch_ID = 0;
            _branch_Code = string.Empty;
            _branch_Name = string.Empty;
            _routing_No = string.Empty;
            _district_ID = 0;
            _district_Code = string.Empty;
            _district_Name = string.Empty;
            _thana_ID = 0;
            _thana_Code = string.Empty;
            _thana_Name = string.Empty;
        }

        private int _bank_ID;
        private string _bank_Code;
        private string _bank_Name;       
        private int _branch_ID;
        private string _branch_Code;
        private string _branch_Name;
        private string _routing_No;
        private int _district_ID;
        private string _district_Code;
        private string _district_Name;
        private int _thana_ID;
        private string _thana_Code;
        private string _thana_Name;
        public int Bank_Id
        {
            get { return _bank_ID; }
            set { _bank_ID = value; }
        }

        public string Bank_Code
        {
            get { return _bank_Code; }
            set { _bank_Code = value; }
        }

        public string Bank_Name
        {
            get { return _bank_Name; }
            set { _bank_Name = value; }
        }
        public int Branch_Id
        {
            get { return _branch_ID; }
            set { _branch_ID = value; }
        }

        public string Branch_Code
        {
            get { return _branch_Code; }
            set { _branch_Code = value; }
        }


        public string Branch_Name
        {
            get { return _branch_Name; }
            set { _branch_Name = value; }
        }

        public string RoutingNo
        {
            get { return _routing_No; }
            set { _routing_No = value; }
        }

        public int District_Id
        {
            get { return _district_ID; }
            set { _district_ID = value; }
        }

        public string District_Code
        {
            get { return _district_Code; }
            set { _district_Code = value; }
        }


        public string District_Name
        {
            get { return _district_Name; }
            set { _district_Name = value; }
        }

        public int Thana_Id
        {
            get { return _thana_ID; }
            set { _thana_ID = value; }
        }

        public string Thana_Code
        {
            get { return _thana_Code; }
            set { _thana_Code = value; }
        }

        public string Thana_Name
        {
            get { return _thana_Name; }
            set { _thana_Name = value; }
        }


    }
}
