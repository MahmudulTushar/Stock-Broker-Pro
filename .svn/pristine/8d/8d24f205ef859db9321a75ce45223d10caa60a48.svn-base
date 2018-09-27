using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccessLayer;


namespace BusinessAccessLayer.BAL
{
   public class SpotMarketShareBuySellBAL
    {
        DbConnection _dbConnection;
        public SpotMarketShareBuySellBAL()
        {
            _dbConnection = new DbConnection();
        }
        public DataTable GetSpotMarketcShareBuySellReport(DateTime startDate, DateTime endDate)
        {
            DataTable dtSpotMarketcShareBuySell = null;
            string quryString = @"RptGetSpotMarketShare_BuySellReport";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@StartDate", SqlDbType.DateTime, startDate.ToShortDateString());
                _dbConnection.AddParameter("@EndDate", SqlDbType.DateTime, endDate.ToShortDateString());
                dtSpotMarketcShareBuySell = _dbConnection.ExecuteProQuery(quryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dtSpotMarketcShareBuySell;
        }

    }
}
