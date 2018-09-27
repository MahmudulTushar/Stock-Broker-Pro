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
using StockbrokerProNewArch.Classes;

namespace StockbrokerProNewArch
{
    public partial class SettingsModule : Form
    {
        public SettingsModule()
        {
            InitializeComponent();
        }

       

        private void SettingsModule_Load(object sender, EventArgs e)
        {
            ResetPrevillize();
            LoadPrevillize();
        }
       
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
            else if (RoleWithUserprevillizeDataTable.Rows.Count == 0 )
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

            if (addUpdateBranchToolStripMenuItem1.Available == false && closeBranchToolStripMenuItem1.Available == false)
                branchInformationToolStripMenuItem.Visible = false;


            if (addUpdateBranchToolStripMenuItem1.Available == false && closeBranchToolStripMenuItem1.Available == false)
                branchInformationToolStripMenuItem.Visible = false;

            if (addUpdateToolStripMenuItem.Available == false && deleteToolStripMenuItem.Available == false && grantPrivilegeRoleToolStripMenuItem.Available == false)
                roleToolStripMenuItem.Visible = false;

            if(addUpdateUserToolStripMenuItem1.Available==false && deleteUserToolStripMenuItem.Available==false)
                userOperationsToolStripMenuItem.Visible = false;

            if(gAMarginToolStripMenuItem.Available==false && vMAVIPMarginToolStripMenuItem.Available==false)
                marginToolStripMenuItem.Visible = false;

            if(cashbackPlanToolStripMenuItem1.Available==false && cashbackRegistrationToolStripMenuItem1.Available==false)
                cashbacktoolStripMenuItem.Visible = false;
        }

        private void SetPrevillize(string previllize)
        {
            switch (previllize)
            {
                case "Basic Entry":
                    basicEntryToolStripMenuItem.Visible = true;
                    break;

                case "Payment Maturity Entry":
                    paymentMediaMaturityToolStripMenuItem.Visible = true;
                    break;

                case "Broker Info Entry":
                    brokerageInformationSetupToolStripMenuItem.Visible = true;
                    break;

                case "Branch Add/Edit":
                    addUpdateBranchToolStripMenuItem1.Visible = true;
                    break;

                case "Closing Branch":
                    closeBranchToolStripMenuItem1.Visible = true;
                    break;

                case "Grant Privilege":
                    grantPrivilegeRoleToolStripMenuItem.Visible = true;
                    break;

                case "Branchwise Tree Report":
                    branchwiseWorkstationsToolStripMenuItem.Visible = true;
                    break;

                case "Role Creation":
                    addUpdateToolStripMenuItem.Visible = true;
                    break;

                case "Delete Role":
                    deleteToolStripMenuItem.Visible = true;
                    break;

                case "User Creation":
                    addUpdateUserToolStripMenuItem1.Visible = true;
                    break;

                case "Hide Accounts":
                    hideAccountsFromDashboardToolStripMenuItem.Visible = true;
                    break;


                case "Delete User":
                    deleteUserToolStripMenuItem.Visible = true;
                    break;

                case "Limited Client Dashboard":
                    limitedDashboardToolStripMenuItem1.Visible = true;
                    break;

                case "Logged Users":
                    loggedinUsersToolStripMenuItem1.Visible = true;
                    break;

                case "Common Charge Entry":
                    commonChargesToolStripMenuItem.Visible = true;
                    break;

                case "IPO Charge Entry":
                   iPOChargesEntryToolStripMenuItem.Visible = true;
                    break;

                case "GroupWise Commission Entry":
                    grouToolStripMenuItem.Visible = true;
                    break;

                case "Account Close Charge":
                    accountCloseChargeToolStripMenuItem.Visible = true;
                    break;

                case "GA Margin":
                    gAMarginToolStripMenuItem.Visible = true;
                    break;

                case "VMA/VIP Margin":
                    vMAVIPMarginToolStripMenuItem.Visible = true;
                    break;

                case "Cashback Reg":
                    cashbackRegistrationToolStripMenuItem1.Visible = true;
                    break;

                case "Interest Withdraw":
                    interestWithdrawToolStripMenuItem.Visible = true;
                    break;

                case "Cashback Plan":
                    cashbackPlanToolStripMenuItem1.Visible = true;
                    break;

                case "Cashback":
                    cashbacktoolStripMenuItem.Visible = true;
                    break;

                case "BO Open Charge Define":
                    bOOpnenChargeDefineToolStripMenuItem.Visible = true;
                    break;

                default:
                    break;
            }
        }

