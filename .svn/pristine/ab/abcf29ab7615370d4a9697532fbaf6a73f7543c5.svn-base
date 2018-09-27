using System;
using System.Data;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using BusinessAccessLayer.BO;

namespace StockbrokerProNewArch
{
    public partial class AdditionalInformationEntryForm : Form
    {
        private GlobalVariableBO.ModeSelection currentModeBO = GlobalVariableBO.ModeSelection.NewMode;
        private GlobalVariableBO.ModeSelection currentModeCustGroup = GlobalVariableBO.ModeSelection.NewMode;
        private GlobalVariableBO.ModeSelection currentModeStatementCycle = GlobalVariableBO.ModeSelection.NewMode;
        private GlobalVariableBO.ModeSelection currentModeCompCategory = GlobalVariableBO.ModeSelection.NewMode;
        private int _bOCategoryID;
        private int _customerGroupID;
        private int _statementCycleID;
        private int _companyCategoryID;

        public AdditionalInformationEntryForm()
        {
            InitializeComponent();
        }

        private void BtnSaveBOCatagory()
        {
            AdditionalInformationBO additionalInformationBo = new AdditionalInformationBO();
            AdditionalInformationBAL additionalInformationBal = new AdditionalInformationBAL();

            switch (currentModeBO)
            {
                case GlobalVariableBO.ModeSelection.NewMode:
                    try
                    {
                        additionalInformationBo.BOCatagory = txtBOCatagory.Text;
                        additionalInformationBal.InsertBoCatagory(additionalInformationBo);
                        btnNewBOCatagory.Enabled = false;
                        btnEditBOCatagory.Enabled = true;
                        MessageBox.Show("BO Category Saved successfully");
                        txtBOCatagory.Text = "";
                        // MessageBox.Show(branchBO.BranchName + " Branch has successfully saved.");

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("BO Category Save unsuccessful because of the error :" + ex.Message);
                    }
                    break;
                case GlobalVariableBO.ModeSelection.UpdateMode:
                    try
                    {
                        additionalInformationBo.BOCatagory = txtBOCatagory.Text;
                        additionalInformationBo.BOCatagoryID = _bOCategoryID;
                        additionalInformationBal.UpdateBOCategory(additionalInformationBo);
                        MessageBox.Show("BO Category Updated successfully");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("BO Category update unsuccessful because of the error :" + ex.Message);
                    }
                    break;
                case GlobalVariableBO.ModeSelection.NoneMode:
                    MessageBox.Show("You have selected none mode.Please select a mode.");
                    break;
            }
        }
        private void BtnSaveCustomerGroup()
        {

            AdditionalInformationBO additionalInformationBo = new AdditionalInformationBO();
            AdditionalInformationBAL additionalInformationBal = new AdditionalInformationBAL();

            switch (currentModeCustGroup)
            {
                case GlobalVariableBO.ModeSelection.NewMode:
                    try
                    {
                        additionalInformationBo.CustomerGroup = txtCustomerGroup.Text;
                        additionalInformationBo.CustomerGroupDescription = txtCustGroupDescription.Text;
                        additionalInformationBal.InsertCustomerGroup(additionalInformationBo);
                        btnNewCustomerGroup.Enabled = false;
                        btnEditCustomerGroup.Enabled = true;
                        MessageBox.Show("Customer Group Saved successfully");
                        txtCustomerGroup.Text = "";
                        txtCustGroupDescription.Text = "";
                        // MessageBox.Show(branchBO.BranchName + " Branch has successfully saved.");

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Customer Group save unsuccessful because of the error :" + ex.Message);
                    }
                    break;
                case GlobalVariableBO.ModeSelection.UpdateMode:
                    try
                    {
                        additionalInformationBo.CustomerGroup = txtCustomerGroup.Text;
                        additionalInformationBo.CustomerGroupDescription = txtCustGroupDescription.Text;
                        additionalInformationBo.CustomerGroupID = _customerGroupID;

                        additionalInformationBal.UpdateCustomerGroup(additionalInformationBo);
                        MessageBox.Show(" Customer Group Updated successfully");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Customer Group update unsuccessful because of the error :" + ex.Message);
                    }
                    break;
                case GlobalVariableBO.ModeSelection.NoneMode:
                    MessageBox.Show("You have select none mode.Please select a mode.");
                    break;
            }
        }
       
