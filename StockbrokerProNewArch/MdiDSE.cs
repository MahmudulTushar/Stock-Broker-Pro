using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using BusinessAccessLayer.BO;
using System.Threading;

namespace StockbrokerProNewArch
{
    public partial class MdiDSE : Form
    {
        private WaitWindow waitWindow;
        public static bool isProgressed;

        public MdiDSE()
        {
            InitializeComponent();
        }

        private void MdiDSE_Load(object sender, EventArgs e)
        {
            ResetPrevillize();
            LoadPrevillize();
        }

        //private void LoadPrevillize()
        //{
        //    DataTable previllizeDataTable = new DataTable();
        //    PrevillizeManagementBAL previllizeManagementBal = new PrevillizeManagementBAL();
        //    previllizeDataTable = previllizeManagementBal.GetUserPrevillize();
        //    for (int i = 0; i < previllizeDataTable.Rows.Count; i++)
        //    {
        //        SetPrevillize(previllizeDataTable.Rows[i][0].ToString());
        //    }
        //}

        private void LoadPrevillize()
        {
            bool result = false;
            DataTable RoleWithUserprevillizeDataTable = new DataTable();
            DataTable RolewisePrevillizeDataTable = new DataTable();
            PrevillizeManagementBAL previllizeManagementBal = new PrevillizeManagementBAL();
            //previllizeDataTable = previllizeManagementBal.GetUserPrevillize();
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

                //  DeactiveMenu();
            }
            else if (RoleWithUserprevillizeDataTable.Rows.Count == 0)
            {
                RolewisePrevillizeDataTable = previllizeManagementBal.GetRoleWisePrevillize();

                for (int i = 0; i < RolewisePrevillizeDataTable.Rows.Count; i++)
                {
                    SetPrevillize(RolewisePrevillizeDataTable.Rows[i]["Previllize"].ToString());
                }
                //   DeactiveMenu();
            }
        }

        private void SetPrevillize(string previllize)
        {
            switch (previllize)
            {
                case "Trade File Import":
                    newTradeFileImport.Visible = true;
                    previousTradeFileImport.Visible = true;
                    break;
                case "Generate Cash Limit":
                    cashLimitToolStripMenuItem.Visible = true;
                    previousLimitToolStripMenuItem.Visible = true;
                    break;
                case "Generate Share Limt":
                    shareLimitToolStripMenuItem.Visible = true;
                    break;
                case "Close Price Upload":
                    manualTradepriceImportToolStripMenuItem.Visible = true;
                    autoUploadInternetToolStripMenuItem.Visible = true;
                    break;
                case "Share Price Dashboard":
                    viewSharePriceToolStripMenuItem.Visible = true;
                    break;
                case "Select Company for View Price":
                    companySelectionToolStripMenuItem.Visible = true;
                    break;
                case "Price Data Loader":
                    priceDataLoaderToolStripMenuItem.Visible = true;
                    break;
                case "Process Data":
                    tsmDataProcess.Visible = true;
                    break;

                case "Finical Netting":
                    finicalNettingToolStripMenuItem.Visible = true;
                    break;

                //case "Main Process":
                //    mainProcessToolStripMenuItem.Visible = true;
                //    break;

                //case "Dashboard Process":
                //    dashboardProcessToolStripMenuItem.Visible = true;
                //    break;

                case "Trade File Upload From [DSE] XML FlexTp":
                    flexTradeFileToolStripMenuItem.Visible = true;
                    break;

                case "Trade Price Upload From [DSE] XML FlexTp":
                    uploadFromDSEXMLFlexTradeToolStripMenuItem.Visible = true;
                    break;

                case "Cash Limit From [DSE] FlexTp":
                    cashLimitFromDSEFlexTPToolStripMenuItem.Visible = true;
                    break;

                case "Share Limit From [DSE] FlexTp":
                    shareLimitFromDSEFlexTPToolStripMenuItem.Visible = true;
                    break;

                case "Trade SMS Confirmation - MSA Plus":
                    mSAPlusTradeSMSConfirmationToolStripMenuItem.Visible = true;
                    break;

                case "New Cash Limit":
                    newCashLimitToolStripMenuItem.Visible = true;
                    break;

                case "Data Process":
                    dataProcessToolStripMenuItem.Visible = true;
                    break;

                case "Interest Accrued Process":
                    interestAccuradeToolStripMenuItem.Visible = true;
                    break;

                case "DSE OTC Market":
                    dscToolStripMenuItem.Visible = true;
                    break;

                case "Data Process And Int.  Accrued Process":
                    autoInterestAccruedProcessToolStripMenuItem.Visible = true;
                    break;

                default:
                    break;
            }
        }

