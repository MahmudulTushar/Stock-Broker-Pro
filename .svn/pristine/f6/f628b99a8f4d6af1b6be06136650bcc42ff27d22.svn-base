using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessAccessLayer.BAL;
using System.Data;

namespace ElectronicCommunication.Web
{
    public class WebSenderReceiver
    {
        public void ExportIPO_Session_Company()
        {
            WebDataExportBAL bal = new WebDataExportBAL();
            DataTable dt = new DataTable();
            try
            {
                bal.Connect_SMS();
                bal.Connect_Web();

                dt = bal.GetData_IPOCompany_SessionInfo();
                bal.UploadDataWeb_CompanyInfo(dt);
                bal.UploadDataWeb_SessionInfo(dt);
                bal.UpdateWebSyncFlag_IPOCompany_SessionData(dt);

                bal.Commit_Web();
                bal.Commit_SMS();
                //MessageBox.Show("Upload Successfully");
            }
            catch (Exception ex)
            {
                bal.Rollback_Web();
                bal.Rollback_SMS();
                throw new Exception(ex.Message);
            }
            finally
            {
                bal.CloseConnection_Web();
                bal.CloseConnection_SMS();
            }
        }

        public void ExportIPO_AccountBalance()
        {
            WebDataExportBAL bal = new WebDataExportBAL();
            DataTable dt = new DataTable();
            try
            {
                bal.Connect_SMS();
                bal.Connect_Web();

                dt = bal.GetIpo_RecentIPOAccountBalance_ForWeb_UITransApplied();
                bal.UploadDataWeb_RecentIPOAccountBalance_UITransApplied(dt);
                bal.UpdateWebSyncFlag_RecentIPOAccountBalance(dt);

                bal.Commit_Web();
                bal.Commit_SMS();
                
            }
            catch (Exception ex)
            {
                bal.Rollback_Web();
                bal.Rollback_SMS();
                throw new Exception(ex.Message);
            }
            finally
            {
                bal.CloseConnection_Web();
                bal.CloseConnection_SMS();
            }
        }

        public void ExportIPO_ParentChinldInfo()
        {
            WebDataExportBAL bal = new WebDataExportBAL();
            DataTable dt = new DataTable();
            try
            {
                bal.Connect_SMS();
                bal.Connect_Web();

                dt = bal.GetDataWeb_AccountGroupingInfo();
                bal.UploadDataWeb_AccountGroupingInfo(dt);
                bal.UpdateWebSyncFlag_AccountGroupingInfo(dt);

                bal.Commit_Web();
                bal.Commit_SMS();
                
            }
            catch (Exception ex)
            {
                bal.Rollback_Web();
                bal.Rollback_SMS();
                throw new Exception(ex.Message);
                
            }
            finally
            {
                bal.CloseConnection_Web();
                bal.CloseConnection_SMS();
            }
        }

        public void ExportStatusIPO_ApplicationStatus()
        {
            WebDataExportBAL bal = new WebDataExportBAL();
            DataTable dt = new DataTable();
            try
            {
                bal.Connect_SMS();
                bal.Connect_Web();

                dt = bal.GetData_IPoApplication_MoneyTransaction_UITransApllied();
                bal.UploadDataWeb_IPOApplication_MoneyTransaction_UITransApplied(dt);
                bal.UpdateWebSyncFlag_IPOApplication_MoneyTransaction_UITransApplied(dt);

                bal.Commit_Web();
                bal.Commit_SMS();
                
            }
            catch (Exception ex)
            {
                bal.Rollback_Web();
                bal.Rollback_SMS();
                throw new Exception(ex.Message);
                
            }
            finally
            {
                bal.CloseConnection_Web();
                bal.CloseConnection_SMS();
            }
        }

        public void ExportStatusIPO_MoneyTransaction()
        {
            WebDataExportBAL bal = new WebDataExportBAL();
            DataTable dt = new DataTable();
            try
            {
                bal.Connect_SMS();
                bal.Connect_Web();

                dt = bal.GetData_FreeMoneyTransaction_UITransApplied();
                bal.UploadDataWeb_FreeMoneyTransaction_UITransApplied(dt);
                bal.UpdateWebSyncFlag_FreeMoneyTransaction_UITransApplied(dt);

                bal.Commit_Web();
                bal.Commit_SMS();
               
            }
            catch (Exception ex)
            {
                bal.Rollback_Web();
                bal.Rollback_SMS();
                throw new Exception(ex.Message);
               
            }
            finally
            {
                bal.CloseConnection_Web();
                bal.CloseConnection_SMS();
            }
        }

        public void ExportIPO_CustomerProfile()
        {
            WebDataExportBAL bal = new WebDataExportBAL();
            DataTable dt = new DataTable();
            try
            {
                bal.Connect_SMS();
                bal.Connect_Web();

                dt = bal.GetData_UpdatedRegistration_UITransApplied();
                bal.UploadDataWeb_CustomerProfile_UITransApplied(dt);
                bal.UpdateWebSyncFlag_CustomerProfile_UITransApplied(dt);

                bal.Commit_Web();
                bal.Commit_SMS();
                
            }
            catch (Exception ex)
            {
                bal.Rollback_Web();
                bal.Rollback_SMS();
                throw new Exception(ex.Message);
                
            }
            finally
            {
                bal.CloseConnection_Web();
                bal.CloseConnection_SMS();
            }
        }

        public void ImportIPO_NewApplication_MoneyTransactionRequest()
        {
            Web2014DataImportBAL bal = new Web2014DataImportBAL();
            DataTable dt = new DataTable();
            try
            {
                bal.Connect_SMS();
                bal.Connect_Web();

                dt = bal.GetDataWeb_IPOApplicationMoneyTransRequest_UITransApplied();
                bal.InsertData_WebReceiveAll_UITransApplied(dt);
                bal.UpdateWebSyncFlagWeb_IPOApplicationMoneyTransRequest_UITransApplied(dt);

                bal.Commit_Web();
                bal.Commit_SMS();
                
            }
            catch (Exception ex)
            {
                bal.Rollback_Web();
                bal.Rollback_SMS();
                throw new Exception(ex.Message);

                
            }
            finally
            {
                bal.CloseConnection_Web();
                bal.CloseConnection_SMS();
            }
        }

        public void DataProcessIPO_Create_Application_Transaction_Request_FromWeb()
        {
            Web2014DataImportBAL bal = new Web2014DataImportBAL();
            DataTable dt = new DataTable();
            try
            {
                bal.Connect_SMS();
                bal.InsertData_WebRequest_UITransApplied();
                bal.Commit_SMS();
            }
            catch (Exception ex)
            {
                bal.Rollback_SMS();
                throw new Exception(ex.Message);

            }
            finally
            {
                bal.CloseConnection_SMS();
            }
        }
    }
}
