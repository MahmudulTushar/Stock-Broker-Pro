using System;
using System.Data;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using BusinessAccessLayer.BO;
using Reports;
using StockbrokerProNewArch.Classes;
using BusinessAccessLayer.Constants;

namespace StockbrokerProNewArch
{
    public partial class AccountInformation : Form
    {
        public AccountInformation()
        {
            InitializeComponent();
        }

      
      
        private void UnlockLockedinShareToolStripMenuItemClick(object sender, EventArgs e)
        {
            LockedinFree lockedinFree = new LockedinFree {MdiParent = this};
            lockedinFree.Show();
        }

    
        private void AccountInformation_Load(object sender, EventArgs e)
        {
            mainMenubar.Visible = false;
            ResetPrevillize();
            LoadPrevillize();
           // DeactiveMenuu();
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

                DeactiveMenu();
            }
            else if (RoleWithUserprevillizeDataTable.Rows.Count == 0)
            {
                RolewisePrevillizeDataTable = previllizeManagementBal.GetRoleWisePrevillize();

                for (int i = 0; i < RolewisePrevillizeDataTable.Rows.Count; i++)
                {
                    SetPrevillize(RolewisePrevillizeDataTable.Rows[i]["Previllize"].ToString());
                }
                DeactiveMenu();
            }
        }


        private void DeactiveMenu()
        {
            if (SharedepositWithdrawToolStripMenuItem.Available == false)
                shareTransactionToolStripMenuItem.Visible = false;

            if (paymentReceiptToolStripMenuItem.Available == false && depositPostingToolStripMenuItem.Available == false && othersChargeCreditToolStripMenuItem.Available == false && chequeRequistionToolStripMenuItem.Available == false)
                moneyTransactionToolStripMenuItem.Visible = false;


            if (depositToolStripMenuItem.Available == false && ApprovalchequeRequisitionToolStripMenuItem.Available == false && ApprovalotherChargeCreditToolStripMenuItem.Available == false)
                approvalToolStripMenuItem.Visible = false;

            if (deleteShareDepositWithdrawToolStripMenuItem.Available == false && otherChargeCreditsToolStripMenuItem.Available == false && moneyPaymentReceiptToolStripMenuItem.Available == false)
                deleteTransactionToolStripMenuItem.Visible = false;
        }

