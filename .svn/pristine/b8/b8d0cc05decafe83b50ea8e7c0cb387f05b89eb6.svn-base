using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using System.Data;

namespace BusinessAccessLayer.BAL
{
   public class Client_Ledger_Detail_Report_DSE_24_10BAL
    {
        private DbConnection _dbconnection;

        #region Constructor
        public Client_Ledger_Detail_Report_DSE_24_10BAL()
        {
            this._dbconnection = new DbConnection();
        }
        #endregion

        #region Execute Query
        public DataTable Client_Ledger_Detail_Report(string Client_Code, DateTime Start_Date, DateTime End_date)
        {
            DataTable dt = new DataTable();
            try
            {
                string query = @"rptClient_Ledger_Detail_Report_DSE_24_10";
                this._dbconnection.ConnectDatabase();
                this._dbconnection.ActiveStoredProcedure();
                this._dbconnection.AddParameter("@Cust_Code", SqlDbType.VarChar, Client_Code);
                this._dbconnection.AddParameter("@Start_Date", SqlDbType.DateTime, Start_Date);
                this._dbconnection.AddParameter("@End_Date", SqlDbType.DateTime, End_date);
                dt=this._dbconnection.ExecuteProQuery(query);
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

        #region Get Client Code
        public DataTable GetClient()
        {
            DataTable dt = new DataTable();
            try
            {
                string query = @"select Cust_Code from SBP_Customers";
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
