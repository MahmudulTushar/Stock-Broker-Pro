using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Odbc;
using System.Data.OleDb;
using DataAccessLayer;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;


namespace BusinessAccessLayer.BAL
{
    public class Web2014DataImportBAL
    {
        private DbConnection _dbConnection;
        MySqlConnection Webconnection;
        MySqlTransaction WebTransaction;

        string mySqlConnection = //"DRIVER={MySQL ODBC 3.51 Driver};" +

        //New Pattern
        //@"Server=cloud7.eicra.com;" +
        //"Port=3306;" +
        //"Database=ksclbdco_ks;" +
        //"User Id=ksclbdco;" +
        //"Password=16Dec08;" +
        //"Allow Zero Datetime=false;" +
        //"Convert Zero Datetime=true;";

//          @"server= 213.171.200.85;
//            userid=ksclbdco_dbuser;
//            Database=ksclbdco_ks;
//            password=K$clbd12345;
//            database=ksclbdco_ks;";

        @"server= 148.72.232.146;
            userid=ksclbdco;
            Database=ksclbdco_ks;
            password=KoNcvt%hi2Upvj;
            database=ksclbdco_ks;";

       

        public Web2014DataImportBAL()
        {
            _dbConnection = new DbConnection();
            Webconnection = new MySqlConnection(mySqlConnection);
            WebTransaction = null;
        }

        public void Connect_SBP()
        {
            _dbConnection.ConnectDatabase();
            _dbConnection.StartTransaction();
        }
        
        public void Connect_Web()
        {
            Webconnection.Open();
            WebTransaction = Webconnection.BeginTransaction();
        }
        
        public void Connect_WithoutTransaction_SBP()
        {
            _dbConnection.ConnectDatabase();
            // _dbConnection.StartTransaction();
        }
        
        public void CloseConnection_SBP()
        {
            _dbConnection.ConnectDatabase();
        }
        
        public void CloseConnection_Web()
        {
            Webconnection.Close();
            WebTransaction = null;
        }


        public void Commit_SBP()
        {
            _dbConnection.Commit();

        }
        public void Commit_Web()
        {
            WebTransaction.Commit();
        }

        public void Rollback_SBP()
        {
            _dbConnection.Rollback();

        }
        public void Rollback_Web()
        {
            WebTransaction.Rollback();
        }

        public void Connect_SMS()
        {
            _dbConnection.ConnectDatabase_SMSSender();
            _dbConnection.StartTransaction_SMSSender();
        }

        public void Connect_WithoutTransaction_SMS()
        {
            _dbConnection.ConnectDatabase_SMSSender();
            //_dbConnection.StartTransaction_SMSSender();
        }

        public void CloseConnection_SMS()
        {
            _dbConnection.CloseDatabase_SMSSender();
        }

        public void Commit_SMS()
        {
            _dbConnection.Commit_SMSSender();
        }

        public void Rollback_SMS()
        {
            _dbConnection.Rollback_SMSSender();
        }

        public SqlConnection GetConnection()
        {
            return _dbConnection.GetConnection();
        }

        public void SetConnection(SqlConnection con)
        {
            _dbConnection.SetConnection(con);
        }

        public SqlConnection GetConnection_SMS()
        {
            return _dbConnection.GetConnection_SMSSender();
        }

        public void SetConnection_SMS(SqlConnection con)
        {
            _dbConnection.SetConnection_SMSSender(con);
        }

        public SqlTransaction GetTransaction()
        {
            return _dbConnection.GetTransaction();
        }

        public void SetTransaction(SqlTransaction trans)
        {
            _dbConnection.SetTransaction(trans);
        }

        public SqlTransaction GetTransaction_SMS()
        {
            return _dbConnection.GetTransaction_SMSSender();
        }

        public void SetTransaction_SMS(SqlTransaction trans)
        {
            _dbConnection.SetTransaction_SMSSender(trans);
        }
                      
