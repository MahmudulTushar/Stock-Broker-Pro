using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using System.Data;
using System.Data.SqlClient;

namespace BusinessAccessLayer.BAL
{
    public class BO_Modification_Report_DSE_21_5BAL
    {
        private DbConnection _dbConnection;
        public BO_Modification_Report_DSE_21_5BAL()
        {
            _dbConnection = new DbConnection();
        }

        public DataTable GetBO_Modification_ReportData(string CustCode,string BOID, DateTime fromDate, DateTime toDate)
        {
            DataTable data = new DataTable();
            try
            {
                string Query = @"rptBO_Modification_Report_DSE_21_5";
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@Investor_ID", SqlDbType.VarChar, CustCode);
                _dbConnection.AddParameter("@BO_ID", SqlDbType.VarChar, BOID);
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
        public string GetBoIdByCustCode(string id)
        {
            string tempname = "";
            DataTable data = new DataTable();
            try
            {
                string Query = @"select BO_ID from SBP_BI_Customers_Modification_Log where Cust_Code='" + id + "'";
                _dbConnection.ConnectDatabase();
                data = _dbConnection.ExecuteQuery(Query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            if (data.Rows.Count > 0)
            {
                tempname = data.Rows[0][0].ToString();
            }
            return tempname;
        }
        public string GetCustCodeByBoId(string id)
        {
            string tempname = "";
            DataTable data = new DataTable();
            try
            {
                string Query = @"select Cust_Code from SBP_BI_Customers_Modification_Log where BO_ID='" + id + "'";
                _dbConnection.ConnectDatabase();
                data = _dbConnection.ExecuteQuery(Query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            if (data.Rows.Count > 0)
            {
                tempname = data.Rows[0][0].ToString();
            }
            return tempname;
        }

    }
}
