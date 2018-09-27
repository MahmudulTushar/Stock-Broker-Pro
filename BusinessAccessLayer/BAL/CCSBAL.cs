using System;
using System.Data;
using BusinessAccessLayer.BO;
using DataAccessLayer;
using BusinessAccessLayer.Constants;
using System.Data;
using System.Data.SqlClient;

namespace BusinessAccessLayer.BAL
{
    public class CCSBAL
    {

        public void Connect_SBP()
        {
            _dbConnection.ConnectDatabase();
            _dbConnection.StartTransaction();
        }

        public void CloseConnection_SBP()
        {
            _dbConnection.ConnectDatabase();
        }

        public void Commit_SBP()
        {
            _dbConnection.Commit();

        }

        public void Rollback_SBP()
        {
            _dbConnection.Rollback();

        }

        public void Connect_SMS()
        {
            _dbConnection.ConnectDatabase_SMSSender();
            _dbConnection.StartTransaction_SMSSender();
        }

        public void CloseConnection_SMS()
        {
            _dbConnection.CloseDatabase_SMSSender();

        }

        public void Commit_SMS()
        {
            _dbConnection.Commit_SMSSender();

        }

        public void Rollback_SMS()
        {
            _dbConnection.Rollback_SMSSender();
        }

        public SqlConnection GetConnection()
        {
            return _dbConnection.GetConnection();
        }
        public void SetConnection(SqlConnection con)
        {
            _dbConnection.SetConnection(con);
        }

        public SqlConnection GetConnection_SMS()
        {
            return _dbConnection.GetConnection_SMSSender();
        }
        public void SetConnection_SMS(SqlConnection con)
        {
            _dbConnection.SetConnection_SMSSender(con);
        }
        
        public SqlTransaction GetTransaction()
        {
            return _dbConnection.GetTransaction();
        }
        public void SetTransaction(SqlTransaction trans)
        {
            _dbConnection.SetTransaction(trans);
        }
        
        public SqlTransaction GetTransaction_SMS()
        {
            return _dbConnection.GetTransaction_SMSSender();
        }

        public void SetTransaction_SMS(SqlTransaction trans)
        {
            _dbConnection.SetTransaction_SMSSender(trans);
        }
        
        private DbConnection _dbConnection;
        public CCSBAL()
        {
            _dbConnection = new DbConnection();
        }
         
