using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Linq;
using System.Text;
using DataAccessLayer;
using BusinessAccessLayer.BO;

namespace BusinessAccessLayer.BAL
{
   public class Bank_NameBAL
    {
        private DbConnection _dbConnection;
        public Bank_NameBAL()
        {
            _dbConnection = new DbConnection();
        }

        public DataTable GetGridData()
        {
            DataTable data = new DataTable();
            string query = @" SELECT [ID]
                              ,[Bank_Code]
                              ,[Bank_Name]
                              ,[Description]
                              ,[Entry_Date]
                              ,[Entry_By]
                          FROM SBP_Bank_Info";
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

        public void SaveBankName(Bank_NameBO objBO)
        {

            string QueryString = "";
            QueryString = @"INSERT INTO SBP_Bank_Info
                            (
                              [Bank_Code]
                            , [Bank_Name]
                            , [Description]
                            , [Entry_Date]
                            , [Entry_By]
                            )
                            VALUES
                            ("
                          + objBO.Bank_Code
                          + ",'" + objBO.BankName + "'"
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
        public void UpdateBankInfo(Bank_NameBO objBO,int bankId)
        {

            string QueryStringBankInfoUpdate = "";
            string QueryStringCustBankInfoUpdate = "";
            string QueryStringBankBranchRoutingInfoUpdate = "";
            QueryStringBankInfoUpdate = @"UPDATE dbo.SBP_Bank_Info
                            SET
                              [Bank_Code]='" + objBO.Bank_Code + "'"
                            + ",[Bank_Name]='" + objBO.BankName + "'"
                            + ",[Description]='" + objBO.Description + "'"
                            + " WHERE ID=" + bankId;

            QueryStringCustBankInfoUpdate = @"UPDATE dbo.SBP_Cust_Bank_Info
                            SET
                              [Bank_Name]='" + objBO.BankName + "'"
                            + " WHERE [Bank_ID]=" + bankId;

            QueryStringBankBranchRoutingInfoUpdate = @"UPDATE dbo.SBP_Bank_Branch_Routing_Info
                            SET
                              [Bank_Code]='" + objBO.Bank_Code + "'"
                            + ",[Bank_Name]='" + objBO.BankName + "'"
                            + " WHERE [Bank_ID]=" + bankId;
                            
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();
                _dbConnection.ExecuteNonQuery(QueryStringBankInfoUpdate);
                _dbConnection.ExecuteNonQuery(QueryStringCustBankInfoUpdate);
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

        public void DeletebBankName(int bankId)
        {
            string query = "DELETE FROM SBP_Bank_Info WHERE ID=" + bankId;
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
