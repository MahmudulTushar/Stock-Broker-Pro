using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessAccessLayer.BO
{
    public class ChargeDefBO
    {
        private long _chDefID;
        private string _chItem;
        private string _chItemDescription;
        private float _minCh;
        private float _chRate;
        private string _category;
        private DateTime _effectiveDate;

        public ChargeDefBO()
        {
            _chDefID = 0;
            _chItem = "";
            _chItemDescription = "";
            _minCh = 0;
            _chRate = 0;
            _category = "";
        }

        public long ChDefId
        {
            get { return _chDefID; }
            set { _chDefID = value; }
        }

        public string ChItem
        {
            get { return _chItem; }
            set { _chItem = value; }
        }

        public string ChItemDescription
        {
            get { return _chItemDescription; }
            set { _chItemDescription = value; }
        }

        public float MinCh
        {
            get { return _minCh; }
            set { _minCh = value; }
        }

        public float ChRate
        {
            get { return _chRate; }
            set { _chRate = value; }
        }

        public string Category
        {
            get { return _category; }
            set { _category = value; }
        }

        public DateTime EffectiveDate
        {
            get { return _effectiveDate; }
            set { _effectiveDate = value; }
        }
    }
}