        private void BtnSaveCompanyCatagory()
        {
            AdditionalInformationBO additionalInformationBo = new AdditionalInformationBO();
            AdditionalInformationBAL additionalInformationBal = new AdditionalInformationBAL();

            switch (currentModeCompCategory)
            {
                case GlobalVariableBO.ModeSelection.NewMode:
                    try
                    {
                        additionalInformationBo.CompanyCategory = txtCompanyCatagory.Text;
                        additionalInformationBo.CompanyCategoryMinDate = Convert.ToInt16(txtMinimumDate.Text);

                        additionalInformationBal.InsertCompanyCategory(additionalInformationBo);
                        btnNewCompanyCatagory.Enabled = false;
                        btnEditCompanyCatagory.Enabled = true;
                        MessageBox.Show("Company Catagory Saved successfully");
                        txtCompanyCatagory.Text = "";
                        txtMinimumDate.Text = "";
                        // MessageBox.Show(branchBO.BranchName + " Branch has successfully saved.");

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Company Catagory save unsuccessful because of the error :" + ex.Message);
                    }
                    break;
                case GlobalVariableBO.ModeSelection.UpdateMode:
                    try
                    {
                        additionalInformationBo.CompanyCategory = txtCompanyCatagory.Text;
                        additionalInformationBo.CompanyCategoryMinDate = Convert.ToInt16(txtMinimumDate.Text);

                        additionalInformationBo.CompanyCategoryID = _companyCategoryID;

                        additionalInformationBal.UpdateCompanyCategory(additionalInformationBo);
                        MessageBox.Show("Company Catagory Updated successfully");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Company Catagory update unsuccessful because of the error :" + ex.Message);
                    }
                    break;
                case GlobalVariableBO.ModeSelection.NoneMode:
                    MessageBox.Show("You have select none mode.Please select a mode.");
                    break;
            }

        }
       
        private void BtnSaveStatementCycle()
        {
            AdditionalInformationBO additionalInformationBo = new AdditionalInformationBO();
            AdditionalInformationBAL additionalInformationBal = new AdditionalInformationBAL();

            switch (currentModeStatementCycle)
            {
                case GlobalVariableBO.ModeSelection.NewMode:
                    try
                    {
                        additionalInformationBo.StatementCycle = txtStatementCycle.Text;

                        additionalInformationBal.InsertStatementCycle(additionalInformationBo);
                        btnNewStatementCycle.Enabled = false;
                        btnEditStatementCycle.Enabled = true;
                        MessageBox.Show("Statement Cycle Saved successfully");
                        txtStatementCycle.Text = "";
                        // MessageBox.Show(branchBO.BranchName + " Branch has successfully saved.");

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Statement Cycle save unsuccessful because of the error :" + ex.Message);
                    }
                    break;
                case GlobalVariableBO.ModeSelection.UpdateMode:
                    try
                    {
                        additionalInformationBo.StatementCycle = txtStatementCycle.Text;
                        additionalInformationBo.StatementCycleID = _statementCycleID;

                        additionalInformationBal.UpdateStatementCycle(additionalInformationBo);
                        MessageBox.Show("Statement Cycle Updated successfully");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Statement Cycle update unsuccessful because of the error :" + ex.Message);
                    }
                    break;
                case GlobalVariableBO.ModeSelection.NoneMode:
                    MessageBox.Show("You have select none mode.Please select a mode.");
                    break;
            }
        }

      

        //For Loading each value

        private void LoadBOCategory()
        {
            AdditionalInformationBAL additionalInformationBAL = new AdditionalInformationBAL();

            DataTable dataTableBOCategory = new DataTable();

            dataTableBOCategory = additionalInformationBAL.GetBOCategory();
            dtgBOCategory.DataSource = dataTableBOCategory;
            this.dtgBOCategory.Columns[0].Visible = false;
            dtgBOCategory.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

        }
      


        private void LoadCustomerGroup()
        {
            AdditionalInformationBAL additionalInformationBAL = new AdditionalInformationBAL();

            DataTable dataTableCustomerGroup = new DataTable();
            dataTableCustomerGroup = additionalInformationBAL.GetCustomerGroup();
            dtgCustomerGroup.DataSource = dataTableCustomerGroup;
            this.dtgCustomerGroup.Columns[0].Visible = false;
            dtgCustomerGroup.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

        }

        private void LoadStatementCycle()
        {
            AdditionalInformationBAL additionalInformationBAL = new AdditionalInformationBAL();

            DataTable dataTableStatementCycle = new DataTable();
            dataTableStatementCycle = additionalInformationBAL.GetStatementCycle();
            dtgStatementCycle.DataSource = dataTableStatementCycle;
            this.dtgStatementCycle.Columns[0].Visible = false;
            dtgStatementCycle.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

        }

