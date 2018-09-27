using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using System.Data;

namespace BusinessAccessLayer.BAL
{
   public class IPOCustomerSummeryLedgerBAL
    {
       private DbConnection _dbConnection;
       public IPOCustomerSummeryLedgerBAL()
       {
           this._dbConnection = new DbConnection();
       }
       public DataTable IPOGetCustInfoByBOID(string boId)
       {
           DataTable dataTable;
           string queryString = "";
           queryString = "SELECT SBP_Customers.Cust_Code as 'Cust_Code',Cust_Name,BO_Id,ISNULL(dbo.GetLastTradeDateTimeByCust(dbo.GetCustCodeFromBO('" + boId + "')),'Not Yet Trade') AS 'LTD',(SELECT Cust_Status FROM SBP_Cust_Status WHERE SBP_Cust_Status.Cust_Status_ID=SBP_Customers.Cust_Status_ID)AS Status,(SELECT BO_Status FROM SBP_BO_Status WHERE BO_Status_ID=SBP_Customers.BO_Status_ID) AS 'BO_Status',ISNULL((SELECT SUM(Balance) FROM SBP_Share_Balance_Temp WHERE SBP_Share_Balance_Temp.Cust_Code=SBP_Customers.Cust_Code),0) AS Share_Balance,(SELECT BO_Type FROM SBP_BO_Type WHERE BO_Type_ID=SBP_Customers.BO_Type_ID AND SBP_Customers.BO_ID='" + boId + "') AS 'BO Type'  FROM SBP_Customers,SBP_Cust_Personal_Info WHERE BO_ID='" + boId + "' AND SBP_Customers.Cust_Code=SBP_Cust_Personal_Info.Cust_Code";
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
       public DataTable IPOGetCustomerCode(string custCode)
       {
           DataTable dataTable;
           string queryString = "";
           queryString = "SELECT SBP_Customers.Cust_Code as 'Cust_Code',Cust_Name,BO_Id,ISNULL(dbo.GetLastTradeDateTimeByCust('" + custCode + "'),'Not Yet Trade') AS 'LTD',(SELECT Cust_Status FROM SBP_Cust_Status WHERE SBP_Cust_Status.Cust_Status_ID=SBP_Customers.Cust_Status_ID)AS Status,(SELECT BO_Status FROM SBP_BO_Status WHERE BO_Status_ID=SBP_Customers.BO_Status_ID) AS 'BO_Status',ISNULL((SELECT SUM(Balance) FROM SBP_Share_Balance_Temp WHERE SBP_Share_Balance_Temp.Cust_Code=SBP_Customers.Cust_Code),0)AS Share_Balance,(SELECT BO_Type FROM SBP_BO_Type WHERE BO_Type_ID=SBP_Customers.BO_Type_ID AND SBP_Customers.Cust_Code='" + custCode + "') AS 'BO Type' FROM SBP_Customers,SBP_Cust_Personal_Info WHERE SBP_Customers.Cust_Code='" + custCode + "' AND SBP_Customers.Cust_Code=SBP_Cust_Personal_Info.Cust_Code";
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
       public DataTable GetIPOCustSummeryLedger(string custCode, DateTime fromDate, DateTime toDate)
       {
           DataTable dtShareDWReview = null;
           string quryString = "";
           quryString = @"RptIPOGetCustomerSummeryLedger";
           try
           {
               _dbConnection.ConnectDatabase();
               _dbConnection.ActiveStoredProcedure();
               _dbConnection.AddParameter("@custCode", SqlDbType.NVarChar, custCode);
               _dbConnection.AddParameter("@fromDate", SqlDbType.DateTime, fromDate);
               _dbConnection.AddParameter("@toDate", SqlDbType.DateTime, toDate);
               dtShareDWReview = _dbConnection.ExecuteProQuery(quryString);
           }
           catch (Exception exception)
           {
               throw exception;
           }
           finally
           {
               _dbConnection.CloseDatabase();
           }
           return dtShareDWReview;

       }
       public DataTable GetIpoCustSummaryBasicInfo(string custCode)
       {
           DataTable dtShareDWReview = null;
           string quryString = "";

           quryString = "RptGetCustCodeName";
           try
           {
               _dbConnection.ConnectDatabase();
               _dbConnection.ActiveStoredProcedure();
               _dbConnection.AddParameter("@custCode", SqlDbType.NVarChar, custCode);
               dtShareDWReview = _dbConnection.ExecuteProQuery(quryString);
           }
           catch (Exception exception)
           {
               throw exception;
           }
           finally
           {
               _dbConnection.CloseDatabase();
           }
           return dtShareDWReview;

       }
       public DataTable IpoOpenCloseWithdrawDepost(string custcode, DateTime fromdate,DateTime todate)
       {
           DataTable dt = new DataTable();
           string query = @"RptIPOCustoemrOpeningBalance";
           try
           {
               this._dbConnection.ConnectDatabase();
               this._dbConnection.ActiveStoredProcedure();
               this._dbConnection.AddParameter("@custoCode", SqlDbType.VarChar, custcode);
               this._dbConnection.AddParameter("@FromDate", SqlDbType.DateTime, fromdate);
               this._dbConnection.AddParameter("@ToDate", SqlDbType.DateTime, todate);
               dt = this._dbConnection.ExecuteProQuery(query);
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
    }
}
