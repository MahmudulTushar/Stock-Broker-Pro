using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DataAccessLayer;

namespace BusinessAccessLayer.BAL
{
    public class ClientPayableRecounciliationStatementBAL
    {
        DbConnection _dbConnection;
        public ClientPayableRecounciliationStatementBAL()
        {
            _dbConnection = new DbConnection();
        }
        public DataTable GetStatement(DateTime RporotDate)
        {
            _dbConnection.TimeoutPeriod = 3000;

            DataTable dtStatement = null;
            string quryString = "";
            quryString = "SP_TaxCerfificate";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@dateFrom", SqlDbType.DateTime, RporotDate.ToShortDateString());
                dtStatement = _dbConnection.ExecuteProQuery(quryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dtStatement;

        }
    }
}
