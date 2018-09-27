using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using System.Data;
using System.Data.SqlClient;

namespace BusinessAccessLayer.BAL
{
   public class Pay_Out_Confirmation_Report_DSE_21_11BAL
    {
        private DbConnection _dbConnection;
        public Pay_Out_Confirmation_Report_DSE_21_11BAL()
        {
            _dbConnection = new DbConnection();
        }
        public DataTable GetPay_In_Confirmation_ReportData(string instrumentGroup, string branch, DateTime reportDate)
        {
            DataTable data = new DataTable();
            try
            {
                //string Query = @"rptPay_Out_Confirmation_Report_DSE_21_11";
                string Query = @"Exec rptPay_Out_Confirmation_Report_DSE_21_11 '" + reportDate.ToShortDateString() + "','" + instrumentGroup + "','" + branch + "'";
                _dbConnection.ConnectDatabase();
                //_dbConnection.ActiveStoredProcedure();
                //_dbConnection.AddParameter("@Date", SqlDbType.DateTime, reportDate);
                //_dbConnection.AddParameter("@Instrument_Group", SqlDbType.VarChar, instrumentGroup);
                //_dbConnection.AddParameter("@Branch", SqlDbType.VarChar, branch);
                
                data = _dbConnection.ExecuteProByText(Query);
                //data = _dbConnection.ExecuteProQuery(Query);
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
        public DataTable GetBranchName()
        {
            DataTable data = new DataTable();
            string query = @"SELECT 0,'All'
                            UNION ALL 
                            SELECT [Branch_ID],[Branch_Name]
                            FROM SBP_Broker_Branch
                            WHERE IS_Active=1";
            _dbConnection.ConnectDatabase();
            data = _dbConnection.ExecuteQuery(query);
            return data;
        }
        public DataTable GetInstrumentGroup()
        {
            DataTable data = new DataTable();
            string query = @"SELECT [Comp_Cat_ID], [Comp_Category] FROM SBP_Comp_Category";
            _dbConnection.ConnectDatabase();
            data = _dbConnection.ExecuteQuery(query);
            return data;
        }
    }
}
