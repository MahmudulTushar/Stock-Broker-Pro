using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessAccessLayer.BO
{
    public class HolidayBO
    {
        private int _slNo;
        private DateTime _holydayDate;
        private string _purpose;

        public HolidayBO()
        {
            _purpose = "";
        }

        public int SlNo
        {
            get { return _slNo; }
            set { _slNo = value; }
        }

        public DateTime HolydayDate
        {
            get { return _holydayDate; }
            set { _holydayDate = value; }
        }

        public string Purpose
        {
            get { return _purpose; }
            set { _purpose = value; }
        }
    }
}
