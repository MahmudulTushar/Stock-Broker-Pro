using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using System.Data;
using BusinessAccessLayer.BO;


namespace BusinessAccessLayer.BAL
{
    public class AssetSettlementBAL
    {
        private DbConnection _dbConnection;
        public AssetSettlementBAL()
        { 
            _dbConnection=new DbConnection();
        }

        public DataTable getUnSettledData()
        {
            DataTable dt;
            string query = @"SELECT 
	                               CONVERT(Varchar(10),[PurchaseDate],120) as 'Date'
	                              ,[Catagori]
	                              ,[Type] as 'Asset_Type'
	                              ,[Name] as 'Asset_Name'
	                              ,[Quantity]
	                              ,[Rate]
	                              ,[Cost]
	                              ,( select Branch_Name from dbo.SBP_Broker_Branch
		                            where Branch_ID=ast.Branch_ID) as 'Branch_Name'
                                  ,[assetID]
                                  ,[Model]
                                  ,[LifeTime]
                                  ,[SalvageValue]
                                  ,[DepreciationRate]
                                  ,[DepreciationAmount]
                                  ,[NetBalance]
                                  ,[Status]
                                  ,[Remarks]
                                  ,[EntryDate]
                                  ,[EntryBy]
                                  ,[UpdateDate]
                                  ,[UpdateBy]
                                  ,[TransactiionID]
                                  ,[Expense_ID]
                                  ,[Category_ID]
                                  ,[Branch_ID]
                                  
                              FROM [SBP_Database].[dbo].[SBP_Asset] as ast
                              where ast.Status='Approved'";
            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(query);
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dt;
        }
        public DataTable getUnSettledDataIntoTexBox(int asstID)
        {
            DataTable dt;
            string query = @"SELECT 
	                               CONVERT(Varchar(10),[PurchaseDate],120) as 'Date'
	                              ,[Catagori]
	                              ,[Type] as 'Asset_Type'
	                              ,[Name] as 'Asset_Name'
	                              ,[Quantity]
	                              ,[Rate]
	                              ,[Cost]
	                              ,( select Branch_Name from dbo.SBP_Broker_Branch
		                            where Branch_ID=ast.Branch_ID) as 'Branch_Name'
                                  ,[assetID]
                                  ,[Model]
                                  ,[LifeTime]
                                  ,[SalvageValue]
                                  ,[DepreciationRate]
                                  ,[DepreciationAmount]
                                  ,[NetBalance]
                                  ,[Status]
                                  ,[Remarks]
                                  ,[EntryDate]
                                  ,[EntryBy]
                                  ,[UpdateDate]
                                  ,[UpdateBy]
                                  ,[TransactiionID]
                                  ,[Expense_ID]
                                  ,[Category_ID]
                                  ,[Branch_ID]
                                  
                              FROM [SBP_Database].[dbo].[SBP_Asset] as ast
                              where ast.Status='Approved'
                              and assetID="+asstID+"";
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
        public void settleAssetFinally(double LTMonth, double SV, double DepAmt, int assetID)
        {
            string query = @"UPDATE [SBP_Database].[dbo].[SBP_Asset]
                               SET [LifeTime] =" + LTMonth + @"
                                  ,[SalvageValue] =" +SV+@"
                                  ,[DepreciationAmount] = "+DepAmt+@"
                                  ,[Status] = 'Settled'
                                  ,[UpdateDate] = '"+GlobalVariableBO._currentServerDate+@"'
                                  ,[UpdateBy] = '" + GlobalVariableBO._userName + @"'
                             WHERE assetID=" + assetID + "";          
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(query);                
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }        
        }
        public void settledAssetSendToDepTable(int assetID)
        {
            string queryDep = @"INSERT INTO [SBP_Database].[dbo].[SBP_Depreciation]
                               ([assetID]
                               ,[Name]
                               ,[Model]
                               ,[PurchaseDate]
                               ,[Cost]
                               ,[LifeTime]
                               ,[SalvageValue]
                               ,[DepreciationRate]
                               ,DepreciationPerYear
                               ,[NetBalance]
                               ,[UpdateDate]
                               ,[UpdateBy]
                               ,[TransactiionID]
                               ,[Expense_ID]
                               ,[Category_ID]
                               ,[Branch_ID]
                               ,[Status])
                           SELECT [assetID]
                              ,[Name]
                              ,[Model]
                              ,[PurchaseDate]
                              ,[Cost]
                              ,[LifeTime]
                              ,[SalvageValue]
                              ,[DepreciationRate]
                              ,[DepreciationAmount]
                              ,[NetBalance]
                              ,[UpdateDate]
                              ,[UpdateBy]
                              ,[TransactiionID]
                              ,[Expense_ID]
                              ,[Category_ID]
                              ,[Branch_ID]
                              ,[status]
                          FROM [SBP_Database].[dbo].[SBP_Asset]
                          where Status='Settled' and assetID=" + assetID + "";

            try
            {
                _dbConnection.ConnectDatabase();                
                _dbConnection.ExecuteNonQuery(queryDep);
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
    }
}