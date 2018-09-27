using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessAccessLayer.BO;
using BusinessAccessLayer.Constants;
using DataAccessLayer;
using System.Data;

namespace BusinessAccessLayer.BAL
{
    public class LoadSearchInfo
    {
        private DbConnection _dbConnection;

        public LoadSearchInfo()
        {
            _dbConnection = new DbConnection();
        }

        public DataTable LoadCustomerCode()
        {
            DataTable dataTable;
            dataTable = null;
            string queryString = "";
            queryString = "SELECT Cust_Code FROM SBP_Cust_Image;";
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

        public DataTable LoadCustomerImg(string SearchTable_Db, string SearchBy, string SearchCode, string SearchInfoTable, string SearchFieldName)
        {
            DataTable dataTable = new DataTable();
            DataTable dataTable_ImgExt = new DataTable();
            string queryString_CustCode = "";
            string queryString_CustCode_ImgExt = "";
            string PersonName = "";
            string SearchTable_ImgExt = string.Empty;


            if (SearchTable_Db == "SBP_Cust_Image")
            {
                PersonName = "Cust_Name";
                SearchTable_ImgExt =
                    Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_Cust_Image").
                        SingleOrDefault().Value;
            }
            else if (SearchTable_Db == "SBP_Joint_holder_Image")
            {
                PersonName = "Joint_Name";
                SearchTable_ImgExt =
                    Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_Joint_holder_Image").
                        SingleOrDefault().Value;
            }
            else if (SearchTable_Db == "SBP_Nominee1_Image")
            {
                PersonName = "Name";
                SearchTable_ImgExt =
                    Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_Nominee1_Image").
                        SingleOrDefault().Value;
            }
            else if (SearchTable_Db == "SBP_Nominee2_Image")
            {
                PersonName = "Name";
                SearchTable_ImgExt =
                    Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_Nominee2_Image").
                        SingleOrDefault().Value;
            }
            else if (SearchTable_Db == "SBP_Guardian1_Image")
            {
                PersonName = "Name";
                SearchTable_ImgExt =
                    Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_Guardian1_Image").
                        SingleOrDefault().Value;
            }
            else if (SearchTable_Db == "SBP_Guardian2_Image")
            {
                PersonName = "Name";
                SearchTable_ImgExt =
                    Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_Guardian2_Image").
                        SingleOrDefault().Value;
            }
            else if (SearchTable_Db == "SBP_POA_Image")
            {
                PersonName = "Name";
                SearchTable_ImgExt =
                    Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_POA_Image_ImgExt").
                        SingleOrDefault().Value;
            }
            else if (SearchTable_Db == "SBP_Author_Image")
            {
                PersonName = "Author_Name";
                SearchTable_ImgExt =
                    Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_Author_Image").
                        SingleOrDefault().Value;
            }
            else if (SearchTable_Db == "SBP_Others_Upload")
            {
                PersonName = "Name";
                SearchTable_ImgExt =
                    Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_Others_Upload").
                        SingleOrDefault().Value;
            }

            string dbSearchField = FieldName(SearchFieldName);

            if (SearchBy == "Customer Code")
            {
                queryString_CustCode =
                    " SELECT "
                    + SearchTable_Db + "." + dbSearchField
                    + " As " + dbSearchField
                    + " ,SBP_Customers.Cust_Code "
                    + " ,SBP_Customers.BO_ID"
                    + " ," + SearchInfoTable + "." + PersonName
                    + " FROM " + SearchTable_Db
                    + " ,SBP_Customers "
                    + " LEFT JOIN " + SearchInfoTable
                    + " ON (" + SearchInfoTable + ".Cust_Code=SBP_Customers.Cust_Code) "
                    + " WHERE SBP_Customers.Cust_Code=" + SearchTable_Db + ".Cust_Code "
                    + " and  SBP_Customers.Cust_Code='" + SearchCode + "';";

                queryString_CustCode_ImgExt =
                    " SELECT "
                    + "ext." + dbSearchField
                    + " As " + dbSearchField
                    + " ,SBP_Customers.Cust_Code "
                    + " ,SBP_Customers.BO_ID"
                    + " ," + SearchInfoTable + "." + PersonName
                    + " FROM  [SBP_Database_ImageExt].[dbo].[" + SearchTable_ImgExt + "] as ext"
                    + " ,SBP_Customers "
                    + " LEFT JOIN " + SearchInfoTable
                    + " ON (" + SearchInfoTable + ".Cust_Code=SBP_Customers.Cust_Code) "
                    + " WHERE SBP_Customers.Cust_Code=" + "ext.Cust_Code "
                    + " and  SBP_Customers.Cust_Code='" + SearchCode + "';";
            }
            else if (SearchBy == "Customer BO ID")
            {
                string BOID = BOId(SearchCode);
                queryString_CustCode =
                    " SELECT "
                    + SearchTable_Db + "." + dbSearchField
                    + " As " + dbSearchField
                    + " ,SBP_Customers.Cust_Code "
                    + " ,SBP_Customers.BO_ID"
                    + " ," + SearchInfoTable + "." + PersonName
                    + " FROM " + SearchTable_Db
                    + " ,SBP_Customers "
                    + " LEFT JOIN " + SearchInfoTable
                    + " ON (" + SearchInfoTable + ".Cust_Code=SBP_Customers.Cust_Code) "
                    + " WHERE SBP_Customers.Cust_Code=" + SearchTable_Db + ".Cust_Code "
                    + " and  SBP_Customers.BO_ID='" + BOID + "';";

                queryString_CustCode_ImgExt =
                    " SELECT "
                    + "ext." + dbSearchField
                    + " As " + dbSearchField
                    + " ,SBP_Customers.Cust_Code "
                    + " ,SBP_Customers.BO_ID"
                    + " ," + SearchInfoTable + "." + PersonName
                    + " FROM  [SBP_Database_ImageExt].[dbo].[" + SearchTable_ImgExt + " as ext"
                    + " ,SBP_Customers "
                    + " LEFT JOIN " + SearchInfoTable
                    + " ON (" + SearchInfoTable + ".Cust_Code=SBP_Customers.Cust_Code) "
                    + " WHERE SBP_Customers.Cust_Code=" + "ext.Cust_Code "
                    + " and  SBP_Customers.BO_ID='" + BOID + "';";

            }
            try
            {
                _dbConnection.ConnectDatabase();
                dataTable = _dbConnection.ExecuteQuery(queryString_CustCode_ImgExt);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                _dbConnection.CloseDatabase();
            }

            try
            {
                _dbConnection.ConnectDatabase();
                dataTable_ImgExt = _dbConnection.ExecuteQuery(queryString_CustCode_ImgExt);
            }
            catch (Exception ey)
            {

                throw new Exception(ey.Message);
            }

            finally
            {
                _dbConnection.CloseDatabase();
            }
            if (dbSearchField == "Photo")
            {
                if (dataTable_ImgExt.Rows.Count > 0 && dataTable.Rows.Count > 0)
                {
                    if (dataTable_ImgExt.Rows[0]["Photo"] != DBNull.Value)
                    {
                        dataTable.Rows[0]["Photo"] = dataTable_ImgExt.Rows[0]["Photo"];
                    }
                }
            }
            else if (dbSearchField == "Signature")
            {
                if (dataTable_ImgExt.Rows.Count > 0 && dataTable.Rows.Count > 0)
                {
                    if (dataTable_ImgExt.Rows[0]["Signature"] != DBNull.Value)
                    {
                        dataTable.Rows[0]["Signature"] = dataTable_ImgExt.Rows[0]["Signature"];
                    }
                }
            }
            return dataTable;
        }

        public string BOId(string SearchCode)
        {
            DataTable dtCust_code;
            dtCust_code = null;
            string Bo_id;
            string qurey;
            qurey = "";
            qurey = "Select Cust_Code from SBP_Customers where BO_ID='" + SearchCode + "';";

            try
            {
                _dbConnection.ConnectDatabase();
                dtCust_code = _dbConnection.ExecuteQuery(qurey);
                Bo_id = dtCust_code.Rows[0][0].ToString();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }


            return Bo_id;


        }

        public string FieldName(string searchField)
        {
            string FiName;
            FiName = "";

            if (searchField == "Image Viewer")
            {
                FiName = "Photo";

            }

            else if (searchField == "Signature Viewer")
            {
                FiName = "Signature";
            }


            return FiName;

        }

    }
}
