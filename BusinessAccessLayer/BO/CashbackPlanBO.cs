using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessAccessLayer.BO
{
    public class CashbackPlanBO
    {
        private int _slNo;
        private string _planName;
        private string _description;
        private DateTime _planDate;
        public CashbackPlanBO()
        {
            _planName = "";
            _description = "";
        }

        public int SlNo
        {
            get { return _slNo; }
            set { _slNo = value; }
        }

        public string PlanName
        {
            get { return _planName; }
            set { _planName = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public DateTime PlanDate
        {
            get { return _planDate; }
            set { _planDate = value; }
        }
    }
}
