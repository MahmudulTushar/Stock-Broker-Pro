using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DataAccessLayer;

namespace BusinessAccessLayer.BAL
{
   public class WebDataExportBALOld
   {
       private DbConnection _dbConnection;

       public WebDataExportBALOld()
       {
           _dbConnection=new DbConnection();
       }

       public void ProcessWebData()
       {
           string queryString = "SP_ProcessWebData";

           try
           {
               _dbConnection.ConnectDatabase();
               _dbConnection.ActiveStoredProcedure();
               _dbConnection.TimeoutPeriod = 500;
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

       public DataTable GetCompanyProfile()
       {
           DataTable dataTable;
           string queryString = "SELECT Code_No,Comp_Name,Comp_Short_Name,Comp_Group,Face_Value,Market_Lot,Share_Type FROM dbo.SBP_WebCompanyProfile";
          
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

       public DataTable GetCustomerProfile()
       {
           DataTable dataTable;
           string queryString = "SELECT Cust_Code,Cust_Name,Address,BO_ID,BO_Type,Phone,Mobile FROM dbo.SBP_WebCustomerProfile";

           try
           {
               _dbConnection.ConnectDatabase();
               _dbConnection.TimeoutPeriod = 10000;
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

       public DataTable GetPaymentHistory()
       {
           DataTable dataTable;
           string queryString = "SELECT Cust_Code ,REPLACE(CONVERT(varchar,Received_Date,102),'.','-'),Deposit_Withdraw ,CONVERT(DECIMAL(16,2),Amount) ,Description ,Payment_Media_No ,Voucher_SL_No FROM dbo.SBP_WebPaymenthistory";
           try
           {
               _dbConnection.ConnectDatabase();
               _dbConnection.TimeoutPeriod = 10000;
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

       public DataTable GetShareBalance()
       {
           DataTable dataTable;
           string queryString = "SELECT Cust_Code ,Comp_short_Code ,Balance ,Matured_Balance ,Company_Group,Share_Type FROM dbo.SBP_WebShareBalance";
           try
           {
               _dbConnection.ConnectDatabase();
               _dbConnection.TimeoutPeriod = 10000;
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

       public DataTable GetShareBalanceDetails()
       {
           DataTable dataTable;
           string queryString = "SELECT Cust_Code ,Company_Short_Code ,REPLACE(CONVERT(varchar,Trade_Date,102),'.','-'),Buy_Qty ,Sell_Qty ,Balance ,Remarks ,CONVERT(DECIMAL(18,2),Buy_Total ),CONVERT(DECIMAL(18,2),Buy_Avg),CONVERT(DECIMAL(18,2),Sell_Total),CONVERT(DECIMAL(18,2), Sell_Avg) FROM dbo.SBP_WebShareBalanceDetails";
           try
           {
               _dbConnection.ConnectDatabase();
               _dbConnection.TimeoutPeriod = 10000;
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

       public DataTable GetShareDW()
       {
           DataTable dataTable;
           string queryString = "SELECT Cust_Code ,REPLACE(CONVERT(varchar,Received_Date,102),'.','-'),Comp_Short_Code ,Quantity ,Deposit_Withdraw , No_Script ,Voucher_No  FROM dbo.SBP_WebShareDW";
           try
           {
               _dbConnection.ConnectDatabase();
               _dbConnection.TimeoutPeriod = 10000;
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

       public DataTable GetTransactionDetails()
       {
           DataTable dataTable;
           string queryString = "SELECT Customer ,REPLACE(CONVERT(varchar,EventDate,102),'.','-') ,EventTime ,Instrument_Code ,BuySellFlag , Instrument_Catagory ,TradeQty ,CONVERT(DECIMAL(18,2),TradePrice),CONVERT(DECIMAL(18,2),TotalShareValue), CONVERT(DECIMAL(18,2),Commission),UserID FROM dbo.SBP_WebTransactions";
           try
           {
               _dbConnection.ConnectDatabase();
               _dbConnection.TimeoutPeriod = 10000;
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

       public DataTable GetTradeDetails()
       {
           DataTable dataTable;
           string queryString = "SELECT Instrument_Code ,CONVERT(DECIMAL(18,2),Open_price),CONVERT(DECIMAL(18,2),High_Price ),CONVERT(DECIMAL(18,2),Low_Price ),CONVERT(DECIMAL(18,2),Close_Price),CONVERT(DECIMAL(18,2),Change ),CONVERT(DECIMAL(18,2),Total_Trade),Volume,CONVERT(DECIMAL(18,2),Trade_Value),REPLACE(CONVERT(varchar,Trade_Date,102),'.','-') FROM dbo.SBP_WebTradeDetails";
           try
           {
               _dbConnection.ConnectDatabase();
               _dbConnection.TimeoutPeriod = 10000;
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

       public DataTable GetMoneyBalance()
       {
           DataTable dataTable;

           //Updated By Shahrior on June 05 2012
           string queryMoneyBalance = "SELECT Cust_Code,CONVERT(DECIMAL(30,2),Balance),CONVERT(DECIMAL(30,2),Deposit),CONVERT(DECIMAL(30,2),Withdraw),REPLACE(CONVERT(varchar,Entry_Date,102),'.','-') FROM dbo.SBP_WebMoneyBalanceTemp";
           try
           {
               _dbConnection.ConnectDatabase();
               _dbConnection.TimeoutPeriod = 500;
               dataTable = _dbConnection.ExecuteQuery(queryMoneyBalance);
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


   }
}
