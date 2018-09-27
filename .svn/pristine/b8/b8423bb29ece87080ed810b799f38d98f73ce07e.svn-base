using System;
using System.Data;
using BusinessAccessLayer.BO;
using DataAccessLayer;


namespace BusinessAccessLayer.BAL
{
    public class ExpenseEntryBAL
    {
        private DbConnection _dbConnection;
        
        public ExpenseEntryBAL()
        {
            _dbConnection = new DbConnection();
        }

        public void SaveExpense(ExpenseEntryBO expenseEntryBo)
        {
            string queryString = "";
            CommonBAL cmnBAL=new CommonBAL();
            queryString =
                @"INSERT INTO SBP_Expense_Lookup
                       (
                        [Category_ID]
                       ,[Expense_Description]
                       ,[Frequency_ID]
                       ,[Update_Date]
                       ,[Expense_Type_ID]
                        )
                 VALUES
                       ("
                        + expenseEntryBo.Category_ID
                        + ",'" + expenseEntryBo.Expense_Description
                        + "'," + expenseEntryBo.Expense_Frequency
                        +",'"+cmnBAL.GetCurrentServerDate().ToShortDateString()
                        +@",( Select b.Category_Type_ID 
                        From dbo.SBP_Expense_Category_Lookup as b Where b.Category_ID=" + expenseEntryBo.Category_ID + @")"
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

        public DataTable GetAllExpense()
        {
            DataTable dataTable;
            string queryString = @"SELECT 
                                     Expense_ID
                                    ,ecl.Category_Name
                                    ,Expense_Description
                                    ,el.Frequency_ID
                                    ,Frequency_Name
                                    ,el.Update_Date
                                    FROM dbo.SBP_Expense_Lookup AS el
                                    JOIN dbo.SBP_Expense_Category_Lookup AS ecl
                                    ON el.Category_ID=ecl.Category_ID
                                    JOIN dbo.SBP_Expense_Frequency AS ef
                                    ON el.Frequency_ID=ef.Frequency_ID";
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

        public void Update(ExpenseEntryBO expenseEntryBo, int expenseIdForUpdate)
        {
            string queryStringIns = "";
            CommonBAL cmnBAL=new CommonBAL();
            queryStringIns = @"UPDATE SBP_Expense_Lookup
                               SET [Category_ID] =" + expenseEntryBo.Category_ID 
                              + ",[Expense_Description] = '" + expenseEntryBo.Expense_Description + "'"
                              + ",[Frequency_ID] = " + expenseEntryBo.Expense_Frequency 
                              + ",[Update_Date] = '" + cmnBAL.GetCurrentServerDate().ToShortDateString() + "'"
                              + " WHERE Expense_ID=" + expenseIdForUpdate;
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

        public bool CheckExpenseDuplicate(int category_ID)
        {
            DataTable dataTable;
            string queryString = "";
            queryString = "SELECT * FROM SBP_Expense_Lookup WHERE Category_ID=" + category_ID ;
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

        public void DeleteExpense(int expenseIdForDelete)
        {
            string queryString = "";
            queryString = "DELETE FROM SBP_Expense_Lookup WHERE Expense_ID=" + expenseIdForDelete;
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

        public DataTable GetCategory()
        {
            DataTable dataTable=new DataTable();
            string queryString = @"SELECT Category_ID, [Category_Type_ID],Category_Name      
                                  FROM SBP_Expense_Category_Lookup";
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

        public DataTable GetCategoryType()
        {
            DataTable dt = new DataTable();

            string queryString = @"SELECT [Category_Type_ID],[Category_Type]
                                FROM [SBP_Database].[dbo].[SBP_Expense_Category_Type]";
            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(queryString);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }

            return dt;
        }

        public DataTable GetExpenseFrequency()
        {
            DataTable dataTable = new DataTable();
            string queryString = @"SELECT [Frequency_ID]
                                      ,[Frequency_Name]
                                  FROM SBP_Expense_Frequency";
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
       
        public DataTable GetExpense()
        {
            DataTable dataTable = new DataTable();
            string queryString = @" SELECT 
                                           [Expense_ID]
                                          ,[Expense_Description]
                                    FROM SBP_Expense_Lookup ";
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

        public DataTable GetReport(int CatgId,int FreqId, int BranchID, DateTime FromDate,DateTime ToDate,bool IsExpenseDate)
        {
            DataTable dataTable = new DataTable();
            string queryString = @"RptGetExepenseReport"; 
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@ExpenseCatgType_ID", SqlDbType.Int, CatgId);
                _dbConnection.AddParameter("@ExpenseFrequency", SqlDbType.Int, FreqId);
                _dbConnection.AddParameter("@Branch_ID", SqlDbType.Int, BranchID);
                _dbConnection.AddParameter("@FromDate", SqlDbType.DateTime, FromDate);
                _dbConnection.AddParameter("@ToDate", SqlDbType.DateTime, ToDate);
                _dbConnection.AddParameter("@IsExpenseDate", SqlDbType.Bit, IsExpenseDate);
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

        /// <summary>
        /// Showing Monthly Expense Report Only
        /// Rashedul hasan
        /// </summary>
        /// <param name="From"></param>
        /// <param name="To"></param>
        /// <param name="ExpenseOrPayment">New add on 28 july 2015</param>
        /// <returns></returns>
        public DataTable GetMonthlyExpenseReport(DateTime From, DateTime To, string ExpenseOrPayment)
        {
            DataTable dt = new DataTable();
            string query = @"RptMonthlyExpensereport";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@Form", SqlDbType.Date, From.Date);
                _dbConnection.AddParameter("@To", SqlDbType.Date, To.Date);
                _dbConnection.AddParameter("@AccordingToSorting", SqlDbType.VarChar, ExpenseOrPayment);
                dt = _dbConnection.ExecuteProQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dt;
        }

        ///// <summary>
        ///// Showing Monthly Expense Report Only
        ///// Rashedul hasan
        ///// </summary>
        ///// <param name="From"></param>
        ///// <param name="To"></param>
        ///// <returns></returns>
        //public DataTable GetMonthlyExpenseReport(DateTime From, DateTime To)
        //{
        //    DataTable dt = new DataTable();
        //    string query = @"RptMonthlyExpensereport";
        //    try
        //    {
        //        _dbConnection.ConnectDatabase();
        //        _dbConnection.ActiveStoredProcedure();
        //        _dbConnection.AddParameter("@Form", SqlDbType.Date, From.Date);
        //        _dbConnection.AddParameter("@To", SqlDbType.Date, To.Date);
        //        dt = _dbConnection.ExecuteProQuery(query);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        _dbConnection.CloseDatabase();
        //    }
        //    return dt;
        //}
    }
}

