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
//using Reports.DSE_New_Reports;
using BusinessAccessLayer.Constants;
using CrystalDecisions.CrystalReports.Engine;
using StockbrokerProNewArch;



namespace Reports
{
    public partial class MainReport : Form
    {

        private string _CommpanyName;
        private string _branchName;
        private string _branchAddress;
        private string _branchContactNumber;

        private ViewPrivillizeBAL viewprev = new ViewPrivillizeBAL();
        public MainReport()
        {
            InitializeComponent();
        }

        private void reviewReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReview frmtReview = new frmReview{MdiParent = this};
            frmtReview.Show();
        }    

        private void todaysSummeryReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TodaySummeryReport todaySummeryReport = new TodaySummeryReport{MdiParent=this};
            todaySummeryReport.Show();
        }
        private void accountHolderReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustInfoReport custInfoReport = new CustInfoReport { MdiParent = this };
            custInfoReport.Show();
        }

        private void reviewCustomerBalanceToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CustomizedForDSE_ReviewCustbalance reviewCustbalance = new CustomizedForDSE_ReviewCustbalance{MdiParent=this};
            reviewCustbalance.Show();
        }

        private void tradeSummeryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TradeSummeryReport tradeSummeryReport = new TradeSummeryReport{MdiParent=this};
            tradeSummeryReport.Show();
        }

        private void buySaleReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuySellReport buySellReport = new BuySellReport{MdiParent=this};
            buySellReport.Show();
        }

        private void workstationwiseTradeShareListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmShareList frmShareList = new FrmShareList { MdiParent = this };
            frmShareList.Show();
        }

        private void clientShareLadgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerShareLedger customerShareLedger = new CustomerShareLedger{MdiParent=this};
            customerShareLedger.Show();
        }

        private void clientMoneyLadgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerMoneyLedger customerMoneyLedger = new CustomerMoneyLedger{MdiParent = this };
            customerMoneyLedger.Show();
        }

        private void clientSummeryLadgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerSummeryLedger customerSummeryLedger = new CustomerSummeryLedger {MdiParent = this};
            customerSummeryLedger.Show();
        }

       

        private void MainReport_Load(object sender, EventArgs e)
        {
            menuStrip2.Visible = false;
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
                case "Client Share Ledger":
                    clientShareLadgerToolStripMenuItem.Visible = true;
                    break;
                case "Client Money Ledger":
                    clientMoneyLadgerToolStripMenuItem.Visible = true;
                    break;
                case "Client Summery Ledger":
                    clientSummeryLadgerToolStripMenuItem.Visible = true;
                    break;
                case "Client Info Report":
                    accountHolderReportToolStripMenuItem.Visible = true;
                    break;
                case "Account Review Report":
                    reviewCustomerBalanceToolStripMenuItem1.Visible = true;
                    break;
                case "Trade Confirmation Report":
                    tradeConfirmationtoolStripMenuItem.Visible = true;
                    break;
                case "Trade Summery Report":
                    tradeSummeryToolStripMenuItem1.Visible = true;
                    break;
                case "Buy-Sale Report":
                    buySaleReportToolStripMenuItem.Visible = true;
                    break;
                case "WorkStationWise Trade Report":
                    workstationwiseTradeShareListToolStripMenuItem.Visible = true;
                    break;
                case "Review Report":
                    reviewReportToolStripMenuItem.Visible = true;
                    break;
                case "Todays Summery Report":
                    todaysSummeryReportToolStripMenuItem.Visible = true;
                    break;
                case "Tax Certificate":
                    taxCertificateToolStripMenuItem2.Visible = true;
                    break;

                case "Tax Statement":
                    taxStatementToolStripMenuItem1.Visible = true;
                    break;

                case "New Customer Money Ledger":
                    newCustomerMoneyLedgerToolStripMenuItem.Visible = true;
                    break;

                case "Payment OCC":
                    toolStripMenuItem7.Visible = true;
                    break;
                case "Branchwise Payment Review":
                    toolStripMenuItem8.Visible = true;
                    break;

                case "Admin Alternative Report":
                    adminAlternaToolStripMenuItem.Visible = true;
                    break;

                case "Instrument Wise Share Trade List":
                    instrumentWiseShareTradeListToolStripMenuItem.Visible = true;
                    break;

                case "Share Entry Review":
                    shareEntryReviewToolStripMenuItem.Visible = true;
                    break;

                case "Instrument Wise Share Report":
                    instrumentWiseShareReportToolStripMenuItem.Visible = true;
                    break;

                case "Today Trade Risk Analysis On Negetive Balance":
                    todayToolStripMenuItem.Visible = true;
                    break;

                case "Today Money Withdrawal Analysis":
                    todayNegetiveCustomerMoneyTransactionReportToolStripMenuItem.Visible = true;
                    break;

                case "New Payment Review":
                    toolStripMenuItem6.Visible = true;
                    break;

                case "Account Image List":
                    accountImageListToolStripMenuItem.Visible = true;
                    break;

                case "G":
                    voucherPrintingToolStripMenuItem.Visible = true;
                    break;

                case "Personal Profile":
                    personalProfileToolStripMenuItem.Visible = true;
                    break;

                case "Personal Salary Report":
                    personalSalaryReportToolStripMenuItem.Visible = true;
                    break;

                case "Monthly Salary Report":
                    monthlySalarySheetToolStripMenuItem.Visible = true;
                    break;

                case "Salary Chat":
                    salaryChatToolStripMenuItem.Visible = true;
                    break;

                case "Daily Expenditure":
                    dailyExpenditureToolStripMenuItem.Visible = true;
                    break;

                case "Monthly Expenditure":
                    monthlyExpenditureToolStripMenuItem.Visible = true;
                    break;

                case "Common Expenditure":
                    commonExpenditureToolStripMenuItem.Visible = true;
                    break;

                case "Current Asset List":
                    currentAssetListToolStripMenuItem.Visible = true;
                    break;

                case "Monthly Asset List":
                    monthlyExpenseListToolStripMenuItem.Visible = true;
                    break;

                case "Total Asset List":
                    totalExpenseListToolStripMenuItem.Visible = true;
                    break;

                case "New Expense Report":
                    newExpenseReportToolStripMenuItem.Visible = true;
                    break;

                //case "OOO":
                //    receivePaymentToolStripMenuItem.Visible = true;
                //    break;

                //case "PPP":
                //    paymentReceiptSummaryToolStripMenuItem.Visible = true;
                //    break;

                //case "OPOP":
                //    allStockWithVaultToolStripMenuItem.Visible = true;
                //    break;

                case "Voucher Printing":
                    voucherPrintingToolStripMenuItem.Visible = true;
                    break;

                case "Voucher Print":
                    voucherPrintingToolStripMenuItem.Visible = true;
                    break;

                case "Client Payable Reconciliation Statement":
                    clientPayableRecounciliationStatementToolStripMenuItem.Visible = true;
                    break;

                case "Customized For DSE Review Custbalance":
                    customizedForDSEReviewCustbalanceToolStripMenuItem.Visible = true;
                    break;

                case "Z group Share Buy/Sell Report":
                    zGroupShareBuySellReportToolStripMenuItem.Visible = true;
                    break;

                case "Interest Service Charge":
                    interestServiceChargeToolStripMenuItem.Visible = true;
                    break;

                case "Current Cash Report":
                    pettyCashReportToolStripMenuItem.Visible = true;
                    break;

                case "Customer Accrued Balance":
                    customerAccruedBalanceToolStripMenuItem.Visible = true;
                    break;

                    

                default:
                    break;
            }
        }

        private void ResetPrevillize()
        {
            clientShareLadgerToolStripMenuItem.Visible = false;
            interestServiceChargeToolStripMenuItem.Visible = false;
            //allStockWithVaultToolStripMenuItem.Visible = false;
            zGroupShareBuySellReportToolStripMenuItem.Visible = false;
            customizedForDSEReviewCustbalanceToolStripMenuItem.Visible = false;
            clientPayableRecounciliationStatementToolStripMenuItem.Visible = true;
            //paymentReceiptSummaryToolStripMenuItem.Visible = false;
            //receivePaymentToolStripMenuItem.Visible = false;
            newExpenseReportToolStripMenuItem.Visible = false;
            totalExpenseListToolStripMenuItem.Visible = false;
            monthlyExpenseListToolStripMenuItem.Visible = false;
            currentAssetListToolStripMenuItem.Visible = false;
            commonExpenditureToolStripMenuItem.Visible = false;
            monthlyExpenditureToolStripMenuItem.Visible = true;
            salaryChatToolStripMenuItem.Visible = false;
            dailyExpenditureToolStripMenuItem.Visible = false;
            monthlySalarySheetToolStripMenuItem.Visible = false;
            personalSalaryReportToolStripMenuItem.Visible = false;
            personalProfileToolStripMenuItem.Visible = false;
            voucherPrintingToolStripMenuItem.Visible = false;
            clientMoneyLadgerToolStripMenuItem.Visible = false;
            instrumentWiseShareReportToolStripMenuItem.Visible = false;
            todayToolStripMenuItem.Visible = false;
            todayNegetiveCustomerMoneyTransactionReportToolStripMenuItem.Visible = true;
            shareEntryReviewToolStripMenuItem.Visible = false;
            clientSummeryLadgerToolStripMenuItem.Visible = false;
            accountHolderReportToolStripMenuItem.Visible = false;
            reviewCustomerBalanceToolStripMenuItem1.Visible = false;
            tradeConfirmationtoolStripMenuItem.Visible = false;
            newCustomerMoneyLedgerToolStripMenuItem.Visible = false;
            tradeSummeryToolStripMenuItem1.Visible = false;
            buySaleReportToolStripMenuItem.Visible = false;
            instrumentWiseShareTradeListToolStripMenuItem.Visible = false;
            workstationwiseTradeShareListToolStripMenuItem.Visible = false;
            reviewReportToolStripMenuItem.Visible = false;
            todaysSummeryReportToolStripMenuItem.Visible = false;
            taxCertificateToolStripMenuItem2.Visible = false;
            taxStatementToolStripMenuItem1.Visible = false;
            accountImageListToolStripMenuItem.Visible = false;
            toolStripMenuItem7.Visible = false;//Payment OCC
            toolStripMenuItem8.Visible = false; //Branchwise payment review
            adminAlternaToolStripMenuItem.Visible = false;
            toolStripMenuItem6.Visible = false;
            pettyCashReportToolStripMenuItem.Visible = false;
            customerAccruedBalanceToolStripMenuItem.Visible = false;
        }

        private void personalProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportDetaisInformation objDetailsReport = new frmReportDetaisInformation();
            objDetailsReport.ReportValue = 1;
            objDetailsReport.Text = "Employee Profile Information";
            objDetailsReport.Show();
        }

        private void personalSalaryReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportDetaisInformation objDetailsReport = new frmReportDetaisInformation();
            objDetailsReport.Text = "Personal Salary History";
            objDetailsReport.ReportValue = 2;
            objDetailsReport.Show();
        }

        private void monthlySalarySheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPayrollSetting objPayrollSetting = new frmPayrollSetting();
            objPayrollSetting.OperationValue = 3;
            objPayrollSetting.Text = "Employee Salary History";
            objPayrollSetting.Show();
        }

        private void salaryChatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                GetEmployeeInfo();
                this.Cursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void GetEmployeeInfo()
        {
            try
            {
                ReportBAL objReportBal = new ReportBAL();
                DataTable dtReportBal = new DataTable();
                cr_EmployeeInfo objEmployee = new cr_EmployeeInfo();
                frmReportViewer objReportviewer = new frmReportViewer();

                dtReportBal = objReportBal.GetEmployeeInfo();
                objEmployee.SetDataSource(dtReportBal);

                GetCommonInfo();
                ((TextObject)objEmployee.ReportDefinition.Sections[2].ReportObjects["txtCompanyName"]).Text = _CommpanyName;
                ((TextObject)objEmployee.ReportDefinition.Sections[2].ReportObjects["txtAddress"]).Text = "Branch Name:" + _branchName + "," + _branchAddress + ". Phone:" + _branchContactNumber;




                objReportviewer.crvReportViewer.ReportSource = objEmployee;
                objReportviewer.crvReportViewer.DisplayGroupTree = false;
                objReportviewer.Text = "Salary Chat";
                objReportviewer.Show();



            }
            catch (Exception)
            {

                throw;
            }
        }

        private void GetCommonInfo()
        {

            try
            {
                CommonInfoBal objCommonInfoBal = new CommonInfoBal();
                DataRow drCommonInfo = null;

                drCommonInfo = objCommonInfoBal.GetCommpanyInfo();

                if (drCommonInfo != null)
                {
                    _CommpanyName = drCommonInfo.Table.Rows[0][0].ToString();
                    _branchName = drCommonInfo.Table.Rows[0][1].ToString();
                    _branchAddress = drCommonInfo.Table.Rows[0][2].ToString();
                    _branchContactNumber = drCommonInfo.Table.Rows[0][3].ToString();


                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void currentAssetListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                GetCurrentAssetList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Current Asset List", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GetCurrentAssetList()
        {
            try
            {
                AssetInformationBAL objAssetInformationBal = new AssetInformationBAL();
                DataTable dtCurrentAssetList = new DataTable();
                frmReportViewer objfrmReportViewer = new frmReportViewer();
                cr_CurrentAssetList objcrCurrentAssetList = new cr_CurrentAssetList();
                RecordLevelFilteringBAL recordLevelFilteringBAL = new RecordLevelFilteringBAL();
                dtCurrentAssetList = objAssetInformationBal.GetCurrentAssetInfo();

                int TempBranchId = -2;
                int branchid = Int32.Parse(dtCurrentAssetList.Rows[0][8].ToString());

                int resourceId = recordLevelFilteringBAL.GetResourceID(ResourceName.Current_Asset_List);
                int criteriaId = recordLevelFilteringBAL.GetCriteriaID(resourceId);

                    TempBranchId = Convert.ToInt32(recordLevelFilteringBAL.FilterBranchID(branchid.ToString(), resourceId, criteriaId));

                    if (TempBranchId == -1)
                        dtCurrentAssetList.Rows.Clear();
                objcrCurrentAssetList.SetDataSource(dtCurrentAssetList);

                GetCommonInfo();
                ((TextObject)objcrCurrentAssetList.ReportDefinition.Sections[2].ReportObjects["txtCompanyName"]).Text = _CommpanyName;
                ((TextObject)objcrCurrentAssetList.ReportDefinition.Sections[2].ReportObjects["txtAddress"]).Text = "Branch Name:" + _branchName + "," + _branchAddress + ". Phone:" + _branchContactNumber;


                objfrmReportViewer.crvReportViewer.ReportSource = objcrCurrentAssetList;
                objfrmReportViewer.crvReportViewer.DisplayGroupTree = false;
                objfrmReportViewer.Text = "Current Asset List";
                objfrmReportViewer.Show();

            }
            catch (Exception)
            {

                throw;
            }
        }

       
        private void monthlyExpenseListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMonthlyExpense objfrmExpense = new frmMonthlyExpense();
            objfrmExpense.Text = "Monthly Expense List";
            objfrmExpense.Show();
        }

        private void totalExpenseListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                GetTotalExpenseList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GetTotalExpenseList()
        {
            try
            {
                AssetInformationBAL objAssetInformationBal = new AssetInformationBAL();
                DataTable dtTotalExpenseLise = new DataTable();
                frmReportViewer objfrmReportViewer = new frmReportViewer();
                CrTotalExpense objcrTotalAssetList = new CrTotalExpense();
                RecordLevelFilteringBAL recordLevelFilteringBAL = new RecordLevelFilteringBAL();
                int TempBranchId = -2;

                dtTotalExpenseLise = objAssetInformationBal.GetTotalAssetExpense();

                int branchid = Int32.Parse(dtTotalExpenseLise.Rows[0][11].ToString());
                int resourceId = recordLevelFilteringBAL.GetResourceID(ResourceName.Total_Expense_List);
                int criteriaId = recordLevelFilteringBAL.GetCriteriaID(resourceId);
                TempBranchId = Convert.ToInt32(recordLevelFilteringBAL.FilterBranchID(branchid.ToString(), resourceId, criteriaId));
                if (TempBranchId == -1)
                    dtTotalExpenseLise.Rows.Clear();


                objcrTotalAssetList.SetDataSource(dtTotalExpenseLise);
                objfrmReportViewer.crvReportViewer.DisplayGroupTree = false;
                objfrmReportViewer.crvReportViewer.ReportSource = objcrTotalAssetList;

                GetCommonInfo();
                ((TextObject)objcrTotalAssetList.ReportDefinition.Sections[2].ReportObjects["txtCompanyName"]).Text = _CommpanyName;
                ((TextObject)objcrTotalAssetList.ReportDefinition.Sections[2].ReportObjects["txtAddress"]).Text = "Branch Name:" + _branchName + "," + _branchAddress + ". Phone:" + _branchContactNumber;

                objfrmReportViewer.Text = "Total Expense List";
                objfrmReportViewer.Show();

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void dailyExpenditureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCommonDateReport objCommonDate=new frmCommonDateReport();
            objCommonDate.Text = "Daily Expenditure";
            objCommonDate.Show();
        }

        private void taxCertificateToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void monthlyExpenditureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMonthCommonReportWind objMonthly = new frmMonthCommonReportWind();
            objMonthly.Show();
        }

        private void commonExpenditureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCommonExpenditutreReportCall objCommonExpen = new frmCommonExpenditutreReportCall();
            objCommonExpen.Show();
        }

        private void taxStatementToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            frmReportFormPeriod objPeriod = new frmReportFormPeriod();
            objPeriod.Text = "New Payment Review Report";
            objPeriod.Title = "New Payment Review Report";
            //this.MdiParent = objPeriod;
            objPeriod.Show();
        }

        private void shareEntryReviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShareEntryReview obj = new frmShareEntryReview();
            obj.Show();
        }

        private void accountImageListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmImageListReport objImageList = new frmImageListReport();
            objImageList.Show();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            frmPaymentOOCReport objOcc=new frmPaymentOOCReport();
            objOcc.MdiParent = this;
            objOcc.Show();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            frmPaymentReviewReportCall objpaymentview = new frmPaymentReviewReportCall();
            objpaymentview.Show();
        }

        private void voucherPrintingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VoucherPrinting obj=new VoucherPrinting();
            obj.MdiParent = this;
            obj.Show();
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            //if( !viewprev.ViewPermission(MenuNameList.ClientConfirmation))
            //{
            //    MessageBox.Show("You have not view permission");
            //    return;
            //}
            ClientConfirmation clientConfirmation = new ClientConfirmation { MdiParent = this };
            clientConfirmation.Show();
        }

        private void taxCertificateToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            TaxInput taxInput = new TaxInput();
            taxInput.Show();
        }

        private void taxStatementToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TaxInput taxInput = new TaxInput();
            taxInput.ReportNo = "1";
            taxInput.Text = "Tax Statement";
            taxInput.Show();
        }

        private void customerBalanceReportByDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_BalanceByDateReport frmBalanceByDateReport = new frm_BalanceByDateReport();
            frmBalanceByDateReport.Show();
        }

        private void instrumentWiseShareTradeListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InstruwiseShareTradeList frm = new InstruwiseShareTradeList();
            frm.Show();
        }

        private void receivePaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ReceivePaymentDateToDateWise receivepaymentDateToDateWise = new ReceivePaymentDateToDateWise();
            //receivepaymentDateToDateWise.Show();
        }

        private void paymentReceiptSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmPaymentReceiptSummary paymentReceiptSummary = new frmPaymentReceiptSummary();
            //paymentReceiptSummary.Show();
        }

        private void taxStatementToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
        }

        private void allStockWithVaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //AllStockWithVault allStockWithVault = new AllStockWithVault();
            //allStockWithVault.Show();
        }

        private void clientPayableRecounciliationStatementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClientPayableRecounciliationStatement ClientPayableRecounciliationStatement = new ClientPayableRecounciliationStatement();
            ClientPayableRecounciliationStatement.Show();
        }

        private void customizedForDSEReviewCustbalanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomizedForDSE_ReviewCustbalanceNew CustomizedForDSE_ReviewCustbalanceNew = new CustomizedForDSE_ReviewCustbalanceNew();
            CustomizedForDSE_ReviewCustbalanceNew.Show();
        }

        private void zGroupShareBuySellReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmZ_groupBuySellReport Z_groupBuySellReport = new frmZ_groupBuySellReport { MdiParent = this };
            Z_groupBuySellReport.Show();
        }

        private void spotMarketcShareBuySellReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSpotMarketcShareBuySellReport SpotMarketcShareBuySellReport = new frmSpotMarketcShareBuySellReport { MdiParent = this };
            SpotMarketcShareBuySellReport.Show();
        }


        private void interestServiceChargeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            string menuText = item.Text;
            CustomerMoneyLedger customerMoneyLedger = new CustomerMoneyLedger(menuText) { MdiParent = this };
            customerMoneyLedger.Show();

        }

        private void instrumentWiseShareReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInstrumentWiseShareReport InstrumentWiseShareReport = new frmInstrumentWiseShareReport { MdiParent = this };
            InstrumentWiseShareReport.Show();
        }

        private void newCustomerMoneyLedgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuitem=(ToolStripMenuItem)sender;
            string menuName = menuitem.Text;
            CustomerMoneyLedger customerMoneyLedger = new CustomerMoneyLedger(menuName) { MdiParent = this };
            customerMoneyLedger.Show();
        }

        private void newExpenseReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmExpenseReport frm = new frmExpenseReport();
            frm.Show();
        }

        private void adminAlternaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAdminAlternativeReport frm = new frmAdminAlternativeReport() {MdiParent=this };
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void todayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmToday_Transactions_Customer_List frm = new frmToday_Transactions_Customer_List();            
            frm.Show();
        }

        private void todayNegetiveCustomerMoneyTransactionReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmClient_Today_Sale_Info frm = new frmClient_Today_Sale_Info();
            frm.Show();
        }
               
        private void iPOCustomerMoneyLedgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIPOCustomerMoneyLedger frm = new frmIPOCustomerMoneyLedger();
            frm.StartPosition=FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void iPOCustomerSummaryLedgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIPOCustomerSummeryLedger frm = new frmIPOCustomerSummeryLedger();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void iPOPaymentReveiwToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIPONewPaymentReview frm = new frmIPONewPaymentReview();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void iPOApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIPOSuccessfulUnsuccessful frm = new frmIPOSuccessfulUnsuccessful();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void iPOPublicFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIPOApplicationForPublicIssue frm = new frmIPOApplicationForPublicIssue();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void iPOApplicationPortfolioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIPOCustomerShareLedger frm = new frmIPOCustomerShareLedger();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void accountingToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pettyCashReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Current_Cash_Rpt frm = new Frm_Current_Cash_Rpt();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Show();
        }

        private void customerAccruedBalanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAccruedBalance frm = new FrmAccruedBalance();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Show();
        }
   }
}
