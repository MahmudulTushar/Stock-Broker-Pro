﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using BusinessAccessLayer.BO;
using System.Data;

namespace BusinessAccessLayer.BAL
{
   public class CashDividedMarginLoanBAL
    {

        private DbConnection _dbConnection;

        public CashDividedMarginLoanBAL()
        {
            _dbConnection = new DbConnection();
        }

        public DataTable LoadData()
        {
            DataTable dt = new DataTable();
            string Query = @"SELECT [CashDividedofMarginLoanId]
                          ,[CompanyName]
                          ,[Ref]
                          ,[RecordDate]
                          ,[Percentage]
                          ,[FaceValue]      
                          ,[MD_Name]
                          ,[Company_Address]
                          ,[PhoneNo]
                          ,[Email1] 
                          ,[Email2] 
                          ,[SD_Fraction_Percentage] 
                          ,[FunctionSharePrice]           
                      FROM [SBP_CashDivided_MarginLoan]
                      ORDER BY CashDividedofMarginLoanId DESC";
            _dbConnection.ConnectDatabase();
            dt = _dbConnection.ExecuteQuery(Query);
            return dt;
        }

        public DataTable LoadDataforDeposit()
        {
            DataTable dt = new DataTable();
            string Query = @"SELECT [CashDividedofMarginLoanId]
                          ,[CompanyName]
                          ,[Ref]
                          ,[RecordDate]
                          ,[Percentage]
                          ,[FaceValue]      
                          ,[MD_Name]
                          ,[Company_Address]
                          ,[PhoneNo]
                          ,[Email1] 
                          ,[Email2]     
                      FROM [SBP_CashDivided_MarginLoan]
                      WHERE IsReturn IS NULL
                      ORDER BY CashDividedofMarginLoanId DESC";
            _dbConnection.ConnectDatabase();
            dt = _dbConnection.ExecuteQuery(Query);
            return dt;
        }

        public DataTable LoadDataforReturn()
        {
            DataTable dt = new DataTable();
            string Query = @"SELECT [CashDividedofMarginLoanId]
                          ,[CompanyName]
                          ,[Ref]
                          ,[RecordDate]
                          ,[Percentage]
                          ,[FaceValue]      
                          ,[MD_Name]
                          ,[Company_Address]
                          ,[PhoneNo]
                          ,[Email1] 
                          ,[Email2] 
                          ,[ReturnDate]    
                      FROM [SBP_CashDivided_MarginLoan]
                      WHERE IsReturn=1
                      ORDER BY CashDividedofMarginLoanId DESC";
            _dbConnection.ConnectDatabase();
            dt = _dbConnection.ExecuteQuery(Query);
            return dt;
        }

