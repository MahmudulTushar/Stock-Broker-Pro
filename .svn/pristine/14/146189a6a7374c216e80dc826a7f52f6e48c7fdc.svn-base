using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using System.Data;
using System.Data.SqlClient;

namespace BusinessAccessLayer.BAL
{
   public class Client_Account_Status_Report_DSE_24_12BAL
    {
        private DbConnection _dbconnection;

        public Client_Account_Status_Report_DSE_24_12BAL()
        {
            this._dbconnection = new DbConnection();
        }

        public DataTable Client_Account_Status(DateTime _tradeDate, string _custCode, string _nthNumber, string _branchName)
        {
            DataTable dt = new DataTable();
            try
            {
               // string query = @"rptClient_Account_Status_Report_DSE_24_12";
                string query = @"exec rptClient_Account_Status_Report_DSE_24_12 '"+_tradeDate.ToShortDateString()+"','"+_custCode+"','"+_nthNumber+"','"+_branchName+"'";
                this._dbconnection.ConnectDatabase();
                //this._dbconnection.ActiveStoredProcedure();
                //this._dbconnection.AddParameter("@Trade_Date", SqlDbType.DateTime, _tradeDate);
                //this._dbconnection.AddParameter("@Cust_Code", SqlDbType.VarChar, _custCode);
                //this._dbconnection.AddParameter("@n", SqlDbType.VarChar, _nthNumber);
                //this._dbconnection.AddParameter("@Branch_Name", SqlDbType.VarChar, _branchName);
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

        public DataTable GetbranchName()
        {
            DataTable dt = new DataTable();
            try
            {
                string query = @"select 'All' as [Branch_Name] 
                                union all
                                select Branch_Name from SBP_Broker_Branch";
                this._dbconnection.ConnectDatabase();
                dt=this._dbconnection.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
    }
}
