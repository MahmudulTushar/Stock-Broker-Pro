using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessAccessLayer.BO;
using DataAccessLayer;

namespace BusinessAccessLayer.BAL
{
    public class CheckPrintBAL
    {
        private DbConnection _dbConnection;
        public CheckPrintBAL()
        {
            _dbConnection = new DbConnection();
        }
        public DataTable GetAllCheckReceiver(DateTime searchDate)
        {
            DataTable dataTable;
            dataTable = null;
            string queryString = "";
            queryString = "SELECT Cust_Code AS 'Client Code',(SELECT Cust_Name FROM SBP_Cust_Personal_Info WHERE SBP_Cust_Personal_Info.Cust_Code=SBP_Payment.Cust_Code) AS 'Name',Amount,Payment_Media_No AS 'Check No',Voucher_Sl_No AS 'Voucher No',Received_Date AS 'Check Date' FROM SBP_Payment WHERE Deposit_Withdraw='Withdraw' AND Payment_Media='Check' AND Received_Date='" + searchDate + "' AND Payment_Media_No NOT IN (SELECT Payment_Media_No FROM SBP_Check_Print_History WHERE SBP_Check_Print_History.Recieved_Date='" + searchDate + "')";
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

        public DataTable GetCheckInfoForView(int custCodeForView, DateTime searchDate)
        {
            DataTable dataTable;
            dataTable = null;
            string queryString = "";
            queryString = "SELECT (SELECT Cust_Name FROM SBP_Cust_Personal_Info WHERE SBP_Cust_Personal_Info.Cust_Code='"+custCodeForView+"') AS 'Cust_Name',Amount,dbo.Currency_Words(Amount) AS 'Amount_Words',Received_Date FROM SBP_Payment WHERE Deposit_Withdraw='Withdraw' AND Payment_Media='Check' AND Received_Date='" + searchDate + "' AND Cust_Code='"+custCodeForView+"'";
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

        public DataTable GetDataForPrinting(string custCode,DateTime receivedDate, string author)
        {
            DataTable dataTable=new DataTable();
            string queryString = "";
            queryString = "SELECT Cust_Code,(SELECT Name FROM SBP_Broker_Info) AS 'Broker_Name',(SELECT Cust_Name FROM SBP_Cust_Personal_Info WHERE SBP_Cust_Personal_Info.Cust_Code='" + custCode + "') AS 'Cust_Name',Amount,dbo.Currency_Words(Amount) AS 'Amount_Words',Received_Date,'" + author + "' AS 'Author' FROM SBP_Payment WHERE Deposit_Withdraw='Withdraw' AND Payment_Media='Check' AND Received_Date='" + receivedDate + "' AND Cust_Code='" + custCode + "'";
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

        public void InsertPrintLog(CheckPrintLogBO checkPrintLogBo)
        {
            string queryString = "";
            queryString = @"SBPSaveCheckPrintHistory";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@SlNo", SqlDbType.Int, checkPrintLogBo.SlNo);
                _dbConnection.AddParameter("@CustCode", SqlDbType.VarChar, checkPrintLogBo.CustCode);
                _dbConnection.AddParameter("@PaymentMediaNo", SqlDbType.VarChar, checkPrintLogBo.PaymentMediaNo);
                _dbConnection.AddParameter("@BankName", SqlDbType.VarChar,checkPrintLogBo.Bankname);
                _dbConnection.AddParameter("@VoucheNo", SqlDbType.VarChar, checkPrintLogBo.VoucherSlNo);
                _dbConnection.AddParameter("@RecievedDate", SqlDbType.DateTime, checkPrintLogBo.RecievedDate.ToShortDateString());
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

        public DataTable GetCheckPrintHistory(DateTime SearchDate)
        {
            DataTable dataTable;
            dataTable = null;
            string queryString = "";
            queryString = "SELECT Cust_Code AS 'Client Code',Bank_Name AS 'Bank Name',Payment_Media_No AS 'Check No',Voucher_Sl_No AS 'Voucher No',Recieved_Date AS 'Check Date' FROM SBP_Check_Print_History WHERE  Recieved_Date='" + SearchDate + "'";
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
        public void DeleteCheckHistory(string custCode, string paymentNo, DateTime recieveddate)
        {
            string queryString = "";
            queryString = "DELETE FROM SBP_Check_Print_History WHERE Cust_Code='" + custCode + "' AND Payment_Media_No='" + paymentNo + "' AND Recieved_Date='"+recieveddate+"'";
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
