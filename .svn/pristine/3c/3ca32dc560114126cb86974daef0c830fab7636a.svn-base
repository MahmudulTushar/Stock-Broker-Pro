using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using System.Data;
using System.Data.SqlClient;

namespace BusinessAccessLayer.BAL
{
   public class Broker_Comission_Report_DSE_24_1BAL
    {
        #region dbconnection
        private DbConnection _dbconnection;
        #endregion

        #region Constructor
        public Broker_Comission_Report_DSE_24_1BAL()
        {
            this._dbconnection = new DbConnection();
        }
        #endregion

        #region Execute Storeprocedure
        public DataTable Broker_Comission(DateTime Start_Date, DateTime End_Date,string Exchange, string Selection,string _subSelection)
        {
            DataTable dt = new DataTable();
            try
            {
                string query = @"rptBroker_Comission_Report_DSE_24_1";                
                this._dbconnection.ConnectDatabase();
                this._dbconnection.ActiveStoredProcedure();
                this._dbconnection.AddParameter("@Start_Date", SqlDbType.DateTime, Start_Date.ToShortDateString());
                this._dbconnection.AddParameter("@End_Date", SqlDbType.DateTime, End_Date.ToShortDateString());
                this._dbconnection.AddParameter("@Exchange_Name", SqlDbType.VarChar, Exchange);                                
                this._dbconnection.AddParameter("@Selection_Type", SqlDbType.VarChar, Selection);
                this._dbconnection.AddParameter("@Sub_Selection", SqlDbType.VarChar, _subSelection);
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
        #endregion

        #region execute trader
        public DataTable Broker_Comission_Trade(DateTime Start_Date, DateTime End_Date, string Exchange, string Branch_Name, string Selection)
        {
            DataTable dt = new DataTable();
            try
            {
                string query = @"exec rptBroker_Comission_Report_DSE_24_1 '" + Start_Date.ToShortDateString() + "','" + End_Date.ToShortDateString() + "','" + Exchange + "','" + Selection + "','" + Branch_Name + "'";
                this._dbconnection.ConnectDatabase();
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

        #region Exchange Name
        public DataTable GetExchangeName()
        {
            DataTable dt = new DataTable();
            try
            {
                string query = @"select  AS Exchange_Code 
                                from SBP_STOCK_EXCHANGE";
                this._dbconnection.ConnectDatabase();
                dt=this._dbconnection.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
            }
            return dt;
        }
        #endregion

        #region Branch Name
        public DataTable GetBranchName()
        {
            DataTable dt = new DataTable();
            try
            {
                string query = @"select Branch_Name 
                                from SBP_Broker_Branch";
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

        #region Trader Name
        public DataTable GetTraderName()
        {
            DataTable dt = new DataTable();
            try
            {
                string query = @"
                                select WorkStation_Name 
                                from SBP_Workstation";
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
