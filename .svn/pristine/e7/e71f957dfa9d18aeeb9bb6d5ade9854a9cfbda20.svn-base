using System;
using System.Data;
using DataAccessLayer;

namespace BusinessAccessLayer.BAL
{
    public class ShareLedgerBAL
    {
        DbConnection _dbConnection;
        public ShareLedgerBAL()
        {
            _dbConnection = new DbConnection();
        }
        public DataTable GetCustShareSummery(string custCode, DateTime maxPriceDate)
        {
            DataTable dtShareDWReview = null;
            string quryString = "";
            quryString = @"RptGetCustShareSummery";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@custCode", SqlDbType.NVarChar, custCode);
                _dbConnection.AddParameter("@maxPriceDate", SqlDbType.DateTime, maxPriceDate.ToShortDateString());
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
        public DataTable PortfolioWithActualBEPRealizeGL(string Cust_Code, double CommRate, DateTime RequiredDate)
        {
            DataTable dt = new DataTable();
            string query = @"SP_NewPortfolio_CustomerWise_EXCEL";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@Cust_Code", SqlDbType.VarChar, Cust_Code);
                _dbConnection.AddParameter("@CommissionRate", SqlDbType.Money, CommRate);
                _dbConnection.AddParameter("@TradeDate", SqlDbType.DateTime, RequiredDate);
                dt = _dbConnection.ExecuteProQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dt;
        }
        public DataTable GetSpecificShareLedger(string custCode, DateTime fromDate, DateTime toDate)
        {
            DataTable dtShareDWReview = null;
            string quryString = "";
            quryString = @"RptGetSpecificShareLedger";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@custCode", SqlDbType.NVarChar, custCode);
                _dbConnection.AddParameter("@fromDate", SqlDbType.DateTime, fromDate.ToShortDateString());
                _dbConnection.AddParameter("@toDate", SqlDbType.DateTime, toDate.ToShortDateString());
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

        public DataTable GetShareDetails(string custCode)
        {
            DataTable dtShareDWReview = null;
            string quryString = "";
            quryString = @"RptGetShareDetails";//Rpt_CustomezedDSE_GetShareDetails
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
        public DataTable GetCustomerSummerBasicInfo(string custCode,DateTime toDate)
        {
            DataTable dtShareDWReview = null;
            string quryString = "";
            quryString = @"RptGetCustomerSummerBasicInfo";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@custCode", SqlDbType.NVarChar,custCode);
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

        public DateTime GetMaxPriceDate()
        {
            CommonBAL objBal = new CommonBAL();
            DataTable dtMaxDate = null;
            DateTime maxDate = objBal.GetCurrentServerDate();
            string quryString = "";
        
            quryString = "SELECT MAX(Trade_Date) AS 'Trade_Date' FROM SBP_Trade_Price";
            try
            {
                _dbConnection.ConnectDatabase();
                dtMaxDate = _dbConnection.ExecuteQuery(quryString);
            }
            catch (Exception exc)
            {
                throw exc;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            if (dtMaxDate.Rows.Count > 0)
                maxDate =Convert.ToDateTime(dtMaxDate.Rows[0]["Trade_Date"]);
            return maxDate;
        }
    }
}
