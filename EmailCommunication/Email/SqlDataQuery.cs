using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using System.Data;
using System.Data.SqlClient;

namespace ElectronicCommunication.Email
{
   public class SqlDataQuery
    {
        private DbConnection _dbConnection;

        public void ConnectCallCenterDb()
        {
            _dbConnection.ConnectDatabase_SMSSender();
            _dbConnection.StartTransaction_SMSSender();
        }

        public void RollBackCallCenterDb()
        {
            _dbConnection.Rollback_SMSSender();
            
        }

        public void CommitCallCenterDb()
        {
            _dbConnection.Commit_SMSSender();
        }

        public void CloseCallCenterDB()
        {
            _dbConnection.CloseDatabase_SMSSender();
        }


        public SqlDataQuery()
        {
            _dbConnection = new DbConnection();
        }

        public string GetPaymentPostingCustCodeFromCustCode(string CustCode)
        {
            try
            {
                string result = "";
                DataTable dt = new DataTable();
                string Query = "Select * from dbo.SBP_Payment_Posting_Request  Where Payment_ID='"+CustCode+"'";
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(Query);  
                foreach (DataRow dr in dt.Rows)
                {
                    result = dr[1].ToString();
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public void Truncate_Table_IPO_Conformation_Email(string Ipo_session)
        {
            string query = string.Empty;
            query = "Delete tbl_IPOConfirmation_Email Where IPO_Session_Name='" + Ipo_session + "'";
            _dbConnection.ConnectDatabase_SMSSender();
            _dbConnection.ExecuteNonQuery_SMSSender(query);
            _dbConnection.CloseDatabase_SMSSender();
        }


        public void IPOApproveDataInsert(string CustCode, string Email,double Amount, String IPOSessionID, String IPOSessionName ,String CompanyName, String EmailType , String FailurReason,string Status,string IPOStatus,string IPOApplicationID,string MoneyTransName , String RefundType,string EmailSerialNumber)
        {
            try
            {
               
                string sSQL = @" INSERT INTO dbo.tbl_IPOConfirmation_Email  (Cust_Code,Email,Amount,IPO_Session_ID,IPO_Session_Name,Company_Name,MoneyTrans_TypeName,Refund_Name,EmailType,FailureReason,Status,IPO_Status,IPOApplicationID,DelivaryDate,Email_SerialNumber,ProcessDate)
                VAlUES ('" + CustCode + "','" + Email + "'," + Amount + ",'" + IPOSessionID + "','" + IPOSessionName + "','" + CompanyName + "','" + MoneyTransName + "','" + RefundType + "','" + EmailType + "','" + null + "',0,'" + IPOStatus + "','" + IPOApplicationID + "',NULL,'" + EmailSerialNumber + "','"+System.DateTime.Now.ToShortDateString()+"')";
                //_dbConnection.ConnectDatabase_SMSSender();
                //_dbConnection.TimeoutPeriod = 0;
                _dbConnection.ExecuteNonQuery_SMSSender(sSQL);
                
            }
            catch (Exception exc)
            {
                throw exc;
            }
            finally
            {
                    //_dbConnection.CloseDatabase_SMSSender();
            }
        }


        public bool isExistValidation(string CustCode , string IPOSessionID, String IPOSessionName,string IPOApplication, string IPOStatus)
        {
            try
            {
                _dbConnection.ConnectDatabase_SMSSender();
                //string cnn = Email_Constant.CallCenter_ConnectionString;
                //SqlConnection aSqlConnection = new SqlConnection(cnn);
                //aSqlConnection.Open();
                //string sSQL;
                string sSQL = "Select * from tbl_IPOConfirmation_Email Where Cust_Code='" + CustCode + "'AND IPO_Session_ID='" + IPOSessionID + "'AND IPO_Session_Name='" + IPOSessionName + "' AND IPOApplicationID ='" + IPOApplication + "' AND IPO_Status='"+IPOStatus+"'";
                //SqlCommand Command = new SqlCommand(sSQL, aSqlConnection);
                //Command.CommandTimeout = 0;
                SqlDataReader reader = _dbConnection.ExecuteReader_SMSSender(sSQL);
                if (reader.Read())
                    return true;
                else
                    return false;
            }
            catch (SqlException SqlErr)
            {
                throw new Exception(SqlErr.Message);
            }
            catch (Exception Err)
            {
                throw new Exception(Err.Message);
            }
        }


        public string GetRegCustCodeFromCustCodeForEmail(string CustCode)
        {

            try
            {
                string result = "";
                DataTable dt = new DataTable();
                string Query = "Select Email from dbo.SBP_Service_Registration Where Cust_Code='" + CustCode + "' AND IPO_Confiramation_Email='1'";
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(Query);
                foreach (DataRow dr in dt.Rows)
                {
                    result = dr[0].ToString();
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }

        }


        public List<string> GetRegCustCodeFromParentChildCheakingForEmail(string CustCode)
        {

            try
            {
                List<string> Result = new List<string>();
       
                DataTable dt = new DataTable();
                string cnn = Email_Constant.CallCenter_ConnectionString;
                SqlConnection aSqlConnection = new SqlConnection(cnn);
                DataSet aDataset = new DataSet();
                SqlDataAdapter aSqldataadapter = new SqlDataAdapter();
                string Query = @"SELECT [Child_Code]
                              ,[Owner_CustCode]
                              ,[Owner_Name]
                              ,[Owner_Parent_Name]
                              ,[Owner_Mobile]
                              ,[Owner_Land]
                              ,[Owner_Email]
                        FROM [dbksclCallCenter].[dbo].[tbl_AccountGrouping_Info]
                        WHERE [Parent_Code]='"+ CustCode +@"'";
                aSqldataadapter.SelectCommand = new SqlCommand(Query, aSqlConnection);
                aSqldataadapter.Fill(aDataset);
                dt = aDataset.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    Result.Add(dr[0].ToString());
                }
                return Result;
            }
            catch (Exception)
            {
                throw;
            }

        }


        public string GetIPOEmailSender(string EmailID)
        {

            try
            {
                string result = "";
                DataTable dt = new DataTable();


                string Query = "Select EmailContent from dbo.tbl_IPOEmailServiceMessageStoreHouse Where EmailID='" + EmailID + "'";
                _dbConnection.ConnectDatabase();
                 dt = _dbConnection.ExecuteQuery(Query);             
               
                foreach (DataRow dr in dt.Rows)
                {
                    result = dr[0].ToString();
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public string GetParentCheck(string ChildCode)
        {

            try
            {
                string result = "";
                DataTable dt = new DataTable();                
                string cnn = Email_Constant.CallCenter_ConnectionString;
                SqlConnection aSqlConnection = new SqlConnection(cnn);
                DataSet aDataset = new DataSet();
                SqlDataAdapter aSqldataadapter = new SqlDataAdapter();
                string Query = "Select Parent_Code from dbo.tbl_AccountGrouping_Info Where Child_Code='" + ChildCode + "'";
                aSqldataadapter.SelectCommand = new SqlCommand(Query, aSqlConnection);
                aSqldataadapter.Fill(aDataset);
                dt = aDataset.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    result = dr[0].ToString();
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public string GetIPOCompanyName(string IPOSessionID)
        {

            try
            {
                string result = "";
                DataTable dt = new DataTable();
                string Query = @" Select SBP_IPO_Company_Info.Company_Name from dbo.SBP_IPO_Company_Info,
                                  dbo.SBP_IPO_Session 
                                  Where SBP_IPO_Company_Info.ID =  SBP_IPO_Session.IPO_Company_ID
                                  AND SBP_IPO_Session.IPO_Company_ID='" + IPOSessionID + "'";

                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(Query);  
                foreach (DataRow dr in dt.Rows)
                {
                    result = dr[0].ToString();
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public DataTable GetIPOSessionName()
        {
            string queryString;
            {
                queryString = @"Select *,M.ID as IPO_Session_ID,M.IPOSession_Name from dbo.SBP_IPO_Company_Info  AS t
                                    JOIN dbo.SBP_IPO_Session AS M ON
                                    t.ID = M.IPO_Company_ID";

            }
            DataTable data = new DataTable();

            try
            {
                _dbConnection.ConnectDatabase();
                data = _dbConnection.ExecuteQuery(queryString);
            }
            catch (Exception)
            {

                throw;
            }

            finally
            {
                _dbConnection.CloseDatabase();
            }

            return data;
        }

        public DataTable GetIPOApprove_RejectDegion(String SessionID, String CustCode)
        {
            DataTable result = new DataTable();
            string cnn = Email_Constant.CallCenter_ConnectionString;
            SqlConnection aSqlConnection = new SqlConnection(cnn);
            DataSet aDataset = new DataSet();
            SqlDataAdapter aSqldataadapter = new SqlDataAdapter();
            string Query = "Select COUNT(*)AS Count,MoneyTrans_TypeName,Refund_Name from dbo.tbl_IPOConfirmation_Email   Where Cust_Code IN(" + CustCode + ")    AND IPO_Session_ID ='" + SessionID + "' Group By MoneyTrans_TypeName,Refund_Name";

            aSqldataadapter.SelectCommand = new SqlCommand(Query, aSqlConnection);
            aSqldataadapter.Fill(aDataset);
            DataTable dt = new DataTable();

            dt = aDataset.Tables[0];
            result = dt;
            return result;
        }



        public string GetIPOEmailSubject(string EmailID)
        {

            try
            {
                string result = "";
                string cnn = Email_Constant.CallCenter_ConnectionString;
                SqlConnection aSqlConnection = new SqlConnection(cnn);
                DataSet aDataset = new DataSet();
                SqlDataAdapter aSqldataadapter = new SqlDataAdapter();
                string Query = "Select EmailSubjet from dbo.tbl_IPOEmailServiceMessageStoreHouse Where EmailID='" + EmailID + "'";

                aSqldataadapter.SelectCommand = new SqlCommand(Query, aSqlConnection);
                aSqldataadapter.Fill(aDataset);
                DataTable dt = new DataTable();

                dt = aDataset.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    result = dr[0].ToString();
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public string GetIPOAmount(string CustCode, String IPOSessionID)
        {

            try
            {
                string result = "";
                //string cnn = Email_Constant.CallCenter_ConnectionString;
                //SqlConnection aSqlConnection = new SqlConnection(cnn);
                //DataSet aDataset = new DataSet();
                //SqlDataAdapter aSqldataadapter = new SqlDataAdapter();
                DataTable dt = new DataTable();
                string Query = "Select Convert(decimal(28,2),ROUND((TotalAmount),2))  as TotalAmount from SBP_IPO_Application_BasicInfo Where Cust_Code='" + CustCode + "'  AND IPOSession_ID='" + IPOSessionID + "'";
                //aSqldataadapter.SelectCommand = new SqlCommand(Query, aSqlConnection);
                //aSqldataadapter.Fill(aDataset);
                //dt = aDataset.Tables[0];
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(Query);
                foreach (DataRow dr in dt.Rows)
                {
                    result = dr[0].ToString();
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Double GetIPOAmountForParentChlid(string CustCode, String IPOSessionID)
        {

            try
            {
                Double result = 0.00;
                DataTable dt = new DataTable();
                string Query = "Select Convert(decimal(28,2),ROUND((TotalAmount),2))  as TotalAmount from SBP_IPO_Application_BasicInfo Where Cust_Code='" + CustCode + "'  AND IPOSession_ID='" + IPOSessionID + "'";
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(Query);   
                

                
                foreach (DataRow dr in dt.Rows)
                {
                    result = Convert.ToDouble(dr[0]);
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public string GetIPOChildSystem(string CustCode, string IPOSessionID)
        {

            try
            {
                string result = "";
                string cnn = Email_Constant.CallCenter_ConnectionString;
                SqlConnection aSqlConnection = new SqlConnection(cnn);
                DataSet aDataset = new DataSet();
                SqlDataAdapter aSqldataadapter = new SqlDataAdapter();
                string Query = "Select IPO_Status from dbo.tbl_IPOConfirmation_Email Where Cust_Code='"+CustCode+"' AND IPO_Session_ID='"+IPOSessionID+"'";

                aSqldataadapter.SelectCommand = new SqlCommand(Query, aSqlConnection);
                aSqldataadapter.Fill(aDataset);
                DataTable dt = new DataTable();

                dt = aDataset.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    result = dr[0].ToString();
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }

        }




        public DataTable GetIPOParentChilddata(string CustCode, string IPOSessionID)
        {
            DataTable result = new DataTable();
            string cnn = Email_Constant.CallCenter_ConnectionString;
            SqlConnection aSqlConnection = new SqlConnection(cnn);
            DataSet aDataset = new DataSet();
            SqlDataAdapter aSqldataadapter = new SqlDataAdapter();
            string Query = "Select Cust_Code,MoneyTrans_TypeName,Refund_Name from dbo.tbl_IPOConfirmation_Email Where Cust_Code='" + CustCode + "' AND IPO_Session_ID='" + IPOSessionID + "'";

            aSqldataadapter.SelectCommand = new SqlCommand(Query, aSqlConnection);
            aSqldataadapter.Fill(aDataset);
            DataTable dt = new DataTable();

            dt = aDataset.Tables[0];
            result = dt;
            return result;
        }

        public string GetIPOChildsystemAndMoneyTransactiontype(string CustCode, string IPOSessionID)
        {

            try
            {
                string result = "";
                string cnn = Email_Constant.CallCenter_ConnectionString;
                SqlConnection aSqlConnection = new SqlConnection(cnn);
                DataSet aDataset = new DataSet();
                SqlDataAdapter aSqldataadapter = new SqlDataAdapter();
                string Query = "Select MoneyTrans_TypeName from dbo.tbl_IPOConfirmation_Email Where Cust_Code='" + CustCode + "' AND IPO_Session_ID='" + IPOSessionID + "'";

                aSqldataadapter.SelectCommand = new SqlCommand(Query, aSqlConnection);
                aSqldataadapter.Fill(aDataset);
                DataTable dt = new DataTable();

                dt = aDataset.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    result = dr[0].ToString();
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public string GetIPOChildSystemANDRefundtype(string CustCode, string IPOSessionID)
        {

            try
            {
                string result = "";
                string cnn = Email_Constant.CallCenter_ConnectionString;
                SqlConnection aSqlConnection = new SqlConnection(cnn);
                DataSet aDataset = new DataSet();
                SqlDataAdapter aSqldataadapter = new SqlDataAdapter();
                string Query = "Select Refund_Name from dbo.tbl_IPOConfirmation_Email Where Cust_Code='" + CustCode + "' AND IPO_Session_ID='" + IPOSessionID + "'";

                aSqldataadapter.SelectCommand = new SqlCommand(Query, aSqlConnection);
                aSqldataadapter.Fill(aDataset);
                DataTable dt = new DataTable();

                dt = aDataset.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    result = dr[0].ToString();
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public void UpdateIPOEmailConfiramation(string CustCode,string Status,string IPOSessionID)
        {
            try
            {
                string cnn = Email_Constant.CallCenter_ConnectionString;
                SqlConnection aSqlConnection = new SqlConnection(cnn);
                aSqlConnection.Open();
                string Query = "Update dbo.tbl_IPOConfirmation_Email SET Status='" + Status + "' , DelivaryDate ='" + System.DateTime.Now + "'  Where Cust_Code='" + CustCode + "' AND IPO_Session_ID ='"+IPOSessionID+"'";
                SqlCommand Command = new SqlCommand(Query, aSqlConnection);
                Command.CommandTimeout = 0;
                Command.ExecuteNonQuery(); 
            
            }
            catch (Exception)
            {
                throw;
            }

        }

        public void UpdateIPOEmailConfiramationForFailureReason(string CustCode, string ApplicationID, string Status,string Reason)
        {
            try
            {
                string cnn = Email_Constant.CallCenter_ConnectionString;
                SqlConnection aSqlConnection = new SqlConnection(cnn);
                aSqlConnection.Open();
                string Query = "Update dbo.tbl_IPOConfirmation_Email SET Status='" + Status + "' ,FailureReason='" + Reason + "', DelivaryDate ='" + System.DateTime.Now + "'  Where Cust_Code='" + CustCode + "' AND IPOApplicationID ='" + ApplicationID + "'";
                SqlCommand Command = new SqlCommand(Query, aSqlConnection);
                Command.CommandTimeout = 0;
                Command.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }

        }


        public string GetIPO_EmailType(string ID)
        {

            try
            {
                string result = "";
                //string cnn = Email_Constant.CallCenter_ConnectionString;
                //SqlConnection aSqlConnection = new SqlConnection(cnn);
                //DataSet aDataset = new DataSet();
                //SqlDataAdapter aSqldataadapter = new SqlDataAdapter();
                DataTable dt = new DataTable();
                string Query = "Select EmailTypeName from dbo.tbl_IPO_Email_Type Where ID='" + ID + "'";

                _dbConnection.ConnectDatabase_SMSSender();
                dt = _dbConnection.ExecuteQuery_SMSSender(Query); 
               

                //dt = aDataset.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    result = dr[0].ToString();
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }

        }




    }
}
