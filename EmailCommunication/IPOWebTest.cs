using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using System.Data.SqlClient;

namespace ElectronicCommunication
{
    public partial class IPOWebTest : Form
    {
        public IPOWebTest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
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
                MessageBox.Show("Upload Successfully");
            }
            catch (Exception ex)
            {
                bal.Rollback_Web();
                bal.Rollback_SMS();
                MessageBox.Show(ex.Message);
            }
            finally
            {
                bal.CloseConnection_Web();
                bal.CloseConnection_SMS();
            }
        }

        private void button3_Click(object sender, EventArgs e)
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

                MessageBox.Show("Upload Successfully");
            }
            catch (Exception ex)
            {
                bal.Rollback_Web();
                bal.Rollback_SMS();
                MessageBox.Show(ex.Message);
            }
            finally
            {
                bal.CloseConnection_Web();
                bal.CloseConnection_SMS();
            }
        }

        private void button4_Click(object sender, EventArgs e)
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
                MessageBox.Show("Upload Successfully");
            }
            catch (Exception ex)
            {
                bal.Rollback_Web();
                bal.Rollback_SMS();
                MessageBox.Show(ex.Message);
            }
            finally
            {
                bal.CloseConnection_Web();
                bal.CloseConnection_SMS();
            }
        }

        private void button5_Click(object sender, EventArgs e)
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
                MessageBox.Show("Upload Successfully");
            }
            catch (Exception ex)
            {
                bal.Rollback_Web();
                bal.Rollback_SMS();
                MessageBox.Show(ex.Message);
            }
            finally
            {
                bal.CloseConnection_Web();
                bal.CloseConnection_SMS();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Web2014DataImportBAL bal = new Web2014DataImportBAL();
            DataTable dt = new DataTable();
            try
            {
                bal.Connect_SMS();
                bal.InsertData_WebRequest_UITransApplied();
                bal.Commit_SMS();
                MessageBox.Show("Upload Successfully");
            }
            catch (Exception ex)
            {
                bal.Rollback_SMS();
                MessageBox.Show(ex.Message);
            }
            finally
            {
                bal.CloseConnection_SMS();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                SMSSyncBAL bal = new SMSSyncBAL();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e)
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
                MessageBox.Show("Upload Successfully");
            }
            catch (Exception ex)
            {
                bal.Rollback_Web();
                bal.Rollback_SMS();
                MessageBox.Show(ex.Message);
            }
            finally
            {
                bal.CloseConnection_Web();
                bal.CloseConnection_SMS();
            }
        }

        private void button9_Click(object sender, EventArgs e)
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
                MessageBox.Show("Upload Successfully");
            }
            catch (Exception ex)
            {
                bal.Rollback_Web();
                bal.Rollback_SMS();
                MessageBox.Show(ex.Message);
            }
            finally
            {
                bal.CloseConnection_Web();
                bal.CloseConnection_SMS();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            WebDataExportBAL bal = new WebDataExportBAL();
            DataTable dt = new DataTable();
            try
            {
                bal.Connect_SMS();
                bal.Connect_Web();
                
                dt=bal.GetData_FreeMoneyTransaction_UITransApplied();
                bal.UploadDataWeb_FreeMoneyTransaction_UITransApplied(dt);
                bal.UpdateWebSyncFlag_FreeMoneyTransaction_UITransApplied(dt);
                
                bal.Commit_Web();
                bal.Commit_SMS();
                MessageBox.Show("Upload Successfully");
            }
            catch (Exception ex)
            {
                bal.Rollback_Web();
                bal.Rollback_SMS();
                MessageBox.Show(ex.Message);
            }
            finally
            {
                bal.CloseConnection_Web();
                bal.CloseConnection_SMS();
            }
        }

    }
}
