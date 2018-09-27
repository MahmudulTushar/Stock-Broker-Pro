using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccessLayer;

namespace BusinessAccessLayer.BAL
{
   public class IPOPaymentReviewBAL
    {
        private DbConnection _dbConnection;
        public IPOPaymentReviewBAL()
        {
            this._dbConnection = new DbConnection();
        }
        public DataTable GnerateIPOPaymentReview(DateTime fromDate, DateTime toDate, int isSorted,int Branch_ID)
        {
            DataTable dtPaymentReview = null;
            int isAccountsView = 0;
            string quryString = "";

            quryString = @"RptIPONewPaymentReviewSorted";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@fromDate", SqlDbType.DateTime, fromDate.ToShortDateString());
                _dbConnection.AddParameter("@toDate", SqlDbType.DateTime, toDate.ToShortDateString());
                _dbConnection.AddParameter("@IsSorted", SqlDbType.Int, isSorted);
                _dbConnection.AddParameter("@IsAccountsView", SqlDbType.Int, isAccountsView);
                _dbConnection.AddParameter("@Branch_ID", SqlDbType.Int, Branch_ID);
                dtPaymentReview = _dbConnection.ExecuteProQuery(quryString);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dtPaymentReview;

        }        

    }
}
