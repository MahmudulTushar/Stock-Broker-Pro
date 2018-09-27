using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using BusinessAccessLayer.BO;
using System.Data;

namespace BusinessAccessLayer.BAL
{
   public class District_NameBAL
    {
        private DbConnection _dbConnection;
        public District_NameBAL()
        {
            _dbConnection = new DbConnection();
        }

        public DataTable GetGridData()
        {
            DataTable data = new DataTable();
            string query = @" SELECT [ID]
                              ,[District_Code]
                              ,[District_Name]
                              ,[Description]
                              ,[Entry_Date]
                              ,[Entry_By]
                          FROM dbo.SBP_District_Info";
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

        public void SaveDistrictName(District_NameBO objBO)
        {

            string QueryString = "";
            QueryString = @"INSERT INTO SBP_District_Info
                            (
                              [District_Code]
                            , [District_Name]
                            , [Description]
                            , [Entry_Date]
                            , [Entry_By]
                            )
                            VALUES
                            ("
                          + objBO.District_Code
                          + ",'" + objBO.DistrictName + "'"
                          + ",'" + objBO.District_Description + "'"
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

        public void UpdateDistrictInfo(District_NameBO objBO, int districtId)
        {

            string QueryString = "";
            string QueryStringBankBranchRoutingInfoUpdate = "";

            QueryString = @"UPDATE SBP_District_Info
                            SET
                              [District_Code]='" + objBO.District_Code + "'"
                            + ",[District_Name]='" + objBO.DistrictName + "'"
                            + ",[Description]='" + objBO.District_Description + "'"
                            + " WHERE ID=" + districtId;
            QueryStringBankBranchRoutingInfoUpdate = @"UPDATE dbo.SBP_Bank_Branch_Routing_Info
                            SET
                              [District_Code]='" + objBO.District_Code + "'"
                + ",[District_Name]='" + objBO.DistrictName + "'"
                + " WHERE [District_ID]=" + districtId;

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


        public void DeletebDistrictName(int _districtId)
        {
            string query = "DELETE FROM SBP_District_Info WHERE ID=" + _districtId;
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
