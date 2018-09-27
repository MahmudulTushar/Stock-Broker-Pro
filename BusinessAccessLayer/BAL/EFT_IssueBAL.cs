﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using System.Data;
using BusinessAccessLayer.BO;
using System.Data.SqlClient;
using BusinessAccessLayer.Constants;
namespace BusinessAccessLayer.BAL
{
    public class EFT_IssueBAL
    {
        //private string Reason = "Fund Transfer";
        private string Reason = "BEFTN";

        DbConnection _dbConnection;

        public EFT_IssueBAL()
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

        private void AccType_BusinessRule(ref string AccType)
        {
            if (AccType != Indication_AccountType.SavingsAccount && AccType != Indication_AccountType.CurrentAccount)
                AccType = Indication_AccountType.SavingsAccount;
        }

        private void ReceiverName_BusinessRule(ref string CustName)
        {
            int MaximumLength = 22;
            int Length = 0;

            if (CustName.Length > MaximumLength)
                Length = MaximumLength;
            else
                Length = CustName.Length;

            string temp = CustName.Substring(0, Length);
            CustName = temp;
        }

        public void BankAccountNo_BusinessRule_FormattingCharacters(ref string AccNo)
        {
            int Length = 0;
            char[] chars = AccNo.ToCharArray();
            string resultString = string.Empty;
            foreach (char ch in chars)
            {
                if (char.IsDigit(ch))
                    resultString = resultString + ch;
            }
            AccNo = resultString;
        }

        public void BankAccountNo_BusinessRule_MakingUp17Digit(ref string AccNo)
        {
            int MaximumLength = 17;
            int Length = 0;
            if (AccNo.Length > MaximumLength)
                Length = MaximumLength;
            else
                Length = AccNo.Length;
            string resultString = string.Empty;
            resultString = AccNo.Substring(0, Length);///////////////////////
            AccNo = resultString;
        }

        private void ReceiverID_BusinessRule(ref string CustCode)
        {
            int MaximumLength = 15;
            int Length = 0;

            if (CustCode.Length > MaximumLength)
                Length = MaximumLength;
            else
                Length = CustCode.Length;

            string temp = CustCode.Substring(0, Length);
            CustCode = temp;

        }

        private void Reason_BusinessRule(ref string Reason)
        {
            int MaximumLength = 80;
            int Length = 0;

            if (Reason.Length > MaximumLength)
                Length = MaximumLength;
            else
                Length = Reason.Length;

            string temp = Reason.Substring(0, Length);
            Reason = temp;
        }

