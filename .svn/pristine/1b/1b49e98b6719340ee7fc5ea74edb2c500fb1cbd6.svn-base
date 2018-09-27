using System;
using System.Data;
using System.Data.SqlClient;
using BusinessAccessLayer.BO;
using DataAccessLayer;
using BusinessAccessLayer.Constants;
using System.Linq;
using System.Data.Linq;

namespace BusinessAccessLayer.BAL
{
    public class IPOApprovalBAL
    {
        private DbConnection _dbConnection;

        public IPOApprovalBAL()
        {
            _dbConnection = new DbConnection();
        }

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

        /// Added By Shahrior On 27 Jan 2015       
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

        #region Cheque Clereance
        
        public DataTable GetChecqueApprovedData()
        {
            DataTable dt;
            dt = null;
            string Query = "";
            Query = @"SBP_IPOChequeApprovedGridData";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@Entry_Branch_ID", SqlDbType.Int, GlobalVariableBO._branchId);
                dt = _dbConnection.ExecuteProQuery(Query);
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
        
        #endregion

        #region 93Accounut Insert

        public void Insert_Into_93Account_Deposit_UITrans(string[] Trns_ID)
        {
            string transIDJoined = (Trns_ID.Length>0?string.Join(",", Trns_ID):"0");
            string query = "";
            query = @"INSERT INTO [SBP_Database].[dbo].[SBP_Payment]
                            ([Cust_Code]
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
                           --,[Maturity_Days]
                           --,[Requisition_ID]
                           ,[Entry_Branch_ID])
                     SELECT
                           93
                           ,TRN.Amount
                           ,TRN.Received_Date
                           ,TRN.Money_TransactionType_Name
                           ,TD.Cheque_No  
                           ,TD.Cheque_Date
                           ,TD.Bank_ID
                           ,TD.BankName
                           ,TRN.Entry_Branch_ID
                           ,TD.Branch_Name
                           ,TRN.Entry_By
                           ,TRN.Deposit_Withdraw
                           ,TRN.Approval_By
                           ,TRN.Approval_Date
                           ,TRN.Voucher_No
                           --,TRN.Trans_Reason
                           ,trn.Cust_Code
                           ,TRN.Remarks
                           ,TRN.Entry_Date
                           ,TRN.Entry_By
                           --,<Maturity_Days, int,>
                           --,<Requisition_ID, numeric(18,0),>
                           ,trn.Entry_Branch_ID           
                           FROM SBP_IPO_Customer_Broker_MoneyTransaction AS TRN
                           LEFT OUTER JOIN                            
                           SBP_IPO_Customer_Broker_Transaction_Details AS TD
			               ON TD.TransID=TRN.ID
			               WHERE trn.Money_TransactionType_Name<>'TRIPOApp' AND trn.Approval_Status=1 
                           AND trn.ID IN (" + transIDJoined + ")";
            try
            {
                // _dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(query);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Inesert_TransactionBasedCharge_Withdraw(string ChargeName,string Cust_Code,double Amount,DateTime ReceivedDate,int RefTransaction)
        {

            int NewId = 0;

            string query = "";
            string TransReasonPefix = Indication_TransactioBasedCharge.TransReasonList
                .Where(t => t.Key == ChargeName)
                .Select(t => Convert.ToString(t.Value)).FirstOrDefault();

            string VoucherNo = Indication_TransactioBasedCharge.VoucherSLnoList
                .Where(t => t.Key == ChargeName)
                .Select(t => Convert.ToString(t.Value)).FirstOrDefault();

            query = @"INSERT INTO [SBP_Database].[dbo].[SBP_Payment]
                            ([Cust_Code]
                           ,[Amount]
                           ,[Received_Date]
                           ,[Payment_Media]
                           ,[Deposit_Withdraw]
                           ,[Voucher_Sl_No]
                           ,[Trans_Reason]
                           ,[Remarks]
                           ,[Entry_Date]
                           ,[Entry_By]
                           ,[Entry_Branch_ID])
                   VALUES(
                            '" + Cust_Code + @"'
                            ," + Amount + @"
                            ,'" + ReceivedDate.ToShortDateString() + @"'
                            ,'" + VoucherNo + @"'
                            ,''
                            ,GETDATE()
                            ,'" + GlobalVariableBO._userName + @"'
                            ," + GlobalVariableBO._branchId + @"
                    )
                    Select SCOPE_IDENTITY()";

            try
            {
                _dbConnection.ConnectDatabase();
                NewId = _dbConnection.ExecuteScalar(query);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return NewId;
        }

        public int Inesert_TransactionBasedCharge_Withdraw_UITransApplied(string ChargeName, string Cust_Code, double Amount, DateTime ReceivedDate, int RefTransaction)
        {

            int NewId=0;

            string query = "";
            string TransReasonPefix = Indication_TransactioBasedCharge.TransReasonList
                .Where(t => t.Key == ChargeName)
                .Select(t => Convert.ToString(t.Value)).FirstOrDefault();

            string VoucherNo = Indication_TransactioBasedCharge.VoucherSLnoList
                .Where(t => t.Key == ChargeName)
                .Select(t => Convert.ToString(t.Value)).FirstOrDefault();

            query = @"INSERT INTO [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction]
                            ([Cust_Code]
                           ,[Amount]
                           ,[Received_Date]
                           ,[Money_TransactionType_Name]
                           ,[Deposit_Withdraw]
                           ,[Voucher_No]
                           ,[Trans_Reason]
                           ,[Remarks]
                           ,[Approval_Status]
                           ,[Entry_Date]
                           ,[Entry_By]
                           ,[Entry_Branch_ID]
                          )
                   VALUES(
                            '" + Cust_Code + @"'
                            ," + Amount + @"
                            ,'" + ReceivedDate.ToShortDateString() + @"'
                            ,'"+Indication_IPOPaymentTransaction.Cash+@"'
                            ,'"+Indication_PaymentMode.Withdraw+@"'
                            ,'" + VoucherNo + @"'
                            ,'"+TransReasonPefix+"_"+RefTransaction+@"'
                            ,''
                            ,1
                            ,GETDATE()
                            ,'" + GlobalVariableBO._userName + @"'
                            ," + GlobalVariableBO._branchId + @"
                    )
                    Select SCOPE_IDENTITY()";

            try
            {
                //_dbConnection.ConnectDatabase();
                NewId=_dbConnection.ExecuteScalar(query);

            }
            catch (Exception)
            {
                throw;
            }
            //finally
            //{
            //    _dbConnection.CloseDatabase();
            //}
            return NewId;
        }

        public int Inesert_IPoApplicationCharge_Withdraw_UITransApplied(string Cust_Code,double Amount,int IPOSessionID,string IPOSessionName)
        {

            int NewId = 0;

            string query = "";
            string TransReasonPefix = Indication_TransactioBasedCharge.TransReasonList
                .Where(t => t.Key == Indication_TransactioBasedCharge.IPOApp)
                .Select(t => Convert.ToString(t.Value)).FirstOrDefault();

            string VoucherNo = Indication_TransactioBasedCharge.VoucherSLnoList
                .Where(t => t.Key == Indication_TransactioBasedCharge.IPOApp)
                .Select(t => Convert.ToString(t.Value)).FirstOrDefault();
            

            query = @"INSERT INTO [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction]
                            ([Cust_Code]
                           ,[Amount]
                           ,[Received_Date]
                            ,[Money_TransactionType_ID]
                           ,[Money_TransactionType_Name]
                           ,[Deposit_Withdraw]
                           ,[Voucher_No]
                           ,[Trans_Reason]
                           ,[Remarks]
                           ,[Intended_IPOSession_ID]
                           ,[Intended_IPOSession_Name]
                           ,[Approval_Status]
                           ,[Entry_Date]
                           ,[Entry_By]
                           ,[Entry_Branch_ID]
                          )
                   VALUES(
                            '" + Cust_Code + @"'
                            ," + Amount + @"
                            ,'"+GlobalVariableBO._currentServerDate.Date+@"'
                            ,'" + Indication_IPOPaymentTransaction.Cash_ID + @"'
                            ,'" + Indication_IPOPaymentTransaction.Cash + @"'
                            ,'" + Indication_PaymentMode.Withdraw + @"'
                            ,'" + VoucherNo + @"'
                            ,'" + TransReasonPefix +@"'
                            ,''
                            ,'"+IPOSessionID+@"'
                            ,'"+IPOSessionName+ @"'                            
                            ,1
                            ,GETDATE()
                            ,'" + GlobalVariableBO._userName + @"'
                            ," + GlobalVariableBO._branchId + @"
                    )
                    Select SCOPE_IDENTITY()";

            try
            {
                //_dbConnection.ConnectDatabase();
                NewId = _dbConnection.ExecuteScalar(query);

            }
            catch (Exception)
            {
                throw;
            }
            //finally
            //{
            //    _dbConnection.CloseDatabase();
            //}
            return NewId;
        }
        public int Inesert_IPoApplicationCharge_Withdraw_UITransApplied(string Cust_Code, double Amount, int IPOSessionID, string IPOSessionName,string ApplicationType)
        {

            int NewId = 0;
            
            string query = "";
            string TransReasonPefix = Indication_TransactioBasedCharge.TransReasonList
                .Where(t => t.Key == ApplicationType)
                .Select(t => Convert.ToString(t.Value)).FirstOrDefault();

            string VoucherNo = Indication_TransactioBasedCharge.VoucherSLnoList
                .Where(t => t.Key == ApplicationType)
                .Select(t => Convert.ToString(t.Value)).FirstOrDefault();


            query = @"INSERT INTO [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction]
                            ([Cust_Code]
                           ,[Amount]
                           ,[Received_Date]
                            ,[Money_TransactionType_ID]
                           ,[Money_TransactionType_Name]
                           ,[Deposit_Withdraw]
                           ,[Voucher_No]
                           ,[Trans_Reason]
                           ,[Remarks]
                           ,[Intended_IPOSession_ID]
                           ,[Intended_IPOSession_Name]
                           ,[Approval_Status]
                           ,[Entry_Date]
                           ,[Entry_By]
                           ,[Entry_Branch_ID]
                          )
                   VALUES(
                            '" + Cust_Code + @"'
                            ," + Amount + @"
                            ,'" + GlobalVariableBO._currentServerDate.Date + @"'
                            ,(Select t.ID From [SBP_IPO_MoneyTrans_Type] AS t Where t.MoneyTransType_Name='" + Indication_IPOPaymentTransaction.Cash + @"')
                            ,'" + Indication_IPOPaymentTransaction.Cash + @"'
                            ,'" + Indication_PaymentMode.Withdraw + @"'
                            ,'" + VoucherNo + @"'
                            ,'" + TransReasonPefix + @"'
                            ,''
                            ,'" + IPOSessionID + @"'
                            ,'" + IPOSessionName + @"'                            
                            ,1
                            ,GETDATE()
                            ,'" + GlobalVariableBO._userName + @"'
                            ," + GlobalVariableBO._branchId + @"
                    )
                    Select SCOPE_IDENTITY()";

            try
            {
                //_dbConnection.ConnectDatabase();
                NewId = _dbConnection.ExecuteScalar(query);

            }
            catch (Exception)
            {
                throw;
            }
            //finally
            //{
            //    _dbConnection.CloseDatabase();
            //}
            return NewId;
        }

        public void Insert_Into_88Account_Deposit_Single(string[] Trns_ID)
        {
            string transIDJoined =(Trns_ID.Length>0?String.Join(",", Trns_ID):"0");
            string query = "";
            
            string TransReasonPefix=Indication_TransactioBasedCharge.TransReasonList
                .Where(t=> t.Key==Indication_TransactioBasedCharge.BankClearing)
                .Select(t=> Convert.ToString(t.Value)).FirstOrDefault();


            query = @"INSERT INTO [SBP_Database].[dbo].[SBP_Payment]
                            ([Cust_Code]
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
                           --,[Maturity_Days]
                           --,[Requisition_ID]
                           ,[Entry_Branch_ID])
                     SELECT
                           88
                           ,TRN.Amount
                           ,TRN.Received_Date
                           ,TRN.Money_TransactionType_Name
                           ,TD.Cheque_No  
                           ,TD.Cheque_Date
                           ,TD.Bank_ID
                           ,TD.BankName
                           ,TRN.Entry_Branch_ID
                           ,TD.Branch_Name
                           ,TRN.Entry_By
                           ,'Deposit'
                           ,TRN.Approval_By
                           ,TRN.Approval_Date
                           ,TRN.Voucher_No
                           --,TRN.Trans_Reason
                           ,trn.Cust_Code
                           ,TRN.Remarks
                           ,TRN.Entry_Date
                           ,TRN.Entry_By
                           --,<Maturity_Days, int,>
                           --,<Requisition_ID, numeric(18,0),>
                           ,trn.Entry_Branch_ID           
                           FROM SBP_IPO_Customer_Broker_Transaction_Details AS TD JOIN 
			                SBP_IPO_Customer_Broker_MoneyTransaction AS TRN ON TD.TransID=TRN.ID
			               WHERE trn.Trans_Reason LIKE '%"+TransReasonPefix+@"%' AND trn.Approval_Status=1 
                           AND trn.ID IN ('" + transIDJoined + "')";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(query);

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

        public void Insert_Into_88Account_Deposit_Single_UITransApplied(string[] Trns_ID)
        {
            string transIDJoined =(Trns_ID.Length>0?String.Join(",", Trns_ID):"0");
            string query = "";

            string TransReasonPefix = Indication_TransactioBasedCharge.TransReasonList
                .Where(t => t.Key == Indication_TransactioBasedCharge.BankClearing)
                .Select(t => Convert.ToString(t.Value)).FirstOrDefault();


            query = @"INSERT INTO [SBP_Database].[dbo].[SBP_Payment]
                            ([Cust_Code]
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
                           --,[Maturity_Days]
                           --,[Requisition_ID]
                           ,[Entry_Branch_ID])
                     SELECT
                           88
                           ,TRN.Amount
                           ,TRN.Received_Date
                           ,TRN.Money_TransactionType_Name
                           ,TD.Cheque_No  
                           ,TD.Cheque_Date
                           ,TD.Bank_ID
                           ,TD.BankName
                           ,TRN.Entry_Branch_ID
                           ,TD.Branch_Name
                           ,TRN.Entry_By
                           ,'Deposit'
                           ,TRN.Approval_By
                           ,TRN.Approval_Date
                           ,TRN.Voucher_No
                           --,TRN.Trans_Reason
                           ,trn.Cust_Code
                           ,TRN.Remarks
                           ,TRN.Entry_Date
                           ,TRN.Entry_By
                           --,<Maturity_Days, int,>
                           --,<Requisition_ID, numeric(18,0),>
                           ,trn.Entry_Branch_ID           
                           FROM SBP_IPO_Customer_Broker_Transaction_Details AS TD RIGHT OUTER JOIN 
			                SBP_IPO_Customer_Broker_MoneyTransaction AS TRN ON TD.TransID=TRN.ID
			               WHERE trn.Trans_Reason LIKE '%" + TransReasonPefix + @"%' AND trn.Approval_Status=1 
                           AND trn.ID IN ('" + transIDJoined + "')";
            try
            {
                //_dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(query);

            }
            catch (Exception)
            {
                throw;
            }
            //finally
            //{
            //    _dbConnection.CloseDatabase();
            //}

        }

        #region 71 Account
        
        public void Insert_Into_71Account_Deposit(string[] Trns_ID)
        {
            string transIDJoined = (Trns_ID.Length > 0 ? String.Join(",", Trns_ID) : "0");
            string query = "";
            query = @"INSERT INTO [SBP_Database].[dbo].[SBP_Payment]
                            ([Cust_Code]
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
                           --,[Maturity_Days]
                           --,[Requisition_ID]
                           ,[Entry_Branch_ID])
                     SELECT
                           '71'
                           ,TRN.Amount
                           ,TRN.Received_Date
                           ,TRN.Money_TransactionType_Name
                           ,TD.Cheque_No  
                           ,TD.Cheque_Date
                           ,TD.Bank_ID
                           ,TD.BankName
                           ,TRN.Entry_Branch_ID
                           ,TD.Branch_Name
                           ,TRN.Entry_By
                           ,'"+Indication_PaymentMode.Deposit+ @"'
                           ,TRN.Approval_By
                           ,TRN.Approval_Date
                           ,TRN.Voucher_No
                           --,TRN.Trans_Reason
                           ,(
                                CASE 
                                    --Not Applly Together TRTA
                                    WHEN Money_TransactionType_Name IN ('"+Indication_IPOPaymentTransaction.TRTA+@"') AND Trans_Reason NOT LIKE '%Refund%' AND ISNULL(Intended_IPOSession_ID,0)=0
                                            THEN REPLACE(TRN.Trans_Reason,SUBSTRING(TRN.Trans_Reason,CHARINDEX('_',TRN.Trans_Reason),LEN(TRN.Trans_Reason)),'')+'_'+Convert(Varchar(200),TRN.ID)
                                    --Apply Together TRTA
                                    WHEN Money_TransactionType_Name IN ('" + Indication_IPOPaymentTransaction.TRTA + @"') AND Trans_Reason NOT LIKE '%Refund%' AND ISNULL(Intended_IPOSession_ID,0)<>0
                                            THEN REPLACE(TRN.Trans_Reason,SUBSTRING(TRN.Trans_Reason,CHARINDEX('_',TRN.Trans_Reason),LEN(TRN.Trans_Reason)),'')+'_'+Intended_IPOSession_Name+'_'+Convert(Varchar(200),TRN.ID)
		                            --Refund TRTA
		                            WHEN Money_TransactionType_Name IN ('" + Indication_IPOPaymentTransaction.TRTA + @"') AND Trans_Reason LIKE '%Refund%'
                                            THEN  TRN.Cust_Code+'_'+TRN.Trans_Reason+'_'+[Intended_IPOSession_Name]+'_'+Convert(Varchar(200),TRN.ID)
                                    
                                    --Not Apply Together EFT
                                    WHEN Money_TransactionType_Name IN ('" + Indication_IPOPaymentTransaction.EFT + @"') AND Trans_Reason NOT LIKE '%Refund%' AND ISNULL(Intended_IPOSession_ID,0)=0
                                            THEN TRN.Cust_Code+'_'+Convert(Varchar(200),TRN.ID)
                                    --Apply Together EFT
                                    WHEN Money_TransactionType_Name IN ('" + Indication_IPOPaymentTransaction.EFT + @"') AND Trans_Reason NOT LIKE '%Refund%' AND ISNULL(Intended_IPOSession_ID,0)<>0
                                            THEN TRN.Cust_Code+'_'+Intended_IPOSession_Name+'_'+Convert(Varchar(200),TRN.ID)
		                            --Refund EFT
		                            WHEN Money_TransactionType_Name IN ('" + Indication_IPOPaymentTransaction.EFT + @"') AND Trans_Reason LIKE '%Refund%'
                                            THEN TRN.Cust_Code+'_'+TRN.Trans_Reason+'_'+[Intended_IPOSession_Name]+'_'+Convert(Varchar(200),TRN.ID)
                                    
                                    --Not Apply Together Cash
                                    WHEN Money_TransactionType_Name IN ('" + Indication_IPOPaymentTransaction.Cash + @"') AND Trans_Reason NOT LIKE '%Refund%' AND ISNULL(Intended_IPOSession_ID,0)=0
                                            THEN TRN.Cust_Code+'_'+Convert(Varchar(200),TRN.ID)
                                    --Apply Together Cash
                                    WHEN Money_TransactionType_Name IN ('" + Indication_IPOPaymentTransaction.Cash + @"') AND Trans_Reason NOT LIKE '%Refund%' AND ISNULL(Intended_IPOSession_ID,0)<>0
                                            THEN TRN.Cust_Code+'_'+Intended_IPOSession_Name+'_'+Convert(Varchar(200),TRN.ID)
                            		        
                                    WHEN Voucher_No='" + Indication_TransactioBasedCharge.VoucherSLnoList.Where(t => t.Key == Indication_TransactioBasedCharge.BankClearing).Select(t => t.Value).FirstOrDefault() + @"' THEN TRN.Cust_Code+'_'+TRN.Trans_Reason+'_'+Convert(Varchar(200),TRN.ID)
                                    WHEN Voucher_No='" + Indication_TransactioBasedCharge.VoucherSLnoList.Where(t => t.Key == Indication_TransactioBasedCharge.IPOApp).Select(t => t.Value).FirstOrDefault() + @"' THEN TRN.Cust_Code+'_'+TRN.Intended_IPOSession_Name+'_'+Convert(Varchar(200),TRN.ID)
                                    WHEN Voucher_No='" + Indication_TransactioBasedCharge.VoucherSLnoList.Where(t => t.Key == Indication_TransactioBasedCharge.IPOAppRefund).Select(t => t.Value).FirstOrDefault() + @"' THEN TRN.Cust_Code+'_'+TRN.Intended_IPOSession_Name+'_'+Convert(Varchar(200),TRN.ID)
                                    ELSE TRN.Cust_Code+'_'+Convert(Varchar(200),TRN.ID)
                                END
                            ) AS Trans_Reason                               
                           ,TRN.Intended_IPOSession_Name
                           ,TRN.Entry_Date
                           ,TRN.Entry_By
                           --,<Maturity_Days, int,>
                           --,<Requisition_ID, numeric(18,0),>
                           ,trn.Entry_Branch_ID           
                           FROM SBP_IPO_Customer_Broker_MoneyTransaction AS TRN
                           LEFT OUTER JOIN                            
                           SBP_IPO_Customer_Broker_Transaction_Details AS TD
			               ON TD.TransID=TRN.ID
			               WHERE TRN.Money_TransactionType_Name<>'TRIPOApp' AND trn.Approval_Status=1
                           AND TRN.Money_TransactionType_Name<>'" + Indication_IPOPaymentTransaction.TRIPO + @"'
                           AND TRN.Deposit_Withdraw='"+Indication_PaymentMode.Deposit+@"'
                           AND TRN.ID IN (" + transIDJoined + ")";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(query);

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

        public void Insert_Into_71Account_Deposit_UITransApplied(string[] Trns_ID)
        {
            string transIDJoined = (Trns_ID.Length > 0 ? String.Join(",", Trns_ID) : "0");
            string query = "";
            query = @"INSERT INTO [SBP_Database].[dbo].[SBP_Payment]
                            ([Cust_Code]
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
                           --,[Maturity_Days]
                           --,[Requisition_ID]
                           ,[Entry_Branch_ID])
                     SELECT
                           '71'
                           ,TRN.Amount
                           ,TRN.Received_Date
                           ,TRN.Money_TransactionType_Name
                           ,TD.Cheque_No  
                           ,TD.Cheque_Date
                           ,TD.Bank_ID
                           ,TD.BankName
                           ,TRN.Entry_Branch_ID
                           ,TD.Branch_Name
                           ,TRN.Entry_By
                           ,'" + Indication_PaymentMode.Deposit + @"'
                           ,TRN.Approval_By
                           ,TRN.Approval_Date
                           ,TRN.Voucher_No
                           --,TRN.Trans_Reason
                            ,(
                                CASE 
                                    --Not Applly Together TRTA
                                    WHEN Money_TransactionType_Name IN ('" + Indication_IPOPaymentTransaction.TRTA + @"') AND Trans_Reason NOT LIKE '%Refund%' AND ISNULL(Intended_IPOSession_ID,0)=0
                                            THEN REPLACE(TRN.Trans_Reason,SUBSTRING(TRN.Trans_Reason,CHARINDEX('_',TRN.Trans_Reason),LEN(TRN.Trans_Reason)),'')+'_'+Convert(Varchar(200),TRN.ID)
                                    --Apply Together TRTA
                                    WHEN Money_TransactionType_Name IN ('" + Indication_IPOPaymentTransaction.TRTA + @"') AND Trans_Reason NOT LIKE '%Refund%' AND ISNULL(Intended_IPOSession_ID,0)<>0
                                            THEN REPLACE(TRN.Trans_Reason,SUBSTRING(TRN.Trans_Reason,CHARINDEX('_',TRN.Trans_Reason),LEN(TRN.Trans_Reason)),'')+'_'+Intended_IPOSession_Name+'_'+Convert(Varchar(200),TRN.ID)
		                            --Refund TRTA
		                            WHEN Money_TransactionType_Name IN ('" + Indication_IPOPaymentTransaction.TRTA + @"') AND Trans_Reason LIKE '%Refund%'
                                            THEN  TRN.Cust_Code+'_'+TRN.Trans_Reason+'_'+[Intended_IPOSession_Name]+'_'+Convert(Varchar(200),TRN.ID)
                                    
                                    --Not Apply Together EFT
                                    WHEN Money_TransactionType_Name IN ('" + Indication_IPOPaymentTransaction.EFT + @"') AND Trans_Reason NOT LIKE '%Refund%' AND ISNULL(Intended_IPOSession_ID,0)=0
                                            THEN TRN.Cust_Code+'_'+Convert(Varchar(200),TRN.ID)
                                    --Apply Together EFT
                                    WHEN Money_TransactionType_Name IN ('" + Indication_IPOPaymentTransaction.EFT + @"') AND Trans_Reason NOT LIKE '%Refund%' AND ISNULL(Intended_IPOSession_ID,0)<>0
                                            THEN TRN.Cust_Code+'_'+Intended_IPOSession_Name+'_'+Convert(Varchar(200),TRN.ID)
		                            --Refund EFT
		                            WHEN Money_TransactionType_Name IN ('" + Indication_IPOPaymentTransaction.EFT + @"') AND Trans_Reason LIKE '%Refund%'
                                            THEN TRN.Cust_Code+'_'+TRN.Trans_Reason+'_'+[Intended_IPOSession_Name]+'_'+Convert(Varchar(200),TRN.ID)
                                    
                                    --Not Apply Together Cash
                                    WHEN Money_TransactionType_Name IN ('" + Indication_IPOPaymentTransaction.Cash + @"') AND Trans_Reason NOT LIKE '%Refund%' AND ISNULL(Intended_IPOSession_ID,0)=0
                                            THEN TRN.Cust_Code+'_'+Convert(Varchar(200),TRN.ID)
                                    --Apply Together Cash
                                    WHEN Money_TransactionType_Name IN ('" + Indication_IPOPaymentTransaction.Cash + @"') AND Trans_Reason NOT LIKE '%Refund%' AND ISNULL(Intended_IPOSession_ID,0)<>0
                                            THEN TRN.Cust_Code+'_'+Intended_IPOSession_Name+'_'+Convert(Varchar(200),TRN.ID)
                                    WHEN Money_TransactionType_Name IN ('" + Indication_IPOPaymentTransaction.EFT_Return + @"') AND Trans_Reason  LIKE '%EFTRETURN%' 
                                            THEN 'Return_'+Convert(Varchar(200),TRN.ID)
                            		        
                                    WHEN Voucher_No='" + Indication_TransactioBasedCharge.VoucherSLnoList.Where(t => t.Key == Indication_TransactioBasedCharge.BankClearing).Select(t => t.Value).FirstOrDefault() + @"' THEN TRN.Cust_Code+'_'+TRN.Trans_Reason+'_'+Convert(Varchar(200),TRN.ID)
                                    WHEN Voucher_No='" + Indication_TransactioBasedCharge.VoucherSLnoList.Where(t => t.Key == Indication_TransactioBasedCharge.IPOApp).Select(t => t.Value).FirstOrDefault() + @"' THEN TRN.Cust_Code+'_'+TRN.Intended_IPOSession_Name+'_'+Convert(Varchar(200),TRN.ID)
                                    WHEN Voucher_No='" + Indication_TransactioBasedCharge.VoucherSLnoList.Where(t => t.Key == Indication_TransactioBasedCharge.IPOAppRefund).Select(t => t.Value).FirstOrDefault() + @"' THEN TRN.Cust_Code+'_'+TRN.Intended_IPOSession_Name+'_'+Convert(Varchar(200),TRN.ID)
                                    ELSE TRN.Cust_Code+'_'+Convert(Varchar(200),TRN.ID)
                                END
                            ) AS Trans_Reason                                
                           ,TRN.Intended_IPOSession_Name
                           ,TRN.Entry_Date
                           ,TRN.Entry_By
                           --,<Maturity_Days, int,>
                           --,<Requisition_ID, numeric(18,0),>
                           ,trn.Entry_Branch_ID           
                           FROM SBP_IPO_Customer_Broker_MoneyTransaction AS TRN
                           LEFT OUTER JOIN                            
                           SBP_IPO_Customer_Broker_Transaction_Details AS TD
			               ON TD.TransID=TRN.ID
			               WHERE TRN.Money_TransactionType_Name<>'TRIPOApp' AND trn.Approval_Status=1
                           AND TRN.Money_TransactionType_Name<>'" + Indication_IPOPaymentTransaction.TRIPO + @"'
                           AND TRN.Deposit_Withdraw='" + Indication_PaymentMode.Deposit + @"'
                           AND TRN.ID IN (" + transIDJoined.ToString() + ")";
            try
            {
                //_dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(query);

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

        public void Insert_Into_71Account_Withdraw(string[] Trns_ID)
        {
            string transIDJoined = (Trns_ID.Length > 0 ? String.Join(",", Trns_ID) : "0");
            string query = "";
            query = @"INSERT INTO [SBP_Database].[dbo].[SBP_Payment]
                            ([Cust_Code]
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
                           --,[Maturity_Days]
                           --,[Requisition_ID]
                           ,[Entry_Branch_ID])
                     SELECT
                           '71'
                           ,TRN.Amount
                           ,TRN.Received_Date
                           ,TRN.Money_TransactionType_Name
                           ,TD.Cheque_No  
                           ,TD.Cheque_Date
                           ,TD.Bank_ID
                           ,TD.BankName
                           ,TRN.Entry_Branch_ID
                           ,TD.Branch_Name
                           ,TRN.Entry_By
                           ,'" + Indication_PaymentMode.Withdraw + @"'
                           ,TRN.Approval_By
                           ,TRN.Approval_Date
                           ,TRN.Voucher_No
                           --,TRN.Trans_Reason
                          ,(
                                CASE 
                                    --Not Applly Together TRTA
                                    WHEN Money_TransactionType_Name IN ('" + Indication_IPOPaymentTransaction.TRTA + @"') AND Trans_Reason NOT LIKE '%Refund%' AND ISNULL(Intended_IPOSession_ID,0)=0
                                            THEN REPLACE(TRN.Trans_Reason,SUBSTRING(TRN.Trans_Reason,CHARINDEX('_',TRN.Trans_Reason),LEN(TRN.Trans_Reason)),'')+'_'+Convert(Varchar(200),TRN.ID)
                                    --Apply Together TRTA
                                    WHEN Money_TransactionType_Name IN ('" + Indication_IPOPaymentTransaction.TRTA + @"') AND Trans_Reason NOT LIKE '%Refund%' AND ISNULL(Intended_IPOSession_ID,0)<>0
                                            THEN REPLACE(TRN.Trans_Reason,SUBSTRING(TRN.Trans_Reason,CHARINDEX('_',TRN.Trans_Reason),LEN(TRN.Trans_Reason)),'')+'_'+Intended_IPOSession_Name+'_'+Convert(Varchar(200),TRN.ID)
		                            --Refund TRTA
		                            WHEN Money_TransactionType_Name IN ('" + Indication_IPOPaymentTransaction.TRTA + @"') AND Trans_Reason LIKE '%Refund%'
                                            THEN  TRN.Cust_Code+'_'+TRN.Trans_Reason+'_'+[Intended_IPOSession_Name]+'_'+Convert(Varchar(200),TRN.ID)
                                    
                                    --Not Apply Together EFT
                                    WHEN Money_TransactionType_Name IN ('" + Indication_IPOPaymentTransaction.EFT + @"') AND Trans_Reason NOT LIKE '%Refund%' AND ISNULL(Intended_IPOSession_ID,0)=0
                                            THEN TRN.Cust_Code+'_'+Convert(Varchar(200),TRN.ID)
                                    --Apply Together EFT
                                    WHEN Money_TransactionType_Name IN ('" + Indication_IPOPaymentTransaction.EFT + @"') AND Trans_Reason NOT LIKE '%Refund%' AND ISNULL(Intended_IPOSession_ID,0)<>0
                                            THEN TRN.Cust_Code+'_'+Intended_IPOSession_Name+'_'+Convert(Varchar(200),TRN.ID)
		                            --Refund EFT
		                            WHEN Money_TransactionType_Name IN ('" + Indication_IPOPaymentTransaction.EFT + @"') AND Trans_Reason LIKE '%Refund%'
                                            THEN TRN.Cust_Code+'_'+TRN.Trans_Reason+'_'+[Intended_IPOSession_Name]+'_'+Convert(Varchar(200),TRN.ID)
                                    
                                    --Not Apply Together Cash
                                    WHEN Money_TransactionType_Name IN ('" + Indication_IPOPaymentTransaction.Cash + @"') AND Trans_Reason NOT LIKE '%Refund%' AND ISNULL(Intended_IPOSession_ID,0)=0
                                            THEN TRN.Cust_Code+'_'+Convert(Varchar(200),TRN.ID)
                                    --Apply Together Cash
                                    WHEN Money_TransactionType_Name IN ('" + Indication_IPOPaymentTransaction.Cash + @"') AND Trans_Reason NOT LIKE '%Refund%' AND ISNULL(Intended_IPOSession_ID,0)<>0
                                            THEN TRN.Cust_Code+'_'+Intended_IPOSession_Name+'_'+Convert(Varchar(200),TRN.ID)
                            		        
                                    WHEN Voucher_No='" + Indication_TransactioBasedCharge.VoucherSLnoList.Where(t => t.Key == Indication_TransactioBasedCharge.BankClearing).Select(t => t.Value).FirstOrDefault() + @"' THEN TRN.Cust_Code+'_'+TRN.Trans_Reason+'_'+Convert(Varchar(200),TRN.ID)
                                    WHEN Voucher_No='" + Indication_TransactioBasedCharge.VoucherSLnoList.Where(t => t.Key == Indication_TransactioBasedCharge.IPOApp).Select(t => t.Value).FirstOrDefault() + @"' THEN TRN.Cust_Code+'_'+TRN.Intended_IPOSession_Name+'_'+Convert(Varchar(200),TRN.ID)
                                    WHEN Voucher_No='" + Indication_TransactioBasedCharge.VoucherSLnoList.Where(t => t.Key == Indication_TransactioBasedCharge.IPOAppRefund).Select(t => t.Value).FirstOrDefault() + @"' THEN TRN.Cust_Code+'_'+TRN.Intended_IPOSession_Name+'_'+Convert(Varchar(200),TRN.ID)
                                    ELSE TRN.Cust_Code+'_'+Convert(Varchar(200),TRN.ID)
                                END
                            ) AS Trans_Reason   
                           ,TRN.Intended_IPOSession_Name
                           ,TRN.Entry_Date
                           ,TRN.Entry_By
                           --,<Maturity_Days, int,>
                           --,<Requisition_ID, numeric(18,0),>
                           ,trn.Entry_Branch_ID           
                           FROM SBP_IPO_Customer_Broker_MoneyTransaction AS TRN
                           LEFT OUTER JOIN                            
                           SBP_IPO_Customer_Broker_Transaction_Details AS TD
			               ON TD.TransID=TRN.ID
			               WHERE TRN.Money_TransactionType_Name<>'TRIPOApp' AND trn.Approval_Status=1
                           AND TRN.Money_TransactionType_Name<>'" + Indication_IPOPaymentTransaction.TRIPO + @"'
                           AND TRN.Deposit_Withdraw='" + Indication_PaymentMode.Withdraw + @"'       
                           AND TRN.ID IN (" + transIDJoined + ")";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(query);

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

        public void Insert_Into_71Account_Withdraw_UITransApplied(string[] Trns_ID)
        {
            string transIDJoined = (Trns_ID.Length>0?String.Join(",", Trns_ID):"0");
            string query = "";
            query = @"INSERT INTO [SBP_Database].[dbo].[SBP_Payment]
                            ([Cust_Code]
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
                           --,[Maturity_Days]
                           --,[Requisition_ID]
                           ,[Entry_Branch_ID])
                     SELECT
                           '71'
                           ,TRN.Amount
                           ,TRN.Received_Date
                           ,TRN.Money_TransactionType_Name
                           ,TD.Cheque_No  
                           ,TD.Cheque_Date
                           ,TD.Bank_ID
                           ,TD.BankName
                           ,TRN.Entry_Branch_ID
                           ,TD.Branch_Name
                           ,TRN.Entry_By
                           ,'" + Indication_PaymentMode.Withdraw + @"'
                           ,TRN.Approval_By
                           ,TRN.Approval_Date
                           ,TRN.Voucher_No
                           --,TRN.Trans_Reason
                          ,(
                                CASE 
                                    --Not Applly Together TRTA
                                    WHEN Money_TransactionType_Name IN ('" + Indication_IPOPaymentTransaction.TRTA + @"') AND Trans_Reason NOT LIKE '%Refund%' AND ISNULL(Intended_IPOSession_ID,0)=0
                                            THEN REPLACE(TRN.Trans_Reason,SUBSTRING(TRN.Trans_Reason,CHARINDEX('_',TRN.Trans_Reason),LEN(TRN.Trans_Reason)),'')+'_'+Convert(Varchar(200),TRN.ID)
                                    --Apply Together TRTA
                                    WHEN Money_TransactionType_Name IN ('" + Indication_IPOPaymentTransaction.TRTA + @"') AND Trans_Reason NOT LIKE '%Refund%' AND ISNULL(Intended_IPOSession_ID,0)<>0
                                            THEN REPLACE(TRN.Trans_Reason,SUBSTRING(TRN.Trans_Reason,CHARINDEX('_',TRN.Trans_Reason),LEN(TRN.Trans_Reason)),'')+'_'+Intended_IPOSession_Name+'_'+Convert(Varchar(200),TRN.ID)
		                            --Refund TRTA
		                            WHEN Money_TransactionType_Name IN ('" + Indication_IPOPaymentTransaction.TRTA + @"') AND Trans_Reason LIKE '%Refund%'
                                            THEN  TRN.Cust_Code+'_'+TRN.Trans_Reason+'_'+[Intended_IPOSession_Name]+'_'+Convert(Varchar(200),TRN.ID)
                                    
                                    --Not Apply Together EFT
                                    WHEN Money_TransactionType_Name IN ('" + Indication_IPOPaymentTransaction.EFT + @"') AND Trans_Reason NOT LIKE '%Refund%' AND ISNULL(Intended_IPOSession_ID,0)=0
                                            THEN TRN.Cust_Code+'_'+Convert(Varchar(200),TRN.ID)
                                    --Apply Together EFT
                                    WHEN Money_TransactionType_Name IN ('" + Indication_IPOPaymentTransaction.EFT + @"') AND Trans_Reason NOT LIKE '%Refund%' AND ISNULL(Intended_IPOSession_ID,0)<>0
                                            THEN TRN.Cust_Code+'_'+Intended_IPOSession_Name+'_'+Convert(Varchar(200),TRN.ID)
		                            --Refund EFT
		                            WHEN Money_TransactionType_Name IN ('" + Indication_IPOPaymentTransaction.EFT + @"') AND Trans_Reason LIKE '%Refund%'
                                            THEN TRN.Cust_Code+'_'+TRN.Trans_Reason+'_'+[Intended_IPOSession_Name]+'_'+Convert(Varchar(200),TRN.ID)
                                    
                                    --Not Apply Together Cash
                                    WHEN Money_TransactionType_Name IN ('" + Indication_IPOPaymentTransaction.Cash + @"') AND Trans_Reason NOT LIKE '%Refund%' AND ISNULL(Intended_IPOSession_ID,0)=0
                                            THEN TRN.Cust_Code+'_'+Convert(Varchar(200),TRN.ID)
                                    --Apply Together Cash
                                    WHEN Money_TransactionType_Name IN ('" + Indication_IPOPaymentTransaction.Cash + @"') AND Trans_Reason NOT LIKE '%Refund%' AND ISNULL(Intended_IPOSession_ID,0)<>0
                                            THEN TRN.Cust_Code+'_'+Intended_IPOSession_Name+'_'+Convert(Varchar(200),TRN.ID)
                            		        
                                    WHEN Voucher_No='" + Indication_TransactioBasedCharge.VoucherSLnoList.Where(t => t.Key == Indication_TransactioBasedCharge.BankClearing).Select(t => t.Value).FirstOrDefault() + @"' THEN TRN.Cust_Code+'_'+TRN.Trans_Reason+'_'+Convert(Varchar(200),TRN.ID)
                                    WHEN Voucher_No='" + Indication_TransactioBasedCharge.VoucherSLnoList.Where(t => t.Key == Indication_TransactioBasedCharge.IPOApp).Select(t => t.Value).FirstOrDefault() + @"' THEN TRN.Cust_Code+'_'+TRN.Intended_IPOSession_Name+'_'+Convert(Varchar(200),TRN.ID)
                                    WHEN Voucher_No='" + Indication_TransactioBasedCharge.VoucherSLnoList.Where(t => t.Key == Indication_TransactioBasedCharge.IPOAppRefund).Select(t => t.Value).FirstOrDefault() + @"' THEN TRN.Cust_Code+'_'+TRN.Intended_IPOSession_Name+'_'+Convert(Varchar(200),TRN.ID)
                                    WHEN Voucher_No='" + Indication_TransactioBasedCharge.VoucherSLnoList.Where(t => t.Key == Indication_TransactioBasedCharge.IPONRBAppRefund).Select(t => t.Value).FirstOrDefault() + @"' THEN TRN.Cust_Code+'_'+TRN.Intended_IPOSession_Name+'_'+Convert(Varchar(200),TRN.ID)
                                    ELSE TRN.Cust_Code+'_'+Convert(Varchar(200),TRN.ID)
                                END
                            ) AS Trans_Reason      
                           ,TRN.Intended_IPOSession_Name
                           ,TRN.Entry_Date
                           ,TRN.Entry_By
                           --,<Maturity_Days, int,>
                           --,<Requisition_ID, numeric(18,0),>
                           ,trn.Entry_Branch_ID           
                           FROM SBP_IPO_Customer_Broker_MoneyTransaction AS TRN
                           LEFT OUTER JOIN                            
                           SBP_IPO_Customer_Broker_Transaction_Details AS TD
			               ON TD.TransID=TRN.ID
			               WHERE TRN.Money_TransactionType_Name<>'TRIPOApp' AND trn.Approval_Status=1
                           AND TRN.Money_TransactionType_Name<>'" + Indication_IPOPaymentTransaction.TRIPO + @"'
                           AND TRN.Deposit_Withdraw='" + Indication_PaymentMode.Withdraw + @"'       
                           AND TRN.ID IN (" + transIDJoined + ")";
            try
            {
                //_dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(query);

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

        #endregion

        #region 72 Account

        public void Insert_Into_72Account_Deposit(string[] Charge_Trns_ID)
        {
            string transIDJoined = (Charge_Trns_ID.Length > 0 ? String.Join(",", Charge_Trns_ID) : "0");
            string query = "";
            query = @" INSERT INTO [SBP_Database].[dbo].[SBP_Payment]
                            ([Cust_Code]
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
                           --,[Maturity_Days]
                           --,[Requisition_ID]
                           ,[Entry_Branch_ID])
                        SELECT
                        '72'
                        ,TRN.Amount
                        ,TRN.Received_Date
                        ,TRN.Money_TransactionType_Name
                        ,''
                        ,NULL
                        ,0
                        ,''
                        ,TRN.Entry_Branch_ID
                        ,''
                        ,TRN.Entry_By
                        ,'" + Indication_PaymentMode.Deposit + @"'
                        ,TRN.Approval_By
                        ,TRN.Approval_Date
                        ,TRN.Voucher_No
                        --,TRN.Trans_Reason
                        ,(TRN.Cust_Code+'_'+TRN.Intended_IPOSession_Name) AS Trans_Reason                               
                        ,TRN.Intended_IPOSession_Name
                        ,TRN.Entry_Date
                        ,TRN.Entry_By
                        --,<Maturity_Days, int,>
                        --,<Requisition_ID, numeric(18,0),>
                        ,trn.Entry_Branch_ID 
                        FROM SBP_IPO_Customer_Broker_MoneyTransaction AS TRN
                        WHERE TRN.Money_TransactionType_Name='" + Indication_IPOPaymentTransaction.Cash+@"'
                        AND TRN.Deposit_Withdraw='"+Indication_PaymentMode.Withdraw+@"'
                        AND TRN.Voucher_No='"+(Indication_TransactioBasedCharge.VoucherSLnoList.Where(t=> t.Key==Indication_TransactioBasedCharge.IPOApp).FirstOrDefault())+@"'
                        AND TRN.Trans_Reason LIKE '"+(Indication_TransactioBasedCharge.TransReasonList.Where(t=> t.Key==Indication_TransactioBasedCharge.IPOApp).FirstOrDefault())+@"'
                        AND TRN.Approval_Status=1
                        AND TRN.ID IN (" + transIDJoined + @");";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(query);

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
        public void Insert_Into_72Account_Deposit_UITransApplied(string[] Charge_Trns_ID)
        {
            string transIDJoined = (Charge_Trns_ID.Length > 0 ? String.Join(",", Charge_Trns_ID) : "0");
            string query = "";
            query = @" INSERT INTO [SBP_Database].[dbo].[SBP_72]
           ([Cust_Code]
           ,[Deposit_Withdraw]
           ,[amount]
           ,[Trans_Reason]
           ,[Session_ID]
           ,[Remarks]
           ,[Entry_By]
           ,[Entry_Date])
           
           select 72,'Deposit',5
          ,CAST(CONVERT(varchar(100), T.ID)+CAST(
          (case 
          when Voucher_No='iposc' then '_IPOSC_'
          when Voucher_No='IPOWC' Then '_IPOWC_' end) as varchar(100)) +CONVERT(varchar(10), Cust_Code)+'_'+CAST(T.Intended_IPOSession_Name as varchar(100)) as varchar(100))
          ,T.Intended_IPOSession_ID
          ,T.Money_TransactionType_Name+'_'+t.Trans_Reason
          ,'"+GlobalVariableBO._userName+@"'
          ,Getdate()
          From SBP_IPO_Customer_Broker_MoneyTransaction  As T
          Where Voucher_No iN ('iposc','IPOWC')
          And T.ID IN ("+transIDJoined+")";
            try
            {
                //_dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(query);

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

//        public void Insert_Into_72Account_Deposit_UITransApplied(string[] Charge_Trns_ID)
//        {
//            string transIDJoined = (Charge_Trns_ID.Length > 0 ? String.Join(",", Charge_Trns_ID) : "0");
//            string query = "";
//            query = @" INSERT INTO [SBP_Database].[dbo].[SBP_Payment]
//                            ([Cust_Code]
//                           ,[Amount]
//                           ,[Received_Date]
//                           ,[Payment_Media]
//                           ,[Payment_Media_No]
//                           ,[Payment_Media_Date]
//                           ,[Bank_ID]
//                           ,[Bank_Name]
//                           ,[Branch_ID]
//                           ,[Bank_Branch]
//                           ,[Received_By]
//                           ,[Deposit_Withdraw]
//                           ,[Payment_Approved_By]
//                           ,[Payment_Approved_Date]
//                           ,[Voucher_Sl_No]
//                           ,[Trans_Reason]
//                           ,[Remarks]
//                           ,[Entry_Date]
//                           ,[Entry_By]
//                           --,[Maturity_Days]
//                           --,[Requisition_ID]
//                           ,[Entry_Branch_ID])
//                        SELECT
//                        '72'
//                        ,TRN.Amount
//                        ,TRN.Received_Date
//                        ,TRN.Money_TransactionType_Name
//                        ,''
//                        ,NULL
//                        ,0
//                        ,''
//                        ,TRN.Entry_Branch_ID
//                        ,''
//                        ,TRN.Entry_By
//                        ,'" + Indication_PaymentMode.Deposit + @"'
//                        ,TRN.Approval_By
//                        ,TRN.Approval_Date
//                        ,TRN.Voucher_No
//                        --,TRN.Trans_Reason
//                        ,(TRN.Cust_Code+'_'+TRN.Intended_IPOSession_Name) AS Trans_Reason                               
//                        ,TRN.Intended_IPOSession_Name
//                        ,TRN.Entry_Date
//                        ,TRN.Entry_By
//                        --,<Maturity_Days, int,>
//                        --,<Requisition_ID, numeric(18,0),>
//                        ,trn.Entry_Branch_ID 
//                        FROM SBP_IPO_Customer_Broker_MoneyTransaction AS TRN
//                        WHERE TRN.Money_TransactionType_Name='" + Indication_IPOPaymentTransaction.Cash + @"'
//                        AND TRN.Deposit_Withdraw='" + Indication_PaymentMode.Withdraw + @"'
//                        AND TRN.Voucher_No='" + (Indication_TransactioBasedCharge.VoucherSLnoList.Where(t => t.Key == Indication_TransactioBasedCharge.IPOApp).Select(t=> t.Value).FirstOrDefault()) + @"'
//                        AND TRN.Trans_Reason LIKE '" + (Indication_TransactioBasedCharge.TransReasonList.Where(t => t.Key == Indication_TransactioBasedCharge.IPOApp).Select(t => t.Value).FirstOrDefault()) + @"'
//                        OR TRN.Trans_Reason LIKE '" + (Indication_TransactioBasedCharge.TransReasonList.Where(t => t.Key == Indication_TransactioBasedCharge.IPONRBApp).Select(t => t.Value).FirstOrDefault()) + @"'
//                        AND TRN.Approval_Status=1
//                        AND TRN.ID IN (" + transIDJoined + @");";
//            try
//            {
//                //_dbConnection.ConnectDatabase();
//                _dbConnection.ExecuteNonQuery(query);

//            }
//            catch (Exception)
//            {
//                throw;
//            }
//            finally
//            {
//                //_dbConnection.CloseDatabase();
//            }

//        }

        public void Insert_Into_72Account_Deposit_UITransApplied_NRB_Refund(string[] Charge_Trns_ID)
        {
            string transIDJoined = (Charge_Trns_ID.Length > 0 ? String.Join(",", Charge_Trns_ID) : "0");
            string query = "";
            query = @" INSERT INTO [SBP_Database].[dbo].[SBP_Payment]
                            ([Cust_Code]
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
                           --,[Maturity_Days]
                           --,[Requisition_ID]
                           ,[Entry_Branch_ID])
                        SELECT
                        '72'
                        ,TRN.Amount
                        ,TRN.Received_Date
                        ,TRN.Money_TransactionType_Name
                        ,''
                        ,NULL
                        ,0
                        ,''
                        ,TRN.Entry_Branch_ID
                        ,''
                        ,TRN.Entry_By
                        ,'" + Indication_PaymentMode.Deposit + @"'
                        ,TRN.Approval_By
                        ,TRN.Approval_Date
                        ,TRN.Voucher_No
                        --,TRN.Trans_Reason
                        ,(TRN.Cust_Code+'_'+TRN.Intended_IPOSession_Name) AS Trans_Reason                               
                        ,TRN.Intended_IPOSession_Name
                        ,TRN.Entry_Date
                        ,TRN.Entry_By
                        --,<Maturity_Days, int,>
                        --,<Requisition_ID, numeric(18,0),>
                        ,trn.Entry_Branch_ID 
                        FROM SBP_IPO_Customer_Broker_MoneyTransaction AS TRN
                        WHERE TRN.Money_TransactionType_Name='" + Indication_IPOPaymentTransaction.Cash + @"'
                        AND TRN.Deposit_Withdraw='" + Indication_PaymentMode.Withdraw + @"'
                        AND TRN.Voucher_No='" + (Indication_TransactioBasedCharge.VoucherSLnoList.Where(t => t.Key == Indication_TransactioBasedCharge.IPONRBAppRefund).Select(t => t.Value).FirstOrDefault()) + @"'
                        AND TRN.Trans_Reason LIKE '" + (Indication_TransactioBasedCharge.TransReasonList.Where(t => t.Key == Indication_TransactioBasedCharge.IPONRBAppRefund).Select(t => t.Value).FirstOrDefault()) + @"'
                        AND TRN.Approval_Status=1
                        AND TRN.ID IN (" + transIDJoined + @");";
            try
            {
                //_dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(query);

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

        #endregion 72 Account

        #endregion

        #region Customer Account Money Balance Checking

        public double GetIPOCustomerBalance_ForApplication_UITransApply(string cust_Code)
        {
            DataTable dataTable;
            double result = 0.00;
            dataTable = null;
            string queryString = "";
            queryString = @"SELECT
	                        (	Select c.Cust_Name
		                        From SBP_Cust_Personal_Info as c
		                        Where c.Cust_Code= cust.Cust_Code
	                        )AS Cust_Name
	                        ,
                            ISNULL(SUM(ipoBal.Deposit)-SUM(ipoBal.Withdraw),0) AS Balance
	                        FROM(
			                        SELECT [ID]
			                          ,[Cust_Code]
			                          ,[Money_TransactionType_ID]
			                          ,[Money_TransactionType_Name]
			                          ,(
					                        CASE 
						                        WHEN [Deposit_Withdraw]='Deposit' THEN [Amount]
						                        ELSE 0.00
					                        END
			                           ) Deposit
			                          ,(
					                        CASE 
						                        WHEN [Deposit_Withdraw]='Withdraw' THEN [Amount]
						                        ELSE 0.00
					                        END
			                           )AS Withdraw
			                          ,[Amount]
			                          ,[Voucher_No]
			                          ,[Trans_Reason]
			                          ,[Intended_IPOSession_ID]
			                          ,[Intended_IPOSession_Name]
			                          ,[Approval_Status]
			                          ,[Approval_Date]
			                          ,[Approval_By]
			                          ,[Entry_Date]
			                          ,[Entry_By]
			                          ,[Updated_Date]
			                          ,[Update_By]
		                          FROM [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction]
		                          WHERE ( Money_TransactionType_Name<>'" + Indication_IPOPaymentTransaction.Cheque + @"' AND [Approval_Status]=1 )
                                  OR
                                  ( Money_TransactionType_Name='" + Indication_IPOPaymentTransaction.Cheque + @"' AND [Approval_Status]=1  AND Clearing_Status=1)  
	                        ) AS ipoBal
	                        RIGHT OUTER JOIN
	                        SBP_Customers as cust
	                        ON
	                        ipoBal.Cust_Code=cust.Cust_Code
	                        WHERE cust.Cust_Code='" + cust_Code + @"'
	                        GROUP BY cust.Cust_Code";
            try
            {
                //_dbConnection.ConnectDatabase();
                dataTable = _dbConnection.ExecuteQuery(queryString);
                if (dataTable.Rows.Count > 0)
                    result = Convert.ToDouble(dataTable.Rows[0]["Balance"].ToString());
            }
            catch (Exception)
            {
                throw;
            }
            //finally
            //{
            //    _dbConnection.CloseDatabase();
            //}
            return result;
        }

        public double GetIPOCustomerBalance_ForApplication(string cust_Code)
        {
            DataTable dataTable;
            double result = 0.00;
            dataTable = null;
            string queryString = "";
            queryString = @"SELECT
	                        (	Select c.Cust_Name
		                        From SBP_Cust_Personal_Info as c
		                        Where c.Cust_Code= cust.Cust_Code
	                        )AS Cust_Name
	                        ,
                            ISNULL(SUM(ipoBal.Deposit)-SUM(ipoBal.Withdraw),0) AS Balance
	                        FROM(
			                        SELECT [ID]
			                          ,[Cust_Code]
			                          ,[Money_TransactionType_ID]
			                          ,[Money_TransactionType_Name]
			                          ,(
					                        CASE 
						                        WHEN [Deposit_Withdraw]='Deposit' THEN [Amount]
						                        ELSE 0.00
					                        END
			                           ) Deposit
			                          ,(
					                        CASE 
						                        WHEN [Deposit_Withdraw]='Withdraw' THEN [Amount]
						                        ELSE 0.00
					                        END
			                           )AS Withdraw
			                          ,[Amount]
			                          ,[Voucher_No]
			                          ,[Trans_Reason]
			                          ,[Intended_IPOSession_ID]
			                          ,[Intended_IPOSession_Name]
			                          ,[Approval_Status]
			                          ,[Approval_Date]
			                          ,[Approval_By]
			                          ,[Entry_Date]
			                          ,[Entry_By]
			                          ,[Updated_Date]
			                          ,[Update_By]
		                          FROM [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction]
		                          WHERE ( Money_TransactionType_Name<>'" + Indication_IPOPaymentTransaction.Cheque + @"' AND [Approval_Status]=1 )
                                  OR
                                  ( Money_TransactionType_Name='" + Indication_IPOPaymentTransaction.Cheque + @"' AND [Approval_Status]=1  AND Clearing_Status=1)  
	                        ) AS ipoBal
	                        RIGHT OUTER JOIN
	                        SBP_Customers as cust
	                        ON
	                        ipoBal.Cust_Code=cust.Cust_Code
	                        WHERE cust.Cust_Code='" + cust_Code + @"'
	                        GROUP BY cust.Cust_Code";
            try
            {
                _dbConnection.ConnectDatabase();
                dataTable = _dbConnection.ExecuteQuery(queryString);
                if (dataTable.Rows.Count > 0)
                    result = Convert.ToDouble(dataTable.Rows[0]["Balance"].ToString());
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return result;
        }

        public double GetIPOCustomerBalance_ForEntry_UITransApply(string cust_Code)
        {
            DataTable dataTable;
            double result = 0.00;
            dataTable = null;
            string queryString = "";
            queryString = @"SELECT
	                        (	Select c.Cust_Name
		                        From SBP_Cust_Personal_Info as c
		                        Where c.Cust_Code= cust.Cust_Code
	                        )AS Cust_Name
	                        ,
                            ISNULL(SUM(ipoBal.Deposit)-SUM(ipoBal.Withdraw),0) AS Balance
	                        FROM(
			                        SELECT [ID]
			                          ,[Cust_Code]
			                          ,[Money_TransactionType_ID]
			                          ,[Money_TransactionType_Name]
			                          ,(
					                        CASE 
						                        WHEN [Deposit_Withdraw]='Deposit' THEN [Amount]
						                        ELSE 0.00
					                        END
			                           ) Deposit
			                          ,(
					                        CASE 
						                        WHEN [Deposit_Withdraw]='Withdraw' THEN [Amount]
						                        ELSE 0.00
					                        END
			                           )AS Withdraw
			                          ,[Amount]
			                          ,[Voucher_No]
			                          ,[Trans_Reason]
			                          ,[Intended_IPOSession_ID]
			                          ,[Intended_IPOSession_Name]
			                          ,[Approval_Status]
			                          ,[Approval_Date]
			                          ,[Approval_By]
			                          ,[Entry_Date]
			                          ,[Entry_By]
			                          ,[Updated_Date]
			                          ,[Update_By]
		                          FROM [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction]
		                          WHERE [Approval_Status]=1 AND [Money_TransactionType_Name]<>'Cheque'
	                        ) AS ipoBal
	                        RIGHT OUTER JOIN
	                        SBP_Customers as cust
	                        ON
	                        ipoBal.Cust_Code=cust.Cust_Code
	                        WHERE cust.Cust_Code='" + cust_Code + @"'
	                        GROUP BY cust.Cust_Code";
            try
            {
                //_dbConnection.ConnectDatabase();
                dataTable = _dbConnection.ExecuteQuery(queryString);
                if (dataTable.Rows.Count > 0)
                    result = Convert.ToDouble(dataTable.Rows[0]["Balance"].ToString());
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
               // _dbConnection.CloseDatabase();
            }
            return result;
        }

        public double GetIPOCustomerBalance(string cust_Code)
        {
            DataTable dataTable;
            double result = 0.00;
            dataTable = null;
            string queryString = "";
            queryString = @"SELECT
	                        (	Select c.Cust_Name
		                        From SBP_Cust_Personal_Info as c
		                        Where c.Cust_Code= cust.Cust_Code
	                        )AS Cust_Name
	                        ,
                            ISNULL(SUM(ipoBal.Deposit)-SUM(ipoBal.Withdraw),0) AS Balance
	                        FROM(
			                        SELECT [ID]
			                          ,[Cust_Code]
			                          ,[Money_TransactionType_ID]
			                          ,[Money_TransactionType_Name]
			                          ,(
					                        CASE 
						                        WHEN [Deposit_Withdraw]='Deposit' THEN [Amount]
						                        ELSE 0.00
					                        END
			                           ) Deposit
			                          ,(
					                        CASE 
						                        WHEN [Deposit_Withdraw]='Withdraw' THEN [Amount]
						                        ELSE 0.00
					                        END
			                           )AS Withdraw
			                          ,[Amount]
			                          ,[Voucher_No]
			                          ,[Trans_Reason]
			                          ,[Intended_IPOSession_ID]
			                          ,[Intended_IPOSession_Name]
			                          ,[Approval_Status]
			                          ,[Approval_Date]
			                          ,[Approval_By]
			                          ,[Entry_Date]
			                          ,[Entry_By]
			                          ,[Updated_Date]
			                          ,[Update_By]
		                          FROM [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction]
		                          WHERE [Approval_Status]=1 --AND [Money_TransactionType_Name]<>'Cheque'
	                        ) AS ipoBal
	                        RIGHT OUTER JOIN
	                        SBP_Customers as cust
	                        ON
	                        ipoBal.Cust_Code=cust.Cust_Code
	                        WHERE cust.Cust_Code='" + cust_Code + @"'
	                        GROUP BY cust.Cust_Code";
            try
            {
                _dbConnection.ConnectDatabase();
                dataTable = _dbConnection.ExecuteQuery(queryString);
                if (dataTable.Rows.Count > 0)
                    result = Convert.ToDouble(dataTable.Rows[0]["Balance"].ToString());
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return result;
        }

        public double GetIPOCustomerBalance_UITransApply(string cust_Code)
        {
            DataTable dataTable;
            double result = 0.00;
            dataTable = null;
            string queryString = "";
            queryString = @"SELECT
	                        (	Select c.Cust_Name
		                        From SBP_Cust_Personal_Info as c
		                        Where c.Cust_Code= cust.Cust_Code
	                        )AS Cust_Name
	                        ,
                            ISNULL(SUM(ipoBal.Deposit)-SUM(ipoBal.Withdraw),0) AS Balance
	                        FROM(
			                        SELECT [ID]
			                          ,[Cust_Code]
			                          ,[Money_TransactionType_ID]
			                          ,[Money_TransactionType_Name]
			                          ,(
					                        CASE 
						                        WHEN [Deposit_Withdraw]='Deposit' THEN [Amount]
						                        ELSE 0.00
					                        END
			                           ) Deposit
			                          ,(
					                        CASE 
						                        WHEN [Deposit_Withdraw]='Withdraw' THEN [Amount]
						                        ELSE 0.00
					                        END
			                           )AS Withdraw
			                          ,[Amount]
			                          ,[Voucher_No]
			                          ,[Trans_Reason]
			                          ,[Intended_IPOSession_ID]
			                          ,[Intended_IPOSession_Name]
			                          ,[Approval_Status]
			                          ,[Approval_Date]
			                          ,[Approval_By]
			                          ,[Entry_Date]
			                          ,[Entry_By]
			                          ,[Updated_Date]
			                          ,[Update_By]
		                          FROM [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction]
		                          WHERE [Approval_Status]=1 --AND [Money_TransactionType_Name]<>'Cheque'
	                        ) AS ipoBal
	                        RIGHT OUTER JOIN
	                        SBP_Customers as cust
	                        ON
	                        ipoBal.Cust_Code=cust.Cust_Code
	                        WHERE cust.Cust_Code='" + cust_Code + @"'
	                        GROUP BY cust.Cust_Code";
            try
            {
                //_dbConnection.ConnectDatabase();
                dataTable = _dbConnection.ExecuteQuery(queryString);
                if (dataTable.Rows.Count > 0)
                    result = Convert.ToDouble(dataTable.Rows[0]["Balance"].ToString());
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                //_dbConnection.CloseDatabase();
            }
            return result;
        }

        #endregion

        public DataTable GetSingleTransfer_MoneyTransaction_Pending_List()
        {
            DataTable dataTable;
            dataTable = null;
            string queryString = "";
            queryString = @" 
                            --DROP TABLE #GroupByVoucher_IPOAcc
                            --DROP TABLE #GroupByVoucher_PaymentPost

                            SELECT v.Cust_Code,v.[Voucher_No]
                            INTO #GroupByVoucher_IPOAcc
                            FROM [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction] As v
                            WHERE [Approval_Status]=0 AND [Money_TransactionType_Name]='" + Indication_IPOPaymentTransaction.TRTA + @"'  
                            AND [Deposit_Withdraw]='" + Indication_PaymentMode.Deposit + @"'  
                            AND v.ID NOT IN( Select c.Money_Trans_Ref_ID From SBP_IPO_Application_BasicInfo as c )
                            GROUP BY Cust_Code,[Voucher_No]
                            HAVING COUNT(*)=1

                            SELECT v.Cust_Code,v.[Vouchar_SN]
                            INTO #GroupByVoucher_PaymentPost
                            FROM [SBP_Database].[dbo].[SBP_Payment_Posting_Request] As v
                            WHERE [Approval_Status]=0 AND [Payment_Media]='" + Indication_PaymentTransaction.TRIPO + @"'
                            AND [Deposit_Withdraw]='" + Indication_PaymentMode.Withdraw + @"'  
                            GROUP BY Cust_Code,[Vouchar_SN]
                            HAVING COUNT(*)=1

                            SELECT T.* 
                            FROM(

	                                SELECT 
		                                  [ID]
		                                  ,[Cust_Code] AS [Customer]
		                                  ,[Received_Date] AS [Received Date]
		                                  ,[Money_TransactionType_ID] 
		                                  ,[Money_TransactionType_Name] AS [Payment Method]
		                                  ,[Deposit_Withdraw] AS [Deposit/Withdraw]
		                                  ,[Amount] AS [Amount]
		                                  ,[Voucher_No] AS [Voucher No]
		                                  ,[Trans_Reason] AS [Reason]
		                                  ,[Intended_IPOSession_ID] 
		                                  ,[Intended_IPOSession_Name]
		                                  ,ISNULL((
			                                           Select c.Company_Name
                                                      From SBP_IPO_Company_Info as c
                                                      Where c.ID=(
	                                                      Select IPO_Company_ID 
	                                                      From SBP_IPO_Session as s
	                                                      Where s.ID=prTrans.[Intended_IPOSession_ID]
                                                      )
		                                  ),'') AS [Company Name]
		                                  ,ISNULL((
				                                Select t.Premium 
				                                From SBP_IPO_Session as t
				                                Where t.ID=prTrans.[Intended_IPOSession_ID]
		                                  ),0) AS [IPO Premium]
                                          ,ISNULL((
			                                Select t.TotalAmount 
			                                From SBP_IPO_Session as t
			                                Where t.ID=prTrans.[Intended_IPOSession_ID]
		                                  ),0) AS [IPO Amount]  
		                                  ,0
                                          --ISNULL((
				                          --      Select t.Amount
				                          --     From SBP_Payment_OCC_Purpose as t
				                          --      Where t.OCC_Purpose='IPO App Charge'
		                                  --),0) 
                                          AS [IPO Charge]
                                          ,'IPOACC' AS [AccountName]  
                            		     
	                                FROM [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction] AS prTrans
	                                WHERE [Approval_Status]=0 AND [Money_TransactionType_Name]='TRTA' AND
	                                EXISTS  (
						                                Select * From #GroupByVoucher_IPOAcc as c 
                                                        WHERE c.Cust_Code=prTrans.Cust_Code AND c.Voucher_No=prTrans.Voucher_No
	                                )
                                    AND
                                    EXISTS  (
						                                Select * From #GroupByVoucher_PaymentPost as c
                                                        WHERE c.Cust_Code=prTrans.Cust_Code AND c.Vouchar_SN=prTrans.Voucher_No
	                                )
                                    AND Entry_Branch_ID=" + GlobalVariableBO._branchId + @"
                                    AND [Deposit_Withdraw]='" + Indication_PaymentMode.Deposit + @"'

	                                UNION ALL
	                                SELECT 
                                           [Payment_ID] AS [ID]
		                                  ,[Cust_Code] AS [Customer]
		                                  ,[Received_Date] AS [Received Date]
		                                  ,0 AS [Money_TransactionType_ID]
		                                  ,[Payment_Media] AS [Payment Method]
		                                  ,[Deposit_Withdraw] AS [Deposit/Withdraw]
		                                  ,[Amount] AS [Amount]
		                                  ,[Vouchar_SN] AS [Voucher No]
		                                  ,[Trans_Reason] AS [Reason]
		                                  ,0 AS [Intended_IPOSession_ID]
		                                  ,'' AS [Intended_IPOSession_Name]
		                                  ,'' AS [Company Name]
                                          ,0 AS [IPO Amount]
		                                  ,0 AS [IPO Premium]
		                                  ,0 AS [IPO Charge]
                                          ,'TRADEACC' AS [AccountName]    		
	                                FROM [SBP_Database].[dbo].[SBP_Payment_Posting_Request] as pps
	                                WHERE [Payment_Media]='TRIPO' 
                                    AND EXISTS  (
						                                Select * From #GroupByVoucher_IPOAcc as c 
                                                        WHERE c.Cust_Code=pps.Cust_Code AND c.[Voucher_No]=pps.Vouchar_SN
	                                )
                                    AND
                                    EXISTS  (
						                                Select * From #GroupByVoucher_PaymentPost as c
                                                        WHERE c.Cust_Code=pps.Cust_Code AND c.Vouchar_SN=pps.Vouchar_SN
	                                )
                                    AND Entry_Branch_ID=" + GlobalVariableBO._branchId + @"
                                    AND [Deposit_Withdraw]='" + Indication_PaymentMode.Withdraw + @"' 
                            ) AS T
                            ORDER BY T.[Voucher No]
                            ";
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

        public DataTable GetSingleTransfer_ApplyTogether_MoneyTransaction_Pending_List()
        {
            DataTable dataTable;
            dataTable = null;
            string queryString = "";
//            queryString = @"  
//                                /*                             
//                                DROP TABLE #GroupByVoucher_IPOAcc
//                                DROP TABLE #GroupByVoucher_PaymentPost
//                                */
//
//                                SELECT v.Cust_Code,v.[Voucher_No],v.ID,trn.Payment_ID,trn.Entry_Branch_ID
//                                INTO #GroupByVoucher_IPOAcc
//                                FROM [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction] As v
//                                Join [SBP_Payment_Posting_Request] As trn
//                                On Convert(varchar(100),trn.Payment_ID)=REPLACE (v.Trans_Reason,SUBSTRING(v.Trans_Reason,1,CHARINDEX('_',v.Trans_Reason)),'')
//                                JOIN [SBP_Database].dbo.SBP_IPO_Application_BasicInfo as app                            
//                                ON app.Money_Trans_Ref_ID=v.ID
//                                WHERE v.[Approval_Status]=0 AND v.[Money_TransactionType_Name]='" + Indication_IPOPaymentTransaction.TRTA + @"'  
//                                AND trn.Entry_Branch_ID=" +GlobalVariableBO._branchId+ @"
//                                AND v.[Deposit_Withdraw]='" + Indication_PaymentMode.Deposit + @"' AND v.Cust_Code=trn.Cust_Code
//                                AND (
//		                                Select COUNT(*) 
//		                                FROM [SBP_IPO_Customer_Broker_MoneyTransaction] as c 
//		                                WHERE REPLACE (c.Trans_Reason,SUBSTRING(c.Trans_Reason,1,CHARINDEX('_',c.Trans_Reason)),'')=Convert(varchar(100),trn.Payment_ID)
//                                )=1
//                                GROUP BY v.Cust_Code,v.[Voucher_No],trn.Payment_ID,v.ID,trn.Entry_Branch_ID
//                                HAVING COUNT(*)=1
//                                --select * from #GroupByVoucher_IPOAcc									 
//                                		 
//                                SELECT v.Cust_Code,v.[Vouchar_SN],trn.ID,v.Payment_ID
//                                INTO #GroupByVoucher_PaymentPost
//                                FROM [SBP_Database].[dbo].[SBP_Payment_Posting_Request] As v
//                                Join SBP_IPO_Customer_Broker_MoneyTransaction As trn
//                                On Convert(varchar(100),v.Payment_ID)=REPLACE (trn.Trans_Reason,SUBSTRING(trn.Trans_Reason,1,CHARINDEX('_',trn.Trans_Reason)),'')
//                                --JOIN [SBP_Database].dbo.SBP_IPO_Application_BasicInfo as app
//                                --ON app.Money_Trans_Ref_ID=trn.ID
//                                WHERE trn.Approval_Status=0 AND v.[Payment_Media]='" + Indication_PaymentTransaction.TRIPO + @"'--'TRIPO' 
//                                AND v.Approval_Status=0 AND trn.Entry_Branch_ID=" +GlobalVariableBO._branchId+ @"
//                                AND v.[Deposit_Withdraw]='Withdraw' AND v.Cust_Code=trn.Cust_Code
//                                AND (
//		                                Select COUNT(*) 
//		                                FROM [SBP_IPO_Customer_Broker_MoneyTransaction] as c
//		                                WHERE REPLACE (c.Trans_Reason,SUBSTRING(c.Trans_Reason,1,CHARINDEX('_',c.Trans_Reason)),'')=Convert(varchar(100),v.Payment_ID)
//                                )=1 
//                                GROUP BY v.Cust_Code,trn.[Voucher_No],v.Vouchar_SN,v.Payment_ID,trn.ID
//                                HAVING COUNT(*)=1
//                                --select * from #GroupByVoucher_PaymentPost
//
//                                SELECT T.* 
//                                FROM(
//
//                                        SELECT 
//                                              prTrans.Remarks As Remarks
//				                              ,Bas.ID AS [Application Id]
//                                              ,prtrans.[ID] As ID
//                                              ,prtrans.[Cust_Code] AS [Customer]
//                                              ,[Received_Date] AS [Received Date]
//                                              ,[Money_TransactionType_ID] 
//                                              ,[Money_TransactionType_Name] AS [Payment Method]
//                                              ,[Deposit_Withdraw] AS [Deposit/Withdraw]
//                                              ,Cast( prtrans.[Amount] AS Money) As [Amount]
//                                              ,[Voucher_No] AS [Voucher No]
//                                              ,[Trans_Reason] AS [Reason]
//                                              ,[Intended_IPOSession_ID] 
//                                              ,[Intended_IPOSession_Name]
//                                              ,ISNULL((
//                                                           Select c.Company_Name
//                                                          From SBP_IPO_Company_Info as c
//                                                          Where c.ID=(
//                                                              Select IPO_Company_ID 
//                                                              From SBP_IPO_Session as s
//                                                              Where s.ID=prTrans.[Intended_IPOSession_ID]
//                                                          )
//                                              ),'') AS [Company Name]
//                                              ,ISNULL((
//                                                    Select t.Premium 
//                                                    From SBP_IPO_Session as t
//                                                    Where t.ID=prTrans.[Intended_IPOSession_ID]
//                                              ),0) AS [IPO Premium]
//                                              ,ISNULL((
//                                                Select t.TotalAmount 
//                                                From SBP_IPO_Session as t
//                                                Where t.ID=prTrans.[Intended_IPOSession_ID]
//                                              ),0) AS [IPO Amount]  
//                                              ,0
//                                              --ISNULL((
//                                              --      Select t.Amount
//                                              --     From SBP_Payment_OCC_Purpose as t
//                                              --      Where t.OCC_Purpose='IPO App Charge'
//                                              --),0) 
//                                              AS [IPO Charge]
//                                              ,'IPOACC' AS [AccountName]                                  		     
//                                        FROM [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction] AS prTrans
//                                        Inner Join SBP_IPO_Application_BasicInfo As Bas
//                                        On Bas.Money_Trans_Ref_ID=prTrans.ID
//                                        WHERE [Approval_Status]=0 AND [Money_TransactionType_Name]='" + Indication_IPOPaymentTransaction.TRTA + @"' AND
//                                        EXISTS  (
//                                                            Select * From #GroupByVoucher_IPOAcc as c 
//                                                            WHERE c.Cust_Code=prTrans.Cust_Code AND c.Voucher_No=prTrans.Voucher_No
//                                        )
//                                        AND
//                                        EXISTS  (
//                                                            Select * From #GroupByVoucher_PaymentPost as c
//                                                            WHERE c.Cust_Code=prTrans.Cust_Code AND c.Vouchar_SN=prTrans.Voucher_No
//                                        )
//                                        AND prTrans.Entry_Branch_ID=" +GlobalVariableBO._branchId+@"
//                                        AND [Deposit_Withdraw]='" + Indication_PaymentMode.Deposit + @"'
//
//                                        UNION ALL
//                                        
//                                        SELECT 
//                                        trn.Remarks As Remarks
//                                        ,app.[ID] AS [Application Id]
//                                        ,app.ID As [ID]
//                                          ,app.[Cust_Code] AS [Customer]
//                                          ,app.Application_Date AS [Received Date]
//                                          ,0 AS [Money_TransactionType_ID]
//                                          ,'' AS [Payment Method]
//                                          ,'' AS [Deposit/Withdraw]
//                                          ,app.[TotalAmount] AS [Amount]
//                                          ,trn.Voucher_No AS [Voucher No]
//                                          ,'' AS [Reason]
//                                          ,IPOSession_ID AS [Intended_IPOSession_ID]
//                                          ,IPOSession_Name AS [Intended_IPOSession_Name]
//                                          ,Applied_Company AS [Company Name]
//                                        ,app.[TotalAmount] AS [IPO Amount]
//                                          ,Premium AS [IPO Premium]
//                                          ,0 AS [IPO Charge]
//                                        ,'APPLICATION' AS [AccountName]
//                                        --, [Serial_No], '', '', '', [No_Of_Share], [Lot_No], [Amount], [Total_Share_Value], '','' 
//                                        --, [Fine_Amount],'', [BO_ID], [Money_Trans_Ref_ID], [Application_Date], [Application_Satus], [AppStatus_UpdatedBy], [AppStatus_UpdatedDate], [AppStatus_RejectedReason], [Entry_Date], [Entry_By], [Updated_Date], [Update_By] 
//                                        From dbo.SBP_IPO_Application_BasicInfo as app
//                                        Inner join SBP_IPO_Customer_Broker_MoneyTransaction as trn
//			                            on trn.ID=app.Money_Trans_Ref_ID
//                                        Where
//                                        app.Entry_Branch_ID=" + GlobalVariableBO._branchId+ @" AND
//                                        Money_Trans_Ref_ID IN (
//                                                Select b.ID 
//                                                From #GroupByVoucher_IPOAcc as b 
//                                        )
//                                        Union All
//                                        SELECT
//                                        tr.Remarks As Remarks
//                                        ,basicInfo.ID as [Application Id]
//                                        ,pr.Payment_ID as [ID] 
//                                        ,pr.Cust_Code As [Customer]
//                                        ,pr.Received_Date as [Received Date]
//                                        ,0 As [Money_TransactionType_ID]
//                                        ,pr.Payment_Media as [Payment Method]
//                                        ,pr.Deposit_Withdraw As [Deposit/Withdraw]
//                                        ,pr.Amount as [Amount]
//                                        ,pr.Vouchar_SN as [Voucher No]
//                                        ,pr.Trans_Reason as [Reason]
//                                        ,'' As [Intended_IPOSession_ID]
//                                        ,'' As [Intended_IPOSession_Name]
//                                        ,'' As [Company Name]
//                                        ,pr.Amount as [IPO Amount]
//                                        ,'' as [IPO Premium]
//                                        ,0 as [IPO Charge]
//                                        ,'TRADEACC' As [AccountName]
//                                        From SBP_Payment_Posting_Request as pr
//                                        Inner join SBP_IPO_Customer_Broker_MoneyTransaction as tr
//                                        On Convert(varchar(100),pr.Payment_ID)=REPLACE (tr.Trans_Reason,SUBSTRING(tr.Trans_Reason,1,CHARINDEX('_',tr.Trans_Reason)),'')
//                                        Inner Join SBP_IPO_Application_BasicInfo as basicInfo
//                                        On basicInfo.Money_Trans_Ref_ID=tr.ID
//                                        Where Payment_ID IN (select P.Payment_ID from #GroupByVoucher_PaymentPost as P)
//                                        and tr.Entry_Branch_ID=" + GlobalVariableBO._branchId+ @"
//
//                                ) AS T
//                                ORDER BY T.[Customer], T.[Voucher No] desc
//
//                            ";

            string queryString_Proc = @"SBP_IPOSingleTransferDepositApplyTogether_Approval";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@BranchID", SqlDbType.Int, GlobalVariableBO._branchId);
                //dataTable = _dbConnection.ExecuteQuery(queryString);
                dataTable = _dbConnection.ExecuteProQuery(queryString_Proc);

            }
            catch (Exception ex )
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dataTable;
        }

        public DataTable GetTRPRIPOTransferBack_MoneyTransaction_Pending_List()
        {
            DataTable dataTable = new DataTable();
            string QueryString = "";
            QueryString = @"SBP_IPO_Refund_ParentChild";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                dataTable = _dbConnection.ExecuteProQuery(QueryString);
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

        public DataTable GetSingleTransferBack_MoneyTransaction_Pending_List()
        {
            DataTable dataTable;
            dataTable = null;
            string queryString = "";
            queryString = @" 
                            --DROP TABLE #GroupByVoucher_IPOAcc
                            --DROP TABLE #GroupByVoucher_PaymentPost

                            SELECT v.[Voucher_No]
                            INTO #GroupByVoucher_IPOAcc
                            FROM [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction] As v
                            WHERE [Approval_Status]=0 AND [Money_TransactionType_Name]='TRTA'  
                            AND [Deposit_Withdraw]='" + Indication_PaymentMode.Withdraw + @"'  
                            AND
                            v.Trans_Reason LIKE '%TRTA%'
                            GROUP BY [Voucher_No]
                            HAVING COUNT(*)=1

                            SELECT v.[Vouchar_SN]
                            INTO #GroupByVoucher_PaymentPost
                            FROM [SBP_Database].[dbo].[SBP_Payment_Posting_Request] As v
                            WHERE [Approval_Status]=0 AND [Payment_Media]='TRIPO'
                            AND [Deposit_Withdraw]='" + Indication_PaymentMode.Deposit + @"'
                            AND
                            v.Trans_Reason LIKE '%TRTA%'  
                            GROUP BY [Vouchar_SN]
                            HAVING COUNT(*)=1

                            SELECT T.* 
                            FROM(

	                                SELECT 
		                                  [ID]
		                                  ,[Cust_Code] AS [Customer]
		                                  ,[Received_Date] AS [Received Date]
		                                  ,[Money_TransactionType_ID] 
		                                  ,[Money_TransactionType_Name] AS [Payment Method]
		                                  ,[Deposit_Withdraw] AS [Deposit/Withdraw]
		                                  ,[Amount] AS [Amount]
		                                  ,[Voucher_No] AS [Voucher No]
		                                  ,[Trans_Reason] AS [Reason]
		                                  ,[Intended_IPOSession_ID] 
		                                  ,[Intended_IPOSession_Name]
		                                  ,ISNULL((
			                                           Select c.Company_Name
                                                      From SBP_IPO_Company_Info as c
                                                      Where c.ID=(
	                                                      Select IPO_Company_ID 
	                                                      From SBP_IPO_Session as s
	                                                      Where s.ID=prTrans.[Intended_IPOSession_ID]
                                                      )
		                                  ),'') AS [Company Name]
                                          ,ISNULL((
			                                Select t.TotalAmount 
			                                From SBP_IPO_Session as t
			                                Where t.ID=prTrans.[Intended_IPOSession_ID]
		                                  ),0) AS [IPO Amount]
		                                  ,ISNULL((
				                                Select t.Premium 
				                                From SBP_IPO_Session as t
				                                Where t.ID=prTrans.[Intended_IPOSession_ID]
		                                  ),0) AS [IPO Premium]
		                                  ,0
                                          --ISNULL((
				                          --      Select t.Amount
				                          --      From SBP_Payment_OCC_Purpose as t
				                          --      Where t.OCC_Purpose='IPO App Charge'
		                                  --),0) 
                                          AS [IPO Charge]
                                          ,'IPOACC' AS [AccountName]  
                            		     
	                                FROM [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction] AS prTrans
	                                WHERE [Approval_Status]=0 AND [Money_TransactionType_Name]='TRTA' AND
	                                [Voucher_No] IN  (
						                                Select c.[Voucher_No] From #GroupByVoucher_IPOAcc as c
	                                )
	                                AND
	                                [Voucher_No] IN (
						                                Select c.[Vouchar_SN] From #GroupByVoucher_PaymentPost as c
	                                )
                                    AND [Deposit_Withdraw]='" + Indication_PaymentMode.Withdraw + @"' 
	                                UNION ALL
	                                SELECT [Payment_ID] AS [ID]
		                                  ,[Cust_Code] AS [Customer]
		                                  ,[Received_Date] AS [Received Date]
		                                  ,0 AS [Money_TransactionType_ID]
		                                  ,[Payment_Media] AS [Payment Method]
		                                  ,[Deposit_Withdraw] AS [Deposit/Withdraw]
		                                  ,[Amount] AS [Amount]
		                                  ,[Vouchar_SN] AS [Voucher No]
		                                  ,[Trans_Reason] AS [Reason]
		                                  ,0 AS [Intended_IPOSession_ID]
		                                  ,'' AS [Intended_IPOSession_Name]
		                                  ,'' AS [Company Name]
                                          ,0 AS [IPO Amount]
		                                  ,0 AS [IPO Premium]
		                                  ,0 AS [IPO Charge]
                                          ,'TRADEACC' AS [AccountName]    		
	                                FROM [SBP_Database].[dbo].[SBP_Payment_Posting_Request]
	                                WHERE [Payment_Media]='TRIPO' AND [Vouchar_SN] IN (
						                                Select c.[Vouchar_SN] From #GroupByVoucher_PaymentPost as c
	                                ) 
	                                AND [Vouchar_SN] IN (
						                                Select c.[Voucher_No] From #GroupByVoucher_IPOAcc as c
	                                )
                                    AND Entry_Branch_ID=" + GlobalVariableBO._branchId + @"
                                    AND [Deposit_Withdraw]='" + Indication_PaymentMode.Deposit + @"' 
                            ) AS T
                            ORDER BY T.[Voucher No]
                            ";
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

        public DataTable GetMultiTransfer_MoneyTransaction_Pending_List()
        {
            DataTable dataTable;
            dataTable = null;
            string queryString = "";
            queryString = @"
                            --DROP TABLE #GroupByVoucher_IPOAcc
                            --DROP TABLE #GroupByVoucher_PaymentPost

                            SELECT v.Cust_Code,v.[Voucher_No]
                            INTO #GroupByVoucher_IPOAcc
                            FROM [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction] As v
                            WHERE [Approval_Status]=0 AND [Money_TransactionType_Name]='" + Indication_IPOPaymentTransaction.TRTA + @"'  
                            AND [Deposit_Withdraw]='" + Indication_PaymentMode.Deposit + @"'
                            AND v.ID NOT IN (Select c.Money_Trans_Ref_ID From SBP_IPO_Application_BasicInfo as c)  
                            GROUP BY Cust_Code,[Voucher_No]
                            HAVING COUNT(*)>=1

                            SELECT v.Cust_Code,v.[Vouchar_SN]
                            INTO #GroupByVoucher_PaymentPost
                            FROM [SBP_Database].[dbo].[SBP_Payment_Posting_Request] As v
                            WHERE [Approval_Status]=0 AND [Payment_Media]='" + Indication_PaymentTransaction.TRIPO + @"'
                            AND [Deposit_Withdraw]='" + Indication_PaymentMode.Withdraw + @"'   
                            GROUP BY Cust_Code,[Vouchar_SN]
                            HAVING COUNT(*)=1

                            SELECT T.* 
                            FROM(

                                    SELECT 
                                              [ID]
                                              ,[Cust_Code] AS [Customer]
                                              ,[Received_Date] AS [Received Date]
                                              ,[Money_TransactionType_ID] 
                                              ,[Money_TransactionType_Name] AS [Payment Method]
                                              ,[Deposit_Withdraw] AS [Deposit/Withdraw]
                                              ,[Amount] AS [Amount]
                                              ,[Voucher_No] AS [Voucher No]
                                              ,[Trans_Reason] AS [Reason]
                                              ,[Intended_IPOSession_ID] 
                                              ,[Intended_IPOSession_Name]
                                              ,ISNULL((
                                                               Select c.Company_Name
                                                  From SBP_IPO_Company_Info as c
                                                  Where c.ID=(
                                                          Select IPO_Company_ID 
                                                          From SBP_IPO_Session as s
                                                          Where s.ID=prTrans.[Intended_IPOSession_ID]
                                                  )
                                              ),'') AS [Company Name]
                                    
                                              ,ISNULL((
                                                            Select t.Premium 
                                                            From SBP_IPO_Session as t
                                                            Where t.ID=prTrans.[Intended_IPOSession_ID]
                                              ),0) AS [IPO Premium]
                                      ,ISNULL((
                                                    Select t.TotalAmount 
                                                    From SBP_IPO_Session as t
                                                    Where t.ID=prTrans.[Intended_IPOSession_ID]
                                              ),0) AS [IPO Amount]  
                                              ,0
                                      --ISNULL((
                                                      --      Select t.Amount
                                                      --      From SBP_Payment_OCC_Purpose as t
                                                      --      Where t.OCC_Purpose='IPO App Charge'
                                              --),0) 
                                      AS [IPO Charge]
                                            ,Replace(SUBSTRING(prTrans.Trans_Reason,CHARINDEX('_',prTrans.Trans_Reason),LEN(prTrans.Trans_Reason)),'_','') As SelectionId
	                                      ,'IPOACC' AS [AccountName]  
                                    FROM [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction] AS prTrans
                                    WHERE [Approval_Status]=0 AND [Money_TransactionType_Name]='" + Indication_IPOPaymentTransaction.TRTA+@"' 
                                    AND EXISTS  (
	                                                                Select * From #GroupByVoucher_IPOAcc as c
                                                    Where c.Cust_Code=prTrans.Cust_Code AND c.Voucher_No=prTrans.Voucher_No
                                    )
                                    AND
                                    EXISTS (
	                                                                Select * From #GroupByVoucher_PaymentPost as c
                                                    Where c.[Vouchar_SN]=prTrans.Voucher_No
                                    )
                                AND NOT EXISTS(
                                                     Select * From #GroupByVoucher_PaymentPost as c
                                                    Where c.[Cust_Code]=prTrans.Cust_Code  AND c.Vouchar_SN=prTrans.Voucher_No            
                                )
                                AND Entry_Branch_ID="+GlobalVariableBO._branchId+@"
                                AND [Deposit_Withdraw]='"+Indication_PaymentMode.Deposit+ @"'    
                                    
                                UNION ALL
                                    
                                SELECT [Payment_ID] AS [ID]
                                              ,[Cust_Code] AS [Customer]
                                              ,[Received_Date] AS [Received Date]
                                              ,0 AS [Money_TransactionType_ID]
                                              ,[Payment_Media] AS [Payment Method]
                                              ,[Deposit_Withdraw] AS [Deposit/Withdraw]
                                              ,[Amount] AS [Amount]
                                              ,[Vouchar_SN] AS [Voucher No]
                                              ,[Trans_Reason] AS [Reason]
                                              ,0 AS [Intended_IPOSession_ID]
                                              ,'' AS [Intended_IPOSession_Name]
                                              ,'' AS [Company Name]
                                      ,0 AS [IPO Amount]
                                              ,0 AS [IPO Premium]
                                              ,0 AS [IPO Charge]
                                        ,Payment_ID As SelectionId
                                      ,'TRADEACC' AS [AccountName]    				
                                    FROM [SBP_Database].[dbo].[SBP_Payment_Posting_Request] as pps
                                    WHERE [Payment_Media]='" + Indication_PaymentTransaction.TRIPO+@"'  
                                AND EXISTS  (
	                                                                Select * From #GroupByVoucher_PaymentPost as c
                                                    Where c.Cust_Code=pps.Cust_Code AND c.Vouchar_SN=pps.Vouchar_SN
                                    )
                                    AND
                                    EXISTS (
	                                                                Select * From #GroupByVoucher_IPOAcc as c
                                                    Where c.[Voucher_No]=pps.Vouchar_SN
                                    )
                                AND NOT EXISTS(
                                                     Select * From #GroupByVoucher_IPOAcc as c
                                                    Where c.[Cust_Code]=pps.Cust_Code AND c.Voucher_No=pps.Vouchar_SN              
                                )
                                AND Entry_Branch_ID="+GlobalVariableBO._branchId+@"
                                AND [Deposit_Withdraw]='"+Indication_PaymentMode.Withdraw+@"' 
                            ) AS T
                            ORDER BY T.[Voucher No]
                            ";
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

//        public DataTable GetMultiTransfer_ApplyTogether_MoneyTransaction_Pending_List()
//        {
//            DataTable dataTable;
//            dataTable = null;
//            string queryString = "";
//            queryString = @"
//                            /*
//                                DROP TABLE #GroupByVoucher_IPOAcc
//                                DROP TABLE #GroupByVoucher_PaymentPost
//                                */
//
//
//                                SELECT v.Cust_Code,v.[Voucher_No],v.ID,trn.Payment_ID,v.Entry_Branch_ID
//                                INTO #GroupByVoucher_IPOAcc
//                                FROM [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction] As v
//                                Join [SBP_Payment_Posting_Request] As trn
//                                On Convert(varchar(100),trn.Payment_ID)=REPLACE (v.Trans_Reason,SUBSTRING(v.Trans_Reason,1,CHARINDEX('_',v.Trans_Reason)),'')
//                                AND v.Approval_Status=0 AND v.[Money_TransactionType_Name]='" + Indication_IPOPaymentTransaction.TRTA + @"'
//                                JOIN [SBP_Database].dbo.SBP_IPO_Application_BasicInfo as app                            
//                                ON app.Money_Trans_Ref_ID=v.ID
//                                WHERE v.[Approval_Status]=0 AND v.[Money_TransactionType_Name]='" + Indication_IPOPaymentTransaction.TRTA + @"' 
//                                AND v.Entry_Branch_ID=" + GlobalVariableBO._branchId + @" 
//                                AND v.[Deposit_Withdraw]='" + Indication_PaymentMode.Deposit + @"'
//                                AND 
//									
//									(
//									(
//											Select COUNT(*) 
//											FROM [SBP_IPO_Customer_Broker_MoneyTransaction] as c 
//											WHERE 
//											REPLACE (c.Trans_Reason,SUBSTRING(c.Trans_Reason,1,CHARINDEX('_',c.Trans_Reason)),'')=Convert(varchar(100),trn.Payment_ID)		                                
//											AND c.Cust_Code<>trn.Cust_Code
//									)=1
//									OR
//									(
//											Select COUNT(*) 
//											FROM [SBP_IPO_Customer_Broker_MoneyTransaction] as c 
//											WHERE 
//											REPLACE (c.Trans_Reason,SUBSTRING(c.Trans_Reason,1,CHARINDEX('_',c.Trans_Reason)),'')=Convert(varchar(100),trn.Payment_ID)		                                
//									)>1                                
//                                )                               
//                                
//                                GROUP BY v.Cust_Code,v.[Voucher_No],trn.Payment_ID,v.ID,v.Entry_Branch_ID
//
//                                --Select * from #GroupByVoucher_IPOAcc
//
//                                SELECT v.Cust_Code,v.[Vouchar_SN],v.Payment_ID,trn.Entry_Branch_ID
//                                INTO #GroupByVoucher_PaymentPost
//                                FROM 
//                                [SBP_Database].[dbo].[SBP_Payment_Posting_Request] As v
//                                Join SBP_IPO_Customer_Broker_MoneyTransaction As trn
//                                On Convert(varchar(100),v.Payment_ID)=REPLACE (trn.Trans_Reason,SUBSTRING(trn.Trans_Reason,1,CHARINDEX('_',trn.Trans_Reason)),'')
//                                AND trn.Approval_Status=0 AND trn.[Money_TransactionType_Name]='" + Indication_IPOPaymentTransaction.TRTA + @"'
//                                JOIN [SBP_Database].dbo.SBP_IPO_Application_BasicInfo as app
//                                ON app.Money_Trans_Ref_ID=trn.ID
//                                WHERE v.Approval_Status=0 AND v.[Payment_Media]='" + Indication_PaymentTransaction.TRIPO + @"'
//                                AND trn.Entry_Branch_ID=" + GlobalVariableBO._branchId + @"
//                                AND v.[Deposit_Withdraw]='" + Indication_PaymentMode.Withdraw + @"' 
//                                AND 
//									
//                                (
//									(
//											Select COUNT(*) 
//											FROM [SBP_IPO_Customer_Broker_MoneyTransaction] as c 
//											WHERE 
//											REPLACE (c.Trans_Reason,SUBSTRING(c.Trans_Reason,1,CHARINDEX('_',c.Trans_Reason)),'')=Convert(varchar(100),v.Payment_ID)		                                
//											AND c.Cust_Code<>v.Cust_Code
//									)=1
//									OR
//									(
//											Select COUNT(*) 
//											FROM [SBP_IPO_Customer_Broker_MoneyTransaction] as c 
//											WHERE 
//											REPLACE (c.Trans_Reason,SUBSTRING(c.Trans_Reason,1,CHARINDEX('_',c.Trans_Reason)),'')=Convert(varchar(100),v.Payment_ID)		                                
//									)>1                                
//                                )
//                                GROUP BY v.Cust_Code,v.Vouchar_SN,v.Payment_ID,trn.Entry_Branch_ID
//                                --select * from #GroupByVoucher_PaymentPost
//                                SELECT T.* 
//                                FROM(
//
//                                        SELECT 
//			                                   pr.Payment_ID AS [PaymentPosting_ID]
//                                              ,prtrans.[ID] As ID
//                                              ,prtrans.[Cust_Code] AS [Customer]
//                                              ,prTrans.[Received_Date] AS [Received Date]
//                                              ,[Money_TransactionType_ID] 
//                                              ,[Money_TransactionType_Name] AS [Payment Method]
//                                              ,prTrans.[Deposit_Withdraw] AS [Deposit/Withdraw]
//                                              ,Cast( prtrans.[Amount] AS Money) As [Amount]
//                                              ,[Voucher_No] AS [Voucher No]
//                                              ,prTrans.Voucher_No as [Voucher_No_Selection]
//                                              ,prTrans.[Trans_Reason] AS [Reason]
//                                              ,[Intended_IPOSession_ID] 
//                                              ,[Intended_IPOSession_Name]
//                                              ,ISNULL((
//                                                           Select c.Company_Name
//                                                          From SBP_IPO_Company_Info as c
//                                                          Where c.ID=(
//                                                              Select IPO_Company_ID 
//                                                              From SBP_IPO_Session as s
//                                                              Where s.ID=prTrans.[Intended_IPOSession_ID]
//                                                          )
//                                              ),'') AS [Company Name]
//                                              ,ISNULL((
//                                                    Select t.Premium 
//                                                    From SBP_IPO_Session as t
//                                                    Where t.ID=prTrans.[Intended_IPOSession_ID]
//                                              ),0) AS [IPO Premium]
//                                              ,ISNULL((
//                                                Select t.TotalAmount 
//                                                From SBP_IPO_Session as t
//                                                Where t.ID=prTrans.[Intended_IPOSession_ID]
//                                              ),0) AS [IPO Amount]  
//                                              ,0
//                                              --ISNULL((
//                                              --      Select t.Amount
//                                              --     From SBP_Payment_OCC_Purpose as t
//                                              --      Where t.OCC_Purpose='IPO App Charge'
//                                              --),0) 
//                                              AS [IPO Charge]
//                                              ,app.ID As [SelectionID]
//                                              ,'IPOACC' AS [AccountName]  
//                                		     
//                                        FROM SBP_Payment_Posting_Request as pr
//                                        Inner join SBP_IPO_Customer_Broker_MoneyTransaction as prTrans
//                                        On Convert(varchar(100),pr.Payment_ID)=REPLACE (prTrans.Trans_Reason,SUBSTRING(prTrans.Trans_Reason,1,CHARINDEX('_',prTrans.Trans_Reason)),'')
//                                        Inner Join SBP_IPO_Application_BasicInfo as app
//                                        On app.Money_Trans_Ref_ID=prTrans.ID
//                                        WHERE prTrans.[Approval_Status]=0 AND prTrans.[Money_TransactionType_Name]='" + Indication_IPOPaymentTransaction.TRTA + @"' AND
//                                        prTrans.ID IN (
//                                                            Select c.ID From #GroupByVoucher_IPOAcc as c 
//                                                            
//                                        )
//                                    AND prTrans.Entry_Branch_ID=" + GlobalVariableBO._branchId + @"
//                                    AND prTrans.[Deposit_Withdraw]='" + Indication_PaymentMode.Deposit + @"'   
//                                        
//                                    UNION ALL
//                                        
//                                   SELECT 
//                                         pr.Payment_ID AS [PaymentPosting_ID]
//		                                 ,app.ID As [ID]
//                                          ,app.[Cust_Code] AS [Customer]
//                                          ,app.Application_Date AS [Received Date]
//                                          ,0 AS [Money_TransactionType_ID]
//                                          ,'' AS [Payment Method]
//                                          ,'' AS [Deposit/Withdraw]
//                                          ,app.[TotalAmount] AS [Amount]
//                                          ,'' AS [Voucher No]
//                                          ,tr.Voucher_No as [Voucher_No_Selection]
//                                          ,'' AS [Reason]
//                                          ,app.IPOSession_ID AS [Intended_IPOSession_ID]
//                                          ,app.IPOSession_Name AS [Intended_IPOSession_Name]
//                                          ,app.Applied_Company AS [Company Name]
//                                        ,app.[TotalAmount] AS [IPO Amount]
//                                          ,app.Premium AS [IPO Premium]
//                                          ,0 AS [IPO Charge]
//                                          ,app.ID As [SelectionID]
//                                        ,'APPLICATION' AS [AccountName]
//                                        --, [Serial_No], '', '', '', [No_Of_Share], [Lot_No], [Amount], [Total_Share_Value], '','' 
//                                        --, [Fine_Amount],'', [BO_ID], [Money_Trans_Ref_ID], [Application_Date], [Application_Satus], [AppStatus_UpdatedBy], [AppStatus_UpdatedDate], [AppStatus_RejectedReason], [Entry_Date], [Entry_By], [Updated_Date], [Update_By] 
//                                        From SBP_Payment_Posting_Request as pr
//                                        Inner join SBP_IPO_Customer_Broker_MoneyTransaction as tr
//                                        On Convert(varchar(100),pr.Payment_ID)=REPLACE (tr.Trans_Reason,SUBSTRING(tr.Trans_Reason,1,CHARINDEX('_',tr.Trans_Reason)),'')
//                                        Inner Join SBP_IPO_Application_BasicInfo as app
//                                        On app.Money_Trans_Ref_ID=tr.ID
//                                        Where 
//                                         tr.Entry_Branch_ID=" + GlobalVariableBO._branchId + @" AND
//                                        Money_Trans_Ref_ID IN (
//                                                Select b.ID 
//                                                From #GroupByVoucher_IPOAcc as b 
//                                        )
//                                    UNION All
//                                    
//                                    SELECT
//                                        pr.Payment_ID as [PaymentPosting_ID]
//                                        ,pr.Payment_ID as [ID] 
//                                        ,pr.Cust_Code As [Customer]
//                                        ,pr.Received_Date as [Received Date]
//                                        ,0 As [Money_TransactionType_ID]
//                                        ,pr.Payment_Media as [Payment Method]
//                                        ,pr.Deposit_Withdraw As [Deposit/Withdraw]
//                                        ,pr.Amount as [Amount]
//                                        ,pr.Vouchar_SN as [Voucher No]
//                                        ,pr.Vouchar_SN as [Voucher_No_Selection]
//                                        ,pr.Trans_Reason as [Reason]
//                                        ,'' As [Intended_IPOSession_ID]
//                                        ,'' As [Intended_IPOSession_Name]
//                                        ,'' As [Company Name]
//                                        ,pr.Amount as [IPO Amount]
//                                        ,'' as [IPO Premium]
//                                        ,0 as [IPO Charge]
//                                        ,basicInfo.ID As [SelectionID]
//                                        ,'TRADEACC' As [AccountName]
//                                        From SBP_Payment_Posting_Request as pr
//                                        Inner join SBP_IPO_Customer_Broker_MoneyTransaction as tr
//                                        On Convert(varchar(100),pr.Payment_ID)=REPLACE (tr.Trans_Reason,SUBSTRING(tr.Trans_Reason,1,CHARINDEX('_',tr.Trans_Reason)),'')
//                                        Inner Join SBP_IPO_Application_BasicInfo as basicInfo
//                                        On basicInfo.Money_Trans_Ref_ID=tr.ID
//                                        Where pr.Payment_ID IN (select P.Payment_ID from #GroupByVoucher_PaymentPost as P)
//                                        AND tr.Entry_Branch_ID=" + GlobalVariableBO._branchId + @"
//                                        GROUP BY pr.Payment_ID,pr.Cust_Code,pr.Received_Date,pr.Payment_Media,pr.Deposit_Withdraw
//                                        ,pr.Amount,pr.Vouchar_SN,pr.Trans_Reason,pr.Amount,basicInfo.ID
//                            UNION all
//                                
//                                SELECT *
//			FROM (
//			
//			SELECT
//			0 As [PaymentPosting_ID]
//			,Dep_Trans.ID As [ID]
//			,Dep_Trans.Cust_Code As [Customer]
//			,Dep_Trans.Received_Date As [Received Date]
//			,Dep_Trans.Money_TransactionType_ID 
//			,Dep_Trans.Money_TransactionType_Name as [Payment Method]
//			,Dep_Trans.Deposit_Withdraw As [Deposit/Withdraw]
//			,Cast(Dep_Trans.Amount as Money) as [Amount]
//			,Dep_Trans.Voucher_No as [Voucher No]
//			,Dep_Trans.Voucher_No as [Voucher_No_Selection]
//			,Dep_Trans.Trans_Reason	as [Reason]
//			,Dep_Trans.Intended_IPOSession_ID As [Intended_IPOSession_ID] 
//			,Dep_Trans.Intended_IPOSession_Name As [Intended_IPOSession_Name]
//			,'' As [Company Name]
//			,0 as [IPO Amount]
//			,'' as [IPO Premium]
//            ,0 as [IPO Charge]
//			,With_Trans.ID as [SelectionID]	
//			,'IPOtoIPO' As [AccountName]	     
//			FROM
//			( 
//				SELECT *
//				FROM [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction]
//				WHERE Deposit_Withdraw='" + Indication_PaymentMode.Deposit + @"'--'Deposit' 
//                AND Money_TransactionType_Name='" + Indication_IPOPaymentTransaction.TRIPO + @"'--'TRIPO'
//				AND Approval_Status=0 and Entry_Branch_ID=" + GlobalVariableBO._branchId + @"
//			) AS Dep_Trans
//			JOIN 
//			( 
//				SELECT *
//				FROM [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction]
//				WHERE Deposit_Withdraw='" + Indication_PaymentMode.Withdraw + @"'--'Withdraw' 
//               AND Money_TransactionType_Name='" + Indication_IPOPaymentTransaction.TRIPO + @"'--'TRIPO'
//				AND Approval_Status=0 and Entry_Branch_ID=" + GlobalVariableBO._branchId + @"
//			) AS With_Trans
//			ON CONVERT(varchar(100), With_Trans.ID)=REPLACE (Dep_Trans.Trans_Reason,SUBSTRING(Dep_Trans.Trans_Reason,1,CHARINDEX('_',Dep_Trans.Trans_Reason)),'')
//			
//			
//			
//			UNION ALL
//						
//			SELECT 
//			0 As [PaymentPosting_ID]
//			,With_Trans.ID As [ID]
//			,With_Trans.Cust_Code As [Customer]
//			,With_Trans.Received_Date As [Received Date]
//			,With_Trans.Money_TransactionType_ID 
//			,With_Trans.Money_TransactionType_Name as [Payment Method]
//			,With_Trans.Deposit_Withdraw As [Deposit/Withdraw]
//			,Cast(With_Trans.Amount as money) as [Amount]			
//			,With_Trans.Voucher_No as [Voucher No]
//			,With_Trans.Voucher_No as [Voucher_No_Selection]
//			,With_Trans.Trans_Reason as [Reason]
//			,isnull(With_Trans.Intended_IPOSession_ID,'') As [Intended_IPOSession_ID] 
//			,isnull(With_Trans.Intended_IPOSession_Name,'') As [Intended_IPOSession_Name]
//			,'' As [Company Name]
//			,0 as [IPO Amount]
//			,0 as [IPO Premium]
//            ,0 as [IPO Charge]
//			,With_Trans.ID as [SelectionID]	
//			,'IPOtoIPO' As [AccountName]			 
//			FROM
//			( 
//				SELECT *
//				FROM [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction]
//				WHERE Deposit_Withdraw='" + Indication_PaymentMode.Deposit + @"'--'Deposit' 
//                AND Money_TransactionType_Name='" + Indication_IPOPaymentTransaction.TRIPO + @"'--'TRIPO'
//				AND Approval_Status=0 and Entry_Branch_ID=" + GlobalVariableBO._branchId + @"
//			) AS Dep_Trans
//			JOIN 
//			( 
//				SELECT *
//				FROM [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction]
//				WHERE Deposit_Withdraw='" + Indication_PaymentMode.Withdraw + @"'--'Withdraw' 
//                AND Money_TransactionType_Name='" + Indication_IPOPaymentTransaction.TRIPO + @"'--'TRIPO'
//				AND Approval_Status=0 AND Entry_Branch_ID=" + GlobalVariableBO._branchId + @"
//			) AS With_Trans
//			ON CONVERT(varchar(100), With_Trans.ID)=REPLACE (Dep_Trans.Trans_Reason,SUBSTRING(Dep_Trans.Trans_Reason,1,CHARINDEX('_',Dep_Trans.Trans_Reason)),'')
//			GROUP BY With_Trans.ID,With_Trans.Received_Date,With_Trans.Cust_Code
//			,With_Trans.Money_TransactionType_ID,With_Trans.Intended_IPOSession_ID,With_Trans.Intended_IPOSession_Name
//			,With_Trans.Money_TransactionType_Name,With_Trans.Deposit_Withdraw,With_Trans.Amount,With_Trans.Trans_Reason,With_Trans.Voucher_No
//			)AS T
//			--ORDER BY T.SelectionID
//			
//			Union all
//			
//              SELECT 
//                 0 AS [PaymentPosting_ID]
//                 ,app.ID As [ID]
//                  ,app.[Cust_Code] AS [Customer]
//                  ,app.Application_Date AS [Received Date]
//                  ,0 AS [Money_TransactionType_ID]
//                  ,'' AS [Payment Method]
//                  ,'' AS [Deposit/Withdraw]
//                  ,Cast(app.[TotalAmount] as Money) AS [Amount]
//                  ,tr.Voucher_No AS [Voucher No]
//                  ,tr.Voucher_No as [Voucher_No_Selection]
//                  ,'' AS [Reason]
//                  ,app.IPOSession_ID AS [Intended_IPOSession_ID]
//                  ,app.IPOSession_Name AS [Intended_IPOSession_Name]
//                  ,app.Applied_Company AS [Company Name]
//                ,Cast(app.[TotalAmount] as Money) AS [IPO Amount]
//                  ,Cast(app.Premium as Money) AS [IPO Premium]
//                  ,0 AS [IPO Charge]
//                  ,app.Money_Trans_Ref_ID As [SelectionID]
//                ,'TRIPOAPPLICATION' AS [AccountName]                
//                From 
//                SBP_IPO_Customer_Broker_MoneyTransaction as tr                
//                Inner Join SBP_IPO_Application_BasicInfo as app
//                On app.Money_Trans_Ref_ID=tr.ID
//                Where 
//                 tr.Entry_Branch_ID=" + GlobalVariableBO._branchId + @" AND tr.Deposit_Withdraw='" + Indication_PaymentMode.Deposit + @"'--'Deposit' 
//                 And tr.Money_TransactionType_Name='" + Indication_IPOPaymentTransaction.TRIPO + @"'--'TRIPO' 
//                And tr.Approval_Status=0
//                 And app.Application_Satus=0 
//                                ) AS T
//                                ORDER BY T.[SelectionID],[AccountName] DESC
//                            
//                                  
//                            ";
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

        public DataTable GetMultiTransfer_ApplyTogether_MoneyTransaction_Pending_List()
        {
            DataTable dataTable;
            dataTable = null;
            string queryString = "";
            string queryString_Pro = "";
            queryString_Pro = @"SBP_IPOMultiTransferDepositApplyTogether_Approval";
            queryString = @"
                            /*
                                DROP TABLE #GroupByVoucher_IPOAcc
                                DROP TABLE #GroupByVoucher_PaymentPost
                                */


                                SELECT v.Cust_Code,v.[Voucher_No],v.ID,trn.Payment_ID,v.Entry_Branch_ID
                                INTO #GroupByVoucher_IPOAcc
                                FROM [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction] As v
                                Join [SBP_Payment_Posting_Request] As trn
                                On Convert(varchar(100),trn.Payment_ID)=REPLACE (v.Trans_Reason,SUBSTRING(v.Trans_Reason,1,CHARINDEX('_',v.Trans_Reason)),'')
                                AND v.Approval_Status=0 AND v.[Money_TransactionType_Name]='" + Indication_IPOPaymentTransaction.TRTA + @"'
                                JOIN [SBP_Database].dbo.SBP_IPO_Application_BasicInfo as app                            
                                ON app.Money_Trans_Ref_ID=v.ID
                                WHERE v.[Approval_Status]=0 AND v.[Money_TransactionType_Name]='" + Indication_IPOPaymentTransaction.TRTA + @"' 
                                AND v.Entry_Branch_ID=" + GlobalVariableBO._branchId + @" 
                                AND v.[Deposit_Withdraw]='" + Indication_PaymentMode.Deposit + @"'
                                AND 
									
									(
									(
											Select COUNT(*) 
											FROM [SBP_IPO_Customer_Broker_MoneyTransaction] as c 
											WHERE 
											REPLACE (c.Trans_Reason,SUBSTRING(c.Trans_Reason,1,CHARINDEX('_',c.Trans_Reason)),'')=Convert(varchar(100),trn.Payment_ID)		                                
											AND c.Cust_Code<>trn.Cust_Code
									)=1
									OR
									(
											Select COUNT(*) 
											FROM [SBP_IPO_Customer_Broker_MoneyTransaction] as c 
											WHERE 
											REPLACE (c.Trans_Reason,SUBSTRING(c.Trans_Reason,1,CHARINDEX('_',c.Trans_Reason)),'')=Convert(varchar(100),trn.Payment_ID)		                                
									)>1                                
                                )                               
                                
                                GROUP BY v.Cust_Code,v.[Voucher_No],trn.Payment_ID,v.ID,v.Entry_Branch_ID

                                --Select * from #GroupByVoucher_IPOAcc

                                SELECT v.Cust_Code,v.[Vouchar_SN],v.Payment_ID,trn.Entry_Branch_ID
                                INTO #GroupByVoucher_PaymentPost
                                FROM 
                                [SBP_Database].[dbo].[SBP_Payment_Posting_Request] As v
                                Join SBP_IPO_Customer_Broker_MoneyTransaction As trn
                                On Convert(varchar(100),v.Payment_ID)=REPLACE (trn.Trans_Reason,SUBSTRING(trn.Trans_Reason,1,CHARINDEX('_',trn.Trans_Reason)),'')
                                AND trn.Approval_Status=0 AND trn.[Money_TransactionType_Name]='" + Indication_IPOPaymentTransaction.TRTA + @"'
                                JOIN [SBP_Database].dbo.SBP_IPO_Application_BasicInfo as app
                                ON app.Money_Trans_Ref_ID=trn.ID
                                WHERE v.Approval_Status=0 AND v.[Payment_Media]='" + Indication_PaymentTransaction.TRIPO + @"'
                                AND trn.Entry_Branch_ID=" + GlobalVariableBO._branchId + @"
                                AND v.[Deposit_Withdraw]='" + Indication_PaymentMode.Withdraw + @"' 
                                AND 
									
                                (
									(
											Select COUNT(*) 
											FROM [SBP_IPO_Customer_Broker_MoneyTransaction] as c 
											WHERE 
											REPLACE (c.Trans_Reason,SUBSTRING(c.Trans_Reason,1,CHARINDEX('_',c.Trans_Reason)),'')=Convert(varchar(100),v.Payment_ID)		                                
											AND c.Cust_Code<>v.Cust_Code
									)=1
									OR
									(
											Select COUNT(*) 
											FROM [SBP_IPO_Customer_Broker_MoneyTransaction] as c 
											WHERE 
											REPLACE (c.Trans_Reason,SUBSTRING(c.Trans_Reason,1,CHARINDEX('_',c.Trans_Reason)),'')=Convert(varchar(100),v.Payment_ID)		                                
									)>1                                
                                )
                                GROUP BY v.Cust_Code,v.Vouchar_SN,v.Payment_ID,trn.Entry_Branch_ID
                                --select * from #GroupByVoucher_PaymentPost
                                SELECT T.* 
                                FROM(

                                        SELECT 
			                                   pr.Payment_ID AS [PaymentPosting_ID]
                                              ,prtrans.[ID] As ID
                                                ,prtrans.Remarks As 'Remark'
                                              ,prtrans.[Cust_Code] AS [Customer]
                                              ,prTrans.[Received_Date] AS [Received Date]
                                              ,[Money_TransactionType_ID] 
                                              ,[Money_TransactionType_Name] AS [Payment Method]
                                              ,prTrans.[Deposit_Withdraw] AS [Deposit/Withdraw]
                                              ,Cast( prtrans.[Amount] AS Money) As [Amount]
                                              ,[Voucher_No] AS [Voucher No]
                                              ,prTrans.Voucher_No as [Voucher_No_Selection]
                                              ,prTrans.[Trans_Reason] AS [Reason]
                                              ,[Intended_IPOSession_ID] 
                                              ,[Intended_IPOSession_Name]
                                              ,ISNULL((
                                                           Select c.Company_Name
                                                          From SBP_IPO_Company_Info as c
                                                          Where c.ID=(
                                                              Select IPO_Company_ID 
                                                              From SBP_IPO_Session as s
                                                              Where s.ID=prTrans.[Intended_IPOSession_ID]
                                                          )
                                              ),'') AS [Company Name]
                                              ,ISNULL((
                                                    Select t.Premium 
                                                    From SBP_IPO_Session as t
                                                    Where t.ID=prTrans.[Intended_IPOSession_ID]
                                              ),0) AS [IPO Premium]
                                              ,ISNULL((
                                                Select t.TotalAmount 
                                                From SBP_IPO_Session as t
                                                Where t.ID=prTrans.[Intended_IPOSession_ID]
                                              ),0) AS [IPO Amount]  
                                              ,0
                                              --ISNULL((
                                              --      Select t.Amount
                                              --     From SBP_Payment_OCC_Purpose as t
                                              --      Where t.OCC_Purpose='IPO App Charge'
                                              --),0) 
                                              AS [IPO Charge]
                                              ,app.ID As [SelectionID]
                                              ,'IPOACC' AS [AccountName]  
                                		     
                                        FROM SBP_Payment_Posting_Request as pr
                                        Inner join SBP_IPO_Customer_Broker_MoneyTransaction as prTrans
                                        On Convert(varchar(100),pr.Payment_ID)=REPLACE (prTrans.Trans_Reason,SUBSTRING(prTrans.Trans_Reason,1,CHARINDEX('_',prTrans.Trans_Reason)),'')
                                        Inner Join SBP_IPO_Application_BasicInfo as app
                                        On app.Money_Trans_Ref_ID=prTrans.ID
                                        WHERE prTrans.[Approval_Status]=0 AND prTrans.[Money_TransactionType_Name]='" + Indication_IPOPaymentTransaction.TRTA + @"' AND
                                        prTrans.ID IN (
                                                            Select c.ID From #GroupByVoucher_IPOAcc as c 
                                                            
                                        )
                                    AND prTrans.Entry_Branch_ID=" + GlobalVariableBO._branchId + @"
                                    AND prTrans.[Deposit_Withdraw]='" + Indication_PaymentMode.Deposit + @"'   
                                        
                                    UNION ALL
                                        
                                   SELECT 
                                         pr.Payment_ID AS [PaymentPosting_ID]
		                                 ,app.ID As [ID]
                                            ,tr.Remarks As 'Remark'
                                          ,app.[Cust_Code] AS [Customer]
                                          ,app.Application_Date AS [Received Date]
                                          ,0 AS [Money_TransactionType_ID]
                                          ,'' AS [Payment Method]
                                          ,'' AS [Deposit/Withdraw]
                                          ,app.[TotalAmount] AS [Amount]
                                          ,'' AS [Voucher No]
                                          ,tr.Voucher_No as [Voucher_No_Selection]
                                          ,'' AS [Reason]
                                          ,app.IPOSession_ID AS [Intended_IPOSession_ID]
                                          ,app.IPOSession_Name AS [Intended_IPOSession_Name]
                                          ,app.Applied_Company AS [Company Name]
                                        ,app.[TotalAmount] AS [IPO Amount]
                                          ,app.Premium AS [IPO Premium]
                                          ,0 AS [IPO Charge]
                                          ,app.ID As [SelectionID]
                                        ,'APPLICATION' AS [AccountName]
                                        --, [Serial_No], '', '', '', [No_Of_Share], [Lot_No], [Amount], [Total_Share_Value], '','' 
                                        --, [Fine_Amount],'', [BO_ID], [Money_Trans_Ref_ID], [Application_Date], [Application_Satus], [AppStatus_UpdatedBy], [AppStatus_UpdatedDate], [AppStatus_RejectedReason], [Entry_Date], [Entry_By], [Updated_Date], [Update_By] 
                                        From SBP_Payment_Posting_Request as pr
                                        Inner join SBP_IPO_Customer_Broker_MoneyTransaction as tr
                                        On Convert(varchar(100),pr.Payment_ID)=REPLACE (tr.Trans_Reason,SUBSTRING(tr.Trans_Reason,1,CHARINDEX('_',tr.Trans_Reason)),'')
                                        Inner Join SBP_IPO_Application_BasicInfo as app
                                        On app.Money_Trans_Ref_ID=tr.ID
                                        Where 
                                         tr.Entry_Branch_ID=" + GlobalVariableBO._branchId + @" AND
                                        Money_Trans_Ref_ID IN (
                                                Select b.ID 
                                                From #GroupByVoucher_IPOAcc as b 
                                        )
                                    UNION All
                                    
                                    SELECT
                                        pr.Payment_ID as [PaymentPosting_ID]
                                        ,pr.Payment_ID as [ID]
                                        ,tr.Remarks As 'Remark' 
                                        ,pr.Cust_Code As [Customer]
                                        ,pr.Received_Date as [Received Date]
                                        ,0 As [Money_TransactionType_ID]
                                        ,pr.Payment_Media as [Payment Method]
                                        ,pr.Deposit_Withdraw As [Deposit/Withdraw]
                                        ,pr.Amount as [Amount]
                                        ,pr.Vouchar_SN as [Voucher No]
                                        ,pr.Vouchar_SN as [Voucher_No_Selection]
                                        ,pr.Trans_Reason as [Reason]
                                        ,'' As [Intended_IPOSession_ID]
                                        ,'' As [Intended_IPOSession_Name]
                                        ,'' As [Company Name]
                                        ,pr.Amount as [IPO Amount]
                                        ,'' as [IPO Premium]
                                        ,0 as [IPO Charge]
                                        ,basicInfo.ID As [SelectionID]
                                        ,'TRADEACC' As [AccountName]
                                        From SBP_Payment_Posting_Request as pr
                                        Inner join SBP_IPO_Customer_Broker_MoneyTransaction as tr
                                        On Convert(varchar(100),pr.Payment_ID)=REPLACE (tr.Trans_Reason,SUBSTRING(tr.Trans_Reason,1,CHARINDEX('_',tr.Trans_Reason)),'')
                                        Inner Join SBP_IPO_Application_BasicInfo as basicInfo
                                        On basicInfo.Money_Trans_Ref_ID=tr.ID
                                        Where pr.Payment_ID IN (select P.Payment_ID from #GroupByVoucher_PaymentPost as P)
                                        AND tr.Entry_Branch_ID=" + GlobalVariableBO._branchId + @"
                                        GROUP BY pr.Payment_ID,pr.Cust_Code,pr.Received_Date,pr.Payment_Media,pr.Deposit_Withdraw
                                        ,pr.Amount,pr.Vouchar_SN,pr.Trans_Reason,pr.Amount,basicInfo.ID,tr.Remarks
                            UNION all
                                
                                SELECT *
			FROM (
			
			SELECT
			0 As [PaymentPosting_ID]
			,Dep_Trans.ID As [ID]
            ,Dep_Trans.Remarks As 'Remark'
			,Dep_Trans.Cust_Code As [Customer]
			,Dep_Trans.Received_Date As [Received Date]
			,Dep_Trans.Money_TransactionType_ID 
			,Dep_Trans.Money_TransactionType_Name as [Payment Method]
			,Dep_Trans.Deposit_Withdraw As [Deposit/Withdraw]
			,Cast(Dep_Trans.Amount as Money) as [Amount]
			,Dep_Trans.Voucher_No as [Voucher No]
			,Dep_Trans.Voucher_No as [Voucher_No_Selection]
			,Dep_Trans.Trans_Reason	as [Reason]
			,Dep_Trans.Intended_IPOSession_ID As [Intended_IPOSession_ID] 
			,Dep_Trans.Intended_IPOSession_Name As [Intended_IPOSession_Name]
			,'' As [Company Name]
			,0 as [IPO Amount]
			,'' as [IPO Premium]
            ,0 as [IPO Charge]
			,Dep_Trans.ID as [SelectionID]	
			,'DEP_IPOtoIPO' As [AccountName]	     
			FROM
			( 
				SELECT *
				FROM [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction]
				WHERE Deposit_Withdraw='" + Indication_PaymentMode.Deposit + @"'--'Deposit' 
                AND Money_TransactionType_Name='" + Indication_IPOPaymentTransaction.TRIPO + @"'--'TRIPO'
				AND Approval_Status=0 and Entry_Branch_ID=" + GlobalVariableBO._branchId + @"
			) AS Dep_Trans
			JOIN 
			( 
				SELECT *
				FROM [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction]
				WHERE Deposit_Withdraw='" + Indication_PaymentMode.Withdraw + @"'--'Withdraw' 
               AND Money_TransactionType_Name='" + Indication_IPOPaymentTransaction.TRIPO + @"'--'TRIPO'
				AND Approval_Status=0 and Entry_Branch_ID=" + GlobalVariableBO._branchId + @"
			) AS With_Trans
			ON CONVERT(varchar(100), With_Trans.ID)=REPLACE (Dep_Trans.Trans_Reason,SUBSTRING(Dep_Trans.Trans_Reason,1,CHARINDEX('_',Dep_Trans.Trans_Reason)),'')
			
			
			
			UNION ALL
						
			SELECT 
			0 As [PaymentPosting_ID]
			,With_Trans.ID As [ID]
            ,With_Trans.Remarks As 'Remark'
			,With_Trans.Cust_Code As [Customer]
			,With_Trans.Received_Date As [Received Date]
			,With_Trans.Money_TransactionType_ID 
			,With_Trans.Money_TransactionType_Name as [Payment Method]
			,With_Trans.Deposit_Withdraw As [Deposit/Withdraw]
			,Cast(With_Trans.Amount as money) as [Amount]			
			,With_Trans.Voucher_No as [Voucher No]
			,With_Trans.Voucher_No as [Voucher_No_Selection]
			,With_Trans.Trans_Reason as [Reason]
			,isnull(With_Trans.Intended_IPOSession_ID,'') As [Intended_IPOSession_ID] 
			,isnull(With_Trans.Intended_IPOSession_Name,'') As [Intended_IPOSession_Name]
			,'' As [Company Name]
			,0 as [IPO Amount]
			,0 as [IPO Premium]
            ,0 as [IPO Charge]
			,Dep_Trans.ID as [SelectionID]	
			,'With_IPOtoIPO' As [AccountName]			 
			FROM
			( 
				SELECT *
				FROM [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction]
				WHERE Deposit_Withdraw='" + Indication_PaymentMode.Deposit + @"'--'Deposit' 
                AND Money_TransactionType_Name='" + Indication_IPOPaymentTransaction.TRIPO + @"'--'TRIPO'
                 
				AND Approval_Status=0 and Entry_Branch_ID=" + GlobalVariableBO._branchId + @"
			) AS Dep_Trans
			JOIN 
			( 
				SELECT *
				FROM [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction]
				WHERE Deposit_Withdraw='" + Indication_PaymentMode.Withdraw + @"'--'Withdraw' 
                AND Money_TransactionType_Name='" + Indication_IPOPaymentTransaction.TRIPO + @"'--'TRIPO'
                 
				AND Approval_Status=0 AND Entry_Branch_ID=" + GlobalVariableBO._branchId + @"
			) AS With_Trans
			ON CONVERT(varchar(100), With_Trans.ID)=REPLACE (Dep_Trans.Trans_Reason,SUBSTRING(Dep_Trans.Trans_Reason,1,CHARINDEX('_',Dep_Trans.Trans_Reason)),'')
			GROUP BY With_Trans.ID,Dep_Trans.ID,With_Trans.Received_Date,With_Trans.Cust_Code,With_Trans.Remarks
			,With_Trans.Money_TransactionType_ID,With_Trans.Intended_IPOSession_ID,With_Trans.Intended_IPOSession_Name
			,With_Trans.Money_TransactionType_Name,With_Trans.Deposit_Withdraw,With_Trans.Amount,With_Trans.Trans_Reason,With_Trans.Voucher_No
			)AS T
			--ORDER BY T.SelectionID
			
			Union all
			
              SELECT 
                 0 AS [PaymentPosting_ID]
                 ,app.ID As [ID]
                    ,tr.Remarks As 'Remark'
                  ,app.[Cust_Code] AS [Customer]
                  ,app.Application_Date AS [Received Date]
                  ,0 AS [Money_TransactionType_ID]
                  ,'' AS [Payment Method]
                  ,'' AS [Deposit/Withdraw]
                  ,Cast(app.[TotalAmount] as Money) AS [Amount]
                  ,tr.Voucher_No AS [Voucher No]
                  ,tr.Voucher_No as [Voucher_No_Selection]
                  ,'' AS [Reason]
                  ,app.IPOSession_ID AS [Intended_IPOSession_ID]
                  ,app.IPOSession_Name AS [Intended_IPOSession_Name]
                  ,app.Applied_Company AS [Company Name]
                ,Cast(app.[TotalAmount] as Money) AS [IPO Amount]
                  ,Cast(app.Premium as Money) AS [IPO Premium]
                  ,0 AS [IPO Charge]
                  ,app.Money_Trans_Ref_ID As [SelectionID]
                ,'TRIPOAPPLICATION' AS [AccountName]                
                From 
                SBP_IPO_Customer_Broker_MoneyTransaction as tr                
                Inner Join SBP_IPO_Application_BasicInfo as app
                On app.Money_Trans_Ref_ID=tr.ID
                Where 
                 tr.Entry_Branch_ID=" + GlobalVariableBO._branchId + @" AND tr.Deposit_Withdraw='" + Indication_PaymentMode.Deposit + @"'--'Deposit' 
                 And tr.Money_TransactionType_Name='" + Indication_IPOPaymentTransaction.TRIPO + @"'--'TRIPO' 
                And tr.Approval_Status=0
                 And app.Application_Satus=0 
                                ) AS T
                                ORDER BY T.[SelectionID],[AccountName] DESC
                            
                                  
                            ";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@EntryBranch_ID", SqlDbType.Int, GlobalVariableBO._branchId);
                dataTable = _dbConnection.ExecuteProQuery(queryString_Pro);
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

        public DataTable GetMultiTransferBack_MoneyTransaction_Pending_List()
        {
            DataTable dataTable;
            dataTable = null;
            string queryString = "";
            queryString = @"
                            --DROP TABLE #GroupByVoucher_IPOAcc
                            --DROP TABLE #GroupByVoucher_PaymentPost

                            SELECT v.[Voucher_No]
                            INTO #GroupByVoucher_IPOAcc
                            FROM [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction] As v
                            WHERE [Approval_Status]=0 AND [Money_TransactionType_Name]='TRTA'  
                            AND [Deposit_Withdraw]='" + Indication_PaymentMode.Withdraw + @"' 
                            AND v.Trans_Reason LIKE '%TRPR%' 
                            GROUP BY [Voucher_No]
                            HAVING COUNT(*)>=1

                            SELECT v.[Vouchar_SN]
                            INTO #GroupByVoucher_PaymentPost
                            FROM [SBP_Database].[dbo].[SBP_Payment_Posting_Request] As v
                            WHERE [Approval_Status]=0 AND [Payment_Media]='TRIPO'
                            AND [Deposit_Withdraw]='" + Indication_PaymentMode.Deposit + @"'
                            AND v.Trans_Reason LIKE '%TRPR%'     
                            GROUP BY [Vouchar_SN]
                            HAVING COUNT(*)>=1

                              SELECT T.* 
                            FROM(

	                                SELECT 
		                                  [ID]
		                                  ,[Cust_Code] AS [Customer]
		                                  ,[Received_Date] AS [Received Date]
		                                  ,[Money_TransactionType_ID] 
		                                  ,[Money_TransactionType_Name] AS [Payment Method]
		                                  ,[Deposit_Withdraw] AS [Deposit/Withdraw]
		                                  ,[Amount] AS [Amount]
		                                  ,[Voucher_No] AS [Voucher No]
		                                  ,[Trans_Reason] AS [Reason]
		                                  ,[Intended_IPOSession_ID] 
		                                  ,[Intended_IPOSession_Name]
		                                  ,ISNULL((
			                                           Select c.Company_Name
                                                      From SBP_IPO_Company_Info as c
                                                      Where c.ID=(
	                                                      Select IPO_Company_ID 
	                                                      From SBP_IPO_Session as s
	                                                      Where s.ID=prTrans.[Intended_IPOSession_ID]
                                                      )
		                                  ),'') AS [Company Name]
                                          ,ISNULL((
			                                Select t.TotalAmount 
			                                From SBP_IPO_Session as t
			                                Where t.ID=prTrans.[Intended_IPOSession_ID]
		                                  ),0) AS [IPO Amount]
		                                  ,ISNULL((
				                                Select t.Premium 
				                                From SBP_IPO_Session as t
				                                Where t.ID=prTrans.[Intended_IPOSession_ID]
		                                  ),0) AS [IPO Premium]
		                                  ,0
                                          --ISNULL((
				                          --      Select t.Amount
				                          --      From SBP_Payment_OCC_Purpose as t
				                          --      Where t.OCC_Purpose='IPO App Charge'
		                                  --),0) 
                                          AS [IPO Charge]
                            		      ,'IPOACC' AS [AccountName]  
	                                FROM [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction] AS prTrans
	                                WHERE [Approval_Status]=0 AND [Money_TransactionType_Name]='TRTA' AND
	                                [Voucher_No] IN  (
						                                Select c.[Voucher_No] From #GroupByVoucher_IPOAcc as c
	                                )
	                                AND
	                                [Voucher_No] IN (
						                                Select c.[Vouchar_SN] From #GroupByVoucher_PaymentPost as c
	                                )
                                   
                                    AND [Deposit_Withdraw]='" + Indication_PaymentMode.Withdraw + @"'    
	                                
                                    UNION ALL
	                                
                                    SELECT [Payment_ID] AS [ID]
		                                  ,[Cust_Code] AS [Customer]
		                                  ,[Received_Date] AS [Received Date]
		                                  ,0 AS [Money_TransactionType_ID]
		                                  ,[Payment_Media] AS [Payment Method]
		                                  ,[Deposit_Withdraw] AS [Deposit/Withdraw]
		                                  ,[Amount] AS [Amount]
		                                  ,[Vouchar_SN] AS [Voucher No]
		                                  ,[Trans_Reason] AS [Reason]
		                                  ,0 AS [Intended_IPOSession_ID]
		                                  ,'' AS [Intended_IPOSession_Name]
		                                  ,'' AS [Company Name]
                                          ,0 AS [IPO Amount]
		                                  ,0 AS [IPO Premium]
		                                  ,0 AS [IPO Charge]
                                          ,'TRADEACC' AS [AccountName]    				
	                                FROM [SBP_Database].[dbo].[SBP_Payment_Posting_Request]
	                                WHERE [Payment_Media]='TRIPO' 
                                    AND [Vouchar_SN] IN (
						                                Select c.[Vouchar_SN] From #GroupByVoucher_PaymentPost as c
	                                ) 
	                                AND [Vouchar_SN] IN (
						                                Select c.[Voucher_No] From #GroupByVoucher_IPOAcc as c
	                                )
                                    AND Entry_Branch_ID=" + GlobalVariableBO._branchId + @"
                                    AND [Deposit_Withdraw]='" + Indication_PaymentMode.Deposit + @"' 
                            ) AS T
                            ORDER BY T.[Voucher No]
                            ";
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

        public DataTable Get_NonTransfer_money_depositSingle()
        {
            DataTable dt = new DataTable();
            string query = "";
            query = @"SBP_IPOChequeReturnForDepositOnly";
            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteProQuery(query);
            }
            catch (Exception ex)
            { throw ex; }
            finally { _dbConnection.CloseDatabase(); }
            return dt;
        }
        public void Insert_72(string id, string cust_code)
        {
        }
        public DataTable GetNonTransferDeposit_MoneyTransaction_Pending_List()
        {
            DataTable dataTable;
            dataTable = null;
            string queryString = "";
            queryString = @"
                        SELECT [ID]
                              ,[Cust_Code] AS [Customer]
                              ,[Received_Date] AS [Received Date]
                              ,[Money_TransactionType_ID]
                              ,[Money_TransactionType_Name] AS [Payment Method]
                              ,[Deposit_Withdraw] AS [Deposit/Withdraw]
                              ,[Amount] AS [Amount]
                              ,[Voucher_No] AS [Voucher No]
                              ,[Trans_Reason] AS [Reason] 
                              ,ISNULL([Intended_IPOSession_ID],0) AS [Intended_IPOSession_ID]
                              ,ISNULL([Intended_IPOSession_Name],'') AS [Intended_IPOSession_Name]
                              ,ISNULL((
			                                           Select c.Company_Name
                                                      From SBP_IPO_Company_Info as c
                                                      Where c.ID=(
	                                                      Select IPO_Company_ID 
	                                                      From SBP_IPO_Session as s
	                                                      Where s.ID=trans.[Intended_IPOSession_ID]
                                                      )
		                      ),'') AS [Company Name]
                             ,ISNULL((
		                            Select t.Premium 
		                            From SBP_IPO_Session as t
		                            Where t.ID=trans.[Intended_IPOSession_ID]
                              ),0) AS [IPO Premium]
                             ,ISNULL((
		                            Select t.TotalAmount 
		                            From SBP_IPO_Session as t
		                            Where t.ID=trans.[Intended_IPOSession_ID]
                              ),0) AS [IPO Amount] 
                             ,0
                             --ISNULL((
		                     --       Select t.Amount
		                     --       From SBP_Payment_OCC_Purpose as t
		                     --       Where t.OCC_Purpose='IPO App Charge'
                             -- ),0) 
                            AS [IPO Charge]
                          FROM [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction] as trans
                          WHERE [Money_TransactionType_Name] not in ('TRTA','TRIPOApp','TRIPO')  
                           AND [Voucher_No] NOT IN ('IPOSC','IPOWC') And Remarks NOT LIKE '%NRB Charge%'
                          AND Deposit_Withdraw='Deposit'
                          AND Entry_Branch_ID=" + GlobalVariableBO._branchId+@"
                          AND [Approval_Status]=0 AND ID NOT IN (Select Money_Trans_Ref_ID From SBP_IPO_Application_BasicInfo Where ISNULL(Money_Trans_Ref_ID,0)<>0)";
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

        public DataTable GetNonTransferWithdraw_MoneyTransaction_Pending_List()
        {
            DataTable dataTable;
            dataTable = null;
            string queryString = "";
            queryString = @"
                        SELECT [ID]
                              ,[Cust_Code] AS [Customer]
                              ,[Received_Date] AS [Received Date]
                              ,[Money_TransactionType_ID] 
                              ,[Money_TransactionType_Name] AS [Payment Method] 
                              ,[Deposit_Withdraw] AS [Deposit/Withdraw]
                              ,[Amount]  AS [Amount]
                              ,[Voucher_No] AS [Voucher No]
                              ,[Trans_Reason] AS [Reason]
                              ,ISNULL([Intended_IPOSession_ID],0) AS [Intended_IPOSession_ID]
                              ,ISNULL([Intended_IPOSession_Name],'') AS [Intended_IPOSession_Name]
                              ,ISNULL((
			                                           Select c.Company_Name
                                                      From SBP_IPO_Company_Info as c
                                                      Where c.ID=(
	                                                      Select IPO_Company_ID 
	                                                      From SBP_IPO_Session as s
	                                                      Where s.ID=trans.[Intended_IPOSession_ID]
                                                      )
		                      ),'') AS [Company Name]
                               ,ISNULL((
		                            Select t.Premium 
		                            From SBP_IPO_Session as t
		                            Where t.ID=trans.[Intended_IPOSession_ID]
                              ),0) AS [IPO Premium]
                             ,ISNULL((
		                            Select t.TotalAmount 
		                            From SBP_IPO_Session as t
		                            Where t.ID=trans.[Intended_IPOSession_ID]
                              ),0) AS [IPO Amount] 
	                          ,0
                              --ISNULL((
			                  --      Select t.Amount
			                  --      From SBP_Payment_OCC_Purpose as t
			                  --      Where t.OCC_Purpose='IPO App Charge'
	                          --),0) 
                              AS [IPO Charge]
                             
                          FROM [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction] as trans
                          WHERE [Money_TransactionType_Name]<>'TRTA' AND [Money_TransactionType_Name]<>'TRIPOApp'
                            AND [Money_TransactionType_Name]<>'TRIPO'
                          AND Deposit_Withdraw='Withdraw'
                          AND Entry_Branch_ID=" + GlobalVariableBO._branchId + @"
                          AND [Approval_Status]=0";
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

        public DataTable GetNonTransferBack_Withdraw_MoneyTransaction_Pending_List()
        {
            DataTable dataTable;
            dataTable = null;
            string queryString = "";
            queryString = @"
                        SELECT [ID]
                              ,[Cust_Code] AS [Customer]
                              ,[Received_Date] AS [Received Date]
                              ,[Money_TransactionType_ID] 
                              ,[Money_TransactionType_Name] AS [Payment Method] 
                              ,[Deposit_Withdraw] AS [Deposit/Withdraw]
                              ,[Amount]  AS [Amount]
                              ,[Voucher_No] AS [Voucher No]
                              ,[Trans_Reason] AS [Reason]
                              ,ISNULL([Intended_IPOSession_ID],0) AS [Intended_IPOSession_ID]
                              ,ISNULL([Intended_IPOSession_Name],'') AS [Intended_IPOSession_Name]
                              ,ISNULL((
			                                           Select c.Company_Name
                                                      From SBP_IPO_Company_Info as c
                                                      Where c.ID=(
	                                                      Select IPO_Company_ID 
	                                                      From SBP_IPO_Session as s
	                                                      Where s.ID=trans.[Intended_IPOSession_ID]
                                                      )
		                      ),'') AS [Company Name]
                               ,ISNULL((
		                            Select t.Premium 
		                            From SBP_IPO_Session as t
		                            Where t.ID=trans.[Intended_IPOSession_ID]
                              ),0) AS [IPO Premium]
                             ,ISNULL((
		                            Select t.TotalAmount 
		                            From SBP_IPO_Session as t
		                            Where t.ID=trans.[Intended_IPOSession_ID]
                              ),0) AS [IPO Amount] 
	                          ,0
                              --ISNULL((
			                  --      Select t.Amount
			                  --      From SBP_Payment_OCC_Purpose as t
			                  --      Where t.OCC_Purpose='IPO App Charge'
	                          --),0) 
                              AS [IPO Charge]
                             
                          FROM [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction] as trans
                          WHERE [Money_TransactionType_Name]<>'TRTA' AND [Money_TransactionType_Name]<>'TRIPOApp'
                          AND [Money_TransactionType_Name]<>'TRIPO'
                          AND Trans_Reason LIKE '%Refund%'  
                          AND Deposit_Withdraw='Withdraw'
                          AND Entry_Branch_ID=" + GlobalVariableBO._branchId + @"
                          AND [Approval_Status]=0";
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

        public DataTable GetSingleTransferWithdraw_MoneyTransaction_Pending_List()
        {
            DataTable dataTable;
            dataTable = null;
            string queryString = "";
            queryString = @" 
                            --DROP TABLE #GroupByVoucher_IPOAcc
                            --DROP TABLE #GroupByVoucher_PaymentPost

                            SELECT v.[Voucher_No]
                            INTO #GroupByVoucher_IPOAcc
                            FROM [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction] As v
                            WHERE [Approval_Status]=0 AND [Money_TransactionType_Name]='TRTA'  
                            AND [Deposit_Withdraw]='" + Indication_PaymentMode.Withdraw + @"'
                            AND v.Trans_Reason NOT LIKE '%TRPR%'
                            AND v.Trans_Reason NOT LIKE '%TRTA%'  
                            GROUP BY [Voucher_No]
                            HAVING COUNT(*)=1

                            SELECT v.[Vouchar_SN]
                            INTO #GroupByVoucher_PaymentPost
                            FROM [SBP_Database].[dbo].[SBP_Payment_Posting_Request] As v
                            WHERE [Approval_Status]=0 AND [Payment_Media]='TRIPO'
                            AND [Deposit_Withdraw]='" + Indication_PaymentMode.Deposit + @"'  
                            AND v.Trans_Reason NOT LIKE '%TRPR%'
                            AND v.Trans_Reason NOT LIKE '%TRTA%'
                            GROUP BY [Vouchar_SN]
                            HAVING COUNT(*)=1

                            SELECT T.* 
                            FROM(

	                                SELECT 
		                                  [ID]
		                                  ,[Cust_Code] AS [Customer]
		                                  ,[Received_Date] AS [Received Date]
		                                  ,[Money_TransactionType_ID] 
		                                  ,[Money_TransactionType_Name] AS [Payment Method]
		                                  ,[Deposit_Withdraw] AS [Deposit/Withdraw]
		                                  ,[Amount] AS [Amount]
		                                  ,[Voucher_No] AS [Voucher No]
		                                  ,[Trans_Reason] AS [Reason]
		                                  ,[Intended_IPOSession_ID] 
		                                  ,[Intended_IPOSession_Name]
		                                  ,ISNULL((
			                                           Select c.Company_Name
                                                      From SBP_IPO_Company_Info as c
                                                      Where c.ID=(
	                                                      Select IPO_Company_ID 
	                                                      From SBP_IPO_Session as s
	                                                      Where s.ID=prTrans.[Intended_IPOSession_ID]
                                                      )
		                                  ),'') AS [Company Name]
		                                  ,ISNULL((
				                                Select t.Premium 
				                                From SBP_IPO_Session as t
				                                Where t.ID=prTrans.[Intended_IPOSession_ID]
		                                  ),0) AS [IPO Premium]
                                          ,ISNULL((
			                                Select t.TotalAmount 
			                                From SBP_IPO_Session as t
			                                Where t.ID=prTrans.[Intended_IPOSession_ID]
		                                  ),0) AS [IPO Amount]  
		                                  ,0
                                          --ISNULL((
				                          --      Select t.Amount
				                          --     From SBP_Payment_OCC_Purpose as t
				                          --      Where t.OCC_Purpose='IPO App Charge'
		                                  --),0) 
                                          AS [IPO Charge]
                                          ,'IPOACC' AS [AccountName]  
                            		     ,Replace(CONVERT(varchar(100),Substring(prTrans.Trans_Reason,CHARINDEX('_',prTrans.Trans_Reason),len(prTrans.Trans_Reason))),'_','') As SelectionID
	                                FROM [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction] AS prTrans
	                                WHERE [Approval_Status]=0 AND [Money_TransactionType_Name]='TRTA' AND
	                                [Voucher_No] IN  (
						                                Select c.[Voucher_No] From #GroupByVoucher_IPOAcc as c
	                                )
	                                AND
	                                [Voucher_No] IN (
						                                Select c.[Vouchar_SN] From #GroupByVoucher_PaymentPost as c
	                                )
                                    AND [Deposit_Withdraw]='" + Indication_PaymentMode.Withdraw + @"'
	                                UNION ALL
	                                SELECT [Payment_ID] AS [ID]
		                                  ,[Cust_Code] AS [Customer]
		                                  ,[Received_Date] AS [Received Date]
		                                  ,0 AS [Money_TransactionType_ID]
		                                  ,[Payment_Media] AS [Payment Method]
		                                  ,[Deposit_Withdraw] AS [Deposit/Withdraw]
		                                  ,[Amount] AS [Amount]
		                                  ,[Vouchar_SN] AS [Voucher No]
		                                  ,[Trans_Reason] AS [Reason]
		                                  ,0 AS [Intended_IPOSession_ID]
		                                  ,'' AS [Intended_IPOSession_Name]
		                                  ,'' AS [Company Name]
                                          ,0 AS [IPO Amount]
		                                  ,0 AS [IPO Premium]
		                                  ,0 AS [IPO Charge]
                                          ,'TRADEACC' AS [AccountName] 
   		                                    ,[Payment_ID] As SelectionID  
	                                FROM [SBP_Database].[dbo].[SBP_Payment_Posting_Request]
	                                WHERE [Payment_Media]='TRIPO' AND [Vouchar_SN] IN (
						                                Select c.[Vouchar_SN] From #GroupByVoucher_PaymentPost as c
	                                ) 
	                                AND [Vouchar_SN] IN (
						                                Select c.[Voucher_No] From #GroupByVoucher_IPOAcc as c
	                                )
                                    AND Entry_Branch_ID=" + GlobalVariableBO._branchId + @"
                                    AND [Deposit_Withdraw]='" + Indication_PaymentMode.Deposit + @"' 
                            ) AS T
                            ORDER BY T.[Voucher No]
                            ";
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

        public DataTable GetMultiTransferWithdraw_MoneyTransaction_Pending_List()
        {
            DataTable dataTable;
            dataTable = null;
            string queryString = "";
            queryString = @" /*
                            DROP TABLE #GroupByVoucher_IPOAcc
                            DROP TABLE #GroupByVoucher_PaymentPost
                            */
                            SELECT v.[Voucher_No]
                            INTO #GroupByVoucher_IPOAcc
                            FROM [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction] As v
                            WHERE [Approval_Status]=0 AND [Money_TransactionType_Name]='TRTA'  
                            AND [Deposit_Withdraw]='Withdraw'
                            AND v.Trans_Reason NOT LIKE '%TRPR%'
                            AND v.Trans_Reason NOT LIKE '%TRTA%'  
                            GROUP BY [Voucher_No]
                            HAVING COUNT(*)>1

                            SELECT v.[Vouchar_SN]
                            INTO #GroupByVoucher_PaymentPost
                            FROM [SBP_Database].[dbo].[SBP_Payment_Posting_Request] As v
                            WHERE [Approval_Status]=0 AND [Payment_Media]='TRIPO'
                            AND [Deposit_Withdraw]='Deposit'  
                            AND v.Trans_Reason NOT LIKE '%TRPR%'
                            AND v.Trans_Reason NOT LIKE '%TRTA%'
                            GROUP BY [Vouchar_SN]
                            HAVING COUNT(*)=1

                            Declare @MultiDepositId Table
                            (D_Id varchar(100),D_voucher_no varchar(100))
                            Insert @MultiDepositId 
                            Select trn.ID,trn.Voucher_No From SBP_IPO_Customer_Broker_MoneyTransaction As trn
                            Where trn.Deposit_Withdraw='Deposit' And trn.Money_TransactionType_Name='TRIPO' 
                            And trn.[Approval_Status]=0 And Intended_IPOSession_Name IS NULL
                            --Select * from @MultiDepositId

                            SELECT T.* 
                            FROM(

                        SELECT 
                              [ID]
                              ,[Cust_Code] AS [Customer]
                              ,[Received_Date] AS [Received Date]
                              ,[Money_TransactionType_ID] 
                              ,[Money_TransactionType_Name] AS [Payment Method]
                              ,[Deposit_Withdraw] AS [Deposit/Withdraw]
                              ,[Amount] AS [Amount]
                              ,[Voucher_No] AS [Voucher No]
                              ,[Trans_Reason] AS [Reason]
                              ,[Intended_IPOSession_ID] 
                              ,[Intended_IPOSession_Name]
                              ,ISNULL((
                                           Select c.Company_Name
                                          From SBP_IPO_Company_Info as c
                                          Where c.ID=(
                                              Select IPO_Company_ID 
                                              From SBP_IPO_Session as s
                                              Where s.ID=prTrans.[Intended_IPOSession_ID]
                                          )
                              ),'') AS [Company Name]
                              ,ISNULL((
                                    Select t.Premium 
                                    From SBP_IPO_Session as t
                                    Where t.ID=prTrans.[Intended_IPOSession_ID]
                              ),0) AS [IPO Premium]
                              ,ISNULL((
                                Select t.TotalAmount 
                                From SBP_IPO_Session as t
                                Where t.ID=prTrans.[Intended_IPOSession_ID]
                              ),0) AS [IPO Amount]  
                              ,0
                              --ISNULL((
                              --      Select t.Amount
                              --     From SBP_Payment_OCC_Purpose as t
                              --      Where t.OCC_Purpose='IPO App Charge'
                              --),0) 
                              AS [IPO Charge]
                              ,'IPOACC' AS [AccountName]  
                		     ,Isnull(Replace(CONVERT(varchar(100),Substring(prTrans.Trans_Reason,CHARINDEX('_',prTrans.Trans_Reason),len(prTrans.Trans_Reason))),'_',''),'') As SelectionID
                        FROM [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction] AS prTrans
                        WHERE [Approval_Status]=0 AND [Money_TransactionType_Name]='TRTA' AND
                        [Voucher_No] IN  (
                                            Select c.[Voucher_No] From #GroupByVoucher_IPOAcc as c
                        )
                        AND
                        [Voucher_No] IN (
                                            Select c.[Vouchar_SN] From #GroupByVoucher_PaymentPost as c
                        )
                        AND [Deposit_Withdraw]='Withdraw'
                        UNION ALL
                        SELECT [Payment_ID] AS [ID]
                              ,[Cust_Code] AS [Customer]
                              ,[Received_Date] AS [Received Date]
                              ,0 AS [Money_TransactionType_ID]
                              ,[Payment_Media] AS [Payment Method]
                              ,[Deposit_Withdraw] AS [Deposit/Withdraw]
                              ,[Amount] AS [Amount]
                              ,[Vouchar_SN] AS [Voucher No]
                              ,[Trans_Reason] AS [Reason]
                              ,0 AS [Intended_IPOSession_ID]
                              ,'' AS [Intended_IPOSession_Name]
                              ,'' AS [Company Name]
                              ,0 AS [IPO Amount]
                              ,0 AS [IPO Premium]
                              ,0 AS [IPO Charge]
                              ,'TRADEACC' AS [AccountName] 
                              ,Convert(varchar(100),Payment_ID) As SelectionID		
                        FROM [SBP_Database].[dbo].[SBP_Payment_Posting_Request]
                        WHERE [Payment_Media]='TRIPO' AND [Vouchar_SN] IN (
                                            Select c.[Vouchar_SN] From #GroupByVoucher_PaymentPost as c
                        ) 
                        AND [Vouchar_SN] IN (
                                            Select c.[Voucher_No] From #GroupByVoucher_IPOAcc as c
                        )
                        AND Entry_Branch_ID=1
                        AND [Deposit_Withdraw]='Deposit' 
                        
                        Union All
                        
                        SELECT 
                              [ID]
                              ,[Cust_Code] AS [Customer]
                              ,[Received_Date] AS [Received Date]
                              ,[Money_TransactionType_ID] 
                              ,[Money_TransactionType_Name] AS [Payment Method]
                              ,[Deposit_Withdraw] AS [Deposit/Withdraw]
                              ,[Amount] AS [Amount]
                              ,[Voucher_No] AS [Voucher No]
                              ,[Trans_Reason] AS [Reason]
                              ,[Intended_IPOSession_ID] 
                              ,[Intended_IPOSession_Name]
                              ,ISNULL((
                                           Select c.Company_Name
                                          From SBP_IPO_Company_Info as c
                                          Where c.ID=(
                                              Select IPO_Company_ID 
                                              From SBP_IPO_Session as s
                                              Where s.ID=prTrans.[Intended_IPOSession_ID]
                                          )
                              ),'') AS [Company Name]
                              ,ISNULL((
                                    Select t.Premium 
                                    From SBP_IPO_Session as t
                                    Where t.ID=prTrans.[Intended_IPOSession_ID]
                              ),0) AS [IPO Premium]
                              ,ISNULL((
                                Select t.TotalAmount 
                                From SBP_IPO_Session as t
                                Where t.ID=prTrans.[Intended_IPOSession_ID]
                              ),0) AS [IPO Amount]  
                              ,0
                              --ISNULL((
                              --      Select t.Amount
                              --     From SBP_Payment_OCC_Purpose as t
                              --      Where t.OCC_Purpose='IPO App Charge'
                              --),0) 
                              AS [IPO Charge]
                              ,'IPOTOIPODEPOSIT' AS [AccountName]  
                		     ,Convert(varchar(100),prTrans.ID) as SelectionID
                        FROM [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction] AS prTrans
                        Join @MultiDepositId As M
                        On M.D_Id=prTrans.ID
                        WHERE [Approval_Status]=0 AND [Money_TransactionType_Name]='TRIPO' AND
                        prTrans.[Voucher_No] =M.D_voucher_no       
                        AND prTrans.[Deposit_Withdraw]='Deposit'
                        
                        Union All
                        
                        SELECT 
                              [ID]
                              ,[Cust_Code] AS [Customer]
                              ,[Received_Date] AS [Received Date]
                              ,[Money_TransactionType_ID] 
                              ,[Money_TransactionType_Name] AS [Payment Method]
                              ,[Deposit_Withdraw] AS [Deposit/Withdraw]
                              ,[Amount] AS [Amount]
                              ,[Voucher_No] AS [Voucher No]
                              ,[Trans_Reason] AS [Reason]
                              ,[Intended_IPOSession_ID] 
                              ,[Intended_IPOSession_Name]
                              ,ISNULL((
                                           Select c.Company_Name
                                          From SBP_IPO_Company_Info as c
                                          Where c.ID=(
                                              Select IPO_Company_ID 
                                              From SBP_IPO_Session as s
                                              Where s.ID=prTrans.[Intended_IPOSession_ID]
                                          )
                              ),'') AS [Company Name]
                              ,ISNULL((
                                    Select t.Premium 
                                    From SBP_IPO_Session as t
                                    Where t.ID=prTrans.[Intended_IPOSession_ID]
                              ),0) AS [IPO Premium]
                              ,ISNULL((
                                Select t.TotalAmount 
                                From SBP_IPO_Session as t
                                Where t.ID=prTrans.[Intended_IPOSession_ID]
                              ),0) AS [IPO Amount]  
                              ,0
                              --ISNULL((
                              --      Select t.Amount
                              --     From SBP_Payment_OCC_Purpose as t
                              --      Where t.OCC_Purpose='IPO App Charge'
                              --),0) 
                              AS [IPO Charge]
                              ,'IPOTOIPOWITHDRAW' AS [AccountName]  
                		     ,Isnull(Replace(CONVERT(varchar(100),Substring(prTrans.Trans_Reason,CHARINDEX('_',prTrans.Trans_Reason),len(prTrans.Trans_Reason))),'_',''),'') As SelectionID  
                        FROM [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction] AS prTrans
                        Join @MultiDepositId As M
                        On M.D_Id=CONVERT(varchar(100),Replace(substring(prTrans.Trans_Reason,CHARINDEX('_',prTrans.Trans_Reason),Len(prTrans.Trans_Reason)),'_',''))

                        WHERE [Approval_Status]=0 AND [Money_TransactionType_Name]='TRIPO' AND
                        [Voucher_No] =M.D_voucher_no       
                        AND prTrans.[Deposit_Withdraw]='Withdraw'
                        
                         
                    ) AS T
                    ORDER BY T.[Voucher No]

                            ";
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

//        public DataTable GetMultiTransferWithdraw_MoneyTransaction_Pending_List()
//        {
//            DataTable dataTable;
//            dataTable = null;
//            string queryString = "";
//            queryString = @" 
//                            --DROP TABLE #GroupByVoucher_IPOAcc
//                            --DROP TABLE #GroupByVoucher_PaymentPost
//
//                            SELECT v.[Voucher_No]
//                            INTO #GroupByVoucher_IPOAcc
//                            FROM [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction] As v
//                            WHERE [Approval_Status]=0 AND [Money_TransactionType_Name]='TRTA'  
//                            AND [Deposit_Withdraw]='" + Indication_PaymentMode.Withdraw + @"'
//                            AND v.Trans_Reason NOT LIKE '%TRPR%'
//                            AND v.Trans_Reason NOT LIKE '%TRTA%'  
//                            GROUP BY [Voucher_No]
//                            HAVING COUNT(*)>1
//
//                            SELECT v.[Vouchar_SN]
//                            INTO #GroupByVoucher_PaymentPost
//                            FROM [SBP_Database].[dbo].[SBP_Payment_Posting_Request] As v
//                            WHERE [Approval_Status]=0 AND [Payment_Media]='TRIPO'
//                            AND [Deposit_Withdraw]='" + Indication_PaymentMode.Deposit + @"'  
//                            AND v.Trans_Reason NOT LIKE '%TRPR%'
//                            AND v.Trans_Reason NOT LIKE '%TRTA%'
//                            GROUP BY [Vouchar_SN]
//                            HAVING COUNT(*)=1
//
//                            SELECT T.* 
//                            FROM(
//
//	                                SELECT 
//		                                  [ID]
//		                                  ,[Cust_Code] AS [Customer]
//		                                  ,[Received_Date] AS [Received Date]
//		                                  ,[Money_TransactionType_ID] 
//		                                  ,[Money_TransactionType_Name] AS [Payment Method]
//		                                  ,[Deposit_Withdraw] AS [Deposit/Withdraw]
//		                                  ,[Amount] AS [Amount]
//		                                  ,[Voucher_No] AS [Voucher No]
//		                                  ,[Trans_Reason] AS [Reason]
//		                                  ,[Intended_IPOSession_ID] 
//		                                  ,[Intended_IPOSession_Name]
//		                                  ,ISNULL((
//			                                           Select c.Company_Name
//                                                      From SBP_IPO_Company_Info as c
//                                                      Where c.ID=(
//	                                                      Select IPO_Company_ID 
//	                                                      From SBP_IPO_Session as s
//	                                                      Where s.ID=prTrans.[Intended_IPOSession_ID]
//                                                      )
//		                                  ),'') AS [Company Name]
//		                                  ,ISNULL((
//				                                Select t.Premium 
//				                                From SBP_IPO_Session as t
//				                                Where t.ID=prTrans.[Intended_IPOSession_ID]
//		                                  ),0) AS [IPO Premium]
//                                          ,ISNULL((
//			                                Select t.TotalAmount 
//			                                From SBP_IPO_Session as t
//			                                Where t.ID=prTrans.[Intended_IPOSession_ID]
//		                                  ),0) AS [IPO Amount]  
//		                                  ,0
//                                          --ISNULL((
//				                          --      Select t.Amount
//				                          --     From SBP_Payment_OCC_Purpose as t
//				                          --      Where t.OCC_Purpose='IPO App Charge'
//		                                  --),0) 
//                                          AS [IPO Charge]
//                                          ,'IPOACC' AS [AccountName]  
//                            		     
//	                                FROM [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction] AS prTrans
//	                                WHERE [Approval_Status]=0 AND [Money_TransactionType_Name]='TRTA' AND
//	                                [Voucher_No] IN  (
//						                                Select c.[Voucher_No] From #GroupByVoucher_IPOAcc as c
//	                                )
//	                                AND
//	                                [Voucher_No] IN (
//						                                Select c.[Vouchar_SN] From #GroupByVoucher_PaymentPost as c
//	                                )
//                                    AND [Deposit_Withdraw]='" + Indication_PaymentMode.Withdraw + @"'
//	                                UNION ALL
//	                                SELECT [Payment_ID] AS [ID]
//		                                  ,[Cust_Code] AS [Customer]
//		                                  ,[Received_Date] AS [Received Date]
//		                                  ,0 AS [Money_TransactionType_ID]
//		                                  ,[Payment_Media] AS [Payment Method]
//		                                  ,[Deposit_Withdraw] AS [Deposit/Withdraw]
//		                                  ,[Amount] AS [Amount]
//		                                  ,[Vouchar_SN] AS [Voucher No]
//		                                  ,[Trans_Reason] AS [Reason]
//		                                  ,0 AS [Intended_IPOSession_ID]
//		                                  ,'' AS [Intended_IPOSession_Name]
//		                                  ,'' AS [Company Name]
//                                          ,0 AS [IPO Amount]
//		                                  ,0 AS [IPO Premium]
//		                                  ,0 AS [IPO Charge]
//                                          ,'TRADEACC' AS [AccountName]    		
//	                                FROM [SBP_Database].[dbo].[SBP_Payment_Posting_Request]
//	                                WHERE [Payment_Media]='TRIPO' AND [Vouchar_SN] IN (
//						                                Select c.[Vouchar_SN] From #GroupByVoucher_PaymentPost as c
//	                                ) 
//	                                AND [Vouchar_SN] IN (
//						                                Select c.[Voucher_No] From #GroupByVoucher_IPOAcc as c
//	                                )
//                                    AND Entry_Branch_ID=" + GlobalVariableBO._branchId + @"
//                                    AND [Deposit_Withdraw]='" + Indication_PaymentMode.Deposit + @"' 
//                            ) AS T
//                            ORDER BY T.[Voucher No]
//                            ";
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

        public void Approved_Multi_Transfer_MoneyTransaction(string D_TransID)
        {
            SqlConnection conn = new SqlConnection(DbConnectionBasic.ConnectionString);
            CommonBAL comBal = new CommonBAL();
            DateTime TodayServerDate = comBal.GetCurrentServerDate();
            //string DTransID_JoinText = String.Join(",", D_TransID);
            //string WTransID_JoinText = string.Join(",", W_TransID);
            //string Concate_JoinText_ID = DTransID_JoinText + "," + WTransID_JoinText;



            string queryString_Update_CustomerBrokerMoneyTransaction = string.Empty;
            queryString_Update_CustomerBrokerMoneyTransaction =
                            @"UPDATE [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction]
                                SET [Approval_Status]=1
                                ,[Approval_Date]=GETDATE()
                                ,[Approval_By]='" + GlobalVariableBO._userName + @"'
                                ,[Updated_Date]=Convert(varchar(10),GETDATE(),111)
                                ,[Update_By]='" + GlobalVariableBO._userName + @"'
                             WHERE [ID] IN (" + D_TransID + @")
                             ";

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();
                _dbConnection.ExecuteNonQuery(queryString_Update_CustomerBrokerMoneyTransaction);
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

        public void Approved_Multi_Transfer_MoneyTransaction_UITransApplied(string D_TransID)
        {
            SqlConnection conn = new SqlConnection(DbConnectionBasic.ConnectionString);
            CommonBAL comBal = new CommonBAL();
            DateTime TodayServerDate = comBal.GetCurrentServerDate();
            //string DTransID_JoinText = String.Join(",", D_TransID);
            //string WTransID_JoinText = string.Join(",", W_TransID);
            //string Concate_JoinText_ID = DTransID_JoinText + "," + WTransID_JoinText;



            string queryString_Update_CustomerBrokerMoneyTransaction = string.Empty;
            queryString_Update_CustomerBrokerMoneyTransaction =
                            @"UPDATE [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction]
                                SET [Approval_Status]=1
                                ,[Approval_Date]=GETDATE()
                                ,[Approval_By]='" + GlobalVariableBO._userName + @"'
                                ,[Updated_Date]=Convert(varchar(10),GETDATE(),111)
                                ,[Update_By]='" + GlobalVariableBO._userName + @"'
                                WHERE [ID] IN (" + D_TransID + @")
                                ";

            try
            {
                //_dbConnection.ConnectDatabase();
                //_dbConnection.StartTransaction();
                _dbConnection.ExecuteNonQuery(queryString_Update_CustomerBrokerMoneyTransaction);
                ////_dbConnection.Commit();

            }
            catch (Exception)
            {
                //_dbConnection.Rollback();
                throw;
            }
            finally
            {
                //_dbConnection.CloseDatabase();
            }
        }
        
        public void GetDeposit_Apply_Together_Update(int transID, int applicationID)
        {
            DataTable dt = new DataTable();
            string query = "";
            query = "SBP_IPOUpdateDepositApplyTogether";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@TransId", SqlDbType.VarChar, Convert.ToString(transID));
                _dbConnection.AddParameter("@TransRefId", SqlDbType.VarChar, Convert.ToString(applicationID));
                _dbConnection.ExecuteProQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string[] GetCustListFromIPOTransactionIDs(string[] IDs)
        {
            DataTable dataTable;
            dataTable = null;
            string[] output = null;
            string JoinedIDs=String.Join(",",IDs);
            string queryString = "";
            queryString = @"SELECT Distinct t.Cust_Code
                            FROM SBP_IPO_Customer_Broker_MoneyTransaction as t
                            WHERE T.ID IN (" + JoinedIDs + ")";
            try
            {
                _dbConnection.ConnectDatabase();
                dataTable = _dbConnection.ExecuteProQuery(queryString);
                if (dataTable.Rows.Count > 0)
                    output = dataTable.Rows.Cast<DataRow>().Select(t=> Convert.ToString(t[0])).ToArray();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return output;
        
        }

        public DataTable GetDeposit_Apply_Together()
        {
            DataTable dataTable;
            dataTable = null;
            string queryString = "";
            queryString = "SBP_IPOMoneyDepositApplyTogther";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@Entry_Branch_ID", SqlDbType.Int, GlobalVariableBO._branchId);
                dataTable = _dbConnection.ExecuteProQuery(queryString);
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
        /// Modified By Rashed
        /// Add ASI
        /// </summary>
        /// <returns></returns>
        public DataTable GetIPOApplication_Pending_List()
        {
            DataTable dataTable;
            dataTable = null;
            string queryString = "";
            queryString = @"
                           SELECT app.[ID]
                                  ,app.[Cust_Code]
                                  ,app.[BO_ID]                                  
                                  ,app.[Serial_No]
                                   ,app.Remarks
                                   ,comp.Company_Short_Code
                                  ,app.[Applied_Company]
                                  ,app.[IPOSession_ID]
                                  ,app.[IPOSession_Name]
                                  ,app.[No_Of_Share]
                                  ,app.[TotalAmount]
                                  ,t.[Premium]  AS Premium                                  
                                  ,app.[Application_Date]
                                  ,(Case 
										When app.ChannelType='SMS' Then ChannelType 
										When app.ChannelType='Email' Then ChannelType
										When app.ChannelType='Web' Then ChannelType
										Else 'Non Electronic' 
										END
									) As Application_Type          
                            FROM [SBP_Database].[dbo].[SBP_IPO_Application_BasicInfo] as app
                            inner join [SBP_IPO_Session] AS t
                            on app.IPOSession_Id=t.ID
                            inner join SBP_IPO_Company_Info as comp
                            on
                            comp.Id=t.IPO_Company_ID
                            Inner Join SBP_IPO_Application_ExtendedInfo As ext
                            On ext.BasicInfo_ID=app.ID
                            WHERE app.[Application_Satus]=0 
                            AND ext.Applicant_Category in ('RB','ASI') --ASI ADDED
                            AND ISNULL(Money_Trans_Ref_ID,0)=0
                            AND Money_Trans_Ref_ID =0
                            And app.Serial_No is not null
                            AND app.Entry_Branch_ID=" + GlobalVariableBO._branchId + "";
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


//        /// <summary>
//        /// Modified By Rashed
//        /// </summary>
//        /// <returns></returns>
//        public DataTable GetIPOApplication_Pending_List()
//        {
//            DataTable dataTable;
//            dataTable = null;
//            string queryString = "";
//            queryString = @"
//                           SELECT app.[ID]
//                                  ,app.[Cust_Code]
//                                  ,app.[BO_ID]                                  
//                                  ,app.[Serial_No]
//                                   ,app.Remarks
//                                   ,comp.Company_Short_Code
//                                  ,app.[Applied_Company]
//                                  ,app.[IPOSession_ID]
//                                  ,app.[IPOSession_Name]
//                                  ,app.[No_Of_Share]
//                                  ,app.[TotalAmount]
//                                  ,t.[Premium]  AS Premium                                  
//                                  ,app.[Application_Date]
//                                  ,(Case 
//										When app.ChannelType='SMS' Then ChannelType 
//										When app.ChannelType='Email' Then ChannelType
//										When app.ChannelType='Web' Then ChannelType
//										Else 'Non Electronic' 
//										END
//									) As Application_Type          
//                            FROM [SBP_Database].[dbo].[SBP_IPO_Application_BasicInfo] as app
//                            inner join [SBP_IPO_Session] AS t
//                            on app.IPOSession_Id=t.ID
//                            inner join SBP_IPO_Company_Info as comp
//                            on
//                            comp.Id=t.IPO_Company_ID
//                            Inner Join SBP_IPO_Application_ExtendedInfo As ext
//                            On ext.BasicInfo_ID=app.ID
//                            WHERE app.[Application_Satus]=0 
//                            AND ext.Applicant_Category='RB'
//                            AND ISNULL(Money_Trans_Ref_ID,0)=0
//                            AND Money_Trans_Ref_ID =0
//                            And app.Serial_No is not null
//                            AND app.Entry_Branch_ID=" + GlobalVariableBO._branchId+"";
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

////Old Version
//        public DataTable GetIPOApplication_Pending_List()
//        {
//            DataTable dataTable;
//            dataTable = null;
//            string queryString = "";
//            queryString = @"
//                           SELECT app.[ID]
//                                  ,app.[Cust_Code]
//                                  ,app.[BO_ID]                                  
//                                  ,app.[Serial_No]
//                                    ,app.Remarks
//                                   ,comp.Company_Short_Code
//                                  ,app.[Applied_Company]
//                                  ,app.[IPOSession_ID]
//                                  ,app.[IPOSession_Name]
//                                  ,app.[No_Of_Share]
//                                  ,app.[TotalAmount]
//                                  ,t.[Premium]  AS Premium                                  
//                                  ,app.[Application_Date]
//                                  ,(Case When app.ChannelType='SMS' Then ChannelType Else 'Non Electronic' END) As Application_Type          
//                            FROM [SBP_Database].[dbo].[SBP_IPO_Application_BasicInfo] as app
//                            inner join [SBP_IPO_Session] AS t
//                            on app.IPOSession_Id=t.ID
//                            inner join SBP_IPO_Company_Info as comp
//                            on
//                            comp.Id=t.IPO_Company_ID
//                            WHERE app.[Application_Satus]=0 
//                            AND ISNULL(Money_Trans_Ref_ID,0)=0
//                            AND Money_Trans_Ref_ID =0
//                            And app.Serial_No is not null
//                            AND app.Entry_Branch_ID=" + GlobalVariableBO._branchId+"";
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

//        public double GetIPOCustomerBalance_FroAppApproval_UITransApplied(string cust_Code)
//        {
//            DataTable dataTable;
//            double result = 0.00;
//            dataTable = null;
//            string queryString = "";
//            queryString = @"SELECT
//	                        (	Select c.Cust_Name
//		                        From SBP_Cust_Personal_Info as c
//		                        Where c.Cust_Code= cust.Cust_Code
//	                        )AS Cust_Name
//	                        ,
//                            ISNULL(SUM(ipoBal.Deposit)-SUM(ipoBal.Withdraw),0) AS Balance
//	                        FROM(
//			                        SELECT [ID]
//			                          ,[Cust_Code]
//			                          ,[Money_TransactionType_ID]
//			                          ,[Money_TransactionType_Name]
//			                          ,(
//					                        CASE 
//						                        WHEN [Deposit_Withdraw]='Deposit' THEN [Amount]
//						                        ELSE 0.00
//					                        END
//			                           ) Deposit
//			                          ,(
//					                        CASE 
//						                        WHEN [Deposit_Withdraw]='Withdraw' THEN [Amount]
//						                        ELSE 0.00
//					                        END
//			                           )AS Withdraw
//			                          ,[Amount]
//			                          ,[Voucher_No]
//			                          ,[Trans_Reason]
//			                          ,[Intended_IPOSession_ID]
//			                          ,[Intended_IPOSession_Name]
//			                          ,[Approval_Status]
//			                          ,[Approval_Date]
//			                          ,[Approval_By]
//			                          ,[Entry_Date]
//			                          ,[Entry_By]
//			                          ,[Updated_Date]
//			                          ,[Update_By]
//		                          FROM [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction]
//		                          WHERE 
//                                    ( [Approval_Status]=1 AND [Money_TransactionType_Name]<>'Cheque' )
//                                    OR
//                                    ( [Approval_Status]=1 AND Clearing_Status=1 AND [Money_TransactionType_Name]='"+Indication_IPOPaymentTransaction.Cheque+@"' )
//	                        ) AS ipoBal
//	                        RIGHT OUTER JOIN
//	                        SBP_Customers as cust
//	                        ON
//	                        ipoBal.Cust_Code=cust.Cust_Code
//	                        WHERE cust.Cust_Code='" + cust_Code + @"'
//	                        GROUP BY cust.Cust_Code";
//            try
//            {
//                //_dbConnection.ConnectDatabase();
//                dataTable = _dbConnection.ExecuteQuery(queryString,_dbConnection.GetTransaction());
//                if (dataTable.Rows.Count > 0)
//                    result = Convert.ToDouble(dataTable.Rows[0]["Balance"].ToString());
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//            //finally
//            //{
//            //    _dbConnection.CloseDatabase();
//            //}
//            return result;
//        }

        public void Approved_Single_NonTransfer_MoneyTransaction(int TransID_IPOACC, string ApprovedBy)
        {
            SqlConnection conn = new SqlConnection(DbConnectionBasic.ConnectionString);
            CommonBAL comBal = new CommonBAL();

            DateTime TodayServerDate = comBal.GetCurrentServerDate();
            string queryString_IPOACC = "";
            queryString_IPOACC = @"UPDATE [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction]
                          SET [Approval_Status]=1
                          ,[Approval_Date]=GETDATE()
                          ,[Approval_By]='" + ApprovedBy + @"'
                          ,[Updated_Date]=Convert(varchar(10),GETDATE(),111)
                          ,[Update_By]='" + ApprovedBy + @"'
                          WHERE [ID]=" + TransID_IPOACC + "";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();
                _dbConnection.ExecuteNonQuery(queryString_IPOACC);
                _dbConnection.Commit();
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

        public void Approved_Single_NonTransfer_MoneyTransaction_UITransApplied(int TransID_IPOACC, string ApprovedBy)
        {
            SqlConnection conn = new SqlConnection(DbConnectionBasic.ConnectionString);
            CommonBAL comBal = new CommonBAL();

            DateTime TodayServerDate = comBal.GetCurrentServerDate();
            string queryString_IPOACC = "";
            queryString_IPOACC = @"UPDATE [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction]
                          SET [Approval_Status]=1
                          ,[Approval_Date]=GETDATE()
                          ,[Approval_By]='" + ApprovedBy + @"'
                          ,[Updated_Date]=Convert(varchar(10),GETDATE(),111)
                          ,[Update_By]='" + ApprovedBy + @"'
                          WHERE [ID]=" + TransID_IPOACC + "";

          

            try
            {
                //_dbConnection.ConnectDatabase();
                //_dbConnection.StartTransaction();
                _dbConnection.ExecuteNonQuery(queryString_IPOACC);              
                //_dbConnection.Commit();
            }
            catch (Exception)
            {
                throw;
            }
            //finally
            //{
            //    _dbConnection.CloseDatabase();
            //}
        }

        public void ChequeClear_MoneyTransaction_UITransApplied(int Trans_ID, string ApprovedBy)
        {
            SqlConnection conn = new SqlConnection(DbConnectionBasic.ConnectionString);
            CommonBAL comBal = new CommonBAL();

            DateTime TodayServerDate = comBal.GetCurrentServerDate();
            string queryString = "";
            queryString = @"UPDATE [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction]
                          SET [Clearing_Status]=1
                          ,[Approval_Date]=GETDATE()
                          ,[Approval_By]='" + ApprovedBy + @"'
                          ,[Updated_Date]=Convert(varchar(10),GETDATE(),111)
                          ,[Update_By]='" + ApprovedBy + @"'
                          WHERE [ID]=" + Trans_ID + "";

            try
            {
                //_dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(queryString);

            }
            catch (Exception)
            {
                throw;
            }
            //finally
            //{
            //    _dbConnection.CloseDatabase();
            //}
        }

        public void ChequeUnClear_MoneyTransaction_UITransApplied(int Trans_ID, string ApprovedBy)
        {
            string queryString = "";
            queryString = @"UPDATE [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction]
                          SET 
                           [Clearing_Status]=2
                          ,[Approval_Date]=GETDATE()
                          ,[Approval_By]='" + ApprovedBy + @"'
                          ,[Updated_Date]=Convert(varchar(10),GETDATE(),111)
                          ,[Update_By]='" + ApprovedBy + @"'
                          WHERE [ID]=" + Trans_ID + "";

            try
            {
                //_dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(queryString);

            }
            catch (Exception)
            {
                throw;
            }
            //finally
            //{
            //    _dbConnection.CloseDatabase();
            //}
        }       

        public void GetUpdateCleraUncleraInfo(int TransId, string approved)
        {
            IPOApprovalBAL bal = new IPOApprovalBAL();
            DataTable dt = new DataTable();
            string query = @"SBP_IPOUpdateIPOChequeClearUnClearInfo";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@TRANSACTIONID", SqlDbType.Int, TransId);
                _dbConnection.AddParameter("@ApprovebBy", SqlDbType.VarChar, approved);
                _dbConnection.ExecuteProQuery(query);
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
       
        public void Rejected_Single_NonTransfer_MoneyTransaction(int Trans_ID, string ApprovedBy, string RejectionReason)
        {
            SqlConnection conn = new SqlConnection(DbConnectionBasic.ConnectionString);
            CommonBAL comBal = new CommonBAL();

            DateTime TodayServerDate = comBal.GetCurrentServerDate();
            string queryString = "";
            queryString = @"UPDATE [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction]
                          SET [Approval_Status]=2
                          
                          ,[Approval_Date]=GETDATE()
                          ,[Approval_By]='" + ApprovedBy + @"'
                          ,[Rejected_Reason]='" + RejectionReason + @"'
                          ,[Updated_Date]=Convert(varchar(10),GETDATE(),111)
                          ,[Update_By]='" + ApprovedBy + @"'
                          WHERE [ID]=" + Trans_ID + "";

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(queryString);

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

        public void Approved_Mulitple_NonTransfer_MoneyTransaction(string[] Trans_ID_IPOACC,string ApprovedBy)
        {
            SqlConnection conn = new SqlConnection(DbConnectionBasic.ConnectionString);
            CommonBAL comBal = new CommonBAL();

            string query_TransID_IPOACC = (Trans_ID_IPOACC.Length>0?String.Join(",", Trans_ID_IPOACC):"0");
            
            DateTime TodayServerDate = comBal.GetCurrentServerDate();
            string queryString_IPOACC = "";
         

            queryString_IPOACC = @"UPDATE [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction]
                          SET [Approval_Status]=1
                          ,[Approval_Date]=GETDATE()
                          ,[Approval_By]=" + ApprovedBy + @"
                          ,[Updated_Date]=Convert(varchar(10),GETDATE(),111)
                          ,[Update_By]=" + ApprovedBy + @"
                          WHERE [ID] IN (" + Trans_ID_IPOACC + ")";
          
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();
                _dbConnection.ExecuteNonQuery(queryString_IPOACC);
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

        public void Approved_Mulitple_NonTransfer_MoneyTransaction_UITrasnApplied(string[] Trans_ID_IPOACC, string ApprovedBy)
        {
            SqlConnection conn = new SqlConnection(DbConnectionBasic.ConnectionString);
            CommonBAL comBal = new CommonBAL();

            string query_TransID_IPOACC =(Trans_ID_IPOACC.Length>0?String.Join(",", Trans_ID_IPOACC):"0");
          
            DateTime TodayServerDate = comBal.GetCurrentServerDate();
            string queryString_IPOACC = "";

            queryString_IPOACC = @"UPDATE [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction]
                          SET [Approval_Status]=1
                          ,[Approval_Date]=GETDATE()
                          ,[Approval_By]=" + ApprovedBy + @"
                          ,[Updated_Date]=Convert(varchar(10),GETDATE(),111)
                          ,[Update_By]=" + ApprovedBy + @"
                          WHERE [ID] IN (" + Trans_ID_IPOACC + ")";

            try
            {
                //_dbConnection.ConnectDatabase();
                //_dbConnection.StartTransaction();
                _dbConnection.ExecuteNonQuery(queryString_IPOACC);              
                //_dbConnection.Commit();

            }
            catch (Exception)
            {
                //_dbConnection.Rollback();
                throw;
            }
            finally
            {
                //_dbConnection.CloseDatabase();
            }
        }

        public void Rejected_Multiple_NonTransfer_MoneyTransaction(string[] Trans_ID, string ApprovedBy, string RejectionReason)
        {
            SqlConnection conn = new SqlConnection(DbConnectionBasic.ConnectionString);
            CommonBAL comBal = new CommonBAL();

            string query_TransID = (Trans_ID.Length>0?String.Join(",", Trans_ID):"0");
            DateTime TodayServerDate = comBal.GetCurrentServerDate();
            string queryString = "";
            queryString = @"UPDATE [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction]
                          SET [Approval_Status]=2
                          ,[Approval_Date]=GETDATE()
                          ,[Approval_By]='" + ApprovedBy + @"'
                          ,[Rejected_Reason]='" + RejectionReason + @"'
                          ,[Updated_Date]=Convert(varchar(10),GETDATE(),111)
                          ,[Update_By]='" + ApprovedBy + @"'
                          WHERE [ID] IN (" + query_TransID + ")";

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(queryString);

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

//        public void Approved_Single_Transfer_MoneyTransaction_And_Application(int TA_PaymentPosting_ID, int IPA_TransID, int AppID)
//        {
//            SqlConnection conn = new SqlConnection(DbConnectionBasic.ConnectionString);
//            CommonBAL comBal = new CommonBAL();

//            DateTime TodayServerDate = comBal.GetCurrentServerDate();

//            string queryString_UpdatePaymentPosting = string.Empty;
//            queryString_UpdatePaymentPosting = @"UPDATE [SBP_Database].[dbo].[SBP_Payment_Posting_Request]
//                            SET [Approval_Status]=1
//                            ,[Payment_Approved_By]='" + GlobalVariableBO._userName + @"'
//                            ,[Payment_Approved_Date]=GETDATE()
//                            WHERE [Payment_ID]=" + TA_PaymentPosting_ID + @"
//                            ";

//            string queryString_InsertPayment = string.Empty;
//            queryString_InsertPayment = @"INSERT INTO [SBP_Database].[dbo].[SBP_Payment]
//                                        (
//	                                        [Cust_Code]
//	                                        ,[Amount]
//	                                        ,[Received_Date]
//	                                        ,[Payment_Media]
//	                                        ,[Payment_Media_No]
//	                                        ,[Payment_Media_Date]
//	                                        ,[Bank_ID]
//	                                        ,[Bank_Name]
//	                                        ,[Branch_ID]
//	                                        ,[Bank_Branch]
//	                                        ,[Received_By]
//	                                        ,[Deposit_Withdraw]
//	                                        ,[Payment_Approved_By]
//	                                        ,[Payment_Approved_Date]
//	                                        ,[Voucher_Sl_No]
//	                                        ,[Trans_Reason]
//	                                        ,[Remarks]
//	                                        ,[Entry_Date]
//	                                        ,[Entry_By]
//	                                        ,[Maturity_Days]
//	                                        ,[Requisition_ID]
//	                                        ,[Entry_Branch_ID]
//                                        )
//                                        SELECT 
//                                              [Cust_Code]
//                                              ,[Amount]
//                                              ,[Received_Date]
//                                              ,[Payment_Media]
//                                              ,[Payment_Media_No]
//                                              ,[Payment_Media_Date]
//                                              ,[Bank_ID]
//                                              ,[Bank_Name]
//                                              ,[Branch_ID]
//                                              ,[Bank_Branch]
//                                              ,[Received_By]
//                                              ,[Deposit_Withdraw]
//                                              ,[Payment_Approved_By]
//                                              ,[Payment_Approved_Date]
//                                              ,[Vouchar_SN]
//                                              ,[Trans_Reason]
//                                              ,[Remarks]
//                                              ,[Entry_Date]
//                                              ,[Entry_By]
//                                              ,[Maturity_Days]
//                                              ,[Payment_ID]
//                                              ,[Entry_Branch_ID]
//                                        FROM [SBP_Database].[dbo].[SBP_Payment_Posting_Request]
//                                        WHERE [Payment_ID]=" + TA_PaymentPosting_ID + @"
//                                    ";

//            string queryString_Update_CustomerBrokerMoneyTransaction = string.Empty;
//            queryString_Update_CustomerBrokerMoneyTransaction =
//                                        @"UPDATE [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction]
//                                            SET [Approval_Status]=1
//                                          ,[Approval_Date]=GETDATE()
//                                          ,[Approval_By]='" + GlobalVariableBO._userName + @"'
//                                          ,[Updated_Date]=Convert(varchar(10),GETDATE(),111)
//                                          ,[Update_By]='" + GlobalVariableBO._userName + @"'
//                                          WHERE [ID] =" + IPA_TransID + "";
//            string approveApplication = "";
//            approveApplication = @"UPDATE [SBP_IPO_Application_BasicInfo]
//                            SET [Application_Satus]=1
//                            ,[AppStatus_UpdatedBy]='" + GlobalVariableBO._userName + @"'
//                            ,[AppStatus_UpdatedDate]=GETDATE()
//                            ,[Updated_Date]=Convert(Varchar(10),GETDATE(),111)
//                            ,[Update_By]='admin'
//                            WHERE [ID]=" + AppID + "";

//            try
//            {
//                _dbConnection.ConnectDatabase();
//                _dbConnection.StartTransaction();
//                _dbConnection.ExecuteNonQuery(queryString_UpdatePaymentPosting);
//                _dbConnection.ExecuteNonQuery(queryString_InsertPayment);
//                _dbConnection.ExecuteNonQuery(queryString_Update_CustomerBrokerMoneyTransaction);
//                _dbConnection.ExecuteNonQuery(approveApplication);
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

        public void Approved_Single_Transfer_MoneyTransaction(int TA_PaymentPosting_ID, int IPA_TransID)
        {
            SqlConnection conn = new SqlConnection(DbConnectionBasic.ConnectionString);
            CommonBAL comBal = new CommonBAL();

            DateTime TodayServerDate = comBal.GetCurrentServerDate();
            
            bool isUpdated = false;
            string queryString_CheckIf = string.Empty;
            queryString_CheckIf =
                            @"
                            DECLARE @IsUpdated bit

                            IF 
                                EXISTS (SELECT * FROM SBP_Payment_Posting_Request WHERE [Approval_Status]=1 AND [Payment_ID]=" + TA_PaymentPosting_ID + @")
                                OR
                                EXISTS (SELECT * FROM SBP_IPO_Customer_Broker_MoneyTransaction WHERE [Approval_Status]=1 AND [ID] =" + IPA_TransID + @")

                            BEGIN                                                                                                                                    
                                SET @IsUpdated=1
                            END
                            ELSE 
                            BEGIN
                                SET @IsUpdated=0
                            END
                            SELECT @IsUpdated                    
           ";
            string queryString_UpdatePaymentPosting =string.Empty;
            queryString_UpdatePaymentPosting = @"UPDATE [SBP_Database].[dbo].[SBP_Payment_Posting_Request]
                            SET [Approval_Status]=1
                            ,[Payment_Approved_By]='"+GlobalVariableBO._userName+@"'
                            ,[Payment_Approved_Date]=GETDATE()
                            WHERE [Payment_ID]=" + TA_PaymentPosting_ID + @"
                            ";

            string queryString_InsertPayment = string.Empty;
            queryString_InsertPayment = @"INSERT INTO [SBP_Database].[dbo].[SBP_Payment]
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
                                              ,[Vouchar_SN]
                                              ,[Trans_Reason]
                                              ,[Remarks]
                                              ,[Entry_Date]
                                              ,[Entry_By]
                                              ,[Maturity_Days]
                                              ,[Payment_ID]
                                              ,[Entry_Branch_ID]
                                        FROM [SBP_Database].[dbo].[SBP_Payment_Posting_Request]
                                        WHERE [Payment_ID]=" + TA_PaymentPosting_ID + @"
                                    ";

            /**************************Added BY Md.Rashedul Hasan 0n 05 Feb-2015**************************/

            string queryString_Insert_Money_Balance_Temp = string.Empty;
            queryString_Insert_Money_Balance_Temp =
                            @"INSERT INTO [SBP_Database].[dbo].[SBP_Money_Balance_Temp]
                            (
	                              [Cust_Code]
                                  ,[Sell_Deposit]
                                  ,[Buy_Withdraw]
                                  ,[Balance]
                                  ,[Matured_Balance]
                                  ,[Remarks]
                                  ,[Rec_Date]
                            )
                             SELECT
                                  [Cust_Code]
                                  ,( CASE WHEN [Deposit_Withdraw]='Deposit' THEN [Amount] ELSE 0.00 END ) AS Sell_Deposit
                                  ,( CASE WHEN [Deposit_Withdraw]='Withdraw' THEN [Amount] ELSE 0.00 END ) AS Buy_Withdraw  
                                  ,( CASE WHEN [Deposit_Withdraw]='Deposit' THEN [Amount]
                                          WHEN [Deposit_Withdraw]='Withdraw' THEN -1*[Amount] 
                                      END
                                    ) AS Balance
                                  ,( CASE WHEN [Deposit_Withdraw]='Deposit' THEN [Amount]
                                          WHEN [Deposit_Withdraw]='Withdraw' THEN -1*[Amount] 
                                      END
                                    ) AS Matured_Balance
                                  ,[Payment_Media] AS Remarks  
                                  ,[Received_Date] AS Rec_Date
                            FROM [SBP_Database].[dbo].[SBP_Payment_Posting_Request]
                            WHERE [Payment_ID] = " + TA_PaymentPosting_ID + " ";

            /*************************************************************************************************/

            string queryString_Update_CustomerBrokerMoneyTransaction = string.Empty;
            queryString_Update_CustomerBrokerMoneyTransaction = 
                                        @"UPDATE [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction]
                                            SET [Approval_Status]=1
                                          ,[Approval_Date]=GETDATE()
                                          ,[Approval_By]='"+GlobalVariableBO._userName+@"'
                                          ,[Updated_Date]=Convert(varchar(10),GETDATE(),111)
                                          ,[Update_By]='"+GlobalVariableBO._userName+@"'
                                          WHERE [ID] =" + IPA_TransID + "";
             

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();
                
                DataTable dt = _dbConnection.ExecuteQuery(queryString_CheckIf);
                if (dt.Rows.Count > 0)
                    isUpdated = Convert.ToBoolean(dt.Rows[0][0].ToString());
                if (isUpdated)
                    throw new Exception("Already Approved!!");
                
                _dbConnection.ExecuteNonQuery(queryString_UpdatePaymentPosting);
                _dbConnection.ExecuteNonQuery(queryString_InsertPayment);
                _dbConnection.ExecuteNonQuery(queryString_Insert_Money_Balance_Temp);
                _dbConnection.ExecuteNonQuery(queryString_Update_CustomerBrokerMoneyTransaction);
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

        //Previous Version Before Money Balance Insert

//        public void Approved_Single_Transfer_MoneyTransaction_UITransApplied(int TA_PaymentPosting_ID, int IPA_TransID)
//        {
//            SqlConnection conn = new SqlConnection(DbConnectionBasic.ConnectionString);
//            CommonBAL comBal = new CommonBAL();

//            DateTime TodayServerDate = comBal.GetCurrentServerDate();           
//            string queryString_UpdatePaymentPosting = string.Empty;
//            queryString_UpdatePaymentPosting = @"UPDATE [SBP_Database].[dbo].[SBP_Payment_Posting_Request]
//                            SET [Approval_Status]=1
//                            ,[Payment_Approved_By]='" + GlobalVariableBO._userName + @"'
//                            ,[Payment_Approved_Date]=GETDATE()
//                            WHERE [Payment_ID]=" + TA_PaymentPosting_ID + @"
//                            ";

//            string queryString_InsertPayment = string.Empty;
//            queryString_InsertPayment = @"INSERT INTO [SBP_Database].[dbo].[SBP_Payment]
//                                        (
//	                                        [Cust_Code]
//	                                        ,[Amount]
//	                                        ,[Received_Date]
//	                                        ,[Payment_Media]
//	                                        ,[Payment_Media_No]
//	                                        ,[Payment_Media_Date]
//	                                        ,[Bank_ID]
//	                                        ,[Bank_Name]
//	                                        ,[Branch_ID]
//	                                        ,[Bank_Branch]
//	                                        ,[Received_By]
//	                                        ,[Deposit_Withdraw]
//	                                        ,[Payment_Approved_By]
//	                                        ,[Payment_Approved_Date]
//	                                        ,[Voucher_Sl_No]
//	                                        ,[Trans_Reason]
//	                                        ,[Remarks]
//	                                        ,[Entry_Date]
//	                                        ,[Entry_By]
//	                                        ,[Maturity_Days]
//	                                        ,[Requisition_ID]
//	                                        ,[Entry_Branch_ID]
//                                        )
//                                        SELECT 
//                                              [Cust_Code]
//                                              ,[Amount]
//                                              ,[Received_Date]
//                                              ,[Payment_Media]
//                                              ,[Payment_Media_No]
//                                              ,[Payment_Media_Date]
//                                              ,[Bank_ID]
//                                              ,[Bank_Name]
//                                              ,[Branch_ID]
//                                              ,[Bank_Branch]
//                                              ,[Received_By]
//                                              ,[Deposit_Withdraw]
//                                              ,[Payment_Approved_By]
//                                              ,[Payment_Approved_Date]
//                                              ,[Vouchar_SN]
//                                              ,[Trans_Reason]
//                                              ,[Remarks]
//                                              ,[Entry_Date]
//                                              ,[Entry_By]
//                                              ,[Maturity_Days]
//                                              ,[Payment_ID]
//                                              ,[Entry_Branch_ID]
//                                        FROM [SBP_Database].[dbo].[SBP_Payment_Posting_Request]
//                                        WHERE [Payment_ID]=" + TA_PaymentPosting_ID + @"
//                                    ";

//            string queryString_Update_CustomerBrokerMoneyTransaction = string.Empty;
//            queryString_Update_CustomerBrokerMoneyTransaction =
//                                        @"UPDATE [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction]
//                                            SET [Approval_Status]=1
//                                          ,[Approval_Date]=GETDATE()
//                                          ,[Approval_By]='" + GlobalVariableBO._userName + @"'
//                                          ,[Updated_Date]=Convert(varchar(10),GETDATE(),111)
//                                          ,[Update_By]='" + GlobalVariableBO._userName + @"'
//                                          WHERE [ID] =" + IPA_TransID + "";

//            try
//            {
//                //_dbConnection.ConnectDatabase();
//                //_dbConnection.StartTransaction();
//                _dbConnection.ActiveCommandText();
//                    _dbConnection.ExecuteNonQuery(queryString_UpdatePaymentPosting);
//                    _dbConnection.ExecuteNonQuery(queryString_InsertPayment);
//                    _dbConnection.ExecuteNonQuery(queryString_Update_CustomerBrokerMoneyTransaction);
                 
//                //_dbConnection.Commit();

//            }
//            catch (Exception)
//            {
//                //_dbConnection.Rollback();
//                throw;
//            }
//            //finally
//            //{
//            //    _dbConnection.CloseDatabase();
//            //}
//        }

        public void Approved_Single_Transfer_MoneyTransaction_UITransApplied(string TA_PaymentPosting_ID, string IPA_TransID)
        {
            SqlConnection conn = new SqlConnection(DbConnectionBasic.ConnectionString);
            CommonBAL comBal = new CommonBAL();

            bool isUpdated = false;
            string queryString_CheckIf = string.Empty;
            queryString_CheckIf =
                            @"
                            DECLARE @IsUpdated bit

                            IF 
                                EXISTS (SELECT * FROM SBP_Payment_Posting_Request WHERE [Approval_Status]=1 AND [Payment_ID]=" + TA_PaymentPosting_ID + @")
                                OR
                                EXISTS (SELECT * FROM SBP_IPO_Customer_Broker_MoneyTransaction WHERE [Approval_Status]=1 AND [ID] =" + IPA_TransID + @")

                            BEGIN                                                                                                                                    
                                SET @IsUpdated=1
                            END
                            ELSE 
                            BEGIN
                                SET @IsUpdated=0
                            END
                            SELECT @IsUpdated                    
           ";

            
            DateTime TodayServerDate = comBal.GetCurrentServerDate();
            string queryString_UpdatePaymentPosting = string.Empty;
            queryString_UpdatePaymentPosting = 
                            @"UPDATE [SBP_Database].[dbo].[SBP_Payment_Posting_Request]
                            SET [Approval_Status]=1
                            ,[Payment_Approved_By]='" + GlobalVariableBO._userName + @"'
                            ,[Payment_Approved_Date]=GETDATE()
                            WHERE [Payment_ID]=" + TA_PaymentPosting_ID + @"
                            ";

            string queryString_InsertPayment = string.Empty;
            queryString_InsertPayment = 
                            @"INSERT INTO [SBP_Database].[dbo].[SBP_Payment]
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
                                  ,[Vouchar_SN]
                                  ,[Trans_Reason]
                                  ,[Remarks]
                                  ,[Entry_Date]
                                  ,[Entry_By]
                                  ,[Maturity_Days]
                                  ,[Payment_ID]
                                  ,[Entry_Branch_ID]
                            FROM [SBP_Database].[dbo].[SBP_Payment_Posting_Request]
                            WHERE [Payment_ID]=" + TA_PaymentPosting_ID + @"
                           ";

            string queryString_Insert_Money_Balance_Temp = string.Empty;
            queryString_Insert_Money_Balance_Temp =
                            @"INSERT INTO [SBP_Database].[dbo].[SBP_Money_Balance_Temp]
                            (
	                              [Cust_Code]
                                  ,[Sell_Deposit]
                                  ,[Buy_Withdraw]
                                  ,[Balance]
                                  ,[Matured_Balance]
                                  ,[Remarks]
                                  ,[Rec_Date]
                            )
                             SELECT
                                  [Cust_Code]
                                  ,( CASE WHEN [Deposit_Withdraw]='Deposit' THEN [Amount] ELSE 0.00 END ) AS Sell_Deposit
                                  ,( CASE WHEN [Deposit_Withdraw]='Withdraw' THEN [Amount] ELSE 0.00 END ) AS Buy_Withdraw  
                                  ,( CASE WHEN [Deposit_Withdraw]='Deposit' THEN [Amount]
                                          WHEN [Deposit_Withdraw]='Withdraw' THEN -1*[Amount] 
                                      END
                                    ) AS Balance
                                  ,( CASE WHEN [Deposit_Withdraw]='Deposit' THEN [Amount]
                                          WHEN [Deposit_Withdraw]='Withdraw' THEN -1*[Amount] 
                                      END
                                    ) AS Matured_Balance
                                  ,[Payment_Media] AS Remarks  
                                  ,[Received_Date] AS Rec_Date
                            FROM [SBP_Database].[dbo].[SBP_Payment_Posting_Request]
                            WHERE [Payment_ID] = " + TA_PaymentPosting_ID + " ";

            string queryString_Update_CustomerBrokerMoneyTransaction = string.Empty;
            queryString_Update_CustomerBrokerMoneyTransaction =
                            @"UPDATE [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction]
                                SET [Approval_Status]=1
                              ,[Approval_Date]=GETDATE()
                              ,[Approval_By]='" + GlobalVariableBO._userName + @"'
                              ,[Updated_Date]=Convert(varchar(10),GETDATE(),111)
                              ,[Update_By]='" + GlobalVariableBO._userName + @"'
                              WHERE [ID] =" + IPA_TransID + "";

            try
            {
                //_dbConnection.ConnectDatabase();
                //_dbConnection.StartTransaction();
                _dbConnection.ActiveCommandText();
                
                DataTable dt=_dbConnection.ExecuteQuery(queryString_CheckIf);
                if (dt.Rows.Count > 0)
                    isUpdated = Convert.ToBoolean(dt.Rows[0][0].ToString());
                if (isUpdated)
                    throw new Exception("Already Approved!!");
                
                _dbConnection.ExecuteNonQuery(queryString_UpdatePaymentPosting);
                _dbConnection.ExecuteNonQuery(queryString_InsertPayment);
                _dbConnection.ExecuteNonQuery(queryString_Insert_Money_Balance_Temp);
                _dbConnection.ExecuteNonQuery(queryString_Update_CustomerBrokerMoneyTransaction);
                

                //_dbConnection.Commit();

            }
            catch (Exception)
            {
                //_dbConnection.Rollback();
                throw;
            }
            //finally
            //{
            //    _dbConnection.CloseDatabase();
            //}
        }

        public void Approved_Single_Transfer_MoneyTransaction_UITransApplied(string[] TransID_TransID)
        {
            SqlConnection conn = new SqlConnection(DbConnectionBasic.ConnectionString);
            CommonBAL comBal = new CommonBAL();
            DateTime TodayServerDate = comBal.GetCurrentServerDate();

            string IPA_TransID =(TransID_TransID.Length>0?string.Join(",", TransID_TransID):"0");
            
            string queryString_Update_CustomerBrokerMoneyTransaction = string.Empty;
            queryString_Update_CustomerBrokerMoneyTransaction =
                                        @"UPDATE [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction]
                                            SET [Approval_Status]=1
                                          ,[Approval_Date]=GETDATE()
                                          ,[Approval_By]='" + GlobalVariableBO._userName + @"'
                                          ,[Updated_Date]=Convert(varchar(10),GETDATE(),111)
                                          ,[Update_By]='" + GlobalVariableBO._userName + @"'
                                          WHERE [ID] in (" + (IPA_TransID!=string.Empty?IPA_TransID:"0" )+ @")";

            try
            {
                //_dbConnection.ConnectDatabase();
                //_dbConnection.StartTransaction();                
                _dbConnection.ExecuteNonQuery(queryString_Update_CustomerBrokerMoneyTransaction);

                //_dbConnection.Commit();

            }
            catch (Exception)
            {
                //_dbConnection.Rollback();
                throw;
            }
            //finally
            //{
            //    _dbConnection.CloseDatabase();
            //}
        }        

        public void Rejected_Single_Transfer_MoneyTransaction(int TA_PaymentPosting_ID, int IPA_TransID,string RejectionReason)
        {
            SqlConnection conn = new SqlConnection(DbConnectionBasic.ConnectionString);
            CommonBAL comBal = new CommonBAL();

            DateTime TodayServerDate = comBal.GetCurrentServerDate();

            string queryString_UpdatePaymentPosting = string.Empty;
            queryString_UpdatePaymentPosting = @"UPDATE [SBP_Database].[dbo].[SBP_Payment_Posting_Request]
                            SET [Approval_Status]=2
                            ,[Payment_Approved_By]='" + GlobalVariableBO._userName + @"'
                            ,[Payment_Approved_Date]=GETDATE()
                            ,[Rejection_Reason]='" + RejectionReason + @"'
                            WHERE [Payment_ID]=" + TA_PaymentPosting_ID + @"
                            ";

         

            string queryString_Update_CustomerBrokerMoneyTransaction = string.Empty;
            queryString_Update_CustomerBrokerMoneyTransaction =
                                        @"UPDATE [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction]
                                          SET [Approval_Status]=2
                                          ,[Approval_Date]=GETDATE()
                                          ,[Approval_By]='" + GlobalVariableBO._userName + @"'
                                          ,[Rejected_Reason]='"+RejectionReason+@"'  
                                          ,[Updated_Date]=Convert(varchar(10),GETDATE(),111)
                                          ,[Update_By]='" + GlobalVariableBO._userName + @"'
                                          WHERE [ID]=" + IPA_TransID + "";

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();
                _dbConnection.ExecuteNonQuery(queryString_UpdatePaymentPosting);
                _dbConnection.ExecuteNonQuery(queryString_Update_CustomerBrokerMoneyTransaction);
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

        public void Approved_Multi_Transfer_MoneyTransaction(string[] TA_PaymentPosting_ID, string[] IPA_TransID)
        {
            SqlConnection conn = new SqlConnection(DbConnectionBasic.ConnectionString);
            CommonBAL comBal = new CommonBAL();
            DateTime TodayServerDate = comBal.GetCurrentServerDate();

            string PaymentPostingID_JoinText = (TA_PaymentPosting_ID.Length>0?String.Join(",", TA_PaymentPosting_ID):"0");
            string IPATransID_JoinText =(IPA_TransID.Length>0?String.Join(",", IPA_TransID):"0");

            bool isUpdated = false;
            string queryString_CheckIf = string.Empty;
            queryString_CheckIf =
                            @"
                            DECLARE @IsUpdated bit

                            IF 
                                EXISTS (SELECT * FROM SBP_Payment_Posting_Request WHERE [Approval_Status]=1 AND [Payment_ID] IN (" + PaymentPostingID_JoinText + @"))
                                OR
                                EXISTS (SELECT * FROM SBP_IPO_Customer_Broker_MoneyTransaction WHERE [Approval_Status]=1 AND [ID] IN (" + IPATransID_JoinText + @"))

                            BEGIN                                                                                                                                    
                                SET @IsUpdated=1
                            END
                            ELSE 
                            BEGIN
                                SET @IsUpdated=0
                            END
                            SELECT @IsUpdated                    
            ";

            string queryString_UpdatePaymentPosting = string.Empty;
            queryString_UpdatePaymentPosting = @"UPDATE [SBP_Database].[dbo].[SBP_Payment_Posting_Request]
                            SET [Approval_Status]=1
                            ,[Payment_Approved_By]='" + GlobalVariableBO._userName + @"'
                            ,[Payment_Approved_Date]=GETDATE()
                            WHERE [Payment_ID] IN (" + PaymentPostingID_JoinText + @")
                            ";

            string queryString_Insert_CustomerBrokerMoneyTransaction = string.Empty;
            queryString_Insert_CustomerBrokerMoneyTransaction =
                            @"INSERT INTO [SBP_Database].[dbo].[SBP_Payment]
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
                                  ,[Vouchar_SN]
                                  ,[Trans_Reason]
                                  ,[Remarks]
                                  ,[Entry_Date]
                                  ,[Entry_By]
                                  ,[Maturity_Days]
                                  ,[Payment_ID]
                                  ,[Entry_Branch_ID]
                            FROM [SBP_Database].[dbo].[SBP_Payment_Posting_Request]
                            WHERE [Payment_ID] IN (" + PaymentPostingID_JoinText + ")";
            /**************************Added BY Md.Rashedul Hasan 0n 05 Feb-2015**************************/
            string queryString_Insert_Money_Balance_Temp = string.Empty;
            queryString_Insert_Money_Balance_Temp =
                            @"INSERT INTO [SBP_Database].[dbo].[SBP_Money_Balance_Temp]
                            (
	                              [Cust_Code]
                                  ,[Sell_Deposit]
                                  ,[Buy_Withdraw]
                                  ,[Balance]
                                  ,[Matured_Balance]
                                  ,[Remarks]
                                  ,[Rec_Date]
                            )
                             SELECT
                                  [Cust_Code]
                                  ,( CASE WHEN [Deposit_Withdraw]='Deposit' THEN [Amount] ELSE 0.00 END ) AS Sell_Deposit
                                  ,( CASE WHEN [Deposit_Withdraw]='Withdraw' THEN [Amount] ELSE 0.00 END ) AS Buy_Withdraw  
                                  ,( CASE WHEN [Deposit_Withdraw]='Deposit' THEN [Amount]
                                          WHEN [Deposit_Withdraw]='Withdraw' THEN -1*[Amount] 
                                      END
                                    ) AS Balance
                                  ,( CASE WHEN [Deposit_Withdraw]='Deposit' THEN [Amount]
                                          WHEN [Deposit_Withdraw]='Withdraw' THEN -1*[Amount] 
                                      END
                                    ) AS Matured_Balance
                                  ,[Payment_Media] AS Remarks  
                                  ,[Received_Date] AS Rec_Date
                            FROM [SBP_Database].[dbo].[SBP_Payment_Posting_Request]
                            WHERE [Payment_ID] = " + PaymentPostingID_JoinText + " ";
            /*-----------------------------------------------------------------------------*/
            string queryString_Update_CustomerBrokerMoneyTransaction = string.Empty;
            queryString_Update_CustomerBrokerMoneyTransaction =
                            @"UPDATE [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction]
                                SET [Approval_Status]=1
                                ,[Approval_Date]=GETDATE()
                                ,[Approval_By]='"+GlobalVariableBO._userName+@"'
                                ,[Updated_Date]=Convert(varchar(10),GETDATE(),111)
                                ,[Update_By]='"+GlobalVariableBO._userName+@"'
                                WHERE [ID] IN ("+IPATransID_JoinText+@")
                                ";

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();

                DataTable dt = _dbConnection.ExecuteQuery(queryString_CheckIf);
                if (dt.Rows.Count > 0)
                    isUpdated = Convert.ToBoolean(dt.Rows[0][0].ToString());
                if (isUpdated)
                    throw new Exception("Already Approved!!");

                _dbConnection.ExecuteNonQuery(queryString_UpdatePaymentPosting);
                _dbConnection.ExecuteNonQuery(queryString_Insert_CustomerBrokerMoneyTransaction);
                _dbConnection.ExecuteNonQuery(queryString_Insert_Money_Balance_Temp);
                _dbConnection.ExecuteNonQuery(queryString_Update_CustomerBrokerMoneyTransaction);
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

        //Previous Version Before Money Balance Entry

//        public void Approved_Multi_Transfer_MoneyTransaction_UITransApplied(string[] TA_PaymentPosting_ID, string[] IPA_TransID)
//        {
//            SqlConnection conn = new SqlConnection(DbConnectionBasic.ConnectionString);
//            CommonBAL comBal = new CommonBAL();
//            DateTime TodayServerDate = comBal.GetCurrentServerDate();

//            string PaymentPostingID_JoinText = String.Join(",", TA_PaymentPosting_ID);
//            string IPATransID_JoinText = String.Join(",", IPA_TransID);

//            string queryString_UpdatePaymentPosting = string.Empty;
//            queryString_UpdatePaymentPosting = @"UPDATE [SBP_Database].[dbo].[SBP_Payment_Posting_Request]
//                            SET [Approval_Status]=1
//                            ,[Payment_Approved_By]='" + GlobalVariableBO._userName + @"'
//                            ,[Payment_Approved_Date]=GETDATE()
//                            WHERE [Payment_ID] IN (" + PaymentPostingID_JoinText + @")
//                            ";

//            string queryString_Insert_CustomerBrokerMoneyTransaction = string.Empty;
//            queryString_Insert_CustomerBrokerMoneyTransaction =
//                            @"INSERT INTO [SBP_Database].[dbo].[SBP_Payment]
//                            (
//	                            [Cust_Code]
//	                            ,[Amount]
//	                            ,[Received_Date]
//	                            ,[Payment_Media]
//	                            ,[Payment_Media_No]
//	                            ,[Payment_Media_Date]
//	                            ,[Bank_ID]
//	                            ,[Bank_Name]
//	                            ,[Branch_ID]
//	                            ,[Bank_Branch]
//	                            ,[Received_By]
//	                            ,[Deposit_Withdraw]
//	                            ,[Payment_Approved_By]
//	                            ,[Payment_Approved_Date]
//	                            ,[Voucher_Sl_No]
//	                            ,[Trans_Reason]
//	                            ,[Remarks]
//	                            ,[Entry_Date]
//	                            ,[Entry_By]
//	                            ,[Maturity_Days]
//	                            ,[Requisition_ID]
//	                            ,[Entry_Branch_ID]
//                            )
//                            SELECT 
//                                  [Cust_Code]
//                                  ,[Amount]
//                                  ,[Received_Date]
//                                  ,[Payment_Media]
//                                  ,[Payment_Media_No]
//                                  ,[Payment_Media_Date]
//                                  ,[Bank_ID]
//                                  ,[Bank_Name]
//                                  ,[Branch_ID]
//                                  ,[Bank_Branch]
//                                  ,[Received_By]
//                                  ,[Deposit_Withdraw]
//                                  ,[Payment_Approved_By]
//                                  ,[Payment_Approved_Date]
//                                  ,[Vouchar_SN]
//                                  ,[Trans_Reason]
//                                  ,[Remarks]
//                                  ,[Entry_Date]
//                                  ,[Entry_By]
//                                  ,[Maturity_Days]
//                                  ,[Payment_ID]
//                                  ,[Entry_Branch_ID]
//                            FROM [SBP_Database].[dbo].[SBP_Payment_Posting_Request]
//                            WHERE [Payment_ID] IN (" + PaymentPostingID_JoinText + ")";

//            string queryString_Update_CustomerBrokerMoneyTransaction = string.Empty;
//            queryString_Update_CustomerBrokerMoneyTransaction =
//                            @"UPDATE [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction]
//                                SET [Approval_Status]=1
//                                ,[Approval_Date]=GETDATE()
//                                ,[Approval_By]='"+GlobalVariableBO._userName+@"'
//                                ,[Updated_Date]=Convert(varchar(10),GETDATE(),111)
//                                ,[Update_By]='" + GlobalVariableBO._userName + @"'
//                                WHERE [ID] IN (" + IPATransID_JoinText + @")
//                                ";
////            string UpdateApplication = "";
////            UpdateApplication = @"UPDATE [SBP_IPO_Application_BasicInfo]
////                            SET [Application_Satus]=1
////                            ,[AppStatus_UpdatedBy]='" + GlobalVariableBO._userName + @"'
////                            ,[AppStatus_UpdatedDate]=GETDATE()
////                            ,[Updated_Date]=Convert(Varchar(10),GETDATE(),111)
////                            ,[Update_By]='admin'
////                            WHERE [Money_Trans_Ref_ID]=" + IPATransID_JoinText + "";
//            try
//            {
//                //_dbConnection.ConnectDatabase();
//                //_dbConnection.StartTransaction();
//                _dbConnection.ActiveCommandText();
//                _dbConnection.ExecuteNonQuery(queryString_UpdatePaymentPosting);
//                _dbConnection.ExecuteNonQuery(queryString_Insert_CustomerBrokerMoneyTransaction);
//                _dbConnection.ExecuteNonQuery(queryString_Update_CustomerBrokerMoneyTransaction);
//               // _dbConnection.ExecuteNonQuery(UpdateApplication);
//                //_dbConnection.Commit();

//            }
//            catch (Exception)
//            {
//                //_dbConnection.Rollback();
//                throw;
//            }
//            //finally
//            //{
//            //    _dbConnection.CloseDatabase();
//            //}
//        }

        public void Approved_Multi_Transfer_MoneyTransaction_UITransApplied(string[] TA_PaymentPosting_ID, string[] IPA_TransID)
        {
            SqlConnection conn = new SqlConnection(DbConnectionBasic.ConnectionString);
            CommonBAL comBal = new CommonBAL();
            DateTime TodayServerDate = comBal.GetCurrentServerDate();

            string PaymentPostingID_JoinText =(TA_PaymentPosting_ID.Length>0? String.Join(",", TA_PaymentPosting_ID):"0");
            string IPATransID_JoinText =(IPA_TransID.Length>0? String.Join(",", IPA_TransID):"0");

            bool isUpdated = false;
            string queryString_CheckIf = string.Empty;
            queryString_CheckIf =
                            @"
                            DECLARE @IsUpdated bit

                            IF 
                                EXISTS (SELECT * FROM SBP_Payment_Posting_Request WHERE [Approval_Status]=1 AND [Payment_ID] IN (" + PaymentPostingID_JoinText + @"))
                                OR
                                EXISTS (SELECT * FROM SBP_IPO_Customer_Broker_MoneyTransaction WHERE [Approval_Status]=1 AND [ID] IN (" + IPATransID_JoinText + @"))

                            BEGIN                                                                                                                                    
                                SET @IsUpdated=1
                            END
                            ELSE 
                            BEGIN
                                SET @IsUpdated=0
                            END
                            SELECT @IsUpdated                    
            ";

            string queryString_UpdatePaymentPosting = string.Empty;
            queryString_UpdatePaymentPosting = @"UPDATE [SBP_Database].[dbo].[SBP_Payment_Posting_Request]
                            SET [Approval_Status]=1
                            ,[Payment_Approved_By]='" + GlobalVariableBO._userName + @"'
                            ,[Payment_Approved_Date]=GETDATE()
                            WHERE [Payment_ID] IN (" + PaymentPostingID_JoinText + @")
                            ";

            string queryString_Insert_CustomerBrokerMoneyTransaction = string.Empty;
            queryString_Insert_CustomerBrokerMoneyTransaction =
                            @"INSERT INTO [SBP_Database].[dbo].[SBP_Payment]
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
                                  ,[Vouchar_SN]
                                  ,[Trans_Reason]
                                  ,[Remarks]
                                  ,[Entry_Date]
                                  ,[Entry_By]
                                  ,[Maturity_Days]
                                  ,[Payment_ID]
                                  ,[Entry_Branch_ID]
                            FROM [SBP_Database].[dbo].[SBP_Payment_Posting_Request]
                            WHERE [Payment_ID] IN (" + PaymentPostingID_JoinText + ")";
            /************************Added By Md.Rashedul Hasan ON 10 - Feb - 2015***************/
            string queryString_Insert_Money_Balance_Temp = string.Empty;
            queryString_Insert_Money_Balance_Temp =
                            @"INSERT INTO [SBP_Database].[dbo].[SBP_Money_Balance_Temp]
                            (
	                              [Cust_Code]
                                  ,[Sell_Deposit]
                                  ,[Buy_Withdraw]
                                  ,[Balance]
                                  ,[Matured_Balance]
                                  ,[Remarks]
                                  ,[Rec_Date]
                            )
                             SELECT
                                  [Cust_Code]
                                  ,( CASE WHEN [Deposit_Withdraw]='Deposit' THEN [Amount] ELSE 0.00 END ) AS Sell_Deposit
                                  ,( CASE WHEN [Deposit_Withdraw]='Withdraw' THEN [Amount] ELSE 0.00 END ) AS Buy_Withdraw  
                                  ,( CASE WHEN [Deposit_Withdraw]='Deposit' THEN [Amount]
                                          WHEN [Deposit_Withdraw]='Withdraw' THEN -1*[Amount] 
                                      END
                                    ) AS Balance
                                  ,( CASE WHEN [Deposit_Withdraw]='Deposit' THEN [Amount]
                                          WHEN [Deposit_Withdraw]='Withdraw' THEN -1*[Amount] 
                                      END
                                    ) AS Matured_Balance
                                  ,[Payment_Media] AS Remarks  
                                  ,[Received_Date] AS Rec_Date
                            FROM [SBP_Database].[dbo].[SBP_Payment_Posting_Request]
                            WHERE [Payment_ID] IN (" + PaymentPostingID_JoinText + ")";
            /***************************************************************************************************/
            
            string queryString_Update_CustomerBrokerMoneyTransaction = string.Empty;
            queryString_Update_CustomerBrokerMoneyTransaction =
                            @"UPDATE [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction]
                                SET [Approval_Status]=1
                                ,[Approval_Date]=GETDATE()
                                ,[Approval_By]='"+GlobalVariableBO._userName+@"'
                                ,[Updated_Date]=Convert(varchar(10),GETDATE(),111)
                                ,[Update_By]='" + GlobalVariableBO._userName + @"'
                                WHERE [ID] IN (" + IPATransID_JoinText + @")
                                ";

            try
            {
                _dbConnection.ActiveCommandText();
                
                DataTable dt = _dbConnection.ExecuteQuery(queryString_CheckIf);
                if (dt.Rows.Count > 0)
                    isUpdated = Convert.ToBoolean(dt.Rows[0][0].ToString());
                if (isUpdated)
                    throw new Exception("Already Approved!!");
                
                _dbConnection.ExecuteNonQuery(queryString_UpdatePaymentPosting);
                _dbConnection.ExecuteNonQuery(queryString_Insert_CustomerBrokerMoneyTransaction);
                _dbConnection.ExecuteNonQuery(queryString_Insert_Money_Balance_Temp);
                _dbConnection.ExecuteNonQuery(queryString_Update_CustomerBrokerMoneyTransaction);


            }
            catch (Exception)
            {
                //_dbConnection.Rollback();
                throw;
            }
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IPA_TransID"></param>
        /// <param name="RejectionReason"></param>
        public void Rejected_IPO_TO_IPO_Mulit_Transfer_MoneyTransaction(string[] IPA_TransID, string RejectionReason)
        {
            SqlConnection conn = new SqlConnection(DbConnectionBasic.ConnectionString);
            CommonBAL comBal = new CommonBAL();
            DateTime TodayServerDate = comBal.GetCurrentServerDate();

            //string PaymentPostingID_JoinText = String.Join(",", TA_PaymentPosting_ID);
            string IPATransID_JoinText = (IPA_TransID.Length>0?String.Join(",", IPA_TransID):"0");

//            string queryString_UpdatePaymentPosting = string.Empty;
//            queryString_UpdatePaymentPosting = @"UPDATE [SBP_Database].[dbo].[SBP_Payment_Posting_Request]
//                            SET [Approval_Status]=2
//                            ,[Payment_Approved_By]='" + GlobalVariableBO._userName + @"'
//                            ,[Payment_Approved_Date]=GETDATE()
//                            ,Rejection_Reason='" + RejectionReason + @"'
//                            WHERE [Payment_ID] IN (" + PaymentPostingID_JoinText + @")
//                            ";



            string queryString_Update_CustomerBrokerMoneyTransaction = string.Empty;
            queryString_Update_CustomerBrokerMoneyTransaction =
                            @"UPDATE [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction]
                                SET [Approval_Status]=2
                                ,[Approval_Date]=GETDATE()
                                ,[Approval_By]='"+GlobalVariableBO._userName+ @"'
                                ,Rejected_Reason='" + RejectionReason + @"'
                                ,[Updated_Date]=Convert(varchar(10),GETDATE(),111)
                                ,[Update_By]='" + GlobalVariableBO._userName + @"'
                                WHERE [ID] IN (" + IPATransID_JoinText + @")
                                ";

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();
                //_dbConnection.ExecuteNonQuery(queryString_UpdatePaymentPosting);
                _dbConnection.ExecuteNonQuery(queryString_Update_CustomerBrokerMoneyTransaction);
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

        public void Rejected_Mulit_Transfer_MoneyTransaction(string[] TA_PaymentPosting_ID, string[] IPA_TransID,string RejectionReason)
        {
            SqlConnection conn = new SqlConnection(DbConnectionBasic.ConnectionString);
            CommonBAL comBal = new CommonBAL();
            DateTime TodayServerDate = comBal.GetCurrentServerDate();

            string PaymentPostingID_JoinText =(TA_PaymentPosting_ID.Length>0?String.Join(",", TA_PaymentPosting_ID):"0");
            string IPATransID_JoinText =(IPA_TransID.Length>0? String.Join(",", IPA_TransID):"0");

            string queryString_UpdatePaymentPosting = string.Empty;
            queryString_UpdatePaymentPosting = @"UPDATE [SBP_Database].[dbo].[SBP_Payment_Posting_Request]
                            SET [Approval_Status]=2
                            ,[Payment_Approved_By]='" + GlobalVariableBO._userName + @"'
                            ,[Payment_Approved_Date]=GETDATE()
                            ,Rejection_Reason='"+RejectionReason+@"'
                            WHERE [Payment_ID] IN (" + PaymentPostingID_JoinText + @")
                            ";



            string queryString_Update_CustomerBrokerMoneyTransaction = string.Empty;
            queryString_Update_CustomerBrokerMoneyTransaction =
                            @"UPDATE [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction]
                                SET [Approval_Status]=2
                                ,[Approval_Date]=GETDATE()
                                ,[Approval_By]='" + GlobalVariableBO._userName + @"'
                                ,[Updated_Date]=Convert(varchar(10),GETDATE(),111)
                                ,[Update_By]='" + GlobalVariableBO._userName + @"'
                                WHERE [ID] IN (" + IPATransID_JoinText + @")
                                ";

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();
                _dbConnection.ExecuteNonQuery(queryString_UpdatePaymentPosting);
                _dbConnection.ExecuteNonQuery(queryString_Update_CustomerBrokerMoneyTransaction);
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

        public void Approved_Single_TransferBack_MoneyTransaction(int TA_PaymentPosting_ID, int IPA_TransID)
        {
            Approved_Single_Transfer_MoneyTransaction(TA_PaymentPosting_ID, IPA_TransID);
        }

        public void Approved_Single_TransferBack_MoneyTransaction_UITransApplied(string TA_PaymentPosting_ID, string IPA_TransID)
        {
            Approved_Single_Transfer_MoneyTransaction_UITransApplied(TA_PaymentPosting_ID, IPA_TransID);
        }
        
        public void Rejected_Single_TransferBack_MoneyTransaction(int TA_PaymentPosting_ID, int IPA_TransID, string RejectionReason)
        {
            Rejected_Single_Transfer_MoneyTransaction(TA_PaymentPosting_ID, IPA_TransID, RejectionReason);
        }

        public void Approved_Multi_TransferBack_MoneyTransaction(string[] TA_PaymentPosting_ID, string[] IPA_TransID)
        {
            Approved_Multi_Transfer_MoneyTransaction(TA_PaymentPosting_ID, IPA_TransID);
        }
        
        public void Approved_Multi_TransferBack_MoneyTransaction_UITransApplied(string[] TA_PaymentPosting_ID, string[] IPA_TransID)
        {
            Approved_Multi_Transfer_MoneyTransaction_UITransApplied(TA_PaymentPosting_ID,IPA_TransID);
        }
        
        public void Rejected_Multi_TransferBack_MoneyTransaction(string[] TA_PaymentPosting_ID, string[] IPA_TransID,string RejectionReason)
        {
            Rejected_Multi_TransferBack_MoneyTransaction(TA_PaymentPosting_ID, IPA_TransID, RejectionReason);
        }

        public void Approved_Multi_TransferWithdraw_MoneyTransaction(string[] TA_PaymentPosting_ID, string[] IPA_TransID)
        {
            Approved_Multi_Transfer_MoneyTransaction(TA_PaymentPosting_ID, IPA_TransID);
        }

        public void Approved_Multi_TransferWithdraw_MoneyTransaction_UITransApplied(string[] TA_PaymentPosting_ID, string[] IPA_TransID)
        {
            Approved_Multi_Transfer_MoneyTransaction_UITransApplied(TA_PaymentPosting_ID, IPA_TransID);
        }

        public void Rejected_Multi_TransferWithdraw_MoneyTransaction(string[] TA_PaymentPosting_ID, string[] IPA_TransID, string RejectionReason)
        {
            Rejected_Multi_TransferBack_MoneyTransaction(TA_PaymentPosting_ID, IPA_TransID, RejectionReason);
        }

        public void Approved_Single_TransferWithdraw_MoneyTransaction(int TA_PaymentPosting_ID, int IPA_TransID)
        {
            Approved_Single_Transfer_MoneyTransaction(TA_PaymentPosting_ID, IPA_TransID);
        }

        public void Approved_Single_TransferWithdraw_MoneyTransaction_UITransApplied(string TA_PaymentPosting_ID, string IPA_TransID)
        {
            Approved_Single_Transfer_MoneyTransaction_UITransApplied(TA_PaymentPosting_ID, IPA_TransID);
        }

        public void Rejected_Single_TransferWithdraw_MoneyTransaction(int TA_PaymentPosting_ID, int IPA_TransID, string RejectionReason)
        {
            Rejected_Single_Transfer_MoneyTransaction(TA_PaymentPosting_ID, IPA_TransID, RejectionReason);
        }

        public void Delete_SMS_Request(int[] DeletedIds)
        {
            
            string DeletedIds_Joined=string.Join(",",DeletedIds.Select(t=> Convert.ToString(t)).ToArray());
            
            CommonBAL bal=new CommonBAL();
            DateTime CurrentDate=bal.GetCurrentServerDate();

            string Query = @"INSERT INTO [SBP_Database].[dbo].[SMS_Sync_Import_IPORequest_DeleteLog]
                            (
                               [DELETED_ID]
                               ,[Cust_Code]
                               ,[RegisteredCode]
                               ,[Money_TransactionType_Name]
                               ,[Money_TransactionType_Name_ID]
                               ,[Deposit_Withdraw]
                               ,[Amount]
                               ,[TransferCode]
                               ,[IPOSessionID]
                               ,[LotNo]
                               ,[Refund_Name]
                               ,[RefundType_ID]
                               ,[SMSReqID]
                               ,[SMSReceiveID]
                               ,[ApplicationType]
                               ,[Remarks]
                               ,[Received_Date]
                               ,[Delete_Reason]
                               ,[DeletedBy]
                               ,[Deleted_Date]
                               ,[Media_Type]
                            )
                            SELECT [ID]
                              ,[Cust_Code]
                              ,[RegisteredCode]
                              ,[Money_TransactionType_Name]
                              ,[Money_TransactionType_Name_ID]
                              ,[Deposit_Withdraw]
                              ,[Amount]
                              ,[TransferCode]
                              ,[IPOSessionID]
                              ,[LotNo]
                              ,[Refund_Name]
                              ,[RefundType_ID]
                              ,[SMSReqID]
                              ,[SMSReceiveID]
                              ,[ApplicationType]
                              ,[Remarks]
                              ,[Received_Date]
                              ,''
                              ,'" + GlobalVariableBO._userName+@"'
                              ,'"+CurrentDate.ToShortDateString()+ @"'
                              ,Media_Type
                           FROM [SBP_Database].[dbo].[SMS_Sync_Import_IPORequest]
                           WHERE ID IN (" + DeletedIds_Joined + @")";
            string DeleteQry = @"DELETE [SBP_Database].[dbo].[SMS_Sync_Import_IPORequest]
                                WHERE ID IN ("+DeletedIds_Joined+@")";

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();
                _dbConnection.ExecuteNonQuery(Query);
                _dbConnection.ExecuteNonQuery(DeleteQry);
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

        public void Approved_IPOApplication(int AppID,string ApprovedBy)
        {
            SqlConnection conn = new SqlConnection(DbConnectionBasic.ConnectionString);
            CommonBAL comBal = new CommonBAL();

            DateTime TodayServerDate = comBal.GetCurrentServerDate();
            
            string queryString_ApprovedApplication = "";
            queryString_ApprovedApplication = @"UPDATE [SBP_IPO_Application_BasicInfo]
                            SET [Application_Satus]=1
                            ,[AppStatus_UpdatedBy]='" +ApprovedBy+@"'
                            ,[AppStatus_UpdatedDate]=GETDATE()
                            ,[Updated_Date]=Convert(Varchar(10),GETDATE(),111)
                            ,[Update_By]='" + GlobalVariableBO._userName + @"'
                            WHERE [ID]=" + AppID + "";

            string queryString_WithdrawMoneyFromIPOAccount = "";
            queryString_WithdrawMoneyFromIPOAccount = @"INSERT INTO [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction]
                                                               ([Cust_Code]
                                                               ,[Received_Date]
                                                               ,[Money_TransactionType_ID]
                                                               ,[Money_TransactionType_Name]
                                                               ,[Deposit_Withdraw]
                                                               ,[Amount]
                                                               ,[Voucher_No]
                                                               ,[Trans_Reason]
                                                               ,[Intended_IPOSession_ID]
                                                               ,[Intended_IPOSession_Name]
                                                               ,[Approval_Status]
                                                               ,[Approval_Date]
                                                               ,[Approval_By]
                                                               --,[Rejected_Reason]
                                                                ,[Entry_Branch_ID]
                                                               ,[Entry_Date]
                                                               ,[Entry_By]
                                                               )
	                                                    SELECT    
			                                                    Cust_Code AS Cust_Code
			                                                    ,Convert(varchar(10),GETDATE(),111) AS Received_Date
			                                                    ,(
				                                                    Select p.ID
				                                                    From SBP_IPO_MoneyTrans_Type As p
				                                                    Where p.MoneyTransType_Name='TRIPOApp'
			                                                    ) AS PaymentMethod_ID
			                                                    ,'TRIPOApp' AS PaymentMethod_Name
			                                                    ,'Withdraw' AS Deposit_Withdraw
			                                                    ,(
				                                                    SELECT 
				                                                    [TotalAmount]
				                                                    FROM [SBP_Database].[dbo].[SBP_IPO_Session]	AS sess
				                                                    WHERE sess.[ID]=app.[IPOSession_ID]
			                                                    ) AS Amount
			                                                    ,'' AS VoucherNo
			                                                    ,'' AS TransReason
			                                                    ,app.[IPOSession_ID]
			                                                    ,app.[IPOSession_Name]
			                                                    ,1 AS [Approval_Status]
			                                                    ,GETDATE() AS [Approval_Date]
			                                                    ,'"+GlobalVariableBO._userName+@"' AS [Approval_By]
                                                                ,'"+GlobalVariableBO._branchId+@"'
			                                                    ,Convert(varchar(10),GETDATE(),111) AS EntryDate
			                                                    ,'" + GlobalVariableBO._userName + @"' AS [Entry_By]
	                                                    FROM [SBP_Database].[dbo].[SBP_IPO_Application_BasicInfo] As app
	                                                    WHERE app.[ID]=" + AppID+@"
                                                        ";
            string queryString_DepositToIPOAppAccount = "";
            queryString_DepositToIPOAppAccount = @"INSERT INTO [SBP_Database].[dbo].[SBP_IPO_IPOApplication_MoneyTransaction]
                                                       ([Cust_Code]
                                                       ,[Received_Date]
                                                       ,[Money_TransactionType_ID]
                                                       ,[Money_TransactionType_Name]
                                                       ,[Deposit_Withdraw]
                                                       ,[Amount]
                                                       ,[Voucher_No]
                                                       ,[Trans_Reason]
                                                       ,[Intended_IPOSession_ID]
                                                       ,[Intended_IPOSession_Name]
                                                       ,[Approval_Status]
                                                       ,[Approval_Date]
                                                       ,[Approval_By]
                                                       ,[Entry_Date]
                                                       ,[Entry_By]
                                                       )
                                                SELECT    
			                                            Cust_Code AS Cust_Code
			                                            ,Convert(varchar(10),GETDATE(),111) AS Received_Date
			                                            ,(
				                                            Select p.ID
				                                            From SBP_IPO_MoneyTrans_Type As p
				                                            Where p.MoneyTransType_Name='TRIPOApp'
			                                            ) AS PaymentMethod_ID
			                                            ,'TRIPOApp' AS PaymentMethod_Name
			                                            ,'Deposit' AS Deposit_Withdraw
			                                            ,(
				                                            SELECT 
				                                            [TotalAmount]
				                                            FROM [SBP_Database].[dbo].[SBP_IPO_Session]	AS sess
				                                            WHERE sess.[ID]=app.[IPOSession_ID]
			                                            ) AS Amount
			                                            ,'' AS VoucherNo
			                                            ,'' AS TransReason
			                                            ,app.[IPOSession_ID]
			                                            ,app.[IPOSession_Name]
			                                            ,1 AS [Approval_Status]
			                                            ,GETDATE() AS [Approval_Date]
			                                            ,'" + GlobalVariableBO._userName + @"' AS [Approval_By]
			                                            ,Convert(varchar(10),GETDATE(),111) AS EntryDate
			                                            ,'" + GlobalVariableBO._userName + @"' AS [Entry_By]
	                                            FROM [SBP_Database].[dbo].[SBP_IPO_Application_BasicInfo] As app
	                                            WHERE app.[ID]=" + AppID + @"
                                            ";
            
            string queryString_WithdrawMoneyFromIPOAccount_ForCharge = "";
            queryString_WithdrawMoneyFromIPOAccount_ForCharge = @"INSERT INTO [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction]
                                                           (
                                                           [Cust_Code]
                                                           ,[Received_Date]
                                                           ,[Money_TransactionType_ID]
                                                           ,[Money_TransactionType_Name]
                                                           ,[Deposit_Withdraw]
                                                           ,[Amount]
                                                           ,[Voucher_No]
                                                           ,[Trans_Reason]
                                                           ,[Intended_IPOSession_ID]
                                                           ,[Intended_IPOSession_Name]
                                                           ,[Approval_Status]
                                                           ,[Approval_Date]
                                                           ,[Approval_By]
                                                            ,[Entry_Branch_ID]
                                                           ,[Entry_Date]
                                                           ,[Entry_By]
                                                           )
                                                    SELECT    
                                                            Cust_Code AS Cust_Code
                                                            ,Convert(varchar(10),GETDATE(),111) AS Received_Date
                                                            ,(
                                                                Select p.ID
                                                                From SBP_IPO_MoneyTrans_Type As p
                                                                Where p.MoneyTransType_Name='Cash'
                                                            ) AS PaymentMethod_ID
                                                            ,'Cash' AS PaymentMethod_Name
                                                            ,'Withdraw' AS Deposit_Withdraw
                                                           ,( 
                                                                SELECT occ.[Amount]
			                                                    FROM [SBP_Database].[dbo].[SBP_Payment_OCC_Purpose] AS occ
			                                                    WHERE occ.[OCC_Purpose]='IPO App Charge'
                                                            ) AS Amount
                                                            ,'' AS VoucherNo
                                                            ,'IPO_Charge' AS TransReason
                                                            ,app.[IPOSession_ID]
                                                            ,app.[IPOSession_Name]
                                                            ,1 AS [Approval_Status]
                                                            ,GETDATE() AS [Approval_Date]
                                                            ,'" + GlobalVariableBO._userName + @"' AS [Approval_By]
                                                            ,"+GlobalVariableBO._branchId+@"
                                                            ,Convert(varchar(10),GETDATE(),111) AS EntryDate
                                                            ,'" + GlobalVariableBO._userName + @"' AS [Entry_By]
                                                    FROM [SBP_Database].[dbo].[SBP_IPO_Application_BasicInfo] As app
                                                    WHERE app.[ID]=" + AppID+@"";
            
            string queryString_DepositMoneyToPaymentOOC_ForCharge = "";
            queryString_DepositMoneyToPaymentOOC_ForCharge = @"INSERT INTO [SBP_Database].[dbo].[SBP_Payment_OOC]
                                                               ([Cust_Code]
                                                               ,[Payment_Media]
                                                               ,[OCC_ID]
                                                               ,[Payment_Date]
                                                               ,[Amount]
                                                               ,[Voucher]
                                                               ,[Payment_Period]
                                                               ,[Remarks]
                                                               ,[Branch_ID]
                                                               ,[Entry_Date]
                                                               ,[Entry_By]
                                                               ,[Status] 
                                                              )
                                                    SELECT    
                                                            Cust_Code AS Cust_Code        
                                                            ,'Cash' AS [Payment_Media]
                                                            ,( 
			                                                    SELECT occ.[OCC_ID]
			                                                    FROM [SBP_Database].[dbo].[SBP_Payment_OCC_Purpose] AS occ
			                                                    WHERE occ.[OCC_Purpose]='IPO App Charge'
		                                                    ) AS [OCC_ID]
		                                                    ,Convert(varchar(10),GETDATE(),111) AS [Payment_Date]
                                                            ,(
			                                                    SELECT occ.[Amount]
			                                                    FROM [SBP_Database].[dbo].[SBP_Payment_OCC_Purpose] AS occ
			                                                    WHERE occ.[OCC_Purpose]='IPO App Charge'
                                                            ) AS [Amount]
                                                            ,'' AS [Voucher]
                                                            ,Convert(Varchar(10),GETDATE(),111) AS [Payment_Period]
                                                            ,'IPO App Charge' AS [Remarks]      
                                                            ," + GlobalVariableBO._branchId+@" AS [Branch_ID]
                                                            ,GETDATE() AS [Entry_Date]
                                                            ,'" + GlobalVariableBO._userName + @"' AS [Entry_By]
                                                            ,0                
                                                    FROM [SBP_Database].[dbo].[SBP_IPO_Application_BasicInfo] As app
                                                    WHERE app.[ID]=" + AppID + @"";



            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();
                _dbConnection.ExecuteNonQuery(queryString_ApprovedApplication);
                _dbConnection.ExecuteNonQuery(queryString_WithdrawMoneyFromIPOAccount);
                _dbConnection.ExecuteNonQuery(queryString_DepositToIPOAppAccount);
                //_dbConnection.ExecuteNonQuery(queryString_WithdrawMoneyFromIPOAccount_ForCharge);
                //_dbConnection.ExecuteNonQuery(queryString_DepositMoneyToPaymentOOC_ForCharge);
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

        public void Approved_IPOApplication_UITransApplied(int AppID, string ApprovedBy)
        {
            SqlConnection conn = new SqlConnection(DbConnectionBasic.ConnectionString);
            CommonBAL comBal = new CommonBAL();

            DateTime TodayServerDate = comBal.GetCurrentServerDate();

            string queryString_ApprovedApplication = "";
            queryString_ApprovedApplication = @"UPDATE [SBP_IPO_Application_BasicInfo]
                            SET [Application_Satus]=1
                            ,[AppStatus_UpdatedBy]='" + ApprovedBy + @"'
                            ,[AppStatus_UpdatedDate]=GETDATE()
                            ,[Updated_Date]=Convert(Varchar(10),GETDATE(),111)
                            ,[Update_By]='" + GlobalVariableBO._userName + @"'
                            WHERE [ID]=" + AppID + "";

            string queryString_WithdrawMoneyFromIPOAccount = "";
            queryString_WithdrawMoneyFromIPOAccount = @"INSERT INTO [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction]
                                                               ([Cust_Code]
                                                               ,[Received_Date]
                                                               ,[Money_TransactionType_ID]
                                                               ,[Money_TransactionType_Name]
                                                               ,[Deposit_Withdraw]
                                                               ,[Amount]
                                                               ,[Voucher_No]
                                                               ,[Trans_Reason]
                                                               ,[Intended_IPOSession_ID]
                                                               ,[Intended_IPOSession_Name]
                                                               ,[Approval_Status]
                                                               ,[Approval_Date]
                                                               ,[Approval_By]
                                                               --,[Rejected_Reason]
                                                               ,Channel
                                                               ,ChannelID 
                                                               ,[Entry_Date]
                                                               ,[Entry_By]
                                                               ,[Entry_Branch_ID]
                                                               )
	                                                    SELECT    
			                                                    Cust_Code AS Cust_Code
			                                                    ,Convert(varchar(10),GETDATE(),111) AS Received_Date
			                                                    ,(
				                                                    Select p.ID
				                                                    From SBP_IPO_MoneyTrans_Type As p
				                                                    Where p.MoneyTransType_Name='TRIPOApp'
			                                                    ) AS PaymentMethod_ID
			                                                    ,'TRIPOApp' AS PaymentMethod_Name
			                                                    ,'Withdraw' AS Deposit_Withdraw
			                                                    ,(
				                                                    SELECT 
				                                                    [TotalAmount]
				                                                    FROM [SBP_Database].[dbo].[SBP_IPO_Session]	AS sess
				                                                    WHERE sess.[ID]=app.[IPOSession_ID]
			                                                    ) AS Amount
			                                                    ,'' AS VoucherNo
			                                                    ,'' AS TransReason
			                                                    ,app.[IPOSession_ID]
			                                                    ,app.[IPOSession_Name]
			                                                    ,1 AS [Approval_Status]
			                                                    ,GETDATE() AS [Approval_Date]
			                                                    ,'" + GlobalVariableBO._userName + @"' AS [Approval_By]
                                                                ,ChannelType
                                                                ,ChannelID   
			                                                    ,Convert(varchar(10),GETDATE(),111) AS EntryDate
			                                                    ,'" + GlobalVariableBO._userName + @"' AS [Entry_By]
                                                                ," +GlobalVariableBO._branchId+@"
	                                                    FROM [SBP_Database].[dbo].[SBP_IPO_Application_BasicInfo] As app
	                                                    WHERE app.[ID]=" + AppID + @" 
                                                        AND NOT EXISTS(
			                                                    Select t.* 
			                                                    From SBP_IPO_Customer_Broker_MoneyTransaction as t
			                                                    Where t.Cust_Code=app.Cust_Code AND Money_TransactionType_Name='TRIPOApp'
                                                                AND t.Deposit_Withdraw='"+Indication_PaymentMode.Withdraw+@"' 
			                                                    AND t.Intended_IPOSession_ID=app.IPOSession_ID
                                                        )
                                                        ";
            string queryString_DepositToIPOAppAccount = "";
            queryString_DepositToIPOAppAccount = @"INSERT INTO [SBP_Database].[dbo].[SBP_IPO_IPOApplication_MoneyTransaction]
                                                       ([Cust_Code]
                                                       ,[Received_Date]
                                                       ,[Money_TransactionType_ID]
                                                       ,[Money_TransactionType_Name]
                                                       ,[Deposit_Withdraw]
                                                       ,[Amount]
                                                       ,[Voucher_No]
                                                       ,[Trans_Reason]
                                                       ,[Intended_IPOSession_ID]
                                                       ,[Intended_IPOSession_Name]
                                                       ,[Approval_Status]
                                                       ,[Approval_Date]
                                                       ,[Approval_By]
                                                       ,[Entry_Date]
                                                       ,[Entry_By]
                                                       --,[Entry_Branch_ID]
                                                       )
                                                SELECT    
			                                            Cust_Code AS Cust_Code
			                                            ,Convert(varchar(10),GETDATE(),111) AS Received_Date
			                                            ,(
				                                            Select p.ID
				                                            From SBP_IPO_MoneyTrans_Type As p
				                                            Where p.MoneyTransType_Name='TRIPOApp'
			                                            ) AS PaymentMethod_ID
			                                            ,'TRIPOApp' AS PaymentMethod_Name
			                                            ,'Deposit' AS Deposit_Withdraw
			                                            ,(
				                                            SELECT 
				                                            [TotalAmount]
				                                            FROM [SBP_Database].[dbo].[SBP_IPO_Session]	AS sess
				                                            WHERE sess.[ID]=app.[IPOSession_ID]
			                                            ) AS Amount
			                                            ,'' AS VoucherNo
			                                            ,'' AS TransReason
			                                            ,app.[IPOSession_ID]
			                                            ,app.[IPOSession_Name]
			                                            ,1 AS [Approval_Status]
			                                            ,GETDATE() AS [Approval_Date]
			                                            ,'" + GlobalVariableBO._userName + @"' AS [Approval_By]
			                                            ,Convert(varchar(10),GETDATE(),111) AS EntryDate
			                                            ,'" + GlobalVariableBO._userName + @"' AS [Entry_By]
                                                        --," +GlobalVariableBO._branchId+@"
	                                            FROM [SBP_Database].[dbo].[SBP_IPO_Application_BasicInfo] As app
	                                            WHERE app.[ID]=" + AppID + @"
                                                AND NOT EXISTS(
			                                                    Select t.* 
			                                                    From SBP_IPO_IPOApplication_MoneyTransaction as t
			                                                    Where t.Cust_Code=app.Cust_Code AND Money_TransactionType_Name='TRIPOApp' 
			                                                     AND t.Deposit_Withdraw='" + Indication_PaymentMode.Deposit + @"' 
                                                                AND t.Intended_IPOSession_ID=app.IPOSession_ID
                                                )
                                            ";

            string queryString_WithdrawMoneyFromIPOAccount_ForCharge = "";
            queryString_WithdrawMoneyFromIPOAccount_ForCharge = @"INSERT INTO [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction]
                                                           (
                                                           [Cust_Code]
                                                           ,[Received_Date]
                                                           ,[Money_TransactionType_ID]
                                                           ,[Money_TransactionType_Name]
                                                           ,[Deposit_Withdraw]
                                                           ,[Amount]
                                                           ,[Voucher_No]
                                                           ,[Trans_Reason]
                                                           ,[Intended_IPOSession_ID]
                                                           ,[Intended_IPOSession_Name]
                                                           ,[Approval_Status]
                                                           ,[Approval_Date]
                                                           ,[Approval_By]
                                                           ,[Entry_Date]
                                                           ,[Entry_By]
                                                           )
                                                    SELECT    
                                                            Cust_Code AS Cust_Code
                                                            ,Convert(varchar(10),GETDATE(),111) AS Received_Date
                                                            ,(
                                                                Select p.ID
                                                                From SBP_IPO_MoneyTrans_Type As p
                                                                Where p.MoneyTransType_Name='Cash'
                                                            ) AS PaymentMethod_ID
                                                            ,'Cash' AS PaymentMethod_Name
                                                            ,'Withdraw' AS Deposit_Withdraw
                                                           ,( 
                                                                SELECT occ.[Amount]
			                                                    FROM [SBP_Database].[dbo].[SBP_Payment_OCC_Purpose] AS occ
			                                                    WHERE occ.[OCC_Purpose]='IPO App Charge'
                                                            ) AS Amount
                                                            ,'' AS VoucherNo
                                                            ,'IPO_Charge' AS TransReason
                                                            ,app.[IPOSession_ID]
                                                            ,app.[IPOSession_Name]
                                                            ,1 AS [Approval_Status]
                                                            ,GETDATE() AS [Approval_Date]
                                                            ,'"+GlobalVariableBO._userName+@"' AS [Approval_By]
                                                            ,Convert(varchar(10),GETDATE(),111) AS EntryDate
                                                            ,'"+GlobalVariableBO._userName+@"' AS [Entry_By]
                                                    FROM [SBP_Database].[dbo].[SBP_IPO_Application_BasicInfo] As app
                                                    WHERE app.[ID]=" + AppID + @"";

            string queryString_DepositMoneyToPaymentOOC_ForCharge = "";
            queryString_DepositMoneyToPaymentOOC_ForCharge = @"INSERT INTO [SBP_Database].[dbo].[SBP_Payment_OOC]
                                                               ([Cust_Code]
                                                               ,[Payment_Media]
                                                               ,[OCC_ID]
                                                               ,[Payment_Date]
                                                               ,[Amount]
                                                               ,[Voucher]
                                                               ,[Payment_Period]
                                                               ,[Remarks]
                                                               ,[Branch_ID]
                                                               ,[Entry_Date]
                                                               ,[Entry_By]
                                                               ,[Status] 
                                                              )
                                                    SELECT    
                                                            Cust_Code AS Cust_Code        
                                                            ,'Cash' AS [Payment_Media]
                                                            ,( 
			                                                    SELECT occ.[OCC_ID]
			                                                    FROM [SBP_Database].[dbo].[SBP_Payment_OCC_Purpose] AS occ
			                                                    WHERE occ.[OCC_Purpose]='IPO App Charge'
		                                                    ) AS [OCC_ID]
		                                                    ,Convert(varchar(10),GETDATE(),111) AS [Payment_Date]
                                                            ,(
			                                                    SELECT occ.[Amount]
			                                                    FROM [SBP_Database].[dbo].[SBP_Payment_OCC_Purpose] AS occ
			                                                    WHERE occ.[OCC_Purpose]='IPO App Charge'
                                                            ) AS [Amount]
                                                            ,'' AS [Voucher]
                                                            ,Convert(Varchar(10),GETDATE(),111) AS [Payment_Period]
                                                            ,'IPO App Charge' AS [Remarks]      
                                                            ," + GlobalVariableBO._branchId + @" AS [Branch_ID]
                                                            ,GETDATE() AS [Entry_Date]
                                                            ,'" + GlobalVariableBO._userName + @"' AS [Entry_By]
                                                            ,0                
                                                    FROM [SBP_Database].[dbo].[SBP_IPO_Application_BasicInfo] As app
                                                    WHERE app.[ID]=" + AppID + @"";



            try
            {
                //_dbConnection.ConnectDatabase();
                //_dbConnection.StartTransaction();
                _dbConnection.ExecuteNonQuery(queryString_ApprovedApplication);
                _dbConnection.ExecuteNonQuery(queryString_WithdrawMoneyFromIPOAccount);
                _dbConnection.ExecuteNonQuery(queryString_DepositToIPOAppAccount);
                //_dbConnection.ExecuteNonQuery(queryString_WithdrawMoneyFromIPOAccount_ForCharge);
                //_dbConnection.ExecuteNonQuery(queryString_DepositMoneyToPaymentOOC_ForCharge);
                //_dbConnection.Commit();
            }
            catch (Exception)
            {
                //_dbConnection.Rollback();
                throw;
            }
            //finally
            //{
            //    _dbConnection.CloseDatabase();
            //}
        }
        #region NRB BAL

        /// <summary>
        /// Unsuccessful draft Approve and Refund Charge withdraw
        /// Rashedul Hasan 29 jun 2015
        /// </summary>
        public void NRB_DraftRefundApprove(string id)
        {

            string query = @"Update SBP_IPO_NRB_Customer_DraftInformation Set 
                            Draft_Status=4
                            ,Update_By='" + GlobalVariableBO._userName + @"'
                            ,Update_Date=GETDATE()
                            Where ID =" + id + @""
                                   ;
            try
            {

                _dbConnection.ExecuteNonQuery(query);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Unsuccessful Draft information Pending list
        /// Rashedul hasan
        /// 29 jun 2015
        /// </summary>
        /// <returns></returns>
        public DataTable GetRefundInformation_NRBDruft_PendingList()
        {
            DataTable dt = new DataTable();
            string query = @" Select D.ID As Nrb_ID,bs.Cust_Code,Ext.Cust_Name,bs.BO_ID,bs.Serial_No
                         ,bs.Applied_Company,D.Intended_IPOSession_Name,D.Intended_IPOSession_ID
                         ,D.Currency_Name,D.Currency_Amount,D.FD_NO,ext.Applicant_Category,D.Bank_Name,st.Status_Name--,Ext.Refund_Method,Ext.Refund_Other_Details
                         From SBP_IPO_Application_BasicInfo As bs
                         Join SBP_IPO_NRB_Customer_DraftInformation As D
                         on bs.Money_Trans_NRB_ID=D.ID
                         And bs.IPOSession_ID=D.Intended_IPOSession_ID
                         Join SBP_IPO_Application_ExtendedInfo As Ext
                         ON Ext.BasicInfo_ID=bs.ID
                         Join SBP_IPO_ResultTemp As tmp
                         ON tmp.Cust_Code=bs.Cust_Code
                         And tmp.IPO_Session_ID=bs.IPOSession_ID
                         Join SBP_IPO_Approval_Status as st
                         on st.ID=bs.Application_Satus
                         Where Ext.Applicant_Category='NRB'
                         And bs.Application_Satus=4
                         And d.Draft_Status=2
                         --And tmp.Successful_Amount=0
                        ";
            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dt;
        }

        /// <summary>
        /// Added BY MD.Rashedul Hasan
        /// </summary>
        /// <param name="Trans_ID"></param>
        /// <param name="App_ID"></param>
        /// <param name="Charge_Trans_ID"></param>
        /// <param name="AppChrge"></param>
        /// <param name="currency_Name"></param>
        /// <param name="Currecy_Amount"></param>
        public void Approve_NRB_IPO_Application(string Trans_ID, string App_ID, string Charge_Trans_ID, double AppChrge, string currency_Name, double Currecy_Amount)
        {
            string App_Query = @"update SBP_IPO_Application_BasicInfo
                                    Set Application_Satus=1
                                    ,AppStatus_UpdatedBy='" + GlobalVariableBO._userName + @"'
                                    ,AppStatus_UpdatedDate=GETDATE()
                                    Where ID='" + App_ID + @"'
                                    And Money_Trans_NRB_ID='" + Trans_ID + @"'
                                    ";
            string Update_DraftStatus = "";
            Update_DraftStatus = @"Update [SBP_IPO_NRB_Customer_DraftInformation] 
                                 Set Draft_Status=2
	                                ,Update_By ='" + GlobalVariableBO._userName + @"'
	                                ,Update_Date=GETDATE()
	                                Where ID=" + Trans_ID + @"
                                    ";

//            string queryString_WithdrawMoneyFromIPOAccount = "";
//            queryString_WithdrawMoneyFromIPOAccount = @"INSERT INTO [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction]
//                                                               ([Cust_Code]
//                                                               ,[Received_Date]
//                                                               ,[Money_TransactionType_ID]
//                                                               ,[Money_TransactionType_Name]
//                                                               ,[Deposit_Withdraw]
//                                                               ,[Amount]
//                                                               ,[Voucher_No]
//                                                               ,[Trans_Reason]
//                                                               ,[Intended_IPOSession_ID]
//                                                               ,[Intended_IPOSession_Name]
//                                                               ,[Approval_Status]
//                                                               ,[Approval_Date]
//                                                               ,[Approval_By]
//                                                               --,[Rejected_Reason]
//                                                                ,[Entry_Branch_ID]
//                                                               ,[Entry_Date]
//                                                               ,[Entry_By]
//                                                               )
//	                                                    SELECT
//                                                            [Cust_Code]
//                                                            ,Convert(varchar(10),GETDATE(),111) AS Received_Date
//                                                            ,(
//                                                                Select p.ID
//                                                                From SBP_IPO_MoneyTrans_Type As p
//                                                                Where p.MoneyTransType_Name='Cash'
//                                                            ) AS PaymentMethod_ID
//                                                            ,'Cash' AS PaymentMethod_Name
//                                                            ,'Withdraw' AS Deposit_Withdraw
//                                                            ,'" + AppChrge + @"'
//                                                            ,[Voucher_No]
//                                                            ,'Charge NRB_'+ [Cust_Code] +'_To_' +[Cust_Code]+'_'+'" + Charge_Trans_ID + @"'
//                                                            ,[Intended_IPOSession_ID]
//                                                            ,[Intended_IPOSession_Name]
//                                                            ,[Approval_Status]
//                                                            ,Getdate()
//                                                            ,'" + GlobalVariableBO._userName + @"'
//                                                            ,'" + GlobalVariableBO._branchId + @"'
//                                                            ,Getdate()
//                                                            ,'" + GlobalVariableBO._userName + @"'
//                                                            From [SBP_IPO_Customer_Broker_MoneyTransaction]
//                                                            Where ID='" + Charge_Trans_ID + @"'
//                                                            ";
            string Withdraw_For_Application = @"";
            Withdraw_For_Application = @"INSERT INTO [SBP_Database].[dbo].[SBP_IPO_NRB_Customer_MoneyTransaction]
                                       ([Cust_Code]
                                       ,[Receive_Date]
                                       ,[Deposit_Withdraw]
                                        ,[Money_Transaction_ID]
                                       ,[Money_Transaction_Name]
                                       ,[FD_NO]
                                       ,[Currency_Name]
                                       ,[Currency_Amount]
                                       ,[Charge]
                                       --,[Voucher_No]
                                       ,[Intended_IPOSession_ID]
                                       ,[Intended_IPOSession_Name]
                                       --,[Bank_Name]
                                       --,[Bank_ID]
                                       ,[Approval_Status]
                                       ,[Present_Status]
                                       ,[Approval_Date]
                                       ,[Approval_By]
                                       ,[Entry_Branch_ID]
                                       ,[Entry_By]
                                       ,[Entry_Date]
                                       ,[Update_By]
                                       ,[Update_Date]
                                        )
                                select
                                App.Cust_Code As Cust_Code
                                ,Convert(varchar(10),GETDATE(),111) AS Received_Date
                                ,'Withdraw'
                                ,(
                                    Select p.ID
                                    From SBP_IPO_MoneyTrans_Type As p
                                    Where p.MoneyTransType_Name='TRIPOApp'
                                ) AS PaymentMethod_ID
                                ,'TRIPOApp' AS PaymentMethod_Name
                                ,t.[FD_NO]
                                ,'" + currency_Name + @"'
                                ,'" + Currecy_Amount + @"'
                                ,[Charge]
                                --,t.[Voucher_No]
                                ,app.[IPOSession_ID]
                                ,app.[IPOSession_Name]
                                ,1 AS [Approval_Status]
                                ,t.Present_Status
                                ,GetDate()
                                ,'" + GlobalVariableBO._userName + @"'
                                ,'" + GlobalVariableBO._branchId + @"'
                                ,'" + GlobalVariableBO._userName + @"'
                                ,GetDate()
                                ,'" + GlobalVariableBO._userName + @"'
                                ,GetDate()
                                From [SBP_IPO_NRB_Customer_MoneyTransaction] as t 
                                Join SBP_IPO_Application_BasicInfo As App
                                ON App.Money_Trans_NRB_ID=t.ID
                                Where t.ID='" + Trans_ID + @"'
                            ";


            string DepositForIPOApplication = "";
            DepositForIPOApplication = @"INSERT INTO [SBP_Database].[dbo].[SBP_IPO_IPOApplication_MoneyTransaction]
                                                       ([Cust_Code]
                                                       ,[Received_Date]
                                                       ,[Money_TransactionType_ID]
                                                       ,[Money_TransactionType_Name]
                                                       ,[Deposit_Withdraw]
                                                       ,[Amount]
                                                       ,[Voucher_No]
                                                       ,[Trans_Reason]
                                                       ,[Intended_IPOSession_ID]
                                                       ,[Intended_IPOSession_Name]
                                                       ,[Approval_Status]
                                                       ,[Approval_Date]
                                                       ,[Approval_By]
                                                       ,[Entry_Date]
                                                       ,[Entry_By]
                                                       )
                                                SELECT    
			                                            Cust_Code AS Cust_Code
			                                            ,Convert(varchar(10),GETDATE(),111) AS Received_Date
			                                            ,(
				                                            Select p.ID
				                                            From SBP_IPO_MoneyTrans_Type As p
				                                            Where p.MoneyTransType_Name='TRIPOApp'
			                                            ) AS PaymentMethod_ID
			                                            ,'TRIPOApp' AS PaymentMethod_Name
			                                            ,'Deposit' AS Deposit_Withdraw
			                                            ," + Currecy_Amount + @" AS Amount
			                                            ,'' AS VoucherNo
			                                            ,'' AS TransReason
			                                            ,app.[IPOSession_ID]
			                                            ,app.[IPOSession_Name]
			                                            ,1 AS [Approval_Status]
			                                            ,GETDATE() AS [Approval_Date]
			                                            ,'" + GlobalVariableBO._userName + @"' AS [Approval_By]
			                                            ,Convert(varchar(10),GETDATE(),111) AS EntryDate
			                                            ,'" + GlobalVariableBO._userName + @"' AS [Entry_By]
	                                            FROM [SBP_Database].[dbo].[SBP_IPO_Application_BasicInfo] As app
	                                            WHERE app.[ID]=" + App_ID + @"";
            try
            {
                string Concat_Query = App_Query + Update_DraftStatus;
                    //+ queryString_WithdrawMoneyFromIPOAccount;
                _dbConnection.ExecuteNonQuery(Concat_Query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Money trans Update Added By MD.Rashedul Hasan
        /// </summary>
        /// <param name="NRB_trans_id"></param>
        /// <param name="Charge_trans_ID"></param>
        public void Update_NRBApplication_Money_UITrans(string NRB_trans_id)
        {
            string query = @"Update SBP_IPO_NRB_Customer_DraftInformation 
                            Set Approval_Status=1
                            ,Approval_By='" + GlobalVariableBO._userName + @"'
                            ,Approval_Date=GetDate()
                            Where ID='" + NRB_trans_id + "'";
//            string Charge_Query = @"
//                                update SBP_IPO_Customer_Broker_MoneyTransaction
//                                Set Approval_Status=1
//                                ,Approval_By='" + GlobalVariableBO._userName + @"'
//                                ,Approval_Date=GETDATE()
//                                ,Update_By='" + GlobalVariableBO._userName + @"'
//                                ,Updated_Date=GETDATE()
//                                Where ID='" + Charge_trans_ID + @"'
//                                ";

            try
            {
                _dbConnection.ExecuteNonQuery(query );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Require Application Amount For NRB Application Added By Md.Rashedul Hasan
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Cust_Code"></param>
        /// <param name="Fd_NO"></param>
        /// <param name="SessionId"></param>
        /// <returns></returns>
        public double GetNRBReqApplicatinAmount(string Id, string Cust_Code, string Fd_NO, int SessionId)
        {
            double reqamount = 0.00;
            double doubleTry = 0.00;
            DataTable dt = new DataTable();
            string query = @"Select (Currency_Amount) As [Apply_Req_Amount] 
                                From SBP_IPO_NRB_Customer_DraftInformation
                                Where ID='" + Id + @"' 
                                And Cust_Code='" + Cust_Code + @"' 
                                And FD_NO='" + Fd_NO + @"'
                                And Intended_IPOSession_ID=" + SessionId + @"
                                And Approval_Status=1";
            try
            {
                dt = _dbConnection.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            if (double.TryParse(dt.Rows[0]["Apply_Req_Amount"].ToString(), out doubleTry))
            {
                reqamount = doubleTry;
            }
            return reqamount;
        }
        /// <summary>
        /// NRB Money Transaction Pending List Added By Md.Rasheul Hasan
        /// </summary>
        /// <returns></returns>
        public DataTable GetNRBApplicationAndMoneyTransfer()
        {
            DataTable dt = null;
            string query = @"Exec SBP_IPO_NRB_ApplicationAndMoneyTransaction_PendingList " + GlobalVariableBO._branchId + "";
            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteProByText(query);
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
        #endregion
        /// <summary>
        /// Added BY Md.Rashedul Hasan
        /// </summary>
        /// <param name="AppID"></param>
        /// <param name="ApprovedBy"></param>
        /// <param name="RejectedReason"></param>
        public void Rejected_IPO_To_IPO_IPOApplication(string[] AppID, string ApprovedBy, string RejectedReason)
        {
            string JoinAppID = (AppID.Length>0 ? string.Join(",", AppID):"0");
            string queryString_RejectedApplication = "";
            queryString_RejectedApplication = @"UPDATE [SBP_IPO_Application_BasicInfo]
                            SET [Application_Satus]=2
                            ,[AppStatus_UpdatedBy]='" + ApprovedBy + @"'
                            ,[AppStatus_UpdatedDate]=GETDATE()
                            ,[AppStatus_RejectedReason]='" + RejectedReason + @"'
                            ,[Updated_Date]=Convert(Varchar(10),GETDATE(),111)
                            ,[Update_By]='" + GlobalVariableBO._userName + @"'
                            WHERE [ID] in (" + JoinAppID + ")";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(queryString_RejectedApplication);

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

        public void Rejected_IPOApplication(int AppID, string ApprovedBy,string RejectedReason)
        {
            string queryString_RejectedApplication = "";
            queryString_RejectedApplication = @"UPDATE [SBP_IPO_Application_BasicInfo]
                            SET [Application_Satus]=2
                            ,[AppStatus_UpdatedBy]='" + ApprovedBy + @"'
                            ,[AppStatus_UpdatedDate]=GETDATE()
                            ,[AppStatus_RejectedReason]='"+RejectedReason+@"'
                            ,[Updated_Date]=Convert(Varchar(10),GETDATE(),111)
                            ,[Update_By]='"+GlobalVariableBO._userName+@"'
                            WHERE [ID]=" + AppID + "";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(queryString_RejectedApplication);

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

        public void Rejected_IPOApplication_UITransApplied(int AppID, string ApprovedBy, string RejectedReason)
        {
            string queryString_RejectedApplication = "";
            queryString_RejectedApplication = @"UPDATE [SBP_IPO_Application_BasicInfo]
                            SET [Application_Satus]=2
                            ,[AppStatus_UpdatedBy]='" + ApprovedBy + @"'
                            ,[AppStatus_UpdatedDate]=GETDATE()
                            ,[AppStatus_RejectedReason]='" + RejectedReason + @"'
                            ,[Updated_Date]=Convert(Varchar(10),GETDATE(),111)
                            ,[Update_By]='" + GlobalVariableBO._userName + @"'
                            WHERE [ID]=" + AppID + "";
            try
            {
                //_dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(queryString_RejectedApplication);

            }
            catch (Exception)
            {
                throw;
            }
            //finally
            //{
            //    _dbConnection.CloseDatabase();
            //}
        }
               
    }
}
