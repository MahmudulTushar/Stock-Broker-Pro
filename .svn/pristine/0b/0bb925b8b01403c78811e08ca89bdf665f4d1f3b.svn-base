using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DataAccessLayer;

namespace BusinessAccessLayer.BAL
{
    public class SellShareListReviewBAL
    {
          DbConnection _dbConnection;
          public SellShareListReviewBAL()
          {
            _dbConnection = new DbConnection();
          }
      
        public DataTable GetCustWiseSellShareList(DateTime transDate)
        {
            DataTable dtShareDWReview = null;
            string quryString = "";
            quryString = @"RptGetCustWiseSellShareList";
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

        public DataTable GetInstruWiseSellShareList(DateTime transDate)
        {
            DataTable dtShareDWReview = null;
            string quryString = "";
            quryString = @"RptGetInstruWiseSellShareList";
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

        public DataTable GetBuySellNetAmnt(DateTime transDate)
        {
            DataTable dtShareDWReview = null;
            string quryString = "";
            quryString = @"RptGetBuySellNetAmnt";
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
