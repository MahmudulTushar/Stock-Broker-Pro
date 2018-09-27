using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using System.Data;

namespace BusinessAccessLayer.BAL
{
   public class IPOApplicationForPublicIssueBAL
    {
        private DbConnection _dbconnection;
        public IPOApplicationForPublicIssueBAL()
        {
            this._dbconnection = new DbConnection();
        }

        public DataTable GetPublicApplicationIssue(string _code, string Company)
        {
            DataTable dt = new DataTable();
            string query = @"IpoApplicationForPublicIssue";
            try
            {
                this._dbconnection.ConnectDatabase();
                this._dbconnection.ActiveStoredProcedure();
                this._dbconnection.AddParameter("@Cust_Code", SqlDbType.VarChar, _code);
                this._dbconnection.AddParameter("@Company_Name", SqlDbType.VarChar, Company);
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
        public DataTable GetCustCode()
        {
            DataTable dt = new DataTable();
            string query = @"select distinct Cust_Code from dbo.SBP_IPO_Application_BasicInfo ";
            try
            {
                this._dbconnection.ConnectDatabase();
                this._dbconnection.ActiveStoredProcedure();
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
    }
}
