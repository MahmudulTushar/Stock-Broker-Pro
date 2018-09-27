using System;
using System.Data;
using BusinessAccessLayer.BO;
using DataAccessLayer;
using BusinessAccessLayer.Constants;
namespace BusinessAccessLayer.BAL
{
    public class PaymentInfoBAL
    {
        private DbConnection _dbConnection;
        public PaymentInfoBAL()
        {
            _dbConnection = new DbConnection();
        }

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

        public DataTable SearchForDelete(string criteriaString)
        {
            DataTable dataTable;
            dataTable = null;
            string queryString = "";
            queryString = " SELECT " +
                          " Payment_ID " +
                          " ,Cust_Code as 'Customer Code' " +
                          " ,Amount " +
                          " ,Payment_Media " +
                          " ,Payment_Media_No " +
                          " ,Voucher_Sl_No AS 'Vouchar No' " +
                          " ,Deposit_Withdraw AS 'Deposit/Withdraw' " +
                          " ,Received_Date AS 'Received Date' " +
                          " FROM SBP_Payment WHERE 0=0 " + criteriaString + "";
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

        public DataTable GetApprovedReturnTransaction(int paymentID, string paymentMethod, string paymentMode)
        {
            DataTable dt = new DataTable();
            string queryStringHave_ReturnTrans_SBPPayment = string.Empty;
            if (paymentMode == Constants.Indication_PaymentMode.Deposit)
            {
                queryStringHave_ReturnTrans_SBPPayment = " SELECT "
                + " [Payment_ID], [Cust_Code], [Amount], [Received_Date], [Payment_Media], [Payment_Media_No], [Payment_Media_Date], [Bank_Name], [Bank_Branch], [Received_By], [Deposit_Withdraw], [Payment_Approved_By], [Payment_Approved_Date], [Voucher_Sl_No], [Trans_Reason], [Remarks], [Entry_Date], [Entry_By], [Maturity_Days], [Requisition_ID], [Entry_Branch_ID] "
                + " FROM [SBP_Database].[dbo].[SBP_Payment] "
                + " WHERE "
                + " Trans_Reason='" + paymentMethod + "Return_'+Convert(varchar(200)," + paymentID + ") "
                + " AND "
                + " Payment_Media='" + paymentMethod + "Return' "
                + " AND "
                + " Deposit_Withdraw='" + Constants.Indication_PaymentMode.Withdraw + "' ";
            }
            else if (paymentMode == Constants.Indication_PaymentMode.Withdraw)
            {
                queryStringHave_ReturnTrans_SBPPayment = " SELECT "
                + " [Payment_ID], [Cust_Code], [Amount], [Received_Date], [Payment_Media], [Payment_Media_No], [Payment_Media_Date], [Bank_Name], [Bank_Branch], [Received_By], [Deposit_Withdraw], [Payment_Approved_By], [Payment_Approved_Date], [Voucher_Sl_No], [Trans_Reason], [Remarks], [Entry_Date], [Entry_By], [Maturity_Days], [Requisition_ID], [Entry_Branch_ID] "
                + " FROM [SBP_Database].[dbo].[SBP_Payment] "
                + " WHERE "
                + " Trans_Reason='" + paymentMethod + "Return_'+Convert(varchar(200)," + paymentID + ") "
                + " AND "
                + " Payment_Media= '" + paymentMethod + "Return'"
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

        public void DeletePaymentInfo(int paymentId, string paymentMethod, string paymentMode)
        {
            string queryStringInsLog = string.Empty;
            string queryStringDel_SBPPayment = string.Empty;
            string queryStringDel_SBPPayment_Posting = string.Empty;
            string queryStringDel_Return_SBPPayment = string.Empty;
            string queryStringDel_Return_SBPPayment_Posting = string.Empty;

            queryStringInsLog = "INSERT INTO SBP_Payment_Delete_Log(Sl_No,Payment_ID,Cust_Code,Amount,Received_Date,Payment_Media,Payment_Media_No,Payment_Media_Date,Bank_Name,Bank_Branch,Received_By,Deposit_Withdraw,Payment_Approved_By,Payment_Approved_Date,Voucher_Sl_No,Trans_Reason,Remarks,Entry_Date,Entry_By,Maturity_Days,Delete_Date,Deleted_By) SELECT " + GetSlNo() + "," + paymentId + ",Cust_Code,Amount,Received_Date,Payment_Media,Payment_Media_No,Payment_Media_Date,Bank_Name,Bank_Branch,Received_By,Deposit_Withdraw,Payment_Approved_By,Payment_Approved_Date,Voucher_Sl_No,Trans_Reason,Remarks,Entry_Date,Entry_By,Maturity_Days,GETDATE(),'" + GlobalVariableBO._userName + "' FROM SBP_Payment WHERE Payment_ID=" + paymentId + "";
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
            if (paymentMode == Constants.Indication_PaymentMode.Deposit)
            {
                queryStringDel_Return_SBPPayment = " Delete From [SBP_Database].[dbo].[SBP_Payment] "
                + " WHERE "
                + " Trans_Reason='" + paymentMethod + "Return_'+Convert(varchar(200), " + paymentId + " ) "
                + " AND " 
                + " Payment_Media='" + paymentMethod + "Return' "
                + " AND "
                + " Deposit_Withdraw='" + Constants.Indication_PaymentMode.Withdraw + "' ";
                
                queryStringDel_Return_SBPPayment_Posting =" Delete "
                + " From dbo.SBP_Payment_Posting_Request "
                + " Where  "
                + " Payment_ID= "
                + " ( "
                + "                 Select "
                + "                 payReq.Payment_ID "
                + "                 From "
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
                + "                 pay.Payment_ID=( "
                + "                             Select pay.Payment_ID "
                + "                             From [SBP_Database].[dbo].[SBP_Payment] as pay "
                + "                             WHERE "
                + "                             pay.Trans_Reason='" + paymentMethod + "Return_'+Convert(varchar(200), " + paymentId + " ) "
                + "                             AND "
                + "                             pay.Payment_Media='" + paymentMethod + "Return' "
                + "                             AND "
                + "                             pay.Deposit_Withdraw='" + Constants.Indication_PaymentMode.Withdraw + "' "
                + "            ) "
                + " ) ";

            }
            else if (paymentMode == Constants.Indication_PaymentMode.Withdraw)
            {
               queryStringDel_Return_SBPPayment = " Delete From [SBP_Database].[dbo].[SBP_Payment] "
               + " WHERE "
               + " Trans_Reason='" + paymentMethod + "Return_'+Convert(varchar(200), " + paymentId + " ) "
               + " AND "
               + " Payment_Media='" + paymentMethod + "Return' "
               + " AND "
               + " Deposit_Withdraw='" + Constants.Indication_PaymentMode.Deposit + "' ";

               queryStringDel_Return_SBPPayment_Posting = " Delete "
               + " From dbo.SBP_Payment_Posting_Request "
               + " Where  "
               + " Payment_ID= "
               + " ( "
               + "                 Select "
               + "                 payReq.Payment_ID "
               + "                 From "
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
               + "                 pay.Payment_ID=( "
               + "                             Select pay.Payment_ID "
               + "                             From [SBP_Database].[dbo].[SBP_Payment] as pay "
               + "                             WHERE "
               + "                             pay.Trans_Reason='" + paymentMethod + "Return_'+Convert(varchar(200), " + paymentId + " ) "
               + "                             AND "
               + "                             pay.Payment_Media='" + paymentMethod + "Return' "
               + "                             AND "
               + "                             pay.Deposit_Withdraw='" + Constants.Indication_PaymentMode.Deposit + "' "
               + "            ) "
               + " ) ";

            }

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();
                _dbConnection.ExecuteNonQuery(queryStringInsLog);
                _dbConnection.ExecuteNonQuery(queryStringDel_SBPPayment_Posting);
                _dbConnection.ExecuteNonQuery(queryStringDel_Return_SBPPayment_Posting);
                _dbConnection.ExecuteNonQuery(queryStringDel_SBPPayment);
                _dbConnection.ExecuteNonQuery(queryStringDel_Return_SBPPayment);
                
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

        private int GetSlNo()
        {
            CommonBAL commonBAL = new CommonBAL();
            int SlNo = commonBAL.GenerateID("SBP_Payment_Delete_Log", "Sl_No");
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
            int paymentIdForTRwithdraw = 0;
            int paymentIdForTRdeposit = 0;
            CommonBAL commonBAL = new CommonBAL();
            paymentIdForTRwithdraw = commonBAL.GenerateID("SBP_Payment_Posting_Request", "Payment_ID");
            TRwithdraw = @"INSERT INTO SBP_Payment_Posting_Request
                                   (
                                    Payment_ID               
                                   ,Cust_code
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
                                  + paymentIdForTRwithdraw
                                  + ",'" + paymentInfoBo.TransCustCode
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
                                     Payment_ID
                                    ,Cust_code
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
                                     + paymentIdForTRdeposit
                                     + ",'" + paymentInfoBo.CustCode
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
        public void InsertIntoPayment_MoneyBalance_ForTRApproval(int[] paymentID)
        {
            string queryString_Payment_TRWithdraw = "";
            string queryString_Payment_TRDeposit = "";
            string queryString_MBalanceTemp_TRWithdraw = "";
            string queryString_MBalanceTemp_TRDeposit = "";
            string queryUpdateDepPosting = "";
            CommonBAL cmBal = new CommonBAL();

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
                               + " WHERE Payment_ID IN (" + paymentID[0] + "," + paymentID[1] +")";

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();
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

        public void InsertintoPaymentPosting(PaymentInfoBO paymentInfoBo)
        {
            string queryString = "";

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
                                         Payment_ID
                                        ,Cust_code
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
                                       + paymentInfoBo.PaymentId
                                       + ",'" + paymentInfoBo.CustCode
                                       + "'," + paymentInfoBo.Amount
                                       + ",'" + paymentInfoBo.RecievedDate.ToString("MM-dd-yyyy")
                                       + "','" + paymentInfoBo.PaymentMedia
                                       + "'," + maturityDays
                                       + ",'" + ""  //Payment_Media_No
                                       + "','" + paymentInfoBo.PaymentMediaDate.ToString("MM-dd-yyyy")
                                       + "'," + paymentInfoBo.Bank_ID
                                       + ",'" + paymentInfoBo.BankName
                                       + "'," + paymentInfoBo.Branch_ID
                                       + ",'" + paymentInfoBo.BranchName
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
                                             Payment_ID
                                            ,Cust_code
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
                                         + paymentInfoBo.PaymentId 
                                         + ",'" + paymentInfoBo.CustCode 
                                         + "'," + paymentInfoBo.Amount 
                                         + ",'" + paymentInfoBo.RecievedDate.ToString("MM-dd-yyyy") 
                                         + "','" + paymentInfoBo.PaymentMedia 
                                         + "'," + maturityDays 
                                         + ",'" + paymentInfoBo.PaymentMediaNo 
                                         + "','" + paymentInfoBo.PaymentMediaDate.ToString("MM-dd-yyyy")
                                         + "'," + paymentInfoBo.Bank_ID
                                         + ",'" + paymentInfoBo.BankName
                                         + "'," + paymentInfoBo.Branch_ID
                                         + ",'" + paymentInfoBo.BranchName 
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
                             Payment_ID
                            ,Cust_code
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
                            + paymentInfoBo.PaymentId
                            + ",'" + paymentInfoBo.CustCode
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
                            ,Bank_Code
                            ,Bank_Name AS 'Bank'
                            ,Branch_Code
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
                            )
                            ORDER BY Payment_Media"; ;
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

        public int GetPaymentIdFromPaymentByPaymentPostingPaymentId(int payment_RequisitionId)
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
        public void ApprovedSingleWithdraw(int paymentId, int paymentPostingRequest_paymentid)
        {
            CommonBAL cmBal = new CommonBAL();
            string queryUpdateDepPosting = "";
            string queryInsertPayment = "";
            string queryStringTemp = "";

            int _payment_PaymentId = -1;
            string _payment_Trans_Reason;
            _payment_PaymentId = GetPaymentIdFromPaymentByPaymentPostingPaymentId(paymentPostingRequest_paymentid);
            _payment_Trans_Reason = Indication_PaymentTransaction.Return_Indicator + "_" + _payment_PaymentId.ToString();

            queryUpdateDepPosting = "UPDATE SBP_Payment_Posting_Request"
                                           + " SET Approval_Status=1,"
                                           + " Payment_Approved_Date='" + cmBal.GetCurrentServerDate().ToString("MM-dd-yyyy") + "'"
                                           + " WHERE Payment_ID=" + paymentId + "";

            if (paymentPostingRequest_paymentid != -1)
            {
                queryInsertPayment = @" INSERT INTO dbo.SBP_Payment
                                        
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
                                        ,'" + _payment_Trans_Reason +@"' 
                                        , p.[Remarks]
                                        ,CAST(FLOOR(CAST(GETDATE() AS FLOAT)) AS DATETIME)
                                        ,'"+GlobalVariableBO._userName+@"'
                                        , p.[Maturity_Days]
                                        , p.[Payment_ID]
                                        ,'"+GlobalVariableBO._branchId+@"' 
                                        FROM  SBP_Payment_Posting_Request AS p
                                        WHERE
                                        p.Payment_ID="+ paymentId+"";
            }
            else
            {
                queryInsertPayment = "INSERT INTO SBP_Payment("
                                           + "Cust_code"
                                           + ",Amount"
                                           + ",Received_Date"
                                           + ",Payment_Media"
                                           + ",Maturity_Days"
                                           + ",Payment_Media_No"
                                           + ",Payment_Media_Date"
                                           + ",[Bank_ID]"
                                           + ",Bank_Name"
                                           + ",[Branch_ID]"
                                           + ",Bank_Branch"
                                           + ",received_By"
                                           + ",Deposit_Withdraw"
                                           + ",Payment_Approved_By"
                                           + ",Payment_Approved_Date"
                                           + ",Voucher_Sl_No"
                                           + ",Remarks"
                                           + ",Entry_Date"
                                           + ",Entry_By"
                                           + ",Requisition_ID"
                                           + ",Entry_Branch_ID"
                                           + ")"
                                           +
                                           "SELECT "
                                           + "Cust_Code"
                                           + ",Amount"
                                           + ",Received_Date"
                                           + ",Payment_Media"
                                           + ",Maturity_Days"
                                           + ",Payment_Media_No"
                                           + ",Payment_Media_Date"
                                           + ",[Bank_ID]"
                                           + ",Bank_Name"
                                           + ",[Branch_ID]"
                                           + ",Bank_Branch"
                                           + ",Received_By"
                                           + ",Deposit_Withdraw"
                                           + ",Payment_Approved_By"
                                           + ",Payment_Approved_Date"
                                           + ",Vouchar_SN"
                                           + ",Remarks"
                                           + ",CAST(FLOOR(CAST(GETDATE() AS FLOAT)) AS DATETIME)"
                                           + ",'" + GlobalVariableBO._userName + "'"
                                           + "," + paymentId
                                           + ",Entry_Branch_ID "
                                           + "FROM SBP_Payment_Posting_Request "
                                           + "WHERE Payment_ID=" + paymentId + "";

            }
            // string queryStringTemp = " INSERT INTO SBP_Money_Balance_Temp(Cust_Code,Sell_Deposit,Buy_Withdraw,Balance,Matured_Balance,Remarks,Rec_Date) SELECT Cust_Code,Amount,0,Amount,Amount,Payment_Media,Received_Date FROM SBP_Payment_Posting_Request WHERE Payment_Id=" + paymentId + "";
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
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();
                _dbConnection.ExecuteNonQuery(queryUpdateDepPosting);
                _dbConnection.ExecuteNonQuery(queryInsertPayment);
                _dbConnection.ExecuteNonQuery(queryStringTemp);
                _dbConnection.Commit();
            }
            catch (Exception)
            {
                _dbConnection.Rollback();

            }
            finally
            {
                _dbConnection.CloseDatabase();
            }

        }

        public void ApprovedSingleDeposit(int paymentId, int paymentPostingRequest_paymentid)
        {
            CommonBAL cmBal = new CommonBAL();
            string queryUpdateDepPosting = "";
            string queryInsertPayment = "";
            string queryStringTemp = "";

            int _payment_PaymentId = -1;
            string _payment_Trans_Reason = "";
            if (paymentPostingRequest_paymentid != -1)
            {
                _payment_PaymentId = GetPaymentIdFromPaymentByPaymentPostingPaymentId(paymentPostingRequest_paymentid);
                _payment_Trans_Reason = Indication_PaymentTransaction.Return_Indicator + "_" + _payment_PaymentId.ToString();
            }
          //  _payment_Trans_Reason = Indication_PaymentTransaction.Return_Indicator + "_" + paymentPostingRequest_paymentid.ToString();

            queryUpdateDepPosting =
                                  " UPDATE SBP_Payment_Posting_Request "
                                + " SET Approval_Status=1, "
                                + " Payment_Approved_Date='" + cmBal.GetCurrentServerDate().ToString("MM-dd-yyyy") + "'"
                                + " WHERE Payment_ID=" + paymentId + "";
            queryStringTemp = " INSERT INTO SBP_Money_Balance_Temp(Cust_Code,Sell_Deposit,Buy_Withdraw,Balance,Matured_Balance,Remarks,Rec_Date) SELECT Cust_Code,Amount,0,Amount,Amount,Payment_Media,Received_Date FROM SBP_Payment_Posting_Request WHERE Payment_Id=" + paymentId + "";

            if (paymentPostingRequest_paymentid != -1)
            {
                queryInsertPayment = @" INSERT INTO dbo.SBP_Payment
                                        
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
                queryInsertPayment = @"INSERT INTO SBP_Payment(
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
                                        ,received_By
                                        ,Deposit_Withdraw
                                        ,Payment_Approved_By
                                        ,Payment_Approved_Date
                                        ,Voucher_Sl_No
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
                                        ,Maturity_Days
                                        ,Payment_Media_No
                                        ,Payment_Media_Date
                                        ,Bank_ID
                                        ,Bank_Name
                                        ,Branch_ID
                                        ,Bank_Branch
                                        ,Received_By
                                        ,Deposit_Withdraw
                                        ,Payment_Approved_By
                                        ,Payment_Approved_Date
                                        ,Vouchar_SN
                                        ,Remarks
                                        ,CAST(FLOOR(CAST(GETDATE() AS FLOAT)) AS DATETIME)
                                        ,'" + GlobalVariableBO._userName + "'," 
                                        + paymentId 
                                        + ",Entry_Branch_ID FROM SBP_Payment_Posting_Request WHERE Payment_ID=" + paymentId + "";
            }
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();
                _dbConnection.ExecuteNonQuery(queryUpdateDepPosting);
                _dbConnection.ExecuteNonQuery(queryInsertPayment);
                _dbConnection.ExecuteNonQuery(queryStringTemp);
                _dbConnection.Commit();
            }
            catch (Exception)
            {
                _dbConnection.Rollback();

            }
            finally
            {
                _dbConnection.CloseDatabase();
            }

        }

        public void RejectSingleWithdraw(int paymentId, string rejectionReason)
        {
            CommonBAL cmnbal=new CommonBAL();
            string queryUpdateDepPosting = "UPDATE SBP_Payment_Posting_Request SET Approval_Status=2,Rejection_Reason='" + rejectionReason + "', Payment_Approved_Date='" +cmnbal.GetCurrentServerDate() + "' WHERE Payment_ID=" + paymentId + "";
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

        public void RejectSingleDeposit(int paymentId, string rejectionReason)
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

        public void CancelDeposit(int paymentId)
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
                            ,cbi.Bank_ID
                            ,cbi.Branch_ID
                            FROM dbo.SBP_Bank_Branch_Routing_Info AS bbri
                            JOIN dbo.SBP_Cust_Bank_Info AS cbi
                            ON bbri.Bank_ID=cbi.Bank_ID
                            AND bbri.Branch_ID=cbi.Branch_ID
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
                _dbConnection.AddParameter("@PaymentMedia", SqlDbType.VarChar, PaymentMedia);
                _dbConnection.AddParameter("@PaymentReceivedDate", SqlDbType.DateTime, PaymentReceivedDate.ToShortDateString());
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
        

//        public DataTable GetBankNameInfo()
//        {
//            DataTable dataTable = new DataTable();
//            string queryString = "";
//            queryString = @"SELECT 
//                                  [Bank_Code]
//                                 ,[Bank_Name]
//                            FROM SBP_Bank_Info";
//            try
//            {
//                _dbConnection.ConnectDatabase();
//                dataTable = _dbConnection.ExecuteQuery(queryString);
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//            finally
//            {
//                _dbConnection.CloseDatabase();
//            }
//            return dataTable;
//        }

//        public DataTable GetBranchNameInfo()
//        {
//            DataTable dataTable = new DataTable();
//            string queryString = "";
//            queryString = @"SELECT 
//                                  [Branch_Code]
//                                 ,[Branch_Name]
//                            FROM SBP_Branch_Info";
//            try
//            {
//                _dbConnection.ConnectDatabase();
//                dataTable = _dbConnection.ExecuteQuery(queryString);
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//            finally
//            {
//                _dbConnection.CloseDatabase();
//            }
//            return dataTable;
//        }
    }
}
