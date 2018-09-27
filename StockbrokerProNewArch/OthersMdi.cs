using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using StockbrokerProNewArch.Classes;
using BusinessAccessLayer.BAL;
using BusinessAccessLayer.BO;
using System.Threading;
using BusinessAccessLayer.Constants;
using EmailCommunication;
using System.Data.SqlClient;
using ElectronicCommunication;

namespace StockbrokerProNewArch
{
    public partial class OthersMdi : Form
    {
        private WaitWindow waitWindow;
        public static bool isProgressed;
        
        public OthersMdi()
        {
            InitializeComponent();
        }

        private void dataSyncronizationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CcsSyncFrm ccsSyncFrm = new CcsSyncFrm();
            ccsSyncFrm.MdiParent = this;
            ccsSyncFrm.Show();
        }

        private void webDataExportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string foldername = folderBrowserDialog.SelectedPath;

                WebDataExportCls webDataExport = new WebDataExportCls();
                webDataExport.GenerateFile(foldername);
            }

        }

        private void OthersMdi_Load(object sender, EventArgs e)
        {
            ResetPriviliage();
            LoadPrevillize();
        }

        private void ResetPriviliage()
        {
            webDataExportToolStripMenuItem.Visible = false;
            dataSyncronizationToolStripMenuItem.Visible = false;
            //dataSyncronizationToolStripMenuItem1.Visible = false;
            webDataImportTestingFor2014WebToolStripMenuItem.Visible = false;
            toolStripMenuItem2.Visible = false;
            webDataExportToolStripMenuItem.Visible = false;
            toolStripMenuItem1.Visible = false;
            userQueryListToolStripMenuItem1.Visible = false;
            serviceRegistrationListToolStripMenuItem.Visible = false;
            inCommingToolStripMenuItem.Visible = false;
            moneyTransactionSMSToolStripMenuItem.Visible = false;
            exportIPOInformationToolStripMenuItem.Visible = false;
            moneyTransactionEmailNotificationToolStripMenuItem.Visible = false;
            tradeConfirmationEmailNotificationToolStripMenuItem.Visible = false;
            financialNettingToolStripMenuItem.Visible = false;
            xMLImportToolStripMenuItem.Visible = false;
            sMSTestingToolStripMenuItem.Visible = false;
            customerReportToolStripMenuItem.Visible = false;
            webDataReconcilationToolStripMenuItem.Visible = false;
        }

        private void LoadPrevillize()
        {
            bool result = false;
            // DataTable previllizeDataTable = new DataTable();
            DataTable RoleWithUserprevillizeDataTable = new DataTable();
            DataTable RolewisePrevillizeDataTable = new DataTable();

            PrevillizeManagementBAL previllizeManagementBal = new PrevillizeManagementBAL();
            RoleWithUserprevillizeDataTable = previllizeManagementBal.GetAssignedPrevillize();
            if (RoleWithUserprevillizeDataTable.Rows.Count > 0)
            {
                for (int i = 0; i < RoleWithUserprevillizeDataTable.Rows.Count; i++)
                {
                    if (RoleWithUserprevillizeDataTable.Rows[i][0].ToString().ToLower() == GlobalVariableBO._userName.ToLower())
                    {
                        result = true;
                        break;
                    }
                }
                if (result)
                {
                    for (int i = 0; i < RoleWithUserprevillizeDataTable.Rows.Count; i++)
                    {
                        if (RoleWithUserprevillizeDataTable.Rows[i][0].ToString().ToLower() == GlobalVariableBO._userName.ToLower())
                        {
                            SetPrevillize(RoleWithUserprevillizeDataTable.Rows[i]["Previllize"].ToString());
                        }
                    }
                }

                // DeactiveMenu();
            }
            else if (RoleWithUserprevillizeDataTable.Rows.Count == 0)
            {
                RolewisePrevillizeDataTable = previllizeManagementBal.GetRoleWisePrevillize();

                for (int i = 0; i < RolewisePrevillizeDataTable.Rows.Count; i++)
                {
                    SetPrevillize(RolewisePrevillizeDataTable.Rows[i]["Previllize"].ToString());
                }
                // DeactiveMenu();
            }

            //previllizeDataTable = previllizeManagementBal.GetUserPrevillize();
            //for (int i = 0; i < previllizeDataTable.Rows.Count; i++)
            //{
            //    SetPrevillize(previllizeDataTable.Rows[i][0].ToString());
            //}
        }

        private void SetPrevillize(string previllize)
        {
            switch (previllize)
            {
                case "Web Data Export":
                    webDataExportToolStripMenuItem.Visible = true;
                    break;

                case "Data Synchronization":
                    dataSyncronizationToolStripMenuItem.Visible = true;
                    break;

                case "SMS Testing":
                    sMSTestingToolStripMenuItem.Visible = true;
                    break;

                case "Customer Report":
                    customerReportToolStripMenuItem.Visible = true;
                    break;
                case "Web Data Reconcilation":
                    webDataReconcilationToolStripMenuItem.Visible = true;
                    break;

                case "Financial Netting":
                    financialNettingToolStripMenuItem.Visible = false;
                    break;

                case "XML Import":
                    xMLImportToolStripMenuItem.Visible = false;
                    break;

                case "Trade Confirmation Email Notification":
                    tradeConfirmationEmailNotificationToolStripMenuItem.Visible = true;
                    break;

                case "Money Transaction Email Notification":
                    moneyTransactionEmailNotificationToolStripMenuItem.Visible = true;
                    break;

                //case "DD":
                //dataSyncronizationToolStripMenuItem1.Visible = true;
                //break;

                case "Web Data Import - Testing For 2014 Web":
                    webDataImportTestingFor2014WebToolStripMenuItem.Visible = true;
                    break;

                case "Web Data Export - Testing For 2014 Web":
                    toolStripMenuItem2.Visible = true;
                    break;

                case "Web Data Export - New":
                    webDataExportToolStripMenuItem.Visible = true;
                    break;

                case "Web Data Export - Previous":
                    toolStripMenuItem1.Visible = true;
                    break;

                case "User Query List":
                    userQueryListToolStripMenuItem1.Visible = true;
                    break;

                case "Service Registration List":
                    serviceRegistrationListToolStripMenuItem.Visible = true;
                    break;

                case "Import-IPO Request":
                    inCommingToolStripMenuItem.Visible = true;
                    break;

                case "Export-Money Transaction":
                    moneyTransactionSMSToolStripMenuItem.Visible = true;
                    break;

                case "Export- IPO Information":
                    exportIPOInformationToolStripMenuItem.Visible = true;
                    break;


                default:
                    break;
            }
        }

        private void financialNettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FinNetting finNetting = new FinNetting();
            finNetting.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmWebDataExport objExport=new frmWebDataExport();
            objExport.MdiParent = this;
            objExport.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string foldername = folderBrowserDialog.SelectedPath;
                
                Thread thrd = new Thread(WaitWindow_Thread);
                isProgressed=true;
                thrd.Start();
                WebDataExportCls webDataExport = new WebDataExportCls();
                webDataExport.GenerateFileForWeb_2014(foldername,"");
            }
        }

        private void webDataImportTestingFor2014WebToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmWeb2014DataImport frm = new frmWeb2014DataImport();
            frm.Show();
        }

        private void userQueryListToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmWeb2014DataForward frm = new frmWeb2014DataForward("User Query Forward");
            frm.Show();
        }

        private void moneyWithdrawalListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmWeb2014DataForward frm = new frmWeb2014DataForward("Money Withdraw Forward");
            frm.Show();
        }

        private void serviceRegistrationListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmWeb2014DataForward frm = new frmWeb2014DataForward("Service Registration Forward");
            frm.Show();
        }

        private void moneyTransactionSMSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Thread thrd = new Thread(WaitWindow_Thread);
                isProgressed = true;
                thrd.Start();
                frmSMSConfirmationProcess frm = new frmSMSConfirmationProcess(MenuNameList.SMS_Money_Transaction);
                isProgressed = false;
                frm.Show();                
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }            
        }
        
        private void WaitWindow_Thread()
        {
            WaitWindow waitWindow = new WaitWindow();
            waitWindow.Show();
            while (isProgressed)
            {
                waitWindow.Refresh();
            }
            waitWindow.Close();
        }

        private void tradeConfirmationEmailNotificationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Thread thrd = new Thread(WaitWindow_Thread);
            isProgressed = true;
            MessageBox.Show("This Window May Takes 4/5 min To Open Please Wait....");
            thrd.Start();
            frmSMSConfirmationProcess frm = new frmSMSConfirmationProcess(MenuNameList.Email_Trade_Confirmation);
            isProgressed = false;
            frm.ShowDialog(this);
        }

        private void moneyTransactionEmailNotificationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread thrd = new Thread(WaitWindow_Thread);
            isProgressed = true;
            thrd.Start();
            frmSMSConfirmationProcess frm = new frmSMSConfirmationProcess(MenuNameList.Email_Money_Transaction);
            isProgressed = false;
            frm.ShowDialog(this);  
        }

        private void xMLImportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SBPXMLSchema.Sample smp = new SBPXMLSchema.Sample();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void inCommingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread thrd = new Thread(WaitWindow_Thread);
            isProgressed = true;
            thrd.Start();
            SMSSyncBAL syncBal = new SMSSyncBAL();
            try
            {
                DataTable dt_GotAlreadyRequested = new DataTable();
                DataTable dt_GotAlreadyRequested_SingleApplication = new DataTable();
                DataTable dt_GotNewRequest = new DataTable();
                DataTable dt_GotAlreadyRequested_Email = new DataTable();
                DataTable dt_GotAlreadyRequest_Web = new DataTable();
                DataTable dt_GotNewRequest_Web = new DataTable();
                DataTable dt_GotDeposit_Withdraw_SMS = new DataTable();
                DataTable dt_GotDeposit_Withdraw_Email = new DataTable();


                syncBal.Connect_SBP();
                syncBal.Connect_SMS();

                syncBal.TruncateTable_SMSSyncImportIPORequest_UITransApplied();

                dt_GotDeposit_Withdraw_SMS = syncBal.GetProcessedDeposit_Withdraw_Request_SMS();
                dt_GotDeposit_Withdraw_Email = syncBal.GetProcessedDeposit_Withdraw_Request_Email();

                dt_GotAlreadyRequested = syncBal.GetProcessedIPORequest_UITransApplied();
                //dt_GotNewRequest = syncBal.GetNewIPORequest_UITransApplied(dt_GotAlreadyRequested);
                dt_GotAlreadyRequested_Email = syncBal.GetProcessedIPORequest_UITransApplied_Email();
                dt_GotAlreadyRequest_Web = syncBal.GetProcessedIPORequest_ForWeb_UITransApplied();

                dt_GotNewRequest = syncBal.GetNewIPORequest_UITransApplied(dt_GotAlreadyRequested, dt_GotAlreadyRequested_Email, dt_GotDeposit_Withdraw_SMS, dt_GotDeposit_Withdraw_Email);
                dt_GotNewRequest_Web = syncBal.GetNewIPORequest_FroWeb_UITransApplied(dt_GotAlreadyRequest_Web);

                syncBal.InsertTable_SMSSyncImportIPORequest_UITransApplied(dt_GotNewRequest);
                syncBal.InsertTable_SMSSyncImportIPORequest_UITransApplied(dt_GotNewRequest_Web);

                syncBal.Commit_SBP();
                syncBal.Connect_SMS();
                isProgressed = false;
                MessageBox.Show("Data Imported Successfully!!");
                
            }
            catch (Exception ex)
            {
                syncBal.Rollback_SBP();
                syncBal.Rollback_SMS();
                isProgressed = false;
                MessageBox.Show(ex.Message);
            }
            finally
            {
                syncBal.CloseConnection_SBP();
                syncBal.CloseConnection_SMS();
            }
        }

        private void sMSTestingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frm_SMSSender frm = new frm_SMSSender();
            //frm.StartPosition = FormStartPosition.CenterScreen;
            //frm.Show();
        }

        private void exportIPOInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread thrd = new Thread(WaitWindow_Thread);
            isProgressed = true;
            thrd.Start();
            SMSSyncBAL syncBal = new SMSSyncBAL();
            try
            {
                //DataTable dt_GotExported_IpoCompSessInfo = new DataTable();
                //DataTable dt_GotExported_CustomerAll = new DataTable();
                //DataTable dt_GotExported_CustTradeAccBalance = new DataTable();
                //DataTable dt_GotExported_CustIpoAccBalance = new DataTable();

                SqlDataReader dt_GotExported_IpoCompSessInfo;
                SqlDataReader dt_GotExported_CustomerAll;
                SqlDataReader dt_GotExported_CustTradeAccBalance;
                SqlDataReader dt_GotExported_CustIpoAccBalance;
                SqlDataReader dt_GotIpoCharge;
                SqlDataReader dt_AccountGrouping;
                SqlDataReader dt_ServiceRegistration;
                SqlDataReader dt_AllreadyApplied;
                SqlDataReader dt_MoneyTransRequest;

                syncBal.Connect_SBP();
                syncBal.Connect_SMS();

                //Export IPO Session & Company Info
                dt_GotExported_IpoCompSessInfo = syncBal.GetIPO_SessionforCompanyInfo_UITransApplied();
                syncBal.TruncateTable_SMSSyncExport_IPO_SessionforCompanyInfo_UITransApplied();
                syncBal.InsertTable_SMSSyncExport_IPO_SessionforCompanyInfo_UITransApplied(dt_GotExported_IpoCompSessInfo);

                ////Export Customer Trade Acc
                //dt_GotExported_CustTradeAccBalance = syncBal.GetIPO_Customer_Trade_Account_UITransApplied();
                //syncBal.TruncateTable_SMSSyncExport_Customer_Trade_Account_UITransApplied();
                //syncBal.InsertTable_SMSSyncExport_Customer_Trade_Account_UITransApplied(dt_GotExported_CustTradeAccBalance);

                ////Export Customer IPO Acc
                //dt_GotExported_CustIpoAccBalance = syncBal.GetIPO_Customer_IPO_Account_UITransApplied();
                //syncBal.TruncateTable_SMSSyncExport_Customer_IPO_Account_UITransApplied();
                //syncBal.InsertTable_SMSSyncExport_Customer_IPO_Account_UITransApplied(dt_GotExported_CustIpoAccBalance);

                //Export Customer All
                //dt_GotExported_CustomerAll = syncBal.GetIPO_Customer_All_UITransApplied();
                //syncBal.TruncateTable_SMSSyncExport_Customer_All_UITransApplied();
                //syncBal.InsertTable_SMSSyncExport_Customer_All_UITransApplied(dt_GotExported_CustomerAll);

                //Export IPO Charge
                dt_GotIpoCharge = syncBal.GetIPO_Charge_UITransApplied();
                syncBal.TruncateTable_tbl_IPO_Charge_UITransApplied();
                syncBal.InsertTable_tbl_IPO_Charge_UITransApplied(dt_GotIpoCharge);

                ////Export Paretn Child Information
                //dt_AccountGrouping = syncBal.GetIPO_AccountGrouping_Info_UITransApplied();
                //syncBal.TruncateTable_SMSSyncExport_AccountGrouping_Info_UITransApplied();
                //syncBal.InsertTable_SMSSyncExport_AccountGrouping_Info_UITransApplied(dt_AccountGrouping);

                ////Export Service Registration
                //dt_ServiceRegistration = syncBal.GetIPO_ServiceRegistration_UITransApplied();
                //syncBal.TruncateTable_SMSSyncExport_Confirmation_SMS_Reg_UITransApplied();
                //syncBal.InsertTable_SMSSyncExport_Confirmation_SMS_Reg_UITransApplied(dt_ServiceRegistration);

                //////Export SessionApplication
                ////dt_AllreadyApplied = syncBal.GetApplicationList_AllreadyApplied();
                ////syncBal.TruncateTable_tbl_IPO_SessionApplications_UITransApplied();
                ////syncBal.InsertTable_IPO_SessionApplications_UITransApplied(dt_AllreadyApplied);

                ////////Export MoneyTransaction
                //////dt_MoneyTransRequest = syncBal.GetData_FreeMoneyTransactionRequest_Status_UITransApplied();
                //////syncBal.TruncateTable_MoneyTransactionRequest_UITransApplied();
                //////syncBal.InsertTable_MoneyTransactionRequest_Status_UITransApplied(dt_MoneyTransRequest);

                //////Export Customer IPO Acc Single
                //SqlDataReader dt_GotExported_CustIpoAccBalance_TradeTrans = syncBal.GetIPO_Customer_IPO_Account_UITransApplied(new string[] { "17069" });
                //syncBal.DeleteData_SMSSyncExport_Customer_IPO_Account_UITransApplied(new string[] { "17069" });
                //syncBal.InsertTable_SMSSyncExport_Customer_IPO_Account_UITransApplied(dt_GotExported_CustIpoAccBalance_TradeTrans);


                syncBal.Commit_SBP();
                syncBal.Commit_SMS();
                isProgressed = false;
                MessageBox.Show("Datat Exported Successfull!!");
            }
            catch (Exception ex)
            {
                syncBal.Rollback_SBP();
                syncBal.Rollback_SMS();
                isProgressed = false;
                MessageBox.Show(ex.Message);
            }
            finally
            {
                syncBal.CloseConnection_SBP();
                syncBal.CloseConnection_SMS();
            }
        }

     
        private void databaseBackupToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmDataBaseBackUp frm = new frmDataBaseBackUp();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog(this);
        }

        private void logClearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLogFileClear frm = new FrmLogFileClear();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog(this);
        }

        private void exportIPOApplicationNotificationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_IPOSMSNofications frm = new frm_IPOSMSNofications();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog(this);
        }       

        private void exportIPOEmailNotficationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmExportIPOInformation frm = new frmExportIPOInformation();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog(this);

        }

        private void forwardDataToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void webIPoExportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IPOWebTest frm = new IPOWebTest();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void customerReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTaxCertificate frm = new FrmTaxCertificate();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void webDataReconcilationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Web_Data_Reconcilation frm = new Web_Data_Reconcilation();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void webDataExportUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string foldername = folderBrowserDialog.SelectedPath;

                Thread thrd = new Thread(WaitWindow_Thread);
                isProgressed = true;
                thrd.Start();
                WebDataExportCls webDataExport = new WebDataExportCls();
                webDataExport.GenerateFileForWeb_2014(foldername,"NEW");
            }
        }

    }
}
