using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using System.Data;
using System.Data.SqlClient;


namespace BusinessAccessLayer.BAL
{
   public class BO_Closing_Report_DSE_21_6BAL
    {
        private DbConnection _dbConnection;
        public BO_Closing_Report_DSE_21_6BAL()
        {
            _dbConnection = new DbConnection();
        }

        public DataTable GetBO_Closing_ReportData(DateTime fromDate, DateTime toDate)
        {
            DataTable data = new DataTable();
            try
            {
                string Query = @"rptBO_Closing_Report_DSE_21_6";
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@Start_Date", SqlDbType.DateTime, fromDate);
                _dbConnection.AddParameter("@End_Date", SqlDbType.DateTime, toDate);
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

    }
}
