using System;
using System.Data;
using System.Data.SqlClient;
using BusinessAccessLayer.BO;
using DataAccessLayer;

namespace BusinessAccessLayer.BAL
{
    public class OpexBAL
    {
        private DbConnection _dbConnection;
        public OpexBAL()
        {
            _dbConnection = new DbConnection();
        }
        public void SaveDailyOpexInfo(OpexDailyBO opexDailyBo)
        {
            CommonBAL commonBal = new CommonBAL();
            int expenseId = 0;

            string queryString_ImgExt = @"INSERT INTO [SBP_OPEX_ImgExt]
                                            (
                                            [Expense_ID]
                                            , [Voucher_Image]
                                            , [Update_Date]
                                            )
                                            VALUES
                                            (
                                            @Expense_ID
                                            , @Voucher_Image
                                            , @Update_Date
                                            )";
            string queryStringWithoutImage = "";
            queryStringWithoutImage = @"INSERT INTO SBP_OPEX
                                        (
                                         Expense_Purpose_ID
                                        ,Purpose
                                        ,Branch_ID
                                        ,Amount
                                        ,Voucher_No
                                       -- ,Voucher_Image
                                        ,Expense_Date
                                        ,Remarks
                                        ,Entry_By
                                        ,Entry_Date
                                        ,Expense_Type
                                        ,Update_Date
                                        )"

                                        +
                                        @"VALUES(
                                        @Expense_Purpose_ID
                                        ,@Purpose
                                        ,@Branch_ID
                                        ,@Amount
                                        ,@Voucher_No
                                       -- ,@Voucher_Image
                                        ,CAST(FLOOR(CAST(@Expense_Date AS FLOAT)) AS DATETIME)
                                        ,@Remarks
                                        ,@Entry_By
                                        ,CAST(FLOOR(CAST(GETDATE() AS FLOAT)) AS DATETIME)
                                        ,@Expense_Type
                                        ,@Update_Date)";

            string queryStringWithImage = "";
            queryStringWithImage = @"INSERT INTO SBP_OPEX
                                        (
                                        Expense_Purpose_ID
                                        ,Purpose
                                        ,Branch_ID
                                        ,Amount
                                        ,Voucher_No
                                        ,Voucher_Image
                                        ,Expense_Date
                                        ,Remarks
                                        ,Entry_By
                                        ,Entry_Date
                                        ,Expense_Type
                                        ,Update_Date
                                        )"
                                        +
                                        @"VALUES
                                        (
                                        @Expense_Purpose_ID
                                        ,@Purpose
                                        ,@Branch_ID
                                        ,@Amount
                                        ,@Voucher_No
                                        ,@Voucher_Image
                                        ,CAST(FLOOR(CAST(@Expense_Date AS FLOAT)) AS DATETIME)
                                        ,@Remarks
                                        ,@Entry_By
                                        ,CAST(FLOOR(CAST(GETDATE() AS FLOAT)) AS DATETIME)
                                        ,@Expense_Type
                                        ,@Update_Date)";