        private void ResetPrevillize()
        {

            basicEntryToolStripMenuItem.Visible = false;
            paymentMediaMaturityToolStripMenuItem.Visible = false;

            brokerageInformationSetupToolStripMenuItem.Visible = false;
            addUpdateBranchToolStripMenuItem1.Visible = false;
            closeBranchToolStripMenuItem1.Visible = false;
            branchwiseWorkstationsToolStripMenuItem.Visible = false;

            addUpdateToolStripMenuItem.Visible = false;
            deleteToolStripMenuItem.Visible = false;
            grantPrivilegeRoleToolStripMenuItem.Visible = false;
            limitedDashboardToolStripMenuItem1.Visible = false;

            addUpdateUserToolStripMenuItem1.Visible = false;
            deleteUserToolStripMenuItem.Visible = false;

            changePasswordToolStripMenuItem1.Visible = false;
            loggedinUsersToolStripMenuItem1.Visible = false;

            commonChargesToolStripMenuItem.Visible = false;
            iPOChargesEntryToolStripMenuItem.Visible = false;
            grouToolStripMenuItem.Visible = false;
            accountCloseChargeToolStripMenuItem.Visible = false;

            gAMarginToolStripMenuItem.Visible = false;
            vMAVIPMarginToolStripMenuItem.Visible = false;
            cashbackRegistrationToolStripMenuItem1.Visible = false;
            cashbackPlanToolStripMenuItem1.Visible = false;
            hideAccountsFromDashboardToolStripMenuItem.Visible =false;
            cashbacktoolStripMenuItem.Visible = false;
            interestWithdrawToolStripMenuItem.Visible = false;
            bOOpnenChargeDefineToolStripMenuItem.Visible = false;

        }


