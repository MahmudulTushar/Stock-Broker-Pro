using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessAccessLayer.BO
{
    public class MarginChargeDefBO
    {
        private long _id;
        private string _planName;
        private float _chargeRate;
        private int _effectiveCount;
        private DateTime _effectiveDate;
        private string _remarks;
        public MarginChargeDefBO()
        {
            _planName = "";
            _chargeRate = 0;
            _effectiveCount = 0;
            _remarks = "";
        }

        public long Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string PlanName
        {
            get { return _planName; }
            set { _planName = value; }
        }

        public float ChargeRate
        {
            get { return _chargeRate; }
            set { _chargeRate = value; }
        }

        public int EffectiveCount
        {
            get { return _effectiveCount; }
            set { _effectiveCount = value; }
        }

        public DateTime EffectiveDate
        {
            get { return _effectiveDate; }
            set { _effectiveDate = value; }
        }

        public string Remarks
        {
            get { return _remarks; }
            set { _remarks = value; }
        }
    }
}
