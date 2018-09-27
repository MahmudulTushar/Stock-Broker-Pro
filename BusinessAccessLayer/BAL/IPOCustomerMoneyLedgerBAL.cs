using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using System.Data;

namespace BusinessAccessLayer.BAL
{
   
   public class IPOCustomerMoneyLedgerBAL
    {
        private DbConnection _dbConnection;
        public IPOCustomerMoneyLedgerBAL()
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
        public DataTable IPOGetCustomerCode(string boID)
        {
            DataTable dataTable;
            string queryString = "";
            queryString = "SELECT Cust_Code FROM SBP_Customers WHERE BO_ID='" + boID + "'";
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
    }
}