        private void ResetPrevillize()
        {

            mainProcessToolStripMenuItem.Visible = false;
            dashboardProcessToolStripMenuItem.Visible = false;

            flexTradeFileToolStripMenuItem.Visible = false;
            uploadFromDSEXMLFlexTradeToolStripMenuItem.Visible = false;

            cashLimitFromDSEFlexTPToolStripMenuItem.Visible = false;
            shareLimitFromDSEFlexTPToolStripMenuItem.Visible = false;

            mSAPlusTradeSMSConfirmationToolStripMenuItem.Visible = false;


            viewSharePriceToolStripMenuItem.Visible = false;
            companySelectionToolStripMenuItem.Visible = false;
            priceDataLoaderToolStripMenuItem.Visible = false;
            tsmDataProcess.Visible = false;
            newTradeFileImport.Visible = false;
            previousTradeFileImport.Visible = false;
            cashLimitToolStripMenuItem.Visible = false;
            shareLimitToolStripMenuItem.Visible = false;
            previousLimitToolStripMenuItem.Visible = false;
            manualTradepriceImportToolStripMenuItem.Visible = false;
            autoUploadInternetToolStripMenuItem.Visible = false;
            finicalNettingToolStripMenuItem.Visible = false;
            newCashLimitToolStripMenuItem.Visible = false;

            dataProcessToolStripMenuItem.Visible = false;
            interestAccuradeToolStripMenuItem.Visible = false;
            dscToolStripMenuItem.Visible = false;
            autoInterestAccruedProcessToolStripMenuItem.Visible = false;

        }
        
