using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DataAccessLayer;

namespace BusinessAccessLayer.BAL
{
    public class CustomerSummeryBAL
    {
         DbConnection _dbConnection;
         public CustomerSummeryBAL()
          {
            _dbConnection = new DbConnection();
          }
      
        public DataTable GetCustSummery(string custCode, DateTime fromDate, DateTime toDate)
        {
            DataTable dtCustSummery = null;
            string quryString = "";
            quryString = @"RptGetCustSummery";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@custCode", SqlDbType.NVarChar, custCode);
                _dbConnection.AddParameter("@fromDate", SqlDbType.DateTime, fromDate.ToShortDateString());
                _dbConnection.AddParameter("@toDate", SqlDbType.DateTime, toDate.ToShortDateString());
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

        public DataTable GetSummeryDataTransaction(string custCode, DateTime fromDate, DateTime toDate)
        {
            DataTable dtSummeryTrans = null;
            string quryString = "";
            quryString = @"RptGetSummeryDataTransaction";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@custCode", SqlDbType.NVarChar, custCode);
                _dbConnection.AddParameter("@fromDate", SqlDbType.DateTime, fromDate.ToShortDateString());
                _dbConnection.AddParameter("@toDate", SqlDbType.DateTime, toDate.ToShortDateString());
                dtSummeryTrans = _dbConnection.ExecuteProQuery(quryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dtSummeryTrans;
        }
        public DataTable GetSummeryDataPayment(string custCode, DateTime fromDate, DateTime toDate)
        {
            DataTable dtSummeryPay = null;
            string quryString = "";
            quryString = @"RptGetSummeryDataPayment";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@custCode", SqlDbType.NVarChar, custCode);
                _dbConnection.AddParameter("@fromDate", SqlDbType.DateTime, fromDate.ToShortDateString());
                _dbConnection.AddParameter("@toDate", SqlDbType.DateTime, toDate.ToShortDateString());
                dtSummeryPay = _dbConnection.ExecuteProQuery(quryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dtSummeryPay;

        }
    }
}
