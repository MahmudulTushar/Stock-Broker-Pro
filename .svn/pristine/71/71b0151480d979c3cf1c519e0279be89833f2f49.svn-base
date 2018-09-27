using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using System.Data;

using BusinessAccessLayer.BO;

namespace BusinessAccessLayer.BAL
{
    public class IncomeEntryBAL
    {
        private DbConnection _dbConnection = new DbConnection();

        public IncomeEntryBAL()
        {
            _dbConnection = new DbConnection();
        }
        public void ConnectDatabase()
        {
            _dbConnection.ConnectDatabase();
        }
        public void StartTransaction()
        {
            _dbConnection.StartTransaction();
        }
        public void CommitTransaction()
        {
            _dbConnection.Commit();
        }
        public void RollBackTransaction()
        {
            _dbConnection.Rollback();
        }
        public void CloseDatabase()
        {
            _dbConnection.CloseDatabase();
        }

        public DataTable getHeadCode()
        {
            DataTable dt;
            string Query = @"select HeadName
	                                  ,HeadCode
	                                  ,HeadSubCode	  
	                                  ,HeadDescription	
                                from SBP_HeadCodeEntry
                                WHERE HeadName IS NOT NULL";
            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(Query);
            }
            catch
            {
                throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dt;
        }

        public DataTable IncomeSummeryReportData(DateTime FromDate, DateTime ToDate)
        {
            DataTable dt;
            string querySP = @"Rpt_SBP_TotalIncome_withinDateRange";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@fromDate", SqlDbType.DateTime, FromDate);
                _dbConnection.AddParameter("@ToDate", SqlDbType.DateTime, ToDate);
                dt = _dbConnection.ExecuteProQuery(querySP);
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

        public DataTable IncomeSummeryForWithdraw(DateTime ToDate)
        {
            DataTable dt;
            string querySP = @"Rpt_SBP_Income_Balance_ForWithdrawal";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@ToDate", SqlDbType.DateTime, ToDate);
                dt = _dbConnection.ExecuteProQuery(querySP);
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
        public DataTable GetWithdrawalHistory()
        {
            DataTable dt;
            string query = @"SELECT Top 3
                                   [Withdrawdate] as 'Withdraw_Date'
                                  ,[InterestAmount] as 'Interest'
                                  ,[CommissionAmount] as 'Commission'
                                  ,[IPOChargeAmount] as 'IPO_Charge'
                                  ,[BOOpChargeAmount] as 'BO_OP_Charge'
                                  ,[BOClChargeAmount] as 'BO_Cl_Charge'
                                  ,[TaxCertChargeAmount] as 'Tax_Cert._Charge'
                                  ,[TransmissionChargeAmount] as 'Trans._Charge'
                                  ,[DemeteChargeAmount] as 'Demete_Charge'
                                  ,[CustodianChargeAmount] as 'Cust._Charge'
                                  ,[BankIntAmount] as 'Bank_Interest'
                                  ,[TaxCerCharge_Bank] as 'Tax_Cert_Bank'
                                  ,[TransmissionCharge_Bank] as 'Trans._Charge_Bank'
                                  ,[DemetCharge_Bank] as 'Demete_Charge_Bank'
                                  ,[CustodianCharge_Bank] as 'Cust._Charge_Bank'
                                  ,[PaymentMedia] as 'Media'  
                                  ,[BankName] as 'Bank_Name'
                                  ,[ChequeNo] as 'Cheque_No'    
                                  ,[PayDate] as 'Pay_Date'
                                  ,[userName] as 'Entry_By'
                              FROM [SBP_Database].[dbo].[SBP_HeadWiseWithdrawalHistory]
                              ORDER BY WithdrawID desc";
            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(query);
                return dt;
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

        public void saveInterestWithdraw_SBP_Payment(double NewInterest)
        {
            string query = @"INSERT INTO [SBP_Database].[dbo].[SBP_Payment]
                               ([Cust_Code]
                               ,[Amount]
                               ,[Received_Date]
                               ,[Deposit_Withdraw]
                               ,[Trans_Reason]
                               ,[Remarks]
                               ,[Entry_Date]
                               ,[Entry_By]
                               ,[Entry_Branch_ID]
                               ,[Head_Code]
                               )
                         VALUES
                               ('95'
                               ," + NewInterest + @"
                               ,'" + GlobalVariableBO._currentServerDate + @"'
                               ,'Withdraw'        
                               ,'95 To Authority'
                               ,'Interest Withdraw by Authority'
                               ,'" + GlobalVariableBO._currentServerDate + @"'
                               ,'" + GlobalVariableBO._userName + @"'
                               ," + GlobalVariableBO._branchId + @"
                               ,'I005')";
            try
            {
                //_dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //finally
            //{
            //_dbConnection.CloseDatabase();
            //}
        }

        public void saveCommission_SBP_Transactions(double NewCommission, string VoucherNo)
        {
            string query = @"INSERT INTO [SBP_Database].[dbo].[SBP_Transactions]
                                       (           
                                        [BuySellFlag]           
                                       ,[EventDate]         
                                       ,[Commission]          
                                       ,[Head_Code]
                                       ,[VoucherNo])
                                 VALUES
                                       (
                                        'W'           
                                       ,'" + GlobalVariableBO._currentServerDate.ToShortDateString() + @"'    
                                       ," + NewCommission + @"          
                                       ,'I001'
                                       ,'" + VoucherNo + @"')";
            try
            {
                //_dbConnection.ConnectDatabase(); Convert.ToDateTime(GlobalVariableBO._currentServerDate.ToString("yyyy-MM-dd"))  CONVERT(VARCHAR(10),+ GlobalVariableBO._currentServerDate +,120)
                _dbConnection.ExecuteNonQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //finally
            //{
            //    _dbConnection.CloseDatabase();
            //}
        }
        public void Test_Commission(double NewCommission,DateTime ConvertedDate)
        {
            string query = @"INSERT INTO [SBP_Database].[dbo].[SBP_Transactions]
                                       (           
                                        [BuySellFlag]           
                                       ,[EventDate]         
                                       ,[Commission]          
                                       ,[Head_Code])
                                 VALUES
                                       (
                                        'W'           
                                       ,'" + ConvertedDate + @"'        
                                       ," + NewCommission + @"       
                                       ,'I001')";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(query);
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
        public void saveIPOTotaCharge_SBP_IPO_Application_BasicInfo(double NewIPOCharge, string vNo, string typeName, string typeID)
        {
//            string query = @"INSERT INTO [SBP_Database].[dbo].[SBP_IPO_Application_BasicInfo]
//                                   (
//                                    [TotalAmount]           
//                                   ,[Remarks]           
//                                   ,[Entry_Date]
//                                   ,[Entry_Branch_ID]
//                                   ,[Entry_By]
//                                   ,[Head_Code]
//                                   ,[VoucherNo]
//                                    )
//                             VALUES
//                                   (
//                                    " + NewIPOCharge + @"           
//                                   ,'IPO Charge Withdraw by Authority'         
//                                   ,CONVERT(VARCHAR(10),GETDATE(),120)
//                                   ," + GlobalVariableBO._branchId + @"
//                                   ,'" + GlobalVariableBO._userName + @"'
//                                   ,'I002'
//                                   ,'" + vNo + @"'
//                                    )";

            string query = @"INSERT INTO [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction]
                                       ([Received_Date]
                                       ,[Money_TransactionType_ID]
                                       ,[Money_TransactionType_Name]
                                       ,[Deposit_Withdraw]
                                       ,[Amount]
                                       ,[Voucher_No]
                                       ,[Trans_Reason]           
                                       ,[Entry_Branch_ID]
                                       ,[Entry_Date]
                                       ,[Entry_By]
                                       ,[Head_Code]
                                      )
                                 VALUES
                                       (CONVERT(VARCHAR(10),GETDATE(),120)
                                       ,'" + typeID + @"'
                                       ,'" + typeName + @"'
                                       ,'Withdraw'
                                       ," + NewIPOCharge + @"
                                       ,'" + vNo + @"'
                                       ,'IPO Charge Withdraw by Authority'         
                                       ," + GlobalVariableBO._branchId + @"
                                       ,CONVERT(VARCHAR(10),GETDATE(),120)
                                       ,'" + GlobalVariableBO._userName + @"'
                                       ,'I002'
                                       )";

            try
            {
                //_dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //finally
            //{
            //    _dbConnection.CloseDatabase();
            //}
        }
        public void saveBOOpeningCharge_SBP_Payment_OOC(double NewBOOpeningCharge, string vNo)
        {
            string query = @"INSERT INTO [SBP_Database].[dbo].[SBP_Payment_OOC]
                                   (
                                    [OCC_ID]         
                                   ,[Amount]          
                                   ,[Remarks]
                                   ,[Voucher]
                                   ,[Branch_ID]
                                   ,[Entry_Date]
                                   ,[Entry_By]           
                                   ,[Head_Code])
                             VALUES
                                   (2
                                   ," + NewBOOpeningCharge + @"
                                   ,'BO Op. Charge Withdraw by Authority'
                                   ,'" + vNo + @"'
                                   ," + GlobalVariableBO._branchId + @"
                                   ,'" + GlobalVariableBO._currentServerDate + @"'
                                   ,'" + GlobalVariableBO._userName + @"'
                                   ,'I007i')";
            try
            {
                //_dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //finally
            //{
            //    _dbConnection.CloseDatabase();
            //}
        }
        public void saveBOClosingCharge_SBP_Payment_OOC(double NewBOCloseCharge, string vNo)
        {
            string query = @"INSERT INTO [SBP_Database].[dbo].[SBP_Payment_OOC]
                                   (
                                    [OCC_ID]         
                                   ,[Amount]          
                                   ,[Remarks]
                                   ,[Voucher]
                                   ,[Branch_ID]
                                   ,[Entry_Date]
                                   ,[Entry_By]           
                                   ,[Head_Code])
                             VALUES
                                   (9
                                   ," + NewBOCloseCharge + @"
                                   ,'BO Cl. Charge Withdraw by Authority'
                                   ,'" + vNo + @"'
                                   ," + GlobalVariableBO._branchId + @"
                                   ,'" + GlobalVariableBO._currentServerDate + @"'
                                   ,'" + GlobalVariableBO._userName + @"'
                                   ,'I007ii')";
            try
            {
                //_dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //finally
            //{
            //    _dbConnection.CloseDatabase();
            //}
        }
        public void saveTaxCertificateCharge_SBP_Payment_OOC(double NewTaxCharge, string vNo)
        {
            string query = @"INSERT INTO [SBP_Database].[dbo].[SBP_Payment_OOC]
                                   (
                                    [OCC_ID]         
                                   ,[Amount]          
                                   ,[Remarks]
                                   ,[Voucher]
                                   ,[Branch_ID]
                                   ,[Entry_Date]
                                   ,[Entry_By]           
                                   ,[Head_Code])
                             VALUES
                                   (1
                                   ," + NewTaxCharge + @"
                                   ,'Tax Cer. Charge Withdraw by Authority'
                                   ,'" + vNo + @"'
                                   ," + GlobalVariableBO._branchId + @"
                                   ,'" + GlobalVariableBO._currentServerDate + @"'
                                   ,'" + GlobalVariableBO._userName + @"'
                                   ,'I007iii')";
            try
            {
                //_dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //finally
            //{
            //    _dbConnection.CloseDatabase();
            //}
        }
        public void saveTransmissionCharge_SBP_Payment_OOC(double NewTransmissionCharge, string vNo)
        {
            string query = @"INSERT INTO [SBP_Database].[dbo].[SBP_Payment_OOC]
                                   (
                                    [OCC_ID]         
                                   ,[Amount] 
                                   ,[Voucher]         
                                   ,[Remarks]
                                   ,[Branch_ID]
                                   ,[Entry_Date]
                                   ,[Entry_By]           
                                   ,[Head_Code])
                             VALUES
                                   (7
                                   ," + NewTransmissionCharge + @"
                                   ,'" + vNo + @"'
                                   ,'Trns. Charge Withdraw by Authority'
                                   ," + GlobalVariableBO._branchId + @"
                                   ,'" + GlobalVariableBO._currentServerDate + @"'
                                   ,'" + GlobalVariableBO._userName + @"'
                                   ,'I007v')";
            try
            {
                //_dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //finally
            //{
            //    _dbConnection.CloseDatabase();
            //}
        }
        public void saveDemetCharge_SBP_Payment_OOC(double NewDemetCharge, string vNo)
        {
            string query = @"INSERT INTO [SBP_Database].[dbo].[SBP_Payment_OOC]
                                   (
                                    [OCC_ID]         
                                   ,[Amount] 
                                   ,[Voucher]             
                                   ,[Remarks]
                                   ,[Branch_ID]
                                   ,[Entry_Date]
                                   ,[Entry_By]           
                                   ,[Head_Code])
                             VALUES
                                   (5
                                   ," + NewDemetCharge + @"
                                   ,'" + vNo + @"'
                                   ,'Demet Charge Withdraw by Authority'
                                   ," + GlobalVariableBO._branchId + @"
                                   ,'" + GlobalVariableBO._currentServerDate + @"'
                                   ,'" + GlobalVariableBO._userName + @"'
                                   ,'I007iv')";
            try
            {
                //_dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //finally
            //{
            //    _dbConnection.CloseDatabase();
            //}
        }

        public void saveCustodianCharge_SBP_Payment_OOC(double NewCustodian, string vNo)
        {
            string query = @"INSERT INTO [SBP_Database].[dbo].[SBP_Payment_OOC]
                                   (
                                    [OCC_ID]         
                                   ,[Amount] 
                                   ,[Voucher]             
                                   ,[Remarks]
                                   ,[Branch_ID]
                                   ,[Entry_Date]
                                   ,[Entry_By]           
                                   ,[Head_Code])
                             VALUES
                                   (6
                                   ," + NewCustodian + @"
                                   ,'" + vNo + @"'
                                   ,'Custodian Charge Withdraw by Authority'
                                   ," + GlobalVariableBO._branchId + @"
                                   ,'" + GlobalVariableBO._currentServerDate + @"'
                                   ,'" + GlobalVariableBO._userName + @"'
                                   ,'I007vi')";
            try
            {
                //_dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //finally
            //{
            //    _dbConnection.CloseDatabase();
            //}
        }
        public void saveBankInterestCharge_SBP_Payment_OOC(double NewBankInterest, string vNo)
        {
            string query = @"INSERT INTO [SBP_Database].[dbo].[SBP_IncomeEntry]
                                       (
                                        [RcvFrom]
                                       ,[VoucherSLNo]
                                       ,[Dr_Cr]
                                       ,[Dr_Amount]
                                       ,[Cr_Amount]
                                       ,[Purpose]
                                       ,[TrnType]
                                       ,[AccHead]
                                       ,[AccSubHead]
                                       ,[BrokerBranchID]
                                       ,[EntryDate]
                                       ,[EntryBy]
                                       )
                                 VALUES
                                       ('Authority'
                                       ,'" + vNo + @"'
                                       ,'Withdraw'
                                       ,0.00
                                       ," + NewBankInterest + @"
                                       ,'Bank Interest Withdraw by Authority'
                                       ,'Cash'
                                       ,'I004'
                                       ,'I004i'
                                       ," + GlobalVariableBO._branchId + @"
                                       ,'" + GlobalVariableBO._currentServerDate + @"'
                                       ,'" + GlobalVariableBO._userName + @"')";
            try
            {
                //_dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //finally
            //{
            //    _dbConnection.CloseDatabase();
            //}
        }
        public void SaveTaxCerCharge_Bank(double NewTaxCarge_Bank, string vNo, string trnType)
        {
            string query = @"INSERT INTO [SBP_Database].[dbo].[SBP_Payment]
                                           ([Amount]
                                           ,[Received_Date]
                                           ,[Payment_Media]  
                                           ,[Deposit_Withdraw]
                                           ,[Voucher_Sl_No]
                                           ,[Trans_Reason]
                                           ,[Remarks]
                                           ,[Entry_Date]
                                           ,[Entry_By]
                                           ,[Entry_Branch_ID]
                                           ,[Head_Code]
                                           ,[HeadSubCode])
                                     VALUES
                                           (" + NewTaxCarge_Bank + @"
                                           ,'" + DateTime.Now.Date.ToString("yyyy-MM-dd") + @"'
                                           ,'" + trnType + @"'
                                           ,'Withdraw'
                                           ,'" + vNo + @"'
                                           ,'To Authority'
                                           ,'Int.Bank Withdraw by Authority'
                                           ,'" + DateTime.Now.Date + @"'
                                           ,'" + GlobalVariableBO._userName + @"'
                                           ," + GlobalVariableBO._branchId + @"
                                           ,'I008'
                                           ,'I008i')";

            try
            {
                //_dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //finally
            //{
            //    _dbConnection.CloseDatabase();
            //}
        }

        
        public void SaveWithdrawHistory(HeadWiseWithdrawalBO HBO)
        {        
            string query = @"INSERT INTO [SBP_Database].[dbo].[SBP_HeadWiseWithdrawalHistory]
                                           ([VoucharNo]
                                           ,[Withdrawdate]
                                           ,[InterestAmount]
                                           ,[CommissionAmount]
                                           ,[IPOChargeAmount]
                                           ,[BOOpChargeAmount]
                                           ,[BOClChargeAmount]
                                           ,[TaxCertChargeAmount]
                                           ,[TransmissionChargeAmount]
                                           ,[DemeteChargeAmount]
                                           ,[CustodianChargeAmount]
                                           ,[BankIntAmount]
                                           ,[TaxCerCharge_Bank]
                                           ,[TransmissionCharge_Bank]
                                           ,[DemetCharge_Bank]
                                           ,[CustodianCharge_Bank]
                                           ,[PaymentMedia]
                                           ,[BankName]
                                           ,[ChequeNo]
                                           ,[PayDate]
                                           ,[userName]
                                           ,[EntryDate])
                                     VALUES
                                           ('" + HBO.VoucherNo + @"'
                                           ,CONVERT(VARCHAR(10),GETDATE(),120)
                                           ," + HBO.Interest + @"
                                           ," + HBO.Commission + @"
                                           ," + HBO.IPOCharge + @"
                                           ," + HBO.BOOpeningCharge + @"
                                           ," + HBO.BOCloseCharge + @"
                                           ," + HBO.TaxCharge + @"
                                           ," + HBO.TransmissionCharge + @"
                                           ," + HBO.DemetCharge + @"
                                           ," + HBO.Custodian + @"
                                           ," + HBO.BankInteres + @"  
                                           ," + HBO.TaxChargeBank + @"                                       
                                           ," + HBO.TransmissionChargeBank + @"
                                           ," + HBO.DemetChargeBank + @"
                                           ," + HBO.CustodianChargeBank + @"
                                           ,'" + HBO.PaymentMedia + @"'
                                           ,'" + HBO.WBankName + @"'
                                           ,'" + HBO.WChequeNo + @"'
                                           ," + HBO.WPayDate+ @"
                                           ,'" + HBO.UserName + @"'
                                           ,'" + HBO.EntryDate + @"')";          
            try
            {
                //_dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //finally
            //{
            //    _dbConnection.CloseDatabase();
            //}
        }

        public DataTable GetOpenIPOCompanySessionName()
        {
            DataTable dt = new DataTable();
            string query = @"select ID,IPOSession_Name 
                                from SBP_IPO_Session
                                where Status IN (0,1,5) and IPOSession_Name !=''";
            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(query);
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

        public DataTable VoucherDuplicacyCheck(string vNo, DateTime time)
        {
            DataTable dt = new DataTable();
            string query = @"SELECT * 
                                FROM SBP_HeadWiseWithdrawalHistory
                                WHERE VoucharNo='" + vNo + @"' AND Withdrawdate='" + time + @"'";
            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(query);
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



        #region Individual_Income_ForDashboard

        public double Dashboard_InterestBalance(string toDate)
        {
            DataTable dt;
            double bal = 0;

            //            string query = @"SELECT 
            //	                            DISTINCT(ROUND(ISNULL((select SUM(Amount) as 'Deposit_Interest'
            //	                            FROM SBP_Payment													
            //	                            where cust_Code=95		
            //	                            and CONVERT(VARCHAR(10),Received_Date,120) <= CONVERT(VARCHAR(10),'" + toDate + @"',120)
            //	                            and Deposit_Withdraw='Deposit') 
            //                                -
            //	                            (select ISNULL(sum(Amount),0) as 'Withdraw_Interest'
            //	                            from [SBP_Payment]
            //	                            where cust_Code=95 and Deposit_Withdraw='Withdraw'
            //	                            and Head_Code='I005' and Trans_Reason='95 To Authority' And Remarks='Interest Withdraw by Authority'
            //	                            and CONVERT(VARCHAR(10),Entry_Date,120) <= CONVERT(VARCHAR(10),'" + toDate + @"',120)),0),2)) AS 'InterestBal'
            //
            //                            FROM SBP_Payment";

            string query = @"SELECT(SELECT ISNULL(SUM(Amount),0)   
                            FROM SBP_Payment
                            WHERE Cust_Code=95
                            AND Deposit_Withdraw= 'Deposit')-
                                                        (SELECT ISNULL(SUM(Amount),0)   
                                                        FROM SBP_Payment
                                                        WHERE Deposit_Withdraw='Withdraw'
                                                        AND Payment_Media = 'TR'
                                                        AND Trans_Reason LIKE '95 To %')-
			                                                                        (SELECT ISNULL(SUM(Amount),0)   
			                                                                        FROM SBP_Payment
			                                                                        WHERE Cust_Code=95 
			                                                                        AND Deposit_Withdraw='Withdraw'
			                                                                        AND Head_Code='I005' 
			                                                                        AND Trans_Reason='95 To Authority' 
			                                                                        AND Remarks='Interest Withdraw by Authority')-
																							                                (SELECT ISNULL(SUM(Amount),0)   
																							                                FROM SBP_Payment
																							                                WHERE Voucher_Sl_No='CB-IC'
																							                                AND Deposit_Withdraw='Withdraw')";
            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(query);
                if (dt != null)
                {
                    bal = Convert.ToDouble(dt.Rows[0][0].ToString());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return bal;
        }

        public double Dashboard_CommissionBalance(string toDate)
        {
            DataTable dt;
            double bal = 0;
            string query = @"SELECT DISTINCT

	                            ROUND(
		                            (SELECT ISNULL(SUM(Commission),0)
		                            FROM SBP_Transactions
		                            WHERE BuySellFlag !='W' and Head_Code IS NULL                                            
		                            And CONVERT(VARCHAR(10),EventDate,120) <= CONVERT(VARCHAR(10),'" + toDate + @"',120)) 
		                            -
		                            (SELECT ISNULL(SUM(Commission),0)
		                            FROM SBP_Transactions
		                            WHERE BuySellFlag='W' and Head_Code='I001'
		                            And CONVERT(VARCHAR(10),EventDate,120) <= CONVERT(VARCHAR(10),'" + toDate + @"',120)) 
	                            ,2)AS 'CommissionBalance'

                            FROM SBP_Transactions";
            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(query);
                if (dt != null)
                {
                    bal = Convert.ToDouble(dt.Rows[0][0].ToString());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return bal;
        }

        public double Dashboard_IPOChargeBalance(string toDate)
        {
            DataTable dt;
            double bal = 0;
            string query = @"SELECT  DISTINCT

                                    ROUND(

			                                ISNULL((SELECT (COUNT(Cust_Code)*(SELECT Ch_Min_Fee FROM SBP_Ch_Def_All WHERE Ch_ID=14))
			                                FROM SBP_IPO_Application_BasicInfo  
			                                WHERE Application_Satus IN (1,3,4) 
			                                AND CONVERT(VARCHAR(10),Application_Date,120) <=CONVERT(VARCHAR(10),'" + toDate + @"',120)),0)
			                                +

			                                ISNULL((SELECT COUNT(Cust_Code) * (Select Ch_Min_Fee From SBP_Ch_Def_All where Ch_ID=15)
			                                FROM SBP_IPO_Application_BasicInfo
			                                WHERE Application_Satus=4
			                                AND CONVERT(VARCHAR(10),AppStatus_UpdatedDate,120) <=CONVERT(VARCHAR(10),'" + toDate + @"',120)),0)
			                                +	
			                                ISNULL((SELECT SUM(TotalAmount) 
			                                FROM SBP_IPO_Application_BasicInfo
			                                WHERE ChannelType='Manual'
			                                AND Application_Satus=1
			                                And CONVERT(VARCHAR(10),Application_Date,120)<=CONVERT(VARCHAR(10),'" + toDate + @"',120)),0)   
			                                -
			                                ISNULL((select isnull(ROUND(sum(TotalAmount),2),0)
			                                from SBP_IPO_Application_BasicInfo
			                                where Head_Code='I002' and Remarks='IPO Charge Withdraw by Authority'
			                                and CONVERT(VARCHAR(10),Entry_Date,120) <= CONVERT(VARCHAR(10),'" + toDate + @"',120)),0)

                                        ,2)AS 'IPOChargeBalance'

                                FROM SBP_IPO_Application_BasicInfo";
            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(query);
                if (dt != null)
                {
                    bal = Convert.ToDouble(dt.Rows[0][0].ToString());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return bal;
        }

        public double Dashboard_BO_OpChargeBalance(string toDate)
        {
            DataTable dt;
            double bal = 0;
//            string query = @"SELECT DISTINCT
//		                            ROUND(
//				                            (SELECT ISNULL(SUM(Amount),0)
//				                            FROM SBP_Payment_OOC
//				                            WHERE status = 1 AND  OCC_ID=2 
//				                            AND CONVERT(VARCHAR(10),Status_Date,120) <= CONVERT(VARCHAR(10),'" + toDate + @"',120))
//				                            -
//				                            (SELECT ISNULL(SUM(Amount),0)
//				                            FROM SBP_Payment_OOC
//				                            WHERE OCC_ID=2 AND Head_Code='I007i' 
//				                            AND Remarks='BO Op. Charge Withdraw by Authority'
//				                            AND CONVERT(VARCHAR(10),Entry_Date,120) <= CONVERT(VARCHAR(10),'" + toDate + @"',120))
//			                            ,2) AS 'BO_OpChargeBalance'	
//                            FROM SBP_Payment_OOC";

            string query = @"SELECT DISTINCT
		                            ROUND(
				                            (SELECT ISNULL(SUM(Amount),0)
				                            FROM SBP_Payment_OOC
				                            WHERE status = 1 AND  OCC_ID=2 
				                            AND CONVERT(VARCHAR(10),Status_Date,120) <= CONVERT(VARCHAR(10),'" + toDate + @"',120))
				                            +
				                            (SELECT ISNULL(SUM(Dr_Amount),0)
				                            FROM SBP_IncomeEntry  
											WHERE AccSubHead = 'I007i'                                     
											AND Dr_Cr = 'Deposit'
											AND Status = 'Approved'
											AND CONVERT(VARCHAR(10),UpdateDate,120) <= CONVERT(VARCHAR(10),'" + toDate + @"',120))
				                            -
				                            (SELECT ISNULL(SUM(Amount),0)
				                            FROM SBP_Payment_OOC
				                            WHERE OCC_ID=2 AND Head_Code='I007i' 
				                            AND Remarks='BO Op. Charge Withdraw by Authority'
				                            AND CONVERT(VARCHAR(10),Entry_Date,120) <= CONVERT(VARCHAR(10),'" + toDate + @"',120))
			                            ,2) AS 'BO_OpChargeBalance'	
                            FROM SBP_Payment_OOC    ";
            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(query);
                if (dt != null)
                {
                    bal = Convert.ToDouble(dt.Rows[0][0].ToString());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return bal;
        }

        public double Dashboard_BO_CloseChargeBalance(string toDate)
        {
            DataTable dt;
            double bal = 0;
//            string query = @"SELECT DISTINCT
//
//		                            ROUND(
//				                            (SELECT ISNULL(SUM(Amount),0)
//				                            FROM SBP_Payment_OOC	
//				                            WHERE status = 1 AND OCC_ID=9 
//				                            AND CONVERT(VARCHAR(10),Status_Date,120) <= CONVERT(VARCHAR(10),'" + toDate + @"',120))	
//				                            -
//				                            (SELECT ISNULL(SUM(Amount),0)
//				                            FROM SBP_Payment_OOC
//				                            WHERE OCC_ID=9 AND Head_Code='I007ii' 
//				                            AND Remarks='BO Cl. Charge Withdraw by Authority'
//				                            AND CONVERT(VARCHAR(10),Entry_Date,120) <= CONVERT(VARCHAR(10),'" + toDate + @"',120))
//			                            ,2) AS 'BO_ClChargeBalance'
//                            		
//                            FROM SBP_Payment_OOC";

            string query = @"
                               SELECT DISTINCT

		                                ROUND(
				                                (SELECT ISNULL(SUM(Amount),0)
				                                FROM SBP_Payment_OOC	
				                                WHERE status = 1 AND OCC_ID=9 
				                                AND CONVERT(VARCHAR(10),Status_Date,120) <= CONVERT(VARCHAR(10),'" + toDate + @"',120))	
				                               +
				                                (select ISNULL(SUM(Dr_Amount),0)
				                                FROM SBP_IncomeEntry  
											    WHERE AccSubHead = 'I007ii'                                     
												    AND Dr_Cr = 'Deposit'
												    AND Status = 'Approved'
												    AND UpdateDate <= CONVERT(VARCHAR(10),'" + toDate + @"',120))	
				                                -
				                                (SELECT ISNULL(SUM(Amount),0)
				                                FROM SBP_Payment_OOC
				                                WHERE OCC_ID=9 AND Head_Code='I007ii' 
				                                AND Remarks='BO Cl. Charge Withdraw by Authority'
				                                AND CONVERT(VARCHAR(10),Entry_Date,120) <= CONVERT(VARCHAR(10),'" + toDate + @"',120))	
			                                ,2) AS 'BO_ClChargeBalance'
                                		
                                FROM SBP_Payment_OOC";
            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(query);
                if (dt != null)
                {
                    bal = Convert.ToDouble(dt.Rows[0][0].ToString());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return bal;
        }

        public double Dashboard_TaxChargeBalance(string toDate)
        {
            DataTable dt;
            double bal = 0;
            string query = @"SELECT  DISTINCT

                                     ROUND(
			                                (SELECT ISNULL(SUM(Amount),0)
			                                FROM SBP_Payment_OOC	
			                                WHERE status=1 AND OCC_ID=1 
			                                AND CONVERT(VARCHAR(10),Status_Date,120) <= CONVERT(VARCHAR(10),'" + toDate + @"',120) )
		                                   +
		                                    (select ISNULL(SUM(Dr_Amount),0)
		                                    FROM SBP_IncomeEntry  
									        WHERE AccSubHead = 'I007iii'                                     
										        AND Dr_Cr = 'Deposit'
										        AND Status = 'Approved'
										        AND UpdateDate <= CONVERT(VARCHAR(10),'" + toDate + @"',120))
			                                -
			                                (SELECT ISNULL(SUM(Amount),0)
			                                FROM SBP_Payment_OOC
			                                WHERE OCC_ID=1 AND Head_Code='I007iii' 
			                                AND Remarks='Tax Cer. Charge Withdraw by Authority'
			                                AND CONVERT(VARCHAR(10),Entry_Date,120) <= CONVERT(VARCHAR(10),'" + toDate + @"',120))
	                                    ,2)

                            FROM SBP_Payment_OOC";
            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(query);
                if (dt != null)
                {
                    bal = Convert.ToDouble(dt.Rows[0][0].ToString());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return bal;
        }

        public double Dashboard_TransmissionChargeBalance(string toDate)
        {
            DataTable dt;
            double bal = 0;
            string query = @"SELECT DISTINCT

                                 ROUND((SELECT ISNULL(SUM(Amount),0)
			                            FROM SBP_Payment_OOC	
			                            WHERE status=1 AND OCC_ID=7 
			                            AND CONVERT(VARCHAR(10),Status_Date,120) <= CONVERT(VARCHAR(10),'" + toDate + @"',120))
                                        +
	                                    (select ISNULL(SUM(Dr_Amount),0)
	                                    FROM SBP_IncomeEntry  
								        WHERE AccSubHead = 'I007v'                                     
									        AND Dr_Cr = 'Deposit'
									        AND Status = 'Approved'
									        AND UpdateDate <= CONVERT(VARCHAR(10),'" + toDate + @"',120))
			                            -
			                            (SELECT ISNULL(SUM(Amount),0)
			                            FROM SBP_Payment_OOC
			                            WHERE OCC_ID=7 AND Head_Code='I007v' 
			                            AND Remarks='Trns. Charge Withdraw by Authority'
			                            AND CONVERT(VARCHAR(10),Entry_Date,120) <= CONVERT(VARCHAR(10),'" + toDate + @"',120))
	                                ,2)
                            	    
                            FROM SBP_Payment_OOC";
            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(query);
                if (dt != null)
                {
                    bal = Convert.ToDouble(dt.Rows[0][0].ToString());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return bal;
        }

        public double Dashboard_DemetChargeBalance(string toDate)
        {
            DataTable dt;
            double bal = 0;
            string query = @"SELECT DISTINCT

	                            ROUND(
			                            (SELECT ISNULL(SUM(Amount),0)
			                            FROM SBP_Payment_OOC
			                            WHERE status=1 AND OCC_ID=5	
			                            AND CONVERT(VARCHAR(10),Status_Date,120) <= CONVERT(VARCHAR(10),'" + toDate + @"',120))
                                        +
	                                    (select ISNULL(SUM(Dr_Amount),0)
	                                    FROM SBP_IncomeEntry  
								        WHERE AccSubHead = 'I007iv'                                     
									        AND Dr_Cr = 'Deposit'
									        AND Status = 'Approved'
									        AND UpdateDate <= CONVERT(VARCHAR(10),'" + toDate + @"',120))
			                            -
			                            (SELECT ISNULL(SUM(Amount),0)
			                            FROM SBP_Payment_OOC
			                            WHERE OCC_ID=5 AND Head_Code='I007iv' 
			                            AND Remarks='Demet Charge Withdraw by Authority'
			                            AND CONVERT(VARCHAR(10),Entry_Date,120) <= CONVERT(VARCHAR(10),'" + toDate + @"',120))
		                            ,2) AS 'DemetChargeBalance'

                            FROM SBP_Payment_OOC";
            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(query);
                if (dt != null)
                {
                    bal = Convert.ToDouble(dt.Rows[0][0].ToString());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return bal;
        }

        public double Dashboard_CustodianChargeBalance(string toDate)
        {
            DataTable dt;
            double bal = 0;
            string query = @"SELECT DISTINCT

	                            ROUND(
			                            (SELECT ISNULL(SUM(Amount),0)
			                            FROM SBP_Payment_OOC
			                            WHERE status=1 AND OCC_ID=6	
			                            AND CONVERT(VARCHAR(10),Status_Date,120) <= CONVERT(VARCHAR(10),'" + toDate + @"',120))
                                        +
	                                    (select ISNULL(SUM(Dr_Amount),0)
	                                    FROM SBP_IncomeEntry  
								        WHERE AccSubHead = 'I007vi'                                     
									        AND Dr_Cr = 'Deposit'
									        AND Status = 'Approved'
									        AND UpdateDate <= CONVERT(VARCHAR(10),'" + toDate + @"',120))
			                            -
			                            (SELECT ISNULL(SUM(Amount) ,0)
			                            FROM SBP_Payment_OOC
			                            WHERE OCC_ID=6 AND Head_Code='I007vi' 
			                            AND Remarks='Custodian Charge Withdraw by Authority'
			                            AND CONVERT(VARCHAR(10),Entry_Date,120) <= CONVERT(VARCHAR(10),'" + toDate + @"',120))
	                               ,2) AS 'CustodianChargeBal'
                            	
                            FROM SBP_Payment_OOC";
            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(query);
                if (dt != null)
                {
                    bal = Convert.ToDouble(dt.Rows[0][0].ToString());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return bal;
        }
        public double Dashboard_BankInterestChargeBalance(string toDate)
        {
            DataTable dt;
            double bal = 0;
            string query = @"SELECT DISTINCT

	                            ROUND(
			                            (SELECT ISNULL(SUM(Dr_Amount),0)
			                            FROM SBP_IncomeEntry	
			                            WHERE AccSubHead='I004i' AND Status='Approved' 
			                            AND CONVERT(VARCHAR(10),UpdateDate,120)<= CONVERT(VARCHAR(10),'" + toDate + @"',120))
			                            -
			                            (SELECT ISNULL(SUM(Cr_Amount),0)
			                            from SBP_IncomeEntry
			                            WHERE RcvFrom='Authority' AND Dr_Cr='Withdraw' AND Dr_Amount=0.00 AND AccSubHead='I004i'
			                            AND Purpose='Bank Interest Withdraw by Authority'
			                            AND CONVERT(VARCHAR(10),EntryDate,120) <= CONVERT(VARCHAR(10),'" + toDate + @"',120))
	                               ,2)
                            		
                            FROM SBP_IncomeEntry";
            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(query);
                if (dt != null)
                {
                    bal = Convert.ToDouble(dt.Rows[0][0].ToString());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return bal;
        }

        public double Dashboard_TaxCharge_Bank_Balance(string toDate)
        {
            DataTable dt;
            double bal = 0;
            string query = @"SELECT
                                (SELECT ISNULL(SUM(Amount),0)
	                                FROM SBP_Payment
	                                WHERE Deposit_Withdraw = 'Withdraw'
		                                AND Voucher_Sl_No = 'OCC-C'
		                                AND Trans_Reason = 'Tex Certificate')+
				                                                (SELECT ISNULL(SUM(Dr_Amount),0)
					                                                FROM SBP_IncomeEntry  
					                                                WHERE Dr_Cr = 'Deposit'
						                                                AND AccHead = 'I008'
						                                                AND AccSubHead = 'I008i'
						                                                AND Status = 'Approved')-
								                                                        (--Withdraw
								                                                        SELECT ISNULL(SUM(Amount),0) AS 'Total_Withdraw'
								                                                        FROM SBP_Payment
								                                                        WHERE Deposit_Withdraw='Withdraw' 
								                                                          AND Trans_Reason='To Authority' 
								                                                          AND Remarks='Int.Bank Withdraw by Authority' 
								                                                          AND Head_Code='I008' AND HeadSubCode='I008i')	";
            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(query);
                if (dt != null)
                {
                    bal = Convert.ToDouble(dt.Rows[0][0].ToString());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return bal;
        }
        
        #endregion

        #region Income_Ledger_Report

        public DataTable LedgerReport_IPOCharge(string FDate, string TDate)
        {
            DataTable dt = new DataTable();
            string query = @"IncomeLedger_IPOCharge";

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.ClearParameters();
                _dbConnection.AddParameter("@FromDate", SqlDbType.DateTime, FDate);
                _dbConnection.AddParameter("@ToDate", SqlDbType.DateTime, TDate);
                dt = _dbConnection.ExecuteProQuery(query);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dt;
        }

        public DataTable LedgerReport_BOOpeningCharge(string FDate, string TDate)
        {
            DataTable dt = new DataTable();
            string query = @"IncomeLedger_BOOpeningCharge";

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.ClearParameters();
                _dbConnection.AddParameter("@FromDate", SqlDbType.DateTime, FDate);
                _dbConnection.AddParameter("@ToDate", SqlDbType.DateTime, TDate);
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
        public DataTable LedgerReport_BOClosingCharge(string FDate, string TDate)
        {
            DataTable dt = new DataTable();
            string query = @"IncomeLedger_BOClosingCharge";

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.ClearParameters();
                _dbConnection.AddParameter("@FromDate", SqlDbType.DateTime, FDate);
                _dbConnection.AddParameter("@ToDate", SqlDbType.DateTime, TDate);
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
        public DataTable LedgerReport_Commission(string FDate, string TDate)
        {
            DataTable dt = new DataTable();
            string query = @"IncomeLedger_Commission";

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.ClearParameters();
                _dbConnection.AddParameter("@FromDate", SqlDbType.DateTime, FDate);
                _dbConnection.AddParameter("@ToDate", SqlDbType.DateTime, TDate);
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

        public DataTable LedgerReport_Interest(string FDate, string TDate)
        {
            DataTable dt = new DataTable();
            string query = @"IncomeLedger_Interest";

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.ClearParameters();
                _dbConnection.AddParameter("@FromDate", SqlDbType.DateTime, FDate);
                _dbConnection.AddParameter("@ToDate", SqlDbType.DateTime, TDate);
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

        public DataTable LedgerReport_TaxCharge(string FDate, string TDate)
        {
            DataTable dt = new DataTable();
            string query = @"IncomeLedger_TaxCharge";

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.ClearParameters();
                _dbConnection.AddParameter("@FromDate", SqlDbType.DateTime, FDate);
                _dbConnection.AddParameter("@ToDate", SqlDbType.DateTime, TDate);
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

        public DataTable LedgerReport_TransmissionCharge(string FDate, string TDate)
        {
            DataTable dt = new DataTable();
            string query = @"IncomeLedger_TransmissionCharge";

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.ClearParameters();
                _dbConnection.AddParameter("@FromDate", SqlDbType.DateTime, FDate);
                _dbConnection.AddParameter("@ToDate", SqlDbType.DateTime, TDate);
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
        public DataTable LedgerReport_DemetCharge(string FDate, string TDate)
        {
            DataTable dt = new DataTable();
            string query = @"IncomeLedger_DemetCharge";

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.ClearParameters();
                _dbConnection.AddParameter("@FromDate", SqlDbType.DateTime, FDate);
                _dbConnection.AddParameter("@ToDate", SqlDbType.DateTime, TDate);
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


        public DataTable LedgerReport_CustodianCharge(string FDate, string TDate)
        {
            DataTable dt = new DataTable();
            string query = @"IncomeLedger_CustodianCharge";

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.ClearParameters();
                _dbConnection.AddParameter("@FromDate", SqlDbType.DateTime, FDate);
                _dbConnection.AddParameter("@ToDate", SqlDbType.DateTime, TDate);
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

        public DataTable LedgerReport_BankInterestCharge(string FDate, string TDate)
        {
            DataTable dt = new DataTable();
            string query = @"IncomeLedger_BankInterstCharge";

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.ClearParameters();
                _dbConnection.AddParameter("@FromDate", SqlDbType.DateTime, FDate);
                _dbConnection.AddParameter("@ToDate", SqlDbType.DateTime, TDate);
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

        public DataTable LedgerReport_TaxCertCharge_Bank(string FDate, string TDate)
        {
            DataTable dt = new DataTable();
            string query = @"IncomeLedger_TaxChargeBank";

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.ClearParameters();
                _dbConnection.AddParameter("@FromDate", SqlDbType.DateTime, FDate);
                _dbConnection.AddParameter("@ToDate", SqlDbType.DateTime, TDate);
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

        public DataTable LedgerReport_Commission_AddInfo(string FDate, string TDate)
        {
            DataTable dt = new DataTable();
            string query = @"
                                SELECT ISNULL(SUM(A.Commission),0) AS 'TotalCommission'
                                      ,ISNULL(SUM(A.LagaCharge),0) AS 'TotalLaga'
                                      ,ISNULL(SUM(A.HowlaCharge),0) AS 'TotalHowla'
                                      ,ISNULL(SUM(A.Tax),0) AS 'TotalTax'
                                FROM (SELECT EventDate,Commission,LagaCharge,HowlaCharge,Tax
                                            FROM SBP_Transactions
                                            WHERE BuySellFlag IN ('B','S')
                                            AND EventDate BETWEEN '" + FDate + @"' AND '" + TDate + @"'
                                      ) AS A";

            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(query);
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
    }
}
