using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using System.Data;
using System.Data.SqlClient;

namespace BusinessAccessLayer.BAL
{
   public class List_Of_Landing_Clients_DSE_21_28_1BAL
    {
        #region Private Field
        private DbConnection _dbconnection;
        #endregion

        #region Constructor
        public List_Of_Landing_Clients_DSE_21_28_1BAL()
        {
            this._dbconnection = new DbConnection();
        }
        #endregion

        #region Execute storeprocedure
        public DataTable Lnading_Clients_Dse(string Exchange_Name,DateTime From_Date, DateTime End_Date)
        {
            DataTable data = new DataTable();
            try
            {
                string query = @"rptList_Of_Lending_Clients_DSE_21_28_1";
               

                this._dbconnection.ConnectDatabase();
                this._dbconnection.ActiveStoredProcedure();
                this._dbconnection.AddParameter("@Exchange_Name", SqlDbType.VarChar, Exchange_Name);
                this._dbconnection.AddParameter("@Start_Date", SqlDbType.VarChar, From_Date);
                this._dbconnection.AddParameter("@End_Date", SqlDbType.VarChar, End_Date);
                data = this._dbconnection.ExecuteProQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this._dbconnection.CloseDatabase();
            }
            return data;
        }
        #endregion

        #region BlankMethod
        public void Lnading_Clients_Dse()
        {
        }
        #endregion

        #region Get Exchange Name
        public DataTable GetExchangeName()
        {
            DataTable dt = new DataTable();
            try
            {
                string query = @"select Exchange_Code from SBP_STOCK_EXCHANGE";
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