            try
            {

                _dbConnection.ConnectDatabase_ImageExt();
                _dbConnection.ConnectDatabase();

                _dbConnection.StartTransaction_ImageExt();
                _dbConnection.StartTransaction();


                _dbConnection.AddParameter("@Expense_Purpose_ID", SqlDbType.Int, (object)opexDailyBo.PurposeId);
                _dbConnection.AddParameter("@Purpose", SqlDbType.VarChar, (object)opexDailyBo.Purpose);
                _dbConnection.AddParameter("@Branch_ID", SqlDbType.Int, (object)opexDailyBo.BranchId);
                _dbConnection.AddParameter("@Amount", SqlDbType.Money, (object)opexDailyBo.Amount);
                _dbConnection.AddParameter("@Voucher_No", SqlDbType.VarChar, (object)opexDailyBo.VoucherNo);
                // _dbConnection.AddParameter("@Voucher_Image", SqlDbType.Image, null);
                _dbConnection.AddParameter("@Expense_Date", SqlDbType.DateTime, (object)opexDailyBo.ExpenseDate);
                _dbConnection.AddParameter("@Remarks", SqlDbType.VarChar, (object)opexDailyBo.Remarks);
                _dbConnection.AddParameter("@Entry_By", SqlDbType.VarChar, (object)GlobalVariableBO._userName);
                _dbConnection.AddParameter("@Expense_Type", SqlDbType.VarChar, opexDailyBo.ExpenseType == null ? string.Empty : (object)opexDailyBo.ExpenseType);
                _dbConnection.AddParameter("@Update_Date", SqlDbType.DateTime, (object)commonBal.GetCurrentServerDate().ToShortDateString());
                _dbConnection.ExecuteNonQuery(queryStringWithoutImage);
                _dbConnection.ClearParameters();
                _dbConnection.Commit();

                expenseId = commonBal.GetMaxID("SBP_OPEX", "Expense_ID");

                _dbConnection.AddParameter_ImageExt("@Expense_ID", SqlDbType.Int, (object)expenseId);
                _dbConnection.AddParameter_ImageExt("@Voucher_Image", SqlDbType.Image, (object)opexDailyBo.VoucherImage);
                _dbConnection.AddParameter_ImageExt("@Update_Date", SqlDbType.DateTime, (object)commonBal.GetCurrentServerDate().ToShortDateString());
                _dbConnection.ExecuteNonQuery_ImageExt(queryString_ImgExt);
                _dbConnection.ClearParameters_ImageExt();
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
                    _dbConnection.AddParameter("@Expense_Purpose_ID", SqlDbType.Int, (object)opexDailyBo.PurposeId);
                    _dbConnection.AddParameter("@Purpose", SqlDbType.VarChar, (object)opexDailyBo.Purpose);
                    _dbConnection.AddParameter("@Branch_ID", SqlDbType.Int, (object)opexDailyBo.BranchId);
                    _dbConnection.AddParameter("@Amount", SqlDbType.Money, (object)opexDailyBo.Amount);
                    _dbConnection.AddParameter("@Voucher_No", SqlDbType.VarChar, (object)opexDailyBo.VoucherNo);
                    _dbConnection.AddParameter("@Voucher_Image", SqlDbType.Image, (object)opexDailyBo.VoucherImage);
                    _dbConnection.AddParameter("@Expense_Date", SqlDbType.DateTime, (object)opexDailyBo.ExpenseDate);
                    _dbConnection.AddParameter("@Remarks", SqlDbType.VarChar, (object)opexDailyBo.Remarks);
                    _dbConnection.AddParameter("@Entry_By", SqlDbType.VarChar, (object)GlobalVariableBO._userName);
                    _dbConnection.AddParameter("@Expense_Type", SqlDbType.VarChar, (object)opexDailyBo.ExpenseType);
                    _dbConnection.AddParameter("@Update_Date", SqlDbType.DateTime, (object)commonBal.GetCurrentServerDate().ToShortDateString());
                    _dbConnection.ExecuteNonQuery(queryStringWithImage);
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
        }

        public DataTable GetOpexDailyInfo()
        {
            string queryString = "";
            queryString = "SELECT Opex.Expense_ID,EP.Purpose_Name AS [Category],Purpose, CAST(OPEX.Amount AS FLOAT) AS [Expense Amount],OPEX.Voucher_No AS 'Voucher No',CONVERT(VARCHAR(12),OPEX.Expense_Date,107) AS 'Expense Date',(CASE WHEN(Status=1) THEN 'Approved' ELSE CASE WHEN(Status=2) THEN 'Rejected' ELSE 'Pending' END END) AS Status FROM SBP_Expense_Purpose EP,SBP_OPEX OPEX WHERE EP.Purpose_Id=OPEX.Expense_Purpose_ID AND OPEX.Branch_ID=" + GlobalVariableBO._branchId + " AND Expense_Type='Daily' ORDER BY Opex.Expense_ID DESC;";

            DataTable dt_RecordInfo = new DataTable();

            try
            {
                _dbConnection.ConnectDatabase();
                dt_RecordInfo = _dbConnection.ExecuteQuery(queryString);
            }
            catch (Exception)
            {

                throw;
            }

            finally
            {
                _dbConnection.CloseDatabase();
            }

            return dt_RecordInfo;
        }

        public DataTable GetOpexMonthlyInfo()
        {
            string queryString = "";
            queryString = "SELECT Opex.Expense_ID,EP.Purpose_Name AS [Category],Purpose,CAST(OPEX.Amount AS FLOAT) AS [Expense Amount],OPEX.Voucher_No AS 'Voucher No',CONVERT(VARCHAR(12),OPEX.Expense_Date,107) AS 'Expense Date',CONVERT(VARCHAR(12),OPEX.Expense_Month,100) AS 'Expense Month',(CASE WHEN(Status=1) THEN 'Approved' ELSE CASE WHEN(Status=2) THEN 'Rejected' ELSE 'Pending' END END) AS Status FROM SBP_Expense_Purpose EP,SBP_OPEX OPEX WHERE EP.Purpose_Id=OPEX.Expense_Purpose_ID AND OPEX.Branch_ID=" + GlobalVariableBO._branchId + " AND Expense_Type='Monthly' ORDER BY Opex.Expense_ID DESC;";

            DataTable dt_RecordInfo = new DataTable();

            try
            {
                _dbConnection.ConnectDatabase();
                dt_RecordInfo = _dbConnection.ExecuteQuery(queryString);
            }
            catch (Exception)
            {

                throw;
            }

            finally
            {
                _dbConnection.CloseDatabase();
            }

            return dt_RecordInfo;
        }

