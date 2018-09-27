﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessAccessLayer.BO;
using DataAccessLayer;

namespace BusinessAccessLayer.BAL
{
    public class CheckRequisitionBAL
    {
          private DbConnection _dbConnection;
          public CheckRequisitionBAL()
        {
            _dbConnection = new DbConnection();
        }
        public void Insert(CheckRequisitionBO checkRequisitionBo)//New Requisition
        {
            string queryString = "";
            string queryWebDataDelete = "";
            CommonBAL commonBal=new CommonBAL();
            Web2014DataForwardBAL webBal = new Web2014DataForwardBAL();
            //checkRequisitionBo.SlNo = commonBal.GenerateID("SBP_Check_Requisition", "Sl_No");
            queryString = "INSERT INTO SBP_Check_Requisition(Cust_code,Amount,Requisition_Date,Collection_Branch_ID,Remarks,Is_Approved,Entry_Date,Entry_By,Entry_Branch_ID,OnlineOrderNo,OnlineEntry_Date)" +
               " VALUES('" + checkRequisitionBo.CustCode + "'," + Convert.ToString(checkRequisitionBo.Amount) + ",'" + checkRequisitionBo.RequisitionDate.ToShortDateString() + "'," + checkRequisitionBo.BranchId + ",'" + checkRequisitionBo.Remarks + "',0,GETDATE(),'" + GlobalVariableBO._userName + "'," + GlobalVariableBO._branchId + "," + checkRequisitionBo.OnlineOrderNo + ",'" + Convert.ToString(checkRequisitionBo.OnlineEntry_Date.Date.Equals(DateTime.MinValue.Date) ? string.Empty : checkRequisitionBo.OnlineEntry_Date.ToString("MM-dd-yyyy") ) + "')";
            if(checkRequisitionBo.OnlineOrderNo!=0 && checkRequisitionBo.OnlineOrderNo!=null)
                queryWebDataDelete=webBal.DeleteFrom_Web2014_WithdrawalRequest_Temp(checkRequisitionBo.OnlineOrderNo);

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();
                _dbConnection.ExecuteNonQuery(queryString);
                if(checkRequisitionBo.OnlineOrderNo!=0 && checkRequisitionBo.OnlineOrderNo!=null)
                    _dbConnection.ExecuteNonQuery(queryWebDataDelete);
                _dbConnection.Commit();

            }
            catch (Exception exp)
            {
                _dbConnection.Rollback();
                throw exp;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
        }

