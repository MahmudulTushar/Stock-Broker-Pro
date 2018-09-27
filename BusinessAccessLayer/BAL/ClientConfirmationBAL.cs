using System;
using System.Data;
using DataAccessLayer;

namespace BusinessAccessLayer.BAL
{
    public class ClientConfirmationBAL
    {        
          DbConnection _dbConnection;
          public ClientConfirmationBAL()
          {
            _dbConnection = new DbConnection();
          }
          public DataTable GetClientConfirmation(string custCode,DateTime transDate)
          {
              DataTable dtClientConf = null;
              string quryString = "";
              quryString = @"RptGetClientConfirmation";
              try
              {
                  _dbConnection.ConnectDatabase();
                  _dbConnection.ActiveStoredProcedure();
                  _dbConnection.AddParameter("@custCode", SqlDbType.NVarChar, custCode);
                  _dbConnection.AddParameter("@transDate", SqlDbType.DateTime, transDate.ToShortDateString());
                  dtClientConf = _dbConnection.ExecuteProQuery(quryString);
              }
              catch (Exception exception)
              {
                  throw exception;
              }
              finally
              {
                  _dbConnection.CloseDatabase();
              }
              return dtClientConf;


          }
          public DataTable GetClientBasicData(string custCode, DateTime transDate)
          {
              DataTable dtClientBasicData = null;
              string quryString = "";
              quryString = @"RptGetClientBasicData";
              try
              {
                  _dbConnection.ConnectDatabase();
                  _dbConnection.ActiveStoredProcedure();
                  _dbConnection.AddParameter("@custCode",SqlDbType.NVarChar,custCode);
                  _dbConnection.AddParameter("@transDate", SqlDbType.DateTime, transDate.ToShortDateString());
                  dtClientBasicData = _dbConnection.ExecuteProQuery(quryString);
              }
              catch (Exception exception)
              {
                  throw exception;
              }
              finally
              {
                  _dbConnection.CloseDatabase();
              }
              return dtClientBasicData;

          }

        public DataTable getClientConfirmationClientCopy(DateTime transDate)
        {
            DataTable dtClientConf = null;
            string quryString = "";
            quryString = @"RptGetClientConfirmationClientCopy";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@transDate", SqlDbType.DateTime, transDate.ToShortDateString());
                dtClientConf = _dbConnection.ExecuteProQuery(quryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dtClientConf;
        }

        public DataTable GetClientConfirmationOfficeCopy(DateTime transDate)
        {
            DataTable dtClientConf = null;
            string quryString = "";
            quryString = @"RptGetClientConfirmationOfficeCopy";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@transDate", SqlDbType.DateTime, transDate.ToShortDateString());
                dtClientConf = _dbConnection.ExecuteProQuery(quryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dtClientConf;
        }
    }
}
