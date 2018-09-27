﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessAccessLayer.BO;
using DataAccessLayer;

namespace BusinessAccessLayer.BAL
{
    public class HideCustomerBAL
    {
        private DbConnection _dbConnection;
        public HideCustomerBAL()
        {
            _dbConnection = new DbConnection();
        }

        public DataTable GetGridData(List<string> username, int resourceId, int criteriaId)
        {
            string queryString = "";
            bool isColoned = false;
            DataTable data = new DataTable();
            DataTable finalTable = new DataTable();
            try
            {
                _dbConnection.ConnectDatabase();
                foreach (string userName in username)
                {
                    queryString =
                        "SELECT Sl_No,SBP_Hide_Customer.Reference_Code as 'Ref Code',(SELECT Cust_Name FROM dbo.SBP_Cust_Personal_Info WHERE Cust_Code=Reference_Code) AS 'Client Name',(SELECT ISNULL(Resource_Name,'') FROM SBP_Resource_List WHERE Resource_ID=" +
                        resourceId +
                        ") AS 'Resource Name',User_Name,SBP_Hide_Customer.Entry_By AS 'Entry By',SBP_Hide_Customer.Entry_Date AS 'Entry Date'   FROM SBP_Hide_Customer WHERE User_Name='" +
                        userName + "' AND Resource_ID=" + resourceId + " AND Criteria_ID=" + criteriaId;


                    data = _dbConnection.ExecuteQuery(queryString);
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
            catch
            {
                //  throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return finalTable;
        }

        public void SaveHideCustomer(string custCode, string userName, int resourceId, int criteraId)
        {
            CommonBAL commonBAL = new CommonBAL();
            long slNo = commonBAL.GenerateID("SBP_Hide_Customer", "Sl_No");

            string queryString = "INSERT INTO SBP_Hide_Customer(Sl_No,Reference_Code,User_Name,Resource_ID,Criteria_ID,Entry_Date,Entry_By) Values(" + slNo + ",'" + custCode + "','" + userName + "'," + resourceId +"," + criteraId+ ",CAST(FLOOR(CAST(GETDATE() AS FLOAT)) AS DATETIME),'" + GlobalVariableBO._userName + "')";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(queryString);
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
        public void DeleteHideClientDashboard(string custCode, string userName, int resourceId, int criteraId)
        {
            string queryString = "DELETE FROM dbo.SBP_Hide_Customer WHERE User_Name='" + userName + "' AND Reference_Code='" + custCode + "' AND Resource_ID=" + resourceId + " AND Criteria_ID=" + criteraId;

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




        public void DeleteHideClientDashboard(List<string> userName, int resourceId, int criteraId)
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

        public void DeleteClientFromHiddenDashBoard(int slNo)
        {
            string queryString = "DELETE FROM SBP_Hide_Customer WHERE Sl_No="+slNo+"";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(queryString);
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
        public DataTable GetCustomerDetails(string code, int isCustCode)
        {
            DataTable dataTable;
            string queryString = @"ShowCustomerDetailsForDashBoard";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@custCode", SqlDbType.NVarChar, code);
                _dbConnection.AddParameter("@isCustCode", SqlDbType.Int, isCustCode);
                dataTable = _dbConnection.ExecuteProQuery(queryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dataTable;
        }

        //public bool CheckDuplicate(string custCode)
        //{
        //    DataTable dataTable;
        //    string queryString = "";
        //    queryString = "SELECT Cust_Code FROM SBP_Hide_Customer WHERE Cust_Code='" + custCode + "'";
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
        //    if (dataTable.Rows.Count > 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        public bool CheckDuplicate(string custCode, string userName, int resourceId)
        {
            DataTable dataTable;
            string queryString = "";
            queryString = "SELECT Cust_Code,User_Name,Resource_ID FROM SBP_Hide_Customer WHERE Cust_Code='" + custCode +
                          "' AND User_Name='" + userName + "' AND Resource_ID=" + resourceId;
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

        public DataTable GetResourceList()
        {
            string queryString = "SELECT Resource_ID,Resource_Name FROM SBP_Resource_List";
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
        public DataTable GetUserList()
        {
            string queryString = "SELECT User_Name FROM dbo.SBP_Users WHERE IS_Active=1";
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
        public List<bool> IsExists(List<string> username, string referenceCode, int resourceId, int criteriaId)
        {
            DataTable data = new DataTable();
            string queryString = "";
            List<bool> isExist = new List<bool>();

            try
            {
                _dbConnection.ConnectDatabase();
                foreach (string userName in username)
                {

                    queryString = "SELECT * FROM SBP_Hide_Customer WHERE User_Name='" + userName +
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

                throw;
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

                queryString = "SELECT * FROM SBP_Hide_Customer WHERE User_Name='" + username +
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

                throw;
            }

            finally
            {
                _dbConnection.CloseDatabase();
            }
            return isExist;
        }

        
        public bool IsExists(string userName, string ClientCode, int resourceId)
        {
            string queryString = "SELECT * FROM SBP_Hide_Customer WHERE User_Name='" + userName +
                                 "' AND Reference_Code='" + ClientCode + "' AND Resource_ID=" + resourceId;
            DataTable data = new DataTable();
            bool isExist = false;

            try
            {
                _dbConnection.ConnectDatabase();
                data = _dbConnection.ExecuteQuery(queryString);

                if (data.Rows.Count > 0)
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

        public string GetCustCodeByBOID(string BOID)
        {
            DataTable dataTable;
            dataTable = null;
            string queryString = "";
            queryString = "SELECT Cust_Code "
                          + " FROM [SBP_Database].[dbo].[SBP_Customers] "
                          + " WHERE BO_ID='" + BOID + "'";
            try
            {
                _dbConnection.ConnectDatabase();
                dataTable = _dbConnection.ExecuteQuery(queryString);
            }
            catch
            {
                //  throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            if (dataTable.Rows.Count > 0)
                return dataTable.Rows[0][0].ToString();
            else return "";
        }


    }
}