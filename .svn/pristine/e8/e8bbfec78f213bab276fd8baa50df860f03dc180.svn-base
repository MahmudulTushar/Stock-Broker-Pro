using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccessLayer;
using BusinessAccessLayer.BO;
using System.Data.SqlClient;

namespace BusinessAccessLayer.BAL
{
    public class InterestWithdrawBAL
    {
        private DbConnection _dbConnection;
        
        private static DataTable InterestTransaction;
        private static string CustCode;
        
        public void ConnectDatabase()
        {
            _dbConnection.ConnectDatabase();
            _dbConnection.ClearParameters();
            _dbConnection.StartTransaction();
        }

        public void ClearTransaction()
        {

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
        public void SetTransaction(SqlTransaction trans)
        {
            _dbConnection.SetTransaction(trans);
        }

        public InterestWithdrawBAL()
        {
            _dbConnection = new DbConnection();
            //if (CustCode != CustCode_Param)
            //{
            //    CustCode = CustCode_Param;
            //    InterestTransaction = GetAllInterestTransactionByCustCode(CustCode);
            //}
        }
        //public double GetOpeningBalAmount(string CustCode, DateTime FromDate, DateTime ToDate)
        //{
        //    double OpeningBal = 0.00;
            
        //    if (InterestTransaction.Rows.Count > 0)
        //    {
        //        var BeforeFromDate_Temp = InterestTransaction.AsEnumerable().Where(t =>
        //           (t["Received_Date"] == DBNull.Value ? Convert.ToDateTime(t["Received_Date"].ToString()) :DateTime.MinValue ) < FromDate).ToList();
        //        var MaxDate_Temp = InterestTransaction.AsEnumerable().Max(t => (t["Received_Date"] == DBNull.Value ? Convert.ToDateTime(t["Received_Date"]) : null));
        //        if (MaxDate_Temp != null)
        //        {
        //            OpeningBal = BeforeFromDate_Temp.Where(t => (t["Received_Date"] == DBNull.Value ? Convert.ToDateTime(t["Received_Date"]) : null) == MaxDate_Temp)
        //              .Select(t => Convert.ToDouble(t["Comm_Interest"])).SingleOrDefault();
        //        }               
        //    }   
                    
        //    return OpeningBal;
        //}
        public double GetSummaryTotalInterestAmount(string CustCode,DateTime FromDate, DateTime ToDate)
        {
            DataTable data = new DataTable();
            DateTime dateTimeTryParse=new DateTime();
            double TotalAmount=0.00;
            string queryString = "";
            queryString = @"GetInterestTransactionForAdjustment";
            
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@CustCode", SqlDbType.VarChar, CustCode);
                _dbConnection.AddParameter("@FromDate", SqlDbType.DateTime, FromDate);
                _dbConnection.AddParameter("@ToDate", SqlDbType.DateTime, ToDate);
                _dbConnection.AddParameter("@Switch", SqlDbType.Int, 3);
                data = _dbConnection.ExecuteProQuery(queryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            //var OpenBal = GetOpeningBalAmount(CustCode, FromDate, ToDate);
            //var OpeningBal
            //var MaxDate = InterestTransaction.AsEnumerable().Max(t => t["Received_Date"] ==DBNull.Value ? Convert.ToDateTime(t["Received_Date"]):null).Date;
            //    //.Where(t=> (t["Received_Date"].ToString()==string.Empty?Convert.ToDateTime(t["Received_Date"].ToString()):null)==
            ////var amount_Temp=InterestTransaction.AsEnumerable().Where(t=> Convert.ToDateTime(t["Received_Date"].ToString())==

            if (data.Rows.Count > 0)
                TotalAmount = Convert.ToDouble(data.Rows[0]["TotalInterestAmount"].ToString());
            return TotalAmount;
        }
        public int InsertIneterestWithdrawLog_UITransApplied(string Cust_Code,DateTime FromDate,DateTime ToDate,Double Amount,string Reference,string ConditionedBy)
        {
         
            CommonBAL comBal = new CommonBAL();
            int NewProcessID = 0;

            DateTime TodayServerDate = comBal.GetCurrentServerDate();
            string queryString = "";
            queryString = @"INSERT INTO [SBP_Database].[dbo].[SBP_InterestWithdraw_Log]
                           (
                            Applied_Cust_Code
                           ,[FromDate]
                           ,[ToDate]
                           ,[Withdraw_Amount]
                           ,[Reference]
                           ,[ConditionedBy]
                           ,[ProcessedBy]
                           ,[ProcessedDate]
                          )
                     VALUES
                           (
                           '"+Cust_Code+@"'
                           ,'"+FromDate.ToShortDateString()+@"' 
                           ,'" + ToDate.ToShortDateString() + @"' 
                           ,"+Amount+@"
                           ,'"+Reference+@"'
                           ,'"+ConditionedBy+@"'
                           ,'"+GlobalVariableBO._userName+@"'
                           ,GETDATE()
                           )
                    SELECT SCOPE_IDENTITY() AS NewID";
            try
            {
                //_dbConnection.ConnectDatabase();               

                _dbConnection.ClearParameters();
                DataTable Dt=_dbConnection.ExecuteQuery(queryString);
                if (Dt.Rows.Count > 0)
                    NewProcessID = Convert.ToInt32(Dt.Rows[0]["NewID"].ToString());
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                //_dbConnection.CloseDatabase();
            }

            return NewProcessID;

        }

        public DateTime GetFirstDateOfInterestTrans(string CustCode,DateTime DefaultDate)
        {
            DataTable data = new DataTable();
            DateTime DateTimeTryParse;
            DateTime Date=DefaultDate;
            string queryString = "";
            queryString = @"GetInterestTransactionForAdjustment";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@CustCode", SqlDbType.VarChar, CustCode);                          
                _dbConnection.AddParameter("@Switch", SqlDbType.Int, 5);
                data = _dbConnection.ExecuteProQuery(queryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            if (data.Rows.Count > 0)
                if (DateTime.TryParse(data.Rows[0]["TransactionDate"].ToString(),out DateTimeTryParse))
                      Date = DateTimeTryParse;

            return Date;
        }
        public DateTime GetLastDateOfInterestTrans(string CustCode,DateTime DefaultDate)
        {
            DataTable data = new DataTable();
            DateTime DateTimeTryParse;
            DateTime Date=DefaultDate;
            string queryString = "";
            queryString = @"GetInterestTransactionForAdjustment";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@CustCode", SqlDbType.VarChar, CustCode);
                _dbConnection.AddParameter("@Switch", SqlDbType.Int, 4);
                data = _dbConnection.ExecuteProQuery(queryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            if (data.Rows.Count > 0)
                if (DateTime.TryParse(data.Rows[0]["TransactionDate"].ToString(), out DateTimeTryParse))
                    Date = DateTimeTryParse;
            return Date;
        }
        //public DataTable GetAllInterestTransactionByCustCode(string CustCode)
        //{
        //    DataTable data = new DataTable();
        //       string queryString = "";
        //    queryString = @"GetInterestTransactionForAdjustment";
        //    try
        //    {
        //        _dbConnection.ConnectDatabase();
        //        _dbConnection.ActiveStoredProcedure();
        //        _dbConnection.AddParameter("@CustCode", SqlDbType.VarChar, CustCode);
        //        _dbConnection.AddParameter("@Switch", SqlDbType.Int, 6);
        //        data = _dbConnection.ExecuteProQuery(queryString);
        //    }
        //    catch (Exception exception)
        //    {
        //        throw exception;
        //    }
        //    finally
        //    {
        //        _dbConnection.CloseDatabase();
        //    }
        
        //    return DataTable;
        //}        
        public double GetSummaryTotalInterestAmount(string CustCode)
        {
            DataTable data = new DataTable();
            double TotalAmount = 0.00;
            string queryString = "";
            queryString = @"GetInterestTransactionForAdjustment";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@CustCode", SqlDbType.VarChar, CustCode);
                _dbConnection.AddParameter("@Switch", SqlDbType.Int, 3);
                data = _dbConnection.ExecuteProQuery(queryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            if (data.Rows.Count > 0)
                TotalAmount = Convert.ToDouble(data.Rows[0]["TotalInterestAmount"].ToString());
            return TotalAmount;
        }
        public DataTable GetSummaryInterestTransaction(string CustCode, double Amount, DateTime FromDate, DateTime ToDate)
        {
            DataTable data = new DataTable();
            string queryString = "";
            queryString = @"GetInterestTransactionForAdjustment";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@CustCode", SqlDbType.VarChar, CustCode);
                _dbConnection.AddParameter("@AmountToBeWithdraw", SqlDbType.Money, Amount);
                _dbConnection.AddParameter("@FromDate", SqlDbType.DateTime, FromDate);
                _dbConnection.AddParameter("@ToDate", SqlDbType.DateTime, ToDate);
                _dbConnection.AddParameter("@Switch", SqlDbType.Int, 2);
                data = _dbConnection.ExecuteProQuery(queryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return data;
        }

        public Double GetEstimated_RecalculationDiff(string CustCode, double Amount, DateTime FromDate, DateTime ToDate)
        {
            DataTable data = new DataTable();
            string queryString = "";
            double Difference=0.00;
            queryString = @"GetInterestTransactionForAdjustment";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@CustCode", SqlDbType.VarChar, CustCode);
                _dbConnection.AddParameter("@AmountToBeWithdraw", SqlDbType.Money, Amount);
                _dbConnection.AddParameter("@FromDate", SqlDbType.DateTime, FromDate);
                _dbConnection.AddParameter("@ToDate", SqlDbType.DateTime, ToDate);
                _dbConnection.AddParameter("@Switch", SqlDbType.Int, 7);
                data = _dbConnection.ExecuteProQuery(queryString);
                if (data.Rows.Count > 0)
                    Difference = Convert.ToDouble(data.Rows[0]["Difference"].ToString());

            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return Difference;
        }
        
        public DataTable GetInterestTransaction(string CustCode, double Amount, DateTime FromDate, DateTime ToDate)
        {
            DataTable data = new DataTable();
            string queryString = "";
            queryString = @"GetInterestTransactionForAdjustment";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@CustCode", SqlDbType.VarChar, CustCode);
                _dbConnection.AddParameter("@AmountToBeWithdraw", SqlDbType.Money, Amount);
                _dbConnection.AddParameter("@FromDate", SqlDbType.DateTime, FromDate);
                _dbConnection.AddParameter("@ToDate", SqlDbType.DateTime, ToDate);
                _dbConnection.AddParameter("@Switch", SqlDbType.Int, 1);
                data = _dbConnection.ExecuteProQuery(queryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return data;
        }
        
        public void InterestWithdrawProcess_UITransApplied(string CustCode, double Amount, DateTime FromDate, DateTime ToDate,int processID)
        {
            string queryString = "";
            queryString = @"SBPInterestAdjustment";
            try
            {
                //_dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@CustCode", SqlDbType.VarChar, CustCode);
                _dbConnection.AddParameter("@AmountToBeWithdraw", SqlDbType.Money, Amount);
                _dbConnection.AddParameter("@FromDate", SqlDbType.DateTime, FromDate);
                _dbConnection.AddParameter("@ToDate", SqlDbType.DateTime, ToDate);
                _dbConnection.AddParameter("@ProcessID", SqlDbType.Int, processID);
                _dbConnection.ExecuteProQuery(queryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                //_dbConnection.CloseDatabase();
            }
           
        }
    }
}
