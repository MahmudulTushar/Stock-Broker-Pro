using System;
using System.Data;
using System.Data.SqlClient;
using BusinessAccessLayer.BO;
using DataAccessLayer;

namespace BusinessAccessLayer.BAL
{
    public class BrokerInfoBAL
    {

        private DbConnection _dbConnection;

        public BrokerInfoBAL()
        {
            _dbConnection = new DbConnection();
        }
        public DataTable GetBrokerInfo()
        {
            DataTable dataTable;
            dataTable = null;
            string queryString = "";
            queryString = "SELECT Name,BO_ID,Trade_ID,Exchange_Name,CDBL_Participant_ID,Open_Date,Logo_Image,Directors_Signature,Default_Signature FROM SBP_Broker_Info";
            try
            {
                _dbConnection.ConnectDatabase();
                dataTable = _dbConnection.ExecuteQuery(queryString);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dataTable;
        }
        //public DataTable GetIPoSession()
        //{
        //    DataTable dataTable;
        //    dataTable = null;
        //    string queryString = "";
        //    queryString = "SELECT ID, IPOSession_Name FROM  SBP_IPO_Session ORDER BY ID DESC ";
        //    try
        //    {
        //        _dbConnection.ConnectDatabase();
        //        dataTable = _dbConnection.ExecuteQuery(queryString);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        _dbConnection.CloseDatabase();
        //    }
        //    return dataTable;

        //}
        public DataTable GetBrokerBranchName()
        {
            DataTable dataTable;
            dataTable = null;
            string queryString = "";
            queryString = @"Select Branch_ID,Branch_Name
                            From dbo.SBP_Broker_Branch
                            UNION ALL
                            Select 0 as Branch_ID ,'ALL' as Branch_Name
                            ORDER BY Branch_ID";
            try
            {
                _dbConnection.ConnectDatabase();
                dataTable = _dbConnection.ExecuteQuery(queryString);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dataTable;
        }

      
        public void UpdateBrokerInfo(BrokerInfoBO brokerInfoBO, string oldName)
        {
            SqlConnection conn=new SqlConnection(DbConnectionBasic.ConnectionString);
            string queryString = "";
            queryString = "Update SBP_Broker_Info SET [Name]=@name,[BO_ID]=@boID,[Trade_ID]=@tradeID,[Exchange_Name]=@exchangeName,[CDBL_Participant_ID]=@CDBLParticipantID,[Open_Date]=@openDate Where [Name]=@oldName";
            SqlCommand command = new SqlCommand(queryString,conn);
            command.Parameters.Add(new SqlParameter("@name", (object)brokerInfoBO.Name));
            command.Parameters.Add(new SqlParameter("@boID", (object)brokerInfoBO.BOId));
            command.Parameters.Add(new SqlParameter("@tradeID", (object)brokerInfoBO.TradeId));
            command.Parameters.Add(new SqlParameter("@exchangeName", (object)brokerInfoBO.ExchangeName));
            command.Parameters.Add(new SqlParameter("@CDBLParticipantID", (object) brokerInfoBO.CdblParticipantId));
            command.Parameters.Add(new SqlParameter("@openDate", (object)brokerInfoBO.OpenDate));
            command.Parameters.Add(new SqlParameter("@oldName", (object) oldName));

            try
            {
               conn.Open();
               command.ExecuteNonQuery();
               conn.Close();
            }
            catch (Exception)
            {
               throw;
            }
        }

        public void UpdateLogoImage(BrokerInfoBO brokerInfoBo)
        {
            SqlConnection conn = new SqlConnection(DbConnectionBasic.ConnectionString);
            string queryString = "";
            queryString = "Update SBP_Broker_Info SET [Logo_Image]=@logoImage";
            SqlCommand command = new SqlCommand(queryString, conn);
            command.Parameters.Add(new SqlParameter("@logoImage", (object)brokerInfoBo.LogoImage));
            
            try
            {
                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void UpdateDirSignature(BrokerInfoBO brokerInfoBo)
        {
            SqlConnection conn = new SqlConnection(DbConnectionBasic.ConnectionString);
            string queryString = "";
            queryString = "Update SBP_Broker_Info SET [Directors_Signature]=@DirSignImage";
            SqlCommand command = new SqlCommand(queryString, conn);
            command.Parameters.Add(new SqlParameter("@DirSignImage", (object)brokerInfoBo.DirSignImage));
            try
            {
                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void UpdateDefaultSignature(BrokerInfoBO brokerInfoBo)
        {
            SqlConnection conn = new SqlConnection(DbConnectionBasic.ConnectionString);
            string queryString = "";
            queryString = "Update SBP_Broker_Info SET [Default_Signature]=@DefaultSignImage";
            SqlCommand command = new SqlCommand(queryString, conn);
            command.Parameters.Add(new SqlParameter("@DefaultSignImage", (object)brokerInfoBo.DefaultSignImage));
            try
            {
                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////

        public DataTable IPO_Money_Trns(String fromDate, string toDate)
        {
            DataTable dtPaymentReview = null;

            string quryString = "";

            quryString = @"Rpt_IPO_Money_Trns_ApplyTogether";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@fromDate", SqlDbType.DateTime, fromDate);
                _dbConnection.AddParameter("@toDate", SqlDbType.DateTime, toDate);

                dtPaymentReview = _dbConnection.ExecuteProQuery(quryString);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dtPaymentReview;

        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public DataTable GetIPoSession()
        {
            DataTable dataTable;
            dataTable = null;
            string queryString = "";
            queryString = "SELECT ID, IPOSession_Name FROM  SBP_IPO_Session ORDER BY ID DESC ";
            try
            {
                _dbConnection.ConnectDatabase();
                dataTable = _dbConnection.ExecuteQuery(queryString);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dataTable;

        }
    
        /////////////////////////////////////////////////////////////////////////////////////////     
        public DataTable IPO_Single_Trans(string fromDate, string toDate)
        {
            DataTable dataTable;
            dataTable = null;
            string queryString = "";

            queryString = @"Rpt_IPO_Money_Trns_Revew";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@fromDate", SqlDbType.DateTime, fromDate);
                _dbConnection.AddParameter("@toDate", SqlDbType.DateTime, toDate);

                dataTable = _dbConnection.ExecuteProQuery(queryString);
            }


//            queryString = @"SELECT Deposit_Type, Date, Client_Code, Client_Name, Received_Amount, Paid_Amount, Cheque_No, Voucher_No, Type, Remarks, BranchName, BranchID, ApplicationType, 
            //                                  IPO_SessionID FROM  V_IPO_Money_Trns WHERE (Date >= CONVERT(DATETIME, '" + _FormDate + "', 102)) AND (Date <= CONVERT(DATETIME, '" + _ToDate + "', 102))";


            //try
            //{
            //    _dbConnection.ConnectDatabase();
            //    dataTable = _dbConnection.ExecuteQuery(queryString);
            //}
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dataTable;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////



        public DataTable Portfolio_PE_dt(String txtSearchCustomer, string toDate)
        {
            DataTable dataTable = null;

            string quryString = "";

            quryString = @"SELECT *
                                FROM V_Portfolio_P_E_Repot
                                     WHERE (Cust_Code = N'" + txtSearchCustomer + @"') 
                                           AND (Trade_Date <= CONVERT(DATETIME, '" + toDate + @"', 102))
                                ";
            try
            {
                _dbConnection.ConnectDatabase();
                dataTable = _dbConnection.ExecuteQuery(quryString);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dataTable;

        }

     
    }
}
