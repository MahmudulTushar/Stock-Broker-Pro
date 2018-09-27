using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DataAccessLayer;

namespace BusinessAccessLayer.BAL
{
    public class ShareDWReviewBAL
    {
        DbConnection _dbConnection;
        public ShareDWReviewBAL()
        {
            _dbConnection = new DbConnection();
        }
        public DataTable GetShareDWReview(DateTime fromDate, DateTime toDate)
        {
          DataTable dtShareDWReview =null;
          string quryString="";
            quryString = @"RptGetShareDWReview";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@fromDate", SqlDbType.DateTime, fromDate.ToShortDateString());
                _dbConnection.AddParameter("@toDate", SqlDbType.DateTime, toDate.ToShortDateString());
                dtShareDWReview = _dbConnection.ExecuteProQuery(quryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dtShareDWReview;
        }
    }
}