        public string Company_Validation(string Company)
        {
            string result = string.Empty;
            DataTable dt = new DataTable();
            string Query = @"Select CompanyName from SBP_CashDivided_MarginLoan Where CompanyName='"+Company+"'";
            _dbConnection.ConnectDatabase();
            dt = _dbConnection.ExecuteQuery(Query);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    result = dr[0].ToString();
                }
            }
            return result;
        }

        public int EmailCounting(CashDividedMarginLoanBO cashDividedMarginLoanBO)
        {
            int EmailCount = 0;
            DataTable dt = new DataTable();
            string Query = @"Select ISNULL(EmailSendCounting,0) AS 'EmailSendCounting' 
                             from SBP_CashDivided_MarginLoan  WHERE CashDividedofMarginLoanId='"+cashDividedMarginLoanBO.CashDividedMarginLoanId+"'";
            _dbConnection.ConnectDatabase();
            dt = _dbConnection.ExecuteQuery(Query);
            if(dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                    EmailCount = Convert.ToInt32(dr["EmailSendCounting"].ToString());
            }

            return EmailCount;
        }

        public void UpdateCashDividedMarginLoanDeposit11(CashDividedMarginLoanBO cashDividedMarginLoanBO)
        {
            string Query = string.Empty;
            Query = @"UPDATE SBP_CashDivided_MarginLoan SET IsReturn=1,ReturnDate = null Where CashDividedofMarginLoanId ='" + cashDividedMarginLoanBO.CashDividedMarginLoanId + "'";
            _dbConnection.ConnectDatabase();
            _dbConnection.ExecuteNonQuery(Query);
        }

        public void GetQueryString_Insert_InterestPayment(string voucherNo, int parentPaymentId_FromPayPostReq_ForReturnTrans, DateTime Date, string Deposit_Withdraw, string Transfer, string CustCode)
        {
            string queryInsertPayment = string.Empty;
            string _payment_Trans_Reason = string.Empty;
            int parentPaymentID_FromPayment_ForReturnTrans = -1;
            //parentPaymentID_FromPayment_ForReturnTrans = Get_PaymentIdFromPayment_By_PaymentPostingPaymentId(parentPaymentId_FromPayPostReq_ForReturnTrans);
            // _payment_Trans_Reason = Indication_PaymentTransaction.Return_Indicator + "_" + parentPaymentID_FromPayment_ForReturnTrans.ToString();
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
                                          99
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
                                        , '" + Deposit_Withdraw + @"'
                                        , p.[Payment_Approved_By]
                                        , p.[Payment_Approved_Date]
                                        , p.[Vouchar_SN]
                                        ,'" + Transfer + @"' 
                                        , p.[Remarks]
                                        ,CAST(FLOOR(CAST(GETDATE() AS FLOAT)) AS DATETIME)
                                        ,'" + GlobalVariableBO._userName + @"'
                                        , p.[Maturity_Days]
                                        , p.[Payment_ID]
                                        ,'" + GlobalVariableBO._branchId + @"' 
                                        FROM  SBP_Payment_Posting_Request AS p
                                        WHERE
                                        p.Vouchar_SN='" + voucherNo + @"'
                                        AND CONVERT(VARCHAR(10),p.Received_Date,120)='" + Date.ToString("yyyy-MM-dd") + "'  AND Cust_Code='" + CustCode + "'";
            }
            else
            {
                queryInsertPayment = "INSERT INTO SBP_Payment(Cust_code,Amount,Received_Date,Payment_Media,Maturity_Days,Payment_Media_No,Payment_Media_Date,Bank_Name,Bank_Branch,received_By,Deposit_Withdraw,Payment_Approved_By,Payment_Approved_Date,Voucher_Sl_No,Remarks,Entry_Date,Entry_By,Requisition_ID,Entry_Branch_ID,Trans_Reason) SELECT 99,Amount,Received_Date,Payment_Media,Maturity_Days,Payment_Media_No,Payment_Media_Date,Bank_Name,Bank_Branch,Received_By,'" + Deposit_Withdraw + "',Payment_Approved_By,Payment_Approved_Date,Vouchar_SN,Remarks,CAST(FLOOR(CAST(GETDATE() AS FLOAT)) AS DATETIME),'" + GlobalVariableBO._userName + "',Payment_ID,Entry_Branch_ID,'" + Transfer + "' FROM SBP_Payment_Posting_Request WHERE Vouchar_SN='" + voucherNo + "' AND CONVERT(VARCHAR(10),Received_Date,120)='" + Date.ToString("yyyy-MM-dd") + "' AND Cust_Code='" + CustCode + "'";
            }

            _dbConnection.ConnectDatabase();
            _dbConnection.ExecuteNonQuery(queryInsertPayment);
        }


