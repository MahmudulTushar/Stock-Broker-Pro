using System.Data;
using System;

namespace BusinessAccessLayer.BO

{
    public class ReportReviewBO
    {
       private DateTime _fromDate;
       private DateTime _toDate;

        public ReportReviewBO()
        {
           
        }

        public DateTime FromDate
        {
            get { return _fromDate; }
            set { _fromDate = value; }
        }

        public DateTime ToDate
        {
            get { return _toDate; }
            set { _toDate = value; }
        }
    }
}
