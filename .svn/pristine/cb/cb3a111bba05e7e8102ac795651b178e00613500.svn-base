using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DataAccessLayer;
using BusinessAccessLayer.BO;
namespace BusinessAccessLayer.BAL
{
  public class ViewPrivillizeBAL
    {
        private DbConnection _dbConnection;
        public ViewPrivillizeBAL()
        {
            _dbConnection = new DbConnection();
        }
      public bool ViewPermission(string menuName)
      {
          bool isExist = true;
          DataTable data = new DataTable();

          string queryString = "SELECT "
                               + "[Role_Name]"
                               + ",[User_Name]"
                               + ",[MenuID] "
                               + "FROM [SBP_Database].[dbo].[SBP_PrevillizeMenuwise]"
                               + "WHERE USER_NAME='" + GlobalVariableBO._userName + "' AND "
                               + "Role_Name=(SELECT Role_Name FROM dbo.SBP_Users WHERE User_Name='" +
                               GlobalVariableBO._userName + "')AND "
                               + "MenuID=(SELECT MenuID FROM dbo.SBP_MenuList WHERE MenuName='" + menuName + "')";
          try
          {
              _dbConnection.ConnectDatabase();
              data = _dbConnection.ExecuteQuery(queryString);
              if(data.Rows.Count>0)
              {
                  isExist = false;
              }
          }
          catch (Exception)
          {
              
          }
          return isExist;
      }
    }
}
