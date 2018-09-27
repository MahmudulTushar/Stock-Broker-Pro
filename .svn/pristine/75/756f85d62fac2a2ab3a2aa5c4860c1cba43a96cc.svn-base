using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;

namespace StockbrokerProNewArch
{
    public partial class CheckReceived : Form
    {
        private int _requisitionID;
        private DateTime _searchDate;
        public CheckReceived()
        {
            InitializeComponent();
        }
        private void LoadRequisitedGridData()
        {
            CheckRequisitionBAL checkRequisitionBal = new CheckRequisitionBAL();
            DataTable dtCheckInfo = checkRequisitionBal.GetRequisitedGridData();
            dtgCheckRequisitionInfo.DataSource = dtCheckInfo;
            dtgCheckRequisitionInfo.Columns[0].Visible = false;
            dtgCheckRequisitionInfo.Columns[4].DefaultCellStyle.Format = "N";
            dtgCheckRequisitionInfo.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            lblRequision.Text = "Total Requisition : " + dtgCheckRequisitionInfo.Rows.Count;
        }
        private void LoadReceivedCheckGridData()
        {
            CheckRequisitionBAL checkRequisitionBal = new CheckRequisitionBAL();
            _searchDate = dtCheckRequisitionDate.Value;
            DataTable dtCheckInfo = checkRequisitionBal.GetReceivedCheckGridData(_searchDate);
            dtgReceivedCheck.DataSource = dtCheckInfo;
            dtgReceivedCheck.Columns[0].Visible = false;
            dtgReceivedCheck.Columns[4].DefaultCellStyle.Format = "N";
            dtgReceivedCheck.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            lblRecived.Text = "Total Received : " + dtgReceivedCheck.Rows.Count;

        }
        private void CheckRequisitionStatus_Load(object sender, EventArgs e)
        {
            LoadRequisitedGridData();
            LoadReceivedCheckGridData();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnReceived_Click(object sender, EventArgs e)
        {
            try
            {
                LoadDataFromGrid();
                CheckRequisitionBAL checkRequisitionBal = new CheckRequisitionBAL();
                checkRequisitionBal.ReceivedCheck(_requisitionID);
                MessageBox.Show("Cheque has Received successfully.");
                LoadRequisitedGridData();
                LoadReceivedCheckGridData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Received unsuccessfull. Error Occured: " + ex.Message);
            }
        }
        private void LoadDataFromGrid()
        {
            
            foreach (DataGridViewRow row in this.dtgCheckRequisitionInfo.SelectedRows)
            {
                if (dtgCheckRequisitionInfo[0, row.Index].Value != DBNull.Value)
                    _requisitionID = Convert.ToInt32(dtgCheckRequisitionInfo[0, row.Index].Value);
            }

        }

        private void btnReceivedAll_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dtgCheckRequisitionInfo.Rows)
                {
                    if (dtgCheckRequisitionInfo[0, row.Index].Value != DBNull.Value)
                        _requisitionID = Convert.ToInt32(dtgCheckRequisitionInfo[0, row.Index].Value);
                    CheckRequisitionBAL checkRequisitionBal = new CheckRequisitionBAL();
                    checkRequisitionBal.ReceivedCheck(_requisitionID);
                }
                MessageBox.Show("Cheque has Received successfully.");
                LoadRequisitedGridData();
                LoadReceivedCheckGridData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Received unsuccessfull. Error Occured: " + ex.Message);
            }
        }

        private void dtCheckRequisitionDate_ValueChanged(object sender, EventArgs e)
        {
            LoadReceivedCheckGridData();
        }
    }
}
