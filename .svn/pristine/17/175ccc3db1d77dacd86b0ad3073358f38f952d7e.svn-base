using System;
using System.Data;
using BusinessAccessLayer.BO;
using DataAccessLayer;

namespace BusinessAccessLayer.BAL
{
    public class WorkStationBAL
    {
         private DbConnection _dbConnection;
         public WorkStationBAL()
        {
            _dbConnection = new DbConnection();
        }

        public DataTable GetAllWorkStations()
        {
            DataTable dataTable;
            dataTable = null;
            string queryString = "";
            queryString ="SELECT WorkStation_Name as 'Work Station',SBP_WorkStation.Branch_ID,Branch_Name AS 'Branch Name'FROM SBP_WorkStation,SBP_Broker_Branch WHERE SBP_Broker_Branch.Branch_ID=SBP_WorkStation.Branch_ID ORDER BY WorkStation_Name";
            try
            {
                _dbConnection.ConnectDatabase();
                dataTable = _dbConnection.ExecuteQuery(queryString);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dataTable;
        }

        public bool CheckWorkStationDuplicate(string workStation)
        {
            DataTable dataTable;
            string queryString = "";
            queryString = "SELECT WorkStation_Name FROM SBP_WorkStation WHERE WorkStation_Name='" + workStation + "'";
            try
            {
                _dbConnection.ConnectDatabase();
                dataTable = _dbConnection.ExecuteQuery(queryString);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            if (dataTable.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        
        }

        public void Insert(WorkStationBO workStationBo)
        {
            string queryString = "";
            queryString = @"SBPSaveWorkStation";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@WorkStation", SqlDbType.VarChar, workStationBo.WorkStation);
                _dbConnection.AddParameter("@BranchId", SqlDbType.Int, workStationBo.BranchId);
                _dbConnection.AddParameter("@entryBy", SqlDbType.VarChar, GlobalVariableBO._userName);
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

        public void Update(WorkStationBO workStationBo, string workStationForUpdate)
        {
            string queryString = "";
            queryString = @"SBPUpdateWorkStation";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@WorkStation", SqlDbType.VarChar, workStationForUpdate);
                _dbConnection.AddParameter("@BranchId", SqlDbType.Int, workStationBo.BranchId);
                _dbConnection.AddParameter("@entryBy", SqlDbType.VarChar,GlobalVariableBO._userName);
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

        public DataTable GetWorkStationList()
        {
            string queryString = "SELECT WorkStation_Name FROM SBP_Workstation";
            DataTable data = new DataTable();

            try
            {
                _dbConnection.ConnectDatabase();
                data = _dbConnection.ExecuteQuery(queryString);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return data;
        }
    }
}
