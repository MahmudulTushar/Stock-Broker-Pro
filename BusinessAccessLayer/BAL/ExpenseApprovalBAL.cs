using System;
using System.Data;
using BusinessAccessLayer.BO;
using DataAccessLayer;

namespace BusinessAccessLayer.BAL
{
    public class ExpenseApprovalBAL
    {
        private DbConnection _dbConnection;
        public ExpenseApprovalBAL()
        {
            _dbConnection = new DbConnection();
        }

        public DataTable GetExpenseApproveList()
        {
            DataTable dataTable;
            string queryString = @"SELECT [Transaction_ID]                                      
	                                      ,Expense_Description AS [Expense]            
	                                      ,Category_Name AS [Category]
	                                      ,(select Sub_Category_Type_Name 
		                                    from SBP_Expense_Sub_Category_Type as sub
		                                    where Sub_Category_Type_ID=et.subCatagory_ID ) as 'AssetName'
	                                      ,[Expense_Date] AS [Expense_Date]
	                                      ,[Payment_Date] AS [Payment_Date]
	                                      ,Quantity as Qty
	                                      ,Rate
	                                      ,[Amount] AS [Amount]
	                                      --,[Quantity] AS [Quantity]
	                                     ,et.Voucher_ID AS [Voucher_ID] 
	                                     ,(	Select t.Voucher_No 
			                                    From SBP_Expense_Voucher as t 
			                                    Where t.[Voucher_ID]=et.[Voucher_ID]
	                                      ) AS [Voucher_No]
	                                      ,[Purchaser_Emp_ID] AS [Purchaser]
	                                      ,et.[Entry_By] AS [Entry By]
	                                      ,[Entry_Date_Time] AS [Entry Date]
	                                      , CASE WHEN [Approval_Status]=0 THEN 'Pending'
			                                     WHEN [Approval_Status]=1 THEN 'Approved'
		                                    END  AS [Status]
	                                      --,[Approved_By]  AS [Approved By]
	                                      --,[Approval_date]  AS [Approval date]
	                                      ,Branch_Name AS [Branch]
	                                      ,[Remarks]  AS [Remarks]
	                                      ,et.Payment_Media as [Payment_Media]
	                                      ,et.Pay_Bank_Name as [Bank_Name]
	                                      ,et.Bank_Account_No as [Account_No]
	                                      ,et.Pay_Cheque_No as [Cheque_No]
	                                      --,subCatagory_ID as [Sub_CatagoryID]
	                                      ,et.Expense_ID
	                                      ,et.Category_ID
                                    FROM SBP_Expense_Transaction AS et
                                    INNER JOIN SBP_Expense_Lookup AS el
                                    ON et.Expense_ID=el.Expense_ID
                                    INNER JOIN SBP_Expense_Category_Lookup AS ecl
                                    ON et.Category_ID=ecl.Category_ID
                                    INNER JOIN SBP_Broker_Branch AS bb
                                    ON et.Branch_ID=bb.Branch_ID
                                    WHERE et.Approval_Status=0";
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

        public void ApproveSelectedExpense(int trnId)
        {

            string queryString = "UPDATE SBP_Expense_Transaction SET Approval_Status=1, Approval_date=Convert(varchar(10),GETDATE(),111) WHERE Transaction_ID=" + trnId;
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
        public void ApproveSelectedIncome(int RctID, string appvDate)
        {
            string queryString = @"update SBP_IncomeEntry set Status='Approved', UpdateDate='" + appvDate + "' where ReceiptNo IN(" + RctID + ")";
           // string queryBasic = @"UPDATE SBP_IPO_Application_BasicInfo SET Application_Satus=1 WHERE ID IN(" + BasInfoID + @")";

            try
            {
                _dbConnection.ConnectDatabase();

                //if (BasInfoID != null)
                //{
                //    _dbConnection.ExecuteNonQuery(queryBasic);
                //    _dbConnection.ExecuteNonQuery(queryString);
                //}
                //else
                //{ 
                    _dbConnection.ExecuteNonQuery(queryString);
                //}
                
            }
            catch (Exception EX)
            {
                throw EX;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
        }
        public void DeleteReceivedOfficeExpense(DateTime Rdate, string voucherNo)
        {

            string queryString = @"delete AccTransaction where PDate='" + Rdate.ToString("yyyy-MM-dd") + "' and VoucherNo='" + voucherNo + "'";
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
        public void DeleteIncome(int RctID)
        {

            string queryString = @"delete SBP_IncomeEntry where ReceiptNo="+RctID+"";
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
        public void RejectSelectedIncom(int RctID, string appvDate)
        {

            string queryString = @"update SBP_IncomeEntry set Status='Rejected', UpdateDate='" + appvDate + "' where ReceiptNo IN(" + RctID + ")";
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
        public void ApproveAllSelectedIncome(string RctID, string appvDate)
        {

            string queryString = @"update SBP_IncomeEntry set Status='Approved', UpdateDate='" + appvDate + "' where ReceiptNo IN(" + RctID + ")";
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
        public void RejectAllSelectedIncome(string RctID, string appvDate)
        {

            string queryString = @"update SBP_IncomeEntry set Status='Rejected', UpdateDate='" + appvDate + "' where ReceiptNo IN(" + RctID + ")";
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

        public void RejectSelectedExpense(int expenseId)
        {

            string queryString = "UPDATE SBP_Expense_Transaction SET Status=2  WHERE Transaction_ID=" + expenseId;
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

        public byte[] GetVoucherByte(int voucherID)
        {
            byte[] voucherByte = null;
            string queryString = "";
            string queryString_ImgExt = "";
            queryString =
                @" SELECT 
                  Voucher_Image as Voucher_Image 
                  FROM SBP_Expense_Voucher 
                  WHERE 
                  Voucher_ID=" + voucherID + "";

            queryString_ImgExt =
                @"SELECT Voucher_Image
                                FROM [SBP_Database_ImageExt].[dbo].[SBP_Expense_Voucher_ImgExt]
                                WHERE Voucher_ID=" + voucherID;

            DataTable dtRecordInfo = new DataTable();
            DataTable dtRecordInfo_ImgExt = new DataTable();

            try
            {
                _dbConnection.ConnectDatabase();

                dtRecordInfo = _dbConnection.ExecuteQuery(queryString);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            finally
            {
                _dbConnection.CloseDatabase();
            }

            try
            {
                _dbConnection.ConnectDatabase_ImageExt();
                dtRecordInfo_ImgExt = _dbConnection.ExecuteQuery_ImageExt(queryString_ImgExt);
            }
            catch (Exception ey)
            {
                throw new Exception(ey.Message);
            }
            finally
            {
                _dbConnection.CloseDatabase_ImageExt();
            }

            if (dtRecordInfo_ImgExt.Rows.Count > 0 && dtRecordInfo.Rows.Count > 0)
            {
                if (dtRecordInfo_ImgExt.Rows[0]["Voucher_Image"] != DBNull.Value)
                {
                    voucherByte = (byte[])dtRecordInfo_ImgExt.Rows[0]["Voucher_Image"];
                }
                else if (dtRecordInfo.Rows[0]["Voucher_Image"] != DBNull.Value)
                {
                    voucherByte = (byte[])dtRecordInfo.Rows[0]["Voucher_Image"];
                }
                else
                {
                    voucherByte = new byte[0];
                }
            }
            else if (dtRecordInfo_ImgExt.Rows.Count == 0 && dtRecordInfo.Rows.Count > 0)
            {
                if (dtRecordInfo.Rows[0]["Voucher_Image"] != DBNull.Value)
                {
                    voucherByte = (byte[])dtRecordInfo.Rows[0]["Voucher_Image"];
                }
                else
                {
                    voucherByte = new byte[0];
                }
            }
            return voucherByte;
        }

    }
}
