using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using BusinessAccessLayer.BO;
using BusinessAccessLayer.Constants;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using SBPXMLSchema;


namespace StockbrokerProNewArch
{
    public partial class CusInfoEntry : Form
    {

        public CusInfoEntry()
        {
            InitializeComponent();

        }
        private string bank_branch_routing = "bank_branch_routing";
        private CustomerModificationLogBO _custModLogBo;
        public string _customerCode;
        private GlobalVariableBO.ModeSelection _currentMode = GlobalVariableBO.ModeSelection.NewMode;
        private string[] Account_Type = new string[] { Indication_AccountType.CurrentAccount, Indication_AccountType.SavingsAccount };
        private Dictionary<string, object> custInfoEntryCache = new Dictionary<string, object>();

        private bool isKeyPressEventFired_txtBranchName = false;
        private enum PanelVisibleState
        {
            PanelBankCombo
           ,
            PanelBranchCombo
           ,
            PanelBank_BranchCombo
           ,
            PanelBankTextBox
           ,
            PanelBranchTextBox
        }
        private void SetPanelVisibleState(PanelVisibleState pnlName)
        {
            switch (pnlName)
            {
                case PanelVisibleState.PanelBankCombo:
                    pnlBankCombo.Visible = true;
                    pnlBankTextBox.Visible = false;
                    break;

                case PanelVisibleState.PanelBranchCombo:
                    pnlBranchCombo.Visible = true;
                    pnlBranchTextBox.Visible = false;
                    break;

                case PanelVisibleState.PanelBank_BranchCombo:
                    pnlBankCombo.Visible = true;
                    pnlBankTextBox.Visible = false;
                    pnlBranchCombo.Visible = true;
                    pnlBranchTextBox.Visible = false;
                    break;

                case PanelVisibleState.PanelBankTextBox:
                    pnlBankTextBox.Visible = true;
                    pnlBankCombo.Visible = false;
                    break;

                case PanelVisibleState.PanelBranchTextBox:
                    pnlBranchTextBox.Visible = true;
                    pnlBranchCombo.Visible = false;
                    break;
            }
        }
        private void CusInfoEntry_Load(object sender, EventArgs e)
        {
            cmbNetAdjustment.SelectedIndex = 0;
            LoadFunctions();
            Init();
            LoadBank_Branch_Name();
            SetPanelVisibleState(PanelVisibleState.PanelBank_BranchCombo);

        }
        private void Init()
        {
            CommonBAL bal = new CommonBAL();
            dtCustomerOpenDate.Value = bal.GetCurrentServerDate();
            dtOpenDate.Value = bal.GetCurrentServerDate();
            txtNameAddressSE.Enabled = rdoSEYes.Checked;
            txtAccLinkBO.Enabled = rdoLinkYes.Checked;
            ddlSex.SelectedIndex = 0;
            ddlResidency.SelectedIndex = 0;
            ddlSatementCycle.SelectedIndex = 0;
            ddlOccupation.SelectedIndex = 0;
            ddlCustomerGroup.SelectedIndex = 0;
            ddlBOType.SelectedIndex = 0;
            ddlBOCategory.SelectedIndex = 0;
            ddlJointHolderSex.SelectedIndex = 0;
            ddlOperatedBy.SelectedIndex = 0;
            //if (ddlRoutingNo.SelectedIndex == -1)
            //    ddlRoutingNo.SelectedIndex = 0;
            //else
            //    ddlRoutingNo.SelectedIndex = 0;
            tabControl1.TabPages.Remove(tabPageJointHolder);

        }
        private void LoadFunctions()
        {
            LoadCustomerGroup();
            LoadBOType();
            LoadBOCategory();
            LoadStatementCycle();
            LoadAccountType();
            LoadAssignedWorkstation();
            LoadBoStatus();

        }

        private void LoadAssignedWorkstation() //Call to this Method /*LoadFunctions()*/
        {
            CustomerInfoBAL Bal = new CustomerInfoBAL();
            DataTable dt = new DataTable();
            dt = Bal.GetWorkStationName();
            cmbworkstationName.DataSource = dt;
            cmbworkstationName.DisplayMember = "WorkStation_Name";
            cmbworkstationName.ValueMember = "WorkStation_Name";

        }

        private void LoadBank_Branch_Name()
        {
            DataTable dtBankBranchRoutingInfo = new DataTable();
            DataTable dtBranchName = new DataTable();
            Bank_Branch_ComboBAL objBAL = new Bank_Branch_ComboBAL();

            dtBankBranchRoutingInfo = objBAL.GetRoutingInfo();
            custInfoEntryCache.Add(bank_branch_routing, dtBankBranchRoutingInfo);
            var BankDs = (custInfoEntryCache.Where(t => t.Key == bank_branch_routing)
                        .Select(t => t.Value).SingleOrDefault() as DataTable).AsEnumerable()
                        .Select(t => new { Key_Dtl = t["Bank_ID"], Value_Dtl = t["Bank_Name"] }).GroupBy(t => t.Key_Dtl)
                        .Select(g => new { Key = g.Key, Value = Convert.ToString(g.Max(t => t.Value_Dtl)) }).ToList();

            var MaxLenBank = BankDs.Select(t => t.Value.Length).Max();


            ddlBankName.ValueMember = "Key";
            ddlBankName.DisplayMember = "Value";
            ddlBankName.DataSource = BankDs;
            ddlBankName.DropDownWidth = MaxLenBank * 7;

            var RoutingDs = (custInfoEntryCache.Where(t => t.Key == bank_branch_routing)
                .Select(t => t.Value).SingleOrDefault() as DataTable).AsEnumerable()
                .Select(t => new { Key = t["Routing_No"], Value = t["Routing_No"] }).ToList();
            ddlRoutingNo.DataSource = RoutingDs;

            ddlRoutingNo.ValueMember = "Key";
            ddlRoutingNo.DisplayMember = "Value";
            
            ddlRoutingNo.SelectedIndex = 0;

        }
        private void LoadAccountType()
        {
            for (int i = 0; i < Account_Type.Length; i++)
                ddlAccountType.Items.Add(Account_Type[i].ToString());
            try
            {
                ddlAccountType.SelectedIndex = 0;
            }
            catch
            {

            }
        }

        private void LoadStatementCycle()
        {
            LoadDDLBAL loadDDLBAL = new LoadDDLBAL();
            DataTable dtData = loadDDLBAL.LoadDDL("SBP_Statement_Cycle");
            ddlSatementCycle.DataSource = dtData;
            ddlSatementCycle.DisplayMember = "Statement_Cycle";
            ddlSatementCycle.ValueMember = "Statement_Cycle_ID";
            if (ddlSatementCycle.HasChildren)
                ddlSatementCycle.SelectedIndex = 0;

        }

        private void LoadCustomerGroup()
        {
            LoadDDLBAL loadDDLBAL = new LoadDDLBAL();
            DataTable dtData = loadDDLBAL.LoadDDL("SBP_Cust_Group");

            ddlCustomerGroup.DataSource = dtData;

            ddlCustomerGroup.DisplayMember = "Cust_Group";
            ddlCustomerGroup.ValueMember = "Cust_Group_ID";

            if (ddlCustomerGroup.HasChildren)
                ddlCustomerGroup.SelectedIndex = 0;
        }


        private void LoadBoStatus()
        {
            LoadDDLBAL loadDDLBAL = new LoadDDLBAL();
            DataTable dtData = loadDDLBAL.LoadDDL("SBP_BO_Status");

            cmdBoStatus.DataSource = dtData;

            cmdBoStatus.DisplayMember = "BO_Status";
            cmdBoStatus.ValueMember = "BO_Status_ID";

            if (cmdBoStatus.HasChildren)
                cmdBoStatus.SelectedIndex = 0;
        }

        private void LoadBOType()
        {
            LoadDDLBAL loadDDLBAL = new LoadDDLBAL();
            DataTable dtData = loadDDLBAL.LoadDDL("SBP_BO_Type");

            ddlBOType.DataSource = dtData;

            ddlBOType.DisplayMember = "BO_Type";
            ddlBOType.ValueMember = "BO_Type_ID";
            if (ddlBOType.HasChildren)
                ddlBOType.SelectedIndex = 0;
        }

        private void LoadBOCategory()
        {
            LoadDDLBAL loadDDLBAL = new LoadDDLBAL();
            DataTable dtData = loadDDLBAL.LoadDDL("SBP_BO_Category");

            ddlBOCategory.DataSource = dtData;

            ddlBOCategory.DisplayMember = "BO_Category";
            ddlBOCategory.ValueMember = "BO_Category_ID";
            if (ddlBOCategory.HasChildren)
                ddlBOCategory.SelectedIndex = 0;
        }

