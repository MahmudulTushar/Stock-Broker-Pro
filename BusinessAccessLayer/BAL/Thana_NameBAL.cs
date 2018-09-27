using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using BusinessAccessLayer.BO;
using System.Data;

namespace BusinessAccessLayer.BAL
{
   public class Thana_NameBAL
    {
        private DbConnection _dbConnection;
        public Thana_NameBAL()
        {
            _dbConnection = new DbConnection();
        }

        public DataTable GetGridData()
        {
            DataTable data = new DataTable();
            string query = @" SELECT [ID]
                              ,[Thana_Code]
                              ,[Thana_Name]
                              ,[Description]
                              ,[Entry_Date]
                              ,[Entry_By]
                          FROM dbo.SBP_Thana_Info";
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

        public void SaveThanaName(Thana_NameBO objBO)
        {

            string QueryString = "";
            QueryString = @"INSERT INTO SBP_Thana_Info
                            (
                              [Thana_Code]
                            , [Thana_Name]
                            , [Description]
                            , [Entry_Date]
                            , [Entry_By]
                            )
                            VALUES
                            ("
                          + objBO.Thana_Code
                          + ",'" + objBO.ThanaName + "'"
                          + ",'" + objBO.Thana_Description + "'"
                          + ",(CAST(FLOOR(CAST(GETDATE() AS FLOAT)) AS DATETIME))"
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

        public void UpdateThanaInfo(Thana_NameBO objBO, int thanaId)
        {

            string QueryString = "";
            string QueryStringBankBranchRoutingInfoUpdate = "";

            QueryString = @"UPDATE SBP_Thana_Info
                            SET
                              [Thana_Code]='" + objBO.Thana_Code + "'"
                            + ",[Thana_Name]='" + objBO.ThanaName + "'"
                            + ",[Description]='" + objBO.Thana_Description + "'"
                            + " WHERE ID=" + thanaId;
            QueryStringBankBranchRoutingInfoUpdate = @"UPDATE dbo.SBP_Bank_Branch_Routing_Info
                            SET
                              [Thana_Code]='" + objBO.Thana_Code + "'"
                + ",[Thana_Name]='" + objBO.ThanaName + "'"
                + " WHERE [Thana_ID]=" + thanaId;

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();
                _dbConnection.ExecuteNonQuery(QueryString);
                _dbConnection.ExecuteNonQuery(QueryStringBankBranchRoutingInfoUpdate);
                _dbConnection.Commit();
            }
            catch (Exception ex)
            {
                _dbConnection.Rollback();
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }

        }


        public void DeletebThanaName(int _thanaId)
        {
            string query = "DELETE FROM SBP_Thana_Info WHERE ID=" + _thanaId;
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
    }
}
