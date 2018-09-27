using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer
{
    public class LoginInfo
    {
        public static string _userName = "";
        public static int _branchId = 0;
        public static string _branchName = "";
        public static bool _addCategoryPriv = false;
        public static string _employeeCode = "";
        public static string _role_Name = "";
        public static DateTime _currentServerDate;
        public enum ModeSelection
        {
            NewMode,
            UpdateMode,
            NoneMode
        }
    }
}