        private void LoadCompanyCategory()
        {
            AdditionalInformationBAL additionalInformationBAL = new AdditionalInformationBAL();

            DataTable dataTableCompanyCategory = new DataTable();
            dataTableCompanyCategory = additionalInformationBAL.GetCompanyCategory();
            dtgCompanyCategory.DataSource = dataTableCompanyCategory;
            this.dtgCompanyCategory.Columns[0].Visible = false;
            dtgCompanyCategory.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

        }
     
        private void btnNewBOCatagory_Click(object sender, EventArgs e)
        {
            currentModeBO = GlobalVariableBO.ModeSelection.NewMode;
            txtBOCatagory.Text = "";
            btnNewBOCatagory.Enabled = false;
            btnEditBOCatagory.Enabled = true;
            btnSaveBOCategory.Enabled = true;
        }

      

        private void btnNewCustomerGroup_Click(object sender, EventArgs e)
        {
            currentModeCustGroup = GlobalVariableBO.ModeSelection.NewMode;
            txtCustomerGroup.Text = "";
            txtCustGroupDescription.Text = "";
            btnNewCustomerGroup.Enabled = false;
            btnEditCustomerGroup.Enabled = true;
            btnSaveCustGroup.Enabled = true;
        }

        private void btnNewStatementCycle_Click(object sender, EventArgs e)
        {
            currentModeStatementCycle = GlobalVariableBO.ModeSelection.NewMode;
            txtStatementCycle.Text = "";
            btnNewStatementCycle.Enabled = false;
            btnEditStatementCycle.Enabled = true;
            btnSaveStateCycle.Enabled = true;
        }

        private void btnNewCompanyCatagory_Click(object sender, EventArgs e)
        {
            currentModeCompCategory = GlobalVariableBO.ModeSelection.NewMode;
            txtCompanyCatagory.Text = "";
            txtMinimumDate.Text = "";
            btnNewCompanyCatagory.Enabled = false;
            btnEditCompanyCatagory.Enabled = true;
            btnSaveCompCategory.Enabled = true;
        }

      
        private void btnEditBOCatagory_Click(object sender, EventArgs e)
        {

            btnEditBOCatagory.Enabled = false;
            btnNewBOCatagory.Enabled = true;
            foreach (DataGridViewRow row in this.dtgBOCategory.SelectedRows)
            {
                _bOCategoryID = Convert.ToInt16(dtgBOCategory[0, row.Index].Value);
                txtBOCatagory.Text = dtgBOCategory[1, row.Index].Value.ToString();
            }
            currentModeBO = GlobalVariableBO.ModeSelection.UpdateMode;
        }

        private void btnEditCustomerGroup_Click(object sender, EventArgs e)
        {
            btnEditCustomerGroup.Enabled = false;
            btnNewCustomerGroup.Enabled = true;
            foreach (DataGridViewRow row in this.dtgCustomerGroup.SelectedRows)
            {
                _customerGroupID = Convert.ToInt16(dtgCustomerGroup[0, row.Index].Value);
                txtCustomerGroup.Text = dtgCustomerGroup[1, row.Index].Value.ToString();
                txtCustGroupDescription.Text = dtgCustomerGroup[2, row.Index].Value.ToString();

            }
            currentModeCustGroup = GlobalVariableBO.ModeSelection.UpdateMode;
        }

        private void btnEditStatementCycle_Click(object sender, EventArgs e)
        {

            btnEditStatementCycle.Enabled = false;
            btnNewStatementCycle.Enabled = true;
            foreach (DataGridViewRow row in this.dtgStatementCycle.SelectedRows)
            {
                _statementCycleID = Convert.ToInt16(dtgStatementCycle[0, row.Index].Value);
                txtStatementCycle.Text = dtgStatementCycle[1, row.Index].Value.ToString();

            }
            currentModeStatementCycle = GlobalVariableBO.ModeSelection.UpdateMode;
        }

        private void btnEditCompanyCatagory_Click(object sender, EventArgs e)
        {
            btnEditCompanyCatagory.Enabled = false;
            btnNewCompanyCatagory.Enabled = true;
            foreach (DataGridViewRow row in this.dtgCompanyCategory.SelectedRows)
            {
                _companyCategoryID = Convert.ToInt16(dtgCompanyCategory[0, row.Index].Value);
                txtCompanyCatagory.Text = dtgCompanyCategory[1, row.Index].Value.ToString();
                txtMinimumDate.Text = dtgCompanyCategory[2, row.Index].Value.ToString();

            }
            currentModeCompCategory = GlobalVariableBO.ModeSelection.UpdateMode;
        }
        
