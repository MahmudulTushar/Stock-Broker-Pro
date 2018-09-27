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

namespace StockbrokerProNewArch
{
    public partial class MDIExpense : Form
    {
        public MDIExpense()
        {
            InitializeComponent();
        }
        private void dailyOPEXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpexDaily opexDaily=new OpexDaily{MdiParent = this};
            opexDaily.Show();
        }

        private void monthlyOPEXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpexMonthly opexMonthly=new OpexMonthly{MdiParent=this};
            opexMonthly.Show();
        }

        

        private void commonExpenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommonOPEX commonOpex=new CommonOPEX();
            commonOpex.Show();
        }

        private void addCapexInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNoDepreciation objNoDepri=new frmNoDepreciation();
            objNoDepri.Show();
        }

        private void deleteCapexInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDeleteCapexInformation objDelete=new frmDeleteCapexInformation();
            objDelete.Show();
        }

        private void voucharViewerToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void approveOPEXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExpenseApproval expenseApproval = new ExpenseApproval();
            expenseApproval.MdiParent = this;
            expenseApproval.Show();
        }

        private void MDIExpense_Load(object sender, EventArgs e)
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
                case "Add Capex":
                    addCapexInformationToolStripMenuItem.Visible = true;
                    break;
                case "Delete Capex":
                    deleteCapexInformationToolStripMenuItem.Visible = true;
                    break;
                case "Daily Opex":
                    dailyOPEXToolStripMenuItem.Visible = true;
                    break;
                case "Monthly Opex":
                    monthlyOPEXToolStripMenuItem.Visible = true;
                    break;
                case "Common Opex":
                    commonExpenseToolStripMenuItem.Visible = true;
                    break;
                case "Approve Opex":
                    approveOPEXToolStripMenuItem.Visible = true;
                    break;
                case "Office Expense":
                    pttyCashReceiveToolStripMenuItem.Visible = true;
                    break;
                case "Expenditure Category Add":
                    GlobalVariableBO._addCategoryPriv  = true;
                    break;

                case "Asset Settlement":
                    assetSettlementToolStripMenuItem.Visible = true;
                    break;
                case "Define Liability Amount":
                    defineLiabilityAmountToolStripMenuItem.Visible = true;
                    break;
                case "Income":
                    incomeToolStripMenuItem.Visible = true;
                    break;
                case "Received Office Expense Delete":
                    officeExpenseToolStripMenuItem.Visible = true;
                    break;
                case "Category Entry":
                    categoryEntryToolStripMenuItem.Visible = true;
                    break;
                case "Income Summary Report":
                    incomeSummaryReportToolStripMenuItem.Visible = true;
                    break;

                case "Head Wise Withdrawal":
                    headWiseWithdrawalToolStripMenuItem.Visible = true;
                    break;
                    
                default:
                    break;
            }
        }

        private void ResetPrevillize()
        {
            addCapexInformationToolStripMenuItem.Visible = false;
            deleteCapexInformationToolStripMenuItem.Visible = false;
            dailyOPEXToolStripMenuItem.Visible = false;
            monthlyOPEXToolStripMenuItem.Visible = false;
            commonExpenseToolStripMenuItem.Visible = false;
            approveOPEXToolStripMenuItem.Visible = false;
            assetSettlementToolStripMenuItem.Visible = false;
            defineLiabilityAmountToolStripMenuItem.Visible = false;
            incomeToolStripMenuItem.Visible = false;
            officeExpenseToolStripMenuItem.Visible = false;
            categoryEntryToolStripMenuItem.Visible = false;
            incomeSummaryReportToolStripMenuItem.Visible = false;
            headWiseWithdrawalToolStripMenuItem.Visible = false;
            
        }

        private void addOCCTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmExpense_Frequency_Entry AddOCCType = new frmExpense_Frequency_Entry() {MdiParent = this};
            AddOCCType.Show();
        }

        private void expenseEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmExpense_CategoryEntry categoryEntry=new frmExpense_CategoryEntry(){MdiParent = this};
            categoryEntry.Show();
        }

        private void expenseCategoryEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmExpenseEntry expenseEntry = new frmExpenseEntry() {MdiParent = this};
            expenseEntry.Show();
        }

        private void expenseVoucherEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmExpenseVoucherImage expenseVoucherImage = new frmExpenseVoucherImage() {MdiParent = this};
            expenseVoucherImage.Show();
        }

        private void expenseTransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmExpenseTransaction expenseTransaction = new frmExpenseTransaction() {MdiParent = this};
            expenseTransaction.Show();
        }

        private void newExpenseApprovalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmExpenseApproval expenseApproval = new frmExpenseApproval() {MdiParent = this};
            expenseApproval.Show();
        }

        private void pttyCashReceiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Office_Expense frm = new Frm_Office_Expense() { MdiParent = this };
            frm.Show();
        }

        private void assetSettlementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAssetConfirmation frm = new frmAssetConfirmation() { MdiParent = this };
            frm.Show();
        }

        private void defineLiabilityAmountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPreDefineAmountOfLiabilities frm = new frmPreDefineAmountOfLiabilities() { MdiParent = this };
            frm.Show();
        }

        private void newIncomeEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmIncomeEntry frm = new FrmIncomeEntry() { MdiParent = this };
            frm.Show();
        }

        private void incomeApprovalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmIncomeApprov frm = new FrmIncomeApprov() { MdiParent = this };
            frm.Show();
        }

        private void officeExpenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReceivedOfficeExpenseDelete frm = new FrmReceivedOfficeExpenseDelete() { MdiParent = this };
            frm.Show();
        }

        private void categoryEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FromCategoryEntry frm = new FromCategoryEntry() { MdiParent = this };
            frm.Show();
        }

        private void incomeSummaryReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmIncomeSummary frm = new FrmIncomeSummary() { MdiParent = this };
            frm.Show();
        }

        private void headWiseWithdrawalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_HeadWiseWithdraw frm = new frm_HeadWiseWithdraw() { MdiParent = this };
            frm.Show();
        }

        private void headWiseIncomeLedgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_HeadWiseIncomeLedger frm = new Frm_HeadWiseIncomeLedger() { MdiParent = this };
            frm.Show();
        }

        private void incomeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
//Calling dse ShareLedger Form
        private void dSELedgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDseLeadger frm = new frmDseLeadger();
            frm.Show();
        }

        private void menuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
