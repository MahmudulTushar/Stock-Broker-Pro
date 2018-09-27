using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessAccessLayer.BO
{
    public class District_NameBO
    {
        public District_NameBO()
        {
            _district_Code = "";
            _district_Name = string.Empty;
            _district_Description = string.Empty;
        }

        private string _district_Code;
        private string _district_Name;
        private string _district_Description;

        public string District_Code
        {
            get { return _district_Code; }
            set { _district_Code = value; }
        }

        public string DistrictName
        {
            get { return _district_Name; }
            set { _district_Name = value; }
        }

        public string District_Description
        {
            get { return _district_Description; }
            set { _district_Description = value; }
        }
    }
}
