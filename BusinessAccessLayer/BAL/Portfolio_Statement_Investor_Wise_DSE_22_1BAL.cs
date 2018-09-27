using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using System.Data;
using System.Data.SqlClient;

namespace BusinessAccessLayer.BAL
{
   public class Portfolio_Statement_Investor_Wise_DSE_22_1BAL
    {
        #region dbconnection
        private DbConnection _dbconnection;
        #endregion

        #region Constructor
        public Portfolio_Statement_Investor_Wise_DSE_22_1BAL()
        {
            this._dbconnection = new DbConnection();
        }
        #endregion 

        #region Execute Storeprocedure
        public DataTable Portfolio_Statement_Investor(string _exchange,DateTime _report_date, string _code)
        {
            DataTable dt = new DataTable();
            try
            {
                string query = @"exec rptPortfolio_Statement_Investor_Wise_DSE_22_1 '" + _exchange + "','" + _report_date.ToShortDateString() +"','" + _code + "'";
                this._dbconnection.ConnectDatabase();
                //this._dbconnection.ActiveStoredProcedure();
                //this._dbconnection.AddParameter("@Exchange_Name", SqlDbType.VarChar, _exchange);
                //this._dbconnection.AddParameter("@Reporting_Date", SqlDbType.DateTime, _report_date);
                //this._dbconnection.AddParameter("@Investor_ID", SqlDbType.VarChar, _code);
                //dt = this._dbconnection.ExecuteProQuery(query);
                dt = this._dbconnection.ExecuteProByText(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this._dbconnection.CloseDatabase();
            }
            return dt;
        }
        #endregion

        #region Client Id
        public DataTable GetInvestorId()
        {
            DataTable dt = new DataTable();
            string query = @"select Cust_Code from  dbo.SBP_BI_Customers order by Cust_Code asc";
            try
            {
                this._dbconnection.ConnectDatabase();
                dt=this._dbconnection.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this._dbconnection.CloseDatabase();
            }
            return dt;
        }
        #endregion
    }
}