        public DataTable GetAllApprovedRequest()
        {
            DataTable dtApprovedRequest = null;
            string quryString = @"Get_All_Approved_Posting";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                dtApprovedRequest = _dbConnection.ExecuteProQuery(quryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dtApprovedRequest;
        }

        public string GetMaxFileNo_ByDate(DateTime date, int count)
        {
            StringBuilder sb = new StringBuilder();
            string fileNo = string.Empty;
            fileNo = date.Date.ToString("ddMMyyyy");
            fileNo = fileNo + count.ToString("00000");
            DataTable dt = null;
            int result = 0;
            string quryString = " Select "
                              + " ISNULL(Max(T.[FileNo]),0) "
                              + " From "
                              + "( "
                              + "	select "
                              + "	Convert(DateTime, substring(File_No,5,4) + substring(File_No,3,2) +substring(File_No,1,2) ) AS [Date] "
                              + "	,Convert(bigint,substring(File_No,14,2)) AS [FileNo] "
                              + "	from dbo.SBP_EFT_File_Info "
                              + " ) AS T "
                              + "Where T.[Date]='" + date.ToString("yyyy-MMM-dd") + "'";

            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(quryString);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                        result = Convert.ToInt32(dt.Rows[0][0]);
                    fileNo = fileNo + (result + 1).ToString("00");
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return fileNo;
        }

        public string GetLastFilePasswordByLoginName(string logInName)
        {
            string result = string.Empty;
            DataTable dt = new DataTable();
            string quryString = " Select ISNULL(File_Password,'') "
                                  + " From dbo.SBP_EFT_File_Info "
                                  + " Where Issue_By='" + logInName + "' "
                                  + " and File_No=(Select Max(Convert(decimal(28,8),t.File_No)) From dbo.SBP_EFT_File_Info as t Where t.Issue_By='" + logInName + "' and t.File_Issue_Date=( Select Max(k.File_Issue_Date) From dbo.SBP_EFT_File_Info as k Where k.Issue_By='" + logInName + "') ) ";

            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(quryString);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                        result = Convert.ToString(dt.Rows[0][0]);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return result;
        }

        public string GetRoutingByCustCode(string custCode)
        {
            string result = string.Empty;
            DataTable dt = new DataTable();
            string quryString = " SELECT "
                                  + "ISNULL(bankRouting.RoutingNo,'')"
                                  + " FROM "
                                  + "dbo.SBP_Cust_Bank_Info as custBank LEFT OUTER JOIN "
                                  + "dbo.SBP_Bank_Branch_Routing as bankRouting ON "
                                  + "custBank.Bank_Name=bankRouting.Bank_Name"
                                  + " AND "
                                  + "custBank.Branch_Name=bankRouting.Branch_Name"
                                  + " WHERE "
                                  + "custBank.Cust_Code='" + custCode + "'";

            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(quryString);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                        result = Convert.ToString(dt.Rows[0][0]);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return result;
        }

        /*public string GetRoutingByBankBranchCode(string BankCode,string BranchCode)
        {
            string result = string.Empty;
            DataTable dt = new DataTable();
            string quryString = " SELECT "
                                  + "ISNULL(bankRouting.RoutingNo,'')"
                                  + " FROM "
                                  + "dbo.SBP_Cust_Bank_Info as custBank LEFT OUTER JOIN "
                                  + "dbo.SBP_Bank_Branch_Routing as bankRouting ON "
                                  + "custBank.Bank_Name=bankRouting.Bank_Name"
                                  + " AND "
                                  + "custBank.Branch_Name=bankRouting.Branch_Name"
                                  + " WHERE "
                                  + "custBank.Cust_Code='" + custCode + "'";

            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(quryString);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                        result = Convert.ToString(dt.Rows[0][0]);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return result;
        } */

        public string GetAccountTypeByCustCode(string custCode)
        {
            string result = string.Empty;
            DataTable dt = new DataTable();
            string quryString = " SELECT Account_Type "
                                 + " FROM dbo.SBP_Cust_Bank_Info "
                                 + " WHERE Cust_Code='" + custCode + "'";

            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(quryString);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                        result = Convert.ToString(dt.Rows[0][0]);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return result;
        }
        /// <summary>
        /// Change Customer Name Character For city bank Ltd (Character is 50 instead of 22)
        /// Edit By Rashedul Hasan on 08 Jun 2015
        /// </summary>
        /// <param name="custCode"></param>
        /// <param name="bankName"></param>
        /// <returns></returns>
        public string GetCustomerName(string custCode, string bankName)
        {
            string result = string.Empty;
            DataTable dt = new DataTable();
            string quryString = "";
            if (bankName == "THE CITY BANK LTD.")
            {
                quryString = "Select substring(t.Cust_Name,1,50) From dbo.SBP_Cust_Personal_Info as t Where t.Cust_Code='" + custCode + "' ";
            }
            else
            {
                quryString = "Select substring(t.Cust_Name,1,22) From dbo.SBP_Cust_Personal_Info as t Where t.Cust_Code='" + custCode + "' ";
            }
            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(quryString);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                        result = Convert.ToString(dt.Rows[0][0]);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return result;
        }
        //Block By Rashedul Hasan
        //public string GetCustomerName(string custCode)
        //{
        //    string result = string.Empty;
        //    DataTable dt = new DataTable();
        //    string quryString = "Select substring(t.Cust_Name,1,22) From dbo.SBP_Cust_Personal_Info as t Where t.Cust_Code='" + custCode + "' ";
        //    try
        //    {
        //        _dbConnection.ConnectDatabase();
        //        dt = _dbConnection.ExecuteQuery(quryString);
        //        if (dt != null)
        //        {
        //            if (dt.Rows.Count > 0)
        //                result = Convert.ToString(dt.Rows[0][0]);
        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        throw exception;
        //    }
        //    finally
        //    {
        //        _dbConnection.CloseDatabase();
        //    }
        //    return result;
        //}

        public string GetCustomerAccountNo(string custCode)
        {
            string result = string.Empty;
            DataTable dt = new DataTable();
            string quryString = "Select TOP 1 ISNULL(t.Account_No,'') From dbo.SBP_Cust_Bank_Info as t Where t.Cust_Code='" + custCode + "'";
            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(quryString);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                        result = Convert.ToString(dt.Rows[0][0]);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return result;
        }

        public DateTime GetServerDate()
        {
            DateTime result = new DateTime();
            DataTable dt = new DataTable();
            string quryString = "Select GETDATE()";
            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(quryString);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                        result = Convert.ToDateTime(dt.Rows[0][0]);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return result;
        }
//v3
//        public List<Payment_PostingBO> GetAllApprovedRequest_BOList(string BankName)
//        {
//            string quryString =
//                /*
//                              @"SELECT p.*
//                              -- p.Cust_Code as 'Cust_Code'
//                              --,p.Payment_ID as 'Payment_ID'
//                              --,p.Amount as 'Amount'
//                              --,p.Payment_Media as 'Payment_Media'
//                              --,p.Vouchar_SN as 'Vouchar_SN'
//                              --,p.Received_Date as 'Received_Date'

//                              --,e.Req_ID as 'Req_ID'
//                              --,e.Cust_Code as 'Cust_Code'

//                              FROM dbo.SBP_Payment_Posting_Request as p
//                              LEFT OUTER JOIN 
//                              dbo.SBP_EFT_Issue as e
//                              ON p.Payment_ID = e.Req_ID AND ISNULL(e.Req_Type,'')='" + Indication_PaymentTransaction.ReqType_EftIssue_TradeAccount + @"'
//                              WHERE 
//                              --p.Payment_Media='EFT' AND 
//                              e.Req_ID IS NULL AND p.Approval_Status =1 AND p.Payment_Media='EFT' 
//                              AND p.Payment_ID NOT IN (
//                                          Select CONVERT(INT,REPLACE(Trans_Reason,Payment_Media+'_',''))
//                                          From SBP_Payment_Posting_Request
//                                          Where Payment_Media='EFTReturn' 
//                              )";//"SELECT * FROM [SBP_Database].[dbo].[SBP_Payment_Posting_Request]";
//                 */
//                 @"Declare @BankName varchar(50)='" + BankName + @"'
//                    IF(@BankName='THE CITY BANK LTD.')
//            BEGIN
//			SELECT distinct
//			   p.[Payment_ID] As Payment_ID
//			  ,p.[Cust_Code] As Cust_Code
//			  ,p.[Amount] AS Amount
//			  ,p.[Received_Date] As Received_Date
//			  ,p.[Payment_Media] As Payment_Media
//			  ,p.[Payment_Media_No] As Payment_Media_No
//			  ,p.[Payment_Media_Date] As Payment_Media_Date
//			  ,p.[Bank_ID] As Bank_ID
//			  ,p.[Bank_Name] As Bank_Name
//			  ,p.[Branch_ID] As Branch_ID
//			  ,p.[Bank_Branch] As Bank_Branch
//			  ,p.[RoutingNo] As RoutingNo
//			  ,p.[BankAccNo] As BankAccNo
//			  ,p.[Received_By] As Received_By
//			  ,p.[Deposit_Withdraw] As Deposit_Withdraw
//			  ,p.[Payment_Approved_By] As Payment_Approved_By
//			  ,p.[Payment_Approved_Date] As Payment_Approved_Date
//			  ,p.[Vouchar_SN] As Vouchar_SN
//			  ,p.[Trans_Reason] As Trans_Reason
//			  ,p.[Remarks] As Remarks
//			  ,p.[Entry_Date] As Entry_Date
//			  ,p.[Entry_By] As Entry_By 
//			  ,p.[Maturity_Days] As Maturity_Days
//			  ,p.[Deposit_Bank_Name] As Deposit_Bank_Name
//			  ,p.[Deposit_Branch_Name] As Deposit_Branch_Name
//			  ,p.[Approval_Status] As Approval_Status
//			  ,p.[Rejection_Reason] As Rejection_Reason
//			  ,p.[Entry_Branch_ID] As Entry_Branch_ID
//			  ,p.[OnlineOrderNo] As OnlineOrderNo
//			  ,p.[OnlineEntry_Date] As  OnlineEntry_Date             
//				,'TRADE' As EFT_TYPE
//			FROM dbo.SBP_Payment_Posting_Request as p
//			LEFT OUTER JOIN 
//			dbo.SBP_EFT_Issue as e
//			ON p.Payment_ID = e.Req_ID AND ISNULL(e.Req_Type,'')='" + Indication_PaymentTransaction.ReqType_EftIssue_TradeAccount + @"'
//			LEFT OUTER JOIN
//			dbo.SBP_EFT_File_Info as f
//			ON f.File_No=e.File_No_ID AND f.IsCanceled=0
//
//			WHERE 
//			--p.Payment_Media='EFT' AND 
//			e.Req_ID IS NULL AND p.Approval_Status =1
//			And P.Bank_ID=43
//			AND p.Payment_Media='EFT' 
//			AND p.Payment_ID NOT IN (
//						Select CONVERT(INT,REPLACE(Trans_Reason,Payment_Media+'_',''))
//						From SBP_Payment_Posting_Request
//						Where Payment_Media='EFTReturn' 
//			)
//            AND p.Payment_ID NOT IN (
//						Select CONVERT(INT,REPLACE(Trans_Reason,Payment_Media+'_',''))
//						From SBP_Payment_Posting_Request
//						Where Payment_Media='EFTCancel' 
//			)
//UNION All
//			SELECT distinct
//			  p.[ID] As Payment_ID
//			  ,p.[Cust_Code] As Cust_Code
//			  ,p.[Amount] AS Amount
//			  ,p.[Received_Date] As Received_Date
//			  ,p.Money_TransactionType_Name As Payment_Media
//			  ,'' As Payment_Media_No
//			  ,'' As Payment_Media_Date
//			  ,dtl.[Bank_ID] As Bank_ID
//			  ,dtl.BankName As Bank_Name
//			  ,dtl.[Branch_ID] As Branch_ID
//			  ,dtl.Branch_Name As Bank_Branch
//			  ,dtl.Routing_No As RoutingNo
//			  ,dtl.Bank_Acc_No As BankAccNo
//			  ,p.Entry_By As Received_By
//			  ,p.[Deposit_Withdraw] As Deposit_Withdraw
//			  ,p.Approval_By As Payment_Approved_By
//			  ,p.Approval_Date As Payment_Approved_Date
//			  ,p.Voucher_No As Vouchar_SN
//			  ,p.[Trans_Reason] As Trans_Reason
//			  ,p.[Remarks] As Remarks
//			  ,p.[Entry_Date] As Entry_Date
//			  ,p.[Entry_By] As Entry_By 
//			  ,'' As Maturity_Days
//			  ,dtl.BankName As Deposit_Bank_Name
//			  ,dtl.Branch_Name As Deposit_Branch_Name
//			  ,p.[Approval_Status] As Approval_Status
//			  ,p.Rejected_Reason As Rejection_Reason
//			  ,p.[Entry_Branch_ID] As Entry_Branch_ID
//			  ,'' As OnlineOrderNo
//			  ,'' As  OnlineEntry_Date  
//				,'IPO' As EFT_TYPE
//			FROM dbo.SBP_IPO_Customer_Broker_MoneyTransaction as p
//			LEFT OUTER JOIN 
//			dbo.SBP_EFT_Issue as e
//			ON p.ID = e.Req_ID AND ISNULL(e.Req_Type,'')='" + Indication_PaymentTransaction.ReqType_EftIssue_IPOAccount + @"' 
//			LEFT OUTER JOIN
//			dbo.SBP_EFT_File_Info as f
//			ON f.File_No=e.File_No_ID AND f.IsCanceled=0
//			LEFT OUTER JOIN 
//			SBP_IPO_Customer_Broker_Transaction_Details As dtl
//			ON dtl.TransID=p.ID
//
//			WHERE 
//			--p.Payment_Media='EFT' AND 
//			e.Req_ID IS NULL AND p.Approval_Status =1
//			And dtl.Bank_ID=43
//			AND
//			p.Money_TransactionType_Name='EFT' 
//UNION All
//			
//			SELECT distinct
//			  p.[ID] As Payment_ID
//			  ,p.[Cust_Code] As Cust_Code
//			  ,p.[Amount] AS Amount
//			  ,p.[Received_Date] As Received_Date
//			  ,p.Money_TransactionType_Name As Payment_Media
//			  ,'' As Payment_Media_No
//			  ,'' As Payment_Media_Date
//			  ,dtl.[Bank_ID] As Bank_ID
//			  ,dtl.BankName As Bank_Name
//			  ,dtl.[Branch_ID] As Branch_ID
//			  ,dtl.Branch_Name As Bank_Branch
//			  ,dtl.Routing_No As RoutingNo
//			  ,dtl.Bank_Acc_No As BankAccNo
//			  ,p.Entry_By As Received_By
//			  ,p.[Deposit_Withdraw] As Deposit_Withdraw
//			  ,p.Approval_By As Payment_Approved_By
//			  ,p.Approval_Date As Payment_Approved_Date
//			  ,p.Voucher_No As Vouchar_SN
//			  ,p.[Trans_Reason] As Trans_Reason
//			  ,p.[Remarks] As Remarks
//			  ,p.[Entry_Date] As Entry_Date
//			  ,p.[Entry_By] As Entry_By 
//			  ,'' As Maturity_Days
//			  ,dtl.BankName As Deposit_Bank_Name
//			  ,dtl.Branch_Name As Deposit_Branch_Name
//			  ,p.[Approval_Status] As Approval_Status
//			  ,p.Rejected_Reason As Rejection_Reason
//			  ,p.[Entry_Branch_ID] As Entry_Branch_ID
//			  ,'' As OnlineOrderNo
//			  ,'' As  OnlineEntry_Date  
//				,'IPO' As EFT_TYPE
//			FROM dbo.SBP_IPO_Customer_Broker_MoneyTransaction as p
//			JOIN
//			(
//				Select 
//				S.Req_ID as REq_ID
//				,S.File_No_ID as cancelID 
//				From SBP_EFT_Issue As S
//				Join SBP_EFT_File_Info as e
//				on S.File_No_ID=e.File_No
//				Where e.IsCanceled=1 
//				AND S.Req_ID NOT IN (Select iss.Req_ID From SBP_EFT_File_Info as fl JOIN SBP_EFT_Issue as iss ON fl.File_No=iss.File_No_ID Where fl.IsCanceled=0 AND iss.Req_Type='IPO')
//				And S.Req_ID NOT IN (Select CONVERT(INT,REPLACE(Trans_Reason,Money_TransactionType_Name+'_',''))
//						From SBP_IPO_Customer_Broker_MoneyTransaction
//						Where Money_TransactionType_Name='EFTReturn') 
//                And S.Req_ID NOT IN (Select CONVERT(INT,REPLACE(Trans_Reason,Money_TransactionType_Name+'_',''))
//						From SBP_IPO_Customer_Broker_MoneyTransaction
//						Where Money_TransactionType_Name='EFTCancel')
//				--order by S.ID desc
//			)As Cancel
//			ON cancel.REq_ID=Convert(varchar(100),p.ID)
//            Join SBP_IPO_Customer_Broker_Transaction_Details as dtl
//			on dtl.TransID=p.ID
//			Where dtl.Bank_ID=43
//			
//		union all
//			SELECT distinct	
//			--e.Req_ID
//			p.[Payment_ID] As Payment_ID
//			  ,p.[Cust_Code] As Cust_Code
//			  ,p.[Amount] AS Amount
//			  ,p.[Received_Date] As Received_Date
//			  ,p.[Payment_Media] As Payment_Media
//			  ,p.[Payment_Media_No] As Payment_Media_No
//			  ,p.[Payment_Media_Date] As Payment_Media_Date
//			  ,p.[Bank_ID] As Bank_ID
//			  ,p.[Bank_Name] As Bank_Name
//			  ,p.[Branch_ID] As Branch_ID
//			  ,p.[Bank_Branch] As Bank_Branch
//			  ,p.[RoutingNo] As RoutingNo
//			  ,p.[BankAccNo] As BankAccNo
//			  ,p.[Received_By] As Received_By
//			  ,p.[Deposit_Withdraw] As Deposit_Withdraw
//			  ,p.[Payment_Approved_By] As Payment_Approved_By
//			  ,p.[Payment_Approved_Date] As Payment_Approved_Date
//			  ,p.[Vouchar_SN] As Vouchar_SN
//			  ,p.[Trans_Reason] As Trans_Reason
//			  ,p.[Remarks] As Remarks
//			  ,p.[Entry_Date] As Entry_Date
//			  ,p.[Entry_By] As Entry_By 
//			  ,p.[Maturity_Days] As Maturity_Days
//			  ,p.[Deposit_Bank_Name] As Deposit_Bank_Name
//			  ,p.[Deposit_Branch_Name] As Deposit_Branch_Name
//			  ,p.[Approval_Status] As Approval_Status
//			  ,p.[Rejection_Reason] As Rejection_Reason
//			  ,p.[Entry_Branch_ID] As Entry_Branch_ID
//			  ,p.[OnlineOrderNo] As OnlineOrderNo
//			  ,p.[OnlineEntry_Date] As  OnlineEntry_Date                  
//				,'TRADE' As EFT_TYPE
//			FROM dbo.SBP_Payment_Posting_Request as p
//			Join 
//			(
//				Select 
//				S.Req_ID as REq_ID
//				,S.File_No_ID as cancelID 
//				From SBP_EFT_Issue As S
//				Join SBP_EFT_File_Info as e
//				on S.File_No_ID=e.File_No
//				Where e.IsCanceled=1 
//				AND S.Req_ID NOT IN (Select iss.Req_ID From SBP_EFT_File_Info as fl JOIN SBP_EFT_Issue as iss ON fl.File_No=iss.File_No_ID Where fl.IsCanceled=0 AND iss.Req_Type='TRADE')
//				And S.Req_ID NOT IN (Select CONVERT(INT,REPLACE(Trans_Reason,Payment_Media+'_',''))
//						From SBP_Payment_Posting_Request
//						Where Payment_Media='EFTReturn') 
//                And S.Req_ID NOT IN (Select CONVERT(INT,REPLACE(Trans_Reason,Payment_Media+'_',''))
//						From SBP_Payment_Posting_Request
//						Where Payment_Media='EFTCancel')
//				--order by S.ID desc
//			)As Cancel
//			ON cancel.REq_ID=Convert(varchar(100),p.Payment_ID)
//		Where 
//		p.Bank_ID=43
//
//END
//ELse
//BEGIN
//			SELECT distinct	p.[Payment_ID] As Payment_ID
//			  ,p.[Cust_Code] As Cust_Code
//			  ,p.[Amount] AS Amount
//			  ,p.[Received_Date] As Received_Date
//			  ,p.[Payment_Media] As Payment_Media
//			  ,p.[Payment_Media_No] As Payment_Media_No
//			  ,p.[Payment_Media_Date] As Payment_Media_Date
//			  ,p.[Bank_ID] As Bank_ID
//			  ,p.[Bank_Name] As Bank_Name
//			  ,p.[Branch_ID] As Branch_ID
//			  ,p.[Bank_Branch] As Bank_Branch
//			  ,p.[RoutingNo] As RoutingNo
//			  ,p.[BankAccNo] As BankAccNo
//			  ,p.[Received_By] As Received_By
//			  ,p.[Deposit_Withdraw] As Deposit_Withdraw
//			  ,p.[Payment_Approved_By] As Payment_Approved_By
//			  ,p.[Payment_Approved_Date] As Payment_Approved_Date
//			  ,p.[Vouchar_SN] As Vouchar_SN
//			  ,p.[Trans_Reason] As Trans_Reason
//			  ,p.[Remarks] As Remarks
//			  ,p.[Entry_Date] As Entry_Date
//			  ,p.[Entry_By] As Entry_By 
//			  ,p.[Maturity_Days] As Maturity_Days
//			  ,p.[Deposit_Bank_Name] As Deposit_Bank_Name
//			  ,p.[Deposit_Branch_Name] As Deposit_Branch_Name
//			  ,p.[Approval_Status] As Approval_Status
//			  ,p.[Rejection_Reason] As Rejection_Reason
//			  ,p.[Entry_Branch_ID] As Entry_Branch_ID
//			  ,p.[OnlineOrderNo] As OnlineOrderNo
//			  ,p.[OnlineEntry_Date] As  OnlineEntry_Date                  
//				,'TRADE' As EFT_TYPE
//			FROM dbo.SBP_Payment_Posting_Request as p
//			LEFT OUTER JOIN 
//			dbo.SBP_EFT_Issue as e
//			ON p.Payment_ID = e.Req_ID AND ISNULL(e.Req_Type,'')='" + Indication_PaymentTransaction.ReqType_EftIssue_TradeAccount + @"'
//			LEFT OUTER JOIN
//			dbo.SBP_EFT_File_Info as f
//			ON f.File_No=e.File_No_ID AND f.IsCanceled=0 
//
//			WHERE 
//			--p.Payment_Media='EFT' AND 
//			e.Req_ID IS NULL AND p.Approval_Status =1
//			AND p.Payment_Media='EFT' And P.Bank_ID<>43 
//			AND p.Payment_ID NOT IN (
//						Select CONVERT(INT,REPLACE(Trans_Reason,Payment_Media+'_',''))
//						From SBP_Payment_Posting_Request
//						Where Payment_Media='EFTReturn' 
//			)
//            AND p.Payment_ID NOT IN (
//						Select CONVERT(INT,REPLACE(Trans_Reason,Payment_Media+'_',''))
//						From SBP_Payment_Posting_Request
//						Where Payment_Media='EFTCancel' 
//			)
//UNION All
//			SELECT distinct p.[ID] As Payment_ID
//			  ,p.[Cust_Code] As Cust_Code
//			  ,p.[Amount] AS Amount
//			  ,p.[Received_Date] As Received_Date
//			  ,p.Money_TransactionType_Name As Payment_Media
//			  ,'' As Payment_Media_No
//			  ,'' As Payment_Media_Date
//			  ,dtl.[Bank_ID] As Bank_ID
//			  ,dtl.BankName As Bank_Name
//			  ,dtl.[Branch_ID] As Branch_ID
//			  ,dtl.Branch_Name As Bank_Branch
//			  ,dtl.Routing_No As RoutingNo
//			  ,dtl.Bank_Acc_No As BankAccNo
//			  ,p.Entry_By As Received_By
//			  ,p.[Deposit_Withdraw] As Deposit_Withdraw
//			  ,p.Approval_By As Payment_Approved_By
//			  ,p.Approval_Date As Payment_Approved_Date
//			  ,p.Voucher_No As Vouchar_SN
//			  ,p.[Trans_Reason] As Trans_Reason
//			  ,p.[Remarks] As Remarks
//			  ,p.[Entry_Date] As Entry_Date
//			  ,p.[Entry_By] As Entry_By 
//			  ,'' As Maturity_Days
//			  ,dtl.BankName As Deposit_Bank_Name
//			  ,dtl.Branch_Name As Deposit_Branch_Name
//			  ,p.[Approval_Status] As Approval_Status
//			  ,p.Rejected_Reason As Rejection_Reason
//			  ,p.[Entry_Branch_ID] As Entry_Branch_ID
//			  ,'' As OnlineOrderNo
//			  ,'' As  OnlineEntry_Date  
//				,'IPO' As EFT_TYPE
//			FROM dbo.SBP_IPO_Customer_Broker_MoneyTransaction as p
//			LEFT OUTER JOIN 
//			dbo.SBP_EFT_Issue as e
//			ON p.ID = e.Req_ID AND ISNULL(e.Req_Type,'')='" + Indication_PaymentTransaction.ReqType_EftIssue_IPOAccount + @"' 
//			LEFT OUTER JOIN
//			dbo.SBP_EFT_File_Info as f
//			ON f.File_No=e.File_No_ID AND f.IsCanceled=0
//			LEFT OUTER JOIN 
//			SBP_IPO_Customer_Broker_Transaction_Details As dtl
//			ON dtl.TransID=p.ID
//			
//			WHERE 
//			--p.Payment_Media='EFT' AND 
//			e.Req_ID IS NULL AND p.Approval_Status =1
//			And dtl.Bank_ID<>43
//			AND p.Money_TransactionType_Name='EFT'
//UNION All
//			
//			SELECT distinct
//			  p.[ID] As Payment_ID
//			  ,p.[Cust_Code] As Cust_Code
//			  ,p.[Amount] AS Amount
//			  ,p.[Received_Date] As Received_Date
//			  ,p.Money_TransactionType_Name As Payment_Media
//			  ,'' As Payment_Media_No
//			  ,'' As Payment_Media_Date
//			  ,dtl.[Bank_ID] As Bank_ID
//			  ,dtl.BankName As Bank_Name
//			  ,dtl.[Branch_ID] As Branch_ID
//			  ,dtl.Branch_Name As Bank_Branch
//			  ,dtl.Routing_No As RoutingNo
//			  ,dtl.Bank_Acc_No As BankAccNo
//			  ,p.Entry_By As Received_By
//			  ,p.[Deposit_Withdraw] As Deposit_Withdraw
//			  ,p.Approval_By As Payment_Approved_By
//			  ,p.Approval_Date As Payment_Approved_Date
//			  ,p.Voucher_No As Vouchar_SN
//			  ,p.[Trans_Reason] As Trans_Reason
//			  ,p.[Remarks] As Remarks
//			  ,p.[Entry_Date] As Entry_Date
//			  ,p.[Entry_By] As Entry_By 
//			  ,'' As Maturity_Days
//			  ,dtl.BankName As Deposit_Bank_Name
//			  ,dtl.Branch_Name As Deposit_Branch_Name
//			  ,p.[Approval_Status] As Approval_Status
//			  ,p.Rejected_Reason As Rejection_Reason
//			  ,p.[Entry_Branch_ID] As Entry_Branch_ID
//			  ,'' As OnlineOrderNo
//			  ,'' As  OnlineEntry_Date  
//				,'IPO' As EFT_TYPE
//			FROM dbo.SBP_IPO_Customer_Broker_MoneyTransaction as p
//			Join 
//			(
//				Select 
//				S.Req_ID as REq_ID
//				,S.File_No_ID as cancelID 
//				From SBP_EFT_Issue As S
//				Join SBP_EFT_File_Info as e
//				on S.File_No_ID=e.File_No
//				Where e.IsCanceled=1 
//				AND S.Req_ID NOT IN (Select iss.Req_ID From SBP_EFT_File_Info as fl JOIN SBP_EFT_Issue as iss ON fl.File_No=iss.File_No_ID Where fl.IsCanceled=0 AND iss.Req_Type='IPO')
//				And S.Req_ID NOT IN (Select CONVERT(INT,REPLACE(Trans_Reason,Money_TransactionType_Name+'_',''))
//						From SBP_IPO_Customer_Broker_MoneyTransaction
//						Where Money_TransactionType_Name='EFTReturn')
//                And S.Req_ID NOT IN (Select CONVERT(INT,REPLACE(Trans_Reason,Money_TransactionType_Name+'_',''))
//						From SBP_IPO_Customer_Broker_MoneyTransaction
//						Where Money_TransactionType_Name='EFTCancel') 
//				--order by S.ID desc
//			)As Cancel
//			ON cancel.REq_ID=Convert(varchar(100),p.ID)
//			JOIN 
//			SBP_IPO_Customer_Broker_Transaction_Details As dtl
//			ON dtl.TransID=p.ID
//			Where dtl.Bank_ID<>43
//	union all
//			SELECT 	distinct
//			--e.Req_ID
//			p.[Payment_ID] As Payment_ID
//			  ,p.[Cust_Code] As Cust_Code
//			  ,p.[Amount] AS Amount
//			  ,p.[Received_Date] As Received_Date
//			  ,p.[Payment_Media] As Payment_Media
//			  ,p.[Payment_Media_No] As Payment_Media_No
//			  ,p.[Payment_Media_Date] As Payment_Media_Date
//			  ,p.[Bank_ID] As Bank_ID
//			  ,p.[Bank_Name] As Bank_Name
//			  ,p.[Branch_ID] As Branch_ID
//			  ,p.[Bank_Branch] As Bank_Branch
//			  ,p.[RoutingNo] As RoutingNo
//			  ,p.[BankAccNo] As BankAccNo
//			  ,p.[Received_By] As Received_By
//			  ,p.[Deposit_Withdraw] As Deposit_Withdraw
//			  ,p.[Payment_Approved_By] As Payment_Approved_By
//			  ,p.[Payment_Approved_Date] As Payment_Approved_Date
//			  ,p.[Vouchar_SN] As Vouchar_SN
//			  ,p.[Trans_Reason] As Trans_Reason
//			  ,p.[Remarks] As Remarks
//			  ,p.[Entry_Date] As Entry_Date
//			  ,p.[Entry_By] As Entry_By 
//			  ,p.[Maturity_Days] As Maturity_Days
//			  ,p.[Deposit_Bank_Name] As Deposit_Bank_Name
//			  ,p.[Deposit_Branch_Name] As Deposit_Branch_Name
//			  ,p.[Approval_Status] As Approval_Status
//			  ,p.[Rejection_Reason] As Rejection_Reason
//			  ,p.[Entry_Branch_ID] As Entry_Branch_ID
//			  ,p.[OnlineOrderNo] As OnlineOrderNo
//			  ,p.[OnlineEntry_Date] As  OnlineEntry_Date                  
//				,'TRADE' As EFT_TYPE
//			FROM dbo.SBP_Payment_Posting_Request as p
//            join
//			(
//				Select 
//				S.Req_ID as REq_ID
//				,S.File_No_ID as cancelID 
//				From SBP_EFT_Issue As S
//				Join SBP_EFT_File_Info as e
//				on S.File_No_ID=e.File_No
//				Where e.IsCanceled=1 
//				AND S.Req_ID NOT IN (Select iss.Req_ID From SBP_EFT_File_Info as fl JOIN SBP_EFT_Issue as iss ON fl.File_No=iss.File_No_ID Where fl.IsCanceled=0 AND iss.Req_Type='TRADE')
//				And S.Req_ID NOT IN (Select CONVERT(INT,REPLACE(Trans_Reason,Payment_Media+'_',''))
//						From SBP_Payment_Posting_Request
//						Where Payment_Media='EFTReturn') 
//                And S.Req_ID NOT IN (Select CONVERT(INT,REPLACE(Trans_Reason,Payment_Media+'_',''))
//						From SBP_Payment_Posting_Request
//						Where Payment_Media='EFTCancel')
//				--order by S.ID desc
//			)As Cancel
//			ON cancel.REq_ID=Convert(varchar(100),p.Payment_ID)
//		Where p.Bank_ID<>43
//            END"
//                ;
//            List<Payment_PostingBO> ResultPaymentPosting = new List<Payment_PostingBO>();
//            try
//            {
//                _dbConnection.ConnectDatabase();
//                //_dbConnection.ActiveStoredProcedure();

//                using (SqlDataReader dr = _dbConnection.ExecuteReader(quryString))
//                {

//                    while (dr.Read())
//                    {
//                        Payment_PostingBO obj = new Payment_PostingBO();

//                        obj.Payment_ID = Convert.ToInt32(dr["Payment_ID"]);
//                        obj.Cust_Code = Convert.ToString(dr["Cust_Code"]);
//                        obj.Amount = Convert.ToDouble(dr["Amount"]);
//                        obj.Approval_Status = Convert.ToInt32(dr["Approval_Status"]);
//                        obj.Bank_ID = Convert.ToInt32(dr["Bank_ID"]);
//                        obj.Bank_Name = Convert.ToString(dr["Bank_Name"]);
//                        obj.Branch_ID = Convert.ToInt32(dr["Branch_ID"]);
//                        obj.Bank_Branch = Convert.ToString(dr["Bank_Branch"]);
//                        obj.Received_By = Convert.ToString(dr["Received_By"]);
//                        obj.Received_Date = Convert.ToDateTime(dr["Received_Date"]);
//                        obj.Payment_Media = Convert.ToString(dr["Payment_Media"]);
//                        obj.Payment_Media_No = Convert.ToString(dr["Payment_Media_No"]);
//                        obj.Payment_Media_Date = Convert.ToDateTime(dr["Payment_Media_Date"]);
//                        obj.Deposit_Withdraw = Convert.ToString(dr["Deposit_Withdraw"]);
//                        obj.Payment_Approved_By = Convert.ToString(dr["Payment_Approved_By"]);
//                        obj.Payment_Approved_Date = Convert.ToDateTime(dr["Payment_Approved_Date"]);
//                        obj.Rejection_Reason = Convert.ToString(dr["Rejection_Reason"]);
//                        obj.Remarks = Convert.ToString(dr["Remarks"]);
//                        obj.Vouchar_SN = Convert.ToString(dr["Vouchar_SN"]);
//                        obj.Entry_By = Convert.ToString(dr["Entry_By"]);
//                        obj.Entry_Date = Convert.ToDateTime(dr["Entry_Date"]);
//                        obj.Maturity_Days = Convert.ToInt32(dr["Maturity_Days"]);
//                        obj.Deposit_Bank_Name = Convert.ToString(dr["Deposit_Bank_Name"]);
//                        obj.Deposit_Branch_Name = Convert.ToString(dr["Deposit_Branch_Name"]);
//                        obj.Entry_Branch_ID = Convert.ToInt32(dr["Entry_Branch_ID"]);
//                        obj.BankAccNo = Convert.ToString(dr["BankAccNo"]);
//                        obj.RoutingNo = Convert.ToString(dr["RoutingNo"]);
//                        obj.ReqType = Convert.ToString(dr["EFT_TYPE"]);

//                        ResultPaymentPosting.Add(obj);
//                    }
//                }
//            }
//            catch (Exception exception)
//            {
//                throw exception;
//            }
//            finally
//            {
//                _dbConnection.CloseDatabase();
//            }
//            return ResultPaymentPosting;
//        }

        public List<Payment_PostingBO> GetAllApprovedRequest_BOList(string BankName)
        {
            string quryString =
                /*
                              @"SELECT p.*
                              -- p.Cust_Code as 'Cust_Code'
                              --,p.Payment_ID as 'Payment_ID'
                              --,p.Amount as 'Amount'
                              --,p.Payment_Media as 'Payment_Media'
                              --,p.Vouchar_SN as 'Vouchar_SN'
                              --,p.Received_Date as 'Received_Date'

                              --,e.Req_ID as 'Req_ID'
                              --,e.Cust_Code as 'Cust_Code'

                              FROM dbo.SBP_Payment_Posting_Request as p
                              LEFT OUTER JOIN 
                              dbo.SBP_EFT_Issue as e
                              ON p.Payment_ID = e.Req_ID AND ISNULL(e.Req_Type,'')='" + Indication_PaymentTransaction.ReqType_EftIssue_TradeAccount + @"'
                              WHERE 
                              --p.Payment_Media='EFT' AND 
                              e.Req_ID IS NULL AND p.Approval_Status =1 AND p.Payment_Media='EFT' 
                              AND p.Payment_ID NOT IN (
                                          Select CONVERT(INT,REPLACE(Trans_Reason,Payment_Media+'_',''))
                                          From SBP_Payment_Posting_Request
                                          Where Payment_Media='EFTReturn' 
                              )";//"SELECT * FROM [SBP_Database].[dbo].[SBP_Payment_Posting_Request]";
                 */
                @"Declare @BankName varchar(50)='" + BankName + @"'
                    IF(@BankName='THE CITY BANK LTD.')
            BEGIN
			SELECT distinct
			   p.[Payment_ID] As Payment_ID
			  ,p.[Cust_Code] As Cust_Code
			  ,p.[Amount] AS Amount
			  ,p.[Received_Date] As Received_Date
			  ,p.[Payment_Media] As Payment_Media
			  ,p.[Payment_Media_No] As Payment_Media_No
			  ,p.[Payment_Media_Date] As Payment_Media_Date
			  ,p.[Bank_ID] As Bank_ID
			  ,p.[Bank_Name] As Bank_Name
			  ,p.[Branch_ID] As Branch_ID
			  ,p.[Bank_Branch] As Bank_Branch
			  ,p.[RoutingNo] As RoutingNo
			  ,p.[BankAccNo] As BankAccNo
			  ,p.[Received_By] As Received_By
			  ,p.[Deposit_Withdraw] As Deposit_Withdraw
			  ,p.[Payment_Approved_By] As Payment_Approved_By
			  ,p.[Payment_Approved_Date] As Payment_Approved_Date
			  ,p.[Vouchar_SN] As Vouchar_SN
			  ,p.[Trans_Reason] As Trans_Reason
			  ,p.[Remarks] As Remarks
			  ,p.[Entry_Date] As Entry_Date
			  ,p.[Entry_By] As Entry_By 
			  ,p.[Maturity_Days] As Maturity_Days
			  ,p.[Deposit_Bank_Name] As Deposit_Bank_Name
			  ,p.[Deposit_Branch_Name] As Deposit_Branch_Name
			  ,p.[Approval_Status] As Approval_Status
			  ,p.[Rejection_Reason] As Rejection_Reason
			  ,p.[Entry_Branch_ID] As Entry_Branch_ID
			  ,p.[OnlineOrderNo] As OnlineOrderNo
			  ,p.[OnlineEntry_Date] As  OnlineEntry_Date             
				,'TRADE' As EFT_TYPE
			FROM dbo.SBP_Payment_Posting_Request as p
			LEFT OUTER JOIN 
			dbo.SBP_EFT_Issue as e
			ON p.Payment_ID = e.Req_ID AND ISNULL(e.Req_Type,'')='" + Indication_PaymentTransaction.ReqType_EftIssue_TradeAccount + @"'
			LEFT OUTER JOIN
			dbo.SBP_EFT_File_Info as f
			ON f.File_No=e.File_No_ID AND f.IsCanceled=0

			WHERE 
			--p.Payment_Media='EFT' AND 
			e.Req_ID IS NULL AND p.Approval_Status =1
			And P.Bank_ID=43
			AND p.Payment_Media='EFT' 
			AND p.Payment_ID NOT IN (
						Select CONVERT(Decimal(18,0),REPLACE(Trans_Reason,Payment_Media+'_',''))
						From SBP_Payment_Posting_Request
						Where Payment_Media='EFTReturn' 
			)
            AND p.Payment_ID NOT IN (
						Select CONVERT(Decimal(18,0),REPLACE(Trans_Reason,Payment_Media+'_',''))
						From SBP_Payment_Posting_Request
						Where Payment_Media='EFTCancel' 
			)
UNION All
            SELECT distinct
			   p.[Payment_ID] As Payment_ID
			  ,p.[Cust_Code] As Cust_Code
			  ,p.[Amount] AS Amount
			  ,p.[Received_Date] As Received_Date
			  ,p.[Payment_Media] As Payment_Media
			  ,ISNULL(p.[Payment_Media_No],'') As Payment_Media_No
			  ,p.[Payment_Media_Date] As Payment_Media_Date
			  ,p.[Bank_ID] As Bank_ID
			  ,p.[Bank_Name] As Bank_Name
			  ,p.[Branch_ID] As Branch_ID
			  ,p.[Bank_Branch] As Bank_Branch
			  ,p.[RoutingNo] As RoutingNo
			  ,p.[BankAccNo] As BankAccNo
			  ,p.[Received_By] As Received_By
			  ,p.[Deposit_Withdraw] As Deposit_Withdraw
			  ,ISNULL(p.[Payment_Approved_By],'') As Payment_Approved_By
			  ,ISNULL(p.[Payment_Approved_Date],'') As Payment_Approved_Date
			  ,p.[Vouchar_SN] As Vouchar_SN
			  ,p.[Trans_Reason] As Trans_Reason
			  ,p.[Remarks] As Remarks
			  ,p.[Entry_Date] As Entry_Date
			  ,p.[Entry_By] As Entry_By 
			  ,ISNULL(p.[Maturity_Days],'') As Maturity_Days
			  ,ISNULL(p.[Deposit_Bank_Name],'') As Deposit_Bank_Name
			  ,ISNULL(p.[Deposit_Branch_Name],'') As Deposit_Branch_Name
			  ,p.[Approval_Status] As Approval_Status
			  ,p.[Rejection_Reason] As Rejection_Reason
			  ,p.[Entry_Branch_ID] As Entry_Branch_ID
			  ,ISNULL(p.[OnlineOrderNo],'') As OnlineOrderNo
			  ,ISNULL(p.[OnlineEntry_Date],'') As  OnlineEntry_Date 			           
				,'TRADE' As EFT_TYPE
			FROM dbo.SBP_Payment_Posting_Request as p
			LEFT OUTER JOIN 
			dbo.SBP_EFT_Issue as e
			ON p.Payment_ID = e.Req_ID AND ISNULL(e.Req_Type,'')='" + Indication_PaymentTransaction.ReqType_EftIssue_TradeAccount + @"'
			LEFT OUTER JOIN
			dbo.SBP_EFT_File_Info as f
			ON f.File_No=e.File_No_ID AND f.IsCanceled=0

			WHERE 
			--p.Payment_Media='EFT' AND 
			e.Req_ID IS NULL AND p.Approval_Status =2
			And P.Bank_ID=43
			AND p.Payment_Media='EFTCancel' 
			AND p.Payment_ID NOT IN (
						Select CONVERT(Decimal(18,0),REPLACE(Trans_Reason,Payment_Media+'_',''))
						From SBP_Payment_Posting_Request
						Where Payment_Media='EFTReturn' 
			)
            AND p.Payment_ID NOT IN (
						Select CONVERT(Decimal(18,0),REPLACE(Trans_Reason,Payment_Media+'_',''))
						From SBP_Payment_Posting_Request
						Where Payment_Media='EFTCancel' 
			)
UNION All
			SELECT distinct
			  p.[ID] As Payment_ID
			  ,p.[Cust_Code] As Cust_Code
			  ,p.[Amount] AS Amount
			  ,p.[Received_Date] As Received_Date
			  ,p.Money_TransactionType_Name As Payment_Media
			  ,'' As Payment_Media_No
			  ,'' As Payment_Media_Date
			  ,dtl.[Bank_ID] As Bank_ID
			  ,dtl.BankName As Bank_Name
			  ,dtl.[Branch_ID] As Branch_ID
			  ,dtl.Branch_Name As Bank_Branch
			  ,dtl.Routing_No As RoutingNo
			  ,dtl.Bank_Acc_No As BankAccNo
			  ,p.Entry_By As Received_By
			  ,p.[Deposit_Withdraw] As Deposit_Withdraw
			  ,p.Approval_By As Payment_Approved_By
			  ,p.Approval_Date As Payment_Approved_Date
			  ,p.Voucher_No As Vouchar_SN
			  ,p.[Trans_Reason] As Trans_Reason
			  ,p.[Remarks] As Remarks
			  ,p.[Entry_Date] As Entry_Date
			  ,p.[Entry_By] As Entry_By 
			  ,'' As Maturity_Days
			  ,dtl.BankName As Deposit_Bank_Name
			  ,dtl.Branch_Name As Deposit_Branch_Name
			  ,p.[Approval_Status] As Approval_Status
			  ,p.Rejected_Reason As Rejection_Reason
			  ,p.[Entry_Branch_ID] As Entry_Branch_ID
			  ,'' As OnlineOrderNo
			  ,'' As  OnlineEntry_Date  
				,'IPO' As EFT_TYPE
			FROM dbo.SBP_IPO_Customer_Broker_MoneyTransaction as p
			LEFT OUTER JOIN 
			dbo.SBP_EFT_Issue as e
			ON p.ID = e.Req_ID AND ISNULL(e.Req_Type,'')='" + Indication_PaymentTransaction.ReqType_EftIssue_IPOAccount + @"' 
			LEFT OUTER JOIN
			dbo.SBP_EFT_File_Info as f
			ON f.File_No=e.File_No_ID AND f.IsCanceled=0
			LEFT OUTER JOIN 
			SBP_IPO_Customer_Broker_Transaction_Details As dtl
			ON dtl.TransID=p.ID

			WHERE 
			--p.Payment_Media='EFT' AND 
			e.Req_ID IS NULL AND p.Approval_Status =1
			And dtl.Bank_ID=43
			AND
			p.Money_TransactionType_Name='EFT' 
UNION All
			SELECT distinct
			  p.[ID] As Payment_ID
			  ,p.[Cust_Code] As Cust_Code
			  ,p.[Amount] AS Amount
			  ,p.[Received_Date] As Received_Date
			  ,p.Money_TransactionType_Name As Payment_Media
			  ,'' As Payment_Media_No
			  ,'' As Payment_Media_Date
			  ,dtl.[Bank_ID] As Bank_ID
			  ,dtl.BankName As Bank_Name
			  ,dtl.[Branch_ID] As Branch_ID
			  ,dtl.Branch_Name As Bank_Branch
			  ,dtl.Routing_No As RoutingNo
			  ,dtl.Bank_Acc_No As BankAccNo
			  ,p.Entry_By As Received_By
			  ,p.[Deposit_Withdraw] As Deposit_Withdraw
			  ,p.Approval_By As Payment_Approved_By
			  ,p.Approval_Date As Payment_Approved_Date
			  ,p.Voucher_No As Vouchar_SN
			  ,p.[Trans_Reason] As Trans_Reason
			  ,p.[Remarks] As Remarks
			  ,p.[Entry_Date] As Entry_Date
			  ,p.[Entry_By] As Entry_By 
			  ,'' As Maturity_Days
			  ,dtl.BankName As Deposit_Bank_Name
			  ,dtl.Branch_Name As Deposit_Branch_Name
			  ,p.[Approval_Status] As Approval_Status
			  ,p.Rejected_Reason As Rejection_Reason
			  ,p.[Entry_Branch_ID] As Entry_Branch_ID
			  ,'' As OnlineOrderNo
			  ,'' As  OnlineEntry_Date  
				,'IPO' As EFT_TYPE
			FROM dbo.SBP_IPO_Customer_Broker_MoneyTransaction as p
			LEFT OUTER JOIN 
			dbo.SBP_EFT_Issue as e
			ON p.ID = e.Req_ID AND ISNULL(e.Req_Type,'')='" + Indication_PaymentTransaction.ReqType_EftIssue_IPOAccount + @"' 
			LEFT OUTER JOIN
			dbo.SBP_EFT_File_Info as f
			ON f.File_No=e.File_No_ID AND f.IsCanceled=0
			LEFT OUTER JOIN 
			SBP_IPO_Customer_Broker_Transaction_Details As dtl
			ON dtl.TransID=p.ID

			WHERE 
			--p.Payment_Media='EFT' AND 
			e.Req_ID IS NULL AND p.Approval_Status =1
			And dtl.Bank_ID=43
			AND
			p.Money_TransactionType_Name='EFTCancel' 
UNION All
			
			SELECT distinct
			  p.[ID] As Payment_ID
			  ,p.[Cust_Code] As Cust_Code
			  ,p.[Amount] AS Amount
			  ,p.[Received_Date] As Received_Date
			  ,p.Money_TransactionType_Name As Payment_Media
			  ,'' As Payment_Media_No
			  ,'' As Payment_Media_Date
			  ,dtl.[Bank_ID] As Bank_ID
			  ,dtl.BankName As Bank_Name
			  ,dtl.[Branch_ID] As Branch_ID
			  ,dtl.Branch_Name As Bank_Branch
			  ,dtl.Routing_No As RoutingNo
			  ,dtl.Bank_Acc_No As BankAccNo
			  ,p.Entry_By As Received_By
			  ,p.[Deposit_Withdraw] As Deposit_Withdraw
			  ,p.Approval_By As Payment_Approved_By
			  ,p.Approval_Date As Payment_Approved_Date
			  ,p.Voucher_No As Vouchar_SN
			  ,p.[Trans_Reason] As Trans_Reason
			  ,p.[Remarks] As Remarks
			  ,p.[Entry_Date] As Entry_Date
			  ,p.[Entry_By] As Entry_By 
			  ,'' As Maturity_Days
			  ,dtl.BankName As Deposit_Bank_Name
			  ,dtl.Branch_Name As Deposit_Branch_Name
			  ,p.[Approval_Status] As Approval_Status
			  ,p.Rejected_Reason As Rejection_Reason
			  ,p.[Entry_Branch_ID] As Entry_Branch_ID
			  ,'' As OnlineOrderNo
			  ,'' As  OnlineEntry_Date  
				,'IPO' As EFT_TYPE
			FROM dbo.SBP_IPO_Customer_Broker_MoneyTransaction as p
			JOIN
			(
				Select 
				S.Req_ID as REq_ID
				,S.File_No_ID as cancelID 
				From SBP_EFT_Issue As S
				Join SBP_EFT_File_Info as e
				on S.File_No_ID=e.File_No
                AND ISNULL(S.Req_Type,'')='" + Indication_PaymentTransaction.ReqType_EftIssue_IPOAccount + @"'
				Where e.IsCanceled=1 
				AND S.Req_ID NOT IN (Select iss.Req_ID From SBP_EFT_File_Info as fl JOIN SBP_EFT_Issue as iss ON fl.File_No=iss.File_No_ID Where fl.IsCanceled=0 AND iss.Req_Type='IPO')
				And S.Req_ID NOT IN (Select CONVERT(Decimal(18,0),REPLACE(Trans_Reason,Money_TransactionType_Name+'_',''))
						From SBP_IPO_Customer_Broker_MoneyTransaction
						Where Money_TransactionType_Name='EFTReturn') 
                And S.Req_ID NOT IN (Select CONVERT(Decimal(18,0),REPLACE(Trans_Reason,Money_TransactionType_Name+'_',''))
						From SBP_IPO_Customer_Broker_MoneyTransaction
						Where Money_TransactionType_Name='EFTCancel')
				--order by S.ID desc
			)As Cancel
			ON cancel.REq_ID=Convert(varchar(100),p.ID)
            Join SBP_IPO_Customer_Broker_Transaction_Details as dtl
			on dtl.TransID=p.ID
			Where dtl.Bank_ID=43
			
		union all
			SELECT distinct	
			--e.Req_ID
			p.[Payment_ID] As Payment_ID
			  ,p.[Cust_Code] As Cust_Code
			  ,p.[Amount] AS Amount
			  ,p.[Received_Date] As Received_Date
			  ,p.[Payment_Media] As Payment_Media
			  ,p.[Payment_Media_No] As Payment_Media_No
			  ,p.[Payment_Media_Date] As Payment_Media_Date
			  ,p.[Bank_ID] As Bank_ID
			  ,p.[Bank_Name] As Bank_Name
			  ,p.[Branch_ID] As Branch_ID
			  ,p.[Bank_Branch] As Bank_Branch
			  ,p.[RoutingNo] As RoutingNo
			  ,p.[BankAccNo] As BankAccNo
			  ,p.[Received_By] As Received_By
			  ,p.[Deposit_Withdraw] As Deposit_Withdraw
			  ,p.[Payment_Approved_By] As Payment_Approved_By
			  ,p.[Payment_Approved_Date] As Payment_Approved_Date
			  ,p.[Vouchar_SN] As Vouchar_SN
			  ,p.[Trans_Reason] As Trans_Reason
			  ,p.[Remarks] As Remarks
			  ,p.[Entry_Date] As Entry_Date
			  ,p.[Entry_By] As Entry_By 
			  ,p.[Maturity_Days] As Maturity_Days
			  ,p.[Deposit_Bank_Name] As Deposit_Bank_Name
			  ,p.[Deposit_Branch_Name] As Deposit_Branch_Name
			  ,p.[Approval_Status] As Approval_Status
			  ,p.[Rejection_Reason] As Rejection_Reason
			  ,p.[Entry_Branch_ID] As Entry_Branch_ID
			  ,p.[OnlineOrderNo] As OnlineOrderNo
			  ,p.[OnlineEntry_Date] As  OnlineEntry_Date                  
				,'TRADE' As EFT_TYPE
			FROM dbo.SBP_Payment_Posting_Request as p
			Join 
			(
				Select 
				S.Req_ID as REq_ID
				,S.File_No_ID as cancelID 
				From SBP_EFT_Issue As S
				Join SBP_EFT_File_Info as e
				on S.File_No_ID=e.File_No
                AND ISNULL(S.Req_Type,'')='" + Indication_PaymentTransaction.ReqType_EftIssue_TradeAccount + @"'
				Where e.IsCanceled=1 
				AND S.Req_ID NOT IN (Select iss.Req_ID From SBP_EFT_File_Info as fl JOIN SBP_EFT_Issue as iss ON fl.File_No=iss.File_No_ID Where fl.IsCanceled=0 AND iss.Req_Type='TRADE')
				And S.Req_ID NOT IN (Select CONVERT(Decimal(18,0),REPLACE(Trans_Reason,Payment_Media+'_',''))
						From SBP_Payment_Posting_Request
						Where Payment_Media='EFTReturn') 
                And S.Req_ID NOT IN (Select CONVERT(Decimal(18,0),REPLACE(Trans_Reason,Payment_Media+'_',''))
						From SBP_Payment_Posting_Request
						Where Payment_Media='EFTCancel')
				--order by S.ID desc
			)As Cancel
			ON cancel.REq_ID=Convert(varchar(100),p.Payment_ID)
		Where 
		p.Bank_ID=43

END
ELse
BEGIN
			SELECT distinct	p.[Payment_ID] As Payment_ID
			  ,p.[Cust_Code] As Cust_Code
			  ,p.[Amount] AS Amount
			  ,p.[Received_Date] As Received_Date
			  ,p.[Payment_Media] As Payment_Media
			  ,p.[Payment_Media_No] As Payment_Media_No
			  ,p.[Payment_Media_Date] As Payment_Media_Date
			  ,p.[Bank_ID] As Bank_ID
			  ,p.[Bank_Name] As Bank_Name
			  ,p.[Branch_ID] As Branch_ID
			  ,p.[Bank_Branch] As Bank_Branch
			  ,p.[RoutingNo] As RoutingNo
			  ,p.[BankAccNo] As BankAccNo
			  ,p.[Received_By] As Received_By
			  ,p.[Deposit_Withdraw] As Deposit_Withdraw
			  ,p.[Payment_Approved_By] As Payment_Approved_By
			  ,p.[Payment_Approved_Date] As Payment_Approved_Date
			  ,p.[Vouchar_SN] As Vouchar_SN
			  ,p.[Trans_Reason] As Trans_Reason
			  ,p.[Remarks] As Remarks
			  ,p.[Entry_Date] As Entry_Date
			  ,p.[Entry_By] As Entry_By 
			  ,p.[Maturity_Days] As Maturity_Days
			  ,p.[Deposit_Bank_Name] As Deposit_Bank_Name
			  ,p.[Deposit_Branch_Name] As Deposit_Branch_Name
			  ,p.[Approval_Status] As Approval_Status
			  ,p.[Rejection_Reason] As Rejection_Reason
			  ,p.[Entry_Branch_ID] As Entry_Branch_ID
			  ,p.[OnlineOrderNo] As OnlineOrderNo
			  ,p.[OnlineEntry_Date] As  OnlineEntry_Date                  
				,'TRADE' As EFT_TYPE
			FROM dbo.SBP_Payment_Posting_Request as p
			LEFT OUTER JOIN 
			dbo.SBP_EFT_Issue as e
			ON p.Payment_ID = e.Req_ID AND ISNULL(e.Req_Type,'')='" + Indication_PaymentTransaction.ReqType_EftIssue_TradeAccount + @"'
			LEFT OUTER JOIN
			dbo.SBP_EFT_File_Info as f
			ON f.File_No=e.File_No_ID AND f.IsCanceled=0 

			WHERE 
			--p.Payment_Media='EFT' AND 
			e.Req_ID IS NULL AND p.Approval_Status =1
			AND p.Payment_Media='EFT' AND p.Deposit_Withdraw ='Withdraw'
            And P.Bank_ID<>43 
			AND p.Payment_ID NOT IN (
						Select CONVERT(Decimal(18,0),REPLACE(Trans_Reason,Payment_Media+'_',''))
						From SBP_Payment_Posting_Request
						Where Payment_Media='EFTReturn' 
			)
            AND p.Payment_ID NOT IN (
						Select CONVERT(Decimal(18,0),REPLACE(Trans_Reason,Payment_Media+'_',''))
						From SBP_Payment_Posting_Request
						Where Payment_Media='EFTCancel' 
			)
UNION All
			SELECT distinct p.[ID] As Payment_ID
			  ,p.[Cust_Code] As Cust_Code
			  ,p.[Amount] AS Amount
			  ,p.[Received_Date] As Received_Date
			  ,p.Money_TransactionType_Name As Payment_Media
			  ,'' As Payment_Media_No
			  ,'' As Payment_Media_Date
			  ,dtl.[Bank_ID] As Bank_ID
			  ,dtl.BankName As Bank_Name
			  ,dtl.[Branch_ID] As Branch_ID
			  ,dtl.Branch_Name As Bank_Branch
			  ,dtl.Routing_No As RoutingNo
			  ,dtl.Bank_Acc_No As BankAccNo
			  ,p.Entry_By As Received_By
			  ,p.[Deposit_Withdraw] As Deposit_Withdraw
			  ,p.Approval_By As Payment_Approved_By
			  ,p.Approval_Date As Payment_Approved_Date
			  ,p.Voucher_No As Vouchar_SN
			  ,p.[Trans_Reason] As Trans_Reason
			  ,p.[Remarks] As Remarks
			  ,p.[Entry_Date] As Entry_Date
			  ,p.[Entry_By] As Entry_By 
			  ,'' As Maturity_Days
			  ,dtl.BankName As Deposit_Bank_Name
			  ,dtl.Branch_Name As Deposit_Branch_Name
			  ,p.[Approval_Status] As Approval_Status
			  ,p.Rejected_Reason As Rejection_Reason
			  ,p.[Entry_Branch_ID] As Entry_Branch_ID
			  ,'' As OnlineOrderNo
			  ,'' As  OnlineEntry_Date  
				,'IPO' As EFT_TYPE
			FROM dbo.SBP_IPO_Customer_Broker_MoneyTransaction as p
			LEFT OUTER JOIN 
			dbo.SBP_EFT_Issue as e
			ON p.ID = e.Req_ID AND ISNULL(e.Req_Type,'')='" + Indication_PaymentTransaction.ReqType_EftIssue_IPOAccount + @"' 
			LEFT OUTER JOIN
			dbo.SBP_EFT_File_Info as f
			ON f.File_No=e.File_No_ID AND f.IsCanceled=0
			LEFT OUTER JOIN 
			SBP_IPO_Customer_Broker_Transaction_Details As dtl
			ON dtl.TransID=p.ID			
			WHERE 
			--p.Payment_Media='EFT' AND 
			e.Req_ID IS NULL AND p.Approval_Status =1
			And dtl.Bank_ID<>43
			AND p.Money_TransactionType_Name='EFT'
UNION All
			
			SELECT distinct
			  p.[ID] As Payment_ID
			  ,p.[Cust_Code] As Cust_Code
			  ,p.[Amount] AS Amount
			  ,p.[Received_Date] As Received_Date
			  ,p.Money_TransactionType_Name As Payment_Media
			  ,'' As Payment_Media_No
			  ,'' As Payment_Media_Date
			  ,dtl.[Bank_ID] As Bank_ID
			  ,dtl.BankName As Bank_Name
			  ,dtl.[Branch_ID] As Branch_ID
			  ,dtl.Branch_Name As Bank_Branch
			  ,dtl.Routing_No As RoutingNo
			  ,dtl.Bank_Acc_No As BankAccNo
			  ,p.Entry_By As Received_By
			  ,p.[Deposit_Withdraw] As Deposit_Withdraw
			  ,p.Approval_By As Payment_Approved_By
			  ,p.Approval_Date As Payment_Approved_Date
			  ,p.Voucher_No As Vouchar_SN
			  ,p.[Trans_Reason] As Trans_Reason
			  ,p.[Remarks] As Remarks
			  ,p.[Entry_Date] As Entry_Date
			  ,p.[Entry_By] As Entry_By 
			  ,'' As Maturity_Days
			  ,dtl.BankName As Deposit_Bank_Name
			  ,dtl.Branch_Name As Deposit_Branch_Name
			  ,p.[Approval_Status] As Approval_Status
			  ,p.Rejected_Reason As Rejection_Reason
			  ,p.[Entry_Branch_ID] As Entry_Branch_ID
			  ,'' As OnlineOrderNo
			  ,'' As  OnlineEntry_Date  
				,'IPO' As EFT_TYPE
			FROM dbo.SBP_IPO_Customer_Broker_MoneyTransaction as p
			Join 
			(
				Select 
				S.Req_ID as REq_ID
				,S.File_No_ID as cancelID 
				From SBP_EFT_Issue As S
				Join SBP_EFT_File_Info as e
				on S.File_No_ID=e.File_No
                AND ISNULL(S.Req_Type,'')='" + Indication_PaymentTransaction.ReqType_EftIssue_IPOAccount + @"'
				Where e.IsCanceled=1 
				AND S.Req_ID NOT IN (Select iss.Req_ID From SBP_EFT_File_Info as fl JOIN SBP_EFT_Issue as iss ON fl.File_No=iss.File_No_ID Where fl.IsCanceled=0 AND iss.Req_Type='IPO')
				And S.Req_ID NOT IN (Select CONVERT(Decimal(18,0),REPLACE(Trans_Reason,Money_TransactionType_Name+'_',''))
						From SBP_IPO_Customer_Broker_MoneyTransaction
						Where Money_TransactionType_Name='EFTReturn')
                And S.Req_ID NOT IN (Select CONVERT(Decimal(18,0),REPLACE(Trans_Reason,Money_TransactionType_Name+'_',''))
						From SBP_IPO_Customer_Broker_MoneyTransaction
						Where Money_TransactionType_Name='EFTCancel') 
				--order by S.ID desc
			)As Cancel
			ON cancel.REq_ID=Convert(varchar(100),p.ID)
			JOIN 
			SBP_IPO_Customer_Broker_Transaction_Details As dtl
			ON dtl.TransID=p.ID
			Where dtl.Bank_ID<>43
	union all
			SELECT 	distinct
			--e.Req_ID
			p.[Payment_ID] As Payment_ID
			  ,p.[Cust_Code] As Cust_Code
			  ,p.[Amount] AS Amount
			  ,p.[Received_Date] As Received_Date
			  ,p.[Payment_Media] As Payment_Media
			  ,p.[Payment_Media_No] As Payment_Media_No
			  ,p.[Payment_Media_Date] As Payment_Media_Date
			  ,p.[Bank_ID] As Bank_ID
			  ,p.[Bank_Name] As Bank_Name
			  ,p.[Branch_ID] As Branch_ID
			  ,p.[Bank_Branch] As Bank_Branch
			  ,p.[RoutingNo] As RoutingNo
			  ,p.[BankAccNo] As BankAccNo
			  ,p.[Received_By] As Received_By
			  ,p.[Deposit_Withdraw] As Deposit_Withdraw
			  ,p.[Payment_Approved_By] As Payment_Approved_By
			  ,p.[Payment_Approved_Date] As Payment_Approved_Date
			  ,p.[Vouchar_SN] As Vouchar_SN
			  ,p.[Trans_Reason] As Trans_Reason
			  ,p.[Remarks] As Remarks
			  ,p.[Entry_Date] As Entry_Date
			  ,p.[Entry_By] As Entry_By 
			  ,p.[Maturity_Days] As Maturity_Days
			  ,p.[Deposit_Bank_Name] As Deposit_Bank_Name
			  ,p.[Deposit_Branch_Name] As Deposit_Branch_Name
			  ,p.[Approval_Status] As Approval_Status
			  ,p.[Rejection_Reason] As Rejection_Reason
			  ,p.[Entry_Branch_ID] As Entry_Branch_ID
			  ,p.[OnlineOrderNo] As OnlineOrderNo
			  ,p.[OnlineEntry_Date] As  OnlineEntry_Date                  
				,'TRADE' As EFT_TYPE
			FROM dbo.SBP_Payment_Posting_Request as p
            join
			(
				Select 
				S.Req_ID as REq_ID
				,S.File_No_ID as cancelID 
				From SBP_EFT_Issue As S
				Join SBP_EFT_File_Info as e
				on S.File_No_ID=e.File_No
                AND ISNULL(S.Req_Type,'')='" + Indication_PaymentTransaction.ReqType_EftIssue_TradeAccount + @"'
				Where e.IsCanceled=1 
				AND S.Req_ID NOT IN (Select iss.Req_ID From SBP_EFT_File_Info as fl JOIN SBP_EFT_Issue as iss ON fl.File_No=iss.File_No_ID Where fl.IsCanceled=0 AND iss.Req_Type='TRADE')
				And S.Req_ID NOT IN (Select CONVERT(Decimal(18,0),REPLACE(Trans_Reason,Payment_Media+'_',''))
						From SBP_Payment_Posting_Request
						Where Payment_Media='EFTReturn') 
                And S.Req_ID NOT IN (Select CONVERT(Decimal(18,0),REPLACE(Trans_Reason,Payment_Media+'_',''))
						From SBP_Payment_Posting_Request
						Where Payment_Media='EFTCancel')
				--order by S.ID desc
			)As Cancel
			ON cancel.REq_ID=Convert(varchar(100),p.Payment_ID)
		Where p.Bank_ID<>43
UNION All
            SELECT distinct
			   p.[Payment_ID] As Payment_ID
			  ,p.[Cust_Code] As Cust_Code
			  ,p.[Amount] AS Amount
			  ,p.[Received_Date] As Received_Date
			  ,p.[Payment_Media] As Payment_Media
			  ,ISNULL(p.[Payment_Media_No],'') As Payment_Media_No
			  ,p.[Payment_Media_Date] As Payment_Media_Date
			  ,p.[Bank_ID] As Bank_ID
			  ,p.[Bank_Name] As Bank_Name
			  ,p.[Branch_ID] As Branch_ID
			  ,p.[Bank_Branch] As Bank_Branch
			  ,p.[RoutingNo] As RoutingNo
			  ,p.[BankAccNo] As BankAccNo
			  ,p.[Received_By] As Received_By
			  ,p.[Deposit_Withdraw] As Deposit_Withdraw
			  ,ISNULL(p.[Payment_Approved_By],'') As Payment_Approved_By
			  ,ISNULL(p.[Payment_Approved_Date],'') As Payment_Approved_Date
			  ,p.[Vouchar_SN] As Vouchar_SN
			  ,p.[Trans_Reason] As Trans_Reason
			  ,p.[Remarks] As Remarks
			  ,p.[Entry_Date] As Entry_Date
			  ,p.[Entry_By] As Entry_By 
			  ,ISNULL(p.[Maturity_Days],'') As Maturity_Days
			  ,ISNULL(p.[Deposit_Bank_Name],'') As Deposit_Bank_Name
			  ,ISNULL(p.[Deposit_Branch_Name],'') As Deposit_Branch_Name
			  ,p.[Approval_Status] As Approval_Status
			  ,p.[Rejection_Reason] As Rejection_Reason
			  ,p.[Entry_Branch_ID] As Entry_Branch_ID
			  ,ISNULL(p.[OnlineOrderNo],'') As OnlineOrderNo
			  ,ISNULL(p.[OnlineEntry_Date],'') As  OnlineEntry_Date 
			           
				,'TRADE' As EFT_TYPE
			FROM dbo.SBP_Payment_Posting_Request as p
			LEFT OUTER JOIN 
			dbo.SBP_EFT_Issue as e
			ON p.Payment_ID = e.Req_ID AND ISNULL(e.Req_Type,'')='TRADE'
			LEFT OUTER JOIN
			dbo.SBP_EFT_File_Info as f
			ON f.File_No=e.File_No_ID AND f.IsCanceled=0

			WHERE 
			--p.Payment_Media='EFT' AND 
			e.Req_ID IS NULL AND p.Approval_Status =2
			And P.Bank_ID<>43
			AND p.Payment_Media='EFTCancel' 
			AND p.Payment_ID NOT IN (
						Select CONVERT(Decimal(18,0),REPLACE(Trans_Reason,Payment_Media+'_',''))
						From SBP_Payment_Posting_Request
						Where Payment_Media='EFTReturn' 
			)
            AND p.Payment_ID NOT IN (
						Select CONVERT(Decimal(18,0),REPLACE(Trans_Reason,Payment_Media+'_',''))
						From SBP_Payment_Posting_Request
						Where Payment_Media='EFTCancel' 
			)
SELECT distinct
			  p.[ID] As Payment_ID
			  ,p.[Cust_Code] As Cust_Code
			  ,p.[Amount] AS Amount
			  ,p.[Received_Date] As Received_Date
			  ,p.Money_TransactionType_Name As Payment_Media
			  ,'' As Payment_Media_No
			  ,'' As Payment_Media_Date
			  ,dtl.[Bank_ID] As Bank_ID
			  ,dtl.BankName As Bank_Name
			  ,dtl.[Branch_ID] As Branch_ID
			  ,dtl.Branch_Name As Bank_Branch
			  ,dtl.Routing_No As RoutingNo
			  ,dtl.Bank_Acc_No As BankAccNo
			  ,p.Entry_By As Received_By
			  ,p.[Deposit_Withdraw] As Deposit_Withdraw
			  ,p.Approval_By As Payment_Approved_By
			  ,p.Approval_Date As Payment_Approved_Date
			  ,p.Voucher_No As Vouchar_SN
			  ,p.[Trans_Reason] As Trans_Reason
			  ,p.[Remarks] As Remarks
			  ,p.[Entry_Date] As Entry_Date
			  ,p.[Entry_By] As Entry_By 
			  ,'' As Maturity_Days
			  ,dtl.BankName As Deposit_Bank_Name
			  ,dtl.Branch_Name As Deposit_Branch_Name
			  ,p.[Approval_Status] As Approval_Status
			  ,p.Rejected_Reason As Rejection_Reason
			  ,p.[Entry_Branch_ID] As Entry_Branch_ID
			  ,'' As OnlineOrderNo
			  ,'' As  OnlineEntry_Date  
				,'IPO' As EFT_TYPE
			FROM dbo.SBP_IPO_Customer_Broker_MoneyTransaction as p
			LEFT OUTER JOIN 
			dbo.SBP_EFT_Issue as e
			ON p.ID = e.Req_ID AND ISNULL(e.Req_Type,'')='" + Indication_PaymentTransaction.ReqType_EftIssue_TradeAccount + @"' 
			LEFT OUTER JOIN
			dbo.SBP_EFT_File_Info as f
			ON f.File_No=e.File_No_ID AND f.IsCanceled=0
			LEFT OUTER JOIN 
			SBP_IPO_Customer_Broker_Transaction_Details As dtl
			ON dtl.TransID=p.ID

			WHERE 
			--p.Payment_Media='EFT' AND 
			e.Req_ID IS NULL AND p.Approval_Status =1
			And dtl.Bank_ID=43
			AND
			p.Money_TransactionType_Name='EFTCancel'
            END"
                ;
            List<Payment_PostingBO> ResultPaymentPosting = new List<Payment_PostingBO>();
            try
            {
                _dbConnection.ConnectDatabase();
                //_dbConnection.ActiveStoredProcedure();

                using (SqlDataReader dr = _dbConnection.ExecuteReader(quryString))
                {

                    while (dr.Read())
                    {
                        Payment_PostingBO obj = new Payment_PostingBO();

                        obj.Payment_ID = dr["Payment_ID"].ToString();
                        obj.Cust_Code = Convert.ToString(dr["Cust_Code"]);
                        obj.Amount = Convert.ToDouble(dr["Amount"]);
                        obj.Approval_Status = Convert.ToInt32(dr["Approval_Status"]);
                        obj.Bank_ID = Convert.ToInt32(dr["Bank_ID"]);
                        obj.Bank_Name = Convert.ToString(dr["Bank_Name"]);
                        obj.Branch_ID = Convert.ToInt32(dr["Branch_ID"]);
                        obj.Bank_Branch = Convert.ToString(dr["Bank_Branch"]);
                        obj.Received_By = Convert.ToString(dr["Received_By"]);
                        obj.Received_Date = Convert.ToDateTime(dr["Received_Date"]);
                        obj.Payment_Media = Convert.ToString(dr["Payment_Media"]);
                        obj.Payment_Media_No = Convert.ToString(dr["Payment_Media_No"]);
                        obj.Payment_Media_Date = Convert.ToDateTime(dr["Payment_Media_Date"]);
                        obj.Deposit_Withdraw = Convert.ToString(dr["Deposit_Withdraw"]);
                        obj.Payment_Approved_By = Convert.ToString(dr["Payment_Approved_By"]);
                        obj.Payment_Approved_Date = Convert.ToDateTime(dr["Payment_Approved_Date"]);
                        obj.Rejection_Reason = Convert.ToString(dr["Rejection_Reason"]);
                        obj.Remarks = Convert.ToString(dr["Remarks"]);
                        obj.Vouchar_SN = Convert.ToString(dr["Vouchar_SN"]);
                        obj.Entry_By = Convert.ToString(dr["Entry_By"]);
                        obj.Entry_Date = Convert.ToDateTime(dr["Entry_Date"]);
                        obj.Maturity_Days = Convert.ToInt32(dr["Maturity_Days"]);
                        obj.Deposit_Bank_Name = Convert.ToString(dr["Deposit_Bank_Name"]);
                        obj.Deposit_Branch_Name = Convert.ToString(dr["Deposit_Branch_Name"]);
                        obj.Entry_Branch_ID = Convert.ToInt32(dr["Entry_Branch_ID"]);
                        obj.BankAccNo = Convert.ToString(dr["BankAccNo"]);
                        obj.RoutingNo = Convert.ToString(dr["RoutingNo"]);
                        obj.ReqType = Convert.ToString(dr["EFT_TYPE"]);

                        ResultPaymentPosting.Add(obj);
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return ResultPaymentPosting;
        }

        //v2
//        public List<Payment_PostingBO> GetAllApprovedRequest_BOList(string BankName)
//          {
//              string quryString =
//                  /*
//                                @"SELECT p.*
//                                -- p.Cust_Code as 'Cust_Code'
//                                --,p.Payment_ID as 'Payment_ID'
//                                --,p.Amount as 'Amount'
//                                --,p.Payment_Media as 'Payment_Media'
//                                --,p.Vouchar_SN as 'Vouchar_SN'
//                                --,p.Received_Date as 'Received_Date'

//                                --,e.Req_ID as 'Req_ID'
//                                --,e.Cust_Code as 'Cust_Code'

//                                FROM dbo.SBP_Payment_Posting_Request as p
//                                LEFT OUTER JOIN 
//                                dbo.SBP_EFT_Issue as e
//                                ON p.Payment_ID = e.Req_ID AND ISNULL(e.Req_Type,'')='" + Indication_PaymentTransaction.ReqType_EftIssue_TradeAccount + @"'
//                                WHERE 
//                                --p.Payment_Media='EFT' AND 
//                                e.Req_ID IS NULL AND p.Approval_Status =1 AND p.Payment_Media='EFT' 
//                                AND p.Payment_ID NOT IN (
//                                            Select CONVERT(INT,REPLACE(Trans_Reason,Payment_Media+'_',''))
//                                            From SBP_Payment_Posting_Request
//                                            Where Payment_Media='EFTReturn' 
//                                )";//"SELECT * FROM [SBP_Database].[dbo].[SBP_Payment_Posting_Request]";
//                   */
//                  @"Declare @BankName varchar(50)='"+BankName+ @"'
//                    IF(@BankName='THE CITY BANK LTD.')
//            BEGIN
//			SELECT distinct
//			   p.[Payment_ID] As Payment_ID
//			  ,p.[Cust_Code] As Cust_Code
//			  ,p.[Amount] AS Amount
//			  ,p.[Received_Date] As Received_Date
//			  ,p.[Payment_Media] As Payment_Media
//			  ,p.[Payment_Media_No] As Payment_Media_No
//			  ,p.[Payment_Media_Date] As Payment_Media_Date
//			  ,p.[Bank_ID] As Bank_ID
//			  ,p.[Bank_Name] As Bank_Name
//			  ,p.[Branch_ID] As Branch_ID
//			  ,p.[Bank_Branch] As Bank_Branch
//			  ,p.[RoutingNo] As RoutingNo
//			  ,p.[BankAccNo] As BankAccNo
//			  ,p.[Received_By] As Received_By
//			  ,p.[Deposit_Withdraw] As Deposit_Withdraw
//			  ,p.[Payment_Approved_By] As Payment_Approved_By
//			  ,p.[Payment_Approved_Date] As Payment_Approved_Date
//			  ,p.[Vouchar_SN] As Vouchar_SN
//			  ,p.[Trans_Reason] As Trans_Reason
//			  ,p.[Remarks] As Remarks
//			  ,p.[Entry_Date] As Entry_Date
//			  ,p.[Entry_By] As Entry_By 
//			  ,p.[Maturity_Days] As Maturity_Days
//			  ,p.[Deposit_Bank_Name] As Deposit_Bank_Name
//			  ,p.[Deposit_Branch_Name] As Deposit_Branch_Name
//			  ,p.[Approval_Status] As Approval_Status
//			  ,p.[Rejection_Reason] As Rejection_Reason
//			  ,p.[Entry_Branch_ID] As Entry_Branch_ID
//			  ,p.[OnlineOrderNo] As OnlineOrderNo
//			  ,p.[OnlineEntry_Date] As  OnlineEntry_Date             
//				,'TRADE' As EFT_TYPE
//			FROM dbo.SBP_Payment_Posting_Request as p
//			LEFT OUTER JOIN 
//			dbo.SBP_EFT_Issue as e
//			ON p.Payment_ID = e.Req_ID AND ISNULL(e.Req_Type,'')='" + Indication_PaymentTransaction.ReqType_EftIssue_TradeAccount + @"'
//			LEFT OUTER JOIN
//			dbo.SBP_EFT_File_Info as f
//			ON f.File_No=e.File_No_ID AND f.IsCanceled=0
//
//			WHERE 
//			--p.Payment_Media='EFT' AND 
//			e.Req_ID IS NULL AND p.Approval_Status =1
//			And P.Bank_ID=43
//			AND p.Payment_Media='EFT' 
//			AND p.Payment_ID NOT IN (
//						Select CONVERT(INT,REPLACE(Trans_Reason,Payment_Media+'_',''))
//						From SBP_Payment_Posting_Request
//						Where Payment_Media='EFTReturn' 
//			)
//            AND p.Payment_ID NOT IN (
//						Select CONVERT(INT,REPLACE(Trans_Reason,Payment_Media+'_',''))
//						From SBP_Payment_Posting_Request
//						Where Payment_Media='EFTCancel' 
//			)
//UNION All
//            SELECT distinct
//			   p.[Payment_ID] As Payment_ID
//			  ,p.[Cust_Code] As Cust_Code
//			  ,p.[Amount] AS Amount
//			  ,p.[Received_Date] As Received_Date
//			  ,p.[Payment_Media] As Payment_Media
//			  ,ISNULL(p.[Payment_Media_No],'') As Payment_Media_No
//			  ,p.[Payment_Media_Date] As Payment_Media_Date
//			  ,p.[Bank_ID] As Bank_ID
//			  ,p.[Bank_Name] As Bank_Name
//			  ,p.[Branch_ID] As Branch_ID
//			  ,p.[Bank_Branch] As Bank_Branch
//			  ,p.[RoutingNo] As RoutingNo
//			  ,p.[BankAccNo] As BankAccNo
//			  ,p.[Received_By] As Received_By
//			  ,p.[Deposit_Withdraw] As Deposit_Withdraw
//			  ,ISNULL(p.[Payment_Approved_By],'') As Payment_Approved_By
//			  ,ISNULL(p.[Payment_Approved_Date],'') As Payment_Approved_Date
//			  ,p.[Vouchar_SN] As Vouchar_SN
//			  ,p.[Trans_Reason] As Trans_Reason
//			  ,p.[Remarks] As Remarks
//			  ,p.[Entry_Date] As Entry_Date
//			  ,p.[Entry_By] As Entry_By 
//			  ,ISNULL(p.[Maturity_Days],'') As Maturity_Days
//			  ,ISNULL(p.[Deposit_Bank_Name],'') As Deposit_Bank_Name
//			  ,ISNULL(p.[Deposit_Branch_Name],'') As Deposit_Branch_Name
//			  ,p.[Approval_Status] As Approval_Status
//			  ,p.[Rejection_Reason] As Rejection_Reason
//			  ,p.[Entry_Branch_ID] As Entry_Branch_ID
//			  ,ISNULL(p.[OnlineOrderNo],'') As OnlineOrderNo
//			  ,ISNULL(p.[OnlineEntry_Date],'') As  OnlineEntry_Date 			           
//				,'TRADE' As EFT_TYPE
//			FROM dbo.SBP_Payment_Posting_Request as p
//			LEFT OUTER JOIN 
//			dbo.SBP_EFT_Issue as e
//			ON p.Payment_ID = e.Req_ID AND ISNULL(e.Req_Type,'')='" + Indication_PaymentTransaction.ReqType_EftIssue_TradeAccount + @"'
//			LEFT OUTER JOIN
//			dbo.SBP_EFT_File_Info as f
//			ON f.File_No=e.File_No_ID AND f.IsCanceled=0
//
//			WHERE 
//			--p.Payment_Media='EFT' AND 
//			e.Req_ID IS NULL AND p.Approval_Status =2
//			And P.Bank_ID=43
//			AND p.Payment_Media='EFTCancel' 
//			AND p.Payment_ID NOT IN (
//						Select CONVERT(INT,REPLACE(Trans_Reason,Payment_Media+'_',''))
//						From SBP_Payment_Posting_Request
//						Where Payment_Media='EFTReturn' 
//			)
//            AND p.Payment_ID NOT IN (
//						Select CONVERT(INT,REPLACE(Trans_Reason,Payment_Media+'_',''))
//						From SBP_Payment_Posting_Request
//						Where Payment_Media='EFTCancel' 
//			)
//UNION All
//			SELECT distinct
//			  p.[ID] As Payment_ID
//			  ,p.[Cust_Code] As Cust_Code
//			  ,p.[Amount] AS Amount
//			  ,p.[Received_Date] As Received_Date
//			  ,p.Money_TransactionType_Name As Payment_Media
//			  ,'' As Payment_Media_No
//			  ,'' As Payment_Media_Date
//			  ,dtl.[Bank_ID] As Bank_ID
//			  ,dtl.BankName As Bank_Name
//			  ,dtl.[Branch_ID] As Branch_ID
//			  ,dtl.Branch_Name As Bank_Branch
//			  ,dtl.Routing_No As RoutingNo
//			  ,dtl.Bank_Acc_No As BankAccNo
//			  ,p.Entry_By As Received_By
//			  ,p.[Deposit_Withdraw] As Deposit_Withdraw
//			  ,p.Approval_By As Payment_Approved_By
//			  ,p.Approval_Date As Payment_Approved_Date
//			  ,p.Voucher_No As Vouchar_SN
//			  ,p.[Trans_Reason] As Trans_Reason
//			  ,p.[Remarks] As Remarks
//			  ,p.[Entry_Date] As Entry_Date
//			  ,p.[Entry_By] As Entry_By 
//			  ,'' As Maturity_Days
//			  ,dtl.BankName As Deposit_Bank_Name
//			  ,dtl.Branch_Name As Deposit_Branch_Name
//			  ,p.[Approval_Status] As Approval_Status
//			  ,p.Rejected_Reason As Rejection_Reason
//			  ,p.[Entry_Branch_ID] As Entry_Branch_ID
//			  ,'' As OnlineOrderNo
//			  ,'' As  OnlineEntry_Date  
//				,'IPO' As EFT_TYPE
//			FROM dbo.SBP_IPO_Customer_Broker_MoneyTransaction as p
//			LEFT OUTER JOIN 
//			dbo.SBP_EFT_Issue as e
//			ON p.ID = e.Req_ID AND ISNULL(e.Req_Type,'')='" + Indication_PaymentTransaction.ReqType_EftIssue_IPOAccount+ @"' 
//			LEFT OUTER JOIN
//			dbo.SBP_EFT_File_Info as f
//			ON f.File_No=e.File_No_ID AND f.IsCanceled=0
//			LEFT OUTER JOIN 
//			SBP_IPO_Customer_Broker_Transaction_Details As dtl
//			ON dtl.TransID=p.ID
//
//			WHERE 
//			--p.Payment_Media='EFT' AND 
//			e.Req_ID IS NULL AND p.Approval_Status =1
//			And dtl.Bank_ID=43
//			AND
//			p.Money_TransactionType_Name='EFT' 
//UNION All
//			SELECT distinct
//			  p.[ID] As Payment_ID
//			  ,p.[Cust_Code] As Cust_Code
//			  ,p.[Amount] AS Amount
//			  ,p.[Received_Date] As Received_Date
//			  ,p.Money_TransactionType_Name As Payment_Media
//			  ,'' As Payment_Media_No
//			  ,'' As Payment_Media_Date
//			  ,dtl.[Bank_ID] As Bank_ID
//			  ,dtl.BankName As Bank_Name
//			  ,dtl.[Branch_ID] As Branch_ID
//			  ,dtl.Branch_Name As Bank_Branch
//			  ,dtl.Routing_No As RoutingNo
//			  ,dtl.Bank_Acc_No As BankAccNo
//			  ,p.Entry_By As Received_By
//			  ,p.[Deposit_Withdraw] As Deposit_Withdraw
//			  ,p.Approval_By As Payment_Approved_By
//			  ,p.Approval_Date As Payment_Approved_Date
//			  ,p.Voucher_No As Vouchar_SN
//			  ,p.[Trans_Reason] As Trans_Reason
//			  ,p.[Remarks] As Remarks
//			  ,p.[Entry_Date] As Entry_Date
//			  ,p.[Entry_By] As Entry_By 
//			  ,'' As Maturity_Days
//			  ,dtl.BankName As Deposit_Bank_Name
//			  ,dtl.Branch_Name As Deposit_Branch_Name
//			  ,p.[Approval_Status] As Approval_Status
//			  ,p.Rejected_Reason As Rejection_Reason
//			  ,p.[Entry_Branch_ID] As Entry_Branch_ID
//			  ,'' As OnlineOrderNo
//			  ,'' As  OnlineEntry_Date  
//				,'IPO' As EFT_TYPE
//			FROM dbo.SBP_IPO_Customer_Broker_MoneyTransaction as p
//			LEFT OUTER JOIN 
//			dbo.SBP_EFT_Issue as e
//			ON p.ID = e.Req_ID AND ISNULL(e.Req_Type,'')='" + Indication_PaymentTransaction.ReqType_EftIssue_IPOAccount + @"' 
//			LEFT OUTER JOIN
//			dbo.SBP_EFT_File_Info as f
//			ON f.File_No=e.File_No_ID AND f.IsCanceled=0
//			LEFT OUTER JOIN 
//			SBP_IPO_Customer_Broker_Transaction_Details As dtl
//			ON dtl.TransID=p.ID
//
//			WHERE 
//			--p.Payment_Media='EFT' AND 
//			e.Req_ID IS NULL AND p.Approval_Status =1
//			And dtl.Bank_ID=43
//			AND
//			p.Money_TransactionType_Name='EFTCancel' 
//UNION All
//			
//			SELECT distinct
//			  p.[ID] As Payment_ID
//			  ,p.[Cust_Code] As Cust_Code
//			  ,p.[Amount] AS Amount
//			  ,p.[Received_Date] As Received_Date
//			  ,p.Money_TransactionType_Name As Payment_Media
//			  ,'' As Payment_Media_No
//			  ,'' As Payment_Media_Date
//			  ,dtl.[Bank_ID] As Bank_ID
//			  ,dtl.BankName As Bank_Name
//			  ,dtl.[Branch_ID] As Branch_ID
//			  ,dtl.Branch_Name As Bank_Branch
//			  ,dtl.Routing_No As RoutingNo
//			  ,dtl.Bank_Acc_No As BankAccNo
//			  ,p.Entry_By As Received_By
//			  ,p.[Deposit_Withdraw] As Deposit_Withdraw
//			  ,p.Approval_By As Payment_Approved_By
//			  ,p.Approval_Date As Payment_Approved_Date
//			  ,p.Voucher_No As Vouchar_SN
//			  ,p.[Trans_Reason] As Trans_Reason
//			  ,p.[Remarks] As Remarks
//			  ,p.[Entry_Date] As Entry_Date
//			  ,p.[Entry_By] As Entry_By 
//			  ,'' As Maturity_Days
//			  ,dtl.BankName As Deposit_Bank_Name
//			  ,dtl.Branch_Name As Deposit_Branch_Name
//			  ,p.[Approval_Status] As Approval_Status
//			  ,p.Rejected_Reason As Rejection_Reason
//			  ,p.[Entry_Branch_ID] As Entry_Branch_ID
//			  ,'' As OnlineOrderNo
//			  ,'' As  OnlineEntry_Date  
//				,'IPO' As EFT_TYPE
//			FROM dbo.SBP_IPO_Customer_Broker_MoneyTransaction as p
//			JOIN
//			(
//				Select 
//				S.Req_ID as REq_ID
//				,S.File_No_ID as cancelID 
//				From SBP_EFT_Issue As S
//				Join SBP_EFT_File_Info as e
//				on S.File_No_ID=e.File_No
//                AND ISNULL(S.Req_Type,'')='" + Indication_PaymentTransaction.ReqType_EftIssue_IPOAccount + @"'
//				Where e.IsCanceled=1 
//				AND S.Req_ID NOT IN (Select iss.Req_ID From SBP_EFT_File_Info as fl JOIN SBP_EFT_Issue as iss ON fl.File_No=iss.File_No_ID Where fl.IsCanceled=0 AND iss.Req_Type='IPO')
//				And S.Req_ID NOT IN (Select CONVERT(INT,REPLACE(Trans_Reason,Money_TransactionType_Name+'_',''))
//						From SBP_IPO_Customer_Broker_MoneyTransaction
//						Where Money_TransactionType_Name='EFTReturn') 
//                And S.Req_ID NOT IN (Select CONVERT(INT,REPLACE(Trans_Reason,Money_TransactionType_Name+'_',''))
//						From SBP_IPO_Customer_Broker_MoneyTransaction
//						Where Money_TransactionType_Name='EFTCancel')
//				--order by S.ID desc
//			)As Cancel
//			ON cancel.REq_ID=Convert(varchar(100),p.ID)
//            Join SBP_IPO_Customer_Broker_Transaction_Details as dtl
//			on dtl.TransID=p.ID
//			Where dtl.Bank_ID=43
//			
//		union all
//			SELECT distinct	
//			--e.Req_ID
//			p.[Payment_ID] As Payment_ID
//			  ,p.[Cust_Code] As Cust_Code
//			  ,p.[Amount] AS Amount
//			  ,p.[Received_Date] As Received_Date
//			  ,p.[Payment_Media] As Payment_Media
//			  ,p.[Payment_Media_No] As Payment_Media_No
//			  ,p.[Payment_Media_Date] As Payment_Media_Date
//			  ,p.[Bank_ID] As Bank_ID
//			  ,p.[Bank_Name] As Bank_Name
//			  ,p.[Branch_ID] As Branch_ID
//			  ,p.[Bank_Branch] As Bank_Branch
//			  ,p.[RoutingNo] As RoutingNo
//			  ,p.[BankAccNo] As BankAccNo
//			  ,p.[Received_By] As Received_By
//			  ,p.[Deposit_Withdraw] As Deposit_Withdraw
//			  ,p.[Payment_Approved_By] As Payment_Approved_By
//			  ,p.[Payment_Approved_Date] As Payment_Approved_Date
//			  ,p.[Vouchar_SN] As Vouchar_SN
//			  ,p.[Trans_Reason] As Trans_Reason
//			  ,p.[Remarks] As Remarks
//			  ,p.[Entry_Date] As Entry_Date
//			  ,p.[Entry_By] As Entry_By 
//			  ,p.[Maturity_Days] As Maturity_Days
//			  ,p.[Deposit_Bank_Name] As Deposit_Bank_Name
//			  ,p.[Deposit_Branch_Name] As Deposit_Branch_Name
//			  ,p.[Approval_Status] As Approval_Status
//			  ,p.[Rejection_Reason] As Rejection_Reason
//			  ,p.[Entry_Branch_ID] As Entry_Branch_ID
//			  ,p.[OnlineOrderNo] As OnlineOrderNo
//			  ,p.[OnlineEntry_Date] As  OnlineEntry_Date                  
//				,'TRADE' As EFT_TYPE
//			FROM dbo.SBP_Payment_Posting_Request as p
//			Join 
//			(
//				Select 
//				S.Req_ID as REq_ID
//				,S.File_No_ID as cancelID 
//				From SBP_EFT_Issue As S
//				Join SBP_EFT_File_Info as e
//				on S.File_No_ID=e.File_No
//                AND ISNULL(S.Req_Type,'')='" + Indication_PaymentTransaction.ReqType_EftIssue_TradeAccount + @"'
//				Where e.IsCanceled=1 
//				AND S.Req_ID NOT IN (Select iss.Req_ID From SBP_EFT_File_Info as fl JOIN SBP_EFT_Issue as iss ON fl.File_No=iss.File_No_ID Where fl.IsCanceled=0 AND iss.Req_Type='TRADE')
//				And S.Req_ID NOT IN (Select CONVERT(INT,REPLACE(Trans_Reason,Payment_Media+'_',''))
//						From SBP_Payment_Posting_Request
//						Where Payment_Media='EFTReturn') 
//                And S.Req_ID NOT IN (Select CONVERT(INT,REPLACE(Trans_Reason,Payment_Media+'_',''))
//						From SBP_Payment_Posting_Request
//						Where Payment_Media='EFTCancel')
//				--order by S.ID desc
//			)As Cancel
//			ON cancel.REq_ID=Convert(varchar(100),p.Payment_ID)
//		Where 
//		p.Bank_ID=43
//
//END
//ELse
//BEGIN
//			SELECT distinct	p.[Payment_ID] As Payment_ID
//			  ,p.[Cust_Code] As Cust_Code
//			  ,p.[Amount] AS Amount
//			  ,p.[Received_Date] As Received_Date
//			  ,p.[Payment_Media] As Payment_Media
//			  ,p.[Payment_Media_No] As Payment_Media_No
//			  ,p.[Payment_Media_Date] As Payment_Media_Date
//			  ,p.[Bank_ID] As Bank_ID
//			  ,p.[Bank_Name] As Bank_Name
//			  ,p.[Branch_ID] As Branch_ID
//			  ,p.[Bank_Branch] As Bank_Branch
//			  ,p.[RoutingNo] As RoutingNo
//			  ,p.[BankAccNo] As BankAccNo
//			  ,p.[Received_By] As Received_By
//			  ,p.[Deposit_Withdraw] As Deposit_Withdraw
//			  ,p.[Payment_Approved_By] As Payment_Approved_By
//			  ,p.[Payment_Approved_Date] As Payment_Approved_Date
//			  ,p.[Vouchar_SN] As Vouchar_SN
//			  ,p.[Trans_Reason] As Trans_Reason
//			  ,p.[Remarks] As Remarks
//			  ,p.[Entry_Date] As Entry_Date
//			  ,p.[Entry_By] As Entry_By 
//			  ,p.[Maturity_Days] As Maturity_Days
//			  ,p.[Deposit_Bank_Name] As Deposit_Bank_Name
//			  ,p.[Deposit_Branch_Name] As Deposit_Branch_Name
//			  ,p.[Approval_Status] As Approval_Status
//			  ,p.[Rejection_Reason] As Rejection_Reason
//			  ,p.[Entry_Branch_ID] As Entry_Branch_ID
//			  ,p.[OnlineOrderNo] As OnlineOrderNo
//			  ,p.[OnlineEntry_Date] As  OnlineEntry_Date                  
//				,'TRADE' As EFT_TYPE
//			FROM dbo.SBP_Payment_Posting_Request as p
//			LEFT OUTER JOIN 
//			dbo.SBP_EFT_Issue as e
//			ON p.Payment_ID = e.Req_ID AND ISNULL(e.Req_Type,'')='" + Indication_PaymentTransaction.ReqType_EftIssue_TradeAccount+ @"'
//			LEFT OUTER JOIN
//			dbo.SBP_EFT_File_Info as f
//			ON f.File_No=e.File_No_ID AND f.IsCanceled=0 
//
//			WHERE 
//			--p.Payment_Media='EFT' AND 
//			e.Req_ID IS NULL AND p.Approval_Status =1
//			AND p.Payment_Media='EFT' And P.Bank_ID<>43 
//			AND p.Payment_ID NOT IN (
//						Select CONVERT(INT,REPLACE(Trans_Reason,Payment_Media+'_',''))
//						From SBP_Payment_Posting_Request
//						Where Payment_Media='EFTReturn' 
//			)
//            AND p.Payment_ID NOT IN (
//						Select CONVERT(INT,REPLACE(Trans_Reason,Payment_Media+'_',''))
//						From SBP_Payment_Posting_Request
//						Where Payment_Media='EFTCancel' 
//			)
//UNION All
//			SELECT distinct p.[ID] As Payment_ID
//			  ,p.[Cust_Code] As Cust_Code
//			  ,p.[Amount] AS Amount
//			  ,p.[Received_Date] As Received_Date
//			  ,p.Money_TransactionType_Name As Payment_Media
//			  ,'' As Payment_Media_No
//			  ,'' As Payment_Media_Date
//			  ,dtl.[Bank_ID] As Bank_ID
//			  ,dtl.BankName As Bank_Name
//			  ,dtl.[Branch_ID] As Branch_ID
//			  ,dtl.Branch_Name As Bank_Branch
//			  ,dtl.Routing_No As RoutingNo
//			  ,dtl.Bank_Acc_No As BankAccNo
//			  ,p.Entry_By As Received_By
//			  ,p.[Deposit_Withdraw] As Deposit_Withdraw
//			  ,p.Approval_By As Payment_Approved_By
//			  ,p.Approval_Date As Payment_Approved_Date
//			  ,p.Voucher_No As Vouchar_SN
//			  ,p.[Trans_Reason] As Trans_Reason
//			  ,p.[Remarks] As Remarks
//			  ,p.[Entry_Date] As Entry_Date
//			  ,p.[Entry_By] As Entry_By 
//			  ,'' As Maturity_Days
//			  ,dtl.BankName As Deposit_Bank_Name
//			  ,dtl.Branch_Name As Deposit_Branch_Name
//			  ,p.[Approval_Status] As Approval_Status
//			  ,p.Rejected_Reason As Rejection_Reason
//			  ,p.[Entry_Branch_ID] As Entry_Branch_ID
//			  ,'' As OnlineOrderNo
//			  ,'' As  OnlineEntry_Date  
//				,'IPO' As EFT_TYPE
//			FROM dbo.SBP_IPO_Customer_Broker_MoneyTransaction as p
//			LEFT OUTER JOIN 
//			dbo.SBP_EFT_Issue as e
//			ON p.ID = e.Req_ID AND ISNULL(e.Req_Type,'')='" + Indication_PaymentTransaction.ReqType_EftIssue_IPOAccount+ @"' 
//			LEFT OUTER JOIN
//			dbo.SBP_EFT_File_Info as f
//			ON f.File_No=e.File_No_ID AND f.IsCanceled=0
//			LEFT OUTER JOIN 
//			SBP_IPO_Customer_Broker_Transaction_Details As dtl
//			ON dtl.TransID=p.ID			
//			WHERE 
//			--p.Payment_Media='EFT' AND 
//			e.Req_ID IS NULL AND p.Approval_Status =1
//			And dtl.Bank_ID<>43
//			AND p.Money_TransactionType_Name='EFT'
//UNION All
//			
//			SELECT distinct
//			  p.[ID] As Payment_ID
//			  ,p.[Cust_Code] As Cust_Code
//			  ,p.[Amount] AS Amount
//			  ,p.[Received_Date] As Received_Date
//			  ,p.Money_TransactionType_Name As Payment_Media
//			  ,'' As Payment_Media_No
//			  ,'' As Payment_Media_Date
//			  ,dtl.[Bank_ID] As Bank_ID
//			  ,dtl.BankName As Bank_Name
//			  ,dtl.[Branch_ID] As Branch_ID
//			  ,dtl.Branch_Name As Bank_Branch
//			  ,dtl.Routing_No As RoutingNo
//			  ,dtl.Bank_Acc_No As BankAccNo
//			  ,p.Entry_By As Received_By
//			  ,p.[Deposit_Withdraw] As Deposit_Withdraw
//			  ,p.Approval_By As Payment_Approved_By
//			  ,p.Approval_Date As Payment_Approved_Date
//			  ,p.Voucher_No As Vouchar_SN
//			  ,p.[Trans_Reason] As Trans_Reason
//			  ,p.[Remarks] As Remarks
//			  ,p.[Entry_Date] As Entry_Date
//			  ,p.[Entry_By] As Entry_By 
//			  ,'' As Maturity_Days
//			  ,dtl.BankName As Deposit_Bank_Name
//			  ,dtl.Branch_Name As Deposit_Branch_Name
//			  ,p.[Approval_Status] As Approval_Status
//			  ,p.Rejected_Reason As Rejection_Reason
//			  ,p.[Entry_Branch_ID] As Entry_Branch_ID
//			  ,'' As OnlineOrderNo
//			  ,'' As  OnlineEntry_Date  
//				,'IPO' As EFT_TYPE
//			FROM dbo.SBP_IPO_Customer_Broker_MoneyTransaction as p
//			Join 
//			(
//				Select 
//				S.Req_ID as REq_ID
//				,S.File_No_ID as cancelID 
//				From SBP_EFT_Issue As S
//				Join SBP_EFT_File_Info as e
//				on S.File_No_ID=e.File_No
//                AND ISNULL(S.Req_Type,'')='" + Indication_PaymentTransaction.ReqType_EftIssue_IPOAccount + @"'
//				Where e.IsCanceled=1 
//				AND S.Req_ID NOT IN (Select iss.Req_ID From SBP_EFT_File_Info as fl JOIN SBP_EFT_Issue as iss ON fl.File_No=iss.File_No_ID Where fl.IsCanceled=0 AND iss.Req_Type='IPO')
//				And S.Req_ID NOT IN (Select CONVERT(INT,REPLACE(Trans_Reason,Money_TransactionType_Name+'_',''))
//						From SBP_IPO_Customer_Broker_MoneyTransaction
//						Where Money_TransactionType_Name='EFTReturn')
//                And S.Req_ID NOT IN (Select CONVERT(INT,REPLACE(Trans_Reason,Money_TransactionType_Name+'_',''))
//						From SBP_IPO_Customer_Broker_MoneyTransaction
//						Where Money_TransactionType_Name='EFTCancel') 
//				--order by S.ID desc
//			)As Cancel
//			ON cancel.REq_ID=Convert(varchar(100),p.ID)
//			JOIN 
//			SBP_IPO_Customer_Broker_Transaction_Details As dtl
//			ON dtl.TransID=p.ID
//			Where dtl.Bank_ID<>43
//	union all
//			SELECT 	distinct
//			--e.Req_ID
//			p.[Payment_ID] As Payment_ID
//			  ,p.[Cust_Code] As Cust_Code
//			  ,p.[Amount] AS Amount
//			  ,p.[Received_Date] As Received_Date
//			  ,p.[Payment_Media] As Payment_Media
//			  ,p.[Payment_Media_No] As Payment_Media_No
//			  ,p.[Payment_Media_Date] As Payment_Media_Date
//			  ,p.[Bank_ID] As Bank_ID
//			  ,p.[Bank_Name] As Bank_Name
//			  ,p.[Branch_ID] As Branch_ID
//			  ,p.[Bank_Branch] As Bank_Branch
//			  ,p.[RoutingNo] As RoutingNo
//			  ,p.[BankAccNo] As BankAccNo
//			  ,p.[Received_By] As Received_By
//			  ,p.[Deposit_Withdraw] As Deposit_Withdraw
//			  ,p.[Payment_Approved_By] As Payment_Approved_By
//			  ,p.[Payment_Approved_Date] As Payment_Approved_Date
//			  ,p.[Vouchar_SN] As Vouchar_SN
//			  ,p.[Trans_Reason] As Trans_Reason
//			  ,p.[Remarks] As Remarks
//			  ,p.[Entry_Date] As Entry_Date
//			  ,p.[Entry_By] As Entry_By 
//			  ,p.[Maturity_Days] As Maturity_Days
//			  ,p.[Deposit_Bank_Name] As Deposit_Bank_Name
//			  ,p.[Deposit_Branch_Name] As Deposit_Branch_Name
//			  ,p.[Approval_Status] As Approval_Status
//			  ,p.[Rejection_Reason] As Rejection_Reason
//			  ,p.[Entry_Branch_ID] As Entry_Branch_ID
//			  ,p.[OnlineOrderNo] As OnlineOrderNo
//			  ,p.[OnlineEntry_Date] As  OnlineEntry_Date                  
//				,'TRADE' As EFT_TYPE
//			FROM dbo.SBP_Payment_Posting_Request as p
//            join
//			(
//				Select 
//				S.Req_ID as REq_ID
//				,S.File_No_ID as cancelID 
//				From SBP_EFT_Issue As S
//				Join SBP_EFT_File_Info as e
//				on S.File_No_ID=e.File_No
//                AND ISNULL(S.Req_Type,'')='" + Indication_PaymentTransaction.ReqType_EftIssue_TradeAccount + @"'
//				Where e.IsCanceled=1 
//				AND S.Req_ID NOT IN (Select iss.Req_ID From SBP_EFT_File_Info as fl JOIN SBP_EFT_Issue as iss ON fl.File_No=iss.File_No_ID Where fl.IsCanceled=0 AND iss.Req_Type='TRADE')
//				And S.Req_ID NOT IN (Select CONVERT(INT,REPLACE(Trans_Reason,Payment_Media+'_',''))
//						From SBP_Payment_Posting_Request
//						Where Payment_Media='EFTReturn') 
//                And S.Req_ID NOT IN (Select CONVERT(INT,REPLACE(Trans_Reason,Payment_Media+'_',''))
//						From SBP_Payment_Posting_Request
//						Where Payment_Media='EFTCancel')
//				--order by S.ID desc
//			)As Cancel
//			ON cancel.REq_ID=Convert(varchar(100),p.Payment_ID)
//		Where p.Bank_ID<>43
//UNION All
//            SELECT distinct
//			   p.[Payment_ID] As Payment_ID
//			  ,p.[Cust_Code] As Cust_Code
//			  ,p.[Amount] AS Amount
//			  ,p.[Received_Date] As Received_Date
//			  ,p.[Payment_Media] As Payment_Media
//			  ,ISNULL(p.[Payment_Media_No],'') As Payment_Media_No
//			  ,p.[Payment_Media_Date] As Payment_Media_Date
//			  ,p.[Bank_ID] As Bank_ID
//			  ,p.[Bank_Name] As Bank_Name
//			  ,p.[Branch_ID] As Branch_ID
//			  ,p.[Bank_Branch] As Bank_Branch
//			  ,p.[RoutingNo] As RoutingNo
//			  ,p.[BankAccNo] As BankAccNo
//			  ,p.[Received_By] As Received_By
//			  ,p.[Deposit_Withdraw] As Deposit_Withdraw
//			  ,ISNULL(p.[Payment_Approved_By],'') As Payment_Approved_By
//			  ,ISNULL(p.[Payment_Approved_Date],'') As Payment_Approved_Date
//			  ,p.[Vouchar_SN] As Vouchar_SN
//			  ,p.[Trans_Reason] As Trans_Reason
//			  ,p.[Remarks] As Remarks
//			  ,p.[Entry_Date] As Entry_Date
//			  ,p.[Entry_By] As Entry_By 
//			  ,ISNULL(p.[Maturity_Days],'') As Maturity_Days
//			  ,ISNULL(p.[Deposit_Bank_Name],'') As Deposit_Bank_Name
//			  ,ISNULL(p.[Deposit_Branch_Name],'') As Deposit_Branch_Name
//			  ,p.[Approval_Status] As Approval_Status
//			  ,p.[Rejection_Reason] As Rejection_Reason
//			  ,p.[Entry_Branch_ID] As Entry_Branch_ID
//			  ,ISNULL(p.[OnlineOrderNo],'') As OnlineOrderNo
//			  ,ISNULL(p.[OnlineEntry_Date],'') As  OnlineEntry_Date 
//			           
//				,'TRADE' As EFT_TYPE
//			FROM dbo.SBP_Payment_Posting_Request as p
//			LEFT OUTER JOIN 
//			dbo.SBP_EFT_Issue as e
//			ON p.Payment_ID = e.Req_ID AND ISNULL(e.Req_Type,'')='TRADE'
//			LEFT OUTER JOIN
//			dbo.SBP_EFT_File_Info as f
//			ON f.File_No=e.File_No_ID AND f.IsCanceled=0
//
//			WHERE 
//			--p.Payment_Media='EFT' AND 
//			e.Req_ID IS NULL AND p.Approval_Status =2
//			And P.Bank_ID<>43
//			AND p.Payment_Media='EFTCancel' 
//			AND p.Payment_ID NOT IN (
//						Select CONVERT(INT,REPLACE(Trans_Reason,Payment_Media+'_',''))
//						From SBP_Payment_Posting_Request
//						Where Payment_Media='EFTReturn' 
//			)
//            AND p.Payment_ID NOT IN (
//						Select CONVERT(INT,REPLACE(Trans_Reason,Payment_Media+'_',''))
//						From SBP_Payment_Posting_Request
//						Where Payment_Media='EFTCancel' 
//			)
//SELECT distinct
//			  p.[ID] As Payment_ID
//			  ,p.[Cust_Code] As Cust_Code
//			  ,p.[Amount] AS Amount
//			  ,p.[Received_Date] As Received_Date
//			  ,p.Money_TransactionType_Name As Payment_Media
//			  ,'' As Payment_Media_No
//			  ,'' As Payment_Media_Date
//			  ,dtl.[Bank_ID] As Bank_ID
//			  ,dtl.BankName As Bank_Name
//			  ,dtl.[Branch_ID] As Branch_ID
//			  ,dtl.Branch_Name As Bank_Branch
//			  ,dtl.Routing_No As RoutingNo
//			  ,dtl.Bank_Acc_No As BankAccNo
//			  ,p.Entry_By As Received_By
//			  ,p.[Deposit_Withdraw] As Deposit_Withdraw
//			  ,p.Approval_By As Payment_Approved_By
//			  ,p.Approval_Date As Payment_Approved_Date
//			  ,p.Voucher_No As Vouchar_SN
//			  ,p.[Trans_Reason] As Trans_Reason
//			  ,p.[Remarks] As Remarks
//			  ,p.[Entry_Date] As Entry_Date
//			  ,p.[Entry_By] As Entry_By 
//			  ,'' As Maturity_Days
//			  ,dtl.BankName As Deposit_Bank_Name
//			  ,dtl.Branch_Name As Deposit_Branch_Name
//			  ,p.[Approval_Status] As Approval_Status
//			  ,p.Rejected_Reason As Rejection_Reason
//			  ,p.[Entry_Branch_ID] As Entry_Branch_ID
//			  ,'' As OnlineOrderNo
//			  ,'' As  OnlineEntry_Date  
//				,'IPO' As EFT_TYPE
//			FROM dbo.SBP_IPO_Customer_Broker_MoneyTransaction as p
//			LEFT OUTER JOIN 
//			dbo.SBP_EFT_Issue as e
//			ON p.ID = e.Req_ID AND ISNULL(e.Req_Type,'')='" + Indication_PaymentTransaction.ReqType_EftIssue_TradeAccount + @"' 
//			LEFT OUTER JOIN
//			dbo.SBP_EFT_File_Info as f
//			ON f.File_No=e.File_No_ID AND f.IsCanceled=0
//			LEFT OUTER JOIN 
//			SBP_IPO_Customer_Broker_Transaction_Details As dtl
//			ON dtl.TransID=p.ID
//
//			WHERE 
//			--p.Payment_Media='EFT' AND 
//			e.Req_ID IS NULL AND p.Approval_Status =1
//			And dtl.Bank_ID=43
//			AND
//			p.Money_TransactionType_Name='EFTCancel'
//            END"
//                  ;
//              List<Payment_PostingBO> ResultPaymentPosting = new List<Payment_PostingBO>();
//              try
//              {
//                  _dbConnection.ConnectDatabase();
//                  //_dbConnection.ActiveStoredProcedure();
                  
//                  using(SqlDataReader dr= _dbConnection.ExecuteReader(quryString)) 
//                  {

//                      while (dr.Read())
//                      {
//                          Payment_PostingBO obj = new Payment_PostingBO();
                                
//                          obj.Payment_ID = Convert.ToInt32(dr["Payment_ID"]);
//                          obj.Cust_Code = Convert.ToString(dr["Cust_Code"]);
//                          obj.Amount = Convert.ToDouble(dr["Amount"]);
//                          obj.Approval_Status = Convert.ToInt32(dr["Approval_Status"]);
//                          obj.Bank_ID = Convert.ToInt32(dr["Bank_ID"]);
//                          obj.Bank_Name = Convert.ToString(dr["Bank_Name"]);
//                          obj.Branch_ID = Convert.ToInt32(dr["Branch_ID"]);
//                          obj.Bank_Branch = Convert.ToString(dr["Bank_Branch"]);
//                          obj.Received_By = Convert.ToString(dr["Received_By"]);
//                          obj.Received_Date = Convert.ToDateTime(dr["Received_Date"]);
//                          obj.Payment_Media = Convert.ToString(dr["Payment_Media"]);
//                          obj.Payment_Media_No = Convert.ToString(dr["Payment_Media_No"]);
//                          obj.Payment_Media_Date = Convert.ToDateTime(dr["Payment_Media_Date"]);
//                          obj.Deposit_Withdraw = Convert.ToString(dr["Deposit_Withdraw"]);
//                          obj.Payment_Approved_By = Convert.ToString(dr["Payment_Approved_By"]);
//                          obj.Payment_Approved_Date = Convert.ToDateTime(dr["Payment_Approved_Date"]);
//                          obj.Rejection_Reason = Convert.ToString(dr["Rejection_Reason"]);
//                          obj.Remarks = Convert.ToString(dr["Remarks"]);
//                          obj.Vouchar_SN = Convert.ToString(dr["Vouchar_SN"]);
//                          obj.Entry_By = Convert.ToString(dr["Entry_By"]);
//                          obj.Entry_Date = Convert.ToDateTime(dr["Entry_Date"]);
//                          obj.Maturity_Days = Convert.ToInt32(dr["Maturity_Days"]);
//                          obj.Deposit_Bank_Name = Convert.ToString(dr["Deposit_Bank_Name"]);
//                          obj.Deposit_Branch_Name = Convert.ToString(dr["Deposit_Branch_Name"]);
//                          obj.Entry_Branch_ID = Convert.ToInt32(dr["Entry_Branch_ID"]);
//                          obj.BankAccNo = Convert.ToString(dr["BankAccNo"]);
//                          obj.RoutingNo = Convert.ToString(dr["RoutingNo"]);
//                          obj.ReqType = Convert.ToString(dr["EFT_TYPE"]);

//                          ResultPaymentPosting.Add(obj);
//                      }
//                  }
//              }
//              catch (Exception exception)
//              {
//                  throw exception;
//              }
//              finally
//              {
//                  _dbConnection.CloseDatabase();
//              }
//              return ResultPaymentPosting;
//          }


        // v1

        //          public List<Payment_PostingBO> GetAllApprovedRequest_BOList(string BankName)
        //          {
        //              string quryString =
        //                  /*
        //                                @"SELECT p.*
        //                                -- p.Cust_Code as 'Cust_Code'
        //                                --,p.Payment_ID as 'Payment_ID'
        //                                --,p.Amount as 'Amount'
        //                                --,p.Payment_Media as 'Payment_Media'
        //                                --,p.Vouchar_SN as 'Vouchar_SN'
        //                                --,p.Received_Date as 'Received_Date'

        //                                --,e.Req_ID as 'Req_ID'
        //                                --,e.Cust_Code as 'Cust_Code'

        //                                FROM dbo.SBP_Payment_Posting_Request as p
        //                                LEFT OUTER JOIN 
        //                                dbo.SBP_EFT_Issue as e
        //                                ON p.Payment_ID = e.Req_ID AND ISNULL(e.Req_Type,'')='" + Indication_PaymentTransaction.ReqType_EftIssue_TradeAccount + @"'
        //                                WHERE 
        //                                --p.Payment_Media='EFT' AND 
        //                                e.Req_ID IS NULL AND p.Approval_Status =1 AND p.Payment_Media='EFT' 
        //                                AND p.Payment_ID NOT IN (
        //                                            Select CONVERT(INT,REPLACE(Trans_Reason,Payment_Media+'_',''))
        //                                            From SBP_Payment_Posting_Request
        //                                            Where Payment_Media='EFTReturn' 
        //                                )";//"SELECT * FROM [SBP_Database].[dbo].[SBP_Payment_Posting_Request]";
        //                   */
        //                  @"Declare @BankName varchar(50)='"+BankName+ @"'
        //                    IF(@BankName='THE CITY BANK LTD.')
        //                    BEGIN
        //	                    SELECT 
        //	                       p.[Payment_ID] As Payment_ID
        //                          ,p.[Cust_Code] As Cust_Code
        //                          ,p.[Amount] AS Amount
        //                          ,p.[Received_Date] As Received_Date
        //                          ,p.[Payment_Media] As Payment_Media
        //                          ,p.[Payment_Media_No] As Payment_Media_No
        //                          ,p.[Payment_Media_Date] As Payment_Media_Date
        //                          ,p.[Bank_ID] As Bank_ID
        //                          ,p.[Bank_Name] As Bank_Name
        //                          ,p.[Branch_ID] As Branch_ID
        //                          ,p.[Bank_Branch] As Bank_Branch
        //                          ,p.[RoutingNo] As RoutingNo
        //                          ,p.[BankAccNo] As BankAccNo
        //                          ,p.[Received_By] As Received_By
        //                          ,p.[Deposit_Withdraw] As Deposit_Withdraw
        //                          ,p.[Payment_Approved_By] As Payment_Approved_By
        //                          ,p.[Payment_Approved_Date] As Payment_Approved_Date
        //                          ,p.[Vouchar_SN] As Vouchar_SN
        //                          ,p.[Trans_Reason] As Trans_Reason
        //                          ,p.[Remarks] As Remarks
        //                          ,p.[Entry_Date] As Entry_Date
        //                          ,p.[Entry_By] As Entry_By 
        //                          ,p.[Maturity_Days] As Maturity_Days
        //                          ,p.[Deposit_Bank_Name] As Deposit_Bank_Name
        //                          ,p.[Deposit_Branch_Name] As Deposit_Branch_Name
        //                          ,p.[Approval_Status] As Approval_Status
        //                          ,p.[Rejection_Reason] As Rejection_Reason
        //                          ,p.[Entry_Branch_ID] As Entry_Branch_ID
        //                          ,p.[OnlineOrderNo] As OnlineOrderNo
        //                          ,p.[OnlineEntry_Date] As  OnlineEntry_Date             
        //                            ,'TRADE' As EFT_TYPE
        //	                    FROM dbo.SBP_Payment_Posting_Request as p
        //	                    LEFT OUTER JOIN 
        //	                    dbo.SBP_EFT_Issue as e
        //	                    ON p.Payment_ID = e.Req_ID AND ISNULL(e.Req_Type,'')='" + Indication_PaymentTransaction.ReqType_EftIssue_TradeAccount + @"'
        //	                    --And P.Bank_ID=43
        //	                    WHERE 
        //	                    --p.Payment_Media='EFT' AND 
        //	                    e.Req_ID IS NULL AND p.Approval_Status =1
        //	                    And P.Bank_ID=43
        //	                    AND p.Payment_Media='EFT' 
        //	                    AND p.Payment_ID NOT IN (
        //				                    Select CONVERT(INT,REPLACE(Trans_Reason,Payment_Media+'_',''))
        //				                    From SBP_Payment_Posting_Request
        //				                    Where Payment_Media='EFTReturn' 
        //	                    )
        //                    UNION All
        //	                    SELECT p.[ID] As Payment_ID
        //                          ,p.[Cust_Code] As Cust_Code
        //                          ,p.[Amount] AS Amount
        //                          ,p.[Received_Date] As Received_Date
        //                          ,p.Money_TransactionType_Name As Payment_Media
        //                          ,'' As Payment_Media_No
        //                          ,'' As Payment_Media_Date
        //                          ,dtl.[Bank_ID] As Bank_ID
        //                          ,dtl.BankName As Bank_Name
        //                          ,dtl.[Branch_ID] As Branch_ID
        //                          ,dtl.Branch_Name As Bank_Branch
        //                          ,dtl.Routing_No As RoutingNo
        //                          ,dtl.Bank_Acc_No As BankAccNo
        //                          ,p.Entry_By As Received_By
        //                          ,p.[Deposit_Withdraw] As Deposit_Withdraw
        //                          ,p.Approval_By As Payment_Approved_By
        //                          ,p.Approval_Date As Payment_Approved_Date
        //                          ,p.Voucher_No As Vouchar_SN
        //                          ,p.[Trans_Reason] As Trans_Reason
        //                          ,p.[Remarks] As Remarks
        //                          ,p.[Entry_Date] As Entry_Date
        //                          ,p.[Entry_By] As Entry_By 
        //                          ,'' As Maturity_Days
        //                          ,dtl.BankName As Deposit_Bank_Name
        //                          ,dtl.Branch_Name As Deposit_Branch_Name
        //                          ,p.[Approval_Status] As Approval_Status
        //                          ,p.Rejected_Reason As Rejection_Reason
        //                          ,p.[Entry_Branch_ID] As Entry_Branch_ID
        //                          ,'' As OnlineOrderNo
        //                          ,'' As  OnlineEntry_Date  
        //                            ,'IPO' As EFT_TYPE
        //	                    FROM dbo.SBP_IPO_Customer_Broker_MoneyTransaction as p
        //	                    LEFT OUTER JOIN 
        //	                    dbo.SBP_EFT_Issue as e
        //	                    ON p.ID = e.Req_ID AND ISNULL(e.Req_Type,'')='IPO' 
        //	                    LEFT OUTER JOIN 
        //	                    SBP_IPO_Customer_Broker_Transaction_Details As dtl
        //	                    ON dtl.TransID=p.ID
        //                    	
        //	                    WHERE 
        //	                    --p.Payment_Media='EFT' AND 
        //	                    e.Req_ID IS NULL AND p.Approval_Status =1
        //	                    And dtl.Bank_ID=43
        //	                    AND
        //	                    p.Money_TransactionType_Name='EFT' 
        //                    END
        //                    ELse
        //                    BEGIN
        //	                    SELECT 	p.[Payment_ID] As Payment_ID
        //                          ,p.[Cust_Code] As Cust_Code
        //                          ,p.[Amount] AS Amount
        //                          ,p.[Received_Date] As Received_Date
        //                          ,p.[Payment_Media] As Payment_Media
        //                          ,p.[Payment_Media_No] As Payment_Media_No
        //                          ,p.[Payment_Media_Date] As Payment_Media_Date
        //                          ,p.[Bank_ID] As Bank_ID
        //                          ,p.[Bank_Name] As Bank_Name
        //                          ,p.[Branch_ID] As Branch_ID
        //                          ,p.[Bank_Branch] As Bank_Branch
        //                          ,p.[RoutingNo] As RoutingNo
        //                          ,p.[BankAccNo] As BankAccNo
        //                          ,p.[Received_By] As Received_By
        //                          ,p.[Deposit_Withdraw] As Deposit_Withdraw
        //                          ,p.[Payment_Approved_By] As Payment_Approved_By
        //                          ,p.[Payment_Approved_Date] As Payment_Approved_Date
        //                          ,p.[Vouchar_SN] As Vouchar_SN
        //                          ,p.[Trans_Reason] As Trans_Reason
        //                          ,p.[Remarks] As Remarks
        //                          ,p.[Entry_Date] As Entry_Date
        //                          ,p.[Entry_By] As Entry_By 
        //                          ,p.[Maturity_Days] As Maturity_Days
        //                          ,p.[Deposit_Bank_Name] As Deposit_Bank_Name
        //                          ,p.[Deposit_Branch_Name] As Deposit_Branch_Name
        //                          ,p.[Approval_Status] As Approval_Status
        //                          ,p.[Rejection_Reason] As Rejection_Reason
        //                          ,p.[Entry_Branch_ID] As Entry_Branch_ID
        //                          ,p.[OnlineOrderNo] As OnlineOrderNo
        //                          ,p.[OnlineEntry_Date] As  OnlineEntry_Date                  
        //                            ,'TRADE' As EFT_TYPE
        //	                    FROM dbo.SBP_Payment_Posting_Request as p
        //	                    LEFT OUTER JOIN 
        //	                    dbo.SBP_EFT_Issue as e
        //	                    ON p.Payment_ID = e.Req_ID AND ISNULL(e.Req_Type,'')='TRADE' 
        //                    	
        //	                    WHERE 
        //	                    --p.Payment_Media='EFT' AND 
        //	                    e.Req_ID IS NULL AND p.Approval_Status =1
        //	                    AND p.Payment_Media='EFT' And P.Bank_ID<>43 
        //	                    AND p.Payment_ID NOT IN (
        //				                    Select CONVERT(INT,REPLACE(Trans_Reason,Payment_Media+'_',''))
        //				                    From SBP_Payment_Posting_Request
        //				                    Where Payment_Media='EFTReturn' 
        //	                    )
        //                    UNION All
        //	                    SELECT p.[ID] As Payment_ID
        //                          ,p.[Cust_Code] As Cust_Code
        //                          ,p.[Amount] AS Amount
        //                          ,p.[Received_Date] As Received_Date
        //                          ,p.Money_TransactionType_Name As Payment_Media
        //                          ,'' As Payment_Media_No
        //                          ,'' As Payment_Media_Date
        //                          ,dtl.[Bank_ID] As Bank_ID
        //                          ,dtl.BankName As Bank_Name
        //                          ,dtl.[Branch_ID] As Branch_ID
        //                          ,dtl.Branch_Name As Bank_Branch
        //                          ,dtl.Routing_No As RoutingNo
        //                          ,dtl.Bank_Acc_No As BankAccNo
        //                          ,p.Entry_By As Received_By
        //                          ,p.[Deposit_Withdraw] As Deposit_Withdraw
        //                          ,p.Approval_By As Payment_Approved_By
        //                          ,p.Approval_Date As Payment_Approved_Date
        //                          ,p.Voucher_No As Vouchar_SN
        //                          ,p.[Trans_Reason] As Trans_Reason
        //                          ,p.[Remarks] As Remarks
        //                          ,p.[Entry_Date] As Entry_Date
        //                          ,p.[Entry_By] As Entry_By 
        //                          ,'' As Maturity_Days
        //                          ,dtl.BankName As Deposit_Bank_Name
        //                          ,dtl.Branch_Name As Deposit_Branch_Name
        //                          ,p.[Approval_Status] As Approval_Status
        //                          ,p.Rejected_Reason As Rejection_Reason
        //                          ,p.[Entry_Branch_ID] As Entry_Branch_ID
        //                          ,'' As OnlineOrderNo
        //                          ,'' As  OnlineEntry_Date  
        //                            ,'IPO' As EFT_TYPE
        //	                    FROM dbo.SBP_IPO_Customer_Broker_MoneyTransaction as p
        //	                    LEFT OUTER JOIN 
        //	                    dbo.SBP_EFT_Issue as e
        //	                    ON p.ID = e.Req_ID AND ISNULL(e.Req_Type,'')='IPO' 
        //	                    LEFT OUTER JOIN 
        //	                    SBP_IPO_Customer_Broker_Transaction_Details As dtl
        //	                    ON dtl.TransID=p.ID
        //	                    --And dtl.Bank_ID<>43
        //	                    WHERE 
        //	                    --p.Payment_Media='EFT' AND 
        //	                    e.Req_ID IS NULL AND p.Approval_Status =1
        //	                    And dtl.Bank_ID<>43
        //	                    AND p.Money_TransactionType_Name='EFT'
        //                    END"
        //                  ;
        //              List<Payment_PostingBO> ResultPaymentPosting = new List<Payment_PostingBO>();
        //              try
        //              {
        //                  _dbConnection.ConnectDatabase();
        //                  //_dbConnection.ActiveStoredProcedure();

        //                  using(SqlDataReader dr= _dbConnection.ExecuteReader(quryString)) 
        //                  {

        //                      while (dr.Read())
        //                      {
        //                          Payment_PostingBO obj = new Payment_PostingBO();

        //                          obj.Payment_ID = Convert.ToInt32(dr["Payment_ID"]);
        //                          obj.Cust_Code = Convert.ToString(dr["Cust_Code"]);
        //                          obj.Amount = Convert.ToDouble(dr["Amount"]);
        //                          obj.Approval_Status = Convert.ToInt32(dr["Approval_Status"]);
        //                          obj.Bank_ID = Convert.ToInt32(dr["Bank_ID"]);
        //                          obj.Bank_Name = Convert.ToString(dr["Bank_Name"]);
        //                          obj.Branch_ID = Convert.ToInt32(dr["Branch_ID"]);
        //                          obj.Bank_Branch = Convert.ToString(dr["Bank_Branch"]);
        //                          obj.Received_By = Convert.ToString(dr["Received_By"]);
        //                          obj.Received_Date = Convert.ToDateTime(dr["Received_Date"]);
        //                          obj.Payment_Media = Convert.ToString(dr["Payment_Media"]);
        //                          obj.Payment_Media_No = Convert.ToString(dr["Payment_Media_No"]);
        //                          obj.Payment_Media_Date = Convert.ToDateTime(dr["Payment_Media_Date"]);
        //                          obj.Deposit_Withdraw = Convert.ToString(dr["Deposit_Withdraw"]);
        //                          obj.Payment_Approved_By = Convert.ToString(dr["Payment_Approved_By"]);
        //                          obj.Payment_Approved_Date = Convert.ToDateTime(dr["Payment_Approved_Date"]);
        //                          obj.Rejection_Reason = Convert.ToString(dr["Rejection_Reason"]);
        //                          obj.Remarks = Convert.ToString(dr["Remarks"]);
        //                          obj.Vouchar_SN = Convert.ToString(dr["Vouchar_SN"]);
        //                          obj.Entry_By = Convert.ToString(dr["Entry_By"]);
        //                          obj.Entry_Date = Convert.ToDateTime(dr["Entry_Date"]);
        //                          obj.Maturity_Days = Convert.ToInt32(dr["Maturity_Days"]);
        //                          obj.Deposit_Bank_Name = Convert.ToString(dr["Deposit_Bank_Name"]);
        //                          obj.Deposit_Branch_Name = Convert.ToString(dr["Deposit_Branch_Name"]);
        //                          obj.Entry_Branch_ID = Convert.ToInt32(dr["Entry_Branch_ID"]);
        //                          obj.BankAccNo = Convert.ToString(dr["BankAccNo"]);
        //                          obj.RoutingNo = Convert.ToString(dr["RoutingNo"]);
        //                          obj.ReqType = Convert.ToString(dr["EFT_TYPE"]);

        //                          ResultPaymentPosting.Add(obj);
        //                      }
        //                  }
        //              }
        //              catch (Exception exception)
        //              {
        //                  throw exception;
        //              }
        //              finally
        //              {
        //                  _dbConnection.CloseDatabase();
        //              }
        //              return ResultPaymentPosting;
        //          }

        public void InsertEFT_FileInfo(EFT_File_InfoBO objMaster)
        {
            DataTable dtApprovedRequest = null;
            List<string> queryList = new List<string>();
            string queryMaster = "INSERT INTO [SBP_Database].[dbo].[SBP_EFT_File_Info]"
                                 + "([File_No]"
                                 + ",[File_Password]"
                                 + ",[File_Path]"
                                 + ",[File_Issue_Date]"
                                 + ",[Issue_By])"
                                 + "VALUES"
                                 + "('" + objMaster.File_No + "'"
                                 + ",'" + objMaster.File_Password + "'"
                                 + ",'" + objMaster.File_Path + "'"
                                 + ",'" + objMaster.File_Issue_Date + "'"
                                 + ",'" + objMaster.Issue_By + "')";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();
                //_dbConnection.ActiveStoredProcedure();
                _dbConnection.ExecuteNonQuery(queryMaster);
                //foreach (var str in queryList)
                //{
                //    _dbConnection.ExecuteNonQuery(str);
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

        public void InsertEFT_Issue(List<EFT_IssueBO> objDetails)
        {
            DataTable dtApprovedRequest = null;
            List<string> queryList = new List<string>();

            foreach (var obj in objDetails)
            {
                string quryString = "INSERT INTO [SBP_Database].[dbo].[SBP_EFT_Issue]"
                                     + "([File_No_ID]"
                                     + ",[Req_ID]"
                                     + ",[Cust_Code]"
                                     + ",[Amount]"
                                     + ",[Bank_ID]"
                                     + ",[Bank_Name]"
                                     + ",[Branch_ID]"
                                     + ",[Branch_Name]"
                                     + ",[Routing_No]"
                                     + ",[Bank_Account_No]"
                                     + ",[Account_Type]"
                                     + ",[Received_Date])"
                                     + "VALUES"
                                     + "('" + obj.File_No_ID + "'"
                                     + "," + obj.Req_ID + ""
                                     + ",'" + obj.Cust_Code + "'"
                                     + "," + obj.Amount
                                     + "," + obj.Bank_ID
                                     + ",'" + obj.BankName + "'"
                                     + "," + obj.Branch_ID
                                     + ",'" + obj.BranchName + "'"
                                     + ",'" + obj.RoutingNo + "'"
                                     + ",'" + GetCustomerAccountNo(obj.Cust_Code) + "'"
                                     + ",'" + obj.Account_Type + "'"
                                     + ",'" + obj.Received_Date + "')";
                queryList.Add(quryString);
            }

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();
                //_dbConnection.ActiveStoredProcedure();
                //_dbConnection.ExecuteNonQuery(queryMaster);
                foreach (var str in queryList)
                {
                    _dbConnection.ExecuteNonQuery(str);
                }
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

        public void InsertEFT_FileContents(List<EFT_FileContentsBO> objDetails)
        {
            DataTable dtApprovedRequest = null;
            List<string> queryList = new List<string>();

            foreach (var obj in objDetails)
            {
                string quryString = "INSERT INTO [SBP_Database].[dbo].[SBP_EFT_FileContents]"
                                     + "([EFTIssue_ID]"
                                     + ",[File_No_ID]"
                                     + ",[Req_ID]"
                                     + ",[Cust_Code]"
                                     + ",[Amount]"
                                     + ",[Bank_ID]"
                                     + ",[Bank_Name]"
                                     + ",[Branch_ID]"
                                     + ",[Branch_Name]"
                                     + ",[Routing_No]"
                                     + ",[Bank_Account_No]"
                                     + ",[Account_Type]"
                                     + ",[EFT_Reason]"
                                     + ",[SenderAccNo]"
                                     + ",[Received_Date])"

                                     + "VALUES"
                                     + "(" + obj.EftIssue_ID + ""
                                     + "," + obj.File_No_ID + ""
                                     + "," + obj.Req_ID + ""
                                     + ",'" + obj.Cust_Code + "'"
                                     + "," + obj.Amount
                                     + "," + obj.Bank_ID
                                     + ",'" + obj.BankName + "'"
                                     + "," + obj.Branch_ID
                                     + ",'" + obj.BranchName + "'"
                                     + ",'" + obj.RoutingNo + "'"
                                     + ",'" + obj.Bank_Account_No + "'"
                                     + ",'" + obj.Account_Type + "'"
                                     + ",'" + obj.EFT_Reason + "'"
                                     + ",'" + obj.SenderAccNo + "'"
                                     + ",'" + obj.Received_Date + "')";
                queryList.Add(quryString);
            }

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();
                //_dbConnection.ActiveStoredProcedure();
                //_dbConnection.ExecuteNonQuery(queryMaster);
                foreach (var str in queryList)
                {
                    _dbConnection.ExecuteNonQuery(str);
                }
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

        public void InsertEFT(EFT_File_InfoBO objMaster, List<EFT_IssueBO> objDetails)
        {
            DataTable dtApprovedRequest = null;
            List<string> queryList = new List<string>();
            string queryMaster = "INSERT INTO [SBP_Database].[dbo].[SBP_EFT_File_Info]"
                                 + "([File_No]"
                                 + ",[File_Password]"
                                 + ",[File_Path]"
                                 + ",[File_Issue_Date]"
                                 + ",[Issue_By])"
                                 + "VALUES"
                                 + "('" + objMaster.File_No + "'"
                                 + ",'" + objMaster.File_Password + "'"
                                 + ",'" + objMaster.File_Path + "'"
                                 + ",'" + objMaster.File_Issue_Date + "'"
                                 + ",'" + objMaster.Issue_By + "')";

            foreach (var obj in objDetails)
            {
                string quryString = "INSERT INTO [SBP_Database].[dbo].[SBP_EFT_Issue]"
                                     + "([File_No_ID]"
                                     + ",[Req_ID]"
                                     + ",[Req_Type]"
                                     + ",[Cust_Code]"
                                     + ",[Amount]"
                                     + ",[Bank_ID]"
                                     + ",[Bank_Name]"
                                     + ",[Branch_ID]"
                                     + ",[Branch_Name]"
                                     + ",[Routing_No]"
                                     + ",[Bank_Account_No]"
                                     + ",[Account_Type]"
                                     + ",[Received_Date])"
                                     + "VALUES"
                                     + "('" + obj.File_No_ID + "'"
                                     + "," + obj.Req_ID + ""
                                     + ",'" + obj.ReqType + "'"
                                     + ",'" + obj.Cust_Code + "'"
                                     + "," + obj.Amount + ""
                                     + ",'" + obj.Bank_ID + "'"
                                     + ",'" + obj.BankName + "'"
                                     + ",'" + obj.Branch_ID + "'"
                                     + ",'" + obj.BranchName + "'"
                                     + ",'" + obj.RoutingNo + "'"
                                     + ",'" + GetCustomerAccountNo(obj.Cust_Code) + "'"
                                     + ",'" + obj.Account_Type + "'"
                                     + ",'" + obj.Received_Date + "')";
                queryList.Add(quryString);
            }

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();
                //_dbConnection.ActiveStoredProcedure();
                _dbConnection.ExecuteNonQuery(queryMaster);
                foreach (var str in queryList)
                {
                    _dbConnection.ExecuteNonQuery(str);
                }
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

        public void UpdateExportFlag_EFT_FileInfo(string fileNo)
        {
            DataTable dtApprovedRequest = null;
            List<string> queryList = new List<string>();
            string queryMaster = "UPDATE [SBP_Database].[dbo].[SBP_EFT_File_Info]"
                                  + "SET "
                                  + "[IsExported]=1"
                                  + "WHERE File_No='" + fileNo + "'";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();
                //_dbConnection.ActiveStoredProcedure();
                _dbConnection.ExecuteNonQuery(queryMaster);
                //foreach (var str in queryList)
                //{
                //    _dbConnection.ExecuteNonQuery(str);
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

        public List<EFT_IssueBO> GetAllEFT_IssueBOList_ByFileNo(string fileNo)
        {
            DataTable dtApprovedRequest = null;
            List<EFT_IssueBO> resultList = new List<EFT_IssueBO>();
            string quryString =
                            "SELECT "
                            + "issue.[ID]"
                            + ",issue.[File_No_ID]"
                            + ",issue.[Req_ID]"
                            + ",issue.[Cust_Code]"
                            + ",issue.[Amount]"
                            + ",issue.[Bank_ID]"
                            + ",issue.[Bank_Name]"
                            + ",issue.[Branch_ID]"
                            + ",issue.[Branch_Name]"
                            + ",issue.[Routing_No]"
                            + ",issue.[Bank_Account_No]"
                            + ",issue.[Account_Type]"
                            + ",issue.[Received_Date]"
                            + "FROM "
                            + "[SBP_Database].[dbo].[SBP_EFT_Issue] AS issue"
                            + " JOIN "
                            + "[SBP_Database].[dbo].[SBP_EFT_File_Info] AS fileInfo"
                            + " ON "
                            + "issue.File_No_ID=fileInfo.File_No"
                            + " WHERE "
                            + "fileInfo.File_No='" + fileNo + "'";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                using (SqlDataReader dr = _dbConnection.ExecuteReader(quryString))
                {
                    while (dr.Read())
                    {
                        EFT_IssueBO obj = new EFT_IssueBO();
                        obj.Amount = Convert.ToDouble(dr["Amount"]);
                        obj.Bank_ID = Convert.ToInt32(dr["Bank_ID"]);
                        obj.BankName = Convert.ToString(dr["Bank_Name"]);
                        obj.Branch_ID = Convert.ToInt32(dr["Branch_ID"]);
                        obj.BranchName = Convert.ToString(dr["Branch_Name"]);
                        obj.Cust_Code = Convert.ToString(dr["Cust_Code"]);
                        obj.File_No_ID = Convert.ToString(dr["File_No_ID"]);
                        obj.Received_Date = Convert.ToDateTime(dr["Received_Date"]);
                        obj.Req_ID = dr["Req_ID"].ToString();
                        obj.RoutingNo = Convert.ToString(dr["Routing_No"]);
                        obj.Bank_Account_No = Convert.ToString(dr["Bank_Account_No"]);
                        obj.Account_Type = Convert.ToString(dr["Account_Type"]);

                        resultList.Add(obj);
                    }

                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return resultList;
        }

        public List<Export_ExcelDocBo> GetExport_ExcelDocByFileNo_Export(string fileNo, string SenderAccNo, string BankName)
        {
            //DataTable dtApprovedRequest = null;
            List<Export_ExcelDocBo> resultList = new List<Export_ExcelDocBo>();
            string quryString =
                            " SELECT "
                          + "issue.[ID] as [ID]"
                          + ", issue.[Req_ID] as [Req_ID]"
                          + ", issue.[Cust_Code] as [Cust_Code]"
                          + ", issue.[Amount] as [Amount]"
                          + ", issue.[Bank_ID] as [Bank_ID]"
                          + ", issue.[Bank_Name] as [Bank_Name]"
                          + ", issue.[Branch_ID] as [Branch_ID]"
                          + ", issue.[Branch_Name] as [Branch_Name]"
                          + ", issue.[Routing_No] as [Routing_No]"
                          + ", issue.[Bank_Account_No] as [Bank_Account_No]"
                          + ", issue.[Account_Type] as [Account_Type]"
                          + ", issue.[Received_Date] as [Received_Date]"
                          + ", [file].[File_No] as [File_No]"
                          + ", [file].[File_Password] as [File_Password]"
                           + ", [file].[File_Issue_Date] as [File_Issue_Date]"
                          + " FROM "
                          + "[SBP_Database].[dbo].[SBP_EFT_Issue] as issue"
                          + " JOIN "
                          + "[SBP_Database].[dbo].[SBP_EFT_File_Info] as [file]"
                          + " ON "
                          + "issue.File_No_ID=[file].File_No"
                          + " WHERE "
                          + "[file].File_No='" + fileNo + "'";
            try
            {
                _dbConnection.ConnectDatabase();
                EFT_IssueBAL balobj = new EFT_IssueBAL();
                using (SqlDataReader dr = _dbConnection.ExecuteReader(quryString))
                {
                    while (dr.Read())
                    {
                        Export_ExcelDocBo obj = new Export_ExcelDocBo();
                        obj.Amount = Convert.ToDouble(dr["Amount"]);
                        obj.Bank_ID = Convert.ToInt32(dr["Bank_ID"]);
                        obj.BankName = Convert.ToString(dr["Bank_Name"]);
                        obj.Branch_ID = Convert.ToInt32(dr["Branch_ID"]);
                        obj.BranchName = Convert.ToString(dr["Branch_Name"]);
                        var Cust_Code_Temp = Convert.ToString(dr["Cust_Code"]);
                        ReceiverID_BusinessRule(ref  Cust_Code_Temp);//Rules
                        obj.Cust_Code = Cust_Code_Temp;
                        obj.File_No_ID = Convert.ToString(dr["File_No"]);
                        obj.Received_Date = Convert.ToDateTime(dr["Received_Date"]);
                        obj.Req_ID =dr["Req_ID"].ToString();
                        obj.RoutingNo = Convert.ToString(dr["Routing_No"]);
                        string BankAccNo_Temp = Convert.ToString(dr["Bank_Account_No"]);
                        BankAccountNo_BusinessRule_FormattingCharacters(ref BankAccNo_Temp);//Rules
                        BankAccountNo_BusinessRule_MakingUp17Digit(ref BankAccNo_Temp);//Rules
                        obj.Bank_Account_No = BankAccNo_Temp;
                        string AccType_Temp = Convert.ToString(dr["Account_Type"]);
                        AccType_BusinessRule(ref AccType_Temp);
                        obj.Account_Type = AccType_Temp;
                        var Reason_Temp = Reason;
                        Reason_BusinessRule(ref Reason_Temp);//Rules
                        obj.Reason = Reason_Temp;
                        obj.SenderAccNumber = SenderAccNo;
                        obj.File_Issue_Date = Convert.ToDateTime(dr["File_Issue_Date"]);
                        obj.ID = Convert.ToInt32(dr["ID"]);
                        var ReceiverName = Convert.ToString(balobj.GetCustomerName(obj.Cust_Code, BankName)).Trim();
                        ReceiverName_BusinessRule(ref ReceiverName);//Rules
                        obj.ReceiverName = ReceiverName;
                        resultList.Add(obj);
                    }

                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return resultList;
        }

        public List<Export_ExcelDocBo> GetExport_ExcelDocByFileNo_Report(string fileNo, string SenderAccNo, string BankName)
        {
            int intTryParse;
            DateTime dateTimeTryParse;
            double doubleTryParse;

            //DataTable dtApprovedRequest = null;
            List<Export_ExcelDocBo> resultList = new List<Export_ExcelDocBo>();
            //string quryString =
            //                " SELECT "
            //              + "issue.[ID] as [ID]"
            //              + ", issue.[Req_ID] as [Req_ID]"
            //              + ", issue.[Cust_Code] as [Cust_Code]"
            //              + ", issue.[Amount] as [Amount]"
            //              + ", issue.[Bank_Name] as [Bank_Name]"
            //              + ", issue.[Branch_Name] as [Branch_Name]"
            //              + ", issue.[Routing_No] as [Routing_No]"
            //              + ", issue.[Bank_Account_No] as [Bank_Account_No]"
            //              + ", issue.[Account_Type] as [Account_Type]"
            //              + ", issue.[Received_Date] as [Received_Date]"
            //              + ", [file].[File_No] as [File_No]"
            //              + ", [file].[File_Password] as [File_Password]"
            //               + ", [file].[File_Issue_Date] as [File_Issue_Date]"
            //              + " FROM "
            //              + "[SBP_Database].[dbo].[SBP_EFT_Issue] as issue"
            //              + " JOIN "
            //              + "[SBP_Database].[dbo].[SBP_EFT_File_Info] as [file]"
            //              + " ON "
            //              + "issue.File_No_ID=[file].File_No"
            //              + " WHERE "
            //              + "[file].File_No='" + fileNo + "'";
            string queryString = "Total_Per_Page";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@File_No", SqlDbType.VarChar, fileNo);
                EFT_IssueBAL balobj = new EFT_IssueBAL();
                using (SqlDataReader dr = _dbConnection.ExecuteProQueryDataReader(queryString))
                {
                    while (dr.Read())
                    {
                        Export_ExcelDocBo obj = new Export_ExcelDocBo();
                        obj.Amount = Convert.ToDouble(dr["Amount"]);
                        obj.Bank_ID = Convert.ToInt32(dr["Bank_ID"]);
                        obj.BankName = Convert.ToString(dr["Bank_Name"]);
                        obj.Branch_ID = Convert.ToInt32(dr["Branch_ID"]);
                        obj.BranchName = Convert.ToString(dr["Branch_Name"]);
                        var Cust_Code_Temp = Convert.ToString(dr["Cust_Code"]);
                        ReceiverID_BusinessRule(ref  Cust_Code_Temp);//Rules
                        obj.Cust_Code = Cust_Code_Temp;
                        obj.FileNo = Convert.ToString(dr["File_No"]);
                        obj.File_No_ID = Convert.ToString(dr["ID"]);
                        obj.Received_Date = Convert.ToDateTime(dr["Received_Date"]);
                        obj.Req_ID = dr["Req_ID"].ToString();
                        obj.RoutingNo = Convert.ToString(dr["Routing_No"]);
                        string BankAccNo_Temp = Convert.ToString(dr["Bank_Account_No"]);
                        BankAccountNo_BusinessRule_FormattingCharacters(ref BankAccNo_Temp);//Rules
                        BankAccountNo_BusinessRule_MakingUp17Digit(ref BankAccNo_Temp);//Rules
                        obj.Bank_Account_No = BankAccNo_Temp;
                        string AccType_Temp = Convert.ToString(dr["Account_Type"]);
                        AccType_BusinessRule(ref AccType_Temp);
                        obj.Account_Type = AccType_Temp;
                        var Reason_Temp = Reason;
                        Reason_BusinessRule(ref Reason_Temp);//Rules
                        obj.Reason = Reason_Temp;
                        obj.SenderAccNumber = SenderAccNo;
                        obj.File_Issue_Date = Convert.ToDateTime(dr["File_Issue_Date"]);

                        if (obj.BankName == "THE CITY BANK LTD.")
                        {
                            obj.ReceiverName = Convert.ToString(dr["ReceiverName"]);
                        }
                        else 
                        { 
                            //var ReceiverName = Convert.ToString(balobj.GetCustomerName(obj.Cust_Code, BankName)).Trim();
                            //ReceiverName_BusinessRule(ref ReceiverName);//Rules
                            //obj.ReceiverName = ReceiverName;
                            string ReceiverName = Convert.ToString(dr["ReceiverName"]);
                            ReceiverName_BusinessRule(ref ReceiverName);
                            obj.ReceiverName = ReceiverName;
                        }
                        
                        if (int.TryParse(Convert.ToString(dr["PageNumber"]), out intTryParse))
                            obj.PageNumber = intTryParse;

                        resultList.Add(obj);
                    }
                    dr.Close();
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return resultList;
        }

        public EFT_File_InfoBO GetAllEFT_File_Info_ByFileNo(string fileNo)
        {
            DataTable dtApprovedRequest = null;
            EFT_File_InfoBO result = new EFT_File_InfoBO();
            string quryString =
                              "SELECT "
                              + "[ID]"
                              + ", [File_No]"
                              + ", [File_Password]"
                              + ", [File_Path]"
                              + ", [File_Issue_Date]"
                              + ", [Issue_By] "
                              + "FROM [SBP_Database].[dbo].[SBP_EFT_File_Info]"
                              + "WHERE File_No='" + fileNo + "'";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                using (SqlDataReader dr = _dbConnection.ExecuteReader(quryString))
                {
                    while (dr.Read())
                    {
                        //EFT_File_InfoBO obj = new EFT_File_InfoBO();
                        result.ID = Convert.ToInt32(dr["ID"]);
                        result.File_No = Convert.ToString(dr["File_No"]);
                        result.File_Password = Convert.ToString(dr["File_Password"]);
                        result.File_Path = Convert.ToString(dr["File_Path"]);
                        result.File_Issue_Date = Convert.ToDateTime(dr["File_Issue_Date"]);
                        result.Issue_By = Convert.ToString(dr["Issue_By"]);

                        //resultList.Add(obj);
                    }

                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return result;
        }


        public DataTable GetBEFTN_ReportData(string FileNo, string AccountNo, string BankName)
        {
            DataTable dtBEFTN = null;
            string quryString = @"RptGetBFTN";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@FileNo", SqlDbType.VarChar, FileNo);
                _dbConnection.AddParameter("@AccountNo", SqlDbType.VarChar, AccountNo);
                _dbConnection.AddParameter("@BankName", SqlDbType.VarChar, BankName);
                dtBEFTN = _dbConnection.ExecuteProQuery(quryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dtBEFTN;
        }

        #region EFT Cancel Info
        /// <summary>
        /// EFT File Info  
        /// Rashedul Hasan
        /// </summary>
        /// <param name="File_No"></param>
        /// <returns></returns>
        public DataTable LoadEftFileInfo()
        {
            DataTable dt = new DataTable();
            string query = "";
            query = @"Select ID,File_No,File_Issue_Date 
                                ,Issue_By
                                ,(Case When ISNULL(IsCanceled,0)=0 Then 'OK' Else 'Cancel' END) As 'Ok/Cnacel'
                                ,(Case When Isnull(IsExported,0)=1 Then 'Exported' Else 'Not Export' END)As 'IsExport'
                                From SBP_EFT_File_Info 
                                where CAST(File_Issue_Date As nvarchar(20))<= CAST(GETDATE() as nvarchar(20)) And 
                                CAST(File_Issue_Date As nvarchar(20))>=(SELECT DateAdd(month, -2, Convert(date, GetDate())))
                                And Isnull(IsCanceled,0)=0                                
                                ORDER BY CAST(File_Issue_Date As nvarchar(20)) DESC";

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

        /// <summary>
        /// EFT File Info By File No
        /// Rashedul Hasan On 09 July 2015
        /// </summary>
        /// <returns></returns>
        public DataTable LoadEftFileInfo(string Fileno)
        {
            DataTable dt = new DataTable();
            string query = "";
            query = @"Select ID,File_No,File_Issue_Date 
                        ,Issue_By
                        ,(Case When ISNULL(IsCanceled,0)=0 Then 'OK' Else 'Cancel' END) As 'Ok/Cnacel'
                        ,(Case When Isnull(IsExported,0)=1 Then 'Exported' Else 'Not Export' END)As 'IsExport'
                        From SBP_EFT_File_Info 
                        where File_No='" + Fileno + @"'
                        And Isnull(IsCanceled,0)=0            
                        ";

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

        /// <summary>
        /// EFT Issue by eft file no
        /// Rashedul hasan
        /// </summary>
        /// <param name="File_No"></param>
        /// <returns></returns>
        public DataTable LoadEftIssueInfo_ByEftFile(string File_No)
        {
            DataTable dt = new DataTable();
            string query = "";
            query = @"Select E.ID,File_No_ID,Req_ID,Req_Type,Cust_Code,Amount,Bank_Name,Branch_Name,Routing_No,Bank_Account_No,Account_Type 
                            From SBP_EFT_Issue As E
                            JOin SBP_EFT_File_Info As I
                            ON E.File_No_ID=I.File_No
                            Where File_No_ID='" + File_No + @"'
                            And Isnull(I.IsCanceled,0)=0";

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

        /// <summary>
        /// Update EFT cancel file to cancel
        /// Rashedul hasan
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Fielno"></param>
        public void UpdateEFTFile(int id, string Fielno)
        {

            string SBP_EFT_File_Info_Update = @"update SBP_EFT_File_Info set IsCanceled=1 Where File_No='" + Fielno + "' And ID=" + id + @"
              ";
            try
            {
                _dbConnection.ExecuteNonQuery(SBP_EFT_File_Info_Update);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// EFT Cancel For Trade and IPO
        /// Rashedul Hasan
        /// </summary>
        /// <param name="FileNo"></param>
        /// <param name="Cust_Code"></param>
        /// <param name="requisitionID"></param>
        /// <param name="EftId"></param>
        /// <param name="RequstType"></param>
        /// <param name="IssueID"></param>
        public void Insert_EFT_File_Info_And_Issue(string FileNo, string Cust_Code, string requisitionID, int EftId, string RequstType, string IssueID, string voucher, string remarks)
        {

            string P_Query = "";
            string Total_query = "";
            if (RequstType == "TRADE")
            {
                P_Query = @" INSERT INTO [SBP_Database].[dbo].[SBP_Payment_Posting_Request]
                            ([Cust_Code]
                           ,[Amount]
                           ,[Received_Date]
                           ,[Payment_Media]                           
                           ,[Payment_Media_Date]
                           ,[Bank_ID]
                           ,[Bank_Name]
                           ,[Branch_ID]
                           ,[Bank_Branch]
                           ,[RoutingNo]
                           ,[BankAccName]
                           ,[BankAccNo]
                           ,[Received_By]
                           ,[Deposit_Withdraw]            
                           ,[Vouchar_SN]
                           ,[Trans_Reason]
                           ,[Remarks]
                           ,[Entry_Date]
                           ,[Entry_By]
                            ,Approval_Status
                           ,[Entry_Branch_ID]
                           )
                           Select Cust_Code,Amount,CAST(Getdate() as Date)
                            ,'" + Indication_PaymentTransaction.EFT_Cancel + @"'
                            ,CAST(Getdate() as Date),Bank_ID,Bank_Name,Branch_ID,Branch_Name 
                           ,Routing_No,'',Bank_Account_No,'" + GlobalVariableBO._userName + @"'
                            ,'" + Indication_PaymentMode.Deposit + @"'
                            ,'" + voucher + @"'
                            ,'" + Indication_PaymentTransaction.EFT_Cancel + @"_'+Convert(varchar(100),Req_ID)
                            ,'" + remarks + @"'
                            ,GETDATE()
                           ,'" + GlobalVariableBO._userName + @"',0,'" + GlobalVariableBO._branchId + @"'
                           from SBP_EFT_Issue
                           Where File_No_ID='" + FileNo + "' And Cust_Code ='" + Cust_Code + @"'
                                                And Req_ID =" + requisitionID + @" And ID ='" + IssueID + @"'
                            ";

            }
            else
            {
                P_Query = @"INSERT INTO [SBP_IPO_Customer_Broker_MoneyTransaction]
                           ([Cust_Code]
                           ,[Received_Date]
                           ,[Money_TransactionType_ID]
                           ,[Money_TransactionType_Name]
                           ,[Deposit_Withdraw]
                           ,[Amount]
                           ,[Voucher_No]
                           ,[Trans_Reason]
                            ,Remarks           
                           ,[Approval_Status]                           
                           ,[Entry_Branch_ID]
                           ,[Entry_Date]
                           ,[Entry_By]
                           )
                           Select 
                           Cust_Code
                           ,CAST(Getdate() as Date)
                            ,'10'
                            ,'" + Indication_PaymentTransaction.EFT_Cancel + @"'
                            ,'" + Indication_PaymentMode.Deposit + @"'
                            ,Amount
                            ,'" + voucher + @"'
                            ,'" + Indication_PaymentTransaction.EFT_Cancel + @"_'+Convert(varchar(100),Req_ID)
                            ,'" + remarks + @"'
                            ,0
                            ,'" + GlobalVariableBO._branchId + @"'
                            ,GETDATE()
                            ,'" + GlobalVariableBO._userName + @"'                            
                           from SBP_EFT_Issue
                           Where File_No_ID='" + FileNo + "' And Cust_Code ='" + Cust_Code + @"'
                                                And Req_ID =" + requisitionID + @" And ID ='" + IssueID + @"'
                            ";
            }



            //Total_query = SBP_EFT_File_Info + SBP_EFT_Issue + QueyPosting + SBP_EFT_File_Info_Update;
            Total_query = P_Query;
            try
            {
                //_dbConnection.ConnectDatabase();
                //_dbConnection.StartTransaction();
                _dbConnection.ExecuteNonQuery(Total_query);
                //_dbConnection.Commit();
            }
            catch (Exception ex)
            {
                //_dbConnection.Rollback();
                throw ex;
            }
            //finally
            //{
            //    _dbConnection.CloseDatabase();
            //}

        }  

        #endregion

        #region Delete Info
        /// <summary>
        /// EFT Issue and file Delete 
        /// Rashedul hasan
        /// 30 july 2015
        /// </summary>
        /// <param name="FileID"></param>
        /// <param name="FileNO"></param>
        /// <param name="IssueId"></param>
        /// <param name="IssueFileNO"></param>
        public void Delete_EFT_FileAndIssue(string FileID, string FileNO, string IssueId, string IssueFileNO)
        {
            string query = "";
            query = @" Delete From SBP_EFT_File_Info 
                         Where ID IN (" + FileID + @")
                         And File_No IN (" + FileNO + @")
                         
                         Delete From SBP_EFT_Issue 
                         Where ID IN (" + IssueId + @")
                         And File_No_ID IN (" + IssueFileNO + @")
                            ";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(query);
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
        #endregion

    }
}