using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessAccessLayer.BO;
using DataAccessLayer;
using System.Data;

namespace BusinessAccessLayer.BAL
{
    public class CashBackSessionBAL
    {
        private DbConnection _dbConnection;
        public CashBackSessionBAL()
         {
             _dbConnection = new DbConnection();
         }
        public void SaveCashBackSessionData(CashBackSessionBO objBO)
        {

            string QueryString = "";
            QueryString = @"INSERT INTO SBP_Cashback_Session
                            (
                            [Name]
                            , [Description]
                            , [Session_Start_Date]
                            , [Session_End_Date]
                            , [Remarks]
                            , [Entry_Date]
                            , [Entry_By]
                            , [IsProcessed]
                            )
                            VALUES
                            ("
                          + "'" + objBO.Name + "'"
                          + ",'" + objBO.Description + "'"
                          + ",'" + objBO.SessionStartDate + "'"
                          + ",'" + objBO.SessionEndDate + "'"
                          + ",'" + objBO.Remarks + "'"
                          + ",'" + objBO.EntryDate.ToShortDateString() + "'"
                          + ",'" + GlobalVariableBO._userName + "'"
                          + "," + objBO.IsProcessed
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
        public void UpdateCashBackSessionData(int sessionId, CashBackSessionBO objBO)
        {
            string query =
                @"UPDATE SBP_Cashback_Session
                         SET 
                             [Name] ='" +
                objBO.Name + "'"
                + ",[Description] = '" + objBO.Description + "'"
                + ",[Session_Start_Date] = '" + objBO.SessionStartDate + "'"
                + ",[Session_End_Date] = '" + objBO.SessionEndDate + "'"
                + ",[Remarks] = '" + objBO.Remarks + "'"
                + ",[Entry_Date] = '" + objBO.EntryDate + "'"
                + ",[Entry_By] = '" + GlobalVariableBO._userName + "'"
                + " WHERE ID=" + sessionId;
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(query);
            }
            catch(Exception ex )
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
        }
        public void DeleteCashBackSessionData(int sessionId)
        {
            string query = "DELETE FROM SBP_Cashback_Session WHERE ID="+sessionId;
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
            DataTable data=new DataTable();
            string query = @" SELECT
                              ID
                            , [Name]
                            , [Description]
                            , [Session_Start_Date] AS 'Start Date'
                            , [Session_End_Date] AS 'End Date'
                            , [Remarks]
                            , [Entry_Date] AS 'Entry Date'
                            ,
                            CASE
                            WHEN IsProcessed=0 THEN 'Pending'
                            WHEN IsProcessed=1 THEN 'Processed'
                            END AS 'Status'
                            , [Entry_By] AS 'Entry By'
                            FROM SBP_Cashback_Session
                            ORDER BY Session_Start_Date DESC";
            try
            {
                _dbConnection.ConnectDatabase();
                data = _dbConnection.ExecuteQuery(query);
            }
            catch (Exception ex )
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