        // SBP Temp        
        public void DropWebSiteBackOfficeTemp()
        {
            MySqlConnection connection = new MySqlConnection(mySqlConnection);

            MySqlTransaction trans = null;
            try
            {
                string query = @"DROP TABLE IF EXISTS sbp_backoffice_temp;";
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                trans = connection.BeginTransaction();
                command.ExecuteNonQuery();
                trans.Commit();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public void CreateWebSiteBackOfficeTemp()
        {
            MySqlConnection connection = new MySqlConnection(mySqlConnection);

            MySqlTransaction trans = null;
            try
            {
                string query = @" CREATE TABLE sbp_backoffice_temp
                                (
                                           ref_1 varchar(200),
                                           ref_2 varchar(200),
                                           ref_3 varchar(200)
                                );";
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                trans = connection.BeginTransaction();
                command.ExecuteNonQuery();
                trans.Commit();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        // Create WebProcedure

        public void CreateWebSiteProcedure_GetNewUserQuery()
        {
            MySqlConnection connection = new MySqlConnection(mySqlConnection);

            MySqlTransaction trans = null;
            try
            {
                string query = @"
                                delimiter //


                                CREATE PROCEDURE GetNewUserQuery()

                                BEGIN

                                SELECT msg . * ,CURRENT_TIMESTAMP()
                                FROM message msg
                                LEFT OUTER JOIN sbp_backoffice_temp AS tmp ON msg.m_id = IFNULL( tmp.ref_1, 0 ) 
                                WHERE tmp.ref_1 IS NULL ;

                                END //

                                delimiter ;";
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                trans = connection.BeginTransaction();
                command.ExecuteNonQuery();
                trans.Commit();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public void DropWebSiteProcedure_GetNewUserQuery()
        {
            MySqlConnection connection = new MySqlConnection(mySqlConnection);

            MySqlTransaction trans = null;
            try
            {
                string query = @" DROP PROCEDURE GetNewUserQuery;";
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                trans = connection.BeginTransaction();
                command.ExecuteNonQuery();
                trans.Commit();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public void CreateWebSiteProcedure_GetAllServiceRegistration()
        {
            MySqlConnection connection = new MySqlConnection(mySqlConnection);

            MySqlTransaction trans = null;
            try
            {
                string query = @"
                                delimiter //


                                CREATE PROCEDURE GetAllServiceRegistration()

                                BEGIN

                                

                                END //

                                delimiter ;";
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                trans = connection.BeginTransaction();
                command.ExecuteNonQuery();
                trans.Commit();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public void DropWebSiteProcedure_GetAllServiceRegistration()
        {
            MySqlConnection connection = new MySqlConnection(mySqlConnection);

            MySqlTransaction trans = null;
            try
            {
                string query = @" DROP PROCEDURE GetAllServiceRegistration;";
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                trans = connection.BeginTransaction();
                command.ExecuteNonQuery();
                trans.Commit();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public void CreateWebSiteProcedure_GetNewWithdrawalRequest()
        {
            MySqlConnection connection = new MySqlConnection(mySqlConnection);

            MySqlTransaction trans = null;
            try
            {
                string query = @"delimiter //

                                CREATE PROCEDURE GetNewWithdrawalRequest()

                                BEGIN

                                SELECT req. *,CURRENT_TIMESTAMP()
                                FROM money_withdrawal_request AS req
                                LEFT OUTER JOIN sbp_backoffice_temp AS tmp ON req.request_id = IFNULL( tmp.ref_1, 0 )
                                WHERE tmp.ref_1 IS NULL;

                                END //

                                delimiter ;";
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                trans = connection.BeginTransaction();
                command.ExecuteNonQuery();
                trans.Commit();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public void DropWebSiteProcedure_GetNewWithdrawalRequest()
        {
            MySqlConnection connection = new MySqlConnection(mySqlConnection);

            MySqlTransaction trans = null;
            try
            {
                string query = @" DROP PROCEDURE GetNewWithdrawalRequest;";
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                trans = connection.BeginTransaction();
                command.ExecuteNonQuery();
                trans.Commit();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
 
        // Money Withdrawl Request

        public DataTable GetAllreadyImported_MoneyWithdrawalReq()
        {
            DataTable dt = new DataTable();

            string query;
            query = "";

            query = @"SELECT * 
                    FROM(
	                    Select OnlineOrderNo 
	                    From SBP_Payment_Posting_Request as req
	                    Where OnlineOrderNo Is Not Null
	                    Group By OnlineOrderNo
	                    UNION ALL
	                    Select OnlineOrderNo
	                    From SBP_Check_Requisition as rqs
	                    Where OnlineOrderNo Is Not Null
	                    Group By OnlineOrderNo
                        UNION ALL
                        SELECT [Request_Id] as [OnlineOrderNo]
                        FROM [Web2014_GetNewWithdrawalRequest_Temp]
                        GROUP BY [Request_Id]
                    )AS T
                    ORDER BY OnlineOrderNo
            ";

            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(query);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }

            return dt;
        }
        
        public void UploadAllreadyImported_MoneyWithdrawalReq_ToWeb(DataTable dt)
        {
            MySqlConnection connection = new MySqlConnection(mySqlConnection);
            MySqlTransaction trans = null;
            
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                
                connection.Open();
                trans = connection.BeginTransaction();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string query = "INSERT INTO sbp_backoffice_temp(ref_1) VALUES ('" +dt.Rows[i][0] +"')";
                    cmd.CommandText = query;        
                    cmd.ExecuteNonQuery();
                }
                trans.Commit();                
            }
            catch (Exception ex)
            {
                trans.Rollback();
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public DataTable GetNew_MoneyWithdrawalReq_FromWeb()
        {
            DataTable dt=new DataTable();
            MySqlConnection connection = new MySqlConnection(mySqlConnection);
            //MySqlTransaction trans = connection.BeginTransaction();
            try
            {
                string query = @"CALL GetNewWithdrawalRequest";
                MySqlDataAdapter da = new MySqlDataAdapter(query, connection);
                connection.Open();
                da.Fill(dt);
                //trans.Commit();
            }
            catch (Exception ex)
            {
                //trans.Rollback();
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return dt;
        }

        // User Registration
                
        public DataTable GetAllWebServiceRegistration_FromWeb()
        {
            DataTable dt = new DataTable();
            MySqlConnection connection = new MySqlConnection(mySqlConnection);
            //MySqlTransaction trans = connection.BeginTransaction();
            try
            {
                string query = @"CALL GetAllServiceRegistration";
                MySqlDataAdapter da = new MySqlDataAdapter(query, connection);
                connection.Open();
                da.Fill(dt);
                //trans.Commit();
            }
            catch (Exception ex)
            {
                //trans.Rollback();
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return dt;
        }

        public void Truncate_GetAllWebServiceRegistration_Temp()
        {
           string query = @"TRUNCATE TABLE Web2014_GetAllServiceRegistration_Temp";

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();
                _dbConnection.ExecuteNonQuery(query);
                
                _dbConnection.Commit();

            }
            catch (Exception exception)
            {
                _dbConnection.Rollback();
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
        } 
        

        // User Query

        public DataTable GetAllreadyImported_UserQuery()
        {
            DataTable dt = new DataTable();

            string query;
            query = "";

            query = @"  SELECT *
                        FROM(
                        Select Contact_Us_Id
                        From Web2014_GetNewUserQuery_Temp
                        Group By Contact_Us_Id
                        UNION ALL
                        SELECT [Contact_Us_Id]
                        FROM [Web2014_UserQuery]
                        GROUP BY [Contact_Us_Id]
                        ) AS T
                        Order By T.Contact_Us_Id
                    ";

            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(query);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }

            return dt;
        }

        public void UploadAllreadyImported_UserQuery_ToWeb(DataTable dt)
        {
            MySqlConnection connection = new MySqlConnection(mySqlConnection);
            MySqlTransaction trans = null;

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;

                connection.Open();
                trans = connection.BeginTransaction();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string query = "INSERT INTO sbp_backoffice_temp(ref_1) VALUES ('" + dt.Rows[i][0] + "')";
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                }
                trans.Commit();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public DataTable GetNew_UserQuery_FromWeb()
        {
            DataTable dt = new DataTable();
            MySqlConnection connection = new MySqlConnection(mySqlConnection);
            //MySqlTransaction trans = connection.BeginTransaction();
            try
            {
                string query = @"CALL GetNewUserQuery";
                MySqlDataAdapter da = new MySqlDataAdapter(query, connection);
                connection.Open();
                da.Fill(dt);
                //trans.Commit();
            }
            catch (Exception ex)
            {
                //trans.Rollback();
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return dt;
        }

        public void UpdateWebSyncFlagWeb_IPOApplicationMoneyTransRequest_UITransApplied(DataTable dt)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = Webconnection;

            try
            {  
                List<DataRow> ApplicationData = dt.Rows.Cast<DataRow>().Where(t => Convert.ToString(t["app_id"]) != string.Empty && Convert.ToString(t["app_id"]) != "0").ToList();
                List<DataRow> App_WithData = dt.Rows.Cast<DataRow>().Where(t => Convert.ToString(t["App_With_IPO_MoneyTransfer_Request_ID"]) != string.Empty && Convert.ToString(t["App_With_IPO_MoneyTransfer_Request_ID"]) != "0").ToList();
                List<DataRow> Parent_WithData = dt.Rows.Cast<DataRow>().Where(t => Convert.ToString(t["Parent_With_IPO_MoneyTransfer_Request_ID"]) != string.Empty && Convert.ToString(t["Parent_With_IPO_MoneyTransfer_Request_ID"]) != "0").ToList();
                List<DataRow> child_DepData = dt.Rows.Cast<DataRow>().Where(t => Convert.ToString(t["child_Dep_IPO_MoneyTransfer_Request_ID"]) != string.Empty && Convert.ToString(t["child_Dep_IPO_MoneyTransfer_Request_ID"]) != "0").ToList();
                List<DataRow> FreeTrnsData = dt.Rows.Cast<DataRow>().Where(t => Convert.ToString(t["FreeTrns_IPO_MoneyTransfer_Request_ID"]) != string.Empty && Convert.ToString(t["FreeTrns_IPO_MoneyTransfer_Request_ID"]) != "0").ToList();
               
                foreach (DataRow dr in ApplicationData)
                {
                    string query = "UPDATE ipo_application SET SBPSyncFlag=1 WHERE id=" + dr["app_id"] + ";";
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                }
                foreach (DataRow dr in App_WithData)
                {
                    string query = "UPDATE ipo_moneytransfer_request SET SBPSyncFlag=1 WHERE IPO_MoneyTransfer_Request_ID=" + dr["App_With_IPO_MoneyTransfer_Request_ID"] + ";";
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                }
                foreach (DataRow dr in Parent_WithData)
                {
                    string query = "UPDATE ipo_moneytransfer_request SET SBPSyncFlag=1 WHERE IPO_MoneyTransfer_Request_ID=" + dr["Parent_With_IPO_MoneyTransfer_Request_ID"] + ";";
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                }
                foreach (DataRow dr in child_DepData)
                {
                    string query = "UPDATE ipo_moneytransfer_request SET SBPSyncFlag=1 WHERE IPO_MoneyTransfer_Request_ID=" + dr["child_Dep_IPO_MoneyTransfer_Request_ID"] + ";";
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                }
                foreach (DataRow dr in FreeTrnsData)
                {
                    string query = "UPDATE ipo_moneytransfer_request SET SBPSyncFlag=1 WHERE IPO_MoneyTransfer_Request_ID=" + dr["FreeTrns_IPO_MoneyTransfer_Request_ID"] + ";";
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
               
                throw new Exception(ex.Message);
            }
        }

        public DataTable GetDataWeb_IPOApplicationMoneyTransRequest_UITransApplied()
        {
            DataTable dt = new DataTable();
            //MySqlConnection connection = new MySqlConnection(mySqlConnection);
            //MySqlTransaction trans = connection.BeginTransaction();

            try
            {
                string query = @"CALL GetNewIPOApplicationAndMoneyTransactionRequest";
                MySqlDataAdapter da = new MySqlDataAdapter(query, Webconnection);
                //connection.Open();
              
                da.Fill(dt);
                //trans.Commit();
            }
            catch (Exception ex)
            {
                //trans.Rollback();
                throw new Exception(ex.Message);
            }
            finally
            {
                //connection.Close();
            }
            return dt;
        }

        //Bulk Save
        
        public void Save_ToTemp(DataTable dt, string tableName)
        {
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.BulkCopy(dt, tableName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
               {
                _dbConnection.CloseDatabase();
            }
        }

        public void InsertData_WebReceiveAll_UITransApplied(DataTable dt)
        {
            try
            {
                
                foreach(DataRow dr in dt.Rows)
                {
                    string query = @"INSERT INTO [dbo].[tbl_Web_ReceiveAll]
                           ([app_id]
                           ,[app_Serial_No]
                           ,[app_IPO_Session_ID]
                           ,[app_IPOSession_Name]
                           ,[app_Applied_Company]
                           ,[app_No_Of_Share]
                           ,[app_Amount]
                           ,[app_Total_Share_Value]
                           ,[app_Premium]
                           ,[app_TotalAmount]
                           ,[app_Fine_Amount]
                           ,[app_Cust_Code]
                           ,[app_BO_ID]
                           ,[app_Refund_Option]
                           ,[app_Remarks]
                           ,[app_Application_Date]
                           ,[app_Application_Satus]
                           ,[app_Action_Description]
                           ,[app_Action_Date]
                           ,[app_TimeStamp]
                           ,[App_With_IPO_MoneyTransfer_Request_ID]
                           ,[App_With_Cust_ID]
                           ,[App_With_Received_Date]
                           ,[App_With_Amount]
                           ,[App_With_TimeStamp]
                           ,[Parent_With_IPO_MoneyTransfer_Request_ID]
                           ,[Parent_With_Cust_ID]
                           ,[Parent_With_Received_Date]
                           ,[Parent_With_Amount]
                           ,[Parent_With_TimeStamp]
                           ,[Trade_With_Request_ID]
                           ,[Trade_With_Cust_ID]
                           ,[Trade_With_Received_Date]
                           ,[Trade_With_Amount]
                           ,[Trade_With_TimeStamp]
                           ,[child_Dep_IPO_MoneyTransfer_Request_ID]
                           ,[child_Dep_Cust_ID]
                           ,[child_Dep_Received_Date]
                           ,[child_Dep_Amount]
                           ,[child_Dep_TimeStamp]
                           ,[FreeTrns_IPO_MoneyTransfer_Request_ID]
                           ,[FreeTrns_Cust_ID]
                           ,[FreeTrns_Deposit_Withdraw]
                           ,[FreeTrns_TransactionType] 
                           ,[FreeTrns_Received_Date]
                           ,[FreeTrns_Amount]
                           ,[FreeTrns_TimeStamp]
                           )
                     VALUES
                           (
                            " + dr["app_id"]+@"
                           ,"+dr["app_Serial_No"]+@"
                           ,"+dr["app_IPO_Session_ID"]+@"
                           ,'"+Convert.ToString(dr["app_IPOSession_Name"])+@"'
                           ,'"+Convert.ToString(dr["app_Applied_Company"])+@"'
                           ,"+dr["app_No_Of_Share"]+@"
                           ,"+dr["app_Amount"]+@"
                           ,"+dr["app_Total_Share_Value"]+@"
                           ,"+dr["app_Premium"]+@"
                           ,"+dr["app_TotalAmount"]+@"
                           ,"+dr["app_Fine_Amount"]+@"
                           ,'"+Convert.ToString(dr["app_Cust_Code"])+@"'
                           ,'"+Convert.ToString(dr["app_BO_ID"])+@"'
                           ,"+dr["app_Refund_Option"]+@"
                           ,'"+dr["app_Remarks"]+@"'
                           ," +((dr["app_Application_Date"].ToString().Trim() == "01-Jan-0001 12:00:00 AM") || (dr["app_Application_Date"].ToString().Trim()==string.Empty) ? "NULL" : "'"+dr["app_Application_Date"].ToString()+"'") + @"
                           ," + dr["app_Application_Satus"] + @"
                           ,'" + dr["app_Action_Description"] + @"'
                           ," + ((dr["app_Action_Date"].ToString().Trim() == "01-Jan-0001 12:00:00 AM") || (dr["app_Action_Date"].ToString().Trim() == string.Empty) ? "NULL" : "'" + dr["app_Action_Date"].ToString() + "'") + @"
                           ," + ((dr["app_TimeStamp"].ToString().Trim() == "01-Jan-0001 12:00:00 AM") || (dr["app_TimeStamp"].ToString().Trim() == string.Empty) ? "NULL" : "'" + dr["app_TimeStamp"].ToString() + "'") + @"
                           ," + dr["App_With_IPO_MoneyTransfer_Request_ID"] + @"
                           ,'" + Convert.ToString(dr["App_With_Cust_ID"]) + @"'
                           ," + ((dr["App_With_Received_Date"].ToString().Trim() == "01-Jan-0001 12:00:00 AM") || (dr["App_With_Received_Date"].ToString().Trim() == string.Empty) ? "NULL" : "'" + dr["App_With_Received_Date"].ToString() + "'") + @"
                           ," + dr["App_With_Amount"] + @"
                           ," + ((dr["App_With_TimeStamp"].ToString().Trim() == "01-Jan-0001 12:00:00 AM") || (dr["App_With_TimeStamp"].ToString().Trim() == string.Empty) ? "NULL" : "'" + dr["App_With_TimeStamp"].ToString() + "'") + @"
                           ," + dr["Parent_With_IPO_MoneyTransfer_Request_ID"] + @"
                           ,'" + Convert.ToString(dr["Parent_With_Cust_ID"]) + @"'
                           ," + ((dr["Parent_With_Received_Date"].ToString().Trim() == "01-Jan-0001 12:00:00 AM") || (dr["Parent_With_Received_Date"].ToString().Trim() == string.Empty) ? "NULL" : "'" + dr["Parent_With_Received_Date"].ToString() + "'") + @"
                           ," + dr["Parent_With_Amount"] + @"
                           ," + ((dr["Parent_With_TimeStamp"].ToString().Trim() == "01-Jan-0001 12:00:00 AM") || (dr["Parent_With_TimeStamp"].ToString().Trim() == string.Empty) ? "NULL" : "'" + dr["Parent_With_TimeStamp"].ToString() + "'") + @"
                           
                           ," + dr["Trade_With_Request_ID"] + @"
                           ,'" + Convert.ToString(dr["Trade_With_Cust_ID"]) + @"'
                           ," + ((dr["Trade_With_Received_Date"].ToString().Trim() == "01-Jan-0001 12:00:00 AM") || (dr["Trade_With_Received_Date"].ToString().Trim() == string.Empty) ? "NULL" : "'" + dr["Trade_With_Received_Date"].ToString() + "'") + @"
                           ," + dr["Trade_With_Amount"] + @"
                           ," + ((dr["Trade_With_TimeStamp"].ToString().Trim() == "01-Jan-0001 12:00:00 AM") || (dr["Trade_With_TimeStamp"].ToString().Trim() == string.Empty) ? "NULL" : "'" + dr["Trade_With_TimeStamp"].ToString() + "'") + @"  

                           ," + dr["child_Dep_IPO_MoneyTransfer_Request_ID"] + @"
                           ,'" + Convert.ToString(dr["child_Dep_Cust_ID"]) + @"'
                           ," + ((dr["child_Dep_Received_Date"].ToString().Trim() == "01-Jan-0001 12:00:00 AM") || (dr["child_Dep_Received_Date"].ToString().Trim() == string.Empty) ? "NULL" : "'" + dr["child_Dep_Received_Date"].ToString() + "'") + @"
                           ," + dr["child_Dep_Amount"] + @"
                           ," + ((dr["child_Dep_TimeStamp"].ToString().Trim() == "01-Jan-0001 12:00:00 AM") || (dr["child_Dep_TimeStamp"].ToString().Trim() == string.Empty) ? "NULL" : "'" + dr["child_Dep_TimeStamp"].ToString() + "'") + @"
                           ," + dr["FreeTrns_IPO_MoneyTransfer_Request_ID"] + @"
                           ,'" + Convert.ToString(dr["FreeTrns_Cust_ID"]) + @"'
                           ,'" + Convert.ToString(dr["FreeTrns_Deposit_Withdraw"]) + @"'
                           ,'" + Convert.ToString(dr["FreeTrns_TransactionType"]) + @"'
                           ," + ((dr["FreeTrns_Received_Date"].ToString().Trim() == "01-Jan-0001 12:00:00 AM") || (dr["FreeTrns_Received_Date"].ToString().Trim() == string.Empty) ? "NULL" : "'" + dr["FreeTrns_Received_Date"].ToString() + "'") + @"
                           ," + dr["FreeTrns_Amount"] + @"
                           ," + ((dr["FreeTrns_TimeStamp"].ToString().Trim() == "01-Jan-0001 12:00:00 AM") || (dr["FreeTrns_TimeStamp"].ToString().Trim() == string.Empty) ? "NULL" : "'" + dr["FreeTrns_TimeStamp"].ToString() + "'") + @"
                           ) 

                ";
                    _dbConnection.ExecuteNonQuery_SMSSender(query);
                }
                
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
            
        }
        public void InsertData_WebRequest_UITransApplied()
        {
            //string queryString = "SELECT Code_No,Comp_Name,Comp_Short_Code,(SELECT Comp_Category FROM SBP_Comp_Category WHERE Comp_Cat_ID=SBP_Company.Comp_Cat_ID),Face_Value,Market_Lot,Share_Type FROM SBP_Company;";
            string queryString = string.Empty;
            try
            {
                queryString = @"INSERT INTO [tbl_Web_Request]
                        ( 
                             [CompanyShortName]
                              ,[Cust_Code]
                              ,[PaymentType]
                              ,[RefundType]
                              ,[OrderFrom]
                              ,[ReferenceNumber]
                              ,[ReceiveID]
                              ,[app_id]
                              ,[App_With_IPO_MoneyTransfer_Request_ID]
                              ,[Parent_With_IPO_MoneyTransfer_Request_ID]
                              ,[Trade_With_IPO_MoneyTransfer_Request_ID]   
                              ,[child_Dep_IPO_MoneyTransfer_Request_ID]
                              ,[Child_Dep_Amount]
                              ,[FreeTrns_IPO_MoneyTransfer_Request_ID]
                              ,[FreeTrns_Amount]
                              ,[FreeTrns_Deposit_Withdraw]
                              ,[FreeTrns_TransactionType]  
                              ,[DateTime]
                              ,[Remarks]
                              ,[Status]
                        )
                        SELECT
                                (Select t.Company_Short_Code From tbl_IPO_SessionforCompanyInfo as t Where t.IPO_SessionID=web.app_IPO_Session_ID)
                                ,(
                                CASE 
                                WHEN ISNULL(web.[app_Cust_Code],'')<>'' THEN web.[app_Cust_Code] 
                                WHEN ISNULL(web.[FreeTrns_Cust_ID],'')<>'' THEN web.[FreeTrns_Cust_ID]
                                WHEN ISNULL(web.[Trade_With_Cust_ID],'')<>'' AND ISNULL(web.[child_Dep_Cust_ID],'')<>''  THEN web.[child_Dep_Cust_ID]
                                END 
                                ) AS Cust_Code
                                ,(
                                CASE 
                                WHEN ISNULL(web.[FreeTrns_IPO_MoneyTransfer_Request_ID],0)<>0 THEN ISNULL(web.FreeTrns_TransactionType,'')
                                WHEN 
                                    ISNULL(web.[Trade_With_Request_ID],0)<>0 
                                    AND ISNULL(web.child_Dep_IPO_MoneyTransfer_Request_ID,0)<>0
                                    AND ISNULL([Trade_With_Cust_ID],'')=ISNULL([child_Dep_Cust_ID],'')				                        
                                    AND ISNULL(web.[Parent_With_IPO_MoneyTransfer_Request_ID],0)=0
                                    AND ISNULL(web.[App_With_IPO_MoneyTransfer_Request_ID],0)=0  
                                    AND ISNULL(web.[app_id],0)=0    
                                THEN 'pTrade'
                                WHEN 
                                    ISNULL(web.child_Dep_IPO_MoneyTransfer_Request_ID,0)<>0 
                                    AND ISNULL(web.[Parent_With_IPO_MoneyTransfer_Request_ID],0)<>0  
                                    AND ISNULL(web.[App_With_IPO_MoneyTransfer_Request_ID],0)<>0
                                    AND ISNULL(web.[app_id],0)<>0
                                    AND ISNULL(web.[Parent_With_Cust_ID],0)<>ISNULL(web.App_With_Cust_ID,0)
                                THEN 'pmIPO'
                                WHEN 
                                    ISNULL(web.child_Dep_IPO_MoneyTransfer_Request_ID,0)<>0 
                                    AND ISNULL(web.[Parent_With_IPO_MoneyTransfer_Request_ID],0)<>0  
                                    AND ISNULL(web.[App_With_IPO_MoneyTransfer_Request_ID],0)<>0
                                    AND ISNULL(web.[app_id],0)<>0
                                    AND ISNULL(web.[Parent_With_Cust_ID],0)=ISNULL(web.App_With_Cust_ID,0)
                                THEN 'pIPO'
                                WHEN 
                                    ISNULL(web.child_Dep_IPO_MoneyTransfer_Request_ID,0)=0 
                                    AND ISNULL(web.[Parent_With_IPO_MoneyTransfer_Request_ID],0)=0  
                                    AND ISNULL(web.[App_With_IPO_MoneyTransfer_Request_ID],0)<>0
                                    AND ISNULL(web.[app_id],0)<>0
                                THEN 'pIPO'
                                END
                                ) AS PaymentType
                                ,(
                                CASE 
                                WHEN ISNULL(web.[app_id],0)<>0 AND web.[app_Refund_Option]=0 THEN 'rEft'
                                WHEN ISNULL(web.[app_id],0)<>0 AND web.[app_Refund_Option]=1 THEN 'rmIPO'
                                ELSE ''
                                END
                                ) AS RefundType
                                ,'' AS [OrderFrom]
                                ,web.[Parent_With_Cust_ID] as ReferenceNumber
                                ,web.ID AS ReceiveID
                                ,ISNULL(web.[app_id],0) AS app_id
                                ,ISNULL(web.[App_With_IPO_MoneyTransfer_Request_ID],0) as [App_With_IPO_MoneyTransfer_Request_ID]
                                ,ISNULL(web.[Parent_With_IPO_MoneyTransfer_Request_ID],0) as [Parent_With_IPO_MoneyTransfer_Request_ID]
                                ,ISNULL(web.[Trade_With_Request_ID],0) as Trade_With_Request_ID
                                ,ISNULL(web.[child_Dep_IPO_MoneyTransfer_Request_ID],0) as [child_Dep_IPO_MoneyTransfer_Request_ID]
                                ,ISNULL(web.[Child_Dep_Amount],0) AS [Child_Dep_Amount]
                                ,ISNULL(web.[FreeTrns_IPO_MoneyTransfer_Request_ID],0) as [FreeTrns_IPO_MoneyTransfer_Request_ID]
                                ,ISNULL(web.[FreeTrns_Amount],0) as [FreeTrns_Amount]
                                ,ISNULL(web.[FreeTrns_Deposit_Withdraw],'') as [FreeTrns_Deposit_Withdraw]
                                ,ISNULL(web.[FreeTrns_TransactionType],'') as [FreeTrns_TransactionType]
                                ,web.[ProcessDate] as [DateTime]
                                ,'' AS [Remarks]
                                ,0 AS [Status]
                                FROM [tbl_Web_ReceiveAll] as web
                                WHERE web. [ID] NOT IN (Select distinct t.ReceiveID From [tbl_Web_Request] as t )
                                AND
                                (
                                ( ISNULL(web.[app_id],0)<>0 AND ISNULL(web.Parent_With_IPO_MoneyTransfer_Request_ID,0)<>0 AND web.App_With_Cust_ID<>web.Parent_With_Cust_ID )
                                OR
                                ( ISNULL(web.[app_id],0)<>0 AND ISNULL(web.Parent_With_IPO_MoneyTransfer_Request_ID,0)=0)
                                OR
                                ( ISNULL(web.[Trade_With_Request_ID],0)<>0 AND ISNULL(web.[child_Dep_IPO_MoneyTransfer_Request_ID],0)<>0)
                                OR
                                ( ISNULL(web.[FreeTrns_IPO_MoneyTransfer_Request_ID],0)<>0 )
                                )

                                UNION ALL

                                SELECT
                                (Select t.Company_Short_Code From tbl_IPO_SessionforCompanyInfo as t Where t.IPO_SessionID=web.app_IPO_Session_ID)
                                ,(
                                CASE 
                                WHEN ISNULL(web.[app_Cust_Code],'')<>'' THEN web.[app_Cust_Code] 
                                WHEN ISNULL(web.[FreeTrns_Cust_ID],'')<>'' THEN web.[FreeTrns_Cust_ID]
                                WHEN ISNULL(web.[Trade_With_Cust_ID],'')<>'' AND ISNULL(web.[child_Dep_Cust_ID],'')<>''  THEN web.[child_Dep_Cust_ID]
                                END 
                                ) AS Cust_Code
                                ,(
                                CASE 
                                WHEN ISNULL(web.[FreeTrns_IPO_MoneyTransfer_Request_ID],0)<>0 THEN 'pTrade'
                                WHEN 
                                    ISNULL(web.[Trade_With_Request_ID],0)<>0 
                                    AND ISNULL(web.child_Dep_IPO_MoneyTransfer_Request_ID,0)<>0
                                    AND ISNULL([Trade_With_Cust_ID],'')=ISNULL([child_Dep_Cust_ID],'')				                        
                                    AND ISNULL(web.[Parent_With_IPO_MoneyTransfer_Request_ID],0)=0
                                    AND ISNULL(web.[App_With_IPO_MoneyTransfer_Request_ID],0)=0  
                                    AND ISNULL(web.[app_id],0)=0    
                                THEN 'pTrade'
                                WHEN 
                                    ISNULL(web.child_Dep_IPO_MoneyTransfer_Request_ID,0)<>0 
                                    AND ISNULL(web.[Parent_With_IPO_MoneyTransfer_Request_ID],0)<>0  
                                    AND ISNULL(web.[App_With_IPO_MoneyTransfer_Request_ID],0)<>0
                                    AND ISNULL(web.[app_id],0)<>0
                                    AND ISNULL(web.[Parent_With_Cust_ID],0)<>ISNULL(web.App_With_Cust_ID,0)
                                THEN 'pmIPO'
                                WHEN 
                                    ISNULL(web.child_Dep_IPO_MoneyTransfer_Request_ID,0)<>0 
                                    AND ISNULL(web.[Parent_With_IPO_MoneyTransfer_Request_ID],0)<>0  
                                    AND ISNULL(web.[App_With_IPO_MoneyTransfer_Request_ID],0)<>0
                                    AND ISNULL(web.[app_id],0)<>0
                                    AND ISNULL(web.[Parent_With_Cust_ID],0)=ISNULL(web.App_With_Cust_ID,0)
                                THEN 'pIPO'
                                WHEN 
                                    ISNULL(web.child_Dep_IPO_MoneyTransfer_Request_ID,0)=0 
                                    AND ISNULL(web.[Parent_With_IPO_MoneyTransfer_Request_ID],0)=0  
                                    AND ISNULL(web.[App_With_IPO_MoneyTransfer_Request_ID],0)<>0
                                    AND ISNULL(web.[app_id],0)<>0
                                THEN 'pIPO'
                                END
                                ) AS PaymentType
                                ,(
                                CASE 
                                WHEN ISNULL(web.[app_id],0)<>0 AND web.[app_Refund_Option]=0 THEN 'rEft'
                                WHEN ISNULL(web.[app_id],0)<>0 AND web.[app_Refund_Option]=1 THEN 'rmIPO'
                                ELSE ''
                                END
                                ) AS RefundType
                                ,'' AS [OrderFrom]
                                ,web.[Parent_With_Cust_ID] as ReferenceNumber
                                ,web.ID AS ReceiveID
                                ,web.[app_id] AS app_id
                                ,web.[App_With_IPO_MoneyTransfer_Request_ID] as [App_With_IPO_MoneyTransfer_Request_ID]
                                ,web.[Parent_With_IPO_MoneyTransfer_Request_ID] as [Parent_With_IPO_MoneyTransfer_Request_ID]
                                ,ISNULL(web.[Trade_With_Request_ID],0) as Trade_With_Request_ID
                                ,web.[child_Dep_IPO_MoneyTransfer_Request_ID] as [child_Dep_IPO_MoneyTransfer_Request_ID]
                                ,ISNULL(web.[Child_Dep_Amount],0) AS [Child_Dep_Amount]
                                ,web.[FreeTrns_IPO_MoneyTransfer_Request_ID] as [FreeTrns_IPO_MoneyTransfer_Request_ID]
                                ,web.[FreeTrns_Amount] as [FreeTrns_Amount]
                                ,web.[FreeTrns_Deposit_Withdraw] as [FreeTrns_Deposit_Withdraw]
                                ,web.[FreeTrns_TransactionType] as [FreeTrns_TransactionType]
                                ,web.[ProcessDate] as [DateTime]
                                ,'' AS [Remarks]
                                ,0 AS [Status]
                                FROM [tbl_Web_ReceiveAll] as web
                                WHERE web. [ID] NOT IN (Select distinct t.ReceiveID From [tbl_Web_Request] as t)
                                AND
                                (
                                ( ISNULL(web.[app_id],0)<>0 AND ISNULL(web.Parent_With_IPO_MoneyTransfer_Request_ID,0)<>0 AND web.App_With_Cust_ID=web.Parent_With_Cust_ID )	
                                )

                        ";
               _dbConnection.ExecuteNonQuery_SMSSender(queryString);
               
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
