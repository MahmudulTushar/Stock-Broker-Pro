using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using System.Data;
using BusinessAccessLayer.BO;

namespace BusinessAccessLayer.BAL
{
   public class LimitedDashboardBAL
   {
       private DbConnection _dbConnection;

       public LimitedDashboardBAL()
       {
           _dbConnection=new DbConnection();
       }

       public void DeleteLimitedClientDashboard(List<string> userName, int resourceId, int criteraId)
       {
           string queryString = "";

           try
           {
               _dbConnection.ConnectDatabase();
               foreach (string uname in userName)
               {
                   queryString = "DELETE FROM dbo.SBP_Limited_Dashbord WHERE User_Name='" + uname + "' AND Resource_ID=" + resourceId + " AND Criteria_ID=" + criteraId;
                   _dbConnection.ExecuteNonQuery(queryString);
               }
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

       public void InsertLimitedClientIntoDashboard(string userName,int resourceId, string  ClientCode,int criteraId)
       {
           string queryString = "INSERT INTO dbo.SBP_Limited_Dashbord (User_Name,Reference_Code,Resource_ID,Criteria_ID,Entry_Date,Entry_By) VALUES('" + userName + "','" + ClientCode + "'," + resourceId + "," + criteraId + ",GETDATE(),'" + GlobalVariableBO._userName + "')";

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
       public void DeleteLimitedClientIntoDashboard(string userName, int resourceId, string ClientCode, int criteraId)
       {
           string queryString = "DELETE FROM dbo.SBP_Limited_Dashbord WHERE User_Name='" + userName + "' AND Reference_Code='" + ClientCode + "' AND Resource_ID=" + resourceId + " AND Criteria_ID=" + criteraId;

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

       public bool IsExists(string userName,string ClientCode,int resourceId)
       {
           string queryString = "SELECT * FROM dbo.SBP_Limited_Dashbord WHERE User_Name='" + userName +
                                "' AND Reference_Code='" + ClientCode + "' AND Resource_ID=" + resourceId;
           DataTable data=new DataTable();
           bool isExist = false;

           try
           {
               _dbConnection.ConnectDatabase();
               data = _dbConnection.ExecuteQuery(queryString);

               if(data.Rows.Count>0)
               {
                   isExist = true;
               }

               else
               {
                   isExist = false;
               }
           }
           catch (Exception)
           {
               
               throw;
           }

           finally
           {
               _dbConnection.CloseDatabase();
           }
           return isExist;
       }

       public List<bool> IsExists(List<string> username, string referenceCode, int resourceId,int criteriaId)
       {
           DataTable data = new DataTable();
           string queryString = "";
           List<bool> isExist=new List<bool>();

           try
           {
               _dbConnection.ConnectDatabase();
               foreach (string userName in username)
               {
                   queryString = "SELECT * FROM dbo.SBP_Limited_Dashbord WHERE User_Name='" + userName +
                                 "' AND Reference_Code='" + referenceCode + "' AND Resource_ID=" + resourceId +
                                 " AND Criteria_ID=" + criteriaId;

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
       public bool IsExists(string username, string referenceCode, int resourceId, int criteriaId)
       {
           DataTable data = new DataTable();
           string queryString = "";
           bool isExist = false;
           try
           {
               _dbConnection.ConnectDatabase();
               queryString = "SELECT * FROM dbo.SBP_Limited_Dashbord WHERE User_Name='" + username +
                                 "' AND Reference_Code='" + referenceCode + "' AND Resource_ID=" + resourceId +
                                 " AND Criteria_ID=" + criteriaId;

                   data = _dbConnection.ExecuteQuery(queryString);

                   if (data.Rows.Count > 0)
                   {
                       isExist= true;
                   }

                   else
                   {
                       isExist= false;
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


       public DataTable GetLimitedClientList(List<string> username, int resourceId, int criteriaId)
       {
           string queryString = "";
           bool isColoned = false;
           DataTable data = new DataTable();
           DataTable finalTable=new DataTable();

           try
           {
               _dbConnection.ConnectDatabase();

               foreach (string userName in username)
               {
                   queryString =
                       "SELECT Limited_ID,Reference_Code AS 'Ref_Code',(SELECT Cust_Name FROM dbo.SBP_Cust_Personal_Info WHERE Cust_Code=Reference_Code) AS 'Client Name',(SELECT ISNULL(Resource_Name,'') FROM SBP_Resource_List WHERE Resource_ID=" +
                       resourceId +
                       ") AS 'Resource Name',User_Name,dbo.SBP_Limited_Dashbord.Entry_By AS 'Entry By',dbo.SBP_Limited_Dashbord.Entry_Date AS 'Entry Date'   FROM dbo.SBP_Limited_Dashbord WHERE User_Name='" +
                       userName + "' AND Resource_ID=" + resourceId + " AND Criteria_ID=" + criteriaId;


                    data = _dbConnection.ExecuteQuery(queryString);
                    if (isColoned == false)
                    {
                        finalTable = data.Clone();
                        isColoned= true;
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
           catch(Exception ex) 
           {
               
              
           }

           finally
           {
               _dbConnection.CloseDatabase();
           }

           return finalTable;
       }

       public void DeleteClientFromLimitedDashBoard(int LimitedID)
       {
           string qaueryString = "DELETE FROM dbo.SBP_Limited_Dashbord WHERE Limited_ID=" + LimitedID + "";

           try
           {
               _dbConnection.ConnectDatabase();
               _dbConnection.ExecuteNonQuery(qaueryString);
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
