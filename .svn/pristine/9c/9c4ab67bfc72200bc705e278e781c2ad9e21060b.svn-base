using System;
using System.Data;
using System.Data.Linq;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using BusinessAccessLayer.BO;

namespace StockbrokerProNewArch
{
    public partial class CompanyInfoForm : Form
    {
        /// <summary>
        /// Edit By Rashedul Hasan on 29 july 204
        /// Add Marging Info only
        /// </summary>
        public CompanyInfoForm()
        {
            InitializeComponent();
        }
        private GlobalVariableBO.ModeSelection currentMode = GlobalVariableBO.ModeSelection.NewMode;
        private void CompanyInfoForm_Load(object sender, EventArgs e)
        {
            Init();
            LoadFunctions();

        }

        private void LoadFunctions()
        {
            LoadCompanyCategory();
            LoadCompanySector();

        }

        private void LoadCompanyCategory()
        {
            LoadDDLBAL loadDDLBAL = new LoadDDLBAL();
            DataTable dtData = loadDDLBAL.LoadDDL("SBP_Comp_Category");
            ddlCompCategory.DataSource = dtData;
            ddlCompCategory.DisplayMember = "Comp_Category";
            ddlCompCategory.ValueMember = "Comp_Cat_ID";
            if (ddlCompCategory.HasChildren)
                ddlCompCategory.SelectedIndex = -1;
        }

        private void LoadCompanySector()
        {
            LoadDDLBAL loadDDLBAL = new LoadDDLBAL();
            DataTable dtData = loadDDLBAL.LoadDDL("SBP_Comp_Sector");
            ddlCompSector.DataSource = dtData;
            ddlCompSector.DisplayMember = "SectorName";
            ddlCompSector.ValueMember = "Sector_ID";
            if (ddlCompSector.HasChildren)
                ddlCompSector.SelectedIndex = 0;
        }

