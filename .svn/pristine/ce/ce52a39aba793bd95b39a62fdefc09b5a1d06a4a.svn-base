using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using System.Data;
using System.Data.SqlClient;

namespace BusinessAccessLayer.BAL
{
    public class Right_Instrument_Received_Report_DSE_21_15_BAL
    {
        private DbConnection _dbConnection;
        public Right_Instrument_Received_Report_DSE_21_15_BAL()
        {
            _dbConnection = new DbConnection();
        }

        public DataTable ReportData_15(DateTime fromDate, DateTime toDate, string instrumentId)
        {
            DataTable data = new DataTable();
            try
            {
                string Query = @"rptRight_Instrument_Received_Report_DSE_21_15";
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@Start_Date", SqlDbType.DateTime, fromDate);
                _dbConnection.AddParameter("@End_Date", SqlDbType.DateTime, toDate);
                _dbConnection.AddParameter("@Instrument_ID", SqlDbType.VarChar, instrumentId);
                data = _dbConnection.ExecuteProQuery(Query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return data;
        }
        public DataTable GetInstrument()
        {
            DataTable data = new DataTable();
            try
            {
                string Query = @"SELECT 'All' AS Comp_Short_Code
                                 UNION ALL
                                 SELECT 
                                 [Comp_Short_Code]
                                 FROM [SBP_Company]";
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
            return data;
        }

        public DataTable GetInstrumentByPrefix(string prefix)
        {
            DataTable data = new DataTable();
            try
            {
                string Query = @"SearchCompany";
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@Instrument_ID", SqlDbType.VarChar, prefix);
                data = _dbConnection.ExecuteProQuery(Query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return data;
        }
    }
}
