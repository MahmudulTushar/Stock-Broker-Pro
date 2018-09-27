using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DataAccessLayer;
using BusinessAccessLayer.BO;

namespace BusinessAccessLayer.BAL
{
    public class BonusBAL
    {
     private DbConnection _dbConnection;

         public BonusBAL()
        {
            _dbConnection = new DbConnection();
        }
         public void SaveProcessedBonusRightShare(DataTable bonusRightDataTable, string tableName)
        {
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.BulkCopy(bonusRightDataTable, tableName);
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
            string queryString = "SELECT ISIN_Short_Name as 'Company Short Name',BO_ID as 'BO ID',Total_Entitlement as 'Share Quantity',CA_Type as 'Deposit Type',Record_Date as 'Record Date',Effective_Date as 'Effective Date' From SBP_17DP70UX WHERE CA_Type='BONUS'";
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
            string queryString = "SELECT DISTINCT(ISIN_No) From SBP_17DP70UX WHERE ISIN_No NOT IN (SELECT ISIN_No From SBP_Company) AND CA_Type='BONUS'";
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
            string queryString = "SELECT DISTINCT(BO_ID) From SBP_17DP70UX WHERE BO_ID NOT IN (SELECT BO_ID From SBP_Customers) AND CA_Type='BONUS'";
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
            queryStringInsShareDW = "INSERT INTO SBP_Share_DW(Cust_Code,Comp_Short_Code,Quantity,Lockedin_Quantity,Available_Quantity,Share_Type,Issue_Price,Issue_Amount,Effective_Date,Received_Date,Record_Date,Deposit_Withdraw,Deposit_Type,Entry_Date,Entry_By)"
            + "SELECT dbo.GetCustCodeFromBO(BO_ID),dbo.GetCompShortCodeFromISINNo(ISIN_No),Total_Entitlement,0,Total_Entitlement,'CDBL',Issue_Price,Issue_Price*Total_Entitlement,Effective_Date,Effective_Date,Record_Date,(CASE WHEN(DR_CR_Flag='CREDIT') THEN 'Deposit' ELSE 'Withdraw' END),CA_Type,Getdate(),'" + GlobalVariableBO._userName + "' From SBP_17DP70UX WHERE CA_Type='BONUS'";

            queryStringInsHistory = "INSERT INTO  SBP_17DP70UX_History(ISIN_No,ISIN_Short_Name,Sequence_No,CA_Type,Record_Date,Effective_Date,Cash_Fraction_Amount,Payment_Date,Benefit_ISIN,Benefit_ISIN_Short_Name,BO_ID,BO_Short_Name,BO_Holding,DR_CR_Flag,Total_Entitlement,Parent_Ration,Benefit_Ration,un1,un2,un3,Issue_Price)" +
                "SELECT ISIN_No,ISIN_Short_Name,Sequence_No,CA_Type,Record_Date,Effective_Date,Cash_Fraction_Amount,Payment_Date,Benefit_ISIN,Benefit_ISIN_Short_Name,BO_ID,BO_Short_Name,BO_Holding,DR_CR_Flag,Total_Entitlement,Parent_Ration,Benefit_Ration,un1,un2,un3,Issue_Price From SBP_17DP70UX WHERE CA_Type='BONUS'";
            CommonBAL comBAL = new CommonBAL();
            long slNo = comBAL.GenerateID("SBP_Upload_History", "Upload_ID");
            queryStringUploadHistory = "INSERT INTO SBP_Upload_History(Upload_ID,File_Name,Upload_Date,Entry_By) SELECT TOP 1 " + slNo + ",'17DP70UX_Bonus',Effective_Date,'" + GlobalVariableBO._userName + "' FROM SBP_17DP70UX WHERE CA_Type='BONUS'";
            
          
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

        public DataTable GetGridIssueAmount()
        {
            DataTable dataTable;
            string queryString = "SELECT DISTINCT(ISIN_Short_Name) as 'Company Name',CA_Type as 'Deposit Type',Issue_Price as 'Issue Price' From SBP_17DP70UX WHERE CA_Type='BONUS'";
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

        public void TruncateBonusTemp()
        {
            string queryString = "";
            queryString = "TRUNCATE TABLE SBP_17DP70UX";
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

        public void UpdateIssueAmount(string companyName, float issuePrice)
        {
            string queryStringUpdateTemp = "";
            queryStringUpdateTemp = "UPDATE  SBP_17DP70UX SET Issue_Price=" + issuePrice + " WHERE ISIN_Short_Name='" + companyName + "' AND CA_Type='BONUS'";
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