        private void Init()
        {
            dtOpenDate.Value = DateTime.Now;
            ddlShareType.SelectedIndex = 0;
             
        }
        private void SaveCompanyInfo()
        {

            if (ddlCompanyShortCode.Text.Trim() == "")
            {
                MessageBox.Show("Fill up the Company Short Code.");
                return;
            }
            if (txtCompName.Text.Trim() == "")
            {
                MessageBox.Show("Fill up the Company Name.");
                return;
            }
            if (txtFaceValue.Text.Trim() == "")
            {
                MessageBox.Show("Fill up the Face Value.");
                return;
            }
            if (txtMarketLot.Text.Trim() == "")
            {
                MessageBox.Show("Fill up the Market Lot.");
                return;
            }
            if (ddlShareType.Text == "CDBL")
            {
                if (txtIssuerId.Text.Trim() == "")
                {
                    MessageBox.Show("Fill up the Issuer ID.");
                    return;
                }
                if (txtISINNo.Text.Trim() == "")
                {
                    MessageBox.Show("Fill up the ISIN No.");
                    return;
                }
            }
            if (chkMargin.Checked==false && chkNonmargin.Checked==false)
            {                
                MessageBox.Show("Please select margin or Non Margin check box", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            
            try
            {
                CompanyBO companyBo = new CompanyBO();
                companyBo.CompanyName = txtCompName.Text;
                companyBo.CompanyShortCode = ddlCompanyShortCode.Text;
                if (ddlCompCategory.SelectedIndex != -1)
                    companyBo.CompanyCategoryID = Convert.ToInt16(ddlCompCategory.SelectedValue);
                companyBo.FaceValue = float.Parse(txtFaceValue.Text);
                companyBo.MarketLot = Convert.ToInt32(txtMarketLot.Text);
                if (ddlShareType.SelectedIndex != -1)
                    companyBo.ShareType = ddlShareType.SelectedItem.ToString();
                companyBo.IssuerId = Convert.ToInt32(txtIssuerId.Text == "" ? 0 : Convert.ToInt32(txtIssuerId.Text));
                companyBo.ISINNo = txtISINNo.Text;
                companyBo.OpeningDate = dtOpenDate.Value;
                companyBo.Remarks = txtRemarks.Text;
                companyBo.CompanySectorID = Int32.Parse(ddlCompSector.SelectedValue.ToString());
                companyBo.CompanyShortNumber = txtCompanyShortCode.Text;
               

                if (chkMargin.Checked)
                {
                    companyBo.IsMargin = true;
                }
                if (chkNonmargin.Checked)
                {
                    companyBo.IsMargin = false;
                }

                switch (currentMode)
                {
                    case GlobalVariableBO.ModeSelection.NewMode:
                        try
                        {
                            if (IsNotExist())
                            {
                                CompanyBAL companyBal = new CompanyBAL();
                                companyBal.Insert(companyBo);
                                MessageBox.Show("Company Information Saved Successfully.","Save Company Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
                                ClearAll();
                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Fail to save Company Information because of the Error : " + ex.Message);
                        }
                        break;
                    case GlobalVariableBO.ModeSelection.UpdateMode:
                        try
                        {
                            //if (IsInputValid())
                            //{
                            CompanyBAL companyBal = new CompanyBAL();
                            if (DialogResult.Yes == MessageBox.Show("Is your information is correct that you have provided?", "Update Company Info", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                            {
                                companyBal.Update(companyBo);
                                MessageBox.Show(ddlCompanyShortCode.Text + " Company Information updated Successfully.", "Update Company Information.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Fail to updated Company Information because of the Error : " + ex.Message);
                        }
                        break;
                }

            }
            catch (Exception exc)
            {

                MessageBox.Show(exc.Message);
            }

        }

        private bool IsNotExist()
        {
            if (IsDuplicateBranchName())
            {
                MessageBox.Show("Company is allready exist.");
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool IsDuplicateBranchName()
        {
            CompanyBAL companyBal = new CompanyBAL();
            if (companyBal.CheckCompanyDuplicate(ddlCompanyShortCode.Text))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            currentMode = GlobalVariableBO.ModeSelection.NewMode;
            btnNew.Enabled = false;
            btnNew.BackColor = Color.Gray;
            btnUpdate.Enabled = true;
            btnUpdate.ResetBackColor();
            ddlCompanyShortCode.DropDownStyle = ComboBoxStyle.DropDown;
            ClearAll();
            EnableAll();
        }

        private void ClearAll()
        {
            chkMargin.Checked = false;
            chkNonmargin.Checked = false;            
            txtRemarks.Text = "";
            txtMarketLot.Text = "";
            txtIssuerId.Text = "";
            txtISINNo.Text = "";
            txtFaceValue.Text = "";
            ddlCompanyShortCode.Text = "";
            txtCompName.Text = "";
            ddlCompCategory.SelectedIndex = 0;
            ddlShareType.SelectedIndex = 0;
            dtOpenDate.Value = DateTime.Now;
            ddlCompanyShortCode.Focus();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            currentMode = GlobalVariableBO.ModeSelection.UpdateMode;
            DisableAll();
            btnUpdate.Enabled = false;
            btnUpdate.BackColor = Color.Gray;
            btnNew.Enabled = true;
            ddlCompanyShortCode.DropDownStyle = ComboBoxStyle.DropDownList;
            btnNew.ResetBackColor();
            ClearAll();
            LoadCompanyShortCode();
            chkNonmargin.Visible = true;
            chkMargin.Visible = true;            

        }

        private void LoadCompanyShortCode()
        {
            LoadDDLBAL loadDDLBAL = new LoadDDLBAL();
            DataTable dtData = loadDDLBAL.LoadDDL("SBP_Company");
            ddlCompanyShortCode.DataSource = dtData;
            ddlCompanyShortCode.DisplayMember = "Comp_Short_Code";
            ddlCompanyShortCode.ValueMember = "Comp_Short_Code";
            if (ddlCompanyShortCode.HasChildren)
                ddlCompanyShortCode.SelectedIndex = -1;
        }

        private void EnableAll()
        {
            txtRemarks.Enabled = true;
            txtMarketLot.Enabled = true;
            txtIssuerId.Enabled = true;
            txtISINNo.Enabled = true;
            txtFaceValue.Enabled = true;
            ddlCompanyShortCode.Enabled = true;
            txtCompName.Enabled = true;
            ddlCompCategory.Enabled = true;
            ddlShareType.Enabled = true;
            dtOpenDate.Enabled = true;
            

        }

        private void DisableAll()
        {
            txtRemarks.Enabled = false;
            txtMarketLot.Enabled = false;
            txtIssuerId.Enabled = false;
            txtISINNo.Enabled = false;
            txtFaceValue.Enabled = false;
            ddlCompanyShortCode.Enabled = true;
            txtCompName.Enabled = false;
            ddlCompCategory.Enabled = false;
            ddlShareType.Enabled = false;
            dtOpenDate.Enabled = false;
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveCompanyInfo();
            CompanyBAL companyBo = new CompanyBAL();
            companyBo.Insert_Dealer_Company();
        }
        private void btnReset_Click(object sender, EventArgs e)
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

        private void txtFaceValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonBAL commonBal = new CommonBAL();
            commonBal.NumberValidate(txtFaceValue.Text, e);
        }

        private void txtMarketLot_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonBAL commonBal = new CommonBAL();
            commonBal.NumberValidate(txtMarketLot.Text, e);
        }

        private void txtIssuerId_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonBAL commonBal = new CommonBAL();
            commonBal.NumberValidate(txtIssuerId.Text, e);
        }

        private void ddlCompanyShortCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (currentMode == GlobalVariableBO.ModeSelection.UpdateMode)
            {
                ddlCompanyShortCode.Enabled = true;
                LoadDataFromDataTable();
            }
        }

        private void LoadDataFromDataTable()
        {
            DataTable companyDataTable = new DataTable();
            CompanyBAL companyBal = new CompanyBAL();
            if (ddlCompanyShortCode.SelectedIndex != -1)
                companyDataTable = companyBal.GetAllData(ddlCompanyShortCode.Text);
            if (companyDataTable.Rows.Count > 0)
            {
                EnableAll();
                txtCompName.Text = companyDataTable.Rows[0]["Comp_Name"].ToString();
                ddlCompCategory.SelectedValue = companyDataTable.Rows[0]["Comp_Cat_ID"];
                ddlCompCategory.Enabled = false;
                ddlShareType.Enabled = false;
                txtFaceValue.Text = companyDataTable.Rows[0]["Face_Value"].ToString();
                txtMarketLot.Text = companyDataTable.Rows[0]["Market_Lot"].ToString();
                ddlShareType.SelectedItem = companyDataTable.Rows[0]["Share_Type"];
                txtIssuerId.Text = companyDataTable.Rows[0]["Issuer_ID"].ToString();
                txtISINNo.Text = companyDataTable.Rows[0]["ISIN_No"].ToString();
                dtOpenDate.Value =Convert.ToDateTime(companyDataTable.Rows[0]["Opening_Date"]);
                txtRemarks.Text = companyDataTable.Rows[0]["Remarks"].ToString();                

                if (companyDataTable.Rows[0]["Sector_ID"] == DBNull.Value || companyDataTable.Rows[0]["Sector_ID"].ToString()=="")
                    ddlCompSector.SelectedIndex=0;
                else
                {
                    ddlCompSector.Text = companyDataTable.Rows[0]["Sector_ID"].ToString();
                }

                txtCompanyShortCode.Text = companyDataTable.Rows[0]["Code_No"].ToString();
                //Added By Rashedul Hasan on 29 july 2015
                string chkMarginNullValue = companyDataTable.Rows.Cast<DataRow>().Select(c => Convert.ToString(c["IsMargin"])).FirstOrDefault();
                if (!string.IsNullOrEmpty(chkMarginNullValue))
                {
                    bool CheckMargin = Convert.ToBoolean(companyDataTable.Rows[0]["IsMargin"].ToString());
                    if (CheckMargin == true)
                    {
                        chkMargin.Checked = true;
                         
                    }
                    else if (CheckMargin == false)
                    {
                        chkNonmargin.Checked = true;                         
                    }
                }
                else
                {
                    chkMargin.Checked = false;
                    chkNonmargin.Checked = false;
                    //MessageBox.Show("Margin or Non Margin is not Define for this company " + txtCompName.Text + " ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                //////////////////////

            }
        }
        /// <summary>
        /// Added By Rashedul Hasan on 29 July 2015
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkMargin_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMargin.Checked)
            {
                chkNonmargin.Checked = false;
            }

        }

        /// <summary>
        /// Added By Rashedul Hasan on 29 July 2015
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkNonmargin_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNonmargin.Checked)
            {
                chkMargin.Checked = false;
            }
        }

        private void ddlShareType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlShareType.Text == "Non-CDBL")
            {
                txtIssuerId.ReadOnly = true;
                txtISINNo.ReadOnly = true;
                txtIssuerId.Enabled = false;
                txtISINNo.Enabled = false;
            }
            else if (ddlShareType.Text == "CDBL")
            {
                txtIssuerId.ReadOnly = false;
                txtISINNo.ReadOnly = false;
                txtIssuerId.Enabled = true;
                txtISINNo.Enabled = true;
            }
        }

        private void btncompanylist_Click(object sender, EventArgs e)
        {
            Margin_Non_Margin_History frm = new Margin_Non_Margin_History();
            frm.ShowDialog(this);
        }

      

       
    }
}
