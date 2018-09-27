using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccessLayer;
using BusinessAccessLayer.BO;
namespace BusinessAccessLayer.BAL
{
   public class RecordLevelFilteringBAL
    {
        private DbConnection _dbConnection;
        private DataTable rootDataSource = new DataTable();

        private DataTable hiddenDatatable = new DataTable();
        private DataTable limitedDatatable = new DataTable();

        private string filterName = string.Empty;
        private string resourceName = string.Empty;

        private List<string> hiddenList = new List<string>();
        private List<string> limitedList = new List<string>();
        private List<string> commonList = new List<string>();


        bool isAllHide = false;
        bool isAllLimit = false;
        bool isExistHidetable = false;
        bool isExistLimitable = false;

        public RecordLevelFilteringBAL(DataTable data, string filterColumnName,string resourcename)
        {
            _dbConnection = new DbConnection();
            rootDataSource = data;
            filterName = filterColumnName;
            resourceName = resourcename;
        }
        public RecordLevelFilteringBAL(string resourcename)
        {
            _dbConnection = new DbConnection();
            resourceName = resourcename;
        }
        public RecordLevelFilteringBAL()
        {
            _dbConnection = new DbConnection();
        }

       private  void SetHiddenList()
       {
            string queryString = "SELECT Reference_Code FROM SBP_Hide_Customer WHERE User_Name='" + GlobalVariableBO._userName + "' AND Resource_ID=(SELECT Resource_ID FROM SBP_Resource_List WHERE Resource_Name='" + resourceName + "')";
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
            hiddenList.Clear();
            if (data.Rows.Count > 0)
            {
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    hiddenList.Add(data.Rows[i][0].ToString());
                }
            }
       }
       private void SetHiddenList(string referenceCode, int resourceId, int criteriaId)
       {
           string queryString = "SELECT * FROM dbo.SBP_Hide_Customer WHERE User_Name='" + GlobalVariableBO._userName +
                                "' AND Resource_ID=" + resourceId +
                                " AND Criteria_ID=" + criteriaId;
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
           hiddenList.Clear();
           if (data.Rows.Count > 0)
           {
               for (int i = 0; i < data.Rows.Count; i++)
               {
                   hiddenList.Add(data.Rows[i][1].ToString());
               }
           }

       }
       private void SetHiddenList(int workstation, string workstationName, int resourceId, int criteriaId)
       {
           string queryString = "SELECT * FROM dbo.SBP_Hide_Customer WHERE User_Name='" + GlobalVariableBO._userName +
                                "' AND Reference_Code='" + workstationName + "' AND Resource_ID=" + resourceId +
                                " AND Criteria_ID=" + criteriaId;
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
           hiddenList.Clear();
           if (data.Rows.Count > 0)
           {
               for (int i = 0; i < data.Rows.Count; i++)
               {
                   hiddenList.Add(data.Rows[i][1].ToString());
               }
           }

       }
       private void SetLimitedList(string referenceCode, int resourceId, int criteriaId)
       {
           string queryString = "SELECT * FROM dbo.SBP_Limited_Dashbord WHERE User_Name='" + GlobalVariableBO._userName +
                                "' AND Resource_ID=" + resourceId +
                                " AND Criteria_ID=" + criteriaId;
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
           limitedList.Clear();
           if (data.Rows.Count > 0)
           {
               for (int i = 0; i < data.Rows.Count; i++)
               {
                   limitedList.Add(data.Rows[i][2].ToString());
               }
           }

       }

       private void SetLimitedList(int workstation, string workstationName, int resourceId, int criteriaId)
       {
           string queryString = "SELECT * FROM dbo.SBP_Limited_Dashbord WHERE User_Name='" + GlobalVariableBO._userName +
                                "' AND Reference_Code='" + workstationName + "' AND Resource_ID=" + resourceId +
                                " AND Criteria_ID=" + criteriaId;
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
           limitedList.Clear();
           if (data.Rows.Count > 0)
           {
               for (int i = 0; i < data.Rows.Count; i++)
               {
                   limitedList.Add(data.Rows[i][2].ToString());
               }
           }

       }

