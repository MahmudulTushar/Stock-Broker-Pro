using System;
using System.Data;
using DataAccessLayer;

namespace BusinessAccessLayer.BAL
{
    public class SummeryReportBAL
    {
         DbConnection _dbConnection;
         public SummeryReportBAL()
          {
            _dbConnection = new DbConnection();
          }
        
         public DataTable GetCustShareBalance()
         {
             DataTable dtCustShareBalance = null;
             string quryString = "";
             quryString = @"RptGetCustTodaysShareBalance";
             try
             {
                 _dbConnection.ConnectDatabase();
                 _dbConnection.ActiveStoredProcedure();
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

        public DataTable GetCustMoneyBalance()
        {
             DataTable dtCustmoneyBalance = null;
             string quryString = "";
             quryString = @"RptGetCustTodaysMoneyBalance";
             try
             {
                 _dbConnection.ConnectDatabase();
                 _dbConnection.ActiveStoredProcedure();
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

        public DataTable GetTodaysCustBalance()
        {
            DataTable dtCustTotalBalance = null;
            string quryString = "";
            quryString = @"RptGetCustTodaysTotalBalance";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
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
       
    }
}
