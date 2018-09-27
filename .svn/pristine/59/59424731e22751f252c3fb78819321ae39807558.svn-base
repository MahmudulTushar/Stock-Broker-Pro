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
    public partial class ChangeCheckPrintStatus : Form
    {
        private int _requisitionID;
        public ChangeCheckPrintStatus()
        {
            InitializeComponent();
        }

        

        private void LoadGridData()
        {

            try
            {
                CheckRequisitionBAL checkRequisitionBal = new CheckRequisitionBAL();
                DataTable dtCheckHistoryInfo = checkRequisitionBal.GetUnprintedPrintCheck(dtSearchDate.Value);
                dtgCheckPrintingHistory.DataSource = dtCheckHistoryInfo;
                dtgCheckPrintingHistory.Columns[0].Visible = false;
                dtgCheckPrintingHistory.Columns["Amount"].DefaultCellStyle.Format = "N";
                dtgCheckPrintingHistory.Columns["Amount"].DefaultCellStyle.Alignment =DataGridViewContentAlignment.MiddleRight;
                dtgCheckPrintingHistory.Columns["Cheque Date"].DefaultCellStyle.Format = "dd MMM yyyy";
                dtgCheckPrintingHistory.Columns["Cheque Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                lblTotalRecord.Text = "Total Record : " + dtgCheckPrintingHistory.Rows.Count.ToString();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           
           
        }

        private void btnChangeStatus_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.dtgCheckPrintingHistory.SelectedRows)
            {
                _requisitionID = Convert.ToInt32(dtgCheckPrintingHistory[0, row.Index].Value);
                if (MessageBox.Show("Do you want to continue to Change the print Status?", "Question",MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        CheckRequisitionBAL checkRequisitionBal = new CheckRequisitionBAL();
                        checkRequisitionBal.ChangeCheckPrintStatus(_requisitionID);
                        MessageBox.Show("Successfully Change the Cheque Print Status", "Success.");
                        LoadGridData();
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show("Fail to Change the cheque print Status" + exc.Message);
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChangeCheckPrintStatus_Load(object sender, EventArgs e)
        {
            
            LoadGridData();
        }

        private void dtSearchDate_ValueChanged(object sender, EventArgs e)
        {
            LoadGridData();
        }
    }
}