        private void SetPrevillize(string previllize)
        {
            switch (previllize)
            {
                case "Account Holder Add/Edit":
                    customerInformationToolStripMenuItem.Visible = true;
                    break;
                case "Additional Holder Add/Edit":
                    additionalInformationToolStripMenuItem.Visible = true;
                    break;

                case "New Customer Open":
                    newCustomerOpenToolStripMenuItem.Visible = true;
                    break;

                case "Account Searching":
                    accountSearchingToolStripMenuItem.Visible = true;
                    break;
                case "Account Close":
                    accountClosingToolStripMenuItem1.Visible = true;
                    break;
                case "Customer Inside":
                    insideInformationToolStripMenuItem.Visible = true;
                    break;
                case "BO Closing & Renwal":
                    bOClosingRenwalToolStripMenuItem.Visible = true;
                    break;
                
                case "Voucher Printing":
                    voucherPrintingToolStripMenuItem.Visible = true;
                    break;
                
                case "Voucher Print":
                    voucherPrintingToolStripMenuItem.Visible = true;
                    break;

                case "Company Add/Edit":
                    addUpdateInstrumentToolStripMenuItem.Visible = true;
                    break;

                case "Change Instrument":
                    changeInstrumentToolStripMenuItem.Visible = true;
                    break;

                case "Company Type Change":
                    chargeTypeToolStripMenuItem.Visible = true;
                    break;

                case "Company Category Change":
                    changeGroupToolStripMenuItem.Visible = true;
                    break;

                case "Company Analysis":
                    analiToolStripMenuItem.Visible = true;
                    break;

                case "ShareDW Entry":
                    SharedepositWithdrawToolStripMenuItem.Visible = true;
                    break;



                case "Payment Entry":
                    paymentReceiptToolStripMenuItem.Visible = true;
                    break;

                case "Payment Withdraw":
                    PaymentWithdrawtoolStripMenuItem.Visible = true;
                    break;
                case "Deposit Request":
                    depositPostingToolStripMenuItem.Visible = true;
                    break;

                case "Cheque Requisition":
                    chequeRequistionToolStripMenuItem.Visible = true;
                    break;

                case "Payment OCC":
                    othersChargeCreditToolStripMenuItem.Visible = true;
                    break;

                case "Cheque Approval":
                    ApprovalchequeRequisitionToolStripMenuItem.Visible = true;
                    break;

                case "Deposit Approval":
                    depositToolStripMenuItem.Visible = true;
                    break;

                case "Approval Payment OCC":
                    ApprovalotherChargeCreditToolStripMenuItem.Visible = true;
                    break;

                case "Cheque Received":
                    chequeReceivingToolStripMenuItem.Visible = true;
                    break;

                case "Delete Payment":
                    moneyPaymentReceiptToolStripMenuItem.Visible = true;
                    break;

                case "pproval Payment OCC":
                    otherChargeCreditsToolStripMenuItem.Visible = true;
                    break;

                case "Delete ShareDW":
                    deleteShareDepositWithdrawToolStripMenuItem.Visible = true;
                    break;

                case "Delete Payment OCC":
                    otherChargeCreditsToolStripMenuItem.Visible = true;
                    break;

                case "Trade Transfer":
                    toolStripMenuItem4.Visible = true;
                    break;

                case "Check Print":
                    printChequeToolStripMenuItem.Visible = true;
                    break;

                case "Cheque Reprint Permission":
                    reprintPermissionToolStripMenuItem.Visible = true;
                    break;

                case "Excel Cheque Configuration":
                    cityBankToolStripMenuItem.Visible = true;
                    break;

                case "Service Registration":
                    serviceRegistrationToolStripMenuItem.Visible = true;
                    break;

                case "Bank Reconcile":
                    BankReconciletoolStripMenuItem3.Visible = true;
                    break;

                case "Cashback Process":
                    processCashBackToolStripMenuItem.Visible = true;
                    break;

                case "EFT Requisition":
                    EFTRequisitiontoolStripMenuItem.Visible = true;
                    break;

                case "EFT Issue":
                    eFTIssueToolStripMenuItem.Visible = true;
                    break;

                case "EFT/Cash (Requisition)":
                    withdrawtoolStripMenuItem.Visible = true;
                    break;

                case "BO Annual Charge":
                    bOAnnualChargeToolStripMenuItem.Visible = true;
                    break;
                case "EFT Cancel":
                    eFTCancelToolStripMenuItem.Visible = true;
                    break;
 
                case "Cash Divided Margine Loan":
                    cashDividedMargineLoanToolStripMenuItem.Visible = true;
                    break;
                case "Cash Dividend Settlement":
                    cashDividedSatelmentToolStripMenuItem.Visible = true;
                    break;
                case "Cash Dividend Settlemet Delete":
                    cashDividendSettlemetDeleteToolStripMenuItem.Visible = true;
                    break; 

                default:
                    break;
            }
        }

