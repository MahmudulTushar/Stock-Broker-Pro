using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessAccessLayer.BO;
using DataAccessLayer;

namespace BusinessAccessLayer.BAL
{
    public class BOClosing_ProcedureBAL
    {
        private DbConnection _dbConnection;
        
        public BOClosing_ProcedureBAL()
        {
            _dbConnection = new DbConnection();
        }
        public DataTable GetActiveAccountList(string AnnualYear,DateTime reportDate)
        {
            string queryString = @"RptGet_All_Active_Account_List_WithAnnualMark";
            DataTable dataTable=new DataTable();
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter(@"@BO_Annual_Year", SqlDbType.VarChar, (object)AnnualYear);
                _dbConnection.AddParameter(@"@BO_AnnualTaken_Date", SqlDbType.DateTime, (object)reportDate.ToString("dd-MM-yyyy"));
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
        public DataTable GetAppliedAnnualChargeList(DateTime ReceivedDate,string VoucherSn)
        {
            string queryString =@"Select * 
                                From SBP_Payment
                                Where Voucher_Sl_No='" + VoucherSn + "' AND Received_Date='" + ReceivedDate + "' AND Cust_Code<>'98'";
            DataTable dataTable = new DataTable();
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

//        public void DeductedChargeSendToSBP_Income(string voucherSn, DateTime rcvDate)
//        {
//           string queryIntoSBP_Income_Entry_HouseCharge100 = @"INSERT INTO [SBP_Database].[dbo].[SBP_IncomeEntry]
//                                                           ([VoucherSLNo]
//                                                           ,[RcvDate]
//                                                           ,[RcvFrom]
//                                                           ,[ClientCode]
//                                                           ,[Dr_Cr]
//                                                           ,[Dr_Amount]
//                                                           ,[Cr_Amount]
//                                                           ,[Purpose]
//                                                           ,[TrnType]
//                                                           ,[AccHead]
//                                                           ,[AccSubHead]
//                                                           ,[RoutingNo]
//                                                           ,[BankName]
//                                                           ,[BankBranchName]
//                                                           ,[DistrictName]
//                                                           ,[ChequeNo]
//                                                           ,[PayDate]
//                                                           ,[Status]
//                                                           ,[BrokerBranchID]
//                                                           ,[EntryDate]
//                                                           ,[EntryBy]
//                                                           ,[UpdateDate]
//                                                           ,[UpdateBy])
//                                                     VALUES
//                                                           ('" + voucherSn + @"'
//                                                           ,'" + rcvDate + @"'
//                                                           ,'All Active Customer'
//                                                           ,'All Active Code'
//                                                           ,'Deposit'
//                                                           ,100
//                                                           ,0.00
//                                                           ,'BO Opening Charge(CDBL)'
//                                                           ,'" + Indication_PaymentTransaction.Cash + @"'
//                                                           ,'I003'
//                                                           ,'I003i'
//                                                           ,''
//                                                           ,''
//                                                           ,''
//                                                           ,''
//                                                           ,''
//                                                           ,''
//                                                           ,'Approved'
//                                                           ," + GlobalVariableBO._branchId + @"
//                                                           ,'" + GlobalVariableBO._currentServerDate + @"'
//                                                           ,'" + GlobalVariableBO._userName + @"'
//                                                           ,'" + GlobalVariableBO._currentServerDate + @"'
//                                                           ,'" + GlobalVariableBO._userName + @"')";
//           string queryIntoSBP_Income_Entry_CDBL_Charge400 = @"INSERT INTO [SBP_Database].[dbo].[SBP_IncomeEntry]
//                                                           ([VoucherSLNo]
//                                                           ,[RcvDate]
//                                                           ,[RcvFrom]
//                                                           ,[ClientCode]
//                                                           ,[Dr_Cr]
//                                                           ,[Dr_Amount]
//                                                           ,[Cr_Amount]
//                                                           ,[Purpose]
//                                                           ,[TrnType]
//                                                           ,[AccHead]
//                                                           ,[AccSubHead]
//                                                           ,[RoutingNo]
//                                                           ,[BankName]
//                                                           ,[BankBranchName]
//                                                           ,[DistrictName]
//                                                           ,[ChequeNo]
//                                                           ,[PayDate]
//                                                           ,[Status]
//                                                           ,[BrokerBranchID]
//                                                           ,[EntryDate]
//                                                           ,[EntryBy]
//                                                           ,[UpdateDate]
//                                                           ,[UpdateBy])
//                                                     VALUES
//                                                           ('" + Indication_Fixed_VoucherNo_TransReason.GetBORenewal_VoucherNo(customerBo.BO_Open_Date.Value) + @"'
//                                                           ,'" + customerBo.BO_Open_Date + @"'
//                                                           ,'" + customerBo.CustomerName + @"'
//                                                           ," + customerBo.CustomerCode + @"
//                                                           ,'Deposit'
//                                                           ,400
//                                                           ,0.00
//                                                           ,'BO Opening Charge'
//                                                           ,'" + Indication_PaymentTransaction.Cash + @"'
//                                                           ,'I003'
//                                                           ,'I003ii'
//                                                           ,''
//                                                           ,''
//                                                           ,''
//                                                           ,''
//                                                           ,''
//                                                           ,''
//                                                           ,'Approved'
//                                                           ," + GlobalVariableBO._branchId + @"
//                                                           ,'" + GlobalVariableBO._currentServerDate + @"'
//                                                           ,'" + GlobalVariableBO._userName + @"'
//                                                           ,'" + GlobalVariableBO._currentServerDate + @"'
//                                                           ,'" + GlobalVariableBO._userName + @"')";
//           try
//           {
//               _dbConnection.ConnectDatabase();
//               _dbConnection.ExecuteNonQuery(queryString);
//           }
//           catch (Exception)
//           {
//               throw;
//           }
//           finally
//           {
//               _dbConnection.CloseDatabase();
//           }

//        }
        public void Withdraw_Active_Account_Annual_Charge(BOClosing_ProcedureBO bOClosing_ProcedureBO)
        {
            //DataTable dt = new DataTable();
            //string cCode = bOClosing_ProcedureBO.Cust_Code;
            //string cNameQuery = @"select Cust_Name from dbo.SBP_Cust_Personal_Info where Cust_Code='" + cCode + "'";
            //_dbConnection.ConnectDatabase();
            //dt = _dbConnection.ExecuteQuery(cNameQuery);


            string queryString = string.Empty;
            //string queryIntoSBP_Income_Entry_HouseCharge100 = string.Empty;
            //string queryIntoSBP_Income_Entry_CDBL_Charge400 = string.Empty;
            queryString = @"INSERT INTO SBP_Payment
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
                     VALUES
                           ("
                           +"'"+ bOClosing_ProcedureBO.Cust_Code
                           +"',"+bOClosing_ProcedureBO.Amount
                           +",'"+bOClosing_ProcedureBO.Received_Date
                           +"','"+bOClosing_ProcedureBO.Payment_Media
                           + "',NULL" //+ bOClosing_ProcedureBO.Payment_Media_No
                           + ",NULL" //+ bOClosing_ProcedureBO.Payment_Media_Date
                           + ",NULL" //+ bOClosing_ProcedureBO.Bank_ID
                           + ",NULL"// + bOClosing_ProcedureBO.Bank_Name
                           + ",NULL" //+ bOClosing_ProcedureBO.Branch_ID
                           + ",NULL" //+ bOClosing_ProcedureBO.Branch_Name
                           +",'"+bOClosing_ProcedureBO.Received_By
                           +"','"+bOClosing_ProcedureBO.Deposit_Withdraw
                           + "',NULL"// + bOClosing_ProcedureBO.Payment_Approved_By
                           + ",NULL" //+ bOClosing_ProcedureBO.Payment_Approved_Date
                           +",'"+bOClosing_ProcedureBO.VoucherSl_No
                           +"','"+bOClosing_ProcedureBO.Trans_Reason
                           + "',NULL"// + bOClosing_ProcedureBO.Remarks
                           +",'"+bOClosing_ProcedureBO.Entry_Date
                           +"','"+bOClosing_ProcedureBO.Entry_By
                           + "',NULL"// + bOClosing_ProcedureBO.Maturity_Days
                           +",NULL"//+bOClosing_ProcedureBO.Requisition_ID
                           +","+bOClosing_ProcedureBO.Entry_Branch_ID
                           +")";

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
        public DataTable Get_All_Active_CDBL_AccountList()
        {
            DataTable dtActiveCDBLAccountList=new DataTable();

            string QueryString =
                @"SELECT
                     c.Cust_Code
                    ,c.BO_ID
                    ,Cust_Name
                    ,c.BO_Status_ID
                    FROM SBP_Customers AS c
                    INNER JOIN 
                    SBP_Cust_Personal_Info AS p
                    ON c.Cust_Code=p.Cust_Code
                    WHERE BO_Status_ID=1
                    AND (BO_ID IS NOT NULL OR BO_ID<> '')";

            try
            {
                _dbConnection.ConnectDatabase();
                dtActiveCDBLAccountList = _dbConnection.ExecuteQuery(QueryString);
            }
            catch (Exception)
            {
                
                throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dtActiveCDBLAccountList;
        }

        public void RefundBOClosingCharge(string voucherNo, DateTime received_Date)
        {
            string queryString = string.Empty;
            queryString = @"SBPRefundBOClosingCharge";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();
                _dbConnection.ActiveStoredProcedure();
                //_dbConnection.AddParameter(@"@BO_ID", SqlDbType.VarChar, (object)boid);
                _dbConnection.AddParameter(@"@Voucher_Sl_No", SqlDbType.VarChar, (object) voucherNo);
                _dbConnection.AddParameter(@"@Received_Date", SqlDbType.DateTime, (object)received_Date.ToString("dd-MM-yyyy"));
                _dbConnection.ExecuteNonQuery(queryString);
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
        public void Process_Settlement()
        {
            string query = "EXEC GenerateMoneyBalanceTemp";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();
                _dbConnection.ExecuteNonQuery(query);
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
        public bool CheckDataAvailability(string vNo, string SearchDate)
        {
            DataTable dt = new DataTable();
            string query = @"
                            SELECT P.Cust_Code
                            FROM SBP_Payment AS P
                            INNER JOIN SBP_Customers AS C
                            ON P.Cust_Code=C.Cust_Code
                            WHERE C.BO_ID IN (SELECT SUBSTRING(BO_ID,9,8) AS BO_ID FROM SBP_08DP04UX)
                            AND P.Deposit_Withdraw='Withdraw'
                            AND P.Voucher_Sl_No='" + vNo + @"'
                            AND P.Received_Date='" + SearchDate + @"'";
            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(query);
                return dt.Rows.Count > 0;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
        }
    

        public void TakeBOClosingCharge(string voucherNo)
        {
            string queryString = string.Empty;
            queryString = @"SBPClosingChargeTaken";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter(@"@VoucherNo", SqlDbType.VarChar, (object) voucherNo);
                _dbConnection.AddParameter(@"@Preview", SqlDbType.VarChar, (object) 1);
                _dbConnection.ExecuteNonQuery(queryString);
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

        public DataTable GetAllAccountListNeedToDeposit98Account(int accNo, string voucherNo, DateTime received_Date)
        {
            string queryString = string.Empty;
            DataTable dtAllAccountListNeedToDeposit98OR99Account=new DataTable();
            if (accNo == 98)
            {
//                queryString =
//                     @"SELECT 
//                     [With].Cust_Code
//                     ,[With].Cust_Name
//                     ,[With].Amount
//                     ,[With].Received_Date
//                     ,[With].Payment_Media
//                     ,[With].Deposit_Withdraw
//                     ,[With].Voucher_Sl_No
//                     ,ISNULL([With].Requisition_ID,0) Requisition_ID
//                     ,[Dep].*
//                     
//                     FROM
//                     ( 
//                        SELECT 
//                        p.Cust_Code
//                        ,c.Cust_Name
//                        ,Amount
//                        ,Received_Date
//                        ,Payment_Media
//                        ,Deposit_Withdraw
//                        ,Voucher_Sl_No
//                        ,Trans_Reason
//                        ,Requisition_ID
//                         FROM SBP_Payment AS p
//                         LEFT OUTER JOIN SBP_Cust_Personal_Info AS c
//                         ON p.Cust_Code=c.Cust_Code
//                         WHERE
//                         p.Deposit_Withdraw='Withdraw'
//                         AND p.Voucher_Sl_No='" + voucherNo+ @"'
//                         AND p.Cust_Code<>'98'
//                         AND(
//						                        Select Count(t.Payment_ID)
//						                        From SBP_Payment as t
//						                        Where t.Cust_Code=p.Cust_Code 
//						                        And t.Voucher_Sl_No=p.Voucher_Sl_No
//						                        And t.Deposit_Withdraw=p.Deposit_Withdraw
//                         )=1
//                         AND (
//                                                Select Count(t.Payment_ID)
//						                        From SBP_Payment as t
//						                        Where t.Cust_Code=p.Cust_Code 
//						                        AND t.Trans_Reason LIKE '%BAC%'
//                                                And t.Deposit_Withdraw='Deposit'
//                                                And REVERSE(SUBSTRING(REVERSE(t.Trans_Reason),0,CHARINDEX('_',REVERSE(t.Trans_Reason))))=Convert(varchar(100),p.Payment_ID)
//                         )=0
//                     ) AS [With]
//                     LEFT OUTER JOIN
//                     (
//                        SELECT 
//	                    p.Cust_Code
//	                    ,c.Cust_Name
//	                    ,Amount
//	                    ,Received_Date
//	                    ,Payment_Media
//	                    ,Deposit_Withdraw
//	                    ,Voucher_Sl_No
//	                    ,Trans_Reason
//	                     FROM SBP_Payment AS p
//	                     INNER JOIN SBP_Cust_Personal_Info AS c
//	                     ON p.Cust_Code=c.Cust_Code
//	                     WHERE
//	                     p.Deposit_Withdraw='Deposit'
//	                     AND p.Cust_Code='98'
//	                     AND p.Voucher_Sl_No='" + voucherNo+ @"'
//	                     AND (
//				                    Select Count(t.Payment_ID)
//				                    From SBP_Payment as t
//				                    Where t.Cust_Code=p.Cust_Code
//				                    And t.Trans_Reason=p.Trans_Reason 
//				                    And t.Voucher_Sl_No=p.Voucher_Sl_No
//				                    And t.Deposit_Withdraw=p.Deposit_Withdraw
//	                     )=1
//                         AND (
//                                    Select Count(t.Payment_ID)
//			                        From SBP_Payment as t
//			                        Where t.Cust_Code=p.Trans_Reason 
//			                        AND t.Trans_Reason LIKE '%BAC%'
//			                        And t.Deposit_Withdraw='Deposit'
//                                    And REVERSE(SUBSTRING(REVERSE(t.Trans_Reason),0,CHARINDEX('_',REVERSE(t.Trans_Reason))))=(
//                                                Select Convert(varchar(100),t.Payment_ID)
//				                                From SBP_Payment as t
//				                                Where t.Cust_Code=p.Trans_Reason
//				                                And t.Trans_Reason LIKE '%BAC%'
//				                                And t.Voucher_Sl_No=p.Voucher_Sl_No
//				                                And t.Deposit_Withdraw='Withdraw'                                                                              
//                                    )
//                         )=0	
//                     ) AS [Dep]
//                     ON 
//                     [With].Cust_Code=[Dep].Trans_Reason
//                     AND [With].Voucher_Sl_No=[Dep].Voucher_Sl_No
//                     WHERE  [Dep].Cust_Code is NULL";

                queryString = "SBP_GetRestOfBOAnnualTaken_DepositTo98"; 
            }
            else if (accNo==99)
            {
                queryString = "SBPClosingChargeTaken";

            }
            try
            {
                _dbConnection.ConnectDatabase();
                if (accNo == 98)
                {
                    _dbConnection.ActiveStoredProcedure();
                    _dbConnection.AddParameter("@VoucherNo", SqlDbType.VarChar, voucherNo);
                    dtAllAccountListNeedToDeposit98OR99Account = _dbConnection.ExecuteProQuery(queryString);
                }
                else if(accNo==99)
                {
                    _dbConnection.ActiveStoredProcedure();
                    _dbConnection.AddParameter(@"@VoucherNo", SqlDbType.VarChar, (object)voucherNo);
                    _dbConnection.AddParameter(@"@Preview", SqlDbType.VarChar, (object)0);
                    dtAllAccountListNeedToDeposit98OR99Account = _dbConnection.ExecuteProQuery(queryString);
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
            return dtAllAccountListNeedToDeposit98OR99Account;
        }

        public void DepositBOClosingChargeInto98Account( DataTable dtAllAccountListNeedToDeposit98Account,DateTime ReceivedDate)
        {
            string queryString = string.Empty;
            CommonBAL cmnBAL=new CommonBAL();
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();
                //if (accNo == 98)
                //{
                    for (int i = 0; i < dtAllAccountListNeedToDeposit98Account.Rows.Count; i++)
                    {
                        queryString =
                            @"INSERT INTO SBP_Payment
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
                           ,[Entry_Branch_ID])
                     VALUES
                           ("
                            + " '98'"
                            + "," + dtAllAccountListNeedToDeposit98Account.Rows[i]["Amount"]
                            + ",'" + dtAllAccountListNeedToDeposit98Account.Rows[i]["Received_Date"]
                            //+ ",'" + ReceivedDate.ToString("yyyy-MM-dd")
                            + "','Cash'"
                            + ",NULL"
                            + ",NULL"
                            + ",NULL"
                            + ",NULL"
                            + ",NULL"
                            + ",NULL"
                            + ",NULL"
                            + ",'Deposit'"
                            + ",NULL"
                            + ",NULL"
                            + ",'" + dtAllAccountListNeedToDeposit98Account.Rows[i]["Voucher_Sl_No"]
                            + "','" + dtAllAccountListNeedToDeposit98Account.Rows[i]["Cust_Code"]
                            + "',NULL"
                            + ",'" + cmnBAL.GetCurrentServerDate().ToString("yyyy-MM-dd")
                            + "','" + GlobalVariableBO._userName
                            + "', NULL"
                            + ","+dtAllAccountListNeedToDeposit98Account.Rows[i]["Requisition_ID"]
                            + "," + GlobalVariableBO._branchId
                            + ")";
                        _dbConnection.ExecuteNonQuery(queryString);
                    }
                //}
//                else if(accNo==99)
//                {
//                    for (int i = 0; i < dtAllAccountListNeedToDeposit98OR99Account.Rows.Count; i++)
//                    {
//                        //Need Not to Change
//                        queryString =
//                            @"INSERT INTO SBP_Payment
//                           (
//                            [Cust_Code]
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
//                           ,[Maturity_Days]
//                           ,[Requisition_ID]
//                           ,[Entry_Branch_ID])
//                     VALUES
//                           ("
//                            + " '" + accNo + "'"
//                            + "," + dtAllAccountListNeedToDeposit98OR99Account.Rows[i]["Amount"]
//                            + ",'" + dtAllAccountListNeedToDeposit98OR99Account.Rows[i]["Received_Date"]
//                            + "','Cash'"
//                            + ",NULL"
//                            + ",'" + dtAllAccountListNeedToDeposit98OR99Account.Rows[i]["Received_Date"]
//                            + "',NULL"
//                            + ",NULL"
//                            + ",NULL"
//                            + ",NULL"
//                            + ",NULL"
//                            + ",'Deposit'"
//                            + ",NULL"
//                            + ",NULL"
//                            + ",'" + dtAllAccountListNeedToDeposit98OR99Account.Rows[i]["Voucher_Sl_No"]
//                            + "','" + dtAllAccountListNeedToDeposit98OR99Account.Rows[i]["Cust_Code"]
//                            + "',NULL"
//                            + ",'" + cmnBAL.GetCurrentServerDate().ToString("yyyy-MM-dd")
//                            + "','" + GlobalVariableBO._userName
//                            + "', NULL"
//                            + ", NULL"
//                            + "," + GlobalVariableBO._branchId
//                            + ")";
//                        _dbConnection.ExecuteNonQuery(queryString);
//                    }
//                }
                _dbConnection.Commit();
            }
            catch(Exception ex)
            {
                _dbConnection.Rollback();
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
        }
    }
}
