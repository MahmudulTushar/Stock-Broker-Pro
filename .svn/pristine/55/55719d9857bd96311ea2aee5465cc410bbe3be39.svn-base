using System;
using System.Data;
using DataAccessLayer;

namespace BusinessAccessLayer.BAL
{
    public class MoneyLadgerReportBAL
    {
        DbConnection _dbConnection;
        public MoneyLadgerReportBAL()
        {
            _dbConnection = new DbConnection();
        }
        public DataTable GetAccruedBalanceData(string custCode, DateTime fromDate, DateTime toDate)
        {
            DataTable dt = new DataTable();
            string Query = @"Accrued_Money_Transaction";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();

                if (!string.IsNullOrEmpty(custCode))
                    _dbConnection.AddParameter("@Cust_Code", SqlDbType.NVarChar, custCode);

                _dbConnection.AddParameter("@StartDate", SqlDbType.DateTime, fromDate);
                _dbConnection.AddParameter("@EndDate", SqlDbType.DateTime, toDate);
                dt = _dbConnection.ExecuteProQuery(Query);
            }
            catch
            {
                throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dt;
        }

        public DataTable GetCustMoneyLedger(string custCode,DateTime fromDate,DateTime toDate)
        {
            DataTable dtShareDWReview = null;
            string quryString = "";
            quryString = @"RptGetCustMoneyLedger";
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
        public DataTable GetNewCustMoneyLedger(string custCode,DateTime fromDate,DateTime toDate)
        {
            DataTable dtShareDWReview = null;
            string quryString = "";
            quryString = @"RptGetNewCustMoneyLedger";
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
        
        public DataTable GetInterestServiceCharge(string custCode, DateTime fromDate, DateTime toDate)
        {
            DataTable dtShareDWReview = null;
            string quryString = "";
            quryString = @"RptGetInterestServiceCharge";
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
        public DataTable GetCustBasicInfo(string custCode)
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
    }
}
