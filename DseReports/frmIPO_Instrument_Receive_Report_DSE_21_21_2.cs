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
    public partial class frmIPO_Instrument_Receive_Report_DSE_21_21_2 : Form
    {
        string code = "";
        
        public frmIPO_Instrument_Receive_Report_DSE_21_21_2()
        {
            InitializeComponent();
        }
        private void InitializeComboData()
        {
            IPO_Instrument_Receive_Report_DSE_21_21_2BAL objBAL = new IPO_Instrument_Receive_Report_DSE_21_21_2BAL();
            DataTable dtInstrument = new DataTable();
            DataTable dtCompanyName = new DataTable();

            dtInstrument = objBAL.GetInstrument();
            dtCompanyName = objBAL.GetCompanyName();

            ddlInstrumentCode.DataSource = dtInstrument;
            ddlInstrumentCode.ValueMember = dtInstrument.Columns[1].ToString();
            ddlInstrumentCode.DisplayMember = dtInstrument.Columns[0].ToString();

            ddlinstrumentName.DataSource = dtCompanyName;
            ddlinstrumentName.ValueMember = dtCompanyName.Columns[1].ToString();
            ddlinstrumentName.DisplayMember = dtCompanyName.Columns[0].ToString();
        }

        private void frmIPO_Instrument_Receive_Report_DSE_21_21_2_Load(object sender, EventArgs e)
        {
            try
            {
                InitializeComboData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        string Instrument_ID, Instrument_Name;
        private void btnViewReport_Click(object sender, EventArgs e)
        {
            IPO_Instrument_Receive_Report_DSE_21_21_2BAL objBAL = new IPO_Instrument_Receive_Report_DSE_21_21_2BAL();
            DateTime Start_Date, End_Date;
            

            Start_Date = dtpFromDate.Value;
            End_Date = dtpToDate.Value;
            Instrument_Name = ddlinstrumentName.Text;
            Instrument_ID = ddlInstrumentCode.Text;

            DataTable data = new DataTable();
            frmReportViewer rptviewer = new frmReportViewer();
            crIPO_Instrument_Receive_Report_DSE_21_21_2 objrpt = new crIPO_Instrument_Receive_Report_DSE_21_21_2();
            data = objBAL.GetIPO_Instrument_Receive_ReportData(Start_Date, End_Date,Instrument_ID, Instrument_Name);
            objrpt.SetDataSource(data);
            ((TextObject)objrpt.Section2.ReportObjects["txtFromDate"]).Text = Start_Date.ToString("dd-MMMM-yyyy");
            ((TextObject)objrpt.Section2.ReportObjects["txtToDate"]).Text = End_Date.ToString("dd-MMMM-yyyy");
            rptviewer.crvReportViewer.ReportSource = objrpt;
            rptviewer.Show();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ddlInstrumentCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (ddlInstrumentCode.SelectedIndex == 0)
                {
                    ddlinstrumentName.SelectedIndex = 0;
                }
                else
                {
                    code = ddlInstrumentCode.Text;
                    ddlinstrumentName.SelectedValue = code;
                }
            }
            catch
            {
            }
        }

        private void ddlinstrumentName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlinstrumentName.SelectedIndex == 0)
                {
                    ddlInstrumentCode.SelectedIndex = 0;
                }
                else
                {
                    Name = ddlinstrumentName.Text;
                    ddlInstrumentCode.SelectedValue = Name;
                }
            }
            catch
            {
            }
        }

    }
}