//        public void GetQueryString_Insert_InterestPayment(string voucherNo, int parentPaymentId_FromPayPostReq_ForReturnTrans, DateTime Date, string Deposit_Withdraw, string Transfer)
//        {
//            string queryInsertPayment = string.Empty;
//            string _payment_Trans_Reason = string.Empty;
//            int parentPaymentID_FromPayment_ForReturnTrans = -1;
//            //parentPaymentID_FromPayment_ForReturnTrans = Get_PaymentIdFromPayment_By_PaymentPostingPaymentId(parentPaymentId_FromPayPostReq_ForReturnTrans);
//            // _payment_Trans_Reason = Indication_PaymentTransaction.Return_Indicator + "_" + parentPaymentID_FromPayment_ForReturnTrans.ToString();
//            if (parentPaymentID_FromPayment_ForReturnTrans != -1)
//            {
//                queryInsertPayment = @" INSERT INTO dbo.SBP_Payment
//                                        (
//	                                         [Cust_Code]
//	                                         ,[Amount]
//	                                         ,[Received_Date]
//	                                         ,[Payment_Media]
//	                                         ,[Payment_Media_No]
//	                                         ,[Payment_Media_Date]
//	                                         ,[Bank_ID]
//	                                         ,[Bank_Name]
//	                                         ,[Branch_ID]
//	                                         ,[Bank_Branch]
//	                                         ,[Received_By]
//	                                         ,[Deposit_Withdraw]
//	                                         ,[Payment_Approved_By]
//	                                         ,[Payment_Approved_Date]
//	                                         ,[Voucher_Sl_No]
//	                                         ,[Trans_Reason]
//	                                         ,[Remarks]
//	                                         ,[Entry_Date]
//	                                         ,[Entry_By]
//	                                         ,[Maturity_Days]
//	                                         ,[Requisition_ID]
//	                                         ,[Entry_Branch_ID]
//                                        )
//                                        
//                                        SELECT                                         
//                                          99
//                                        , p.[Amount]
//                                        , p.[Received_Date]
//                                        , p.[Payment_Media]
//                                        , p.[Payment_Media_No]
//                                        , p.[Payment_Media_Date]
//                                        , p.[Bank_ID]
//                                        , p.[Bank_Name]
//                                        , p.[Branch_ID]
//                                        , p.[Bank_Branch]
//                                        , p.[Received_By]
//                                        , '" + Deposit_Withdraw + @"'
//                                        , p.[Payment_Approved_By]
//                                        , p.[Payment_Approved_Date]
//                                        , p.[Vouchar_SN]
//                                        ,'" + Transfer + @"' 
//                                        , p.[Remarks]
//                                        ,CAST(FLOOR(CAST(GETDATE() AS FLOAT)) AS DATETIME)
//                                        ,'" + GlobalVariableBO._userName + @"'
//                                        , p.[Maturity_Days]
//                                        , p.[Payment_ID]
//                                        ,'" + GlobalVariableBO._branchId + @"' 
//                                        FROM  SBP_Payment_Posting_Request AS p
//                                        WHERE
//                                        p.Vouchar_SN='" + voucherNo + @"'
//                                        AND CONVERT(VARCHAR(10),p.Received_Date,120)='" + Date.ToString("yyyy-MM-dd") + "'";
//            }
//            else
//            {
//                queryInsertPayment = "INSERT INTO SBP_Payment(Cust_code,Amount,Received_Date,Payment_Media,Maturity_Days,Payment_Media_No,Payment_Media_Date,Bank_Name,Bank_Branch,received_By,Deposit_Withdraw,Payment_Approved_By,Payment_Approved_Date,Voucher_Sl_No,Remarks,Entry_Date,Entry_By,Requisition_ID,Entry_Branch_ID,Trans_Reason) SELECT 99,Amount,Received_Date,Payment_Media,Maturity_Days,Payment_Media_No,Payment_Media_Date,Bank_Name,Bank_Branch,Received_By,'" + Deposit_Withdraw + "',Payment_Approved_By,Payment_Approved_Date,Vouchar_SN,Remarks,CAST(FLOOR(CAST(GETDATE() AS FLOAT)) AS DATETIME),'" + GlobalVariableBO._userName + "',Payment_ID,Entry_Branch_ID,'" + Transfer + "' FROM SBP_Payment_Posting_Request WHERE Vouchar_SN='" + voucherNo + "' AND CONVERT(VARCHAR(10),Received_Date,120)='" + Date.ToString("yyyy-MM-dd") + "'";
//            }

