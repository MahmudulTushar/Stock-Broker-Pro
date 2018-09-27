using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;

namespace BusinessAccessLayer.BAL
{
    public class Rights_Instrumens_Confirmation_Report_Dse_21_14_BAL
    {
        private DbConnection _dbConnection;
        public Rights_Instrumens_Confirmation_Report_Dse_21_14_BAL()
        {
            this._dbConnection = new DbConnection();
        }
        public DataTable Reprot_dse_21(string CustCode, string BOID, DateTime fromDate, DateTime toDate, string instrumentId)
        {
            DataTable dt = new DataTable();
            try
            {
                //string query = @"rptRights_Instrumens_Confirmation_Report_Dse_21_14";
                string query = @"exec rptRights_Instrumens_Confirmation_Report_Dse_21_14 '" + fromDate.ToShortDateString() + "','" + toDate.ToShortDateString() + "','" + BOID + "','" + CustCode + "','" + instrumentId + "' ";
                this._dbConnection.ConnectDatabase();
                //this._dbConnection.ActiveStoredProcedure();
                //this._dbConnection.AddParameter("@Start_Date", SqlDbType.DateTime, fromDate);
                //this._dbConnection.AddParameter("@End_Date", SqlDbType.DateTime, toDate);
                //this._dbConnection.AddParameter("@BO_ID", SqlDbType.VarChar, BOID);
                //this._dbConnection.AddParameter("@Investor_ID", SqlDbType.VarChar, CustCode);                
                //this._dbConnection.AddParameter("@Instrument_ID", SqlDbType.VarChar, instrumentId);
                //dt = _dbConnection.ExecuteProQuery(query);
                dt = this._dbConnection.ExecuteProByText(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this._dbConnection.CloseDatabase();
            }
            return dt;
        }
        public string Getboid(string Custcode)
        {
            string isin = "";
            DataTable data = new DataTable();
            try
            {
                string Query = @"select 
                            BO_ID from 
                            SBP_Customers 
                            where Cust_Code='" + Custcode + "'";

                _dbConnection.ConnectDatabase();
                data = _dbConnection.ExecuteQuery(Query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            if (data.Rows.Count > 0)
            {
                isin = data.Rows[0][0].ToString();
            }
            return isin;
        }
        public string GetCustId(string boid)
        {
            string isin = "";
            DataTable data = new DataTable();
            try
            {
                string Query = @"select Cust_Code from SBP_Customers where BO_ID='" + boid + "'";

                _dbConnection.ConnectDatabase();
                data = _dbConnection.ExecuteQuery(Query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            if (data.Rows.Count > 0)
            {
                isin = data.Rows[0][0].ToString();
            }
            return isin;
        }
        public DataTable GetInstrument()
        {
            DataTable dt = new DataTable();
            try
            {
                string query =
                    @"SELECT 
                                'All' AS Comp_Short_Code
                                UNION ALL 
                                SELECT
                                [Comp_Short_Code]
                                FROM [SBP_Company]";
                this._dbConnection.ConnectDatabase();
                dt = this._dbConnection.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public DataTable GetCustCode()
        {
            DataTable data = new DataTable();
            try
            {
                string Query = @"SELECT 
                                'All' AS Cust_Code
                                ,0 AS BO_ID
                                UNION ALL
                                SELECT
                                [Cust_Code]
                                ,[BO_ID]
                                FROM SBP_Customers";
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

        public DataTable GetCustBOID()
        {
            DataTable data = new DataTable();
            try
            {
                string Query = @"SELECT 
                                'All' AS BO_ID
                                ,0 AS Cust_Code
                                UNION ALL
                                SELECT
                                [BO_ID]
                                ,[Cust_Code]
                                FROM SBP_Customers";
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
    }
}
