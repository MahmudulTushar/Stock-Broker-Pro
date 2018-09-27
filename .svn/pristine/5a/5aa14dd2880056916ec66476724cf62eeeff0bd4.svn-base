using System;
using System.Data;
using BusinessAccessLayer.BO;
using DataAccessLayer;


namespace BusinessAccessLayer.BAL
{
    public class Expense_CategoryEntryBAL
    {
        private DbConnection _dbConnection;
        public Expense_CategoryEntryBAL()
        {
            _dbConnection = new DbConnection();
        }
        public void SaveCategory(Expense_CategoryEntryBO categoryEntryBo)
        {
            string queryString = "";
            CommonBAL cmnBAL=new CommonBAL();
            queryString =
                @"INSERT INTO SBP_Expense_Category_Lookup
                       ([Category_Name]
                       ,[Category_Type_ID]
                       ,[Sub_Category]
                       ,[Update_Date]
                       )
                 VALUES
                       ("
                        +"'" + categoryEntryBo.Category_Name
                        +"',"+categoryEntryBo.Category_Type_ID
                        +",'"+categoryEntryBo.Sub_Category
                        +"','"+cmnBAL.GetCurrentServerDate().ToShortDateString()
                       +"')";
                               
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

        public DataTable GetAllCategory()
        {
            DataTable dataTable;
            string queryString = @"SELECT 
                                        Category_ID
                                       ,[Category_Name]
                                       ,ecl.[Category_Type_ID]
                                       ,[Category_Type]
                                       ,[Sub_Category]
                                       ,ecl.[Update_Date]
                                  FROM SBP_Expense_Category_Lookup AS ecl
                                  JOIN dbo.SBP_Expense_Category_Type AS ct
                                  ON ecl.Category_Type_ID=ct.Category_Type_ID";
            try
            {
                _dbConnection.ConnectDatabase();
                dataTable = _dbConnection.ExecuteQuery(queryString);
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

        public DataTable GetAllCategoryType()
        {
            DataTable dataTable;
            string queryString = @"SELECT [Category_Type_ID]
                                          ,[Category_Type]
                                   FROM SBP_Expense_Category_Type";
            try
            {
                _dbConnection.ConnectDatabase();
                dataTable = _dbConnection.ExecuteQuery(queryString);
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

        public void Update(Expense_CategoryEntryBO categoryEntryBo, int CategoryIdForUpdate)
        {
            string queryStringIns = "";
            CommonBAL cmnBAL=new CommonBAL();
            queryStringIns = @"UPDATE SBP_Expense_Category_Lookup
                               SET [Category_Name] ='" + categoryEntryBo.Category_Name + "'"
                              + ",[Category_Type_ID] = " + categoryEntryBo.Category_Type_ID 
                              + ",[Sub_Category] = '" + categoryEntryBo.Sub_Category + "'"
                              + ",[Update_Date] = '" + cmnBAL.GetCurrentServerDate().ToShortDateString() + "'"
                              + " WHERE Category_ID=" + CategoryIdForUpdate;
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(queryStringIns);
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

        public bool CheckCategoryDuplicate(string Category)
        {
            DataTable dataTable;
            string queryString = "";
            queryString = "SELECT * FROM SBP_Expense_Category_Lookup WHERE Category_Name='" + Category + "'";
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
        public void DeleteCategory(int CategoryIdForDelete)
        {
            string queryString = "";
            queryString = "DELETE FROM SBP_Expense_Category_Lookup WHERE Category_ID=" + CategoryIdForDelete;
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
    }
}

