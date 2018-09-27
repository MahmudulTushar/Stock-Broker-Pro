using System;
using System.Data;
using BusinessAccessLayer.BO;
using DataAccessLayer;

namespace BusinessAccessLayer.BAL
{
    public class TradeOldBAL
    {
        private DbConnection _dbConnection;

        public TradeOldBAL()
        {
            _dbConnection = new DbConnection();
        }
        public void SaveProcessedTradeInfoOld(DataTable dataTable, string tableName)
        {
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.BulkCopy(dataTable, tableName);
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
        public void TruncateTradeInfo()
        {
            string queryString = "";
            queryString = "TRUNCATE TABLE SBP_Transactions_Temp_Old";
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

        public void SaveIntoTransaction()
        {
            string queryStringInsert = "";
            string queryStringUploadHistory = "";
            queryStringInsert = "EXECUTE SP_ProcessTransactions;";
            CommonBAL comBAL = new CommonBAL();
            long slNo = comBAL.GenerateID("SBP_Upload_History", "Upload_ID");
            queryStringUploadHistory = "INSERT INTO SBP_Upload_History(Upload_ID,File_Name,Upload_Date,Entry_By) SELECT TOP 1 " + slNo + ",'tradeFileOld',EventDate,'" + GlobalVariableBO._userName + "' FROM SBP_Transactions_Temp_Old";



            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();
                _dbConnection.ExecuteNonQuery(queryStringInsert);
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

        public void TruncateNewTradeInfo()
        {
            string queryString = "";
            queryString = "TRUNCATE TABLE SBP_Transaction_Temp";
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

        public void InsertIntoNewTradeInfo()
        {
            string queryStringInsert = "";
            queryStringInsert = "INSERT INTO SBP_Transaction_Temp(BORN,InstrumentCode,ISIN,UserID,BuySellFlag,TradeQty,TradePrice,EventDate,EventTime,MktType,HowlaType,Customer,BOID,InstrumentCategory) SELECT BORN,InstrumentCode,(SELECT ISIN_No FROM SBP_Company WHERE Comp_Short_Code=InstrumentCode),UserID,BuySellFlag,TradeQty,TradePrice,EventDate,EventTime,MktType,HowlaType,Customer,(SELECT (SELECT BO_ID FROM SBP_Broker_Info)+BO_ID FROM SBP_Customers WHERE Cust_Code=customer),(SELECT Comp_Category FROM SBP_Company,SBP_Comp_Category WHERE Comp_Short_Code=InstrumentCode AND SBP_Company.Comp_Cat_ID=SBP_Comp_Category.Comp_Cat_ID) FROM SBP_Transactions_Temp_Old;";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();
                _dbConnection.ExecuteNonQuery(queryStringInsert);
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

        public void UpdateClientCode(string _newcustCode,string _oldCustCode,int _updateID)
        {
            string queryStringInsert = "";
            CommonBAL commonBal=new CommonBAL();
            long slNo = commonBal.GenerateID("SBP_Transaction_Change_History", "Sl_No");
            string queryLog = "INSERT INTO SBP_Transaction_Change_History(Sl_No,BORN,InstrumentCode,ISIN,UserID,BuySellFlag,TradeQty,TradePrice,EventDate,EventTime,OldCustomer,NewCustomer,ModifiedBy,ModifiedDate) SELECT " + slNo + ",BORN,InstrumentCode,ISIN,UserID,BuySellFlag,TradeQty,TradePrice,EventDate,EventTime,'" + _oldCustCode + "','" + _newcustCode + "','" + GlobalVariableBO._userName + "',GETDATE() FROM SBP_Transaction_Temp WHERE ID='" + _updateID + "'";
            queryStringInsert = "UPDATE SBP_Transaction_Temp SET Customer='" + _newcustCode + "',BOID=(SELECT '12023500'+dbo.GetBOFromCustCode('" + _newcustCode + "')) WHERE ID=" + _updateID + "";
            //queryLog = "UPDATE SBP_Transaction_Temp SET Customer='" + _custCode + "',BOID=(SELECT '12023500'+dbo.GetBOFromCustCode('" + _custCode + "')) WHERE ID=" + _updateID + "";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();
                _dbConnection.ExecuteNonQuery(queryStringInsert);
                _dbConnection.ExecuteNonQuery(queryLog);
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


    