        private void ResetPrevillize()
        {

            customerInformationToolStripMenuItem.Visible = false;
            additionalInformationToolStripMenuItem.Visible = false;
            newCustomerOpenToolStripMenuItem.Visible = false;
            accountSearchingToolStripMenuItem.Visible = false;
            accountClosingToolStripMenuItem1.Visible = false;
            insideInformationToolStripMenuItem.Visible = false;
            bOClosingRenwalToolStripMenuItem.Visible = false;


            addUpdateInstrumentToolStripMenuItem.Visible = false;
            changeInstrumentToolStripMenuItem.Visible = false;
            changeGroupToolStripMenuItem.Visible = false;
            chargeTypeToolStripMenuItem.Visible = false;
            analiToolStripMenuItem.Visible = false;



            SharedepositWithdrawToolStripMenuItem.Visible = false;
            deleteShareDepositWithdrawToolStripMenuItem.Visible = false;
            paymentReceiptToolStripMenuItem.Visible = false;
            PaymentWithdrawtoolStripMenuItem.Visible = false;////
            depositPostingToolStripMenuItem.Visible = false;
            chequeRequistionToolStripMenuItem.Visible = false;
            othersChargeCreditToolStripMenuItem.Visible = false;
            toolStripMenuItem4.Visible = false;

            depositToolStripMenuItem.Visible = false;
            ApprovalchequeRequisitionToolStripMenuItem.Visible = false;
            ApprovalotherChargeCreditToolStripMenuItem.Visible = false;
            chequeReceivingToolStripMenuItem.Visible = false;

            deleteShareDepositWithdrawToolStripMenuItem.Visible = false;
            moneyPaymentReceiptToolStripMenuItem.Visible = false;
            otherChargeCreditsToolStripMenuItem.Visible = false;

            printChequeToolStripMenuItem.Visible = false;
            reprintPermissionToolStripMenuItem.Visible = false;
            cityBankToolStripMenuItem.Visible = false;

            serviceRegistrationToolStripMenuItem.Visible = false;
            BankReconciletoolStripMenuItem3.Visible = false;
            processCashBackToolStripMenuItem.Visible = false;

            EFTRequisitiontoolStripMenuItem.Visible = false;
            eFTIssueToolStripMenuItem.Visible = false;
            withdrawtoolStripMenuItem.Visible = false;
            bOAnnualChargeToolStripMenuItem.Visible = false;
            eFTCancelToolStripMenuItem.Visible = false;
            cashDividedMargineLoanToolStripMenuItem.Visible = false;
            cashDividedSatelmentToolStripMenuItem.Visible = false;
            cashDividendSettlemetDeleteToolStripMenuItem.Visible = false;

        }
      
        private void checkPrintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckPrinting checkPrinting = new CheckPrinting { MdiParent = this };
            checkPrinting.Show();
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

      

