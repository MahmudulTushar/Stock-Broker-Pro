using System;
using System.Data;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using BusinessAccessLayer.BO;
using System.Collections.Generic;
using BusinessAccessLayer.BAL;
using BusinessAccessLayer.BO;
using CrystalDecisions.CrystalReports.Engine;
using Reports;

namespace StockbrokerProNewArch
{
    public partial class CashBackReg : Form
    {
        private GlobalVariableBO.ModeSelection _currentMode = GlobalVariableBO.ModeSelection.NewMode;
        CashBackRegBAL cashBackRegBAL = new CashBackRegBAL();
        CashBackRegBO cashBackRegBO = new CashBackRegBO();

        bool isEditedByEvent_Percantage=false;
        bool isEditedByEvent_PCashBackAmount = false;
        private double cashbackAmountBeforeEdit;
        bool isErrorOccured = false;


        private string _custcode;
        int _deleteId;
        public CashBackReg()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnResetBasicInfo_Click(object sender, EventArgs e)
        {
            //if (_currentMode == GlobalVariableBO.ModeSelection.UpdateMode)
            //{
            //    ClearAll();
            //    DisableAll();
            //    txtCustomerCode.Focus();
            //}
            //else
            //{
            //    ClearAll();
            //    EnableAll();
            //    txtCustomerCode.Focus();
            //}
        }

        private void EnableAll()
        {
            //txtCustomerCode.Enabled = true;
            //ddlPlanName.Enabled = true;
            //txtRemarks.Enabled = true;
            //dtpEntryDate.Enabled = true;
        }

        private void DisableAll()
        {
            //ddlPlanName.Enabled = false;
            //txtRemarks.Enabled = false;
            //dtpEntryDate.Enabled = false;
        }

        private void ClearAll()
        {
            ////EnableAll();
            //txtCustomerCode.Text = "";
            //ddlPlanName.SelectedIndex = -1;
            //ddlSessionName.SelectedIndex = -1;
            //dtpEntryDate.Value = DateTime.Today;
            //txtCashBackAmount.Text = string.Empty;
            //txtRemarks.Text = "";
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            //_currentMode = GlobalVariableBO.ModeSelection.NewMode;
            //btnNew.Enabled = false;
            //btnNew.BackColor = Color.Gray;
            //btnUpdate.Enabled = true;
            //btnUpdate.ResetBackColor();
            //ClearAll();
            //txtCustomerCode.Focus();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //_currentMode = GlobalVariableBO.ModeSelection.UpdateMode;
            //btnUpdate.Enabled = false;
            //btnUpdate.BackColor = Color.Gray;
            //btnNew.Enabled = true;
            //btnNew.ResetBackColor();
            //ClearAll();
            //DisableAll();
            //txtCustomerCode.Focus();
        }

