using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using BusinessAccessLayer.BO;
using System.Data;

namespace BusinessAccessLayer.BAL
{
  public   class PaymentReviewBAL
    {
      DbConnection _dbConnection;

      public PaymentReviewBAL()
      {
          _dbConnection = new DbConnection();
      }

      public DataTable GneratePaymentReview(DateTime fromDate,DateTime toDate)
      {

          DataTable dtPaymentReview=null;
          string quryString="";

          quryString = @"RptGneratePaymentReview";
          try
          {
              _dbConnection.ConnectDatabase();
              _dbConnection.ActiveStoredProcedure();
              _dbConnection.AddParameter("@fromDate", SqlDbType.DateTime, fromDate.ToShortDateString());
              _dbConnection.AddParameter("@toDate", SqlDbType.DateTime, toDate.ToShortDateString());
              dtPaymentReview = _dbConnection.ExecuteProQuery(quryString);
          }
          catch (Exception exception)
          {
              throw exception;
          }
          finally
          {
              _dbConnection.CloseDatabase();
          }
          return dtPaymentReview;
      
      }

      public DataTable GneratePaymentReviewByBranchWise(DateTime fromDate,DateTime todate)
      {

          DataTable dtPaymentReview = null;
          string quryString = "";

          quryString = @"RptGneratePaymentReviewByBranchWise";
          try
          {
              _dbConnection.ConnectDatabase();
              _dbConnection.ActiveStoredProcedure();
              _dbConnection.AddParameter("@fromDate", SqlDbType.DateTime, fromDate.ToShortDateString());
              _dbConnection.AddParameter("@toDate", SqlDbType.DateTime, todate.ToShortDateString());
              _dbConnection.AddParameter("@branchid",SqlDbType.Int,GlobalVariableBO._branchId);
              dtPaymentReview = _dbConnection.ExecuteProQuery(quryString);
          }
          catch (Exception exception)
          {
              throw exception;
          }
          finally
          {
              _dbConnection.CloseDatabase();
          }
          return dtPaymentReview;

      }
      
      public DataTable GnerateNewPaymentReview(DateTime fromDate, DateTime toDate,int isSorted)
      {

          DataTable dtPaymentReview = null;
          string quryString = "";

          quryString = @"RptNewPaymentReviewSorted";
          try
          {
              _dbConnection.ConnectDatabase();
              _dbConnection.ActiveStoredProcedure();
              _dbConnection.AddParameter("@fromDate", SqlDbType.DateTime, fromDate.ToShortDateString());
              _dbConnection.AddParameter("@toDate", SqlDbType.DateTime, toDate.ToShortDateString());
              _dbConnection.AddParameter("@IsSorted", SqlDbType.Int, isSorted);              
              dtPaymentReview = _dbConnection.ExecuteProQuery(quryString);
          }
          catch (Exception)
          {
              throw;
          }
          finally
          {
              _dbConnection.CloseDatabase();
          }
          return dtPaymentReview;

      }

      public DataTable BalanceByDateReport(DateTime date)
      {

          DataTable dtPaymentReview = null;
          const string quryString = @"Report_CustBalanceListByDate";
          try
          {
              _dbConnection.ConnectDatabase();
              _dbConnection.ActiveStoredProcedure();
              _dbConnection.AddParameter("@date", SqlDbType.DateTime, date);
              dtPaymentReview = _dbConnection.ExecuteProQuery(quryString);
          }
          catch (Exception exception)
          {
              throw exception;
          }
          finally
          {
              _dbConnection.CloseDatabase();
          }
          return dtPaymentReview;

      }
      
    }
}
