using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessAccessLayer.BO
{
  public class CashBackSessionBO
    {
        public CashBackSessionBO()
        {
            _iD = 0;
            _name = string.Empty;
            _description = string.Empty;
            _entry_By = string.Empty;
            _isProcessed = 0;
        }

        private int _iD;
        private string _name;
        private string _description;
        private string _session_Start_Date;
        private string __session_End_Date;
        private string _remarks;
        private DateTime _entry_Date;
        private string _entry_By;
        private int _isProcessed;



        public int _ID
        {
            get { return _iD; }
            set { _iD = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public string SessionStartDate
        {
            get { return _session_Start_Date; }
            set { _session_Start_Date = value; }
        }

        public string SessionEndDate
        {
            get { return __session_End_Date; }
            set { __session_End_Date = value; }
        }
        public string Remarks
        {
            get { return _remarks; }
            set { _remarks = value; }
        }
        public DateTime EntryDate
        {
            get { return _entry_Date; }
            set { _entry_Date = value; }
        }
        public string EntryBy
        {
            get { return _entry_By; }
            set { _entry_By = value; }
        }

        public int IsProcessed
        {
            get { return _isProcessed; }
            set { _isProcessed = value; }
        }

     
    }
}
