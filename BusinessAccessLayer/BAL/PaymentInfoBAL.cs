﻿using System;
using System.Collections.Generic;
using System.Data;
using BusinessAccessLayer.BO;
using DataAccessLayer;
using BusinessAccessLayer.Constants;
using System.Linq;
using System.Data.SqlClient;
namespace BusinessAccessLayer.BAL
{
    public class PaymentInfoBAL
    {
        private DbConnection _dbConnection;
        
        public PaymentInfoBAL()
        {
            _dbConnection = new DbConnection();
        }
        /// <summary>
        /// Added By Shahrior On 27 January 2015
        /// </summary>
        public void ConnectDatabase()
        {
            _dbConnection.ConnectDatabase();
            _dbConnection.StartTransaction();
        }

        public void CloseDatabase()
        {
            _dbConnection.CloseDatabase();
        }

        public void Commit()
        {
            _dbConnection.Commit();
        }

        public void RollBack()
        {
            _dbConnection.Rollback();
        }

        public SqlTransaction GetTransaction()
        {
            return _dbConnection.GetTransaction();
        }

        public void SetTransaction(SqlTransaction trans)
        {
            _dbConnection.SetTransaction(trans);
        }

        public DbConnection GetConnection()
        {
            return _dbConnection;
        }
        public void SetConnection(DbConnection con)
        {

            _dbConnection = con;
        }
        /******************************************************************/
        public DataTable GetPaymentEntryInfo(DateTime date)
        {
            // "SELECT Payment_ID,Cust_code AS 'Client Code',(SELECT Cust_Name FROM SBP_Cust_Personal_Info WHERE SBP_Cust_Personal_Info.Cust_code=SBP_Payment_Posting_Request.Cust_code) AS 'Name',Amount,CASE Payment_Media WHEN 'Check' THEN 'Cheque' ELSE Payment_Media END AS 'Payment Media',Payment_Media_No AS 'Payment Media No',Vouchar_SN AS 'Vouchar No',Received_Date AS 'Received Date',(CASE WHEN Approval_Status=1 THEN 'Approved' WHEN Approval_Status=0 THEN 'Pending' WHEN Approval_Status=2 THEN 'Rejected' END) AS 'Status' FROM SBP_Payment_Posting_Request WHERE Received_Date='" + date.ToShortDateString() + "' AND '" + GlobalVariableBO._branchId + "'=(SELECT Branch_ID FROM SBP_Users WHERE User_Name=SBP_Payment_Posting_Request.Entry_By)";                                //
            string queryString = "SELECT Cust_Code AS 'Client ID',CASE Payment_Media WHEN 'Check' THEN 'Cheque' ELSE Payment_Media END AS 'Payment Media',Payment_Media_No AS 'Cheque No',Voucher_Sl_No AS 'Voucher No',Amount FROM SBP_Payment WHERE Received_Date='" + date.ToShortDateString() + "'";
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

        private DataTable GetPaymentMediaMaturityDay(int InstantMature, string paymentMedia)
        {
            DataTable dataTable;
            dataTable = null;
            string queryString = "";
            queryString = "SELECT CASE WHEN(" + InstantMature + "=1) THEN 0 ELSE (SELECT TOP 1 Maturity_Days FROM SBP_Payment_Media_Maturity WHERE Effective_Date=(SELECT MAX(Effective_Date) FROM SBP_Payment_Media_Maturity WHERE Payment_Media='" + paymentMedia + "') ORDER BY ID DESC) END";
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

        public DataTable LoadOtherMedia()
        {
            DataTable dataTable;
            dataTable = null;
            string queryString = "";
            queryString = "SELECT * FROM SBP_Payment_Media";
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

        public string GenerateSerial()  ////Auto SerialNo Generate
        {
            string slNo = "";
            int intTryParse;
            DataTable dataTable;
            string queryStringSelect = "";
            string queryStringUpdate = "";
            queryStringSelect = "SELECT Prefix + Convert(varchar(20),Sl_No) as 'sl No' FROM SBP_Serial_Generator WHERE Serial_Purpose='Payment'";
            // queryStringUpdate="UPDATE SBP_Serial_Generator SET Sl_No = Sl_No + 1 WHERE Serial_Purpose='Payment'";

            try
            {
                _dbConnection.ConnectDatabase();
                dataTable = _dbConnection.ExecuteQuery(queryStringSelect);
                //  _dbConnection.ExecuteNonQuery(queryStringUpdate);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }

            if (dataTable.Rows[0]["sl No"] != DBNull.Value)
            {
                slNo = dataTable.Rows[0]["sl No"].ToString();
            }

            return slNo;
        }

        public bool IsLockedVoucherLockState()
        {
            bool result = false;
            DataTable dataTable;
            string query = "SELECT [Serial_Purpose], [Prefix], [Sl_No], [IsLocked] "
                         + " FROM [SBP_Database].[dbo].[SBP_Serial_Generator]"
                         + " WHERE IsLocked=1";
            _dbConnection.ConnectDatabase();
            dataTable = _dbConnection.ExecuteQuery(query);
            if (dataTable.Rows.Count > 0)
            {
                result = true;
            }
            return result;
        }

        public void LockVoucherNo()
        {
            string queryStringUpdate = "";
            queryStringUpdate = "UPDATE SBP_Serial_Generator SET IsLocked=1 WHERE IsLocked=0";

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(queryStringUpdate);
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

        public void UnLockVoucherNo()
        {
            string queryStringUpdate = "";
            queryStringUpdate = "UPDATE SBP_Serial_Generator SET IsLocked=0 WHERE IsLocked=1";

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(queryStringUpdate);
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

        public void UpdateSerialNo()  ////Auto SerialNo Generate
        {
            string slNo = "";
            DataTable dataTable;
            string queryStringSelect = "";
            string queryStringUpdate = "";
            queryStringUpdate = "UPDATE SBP_Serial_Generator SET Sl_No = Sl_No+1 WHERE Serial_Purpose='Payment'";

            try
            {
                _dbConnection.ConnectDatabase();
                //  dataTable = _dbConnection.ExecuteQuery(queryStringSelect);
                _dbConnection.ExecuteNonQuery(queryStringUpdate);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }

            //if (dataTable.Rows[0]["sl No"] != DBNull.Value)
            //    slNo = dataTable.Rows[0]["sl No"].ToString();

            //return slNo;
        }

        public float GetCurrentBalane(string custCode)
        {
            float currentBalance = 0;
            DataTable dataTable;
            string queryString = "SELECT dbo.GetCurrentMoneyBalance('" + custCode + "')";

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

            if (dataTable.Rows[0][0] != DBNull.Value)
                currentBalance = float.Parse(dataTable.Rows[0][0].ToString());

            return currentBalance;

        }

        public float GetMaturedBalane(string custCode)
        {
            float matureBalance = 0;
            DataTable dataTable;
            string queryString = "SELECT dbo.GetMaturedMoneyBalance('" + custCode + "')";

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

            if (dataTable.Rows[0][0] != DBNull.Value)
                matureBalance = float.Parse(dataTable.Rows[0][0].ToString());

            return matureBalance;

        }

        public DataTable SearchForDelete(string criteriaString, bool isPaymentDelete, bool isPaymentOCCDelete)
        {
            DataTable dataTable;
            dataTable = null;
            string queryString = "";
            queryString =
                @"SELECT  
                              Payment_ID  
                             ,Cust_Code as 'Customer Code'  
                             ,Amount  
                             ,Payment_Media  
                             ,Payment_Media_No  
                             ,Voucher_Sl_No AS 'Vouchar No'  
                             ,Deposit_Withdraw AS 'Deposit/Withdraw'  
                             ,Received_Date AS 'Received Date'  
                             ,Requisition_ID AS 'Requisition_ID'  
                             FROM SBP_Payment 
                             WHERE 0=0 " + criteriaString;


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

        /// <summary>
        /// Current Money,Deduct Money For 500,Deposit and Withdraw Pending Balance Info For Trade account
        /// </summary>
        /// <param name="cust_code"></param>
        /// <returns>Md.Rashedul Hasan On 27-Jan-2015</returns>
        public DataTable GetCurrentBalanceInfo_Uitrans(string cust_code)
        {
            DataTable dt = new DataTable();
            string query = @"SBP_TradeAccountBalanceInfo";
            try
            {
                //_dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@Cust_Code", SqlDbType.VarChar, cust_code);
                dt = _dbConnection.ExecuteProQuery(query);
                //_dbConnection.ClearParameters();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //finally
            //{
            //    _dbConnection.CloseDatabase();
            //}
            return dt;
        }

        /// <summary>
        /// Current Money,Deduct Money For 500,Deposit and Withdraw Pending Balance Info For Trade account
        /// </summary>
        /// <param name="cust_code"></param>
        /// <returns>Md.Rashedul Hasan On 27-Jan-2015</returns>
        public DataTable GetCurrentBalanceInfo(string cust_code)
        {
            DataTable dt = new DataTable();
            string query = @"SBP_TradeAccountBalanceInfo";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@Cust_Code", SqlDbType.VarChar, cust_code);
                dt = _dbConnection.ExecuteProQuery(query);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dt;
        }


        public DataTable GetApprovedReturnTransaction(int paymentID, string paymentMethod, string paymentMode)
        {
            DataTable dt = new DataTable();
            string queryStringHave_ReturnTrans_SBPPayment = string.Empty;
            if (paymentMode == Constants.Indication_PaymentMode.Deposit )
            {
                //if (paymentMethod == Constants.Indication_PaymentMode.EFT || paymentMethod == Constants.Indication_PaymentMode.ECash)
                {
                      queryStringHave_ReturnTrans_SBPPayment = " SELECT "
                       + " [Payment_ID], [Cust_Code], [Amount], [Received_Date], [Payment_Media], [Payment_Media_No], [Payment_Media_Date], [Bank_Name], [Bank_Branch], [Received_By], [Deposit_Withdraw], [Payment_Approved_By], [Payment_Approved_Date], [Voucher_Sl_No], [Trans_Reason], [Remarks], [Entry_Date], [Entry_By], [Maturity_Days], [Requisition_ID], [Entry_Branch_ID] "
                       + " FROM [SBP_Database].[dbo].[SBP_Payment] "
                       + " WHERE "
                       + " Payment_Media= '" + paymentMethod + "'"
                       + " AND "
                       + " Deposit_Withdraw= '" + Constants.Indication_PaymentMode.Deposit + "'   AND Payment_ID='" + paymentID + "'";
                }
                //else
                //{
                //    queryStringHave_ReturnTrans_SBPPayment = " SELECT "
                //    + " [Payment_ID], [Cust_Code], [Amount], [Received_Date], [Payment_Media], [Payment_Media_No], [Payment_Media_Date], [Bank_Name], [Bank_Branch], [Received_By], [Deposit_Withdraw], [Payment_Approved_By], [Payment_Approved_Date], [Voucher_Sl_No], [Trans_Reason], [Remarks], [Entry_Date], [Entry_By], [Maturity_Days], [Requisition_ID], [Entry_Branch_ID] "
                //    + " FROM [SBP_Database].[dbo].[SBP_Payment] "
                //    + " WHERE "
                //    + " Trans_Reason='" + paymentMethod + "Return_'+Convert(varchar(200)," + paymentID + ") "
                //    + " AND "
                //    + " Payment_Media='" + paymentMethod + "Return' "
                //    + " AND "
                //    + " Deposit_Withdraw='" + Constants.Indication_PaymentMode.Withdraw + "' ";
                //}
            }
            else if (paymentMode == Constants.Indication_PaymentMode.Withdraw)
            {
                //if (paymentMethod == Constants.Indication_PaymentMode.EFT || paymentMethod == Constants.Indication_PaymentMode.ECash)
                {
                    queryStringHave_ReturnTrans_SBPPayment = " SELECT "
                     + " [Payment_ID], [Cust_Code], [Amount], [Received_Date], [Payment_Media], [Payment_Media_No], [Payment_Media_Date], [Bank_Name], [Bank_Branch], [Received_By], [Deposit_Withdraw], [Payment_Approved_By], [Payment_Approved_Date], [Voucher_Sl_No], [Trans_Reason], [Remarks], [Entry_Date], [Entry_By], [Maturity_Days], [Requisition_ID], [Entry_Branch_ID] "
                     + " FROM [SBP_Database].[dbo].[SBP_Payment] "
                     + " WHERE "
                     + " Payment_Media= '" + paymentMethod + "'"
                     + " AND "
                     + " Deposit_Withdraw= '" + Constants.Indication_PaymentMode.Withdraw + "'   AND Payment_ID='" + paymentID + "'";
                }
                //else
                //{
                //    queryStringHave_ReturnTrans_SBPPayment = " SELECT "
                //    + " [Payment_ID], [Cust_Code], [Amount], [Received_Date], [Payment_Media], [Payment_Media_No], [Payment_Media_Date], [Bank_Name], [Bank_Branch], [Received_By], [Deposit_Withdraw], [Payment_Approved_By], [Payment_Approved_Date], [Voucher_Sl_No], [Trans_Reason], [Remarks], [Entry_Date], [Entry_By], [Maturity_Days], [Requisition_ID], [Entry_Branch_ID] "
                //    + " FROM [SBP_Database].[dbo].[SBP_Payment] "
                //    + " WHERE "
                //    + " Trans_Reason='" + paymentMethod + "Return_'+Convert(varchar(200)," + paymentID + ") "
                //    + " AND "
                //    + " Payment_Media= '" + paymentMethod + "Return'"
                //    + " AND "
                //    + " Deposit_Withdraw= '" + Constants.Indication_PaymentMode.Deposit + "' ";
                //}
            }
           
            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(queryStringHave_ReturnTrans_SBPPayment);

            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dt;
        }
        public DataTable GetPendingReturnTransaction(int paymentID, string paymentMethod, string paymentMode)
        {
            DataTable dt = new DataTable();
            string queryStringHave_ReturnTrans_SBPPayment = string.Empty;
            if (paymentMode == Constants.Indication_PaymentMode.Deposit)
            {
                queryStringHave_ReturnTrans_SBPPayment = " Select * "
                + " From dbo.SBP_Payment_Posting_Request "
                + " Where Replace(Trans_Reason,'" + paymentMethod + "Return_','')= "
                + " Convert(varchar(200), "
                + " ( "
                + "							Select PayPosting.Payment_ID "
                + "							From "
                + "							dbo.SBP_Payment_Posting_Request As PayPosting "
                + "        					Join "
                + "							dbo.SBP_Payment As Pay "
                + "							ON "
                + "							Pay.Requisition_ID=PayPosting.Payment_ID "
                + "							Where Pay.Payment_ID=" + paymentID + " "
                + " ) "
                + " ) "
                + " AND "
                + " Approval_Status=0 "
                + " AND "
                + " Deposit_Withdraw='" + Constants.Indication_PaymentMode.Withdraw + "'";
            }
            else if (paymentMode == Constants.Indication_PaymentMode.Withdraw)
            {
                queryStringHave_ReturnTrans_SBPPayment = " Select * "
                + " From dbo.SBP_Payment_Posting_Request "
                + " Where Replace(Trans_Reason,'" + paymentMethod + "Return_','')= "
                + " Convert(varchar(200), "
                + " ( "
                + "							Select PayPosting.Payment_ID "
                + "							From "
                + "							dbo.SBP_Payment_Posting_Request As PayPosting "
                + "        					Join "
                + "							dbo.SBP_Payment As Pay "
                + "							ON "
                + "							Pay.Requisition_ID=PayPosting.Payment_ID "
                + "							Where Pay.Payment_ID=" + paymentID + " "
                + " ) "
                + " ) "
                + " AND "
                + " Approval_Status=0 "
                + " AND "
                + " Deposit_Withdraw='" + Constants.Indication_PaymentMode.Deposit + "'";
            }

            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(queryStringHave_ReturnTrans_SBPPayment);

            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dt;
        }
        public DataTable LoadApprovedReturnTansaction(int paymentID, string paymentMethod, string paymentMode)
        {
            DataTable dt = new DataTable();
            string queryStringHave_ReturnTrans_SBPPayment = string.Empty;
            if (paymentMode == Constants.Indication_PaymentMode.Deposit)
            {
                queryStringHave_ReturnTrans_SBPPayment = " SELECT "
                + " [Payment_ID], [Cust_Code], [Amount], [Received_Date], [Payment_Media], [Payment_Media_No], [Payment_Media_Date], [Bank_Name], [Bank_Branch], [Received_By], [Deposit_Withdraw], [Payment_Approved_By], [Payment_Approved_Date], [Voucher_Sl_No], [Trans_Reason], [Remarks], [Entry_Date], [Entry_By], [Maturity_Days], [Requisition_ID], [Entry_Branch_ID] "
                + " FROM [SBP_Database].[dbo].[SBP_Payment] "
                + " WHERE "
                + " Trans_Reason='Return_'+Convert(varchar(200)," + paymentID + ") "
                + " AND "
                + " Payment_Media='" + paymentMethod + "' "
                + " AND "
                + " Deposit_Withdraw='" + Constants.Indication_PaymentMode.Withdraw + "' ";
            }
            else if (paymentMode == Constants.Indication_PaymentMode.Withdraw)
            {
                queryStringHave_ReturnTrans_SBPPayment = " SELECT "
                + " [Payment_ID], [Cust_Code], [Amount], [Received_Date], [Payment_Media], [Payment_Media_No], [Payment_Media_Date], [Bank_Name], [Bank_Branch], [Received_By], [Deposit_Withdraw], [Payment_Approved_By], [Payment_Approved_Date], [Voucher_Sl_No], [Trans_Reason], [Remarks], [Entry_Date], [Entry_By], [Maturity_Days], [Requisition_ID], [Entry_Branch_ID] "
                + " FROM [SBP_Database].[dbo].[SBP_Payment] "
                + " WHERE "
                + " Trans_Reason='Return_'+Convert(varchar(200)," + paymentID + ") "
                + " AND "
                + " Payment_Media= '" + paymentMethod + "' "
                + " AND "
                + " Deposit_Withdraw= '" + Constants.Indication_PaymentMode.Deposit + "' ";
            }
            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(queryStringHave_ReturnTrans_SBPPayment);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }

            return dt;
        }

        public DataTable LoadPendingReturnTansaction(int paymentID, string paymentMethod, string paymentMode)
        {
            DataTable dt = new DataTable();
            string queryStringHave_ReturnTrans_SBPPayment = string.Empty;
            if (paymentMode == Constants.Indication_PaymentMode.Deposit)
            {
                queryStringHave_ReturnTrans_SBPPayment = " SELECT "
                + " [Payment_ID], [Cust_Code], [Amount], [Received_Date], [Payment_Media], [Payment_Media_No], [Payment_Media_Date], [Bank_Name], [Bank_Branch], [Received_By], [Deposit_Withdraw], [Payment_Approved_By], [Payment_Approved_Date], [Voucher_Sl_No], [Trans_Reason], [Remarks], [Entry_Date], [Entry_By], [Maturity_Days], [Requisition_ID], [Entry_Branch_ID] "
                + " FROM [SBP_Database].[dbo].[SBP_Payment] "
                + " WHERE "
                + " Trans_Reason='Return_'+Convert(varchar(200)," + paymentID + ") "
                + " AND "
                + " Payment_Media='" + paymentMethod + "' "
                + " AND "
                + " Deposit_Withdraw='" + Constants.Indication_PaymentMode.Withdraw + "' ";
            }
            else if (paymentMode == Constants.Indication_PaymentMode.Withdraw)
            {
                queryStringHave_ReturnTrans_SBPPayment = " SELECT "
                + " [Payment_ID], [Cust_Code], [Amount], [Received_Date], [Payment_Media], [Payment_Media_No], [Payment_Media_Date], [Bank_Name], [Bank_Branch], [Received_By], [Deposit_Withdraw], [Payment_Approved_By], [Payment_Approved_Date], [Voucher_Sl_No], [Trans_Reason], [Remarks], [Entry_Date], [Entry_By], [Maturity_Days], [Requisition_ID], [Entry_Branch_ID] "
                + " FROM [SBP_Database].[dbo].[SBP_Payment] "
                + " WHERE "
                + " Trans_Reason='Return_'+Convert(varchar(200)," + paymentID + ") "
                + " AND "
                + " Payment_Media= '" + paymentMethod + "' "
                + " AND "
                + " Deposit_Withdraw= '" + Constants.Indication_PaymentMode.Deposit + "' ";
            }

            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(queryStringHave_ReturnTrans_SBPPayment);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }

            return dt;
        }

        public void DeletePaymentInfo(int paymentId, string paymentMethod, string paymentMode,string modificationType)
        {
            string queryStringInsLog = string.Empty;
            string queryStringDel_SBPPayment = string.Empty;
            string queryStringDel_SBPPayment_Posting = string.Empty;
            string queryStringDel_Return_SBPPayment = string.Empty;
            string queryStringDel_Return_SBPPayment_Posting = string.Empty;

            CommonBAL cmbBAL=new CommonBAL();
            //queryStringInsLog = "INSERT INTO SBP_Payment_Delete_Log(Sl_No,Payment_ID,Cust_Code,Amount,Received_Date,Payment_Media,Payment_Media_No,Payment_Media_Date,Bank_Name,Bank_Branch,Received_By,Deposit_Withdraw,Payment_Approved_By,Payment_Approved_Date,Voucher_Sl_No,Trans_Reason,Remarks,Entry_Date,Entry_By,Maturity_Days,Delete_Date,Deleted_By) SELECT " + GetSlNo() + "," + paymentId + ",Cust_Code,Amount,Received_Date,Payment_Media,Payment_Media_No,Payment_Media_Date,Bank_Name,Bank_Branch,Received_By,Deposit_Withdraw,Payment_Approved_By,Payment_Approved_Date,Voucher_Sl_No,Trans_Reason,Remarks,Entry_Date,Entry_By,Maturity_Days,GETDATE(),'" + GlobalVariableBO._userName + "' FROM SBP_Payment WHERE Payment_ID=" + paymentId + "";
            queryStringInsLog = @"INSERT INTO SBP_Payment_Modification_Log
                                   (
                                    [Payment_ID]
                                   ,[Cust_Code]
                                   ,[Amount]
                                   ,[Received_Date]
                                   ,[Payment_Media]
                                   ,[Payment_Media_No]
                                   ,[Payment_Media_Date]
                                   ,[Bank_ID]
                                   ,[Bank_Name]
                                   ,[Branch_ID]
                                   ,[Bank_Branch]
                                   ,[Received_By]
                                   ,[Deposit_Withdraw]
                                   ,[Payment_Approved_By]
                                   ,[Payment_Approved_Date]
                                   ,[Voucher_Sl_No]
                                   ,[Trans_Reason]
                                   ,[Remarks]
                                   ,[Entry_Date]
                                   ,[Entry_By]
                                   ,[Maturity_Days]
                                   ,[Requisition_ID]
                                   ,[Entry_Branch_ID]
                                   ,[Modification_Date]
                                   ,[Modification_By]
                                   ,[Modification_Type]
                                   )
                             SELECT [Payment_ID]
                              ,[Cust_Code]
                              ,[Amount]
                              ,[Received_Date]
                              ,[Payment_Media]
                              ,[Payment_Media_No]
                              ,[Payment_Media_Date]
                              ,[Bank_ID]
                              ,[Bank_Name]
                              ,[Branch_ID]
                              ,[Bank_Branch]
                              ,[Received_By]
                              ,[Deposit_Withdraw]
                              ,[Payment_Approved_By]
                              ,[Payment_Approved_Date]
                              ,[Voucher_Sl_No]
                              ,[Trans_Reason]
                              ,[Remarks]
                              ,[Entry_Date]
                              ,[Entry_By]
                              ,[Maturity_Days]
                              ,[Requisition_ID]
                              ,[Entry_Branch_ID]
                              ,'" + cmbBAL.GetCurrentServerDate().ToShortDateString()
                              +"','" + GlobalVariableBO._userName +"'"
                              +",'" + modificationType +"'"
                              +" FROM [SBP_Database].[dbo].[SBP_Payment]"
                              + " WHERE Payment_ID=" + paymentId;

            queryStringDel_SBPPayment = "DELETE FROM SBP_Payment WHERE Payment_ID=" + paymentId + "";

            queryStringDel_SBPPayment_Posting = " Delete "
                + " From dbo.SBP_Payment_Posting_Request "
                + " Where "
                + " Payment_ID=( "
                + "                 Select "
                + "                  payReq.Payment_ID "
                + "                 From  "
                + "                 dbo.SBP_Payment_Posting_Request as payReq "
                + "                 Join "
                + "                 dbo.SBP_Payment as pay "
                + "                 ON "
                + "                 payReq.Payment_ID=pay.Requisition_ID "
                + "                 AND "
                + "                 payReq.Payment_Media=pay.Payment_Media "
                + "                 AND "
                + "                 payReq.Deposit_Withdraw=pay.Deposit_Withdraw "
                + "                 AND "
                + "                 pay.Payment_ID='" + paymentId + "' "
                + " ) ";
            if (paymentMode == Indication_PaymentMode.Deposit)
            {
                queryStringDel_Return_SBPPayment = " Delete From [SBP_Database].[dbo].[SBP_Payment] "
                + " WHERE "
                + " Trans_Reason='" + paymentMethod + "Return_'+Convert(varchar(200), " + paymentId + " ) "
                + " AND "
                + " Payment_Media='" + paymentMethod + "Return' "
                + " AND "
                + " Deposit_Withdraw='" + Indication_PaymentMode.Withdraw + "' ";

                queryStringDel_Return_SBPPayment_Posting = " Delete "
                + " From dbo.SBP_Payment_Posting_Request "
                + " Where  "
                + " Payment_ID= "
                            + " ( "
                            + "  Select "
                            + "  payReq.Payment_ID "
                            + "  From "
                            + "  dbo.SBP_Payment_Posting_Request as payReq "
                            + "  Join "
                            + "  dbo.SBP_Payment as pay "
                            + "  ON "
                            + "  payReq.Payment_ID=pay.Requisition_ID "
                            + "  AND "
                            + "  payReq.Payment_Media=pay.Payment_Media "
                            + "  AND "
                            + "  payReq.Deposit_Withdraw=pay.Deposit_Withdraw "
                            + "  AND "
                            + "  pay.Payment_ID=( "
                            + "                      Select pay.Payment_ID "
                            + "                      From [SBP_Database].[dbo].[SBP_Payment] as pay "
                            + "                      WHERE "
                            + "                      pay.Trans_Reason='" + paymentMethod + "Return_'+Convert(varchar(200), " + paymentId + " ) "
                            + "                      AND "
                            + "                      pay.Payment_Media='" + paymentMethod + "Return' "
                            + "                      AND "
                            + "                      pay.Deposit_Withdraw='" + Indication_PaymentMode.Withdraw + "' "
                            + "                  ) "
                            + " ) ";

            }
            else if (paymentMode == Indication_PaymentMode.Withdraw)
            {
                queryStringDel_Return_SBPPayment = " Delete From [SBP_Database].[dbo].[SBP_Payment] "
                + " WHERE "
                + " Trans_Reason='" + paymentMethod + "Return_'+Convert(varchar(200), " + paymentId + " ) "
                + " AND "
                + " Payment_Media='" + paymentMethod + "Return' "
                + " AND "
                + " Deposit_Withdraw='" + Indication_PaymentMode.Deposit + "' ";

                queryStringDel_Return_SBPPayment_Posting = " Delete "
                + " From dbo.SBP_Payment_Posting_Request "
                + " Where  "
                + " Payment_ID= "
                            + " ( "
                            + "  Select "
                            + "  payReq.Payment_ID "
                            + "  From "
                            + "  dbo.SBP_Payment_Posting_Request as payReq "
                            + "  Join "
                            + "  dbo.SBP_Payment as pay "
                            + "  ON "
                            + "  payReq.Payment_ID=pay.Requisition_ID "
                            + "  AND "
                            + "  payReq.Payment_Media=pay.Payment_Media "
                            + "  AND "
                            + "  payReq.Deposit_Withdraw=pay.Deposit_Withdraw "
                            + "  AND "
                            + "  pay.Payment_ID=( "
                            + "                   Select pay.Payment_ID "
                            + "                   From [SBP_Database].[dbo].[SBP_Payment] as pay "
                            + "                   WHERE "
                            + "                   pay.Trans_Reason='" + paymentMethod + "Return_'+Convert(varchar(200), " + paymentId + " ) "
                            + "                   AND "
                            + "                   pay.Payment_Media='" + paymentMethod + "Return' "
                            + "                   AND "
                            + "                   pay.Deposit_Withdraw='" + Constants.Indication_PaymentMode.Deposit + "' "
                            + "                  ) "
                            + " ) ";

            }

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();
                _dbConnection.ExecuteNonQuery(queryStringInsLog);
                _dbConnection.ExecuteNonQuery(queryStringDel_SBPPayment_Posting);
               // _dbConnection.ExecuteNonQuery(queryStringDel_Return_SBPPayment_Posting);
                _dbConnection.ExecuteNonQuery(queryStringDel_SBPPayment);
                //_dbConnection.ExecuteNonQuery(queryStringDel_Return_SBPPayment);

                //if (paymentMethod != Indication_PaymentTransaction.Cheque && paymentMode == Indication_PaymentMode.Withdraw)
                //{
                //    _dbConnection.ExecuteNonQuery(queryStringD_SBPPayment_Posting);
                //    _dbConnection.ExecuteNonQuery(queryStringDel_SBPPayment);
                //}
                //else
                //{

                //}
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

        private long GetSlNo()
        {
            CommonBAL commonBAL = new CommonBAL();
            long SlNo = commonBAL.GenerateID("SBP_Payment_Delete_Log", "Sl_No");
            return SlNo;
        }

        public void PaymentInitialProcessing()
        {
            try
            {
                GenerateMoneyBalanceTemp();
            }
            catch (Exception)
            {
                throw;
            }
           
        }
        public void EditPaymentInfoData(int paymentId, int requisitionId, string voucherNo, DateTime modifiedDate,string modificationType)
        {
            CommonBAL cmnBAL = new CommonBAL();
            string queryStringInsLog = string.Empty;
            string queryStringPaymentUpdate = string.Empty;
            string queryStringPaymentPostingRequestUpdate = string.Empty;

            queryStringInsLog =
                @"INSERT INTO SBP_Payment_Modification_Log
                                   (
                                    [Payment_ID]
                                   ,[Cust_Code]
                                   ,[Amount]
                                   ,[Received_Date]
                                   ,[Payment_Media]
                                   ,[Payment_Media_No]
                                   ,[Payment_Media_Date]
                                   ,[Bank_ID]
                                   ,[Bank_Name]
                                   ,[Branch_ID]
                                   ,[Bank_Branch]
                                   ,[Received_By]
                                   ,[Deposit_Withdraw]
                                   ,[Payment_Approved_By]
                                   ,[Payment_Approved_Date]
                                   ,[Voucher_Sl_No]
                                   ,[Trans_Reason]
                                   ,[Remarks]
                                   ,[Entry_Date]
                                   ,[Entry_By]
                                   ,[Maturity_Days]
                                   ,[Requisition_ID]
                                   ,[Entry_Branch_ID]
                                   ,[Modification_Date]
                                   ,[Modification_By]
                                   ,[Modification_Type]
                                   )
                             SELECT [Payment_ID]
                              ,[Cust_Code]
                              ,[Amount]
                              ,[Received_Date]
                              ,[Payment_Media]
                              ,[Payment_Media_No]
                              ,[Payment_Media_Date]
                              ,[Bank_ID]
                              ,[Bank_Name]
                              ,[Branch_ID]
                              ,[Bank_Branch]
                              ,[Received_By]
                              ,[Deposit_Withdraw]
                              ,[Payment_Approved_By]
                              ,[Payment_Approved_Date]
                              ,[Voucher_Sl_No]
                              ,[Trans_Reason]
                              ,[Remarks]
                              ,[Entry_Date]
                              ,[Entry_By]
                              ,[Maturity_Days]
                              ,[Requisition_ID]
                              ,[Entry_Branch_ID]
                              ,'" +cmnBAL.GetCurrentServerDate().ToShortDateString()
                            + "','" + GlobalVariableBO._userName + "'"
                            + ",'" + modificationType + "'"
                            + " FROM [SBP_Database].[dbo].[SBP_Payment]"
                            +" WHERE Payment_ID="+paymentId;
                              

            queryStringPaymentUpdate = @"UPDATE dbo.SBP_Payment
                                        SET Voucher_Sl_No='" + voucherNo
                                        + "',Received_Date='" + modifiedDate.ToShortDateString()
                                        + "' WHERE Payment_ID=" + paymentId;


            queryStringPaymentPostingRequestUpdate = @"UPDATE dbo.SBP_Payment_Posting_Request
                                                        SET Vouchar_SN='" + voucherNo
                                                        + "',Received_Date='" + modifiedDate.ToShortDateString()
                                                        + "' WHERE  Payment_ID=( "
                                                                                + " Select "
                                                                                + " payReq.Payment_ID "
                                                                                + " From  "
                                                                                + " dbo.SBP_Payment_Posting_Request as payReq "
                                                                                + " Join "
                                                                                + " dbo.SBP_Payment as pay "
                                                                                + " ON "
                                                                                + " payReq.Payment_ID=pay.Requisition_ID "
                                                                                + " AND "
                                                                                + " payReq.Payment_Media=pay.Payment_Media "
                                                                                + " AND "
                                                                                + " payReq.Deposit_Withdraw=pay.Deposit_Withdraw "
                                                                                + " AND "
                                                                                + " pay.Payment_ID='" + paymentId + "' "
                                                                                + " ) ";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(queryStringInsLog);
                _dbConnection.ExecuteNonQuery(queryStringPaymentUpdate);
                _dbConnection.ExecuteNonQuery(queryStringPaymentPostingRequestUpdate);
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
        private void GenerateMoneyBalanceTemp()
        {
            string queryString = @"EXECUTE GenerateMoneyBalanceTemp;";

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(queryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
        }
        public void InsertintoPaymentPostingRequestForTR(PaymentInfoBO paymentInfoBo)
        {
            string TRwithdraw = "";
            string TRdeposit = "";
            long paymentIdForTRwithdraw = 0;
            long paymentIdForTRdeposit = 0;
            CommonBAL commonBAL = new CommonBAL();
            paymentIdForTRwithdraw = commonBAL.GenerateID("SBP_Payment_Posting_Request", "Payment_ID");
            TRwithdraw = @"INSERT INTO SBP_Payment_Posting_Request
                                   (
                                    --Payment_ID               
                                    --,
                                    Cust_code
                                   ,Amount
                                   ,Received_Date
                                   ,Payment_Media
                                   ,Received_By
                                   ,Deposit_Withdraw
                                   ,Vouchar_SN
                                   ,Trans_Reason
                                   ,Payment_Approved_By
                                   ,Payment_Approved_Date
                                   ,Remarks
                                   ,Entry_Date          
                                   ,Entry_By
                                   )
                                   VALUES
                                  ("
                                  //+ paymentIdForTRwithdraw
                                  //+ ",'" 
                                  +"'"+ paymentInfoBo.TransCustCode
                                  + "'," + paymentInfoBo.Amount
                                  + ",'" + paymentInfoBo.RecievedDate.ToShortDateString()
                                  + "','" + paymentInfoBo.PaymentMedia
                                  + "','" + paymentInfoBo.RecievedBy
                                  + "','Withdraw'"
                                  + ",'" + paymentInfoBo.VoucherSlNo
                                  + "','" + paymentInfoBo.TransCustCode + " To " + paymentInfoBo.CustCode
                                  + "','" + paymentInfoBo.PaymentApprovedBy
                                  + "','" + paymentInfoBo.PaymentApprovedDate
                                  + "','" + paymentInfoBo.Remarks
                                  + "',CAST(FLOOR(CAST(GETDATE() AS FLOAT)) AS DATETIME),'"
                                  + GlobalVariableBO._userName
                                  + "')";

            paymentIdForTRdeposit = paymentIdForTRwithdraw + 1;
            TRdeposit = @"INSERT INTO SBP_Payment_Posting_Request
                                    (
                                     --Payment_ID
                                    --,
                                    Cust_code
                                    ,Amount
                                    ,Received_Date
                                    ,Payment_Media
                                    ,Received_By
                                    ,Deposit_Withdraw
                                    ,Vouchar_SN
                                    ,Trans_Reason
                                    ,Payment_Approved_By
                                    ,Payment_Approved_Date
                                    ,Remarks
                                    ,Entry_Date
                                    ,Entry_By
                                    )"
                                     +
                                     " VALUES("
                                     //+ paymentIdForTRdeposit
                                     //+ ",'" 
                                     +"'"+ paymentInfoBo.CustCode
                                     + "'," + paymentInfoBo.Amount
                                     + ",'" + paymentInfoBo.RecievedDate.ToShortDateString()
                                     + "','" + paymentInfoBo.PaymentMedia
                                     + "','" + paymentInfoBo.RecievedBy
                                     + "','Deposit'"
                                     + ",'" + paymentInfoBo.VoucherSlNo
                                     + "','" + paymentInfoBo.CustCode + " From " + paymentInfoBo.TransCustCode
                                     + "','" + paymentInfoBo.PaymentApprovedBy
                                     + "','" + paymentInfoBo.PaymentApprovedDate
                                     + "','" + paymentInfoBo.Remarks
                                     + "',CAST(FLOOR(CAST(GETDATE() AS FLOAT)) AS DATETIME),'"
                                     + GlobalVariableBO._userName + "')";

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();
                _dbConnection.ExecuteNonQuery(TRwithdraw);
                _dbConnection.ExecuteNonQuery(TRdeposit);
                _dbConnection.Commit();
            }
            catch (Exception ex)
            {
                _dbConnection.Rollback();
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }

        }
        public void InsertIntoPayment(PaymentInfoBO paymentInfoBo)
        {
            string queryString = "";
            string queryString_Payment_TRWithdraw = "";
            string queryString_Payment_TRDeposit = "";
            string queryString_MBalanceTemp_TRWithdraw = "";
            string queryString_MBalanceTemp_TRDeposit = "";

            if (paymentInfoBo.PaymentMedia == Indication_PaymentTransaction.TR)
            {
                queryString_Payment_TRWithdraw = "INSERT INTO SBP_Payment(Cust_code,Amount,Received_Date,Payment_Media,Received_By,Deposit_Withdraw,Voucher_Sl_No,Trans_Reason,Payment_Approved_By,Payment_Approved_Date,Remarks,Entry_Date,Entry_By)" +
              " VALUES('" + paymentInfoBo.TransCustCode + "'," + paymentInfoBo.Amount + ",'" + paymentInfoBo.RecievedDate.ToShortDateString() + "','" + paymentInfoBo.PaymentMedia + "','" + paymentInfoBo.RecievedBy + "','Withdraw','" + paymentInfoBo.VoucherSlNo + "','" + paymentInfoBo.TransCustCode + " To " + paymentInfoBo.CustCode + "','" + paymentInfoBo.PaymentApprovedBy + "','" + paymentInfoBo.PaymentApprovedDate + "','" + paymentInfoBo.Remarks + "',CAST(FLOOR(CAST(GETDATE() AS FLOAT)) AS DATETIME),'" + GlobalVariableBO._userName + "')";
                queryString_Payment_TRDeposit = "INSERT INTO SBP_Payment(Cust_code,Amount,Received_Date,Payment_Media,Received_By,Deposit_Withdraw,Voucher_Sl_No,Trans_Reason,Payment_Approved_By,Payment_Approved_Date,Remarks,Entry_Date,Entry_By)" +
              " VALUES('" + paymentInfoBo.CustCode + "'," + paymentInfoBo.Amount + ",'" + paymentInfoBo.RecievedDate.ToShortDateString() + "','" + paymentInfoBo.PaymentMedia + "','" + paymentInfoBo.RecievedBy + "','Deposit','" + paymentInfoBo.VoucherSlNo + "','" + paymentInfoBo.CustCode + " From " + paymentInfoBo.TransCustCode + "','" + paymentInfoBo.PaymentApprovedBy + "','" + paymentInfoBo.PaymentApprovedDate + "','" + paymentInfoBo.Remarks + "',CAST(FLOOR(CAST(GETDATE() AS FLOAT)) AS DATETIME),'" + GlobalVariableBO._userName + "')";

                queryString_MBalanceTemp_TRWithdraw = "INSERT INTO SBP_Money_Balance_Temp(Cust_Code,Sell_Deposit,Buy_Withdraw,Balance,Matured_Balance,Remarks,Rec_Date)"
                                        + " VALUES('" + paymentInfoBo.TransCustCode + "',0," + paymentInfoBo.Amount + "," + (0 - paymentInfoBo.Amount) + "," + (0 - paymentInfoBo.Amount) + ",'" + paymentInfoBo.PaymentMedia + "','" + paymentInfoBo.RecievedDate.ToShortDateString() + "');";

                queryString_MBalanceTemp_TRDeposit = "INSERT INTO SBP_Money_Balance_Temp(Cust_Code,Sell_Deposit,Buy_Withdraw,Balance,Matured_Balance,Remarks,Rec_Date)"
                                            + " VALUES('" + paymentInfoBo.CustCode + "'," + paymentInfoBo.Amount + ",0," + paymentInfoBo.Amount + "," + paymentInfoBo.Amount + ",'" + paymentInfoBo.PaymentMedia + "','" + paymentInfoBo.RecievedDate.ToShortDateString() + "');";
            }
            //else
            //{
            //    DataTable dtMaturity=new DataTable();
            //    int maturityDays = 0;
            //    dtMaturity=GetPaymentMediaMaturityDay(paymentInfoBo.IsMatureToday, paymentInfoBo.PaymentMedia);
            //    if (dtMaturity.Rows.Count > 0)
            //    {
            //        if (dtMaturity.Rows[0][0] != DBNull.Value)
            //            maturityDays = Convert.ToInt32(dtMaturity.Rows[0][0]);
            //    }
            //    queryString = "INSERT INTO SBP_Payment(Cust_code,Amount,Received_Date,Payment_Media,Maturity_Days,Payment_Media_No,Payment_Media_Date,Bank_Name,Bank_Branch,received_By,Deposit_Withdraw,Voucher_Sl_No,Payment_Approved_By,Payment_Approved_Date,Remarks,Entry_Date,Entry_By)" +
            //   " VALUES('" + paymentInfoBo.CustCode + "'," + paymentInfoBo.Amount + ",'" + paymentInfoBo.RecievedDate.ToShortDateString() + "','" + paymentInfoBo.PaymentMedia + "'," + maturityDays + ",'" + paymentInfoBo.PaymentMediaNo + "','" + paymentInfoBo.PaymentMediaDate.ToShortDateString() + "','" + paymentInfoBo.BankName + "','" + paymentInfoBo.BranchName + "','" + paymentInfoBo.RecievedBy + "','" + paymentInfoBo.DepositWithdraw + "','" + paymentInfoBo.VoucherSlNo + "','" + paymentInfoBo.PaymentApprovedBy + "','" + paymentInfoBo.PaymentApprovedDate + "','" + paymentInfoBo.Remarks + "',CAST(FLOOR(CAST(GETDATE() AS FLOAT)) AS DATETIME),'" + GlobalVariableBO._userName + "')";
            //}
            //string queryStringTemp;
            //if(paymentInfoBo.DepositWithdraw.Equals("Deposit"))
            //{
            //    queryStringTemp = "INSERT INTO SBP_Money_Balance_Temp(Cust_Code,Sell_Deposit,Buy_Withdraw,Balance,Matured_Balance,Remarks,Rec_Date)"
            //                         + " VALUES('" + paymentInfoBo.CustCode + "'," + paymentInfoBo.Amount + ",0," +paymentInfoBo.Amount + "," + paymentInfoBo.Amount + ",'" +paymentInfoBo.PaymentMedia + "','" +paymentInfoBo.RecievedDate.ToShortDateString() + "');";
            //}
            //else
            //{
            //    queryStringTemp = "INSERT INTO SBP_Money_Balance_Temp(Cust_Code,Sell_Deposit,Buy_Withdraw,Balance,Matured_Balance,Remarks,Rec_Date)"
            //                         + " VALUES('" + paymentInfoBo.CustCode + "',0," + paymentInfoBo.Amount + "," +(0- paymentInfoBo.Amount) + "," +(0- paymentInfoBo.Amount) + ",'" +paymentInfoBo.PaymentMedia + "','" +paymentInfoBo.RecievedDate.ToShortDateString() + "');";
            //}
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();
                if (paymentInfoBo.PaymentMedia == "TR")
                {
                    _dbConnection.ExecuteNonQuery(queryString_Payment_TRWithdraw);
                    _dbConnection.ExecuteNonQuery(queryString_Payment_TRDeposit);
                    _dbConnection.ExecuteNonQuery(queryString_MBalanceTemp_TRWithdraw);
                    _dbConnection.ExecuteNonQuery(queryString_MBalanceTemp_TRDeposit);
                }
                //else
                //{
                //    _dbConnection.ExecuteNonQuery(queryString);
                //    _dbConnection.ExecuteNonQuery(queryStringTemp);
                //}
                _dbConnection.Commit();
            }
            catch (Exception)
            {
                _dbConnection.Rollback();
                throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }

        }
        public void InsertIntoPayment_MoneyBalance_ForTRApproval(string[] paymentID)
        {
            string queryString_Payment_TRWithdraw = "";
            string queryString_Payment_TRDeposit = "";
            string queryString_MBalanceTemp_TRWithdraw = "";
            string queryString_MBalanceTemp_TRDeposit = "";
            string queryUpdateDepPosting = "";
            CommonBAL cmBal = new CommonBAL();
            
            string paymentIDText="0";
            int increment=1;
            foreach(var value in paymentID)
            {
                if(increment!=paymentID.Length)
                    paymentIDText=paymentIDText+value+",";
                else
                    paymentIDText=paymentIDText+value;

                increment++;
            }


            bool isUpdated = false;
            string queryString_CheckIf = string.Empty;
            queryString_CheckIf =
                            @"
                            DECLARE @IsUpdated bit

                            IF 
                                EXISTS (SELECT * FROM SBP_Payment_Posting_Request WHERE [Approval_Status]=1 AND [Payment_ID] IN (" + paymentIDText + @"))

                            BEGIN                                                                                                                                    
                                SET @IsUpdated=1
                            END
                            ELSE 
                            BEGIN
                                SET @IsUpdated=0
                            END
                            SELECT @IsUpdated                    
           ";


            queryString_Payment_TRWithdraw =
                @"INSERT INTO SBP_Payment
                                                    (
                                                    Cust_code
                                                    ,Amount
                                                    ,Received_Date
                                                    ,Payment_Media
                                                    ,Received_By
                                                    ,Deposit_Withdraw
                                                    ,Voucher_Sl_No
                                                    ,Trans_Reason
                                                    ,Payment_Approved_By
                                                    ,Payment_Approved_Date
                                                    ,Remarks
                                                    ,Entry_Date
                                                    ,Entry_By
                                                    ,Requisition_ID
                                                     )
                                                     SELECT 
                                                     Cust_Code
                                                    ,Amount
                                                    ,Received_Date
                                                    ,Payment_Media
                                                    ,Received_By
                                                    ,Deposit_Withdraw
                                                    ,Vouchar_SN
                                                    ,Trans_Reason
                                                    ,Payment_Approved_By
                                                    ,Payment_Approved_Date
                                                    ,Remarks
                                                    ,Entry_Date
                                                    ,Entry_By
                                                    ,Payment_ID
                                                    FROM SBP_Payment_Posting_Request
                                                    WHERE Payment_ID=" + paymentID[0];


            //                                                    )" +
            //                                              " VALUES('"
            //                                              + paymentInfoBo.TransCustCode
            //                                              + "'," + paymentInfoBo.Amount
            //                                              + ",'" + paymentInfoBo.RecievedDate.ToShortDateString()
            //                                              + "','" + paymentInfoBo.PaymentMedia
            //                                              + "','" + paymentInfoBo.RecievedBy
            //                                              + "','Withdraw'"
            //                                              + ",'" + paymentInfoBo.VoucherSlNo
            //                                              + "','" + paymentInfoBo.TransCustCode + " To " + paymentInfoBo.CustCode
            //                                              + "','" + paymentInfoBo.PaymentApprovedBy
            //                                              + "','" + paymentInfoBo.PaymentApprovedDate
            //                                              + "','" + paymentInfoBo.Remarks
            //                                              + "',CAST(FLOOR(CAST(GETDATE() AS FLOAT)) AS DATETIME),'"
            //                                              + GlobalVariableBO._userName + "')";

            queryString_Payment_TRDeposit = @"INSERT INTO SBP_Payment
                                                (
                                                Cust_code
                                                ,Amount
                                                ,Received_Date
                                                ,Payment_Media
                                                ,Received_By
                                                ,Deposit_Withdraw
                                                ,Voucher_Sl_No
                                                ,Trans_Reason
                                                ,Payment_Approved_By
                                                ,Payment_Approved_Date
                                                ,Remarks,Entry_Date
                                                ,Entry_By
                                                ,Requisition_ID
                                                )
                                                SELECT 
                                                 Cust_Code
                                                ,Amount
                                                ,Received_Date
                                                ,Payment_Media
                                                ,Received_By
                                                ,Deposit_Withdraw
                                                ,Vouchar_SN
                                                ,Trans_Reason
                                                ,Payment_Approved_By
                                                ,Payment_Approved_Date
                                                ,Remarks
                                                ,Entry_Date
                                                ,Entry_By
                                                ,Payment_ID
                                                FROM SBP_Payment_Posting_Request
                                                WHERE Payment_ID=" + paymentID[1];


            //  +
            //" VALUES('"
            //+ paymentInfoBo.CustCode
            //+ "'," + paymentInfoBo.Amount
            //+ ",'" + paymentInfoBo.RecievedDate.ToShortDateString()
            //+ "','" + paymentInfoBo.PaymentMedia
            //+ "','" + paymentInfoBo.RecievedBy
            //+ "','Deposit'"
            //+ ",'" + paymentInfoBo.VoucherSlNo
            //+ "','" + paymentInfoBo.CustCode + " From " + paymentInfoBo.TransCustCode
            //+ "','" + paymentInfoBo.PaymentApprovedBy
            //+ "','" + paymentInfoBo.PaymentApprovedDate
            //+ "','" + paymentInfoBo.Remarks
            //+ "',CAST(FLOOR(CAST(GETDATE() AS FLOAT)) AS DATETIME),'"
            //+ GlobalVariableBO._userName + "')";

            queryString_MBalanceTemp_TRWithdraw = @"INSERT INTO SBP_Money_Balance_Temp
                                                        (
                                                        Cust_Code
                                                        ,Sell_Deposit
                                                        ,Buy_Withdraw
                                                        ,Balance
                                                        ,Matured_Balance
                                                        ,Remarks
                                                        ,Rec_Date
                                                        )
                                                         SELECT 
                                                         Cust_Code
                                                        ,0
                                                        ,Amount
                                                        ,-(Amount)
                                                        ,-(Amount)
                                                        ,Payment_Media
                                                        ,Received_Date
                                                        FROM SBP_Payment_Posting_Request
                                                        WHERE Payment_ID=" + paymentID[0];

            //     
            //+ " VALUES('"
            //+ paymentInfoBo.TransCustCode
            //+ "',0,"
            //+ paymentInfoBo.Amount
            //+ "," + (0 - paymentInfoBo.Amount)
            //+ "," + (0 - paymentInfoBo.Amount)
            //+ ",'" + paymentInfoBo.PaymentMedia
            //+ "','" + paymentInfoBo.RecievedDate.ToShortDateString()
            //+ "');";

            queryString_MBalanceTemp_TRDeposit = @"INSERT INTO SBP_Money_Balance_Temp
                                                        (
                                                        Cust_Code
                                                        ,Sell_Deposit
                                                        ,Buy_Withdraw
                                                        ,Balance
                                                        ,Matured_Balance
                                                        ,Remarks
                                                        ,Rec_Date
                                                        )
                                                         SELECT 
                                                         Cust_Code
                                                        ,0
                                                        ,Amount
                                                        ,Amount
                                                        ,Amount
                                                        ,Payment_Media
                                                        ,Received_Date
                                                        FROM SBP_Payment_Posting_Request
                                                        WHERE Payment_ID=" + paymentID[1];

            //+ " VALUES('"
            //+ paymentInfoBo.CustCode
            //+ "'," + paymentInfoBo.Amount
            //+ ",0,"
            //+ paymentInfoBo.Amount
            //+ "," + paymentInfoBo.Amount
            //+ ",'" + paymentInfoBo.PaymentMedia
            //+ "','" + paymentInfoBo.RecievedDate.ToShortDateString()
            //+ "');";
            queryUpdateDepPosting = "UPDATE SBP_Payment_Posting_Request"
                               + " SET Approval_Status=1,"
                               + " Payment_Approved_Date='" + cmBal.GetCurrentServerDate().ToString("MM-dd-yyyy") + "'"
                               + " WHERE Payment_ID IN (" + paymentID[0] + "," + paymentID[1] + ")";

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();

                DataTable dt = _dbConnection.ExecuteQuery(queryString_CheckIf);
                if (dt.Rows.Count > 0)
                    isUpdated = Convert.ToBoolean(dt.Rows[0][0].ToString());
                if (isUpdated)
                    throw new Exception("Already Approved!!");

                _dbConnection.ExecuteNonQuery(queryString_Payment_TRWithdraw);
                _dbConnection.ExecuteNonQuery(queryString_Payment_TRDeposit);
                _dbConnection.ExecuteNonQuery(queryString_MBalanceTemp_TRWithdraw);
                _dbConnection.ExecuteNonQuery(queryString_MBalanceTemp_TRDeposit);
                _dbConnection.ExecuteNonQuery(queryUpdateDepPosting);
                _dbConnection.Commit();
            }
            catch (Exception)
            {
                _dbConnection.Rollback();
                throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }

        }
        public void InsertIntoPayment_ForBOAnnualApproval(string[] paymentID)
        {
            string queryString_Payment_withdraw = "";
            string queryString_Payment_Deposit = "";
            string queryString_Payment_Deposit98 = "";
            string queryUpdateDepPosting = "";
            CommonBAL cmBal = new CommonBAL();

            bool isUpdated = false;
            string queryString_CheckIf = string.Empty;
            queryString_CheckIf =
                            @"
                            DECLARE @IsUpdated bit

                            IF 
                                EXISTS (SELECT * FROM SBP_Payment_Posting_Request WHERE [Approval_Status]=1 AND [Payment_ID]=" + paymentID[0] + @")
                                

                            BEGIN                                                                                                                                    
                                SET @IsUpdated=1
                            END
                            ELSE 
                            BEGIN
                                SET @IsUpdated=0
                            END
                            SELECT @IsUpdated                    
           ";

            queryString_Payment_Deposit =
                @"INSERT INTO SBP_Payment
                                                    (
                                                     Cust_code
                                                    ,Amount
                                                    ,Received_Date
                                                    ,Payment_Media
                                                    ,Received_By
                                                    ,Deposit_Withdraw
                                                    ,Voucher_Sl_No
                                                    ,Trans_Reason
                                                    ,Payment_Approved_By
                                                    ,Payment_Approved_Date
                                                    ,Remarks
                                                    ,Entry_Date
                                                    ,Entry_By
                                                    ,Requisition_ID
                                                    ,Entry_Branch_ID
                                                     )
                                                     SELECT 
                                                     Cust_Code
                                                    ,Amount
                                                    ,Received_Date
                                                    ,Payment_Media
                                                    ,Received_By
                                                    ,Deposit_Withdraw
                                                    ,Vouchar_SN
                                                    ,Trans_Reason
                                                    ,Payment_Approved_By
                                                    ,Payment_Approved_Date
                                                    ,Remarks
                                                    ,Entry_Date
                                                    ,Entry_By
                                                    ,Payment_ID
                                                    ,Entry_Branch_ID
                                                    FROM SBP_Payment_Posting_Request
                                                    WHERE Payment_ID=" + paymentID[0];

//            queryString_Payment_Withdraw = @"INSERT INTO SBP_Payment
//                                                (
//                                                Cust_code
//                                                ,Amount
//                                                ,Received_Date
//                                                ,Payment_Media
//                                                ,Received_By
//                                                ,Deposit_Withdraw
//                                                ,Voucher_Sl_No
//                                                ,Trans_Reason
//                                                ,Payment_Approved_By
//                                                ,Payment_Approved_Date
//                                                ,Remarks,Entry_Date
//                                                ,Entry_By
//                                                ,Requisition_ID
//                                                ,Entry_Branch_ID
//                                                )
//                                                SELECT 
//                                                 Cust_Code
//                                                ,Amount
//                                                ,Received_Date
//                                                ,Payment_Media
//                                                ,Received_By
//                                                ,Deposit_Withdraw
//                                                ,Vouchar_SN
//                                                ,Trans_Reason
//                                                ,Payment_Approved_By
//                                                ,Payment_Approved_Date
//                                                ,Remarks
//                                                ,Entry_Date
//                                                ,Entry_By
//                                                ,Payment_ID
//                                                ,Entry_Branch_ID
//                                                FROM SBP_Payment_Posting_Request
//                                                WHERE Payment_ID=" + paymentID[1];

            


            queryUpdateDepPosting = "UPDATE SBP_Payment_Posting_Request"
                               + " SET Approval_Status=1,"
                               + " Payment_Approved_Date='" + cmBal.GetCurrentServerDate().ToString("MM-dd-yyyy") + "',"
                               + " Payment_Approved_By='" + GlobalVariableBO._userName + "'"
                               + " WHERE Payment_ID IN (" + paymentID[0]+ ")";

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();

                DataTable dt = _dbConnection.ExecuteQuery(queryString_CheckIf);
                if (dt.Rows.Count > 0)
                    isUpdated = Convert.ToBoolean(dt.Rows[0][0].ToString());
                if (isUpdated)
                    throw new Exception("Already Updated!!");

                //_dbConnection.ExecuteNonQuery(queryString_Payment_Withdraw);
                _dbConnection.ExecuteNonQuery(queryString_Payment_Deposit);
            
                _dbConnection.ExecuteNonQuery(queryUpdateDepPosting);
                _dbConnection.Commit();
            }
            catch (Exception)
            {
                _dbConnection.Rollback();
                throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }

        }
        public void InsertintoPaymentPosting(PaymentInfoBO paymentInfoBo)
        {
            string queryString = "";
            string queryDeleteWebData = "";

            CommonBAL commonBAL = new CommonBAL();            
            paymentInfoBo.PaymentId = commonBAL.GenerateID("SBP_Payment_Posting_Request", "Payment_ID");
            DataTable dtMaturity = new DataTable();
            int maturityDays = 0;
            dtMaturity = GetPaymentMediaMaturityDay(paymentInfoBo.IsMatureToday, paymentInfoBo.PaymentMedia);
            if (dtMaturity.Rows.Count > 0)
            {
                if (dtMaturity.Rows[0][0] != DBNull.Value)
                    maturityDays = Convert.ToInt32(dtMaturity.Rows[0][0]);
            }
            if (paymentInfoBo.DepositWithdraw == "Withdraw" && paymentInfoBo.PaymentMedia == Indication_PaymentTransaction.Cash)
            {
                queryString = @"INSERT INTO SBP_Payment_Posting_Request(
                                         --Payment_ID
                                        --,
                                        Cust_code
                                        ,Amount
                                        ,Received_Date
                                        ,Payment_Media
                                        ,Maturity_Days
                                        ,Payment_Media_No
                                        ,Payment_Media_Date
                                        ,Bank_ID
                                        ,Bank_Name
                                        ,Branch_ID
                                        ,Bank_Branch 
                                        ,RoutingNo 
                                        ,BankAccNo 
                                        ,Received_By
                                        ,Deposit_Withdraw         
                                        ,Payment_Approved_By           
                                        ,Payment_Approved_Date         
                                        ,Remarks                    
                                        ,Entry_Date          
                                        ,Entry_By                                         
                                        ,Deposit_Bank_Name
                                        ,Deposit_Branch_Name
                                        ,Approval_Status
                                        ,Vouchar_SN
                                        ,Entry_Branch_ID
                                       
                                        )"
                                     +
                                       " VALUES("
                                       //+ paymentInfoBo.PaymentId
                                       //+ ",'" 
                                       +"'"+ paymentInfoBo.CustCode
                                       + "'," + paymentInfoBo.Amount
                                       + ",'" + paymentInfoBo.RecievedDate.ToString("MM-dd-yyyy")
                                       + "','" + paymentInfoBo.PaymentMedia
                                       + "'," + maturityDays
                                       + ",'" + ""  //Payment_Media_No
                                       + "','" + paymentInfoBo.PaymentMediaDate.ToString("MM-dd-yyyy")
                                       + "','" + paymentInfoBo.Bank_ID
                                       + "','" + paymentInfoBo.BankName
                                       + "','" + paymentInfoBo.Branch_ID
                                       + "','" + paymentInfoBo.BranchName
                                       + "','" + paymentInfoBo.RoutingNo
                                       + "','" + paymentInfoBo.BankAccNo
                                       + "','" + paymentInfoBo.RecievedBy
                    // + "','" + ""  //Deposit_Withdraw
                    // + "','" + paymentInfoBo.RecievedBy
                                       + "','" + paymentInfoBo.DepositWithdraw
                                       + "','" + paymentInfoBo.PaymentApprovedBy
                                       + "'," + ((Convert.ToString(paymentInfoBo.PaymentApprovedDate) == string.Empty) ? "null" : "'" + paymentInfoBo.PaymentApprovedDate.Value.ToString("MM-dd-yyyy") + "'")
                                       + ",'" + paymentInfoBo.Remarks
                                       + "',CAST(FLOOR(CAST(GETDATE() AS FLOAT)) AS DATETIME)"
                                       + ",'" + GlobalVariableBO._userName
                                       + "','" + ""
                                       + "','" + ""
                                       + "',0,'" + paymentInfoBo.VoucherSlNo
                                       + "'," + GlobalVariableBO._branchId
                                    
                                       + ")";
            }
            else
            {
                queryString = @"INSERT INTO SBP_Payment_Posting_Request(
                                             --Payment_ID
                                            --,
                                            Cust_code
                                            ,Amount
                                            ,Received_Date
                                            ,Payment_Media
                                            ,Maturity_Days
                                            ,Payment_Media_No
                                            ,Payment_Media_Date
                                            ,Bank_ID
                                            ,Bank_Name
                                            ,Branch_ID
                                            ,Bank_Branch 
                                            ,RoutingNo
                                            ,BankAccNo
                                            ,Received_By
                                            ,Deposit_Withdraw
                                            ,Payment_Approved_By
                                            ,Payment_Approved_Date
                                            ,Remarks
                                            ,Entry_Date
                                            ,Entry_By
                                            ,Deposit_Bank_Name
                                            ,Deposit_Branch_Name
                                            ,Approval_Status
                                            ,Vouchar_SN
                                            ,Entry_Branch_ID
                                           
                                            )"
                                          +
                                         " VALUES("
                                         //+ paymentInfoBo.PaymentId
                                         //+ ",'" 
                                         +"'"+ paymentInfoBo.CustCode
                                         + "'," + paymentInfoBo.Amount
                                         + ",'" + paymentInfoBo.RecievedDate.ToString("MM-dd-yyyy")
                                         + "','" + paymentInfoBo.PaymentMedia
                                         + "'," + maturityDays
                                         + ",'" + paymentInfoBo.PaymentMediaNo
                                         + "','" + paymentInfoBo.PaymentMediaDate.ToString("MM-dd-yyyy")
                                         + "','" + paymentInfoBo.Bank_ID
                                         + "','" + paymentInfoBo.BankName
                                         + "','" + paymentInfoBo.Branch_ID
                                         + "','" + paymentInfoBo.BranchName
                                         + "','" + paymentInfoBo.RoutingNo
                                         + "','" + paymentInfoBo.BankAccNo
                                         + "','" + paymentInfoBo.RecievedBy
                                         + "','" + paymentInfoBo.DepositWithdraw
                                         + "','" + paymentInfoBo.PaymentApprovedBy
                                         + "'," + ((Convert.ToString(paymentInfoBo.PaymentApprovedDate) == string.Empty) ? "null" : "'" + paymentInfoBo.PaymentApprovedDate.Value.ToString("MM-dd-yyyy") + "'")
                                         + ",'" + paymentInfoBo.Remarks + "',CAST(FLOOR(CAST(GETDATE() AS FLOAT)) AS DATETIME),'"
                                         + GlobalVariableBO._userName
                                         + "','" + ""
                                         + "','" + ""
                                         + "',0,'"
                                         + paymentInfoBo.VoucherSlNo
                                         + "'," + GlobalVariableBO._branchId
                                      
                                         + ")";
            }           
            try
            {
                _dbConnection.ConnectDatabase();             
                _dbConnection.ExecuteNonQuery(queryString);             
            }
            catch (Exception ex)
            {
               throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }

        }

        public void InsertintoPaymentPosting(PaymentInfoBO paymentInfoBo, Payment_PostingBO postBo)// For Web
        {
            string queryString = "";
            string queryDeleteWebData = "";
            Int32 AAA = postBo.OnlineOrderNo;

            CommonBAL commonBAL = new CommonBAL();
            Web2014DataForwardBAL webBal=new Web2014DataForwardBAL();
            paymentInfoBo.PaymentId = commonBAL.GenerateID("SBP_Payment_Posting_Request", "Payment_ID");
            DataTable dtMaturity = new DataTable();
            int maturityDays = 0;
            dtMaturity = GetPaymentMediaMaturityDay(paymentInfoBo.IsMatureToday, paymentInfoBo.PaymentMedia);
            if (dtMaturity.Rows.Count > 0)
            {
                if (dtMaturity.Rows[0][0] != DBNull.Value)
                    maturityDays = Convert.ToInt32(dtMaturity.Rows[0][0]);
            }
            if (paymentInfoBo.DepositWithdraw == "Withdraw" && paymentInfoBo.PaymentMedia == Indication_PaymentTransaction.Cash)
            {
                queryString = @"INSERT INTO SBP_Payment_Posting_Request(
                                         --Payment_ID
                                        --,
                                        Cust_code
                                        ,Amount
                                        ,Received_Date
                                        ,Payment_Media
                                        ,Maturity_Days
                                        ,Payment_Media_No
                                        ,Payment_Media_Date
                                        ,Bank_ID
                                        ,Bank_Name
                                        ,Branch_ID
                                        ,Bank_Branch 
                                        ,RoutingNo                                        
                                        ,BankAccNo 
                                        ,Received_By
                                        ,Deposit_Withdraw         
                                        ,Payment_Approved_By           
                                        ,Payment_Approved_Date         
                                        ,Remarks                    
                                        ,Entry_Date          
                                        ,Entry_By                                         
                                        ,Deposit_Bank_Name
                                        ,Deposit_Branch_Name
                                        ,Approval_Status
                                        ,Vouchar_SN
                                        ,Entry_Branch_ID
                                        ,OnlineOrderNo
                                        ,Channel
                                        ,OnlineEntry_Date                                      
                                        )"
                                     +
                                       " VALUES("
                                       //+ paymentInfoBo.PaymentId
                                       //+ ",'" 
                                       +"'"+ paymentInfoBo.CustCode
                                       + "'," + paymentInfoBo.Amount
                                       + ",'" + paymentInfoBo.RecievedDate.ToString("MM-dd-yyyy")
                                       + "','" + paymentInfoBo.PaymentMedia
                                       + "'," + maturityDays
                                       + ",'" + ""  //Payment_Media_No
                                       + "','" + paymentInfoBo.PaymentMediaDate.ToString("MM-dd-yyyy")
                                       + "','" + paymentInfoBo.Bank_ID
                                       + "','" + paymentInfoBo.BankName
                                       + "','" + paymentInfoBo.Branch_ID
                                       + "','" + paymentInfoBo.BranchName
                                       + "','" + paymentInfoBo.RoutingNo                                       
                                       + "','" + paymentInfoBo.BankAccNo
                                       + "','" + paymentInfoBo.RecievedBy
                    // + "','" + ""  //Deposit_Withdraw
                    // + "','" + paymentInfoBo.RecievedBy
                                       + "','" + paymentInfoBo.DepositWithdraw
                                       + "','" + paymentInfoBo.PaymentApprovedBy
                                       + "'," + ((Convert.ToString(paymentInfoBo.PaymentApprovedDate) == string.Empty) ? "null" : "'" + paymentInfoBo.PaymentApprovedDate.Value.ToString("MM-dd-yyyy") + "'")
                                       + ",'" + paymentInfoBo.Remarks
                                       + "',CAST(FLOOR(CAST(GETDATE() AS FLOAT)) AS DATETIME)"
                                       + ",'" + GlobalVariableBO._userName
                                       + "','" + ""
                                       + "','" + ""
                                       + "',0,'" + paymentInfoBo.VoucherSlNo
                                       + "'," + GlobalVariableBO._branchId
                                       + "," + postBo.OnlineOrderNo
                                       + ",'" + postBo.Channel
                                       + "','" + Convert.ToString(postBo.OnlineEntry_Date.Date.Equals(DateTime.MinValue.Date) ? string.Empty : postBo.OnlineEntry_Date.ToString("MM-dd-yyyy") ) 
                                       + "')";
            }
            else
            {
                queryString = @"INSERT INTO SBP_Payment_Posting_Request(
                                             --Payment_ID
                                            --,
                                            Cust_code
                                            ,Amount
                                            ,Received_Date
                                            ,Payment_Media
                                            ,Maturity_Days
                                            ,Payment_Media_No
                                            ,Payment_Media_Date
                                            ,Bank_ID
                                            ,Bank_Name
                                            ,Branch_ID
                                            ,Bank_Branch 
                                            ,RoutingNo
                                            ,BankAccNo
                                            ,Received_By
                                            ,Deposit_Withdraw
                                            ,Payment_Approved_By
                                            ,Payment_Approved_Date
                                            ,Remarks
                                            ,Entry_Date
                                            ,Entry_By
                                            ,Deposit_Bank_Name
                                            ,Deposit_Branch_Name
                                            ,Approval_Status
                                            ,Vouchar_SN
                                            ,Entry_Branch_ID
                                            ,OnlineOrderNo
                                            ,Channel
                                            ,OnlineEntry_Date                                           
                                            )"
                                          +
                                         " VALUES("
                                         //+ paymentInfoBo.PaymentId
                                         //+ ",'" 
                                         +"'"+ paymentInfoBo.CustCode
                                         + "'," + paymentInfoBo.Amount
                                         + ",'" + paymentInfoBo.RecievedDate.ToString("MM-dd-yyyy")
                                         + "','" + paymentInfoBo.PaymentMedia
                                         + "'," + maturityDays
                                         + ",'" + paymentInfoBo.PaymentMediaNo
                                         + "','" + paymentInfoBo.PaymentMediaDate.ToString("MM-dd-yyyy")
                                         + "','" + paymentInfoBo.Bank_ID
                                         + "','" + paymentInfoBo.BankName
                                         + "','" + paymentInfoBo.Branch_ID
                                         + "','" + paymentInfoBo.BranchName
                                         + "','" + paymentInfoBo.RoutingNo
                                         + "','" + paymentInfoBo.BankAccNo
                                         + "','" + paymentInfoBo.RecievedBy
                                         + "','" + paymentInfoBo.DepositWithdraw
                                         + "','" + paymentInfoBo.PaymentApprovedBy
                                         + "'," + ((Convert.ToString(paymentInfoBo.PaymentApprovedDate) == string.Empty) ? "null" : "'" + paymentInfoBo.PaymentApprovedDate.Value.ToString("MM-dd-yyyy") + "'")
                                         + ",'" + paymentInfoBo.Remarks + "',CAST(FLOOR(CAST(GETDATE() AS FLOAT)) AS DATETIME),'"
                                         + GlobalVariableBO._userName
                                         + "','" + ""
                                         + "','" + ""
                                         + "',0,'"
                                         + paymentInfoBo.VoucherSlNo
                                         + "'," + GlobalVariableBO._branchId
                                         + "," + postBo.OnlineOrderNo
                                         + ",'" + postBo.Channel
                                         + "','" + Convert.ToString(postBo.OnlineEntry_Date.Date.Equals(DateTime.MinValue.Date) ? string.Empty : postBo.OnlineEntry_Date.ToString("MM-dd-yyyy")  )
                                         + "')";
            }

            if (postBo.OnlineOrderNo != 0 && postBo.OnlineOrderNo != null)
            {
                queryDeleteWebData = webBal.DeleteFrom_Web2014_WithdrawalRequest_Temp(postBo.OnlineOrderNo);
            }
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();
                _dbConnection.ExecuteNonQuery(queryString);
                if (postBo.OnlineOrderNo != 0 && postBo.OnlineOrderNo != null)
                {
                    _dbConnection.ExecuteNonQuery(queryDeleteWebData);
                }
                _dbConnection.Commit();
            }
            catch (Exception ex)
            {
                _dbConnection.Rollback();
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }

        }

        public void InsertDW_ReturnInfo_IntoPaymentPosting(PaymentInfoBO paymentInfoBo)//, string depositBank, string depositBranch)
        {
            string queryString = "";

            CommonBAL commonBAL = new CommonBAL();
            paymentInfoBo.PaymentId = commonBAL.GenerateID("SBP_Payment_Posting_Request", "Payment_ID");
            //DataTable dtMaturity = new DataTable();
            //int maturityDays = 0;
            //dtMaturity = GetPaymentMediaMaturityDay(paymentInfoBo.IsMatureToday, paymentInfoBo.PaymentMedia);
            //if (dtMaturity.Rows.Count > 0)
            //{
            //    if (dtMaturity.Rows[0][0] != DBNull.Value)
            //        maturityDays = Convert.ToInt32(dtMaturity.Rows[0][0]);
            //}
            //if (paymentInfoBo.DepositWithdraw == "Withdraw" && paymentInfoBo.PaymentMedia == Indication_PaymentTransaction.Cash)
            //{
            //    queryString = "INSERT INTO SBP_Payment_Posting_Request(     Payment_ID               ,       Cust_code,Amount         ,        Received_Date       ,                  Payment_Media                         ,            Maturity_Days           ,  Payment_Media_No  ,  Payment_Media_Date,           Bank_Name                                ,Bank_Branch ,   RoutingNo ,  BankAccNo ,  Received_By,        Deposit_Withdraw         ,         Payment_Approved_By           ,           Payment_Approved_Date         ,               Remarks                    ,            Entry_Date          ,Entry_By                                         ,           Deposit_Bank_Name,Deposit_Branch_Name,Approval_Status,Vouchar_SN,Entry_Branch_ID)" +
            //        " VALUES(" + paymentInfoBo.PaymentId + ",'" + paymentInfoBo.CustCode + "'," + paymentInfoBo.Amount + ",'" + paymentInfoBo.RecievedDate.ToString("MM-dd-yyyy") + "','" + paymentInfoBo.PaymentMedia + "'," + maturityDays + ",'" + "" + "','" + paymentInfoBo.PaymentMediaDate.ToString("MM-dd-yyyy") + "','" + paymentInfoBo.RoutingNo + "','" + paymentInfoBo.BankAccNo + "','" + "" + "','" + "" + "','" + paymentInfoBo.RecievedBy + "','" + paymentInfoBo.DepositWithdraw + "','" + paymentInfoBo.PaymentApprovedBy + "'," + ((Convert.ToString(paymentInfoBo.PaymentApprovedDate) == string.Empty) ? "null" : "'" + paymentInfoBo.PaymentApprovedDate.Value.ToString("MM-dd-yyyy") + "'") + ",'" + paymentInfoBo.Remarks + "',CAST(FLOOR(CAST(GETDATE() AS FLOAT)) AS DATETIME),'" + GlobalVariableBO._userName + "','" + "" + "','" + "" + "',0,'" + paymentInfoBo.VoucherSlNo + "'," + GlobalVariableBO._branchId + ")";
            //}
            //else
            //{
            //queryString = "INSERT INTO SBP_Payment_Posting_Request(Payment_ID,Cust_code,Amount,Received_Date,Payment_Media,Maturity_Days,Payment_Media_No,Payment_Media_Date,Bank_Name,Bank_Branch,RoutingNo,BankAccNo,Received_By,Deposit_Withdraw,Payment_Approved_By,Payment_Approved_Date,Remarks,Entry_Date,Entry_By,Deposit_Bank_Name,Deposit_Branch_Name,Approval_Status,Vouchar_SN,Entry_Branch_ID)" +
            //    " VALUES(" + paymentInfoBo.PaymentId + ",'" + paymentInfoBo.CustCode + "'," + paymentInfoBo.Amount + ",'" + paymentInfoBo.RecievedDate.ToString("MM-dd-yyyy") + "','" + paymentInfoBo.PaymentMedia + "'," + maturityDays + ",'" + paymentInfoBo.PaymentMediaNo + "','" + paymentInfoBo.PaymentMediaDate.ToString("MM-dd-yyyy") + "','" + paymentInfoBo.BankName + "','" + paymentInfoBo.BranchName + "','" + paymentInfoBo.RoutingNo + "','" + paymentInfoBo.BankAccNo + "','" + paymentInfoBo.RecievedBy + "','" + paymentInfoBo.DepositWithdraw + "','" + paymentInfoBo.PaymentApprovedBy + "'," + ((Convert.ToString(paymentInfoBo.PaymentApprovedDate) == string.Empty) ? "null" : "'" + paymentInfoBo.PaymentApprovedDate.Value.ToString("MM-dd-yyyy") + "'") + ",'" + paymentInfoBo.Remarks + "',CAST(FLOOR(CAST(GETDATE() AS FLOAT)) AS DATETIME),'" + GlobalVariableBO._userName + "','" + paymentInfoBo.BankName + "','" + paymentInfoBo.BranchName + "',0,'" + paymentInfoBo.VoucherSlNo + "'," + GlobalVariableBO._branchId + ")";
            queryString = @"INSERT INTO SBP_Payment_Posting_Request
                            (
                             --Payment_ID
                            --,
                            Cust_code
                            ,Amount
                            ,Received_Date
                            ,Payment_Media
                            ,Payment_Media_No
                            ,Payment_Media_Date
                            ,Bank_Name
                            ,Bank_Branch
                            ,RoutingNo
                            ,BankAccNo
                            ,Deposit_Withdraw
                            ,Vouchar_SN
                            ,Trans_Reason
                            ,Entry_Branch_ID
                            ) 
                            VALUES
                            ( "
                            //+ paymentInfoBo.PaymentId
                            //+ ",'" 
                            +"'"+ paymentInfoBo.CustCode
                            + "'," + paymentInfoBo.Amount
                            + ",'" + paymentInfoBo.RecievedDate.ToString("MM-dd-yyyy")
                            + "','" + paymentInfoBo.PaymentMedia
                            + "','" + paymentInfoBo.PaymentMediaNo
                            + "','" + paymentInfoBo.PaymentMediaDate.ToString("MM-dd-yyyy")
                            + "','" + paymentInfoBo.BankName
                            + "','" + paymentInfoBo.BranchName
                            + "','" + paymentInfoBo.RoutingNo
                            + "','" + paymentInfoBo.BankAccNo
                            + "','" + paymentInfoBo.DepositWithdraw
                            + "','" + paymentInfoBo.VoucherSlNo
                            + "','" + paymentInfoBo.TransReason
                            + "'," + GlobalVariableBO._branchId
                            + ")";

            //}
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(queryString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }

        }


        #region Accrued Current Balance

        public float GetCurrentBalaneforAccrued(string custCode)
        {
            float currentBalance = 0;
            DataTable dataTable;
            string queryString = @"Select ISNULL(SUM(Amount),0) AS 'AccruedAmount' from  SBP_Payment_Accrued  Where Cust_Code='" + custCode + @"' AND Status =0";

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

            if (dataTable.Rows[0][0] != DBNull.Value)
                currentBalance = float.Parse(dataTable.Rows[0][0].ToString());

            return currentBalance;

        }

        #endregion

        public DataTable GetAllWithdrawForApproval()
        {
            DataTable dataTable = new DataTable();
            string queryString = "";
            //queryString = "SELECT Payment_ID,Cust_Code AS 'Cust',Amount,Payment_Media AS 'P.Media',Deposit_Withdraw AS 'T.Type',Vouchar_SN AS 'Voucher',Received_Date AS 'Recv.Date',Payment_Media_No AS 'Cheq.No',Payment_Media_Date AS 'Cheq.Date',Bank_Name AS 'Bank',Bank_Branch AS 'Branch',ISNULL(RoutingNo,'') AS 'Rout.No',ISNULL(BankAccNo,'') AS 'AccNo',Received_By AS 'Recv.By',"
            //    //+"Maturity_Days AS 'Matu. Day',"
            //+ "Remarks,(SELECT Cust_Status FROM SBP_Cust_Status,dbo.SBP_Customers WHERE SBP_Cust_Status.Cust_Status_ID=SBP_Customers.Cust_Status_ID AND SBP_Customers.Cust_Code=SBP_Payment_Posting_Request.Cust_Code) AS 'Status',(SELECT Branch_Name FROM SBP_Broker_Branch WHERE Branch_ID=SBP_Payment_Posting_Request.Entry_Branch_ID) AS 'Dep.Branch',Entry_Branch_ID,Trans_Reason FROM SBP_Payment_Posting_Request WHERE Approval_Status=0 AND Deposit_Withdraw='Withdraw'";
            queryString = @"SELECT pay.Payment_ID,pay.Cust_Code AS 'Cust',pay.Amount,pay.Payment_Media AS 'P.Media',pay.Deposit_Withdraw AS 'T.Type',pay.Vouchar_SN AS 'Voucher',pay.Received_Date AS 'Recv.Date',pay.Payment_Media_No AS 'Cheq.No',pay.Payment_Media_Date AS 'Cheq.Date',pay.Bank_ID,pay.Bank_Name AS 'Bank',pay.Branch_ID ,pay.Bank_Branch AS 'Branch',ISNULL(pay.RoutingNo,'') AS 'Rout.No',ISNULL(pay.BankAccNo,'') AS 'AccNo',pay.Received_By AS 'Recv.By',pay.Remarks,(SELECT Cust_Status FROM SBP_Cust_Status,dbo.SBP_Customers WHERE SBP_Cust_Status.Cust_Status_ID=SBP_Customers.Cust_Status_ID AND SBP_Customers.Cust_Code=pay.Cust_Code) AS 'Status',(SELECT Branch_Name FROM SBP_Broker_Branch WHERE Branch_ID=pay.Entry_Branch_ID) AS 'Dep.Branch',pay.Entry_Branch_ID,pay.Trans_Reason 
                            FROM SBP_Payment_Posting_Request AS pay 
                            WHERE 
                            (
                            NOT EXISTS(SELECT t.* FROM SBP_Payment_Posting_Request AS t WHERE t.Payment_ID=pay.Payment_ID AND t.Payment_Media LIKE '%Return%' )
                            AND
                            pay.Deposit_Withdraw='Withdraw'
                            AND
                            pay.Approval_Status=0
                            AND
                            pay.Payment_Media<>'TR' 
                            AND pay.Vouchar_SN <> 'OCC-C' 
                            AND  ISNULL(pay.Vouchar_SN,'') NOT LIKE '%BAC%'
                            AND ISNULL(pay.Trans_Reason,'') NOT LIKE '%BAC%'
                            AND Payment_Media<>'"+Indication_PaymentTransaction.TRIPO+@"'
                            )
                            OR
                            (
                            EXISTS(SELECT t.* FROM SBP_Payment_Posting_Request AS t WHERE t.Payment_ID=pay.Payment_ID AND t.Payment_Media LIKE '%Return%' )
                            AND 
                            Deposit_Withdraw='Deposit'
                            AND
                            pay.Approval_Status=0 
                            AND
                            pay.Payment_Media<>'TR'
                            AND pay.Vouchar_SN <> 'OOC-C' 
                            AND  ISNULL(pay.Vouchar_SN,'') NOT LIKE '%BAC%'
                            AND ISNULL(pay.Trans_Reason,'') NOT LIKE '%BAC%'
                            AND Payment_Media<>'" + Indication_PaymentTransaction.TRIPO + @"'
                            )
                            ORDER BY Payment_Media";
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

        public DataTable GetAllTransferForApproval()
        {
            DataTable dataTable = new DataTable();
            string queryString = "";
            queryString = @"SELECT 
                            Payment_ID
                            ,Cust_Code AS 'Cust'
                            ,Amount
                            ,Payment_Media AS 'P.Media'
                            ,Deposit_Withdraw AS 'T.Type'
                            ,Vouchar_SN AS 'Voucher'
                            ,Received_Date AS 'Recv.Date'
                            ,Payment_Media_No AS 'Cheq.No'
                            ,Payment_Media_Date AS 'Cheq.Date'
                            ,Bank_ID
                            ,Bank_Name AS 'Bank'
                            ,Branch_ID
                            ,Bank_Branch AS 'Branch'
                            ,ISNULL(RoutingNo,'') AS 'Rout.No'
                            ,ISNULL(BankAccNo,'') AS 'AccNo'
                            ,Received_By AS 'Recv.By'
                            ,Remarks
                            ,(
	                            SELECT Cust_Status 
	                            FROM SBP_Cust_Status,dbo.SBP_Customers 
	                            WHERE SBP_Cust_Status.Cust_Status_ID=SBP_Customers.Cust_Status_ID 
	                            AND SBP_Customers.Cust_Code=SBP_Payment_Posting_Request.Cust_Code
                            ) AS 'Status'
                            ,
                            (
	                            SELECT Branch_Name 
	                            FROM SBP_Broker_Branch 
	                            WHERE Branch_ID=SBP_Payment_Posting_Request.Entry_Branch_ID
                            ) AS 'Dep.Branch'
                            ,Entry_Branch_ID
                            ,Trans_Reason 
                            FROM SBP_Payment_Posting_Request 
                            WHERE Approval_Status=0 AND Payment_Media='TR'
                            AND Payment_Media <> 'TRIPO'
                            ORDER BY Vouchar_SN,Deposit_Withdraw";
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
        public DataTable GetAllBOAnnualChargeForApproval()
        {
            DataTable dataTable = new DataTable();
            string queryString = "";
            queryString =
                @"SELECT 
                     T.Payment_ID
                    ,T.Cust_Code AS 'Cust'
                    ,T.Amount
                    ,T.Payment_Media AS 'P.Media'
                    ,T.Deposit_Withdraw AS 'T.Type'
                    ,T.Vouchar_SN AS 'Voucher'
                    ,T.Received_Date AS 'Recv.Date'
                    ,T.Payment_Media_No AS 'Cheq.No'
                    ,T.Payment_Media_Date AS 'Cheq.Date'
                    ,T.Bank_ID
                    ,T.Bank_Name AS 'Bank'
                    ,T.Branch_ID
                    ,T.Bank_Branch AS 'Branch'
                    ,ISNULL(T.RoutingNo,'') AS 'Rout.No'
                    ,ISNULL(T.BankAccNo,'') AS 'AccNo'
                    ,T.Received_By AS 'Recv.By'
                    ,T.Remarks
                    ,(
                        SELECT Cust_Status 
                        FROM SBP_Cust_Status,dbo.SBP_Customers 
                        WHERE SBP_Cust_Status.Cust_Status_ID=SBP_Customers.Cust_Status_ID 
                        AND SBP_Customers.Cust_Code=T.Cust_Code
                    ) AS 'Status'
                    ,
                    (
                        SELECT Branch_Name 
                        FROM SBP_Broker_Branch 
                        WHERE Branch_ID=T.Entry_Branch_ID
                    ) AS 'Dep.Branch'
                    ,T.Entry_Branch_ID
                    ,T.Trans_Reason 
                    ,T.srt_ID
                    FROM
                    (
                    --SELECT wth.*,wth.Payment_ID AS srt_ID
                    --FROM 
                    --(
                    --    SELECT *
                    --    FROM dbo.SBP_Payment_Posting_Request
                    --    WHERE Trans_Reason LIKE 'BAC%' AND Deposit_Withdraw='Withdraw'
                    --    AND Payment_Media='cash'
                    --    AND Approval_Status=0
                    --) AS wth
                    --JOIN
                    --(
                    --    SELECT *
                    --    FROM dbo.SBP_Payment_Posting_Request
                    --    WHERE Trans_Reason LIKE 'BAC%' AND Deposit_Withdraw='Deposit'
                    --   AND REVERSE(SUBSTRING(REVERSE(Trans_Reason),0,CHARINDEX('_',REVERSE(Trans_Reason))))<>'0'
                    --    AND Payment_Media='cash' 
                    --    AND Approval_Status=0
                    --) AS dps
                    --ON
                    --Convert(Varchar(50),wth.Payment_ID)=REPLACE(dps.Trans_Reason,wth.Vouchar_SN+'_','')
                    --UNION
                    SELECT dps.*,dps.Payment_ID AS srt_ID
                    FROM 
                    --(
                    --    SELECT *
                    --    FROM dbo.SBP_Payment_Posting_Request
                    --    WHERE Trans_Reason LIKE 'BAC%' AND Deposit_Withdraw='Withdraw'
                    --    AND Payment_Media='cash'
                    --    AND Approval_Status=0
                    --) AS wth
                    --JOIN
                    (
                        SELECT *
                        FROM dbo.SBP_Payment_Posting_Request
                        WHERE Trans_Reason LIKE 'BAC%' AND Deposit_Withdraw='Deposit'
                        AND REVERSE(SUBSTRING(REVERSE(Trans_Reason),0,CHARINDEX('_',REVERSE(Trans_Reason))))<>'0'
                        AND Payment_Media='cash'
                        AND Approval_Status=0
                        AND Cust_Code IN (Select cust.Cust_Code From SBP_Customers as cust Where cust.Cust_Status_ID=3)
                    ) AS dps
                    --ON
                    --Convert(Varchar(50),wth.Payment_ID)=REPLACE(dps.Trans_Reason,wth.Vouchar_SN+'_','')
                    ) AS T
                    ORDER BY T.srt_ID";
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

        public DataTable GetAllDepositForApproval()
        {
            DataTable dataTable = new DataTable();
            string queryString = "";
            // string queryString = @"GetDeposit_ReturnForApproval";
            //queryString = "SELECT Payment_ID,Cust_Code AS 'Cust',Amount,Payment_Media AS 'P. Media',Deposit_Withdraw AS 'Trans. Type',Received_Date AS 'Recv. Date',Payment_Media_No AS 'Cheq. No.',Payment_Media_Date AS 'Cheq. Date',Bank_Name AS 'Bank',Bank_Branch AS 'Branch',ISNULL(RoutingNo,'') AS 'Rout. No',ISNULL(BankAccNo,'') AS 'Acc No',Received_By AS 'Recv. By',"
            ////+"Maturity_Days AS 'Matu Day',"
            //+"Remarks,(SELECT Cust_Status FROM SBP_Cust_Status,dbo.SBP_Customers WHERE SBP_Cust_Status.Cust_Status_ID=SBP_Customers.Cust_Status_ID AND SBP_Customers.Cust_Code=SBP_Payment_Posting_Request.Cust_Code) AS 'Acc Status',(SELECT Branch_Name FROM SBP_Broker_Branch WHERE Branch_ID=SBP_Payment_Posting_Request.Entry_Branch_ID) AS 'Entry Branch',Entry_Branch_ID FROM SBP_Payment_Posting_Request WHERE Approval_Status=0 AND Deposit_Withdraw='Deposit'"; 
            queryString = @"SELECT pay.Payment_ID,pay.Cust_Code AS 'Cust',pay.Amount,pay.Payment_Media AS 'P.Media',pay.Deposit_Withdraw AS 'T.Type',pay.Vouchar_SN AS 'Voucher',pay.Received_Date AS 'Recv.Date',pay.Payment_Media_No AS 'Cheq.No',pay.Payment_Media_Date AS 'Cheq.Date',pay.Bank_ID,pay.Bank_Name AS 'Bank',pay.Branch_ID ,pay.Bank_Branch AS 'Branch',ISNULL(pay.RoutingNo,'') AS 'Rout.No',ISNULL(pay.BankAccNo,'') AS 'AccNo',pay.Received_By AS 'Recv.By',pay.Remarks,(SELECT Cust_Status FROM SBP_Cust_Status,dbo.SBP_Customers WHERE SBP_Cust_Status.Cust_Status_ID=SBP_Customers.Cust_Status_ID AND SBP_Customers.Cust_Code=pay.Cust_Code) AS 'Status',(SELECT Branch_Name FROM SBP_Broker_Branch WHERE Branch_ID=pay.Entry_Branch_ID) AS 'Dep.Branch',pay.Entry_Branch_ID,pay.Trans_Reason 
                            FROM SBP_Payment_Posting_Request AS pay 
                            WHERE 
                            (
                            NOT EXISTS(SELECT t.* FROM SBP_Payment_Posting_Request AS t WHERE t.Payment_ID=pay.Payment_ID AND t.Payment_Media LIKE '%Return%' )
                            AND
                            pay.Deposit_Withdraw='Deposit'
                            AND
                            pay.Approval_Status=0
                            AND
                            pay.Payment_Media<>'TR' 
                            AND pay.Vouchar_SN <> 'OCC-C' 
                            AND  ISNULL(pay.Vouchar_SN,'') NOT LIKE '%BAC%'
                            AND ISNULL(pay.Trans_Reason,'') NOT LIKE '%BAC%'
                            AND Payment_Media NOT like '%TRIPO%'
                            )
                            OR
                            (
                            EXISTS(SELECT t.* FROM SBP_Payment_Posting_Request AS t WHERE t.Payment_ID=pay.Payment_ID AND t.Payment_Media LIKE '%Return%' )
                            AND 
                            Deposit_Withdraw='Withdraw'
                            AND
                            pay.Approval_Status=0 
                            AND
                            pay.Payment_Media<>'TR'
                            AND pay.Vouchar_SN <> 'OCC-C' 
                            AND  ISNULL(pay.Vouchar_SN,'') NOT LIKE '%BAC%'
                            AND ISNULL(pay.Trans_Reason,'') NOT LIKE '%BAC%'
                            AND Payment_Media NOT like '%TRIPO%'
                            )
                            ORDER BY Payment_Media";
            try
            {
                _dbConnection.ConnectDatabase();
                //_dbConnection.ActiveStoredProcedure();
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

        public int Get_PaymentIdFromPayment_By_PaymentPostingPaymentId(int payment_RequisitionId)
        {
            int Payment_paymentId = -1;
            DataTable data = new DataTable();
            string query = @"SELECT p.[Payment_ID]
                            FROM [SBP_Payment] AS p
                            JOIN SBP_Payment_Posting_Request AS pp
                            ON 
                            p.Requisition_ID=pp.Payment_ID
                            AND p.Payment_Media=pp.Payment_Media
                            AND p.Deposit_Withdraw=pp.Deposit_Withdraw
                            WHERE Requisition_ID=" + payment_RequisitionId;
            _dbConnection.ConnectDatabase();
            data = _dbConnection.ExecuteQuery(query);
            if (data.Rows.Count > 0)
            {
                Payment_paymentId = Convert.ToInt32(data.Rows[0][0].ToString());
            }
            return Payment_paymentId;
        }
        
        public void ApprovedSingleWithdraw(string paymentId, int parentPaymentId_FromPayPostReq_ForReturnTrans)
        {
            try
            {
                string UpdatePaymentPostingReq = string.Empty;
                string InsertPayment = string.Empty;
                string InsertMoneyBalance = string.Empty;
                bool isUpdated = false;
                string queryString_CheckIf = string.Empty;
                queryString_CheckIf =
                            @"
                            DECLARE @IsUpdated bit

                            IF 
                                EXISTS (SELECT * FROM SBP_Payment_Posting_Request WHERE [Approval_Status]=1 AND [Payment_ID]=" + paymentId + @")

                            BEGIN                                                                                                                                    
                                SET @IsUpdated=1
                            END
                            ELSE 
                            BEGIN
                                SET @IsUpdated=0
                            END
                            SELECT @IsUpdated                    
                ";

                UpdatePaymentPostingReq = GetQueryString_UpdateDepositPosting(paymentId);
                InsertPayment = GetQueryString_InsertPayment(paymentId, parentPaymentId_FromPayPostReq_ForReturnTrans);
                InsertMoneyBalance = GetQueryString_Withdraw_InsertMoneyBalance(paymentId);
                try
                {
                    _dbConnection.ConnectDatabase();
                    _dbConnection.StartTransaction();
                    
                    DataTable dt = _dbConnection.ExecuteQuery(queryString_CheckIf);
                    if (dt.Rows.Count > 0)
                        isUpdated = Convert.ToBoolean(dt.Rows[0][0].ToString());
                    if (isUpdated)
                        throw new Exception("Already Approved!!");
                    
                    _dbConnection.ExecuteNonQuery(UpdatePaymentPostingReq);
                    _dbConnection.ExecuteNonQuery(InsertPayment);
                    _dbConnection.ExecuteNonQuery(InsertMoneyBalance);
                    _dbConnection.Commit();
                }
                catch (Exception ex)
                {
                    _dbConnection.Rollback();
                    throw new Exception(ex.Message);
                }
                finally
                {
                    _dbConnection.CloseDatabase();
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public void ApprovedSingleWithdraw(string paymentId, int parentPaymentId_FromPayPostReq_ForReturnTrans, PaymentInfoBO bo, int ChargeID, string ChargeName, double Req_Amount)
        {
            try
            {
                double doubleTryParse;
                string UpdatePaymentPostingReq = string.Empty;
                string InsertPayment = string.Empty;
                string InsertMoneyBalance = string.Empty;
                string ApplyTransCharge = string.Empty;
                string ApplyTransChargeToMoneyBal = string.Empty;
                string ChargeType = string.Empty;
                string TransReason = string.Empty;
                double Charge_Rate = 0.00;
                double Charge_Amount = 0.00;

                bool isChargeApplied = true;

                DataTable dt = new DataTable();
                PaymentInfoBAL payBal = new PaymentInfoBAL();


                UpdatePaymentPostingReq = GetQueryString_UpdateDepositPosting(paymentId);
                InsertPayment = GetQueryString_InsertPayment(paymentId, parentPaymentId_FromPayPostReq_ForReturnTrans);
                InsertMoneyBalance = GetQueryString_Withdraw_InsertMoneyBalance(paymentId);
                //Switching Whether Charge Apply/Not
                dt = GetTransactionBasedCharges(ChargeID, ChargeName, Req_Amount);
                if (dt.Rows.Count > 0)
                {
                    ChargeType = Indication_TransactioBasedCharge.ChargeTypeList.Where(t => t.Key == ChargeName).Select(t => t.Value).SingleOrDefault();
                    TransReason = Indication_TransactioBasedCharge.TransReasonList.Where(t => t.Key == ChargeName).Select(t => t.Value).SingleOrDefault();

                    if (ChargeType == Indication_TransactioBasedCharge.Charge_Rate)
                    {
                        if (double.TryParse(dt.Rows[0]["Charge_Rate"].ToString(), out doubleTryParse))
                            Charge_Rate = doubleTryParse;
                    }
                    else if (ChargeType == Indication_TransactioBasedCharge.Charge_Amount)
                    {
                        if (double.TryParse(dt.Rows[0]["Charge_Amount"].ToString(), out doubleTryParse))
                            Charge_Amount = doubleTryParse;
                    }

                    if ((ChargeType == Indication_TransactioBasedCharge.Charge_Amount && Charge_Amount == 0) || (ChargeType == Indication_TransactioBasedCharge.Charge_Rate && Charge_Rate == 0))
                        isChargeApplied = false;

                    if (Indication_TransactioBasedCharge.ExceptionString.GetValues(Indication_TransactioBasedCharge.BankClearing).ToList().Contains(bo.BankName))
                        isChargeApplied = false;
                }

                //Commented By Shahrior On 17June2013
                //if (!payBal.IsLockedVoucherLockState() && isChargeApplied)
                //{
                //    payBal.LockVoucherNo();
                //    voucherNo = payBal.GenerateSerial();
                //}
                //else if (isChargeApplied && payBal.IsLockedVoucherLockState()) { throw new Exception("SomeOne Lock Auto Vuocher!! Please Try Later !!"); }

                if (isChargeApplied)
                {
                    bo.VoucherSlNo = Indication_TransactioBasedCharge.VoucherSLnoList.Where(t => t.Key == ChargeName).Select(t => t.Value).SingleOrDefault();
                    bo.Amount = (float)(ChargeType == Indication_TransactioBasedCharge.Charge_Rate ? Charge_Rate : Charge_Amount);
                    bo.TransReason = TransReason + '_' + bo.PaymentMediaNo;
                    ApplyTransCharge = GetQueryString_ApplyCharges(bo);
                    ApplyTransChargeToMoneyBal = GetQueryString_TransCharge_InsertMoneyBalance(bo.CustCode, bo.RecievedDate, bo.RecievedBy, ChargeID, ChargeName, Req_Amount);
                }
                try
                {
                    _dbConnection.ConnectDatabase();
                    _dbConnection.StartTransaction();
                    _dbConnection.ExecuteNonQuery(UpdatePaymentPostingReq);
                    _dbConnection.ExecuteNonQuery(InsertPayment);
                    _dbConnection.ExecuteNonQuery(InsertMoneyBalance);
                    if (isChargeApplied)
                    {
                        _dbConnection.ExecuteNonQuery(ApplyTransCharge);
                        _dbConnection.ExecuteNonQuery(ApplyTransChargeToMoneyBal);
                    }
                    _dbConnection.Commit();
                }
                catch (Exception ex)
                {
                    _dbConnection.Rollback();
                    throw new Exception(ex.Message);
                }
                finally
                {
                    _dbConnection.CloseDatabase();
                }

                //if(isChargeApplied)
                //{
                //    payBal.UpdateSerialNo();
                //    payBal.UnLockVoucherNo();
                //}
            }
            catch (Exception ex)
            {
                PaymentInfoBAL payBal = new PaymentInfoBAL();
                //if (payBal.IsLockedVoucherLockState())
                //{
                //    payBal.UnLockVoucherNo();
                //}
                throw new Exception(ex.Message);
            }
        }

        //        public void ApprovedSingleWithdraw(int paymentId, int parentPaymentId_FromPayPostReq_ForReturnTrans, string QryString_TransCharge)
        //        {
        //            CommonBAL cmBal = new CommonBAL();
        //            string queryUpdateDepPosting = "";
        //            string queryInsertPayment = "";
        //            string queryStringTemp = "";
        //            string queryStringTransChages = "";


        //            int parentPaymentID_FromPayment_ForReturnTrans = -1;
        //            string _payment_Trans_Reason;
        //            parentPaymentID_FromPayment_ForReturnTrans = Get_PaymentIdFromPayment_By_PaymentPostingPaymentId(parentPaymentId_FromPayPostReq_ForReturnTrans);
        //            _payment_Trans_Reason = Indication_PaymentTransaction.Return_Indicator + "_" + parentPaymentID_FromPayment_ForReturnTrans.ToString();

        //            queryUpdateDepPosting = "UPDATE SBP_Payment_Posting_Request"
        //                                           + " SET Approval_Status=1,"
        //                                           + " Payment_Approved_Date='" + cmBal.GetCurrentServerDate().ToString("MM-dd-yyyy") + "'"
        //                                           + " WHERE Payment_ID=" + paymentId + "";

        //            if (parentPaymentID_FromPayment_ForReturnTrans != -1)
        //            {
        //                queryInsertPayment = @" INSERT INTO dbo.SBP_Payment                                        
        //                                        SELECT 
        //                                          p.[Cust_Code]
        //                                        , p.[Amount]
        //                                        , p.[Received_Date]
        //                                        , p.[Payment_Media]
        //                                        , p.[Payment_Media_No]
        //                                        , p.[Payment_Media_Date]
        //                                        , p.[Bank_Name]
        //                                        , p.[Bank_Branch]
        //                                        , p.[Received_By]
        //                                        , p.[Deposit_Withdraw]
        //                                        , p.[Payment_Approved_By]
        //                                        , p.[Payment_Approved_Date]
        //                                        , p.[Vouchar_SN]
        //                                        ,'"+ _payment_Trans_Reason +@"' 
        //                                        , p.[Remarks]
        //                                        ,CAST(FLOOR(CAST(GETDATE() AS FLOAT)) AS DATETIME)
        //                                        ,'"+GlobalVariableBO._userName+@"'
        //                                        , p.[Maturity_Days]
        //                                        , p.[Payment_ID]
        //                                        ,'"+GlobalVariableBO._branchId+@"' 
        //                                        FROM  SBP_Payment_Posting_Request AS p
        //                                        WHERE
        //                                        p.Payment_ID="+ paymentId+"";
        //            }
        //            else
        //            {
        //                queryInsertPayment = "INSERT INTO SBP_Payment("
        //                                           + "Cust_code"
        //                                           + ",Amount"
        //                                           + ",Received_Date"
        //                                           + ",Payment_Media"
        //                                           + ",Maturity_Days"
        //                                           + ",Payment_Media_No"
        //                                           + ",Payment_Media_Date"
        //                                           + ",Bank_Name"
        //                                           + ",Bank_Branch"
        //                                           + ",received_By"
        //                                           + ",Deposit_Withdraw"
        //                                           + ",Payment_Approved_By"
        //                                           + ",Payment_Approved_Date"
        //                                           + ",Voucher_Sl_No"
        //                                           + ",Remarks"
        //                                           + ",Entry_Date"
        //                                           + ",Entry_By"
        //                                           + ",Requisition_ID"
        //                                           + ",Entry_Branch_ID"
        //                                           + ")"
        //                                           +
        //                                           "SELECT "
        //                                           + "Cust_Code"
        //                                           + ",Amount"
        //                                           + ",Received_Date"
        //                                           + ",Payment_Media"
        //                                           + ",Maturity_Days"
        //                                           + ",Payment_Media_No"
        //                                           + ",Payment_Media_Date"
        //                                           + ",Bank_Name"
        //                                           + ",Bank_Branch"
        //                                           + ",Received_By"
        //                                           + ",Deposit_Withdraw"
        //                                           + ",Payment_Approved_By"
        //                                           + ",Payment_Approved_Date"
        //                                           + ",Vouchar_SN"
        //                                           + ",Remarks"
        //                                           + ",CAST(FLOOR(CAST(GETDATE() AS FLOAT)) AS DATETIME)"
        //                                           + ",'" + GlobalVariableBO._userName + "'"
        //                                           + "," + paymentId
        //                                           + ",Entry_Branch_ID "
        //                                           + "FROM SBP_Payment_Posting_Request "
        //                                           + "WHERE Payment_ID=" + paymentId + "";

        //            }
        //            // string queryStringTemp = " INSERT INTO SBP_Money_Balance_Temp(Cust_Code,Sell_Deposit,Buy_Withdraw,Balance,Matured_Balance,Remarks,Rec_Date) SELECT Cust_Code,Amount,0,Amount,Amount,Payment_Media,Received_Date FROM SBP_Payment_Posting_Request WHERE Payment_Id=" + paymentId + "";
        //            //queryStringTemp = " INSERT INTO SBP_Money_Balance_Temp("
        //            //                           + " Cust_Code"
        //            //                           + ",Sell_Deposit"
        //            //                           + ",Buy_Withdraw"
        //            //                           + ",Balance"
        //            //                           + ",Matured_Balance"
        //            //                           + ",Remarks"
        //            //                           + ",Rec_Date"
        //            //                           + ")"

        //            //                           + " SELECT"
        //            //                          + " Cust_Code"
        //            //                          + " ,SUM("
        //            //                          + " CASE"
        //            //                                + " WHEN Deposit_Withdraw='Deposit' THEN ISNULL(Amount,0.00)"
        //            //                               + " ELSE 0.00"
        //            //                          + " END"
        //            //                          + " )"
        //            //                          + " ,SUM("
        //            //                          + " CASE"
        //            //                               + " WHEN Deposit_Withdraw='Withdraw' THEN ISNULL(Amount,0.00)"
        //            //                               + " ELSE 0.00"
        //            //                          + " END"
        //            //                          + " )"
        //            //                          + " ,SUM("
        //            //                          + " CASE"
        //            //                               + " WHEN Deposit_Withdraw='Deposit' THEN ISNULL(Amount,0.00)"
        //            //                               + " ELSE 0.00"
        //            //                          + " END"
        //            //                          + " )-"
        //            //                          + " SUM("
        //            //                          + " CASE"
        //            //                               + " WHEN Deposit_Withdraw='Withdraw' THEN ISNULL(Amount,0.00)"
        //            //                               + " ELSE 0.00"
        //            //                          + " END"
        //            //                          + " )"
        //            //                          + " ,SUM("
        //            //                          + " CASE"
        //            //                               + " WHEN Deposit_Withdraw='Deposit' THEN ISNULL(Amount,0.00)"
        //            //                               + " ELSE 0.00"
        //            //                          + " END"
        //            //                          + " )-"
        //            //                          + " SUM("
        //            //                          + " CASE"
        //            //                               + " WHEN Deposit_Withdraw='Withdraw' THEN ISNULL(Amount,0.00)"
        //            //                               + " ELSE 0.00"
        //            //                          + " END"
        //            //                          + " )"
        //            //                          + " ,Payment_Media"
        //            //                          + " ,Received_Date "
        //            //                          + " FROM SBP_Payment_Posting_Request"
        //            //                          + " WHERE Payment_Id=" + paymentId
        //            //                          + " GROUP BY Cust_Code,Payment_Media,Received_Date ";
        //            queryStringTransChages = QryString_TransCharge;
        //            try
        //            {
        //                _dbConnection.ConnectDatabase();
        //                _dbConnection.StartTransaction();
        //                _dbConnection.ExecuteNonQuery(queryUpdateDepPosting);
        //                _dbConnection.ExecuteNonQuery(queryInsertPayment);
        //                if (queryStringTransChages != string.Empty)
        //                    _dbConnection.ExecuteNonQuery(queryStringTransChages);
        //                _dbConnection.Commit();
        //            }
        //            catch (Exception)
        //            {
        //                _dbConnection.Rollback();

        //            }
        //            finally
        //            {
        //                _dbConnection.CloseDatabase();
        //            }

        //        }

        private string GetQueryString_UpdateDepositPosting(string paymentId)
        {
            string queryUpdateDepPosting = "";
            CommonBAL cmBal = new CommonBAL();
            queryUpdateDepPosting =
                                 " UPDATE SBP_Payment_Posting_Request "
                               + " SET Approval_Status=1, "
                               + " Payment_Approved_Date='" + cmBal.GetCurrentServerDate().ToString("MM-dd-yyyy") + "'"
                               + " WHERE Payment_ID=" + paymentId + "";
            return queryUpdateDepPosting;
        }
        private string GetQueryString_InsertPayment(string paymentId, int parentPaymentId_FromPayPostReq_ForReturnTrans)
        {
            string queryInsertPayment = string.Empty;
            string _payment_Trans_Reason = string.Empty;
            int parentPaymentID_FromPayment_ForReturnTrans = -1;
            parentPaymentID_FromPayment_ForReturnTrans = Get_PaymentIdFromPayment_By_PaymentPostingPaymentId(parentPaymentId_FromPayPostReq_ForReturnTrans);
            _payment_Trans_Reason = Indication_PaymentTransaction.Return_Indicator + "_" + parentPaymentID_FromPayment_ForReturnTrans.ToString();
            if (parentPaymentID_FromPayment_ForReturnTrans != -1)
            {
                queryInsertPayment = @" INSERT INTO dbo.SBP_Payment
                                        (
	                                         [Cust_Code]
	                                         ,[Amount]
	                                         ,[Received_Date]
	                                         ,[Payment_Media]
	                                         ,[Payment_Media_No]
	                                         ,[Payment_Media_Date]
	                                         ,[Bank_ID]
	                                         ,[Bank_Name]
	                                         ,[Branch_ID]
	                                         ,[Bank_Branch]
	                                         ,[Received_By]
	                                         ,[Deposit_Withdraw]
	                                         ,[Payment_Approved_By]
	                                         ,[Payment_Approved_Date]
	                                         ,[Voucher_Sl_No]
	                                         ,[Trans_Reason]
	                                         ,[Remarks]
	                                         ,[Entry_Date]
	                                         ,[Entry_By]
	                                         ,[Maturity_Days]
	                                         ,[Requisition_ID]
	                                         ,[Entry_Branch_ID]
                                        )
                                        
                                        SELECT                                         
                                          p.[Cust_Code]
                                        , p.[Amount]
                                        , p.[Received_Date]
                                        , p.[Payment_Media]
                                        , p.[Payment_Media_No]
                                        , p.[Payment_Media_Date]
                                        , p.[Bank_ID]
                                        , p.[Bank_Name]
                                        , p.[Branch_ID]
                                        , p.[Bank_Branch]
                                        , p.[Received_By]
                                        , p.[Deposit_Withdraw]
                                        , p.[Payment_Approved_By]
                                        , p.[Payment_Approved_Date]
                                        , p.[Vouchar_SN]
                                        ,'" + _payment_Trans_Reason + @"' 
                                        , p.[Remarks]
                                        ,CAST(FLOOR(CAST(GETDATE() AS FLOAT)) AS DATETIME)
                                        ,'" + GlobalVariableBO._userName + @"'
                                        , p.[Maturity_Days]
                                        , p.[Payment_ID]
                                        ,'" + GlobalVariableBO._branchId + @"' 
                                        FROM  SBP_Payment_Posting_Request AS p
                                        WHERE
                                        p.Payment_ID=" + paymentId + "";
            }
            else
            {
                queryInsertPayment = "INSERT INTO SBP_Payment(Cust_code,Amount,Received_Date,Payment_Media,Maturity_Days,Payment_Media_No,Payment_Media_Date,Bank_Name,Bank_Branch,received_By,Deposit_Withdraw,Payment_Approved_By,Payment_Approved_Date,Voucher_Sl_No,Remarks,Entry_Date,Entry_By,Requisition_ID,Entry_Branch_ID) SELECT Cust_Code,Amount,Received_Date,Payment_Media,Maturity_Days,Payment_Media_No,Payment_Media_Date,Bank_Name,Bank_Branch,Received_By,Deposit_Withdraw,Payment_Approved_By,Payment_Approved_Date,Vouchar_SN,Remarks,CAST(FLOOR(CAST(GETDATE() AS FLOAT)) AS DATETIME),'" + GlobalVariableBO._userName + "'," + paymentId + ",Entry_Branch_ID FROM SBP_Payment_Posting_Request WHERE Payment_ID=" + paymentId + "";
            }

            return queryInsertPayment;
        }

        private string GetQueryString_Withdraw_InsertMoneyBalance(string PaymentId)
        {
            string paymentId = "0";
            paymentId = PaymentId;
            string queryStringTemp = " INSERT INTO SBP_Money_Balance_Temp(Cust_Code,Sell_Deposit,Buy_Withdraw,Balance,Matured_Balance,Remarks,Rec_Date) SELECT Cust_Code,Amount,0,Amount,Amount,Payment_Media,Received_Date FROM SBP_Payment_Posting_Request WHERE Payment_Id=" + paymentId + "";
            queryStringTemp = " INSERT INTO SBP_Money_Balance_Temp("
                                       + " Cust_Code"
                                       + ",Sell_Deposit"
                                       + ",Buy_Withdraw"
                                       + ",Balance"
                                       + ",Matured_Balance"
                                       + ",Remarks"
                                       + ",Rec_Date"
                                       + ")"

                                      + " SELECT"
                                      + " Cust_Code"
                                      + " ,SUM("
                                      + " CASE"
                                            + " WHEN Deposit_Withdraw='Deposit' THEN ISNULL(Amount,0.00)"
                                           + " ELSE 0.00"
                                      + " END"
                                      + " )"
                                      + " ,SUM("
                                      + " CASE"
                                           + " WHEN Deposit_Withdraw='Withdraw' THEN ISNULL(Amount,0.00)"
                                           + " ELSE 0.00"
                                      + " END"
                                      + " )"
                                      + " ,SUM("
                                      + " CASE"
                                           + " WHEN Deposit_Withdraw='Deposit' THEN ISNULL(Amount,0.00)"
                                           + " ELSE 0.00"
                                      + " END"
                                      + " )-"
                                      + " SUM("
                                      + " CASE"
                                           + " WHEN Deposit_Withdraw='Withdraw' THEN ISNULL(Amount,0.00)"
                                           + " ELSE 0.00"
                                      + " END"
                                      + " )"
                                      + " ,SUM("
                                      + " CASE"
                                           + " WHEN Deposit_Withdraw='Deposit' THEN ISNULL(Amount,0.00)"
                                           + " ELSE 0.00"
                                      + " END"
                                      + " )-"
                                      + " SUM("
                                      + " CASE"
                                           + " WHEN Deposit_Withdraw='Withdraw' THEN ISNULL(Amount,0.00)"
                                           + " ELSE 0.00"
                                      + " END"
                                      + " )"
                                      + " ,Payment_Media"
                                      + " ,Received_Date "
                                      + " FROM SBP_Payment_Posting_Request"
                                      + " WHERE Payment_Id=" + paymentId
                                      + " GROUP BY Cust_Code,Payment_Media,Received_Date ";

            return queryStringTemp;
        }
        private string GetQueryString_Deposit_InsertMoneyBalance(string PaymentId)
        {
            string queryStringTemp = string.Empty;
            string paymentId = "0";
            paymentId = PaymentId;

            queryStringTemp =
                         @"INSERT INTO 
                        SBP_Money_Balance_Temp
                        (Cust_Code,Sell_Deposit,Buy_Withdraw,Balance,Matured_Balance,Remarks,Rec_Date) 
                        SELECT Cust_Code,Amount,0,Amount,Amount,Payment_Media,Received_Date 
                        FROM SBP_Payment_Posting_Request 
                        WHERE Payment_Id=" + paymentId + "";
            return queryStringTemp;
        }
        private string GetQueryString_TransCharge_InsertMoneyBalance(string Cust_Code, DateTime Received_Date, string ReceivedBy, int ChargeID, string ChargeName, double Req_Amount)
        {
            string queryStringTemp = string.Empty;

            queryStringTemp =
                         @"INSERT INTO 
                        SBP_Money_Balance_Temp
                        (Cust_Code,Sell_Deposit,Buy_Withdraw,Balance,Matured_Balance,Remarks,Rec_Date) 
                        VALUES('" + Cust_Code + @"',0," + Req_Amount + @"," + Req_Amount + @"," + Req_Amount + @",'Cash','" + Received_Date.ToShortDateString() + @"')";
            return queryStringTemp;
        }
        //        private string GetQueryString_TransCharge_InsertMoneyBalance_DepositCompanyAcc(string Cust_Code, DateTime Received_Date, string ReceivedBy, int ChargeID, string ChargeName, double Req_Amount)
        //        {
        //            string queryStringTemp = string.Empty;

        //            queryStringTemp =
        //                         @"INSERT INTO 
        //                        SBP_Money_Balance_Temp
        //                        (Cust_Code,Sell_Deposit,Buy_Withdraw,Balance,Matured_Balance,Remarks,Rec_Date) 
        //                        VALUES('" + Cust_Code + @"'," + Req_Amount+",0" + @"," + Req_Amount + @"," + Req_Amount + @",'Cash','" + Received_Date.ToShortDateString() + @"')";
        //            return queryStringTemp;
        //        }

        private string GetQueryString_Deposit99(PaymentInfoBO bo)
        {
            CommonBAL combal = new CommonBAL();
            string qeuryString_Charge_InsertPayment =
            @"INSERT INTO [SBP_Database].[dbo].[SBP_Payment]
            (
            [Cust_Code], [Amount], [Received_Date], [Payment_Media]
            , [Deposit_Withdraw], [Voucher_Sl_No]
            , [Trans_Reason], [Entry_Date], [Entry_By], [Maturity_Days], [Requisition_ID]
            , [Entry_Branch_ID]
            )
            VALUES(" 
               +@"'99'"       
               +@"," + bo.Amount
               +@",'" + bo.RecievedDate.ToShortDateString() +@"'"
               +@",'Cash'"
               +@",'Deposit'"
               +@",'"+bo.VoucherSlNo + @"'" 
               +@",'"+bo.CustCode+@"'"
               +@",'"+combal.GetCurrentServerDate().ToShortDateString() + "'" 
               +@",'"+GlobalVariableBO._userName+"'"
               +@",NULL,NULL" 
               +@","+ GlobalVariableBO._branchId
            + ")";
            
            return qeuryString_Charge_InsertPayment;
        }
        private string GetQueryString_ApplyCharges(PaymentInfoBO bo)
        {
            CommonBAL combal = new CommonBAL();
            string qeuryString_Charge_InsertPayment =
            @"INSERT INTO [SBP_Database].[dbo].[SBP_Payment]
            (
            [Cust_Code], [Amount], [Received_Date], [Payment_Media], [Payment_Media_No]
            , [Payment_Media_Date], [Bank_ID], [Bank_Name], [Branch_ID], [Bank_Branch], [Received_By]
            , [Deposit_Withdraw], [Payment_Approved_By], [Payment_Approved_Date], [Voucher_Sl_No]
            , [Trans_Reason], [Remarks], [Entry_Date], [Entry_By], [Maturity_Days], [Requisition_ID]
            , [Entry_Branch_ID]
            )
            VALUES('" +
               bo.CustCode
               + @"'," +
               bo.Amount
               + @",'" +
               bo.RecievedDate.ToShortDateString()
               + @"','Cash','',NULL,'','','','','" +
               bo.RecievedBy
               + @"','" +
               "Withdraw','" +
               GlobalVariableBO._employeeCode + @"','" +
               combal.GetCurrentServerDate().ToShortDateString() + @"','" +
               bo.VoucherSlNo + @"','" +
               bo.TransReason + "','','" + combal.GetCurrentServerDate().ToShortDateString() + "','" +
               GlobalVariableBO._userName + "',NULL,NULL,'" + GlobalVariableBO._branchId
            + "')";
            return qeuryString_Charge_InsertPayment;
        }
        //        private string GetQueryString_ApplyCharge_DepositCompanyAcc(PaymentInfoBO bo)
        //        {
        //            CommonBAL combal = new CommonBAL();
        //            string CompanyAcc = string.Empty;
        //            string VoucherNo = string.Empty;
        //            CompanyAcc = Indication_TransactioBasedCharge.DepositCompanyAccount;
        //            VoucherNo = "Deposit_" + bo.PaymentId;
        //            string qeuryString_Charge_InsertPayment =
        //            @"INSERT INTO [SBP_Database].[dbo].[SBP_Payment]
        //            (
        //            [Cust_Code], [Amount], [Received_Date], [Payment_Media], [Payment_Media_No]
        //            , [Payment_Media_Date], [Bank_ID], [Bank_Name], [Branch_ID], [Bank_Branch], [Received_By]
        //            , [Deposit_Withdraw], [Payment_Approved_By], [Payment_Approved_Date], [Voucher_Sl_No]
        //            , [Trans_Reason], [Remarks], [Entry_Date], [Entry_By], [Maturity_Days], [Requisition_ID]
        //            , [Entry_Branch_ID]
        //            )
        //            VALUES('" +
        //               CompanyAcc
        //               + @"'," +
        //               bo.Amount
        //               + @",'" +
        //               bo.RecievedDate.ToShortDateString()
        //               + @"','Cash','',NULL,'','','','','" +
        //               bo.RecievedBy
        //               + @"','" +
        //               "Deposit','" +
        //               GlobalVariableBO._employeeCode + @"','" +
        //               combal.GetCurrentServerDate().ToShortDateString() + @"','" +
        //               bo.VoucherSlNo + @"','" +
        //               bo.TransReason + "','','" + combal.GetCurrentServerDate().ToShortDateString() + "','" +
        //               GlobalVariableBO._userName + "',NULL,NULL,'" + GlobalVariableBO._branchId
        //            + "')";
        //            return qeuryString_Charge_InsertPayment;
        //        }
        private DataTable GetTransactionBasedCharges(int ChargeID, string ChargeName, double Req_Amount)
        {
            DataTable data = new DataTable();
            string queryString_ForGettingCharge = string.Empty;
            queryString_ForGettingCharge = @"GetTransactionBasedCharge";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter(@"ChargeID", SqlDbType.Int, ChargeID);
                _dbConnection.AddParameter(@"ChargeName", SqlDbType.VarChar, ChargeName);
                _dbConnection.AddParameter(@"TransactionAmount", SqlDbType.Money, Req_Amount);
                data = _dbConnection.ExecuteProQuery(queryString_ForGettingCharge);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return data;
        }
        public double GetTransactionBasedCharges_ChageRate(string ChargeName, double Req_Amount)
        {
            double Result = 0.00;
            double doubleTryParse;
            DataTable dt = new DataTable();
            dt = GetTransactionBasedCharges(0, ChargeName, Req_Amount);
            if (dt.Rows.Count > 0)
            {
                if (double.TryParse(dt.Rows[0]["Charge_Rate"].ToString(), out doubleTryParse))
                    Result = doubleTryParse;
            }
            return Result;
        }
        public double GetTransactionBasedCharges_ChargeAmount(string ChargeName, double Req_Amount)
        {
            double Result = 0.00;
            double doubleTryParse;
            DataTable dt = new DataTable();
            dt = GetTransactionBasedCharges(0, ChargeName, Req_Amount);
            if (dt.Rows.Count > 0)
            {
                if (double.TryParse(dt.Rows[0]["Charge_Amount"].ToString(), out doubleTryParse))
                    Result = doubleTryParse;
            }
            return Result;
        }
        public void ApprovedSingleDeposit(string paymentId, int parentPaymentId_FromPayPostReq_ForReturnTrans, PaymentInfoBO bo, int ChargeID, string ChargeName, double Req_Amount)
        {
            try
            {
                double doubleTryParse;
                string UpdatePaymentPostingReq = string.Empty;
                string InsertPayment = string.Empty;
                string InsertMoneyBal = string.Empty;
                string InsertChargeToMoneyBal = string.Empty;
                string ApplyTransCharge = string.Empty;
                string ApplyTransChargeToMoneyBal = string.Empty;
                string DepositTo99 = string.Empty;
                string ChargeType = string.Empty;
                string TransReason = string.Empty;
                double Charge_Rate = 0.00;
                double Charge_Amount = 0.00;
                bool isChargeApplied = true;
                int currentPayment_ID = -1;
                DataTable dt = new DataTable();

                PaymentInfoBAL payBal = new PaymentInfoBAL();
                
                
                bool isUpdated = false;
                string queryString_CheckIf = string.Empty;
                queryString_CheckIf =
                                @"
                            DECLARE @IsUpdated bit

                            IF 
                                EXISTS (SELECT * FROM SBP_Payment_Posting_Request WHERE [Approval_Status]=1 AND [Payment_ID]=" + paymentId + @")

                            BEGIN                                                                                                                                    
                                SET @IsUpdated=1
                            END
                            ELSE 
                            BEGIN
                                SET @IsUpdated=0
                            END
                            SELECT @IsUpdated                    
                ";


                UpdatePaymentPostingReq = GetQueryString_UpdateDepositPosting(paymentId);
                InsertPayment = GetQueryString_InsertPayment(paymentId, parentPaymentId_FromPayPostReq_ForReturnTrans);
                InsertMoneyBal = GetQueryString_Deposit_InsertMoneyBalance(paymentId);
                dt = GetTransactionBasedCharges(ChargeID, ChargeName, Req_Amount);
                if (dt.Rows.Count > 0)
                {
                    ChargeType = Indication_TransactioBasedCharge.ChargeTypeList.Where(t => t.Key == ChargeName).Select(t => t.Value).SingleOrDefault();
                    TransReason = Indication_TransactioBasedCharge.TransReasonList.Where(t => t.Key == ChargeName).Select(t => t.Value).SingleOrDefault();

                    if (ChargeType == Indication_TransactioBasedCharge.Charge_Rate)
                    {
                        if (double.TryParse(dt.Rows[0]["Charge_Rate"].ToString(), out doubleTryParse))
                            Charge_Rate = doubleTryParse;
                    }
                    else if (ChargeType == Indication_TransactioBasedCharge.Charge_Amount)
                    {
                        if (double.TryParse(dt.Rows[0]["Charge_Amount"].ToString(), out doubleTryParse))
                            Charge_Amount = doubleTryParse;
                    }

                    if ((ChargeType == Indication_TransactioBasedCharge.Charge_Amount && Charge_Amount == 0) || (ChargeType == Indication_TransactioBasedCharge.Charge_Rate && Charge_Rate == 0))
                        isChargeApplied = false;

                    if (Indication_TransactioBasedCharge.ExceptionString.GetValues(Indication_TransactioBasedCharge.BankClearing).ToList().Contains(bo.BankName))
                        isChargeApplied = false;
                }

                //Auto Voucher Start --Commented On 17June2013 By Shahrior
                //if (!payBal.IsLockedVoucherLockState() && isChargeApplied)
                //{
                //    payBal.LockVoucherNo();
                //    voucherNo = payBal.GenerateSerial();
                //}
                //else if (isChargeApplied && payBal.IsLockedVoucherLockState()) { throw new Exception("SomeOne Lock Auto Vuocher!! Please Try Later !!"); }           

                //if (isChargeApplied)
                //{
                //    bo.VoucherSlNo = Indication_TransactioBasedCharge.VoucherSLnoList.Where(t => t.Key == ChargeName).Select(t => t.Value).SingleOrDefault();
                //    bo.Amount = (float)(ChargeType == Indication_TransactioBasedCharge.Charge_Rate ? Charge_Rate : Charge_Amount);
                //    //bo.TransReason = TransReason + '_' + paymentId;
                    
                //    //bo.TransReason = TransReason + '_' + bo.PaymentMediaNo;
                //    ApplyTransCharge = GetQueryString_ApplyCharges(bo);
                //    ApplyTransChargeToMoneyBal = GetQueryString_TransCharge_InsertMoneyBalance(bo.CustCode, bo.RecievedDate, bo.RecievedBy, ChargeID, ChargeName, Req_Amount);
                    
                //}

                try
                {
                    _dbConnection.ConnectDatabase();
                    _dbConnection.StartTransaction();

                    DataTable dt_temp = _dbConnection.ExecuteQuery(queryString_CheckIf);
                    if (dt_temp.Rows.Count > 0)
                        isUpdated = Convert.ToBoolean(dt_temp.Rows[0][0].ToString());
                    if (isUpdated)
                        throw new Exception("Already Approved!!");

                    _dbConnection.ExecuteNonQuery(UpdatePaymentPostingReq);
                    currentPayment_ID=_dbConnection.ExecuteScalar(InsertPayment);
                 
                    if (isChargeApplied)
                    {
                        bo.VoucherSlNo = Indication_TransactioBasedCharge.VoucherSLnoList.Where(t => t.Key == ChargeName).Select(t => t.Value).SingleOrDefault();
                        bo.Amount = (float)(ChargeType == Indication_TransactioBasedCharge.Charge_Rate ? Charge_Rate : Charge_Amount);

                        //bo.TransReason = TransReason + '_' + bo.PaymentMediaNo;
                        bo.TransReason = TransReason + '_' + currentPayment_ID;
                        if (bo.VoucherSlNo.ToLower().Trim() == ("BACH-C").ToLower().Trim())
                        {
                            //bo.Amount = (bo.Amount * (-1));
                            Req_Amount = bo.Amount;
                        }                              
                        
                        ApplyTransCharge = GetQueryString_ApplyCharges(bo);
                        ApplyTransChargeToMoneyBal = GetQueryString_TransCharge_InsertMoneyBalance(bo.CustCode, bo.RecievedDate, bo.RecievedBy, ChargeID, ChargeName, Req_Amount);
                        
                        _dbConnection.ExecuteNonQuery(ApplyTransCharge);
                        _dbConnection.ExecuteNonQuery(ApplyTransChargeToMoneyBal);
                        
                        
                        if (ChargeName == Indication_TransactioBasedCharge.CheckBounce)
                        {
                            DepositTo99 = GetQueryString_Deposit99(bo);
                            
                            _dbConnection.ExecuteNonQuery(DepositTo99);
                        }
                    }
                    _dbConnection.ExecuteNonQuery(InsertMoneyBal);
                    _dbConnection.Commit();
                }
                catch (Exception ex)
                {
                    _dbConnection.Rollback();
                    throw new Exception(ex.Message);
                }
                finally
                {
                    _dbConnection.CloseDatabase();
                }

                //if(isChargeApplied)
                //{
                //    payBal.UpdateSerialNo();
                //    payBal.UnLockVoucherNo();
                //}
            }
            catch (Exception ex)
            {
                PaymentInfoBAL payBal = new PaymentInfoBAL();
                //if (payBal.IsLockedVoucherLockState())
                //{
                //    payBal.UnLockVoucherNo();
                //}
                throw new Exception(ex.Message);
            }
        }
        public void ApprovedSingleDeposit(string paymentId, int parentPaymentId_FromPayPostReq_ForReturnTrans)
        {
            try
            {
                string UpdatePaymentPostingReq = string.Empty;
                string InsertPayment = string.Empty;
                string InsertMoneyBal = string.Empty;
                bool isUpdated = false;
                string queryString_CheckIf = string.Empty;
                queryString_CheckIf =
                                @"
                            DECLARE @IsUpdated bit

                            IF 
                                EXISTS (SELECT * FROM SBP_Payment_Posting_Request WHERE [Approval_Status]=1 AND [Payment_ID]=" + paymentId + @")
                                

                            BEGIN                                                                                                                                    
                                SET @IsUpdated=1
                            END
                            ELSE 
                            BEGIN
                                SET @IsUpdated=0
                            END
                            SELECT @IsUpdated                    
                ";


                UpdatePaymentPostingReq = GetQueryString_UpdateDepositPosting(paymentId);
                InsertPayment = GetQueryString_InsertPayment(paymentId, parentPaymentId_FromPayPostReq_ForReturnTrans);
                InsertMoneyBal = GetQueryString_Deposit_InsertMoneyBalance(paymentId);

                try
                {
                    _dbConnection.ConnectDatabase();
                    _dbConnection.StartTransaction();


                    DataTable dt = _dbConnection.ExecuteQuery(queryString_CheckIf);
                    if (dt.Rows.Count > 0)
                        isUpdated = Convert.ToBoolean(dt.Rows[0][0].ToString());
                    if (isUpdated)
                        throw new Exception("Already Approved!!");

                    _dbConnection.ExecuteNonQuery(UpdatePaymentPostingReq);
                    _dbConnection.ExecuteNonQuery(InsertPayment);
                    _dbConnection.ExecuteNonQuery(InsertMoneyBal);
                    _dbConnection.Commit();
                }
                catch (Exception ex)
                {
                    _dbConnection.Rollback();
                    throw new Exception(ex.Message);

                }
                finally
                {
                    _dbConnection.CloseDatabase();
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public void RejectSingleWithdraw(string paymentId, string rejectionReason)
        {
            CommonBAL cmnbal = new CommonBAL();
            string queryUpdateDepPosting = "UPDATE SBP_Payment_Posting_Request SET Approval_Status=2,Rejection_Reason='" + rejectionReason + "', Payment_Approved_Date='" + cmnbal.GetCurrentServerDate() + "' WHERE Payment_ID=" + paymentId + "";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(queryUpdateDepPosting);
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

        public DataTable GetGridData(DateTime searchDate)
        {
            DataTable dataTable = new DataTable();
            string queryString = "";
            queryString = "SELECT Payment_ID,Cust_code AS 'Client Code',(SELECT Cust_Name FROM SBP_Cust_Personal_Info WHERE SBP_Cust_Personal_Info.Cust_code=SBP_Payment_Posting_Request.Cust_code) AS 'Name',Amount,CASE Payment_Media WHEN 'Check' THEN 'Cheque' ELSE Payment_Media END AS 'Payment Media',Payment_Media_No AS 'Cheque No.',Vouchar_SN AS 'Serial No',Received_Date AS 'Received Date',(CASE WHEN Approval_Status=1 THEN 'Approved' WHEN Approval_Status=0 THEN 'Pending' WHEN Approval_Status=2 THEN 'Rejected' END) AS 'Status' FROM SBP_Payment_Posting_Request WHERE Received_Date='" + searchDate.ToShortDateString() + "' AND '" + GlobalVariableBO._branchId + "'=(SELECT Branch_ID FROM SBP_Users WHERE User_Name=SBP_Payment_Posting_Request.Entry_By)";
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

        public void RejectSingleDeposit(string paymentId, string rejectionReason)
        {
            string queryUpdateDepPosting = "UPDATE SBP_Payment_Posting_Request SET Approval_Status=2,Rejection_Reason='" + rejectionReason + "' WHERE Payment_ID=" + paymentId + "";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(queryUpdateDepPosting);
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
        public void RejectTransfer(string voucherNo, string rejectionReason)
        {
            string queryUpdateDepPosting = "UPDATE SBP_Payment_Posting_Request SET Approval_Status=2,Rejection_Reason='" + rejectionReason + "' WHERE Vouchar_SN='" + voucherNo + "'";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(queryUpdateDepPosting);
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

        public void RejectBOAnnual(string []paymentId, string rejectionReason)
        {
            string queryUpdateDepPosting =
                "UPDATE SBP_Payment_Posting_Request SET Approval_Status=2,Rejection_Reason='" + rejectionReason +
                "' WHERE Payment_ID IN (" + paymentId[0] + "," + paymentId[1] + ")";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(queryUpdateDepPosting);
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
        public void InsertDeleteLog(int paymentId)
        {
            string queryUpdate = @"INSERT INTO dbo.SBP_Payment_Posting_Request_Delete_Log
                                  SELECT * FROM SBP_Payment_Posting_Request WHERE Payment_ID=" + paymentId + "";

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(queryUpdate);

            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
        }

        public void CancelDeposit(long paymentId)
        {
            string queryUpdate = "DELETE FROM SBP_Payment_Posting_Request WHERE Payment_ID=" + paymentId + "";

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(queryUpdate);

            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
        }

        public DataTable GetRoutingInfo(string CustCode)
        {
            DataTable dataTable = new DataTable();
            string queryString = "";
            queryString = @"SELECT 
                            cbi.Bank_Name
                            ,cbi.Branch_Name
                            ,bbri.Routing_No
                            ,cbi.Account_No
                            ,bbri.Bank_ID
                            ,bbri.Branch_ID
                            FROM dbo.SBP_Bank_Branch_Routing_Info AS bbri
                            JOIN dbo.SBP_Cust_Bank_Info AS cbi
                            ON bbri.Bank_ID=cbi.Bank_ID
                            AND bbri.Bank_Name=cbi.Bank_Name
                            AND bbri.Branch_ID=cbi.Branch_ID
                            AND bbri.Branch_Name=cbi.Branch_Name
                            AND cbi.Routing_No=bbri.Routing_No
                            WHERE cbi.Cust_Code='" + CustCode + "'";
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

        public DataTable PaymentGridLoad(string CustCode, string DepositWithdraw, string PaymentMedia, DateTime PaymentReceivedDate)
        {
            DataTable data = new DataTable();
            string queryString = "";
            queryString = @"PaymentGridLoad";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@CustCode", SqlDbType.VarChar, CustCode);
                _dbConnection.AddParameter("@DepositWithdraw", SqlDbType.VarChar, DepositWithdraw);
                _dbConnection.AddParameter("@PaymentMedia", SqlDbType.VarChar, PaymentMedia == null ? "" : PaymentMedia);
                _dbConnection.AddParameter("@PaymentReceivedDate", SqlDbType.DateTime, PaymentReceivedDate.ToShortDateString());
                _dbConnection.AddParameter("@Branch_Id", SqlDbType.Int, GlobalVariableBO._branchId);
                data = _dbConnection.ExecuteProQuery(queryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return data;
        }

       
        public bool IsReceivedBoRenewal(string custCode, string transReason)
        {
            string queryString = string.Empty;
            bool result = false;
            DataTable dt = new DataTable();
            queryString = @"select * from dbo.SBP_Payment
                            where Cust_Code='" + custCode + "'AND Trans_Reason='" + transReason + "'";
            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(queryString);
                if (dt.Rows.Count > 0)
                {
                    result = true;
                }
            }
            catch
            {
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return result;
        }

        
        public bool IsRenewal_Transaction(int paymentID,string paymentMedia)
        {
            DataTable dataTable = new DataTable();
            bool renewal_Transaction = false;
            string queryString = "";
            queryString = @" SELECT Trans_Reason FROM dbo.SBP_Payment
                             WHERE Payment_ID="+paymentID 
                            +@" AND Payment_Media='"+paymentMedia +"'"
                            + @" AND Trans_Reason LIKE '%BAC%'";
            try
            {
                _dbConnection.ConnectDatabase();
                dataTable = _dbConnection.ExecuteQuery(queryString);
                if(dataTable.Rows.Count>0)
                {
                    renewal_Transaction = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return renewal_Transaction;
        }

        public DataTable GetRequisitionIDByDepositTransaction(int paymentId,string paymentMedia,string depositwithdraw)
        {
            DataTable dataTable = new DataTable();
            string queryString = "";
            queryString = @"SELECT Requisition_ID AS 'Deposit Requisition_ID'
                             ,
                             (
	                            SELECT  SUBSTRING(Trans_Reason, CHARINDEX('_', Trans_Reason) + 1, LEN(Trans_Reason)) 
                                FROM dbo.SBP_Payment
                                WHERE Payment_ID="+paymentId +@" AND Payment_Media='"+paymentMedia +@"' AND Deposit_Withdraw='" +depositwithdraw + @"' AND Trans_Reason LIKE '%BAC%'
                             ) AS 'Withdraw Requisition_ID'
                             FROM dbo.SBP_Payment
                             WHERE Payment_ID=" + paymentId + @" AND Payment_Media='" + paymentMedia + @"' AND Deposit_Withdraw='" + depositwithdraw + @"' AND Trans_Reason LIKE '%BAC%'";
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


        public DataTable GetRequisitionIDByWithdrawTransaction_For_BAC_Voucher(int paymentId, string paymentMedia, string depositwithdraw,string CustCode , string Voucher)
        {
            DataTable dataTable = new DataTable();
            string queryString = "";
            string query = "";
            queryString = @" Select Payment_ID from SBP_Payment
                             Where Cust_Code='" +CustCode+@"' AND Deposit_Withdraw='Withdraw'
                             AND Voucher_Sl_No='"+Voucher+"' AND Payment_ID='"+paymentId+"'";       
           

            query = @"  Select Payment_ID from SBP_Payment_Posting_Request
                             Where Deposit_Withdraw='Withdraw' AND Cust_Code='" +CustCode+@"'
                             AND Vouchar_SN='"+Voucher+"'";

            _dbConnection.ConnectDatabase();
            DataTable dt = _dbConnection.ExecuteQuery(queryString);
            DataTable data = _dbConnection.ExecuteQuery(query);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow Value in dt.Rows)
                {
                    dataTable.Clear();
                    dataTable.Columns.Add("PaymentId");
                    DataRow _ravi = dataTable.NewRow();
                    _ravi["PaymentId"] = Value[0].ToString();
                    dataTable.Rows.Add(_ravi);                   
                }
            }
            if (data.Rows.Count > 0)
            {
                foreach (DataRow Value in data.Rows)
                {
                    DataRow _ravi = dataTable.NewRow();
                    _ravi["PaymentId"] = Value[0].ToString();
                    dataTable.Rows.Add(_ravi);                 
                }
            }          
            return dataTable;
        }



        public DataTable GetRequisitionIDByWithdrawTransaction(int paymentId, string paymentMedia, string depositwithdraw)
        {
            DataTable dataTable = new DataTable();
            string queryString = "";
            queryString = @"SELECT p.Requisition_ID AS 'Withdraw Requisition_ID'
                             ,
                             (
	                            SELECT Requisition_ID 
                                FROM dbo.SBP_Payment
                                WHERE Payment_Media='" + paymentMedia + @"' AND Deposit_Withdraw='Deposit' AND Trans_Reason LIKE '%BAC%'
                                AND SUBSTRING(Trans_Reason, CHARINDEX('_', Trans_Reason) + 1, LEN(Trans_Reason))=(SELECT CONVERT(VARCHAR(50), p.Requisition_ID)) 
                             ) AS 'Deposit Requisition_ID'
                             FROM dbo.SBP_Payment AS p
                             WHERE Payment_ID=" + paymentId + @" AND Payment_Media='" + paymentMedia + @"' AND Deposit_Withdraw='" + depositwithdraw + @"' AND Trans_Reason LIKE '%BAC%'";
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
        
//        public void DeleteRenewal_Transaction(DataTable dtrequisitionId)
//        {
//            int depositRequisitionId=0, withdrawRequisitionId = 0;
//            string queryStringPosting = string.Empty;
//            string queryStringPayment = string.Empty;

//            if(dtrequisitionId.Rows.Count>0)
//            {
//                depositRequisitionId = Convert.ToInt32(dtrequisitionId.Rows[0]["Deposit Requisition_ID"].ToString());
//                withdrawRequisitionId = Convert.ToInt32(dtrequisitionId.Rows[0]["Withdraw Requisition_ID"].ToString());
//            }
//             queryStringPosting = @"DELETE FROM SBP_Payment_Posting_Request WHERE Payment_ID IN (" + depositRequisitionId + "," + withdrawRequisitionId + ")";
            
//             queryStringPayment = @"DELETE FROM dbo.SBP_Payment
//                                   WHERE Requisition_ID IN (" + depositRequisitionId + "," + withdrawRequisitionId + ")";

//            try
//            {
//                _dbConnection.ConnectDatabase();
//                _dbConnection.StartTransaction();
//                _dbConnection.ExecuteNonQuery(queryStringPosting);
//                _dbConnection.ExecuteNonQuery(queryStringPayment);
//                _dbConnection.Commit();
//            }
//            catch (Exception)
//            {
//                _dbConnection.Rollback();
//                throw;
//            }
//            finally
//            {
//                _dbConnection.CloseDatabase();
//            }
//        }


        public void DeleteRenewal_PaymentId(DataTable dtPayment)
        {
            string query = "";
            string sqlquery = "";
            int Count = 0;
            if (dtPayment.Rows.Count > 0)
            {
                foreach (DataRow dr in dtPayment.Rows)
                {               
                    Count++;
                    if (dtPayment.Rows.Count > 0 && Count == 1)
                        query = @" Delete SBP_Payment Where Payment_ID='" + dr[0].ToString() + "'";
                    if (dtPayment.Rows.Count > 1 && Count == 2)
                        sqlquery = @" Delete SBP_Payment_Posting_Request Where Payment_ID='"+dr[0].ToString()+"'";
                }
               
            }
            try
            {
                _dbConnection.ConnectDatabase();                
                _dbConnection.StartTransaction();
                _dbConnection.ExecuteNonQuery(query);
                if (dtPayment.Rows.Count > 1)
                   _dbConnection.ExecuteNonQuery(sqlquery);
                _dbConnection.Commit();
               
            }
            catch (Exception)
            {
                _dbConnection.Rollback();
                throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }

        }


        public void DeleteRenewal_Transaction(DataTable dtrequisitionId)
        {
            int depositRequisitionId = 0;
            //withdrawRequisitionId = 0;
            string queryStringPosting = string.Empty;
            string queryStringPayment = string.Empty;

            if (dtrequisitionId.Rows.Count > 0)
            {

                depositRequisitionId = Convert.ToInt32(dtrequisitionId.Rows[0]["Deposit Requisition_ID"].ToString() == "" ? 0 : Convert.ToInt32(dtrequisitionId.Rows[0]["Deposit Requisition_ID"].ToString()));
                //Block By Rashedul Hasan 03 Feb 2016
                //withdrawRequisitionId = Convert.ToInt32(dtrequisitionId.Rows[0]["Withdraw Requisition_ID"].ToString()==""?0:Convert.ToInt32(dtrequisitionId.Rows[0]["Withdraw Requisition_ID"].ToString()));
            }
            //Block By Rashedul Hasan 03 Feb 2016
            //             queryStringPosting = @"DELETE FROM SBP_Payment_Posting_Request WHERE Payment_ID IN (" + depositRequisitionId + "," + withdrawRequisitionId + ")";

            //             queryStringPayment = @"DELETE FROM dbo.SBP_Payment
            //                                   WHERE Requisition_ID IN (" + depositRequisitionId + "," + withdrawRequisitionId + ")";
            if (depositRequisitionId > 0)
            {
                queryStringPosting = @"DELETE FROM SBP_Payment_Posting_Request WHERE Payment_ID IN (" + depositRequisitionId + ")";

                queryStringPayment = @"DELETE FROM dbo.SBP_Payment
                                   WHERE Requisition_ID IN (" + depositRequisitionId + ")";
            }

            try
            {
                _dbConnection.ConnectDatabase();
                if (depositRequisitionId > 0)
                {                    
                    _dbConnection.StartTransaction();
                    _dbConnection.ExecuteNonQuery(queryStringPosting);
                    _dbConnection.ExecuteNonQuery(queryStringPayment);
                    _dbConnection.Commit();
                }
            }
            catch (Exception)
            {
                _dbConnection.Rollback();
                throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
        }
        
        private int GetScopeIdentity(DbConnection db)
        {
            int intTryParse = 0;
            int Payment_paymentId = -1;

            DataTable data = new DataTable();
            string query = @"Select SCOPE_IDENTITY() As ScopeIden";
            
            data = db.ExecuteQuery(query);
            if (data.Rows.Count > 0)
            {
                if(int.TryParse(data.Rows[0][0].ToString(),out intTryParse))
                {
                    Payment_paymentId = intTryParse;
                }
                
            }
            return Payment_paymentId;
        }

        /// <summary>
        /// Dev By : Mr. Rashed 
        /// On 24 Jun 2015
        /// </summary>
        /// <returns></returns>


        #region AlltegetherTransation
        public string GenerateSerial_UI()  ////Auto SerialNo Generate
        {
            string slNo = "";
            int intTryParse;
            DataTable dataTable;
            string queryStringSelect = "";
            string queryStringUpdate = "";
            queryStringSelect = "SELECT Prefix + Convert(varchar(20),Sl_No) as 'sl No' FROM SBP_Serial_Generator WHERE Serial_Purpose='Payment'";
            // queryStringUpdate="UPDATE SBP_Serial_Generator SET Sl_No = Sl_No + 1 WHERE Serial_Purpose='Payment'";

            try
            {
                //_dbConnection.ConnectDatabase();
                dataTable = _dbConnection.ExecuteQuery(queryStringSelect);
                //  _dbConnection.ExecuteNonQuery(queryStringUpdate);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                // _dbConnection.CloseDatabase();
            }

            if (dataTable.Rows[0]["sl No"] != DBNull.Value)
            {
                slNo = dataTable.Rows[0]["sl No"].ToString();
            }

            return slNo;
        }

        public bool IsLockedVoucherLockState_UI()
        {
            bool result = false;
            try
            {

                DataTable dataTable;
                string query = "SELECT [Serial_Purpose], [Prefix], [Sl_No], [IsLocked] "
                             + " FROM [SBP_Database].[dbo].[SBP_Serial_Generator]"
                             + " WHERE IsLocked=1";
                //_dbConnection.ConnectDatabase();
                dataTable = _dbConnection.ExecuteQuery(query);
                if (dataTable.Rows.Count > 0)
                {
                    result = true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }

            return result;

        }

        public void LockVoucherNo_UI()
        {
            string queryStringUpdate = "";
            queryStringUpdate = "UPDATE SBP_Serial_Generator SET IsLocked=1 WHERE IsLocked=0";

            try
            {
                //_dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(queryStringUpdate);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                // _dbConnection.CloseDatabase();
            }
        }

        public void UnLockVoucherNo_UI()
        {
            string queryStringUpdate = "";
            queryStringUpdate = "UPDATE SBP_Serial_Generator SET IsLocked=0 WHERE IsLocked=1";

            try
            {
                //_dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(queryStringUpdate);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                //_dbConnection.CloseDatabase();
            }
        }

        public void UpdateSerialNo_UI()
        {
            string slNo = "";
            DataTable dataTable;
            string queryStringSelect = "";
            string queryStringUpdate = "";
            queryStringUpdate = "UPDATE SBP_Serial_Generator SET Sl_No = Sl_No+1 WHERE Serial_Purpose='Payment'";

            try
            {
                //_dbConnection.ConnectDatabase();
                //  dataTable = _dbConnection.ExecuteQuery(queryStringSelect);
                _dbConnection.ExecuteNonQuery(queryStringUpdate);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                // _dbConnection.CloseDatabase();
            }

            //if (dataTable.Rows[0]["sl No"] != DBNull.Value)
            //    slNo = dataTable.Rows[0]["sl No"].ToString();

            //return slNo;
        }

        #endregion

        
    }
}