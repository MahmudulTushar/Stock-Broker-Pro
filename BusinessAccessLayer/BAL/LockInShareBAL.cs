using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DataAccessLayer;
using BusinessAccessLayer.BO;

namespace BusinessAccessLayer.BAL
{
    public class LockInShareBAL
    {
        private DbConnection _dbConnection;
        public LockInShareBAL()
        {
            _dbConnection = new DbConnection();
        }

        public void SaveProcessedLockInShareInfo(DataTable lockInShareDataTable, string tableName)
        {
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.BulkCopy(lockInShareDataTable, tableName);
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

        public DataTable ValidateBOID()
        {
            DataTable dataTable;
            //string queryString = "SELECT DISTINCT(BO_ID) From SBP_16DP95UX WHERE BO_ID NOT IN (SELECT BO_ID From SBP_Customers)";
            string queryString=@"Select
                                 distinct lockIn.[BO_ID] as BO_ID
                                 From [SBP_Database].[dbo].[SBP_16DPB7UX] as lockIn
                                 Where lockIn.[BO_ID] NOT IN 
                                 (
	                                 Select j.BO_ID
	                                 From dbo.SBP_Customers as j
                                 )";
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

        public DataTable ValidateCompany()
        {
            DataTable dataTable;
            //string queryString = "SELECT DISTINCT(ISIN_No) From SBP_16DP95UX WHERE ISIN_No NOT IN (SELECT ISIN_No From SBP_Company)";
            string queryString=@"Select 
                                Distinct 
                                (	
	                                Select t.Comp_Short_Code
	                                From SBP_Company as t 
	                                Where t.ISIN_No=lockIn.ISIN
                                ) as Comp_Short_Code
                                From [SBP_Database].[dbo].[SBP_16DPB7UX] as lockIn
                                Where lockIn.ISIN 
                                NOT IN 
                                (
	                                Select Max(t.ISIN_No) 
	                                From SBP_Company as t 
	                                Group By t.Comp_Short_Code 
                                )";
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

        public bool IsUploadMainTable()
        {
            DataTable dataTable;
            string queryString = "SELECT Upload_Date From SBP_Upload_History WHERE File_Name='16DPB7UX' AND Uplaod_Date IN(Select Date From SBP_16DPB7UX)";
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
            if (dataTable.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public DataTable GetGridData()
        {
            DataTable dataTable;
            string queryString = @"SELECT 
                                [BO_ID] AS [BO ID]
                                , [BO_Name] AS [BO Name]
                                , [ISIN_Name] AS [ISIN No]
                                , [Lockin_Quantity] AS [Qty]
                                , [Lockin_Setup_Date] AS [Setup Date]
                                , [Lockin_Expiry_Date] AS [Expiry Date]
                                , [IssuePrice] AS [Issue Price]
                                FROM [SBP_Database].[dbo].[SBP_16DPB7UX]";
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

        public void SaveIntoShareDW()
        {
            string queryStringInsShareDW = "";
            string queryStringInsHistory = "";
            string queryStringUploadHistory = "";
            
            //Insert Share DW
            queryStringInsShareDW = @"INSERT INTO SBP_Share_DW
                        (
                        [Cust_Code]
                        , [Comp_Short_Code]
                        , [Quantity]
                        , [Lockedin_Quantity]
                        , [Available_Quantity]
                        , [Lockedin_Expiry_Date]
                        , [Deposit_Withdraw]
                        ,[Record_Date]
                        , [Received_Date]
                        , [Effective_Date]
                        , [Vouchar_No]
                        , [No_Script]
                        , [Deposit_Type]
                        , [Share_Type]
                        , [Issue_Price]
                        , [Issue_Amount]
                        , [CDBL_Charge]
                        , [Entry_Date]
                        , [Entry_By] 
                        )
                        SELECT 
                        dbo.GetCustCodeFromBO(BO_ID)
                        ,dbo.GetCompShortCodeFromISINNo(ISIN)
                        ,[Lockin_Quantity]
                        ,[Lockin_Quantity]
                        ,0
                        ,Lockin_Expiry_Date
                        ,'Deposit'
                        ,[Lockin_Setup_Date]
                        ,[Lockin_Setup_Date]
                        ,[Lockin_Setup_Date]
                        ,NULL
                        ,NULL
                        ,'" + BusinessAccessLayer.Constants.Indication_ShareDepositType.LockIn+@"'
                        ,'CDBL'
                        ,[IssuePrice]
                        ,[IssuePrice]*[Lockin_Quantity]
                        ,0.00
                        ,GETDATE()
                        ,'" + GlobalVariableBO._userName+ @"' 
                        From [SBP_16DPB7UX]";

            //Insert History
            queryStringInsHistory = @"INSERT INTO [SBP_16DPB7UX_History]
                        (
                        [BO_ID]
                        , [BO_Name]
                        , [ISIN]
                        , [ISIN_Name]
                        , [Lockin_Quantity]
                        , [Lockin_Setup_Date]
                        , [Lockin_Expiry_Date]
                        , [IssuePrice]
                        )
                        SELECT 
                        [BO_ID]
                        , [BO_Name]
                        , [ISIN]
                        , [ISIN_Name]
                        , [Lockin_Quantity]
                        , [Lockin_Setup_Date]
                        , [Lockin_Expiry_Date]
                        , [IssuePrice] 
                        FROM [SBP_16DPB7UX]";
            
            //Insert File Upload Hisotry
            CommonBAL comBAL = new CommonBAL();
            long slNo = comBAL.GenerateID("SBP_Upload_History", "Upload_ID");
            queryStringUploadHistory = "INSERT INTO SBP_Upload_History(Upload_ID,File_Name,Upload_Date,Entry_By) SELECT TOP 1 " + slNo + ",'16DPB7UX',[Lockin_Setup_Date],'" + GlobalVariableBO._userName + @"' FROM [SBP_16DPB7UX]";

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();
                _dbConnection.ExecuteNonQuery(queryStringInsShareDW);
                _dbConnection.ExecuteNonQuery(queryStringInsHistory);
                _dbConnection.ExecuteNonQuery(queryStringUploadHistory);
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

        public DataTable GetGridIssueAmount()
        {
            DataTable dataTable;
            //string queryString = "SELECT DISTINCT(ISIN) as 'Company Name',Issue_Price as 'Issue Price' From SBP_16DPB7UX";
            string queryString = @"SELECT 
            (
	            Select p.Comp_Short_Code 
	            From SBP_Company As p 
	            Where p.ISIN_No=T.ISIN
            ) AS [Company Code]
            ,0.00 AS [Issue Price]
            FROM
            (
                SELECT 
                Distinct [ISIN] as ISIN
                FROM [SBP_Database].[dbo].[SBP_16DPB7UX]
            )AS T";
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


        public void TruncateIPOTemp()
        {
            string queryString = "";
            queryString = "TRUNCATE TABLE SBP_16DPB7UX";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();
                _dbConnection.ExecuteNonQuery(queryString);
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

        public void UpdateIssueAmount(string companyName, float issuePrice)
        {
            string queryStringUpdateTemp = "";
            queryStringUpdateTemp = @"UPDATE SBP_16DPB7UX 
            SET IssuePrice=" + issuePrice + @" 
            WHERE ISIN= ( 
				            Select TOP 1 ISIN_No 
				            FROM SBP_Company 
				            WHERE Comp_Short_Code='" + companyName + @"')";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();
                _dbConnection.ExecuteNonQuery(queryStringUpdateTemp);
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
        public void Validate_FreeQty(double Qty, double LockInQty, double AvailableQty, double FreeQty)
        {
            try
            {
                if (!(LockInQty >= FreeQty))
                    throw new Exception("Invalid Free Qty");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Validate_LockInQty(double Qty, double LockInQty, double AvailableQty)
        {
            try
            {
                if (AvailableQty < 0)
                    throw new Exception("Invalid Lock In Qty");
                if (!(Qty==LockInQty+AvailableQty))
                    throw new Exception("Invalid Lock In Qty");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void FreeLockInShare(int Share_DW_ID, double Qty, double LQty, double AQty)
        {
            string queryStringUpdateTemp = "";
            queryStringUpdateTemp = @"UPDATE [SBP_Database].[dbo].[SBP_Share_DW]
                                    SET [Quantity]=" + Qty + @"
                                      , [Lockedin_Quantity]=" + LQty + @"
                                      , [Available_Quantity]=" + AQty + @"
                                    WHERE [Share_DW_ID]=" + Share_DW_ID + @"";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();
                _dbConnection.ExecuteNonQuery(queryStringUpdateTemp);
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
        public DataTable GetLockInFreeGrid(DateTime fromDate, DateTime toDate)
        {
            DataTable dt = new DataTable();
            string queryStringUpdateTemp = "";
            queryStringUpdateTemp = @"SELECT [Share_DW_ID] AS [Share_DW_ID], [Cust_Code] AS [Cust Code], [Comp_Short_Code] AS [Share Code], [Quantity] AS [Qty], [Lockedin_Quantity] AS [LockIn Qty], [Available_Quantity] AS [Avail. Qty], [Lockedin_Expiry_Date] AS [Expiry Date], [Received_Date] AS [Received Date], [Issue_Price] AS [Issue Price], [Deposit_Type] AS [Remarks] 
            FROM [SBP_Database].[dbo].[SBP_Share_DW]
            WHERE [Lockedin_Expiry_Date]>='" + fromDate.ToShortDateString() + "' AND  [Lockedin_Expiry_Date]<='" + toDate.ToShortDateString() + "' AND [Lockedin_Quantity]>0 AND [Deposit_Type] IN ('" + BusinessAccessLayer.Constants.Indication_ShareDepositType.LockIn + "','" + BusinessAccessLayer.Constants.Indication_ShareDepositType.Ipo + "') ORDER BY [Lockedin_Expiry_Date],[Received_Date]";
            try
            {
                _dbConnection.ConnectDatabase();
                //_dbConnection.StartTransaction();
                dt=_dbConnection.ExecuteQuery(queryStringUpdateTemp);
                //_dbConnection.Commit();
            }
            catch (Exception exception)
            {
                //_dbConnection.Rollback();
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            
            return dt;
        }

    }
}