        private void SaveCustomerInfo()
        {
            string bankName, branchName;
            if (txtCustomerCode.Text.Trim() == "")
            {
                MessageBox.Show("Please Fill the customer code.");
                return;
            }
            if (txtBoId.Text.Trim() == "")
            {
                MessageBox.Show("Please Fill the BO ID.");
                return;
            }

            if (ddlBankName.SelectedIndex < 0)
            {
                MessageBox.Show("Please Fill Bank Name.");
                return;
            }
            if (ddlBranchName.SelectedIndex < 0)
            {
                MessageBox.Show("Please Fill Branch Name.");
                return;
            }

            if (ddlRoutingNo.SelectedIndex<0)
            {
                MessageBox.Show("Please Fill Routing Number");
                return;
            }


            try
            {
                //Basic Info
                CustomerBasicInfoBO customerBasicInfoBO = new CustomerBasicInfoBO();
                customerBasicInfoBO.CustCode = txtCustomerCode.Text;
                if (ddlCustomerGroup.SelectedIndex != -1)
                    customerBasicInfoBO.CustGroup = Convert.ToInt16(ddlCustomerGroup.SelectedValue);                
                customerBasicInfoBO.SpecialInstrution = txtNameAddressSE.Text;
                customerBasicInfoBO.CustOpenDate = Convert.ToDateTime(dtCustomerOpenDate.Value);
                if (txtCustomerParentCode.Text.Trim() != "")
                    customerBasicInfoBO.CustParentCode = Convert.ToInt16(txtCustomerParentCode.Text);
                customerBasicInfoBO.BOID = txtBoId.Text;
                //if (customerBasicInfoBO.BOID != string.Empty && customerBasicInfoBO.BOID.Length == 8)
                    customerBasicInfoBO.BOStatus = Convert.ToInt16(cmdBoStatus.SelectedValue);

                if (ddlBOType.SelectedIndex != -1)
                    customerBasicInfoBO.BOType = Convert.ToInt16(ddlBOType.SelectedValue);
                if (ddlBOCategory.SelectedIndex != -1)
                    customerBasicInfoBO.BOCategory = Convert.ToInt16(ddlBOCategory.SelectedValue);
                customerBasicInfoBO.BOOpenDate = Convert.ToDateTime(dtOpenDate.Value);
                customerBasicInfoBO.IsDirSE = Convert.ToInt16(rdoSEYes.Checked);
                customerBasicInfoBO.NameAddressSE = txtNameAddressSE.Text;

                //add by Rashedul Hasan on 30 july 2015
                if (RDMargin.Checked)
                {
                    customerBasicInfoBO.Transaction_Status_ID = Indication_AccountType.Margin_ID;
                }
                if (RDCash.Checked)
                {
                    customerBasicInfoBO.Transaction_Status_ID = Indication_AccountType.Cash_ID;
                }

                //Personal Info

                CustomerPersonalInfoBO customerPersonalInfoBO = new CustomerPersonalInfoBO();
                customerPersonalInfoBO.CustCode = txtCustomerCode.Text;
                customerPersonalInfoBO.AccountHolder = txtAccountHolder.Text;
                customerPersonalInfoBO.FatherName = txtFatherName.Text;
                customerPersonalInfoBO.MotherName = txtMotherName.Text;
                customerPersonalInfoBO.DOB = dtDOB.Value;
                if (ddlSex.SelectedIndex != -1)
                    customerPersonalInfoBO.Gender = ddlSex.SelectedItem.ToString();
                if (ddlOccupation.SelectedIndex != -1)
                    customerPersonalInfoBO.Occupation = ddlOccupation.SelectedItem.ToString();
                customerPersonalInfoBO.NationalID = txtNationalIdNo.Text;


                //Contacts Details
                CustomerContactDetailsBO contactDetailsBO = new CustomerContactDetailsBO();
                contactDetailsBO.CustCode = txtCustomerCode.Text;
                contactDetailsBO.Address1 = txtAddress1.Text;
                contactDetailsBO.Address2 = txtAddress2.Text;
                contactDetailsBO.Address3 = txtAddress3.Text;
                contactDetailsBO.CityName = txtCity.Text;

                contactDetailsBO.PostCode = txtPostCode.Text;
                contactDetailsBO.DivisionName = txtDivision.Text;
                contactDetailsBO.CountryName = txtCountry.Text;
                contactDetailsBO.Telephone = txtTelephone.Text;
                contactDetailsBO.Mobile = txtMobile.Text;
                contactDetailsBO.CustomerFax = txtFax.Text;
                contactDetailsBO.CustomerEmail = txtEmail.Text;


                //Additional Info
                CustomerInfoBAL CustomerInfoBAL = new CustomerInfoBAL();
                CustomerAdditionalInfoBO additionalInfoBO = new CustomerAdditionalInfoBO();
                additionalInfoBO.CustCode = txtCustomerCode.Text;
                if (ddlResidency.SelectedIndex != -1)
                    additionalInfoBO.Residency = ddlResidency.SelectedItem.ToString();
                additionalInfoBO.Nationality = txtNationality.Text;
                if (ddlSatementCycle.SelectedIndex != -1)
                    additionalInfoBO.StatementCycleID = Convert.ToInt16(ddlSatementCycle.SelectedValue);
                additionalInfoBO.InternalRefNo = txtInternalReference.Text;
                additionalInfoBO.CompanyRegNo = txtCompanyRegNo.Text;
                additionalInfoBO.CompanyRegDate = dtRegDate.Value;

                additionalInfoBO.IsAccLinkRequest = Convert.ToInt16(rdoLinkYes.Checked);
                additionalInfoBO.AccLinkBo = txtAccLinkBO.Text;
                additionalInfoBO.IsStandingIns = Convert.ToInt16(rdoStandingYes.Checked);
                //additionalInfoBO.AssignedWorkstation = cmbworkstationName.Text.ToString();
                if (cmbworkstationName.Text.Trim().ToUpper() == ("N/A").Trim().ToUpper())
                {
                    additionalInfoBO.AssignedWorkstation = CustomerInfoBAL.Default_Work_Station();
                }
                else if (cmbworkstationName.Text.Trim() == "")
                {
                    additionalInfoBO.AssignedWorkstation = CustomerInfoBAL.Default_Work_Station();
                }
                else
                {
                    additionalInfoBO.AssignedWorkstation = cmbworkstationName.Text.ToString();
                }


                if (cmbNetAdjustment.Text.Trim().ToUpper() == ("N/A").ToUpper().Trim())
                {
                    additionalInfoBO.Net_Adjustment = "";
                }
                else if (cmbNetAdjustment.Text.Trim() == "")
                {
                    additionalInfoBO.Net_Adjustment = "";
                }
                else
                {
                    additionalInfoBO.Net_Adjustment = cmbNetAdjustment.Text.Trim().ToString();
                }

                //Bank Info
                CustomerBankDetailsBO bankDetailsBO = new CustomerBankDetailsBO();
                //Bank_Branch_ComboBAL objBAL = new Bank_Branch_ComboBAL();
                bankDetailsBO.CustCode = txtCustomerCode.Text;
                bankDetailsBO.Bank_ID = Convert.ToInt32(ddlBankName.SelectedValue.ToString());

                var bankNameTemp = (custInfoEntryCache.Where(t => t.Key == bank_branch_routing)
                    .Select(t => t.Value).SingleOrDefault() as DataTable).AsEnumerable()
                    .Where(t => Convert.ToInt32(t["Bank_ID"]) == bankDetailsBO.Bank_ID)
                    .Select(t => t["Bank_Name"]).FirstOrDefault();//.SingleOrDefault();

                // bankName = objBAL.GetBankNameByBankID(bankDetailsBO.Bank_ID);
                //bankName = bankNameTemp.ToString();
                bankDetailsBO.BankName = bankNameTemp.ToString();// txtBankName.Text;
                bankDetailsBO.Branch_ID = Convert.ToInt32(ddlBranchName.SelectedValue.ToString());

                var branchTemp = (custInfoEntryCache.Where(t => t.Key == bank_branch_routing)
                    .Select(t => t.Value).SingleOrDefault() as DataTable).AsEnumerable()
                    .Where(t => Convert.ToInt32(t["Branch_ID"]) == bankDetailsBO.Branch_ID)
                    .Select(t => t["Branch_Name"]).FirstOrDefault();

                //branchName = branchTemp.ToString();// objBAL.GetBranchNameByBranchID(bankDetailsBO.Branch_ID); //------------Apply Cache--------------
                bankDetailsBO.BranchName = branchTemp.ToString();// txtBranchName.Text;
                bankDetailsBO.AccountNo = txtAccountNo.Text;
                bankDetailsBO.AccountType = ddlAccountType.Text;
                bankDetailsBO.IsEDC = Convert.ToInt16(rdoEDCYes.Checked);
                bankDetailsBO.IsTaxExemption = Convert.ToInt16(rdoTaxExemptionYes.Checked);
                bankDetailsBO.TIN = txtTIN.Text;
                bankDetailsBO.SWIFT_Code = txtSWIFTCode.Text.Trim();
                bankDetailsBO.IBAN = txtIBAN.Text.Trim();
              

                bankDetailsBO.Routing_No = ddlRoutingNo.SelectedValue.ToString();
                bankDetailsBO.District_Name = txtDistrictName.Text.Trim();
                //Passport Info
                CustomerPassportInfoBO passportInfoBO = new CustomerPassportInfoBO();
                passportInfoBO.CustCode = txtCustomerCode.Text;
                passportInfoBO.PassportNo = txtPassportNo.Text;
                passportInfoBO.IssuePlace = txtIssuePlace.Text;
                passportInfoBO.IssueDate = dtIssueDate.Value;
                passportInfoBO.ExpireDate = dtExpireDate.Value;

                //Joint Info
                JointAccountHolderInfoBO jointAccountBO = new JointAccountHolderInfoBO();
                jointAccountBO.JointCustCode = txtCustomerCode.Text;
                jointAccountBO.JointName = txtJointHolderName.Text;
                jointAccountBO.JointFatherName = txtJointHolderFather.Text;
                jointAccountBO.JointMotherName = txtJointHolderMother.Text;
                jointAccountBO.JointDOB = dtJointHolderDOB.Value;
                if (ddlJointHolderSex.SelectedIndex != -1)
                    jointAccountBO.JointSex = ddlJointHolderSex.SelectedItem.ToString();
                if (ddlOperatedBy.SelectedIndex != -1 && ddlOperatedBy.SelectedItem.ToString() != "Others")
                {
                    jointAccountBO.JointOperatedBy = ddlOperatedBy.SelectedItem.ToString();
                }
                else
                {
                    jointAccountBO.JointOperatedBy = txtOperatedBy.Text;

                }
                jointAccountBO.JointNationality = txtJointHolderNationality.Text;
                jointAccountBO.JointNationalId = txtJointHolderNationalID.Text;
                jointAccountBO.JointAddress = txtJointHolderAddress.Text;
                jointAccountBO.JoitnPhone = txtJointHolderPhone.Text;
                jointAccountBO.JointMobile = txtJointHolderMobile.Text;
                jointAccountBO.JointEmail = txtJointHolderEmail.Text;

                //Author n Introducer Info
                AuthorInroducerBO authorInroBO = new AuthorInroducerBO();
                authorInroBO.AuthorCustCode = txtCustomerCode.Text;
                authorInroBO.AuthorName = txtAuthorName.Text;
                authorInroBO.AuthorAddress = txtAuthorAddress.Text;
                authorInroBO.AuthorMobile = txtAuthorMobile.Text;
                authorInroBO.IntroName = txtIntroName.Text;
                authorInroBO.IntroAddress = txtIntroName.Text;
                authorInroBO.IntroBOID = txtIntroBOID.Text;
                authorInroBO.IntroRemarks = txtIntroRemarks.Text;

                switch (_currentMode)
                {
                    case GlobalVariableBO.ModeSelection.NewMode:
                        try
                        {
                            if (IsInputValid())
                            {
                                CustomerInfoBAL customerBasicInfoBAL = new CustomerInfoBAL();
                                customerBasicInfoBAL.Insert(customerBasicInfoBO, customerPersonalInfoBO,
                                                            contactDetailsBO, additionalInfoBO, bankDetailsBO,
                                                            passportInfoBO, jointAccountBO, authorInroBO);
                                MessageBox.Show("Customer's Information Saved Successfully.");
                                ClearAll();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Fail to save Customer's Information because of the Error : " + ex.Message);
                        }
                        break;
                    case GlobalVariableBO.ModeSelection.UpdateMode:
                        try
                        {
                            CustomerInfoBAL customerBasicInfoBAL = new CustomerInfoBAL();
                            if (IsPendingStatus(txtCustomerCode.Text.Trim()))
                            {
                                if (!IsInputValid())
                                    UpdatePendingStatus(txtCustomerCode.Text.Trim());
                                
                            }
                            customerBasicInfoBAL.Update(customerBasicInfoBO, customerPersonalInfoBO, contactDetailsBO, additionalInfoBO, bankDetailsBO, passportInfoBO, jointAccountBO, authorInroBO, _custModLogBo);
                            MessageBox.Show("Customer's Information Updated Successfully.");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Fail to update Customer's Information because of the Error : " + ex.Message);
                        }
                        break;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private bool IsPendingStatus(string cust_code)
        {
            bool isPending = false;
            CustomerInfoBAL customerBasicInfoBAL = new CustomerInfoBAL();
            isPending = customerBasicInfoBAL.IsPending(cust_code);
            return isPending;
        }

        private void UpdatePendingStatus(string cust_code)
        {
            CustomerInfoBAL customerBasicInfoBAL = new CustomerInfoBAL();
            customerBasicInfoBAL.UpdatePendingStatus(cust_code);
        }

        private void btnSaveBasicInfo_Click(object sender, EventArgs e)
        {
            if ((_currentMode == GlobalVariableBO.ModeSelection.UpdateMode) && (txtBoId.Text.Length.Equals(0)))
            {
                LoadSelectedInformation();
                return;
            }
            SetPanelVisibleState(PanelVisibleState.PanelBank_BranchCombo);
            SaveCustomerInfo();
        }

        private void RealTimeExportSMSServer_MoneyTransaction()
        {
            string Cust_Code = txtCustomerCode.Text;
            
                
            SMSSyncBAL syncBal = new SMSSyncBAL();
            DashboardBAL dashBal = new DashboardBAL();

            try
            {

                syncBal.Connect_SBP();
                syncBal.Connect_SMS();

                SqlDataReader dt_GotExported_CustAllInformation = syncBal.GetIPO_Customer_All_UITransApplied(Cust_Code);
                syncBal.DeleteData_SMSSyncExport_Customer_All_UITransApplied(Cust_Code);
                syncBal.InsertTable_SMSSyncExport_Customer_All_UITransApplied(dt_GotExported_CustAllInformation);

                //////Export Customer IPO Acc
                //SqlDataReader dt_GotExported_CustIpoAccBalance = syncBal.GetIPO_Customer_IPO_Account_UITransApplied(UpdatedCustList.ToArray());
                //syncBal.DeleteData_SMSSyncExport_Customer_IPO_Account_UITransApplied(UpdatedCustList.ToArray());
                //syncBal.InsertTable_SMSSyncExport_Customer_IPO_Account_UITransApplied(dt_GotExported_CustIpoAccBalance);

                syncBal.Commit_SBP();
                syncBal.Commit_SMS();
            }
            catch (Exception ex)
            {
                syncBal.Rollback_SBP();
                syncBal.Rollback_SMS();
            }
            finally
            {
                syncBal.CloseConnection_SBP();
                syncBal.CloseConnection_SMS();
            }

        }



        private bool IsInputValid()
        {
            if (IsDuplicateCustomerCode())
            {
                MessageBox.Show("Customer Code Allready exist.Please try a different Customer Code.");
                return false;
            }
            else if (IsDuplicateBOID())
            {
                MessageBox.Show("BO Id Allready exist.Please try a different BO Id.");
                return false;
            }
            else
            {
                return true;
            }

        }

        private bool IsDuplicateBOID()
        {
            CustomerInfoBAL cusomerBAL = new CustomerInfoBAL();
            if (cusomerBAL.CheckBOIdDuplicate(txtBoId.Text))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private bool IsDuplicateCustomerCode()
        {
            CustomerInfoBAL customerBAL = new CustomerInfoBAL();
            if (customerBAL.CheckCustomerCodeDuplicate(txtCustomerCode.Text))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void btnResetBasicInfo_Click(object sender, EventArgs e)
        {
            if (_currentMode == GlobalVariableBO.ModeSelection.UpdateMode)
            {
                ClearAll();
                DisableAll();
                txtCustomerCode.Focus();
            }
            else
            {
                ClearAll();
                EnableAll();
                txtCustomerCode.Focus();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rdoSEYes_CheckedChanged(object sender, EventArgs e)
        {
            txtNameAddressSE.Enabled = rdoSEYes.Checked;
        }

        private void txtCustomerCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonBAL commonBal = new CommonBAL();
            commonBal.NumberValidate(txtCustomerCode.Text, e);
        }

        private void txtCustomerParentCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonBAL commonBal = new CommonBAL();
            commonBal.NumberValidate(txtCustomerParentCode.Text, e);

        }

        private void txtBoId_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonBAL commonBal = new CommonBAL();
            commonBal.NumberValidate(txtBoId.Text, e);

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            _currentMode = GlobalVariableBO.ModeSelection.NewMode;
            btnNew.Enabled = false;
            btnNew.BackColor = Color.Gray;
            btnUpdate.Enabled = true;
            btnUpdate.ResetBackColor();
            ClearAll();
            txtCustomerCode.Focus();
            SetPanelVisibleState(PanelVisibleState.PanelBank_BranchCombo);
        }

        private void ClearAll()
        {
            EnableAll();
            txtTIN.Text = "";
            txtTelephone.Text = "";
            txtSpecialInstruction.Text = "";
            txtPostCode.Text = "";
            txtPassportNo.Text = "";
            txtNationality.Text = "";
            txtNationalIdNo.Text = "";
            txtNameAddressSE.Text = "";
            txtMotherName.Text = "";
            txtMobile.Text = "";
            txtIssuePlace.Text = "";
            txtInternalReference.Text = "";
            txtFax.Text = "";
            txtFatherName.Text = "";
            txtEmail.Text = "";
            txtCustomerParentCode.Text = "";
            txtCompanyRegNo.Text = "";
            txtCustomerCode.Text = "";
            txtBranchName.Text = "";
            txtBoId.Text = "";
            txtAddress1.Text = "";
            txtAddress2.Text = "";
            txtAddress3.Text = "";
            txtAccountNo.Text = "";
            txtAccountHolder.Text = "";
            txtDivision.Text = "";
            txtCountry.Text = "";
            txtCity.Text = "";
            txtBankName.Text = "";
            txtAuthorName.Text = "";
            txtAuthorMobile.Text = "";
            txtAuthorAddress.Text = "";
            txtIntroRemarks.Text = "";
            txtIntroName.Text = "";
            txtIntroAddress.Text = "";
            txtIntroBOID.Text = "";
            txtJointHolderPhone.Text = "";
            txtJointHolderNationality.Text = "";
            txtJointHolderNationalID.Text = "";
            txtJointHolderName.Text = "";
            txtJointHolderMother.Text = "";
            txtJointHolderMobile.Text = "";
            txtJointHolderFather.Text = "";
            txtJointHolderEmail.Text = "";
            txtJointHolderAddress.Text = "";
            txtOperatedBy.Text = "";
            ddlOperatedBy.SelectedIndex = 0;
            ddlSatementCycle.SelectedIndex = 0;
            ddlCustomerGroup.SelectedIndex = 0;
            ddlBOType.SelectedIndex = 0;
            ddlBOCategory.SelectedIndex = 0;

            ddlRoutingNo.SelectedIndex = 0;
            ddlJointHolderSex.SelectedIndex = -1;
            //ddlSatementCycle.SelectedIndex = -1;
            ddlResidency.SelectedIndex = -1;
            ddlOccupation.SelectedIndex = -1;
            ddlSex.SelectedIndex = -1;
            ddlAccountType.SelectedIndex = -1;
            //ddlCustomerStatus.SelectedIndex = -1;
            //ddlCustomerGroup.SelectedIndex = -1;
            //ddlBOType.SelectedIndex = -1;
            //ddlBOStatus.SelectedIndex = -1;
            //ddlBOCategory.SelectedIndex = -1;
            //ddlAccountStatus.SelectedIndex = -1;
            txtAccLinkBO.Text = "";
            rdoStandingNo.Checked = true;
            rdoLinkNo.Checked = true;
            rdoTaxExemptionNo.Checked = true;
            rdoSENo.Checked = true;
            rdoEDCNo.Checked = true;
            RDMargin.Checked = false;
            RDCash.Checked = false;

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _currentMode = GlobalVariableBO.ModeSelection.UpdateMode;
            btnUpdate.Enabled = false;
            btnUpdate.BackColor = Color.Gray;
            btnNew.Enabled = false;
            btnNew.ResetBackColor();
            ClearAll();
            DisableAll();             
            txtCustomerCode.Focus();
        }

        private void EnableAll()
        {
            txtTIN.Enabled = true;
            txtTelephone.Enabled = true;
            txtSpecialInstruction.Enabled = true;
            txtPostCode.Enabled = true;
            txtPassportNo.Enabled = true;
            txtNationality.Enabled = true;
            txtNationalIdNo.Enabled = true;
            txtMotherName.Enabled = true;
            txtMobile.Enabled = true;
            txtIssuePlace.Enabled = true;
            txtInternalReference.Enabled = true;
            txtFax.Enabled = true;
            txtFatherName.Enabled = true;
            txtEmail.Enabled = true;
            txtCustomerParentCode.Enabled = true;
            txtCompanyRegNo.Enabled = true;
            txtCustomerCode.Enabled = true;
            txtBranchName.Enabled = true;
            txtBoId.Enabled = true;
            txtAddress1.Enabled = true;
            txtAddress2.Enabled = true;
            txtAddress3.Enabled = true;
            txtAccountNo.Enabled = true;
            txtAccountHolder.Enabled = true;
            ddlSatementCycle.Enabled = true;
            ddlResidency.Enabled = true;
            ddlOccupation.Enabled = true;
            ddlSex.Enabled = true;
            txtDivision.Enabled = true;
            ddlCustomerGroup.Enabled = true;
            txtCountry.Enabled = true;
            txtCity.Enabled = true;
            ddlBOType.Enabled = true;
            ddlBOCategory.Enabled = true;
            txtBankName.Enabled = true;
            ddlAccountType.Enabled = true;
            dtRegDate.Enabled = true;
            dtOpenDate.Enabled = true;
            dtIssueDate.Enabled = true;
            dtExpireDate.Enabled = true;
            dtDOB.Enabled = true;
            dtCustomerOpenDate.Enabled = true;
            rdoTaxExemptionYes.Enabled = true;
            rdoTaxExemptionNo.Enabled = true;
            rdoSEYes.Enabled = true;
            rdoSENo.Enabled = true;
            rdoEDCYes.Enabled = true;
            rdoEDCNo.Enabled = true;
            txtAuthorName.Enabled = true;
            txtAuthorMobile.Enabled = true;
            txtAuthorAddress.Enabled = true;
            txtIntroRemarks.Enabled = true;
            txtIntroName.Enabled = true;
            txtIntroAddress.Enabled = true;
            txtIntroBOID.Enabled = true;
            txtJointHolderPhone.Enabled = true;
            txtJointHolderNationality.Enabled = true;
            txtJointHolderNationalID.Enabled = true;
            txtJointHolderName.Enabled = true;
            txtJointHolderMother.Enabled = true;
            txtJointHolderMobile.Enabled = true;
            txtJointHolderFather.Enabled = true;
            txtJointHolderEmail.Enabled = true;
            txtJointHolderAddress.Enabled = true;
            ddlJointHolderSex.Enabled = true;
            dtJointHolderDOB.Enabled = true;
            txtOperatedBy.Enabled = true;
            ddlOperatedBy.Enabled = true;
            rdoLinkYes.Enabled = true;
            rdoLinkNo.Enabled = true;
            rdoStandingYes.Enabled = true;
            rdoStandingNo.Enabled = true;


        }

        private void DisableAll()
        {
            txtTIN.Enabled = false;
            txtTelephone.Enabled = false;
            txtSpecialInstruction.Enabled = false;
            txtPostCode.Enabled = false;
            txtPassportNo.Enabled = false;
            txtNationality.Enabled = false;
            txtNationalIdNo.Enabled = false;
            txtNameAddressSE.Enabled = false;
            txtMotherName.Enabled = false;
            txtMobile.Enabled = false;
            txtIssuePlace.Enabled = false;
            txtInternalReference.Enabled = false;
            txtFax.Enabled = false;
            txtFatherName.Enabled = false;
            txtEmail.Enabled = false;
            txtCustomerParentCode.Enabled = false;
            txtCompanyRegNo.Enabled = false;
            txtBranchName.Enabled = false;
            txtBoId.Enabled = false;
            txtAddress1.Enabled = false;
            txtAddress2.Enabled = false;
            txtAddress3.Enabled = false;
            txtAccountNo.Enabled = false;
            txtAccountHolder.Enabled = false;
            ddlSatementCycle.Enabled = false;
            ddlResidency.Enabled = false;
            ddlOccupation.Enabled = false;
            ddlSex.Enabled = false;
            txtDivision.Enabled = false;
            ddlCustomerGroup.Enabled = false;
            txtCountry.Enabled = false;
            txtCity.Enabled = false;
            ddlBOType.Enabled = false;
            ddlBOCategory.Enabled = false;
            txtBankName.Enabled = false;
            ddlAccountType.Enabled = false;
            dtRegDate.Enabled = false;
            dtOpenDate.Enabled = false;
            dtIssueDate.Enabled = false;
            dtExpireDate.Enabled = false;
            dtDOB.Enabled = false;
            dtCustomerOpenDate.Enabled = false;
            rdoTaxExemptionYes.Enabled = false;
            rdoTaxExemptionNo.Enabled = false;
            rdoSEYes.Enabled = false;
            rdoSENo.Enabled = false;
            rdoEDCYes.Enabled = false;
            rdoEDCNo.Enabled = false;
            txtAuthorName.Enabled = false;
            txtAuthorMobile.Enabled = false;
            txtAuthorAddress.Enabled = false;
            txtIntroRemarks.Enabled = false;
            txtIntroName.Enabled = false;
            txtIntroAddress.Enabled = false;
            txtIntroBOID.Enabled = false;
            txtJointHolderPhone.Enabled = false;
            txtJointHolderNationality.Enabled = false;
            txtJointHolderNationalID.Enabled = false;
            txtJointHolderName.Enabled = false;
            txtJointHolderMother.Enabled = false;
            txtJointHolderMobile.Enabled = false;
            txtJointHolderFather.Enabled = false;
            txtJointHolderEmail.Enabled = false;
            txtJointHolderAddress.Enabled = false;
            txtOperatedBy.Enabled = false;
            ddlOperatedBy.Enabled = false;
            ddlJointHolderSex.Enabled = false;
            dtJointHolderDOB.Enabled = false;
            rdoLinkYes.Enabled = false;
            rdoLinkNo.Enabled = false;
            rdoStandingYes.Enabled = false;
            rdoStandingNo.Enabled = false;
            txtAccLinkBO.Enabled = false;
        }

        private void SetPreviousDataForLog()
        {
            DataTable previousDataTable = new DataTable();
            CustomerInfoBAL customerInfoBAL = new CustomerInfoBAL();
            Bank_Branch_ComboBAL objBAL = new Bank_Branch_ComboBAL();
            string routingNo = "";
            if (!String.IsNullOrEmpty(txtCustomerCode.Text.Trim()))
                previousDataTable = customerInfoBAL.GetAllDataForLog(txtCustomerCode.Text);
            if (previousDataTable.Rows.Count > 0)
            {
                _custModLogBo = new CustomerModificationLogBO();
                _custModLogBo.CustCode = previousDataTable.Rows[0]["Cust_Code"].ToString();
                _custModLogBo.CustGroup = previousDataTable.Rows[0]["Cust_Group"].ToString();
                _custModLogBo.BoStatus = previousDataTable.Rows[0]["BO_Status_ID"].ToString();
                _custModLogBo.SpecialInstruction = previousDataTable.Rows[0]["Special_Remarks"].ToString();
                if (previousDataTable.Rows[0]["Cust_Open_Date"] != DBNull.Value)
                    _custModLogBo.CustomerOpenDate = Convert.ToDateTime(previousDataTable.Rows[0]["Cust_Open_Date"]);
                if (previousDataTable.Rows[0]["Cust_Close_Date"] != DBNull.Value)
                    _custModLogBo.CustomerCloseDate = Convert.ToDateTime(previousDataTable.Rows[0]["Cust_Close_Date"]);
                _custModLogBo.CustStatus = previousDataTable.Rows[0]["Cust_Status"].ToString();
                if (previousDataTable.Rows[0]["Parent_Cust_Code"] != DBNull.Value)
                    _custModLogBo.CustParentCode = Convert.ToInt32(previousDataTable.Rows[0]["Parent_Cust_Code"]);
                _custModLogBo.BoId = previousDataTable.Rows[0]["BO_ID"].ToString();
                _custModLogBo.BoCategory = previousDataTable.Rows[0]["BO_Category"].ToString();
                _custModLogBo.BoType = previousDataTable.Rows[0]["BO_Type"].ToString();
                if (previousDataTable.Rows[0]["BO_Open_Date"] != DBNull.Value)
                    _custModLogBo.BoOpenDate = Convert.ToDateTime(previousDataTable.Rows[0]["BO_Open_Date"]);
                if (previousDataTable.Rows[0]["Is_Officer_Director_SE"] != DBNull.Value)
                    _custModLogBo.IsDirSe = Convert.ToInt32(previousDataTable.Rows[0]["Is_Officer_Director_SE"]);
                _custModLogBo.NameAddressSe = previousDataTable.Rows[0]["SE_Name_Address"].ToString();
                _custModLogBo.AccountHolder = previousDataTable.Rows[0]["Cust_Name"].ToString();
                _custModLogBo.FatherName = previousDataTable.Rows[0]["Father_Name"].ToString();
                _custModLogBo.MotherName = previousDataTable.Rows[0]["Mother_Name"].ToString();
                if (previousDataTable.Rows[0]["DOB"] != DBNull.Value)
                    _custModLogBo.DOb = Convert.ToDateTime(previousDataTable.Rows[0]["DOB"]);
                _custModLogBo.Gender = previousDataTable.Rows[0]["Gender"].ToString();
                _custModLogBo.Occupation = previousDataTable.Rows[0]["Occupation"].ToString();
                _custModLogBo.NationalId = previousDataTable.Rows[0]["National_ID"].ToString();
                _custModLogBo.Address1 = previousDataTable.Rows[0]["Address1"].ToString();
                _custModLogBo.Address2 = previousDataTable.Rows[0]["Address2"].ToString();
                _custModLogBo.Address3 = previousDataTable.Rows[0]["Address3"].ToString();
                _custModLogBo.CityName = previousDataTable.Rows[0]["City_Name"].ToString();
                _custModLogBo.PostCode = previousDataTable.Rows[0]["Post_Code"].ToString();
                _custModLogBo.DivisionName = previousDataTable.Rows[0]["Division_Name"].ToString();
                _custModLogBo.CountryName = previousDataTable.Rows[0]["Country_Name"].ToString();
                _custModLogBo.Telephone = previousDataTable.Rows[0]["Phone"].ToString();
                _custModLogBo.Mobile = previousDataTable.Rows[0]["Mobile"].ToString();
                _custModLogBo.Fax = previousDataTable.Rows[0]["Fax"].ToString();
                _custModLogBo.Email = previousDataTable.Rows[0]["Email"].ToString();
                _custModLogBo.Residency = previousDataTable.Rows[0]["Recidency"].ToString();
                _custModLogBo.Nationality = previousDataTable.Rows[0]["Nationality"].ToString();
                _custModLogBo.StatementCycle = previousDataTable.Rows[0]["Statement_Cycle"].ToString();
                _custModLogBo.InternalRefNo = previousDataTable.Rows[0]["Internal_Ref_No"].ToString();
                _custModLogBo.CompanyRegNo = previousDataTable.Rows[0]["Comp_Reg_No"].ToString();
                if (previousDataTable.Rows[0]["Comp_Reg_Date"] != DBNull.Value)
                    _custModLogBo.CompanyRegDate = Convert.ToDateTime(previousDataTable.Rows[0]["Comp_Reg_Date"]);
                _custModLogBo.AccLinkBo = previousDataTable.Rows[0]["Acc_Link_BO_ID"].ToString();
                if (previousDataTable.Rows[0]["Acc_Link_Request"] != DBNull.Value)
                    _custModLogBo.IsAccLinkRequest = Convert.ToInt32(previousDataTable.Rows[0]["Acc_Link_Request"]);
                if (previousDataTable.Rows[0]["Standing_Ins"] != DBNull.Value)
                    _custModLogBo.IsStandingIns = Convert.ToInt32(previousDataTable.Rows[0]["Standing_Ins"]);

                _custModLogBo.BankName = previousDataTable.Rows[0]["Bank_Name"].ToString();
                _custModLogBo.BranchName = previousDataTable.Rows[0]["Branch_Name"].ToString();
                _custModLogBo.IBAN = previousDataTable.Rows[0]["IBAN"].ToString();
                _custModLogBo.SWIFT_Code = previousDataTable.Rows[0]["SWIFT_Code"].ToString();
                _custModLogBo.Routing_No = previousDataTable.Rows[0]["Routing_No"].ToString();
                _custModLogBo.District_Name = previousDataTable.Rows[0]["District_Name"].ToString();

                _custModLogBo.AccountNo = previousDataTable.Rows[0]["Account_No"].ToString();
                _custModLogBo.AccountType = previousDataTable.Rows[0]["Account_Type"].ToString();
                if (previousDataTable.Rows[0]["Is_EDC"] != DBNull.Value)
                    _custModLogBo.IsEdc = Convert.ToInt32(previousDataTable.Rows[0]["Is_EDC"]);
                if (previousDataTable.Rows[0]["Is_Tax_Exemption"] != DBNull.Value)
                    _custModLogBo.IsTaxExemption = Convert.ToInt32(previousDataTable.Rows[0]["Is_Tax_Exemption"]);
                _custModLogBo.Tin = previousDataTable.Rows[0]["TIN"].ToString();
                _custModLogBo.PassportNo = previousDataTable.Rows[0]["Passport_No"].ToString();
                _custModLogBo.IssuePlace = previousDataTable.Rows[0]["Issue_Place"].ToString();
                if (previousDataTable.Rows[0]["Issue_Date"] != DBNull.Value)
                    _custModLogBo.IssueDate = Convert.ToDateTime(previousDataTable.Rows[0]["Issue_Date"]);
                if (previousDataTable.Rows[0]["Expire_Date"] != DBNull.Value)
                    _custModLogBo.ExpireDate = Convert.ToDateTime(previousDataTable.Rows[0]["Expire_Date"]);
                _custModLogBo.JointName = previousDataTable.Rows[0]["Joint_Name"].ToString();
                _custModLogBo.JointFatherName = previousDataTable.Rows[0]["Joint_Father_Name"].ToString();
                _custModLogBo.JointMotherName = previousDataTable.Rows[0]["Joint_Mother_Name"].ToString();
                if (previousDataTable.Rows[0]["Joint_DOB"] != DBNull.Value)
                    _custModLogBo.JointDob = Convert.ToDateTime(previousDataTable.Rows[0]["Joint_DOB"]);
                _custModLogBo.JointSex = previousDataTable.Rows[0]["Joint_Gender"].ToString();
                _custModLogBo.JointNationality = previousDataTable.Rows[0]["Joint_Nationality"].ToString();
                _custModLogBo.JointNationalId = previousDataTable.Rows[0]["National_ID"].ToString();
                _custModLogBo.JointAddress = previousDataTable.Rows[0]["Joint_Address"].ToString();
                _custModLogBo.JoitnPhone = previousDataTable.Rows[0]["Joint_Phone"].ToString();
                _custModLogBo.JointMobile = previousDataTable.Rows[0]["Joint_Mobile"].ToString();
                _custModLogBo.JointEmail = previousDataTable.Rows[0]["Joint_Email"].ToString();
                _custModLogBo.AuthorName = previousDataTable.Rows[0]["Author_Name"].ToString();
                _custModLogBo.AuthorAddress = previousDataTable.Rows[0]["Author_Address"].ToString();
                _custModLogBo.AuthorMobile = previousDataTable.Rows[0]["Author_Mobile"].ToString();
                _custModLogBo.IntroName = previousDataTable.Rows[0]["Intro_Name"].ToString();
                _custModLogBo.IntroAddress = previousDataTable.Rows[0]["Intro_Address"].ToString();
                _custModLogBo.IntroBOID = previousDataTable.Rows[0]["Intro_BO_ID"].ToString();
                _custModLogBo.IntroRemarks = previousDataTable.Rows[0]["Remarks"].ToString();
                _custModLogBo.OperatedBy = previousDataTable.Rows[0]["Operation_Ins"].ToString();
            }

        }

        private void LoadDataFromDataTable()
        {
            DataTable userinfoDataTable = new DataTable();
            CustomerInfoBAL customerInfoBAL = new CustomerInfoBAL();
            //int IntTryParse;
            if (!String.IsNullOrEmpty(txtCustomerCode.Text.Trim()))
                userinfoDataTable = customerInfoBAL.GetAllData(txtCustomerCode.Text);
            if (userinfoDataTable.Rows.Count > 0)
            {
                txtCustomerCode.Text = userinfoDataTable.Rows[0]["Cust_Code"].ToString();
                ddlCustomerGroup.SelectedValue = userinfoDataTable.Rows[0]["Cust_Group_ID"];
                cmdBoStatus.SelectedValue = userinfoDataTable.Rows[0]["BO_Status_ID"];
                if (userinfoDataTable.Rows[0]["Cust_Open_Date"] != DBNull.Value)
                    dtCustomerOpenDate.Value = Convert.ToDateTime(userinfoDataTable.Rows[0]["Cust_Open_Date"]);
                txtCustomerParentCode.Text = userinfoDataTable.Rows[0]["Parent_Cust_Code"].ToString();
                txtSpecialInstruction.Text = userinfoDataTable.Rows[0]["Special_Remarks"].ToString();
                txtBoId.Text = userinfoDataTable.Rows[0]["BO_ID"].ToString();
                ddlBOType.SelectedValue = userinfoDataTable.Rows[0]["BO_Type_ID"];
                ddlBOCategory.SelectedValue = userinfoDataTable.Rows[0]["BO_Category_ID"];
                if (userinfoDataTable.Rows[0]["BO_Open_Date"] != DBNull.Value)
                    dtOpenDate.Value = Convert.ToDateTime(userinfoDataTable.Rows[0]["BO_Open_Date"]);
                int SE = 0;
                if (userinfoDataTable.Rows[0]["Is_Officer_Director_SE"] != DBNull.Value)
                    SE = Convert.ToInt16(userinfoDataTable.Rows[0]["Is_Officer_Director_SE"]);
                if (SE == 1)
                {
                    rdoSEYes.Checked = true;
                    txtNameAddressSE.Text = userinfoDataTable.Rows[0]["SE_Name_Address"].ToString();
                }
                else
                {
                    rdoSENo.Checked = true;
                    txtNameAddressSE.Text = "";
                }
                txtAccountHolder.Text = userinfoDataTable.Rows[0]["Cust_Name"].ToString();
                txtNationalIdNo.Text = userinfoDataTable.Rows[0]["National_ID"].ToString();
                txtFatherName.Text = userinfoDataTable.Rows[0]["Father_Name"].ToString();
                txtMotherName.Text = userinfoDataTable.Rows[0]["Mother_Name"].ToString();
                ddlOccupation.SelectedItem = userinfoDataTable.Rows[0]["Occupation"].ToString();
                if (userinfoDataTable.Rows[0]["DOB"] != DBNull.Value)
                    dtDOB.Value = Convert.ToDateTime(userinfoDataTable.Rows[0]["DOB"]);
                ddlSex.SelectedItem = userinfoDataTable.Rows[0]["Gender"].ToString();
                txtCountry.Text = userinfoDataTable.Rows[0]["Country_Name"].ToString();
                txtDivision.Text = userinfoDataTable.Rows[0]["Division_Name"].ToString();
                txtCity.Text = userinfoDataTable.Rows[0]["City_Name"].ToString();
                txtPostCode.Text = userinfoDataTable.Rows[0]["Post_Code"].ToString();
                txtEmail.Text = userinfoDataTable.Rows[0]["Email"].ToString();
                txtAddress1.Text = userinfoDataTable.Rows[0]["Address1"].ToString();
                txtAddress2.Text = userinfoDataTable.Rows[0]["Address2"].ToString();
                txtAddress3.Text = userinfoDataTable.Rows[0]["Address3"].ToString();
                txtTelephone.Text = userinfoDataTable.Rows[0]["Phone"].ToString();
                txtMobile.Text = userinfoDataTable.Rows[0]["Mobile"].ToString();
                txtFax.Text = userinfoDataTable.Rows[0]["Fax"].ToString();
                ddlResidency.SelectedItem = userinfoDataTable.Rows[0]["Recidency"].ToString();
                cmbNetAdjustment.Text = userinfoDataTable.Rows[0]["Net_Adjustment"].ToString();
                cmbworkstationName.Text = userinfoDataTable.Rows[0]["Assigned_WorkStation"].ToString();
                txtNationality.Text = userinfoDataTable.Rows[0]["Nationality"].ToString();
                ddlSatementCycle.SelectedValue = userinfoDataTable.Rows[0]["Statement_Cycle_ID"];
                txtInternalReference.Text = userinfoDataTable.Rows[0]["Internal_Ref_No"].ToString();
                txtCompanyRegNo.Text = userinfoDataTable.Rows[0]["Comp_Reg_No"].ToString();
                if (userinfoDataTable.Rows[0]["Comp_Reg_Date"] != DBNull.Value)
                    dtRegDate.Value = Convert.ToDateTime(userinfoDataTable.Rows[0]["Comp_Reg_Date"]);
                if (userinfoDataTable.Rows[0]["Acc_Link_Request"] != DBNull.Value)
                    if (Convert.ToInt16(userinfoDataTable.Rows[0]["Acc_Link_Request"]) == 1)
                    {
                        rdoLinkYes.Checked = true;
                        txtAccLinkBO.Text = userinfoDataTable.Rows[0]["Acc_Link_BO_ID"].ToString();
                    }
                    else
                    {
                        rdoLinkNo.Checked = true;
                        txtAccLinkBO.Text = "";
                    }

                if (userinfoDataTable.Rows[0]["Standing_Ins"] != DBNull.Value)
                    if (Convert.ToInt16(userinfoDataTable.Rows[0]["Standing_Ins"]) == 1)
                    {
                        rdoStandingYes.Checked = true;
                    }
                    else
                    {
                        rdoStandingYes.Checked = true;
                    }
                
                //Bank Info
                ddlRoutingNo.SelectedValue = userinfoDataTable.Rows[0]["Routing_No"].ToString();
                if (userinfoDataTable.Rows[0]["Bank_ID"].ToString() != "")
                {
                    //int valueTemp = -1;
                    //IntTryParse = -1;
                    //if (int.TryParse(userinfoDataTable.Rows[0]["Bank_ID"].ToString(), out IntTryParse))
                    //    valueTemp = IntTryParse;
                    //ddlBankName.SelectedValue = valueTemp;

                    ddlBankName.SelectedValue = Convert.ToInt32(userinfoDataTable.Rows[0]["Bank_ID"].ToString());
                    SetPanelVisibleState(PanelVisibleState.PanelBankCombo);
                }
                else
                {
                    SetPanelVisibleState(PanelVisibleState.PanelBankTextBox);
                    txtBankName.Text = userinfoDataTable.Rows[0]["Bank_Name"].ToString();
                }
                if (userinfoDataTable.Rows[0]["Branch_ID"].ToString() != "")
                {
                    //int valueTemp = -1;
                    //IntTryParse = -1;
                    //if (int.TryParse(userinfoDataTable.Rows[0]["Branch_ID"].ToString(), out IntTryParse))
                    //    valueTemp = IntTryParse;

                    //ddlBranchName.SelectedValue = valueTemp;
                    ddlBranchName.SelectedValue = Convert.ToInt32(userinfoDataTable.Rows[0]["Branch_ID"].ToString());
                    SetPanelVisibleState(PanelVisibleState.PanelBranchCombo);
                }
                else
                {
                    SetPanelVisibleState(PanelVisibleState.PanelBranchTextBox);
                    txtBranchName.Text = userinfoDataTable.Rows[0]["Branch_Name"].ToString();
                }
                txtAccountNo.Text = userinfoDataTable.Rows[0]["Account_No"].ToString();
                ddlAccountType.SelectedItem = userinfoDataTable.Rows[0]["Account_Type"].ToString() == "" ? Indication_AccountType.SavingsAccount : userinfoDataTable.Rows[0]["Account_Type"].ToString();
                int EDC = 0;
                if (userinfoDataTable.Rows[0]["Is_EDC"] != DBNull.Value)
                    EDC = Convert.ToInt16(userinfoDataTable.Rows[0]["Is_EDC"]);
                if (EDC == 1)
                {
                    rdoEDCYes.Checked = true;
                }
                else
                {
                    rdoEDCNo.Checked = true;
                }
                int TaxExemption = 0;
                if (userinfoDataTable.Rows[0]["Is_Tax_Exemption"] != DBNull.Value)
                    TaxExemption = Convert.ToInt16(userinfoDataTable.Rows[0]["Is_Tax_Exemption"]);
                if (TaxExemption == 1)
                {
                    rdoTaxExemptionYes.Checked = true;
                }
                else
                {
                    rdoTaxExemptionNo.Checked = true;
                }
                txtTIN.Text = userinfoDataTable.Rows[0]["TIN"].ToString();
                txtSWIFTCode.Text = userinfoDataTable.Rows[0]["SWIFT_Code"].ToString();
                txtIBAN.Text = userinfoDataTable.Rows[0]["IBAN"].ToString();
                
                txtDistrictName.Text = userinfoDataTable.Rows[0]["District_Name"].ToString();
                txtPassportNo.Text = userinfoDataTable.Rows[0]["Passport_No"].ToString();
                txtIssuePlace.Text = userinfoDataTable.Rows[0]["Issue_Place"].ToString();
                if (userinfoDataTable.Rows[0]["Issue_Date"] != DBNull.Value)
                    dtIssueDate.Value = Convert.ToDateTime(userinfoDataTable.Rows[0]["Issue_Date"]);
                if (userinfoDataTable.Rows[0]["Expire_Date"] != DBNull.Value)
                    dtExpireDate.Value = Convert.ToDateTime(userinfoDataTable.Rows[0]["Expire_Date"]);
                txtJointHolderName.Text = userinfoDataTable.Rows[0]["Joint_Name"].ToString();
                txtJointHolderFather.Text = userinfoDataTable.Rows[0]["Joint_Father_Name"].ToString();
                txtJointHolderMother.Text = userinfoDataTable.Rows[0]["Joint_Mother_Name"].ToString();
                if (userinfoDataTable.Rows[0]["Joint_DOB"] != DBNull.Value)
                    dtJointHolderDOB.Value = Convert.ToDateTime(userinfoDataTable.Rows[0]["Joint_DOB"]);
                ddlJointHolderSex.SelectedItem = userinfoDataTable.Rows[0]["Joint_Gender"].ToString();
                txtJointHolderNationality.Text = userinfoDataTable.Rows[0]["Joint_Nationality"].ToString();
                txtJointHolderNationalID.Text = userinfoDataTable.Rows[0]["Joint_National_ID"].ToString();
                txtJointHolderAddress.Text = userinfoDataTable.Rows[0]["Joint_Address"].ToString();
                txtJointHolderPhone.Text = userinfoDataTable.Rows[0]["Joint_Phone"].ToString();
                txtJointHolderMobile.Text = userinfoDataTable.Rows[0]["Joint_Mobile"].ToString();
                txtJointHolderEmail.Text = userinfoDataTable.Rows[0]["Joint_Email"].ToString();
                string operatedBy = userinfoDataTable.Rows[0]["Operation_Ins"].ToString();
                if (operatedBy == "Either or Survivor" || operatedBy == "Any one" || operatedBy == "Any two jointly")
                {
                    ddlOperatedBy.SelectedItem = userinfoDataTable.Rows[0]["Operation_Ins"].ToString();
                    txtOperatedBy.Enabled = false;
                }
                else
                {
                    ddlOperatedBy.SelectedItem = "Others";
                    txtOperatedBy.Enabled = true;
                    txtOperatedBy.Text = userinfoDataTable.Rows[0]["Operation_Ins"].ToString();
                }
                txtAuthorName.Text = userinfoDataTable.Rows[0]["Author_Name"].ToString();
                txtAuthorAddress.Text = userinfoDataTable.Rows[0]["Author_Address"].ToString();
                txtAuthorMobile.Text = userinfoDataTable.Rows[0]["Author_Mobile"].ToString();
                txtIntroName.Text = userinfoDataTable.Rows[0]["Intro_Name"].ToString();
                txtIntroAddress.Text = userinfoDataTable.Rows[0]["Intro_Address"].ToString();
                txtIntroBOID.Text = userinfoDataTable.Rows[0]["Intro_BO_ID"].ToString();
                txtIntroRemarks.Text = userinfoDataTable.Rows[0]["Remarks"].ToString();
                //Add By Rashedul Hasan 25 August 2015
                if (userinfoDataTable.Rows[0]["Cust_Trans_Status_ID"] != DBNull.Value)
                {
                    if (Convert.ToInt32(userinfoDataTable.Rows[0]["Cust_Trans_Status_ID"].ToString()) == Indication_AccountType.Cash_ID)
                    {
                        RDCash.Checked = true;
                    }
                    if (Convert.ToInt32(userinfoDataTable.Rows[0]["Cust_Trans_Status_ID"].ToString()) == Indication_AccountType.Margin_ID)
                    {
                        RDMargin.Checked = true;
                    }
                }
                /////
            }
            else
            {
                btnUpdate.Enabled = false;
                btnUpdate.BackColor = Color.Gray;
                btnNew.Enabled = false;
                btnNew.ResetBackColor();
                ClearAll();
                DisableAll();
                MessageBox.Show("Customer code does not exist.");

            }
        }


        //private void SetBank(string bankName)
        //{
        //    if (bankName != "")
        //    {
        //        if (ddlBankName.Items.Cast<System.Data.DataRowView>().ToList().Exists(t => t.Row[ddlBankName.DisplayMember].ToString() == bankName))
        //        {
        //            ddlBankName.Text = bankName;
        //            SetPanelVisibleState(PanelVisibleState.PanelBankCombo);
        //        }
        //        else
        //        {
        //            ddlBankName.SelectedIndex = -1;
        //            SetPanelVisibleState(PanelVisibleState.PanelBankTextBox);
        //            txtBankName.Text = bankName;

        //        }
        //    }
        //}

        //private void SetBranch(string branchName)
        //{
        //    if (branchName != "")
        //    {
        //        if (ddlBranchName.Items.Cast<System.Data.DataRowView>().ToList().Exists(t => t.Row[ddlBranchName.DisplayMember].ToString() == branchName))
        //        {
        //            ddlBranchName.Text = branchName;
        //            SetPanelVisibleState(PanelVisibleState.PanelBranchCombo);
        //        }
        //        else
        //        {
        //            ddlBranchName.SelectedIndex = -1;
        //            SetPanelVisibleState(PanelVisibleState.PanelBranchTextBox);
        //            txtBranchName.Text = branchName;

        //        }
        //    }
        //}

        private void ddlSpecialIns_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtOperatedBy.Text = "";
            txtOperatedBy.Enabled = ddlOperatedBy.SelectedItem.ToString() == "Others";
        }

        private void rdoLinkYes_CheckedChanged_1(object sender, EventArgs e)
        {
            txtAccLinkBO.Enabled = rdoLinkYes.Checked;
        }

        private void rdoLinkNo_CheckedChanged_1(object sender, EventArgs e)
        {
            txtAccLinkBO.Enabled = rdoLinkYes.Checked;
        }

        private void btnNextInfoEntry_Click(object sender, EventArgs e)
        {
            if (txtCustomerCode.Text.Trim() != "")
            {
                _customerCode = txtCustomerCode.Text;
                NominationForm nominationForm = new NominationForm();
                nominationForm.Show();
                nominationForm.ddlSearchCustomer.SelectedIndex = 0;
                nominationForm.txtSearchCustomer.Text = _customerCode.ToString();
                DataTable custDataTable = new DataTable();
                CustomerInfoBAL custInfoBal = new CustomerInfoBAL();
                custDataTable = custInfoBal.GetCustInfoByCustCode(_customerCode);

                if (custDataTable.Rows.Count > 0)
                {
                    nominationForm.txtCustCode.Text = custDataTable.Rows[0][0].ToString();
                    nominationForm.txtAccountHolderName.Text = custDataTable.Rows[0][1].ToString();
                    nominationForm.txtAccountHolderBOId.Text = custDataTable.Rows[0][2].ToString();
                }
            }
            else
            {
                MessageBox.Show("Entry the Customer Code.");
            }
        }

        private void txtCustomerCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "Return")
            {
                LoadSelectedInformation();
            }

        }

        private void txtCustomerCode_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "Return")
            {
                LoadSelectedInformation();
            }
        }

