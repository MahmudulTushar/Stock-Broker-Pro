using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DataAccessLayer;

namespace BusinessAccessLayer.BAL
{
    public class DataLoaderBAL
    {
         private DbConnection _dbConnection;

         public DataLoaderBAL()
        {
            _dbConnection = new DbConnection();
        }

       
        public void InsertDataGeneratePLTP(DataTable dataTable)
        {
            string queryString = @"EXECUTE GeneratePLTP;";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(queryString);
                _dbConnection.BulkCopy(dataTable, "SBP_LTP");
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
        }
    }
}
