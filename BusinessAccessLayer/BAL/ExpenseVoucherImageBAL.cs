using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using BusinessAccessLayer.BO;
using DataAccessLayer;

namespace BusinessAccessLayer.BAL
{
   public class ExpenseVoucherImageBAL
    {
       private DbConnection _dbConnection;
       public ExpenseVoucherImageBAL()
        {
            _dbConnection = new DbConnection();
        }

       public void SaveExpenseVoucherImage(ExpenseVoucherImageBO expenseVoucherImageBO)
       {
           CommonBAL commonBal = new CommonBAL();
           int expenseId = 0;

//           string queryString_ImgExt = @"INSERT INTO SBP_Expense_Voucher
//                                           ([Voucher_No]
//                                           ,[Date]
//                                           ,[Voucher_Image])"
//                                       +
//                                       @"VALUES
//                                        (
//                                        @Voucher_No
//                                        ,@Date
//                                        ,@Voucher_Image
//                                        )";
//           string queryStringWithoutImage = "";
//           queryStringWithoutImage = @"INSERT INTO SBP_Expense_Voucher
//                                           ([Voucher_No]
//                                           ,[Date]
//                                           ,[Voucher_Image])"
//                                       +
//                                       @"VALUES
//                                        (
//                                        @Voucher_No
//                                        ,@Date
//                                        ,@Voucher_Image
//                                        )"

//                                       +
//                                       @"VALUES(
//                                        @Expense_Purpose_ID
//                                        ,@Purpose
//                                        ,@Branch_ID
//                                        ,@Amount
//                                        ,@Voucher_No
//                                       -- ,@Voucher_Image
//                                        ,CAST(FLOOR(CAST(@Expense_Date AS FLOAT)) AS DATETIME)
//                                        ,@Remarks
//                                        ,@Entry_By
//                                        ,CAST(FLOOR(CAST(GETDATE() AS FLOAT)) AS DATETIME)
//                                        ,@Expense_Type
//                                        ,@Update_Date)";

           string queryStringWithImage = "";
           queryStringWithImage = @"INSERT INTO SBP_Expense_Voucher
                                           ([Voucher_No]
                                           ,[Date]
                                           ,[Voucher_Image])"
                                       +
                                       @"VALUES
                                        (
                                        @Voucher_No
                                        ,@Date
                                        ,@Voucher_Image
                                        )";

           //try
           //{

           //    _dbConnection.ConnectDatabase_ImageExt();
           //    _dbConnection.ConnectDatabase();

           //    _dbConnection.StartTransaction_ImageExt();
           //    _dbConnection.StartTransaction();


           //_dbConnection.AddParameter("@Voucher_No", SqlDbType.VarChar, (object)expenseVoucherImageBO.VoucherNo);
           //_dbConnection.AddParameter("@Date", SqlDbType.DateTime, (object)expenseVoucherImageBO.ExpenseDate);
           //_dbConnection.AddParameter("@Voucher_Image", SqlDbType.Image, (object)expenseVoucherImageBO.VoucherImage);
           //    _dbConnection.ExecuteNonQuery(queryStringWithoutImage);
           //    _dbConnection.ClearParameters();
           //    _dbConnection.Commit();

           //    expenseId = commonBal.GetMaxID("SBP_OPEX", "Expense_ID");

           //_dbConnection.AddParameter("@Voucher_No", SqlDbType.VarChar, (object)expenseVoucherImageBO.VoucherNo);
           //_dbConnection.AddParameter("@Date", SqlDbType.DateTime, (object)expenseVoucherImageBO.ExpenseDate);
           //_dbConnection.AddParameter("@Voucher_Image", SqlDbType.Image, (object)expenseVoucherImageBO.VoucherImage);
           //    _dbConnection.ExecuteNonQuery_ImageExt(queryString_ImgExt);
           //    _dbConnection.ClearParameters_ImageExt();
           //    _dbConnection.Commit_ImageExt();

           //}
           //catch (Exception ex)
           //{
               try
               {
                   //_dbConnection.Rollback();
                   //_dbConnection.Rollback_ImageExt();
                   //_dbConnection.CloseDatabase();

                   _dbConnection.ConnectDatabase();

                   //_dbConnection.StartTransaction();
                   _dbConnection.AddParameter("@Voucher_No", SqlDbType.VarChar, (object)expenseVoucherImageBO.VoucherNo);
                   _dbConnection.AddParameter("@Date", SqlDbType.DateTime, (object)expenseVoucherImageBO.ExpenseDate.ToShortDateString());
                   _dbConnection.AddParameter("@Voucher_Image", SqlDbType.Image, (object)expenseVoucherImageBO.VoucherImage);
                   _dbConnection.ExecuteNonQuery(queryStringWithImage);
                   //_dbConnection.Commit();

               }
               catch (Exception ey)
               {
                  // _dbConnection.Rollback();
                   throw new Exception(ey.Message);
               }
               finally
               {
                   _dbConnection.CloseDatabase();
               }

           //}

           //finally
           //{
           //    _dbConnection.CloseDatabase_ImageExt();
           //    _dbConnection.CloseDatabase();
           //}
       }

