using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessAccessLayer.BO;
using DataAccessLayer;

namespace BusinessAccessLayer.BAL
{
    public class CashBackRegBAL
    {
          private DbConnection _dbConnection;
          public CashBackRegBAL()
        {
            _dbConnection = new DbConnection();
        }

        public bool CheckCustomerCodeDuplicate(string custCode)
        {
            DataTable dataTable;
            string queryString = "";
            queryString = "SELECT Cust_Code FROM SBP_Cashback_Reg WHERE Cust_Code='" + custCode + "'";
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

        public bool CheckCustomerCodeExist(string custCode)
        {
            DataTable dataTable;
            string queryString = "";
            queryString = "SELECT Cust_Code FROM SBP_Customers WHERE Cust_Code='" + custCode + "'";
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

        public void SaveData(List<CashBackRegBO> cashBackRegBos)
        {
            string queryString = "";
            CommonBAL commonBAL = new CommonBAL();
            // cashBackRegBo.SlNo = commonBAL.GenerateID("SBP_CashBack_Reg", "CB_ID");
            queryString = @"SBPSaveCashBackReg";
            try
            {
                _dbConnection.ConnectDatabase();
                foreach (CashBackRegBO cashBackRegBo in cashBackRegBos)
                {


                    _dbConnection.ActiveStoredProcedure();
                    // _dbConnection.AddParameter("@cbID", SqlDbType.Int, cashBackRegBo.SlNo);
                    _dbConnection.AddParameter("@sessionID", SqlDbType.Int, cashBackRegBo.SessionId);
                    _dbConnection.AddParameter("@custCode", SqlDbType.NVarChar, cashBackRegBo.CustCode);
                    _dbConnection.AddParameter("@planID", SqlDbType.Int, cashBackRegBo.PlanId);
                    _dbConnection.AddParameter("@planName", SqlDbType.VarChar, cashBackRegBo.PlanName);
                    _dbConnection.AddParameter("@cashbackamount", SqlDbType.Money, cashBackRegBo.CashBackAmount);
                    _dbConnection.AddParameter("@remark", SqlDbType.VarChar, cashBackRegBo.Remarks);
                   // _dbConnection.AddParameter("@entryDate", SqlDbType.DateTime, cashBackRegBo.EntryDate);
                    _dbConnection.AddParameter("@entryBy", SqlDbType.VarChar, GlobalVariableBO._userName);
                    _dbConnection.ExecuteNonQuery(queryString);
                }
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
        public void Insert(CashBackRegBO cashBackRegBo)
        {
            string queryString = "";
            CommonBAL commonBAL = new CommonBAL();
           // cashBackRegBo.SlNo = commonBAL.GenerateID("SBP_CashBack_Reg", "CB_ID");
            queryString = @"SBPSaveCashBackReg";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
               // _dbConnection.AddParameter("@cbID", SqlDbType.Int, cashBackRegBo.SlNo);
                _dbConnection.AddParameter("@custCode", SqlDbType.NVarChar, cashBackRegBo.CustCode);
                _dbConnection.AddParameter("@sessionID", SqlDbType.Int, cashBackRegBo.SessionId);
                _dbConnection.AddParameter("@planName", SqlDbType.VarChar, cashBackRegBo.PlanName);
                _dbConnection.AddParameter("@cashbackamount", SqlDbType.Money, cashBackRegBo.CashBackAmount);
                _dbConnection.AddParameter("@remark", SqlDbType.VarChar, cashBackRegBo.Remarks);
                _dbConnection.AddParameter("@entryDate", SqlDbType.DateTime, cashBackRegBo.EntryDate);
                _dbConnection.AddParameter("@entryBy", SqlDbType.VarChar, GlobalVariableBO._userName);
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

        public void Update(CashBackRegBO cashBackRegBo)
        {
            string queryString = "";
            queryString = @"SBPUpdateCashBackReg";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@custCode", SqlDbType.NVarChar, cashBackRegBo.CustCode);
                _dbConnection.AddParameter("@sessionID", SqlDbType.Int, cashBackRegBo.SessionId);
                _dbConnection.AddParameter("@planName", SqlDbType.VarChar, cashBackRegBo.PlanName);
                _dbConnection.AddParameter("@cashbackamount", SqlDbType.Money, cashBackRegBo.CashBackAmount);
                _dbConnection.AddParameter("@remark", SqlDbType.VarChar, cashBackRegBo.Remarks);
                _dbConnection.AddParameter("@entryDate", SqlDbType.DateTime, cashBackRegBo.EntryDate);
                _dbConnection.AddParameter("@entryBy", SqlDbType.VarChar, GlobalVariableBO._userName);
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

        public DataTable GetAllData(string custCode)
        {
            DataTable dataTable;
            string queryString = "";
            queryString = @"SELECT 
                            CashBack_SessionID
                            ,Plan_Name
                            ,CashBack_Amount
                            ,Remark
                            ,Entry_Date
                            FROM SBP_Cashback_Reg 
                            WHERE Cust_Code='" + custCode + "'";
            try
            {
                _dbConnection.ConnectDatabase();
                dataTable = _dbConnection.ExecuteQuery(queryString);
            }
            catch (Exception)
            {
                throw;
            }
            return dataTable;
           
        }

        public DataTable GetAllCashBackInfo()
        {
            DataTable dataTable;
            dataTable = null;
            string queryString = "";
            queryString = "SELECT Cust_Code AS 'Client Code',CB_Rate AS 'Cashback Rate',Min_Trade_Amount AS 'Minimum Trade Amount',Remark,Entry_Date,Entry_By,CB_Last_Paid AS 'Last Cashback Date' FROM SBP_Cashback_Reg ORDER BY Cust_Code";
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

        public DataTable GetLastCashbackDate()
        {
            DataTable dataTable;
            string queryString = "";
            queryString = "SELECT MAX(CB_Last_Paid) AS 'LastCashBackDate' FROM SBP_Cashback_Reg";
            try
            {
                _dbConnection.ConnectDatabase();
                dataTable = _dbConnection.ExecuteQuery(queryString);
            }
            catch (Exception)
            {
                throw;
            }
            return dataTable;
        }

        public DataTable GetCashbackProcessGridInfo(DateTime lastProcessDate)
        {
            DataTable dataTable;
            string queryString = "";
            queryString = "SELECT Cust_Code AS 'Client Code',CB_Rate AS 'Rate',(SELECT ISNULL(SUM(TotalShareValue),0) FROM SBP_Transactions WHERE Customer=SBP_Cashback_Reg.Cust_Code AND MONTH(EventDate)=MONTH('" + lastProcessDate + "') AND YEAR(EventDate)=YEAR('" + lastProcessDate + "')) AS 'Total Trade'," +
" CB_Rate*(SELECT ISNULL(SUM(TotalShareValue),0) FROM SBP_Transactions WHERE Customer=SBP_Cashback_Reg.Cust_Code AND MONTH(EventDate)=MONTH('" + lastProcessDate + "') AND YEAR(EventDate)=YEAR('" + lastProcessDate + "')) AS 'Cashback Amount'" +
" FROM SBP_Cashback_Reg  WHERE (SELECT ISNULL(SUM(TotalShareValue),0) FROM SBP_Transactions WHERE Customer=SBP_Cashback_Reg.Cust_Code AND MONTH(EventDate)=MONTH('" + lastProcessDate + "') AND YEAR(EventDate)=YEAR('" + lastProcessDate + "'))>=Min_Trade_Amount AND (YEAR(CB_Last_Paid)<YEAR('" + lastProcessDate + "') OR MONTH(CB_Last_Paid)<MONTH('" + lastProcessDate + "'))";
            try
            {
                _dbConnection.ConnectDatabase();
                dataTable = _dbConnection.ExecuteQuery(queryString);
            }
            catch (Exception)
            {
                throw;
            }
            return dataTable;
            
        }

        public void ProcessCashBack(DateTime processDate)
        {
            string queryString = "";
            queryString ="INSERT INTO SBP_Payment(Cust_Code,Amount,Received_Date,Payment_Media,Trans_Reason,Deposit_Withdraw,Entry_Date,Entry_By)" +
                " SELECT Cust_Code,CB_Rate*(SELECT ISNULL(SUM(TotalShareValue),0) FROM SBP_Transactions WHERE Customer=SBP_Cashback_Reg.Cust_Code AND MONTH(EventDate)=MONTH('" + processDate + "') AND YEAR(EventDate)=YEAR('" + processDate + "')) AS CASHBACK,GETDATE(),'Cash','CB','Deposit',GETDATE(),'Admin' FROM SBP_Cashback_Reg WHERE (SELECT ISNULL(SUM(TotalShareValue),0) FROM SBP_Transactions WHERE Customer=SBP_Cashback_Reg.Cust_Code AND MONTH(EventDate)=MONTH('" + processDate + "') AND YEAR(EventDate)=YEAR('" + processDate + "'))>=Min_Trade_Amount AND (YEAR(CB_Last_Paid)<YEAR('" + processDate + "') OR MONTH(CB_Last_Paid)<MONTH('" + processDate + "'))" +
                " UNION ALL SELECT 100,CB_Rate*(SELECT ISNULL(SUM(TotalShareValue),0) FROM SBP_Transactions WHERE Customer=SBP_Cashback_Reg.Cust_Code AND MONTH(EventDate)=MONTH('" + processDate + "') AND YEAR(EventDate)=YEAR('" + processDate + "')) AS CASHBACK,GETDATE(),'Cash','CB->'+CAST(Cust_Code AS varchar(20)),'Withdraw',GETDATE(),'Admin' FROM SBP_Cashback_Reg WHERE (SELECT ISNULL(SUM(TotalShareValue),0) FROM SBP_Transactions WHERE Customer=SBP_Cashback_Reg.Cust_Code AND MONTH(EventDate)=MONTH('" + processDate + "') AND YEAR(EventDate)=YEAR('" + processDate + "'))>=Min_Trade_Amount AND (YEAR(CB_Last_Paid)<YEAR('" + processDate + "') OR MONTH(CB_Last_Paid)<MONTH('" + processDate + "'))" +
                " UPDATE SBP_Cashback_Reg SET CB_Last_Paid=CONVERT(datetime,'" + processDate + "') WHERE (SELECT ISNULL(SUM(TotalShareValue),0) FROM SBP_Transactions WHERE Customer=SBP_Cashback_Reg.Cust_Code AND MONTH(EventDate)=MONTH('" + processDate + "') AND YEAR(EventDate)=YEAR('" + processDate + "'))>=Min_Trade_Amount AND (YEAR(CB_Last_Paid)<YEAR('" + processDate + "') OR MONTH(CB_Last_Paid)<MONTH('" + processDate + "'))";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();
                _dbConnection.ExecuteNonQuery(queryString);
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
        public void DeleteCashBackRegistrationData(string custcode)
        {
            string query = "DELETE FROM SBP_Cashback_Reg WHERE Cust_Code='" + custcode + "'";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(query);
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
        public void DeleteFromReg(int _deleteId)//CashBackRegBO objBO
        {
            string query = @"DELETE FROM SBP_Cashback_Reg
                            WHERE ID=" + _deleteId;
                           
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(query);
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
        //
        public DataTable GetCashBackRegi(int _sessionId)
        {
            string queryString;
            //string queryString =
            //    "SELECT Cust_Code AS 'Customer Code',(SELECT cust_Name FROM dbo.SBP_Cust_Personal_Info WHERE dbo.SBP_Cust_Personal_Info.Cust_Code=dbo.SBP_Cashback_Reg.Cust_Code) AS 'Customer Name',Plan_Name AS 'Plan Name',Effective_Date AS 'Effective Date',Remark,CB_Last_Paid AS 'Last Paid Date' FROM dbo.SBP_Cashback_Reg";
//            string queryString =
//                @"SELECT 
//                 CashBack_SessionID
//                ,Cust_Code AS 'Customer Code'
//                ,Plan_ID
//                ,
//                (
//                SELECT cust_Name 
//                FROM dbo.SBP_Cust_Personal_Info 
//                WHERE dbo.SBP_Cust_Personal_Info.Cust_Code=dbo.SBP_Cashback_Reg.Cust_Code
//                ) AS 'Customer Name'
//                ,
//                ISNULL(
//                (
//                SELECT [Name] 
//                FROM dbo.SBP_Cashback_Session 
//                WHERE [ID]=dbo.SBP_Cashback_Reg.CashBack_SessionID
//                ),'') AS 'Session Name'
//                ,ISNULL(Plan_Name,'') AS 'Plan Name'
//                ,ISNULL(CashBack_Amount,0) AS 'Cash Back Amt'
//                ,ISNULL(Remark,'') AS Remark
//                ,Entry_Date AS 'Entry Date' 
//                ,Entry_By AS 'Entry By'
//                FROM dbo.SBP_Cashback_Reg";
            queryString = @"SELECT 
                            scr.[ID]
                            ,scr.Cust_Code AS 'Cust_Code'
                            ,scs.[Name] AS 'Session_Name'
                            ,scr.Plan_Name AS 'Plan_Name'
                            ,scr.CashBack_Amount AS 'CB_Amount'
                            ,scr.Remark
                            ,scr.Entry_By
                            ,cp.Plan_Date
                            ,cp.Min_Trade_Amount
                            ,cp.Rate
                            ,cp.Effective_Date
                             FROM SBP_Cashback_Reg AS scr
                             ,dbo.SBP_Cashback_Session AS scs
                             ,dbo.SBP_Cashback_Plan AS cp
                             WHERE scr.CashBack_SessionID=scs.[ID]
                             AND scr.Plan_ID=cp.[ID]
                             AND scs.IsProcessed=0"
                            + " AND scr.CashBack_SessionID=" + _sessionId;
            DataTable data=new DataTable();

            try
            {
                _dbConnection.ConnectDatabase();
                data = _dbConnection.ExecuteQuery(queryString);
            }
            catch (Exception)
            {
                
                throw;
            }

            finally
            {
                _dbConnection.CloseDatabase();
            }

            return data;
        }
        //---------------------------------------------------------------------------//
        public DataTable GetPossibleCandidateCashBackWithData(int _sessionId, int _planId, DateTime _startDate, DateTime _endDate)
        {
            //string queryString =
            //    "SELECT Cust_Code AS 'Customer Code',(SELECT cust_Name FROM dbo.SBP_Cust_Personal_Info WHERE dbo.SBP_Cust_Personal_Info.Cust_Code=dbo.SBP_Cashback_Reg.Cust_Code) AS 'Customer Name',Plan_Name AS 'Plan Name',Effective_Date AS 'Effective Date',Remark,CB_Last_Paid AS 'Last Paid Date' FROM dbo.SBP_Cashback_Reg";
            string queryString =
                @"GetPossibleCashBackCandidatesWithData";

            DataTable data = new DataTable();

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@SessionID", SqlDbType.Int, _sessionId);
                _dbConnection.AddParameter("@PlanID", SqlDbType.Int, _planId);
                _dbConnection.AddParameter("@StartDate", SqlDbType.DateTime, _startDate);
                _dbConnection.AddParameter("@EndDate", SqlDbType.DateTime, _endDate);
                data = _dbConnection.ExecuteProQuery(queryString);
            }
            catch (Exception)
            {

                throw;
            }

            finally
            {
                _dbConnection.CloseDatabase();
            }

            return data;
        }
        public DataTable GetSessionAndPlanInfoBySessionandPlanID(int sessionId,int planId)
        {
            DataTable data = new DataTable();
            string queryString =
                @"SELECT 
                Min_Trade_Amount
                ,Rate
                ,Session_Start_Date
                ,Session_End_Date
                FROM SBP_Cashback_Plan , SBP_Cashback_Session
                WHERE SBP_Cashback_Plan.ID=" +
                planId + " AND SBP_Cashback_Session.ID=" + sessionId;
                


            try
            {
                _dbConnection.ConnectDatabase();
                data = _dbConnection.ExecuteQuery(queryString);
            }
            catch (Exception)
            {

                throw;
            }

            finally
            {
                _dbConnection.CloseDatabase();
            }

            return data;
        }

        public DataTable GetSessionInfoBySessionID(int sessionId)
        {
            DataTable data = new DataTable();
            string queryString =
                @"SELECT 
                 [Name]
                ,[Description]
                ,Session_Start_Date
                ,Session_End_Date
                FROM SBP_Cashback_Session
                WHERE ID=" + sessionId;
            try
            {
                _dbConnection.ConnectDatabase();
                data = _dbConnection.ExecuteQuery(queryString);
            }
            catch (Exception)
            {

                throw;
            }

            finally
            {
                _dbConnection.CloseDatabase();
            }

            return data;
        }
        public DataTable GetPlanInfoByPlanID(int planId)
        {
            DataTable data = new DataTable();
            string queryString =
                @"SELECT 
                Min_Trade_Amount
                ,Rate
                FROM SBP_Cashback_Plan 
                WHERE SBP_Cashback_Plan.ID=" + planId ;
            try
            {
                _dbConnection.ConnectDatabase();
                data = _dbConnection.ExecuteQuery(queryString);
            }
            catch (Exception)
            {

                throw;
            }

            finally
            {
                _dbConnection.CloseDatabase();
            }

            return data;
        }
        public DataTable GetCashBackRegEditGridData(int sessionId,int planId)
        {
            DataTable data = new DataTable();
            string queryString =
                @"SELECT
                     0 AS 'Select' 
                     ,'' AS Previous_Cash_Back_details 
                    , [Cust_Code]
                    , [CashBack_Amount]
                    , [Remark]
                     FROM SBP_Cashback_Reg
                     WHERE CashBack_SessionID="+sessionId 
                     +" AND Plan_ID=" + planId;
            try
            {
                _dbConnection.ConnectDatabase();
                data = _dbConnection.ExecuteQuery(queryString);
            }
            catch (Exception)
            {

                throw;
            }

            finally
            {
                _dbConnection.CloseDatabase();
            }

            return data;
        }
    }
}
