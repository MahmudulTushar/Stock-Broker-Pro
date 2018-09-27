using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DataAccessLayer;

namespace BusinessAccessLayer.BAL
{
    public class CustReviewBalanceBAL
    {
        DbConnection _dbConnection;
        public CustReviewBalanceBAL()
        {
            _dbConnection = new DbConnection();
        }
      
        public DataTable GetCustPositiveBalance(int isSorted)
        {
            DataTable dtPossitiveBal = null;
            string quryString = "";
            quryString = @"RptNewGetCustPositiveBalance";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@IsSorted", SqlDbType.Int, isSorted);
                dtPossitiveBal = _dbConnection.ExecuteProQuery(quryString);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dtPossitiveBal;
            
        }

        public DataTable GetCustNegetiveBalance(int isSorted)
        {
            DataTable dtNegetiveBal = null;
            string quryString = "";
            quryString =  @"RptNewGetCustNegativeBalance";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@IsSorted", SqlDbType.Int, isSorted);
                dtNegetiveBal = _dbConnection.ExecuteProQuery(quryString);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dtNegetiveBal;
        }

        public DataTable GetCustNegetiveBalanceToday()
        {
            DataTable dtNegetiveBalToday = null;
            string quryString = "";
            quryString =@"RptGetCustNegetiveBalanceToday";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                dtNegetiveBalToday = _dbConnection.ExecuteProQuery(quryString);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dtNegetiveBalToday;

        }

        public DataTable GetCustNegSpecificBalance(DateTime fromDate,int isSorted)
        {

            DataTable dtNegSpecificBal = null;
            string quryString = "";
            quryString = @"RptNewGetCustNegSpecificBalance";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@date", SqlDbType.DateTime, fromDate.ToShortDateString());
                _dbConnection.AddParameter("@IsSorted", SqlDbType.Int, isSorted);
                dtNegSpecificBal = _dbConnection.ExecuteProQuery(quryString);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dtNegSpecificBal;
        }

        public DataTable GetCustNegBalanceTillSpecificDate(DateTime fromDate, int isSorted)
        {

            DataTable dtNegSpecificBal = null;
            string quryString = "";
            quryString = @"RptNewGetCustNegBalanceTillSpecificDate"; 
            //quryString = @"Rpt_CustomisedDSE_NewGetCustNegBalanceTillSpecificDate"; 
            
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@date", SqlDbType.DateTime, fromDate.ToShortDateString());
                _dbConnection.AddParameter("@IsSorted", SqlDbType.Int, isSorted);
                dtNegSpecificBal = _dbConnection.ExecuteProQuery(quryString);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dtNegSpecificBal;
        }

        public DataTable GetCustNegBalanceBetweenDateRang(DateTime fromDate, DateTime toDate, int isSorted)
        {

            DataTable dtNegSpecificBal = null;
            string quryString = "";
            quryString = @"RptGetCustNegBalanceBetweenDateRange";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@FromDate", SqlDbType.DateTime, fromDate.ToShortDateString());
                _dbConnection.AddParameter("@ToDate", SqlDbType.DateTime, toDate.ToShortDateString());
                _dbConnection.AddParameter("@IsSorted", SqlDbType.Int, isSorted);
                dtNegSpecificBal = _dbConnection.ExecuteProQuery(quryString);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dtNegSpecificBal;
        }

        public DataTable GetCustPosBalanceTillSpecificDate(DateTime fromDate, int isSorted)
        {

            DataTable dtNegSpecificBal = null;
            string quryString = "";
            quryString = @"RptNewGetCustPosBalanceTillSpecificDate";
            //quryString = @"Rpt_CustomisedDSE_NewGetCustPosBalanceTillSpecificDate";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@date", SqlDbType.DateTime, fromDate.ToShortDateString());
                _dbConnection.AddParameter("@IsSorted", SqlDbType.Int, isSorted);
                dtNegSpecificBal = _dbConnection.ExecuteProQuery(quryString);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dtNegSpecificBal;
        }

        public DataTable GetCustPosSpecificBalance(DateTime fromDate,int isSorted)
        {

            DataTable dtPosSpecificBal = null;
            string quryString = "";
            quryString = @"RptNewGetCustPosSpecificBalance";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@date", SqlDbType.DateTime, fromDate.ToShortDateString());
                _dbConnection.AddParameter("@isSorted", SqlDbType.Int, isSorted);
                dtPosSpecificBal = _dbConnection.ExecuteProQuery(quryString);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dtPosSpecificBal;
        }

        public DataTable CustomisedDSE_NewGetCustNegBalanceTillSpecificDate(DateTime fromDate, int isSorted)
        {

            DataTable dtNegSpecificBal = null;
            string quryString = "";
            quryString = @"Rpt_CustomisedDSE_NewGetCustNegBalanceTillSpecificDate";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@date", SqlDbType.DateTime, fromDate.ToShortDateString());
                _dbConnection.AddParameter("@IsSorted", SqlDbType.Int, isSorted);
                dtNegSpecificBal = _dbConnection.ExecuteProQuery(quryString);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dtNegSpecificBal;
        }

        public DataTable CustomisedDSE_NewGetCustPosBalanceTillSpecificDate(DateTime fromDate, int isSorted)
        {

            DataTable dtNegSpecificBal = null;
            string quryString = "";
            quryString = @"Rpt_CustomisedDSE_NewGetCustPosBalanceTillSpecificDate";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@date", SqlDbType.DateTime, fromDate.ToShortDateString());
                _dbConnection.AddParameter("@IsSorted", SqlDbType.Int, isSorted);
                dtNegSpecificBal = _dbConnection.ExecuteProQuery(quryString);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dtNegSpecificBal;
        }


    }
}
