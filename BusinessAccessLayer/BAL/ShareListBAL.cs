using System;
using System.Data;
using BusinessAccessLayer.BO;
using DataAccessLayer;

namespace BusinessAccessLayer.BAL
{
    public class ShareListBAL
    {
        private DbConnection _dbConnection;

        public ShareListBAL()
        {
            _dbConnection = new DbConnection();
        }



        public DataTable GetUserIdInfo()
        {

            string queryString = "";
            DataTable dataTable = new DataTable();

            queryString ="SELECT UserID='All'"
                + " UNION SELECT  distinct UserID FROM SBP_Transactions";

            try
            {
                _dbConnection.ConnectDatabase();

                dataTable = _dbConnection.ExecuteQuery(queryString);

                return dataTable;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public DataTable GetShareInfo(ShareListBO shareBo)
        {

            string queryString = "";
            DataTable dataTable = new DataTable();
            queryString = @"RptGetShareInfo";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@fromDate", SqlDbType.DateTime, shareBo.DtFrom.ToShortDateString());
                _dbConnection.AddParameter("@toDate", SqlDbType.DateTime, shareBo.DtTo.ToShortDateString());
                _dbConnection.AddParameter("@userID", SqlDbType.NVarChar, shareBo.WorkStation);
                dataTable = _dbConnection.ExecuteProQuery(queryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dataTable;
        }
        public DataTable GetParticipatoryInfo()
        {

            string queryString = "";
            DataTable dataTable = new DataTable();

            queryString = "SELECT  Name,Branch_Name,Address "
            + "FROM SBP_Broker_Info,SBP_Broker_Branch "
            + "WHERE Branch_ID=1";

            try
            {
                _dbConnection.ConnectDatabase();

                dataTable = _dbConnection.ExecuteQuery(queryString);

                return dataTable;
            }
            catch (Exception)
            {

                throw;
            }

        }


    }
}
