using System;
using System.Data;
using BusinessAccessLayer.BO;
using DataAccessLayer;

namespace BusinessAccessLayer.BAL
{
    public class RoleManagementBAL
    {
        private DbConnection _dbConnection;
        public RoleManagementBAL()
        {
            _dbConnection = new DbConnection();
        }
        public void Insert(RoleManagementBO roleManagementBo)
        {
            
            string roleQueryString = "";
            roleQueryString =@"SBPSaveRoleInfo";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@RoleName", SqlDbType.NVarChar, roleManagementBo.RoleName);
                _dbConnection.AddParameter("@Description", SqlDbType.NVarChar, roleManagementBo.Description);
                _dbConnection.AddParameter("@CreationDate", SqlDbType.DateTime, roleManagementBo.CreationDate.ToShortDateString());
               _dbConnection.AddParameter("@entryBy", SqlDbType.VarChar,GlobalVariableBO._userName);
               _dbConnection.ExecuteNonQuery(roleQueryString);
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
       

        public DataTable GetGridData()
        {
            DataTable dataTable;
            string queryString = "";
            queryString = "SELECT Role_Name as 'Role Name',Description,Creat_Date AS 'Create Date' FROM SBP_Roles";
            try
            {
                _dbConnection.ConnectDatabase();
                dataTable = _dbConnection.ExecuteQuery(queryString);
            }
            catch (Exception)
            {
                throw;
            }
            return dataTable;
        }

        public void DeleteToRoleName(string RoleName)
        {
            string queryString = "DELETE FROM SBP_Roles WHERE Role_Name='" + RoleName + "'";

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(queryString);
            }
            catch (Exception)
            {
                
                throw;
            }

            finally
            {
                _dbConnection.CloseDatabase();
            }
        }
        public void Update(RoleManagementBO roleManagementBo)
        {
            string queryStringPrevillize="";
            queryStringPrevillize = @"SBPUpdateRoleInfo";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@RoleName", SqlDbType.NVarChar, roleManagementBo.RoleName);
                _dbConnection.AddParameter("@Description", SqlDbType.NVarChar, roleManagementBo.Description);
                _dbConnection.AddParameter("@CreationDate", SqlDbType.DateTime, roleManagementBo.CreationDate.ToShortDateString());
                _dbConnection.AddParameter("@entryBy", SqlDbType.VarChar, GlobalVariableBO._userName);
                _dbConnection.ExecuteNonQuery(queryStringPrevillize);
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
    }
}
