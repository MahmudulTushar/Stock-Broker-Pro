using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using System.Data;
using System.Data.SqlClient;

namespace  BusinessAccessLayer.BAL
{
   public class Portfolio_Statement_Instrumnet_Wise_DSE_22_3BAL
    {
        #region dbconnection
        private DbConnection _dbconnection;
        #endregion

        #region Construction
        public Portfolio_Statement_Instrumnet_Wise_DSE_22_3BAL()
        {
            this._dbconnection = new DbConnection();
        }
        #endregion

        #region execute Procedure
        public DataTable Portfolio_Statement_Instrumnet_Wise(string Company_Code, DateTime Trade_Date, string Exchange)
        {
            DataTable dt = new DataTable();
            try
            {
                string query = @"exec rptPortfolio_Statement_Instrumnet_Wise_DSE_22_3 '" + Exchange + "','" + Trade_Date.ToShortDateString() + "','" + Company_Code + "'";
                this._dbconnection.ConnectDatabase();
                //this._dbconnection.ActiveStoredProcedure();
                //this._dbconnection.AddParameter("@Comp_Code", SqlDbType.VarChar, Company_Code);
                //this._dbconnection.AddParameter("@Max_Date", SqlDbType.DateTime, Trade_Date);
                //this._dbconnection.AddParameter("@ExchangeName", SqlDbType.VarChar, Exchange);
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

        #region GetCompany short code
        public string GetCompanyCode(string inscode)
        {
            DataTable dt = new DataTable();
            try
            {
//                string query = @"select 'All' as Instrument_Code 
//                                union all
//                                select Instrument_Code
//                                from SBP_Trade_Price";
                string query = @"select Instrument_Code from SBP_Trade_Price where Instrument_Code= '"+inscode+"'";
                this._dbconnection.ConnectDatabase();
                dt = this._dbconnection.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this._dbconnection.CloseDatabase();
            }
            string code = "";
            if (dt.Rows.Count > 0)
            {
                code = dt.Rows[0][0].ToString();
            }
            return code;
        }
        #endregion

        #region GetExchange Name
        public DataTable GetExchangeName()
        {
            DataTable dt = new DataTable();
            try
            {
                string query = @"select 'All' as Exchange_Code 
                                union all
                                select Exchange_Code 
                                from SBP_STOCK_EXCHANGE";
                this._dbconnection.ConnectDatabase();
                dt = this._dbconnection.ExecuteQuery(query);
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
