using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessAccessLayer.BO;
using DataAccessLayer;

namespace BusinessAccessLayer.BAL
{
    public class PrevillizeManagementBAL
    {

        private DbConnection _dbConnection;
        public PrevillizeManagementBAL()
        {
            _dbConnection = new DbConnection();
        }

        //public DataTable GetGridData()
        //{
        //    DataTable dataTable;
        //    string queryString = "";
        //   // queryString = "SELECT Role_Name as 'Role Name',Description,Creat_Date AS 'Creat Date' FROM SBP_Roles";
        //    try
        //    {
        //        _dbConnection.ConnectDatabase();
        //        dataTable = _dbConnection.ExecuteQuery(queryString);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    return dataTable;
        //}

        public void Insert(string roleName, List<string> previllizeList)
        {

            string roleQueryStringIns = "";
            string roleQueryStringDel = "";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();
                roleQueryStringDel = "DELETE FROM SBP_Previllizes WHERE Role_Name='" + roleName + "'";
                _dbConnection.ExecuteNonQuery(roleQueryStringDel);
                for (int i = 0; i < previllizeList.Count; i++)
                {
                    roleQueryStringIns = "INSERT INTO SBP_Previllizes(Role_Name,Previllize,Entry_Date,Entry_By)" + " Values('" + roleName + "','" + previllizeList[i] + "',GETDATE(),'" + GlobalVariableBO._userName + "')";
                    _dbConnection.ExecuteNonQuery(roleQueryStringIns);
                }
                _dbConnection.Commit();
            }
            catch (Exception)
            {
                _dbConnection.Rollback();
                throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
        }
        public DataTable GetAllPrevillize(string roleName)
        {
            DataTable dataTable;
            string queryString = "";
            queryString = "SELECT Previllize FROM SBP_Previllizes WHERE Role_Name='" + roleName + "'";
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

        public DataTable GetUserPrevillize()
        {
            DataTable dataTable;
            dataTable = null;
            string queryString = "";
            queryString = "SELECT Previllize FROM SBP_Previllizes WHERE Role_Name= (SELECT Role_Name FROM SBP_Users WHERE User_Name ='" + GlobalVariableBO._userName + "')";
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
        public DataTable GetRoleWisePrevillize()
        {
            DataTable dataTable;
            dataTable = null;
            string queryString = "";
            queryString = "SELECT Previllize FROM SBP_Previllizes WHERE Role_Name= (SELECT Role_Name FROM SBP_Users WHERE User_Name ='" + GlobalVariableBO._userName + "')";
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

        public DataTable GetOnlyRoleWisePrevillize()
        {
            DataTable dataTable;
            dataTable = null;
            string queryString = "";
            queryString = @"SELECT [UserName],Previllize FROM SBP_Previllizes 
                            WHERE Role_Name= (SELECT Role_Name FROM SBP_Users WHERE User_Name ='" + GlobalVariableBO._userName +"')"
                         +" AND [UserName]=''";
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

        public DataTable GetAllUserAssignedForCurrentRole()
        {
            DataTable dataTable;
            dataTable = null;
            string queryString = "";
            queryString =
                @"SELECT 
                             [UserName]
                            ,[Previllize]
                            FROM SBP_Previllizes 
                            WHERE Role_Name=
                            (SELECT Role_Name FROM SBP_Users WHERE User_Name ='" +
                GlobalVariableBO._userName + "'"
                + " AND [UserName]<>'" + GlobalVariableBO._userName + "') AND [UserName]<>''";
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


        public DataTable GetAssignedPrevillize()
        {
            DataTable dataTable;
            dataTable = null;
            string queryString = "";
            queryString = "SELECT "
                        + "[UserName] "
                        + ", [Role_Name]"
                        + ", [PrevillizeID]"
                        + ", [Previllize]"
                        + " FROM SBP_Previllizes"
                        + " WHERE UserName <>'' AND Role_Name=(SELECT [Role_Name] FROM [SBP_Users] WHERE User_Name='" + GlobalVariableBO._userName + "')";
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

        public DataTable GetAssignedPrevillizeByUserName(string userName)
        {
            DataTable dataTable;
            dataTable = null;
            string queryString = "";
            queryString = "SELECT "
                        + "[UserName] "
                        + ", [Role_Name]"
                        + ", [PrevillizeID]"
                        + ", [Previllize]"
                        + " FROM SBP_Previllizes"
                        + " WHERE UserName ='" + userName + "' AND Role_Name=(SELECT [Role_Name] FROM [SBP_Users] WHERE User_Name='" + userName + "')";
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

        public int GetDashboardUserPrevillize()
        {
            DataTable dataTable;
            dataTable = null;
            string queryString = "";
            queryString = "SELECT Previllize FROM SBP_Previllizes WHERE Role_Name= (SELECT Role_Name FROM SBP_Users WHERE User_Name ='" + GlobalVariableBO._userName + "') AND Previllize='Dashboard All'";
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
            if (dataTable.Rows.Count > 0)
                return 1;
            else
            {
                return 0;
            }

        }


        //public DataTable GetGridData()
        //{
        //    DataTable dataTable;
        //    dataTable = null;
        //    string queryString = "";
        //    queryString = "";
        //    try
        //    {
        //        _dbConnection.ConnectDatabase();
        //        dataTable = _dbConnection.ExecuteQuery(queryString);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        _dbConnection.CloseDatabase();
        //    }
        //    return dataTable;

        //}

        public DataTable GetPrevillizeList(string roleName)
        {
          //  string queryString = "SELECT PrevillizeID,PrevillizeName FROM SBP_PrevillizeInfo";
            string queryString = " SELECT  "
                                 + " prvInfo.PrevillizeID AS PrevillizeID "

                                 + " ,(  "
                                 + "    CASE "
                                 + " 	 WHEN prvls.Role_Name is NULL  "
                                 + " 	 THEN 0    "
                                 + " 	 ELSE 1  "
                                 + "    END  "
                                 + "  )AS [Select]  "
                                 + " ,prvInfo.PrevillizeName AS PrevillizeName "
                                 + "  FROM  	( "
                                 + "        	 SELECT c.* "
                                 + "         	FROM dbo.SBP_PrevillizeInfo AS c  "
                                 + "       	)AS prvInfo        "
                                 + " 	LEFT OUTER JOIN  "
                                 + " 	(           "
                                 + " 	 	SELECT t.Role_Name, t.PrevillizeID, t.Previllize "         	 	
		                         +         " FROM dbo.SBP_Previllizes AS t "  	 	
		                         +         " WHERE t.[Role_Name]='"+ roleName +"'"
		                         +         " GROUP BY Role_Name,PrevillizeID,Previllize "
                                 +         " ) AS prvls  "
                                 + "  ON  prvInfo.PrevillizeID=prvls.PrevillizeID "
                                 +" ORDER BY prvInfo.PrevillizeName";
 
            DataTable data = new DataTable();

            try
            {
                _dbConnection.ConnectDatabase();
                data = _dbConnection.ExecuteQuery(queryString);
            }
            catch (Exception)
            {

                throw;
            }

            finally
            {
                _dbConnection.CloseDatabase();
            }

            return data;
        }

        public void InsertRoleInfo(string userName, string roleName, int prevId, string prevName)
        {

            string roleQueryStringIns = "";
            try
            {
                _dbConnection.ConnectDatabase();
                roleQueryStringIns = "INSERT INTO [SBP_Previllizes] "
                                     + "([UserName]"
                                     + ", [Role_Name]"
                                     + ", [PrevillizeID]"
                                     + ", [Previllize]"
                                     + ", [Entry_Date]"
                                     + ", [Entry_By]"
                                     + ")VALUES ("
                                     + "'" + userName + "'"
                                     + ",'" + roleName + "'"
                                     + "," + prevId
                                     + ",'" + prevName + "'"
                                     + ",'" + DateTime.Now.ToShortDateString() + "'"
                                     + ",'" + GlobalVariableBO._userName + "')";

                _dbConnection.ExecuteNonQuery(roleQueryStringIns);
            }
            catch (Exception ex)
            {
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
        }
        public void InsertRoleWithUserInfo(string username, string roleName, int prevId, string prevName)
        {

            string roleQueryStringIns = "";
            try
            {
                _dbConnection.ConnectDatabase();
                roleQueryStringIns = "INSERT INTO [SBP_Previllizes] "
                                     + "([UserName]"
                                     + ", [Role_Name]"
                                     + ", [PrevillizeID]"
                                     + ", [Previllize]"
                                     + ", [Entry_Date]"
                                     + ", [Entry_By]"
                                     + ")VALUES ("
                                     + "'" + username + "'"
                                     + ",'" + roleName + "'"
                                     + "," + prevId
                                     + ",'" + prevName + "'"
                                     + ",'" + DateTime.Now.ToShortDateString() + "'"
                                     + ",'" + GlobalVariableBO._userName + "')";

                _dbConnection.ExecuteNonQuery(roleQueryStringIns);
            }
            catch (Exception ex)
            {
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
        }

        public void DeleteRoleInfo(string roleName, int prevId, string prevName)
        {

            string roleQueryStringIns = "";
            try
            {
                _dbConnection.ConnectDatabase();
                roleQueryStringIns = "DELETE FROM SBP_Previllizes WHERE "
                                     //+ " WHERE UserName='" + userName + "'"
                                     + " Role_Name ='" + roleName + "'"
                                     + " AND PrevillizeID=" + prevId
                                     + " AND Previllize='" + prevName + "'";
                _dbConnection.ExecuteNonQuery(roleQueryStringIns);
            }
            catch (Exception ex)
            {
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
        }
        public void DeleteRoleWithUser(List<string> username, string roleName, int prevId, string prevName)
        {

            string roleQueryStringIns = "";
            try
            {
                _dbConnection.ConnectDatabase();
                foreach (string userName in username)
                {
                    roleQueryStringIns = "DELETE FROM SBP_Previllizes "
                                         + " WHERE UserName='" + userName + "'"
                                         + " AND Role_Name ='" + roleName + "'"
                                         + " AND PrevillizeID=" + prevId
                                         + " AND Previllize='" + prevName + "'";
                    _dbConnection.ExecuteNonQuery(roleQueryStringIns);
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
        }

        public List<bool> IsExists(List<string> username, string rolename, int prevId, string prevName)
        {
            DataTable data = new DataTable();
            string queryString = "";
            List<bool> isExist = new List<bool>();

            try
            {
                _dbConnection.ConnectDatabase();
                foreach (string userName in username)
                {
                    queryString = "SELECT * FROM [SBP_Previllizes]"
                                + " WHERE UserName ='" + userName + "' AND "
                                + " Role_Name='" + rolename + "' AND "
                                + " PrevillizeID=" + prevId + " AND "
                                + " Previllize='" + prevName + "'";

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
        public DataTable SearchBeforeInsert(string rolename, string prevName)
        {
            DataTable data = new DataTable();
            string queryString = "";

            try
            {
                _dbConnection.ConnectDatabase();
                queryString = "SELECT * FROM [SBP_Previllizes]"
                            + " WHERE Role_Name ='" + rolename + "' AND "
                            + " Previllize='" + prevName + "'";

                data = _dbConnection.ExecuteQuery(queryString);

            }
            catch (Exception)
            {


            }

            finally
            {
                _dbConnection.CloseDatabase();
            }
            return data;
        }


        public DataTable LoadDataForGrid(List<string> username, string roleName, int prevId, string prevName)
        {
            DataTable data = new DataTable();
            DataTable finalTable = new DataTable();
            bool isColoned = false;

            string QueryString = "";
            try
            {
                _dbConnection.ConnectDatabase();
                if (username.Count > 0)
                {
                    foreach (string userName in username)
                    {
                        QueryString = "SELECT *  FROM dbo.SBP_Previllizes WHERE UserName='" + userName +
                                             "' AND Role_Name ='" + roleName + "' AND PrevillizeID=" + prevId +
                                             " AND Previllize='" + prevName + "'";

                        data = _dbConnection.ExecuteQuery(QueryString);
                        if (isColoned == false)
                        {
                            finalTable = data.Clone();
                            isColoned = true;
                        }

                        if (data.Rows.Count > 0)
                        {
                            for (int i = 0; i < data.Rows.Count; i++)
                            {
                                finalTable.ImportRow(data.Rows[i]);
                            }

                        }

                    }
                }
                else
                {
                    QueryString = "SELECT *  FROM dbo.SBP_Previllizes WHERE UserName='" +
                     "' AND Role_Name ='" + roleName + "' AND PrevillizeID=" + prevId +
                     " AND Previllize='" + prevName + "'";

                    data = _dbConnection.ExecuteQuery(QueryString);
                    finalTable = data;
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return finalTable;
        }
        public DataTable LoadDataForGrid(string roleName, int prevId, string prevName)
        {
            DataTable data = new DataTable();
            DataTable finalTable = new DataTable();
            bool isColoned = false;

            string QueryString = "";
            try
            {
                _dbConnection.ConnectDatabase();
                QueryString = "SELECT *  FROM dbo.SBP_Previllizes WHERE " +
                 "Role_Name ='" + roleName + "' AND PrevillizeID=" + prevId +
                 " AND Previllize='" + prevName + "'";

                data = _dbConnection.ExecuteQuery(QueryString);
                finalTable = data;

            }
            catch (Exception ex)
            {
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return finalTable;
        }


        public void DeleteWithInsertIndicator(string userName, string roleName, string prevName)
        {

            string DeleteWithInsertIndicator = "";
            try
            {
                _dbConnection.ConnectDatabase();
                DeleteWithInsertIndicator = "DELETE FROM SBP_Previllizes "
                                         + " WHERE UserName='" + userName + "'"
                                         + " AND Role_Name='" + roleName + "'"
                                         + " AND Previllize='" + prevName + "'";
                _dbConnection.ExecuteNonQuery(DeleteWithInsertIndicator);
            }
            catch (Exception ex)
            {
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
        }

        public void DeleteFromPrevilizes(string userName, string roleName,int prevID, string prevName)
        {

            string DeleteWithDeleteIndicator = "";
            try
            {
                _dbConnection.ConnectDatabase();

                DeleteWithDeleteIndicator = "DELETE FROM SBP_Previllizes "
                                         + " WHERE UserName='" + userName + "'"
                                         + " AND Role_Name='" + roleName + "'"
                                         + " AND PrevillizeID=" + prevID + ""
                                         + " AND Previllize='" + prevName + "'";
                _dbConnection.ExecuteNonQuery(DeleteWithDeleteIndicator);
            }
            catch (Exception ex)
            {
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }


        }

        public void InsertIntoPrevillize(string username, string roleName, int prevId, string prevName)
        {

            string roleQueryStringIns = "";
            try
            {
                _dbConnection.ConnectDatabase();
                roleQueryStringIns = "INSERT INTO [SBP_Previllizes] "
                                     + "([UserName]"
                                     + ", [Role_Name]"
                                     + ", [PrevillizeID]"
                                     + ", [Previllize]"
                                     + ", [Entry_Date]"
                                     + ", [Entry_By]"
                                     + ")VALUES ("
                                     + "'" + username + "'"
                                     + ",'" + roleName + "'"
                                     + "," + prevId
                                     + ",'" + prevName + "'"
                                     + ",'" + DateTime.Now.ToShortDateString() + "'"
                                     + ",'" + GlobalVariableBO._userName + "')";

                _dbConnection.ExecuteNonQuery(roleQueryStringIns);
            }
            catch (Exception ex)
            {
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
        }

        public bool IsExistRoleAndPrevillize(string rolename, string prevName,int prevID)
        {
            DataTable data = new DataTable();
            string queryString = "";
            bool result = false;

            try
            {
                _dbConnection.ConnectDatabase();
                queryString = "SELECT * FROM [SBP_Previllizes]"
                            + " WHERE Role_Name ='" + rolename + "'"
                            + " AND ISNULL(UserName,'')=''"
                            + "AND Previllize='" + prevName + "'"
                            + "AND PrevillizeID=" + prevID;

                data = _dbConnection.ExecuteQuery(queryString);
                if (data.Rows.Count > 0)
                {
                    result = true;
                }

            }
            catch (Exception)
            {


            }

            finally
            {
                _dbConnection.CloseDatabase();
            }
            return result;
        }


        public bool IsExistRolePrevillizeAndUserName(string rolename, string prevName,int prevID)
        {
            DataTable data = new DataTable();
            string queryString = "";
            bool result = false;

            try
            {
                _dbConnection.ConnectDatabase();
                queryString = "SELECT * FROM [SBP_Previllizes]"
                            + " WHERE Role_Name ='" + rolename + "'"
                            + " AND ISNULL(UserName,'')<>''"
                            + " AND Previllize='" + prevName + "'"
                            + " AND PrevillizeID=" + prevID ;

                data = _dbConnection.ExecuteQuery(queryString);
                if (data.Rows.Count > 0)
                {
                    result = true;
                }

            }
            catch (Exception)
            {


            }

            finally
            {
                _dbConnection.CloseDatabase();
            }
            return result;
        }

        public bool IsExists(string userName, string rolename, int prevId, string prevName)
        {
            DataTable data = new DataTable();
            string queryString = "";
            bool isExist =false;

            try
            {
                _dbConnection.ConnectDatabase();
                    queryString = "SELECT * FROM [SBP_Previllizes]"
                                + " WHERE UserName ='" + userName + "'"
                                + " AND Role_Name='" + rolename + "'"
                                + " AND PrevillizeID=" + prevId 
                                + " AND Previllize='" + prevName + "'";

                    data = _dbConnection.ExecuteQuery(queryString);

                    if (data.Rows.Count > 0)
                    {
                        isExist=true;
                    }

                    else
                    {
                        isExist=false;
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

    }
}
