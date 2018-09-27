using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DataAccessLayer;
using BusinessAccessLayer.BO;

namespace BusinessAccessLayer.BAL
{
    public class TradePriceBAL
    {
         private DbConnection _dbConnection;

         public TradePriceBAL()
        {
            _dbConnection = new DbConnection();
        }
        public void SaveProcessedTradeInfo(DataTable dataTable, string tableName)
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

        public void Insert_Dealer_Trade_Price_Temp()
        {
            string query = @"Dealer_Trade_Price_Temp";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();                
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

        public void SaveProcessedPriceTemp_ByInsertQuery(DataTable dataTable)
        {
            List<string> queryList = new List<string>();

            foreach (DataRow dr in dataTable.Rows)
            {
                //NI
                string temp = @"INSERT INTO [SBP_Trade_Price_Temp]
                               ([Instrument_Code]
                               ,[ISIN]
                               ,[Category]
                               ,[CompulsorySpot]
                               ,[Trade_Date]
                               ,[Open]
                               ,[High]
                               ,[Low]
                               ,[Close_Price]
                               ,[Var]
                               ,[VarPercent]
                               ,[AssetClass]
                               ,[Sector])
                         VALUES
                               ('"+Convert.ToString(dr["SecurityCode"])+@"'
                               ,'" + Convert.ToString(dr["ISIN"]) + @"'
                               ,'" + Convert.ToString(dr["Category"]) + @"'
                               ,'" + Convert.ToString(dr["CompulsorySpot"]) + @"'
                               ,'" + Convert.ToString(dr["TradeDate"]) + @"'
                               ," + ( Convert.ToString(dr["Open"]) == "" ? "0" : Convert.ToString(dr["Open"]) ) + @"
                               ," + ( Convert.ToString(dr["High"]) == "" ? "0" : Convert.ToString(dr["High"]) )  + @"
                               ," + ( Convert.ToString(dr["Low"]) == "" ? "0" : Convert.ToString(dr["Low"]) ) + @"
                               ," + ( Convert.ToString(dr["Close"]) == "" ? "0" : Convert.ToString(dr["Close"]) ) + @"
                               ," + ( Convert.ToString(dr["Var"]) == "" ? "0" : Convert.ToString(dr["Var"]) ) + @"
                               ," + ( Convert.ToString(dr["VarPercent"]) == "" ? "0" : Convert.ToString(dr["VarPercent"]) ) + @"
                               ,'" +(  Convert.ToString(dr["AssetClass"]) == "" ? "0" : Convert.ToString(dr["AssetClass"]) ) + @"'
                               ,'" +(  Convert.ToString(dr["Sector"]) == "" ? "0" : Convert.ToString(dr["Sector"]) ) + @"')";
                queryList.Add(temp);
            }


            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();
                foreach (string temp in queryList)
                    _dbConnection.ExecuteNonQuery(temp);
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
        
        public void TruncateTradePriceInfo()
        {
            string queryString = "";
            queryString = "TRUNCATE TABLE SBP_Trade_Price_Temp";
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

        public DataTable ValidateCompany()
        {
            DataTable dataTable;
            string queryString = "SELECT DISTINCT(Instrument_Code) From SBP_Trade_Price_Temp WHERE Instrument_Code NOT IN (SELECT Comp_Short_Code From SBP_Company)";

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

        public DataTable ValidateGroupMisMatch_FlexTrade()
        {
            DataTable dataTable;
            //string queryString = "Select DISTINCT(SecurityCode) as 'Company',Comp_Category as 'Old Category',SBP_Transaction_Temp.Category as 'New Category' FROM SBP_Company,SBP_Comp_Category,SBP_Transaction_Temp"
            // + " WHERE SBP_Company.Comp_Cat_ID=SBP_Comp_Category.Comp_Cat_ID AND SBP_Company.Comp_Short_Code=SecurityCode AND SBP_Comp_Category.Comp_Category !=SBP_Transaction_Temp.Category";
            string queryString_price = @"Select DISTINCT
                                    (Instrument_Code) as 'Company'
                                    ,Comp_Category as 'Old Category'
                                    ,SBP_Trade_Price_Temp.Category as 'New Category' 
                                    FROM 
                                    SBP_Company
                                    ,SBP_Comp_Category
                                    ,SBP_Trade_Price_Temp
                                    WHERE 
                                    SBP_Company.Comp_Cat_ID=SBP_Comp_Category.Comp_Cat_ID 
                                    AND SBP_Company.Comp_Short_Code=Instrument_Code 
                                    AND SBP_Comp_Category.Comp_Category !=SBP_Trade_Price_Temp.Category";
            try
            {
                _dbConnection.ConnectDatabase();
                dataTable = _dbConnection.ExecuteQuery(queryString_price);
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
        
        public DataTable GetGridData()
        {
            DataTable dataTable;
            //NI
            string queryString = "SELECT Instrument_Code,Open_Price,High_Price,Low_Price,Close_Price,Change,Total_Trade,Volume,Trade_Value From SBP_Trade_Price_Temp";
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
        public DataTable GetGridData_FlexTrade()
        {
            DataTable dataTable;
            string queryString = @"Select Instrument_Code,ISIN,Category,CompulsorySpot,Trade_Date,Close_Price
                                From SBP_Trade_Price_Temp";
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

        public DataTable GetInstrumentGroupInfo()
        {
            DataTable dataTable;
            string queryString = @"SELECT [Comp_Cat_ID]
                                          ,[Comp_Category]
                                   FROM SBP_Comp_Category";
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

        public void ChangeCompanyGroup(string comp_Short_Code, int catId)
        {
            string queryString = "";
            queryString = @"UPDATE SBP_Company
                          SET [Comp_Cat_ID]=" + catId
                          + " WHERE [Comp_Short_Code]='" + comp_Short_Code + "'";
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

        public DataTable GetInstrumentCompanyInfo()
        {
            DataTable dataTable;
            string queryString = @"SELECT [Comp_Short_Code]
                                          ,[Comp_Cat_ID]
                                   FROM SBP_Company";
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


        public void SaveIntoTradePrice(DateTime eventDate)
        {
            string queryStringInsert = "";
            string queryStringUploadHistory = "";
            CommonBAL comBAL = new CommonBAL();
            long slNo = comBAL.GenerateID("SBP_Upload_History", "Upload_ID");
            //NI
            queryStringInsert ="INSERT INTO SBP_Trade_Price(Instrument_Code,Open_Price,High_Price,Low_Price,Close_Price,Change,Total_Trade,Volume,Trade_Value,Trade_Date) SELECT Instrument_Code,Open_Price,High_Price,Low_Price,Close_Price,Change,Total_Trade,Volume,Trade_Value,'" +eventDate + "' FROM SBP_Trade_Price_Temp";
            queryStringUploadHistory = "INSERT INTO SBP_Upload_History(Upload_ID,File_Name,Upload_Date,Entry_By) SELECT TOP 1 " + slNo + ",'tradePrice','" + eventDate.ToShortDateString() + "','" + GlobalVariableBO._userName + "' FROM SBP_Trade_Price_Temp";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();
                //_dbConnection.ExecuteNonQuery(queryStringUpdate);
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
        public void SaveIntoTradePrice_FlexTrade(DateTime eventDate)
        {
            string queryStringInsert = "";
            string queryStringUploadHistory = "";
            string TradePriceZero = "";
            CommonBAL comBAL = new CommonBAL();
            long slNo = comBAL.GenerateID("SBP_Upload_History", "Upload_ID");
            queryStringInsert = @"INSERT INTO [SBP_Trade_Price]
                                ([Instrument_Code], [ISIN], [Category], [CompulsorySpot], [Trade_Date], [Close_Price])
                                SELECT [Instrument_Code], [ISIN], [Category], [CompulsorySpot], [Trade_Date], [Close_Price] 
                                FROM SBP_Trade_Price_Temp "
                ;
            queryStringUploadHistory = "INSERT INTO SBP_Upload_History(Upload_ID,File_Name,Upload_Date,Entry_By) SELECT TOP 1 " + slNo + ",'tradePrice','" + eventDate.ToShortDateString() + "','" + GlobalVariableBO._userName + "' FROM SBP_Trade_Price_Temp"
                                ;
            TradePriceZero = @"
                                Select * Into #LastTradedate 
                                From 
	                                (
	                                Select distinct t.Trade_Date,t.Instrument_Code,Close_Price,t.LastTradeDays From 
		                                (
		                                Select 
			                                MAX(Trade_Date) As Trade_Date,Instrument_Code
			                                ,DATEDIFF(DAY,Max(CAST(Trade_Date As Date)),CAST(GETDATE() As Date)) As LastTradeDays 
                                			
		                                From SBP_Trade_Price 		
		                                group by Instrument_Code		
		                                )as t
		                                Join SBP_Trade_Price as p on p.Trade_Date=t.Trade_Date and p.Instrument_Code=t.Instrument_Code
	                                )As T Where T.LastTradeDays>30
                                	
	                                --select * From #LastTradedate
                                	
	                                INSERT INTO [SBP_Trade_Price](
                                [Instrument_Code], [ISIN], [Category], [CompulsorySpot], [Trade_Date], [Close_Price]
                                )
                                select distinct
                                t.Instrument_Code
                                ,(Select ISIN_No From SBP_Company Where Comp_Short_Code=t.Instrument_Code) As IsinNO
                                ,(Select (Select Comp_Category From SBP_Comp_Category Where C.Comp_Cat_ID=Comp_Cat_ID) From SBP_Company As C Where C.Comp_Short_Code=t.Instrument_Code)As Category
                                ,'' As CompulsorySpot
                                ,CAST(GETDATE() As Date) Trade_Date,0.00
                                From #LastTradedate as t";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();
                //_dbConnection.ExecuteNonQuery(queryStringUpdate);
                _dbConnection.ExecuteNonQuery(queryStringInsert+TradePriceZero);

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

        

        public void UploadWebPriceData(DataTable dataTable,String tableName)
        {
            string queryStringDel = "";
            string queryStringInsert = "";
            if(dataTable.Rows[0][9]!=DBNull.Value)
                queryStringDel = "DELETE FROM SBP_Trade_Price WHERE Trade_Date='" + Convert.ToDateTime(dataTable.Rows[0][9]) + "'";
            //NI
            queryStringInsert = "INSERT INTO SBP_Trade_Price(Instrument_Code,Open_Price,High_Price,Low_Price,Close_Price,Change,Total_Trade,Volume,Trade_Value,Trade_Date) SELECT Instrument_Code,Open_Price,High_Price,Low_Price,Close_Price,Change,Total_Trade,Volume,Trade_Value,Trade_Date FROM SBP_Trade_Price_Temp";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();
                _dbConnection.BulkCopy(dataTable,tableName);
                _dbConnection.ExecuteNonQuery(queryStringDel);
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
    }
}
