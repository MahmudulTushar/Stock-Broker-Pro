using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DataAccessLayer;

namespace BusinessAccessLayer.BAL
{
    public class CustomerInsideBAL
    {
         private DbConnection _dbConnection;
         public CustomerInsideBAL()
         {
             _dbConnection = new DbConnection();
         }
         public DataTable GetCustGraphValues(string custCode)
         {
             DataTable dataTable;
             string queryString = "";

             queryString = "SELECT TOP 30 EventDate,(SELECT ISNULL(SUM(T1.TradePrice*T1.TradeQty),0) FROM SBP_Transactions AS T1 WHERE T1.EventDate=SBP_Transactions.EventDate AND T1.Customer='" + custCode + "') FROM SBP_Transactions GROUP BY EventDate ORDER BY EventDate DESC";

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

        public DataTable GetCustInfoByBOID(string boId)
        {
            DataTable dataTable;
            string queryString = "";
            queryString = "SELECT SBP_Customers.Cust_Code as 'Cust_Code',Cust_Name,BO_Id,dbo.GetMaturedMoneyBalance(dbo.GetCustCodeFromBO('" + boId + "')) as 'MaturedBalance',dbo.GetCurrentMoneyBalance(dbo.GetCustCodeFromBO('" + boId + "')) as 'CurrentBalance' FROM SBP_Customers,SBP_Cust_Personal_Info WHERE BO_ID='" + boId + "' AND SBP_Customers.Cust_Code=SBP_Cust_Personal_Info.Cust_Code";
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

        public DataTable GetCustInfoByCustCode(string custCode)
        {
            DataTable dataTable;
            string queryString = "";
            queryString = "SELECT SBP_Customers.Cust_Code as 'Cust_Code',Cust_Name,BO_Id,dbo.GetMaturedMoneyBalance('" + custCode + "') as 'MaturedBalance',dbo.GetCurrentMoneyBalance('" + custCode + "') as 'CurrentBalance' FROM SBP_Customers,SBP_Cust_Personal_Info WHERE SBP_Customers.Cust_Code='" + custCode + "' AND SBP_Customers.Cust_Code=SBP_Cust_Personal_Info.Cust_Code";
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

        public DataTable GetCustBasicInfo(string custCode)
        {
            DataTable dataTable;
            string queryString = "";
            queryString ="SELECT SBP_Customers.Cust_Code as 'Cust_Code',(SELECT Cust_Name FROM SBP_Cust_Personal_Info WHERE SBP_Cust_Personal_Info.Cust_Code='" +custCode +"') AS 'Cust_Name',BO_Id,(SELECT Address1 FROM SBP_Cust_Contact_Info WHERE SBP_Cust_Contact_Info.Cust_Code='" +custCode + "') AS 'Address'," +" (SELECT Phone FROM SBP_Cust_Contact_Info WHERE SBP_Cust_Contact_Info.Cust_Code='" + custCode +"') AS 'Phone',(SELECT Mobile FROM SBP_Cust_Contact_Info WHERE SBP_Cust_Contact_Info.Cust_Code='" +custCode +"') AS 'Mobile',(SELECT Branch_Name FROM SBP_Broker_Branch WHERE SBP_Customers.Branch_ID=SBP_Broker_Branch.Branch_ID AND SBP_Customers.Cust_Code='" +custCode + "') AS 'Branch'" +" FROM SBP_Customers WHERE Cust_Code='" + custCode + "'"; 
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

        public DataTable GetCustMoneyBalanceInfo(string custCode)
        {
            DataTable dataTable;
            string queryString = "";
            queryString = "SELECT dbo.GetMaturedMoneyBalance('" + custCode + "') as 'MaturedBalance',dbo.GetCurrentMoneyBalance('" + custCode + "') as 'CurrentBalance',dbo.GetMaturedShareBalance('" + custCode + "') as 'MaturedShareBalance',dbo.GetCurrentShareBalance('" + custCode + "') as 'CurrentShareBalance',(SELECT SUM(Amount) FROM SBP_Payment WHERE Deposit_Withdraw='Deposit' AND SBP_Payment.Cust_Code='" + custCode + "') AS 'TotalDeposit',(SELECT SUM(Amount) FROM SBP_Payment WHERE Deposit_Withdraw='Withdraw' AND SBP_Payment.Cust_Code='" + custCode + "') AS 'TotalWithdraw'";
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

        public DataTable GetCustMarginInfo(string custCode)
        {
            DataTable dataTable;
            string queryString = "";
            queryString = "SELECT Plan_Name,Charge_Rate,Free_Amount,M_Ratio FROM SBP_Margin_Charge_Plan WHERE Cust_Code='"+custCode+"'";
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

        public string GetCustCodeFromBO(string boId)
        {
            DataTable dataTable;
            string CustCode="";
            string queryString = "";
            queryString = "SELECT dbo.GetCustCodeFromBO('" + boId + "')";
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
            if(dataTable.Rows.Count>0)
            {
                if (dataTable.Rows[0][0]!=DBNull.Value)
                    CustCode = dataTable.Rows[0][0].ToString();
            }
            return CustCode;
        }

        public bool CustCodeDoesExist(string custCode)
        {
            DataTable dataTable;
            string queryString = "";
            queryString = "SELECT Cust_Code FROM SBP_Customers WHERE Cust_Code='"+custCode+"'";
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
            if (dataTable.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        public DataTable GetCashbackInfo(string custCode)
        {
            DataTable dataTable;
            string queryString = "";
            queryString ="SELECT Plan_Name,CB_Last_Paid,(SELECT Min_Trade_Amount FROM SBP_Cashback_Plan_Criteria WHERE SBP_Cashback_Plan_Criteria.Plan_Name=SBP_Cashback_Reg.Plan_Name) AS 'Min_Trade_Amount',(SELECT Rate FROM SBP_Cashback_Plan_Criteria  WHERE SBP_Cashback_Plan_Criteria.Plan_Name=SBP_Cashback_Reg.Plan_Name) AS 'CB_Rate' FROM SBP_Cashback_Reg WHERE Cust_Code='" +custCode + "'";
                //"SELECT CB_Rate,Min_Trade_Amount,CB_Last_Paid FROM SBP_Cashback_Reg WHERE Cust_Code="+custCode+"";
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
