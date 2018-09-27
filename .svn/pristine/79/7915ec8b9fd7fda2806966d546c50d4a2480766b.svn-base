using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DataAccessLayer;
using System.Data.SqlClient;
using BusinessAccessLayer.BO;

namespace BusinessAccessLayer.BAL
{
    public class IPOShareBAL
    {
        private DbConnection _dbConnection;
        public IPOShareBAL()
        {
            _dbConnection = new DbConnection();
        }

        public void ConnectDatabase()
        {
            _dbConnection.ConnectDatabase();
            _dbConnection.StartTransaction();
        }

        public void CloseDatabase()
        {
            _dbConnection.CloseDatabase();
        }

        public void Commit()
        {
            _dbConnection.Commit();
        }

        public void RollBack()
        {
            _dbConnection.Rollback();
        }

        public SqlTransaction GetTransaction()
        {
            return _dbConnection.GetTransaction();
        }

        /// Added By Shahrior On 27 Jan 2015       
        public void SetTransaction(SqlTransaction trans)
        {
            _dbConnection.SetTransaction(trans);
        }

        public DbConnection GetConnection()
        {
            return _dbConnection;
        }

        public void SetConnection(DbConnection con)
        {

            _dbConnection = con;
        }

        public void SaveProcessedIPOShareInfo(DataTable ipoShareDataTable, string tableName)
        {
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.BulkCopy(ipoShareDataTable, tableName);
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

        public DataTable ValidateBOID()
        {
            DataTable dataTable;
            string queryString = "SELECT DISTINCT(BO_ID) From SBP_16DP95UX WHERE BO_ID NOT IN (SELECT BO_ID From SBP_Customers)";
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

        public DataTable ValidateCompany()
        {
            DataTable dataTable;
            string queryString = "SELECT DISTINCT(ISIN_No) From SBP_16DP95UX WHERE ISIN_No NOT IN (SELECT ISIN_No From SBP_Company)";
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

        public bool IsUploadMainTable()
        {
            DataTable dataTable;
            string queryString = "SELECT Upload_Date From SBP_Upload_History WHERE File_Name='16DP95UX' AND Uplaod_Date IN(Select Date From SBP_16DP95UX)";
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
            string queryString = "SELECT ISIN_No as 'ISIN No',ISIN_Short_Name as 'Company Short Name',Effective_Date as 'Effective Date',BO_ID as 'BO ID',Current_Balance as 'Current Balance',Lockedin_Balance as 'Lockin Balance' From SBP_16DP95UX";
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

        public DataTable GetGridData_UTTransApplied()
        {
            DataTable dataTable;
            string queryString = "SELECT ISIN_No as 'ISIN No',ISIN_Short_Name as 'Company Short Name',Effective_Date as 'Effective Date',BO_ID as 'BO ID',Current_Balance as 'Current Balance',Lockedin_Balance as 'Lockin Balance' From SBP_16DP95UX";
            try
            {
                //_dbConnection.ConnectDatabase();
                dataTable = _dbConnection.ExecuteQuery(queryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                //_dbConnection.CloseDatabase();
            }
            return dataTable;

        }

        public void SaveIntoShareDW()
        {
            string queryStringInsShareDW = "";
            string queryStringInsHistory = "";
            string queryStringUploadHistory = "";
            queryStringInsShareDW = "INSERT INTO SBP_Share_DW(Cust_Code,Comp_Short_Code,Quantity,Lockedin_Quantity,Available_Quantity,Issue_Price,Received_Date,Effective_Date,Deposit_Withdraw,Deposit_Type,Share_Type,Issue_Amount,Entry_Date,Entry_By)SELECT dbo.GetCustCodeFromBO(BO_ID),dbo.GetCompShortCodeFromISINNo(ISIN_No),Current_Balance,Lockedin_Balance,Current_Balance-Lockedin_Balance,Issue_Price,Effective_Date,Effective_Date,'Deposit','IPO','CDBL',Issue_Price*Current_Balance,Getdate(),'" + GlobalVariableBO._userName + "' From SBP_16DP95UX";

            queryStringInsHistory = "INSERT INTO SBP_16DP95UX_History(ISIN_No,ISIN_Short_Name,Sequence_No,Effective_Date,BO_ID,BO_Short_Name,BO_Category,BO_Account_Status,Current_Balance,Lockedin_Balance,Proc_Flag,un1,un2,un3,Issue_Price,CA_Type)" +
             "SELECT ISIN_No,ISIN_Short_Name,Sequence_No,Effective_Date,BO_ID,BO_Short_Name,BO_Category,BO_Account_Status,Current_Balance,Lockedin_Balance,Proc_Flag,un1,un2,un3,Issue_Price,CA_Type FROM SBP_16DP95UX";
            
            CommonBAL comBAL = new CommonBAL();
            long slNo = comBAL.GenerateID("SBP_Upload_History", "Upload_ID");
            queryStringUploadHistory = "INSERT INTO SBP_Upload_History(Upload_ID,File_Name,Upload_Date,Entry_By) SELECT TOP 1 " + slNo + ",'16DP95UX',Effective_Date,'" + GlobalVariableBO._userName + "' FROM SBP_16DP95UX";

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();
                _dbConnection.ExecuteNonQuery(queryStringInsShareDW);
                _dbConnection.ExecuteNonQuery(queryStringInsHistory);
                _dbConnection.ExecuteNonQuery(queryStringUploadHistory);
                _dbConnection.Commit();
            }
            catch (Exception exception)
            {
                _dbConnection.Rollback();
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
        }

        public void SaveIntoShareDW_UITran(DbConnection connection)
        {
            string queryStringInsShareDW = "";
            string queryStringInsHistory = "";
            string queryStringUploadHistory = "";
            queryStringInsShareDW = "INSERT INTO SBP_Share_DW(Cust_Code,Comp_Short_Code,Quantity,Lockedin_Quantity,Available_Quantity,Issue_Price,Received_Date,Effective_Date,Deposit_Withdraw,Deposit_Type,Share_Type,Issue_Amount,Entry_Date,Entry_By)SELECT dbo.GetCustCodeFromBO(BO_ID),dbo.GetCompShortCodeFromISINNo(ISIN_No),Current_Balance,Lockedin_Balance,Current_Balance-Lockedin_Balance,Issue_Price,Effective_Date,Effective_Date,'Deposit','IPO','CDBL',Issue_Price*Current_Balance,Getdate(),'" + GlobalVariableBO._userName + "' From SBP_16DP95UX";

            queryStringInsHistory = "INSERT INTO SBP_16DP95UX_History(ISIN_No,ISIN_Short_Name,Sequence_No,Effective_Date,BO_ID,BO_Short_Name,BO_Category,BO_Account_Status,Current_Balance,Lockedin_Balance,Proc_Flag,un1,un2,un3,Issue_Price,CA_Type)" +
             "SELECT ISIN_No,ISIN_Short_Name,Sequence_No,Effective_Date,BO_ID,BO_Short_Name,BO_Category,BO_Account_Status,Current_Balance,Lockedin_Balance,Proc_Flag,un1,un2,un3,Issue_Price,CA_Type FROM SBP_16DP95UX";

            CommonBAL comBAL = new CommonBAL();
            long slNo = comBAL.GenerateID("SBP_Upload_History", "Upload_ID");
            queryStringUploadHistory = "INSERT INTO SBP_Upload_History(Upload_ID,File_Name,Upload_Date,Entry_By) SELECT TOP 1 " + slNo + ",'16DP95UX',Effective_Date,'" + GlobalVariableBO._userName + "' FROM SBP_16DP95UX";

            try
            {
                //_dbConnection.ConnectDatabase();
                //_dbConnection.StartTransaction();
                connection.ExecuteNonQuery(queryStringInsShareDW);
                connection.ExecuteNonQuery(queryStringInsHistory);
                connection.ExecuteNonQuery(queryStringUploadHistory);
                //_dbConnection.Commit();
            }
            catch (Exception exception)
            {
                //_dbConnection.Rollback();
                throw exception;
            }
            //finally
            //{
            //    //_dbConnection.CloseDatabase();
            //}
        }

        public DataTable GetGridIssueAmount()
        {
            DataTable dataTable;
            string queryString = "SELECT ISIN_No as 'ISIN No', ISIN_Short_Name as 'Company Name',Issue_Price as 'Issue Price' From SBP_16DP95UX Group By ISIN_No, ISIN_Short_Name,Issue_Price";
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


        public void TruncateIPOTemp()
        {
            string queryString = "";
            queryString = "TRUNCATE TABLE SBP_16DP95UX";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();
                _dbConnection.ExecuteNonQuery(queryString);
                _dbConnection.Commit();
            }
            catch (Exception exception)
            {
                _dbConnection.Rollback();
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
        }

       
        public void UpdateIssueAmount(string ISINNo, float issuePrice)
        {
            string queryStringUpdateTemp = "";
            //queryStringUpdateTemp = "UPDATE  SBP_16DP95UX SET Issue_Price=" + issuePrice + " WHERE ISIN_Short_Name='" + companyName + "'";
            queryStringUpdateTemp = @"UPDATE SBP_16DP95UX
            SET Issue_Price=" + issuePrice + @"
            WHERE ISIN_No='" + ISINNo + "'";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();
                _dbConnection.ExecuteNonQuery(queryStringUpdateTemp);
                _dbConnection.Commit();
            }
            catch (Exception exception)
            {
                _dbConnection.Rollback();
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
        }
    }
}