        private  void SetLimitedList()
        {
            string queryString = "SELECT DISTINCT Reference_Code FROM SBP_Limited_Dashbord WHERE User_Name='" + GlobalVariableBO._userName + "' AND Resource_ID=(SELECT Resource_ID FROM SBP_Resource_List WHERE Resource_Name='" + resourceName + "')";
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
            limitedList.Clear();
            if (data.Rows.Count > 0)
            {
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    limitedList.Add(data.Rows[i][0].ToString());
                }
            }

        }
        private  void SetCommonList()
        {
            //string queryString = " SELECT DISTINCT Client_Code"
            //                     + " FROM SBP_Limited_Dashbord INNER JOIN  SBP_Hide_Customer"
            //                     + " ON SBP_Limited_Dashbord.Client_Code=SBP_Hide_Customer.Cust_Code AND "
            //                     + " SBP_Limited_Dashbord.User_Name=SBP_Hide_Customer.User_Name AND "
            //                     + " SBP_Limited_Dashbord.Resource_ID=SBP_Hide_Customer.Resource_ID "
            //                     + " AND SBP_Limited_Dashbord.User_Name='" + GlobalVariableBO._userName + "' AND SBP_Hide_Customer.User_Name='" + GlobalVariableBO._userName + "'";
 
            //DataTable data = new DataTable();

            //try
            //{
            //    _dbConnection.ConnectDatabase();
            //    data = _dbConnection.ExecuteQuery(queryString);
            //}
            //catch (Exception)
            //{

            //    throw;
            //}

            //finally
            //{
            //    _dbConnection.CloseDatabase();
            //}

            //if (data.Rows.Count > 0)
            //{
            //    commonCustCode.Clear();
            //    for (int i = 0; i < data.Rows.Count; i++)
            //    {
            //        commonCustCode.Add(data.Rows[i][0].ToString());
            //    }
            //}
            if (hiddenList.Count >limitedList.Count)
            {
                commonList.Clear();
                foreach(string item in hiddenList)
                {
                    foreach(string litem in limitedList)
                    {
                        if(item==litem)
                        {
                            commonList.Add(item);
                        }
                    }
                }
            }
            else
            {
                foreach (string item in limitedList)
                {
                    foreach (string litem in hiddenList)
                    {
                        if (item == litem)
                        {
                            commonList.Add(item);
                        }
                    }
                }

            }

        }

        private  void SetHiddenDataSource()
        {
            bool result = false;
            if (hiddenList.Count > 0)
            {
                hiddenDatatable = rootDataSource.Clone();
                foreach (DataRow row in rootDataSource.Rows)
                {
                    result = false;
                    foreach (string item in hiddenList)
                    {
                        if (row[filterName].ToString() == item)
                        {
                            result = true;
                            break;
                        }
                    }
                    if (result == false)
                    {
                        DataRow dr = hiddenDatatable.NewRow();
                        dr = row;
                        hiddenDatatable.ImportRow(dr);
                    }

                }
            }
            else
                hiddenDatatable = rootDataSource;

        }


        private  void SetLimitedDataSource()
        {
            bool result = false;
            if (limitedList.Count > 0)
            {
                //limitedDatatable = hiddenDatatable.Clone();
                limitedDatatable = rootDataSource.Clone();

                foreach (DataRow row in rootDataSource.Rows)
                {
                    result = false;
                    foreach (string item in limitedList)
                    {
                        if (row[filterName].ToString() == item)
                        {
                            result = true;
                            break;
                        }
                    }
                    if (result == true)
                    {
                        DataRow dr = limitedDatatable.NewRow();
                        dr = row;
                        limitedDatatable.ImportRow(dr);
                    }
                }
                if (limitedDatatable.Rows.Count == 0 && rootDataSource.Rows.Count != 0)
                {
                    limitedDatatable = rootDataSource;
                }

            }
            else
                limitedDatatable = rootDataSource;

        }

        private DataTable SetFinalDataSource()
        {
            bool result = false;
            if (commonList.Count > 0)
            {
                //  finalDataSource = rootDataSource.Clone();

                result = false;
                foreach (string item in commonList)
                {
                    foreach (DataRow row in limitedDatatable.Rows)
                    {
                        if (row[filterName].ToString() == item)
                        {
                            result = true;
                            break;
                        }
                    }
                    if (result == false)
                    {
                        DataRow dr = limitedDatatable.NewRow();
                        for (int x = 0; x < rootDataSource.Rows.Count; x++)
                        {
                            if (rootDataSource.Rows[x][filterName].ToString() == item)
                            {
                                DataRow row = rootDataSource.Rows[x];
                                limitedDatatable.ImportRow(row);
                            }
                        }
                    }

                }
                return limitedDatatable;

            }
            else
                return limitedDatatable;

        }

       public DataTable GetRecordLevelFilteredData()
       {
           DataTable data = new DataTable();
           SetHiddenList();
           SetLimitedList();
           //SetCommonList();
           if (hiddenList.Count == 0 && limitedList.Count == 0)
           {
               data = rootDataSource;
           }
           else if (hiddenList.Count != 0 && limitedList.Count == 0)
           {
               SetHiddenDataSource();
               data = hiddenDatatable;
           }
           else if (hiddenList.Count == 0 && limitedList.Count != 0)
           {
               SetLimitedDataSource();
               data = limitedDatatable;
           }
           else if (hiddenList.Count != 0 && limitedList.Count != 0)
           {
               SetLimitedDataSource();
               data = limitedDatatable;
           }
           //else
           //{
           //    SetHiddenDataSource();
           //    SetLimitedDataSource();
           //    data = SetFinalDataSource();
           //}
           return data;
       }

       public string FilterCustCode(string custcode, string resourcename)
       {
           string CustCode = custcode;
           SetHiddenList();
           SetLimitedList();
           if (hiddenList.Count == 0 && limitedList.Count == 0)
           {
               CustCode = custcode;
           }
           else
           {
               if (hiddenList.Count > 0)
               {
                   foreach (string item in hiddenList)
                   {
                       if (custcode == item)
                           CustCode = "";
                   }
               }

               if (limitedList.Count > 0)
               {
                   foreach (string item in limitedList)
                   {
                       if (custcode == item)
                       {
                           CustCode = item;
                           break;
                       }
                       else
                       {
                           CustCode = "";
                       }
                   }
               }
           }

           return CustCode;
       }

       public string FilterBranchID(string referenceCode, int resourceId,int criteriaId)
       {
           string branchId = referenceCode;
           SetHiddenList(referenceCode, resourceId, criteriaId);
           SetLimitedList(referenceCode, resourceId, criteriaId);
           
           if (hiddenList.Count > 0)
           {
               foreach (string item in hiddenList)
               {
                   if (referenceCode == item)
                       branchId = "";
               }
           }

           if (limitedList.Count > 0)
           {
               foreach (string item in limitedList)
               {
                   if (referenceCode == item)
                   {
                       branchId = item;
                       break;
                   }
                   else
                   {
                       branchId = "";
                   }
               }
           }
           if (branchId == "")
               branchId = "-1";
           return branchId;
       }

       public string FilterWorkStation_All(string WorkSataionName, int resourceId, int criteriaId)
       {
           string result = "-1";
           isAllLimit = Check_All_Limit(resourceId, criteriaId);
           isAllHide = Check_All_Hide(resourceId, criteriaId);
           isExistLimitable= isExistLimit(resourceId, criteriaId);
           isExistHidetable = isExistHide(resourceId, criteriaId);


           if (isAllLimit)
           {
               result = WorkSataionName;
           }
           else if (!isAllLimit && !isAllHide && !isExistLimitable && !isExistHidetable)
           {
               result = WorkSataionName;
           }
           return result;
       }
       public string FilterWorkStation(string workstation, int resourceId, int criteriaId)
       {
           string workstationName = workstation;
           SetHiddenList(1,workstation, resourceId, criteriaId);
           SetLimitedList(1,workstation, resourceId, criteriaId);
           if (hiddenList.Count > 0)
           {
               foreach (string item in hiddenList)
               {
                   if (workstation == item)
                       workstationName = "";
               }
           }

           if (limitedList.Count > 0)
           {
               foreach (string item in limitedList)
               {
                   if (workstation == item)
                       workstationName = item;
               }
           }
           if (workstationName == "")
               workstationName = "";
           return workstationName;
       }

       public int GetResourceID(string resourceName)
       {
           string queryString = "SELECT Resource_ID FROM SBP_Resource_List WHERE Resource_Name='" + resourceName + "'";
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
           if (data.Rows.Count > 0)
               return Convert.ToInt32(data.Rows[0][0]);
           else
               return 0;
       }

       public int GetCriteriaID(int resourceId)
       {
           string queryString = "SELECT Criteria_ID FROM SBP_Criteria_Resource WHERE Resource_ID=" + resourceId;
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
           if (data.Rows.Count > 0)
               return Convert.ToInt32(data.Rows[0][0]);
           else
               return 0;
       }
       public string GetFilteredColumnName(string resourceName)
       {
           string filteredColumn_name = string.Empty;
           string queryString = " SELECT [Rs_Mapped_Column] "
                                + " FROM [SBP_Database].[dbo].[SBP_Criteria_Resource]"
                                + " WHERE Resource_ID="
                                + " (SELECT Resource_ID "
                                + "  FROM dbo.SBP_Resource_List "
                                + " WHERE Resource_Name='" + resourceName  + "' "
                                + ")";
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
           if (data.Rows.Count > 0)
               filteredColumn_name= data.Rows[0][0].ToString();
           else
               filteredColumn_name= "";
           return filteredColumn_name;

       }
       public bool Check_All_Hide(int resourceId, int criteriaId)
       {
           bool result = false;
           string queryString = @"GetIsAllHide";                                
           DataTable data = new DataTable();

           try
           {
               _dbConnection.ConnectDatabase();
               _dbConnection.ActiveStoredProcedure();
               _dbConnection.AddParameter("@ResourceId", SqlDbType.Int, resourceId);
               _dbConnection.AddParameter("@CriteriaId", SqlDbType.Int, criteriaId);
               _dbConnection.AddParameter("@UserName", SqlDbType.VarChar, GlobalVariableBO._userName);
               data = _dbConnection.ExecuteProQuery(queryString);
           }
           catch (Exception)
           {

               throw;
           }

           finally
           {
               _dbConnection.CloseDatabase();
           }
           if (data.Rows.Count > 0)
           {
               if (data.Rows[0][0].ToString() != "0")
                   result = true;
           }
               return result;
       }

       public bool Check_All_Limit(int resourceId, int criteriaId)
       {
           bool result = false;
           string queryString = @"GetIsAllLimit";
           DataTable data = new DataTable();

           try
           {
               _dbConnection.ConnectDatabase();
               _dbConnection.ActiveStoredProcedure();
               _dbConnection.AddParameter("@ResourceId", SqlDbType.Int, resourceId);
               _dbConnection.AddParameter("@CriteriaId", SqlDbType.Int, criteriaId);
               _dbConnection.AddParameter("@UserName", SqlDbType.VarChar, GlobalVariableBO._userName);
               data = _dbConnection.ExecuteProQuery(queryString);
           }
           catch (Exception)
           {

               throw;
           }

           finally
           {
               _dbConnection.CloseDatabase();
           }
           if (data.Rows.Count > 0)
           {
               if (data.Rows[0][0].ToString() != "0")
                   result = true;
           }
           return result;
       }
       public bool isExistLimit(int resourceId, int criteriaId)
       {
           bool result = false;
           DataTable data = new DataTable();
           string query = "SELECT DISTINCT [Reference_Code]"
        + " FROM [SBP_Database].[dbo].[SBP_Limited_Dashbord]"
        + " WHERE Resource_ID=" + resourceId + " AND Criteria_ID=" + criteriaId + " AND User_Name='" + GlobalVariableBO._userName + "'";

           try
           {
               _dbConnection.ConnectDatabase();
               data = _dbConnection.ExecuteQuery(query);
           }
           catch
           {

           }
           if (data.Rows.Count > 0)
           {
               result = true;
           }
           return result;
       }
       public bool isExistHide(int resourceId, int criteriaId)
       {
           bool result = false;
           DataTable data = new DataTable();
           string query = "SELECT DISTINCT [Reference_Code]"
        + " FROM [SBP_Database].[dbo].[SBP_Hide_Customer]"
        + " WHERE Resource_ID=" + resourceId + " AND Criteria_ID=" + criteriaId + " AND User_Name='" + GlobalVariableBO._userName + "'";

           try
           {
               _dbConnection.ConnectDatabase();
               data = _dbConnection.ExecuteQuery(query);
           }
           catch
           {

           }
           if (data.Rows.Count > 0)
           {
               result = true;
           }
           return result;
       }
    }
}
