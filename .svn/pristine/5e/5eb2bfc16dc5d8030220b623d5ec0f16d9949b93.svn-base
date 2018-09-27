using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DataAccessLayer;

namespace BusinessAccessLayer.BAL
{
    public class CashLimitBAL
    {
        private DbConnection _dbConnection;

        public CashLimitBAL()
        {
            _dbConnection = new DbConnection();
        }

        public DataTable GetCashLimitData()
        {
            DataTable dataTable;
            string queryString = @"GenerateCashLimit";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
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
        public DataTable GetCashLimitDataP()
        {
            DataTable dataTable;
            string queryString = "EXECUTE GenerateLimitListP";
            try
            {
                _dbConnection.ConnectDatabase();
                dataTable = _dbConnection.ExecuteQuery(queryString);
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
