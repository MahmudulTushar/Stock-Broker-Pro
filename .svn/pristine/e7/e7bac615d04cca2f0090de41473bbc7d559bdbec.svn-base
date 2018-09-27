using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DataAccessLayer;
using BusinessAccessLayer.BO;

namespace BusinessAccessLayer.BAL
{
    public class DematBAL
    {
        private DbConnection _dbConnection;

        public DematBAL()
        {
            _dbConnection = new DbConnection();
        }

        public void SaveProcessedDematInfo(DataTable dematDataTable, string tableName)
        {
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.BulkCopy(dematDataTable, tableName);
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

        public DataTable GetGridData()
        {
            DataTable dataTable;
            string queryString = "SELECT DRN,DRF,ISIN_No as 'ISIN No',ISIN_Short_Name as 'Company Short Name',BO_ID as 'BO ID',Status,Requested_Qty,Accepted_Qty,Rejected_Qty,Balance_Type,DR_Flag From SBP_16DP61UX";
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

        public DataTable ValidateISINNo()
        {
            DataTable dataTable;
            string queryString = "SELECT DISTINCT(ISIN_No) From SBP_16DP61UX WHERE ISIN_No NOT IN (SELECT ISIN_No From SBP_Company)";
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

        public DataTable ValidateBOID()
        {
            DataTable dataTable;
            string queryString = "SELECT DISTINCT(BO_ID) From SBP_16DP61UX WHERE BO_ID NOT IN (SELECT BO_ID From SBP_Customers)";
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

        public void SaveIntoShareDW()
        {
            string queryStringInsShareDW = "";
            string queryStringInsHistory = "";
            string queryStringUploadHistory = "";
            queryStringInsShareDW =
                " INSERT INTO SBP_Share_DW(Cust_Code,Comp_Short_Code,Quantity,Lockedin_Quantity,Available_Quantity,Issue_Price,Issue_Amount,Share_Type,Effective_Date,Received_Date,Deposit_Withdraw,Deposit_Type,Entry_Date,Entry_By) " +
                " SELECT DISTINCT dbo.GetCustCodeFromBO(tempShare.BO_ID),dbo.GetCompShortCodeFromISINNo(tempShare.ISIN_No),tempShare.Accepted_Qty,0,tempShare.Accepted_Qty,tempShare.Issue_Price,tempShare.Accepted_Qty*tempShare.Issue_Price,'CDBL',tempShare.File_Date,tempShare.File_Date,'Deposit',tempShare.CA_Type,Getdate(),'" + GlobalVariableBO._userName + "' " +
                " FROM (SELECT DISTINCT * FROM dbo.SBP_16DP61UX WHERE  Status='Confirmed') tempShare ";
           
            queryStringInsHistory = "INSERT INTO SBP_16DP61UX_History(DRN,DRF,ISIN_No,ISIN_Short_Name,BO_ID,BO_Short_Name,Status,Requested_Qty,Accepted_Qty,Rejected_Qty,Balance_Type,Cert_No,Folio_No,Cert_Qty,Cert_Status,DNR_Start,DNR_End,Cert_Seq_No,Range_Serial_No,DR_Flag,File_Date,CA_Type) SELECT DRN,DRF,ISIN_No,ISIN_Short_Name,BO_ID,BO_Short_Name,Status,Requested_Qty,Accepted_Qty,Rejected_Qty,Balance_Type,Cert_No,Folio_No,Cert_Qty,Cert_Status,DNR_Start,DNR_End,Cert_Seq_No,Range_Serial_No,DR_Flag,File_Date,CA_Type FROM SBP_16DP61UX";
            CommonBAL comBAL = new CommonBAL();
            long slNo = comBAL.GenerateID("SBP_Upload_History", "Upload_ID");
            queryStringUploadHistory = "INSERT INTO SBP_Upload_History(Upload_ID,File_Name,Upload_Date,Entry_By) SELECT TOP 1 " + slNo + ",'16DP61UX',File_Date,'" + GlobalVariableBO._userName + "' FROM SBP_16DP61UX";


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
        public void TruncateDematTemp()
        {
            string queryString = "";
            queryString = "TRUNCATE TABLE SBP_16DP61UX";
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

        public DataTable GetGridIssueAmount()
        {
            DataTable dataTable;
            string queryString = "SELECT DISTINCT(ISIN_Short_Name) as 'Company Name',CA_Type as 'Deposit Type',Issue_Price as 'Issue Price' From SBP_16DP61UX";
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

        public void UpdateIssueAmount(string companyName, float issuePrice)
        {
            string queryStringUpdateTemp = "";
            queryStringUpdateTemp = "UPDATE  SBP_16DP61UX SET Issue_Price=" + issuePrice + " WHERE ISIN_Short_Name='" + companyName + "'";
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