        private void LoadSelectedInformation()
        {
            if (_currentMode == GlobalVariableBO.ModeSelection.UpdateMode)
            {
                EnableAll();
                txtCustomerCode.Enabled = false;
                SetPreviousDataForLog();
                LoadDataFromDataTable();

            }
        }

        private void ddlBOType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlBOType.SelectedIndex == 1)
            {
                tabControl1.TabPages.Add(tabPageJointHolder);
            }
            else
            {
                tabControl1.TabPages.Remove(tabPageJointHolder);
            }

        }

        private void rdoSEYes_CheckedChanged_1(object sender, EventArgs e)
        {
            txtNameAddressSE.Enabled = rdoSEYes.Checked;
        }

        private void tabPageBankInfo_Click(object sender, EventArgs e)
        {
            ddlRoutingNo.SelectedIndex = 0;
        }

        private void txtBankName_KeyPress(object sender, KeyPressEventArgs e)
        {
            //ddlBankName_KeyPress(sender, e);
            try
            {
                if (Char.IsLetterOrDigit(e.KeyChar) || Char.IsPunctuation(e.KeyChar))
                {
                    //ddlBankName.SelectedIndex = ddlBankName.FindString(e.KeyChar.ToString());
                    //ddlBankName.Focus();
                    SetPanelVisibleState(PanelVisibleState.PanelBankCombo);
                    ddlBankName.Focus();
                }
            }
            catch
            {
            }

        }

        private void ddlBankName_KeyPress(object sender, KeyPressEventArgs e)
        {
            //try
            //{
            //    if (Char.IsLetterOrDigit(e.KeyChar) || Char.IsPunctuation(e.KeyChar))
            //    {
            //        ddlBankName.SelectedIndex = ddlBankName.FindString(e.KeyChar.ToString());
            //        //ddlBankName.Focus();
            //        SetPanelVisibleState(PanelVisibleState.PanelBankCombo);
            //        ddlBankName.Focus();
            //    }
            //}
            //catch
            //{
            //}
        }

        private void txtBranchName_KeyPress(object sender, KeyPressEventArgs e)
        {
            //ddlBranchName_KeyPress(sender, e);
            try
            {
                if (Char.IsLetterOrDigit(e.KeyChar) || Char.IsPunctuation(e.KeyChar))
                {
                    //ddlBranchName.SelectedIndex = ddlBranchName.FindString(e.KeyChar.ToString());
                    //ddlBranchName.Focus();
                    SetPanelVisibleState(PanelVisibleState.PanelBranchCombo);
                    ddlBranchName.Focus();
                }
            }
            catch
            {
            }

        }

        private void ddlBranchName_KeyPress(object sender, KeyPressEventArgs e)
        {
            //try
            //{
            //    if (Char.IsLetterOrDigit(e.KeyChar) || Char.IsPunctuation(e.KeyChar))
            //    {
            //        ddlBranchName.SelectedIndex = ddlBranchName.FindString(e.KeyChar.ToString());
            //        //ddlBranchName.Focus();
            //        SetPanelVisibleState(PanelVisibleState.PanelBranchCombo);
            //        ddlBranchName.Focus();
            //    }
            //}
            //catch
            //{
            //}
        }



        private void txtBankName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                if (ddlBankName.Items.Count > 0)
                    ddlBankName.SelectedIndex = -1;
                //ddlBranchName.Focus();
                SetPanelVisibleState(PanelVisibleState.PanelBankCombo);
                ddlBankName.Focus();
            }
        }
        private void txtBranchName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                if (ddlBankName.Items.Count > 0)
                    ddlBranchName.SelectedIndex = -1;
                //ddlBranchName.Focus();
                SetPanelVisibleState(PanelVisibleState.PanelBranchCombo);
                ddlBranchName.Focus();
            }
        }

        private void LoadBranchInfoByBankId(int bankId)
        {
            var dtbranch = (custInfoEntryCache.Where(t => t.Key == bank_branch_routing)
                           .Select(t => t.Value).SingleOrDefault() as DataTable).AsEnumerable().Where(t => Convert.ToInt32(t["Bank_ID"]) == bankId)
                           .Select(t => new { Value = t["Branch_Name"] + "(" + t["Routing_No"] + ")", Key = Convert.ToInt32(t["Branch_ID"]) }).ToList();

            var bankCode = (custInfoEntryCache.Where(t => t.Key == bank_branch_routing)
                        .Select(t => t.Value).SingleOrDefault() as DataTable).AsEnumerable()
                        .Where(t => Convert.ToInt32(t["Bank_ID"].ToString()) == bankId)
                        .Select(t => t["Bank_Code"]).FirstOrDefault();

            var districtName = (custInfoEntryCache.Where(t => t.Key == bank_branch_routing)
                    .Select(t => t.Value).SingleOrDefault() as DataTable).AsEnumerable()
                    .Where(t => Convert.ToInt32(t["Bank_ID"].ToString()) == bankId)
                    .Select(t => t["District_Name"]).FirstOrDefault();

            var MaxLen = dtbranch.Select(t => t.Value.Length).Max();

            ddlBranchName.DataSource = dtbranch;
            ddlBranchName.ValueMember = "Key";
            ddlBranchName.DisplayMember = "Value";
            ddlBranchName.DropDownWidth = MaxLen * 7;
            ddlBranchName.SelectedIndex = 0;

            txtBankCode.Text = bankCode.ToString();
            txtDistrictName.Text = districtName.ToString();

        }
        private void LoadBankInfoByRoutingNo(string routingNo)
        {
            var BankID = (custInfoEntryCache.Where(t => t.Key == bank_branch_routing)
                        .Select(t => t.Value).SingleOrDefault() as DataTable).AsEnumerable()
                        .Where(t => t["Routing_No"].ToString() == routingNo)
                        .Select(t => t["Bank_ID"]).FirstOrDefault();

            var BranchID = (custInfoEntryCache.Where(t => t.Key == bank_branch_routing)
                        .Select(t => t.Value).SingleOrDefault() as DataTable).AsEnumerable()
                        .Where(t => t["Routing_No"].ToString() == routingNo)
                        .Select(t => t["Branch_ID"]).FirstOrDefault();

            var bankCode = (custInfoEntryCache.Where(t => t.Key == bank_branch_routing)
                        .Select(t => t.Value).SingleOrDefault() as DataTable).AsEnumerable()
                        .Where(t => t["Routing_No"].ToString() == routingNo)
                        .Select(t => t["Bank_Code"]).FirstOrDefault();

            var districtName = (custInfoEntryCache.Where(t => t.Key == bank_branch_routing)
                        .Select(t => t.Value).SingleOrDefault() as DataTable).AsEnumerable()
                        .Where(t => t["Routing_No"].ToString() == routingNo)
                        .Select(t => t["District_Name"]).FirstOrDefault();

            if (BankID != null || BranchID != null)
            {
                ddlBankName.SelectedValue = BankID;
                ddlBranchName.SelectedValue = BranchID;
            }
            txtBankCode.Text = bankCode.ToString();
            txtDistrictName.Text = districtName.ToString();
        }
        private void LoadRoutingNoByBankId(int bankId)
        {
            var routingNo = (custInfoEntryCache.Where(t => t.Key == bank_branch_routing)
                        .Select(t => t.Value).SingleOrDefault() as DataTable).AsEnumerable()
                        .Where(t => Convert.ToInt32(t["Bank_ID"].ToString()) == bankId)
                        .Select(t => t["Routing_No"]).FirstOrDefault();
            ddlRoutingNo.SelectedValue = routingNo;
        }
        private void ddlBankName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int index = Convert.ToInt32(ddlBankName.SelectedValue.ToString());
                //  LoadRoutingNoByBankId(index);
                LoadBranchInfoByBankId(index);
            }
            catch
            {
            }
        }

        private void ddlBankName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                int index = Convert.ToInt32(ddlBankName.SelectedValue.ToString());
                LoadRoutingNoByBankId(index);
                LoadBranchInfoByBankId(index);
            }
            catch
            {
            }
        }

        private void ddlBankName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (ddlBankName.DroppedDown)
                {
                    ddlBankName.DroppedDown = false;
                }
            }
        }

        private void ddlBankName_DropDown(object sender, EventArgs e)
        {
            ddlBankName.AutoCompleteMode = AutoCompleteMode.None;
        }

        private void ddlBankName_DropDownClosed(object sender, EventArgs e)
        {
            ddlBankName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }

        private void ddlBranchName_DropDown(object sender, EventArgs e)
        {
            ddlBranchName.AutoCompleteMode = AutoCompleteMode.None;
        }

        private void ddlBranchName_DropDownClosed(object sender, EventArgs e)
        {
            ddlBranchName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }

        private void ddlBranchName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (ddlBranchName.DroppedDown)
                {
                    ddlBranchName.DroppedDown = false;
                }
            }
        }

        private void ddlRoutingNo_DropDown(object sender, EventArgs e)
        {
            ddlRoutingNo.AutoCompleteMode = AutoCompleteMode.None;
        }

        private void ddlRoutingNo_DropDownClosed(object sender, EventArgs e)
        {
            ddlRoutingNo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }

        private void ddlRoutingNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (ddlRoutingNo.DroppedDown)
                {
                    ddlRoutingNo.DroppedDown = false;
                }
               
                txtAccountNo.Focus();
            }            
        }

        private void ddlRoutingNo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (ddlRoutingNo.DroppedDown)
                {
                    ddlRoutingNo.DroppedDown = false;
                }

                txtAccountNo.Focus();
            }
        }

        private void ddlRoutingNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string routingNo = ddlRoutingNo.SelectedValue.ToString();
                LoadBankInfoByRoutingNo(routingNo);
                SetPanelVisibleState(PanelVisibleState.PanelBankCombo);
                SetPanelVisibleState(PanelVisibleState.PanelBranchCombo);
            }
            catch
            {
            }
        }
        private void LoadRoutingNoByBranchId(int branchId)
        {
            //var routingNo = (custInfoEntryCache.Where(t => t.Key == bank_branch_routing)
            //                .Select(t => t.Value).SingleOrDefault() as DataTable).AsEnumerable()
            //                .Where(t => Convert.ToInt32(t["Branch_ID"]) == branchId)
            //                .Select(t => t["Routing_No"]).FirstOrDefault();

            //ddlRoutingNo.SelectedValue = routingNo;

        }
        private void ddlRoutingNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                string routingNo = ddlRoutingNo.SelectedValue.ToString();
                LoadBankInfoByRoutingNo(routingNo);
                SetPanelVisibleState(PanelVisibleState.PanelBankCombo);
                SetPanelVisibleState(PanelVisibleState.PanelBranchCombo);
            }
            catch
            {
            
            }
        }

        private void ddlBranchName_SelectedIndexChanged(object sender, EventArgs e)
        {
            int branchId = 0;
            try
            {
                branchId = Convert.ToInt32(ddlBranchName.SelectedValue.ToString());
                LoadRoutingNoByBranchId(branchId);
            }
            catch
            {

            }
        }

        private void ddlBranchName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int branchId = 0;
            try
            {
                branchId = Convert.ToInt32(ddlBranchName.SelectedValue.ToString());
                LoadRoutingNoByBranchId(branchId);
            }
            catch
            {

            }
        }

        private void txtAccountNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSaveBasicInfo.Focus();
            }
        }

        private void txtAccountNo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSaveBasicInfo.Focus();
            }
        }

        #region Search
        private DataTable Final_Data = new DataTable();
        private int K = 0;
        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataTable data = new DataTable();
            CustomerInfoBAL objBal = new CustomerInfoBAL();
            data = objBal.Flex_Tp_Cash_Limit_Cust_Searching(this.txtSearchCustCode.Text.Trim());
            List<DataRow> Validation = Final_Data.Rows.Cast<DataRow>().Where(t => Convert.ToString(t["Client_Code"]) == this.txtSearchCustCode.Text.Trim()).ToList();
            if (Validation.Count == 0)
            {
                if (K == 0)
                {
                    Final_Data = data;
                    K++;

                }
                else
                {

                    foreach (DataRow dr in data.Rows)
                    {
                        Final_Data.Rows.Add(dr.ItemArray);
                    }
                    K++;
                }

                Gride_Cash_Limit.DataSource = Final_Data;
            }
            else
            {
                MessageBox.Show("Cust Code : " + this.txtSearchCustCode.Text.Trim() + " Already add in Gride", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            txtSearchCustCode.Text = "";
            txtSearchCustCode.Focus();
        }

        #endregion

        #region Send
        string folderpath = string.Empty;
        private void btnSend_Click(object sender, EventArgs e)
        {
            XMLFolderChoose.ShowDialog();
            folderpath = XMLFolderChoose.SelectedPath;
            Send_Clint_Limit();
            MessageBox.Show("Send Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void Send_Clint_Limit()
        {
            CommonBAL comBal = new CommonBAL();
            List<ClientRegistration> crList = new List<ClientRegistration>();
            List<ClientLimits> cashLimit = new List<ClientLimits>();

           
            SBPXMLSchema.XMLExport.Date =  comBal.GetCurrentServerDate_FromDB();
            SBPXMLSchema.XMLExport.Time = comBal.GetCurrentServerDate_FromDB();


            #region Cash_Limit
            foreach (DataRow dr in Final_Data.Rows)
            {

                SBPXMLSchema.ClientRegistration crRegTemp = new ClientRegistration();
                SBPXMLSchema.ClientLimits limit = new ClientLimits();

                if (dr["AccountType"].ToString() == "Non Resident")
                    crRegTemp.AccountType = SBPXMLSchema.AccountType.R;// NRB
                if (dr["AccountType"].ToString() == "Resident")
                    crRegTemp.AccountType = SBPXMLSchema.AccountType.N;// NORMAL
                crRegTemp.Address = dr["Address"].ToString();
                crRegTemp.BOID = dr["BOID"].ToString();
                crRegTemp.ICNo = dr["Branch_ID"].ToString();
                //crRegTemp.BranchID = "1";//dr["Branch ID"].ToString();
                crRegTemp.ClientCode = dr["Client_Code"].ToString();
                crRegTemp.DealerID = dr["DealerID"].ToString();
                crRegTemp.ICNo = dr["Nationa_id"].ToString();
                crRegTemp.Name = dr["Name"].ToString();
                crRegTemp.ShortName = dr["Short_Name"].ToString().Split(' ').Last();
                crRegTemp.ShortSellingAllowed = SBPXMLSchema.BooleanYesNo.No;
                crRegTemp.Tel = dr["Telephone"].ToString();

                if (dr["Net_Adjustment"].ToString().ToUpper().Trim() != "")
                {
                    string AAA = dr["Client_Code"].ToString();
                    if (dr["Net_Adjustment"].ToString().ToUpper().Trim() == ("YES").ToUpper().Trim())
                    {
                        crRegTemp.WithNetAdjustment = SBPXMLSchema.BooleanYesNo.Yes;
                    }
                    if (dr["Net_Adjustment"].ToString().ToUpper().Trim() == ("No").ToUpper().Trim())
                    {
                        crRegTemp.WithNetAdjustment = SBPXMLSchema.BooleanYesNo.No;
                    }
                }
                else
                {
                    string AAA = dr["Client_Code"].ToString();
                    if (dr["AccountType"].ToString().Trim().ToUpper() == ("Non Resident").ToUpper().Trim())
                    {
                        crRegTemp.WithNetAdjustment = SBPXMLSchema.BooleanYesNo.No;
                    }
                    if (Convert.ToDouble(dr["Balance"].ToString()) > 0)
                    {
                        crRegTemp.WithNetAdjustment = SBPXMLSchema.BooleanYesNo.Yes;
                    }
                    if (Convert.ToDouble(dr["Balance"].ToString()) < 0)
                    {
                        crRegTemp.WithNetAdjustment = SBPXMLSchema.BooleanYesNo.No;
                    }

                }
                //crRegTemp.WithNetAdjustment = SBPXMLSchema.BooleanYesNo.Yes;
                crList.Add(crRegTemp);


                if (Convert.ToDouble(dr["Cash"]) > 0)
                {
                    double dbl_Cash = Convert.ToDouble(dr["Cash"].ToString());
                    double round_dbl_Cash = Math.Round(dbl_Cash);
                    long lng_Cash = long.Parse(round_dbl_Cash.ToString());
                    limit.Cash = lng_Cash;//long.Parse(Math.Round(Convert.ToDouble(row["Cash"].ToString())).ToString());
                }
                else
                {
                    limit.Cash = long.Parse("0");
                }
                limit.ClientCode = dr["Client_Code"].ToString();
                cashLimit.Add(limit);


            }


            Clients cs = new Clients();
            cs.Register = crList.ToArray();
            cs.Limits = cashLimit.ToArray();
            cs.ProcessingMode = SBPXMLSchema.ProcessingMode_Clients.BatchInsertOrUpdate;
            SBPXMLSchema.XMLExport xprt = new XMLExport(XMLExportType.Clients, cs, folderpath);
            xprt.Export();
            #endregion
        }

        #endregion

        private void txtCustomerCode_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
