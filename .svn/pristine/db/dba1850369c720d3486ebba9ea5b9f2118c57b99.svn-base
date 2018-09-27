using System;
using System.Data;
using BusinessAccessLayer.BO;
using DataAccessLayer;

namespace BusinessAccessLayer.BAL
{
    public class ServiceRegistrationBAL
    {
        private DbConnection _dbConnection;
        
        public ServiceRegistrationBAL()
        {
            _dbConnection = new DbConnection();
        }
        
        public DataTable GetAllData(string custCode)
        {
            DataTable dataTable;
            string queryString = "";
            queryString = @"SELECT 
                            Cust_Code
                            ,Web_Service
                            ,SMS_Confirmation
                            ,SMS_Trade
                            ,E_Charge
                            ,Remarks
                            ,Reg_Date
                            ,Email
                            ,Mobile_No
                            ,SMS_MoneyDeposit_Confirmation
                            ,SMS_MoneyWithdraw_Confirmation
                            ,SMS_EFTWithdraw_Confirmation
                            ,[MoneyDeposit_Confirmation_Email]
                            ,[MoneyWithdraw_Confirmation_Email]
                            ,[EFTWithdraw_Confirmation_Email]
                            ,[Trade_Confirmation_Email] 
                            FROM SBP_Service_Registration 
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

      // Service Update / web Uploding Data save

        public void Post_For_WebUPdate(string Cust_code)
        {
            string queryString = "";

            queryString = @"INSERT INTO SBP_Service_Uplode
                                 (Cust_Code, Email, Mobile_No, Remarks, Entry_Date, Entry_By, UpdateStatus)
                                 (SELECT Cust_Code, Email, Mobile_No, Remarks, Entry_Date, Entry_By,'0'
                                  FROM SBP_Service_Registration
                                     WHERE (Cust_Code = N'"+Cust_code+ @"') AND (Web_Service = 1)
                                 )";
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




        public void Insert(ServiceRegistrationBO serviceRegBo)
        {
            string queryString = "";

            queryString = @"SBPSaveServiceReg";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@CustCode", SqlDbType.NVarChar, serviceRegBo.CustCode);
                _dbConnection.AddParameter("@WebService", SqlDbType.Bit, serviceRegBo.WebService);
                _dbConnection.AddParameter("@SmsConf", SqlDbType.Bit, serviceRegBo.SmsConf);
                _dbConnection.AddParameter("@SmsTrade", SqlDbType.Bit, serviceRegBo.SmsTrade);
                _dbConnection.AddParameter("@ECharge", SqlDbType.Bit, serviceRegBo.ECharge);
                _dbConnection.AddParameter("@EMail", SqlDbType.VarChar, serviceRegBo.EMail);
                _dbConnection.AddParameter("@Mobile", SqlDbType.VarChar, serviceRegBo.Mobile);
                _dbConnection.AddParameter("@Remarks", SqlDbType.VarChar, serviceRegBo.Remarks);
                _dbConnection.AddParameter("@RegDate",SqlDbType.DateTime,serviceRegBo.RegDate);
                _dbConnection.AddParameter("@entryBy", SqlDbType.VarChar, GlobalVariableBO._userName);
                _dbConnection.AddParameter("@MoneyDeposit", SqlDbType.Bit, serviceRegBo.Sms_Money_Deposit);
                _dbConnection.AddParameter("@MoneyWithdraw", SqlDbType.Bit, serviceRegBo.Sms_Money_Withdraw);
                _dbConnection.AddParameter("@EFTWithdraw", SqlDbType.Bit, serviceRegBo.Sms_Eft_Withdraw);
                _dbConnection.AddParameter("@MoneyDeposit_Email", SqlDbType.Bit, serviceRegBo.Email_Money_Deposit);
                _dbConnection.AddParameter("@MoneyWithdraw_Email", SqlDbType.Bit, serviceRegBo.Email_Money_Withdraw);
                _dbConnection.AddParameter("@EftWithdraw_Email", SqlDbType.Bit, serviceRegBo.Email_Eft_Withdraw);
                _dbConnection.AddParameter("@Trade_Confirmation_Email", SqlDbType.Bit, serviceRegBo.Email_Trade_Confirmation);
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

        public void Update(ServiceRegistrationBO serviceRegBo)
        {
            string queryString = "";
            queryString = @"SBPUpdateServiceReg";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@CustCode", SqlDbType.NVarChar, serviceRegBo.CustCode);
                _dbConnection.AddParameter("@WebService", SqlDbType.Bit, serviceRegBo.WebService);
                _dbConnection.AddParameter("@SmsConf", SqlDbType.Bit, serviceRegBo.SmsConf);
                _dbConnection.AddParameter("@SmsTrade", SqlDbType.Bit, serviceRegBo.SmsTrade);
                _dbConnection.AddParameter("@ECharge", SqlDbType.Bit, serviceRegBo.ECharge);
                _dbConnection.AddParameter("@EMail", SqlDbType.VarChar, serviceRegBo.EMail);
                _dbConnection.AddParameter("@Mobile", SqlDbType.VarChar, serviceRegBo.Mobile);
                _dbConnection.AddParameter("@Remarks", SqlDbType.VarChar, serviceRegBo.Remarks);
                _dbConnection.AddParameter("@RegDate", SqlDbType.DateTime, serviceRegBo.RegDate);
                _dbConnection.AddParameter("@entryBy", SqlDbType.VarChar, GlobalVariableBO._userName);
                _dbConnection.AddParameter("@MoneyDeposit", SqlDbType.Bit, serviceRegBo.Sms_Money_Deposit);
                _dbConnection.AddParameter("@MoneyWithdraw", SqlDbType.Bit, serviceRegBo.Sms_Money_Withdraw);
                _dbConnection.AddParameter("@EFTWithdraw", SqlDbType.Bit, serviceRegBo.Sms_Eft_Withdraw);
                _dbConnection.AddParameter("@MoneyDeposit_Email", SqlDbType.Bit, serviceRegBo.Email_Money_Deposit);
                _dbConnection.AddParameter("@MoneyWithdraw_Email", SqlDbType.Bit, serviceRegBo.Email_Money_Withdraw);
                _dbConnection.AddParameter("@EftWithdraw_Email", SqlDbType.Bit, serviceRegBo.Email_Eft_Withdraw);
                _dbConnection.AddParameter("@Trade_Confirmation_Email", SqlDbType.Bit, serviceRegBo.Email_Trade_Confirmation);
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

        public bool CheckCustomerCodeDuplicate(string custCode)
        {
            DataTable dataTable;
            string queryString = "";
            queryString = "SELECT Cust_Code FROM SBP_Service_Registration WHERE Cust_Code='" + custCode + "'";
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

        public DataTable GetAllRegisteredClient()
        {
            DataTable dataTable;
            string queryString = "";
            queryString = "SELECT Cust_Code AS 'Client Code',Web_Service AS 'WEB',SMS_Confirmation AS 'SMS Conf.',SMS_Trade AS 'SMS Trade',E_Charge AS 'E-Charge',Email,Mobile_No AS 'Mobile',Remarks,Reg_Date AS 'Reg Date' FROM SBP_Service_Registration";
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

        public DataTable GetServiceRegistationInfo(string CustCode)
        {
            string queryString = "GetServiceRegInfo";
            DataTable data = new DataTable();

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@custCode",SqlDbType.VarChar,CustCode);
                data=_dbConnection.ExecuteProQuery(queryString);
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
