﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Odbc;
using System.Data.OleDb;
using DataAccessLayer;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace BusinessAccessLayer.BAL
{
    public class Web2014DataForwardBAL
    {
        private DbConnection _dbConnection;

        string mySqlConnection = //"DRIVER={MySQL ODBC 3.51 Driver};" +
            @"Server=prelude.websitewelcome.com;" +
            "Port=3306;" +
            "Database=ksclbdco_ks;" +
            "Uid=ksclbdco;" +
            "Pwd=16Dec08;";


        //string mySqlConnection = //"DRIVER={MySQL ODBC 3.51 Driver};" +
        //    "DRIVER={MySQL ODBC 5.1 Driver};" +
        //    "SERVER=prelude.websitewelcome.com;" +
        //    "PORT=3306;"+
        //    "DATABASE=ksclbdco_ks;" +
        //    "UID=ksclbdco;" +
        //    "PASSWORD=16Dec08;" +
        //    "OPTION=3";




        public Web2014DataForwardBAL()
        {
            _dbConnection = new DbConnection();
        }

        // Load Data From Temp

        public DataTable GetData_Web2014_GetNewUserQuery_Temp()
        {
            DataTable dt = new DataTable();

            string query;
            query = "";

            query = @"SELECT [Contact_Us_Id]
                      ,[From_Email_Address]
                      ,[Contact_To]
                      ,[Contact_Subject]
                      ,[Contact_Message]
                      ,[Contact_Date]
                      ,[Contact_Status]
                      ,[Entry_Date]
	                  FROM [SBP_Database].[dbo].[Web2014_GetNewUserQuery_Temp]
	                  ORDER BY [Contact_Us_Id]";

            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(query);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }

            return dt;
        }

        public DataTable GetData_Web2014_GetNewWithdrawalRequest_Temp_PaymentPosting()
        {
            DataTable dt = new DataTable();

            string query;
            query = "";

//            query = @"SELECT [Request_Id]
//                      ,[Customer_Id]
//                      ,[Request_Date]
//                      ,[Request_Type]
//                      ,[Cheque_Collection_Branch]
//                      ,[Delivery_Date]
//                      ,[Amount]
//                      ,[Status]
//                      ,[Remarks]
//                      ,[Entry_Date]
//                FROM [SBP_Database].[dbo].[Web2014_GetNewWithdrawalRequest_Temp]
//                WHERE [Request_Type]='Direct Account'
//                ORDER BY [Request_Id]";

            query = @"SELECT [Request_Id]
                              ,[Customer_Id]
                              ,[Request_Date]
                              ,[Request_Type]
                              ,[Cheque_Collection_Branch]
                              ,[Delivery_Date]
                              ,[Amount]
                              ,[Status]
                              ,'' AS 'Money_TransactionType_Name'
                              ,'' AS 'Money_TransactionType_Name_ID'
                              ,[Remarks]
                              ,[Entry_Date]
                              ,'' AS 'Media_Type'
                              ,'' AS Deposit_Withdraw
                              ,'' AS Cheque_Number
                        FROM [SBP_Database].[dbo].[Web2014_GetNewWithdrawalRequest_Temp]
                        WHERE [Request_Type]='Direct Account'
                        UNION ALL
                          Select SMSReqID AS 'Request_Id'
                                 ,Cust_Code AS 'Customer_Id'
                                 ,Received_Date AS 'Request_Date'
                                 ,'' AS 'Request_Type'
                                 ,'Head Office' AS 'Cheque_Collection_Branch'
                                 ,'' AS 'Delivery_Date'
                                 ,Amount AS 'Amount'
                                 ,'Pending' AS 'Status'
                                 ,Money_TransactionType_Name
                                 ,Money_TransactionType_Name_ID
                                 ,Remarks
                                 ,Received_Date AS 'Entry_Date'
                                 ,Media_Type
                                 ,Deposit_Withdraw
                                 ,Cheque_Number
                           from dbo.SMS_Sync_Import_IPORequest
                           Where Payment_Media='Trade' 
                           AND Deposit_Withdraw='Deposit'
                           AND Money_TransactionType_Name_ID=1
                           AND Money_TransactionType_Name='Cash'
                          -- AND Money_TransactionType_Name_ID=2
                           --AND Money_TransactionType_Name='Cheque'
                           AND SMSReqID NOT IN (
                           Select OnlineOrderNo FROM [SBP_Database].[dbo].[SBP_Payment_Posting_Request]
                           Where Payment_Media='Cash' AND Deposit_Withdraw='Deposit'
                          and Channel='SMS')
                          AND SMSReqID NOT IN (
                           Select OnlineOrderNo FROM [SBP_Database].[dbo].[SBP_Payment_Posting_Request]
                           Where Payment_Media='Cash' AND Deposit_Withdraw='Deposit'
                          and Channel='Email')
                       UNION ALL
                          Select SMSReqID AS 'Request_Id'
                                 ,Cust_Code AS 'Customer_Id'
                                 ,Received_Date AS 'Request_Date'
                                 ,'' AS 'Request_Type'
                                 ,'Head Office' AS 'Cheque_Collection_Branch'
                                 ,'' AS 'Delivery_Date'
                                 ,Amount AS 'Amount'
                                 ,'Pending' AS 'Status'
                                 ,Money_TransactionType_Name
                                 ,Money_TransactionType_Name_ID
                                 ,Remarks
                                 ,Received_Date AS 'Entry_Date'
                                 ,Media_Type
                                 ,Deposit_Withdraw
                                 ,Cheque_Number
                           from dbo.SMS_Sync_Import_IPORequest
                           Where Payment_Media='Trade' 
                           AND Deposit_Withdraw='Deposit'
                           AND Money_TransactionType_Name_ID=3
                           AND Money_TransactionType_Name='EFT'
                          -- AND Money_TransactionType_Name_ID=2
                           --AND Money_TransactionType_Name='Cheque'
                           AND SMSReqID NOT IN (
                           Select OnlineOrderNo FROM [SBP_Database].[dbo].[SBP_Payment_Posting_Request]
                           Where Payment_Media='EFT' AND Deposit_Withdraw='Deposit'
                           and Channel='SMS')
                           AND SMSReqID NOT IN (
                           Select OnlineOrderNo FROM [SBP_Database].[dbo].[SBP_Payment_Posting_Request]
                           Where Payment_Media='EFT' AND Deposit_Withdraw='Deposit'
                           and Channel='Email')
                        UNION ALL
                          Select SMSReqID AS 'Request_Id'
                                 ,Cust_Code AS 'Customer_Id'
                                 ,Received_Date AS 'Request_Date'
                                 ,'' AS 'Request_Type'
                                 ,'Head Office' AS 'Cheque_Collection_Branch'
                                 ,'' AS 'Delivery_Date'
                                 ,Amount AS 'Amount'
                                 ,'Pending' AS 'Status'
                                 ,Money_TransactionType_Name
                                 ,Money_TransactionType_Name_ID
                                 ,Remarks
                                 ,Received_Date AS 'Entry_Date'
                                 ,Media_Type
                                 ,Deposit_Withdraw
                                 ,Cheque_Number
                           from dbo.SMS_Sync_Import_IPORequest
                           Where Payment_Media='Trade' 
                           AND Deposit_Withdraw='Deposit'
                           --AND Money_TransactionType_Name_ID=1
                          -- AND Money_TransactionType_Name='Cash'
                           AND Money_TransactionType_Name_ID=2
                           AND Money_TransactionType_Name='Cheque'
                           AND SMSReqID NOT IN (
                           Select OnlineOrderNo FROM [SBP_Database].[dbo].[SBP_Payment_Posting_Request]
                           Where Payment_Media='Cheque' AND Deposit_Withdraw='Deposit'
                           and Channel='SMS')
                           AND SMSReqID NOT IN (
                           Select OnlineOrderNo FROM [SBP_Database].[dbo].[SBP_Payment_Posting_Request]
                           Where Payment_Media='Cheque' AND Deposit_Withdraw='Deposit'
                           and Channel='Email')";


            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(query);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }

            return dt;
        }

        public DataTable GetData_Withdraw_PaymentPosting()
        {
            DataTable dt = new DataTable();

            string query;
            query = "";

            //            query = @"SELECT [Request_Id]
            //                      ,[Customer_Id]
            //                      ,[Request_Date]
            //                      ,[Request_Type]
            //                      ,[Cheque_Collection_Branch]
            //                      ,[Delivery_Date]
            //                      ,[Amount]
            //                      ,[Status]
            //                      ,[Remarks]
            //                      ,[Entry_Date]
            //                FROM [SBP_Database].[dbo].[Web2014_GetNewWithdrawalRequest_Temp]
            //                WHERE [Request_Type]='Direct Account'
            //                ORDER BY [Request_Id]";

            query = @"SELECT [Request_Id]
                              ,[Customer_Id]
                              ,[Request_Date]
                              ,[Request_Type]
                              ,[Cheque_Collection_Branch]
                              ,[Delivery_Date]
                              ,[Amount]
                              ,[Status]
                              ,'' AS 'Money_TransactionType_Name'
                              ,'' AS 'Money_TransactionType_Name_ID'
                              ,[Remarks]
                              ,[Entry_Date]
                              ,'' AS 'Media_Type'
                              ,'' AS Deposit_Withdraw
                              ,'' AS Cheque_Number
                        FROM [SBP_Database].[dbo].[Web2014_GetNewWithdrawalRequest_Temp]
                        WHERE [Request_Type]='Direct Account'
                        UNION ALL
                          Select SMSReqID AS 'Request_Id'
                                 ,Cust_Code AS 'Customer_Id'
                                 ,Received_Date AS 'Request_Date'
                                 ,'' AS 'Request_Type'
                                 ,'Head Office' AS 'Cheque_Collection_Branch'
                                 ,'' AS 'Delivery_Date'
                                 ,Amount AS 'Amount'
                                 ,'Pending' AS 'Status'
                                 ,Money_TransactionType_Name
                                 ,Money_TransactionType_Name_ID
                                 ,Remarks
                                 ,Received_Date AS 'Entry_Date'
                                 ,Media_Type
                                 ,Deposit_Withdraw
                                 ,Cheque_Number
                           from dbo.SMS_Sync_Import_IPORequest
                           Where Payment_Media='Trade' 
                           AND Deposit_Withdraw='Withdraw'
                           AND Money_TransactionType_Name_ID in (1,3)
                           AND Money_TransactionType_Name in('Cash','EFT')
                           AND SMSReqID NOT IN (
                           Select OnlineOrderNo FROM [SBP_Database].[dbo].[SBP_Payment_Posting_Request]
                           Where Payment_Media in('Cash','EFT') AND Deposit_Withdraw='Withdraw'
                           and Channel='SMS' OR Channel='Email')";

            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(query);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }

            return dt;
        }

        public DataTable GetData_EFT_PaymentPosting()
        {
            DataTable dt = new DataTable();

            string query;
            query = "";

            //            query = @"SELECT [Request_Id]
            //                      ,[Customer_Id]
            //                      ,[Request_Date]
            //                      ,[Request_Type]
            //                      ,[Cheque_Collection_Branch]
            //                      ,[Delivery_Date]
            //                      ,[Amount]
            //                      ,[Status]
            //                      ,[Remarks]
            //                      ,[Entry_Date]
            //                FROM [SBP_Database].[dbo].[Web2014_GetNewWithdrawalRequest_Temp]
            //                WHERE [Request_Type]='Direct Account'
            //                ORDER BY [Request_Id]";

            query = @"SELECT [Request_Id]
                              ,[Customer_Id]
                              ,[Request_Date]
                              ,[Request_Type]
                              ,[Cheque_Collection_Branch]
                              ,[Delivery_Date]
                              ,[Amount]
                              ,[Status]
                              ,'EFT' AS 'Money_TransactionType_Name'
                              ,'3' AS 'Money_TransactionType_Name_ID'
                              ,[Remarks]
                              ,[Entry_Date]
                              ,'Web' AS 'Media_Type'
                              ,'Withdraw' AS Deposit_Withdraw
                             ,'' AS Cheque_Number
                        FROM [SBP_Database].[dbo].[Web2014_GetNewWithdrawalRequest_Temp]
                        WHERE [Request_Type]='Direct Account'
                        UNION ALL
                          Select SMSReqID AS 'Request_Id'
                                 ,Cust_Code AS 'Customer_Id'
                                 ,Received_Date AS 'Request_Date'
                                 ,'' AS 'Request_Type'
                                 ,'Head Office' AS 'Cheque_Collection_Branch'
                                 ,'' AS 'Delivery_Date'
                                 ,Amount AS 'Amount'
                                 ,'Pending' AS 'Status'
                                 ,Money_TransactionType_Name
                                 ,Money_TransactionType_Name_ID
                                 ,Remarks
                                 ,Received_Date AS 'Entry_Date'
                                 ,Media_Type
                                 ,Deposit_Withdraw
                                 ,Cheque_Number
                           from dbo.SMS_Sync_Import_IPORequest
                           Where Payment_Media='Trade' 
                           AND Deposit_Withdraw='Withdraw'
                           AND Money_TransactionType_Name_ID=3
                           AND Money_TransactionType_Name='EFT'
                           AND SMSReqID NOT IN (
                           Select OnlineOrderNo FROM [SBP_Database].[dbo].[SBP_Payment_Posting_Request]
                           Where Payment_Media='EFT' 
                           and Channel='SMS')
                           AND SMSReqID NOT IN (
                           Select OnlineOrderNo FROM [SBP_Database].[dbo].[SBP_Payment_Posting_Request]
                           Where Payment_Media='EFT' 
                           and Channel='Email')";

            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(query);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }

            return dt;
        }

        public DataTable GetData_Web2014_GetNewWithdrawalRequest_Temp_CheckRequisition()
        {
            DataTable dt = new DataTable();

            string query;
            query = "";

//            query = @"SELECT [Request_Id]
//                      ,[Customer_Id]
//                      ,[Request_Date]
//                      ,[Request_Type]
//                      ,[Cheque_Collection_Branch]
//                      ,[Delivery_Date]
//                      ,[Amount]
//                      ,[Status]
//                      ,[Remarks]
//                      ,[Entry_Date]
//                FROM [SBP_Database].[dbo].[Web2014_GetNewWithdrawalRequest_Temp]
//                WHERE [Request_Type]='Cheque Requisition'
//                ORDER BY [Request_Id]";


            query = @"SELECT [Request_Id]
                              ,[Customer_Id]
                              ,[Request_Date]
                              ,[Request_Type]
                              ,[Cheque_Collection_Branch]
                              ,[Delivery_Date]
                              ,[Amount]
                              ,[Status]
                              ,'' AS 'Money_TransactionType_Name'
                              ,'' AS 'Money_TransactionType_Name_ID'
                              ,[Remarks]
                              ,[Entry_Date]
                              ,'' AS 'Media_Type'
                              ,'' AS Deposit_Withdraw
                               ,'' AS Cheque_Number
                        FROM [SBP_Database].[dbo].[Web2014_GetNewWithdrawalRequest_Temp]
                        WHERE [Request_Type]='Cheque Requisition'
                        UNION ALL
                          Select SMSReqID AS 'Request_Id'
                                 ,Cust_Code AS 'Customer_Id'
                                 ,Received_Date AS 'Request_Date'
                                 ,'' AS 'Request_Type'
                                 ,'Head Office' AS 'Cheque_Collection_Branch'
                                 ,'' AS 'Delivery_Date'
                                 ,Amount AS 'Amount'
                                 ,'Pending' AS 'Status'
                                 ,Money_TransactionType_Name
                                 ,Money_TransactionType_Name_ID
                                 ,Remarks
                                 ,Received_Date AS 'Entry_Date'
                                 ,Media_Type
                                 ,Deposit_Withdraw
                                 ,Cheque_Number
                           from dbo.SMS_Sync_Import_IPORequest
                           Where Payment_Media='Trade' 
                           AND Deposit_Withdraw='Withdraw'
                           AND Money_TransactionType_Name_ID=2
                           AND Money_TransactionType_Name='Cheque'
                           AND SMSReqID NOT IN (
                           Select OnlineOrderNo FROM [SBP_Database].[dbo].[SBP_Check_Requisition]
                           Where OnlineOrderNo !='' 
                           and Channel='SMS')
                           AND SMSReqID NOT IN (
                           Select OnlineOrderNo FROM [SBP_Database].[dbo].[SBP_Check_Requisition]
                           Where OnlineOrderNo !='' 
                           and Channel='Email')";

            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(query);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }

            return dt;
        }

        public DataTable GetData_Web2014_GetAllServiceRegistration_Temp()
        {
            DataTable dt = new DataTable();

            string query;
            query = "";

//            query = @"SELECT T.*
//                    FROM 
//                    (
//                        Select web.Cust_Code
//                        ,Convert(int,web.[Web_Service]) AS [Web_Service]
//                        ,Convert(int,web.[SMS_Confirmation]) AS [SMS_Confirmation]
//                        ,Convert(int,web.[SMS_Trade]) AS [SMS_Trade]
//                        ,ISNULL(Convert(int,web.[SMS_MoneyDeposit_Confirmation]),0) AS [SMS_MoneyDeposit_Confirmation]
//                        ,ISNULL(Convert(int,web.[SMS_MoneyWithdraw_Confirmation]),0) AS [SMS_MoneyWithdraw_Confirmation]
//                        ,ISNULL(Convert(int,web.[SMS_EFTWithdraw_Confirmation]),0) AS [SMS_EFTWithdraw_Confirmation]
//                        ,web.Email AS [Email]
//                        ,web.Cell_No AS [Mobile No]
//                        ,
//                        (
//                        CASE 
//                                WHEN Convert(int,web.[Web_Service])<>Convert(int,reg.Web_Service) THEN 'Web Service'
//                                WHEN Convert(int,web.[SMS_Confirmation])<>Convert(int,reg.[SMS_Confirmation]) THEN 'SMS Confirmation'
//                                WHEN Convert(int,web.[SMS_Trade])<>Convert(int,reg.[SMS_Trade]) THEN 'SMS Trade'
//                                WHEN Convert(int,web.[SMS_MoneyDeposit_Confirmation])<>Convert(int,ISNULL(reg.[SMS_MoneyDeposit_Confirmation],0)) THEN 'Money Deposit'
//                                WHEN Convert(int,web.[SMS_MoneyWithdraw_Confirmation])<>Convert(int,ISNULL(reg.[SMS_MoneyWithdraw_Confirmation],0)) THEN 'Money Withdraw'
//                                WHEN Convert(int,web.[SMS_EFTWithdraw_Confirmation])<>Convert(int,ISNULL(reg.[SMS_EFTWithdraw_Confirmation],0)) THEN 'EFT Withdraw'
//                                WHEN web.Email<>reg.Email THEN 'Email'
//                                WHEN web.Cell_No<>reg.Mobile_No THEN 'Mobile'
//                        END
//                        ) AS [Comment]
//                        FROM [SBP_Database].[dbo].[Web2014_GetAllServiceRegistration_Temp] as web
//                        JOIN dbo.SBP_Service_Registration as reg
//                        ON 
//                        reg.Cust_Code=web.Cust_Code
//                        WHERE 
//                    	
//                            Convert(int,web.[Web_Service])<>Convert(int,reg.Web_Service)
//                            OR
//                            Convert(int,web.[SMS_Confirmation])<>Convert(int,reg.[SMS_Confirmation])
//                            OR
//                            Convert(int,web.[SMS_Trade])<>Convert(int,reg.[SMS_Trade])
//                            OR
//                            Convert(int,web.[SMS_MoneyDeposit_Confirmation])<>Convert(int,ISNULL(reg.[SMS_MoneyDeposit_Confirmation],0))
//                            OR
//                            Convert(int,web.[SMS_MoneyWithdraw_Confirmation])<>Convert(int,ISNULL(reg.[SMS_MoneyWithdraw_Confirmation],0))
//                            OR
//                            Convert(int,web.[SMS_EFTWithdraw_Confirmation])<>Convert(int,ISNULL(reg.[SMS_EFTWithdraw_Confirmation],0))
//                            OR
//                            web.Email<>reg.Email
//                            OR
//                            web.Cell_No<>reg.Mobile_No
//                    	
//                    	
//                        UNION ALL
//                        
//                        select web.Cust_Code
//                        ,Convert(int,web.[Web_Service]) AS [Web_Service]
//                        ,Convert(int,web.[SMS_Confirmation]) AS [SMS_Confirmation]
//                        ,Convert(int,web.[SMS_Trade]) AS [SMS_Trade]
//                        ,ISNULL(Convert(int,web.[SMS_MoneyDeposit_Confirmation]),0) AS [MoneyDeposit_Confirmation_SMS]
//                        ,ISNULL(Convert(int,web.[SMS_MoneyWithdraw_Confirmation]),0) AS [MoneyWithdraw_Confirmation_SMS]
//                        ,ISNULL(Convert(int,web.[SMS_EFTWithdraw_Confirmation]),0) AS [EFTWithdraw_Confirmation_SMS]
//                        ,web.Email AS Email
//                        ,web.Cell_No AS [Mobile No]
//                        ,
//                        (
//                        CASE 
//                                WHEN reg.Cust_Code Is NULL THEN 'New Registration'		
//                        END
//                        ) AS [Comment]
//                        FROM [SBP_Database].[dbo].[Web2014_GetAllServiceRegistration_Temp] as web
//                        LEFT OUTER JOIN dbo.SBP_Service_Registration as reg
//                        ON 
//                        reg.Cust_Code=web.Cust_Code
//                        WHERE 
//                        reg.Cust_Code is NULL AND web.Cust_Code<>0	 
//                    ) AS T
//                    ORDER BY
//                    CONVERT(INT,T.Cust_Code)";

            query = @"SELECT T.*
            FROM 
            (
                Select web.Cust_Code
                ,web.[Web_Service] AS [Web_Service]
                ,(CASE WHEN Convert(int,ISNULL(web.[Web_Service],0))<>Convert(int,ISNULL(reg.Web_Service,0)) THEN 1 ELSE 0 END ) AS [Web_Service_ChangeIndicator]
            	
	            ,web.[SMS_Confirmation] AS [SMS_Confirmation]
	            ,(CASE WHEN Convert(int,ISNULL(web.[SMS_Confirmation],0))<>Convert(int,ISNULL(reg.[SMS_Confirmation],0)) THEN Convert(bit,1) ELSE Convert(bit,0) END ) AS [SMS_Confirmation_ChangeIndicator]
                
	            ,web.[SMS_Trade] AS [SMS_Trade]
                ,(CASE WHEN Convert(int,ISNULL(web.[SMS_Trade],0))<>Convert(int,ISNULL(reg.[SMS_Trade],0)) THEN Convert(bit,1) ELSE Convert(bit,0) END ) AS [SMS_Trade_ChangeIndicator]
            	
	            ,web.[SMS_MoneyDeposit_Confirmation] AS [SMS_MoneyDeposit_Confirmation]
                ,(CASE WHEN Convert(int,ISNULL(web.[SMS_MoneyDeposit_Confirmation],0))<>Convert(int,ISNULL(reg.[SMS_MoneyDeposit_Confirmation],0)) THEN 1 ELSE 0 END ) AS [SMS_MoneyDeposit_Confirmation_ChangeIndicator]
                
	            ,web.[SMS_MoneyWithdraw_Confirmation] AS [SMS_MoneyWithdraw_Confirmation]
                ,(CASE WHEN Convert(int,ISNULL(web.[SMS_MoneyWithdraw_Confirmation],0))<>Convert(int,ISNULL(reg.[SMS_MoneyWithdraw_Confirmation],0)) THEN 1 ELSE 0 END ) AS [SMS_MoneyWithdraw_Confirmation_ChangeIndicator]
            	
	            ,web.[SMS_EFTWithdraw_Confirmation] AS [SMS_EFTWithdraw_Confirmation]
	            ,(CASE WHEN Convert(int,ISNULL(web.[SMS_EFTWithdraw_Confirmation],0))<>Convert(int,ISNULL(reg.[SMS_EFTWithdraw_Confirmation],0)) THEN 1 ELSE 0 END ) AS [SMS_EFTWithdraw_Confirmation_ChangeIndicator]	    
            	
	            ,web.[Email_MoneyDeposit_Confirmation] AS [Email_MoneyDeposit_Confirmation]
                ,(CASE WHEN Convert(int,ISNULL(web.[Email_MoneyDeposit_Confirmation],0))<>Convert(int,ISNULL(reg.[MoneyDeposit_Confirmation_Email],0)) THEN 1 ELSE 0 END ) AS [Email_MoneyDeposit_Confirmation_ChangeIndicator]	    
            	
	            ,web.[Email_MoneyWithdraw_Confirmation] AS [Email_MoneyWithdraw_Confirmation]
	            ,(CASE WHEN Convert(int,ISNULL(web.[Email_MoneyWithdraw_Confirmation],0))<>Convert(int,ISNULL(reg.[MoneyWithdraw_Confirmation_Email],0)) THEN 1 ELSE 0 END ) AS [Email_MoneyWithdraw_Confirmation_ChangeIndicator]

	            ,web.[Email_EftWithdraw_Confirmation] AS [Email_EftWithdraw_Confirmation]
	            ,(CASE WHEN Convert(int,ISNULL(web.[Email_EftWithdraw_Confirmation],0))<>Convert(int,ISNULL(reg.[EFTWithdraw_Confirmation_Email],0)) THEN 1 ELSE 0 END ) AS [Email_EftWithdraw_Confirmation_ChangeIndicator]	        	        
            	
	            ,web.[Email_Trade_Confirmation] AS [Email_Trade_Confirmation]
	            ,(CASE WHEN Convert(int,ISNULL(web.[Email_Trade_Confirmation],0))<>Convert(int,ISNULL(reg.[Trade_Confirmation_Email],0)) THEN 1 ELSE 0 END ) AS [Email_Trade_Confirmation_ChangeIndicator]	        
            	
	            ,web.Email AS [Email]
	            ,(CASE WHEN ISNULL(web.Email,0)<>ISNULL(reg.Email,0) THEN 1 ELSE 0 END ) AS [Email_ChangeIndicator]	        
            	
	            ,web.Cell_No AS [Mobile No]
	            ,(CASE WHEN ISNULL(web.Cell_No,0)<>ISNULL(reg.Mobile_No,0) THEN 1 ELSE 0 END ) AS [Mobile No_ChangeIndicator]	    
                ,web.AccountType as AccountType
                ,
                (
                CASE 
                        WHEN Convert(int,ISNULL(web.[Web_Service],0))<>Convert(int,ISNULL(reg.Web_Service,0)) THEN 'Web'
                        WHEN Convert(int,web.[SMS_Confirmation])<>Convert(int,reg.[SMS_Confirmation]) THEN 'SMS Confirmation'
                        WHEN Convert(int,web.[SMS_Trade])<>Convert(int,reg.[SMS_Trade]) THEN 'SMS Trade'
                        WHEN Convert(int,web.[SMS_MoneyDeposit_Confirmation])<>Convert(int,ISNULL(reg.[SMS_MoneyDeposit_Confirmation],0)) THEN 'SMS Deposit'
                        WHEN Convert(int,web.[SMS_MoneyWithdraw_Confirmation])<>Convert(int,ISNULL(reg.[SMS_MoneyWithdraw_Confirmation],0)) THEN 'SMS Withdraw'
                        WHEN Convert(int,web.[SMS_EFTWithdraw_Confirmation])<>Convert(int,ISNULL(reg.[SMS_EFTWithdraw_Confirmation],0)) THEN 'SMS EFT Withdraw'
			            WHEN Convert(int,web.[Email_MoneyDeposit_Confirmation])<>Convert(int,ISNULL(reg.[MoneyDeposit_Confirmation_Email],0)) THEN 'Email Deposit'
			            WHEN Convert(int,web.[Email_MoneyWithdraw_Confirmation])<>Convert(int,ISNULL(reg.[MoneyWithdraw_Confirmation_Email],0)) THEN 'Email Withdraw'
			            WHEN Convert(int,web.[Email_EftWithdraw_Confirmation])<>Convert(int,ISNULL(reg.[EFTWithdraw_Confirmation_Email],0)) THEN 'Email EFT Withdraw'
			            WHEN Convert(int,web.[Email_Trade_Confirmation])<>Convert(int,ISNULL(reg.[Trade_Confirmation_Email],0)) THEN 'Email Confirmation'
                        WHEN web.Email<>reg.Email THEN 'Email'
                        WHEN web.Cell_No<>reg.Mobile_No THEN 'Mobile'
                END
                ) AS [Comment]
                
                FROM [SBP_Database].[dbo].[Web2014_GetAllServiceRegistration_Temp] as web
                JOIN dbo.SBP_Service_Registration as reg
                ON 
                reg.Cust_Code=web.Cust_Code
                WHERE 
            	
                    Convert(int,web.[Web_Service])<>Convert(int,reg.Web_Service)
                    OR
                    Convert(int,web.[SMS_Confirmation])<>Convert(int,reg.[SMS_Confirmation])
                    OR
                    Convert(int,web.[SMS_Trade])<>Convert(int,reg.[SMS_Trade])
                    OR
                    Convert(int,web.[SMS_MoneyDeposit_Confirmation])<>Convert(int,ISNULL(reg.[SMS_MoneyDeposit_Confirmation],0))
                    OR
                    Convert(int,web.[SMS_MoneyWithdraw_Confirmation])<>Convert(int,ISNULL(reg.[SMS_MoneyWithdraw_Confirmation],0))
                    OR
                    Convert(int,web.[SMS_EFTWithdraw_Confirmation])<>Convert(int,ISNULL(reg.[SMS_EFTWithdraw_Confirmation],0))
		            OR
                    Convert(int,web.[Email_MoneyDeposit_Confirmation])<>Convert(int,ISNULL(reg.[MoneyDeposit_Confirmation_Email],0))
		            OR
                    Convert(int,web.[Email_MoneyWithdraw_Confirmation])<>Convert(int,ISNULL(reg.[MoneyWithdraw_Confirmation_Email],0))
		            OR
                    Convert(int,web.[Email_Trade_Confirmation])<>Convert(int,ISNULL(reg.[Trade_Confirmation_Email],0))
		            OR
                    web.Email<>reg.Email
                    OR
                    web.Cell_No<>reg.Mobile_No
            	
            	
                UNION ALL
                
                select web.Cust_Code
                ,web.[Web_Service] AS [Web_Service]
	            ,1 AS [Web_Service_ChangeIndicator]
                ,web.[SMS_Confirmation] AS [SMS_Confirmation]
	            ,1 AS [SMS_Confirmation_ChangeIndicator]
                ,web.[SMS_Trade] AS [SMS_Trade]
	            ,1 AS [SMS_Trade_ChangeIndicator]
                ,web.[SMS_MoneyDeposit_Confirmation] AS [MoneyDeposit_Confirmation_SMS]
	            ,1 AS [SMS_MoneyDeposit_Confirmation_ChangeIndicator]
                ,web.[SMS_MoneyWithdraw_Confirmation] AS [MoneyWithdraw_Confirmation_SMS]
	            ,1 AS [SMS_MoneyWithdraw_Confirmation_ChangeIndicator]
                ,web.[SMS_EFTWithdraw_Confirmation] AS [EFTWithdraw_Confirmation_SMS]
	            ,1 AS [SMS_EFTWithdraw_Confirmation_ChangeIndicator]
                ,web.[Email_MoneyDeposit_Confirmation] AS [Email_MoneyDeposit_Confirmation]
	            ,1 AS [Email_MoneyDeposit_Confirmation_ChangeIndicator]
	            ,web.[Email_MoneyWithdraw_Confirmation] AS [Email_MoneyWithdraw_Confirmation]
	            ,1 AS [Email_MoneyWithdraw_Confirmation_ChangeIndicator]
	            ,web.[Email_EftWithdraw_Confirmation] AS [Email_EftWithdraw_Confirmation]
	            ,1 AS [Email_EftWithdraw_Confirmation_ChangeIndicator]
	            ,web.[Email_Trade_Confirmation] AS [Email_Trade_Confirmation]
	            ,1 AS [Email_Trade_Confirmation_ChangeIndicator]
                ,web.Email AS Email
	            ,1 AS [Email_ChangeIndicator]
                ,web.Cell_No AS [Mobile No]
	            ,1 AS [Mobile No_ChangeIndicator]
                ,web.AccountType as AccountType    
                ,
                (
                CASE 
                        WHEN reg.Cust_Code Is NULL THEN 'New Registration'		
                END
                ) AS [Comment]
                FROM [SBP_Database].[dbo].[Web2014_GetAllServiceRegistration_Temp] as web
                LEFT OUTER JOIN dbo.SBP_Service_Registration as reg
                ON 
                reg.Cust_Code=web.Cust_Code
                WHERE 
                reg.Cust_Code is NULL AND web.Cust_Code<>0	 
            ) AS T
            ORDER BY
            CONVERT(INT,T.Cust_Code)
            ";

            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(query);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }

            return dt;
        }

        public DataTable GetData_AsSBPCompitable(int Id)
        {
            DataTable dt = new DataTable();

            string query;
            query = "";

            query = @"DECLARE @Indication varchar(200)
                    SET @Indication=(
					                    Select t.[Request_Type]
					                    From [Web2014_GetNewWithdrawalRequest_Temp] as t
					                    Where t.[Request_Id]=" + Id + @"
                    )

                    IF(@Indication='Direct Account')
                    BEGIN
                    	
	                    DECLARE @MaxPaymentId int
	                    SET @MaxPaymentId=(
						                    Select ISNULL(Max([Payment_ID]),0)
						                    From [SBP_Payment_Posting_Request]
	                    )

	                    SELECT 
                           @MaxPaymentId+1 AS [Payment_ID]
	                      ,[Customer_Id] AS [Cust_Code]
                          ,[Amount] AS [Amount]
	                      ,[Request_Date] AS [Received_Date]
                          ,'EFT' AS [Payment_Media]
	                      ,'Withdraw' AS [Deposit_Withdraw]
	                      ,'' AS [Vouchar_SN]
	                      ,'' AS [Trans_Reason]	
                          ,0  AS [Approval_Status]
                          ,[Remarks] AS [Remarks]
                          ,[Entry_Date] AS [Entry_Date]
	                      ,'' AS [Entry_By]	
	                      ,[Request_Id] As [OnlineOrderNo]
	                    FROM [Web2014_GetNewWithdrawalRequest_Temp]
	                    WHERE [Request_Id]=" + Id + @"
                    	
                    END
                    ELSE IF(@Indication='Cheque Requisition')
                    BEGIN
	                    SELECT 
                        [Customer_Id] AS [Cust_Code]
	                    ,[Amount] AS [Amount]  
	                    ,[Request_Date] AS [Requisition_Date]
                        ,'Check' AS [Payment_Media]
                        ,(Select t.Branch_ID From SBP_Broker_Branch as t Where Lower([Cheque_Collection_Branch]) LIKE '%'+Lower(t.Branch_Name)+'%') AS [Collection_Branch_ID]
                        ,[Remarks] AS  [Remarks] 
	                    ,0 AS [Is_Approved]
	                    ,0 AS [Is_Printed]  
	                    ,0 AS [IsACPayee]
	                    ,0 AS[Is_Received]
	                    ,[Entry_Date] AS [Entry_Date]
	                    ,'' AS [Entry_Branch_ID]  
	                    ,[Request_Id] AS [OnlineOrderNo]
                      FROM [Web2014_GetNewWithdrawalRequest_Temp]
                      WHERE [Request_Id]=" + Id + @"

                    END";

            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(query);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }

            return dt;
        }

        // Forward Data To SBP

        public void ForwardTo_Web2014_UserQuery(int Id)
        {
            string queryForward = @"INSERT INTO [SBP_Database].[dbo].[Web2014_UserQuery]
                                         ([Contact_Us_Id]
                                           ,[From_Email_Address]
                                           ,[Contact_To]
                                           ,[Contact_Subject]
                                           ,[Contact_Message]
                                           ,[Contact_Date]
                                           ,[Contact_Status]
                                           ,[Entry_Date]
                                           ,[OnlineEntry_Date])
                                (
		                                SELECT [Contact_Us_Id]
                                       ,[From_Email_Address]
                                       ,[Contact_To]
                                       ,[Contact_Subject]
                                       ,[Contact_Message]
                                       ,[Contact_Date]
                                       ,'Closed'
                                       ,Convert(varchar(10),GETDATE(),126) 
                                       ,[Entry_Date]
		                                FROM [SBP_Database].[dbo].[Web2014_GetNewUserQuery_Temp]		
		                                WHERE [Contact_Us_Id]=" + Id + @"		
                                )";

            string queryDelete = @"Delete Web2014_GetNewUserQuery_Temp
                                Where [Contact_Us_Id]=" + Id + "";

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();
                _dbConnection.ExecuteNonQuery(queryForward);
                _dbConnection.ExecuteNonQuery(queryDelete);
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

        public void FrowardTo_ServiceRegistration(string CustCode)
        {
            string queryUpdate = @"
                DECLARE @Cust_Code Varchar(200)
                DECLARE @Switch INT

                SET @Cust_Code='" + CustCode + @"'

                SET @Switch=( 
                                Select COUNT(*)
                                From [SBP_Service_Registration]
                                Where Cust_Code=@Cust_Code
                )
                Print Convert(varchar(100),@Switch)
                IF(@Switch>0)
                Begin

                    UPDATE [SBP_Database].[dbo].[SBP_Service_Registration]
                    SET		
                      [Web_Service] =(select MAX(Convert(int,t.[Web_Service]))	from [Web2014_GetAllServiceRegistration_Temp] as t where t.[Cust_Code]=@Cust_Code Group BY t.[Cust_Code] )
                      ,[SMS_Confirmation] =(select MAX(Convert(int,t.[SMS_Confirmation]))	from [Web2014_GetAllServiceRegistration_Temp] as t where t.[Cust_Code]=@Cust_Code Group BY t.[Cust_Code] )
	                  ,[Trade_Confirmation_Email] =(select MAX(Convert(int,t.[Email_Trade_Confirmation]))	from [Web2014_GetAllServiceRegistration_Temp] as t where t.[Cust_Code]=@Cust_Code Group BY t.[Cust_Code] )
                      ,[SMS_Trade] =( select MAX(Convert(int,t.[SMS_Trade])) from [Web2014_GetAllServiceRegistration_Temp] as t where t.[Cust_Code]=@Cust_Code Group By t.Cust_Code)
                      ,[SMS_MoneyDeposit_Confirmation] = ( select MAX(Convert(int,t.[SMS_MoneyDeposit_Confirmation])) from [Web2014_GetAllServiceRegistration_Temp] as t where t.[Cust_Code]=@Cust_Code Group By t.Cust_Code)
                      ,[MoneyDeposit_Confirmation_Email] = ( select MAX(Convert(int,t.[Email_MoneyDeposit_Confirmation])) from [Web2014_GetAllServiceRegistration_Temp] as t where t.[Cust_Code]=@Cust_Code Group By t.Cust_Code)
	                  ,[SMS_MoneyWithdraw_Confirmation] = ( select MAX(Convert(int,t.[SMS_MoneyWithdraw_Confirmation])) from [Web2014_GetAllServiceRegistration_Temp] as t where t.[Cust_Code]=@Cust_Code Group By t.Cust_Code)
                      ,[MoneyWithdraw_Confirmation_Email] = ( select MAX(Convert(int,t.[Email_MoneyWithdraw_Confirmation])) from [Web2014_GetAllServiceRegistration_Temp] as t where t.[Cust_Code]=@Cust_Code Group By t.Cust_Code)  
	                  ,[SMS_EFTWithdraw_Confirmation] = ( select MAX(Convert(int,t.[SMS_EFTWithdraw_Confirmation])) from [Web2014_GetAllServiceRegistration_Temp] as t where t.[Cust_Code]=@Cust_Code Group By t.Cust_Code)
	                  ,[EFTWithdraw_Confirmation_Email] = ( select MAX(Convert(int,t.[Email_EftWithdraw_Confirmation])) from [Web2014_GetAllServiceRegistration_Temp] as t where t.[Cust_Code]=@Cust_Code Group By t.Cust_Code)      
	                  ,[Email]=(select MAX(t.Email) from [Web2014_GetAllServiceRegistration_Temp] as t where t.[Cust_Code]=@Cust_Code Group By t.Cust_Code)
                      ,[Mobile_No]=(select MAX(t.[Cell_No]) from [Web2014_GetAllServiceRegistration_Temp] as t where t.[Cust_Code]=@Cust_Code Group By t.Cust_Code)
                      
                      --,[Entry_Date] = ( select t.[Entry_Date] from [Web2014_GetAllServiceRegistration_Temp] as t where t.[Cust_Code]='104')
                    WHERE [Cust_Code]=@Cust_Code

                End
                ELSE 
                Begin
                    INSERT INTO [SBP_Database].[dbo].[SBP_Service_Registration]
                    ([Cust_Code],[Web_Service],[SMS_Confirmation],[Trade_Confirmation_Email],[SMS_Trade],[SMS_MoneyDeposit_Confirmation],[MoneyDeposit_Confirmation_Email],[SMS_MoneyWithdraw_Confirmation],[MoneyWithdraw_Confirmation_Email],[SMS_EFTWithdraw_Confirmation],[EFTWithdraw_Confirmation_Email],[E_Charge],[Email],[Mobile_No])
                    (
                        Select 
                        t.[Cust_Code]
                        ,MAX(Convert(int,t.[Web_Service]))
                        ,MAX(Convert(int,t.[SMS_Confirmation]))
		                ,MAX(Convert(int,t.[Email_Trade_Confirmation]))
                        ,MAX(Convert(int,t.[SMS_Trade]))
                        ,MAX(Convert(int,t.[SMS_MoneyDeposit_Confirmation]))
		                ,MAX(Convert(int,t.[Email_MoneyDeposit_Confirmation]))
                        ,MAX(Convert(int,t.[SMS_MoneyWithdraw_Confirmation]))
		                ,MAX(Convert(int,t.[Email_MoneyWithdraw_Confirmation]))
                        ,MAX(Convert(int,t.[SMS_EFTWithdraw_Confirmation]))	
		                ,MAX(Convert(int,t.[Email_EftWithdraw_Confirmation]))
                        ,0
                        ,MAX(Email)
                        ,MAX(Cell_No)
                        From [Web2014_GetAllServiceRegistration_Temp] as t 
                        Where t.[Cust_Code]=@Cust_Code 
                        Group BY t.[Cust_Code] 
                    )
                End";
            string queryDelete = @"Delete [Web2014_GetAllServiceRegistration_Temp]
                                WHERE Cust_Code='" + CustCode + "'";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();
                _dbConnection.ExecuteNonQuery(queryUpdate);
                //_dbConnection.ExecuteNonQuery(queryDelete);
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

        // Delete Data From Temp

        public string DeleteFrom_Web2014_WithdrawalRequest_Temp(int Id)
        {
            string queryDelete = @"Delete Web2014_GetNewWithdrawalRequest_Temp
                                    Where Request_Id=" + Id + "";

            return queryDelete;
        }

        public void RejectedFrom_Web2014_WithdrawalRequest_Temp(int Id)
        {
            CommonBAL bal = new CommonBAL();
            string query = @"DECLARE @Indication varchar(200)
                    SET @Indication=(
					                    Select t.[Request_Type]
					                    From [Web2014_GetNewWithdrawalRequest_Temp] as t
					                    Where t.[Request_Id]=" + Id + @"
                    )

                    IF(@Indication='Direct Account')
                    BEGIN
                    	
	                    --DECLARE @MaxPaymentId int
	                    --SET @MaxPaymentId=(
						--                    Select ISNULL(Max([Payment_ID]),0)
						--                    From [SBP_Payment_Posting_Request]
	                    --)

	                    
                        INSERT INTO [SBP_Database].[dbo].[SBP_Payment_Posting_Request]
                       (
                        --[Payment_ID]
			            --,
                        [Cust_Code]
			            ,[Amount]
			            ,[Received_Date]
			            ,[Payment_Media]
			            ,[Deposit_Withdraw]
			            ,[Vouchar_SN]
	                    ,[Trans_Reason]
                        ,[Payment_Approved_Date]
			            ,[Approval_Status]
			            ,[Rejection_Reason]
			            ,[Remarks]
			            ,[Entry_Date]
			            ,[Entry_By]
			            ,[OnlineOrderNo] 
                        ,[OnlineEntry_Date])

                        SELECT 
                          --@MaxPaymentId+1 AS [Payment_ID]
	                      --,
                           [Customer_Id] AS [Cust_Code]
                          ,[Amount] AS [Amount]
	                      ,'" + bal.GetCurrentServerDate().ToShortDateString() + @"' AS [Received_Date]
                          ,'EFT' AS [Payment_Media]
	                      ,'Withdraw' AS [Deposit_Withdraw]
	                      ,'' AS [Vouchar_SN]
	                      ,'' AS [Trans_Reason]
                          ,'" + bal.GetCurrentServerDate().ToShortDateString() + @"' AS [Approval_Status]  	
                          ,2  AS [Approval_Status]
                          ,'UNNECESSARY' AS [Rejection_Reason]   
                          ,[Remarks] AS [Remarks]
                          ,[Entry_Date] AS [Entry_Date]
	                      ,'' AS [Entry_By]	
	                      ,[Request_Id] As [OnlineOrderNo]
                          ,[Entry_Date] AS [OnlineEntry_Date]                            
	                    FROM [Web2014_GetNewWithdrawalRequest_Temp]
	                    WHERE [Request_Id]=" + Id + @"
                    	
                    END
                    ELSE IF(@Indication='Cheque Requisition')
                    BEGIN
	                    INSERT INTO [SBP_Database].[dbo].[SBP_Check_Requisition]
                       ([Cust_Code]
                       ,[Amount]
                       ,[Requisition_Date]
                       ,[Collection_Branch_ID]
                       ,[Remarks]
                       ,[Is_Approved]
                       ,[Rejection_Reason]
                       ,[Is_Printed]
                       ,[IsACPayee]
                       ,[Is_Received]
                       ,[Entry_Date]
                       ,[Entry_Branch_ID]
                       ,[OnlineOrderNo]
                       ,[OnlineEntry_Date])
                        (
                        SELECT 
                        [Customer_Id] AS [Cust_Code]
	                    ,[Amount] AS [Amount]  
	                    ,'" + bal.GetCurrentServerDate().ToShortDateString() + @"' AS [Requisition_Date]
                        ,(Select t.Branch_ID From SBP_Broker_Branch as t Where Lower([Cheque_Collection_Branch]) LIKE '%'+Lower(t.Branch_Name)+'%') AS [Collection_Branch_ID]
                        ,[Remarks] AS  [Remarks] 
	                    ,2 AS [Is_Approved]
                        ,'UNNECESSARY' AS [Rejection_Reason]
	                    ,0 AS [Is_Printed]  
	                    ,0 AS [IsACPayee]
	                    ,0 AS[Is_Received]
	                    ,[Entry_Date] AS [Entry_Date]
	                    ,'' AS [Entry_Branch_ID]  
	                    ,[Request_Id] AS [OnlineOrderNo]
                        ,[Entry_Date] AS [OnlineEntry_Date]
                      FROM [Web2014_GetNewWithdrawalRequest_Temp]
                      WHERE [Request_Id]=" + Id + @")

                    END";
            string query_Delete = DeleteFrom_Web2014_WithdrawalRequest_Temp(Id);
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();
                _dbConnection.ExecuteNonQuery(query);
                _dbConnection.ExecuteNonQuery(query_Delete);
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

        public void RejectedFrom_Web2014_GetNewUserQuery_Temp(int Id)
        {

            string query = @"INSERT INTO [SBP_Database].[dbo].[Web2014_UserQuery]
                           ([Contact_Us_Id]
                           ,[From_Email_Address]
                           ,[Contact_To]
                           ,[Contact_Subject]
                           ,[Contact_Message]
                           ,[Contact_Date]
                           ,[Contact_Status]
                           ,[Entry_Date]
		                   ,[OnlineEntry_Date])

                (
	                Select [Contact_Us_Id]
		                  ,[From_Email_Address]
		                  ,[Contact_To]
		                  ,[Contact_Subject]
		                  ,[Contact_Message]
		                  ,[Contact_Date]
		                  ,'Deleted'
		                  ,Convert(varchar(10),GETDATE(),126)
		                  ,[Entry_Date]
	                From [Web2014_GetNewUserQuery_Temp]
	                Where [Contact_Us_Id]=" + Id + @"
                )";
            string query_Delete =  @"Delete Web2014_GetNewUserQuery_Temp
                                Where [Contact_Us_Id]=" + Id + "";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();
                _dbConnection.ExecuteNonQuery(query);
                _dbConnection.ExecuteNonQuery(query_Delete);
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
    


      
    }
}