        private void btnSaveBasicInfo_Click(object sender, EventArgs e)
        {
            //SaveCashBackReg();
            int sessionId, planId;

            List<CashBackRegBO> cashBackRegBos = new List<CashBackRegBO>();
            try
            {
                sessionId = Convert.ToInt32(ddlSessionName.SelectedValue.ToString());
                planId = Convert.ToInt32(ddlPlanName.SelectedValue.ToString());

                if (dgvCashBackRegEditInfo.Rows.Count > 0)
                {
                    foreach (DataGridViewRow dgvrow in dgvCashBackRegEditInfo.Rows)
                    {

                        if ((bool)dgvrow.Cells["Select"].EditedFormattedValue)
                        {
                            CashBackRegBO cashBackRegBo = new CashBackRegBO();
                            cashBackRegBo.SessionId = Convert.ToInt32(ddlSessionName.SelectedValue.ToString());
                            cashBackRegBo.PlanId = Convert.ToInt32(ddlPlanName.SelectedValue.ToString());
                            cashBackRegBo.PlanName = ddlPlanName.Text;

                            cashBackRegBo.CustCode = dgvrow.Cells["Cust_Code"].EditedFormattedValue.ToString();
                            cashBackRegBo.CashBackAmount = double.Parse(dgvrow.Cells["ProposedCBAmount"].EditedFormattedValue.ToString());
                            cashBackRegBo.Remarks = dgvrow.Cells["Remarks"].EditedFormattedValue.ToString();
                            cashBackRegBos.Add(cashBackRegBo);
                        }

                    }
                }
                if (cashBackRegBos.Count > 0)
                {
                    SaveData(cashBackRegBos);
                    MessageBox.Show("Data Saved Successfully");
                    GetPossibleCandidateCashbackWithData(sessionId, planId, dtpStartDate.Value, dtpEndDate.Value);
                    cashBackRegBos.Clear();
                    GetCashbackRegi();
                }
                else
                {
                    MessageBox.Show("Please select item");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void SaveData(List<CashBackRegBO> cashBackRegBos)
        {
            CashBackRegBAL cashBackRegBal = new CashBackRegBAL();
            cashBackRegBal.SaveData(cashBackRegBos);
        }
        //private bool IsValidData()
        //{
        //    bool result = true;
        //    if (txtCustomerCode.Text.Trim() == "")
        //    {
        //        throw new Exception("Please Fill the customer code.");
        //    }
        //    if (ddlPlanName.Text.Trim() == "")
        //    {
        //        throw new Exception("Please Select a Plan Name."); 
        //    }
        //    if (ddlSessionName.Text.Trim() == "")
        //    {
        //        throw new Exception("Please Select a Session Name.");
        //    }
        //    if (txtCashBackAmount.Text.Trim() == "")
        //    {
        //        throw new Exception("Please Give Cash Back Amount.");
        //    }
        //    return result;
        //}
        private CashBackRegBO SetBO()
        {
            CashBackRegBO cashBackRegBo = new CashBackRegBO();
            //            cashBackRegBo.CustCode = txtCustomerCode.Text;
            cashBackRegBo.SessionId = Convert.ToInt32(ddlSessionName.SelectedValue.ToString());
            cashBackRegBo.PlanName = ddlPlanName.Text;
            // cashBackRegBo.EffectiveDate = dtEffectiveDate.Value;
            //            cashBackRegBo.EntryDate = dtpEntryDate.Value.ToString("dd-MM-yyyy");
            //            cashBackRegBo.CashBackAmount = double.Parse(txtCashBackAmount.Text.Trim());
            //            cashBackRegBo.Remarks = txtRemarks.Text;
            return cashBackRegBo;
        }
        private void SaveCashBackReg()
        {

            try
            {
                CashBackRegBO cashBackRegBo = new CashBackRegBO();
                cashBackRegBo = SetBO();
                switch (_currentMode)
                {
                    case GlobalVariableBO.ModeSelection.NewMode:
                        try
                        {
                            if (IsInputValid())
                            {
                                CashBackRegBAL cashBackRegBal = new CashBackRegBAL();
                                cashBackRegBal.Insert(cashBackRegBo);
                                MessageBox.Show("Cashback Registration has been done Successfully.");
                                ClearAll();
                                GetCashbackRegi();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Fail to save Cashback Registration Information because of the Error : " + ex.Message);
                        }
                        break;
                    case GlobalVariableBO.ModeSelection.UpdateMode:
                        try
                        {
                            CashBackRegBAL cashBackRegBal = new CashBackRegBAL();
                            cashBackRegBal.Update(cashBackRegBo);
                            MessageBox.Show("Cashback Registration Information Updated Successfully.");
                            GetCashbackRegi();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Fail to update Cashback Registration Information, because of the Error : " + ex.Message);
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
            if (ddlSessionName.Text.Trim() == "")
            {
                MessageBox.Show("Please Select a Session Name.");
                return false;
            }
            //           if (txtCashBackAmount.Text.Trim() == "")
            {
                MessageBox.Show("Please Give Cash Back Amount.");
                return false;
            }
            //else
            //{
            //    return true;
            //}

        }

        private bool IsDuplicateCustomerCode()
        {
            CashBackRegBAL cashBackRegBal = new CashBackRegBAL();
            //     if (cashBackRegBal.CheckCustomerCodeDuplicate(txtCustomerCode.Text))
            {
                return true;
            }
            //else
            //{
            //    return false;
            //}
        }

        private bool IsExistCustomerCode()
        {
            CashBackRegBAL cashBackRegBal = new CashBackRegBAL();
            //          if (cashBackRegBal.CheckCustomerCodeExist(txtCustomerCode.Text))
            {
                return false;
            }
            //else
            //{
            //    return true;
            //}

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
                //          txtCustomerCode.Enabled = false;
                LoadDataFromDataTable();

            }
        }

        private void LoadDataFromDataTable()
        {
            DataTable dtCashBack = new DataTable();
            CashBackRegBAL cashBackRegBal = new CashBackRegBAL();
            //       if (!String.IsNullOrEmpty(txtCustomerCode.Text.Trim()))
            //           dtCashBack = cashBackRegBal.GetAllData(txtCustomerCode.Text);
            if (dtCashBack.Rows.Count > 0)
            {
                // txtCustomerCode.Text = dtCashBack.Rows[0]["Cust_Code"].ToString();
                ddlSessionName.SelectedValue = dtCashBack.Rows[0]["CashBack_SessionID"].ToString();
                ddlPlanName.SelectedValue = dtCashBack.Rows[0]["Plan_Name"].ToString();
                //            txtCashBackAmount.Text = dtCashBack.Rows[0]["CashBack_Amount"].ToString();
                //            txtRemarks.Text = dtCashBack.Rows[0]["Remark"].ToString();
                //            dtpEntryDate.Value = Convert.ToDateTime(dtCashBack.Rows[0]["Entry_Date"]);
            }
            else
            {
                //btnUpdate.Enabled = false;
                //btnUpdate.BackColor = Color.Gray;
                //btnNew.Enabled = true;
                //btnNew.ResetBackColor();
                ClearAll();
                DisableAll();
                MessageBox.Show("Customer code does not exist.");

            }
        }
        private void LoadCashBackRegEditGridData()
        {
            int sessionId, planId;
            DataTable data = new DataTable();
            CashBackRegBAL objCashBackRegi = new CashBackRegBAL();
            try
            {
                sessionId = Convert.ToInt32(ddlSessionName.SelectedValue.ToString());
                planId = Convert.ToInt32(ddlPlanName.SelectedValue.ToString());
                data = objCashBackRegi.GetCashBackRegEditGridData(sessionId, planId);
                dgvCashBackRegEditInfo.DataSource = data;
            }
            catch
            {

            }
        }

        private void CashBackReg_Load(object sender, EventArgs e)
        {
            LoadPlanNameDDL();
            LoadSessionName();
           // GetCashbackRegi();
            //  LoadCashBackRegEditGridData();
        }

        private void GetCashbackRegi()
        {
            try
            {
                DataTable data = new DataTable();
                CashBackRegBAL objCashBackRegi = new CashBackRegBAL();
                int _sessionID = 0;
                _sessionID = Convert.ToInt32(ddlSessionName.SelectedValue.ToString());
                data = objCashBackRegi.GetCashBackRegi(_sessionID);
                dgvCashbackLoadInfo.DataSource = data;
                dgvCashbackLoadInfo.Columns["ID"].Visible = false;//Cust Code.DefaultCellStyle.Format = "dd MMM yyyy";
                dgvCashbackLoadInfo.Columns["Cust_Code"].Width = 80;
                dgvCashbackLoadInfo.Columns["Session_Name"].Width = 120;//.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvCashbackLoadInfo.Columns["Plan_Name"].Width = 120;
                dgvCashbackLoadInfo.Columns["CB_Amount"].Width = 100;
                dgvCashbackLoadInfo.Columns["Remark"].Width = 120;
                dgvCashbackLoadInfo.Columns["Entry_By"].Width = 60;
                dgvCashbackLoadInfo.Columns["Plan_Date"].Visible = false;
                dgvCashbackLoadInfo.Columns["Min_Trade_Amount"].Visible = false;
                dgvCashbackLoadInfo.Columns["Rate"].Visible = false;
                dgvCashbackLoadInfo.Columns["Effective_Date"].Visible = false;
            }
            catch
            {

                // MessageBox.Show(ex.Message);
            }
        }

        private void GetPossibleCandidateCashbackWithData(int _sessionId, int _planId, DateTime _startDate, DateTime _endDate)
        {
            try
            {
                DataTable data = new DataTable();
                CashBackRegBAL objCashBackRegi = new CashBackRegBAL();
                data = objCashBackRegi.GetPossibleCandidateCashBackWithData(_sessionId, _planId, _startDate, _endDate);
                dgvCashBackRegEditInfo.DataSource = data;
                //dgvCashBackRegEditInfo.Columns["CashBack_SessionID"].Visible = false;//.DefaultCellStyle.Format = "dd MMM yyyy";
                //dgvCashBackRegEditInfo.Columns["Plan_ID"].Visible = false;//.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                //dgvInfo.Columns["Last Paid Date"].DefaultCellStyle.Format = "dd MMM yyyy";
                //dgvInfo.Columns["Last Paid Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }


        private void LoadPlanNameDDL()
        {
            LoadDDLBAL loadDDLBAL = new LoadDDLBAL();
            DataTable dtData = loadDDLBAL.LoadDDL("SBP_Cashback_Plan");
            ddlPlanName.DataSource = dtData;
            ddlPlanName.DisplayMember = "Plan_Name";
            ddlPlanName.ValueMember = "ID";
            ddlPlanName.SelectedIndex = -1;
        }
        private void LoadSessionName()
        {
            LoadDDLBAL loadDDLBAL = new LoadDDLBAL();
            DataTable dtData = loadDDLBAL.GetSessionName();
            ddlSessionName.ValueMember = "ID";
            ddlSessionName.DisplayMember = "Name";
            ddlSessionName.DataSource = dtData;
            ddlSessionName.SelectedIndex = -1;
        }

        private void ddlPlanName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "Return")
            {
                SaveCashBackReg();
            }
        }

        //private void txtCustomerCode_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    CommonBAL commonBal = new CommonBAL();
        //    commonBal.NumberValidate(txtCustomerCode.Text, e);
        //}

        //private void txtCashBackAmount_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    CommonBAL commonBal = new CommonBAL();
        //    commonBal.NumberValidate(txtCashBackAmount.Text, e);
        //}

        private void btnCancelReg_Click(object sender, EventArgs e)
        {
            //CashBackRegBAL objCashBackRegi = new CashBackRegBAL();
            //if (_custcode != "")
            //{
            //    try
            //    {
            //        objCashBackRegi.DeleteCashBackRegistrationData(_custcode);
            //        MessageBox.Show(@"Registration Deleted Successfully");
            //        GetCashbackRegi();
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //}
            //_custcode = "";
            if (_deleteId != 0)
            {
                cashBackRegBAL.DeleteFromReg(_deleteId);//cashBackRegBO
                _deleteId = 0;
                MessageBox.Show("Data canceled Successfully");
                GetCashbackRegi();
                cashBackRegBO = new CashBackRegBO();
            }
        }



        private void dgvInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dgvCashbackLoadInfo.CurrentRow;
                _deleteId = Int32.Parse(dr.Cells[0].Value.ToString());
                //cashBackRegBO.SessionId = Int32.Parse(dr.Cells[0].Value.ToString());
                //cashBackRegBO.CustCode = dr.Cells[1].Value.ToString();
                //cashBackRegBO.PlanId = Int32.Parse(dr.Cells[2].Value.ToString());
            }
            catch
            {

            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataTable data = new DataTable();
            int sessionId, planId;
            CashBackRegBAL objBAL = new CashBackRegBAL();
            try
            {
                sessionId = Convert.ToInt32(ddlSessionName.SelectedValue.ToString());
                planId = Convert.ToInt32(ddlPlanName.SelectedValue.ToString());
                data = objBAL.GetSessionAndPlanInfoBySessionandPlanID(sessionId, planId);
                if (data.Rows.Count > 0)
                {
                    txtMinimumTradeAmount.Text = data.Rows[0]["Min_Trade_Amount"].ToString();
                    txtPlanRate.Text = double.Parse(data.Rows[0]["Rate"].ToString()).ToString("0.00");
                    dtpStartDate.Value = Convert.ToDateTime(data.Rows[0]["Session_Start_Date"].ToString());
                    dtpEndDate.Value = Convert.ToDateTime(data.Rows[0]["Session_End_Date"].ToString());
                }
                GetPossibleCandidateCashbackWithData(sessionId, planId, dtpStartDate.Value, dtpEndDate.Value);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void dgvSessionPlanInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (
            //    (e.ColumnIndex == 0)
            //    && (dgvSessionPlanInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue != null)
            //    && ((bool) dgvSessionPlanInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue == true)
            //    )
            //{
            //    foreach (DataGridViewRow dgvrow in dgvSessionPlanInfo.Rows)
            //    {
            //        if ((bool)dgvrow.Cells["ckbSelect"].EditedFormattedValue == true)
            //        {
            //        }
            //    }
            //}
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> tobeDeleted = new List<DataGridViewRow>();
            try
            {
                if (dgvCashBackRegEditInfo.Rows.Count > 0)
                {
                    foreach (DataGridViewRow dgvrow in dgvCashBackRegEditInfo.Rows)
                    {

                        if ((bool)dgvrow.Cells["Select"].EditedFormattedValue)
                        {
                            tobeDeleted.Add(dgvrow);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select item");
                    return;
                }
                foreach (DataGridViewRow dgvrow in tobeDeleted)
                {
                    dgvCashBackRegEditInfo.Rows.Remove(dgvrow);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ddlSessionName_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable data = new DataTable();
            int sessionId = 0;
            CashBackRegBAL objBAL = new CashBackRegBAL();
            try
            {
                sessionId = Convert.ToInt32(ddlSessionName.SelectedValue.ToString());
                data = objBAL.GetSessionInfoBySessionID(sessionId);
                if (data.Rows.Count > 0)
                {
                    dtpStartDate.Value = Convert.ToDateTime(data.Rows[0]["Session_Start_Date"].ToString());
                    dtpEndDate.Value = Convert.ToDateTime(data.Rows[0]["Session_End_Date"].ToString());
                    GetCashbackRegi();
                }
            }

            catch
            {
                dgvCashbackLoadInfo.DataSource = null;
                dtpStartDate.Value = DateTime.Today;
            }
              
            //  LoadCashBackRegEditGridData();
        }

        private void ddlPlanName_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable data = new DataTable();
            int planId;
            CashBackRegBAL objBAL = new CashBackRegBAL();
            try
            {
                planId = Convert.ToInt32(ddlPlanName.SelectedValue.ToString());
                data = objBAL.GetPlanInfoByPlanID(planId);
                if (data.Rows.Count > 0)
                {
                    txtMinimumTradeAmount.Text = data.Rows[0]["Min_Trade_Amount"].ToString();
                    txtPlanRate.Text = double.Parse(data.Rows[0]["Rate"].ToString()).ToString("0.00");
                }
            }

            catch
            {

            }

            //GetCashbackRegi();
            //  LoadCashBackRegEditGridData();
        }

        private void ckbCheckAll_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbCheckAll.Checked)
            {
                try
                {
                    foreach (DataGridViewRow dgvrow in dgvCashBackRegEditInfo.Rows)
                    {
                        dgvrow.Cells["Select"].Value = true;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                try
                {
                    foreach (DataGridViewRow dgvrow in dgvCashBackRegEditInfo.Rows)
                    {
                        dgvrow.Cells["Select"].Value = false;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

    
  
      
        private void dgvCashBackRegEditInfo_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            double percent=0, doubleTryParse;
            double cashBackAmount=0;
            double commission = 0;
            try
            {
                if (dgvCashBackRegEditInfo.Columns[e.ColumnIndex].Name == "Apply_Percentage" && !isEditedByEvent_PCashBackAmount && !isErrorOccured)
                {
                   
                    if (double.TryParse(dgvCashBackRegEditInfo.Rows[e.RowIndex].Cells[5].EditedFormattedValue.ToString(), out doubleTryParse))
                    {
                        commission = doubleTryParse;
                    }

                    if (double.TryParse(dgvCashBackRegEditInfo.Rows[e.RowIndex].Cells[6].EditedFormattedValue.ToString(), out doubleTryParse))
                    {
                        percent = doubleTryParse;
                    }
                    if (double.TryParse(dgvCashBackRegEditInfo.Rows[e.RowIndex].Cells[7].EditedFormattedValue.ToString(), out doubleTryParse))
                    {
                        cashBackAmount = doubleTryParse;
                    }


                    if (percent <= 100)
                    {
                        isEditedByEvent_Percantage = true;
                        isEditedByEvent_PCashBackAmount = false;
                        dgvCashBackRegEditInfo.Rows[e.RowIndex].Cells[7].Value = Convert.ToString((commission * percent) / 100);
                    }

                    else if (percent > 100)
                    {
                        isErrorOccured = true;
                        dgvCashBackRegEditInfo.Rows[e.RowIndex].Cells[6].Value = "0.00";
                        MessageBox.Show("Percentage is gerather than 100 percent");
                        return;
                    }
                     
                }
                else if (dgvCashBackRegEditInfo.Columns[e.ColumnIndex].Name == "ProposedCBAmount" && !isEditedByEvent_Percantage && !isErrorOccured)
                {
                 
                    if (double.TryParse(dgvCashBackRegEditInfo.Rows[e.RowIndex].Cells[5].EditedFormattedValue.ToString(), out doubleTryParse))
                    {
                        commission = doubleTryParse;
                    }

                    if (double.TryParse(dgvCashBackRegEditInfo.Rows[e.RowIndex].Cells[6].EditedFormattedValue.ToString(), out doubleTryParse))
                    {
                        percent = doubleTryParse;
                    }
                    if (double.TryParse(dgvCashBackRegEditInfo.Rows[e.RowIndex].Cells[7].EditedFormattedValue.ToString(), out doubleTryParse))
                    {
                        cashBackAmount = doubleTryParse;
                    }


                    if (cashBackAmount <= commission && commission != 0)
                    {
                        isEditedByEvent_Percantage = false;
                        isEditedByEvent_PCashBackAmount = true;

                        dgvCashBackRegEditInfo.Rows[e.RowIndex].Cells[6].Value = Math.Round(((cashBackAmount * 100) / commission),2).ToString();

                    }
                    else
                    {
                        isErrorOccured = true;
                        dgvCashBackRegEditInfo.Rows[e.RowIndex].Cells[7].Value = cashbackAmountBeforeEdit.ToString();
                        MessageBox.Show("Proposed Cashback amount is greater than Commission");
                        return;
                    }

                    
                }
                else
                {
                    isEditedByEvent_Percantage = false;
                    isEditedByEvent_PCashBackAmount = false;
                    isErrorOccured = false;
                }
            }
            catch
            {

            }
        }

        private void dgvCashBackRegEditInfo_SelectionChanged(object sender, EventArgs e)
        {
            double doubleTryParse;
            try{
            if (dgvCashBackRegEditInfo.CurrentRow.Cells[7].Value!=null)
            {
                if (double.TryParse(dgvCashBackRegEditInfo.CurrentRow.Cells[7].Value.ToString(), out doubleTryParse))
                {
                    cashbackAmountBeforeEdit = double.Parse(dgvCashBackRegEditInfo.CurrentRow.Cells[7].Value.ToString());
                }

            }
                }
            catch(Exception ex)
            {
                }
        }

        private void dgvCashBackRegEditInfo_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
        }

        private void btnViewReport_Click(object sender, EventArgs e)
        {
            CashBackRegBAL objBAL = new CashBackRegBAL();
            frmReportViewer rptviewer = new frmReportViewer();
            crCashbackReport objrpt = new crCashbackReport();
            DataTable dtSessionInfo = new DataTable();
            DataTable dtCashbackReport = (DataTable)dgvCashbackLoadInfo.DataSource;
            dtSessionInfo = objBAL.GetSessionInfoBySessionID(Convert.ToInt32(ddlSessionName.SelectedValue.ToString()));
            if (dtSessionInfo.Rows.Count > 0)
            {
                ((TextObject)objrpt.ReportDefinition.Sections[1].ReportObjects["txtSessionName"]).Text = dtSessionInfo.Rows[0]["Name"].ToString();
                ((TextObject)objrpt.ReportDefinition.Sections[1].ReportObjects["txtSessionDescription"]).Text = dtSessionInfo.Rows[0]["Description"].ToString();
                ((TextObject)objrpt.ReportDefinition.Sections[1].ReportObjects["txtSessionStartDate"]).Text = Convert.ToDateTime(dtSessionInfo.Rows[0]["Session_Start_Date"].ToString()).ToShortDateString();
                ((TextObject)objrpt.ReportDefinition.Sections[1].ReportObjects["txtSessionEndDate"]).Text = Convert.ToDateTime(dtSessionInfo.Rows[0]["Session_End_Date"].ToString()).ToShortDateString();
            }
            objrpt.SetDataSource(dtCashbackReport);
            rptviewer.crvReportViewer.ReportSource = objrpt;
            rptviewer.Text = "Cash Back Report";
            rptviewer.Show();
        }
    }
}
