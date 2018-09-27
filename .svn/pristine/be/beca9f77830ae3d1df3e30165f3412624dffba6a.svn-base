using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessAccessLayer.BO;
using DataAccessLayer;

namespace BusinessAccessLayer.BAL
{
    public class Today_Transactions_Customer_ListBAL
    {
        public DbConnection _dbconnection;

        public Today_Transactions_Customer_ListBAL()
        {
            this._dbconnection = new DbConnection();
        }

        public DataTable Today_Transactions_Customer(DateTime TradeDate)
        {
            DataTable dt = new DataTable();
            try
            {
                string query = @"RptToday_TradeRiskAnalysis";
                this._dbconnection.ConnectDatabase();
                this._dbconnection.ActiveStoredProcedure();
                this._dbconnection.AddParameter("@Trade_Date", SqlDbType.DateTime, TradeDate.ToShortDateString());
                dt = this._dbconnection.ExecuteProQuery(query);
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
    }
}
