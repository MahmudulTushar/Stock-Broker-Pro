using System;
using System.Data;
using DataAccessLayer;
using BusinessAccessLayer.BO;

namespace BusinessAccessLayer.BAL
{
    public class Admin_Alternative_Report_Bal
    {
        DbConnection _dbConnection;
        public Admin_Alternative_Report_Bal()
        {
            _dbConnection = new DbConnection();
        }

        public DataTable GetTodaysCustBalance(DateTime dt)
        {
            DataTable dtCustTotalBalance = null;
            string quryString = "";
            quryString = @"RptGetCustTodaysTotalBalance_AdminAlternative";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@Date", SqlDbType.DateTime, dt.ToShortDateString());
                dtCustTotalBalance = _dbConnection.ExecuteProQuery(quryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dtCustTotalBalance;
        }

        public DataTable GetCustMoneyBalance(DateTime dt)
        {
            DataTable dtCustmoneyBalance = null;
            string quryString = "";
            quryString = @"RptGetCustTodaysMoneyBalance_AdminAlternative";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@Date", SqlDbType.DateTime, dt.ToShortDateString());
                dtCustmoneyBalance = _dbConnection.ExecuteProQuery(quryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dtCustmoneyBalance;
        }

        public DataTable GetCustShareBalance(DateTime dt)
        {
            DataTable dtCustShareBalance = null;
            string quryString = "";
            quryString = @"RptGetCustTodaysShareBalance_AdminAlternative";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@Date", SqlDbType.DateTime, dt.ToShortDateString());
                dtCustShareBalance = _dbConnection.ExecuteProQuery(quryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dtCustShareBalance;

        }
        
        public DataTable GnerateNewPaymentReview(DateTime fromDate, DateTime toDate, int isSorted, int isAccountsView)
        {

            DataTable dtPaymentReview = null;
            string quryString = "";

            quryString = @"RptNewPaymentReviewSorted_AdminAlternative";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@fromDate", SqlDbType.DateTime, fromDate.ToShortDateString());
                _dbConnection.AddParameter("@toDate", SqlDbType.DateTime, toDate.ToShortDateString());
                _dbConnection.AddParameter("@IsSorted", SqlDbType.Int, isSorted);
                _dbConnection.AddParameter("@IsAccountsView", SqlDbType.Int, isAccountsView);
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

        public void InsertAdminLog(string ReportName,string Reason,DateTime ExecutionDate)
        {
            CommonBAL commonBAL = new CommonBAL();
            //int slNo = commonBAL.GenerateID("SBP_Dashboard_Log", "Sl_No");

            //string queryString = "INSERT INTO SBP_Dashboard_Log(Sl_No,User_Name,Cust_Code,Log_time) Values(" + slNo + ",'" + GlobalVariableBO._userName + "','" + custCode + "',GETDATE())";
            string queryString = @"INSERT INTO SBP_Admin_Alternative_Report_Log
                                       ([ReportName]
                                       ,[Report_ExecutedBy_NonNumeric]
                                       ,[ReasonForExecution]
                                       ,[ExecutionDate]
                                       ,[Entry_Date]
                                       ,[Entry_By])
                                  VALUES
                                       ('"+ReportName+@"'
                                       ,'" + GlobalVariableBO._userName + @"'
                                       ,'" + Reason + @"'
                                       ,'" + ExecutionDate.ToShortDateString() + @"'
                                       ,Convert(Varchar(10),GETDATE(),111)
                                       ,'"+GlobalVariableBO._userName+@"'
                                 )";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(queryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            
        }
         
    }
}
