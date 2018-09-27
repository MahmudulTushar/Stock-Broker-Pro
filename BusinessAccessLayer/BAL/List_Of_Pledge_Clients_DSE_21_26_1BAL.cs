using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using System.Data;
using System.Data.SqlClient;

namespace BusinessAccessLayer.BAL
{
   public class List_Of_Pledge_Clients_DSE_21_26_1BAL
    {
        private DbConnection _dbConnection;
        public List_Of_Pledge_Clients_DSE_21_26_1BAL()
        {
            _dbConnection = new DbConnection();
        }
        public DataTable GetList_Of_Pledge_Clients_ReportData(DateTime fromDate, DateTime toDate, string exchangeName)
        {
            DataTable data = new DataTable();
            try
            {
                string Query = @"rptList_Of_Pledge_Clients_DSE_21_26_1";
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@Start_Date", SqlDbType.DateTime, fromDate);
                _dbConnection.AddParameter("@End_Date", SqlDbType.DateTime, toDate);
                _dbConnection.AddParameter("@Exchange_Name", SqlDbType.VarChar, exchangeName);
                data = _dbConnection.ExecuteProQuery(Query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return data;
        }
        public DataTable GetExchangeName()
        {
            DataTable data = new DataTable();
            string query = @"SELECT [Exchange_Name]
                             FROM SBP_Broker_Info";
            _dbConnection.ConnectDatabase();
            data = _dbConnection.ExecuteQuery(query);
            return data;
        }

    }
}
