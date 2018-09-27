using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessAccessLayer.BO;
using DataAccessLayer;
using System.Data;

namespace BusinessAccessLayer.BAL
{
    public class SecerityInfoBAL
    {
        private DbConnection _dbConnection;
        public SecerityInfoBAL()
        {
           _dbConnection = new DbConnection();
        }
        public DataTable GetPermission()
        {
            string result = string.Empty;
            DataTable dataTable;
            dataTable = null;
            string queryString = "";
            queryString = "SELECT Previllize FROM [SBP_Database].[dbo].[SBP_Previllizes] WHERE Role_Name='" + GlobalVariableBO._role_Name + "' AND Previllize='" + "Transfer Not Allowed"  + "' OR Previllize='" + "EFT Not Allowed" + "'";
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
    }
}
