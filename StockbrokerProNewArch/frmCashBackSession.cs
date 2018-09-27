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
    public partial class frmCashBackSession : Form
    {
        public frmCashBackSession()
        {
            InitializeComponent();
        }

        private int _sessionId;
        private string Processed_Status = string.Empty;
        private CashBackSessionBO SetBO()
        {
            CashBackSessionBO objBO = new CashBackSessionBO();
            CommonBAL objBAL = new CommonBAL();
            objBO.Name = txtSessionName.Text;
            objBO.Description = txtDescription.Text;
            objBO.SessionStartDate = dtpSession_Start_Date.Value.ToString("yyyy-MM-dd");
            objBO.SessionEndDate = dtpSession_End_Date.Value.ToString("yyyy-MM-dd");
            objBO.Remarks = txtRemarks.Text;
            objBO.EntryDate = objBAL.GetCurrentServerDate();// dtpEntry_Date.Value.ToString("yyyy-MM-dd");
            objBO.IsProcessed = 0;
            return objBO;
        }
        private void ClearAfterSave()
        {
            txtSessionName.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtRemarks.Text = string.Empty;
        }
        private bool IsValidInputData()
        {
            bool result = true;
            if(txtSessionName.Text=="")
            {
                throw new Exception("Session Name Required");
            }
            
            return result;
        }
        private void LoadGridData()
        {
            DataTable dtgrid=new DataTable();
            CashBackSessionBAL objBAL = new CashBackSessionBAL();
            dtgrid = objBAL.GetGridData();
            dgvCashBackSessionInfo.DataSource = dtgrid;
            dgvCashBackSessionInfo.Columns[0].Visible = false;
            dgvCashBackSessionInfo.Columns[3].DefaultCellStyle.Format = "dd-MM-yyyy";
            dgvCashBackSessionInfo.Columns[4].DefaultCellStyle.Format = "dd-MM-yyyy";
            dgvCashBackSessionInfo.Columns[6].DefaultCellStyle.Format = "dd-MM-yyyy";
        }
        private void btnSaveBasicInfo_Click(object sender, EventArgs e)
        {
            CashBackSessionBO objBO = new CashBackSessionBO();
            CashBackSessionBAL objBAL=new CashBackSessionBAL();
            try
            {
                objBO = SetBO();
                if (IsValidInputData())
                {
                    objBAL.SaveCashBackSessionData(objBO);
                    MessageBox.Show(@"Data Saved Successfully");
                    ClearAfterSave();
                    LoadGridData();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmCashBackSession_Load(object sender, EventArgs e)
        {
            try
            {
                LoadGridData();
            }
            catch
            {
                
            }
        }

        private void dgvCashBackSessionInfo_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow dr = dgvCashBackSessionInfo.CurrentRow;
                _sessionId = 0;
                Processed_Status = dr.Cells["Status"].Value.ToString();
                if (Processed_Status == "Pending")
                {
                    _sessionId = Int32.Parse(dr.Cells[0].Value.ToString());
                }
                //txtSessionName.Text = dr.Cells[1].Value.ToString();
                //txtDescription.Text = dr.Cells[2].Value.ToString();
                //dtpSession_Start_Date.Value = Convert.ToDateTime(dr.Cells[3].Value);
                //dtpSession_End_Date.Value = Convert.ToDateTime(dr.Cells[4].Value);
                //txtRemarks.Text = dr.Cells[5].Value.ToString();
                //dtpEntry_Date.Value = Convert.ToDateTime(dr.Cells[6].Value);
            }
            catch
            {
                
            }

        }

        //private void btnUpdate_Click(object sender, EventArgs e)
        //{
        //    CashBackSessionBO objBO = new CashBackSessionBO();
        //    CashBackSessionBAL objBAL = new CashBackSessionBAL();
        //    if (_sessionId != 0)
        //    {
        //        try
        //        {
        //            objBO = SetBO();
        //            if (IsValidInputData())
        //            {
        //                objBAL.UpdateCashBackSessionData(_sessionId,objBO);
        //                MessageBox.Show(@"Data Updated Successfully");
        //                ClearAfterSave();
        //                LoadGridData();
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //        }
        //    }
        //    _sessionId = 0;
        //}

        private void btnDelete_Click(object sender, EventArgs e)
        {
            CashBackSessionBAL objBAL = new CashBackSessionBAL();
            if (_sessionId != 0)
            {
                try
                {
                    objBAL.DeleteCashBackSessionData(_sessionId);
                    MessageBox.Show(@"Data Deleted Successfully");
                    ClearAfterSave();
                    LoadGridData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if(Processed_Status=="Processed")
            {
                MessageBox.Show("Processed Session Can't be deleted","Session State Check",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            _sessionId = 0;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvCashBackSessionInfo_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dgvCashBackSessionInfo.Rows.Count > 0)
            {
                dgvCashBackSessionInfo.Rows[0].Selected = false;
                ClearAfterSave();
            }
        }

        private void dgvCashBackSessionInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dgvCashBackSessionInfo.CurrentRow;
                _sessionId = 0;
                Processed_Status = dr.Cells["Status"].Value.ToString();
                if (Processed_Status == "Pending")
                {
                    _sessionId = Int32.Parse(dr.Cells[0].Value.ToString());
                }
            }
            catch
            {

            }

        }
        private void Set_Session_StartEnd_Date()
        {
            DateTime firstDate = new DateTime(dtpYearSelector.Value.Year, dtpMonthSelector.Value.Month, 1);
            DateTime endDate = new DateTime(dtpYearSelector.Value.Year, dtpMonthSelector.Value.Month, DateTime.DaysInMonth(dtpYearSelector.Value.Year, dtpMonthSelector.Value.Month));
            dtpSession_Start_Date.Value = firstDate;
            dtpSession_End_Date.Value = endDate;
        }
        private void dtpMonthSelector_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                Set_Session_StartEnd_Date();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void dtpYearSelector_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                Set_Session_StartEnd_Date();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
