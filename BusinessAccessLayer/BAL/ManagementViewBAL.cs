using System;
using System.Data;
using DataAccessLayer;

namespace BusinessAccessLayer.BAL
{
    public class ManagementViewBAL
    {
         private DbConnection _dbConnection;

         public ManagementViewBAL()
        {
            _dbConnection = new DbConnection();
        }
        
        public DataTable GetmanagementBOInfo(int month, int year)
        {
            string queryString = "";
            DataTable dataTable = new DataTable();
            queryString =@"ShowManagementViewData";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@month", SqlDbType.Int,month);
                _dbConnection.AddParameter("@year", SqlDbType.Int,year);
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
        public DataTable GetBranchReport(int month, int year)
        {
            string queryString = "";
            DataTable dataTable = new DataTable();
            queryString = @"SBPBranchReport";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@month", SqlDbType.Int, month);
                _dbConnection.AddParameter("@year", SqlDbType.Int, year);
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
