using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessAccessLayer.BO;
using DataAccessLayer;
using System.Data;

namespace BusinessAccessLayer.BAL
{
   public class Process_ListBAL
    {
        private DbConnection _dbConnection;
        public Process_ListBAL()
         {
             _dbConnection = new DbConnection();
         }
        public void SaveProcess_ListData(Process_ListBO objBO)
        {

            string QueryString = "";
            QueryString = @"INSERT INTO SBP_Process_List
                            (
                            [Name]
                            , [Description]
                            , [Entry_Date]
                            , [Entry_By]
                            )
                            VALUES
                            ("
                          + "'" + objBO.Name + "'"
                          + ",'" + objBO.Description + "'"
                          + ",'" + objBO.EntryDate + "'"
                          + ",'" + GlobalVariableBO._userName + "'"
                          + ")";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(QueryString);
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
        public void UpdateProcess_ListData(Process_ListBO objBO)
        {
            string query =
                    @"UPDATE SBP_Process_List
                    SET 
                    [Name] ='" + objBO.Name + "'"
                + ",[Description] = '" + objBO.Description + "'"
                + ",[Entry_Date] = '" + objBO.EntryDate + "'"
                + ",[Entry_By] = '" + GlobalVariableBO._userName + "'"
                + " WHERE ID=" + objBO.Id;
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(query);
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
        public void DeleteProcess_ListData(int processId)
        {
            string query = "DELETE FROM SBP_Process_List WHERE ID=" + processId;
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(query);
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
        public DataTable GetGridData()
        {
            DataTable data = new DataTable();
            string query = @" SELECT
                              ID
                            , [Name]
                            , [Description]
                            , [Entry_Date] AS 'Entry Date'
                            , [Entry_By] AS 'Entry By'
                            FROM SBP_Process_List";
            try
            {
                _dbConnection.ConnectDatabase();
                data = _dbConnection.ExecuteQuery(query);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return data;
        }
       public DataTable  GetPorcessDataByProcessId(int _processId)
       {
           DataTable data = new DataTable();
           string query = @" SELECT
                              Name
                              ,[Description]
                              ,Entry_Date
                              FROM dbo.SBP_Process_List
                              WHERE ID="+_processId;
           try
           {
               _dbConnection.ConnectDatabase();
               data = _dbConnection.ExecuteQuery(query);
           }
           catch (Exception ex)
           {

               throw ex;
           }
           finally
           {
               _dbConnection.CloseDatabase();
           }
           return data;
       }
    }
}
