using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccessLayer;

namespace BusinessAccessLayer.BAL
{
    public class ZgroupBuySellReportBAL
    {
        DbConnection _dbConnection;
        public ZgroupBuySellReportBAL()
        {
            _dbConnection = new DbConnection();
        }
        public DataTable GetZgroupShareBuySellReport(int zgroupId, DateTime startDate, DateTime endDate)
        {
            DataTable dtZgroupShareBuySell = null;
            string quryString = @"RptGetZ_GroupBuySellReport";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@ZgroupCategoryId", SqlDbType.Int, zgroupId);
                _dbConnection.AddParameter("@StartDate", SqlDbType.DateTime, startDate.ToShortDateString());
                _dbConnection.AddParameter("@EndDate", SqlDbType.DateTime, endDate.ToShortDateString());
                dtZgroupShareBuySell = _dbConnection.ExecuteProQuery(quryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dtZgroupShareBuySell;
        }

        public int GetZgroupCompanyId()
        {
            DataTable dtZgroupId = null;
            int zgroupId = 0;
            string quryString = @"SELECT Comp_Cat_ID FROM dbo.SBP_Comp_Category
                                  WHERE Comp_Category='Z' ";
            try
            {
                _dbConnection.ConnectDatabase();
                dtZgroupId = _dbConnection.ExecuteQuery(quryString);
                if (dtZgroupId.Rows.Count > 0)
                {
                    zgroupId = Convert.ToInt32(dtZgroupId.Rows[0][0].ToString());
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return zgroupId;
        }

    }
}
