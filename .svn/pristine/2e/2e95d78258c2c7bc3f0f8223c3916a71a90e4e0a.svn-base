using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using BusinessAccessLayer.BO;

namespace StockbrokerProNewArch
{
    public partial class NominationForm : Form
    {
        public NominationForm()
        {
            InitializeComponent();
        }
        private GlobalVariableBO.ModeSelection currentMode = GlobalVariableBO.ModeSelection.NewMode;
        private string _boID = "";
        private string _custCode ="";
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NominationFormLoad(object sender, EventArgs e)
        {
            Init();
        }

        private void Init()
        {
            CommonBAL objBal = new CommonBAL();

            dtPOAIssueDate.Value = objBal.GetCurrentServerDate();
            dtPOAExpireDate.Value = objBal.GetCurrentServerDate();
            dtPOAEffectTo.Value = objBal.GetCurrentServerDate();
            dtPOAEffectFrom.Value = objBal.GetCurrentServerDate();
            dtPOADOB.Value = objBal.GetCurrentServerDate();
            dtNominee2IssueDate.Value = objBal.GetCurrentServerDate();
            dtNominee2ExpireDate.Value = objBal.GetCurrentServerDate();
            dtNominee2DOB.Value = objBal.GetCurrentServerDate();
            dtNominee1IssueDate.Value = objBal.GetCurrentServerDate();
            dtNominee1ExpireDate.Value = objBal.GetCurrentServerDate();
            dtNominee1DOB.Value = objBal.GetCurrentServerDate();

            dtGuardian2MaturityOfMinor.Value = objBal.GetCurrentServerDate();
            dtGuardian2IssueDate.Value = objBal.GetCurrentServerDate();
            dtGuardian2ExpireDate.Value = objBal.GetCurrentServerDate();
            dtGuardian2DOB.Value = objBal.GetCurrentServerDate();
            dtGuardian2BirthOfMinor.Value = objBal.GetCurrentServerDate();
            dtGuardian1MaturityOfMinor.Value = objBal.GetCurrentServerDate();
            dtGuardian1IssueDate.Value = objBal.GetCurrentServerDate();
            dtGuardian1ExpireDate.Value = objBal.GetCurrentServerDate();
            dtGuardian1DOB.Value = objBal.GetCurrentServerDate();
            dtGuardian1BirthOfMinor.Value = objBal.GetCurrentServerDate();
            ddlSearchCustomer.SelectedIndex = 0;
            ddlPOAResidency.SelectedIndex = 0;
            ddlNominee2Residency.SelectedIndex = 0;
            ddlNominee1Residency.SelectedIndex = 0;
            ddlGuardian2Residency.SelectedIndex = 0;
            ddlGuardian1Residency.SelectedIndex = 0;
        }
        private void SaveData(string customerCode)
        {
            try
            {
                //First Nominee
                Nominee1InfoBO nominee1BO = new Nominee1InfoBO();
                nominee1BO.Nominee1Name = txtNominee1Name.Text;
                nominee1BO.Nominee1Relation = txtNominee1Relation.Text;
                if(!String.IsNullOrEmpty(txtNominee1Percentage.Text.Trim()))
                    nominee1BO.Nominee1Percentage = Convert.ToInt32(txtNominee1Percentage.Text);
                nominee1BO.Nominee1Address = txtNominee1Address.Text;
                nominee1BO.Nominee1City = txtNominee1City.Text;
                nominee1BO.Nominee1PostCode = txtNominee1PostCode.Text;
                nominee1BO.Nominee1Division = txtNominee1Division.Text;
                nominee1BO.Nominee1Country = txtNominee1Country.Text;
                nominee1BO.Nominee1Telephone = txtNominee1Telephone.Text;
                nominee1BO.Nominee1Mobile = txtNominee1Mobile.Text;
                nominee1BO.Nominee1Fax = txtNominee1Fax.Text;
                nominee1BO.Nominee1Email = txtNominee1Email.Text;
                nominee1BO.Nominee1PassportNo = txtNominee1PassportNo.Text;
                nominee1BO.Nominee1IssuePlace = txtNominee1IssuePlace.Text;
                nominee1BO.Nominee1IssueDate = dtNominee2IssueDate.Value;
                nominee1BO.Nominee1ExpireDate = dtNominee1ExpireDate.Value;
                nominee1BO.Nominee1Residency = ddlNominee1Residency.SelectedItem.ToString();
                nominee1BO.Nominee1Nationality = txtNominee1Nationality.Text;
                nominee1BO.Nominee1Dob = dtNominee1DOB.Value;
                nominee1BO.Nominee1NationalId = txtNominee1NationalID.Text;

                //Second Nominee
                Nominee2InfoBO nominee2BO = new Nominee2InfoBO();
                nominee2BO.Nominee2Name = txtNominee2Name.Text;
                nominee2BO.Nominee2Relation = txtNominee2Relation.Text;
                if (!String.IsNullOrEmpty(txtNominee2Percentage.Text.Trim()))
                    nominee2BO.Nominee2Percentage = Convert.ToInt32(txtNominee2Percentage.Text);
                nominee2BO.Nominee2Address = txtNominee2Address.Text;
                nominee2BO.Nominee2City = txtNominee2City.Text;
                nominee2BO.Nominee2PostCode = txtNominee2PostCode.Text;
                nominee2BO.Nominee2Division = txtNominee2Division.Text;
                nominee2BO.Nominee2Country = txtNominee2Country.Text;
                nominee2BO.Nominee2Telephone = txtNominee2Telephone.Text;
                nominee2BO.Nominee2Mobile = txtNominee2Mobile.Text;
                nominee2BO.Nominee2Fax = txtNominee2Fax.Text;
                nominee2BO.Nominee2Email = txtNominee2Email.Text;
                nominee2BO.Nominee2PassportNo = txtNominee2PassportNo.Text;
                nominee2BO.Nominee2IssuePlace = txtNominee2IssuePlace.Text;
                nominee2BO.Nominee2IssueDate = dtNominee2IssueDate.Value;
                nominee2BO.Nominee2ExpireDate = dtNominee2ExpireDate.Value;
                nominee2BO.Nominee2Residency = ddlNominee2Residency.SelectedItem.ToString();
                nominee2BO.Nominee2Nationality = txtNominee2Nationality.Text;
                nominee2BO.Nominee2Dob = dtNominee2DOB.Value;
                nominee2BO.Nominee2NationalId = txtNominee2NationalID.Text;

                //First Guardian
                Guardian1InfoBO guardian1BO = new Guardian1InfoBO();
                guardian1BO.Guardian1Name = txtGuardian1Name.Text;
                guardian1BO.Guardian1Relation = txtGuardian1Relation.Text;
                guardian1BO.Guardian1DoBofMinor = dtGuardian1BirthOfMinor.Value;
                guardian1BO.Guardian1MaturityDateMinor = dtGuardian1MaturityOfMinor.Value;
                guardian1BO.Guardian1Address = txtGuardian1Address.Text;
                guardian1BO.Guardian1City = txtGuardian1City.Text;
                guardian1BO.Guardian1PostCode = txtGuardian1PostCode.Text;
                guardian1BO.Guardian1Division = txtGuardian1Division.Text;
                guardian1BO.Guardian1Country = txtGuardian1Country.Text;
                guardian1BO.Guardian1Telephone = txtGuardian1Telephone.Text;
                guardian1BO.Guardian1Mobile = txtGuardian1Mobile.Text;
                guardian1BO.Guardian1Fax = txtGuardian1Fax.Text;
                guardian1BO.Guardian1Email = txtGuardian1Email.Text;
                guardian1BO.Guardian1PassportNo = txtGuardian1PassportNo.Text;
                guardian1BO.Guardian1IssuePlace = txtGuardian1IssuePlace.Text;
                guardian1BO.Guardian1IssueDate = dtGuardian1IssueDate.Value;
                guardian1BO.Guardian1ExpireDate = dtGuardian1ExpireDate.Value;
                guardian1BO.Guardian1Residency = ddlGuardian1Residency.SelectedItem.ToString();
                guardian1BO.Guardian1Nationality = txtGuardian1Nationality.Text;
                guardian1BO.Guardian1DOB = dtGuardian1DOB.Value;

                //Second Guardian
                Guardian2InfoBO guardian2BO = new Guardian2InfoBO();
                guardian2BO.Guardian2Name = txtGuardian2Name.Text;
                guardian2BO.Guardian2Relation = txtGuardian2Relation.Text;
                guardian2BO.Guardian2DoBofMinor = dtGuardian2BirthOfMinor.Value;
                guardian2BO.Guardian2MaturityDateMinor = dtGuardian2MaturityOfMinor.Value;
                guardian2BO.Guardian2Address = txtGuardian2Address.Text;
                guardian2BO.Guardian2City = txtGuardian2City.Text;
                guardian2BO.Guardian2PostCode = txtGuardian2PostCode.Text;
                guardian2BO.Guardian2Division = txtGuardian2Division.Text;
                guardian2BO.Guardian2Country = txtGuardian2Country.Text;
                guardian2BO.Guardian2Telephone = txtGuardian2Telephone.Text;
                guardian2BO.Guardian2Mobile = txtGuardian2Mobile.Text;
                guardian2BO.Guardian2Fax = txtGuardian2Fax.Text;
                guardian2BO.Guardian2Email = txtGuardian2Email.Text;
                guardian2BO.Guardian2PassportNo = txtGuardian2PassportNo.Text;
                guardian2BO.Guardian2IssuePlace = txtGuardian2IssuePlace.Text;
                guardian2BO.Guardian2IssueDate = dtGuardian2IssueDate.Value;
                guardian2BO.Guardian2ExpireDate = dtGuardian2ExpireDate.Value;
                guardian2BO.Guardian2Residency = ddlGuardian2Residency.SelectedItem.ToString();
                guardian2BO.Guardian2Nationality = txtGuardian2Nationality.Text;
                guardian2BO.Guardian2DOB = dtGuardian2DOB.Value;

                //Power of Attorney
                PowerOfAttorneyInfoBO poaInfoBO = new PowerOfAttorneyInfoBO();
                poaInfoBO.POAName = txtPOAName.Text;
                poaInfoBO.POAAddress = txtPOAAddress.Text;
                poaInfoBO.POACity = txtPOACity.Text;
                poaInfoBO.POAPostCode = txtPOAPostCode.Text;
                poaInfoBO.POADivision = txtPOADivision.Text;
                poaInfoBO.POACountry = txtPOACountry.Text;
                poaInfoBO.POATelephone = txtPOATelephone.Text;
                poaInfoBO.POAMobile = txtPOAMobile.Text;
                poaInfoBO.POAFax = txtPOAFax.Text;
                poaInfoBO.POAEmail = txtPOAEmail.Text;
                poaInfoBO.POAPassportNo = txtPOAPassportNo.Text;
                poaInfoBO.POAIssuePlace = txtPOAIssuePlace.Text;
                poaInfoBO.POAIssueDate = dtPOAIssueDate.Value;
                poaInfoBO.POAExpireDate = dtPOAExpireDate.Value;
                poaInfoBO.POAResidency = ddlPOAResidency.SelectedItem.ToString();
                poaInfoBO.POANationality = txtPOANationality.Text;
                poaInfoBO.POADob = dtPOADOB.Value;
                poaInfoBO.POAEffectiveFrom = dtPOAEffectFrom.Value;
                poaInfoBO.POAEffectiveTo = dtPOAEffectTo.Value;
                poaInfoBO.POARemarks = txtPOARemarks.Text;

                switch (currentMode)
                {
                    case GlobalVariableBO.ModeSelection.NewMode:
                        try
                        {
                            if (IsInputValid())
                            {
                                NomineePOABAL nomineePOABAL = new NomineePOABAL();
                                nomineePOABAL.Insert(customerCode, nominee1BO, nominee2BO, guardian1BO, guardian2BO, poaInfoBO);
                                MessageBox.Show("Information Saved Successfully.", "Save Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ClearAll();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Fail to save Information because of the Error : " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    case GlobalVariableBO.ModeSelection.UpdateMode:
                        try
                        {
                            NomineePOABAL nomineePOABAL = new NomineePOABAL();
                            nomineePOABAL.Update(customerCode, nominee1BO, nominee2BO, guardian1BO, guardian2BO, poaInfoBO);
                            MessageBox.Show("Information updated Successfully.", "Save Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Fail to update Information because of the Error : " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private bool IsInputValid()
        {
            NomineePOABAL nomineePoabal = new NomineePOABAL();
            if (nomineePoabal.CheckTable(txtCustCode.Text))
            {
                MessageBox.Show("You can not insert data twice for any customer.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btnSaveBasicInfo_Click(object sender, EventArgs e)
        {
            LoadSaveInfo();
        }

        private void LoadSaveInfo()
        {
            if (txtSearchCustomer.Text.Trim() == "")
            {
                MessageBox.Show("Please Fill the Customer Code/BO ID.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SaveData(txtCustCode.Text);
        }

        private void btnResetBasicInfo_Click(object sender, EventArgs e)
        {
            if (currentMode == GlobalVariableBO.ModeSelection.UpdateMode)
            {
                ClearAll();
                DisableAll();

            }
            else
            {
                ClearAll();
                EnableAll();
            }
        }

      private void EnableAll()
        {
            /*  txtPOATelephone.Enabled = true;
            txtPOARemarks.Enabled = true;
            txtPOAPostCode.Enabled = true;
            txtPOAPassportNo.Enabled = true;
            txtPOANationality.Enabled = true;
            txtPOAName.Enabled = true;
            txtPOAMobile.Enabled = true;
            txtPOAIssuePlace.Enabled = true;
            txtPOAFax.Enabled = true;
            txtPOAEmail.Enabled = true;
            txtPOADivision.Enabled = true;
            txtPOACountry.Enabled = true;
            txtPOACity.Enabled = true;
            txtPOAAddress.Enabled = true;
            txtNominee2Telephone.Enabled = true;
            txtNominee2Relation.Enabled = true;
            txtNominee2PostCode.Enabled = true;
            txtNominee2Percentage.Enabled = true;
            txtNominee2PassportNo.Enabled = true;
            txtNominee2Nationality.Enabled = true;
            txtNominee2Name.Enabled = true;
            txtNominee2Mobile.Enabled = true;
            txtNominee2IssuePlace.Enabled = true;
            txtNominee2Fax.Enabled = true;
            txtNominee2Email.Enabled = true;
            txtNominee2Division.Enabled = true;
            txtNominee2Country.Enabled = true;
            txtNominee2City.Enabled = true;
            txtNominee2Address.Enabled = true;
            txtNominee1Telephone.Enabled = true;
            txtNominee1Relation.Enabled = true;
            txtNominee1PostCode.Enabled = true;
            txtNominee1Percentage.Enabled = true;
            txtNominee1PassportNo.Enabled = true;
            txtNominee1Nationality.Enabled = true;
            txtNominee1Name.Enabled = true;
            txtNominee1Mobile.Enabled = true;
            txtNominee1IssuePlace.Enabled = true;
            txtNominee1Fax.Enabled = true;
            txtNominee1Email.Enabled = true;
            txtNominee1Division.Enabled = true;
            txtNominee1Country.Enabled = true; 
            txtNominee1City.Enabled = true;
            txtNominee1Address.Enabled = true;
            txtGuardian2Telephone.Enabled = true;
            txtGuardian2Relation.Enabled = true;
            txtGuardian2PostCode.Enabled = true;
            txtGuardian2PassportNo.Enabled = true;
            txtGuardian2Nationality.Enabled = true;
            txtGuardian2Name.Enabled = true;
            txtGuardian2Mobile.Enabled = true;
            txtGuardian2IssuePlace.Enabled = true;
            txtGuardian2Fax.Enabled = true;
            txtGuardian2Email.Enabled = true;
            txtGuardian2Division.Enabled = true;
            txtGuardian2Country.Enabled = true;
            txtGuardian2City.Enabled = true;
            txtGuardian1Address.Enabled = true;
            txtGuardian1Telephone.Enabled = true;
            txtGuardian1Relation.Enabled = true;
            txtGuardian1PostCode.Enabled = true;
            txtGuardian1PassportNo.Enabled = true;
            txtGuardian1Nationality.Enabled = true;
            txtGuardian1Name.Enabled = true;
            txtGuardian1Mobile.Enabled = true;
            txtGuardian1IssuePlace.Enabled = true;
            txtGuardian1Fax.Enabled = true;
            txtGuardian1Email.Enabled = true;
            txtGuardian1Division.Enabled = true;
            txtGuardian1Country.Enabled = true;
            txtGuardian1City.Enabled = true;
            txtGuardian1Address.Enabled = true;
            ddlPOAResidency.Enabled = true;
            ddlNominee2Residency.Enabled = true;
            ddlNominee1Residency.Enabled = true;
            ddlGuardian2Residency.Enabled = true;
            ddlGuardian1Residency.Enabled = true;
            txtGuardian2Address.Enabled = true;
            txtCustCode.Enabled = true;
            txtAccountHolderName.Enabled = true;
            txtAccountHolderBOId.Enabled = true;
            dtPOAIssueDate.Enabled = true;
            dtPOAExpireDate.Enabled = true;
            dtPOAEffectTo.Enabled = true;
            dtPOAEffectFrom.Enabled = true;
            dtPOADOB.Enabled = true;
            dtNominee2IssueDate.Enabled = true;
            dtNominee2ExpireDate.Enabled = true;
            dtNominee2DOB.Enabled = true;
            dtNominee1IssueDate.Enabled = true;
            dtNominee1ExpireDate.Enabled = true;
            dtNominee1DOB.Enabled = true;
            dtGuardian2MaturityOfMinor.Enabled = true;
            dtGuardian2IssueDate.Enabled = true;
            dtGuardian2ExpireDate.Enabled = true;
            dtGuardian2DOB.Enabled = true;
            dtGuardian2BirthOfMinor.Enabled = true;
            dtGuardian1MaturityOfMinor.Enabled = true;
            dtGuardian1IssueDate.Enabled = true;
            dtGuardian1ExpireDate.Enabled = true;
            dtGuardian1DOB.Enabled = true;
            dtGuardian1BirthOfMinor.Enabled = true;*/
           }

        private void DisableAll()
        {/*
            txtPOATelephone.Enabled = false;
            txtPOARemarks.Enabled = false;
            txtPOAPostCode.Enabled = false;
            txtPOAPassportNo.Enabled = false;
            txtPOANationality.Enabled = false;
            txtPOAName.Enabled = false;
            txtPOAMobile.Enabled = false;
            txtPOAIssuePlace.Enabled = false;
            txtPOAFax.Enabled = false;
            txtPOAEmail.Enabled = false;
            txtPOADivision.Enabled = false;
            txtPOACountry.Enabled = false;
            txtPOACity.Enabled = false;
            txtPOAAddress.Enabled = false;
            txtNominee2Telephone.Enabled = false;
            txtNominee2Relation.Enabled = false;
            txtNominee2PostCode.Enabled = false;
            txtNominee2Percentage.Enabled = false;
            txtNominee2PassportNo.Enabled = false;
            txtNominee2Nationality.Enabled = false;
            txtNominee2Name.Enabled = false;
            txtNominee2Mobile.Enabled = false;
            txtNominee2IssuePlace.Enabled = false;
            txtNominee2Fax.Enabled = false;
            txtNominee2Email.Enabled = false;
            txtNominee2Division.Enabled = false;
            txtNominee2Country.Enabled = false;
            txtNominee2City.Enabled = false;
            txtNominee2Address.Enabled = false;
            txtNominee1Telephone.Enabled = false;
            txtNominee1Relation.Enabled = false;
            txtNominee1PostCode.Enabled = false;
            txtNominee1Percentage.Enabled = false;
            txtNominee1PassportNo.Enabled = false;
            txtNominee1Nationality.Enabled = false;
            txtNominee1Name.Enabled = false;
            txtNominee1Mobile.Enabled = false;
            txtNominee1IssuePlace.Enabled = false;
            txtNominee1Fax.Enabled = false;
            txtNominee1Email.Enabled = false;
            txtNominee1Division.Enabled = false;
            txtNominee1Country.Enabled = false;
            txtNominee1City.Enabled = false;
            txtNominee1Address.Enabled = false;
            txtGuardian2Telephone.Enabled = false;
            txtGuardian2Relation.Enabled = false;
            txtGuardian2PostCode.Enabled = false;
            txtGuardian2PassportNo.Enabled = false;
            txtGuardian2Nationality.Enabled = false;
            txtGuardian2Name.Enabled = false;
            txtGuardian2Mobile.Enabled = false;
            txtGuardian2IssuePlace.Enabled = false;
            txtGuardian2Fax.Enabled = false;
            txtGuardian2Email.Enabled = false;
            txtGuardian2Division.Enabled = false;
            txtGuardian2Country.Enabled = false;
            txtGuardian2City.Enabled = false;
            txtGuardian1Address.Enabled = false;
            txtGuardian1Telephone.Enabled = false;
            txtGuardian1Relation.Enabled = false;
            txtGuardian1PostCode.Enabled = false;
            txtGuardian1PassportNo.Enabled = false;
            txtGuardian1Nationality.Enabled = false;
            txtGuardian1Name.Enabled = false;
            txtGuardian1Mobile.Enabled = false;
            txtGuardian1IssuePlace.Enabled = false;
            txtGuardian1Fax.Enabled = false;
            txtGuardian1Email.Enabled = false;
            txtGuardian1Division.Enabled = false;
            txtGuardian1Country.Enabled = false;
            txtGuardian1City.Enabled = false;
            txtGuardian1Address.Enabled = false;
            ddlPOAResidency.Enabled = false;
            ddlNominee2Residency.Enabled = false;
            ddlNominee1Residency.Enabled = false;
            ddlGuardian2Residency.Enabled = false;
            ddlGuardian1Residency.Enabled = false;
            txtGuardian2Address.Enabled = false;
            txtCustCode.Enabled = false;
            txtAccountHolderName.Enabled = false;
            txtAccountHolderBOId.Enabled = false;
            dtPOAIssueDate.Enabled = false;
            dtPOAExpireDate.Enabled = false;
            dtPOAEffectTo.Enabled = false;
            dtPOAEffectFrom.Enabled = false;
            dtPOADOB.Enabled = false;
            dtNominee2IssueDate.Enabled = false;
            dtNominee2ExpireDate.Enabled = false;
            dtNominee2DOB.Enabled = false;
            dtNominee1IssueDate.Enabled = false;
            dtNominee1ExpireDate.Enabled = false;
            dtNominee1DOB.Enabled = false;
            dtGuardian2MaturityOfMinor.Enabled = false;
            dtGuardian2IssueDate.Enabled = false;
            dtGuardian2ExpireDate.Enabled = false;
            dtGuardian2DOB.Enabled = false;
            dtGuardian2BirthOfMinor.Enabled = false;
            dtGuardian1MaturityOfMinor.Enabled = false;
            dtGuardian1IssueDate.Enabled = false;
            dtGuardian1ExpireDate.Enabled = false;
            dtGuardian1DOB.Enabled = false;
            dtGuardian1BirthOfMinor.Enabled = false;*/
        }

        private void ClearAll()
        {
           // EnableAll();
            txtPOATelephone.Text = "";
            txtPOARemarks.Text = "";
            txtPOAPostCode.Text = "";
            txtPOAPassportNo.Text = "";
            txtPOANationality.Text = "";
            txtPOAName.Text = "";
            txtPOAMobile.Text = "";
            txtPOAIssuePlace.Text = "";
            txtPOAFax.Text = "";
            txtPOAEmail.Text = "";
            txtPOADivision.Text = "";
            txtPOACountry.Text = "";
            txtPOACity.Text = "";
            txtPOAAddress.Text = "";
            txtNominee2Telephone.Text = "";
            txtNominee2Relation.Text = "";
            txtNominee2PostCode.Text = "";
            txtNominee2Percentage.Text = "";
            txtNominee2PassportNo.Text = "";
            txtNominee2Nationality.Text = "";
            txtNominee2Name.Text = "";
            txtNominee2Mobile.Text = "";
            txtNominee2IssuePlace.Text = "";
            txtNominee2Fax.Text = "";
            txtNominee2Email.Text = "";
            txtNominee2Division.Text = "";
            txtNominee2Country.Text = "";
            txtNominee2City.Text = "";
            txtNominee2Address.Text = "";
            txtNominee1Telephone.Text = "";
            txtNominee1Relation.Text = "";
            txtNominee1PostCode.Text = "";
            txtNominee1Percentage.Text = "";
            txtNominee1PassportNo.Text = "";
            txtNominee1Nationality.Text = "";
            txtNominee1Name.Text = "";
            txtNominee1Mobile.Text = "";
            txtNominee1IssuePlace.Text = "";
            txtNominee1Fax.Text = "";
            txtNominee1Email.Text = "";
            txtNominee1Division.Text = "";
            txtNominee1Country.Text = "";
            txtNominee1City.Text = "";
            txtNominee1Address.Text = "";
            txtGuardian2Telephone.Text = "";
            txtGuardian2Relation.Text = "";
            txtGuardian2PostCode.Text = "";
            txtGuardian2PassportNo.Text = "";
            txtGuardian2Nationality.Text = "";
            txtGuardian2Name.Text = "";
            txtGuardian2Mobile.Text = "";
            txtGuardian2IssuePlace.Text = "";
            txtGuardian2Fax.Text = "";
            txtGuardian2Email.Text = "";
            txtGuardian2Division.Text = "";
            txtGuardian2Country.Text = "";
            txtGuardian2City.Text = "";
            txtGuardian1Address.Text = "";
            txtGuardian1Telephone.Text = "";
            txtGuardian1Relation.Text = "";
            txtGuardian1PostCode.Text = "";
            txtGuardian1PassportNo.Text = "";
            txtGuardian1Nationality.Text = "";
            txtGuardian1Name.Text = "";
            txtGuardian1Mobile.Text = "";
            txtGuardian1IssuePlace.Text = "";
            txtGuardian1Fax.Text = "";
            txtGuardian1Email.Text = "";
            txtGuardian1Division.Text = "";
            txtGuardian1Country.Text = "";
            txtGuardian1City.Text = "";
            txtGuardian1Address.Text = "";
            ddlPOAResidency.SelectedIndex = 0;
            ddlNominee2Residency.SelectedIndex = 0;
            ddlNominee1Residency.SelectedIndex = 0;
            ddlGuardian2Residency.SelectedIndex = 0;
            ddlGuardian1Residency.SelectedIndex = 0;
            txtGuardian2Address.Text = "";
            txtSearchCustomer.Text = "";
            txtCustCode.Text = "";
            txtAccountHolderName.Text = "";
            txtAccountHolderBOId.Text = "";
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            currentMode = GlobalVariableBO.ModeSelection.NewMode;
            btnNew.Enabled = false;
            btnNew.BackColor = Color.Gray;
            btnUpdate.Enabled = true;
            btnUpdate.ResetBackColor();
            ClearAll();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            currentMode = GlobalVariableBO.ModeSelection.UpdateMode;
            btnUpdate.Enabled = false;
            btnUpdate.BackColor = Color.Gray;
            btnNew.Enabled = true;
            btnNew.ResetBackColor();
            ClearAll();
            DisableAll();
        }

       

        public void LoadDataFromDataTable()
        {
            DataTable nomineeDataTable = new DataTable();
            NomineePOABAL nomineeBAL = new NomineePOABAL();
            if (!String.IsNullOrEmpty(txtCustCode.Text.Trim()))
                nomineeDataTable = nomineeBAL.GetAllData(txtCustCode.Text);
            if (nomineeDataTable.Rows.Count > 0)
            {
                txtNominee1Name.Text = nomineeDataTable.Rows[0]["n1Name"].ToString();
                txtNominee1Address.Text = nomineeDataTable.Rows[0]["n1Address"].ToString();
                txtNominee1City.Text = nomineeDataTable.Rows[0]["n1City"].ToString();
                txtNominee1Division.Text = nomineeDataTable.Rows[0]["n1Division"].ToString();
                txtNominee1Country.Text = nomineeDataTable.Rows[0]["n1Country"].ToString();
                txtNominee1PostCode.Text = nomineeDataTable.Rows[0]["n1PostCode"].ToString();
                txtNominee1Telephone.Text = nomineeDataTable.Rows[0]["n1Phone"].ToString();
                txtNominee1Mobile.Text = nomineeDataTable.Rows[0]["n1Mobile"].ToString();
                txtNominee1Fax.Text = nomineeDataTable.Rows[0]["n1Fax"].ToString();
                txtNominee1Email.Text = nomineeDataTable.Rows[0]["n1Email"].ToString();
           

                dtNominee1DOB.Value = nomineeDataTable.Rows[0]["n1DOB"].ToString() == "" ? DateTime.Now : Convert.ToDateTime(nomineeDataTable.Rows[0]["n1DOB"].ToString());
                txtNominee1Nationality.Text = nomineeDataTable.Rows[0]["n1Nationality"].ToString();
                ddlNominee1Residency.SelectedItem = nomineeDataTable.Rows[0]["n1Residency"].ToString();
                txtNominee1PassportNo.Text = nomineeDataTable.Rows[0]["n1PassNo"].ToString();
                dtNominee1IssueDate.Value = nomineeDataTable.Rows[0]["n1IssueDate"] .ToString()== "" ? DateTime.Now : Convert.ToDateTime(nomineeDataTable.Rows[0]["n1IssueDate"]);
                dtNominee1ExpireDate.Value = nomineeDataTable.Rows[0]["n1Expire"].ToString() == "" ? DateTime.Now : Convert.ToDateTime(nomineeDataTable.Rows[0]["n1Expire"]);
                txtNominee1IssuePlace.Text = nomineeDataTable.Rows[0]["n1IssuePlace"].ToString();
                txtNominee1Relation.Text = nomineeDataTable.Rows[0]["n1Relation"].ToString();
                txtNominee1Percentage.Text = nomineeDataTable.Rows[0]["n1Percentage"].ToString();
                txtNominee1NationalID.Text = nomineeDataTable.Rows[0]["n1NationalID"].ToString();

                txtNominee2Name.Text = nomineeDataTable.Rows[0]["n2Name"].ToString();
                txtNominee2Address.Text = nomineeDataTable.Rows[0]["n2Address"].ToString();
                txtNominee2City.Text = nomineeDataTable.Rows[0]["n2City"].ToString();
                txtNominee2Division.Text = nomineeDataTable.Rows[0]["n2Division"].ToString();
                txtNominee2Country.Text = nomineeDataTable.Rows[0]["n2Country"].ToString();
                txtNominee2PostCode.Text = nomineeDataTable.Rows[0]["n2PostCode"].ToString();
                txtNominee2Telephone.Text = nomineeDataTable.Rows[0]["n2Phone"].ToString();
                txtNominee2Mobile.Text = nomineeDataTable.Rows[0]["n2Mobile"].ToString();
                txtNominee2Fax.Text = nomineeDataTable.Rows[0]["n2Fax"].ToString();
                txtNominee2Email.Text = nomineeDataTable.Rows[0]["n2Email"].ToString();
                dtNominee2DOB.Value = nomineeDataTable.Rows[0]["n2DOB"].ToString() == "" ? DateTime.Now : Convert.ToDateTime(nomineeDataTable.Rows[0]["n2DOB"]);
                txtNominee2Nationality.Text = nomineeDataTable.Rows[0]["n2Nationality"].ToString();
                ddlNominee2Residency.SelectedItem = nomineeDataTable.Rows[0]["n2Residency"].ToString();
                txtNominee2PassportNo.Text = nomineeDataTable.Rows[0]["n2PassNo"].ToString();
                dtNominee2IssueDate.Value = nomineeDataTable.Rows[0]["n2IssueDate"].ToString() == "" ? DateTime.Now :Convert.ToDateTime(nomineeDataTable.Rows[0]["n2IssueDate"]);
                dtNominee2ExpireDate.Value = nomineeDataTable.Rows[0]["n2Expire"].ToString() == "" ? DateTime.Now :Convert.ToDateTime(nomineeDataTable.Rows[0]["n2Expire"]);
                txtNominee2IssuePlace.Text = nomineeDataTable.Rows[0]["n2IssuePlace"].ToString();
                txtNominee2Relation.Text = nomineeDataTable.Rows[0]["n2Relation"].ToString();
                txtNominee2Percentage.Text = nomineeDataTable.Rows[0]["n2Percentage"].ToString();
                txtNominee2NationalID.Text = nomineeDataTable.Rows[0]["n2NationalID"].ToString();

                txtGuardian1Name.Text = nomineeDataTable.Rows[0]["g1Name"].ToString();
                txtGuardian1Address.Text = nomineeDataTable.Rows[0]["g1Address"].ToString();
                txtGuardian1City.Text = nomineeDataTable.Rows[0]["g1City"].ToString();
                txtGuardian1Division.Text = nomineeDataTable.Rows[0]["g1Division"].ToString();
                txtGuardian1Country.Text = nomineeDataTable.Rows[0]["g1Country"].ToString();
                txtGuardian1PostCode.Text = nomineeDataTable.Rows[0]["g1PostCode"].ToString();
                txtGuardian1Telephone.Text = nomineeDataTable.Rows[0]["g1Phone"].ToString();
                txtGuardian1Mobile.Text = nomineeDataTable.Rows[0]["g1Mobile"].ToString();
                txtGuardian1Fax.Text = nomineeDataTable.Rows[0]["g1Fax"].ToString();
                txtGuardian1Email.Text = nomineeDataTable.Rows[0]["g1Email"].ToString();
                dtGuardian1DOB.Value = nomineeDataTable.Rows[0]["g1DOB"].ToString() == "" ? DateTime.Now :Convert.ToDateTime(nomineeDataTable.Rows[0]["g1DOB"]);
                txtGuardian1Nationality.Text = nomineeDataTable.Rows[0]["g1Nationality"].ToString();
                ddlGuardian1Residency.SelectedItem = nomineeDataTable.Rows[0]["g1Residency"].ToString();
                txtGuardian1PassportNo.Text = nomineeDataTable.Rows[0]["g1PassNo"].ToString();
                dtGuardian1IssueDate.Value = nomineeDataTable.Rows[0]["g1IssueDate"].ToString() == "" ? DateTime.Now :Convert.ToDateTime(nomineeDataTable.Rows[0]["g1IssueDate"]);
                dtGuardian1ExpireDate.Value =nomineeDataTable.Rows[0]["g1Expire"] .ToString() == "" ? DateTime.Now :Convert.ToDateTime(nomineeDataTable.Rows[0]["g1Expire"]);
                txtGuardian1IssuePlace.Text = nomineeDataTable.Rows[0]["g1IssuePlace"].ToString();
                txtGuardian1Relation.Text = nomineeDataTable.Rows[0]["g1Relation"].ToString();
                dtGuardian1BirthOfMinor.Value =nomineeDataTable.Rows[0]["g1Minor"] .ToString() == "" ? DateTime.Now :Convert.ToDateTime(nomineeDataTable.Rows[0]["g1Minor"]);
                dtGuardian1MaturityOfMinor.Value = nomineeDataTable.Rows[0]["g1Mature"].ToString() == "" ? DateTime.Now :Convert.ToDateTime(nomineeDataTable.Rows[0]["g1Mature"]);

                txtGuardian2Name.Text = nomineeDataTable.Rows[0]["g2Name"].ToString();
                txtGuardian2Address.Text = nomineeDataTable.Rows[0]["g2Address"].ToString();
                txtGuardian2City.Text = nomineeDataTable.Rows[0]["g2City"].ToString();
                txtGuardian2Division.Text = nomineeDataTable.Rows[0]["g2Division"].ToString();
                txtGuardian2Country.Text = nomineeDataTable.Rows[0]["g2Country"].ToString();
                txtGuardian2PostCode.Text = nomineeDataTable.Rows[0]["g2PostCode"].ToString();
                txtGuardian2Telephone.Text = nomineeDataTable.Rows[0]["g2Phone"].ToString();
                txtGuardian2Mobile.Text = nomineeDataTable.Rows[0]["g2Mobile"].ToString();
                txtGuardian2Fax.Text = nomineeDataTable.Rows[0]["g2Fax"].ToString();
                txtGuardian2Email.Text = nomineeDataTable.Rows[0]["g2Email"].ToString();
                dtGuardian2DOB.Value =nomineeDataTable.Rows[0]["g2DOB"] .ToString() == "" ? DateTime.Now :Convert.ToDateTime(nomineeDataTable.Rows[0]["g2DOB"]);
                txtGuardian2Nationality.Text = nomineeDataTable.Rows[0]["g2Nationality"].ToString();
                ddlGuardian2Residency.SelectedItem = nomineeDataTable.Rows[0]["g2Residency"].ToString();
                txtGuardian2PassportNo.Text = nomineeDataTable.Rows[0]["g2PassNo"].ToString();
                dtGuardian2IssueDate.Value =nomineeDataTable.Rows[0]["g2IssueDate"] .ToString() == "" ? DateTime.Now :Convert.ToDateTime(nomineeDataTable.Rows[0]["g2IssueDate"]);
                dtGuardian2ExpireDate.Value =nomineeDataTable.Rows[0]["g2Expire"] .ToString() == "" ? DateTime.Now :Convert.ToDateTime(nomineeDataTable.Rows[0]["g2Expire"]);
                txtGuardian2IssuePlace.Text = nomineeDataTable.Rows[0]["g2IssuePlace"].ToString();
                txtGuardian2Relation.Text = nomineeDataTable.Rows[0]["g2Relation"].ToString();
                dtGuardian2BirthOfMinor.Value = nomineeDataTable.Rows[0]["g2Minor"].ToString() == "" ? DateTime.Now :Convert.ToDateTime(nomineeDataTable.Rows[0]["g2Minor"]);
                dtGuardian2MaturityOfMinor.Value = nomineeDataTable.Rows[0]["g2Mature"].ToString() == "" ? DateTime.Now :Convert.ToDateTime(nomineeDataTable.Rows[0]["g2Mature"]);

                txtPOAName.Text = nomineeDataTable.Rows[0]["pName"].ToString();
                txtPOAAddress.Text = nomineeDataTable.Rows[0]["pAddress"].ToString();
                txtPOACity.Text = nomineeDataTable.Rows[0]["pCity"].ToString();
                txtPOADivision.Text = nomineeDataTable.Rows[0]["pDivision"].ToString();
                txtPOACountry.Text = nomineeDataTable.Rows[0]["pCountry"].ToString();
                txtPOAPostCode.Text = nomineeDataTable.Rows[0]["pPostCode"].ToString();
                txtPOATelephone.Text = nomineeDataTable.Rows[0]["pPhone"].ToString();
                txtPOAMobile.Text = nomineeDataTable.Rows[0]["pMobile"].ToString();
                txtPOAFax.Text = nomineeDataTable.Rows[0]["pFax"].ToString();
                txtPOAEmail.Text = nomineeDataTable.Rows[0]["pEmail"].ToString();
                txtPOAPassportNo.Text = nomineeDataTable.Rows[0]["pPassNo"].ToString();
                dtPOAIssueDate.Value =nomineeDataTable.Rows[0]["pIssueDate"] .ToString() == "" ? DateTime.Now :Convert.ToDateTime(nomineeDataTable.Rows[0]["pIssueDate"]);
                dtPOAExpireDate.Value = nomineeDataTable.Rows[0]["pExpire"].ToString() == "" ? DateTime.Now :Convert.ToDateTime(nomineeDataTable.Rows[0]["pExpire"]);
                txtPOAIssuePlace.Text = nomineeDataTable.Rows[0]["pIssuePlace"].ToString();
                txtPOANationality.Text = nomineeDataTable.Rows[0]["pNationality"].ToString();
                ddlPOAResidency.SelectedItem = nomineeDataTable.Rows[0]["pResidency"].ToString();
                dtPOADOB.Value = nomineeDataTable.Rows[0]["pDOB"].ToString() == "" ? DateTime.Now :Convert.ToDateTime(nomineeDataTable.Rows[0]["pDOB"]);
                dtPOAEffectFrom.Value = nomineeDataTable.Rows[0]["Effective_From"].ToString() == "" ? DateTime.Now :Convert.ToDateTime(nomineeDataTable.Rows[0]["Effective_From"]);
                dtPOAEffectTo.Value = nomineeDataTable.Rows[0]["Effective_To"].ToString() == "" ? DateTime.Now :Convert.ToDateTime(nomineeDataTable.Rows[0]["Effective_To"]);
                txtPOARemarks.Text = nomineeDataTable.Rows[0]["Remarks"].ToString();
            }
            else
            {
                MessageBox.Show("No item found to edit.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
        public void ShowData()
        {
            DataTable custDateTable = new DataTable();
            if (currentMode == GlobalVariableBO.ModeSelection.NewMode)
            {
                CustomerInfoBAL customerInfoBAL = new CustomerInfoBAL();
                if (ddlSearchCustomer.SelectedItem.Equals("BO Id"))
                {
                    _boID = txtSearchCustomer.Text;
                    custDateTable = customerInfoBAL.GetCustInfoByBOID(_boID);
                    if (custDateTable.Rows.Count > 0)
                    {
                        txtCustCode.Text = custDateTable.Rows[0]["Cust_Code"].ToString();
                        txtAccountHolderName.Text = custDateTable.Rows[0]["Cust_Name"].ToString();
                        txtAccountHolderBOId.Text = custDateTable.Rows[0]["BO_Id"].ToString();
                        txtNominee1Name.Focus();
                    }
                    else
                    {
                        MessageBox.Show("No customer found.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtSearchCustomer.Focus();
                    }
                }
                else
                {
                    _custCode = txtSearchCustomer.Text;
                    custDateTable = customerInfoBAL.GetCustInfoByCustCode(_custCode);
                    if (custDateTable.Rows.Count > 0)
                    {
                        txtCustCode.Text = custDateTable.Rows[0]["Cust_Code"].ToString();
                        txtAccountHolderName.Text = custDateTable.Rows[0]["Cust_Name"].ToString();
                        txtAccountHolderBOId.Text = custDateTable.Rows[0]["BO_Id"].ToString();
                        txtNominee1Name.Focus();
                    }
                    else
                    {
                        MessageBox.Show("No customer found.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtSearchCustomer.Focus();
                    }
                }
            }
            else
            {
                CustomerInfoBAL customerInfoBAL = new CustomerInfoBAL();
                if (ddlSearchCustomer.SelectedItem.Equals("BO Id"))
                {
                    _boID = txtSearchCustomer.Text;
                    custDateTable = customerInfoBAL.GetCustInfoByBOID(_boID);
                    if (custDateTable.Rows.Count > 0)
                    {
                        txtCustCode.Text = custDateTable.Rows[0][0].ToString();
                        txtAccountHolderName.Text = custDateTable.Rows[0][1].ToString();
                        txtAccountHolderBOId.Text = custDateTable.Rows[0][2].ToString();
                        LoadDataFromDataTable();
                    }
                    else
                    {
                        MessageBox.Show("No customer found.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    _custCode = txtSearchCustomer.Text;
                    custDateTable = customerInfoBAL.GetCustInfoByCustCode(_custCode);
                    if (custDateTable.Rows.Count > 0)
                    {
                        txtCustCode.Text = custDateTable.Rows[0][0].ToString();
                        txtAccountHolderName.Text = custDateTable.Rows[0][1].ToString();
                        txtAccountHolderBOId.Text = custDateTable.Rows[0][2].ToString();
                        LoadDataFromDataTable();
                        EnableAll();
                    }
                    else
                    {
                        MessageBox.Show("No customer found.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                
            }
        }

        private void txtNominee1Percentage_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonBAL commonBal = new CommonBAL();
            commonBal.NumberValidate(txtNominee1Percentage.Text, e);
        }

        private void txtNominee2Percentage_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonBAL commonBal = new CommonBAL();
            commonBal.NumberValidate(txtNominee2Percentage.Text, e);
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            if(txtSearchCustomer.Text.Trim()!="")
                ShowData();
        }

        private void ddlSearchCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "Return")
            {
                if (txtSearchCustomer.Text.Trim() != "")
                    ShowData();
            }
        
        }

        private void txtCustCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "Return")
            {
                LoadSaveInfo();
            }

        }
    }
}
