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
    public partial class GrantPrevillize : Form
    {
        public GrantPrevillize()
        {
            InitializeComponent();
        }
        public struct PrevwithRole
        {
            public string userName;
            public string roleName;
            public string prevID;
            public string prevName;
            public string action;
        };
        public string insertIndicator = "Insert";
        public string deleteIndicator = "Delete";
        public List<PrevwithRole> finalList = new List<PrevwithRole>();
        private string previllize_Name = string.Empty;
        private int previllize_ID = 0;
        int increment;
        List<bool> result;
        public List<string> userList = new List<string>();

        private void RoleCreation_Load(object sender, EventArgs e)
        {
            //LoadOptions();
           
            //LoadDataFromDataTable();
            LoadPrevillizeList();
            LoadRoleName();
        }
        //private void LoadOptions()
        //{
        //    chlPrevillize.Items.Add("Initial Info Entry");
        //    chlPrevillize.Items.Add("Broker Info Entry");
        //    chlPrevillize.Items.Add("Branch Add/Edit");
        //    chlPrevillize.Items.Add("Closing Branch");
        //    chlPrevillize.Items.Add("Role Creation");
        //    chlPrevillize.Items.Add("User Creation");
        //    chlPrevillize.Items.Add("Grant Privilege");
        //    chlPrevillize.Items.Add("Common Charge Entry");
        //    chlPrevillize.Items.Add("IPO Charge Entry");
        //    chlPrevillize.Items.Add("GroupWise Commission Entry");
        //    chlPrevillize.Items.Add("Account Holder Add/Edit");
        //    chlPrevillize.Items.Add("Additional Holder Add/Edit");
        //    chlPrevillize.Items.Add("Account Close");
        //    chlPrevillize.Items.Add("Account Searching");
        //    chlPrevillize.Items.Add("Company Add/Edit");
        //    chlPrevillize.Items.Add("Company Type Change");
        //    chlPrevillize.Items.Add("Company Category Change");
        //    chlPrevillize.Items.Add("Unlock Lockedin Share");
        //    chlPrevillize.Items.Add("Company Analysis");
        //    chlPrevillize.Items.Add("ShareDW Entry");
        //    chlPrevillize.Items.Add("Payment Entry");
        //    chlPrevillize.Items.Add("Management View");
        //    chlPrevillize.Items.Add("Customer Inside");
        //    chlPrevillize.Items.Add("Service Registration");
        //    chlPrevillize.Items.Add("Check Print");
        //    chlPrevillize.Items.Add("Voucher Print");
        //    chlPrevillize.Items.Add("Web Data Export");
        //    chlPrevillize.Items.Add("Trade File Import");
        //    chlPrevillize.Items.Add("Generate Cash Limit");
        //    chlPrevillize.Items.Add("Generate Share Limt");
        //    chlPrevillize.Items.Add("Close Price Upload");
        //    chlPrevillize.Items.Add("Share Price Dashboard");
        //    chlPrevillize.Items.Add("Select Company for View Price");
        //    chlPrevillize.Items.Add("New BO Upload");
        //    chlPrevillize.Items.Add("Additional Holder Upload");
        //    chlPrevillize.Items.Add("BO Modification Upload");
        //    chlPrevillize.Items.Add("BO Close Upload");
        //    chlPrevillize.Items.Add("IPO Share Upload");
        //    chlPrevillize.Items.Add("Bonus Share Upload");
        //    chlPrevillize.Items.Add("Right Share Upload");
        //    chlPrevillize.Items.Add("Demat Share Upload");
        //    chlPrevillize.Items.Add("Stock Split Share Upload");
        //    chlPrevillize.Items.Add("Sattlement");
        //    chlPrevillize.Items.Add("Process Data");
        //    chlPrevillize.Items.Add("CDBL Share Reconcile");
        //    chlPrevillize.Items.Add("Image Upload");
        //    chlPrevillize.Items.Add("Margin Registration");
        //    chlPrevillize.Items.Add("Margin Plan Entry");
        //    chlPrevillize.Items.Add("Cashback Reg");
        //    chlPrevillize.Items.Add("Cashback Plan");
        //    chlPrevillize.Items.Add("Cashback Process");
        //    chlPrevillize.Items.Add("Payment Maturity Entry");
        //    chlPrevillize.Items.Add("Image Management");
        //    chlPrevillize.Items.Add("Account Close Charge");
        //    chlPrevillize.Items.Add("Branchwise Tree Report");
        //    chlPrevillize.Items.Add("Delete History For Reprint Check");
        //    chlPrevillize.Items.Add("Delete ShareDW");
        //    chlPrevillize.Items.Add("Delete Payment");
        //    chlPrevillize.Items.Add("Hide Accounts");
        //    chlPrevillize.Items.Add("Dashboard All");
        //    chlPrevillize.Items.Add("Cheque Requisition");
        //    chlPrevillize.Items.Add("Cheque Approval");
        //    chlPrevillize.Items.Add("Cheque Received");
        //    chlPrevillize.Items.Add("Cheque Print");
        //    chlPrevillize.Items.Add("Cheque Reprint Permission");
        //    chlPrevillize.Items.Add("Bank Reconcile");
        //    chlPrevillize.Items.Add("Deposit Request");
        //    chlPrevillize.Items.Add("Deposit Approval");
        //    chlPrevillize.Items.Add("Price Data Loader");
        //    chlPrevillize.Items.Add("Workstation Add/Edit");
        //    chlPrevillize.Items.Add("Holiday Entry");

        //    chlPrevillize.Items.Add("Client Share Ledger");
        //    chlPrevillize.Items.Add("Client Money Ledger");
        //    chlPrevillize.Items.Add("Client Summery Ledger");
        //    chlPrevillize.Items.Add("Client Info Report");
        //    chlPrevillize.Items.Add("Account Review Report");
        //    chlPrevillize.Items.Add("Trade Confirmation Report");
        //    chlPrevillize.Items.Add("Trade Summery Report");
        //    chlPrevillize.Items.Add("Buy-Sale Report");
        //    chlPrevillize.Items.Add("WorkStationWise Trade Report");
        //    chlPrevillize.Items.Add("Review Report");
        //    chlPrevillize.Items.Add("Todays Summery Report");
        //    chlPrevillize.Items.Add("Tax Certificate");

        //    chlPrevillize.Items.Add("Add Capex");
        //    chlPrevillize.Items.Add("Delete Capex");
        //    chlPrevillize.Items.Add("Daily Opex");
        //    chlPrevillize.Items.Add("Monthly Opex");
        //    chlPrevillize.Items.Add("Common Opex");
        //    chlPrevillize.Items.Add("Approve Opex");
        //    chlPrevillize.Items.Add("Expenditure Category Add");
        //    chlPrevillize.Items.Add("Logged Users");
        //    chlPrevillize.Items.Add("Change Instrument");
        //    chlPrevillize.Items.Add("Payment OCC");
        //    chlPrevillize.Items.Add("Approval Payment OCC");
        //    chlPrevillize.Items.Add("Delete Payment OCC");
        //    chlPrevillize.Items.Add("Excel Cheque Configuration");
        //    chlPrevillize.Items.Add("Delete Role");
        //    chlPrevillize.Items.Add("Delete User");
        //    chlPrevillize.Items.Add("GA Margin");
        //    chlPrevillize.Items.Add("VMA/VIP Margin");
        //    chlPrevillize.Items.Add("Limited Client Dashboard");
        //    chlPrevillize.Items.Add("Finical Netting");
        //    chlPrevillize.Items.Add("Tax Statement");

        //    chlPrevillize.Items.Add("EFT Requisition");
        //    chlPrevillize.Items.Add("EFT Issue");
        //    chlPrevillize.Items.Add("EFT/Cash (Requisition)");
        //    chlPrevillize.Items.Add("DP 29 File Upload");
            
        //}
        private List<bool> DuplicateCheck()
        {
            PrevillizeManagementBAL prevbal = new PrevillizeManagementBAL();
            result = prevbal.IsExists(userList, ddlRoleName.Text, previllize_ID, previllize_Name);
            return result;
        }
        private void SearchAndProcessExistingData()
        {
            bool searchContainUser = false;
            PrevillizeManagementBAL prevbal = new PrevillizeManagementBAL();
            DataTable data=new DataTable();
            data = prevbal.SearchBeforeInsert(ddlRoleName.Text, previllize_Name);
            if (userList.Count == 0)
            {
                if (data.Rows.Count > 0)
                {
                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        if (data.Rows[i][0].ToString() != "")
                        {
                            searchContainUser = true;
                            userList.Add(data.Rows[i][0].ToString());
                        }
                    }
                }
                if (searchContainUser)
                {
                    DeleteRoleWithUser();
                    SaveRoleWithoutUser(previllize_ID, previllize_Name);
                    userList = new List<string>();
                }
                if (data.Rows.Count == 0)
                {
                    if (previllize_ID != 0 || previllize_Name != "")
                        SaveRoleWithoutUser(previllize_ID, previllize_Name);
                }
                else
                {
                    MessageBox.Show("Data already exist");
                    return;
                }
            }
            else
            {
                if (data.Rows.Count > 0)
                {
                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        if (data.Rows[i][0].ToString() != "")
                        {
                            searchContainUser = true;
                        }
                    }
                }
                if (searchContainUser)
                {
                    SaveRoleWithUser();
                }
                else
                {
                    DeleteRoleWithoutUser(previllize_ID, previllize_Name);
                    SaveRoleWithUser();
                }

            }
        }
        private void DeleteRoleWithUser()
        {
            PrevillizeManagementBAL prevbal = new PrevillizeManagementBAL();
            prevbal.DeleteRoleWithUser(userList,ddlRoleName.Text,previllize_ID,previllize_Name);
        }

        private void SaveRoleWithUser()
        {
            PrevillizeManagementBAL prevbal = new PrevillizeManagementBAL();
            string name = "";
            List<bool> exist;
            increment = 0;
            exist = DuplicateCheck();
            try
            {
                foreach (bool duplicate in exist)
                {
                    name = userList[increment];
                    if (duplicate == false)
                    {
                        //if (
                        //    MessageBox.Show(@"Do you want to Save ?", @"Save information",
                        //                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        //{
                        prevbal.InsertRoleWithUserInfo(name, ddlRoleName.Text, previllize_ID, previllize_Name);
                    //    }
                    //}
                    //else
                    //{
                    //    MessageBox.Show(@"Data already Restricted", @"Restrict check",
                    //                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    increment++;
                }
                MessageBox.Show(@"Data Saved Successfull", @"Save information",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }
        public void LoadPrevData()
        {
            DataTable data=new DataTable();
            PrevillizeManagementBAL prevbal = new PrevillizeManagementBAL();
            try
            {
                data = prevbal.LoadDataForGrid(userList, ddlRoleName.Text, previllize_ID, previllize_Name);
                dgvprevshow.DataSource = data;
                dgvprevshow.Columns[2].Visible = false;

            }
            catch
            {
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            ////SaveRoleWithUser();
            //SearchAndProcessExistingData();
            //LoadPrevData();
            ////SaveRoleInfo();
            ////LoadDataFromDataTable();
            //userList = new List<string>();
            PrevillizeManagementBAL prevbal = new PrevillizeManagementBAL();
            foreach (PrevwithRole indicator in finalList)
            {
                if (indicator.action == insertIndicator)
                {
                    prevbal.DeleteWithInsertIndicator(indicator.userName,indicator.roleName, indicator.prevName);
                }
            }

            foreach (PrevwithRole indicator in finalList)
            {
                if (indicator.action == deleteIndicator)
                {
     //               prevbal.DeleteWithDeleteIndicator(indicator.userName,indicator.roleName, indicator.prevName);
                }
            }

            foreach (PrevwithRole indicator in finalList)
            {
                if (indicator.action == insertIndicator)
                {
                    prevbal.InsertIntoPrevillize(indicator.userName, indicator.roleName,Int32.Parse( indicator.prevID), indicator.prevName);
                }
            }
            finalList.Clear();
            LoadDataFromDataTable();
        }

        //private void SaveRoleInfo()
        //{
        //    if(ddlRoleName.Text.Trim() == "")
        //    {
        //        MessageBox.Show("Please Enter a role name");
        //        return;
        //    }
        //    try
        //    {

        //        string roleName = ddlRoleName.Text;
        //        List<string> previllizeList = new List<string>();

        //        for (int x = 0; x < chlPrevillize.CheckedItems.Count; x++)
        //        {
        //            previllizeList.Add(chlPrevillize.CheckedItems[x].ToString());
        //        }
        //        PrevillizeManagementBAL previllizeManagementBal = new PrevillizeManagementBAL();
        //        previllizeManagementBal.Insert(roleName, previllizeList);
        //        MessageBox.Show(roleName + " Role Previllize has Saved Successfully.");
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Fail to save Role Previllize because of the Error : " + ex.Message);
        //    }
        //}

        private void ClearAll()
        {
           
            //for(int i=0; i<chlPrevillize.Items.Count;++i)
            //    chlPrevillize.SetItemChecked(i,false);
            foreach (DataGridViewRow dr in dgvPrevillize.Rows)
            {
                dr.Cells[1].Value = false;
            }
        }

       private void btnReset_Click(object sender, EventArgs e)
       {
          ClearAll();
       }
     
        private void LoadRoleName()
        {
            LoadDDLBAL loadDDLBAL = new LoadDDLBAL();
            DataTable dtData = loadDDLBAL.LoadDDL("SBP_Roles");
            ddlRoleName.DataSource = dtData;
            ddlRoleName.DisplayMember = "Role_Name";
            ddlRoleName.ValueMember = "Role_Name";
            if (ddlRoleName.HasChildren)
                ddlRoleName.SelectedIndex = 0;
        }
        private void ddlRoleName_SelectedIndexChanged(object sender, EventArgs e)
        {
            finalList.Clear();
            //LoadDataFromDataTable();
            LoadPrevillizeList();
        }
        private void LoadPrevillizeList()
        {
            DataTable prevDataTable = new DataTable();
            PrevillizeManagementBAL previllizeManagementBal = new PrevillizeManagementBAL();
            prevDataTable = previllizeManagementBal.GetPrevillizeList(ddlRoleName.Text);
            dgvPrevillize.DataSource = prevDataTable;
            //for (int i = 0; i < prevDataTable.Rows.Count; i++)
            //{
            //    int x = dgvPrevillize.Rows.Add();
            //    dgvPrevillize.Rows[x].Cells["PrevillizeID"].Value = prevDataTable.Rows[i]["PrevillizeID"].ToString();
            //    dgvPrevillize.Rows[x].Cells["PrevillizeName"].Value = prevDataTable.Rows[i]["PrevillizeName"].ToString();
            //}

        }

        private void LoadDataFromDataTable()
        {
           
                DataTable roleDataTable = new DataTable();
                PrevillizeManagementBAL previllizeManagementBal = new PrevillizeManagementBAL();
                if (ddlRoleName.SelectedIndex != -1)
                    roleDataTable = previllizeManagementBal.GetAllPrevillize(ddlRoleName.Text);
                if (roleDataTable.Rows.Count > 0)
                {
                    ClearAll();
                    for (int i = 0; i < roleDataTable.Rows.Count; i++)
                    {
                        //SetChecked(roleDataTable.Rows[i][0].ToString());
                        foreach (DataGridViewRow dr in dgvPrevillize.Rows)
                        {
                            if (dr.Cells[2].Value != null)
                            {
                                if (dr.Cells[2].Value.ToString() == roleDataTable.Rows[i][0].ToString())
                                {
                                    dr.Cells[1].Value = true;
                                }
                            }
                        }
                    }
                }
           
        }

        //private void SetChecked(string previllize)
        //{
        //    switch (previllize)
        //    {
        //        case "Initial Info Entry":
        //            chlPrevillize.SetItemChecked(0, true);
        //            break;
        //        case "Broker Info Entry":
        //            chlPrevillize.SetItemChecked(1, true);
        //            break;
        //        case "Branch Add/Edit":
        //            chlPrevillize.SetItemChecked(2, true);
        //            break;
        //        case "Closing Branch":
        //            chlPrevillize.SetItemChecked(3, true);
        //            break;
        //        case "Role Creation":
        //            chlPrevillize.SetItemChecked(4, true);
        //            break;
        //        case "User Creation":
        //            chlPrevillize.SetItemChecked(5, true);
        //            break;
        //        case "Grant Privilege":
        //            chlPrevillize.SetItemChecked(6, true);
        //            break;
        //        case "Common Charge Entry":
        //            chlPrevillize.SetItemChecked(7, true);
        //            break;
        //        case "IPO Charge Entry":
        //            chlPrevillize.SetItemChecked(8, true);
        //            break;
        //        case "GroupWise Commission Entry":
        //            chlPrevillize.SetItemChecked(9, true);
        //            break;
        //        case "Account Holder Add/Edit":
        //            chlPrevillize.SetItemChecked(10, true);
        //            break;
        //        case "Additional Holder Add/Edit":
        //            chlPrevillize.SetItemChecked(11, true);
        //            break;
        //        case "Account Close":
        //            chlPrevillize.SetItemChecked(12, true);
        //            break;
        //        case "Account Searching":
        //            chlPrevillize.SetItemChecked(13, true);
        //            break;
        //        case "Company Add/Edit":
        //            chlPrevillize.SetItemChecked(14, true);
        //            break;
        //        case "Company Type Change":
        //            chlPrevillize.SetItemChecked(15, true);
        //            break;
        //        case "Company Category Change":
        //            chlPrevillize.SetItemChecked(16, true);
        //            break;
        //        case "Unlock Lockedin Share":
        //            chlPrevillize.SetItemChecked(17, true);
        //            break;
        //        case "Company Analysis":
        //            chlPrevillize.SetItemChecked(18,true);
        //            break;
        //        case "ShareDW Entry":
        //            chlPrevillize.SetItemChecked(19, true);
        //            break;
        //        case "Payment Entry":
        //            chlPrevillize.SetItemChecked(20, true);
        //            break;
        //        case "Management View":
        //            chlPrevillize.SetItemChecked(21, true);
        //            break;
        //        case "Customer Inside":
        //            chlPrevillize.SetItemChecked(22, true);
        //            break;
        //        case "Service Registration":
        //            chlPrevillize.SetItemChecked(23, true);
        //            break;
        //        case "Check Print":
        //            chlPrevillize.SetItemChecked(24, true);
        //            break;
        //        case "Voucher Print":
        //            chlPrevillize.SetItemChecked(25, true);
        //            break;
        //        case "Web Data Export":
        //            chlPrevillize.SetItemChecked(26, true);
        //            break;
        //        case "Trade File Import":
        //            chlPrevillize.SetItemChecked(27, true);
        //            break;
        //        case "Generate Cash Limit":
        //            chlPrevillize.SetItemChecked(28, true);
        //            break;
        //        case "Generate Share Limt":
        //            chlPrevillize.SetItemChecked(29, true);
        //            break;
        //        case "Close Price Upload":
        //            chlPrevillize.SetItemChecked(30, true);
        //            break;
        //        case "Share Price Dashboard":
        //            chlPrevillize.SetItemChecked(31, true);
        //            break;
        //        case "Select Company for View Price":
        //            chlPrevillize.SetItemChecked(32, true);
        //            break;
        //        case "New BO Upload":
        //            chlPrevillize.SetItemChecked(33, true);
        //            break;
        //        case "Additional Holder Upload":
        //            chlPrevillize.SetItemChecked(34, true);
        //            break;
        //        case "BO Modification Upload":
        //            chlPrevillize.SetItemChecked(35, true);
        //            break;
        //        case "BO Close Upload":
        //            chlPrevillize.SetItemChecked(36, true);
        //            break;
        //        case "IPO Share Upload":
        //            chlPrevillize.SetItemChecked(37, true);
        //            break;
        //        case "Bonus Share Upload":
        //            chlPrevillize.SetItemChecked(38, true);
        //            break;
        //        case "Right Share Upload":
        //            chlPrevillize.SetItemChecked(39, true);
        //            break;
        //        case "Demat Share Upload":
        //            chlPrevillize.SetItemChecked(40, true);
        //            break;
        //        case "Stock Split Share Upload":
        //            chlPrevillize.SetItemChecked(41, true);
        //            break;
        //        case "Sattlement":
        //            chlPrevillize.SetItemChecked(42, true);
        //            break;
        //        case "Process Data":
        //            chlPrevillize.SetItemChecked(43, true);
        //            break;
        //        case "CDBL Share Reconcile":
        //            chlPrevillize.SetItemChecked(44, true);
        //            break;
        //        case "Image Upload":
        //            chlPrevillize.SetItemChecked(45, true);
        //            break;
        //        case "Margin Registration":
        //            chlPrevillize.SetItemChecked(46, true);
        //            break;
        //        case "Margin Plan Entry":
        //            chlPrevillize.SetItemChecked(47, true);
        //            break;
        //        case "Cashback Reg":
        //            chlPrevillize.SetItemChecked(48, true);
        //            break;
        //        case "Cashback Plan":
        //            chlPrevillize.SetItemChecked(49, true);
        //            break;
        //        case "Cashback Process":
        //            chlPrevillize.SetItemChecked(50, true);
        //            break;
        //        case "Payment Maturity Entry":
        //            chlPrevillize.SetItemChecked(51, true);
        //            break;
        //        case "Image Management":
        //            chlPrevillize.SetItemChecked(52,true);
        //            break;
        //        case "Account Close Charge":
        //            chlPrevillize.SetItemChecked(53, true);
        //            break;
        //        case "Branchwise Tree Report":
        //            chlPrevillize.SetItemChecked(54,true);
        //            break;
        //        case "Delete History For Reprint Check":
        //            chlPrevillize.SetItemChecked(55,true);
        //            break;
        //            case "Delete ShareDW":
        //            chlPrevillize.SetItemChecked(56,true);
        //            break;
        //        case "Delete Payment":
        //            chlPrevillize.SetItemChecked(57,true);
        //            break;
        //        case "Hide Accounts":
        //            chlPrevillize.SetItemChecked(58,true);
        //            break;
        //        case "Dashboard All":
        //            chlPrevillize.SetItemChecked(59,true);
        //            break;
        //        case "Cheque Requisition":
        //            chlPrevillize.SetItemChecked(60,true);
        //            break;
        //        case "Cheque Approval":
        //            chlPrevillize.SetItemChecked(61,true);
        //            break;
        //        case "Cheque Received":
        //            chlPrevillize.SetItemChecked(62,true);
        //            break;
        //        case "Cheque Print":
        //            chlPrevillize.SetItemChecked(63,true);
        //            break;
        //        case "Cheque Reprint Permission":
        //            chlPrevillize.SetItemChecked(64,true);
        //            break;
        //        case "Bank Reconcile":
        //            chlPrevillize.SetItemChecked(65,true);
        //            break;
        //        case "Deposit Request":
        //            chlPrevillize.SetItemChecked(66, true);
        //            break;
        //        case "Deposit Approval":
        //            chlPrevillize.SetItemChecked(67, true);
        //            break;
        //        case "Price Data Loader":
        //            chlPrevillize.SetItemChecked(68,true);
        //            break;
        //        case "Workstation Add/Edit":
        //            chlPrevillize.SetItemChecked(69,true);
        //            break;
        //        case "Holiday Entry":
        //            chlPrevillize.SetItemChecked(70,true);
        //            break;

        //        case "Client Share Ledger":
        //            chlPrevillize.SetItemChecked(71, true);
        //            break;

        //        case "Client Money Ledger":
        //            chlPrevillize.SetItemChecked(72, true);
        //            break;

        //        case "Client Summery Ledger":
        //            chlPrevillize.SetItemChecked(73, true);
        //            break;

        //        case "Client Info Report":
        //            chlPrevillize.SetItemChecked(74, true);
        //            break;

        //        case "Account Review Report":
        //            chlPrevillize.SetItemChecked(75, true);
        //            break;

        //        case "Trade Confirmation Report":
        //            chlPrevillize.SetItemChecked(76, true);
        //            break;

        //        case "Trade Summery Report":
        //            chlPrevillize.SetItemChecked(77, true);
        //            break;
        //        case "Buy-Sale Report":
        //            chlPrevillize.SetItemChecked(78, true);
        //            break;
        //        case "WorkStationWise Trade Report":
        //            chlPrevillize.SetItemChecked(79, true);
        //            break;
        //        case "Review Report":
        //            chlPrevillize.SetItemChecked(80, true);
        //            break;
        //        case "Todays Summery Report":
        //            chlPrevillize.SetItemChecked(81, true);
        //            break;
        //        case "Tax Certificate":
        //            chlPrevillize.SetItemChecked(82, true);
        //            break;

        //        case "Add Capex":
        //            chlPrevillize.SetItemChecked(83, true);
        //            break;
        //        case "Delete Capex":
        //            chlPrevillize.SetItemChecked(84, true);
        //            break;
        //        case "Daily Opex":
        //            chlPrevillize.SetItemChecked(85, true);
        //            break;
        //        case "Monthly Opex":
        //            chlPrevillize.SetItemChecked(86, true);
        //            break;
        //        case "Common Opex":
        //            chlPrevillize.SetItemChecked(87, true);
        //            break;
        //        case "Approve Opex":
        //            chlPrevillize.SetItemChecked(88, true);
        //            break;
        //        case "Expenditure Category Add":
        //            chlPrevillize.SetItemChecked(89, true);
        //            break;

        //            case "Logged Users":
        //            chlPrevillize.SetItemChecked(90, true);
        //            break;

        //            case "Change Instrument":
        //            chlPrevillize.SetItemChecked(91, true);
        //            break;

        //            case "Payment OCC":
        //            chlPrevillize.SetItemChecked(92, true);
        //            break;

        //            case "Approval Payment OCC":
        //            chlPrevillize.SetItemChecked(93, true);
        //            break;

        //            case "Delete Payment OCC":
        //            chlPrevillize.SetItemChecked(94, true);
        //            break;

        //            case "Excel Cheque Configuration":
        //            chlPrevillize.SetItemChecked(95, true);
        //            break;

        //            case "Delete Role":
        //            chlPrevillize.SetItemChecked(96, true);
        //            break;

        //            case "Delete User":
        //            chlPrevillize.SetItemChecked(97, true);
        //            break;

        //            case "GA Margin":
        //            chlPrevillize.SetItemChecked(98, true);
        //            break;


        //            case "VMA/VIP Margin":
        //            chlPrevillize.SetItemChecked(99, true);
        //            break;

        //        case "Limited Client Dashboard":
        //            chlPrevillize.SetItemChecked(100,true);
        //            break;

        //         case "Finical Netting":
        //            chlPrevillize.SetItemChecked(101, true);
        //            break;

        //        case "Tax Statement":
        //            chlPrevillize.SetItemChecked(102,true);
        //            break;

        //        case "EFT Requisition":
        //            chlPrevillize.SetItemChecked(103, true);
        //            break;

        //        case "EFT Issue":
        //            chlPrevillize.SetItemChecked(104, true);
        //            break;

        //        case "EFT/Cash (Requisition)":
        //            chlPrevillize.SetItemChecked(105, true);
        //            break;

        //        case "DP 29 File Upload":
        //            chlPrevillize.SetItemChecked(106, true);
        //            break;
        //    }
           
        //}
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void btnLimitPrevillize_Click(object sender, EventArgs e)
        {
            frmSpecialClientDashboard objSpecial = new frmSpecialClientDashboard("Limit");
          //  objSpecial.MdiParent = this;
            objSpecial.Show();
        }

        private void btnHide_Previllize_Click(object sender, EventArgs e)
        {
            string hide = "Hide";
            frmSpecialClientDashboard objSpecial = new frmSpecialClientDashboard(hide);
           // objSpecial.MdiParent = this;
            objSpecial.Show();
        }

        private void btnRoleWithUserPrevillize_Click(object sender, EventArgs e)
        {
            frmRoleWithUserPrevillize rolwwithuser=new frmRoleWithUserPrevillize();
           // rolwwithuser.MdiParent = this;
            rolwwithuser.Show();
        }
        private void SaveRoleWithoutUser(int previd,string prevname)
        {
            PrevillizeManagementBAL prevbal=new PrevillizeManagementBAL();
            prevbal.InsertRoleInfo("",ddlRoleName.Text,previd,prevname);
        }

        private void DeleteRoleWithoutUser(int previd, string prevname)
        {
            PrevillizeManagementBAL prevbal = new PrevillizeManagementBAL();
            prevbal.DeleteRoleInfo(ddlRoleName.Text, previd, prevname);
        }

        private void dgvPrevillize_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 2) && (dgvPrevillize.Rows[e.RowIndex].Cells["Select"].EditedFormattedValue != null) &&
                ((bool) dgvPrevillize.Rows[e.RowIndex].Cells["Select"].EditedFormattedValue == true))
            {
                previllize_ID = Int32.Parse(dgvPrevillize.Rows[e.RowIndex].Cells["PrevillizeID"].Value.ToString());
                previllize_Name = dgvPrevillize.Rows[e.RowIndex].Cells["PrevillizeName"].Value.ToString();
                SaveRoleWithoutUser(previllize_ID, previllize_Name);
              //  finalList.Add(new PrevwithRole { userName = string.Empty, roleName = ddlRoleName.Text, prevID=dgvPrevillize.Rows[e.RowIndex].Cells["PrevillizeID"].Value.ToString(), prevName = dgvPrevillize.Rows[e.RowIndex].Cells["PrevillizeName"].Value.ToString(), action=insertIndicator });
                LoadAfterDeleteRoleAndPrev(Int32.Parse(dgvPrevillize.CurrentRow.Index.ToString()));
            }
            else if ((e.ColumnIndex == 2) &&
                     (dgvPrevillize.Rows[e.RowIndex].Cells["Select"].EditedFormattedValue != null) &&
                     ((bool) dgvPrevillize.Rows[e.RowIndex].Cells["Select"].EditedFormattedValue == false))
            {
                //previllize_ID = 0;
                //previllize_Name = "";
                previllize_ID = Int32.Parse(dgvPrevillize.Rows[e.RowIndex].Cells["PrevillizeID"].Value.ToString());
                previllize_Name = dgvPrevillize.Rows[e.RowIndex].Cells["PrevillizeName"].Value.ToString();

                DeleteRoleWithoutUser(previllize_ID, previllize_Name);
                LoadAfterDeleteRoleAndPrev(Int32.Parse(dgvPrevillize.CurrentRow.Index.ToString()));
                //List<int> indexTobeDeleted=new List<int>();
                //var DeletedRecords = finalList.Where(t => t.roleName == ddlRoleName.Text && t.prevID == dgvPrevillize.Rows[e.RowIndex].Cells["PrevillizeID"].Value.ToString() && t.action == insertIndicator);
                //foreach (var obj in DeletedRecords)
                //{
                //    int indexTemp = finalList.FindIndex(t => t.roleName == obj.roleName && t.prevID == obj.prevID && t.action==obj.action);
                //    indexTobeDeleted.Add(indexTemp);
                //}
                //foreach(int deleteTemp in indexTobeDeleted)
                //{
                //    finalList.RemoveAt(deleteTemp);
                //}

                //if (DeletedRecords == null)
                //{
                //    finalList.Add(new PrevwithRole { userName = string.Empty, roleName = ddlRoleName.Text, prevID=dgvPrevillize.Rows[e.RowIndex].Cells["PrevillizeID"].Value.ToString(), prevName = dgvPrevillize.Rows[e.RowIndex].Cells["PrevillizeName"].Value.ToString(), action = deleteIndicator });
                //}
            }
            else if ((e.ColumnIndex == 0) &&
                     (dgvPrevillize.Rows[e.RowIndex].Cells["Select"].EditedFormattedValue != null) &&
                     ((bool) dgvPrevillize.Rows[e.RowIndex].Cells["Select"].EditedFormattedValue == true))
            {
                previllize_ID =
                    Int32.Parse(dgvPrevillize.Rows[e.RowIndex].Cells["PrevillizeID"].Value.ToString());
                previllize_Name = dgvPrevillize.Rows[e.RowIndex].Cells["PrevillizeName"].Value.ToString();
                //if (userList.Count == 0)
                //{
                //    DeleteRoleWithoutUser(previllize_ID, previllize_Name);
                //}
                userList = new List<string>();
                
                frmAddUser adduser = new frmAddUser(ddlRoleName.Text,
                                                    dgvPrevillize.Rows[e.RowIndex].Cells["PrevillizeID"].Value.
                                                        ToString(),
                                                    dgvPrevillize.Rows[e.RowIndex].Cells["PrevillizeName"].Value
                                                        .ToString(),Int32.Parse(dgvPrevillize.CurrentRow.Index.ToString()));
                PrevillizeManagementBAL objBal = new PrevillizeManagementBAL();
                if (!objBal.IsExistRoleAndPrevillize(ddlRoleName.Text, previllize_Name, previllize_ID))
                    SaveRoleWithoutUser(previllize_ID, previllize_Name);
                adduser.StartPosition = FormStartPosition.CenterParent;
                adduser.ShowDialog(this);
                
                
                
            }
            else if ((e.ColumnIndex == 0) &&
                     (dgvPrevillize.Rows[e.RowIndex].Cells["Select"].EditedFormattedValue != null) &&
                     ((bool) dgvPrevillize.Rows[e.RowIndex].Cells["Select"].EditedFormattedValue == false))
            {
                MessageBox.Show("Please first Select an item ");
                return;
            }
            

        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            PrevillizeManagementBAL prevbal = new PrevillizeManagementBAL();
            try
            {
                int row = dgvprevshow.CurrentRow.Index;
                userList.Clear();
                userList.Add(dgvprevshow[0, dgvprevshow.CurrentRow.Index].Value.ToString());
                prevbal.DeleteRoleWithUser(userList, ddlRoleName.Text, Int32.Parse(dgvprevshow[2, row].Value.ToString()), dgvprevshow[3, dgvprevshow.CurrentRow.Index].Value.ToString());
                userList.Clear();
                foreach (DataGridViewRow dr in dgvprevshow.Rows)
                {
                    if (dr.Index != row)
                    {
                        try
                        {
                            userList.Add(dr.Cells[0].Value.ToString());
                        }
                        catch
                        {
                        }
                    }
                }
                MessageBox.Show("Successfully Deleted");
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            LoadPrevData();
            userList.Clear();
        }
        public void LoadAfterDeleteRoleAndPrev(int row)
        {
            DataTable data = new DataTable();
            PrevillizeManagementBAL prevbal = new PrevillizeManagementBAL();
            try
            {

                data = prevbal.LoadDataForGrid(ddlRoleName.Text, Int32.Parse(dgvPrevillize["PrevillizeID", row].Value.ToString()), dgvPrevillize["PrevillizeName", row].Value.ToString());
                dgvprevshow.DataSource = data;
                dgvprevshow.Columns[2].Visible = false;

            }
            catch (Exception ex)
            {
                //  MessageBox.Show(ex.Message);
            }

        }
        private void dgvPrevillize_SelectionChanged(object sender, EventArgs e)
        {
            int row = dgvPrevillize.CurrentRow.Index;
            LoadAfterDeleteRoleAndPrev(row);
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
