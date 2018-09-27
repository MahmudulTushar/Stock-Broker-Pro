using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessAccessLayer.BO
{
    public class EFT_File_InfoBO
    {
        private int _iD;

        public int ID
        {
            get { return _iD; }
            set { _iD = value; }
        }

        private string _file_No;

        public string File_No
        {
            get { return _file_No; }
            set { _file_No = value; }
        }
        private string _file_Password;

        public string File_Password
        {
            get { return _file_Password; }
            set { _file_Password = value; }
        }

        private string _file_Path;

        public string File_Path
        {
            get { return _file_Path; }
            set { _file_Path = value; }
        }
        private DateTime _file_Issue_Date;

        public DateTime File_Issue_Date
        {
            get { return _file_Issue_Date; }
            set { _file_Issue_Date = value; }
        }
        private bool _isExported;

        public bool IsExported
        {
            get { return _isExported; }
            set { _isExported = value; }
        }
        private string _issue_By;

        public string Issue_By
        {
            get { return _issue_By; }
            set { _issue_By = value; }
        }

        public EFT_File_InfoBO()
        {
            _file_No = string.Empty;
            _file_Path = string.Empty;
            //_file_Issue_Date =
            _issue_By = string.Empty;
            _file_Password = string.Empty;
            _isExported = false;
        }
    }
}
