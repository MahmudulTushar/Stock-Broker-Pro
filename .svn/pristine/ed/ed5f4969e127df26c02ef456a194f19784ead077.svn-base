using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using DSE_Reports.Reports;
using CrystalDecisions.CrystalReports.Engine;
 

namespace DseReports
{
    public partial class frmRights_Instruments_Received_Reports_DSE_21_15 : Form
    {
        public frmRights_Instruments_Received_Reports_DSE_21_15()
        {
            InitializeComponent();
            LoadComboData();
        }
        #region Load combodata
        private void LoadComboData()
        {
            Right_Instrument_Received_Report_DSE_21_15_BAL objBAL = new Right_Instrument_Received_Report_DSE_21_15_BAL();
            DataTable data = new DataTable();
            data = objBAL.GetInstrument();
            ddlInstrumentID.DataSource = data;
            ddlInstrumentID.ValueMember = data.Columns[0].ToString();
            ddlInstrumentID.DisplayMember = data.Columns[0].ToString();

        }
        #endregion

        private void btnViewReport_Click(object sender, EventArgs e)
        {
            Right_Instrument_Received_Report_DSE_21_15_BAL objBAL = new Right_Instrument_Received_Report_DSE_21_15_BAL();
            DataTable data = new DataTable();
            frmReportViewer rptviewer = new frmReportViewer();
            crRights_Instruments_Received_Reports_DSE_21_15 objrpt = new crRights_Instruments_Received_Reports_DSE_21_15();
            data = objBAL.ReportData_15(dtpFromDate.Value, dtpToDate.Value, ddlInstrumentID.Text);
            objrpt.SetDataSource(data);
            ((TextObject)objrpt.Section2.ReportObjects["txtFromDate"]).Text = dtpFromDate.Value.ToString("dd/MM/yyyy");
            ((TextObject)objrpt.Section2.ReportObjects["txtToDate"]).Text = dtpToDate.Value.ToString("dd/MM/yyyy");
            rptviewer.crvReportViewer.ReportSource = objrpt;
            rptviewer.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_Dse_21_15_Load(object sender, EventArgs e)
        {
            
        }
    }
}