        private void basicEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdditionalInformationEntryForm additionalInformationEntryForm = new AdditionalInformationEntryForm { MdiParent = this };
            additionalInformationEntryForm.MdiParent = this;
            additionalInformationEntryForm.Show();
        }

        private void paymentMaturityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PaymentMediaMaturity paymentMediaMaturity = new PaymentMediaMaturity { MdiParent = this };
            paymentMediaMaturity.MdiParent = this;
            paymentMediaMaturity.Show();
        }

        private void brokerageInformationSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BrokerInfoForm brokerInfoForm = new BrokerInfoForm { MdiParent = this };
            brokerInfoForm.MdiParent = this;
            brokerInfoForm.Show();
        }

        private void addUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RoleCreation roleCreation = new RoleCreation();
            roleCreation.MdiParent = this;
            roleCreation.Show();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RoleDeletion objRole = new RoleDeletion();
            objRole.MdiParent = this;
            objRole.Show();
        }

        private void grantPrivilegeRoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GrantPrevillize grantPrevillize = new GrantPrevillize { MdiParent = this };
            grantPrevillize.Show();
        }

        private void addUpdateUserToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            UserForm userForm = new UserForm { MdiParent = this };
            userForm.Show();
        }

        private void deleteUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserDeletion objDelete = new UserDeletion { MdiParent = this };
            objDelete.Show();
        }

        private void changePasswordToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ChangePasswordForm changePasswordForm = new ChangePasswordForm { MdiParent = this };
            changePasswordForm.Show();
        }

        private void loggedinUsersToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            LoggedinStatus loggedinStatus = new LoggedinStatus { MdiParent = this };
            loggedinStatus.MdiParent = this;
            loggedinStatus.Show();
        }

        private void grouToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerCommisionInfo customerCommisionInfo = new CustomerCommisionInfo { MdiParent = this };
            customerCommisionInfo.Show();
        }

        private void commonChargesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChargeDefForm chargeDefForm = new ChargeDefForm { MdiParent = this };
            chargeDefForm.Show();
        }

        private void iPOChargesEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChargeDefIPO chargeDefIPO = new ChargeDefIPO { MdiParent = this };
            chargeDefIPO.Show();
        }

        private void accountCloseChargeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClosingChargeEntry closingChargeEntry = new ClosingChargeEntry { MdiParent = this };
            closingChargeEntry.Show();
        }

        private void addUpdateBranchToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            BranchForm branchForm = new BranchForm { MdiParent = this };
            branchForm.Show();
        }

        private void closeBranchToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            BranchClosingForm branchClosingForm = new BranchClosingForm { MdiParent = this };
            branchClosingForm.Show();
        }

        private void branchwiseWorkstationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WorkStationEntry workStationEntry = new WorkStationEntry() { MdiParent = this };
            workStationEntry.Show();
        }

       

        private void gAMarginToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            MarginChargeDef marginChargeDef = new MarginChargeDef { MdiParent = this };
            marginChargeDef.Show();
        }

        private void vMAVIPMarginToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            MarginChargePlan objMarginChargePlan = new MarginChargePlan { MdiParent = this };
            objMarginChargePlan.Show();
        }

        private void cashbackPlanToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            CashbackPlan cashbackPlan = new CashbackPlan { MdiParent = this };
            cashbackPlan.Show();
        }

        private void cashbackRegistrationToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            CashBackReg cashBackCharge = new CashBackReg { MdiParent = this };
            cashBackCharge.Show();
        }

        private void limitedDashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void userInformationToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void limitedDashboardToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //frmSpecialClientDashboard objSpecial = new frmSpecialClientDashboard("");
            //objSpecial.MdiParent = this;
            //objSpecial.Show();
        }

        private void hideAccountsFromDashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
          //  string menuName;
          //  ToolStripMenuItem formName = (ToolStripMenuItem)sender;
          //  menuName = formName.Text;
          //  HideCustomer objHideCustomer = new HideCustomer(menuName);
          //  //objHideCustomer.MdiParent = this;
          //  //objHideCustomer.Show();
          //  frmSpecialClientDashboard objSpecial = new frmSpecialClientDashboard(menuName);
          //  objSpecial.MdiParent = this;
          //  objSpecial.Show();

            
        }

        private void cashBackSessionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCashBackSession CashBackSession = new frmCashBackSession {MdiParent = this};
            CashBackSession.Show();
        }

        private void processListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProcess_List Process_List = new frmProcess_List {MdiParent = this};
            Process_List.Show();
        }

        private void bankBranchRoutingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBank_Branch_Routing_Info Bank_Branch_Routing_Info = new frmBank_Branch_Routing_Info {MdiParent = this};
            Bank_Branch_Routing_Info.Show();
        }

        private void cashBackProcessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCashBackProcess CashBackProcess = new frmCashBackProcess {MdiParent = this};
            CashBackProcess.Show();
        }

        private void transactionBasedChargeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_TransactionBasedCharge transBasedCharge = new frm_TransactionBasedCharge { MdiParent = this };
            transBasedCharge.Show();
        }

        private void interestWithdrawToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInterestWithdraw interestWithdraw = new frmInterestWithdraw() { MdiParent = this,StartPosition=FormStartPosition.CenterScreen };
            interestWithdraw.Show();
        }

        private void holidayEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HolidayAdd holidayAdd = new HolidayAdd() {MdiParent = this};
            holidayAdd.Show();
        }

        private void headCodeEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_HeadCodeEntry frm = new Frm_HeadCodeEntry() { MdiParent = this };
            frm.Show();
        }

        private void bOOpnenChargeDefineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_BOOpeningCharge frm = new Frm_BOOpeningCharge() { MdiParent = this };
            frm.Show();
        }
    }
}
