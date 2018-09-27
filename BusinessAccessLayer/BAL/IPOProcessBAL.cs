﻿using System;
using System.Data;
using System.Data.SqlClient;
using BusinessAccessLayer.BO;
using DataAccessLayer;
using BusinessAccessLayer.Constants;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;

namespace BusinessAccessLayer.BAL
{
    public class IPOProcessBAL
    {

        public DbConnection _dbConnection;
        public string SBPModuleName;

        public IPOProcessBAL()
        {
            _dbConnection = new DbConnection();
            _dbConnection.LogInName = GlobalVariableBO._userName;
            _dbConnection.EmployeCode = GlobalVariableBO._employeeCode;
            _dbConnection.EntryBranchID = GlobalVariableBO._branchId;
            _dbConnection.BranchName = GlobalVariableBO._branchName;
            _dbConnection.SBPModuleName = SBPModuleName;

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
            Query = @"IPO_Cheque_Approved_Grid_Data";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
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
        public DataTable GetParentInfo(string[] code)
        {
            DataTable dt = new DataTable();
            string codes = String.Join(",", code);
            string query = @"Select distinct Parent_Code
                            From SBP_Parent_Child_Details
                            Where Child_Code IN(" + codes + ")";
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

        public void ChequeClereance(string cheque,string Cust_Code)
        {
            //DataTable dt = null;
            string query = "";
            query = @"UPDATE [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction]
                    SET [Approval_Status]=3 where [Money_TransactionType_Name]='" + cheque + "'AND [ID]='" + Cust_Code + "'";
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

        public int CheckApproval_Status(string Cheque)
        {
            DataTable dt = null;
            string query = @"SELECT [Approval_Status] FROM [SBP_IPO_Customer_Broker_MoneyTransaction] WHERE [Money_TransactionType_Name]='"+Cheque+"' and [Approval_Status]=1";
            try
            {
                _dbConnection.ConnectDatabase();
                dt=_dbConnection.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            int id = 0;
            if (dt.Rows.Count > 0)
            {
                id = Convert.ToInt32(dt.Rows[0][0]);
            }
            return id;
        }
        #endregion

        #region Auto IPO Application
        /// <summary>
        /// Getting All Register Client
        /// </summary>
        /// <returns></returns>
        public DataTable Get_TotalRegisterClient_ForAutoApplication<T>(T sessionID)
        {
            DataTable dt = new DataTable();
            string query = @"
                            Select T.Cust_Code,T.Parent_Code,T.Cust_Name,T.Cell_No,T.Email,T.Subscription_Type,T.App_Cust_Code
                            From
                            (
                            Select 
                                Parent_Code as Parent_Code,Child_Code as Cust_Code,Parent_Name As Cust_Name
                                ,Parent_Contact_Mobile+'  '+Parent_Contact_Land  As Cell_No
                                ,Parent_Email As Email,'Auto IPO' As Subscription_Type
                                ,T.Cust_Code As App_Cust_Code
                            From 
                                SBP_Parent_Child_Details
                            Left JOIn
	                            (	
		                            Select Cust_Code From SBP_IPO_Application_BasicInfo Where IPOSession_ID=" + sessionID + @"
	                            )As T
                            ON 
                            T.Cust_Code=Child_Code
                            where 
                                Parent_Code IN (
                                    Select 
                                        Cust_Code 
                                    From 
                                        sbp_service_transaction Where isSubscribed=1
                                        )
                            Union All
                                    Select 
                                    ''as Parent_Code,tr.Cust_Code ,P.Cust_Name,c.Mobile,c.Email,tr.ServiceType As Subscription_Type
                                    ,b.Cust_Code As App_Cust_Code
                                    From 
                                        sbp_service_transaction As tr
                                    Join 
                                        SBP_Cust_Personal_Info As P
                                    ON 
                                        P.Cust_Code=tr.Cust_Code
                                    Join 
                                        SBP_Cust_Contact_Info As c
                                    ON 
			                            c.Cust_Code=tr.Cust_Code
                                    Left Join
			                            (
				                            Select Cust_Code From SBP_IPO_Application_BasicInfo as b
				                            where b.IPOSession_ID=" + sessionID + @"
			                            )as b
		                            on
			                            b.Cust_Code=tr.Cust_Code
                                    Where 
                                        tr.isSubscribed=1
                                    And 
                                        tr.Cust_Code Not in 
                                        (
                                        Select 
                                            Child_Code 
                                        From 
                                            SBP_Parent_Child_Details
                                        )
                            )As T";
            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(query);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;

        }
        /// <summary>
        /// Md.rashedul hasan
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="SessionId">Session Id</param>
        /// <param name="EligibleOrNot">Customer is eligible or  not</param>
        /// <param name="Cust_Code">This customer information</param>
        /// <returns></returns>
        public DataTable GetIPOAccountBalanceFor_AutoApplication<T>(T SessionId, T EligibleOrNot, T Cust_Code)
        {
            DataTable dt = new DataTable();
            string query = @"SBP_IPO_CustomerBalance_For_AutoApplication";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@SessionID", SqlDbType.Int, Convert.ToInt32(SessionId));
                _dbConnection.AddParameter("@EligibleORNot", SqlDbType.VarChar, EligibleOrNot);
                _dbConnection.AddParameter("@Cust_code", SqlDbType.VarChar, Cust_Code);
                dt = _dbConnection.ExecuteProQuery(query);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;
        }

        public DataTable GetIPOAccountBalanceFor_AutoApplication<T>(T SessionId, T EligibleOrNot)
        {
            DataTable dt = new DataTable();
            string query = @"SBP_IPO_CustomerBalance_For_AutoApplication";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@SessionID", SqlDbType.Int, SessionId);
                _dbConnection.AddParameter("@EligibleORNot", SqlDbType.VarChar, EligibleOrNot);
                _dbConnection.AddParameter("@Cust_code", SqlDbType.VarChar, "");
                dt = _dbConnection.ExecuteProQuery(query);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;
        }

        /// <summary>
        /// Customer balance who are the eligible for auto application
        /// Md.Rashedul Hasan ON 26 August 2015
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="SessionId"></param>
        /// <returns></returns>
        public DataTable GetIPOAccountBalanceFor_AutoApplication<T>(T SessionId)
        {
            DataTable dt = new DataTable();
            string query = @"SBP_IPO_CustomerBalance_For_AutoApplication";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@SessionID", SqlDbType.Int, SessionId);
                dt = _dbConnection.ExecuteProQuery(query);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;
        }

        /// <summary>
        /// All Kind Of application data provide by session id and cust code
        /// Md.Rashedul Hasan on 26 August 2015
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Cust_Code"></param>
        /// <param name="SessionID"></param>
        /// <returns></returns>
        public DataTable GetIPOApplicationTableDataByCustCode_SessionID_Check_IsAlreadyApply<T>(T Cust_Code, T SessionID)
        {
            DataTable dt = new DataTable();
            string Qeury = @"Select bs.Cust_Code,bs.BO_ID,bs.IPOSession_ID,bs.Applied_Company,bs.ChannelID,bs.ChannelType,bs.TotalAmount,bs.Total_Share_Value
                        ,bs.Serial_No,bs.Money_Trans_NRB_ID,bs.Money_Trans_Ref_ID,ext.Applicant_Category,ext.Refund_Method,ext.Refund_Other_Details
                         From SBP_IPO_Application_BasicInfo As bs
                        Join SBP_IPO_Application_ExtendedInfo As ext
                        ON ext.BasicInfo_ID=bs.ID
                        Where bs.Cust_Code='" + Cust_Code + "' And bs.IPOSession_ID=" + SessionID + ""
                ;
            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(Qeury);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;
        }

        public DataTable Insert_Transfer_Auto_IPO_DepositMoneyTransaction_UITransApplied(string Trans_Cust_Code_IPOAcc, string[] Details_CustCode_IPOAcc, double Amount_TransCustCode, double[] Amount_Details_CustCode, string Deposit_Withdraw_TransCustCode, string Deposit_Withdraw_Details_CustCode, DateTime ReceivedDate, string VoucherNo, string Remarks, int IntendedIPOSessionID, string[] ChannelType)
        {
            CommonBAL comBal = new CommonBAL();
            DateTime TodayServerDate = comBal.GetCurrentServerDate();
            string PaymentMethod = Indication_IPOPaymentTransaction.TRTA;
            string PaymentMethodForIPOtoIPO = Indication_PaymentTransaction.TRIPO;
            DataTable dt = new DataTable();


            string queryString_GetTemporaryTable_NewInsertDetails = @"
                                                            Select * 
                                                            From #Temp_IPOAcc_NewInsert
                ";

            string queryString_TemporaryTable = @"
                                                 CREATE TABLE #Temp_IPOAcc(
                                                    ID  INT IDENTITY(1,1), 
                                                    Cust_Code Varchar(100),
                                                    Amount Money,
                                                    Deposit_Withdraw Varchar(100),                                                    
                                                    ChannelType Varchar(150)
                                                 );   
            ";
            string queryString_TemporaryTable_NewInsertDetails = @"
                                                                    CREATE TABLE #Temp_IPOAcc_NewInsert(
                                                                       Cust_Code varchar(100),
                                                                       Trans_ID INT
                                                                    );
            ";

            string queryString_InsertTemporaryTable = string.Empty;

            for (int i = 0; i < Details_CustCode_IPOAcc.Length; i++)
            {
                string queryString_InsertTemporaryTable_Temp = @"INSERT INTO #Temp_IPOAcc (Cust_Code,Amount,Deposit_Withdraw,ChannelType) VALUES('" + Details_CustCode_IPOAcc[i] + @"'," + Amount_Details_CustCode[i] + @",'" + Deposit_Withdraw_Details_CustCode + @"','" + ChannelType[i] + @"');
                ";
                queryString_InsertTemporaryTable = queryString_InsertTemporaryTable + queryString_InsertTemporaryTable_Temp;
            }

            //Transfer Direction
            string TransferDirection_TransCustCode = string.Empty;
            if (Deposit_Withdraw_TransCustCode == Indication_PaymentMode.Deposit)
                TransferDirection_TransCustCode = "From ";
            else
                TransferDirection_TransCustCode = "To ";

            string TransferDirection_DetailsCustCode = string.Empty;
            if (Deposit_Withdraw_Details_CustCode == Indication_PaymentMode.Deposit)
                TransferDirection_DetailsCustCode = "From ";
            else
                TransferDirection_DetailsCustCode = "To ";


            // TransCode Transaction
            string queryString_InsertTransCode = string.Empty;
            //if (Deposit_Withdraw_TransCustCode == Indication_PaymentMode.Deposit)
            //{
            queryString_InsertTransCode = @"INSERT INTO [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction]
                                               ([Cust_Code]
                                               ,[Received_Date]
                                               ,[Money_TransactionType_ID]
                                               ,[Money_TransactionType_Name]
                                               ,[Deposit_Withdraw]
                                               ,[Amount]
                                               ,[Voucher_No]
                                               ,[Trans_Reason]
                                               ,[Remarks]
                                                ,[Approval_Status]
                                               ,[Entry_Branch_ID]
                                               ,[Entry_Date]
                                               ,[Entry_By])

                           VALUES( 
                                                                
                                '" + Trans_Cust_Code_IPOAcc + @"'                                
                                ,'" + ReceivedDate.ToShortDateString() + @"' /*AS Received_Date*/
                                ,(    SELECT [ID]
                                    FROM [SBP_Database].[dbo].[SBP_IPO_MoneyTrans_Type]
                                    WHERE [MoneyTransType_Name]='" + PaymentMethodForIPOtoIPO + @"'
                                )/* AS Money_TransactionType_ID*/
                                ,'" + PaymentMethodForIPOtoIPO + @"' /*AS Money_TransactionType_Name*/
                                ,'" + Deposit_Withdraw_TransCustCode + @"' /*AS Deposit_Withdraw*/
                                ," + Amount_TransCustCode + @" /*AS Amount*/  
                                ,'" + VoucherNo + @"' /*AS Voucher_No*/
                                ,'" + Trans_Cust_Code_IPOAcc + " " + TransferDirection_TransCustCode + " " + (Details_CustCode_IPOAcc.Length > 1 ? "MulitCustomers" : "" + Details_CustCode_IPOAcc[0].ToString() + "") + @"' /*AS Trans_Reason*/ 
                                ,'Withdraw_Auto IPO Application' /*AS Remarks*/ 
                                ,1 /*AS Approval_Status */
                                ," + GlobalVariableBO._branchId + @"                        
                                 
                                ,CONVERT(Varchar(10),GETDATE(),111) /*AS Entry_Date*/
                                ,'" + GlobalVariableBO._userName + @"'                                
                                
                           )";

            string lastId = @" declare @lastScopeIdentity int
                            set @lastScopeIdentity=(select scope_identity()) ";


            //Details IPO Code Transaction
            string queryString_InsertDetailsCode = string.Empty;
            //if (Deposit_Withdraw_Details_CustCode == Indication_PaymentMode.Deposit)
            //{
            queryString_InsertDetailsCode = @"INSERT INTO [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction]
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
                                ,[Channel]                               
                               ,[Approval_Status]
                               ,[Remarks]
                               ,[Entry_Branch_ID]
                               ,[Entry_Date]
                               ,[Entry_By]
                            )
                            SELECT 
                                Cust_Code
                                ,'" + ReceivedDate.ToShortDateString() + @"' AS Received_Date
                                ,(    SELECT [ID]
                                    FROM [SBP_Database].[dbo].[SBP_IPO_MoneyTrans_Type]
                                    WHERE [MoneyTransType_Name]='" + PaymentMethodForIPOtoIPO + @"'
                                ) AS Money_TransactionType_ID
                                ,'" + PaymentMethodForIPOtoIPO + @"' AS Money_TransactionType_Name
                                ,Deposit_Withdraw AS Deposit_Withdraw
                                , Amount AS Amount
                                ,'" + VoucherNo + @"' AS Voucher_No
                                ,(
                                    CASE 
                                        WHEN Deposit_Withdraw='Deposit' THEN " + "[Cust_Code]+ '" + @" " + TransferDirection_DetailsCustCode + @" " + Trans_Cust_Code_IPOAcc + @"'" + "+'_'+Convert(varchar(100),@lastScopeIdentity)" + @" 
                                        WHEN Deposit_Withdraw='Withdraw' THEN " + "[Cust_Code]+'" + @" " + TransferDirection_DetailsCustCode + @" " + Trans_Cust_Code_IPOAcc + @"'" + "+'_'+Convert(varchar(100),@lastScopeIdentity)" + @" 
                                    END
                                )AS Trans_Reason
                                ," + IntendedIPOSessionID + @" AS Intended_IPOSession_ID
                                ,( 
                                        SELECT  [IPOSession_Name]
                                        FROM [SBP_Database].[dbo].[SBP_IPO_Session]
                                        WHERE [ID]=" + IntendedIPOSessionID + @"
                                ) AS Intended_IPOSession_Name 
                                ,ChannelType                                
                                ,1 AS Approval_Status
                                ,'Deposit_Auto IPO Application'
                                ,'" + GlobalVariableBO._branchId + @"'
                                ,GETDATE() AS Entry_Date
                                ,'" + GlobalVariableBO._userName + @"'
                            FROM #Temp_IPOAcc 
                            ORDER BY ID
                            
                            DECLARE @First_Identity INT                            

                            SET @First_Identity=(
                                                    Select Scope_Identity()-(IDENT_INCR('SBP_IPO_Customer_Broker_MoneyTransaction')*@@Rowcount-1)
                            )                               
                        
                            ";




            string query_Insert_TemporaryTable_NewInsertDetails = string.Empty;

            query_Insert_TemporaryTable_NewInsertDetails = @"   INSERT INTO #Temp_IPOAcc_NewInsert(Cust_Code,Trans_ID)
                                                                Select Cust_Code,@First_Identity+(ID-1)
                                                                From  #Temp_IPOAcc
                                                                ORDER BY ID     
                                                            ";

            //Concat All Query

            string queryString = queryString_TemporaryTable + queryString_TemporaryTable_NewInsertDetails + queryString_InsertTemporaryTable + queryString_InsertTransCode + lastId + queryString_InsertDetailsCode + query_Insert_TemporaryTable_NewInsertDetails;

            try
            {
                _dbConnection.ExecuteNonQuery(queryString);
                dt = _dbConnection.ExecuteQuery(queryString_GetTemporaryTable_NewInsertDetails);
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
            return dt;
        }

        public void Insert_AutoApply_Application_MoneyTransaction_UITransApplied(int[] IPOSession_ID, string[] Cust_Code, Dictionary<string, int> RefundType, string Refund_Reference, DataTable money_trans_ref_id_Dt, int lot_No, string[] SerialNo, string[] SingelApplyRemarks, string[] ChannelID, string[] ChannelType)
        {

            CommonBAL comBal = new CommonBAL();

            DateTime TodayServerDate = comBal.GetCurrentServerDate();
            string queryString = "";
            queryString = @"[SBP_IpoApplicationProcess]";

            try
            {
                //_dbConnection.ConnectDatabase();
                //_dbConnection.StartTransaction();

                for (int i = 0; i < IPOSession_ID.Length; i++)
                {
                    for (int j = 0; j < Cust_Code.Length; j++)
                    {
                        int id = money_trans_ref_id_Dt.Rows.Cast<DataRow>().Where(t => Convert.ToString(t["Cust_Code"]) == Cust_Code[j]).Select(t => Convert.ToInt32(t[1])).FirstOrDefault();
                        int RefundID = RefundType.Where(c => Convert.ToString(c.Key) == Cust_Code[j]).Select(c => Convert.ToInt32(c.Value)).FirstOrDefault();
                        //int[] cId= money_trans_ref_id.Rows.Cast<DataRow>()
                        _dbConnection.ClearParameters();
                        //queryString = " exec [SBP_IPOApplicationProcess] " + IPOSession_ID[i] + "," + Cust_Code[j] + "," + RefundTypeID + ",'" + Refund_Reference + "'," + id + ",'" + GlobalVariableBO._userName + "',"+lot_No+"";
                        _dbConnection.AddParameter("@Session_ID", SqlDbType.Int, IPOSession_ID[i]);
                        _dbConnection.AddParameter("@Cust_Code", SqlDbType.Int, Cust_Code[j]);
                        _dbConnection.AddParameter("@RefundTypeID", SqlDbType.Int, RefundID);
                        _dbConnection.AddParameter("@Refund_Reference", SqlDbType.VarChar, Refund_Reference == Cust_Code[j] ? "" : Refund_Reference);
                        _dbConnection.AddParameter("@Money_Trans_Ref_ID", SqlDbType.Int, id);
                        _dbConnection.AddParameter("@Entry_Branch_ID", SqlDbType.Int, GlobalVariableBO._branchId);
                        _dbConnection.AddParameter("@Entry_By", SqlDbType.VarChar, GlobalVariableBO._userName);
                        _dbConnection.AddParameter("@ChannelID", SqlDbType.Int, 0);
                        _dbConnection.AddParameter("@ChannelType", SqlDbType.VarChar, ChannelType.Length > 0 ? ChannelType[i] : string.Empty);
                        _dbConnection.AddParameter("@Lot_No", SqlDbType.Int, lot_No);
                        //_dbConnection.AddParameter("@AutoApply", SqlDbType.VarChar, ChannelType.Length > 0 ? ChannelType[i] : string.Empty);
                        if (SerialNo.Length > 0)
                            _dbConnection.AddParameter("@VoucherNo", SqlDbType.VarChar, SerialNo[j]);
                        else
                            _dbConnection.AddParameter("@VoucherNo", SqlDbType.VarChar, DBNull.Value);
                        if (SingelApplyRemarks.Length > 0)
                            _dbConnection.AddParameter("@Remarks", SqlDbType.VarChar, SingelApplyRemarks[j]);
                        else
                            _dbConnection.AddParameter("@Remarks", SqlDbType.VarChar, DBNull.Value);

                        _dbConnection.ExecuteProQuery(queryString);
                    }
                }
                //_dbConnection.Commit();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                // _dbConnection.Rollback();

            }
            //finally
            //{
            //    _dbConnection.CloseDatabase();
            //}
        }

        public void Auto_Application_Approval(string Cust_Code, int SessionID, double appcharge, string sessionName)
        {
            string pro = @"SBP_AutoApplication";
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
                                                                
			                                                    ,Convert(varchar(10),GETDATE(),111) AS EntryDate
			                                                    ,'" + GlobalVariableBO._userName + @"' AS [Entry_By]
                                                                ," + GlobalVariableBO._branchId + @"
	                                                    FROM [SBP_Database].[dbo].[SBP_IPO_Application_BasicInfo] As app
	                                                    WHERE app.Cust_Code = '" + Cust_Code + @"'
                                                        And app.IPOSession_ID=" + SessionID + @"
                                                        AND NOT EXISTS(
			                                                    Select t.* 
			                                                    From SBP_IPO_Customer_Broker_MoneyTransaction as t
			                                                    Where t.Cust_Code=app.Cust_Code AND Money_TransactionType_Name='TRIPOApp'
                                                                AND t.Deposit_Withdraw='" + Indication_PaymentMode.Withdraw + @"' 
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
                                                        --," + GlobalVariableBO._branchId + @"
	                                            FROM [SBP_Database].[dbo].[SBP_IPO_Application_BasicInfo] As app
	                                            WHERE app.Cust_Code = '" + Cust_Code + @"'
                                                And app.IPOSession_ID=" + SessionID + @"
                                                AND NOT EXISTS(
			                                                    Select t.* 
			                                                    From SBP_IPO_IPOApplication_MoneyTransaction as t
			                                                    Where t.Cust_Code=app.Cust_Code AND Money_TransactionType_Name='TRIPOApp' 
			                                                     AND t.Deposit_Withdraw='" + Indication_PaymentMode.Deposit + @"' 
                                                                AND t.Intended_IPOSession_ID=app.IPOSession_ID
                                                )
                                            ";
            string query = queryString_WithdrawMoneyFromIPOAccount + queryString_DepositToIPOAppAccount;
            try
            {

                //_dbConnection.ExecuteNonQuery(query);
                //_dbConnection.ExecuteNonQuery(queryString_WithdrawMoneyFromIPOAccount);
                //_dbConnection.ExecuteNonQuery(queryString_DepositToIPOAppAccount);
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@cust_Code", SqlDbType.VarChar, Cust_Code);
                _dbConnection.AddParameter("@SessionID", SqlDbType.VarChar, SessionID);
                _dbConnection.AddParameter("@AppCharge", SqlDbType.Money, appcharge);
                _dbConnection.AddParameter("@UserName", SqlDbType.VarChar, GlobalVariableBO._userName);
                _dbConnection.AddParameter("@EntryBranchID", SqlDbType.Int, GlobalVariableBO._branchId);
                _dbConnection.AddParameter("@SessionName", SqlDbType.VarChar, sessionName);
                _dbConnection.ExecuteProQuery(pro);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        #endregion

        #region Parent And Child Info
        public DataTable GetParentChildInfo(string parentId, string CodeName)
        {
            string query = @"SBP_IPOParentAndChildForTRTA";
            DataTable dt = new DataTable();
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@ParentCode", SqlDbType.VarChar, parentId);
                _dbConnection.AddParameter("@SelectName", SqlDbType.VarChar, CodeName);
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
        public DataTable GetAllChildCode(string parent)
        {
            DataTable dt = new DataTable();
            string parentCode = @"DECLARE @Parent_Cust_Code Varchar(100)='" + parent + @"'
                                Select Child_Code 
                                From  SBP_Parent_Child_Details 
                                Where Parent_Code=(
					                                Select Parent_Code From SBP_Parent_Child_Details Where Child_Code=@Parent_Cust_Code)"
                                    ;
            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(parentCode);
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

        public DataTable GetParentCodeFromChildCode(string[] Child_Code)
        {
            DataTable dt = new DataTable();
            string query = "";
            string Child_join = string.Join(",", Child_Code);
            string Parent_Code = "";
            if (Child_join != string.Empty)
            {
                query = @"select distinct Parent_Code from SBP_Parent_Child_Details where Child_Code in (" + Child_join + ")";
            }
            else
            {
                throw new Exception("Code not found");
            }
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
                _dbConnection.ConnectDatabase();
            }           
            return dt;
        }
        #endregion

        #region Bank 
        /// <summary>
        /// Get Bank Name,ID,Bank Code Added By Md.Rashedul Hasan
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllBankName()
        {
            DataTable DtBankName = new DataTable();
            string query = @"Select ID,Bank_Code,Bank_Name,Branch_Name,Routing_No From SBP_Bank_Branch_Routing_Info ";
            try
            {
                _dbConnection.ConnectDatabase();
                DtBankName = _dbConnection.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return DtBankName;
        }
        #endregion

        #region NRB Applicant Info

        /// <summary>
        /// Load All Nrb information By company id
        /// </summary>
        /// <param name="CompanyId">NRB Draft information by company id</param>
        /// <param name="SessionID">NRB Draft information by session id</param>
        /// <returns></returns>
        public DataTable GetIPO_NRB_DraftInformation(string CompanyId, string SessionID)
        {
            DataTable dt = new DataTable();
            string query = "";
            if (!string.IsNullOrEmpty(CompanyId))
            {
                query = @" Select 
                                * 
                           From 
                                SBP_IPO_NRB_Customer_DraftInformation
                           Where 
                                Intended_IPOSession_ID=
                                (
                                    Select 
                                        sess.ID 
                                    From 
                                        SBP_IPO_Session As sess
                                    Join 
                                        SBP_IPO_Company_Info As com
                                    on 
                                        sess.IPO_Company_ID=com.ID
                                    Where 
                                        com.ID=" + CompanyId + @"
                                    And 
                                        sess.IPOSession_Name<>''
                                )";
            }
            else if (!string.IsNullOrEmpty(SessionID))
            {
                query = @" Select 
                            * 
                          From 
                            SBP_IPO_NRB_Customer_DraftInformation
                          Where 
                            Intended_IPOSession_ID='" + SessionID + @"'
                          
                          ";
            }
            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;
        }

        /// <summary>
        /// Load All Nrb information By company id
        /// </summary>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        /// Old on 01 oct 2015
//        public DataTable GetIPO_NRB_DraftInformation(string CompanyId)
//        {
//            DataTable dt = new DataTable();
//            string query = @" Select * From SBP_IPO_NRB_Customer_DraftInformation
//                              Where Intended_IPOSession_ID=
//                              (
//	                              Select sess.ID From SBP_IPO_Session As sess
//	                              Join SBP_IPO_Company_Info As com
//	                              on sess.IPO_Company_ID=com.ID
//	                              Where com.ID=" + CompanyId + @"
//	                              And sess.IPOSession_Name<>''
//                              )";
//            try
//            {
//                _dbConnection.ConnectDatabase();
//                dt = _dbConnection.ExecuteQuery(query);
//            }
//            catch (Exception ex)
//            {
//                throw new Exception(ex.Message);
//            }
//            return dt;
//        }

        /// <summary>
        /// Nrb Wrong Transaction Deleted
        /// Md.Rashedul Hasan
        /// </summary>
        /// <param name="NRBID"></param>
        public void GetNRB_DeleteData(int NRBID)
        {
            string query = @"SBP_IPO_NRB_TransactionDelete";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.AddParameter("@ID", SqlDbType.Int, NRBID);
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

        //old on 01 oct 2015
//        public void GetNRBRefundStatusUpdate(string id, string name)
//        {
//            string query = @"
//                        update SBP_IPO_NRB_Customer_DraftInformation 
//                        set Draft_Status='5' 
//                        ,Update_By='" + GlobalVariableBO._userName + @"'
//                        ,Update_Date=GETDATE()
//                        ,Collected_BY='" + name + @"'
//                        ,Collected_Date=GETDATE()
//                        Where ID IN (" + id + @")
//                        ";
//            try
//            {
//                _dbConnection.ConnectDatabase();
//                _dbConnection.ExecuteNonQuery(query);
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//            finally
//            {
//                _dbConnection.CloseDatabase();
//            }
//        }
        /// <summary>
        /// NRB Draft collected by Draft owner
        /// Update Warrent no on 01 oct 2015 By Rashedul Hasan
        /// </summary>
        /// <param name="id">Deposit ID</param>
        /// <param name="name">Collector Mobile No</param>
        /// <param name="WarrantNo">DSE Provide Warrent no against every draft</param>
        public void GetNRBRefundStatusUpdate(string id, string name, string WarrantNo)
        {
            string query = @"
                        update SBP_IPO_NRB_Customer_DraftInformation 
                        set Draft_Status='5'
                        ,WarrantNo='" + WarrantNo + @"'
                        ,Update_By='" + GlobalVariableBO._userName + @"'
                        ,Update_Date=GETDATE()
                        ,Collected_BY='" + name + @"'
                        ,Collected_Date=GETDATE()
                        Where ID IN (" + id + @")
                        ";
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

        /// <summary>
        /// Get Currency Amount 
        /// Add by Md.Rashedul Hasan
        /// </summary>
        /// <param name="Company_Name"></param>
        /// <param name="Currency_Name"></param>
        /// <returns></returns>
        public double Get_NRB_IPO_Amount(string Company_Name, string Currency_Name)
        {
            DataTable dt = new DataTable();
            double Amount = 0.0;
            string Query = @"Select currency_Amount 
                                From SBP_IPO_Session_NRB As N
                                Join SBP_IPO_Company_Info As C
                                ON C.ID=N.IPO_Company_ID
                                Where C.Company_Short_Code='" + Company_Name + @"'
                                And Currency_Name='" + Currency_Name + "'";
            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(Query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            if (dt.Rows.Count > 0)
            {
                Amount = Convert.ToDouble(dt.Rows[0]["currency_Amount"]);
            }
            return Amount;

        }

        /// <summary>
        /// Currency Symbol 
        /// Added by Md.Rashedul Hasan
        /// </summary>
        /// <returns></returns>
        /// <summary>
        /// Currency Symbol 
        /// Added by Md.Rashedul Hasan
        /// </summary>
        /// <returns></returns>
        public DataTable GetNRB_CurrnecyAmount_Symbol(int sessionID)
        {
            DataTable dt = new DataTable();
            string query = @"select 
                            MAX(Case When c.Currency_Name='EUR' THEN (Convert(varchar(10),Currency_Amount)+currency_Symbol) END) As EUR_Symbol
                            ,MAX(Case When c.Currency_Name='GBP' THEN (Convert(varchar(10),Currency_Amount)+currency_Symbol) END) As GBP_Symbol
                            ,MAX(Case When c.Currency_Name='USD' THEN (Convert(varchar(10),Currency_Amount)+currency_Symbol) END) As USD_Symbol
                            From SBP_IPO_Session_NRB As n
                            Left join SBP_IPO_Currency As c
                            ON n.Currency_ID=c.ID 
                            Where n.IPO_Session_ID=
                            (   
                                Select 
                                    ID   
                                    From SBP_IPO_Session 
                                    Where IPO_Company_ID=" + sessionID + @")
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
            return dt;
        }
        /// <summary>
        /// Currency Name 
        /// Added By Md.Rashedul Hasan
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllCurrency_Name()
        {
            DataTable dt = new DataTable();
            string query = @" Select  
                             Max(Case when Currency_Name='EUR' THEN 'EUR' END) As EUR
                             ,Max(Case when Currency_Name='GBP' THEN 'GBP' END) As GBP
                             ,Max(Case when Currency_Name='USD' THEN 'USD' END) As USD
                             From SBP_IPO_Currency";
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
        /// Md.Rashedul Hasan
        /// </summary>
        /// <param name="code">Customer Code</param>
        /// <param name="sessionid">Session Id</param>
        /// <param name="voucher">Draft voucher no</param>
        /// <returns></returns>
        public DataTable Get_NRB_DraftReturnData(string code, int sessionid, string voucher)
        {
            DataTable dt = new DataTable();
            string query = @"Select  di.ID As 'ID'
		                            ,di.Voucher_No
		                            ,sta.NRB_Status_Desc As 'Draft Status'
		                            ,di.Bank_Name
		                            ,di.Cust_Code As 'Code'
		                            ,(Select Cust_Name From SBP_Cust_Personal_Info Where Cust_Code=di.Cust_Code) As 'Client_Name'
		                            ,(Select BO_ID From SBP_Customers Where Cust_Code=di.Cust_Code) As 'Bo_ID'
		                            ,FD_NO AS 'DD No'
		                            ,Currency_Name As 'Currency'
		                            ,Currency_Amount As 'Amount'
		                            ,(Select Company_Short_Code 
		                                   From SBP_IPO_Company_Info as c
			                               join SBP_IPO_Session as sess 
			                               on sess.IPO_Company_ID=c.ID
			                               Where sess.ID=di.Intended_IPOSession_ID) As 'Comp_code'
		                            ,Bank_Name                          
		                            ,(Select Recidency From SBP_Cust_Additional_Info where Cust_Code=di.Cust_Code) As 'Resident'
		                            From SBP_IPO_NRB_Customer_DraftInformation as di
		                              Join SBP_IPO_NRB_ApplicationStatus as sta
		                              on sta.ID=di.Draft_Status
		                              Join SBP_IPO_Application_BasicInfo as bs
		                              on bs.Money_Trans_NRB_ID=di.ID
		                            Where 
		                            --Isnull(bs.Fine_Amount,0)>0 OR bs.Fine_Amount=0
		                            di.Voucher_No IN (Select distinct Voucher_No 
		                                                    from SBP_IPO_NRB_Customer_DraftInformation as c 
		                                                    Where c.Cust_Code='" + code + @"' OR c.Voucher_No='" + voucher + @"')
		                            And di.Draft_Status=4
		                            And Intended_IPOSession_ID=" + sessionid + @"";
            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        /// <summary>
        /// Check NRB Account Status
        /// Rashedul Hasan
        /// </summary>
        /// <param name="code"></param>
        /// <param name="sessionID"></param>
        /// <returns></returns>
        public string CheckNrbAccountStatus(string code, int sessionID, string voucher)
        {
            DataTable dt = new DataTable();
            string NrbStatus = "";
            string query = @"Select a.NRB_Status_Desc From SBP_IPO_NRB_Customer_DraftInformation as d
                            Join SBP_IPO_NRB_ApplicationStatus as a
                            on a.ID=d.Draft_Status
	                        Where d.Cust_Code='" + code + @"' 
                            OR d.Voucher_No='" + voucher + @"'
                            and d.Intended_IPOSession_ID=" + sessionID + " ";
            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(query);
                if (dt.Rows.Count > 0)
                {
                    NrbStatus = dt.Rows[0][0].ToString();
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
            return NrbStatus; ;
        }

        /// <summary>
        /// Draft Successfully Return To the client
        /// Rashedul hasan
        /// </summary>
        /// <returns>NRB Draft Successful Unsuccessful and customer collected data</returns>
        public DataTable Get_NRB_DraftReturnData()
        {
            DataTable dt = new DataTable();
            string query = @"Select 
                                     di.ID As 'Trn_ID'
                                    ,bs.ID As 'App_ID'
                                    ,ext.BasicInfo_ID
                                    ,di.Voucher_No
                                    ,di.WarrantNo
                                    ,NRB_appSt.NRB_Status_Desc As 'NRB_Status'
                                    ,di.Bank_Name
                                    ,di.FD_NO As 'DD NO'
                                    ,di.Cust_Code As 'Code'
                                    ,ext.Cust_Name As 'Name'
                                    ,ext.Applicant_Category As 'Type'
                                    ,di.Receive_Date As 'Date'
                                    ,di.Payment_Media_Type As 'Media' 
                                    ,di.Currency_Name As 'Currency'
                                    ,di.Currency_Amount As 'Amount'
                                    ,bs.Applied_Company As 'Company'
                                    ,di.Intended_IPOSession_Name As 'Session' 
                                    ,IPO_appSt.Status_Name As 'App_Status'                            
                                    From SBP_IPO_NRB_Customer_DraftInformation As di
                                    Join SBP_IPO_Application_BasicInfo As bs
                                    on di.ID=bs.Money_Trans_NRB_ID
                                    JOin SBP_IPO_Application_ExtendedInfo As ext
                                    on ext.BasicInfo_ID=bs.ID
                                    Join SBP_IPO_Approval_Status As IPO_appSt
                                    on bs.Application_Satus=IPO_appSt.ID
                                    Join SBP_IPO_NRB_ApplicationStatus as NRB_appSt
                                    ON NRB_appSt.ID=di.Draft_Status
                                    Where di.Draft_Status IN (3,4,5)
                                    And bs.Application_Satus IN (3,4)";
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

        public DataTable Get_NRB_IPO_Application_Data(DateTime date)
        {
            DataTable dt = new DataTable();
            string query = @"Select 
                            T.ID As Trn_ID,bs.ID As App_ID,ext.BasicInfo_ID
                            ,T.Cust_Code As Code
                            ,ext.Cust_Name As Name
                            ,ext.Applicant_Category As Type
                            ,T.FD_NO As 'DD NO'
                            ,T.Bank_Name
                            ,T.BranchName                            
                            ,T.Voucher_No
                            ,T.Currency_Name As Currency
                            ,T.Currency_Amount As Amount
                            ,bs.Applied_Company As Company
                            ,T.Intended_IPOSession_Name As Session
                            ,T.Receive_Date As Date
                            ,st.Status_Name As App_Status
                            ,NS.NRB_Status_Name As NRB_Status
                            ,T.Payment_Media_Type As Media
                            From SBP_IPO_NRB_Customer_DraftInformation As T
                            Join SBP_IPO_Application_BasicInfo As bs
                            on T.ID=bs.Money_Trans_NRB_ID
                            JOin SBP_IPO_Application_ExtendedInfo As ext
                            on ext.BasicInfo_ID=bs.ID
                            Join SBP_IPO_Approval_Status As st
                            on T.Approval_Status=st.ID
                            Join SBP_IPO_NRB_ApplicationStatus as NS
                            ON NS.ID=T.Draft_Status
                            Where T.Receive_Date='" + date.Date + @"'
                            And T.Entry_Branch_ID='" + GlobalVariableBO._branchId + @"'
                            And T.Entry_By='" + GlobalVariableBO._userName + @"'
                            And T.Draft_Status IN (1,2)";
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
        //v1
//        /// <summary>
//        /// NRB IPO Application List by current Date on Payemnt Form
//        /// Md.Rashedul Hasan 
//        /// </summary>
//        /// <param name="date"></param>
//        /// <returns></returns>
//        public DataTable Get_NRB_IPO_Application_Data(DateTime date)
//        {
//            DataTable dt = new DataTable();
//            string query = @"Select 
//                            T.ID As Trn_ID,bs.ID As App_ID,ext.BasicInfo_ID
//                            ,T.Cust_Code As Code
//                            ,ext.Cust_Name As Name
//                            ,ext.Applicant_Category As Type
//                            ,T.Receive_Date As Date
//                            ,T.Payment_Media_Type As Media                             
//                            ,T.FD_NO As 'DD NO'
//                            ,T.Currency_Name As Currency
//                            ,T.Currency_Amount As Amount
//                            ,bs.Applied_Company As Company
//                            ,T.Intended_IPOSession_Name As Session
//                            ,st.Status_Name As App_Status
//                            ,NS.NRB_Status_Name As NRB_Status
//                            From SBP_IPO_NRB_Customer_DraftInformation As T
//                            Join SBP_IPO_Application_BasicInfo As bs
//                            on T.ID=bs.Money_Trans_NRB_ID
//                            JOin SBP_IPO_Application_ExtendedInfo As ext
//                            on ext.BasicInfo_ID=bs.ID
//                            Join SBP_IPO_Approval_Status As st
//                            on T.Approval_Status=st.ID
//                            Join SBP_IPO_NRB_ApplicationStatus as NS
//                            ON NS.ID=T.Draft_Status
//                            Where T.Receive_Date='" + date.Date + @"'
//                            And T.Entry_Branch_ID='" + GlobalVariableBO._branchId + @"'
//                            And T.Entry_By='" + GlobalVariableBO._userName + @"'
//                            And T.Draft_Status IN (1,2)";
//            try
//            {
//                _dbConnection.ConnectDatabase();
//                dt = _dbConnection.ExecuteQuery(query);
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//            finally
//            {
//                _dbConnection.CloseDatabase();
//            }
//            return dt;
//        }
        /// <summary>
        /// NRB IPO Application List by current Date on Payemnt Form
        /// Md.Rashedul Hasan 
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public DataTable Get_NRB_IPO_Application_PendingList(DateTime date)
        {
            DataTable dt = new DataTable();
            string query = @"Select 
                            T.ID As Trn_ID,bs.ID As App_ID,ext.BasicInfo_ID
                            ,T.Cust_Code,ext.Cust_Name,ext.Applicant_Category,T.Receive_Date--,T.Money_Transaction_Name
                            --,T.Deposit_Withdraw
                            ,T.FD_NO,T.Currency_Name,T.Currency_Amount--,T.Charge
                            ,bs.Applied_Company,T.Intended_IPOSession_Name
                            ,st.Status_Name,NS.NRB_Status_Name
                            From SBP_IPO_NRB_Customer_DraftInformation As T
                            Join SBP_IPO_Application_BasicInfo As bs
                            on T.ID=bs.Money_Trans_NRB_ID
                            JOin SBP_IPO_Application_ExtendedInfo As ext
                            on ext.BasicInfo_ID=bs.ID
                            Join SBP_IPO_Approval_Status As st
                            on T.Approval_Status=st.ID
                            Join SBP_IPO_NRB_ApplicationStatus as NS
                            ON NS.ID=T.Draft_Status
                            Where T.Receive_Date='" + date.Date + @"'
                            And T.Entry_Branch_ID='"+GlobalVariableBO._branchId+"'";
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
        /// EFT Return for IPO
        /// Added Rashedul Hasan 21-05-2016
        /// </summary>
        /// <param name="id">EFT Return Customer transaction ID </param>
        /// <param name="cust_code">Return customer code</param>
        /// <param name="amount">Return amount</param>
        /// <param name="date">Eft return date</param>
        /// <param name="remarks">Why return</param>
        /// <param name="voucher">Return voucher no</param>
        public void InsertIPO_EFT_Return(string id, string cust_code, double amount, DateTime date, string remarks, string voucher)
        {
            string query = @"INSERT INTO [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction]
                               ([Cust_Code]
                               ,[Received_Date]
                               ,[Money_TransactionType_ID]
                               ,[Money_TransactionType_Name]
                               ,[Deposit_Withdraw]
                               ,[Amount]
                               ,[Voucher_No]
                               ,[Trans_Reason]
                               ,[Remarks]
                               
                               ,[Approval_Status]
                               
                               ,[Entry_Branch_ID]
                               ,[Entry_Date]
                               ,[Entry_By]
                               )
                        values( " + cust_code + @"
                               ,cast(Getdate() as date) 
                               ,'" + Indication_IPOPaymentTransaction.EFTReturn_ID + @"'
                               ,'" + Indication_IPOPaymentTransaction.EFT_Return + @"'
                               ,'" + Indication_PaymentMode.Deposit + @"'
                               ,'" + amount + @"'
                               ,'" + voucher + @"'
                               ,'" + id + @"_EFTRETURN_" + cust_code + @"'
                               ,'" + remarks + @"'                               
                               ,0                               
                               ,'" + GlobalVariableBO._branchId + @"'
                               , GETDATE()
                               ,'" + GlobalVariableBO._userName + @"' )
                                    ";
            try
            {
                //_dbConnection.ConnectDatabase();
                _dbConnection.ClearParameters();
                _dbConnection.ExecuteNonQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //_dbConnection.CloseDatabase();
            }
        }
        /// <summary>
        /// Save NRB Application Data 
        /// Added By. Md.Rashedul Hasan
        /// </summary>
        /// <param name="CompanyID"></param>
        /// <param name="Cust_Code"></param>
        /// <param name="RefundID"></param>
        /// <param name="voucher_No"></param>
        public void Insert_NRB_IPO_Application_Process(int CompanyID, string Cust_Code, int RefundID, string voucher_No, string currency_Name, string FD_NO)
        {
            //string query = @"Exec SBP_NRB_IPOApplicationProcess " + CompanyID + ",'" + Cust_Code + "'," + RefundID + ",'" + GlobalVariableBO._userName + "','" + voucher_No + "','" + GlobalVariableBO._branchId + "'";
            string query = @"SBP_NRB_IPOApplicationProcess";
            try
            {
                _dbConnection.ClearParameters();
                _dbConnection.AddParameter("@Company_ID", SqlDbType.Int, CompanyID);
                _dbConnection.AddParameter("@Cust_Code", SqlDbType.VarChar, Cust_Code);
                _dbConnection.AddParameter("@RefundTypeID", SqlDbType.Int, RefundID);
                _dbConnection.AddParameter("@Entry_By", SqlDbType.VarChar, GlobalVariableBO._userName);
                _dbConnection.AddParameter("@VoucherNo", SqlDbType.VarChar, voucher_No);
                _dbConnection.AddParameter("@Entry_Branch_ID", SqlDbType.Int, GlobalVariableBO._branchId);
                _dbConnection.AddParameter("@Currency_Name", SqlDbType.VarChar, currency_Name);
                _dbConnection.AddParameter("@FD_NO", SqlDbType.VarChar, FD_NO);
                _dbConnection.ExecuteProQuery(query);
                //_dbConnection.ExecuteProByText(query);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Save NRB IPO Money Transaction 
        /// Added By Md.Rashedul Hasan
        /// </summary>
        /// <param name="Cust_Code">NRB Applicant Cust Code</param>
        /// <param name="Bank_Name">Draft Bank Name</param>
        /// <param name="Bank_ID">Draft Bank ID</param>
        /// <param name="Company_ID">Application Company ID</param>
        /// <param name="Deposit"></param>
        /// <param name="Receive_Date">Draft Receive Date</param>
        /// <param name="Fd_No">Draft DD no</param>
        /// <param name="currency">Application Currency name</param>
        /// <param name="amount">Application Amount</param>
        /// <param name="voucher">Draft voucher</param>
        /// <param name="Bank_BranchName">Bank Branch Name</param>
        /// <param name="JoinOrSingelAmount">Joint Amount or single amount</param>
        /// <param name="Draftdate">Bank Draft Date</param>
        public void Insert_NRB_IPO_Money_Transaction(string Cust_Code, string Bank_Name, int Bank_ID, string Bank_BranchName, int Company_ID, DateTime Receive_Date, DateTime Draftdate, string Fd_No, string currency, decimal amount, decimal JoinOrSingelAmount, decimal Charge, string voucher, string M_Trans_Type, int M_Trans_ID, string Charge_Trans_Type)
        {
            string Query = @"SBP_IPO_NRB_Applicant_DraftInformation_Process";
            try
            {

                _dbConnection.ClearParameters();
                _dbConnection.AddParameter("@Cust_Code", SqlDbType.VarChar, Cust_Code);
                _dbConnection.AddParameter("@Bank_Name", SqlDbType.VarChar, Bank_Name);
                _dbConnection.AddParameter("@Bank_ID", SqlDbType.Int, Bank_ID);
                _dbConnection.AddParameter("@BranchName", SqlDbType.VarChar, Bank_BranchName);
                _dbConnection.AddParameter("@Company_ID", SqlDbType.Int, Company_ID);
                _dbConnection.AddParameter("@DraftDate", SqlDbType.VarChar, Draftdate.Date);
                _dbConnection.AddParameter("@Receive_Date", SqlDbType.Date, GlobalVariableBO._currentServerDate.Date);
                _dbConnection.AddParameter("@FD_NO", SqlDbType.VarChar, Fd_No);
                _dbConnection.AddParameter("@Voucher", SqlDbType.VarChar, voucher);
                _dbConnection.AddParameter("@Currency", SqlDbType.VarChar, currency);
                _dbConnection.AddParameter("@Currency_Amount", SqlDbType.Decimal, amount);
                _dbConnection.AddParameter("@CurrencyAmount_JoinOrSingle", SqlDbType.Decimal, JoinOrSingelAmount);
                _dbConnection.AddParameter("@Charge", SqlDbType.Decimal, Charge);
                _dbConnection.AddParameter("@Entry_By", SqlDbType.VarChar, GlobalVariableBO._userName);
                _dbConnection.AddParameter("@Entry_Branch_ID", SqlDbType.VarChar, GlobalVariableBO._branchId);
                _dbConnection.AddParameter("@M_Trans_Name", SqlDbType.VarChar, M_Trans_Type);
                _dbConnection.AddParameter("@M_Trans_ID", SqlDbType.VarChar, M_Trans_ID);
                _dbConnection.AddParameter("@Charge_TransType", SqlDbType.VarChar, Charge_Trans_Type);
                _dbConnection.ExecuteProQuery(Query);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        //public void Insert_NRB_IPO_Money_Transaction(string Cust_Code, string Bank_Name, int Bank_ID, string Bank_BranchName, int Company_ID, DateTime Receive_Date, string Fd_No, string currency, decimal amount, decimal Charge, string voucher, string M_Trans_Type, int M_Trans_ID, string Charge_Trans_Type)
        //{
        //    string Query = @"SBP_IPO_NRB_Applicant_DraftInformation_Process";
        //    try
        //    {
        //        _dbConnection.ClearParameters();
        //        _dbConnection.AddParameter("@Cust_Code", SqlDbType.VarChar, Cust_Code);
        //        _dbConnection.AddParameter("@Bank_Name", SqlDbType.VarChar, Bank_Name);
        //        _dbConnection.AddParameter("@Bank_ID", SqlDbType.Int, Bank_ID);
        //        _dbConnection.AddParameter("@BranchName", SqlDbType.VarChar, Bank_BranchName);
        //        _dbConnection.AddParameter("@Company_ID", SqlDbType.Int, Company_ID);
        //        //_dbConnection.AddParameter("@Depost", SqlDbType.VarChar, Deposit);
        //        _dbConnection.AddParameter("@Receive_Date", SqlDbType.Date, GlobalVariableBO._currentServerDate.Date);
        //        _dbConnection.AddParameter("@FD_NO", SqlDbType.VarChar, Fd_No);
        //        _dbConnection.AddParameter("@Voucher", SqlDbType.VarChar, voucher);
        //        _dbConnection.AddParameter("@Currency", SqlDbType.VarChar, currency);
        //        _dbConnection.AddParameter("@Currency_Amount", SqlDbType.Decimal, amount);
        //        _dbConnection.AddParameter("@Charge", SqlDbType.Decimal, Charge);
        //        _dbConnection.AddParameter("@Entry_By", SqlDbType.VarChar, GlobalVariableBO._userName);
        //        _dbConnection.AddParameter("@Entry_Branch_ID", SqlDbType.VarChar, GlobalVariableBO._branchId);
        //        _dbConnection.AddParameter("@M_Trans_Name", SqlDbType.VarChar, M_Trans_Type);
        //        _dbConnection.AddParameter("@M_Trans_ID", SqlDbType.VarChar, M_Trans_ID);
        //        _dbConnection.AddParameter("@Charge_TransType", SqlDbType.VarChar, Charge_Trans_Type);
        //        _dbConnection.ExecuteProQuery(Query);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //v2
        //public void Insert_NRB_IPO_Money_Transaction(string Cust_Code, string Bank_Name, int Bank_ID, string Bank_BranchName, int Company_ID, DateTime Receive_Date, string Fd_No, string currency, decimal amount, decimal Charge, string voucher, string M_Trans_Type, int M_Trans_ID, string Charge_Trans_Type)
        //{
        //    string Query = @"SBP_IPO_NRB_Applicant_DraftInformation_Process";
        //    try
        //    {
        //        _dbConnection.ClearParameters();
        //        _dbConnection.AddParameter("@Cust_Code", SqlDbType.VarChar, Cust_Code);
        //        _dbConnection.AddParameter("@Bank_Name", SqlDbType.VarChar, Bank_Name);
        //        _dbConnection.AddParameter("@Bank_ID", SqlDbType.Int, Bank_ID);
        //        _dbConnection.AddParameter("@BranchName", SqlDbType.VarChar, Bank_BranchName);
        //        _dbConnection.AddParameter("@Company_ID", SqlDbType.Int, Company_ID);
        //        //_dbConnection.AddParameter("@Depost", SqlDbType.VarChar, Deposit);
        //        _dbConnection.AddParameter("@Receive_Date", SqlDbType.Date, GlobalVariableBO._currentServerDate.Date);
        //        _dbConnection.AddParameter("@FD_NO", SqlDbType.VarChar, Fd_No);
        //        _dbConnection.AddParameter("@Voucher", SqlDbType.VarChar, voucher);
        //        _dbConnection.AddParameter("@Currency", SqlDbType.VarChar, currency);
        //        _dbConnection.AddParameter("@Currency_Amount", SqlDbType.Decimal, amount);
        //        _dbConnection.AddParameter("@Charge", SqlDbType.Decimal, Charge);
        //        _dbConnection.AddParameter("@Entry_By", SqlDbType.VarChar, GlobalVariableBO._userName);
        //        _dbConnection.AddParameter("@Entry_Branch_ID", SqlDbType.VarChar, GlobalVariableBO._branchId);
        //        _dbConnection.AddParameter("@M_Trans_Name", SqlDbType.VarChar, M_Trans_Type);
        //        _dbConnection.AddParameter("@M_Trans_ID", SqlDbType.VarChar, M_Trans_ID);
        //        _dbConnection.AddParameter("@Charge_TransType", SqlDbType.VarChar, Charge_Trans_Type);
        //        _dbConnection.ExecuteProQuery(Query);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        /// <summary>
        /// Active NRB Client Checking 
        /// Added By Md.Rashedul Hasan
        /// </summary>
        /// <param name="Cust_COde"></param>
        /// <returns></returns>
        public string GetActive_NRB_Cust_Code(string Cust_COde)
        {
            DataTable dt = new DataTable();
            string Code = "";
            string Query = @"Select cust.Cust_Code From SBP_Cust_Additional_Info As Addt
                            Join SBP_Customers As cust
                            ON Addt.Cust_Code=cust.Cust_Code
                            Where Recidency='Non Resident'
                            And cust.Cust_Status_ID=1
                            And cust.Cust_Code='" + Cust_COde + "'";
            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(Query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            if (dt.Rows.Count > 0)
            {
                Code = dt.Rows[0]["Cust_Code"].ToString();
            }
            return Code;
        }

        /// <summary>
        /// Applicant information from application table
        /// add by md rashedul hasan on 06 sep 2015
        /// </summary>
        /// <typeparam name="T">Any kind of variable you are able to pass</typeparam>
        /// <param name="Cust_Code">Customer information From application table by cust code</param>
        /// <param name="SessionID">customer information by session id</param>
        /// <returns></returns>
        public DataTable GetIPOApplicationTableDataByCustCode_SessionID_Check_IsAlreadyApply(string Cust_Code, string SessionID)
        {
            DataTable dt = new DataTable();
            string Qeury = @"Select bs.Cust_Code,bs.BO_ID,bs.IPOSession_ID,bs.Applied_Company,bs.ChannelID,bs.ChannelType,bs.TotalAmount,bs.Total_Share_Value
                        ,bs.Serial_No,bs.Money_Trans_NRB_ID,bs.Money_Trans_Ref_ID,ext.Applicant_Category,ext.Refund_Method,ext.Refund_Other_Details
                         From SBP_IPO_Application_BasicInfo As bs
                        Join SBP_IPO_Application_ExtendedInfo As ext
                        ON ext.BasicInfo_ID=bs.ID
                        Where bs.Cust_Code='" + Cust_Code + "' And bs.IPOSession_ID=" + SessionID + ""
                ;
            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(Qeury);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;
        }

        /// <summary>
        /// Currency Loading For IPO Application 
        /// Md.Rashedul Hasan
        /// </summary>
        /// <returns></returns>
        public DataTable GetCurrencyName()
        {
            DataTable DtCurrency = new DataTable();
            string query = @"Select ID,Currency_Name From SBP_IPO_Currency";
            try
            {
                _dbConnection.ConnectDatabase();
                DtCurrency = _dbConnection.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return DtCurrency;
        }
        #endregion

        /// <summary>
        /// IPO Application,IPO Refund And Total Application Charge 
        /// Added By Md.Rashedul Hasan
        /// </summary>
        /// <returns></returns>
        public DataTable GetIPO_ChargeDef()
        {
            DataTable dt = new DataTable();
            string query = @"Declare @AppCharge decimal,@RefundCharge decimal,@TotalCharge decimal
                             Set @AppCharge=ISNULL((Select Ch_Min_Fee From SBP_Ch_Def_All Where Ch_Item='IPO App'),0)
                             Set @RefundCharge=ISNULL((Select Ch_Min_Fee From SBP_Ch_Def_All Where Ch_Item='IPO App Refund'),0)
                             Set @TotalCharge=ISNULL((Select Sum(Ch_Min_Fee) From SBP_Ch_Def_All Where Ch_Item IN ('IPO App Refund','IPO App')),0)
                             Select @AppCharge As AppCharge,@RefundCharge As RefundCharge,@TotalCharge As TotalCharge";
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
        /// Added BY Md.Rashedul Hasan
        /// </summary>
        /// <param name="Cust_Code"></param>
        /// <param name="sessionId"></param>
        /// <param name="Start"></param>
        /// <param name="voucher"></param>
        /// <param name="remark"></param>
        /// <param name="trans"></param>
        /// <param name="dep_with"></param>
        /// <returns></returns>

        public DataTable GetIPOAppliedCompany_ForDelete(string Cust_Code, string sessionId, DateTime? Start, string voucher, string remark, string trans, string dep_with)
        {
            DataTable dtCompany = new DataTable();
            string query = @"SBP_IPO_GETDeleteApproveTransaction";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@Cust_Code", SqlDbType.VarChar, Cust_Code);
                _dbConnection.AddParameter("@IPOCompanyID", SqlDbType.Int, sessionId);
                if (Start == null)
                    _dbConnection.AddParameter("@From_Date", SqlDbType.Date, DBNull.Value);
                else
                    _dbConnection.AddParameter("@From_Date", SqlDbType.Date, Start);
                _dbConnection.AddParameter("@Voucher", SqlDbType.VarChar, voucher);
                _dbConnection.AddParameter("@Remarks", SqlDbType.VarChar, remark);
                _dbConnection.AddParameter("@trans", SqlDbType.VarChar, trans);
                _dbConnection.AddParameter("@Dep_With", SqlDbType.VarChar, dep_with);
                dtCompany = _dbConnection.ExecuteProQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dtCompany;
        }

        //public DataTable GetIPOAppliedCompany_ForDelete(string Cust_Code, int sessionId, DateTime? Start,string voucher,string remark,string trans,string dep_with)
        //{
        //    DataTable dtCompany = new DataTable();
        //    string query = @"SBP_IPO_GETDeleteApproveTransaction";
        //    try
        //    {
        //        _dbConnection.ConnectDatabase();
        //        _dbConnection.ActiveStoredProcedure();
        //        _dbConnection.AddParameter("@Cust_Code", SqlDbType.VarChar, Cust_Code);
        //        _dbConnection.AddParameter("@IPOCompanyID", SqlDbType.Int, sessionId);
        //        if(Start==null)
        //            _dbConnection.AddParameter("@From_Date",SqlDbType.Date, DBNull.Value);
        //            else
        //        _dbConnection.AddParameter("@From_Date", SqlDbType.Date, Start);
        //        _dbConnection.AddParameter("@Voucher", SqlDbType.VarChar, voucher);
        //        _dbConnection.AddParameter("@Remarks", SqlDbType.VarChar, remark);
        //        _dbConnection.AddParameter("@trans", SqlDbType.VarChar, trans);
        //        _dbConnection.AddParameter("@Dep_With", SqlDbType.VarChar, dep_with);
        //        dtCompany = _dbConnection.ExecuteProQuery(query);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        _dbConnection.CloseDatabase();
        //    }
        //    return dtCompany;
        //}



        //Added BY Md.Rashedul Hasan
        /// <summary>
        /// Same Voucher OR Remarks Or Amount Checking 
        /// </summary>
        /// <param name="TransType"></param>
        /// <param name="cust_code"></param>
        /// <param name="voucher"></param>
        /// <param name="remarks"></param>
        /// <returns></returns>
        public DataTable GetIPOSameVoucherORRemarks(string TransType, string cust_code, string voucher, string remarks)
        {
            string query = @"SBP_IPODuplicateDeposit";
            DataTable dt = new DataTable();
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@Transaction_Name", SqlDbType.VarChar, TransType);
                _dbConnection.AddParameter("@Voucher", SqlDbType.VarChar, voucher);
                _dbConnection.AddParameter("@Remarks", SqlDbType.VarChar, remarks);
                _dbConnection.AddParameter("@cust_Code", SqlDbType.VarChar, cust_code);
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

        /// <summary>
        /// Added By Md.rashedul Hasan
        /// </summary>
        /// <param name="custcode"></param>
        /// <returns></returns>
	    public DataTable GetIPOAccountInformation(string custcode)
        {
            DataTable dt = new DataTable();
            string query = @"SBP_IPOBalanceCheque";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@Cust_Code", SqlDbType.VarChar, custcode);
                dt = _dbConnection.ExecuteProQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this._dbConnection.CloseDatabase();
            }
            return dt;
        }

   
        public DataTable GetApplicationType()
        {
            DataTable dataTable;
            dataTable = null;
            string queryString = "";
            queryString = @"SELECT [ID] AS ID
                            ,[ApplicationType_Name]  AS ApplicationType_Name    
                            FROM [SBP_IPO_Application_Type]
                            ORDER BY [ApplicationType_Name]";
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
        /// Display member "Company short code and value member Session ID"
        /// Added By Md.Rashedul Hasan
        /// </summary>
        /// <returns></returns>
        public DataTable GetCompanyShortCodeAndSessionID()
        {
            DataTable dt = null;
            string query = @"Select s.ID As ID,c.Company_Short_Code As Code 
                        From SBP_IPO_Session As s
                        JOin SBP_IPO_Company_Info As c
                        on s.IPO_Company_ID=c.ID
                        Where s.IPOSession_Name <>''
                        order by c.ID desc";
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
                _dbConnection.ConnectDatabase();
            }
            return dt;
        }

        /// <summary>
        /// Get Application Eligigble Company List. Added By MD.Rashedul Hasan
        /// </summary>
        /// <returns></returns>
        public DataTable GetCompanyList_EligibleFor_Application()
        {
            DataTable DtElibibleCompany = new DataTable();
            string Query = @"Select
                            Com.ID As 'Company_Id'
                            ,Ses.ID As 'Session_ID'
                            ,Com.Company_Name As 'Company_Name'
                            ,Com.Company_Short_Code As 'Company_Short_Code'
                            ,Ses.IPOSession_Name As 'IPOSession_Name'
                            ,Ses.TotalAmount As 'TotalAmount'
                            ,Ses.No_Of_Share As 'No_Of_Share'
                            ,Ses.Amount As 'Each_Share_Amount'
                            ,Ses.Premium As 'Premium'
                            ,Ses.Total_Share_Value As 'Total_Share_Value'
                            From SBP_IPO_Company_Info As Com
                            Join SBP_IPO_Session As Ses
                            ON Com.ID=Ses.IPO_Company_ID
                            Where Ses.Status=0
                            ";
            try
            {
                _dbConnection.ConnectDatabase();
                DtElibibleCompany = _dbConnection.ExecuteQuery(Query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return DtElibibleCompany;
        }

        public DataTable GetCompanyList()
        {
            DataTable dataTable;
            dataTable = null;
            string queryString = "";
            queryString = @"SELECT	[ID] AS ID
		                    ,[Company_Name] AS Company_Name
                            FROM [SBP_IPO_Company_Info]
                            ORDER BY [Company_Name] ";
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

        public DataTable GetSessionList()
        {
            DataTable dt = new DataTable();
            string Query = @"select ID,Session_Status from SBP_IPO_Session_Status order by ID desc";
            try
            {
                _dbConnection.ConnectDatabase();
               dt= _dbConnection.ExecuteQuery(Query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                
            }
            return dt;
        }

        /// <summary>
        /// UpDate By Md.Rashedul Hasan On 11 May 2014
        /// Added Company_Chairman_name And Designation
        /// </summary>
        /// <returns></returns>
        public DataTable GetIPOCompanyALL()
        {
            DataTable dataTable;
            dataTable = null;
            string queryString = "";
            queryString = @"SELECT [ID]
                          ,[Company_Chairman_name]
                          ,[Designation]
                          ,[Company_Short_Code]
                          ,[Company_Name]
                          ,[Company_Address]
                          ,[Bank_ID]
                          ,[Bank_Name]
                          ,[Branch_ID]
                          ,[Branch_Name]
                          ,[BankAcc_No]
                          ,[RoutingNo]
                          ,[Company_Logo]
                          FROM [SBP_Database].[dbo].[SBP_IPO_Company_Info] Order By ID Desc";
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
        /// Update Currency Name and Currency Amount 
        /// BY Md.Rashedul Hasan
        /// </summary>
        /// <returns></returns>
        public DataTable GetIPOSessionALL()
        {
            DataTable dataTable;
            dataTable = null;
            string queryString = "";             
            queryString = @"SELECT   sess.[ID]
                            ,sess.[IPOSession_Name]
                            ,sess.[IPOSession_Desc]
                            ,sess.[IPO_Company_ID]
                            ,(
                            Select p.Company_Name
                            From SBP_IPO_Company_Info as p
                            Where p.ID=sess.[IPO_Company_ID]
                            ) AS [Company_Name]
                            ,sess.[Application_Type_ID]
                            ,(
                            Select p.ApplicationType_Name
                            From dbo.SBP_IPO_Application_Type as p
                            Where p.ID=sess.[Application_Type_ID]
                            ) AS [Application_Type]
                            ,sess.[Session_Date]
                            ,sess.[No_Of_Share]
                            ,sess.[Amount]
                            ,sess.[Premium]
                            ,sess.[TotalAmount]
                            ,(Select TOP 1 Currency_Name  From SBP_IPO_Session_NRB where IPO_Session_ID=sess.ID and Currency_Name='EUR')EUR
                            ,(Select TOP 1 Currency_Amount  From SBP_IPO_Session_NRB where IPO_Session_ID=sess.ID and Currency_Name='EUR')EUR_Amount
                            ,(Select TOP 1 Currency_Name  From SBP_IPO_Session_NRB where IPO_Session_ID=sess.ID and Currency_Name='GBP')GBP
                            ,(Select TOP 1 Currency_Amount  From SBP_IPO_Session_NRB where IPO_Session_ID=sess.ID and Currency_Name='GBP')GBP_Amount
                            ,(Select TOP 1 Currency_Name  From SBP_IPO_Session_NRB where IPO_Session_ID=sess.ID and Currency_Name='USD')GBP
                            ,(Select TOP 1 Currency_Amount  From SBP_IPO_Session_NRB where IPO_Session_ID=sess.ID and Currency_Name='USD')GBP_Amount
                            ,sess.Status as 'Status Id'
                            ,st.Session_Status as 'Status Name'                       
                            FROM [SBP_IPO_Session] as sess
                            inner join SBP_IPO_Session_Status as st                    
                            on st.ID=sess.Status                    
                            where sess.[Status]=0 OR sess.[Status]=4 OR sess.[Status]=6 
                            Order By sess.ID desc";
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

//        public DataTable GetIPOSessionALL()
//        {
//            DataTable dataTable;
//            dataTable = null;
//            string queryString = "";
//            queryString = @"SELECT sess.[ID]
//                          ,sess.[IPOSession_Name]
//                          ,sess.[IPOSession_Desc]
//                          ,sess.[IPO_Company_ID]
//                          ,(
//                            Select p.Company_Name
//                            From SBP_IPO_Company_Info as p
//                            Where p.ID=sess.[IPO_Company_ID]
//                          ) AS [Company_Name]
//                          ,sess.[Application_Type_ID]
//                          ,(
//                            Select p.ApplicationType_Name
//                            From dbo.SBP_IPO_Application_Type as p
//                            Where p.ID=sess.[Application_Type_ID]
//                          ) AS [Application_Type]
//                          ,sess.[Session_Date]
//                          ,sess.[No_Of_Share]
//                          ,sess.[Amount]
//                           ,sess.[Premium]
//                          ,sess.[TotalAmount]
//                          ,sess.Status as 'Status Id'
//                          ,st.Session_Status as 'Status Name'                       
//                        FROM [SBP_IPO_Session] as sess
//                    inner join SBP_IPO_Session_Status as st
//                    on st.ID=sess.Status
//                     where sess.[Status]=0 OR sess.[Status]=4";
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

        public string GetCompanyShortCodeBySessionID(int ID)
        {
            DataTable dataTable;
            dataTable = null;
            string queryString = "";
            queryString = @"SELECT 
                        ISNULL(comp.Company_Short_Code,'') AS Comp_Short_Code
                        FROM
                        dbo.SBP_IPO_Company_Info as comp
                        JOIN
                        dbo.SBP_IPO_Session as sess
                        ON
                        comp.ID=sess.IPO_Company_ID
                        WHERE
                        sess.ID=" + Convert.ToString(ID) + "";
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
            string short_Code = "";
            if (dataTable.Rows.Count > 0)
            {
                short_Code = dataTable.Rows[0][0].ToString();
            }
            return short_Code;
        } 

        public DataTable GetIPOSessionInfo_BySessionId(int SessionID)
        {
            DataTable dataTable;
            dataTable = null;
            string queryString = "";
            queryString = @"SELECT [ID]
                          ,[IPOSession_Name]
                          ,[IPOSession_Desc]
                          ,[IPO_Company_ID]
                          ,(
		                    Select p.Company_Name
		                    From SBP_IPO_Company_Info as p
		                    Where p.ID=[SBP_IPO_Session].[IPO_Company_ID]
                          ) AS [Company_Name]
                          ,[Application_Type_ID]
                          ,(
		                    Select p.ApplicationType_Name
		                    From dbo.SBP_IPO_Application_Type as p
		                    Where p.ID=[SBP_IPO_Session].[Application_Type_ID]
                          ) AS [Application_Type]
                          ,[Session_Date]
                          ,[No_Of_Share]
                          ,[Amount]
                          ,[TotalAmount]
                          ,[Premium]
                          ,[IsMaturedForTrade]                        
                    FROM [SBP_Database].[dbo].[SBP_IPO_Session]
                    WHERE ID="+SessionID+@"
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

        public string GetIPOSessionName_CompanyName_BySessionID(int ID)
        {
            string result="";
            DataTable dataTable;
            dataTable = null;
            string queryString = "";
            queryString = @"SELECT
                        IPOSession_Name  
                        ,(
		                    Select p.Company_Name
		                    From SBP_IPO_Company_Info as p
		                    Where p.ID=[SBP_IPO_Session].[IPO_Company_ID]
                          ) AS [Company_Name]                                                
                    FROM [SBP_Database].[dbo].[SBP_IPO_Session]
                    WHERE ID=" + ID+" ";
            try
            {
                _dbConnection.ConnectDatabase();
                dataTable = _dbConnection.ExecuteQuery(queryString);
                if (dataTable.Rows.Count ==1)
                {
                    result = Convert.ToString(dataTable.Rows[0]["IPOSession_Name"]);
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
            return result;
        }

        public DataTable GetIPOMoneyTransType()
        {
            DataTable dataTable;
            dataTable = null;          
            
            string queryString = "";
            queryString = @"SELECT ID AS ID
                            ,MoneyTransType_Name AS Name
                            --,[MoneyTransType_Desc]
                            FROM [SBP_Database].[dbo].[SBP_IPO_MoneyTrans_Type]                            
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

        public DataTable GetCustoemrDetailsForPaymentEntry(string CustCode)
        {
            DataTable dataTable;
            dataTable = null;
            string queryString = "";
            queryString = @"DECLARE @Cust_Code Varchar(100)
                            SET @Cust_Code='"+CustCode+ @"'

                            Select 
                            cust.Cust_Code
                            ,P.Cust_Name
                            ,(
                                Select t.[BO_Status]
                                From SBP_BO_Status as t
                                Where t.BO_Status_ID=cust.BO_Status_ID
                            ) AS Status
                            ,cust.BO_ID as BOID
                            ,ISNULL((
                                SELECT SUM(Deposit)-SUM(Withdraw) AS Balance
	                            FROM (
			                            SELECT [Cust_Code]
				                              ,( CASE WHEN [Deposit_Withdraw]='Deposit' THEN [Amount] ELSE 0.00 END ) AS Deposit
				                              ,( CASE WHEN [Deposit_Withdraw]='Withdraw' THEN [Amount] ELSE 0.00 END ) AS Withdraw
			                            FROM [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction]
			                            WHERE [Approval_Status]=1
	                            ) AS T
	                            WHERE T.Cust_Code=cust.Cust_Code
	                            GROUP BY T.Cust_Code
                            ),0) AS IPO_Mone_Bal
                            ,0.00 AS Distributed_Amount
                            ,ISNULL(bnk.Account_No,'') AS BankAccNo
                            ,ISNULL(bnk.Routing_No,'') AS RoutingNo
                            ,ISNULL(bnk.Bank_ID,0) AS BankID
                            ,ISNULL(bnk.Bank_Name,'') AS BankName
                            ,ISNULL(bnk.Branch_ID,0) AS BranchID
                            ,ISNULL(bnk.Branch_Name,'') AS BranchName
                            From SBP_Customers as cust
                            Left Outer Join
                            SBP_Cust_Bank_Info as bnk
                            ON
                            bnk.Cust_Code=cust.Cust_Code
                            Join SBP_Cust_Personal_Info As P
                            ON P.Cust_Code=cust.Cust_Code
                            Where cust.Cust_Code=@Cust_Code

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
        
        public DataTable GetAvailableSession(string CustCode)
        {
            DataTable dataTable;
            dataTable = null;
            string queryString = "";
            queryString = @"SELECT [ID]
                            --,[IPOSession_Name]
                         -- ,[IPOSession_Desc]
                          ,(
			                    Select t.Company_Name
			                    From SBP_IPO_Company_Info as t
			                    Where t.ID=sess.[IPO_Company_ID]
                          ) AS Company_Name
                          --,[Application_Type_ID]
                         -- ,[Session_Date]
                          ,[No_Of_Share]
                         -- ,[Amount]
                          ,[TotalAmount]
                          ,[Premium]
                          --,[IsMaturedForTrade]
                          --,[Status]
                    FROM [SBP_Database].[dbo].[SBP_IPO_Session] as sess
                    WHERE [Status]=0
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

        public DataTable GetAvailableSession(double NextPossibleBalance)
        {
            DataTable dataTable;
            dataTable = null;
            string queryString = "";
            queryString = @"
                        Declare @Money money =ISNULL((Select SUM(ch_Min_Fee) from SBP_Ch_Def_All Where Ch_ID IN (14,15)),0)						 
						
						SELECT [ID]
                           -- ,[IPOSession_Name]
                         -- ,[IPOSession_Desc]
                          ,(
                                Select t.Company_Name
                                From SBP_IPO_Company_Info as t
                                Where t.ID=sess.[IPO_Company_ID]
                          ) AS Company_Name
                        --  ,[Application_Type_ID]
                        --  ,[Session_Date]
                          ,[No_Of_Share]
                         -- ,[Amount]
                          ,[TotalAmount] 
                          ,@Money As Charge
                          ,[Premium]
                        --  ,[IsMaturedForTrade]
                        --  ,[Status]
                        FROM [SBP_Database].[dbo].[SBP_IPO_Session] as sess
                        WHERE [Status]=0 AND ([TotalAmount]+@Money)<=" + NextPossibleBalance + @"
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

        public DataTable GetRefundMethod()
        {
            DataTable dataTable;
            dataTable = null;
            string queryString = "";
            queryString = @"SELECT [ID] AS ID
                                  ,[Method_Name] AS Name
                                   ,[Method_Desc] as 'Desc'
                            FROM [SBP_Database].[dbo].[SBP_IPO_MoneyRefund_Method]
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

        public DataTable GetSessionIdByName()
        {
            DataTable dt = new DataTable();
            string query = @"select ID,IPOSession_Name from SBP_IPO_Session";
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

        #region ReportMethod

        public DataTable GetTotalApplicationList(string sessionId)
        {
            DataTable dt = new DataTable();
            string query = @"RptIPOTotalApplicationList";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@seessionId", SqlDbType.VarChar, sessionId);
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

        public DataTable GetTotalSubscriptionStatus(int SessionId)
        {
            DataTable dt = new DataTable();
            string Query = @"RptIPOTotalSubscriptionStatus";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ClearParameters();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@SessId", SqlDbType.Int, SessionId);
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

        public DataTable GetCategoryWiseReportToIssuer(string sessionid)
        {
            DataTable dt = new DataTable();
            string query = @"RptIPOCategoryWiseReportToIssuer";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@seessionId", SqlDbType.VarChar, sessionid);
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

//        public DataTable GetExportForIssuer(string code)
//        {
//            DataTable dt = new DataTable();
//            string query = @"
//                             declare @CoBoId varchar(30)    
//                            set @CoBoId=(select [BO_ID] from [SBP_Broker_Info])   
//                             select 
//                            '122' as 'Trec Code'
//                             ,'23500' as 'DPID'
//                             ,basicInfo.cust_code as 'Customer Id'
//                            ,extedInfo.Cust_Name as 'Name Of applicant'
//                            ,(@CoBoId+basicInfo.Bo_ID) as 'BO Id no'
//                            ,(case when additional.IsAffected_Account=1 then 'ASI' else (case when additional.Recidency='Resident' then 'RB' else 'NRB' end) end) as 'Applicant category'
//                            ,basicInfo.No_Of_Share*basicInfo.Lot_No as 'Number of share'
//                            ,sess.TotalAmount*basicInfo.Lot_No as 'Applied Amount'
//                            ,com.Company_short_code as 'Security name'
//                            from SBP_IPO_Application_BasicInfo as basicInfo
//                            join SBP_IPO_Application_ExtendedInfo as extedInfo
//                            on extedInfo.BasicInfo_ID=basicInfo.ID
//                            join dbo.SBP_IPO_Session as sess	                         
//                            on sess.Id=basicInfo.IPOSession_ID
//                            join SBP_IPO_Company_Info as com
//                            on com.ID=sess.IPO_Company_ID
//                            left join SBP_Cust_Additional_Info as additional
//                            on additional.cust_Code =basicInfo.Cust_code
//
//                            where sess.ID='" + code + @"'
//                            AND basicInfo.Application_Satus=1 ";
//            try
//            {
//                _dbConnection.ConnectDatabase();
//                dt=_dbConnection.ExecuteQuery(query);
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//            finally
//            {
//                _dbConnection.CloseDatabase();
//            }
//            return dt;
//        }

        public DataTable GetExportForIssuer(string SessionId)
        {
            DataTable dt = new DataTable();
            string query = @"
                             declare @CoBoId varchar(30)    
                            set @CoBoId=(select [BO_ID] from [SBP_Broker_Info])   
                             select  Distinct
                            '122' as 'Trec Code'
                             ,'23500' as 'DPID'
                             ,basicInfo.cust_code as 'Customer Id'
                            ,extedInfo.Cust_Name as 'Name Of applicant'
                            ,(@CoBoId+basicInfo.Bo_ID) as 'BO Id no'
                            ,(
								case when additional.IsAffected_Account=1 then 'ASI' 
								else 
								(	case 
									when additional.Recidency='Resident' then 'RB' else 'NRB' 
									end
								) 
								end
							) as 'Applicant category'
                            ,basicInfo.No_Of_Share*basicInfo.Lot_No as 'Number of share'
                            ,(
                            Case 
								When additional.Recidency='Resident' Then 'BDT'								 
									Else ''
										END
								) As Currency
                            ,
                            Convert(decimal(18,2),
                                            ( 
								                Case When additional.Recidency='Resident' Then sess.TotalAmount*basicInfo.Lot_No
									            Else 0.0								
				                				END
                                            )
                            )as 'Applied Amount'
                             
                            ,com.Company_short_code as 'Security name'
                            from SBP_IPO_Application_BasicInfo as basicInfo
                            join SBP_IPO_Application_ExtendedInfo as extedInfo
                            on extedInfo.BasicInfo_ID=basicInfo.ID
                            join dbo.SBP_IPO_Session as sess	                         
                            on sess.Id=basicInfo.IPOSession_ID
                            join SBP_IPO_Company_Info as com
                            on com.ID=sess.IPO_Company_ID
                            left join SBP_Cust_Additional_Info as additional
                            on additional.cust_Code =basicInfo.Cust_code     
                            where sess.ID='" + SessionId + @"'
                            AND basicInfo.Application_Satus=1 
                            And extedInfo.Applicant_Category IN ('RB','ASI')
                            UNION All
                            select distinct
                            '122' as 'Trec Code'
                             ,'23500' as 'DPID'
                             ,basicInfo.cust_code as 'Customer Id'
                            ,extedInfo.Cust_Name as 'Name Of applicant'
                            ,(@CoBoId+basicInfo.Bo_ID) as 'BO Id no'
                            ,(
								case when additional.IsAffected_Account=1 then 'ASI' 
								else 
								(	case 
									when additional.Recidency='Resident' then 'RB' else 'NRB' 
									end
								) 
								end
							) as 'Applicant category'
                            ,basicInfo.No_Of_Share*basicInfo.Lot_No as 'Number of share'
                            ,(
                            Case 
								--When additional.Recidency='Resident' Then 'BDT'								 
								When additional.Recidency='Non Resident'
										Then 
											(
												Case 
													When D.Currency_Name='EUR' THEN 'EUR'
													When D.Currency_Name='GBP'  THEN 'GBP'
													When D.Currency_Name='USD'  THEN 'USD'
												END
											)END
									 
								) As Currency
                            ,
                            Convert(decimal(18,2),
                                                    ( 
								                        Case 
									                        --When additional.Recidency='Resident' Then sess.TotalAmount*basicInfo.Lot_No
									                        --Else(Case 
									                        When additional.Recidency='Non Resident' 
										                        THEN
										                        (
											                        Case 
												                        When D.Currency_Name='EUR' Then Curr_Amount.EUR_Amount*basicInfo.Lot_No
												                        When D.Currency_Name='GBP' Then Curr_Amount.GBP_Amount*basicInfo.Lot_No
												                        When D.Currency_Name='USD' Then Curr_Amount.USD_Amount*basicInfo.Lot_No
											                        END
										                        ) 
										                        --END)
								                        END
                                                    )
                            )as 'Applied Amount'
                             
                            ,com.Company_short_code as 'Security name'
                            from SBP_IPO_Application_BasicInfo as basicInfo
                            join SBP_IPO_Application_ExtendedInfo as extedInfo
                            on extedInfo.BasicInfo_ID=basicInfo.ID
                            join dbo.SBP_IPO_Session as sess	                         
                            on sess.Id=basicInfo.IPOSession_ID
                            join SBP_IPO_Company_Info as com
                            on com.ID=sess.IPO_Company_ID
                            left join SBP_Cust_Additional_Info as additional
                            on additional.cust_Code =basicInfo.Cust_code                             
							JOin SBP_IPO_NRB_Customer_DraftInformation as D
							on basicInfo.IPOSession_ID=D.Intended_IPOSession_ID
							And D.Cust_Code=basicInfo.Cust_Code
							Join
							(
								Select 
								 IPO_Session_ID
								 ,Max(case When Currency_Name='EUR' Then 'EUR' Else '' End)As EUR
								 ,Sum(case When Currency_Name='EUR' Then Currency_Amount Else 0.00 End)As EUR_Amount
								 ,Max(case When Currency_Name='GBP' Then 'GBP' Else '' End)As GBP
								 ,Sum(case When Currency_Name='GBP' Then Currency_Amount Else 0.00 End)As GBP_Amount
								 ,Max(case When Currency_Name='USD' Then 'USD' Else '' End)As USD
								 ,Sum(case When Currency_Name='USD' Then Currency_Amount Else 0.00 End)As USD_Amount
								From SBP_IPO_Session_NRB
								Where IPO_Session_ID='" + SessionId + @"'
								Group by IPO_Session_ID
							)As Curr_Amount
							On Curr_Amount.IPO_Session_ID=basicInfo.IPOSession_ID
                            where sess.ID='" + SessionId + @"'
                            And D.Draft_Status=2
                            AND basicInfo.Application_Satus=1 
                            And extedInfo.Applicant_Category='NRB'
UNION ALL
                        select  Distinct
                            '122' as 'Trec Code'
                             ,'23500' as 'DPID'
                             ,basicInfo.cust_code as 'Customer Id'
                            ,extedInfo.Cust_Name as 'Name Of applicant'
                            ,(@CoBoId+basicInfo.Bo_ID) as 'BO Id no'
                            ,(
								case when additional.IsAffected_Account=1 then 'ASI' 
								else 
								(	case 
									when additional.Recidency='Resident' then 'DLR' else 'NRB' 
									end
								) 
								end
							) as 'Applicant category'
                            ,basicInfo.No_Of_Share*basicInfo.Lot_No as 'Number of share'
                            ,(
                            Case 
								When additional.Recidency='Resident' Then 'BDT'								 
									Else ''
										END
								) As Currency
                            ,
                            Convert(decimal(18,2),
                                            ( 
								                Case When additional.Recidency='Resident' Then sess.TotalAmount*basicInfo.Lot_No
									            Else 0.0								
				                				END
                                            )
                            )as 'Applied Amount'
                             
                            ,com.Company_short_code as 'Security name'
                            from [DEALERDB].dbo.SBP_IPO_Application_BasicInfo as basicInfo
                            join [DEALERDB].dbo.SBP_IPO_Application_ExtendedInfo as extedInfo
                            on extedInfo.BasicInfo_ID=basicInfo.ID
                            join [DEALERDB].dbo.SBP_IPO_Session as sess	                         
                            on sess.Id=basicInfo.IPOSession_ID
                            join [DEALERDB].dbo.SBP_IPO_Company_Info as com
                            on com.ID=sess.IPO_Company_ID
                            left join [DEALERDB].dbo.SBP_Cust_Additional_Info as additional
                            on additional.cust_Code =basicInfo.Cust_code     
                            where sess.ID='" + SessionId + @"'
                            AND basicInfo.Application_Satus=1 
                            And extedInfo.Applicant_Category IN ('DLR','ASI')
                            UNION All
                            select distinct
                            '122' as 'Trec Code'
                             ,'23500' as 'DPID'
                             ,basicInfo.cust_code as 'Customer Id'
                            ,extedInfo.Cust_Name as 'Name Of applicant'
                            ,(@CoBoId+basicInfo.Bo_ID) as 'BO Id no'
                            ,(
								case when additional.IsAffected_Account=1 then 'ASI' 
								else 
								(	case 
									when additional.Recidency='Resident' then 'RB' else 'NRB' 
									end
								) 
								end
							) as 'Applicant category'
                            ,basicInfo.No_Of_Share*basicInfo.Lot_No as 'Number of share'
                            ,(
                            Case 
								--When additional.Recidency='Resident' Then 'BDT'								 
								When additional.Recidency='Non Resident'
										Then 
											(
												Case 
													When D.Currency_Name='EUR' THEN 'EUR'
													When D.Currency_Name='GBP'  THEN 'GBP'
													When D.Currency_Name='USD'  THEN 'USD'
												END
											)END
									 
								) As Currency
                            ,
                            Convert(decimal(18,2),
                                                    ( 
								                        Case 
									                        --When additional.Recidency='Resident' Then sess.TotalAmount*basicInfo.Lot_No
									                        --Else(Case 
									                        When additional.Recidency='Non Resident' 
										                        THEN
										                        (
											                        Case 
												                        When D.Currency_Name='EUR' Then Curr_Amount.EUR_Amount*basicInfo.Lot_No
												                        When D.Currency_Name='GBP' Then Curr_Amount.GBP_Amount*basicInfo.Lot_No
												                        When D.Currency_Name='USD' Then Curr_Amount.USD_Amount*basicInfo.Lot_No
											                        END
										                        ) 
										                        --END)
								                        END
                                                    )
                            )as 'Applied Amount'
                             
                            ,com.Company_short_code as 'Security name'
                            from [DEALERDB].dbo.SBP_IPO_Application_BasicInfo as basicInfo
                            join [DEALERDB].dbo.SBP_IPO_Application_ExtendedInfo as extedInfo
                            on extedInfo.BasicInfo_ID=basicInfo.ID
                            join [DEALERDB].dbo.SBP_IPO_Session as sess	                         
                            on sess.Id=basicInfo.IPOSession_ID
                            join [DEALERDB].dbo.SBP_IPO_Company_Info as com
                            on com.ID=sess.IPO_Company_ID
                            left join [DEALERDB].dbo.SBP_Cust_Additional_Info as additional
                            on additional.cust_Code =basicInfo.Cust_code                             
							JOin [DEALERDB].dbo.SBP_IPO_NRB_Customer_DraftInformation as D
							on basicInfo.IPOSession_ID=D.Intended_IPOSession_ID
							And D.Cust_Code=basicInfo.Cust_Code
							Join
							(
								Select 
								 IPO_Session_ID
								 ,Max(case When Currency_Name='EUR' Then 'EUR' Else '' End)As EUR
								 ,Sum(case When Currency_Name='EUR' Then Currency_Amount Else 0.00 End)As EUR_Amount
								 ,Max(case When Currency_Name='GBP' Then 'GBP' Else '' End)As GBP
								 ,Sum(case When Currency_Name='GBP' Then Currency_Amount Else 0.00 End)As GBP_Amount
								 ,Max(case When Currency_Name='USD' Then 'USD' Else '' End)As USD
								 ,Sum(case When Currency_Name='USD' Then Currency_Amount Else 0.00 End)As USD_Amount
								From SBP_IPO_Session_NRB
								Where IPO_Session_ID='" + SessionId + @"'
								Group by IPO_Session_ID
							)As Curr_Amount
							On Curr_Amount.IPO_Session_ID=basicInfo.IPOSession_ID
                            where sess.ID='" + SessionId + @"'
                            And D.Draft_Status=2
                            AND basicInfo.Application_Satus=1 
                            And extedInfo.Applicant_Category='NRB'";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.TimeoutPeriod = 900;
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

        //Replace to IPO PRocess Bal
        /// <summary>
        /// Change Eecute query to procedure 
        /// Due to Execute query given time out error
        /// By Rahsedul hasan ON 11 Aug 2015
        /// </summary>
        /// <param name="SessionID"></param>
        /// <returns></returns>
        public DataTable GetEligibleCustomer(int SessionID)
        {
            DataTable dt = new DataTable();
            string query_s = @"SBP_IPOSingle_Application_Loading";
            string query = @"DECLARE @SessionID INT
                            SET @SessionID=" + SessionID + @"
                            DECLARE @TotaRequiredlMoney MONEY
                            SET @TotaRequiredlMoney=( 
                                                        SELECT ISNULL(
                                                            (SELECT [TotalAmount] 
                                                               --[TotalAmount]+[Premium]
                                                            FROM [SBP_Database].[dbo].[SBP_IPO_Session]
                                                            WHERE [ID]=@SessionID)
                                                        ,0)
                            )
                            SELECT 
                            ipoAcc.Cust_Code as Cust_Code
                            ,(
                                Select t.Cust_Name 
                                From SBP_Cust_Personal_Info as t 
                                Where t.Cust_Code=ipoAcc.Cust_Code
                            ) AS Cust_Name
                            ,SUM(ipoAcc.Deposit-ipoAcc.Withdraw) as Balance
                            ,@TotaRequiredlMoney AS ApplyMoney
                            ,info.Bank_ID as 'Bank id'
                            ,info.Bank_Name as 'Bank_Name'
                            ,info.Branch_ID as 'Branch Id'
                            ,info.Branch_Name as 'Branch_Name'
                            ,info.Routing_No as 'Routing_No'
                            ,ipoAcc.Serial_No aS 'Serial_No'
                            ,ipoAcc.Remarks As 'Remarks'
                            ,'' AS ChannelType
                            ,0  AS ChannelID
                            FROM(
                                    Select mt.Cust_Code
                                    ,( CASE WHEN mt.Deposit_Withdraw='Deposit' THEN mt.Amount ELSE 0.00 END ) AS Deposit
                                    ,( CASE WHEN mt.Deposit_Withdraw='Withdraw' THEN mt.Amount ELSE 0.00 END ) AS Withdraw
                                    ,mt.Intended_IPOSession_ID
                                    ,'' AS Serial_No
                                    ,'' AS Remarks
                                    From dbo.SBP_IPO_Customer_Broker_MoneyTransaction as mt
                                    Where 
                                    --( mt.Intended_IPOSession_ID=@SessionID OR isnull(mt.Intended_IPOSession_ID,0)=0)   
                                    --AND
                                    mt.Cust_Code NOT IN (
                                                    Select App.Cust_Code 
                                                    From SBP_IPO_Application_BasicInfo as App
                                                    Where App.IPOSession_ID=@SessionID
                                    )
                                    AND
                                    mt.Approval_Status=1
                                    
                            		
                            		
                            ) AS ipoAcc
                            left join SBP_Cust_Bank_Info as info
                            on info.Cust_Code=ipoacc.cust_code
                             
                            GROUP BY ipoAcc.Cust_Code,info.Bank_Id,info.Bank_Name,info.branch_id,info.branch_Name,info.routing_no
                            ,ipoAcc.Serial_No,ipoAcc.Remarks
                            HAVING SUM(ipoAcc.Deposit-ipoAcc.Withdraw)>=@TotaRequiredlMoney"

                           ;
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@SessionID", SqlDbType.Int, SessionID);
                dt = _dbConnection.ExecuteProQuery(query_s);
                //dt = _dbConnection.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

//        public DataTable GetEligibleCustomer(int SessionID)
//        {
//            DataTable dt = new DataTable();
//            string query = @"DECLARE @SessionID INT
//                            SET @SessionID="+SessionID+ @"
//                            DECLARE @TotaRequiredlMoney MONEY
//                            SET @TotaRequiredlMoney=( 
//                                                        SELECT ISNULL(
//                                                            (SELECT [TotalAmount] 
//                                                               --[TotalAmount]+[Premium]
//                                                            FROM [SBP_Database].[dbo].[SBP_IPO_Session]
//                                                            WHERE [ID]=@SessionID)
//                                                        ,0)
//                            )
//                            SELECT 
//                            ipoAcc.Cust_Code as Cust_Code
//                            ,(
//                                Select t.Cust_Name 
//                                From SBP_Cust_Personal_Info as t 
//                                Where t.Cust_Code=ipoAcc.Cust_Code
//                            ) AS Cust_Name
//                            ,SUM(ipoAcc.Deposit-ipoAcc.Withdraw) as Balance
//                            ,@TotaRequiredlMoney AS ApplyMoney
//                            ,info.Bank_ID as 'Bank id'
//                            ,info.Bank_Name as 'Bank_Name'
//                            ,info.Branch_ID as 'Branch Id'
//                            ,info.Branch_Name as 'Branch_Name'
//                            ,info.Routing_No as 'Routing_NO'
//                            ,ipoAcc.Serial_No aS 'Serial_No'
//                            ,ipoAcc.Remarks As 'Remarks'
//                            ,'' AS ChannelType
//                            ,0  AS ChannelID
//                            FROM(
//                                    Select mt.Cust_Code
//                                    ,( CASE WHEN mt.Deposit_Withdraw='Deposit' THEN mt.Amount ELSE 0.00 END ) AS Deposit
//                                    ,( CASE WHEN mt.Deposit_Withdraw='Withdraw' THEN mt.Amount ELSE 0.00 END ) AS Withdraw
//                                    ,mt.Intended_IPOSession_ID
//                                    ,'' AS Serial_No
//                                    ,'' AS Remarks
//                                    From dbo.SBP_IPO_Customer_Broker_MoneyTransaction as mt
//                                    Where 
//                                    --( mt.Intended_IPOSession_ID=@SessionID OR isnull(mt.Intended_IPOSession_ID,0)=0)   
//                                    --AND
//                                    mt.Cust_Code NOT IN (
//                                                    Select App.Cust_Code 
//                                                    From SBP_IPO_Application_BasicInfo as App
//                                                    Where App.IPOSession_ID=@SessionID
//                                    )
//                                    AND
//                                    mt.Approval_Status=1
//                                    
//                            		
//                            		
//                            ) AS ipoAcc
//                            left join SBP_Cust_Bank_Info as info
//                            on info.Cust_Code=ipoacc.cust_code
//                             
//                            GROUP BY ipoAcc.Cust_Code,info.Bank_Id,info.Bank_Name,info.branch_id,info.branch_Name,info.routing_no
//                            ,ipoAcc.Serial_No,ipoAcc.Remarks
//                            HAVING SUM(ipoAcc.Deposit-ipoAcc.Withdraw)>=@TotaRequiredlMoney"

//                           ;
//            try
//            {
//                _dbConnection.ConnectDatabase();
//                dt = _dbConnection.ExecuteQuery(query);
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//            return dt;
//        }

        public DataTable GetEligibleCustomer(int SessionID, string Cust_Code)
        {
            DataTable dt = new DataTable();
            string query = @"DECLARE @SessionID INT,@code varchar(15)
	                        set @code='" + Cust_Code + @"'
                            SET @SessionID='" + SessionID + @"'
                            DECLARE @TotaRequiredlMoney MONEY
                            SET @TotaRequiredlMoney=( 
                                                        SELECT ISNULL(
                                                            (SELECT [TotalAmount] 
                                                            FROM [SBP_Database].[dbo].[SBP_IPO_Session]
                                                            WHERE [ID]=@SessionID)
                                                        ,0)
                            )
                            SELECT 
                            ipoAcc.Cust_Code as Cust_Code
                            ,(
                                Select t.Cust_Name 
                                From SBP_Cust_Personal_Info as t 
                                Where t.Cust_Code=ipoAcc.Cust_Code
                            ) AS Cust_Name
                            ,SUM(ipoAcc.Deposit-ipoAcc.Withdraw) as Balance
                            ,@TotaRequiredlMoney AS ApplyMoney
                            ,info.Bank_ID as 'Bank id'
                            ,info.Bank_Name as 'Bank_Name'
                            ,info.Branch_ID as 'Branch Id'
                            ,info.Branch_Name as 'Branch_Name'
                            ,info.Routing_No as 'Routing_No'
                            ,ipoAcc.Serial_No aS 'Serial_NO'
                            ,ipoAcc.Remarks As 'Remarks'
                            ,'' AS ChannelType
                            ,0 AS ChannelID
                            INTO #Temp
                            FROM(
                                    Select mt.Cust_Code
                                    ,( CASE WHEN mt.Deposit_Withdraw='Deposit' THEN mt.Amount ELSE 0.00 END ) AS Deposit
                                    ,( CASE WHEN mt.Deposit_Withdraw='Withdraw' THEN mt.Amount ELSE 0.00 END ) AS Withdraw
                                    ,mt.Intended_IPOSession_ID
                                    ,'' AS Serial_No
                                    ,'' AS Remarks
                                    From dbo.SBP_IPO_Customer_Broker_MoneyTransaction as mt
                                    Where 
                                    --( mt.Intended_IPOSession_ID=@SessionID OR isnull(mt.Intended_IPOSession_ID,0)=0)   
                                    --AND
                                    mt.Cust_Code NOT IN (
                                                    Select App.Cust_Code 
                                                    From SBP_IPO_Application_BasicInfo as App
                                                    Where App.IPOSession_ID=@SessionID
                                    )
                                    AND
                                   ( mt.Money_TransactionType_Name<>'" + Indication_IPOPaymentTransaction.Cheque + @"'AND mt.Approval_Status=1 )
                                   OR
                                   ( mt.Money_TransactionType_Name='" + Indication_IPOPaymentTransaction.Cheque + @"'AND mt.Approval_Status=1 AND Clearing_Status=1)
                                    and mt.Cust_Code=@code
                            		
                            		
                            ) AS ipoAcc
                            left join SBP_Cust_Bank_Info as info
                            on info.Cust_Code=ipoacc.cust_code
                            Where ipoAcc.Cust_Code=@code
                            GROUP BY ipoAcc.Cust_Code,info.Bank_Id,info.Bank_Name,info.branch_id,info.branch_Name,info.routing_no
                            ,ipoAcc.Serial_No,ipoAcc.Remarks                            
                            HAVING SUM(ipoAcc.Deposit-ipoAcc.Withdraw)>=@TotaRequiredlMoney
                            
                            IF EXISTS(Select App.Cust_Code From SBP_IPO_Application_BasicInfo as App Where App.IPOSession_ID=@SessionID AND App.Cust_Code=@Code)
                            Begin
		                        RAISERROR('Already Applied!!',16,1);
                            End
                            ELSE IF( (Select Count(*) From #Temp)=0)
                            Begin
		                        RAISERROR('Insufficient Balance!!',16,1)
                            End
                            
                            Select * From #Temp";
            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable GetCheckReturnInfo(string[] codes)
        {
            DataTable dt = new DataTable();
            string query_Codes = string.Join(",", codes);
            string query = @"
                                Select 
                                 trans.[ID]
                                ,trans.[Cust_Code]
                                ,trans.[Received_Date]
                                ,trans.[Money_TransactionType_ID]
                                ,trans.[Money_TransactionType_Name]
                                ,trans.[Deposit_Withdraw]
                                ,trans.[Amount] as 'IPO_Mone_Bal'
                                ,trans.[Voucher_No]
                                ,trans.[Trans_Reason]
                                ,trans.[Remarks]
                                ,trans.[Intended_IPOSession_ID]
                                ,trans.[Intended_IPOSession_Name]
                                ,trans.[Approval_Status]
                                ,trans.[Approval_Date]
                                ,trans.[Approval_By]
                                ,trans.[Rejected_Reason]
                                ,(
	                                Select t.Branch_Name 
	                                From dbo.SBP_Broker_Branch as t 
	                                Where t.Branch_ID=trans.[Entry_Branch_ID]
                                ) AS Entry_Branch_Name
                                ,dtls.[Bank_ID]
                                ,dtls.[BankName]
                                ,dtls.[Branch_ID]
                                ,dtls.[Branch_Name]
                                ,dtls.[Routing_No]
                                ,dtls.[Bank_Acc_No]
                                ,dtls.[Cheque_No]
                                ,dtls.[Cheque_Date]
                                From 
                                [dbo].[SBP_IPO_Customer_Broker_MoneyTransaction] AS trans
                                JOIN 
                                [dbo].[SBP_IPO_Customer_Broker_Transaction_Details] AS dtls
                                ON
                                trans.[ID]=dtls.[TransID]
                                Where   trans.[Voucher_No] IN (
                                                            Select t.Voucher_No
                                                            From SBP_IPO_Customer_Broker_MoneyTransaction as t
                                                            Where t.Cust_Code IN ("+query_Codes+ @")
                                )
                                AND dtls.[Routing_No] IN (
                                                            Select d.Routing_No
                                                            From [dbo].[SBP_IPO_Customer_Broker_MoneyTransaction] AS t
                                                            JOIN 
                                                            [dbo].[SBP_IPO_Customer_Broker_Transaction_Details] AS d
                                                            ON
                                                            t.[ID]=d.[TransID]
                                                            Where t.Cust_Code IN (" + query_Codes + @") AND t.Approval_Status=1 AND t.Clearing_Status=2
                                                            AND t.[Money_TransactionType_Name]='" + Indication_IPOPaymentTransaction.Cheque + @"'    
                                )
                                AND dtls.[Cheque_No] IN (
                                                            Select d.Cheque_No
                                                            From [dbo].[SBP_IPO_Customer_Broker_MoneyTransaction] AS t
                                                            JOIN 
                                                            [dbo].[SBP_IPO_Customer_Broker_Transaction_Details] AS d
                                                            ON
                                                            t.[ID]=d.[TransID]
                                                            Where t.Cust_Code IN (" + query_Codes + @") AND t.Approval_Status=1 AND t.Clearing_Status=2
                                                            AND t.[Money_TransactionType_Name]='" + Indication_IPOPaymentTransaction.Cheque + @"'    
                                )
                                AND dtls.[Cheque_Date] IN (
                                                            Select d.Cheque_Date
                                                            From [dbo].[SBP_IPO_Customer_Broker_MoneyTransaction] AS t
                                                            JOIN 
                                                            [dbo].[SBP_IPO_Customer_Broker_Transaction_Details] AS d
                                                            ON
                                                            t.[ID]=d.[TransID]
                                                            Where t.Cust_Code IN (" + query_Codes + @") AND t.Approval_Status=1 AND t.Clearing_Status=2
                                                            AND t.[Money_TransactionType_Name]='" + Indication_IPOPaymentTransaction.Cheque + @"'    
                                )
                                AND Approval_Status=1 AND [Clearing_Status]=2
                                AND trans.Deposit_Withdraw='"+Indication_PaymentMode.Deposit+@"'
                                
                                AND  trans.[Money_TransactionType_Name]='" + Indication_IPOPaymentTransaction.Cheque+@"'      
                                AND NOT EXISTS(
                                                    Select * From SBP_IPO_Customer_Broker_MoneyTransaction as t Where REPLACE(t.Trans_Reason,'"+Indication_IPOPaymentTransaction.Cheque_Return+@"_','')=trans.ID AND t.Deposit_Withdraw='"+Indication_PaymentMode.Withdraw+@"'
                                )
            ";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
               dt = _dbConnection.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public void IpoAppliccationAndchequeReject(string code)
        {
            DataTable dt = new DataTable();
            string query = @"SBP_IPOAppliccationAndchequeReject";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@trans_Id", SqlDbType.Int, Convert.ToInt32(code));
                _dbConnection.ExecuteProQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateReturnInfo(string code)
        {
            DataTable dt = new DataTable();
            string query = @"SBP_IPOUpdateIpoCheckReturnInfo";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@transId", SqlDbType.VarChar, code);
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

        public DataTable GetIPOPaymentEntryFormTransactionData(string DepositWithdraw, string PaymentMedia,DateTime FilteredDay )
        {
            DataTable dataTable;
            dataTable = null;
            string Codes = string.Empty;
            //Codes = String.Join(",", Cust_Code);
            string queryString = "";
            queryString = @"
                            SELECT 
                             ID
                            ,[Cust_Code]
                            ,[Money_TransactionType_Name] AS Media
                            ,[Deposit_Withdraw] AS [D/W]
                            ,[Amount]
                            ,[Voucher_No] AS Voucher
                            ,[Trans_Reason]
                            ,[Remarks]                          
                            ,(
                                CASE 
                                   WHEN Clearing_Status=2 THEN 'Uncleared'
                                   WHEN Clearing_Status=1 THEN 'Cleared'
                                   ELSE (Select t.[Status_Name] From [SBP_IPO_Approval_Status] as t Where t.ID=trn.[Approval_Status])
                                END
                            )AS Status

                            FROM [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction] as trn
                            WHERE trn.Received_Date='" + FilteredDay.ToShortDateString() + @"'
                            And trn.[Entry_by] = ('" + GlobalVariableBO._userName + @"')
                                    And 
                                    (
                                    trn.[Deposit_Withdraw]='"+DepositWithdraw+@"' And trn.Money_TransactionType_Name not in ('TRIPO','TRIPOApp')
                                    Or
                                    trn.Money_TransactionType_Name ='TRIPO'
                                    )
                                
                            --And trn.[Money_TransactionType_Name]='" + PaymentMedia + @"'
                            order by Entry_Date desc
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

        public DataTable GetIPOPaymentEntryFromApplicationData(DateTime date)
        {
            DataTable dataTable;
            dataTable = null;
            string Codes = string.Empty;
           // Codes = String.Join(",", Cust_Code);
            string queryString = "";

            queryString = @"
                           SELECT  
                            app.cust_code                           
                            ,comp.Company_Short_Code AS [Applied_Company]
                            ,(Select t.[Status_Name] From [SBP_IPO_Approval_Status] as t Where t.ID=app.[Application_Satus]) AS [Status]
                            ,(Select rfd.Method_Name from dbo.SBP_IPO_MoneyRefund_Method as rfd				
			                where rfd.ID=ext.Refund_Method )as RefundType
                            FROM [SBP_Database].[dbo].[SBP_IPO_Application_BasicInfo] AS app
                            JOIN SBP_IPO_Session as sess
                            ON 
                            sess.ID=app.[IPOSession_ID]
                            JOIN SBP_IPO_Company_Info as comp
                            ON 
                            comp.ID=sess.IPO_Company_ID
			                join SBP_IPO_Application_ExtendedInfo as ext
			                on ext.BasicInfo_ID=app.ID
                            WHERE app.[Entry_By] = '"+GlobalVariableBO._userName+@"' and app.application_date='"+date.ToShortDateString()+@"'
                            GROUP BY app.Cust_COde,app.[Applied_Company],sess.Session_Date
                            ,app.[Application_Satus],app.Entry_Date,comp.Company_Short_Code,ext.Refund_Method
                            ORDER BY sess.Session_Date DESC, app.Entry_Date DESC
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
        /// <summary>
        /// Loading data for eft return
        /// Md.Rashedul Hasan on 
        /// </summary>
        /// <param name="custCode">Customer code whose eft will be return</param>
        /// <param name="amount">Amount For retuning eft</param>
        /// <param name="date">Which date eft has entry</param>
        /// <returns></returns>
        public DataTable Get_EFT_Return_Data(string custCode, decimal amount, string date)
        {
            DataTable dt = new DataTable();
            string query = @"select T.ID,T.Cust_Code
                                ,p.Cust_Name As Customer_Name
                                ,T.Received_Date,T.Amount,T.Voucher_No 
                                From SBP_IPO_Customer_Broker_MoneyTransaction As T
                                Inner join SBP_Cust_Personal_Info As P 
                                ON T.Cust_Code=p.Cust_Code
                                where 
	                                Money_TransactionType_Name='EFT' 
	                                And 
	                                T.Cust_Code=" + custCode + @"
	                                 and 
	                                Received_Date=cast('" + date + @"'as date) 
	                                And Deposit_Withdraw='Withdraw'
	                                And Amount=" + amount + @"
                                        and T.ID NOT IN(
										Select 	
										--trn.ID,trn.Trans_Reason,
										REPLACE(trn.Trans_Reason,substring(trn.Trans_Reason,CHARINDEX('_',trn.Trans_Reason),LEN(trn.Trans_Reason)),'')
										From SBP_IPO_Customer_Broker_MoneyTransaction As trn
										
										Where trn.Money_TransactionType_Name='EFTRETURN' 
										And 
										trn.Cust_Code=" + custCode + @"
										 --and trn.Received_Date=cast('" + date + @"'as date) 
										And trn.Deposit_Withdraw='Deposit'
										And trn.Amount=" + amount + @" 
	                                )
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
            return dt;
        }
        public  List<Payment_PostingBO> GetIPOEftRequisitionRequest()
        {
            
            string quryString = @"SELECT p.[ID] AS [Payment_ID]
                      ,p.[Cust_Code] AS [Cust_Code]
                      ,p.[Amount] AS [Amount]
                      ,p.[Received_Date] AS [Received_Date]
                      ,[Money_TransactionType_Name] AS [Payment_Media]
                      ,(
			                Select t.[Cheque_No]
			                From [SBP_IPO_Customer_Broker_Transaction_Details] as t
			                Where t.[TransID]= p.[ID]
                      )  AS [Payment_Media_No]
                      ,(
			                Select t.[Cheque_Date]
			                From [SBP_IPO_Customer_Broker_Transaction_Details] as t
			                Where t.[TransID]= p.[ID]
                      )  AS [Payment_Media_Date]
                      ,(
			                Select t.[Bank_ID]
			                From [SBP_IPO_Customer_Broker_Transaction_Details] as t
			                Where t.[TransID]= p.[ID]
                      ) AS [Bank_ID]
                      ,(
			                Select t.[BankName]
			                From [SBP_IPO_Customer_Broker_Transaction_Details] as t
			                Where t.[TransID]= p.[ID]
                      ) AS [Bank_Name]
                      ,(
			                Select t.[Branch_ID]
			                From [SBP_IPO_Customer_Broker_Transaction_Details] as t
			                Where t.[TransID]= p.[ID]
                      ) AS [Branch_ID]
                      ,(
			                Select t.[Branch_Name]
			                From [SBP_IPO_Customer_Broker_Transaction_Details] as t
			                Where t.[TransID]= p.[ID]
                      ) AS [Bank_Branch]
                      ,(
			                Select t.[Routing_No]
			                From [SBP_IPO_Customer_Broker_Transaction_Details] as t
			                Where t.[TransID]= p.[ID]
                      ) AS [RoutingNo]
                      ,(
			                Select t.[Bank_Acc_No]
			                From [SBP_IPO_Customer_Broker_Transaction_Details] as t
			                Where t.[TransID]= p.[ID]
                      ) AS [BankAccNo]
                      ,[Entry_By] AS [Received_By]
                      ,[Deposit_Withdraw]
                      ,[Approval_By] AS [Payment_Approved_By]
                      ,[Approval_Date] AS [Payment_Approved_Date]                      
                      ,[Voucher_No] AS [Vouchar_SN]
                      ,[Trans_Reason] AS [Trans_Reason]
                      ,[Remarks] AS [Remarks]
                      ,[Entry_Date] AS [Entry_Date]
                      ,[Entry_By] AS [Entry_By]
                      ,0 AS [Maturity_Days]
                      ,'' AS [Deposit_Bank_Name]
                      ,'' AS [Deposit_Branch_Name]
                       ,[Approval_Status]
                       ,[Rejected_Reason] AS [Rejection_Reason]
                        ,[Entry_Branch_ID] AS [Entry_Branch_ID]
                        ,0 AS [OnlineOrderNo]
                        , NULL AS [OnlineEntry_Date]

                FROM dbo.SBP_IPO_Customer_Broker_MoneyTransaction as p
                LEFT OUTER JOIN 
                dbo.SBP_EFT_Issue as e
                ON p.ID = e.Req_ID
                AND ISNULL(e.Req_Type,'')='"+Indication_IPOPaymentTransaction.ReqType_EftIssue_IPOAccount+@"'
                WHERE 
                --p.Payment_Media='EFT' AND 
                e.Req_ID IS NULL AND p.[Approval_Status] =1 AND p.[Money_TransactionType_Name]='EFT'
                AND p.Deposit_Withdraw='" + Indication_PaymentMode.Withdraw+"'";
            
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
                        obj.Bank_ID =Convert.ToInt32(dr["Bank_ID"]);
                        obj.Bank_Name = Convert.ToString(dr["Bank_Name"]);
                        obj.Branch_ID = Convert.ToInt32(dr["Branch_ID"]); ;
                        obj.Bank_Branch = Convert.ToString(dr["Bank_Branch"]);
                        obj.Received_By = Convert.ToString(dr["Received_By"]);
                        obj.Received_Date = Convert.ToDateTime(dr["Received_Date"]);
                        obj.Payment_Media = Convert.ToString(dr["Payment_Media"]);
                        obj.Payment_Media_No = Convert.ToString(dr["Payment_Media_No"]);
                        if (dr["Payment_Media_Date"] != DBNull.Value)
                            obj.Payment_Media_Date = Convert.ToDateTime(dr["Payment_Media_Date"]);
                        obj.Deposit_Withdraw = Convert.ToString(dr["Deposit_Withdraw"]);
                        obj.Payment_Approved_By = Convert.ToString(dr["Payment_Approved_By"]);
                        if (dr["Payment_Approved_Date"] != DBNull.Value)
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

        public DataTable GetPublicIssueFromBeforeApplication(string[] ID, string[] sessionId)
        {
            DataTable dt = new DataTable();
            string Query_temp = @"--DROP TABLE #TEMP
                                    CREATE TABLE #TEMP(
	                                    Cust_Code Varchar(150),
	                                    Session_ID INT
                                    );";
            string queryString_InsertTemporaryTable = "";
            for (int i = 0; i < ID.Length; i++)
            {
                for (int j = 0; j < sessionId.Length; j++)
                {

                    string queryString_InsertTemporaryTable_Temp = @"INSERT INTO #TEMP(Cust_Code,Session_ID) VALUES('" + ID[i] + "'," + sessionId[j] + ")";
                    queryString_InsertTemporaryTable = queryString_InsertTemporaryTable + queryString_InsertTemporaryTable_Temp;
                }
            }
            string query_first = @"declare @CoBoId varchar(30)    
                                        set @CoBoId=(select [BO_ID] from [SBP_Broker_Info])   
                                        
                                        SELECT      
                                        per.Cust_Name As 'Client_Name'    
                                        ,cust.Cust_Code as 'Code'    
                                        ,(@CoBoId+cust.BO_ID) as 'Bo_ID'    
                                        ,Si.Recidency as 'Resident'    
                                        ,ipoComp.Company_Name as 'Company'    
                                        ,SIS.No_Of_Share as 'Share'    
                                        ,SIS.TotalAmount as 'Total_Amount'    
                                        ,SIS.Amount as 'Amount'    
                                        ,SCI.[Signature] AS 'Signature'
                                        ,'' AS 'Refund_Method'  
                                        FROM SBP_Cust_Personal_Info as per
                                        inner join sbp_customers as cust   
                                        on per.cust_code=cust.cust_code  
                                        inner join SBP_Cust_Additional_Info Si    
                                        on cust.Cust_Code=Si.Cust_Code    
                                        Left outer join [SBP_Cust_Image] SCI  
                                        on SCI.[Cust_Code]=cust.Cust_Code
                                        ,dbo.SBP_IPO_Session AS SIS
                                        inner join SBP_IPO_Company_Info as ipoComp
                                        on ipoComp.ID=SIS.IPO_Company_ID   
                                        WHERE 
                                        SIS.ID IN (
					                                        Select Distinct Session_ID
					                                        From #TEMP
                                        					
                                        )
                                        AND
                                        cust.Cust_Code IN (
					                                        Select Distinct Cust_Code
					                                        From #TEMP
                                        )
                                        ORDER BY Convert(INT,cust.Cust_Code)";
            string query_second = Query_temp + queryString_InsertTemporaryTable + query_first;
            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(query_second);
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

       

        public string GetCheckCustCode(string code)
        {
            DataTable dt = new DataTable();
            string query = @"select cust.cust_code from sbp_customers cust
                            join SBP_Cust_Additional_Info as addit
                            on cust.cust_code=addit.cust_code
                            where cust.cust_code='" + code + "' and Cust_Status_ID=1 and addit.Recidency<>'Non Resident' AND addit.Recidency IS NOT NULL";
            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(query);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            string cust_code = "";
            if (dt.Rows.Count > 0)
            {
                cust_code = dt.Rows[0][0].ToString();
            }
            return cust_code;
        }

        #region Dealer Account
        public void IPO_Company_Session_for_Dealer()
        {
            string query = @"TRUNCATE TABLE [DEALERDB].[dbo].[SBP_IPO_Company_Info]
                             TRUNCATE TABLE [DEALERDB].[dbo].[SBP_IPO_Session]

                             INSERT INTO [DEALERDB].[dbo].[SBP_IPO_Company_Info]
                             Select * from [SBP_Database].[dbo].[SBP_IPO_Company_Info]

                             INSERT INTO [DEALERDB].[dbo].[SBP_IPO_Session]
                             Select 
                               [ID]
                              ,[IPOSession_Name]
                              ,[IPOSession_Desc]
                              ,[IPO_Company_ID]
                              ,[Application_Type_ID]
                              ,[Session_Date]
                              ,[No_Of_Share]
                              ,[Amount]
                              ,[Total_Share_Value]
                              ,[Premium]
                              ,[TotalAmount]
                              ,[IsMaturedForTrade]
                              ,[Status]
                              ,[Entry_Date]
                              ,[Entry_By]
                              ,[Updated_Date]
                              ,[Update_By]
                            from [SBP_Database].[dbo].[SBP_IPO_Session]";
            try
            {
                _dbConnection.CloseDatabase();
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
        #endregion

        public void InsertIPOCompany(string CompanyShortCode, string CompanyName, string CompanyAddress, int BankID, string BankName, int BranchID, string BranchName, string BankAccNo, string RoutingNo)
        {
            SqlConnection conn = new SqlConnection(DbConnectionBasic.ConnectionString);
            CommonBAL comBal = new CommonBAL();

            DateTime TodayServerDate = comBal.GetCurrentServerDate();
            string queryString = "";
            queryString = @"INSERT INTO [SBP_Database].[dbo].[SBP_IPO_Company_Info]
                           (Company_Short_Code
                            ,[Company_Name]
                           ,[Company_Address]
                           ,[Bank_ID]
                           ,[Bank_Name]
                           ,[Branch_ID]
                           ,[Branch_Name]
                           ,[BankAcc_No]
                           ,[RoutingNo]
                           --,[Company_Logo]
                           ,[Entry_Date]
                           ,[Entry_By]
                          )
                     VALUES
                           (
                            @Company_Short_Code
                            ,@Company_Name
                           ,@Company_Address
                           ,@Bank_ID
                           ,@Bank_Name
                           ,@Branch_ID
                           ,@Branch_Name
                           ,@BankAcc_No
                           ,@RoutingNo
                           --,@Company_Logo
                           ,@Entry_Date
                           ,@Entry_By
                           )";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ClearParameters();
                _dbConnection.AddParameter("@Company_Short_Code", SqlDbType.VarChar, CompanyShortCode);
                _dbConnection.AddParameter("@Company_Name", SqlDbType.VarChar, CompanyName);
                _dbConnection.AddParameter("@Company_Address", SqlDbType.VarChar, CompanyAddress);
                _dbConnection.AddParameter("@Bank_ID", SqlDbType.Int, BankID);
                _dbConnection.AddParameter("@Bank_Name", SqlDbType.VarChar, BankName);
                _dbConnection.AddParameter("@Branch_ID", SqlDbType.Int, BranchID);
                _dbConnection.AddParameter("@Branch_Name", SqlDbType.VarChar, BranchName);
                _dbConnection.AddParameter("@BankAcc_No", SqlDbType.VarChar, BankAccNo);
                _dbConnection.AddParameter("@RoutingNo", SqlDbType.VarChar, RoutingNo);
                //_dbConnection.AddParameter("@Company_Logo", SqlDbType.Image, CompanyLogo);
                _dbConnection.AddParameter("@Entry_Date", SqlDbType.DateTime, TodayServerDate.ToShortDateString());
                _dbConnection.AddParameter("@Entry_By", SqlDbType.VarChar, GlobalVariableBO._userName);
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

        public void InsertIPOCompany(string Chairman_Name,string Designation,string CompanyShortCode,string CompanyName,string CompanyAddress,int BankID,string BankName,int BranchID,string BranchName,string BankAccNo,string RoutingNo)
        {
            SqlConnection conn = new SqlConnection(DbConnectionBasic.ConnectionString);
            CommonBAL comBal = new CommonBAL();

            DateTime TodayServerDate = comBal.GetCurrentServerDate();
            string queryString = "";
            queryString = @"INSERT INTO [SBP_Database].[dbo].[SBP_IPO_Company_Info]
                           (Company_Chairman_name
                            ,Designation
                            ,Company_Short_Code
                            ,[Company_Name]
                           ,[Company_Address]
                           ,[Bank_ID]
                           ,[Bank_Name]
                           ,[Branch_ID]
                           ,[Branch_Name]
                           ,[BankAcc_No]
                           ,[RoutingNo]
                           --,[Company_Logo]
                           ,[Entry_Date]
                           ,[Entry_By]
                          )
                     VALUES
                           (
                            @Company_Chairman_name
                            ,@Designation
                            ,@Company_Short_Code
                            ,@Company_Name
                           ,@Company_Address
                           ,@Bank_ID
                           ,@Bank_Name
                           ,@Branch_ID
                           ,@Branch_Name
                           ,@BankAcc_No
                           ,@RoutingNo
                           --,@Company_Logo
                           ,@Entry_Date
                           ,@Entry_By
                           )";
            try
            {
            _dbConnection.ConnectDatabase();
            _dbConnection.ClearParameters();
            _dbConnection.AddParameter("@Company_Chairman_name", SqlDbType.VarChar, Chairman_Name);
            _dbConnection.AddParameter("@Designation", SqlDbType.VarChar, Designation);
            _dbConnection.AddParameter("@Company_Short_Code", SqlDbType.VarChar, CompanyShortCode);
            _dbConnection.AddParameter("@Company_Name", SqlDbType.VarChar, CompanyName);
            _dbConnection.AddParameter("@Company_Address", SqlDbType.VarChar, CompanyAddress);
            _dbConnection.AddParameter("@Bank_ID", SqlDbType.Int, BankID);
            _dbConnection.AddParameter("@Bank_Name", SqlDbType.VarChar, BankName);
            _dbConnection.AddParameter("@Branch_ID", SqlDbType.Int, BranchID);
            _dbConnection.AddParameter("@Branch_Name", SqlDbType.VarChar, BranchName);
            _dbConnection.AddParameter("@BankAcc_No", SqlDbType.VarChar, BankAccNo);
            _dbConnection.AddParameter("@RoutingNo", SqlDbType.VarChar, RoutingNo);
            //_dbConnection.AddParameter("@Company_Logo", SqlDbType.Image, CompanyLogo);
            _dbConnection.AddParameter("@Entry_Date", SqlDbType.DateTime, TodayServerDate.ToShortDateString());
            _dbConnection.AddParameter("@Entry_By", SqlDbType.VarChar, GlobalVariableBO._userName);
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
        /// <summary>
        /// NRB Session Infromation Entry
        /// Added By Md.Rashedul Hasan
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Currency"></param>
        /// <param name="Amount"></param>
        /// <param name="Session_Name"></param>
        public void InsertIPOSession_NRB(int[] Id, string[] Currency, double[] Amount, string Session_Name)
        {
            string Query = @"SBP_IPO_NRBSession_Entry";
            try
            {
                for (int i = 0; i < Id.Length; i++)
                {
                    _dbConnection.ClearParameters();
                    _dbConnection.AddParameter("@Session_Name", SqlDbType.VarChar, Session_Name);
                    _dbConnection.AddParameter("@Currency_Name", SqlDbType.VarChar, Currency[i]);
                    _dbConnection.AddParameter("@Currency_ID", SqlDbType.VarChar, Id[i]);
                    _dbConnection.AddParameter("@Currency_Amount", SqlDbType.Money, Amount[i]);
                    _dbConnection.AddParameter("@Entry_BY", SqlDbType.VarChar, GlobalVariableBO._userName);
                    _dbConnection.ExecuteProQuery(Query);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InsertIPOSession(string IPOSession_Name,string IPOSession_Desc,int IPO_Company_ID,int Application_Type_ID,DateTime Session_Date,int No_Of_Share,double Amount,double TotalShareValue,double TotalAmount,int session_status,double Premium)
        {
            SqlConnection conn = new SqlConnection(DbConnectionBasic.ConnectionString);
            CommonBAL comBal = new CommonBAL();

            DateTime TodayServerDate = comBal.GetCurrentServerDate();
            string queryString = "";
            queryString = @"INSERT INTO [SBP_Database].[dbo].[SBP_IPO_Session]
                           ([IPOSession_Name]
                           ,[IPOSession_Desc]
                           ,[IPO_Company_ID]
                           ,[Application_Type_ID]
                           ,[Session_Date]
                           ,[No_Of_Share]
                           ,[Amount]
                           ,[Total_Share_Value]
                           ,[Premium]
                           ,[TotalAmount]
                            
                            ,[Status]
                           ,[Entry_Date]
                           ,[Entry_By]
                          )
                     VALUES
                           (@IPOSession_Name
                           ,@IPOSession_Desc
                           ,@IPO_Company_ID
                           ,@Application_Type_ID
                           ,@Session_Date
                           ,@No_Of_Share
                           ,@Amount
                           ,@Total_Share_Value
                           ,@Premium  
                           ,@TotalAmount
                            
                            ,@session_status
                           ,@Entry_Date
                           ,@Entry_By
                          )";
           
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ClearParameters();
                _dbConnection.AddParameter("@IPOSession_Name", SqlDbType.VarChar, IPOSession_Name);
                _dbConnection.AddParameter("@IPOSession_Desc", SqlDbType.VarChar, IPOSession_Desc);
                _dbConnection.AddParameter("@IPO_Company_ID", SqlDbType.Int, IPO_Company_ID);
                _dbConnection.AddParameter("@Application_Type_ID", SqlDbType.Int, Application_Type_ID);
                _dbConnection.AddParameter("@Session_Date", SqlDbType.DateTime, Session_Date.ToShortDateString());
                _dbConnection.AddParameter("@No_Of_Share", SqlDbType.Int, No_Of_Share);
                _dbConnection.AddParameter("@Amount", SqlDbType.Money, Amount);
                _dbConnection.AddParameter("@Total_Share_Value", SqlDbType.Money, TotalShareValue);
                _dbConnection.AddParameter("@Premium", SqlDbType.Money, Premium);
                _dbConnection.AddParameter("@TotalAmount", SqlDbType.Money, TotalAmount);
                _dbConnection.AddParameter("@session_status", SqlDbType.Bit, session_status);
                //_dbConnection.AddParameter("@Company_Logo", SqlDbType.Image, CompanyLogo);
                _dbConnection.AddParameter("@Entry_Date", SqlDbType.DateTime, TodayServerDate.ToShortDateString());
                _dbConnection.AddParameter("@Entry_By", SqlDbType.VarChar, GlobalVariableBO._userName);
               
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

        public void InsertIPOSession_UITransApplied(string IPOSession_Name, string IPOSession_Desc, int IPO_Company_ID, int Application_Type_ID, DateTime Session_Date, int No_Of_Share, double Amount, double TotalShareValue, double TotalAmount, int session_status, double Premium,DateTime Session_End_Date)
        {
            SqlConnection conn = new SqlConnection(DbConnectionBasic.ConnectionString);
            CommonBAL comBal = new CommonBAL();

            DateTime TodayServerDate = comBal.GetCurrentServerDate();
            string queryString = "";
            queryString = @"INSERT INTO [SBP_Database].[dbo].[SBP_IPO_Session]
                           ([IPOSession_Name]
                           ,[IPOSession_Desc]
                           ,[IPO_Company_ID]
                           ,[Application_Type_ID]
                           ,[Session_Date]
                           ,[No_Of_Share]
                           ,[Amount]
                           ,[Total_Share_Value]
                           ,[Premium]
                           ,[TotalAmount]
                           ,[Status]
                           ,[Entry_Date]
                           ,[Entry_By]
                           ,[IPO_Session_End_Date]
                          )
                     VALUES
                           (@IPOSession_Name
                           ,@IPOSession_Desc
                           ,@IPO_Company_ID
                           ,@Application_Type_ID
                           ,@Session_Date
                           ,@No_Of_Share
                           ,@Amount
                           ,@Total_Share_Value
                           ,@Premium  
                           ,@TotalAmount
                           ,@session_status
                           ,@Entry_Date
                           ,@Entry_By
                           ,@IPO_Session_End_Date
                          )";

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ClearParameters();
                _dbConnection.AddParameter("@IPOSession_Name", SqlDbType.VarChar, IPOSession_Name);
                _dbConnection.AddParameter("@IPOSession_Desc", SqlDbType.VarChar, IPOSession_Desc);
                _dbConnection.AddParameter("@IPO_Company_ID", SqlDbType.Int, IPO_Company_ID);
                _dbConnection.AddParameter("@Application_Type_ID", SqlDbType.Int, Application_Type_ID);
                _dbConnection.AddParameter("@Session_Date", SqlDbType.DateTime, Session_Date.ToShortDateString());
                _dbConnection.AddParameter("@No_Of_Share", SqlDbType.Int, No_Of_Share);
                _dbConnection.AddParameter("@Amount", SqlDbType.Money, Amount);
                _dbConnection.AddParameter("@Total_Share_Value", SqlDbType.Money, TotalShareValue);
                _dbConnection.AddParameter("@Premium", SqlDbType.Money, Premium);
                _dbConnection.AddParameter("@TotalAmount", SqlDbType.Money, TotalAmount);
                _dbConnection.AddParameter("@session_status", SqlDbType.TinyInt, session_status);
                //_dbConnection.AddParameter("@Company_Logo", SqlDbType.Image, CompanyLogo);
                _dbConnection.AddParameter("@Entry_Date", SqlDbType.DateTime, TodayServerDate.ToShortDateString());
                _dbConnection.AddParameter("@Entry_By", SqlDbType.VarChar, GlobalVariableBO._userName);
                _dbConnection.AddParameter("@IPO_Session_End_Date", SqlDbType.DateTime, Session_End_Date.ToShortDateString());
                _dbConnection.ExecuteNonQuery(queryString);

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


        public void Insert_Transfer_DepositMoneyTransaction(string CustCode_TradeAcc, string[] CustCode_IPOAcc, double Amount_TradeAcc, double[] Amount_IPOAcc, string Deposit_Withdraw_TradeAcc, string Deposit_Withdraw_IPOAcc, DateTime ReceivedDate, string VoucherNo,string Remarks, int IntendedIPOSessionID)
        {
            CommonBAL comBal = new CommonBAL();
            DateTime TodayServerDate = comBal.GetCurrentServerDate();
            string PaymentMethod = Indication_IPOPaymentTransaction.TRTA;
            string PaymentMethodForPaymentPosting = Indication_PaymentTransaction.TRIPO;

            string queryString_TemporaryTable = @"
                                                 CREATE TABLE #Temp_IPOAcc(
                                                    Cust_Code Varchar(100),
                                                    Amount Money,
                                                    Deposit_Withdraw Varchar(100)
                                                 );   
            ";
            string queryString_TemporaryTable_NewInsertDetails = @"
                                                                    CREATE TABLE #Temp_IPOAcc_NewInsert(
                                                                       Cust_Code varchar(100),
                                                                       Trans_ID INT
                                                                    );
            ";

            string queryString_InsertTemporaryTable = string.Empty;

            for (int i = 0; i < CustCode_IPOAcc.Length; i++)
            {
                string queryString_InsertTemporaryTable_Temp = @"INSERT INTO #Temp_IPOAcc (Cust_Code,Amount,Deposit_Withdraw) VALUES('" + CustCode_IPOAcc[i] + @"'," + Amount_IPOAcc[i] + @",'" + Deposit_Withdraw_IPOAcc + @"');
                ";
                queryString_InsertTemporaryTable = queryString_InsertTemporaryTable + queryString_InsertTemporaryTable_Temp;
            }

            string queryString_InsertIPOAcc = string.Empty;
            queryString_InsertIPOAcc = @"INSERT INTO [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction]
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
                               ,[Remarks]
                               ,[Entry_Branch_ID]
                               ,[Entry_Date]
                               ,[Entry_By]
                            )
                            SELECT 
                                Cust_Code
                                ,'" + ReceivedDate.ToShortDateString() + @"' AS Received_Date
                                ,(    SELECT [ID]
                                    FROM [SBP_Database].[dbo].[SBP_IPO_MoneyTrans_Type]
                                    WHERE [MoneyTransType_Name]='" + PaymentMethod + @"'
                                ) AS Money_TransactionType_ID
                                ,'" + PaymentMethod + @"' AS Money_TransactionType_Name
                                ,Deposit_Withdraw AS Deposit_Withdraw
                                , Amount AS Amount
                                ,'" + VoucherNo + @"' AS Voucher_No
                                ,(
                                    CASE 
                                        WHEN Deposit_Withdraw='Deposit' THEN " + "[Cust_Code]+' From " + CustCode_TradeAcc + @"' 
                                        WHEN Deposit_Withdraw='Withdraw' THEN " + "[Cust_Code]+' To " + CustCode_TradeAcc + @"' 
                                    END
                                )AS Trans_Reason
                                ," + IntendedIPOSessionID + @" AS Intended_IPOSession_ID
                                ,( 
                                        SELECT  [IPOSession_Name]
                                        FROM [SBP_Database].[dbo].[SBP_IPO_Session]
                                        WHERE [ID]=" + IntendedIPOSessionID + @"
                                ) AS Intended_IPOSession_Name
                                ,0 AS Approval_Status
                                ,'"+Remarks+@"'
                                ,'"+GlobalVariableBO._branchId+@"'
                                ,GETDATE() AS Entry_Date
                                ,'" + GlobalVariableBO._userName + @"'
                            FROM #Temp_IPOAcc ";



            string queryString_InsertPaymentPosting = string.Empty;
            queryString_InsertPaymentPosting = @"INSERT INTO [SBP_Database].[dbo].[SBP_Payment_Posting_Request]
                                (
	                                [Cust_Code]
                                   ,[Amount]
                                   ,[Received_Date]
                                   ,[Payment_Media]
                                   ,[Received_By]
                                   ,[Deposit_Withdraw]
                                   ,[Vouchar_SN]
                                   ,[Trans_Reason]
                                   ,[Remarks]
                                   ,[Entry_Date]
                                   ,[Entry_By]
                                   ,[Approval_Status]
                                   ,[Entry_Branch_ID]
                                )

                           VALUES( 
                                
                                '" + CustCode_TradeAcc + @"'
                                ," + Amount_TradeAcc + @" /*AS Amount*/
                                ,'" + ReceivedDate.ToShortDateString() + @"' /*AS Received_Date*/
                                ,'" + PaymentMethodForPaymentPosting + @"' /*AS Payment_Media*/
                                ,'" + GlobalVariableBO._userName + @"' /*AS Received_By*/
                                ,'" + Deposit_Withdraw_TradeAcc + @"' /*AS Deposit_Withdraw*/
                                ,'" + VoucherNo + @"' /*AS Voucher_No*/
                                ,'" + Deposit_Withdraw_TradeAcc == Indication_PaymentMode.Deposit ?
                                    CustCode_TradeAcc + @" To '+" + (CustCode_IPOAcc.Length > 1 ? "'MulitCustomers'" : "'" + CustCode_IPOAcc[0].ToString() + "'")
                                    :
                                    CustCode_TradeAcc + @" From '+" + (CustCode_IPOAcc.Length > 1 ? "'MulitCustomers'" : "'" + CustCode_IPOAcc[0].ToString() + "'") + @" /*AS Trans_Reason*/
                                ,'" + string.Empty + @"' /*AS Remarks*/
                                ,CONVERT(Varchar(10),GETDATE(),111) /*AS Entry_Date*/
                                ,'" + GlobalVariableBO._userName + @"'
                                ,0 /*AS Approval_Status*/
                                ," + GlobalVariableBO._branchId + @"
                           )";


            string queryString = queryString_TemporaryTable + queryString_InsertTemporaryTable + queryString_InsertIPOAcc + queryString_InsertPaymentPosting;

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();
                //_dbConnection.ExecuteNonQuery(queryString_TemporaryTable);
                //_dbConnection.ExecuteNonQuery(queryString_InsertTemporaryTable);
                //_dbConnection.ExecuteNonQuery(queryString_InsertIPOAcc);
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
        public DataTable Insert_Transfer_DepositMoneyTransaction_UITransApplied_Negative(string CustCode_TradeAcc, string[] CustCode_IPOAcc, double Amount_TradeAcc, double[] Amount_IPOAcc, string Deposit_Withdraw_TradeAcc, string Deposit_Withdraw_IPOAcc, DateTime ReceivedDate, string VoucherNo, string Remarks, int IntendedIPOSessionID, int[] ChannelID, string[] ChannelType)
        {
            CommonBAL comBal = new CommonBAL();
            DateTime TodayServerDate = comBal.GetCurrentServerDate();
            string PaymentMethod = Indication_IPOPaymentTransaction.TRTA;
            string PaymentMethodForPaymentPosting = Indication_PaymentTransaction.TRIPO;
            DataTable dt = new DataTable();


            string queryString_GetTemporaryTable_NewInsertDetails = @"
                                                            Select * 
                                                            From #Temp_IPOAcc_NewInsert
                ";

            string queryString_TemporaryTable = @"
                                                 CREATE TABLE #Temp_IPOAcc(
                                                    ID  INT IDENTITY(1,1), 
                                                    Cust_Code Varchar(100),
                                                    Amount Money,
                                                    Deposit_Withdraw Varchar(100),
                                                    ChannelID INT,
                                                    ChannelType varchar(100)

                                                 );   
            ";
            string queryString_TemporaryTable_NewInsertDetails = @"
                                                                    CREATE TABLE #Temp_IPOAcc_NewInsert(
                                                                       Cust_Code varchar(100),
                                                                       Trans_ID INT
                                                                    );
            ";

            string queryString_InsertTemporaryTable = string.Empty;

            for (int i = 0; i < CustCode_IPOAcc.Length; i++)
            {
                string queryString_InsertTemporaryTable_Temp = @"INSERT INTO #Temp_IPOAcc (Cust_Code,Amount,Deposit_Withdraw,ChannelID,ChannelType) VALUES('" + CustCode_IPOAcc[i] + @"'," + Amount_IPOAcc[i] + @",'" + Deposit_Withdraw_IPOAcc + @"'," + Convert.ToString(ChannelID.Length > 0 ? ChannelID[i] : 0) + @",'" + Convert.ToString(ChannelType.Length > 0 ? ChannelType[i] : string.Empty) + @"');
                ";
                queryString_InsertTemporaryTable = queryString_InsertTemporaryTable + queryString_InsertTemporaryTable_Temp;
            }

            //Transfer Direction
            string TransferDirection_TradeAcc = string.Empty;
            if (Deposit_Withdraw_TradeAcc == Indication_PaymentMode.Deposit)
                TransferDirection_TradeAcc = "From ";
            else
                TransferDirection_TradeAcc = "To ";

            string TransferDirection_IPOAcc = string.Empty;
            if (Deposit_Withdraw_IPOAcc == Indication_PaymentMode.Deposit)
                TransferDirection_IPOAcc = "From ";
            else
                TransferDirection_IPOAcc = "To ";

            //Insert Payment Posting
            string queryString_InsertPaymentPosting = string.Empty;
            queryString_InsertPaymentPosting = @"INSERT INTO [SBP_Database].[dbo].[SBP_Payment_Posting_Request]
                                (
	                                [Cust_Code]
                                   ,[Amount]
                                   ,[Received_Date]
                                   ,[Payment_Media]
                                   ,[Received_By]
                                   ,[Deposit_Withdraw]
                                   ,[Vouchar_SN]
                                   ,[Trans_Reason]
                                   ,[Remarks]
                                   ,[Entry_Date]
                                   ,[Entry_By]
                                   ,[Approval_Status]
                                   ,[Entry_Branch_ID]
                                )

                           VALUES( 
                                
                                '" + CustCode_TradeAcc + @"'
                                ," + Amount_TradeAcc + @" /*AS Amount*/
                                ,'" + ReceivedDate.ToShortDateString() + @"' /*AS Received_Date*/
                                ,'" + PaymentMethodForPaymentPosting + @"' /*AS Payment_Media*/
                                ,'" + GlobalVariableBO._userName + @"' /*AS Received_By*/
                                ,'" + Deposit_Withdraw_TradeAcc + @"' /*AS Deposit_Withdraw*/
                                ,'" + VoucherNo + @"' /*AS Voucher_No*/
                                ,'" + CustCode_TradeAcc + " " + TransferDirection_TradeAcc + " " + (CustCode_IPOAcc.Length > 1 ? "MulitCustomers" : "" + CustCode_IPOAcc[0].ToString() + "") + @"' /*AS Trans_Reason*/
                                ,'" + string.Empty + @"' /*AS Remarks*/
                                ,CONVERT(Varchar(10),GETDATE(),111) /*AS Entry_Date*/
                                ,'" + GlobalVariableBO._userName + @"'
                                ,0 /*AS Approval_Status*/
                                ," + GlobalVariableBO._branchId + @"
                           )";
            string lastId = @" declare @lastScopeIdentity bigint
                            set @lastScopeIdentity=(select scope_identity()) ";


            //Insert IPO Acc
            string queryString_InsertIPOAcc = string.Empty;
            queryString_InsertIPOAcc = @"INSERT INTO [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction]
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
                               ,[Remarks]
                               ,[Channel]
                               ,[ChannelID]
                               ,[Entry_Branch_ID]
                               ,[Entry_Date]
                               ,[Entry_By]
                            )
                            SELECT 
                                Cust_Code
                                ,'" + ReceivedDate.ToShortDateString() + @"' AS Received_Date
                                ,(    SELECT [ID]
                                    FROM [SBP_Database].[dbo].[SBP_IPO_MoneyTrans_Type]
                                    WHERE [MoneyTransType_Name]='" + PaymentMethod + @"'
                                ) AS Money_TransactionType_ID
                                ,'" + PaymentMethod + @"' AS Money_TransactionType_Name
                                ,Deposit_Withdraw AS Deposit_Withdraw
                                , Amount AS Amount
                                ,'" + VoucherNo + @"' AS Voucher_No
                                ,(
                                    CASE 
                                        WHEN Deposit_Withdraw='Deposit' THEN " + "[Cust_Code]+ '" + TransferDirection_IPOAcc + @" " + CustCode_TradeAcc + @"'" + "+'_'+Convert(varchar(100),@lastScopeIdentity)" + @" 
                                        WHEN Deposit_Withdraw='Withdraw' THEN " + "[Cust_Code]+'" + TransferDirection_IPOAcc + @" " + CustCode_TradeAcc + @"'" + "+'_'+Convert(varchar(100),@lastScopeIdentity)" + @" 
                                    END
                                )AS Trans_Reason
                                ," + IntendedIPOSessionID + @" AS Intended_IPOSession_ID
                                ,( 
                                        SELECT  [IPOSession_Name]
                                        FROM [SBP_Database].[dbo].[SBP_IPO_Session]
                                        WHERE [ID]=" + IntendedIPOSessionID + @"
                                ) AS Intended_IPOSession_Name
                                ,0 AS Approval_Status
                                 ,'" + Remarks + @"'
                                ,ChannelType
                                ,ChannelID
                                ,'" + GlobalVariableBO._branchId + @"'
                                ,GETDATE() AS Entry_Date
                                ,'" + GlobalVariableBO._userName + @"'
                            FROM #Temp_IPOAcc 
                            ORDER BY ID
                            
                            DECLARE @First_Identity INT                            

                            SET @First_Identity=(
                                                    Select Scope_Identity()-(IDENT_INCR('SBP_IPO_Customer_Broker_MoneyTransaction')*@@Rowcount-1)
                            )                               
                        
                            ";

            string query_Insert_TemporaryTable_NewInsertDetails = string.Empty;
            query_Insert_TemporaryTable_NewInsertDetails = @"
                                                            IF('" + Deposit_Withdraw_IPOAcc + "' = '" + Indication_PaymentMode.Deposit + @"')
                                                            BEGIN 
                
                                                                INSERT INTO #Temp_IPOAcc_NewInsert(Cust_Code,Trans_ID)
                                                                Select Cust_Code,@First_Identity+(ID-1)
                                                                From  #Temp_IPOAcc
                                                                ORDER BY ID     

                                                            END ";

            //Concat All Query
            string queryString = queryString_TemporaryTable + queryString_TemporaryTable_NewInsertDetails + queryString_InsertTemporaryTable + queryString_InsertPaymentPosting + lastId + queryString_InsertIPOAcc + query_Insert_TemporaryTable_NewInsertDetails;

            try
            {
                //_dbConnection.ConnectDatabase();
                // _dbConnection.StartTransaction();
                //_dbConnection.ExecuteNonQuery(queryString_TemporaryTable);
                //_dbConnection.ExecuteNonQuery(queryString_InsertTemporaryTable);
                //_dbConnection.ExecuteNonQuery(queryString_InsertIPOAcc);
                _dbConnection.ExecuteNonQuery(queryString);
                dt = _dbConnection.ExecuteQuery(queryString_GetTemporaryTable_NewInsertDetails);
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
            return dt;
        }
        public DataTable Insert_Transfer_DepositMoneyTransaction_UITransApplied(string CustCode_TradeAcc, string[] CustCode_IPOAcc, double Amount_TradeAcc, double[] Amount_IPOAcc, string Deposit_Withdraw_TradeAcc, string Deposit_Withdraw_IPOAcc, DateTime ReceivedDate, string VoucherNo,string Remarks, int IntendedIPOSessionID,int[] ChannelID,string[] ChannelType)
        {
            CommonBAL comBal = new CommonBAL();
            DateTime TodayServerDate = comBal.GetCurrentServerDate();
            string PaymentMethod = Indication_IPOPaymentTransaction.TRTA;
            string PaymentMethodForPaymentPosting = Indication_PaymentTransaction.TRIPO;
            DataTable dt = new DataTable();

            
            string queryString_GetTemporaryTable_NewInsertDetails = @"
                                                            Select * 
                                                            From #Temp_IPOAcc_NewInsert
                ";

            string queryString_TemporaryTable = @"
                                                 CREATE TABLE #Temp_IPOAcc(
                                                    ID  INT IDENTITY(1,1), 
                                                    Cust_Code Varchar(100),
                                                    Amount Money,
                                                    Deposit_Withdraw Varchar(100),
                                                    ChannelID INT,
                                                    ChannelType varchar(100)

                                                 );   
            ";
            string queryString_TemporaryTable_NewInsertDetails = @"
                                                                    CREATE TABLE #Temp_IPOAcc_NewInsert(
                                                                       Cust_Code varchar(100),
                                                                       Trans_ID INT
                                                                    );
            ";

            string queryString_InsertTemporaryTable = string.Empty;

            for (int i = 0; i < CustCode_IPOAcc.Length; i++)
            {
                string queryString_InsertTemporaryTable_Temp = @"INSERT INTO #Temp_IPOAcc (Cust_Code,Amount,Deposit_Withdraw,ChannelID,ChannelType) VALUES('" + CustCode_IPOAcc[i] + @"'," + Amount_IPOAcc[i] + @",'" + Deposit_Withdraw_IPOAcc + @"'," + Convert.ToString(ChannelID.Length > 0 ? ChannelID[i] : 0) + @",'" + Convert.ToString(ChannelType.Length>0?ChannelType[i]:string.Empty) + @"');
                ";
                queryString_InsertTemporaryTable = queryString_InsertTemporaryTable + queryString_InsertTemporaryTable_Temp;
            }
            
            //Transfer Direction
            string TransferDirection_TradeAcc = string.Empty;
            if (Deposit_Withdraw_TradeAcc == Indication_PaymentMode.Deposit)
                TransferDirection_TradeAcc = "From ";
            else
                TransferDirection_TradeAcc = "To ";

            string TransferDirection_IPOAcc = string.Empty;
            if (Deposit_Withdraw_IPOAcc == Indication_PaymentMode.Deposit)
                TransferDirection_IPOAcc = "From ";
            else
                TransferDirection_IPOAcc = "To ";

            //Insert Payment Posting
            string queryString_InsertPaymentPosting = string.Empty;
            queryString_InsertPaymentPosting = @"INSERT INTO [SBP_Database].[dbo].[SBP_Payment_Posting_Request]
                                (
	                                [Cust_Code]
                                   ,[Amount]
                                   ,[Received_Date]
                                   ,[Payment_Media]
                                   ,[Received_By]
                                   ,[Deposit_Withdraw]
                                   ,[Vouchar_SN]
                                   ,[Trans_Reason]
                                   ,[Remarks]
                                   ,[Entry_Date]
                                   ,[Entry_By]
                                   ,[Approval_Status]
                                   ,[Entry_Branch_ID]
                                )

                           VALUES( 
                                
                                '" + CustCode_TradeAcc + @"'
                                ," + Amount_TradeAcc + @" /*AS Amount*/
                                ,'" + ReceivedDate.ToShortDateString() + @"' /*AS Received_Date*/
                                ,'" + PaymentMethodForPaymentPosting + @"' /*AS Payment_Media*/
                                ,'" + GlobalVariableBO._userName + @"' /*AS Received_By*/
                                ,'" + Deposit_Withdraw_TradeAcc + @"' /*AS Deposit_Withdraw*/
                                ,'" + VoucherNo + @"' /*AS Voucher_No*/
                                ,'" + CustCode_TradeAcc + " " + TransferDirection_TradeAcc + " " + (CustCode_IPOAcc.Length > 1 ? "MulitCustomers" : "" + CustCode_IPOAcc[0].ToString() + "") + @"' /*AS Trans_Reason*/
                                ,'" + string.Empty + @"' /*AS Remarks*/
                                ,CONVERT(Varchar(10),GETDATE(),111) /*AS Entry_Date*/
                                ,'" + GlobalVariableBO._userName + @"'
                                ,0 /*AS Approval_Status*/
                                ," + GlobalVariableBO._branchId + @"
                           )";
            string lastId = @" declare @lastScopeIdentity bigint
                            set @lastScopeIdentity=(select scope_identity()) ";


            //Insert IPO Acc
            string queryString_InsertIPOAcc = string.Empty;
            queryString_InsertIPOAcc = @"INSERT INTO [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction]
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
                               ,[Remarks]
                               ,[Channel]
                               ,[ChannelID]
                               ,[Entry_Branch_ID]
                               ,[Entry_Date]
                               ,[Entry_By]
                            )
                            SELECT 
                                Cust_Code
                                ,'" + ReceivedDate.ToShortDateString() + @"' AS Received_Date
                                ,(    SELECT [ID]
                                    FROM [SBP_Database].[dbo].[SBP_IPO_MoneyTrans_Type]
                                    WHERE [MoneyTransType_Name]='" + PaymentMethod + @"'
                                ) AS Money_TransactionType_ID
                                ,'" + PaymentMethod + @"' AS Money_TransactionType_Name
                                ,Deposit_Withdraw AS Deposit_Withdraw
                                , Amount AS Amount
                                ,'" + VoucherNo + @"' AS Voucher_No
                                ,(
                                    CASE 
                                        WHEN Deposit_Withdraw='Deposit' THEN " + "[Cust_Code]+ '" + TransferDirection_IPOAcc + @" " + CustCode_TradeAcc + @"'" + "+'_'+Convert(varchar(100),@lastScopeIdentity)" + @" 
                                        WHEN Deposit_Withdraw='Withdraw' THEN " + "[Cust_Code]+'" + TransferDirection_IPOAcc + @" " + CustCode_TradeAcc + @"'" + "+'_'+Convert(varchar(100),@lastScopeIdentity)" + @" 
                                    END
                                )AS Trans_Reason
                                ," + IntendedIPOSessionID + @" AS Intended_IPOSession_ID
                                ,( 
                                        SELECT  [IPOSession_Name]
                                        FROM [SBP_Database].[dbo].[SBP_IPO_Session]
                                        WHERE [ID]=" + IntendedIPOSessionID + @"
                                ) AS Intended_IPOSession_Name
                                ,0 AS Approval_Status
                                 ,'" + Remarks + @"'
                                ,ChannelType
                                ,ChannelID
                                ,'" + GlobalVariableBO._branchId + @"'
                                ,GETDATE() AS Entry_Date
                                ,'" + GlobalVariableBO._userName + @"'
                            FROM #Temp_IPOAcc 
                            ORDER BY ID
                            
                            DECLARE @First_Identity bigint                            

                            SET @First_Identity=(
                                                    Select Scope_Identity()-(IDENT_INCR('SBP_IPO_Customer_Broker_MoneyTransaction')*@@Rowcount-1)
                            )                               
                        
                            ";

            string query_Insert_TemporaryTable_NewInsertDetails = string.Empty;
            query_Insert_TemporaryTable_NewInsertDetails = @"
                                                            IF('"+Deposit_Withdraw_IPOAcc+"' = '"+Indication_PaymentMode.Deposit+ @"')
                                                            BEGIN 
                
                                                                INSERT INTO #Temp_IPOAcc_NewInsert(Cust_Code,Trans_ID)
                                                                Select Cust_Code,@First_Identity+(ID-1)
                                                                From  #Temp_IPOAcc
                                                                ORDER BY ID     

                                                            END ";
           
            //Concat All Query
            string queryString = queryString_TemporaryTable + queryString_TemporaryTable_NewInsertDetails + queryString_InsertTemporaryTable + queryString_InsertPaymentPosting + lastId + queryString_InsertIPOAcc + query_Insert_TemporaryTable_NewInsertDetails;

            try
            {
                //_dbConnection.ConnectDatabase();
                // _dbConnection.StartTransaction();
                //_dbConnection.ExecuteNonQuery(queryString_TemporaryTable);
                //_dbConnection.ExecuteNonQuery(queryString_InsertTemporaryTable);
                //_dbConnection.ExecuteNonQuery(queryString_InsertIPOAcc);
                _dbConnection.ExecuteNonQuery(queryString);
                dt = _dbConnection.ExecuteQuery(queryString_GetTemporaryTable_NewInsertDetails);
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
            return dt;
        }
        /// <summary>
        /// Charge Taken Entry Add By Md.Rashedul Hasan 12 mar 2015
        /// </summary>
        /// <param name="With_cust_Code"></param>
        /// <param name="Deposit_CustCode"></param>
        /// <param name="Amount"></param>
        /// <param name="Payemnt_Media"></param>
        /// <param name="Deposit_Withdraw"></param>
        /// <param name="Voucher_No"></param>
        /// <param name="Trans_Reason"></param>
        /// <param name="IntendedIPOSessionID"></param>
        /// <param name="Remarks"></param>
        /// <param name="chargeamount"></param>
                                                 
        public void Insert_IPO_Application_Charge(string[] Deposit_CustCode, double ChargeAmount, string Payemnt_Media, string TransferCode, string Voucher_No, string Trans_Reason, int IntendedIPOSessionID, string Remarks)
        {
            string queryString_Temporary_Table = @"
                                                    IF OBJECT_ID('tempdb..#Temp_IPOAcc') IS NOT NULL  
													BEGIN 													 
													DROP TABLE #Temp_IPOAcc
													END
                                                    CREATE TABLE #Temp_IPOAcc
                                                    (
                                                        ID  INT IDENTITY(1,1), 
                                                        Cust_Code Varchar(100),
                                                        Amount Money                                                    
                                                    );   
                                            ";
            string queryString_InsertTemporaryTable = string.Empty;
            for (int i = 0; i < Deposit_CustCode.Length; i++)
            {
                string queryString_InsertTemporaryTable_Temp = @"INSERT INTO #Temp_IPOAcc (Cust_Code,Amount) VALUES ('" + Deposit_CustCode[i] + @"'," + ChargeAmount + @")
                                    ";
                queryString_InsertTemporaryTable = queryString_InsertTemporaryTable + queryString_InsertTemporaryTable_Temp;
            }
            string queryString_InsertPaymentPosting = string.Empty;
            string Insert_Withdra_Query = "";
            string Insert_Cash_Deposit_query = "";
            if (Payemnt_Media == "TRIPO")
            {
                Insert_Withdra_Query = @"INSERT INTO [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction]
                            (
	                            [Cust_Code]
                               ,[Received_Date]
                               ,[Money_TransactionType_ID]
                               ,[Money_TransactionType_Name]
                               ,[Deposit_Withdraw]
                               ,[Amount]
                               ,[Voucher_No]
                               ,[Trans_Reason]                               
                               ,[Approval_Status]
                               ,[Remarks]
                               ,[Entry_Branch_ID]
                               ,[Entry_Date]
                               ,[Entry_By]
                            )
                            Values ( 
                                '" + TransferCode + @"'
                                ,'" + GlobalVariableBO._currentServerDate.Date + @"' /*AS Received_Date*/
                                ,(    SELECT [ID]
                                    FROM [SBP_Database].[dbo].[SBP_IPO_MoneyTrans_Type]
                                    WHERE [MoneyTransType_Name]='" + Payemnt_Media + @"'
                                ) /*AS Money_TransactionType_ID*/
                                ,'" + Payemnt_Media + @"' /*AS Money_TransactionType_Name*/
                                ,'Withdraw' /* AS Deposit_Withdraw */
                                , " + ChargeAmount + @"/* AS Amount*/
                                ,'" + Voucher_No + @"' /*AS Voucher_No*/
                                ,'Charge From '+'" + TransferCode + "'+' To '+'" + (Deposit_CustCode.Length > 1 ? "MulitCustomers" : "" + Deposit_CustCode[0].ToString() + "") + @"' /*AS Trans_Reason*/ 
                                
                                ,0 /*AS Approval_Status*/
                                 ,'" + Remarks + @"'
                                ,'" + GlobalVariableBO._branchId + @"'
                                ,GETDATE()/* AS Entry_Date*/
                                ,'" + GlobalVariableBO._userName + @"'
                            )
                                    ";
            }

            else if (Payemnt_Media == "TRTA")
            {
                //Insert Payment Posting

                queryString_InsertPaymentPosting = @"INSERT INTO [SBP_Database].[dbo].[SBP_Payment_Posting_Request]
                                (
	                                [Cust_Code]
                                   ,[Amount]
                                   ,[Received_Date]
                                   ,[Payment_Media]
                                   ,[Received_By]
                                   ,[Deposit_Withdraw]
                                   ,[Vouchar_SN]
                                   ,[Trans_Reason]
                                   ,[Remarks]
                                   ,[Entry_Date]
                                   ,[Entry_By]
                                   ,[Approval_Status]
                                   ,[Entry_Branch_ID]
                                )

                           VALUES( 
                                
                                '" + TransferCode + @"'
                                ," + ChargeAmount + @" /*AS Amount*/
                                ,'" + GlobalVariableBO._currentServerDate.Date.ToShortDateString() + @"' /*AS Received_Date*/
                                ,'TRIPO' /*AS Payment_Media*/
                                ,'" + GlobalVariableBO._userName + @"' /*AS Received_By*/
                                ,'Withdraw' /*AS Deposit_Withdraw*/
                                ,'" + Voucher_No + @"' /*AS Voucher_No*/
                                ,'Charge From '+'" + TransferCode + "'+' To '+'" + (Deposit_CustCode.Length > 1 ? "MulitCustomers" : "" + Deposit_CustCode[0].ToString() + "") + @"' /*AS Trans_Reason*/
                                ,'" + Remarks + @"' /*AS Remarks*/
                                ,CONVERT(Varchar(10),GETDATE(),111) /*AS Entry_Date*/
                                ,'" + GlobalVariableBO._userName + @"'
                                ,0 /*AS Approval_Status*/
                                ," + GlobalVariableBO._branchId + @"
                           )";
            }
            else
            {
                Insert_Cash_Deposit_query =
                             @"INSERT INTO [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction]
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
                               ,[Remarks]
                               ,[Entry_Branch_ID]
                               ,[Entry_Date]
                               ,[Entry_By]
                            )
                            SELECT 
                                Cust_Code
                                ,'" + GlobalVariableBO._currentServerDate.ToShortDateString() + @"' AS Received_Date
                                ,(    SELECT [ID]
                                    FROM [SBP_Database].[dbo].[SBP_IPO_MoneyTrans_Type]
                                    WHERE [MoneyTransType_Name]='" + Payemnt_Media + @"'
                                ) AS Money_TransactionType_ID
                                ,'" + Payemnt_Media + @"' AS Money_TransactionType_Name
                                ,'Deposit' AS Deposit_Withdraw
                                , Amount AS Amount
                                ,'" + Voucher_No + @"' AS Voucher_No
                                ,'Charge For IPO Application' /*AS Trans_Reason*/                                
                                ," + IntendedIPOSessionID + @" AS Intended_IPOSession_ID
                                ,( 
                                        SELECT  [IPOSession_Name]
                                        FROM [SBP_Database].[dbo].[SBP_IPO_Session]
                                        WHERE [ID]=" + IntendedIPOSessionID + @"
                                ) AS Intended_IPOSession_Name
                                ,0 AS Approval_Status
                                 ,'" + Remarks + @"'
                                ,'" + GlobalVariableBO._branchId + @"'
                                ,GETDATE() AS Entry_Date
                                ,'" + GlobalVariableBO._userName + @"'
                            FROM #Temp_IPOAcc 
                            ORDER BY ID
                            ";
            }
            string lastId = @" declare @lastScopeIdentity int
                            set @lastScopeIdentity=(select scope_identity()) 
                            ";
            string Insert_Deposit_query =
                                        @"INSERT INTO [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction]
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
                               ,[Remarks]
                               ,[Entry_Branch_ID]
                               ,[Entry_Date]
                               ,[Entry_By]
                            )
                            SELECT 
                                Cust_Code
                                ,'" + GlobalVariableBO._currentServerDate.ToShortDateString() + @"' AS Received_Date
                                ,(    SELECT [ID]
                                    FROM [SBP_Database].[dbo].[SBP_IPO_MoneyTrans_Type]
                                    WHERE [MoneyTransType_Name]='" + Payemnt_Media + @"'
                                ) AS Money_TransactionType_ID
                                ,'" + Payemnt_Media + @"' AS Money_TransactionType_Name
                                ,'Deposit' AS Deposit_Withdraw
                                , Amount AS Amount
                                ,'" + Voucher_No + @"' AS Voucher_No
                                ,'Charge From' +' " + TransferCode + @"'+' To '+Cust_Code +'_'+Convert(varchar(100),@lastScopeIdentity)" + @"                                  
                                AS Trans_Reason
                                ," + IntendedIPOSessionID + @" AS Intended_IPOSession_ID
                                ,( 
                                        SELECT  [IPOSession_Name]
                                        FROM [SBP_Database].[dbo].[SBP_IPO_Session]
                                        WHERE [ID]=" + IntendedIPOSessionID + @"
                                ) AS Intended_IPOSession_Name
                                ,0 AS Approval_Status
                                 ,'" + Remarks + @"'
                                ,'" + GlobalVariableBO._branchId + @"'
                                ,GETDATE() AS Entry_Date
                                ,'" + GlobalVariableBO._userName + @"'
                            FROM #Temp_IPOAcc 
                            ORDER BY ID
                            
                                    ";
            string query = "";
            if (Payemnt_Media == "TRTA" || Payemnt_Media == "TRIPO")
            {
                query = queryString_Temporary_Table + queryString_InsertTemporaryTable + Insert_Withdra_Query + queryString_InsertPaymentPosting + lastId + Insert_Deposit_query;
            }
            else
            {
                query = queryString_Temporary_Table + queryString_InsertTemporaryTable + Insert_Cash_Deposit_query;
            }
            try
            {
                _dbConnection.ExecuteNonQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

//        public void Insert_IPO_Application_Charge(string[] Deposit_CustCode, double ChargeAmount, string Payemnt_Media, string TransferCode, string Voucher_No, string Trans_Reason, int IntendedIPOSessionID, string Remarks)
//        {
//            //Main Transaction Deposit ID
//            int Id = 0;
//            string PaymentID = "";
//            string lastId = "";
//            string Insert_Deposit_query = "";
//            if (dt.Rows.Count > 0)
//            {
//                Id = dt.Rows.Cast<DataRow>().Select(t => Convert.ToInt32(t[1])).FirstOrDefault();
//            }
//            string queryString_Temporary_Table = @"
//                                                    IF OBJECT_ID('tempdb..#Temp_IPOAcc') IS NOT NULL  
//													BEGIN 													 
//													DROP TABLE #Temp_IPOAcc
//													END
//                                                    CREATE TABLE #Temp_IPOAcc
//                                                    (
//                                                        ID  INT IDENTITY(1,1), 
//                                                        Cust_Code Varchar(100),
//                                                        Amount Money
//                                                        --,App_Trans_ID Varchar(100)                                                    
//                                                    );   
//                                            ";
//            string queryString_InsertTemporaryTable = string.Empty;
//            for (int i = 0; i < Deposit_CustCode.Length; i++)
//            {
//                string id = "";
//                if (dt.Rows.Count > 0)
//                {
//                    id = dt.Rows.Cast<DataRow>()
//                          .Where(t => Convert.ToString(t[0]) == Deposit_CustCode[i])
//                          .Select(t => Convert.ToString(t[1])).FirstOrDefault();
//                }
//                string queryString_InsertTemporaryTable_Temp = @"INSERT INTO #Temp_IPOAcc (Cust_Code,Amount) VALUES 
//                    ('" + Deposit_CustCode[i] + @"'," + ChargeAmount + @")
//                                    ";
//                queryString_InsertTemporaryTable = queryString_InsertTemporaryTable + queryString_InsertTemporaryTable_Temp;
//            }
//            string queryString_InsertPaymentPosting = string.Empty;
//            string Insert_Withdra_Query = "";
//            string Insert_Cash_Deposit_query = "";
//            if (Payemnt_Media == "TRIPO")
//            {
//                Insert_Withdra_Query = @"INSERT INTO [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction]
//                            (
//	                            [Cust_Code]
//                               ,[Received_Date]
//                               ,[Money_TransactionType_ID]
//                               ,[Money_TransactionType_Name]
//                               ,[Deposit_Withdraw]
//                               ,[Amount]
//                               ,[Voucher_No]
//                               ,[Trans_Reason]                               
//                               ,[Approval_Status]
//                               ,[Remarks]
//                               ,[Entry_Branch_ID]
//                               ,[Entry_Date]
//                               ,[Entry_By]
//                            )
//                            Values ( 
//                                '" + TransferCode + @"'
//                                ,'" + GlobalVariableBO._currentServerDate.Date + @"' /*AS Received_Date*/
//                                ,(    SELECT [ID]
//                                    FROM [SBP_Database].[dbo].[SBP_IPO_MoneyTrans_Type]
//                                    WHERE [MoneyTransType_Name]='" + Payemnt_Media + @"'
//                                ) /*AS Money_TransactionType_ID*/
//                                ,'" + Payemnt_Media + @"' /*AS Money_TransactionType_Name*/
//                                ,'Withdraw' /* AS Deposit_Withdraw */
//                                , " + ChargeAmount + @"/* AS Amount*/
//                                ,'" + Voucher_No + @"' /*AS Voucher_No*/
//                                ,'Charge From '+'" + TransferCode + "'+' To '+'" + (Deposit_CustCode.Length > 1 ? "MulitCustomers" : "" + Deposit_CustCode[0].ToString() + "") + @"' /*AS Trans_Reason*/ 
//                                
//                                ,0 /*AS Approval_Status*/
//                                 ,'" + Remarks + @"'
//                                ,'" + GlobalVariableBO._branchId + @"'
//                                ,GETDATE()/* AS Entry_Date*/
//                                ,'" + GlobalVariableBO._userName + @"'
//                            )
//                                    ";

//                //                   Insert_Deposit_query =
//                //                                           @"INSERT INTO [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction]
//                //                            (
//                //	                            [Cust_Code]
//                //                               ,[Received_Date]
//                //                               ,[Money_TransactionType_ID]
//                //                               ,[Money_TransactionType_Name]
//                //                               ,[Deposit_Withdraw]
//                //                               ,[Amount]
//                //                               ,[Voucher_No]
//                //                               ,[Trans_Reason]
//                //                               ,[Intended_IPOSession_ID]
//                //                               ,[Intended_IPOSession_Name]
//                //                               ,[Approval_Status]
//                //                               ,[Remarks]
//                //                               ,[Entry_Branch_ID]
//                //                               ,[Entry_Date]
//                //                               ,[Entry_By]
//                //                            )
//                //                            SELECT 
//                //                                Cust_Code
//                //                                ,'" + GlobalVariableBO._currentServerDate.ToShortDateString() + @"' AS Received_Date
//                //                                ,(    SELECT [ID]
//                //                                    FROM [SBP_Database].[dbo].[SBP_IPO_MoneyTrans_Type]
//                //                                    WHERE [MoneyTransType_Name]='" + Payemnt_Media + @"'
//                //                                ) AS Money_TransactionType_ID
//                //                                ,'" + Payemnt_Media + @"' AS Money_TransactionType_Name
//                //                                ,'Deposit' AS Deposit_Withdraw
//                //                                , Amount AS Amount
//                //                                ,'" + Voucher_No + @"' AS Voucher_No
//                //                                
//                //                                ,'"+Id.ToString()+@"+'_Charge From' +' " + TransferCode + @"'+' To '+Cust_Code +'_'+Convert(varchar(100),@lastScopeIdentity)" + @"                                  
//                //                                AS Trans_Reason
//                //                                ," + IntendedIPOSessionID + @" AS Intended_IPOSession_ID
//                //                                ,( 
//                //                                        SELECT  [IPOSession_Name]
//                //                                        FROM [SBP_Database].[dbo].[SBP_IPO_Session]
//                //                                        WHERE [ID]=" + IntendedIPOSessionID + @"
//                //                                ) AS Intended_IPOSession_Name
//                //                                ,0 AS Approval_Status
//                //                                 ,'" + Remarks + @"'
//                //                                ,'" + GlobalVariableBO._branchId + @"'
//                //                                ,GETDATE() AS Entry_Date
//                //                                ,'" + GlobalVariableBO._userName + @"'
//                //                            FROM #Temp_IPOAcc 
//                //                            ORDER BY ID                            
//                //                                    ";
//            }

//            else if (Payemnt_Media == "TRTA")
//            {
//                //Insert Payment Posting

//                queryString_InsertPaymentPosting = @"INSERT INTO [SBP_Database].[dbo].[SBP_Payment_Posting_Request]
//                                (
//	                                [Cust_Code]
//                                   ,[Amount]
//                                   ,[Received_Date]
//                                   ,[Payment_Media]
//                                   ,[Received_By]
//                                   ,[Deposit_Withdraw]
//                                   ,[Vouchar_SN]
//                                   ,[Trans_Reason]
//                                   ,[Remarks]
//                                   ,[Entry_Date]
//                                   ,[Entry_By]
//                                   ,[Approval_Status]
//                                   ,[Entry_Branch_ID]
//                                )
//
//                           VALUES( 
//                                
//                                '" + TransferCode + @"'
//                                ," + ChargeAmount + @" /*AS Amount*/
//                                ,'" + GlobalVariableBO._currentServerDate.Date.ToShortDateString() + @"' /*AS Received_Date*/
//                                ,'TRIPO' /*AS Payment_Media*/
//                                ,'" + GlobalVariableBO._userName + @"' /*AS Received_By*/
//                                ,'Withdraw' /*AS Deposit_Withdraw*/
//                                ,'" + Voucher_No + @"' /*AS Voucher_No*/
//                                ,'Charge From '+'" + TransferCode + "'+' To '+'" + (Deposit_CustCode.Length > 1 ? "MulitCustomers" : "" + Deposit_CustCode[0].ToString() + "") + @"' /*AS Trans_Reason*/
//                                ,'" + Remarks + @"' /*AS Remarks*/
//                                ,CONVERT(Varchar(10),GETDATE(),111) /*AS Entry_Date*/
//                                ,'" + GlobalVariableBO._userName + @"'
//                                ,0 /*AS Approval_Status*/
//                                ," + GlobalVariableBO._branchId + @"
//                           )";

//                //PaymentID = "Declare @PaymentID int "+
//                //                "Set @PaymentID=(Select IDENT_CURRENT('SBP_Payment_Posting_Request'))"
//                //            ;

//            }
//            else
//            {
//                Insert_Cash_Deposit_query =
//                             @"INSERT INTO [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction]
//                            (
//	                            [Cust_Code]
//                               ,[Received_Date]
//                               ,[Money_TransactionType_ID]
//                               ,[Money_TransactionType_Name]
//                               ,[Deposit_Withdraw]
//                               ,[Amount]
//                               ,[Voucher_No]
//                               ,[Trans_Reason]
//                               ,[Intended_IPOSession_ID]
//                               ,[Intended_IPOSession_Name]
//                               ,[Approval_Status]
//                               ,[Remarks]
//                               ,[Entry_Branch_ID]
//                               ,[Entry_Date]
//                               ,[Entry_By]
//                            )
//                            SELECT 
//                                Cust_Code
//                                ,'" + GlobalVariableBO._currentServerDate.ToShortDateString() + @"' AS Received_Date
//                                ,(    SELECT [ID]
//                                    FROM [SBP_Database].[dbo].[SBP_IPO_MoneyTrans_Type]
//                                    WHERE [MoneyTransType_Name]='" + Payemnt_Media + @"'
//                                ) AS Money_TransactionType_ID
//                                ,'" + Payemnt_Media + @"' AS Money_TransactionType_Name
//                                ,'Deposit' AS Deposit_Withdraw
//                                , Amount AS Amount
//                                ,'" + Voucher_No + @"' AS Voucher_No
//                                ,'" + Id + @"'+'_Charge For IPO Application' /*AS Trans_Reason*/                                
//                                ," + IntendedIPOSessionID + @" AS Intended_IPOSession_ID
//                                ,( 
//                                        SELECT  [IPOSession_Name]
//                                        FROM [SBP_Database].[dbo].[SBP_IPO_Session]
//                                        WHERE [ID]=" + IntendedIPOSessionID + @"
//                                ) AS Intended_IPOSession_Name
//                                ,0 AS Approval_Status
//                                 ,'" + Remarks + @"'
//                                ,'" + GlobalVariableBO._branchId + @"'
//                                ,GETDATE() AS Entry_Date
//                                ,'" + GlobalVariableBO._userName + @"'
//                            FROM #Temp_IPOAcc 
//                            ORDER BY ID
//                            ";
//            }

//            lastId = @" declare @lastScopeIdentity int
//                            set @lastScopeIdentity=(select scope_identity())
//                            ";
//            Insert_Deposit_query =
//                                        @"INSERT INTO [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction]
//                            (
//	                            [Cust_Code]
//                               ,[Received_Date]
//                               ,[Money_TransactionType_ID]
//                               ,[Money_TransactionType_Name]
//                               ,[Deposit_Withdraw]
//                               ,[Amount]
//                               ,[Voucher_No]
//                               ,[Trans_Reason]
//                               ,[Intended_IPOSession_ID]
//                               ,[Intended_IPOSession_Name]
//                               ,[Approval_Status]
//                               ,[Remarks]
//                               ,[Entry_Branch_ID]
//                               ,[Entry_Date]
//                               ,[Entry_By]
//                            )
//                            SELECT 
//                                Cust_Code
//                                ,'" + GlobalVariableBO._currentServerDate.ToShortDateString() + @"' AS Received_Date
//                                ,(    SELECT [ID]
//                                    FROM [SBP_Database].[dbo].[SBP_IPO_MoneyTrans_Type]
//                                    WHERE [MoneyTransType_Name]='" + Payemnt_Media + @"'
//                                ) AS Money_TransactionType_ID
//                                ,'" + Payemnt_Media + @"' AS Money_TransactionType_Name
//                                ,'Deposit' AS Deposit_Withdraw
//                                , Amount AS Amount
//                                ,'" + Voucher_No + @"' AS Voucher_No
//                                
//                                ,'" + Id + @"'+'_Charge From' +' " + TransferCode + @"'+' To '+Cust_Code +'_'+Convert(varchar(100),@lastScopeIdentity)" + @"                                  
//                                AS Trans_Reason
//                                ," + IntendedIPOSessionID + @" AS Intended_IPOSession_ID
//                                ,( 
//                                        SELECT  [IPOSession_Name]
//                                        FROM [SBP_Database].[dbo].[SBP_IPO_Session]
//                                        WHERE [ID]=" + IntendedIPOSessionID + @"
//                                ) AS Intended_IPOSession_Name
//                                ,0 AS Approval_Status
//                                 ,'" + Remarks + @"'
//                                ,'" + GlobalVariableBO._branchId + @"'
//                                ,GETDATE() AS Entry_Date
//                                ,'" + GlobalVariableBO._userName + @"'
//                            FROM #Temp_IPOAcc 
//                            ORDER BY ID                            
//                                    ";

//            string query = "";
//            if (Payemnt_Media == "TRTA" || Payemnt_Media == "TRIPO")
//            {
//                query = queryString_Temporary_Table + queryString_InsertTemporaryTable + Insert_Withdra_Query + queryString_InsertPaymentPosting + PaymentID + lastId + Insert_Deposit_query;
//            }
//            else
//            {
//                query = queryString_Temporary_Table + queryString_InsertTemporaryTable + Insert_Cash_Deposit_query;
//            }
//            try
//            {
//                _dbConnection.ExecuteNonQuery(query);
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }

        public DataTable Insert_Transfer_IPO_To_IPO_DepositMoneyTransaction_UITransApplied(string Trans_Cust_Code_IPOAcc, string[] Details_CustCode_IPOAcc, double Amount_TransCustCode, double[] Amount_Details_CustCode, string Deposit_Withdraw_TransCustCode, string Deposit_Withdraw_Details_CustCode, DateTime ReceivedDate, string VoucherNo, string Remarks, int IntendedIPOSessionID, string Charge_For_IPO_Application,int[] ChannelID,string[] ChannelType)
        {
            CommonBAL comBal = new CommonBAL();
            DateTime TodayServerDate = comBal.GetCurrentServerDate();
            string PaymentMethod = Indication_IPOPaymentTransaction.TRTA;
            string PaymentMethodForIPOtoIPO = Indication_PaymentTransaction.TRIPO;
            DataTable dt = new DataTable();


            string queryString_GetTemporaryTable_NewInsertDetails = @"
                                                            Select * 
                                                            From #Temp_IPOAcc_NewInsert
                ";

            string queryString_TemporaryTable = @"
                                                 CREATE TABLE #Temp_IPOAcc(
                                                    ID  INT IDENTITY(1,1), 
                                                    Cust_Code Varchar(100),
                                                    Amount Money,
                                                    Deposit_Withdraw Varchar(100),
                                                    ChannelID INT,
                                                    ChannelType Varchar(150)
                                                 );   
            ";
            string queryString_TemporaryTable_NewInsertDetails = @"
                                                                    CREATE TABLE #Temp_IPOAcc_NewInsert(
                                                                       Cust_Code varchar(100),
                                                                       Trans_ID INT
                                                                    );
            ";

            string queryString_InsertTemporaryTable = string.Empty;

            for (int i = 0; i < Details_CustCode_IPOAcc.Length; i++)
            {
                string queryString_InsertTemporaryTable_Temp = @"INSERT INTO #Temp_IPOAcc (Cust_Code,Amount,Deposit_Withdraw,ChannelID,ChannelType) VALUES('" + Details_CustCode_IPOAcc[i] + @"'," + Amount_Details_CustCode[i] + @",'" + Deposit_Withdraw_Details_CustCode + @"'," + Convert.ToString(ChannelID.Length > 0 ? ChannelID[i] : 0) + @",'" + Convert.ToString(ChannelType.Length>0?ChannelType[i]:string.Empty) + @"');
                ";
                queryString_InsertTemporaryTable = queryString_InsertTemporaryTable + queryString_InsertTemporaryTable_Temp;
            }

            //Transfer Direction
            string TransferDirection_TransCustCode = string.Empty;
            if (Deposit_Withdraw_TransCustCode == Indication_PaymentMode.Deposit)
                TransferDirection_TransCustCode = "From ";
            else
                TransferDirection_TransCustCode = "To ";

            string TransferDirection_DetailsCustCode = string.Empty;
            if (Deposit_Withdraw_Details_CustCode == Indication_PaymentMode.Deposit)
                TransferDirection_DetailsCustCode = "From ";
            else
                TransferDirection_DetailsCustCode = "To ";

            
            // TransCode Transaction
            string queryString_InsertTransCode = string.Empty;
            //if (Deposit_Withdraw_TransCustCode == Indication_PaymentMode.Deposit)
            //{
                queryString_InsertTransCode = @"INSERT INTO [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction]
                                               ([Cust_Code]
                                               ,[Received_Date]
                                               ,[Money_TransactionType_ID]
                                               ,[Money_TransactionType_Name]
                                               ,[Deposit_Withdraw]
                                               ,[Amount]
                                               ,[Voucher_No]
                                               ,[Trans_Reason]
                                               ,[Remarks]
                                                ,[Channel]
                                                ,[ChannelID]
                                                ,[Approval_Status]
                                               ,[Entry_Branch_ID]
                                               ,[Entry_Date]
                                               ,[Entry_By])

                           VALUES( 
                                                                
                                '" + Trans_Cust_Code_IPOAcc + @"'                                
                                ,'" + ReceivedDate.ToShortDateString() + @"' /*AS Received_Date*/
                                ,(    SELECT [ID]
                                    FROM [SBP_Database].[dbo].[SBP_IPO_MoneyTrans_Type]
                                    WHERE [MoneyTransType_Name]='" + PaymentMethodForIPOtoIPO + @"'
                                )/* AS Money_TransactionType_ID*/
                                ,'" + PaymentMethodForIPOtoIPO + @"' /*AS Money_TransactionType_Name*/
                                ,'" + Deposit_Withdraw_TransCustCode + @"' /*AS Deposit_Withdraw*/
                                ," + Amount_TransCustCode + @" /*AS Amount*/  
                                ,'" + VoucherNo + @"' /*AS Voucher_No*/
                                ,'" + Trans_Cust_Code_IPOAcc + " " + TransferDirection_TransCustCode + " " + (Details_CustCode_IPOAcc.Length > 1 ? "MulitCustomers" : "" + Details_CustCode_IPOAcc[0].ToString() + "") + @"' /*AS Trans_Reason*/ 
                                ,'" + Remarks + @"' /*AS Remarks*/  
                                ,''
                                ,0
                                ,0 /*AS Approval_Status */
                                ," + GlobalVariableBO._branchId + @"                        
                                 
                                ,CONVERT(Varchar(10),GETDATE(),111) /*AS Entry_Date*/
                                ,'" + GlobalVariableBO._userName + @"'                                
                                
                           )";
 
            string lastId = @" declare @lastScopeIdentity int
                            set @lastScopeIdentity=(select scope_identity()) ";


            //Details IPO Code Transaction
            string queryString_InsertDetailsCode = string.Empty;
            //if (Deposit_Withdraw_Details_CustCode == Indication_PaymentMode.Deposit)
            //{
                queryString_InsertDetailsCode = @"INSERT INTO [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction]
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
                               ,[Channel]
                               ,[ChannelID]
                               ,[Approval_Status]
                               ,[Remarks]
                               ,[Entry_Branch_ID]
                               ,[Entry_Date]
                               ,[Entry_By]
                            )
                            SELECT 
                                Cust_Code
                                ,'" + ReceivedDate.ToShortDateString() + @"' AS Received_Date
                                ,(    SELECT [ID]
                                    FROM [SBP_Database].[dbo].[SBP_IPO_MoneyTrans_Type]
                                    WHERE [MoneyTransType_Name]='" + PaymentMethodForIPOtoIPO + @"'
                                ) AS Money_TransactionType_ID
                                ,'" + PaymentMethodForIPOtoIPO + @"' AS Money_TransactionType_Name
                                ,Deposit_Withdraw AS Deposit_Withdraw
                                , Amount AS Amount
                                ,'" + VoucherNo + @"' AS Voucher_No
                                ,(
                                    CASE 
                                        WHEN Deposit_Withdraw='Deposit' THEN " + "[Cust_Code]+ '" + @" " + TransferDirection_DetailsCustCode + @" " + Trans_Cust_Code_IPOAcc + @"'" + "+'_'+Convert(varchar(100),@lastScopeIdentity)" + @" 
                                        WHEN Deposit_Withdraw='Withdraw' THEN " + "[Cust_Code]+'" + @" " + TransferDirection_DetailsCustCode + @" " + Trans_Cust_Code_IPOAcc + @"'" + "+'_'+Convert(varchar(100),@lastScopeIdentity)" + @" 
                                    END
                                )AS Trans_Reason
                                ," + IntendedIPOSessionID + @" AS Intended_IPOSession_ID
                                ,( 
                                        SELECT  [IPOSession_Name]
                                        FROM [SBP_Database].[dbo].[SBP_IPO_Session]
                                        WHERE [ID]=" + IntendedIPOSessionID + @"
                                ) AS Intended_IPOSession_Name
                                ,ChannelType
                                ,ChannelID
                                ,0 AS Approval_Status
                                ,'" + Remarks + @"'
                                ,'" + GlobalVariableBO._branchId + @"'
                                ,GETDATE() AS Entry_Date
                                ,'" + GlobalVariableBO._userName + @"'
                            FROM #Temp_IPOAcc 
                            ORDER BY ID
                            
                            DECLARE @First_Identity INT                            

                            SET @First_Identity=(
                                                    Select Scope_Identity()-(IDENT_INCR('SBP_IPO_Customer_Broker_MoneyTransaction')*@@Rowcount-1)
                            )                               
                        
                            ";
           
            
 
 
            string query_Insert_TemporaryTable_NewInsertDetails = string.Empty;
//            query_Insert_TemporaryTable_NewInsertDetails = @"
//                                                            IF('" + Deposit_Withdraw_Details_CustCode + "' = '" + Indication_PaymentMode.Deposit + @"')
//                                                            BEGIN 
//                
//                                                                INSERT INTO #Temp_IPOAcc_NewInsert(Cust_Code,Trans_ID)
//                                                                Select Cust_Code,@First_Identity+(ID-1)
//                                                                From  #Temp_IPOAcc
//                                                                ORDER BY ID     
//
//                                                            END 
//                                                            ELSE IF('" + Deposit_Withdraw_Details_CustCode + "' = '" + Indication_PaymentMode.Withdraw + @"')
//                                                            BEGIN 
//                
//                                                                INSERT INTO #Temp_IPOAcc_NewInsert(Cust_Code,Trans_ID)
//                                                                Select Cust_Code,@First_Identity+(ID-1)
//                                                                From  #Temp_IPOAcc
//                                                                ORDER BY ID     
//
//                                                            END ";

            query_Insert_TemporaryTable_NewInsertDetails = @"   INSERT INTO #Temp_IPOAcc_NewInsert(Cust_Code,Trans_ID)
                                                                Select Cust_Code,@First_Identity+(ID-1)
                                                                From  #Temp_IPOAcc
                                                                ORDER BY ID     
                                                            ";

            //Concat All Query
            
               string  queryString = queryString_TemporaryTable + queryString_TemporaryTable_NewInsertDetails + queryString_InsertTemporaryTable + queryString_InsertTransCode + lastId + queryString_InsertDetailsCode + query_Insert_TemporaryTable_NewInsertDetails;
           
            try
            {


                //Transcode Withdraw
                //Ipo Account Withdraw
                //TransCode Deposit
                //Ipo Account Deposit

                //_dbConnection.ConnectDatabase();
                // _dbConnection.StartTransaction();
                //_dbConnection.ExecuteNonQuery(queryString_TemporaryTable);
                //_dbConnection.ExecuteNonQuery(queryString_InsertTemporaryTable);
                //_dbConnection.ExecuteNonQuery(queryString_InsertIPOAcc);
                _dbConnection.ExecuteNonQuery(queryString);
                dt = _dbConnection.ExecuteQuery(queryString_GetTemporaryTable_NewInsertDetails);
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
            return dt;
        }


        public DataTable Insert_NonTransfer_MoneyTransaction(string[] CustCode_IPOAcc, double[] Amount_IPOAcc, string Deposit_Withdraw_IPOAcc, DateTime ReceivedDate, int PaymentMethod_ID, string PaymentMethodName, string VoucherNo, string Trans_Reason, string Remarks, int IntendedIPOSessionID)
        {
            CommonBAL comBal = new CommonBAL();
            DateTime TodayServerDate = comBal.GetCurrentServerDate();

            DataTable Dt = new DataTable();


            try
            {
                //_dbConnection.ConnectDatabase();
                // _dbConnection.StartTransaction();
                //                for (int i = 0; i < CustCode_IPOAcc.Length; i++)
                //                {
                //                    string queryString_InsertIPOAcc = "";
                //                    queryString_InsertIPOAcc = @"
                //    
                //                             DECLARE @SessionName Varchar(100)
                //                             SET @SessionName=( 
                //                                        SELECT  [IPOSession_Name]
                //                                        FROM [SBP_Database].[dbo].[SBP_IPO_Session]
                //                                        WHERE [ID]=" + IntendedIPOSessionID + @"
                //                                )
                //
                //                             INSERT INTO [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction]
                //                             ( 
                //	                            [Cust_Code]
                //                               ,[Received_Date]
                //                               ,[Money_TransactionType_ID]
                //                               ,[Money_TransactionType_Name]
                //                               ,[Deposit_Withdraw]
                //                               ,[Amount]
                //                               ,[Voucher_No]
                //                               ,[Trans_Reason]
                //                               ,[Intended_IPOSession_ID]
                //                               ,[Intended_IPOSession_Name]
                //                               ,[Approval_Status]
                //                               ,[Entry_Date]
                //                               ,[Entry_By]
                //                             )
                //                             VALUES(
                //                                '" + CustCode_IPOAcc[i] + @"'
                //                                ,'" + ReceivedDate.ToShortDateString() + @"' /*AS Received_Date*/
                //                                ," + PaymentMethod_ID + @"  /*AS Money_TransactionType_Name*/
                //                                ,'" + PaymentMethodName + @"' /*AS Money_TransactionType_ID*/
                //                                ,'" + Deposit_Withdraw_IPOAcc + @"' /*AS Deposit_Withdraw*/
                //                                ," + Amount_IPOAcc[i] + @" /*AS Amount*/
                //                                ,'" + VoucherNo + @"' /*AS Voucher_No*/
                //                                ,'" + string.Empty + @"' /*AS Trans_Reason*/
                //                                ," + IntendedIPOSessionID + @" /*AS Intended_IPOSession_ID*/
                //                                ,@SessionName /*AS Intended_IPOSession_Name*/
                //                                ,0 /*AS Approval_Status*/
                //                                ,GETDATE() /*AS Entry_Date*/
                //                                ,'" + GlobalVariableBO._userName + @"'
                //                            )";
                //                    _dbConnection.ExecuteNonQuery(queryString_InsertIPOAcc);
                //                }

                //_dbConnection.Commit();


                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();
                string queryString_CreateTempIdentityTable = @"
                IF OBJECT_ID('tempdb..#temp') IS NOT NULL
                BEGIN
                    DROP TABLE #temp
                END
                Create table #temp
                             (
	                            Cust_Code Varchar(100),
	                            Last_Scope_Id int,
                             )";
                string queryString_GetTempIdentityTable = @"
                                                            Select * 
                                                            From #temp
                ";



                _dbConnection.ExecuteNonQuery(queryString_CreateTempIdentityTable);


                for (int i = 0; i < CustCode_IPOAcc.Length; i++)
                {


                    string queryString_InsertIPOAcc = "";
                    queryString_InsertIPOAcc = @"
    
                             DECLARE @SessionName Varchar(100)
                             SET @SessionName=( 
                                        SELECT  [IPOSession_Name]
                                        FROM [SBP_Database].[dbo].[SBP_IPO_Session]
                                        WHERE [ID]=" + IntendedIPOSessionID + @"
                                )

                             INSERT INTO [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction]
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
                               ,[Remarks]
                               ,[Entry_Branch_ID]
                               ,[Entry_Date]
                               ,[Entry_By]
                             )
                             VALUES(
                                '" + CustCode_IPOAcc[i] + @"'
                                ,'" + ReceivedDate.ToShortDateString() + @"' /*AS Received_Date*/
                                ," + PaymentMethod_ID + @"  /*AS Money_TransactionType_Name*/
                                ,'" + PaymentMethodName + @"' /*AS Money_TransactionType_ID*/
                                ,'" + Deposit_Withdraw_IPOAcc + @"' /*AS Deposit_Withdraw*/
                                ," + Amount_IPOAcc[i] + @" /*AS Amount*/
                                ,'" + VoucherNo + @"' /*AS Voucher_No*/
                                ,'" + Trans_Reason + @"' /*AS Trans_Reason*/
                                ," + IntendedIPOSessionID + @" /*AS Intended_IPOSession_ID*/
                                ,@SessionName /*AS Intended_IPOSession_Name*/
                                ,0 /*AS Approval_Status*/
                                ,'"+Remarks+@"'
                                ,'" + GlobalVariableBO._branchId + @"'
                                ,GETDATE() /*AS Entry_Date*/
                                ,'" + GlobalVariableBO._userName + @"'
                            )
                            DECLARE @ScopeIdent_TransID INT
                            SET @ScopeIdent_TransID=( SELECT SCOPE_IDENTITY())
                            
                            IF('" + Deposit_Withdraw_IPOAcc + @"'='" + Indication_PaymentMode.Deposit + @"')
                            BEGIN
                                    INSERT INTO #temp (Cust_Code,Last_Scope_Id)
                                    VALUES
                                    (
                                       '" + CustCode_IPOAcc[i] + @"'
                                       ,@ScopeIdent_TransID 
	                                ) 
                            END ";
                    _dbConnection.ExecuteNonQuery(queryString_InsertIPOAcc);
                }

                Dt = _dbConnection.ExecuteQuery(queryString_GetTempIdentityTable, _dbConnection.GetTransaction());

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

            return Dt;
        }
        

//        public DataTable Insert_NonTransfer_MoneyTransaction_UITransApplied(string[] CustCode_IPOAcc, double[] Amount_IPOAcc, string Deposit_Withdraw_IPOAcc, DateTime ReceivedDate, int PaymentMethod_ID, string PaymentMethodName, string VoucherNo,string Trans_Reason,string Remarks, int IntendedIPOSessionID,int[] ChannelID,string[] ChannelType)
//        {

//            CommonBAL comBal = new CommonBAL();
//            DateTime TodayServerDate = comBal.GetCurrentServerDate();
          
//            DataTable Dt = new DataTable();


//            try
//            {
//                //_dbConnection.ConnectDatabase();
//               // _dbConnection.StartTransaction();
////                for (int i = 0; i < CustCode_IPOAcc.Length; i++)
////                {
////                    string queryString_InsertIPOAcc = "";
////                    queryString_InsertIPOAcc = @"
////    
////                             DECLARE @SessionName Varchar(100)
////                             SET @SessionName=( 
////                                        SELECT  [IPOSession_Name]
////                                        FROM [SBP_Database].[dbo].[SBP_IPO_Session]
////                                        WHERE [ID]=" + IntendedIPOSessionID + @"
////                                )
////
////                             INSERT INTO [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction]
////                             ( 
////	                            [Cust_Code]
////                               ,[Received_Date]
////                               ,[Money_TransactionType_ID]
////                               ,[Money_TransactionType_Name]
////                               ,[Deposit_Withdraw]
////                               ,[Amount]
////                               ,[Voucher_No]
////                               ,[Trans_Reason]
////                               ,[Intended_IPOSession_ID]
////                               ,[Intended_IPOSession_Name]
////                               ,[Approval_Status]
////                               ,[Entry_Date]
////                               ,[Entry_By]
////                             )
////                             VALUES(
////                                '" + CustCode_IPOAcc[i] + @"'
////                                ,'" + ReceivedDate.ToShortDateString() + @"' /*AS Received_Date*/
////                                ," + PaymentMethod_ID + @"  /*AS Money_TransactionType_Name*/
////                                ,'" + PaymentMethodName + @"' /*AS Money_TransactionType_ID*/
////                                ,'" + Deposit_Withdraw_IPOAcc + @"' /*AS Deposit_Withdraw*/
////                                ," + Amount_IPOAcc[i] + @" /*AS Amount*/
////                                ,'" + VoucherNo + @"' /*AS Voucher_No*/
////                                ,'" + string.Empty + @"' /*AS Trans_Reason*/
////                                ," + IntendedIPOSessionID + @" /*AS Intended_IPOSession_ID*/
////                                ,@SessionName /*AS Intended_IPOSession_Name*/
////                                ,0 /*AS Approval_Status*/
////                                ,GETDATE() /*AS Entry_Date*/
////                                ,'" + GlobalVariableBO._userName + @"'
////                            )";
////                    _dbConnection.ExecuteNonQuery(queryString_InsertIPOAcc);
////                }

//                //_dbConnection.Commit();


//                //_dbConnection.ConnectDatabase();
//                //_dbConnection.StartTransaction();
//                string queryString_CreateTempIdentityTable = @"
//                IF OBJECT_ID('tempdb..#temp') IS NOT NULL
//                BEGIN
//                    DROP TABLE #temp
//                END
//                            Create table #temp
//                             (
//	                            Cust_Code Varchar(100),
//	                            Last_Scope_Id int,
//                             )";
//                string queryString_GetTempIdentityTable = @"
//                                                            Select * 
//                                                            From #temp
//                ";
                


//                _dbConnection.ClearParameters();
//                _dbConnection.ExecuteNonQuery(queryString_CreateTempIdentityTable);


//                for (int i = 0; i < CustCode_IPOAcc.Length; i++)
//                {


//                    string queryString_InsertIPOAcc = "";
//                    queryString_InsertIPOAcc = @"
//    
//                             DECLARE @SessionName Varchar(100)
//                             SET @SessionName=( 
//                                        SELECT  [IPOSession_Name]
//                                        FROM [SBP_Database].[dbo].[SBP_IPO_Session]
//                                        WHERE [ID]=" + IntendedIPOSessionID + @"
//                                )
//
//                             INSERT INTO [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction]
//                             ( 
//	                            [Cust_Code]
//                               ,[Received_Date]
//                               ,[Money_TransactionType_ID]
//                               ,[Money_TransactionType_Name]
//                               ,[Deposit_Withdraw]
//                               ,[Amount]
//                               ,[Voucher_No]
//                               ,[Trans_Reason]
//                               ,[Intended_IPOSession_ID]
//                               ,[Intended_IPOSession_Name]
//                               ,[Approval_Status]
//                               ,[Remarks]
//                               ,[Channel]
//                               ,[ChannelID]
//                               ,[Entry_Branch_ID]
//                               ,[Entry_Date]
//                               ,[Entry_By]
//                             )
//                             VALUES(
//                                '" + CustCode_IPOAcc[i] + @"'
//                                ,'" + ReceivedDate.ToShortDateString() + @"' /*AS Received_Date*/
//                                ," + PaymentMethod_ID + @"  /*AS Money_TransactionType_Name*/
//                                ,'" + PaymentMethodName + @"' /*AS Money_TransactionType_ID*/
//                                ,'" + Deposit_Withdraw_IPOAcc + @"' /*AS Deposit_Withdraw*/
//                                ," + Amount_IPOAcc[i] + @" /*AS Amount*/
//                                ,'" + VoucherNo + @"' /*AS Voucher_No*/
//                                ,'" + Trans_Reason + @"' /*AS Trans_Reason*/
//                                ," + IntendedIPOSessionID + @" /*AS Intended_IPOSession_ID*/
//                                ,@SessionName /*AS Intended_IPOSession_Name*/
//                                ,0 /*AS Approval_Status*/
//                                ,'"+ChannelType[i]+@"'
//                                ,"+ChannelID[i]+@"                                
//                                ,'" +Remarks+@"'
//                                ,'" + GlobalVariableBO._branchId + @"'
//                                ,GETDATE() /*AS Entry_Date*/
//                                ,'" + GlobalVariableBO._userName + @"'
//                            )
//                            DECLARE @ScopeIdent_TransID INT
//                            SET @ScopeIdent_TransID=( SELECT SCOPE_IDENTITY())
//                            
//                            IF('" + Deposit_Withdraw_IPOAcc + @"'='" + Indication_PaymentMode.Deposit + @"')
//                            BEGIN
//                                    INSERT INTO #temp (Cust_Code,Last_Scope_Id)
//                                    VALUES
//                                    (
//                                       '" + CustCode_IPOAcc[i] + @"'
//                                       ,@ScopeIdent_TransID 
//	                                ) 
//                            END ";
//                    _dbConnection.ExecuteNonQuery(queryString_InsertIPOAcc);
//                }

//                Dt = _dbConnection.ExecuteQuery(queryString_GetTempIdentityTable);

//                // _dbConnection.Commit();


//            }
//            catch (Exception)
//            {
//               // _dbConnection.Rollback();
//                throw;
//            }
//            //finally
//            //{
//            //    _dbConnection.CloseDatabase();
//            //}

//            return Dt;

//        }

        public DataTable Insert_NonTransfer_MoneyTransaction_UITransApplied(string[] CustCode_IPOAcc, double[] Amount_IPOAcc, string Deposit_Withdraw_IPOAcc, DateTime ReceivedDate, int PaymentMethod_ID, string PaymentMethodName, string VoucherNo, string Trans_Reason, string Remarks, int IntendedIPOSessionID, int[] ChannelID, string[] ChannelType)
        {

            CommonBAL comBal = new CommonBAL();
            DateTime TodayServerDate = comBal.GetCurrentServerDate();

            DataTable Dt = new DataTable();


            try
            {
                //_dbConnection.ConnectDatabase();
                // _dbConnection.StartTransaction();
                //                for (int i = 0; i < CustCode_IPOAcc.Length; i++)
                //                {
                //                    string queryString_InsertIPOAcc = "";
                //                    queryString_InsertIPOAcc = @"
                //    
                //                             DECLARE @SessionName Varchar(100)
                //                             SET @SessionName=( 
                //                                        SELECT  [IPOSession_Name]
                //                                        FROM [SBP_Database].[dbo].[SBP_IPO_Session]
                //                                        WHERE [ID]=" + IntendedIPOSessionID + @"
                //                                )
                //
                //                             INSERT INTO [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction]
                //                             ( 
                //	                            [Cust_Code]
                //                               ,[Received_Date]
                //                               ,[Money_TransactionType_ID]
                //                               ,[Money_TransactionType_Name]
                //                               ,[Deposit_Withdraw]
                //                               ,[Amount]
                //                               ,[Voucher_No]
                //                               ,[Trans_Reason]
                //                               ,[Intended_IPOSession_ID]
                //                               ,[Intended_IPOSession_Name]
                //                               ,[Approval_Status]
                //                               ,[Entry_Date]
                //                               ,[Entry_By]
                //                             )
                //                             VALUES(
                //                                '" + CustCode_IPOAcc[i] + @"'
                //                                ,'" + ReceivedDate.ToShortDateString() + @"' /*AS Received_Date*/
                //                                ," + PaymentMethod_ID + @"  /*AS Money_TransactionType_Name*/
                //                                ,'" + PaymentMethodName + @"' /*AS Money_TransactionType_ID*/
                //                                ,'" + Deposit_Withdraw_IPOAcc + @"' /*AS Deposit_Withdraw*/
                //                                ," + Amount_IPOAcc[i] + @" /*AS Amount*/
                //                                ,'" + VoucherNo + @"' /*AS Voucher_No*/
                //                                ,'" + string.Empty + @"' /*AS Trans_Reason*/
                //                                ," + IntendedIPOSessionID + @" /*AS Intended_IPOSession_ID*/
                //                                ,@SessionName /*AS Intended_IPOSession_Name*/
                //                                ,0 /*AS Approval_Status*/
                //                                ,GETDATE() /*AS Entry_Date*/
                //                                ,'" + GlobalVariableBO._userName + @"'
                //                            )";
                //                    _dbConnection.ExecuteNonQuery(queryString_InsertIPOAcc);
                //                }

                //_dbConnection.Commit();


                //_dbConnection.ConnectDatabase();
                //_dbConnection.StartTransaction();
                string queryString_CreateTempIdentityTable = @"
                IF OBJECT_ID('tempdb..#temp') IS NOT NULL
                BEGIN
                    DROP TABLE #temp
                END
                            Create table #temp
                             (
	                            Cust_Code Varchar(100),
	                            Last_Scope_Id int,
                             )";
                string queryString_GetTempIdentityTable = @"
                                                            Select * 
                                                            From #temp
                ";



                _dbConnection.ClearParameters();
                _dbConnection.ExecuteNonQuery(queryString_CreateTempIdentityTable);


                for (int i = 0; i < CustCode_IPOAcc.Length; i++)
                {


                    string queryString_InsertIPOAcc = "";
                    queryString_InsertIPOAcc = @"
    
                             DECLARE @SessionName Varchar(100)
                             SET @SessionName=( 
                                        SELECT  [IPOSession_Name]
                                        FROM [SBP_Database].[dbo].[SBP_IPO_Session]
                                        WHERE [ID]=" + IntendedIPOSessionID + @"
                                )

                             INSERT INTO [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction]
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
                               ,[Remarks]
                               ,[Channel]
                               ,[ChannelID]
                               ,[Entry_Branch_ID]
                               ,[Entry_Date]
                               ,[Entry_By]
                             )
                             VALUES(
                                '" + CustCode_IPOAcc[i] + @"'
                                ,'" + ReceivedDate.ToShortDateString() + @"' /*AS Received_Date*/
                                ," + PaymentMethod_ID + @"  /*AS Money_TransactionType_Name*/
                                ,'" + PaymentMethodName + @"' /*AS Money_TransactionType_ID*/
                                ,'" + Deposit_Withdraw_IPOAcc + @"' /*AS Deposit_Withdraw*/
                                ," + Amount_IPOAcc[i] + @" /*AS Amount*/
                                ,'" + VoucherNo + @"' /*AS Voucher_No*/
                                ,'" + Trans_Reason + @"' /*AS Trans_Reason*/
                                ," + IntendedIPOSessionID + @" /*AS Intended_IPOSession_ID*/
                                ,@SessionName /*AS Intended_IPOSession_Name*/
                                ,0 /*AS Approval_Status*/
                                ,'" + Remarks + @"'                               
                                ,'" + ChannelType[i] + @"'
                                ," + ChannelID[i] + @"                              
                                ,'" + GlobalVariableBO._branchId + @"'
                                ,GETDATE() /*AS Entry_Date*/
                                ,'" + GlobalVariableBO._userName + @"'
                            )
                            DECLARE @ScopeIdent_TransID INT
                            SET @ScopeIdent_TransID=( SELECT SCOPE_IDENTITY())
                            
                            IF('" + Deposit_Withdraw_IPOAcc + @"'='" + Indication_PaymentMode.Deposit + @"')
                            BEGIN
                                    INSERT INTO #temp (Cust_Code,Last_Scope_Id)
                                    VALUES
                                    (
                                       '" + CustCode_IPOAcc[i] + @"'
                                       ,@ScopeIdent_TransID 
	                                ) 
                            END ";
                    _dbConnection.ExecuteNonQuery(queryString_InsertIPOAcc);
                }

                Dt = _dbConnection.ExecuteQuery(queryString_GetTempIdentityTable);

                // _dbConnection.Commit();


            }
            catch (Exception)
            {
                // _dbConnection.Rollback();
                throw;
            }
            //finally
            //{
            //    _dbConnection.CloseDatabase();
            //}

            return Dt;

        }


        public void Insert_Return_NonTransfer_MoneyTransaction(string[] CustCode_IPOAcc, double[] Amount_IPOAcc, string Deposit_Withdraw_IPOAcc, DateTime ReceivedDate, string PaymentMethodName, string VoucherNo,string Remarks,string[] TransReason)
        {

            CommonBAL comBal = new CommonBAL();
            DateTime TodayServerDate = comBal.GetCurrentServerDate();

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();
                for (int i = 0; i < CustCode_IPOAcc.Length; i++)
                {
                    string queryString_InsertIPOAcc = "";
                    queryString_InsertIPOAcc = @"
    
                             DECLARE @Method_ID int
                                SET @Method_ID=( 
                                SELECT  ID
                                FROM [SBP_Database].[dbo].SBP_IPO_MoneyTrans_Type
                                WHERE MoneyTransType_Name='"+PaymentMethodName+ @"')

                             INSERT INTO [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction]
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
                               ,[Clearing_Status]
                               ,[Channel]
                               ,[ChannelID]
                                ,[Remarks]
                               ,[Entry_Branch_ID]
                                ,[Entry_Date]
                               ,[Entry_By]
                             )
                             VALUES(
                                '" + CustCode_IPOAcc[i] + @"'
                                ,'" + ReceivedDate.ToShortDateString() + @"' /*AS Received_Date*/
                                , @Method_ID  /*AS Money_TransactionType_Name*/
                                ,'" + PaymentMethodName + @"' /*AS Money_TransactionType_ID*/
                                ,'" + Deposit_Withdraw_IPOAcc + @"' /*AS Deposit_Withdraw*/
                                ," + Amount_IPOAcc[i] + @" /*AS Amount*/
                                ,'" + VoucherNo + @"' /*AS Voucher_No*/
                                ,'" + TransReason[i] + @"' /*AS Trans_Reason*/
                                ,0 /*AS Intended_IPOSession_ID*/
                                ,'' /*AS Intended_IPOSession_Name*/
                                ,0 /*AS Approval_Status*/
                                ,''
                                ,0
                                ,'" +Remarks+@"'
                                ,'"+GlobalVariableBO._branchId+@"'
                                ,0 /*CLEARING STATUS*/
                                ,GETDATE() /*AS Entry_Date*/
                                ,'" + GlobalVariableBO._userName + @"'
                            )";
                    _dbConnection.ExecuteNonQuery(queryString_InsertIPOAcc);
                }

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

        public DataTable Insert_NonTransfer_WithTransDetails_MoneyTransaction(string[] CustCode_IPOAcc, double[] Amount_IPOAcc, string Deposit_Withdraw_IPOAcc, DateTime ReceivedDate, int PaymentMethod_ID, string PaymentMethodName, string ChequeNo, DateTime ChequeDate, int BankID, string BankName, int BranchID, string BranchName, string RoutingNo, string BankAccountNo, string VoucherNo,string TransReason,string Remarks, int IntendedIPOSessionID)
        {

            CommonBAL comBal = new CommonBAL();
            DateTime TodayServerDate = comBal.GetCurrentServerDate();
            DataTable Dt = new DataTable();

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();
                string queryString_CreateTempIdentityTable = @"
                IF OBJECT_ID('tempdb..#temp') IS NOT NULL
                BEGIN
                    DROP TABLE #temp
                END             
                

                            Create table #temp
                             (
	                            Cust_Code Varchar(100),
	                            Last_Scope_Id int,
                             )";
                string queryString_GetTempIdentityTable = @"
                                                            Select * 
                                                            From #temp
                ";


                _dbConnection.ExecuteNonQuery(queryString_CreateTempIdentityTable);


                for (int i = 0; i < CustCode_IPOAcc.Length; i++)
                {


                    string queryString_InsertIPOAcc = "";
                    queryString_InsertIPOAcc = @"
    
                             DECLARE @SessionName Varchar(100)
                             SET @SessionName=( 
                                        SELECT  [IPOSession_Name]
                                        FROM [SBP_Database].[dbo].[SBP_IPO_Session]
                                        WHERE [ID]=" + IntendedIPOSessionID + @"
                                )

                             INSERT INTO [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction]
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
                                ,[Remarks]
                                ,[Entry_Branch_ID]
                               ,[Entry_Date]
                               ,[Entry_By]
                             )
                             VALUES(
                                '" + CustCode_IPOAcc[i] + @"'
                                ,'" + ReceivedDate.ToShortDateString() + @"' /*AS Received_Date*/
                                ," + PaymentMethod_ID + @"  /*AS Money_TransactionType_Name*/
                                ,'" + PaymentMethodName + @"' /*AS Money_TransactionType_ID*/
                                ,'" + Deposit_Withdraw_IPOAcc + @"' /*AS Deposit_Withdraw*/
                                ," + Amount_IPOAcc[i] + @" /*AS Amount*/
                                ,'" + VoucherNo + @"' /*AS Voucher_No*/
                                ,'" + TransReason + @"' /*AS Trans_Reason*/
                                ," + IntendedIPOSessionID + @" /*AS Intended_IPOSession_ID*/
                                ,@SessionName /*AS Intended_IPOSession_Name*/
                                ,0 /*AS Approval_Status*/
                                ,'" + Remarks + @"'
                                ,'" + GlobalVariableBO._branchId + @"'
                                ,GETDATE() /*AS Entry_Date*/
                                ,'" + GlobalVariableBO._userName + @"'
                            )
                            DECLARE @ScopeIdent_TransID INT
                            SET @ScopeIdent_TransID=( SELECT SCOPE_IDENTITY())
                            
                            IF('" + Deposit_Withdraw_IPOAcc + @"'='" + Indication_PaymentMode.Deposit + @"')
                            BEGIN
                                    INSERT INTO #temp (Cust_Code,Last_Scope_Id)
                                    VALUES
                                    (
                                       '" + CustCode_IPOAcc[i] + @"'
                                       ,@ScopeIdent_TransID 
	                                ) 
                            END
                                
                            
                            INSERT INTO [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_Transaction_Details]
                            (
                               [TransID]
                               ,[Bank_ID]
                               ,[BankName]
                               ,[Branch_ID]
                               ,[Branch_Name]
                               ,[Routing_No]
                               ,[Bank_Acc_No]
                               ,[Cheque_No]
                               ,[Cheque_Date]
                            )
                            VALUES( 
                                @ScopeIdent_TransID
                                ," + BankID + @" /*AS Bank_ID*/
                                ,'" + BankName + @"' /*AS BankName*/
                                ," + BranchID + @" /*AS Branch_ID*/
                                ,'" + BranchName + @"' /*AS Branch_Name*/
                                ,'" + RoutingNo + @"' /*AS Routing_No*/
                                ,'" + BankAccountNo + @"' /*AS Bank_Acc_No*/
                                ,'" + ChequeNo + @"' /*AS Cheque_No*/
                                ,'" + ChequeDate.ToShortDateString() + @"' /*AS Cheque_Date*/
                            )";
                    _dbConnection.ExecuteNonQuery(queryString_InsertIPOAcc);
                }

                Dt = _dbConnection.ExecuteQuery(queryString_GetTempIdentityTable, _dbConnection.GetTransaction());

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
            //return _dbConnection;
            return Dt;
        }

        public DataTable Insert_NonTransfer_WithTransDetails_MoneyTransaction_UITransApplied(string[] CustCode_IPOAcc, double[] Amount_IPOAcc, string Deposit_Withdraw_IPOAcc, DateTime ReceivedDate, int PaymentMethod_ID, string PaymentMethodName, string ChequeNo, DateTime ChequeDate, int BankID, string BankName, int BranchID, string BranchName, string RoutingNo, string BankAccountNo, string VoucherNo,string TransReason,string Remarks, int IntendedIPOSessionID,int[] ChannelID,string[] ChannelType)
        {

            CommonBAL comBal = new CommonBAL();
            DateTime TodayServerDate = comBal.GetCurrentServerDate();
            DataTable Dt = new DataTable();

            try
            {
                //_dbConnection.ConnectDatabase();
                //_dbConnection.StartTransaction();
                string queryString_CreateTempIdentityTable = @"
                IF OBJECT_ID('tempdb..#temp') IS NOT NULL
                BEGIN
                    DROP TABLE #temp
                END             
                

                            Create table #temp
                             (
	                            Cust_Code Varchar(100),
	                            Last_Scope_Id int,
                             )";
                string queryString_GetTempIdentityTable = @"
                                                            Select * 
                                                            From #temp
                ";
                
                
                _dbConnection.ExecuteNonQuery(queryString_CreateTempIdentityTable);
                
                
                for (int i = 0; i < CustCode_IPOAcc.Length; i++)
                {
                    
                    
                    string queryString_InsertIPOAcc = "";
                    queryString_InsertIPOAcc = @"
    
                             DECLARE @SessionName Varchar(100)
                             SET @SessionName=( 
                                        SELECT  [IPOSession_Name]
                                        FROM [SBP_Database].[dbo].[SBP_IPO_Session]
                                        WHERE [ID]=" + IntendedIPOSessionID + @"
                                )

                             INSERT INTO [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_MoneyTransaction]
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
                                ,[Channel]
                                ,[ChannelID] 
                                ,[Remarks]
                                ,[Entry_Branch_ID]
                               ,[Entry_Date]
                               ,[Entry_By]
                             )
                             VALUES(
                                '" + CustCode_IPOAcc[i] + @"'
                                ,'" + ReceivedDate.ToShortDateString() + @"' /*AS Received_Date*/
                                ," + PaymentMethod_ID + @"  /*AS Money_TransactionType_Name*/
                                ,'" + PaymentMethodName + @"' /*AS Money_TransactionType_ID*/
                                ,'" + Deposit_Withdraw_IPOAcc + @"' /*AS Deposit_Withdraw*/
                                ," + Amount_IPOAcc[i] + @" /*AS Amount*/
                                ,'" + VoucherNo + @"' /*AS Voucher_No*/
                                ,'" + TransReason + @"' /*AS Trans_Reason*/
                                ," + IntendedIPOSessionID + @" /*AS Intended_IPOSession_ID*/
                                ,@SessionName /*AS Intended_IPOSession_Name*/
                                ,0 /*AS Approval_Status*/
                                ,'"+ChannelType[i]+@"' /*AS Channel*/
                                ," + ChannelID[i] + @" /*AS ChannelID*/
                                ,'" +Remarks+@"'
                                ,'"+GlobalVariableBO._branchId+@"'
                                ,GETDATE() /*AS Entry_Date*/
                                ,'" + GlobalVariableBO._userName + @"'
                            )
                            DECLARE @ScopeIdent_TransID INT
                            SET @ScopeIdent_TransID=( SELECT SCOPE_IDENTITY())
                            
                            IF('"+Deposit_Withdraw_IPOAcc+@"'='"+Indication_PaymentMode.Deposit+@"')
                            BEGIN
                                    INSERT INTO #temp (Cust_Code,Last_Scope_Id)
                                    VALUES
                                    (
                                       '" + CustCode_IPOAcc[i] + @"'
                                       ,@ScopeIdent_TransID 
	                                ) 
                            END
                                
                            
                            INSERT INTO [SBP_Database].[dbo].[SBP_IPO_Customer_Broker_Transaction_Details]
                            (
                               [TransID]
                               ,[Bank_ID]
                               ,[BankName]
                               ,[Branch_ID]
                               ,[Branch_Name]
                               ,[Routing_No]
                               ,[Bank_Acc_No]
                               ,[Cheque_No]
                               ,[Cheque_Date]
                            )
                            VALUES( 
                                @ScopeIdent_TransID
                                ," + BankID + @" /*AS Bank_ID*/
                                ,'" + BankName + @"' /*AS BankName*/
                                ," + BranchID + @" /*AS Branch_ID*/
                                ,'" + BranchName + @"' /*AS Branch_Name*/
                                ,'" + RoutingNo + @"' /*AS Routing_No*/
                                ,'" + BankAccountNo + @"' /*AS Bank_Acc_No*/
                                ,'" + ChequeNo + @"' /*AS Cheque_No*/
                                ,'" + ChequeDate.ToShortDateString() + @"' /*AS Cheque_Date*/
                            )";
                    _dbConnection.ExecuteNonQuery(queryString_InsertIPOAcc);
                }

                Dt=_dbConnection.ExecuteQuery(queryString_GetTempIdentityTable,_dbConnection.GetTransaction());
                
               // _dbConnection.Commit();

            }
            catch (Exception ex)
            {
            //    _dbConnection.Rollback();
                throw ex;
            }
            //finally
            //{
            //    _dbConnection.CloseDatabase();
            //}
            //return _dbConnection;
            return Dt;

        }

        public void Insert_ApplyApplication_MoneyTransaction(int[] IPOSession_ID,string[] Cust_Code,int RefundTypeID,string Refund_Reference,int money_trans_ref_id)
        {
           
            CommonBAL comBal = new CommonBAL();

            DateTime TodayServerDate = comBal.GetCurrentServerDate();
            string queryString = "";
            queryString = @"[SBP_IpoApplicationProcess]";

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();

                for (int i = 0; i < IPOSession_ID.Length; i++)
                {
                    for (int j = 0; j < Cust_Code.Length; j++)
                    {
                        _dbConnection.ClearParameters();
                        _dbConnection.AddParameter("@Session_ID", SqlDbType.Int, IPOSession_ID[i]);
                        _dbConnection.AddParameter("@Cust_Code", SqlDbType.Int, Cust_Code[j]);
                        _dbConnection.AddParameter("@RefundTypeID", SqlDbType.Int, RefundTypeID);
                        _dbConnection.AddParameter("@Refund_Reference", SqlDbType.VarChar, Refund_Reference);
                        _dbConnection.AddParameter("@Entry_By", SqlDbType.VarChar, GlobalVariableBO._userName);
                        _dbConnection.AddParameter("@Money_Trans_Ref_ID", SqlDbType.Int, money_trans_ref_id);
                        _dbConnection.ExecuteProQuery(queryString);
                    }
                }
                _dbConnection.Commit();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                _dbConnection.Rollback();
               
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
        }

        public DataTable GetSingleApplicationDataAfterSave(string[] custCode,int sessionId,int refund)
        {
            string JoinCode = string.Join(",", custCode);
            DataTable dt = new DataTable();
            string query = @"Declare  @Sessid int,@Refund int
 
                            set @Sessid="+sessionId+@"
                            set @Refund="+refund+ @"
                            Select
                            ID As 'ApplicationID'
                            ,bs.Cust_Code As 'Cust_Code'
                            ,bs.Serial_No As 'Serial_No'
                            ,bs.Remarks As 'Remarks'
                            ,ext.Cust_Name As 'Cust_Name'
                            ,bs.TotalAmount as 'ApplyMoney'
                            ,ISNULL(ipoAcc.Balance,0) As 'Balance'
                            From SBP_IPO_Application_BasicInfo as bs
                            JOIN SBP_IPO_Application_ExtendedInfo as ext
                            ON bs.ID=ext.BasicInfo_ID
                            LEFT OUTER JOIN 
                            (
                                    Select mt.Cust_Code
                                    ,SUM(( CASE WHEN mt.Deposit_Withdraw='Deposit' THEN mt.Amount ELSE 0.00 END )) - SUM(( CASE WHEN mt.Deposit_Withdraw='Withdraw' THEN mt.Amount ELSE 0.00 END )) AS Balance
                                    From dbo.SBP_IPO_Customer_Broker_MoneyTransaction as mt
                                    Where 
                                   ( mt.Money_TransactionType_Name<>'Cheque'AND mt.Approval_Status=1 )
                                   OR
                                   ( mt.Money_TransactionType_Name='Cheque'AND mt.Approval_Status=1 AND Clearing_Status=1)
                                   GROUP BY mt.Cust_Code
                            		
                            ) AS ipoAcc
                            ON ipoAcc.Cust_Code=bs.Cust_Code
                            WHERE bs.Cust_Code IN (" + JoinCode+@") And bs.IPOSession_ID= @Sessid
                            And ext.Refund_Method=@Refund"
                         ;
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

        public void Insert_ApplyApplication_MoneyTransaction_UITransApplied(int[] IPOSession_ID, string[] Cust_Code, int RefundTypeID, string Refund_Reference, DataTable money_trans_ref_id_Dt,int lot_No,string[] SerialNo,string[] SingelApplyRemarks,int[] ChannelID,string[] ChannelType)
        {

            CommonBAL comBal = new CommonBAL();

            DateTime TodayServerDate = comBal.GetCurrentServerDate();
            string queryString = "";
            queryString = @"[SBP_IpoApplicationProcess]";

            try
            {
                //_dbConnection.ConnectDatabase();
                //_dbConnection.StartTransaction();

                for (int i = 0; i < IPOSession_ID.Length; i++)
                {
                    for (int j = 0; j < Cust_Code.Length; j++)
                    {
                        int id = money_trans_ref_id_Dt.Rows.Cast<DataRow>().Where(t => Convert.ToString(t["Cust_Code"]) == Cust_Code[j]).Select(t => Convert.ToInt32(t[1])).FirstOrDefault();
                        
                        //int[] cId= money_trans_ref_id.Rows.Cast<DataRow>()
                        _dbConnection.ClearParameters();
                        //queryString = " exec [SBP_IPOApplicationProcess] " + IPOSession_ID[i] + "," + Cust_Code[j] + "," + RefundTypeID + ",'" + Refund_Reference + "'," + id + ",'" + GlobalVariableBO._userName + "',"+lot_No+"";
                        _dbConnection.AddParameter("@Session_ID", SqlDbType.Int, IPOSession_ID[i]);
                        _dbConnection.AddParameter("@Cust_Code", SqlDbType.Int, Cust_Code[j]);
                        _dbConnection.AddParameter("@RefundTypeID", SqlDbType.Int, RefundTypeID);
                        _dbConnection.AddParameter("@Refund_Reference", SqlDbType.VarChar, Refund_Reference);
                        _dbConnection.AddParameter("@Money_Trans_Ref_ID", SqlDbType.Int, id);
                        _dbConnection.AddParameter("@Entry_Branch_ID", SqlDbType.Int, GlobalVariableBO._branchId);
                        _dbConnection.AddParameter("@Entry_By", SqlDbType.VarChar, GlobalVariableBO._userName);
                        _dbConnection.AddParameter("@ChannelID", SqlDbType.Int, ChannelID.Length>0?ChannelID[j]:0);
                        _dbConnection.AddParameter("@ChannelType", SqlDbType.VarChar, ChannelType.Length>0?ChannelType[i]:string.Empty);
                        _dbConnection.AddParameter("@Lot_No", SqlDbType.Int, lot_No);
                        if (SerialNo.Length > 0)
                            _dbConnection.AddParameter("@VoucherNo", SqlDbType.VarChar, SerialNo[j]);
                        else
                            _dbConnection.AddParameter("@VoucherNo", SqlDbType.VarChar, DBNull.Value);
                        if (SingelApplyRemarks.Length > 0)
                            _dbConnection.AddParameter("@Remarks", SqlDbType.VarChar, SingelApplyRemarks[j]);
                        else
                            _dbConnection.AddParameter("@Remarks", SqlDbType.VarChar, DBNull.Value);

                        _dbConnection.ExecuteProQuery(queryString);
                    }
                }
                //_dbConnection.Commit();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
               // _dbConnection.Rollback();

            }
            //finally
            //{
            //    _dbConnection.CloseDatabase();
            //}
        }

        public void UpdateIPOSession_UITransApplied(string IPOSession_Name, string IPOSession_Desc, int IPO_Company_ID, int Application_Type_ID, DateTime Session_Date, int No_Of_Share, double Amount, double TotalShareValue, double TotalAmount, int Session_Status, int IPOSessionID, double Premium)
        {
            SqlConnection conn = new SqlConnection(DbConnectionBasic.ConnectionString);
            CommonBAL comBal = new CommonBAL();

            DateTime TodayServerDate = comBal.GetCurrentServerDate();
            string queryString = "";
            queryString = @"UPDATE [SBP_Database].[dbo].[SBP_IPO_Session]
                           SET [IPOSession_Name] = @IPOSession_Name
                              ,[IPOSession_Desc] = @IPOSession_Desc
                              ,[IPO_Company_ID] = @IPO_Company_ID
                              ,[Application_Type_ID] = @Application_Type_ID
                              ,[Session_Date] = @Session_Date
                              ,[No_Of_Share] = @No_Of_Share
                              ,[Amount] = @Amount
                              ,[Total_Share_Value]=@TotalShareValue
                              ,[Premium]=@Premium                                
                              ,[TotalAmount] = @TotalAmount
                              ,[Status] = @Session_Status                             
                              
                              ,[Updated_Date] = @Updated_Date
                              ,[Update_By] = @Update_By
                         WHERE ID=" + IPOSessionID + "";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ClearParameters();
                _dbConnection.AddParameter("@IPOSession_Name", SqlDbType.VarChar, IPOSession_Name);
                _dbConnection.AddParameter("@IPOSession_Desc", SqlDbType.VarChar, IPOSession_Desc);
                _dbConnection.AddParameter("@IPO_Company_ID", SqlDbType.Int, IPO_Company_ID);
                _dbConnection.AddParameter("@Application_Type_ID", SqlDbType.Int, Application_Type_ID);
                _dbConnection.AddParameter("@Session_Date", SqlDbType.DateTime, Session_Date.ToShortDateString());
                _dbConnection.AddParameter("@No_Of_Share", SqlDbType.Int, No_Of_Share);
                _dbConnection.AddParameter("@Amount", SqlDbType.Money, Amount);
                _dbConnection.AddParameter("@TotalShareValue", SqlDbType.Money, TotalShareValue);
                _dbConnection.AddParameter("@Premium ", SqlDbType.Money, Premium);
                _dbConnection.AddParameter("@TotalAmount", SqlDbType.Money, TotalAmount);
                _dbConnection.AddParameter("@Session_Status", SqlDbType.Int, Session_Status);
                //_dbConnection.AddParameter("@Company_Logo", SqlDbType.Image, CompanyLogo);
                _dbConnection.AddParameter("@Updated_Date", SqlDbType.DateTime, TodayServerDate.ToShortDateString());
                _dbConnection.AddParameter("@Update_By", SqlDbType.VarChar, GlobalVariableBO._userName);

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

        public void UpdateIPOSession(string IPOSession_Name, string IPOSession_Desc, int IPO_Company_ID, int Application_Type_ID, DateTime Session_Date, int No_Of_Share, double Amount, double TotalShareValue, double TotalAmount, int Session_Status, int IPOSessionID, double Premium)
        {
            SqlConnection conn = new SqlConnection(DbConnectionBasic.ConnectionString);
            CommonBAL comBal = new CommonBAL();

            DateTime TodayServerDate = comBal.GetCurrentServerDate();
            string queryString = "";
            queryString = @"UPDATE [SBP_Database].[dbo].[SBP_IPO_Session]
                           SET [IPOSession_Name] = @IPOSession_Name
                              ,[IPOSession_Desc] = @IPOSession_Desc
                              ,[IPO_Company_ID] = @IPO_Company_ID
                              ,[Application_Type_ID] = @Application_Type_ID
                              ,[Session_Date] = @Session_Date
                              ,[No_Of_Share] = @No_Of_Share
                              ,[Amount] = @Amount
                              ,[Total_Share_Value]=@TotalShareValue
                              ,[Premium]=@Premium                                
                              ,[TotalAmount] = @TotalAmount
                              ,[Status] = @Session_Status
                              
                              
                              ,[Updated_Date] = @Updated_Date
                              ,[Update_By] = @Update_By
                         WHERE ID=" + IPOSessionID + "";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ClearParameters();
                _dbConnection.AddParameter("@IPOSession_Name", SqlDbType.VarChar, IPOSession_Name);
                _dbConnection.AddParameter("@IPOSession_Desc", SqlDbType.VarChar, IPOSession_Desc);
                _dbConnection.AddParameter("@IPO_Company_ID", SqlDbType.Int, IPO_Company_ID);
                _dbConnection.AddParameter("@Application_Type_ID", SqlDbType.Int, Application_Type_ID);
                _dbConnection.AddParameter("@Session_Date", SqlDbType.DateTime, Session_Date.ToShortDateString());
                _dbConnection.AddParameter("@No_Of_Share", SqlDbType.Int, No_Of_Share);
                _dbConnection.AddParameter("@Amount", SqlDbType.Money, Amount);
                _dbConnection.AddParameter("@TotalShareValue", SqlDbType.Money, TotalShareValue);
                _dbConnection.AddParameter("@Premium ", SqlDbType.Money, Premium);
                _dbConnection.AddParameter("@TotalAmount", SqlDbType.Money, TotalAmount);
                _dbConnection.AddParameter("@Session_Status", SqlDbType.Int, Session_Status);
                //_dbConnection.AddParameter("@Company_Logo", SqlDbType.Image, CompanyLogo);
                _dbConnection.AddParameter("@Updated_Date", SqlDbType.DateTime, TodayServerDate.ToShortDateString());
                _dbConnection.AddParameter("@Update_By", SqlDbType.VarChar, GlobalVariableBO._userName);

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

        public void UpdateIPOCompany_UITransApplied( string CompanyShortCode, string CompanyName, string CompanyAddress, int BankID, string BankName, int BranchID, string BranchName, string BankAccNo, string RoutingNo, int IPOCompanyID)
        {
            SqlConnection conn = new SqlConnection(DbConnectionBasic.ConnectionString);
            CommonBAL comBal = new CommonBAL();

            DateTime TodayServerDate = comBal.GetCurrentServerDate();
            string queryString = "";
            queryString = @"UPDATE [SBP_Database].[dbo].[SBP_IPO_Company_Info]
                           SET 
                               [Company_Short_Code] = @Company_Short_Code
                              ,[Company_Name] = @Company_Name
                              ,[Company_Address] = @Company_Address
                              ,[Bank_ID] = @Bank_ID
                              ,[Bank_Name] = @Bank_Name
                              ,[Branch_ID] = @Branch_ID
                              ,[Branch_Name] = @Branch_Name
                              ,[BankAcc_No] = @BankAcc_No
                              ,[RoutingNo] = @RoutingNo
                              --,[Company_Logo] = @Company_Logo
                              ,[Updated_Date] = @Updated_Date
                              ,[Update_By] = @Update_By
                         WHERE [ID]=" + IPOCompanyID + "";

            try
            {
                //_dbConnection.ConnectDatabase();
                _dbConnection.ClearParameters();
           
                _dbConnection.AddParameter("@Company_Short_Code", SqlDbType.VarChar, CompanyShortCode);
                _dbConnection.AddParameter("@Company_Name", SqlDbType.VarChar, CompanyName);
                _dbConnection.AddParameter("@Company_Address", SqlDbType.VarChar, CompanyAddress);
                _dbConnection.AddParameter("@Bank_ID", SqlDbType.Int, BankID);
                _dbConnection.AddParameter("@Bank_Name", SqlDbType.VarChar, BankName);
                _dbConnection.AddParameter("@Branch_ID", SqlDbType.Int, BranchID);
                _dbConnection.AddParameter("@Branch_Name", SqlDbType.VarChar, BranchName);
                _dbConnection.AddParameter("@BankAcc_No", SqlDbType.VarChar, BankAccNo);
                _dbConnection.AddParameter("@RoutingNo", SqlDbType.VarChar, RoutingNo);
                //_dbConnection.AddParameter("@Company_Logo", SqlDbType.Image, CompanyLogo);
                _dbConnection.AddParameter("@Updated_Date", SqlDbType.DateTime, TodayServerDate.ToShortDateString());
                _dbConnection.AddParameter("@Update_By", SqlDbType.VarChar, GlobalVariableBO._userName);
                _dbConnection.ExecuteNonQuery(queryString);

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


        public void UpdateIPOCompany_UITransApplied(string Chairman_name, string Designation, string CompanyShortCode, string CompanyName, string CompanyAddress, int BankID, string BankName, int BranchID, string BranchName, string BankAccNo, string RoutingNo, int IPOCompanyID)
        {
            SqlConnection conn = new SqlConnection(DbConnectionBasic.ConnectionString);
            CommonBAL comBal = new CommonBAL();

            DateTime TodayServerDate = comBal.GetCurrentServerDate();
            string queryString = "";
            //            queryString = @"UPDATE [SBP_Database].[dbo].[SBP_IPO_Company_Info]
            //                           SET 
            //                                [Company_Chairman_name]=@Company_Chairman_name
            //                                ,[Designation]=@Designation
            //                               ,[Company_Short_Code] = @Company_Short_Code
            //                              ,[Company_Name] = @Company_Name
            //                              ,[Company_Address] = @Company_Address
            //                              ,[Bank_ID] = @Bank_ID
            //                              ,[Bank_Name] = @Bank_Name
            //                              ,[Branch_ID] = @Branch_ID
            //                              ,[Branch_Name] = @Branch_Name
            //                              ,[BankAcc_No] = @BankAcc_No
            //                              ,[RoutingNo] = @RoutingNo
            //                              --,[Company_Logo] = @Company_Logo
            //                              ,[Updated_Date] = @Updated_Date
            //                              ,[Update_By] = @Update_By
            //                         WHERE [ID]=" + IPOCompanyID + "";

            queryString = @"UPDATE [SBP_IPO_Company_Info]
                           SET 
                                [Company_Chairman_name]='" + Chairman_name + @"'
                                ,[Designation]='" + Designation + @"'
                               ,[Company_Short_Code] = '" + CompanyShortCode + @"'
                              ,[Company_Name] = '" + CompanyName + @"'
                              ,[Company_Address] = '" + CompanyAddress + @"'
                              ,[Bank_ID] = '" + BankID + @"'
                              ,[Bank_Name] = '" + BankName + @"'
                              ,[Branch_ID] = '" + BranchID + @"'
                              ,[Branch_Name] = '" + BranchName + @"'
                              ,[BankAcc_No] = '" + BankAccNo + @"'
                              ,[RoutingNo] = '" + RoutingNo + @"'
                              --,[Company_Logo] = @Company_Logo
                              ,[Updated_Date] = '" + TodayServerDate + @"'
                              ,[Update_By] = '" + GlobalVariableBO._userName + @"'
                         WHERE [ID]=" + IPOCompanyID + "";

            try
            {
                _dbConnection.ConnectDatabase();
                //_dbConnection.ClearParameters();
                //_dbConnection.AddParameter("@Company_Chairman_name", SqlDbType.VarChar, Chairman_name);
                //_dbConnection.AddParameter("@Designation", SqlDbType.VarChar, Designation);
                //_dbConnection.AddParameter("@Company_Short_Code", SqlDbType.VarChar, CompanyShortCode);
                //_dbConnection.AddParameter("@Company_Name", SqlDbType.VarChar, CompanyName);
                //_dbConnection.AddParameter("@Company_Address", SqlDbType.VarChar, CompanyAddress);
                //_dbConnection.AddParameter("@Bank_ID", SqlDbType.Int, BankID);
                //_dbConnection.AddParameter("@Bank_Name", SqlDbType.VarChar, BankName);
                //_dbConnection.AddParameter("@Branch_ID", SqlDbType.Int, BranchID);
                //_dbConnection.AddParameter("@Branch_Name", SqlDbType.VarChar, BranchName);
                //_dbConnection.AddParameter("@BankAcc_No", SqlDbType.VarChar, BankAccNo);
                //_dbConnection.AddParameter("@RoutingNo", SqlDbType.VarChar, RoutingNo);
                ////_dbConnection.AddParameter("@Company_Logo", SqlDbType.Image, CompanyLogo);
                //_dbConnection.AddParameter("@Updated_Date", SqlDbType.DateTime, TodayServerDate.ToShortDateString());
                //_dbConnection.AddParameter("@Update_By", SqlDbType.VarChar, GlobalVariableBO._userName);
                _dbConnection.ExecuteNonQuery(queryString);

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


//        public void UpdateIPOCompany_UITransApplied(string Chairman_name,string Designation,string CompanyShortCode, string CompanyName, string CompanyAddress, int BankID, string BankName, int BranchID, string BranchName, string BankAccNo, string RoutingNo, int IPOCompanyID)
//        {
//            SqlConnection conn = new SqlConnection(DbConnectionBasic.ConnectionString);
//            CommonBAL comBal = new CommonBAL();

//            DateTime TodayServerDate = comBal.GetCurrentServerDate();
//            string queryString = "";
//            queryString = @"UPDATE [SBP_Database].[dbo].[SBP_IPO_Company_Info]
//                           SET 
//                                [Company_Chairman_name]=@Company_Chairman_name
//                                ,[Designation]=@Designation
//                               ,[Company_Short_Code] = @Company_Short_Code
//                              ,[Company_Name] = @Company_Name
//                              ,[Company_Address] = @Company_Address
//                              ,[Bank_ID] = @Bank_ID
//                              ,[Bank_Name] = @Bank_Name
//                              ,[Branch_ID] = @Branch_ID
//                              ,[Branch_Name] = @Branch_Name
//                              ,[BankAcc_No] = @BankAcc_No
//                              ,[RoutingNo] = @RoutingNo
//                              --,[Company_Logo] = @Company_Logo
//                              ,[Updated_Date] = @Updated_Date
//                              ,[Update_By] = @Update_By
//                         WHERE [ID]=" + IPOCompanyID + "";

//            try
//            {
//                //_dbConnection.ConnectDatabase();
//                _dbConnection.ClearParameters();
//                _dbConnection.AddParameter("@Company_Chairman_name", SqlDbType.VarChar, Chairman_name);
//                _dbConnection.AddParameter("@Designation", SqlDbType.VarChar, Designation);
//                _dbConnection.AddParameter("@Company_Short_Code", SqlDbType.VarChar, CompanyShortCode);
//                _dbConnection.AddParameter("@Company_Name", SqlDbType.VarChar, CompanyName);
//                _dbConnection.AddParameter("@Company_Address", SqlDbType.VarChar, CompanyAddress);
//                _dbConnection.AddParameter("@Bank_ID", SqlDbType.Int, BankID);
//                _dbConnection.AddParameter("@Bank_Name", SqlDbType.VarChar, BankName);
//                _dbConnection.AddParameter("@Branch_ID", SqlDbType.Int, BranchID);
//                _dbConnection.AddParameter("@Branch_Name", SqlDbType.VarChar, BranchName);
//                _dbConnection.AddParameter("@BankAcc_No", SqlDbType.VarChar, BankAccNo);
//                _dbConnection.AddParameter("@RoutingNo", SqlDbType.VarChar, RoutingNo);
//                //_dbConnection.AddParameter("@Company_Logo", SqlDbType.Image, CompanyLogo);
//                _dbConnection.AddParameter("@Updated_Date", SqlDbType.DateTime, TodayServerDate.ToShortDateString());
//                _dbConnection.AddParameter("@Update_By", SqlDbType.VarChar, GlobalVariableBO._userName);
//                _dbConnection.ExecuteNonQuery(queryString);

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

        public void Update_IPO_New_ShortCode_UITransApplied(int coid, string S_Code, string C_Name, string C_addr)
        {
            CommonBAL bal = new CommonBAL();
            string query = @"	Declare @last int
                                set @last=(select MAX(Sl_No) From SBP_IPO_Company_Modification_Info)
                                Update SBP_IPO_Company_Modification_Info 
			                    set 
			                    Company_Short_Code_New='" + S_Code + @"',
			                    Company_Name_New='" + C_Name + @"',
			                    Company_Address_New='" +bal.HandlingSingelQuation(C_addr) + @"',	                     
			                    Update_By='"+GlobalVariableBO._userName+ @"',
                                Updated_Date=Convert(varchar(10),GETDATE(),111)
			                    Where Sl_No=@last 
                                Update bs Set bs.Applied_Company=Com.Company_Name
                                From [SBP_IPO_Application_BasicInfo] As bs
                                Inner Join SBP_IPO_Session As sess
                                ON bs.IPOSession_ID=sess.ID
                                Inner Join SBP_IPO_Company_Info As Com
                                On Com.ID=sess.IPO_Company_ID
                                Where Com.ID=" + coid + @"	
                             ";
            try
            {
                //_dbConnection.ConnectDatabase();
                _dbConnection.ClearParameters();
                _dbConnection.ExecuteNonQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //_dbConnection.CloseDatabase();
            }
        }
        public void InsertIPO_Company_ModificationInfo_UITransApplied(int ComID)
        {
            string query = @"IPO_CompanyShortCode_Update";
            try
            {
                //_dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@CompanyId", SqlDbType.Int, ComID);
                _dbConnection.ExecuteProQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //_dbConnection.CloseDatabase();
            }
        }
       
        public void Updated_IPO_Affected_Account_UITransApplied( string[] Cust_Code ,bool isAffected)
        {

            CommonBAL comBal = new CommonBAL();

            DateTime TodayServerDate = comBal.GetCurrentServerDate();
            string Codes = String.Join(",",Cust_Code);
            string queryString = "";
            queryString = @"update SBP_Cust_Additional_Info 
                        set IsAffected_Account=" + Convert.ToInt32(isAffected) + " where SBP_Cust_Additional_Info.cust_code IN (" + Codes + ")  ";

            try
            {
                //_dbConnection.AddParameter("@affectedAccount", SqlDbType.Bit, isAffected);
                _dbConnection.ClearParameters();
                if (isAffected)
                    _dbConnection.ExecuteNonQuery(queryString);
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                // _dbConnection.Rollback();

            }
            //finally
            //{
            //    _dbConnection.CloseDatabase();
            //}
        }

        public void DeleteIposessionInfo(string id)
        {

            string query = @"
							DECLARE @SessionID INT
                            SET @SessionID=" + id + @"
                            
                            DECLARE @NOOFTRAN INT
                            Select @NOOFTRAN=COUNT(sess.ID)
                            
                            From dbo.SBP_IPO_Session as sess
                            JOIN
                            dbo.SBP_IPO_Company_Info as comp
                            ON
                            sess.IPO_Company_ID=comp.ID
                            JOIN
                            dbo.SBP_IPO_Application_BasicInfo as app
                            ON
                            app.IPOSession_ID=sess.Id                            
                            WHERE
                            ---comp.ID=
                            sess.ID=@SessionID
							
							--print COnvert(varchar(100),@NOOFTRAN)
							
                            IF(@NOOFTRAN=0)
                            Begin
	                            DELETE SBP_IPO_Session
	                            WHERE ID=@SessionID;
	                            
                                delete from SBP_IPO_Session_NRB where IPO_Session_ID=@SessionID;


	                            Declare @TotalSession int
	                           select @TotalSession=count(*)
	                           from SBP_IPO_Session;
	                          set @TotalSession=@TotalSession+2;
	                      
	                           DBCC CHECKIDENT([SBP_IPO_Session],RESEED,@TotalSession);      
                            End
                            ELSE IF (@NOOFTRAN>0)
                            Begin
								RAISERROR('Transaction Found',16,1)
                            End;";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void DeleteCompanyInfo(string id)
        {
            string query = @"DECLARE @SessionID INT
                            SET @SessionID=" + id + @"
                            DECLARE @NOOFTRAN INT
                            Select @NOOFTRAN=COUNT(sess.ID)
                            From dbo.SBP_IPO_Session as sess
                            JOIN
                            dbo.SBP_IPO_Company_Info as comp
                            ON
                            sess.IPO_Company_ID=comp.ID
                            JOIN
                            dbo.SBP_IPO_Application_BasicInfo as app
                            ON
                            app.IPOSession_ID=sess.Id                            
                            WHERE
                            ---comp.ID=
                            comp.ID=@SessionID
							
							--print COnvert(varchar(100),@NOOFTRAN)
							
                            IF(@NOOFTRAN=0)
                            Begin
	                            DELETE SBP_IPO_Company_Info
	                            WHERE ID=@SessionID
                            End
                            ELSE IF (@NOOFTRAN>0)
                            Begin
								RAISERROR('Transaction Found',16,1)
                            End";

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //public void DeleteDepositInfo(int DepositId,int postingId)
        //{
        //    string query = @"SBP_IPODeletePaymentTransaction";
        //    try
        //    {
        //        _dbConnection.ConnectDatabase();
        //        _dbConnection.ActiveStoredProcedure();
        //        _dbConnection.AddParameter("@DepositId", SqlDbType.Int, DepositId);
        //        _dbConnection.AddParameter("@Payment_Posint_Id", SqlDbType.Int, postingId);
        //        _dbConnection.ExecuteProQuery(query);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    finally
        //    {
        //        _dbConnection.CloseDatabase();
        //    }
        //}

        public void DeleteDepositInfo(int DepositId, int postingId, string status)
        {
            string query = "";
            if (status == "Approved")
            {
                query = @"SBP_IPODeletePaymentTransaction";
            }
            else if (status == "Pending")
            {
                query = @"SBP_IPODeletePaymentTransaction_PendingOnly";
            }
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@DepositId", SqlDbType.Int, DepositId);
                _dbConnection.AddParameter("@Payment_Posint_Id", SqlDbType.Int, postingId);
                _dbConnection.AddParameter("@DeleteBy", SqlDbType.VarChar, GlobalVariableBO._userName);
                //_dbConnection.AddParameter("@DeleteDate", SqlDbType.VarChar, GlobalVariableBO._currentServerDate);
                _dbConnection.AddParameter("@Status", SqlDbType.VarChar, status);
                _dbConnection.ExecuteProQuery(query);
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

        public DataTable GetDP9Cust_Code()
        {
            DataTable dt = new DataTable();
            string Query = @"select Cust_Code,DP9.[BO_ID] from sbp_customers as Customer
                              join [SBP_16DP95UX] as DP9
                              on Customer.bo_id=DP9.bo_id
                              GROUP BY Cust_Code, DP9.[BO_ID]";
            try
            {
                _dbConnection.ConnectDatabase();
                dt=_dbConnection.ExecuteQuery(Query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable GetDP9CompanyShortCode()
        {
            DataTable dt = new DataTable();
            string Query = @"    select com.Comp_Short_Code,DP9.[ISIN_No] from SBP_Company as com
                                   join [SBP_16DP95UX] as DP9 
                                   on DP9.[ISIN_No]=com.ISIN_No
                                   GROUP BY  com.Comp_Short_Code,DP9.[ISIN_No]";
            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(Query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public void Insert_WithDraw_From_SharetempVolt_UITrans(string Cust_Code, string Comp_Short_Code)
        {
            string query = @"INSERT INTO [SBP_IPO_Share_TempVolt]
                           ([Cust_Code]
                           ,[IPOCompany_ID]
                           ,[Received_Date]
                           ,[Share_TransacetionType_ID]
                           ,[Share_TransacetionType_Name]
                           ,[Deposit_Withdraw]
                           ,[Qty]
                           ,[Amount]
                           ,[Total_Share_Value]
                           ,[Premium]
                           ,[Total_Amount]
                           ,[Deposit_IPOSession_ID]
                           ,[Deposit_IPOSession_Name]
                           ,[Deposit_Result_ID]
                           ,[Trans_Reason]
                           ,[Approval_Status]
                           ,[Approval_Date]
                           ,[Approval_By]
                           ,[Entry_Date]
                           ,[Entry_By]
                         )
                    Select vlt.[Cust_Code]
                           ,vlt.[IPOCompany_ID]
                           ,vlt.[Received_Date]
                           ,vlt.[Share_TransacetionType_ID]
                           ,vlt.[Share_TransacetionType_Name]
                           ,'Withdraw'
                           ,vlt.[Qty]
                           ,vlt.[Amount]
                           ,vlt.[Total_Share_Value]
                           ,vlt.[Premium]
                           ,vlt.[Total_Amount]
                           ,vlt.[Deposit_IPOSession_ID]
                           ,vlt.[Deposit_IPOSession_Name]
                           ,vlt.[Deposit_Result_ID]
                           ,vlt.[Trans_Reason]
                           ,vlt.[Approval_Status]
                           ,vlt.[Approval_Date]
                           ,'" + GlobalVariableBO._userName + @"'
                             ,Getdate()
                           ,'" + GlobalVariableBO._userName + @"'
                           
                    From [SBP_IPO_Share_TempVolt] as vlt 
                    JOIN dbo.SBP_IPO_Session as sess
                    ON vlt.[Deposit_IPOSession_ID]=sess.ID
                    JOIN dbo.SBP_IPO_Company_Info as comp
                    ON sess.IPO_Company_ID=comp.ID
                    WHERE 
                    vlt.Cust_Code='" +Cust_Code+@"'
                    AND
                    comp.Company_Short_Code='"+Comp_Short_Code+ @"'
                    AND Cust_Code NOT IN (
                                        SELECT p_Vlt.Cust_Code
                                        FROM SBP_IPO_Share_TempVolt as p_Vlt
                                        WHERE p_Vlt.Cust_Code= vlt.Cust_Code 
                                        AND p_Vlt.Deposit_IPOSession_ID=vlt.Deposit_IPOSession_ID
                                        AND p_Vlt.Deposit_Withdraw='Withdraw'
                    )";
            try
            {
                _dbConnection.ExecuteNonQuery(query);

            }
            catch (Exception ex)
            {
                throw ex;
            }
             
        }

        public void UpdateIPoSessionMatured_ByCompShortCode_UITrans(string Comp_Short_Code)
        {
            string Query = @" DECLARE @Comp_Short_Code Varchar(100)
                             SET @Comp_Short_Code='"+Comp_Short_Code+@"'
                             
                             IF((SELECT count(*) FROM SBP_IPO_Session WHERE SBP_IPO_Session.IPO_Company_ID=(SELECT  ID FROM [SBP_IPO_Company_Info] WHERE Company_Short_Code=@Comp_Short_Code)
	                            and SBP_IPO_Session.[Status]=4)>0)
                             BEGIN
	                             UPDATE SBP_IPO_Session 
	                             SET SBP_IPO_Session.[Status]=2 
	                             WHERE SBP_IPO_Session.IPO_Company_ID=(SELECT  ID FROM [SBP_IPO_Company_Info] WHERE  Company_Short_Code=@Comp_Short_Code)
	                             and SBP_IPO_Session.[Status]=4
                             END 
                             ELSE
                             BEGIN
	                            RAISERROR ('Session not closed',16,1) 
                             END";
            try
            {
                _dbConnection.ExecuteNonQuery(Query);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        #region ResultImport

        public DataTable GetIPOResultTempData()
        {
            DataTable dataTable;
            dataTable = null;
            string queryString = "";
            queryString = @"SELECT [Stock_Broker_id]
                          ,[DPID]
                          ,[Cust_Code]
                          ,[Cust_Name]
                          ,[BO_ID]
                          ,[Category_of_Applicant]
                          ,[Comp_Short_Code]
                          ,[No_Of_Share]
                          ,[Currency]
                          ,[Total_Amount]
                          ,[Successful_Amount]
                          ,[Deducted_Money]
                          ,[Refund_Money]
                          ,[Comment]
                          ,[IPO_Session_ID]
                          ,(case when [Successful_Amount]>0 then 'Successful' else 'Unsuccessful' end) as 'Comment'
                      FROM [SBP_Database].[dbo].[SBP_IPO_ResultTemp] 
                      where [IPO_Session_ID] not in (
								  select IPO_Session_ID 
								  from dbo.SBP_IPO_Result_Summary
                      )
                      AND Cust_Code !='KSL122'
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

        public void InsertResultSummary(int IPO_Session_ID, string Result_Ref_No, DateTime Result_Date, int Qty, int NoOfCust_Code)
        {
            CommonBAL comBal = new CommonBAL();

            DateTime TodayServerDate = comBal.GetCurrentServerDate();
            string queryString = "";
            queryString = @"DECLARE @IPOCompanyID INT
                            SET @IPOCompanyID=(
					                            SELECT [IPO_Company_ID]
					                            FROM [SBP_Database].[dbo].[SBP_IPO_Session] AS B
					                            WHERE B.[ID]=
                            )
                            DECLARE @IPOSessionName Varchar(100)
                            SET @IPOSessionName=(
					                            SELECT [IPOSession_Name]
					                            FROM [SBP_Database].[dbo].[SBP_IPO_Session] AS B
					                            WHERE B.[ID]=
                            )

                            INSERT INTO [SBP_Database].[dbo].[SBP_IPO_Result_Summary]
                                       ([IPOCompany_ID]
                                       ,[Qty]
                                       ,[NoOfCust_Code]
                                       ,[IPO_Session_ID]
                                       ,[IPO_Session_Name]
                                       ,[Result_Ref_No]
                                       ,[Result_Date]          
                                       ,[Entry_Date]
                                       ,[Entry_By]
                                       )
                            VALUES (
		                            @IPOCompanyID
                                    ," + Qty+@"
                                    ,"+NoOfCust_Code+@"
                                    ,"+IPO_Session_ID+@"
                                    ,@IPOSessionName 
                                    ,'" + Result_Ref_No + @"'
                                    ,'" + Result_Date.ToShortDateString() + @"'
                                    ,GETDATE()
                                    ,'"+GlobalVariableBO._userName+@"'
                                  )";


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

        public void TruncateResultTemp()
        {
            CommonBAL comBal = new CommonBAL();

            DateTime TodayServerDate = comBal.GetCurrentServerDate();

         
            string queryString= "";
            queryString = @"TRUNCATE TABLE SBP_IPO_ResultTemp";
          
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
        
        public void UpdateResultTemp(DataTable dt)
        {
            try
            {
                string tableName = "SBP_IPO_ResultTemp";
                
                _dbConnection.ConnectDatabase();
                _dbConnection.BulkCopy(dt, tableName);
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

        public void UpdateApplication_ByResultTemp()
        {
            CommonBAL comBal = new CommonBAL();

            DateTime TodayServerDate = comBal.GetCurrentServerDate();
            
            string SuccessMsg="Successfull";
            string UnsuccessMsg="UnSuccessfull";
            string queryString_SuccessFull = "";
            string queryString_SuccessFull_RichShareTempVolt = string.Empty;
            string queryString_Insert_ResultSummary = string.Empty;
            string queryString_GetIdentity_Of_ResultSummary = string.Empty;
            int NewResultSummaryID = 0;

            queryString_Insert_ResultSummary = @"INSERT INTO [SBP_Database].[dbo].[SBP_IPO_Result_Summary]
                                                           ([IPOCompany_ID]
                                                           ,[Qty]
                                                           ,[TotalApplicant]
                                                           ,[TotalSuccessFull]
                                                           ,[TotalUnsuccessFull]
                                                           ,[IPO_Session_ID]
                                                           ,[IPO_Session_Name]
                                                           ,[Result_Ref_No]
                                                           ,[Result_Date]                                                          
                                                           ,[Entry_Date]
                                                           ,[Entry_By]
                                                          )

                                                SELECT 
                                                       (
                                                            Select t.IPO_Company_ID From dbo.SBP_IPO_Session as t Where t.ID=temp.[IPO_Session_ID]
                                                       ) AS [IPOCompany_ID]
                                                        ,SUM(No_Of_Share) AS Qty
                                                        ,COUNT([Cust_Code]) AS [TotalApplicant]
                                                        ,(
                                                            Select COUNT(c.Cust_Code) From [SBP_IPO_ResultTemp] as c Where c.[IPO_Session_ID]=temp.[IPO_Session_ID] AND c.Successful_Amount>0
                                                        ) AS [TotalSuccessFull]
                                                        ,(
                                                            Select COUNT(c.Cust_Code) From [SBP_IPO_ResultTemp] as c Where c.[IPO_Session_ID]=temp.[IPO_Session_ID]  AND c.Successful_Amount=0
                                                        ) AS [TotalUnsuccessFull]
                                                      ,[IPO_Session_ID]
                                                      ,(
                                                            Select t.[IPOSession_Name]
                                                            From [SBP_IPO_Session] as t
                                                            Where t.[ID]=temp.[IPO_Session_ID]
                                                      ) AS [IPOSession_Name]
                                                      ,'' AS [Result_Ref_No]
                                                      ,Getdate() AS [Result_Date]
                                                      ,Convert(Varchar(10),GETDATE(),111) AS [Entry_Date]
                                                      ,'"+GlobalVariableBO._userName+ @"' AS Entry_By     
                                                FROM [SBP_Database].[dbo].[SBP_IPO_ResultTemp] as temp
                                                WHERE temp.Cust_Code !='KSL122'
                                                GROUP BY [IPO_Session_ID]";

            queryString_GetIdentity_Of_ResultSummary = "SELECT SCOPE_IDENTITY()";

            queryString_SuccessFull = 
                            @"UPDATE [SBP_IPO_Application_BasicInfo]
                            SET                            
                            [Application_Satus]=3
                            ,[AppStatus_UpdatedBy]='" + GlobalVariableBO._userName + @"'
                            ,[AppStatus_UpdatedDate]=GETDATE()
                            WHERE [IPOSession_ID] IN (
							                            Select [IPO_Session_ID]
							                            From SBP_IPO_ResultTemp
                                                        WHERE Cust_Code !='KSL122'
							                            GROUP BY [IPO_Session_ID]
                            )
                            AND 
                            [Cust_Code] IN (
					                            Select CONVERT(INT,Cust_Code)
					                            From SBP_IPO_ResultTemp
                                                 WHERE Successful_Amount>0
                                                 AND Cust_Code !='KSL122'
                            )
                            AND
                            [Application_Satus]=1
                            ";
            
            /// Rashedul Hasan 29 jun 2015 Only RBSuccessfulResultUpdate
            string NRBSuccessfulResultUpdate = string.Empty;
            NRBSuccessfulResultUpdate = 
                                @"Update SBP_IPO_NRB_Customer_DraftInformation Set 
								Draft_Status=3
								,Update_By='" + GlobalVariableBO._userName + @"'
								,Update_Date=GETDATE()
								Where ID IN(
                                    Select 
                                    d.ID
                                    From SBP_IPO_NRB_Customer_DraftInformation As d
                                    Join SBP_IPO_Application_BasicInfo As b
                                    ON ISNULL(b.Money_Trans_NRB_ID,0)=d.ID
                                    Join SBP_IPO_Application_ExtendedInfo As ext
                                    on ext.BasicInfo_ID=b.ID
                                    Join SBP_IPO_ResultTemp As temp
                                    on temp.IPO_Session_ID=b.IPOSession_ID
                                   And Convert(int,temp.Cust_Code)=Convert(int,b.Cust_Code)
                                    Where 
                                    b.Application_Satus=3
                                    And ext.Applicant_Category='NRB'
                                    And temp.Successful_Amount>0
                                    AND temp.Cust_Code !='KSL122'
                                    And d.Draft_Status=2
                                    And d.Approval_Status=1
                                )
                                ";

            string queryString_UnSuccessFull = "";
            queryString_UnSuccessFull =
                            @"UPDATE [SBP_IPO_Application_BasicInfo]
                            SET 
                            [Fine_Amount]=ISNULL(( Select  t.Deducted_Money From dbo.SBP_IPO_ResultTemp as t Where t.Cust_Code !='KSL122' AND CONVERT(INT,t.Cust_Code)=[SBP_IPO_Application_BasicInfo].Cust_Code AND t.IPO_Session_ID=[SBP_IPO_Application_BasicInfo].IPOSession_ID),0.00)
                            ,[Application_Satus]=4
                            ,[AppStatus_UpdatedBy]='" + GlobalVariableBO._userName + @"'
                            ,[AppStatus_UpdatedDate]=GETDATE()
                            WHERE [IPOSession_ID] IN (
							                            Select [IPO_Session_ID]
							                            From SBP_IPO_ResultTemp
                                                        WHERE Cust_Code !='KSL122'
							                            GROUP BY [IPO_Session_ID]
                            )
                            AND 
                            [Cust_Code] IN (
					                            Select CONVERT(INT,Cust_Code)
					                            From SBP_IPO_ResultTemp                                                
                                                WHERE Successful_Amount=0
                                                AND Cust_Code !='KSL122'
                            )
                            AND
                            [Application_Satus]=1
                            ";

            string NRBUnSuccessfulResultUpdate = "";
            NRBUnSuccessfulResultUpdate = @"
                                Update SBP_IPO_NRB_Customer_DraftInformation 
                                Set 
								Draft_Status=4
								,Update_By='" + GlobalVariableBO._userName + @"'
								,Update_Date=GETDATE()
								Where ID IN(
                                    Select d.ID
                                    From SBP_IPO_NRB_Customer_DraftInformation As d
                                    Join SBP_IPO_Application_BasicInfo As b
                                    ON ISNULL(b.Money_Trans_NRB_ID,0)=d.ID
                                    Join SBP_IPO_Application_ExtendedInfo As ext
                                    on ext.BasicInfo_ID=b.ID
                                    Join SBP_IPO_ResultTemp As temp
                                    on temp.IPO_Session_ID=b.IPOSession_ID
                                    And Convert(int,temp.Cust_Code)=Convert(int,b.Cust_Code)
                                    Where 
                                    b.Application_Satus=4
                                    And ext.Applicant_Category='NRB'
                                    And temp.Successful_Amount=0
                                    AND temp.Cust_Code !='KSL122'
                                    And d.Draft_Status=2
                                    And d.Approval_Status=1
                                )
                                ";

            queryString_SuccessFull_RichShareTempVolt = @"INSERT INTO [SBP_Database].[dbo].[SBP_IPO_Share_TempVolt]
                                                           ([Cust_Code]
                                                           ,[IPOCompany_ID]
                                                           ,[Received_Date]
                                                           ,[Share_TransacetionType_ID]
                                                           ,[Share_TransacetionType_Name]
                                                           ,[Deposit_Withdraw]
                                                           ,[Qty]
                                                           ,[Amount]
                                                           ,[Total_Share_Value]
                                                           ,[Premium]
                                                           ,[Total_Amount]
                                                           ,[Deposit_IPOSession_ID]
                                                           ,[Deposit_IPOSession_Name]
                                                           ,[Deposit_Result_ID]
                                                           ,[Trans_Reason]
                                                           ,[Approval_Status]
                                                           ,[Approval_Date]
                                                           ,[Approval_By]
                                                           ,[Entry_Date]
                                                           ,[Entry_By]
                                                           )
                                                SELECT rsl.[Cust_Code]
                                                      ,sess.[IPO_Company_ID] AS [IPOCompany_ID]
                                                      ,Convert(Varchar(10),GETDATE(),111) AS [Received_Date]
                                                      ,(Select c.[ID] From [SBP_IPO_ShareTrans_Type] As c Where c.[ShareTransType_Name]='IPO') AS  [Share_TransacetionType_ID]    
                                                      ,'IPO' AS [Share_TransacetionType_Name]
                                                      ,'Deposit' AS [Deposit_Withdraw]
                                                      ,rsl.Successful_Amount AS Qty
                                                      ,sess.Amount AS [Amount]
                                                      ,sess.Total_Share_Value AS [Total_Share_Value]
                                                      ,sess.Premium AS [Premium]
                                                      ,sess.TotalAmount AS [Total_Amount]  
                                                      ,rsl.[IPO_Session_ID] AS [Deposit_IPOSession_ID]
                                                      ,sess.IPOSession_Name AS [Deposit_IPOSession_Name]
                                                      ,@ResultID AS [Deposit_Result_ID]
                                                      ,'' AS [Trans_Reason]
                                                      ,1 AS [Approval_Status]
                                                      ,GETDATE() AS [Approval_Date]
                                                      ,'" + GlobalVariableBO._userName + @"' AS [Approval_By]
                                                      ,GETDATE() AS [Entry_Date]
                                                      ,'"+GlobalVariableBO._userName+ @"' AS [Entry_By]
                                                FROM [SBP_Database].[dbo].[SBP_IPO_ResultTemp] as rsl
                                                JOIN SBP_IPO_Session as sess
                                                ON sess.ID=rsl.[IPO_Session_ID]
                                                WHERE rsl.Cust_Code NOT IN (
                                                                            Select p.Cust_Code
                                                                            From [SBP_IPO_Share_TempVolt] as p
                                                                            Where p.[Deposit_IPOSession_ID]=rsl.[IPO_Session_ID]			
                                                )
                                                AND rsl.Successful_Amount>0
                                                 AND rsl.Cust_Code !='KSL122'
    

                                                                                    ";


            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ClearParameters();
                _dbConnection.StartTransaction();
                _dbConnection.ExecuteNonQuery(queryString_Insert_ResultSummary);
                NewResultSummaryID=_dbConnection.ExecuteScalar(queryString_GetIdentity_Of_ResultSummary);
                _dbConnection.ExecuteNonQuery(queryString_SuccessFull);
                _dbConnection.ExecuteNonQuery(queryString_UnSuccessFull);
                _dbConnection.ExecuteNonQuery(NRBSuccessfulResultUpdate);
                //_dbConnection.ExecuteNonQuery(NRBUnSuccessfulResultUpdate);
                _dbConnection.AddParameter("@ResultID", SqlDbType.Int, NewResultSummaryID);
                _dbConnection.ExecuteNonQuery(queryString_SuccessFull_RichShareTempVolt);
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

        public void UpdateResultTempBySessionID(int SessionID)
        {
            try
            {
                string queryString = @"UPDATE SBP_IPO_ResultTemp
                                    SET [IPO_Session_ID]="+SessionID+@"
                                    ";

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

        #endregion ResultImport

        #region ApplicationExport

//        public DataTable GetApplication(int SessionID)
//        {
//            DataTable dataTable;
//            dataTable = null;
//            string queryString = "";
//            queryString = @"SELECT [ID]
//                          ,[Cust_Code]
//                          ,[BO_ID]
//                          ,[Serial_No]
//                          ,Applied_Company
//                          ,[No_Of_Share]*[Lot_No] as 'Total Share'
//                            ,[Lot_No]
//                          ,Convert(decimal(18,2),( [TotalAmount]*[Lot_No] ) ) as 'Total Amount'
//                          ,[Application_Date]
//                    FROM [SBP_Database].[dbo].[SBP_IPO_Application_BasicInfo] as bs
//                    WHERE  [IPOSession_ID]=" + SessionID+@" AND  [Application_Satus]=1
//                    ";
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

        /// <summary>
        /// Applicant category add From NRB Application
        /// Added By Md.Rashedul Hasan ON 24 Aug 2015
        /// </summary>
        /// <param name="SessionID"></param>
        /// <param name="ApplicantCategory"></param>
        /// <returns></returns>
        public DataTable GetApplication(int SessionID, string ApplicantCategory)
        {
            DataTable dataTable;
            dataTable = null;
            string queryString = "";
            if (ApplicantCategory.Equals("RB"))
            {
                queryString = @"SELECT [ID]
                          ,[Cust_Code]
                          ,[BO_ID]
                          ,[Serial_No]
                          ,Applied_Company
                          ,[No_Of_Share]*[Lot_No] as 'Total Share'
                            ,[Lot_No]
                          ,Convert(decimal(18,2),( [TotalAmount]*[Lot_No] ) ) as 'Total Amount'
                          ,[Application_Date]
                    FROM [SBP_Database].[dbo].[SBP_IPO_Application_BasicInfo] as bs
                    WHERE  [IPOSession_ID]=" + SessionID + @" AND  [Application_Satus]=1
                     UNION ALL 
                           SELECT [ID]
                          ,[Cust_Code]
                          ,[BO_ID]
                          ,[Serial_No]
                          ,Applied_Company
                          ,[No_Of_Share]*[Lot_No] as 'Total Share'
                            ,[Lot_No]
                          ,Convert(decimal(18,2),( [TotalAmount]*[Lot_No] ) ) as 'Total Amount'
                          ,[Application_Date]
                    FROM [DEALERDB].[dbo].[SBP_IPO_Application_BasicInfo] as bs
                    WHERE  [IPOSession_ID]=" + SessionID + @" AND  [Application_Satus]=1                   
                    ";
            }
            else if (ApplicantCategory.Equals("NRB"))
            {
                queryString = @"SELECT D.[ID]
                                ,D.[Cust_Code]
                                ,[BO_ID]
                                ,[Serial_No]
                                ,Applied_Company
                                ,[No_Of_Share]*[Lot_No] as 'Total Share'
                                ,[Lot_No]
                                ,Convert(decimal(18,2),( [TotalAmount]*[Lot_No] ) ) as 'Total Amount'
                                ,[Draft_Date]
                                FROM [SBP_Database].[dbo].[SBP_IPO_Application_BasicInfo] as bs
                                Join SBP_IPO_NRB_Customer_DraftInformation As D
                                ON D.ID=bs.Money_Trans_NRB_ID

                                WHERE  [IPOSession_ID]='" + SessionID + @"' 
                                AND [Application_Satus]=1
                                And D.Draft_Status=2"
                                                         ;
            }
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.TimeoutPeriod = 900;
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
        /// Added Applicant Category 
        /// Export RB NRB Category Wise
        /// </summary>
        /// <param name="SessionId"></param>
        /// <param name="ApplicantCategory"></param>
        /// <returns></returns>
        public DataTable GetExportForIssuer(string SessionId, string ApplicantCategory)
        {
            DataTable dt = new DataTable();
            string query = "";
            if (ApplicantCategory.Equals("RB"))
            {
                query = @"
                             declare @CoBoId varchar(30)    
                            set @CoBoId=(select [BO_ID] from [SBP_Broker_Info])   
                             select  Distinct
                            '122' as 'Trec Code'
                             ,'23500' as 'DPID'
                             ,basicInfo.cust_code as 'Customer Id'
                            ,extedInfo.Cust_Name as 'Name Of applicant'
                            ,(@CoBoId+basicInfo.Bo_ID) as 'BO Id no'
                            ,(
								case when additional.IsAffected_Account=1 then 'ASI' 
								else 
								(	case 
									when additional.Recidency='Resident' then 'RB' else 'NRB' 
									end
								) 
								end
							) as 'Applicant category'
                            ,basicInfo.No_Of_Share*basicInfo.Lot_No as 'Number of share'
                            ,(
                            Case 
								When additional.Recidency='Resident' Then 'BDT'								 
									Else ''
										END
								) As Currency
                            ,
                            Convert(decimal(18,2),
                                            ( 
								                Case When additional.Recidency='Resident' Then sess.TotalAmount*basicInfo.Lot_No
									            Else 0.0								
				                				END
                                            )
                            )as 'Applied Amount'
                             
                            ,com.Company_short_code as 'Security name'
                            from SBP_IPO_Application_BasicInfo as basicInfo
                            join SBP_IPO_Application_ExtendedInfo as extedInfo
                            on extedInfo.BasicInfo_ID=basicInfo.ID
                            join dbo.SBP_IPO_Session as sess	                         
                            on sess.Id=basicInfo.IPOSession_ID
                            join SBP_IPO_Company_Info as com
                            on com.ID=sess.IPO_Company_ID
                            left join SBP_Cust_Additional_Info as additional
                            on additional.cust_Code =basicInfo.Cust_code     
                            where sess.ID='" + SessionId + @"'
                            AND basicInfo.Application_Satus=1 
                            And extedInfo.Applicant_Category IN ('RB','ASI')
                            UNION All
                            select distinct
                            '122' as 'Trec Code'
                             ,'23500' as 'DPID'
                             ,basicInfo.cust_code as 'Customer Id'
                            ,extedInfo.Cust_Name as 'Name Of applicant'
                            ,(@CoBoId+basicInfo.Bo_ID) as 'BO Id no'
                            ,(
								case when additional.IsAffected_Account=1 then 'ASI' 
								else 
								(	case 
									when additional.Recidency='Resident' then 'RB' else 'NRB' 
									end
								) 
								end
							) as 'Applicant category'
                            ,basicInfo.No_Of_Share*basicInfo.Lot_No as 'Number of share'
                            ,(
                            Case 
								--When additional.Recidency='Resident' Then 'BDT'								 
								When additional.Recidency='Non Resident'
										Then 
											(
												Case 
													When D.Currency_Name='EUR' THEN 'EUR'
													When D.Currency_Name='GBP'  THEN 'GBP'
													When D.Currency_Name='USD'  THEN 'USD'
												END
											)END
									 
								) As Currency
                            ,
                            Convert(decimal(18,2),
                                                    ( 
								                        Case 
									                        --When additional.Recidency='Resident' Then sess.TotalAmount*basicInfo.Lot_No
									                        --Else(Case 
									                        When additional.Recidency='Non Resident' 
										                        THEN
										                        (
											                        Case 
												                        When D.Currency_Name='EUR' Then Curr_Amount.EUR_Amount*basicInfo.Lot_No
												                        When D.Currency_Name='GBP' Then Curr_Amount.GBP_Amount*basicInfo.Lot_No
												                        When D.Currency_Name='USD' Then Curr_Amount.USD_Amount*basicInfo.Lot_No
											                        END
										                        ) 
										                        --END)
								                        END
                                                    )
                            )as 'Applied Amount'
                             
                            ,com.Company_short_code as 'Security name'
                            from SBP_IPO_Application_BasicInfo as basicInfo
                            join SBP_IPO_Application_ExtendedInfo as extedInfo
                            on extedInfo.BasicInfo_ID=basicInfo.ID
                            join dbo.SBP_IPO_Session as sess	                         
                            on sess.Id=basicInfo.IPOSession_ID
                            join SBP_IPO_Company_Info as com
                            on com.ID=sess.IPO_Company_ID
                            left join SBP_Cust_Additional_Info as additional
                            on additional.cust_Code =basicInfo.Cust_code                             
							JOin SBP_IPO_NRB_Customer_DraftInformation as D
							on basicInfo.IPOSession_ID=D.Intended_IPOSession_ID
							And D.Cust_Code=basicInfo.Cust_Code
							Join
							(
								Select 
								 IPO_Session_ID
								 ,Max(case When Currency_Name='EUR' Then 'EUR' Else '' End)As EUR
								 ,Sum(case When Currency_Name='EUR' Then Currency_Amount Else 0.00 End)As EUR_Amount
								 ,Max(case When Currency_Name='GBP' Then 'GBP' Else '' End)As GBP
								 ,Sum(case When Currency_Name='GBP' Then Currency_Amount Else 0.00 End)As GBP_Amount
								 ,Max(case When Currency_Name='USD' Then 'USD' Else '' End)As USD
								 ,Sum(case When Currency_Name='USD' Then Currency_Amount Else 0.00 End)As USD_Amount
								From SBP_IPO_Session_NRB
								Where IPO_Session_ID='" + SessionId + @"'
								Group by IPO_Session_ID
							)As Curr_Amount
							On Curr_Amount.IPO_Session_ID=basicInfo.IPOSession_ID
                            where sess.ID='" + SessionId + @"'
                            And D.Draft_Status=2
                            AND basicInfo.Application_Satus=1 
                            And extedInfo.Applicant_Category='NRB'


    UNION ALL
                        select  Distinct
                            '122' as 'Trec Code'
                             ,'23500' as 'DPID'
                             ,basicInfo.cust_code as 'Customer Id'
                            ,extedInfo.Cust_Name as 'Name Of applicant'
                            ,(@CoBoId+basicInfo.Bo_ID) as 'BO Id no'
                            ,(
								case when additional.IsAffected_Account=1 then 'ASI' 
								else 
								(	case 
									when additional.Recidency='Resident' then 'DLR' else 'NRB' 
									end
								) 
								end
							) as 'Applicant category'
                            ,basicInfo.No_Of_Share*basicInfo.Lot_No as 'Number of share'
                            ,(
                            Case 
								When additional.Recidency='Resident' Then 'BDT'								 
									Else ''
										END
								) As Currency
                            ,
                            Convert(decimal(18,2),
                                            ( 
								                Case When additional.Recidency='Resident' Then sess.TotalAmount*basicInfo.Lot_No
									            Else 0.0								
				                				END
                                            )
                            )as 'Applied Amount'
                             
                            ,com.Company_short_code as 'Security name'
                            from [DEALERDB].dbo.SBP_IPO_Application_BasicInfo as basicInfo
                            join [DEALERDB].dbo.SBP_IPO_Application_ExtendedInfo as extedInfo
                            on extedInfo.BasicInfo_ID=basicInfo.ID
                            join [DEALERDB].dbo.SBP_IPO_Session as sess	                         
                            on sess.Id=basicInfo.IPOSession_ID
                            join [DEALERDB].dbo.SBP_IPO_Company_Info as com
                            on com.ID=sess.IPO_Company_ID
                            left join [DEALERDB].dbo.SBP_Cust_Additional_Info as additional
                            on additional.cust_Code =basicInfo.Cust_code     
                            where sess.ID='" + SessionId + @"'
                            AND basicInfo.Application_Satus=1 
                            And extedInfo.Applicant_Category IN ('DLR','ASI')
                            UNION All
                            select distinct
                            '122' as 'Trec Code'
                             ,'23500' as 'DPID'
                             ,basicInfo.cust_code as 'Customer Id'
                            ,extedInfo.Cust_Name as 'Name Of applicant'
                            ,(@CoBoId+basicInfo.Bo_ID) as 'BO Id no'
                            ,(
								case when additional.IsAffected_Account=1 then 'ASI' 
								else 
								(	case 
									when additional.Recidency='Resident' then 'RB' else 'NRB' 
									end
								) 
								end
							) as 'Applicant category'
                            ,basicInfo.No_Of_Share*basicInfo.Lot_No as 'Number of share'
                            ,(
                            Case 
								--When additional.Recidency='Resident' Then 'BDT'								 
								When additional.Recidency='Non Resident'
										Then 
											(
												Case 
													When D.Currency_Name='EUR' THEN 'EUR'
													When D.Currency_Name='GBP'  THEN 'GBP'
													When D.Currency_Name='USD'  THEN 'USD'
												END
											)END
									 
								) As Currency
                            ,
                            Convert(decimal(18,2),
                                                    ( 
								                        Case 
									                        --When additional.Recidency='Resident' Then sess.TotalAmount*basicInfo.Lot_No
									                        --Else(Case 
									                        When additional.Recidency='Non Resident' 
										                        THEN
										                        (
											                        Case 
												                        When D.Currency_Name='EUR' Then Curr_Amount.EUR_Amount*basicInfo.Lot_No
												                        When D.Currency_Name='GBP' Then Curr_Amount.GBP_Amount*basicInfo.Lot_No
												                        When D.Currency_Name='USD' Then Curr_Amount.USD_Amount*basicInfo.Lot_No
											                        END
										                        ) 
										                        --END)
								                        END
                                                    )
                            )as 'Applied Amount'
                             
                            ,com.Company_short_code as 'Security name'
                            from [DEALERDB].dbo.SBP_IPO_Application_BasicInfo as basicInfo
                            join [DEALERDB].dbo.SBP_IPO_Application_ExtendedInfo as extedInfo
                            on extedInfo.BasicInfo_ID=basicInfo.ID
                            join [DEALERDB].dbo.SBP_IPO_Session as sess	                         
                            on sess.Id=basicInfo.IPOSession_ID
                            join [DEALERDB].dbo.SBP_IPO_Company_Info as com
                            on com.ID=sess.IPO_Company_ID
                            left join [DEALERDB].dbo.SBP_Cust_Additional_Info as additional
                            on additional.cust_Code =basicInfo.Cust_code                             
							JOin [DEALERDB].dbo.SBP_IPO_NRB_Customer_DraftInformation as D
							on basicInfo.IPOSession_ID=D.Intended_IPOSession_ID
							And D.Cust_Code=basicInfo.Cust_Code
							Join
							(
								Select 
								 IPO_Session_ID
								 ,Max(case When Currency_Name='EUR' Then 'EUR' Else '' End)As EUR
								 ,Sum(case When Currency_Name='EUR' Then Currency_Amount Else 0.00 End)As EUR_Amount
								 ,Max(case When Currency_Name='GBP' Then 'GBP' Else '' End)As GBP
								 ,Sum(case When Currency_Name='GBP' Then Currency_Amount Else 0.00 End)As GBP_Amount
								 ,Max(case When Currency_Name='USD' Then 'USD' Else '' End)As USD
								 ,Sum(case When Currency_Name='USD' Then Currency_Amount Else 0.00 End)As USD_Amount
								From SBP_IPO_Session_NRB
								Where IPO_Session_ID='" + SessionId + @"'
								Group by IPO_Session_ID
							)As Curr_Amount
							On Curr_Amount.IPO_Session_ID=basicInfo.IPOSession_ID
                            where sess.ID='" + SessionId + @"'
                            And D.Draft_Status=2
                            AND basicInfo.Application_Satus=1 
                            And extedInfo.Applicant_Category='NRB'";
            }
            if (ApplicantCategory.Equals("NRB"))
            {
                query = @"declare @CoBoId varchar(30)    
                        set @CoBoId=(select [BO_ID] from [SBP_Broker_Info])

                        select distinct
                        '122' as 'Trec Code'
                         ,'23500' as 'DPID'
                         ,basicInfo.cust_code as 'Customer Id'
                        ,extedInfo.Cust_Name as 'Name Of applicant'
                        ,(@CoBoId+basicInfo.Bo_ID) as 'BO Id no'
                        ,extedInfo.Applicant_Category as 'Applicant category'
                        ,D.Currency_Name As Currency                            
                         ,CONVERT(decimal(26,2), D.Currency_Amount) As Amount
                        --,Convert(decimal(18,2),D.Currency_Amount) As Amount                                                                               )as 'Amount'
                        ,D.FD_NO As 'Draft NO'
                        ,D.Bank_Name As 'Bank Name'
                        ,D.BranchName As 'Branch Name'
                        ,CONVERT(varchar(11),D.Draft_Date,103) As 'Date'
                        ,com.Company_short_code as 'Security name'
                        ,'' As Remarks
                        --,basicInfo.No_Of_Share*basicInfo.Lot_No as 'Number of share'
                        from SBP_IPO_Application_BasicInfo as basicInfo
                        join SBP_IPO_Application_ExtendedInfo as extedInfo
                        on extedInfo.BasicInfo_ID=basicInfo.ID
                        join dbo.SBP_IPO_Session as sess	                         
                        on sess.Id=basicInfo.IPOSession_ID
                        join SBP_IPO_Company_Info as com
                        on com.ID=sess.IPO_Company_ID
                        join SBP_Cust_Additional_Info as additional
                        on additional.cust_Code =basicInfo.Cust_code                             
                        JOin SBP_IPO_NRB_Customer_DraftInformation as D
                        on basicInfo.IPOSession_ID=D.Intended_IPOSession_ID
                        And D.Cust_Code=basicInfo.Cust_Code
                        where sess.ID='" + SessionId + @"'
                        And D.Draft_Status=2
                        AND basicInfo.Application_Satus=1 
                        And extedInfo.Applicant_Category='NRB'";
            }
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.TimeoutPeriod = 900;
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
        public DataTable GetApplication_ForExport(int SessionID)
        {
            DataTable dataTable;
            dataTable = null;
            string queryString = "";
            queryString = @"SELECT [ID]
                          ,[Cust_Code]
	                      ,(
			                    Select c.Cust_Name 
			                    From SBP_Cust_Personal_Info as c
			                    Where c.Cust_Code=bs.[Cust_Code]
	                      )AS Cust_Name
	                      ,(
		                    (Select c.BO_ID From dbo.SBP_Broker_Info as c)+[BO_ID]
	                      ) AS [BO_ID]
                          ,[Serial_No]
                          ,[Applied_Company]
                          ,[No_Of_Share]
                          ,[TotalAmount]
                          ,(
		                    Select c.Recidency		
		                    From SBP_Cust_Additional_Info as c
		                    WHERE c.Cust_Code=bs.Cust_Code
                          )AS [CategoryApplicant]
                          ,[Application_Date]
                    FROM [SBP_Database].[dbo].[SBP_IPO_Application_BasicInfo] as bs
                    WHERE  [IPOSession_ID]=" + SessionID + @" AND  [Application_Satus]=1
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

        #endregion ApplicationExport

        #region MoneyRefund

        public DataTable GetRefundInformation_ForTransfer(int SessionID)
        {
            DataTable dataTable;
            dataTable = null;
            string queryString = "";
            queryString = @"SELECT bs.[ID]
                          ,[Cust_Code]
	                      ,(
			                    Select c.Cust_Name 
			                    From SBP_Cust_Personal_Info as c
			                    Where c.Cust_Code=bs.[Cust_Code]
	                      )AS Cust_Name
	                      ,[BO_ID]
                          ,bs.[Serial_No]
                          ,[Applied_Company]
                          ,[No_Of_Share]
                          ,[TotalAmount] as [IPO Amount]
                          ,ISNULL([Fine_Amount],0) as [Fine Amount]
                          ,[TotalAmount]-ISNULL([Fine_Amount],0) as [Net Amount]  
                          ,(
		                    Select c.Recidency		
		                    From SBP_Cust_Additional_Info as c
		                    WHERE c.Cust_Code=bs.Cust_Code
                          )AS [CategoryApplicant]
                          ,[Application_Date]
                          ,rf.Method_Name as [Method_Name]
                          ,ext.Refund_Other_Details as [Transfer To]
                    FROM [SBP_Database].[dbo].[SBP_IPO_Application_BasicInfo] as bs
                    JOIN SBP_IPO_Application_ExtendedInfo as ext
                    ON
                    bs.ID=ext.BasicInfo_ID 
                    JOIN dbo.SBP_IPO_MoneyRefund_Method as rf
                    ON
                    rf.ID=ext.Refund_Method
                    WHERE  
                    [IPOSession_ID]="+SessionID+ @" AND  [Application_Satus]=4
                    AND rf.Method_Name IN ('TRTA','TRPR','TRIPO','TRPRIPO')
                    AND bs.Cust_Code NOT IN (
							Select Cust_Code
							From [SBP_IPO_Customer_Broker_MoneyTransaction]
							Where Trans_Reason LIKE '%Refund%' AND [Intended_IPOSession_ID]=" + SessionID + @"
                            AND Money_TransactionType_Name IN ('TRIPOApp')
					)
                    AND ext.Applicant_Category<>'NRB'
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

        public DataTable GetRefundInformation_ForBankTransfer(int SessionID)
        {
            DataTable dataTable;
            dataTable = null;
            string queryString = "";
            queryString = @"
                    SELECT bs.[ID]
                          ,[Cust_Code]
	                      ,(
			                    Select c.Cust_Name 
			                    From SBP_Cust_Personal_Info as c
			                    Where c.Cust_Code=bs.[Cust_Code]
	                      )AS Cust_Name
	                      ,[BO_ID]
                          ,bs.[Serial_No]
                          ,[Applied_Company]
                          ,[No_Of_Share]
                          ,[TotalAmount]
                          ,(
		                    Select c.Recidency		
		                    From SBP_Cust_Additional_Info as c
		                    WHERE c.Cust_Code=bs.Cust_Code
                          )AS [CategoryApplicant]
                          ,[Application_Date]
                          ,rf.Method_Name as [Method_Name]
                    FROM [SBP_Database].[dbo].[SBP_IPO_Application_BasicInfo] as bs
                    JOIN SBP_IPO_Application_ExtendedInfo as ext
                    ON
                    bs.ID=ext.BasicInfo_ID 
                    JOIN dbo.SBP_IPO_MoneyRefund_Method as rf
                    ON
                    rf.ID=ext.Refund_Method
                    WHERE  
                    [IPOSession_ID]=" + SessionID + @" AND  [Application_Satus]=4
                    AND rf.Method_Name IN ('EFT','MMT')
                    AND bs.Cust_Code NOT IN (
							Select Cust_Code
							From [SBP_IPO_Customer_Broker_MoneyTransaction]
							Where Trans_Reason LIKE '%Refund%' AND [Intended_IPOSession_ID]=" + SessionID + @"
                            AND Money_TransactionType_Name='"+Indication_IPOPaymentTransaction.EFT+ @"'									
					)
                    AND ext.Applicant_Category<>'NRB'
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

        public DataTable RefundProcess_ForTransfer(int SessionID)
        {
            DataTable dataTable;
            dataTable = null;
            string queryString = "";
            string RefundAppCharge_TransReason = Indication_TransactioBasedCharge.TransReasonList
               .Where(t => t.Key == Indication_TransactioBasedCharge.IPOAppRefund)
               .Select(t => Convert.ToString(t.Value)).FirstOrDefault();

            string RefundAppCharge_VoucherNo = Indication_TransactioBasedCharge.VoucherSLnoList
                .Where(t => t.Key == Indication_TransactioBasedCharge.IPOAppRefund)
                .Select(t => Convert.ToString(t.Value)).FirstOrDefault();

            queryString = @"[SBP_IPOMoneyRefundProcess_Transfer]";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ClearParameters();
                _dbConnection.AddParameter("@RefundCharge_VoucherNo", SqlDbType.VarChar, RefundAppCharge_VoucherNo);
                _dbConnection.AddParameter("@RefundCharge_TransReason", SqlDbType.VarChar, RefundAppCharge_TransReason);
                _dbConnection.AddParameter("@Session_ID", SqlDbType.Int, SessionID);
                _dbConnection.AddParameter("@Entry_By", SqlDbType.VarChar, GlobalVariableBO._userName);
                _dbConnection.AddParameter("@Entry_Branch_ID", SqlDbType.VarChar, GlobalVariableBO._branchId);
                _dbConnection.ExecuteProQuery(queryString);
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

        

        public DataTable RefundProcess_ForBankTransfer(int SessionID)
        {
            DataTable dataTable;
            dataTable = null;
            string queryString = "";
            
            string RefundAppCharge_TransReason = Indication_TransactioBasedCharge.TransReasonList
             .Where(t => t.Key == Indication_TransactioBasedCharge.IPOAppRefund)
             .Select(t => Convert.ToString(t.Value)).FirstOrDefault();

            string RefundAppCharge_VoucherNo = Indication_TransactioBasedCharge.VoucherSLnoList
                .Where(t => t.Key == Indication_TransactioBasedCharge.IPOAppRefund)
                .Select(t => Convert.ToString(t.Value)).FirstOrDefault();

            queryString = @"[SBP_IPOMoneyRefundProcess]";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ClearParameters();
                _dbConnection.AddParameter("@RefundCharge_VoucherNo", SqlDbType.VarChar, RefundAppCharge_VoucherNo);
                _dbConnection.AddParameter("@RefundCharge_TransReason", SqlDbType.VarChar, RefundAppCharge_TransReason);
                _dbConnection.AddParameter("@Session_ID", SqlDbType.Int, SessionID);
                _dbConnection.AddParameter("@Entry_By", SqlDbType.VarChar, GlobalVariableBO._userName);
                _dbConnection.AddParameter("@Entry_Branch_ID", SqlDbType.VarChar, GlobalVariableBO._branchId);
                _dbConnection.ExecuteProQuery(queryString);
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



        #endregion MoneyRefund

        #region Auto Voucher For EFT
        public bool CheckLock_UiTransAppliedFor_EFT()
        {
            bool check = false;
            DataTable dt = new DataTable();
            string query = @"Select IsLocked From SBP_Serial_Generator where Serial_Purpose='Payment'";
            try
            {
                //_dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            if (dt.Rows.Count > 0)
            {
                check = (bool)dt.Rows[0][0];
            }
            return check;
        }

        public void Lock_UITransApplied_EFT()
        {
            string query = @"update SBP_Serial_Generator set IsLocked=1 where Serial_Purpose='Payment'";
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
        public string GetPrefix_UITransApplied_EFT()
        {
            DataTable dt = new DataTable();
            string query = @"SELECT  prefix  from SBP_Serial_Generator where Serial_Purpose='Payment'";
            try
            {
                //_dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //finally
            //{
            //    _dbConnection.CloseDatabase();
            //}

            string no = "";
            if (dt.Rows.Count > 0)
            {
                no = dt.Rows[0][0].ToString();
            }
            return no;
        }
        public int GetSerial_UITransApplied_EFT()
        {
            string query = @"SELECT ISNULL(Sl_No,1) from SBP_Serial_Generator where Serial_Purpose='Payment'";
            int serial = 0;
            DataTable dt = new DataTable();
            try
            {
                //_dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //finally
            //{
            //    _dbConnection.CloseDatabase();
            //}

            if (dt.Rows.Count > 0)
            {
                serial = Convert.ToInt32(dt.Rows[0][0].ToString());
            }
            return serial;
        }
        public void UpdateVoucherNo_UITransApplied_EFT(int id)
        {
            string query = @"update SBP_Serial_Generator set Sl_No=" + id + " where [Serial_Purpose]='Payment'";
            try
            {
                //_dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery_EmergencyImplementation(query);
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
        public void UnLock_UITransApplied_EFT()
        {
            DataTable dt = new DataTable();
            string query = @"update SBP_Serial_Generator set IsLocked=0 where Serial_Purpose='Payment'";
            try
            {
                //_dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery_EmergencyImplementation(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //finally
            //{
            //    _dbConnection.CloseDatabase();
            //}
            //bool check = true;
            //if (dt.Rows.Count > 0)
            //{
            //    check =Convert.ToBoolean( dt.Rows[0][0]);
            //}
            //return check;
        }
        #endregion

        #region Auto Voucher
        public bool CheckLock()
        {
            DataTable dt = new DataTable();
            string query = @"SELECT IsLocked from SBP_Serial_Generator where Serial_Purpose='TransferIPO'";
            try
            {
                _dbConnection.ConnectDatabase();
                dt=_dbConnection.ExecuteQuery(query);
                 
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }

            bool check = false;
            if (dt.Rows.Count > 0)
            {
                check = Convert.ToBoolean(dt.Rows[0]["IsLocked"]);
            }            
            return check;
        }
        public bool CheckLock_UITrasnApplied()
        {
            DataTable dt = new DataTable();
            string query = @"SELECT IsLocked from SBP_Serial_Generator where Serial_Purpose='TransferIPO'";
            try
            {
                //_dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(query);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            //finally
            //{
            //    _dbConnection.CloseDatabase();
            //}

            bool check = false;
            if (dt.Rows.Count > 0)
            {
                check = Convert.ToBoolean(dt.Rows[0]["IsLocked"]);
            }
            return check;
        }
        public void Lock()
        {
            string query = @"update SBP_Serial_Generator set IsLocked=1 where Serial_Purpose='TransferIPO'";
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
        public void Lock_UITransApplied()
        {
            string query = @"update SBP_Serial_Generator set IsLocked=1 where Serial_Purpose='TransferIPO'";
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
        public void UnLock()
        {
            DataTable dt = new DataTable();
            string query = @"update SBP_Serial_Generator set IsLocked=0 where Serial_Purpose='TransferIPO'";
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
            //bool check = true;
            //if (dt.Rows.Count > 0)
            //{
            //    check =Convert.ToBoolean( dt.Rows[0][0]);
            //}
            //return check;
        }
        public void UnLock_UITransApplied()
        {
            DataTable dt = new DataTable();
            string query = @"update SBP_Serial_Generator set IsLocked=0 where Serial_Purpose='TransferIPO'";
            try
            {
                //_dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery_EmergencyImplementation(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //finally
            //{
            //    _dbConnection.CloseDatabase();
            //}
            //bool check = true;
            //if (dt.Rows.Count > 0)
            //{
            //    check =Convert.ToBoolean( dt.Rows[0][0]);
            //}
            //return check;
        }
        public void UpdateVoucherNo(int id)
        {
            string query = @"update SBP_Serial_Generator set Sl_No=" + id + " where [Serial_Purpose]='" + Indication_Fixed_VoucherNo_TransReason.TransferIPO_Purpose + "'";
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
        public void UpdateVoucherNo_UITransApplied(int id)
        {
            string query = @"update SBP_Serial_Generator set Sl_No=" + id + " where [Serial_Purpose]='" + Indication_Fixed_VoucherNo_TransReason.TransferIPO_Purpose + "'";
            try
            {
                //_dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery_EmergencyImplementation(query);
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
        public int GetSerial()
        {
            string query = @"SELECT ISNULL(Sl_No,1) from SBP_Serial_Generator where Serial_Purpose='TransferIPO'";
            int serial = 0;
            DataTable dt = new DataTable();
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
            
            if (dt.Rows.Count > 0)
            {
                serial = Convert.ToInt32(dt.Rows[0][0].ToString());
            }
            return serial;
        }
        
        public int GetSerial_UITransApplied()
        {
            string query = @"SELECT ISNULL(Sl_No,1) from SBP_Serial_Generator where Serial_Purpose='TransferIPO'";
            int serial = 0;
            DataTable dt = new DataTable();
            try
            {
                //_dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //finally
            //{
            //    _dbConnection.CloseDatabase();
            //}

            if (dt.Rows.Count > 0)
            {
                serial = Convert.ToInt32(dt.Rows[0][0].ToString());
            }
            return serial;
        }

        public string GetPrefix()
        {
            DataTable dt = new DataTable();
            string query = @"SELECT  prefix  from SBP_Serial_Generator where Serial_Purpose='TransferIPO'";
            try
            {
                _dbConnection.ConnectDatabase();
                 dt=_dbConnection.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            string no = "";
            if (dt.Rows.Count > 0)
            {
                no = dt.Rows[0][0].ToString();
            }
            return no;
        }
        public string GetPrefix_UITransApplied()
        {
            DataTable dt = new DataTable();
            string query = @"SELECT  prefix  from SBP_Serial_Generator where Serial_Purpose='TransferIPO'";
            try
            {
                //_dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //finally
            //{
            //    _dbConnection.CloseDatabase();
            //}
            
            string no = "";
            if (dt.Rows.Count > 0)
            {
                no = dt.Rows[0][0].ToString();
            }
            return no;
        }
         

        #endregion

    }
}
