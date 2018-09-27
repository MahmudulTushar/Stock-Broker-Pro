using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using BusinessAccessLayer.BO;
using System.Data;
namespace BusinessAccessLayer.BAL
{
   public class DW_Return_InfoBAL
    {
        private DbConnection _dbConnection;

        public DW_Return_InfoBAL()
        {
            _dbConnection = new DbConnection();
        }
        public DataTable Get_DW_ReturnInformation(string paymentMedia,string depositWithdraw,string CustCode)
        {
            DataTable dataTable = new DataTable();
            string queryString = @"GetReturnTransaction"; 
//            string queryString = @"SELECT * 
//                                FROM [SBP_Database].[dbo].[SBP_Payment_Posting_Request]
//                                WHERE Cust_Code='" + custcode + "' AND Payment_Media='"+paymentMedia + "' AND Deposit_Withdraw='"+depositWithdraw + "' AND Approval_Status=1";

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@Payment_Media", SqlDbType.VarChar, paymentMedia);
                _dbConnection.AddParameter("@deposit_withdraw", SqlDbType.VarChar, depositWithdraw);
                _dbConnection.AddParameter("@Cust_Code", SqlDbType.VarChar, CustCode);                
               dataTable = _dbConnection.ExecuteProQuery(queryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dataTable;

        }

        public DataTable GetCheck_ReturnData(string custcode)
        {
            DataTable dataTable;
            string queryString = @"	SELECT
				                  [Payment_ID] AS Pid
                                , [Cust_Code] AS Code
                                , [Amount]
                                , [Received_Date] AS Recdate
                                , [Payment_Media] AS P_Media
                                , Payment_Media_No AS P_MediaNo
                                , [Bank_Name]
                                , [Bank_Branch]
                                , [Vouchar_SN] AS Voucher
                                FROM [SBP_Payment_Posting_Request]
                                WHERE Cust_Code='" + custcode + "'"
                                + @" AND Payment_Media='Check' 
                                AND Deposit_Withdraw='Deposit' 
                                AND Approval_Status=1";
            try
            {
                _dbConnection.ConnectDatabase();
                dataTable = _dbConnection.ExecuteQuery(queryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dataTable;

        }

        public void InsertDW_ReturnInfo_IntoPaymentPosting(PaymentInfoBO paymentInfoBo)//, string depositBank, string depositBranch)
        {
            string queryString = "";

            CommonBAL commonBAL = new CommonBAL();
            paymentInfoBo.PaymentId = commonBAL.GenerateID("SBP_Payment_Posting_Request", "Payment_ID");
            #region
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
            //    " VALUES(" + paymentInfoBo.PaymentId + ",'" + paymentInfoBo.CustCode + "'," + paymentInfoBo.Amount + ",'" + paymentInfoBo.RecievedDate.ToString("MM-dd-yyyy") + "','" + paymentInfoBo.PaymentMedia + "'," + maturityDays + ",'" + paymentInfoBo.PaymentMediaNo + "','" + paymentInfoBo.PaymentMediaDate.ToString("MM-dd-yyyy") + "','" + paymentInfoBo.BankName + "','" + paymentInfoBo.BranchName + "','" + paymentInfoBo.RoutingNo + "','" + paymentInfoBo.BankAccNo + "','" + paymentInfoBo.RecievedBy + "','" + paymentInfoBo.DepositWithdraw + "','" 
            //+ paymentInfoBo.PaymentApprovedBy + "'," + ((Convert.ToString(paymentInfoBo.PaymentApprovedDate) == string.Empty) ? "null" : "'" + paymentInfoBo.PaymentApprovedDate.Value.ToString("MM-dd-yyyy") + "'") + ",'" + paymentInfoBo.Remarks 
            //+ "',CAST(FLOOR(CAST(GETDATE() AS FLOAT)) AS DATETIME),'" + GlobalVariableBO._userName + "','" + paymentInfoBo.BankName + "','" + paymentInfoBo.BranchName + "',0,'" + paymentInfoBo.VoucherSlNo + "'," + GlobalVariableBO._branchId + ")";
//            queryString = @"INSERT INTO SBP_Payment_Posting_Request
//                            (
//                             Payment_ID
//                            ,Cust_code
//                            ,Amount
//                            ,Received_Date
//                            ,Payment_Media
//                            ,Payment_Media_No
//                            ,Payment_Media_Date
//                            ,Bank_Name
//                            ,Bank_Branch
//                            ,RoutingNo
//                            ,BankAccNo
//                            ,Deposit_Withdraw
//                            ,Vouchar_SN
//                            ,Trans_Reason
//                            ,Remarks
//                            ,Entry_Branch_ID
//                            ) 
//                            VALUES
//                            ( "
//                            + paymentInfoBo.PaymentId
//                            + ",'" + paymentInfoBo.CustCode
//                            + "'," + paymentInfoBo.Amount
//                            + ",'" + paymentInfoBo.RecievedDate.ToString("MM-dd-yyyy")
//                            + "','" + paymentInfoBo.PaymentMedia
//                            + "','" + paymentInfoBo.PaymentMediaNo
//                            + "','" + paymentInfoBo.PaymentMediaDate.ToString("MM-dd-yyyy")
//                            + "','" + paymentInfoBo.BankName
//                            + "','" + paymentInfoBo.BranchName
//                            + "','" + paymentInfoBo.RoutingNo
//                            + "','" + paymentInfoBo.BankAccNo
//                            + "','" + paymentInfoBo.DepositWithdraw
//                            + "','" + paymentInfoBo.VoucherSlNo
//                            + "','" + paymentInfoBo.TransReason
//                            + "','" + paymentInfoBo.Remarks
//                            + "',CAST(FLOOR(CAST(GETDATE() AS FLOAT)) AS DATETIME)"
//                            +",'"+ GlobalVariableBO._userName 
//                            + "','" + paymentInfoBo.BankName 
//                            + "','" + paymentInfoBo.BranchName 
//                            + "',0,'" 
//                            + "'," + GlobalVariableBO._branchId
            //                            + ")";
            #endregion
            queryString = @"INSERT INTO [SBP_Database].[dbo].[SBP_Payment_Posting_Request]
                            (
                              --[Payment_ID]
                            --, 
                            [Cust_Code]
                            , [Amount]
                            , [Received_Date]
                            , [Payment_Media]
                            , [Payment_Media_No]
                            , [Payment_Media_Date]
                            , [Bank_ID]
                            , [Bank_Name]
                            , [Branch_ID]
                            , [Bank_Branch]
                            , [RoutingNo]
                            , [BankAccNo]
                            , [Received_By]
                            , [Deposit_Withdraw]
                            , [Payment_Approved_By]
                            , [Payment_Approved_Date]
                            , [Vouchar_SN]
                            , [Trans_Reason]
                            , [Remarks]
                            , [Entry_Date]
                            , [Entry_By]
                            , [Maturity_Days]
                            , [Deposit_Bank_Name]
                            , [Deposit_Branch_Name]
                            , [Approval_Status]
                            , [Rejection_Reason]
                            , [Entry_Branch_ID]
                            )
                            VALUES
                            ("

                            //+ paymentInfoBo.PaymentId
                            //+ ",'" 
                            +"'"+ paymentInfoBo.CustCode
                            + "'," + paymentInfoBo.Amount
                            + ",'" + paymentInfoBo.RecievedDate.ToString("MM-dd-yyyy")
                            + "','" + paymentInfoBo.PaymentMedia
                            + "','" + paymentInfoBo.PaymentMediaNo
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
                            + ",'" + paymentInfoBo.VoucherSlNo
                            + "','" + paymentInfoBo.TransReason
                            + "','" + paymentInfoBo.Remarks
                            + "',CAST(FLOOR(CAST(GETDATE() AS FLOAT)) AS DATETIME)"
                            + ",'" + GlobalVariableBO._userName
                            + "',0" 
                            + ",'" + ""
                            + "','" + ""
                            + "',0"
                            + ",'"+""+"'"
                            + "," + GlobalVariableBO._branchId
                            +")";

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


    }
}
