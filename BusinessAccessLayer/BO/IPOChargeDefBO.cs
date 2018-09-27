﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessAccessLayer.BO
{
    public class IPOChargeDefBO
    {
        private long _slNo;
        private string _compShortCode;
        private string _compName;
        private float _commision;
        private string _shareType;
        private DateTime _effectiveDate;
        private string _remarks1;
        private string _remarks2;
        public IPOChargeDefBO()
        {
            _slNo = 0;
            _compShortCode = "";
            _compName = "";
            _commision = 0;
            _shareType = "";
            _remarks1 = "";
            _remarks2 = "";
        }

        public long SlNo
        {
            get { return _slNo; }
            set { _slNo = value; }
        }

        public string CompShortCode
        {
            get { return _compShortCode; }
            set { _compShortCode = value; }
        }

        public string CompName
        {
            get { return _compName; }
            set { _compName = value; }
        }

        public float Commision
        {
            get { return _commision; }
            set { _commision = value; }
        }

        public string ShareType
        {
            get { return _shareType; }
            set { _shareType = value; }
        }

        public DateTime EffectiveDate
        {
            get { return _effectiveDate; }
            set { _effectiveDate = value; }
        }

        public string Remarks1
        {
            get { return _remarks1; }
            set { _remarks1 = value; }
        }

        public string Remarks2
        {
            get { return _remarks2; }
            set { _remarks2 = value; }
        }
    }
}
