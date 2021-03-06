﻿using System;

namespace BusinessAccessLayer.BO
{
    public class BranchManagementBO
    {
        private long _branchId;
        private string _branchName;
        private string _branchAddress;
        private string _telePhone;
        private string _fax;
        private string _eMail;
        private string _web;
        private DateTime _branchOpeningdate;
        private DateTime _branchClosingDate;
        private int _branchIsActive;
        public BranchManagementBO()
        {
            _branchId = 0;
            _branchName = "";
            _branchAddress = "";
            _web = "";
            _telePhone = "";
            _fax = "";
            _eMail = "";
            _branchIsActive = 1;
        }
       
        public string BranchName
        {
            get { return _branchName; }
            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new Exception("Branch Name must be required.");
                _branchName = value;
            }
        }

        public string BranchAddress
        {
            get { return _branchAddress; }
            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new Exception("Branch Address must be required.");
                _branchAddress = value;
            }
        }

        public DateTime BranchOpeningdate
        {
            get { return _branchOpeningdate; }
            set { _branchOpeningdate = value; }
        }

        public DateTime BranchClosingDate
        {
            get { return _branchClosingDate; }
            set { _branchClosingDate = value; }
        }

        public int BranchIsActive
        {
            get { return _branchIsActive; }
            set { _branchIsActive = value; }
        }
        public long BranchId
        {
            get { return _branchId; }
            set { _branchId = value; }
        }

        public string TelePhone
        {
            get { return _telePhone; }
            set { _telePhone = value; }
        }

        public string Fax
        {
            get { return _fax; }
            set { _fax = value; }
        }

        public string Email
        {
            get { return _eMail; }
            set { _eMail = value; }
        }

        public string Web
        {
            get { return _web; }
            set { _web = value; }
        }
    }

}
