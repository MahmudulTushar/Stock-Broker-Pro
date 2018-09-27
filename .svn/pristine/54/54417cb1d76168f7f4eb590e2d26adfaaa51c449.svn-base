using System;
using System.Data;
using DataAccessLayer;

namespace BusinessAccessLayer.BAL
{
    public class BuyShareListReviewBAL
    {
          DbConnection _dbConnection;
          public BuyShareListReviewBAL()
          {
            _dbConnection = new DbConnection();
          }

         
      
        public DataTable GetCustWiseBuyShareList(DateTime transDate)
        {
            DataTable dtShareDWReview = null;
            string quryString = @"RptGetCustWiseBuyShareList";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@transDate",SqlDbType.DateTime,transDate.ToShortDateString());
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

        public DataTable GetInstruWiseBuyShareList(DateTime transDate)
        {
            DataTable dtShareDWReview = null;
            string quryString = "";
            quryString = @"RptGetInstruWiseBuyShareList";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@transDate", SqlDbType.DateTime, transDate.ToShortDateString());
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
