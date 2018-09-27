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
    public partial class CashbackPlan : Form
    {
        private GlobalVariableBO.ModeSelection _currentMode = GlobalVariableBO.ModeSelection.NewMode;
        private int PlanId = 0;
        public CashbackPlan()
        {
            InitializeComponent();
        }

        //private void btnCancel_Click(object sender, EventArgs e)
        //{
        //    this.Close();
        //}

        //private void btnSave_Click(object sender, EventArgs e)
        //{
        //    SaveCashbackPlan();
        //    LoadPlanNameDDL();
        //}

        //private void SaveCashbackPlan()
        //{
        //    if (txtPlanName.Text.Trim() == "")
        //    {
        //        MessageBox.Show("Please Fill the Plan Name.");
        //        return;
        //    }
        //    CashbackPlanBO cashBackPlanBo = new CashbackPlanBO();
        //    cashBackPlanBo.PlanName = txtPlanName.Text;
        //    cashBackPlanBo.Description = txtDescription.Text;
        //    cashBackPlanBo.PlanDate = dtPlanDate.Value;
        //    try
        //    {
        //        CashBackPlanBAL cashBackPlanBal = new CashBackPlanBAL();
        //        cashBackPlanBal.Insert(cashBackPlanBo);
        //        MessageBox.Show("Cashback Plan Information Saved Successfully.");
        //        LoadGridData();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Fail to save Cashback Plan  Information because of the Error : " + ex.Message);
        //    }
        //}

        //private void LoadGridData()
        //{
        //    CashBackPlanBAL cashBackPlanBal = new CashBackPlanBAL();
        //    DataTable datatable = cashBackPlanBal.GetGridInfo();
        //    dtgCashBackPlanInfo.DataSource = datatable;
        //    dtgCashBackPlanInfo.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        //}

        private enum ExecutionMode
        {
            New
           ,
            Save
                ,
            Update
                ,
            Reset
                , Close
        }
        private void CashbackPlan_Load(object sender, EventArgs e)
        {
            //  LoadPlanNameDDL();
            //  LoadGridData();
            LoadCriteriaGridData();
            SetExecutionMode(ExecutionMode.New);
            txtPlan_Name.Focus();


        }
        private void SetExecutionMode(ExecutionMode execMode)
        {
            switch (execMode)
            {
                case ExecutionMode.New:
                    {
                        _currentMode = GlobalVariableBO.ModeSelection.NewMode;
                        EnableAll();
                        ClearAll();
                        btnNew.Enabled = false;
                        btnNew.BackColor = Color.Gray;
                        btnUpdate.Enabled = true;
                        btnUpdate.ResetBackColor();
                        //btnSaveBasicInfo.Enabled = true;
                        //btnResetBasicInfo.Enabled = true;
                        //btnClose.Enabled = true;
                        txtPlanID.Enabled = false;
                        txtPlan_Name.Focus();
                    }
                    break;
                case ExecutionMode.Save:
                    {

                    }
                    break;
                case ExecutionMode.Update:
                    {
                        _currentMode = GlobalVariableBO.ModeSelection.UpdateMode;
                        ClearAll();
                        DisableAll();
                        btnUpdate.Enabled = false;
                        btnUpdate.BackColor = Color.Gray;
                        btnNew.Enabled = true;
                        btnNew.ResetBackColor();
                        //btnSaveBasicInfo.Enabled = true;
                        //btnResetBasicInfo.Enabled = true;
                        //btnClose.Enabled = true;
                        txtPlanID.Enabled = true;
                        txtPlanID.Focus();
                        if (PlanId != 0)
                        {
                            txtPlanID.Text = PlanId.ToString();
                            LoadSelectedInformation();
                        }
                    }
                    break;
                case ExecutionMode.Reset:
                    {
                        if (_currentMode == GlobalVariableBO.ModeSelection.UpdateMode)
                        {
                            ClearAll();
                            DisableAll();
                            txtPlanID.Enabled = true;
                            txtPlanID.Focus();
                        }
                        else
                        {
                            ClearAll();
                            EnableAll();
                            txtPlanID.Enabled = false;
                            txtPlan_Name.Focus();
                        }
                        //btnNew.Enabled = true;
                        //btnNew.ResetBackColor();
                        //btnSaveBasicInfo.Enabled = true;
                        //btnUpdate.Enabled = true;
                        //btnResetBasicInfo.Enabled = true;
                        //btnClose.Enabled = true;
                        //txtProcessID.Enabled = false;
                        //ClearAll();
                        //EnableAll();
                    }
                    break;
                case ExecutionMode.Close:
                    {

                    }
                    break;
            }
        }

        private void EnableAll()
        {
            txtPlan_Name.Enabled = true;
            txtDescription.Enabled = true;
            dtPlanDate.Enabled = true;
            txtMinTradeAmount.Enabled = true;
            txtRate.Enabled = true;
            dtEffectiveDate.Enabled = true;
        }

        private void DisableAll()
        {
            txtPlan_Name.Enabled = false;
            txtDescription.Enabled = false;
            dtPlanDate.Enabled = false;
            txtMinTradeAmount.Enabled = false;
            txtRate.Enabled = false;
            dtEffectiveDate.Enabled = false;
        }
        private void ClearAll()
        {
            txtPlanID.Text = "";
            txtPlan_Name.Text = "";
            txtDescription.Text = "";
            dtPlanDate.Value = DateTime.Today;
            txtMinTradeAmount.Text = "";
            txtRate.Text = "";
            dtEffectiveDate.Value = DateTime.Today;
        }

        private void ResetNewMode()
        {
            txtPlanID.Enabled = false;
            txtPlan_Name.Enabled = true;
            txtDescription.Enabled = true;
            dtPlanDate.Enabled = true;
            txtMinTradeAmount.Enabled = true;
            txtRate.Enabled = true;
            dtEffectiveDate.Enabled = true;
            txtPlan_Name.Focus();
        }
        private void ResetUpdateMode()
        {
            txtPlanID.Enabled = true;
            txtPlan_Name.Enabled = false;
            txtDescription.Enabled = false;
            dtPlanDate.Enabled = false;
            txtMinTradeAmount.Enabled = false;
            txtRate.Enabled = false;
            dtEffectiveDate.Enabled = false;
            txtPlanID.Focus();
        }
        private void LoadCriteriaGridData()
        {
            CashBackPlanBAL cashBackPlanBal = new CashBackPlanBAL();
            DataTable dtCriteria = cashBackPlanBal.GetCriteriaGridInfo();
            dtgPlanCriteriaInfo.DataSource = dtCriteria;
            dtgPlanCriteriaInfo.Columns[0].Width = 30;
            dtgPlanCriteriaInfo.Columns["Trd Amount"].DefaultCellStyle.Format = "N";
            dtgPlanCriteriaInfo.Columns["Rate"].DefaultCellStyle.Format = "N";
            dtgPlanCriteriaInfo.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgPlanCriteriaInfo.Columns[4].Width = 90;
            dtgPlanCriteriaInfo.Columns[5].Width = 40;
            dtgPlanCriteriaInfo.Columns[6].Width = 70;

        }

        //private void LoadPlanNameDDL()
        //{
        //    LoadDDLBAL loadDDLBAL = new LoadDDLBAL();
        //    DataTable dtData = loadDDLBAL.LoadDDL("SBP_Cashback_Plans");
        //    ddlPlanName.DataSource = dtData;
        //    ddlPlanName.DisplayMember = "Plan_Name";
        //    if (ddlPlanName.HasChildren)
        //        ddlPlanName.SelectedIndex = 0;
        //}

        private void btnCloseCashBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSaveCashBack_Click(object sender, EventArgs e)
        {
            SaveCashback();
        }
        private bool IsValid()
        {
            bool result = true;
            if (txtPlan_Name.Text.Trim() == "")
            {
                //MessageBox.Show("Please Fill the Plan Name.");
                result = false;
            }
            if (txtMinTradeAmount.Text.Trim() == "")
            {
                // MessageBox.Show("Please Fill theMinimum Trade Amount.");
                result = false;
            }
            if (txtRate.Text.Trim() == "")
            {
                // MessageBox.Show("Please Fill the Rate.");
                result = false;
            }
            return result;
        }
        private CashbackCriteriaBO SetBO()
        {
            CashbackCriteriaBO cashBackCriteriaBo = new CashbackCriteriaBO();
            if (txtPlanID.Text != "")
            {
                cashBackCriteriaBo.ID = Convert.ToInt32(txtPlanID.Text.Trim());
            }
            cashBackCriteriaBo.PlanName = txtPlan_Name.Text;
            cashBackCriteriaBo.PlanDescription = txtDescription.Text;
            cashBackCriteriaBo.PlanDate = Convert.ToDateTime(dtPlanDate.Value.ToString("yyyy-MM-dd"));
            cashBackCriteriaBo.MinTradeAmount = float.Parse(txtMinTradeAmount.Text);
            cashBackCriteriaBo.Rate = float.Parse(txtRate.Text);
            cashBackCriteriaBo.EffectiveDate = Convert.ToDateTime(dtEffectiveDate.Value.ToString("yyyy-MM-dd"));
            return cashBackCriteriaBo;
        }
        private void SaveCashback()
        {
            CashbackCriteriaBO cashBackCriteriaBo = new CashbackCriteriaBO();
            try
            {
                cashBackCriteriaBo = SetBO();
                switch (_currentMode)
                {
                    case GlobalVariableBO.ModeSelection.NewMode:
                        try
                        {
                            if (IsValid())
                            {

                                CashBackPlanBAL cashBackPlanBal = new CashBackPlanBAL();
                                cashBackPlanBal.InsertCriteria(cashBackCriteriaBo);
                                ClearAll();
                                ResetNewMode();
                                MessageBox.Show("Cashback Plan Criteria Information Saved Successfully.");
                                LoadCriteriaGridData();
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                        break;
                    case GlobalVariableBO.ModeSelection.UpdateMode:
                        try
                        {
                            if (IsValid())
                            {
                                CashBackPlanBAL cashBackPlanBal = new CashBackPlanBAL();
                                cashBackPlanBal.UpdateCashBackPlan(cashBackCriteriaBo);
                                MessageBox.Show(@"Data Updated Successfully");
                                ClearAll();
                                ResetUpdateMode();
                                LoadCriteriaGridData();
                                // SetExecutionMode(ExecutionMode.Update);
                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(@"Fail to update Information, because of the Error : " + ex.Message);
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fail to save Cashback Plan Criteria Information because of the Error : " +
                                ex.Message);
            }
        }

        private void txtMinTradeAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonBAL commonBal = new CommonBAL();
            commonBal.NumberValidate(txtMinTradeAmount.Text, e);
        }

        private void txtRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonBAL commonBal = new CommonBAL();
            commonBal.NumberValidate(txtRate.Text, e);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SetExecutionMode(ExecutionMode.Update);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            SetExecutionMode(ExecutionMode.New);
        }

        private void btnResetBasicInfo_Click(object sender, EventArgs e)
        {
            SetExecutionMode(ExecutionMode.Reset);
        }

        private void txtPlanID_KeyDown(object sender, KeyEventArgs e)
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
                txtPlanID.Enabled = false;
                LoadDataFromDataTable();

            }
        }

        private void LoadDataFromDataTable()
        {
            DataTable dtProcessList = new DataTable();
            CashBackPlanBAL cashBackPlanBal = new CashBackPlanBAL();
            if (!String.IsNullOrEmpty(txtPlanID.Text.Trim()))
                dtProcessList = cashBackPlanBal.GetPlanInfoByPlanID(Int32.Parse(txtPlanID.Text.Trim()));
            if (dtProcessList.Rows.Count > 0)
            {
                // txtCustomerCode.Text = dtCashBack.Rows[0]["Cust_Code"].ToString();
                txtPlan_Name.Text = dtProcessList.Rows[0]["Plan Name"].ToString();
                txtDescription.Text = dtProcessList.Rows[0]["Description"].ToString();
                dtPlanDate.Value = Convert.ToDateTime(dtProcessList.Rows[0]["Plan_Date"]);
                txtMinTradeAmount.Text = dtProcessList.Rows[0]["Min Trade Amount"].ToString();
                txtRate.Text = dtProcessList.Rows[0]["Rate"].ToString();
                dtEffectiveDate.Value = Convert.ToDateTime(dtProcessList.Rows[0]["Effective Date"]);
            }
            else
            {
                btnUpdate.Enabled = false;
                btnUpdate.BackColor = Color.Gray;
                btnNew.Enabled = true;
                btnNew.ResetBackColor();
                ClearAll();
                DisableAll();
                MessageBox.Show("Process Name does not exist.");

            }
        }

        private void txtPlanID_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonBAL commonBal = new CommonBAL();
            commonBal.NumberValidate(txtRate.Text, e);
        }

        private void dtgPlanCriteriaInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dtgPlanCriteriaInfo.CurrentRow;
                PlanId = int.Parse(dr.Cells[0].Value.ToString());
            }
            catch
            {

            }
        }
    }
}
