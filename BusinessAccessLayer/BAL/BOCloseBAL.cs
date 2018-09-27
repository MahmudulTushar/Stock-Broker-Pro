using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DataAccessLayer;
using BusinessAccessLayer.BO;

namespace BusinessAccessLayer.BAL
{
    public class BOCloseBAL
    {
        private DbConnection _dbConnection;
        public BOCloseBAL()
        {
            _dbConnection = new DbConnection();
        }
        public void SaveProcessedBOCloseInfo(DataTable boCloseDataTable, string tableName)
        {
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.BulkCopy(boCloseDataTable, tableName);
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
            string queryString = "SELECT DISTINCT(BO_ID) From SBP_08DP04UX WHERE BO_ID NOT IN (SELECT BO_ID From SBP_Customers)";
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

        public void UpdateBOCloseInfo()
        {
            string queryStringCustomers = "";
            string queryStringInsHistory = "";
            string queryStringUploadHistory = "";
            queryStringCustomers = "UPDATE SBP_Customers SET BO_Status_ID=2,BO_Close_Date=(Select TOP 1 Closure_Date FROM SBP_08DP04UX)WHERE BO_ID IN(Select SUBSTRING(BO_ID,9,8) FROM SBP_08DP04UX)";
            queryStringInsHistory = "INSERT INTO SBP_08DP04UX_History(BO_ID,BO_Name,Closure_Date,Request_Date,Reason_Failure,Remarks,File_Date) SELECT BO_ID,BO_Name,Closure_Date,Request_Date,Reason_Failure,Remarks,File_Date FROM SBP_08DP04UX";
            CommonBAL comBAL = new CommonBAL();
            long slNo = comBAL.GenerateID("SBP_Upload_History", "Upload_ID");
            queryStringUploadHistory = "INSERT INTO SBP_Upload_History(Upload_ID,File_Name,Upload_Date,Entry_By) SELECT TOP 1 " + slNo + ",'08DP04UX',File_Date,'" + GlobalVariableBO._userName + "' FROM SBP_08DP04UX";


            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();
                _dbConnection.ExecuteNonQuery(queryStringCustomers);
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
        public void All_CDBLClose_To_SBP_CustCode_Close(string[] Bo_ID)
        {
            string query = string.Empty;
            try
            {
                foreach (string Value in Bo_ID)
                {
                    query = @"UPDATE [dbo].[SBP_Customers] 
                            SET Cust_Status_ID = 2
		                        ,BO_Close_Date=GETDATE()
                           WHERE BO_ID IN ('" + Value + "')";
                    _dbConnection.ConnectDatabase();                  
                    _dbConnection.ExecuteNonQuery(query);
                    _dbConnection.CloseDatabase();
                }
            }
            catch (Exception ex)
            {
                _dbConnection.Rollback();
                throw ex;
            }
            finally
            {
                //_dbConnection.CloseDatabase();
            }
        }
        public DataTable GetGridData()
        {
            DataTable dataTable;
            string queryString = "SELECT BO_ID as 'BO ID',BO_Name as 'BO Name',Closure_Date as 'Closure Date',Request_Date as 'Request Date',Reason_Failure as 'Reason Failure',Remarks From SBP_08DP04UX";
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

        public void TruncatBOCloseTemp()
        {
            string queryString = "";
            queryString = "TRUNCATE TABLE SBP_08DP04UX";
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
    }
}
