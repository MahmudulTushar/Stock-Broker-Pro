using System;

namespace BusinessAccessLayer.BO
{
    public class UserManagementBO
    {
        private string _userName;
        private string _password;
        private string _name;
        private string _address;
        private string _contactNo;
        private string _remarks;
        private int _isActive;
        private string _roleName;
        private int _branchId;
        private DateTime _entryDate;
        private string _entryBy;
        private string _employeeCode;
        public UserManagementBO()
        {
            _userName = "";
            _password = "";
            _name = "";
            _address = "";
            _contactNo = "";
            _remarks = "";
            _isActive = 1;
            _roleName = "";
            _entryBy = "";
            _employeeCode = "";

        }

        public string UserName
        {
            get { return _userName; }
            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new Exception("User Name must be required.");
                _userName = value;
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new Exception("Password must be required.");
                _password = value;
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
            }
        }

        public string Address
        {
            get { return _address; }
            set
            {
                _address = value;
            }
        }

        public string ContactNo
        {
            get { return _contactNo; }
            set { _contactNo = value; }
        }

        public string Remarks
        {
            get { return _remarks; }
            set { _remarks = value; }
        }

        public int IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }

        public int BranchId
        {
            get { return _branchId; }
            set { _branchId = value; }
        }

        public DateTime EntryDate
        {
            get { return _entryDate; }
            set { _entryDate = value; }
        }

        public string EntryBy
        {
            get { return _entryBy; }
            set { _entryBy = value; }
        }

        public string RoleName
        {
            get { return _roleName; }
            set { _roleName = value; }
        }

        public string EmployeeCode
        {
            get { return _employeeCode; }
            set { _employeeCode = value; }
        }
    }
}
