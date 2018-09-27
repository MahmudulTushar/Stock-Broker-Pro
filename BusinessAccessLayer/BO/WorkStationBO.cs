using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessAccessLayer.BO
{
    public class WorkStationBO
    {
        private string _workStation;
        private int _branchID;
        public WorkStationBO()
        {
            _workStation = "";
        }

        public string WorkStation
        {
            get { return _workStation; }
            set { _workStation = value; }
        }

        public int BranchId
        {
            get { return _branchID; }
            set { _branchID = value; }
        }
    }
}
