using System;
using System.Data;
using BusinessAccessLayer.BO;
using DataAccessLayer;


namespace BusinessAccessLayer.BAL
{
    public class ExpenseTransactionBAL
    {
        private DbConnection _dbConnection;
        public ExpenseTransactionBAL()
        {
            _dbConnection = new DbConnection();
        }

        public DataTable Get_Data(string query)
        {

            DataTable dtable;
            _dbConnection.ConnectDatabase();
            _dbConnection.StartTransaction();
            dtable = _dbConnection.ExecuteQuery(query);
            _dbConnection.Commit();

            return dtable;

        }

        public void SaveDt_CityBankBook(string query)
        {
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();

                _dbConnection.ExecuteNonQuery(query);
                _dbConnection.Commit();

            }
            catch
            {
                //
            }
        }
        public void SaveExpenseTransaction(ExpenseTransBO expenseTransBo)
        {
            CommonBAL commonBal = new CommonBAL();
            int voucherId_WithOutProblem = 0;
            int voucherID_AfterProblem = 0;

            string queryString_ImgExt = @"INSERT INTO SBP_Expense_Voucher_ImgExt
                                           (
                                            [Voucher_ID]
                                           ,[Voucher_Image]
                                           ,[Update_Date]
                                           )
                                     VALUES
                                           (
                                            @Voucher_ID
                                           ,@Voucher_Image
                                           ,@Update_Date
                                           )";

            string queryString_Without_Image = @"INSERT INTO SBP_Expense_Voucher
                                           (
                                            [Voucher_No]
                                           ,[Date]
                                           --,[Voucher_Image]
                                           )
                                     VALUES
                                           (
                                            @Voucher_No
                                           ,@Date
                                           --,@Voucher_Image
                                           )";

            string queryString_With_Image = @"INSERT INTO SBP_Expense_Voucher
                                           (
                                            [Voucher_No]
                                           ,[Date]
                                           ,[Voucher_Image]
                                           )
                                     VALUES
                                           (
                                            @Voucher_No
                                           ,@Date
                                           ,@Voucher_Image
                                           )";

            try
            {
                _dbConnection.ConnectDatabase_ImageExt();
                _dbConnection.ConnectDatabase();

                _dbConnection.StartTransaction_ImageExt();
                _dbConnection.StartTransaction();

                _dbConnection.AddParameter("@Voucher_No", SqlDbType.VarChar, (object)expenseTransBo.Voucher_No);
                _dbConnection.AddParameter("@Date", SqlDbType.DateTime, (object)expenseTransBo.Expense_Date.ToShortDateString());
                _dbConnection.AddParameter("@Voucher_Image", SqlDbType.Image, (object)expenseTransBo.Voucher_Image);
                voucherId_WithOutProblem = _dbConnection.ExecuteScalar(queryString_Without_Image);

                _dbConnection.ClearParameters();

                string queryStringExpenseTrans =
                @"INSERT INTO SBP_Expense_Transaction
                               (
                                [Expense_ID]
                               ,[Category_ID]
                               ,[Expense_Date]
                               ,[Payment_Date]
                               ,[Branch_ID]
                               ,[Amount]
                               ,[Quantity]
                               ,[Voucher_ID]
                               ,[Purchaser_Emp_ID]
                               ,[Entry_By]
                               ,[Entry_Date_Time]
                               ,[Approval_Status]
                               ,[Approved_By]
                               ,[Approval_date]
                               ,[Remarks]
                               ,[Payment_Media]
                               ,[Pay_Bank_Name]
                               ,[Bank_Account_No]
                               ,[Pay_Cheque_No]
                               ,[subCatagory_ID]
                               ,[Rate]
                               )
                         VALUES
                               ("
                                + expenseTransBo.Expense_ID
                                + "," + expenseTransBo.Category_ID
                                + ",'" + expenseTransBo.Expense_Date.ToString("yyyy-MM-dd")
                                + "','" + expenseTransBo.Payment_Date.ToString("yyyy-MM-dd")
                                + "'," + GlobalVariableBO._branchId
                                + "," + expenseTransBo.Amount
                                + "," + expenseTransBo.Qquantity
                                + "," + voucherId_WithOutProblem
                                + "," + expenseTransBo.Purchaser_Emp_ID
                                + ",'" + GlobalVariableBO._userName
                                + "','" + commonBal.GetCurrentServerDate().ToString("yyyy-MM-dd")
                                + "'," + expenseTransBo.Approval_Status
                                + ",'" + expenseTransBo.Approved_By
                                + "','" + expenseTransBo.Approved_Date
                                + "','" + expenseTransBo.Remarks
                                + "','" + expenseTransBo.Payment_Media
                                + "','" + expenseTransBo.Pay_Bank_Name
                                + "','" + expenseTransBo.Bank_Account_No
                                + "','" + expenseTransBo.Pay_Cheque_No
                                + "'," + expenseTransBo.sub_catagory_ID
                                + "," + expenseTransBo.Rate + ")";
                _dbConnection.ExecuteNonQuery(queryStringExpenseTrans);

                _dbConnection.AddParameter_ImageExt("@Voucher_ID", SqlDbType.Int, (object)voucherId_WithOutProblem);
                _dbConnection.AddParameter_ImageExt("@Voucher_Image", SqlDbType.Image, (object)expenseTransBo.Voucher_Image);
                _dbConnection.AddParameter_ImageExt("@Update_Date", SqlDbType.DateTime, (object)commonBal.GetCurrentServerDate().ToShortDateString());
                _dbConnection.ExecuteNonQuery_ImageExt(queryString_ImgExt);
                _dbConnection.ClearParameters_ImageExt();

                _dbConnection.Commit();
                _dbConnection.Commit_ImageExt();

            }
            catch (Exception ex)
            {
                try
                {
                    _dbConnection.Rollback();
                    _dbConnection.Rollback_ImageExt();

                    _dbConnection.CloseDatabase();

                    _dbConnection.ConnectDatabase();
                    _dbConnection.StartTransaction();

                    _dbConnection.AddParameter("@Voucher_No", SqlDbType.VarChar, (object)expenseTransBo.Voucher_No);
                    _dbConnection.AddParameter("@Date", SqlDbType.DateTime, (object)commonBal.GetCurrentServerDate().ToShortDateString());
                    _dbConnection.AddParameter("@Voucher_Image", SqlDbType.Image, (object)expenseTransBo.Voucher_Image);
                    voucherID_AfterProblem = _dbConnection.ExecuteScalar(queryString_With_Image);

                    string queryStringExpenseTrans =
                   @"INSERT INTO SBP_Expense_Transaction
                               (
                                [Expense_ID]
                               ,[Category_ID]
                               ,[Expense_Date]
                               ,[Payment_Date]
                               ,[Branch_ID]
                               ,[Amount]
                               ,[Quantity]
                               ,[Voucher_ID]
                               ,[Purchaser_Emp_ID]
                               ,[Entry_By]
                               ,[Entry_Date_Time]
                               ,[Approval_Status]
                               ,[Approved_By]
                               ,[Approval_date]
                               ,[Remarks]
                               ,[Payment_Media]
                               ,[Pay_Bank_Name]
                               ,[Bank_Account_No]
                               ,[Pay_Cheque_No]
                               ,[subCatagory_ID]
                               ,[Rate]
                               )
                         VALUES
                               ("
                                + expenseTransBo.Expense_ID
                                + "," + expenseTransBo.Category_ID
                                + ",'" + expenseTransBo.Expense_Date.ToString("yyyy-MM-dd")
                                + "','" + expenseTransBo.Payment_Date.ToString("yyyy-MM-dd")
                                + "'," + GlobalVariableBO._branchId
                                + "," + expenseTransBo.Amount
                                + "," + expenseTransBo.Qquantity
                                + "," + voucherId_WithOutProblem
                                + "," + expenseTransBo.Purchaser_Emp_ID
                                + ",'" + GlobalVariableBO._userName
                                + "','" + commonBal.GetCurrentServerDate().ToString("yyyy-MM-dd")
                                + "'," + expenseTransBo.Approval_Status
                                + ",'" + expenseTransBo.Approved_By
                                + "','" + expenseTransBo.Approved_Date
                                + "','" + expenseTransBo.Remarks
                                + "','" + expenseTransBo.Payment_Media
                                + "','" + expenseTransBo.Pay_Bank_Name
                                + "','" + expenseTransBo.Bank_Account_No
                                + "','" + expenseTransBo.Pay_Cheque_No
                                + "'," + expenseTransBo.sub_catagory_ID
                                + "," + expenseTransBo.Rate + ")";
                    _dbConnection.ExecuteNonQuery(queryStringExpenseTrans);
                    _dbConnection.Commit();

                }
                catch (Exception ey)
                {
                    _dbConnection.Rollback();
                    throw new Exception(ey.Message);
                }
                finally
                {
                    _dbConnection.CloseDatabase();
                }

            }

            finally
            {
                _dbConnection.CloseDatabase_ImageExt();
                _dbConnection.CloseDatabase();
            }
            //return voucherId;
        }
        public void UpdateSettledLiabilities(DefineLiabilitiesBO dlBO, int libiID)
        {
            _dbConnection.ConnectDatabase();
            string query = @"UPDATE [SBP_Database].[dbo].[SBP_LiabilitiesPreDefine]
                                   SET [LibName] = '" + dlBO.Lib_Name + @"'
                                      ,[DeductionPeriod] = '" + dlBO.Deduction_Period + @"'
                                      ,[PaymentAmount] = " + dlBO.Payment_Amount + @"
                                      ,[Remarks] = '" + dlBO.Remarks + @"'
                                      ,[Status] = '" + dlBO.Status + @"'      
                                      ,[UpdateDate] = '" + dlBO.Update_Date + @"'
                                      ,[UpdateBy] = '" + GlobalVariableBO._userName + @"'
                                 WHERE LibID=" + libiID + "";
            _dbConnection.ExecuteNonQuery(query);
            _dbConnection.CloseDatabase();
        }


        public void saveNewIncomeAtSBP_IncomeEntry(IncomeEntryBO incEnBO)
        {
            _dbConnection.ConnectDatabase();

            string Query = @"INSERT INTO [SBP_IPO_Application_BasicInfo]
                                           ([IPOSession_ID]
                                           ,[IPOSession_Name]
                                           ,[TotalAmount]
                                           ,[Cust_Code]
                                           ,[ChannelType]
                                           ,[Application_Date]
                                           ,[Application_Satus]
                                           ,[Entry_Date]
                                           ,[Entry_Branch_ID])
                                     VALUES
                                           (" + incEnBO.SessionID + @"
                                           ,'" + incEnBO.SessionName + @"'
                                           ," + incEnBO.Dr_Amount + @"
                                           ,"+incEnBO.ClientCode+@"
                                           ,'Manual'
                                           ,'"+incEnBO.RcvDate+@"'
                                           ,0
                                            ,'" + incEnBO.RcvDate + @"'
                                           ,"+GlobalVariableBO._branchId+@")";

            string queryNew = @"INSERT INTO [SBP_Database].[dbo].[SBP_IncomeEntry]
                                               ([VoucherSLNo]
                                               ,[RcvDate]
                                               ,[RcvFrom]
                                               ,[ClientCode]
                                               ,[Dr_Cr]
                                               ,[Dr_Amount]
                                               ,[Cr_Amount]
                                               ,[Purpose]
                                               ,[TrnType]
                                               ,[AccHead]
                                               ,[AccSubHead]
                                               ,[RoutingNo]
                                               ,[BankName]
                                               ,[BankBranchName]
                                               ,[DistrictName]
                                               ,[ChequeNo]
                                               ,[PayDate]
                                               ,[Status]
                                               ,[BrokerBranchID]
                                               ,[EntryDate]
                                               ,[EntryBy]
                                               ,[UpdateDate]
                                               ,[UpdateBy])
                                         VALUES 
                                               ('" + incEnBO.VoucherSLNo + @"'
                                               ,'" + incEnBO.RcvDate + @"'
                                               ,'" + incEnBO.RcvFrom + @"'
                                               ," + incEnBO.ClientCode + @"
                                               ,'" + incEnBO.Dr_Cr + @"'
                                               ," + incEnBO.Dr_Amount + @"
                                               ," + incEnBO.Cr_Amount + @"
                                               ,'" + incEnBO.Purpose + @"'
                                               ,'" + incEnBO.TrnType + @"'
                                               ,'" + incEnBO.AccHead + @"'
                                               ,'" + incEnBO.AccSubHead + @"'
                                               ,'" + incEnBO.RoutingNo + @"'
                                               ,'" + incEnBO.BankName + @"'
                                               ,'" + incEnBO.BankBranchName + @"'
                                               ,'" + incEnBO.DistrictName + @"'
                                               ,'" + incEnBO.ChequeNo + @"'
                                               ,'" + incEnBO.PayDate + @"'
                                               ,'" + incEnBO.Status + @"'
                                               ," + incEnBO.BrokerBranchID + @"
                                               ,'" + incEnBO.EntryDate + @"'
                                               ,'" + incEnBO.EntryBy + @"'
                                               ,'" + incEnBO.UpdateDate + @"'
                                               ,'" + incEnBO.UpdateBy + @"'
                                               )";

            if (incEnBO.SessionName != string.Empty)
            {
                _dbConnection.ExecuteNonQuery(Query);
                _dbConnection.ExecuteNonQuery(queryNew);
            }
            else
            {
                _dbConnection.ExecuteNonQuery(queryNew);
            }
           
            _dbConnection.CloseDatabase();
        }


        public void saveSettledLiabilities(DefineLiabilitiesBO dlBO)
        {
            _dbConnection.ConnectDatabase();
            string query = @"INSERT INTO [SBP_Database].[dbo].[SBP_LiabilitiesPreDefine]
                                       ([LibName]
                                       ,[DeductionPeriod]
                                       ,[PaymentAmount]
                                       ,[Remarks]
                                       ,[Status]
                                       ,[EntryDate]
                                       ,[EntryBy]
                                       ,[UpdateDate]
                                       ,[UpdateBy])
                                 VALUES
                                       ('" + dlBO.Lib_Name + @"'
                                       ,'" + dlBO.Deduction_Period + @"'
                                       ," + dlBO.Payment_Amount + @"
                                       ,'" + dlBO.Remarks + @"'
                                       ,'" + dlBO.Status + @"'
                                       ,'" + dlBO.Entry_Date + @"'
                                       ,'" + dlBO.Entry_By + @"'
                                       ,'" + dlBO.Update_Date + @"'
                                       ,'" + dlBO.Update_By + "')";
            _dbConnection.ExecuteNonQuery(query);
            _dbConnection.CloseDatabase();
        }
        public DataTable GetLiabilitiesName()
        {
           DataTable dt;
           string query = @"select HeadName as SubHead_Name
	                              ,HeadSubCode as SubHead_Code
	                              ,BasicHead as BasicHead_Name
	                              ,HeadCode as BasicHead_Code
                            from SBP_HeadCodeEntry
                            where HeadSubCode like 'L%'";
         
           try
           {
               _dbConnection.ConnectDatabase();
               dt = _dbConnection.ExecuteQuery(query);
           }
           catch(Exception ex)
           {
               throw ex;
           }
           finally
           { 
                _dbConnection.CloseDatabase();
           }
           return dt;
        }
        public void DeleteVoucherById(int voucherId)
        {
            string queryString = @"DELETE FROM SBP_Expense_Voucher WHERE Voucher_ID=" + voucherId;
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

        public DataTable GetUsers()
        {
            DataTable dataTable = new DataTable();
            string queryString = @"SELECT [User_Name],[User_Name]
                                    FROM [SBP_Database].[dbo].[SBP_Users]";
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

        public void SaveVoucherImage(ExpenseTransBO expenseTransBo)
        {

        }
        public DataTable GetGridData(DateTime expenseTransDate)
        {
            DataTable dataTable;
            string queryString = @"SELECT [Transaction_ID]
                                      ,et.Expense_ID
                                      ,Expense_Description AS [Expense]
                                      ,et.Category_ID
                                      ,Category_Name AS [Category]
                                      ,[Expense_Date] AS [Expense Date]
                                      ,[Payment_Date] AS [Payment Date]
                                      ,Branch_Name AS [Branch]
                                      ,ROUND([Amount],2) AS [Amount]
                                      --,[Quantity] AS [Quantity]
                                       ,(	Select t.Voucher_No 
			                                From SBP_Expense_Voucher as t 
			                                Where t.[Voucher_ID]=et.[Voucher_ID]
		                              ) AS [Voucher]
                                      ,[Purchaser_Emp_ID] AS [Purchaser]
                                      
                                      , CASE WHEN [Approval_Status]=0 THEN 'Pending'
                                             WHEN [Approval_Status]=1 THEN 'Approved'
                                        END  AS [Status]
                                      ,[Approved_By]  AS [Approved By]
                                      ,ISNULL([Approval_date],'')  AS [Approval date]
                                      ,[Remarks]  AS [Remarks]
                                      ,et.[Entry_By] AS [Entry By]
                                      ,[Entry_Date_Time] AS [Entry Date]  
                                      
                                  FROM SBP_Expense_Transaction AS et
                                  INNER JOIN SBP_Expense_Lookup AS el
                                  ON et.Expense_ID=el.Expense_ID
                                  INNER JOIN SBP_Expense_Category_Lookup AS ecl
                                  ON et.Category_ID=ecl.Category_ID
                                  INNER JOIN SBP_Broker_Branch AS bb
                                  ON et.Branch_ID=bb.Branch_ID
                                  WHERE et.Expense_Date='" + expenseTransDate.ToString("yyyy-MM-dd") + "'";
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
        public DataTable getBankInforFromBankBook(string query)
        {
            DataTable dt;
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();

                dt = _dbConnection.ExecuteQuery(query);
                _dbConnection.Commit();

            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dt;
        }
        public DataTable GetGridData(DateTime expenseTransDate, int branchID)
        {
            DataTable dataTable;
            string queryString = @"SELECT [Transaction_ID]
                                      ,et.Expense_ID
                                      ,Expense_Description AS [Expense]
                                      ,et.Category_ID
                                      ,Category_Name AS [Category]
                                      ,[Expense_Date] AS [Expense Date]
                                      ,[Payment_Date] AS [Payment Date]
                                      ,Branch_Name AS [Branch]
                                      ,Quantity as Qty
                                      ,Rate
                                      ,ROUND([Amount],2) AS [Amount]
                                      --,[Quantity] AS [Quantity]
                                      ,(Select t.Voucher_No 
			                            From SBP_Expense_Voucher as t 
			                            Where t.[Voucher_ID]=et.[Voucher_ID]
		                              ) AS [Voucher]                                      
                                      ,[Purchaser_Emp_ID] AS [Purchaser]
                                      , CASE WHEN [Approval_Status]=0 THEN 'Pending'
                                             WHEN [Approval_Status]=1 THEN 'Approved'
                                             END  AS [Status]                                        
                                      ,[Approved_By]  AS [Approved By]
                                      ,(CASE 
											WHEN [Approval_date]='1900-01-01 00:00:00.000' THEN NULL
											ELSE [Approval_date] 
                                            END)  AS [Approval date]
                                      ,[Remarks]  AS [Remarks]
                                      ,et.[Entry_By] AS [Entry By]
                                      ,[Entry_Date_Time] AS [Entry Date]
                                      ,et.Payment_Media as [Payment_Media]
                                      ,et.Pay_Bank_Name as [Bank_Name]
                                      ,et.Bank_Account_No as [Account_No]
                                      ,et.Pay_Cheque_No as [Cheque_No]
                                     
                                  FROM SBP_Expense_Transaction AS et
                                  INNER JOIN SBP_Expense_Lookup AS el
                                  ON et.Expense_ID=el.Expense_ID
                                  INNER JOIN SBP_Expense_Category_Lookup AS ecl
                                  ON et.Category_ID=ecl.Category_ID
                                  INNER JOIN SBP_Broker_Branch AS bb
                                  ON et.Branch_ID=bb.Branch_ID
                                  WHERE et.Expense_Date='" + expenseTransDate.ToString("yyyy-MM-dd") + @"'
                                  AND et.Branch_ID=" + Convert.ToString(branchID) + @"
                                  order by [Transaction_ID] desc";
            //            string queryString = @"SELECT [Transaction_ID]
            //                                      ,et.Expense_ID
            //                                      ,Expense_Description AS [Expense]
            //                                      ,sub.Sub_Category_Type_Name as SubCatagory
            //                                      ,et.Category_ID
            //                                      ,Category_Name AS [Category]
            //                                      ,[Expense_Date] AS [Expense Date]
            //                                      ,[Payment_Date] AS [Payment Date]
            //                                      ,Branch_Name AS [Branch]
            //                                      ,ROUND([Amount],2) AS [Amount]
            //                                      --,[Quantity] AS [Quantity]
            //                                      ,(Select t.Voucher_No 
            //			                            From SBP_Expense_Voucher as t 
            //			                            Where t.[Voucher_ID]=et.[Voucher_ID]
            //		                              ) AS [Voucher]                                      
            //                                      ,[Purchaser_Emp_ID] AS [Purchaser]
            //                                      , CASE WHEN [Approval_Status]=0 THEN 'Pending'
            //                                             WHEN [Approval_Status]=1 THEN 'Approved'
            //                                             END  AS [Status]                                        
            //                                      ,[Approved_By]  AS [Approved By]
            //                                      ,(CASE 
            //											WHEN [Approval_date]='1900-01-01 00:00:00.000' THEN NULL
            //											ELSE [Approval_date] 
            //                                            END)  AS [Approval date]
            //                                      ,[Remarks]  AS [Remarks]
            //                                      ,et.[Entry_By] AS [Entry By]
            //                                      ,[Entry_Date_Time] AS [Entry Date]
            //                                      ,et.Payment_Media as [Payment_Media]
            //                                      ,et.Pay_Bank_Name as [Bank_Name]
            //                                      ,et.Bank_Account_No as [Account_No]
            //                                      ,et.Pay_Cheque_No as [Cheque_No]
            //                                     
            //                                  FROM SBP_Expense_Transaction AS et
            //                                  INNER JOIN SBP_Expense_Lookup AS el
            //                                  ON et.Expense_ID=el.Expense_ID
            //                                  inner join SBP_Expense_Sub_Category_Type as sub
            //                                  on sub.ExpenseID=el.Expense_ID
            //                                  INNER JOIN SBP_Expense_Category_Lookup AS ecl
            //                                  ON et.Category_ID=ecl.Category_ID
            //                                  INNER JOIN SBP_Broker_Branch AS bb
            //                                  ON et.Branch_ID=bb.Branch_ID
            //                                  WHERE et.Expense_Date='" + expenseTransDate.ToString("yyyy-MM-dd") + @"'
            //                                  AND et.Branch_ID=" + Convert.ToString(branchID) + "";
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
            CommonBAL cmnBAL = new CommonBAL();
            queryStringIns = @"UPDATE SBP_Expense_Lookup
                               SET [Category_ID] =" + expenseEntryBo.Category_ID
                              + ",[Expense_Description] = '" + expenseEntryBo.Expense_Description + "'"
                              + ",[Expense_Frequency] = '" + expenseEntryBo.Expense_Frequency + "'"
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
            queryString = "SELECT * FROM SBP_Expense_Lookup WHERE Category_ID=" + category_ID;
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

        public DataTable GetCategory()
        {
            DataTable dataTable = new DataTable();
            string queryString = @"SELECT [Category_ID]
                                          ,[Category_Name]
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

        public DataTable GetSubCategoryName()
        {
            DataTable dt = new DataTable();
            string query = @"select Sub_Category_Type_ID,
                                    Sub_Category_Type_Name 
                                       from SBP_Expense_Sub_Category_Type";
            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(query);
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

        public DataTable GetExpense()
        {
            DataTable dataTable = new DataTable();
            string queryString = @" SELECT 
                                          [Expense_ID]
                                          ,[Expense_Description]
                                    FROM SBP_Expense_Lookup";
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

        public DataTable GetExpenseForAssetSettlement()
        {
            DataTable dataTable = new DataTable();
            string queryString = @"SELECT 
                                      [Expense_ID]
                                      ,[Expense_Description]
                                  FROM SBP_Expense_Lookup
                                  where Category_ID=9";
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
        public string GetExpenseFrequency(int Expense_ID)
        {
            string result = string.Empty;
            DataTable dataTable = new DataTable();
            string queryString = @"SELECT 
                                (
                                Select Frequency_Name
                                From SBP_Expense_Frequency as t
                                Where t.Frequency_ID=lk.Frequency_ID
                                ) AS Frequency_Name
                                FROM [SBP_Database].[dbo].[SBP_Expense_Lookup] AS lk
                                Where [Expense_ID]=" + Expense_ID + "";
            try
            {
                _dbConnection.ConnectDatabase();
                dataTable = _dbConnection.ExecuteQuery(queryString);
                if (dataTable.Rows.Count > 0)
                    result = Convert.ToString(dataTable.Rows[0]["Frequency_Name"]);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }

            return result;
        }
        public DataTable GetTypeCategoryExpenseData()
        {
            string queryString = string.Empty;
            DataTable dtTypeCategoryExpense = new DataTable();
            queryString =
                @"SELECT 
                        cat.Category_Type_ID
                        ,Category_Type
                        ,cat.Category_ID
                        ,Category_Name
                        ,Expense_ID
                        ,Expense_Description
                        FROM dbo.SBP_Expense_Category_Type AS typ
                        LEFT OUTER JOIN 
                        SBP_Expense_Category_Lookup AS cat
                        ON typ.Category_Type_ID=cat.Category_Type_ID
                        LEFT OUTER JOIN
                        SBP_Expense_Lookup AS expn
                        ON cat.Category_ID=expn.Category_ID";
            try
            {
                _dbConnection.ConnectDatabase();
                dtTypeCategoryExpense = _dbConnection.ExecuteQuery(queryString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dtTypeCategoryExpense;
        }

        public DataTable GetDataByLiabilitiesID(int libID)
        {
            DataTable dt = new DataTable();
            string sqlQuery = @"SELECT [LibName] as Liability_Name
                                      ,[DeductionPeriod] as Period
                                      ,[PaymentAmount] as Amount
                                      ,[Remarks] as Remarks    
                                  FROM [SBP_Database].[dbo].[SBP_LiabilitiesPreDefine]
                                  where LibID=" + libID + "";
            _dbConnection.ConnectDatabase();
            dt = _dbConnection.ExecuteQuery(sqlQuery);
            _dbConnection.CloseDatabase();
            return dt;
        }

        public int GetNextIDOfIPO_AppBasicInfo()
        {
            int ID = 0;
            DataTable dt = null;
            string query = @"select MAX(ID)+1 from SBP_IPO_Application_BasicInfo";
            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(query);
                if (dt != null)
                {
                    ID = Convert.ToInt32(dt.Rows[0][0].ToString());
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
            
            return ID;
        }

        public DataTable GetDataByTransactionId(int transactionId)
        {
            string queryString = "";
            string queryString_ImgExt = "";
            queryString =
                @"SELECT 
                                       ecl.Category_Type_ID
                                      ,ct.Category_Type
                                      ,et.Expense_ID
                                      ,Expense_Description AS [Expense]
                                      ,et.Category_ID
                                      ,Category_Name AS [Category]
                                      ,[Expense_Date] AS [Expense Date]
                                      ,[Payment_Date] AS [Payment Date]
                                      ,Branch_Name AS [Branch]
                                      ,[Amount] AS [Amount]
                                      --,[Quantity] AS [Quantity]
                                      ,et.[Voucher_ID] AS [Voucher]
                                      ,ev.Voucher_No AS [Voucher No]
                                      ,ev.Voucher_Image AS [Voucher Image]
                                      ,[Purchaser_Emp_ID] AS [Purchaser]
                                      ,et.[Entry_By] AS [Entry By]
                                      ,[Entry_Date_Time] AS [Entry Date]
                                      , CASE WHEN [Approval_Status]=0 THEN 'Pending'
                                             WHEN [Approval_Status]=1 THEN 'Approved'
                                        END  AS [Status]
                                      ,[Approved_By]  AS [Approved By]
                                      ,[Approval_date]  AS [Approval date]
                                      ,[Remarks]  AS [Remarks]
                                  FROM SBP_Expense_Transaction AS et
                                  INNER JOIN SBP_Expense_Lookup AS el
                                  ON et.Expense_ID=el.Expense_ID
                                  INNER JOIN SBP_Expense_Category_Lookup AS ecl
                                  ON et.Category_ID=ecl.Category_ID
                                  INNER JOIN SBP_Broker_Branch AS bb
                                  ON et.Branch_ID=bb.Branch_ID
                                  INNER JOIN SBP_Expense_Voucher AS ev
                                  ON et.Voucher_ID=ev.Voucher_ID
                                  INNER JOIN SBP_Expense_Category_Type AS ct
                                  ON ecl.Category_Type_ID=ct.Category_Type_ID
                                  WHERE et.Transaction_ID=" + transactionId;

            queryString_ImgExt =
                @"   SELECT ext.Voucher_Image AS [Voucher Image]
                                  FROM [SBP_Database].[dbo].[SBP_Expense_Transaction] AS et
                                  INNER JOIN [SBP_Database_ImageExt].[dbo].[SBP_Expense_Voucher_ImgExt] AS ext
                                  ON et.Voucher_ID=ext.Voucher_ID
                                  WHERE et.Transaction_ID=" + transactionId;

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
                if (dtRecordInfo_ImgExt.Rows[0]["Voucher Image"] != DBNull.Value)
                {
                    dtRecordInfo.Rows[0]["Voucher Image"] = dtRecordInfo_ImgExt.Rows[0]["Voucher Image"];
                }
            }

            return dtRecordInfo;
        }

        public bool IsApprovedOrNot(int trnID)
        {
            string query = @"SELECT Approval_Status FROM SBP_Expense_Transaction WHERE Transaction_ID=" + trnID + @"";

            try
            {
                _dbConnection.ConnectDatabase();
                DataTable dt = _dbConnection.ExecuteQuery(query);
                string Value = dt.Rows[0][0].ToString();

                if (Value == "True")
                {
                    return false;
                }
                else return true;
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

        public void DeleteExpenseTransData(int transId, int voucherId)
        {
            string queryStringDeleteVoucher = "DELETE FROM [SBP_Database].[dbo].[SBP_Expense_Voucher] WHERE Voucher_ID=" + voucherId;
            string queryStringDeleteVoucher_ImgExt = "DELETE FROM [SBP_Database_ImageExt].[dbo].[SBP_Expense_Voucher_ImgExt] WHERE Voucher_ID=" + voucherId;
            string queryStringDeleteTrans = "DELETE FROM [SBP_Database].[dbo].[SBP_Expense_Transaction] WHERE Transaction_ID=" + transId;

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();
                _dbConnection.ExecuteNonQuery(queryStringDeleteTrans);
                _dbConnection.ExecuteNonQuery(queryStringDeleteVoucher_ImgExt);
                _dbConnection.ExecuteNonQuery(queryStringDeleteVoucher);
                _dbConnection.Commit();
            }
            catch (Exception)
            {
                _dbConnection.Rollback();
                throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
        }
        public DataTable SearchDataDateWise(string searchDate)
        {
            DataTable dt = new DataTable();
            string query = @"SELECT PDate as 'Date' 
	                                    ,VoucherNo as 'Voucher_No'
	                                    ,case when AccSub_Sub_Hade=2012003 then 'Md_Sir'
		                                     when AccSub_Sub_Hade=2012004 then 'DMD_Sir' else ''
		                                     end as 'Rcv_From'
	                                    ,DrAmt as 'Amount' 
	                                    ,Cash_Cheque as 'Trn_Type'
	                                    ,ChequeNO as 'Chq_No'
	                                    ,BankRoutingNo as 'Routing_No'
	                                    ,BankName as 'Bank'
	                                    ,Bank_Branch as 'Branch'
	                                    ,Remarks  
	                                    FROM  AccTransaction 
		                                    where CONVERT(Varchar(10),PDate,120)= '"+searchDate+@"' 
		                                    and AccSub_Hade= 2012000 
		                                    and TransactionType='Receive'
		                                    and Branch_ID=" + GlobalVariableBO._branchId + @"
                                    order by SL desc";
            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dt;
        }
        public DataTable getReceivedOfficeExpenseData(DateTime pdate)
        {
            DataTable dt = new DataTable();
            string query = @"SELECT PDate as 'Date' 
                                    ,VoucherNo as 'Voucher_No'
                                    ,case when AccSub_Sub_Hade=2012003 then 'Md_Sir'
	                                     when AccSub_Sub_Hade=2012004 then 'DMD_Sir' else ''
	                                     end as 'Rcv_From'
                                    ,DrAmt as 'Amount' 
                                    ,Cash_Cheque as 'Trn_Type'
                                    ,ChequeNO as 'Chq_No'
                                    ,BankRoutingNo as 'Routing_No'
                                    ,BankName as 'Bank'
                                    ,Bank_Branch as 'Branch'
                                    ,Remarks   
                                        FROM  AccTransaction
                                        where  AccSub_Hade= 2012000 
	                                       and TransactionType='Receive'
	                                       and PDate='"+pdate+@"'
                                        order by SL asc";
            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dt;
        }
        public DataTable getReceivedOfficeExpenseDataWithoutValue()
        {
            DataTable dt = new DataTable();
            string query = @"SELECT PDate as 'Date' 
                                    ,VoucherNo as 'Voucher_No'
                                    ,case when AccSub_Sub_Hade=2012003 then 'Md_Sir'
	                                     when AccSub_Sub_Hade=2012004 then 'DMD_Sir' else ''
	                                     end as 'Rcv_From'
                                    ,DrAmt as 'Amount' 
                                    ,Cash_Cheque as 'Trn_Type'
                                    ,ChequeNO as 'Chq_No'
                                    ,BankRoutingNo as 'Routing_No'
                                    ,BankName as 'Bank'
                                    ,Bank_Branch as 'Branch'
                                    ,Remarks   
                                        FROM  AccTransaction
                                        where  AccSub_Hade= 2012000 
	                                       and TransactionType='Receive'	                                       
                                        order by SL desc";
            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dt;
        }
        public DataTable GetBankNameForWithdrawalHistory()
        {
            DataTable dt;
            string query = @"select BankName
	                               ,BankAcc
	                               ,AccountPurpose
                            from BankBook.dbo.BankInfo";
            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(query);
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
    }
}

