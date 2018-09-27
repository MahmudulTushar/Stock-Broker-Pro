using System;
using System.Data;
using BusinessAccessLayer.BO;
using DataAccessLayer;


namespace BusinessAccessLayer.BAL
{
    public class Expense_Frequency_EntryBAL
    {
        private DbConnection _dbConnection;
        public Expense_Frequency_EntryBAL()
        {
            _dbConnection = new DbConnection();
        }
        public void SaveCategory(string OCCType)
        {
            string queryString = "";
            CommonBAL cmnBAL=new CommonBAL();
            queryString = @"INSERT INTO SBP_Expense_Frequency
                               (
                               [Frequency_Name]
                               ,[Entry_By]
                               ,[Entry_Date]
                               )
                         VALUES
                               ('"
                              + OCCType 
                              +"','" +GlobalVariableBO._userName 
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

        public DataTable GetAllOCCType()
        {
            DataTable dataTable;
            string queryString = @"SELECT 
                                       [Frequency_ID]
                                      ,[Frequency_Name]
                                      ,[Entry_By]
                                      ,[Entry_Date]
                                  FROM SBP_Expense_Frequency";
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

        public void Update(string OCCType, int OCCTypeIdForUpdate)
        {
            string queryStringIns = "";
            CommonBAL cmnBAL=new CommonBAL();
            queryStringIns = @"UPDATE SBP_Expense_Frequency
                               SET [Frequency_Name] ='"+OCCType +"'" 
                              +",[Entry_By] = '"+GlobalVariableBO._userName +"'"
                              + ",[Entry_Date] = '"+cmnBAL.GetCurrentServerDate().ToShortDateString()+"'"
                              +" WHERE Frequency_ID=" +OCCTypeIdForUpdate ;
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

        public bool CheckOCCTypeDuplicate(string OCCType)
        {
            DataTable dataTable;
            string queryString = "";
            queryString = "SELECT * FROM SBP_Expense_Frequency WHERE Frequency_Name='" + OCCType + "'";
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
        public void DeleteOCCType(int OCCTypeIdForDelete)
        {
            string queryString = "";
            queryString = "DELETE FROM SBP_Expense_Frequency WHERE Frequency_ID=" + OCCTypeIdForDelete;
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