        public DataTable GetPendingRequisitionByBO(string boId)
        {
            DataTable dataTable=new DataTable();
           
            string queryString = "";
            queryString = "SELECT SUM(Amount) FROM SBP_Check_Requisition WHERE Is_Approved=0 AND Cust_Code=dbo.GetCustCodeFromBO('" + boId + "'))";
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

        public DataTable GetPendingRequisitionByCustCode(string custCode)
        {
            DataTable dataTable=new DataTable();
           
            string queryString = "";
            queryString = "SELECT SUM(Amount) FROM SBP_Check_Requisition WHERE Is_Approved=0 AND Cust_Code='" + custCode + "'";
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

        public DataTable GetGridData(DateTime searchDate)
        {
            DataTable dataTable=new DataTable();
            string queryString = "";
            queryString = "SELECT Sl_No,Cust_code AS 'Client Code',(SELECT Cust_Name FROM SBP_Cust_Personal_Info WHERE SBP_Cust_Personal_Info.Cust_code=SBP_Check_Requisition.Cust_code) AS 'Name',Amount,Requisition_Date AS 'Requisition Date',(CASE WHEN Is_Printed=1 AND Is_Received=0 THEN 'Printed' WHEN Is_Approved=1 AND Is_Printed=0 THEN 'Approved' WHEN Is_Approved=0 THEN 'Pending' WHEN Is_Approved=2 THEN 'Rejected' WHEN Is_Received=1 AND Is_Printed=1 THEN 'Received' END) AS 'Status',(SELECT Branch_Name FROM SBP_Broker_Branch WHERE Branch_ID=Collection_Branch_ID) AS 'Collection Branch' FROM SBP_Check_Requisition WHERE Requisition_Date='" + searchDate.ToShortDateString() + "' AND '" + GlobalVariableBO._branchId + "'=(SELECT Branch_ID FROM SBP_Users WHERE User_Name=SBP_Check_Requisition.Entry_By)";
               
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

        public DataTable GetAllRequisitionForApproval()
        {
            DataTable dataTable = new DataTable();
            string queryString = "";
            queryString = "SELECT Sl_No,Cust_code AS 'Client Code',(SELECT Cust_Name FROM SBP_Cust_Personal_Info WHERE SBP_Cust_Personal_Info.Cust_code=SBP_Check_Requisition.Cust_code) AS 'Name',Amount,Requisition_Date AS 'Requisition Date',(SELECT Branch_Name FROM SBP_Broker_Branch WHERE Branch_ID=Collection_Branch_ID) AS 'Collection Branch',ISNULL((SELECT Branch_Name FROM SBP_Broker_Branch WHERE Branch_ID =(SELECT Branch_ID FROM SBP_Users WHERE User_Name=SBP_Check_Requisition.Entry_By)),'Online') AS 'Entry Branch',Remarks FROM SBP_Check_Requisition WHERE Is_Approved=0";
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

        public void ApprovedSingleCheck(PaymentInfoBO paymentInfoBo)// Approved Check
        {
            DataTable dtMaturity = new DataTable();
            int maturityDays = 0;
            dtMaturity = GetPaymentMediaMaturityDay(paymentInfoBo.IsMatureToday, paymentInfoBo.PaymentMedia);
            if (dtMaturity.Rows.Count > 0)
            {
                if (dtMaturity.Rows[0][0] != DBNull.Value)
                    maturityDays = Convert.ToInt32(dtMaturity.Rows[0][0]);
            }

            string queryUpdateRequisition = "UPDATE SBP_Check_Requisition SET Is_Approved=1 WHERE Sl_No=" + paymentInfoBo.RequisitionId + "";

            /*string queryInsertPayment = "INSERT INTO SBP_Payment(Cust_code,Amount,Received_Date,Payment_Media,Maturity_Days,Payment_Media_No,Payment_Media_Date,Bank_Name,Bank_Branch,Received_By,Deposit_Withdraw,Voucher_Sl_No,Payment_Approved_By,Payment_Approved_Date,Remarks,Entry_Date,Entry_By,Requisition_ID,Entry_Branch_ID)" +
          " VALUES('" + paymentInfoBo.CustCode + "'," + paymentInfoBo.Amount + ",(CAST(FLOOR(CAST(GETDATE() AS FLOAT)) AS DATETIME)),'" + paymentInfoBo.PaymentMedia + "'," + maturityDays + ",'" + paymentInfoBo.PaymentMediaNo + "','" + paymentInfoBo.PaymentMediaDate.ToShortDateString() + "','" + paymentInfoBo.BankName + "','" + paymentInfoBo.BranchName + "','" + paymentInfoBo.RecievedBy + "','" + paymentInfoBo.DepositWithdraw + "','" + paymentInfoBo.VoucherSlNo + "','" + paymentInfoBo.PaymentApprovedBy + "',CAST(FLOOR(CAST(GETDATE() AS FLOAT)) AS DATETIME),'" + paymentInfoBo.Remarks + "',CAST(FLOOR(CAST(GETDATE() AS FLOAT)) AS DATETIME),'" + GlobalVariableBO._userName + "'," + paymentInfoBo.RequisitionId + "," + GlobalVariableBO._branchId + ")";*/

            string queryInsertPayment = "INSERT INTO dbo.SBP_Payment( Cust_Code , Amount ,Received_Date ,Payment_Media ,Payment_Media_No ,Received_By ,Deposit_Withdraw ,Payment_Approved_By ,Payment_Approved_Date ,Remarks ,Entry_Date ,Entry_By ,Maturity_Days ,Requisition_ID ,Entry_Branch_ID)SELECT  Cust_Code ,Amount ,(CAST(FLOOR(CAST(GETDATE() AS FLOAT)) AS DATETIME)) ,'Check' ,'' ,Received_By ,'Withdraw','" + GlobalVariableBO._userName + "',Requisition_Date,Remarks ,Entry_Date ,Entry_By ," + maturityDays + ",Sl_No ,Entry_Branch_ID FROM dbo.SBP_Check_Requisition WHERE Sl_No=" + paymentInfoBo.RequisitionId;
         
            
            string queryStringTemp = "INSERT INTO SBP_Money_Balance_Temp(Cust_Code,Sell_Deposit,Buy_Withdraw,Balance,Matured_Balance,Remarks,Rec_Date)"
                                     + " VALUES('" + paymentInfoBo.CustCode + "',0," + paymentInfoBo.Amount + "," + (0 - paymentInfoBo.Amount) + "," + (0 - paymentInfoBo.Amount) + ",'" + paymentInfoBo.PaymentMedia + "',(CAST(FLOOR(CAST(GETDATE() AS FLOAT)) AS DATETIME)));";
            
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();
                _dbConnection.ExecuteNonQuery(queryUpdateRequisition);
                _dbConnection.ExecuteNonQuery(queryInsertPayment);
                _dbConnection.ExecuteNonQuery(queryStringTemp);
                _dbConnection.Commit();
            }
            catch (Exception)
            {
                _dbConnection.Rollback();
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            
        }

        public void RejectSingleCheck(int rejectionReqId,string rejectionReason)
        {
            string queryUpdateRequisition = "UPDATE SBP_Check_Requisition SET Is_Approved=2,Rejection_Reason='" + rejectionReason + "' WHERE Sl_No=" + rejectionReqId + "";

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(queryUpdateRequisition);
                
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
        private DataTable GetPaymentMediaMaturityDay(int InstantMature, string paymentMedia)
        {
            DataTable dataTable=new DataTable();
            string queryString = "";
            queryString = "SELECT CASE WHEN(" + InstantMature + "=1) THEN 0 ELSE (SELECT TOP 1 Maturity_Days FROM SBP_Payment_Media_Maturity WHERE Effective_Date=(SELECT MAX(Effective_Date) FROM SBP_Payment_Media_Maturity WHERE Payment_Media='" + paymentMedia + "') ORDER BY ID DESC) END";
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

        public DataTable GetRequisitedGridData()
        {
            DataTable dataTable = new DataTable();
            string queryString = "";
            queryString = "SELECT Sl_No,Cust_code AS 'Client Code',(SELECT Cust_Name FROM SBP_Cust_Personal_Info WHERE SBP_Cust_Personal_Info.Cust_code=SBP_Check_Requisition.Cust_code) AS 'Name',(SELECT Payment_Media_No FROM SBP_Payment WHERE Requisition_ID=SBP_Check_Requisition.Sl_No) AS 'Cheque No',Amount,Requisition_Date AS 'Requisition Date',(CASE WHEN Is_Printed=1 THEN 'Printed' WHEN Is_Approved=1 AND Is_Printed=0 THEN 'Approved' WHEN Is_Approved=0 THEN 'Pending' WHEN Is_Approved=2 THEN 'Rejected' END) AS 'Status',(SELECT Branch_Name FROM SBP_Broker_Branch WHERE Branch_ID=Collection_Branch_ID) AS 'Collection Branch' FROM SBP_Check_Requisition WHERE Is_Received=0 AND  Is_Printed=1  AND Collection_Branch_ID='" + GlobalVariableBO._branchId + "'";
                //"SELECT Sl_No,Cust_code AS 'Client Code',(SELECT Cust_Name FROM SBP_Cust_Personal_Info WHERE SBP_Cust_Personal_Info.Cust_code=SBP_Check_Requisition.Cust_code) AS 'Name',Amount,Requisition_Date AS 'Requisition Date',(CASE WHEN Is_Printed=1 THEN 'Printed' WHEN Is_Approved=1 AND Is_Printed=0 THEN 'Approved' WHEN Is_Approved=0 THEN 'Pending' WHEN Is_Approved=2 THEN 'Rejected' END) AS 'Status',(SELECT Branch_Name FROM SBP_Broker_Branch WHERE Branch_ID=Collection_Branch_ID) AS 'Collection Branch' FROM SBP_Check_Requisition WHERE Requisition_Date='" + searchDate + "' AND Collection_Branch_ID='" + GlobalVariableBO._branchId + "'";
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

       public DataTable GetUnprintedPrintCheck(DateTime value)
        {
            DataTable dataTable = new DataTable();
            string queryString = "";
            queryString ="SELECT Sl_No,SBP_Check_Requisition.Cust_Code AS 'Client Code',SBP_Check_Requisition.Amount,"+
                         "Payment_Media_No AS 'Cheque No',Voucher_Sl_No  AS 'Voucher No',SBP_Payment.Received_Date  AS 'Cheque Date',(SELECT Branch_Name FROM SBP_Broker_Branch WHERE Branch_ID=Collection_Branch_Id) AS 'Collection Branch',"+
                         "(SELECT Branch_Name FROM SBP_Broker_Branch WHERE Branch_ID=(SELECT Branch_ID FROM SBP_Users WHERE User_Name=SBP_Check_Requisition.Entry_By)) AS 'Entry Branch' "+
                         " FROM SBP_Check_Requisition "+
                         "LEFT JOIN  SBP_Payment ON SBP_Payment.Requisition_ID=SBP_Check_Requisition.Sl_No "+
                         "WHERE Is_Printed=1 AND Is_Received=0 AND Requisition_Date='"+value.ToString("yyyy-MM-dd")+"'";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.TimeoutPeriod = 100;
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
        
        public void ChangeCheckPrintStatus(int requisitionId) //Change to Reprint 
        {
            CommonBAL commonBal=new CommonBAL();
            long logId;
            logId=commonBal.GenerateID("SBP_Check_Reprint_Log", "Log_Id");
            string queryLog = "INSERT INTO SBP_Check_Reprint_Log (Log_Id,Requisition_Id,Cust_Code,Amount,Requisition_Date,Payment_Media_No,Voucher_Sl_No,Check_Date,Collection_Branch_Id,Entry_Branch_ID,Modified_By,Modified_Date) SELECT " + logId + ",Sl_No,Cust_Code,Amount,Requisition_Date,(SELECT Payment_Media_No FROM SBP_Payment WHERE Requisition_ID=SBP_Check_Requisition.Sl_No),(SELECT Voucher_Sl_No FROM SBP_Payment WHERE Requisition_ID=SBP_Check_Requisition.Sl_No),(SELECT Received_Date FROM SBP_Payment WHERE Requisition_ID=SBP_Check_Requisition.Sl_No),Collection_Branch_Id,(SELECT Branch_ID FROM SBP_Users WHERE User_Name=SBP_Check_Requisition.Entry_By),'" + GlobalVariableBO._userName + "',CAST(FLOOR(CAST(GETDATE() AS FLOAT)) AS DATETIME) FROM SBP_Check_Requisition WHERE Sl_No=" + requisitionId + "";
            string queryUpdateRequisition = "UPDATE SBP_Check_Requisition SET Is_Printed=0 WHERE Sl_No=" + requisitionId + "";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();
                _dbConnection.ExecuteNonQuery(queryLog);
                _dbConnection.ExecuteNonQuery(queryUpdateRequisition);
                _dbConnection.Commit();
            }
            catch (Exception)
            {
                _dbConnection.Rollback();
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
        }

        public void ReceivedCheck(int requisitionId)
        {
            string queryUpdateRequisition = "UPDATE SBP_Check_Requisition SET Is_Received=1,Received_By='" + GlobalVariableBO._userName + "',Received_Date=CAST(FLOOR(CAST(GETDATE() AS FLOAT)) AS DATETIME) WHERE Sl_No=" + requisitionId + "";

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(queryUpdateRequisition);

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

        public DataTable GetReceivedCheckGridData(DateTime _searchDate)
        {
            DataTable dataTable = new DataTable();
            string queryString = "";
            queryString = "SELECT Sl_No,Cust_code AS 'Client Code',(SELECT Cust_Name FROM SBP_Cust_Personal_Info WHERE SBP_Cust_Personal_Info.Cust_code=SBP_Check_Requisition.Cust_code) AS 'Name',(SELECT Payment_Media_No FROM SBP_Payment WHERE Requisition_ID=SBP_Check_Requisition.Sl_No) AS 'Cheque No',Amount,Requisition_Date AS 'Requisition Date',(CASE WHEN Is_Printed=1 AND Is_Received=0 THEN 'Printed' WHEN Is_Approved=1 AND Is_Printed=0 THEN 'Approved' WHEN Is_Approved=0 THEN 'Pending' WHEN Is_Approved=2 THEN 'Rejected' WHEN Is_Received=1 AND Is_Printed=1 THEN 'Received' END) AS 'Status',(SELECT Branch_Name FROM SBP_Broker_Branch WHERE Branch_ID=Collection_Branch_ID) AS 'Collection Branch' FROM SBP_Check_Requisition WHERE Is_Received=1 AND Received_Date='"+_searchDate.ToShortDateString()+"' AND Collection_Branch_ID='" + GlobalVariableBO._branchId + "'";
            //"SELECT Sl_No,Cust_code AS 'Client Code',(SELECT Cust_Name FROM SBP_Cust_Personal_Info WHERE SBP_Cust_Personal_Info.Cust_code=SBP_Check_Requisition.Cust_code) AS 'Name',Amount,Requisition_Date AS 'Requisition Date',(CASE WHEN Is_Printed=1 THEN 'Printed' WHEN Is_Approved=1 AND Is_Printed=0 THEN 'Approved' WHEN Is_Approved=0 THEN 'Pending' WHEN Is_Approved=2 THEN 'Rejected' END) AS 'Status',(SELECT Branch_Name FROM SBP_Broker_Branch WHERE Branch_ID=Collection_Branch_ID) AS 'Collection Branch' FROM SBP_Check_Requisition WHERE Requisition_Date='" + searchDate + "' AND Collection_Branch_ID='" + GlobalVariableBO._branchId + "'";
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

        public DataTable RetrieveCustInfo(string custCodeForInfo)
        {
            DataTable dataTable = new DataTable();
            string queryString = "";
            queryString = "SELECT (SELECT TOP 1 CONVERT(varchar(12),EventDate,107)+' at '+ REPLACE(EventTime,'-',':') FROM SBP_Transactions WHERE Customer='" + custCodeForInfo + "' ORDER BY EventDate DESC) AS 'Last Trade Date',(SELECT SUM(TotalAmount) FROM SBP_Transactions WHERE Customer='" + custCodeForInfo + "' AND BuySellFlag='S' AND EventDate=(SELECT MAX(EventDate) FROM SBP_Transactions WHERE Customer='" + custCodeForInfo + "')) AS 'Last Trade Amount',(SELECT SUM(Balance) FROM SBP_Money_Balance_Temp WHERE Cust_Code='" + custCodeForInfo + "') AS 'CurrentBalance',(SELECT SUM(Matured_Balance) FROM SBP_Money_Balance_Temp WHERE Cust_Code='" + custCodeForInfo + "')AS 'MaturedBalance',(SELECT SUM(Amount) FROM SBP_Check_Requisition WHERE Is_Approved=0 AND Cust_Code='" + custCodeForInfo + "') AS 'Pending Requisition',(SELECT Cust_Status FROM SBP_Cust_Status,dbo.SBP_Customers WHERE SBP_Cust_Status.Cust_Status_ID=dbo.SBP_Customers.Cust_Status_ID AND Cust_Code='" + custCodeForInfo + "')AS Status";
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

        public void CancelCheckRequisition(int requisitionId)
        {
            string queryUpdateRequisition = "DELETE FROM SBP_Check_Requisition WHERE Sl_No=" + requisitionId + "";

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(queryUpdateRequisition);

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

        public DataTable ChequePaymentInfo(DateTime date)
        {
            string queryString = "SELECT 3101085921001 AS 'Account No',CONVERT(VARCHAR(10),SBP_Payment.Received_Date,105) AS 'Date',ISNULL((SELECT Cust_Name FROM SBP_Cust_Personal_Info WHERE SBP_Cust_Personal_Info.Cust_Code=SBP_Payment.Cust_Code),'Not Found') AS 'Name of the Benificiery',SBP_Payment.Payment_Media_No AS 'Cheque Serial No',SBP_Payment.Amount AS 'Amount',"+
                                 "(SELECT CASE IsACPayee WHEN 1 THEN 'A/C Pay' ELSE 'Cash' END FROM SBP_Check_Requisition WHERE  Sl_No = Requisition_ID)AS 'A/C Pay/Cash' FROM SBP_Payment WHERE Payment_Media='Check' AND Deposit_Withdraw='Withdraw'  AND SBP_Payment.Received_Date='"+date.ToShortDateString()+"'";
            DataTable data = new DataTable();

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
