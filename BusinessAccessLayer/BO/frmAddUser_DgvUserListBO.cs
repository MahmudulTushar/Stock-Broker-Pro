using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessAccessLayer.BO
{
    public class frmAddUser_DgvUserListBO
    {
        private bool _isSelected;

        public bool IsSelected
        {
            get { return _isSelected; }
            set { _isSelected = value; }
        }
        private string _userName;

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        public frmAddUser_DgvUserListBO()
        {
            _isSelected = false;
            _userName = string.Empty;
        }


    }
}