        private void viewSharePriceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LatestSharePriceNew latestSharePriceNew = new LatestSharePriceNew();
            latestSharePriceNew.Show();
        }

        private void companySelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompanySelectionForPrice companySelectionForPrice = new CompanySelectionForPrice { MdiParent = this };
            companySelectionForPrice.Show();
        }

        private void priceDataLoaderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataLoader dataLoader = new DataLoader {MdiParent = this};
            dataLoader.Show();
        }
               
        private void DatabaseInitialProcessing()
        {
            try
            {
                InitialDataProcessingBAL initialDataProcessingBal = new InitialDataProcessingBAL();
                initialDataProcessingBal.ExecuteProcess();
                initialDataProcessingBal.ExecuteDealer_AccountProcess();
                initialDataProcessingBal.Portfolio_Report_Send();
                initialDataProcessingBal.Web_Server_Starting_Mode();
                waitWindow.Close();               
                MessageBox.Show("Data Processed Successfully", "Success.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exception)
            {
                waitWindow.Close();
                MessageBox.Show("Can not process initial data. Because : " + exception.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
        
        private void tradeSMSConfirmationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSMSTradeUpload smsTradeFileUpload = new frmSMSTradeUpload();
            smsTradeFileUpload.IsOldTradedFileLoaded = true;
            smsTradeFileUpload.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

       
        private void newTradeFileImport_Click(object sender, EventArgs e)
        {
            TradeFileImport tradeFileImport = new TradeFileImport { MdiParent = this };
            tradeFileImport.Show();
        }

        private void previousTradeFileImport_Click(object sender, EventArgs e)
        {
            TradeFileImportOld tradeFileImportOld = new TradeFileImportOld { MdiParent = this };
            tradeFileImportOld.Show();
        }        

        private void shareLimitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void previousLimitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void manualImportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TradePriceUpload tradePriceUpload = new TradePriceUpload { MdiParent = this };
            tradePriceUpload.Show();
        }

        private void autoUploadInternetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InternetUploadTradePrice internetUploadTradePrice = new InternetUploadTradePrice (""){ MdiParent = this };
            internetUploadTradePrice.Show();
        }

        private void autoUploadTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)sender;
            string menuName = toolStripMenuItem.Text;

            InternetUploadTradePrice internetUploadTradePrice = new InternetUploadTradePrice(menuName) { MdiParent = this };
            internetUploadTradePrice.Show();
        }
        private void finicalNettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FinNetting objFinNetting = new FinNetting();
            objFinNetting.MdiParent = this;
            objFinNetting.Show();
        }

        private void mSAPlusTradeSMSConfirmationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSMSTradeUpload smsTradeFileUpload = new frmSMSTradeUpload();
            smsTradeFileUpload.IsOldTradedFileLoaded = false;
            smsTradeFileUpload.Show();
        }

        private void mainProcessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirmation Message", "Sure you want to process", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                waitWindow = new WaitWindow();
                waitWindow.Show();
                waitWindow.Refresh();
                DatabaseInitialProcessing();               
            }
        }

        private void dashboardProcessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //if (MessageBox.Show("Confirmation Message", "Sure you want to process", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                //{
                    Thread thrd = new Thread(WaitWindow_Thread);
                    isProgressed = true;
                    thrd.Start();
                    DashboardBAL bal = new DashboardBAL();

                    bal.DashBoard_Details_Populate();
                    isProgressed = false;

                    MessageBox.Show("DashBoard Process Successfully");
                //}
            }
            catch (Exception ex)
            {
                isProgressed = false;
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

        private void updateDashBoardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DashboardBAL bal = new DashboardBAL();
                bal.DashBoard_Details_UpdateByCurrentData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void clientLimitToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            ExportDataForIssuer data = new ExportDataForIssuer { MdiParent = this };
            data.Show();
        }

        private void flexTradeFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TradeFileImport_FlexTrade tradeFileImport = new TradeFileImport_FlexTrade { MdiParent = this };
            tradeFileImport.Show();
        }

        private void uploadFromDSEXMLFlexTradeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TradePriceUpload_FlexTrade frm = new TradePriceUpload_FlexTrade();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void cashLimitFromDSEMSAPlusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CashLimit cashLimit = new CashLimit { MdiParent = this };
            cashLimit.Show();
        }

        private void cashLimitFromDSEFlexTPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClientCashLimit limint = new ClientCashLimit { MdiParent = this };
            limint.Show();
        }

        private void shareLimitFromDSETToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShareLimit shareLimit = new ShareLimit { MdiParent = this };
            shareLimit.Show();
        }

        private void shareLimitFromDSEFlexTPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClientCashLimit limint = new ClientCashLimit { MdiParent = this };
            limint.Show();
        }

        private void shareLimitFromDSETessaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LimitListP lmp = new LimitListP();
            lmp.Show();
        }

        private void cashLimitFromDSETessaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LimitListP lmp = new LimitListP();
            lmp.Show();
        }

        private void toolStripMenuItem1_Click_1(object sender, EventArgs e)
        {

        }

        private void clientFileByFtpClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_FlexTp_FtpSync frm = new frm_FlexTp_FtpSync();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog(this);
        }

        private void newCashLimitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFlex_TP_Data_Export_Module frm = new FrmFlex_TP_Data_Export_Module();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog(this);
        }

        public void New_DataProcess()
        {
            try
            {
                InitialDataProcessingBAL initialDataProcessingBal = new InitialDataProcessingBAL();
                initialDataProcessingBal.New_ExecuteProcess();
                initialDataProcessingBal.ExecuteDealer_AccountProcess();
                initialDataProcessingBal.Portfolio_Report_Send();
                initialDataProcessingBal.Web_Server_Starting_Mode();

                //For Insert Day Summary 
                initialDataProcessingBal.DaySummaryDataCalculation(DateTime.Now.ToString("yyyy-MM-dd"));

                waitWindow.Close();              
                MessageBox.Show("Data Processed Successfully", "Success.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exception)
            {
                waitWindow.Close();
                MessageBox.Show("Can not process initial data. Because : " + exception.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }


        private void dataProcessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirmation Message", "Are you Sure , you want to process", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                waitWindow = new WaitWindow();
                waitWindow.Show();
                waitWindow.Refresh();
                New_DataProcess();
            }
        }

        private void interestAccuradeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Accrued_Interest frm = new frm_Accrued_Interest();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog(this);
        }

        private void dscToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_otc_marker frm = new frm_otc_marker();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void autoInterestAccruedProcessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirmation Message", "Are you Sure , you want to process", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                waitWindow = new WaitWindow();
                waitWindow.Show();
                waitWindow.Refresh();
                New_AutoDataProcess();
            }
        }

        public void New_AutoDataProcess()
        {
            try
            {
                InitialDataProcessingBAL initialDataProcessingBal = new InitialDataProcessingBAL();
                initialDataProcessingBal.New_AutoExecuteProcess();
                initialDataProcessingBal.ExecuteDealer_AccountProcess();
                initialDataProcessingBal.Portfolio_Report_Send();
                initialDataProcessingBal.Web_Server_Starting_Mode();

                //For Insert Day Summary 
                initialDataProcessingBal.DaySummaryDataCalculation(DateTime.Now.ToString("yyyy-MM-dd"));

                waitWindow.Close();
                MessageBox.Show("Data Processed Successfully", "Success.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exception)
            {
                waitWindow.Close();
                MessageBox.Show("Can not process initial data. Because : " + exception.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        
    }
}
