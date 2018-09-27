using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataAccessLayer;

namespace BusinessAccessLayer.BAL
{
    public class ShareBalanceBAL
    {
         private DbConnection _dbConnection;
         public ShareBalanceBAL()
        {
            _dbConnection = new DbConnection();
        }
         public DataTable GetShareSummery(string custCode)
         {
             DataTable dataTable;
             string queryString = "";
             queryString = @"RptGetShareSummery";
             try
             {
                 _dbConnection.ConnectDatabase();
                 _dbConnection.ActiveStoredProcedure();
                 _dbConnection.AddParameter("@custCode", SqlDbType.NVarChar,custCode);
                 dataTable = _dbConnection.ExecuteProQuery(queryString);
             }
             catch (Exception exception)
             {
                 throw exception;
             }
             finally
             {
                 _dbConnection.CloseDatabase();
             }
             return dataTable;
         }

        public DataTable GetCompanySummery(string compShortName)
        {
            DataTable dataTable;
            string queryString = "";
            queryString = @"RptGetCompanySummery";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@compShortName", SqlDbType.NVarChar,compShortName);
                dataTable = _dbConnection.ExecuteProQuery(queryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dataTable;
        }
        public DataTable GetCompanyWiseShareTradeList(string instrumentCode,DateTime fromDate,DateTime toDate)
        {
            DataTable dataTable;
            string queryString = "";
            queryString = @"RptGetInstruWiseTradeList";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@InstrumentCode", SqlDbType.NVarChar, instrumentCode);
                _dbConnection.AddParameter("@FromDate", SqlDbType.DateTime, fromDate);
                _dbConnection.AddParameter("@ToDate", SqlDbType.DateTime, toDate);
                dataTable = _dbConnection.ExecuteProQuery(queryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dataTable;
        
        
        }

    }
}
