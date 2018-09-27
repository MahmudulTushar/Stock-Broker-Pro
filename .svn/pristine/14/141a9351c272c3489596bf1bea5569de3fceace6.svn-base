using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessAccessLayer.BO;
using DataAccessLayer;

namespace BusinessAccessLayer.BAL
{
    public class SMSDataEditBAL
    {
        private DbConnection _dbConnection;
        

        public SMSDataEditBAL()
        {
            _dbConnection = new DbConnection();
        }

        public void GenerateSmsConfOldTempTable()
        {
            string queryString = @"GenerateSmsConfTempTable";

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
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
       
        public void GenerateSmsConfTempTable()
        {
            string queryString = @"GenerateSmsConfTempTable_FlexTP";

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
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



        public DataTable LoadData(string ID)
        {
            string queryString = @"SELECT * FROM SBP_SmsConfTemp WHERE SmsID=" + ID;
            DataTable dataTable;
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

        public void UpdateSmsInfo(SMSConfEdit smsConfEdit)
        {
            string queryString = @"UPDATE SBP_SmsConfTemp SET Customer='" + smsConfEdit.Customer + "',BuySellFlag='" + smsConfEdit.BuySell + "',InstrumentCode='" + smsConfEdit.Instrument + "',TradeQty=" + smsConfEdit.TradeQty + ",TradePrice=" + smsConfEdit.TradePrice + ",MobileNo='" + smsConfEdit.MobileNo + "' WHERE SmsID=" + smsConfEdit.SmsId;
            try
            {
                _dbConnection.ConnectDatabase();
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


        public bool CheckCustomer(string custCode)
        {
            string queryString = @"SELECT * FROM SBP_Customers WHERE Cust_Code='" + custCode + "'";
            DataTable dataTable;
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
            if (dataTable.Rows.Count > 0)
                return true;
            else
                return false;
        }
    }

}
