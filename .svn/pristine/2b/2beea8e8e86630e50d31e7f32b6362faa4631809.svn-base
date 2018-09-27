using System;
using System.Data;
using BusinessAccessLayer.BO;
using DataAccessLayer;
using System.Collections.Generic;

namespace BusinessAccessLayer.BAL
{
    public class UserManagementBAL
    {
        private DbConnection _dbConnection;

        public UserManagementBAL()
        {
            _dbConnection = new DbConnection();
        }
        public void Insert(UserManagementBO userBO)
        {
            string userQueryString = "";
            userQueryString = @"SBPSaveUserInfo";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@userName", SqlDbType.NVarChar, userBO.UserName);
                _dbConnection.AddParameter("@roleName", SqlDbType.NVarChar, userBO.RoleName);
                _dbConnection.AddParameter("@password", SqlDbType.NVarChar, userBO.Password);
                _dbConnection.AddParameter("@name", SqlDbType.VarChar, userBO.Name);
                _dbConnection.AddParameter("@address", SqlDbType.VarChar, userBO.Address);
                _dbConnection.AddParameter("@contact", SqlDbType.VarChar, userBO.ContactNo);
                _dbConnection.AddParameter("@remark", SqlDbType.VarChar, userBO.Remarks);
                _dbConnection.AddParameter("@isActive", SqlDbType.Bit, userBO.IsActive);
                _dbConnection.AddParameter("@branchID", SqlDbType.Int, userBO.BranchId);
                _dbConnection.AddParameter("@entryBy", SqlDbType.VarChar, GlobalVariableBO._userName);
                _dbConnection.AddParameter("@employeeCode",SqlDbType.VarChar,userBO.EmployeeCode);
                _dbConnection.ExecuteNonQuery(userQueryString);
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

        public bool CheckUserDuplicate(string userName)
        {
            DataTable dataTable;
            string queryString = "";
            queryString = "SELECT User_Name FROM SBP_Users WHERE User_Name='" + userName + "'";
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
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public DataTable GetGridData()
        {
            DataTable dataTable;
            string queryString = "";
            queryString = "SELECT U.User_Name as 'User Name',Password,U.Role_Name as 'Role Name',Branch_Name as 'Branch',Name,U.Address,Contact_No as 'Contact No.',Remarks,CASE WHEN(U.IS_Active=1) THEN 'Active' ELSE 'Closed' END as 'Status', U.Branch_ID,U.EmployeeCode FROM SBP_Users U,SBP_Broker_Branch B WHERE  U.Branch_ID=B.Branch_ID and User_Name!='" + GlobalVariableBO._userName + "'";
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

        public void DeleteUserInfo(string userName)
        {
            string queryString = "DELETE FROM SBP_Users WHERE User_Name='" + userName + "'";

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

        public void Update(UserManagementBO userBO)
        {
            string queryStringUser = "";
            queryStringUser = @"SBPUpdateUserInfo";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@userName", SqlDbType.NVarChar, userBO.UserName);
                _dbConnection.AddParameter("@roleName", SqlDbType.NVarChar, userBO.RoleName);
                _dbConnection.AddParameter("@password", SqlDbType.NVarChar, userBO.Password);
                _dbConnection.AddParameter("@name", SqlDbType.VarChar, userBO.Name);
                _dbConnection.AddParameter("@address", SqlDbType.VarChar, userBO.Address);
                _dbConnection.AddParameter("@contact", SqlDbType.VarChar, userBO.ContactNo);
                _dbConnection.AddParameter("@remark", SqlDbType.VarChar, userBO.Remarks);
                _dbConnection.AddParameter("@isActive", SqlDbType.Bit, userBO.IsActive);
                _dbConnection.AddParameter("@branchID", SqlDbType.Int, userBO.BranchId);
                _dbConnection.AddParameter("@entryBy", SqlDbType.VarChar, GlobalVariableBO._userName);
                _dbConnection.AddParameter("@employeeCode",SqlDbType.VarChar,userBO.EmployeeCode);
                _dbConnection.ExecuteNonQuery(queryStringUser);
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

        public bool CheckCurrentPassword(string userName, string password)
        {
            DataTable dataTable;
            string queryString = "";
            queryString = "SELECT User_Name FROM SBP_Users WHERE User_Name='" + userName + "' AND Password='"+password+"'";
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
            {
                return true;
            }
            else
            {
                return false;
            }

            
        }

        public void ChangePassword(string userName, string newPassword)
        {
            string queryStringPassChange = "";
            queryStringPassChange = @"SBPChangePassword"; 
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@userName", SqlDbType.NVarChar, userName);
                _dbConnection.AddParameter("@password", SqlDbType.NVarChar,newPassword);

                _dbConnection.ExecuteNonQuery(queryStringPassChange);
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
        public DataTable GetResourceList()
        {
            string queryString = "SELECT Resource_ID,Resource_Name,(SELECT Criteria_ID FROM SBP_Criteria_Resource WHERE Resource_ID=SBP_Resource_List.Resource_ID ) AS Criteria_ID FROM SBP_Resource_List";
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
        public DataTable GetMenuList()
        {
            string queryString = "SELECT MenuID,MenuName FROM SBP_MenuList";
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

        public DataTable GetRestrictedReferenceCodeList(int resourceID,string menuName,List<string> username)
        {
            string queryString;
            DataTable data = new DataTable();
            DataTable finalTable=new DataTable();
            bool isColoned = false;
            //finalTable.Columns.Add("Reference_Code");
            //finalTable.Columns.Add("User_Name");

          //  finalTable = data.Clone();)
            try
            {
                _dbConnection.ConnectDatabase();

                foreach (string userName in username)
                {
                    if (menuName == "" || menuName == null)
                    {
                        queryString = "SELECT Reference_Code,User_Name FROM SBP_Limited_Dashbord WHERE Resource_ID=" +
                                      resourceID + " AND User_Name='" + userName + "'";
                    }
                    else
                    {
                        queryString = "SELECT Reference_Code,User_Name FROM SBP_Hide_Customer WHERE Resource_ID=" +
                                      resourceID + " AND User_Name='" + userName + "'";
                    }

                    data = _dbConnection.ExecuteQuery(queryString);
                    if (isColoned == false)
                    {
                        finalTable = data.Clone();
                        isColoned = true;
                    }

                    if(data.Rows.Count>0)
                    {
                       for (int i = 0; i < data.Rows.Count; i++)
                       {
                           finalTable.ImportRow(data.Rows[i]);
                       }

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

            return finalTable;
        }

        public DataTable GetUserWithIsSelectValue(string roleName,int prevID)
        {
            string queryString;
            //if (roleName == "")
            //{
            //    queryString = "SELECT User_Name FROM dbo.SBP_Users WHERE IS_Active=1";
            //}
            //else
            //{
            queryString = " SELECT "
                        + " ("
                        + " CASE "
                        + "	            WHEN prv.UserName is NULL "
                        + "                     THEN 0"
                        + "             ELSE 1"
                        + " END"
                        + " )AS [IsSelected]"
                        + " ,"

                        + " usr.[User_Name] AS [UserName]"

                        + " FROM "
                        + " ("
                        + "         SELECT c.*"
                        + "         FROM SBP_Users AS c"
                        + "         WHERE c.[Role_Name]='"+roleName +"' AND c.IS_Active=1"
                        + " )AS usr "
                        + " LEFT OUTER JOIN"
                        + " (" 	
                        +"          SELECT t.*"
                        + "         FROM dbo.SBP_Previllizes AS t"
                        + "         WHERE t.PrevillizeID=" + prevID +" AND t.[Role_Name]='" + roleName +"'"
                        + " )"
                        + " AS prv"
                        + " ON "
                        + " usr.Role_Name=prv.Role_Name"
                        + " AND "
                        + " usr.[User_Name]=prv.[UserName]";
            //}
            DataTable data = new DataTable();

            try
            {
                _dbConnection.ConnectDatabase();
                data = _dbConnection.ExecuteQuery(queryString);
            }
            catch (Exception ex)
            {

                throw;
            }

            finally
            {
                _dbConnection.CloseDatabase();
            }

            return data;
            
        }


        public DataTable GetUserList(string roleName)
        {
            string queryString;
            if (roleName == "")
            {
                queryString = "SELECT User_Name FROM dbo.SBP_Users WHERE IS_Active=1";
            }
            else
            {
                queryString = "SELECT User_Name FROM dbo.SBP_Users WHERE IS_Active=1 AND Role_Name='" + roleName + "'"; 
            }
            DataTable data=new DataTable();

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

        public DataTable GetExistingUserList(string menu , int resourceId)
        {
            string queryString;
            if (menu == "")
            {
               // queryString = "SELECT User_Name FROM dbo.SBP_Limited_Dashbord WHERE Resource_ID=" + resourceId;
                queryString = " SELECT  "
                             + " ( "
                             + "  CASE "
                             + "	WHEN res.User_Name is NULL OR res.User_Name =''"
                             + "	THEN 0 "
                             + "	ELSE 1 "
                             + "  END "
                             + " )AS [IsSelected] "
                             + " , usr.[User_Name] AS [UserName] "
                             + " FROM  "
                             + "   (  "
                             + "    SELECT c.* "
                             + "    FROM SBP_Users AS c "
                             + "    WHERE c.IS_Active=1 "
                             + "    )AS usr "
                             + " LEFT OUTER JOIN "
                             + "   ( "
                             + "   SELECT limt.* "
                             + "   FROM dbo.SBP_Limited_Dashbord AS limt "
                             + "   WHERE limt.Resource_ID=" + resourceId 
                             + "   ) AS res "
                             + " ON  usr.User_Name=res.User_Name";
            }
            else
            {
               // queryString = "SELECT User_Name FROM dbo.SBP_Hide_Customer WHERE Resource_ID=" + resourceId;
                queryString = " SELECT  "
                             + " ( "
                             + "  CASE "
                             + "	WHEN res.User_Name is NULL OR res.User_Name =''"
                             + "	THEN 0 "
                             + "	ELSE 1 "
                             + "  END "
                             + " )AS [IsSelected] "
                             + " , usr.[User_Name] AS [UserName] "
                             + " FROM  "
                             + "   (  "
                             + "    SELECT c.* "
                             + "    FROM SBP_Users AS c "
                             + "    WHERE c.IS_Active=1 "
                             + "    )AS usr "
                             + " LEFT OUTER JOIN "
                             + "   ( "
                             + "   SELECT hide.* "
                             + "   FROM dbo.SBP_Hide_Customer AS hide "
                             + "   WHERE hide.Resource_ID=" + resourceId
                             + "   ) AS res "
                             + " ON  usr.User_Name=res.User_Name";

            }
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

        public DataTable GetExistingUserList(string hidelimit, int resourceId,int criteriaID)
        {
            string queryString="";
            DataTable dataTable = new DataTable();

            if (hidelimit == "Limit")
            {
                // queryString = "SELECT User_Name FROM dbo.SBP_Limited_Dashbord WHERE Resource_ID=" + resourceId;
                queryString = "GetUserList_As_LimitedPrevilleze";
            }
            else if (hidelimit == "Hide")
            {
                // queryString = "SELECT User_Name FROM dbo.SBP_Hide_Customer WHERE Resource_ID=" + resourceId;
                queryString = "dbo.GetUserList_As_HidePrevilleze";

            }

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@Resource_ID", SqlDbType.Int, resourceId);
                _dbConnection.AddParameter("@Criteria_ID", SqlDbType.Int, criteriaID);
                dataTable = _dbConnection.ExecuteProQuery(queryString);
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
        public DataTable GetExistingRefCodeList(string hidelimit, string selectparam, int resourceId, int criteriaID)
        {
            string queryString;
            DataTable dataTable = new DataTable();

            if (hidelimit == "Limit")
            {
                // queryString = "SELECT User_Name FROM dbo.SBP_Limited_Dashbord WHERE Resource_ID=" + resourceId;
                queryString = @"GetClientList_As_LimitedPrevilleze";
            }
            else
            {
                // queryString = "SELECT User_Name FROM dbo.SBP_Hide_Customer WHERE Resource_ID=" + resourceId;
                queryString = @"GetClientList_As_HidePrevilleze";

            }

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@UserName_BySelectUnionQry", SqlDbType.VarChar, selectparam);
                _dbConnection.AddParameter("@ResouceID", SqlDbType.Int, resourceId);
                _dbConnection.AddParameter("@CreteriaID", SqlDbType.Int, criteriaID);
                dataTable = _dbConnection.ExecuteProQuery(queryString);
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


        public DataTable GetExistingRolewithUser(string rolename, int prevId,string prevName)
        {
            string queryString;
            {
                queryString = "SELECT UserName FROM dbo.SBP_Previllizes WHERE Role_Name ='" + rolename +
                              "' AND PrevillizeID=" + prevId + " AND Previllize='" + prevName + "'";
            }
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

        public DataTable GetCriteriaName(int resourceId)
        {
            string queryString;
            {
                queryString = "SELECT [Criteria_ID] AS Criteria_ID, [Criteria_Name] AS Criteria_Name "
                            + " FROM [SBP_Database].[dbo].[SBP_Criteria] "
                            + " WHERE Criteria_ID=(SELECT Criteria_ID FROM dbo.SBP_Criteria_Resource WHERE Resource_ID=" + resourceId + ")";

            }
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


    }
}
