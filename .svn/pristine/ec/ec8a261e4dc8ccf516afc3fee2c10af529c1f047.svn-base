using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessAccessLayer.BO;
using DataAccessLayer;

namespace BusinessAccessLayer.BAL
{
    public class Client_Today_Sale_InfoBAL
    {
        DbConnection _dbConnection;

        public Client_Today_Sale_InfoBAL()
        {
            this._dbConnection = new DbConnection();
        }

        public DataTable Client_Today_Sale(DateTime Trade_Date)
        {
            DataTable dt = new DataTable();
            try
            {
                string query = @"Rpt_TodayMoneyWithdrawAnalysis";
                this._dbConnection.ConnectDatabase();
                this._dbConnection.ActiveStoredProcedure();
                this._dbConnection.AddParameter("@Trade_Date", SqlDbType.DateTime, Trade_Date.ToShortDateString());
                dt = this._dbConnection.ExecuteProQuery(query);
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
    }
}
