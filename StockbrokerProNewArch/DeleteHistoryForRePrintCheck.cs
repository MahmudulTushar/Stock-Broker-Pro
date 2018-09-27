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
    public partial class DeleteHistoryForRePrintCheck : Form
    {
        private string _custCode;
        private string _paymentNo;
        private DateTime _recieveddate;

        public DeleteHistoryForRePrintCheck()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            LoadGridData();
        }

        private void LoadGridData()
        {
            CheckPrintBAL checkPrintBal = new CheckPrintBAL();
            DataTable dtCheckHistoryInfo = checkPrintBal.GetCheckPrintHistory(dtSearchDate.Value);
            dtgCheckPrintingHistory.DataSource = dtCheckHistoryInfo;
            dtgCheckPrintingHistory.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.dtgCheckPrintingHistory.SelectedRows)
            {
                _custCode = dtgCheckPrintingHistory[0, row.Index].Value.ToString();
                _paymentNo = dtgCheckPrintingHistory[2, row.Index].Value.ToString();
                _recieveddate = Convert.ToDateTime(dtgCheckPrintingHistory[4, row.Index].Value);
                if (MessageBox.Show("Do you want to continue to delete the print History?", "Question",
                              MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        CheckPrintBAL checkPrintBal = new CheckPrintBAL();
                        checkPrintBal.DeleteCheckHistory(_custCode, _paymentNo, _recieveddate);
                        MessageBox.Show("Successfully Deleted the Check Print History", "Success.");
                        LoadGridData();
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show("Fail to delete the check print history" + exc.Message);
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