       public DataTable GetExpenseVoucherImage()
       {
           string queryString = "";
           queryString = @"SELECT [Voucher_ID]
                              ,[Voucher_No]
                              ,[Date]
                              ,[Voucher_Image]
                           FROM SBP_Expense_Voucher";

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
       public void DeleteExpenseVoucherImage(int expenseIDforUpdate)
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
       public DataTable GetDailyGridInfo(DateTime searchDate)
       {
           DataTable dataTable = new DataTable();
           string queryString = "";
           queryString = @"SELECT [Voucher_ID]
                              ,[Voucher_No]
                              ,[Date]
                              ,[Voucher_Image]
                           FROM SBP_Expense_Voucher";
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

       public DataTable GetVoucherImageInfo(int voucherId)
       {
           string queryString = "";
           string queryString_ImgExt = "";
           //queryString =
           //    " SELECT "
           //    + " EP.Purpose_Name "
           //    + " ,OPEX.Purpose "
           //    + " ,CAST(OPEX.Amount AS FLOAT) AS Amount "
           //    + " ,OPEX.Voucher_No "
           //    + " ,OPEX.Expense_Date "
           //    + " ,OPEX.Voucher_Image as Voucher_Image "
           //    + " FROM SBP_Expense_Purpose EP "
           //    + " ,SBP_OPEX OPEX "
           //    + " WHERE "
           //    + " EP.Purpose_Id=OPEX.Expense_Purpose_ID "
           //    + " AND OPEX.Expense_ID=" + expenseId + "";

//           queryString_ImgExt =
//               @"SELECT Voucher_Image
//                                FROM [SBP_Database_ImageExt].[dbo].[SBP_OPEX_ImgExt]
//                                WHERE Expense_ID=" + voucherId;
           queryString =
               @"SELECT Voucher_Image
                                FROM SBP_Expense_Voucher
                                WHERE Voucher_ID=" + voucherId;
           DataTable dtRecordInfo = new DataTable();
        //   DataTable dtRecordInfo_ImgExt = new DataTable();

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

           //try
           //{
           //    _dbConnection.ConnectDatabase_ImageExt();
           //    dtRecordInfo_ImgExt = _dbConnection.ExecuteQuery_ImageExt(queryString_ImgExt);
           //}
           //catch (Exception ey)
           //{
           //    throw new Exception(ey.Message);
           //}
           //finally
           //{
           //    _dbConnection.CloseDatabase_ImageExt();
           //}

           //if (dtRecordInfo_ImgExt.Rows.Count > 0 && dtRecordInfo.Rows.Count > 0)
           //{
           //    if (dtRecordInfo_ImgExt.Rows[0]["Voucher_Image"] != DBNull.Value)
           //    {
           //        dtRecordInfo.Rows[0]["Voucher_Image"] = dtRecordInfo_ImgExt.Rows[0]["Voucher_Image"];
           //    }
           //}

           return dtRecordInfo;
       }

    }
}
