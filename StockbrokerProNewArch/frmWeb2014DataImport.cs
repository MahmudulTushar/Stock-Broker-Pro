using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using System.Threading;

namespace StockbrokerProNewArch
{
    public partial class frmWeb2014DataImport : Form
    {
        public static bool IsProgressed ;
        
        public frmWeb2014DataImport()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool isSelected_ServiceRegistration = chk_ServiceRegistration.Checked;
            bool isSelected_MoneyWithdrawRequest = chk_MoneyWithdrawReq.Checked;
            bool isSelected_UserQuery = chk_UserQuery.Checked;
            Thread thrd = new Thread(WaitWindow_Thread); 
            IsProgressed = true;
            thrd.Start();

            try
            {
                if (isSelected_MoneyWithdrawRequest)
                {
                    Web2014DataImportBAL importBal = new Web2014DataImportBAL();

                    DataTable dt_AllreadyHave = importBal.GetAllreadyImported_MoneyWithdrawalReq();
                    importBal.DropWebSiteBackOfficeTemp();
                    importBal.CreateWebSiteBackOfficeTemp();
                    importBal.UploadAllreadyImported_MoneyWithdrawalReq_ToWeb(dt_AllreadyHave);
                    DataTable dt_NewData = importBal.GetNew_MoneyWithdrawalReq_FromWeb();
                    importBal.DropWebSiteBackOfficeTemp();
                    importBal.Save_ToTemp(dt_NewData, "Web2014_GetNewWithdrawalRequest_Temp");
                }
                if (isSelected_ServiceRegistration)
                {
                    Web2014DataImportBAL importBal = new Web2014DataImportBAL();
                    DataTable dt_NewData = importBal.GetAllWebServiceRegistration_FromWeb();
                    importBal.Truncate_GetAllWebServiceRegistration_Temp();
                    importBal.Save_ToTemp(dt_NewData, "Web2014_GetAllServiceRegistration_Temp");
                }
                if (isSelected_UserQuery)
                {
                    Web2014DataImportBAL importBal = new Web2014DataImportBAL();

                    DataTable dt_AllreadyHave = importBal.GetAllreadyImported_UserQuery();
                    importBal.DropWebSiteBackOfficeTemp();
                    importBal.CreateWebSiteBackOfficeTemp();
                    importBal.UploadAllreadyImported_UserQuery_ToWeb(dt_AllreadyHave);
                    DataTable dt_NewData = importBal.GetNew_UserQuery_FromWeb();
                    importBal.DropWebSiteBackOfficeTemp();
                    importBal.Save_ToTemp(dt_NewData, "Web2014_GetNewUserQuery_Temp");
                }
                IsProgressed = false;
                MessageBox.Show("Data Import Successfully Done");
            }
            catch (Exception ex)
            {
                Web2014DataImportBAL importBal = new Web2014DataImportBAL();
                importBal.DropWebSiteBackOfficeTemp();

                IsProgressed = false;
                MessageBox.Show(ex.Message);
            }
        }
        private void WaitWindow_Thread()
        {
            WaitWindow waitWindow = new WaitWindow();
            waitWindow.Show();
            while (IsProgressed)
            {
                waitWindow.Refresh();
            }
            waitWindow.Close();
        }

    }
}
