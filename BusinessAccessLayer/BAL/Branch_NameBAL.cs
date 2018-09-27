using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using BusinessAccessLayer.BO;
using System.Data;

namespace BusinessAccessLayer.BAL
{
    public class Branch_NameBAL
    {
        private DbConnection _dbConnection;
        public Branch_NameBAL()
        {
            _dbConnection = new DbConnection();
        }

        public DataTable GetGridData()
        {
            DataTable data = new DataTable();
            string query = @" SELECT [ID]
                              ,[Branch_Code]
                              ,[Branch_Name]
                              ,[Description]
                              ,[Entry_Date]
                              ,[Entry_By]
                          FROM SBP_Branch_Info";
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

        public void SaveBranchName(Branch_NameBO objBO)
        {

            string QueryString = "";
            QueryString = @"INSERT INTO SBP_Branch_Info
                            (
                              [Branch_Code]
                            , [Branch_Name]
                            , [Description]
                            , [Entry_Date]
                            , [Entry_By]
                            )
                            VALUES
                            ("
                          + objBO.Branch_Code
                          + ",'" + objBO.BranchName + "'"
                          + ",'" + objBO.Description + "'"
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
        public void UpdateBranchInfo(Branch_NameBO objBO, int branchId)
        {

            string QueryString = "";
            string QueryStringCustBranchInfoUpdate = "";
            string QueryStringBankBranchRoutingInfoUpdate = "";

            QueryString = @"UPDATE SBP_Branch_Info
                            SET
                              [Branch_Code]='" + objBO.Branch_Code + "'"
                            + ",[Branch_Name]='" + objBO.BranchName + "'"
                            + ",[Description]='" + objBO.Description + "'"
                            + " WHERE ID=" + branchId;

            QueryStringCustBranchInfoUpdate = @"UPDATE dbo.SBP_Cust_Bank_Info
                            SET
                              [Branch_Name]='" + objBO.BranchName + "'"
                + " WHERE [Branch_ID]=" + branchId;

            QueryStringBankBranchRoutingInfoUpdate = @"UPDATE dbo.SBP_Bank_Branch_Routing_Info
                            SET
                              [Branch_Code]='" + objBO.Branch_Code + "'"
                            + ",[Branch_Name]='" + objBO.BranchName + "'"
                            + " WHERE [Branch_ID]=" + branchId;

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();
                _dbConnection.ExecuteNonQuery(QueryString);
                _dbConnection.ExecuteNonQuery(QueryStringCustBranchInfoUpdate);
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

        public void DeletebBranchName(int _branchId)
        {
            string query = "DELETE FROM SBP_Branch_Info WHERE ID=" + _branchId;
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
