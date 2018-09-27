using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using System.Data;
using System.Text.RegularExpressions;

namespace BusinessAccessLayer.BAL
{
 public class DP29File_DataMatchBAL
    {
        private DbConnection _dbConnection;

        public DP29File_DataMatchBAL()
        {
            _dbConnection = new DbConnection();
        }

     //----------------------- CDBL Schema File Check ----------------------------
        public DataTable getCDBLTextfileMapping()
        {
            string query = "select CDBLFileColumnName from SBP_CDBLtextFileMapping where FormID=1";
            _dbConnection.ConnectDatabase();
            var data = _dbConnection.ExecuteQuery(query);
            return data;
        }

        //----------------------- End CDBL Schema File Check ----------------------------



     //-------------------------------CDBL File Read & Save ----------------------

       //Create DP29 Table 
        public void CreateSBP_DP29Table()
        {
            try
            {

                //Check SBP_DP29 table is exist
                var Isexist = _dbConnection.IsTableExist("SBP_DP29");
                if (Isexist)
                {
                    _dbConnection.ConnectDatabase();
                  var isColumnEquals = @"with reasult as
                              (select 'DP29Row'=(select COUNT(COLUMN_NAME) from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME='SBP_DP29')-1,'CDBLFilecount'=(select count(CDBLFileColumnName) from SBP_CDBLtextFileMapping where FormID=1) )
                            select * from reasult where DP29Row=CDBLFilecount";

                    DataTable isequals =_dbConnection.ExecuteQuery(isColumnEquals);
                    if (isequals.Rows.Count > 0)
                    {
                        TruncateDP29();
                        return;
                    }
                    else
                    {
                        _dbConnection.ExecuteNonQuery("drop table SBP_DP29 ");
                    }

                }


                //Collect ColumnName
                string query = "select * from SBP_CDBLtextFileMapping where FormID=1";
                _dbConnection.ConnectDatabase();
                DataTable data = _dbConnection.ExecuteQuery(query);

                string columnName = "";
                //Table column name add
                if (data.Rows.Count > 0)
                {
                    for (var i = 0; i < data.Rows.Count; i++)
                    {
                        string RemoveSpecialCharacter = Regex.Replace(data.Rows[i]["CDBLFileColumnName"].ToString(), @"[^0-9a-zA-Z]+", "");
                        if (i == data.Rows.Count - 1)
                        {
                            columnName += RemoveSpecialCharacter + " nvarchar(max)";
                        }
                        else
                        {
                            columnName += RemoveSpecialCharacter + " nvarchar(max)" + ",";
                        }
                    }
                }

              

                //create SBP_DP29 Table 
                string CreateTableQuery = "Create table SBP_DP29 (ID int identity primary key," + columnName + ") ";
                _dbConnection.ExecuteNonQuery(CreateTableQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                _dbConnection.CloseDatabase();
            }
        }





        public DataTable getAllDP29ColumnName()
        {
            string query = "select COLUMN_NAME from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME='SBP_DP29' and COLUMN_NAME!='ID'";
            try
            {
                _dbConnection.ConnectDatabase();
                DataTable data = _dbConnection.ExecuteQuery(query);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
        
        }





        public void TruncateDP29()
        {
            string queryString = "Truncate Table SBP_DP29";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(queryString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
        }



     //Insert Data into DP29
        public void InsertCustomerBO_DP29(string query)
        {
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                _dbConnection.CloseDatabase();
            }
        }



        public DataTable GetClientBOInfo()
        {
            string queryString = "select * from SBP_DP29";
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


     //------------------------------End CDBl File Read & Save ------------------


     //------------------------- btn Mismatch Check -------------------------

       //Create Query for Master table data retrive  
        public string DynamicQueryCreator()
        {     //Data retrive form SBP_CDBLtextFileMapping
            string query = "select * from SBP_CDBLtextFileMapping";
            _dbConnection.ConnectDatabase();
            DataTable data = _dbConnection.ExecuteQuery(query);

            //column name list
            var columnNameArray = (from DataRow secondRow in data.Rows select secondRow["TargetColumnName"]).ToArray();

            if (columnNameArray.Contains(string.Empty))
            {
                return "Please set Column Mapping";
            }

          




            // which table will return data
            List<string> TablenameWithAlis = new List<string>();
            List<string> addColumnNamewithAlis = new List<string>();

            string tableNameString = string.Empty;
            string[] AlisName = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l" };
            var tableName = (from DataRow myRow in data.Rows group myRow by myRow["TargetTableName"] into g select g).ToArray();
            for (var i = 0; i < tableName.Length; i++)
            {
                string TableName = tableName[i].Key.ToString();
                if (tableNameString == string.Empty)
                {
                    tableNameString += TableName + " as " + AlisName[i];
                }
                else
                {
                    tableNameString += " left join " + TableName + " as " + AlisName[i] + " on " + AlisName[0] + ".Cust_Code=" + AlisName[i] + ".Cust_Code";
                }
                TablenameWithAlis.Add(AlisName[i] + "." + TableName);

            }


            for (var cd = 0; cd < data.Rows.Count; cd++)
            {
                string targetColumnName = data.Rows[cd]["TargetColumnName"].ToString();
                string targetTableName = data.Rows[cd]["TargetTableName"].ToString();

                string AlisTableName = (from c in TablenameWithAlis where c.Contains(targetTableName) select c).SingleOrDefault();
                string FindAlisName = AlisTableName.Split('.')[0].ToString();
                addColumnNamewithAlis.Add(FindAlisName + "." + targetColumnName);
            }


            var columnName = addColumnNamewithAlis.ToArray().Select(a => a.ToString()).Aggregate((i, j) => i + "," + j);




            string buildQuerySring = "select " + AlisName[0] + ".Cust_Code," + columnName +","+ AlisName[0] + ".Cust_Status_ID" + " from " + tableNameString;

            return buildQuerySring;
        }




        public DataTable Dp29TableData(string from, string to)
        {
            string query = "";
            if (from == "" && to == "")
            {
                query = " select * from SBP_DP29";
            }
            else
            {
               
                query = @"with Result as 
                                    (select *, ROW_NUMBER() over (order by ID) as Row_number from SBP_DP29)
                                    select * from Result where Row_number between " + from + " and " + to + "";
            
            }
           
            _dbConnection.ConnectDatabase();
            DataTable data = _dbConnection.ExecuteQuery(query);
            return data;
        }


        public DataTable MainTableData()
        {

            string query = DynamicQueryCreator();
            if (query == "Please set Column Mapping")
            {
                return null;
            
            }
            _dbConnection.ConnectDatabase();
            DataTable data = _dbConnection.ExecuteQuery(query);
            return data;

        }


        public DataTable MappingTableData()
        {

            string query = "select * from SBP_CDBLtextFileMapping";
            _dbConnection.ConnectDatabase();
            DataTable data = _dbConnection.ExecuteQuery(query);
            return data;

        }



        //CreateSBP_DP29MissmatchDataTable
        public void CreateSBP_DP29MissmatchTable()
        {
            //Check SBP_DP29 table is exist
            var Isexist = _dbConnection.IsTableExist("SBP_DP29Mismatch");
            if (Isexist)
            {
                var isColumnEqual = @"with reasult as
                              (select 'DP29Row'=(select COUNT(COLUMN_NAME) from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME='SBP_DP29Mismatch')-3,'CDBLFilecount'=(select count(CDBLFileColumnName) from SBP_CDBLtextFileMapping) )
                               select * from reasult where DP29Row=CDBLFilecount";

                DataTable isequal = _dbConnection.ExecuteQuery(isColumnEqual);
                if (isequal.Rows.Count > 0)
                {
                    TruncateDP29MismatchTable();
                    return;
                }
                else
                {
                    _dbConnection.ExecuteNonQuery("drop table SBP_DP29Mismatch ");
                }

            }




            try
            {
                //Collect ColumnName
                string query = "select * from SBP_CDBLtextFileMapping where FormID=1";
                _dbConnection.ConnectDatabase();
                DataTable data = _dbConnection.ExecuteQuery(query);


                string columnName = "";
                //Table column name add
                if (data.Rows.Count > 0)
                {
                    for (var i = 0; i < data.Rows.Count; i++)
                    {
                        string RemoveSpecialCharacter = Regex.Replace(data.Rows[i]["CDBLFileColumnName"].ToString(), @"[^0-9a-zA-Z]+", "");
                        if (i == data.Rows.Count - 1)
                        {
                            columnName += RemoveSpecialCharacter + " nvarchar(max)";
                        }
                        else
                        {
                            columnName += RemoveSpecialCharacter + " nvarchar(max)" + ",";
                        }
                    }
                }


                //create SBP_DP29 Table 
                string CreateTableQuery = "Create table SBP_DP29Mismatch (ID int identity primary key,Status nvarchar(max),CustCode nvarchar(max)," + columnName + ") ";
                _dbConnection.ExecuteNonQuery(CreateTableQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                _dbConnection.CloseDatabase();
            }
        }




     // Find ID Reference Table Primary key
        public string FindPrimaryID(string query)
        {
            _dbConnection.ConnectDatabase();
            DataTable data = _dbConnection.ExecuteQuery(query);
            if (data.Rows.Count > 0)
            {
                return data.Rows[0][0].ToString();

            }
            return "Blank";
        }





        public string getAllDP29MisMatchTableColumnName()
        {
            string query = "select COLUMN_NAME from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME='SBP_DP29Mismatch' and COLUMN_NAME!='ID'";
            try
            {
                _dbConnection.ConnectDatabase();
                DataTable data = _dbConnection.ExecuteQuery(query);
                var ColumnNameArray = (from DataRow myRow in data.Rows select myRow["COLUMN_NAME"]).ToArray();
                //Array to Comma separated value
                string Paramiter = ColumnNameArray.Select(a => a.ToString()).Aggregate((i, j) => i + "," + j);
                return Paramiter;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }

        }



     //Save data Dp29MismatchTable

        public void SaveDP29MismatchTable(string query)
        {
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(query);
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //_dbConnection.ConnectDatabase();
            }
        }



        public void TruncateDP29MismatchTable()
        {
            string queryString = "Truncate Table SBP_DP29Mismatch";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(queryString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
        }



        public DataTable GetMismatchData()
        {
            string queryString = "select * from SBP_DP29Mismatch";
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




        public DataTable CreateDataTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Status", typeof(string));
            table.Columns.Add("CustCode", typeof(string));
            string query = "select * from SBP_CDBLtextFileMapping where FormID=1";
            try
            {
                _dbConnection.ConnectDatabase();
                DataTable data = _dbConnection.ExecuteQuery(query);


                if (data.Rows.Count > 0)
                {
                    for (var i = 0; i < data.Rows.Count; i++)
                    {
                        string RemoveSpecialCharacter = Regex.Replace(data.Rows[i]["CDBLFileColumnName"].ToString(), @"[^0-9a-zA-Z]+", "");
                        table.Columns.Add(RemoveSpecialCharacter, typeof(string));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                _dbConnection.CloseDatabase();
            }

            return table;
        }




        public object[] getAllDP29MisMatchTableColumnNameArray()
        {
            string query = @"select COLUMN_NAME from INFORMATION_SCHEMA.COLUMNS 
                            where TABLE_NAME='SBP_DP29Mismatch'"; 
                            //and COLUMN_NAME!='ID' 
                            //and COLUMN_NAME!='Status' 
                            //and COLUMN_NAME!='CustCode' 
                            //and COLUMN_NAME!='BOIdentificationNumber' 
                            //and COLUMN_NAME!='BOType'  
                            //and COLUMN_NAME!='InternalReferenceNumber'";
            try
            {
                _dbConnection.ConnectDatabase();
                DataTable data = _dbConnection.ExecuteQuery(query);
                var ColumnNameArray = (from DataRow myRow in data.Rows select myRow["COLUMN_NAME"]).ToArray();
                //Array to Comma separated value

                return ColumnNameArray;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }

        }


    



     
     //------------------------- btn Mismatch Check -------------------------



     //--------------------btn Force Close ------------------------------

        public void ForceAccuntClose(string query)
        {

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
        
        
        }



     //------------------------btn Find---------------------


        public DataTable FindMismatchTableData(string columnName, string Value)
        {
            string queryString = "select * from SBP_DP29Mismatch where " + columnName + "='" + Value + "'";
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




        public object[] GetMismatchtableColumnGroupbyValue(string columnName)
        {
            if (columnName == "Select Column Name") return null;
            string query = "select " + columnName + " from SBP_DP29Mismatch group by " + columnName + "";

       
            try
            {
                _dbConnection.ConnectDatabase();
                DataTable data = _dbConnection.ExecuteQuery(query);
                var ColumValueArray = (from DataRow myRow in data.Rows select myRow[0]).ToArray();
                //Array to Comma separated value

                return ColumValueArray;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }

        }



   





     //--------------------------btn Forece close ----------------------

        public void UpdateDataFromGrid(string queryString)
        {

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(queryString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
        }



        public DataTable IsRowisAvailable(string queryString)
        {

            try
            {
                _dbConnection.ConnectDatabase();
              var data=  _dbConnection.ExecuteQuery(queryString);

              return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            
        }




        public void RowInsert(string queryString)
        {

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(queryString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
        }



       






    //------------------btn Change --------------------



     //---------------------btn Setting -----------------------


        public object[] getMappingtableCDBLColumnName(string flag)
        {
            string query = "";
            if (flag == "1")
            {
               query = "select CDBLFileColumnName from SBP_CDBLtextFileMapping";
            }
            else
            {
                query = "select CDBLFileColumnName from SBP_CDBLtextFileMapping where isTableCreated=0";

            }
            try
            {
                _dbConnection.ConnectDatabase();
                DataTable data = _dbConnection.ExecuteQuery(query);
                var ColumnNameArray = (from DataRow myRow in data.Rows select myRow[0]).ToArray();
                return ColumnNameArray;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }

        }



        public object[] getAllTableName()
        {
            string query = "select TABLE_NAME from INFORMATION_SCHEMA.TABLES  order by TABLE_NAME";

            try
            {
                _dbConnection.ConnectDatabase();
                DataTable data = _dbConnection.ExecuteQuery(query);
                var ColumnNameArray = (from DataRow myRow in data.Rows select myRow[0]).ToArray();
                return ColumnNameArray;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }

        }


        public object[] getSelectColumnName(string TableName)
        {

            if (TableName == "") return null;
            string query = "select COLUMN_NAME from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME='" + TableName + "';";

            try
            {
                _dbConnection.ConnectDatabase();
                DataTable data = _dbConnection.ExecuteQuery(query);
                var ColumnNameArray = (from DataRow myRow in data.Rows select myRow[0]).ToArray();
                return ColumnNameArray;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }

        }


        public void UpdateCDBLFileMappingTable(string query)
        {

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }


        }



        public DataTable CDBLMappingTableColumnAndTableName(string queryString)
        {

            try
            {
                _dbConnection.ConnectDatabase();
                var data = _dbConnection.ExecuteQuery(queryString);

                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }

        }





        public DataTable MappingTablespecificdata()
        {

            string query = "select id,CDBLFileColumnName,TargetColumnName,TargetTableName from SBP_CDBLtextFileMapping";
            _dbConnection.ConnectDatabase();
            DataTable data = _dbConnection.ExecuteQuery(query);
            return data;

        }


        public void SBP_CDBLtextFileMappingTableCreate()
        {
            string query = @"CREATE TABLE [dbo].[SBP_CDBLtextFileMapping](
                            [id] [int] IDENTITY(1,1) primary key NOT NULL,
	                        [CDBLFileColumnName] [nvarchar](400) NOT NULL,
	                        [TargetColumnName] [nvarchar](400) NOT NULL,
	                        [TargetTableName] [nvarchar](400) NOT NULL,
	                        [isTableCreated] [bit] NOT NULL,
	                        [ColumnType] [nvarchar](50) NOT NULL,
	                        [FormID] [int] NULL)";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
        
        
        
        }




        public object[] GetMappingTableColumnGroupbyValue()
        { 
        string query = "select TargetTableName from SBP_CDBLtextFileMapping group by TargetTableName";


            try
            {
                _dbConnection.ConnectDatabase();
                DataTable data = _dbConnection.ExecuteQuery(query);
                var ColumValueArray = (from DataRow myRow in data.Rows select myRow[0]).ToArray();
                //Array to Comma separated value

                return ColumValueArray;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }

        }



     //--------------btn Report---------- 


        public DataTable ReportDP29MisMatchTableQuery(string queryString)
        {

            try
            {
                _dbConnection.ConnectDatabase();
                var data = _dbConnection.ExecuteQuery(queryString);

                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }

        }





    }
}