        public void InsertOpexPurpose(OPexPurposeBO objOpexPurpose)
        {
            string queryString = "INSERT INTO SBP_Expense_Purpose (Purpose_Name,Purpose_Type) VALUES ('" + objOpexPurpose.OpexPurpose + "','" + objOpexPurpose.ExpenseType + "')";

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


        public int GetTotalCategory()
        {
            string queryString = "SELECT COUNT(*) FROM SBP_Expense_Purpose";
            int totalCategory = 0;
            DataTable data = new DataTable();

            try
            {
                _dbConnection.ConnectDatabase();
                data = _dbConnection.ExecuteQuery(queryString);
                totalCategory = Int32.Parse(data.Rows[0][0].ToString());

            }
            catch (Exception)
            {
                throw;
            }

            finally
            {
                _dbConnection.CloseDatabase();
            }

            return totalCategory;

        }

        private void DeleteToOpexRecordInfo(string Type, int expenseId)
        {
            string queryString = "";
            queryString = "DELETE FROM SBP_OPEX WHERE Expense_ID=" + expenseId + ";";

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

        public DataTable ViewVoucher(string voucherNo)
        {
            DataTable dataTable = new DataTable();

            string query = "Select Voucher_Image FROM SBP_OPEX WHERE Voucher_No='" + voucherNo + "';";

            try
            {
                _dbConnection.ConnectDatabase();
                dataTable = _dbConnection.ExecuteQuery(query);
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

        public void SaveMonthlyOpexInfo(OpexDailyBO opexDailyBo)
        {
            SqlConnection conn = new SqlConnection(DbConnectionBasic.ConnectionString);
            string queryString = "";

            queryString = "INSERT INTO SBP_OPEX(Expense_Purpose_ID,Purpose,Branch_ID,Amount,Voucher_No,Voucher_Image,Expense_Date,Expense_Month,Remarks,Expense_Type,Entry_By,Entry_Date)" +
            "VALUES(@Expense_Purpose_ID,@Purpose,@Branch_ID,@Amount,@Voucher_No,@Voucher_Image,CAST(FLOOR(CAST(@Expense_Date AS FLOAT)) AS DATETIME),@Expense_Month,@Remarks,@Expense_Type,@Entry_By,CAST(FLOOR(CAST(GETDATE() AS FLOAT)) AS DATETIME))";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.AddParameter("@Expense_Purpose_ID", SqlDbType.Int, (object)opexDailyBo.PurposeId);
                _dbConnection.AddParameter("@Purpose", SqlDbType.VarChar, (object)opexDailyBo.Purpose);
                _dbConnection.AddParameter("@Branch_ID", SqlDbType.Int, (object)opexDailyBo.BranchId);
                _dbConnection.AddParameter("@Amount", SqlDbType.Money, (object)opexDailyBo.Amount);
                _dbConnection.AddParameter("@Voucher_No", SqlDbType.VarChar, (object)opexDailyBo.VoucherNo);
                _dbConnection.AddParameter("@Voucher_Image", SqlDbType.Image, (object)opexDailyBo.VoucherImage);
                _dbConnection.AddParameter("@Expense_Date", SqlDbType.DateTime, (object)opexDailyBo.ExpenseDate);
                _dbConnection.AddParameter("@Remarks", SqlDbType.VarChar, (object)opexDailyBo.Remarks);
                _dbConnection.AddParameter("@Entry_By", SqlDbType.VarChar, (object)GlobalVariableBO._userName);
                _dbConnection.AddParameter("@Expense_Type", SqlDbType.VarChar, (object)opexDailyBo.ExpenseType);
                _dbConnection.AddParameter("@Expense_Month", SqlDbType.DateTime, (object)opexDailyBo.MonthOfExpense);
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

        public DataTable GetIndividaulGridInfo(DateTime searchDate)
        {
            DataTable dataTable = new DataTable();
            string queryString = "";
            queryString = "SELECT Opex.Expense_ID,EP.Purpose_Name AS [Purpose Name],CAST(OPEX.Amount AS FLOAT) AS [Expense Amount],OPEX.Voucher_No AS 'Voucher No',CONVERT(VARCHAR(12),OPEX.Expense_Date,107) AS 'Expense Date',CONVERT(VARCHAR(12),OPEX.Expense_Month,100) AS 'Expense Month',OPEX.Remarks,(CASE WHEN(Status=1) THEN 'Approved' ELSE CASE WHEN(Status=2) THEN 'Rejected' ELSE 'Pending' END END) AS Status FROM SBP_Expense_Purpose EP,SBP_OPEX OPEX WHERE EP.Purpose_Id=OPEX.Expense_Purpose_ID AND OPEX.Branch_ID=" + GlobalVariableBO._branchId + " AND Expense_Type='Monthly' AND OPEX.Expense_Date='" + searchDate.ToShortDateString() + "';";
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

        public DataTable GetDailyGridInfo(DateTime searchDate)
        {
            DataTable dataTable = new DataTable();
            string queryString = "";
            queryString = "SELECT Opex.Expense_ID,EP.Purpose_Name AS [Category],Purpose, CAST(OPEX.Amount AS FLOAT) AS [Expense Amount],OPEX.Voucher_No AS 'Voucher No',CONVERT(VARCHAR(12),OPEX.Expense_Date,107) AS 'Expense Date',(CASE WHEN(Status=1) THEN 'Approved' ELSE CASE WHEN(Status=2) THEN 'Rejected' ELSE 'Pending' END END) AS Status FROM SBP_Expense_Purpose EP,SBP_OPEX OPEX WHERE EP.Purpose_Id=OPEX.Expense_Purpose_ID AND OPEX.Branch_ID=" + GlobalVariableBO._branchId + " AND OPEX.Expense_Date='" + searchDate.ToShortDateString() + "' AND Expense_Type='Daily' ORDER BY Opex.Expense_ID DESC;";
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
        public DataTable GetCommonGridInfo(DateTime searchDate)
        {
            DataTable dataTable = new DataTable();
            string queryString = "";
            queryString = "SELECT Opex.Expense_ID,EP.Purpose_Name AS [Category],Purpose,OPEX.Amount AS [Expense Amount],OPEX.Voucher_No AS 'Voucher No',CONVERT(VARCHAR(12),OPEX.Expense_Date,107) AS 'Expense Date',OPEX.Remarks,(CASE WHEN(Status=1) THEN 'Approved' ELSE CASE WHEN(Status=2) THEN 'Rejected' ELSE 'Pending' END END) AS Status FROM SBP_Expense_Purpose EP,SBP_OPEX OPEX WHERE EP.Purpose_Id=OPEX.Expense_Purpose_ID AND Expense_Type='Common' AND Expense_Date='" + searchDate.ToString("yyyy-MM-dd") + "' ORDER BY Opex.Expense_ID DESC;";
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

        public DataTable GetOpexCommonInfo()
        {
            string queryString = "";
            queryString = "SELECT Opex.Expense_ID,EP.Purpose_Name AS [Category],Purpose,CAST(OPEX.Amount AS FLOAT) AS [Expense Amount],CONVERT(VARCHAR(12),OPEX.Expense_Date,107) AS 'Expense Date',(CASE WHEN(Status=1) THEN 'Approved' ELSE CASE WHEN(Status=2) THEN 'Rejected' ELSE 'Pending' END END) AS Status FROM SBP_Expense_Purpose EP,SBP_OPEX OPEX WHERE EP.Purpose_Id=OPEX.Expense_Purpose_ID AND OPEX.Branch_ID=" + GlobalVariableBO._branchId + " AND Expense_Type='Common' ORDER BY Opex.Expense_ID DESC;";

            DataTable dt_RecordInfo = new DataTable();

            try
            {
                _dbConnection.ConnectDatabase();
                dt_RecordInfo = _dbConnection.ExecuteQuery(queryString);
            }
            catch (Exception)
            {

                throw;
            }

            finally
            {
                _dbConnection.CloseDatabase();
            }

            return dt_RecordInfo;
        }



        public void DeleteExpenseData(int expenseIDforUpdate)
        {
            string queryUpdateRequisition = "DELETE FROM SBP_OPEX WHERE Expense_ID=" + expenseIDforUpdate + " AND Status=0;IF @@ROWCOUNT=0 RAISERROR('You can not delete this record. Because this already approved or rejected.', 16, 1)";
            string queryUpdateRequisition_ImgExt = "DELETE FROM SBP_OPEX_ImgExt WHERE Expense_ID=" + expenseIDforUpdate + " IF @@ROWCOUNT=0 RAISERROR('You can not delete this record. Because this already approved or rejected.', 16, 1)";

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(queryUpdateRequisition);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }

            try
            {
                _dbConnection.ConnectDatabase_ImageExt();
                _dbConnection.ExecuteNonQuery_ImageExt(queryUpdateRequisition_ImgExt);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                _dbConnection.CloseDatabase_ImageExt();
            }
        }

        public void SaveCommonOpexInfo(OpexDailyBO opexDailyBo)
        {

            string queryString = "SP_CommonExpense";


            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@Expense_Purpose_ID", SqlDbType.Int, (object)opexDailyBo.PurposeId);
                _dbConnection.AddParameter("@Purpose", SqlDbType.VarChar, (object)opexDailyBo.Purpose);
                _dbConnection.AddParameter("@Amount", SqlDbType.Money, (object)opexDailyBo.Amount);
                _dbConnection.AddParameter("@Expense_Date", SqlDbType.DateTime, (object)opexDailyBo.ExpenseDate.ToShortDateString());
                _dbConnection.AddParameter("@Expense_Month", SqlDbType.DateTime, (object)opexDailyBo.MonthOfExpense.ToShortDateString());
                _dbConnection.AddParameter("@Remarks", SqlDbType.VarChar, (object)opexDailyBo.Remarks);
                _dbConnection.AddParameter("@Entry_By", SqlDbType.VarChar, (object)GlobalVariableBO._userName);
                _dbConnection.AddParameter("@VoucharNo", SqlDbType.VarChar, (object)opexDailyBo.VoucherNo);
                _dbConnection.AddParameter("@VoucherImage", SqlDbType.Image, (object)opexDailyBo.VoucherImage);
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

        public DataTable GetBranchwiseTradeInfo(int month, int year)
        {
            DataTable dataTable = new DataTable();
            string queryString = "";
            queryString = "SELECT SUM(TP) AS 'TradePrice',Branch_ID FROM (SELECT SUM(TradePrice) TP,UserID FROM SBP_Transactions  WHERE MONTH(EventDate)=" + month + " AND YEAR(EventDate)=" + year + " GROUP BY UserID) TempTable,SBP_Workstation WHERE SBP_Workstation.WorkStation_Name=TempTable.UserID GROUP BY Branch_ID";
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

        public DataTable GetTotalTrade(int month, int year)
        {
            DataTable dataTable = new DataTable();
            string queryString = "";
            queryString = "SELECT dbo.GetSumTradePrice(" + month + "," + year + ")";
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

        public DataTable GetDailyVoucherInfo(int expenseId)
        {
            string queryString = "";
            string queryString_ImgExt = "";
            queryString =
                " SELECT "
                + " EP.Purpose_Name "
                + " ,OPEX.Purpose "
                + " ,CAST(OPEX.Amount AS FLOAT) AS Amount "
                + " ,OPEX.Voucher_No "
                + " ,OPEX.Expense_Date "
                + " ,OPEX.Voucher_Image as Voucher_Image "
                + " FROM SBP_Expense_Purpose EP "
                + " ,SBP_OPEX OPEX "
                + " WHERE "
                + " EP.Purpose_Id=OPEX.Expense_Purpose_ID "
                + " AND OPEX.Expense_ID=" + expenseId + "";

            queryString_ImgExt =
                @"SELECT Voucher_Image
                                FROM [SBP_Database_ImageExt].[dbo].[SBP_OPEX_ImgExt]
                                WHERE Expense_ID=" + expenseId;

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
                    dtRecordInfo.Rows[0]["Voucher_Image"] = dtRecordInfo_ImgExt.Rows[0]["Voucher_Image"];
                }
            }

            return dtRecordInfo;
        }

        public DataTable GetMonthwiseDailyOpexReport(DateTime fromDate, DateTime Todate, int BranchId)
        {
            string queryString = "";
            if (BranchId == 0)
                queryString = "SELECT DATENAME(MM, Expense_Date) + ' ' + CAST(YEAR(Expense_Date) AS VARCHAR(4)) AS Expense_Date,Expense_Date AS 'Payment Date',(SELECT Purpose_Name FROM dbo.SBP_Expense_Purpose WHERE Purpose_Id=Expense_Purpose_ID) AS Purpose_Name,Purpose ,Voucher_No,Amount,(SELECT Branch_Name FROM dbo.SBP_Broker_Branch WHERE SBP_Broker_Branch.Branch_ID=SBP_OPEX.Branch_ID) AS Branch_Name FROM dbo.SBP_OPEX WHERE Expense_Type='Daily' AND Status=1 AND Expense_Date BETWEEN '" + fromDate.ToShortDateString() + "' AND '" + Todate.ToShortDateString() + "'";

            else
                queryString = "SELECT DATENAME(MM, Expense_Date) + ' ' + CAST(YEAR(Expense_Date) AS VARCHAR(4)) AS Expense_Date,Expense_Date AS 'Payment Date',(SELECT Purpose_Name FROM dbo.SBP_Expense_Purpose WHERE Purpose_Id=Expense_Purpose_ID) AS Purpose_Name,Purpose ,Voucher_No,Amount,(SELECT Branch_Name FROM dbo.SBP_Broker_Branch WHERE SBP_Broker_Branch.Branch_ID=SBP_OPEX.Branch_ID) AS Branch_Name FROM dbo.SBP_OPEX WHERE Expense_Type='Daily' AND Status=1 AND Expense_Date BETWEEN '" + fromDate.ToShortDateString() + "' AND '" + Todate.ToShortDateString() + "' AND Branch_ID=" + BranchId + "";

            DataTable dataTable = new DataTable();
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

        public DataTable GetYearlyDailyOpexReport(DateTime fromDate, DateTime Todate, int BranchId)
        {
            string queryString = "";
            if (BranchId == 0)
                queryString = "SELECT Expense_Date AS Expense_Date,Expense_Date AS 'Payment Date',(SELECT Purpose_Name FROM dbo.SBP_Expense_Purpose WHERE Purpose_Id=Expense_Purpose_ID) AS Purpose_Name,Purpose ,Voucher_No,Amount,(SELECT Branch_Name FROM dbo.SBP_Broker_Branch WHERE SBP_Broker_Branch.Branch_ID=SBP_OPEX.Branch_ID) AS Branch_Name FROM dbo.SBP_OPEX WHERE Expense_Type='Daily' AND Status=1 AND DATEPART(YEAR,Expense_Date) BETWEEN DATEPART(YEAR,'" + fromDate.Year + "') AND DATEPART(YEAR,'" + Todate.Year + "') ORDER BY Expense_Date ASC";

            else
                queryString = "SELECT Expense_Date AS Expense_Date,Expense_Date AS 'Payment Date',(SELECT Purpose_Name FROM dbo.SBP_Expense_Purpose WHERE Purpose_Id=Expense_Purpose_ID) AS Purpose_Name,Purpose ,Voucher_No,Amount,(SELECT Branch_Name FROM dbo.SBP_Broker_Branch WHERE SBP_Broker_Branch.Branch_ID=SBP_OPEX.Branch_ID) AS Branch_Name FROM dbo.SBP_OPEX WHERE Expense_Type='Daily' AND Status=1 AND DATEPART(YEAR,Expense_Date) BETWEEN DATEPART(YEAR,'" + fromDate.Year + "') AND DATEPART(YEAR,'" + Todate.Year + "') AND Branch_ID=" + BranchId + " ORDER BY Expense_Date ASC";

            DataTable dataTable = new DataTable();
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

        public DataTable GetAllBranchDailyOpex(DateTime fromDate, DateTime Todate, int BranchId)
        {
            string queryString = "";

            if (BranchId == 0)
                queryString = "SELECT  CONVERT(VARCHAR(11),Expense_Date,106) AS Expense_Date,(SELECT Purpose_Name FROM dbo.SBP_Expense_Purpose WHERE Purpose_Id=Expense_Purpose_ID) AS Category,Purpose ,Voucher_No,Amount,(SELECT Branch_Name FROM dbo.SBP_Broker_Branch WHERE SBP_Broker_Branch.Branch_ID=SBP_OPEX.Branch_ID) AS Branch_Name FROM dbo.SBP_OPEX WHERE Expense_Type='Daily' AND Status=1 AND Expense_Date BETWEEN '" + fromDate.ToShortDateString() + "' AND '" + Todate.ToShortDateString() + "'";

            else
                queryString = "SELECT  CONVERT(VARCHAR(11),Expense_Date,106) AS Expense_Date,(SELECT Purpose_Name FROM dbo.SBP_Expense_Purpose WHERE Purpose_Id=Expense_Purpose_ID) AS Category,Purpose ,Voucher_No,Amount,(SELECT Branch_Name FROM dbo.SBP_Broker_Branch WHERE SBP_Broker_Branch.Branch_ID=SBP_OPEX.Branch_ID) AS Branch_Name FROM dbo.SBP_OPEX WHERE Expense_Type='Daily' AND Status=1 AND Expense_Date BETWEEN '" + fromDate.ToShortDateString() + "' AND '" + Todate.ToShortDateString() + "' AND Branch_ID=" + BranchId + "";


            DataTable dataTable = new DataTable();
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

        public DataTable GetCustomizedOpexReport(DateTime fromDate, DateTime Todate, int BranchId)
        {
            string queryString = "";

            if (BranchId == 0)
                queryString = "SELECT  CONVERT(VARCHAR(11),Expense_Date,106) AS Expense_Date,(SELECT Purpose_Name FROM dbo.SBP_Expense_Purpose WHERE Purpose_Id=Expense_Purpose_ID) AS Purpose_Name,Purpose ,Voucher_No,Amount,(SELECT Branch_Name FROM dbo.SBP_Broker_Branch WHERE SBP_Broker_Branch.Branch_ID=SBP_OPEX.Branch_ID) AS Branch_Name FROM dbo.SBP_OPEX WHERE Expense_Type='Daily' AND Status=1 AND Expense_Date BETWEEN '" + fromDate.ToShortDateString() + "' AND '" + Todate.ToShortDateString() + "'";

            else
                queryString = "SELECT  CONVERT(VARCHAR(11),Expense_Date,106) AS Expense_Date,(SELECT Purpose_Name FROM dbo.SBP_Expense_Purpose WHERE Purpose_Id=Expense_Purpose_ID) AS Purpose_Name,Purpose ,Voucher_No,Amount,(SELECT Branch_Name FROM dbo.SBP_Broker_Branch WHERE SBP_Broker_Branch.Branch_ID=SBP_OPEX.Branch_ID) AS Branch_Name FROM dbo.SBP_OPEX WHERE Expense_Type='Daily' AND Status=1 AND Expense_Date BETWEEN '" + fromDate.ToShortDateString() + "' AND '" + Todate.ToShortDateString() + "' AND Branch_ID=" + BranchId + "";


            DataTable dataTable = new DataTable();
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

        public DataTable GetMonthwiseMonthlyOpexReport(DateTime fromDate, DateTime Todate, int BranchId)
        {
            string queryString = "";

            if (BranchId == 0)
                queryString = "SELECT  DATENAME(MM,Expense_Date) + ' ' + CAST(YEAR(Expense_Date) AS VARCHAR(4)) AS Expense_Date,Expense_Date AS 'Payment Date',DATENAME(MM,Expense_Month) + ' ' + CAST(YEAR(Expense_Month) AS VARCHAR(4)) AS Expense_Month,(SELECT Purpose_Name FROM dbo.SBP_Expense_Purpose WHERE Purpose_Id=Expense_Purpose_ID) AS Purpose_Name,Purpose ,Voucher_No,Amount,(SELECT Branch_Name FROM dbo.SBP_Broker_Branch WHERE SBP_Broker_Branch.Branch_ID=SBP_OPEX.Branch_ID) AS Branch_Name,Expense_Type FROM dbo.SBP_OPEX WHERE Expense_Type='Monthly' AND Status=1 AND Expense_Date BETWEEN '" + fromDate.ToShortDateString() + "' AND '" + Todate.ToShortDateString() + "'";

            else
                queryString = "SELECT DATENAME(MM,Expense_Date) + ' ' + CAST(YEAR(Expense_Date) AS VARCHAR(4)) AS Expense_Date,Expense_Date AS 'Payment Date',DATENAME(MM,Expense_Month) + ' ' + CAST(YEAR(Expense_Month) AS VARCHAR(4)) AS Expense_Month,(SELECT Purpose_Name FROM dbo.SBP_Expense_Purpose WHERE Purpose_Id=Expense_Purpose_ID) AS Purpose_Name,Purpose ,Voucher_No,Amount,(SELECT Branch_Name FROM dbo.SBP_Broker_Branch WHERE SBP_Broker_Branch.Branch_ID=SBP_OPEX.Branch_ID) AS Branch_Name,Expense_Type FROM dbo.SBP_OPEX WHERE Expense_Type='Monthly' AND Status=1 AND Expense_Date BETWEEN '" + fromDate.ToShortDateString() + "' AND '" + Todate.ToShortDateString() + "' AND Branch_ID=" + BranchId + "";


            DataTable dataTable = new DataTable();
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

        public DataTable GetYearwiseMonthlyOpexReport(DateTime fromDate, DateTime Todate, int BranchId)
        {
            string queryString = "";

            if (BranchId == 0)
                queryString = "SELECT  DATENAME(MM,Expense_Date) + ' ' + CAST(YEAR(Expense_Date) AS VARCHAR(4)) AS Expense_Date,Expense_Date AS 'Payment Date',DATENAME(MM,Expense_Month) + ' ' + CAST(YEAR(Expense_Month) AS VARCHAR(4)) AS Expense_Month,(SELECT Purpose_Name FROM dbo.SBP_Expense_Purpose WHERE Purpose_Id=Expense_Purpose_ID) AS Purpose_Name,Purpose ,Voucher_No,Amount,(SELECT Branch_Name FROM dbo.SBP_Broker_Branch WHERE SBP_Broker_Branch.Branch_ID=SBP_OPEX.Branch_ID) AS Branch_Name,Expense_Type FROM dbo.SBP_OPEX WHERE Expense_Type='Monthly' AND Status=1 AND DATEPART(YEAR,Expense_Date) BETWEEN '" + fromDate.Year + "' AND '" + Todate.Year + "'";

            else
                queryString = "SELECT DATENAME(MM,Expense_Date) + ' ' + CAST(YEAR(Expense_Date) AS VARCHAR(4)) AS Expense_Date,Expense_Date AS 'Payment Date',DATENAME(MM,Expense_Month) + ' ' + CAST(YEAR(Expense_Month) AS VARCHAR(4)) AS Expense_Month,(SELECT Purpose_Name FROM dbo.SBP_Expense_Purpose WHERE Purpose_Id=Expense_Purpose_ID) AS Purpose_Name,Purpose ,Voucher_No,Amount,(SELECT Branch_Name FROM dbo.SBP_Broker_Branch WHERE SBP_Broker_Branch.Branch_ID=SBP_OPEX.Branch_ID) AS Branch_Name,Expense_Type FROM dbo.SBP_OPEX WHERE Expense_Type='Monthly' AND Status=1 AND DATEPART(YEAR,Expense_Date) BETWEEN '" + fromDate.Year + "' AND '" + Todate.Year + "' AND Branch_ID=" + BranchId + "";


            DataTable dataTable = new DataTable();
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

        public DataTable GetCommonOpexReport(DateTime fromDate, DateTime Todate, int Branchid)
        {
            string queryString = "";

            if (Branchid == 0)
                queryString = "SELECT  DATENAME(MM,Expense_Date) + ' ' + CAST(YEAR(Expense_Date) AS VARCHAR(4)) AS Expense_Date,Expense_Date AS 'Payment Date',(SELECT Purpose_Name FROM dbo.SBP_Expense_Purpose WHERE Purpose_Id=Expense_Purpose_ID) AS Purpose_Name,Purpose ,Voucher_No,Amount,(SELECT Branch_Name FROM dbo.SBP_Broker_Branch WHERE SBP_Broker_Branch.Branch_ID=SBP_OPEX.Branch_ID) AS 'Branch_Name' FROM dbo.SBP_OPEX WHERE Expense_Type='Common' AND Status=1 AND DATEPART(YEAR,Expense_Date) BETWEEN '" + fromDate.Year + "' AND '" + Todate.Year + "'";

            else
                queryString = "SELECT  DATENAME(MM,Expense_Date) + ' ' + CAST(YEAR(Expense_Date) AS VARCHAR(4)) AS Expense_Date,Expense_Date AS 'Payment Date',(SELECT Purpose_Name FROM dbo.SBP_Expense_Purpose WHERE Purpose_Id=Expense_Purpose_ID) AS Purpose_Name,Purpose ,Voucher_No,Amount,(SELECT Branch_Name FROM dbo.SBP_Broker_Branch WHERE SBP_Broker_Branch.Branch_ID=SBP_OPEX.Branch_ID) AS 'Branch_Name' FROM dbo.SBP_OPEX WHERE Expense_Type='Common' AND Status=1 AND DATEPART(YEAR,Expense_Date) BETWEEN '" + fromDate.Year + "' AND '" + Todate.Year + "' AND Branch_ID=" + Branchid + "";


            DataTable dataTable = new DataTable();
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

        /*********************************************************************/

        public DataTable GetPuposes(string type, int cat)
        {
            string queryString = "SELECT DISTINCT Purpose FROM dbo.SBP_OPEX WHERE Expense_Type='" + type + "' AND Expense_Purpose_ID=" + cat;

            DataTable dtRecordInfo = new DataTable();

            try
            {
                _dbConnection.ConnectDatabase();
                dtRecordInfo = _dbConnection.ExecuteQuery(queryString);

            }
            catch (Exception)
            {
                throw;
            }

            finally
            {
                _dbConnection.CloseDatabase();
            }

            return dtRecordInfo;
        }

        //public byte[] GetVoucherByte(int ExpenseId)
        //{
        //    byte[] voucherByte = null;
        //    string queryString =
        //         " SELECT "
        //        + "  (CASE "
        //        + "          WHEN OPEX.Voucher_Image is null THEN ISNULL(ext.Voucher_Image,NULL) "
        //        + "          ELSE OPEX.Voucher_Image "
        //        + "   END) as Voucher_Image "
        //        + " FROM SBP_OPEX as OPEX"
        //        + " ,[SBP_Database_ImageExt].[dbo].[SBP_OPEX_ImgExt] as ext"
        //        + " WHERE "
        //        + " ext.Expense_ID=OPEX.Expense_ID "
        //        + " AND OPEX.Expense_ID=" + ExpenseId + " ";
        //    DataTable data = new DataTable();

        //    try
        //    {
        //        _dbConnection.ConnectDatabase();
        //        data = _dbConnection.ExecuteQuery(queryString);

        //        if (data.Rows.Count > 0)
        //        {
        //            if (data.Rows[0]["Voucher_Image"] != DBNull.Value)
        //                voucherByte = (byte[])(data.Rows[0]["Voucher_Image"]);
        //            else
        //                voucherByte = new byte[0];
        //        }

        //        else
        //        {
        //            voucherByte = new byte[0];
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }

        //    finally
        //    {
        //        _dbConnection.CloseDatabase();
        //    }

        //    return voucherByte;
        //}
        public byte[] GetVoucherByte(int ExpenseId)
        {
            byte[] voucherByte = null;
            string queryString = "";
            string queryString_ImgExt = "";
            queryString =
                @" SELECT 
                  Voucher_Image as Voucher_Image 
                  FROM SBP_OPEX 
                  WHERE 
                  Expense_ID=" + ExpenseId + "";

            queryString_ImgExt =
                @"SELECT Voucher_Image
                                FROM [SBP_Database_ImageExt].[dbo].[SBP_OPEX_ImgExt]
                                WHERE Expense_ID=" + ExpenseId;

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
                    voucherByte = (byte[]) dtRecordInfo.Rows[0]["Voucher_Image"];
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


        /**********************************************************************/
        public DataTable GetExpenseApproveList()
        {
            DataTable dataTable;
            string queryString = "SELECT (SELECT Purpose_Name FROM SBP_Expense_Purpose WHERE Purpose_Type=Expense_Type AND Purpose_Id=Expense_Purpose_ID) AS 'Category',Purpose,Amount,Voucher_No,Expense_Type,Expense_Date,Expense_Month,Remarks,(SELECT Branch_Name FROM dbo.SBP_Broker_Branch WHERE Branch_ID=SBP_OPEX.Branch_ID) AS Branch,Expense_ID FROM dbo.SBP_OPEX WHERE Status=0";
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

        public void ApproveSelectedExpense(string expenseId)
        {

            string queryString = "UPDATE SBP_OPEX SET Status=1 WHERE Expense_ID=" + expenseId;
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
        public void RejectSelectedExpense(string expenseId, string rejectReason)
        {

            string queryString = "UPDATE SBP_OPEX SET Status=2,Reject_Reason='" + rejectReason + "' WHERE Expense_ID=" + expenseId;
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
