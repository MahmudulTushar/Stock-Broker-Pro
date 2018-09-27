using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using System.Data;
using System.Data.SqlClient;

namespace BusinessAccessLayer.BAL
{
   public class Registration_Confirmation_Reports_DSE_21_4BAL
    {
        private DbConnection _dbConnection;
        public Registration_Confirmation_Reports_DSE_21_4BAL()
        {
            _dbConnection = new DbConnection();
        }
        
        public DataTable GetRegistrationConfirmationReportData(string Custcode ,string _boid,string _custName)
        {
            string t = GetBoid(Custcode, _custName);
            DataTable data = new DataTable();
            try
            {
                //string Query = @"rptBO_Registration_Confirmation_Report_DSE_21_4";
                string query = @"rptBO_Registration_Confirmation_Report_DSE_21_4 '"+Custcode+"','"+_boid+"','"+_custName+"'";
                _dbConnection.ConnectDatabase();
                //_dbConnection.ActiveStoredProcedure();
                //_dbConnection.AddParameter("@Investor_ID", SqlDbType.VarChar, Custcode);
                //_dbConnection.AddParameter("@BO_ID", SqlDbType.VarChar, _boid);
                //_dbConnection.AddParameter("@Investor_Name", SqlDbType.VarChar, _custName);
                data = _dbConnection.ExecuteProByText(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return data;
        }

        #region Unusable Method
        public DataTable GetCustomerInfo(string _custCode, string _boid, string _custName)
        {
            string query="";
            DataTable data = new DataTable();
            if (_custCode != string.Empty)
            {
                  query = @"select Cust_Code from SBP_BI_Customers where Cust_Code= '" + _custCode + "'";
            }
            else if (_boid != string.Empty)
            {
                query = @"select BO_ID from SBP_BI_Customers where BO_ID= '" + _boid + "'";
            }
            else if (_custName != string.Empty)
            {
                query = @"select Cust_Name from SBP_BI_Customers where Cust_Name like '" + '%' + _custName + '%' + "'";
            }
            try
            {
                //string Query = @"rptGetCustCode_BOID_CustName";
                //
                //_dbConnection.ActiveStoredProcedure();
                //_dbConnection.AddParameter("@Investor_ID", SqlDbType.VarChar, _custCode);
                //_dbConnection.AddParameter("@BO_ID", SqlDbType.VarChar, _boid);
                //_dbConnection.AddParameter("@Investor_Name", SqlDbType.VarChar, _custName);
                //data = _dbConnection.ExecuteProQuery(Query);
                _dbConnection.ConnectDatabase();
                data = _dbConnection.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return data;
        }
        #endregion

       

        public string GetBoid(string custcode,string cust_name)
        {
            string _bo_id = "";
            string query = "";
            if (custcode != null)
            {
                  query = @"select BO_ID from SBP_BI_Customers where Cust_Code= '" + custcode + "'";
            }
            else if (cust_name != null)
            {
                query = @"select BO_ID from SBP_BI_Customers where Cust_Name= '" + cust_name + "'";
            }
            DataTable dt = new DataTable();
            try
            {
                this._dbConnection.ConnectDatabase();
                dt=this._dbConnection.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            if (dt.Rows.Count > 0)
            {
                _bo_id = dt.Rows[0][0].ToString();
            }
            return _bo_id;
        }
        public string GetCustName(string custcode,string bo_id)
        {
            string _bo_id = "";
            string query="";
            if (custcode != null||custcode!=string.Empty)
            {
                query = @"select Cust_Name from SBP_BI_Customers where Cust_Code= '" + custcode + "'";
            }
            if (bo_id != null||bo_id!=string.Empty)
            {
                query = @"select Cust_Name from SBP_BI_Customers where BO_ID= '" + bo_id + "'";
            }
                DataTable dt = new DataTable();
            try
            {
                this._dbConnection.ConnectDatabase();
                dt = this._dbConnection.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            if (dt.Rows.Count > 0)
            {
                _bo_id = dt.Rows[0][0].ToString();
            }
            return _bo_id;
        }

        public string GetCustCode(string cust_name, string bo_id)
        {
            string _bo_id = "";
            string query = "";
            if (cust_name != null||cust_name!=string.Empty)
            {
                query = @"select Cust_Code from SBP_BI_Customers where Cust_Name= '" + cust_name + "'";
            }
           else if (bo_id != null||bo_id!=string.Empty)
            {
                query = @"select Cust_Code from SBP_BI_Customers where BO_ID= '" + bo_id + "'";
            }
            DataTable dt = new DataTable();
            try
            {
                this._dbConnection.ConnectDatabase();
                dt = this._dbConnection.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            if (dt.Rows.Count > 0)
            {
                _bo_id = dt.Rows[0][0].ToString();
            }
            return _bo_id;
        }
        
    }
}
