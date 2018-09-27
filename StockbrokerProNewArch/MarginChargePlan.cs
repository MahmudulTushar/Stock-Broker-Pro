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
    public partial class MarginChargePlan : Form
    {
        private GlobalVariableBO.ModeSelection _currentMode = GlobalVariableBO.ModeSelection.NewMode;
        string CheckCommissionStatus = string.Empty;
        public MarginChargePlan()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void DisableAll()
        {
            txtRemarks.Enabled = false;
            txtMarginRatio.Enabled = false;
            txtFreeAmount.Enabled = false;
            txtEffectiveCount.Enabled = false;
            txtChargeRate.Enabled = false;
            dtEDate.Enabled = false;
            ddlPlanName.Enabled = false;
        }

        private void EnableAll()
        {
            txtRemarks.Enabled = true;
            txtMarginRatio.Enabled = true;
            txtFreeAmount.Enabled = true;
            txtEffectiveCount.Enabled = true;
            txtCustomerCode.Enabled = true;
            txtChargeRate.Enabled = true;
            dtEDate.Enabled = true;
            ddlPlanName.Enabled = true;

            txtCommissionRate.Enabled = true;
        }

        private void ClearAll()
        {
            EnableAll();
            txtCustomerCode.Text = "";
            txtChargeRate.Text = "";
            txtEffectiveCount.Text = "";
            txtFreeAmount.Text = "";
            txtMarginRatio.Text = "";
            txtRemarks.Text = "";
            ddlPlanName.SelectedIndex = 0;

            txtCommissionRate.Text = string.Empty;
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
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _currentMode = GlobalVariableBO.ModeSelection.UpdateMode;
            btnUpdate.Enabled = false;
            btnUpdate.BackColor = Color.Gray;
            btnNew.Enabled = true;
            btnNew.ResetBackColor();
            ClearAll();
            DisableAll();
            txtCustomerCode.Focus();
        }

        private void btnSaveBasicInfo_Click(object sender, EventArgs e)
        {
            if (CheckCommissionStatus == "Yes")
            {
                if (ValidationCheckForCommission())
                    return;
                if (MessageBox.Show("Want To Save Information?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                {
                    SaveMarginPlanInfo();
                    MarginChargePlan_Load(sender, e);
                }
            }
            else
            {
                if (ValidationCheck())
                    return;

                if (MessageBox.Show("Want To Save Information?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                {
                    SaveMarginPlanInfo();
                    MarginChargePlan_Load(sender, e);
                }
            }
        }
        private bool ValidationCheckForCommission()
        {
            if (txtCustomerCode.Text.Trim() == "")
            {
                MessageBox.Show("Please Fill the customer code.");
                txtCustomerCode.Focus();
                return true;
            }
            else return false;
        }
        private bool ValidationCheck()
        {
            if (txtCustomerCode.Text.Trim() == "")
            {
                MessageBox.Show("Please Fill the customer code.");
                txtCustomerCode.Focus();
                return true;
            }

            else if (ddlPlanName.Text.Trim() == "")
            {
                MessageBox.Show("Please Select the Margin Plan.");
                ddlPlanName.Focus();
                return true;
            }
            else if (txtEffectiveCount.Text.Trim() == "")
            {
                MessageBox.Show("Please Fill the Effective Count.");
                txtEffectiveCount.Focus();
                return true;
            }
            else if (txtChargeRate.Text.Trim() == "")
            {
                MessageBox.Show("Please Fill the Charge Rate.");
                txtChargeRate.Focus();
                return true;
            }
            //else if (CheckCommissionStatus == "Yes")
            //{
            //    return true;
            //}

            else return false;
        }

        private void SaveMarginPlanInfo()
        {
            //if(txtCustomerCode.Text.Trim()=="")
            //{
            //    MessageBox.Show("Please Fill the customer code.");
            //    return;
            //}
            //if(ddlPlanName.Text.Trim()=="")
            //{
            //    MessageBox.Show("Please Select the Margin Plan.");
            //    return;
            //}
            //if(txtEffectiveCount.Text.Trim()=="")
            //{
            //    MessageBox.Show("Please Fill the Effective Count.");
            //    return;
            //}
            //if(txtChargeRate.Text.Trim()=="")
            //{
            //    MessageBox.Show("Please Fill the Charge Rate.");
            //    return;
            //}
            //if (txtCommissionRate.Text.Trim() == string.Empty)
            //{
            //    MessageBox.Show("Please Fill The Commission Rate");
            //    txtCommissionRate.Focus();
            //    return;
            //}
            try
            {
                MarginPlanBO marginPlanBo = new MarginPlanBO();
                marginPlanBo.CustCode = txtCustomerCode.Text;
                marginPlanBo.PlanName = ddlPlanName.SelectedItem.ToString();
                if (txtEffectiveCount.Text.Trim() != "")
                    marginPlanBo.EffectiveCount = Convert.ToInt16(txtEffectiveCount.Text);
                if (txtChargeRate.Text.Trim() != "")
                    marginPlanBo.ChargeRate = float.Parse(txtChargeRate.Text);
                if (txtFreeAmount.Text.Trim() != "")
                    marginPlanBo.FreeAmount = float.Parse(txtFreeAmount.Text);
                if (txtMarginRatio.Text.Trim() != "")
                    marginPlanBo.MarginRatio = float.Parse(txtMarginRatio.Text);

                if (!string.IsNullOrEmpty(txtCommissionRate.Text.Trim()))
                    marginPlanBo.CommissionRate = double.Parse(txtCommissionRate.Text.Trim());
                else
                    marginPlanBo.CommissionRate = null;


                marginPlanBo.Remarks = txtRemarks.Text.Trim();
                marginPlanBo.EDate = dtEDate.Value;

                switch (_currentMode)
                {
                    case GlobalVariableBO.ModeSelection.NewMode:
                        try
                        {
                            if (IsInputValid())
                            {
                                MarginPlanBAL marginPlanBal = new MarginPlanBAL();
                                marginPlanBal.Insert(marginPlanBo);
                                MessageBox.Show("Margin Plan Information Saved Successfully.");
                                GetMarginPlanInfo();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Fail to save Margin Plan Information because of the Error : " + ex.Message);
                        }
                        break;
                    case GlobalVariableBO.ModeSelection.UpdateMode:
                        try
                        {
                            MarginPlanBAL marginPlanBal = new MarginPlanBAL();
                            if (CheckCommissionStatus == "Yes")
                            {
                                double doubleTryParse;
                                double comRate = 0.00;
                                if (double.TryParse(txtCommissionRate.Text.Trim(), out doubleTryParse))
                                    comRate = doubleTryParse;

                                marginPlanBal.UpdateCommissionInfo(comRate, txtRemarks.Text.Trim(), txtCustomerCode.Text.Trim());
                                MessageBox.Show("Margin Plan Information Updated Successfully.");
                            }
                            else
                            {

                                marginPlanBal.Update(marginPlanBo);
                                MessageBox.Show("Margin Plan Information Updated Successfully.");
                                GetMarginPlanInfo();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Fail to update Margin Plan Information because of the Error : " + ex.Message);
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
            if (IsExistCustomerCode())
            {
                MessageBox.Show("Customer Code Inavlid.Please try a Valid Customer Code.");
                return false;
            }
            if (IsDuplicateCustomerCode())
            {
                MessageBox.Show("Customer Code Allready exist.Please try a different Customer Code.");
                return false;
            }
            else
            {
                return true;
            }

        }

        private bool IsExistCustomerCode()
        {
            MarginPlanBAL marginPlanBal = new MarginPlanBAL();
            if (marginPlanBal.CheckCustomerCodeExist(txtCustomerCode.Text))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool IsDuplicateCustomerCode()
        {
            MarginPlanBAL marginPlanBal = new MarginPlanBAL();
            if (marginPlanBal.CheckCustomerCodeDuplicate(txtCustomerCode.Text))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void txtCustomerCode_KeyDown(object sender, KeyEventArgs e)
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
                LoadDataFromDataTable();
            }
        }

        private void LoadDataFromDataTable()
        {
            DataTable marginPlanDataTable = new DataTable();
            MarginPlanBAL marginPlanBal = new MarginPlanBAL();
            if (!String.IsNullOrEmpty(txtCustomerCode.Text.Trim()))
                marginPlanDataTable = marginPlanBal.GetAllData(txtCustomerCode.Text);
            if (marginPlanDataTable.Rows.Count > 0)
            {
                txtCustomerCode.Text = marginPlanDataTable.Rows[0]["Cust_Code"].ToString();
                ddlPlanName.Text = marginPlanDataTable.Rows[0]["Plan_Name"].ToString();
                if (marginPlanDataTable.Rows[0]["Effective_Count"] != DBNull.Value)
                    txtEffectiveCount.Text = marginPlanDataTable.Rows[0]["Effective_Count"].ToString();
                if (marginPlanDataTable.Rows[0]["Charge_Rate"] != DBNull.Value)
                    txtChargeRate.Text = marginPlanDataTable.Rows[0]["Charge_Rate"].ToString();

                if (marginPlanDataTable.Rows[0]["Commission_Rate"] != DBNull.Value)
                    txtCommissionRate.Text = marginPlanDataTable.Rows[0]["Commission_Rate"].ToString();

                if (marginPlanDataTable.Rows[0]["Free_Amount"] != DBNull.Value)
                    txtFreeAmount.Text = marginPlanDataTable.Rows[0]["Free_Amount"].ToString();
                if (marginPlanDataTable.Rows[0]["M_Ratio"] != DBNull.Value)
                    txtMarginRatio.Text = marginPlanDataTable.Rows[0]["M_Ratio"].ToString();
                txtRemarks.Text = marginPlanDataTable.Rows[0]["Remark"].ToString();
                if (marginPlanDataTable.Rows[0]["E_Date"] != DBNull.Value)
                    dtEDate.Value = Convert.ToDateTime(marginPlanDataTable.Rows[0]["E_Date"]);

            }
            else
            {
                btnUpdate.Enabled = false;
                btnUpdate.BackColor = Color.Gray;
                btnNew.Enabled = true;
                btnNew.ResetBackColor();
                ClearAll();
                DisableAll();
                MessageBox.Show("Customer code does not exist.");

            }
        }

        private void MarginChargePlan_Load(object sender, EventArgs e)
        {
            ddlPlanName.SelectedIndex = 0;
            GetMarginPlanInfo();
            //OpeningStage();
            ClearAll();
        }

        private void OpeningStage()
        {
            txtCustomerCode.Text = string.Empty;
            txtEffectiveCount.Text = string.Empty;
            txtChargeRate.Text = string.Empty;
            txtCommissionRate.Text = string.Empty;
            txtFreeAmount.Text = string.Empty;
            txtMarginRatio.Text = string.Empty;
            txtRemarks.Text = string.Empty;

            txtCustomerCode.Enabled = true;
            txtEffectiveCount.Enabled = true;
            txtChargeRate.Enabled = true;
            txtCommissionRate.Enabled = true;
            txtFreeAmount.Enabled = true;
            txtMarginRatio.Enabled = true;
            txtRemarks.Enabled = true;
        }

        private void GetMarginPlanInfo()
        {
            try
            {
                MarginPlanBAL objmarginplanBAL = new MarginPlanBAL();
                DataTable data = new DataTable();
                data = objmarginplanBAL.GetmarginPlanData();
                dgvInfo.DataSource = data;
                dgvInfo.Columns["Free Amount"].DefaultCellStyle.Format = "N";
                dgvInfo.Columns["Free Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                dgvInfo.Columns["Effective Date"].DefaultCellStyle.Format = "dd MMM yyyy";
                dgvInfo.Columns["Effective Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void txtEffectiveCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonBAL commonBal = new CommonBAL();
            commonBal.NumberValidate(txtEffectiveCount.Text, e);

            if (e.KeyChar == 13)
            {
                e.Handled = true;
                txtChargeRate.Focus();
            }

        }

        private void txtChargeRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonBAL commonBal = new CommonBAL();
            commonBal.NumberValidate(txtChargeRate.Text, e);

            if (e.KeyChar == 13)
            {
                e.Handled = true;
                txtCommissionRate.Focus();
            }
        }

        private void txtFreeAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonBAL commonBal = new CommonBAL();
            commonBal.NumberValidate(txtFreeAmount.Text, e);

            if (e.KeyChar == 13)
            {
                e.Handled = true;
                txtMarginRatio.Focus();
            }

        }

        //private void txtEffectiveCount_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (ValidationCheck())
        //        return;

        //    if (e.KeyCode.ToString() == "Return")
        //    {
        //        if (MessageBox.Show("Want To Save Information?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
        //        { 
        //            SaveMarginPlanInfo();
        //        }                
        //    }

        //} _currentMode == GlobalVariableBO.ModeSelection.UpdateMode

        private void txtCommissionRate_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCommissionRate.Text.Trim()) && _currentMode==GlobalVariableBO.ModeSelection.NewMode)
            {
                txtEffectiveCount.Text = string.Empty;
                txtChargeRate.Text = string.Empty;
                txtFreeAmount.Text = string.Empty;
                txtMarginRatio.Text = string.Empty;

                txtEffectiveCount.Enabled = false;
                txtChargeRate.Enabled = false;
                txtFreeAmount.Enabled = false;
                txtMarginRatio.Enabled = false;

                CheckCommissionStatus = "Yes";
            }
            else
            { 
                CheckCommissionStatus = string.Empty;
            }
        }

        private void txtCustomerCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                ddlPlanName.Focus();
            }
        }

        private void ddlPlanName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                txtEffectiveCount.Focus();
            }
        }

        private void txtCommissionRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                txtFreeAmount.Focus();

                if (txtFreeAmount.Enabled == false)
                {
                    txtRemarks.Focus();    
                }
                
            }
        }

        private void txtRemarks_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                btnSaveBasicInfo.Focus();
            }
        }

        private void txtMarginRatio_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonBAL commonBal = new CommonBAL();
            commonBal.NumberValidate(txtMarginRatio.Text, e);

            if (e.KeyChar == 13)
            {
                e.Handled = true;
                txtRemarks.Focus();
            }
        }

        //private void txtRemarks_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == 13)
        //    {
        //        e.Handled = true;
        //        btnSaveBasicInfo.Focus();
        //    }
        //}
    }
}
