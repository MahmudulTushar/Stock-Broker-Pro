using System;
using DataAccessLayer;
using System.Data;

namespace BusinessAccessLayer.BAL
{
    public class IPODashBoardBAL
    {
        private DbConnection _dbConnection;
        
        public IPODashBoardBAL()
        {
            this._dbConnection = new DbConnection();
        }
        public DataTable IPOShareDetails(string _code,string Short_Code)
        {
            DataTable dt = new DataTable();
            string query = @"SBP_IPOShareDetails";
            try
            {
                this._dbConnection.ConnectDatabase();
                this._dbConnection.ActiveStoredProcedure();

                this._dbConnection.AddParameter("@Short_Code", SqlDbType.VarChar, Short_Code);
                this._dbConnection.AddParameter("@Cust_Cdoe", SqlDbType.Int, _code);
                dt = this._dbConnection.ExecuteProQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable IPOShageSummary(string code)
        {
            DataTable dt = new DataTable();
            string query = @"SBP_IPOShareSummery";
            try
            {
                this._dbConnection.ConnectDatabase();
                this._dbConnection.ActiveStoredProcedure();
                this._dbConnection.AddParameter("@Cust_Code", SqlDbType.VarChar, code);
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

        public DataTable AllIpoapply(string code)
        {
            DataTable dt = null;
            string Query = @"SBP_AllIPOShareSummery";
            try
            {
                this._dbConnection.ConnectDatabase();
                this._dbConnection.ActiveStoredProcedure();
                this._dbConnection.AddParameter("@Cust_Code", SqlDbType.VarChar, code);
                dt = this._dbConnection.ExecuteProQuery(Query);
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

        public DataTable GetIpoHoldersInfo(string _code, string _boid)
        {
            DataTable dt = new DataTable();
            string query = @"SBP_IPOAccountHolderInformation";
            try
            {
                this._dbConnection.ConnectDatabase();
                this._dbConnection.ActiveStoredProcedure();
                this._dbConnection.AddParameter("@Cust_Code", SqlDbType.VarChar, _code);
                //this._dbConnection.AddParameter("@bo_id", SqlDbType.VarChar, _boid);
                dt = this._dbConnection.ExecuteProQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public DataTable IpoAccountinfo(string code)
        {
            DataTable dt = new DataTable();
            string query = @"SBP_IPOAccountInformation";
            try
            {
                this._dbConnection.ConnectDatabase();
                this._dbConnection.ActiveStoredProcedure();
                this._dbConnection.AddParameter("@Cust_Code", SqlDbType.VarChar, code);
                dt=this._dbConnection.ExecuteProQuery(query);
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