        private void voucherPrintingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VoucherPrinting voucherPrinting = new VoucherPrinting { MdiParent = this };
            voucherPrinting.Show();
        }

      
        private void accountRegistrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MarginChargePlan marginChargePlan = new MarginChargePlan { MdiParent = this };
            marginChargePlan.Show();
        }

        private void chequeConfirmationEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChequeComfirmationEmailUpdate chequeUpdate = new frmChequeComfirmationEmailUpdate();
            chequeUpdate.Show();
        }

      
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void paymentOOCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPaymentOOC objPaymentOOC = new frmPaymentOOC();
            objPaymentOOC.Show();
        }

      

      

        private void addUpdateAccountHoldersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void addUpdateAdditionalHoldersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void accountClosingToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CustomerClosingForm customerClosingForm = new CustomerClosingForm { MdiParent = this };
            customerClosingForm.Show();
        }

        private void accountSearchingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchCust searchCust = new SearchCust { MdiParent = this };
            searchCust.Show();
        }

        private void addUpdateInstrumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompanyInfoForm companyInfoForm = new CompanyInfoForm { MdiParent = this };
            companyInfoForm.Show();
        }

        private void changeInstrumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdateCompanyShortName objCompanyShortName = new frmUpdateCompanyShortName { MdiParent = this };
            objCompanyShortName.Show();
        }

        private void chargeTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompanyListForm companyListForm = new CompanyListForm { MdiParent = this };
            companyListForm.Show();
        }

        private void changeGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeCompGroup changeCompCategory = new ChangeCompGroup { MdiParent = this };
            changeCompCategory.Show();
        }

        private void analiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Graphs graphs = new Graphs { MdiParent = this };
            graphs.Show();
        }

        private void depositWithdrawToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShareDWForm shareDwForm = new ShareDWForm { MdiParent = this };
            shareDwForm.Show();
        }

        private void cancelDepositWithdrawToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteShareDW deleteShareDw = new DeleteShareDW { MdiParent = this };
            deleteShareDw.Show();
        }

        private void paymentReceiptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //string menunamepurpose = "Bank_Branch_Entry_For_EFT/Check_Deposit";
            // DepositApproval depositApproval = new DepositApproval { MdiParent = this };
            PaymentForm payment = new PaymentForm() { MdiParent = this };
            payment.Show();


            //PaymentForm paymentForm = new PaymentForm { MdiParent = this };
            //paymentForm.Show();
        }

        private void depositPostingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DepositPayment checkDeposite = new DepositPayment { MdiParent = this };
            checkDeposite.Show();
        }

        private void chequeRequistionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckRequisition checkRequisition = new CheckRequisition { MdiParent = this };
            checkRequisition.Show();
        }

        private void othersChargeCreditToolStripMenuItem_Click(object sender, EventArgs e)
        {
           frmPaymentOOC objPaymentOcc=new frmPaymentOOC();
            objPaymentOcc.MdiParent = this;
            objPaymentOcc.Show();
        }

        private void depositToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //DepositApproval depositApproval = new DepositApproval { MdiParent = this };
            //depositApproval.Show();

            ToolStripMenuItem menu = (ToolStripMenuItem)sender;
            string menuname = menu.Text;
            // DepositApproval depositApproval = new DepositApproval { MdiParent = this };
            DepositApproval depositApproval = new DepositApproval(menuname) { Text = menuname + " Approval", MdiParent = this };
            depositApproval.Show();

        }

        private void otherChargeCreditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmApprovedPaymentOCC objApproved = new frmApprovedPaymentOCC();
            objApproved.Show();
        }

        private void chequeRequisitionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckRequisitionApproval checkRequisitionApproval = new CheckRequisitionApproval { MdiParent = this };
            checkRequisitionApproval.Show();
        }

      
        private void chequePrintToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void reprintPermissionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

      
        private void chequeReceivingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckReceived checkReceived = new CheckReceived { MdiParent = this };
            checkReceived.Show();
        }

        private void deleteShareDepositWithdrawToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteShareDW deleteShareDw = new DeleteShareDW { MdiParent = this };
            deleteShareDw.Show();
        }

        private void moneyPaymentReceiptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeletePaymentInfo deletePaymentInfo = new DeletePaymentInfo { MdiParent = this };
            deletePaymentInfo.Show();
        }

        private void otherChargeCreditsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDeletePaymentOCC objDelete = new frmDeletePaymentOCC { MdiParent = this };
            objDelete.Show();
        }

        private void chequeConfigurationExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

      
        private void serviceRegistrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WebSmsRegistration webSmsRegistration = new WebSmsRegistration { MdiParent = this };
            webSmsRegistration.Show();
        }

        private void insideInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerInside customerInside = new CustomerInside { MdiParent = this };
            customerInside.Show();
        }

        private void hideAccountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void processCashBackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessCashback objProcessCashBack=new ProcessCashback();
            objProcessCashBack.MdiParent = this;
            objProcessCashBack.Show();
        }

        private void toolStripMenuItem3_Click_1(object sender, EventArgs e)
        {
            BankReconcilation bankReconcilation = new BankReconcilation { MdiParent = this };
            bankReconcilation.Show();
        }

       

        private void finicalNettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void customerInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CusInfoEntry cusInfoEntry = new CusInfoEntry { MdiParent = this };
            cusInfoEntry.Show();
        }

        private void additionalInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NominationForm nominationForm = new NominationForm { MdiParent = this };
            nominationForm.Show();
        }

        private void printChequeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckPrintingNew checkPrintingNew = new CheckPrintingNew { MdiParent = this };
            checkPrintingNew.Show();
        }

        private void reprintPermissionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeCheckPrintStatus changeCheckPrintStatus = new ChangeCheckPrintStatus { MdiParent = this };
            changeCheckPrintStatus.Show();
        }

        private void cityBankToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChequeConfirmationByEmail chequeConfirmationByEmail = new frmChequeConfirmationByEmail { MdiParent = this };
            chequeConfirmationByEmail.Show();
        }

        private void withdrawtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menu = (ToolStripMenuItem)sender;
            string menuname = menu.Text;
           // DepositApproval depositApproval = new DepositApproval { MdiParent = this };
            DepositApproval withdrawApproval = new DepositApproval(menuname) { Text = menuname + " Approval" ,MdiParent=this};
            withdrawApproval.Show();
        }

        private void eFTIssueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EFT_Issue eft_Issue = new EFT_Issue();
            eft_Issue.StartPosition = FormStartPosition.CenterScreen;
            eft_Issue.ShowDialog(this);
        }

        private void PaymentWithdrawtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menu = (ToolStripMenuItem)sender;
            string menuname = menu.Text;
            // DepositApproval depositApproval = new DepositApproval { MdiParent = this };
            PaymentForm payment = new PaymentForm(menuname) { Text = menuname , MdiParent = this };
            payment.Show();

        }

        private void EFTRequisitiontoolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menu = (ToolStripMenuItem)sender;
            string menuname = menu.Text;
            // DepositApproval depositApproval = new DepositApproval { MdiParent = this };
            PaymentForm payment = new PaymentForm(menuname) { Text = menuname, MdiParent = this };
            payment.Show();

        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menu = (ToolStripMenuItem)sender;
            string menuname = menu.Text;
            // DepositApproval depositApproval = new DepositApproval { MdiParent = this };
            DepositApproval transferApproval = new DepositApproval(menuname) { Text = menuname + " Approval", MdiParent = this };
            transferApproval.Show();
        }

        private void bOAnnualChargeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menu = (ToolStripMenuItem)sender;
            string menuname = menu.Text;
            // DepositApproval depositApproval = new DepositApproval { MdiParent = this };
            DepositApproval annualApproval = new DepositApproval(menuname) { Text = menuname + " Approval", MdiParent = this };
            annualApproval.Show();

        }

        private void newCustomerOpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string menuname = Indication_Forms_Title.NewCustomerOpen;
            frmNewCustomerOpen NewCustomerOpen = new frmNewCustomerOpen(menuname) { MdiParent = this };
            NewCustomerOpen.Show();
        }

        private void bORenewalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string menuname = Indication_Forms_Title.BORenewal;
            frmNewCustomerOpen NewCustomerOpen = new frmNewCustomerOpen(menuname) { MdiParent = this };
            NewCustomerOpen.Show();
 
        }       

        private void bOClosingRenwalToolStripMenuItem_Click(object sender, EventArgs e)
        {
             frmBOClosing_Procedure bOClosing_Procedure = new frmBOClosing_Procedure() {MdiParent = this};
             bOClosing_Procedure.Show();
        }

        private void eFTCancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EFTCancel frm = new EFTCancel();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void bOClosingProcessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBoCloseProcess frm = new frmBoCloseProcess();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Show();
        }

        private void othersChargeCreditToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmPaymentOOC occ = new frmPaymentOOC();
            occ.StartPosition = FormStartPosition.CenterParent;
            occ.Show();
        }

        private void bOBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBO_OpeningForm open = new FrmBO_OpeningForm();
            open.StartPosition = FormStartPosition.CenterParent;
            open.Show();
        }

        private void bOBookDeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBoDelete del = new FrmBoDelete();
            del.StartPosition = FormStartPosition.CenterParent;
            del.Show();
        }

        private void cashDividedMargineLoanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CashDividedMargineLoad frmdel = new CashDividedMargineLoad();
            frmdel.Show();
        }

        private void cashDividedSatelmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CashDividedMarginLoanAmountSettle del = new CashDividedMarginLoanAmountSettle();
            del.StartPosition = FormStartPosition.CenterParent;
            del.Show();
        }

        private void cashDividendSettlemetDeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CashDividedMarginDelete del = new CashDividedMarginDelete();
            del.StartPosition = FormStartPosition.CenterParent;
            del.Show();
        }
        
    }
}
