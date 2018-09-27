using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessAccessLayer.BO;
using DataAccessLayer;
using System.Data;
using BusinessAccessLayer.Constants;

namespace BusinessAccessLayer.BAL
{
   public class CashBack_ProcessBAL
    {
        private DbConnection _dbConnection;
        public CashBack_ProcessBAL()
        {
            _dbConnection = new DbConnection();
        }
        public void ProcessCashBack(int sessionId , DateTime ProcessDate)
        {
            CommonBAL objBAL=new CommonBAL();
            string queryStringDeposit = "";
            string queryStringWithdraw = "";
            queryStringDeposit =
                @" INSERT INTO SBP_Payment
                               (
                                [Cust_Code]
                               ,[Amount]
                               ,[Received_Date]
                               ,[Payment_Media]
                               ,[Payment_Media_No]
                               ,[Payment_Media_Date]
                               ,[Bank_Name]
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
		                      ,[CashBack_Amount]
                             "
                             + ",CONVERT(DATETIME, CONVERT(VARCHAR(11), CONVERT(DATETIME,'" + ProcessDate.ToShortDateString() + "',103)))" 
		                     +@",'Cash' 
		                      ,'' 
		                      ,NULL 
		                      ,'' 
		                      ,'' 
		                      ,'' 
		                      ,'Deposit' 
		                      ,''
		                      ,NULL 
		                      ,'CB'" 
		                      +",'CB-'+CONVERT(VARCHAR(10), RIGHT('0' + RTRIM(MONTH(Session_End_Date)), 2))+'-'+ CONVERT(VARCHAR(10),RIGHT('0' + RTRIM(YEAR(Session_End_Date)), 2))" 
		                      +",''"
                              + ",CONVERT(DATETIME, CONVERT(VARCHAR(11), CONVERT(DATETIME,'" + objBAL.GetCurrentServerDate().ToShortDateString() + "',103)))" 
		                      +
                              ",'" + GlobalVariableBO._userName + "'" 
                              + ",0" 
                              + ",0" 
                              + "," + GlobalVariableBO._branchId
                              + @" FROM SBP_Cashback_Reg ,dbo.SBP_Cashback_Session
                                   WHERE SBP_Cashback_Reg.CashBack_SessionID=SBP_Cashback_Session.ID
	                               AND CashBack_SessionID=" + sessionId;

            queryStringWithdraw =
                @" INSERT INTO SBP_Payment
                               (
                                [Cust_Code]
                               ,[Amount]
                               ,[Received_Date]
                               ,[Payment_Media]
                               ,[Payment_Media_No]
                               ,[Payment_Media_Date]
                               ,[Bank_Name]
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
                               
                               SELECT "
		                      +"'" +Indication_CompanyCode.Kscl_company_Account +"'"
		                      +@",[CashBack_Amount]
                             "
                             + ",CONVERT(DATETIME, CONVERT(VARCHAR(11), CONVERT(DATETIME,'" +ProcessDate.ToShortDateString()+"',103)))" 
                             + @",'Cash' 
		                      ,'' 
		                      ,NULL 
		                      ,NULL 
		                      ,NULL 
		                      ,NULL 
		                      ,'Withdraw' 
		                      ,NULL 
		                      ,NULL"
                             
		                      +",'CB'+[Cust_Code]"
		                      +",'CB-'+CONVERT(VARCHAR(10), RIGHT('0' + RTRIM(MONTH(Session_End_Date)), 2))+'-'+ CONVERT(VARCHAR(10),RIGHT('0' + RTRIM(YEAR(Session_End_Date)), 2))" 
		                      +",NULL"
                              + ",CONVERT(DATETIME, CONVERT(VARCHAR(11), CONVERT(DATETIME,'" + objBAL.GetCurrentServerDate().ToShortDateString() + "',103)))"  
		                      +
                              ",'" + GlobalVariableBO._userName + "'" 
                              + ",0" 
                              + ",NULL" 
                              + "," + GlobalVariableBO._branchId  
                              + @" FROM dbo.SBP_Cashback_Reg,dbo.SBP_Cashback_Session
                                   WHERE SBP_Cashback_Reg.CashBack_SessionID=SBP_Cashback_Session.ID
	                               AND CashBack_SessionID=" + sessionId;
            string updateQuery = @"UPDATE SBP_Cashback_Session
                                  SET [IsProcessed] =1
                                     ,[Process_Date]='" + ProcessDate.ToShortDateString()// objBAL.GetCurrentServerDate().ToShortDateString()
                                  + "' WHERE ID=" + sessionId;


                    
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();
                _dbConnection.ExecuteNonQuery(queryStringDeposit);
                _dbConnection.ExecuteNonQuery(queryStringWithdraw);
                _dbConnection.ExecuteNonQuery(updateQuery);
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
    }
}
