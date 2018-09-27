using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessAccessLayer.BO;
using DataAccessLayer;

namespace BusinessAccessLayer.BAL
{
   public class RoleWithUserPrevillizeBAL
    {
        private DbConnection _dbConnection;
        public RoleWithUserPrevillizeBAL()
        {
            _dbConnection = new DbConnection();
        }

        public List<bool> IsExists(List<string> username, string rolename, int menuId)
        {
            DataTable data = new DataTable();
            string queryString = "";
            List<bool> isExist = new List<bool>();

            try
            {
                _dbConnection.ConnectDatabase();
                foreach (string userName in username)
                {
                    queryString = "SELECT * FROM dbo.SBP_PrevillizeMenuwise WHERE User_Name='" + userName +
                                  "' AND Role_Name='" + rolename + "' AND MenuID=" + menuId;

                    data = _dbConnection.ExecuteQuery(queryString);

                    if (data.Rows.Count > 0)
                    {
                        isExist.Add(true);
                    }

                    else
                    {
                        isExist.Add(false);
                    }
                }
            }
            catch (Exception)
            {


            }

            finally
            {
                _dbConnection.CloseDatabase();
            }
            return isExist;
        }
        public void SaveData(string roleName, int menuid, string username)
        {
            try
            {

                string queryString = "INSERT INTO [SBP_Database].[dbo].[SBP_PrevillizeMenuwise]([Role_Name], [User_Name], [MenuID]) "
                                     + " VALUES('" + roleName + "','" + username + "'," + menuid + ")";

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

    }
}
