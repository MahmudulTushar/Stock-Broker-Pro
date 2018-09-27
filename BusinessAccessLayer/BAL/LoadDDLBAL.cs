using System;
using System.Data;
using DataAccessLayer;

namespace BusinessAccessLayer.BAL
{
    public class LoadDDLBAL
    {
         private DbConnection _dbConnection;
         public LoadDDLBAL()
        {
            _dbConnection = new DbConnection();
        }
        public DataTable LoadDDL(string tableName)
        {
            DataTable dataTable;
            dataTable = null;
            string queryString = "";
            queryString = "SELECT * FROM " + tableName + ";";
            try
            {
                _dbConnection.ConnectDatabase();
                dataTable = _dbConnection.ExecuteQuery(queryString);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dataTable;
        }
        public DataTable LoadDDL(string tableName, string exClause)
        {
            DataTable dataTable;
            dataTable = null;
            string queryString = "";
            queryString = "SELECT * FROM " + tableName + " " + exClause;
            try
            {
                _dbConnection.ConnectDatabase();
                dataTable = _dbConnection.ExecuteQuery(queryString);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dataTable;
        }
        public DataTable LoadBranchesDDL()
        {
            DataTable dataTable;
            dataTable = null;
            string queryString = "";
            queryString = "SELECT Branch_ID, Branch_Name FROM SBP_Broker_Branch WHERE IS_Active=1;";
            try
            {
                _dbConnection.ConnectDatabase();
                dataTable = _dbConnection.ExecuteQuery(queryString);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dataTable;
        } 
        public DataTable GetSessionName()
        {
            DataTable dataTable;
            dataTable = null;
            string queryString = "";
            queryString = "SELECT * FROM SBP_Cashback_Session WHERE [IsProcessed] =0";
            try
            {
                _dbConnection.ConnectDatabase();
                dataTable = _dbConnection.ExecuteQuery(queryString);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dataTable;
        }
    }
}
