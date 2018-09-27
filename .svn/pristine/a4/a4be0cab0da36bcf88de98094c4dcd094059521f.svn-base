using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DataAccessLayer;

namespace BusinessAccessLayer.BAL
{
    public class TaxBAL
    {
        DbConnection _dbConnection;
        public TaxBAL()
        {
            _dbConnection = new DbConnection();
        }
        public DataTable GetCustSummery(string custCode, DateTime fromDate, DateTime toDate)
        {
            _dbConnection.TimeoutPeriod = 3000;

            DataTable dtCustSummery = null;
            string quryString = "";
            quryString = "SP_TaxCerfificate";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@custCode", SqlDbType.NVarChar, custCode);
                _dbConnection.AddParameter("@dateFrom", SqlDbType.DateTime, fromDate.ToShortDateString());
                _dbConnection.AddParameter("@dateTo", SqlDbType.DateTime, toDate.ToShortDateString());
                dtCustSummery = _dbConnection.ExecuteProQuery(quryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dtCustSummery;

        }

        public DataTable GetTaxStatement(string custCode, DateTime fromDate, DateTime toDate)
        {
            _dbConnection.TimeoutPeriod = 3000;

            DataTable dtCustSummery = null;
            string quryString = "";
            quryString = "SP_Tax_Statement";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@custCode", SqlDbType.NVarChar, custCode);
                _dbConnection.AddParameter("@dateFrom", SqlDbType.DateTime, fromDate.ToShortDateString());
                _dbConnection.AddParameter("@dateTo", SqlDbType.DateTime, toDate.ToShortDateString());
                dtCustSummery = _dbConnection.ExecuteProQuery(quryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dtCustSummery;
        }

        public DataTable GetDepositWithdrawBalence(string custCode, DateTime fromDAte, DateTime toDAte)
        {
            string queryString = "SELECT ISNULL(SUM(Amount),0),(SELECT ISNULL(SUM(Amount),0) FROM dbo.SBP_Payment WHERE Deposit_Withdraw='Withdraw' AND Cust_Code='"+custCode+"' AND Received_Date BETWEEN '"+fromDAte+"' AND '"+toDAte+"') FROM dbo.SBP_Payment WHERE Deposit_Withdraw='Deposit' AND Cust_Code='"+custCode+"' AND Received_Date BETWEEN '"+fromDAte+"' AND '"+toDAte+"'";
            DataTable data = new DataTable();

            try
            {
                _dbConnection.ConnectDatabase();
                data = _dbConnection.ExecuteQuery(queryString);
            }

            catch (Exception)
            {
                throw;
            }

            finally
            {
                _dbConnection.CloseDatabase();
            }


            return data;
        }

        public DataTable GetAdditiobnalShare(string custCode, DateTime fromDAte, DateTime toDAte)
        {
            string queryAString = "SELECT Comp_Short_Code,Balance,Remarks,Trade_Date FROM SBP_Share_Balance_Temp WHERE Cust_Code='"+custCode+"' AND Trade_Date BETWEEN '"+fromDAte+"' AND '"+toDAte+"' AND Remarks NOT IN('By Trade','STOCK SPLIT')";
            DataTable dataRecord = new DataTable();

            try
            {
                _dbConnection.ConnectDatabase();
                dataRecord = _dbConnection.ExecuteQuery(queryAString);
            }

            catch (Exception)
            {
                throw;
            }

            finally
            {
                _dbConnection.CloseDatabase();
            }


            return dataRecord;
        }
    }
}
