using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using DataAccessLayer;

namespace BusinessAccessLayer.BAL
{
    public class DatabaseConnectionCheck
    {
        private DbConnection _dbConnection;

        public DatabaseConnectionCheck()
        {
            DbConnectionBasic.ConnectionString = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
            DbConnectionBasic.ConnectionStringImageExt = ConfigurationManager.ConnectionStrings["sqlconImageExt"].ConnectionString;
            DbConnectionBasic.ConnectionStringSMSSender = ConfigurationManager.ConnectionStrings["sqlconSMSSender"].ConnectionString;
            DbConnectionBasic.connectionStringBankBook = ConfigurationManager.ConnectionStrings["sqlconBankBook"].ConnectionString;
        }

        public double CheckDatabaseConnections()
        {
            DataTable dataTable;
            string queryString = "SELECT Version FROM SBP_Software_Information";

            try
            {
                _dbConnection = new DbConnection();
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
            if (dataTable.Rows.Count > 0)
            {
                return Convert.ToDouble(dataTable.Rows[0][0].ToString());
            }
            else
            {
                return 0;
            }
        }
    }
}