        private void btnSaveBOCategory_Click(object sender, EventArgs e)
        {
            BtnSaveBOCatagory();
            LoadBOCategory();
        }
        private void AdditionalInformationEntryForm_Load(object sender, EventArgs e)
        {
            btnNewBOCatagory.Enabled = false;
            
            btnNewCompanyCatagory.Enabled = false;
            btnNewCustomerGroup.Enabled = false;

            btnNewStatementCycle.Enabled = false;

            //// To show BO category
            LoadBOCategory();
         

            //// To show Customer Group
            LoadCustomerGroup();

            //// To show StatementCycle
            LoadStatementCycle();

            //// To show Company Category
            LoadCompanyCategory();
            //// To show order channel

            //// To show Reference Type
            //LoadReferenceType();
            //// To show Payment Media
           
          }

        private void btnSaveCompCategory_Click(object sender, EventArgs e)
        {
            BtnSaveCompanyCatagory();
            LoadCompanyCategory();
            
        }

        private void btnSaveCustGroup_Click(object sender, EventArgs e)
        {
            BtnSaveCustomerGroup();
            LoadCustomerGroup();
        }

        private void btnSaveStateCycle_Click(object sender, EventArgs e)
        {
            BtnSaveStatementCycle();
            LoadStatementCycle();
            
        }

        private void dtgCompanyCategory_SelectionChanged(object sender, EventArgs e)
        {
            if (currentModeCompCategory == GlobalVariableBO.ModeSelection.UpdateMode)
            {
                btnSaveCompCategory.Enabled = true;
                //btnEditBOCatagory.Enabled = true;
                btnNewCompanyCatagory.Enabled = true;
                foreach (DataGridViewRow row in this.dtgCompanyCategory.SelectedRows)
                {
                    _companyCategoryID = Convert.ToInt16(dtgCompanyCategory[0, row.Index].Value);
                    txtCompanyCatagory.Text = dtgCompanyCategory[1, row.Index].Value.ToString();
                    txtMinimumDate.Text = dtgCompanyCategory[2, row.Index].Value.ToString();
                }
                
            }
        }

        private void dtgStatementCycle_SelectionChanged(object sender, EventArgs e)
        {
            if (currentModeStatementCycle == GlobalVariableBO.ModeSelection.UpdateMode)
            {
                btnSaveStateCycle.Enabled = true;
                //btnEditBOCatagory.Enabled = true;
                btnNewStatementCycle.Enabled = true;
                foreach (DataGridViewRow row in this.dtgStatementCycle.SelectedRows)
                {
                    _statementCycleID = Convert.ToInt16(dtgStatementCycle[0, row.Index].Value);
                    txtStatementCycle.Text = dtgStatementCycle[1, row.Index].Value.ToString();
                }
            }
        }

        private void dtgCustomerGroup_SelectionChanged(object sender, EventArgs e)
        {
            if (currentModeCustGroup == GlobalVariableBO.ModeSelection.UpdateMode)
            {
                btnSaveCustGroup.Enabled = true;
                //btnEditBOCatagory.Enabled = true;
                btnNewCustomerGroup.Enabled = true;
                foreach (DataGridViewRow row in this.dtgCustomerGroup.SelectedRows)
                {
                    _customerGroupID = Convert.ToInt16(dtgCustomerGroup[0, row.Index].Value);
                    txtCustomerGroup.Text = dtgCustomerGroup[1, row.Index].Value.ToString();
                    txtCustGroupDescription.Text = dtgCustomerGroup[2, row.Index].Value.ToString();
                }
            }
        }

        private void dtgBOCategory_SelectionChanged(object sender, EventArgs e)
        {
            if (currentModeBO == GlobalVariableBO.ModeSelection.UpdateMode)
            {
                btnSaveBOCategory.Enabled = true;
                btnNewBOCatagory.Enabled = true;
                foreach (DataGridViewRow row in this.dtgBOCategory.SelectedRows)
                {
                    _bOCategoryID = Convert.ToInt16(dtgBOCategory[0, row.Index].Value);
                    txtBOCatagory.Text = dtgBOCategory[1, row.Index].Value.ToString();
                }
            }
        }

       

      
    }
}