        public void CCS_DATA_SYNC()
        {
            string queryString = @"SP_CCS_DATATRANS";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.TimeoutPeriod = 5000;
                _dbConnection.ActiveStoredProcedure();
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
        
        public void CCS_EmptyTables()
        {
            string queryString = @"SB_CCS_EmptyTables";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.TimeoutPeriod = 5000;
                _dbConnection.ActiveStoredProcedure();
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

        public void CCS_EmptyTables_UITransApplied()
        {
            string queryString = @"SB_CCS_EmptyTables";
            try
            {
                //_dbConnection.ConnectDatabase();
                //_dbConnection.TimeoutPeriod = 5000;
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.ExecuteProQuery(queryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                //_dbConnection.CloseDatabase();
            }
        }
        public void CCS_Customers()
        {
            string queryString = @"SB_CCS_Customers";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.TimeoutPeriod = 5000;
                _dbConnection.ActiveStoredProcedure();
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
        public void CCS_Company()
        {
            string queryString = @"SB_CCS_Company";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.TimeoutPeriod = 5000;
                _dbConnection.ActiveStoredProcedure();
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
        public void CCS_ShareDW()
        {
            string queryString = @"SB_CCS_ShareDW";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.TimeoutPeriod = 5000;
                _dbConnection.ActiveStoredProcedure();
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
        public SqlDataReader Get_CCS_Company_UITransApplied()
        {
            SqlDataReader dr;
            string queryString = @"SELECT  
                                 Code_No
                                 ,Comp_Name
                                 ,Comp_Short_Code
                                 ,Comp_Cat_ID=
                                 (
	                                CASE  
		                                WHEN Comp_Cat_ID= 1 THEN 'A'  
		                                WHEN Comp_Cat_ID= 2 THEN 'B'  
		                                WHEN Comp_Cat_ID= 3 THEN 'G'  
		                                WHEN Comp_Cat_ID= 4 THEN 'N'   
		                                WHEN Comp_Cat_ID= 5 THEN 'Z'  
	                                END  
                                 )
                                 ,Face_Value
                                 ,Market_Lot
                                 ,Share_Type
                                 ,Issuer_ID
                                 ,ISIN_No 
                                 FROM SBP_Database..SBP_Company  ";
            try
            {
                //_dbConnection.ConnectDatabase();
                dr=_dbConnection.ExecuteReader(queryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                //_dbConnection.CloseDatabase();
            }
            return dr;
        }

        public void Insert_CCS_Company_UITransApplied(SqlDataReader dr)
        {
            
            try{
                
                while (dr.Read())
                {
                    string queryString = @"INSERT INTO dbksclCallCenter..tbl_company_all(code_no,name,Company_Short_Code,mkt_group,face_val,mkt_lot,type,issuer_id,isin)   
                                VALUES(
                                    '" + dr["Code_No"] + @"'
                                    ,'" + dr["Comp_Name"] + @"'
                                    ,'" + dr["Comp_Short_Code"] + @"'
                                    ,'" + dr["Comp_Cat_ID"] + @"'
                                    ," + dr["Face_Value"] + @"
                                    ," + dr["Market_Lot"] + @"
                                    ,'" + dr["Share_Type"] + @"'
                                    ," + dr["Issuer_ID"] + @"
                                    ,'" + dr["ISIN_No"] + @"'
                                )";
                    _dbConnection.ExecuteNonQuery_SMSSender(queryString);
                }                
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                //_dbConnection.CloseDatabase();
            }
        }
        public SqlDataReader Get_CCS_ShareDW_UITransApplied()
        {
            SqlDataReader dr;
            string queryString = @" SELECT  
                                 Cust_Code
                                 ,Comp_Short_Code
                                 ,Quantity
                                 ,Deposit_Withdraw
                                 ,Received_Date
                                 ,Vouchar_No
                                 ,No_Script
                                 ,Share_Type
                                 ,Entry_Date 
                                 FROM SBP_Database..SBP_Share_DW  ";
            try
            {
                //_dbConnection.ConnectDatabase();
                dr = _dbConnection.ExecuteReader(queryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                //_dbConnection.CloseDatabase();
            }
            return dr;
        }

        public void Insert_CCS_ShareDW_UITransApplied(SqlDataReader dr)
        {

            try
            {
                while (dr.Read())
                {
                    string queryString = @"INSERT INTO dbksclCallCenter..tbl_Share_Draw_Withdraw_All(Cust_Code,Company_Short_Code,quantity,Draw_Withdraw,Received_date,bill_no,no_script,Type,Entry_Date)     
                                VALUES(
                                    '" + dr["Cust_Code"] + @"'
                                    ,'" + dr["Comp_Short_Code"] + @"'
                                    ," + dr["Quantity"] + @"
                                    ,'" + dr["Deposit_Withdraw"] + @"'
                                    ,'" + dr["Received_Date"] + @"'
                                    ,'" + dr["Vouchar_No"] + @"'
                                    ,'" + dr["Share_Type"] + @"'
                                    ," + dr["Issuer_ID"] + @"
                                    ,'" + dr["Entry_Date"] + @"'
                                )";
                    _dbConnection.ExecuteNonQuery_SMSSender(queryString);
                }

            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                //_dbConnection.CloseDatabase();
            }
        }
        public SqlDataReader Get_CCS_Payment_UITransApplied()
        {
            SqlDataReader dr;
            string queryString = @"SELECT  
                                   CONVERT(NUMERIC,Cust_Code) AS Cust_Code,  
	                               Amount ,  
	                               Payment_Media ,  
	                               Received_Date ,          
	                               Payment_Media_No ,  
	                               Payment_Media_Date ,  
	                               Bank_Name ,  
	                               Received_By ,  
	                               Deposit_Withdraw ,  
	                               Voucher_Sl_No ,  
	                               Entry_Date,   
	                               'N/A' 
	                            FROM SBP_Database..SBP_Payment WHERE CONVERT(NUMERIC,Cust_Code)>0   ";
            try
            {
                //_dbConnection.ConnectDatabase();
                dr = _dbConnection.ExecuteReader(queryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                //_dbConnection.CloseDatabase();
            }
            return dr;
        }

        public void Insert_CCS_Payment_UITransApplied(SqlDataReader dr)
        {

            try
            {
                while (dr.Read())
                {
                    string queryString = @"	 INSERT INTO dbksclCallCenter..tbl_Cust_Paymnet_All  
	                                       ( Cust_Code ,  
		                                     amount ,  
		                                     Check_Cash ,  
		                                     Received_date ,  
		                                     check_no ,  
		                                     check_date ,  
		                                     bank_name ,  
		                                     received_by ,  
		                                     Deposit_withdraw ,  
		                                     SL_No ,  
		                                     Entry_Date ,  
		                                     tk_in_word  
	                                       )  
                                       VALUES(
                                           '"+dr["Cust_Code"]+@"',  
                                           "+dr["Amount"]+@",  
                                           '"+dr["Payment_Media"]+@"' ,  
                                           '"+dr["Received_Date"]+@"' ,          
                                           '"+dr["Payment_Media_No"]+@"' ,  
                                           '"+dr["Payment_Media_Date"]+@"' ,  
                                           '"+dr["Bank_Name"]+@"',  
                                           '"+dr["Received_By"]+@"',  
                                           '"+dr["Deposit_Withdraw"]+@"',  
                                           '"+dr["Voucher_Sl_No"]+@"',  
                                           '"+dr["Entry_Date"]+@"',   
                                           '"+dr["'N/A'"]+@"' 
                                        )";       
                    _dbConnection.ExecuteNonQuery_SMSSender(queryString);
                }

            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                //_dbConnection.CloseDatabase();
            }
        }

        public SqlDataReader Get_CCS_ShareBalance_UITransApplied()
        {
            SqlDataReader dr;
            string queryString = @"SELECT  
                                   CONVERT(NUMERIC,Cust_Code) AS Cust_Code ,  
                                   Comp_Short_Code ,  
                                   SUM(Balance) AS Balance ,  
                                   SUM(Matured_Balance) AS Matured_Balance ,  
                                   (SELECT Comp_Category FROM SBP_Comp_Category,dbo.SBP_Company WHERE dbo.SBP_Company.Comp_Cat_ID=dbo.SBP_Comp_Category.Comp_Cat_ID AND dbo.SBP_Company.Comp_Short_Code=dbo.SBP_Share_Balance_Temp.Comp_Short_Code) AS Comp_Category,  
                                   (SELECT Share_Type FROM dbo.SBP_Company WHERE dbo.SBP_Company.Comp_Short_Code=dbo.SBP_Share_Balance_Temp.Comp_Short_Code) AS Share_Type
                                   FROM SBP_Database..SBP_Share_Balance_Temp  
                                   WHERE CONVERT(NUMERIC,Cust_Code)>0 AND Comp_Short_Code!=''  
                                   GROUP BY Cust_Code,Comp_Short_Code";
            try
            {
                //_dbConnection.ConnectDatabase();
                dr = _dbConnection.ExecuteReader(queryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                //_dbConnection.CloseDatabase();
            }
            return dr;
        }

        public void Insert_CCS_ShareBalance_UITransApplied(SqlDataReader dr)
        {

            try
            {
                while (dr.Read())
                {
                    string queryString = @"
                                       INSERT INTO dbksclCallCenter..tbl_Share_Balance  
                                           ( Cust_Code ,  
                                             Company_Short_Code ,  
                                             Balance ,  
                                             Matured_Balance ,  
                                             Mkt_group ,  
                                             Type  
                                           )  
                                       VALUES(
                                           '"+dr["Cust_Code"]+@"',
                                           '"+dr["Comp_Short_Code"]+@"',  
                                           "+dr["Balance"]+@",  
                                           "+dr["Matured_Balance"]+@",  
                                           '"+dr["Comp_Category"]+@"',
                                           '"+dr["Share_Type"] + @"'
                                       )";  
                    _dbConnection.ExecuteNonQuery_SMSSender(queryString);
                }

            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                //_dbConnection.CloseDatabase();
            }
        }

        public SqlDataReader Get_CCS_ShareDetails_UITransApplied()
        {
            SqlDataReader dr;
            string queryString = @" 
                                SELECT  Cust_Code ,  
                                   Comp_Short_Code ,  
                                   Buy_Dep_Qty ,  
                                   Sell_Withdraw_Qty ,  
                                   Balance ,  
                                   Trade_Date ,                  
                                   Buy_Total ,  
                                   Buy_Avg ,  
                                   Sell_Total ,  
                                   Sell_Avg,  
                                   Remarks 
                                FROM SBP_Database..SBP_Share_Balance_Temp";
            try
            {
                //_dbConnection.ConnectDatabase();
                dr = _dbConnection.ExecuteReader(queryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                //_dbConnection.CloseDatabase();
            }
            return dr;
        }

        public void Insert_CCS_ShareDetails_UITransApplied(SqlDataReader dr)
        {

            try
            {
                while (dr.Read())
                {
                    string queryString = @"
                                       INSERT INTO dbksclCallCenter..tbl_ShareTrade_Details  
                                       ( Cust_Code ,  
                                         Company_Short_Code ,  
                                         Buy_Deposit_Qty ,  
                                         Sell_WithDraw_Qty ,  
                                         Balance ,  
                                         Transaction_Date ,  
                                         Buy_Total ,  
                                         Buy_Avg ,  
                                         Sell_Total ,  
                                         Sell_Avg ,  
                                         Remarks  
                                       )  
                                       VALUES(
                                           '" + dr["Cust_Code"] + @"' ,  
                                           '" + dr["Comp_Short_Code"] + @"' ,  
                                           " + dr["Buy_Dep_Qty"] + @" ,  
                                           " + dr["Sell_Withdraw_Qty"] + @" ,  
                                           " + dr["Balance"] + @" ,  
                                           '" + dr["Trade_Date"] + @"' ,                  
                                           " + dr["Buy_Total"] + @" ,  
                                           " + dr["Buy_Avg"] + @" ,  
                                           " + dr["Sell_Total"] + @" ,  
                                           " + dr["Sell_Avg"] + @",  
                                           '" + dr["Remarks"] + @"'
                                      )";
                    _dbConnection.ExecuteNonQuery_SMSSender(queryString);
                }

            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                //_dbConnection.CloseDatabase();
            }
        }


        public void CCS_Payment()
        {
            string queryString = @"SB_CCS_Payment";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.TimeoutPeriod = 5000;
                _dbConnection.ActiveStoredProcedure();
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
        public void CCS_ShareBalance()
        {
            string queryString = @"SB_CCS_ShareBalance";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.TimeoutPeriod = 5000;
                _dbConnection.ActiveStoredProcedure();
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
        public void CCS_ShareDetails()
        {
            string queryString = @"SB_CCS_ShareDetails";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.TimeoutPeriod = 5000;
                _dbConnection.ActiveStoredProcedure();
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
        public void CCS_CustomerAccount()
        {
            string queryString = @"SB_CCS_CustomerAccount";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.TimeoutPeriod = 5000;
                _dbConnection.ActiveStoredProcedure();
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
        public void CCS_MoneyTransConfirmationSMS_Sync()
        {
            string queryString = @"SBP_Process_SyncSMSServer_MoneyTransaction";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.TimeoutPeriod = 5000;
                _dbConnection.ActiveStoredProcedure();
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
        public void CCS_PopulateTemp_EmailTradeConfirmation()
        {
            string queryString = @"SBP_Populate_EmailNotification_TradeConfirmationTemp";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.TimeoutPeriod = 5000;
                _dbConnection.ActiveStoredProcedure();
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
        public void CCS_PopulateTemp_ForSMS_MoneyTransaction()
        {
            string queryString = @"SBP_Populate_SyncSmsServer_ForSMS_MoneyTransactionTemp";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.TimeoutPeriod = 5000;
                _dbConnection.ActiveStoredProcedure();
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
        public void CCS_PopulateTemp_ForEmail_MoneyTransaction()
        {
            string queryString = @"SBP_Populate_SyncSmsServer_ForEmail_MoneyTransactionTemp";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.TimeoutPeriod = 5000;
                _dbConnection.ActiveStoredProcedure();
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
        public DataTable CCS_GetTemp_MoneyTransaction_ForSMS_ForGrid()
        {
            DataTable dt = new DataTable();
            string queryString = @"Select 
                                [IsSelected] AS IsSelected
                                ,[ID]
                                ,tmp.[Cust_Code]
                                ,[Payment_Media]
                                ,[Payment_Media_No]
                                ,[Amount]
                                ,[Deposit_Withdraw]
                                ,[Entry_Branch_Id]
                                ,[Money_Balance]
                                ,[ReferenceNo]
                                ,[Destination_No]
                                ,Convert(varchar(10),GETDATE(),105) AS Date
                                From [SBP_SyncSmsServer_MoneyTransactionTemp] as tmp
                                WHERE NOT EXISTS (
		                                SELECT t.* 
		                                FROM [dbksclCallCenter].[dbo].[tbl_MoneyTransConfirmation_SMS] as t
		                                WHERE t.ReferenceNo=Convert(varchar(200),tmp.ReferenceNo)
                                )";
            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(queryString);
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


        public DataTable CCS_GetTemp_MoneyTransaction_ForEmail_ForGrid()
        {
            DataTable dt = new DataTable();
            string queryString = @"Select 
                                [IsSelected] AS IsSelected
                                ,[ID]
                                ,tmp.[Cust_Code]
                                ,[Payment_Media]
                                ,[Payment_Media_No]
                                ,[Amount]
                                ,[Deposit_Withdraw]
                                ,[Entry_Branch_Id]
                                ,[Money_Balance]
                                ,[ReferenceNo]
                                ,[Destination_No]
                                ,Convert(varchar(10),GETDATE(),105) AS Date
                                From [SBP_SyncSmsServer_MoneyTransactionTemp] as tmp
                                WHERE NOT EXISTS (
					                        Select *
					                        From [SBP_Email_Notification] as t
					                        Where t.DeliveryStatus=1 
					                        AND t.CustCode=tmp.Cust_Code 
					                        AND t.DeliveryDate=Convert(varchar(10),GETDATE(),102)
					                        AND t.MailType= (
									                        CASE 
											                        WHEN tmp.[Deposit_Withdraw]='Deposit' THEN '" + Indication_EmailNotification.Email_NotificationType_MoneyDeposit + @"'
											                        WHEN tmp.[Deposit_Withdraw]='Withdraw' AND tmp.[Payment_Media]<>'EFT' THEN '" + Indication_EmailNotification.Email_NotificationType_MoneyWithdraw + @"'
											                        WHEN tmp.[Deposit_Withdraw]='Withdraw' AND tmp.[Payment_Media]='EFT' THEN '" + Indication_EmailNotification.Email_NotificationType_EftWithdraw + @"'
											                        ELSE ''
									                        END
									                        )
                                            AND t.ReferenceNo=tmp.ReferenceNo
			                   )";
            try
            {
                _dbConnection.ConnectDatabase();
                dt=_dbConnection.ExecuteQuery(queryString);
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

        
        public DataTable CCS_GetTemp_EmailTradeConfirmation_ForGrid()
        {
            DataTable dt = new DataTable();
            string queryString = @"SELECT 
                                  Convert(bit,MIN(ISNULL(Convert(int,IsSelected),0))) AS IsSelected
                                  ,tmp.[Cust_Code]
                                  ,[Cust_Name]
                                  ,[Trade_Date]
                                  ,[Interest]
                                  ,[Pre_Balance]
                                  ,SUM(Buy_Total) AS TotalOnBuyTotal
                                  ,SUM(Sell_Total) AS TotalOnSellTotal
                                  ,SUM(Balance) AS TotalOnBalance
                                  ,SUM(Balance)+SUM(Commission) AS TotalPayable
                                  ,Convert(varchar(10),GETDATE(),105) AS Date
                            FROM [SBP_Database].[dbo].[SBP_EmailNotification_TradeConfirmation_Temp] as tmp
                            WHERE NOT EXISTS(
			                            Select *
			                            From [SBP_Database].[dbo].[SBP_Email_Notification] AS t
			                            Where t.[MailType] IN ('"+Indication_EmailNotification.Email_NotificationType_TradeConfirmation+@"') AND t.CustCode=tmp.Cust_Code
			                            AND t.DeliveryDate=Convert(Varchar(10),GETDATE(),102) AND t.DeliveryStatus=1
                            )
                            GROUP BY [Cust_Code],[Cust_Name],[Trade_Date],[Interest],[Pre_Balance]
                            ";
            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(queryString);
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
        
        public DataTable CCS_GetTemp_EmailTradeConfirmation_Master()
        {
            DataTable dt = new DataTable();
            string queryString = @"SELECT Cust_Code,SUM(Balance) AS Balance
                                INTO #Balance
                                FROM SBP_Money_Balance_Temp  
                                Where Cust_Code IN (
						                                Select Cust_Code
						                                From [SBP_EmailNotification_TradeConfirmation_Temp]
						                                Group BY Cust_Code
                                )
                                GROUP BY Cust_Code

                                SELECT 
                                  [Cust_Code]
                                  ,[Cust_Name]
                                  ,[Trade_Date]
                                  ,ISNULL([Interest],0) AS Interest
                                  ,ISNULL([Pre_Balance],0) AS Pre_Balance
                                  ,SUM(ISNULL(Buy_Total,0)) AS TotalOnBuyTotal
                                  ,SUM(ISNULL(Sell_Total,0)) AS TotalOnSellTotal
                                  ,SUM(ISNULL(Balance,0)) AS TotalOnBalance
                                  ,SUM(ISNULL(Amount,0)) AS TotalOnAmount
                                  ,SUM(ISNULL(Commission,0)) AS TotalOnCommission
                                  ,(
                                    CASE     
                                        WHEN SUM(ISNULL(Amount,0))<0 THEN (-1)* ( ( (-1)*SUM(ISNULL(Amount,0)) )+( SUM(ISNULL(Commission,0)) ) )
                                        WHEN SUM(ISNULL(Amount,0))>0 THEN SUM(ISNULL(Amount,0))+SUM(ISNULL(Commission,0))
                                    END
                                   ) AS TotalPayable
                                  ,(
                                        Select t.Balance 
                                        From #Balance as t 
                                        Where t.Cust_Code=tmp.Cust_Code
                                  )AS [CurrentBalance]
                                  ,(
                                        Select c.Email From [SBP_Service_Registration] as c Where c.Cust_Code=tmp.Cust_Code
                                  )  AS Email
                                FROM [SBP_Database].[dbo].[SBP_EmailNotification_TradeConfirmation_Temp] as tmp
                                WHERE IsSelected=1 
                                AND NOT EXISTS(
                                        Select *
                                        From [SBP_Database].[dbo].[SBP_Email_Notification] AS t
                                        Where t.[MailType] IN ('"+Indication_EmailNotification.Email_NotificationType_TradeConfirmation+@"') AND t.CustCode=tmp.Cust_Code
                                        AND t.DeliveryDate=Convert(Varchar(10),GETDATE(),102) AND t.DeliveryStatus=1
                                )
                                GROUP BY [Cust_Code],[Cust_Name],[Trade_Date],[Interest],[Pre_Balance]";
            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(queryString);
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

        public DataTable CCS_GetTemp_EmailTradeConfirmation_Detials(string Cust_Code)
        {
            DataTable dt = new DataTable();
            string queryString = @"SELECT 
                                  [Comp_Short_Code]
                                  ,[Buy_Qty]
                                  ,[Buy_Avg]
                                  ,[Buy_Total]
                                  ,[Sell_Qty]
                                  ,[Sell_Avg]
                                  ,[Sell_Total]
                                  ,[Balance]
                                  ,[Amount]
                                  ,[Commission]                                 
                              FROM [SBP_Database].[dbo].[SBP_EmailNotification_TradeConfirmation_Temp]
                              WHERE [Cust_Code]=" + Cust_Code + "";
            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(queryString);
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

        public void CCS_Update_EmailTradeConfirmation(string Cust_Code, bool Selected)
        {
            string queryString = @"UPDATE [SBP_EmailNotification_TradeConfirmation_Temp]
                                    SET IsSelected="+Convert.ToInt32(Selected)+@"
                                    WHERE Cust_Code='" + Cust_Code + "'";
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

        public DataTable CCS_GetTemp_MoneyTransactionForEmail_ForSending()
        {
            DataTable dt = new DataTable();
            string queryString = @"                                   
			                        SELECT [ID]
			                        ,tmp.[Cust_Code]
			                        ,[Payment_Media]
			                        ,[Payment_Media_No]
			                        ,[Amount]
			                        ,[Deposit_Withdraw]
			                        ,[Entry_Branch_Id]
			                        ,(
				                        Select t.Branch_Name
				                        From SBP_Broker_Branch as t
				                        Where t.Branch_ID=tmp.[Entry_Branch_Id]
			                        )AS Branch_Name
			                        ,[Money_Balance]
			                        ,[ReferenceNo]
			                        ,[Destination_No]
			                        ,[IsSelected]
			                        ,[VoucherNo]
			                        ,[ChequekBank]
			                        ,[ChequeBranch]
			                        ,reg.Email AS Email --reg.Email
                                    ,ISNULL((
	                                    SELECT t.Trans_Reason
                                        FROM [SBP_Payment] as t
                                        WHERE t.Payment_Media='TR' AND t.[Payment_ID]=tmp.[ReferenceNo]
                                    ),'') AS TransReason
                                     ,ISNULL((
                                        SELECT (
                                                    Select d.Branch_Name
                                                    From SBP_Broker_Branch as d
                                                    Where d.Branch_ID=t.Collection_Branch_ID
                                        )
                                        FROM dbo.SBP_Check_Requisition AS t
                                        WHERE t.Sl_No=(
															Select b.Requisition_ID
															From SBP_Payment as b
															Where b.Payment_ID=tmp.ReferenceNo 
										)													 
                                        AND tmp.Payment_Media='Check'  
                                        AND tmp.Deposit_Withdraw='Withdraw')
                                    ,'') AS CollectionBranch        
            
			                        FROM [SBP_Database].[dbo].[SBP_SyncSmsServer_MoneyTransactionTemp] as tmp
			                        JOIN
			                        SBP_Service_Registration as reg
			                        ON
			                        reg.[Cust_Code]=tmp.Cust_Code
			                        AND
			                        reg.MoneyDeposit_Confirmation_Email=1
			                        AND
			                        tmp.[Deposit_Withdraw]='Deposit'
			                        AND 
			                        tmp.IsSelected=1
			                        AND
			                        NOT EXISTS (
					                        Select *
					                        From [SBP_Email_Notification] as t
					                        Where t.DeliveryStatus=1 
					                        AND t.CustCode=tmp.Cust_Code 
					                        AND t.DeliveryDate=Convert(varchar(10),GETDATE(),102)
					                         AND t.MailType= (
									                        CASE 
											                        WHEN tmp.[Deposit_Withdraw]='Deposit' THEN '" + Indication_EmailNotification.Email_NotificationType_MoneyDeposit + @"'
											                        WHEN tmp.[Deposit_Withdraw]='Withdraw' AND tmp.[Payment_Media]<>'EFT' THEN '" + Indication_EmailNotification.Email_NotificationType_MoneyWithdraw + @"'
											                        WHEN tmp.[Deposit_Withdraw]='Withdraw' AND tmp.[Payment_Media]='EFT' THEN '" + Indication_EmailNotification.Email_NotificationType_EftWithdraw + @"'
											                        ELSE ''
									                        END
									                        )
                                            AND t.ReferenceNo=tmp.ReferenceNo
			                        )


			                        UNION ALL

			                        SELECT [ID]
			                        ,tmp.[Cust_Code]
			                        ,[Payment_Media]
			                        ,[Payment_Media_No]
			                        ,[Amount]
			                        ,[Deposit_Withdraw]
			                        ,[Entry_Branch_Id]
			                        ,(
				                        Select t.Branch_Name
				                        From SBP_Broker_Branch as t
				                        Where t.Branch_ID=tmp.[Entry_Branch_Id]
			                        )AS Branch_Name
			                        ,[Money_Balance]
			                        ,[ReferenceNo]
			                        ,[Destination_No]
			                        ,[IsSelected]
			                        ,[VoucherNo]
			                        ,[ChequekBank]
			                        ,[ChequeBranch]
			                        ,reg.Email AS Email --reg.Email
                                    ,ISNULL((
	                                    SELECT t.Trans_Reason
                                        FROM [SBP_Payment] as t
                                        WHERE t.Payment_Media='TR' AND t.[Payment_ID]=tmp.[ReferenceNo]
                                    ),'') AS TransReason
                                    ,ISNULL((
                                        SELECT (
                                                    Select d.Branch_Name
                                                    From SBP_Broker_Branch as d
                                                    Where d.Branch_ID=t.Collection_Branch_ID
                                        )
                                        FROM dbo.SBP_Check_Requisition AS t
                                        WHERE t.Sl_No=(
															Select b.Requisition_ID
															From SBP_Payment as b
															Where b.Payment_ID=tmp.ReferenceNo 
										)													 
                                        AND tmp.Payment_Media='Check'  
                                        AND tmp.Deposit_Withdraw='Withdraw')
                                    ,'') AS CollectionBranch       
			                        FROM [SBP_Database].[dbo].[SBP_SyncSmsServer_MoneyTransactionTemp] as tmp
			                        JOIN
			                        SBP_Service_Registration as reg
			                        ON
			                        reg.[Cust_Code]=tmp.Cust_Code
			                        AND
			                        reg.MoneyWithdraw_Confirmation_Email=1
			                        AND
			                        tmp.[Deposit_Withdraw]='Withdraw'
			                        AND 
			                        tmp.[Payment_Media]<>'EFT'
			                        AND 
			                        tmp.IsSelected=1
			                        AND
			                        NOT EXISTS (
					                        Select *
					                        From [SBP_Email_Notification] as t
					                        Where t.DeliveryStatus=1 
					                        AND t.CustCode=tmp.Cust_Code 
					                        AND t.DeliveryDate=Convert(varchar(10),GETDATE(),102)
					                         AND t.MailType= (
									                        CASE 
											                        WHEN tmp.[Deposit_Withdraw]='Deposit' THEN '" + Indication_EmailNotification.Email_NotificationType_MoneyDeposit + @"'
											                        WHEN tmp.[Deposit_Withdraw]='Withdraw' AND tmp.[Payment_Media]<>'EFT' THEN '" + Indication_EmailNotification.Email_NotificationType_MoneyWithdraw + @"'
											                        WHEN tmp.[Deposit_Withdraw]='Withdraw' AND tmp.[Payment_Media]='EFT' THEN '" + Indication_EmailNotification.Email_NotificationType_EftWithdraw + @"'
											                        ELSE ''
									                        END
									                        )
                                            AND t.ReferenceNo=tmp.ReferenceNo
			                        )

			                        UNION ALL


			                        SELECT [ID]
			                          ,tmp.[Cust_Code]
			                          ,[Payment_Media]
			                          ,[Payment_Media_No]
			                          ,[Amount]
			                          ,[Deposit_Withdraw]
			                          ,[Entry_Branch_Id]
			                          ,(
					                        Select t.Branch_Name
					                        From SBP_Broker_Branch as t
					                        Where t.Branch_ID=tmp.[Entry_Branch_Id]
			                          )AS Branch_Name
			                          ,[Money_Balance]
			                          ,[ReferenceNo]
			                          ,[Destination_No]
			                          ,[IsSelected]
			                          ,[VoucherNo]
			                          ,[ChequekBank]
			                          ,[ChequeBranch]
			                          ,reg.Email AS Email --reg.Email
                                    ,ISNULL((
                                        SELECT t.Trans_Reason
                                        FROM [SBP_Payment] as t
                                        WHERE t.Payment_Media='TR' AND t.[Payment_ID]=tmp.[ReferenceNo]
                                    ),'') AS TransReason
                                    ,ISNULL((
                                        SELECT (
                                                    Select d.Branch_Name
                                                    From SBP_Broker_Branch as d
                                                    Where d.Branch_ID=t.Collection_Branch_ID
                                        )
                                        FROM dbo.SBP_Check_Requisition AS t
                                        WHERE t.Sl_No=(
															Select b.Requisition_ID
															From SBP_Payment as b
															Where b.Payment_ID=tmp.ReferenceNo 
										)													 
                                        AND tmp.Payment_Media='Check'  
                                        AND tmp.Deposit_Withdraw='Withdraw')
                                    ,'') AS CollectionBranch        
			                        FROM [SBP_Database].[dbo].[SBP_SyncSmsServer_MoneyTransactionTemp] as tmp
			                        JOIN
			                        SBP_Service_Registration as reg
			                        ON
			                        reg.[Cust_Code]=tmp.Cust_Code
			                        AND
			                        reg.MoneyWithdraw_Confirmation_Email=1
			                        AND
			                        tmp.[Deposit_Withdraw]='Withdraw'
			                        AND 
			                        tmp.[Payment_Media]='EFT'
			                        AND 
			                        tmp.IsSelected=1
			                        AND
			                        NOT EXISTS (
					                        Select *
					                        From [SBP_Email_Notification] as t
					                        Where t.DeliveryStatus=1 
					                        AND t.CustCode=tmp.Cust_Code 
					                        AND t.DeliveryDate=Convert(varchar(10),GETDATE(),102)
					                         AND t.MailType= (
									                        CASE 
											                        WHEN tmp.[Deposit_Withdraw]='Deposit' THEN '" + Indication_EmailNotification.Email_NotificationType_MoneyDeposit + @"'
											                        WHEN tmp.[Deposit_Withdraw]='Withdraw' AND tmp.[Payment_Media]<>'EFT' THEN '" + Indication_EmailNotification.Email_NotificationType_MoneyWithdraw + @"'
											                        WHEN tmp.[Deposit_Withdraw]='Withdraw' AND tmp.[Payment_Media]='EFT' THEN '" + Indication_EmailNotification.Email_NotificationType_EftWithdraw + @"'
											                        ELSE ''
									                        END
									                        )
                                            AND t.ReferenceNo=tmp.ReferenceNo		                        
                                   )
                                ";
            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(queryString);
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

        public void CCS_DeleteFromTemp_MoneyTransaction(int id)
        {
            string queryString = @"DELETE SBP_SyncSmsServer_MoneyTransactionTemp WHERE ID=" + id + "";
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
        
        public void CCS_Email_NotificationSent(string Cust_Code,int ReferenceNo,string MailType,string MailContent,string DeliveryDate)
        {
            string queryString = @"INSERT INTO [SBP_Database].[dbo].[SBP_Email_Notification]
                                   ([CustCode]
                                   ,[MailType]
                                   ,[MailContent]
                                   ,[DeliveryDate]
                                   ,[DeliveryStatus]
                                   ,[FailureReason]
                                   ,[ReferenceNo]
                                    )
                                   VALUES ('" + Cust_Code + @"'
                                   ,'" + MailType + @"'
                                   ,'" + MailContent + @"'
                                   ,'" + DeliveryDate + @"'
                                   ," + 1 + @"
                                   ,'" + string.Empty + @"'
                                   ,"+ReferenceNo+@" );"; 
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
        public void CCS_Email_NotificationSent(string Cust_Code,string MailType, string MailContent, string DeliveryDate)
        {
            string queryString = @"INSERT INTO [SBP_Database].[dbo].[SBP_Email_Notification]
                                   ([CustCode]
                                   ,[MailType]
                                   ,[MailContent]
                                   ,[DeliveryDate]
                                   ,[DeliveryStatus]
                                   ,[FailureReason]
                                   ,[ReferenceNo] )
                                   VALUES ('" + Cust_Code + @"'
                                   ,'" + MailType + @"'
                                   ,'" + MailContent + @"'
                                   ,'" + DeliveryDate + @"'
                                   ," + 1 + @"
                                   ,'" + string.Empty + @"'
                                   ,"+0+@");";
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
        public void CCS_Email_NotificationFailure(string Cust_Code,int ReferenceNo, string MailType, string MailContent, string DeliveryDate, string FailureReason)
        {
            string queryString = @" DECLARE @TranName VARCHAR(20);
                                    SET @TranName = 'MyTransaction';
                                    BEGIN TRANSACTION  @TranName;                               
    
                                    DELETE [SBP_Database].[dbo].[SBP_Email_Notification]
                                    WHERE [CustCode]='" + Cust_Code + @"' AND  DeliveryDate=Convert(varchar(10),GETDATE(),102) AND [MailType]='" + MailType + @"' AND ReferenceNo=" + ReferenceNo + @"  

                                    INSERT INTO [SBP_Database].[dbo].[SBP_Email_Notification]
                                   ([CustCode]
                                   ,[MailType]
                                   ,[MailContent]
                                   ,[DeliveryDate]
                                   ,[DeliveryStatus]
                                   ,[FailureReason]
                                   ,[ReferenceNo] )
                                   VALUES ('" + Cust_Code + @"'
                                   ,'" + MailType + @"'
                                   ,'" + MailContent + @"'
                                   ,'" + DeliveryDate + @"'
                                   ," + 0 + @"
                                   ,'" + FailureReason + @"'
                                   ,"+ReferenceNo+@");

                                   COMMIT TRANSACTION @TranName; ";
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
        public void CCS_Email_NotificationFailure(string Cust_Code, string MailType, string MailContent, string DeliveryDate,string FailureReason)
        {
            string queryString = @" DECLARE @TranName VARCHAR(20);
                                    SET @TranName = 'MyTransaction';
                                    BEGIN TRANSACTION  @TranName;                               
    
                                    DELETE [SBP_Database].[dbo].[SBP_Email_Notification]
                                    WHERE [CustCode]='" + Cust_Code+@"' AND  DeliveryDate=Convert(varchar(10),GETDATE(),102) AND [MailType]='"+MailType+ @"'  

                                    INSERT INTO [SBP_Database].[dbo].[SBP_Email_Notification]
                                   ([CustCode]
                                   ,[MailType]
                                   ,[MailContent]
                                   ,[DeliveryDate]
                                   ,[DeliveryStatus]
                                   ,[FailureReason]
                                   ,[ReferenceNo] )
                                   VALUES ('" + Cust_Code + @"'
                                   ,'" + MailType + @"'
                                   ,'" + string.Empty+ @"'
                                   ,'" + DeliveryDate + @"'
                                   ," + 0 + @"
                                   ,'" + FailureReason + @"'
                                   ,"+0+@" );

                                   COMMIT TRANSACTION @TranName; ";
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


        public void CCS_UpdatedSelection_MoneyTransactionTemp(int id,bool Selected)
        {
            string queryString = @"UPDATE SBP_SyncSmsServer_MoneyTransactionTemp  SET IsSelected="+Convert.ToInt32(Selected)+" WHERE ID=" + id + "";
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

    }
}
