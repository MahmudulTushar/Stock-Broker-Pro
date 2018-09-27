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
    public partial class frmProcess_List : Form
    {
        private GlobalVariableBO.ModeSelection _currentMode = GlobalVariableBO.ModeSelection.NewMode;

        public frmProcess_List()
        {
            InitializeComponent();
        }
        private enum ExecutionMode
        {
             New
            ,Save
            ,Update
            ,Reset
            ,Close
        }
        private int _sessionId;
        private Process_ListBO SetBO()
        {
            Process_ListBO objBO = new Process_ListBO();
            if (txtProcessID.Text != "")
            {
                objBO.Id = Int32.Parse(txtProcessID.Text.Trim());
            }
            objBO.Name = txtProcessName.Text;
            objBO.Description = txtDescription.Text;
            objBO.EntryDate = dtpEntry_Date.Value.ToString("yyyy-MM-dd");
            return objBO;
        }
        private void ClearAfterSave()
        {
            txtProcessID.Text = string.Empty;
            txtProcessName.Text = string.Empty;
            txtDescription.Text = string.Empty;
        }
        private bool IsValidInputData()
        {
            bool result = true;
            if (txtProcessName.Text == "")
            {
                throw new Exception("Process Name Required");
            }

            return result;
        }
        private void LoadGridData()
        {
            DataTable dtgrid = new DataTable();
            Process_ListBAL objBAL = new Process_ListBAL();
            dtgrid = objBAL.GetGridData();
            dgvCashBackSessionInfo.DataSource = dtgrid;
            //dgvCashBackSessionInfo.Columns[0].Visible = false;
            dgvCashBackSessionInfo.Columns[3].DefaultCellStyle.Format = "dd-MM-yyyy";
            dgvCashBackSessionInfo.Columns["Name"].Width = 110;
            dgvCashBackSessionInfo.Columns["Description"].Width = 100;
        }
        private void ResetNewMode()
        {
            txtProcessID.Enabled = false;
            txtProcessName.Enabled = true;
            txtDescription.Enabled = true;
            dtpEntry_Date.Enabled = true;
            txtProcessName.Focus();
        }
        private void ResetUpdateMode()
        {
            txtProcessID.Enabled = true;
            txtProcessName.Enabled = false;
            txtDescription.Enabled = false;
            dtpEntry_Date.Enabled = false;
            txtProcessID.Focus();
        }
        private void btnSaveBasicInfo_Click(object sender, EventArgs e)
        {
            Process_ListBO objBO = new Process_ListBO();
            Process_ListBAL objBAL = new Process_ListBAL();
            try
            {
                objBO = SetBO();
                switch (_currentMode)
                {
                    case GlobalVariableBO.ModeSelection.NewMode:
                        try
                        {
                            if (IsValidInputData())
                            {
                                objBAL.SaveProcess_ListData(objBO);
                                MessageBox.Show(@"Data Saved Successfully");
                                ClearAll();
                                ResetNewMode();
                                LoadGridData();
                               // SetExecutionMode(ExecutionMode.New);
                            }
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show(@"Fail to save because of :" + ex.Message);
                        }
                        break;
                    case GlobalVariableBO.ModeSelection.UpdateMode:
                        try
                        {
                            if (IsValidInputData())
                            {
                                objBAL.UpdateProcess_ListData(objBO);
                                MessageBox.Show(@"Data Updated Successfully");
                                ClearAll();
                                LoadGridData();
                                ResetUpdateMode();
                                // SetExecutionMode(ExecutionMode.Update);
                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(@"Fail to update Information, because of the Error : " + ex.Message);
                        }
                        break;

                    case GlobalVariableBO.ModeSelection.NoneMode:
                            MessageBox.Show(@"Please Select a Mode(Save,Update)");
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void SetExecutionMode(ExecutionMode execMode)
        {
            switch(execMode)
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
                        txtProcessID.Enabled = false;
                        txtProcessName.Focus();
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
                        txtProcessID.Enabled = true;
                        txtProcessID.Focus();

                    }
                    break;
                case ExecutionMode.Reset:
                    {
                        if(_currentMode == GlobalVariableBO.ModeSelection.UpdateMode)
                        {
                            ClearAll();
                            DisableAll();
                            txtProcessID.Enabled = true;
                            txtProcessID.Focus();
                        }
                        else
                        {
                            ClearAll();
                            EnableAll();
                            txtProcessID.Enabled = false;
                            txtProcessName.Focus();
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
            //txtProcessID.Enabled = true;
            txtProcessName.Enabled = true;
            txtDescription.Enabled = true;
            dtpEntry_Date.Enabled = true;
        }

        private void DisableAll()
        {
            //txtProcessID.Enabled = false;
            txtProcessName.Enabled = false;
            txtDescription.Enabled = false;
            dtpEntry_Date.Enabled = false;
        }
        private void ClearAll()
        {
          //  EnableAll();
            txtProcessID.Text = "";
            txtProcessName.Text = "";
            dtpEntry_Date.Value = DateTime.Today;
            txtDescription.Text = "";
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
           SetExecutionMode(ExecutionMode.Update);
            //_currentMode = GlobalVariableBO.ModeSelection.UpdateMode;
            //btnUpdate.Enabled = false;
            //btnUpdate.BackColor = Color.Gray;
            //btnNew.Enabled = true;
            //btnNew.ResetBackColor();
            //ClearAll();
            //DisableAll();
            //txtProcessID.Enabled = true;
            //txtProcessID.Focus();

            //Process_ListBO objBO = new Process_ListBO();
            //Process_ListBAL objBAL = new Process_ListBAL();
            //if (_sessionId != 0)
            //{
            //    try
            //    {
            //        objBO = SetBO();
            //        if (IsValidInputData())
            //        {
            //            objBAL.UpdateProcess_ListData(_sessionId, objBO);
            //            MessageBox.Show(@"Data Updated Successfully");
            //            ClearAfterSave();
            //            LoadGridData();
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //}
            //_sessionId = 0;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Process_ListBAL objBAL = new Process_ListBAL();
            if (_sessionId != 0)
            {
                try
                {
                    objBAL.DeleteProcess_ListData(_sessionId);
                    MessageBox.Show(@"Data Deleted Successfully");
                    ClearAfterSave();
                    LoadGridData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            _sessionId = 0;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmProcess_List_Load(object sender, EventArgs e)
        {
            try
            {
                LoadGridData();
                SetExecutionMode(ExecutionMode.New);
                txtProcessName.Focus();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void dgvCashBackSessionInfo_SelectionChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    DataGridViewRow dr = dgvCashBackSessionInfo.CurrentRow;
            //    _sessionId = 0;
            //    _sessionId = Int32.Parse(dr.Cells[0].Value.ToString());
            //    txtProcessName.Text = dr.Cells[1].Value.ToString();
            //    txtDescription.Text = dr.Cells[2].Value.ToString();
            //    dtpEntry_Date.Value = Convert.ToDateTime(dr.Cells[3].Value);
            //}
            //catch
            //{

            //}
        }

        private void dgvCashBackSessionInfo_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                dgvCashBackSessionInfo.Rows[0].Selected = false;
                ClearAfterSave();
            }
            catch
            {
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            SetExecutionMode(ExecutionMode.New);
            //_currentMode = GlobalVariableBO.ModeSelection.NewMode;
            //btnNew.Enabled = false;
            //btnNew.BackColor = Color.Gray;
            //btnUpdate.Enabled = true;
            //btnUpdate.ResetBackColor();
            //ClearAll();
            //txtProcessID.Enabled = false;
            //txtProcessName.Focus();
        }

        private void btnResetBasicInfo_Click(object sender, EventArgs e)
        {
            SetExecutionMode(ExecutionMode.Reset);
            //if (_currentMode == GlobalVariableBO.ModeSelection.UpdateMode)
            //{
            //    ClearAll();
            //    DisableAll();
            //    txtProcessID.Focus();
            //}
            //else
            //{
            //    ClearAll();
            //    EnableAll();
            //    txtProcessName.Focus();
            //}
        }

        private void txtProcessID_KeyDown(object sender, KeyEventArgs e)
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
                txtProcessID.Enabled = false;
                LoadDataFromDataTable();

            }
        }

        private void LoadDataFromDataTable()
        {
            DataTable dtProcessList = new DataTable();
            Process_ListBAL objBAL = new Process_ListBAL();
            if (!String.IsNullOrEmpty(txtProcessID.Text.Trim()))
                dtProcessList = objBAL.GetPorcessDataByProcessId(Int32.Parse(txtProcessID.Text.Trim()));
            if (dtProcessList.Rows.Count > 0)
            {
                // txtCustomerCode.Text = dtCashBack.Rows[0]["Cust_Code"].ToString();
                txtProcessName.Text= dtProcessList.Rows[0]["Name"].ToString();
                txtDescription.Text = dtProcessList.Rows[0]["Description"].ToString();
                dtpEntry_Date.Value = Convert.ToDateTime(dtProcessList.Rows[0]["Entry_Date"]);
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

        private void txtProcessID_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonBAL commonBal = new CommonBAL();
            commonBal.NumberValidate(txtProcessID.Text, e);
        }
    }
}
