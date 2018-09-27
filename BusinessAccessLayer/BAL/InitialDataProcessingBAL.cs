using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using DataAccessLayer;
using System.Data;

namespace BusinessAccessLayer.BAL
{
    public class InitialDataProcessingBAL
    {
        private DbConnection _dbConnection;

        public InitialDataProcessingBAL()
        {
            _dbConnection = new DbConnection();
            _dbConnection.TimeoutPeriod = 10000;
        }



        public void Web_Server_Starting_Mode()
        {
            string Query = string.Empty;
            Query = "UPDATE tbl_WebExportDT SET Status=0";
            _dbConnection.ConnectDatabase_SMSSender();
            _dbConnection.ExecuteNonQuery_SMSSender(Query);
            _dbConnection.CloseDatabase_SMSSender();
        }


        #region New Data Process (Rezaul Islam)

        public void Portfolio_Report_Send()
        {
            string queryString = @"EXECUTE Transaction_Base_Portfolio_Report;";

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

        public void DaySummaryDataCalculation(string calculationDate)
        {
            string query = @"SP_DaySammaryInformationInsert";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@InsertDate", SqlDbType.DateTime, calculationDate);
                _dbConnection.ExecuteProQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
        }

        public void ExecuteProcess_Accrude(DateTime fromDate, DateTime toDate)
        {
            string quryString = "";
            quryString = @"Interest_Process_Accrued";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@fromDate", SqlDbType.DateTime, fromDate);
                _dbConnection.AddParameter("@toDate", SqlDbType.DateTime, toDate);
                _dbConnection.ExecuteProQuery(quryString);
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

        public void New_ExecuteProcess()
        {
            string queryString = @"EXECUTE Process_accrued;";

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

        public void New_AutoExecuteProcess()
        {
            string queryString = @"EXECUTE Process_accrued_Auto;";

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

        #endregion

        public void ExecuteProcess()
        {
            string queryString = @"EXECUTE Process;";

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

        public void ExecuteDealer_AccountProcess()
        {
            string queryString = @"EXECUTE DEALERDB.dbo.Process;";

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
