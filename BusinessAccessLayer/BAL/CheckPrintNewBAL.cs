using System;
using System.Data;
using System.Windows.Forms;
using BusinessAccessLayer.BO;
using DataAccessLayer;
using BusinessAccessLayer.Constants;

namespace BusinessAccessLayer.BAL
{
    public class CheckPrintNewBAL
    {
        private DbConnection _dbConnection;
        public CheckPrintNewBAL()
        {
            _dbConnection = new DbConnection();
        }
        public DataTable GetAllCheckReceiver()
        {
            DataTable dataTable;
            dataTable = null;
            string queryString = "";
            queryString = "SELECT SBP_Payment.Cust_Code AS 'Client Code',(SELECT Cust_Name FROM SBP_Cust_Personal_Info WHERE SBP_Cust_Personal_Info.Cust_Code=SBP_Payment.Cust_Code) AS 'Name',SBP_Payment.Amount,SBP_Payment.Received_Date AS 'Date',SBP_Payment.Payment_ID,SBP_Payment.Requisition_ID,SR.IsACPayee  FROM SBP_Payment,SBP_Check_Requisition SR WHERE Deposit_Withdraw='Withdraw' AND Payment_Media='Check' AND Requisition_ID IN(SELECT Sl_No FROM SBP_Check_Requisition WHERE Is_Approved=1 AND Is_Printed=0) AND SR.Sl_No=SBP_Payment.Requisition_ID ORDER BY Payment_ID ASC";
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

        public bool UpdateRequiredData(int paymentID,int requisitionID,string checkNo, string voucherNo,int IsACPayee)
        {
            string queryUpdatePrintStatus = "UPDATE SBP_Payment SET Payment_Media_No='" + checkNo + "',Voucher_Sl_No='" + voucherNo + "' WHERE Payment_ID=" + paymentID + "";
            string queryUpdatePayment = "UPDATE SBP_Check_Requisition SET Is_Printed=1,IsACPayee="+IsACPayee+" WHERE Sl_No=" + requisitionID + "";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();
                _dbConnection.ExecuteNonQuery(queryUpdatePayment);
                _dbConnection.ExecuteNonQuery(queryUpdatePrintStatus);
                _dbConnection.Commit();
                return true;
            }
            catch (Exception)
            {
                _dbConnection.Rollback();
                return false;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            
        }

        public bool ValidateCheckNo(string checkNo)
        {
            DataTable dataTable;
            dataTable = null;
            string queryString = "";
            queryString = "SELECT Payment_Media_No FROM SBP_Payment WHERE Payment_Media_No='" + checkNo + "' AND Payment_Media='"+Indication_PaymentTransaction.Cheque+"' AND Deposit_Withdraw='" + Indication_PaymentMode.Withdraw + @"'";
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
                return false;
            else
            {
                return true;
            }
        }
        public bool ValidateVoucherNo(string voucherNo)
        {
            DataTable dataTable;
            dataTable = null;
            string queryString = "";
            queryString = "SELECT Voucher_Sl_No FROM SBP_Payment WHERE Voucher_Sl_No='" + voucherNo + "' AND Payment_Media='Check'";
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
                return false;
            else
            {
                return true;
            }
        }
        public DataTable GetDataForPrinting(int paymentID,int requisitionID, string author)
        {
            DataTable dataTable=new DataTable();
            string queryString = "";
            queryString = "SELECT Cust_Code,(SELECT Name FROM SBP_Broker_Info) AS 'Broker_Name',(SELECT Cust_Name FROM SBP_Cust_Personal_Info WHERE SBP_Cust_Personal_Info.Cust_Code=SBP_Payment.Cust_Code) AS 'Cust_Name',CONVERT(DECIMAL(16,2),Amount) AS Amount,dbo.Currency_Words(Amount) AS 'Amount_Words',Received_Date,'" + author + "' AS 'Author',(SELECT Branch_Name FROM SBP_Broker_Branch WHERE Branch_ID=(SELECT Collection_Branch_ID FROM SBP_Check_Requisition WHERE Sl_No=" + requisitionID + ")) AS 'Branch_ID' FROM SBP_Payment WHERE Payment_ID=" + paymentID + "";
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
    }
}
