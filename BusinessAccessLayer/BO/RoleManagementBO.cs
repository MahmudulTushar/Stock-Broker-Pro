using System;

namespace BusinessAccessLayer.BO
{
    public class RoleManagementBO
    {
        private string _roleName;
        private string  _description;
        private DateTime _CreationDate;
        
        public RoleManagementBO()
        {
            _roleName = "";
            _description = "";
            
        }
        public string RoleName
        {
            get { return _roleName; }
            set { _roleName = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public DateTime CreationDate
        {
            get { return _CreationDate; }
            set { _CreationDate = value; }
        }
    }
}