//            _dbConnection.ConnectDatabase();
//            _dbConnection.ExecuteNonQuery(queryInsertPayment);
//        }
       
       public void UpdateCashDividedMarginLoanDeposit(CashDividedMarginLoanBO cashDividedMarginLoanBO)
        {
            string Query = string.Empty;
            Query = @"UPDATE SBP_CashDivided_MarginLoan SET IsReturn=1,ReturnDate ='" + cashDividedMarginLoanBO.ReturnDate + "' Where CashDividedofMarginLoanId ='" + cashDividedMarginLoanBO.CashDividedMarginLoanId + "'";
            _dbConnection.ConnectDatabase();
            _dbConnection.ExecuteNonQuery(Query);
        }
       public DataTable GetCashDividedSatellmentReport(DateTime RecDate, decimal FaceValue, decimal Percentage, string InstrumentCode)
       {
           DataTable dt = new DataTable();
           string query = "CashDividedSatellmentReport";
           //string query = "FindCashDividedCustCode";
           try
           {
               _dbConnection.ConnectDatabase();
               _dbConnection.ActiveStoredProcedure();
               _dbConnection.AddParameter("@Rec_Date", SqlDbType.DateTime, RecDate);
               _dbConnection.AddParameter("@FaceValue", SqlDbType.Decimal, FaceValue);
               _dbConnection.AddParameter("@Percentage", SqlDbType.Decimal, Percentage);
               _dbConnection.AddParameter("@InsTrumentCode", SqlDbType.VarChar, InstrumentCode);
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
        public void UpdateCashDividedMarginLoanDepositReturn(CashDividedMarginLoanBO cashDividedMarginLoanBO)
        {
            string Query = string.Empty;
            Query = @"UPDATE SBP_CashDivided_MarginLoan SET IsReturn=NULL,ReturnDate =NULL Where CashDividedofMarginLoanId ='" + cashDividedMarginLoanBO.CashDividedMarginLoanId + "'";
            _dbConnection.ConnectDatabase();
            _dbConnection.ExecuteNonQuery(Query);
        }
        public void UpdateCashDividedMarginLoanCounting(CashDividedMarginLoanBO cashDividedMarginLoanBO)
        {
            string Query = string.Empty;
            Query = @"UPDATE SBP_CashDivided_MarginLoan SET EmailSendCounting = ISNULL(EmailSendCounting,0)+1 WHERE CashDividedofMarginLoanId='"+cashDividedMarginLoanBO.CashDividedMarginLoanId+"' ";
            _dbConnection.ConnectDatabase();
            _dbConnection.ExecuteNonQuery(Query);
        }


        public void AccTransaction(string voucherNo, DateTime Date, string AccSub_Hade, string AccSub_Sub_Hade, decimal DrAmt, decimal CrAmt, decimal Amount, string Dr_Cr_Acc,string DrCr_SubHad_code,string Remark)
        {
            string sendAccTransaction = @"INSERT INTO [SBP_Database].[dbo].[AccTransaction]
                                                   ([VoucherNo]
                                                   ,[PDate]
                                                   ,[AccSub_Hade]
                                                   ,[AccSub_Sub_Hade]
                                                   ,[DrAmt]
                                                   ,[CrAmt]
                                                   ,[Balance]
                                                   ,[TransactionType]
                                                   ,[Cash_Cheque]
                                                   ,[ChequeNO]
                                                   ,[BankRoutingNo]
                                                   ,[BankName]
                                                   ,[Bank_Branch]
                                                   ,[Branch_ID]
                                                   ,[Dr_Cr_Acc]
                                                   ,[DrCr_SubHad_code]
                                                   ,[Remarks]
                                                   ,[EntyBy]
                                                   ,[EntyDate])
                                             VALUES
                                                   ('" + voucherNo + @"'
                                                   ,'" + Date + @"'
                                                   ,'" + AccSub_Hade + @"'
                                                   ,'" + AccSub_Sub_Hade + @"'
                                                   ,'" + DrAmt + @"'
                                                   ,'" + CrAmt + @"'
                                                   ,'" + Amount + @"'
                                                   ,'Payment'
                                                   ,'Cash'
                                                   ,''
                                                   ,''
                                                   ,''
                                                   ,''
                                                   ," + GlobalVariableBO._branchId + @"
                                                   ,'" + Dr_Cr_Acc + @"'
                                                   ,'" + DrCr_SubHad_code + @"'
                                                   ,'" + Remark + @"'
                                                   ,'" + GlobalVariableBO._userName + @"'
                                                   ,'" + GlobalVariableBO._currentServerDate + @"'
                                                    )";
            _dbConnection.ConnectDatabase();
            _dbConnection.ExecuteNonQuery(sendAccTransaction);
            _dbConnection.CloseDatabase();
        }
   
        public void GetQueryString_Deposit_InsertMoneyBalance(string voucherNo, DateTime Date)
        {
            string queryStringTemp = string.Empty;
           

            queryStringTemp =
                         @"INSERT INTO 
                        SBP_Money_Balance_Temp
                        (Cust_Code,Sell_Deposit,Buy_Withdraw,Balance,Matured_Balance,Remarks,Rec_Date) 
                        SELECT Cust_Code,Amount,0,Amount,Amount,Payment_Media,Received_Date 
                        FROM SBP_Payment_Posting_Request 
                        WHERE Vouchar_SN='" + voucherNo + @"'   AND CONVERT(VARCHAR(10),Received_Date,120)='"+Date.ToString("yyyy-MM-ss")+"'";
            _dbConnection.ConnectDatabase();
            _dbConnection.ExecuteNonQuery(queryStringTemp);
        }
        public void GetQueryString_InsertPayment_Charge(string voucherNo, int parentPaymentId_FromPayPostReq_ForReturnTrans, DateTime Date, string CustCode)
        {
            string queryInsertPayment = string.Empty;
            string _payment_Trans_Reason = string.Empty;
            int parentPaymentID_FromPayment_ForReturnTrans = -1;
            //parentPaymentID_FromPayment_ForReturnTrans = Get_PaymentIdFromPayment_By_PaymentPostingPaymentId(parentPaymentId_FromPayPostReq_ForReturnTrans);
            // _payment_Trans_Reason = Indication_PaymentTransaction.Return_Indicator + "_" + parentPaymentID_FromPayment_ForReturnTrans.ToString();
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
                                        p.Vouchar_SN='" + voucherNo + @"'
                                        AND CONVERT(VARCHAR(10),p.Received_Date,120)='" + Date.ToString("yyyy-MM-dd") + @"'
                                        AND Cust_Code='" + CustCode + "'";
            }
            else
            {
                queryInsertPayment = "INSERT INTO SBP_Payment(Cust_code,Amount,Received_Date,Payment_Media,Maturity_Days,Payment_Media_No,Payment_Media_Date,Bank_Name,Bank_Branch,received_By,Deposit_Withdraw,Payment_Approved_By,Payment_Approved_Date,Voucher_Sl_No,Remarks,Entry_Date,Entry_By,Requisition_ID,Entry_Branch_ID) SELECT Cust_Code,Amount,Received_Date,Payment_Media,Maturity_Days,Payment_Media_No,Payment_Media_Date,Bank_Name,Bank_Branch,Received_By,Deposit_Withdraw,Payment_Approved_By,Payment_Approved_Date,Vouchar_SN,Remarks,CAST(FLOOR(CAST(GETDATE() AS FLOAT)) AS DATETIME),'" + GlobalVariableBO._userName + "',Payment_ID,Entry_Branch_ID FROM SBP_Payment_Posting_Request WHERE Vouchar_SN='" + voucherNo + "' AND CONVERT(VARCHAR(10),Received_Date,120)='" + Date.ToString("yyyy-MM-dd") + "' AND Cust_Code='" + CustCode + "'";
            }

            _dbConnection.ConnectDatabase();
            _dbConnection.ExecuteNonQuery(queryInsertPayment);
        }

        public void GetQueryString_InsertPayment(string voucherNo, int parentPaymentId_FromPayPostReq_ForReturnTrans, DateTime Date)
        {
            string queryInsertPayment = string.Empty;
            string _payment_Trans_Reason = string.Empty;
            int parentPaymentID_FromPayment_ForReturnTrans = -1;
            //parentPaymentID_FromPayment_ForReturnTrans = Get_PaymentIdFromPayment_By_PaymentPostingPaymentId(parentPaymentId_FromPayPostReq_ForReturnTrans);
           // _payment_Trans_Reason = Indication_PaymentTransaction.Return_Indicator + "_" + parentPaymentID_FromPayment_ForReturnTrans.ToString();
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
                                        p.Vouchar_SN='" + voucherNo + @"'
                                        AND CONVERT(VARCHAR(10),p.Received_Date,120)='"+Date.ToString("yyyy-MM-dd")+"'";
            }
            else
            {
                queryInsertPayment = "INSERT INTO SBP_Payment(Cust_code,Amount,Received_Date,Payment_Media,Maturity_Days,Payment_Media_No,Payment_Media_Date,Bank_Name,Bank_Branch,received_By,Deposit_Withdraw,Payment_Approved_By,Payment_Approved_Date,Voucher_Sl_No,Remarks,Entry_Date,Entry_By,Requisition_ID,Entry_Branch_ID) SELECT Cust_Code,Amount,Received_Date,Payment_Media,Maturity_Days,Payment_Media_No,Payment_Media_Date,Bank_Name,Bank_Branch,Received_By,Deposit_Withdraw,Payment_Approved_By,Payment_Approved_Date,Vouchar_SN,Remarks,CAST(FLOOR(CAST(GETDATE() AS FLOAT)) AS DATETIME),'" + GlobalVariableBO._userName + "',Payment_ID,Entry_Branch_ID FROM SBP_Payment_Posting_Request WHERE Vouchar_SN='" + voucherNo + "' AND CONVERT(VARCHAR(10),Received_Date,120)='" + Date.ToString("yyyy-MM-dd") + "'";
            }

            _dbConnection.ConnectDatabase();
            _dbConnection.ExecuteNonQuery(queryInsertPayment);
        }
        public void DeletePayment(CashDividedMarginLoanBO cashDividedMarginLoanBO)
        {
            string Query = string.Empty;
            string query = string.Empty;
            Query = @"DELETE SBP_Payment WHERE Cust_Code IN ("+cashDividedMarginLoanBO.ListCustCode+ @")
                      AND 
                      CONVERT(VARCHAR(10),Received_Date,120)=CONVERT(VARCHAR(10),'"+cashDividedMarginLoanBO.ReturnDate.ToString("yyyy-MM-dd")+@"',120)
                      AND Voucher_Sl_No LIKE '%CD|%'
                      AND SUBSTRING(Voucher_Sl_No , CHARINDEX('|', Voucher_Sl_No ) + 1, LEN(Voucher_Sl_No )) ='" + cashDividedMarginLoanBO.CompanyName+"'";

            cashDividedMarginLoanBO.ListCustCode = cashDividedMarginLoanBO.ListCustCode + "," + "99";

            query = @"DELETE SBP_Payment WHERE Cust_Code IN (" + cashDividedMarginLoanBO.ListCustCode + @")
                      AND 
                      CONVERT(VARCHAR(10),Received_Date,120)=CONVERT(VARCHAR(10),'" + cashDividedMarginLoanBO.ReturnDate.ToString("yyyy-MM-dd") + @"',120)
                      AND Voucher_Sl_No LIKE '%CD|%'
                      AND SUBSTRING(Voucher_Sl_No , CHARINDEX('|', Voucher_Sl_No ) + 5, LEN(Voucher_Sl_No )) ='" + cashDividedMarginLoanBO.CompanyName + "'";

            _dbConnection.ConnectDatabase();
            _dbConnection.ExecuteNonQuery(Query);
            _dbConnection.ExecuteNonQuery(query);
        }

        public void DeletePaymentPosting(CashDividedMarginLoanBO cashDividedMarginLoanBO)
        {
            string Query = string.Empty;
            string query = string.Empty;
            Query = @"DELETE SBP_Payment_Posting_Request WHERE Cust_Code IN (" + cashDividedMarginLoanBO.ListCustCode + @")
                      AND 
                      CONVERT(VARCHAR(10),Received_Date,120)=CONVERT(VARCHAR(10),'" + cashDividedMarginLoanBO.ReturnDate.ToString("yyyy-MM-dd") + @"',120)
                      AND Vouchar_SN LIKE '%CD|%'
                      AND SUBSTRING(Vouchar_SN , CHARINDEX('|', Vouchar_SN ) + 1, LEN(Vouchar_SN )) ='" + cashDividedMarginLoanBO.CompanyName + "'";
            cashDividedMarginLoanBO.ListCustCode = cashDividedMarginLoanBO.ListCustCode + "," + "99";

            query = @"DELETE SBP_Payment WHERE Cust_Code IN (" + cashDividedMarginLoanBO.ListCustCode + @")
                      AND 
                      CONVERT(VARCHAR(10),Received_Date,120)=CONVERT(VARCHAR(10),'" + cashDividedMarginLoanBO.ReturnDate.ToString("yyyy-MM-dd") + @"',120)
                      AND Voucher_Sl_No LIKE '%CD|%'
                      AND SUBSTRING(Voucher_Sl_No , CHARINDEX('|', Voucher_Sl_No ) + 5, LEN(Voucher_Sl_No )) ='" + cashDividedMarginLoanBO.CompanyName + "'";
            _dbConnection.ConnectDatabase();
            _dbConnection.ExecuteNonQuery(Query);
            _dbConnection.ExecuteNonQuery(query);
        }

        public void InsertintoPaymentPosting(PaymentInfoBO paymentInfoBo, Payment_PostingBO postBo)// For Web
        {
            string queryString = "";
            string queryDeleteWebData = "";
            Int32 AAA = postBo.OnlineOrderNo;

            CommonBAL commonBAL = new CommonBAL();
            Web2014DataForwardBAL webBal = new Web2014DataForwardBAL();
            paymentInfoBo.PaymentId = commonBAL.GenerateID("SBP_Payment_Posting_Request", "Payment_ID");
            DataTable dtMaturity = new DataTable();
            int maturityDays = 0;
            //dtMaturity = GetPaymentMediaMaturityDay(paymentInfoBo.IsMatureToday, paymentInfoBo.PaymentMedia);
            if (dtMaturity.Rows.Count > 0)
            {
                if (dtMaturity.Rows[0][0] != DBNull.Value)
                    maturityDays = Convert.ToInt32(dtMaturity.Rows[0][0]);
            }
            
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
                                         + "'" + paymentInfoBo.CustCode
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
                                         + "',1,'"
                                         + paymentInfoBo.VoucherSlNo
                                         + "'," + GlobalVariableBO._branchId
                                         + "," + postBo.OnlineOrderNo
                                         + ",'" + postBo.Channel
                                         + "','" + Convert.ToString(postBo.OnlineEntry_Date.Date.Equals(DateTime.MinValue.Date) ? string.Empty : postBo.OnlineEntry_Date.ToString("MM-dd-yyyy"))
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
        public void InsertCashDividedMarginLoan(CashDividedMarginLoanBO cashDividedMarginLoanBO)
        {
            string Query = string.Empty;
            if (cashDividedMarginLoanBO.CashDividedMarginLoanId > 0)
            {
                Query = @"UPDATE [SBP_CashDivided_MarginLoan]
                           SET [CompanyName] = '"+cashDividedMarginLoanBO.CompanyName+@"'
                              ,[Ref] = '" + cashDividedMarginLoanBO.Ref + @"'
                              ,[RecordDate] = '" + cashDividedMarginLoanBO.RecordDate + @"'
                              ,[Percentage] = '" + cashDividedMarginLoanBO.PercentageCash + @"'
                              ,[FaceValue] = '" + cashDividedMarginLoanBO.FaceValue + @"'        
                              ,[MD_Name] = '" + cashDividedMarginLoanBO.MDName + @"'
                              ,[Company_Address] = '" + cashDividedMarginLoanBO.Address + @"'
                              ,[PhoneNo] = '" + cashDividedMarginLoanBO.PhoneNo + @"'
                              ,[Email1] = '" + cashDividedMarginLoanBO.Email1 + @"'
                              ,[Email2] = '" + cashDividedMarginLoanBO.Email2 + @"'
                              ,[SD_Fraction_Percentage] = '" + cashDividedMarginLoanBO.FunctionPercentage + @"'
                              ,[FunctionSharePrice] = '" + cashDividedMarginLoanBO.FunctionSharePrice + @"'
                              ,[CreateDate] = GETDATE()
                              ,[CreateBy] = '" + GlobalVariableBO._userName + @"'
                         WHERE [CashDividedofMarginLoanId]='"+cashDividedMarginLoanBO.CashDividedMarginLoanId+"'";
                _dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(Query);
            }
            else
            {
                Query = @"INSERT INTO [SBP_CashDivided_MarginLoan]
                       ([CompanyName]
                       ,[Ref]
                       ,[RecordDate]
                       ,[Percentage]
                       ,[FaceValue]                       
                       ,[MD_Name]
                       ,[Company_Address]
                       ,[CreateDate]
                       ,[CreateBy]
                       ,[Email1]
                       ,[Email2]
                       ,[SD_Fraction_Percentage]
                       ,[FunctionSharePrice]
                       ,[PhoneNo])
                       VALUES(
                      '" + cashDividedMarginLoanBO.CompanyName + @"'
                       ,'" + cashDividedMarginLoanBO.Ref + @"'
                       ,'" + cashDividedMarginLoanBO.RecordDate + @"'
                       ,'" + cashDividedMarginLoanBO.PercentageCash + @"'
                       ,'" + cashDividedMarginLoanBO.FaceValue + @"'
                       ,'" + cashDividedMarginLoanBO.MDName + @"'
                       ,'" + cashDividedMarginLoanBO.Address + @"'
                       ,'" + System.DateTime.Now + @"'
                       ,'" + GlobalVariableBO._userName + @"'
                       ,'" + cashDividedMarginLoanBO.Email1 + @"'
                       ,'" + cashDividedMarginLoanBO.Email2 + @"'
                       ,'" + cashDividedMarginLoanBO.FunctionPercentage + @"'
                       ,'" + cashDividedMarginLoanBO.FunctionSharePrice + @"'
                       ,'" + cashDividedMarginLoanBO.PhoneNo + @"')";
                _dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(Query);
            }
        }



        #region Cash Divided Report
        public DataTable GetCashDivided(DateTime RecDate ,decimal FaceValue,decimal Percentage,string InstrumentCode)
        {
            DataTable dt = new DataTable();
            string query = "FindCashDividedSatellmentReport";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@Rec_Date", SqlDbType.DateTime, RecDate);
                _dbConnection.AddParameter("@FaceValue", SqlDbType.Decimal, FaceValue);
                _dbConnection.AddParameter("@Percentage", SqlDbType.Decimal, Percentage);
                _dbConnection.AddParameter("@InsTrumentCode", SqlDbType.VarChar, InstrumentCode);
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
        #endregion




        #region Cash Divided Report
        public DataTable GetCashDividedData(DateTime RecDate, decimal FaceValue, decimal Percentage, string InstrumentCode)
        {
            DataTable dt = new DataTable();
            string query = "FindCashDividedSatellmentReport";
            //string query = "FindCashDividedCustCode";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@Rec_Date", SqlDbType.DateTime, RecDate);
                _dbConnection.AddParameter("@FaceValue", SqlDbType.Decimal, FaceValue);
                _dbConnection.AddParameter("@Percentage", SqlDbType.Decimal, Percentage);
                _dbConnection.AddParameter("@InsTrumentCode", SqlDbType.VarChar, InstrumentCode);
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
        #endregion

        #region Cash Divided CustCode Find
        public DataTable GetCashDividedCustCodeFind(DateTime RecDate, decimal FaceValue, decimal Percentage, string InstrumentCode)
        {
            DataTable dt = new DataTable();
            string query = "FindCashDividedCustCode";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@Rec_Date", SqlDbType.DateTime, RecDate);
                _dbConnection.AddParameter("@FaceValue", SqlDbType.Decimal, FaceValue);
                _dbConnection.AddParameter("@Percentage", SqlDbType.Decimal, Percentage);
                _dbConnection.AddParameter("@InsTrumentCode", SqlDbType.VarChar, InstrumentCode);
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
        #endregion

        #region Cash Divided Letter
        public DataTable GetCashDividedLetter(DateTime RecDate, decimal FaceValue, decimal Percentage, string InstrumentCode)
        {
            DataTable dt = new DataTable();
            string query = "RptCashDividedLetter";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@Rec_Date", SqlDbType.DateTime, RecDate);
                _dbConnection.AddParameter("@FaceValue", SqlDbType.Decimal, FaceValue);
                _dbConnection.AddParameter("@Percentage", SqlDbType.Decimal, Percentage);
                _dbConnection.AddParameter("@InsTrumentCode", SqlDbType.VarChar, InstrumentCode);
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
        #endregion
    }
}