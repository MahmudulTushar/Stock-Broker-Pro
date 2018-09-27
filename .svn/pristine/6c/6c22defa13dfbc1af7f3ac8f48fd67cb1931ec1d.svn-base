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
using System.Data.SqlClient;


namespace DseReports
{
    public partial class frmRights_Instrumens_Confirmations_Reports_Dse_21_14 : Form
    {
        private string _custCode;
        private string _boid;
        private string _instrumentId;

        public frmRights_Instrumens_Confirmations_Reports_Dse_21_14()
        {
            InitializeComponent();
            LoadComboData();
        }

        private void btnViewReport_Click(object sender, EventArgs e)
        {
            Rights_Instrumens_Confirmation_Report_Dse_21_14_BAL objBAL = new Rights_Instrumens_Confirmation_Report_Dse_21_14_BAL();
            DataTable data = new DataTable();
            frmReportViewer rptviewer = new frmReportViewer();
            crRights_Instrumens_Confirmations_Reports_Dse_21_14 objrpt = new crRights_Instrumens_Confirmations_Reports_Dse_21_14();
            SetInputInfo();
            data = objBAL.Reprot_dse_21(_custCode, _boid, dtpFromDate.Value, dtpToDate.Value, _instrumentId);

            objrpt.SetDataSource(data);
            ((TextObject)objrpt.Section2.ReportObjects["txtFromDate"]).Text = dtpFromDate.Value.ToString("dd/MM/yyyy");
            ((TextObject)objrpt.Section2.ReportObjects["txtToDate"]).Text = dtpToDate.Value.ToString("dd/MM/yyyy");
            rptviewer.crvReportViewer.ReportSource = objrpt;
            rptviewer.Show();
            ResetInputInfo();
        }
        private void SetInputInfo()
        {
            _custCode = txtCustcode.Text;
            _boid = txtboId.Text;
            _instrumentId = ddlInstrumentID.Text;
        }
        private void ResetInputInfo()
        {
            _custCode = string.Empty;
            _boid = string.Empty;
            _instrumentId = string.Empty;
        }
        private void LoadComboData()
        {
            Rights_Instrumens_Confirmation_Report_Dse_21_14_BAL objBAL = new Rights_Instrumens_Confirmation_Report_Dse_21_14_BAL();
            DataTable dtCustCode = new DataTable();
            DataTable dtBOID = new DataTable();
            DataTable dtInstrument = new DataTable();

            dtCustCode = objBAL.GetCustCode();
            dtBOID = objBAL.GetCustBOID();
            dtInstrument = objBAL.GetInstrument();

            

            ddlInstrumentID.DataSource = dtInstrument;
            ddlInstrumentID.ValueMember = dtInstrument.Columns[0].ToString();
            ddlInstrumentID.DisplayMember = dtInstrument.Columns[0].ToString();


        }
       

        private void frm_Dse_21_14_Load(object sender, EventArgs e)
        {
           // LoadComboData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        //private void txtCustcode_TextChanged(object sender, EventArgs e)
        //{
        //    Report_Dse_21_14BAL objBAL = new Report_Dse_21_14BAL();
        //    string boid = objBAL.Getboid(txtCustcode.Text);
        //    txtboId.Text = boid.ToString();

        //}

        //private void txtboId_TextChanged(object sender, EventArgs e)
        //{
        //    Report_Dse_21_14BAL objBAL = new Report_Dse_21_14BAL();
        //    string boid = objBAL.GetCustId(txtboId.Text);
        //    txtCustcode.Text = boid.ToString();
        //}

        private void txtboId_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                e.Handled = true;
            }
        }

        private void txtCustcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar ==13)
            {
                Rights_Instrumens_Confirmation_Report_Dse_21_14_BAL objBAL = new Rights_Instrumens_Confirmation_Report_Dse_21_14_BAL();
                string boid = objBAL.Getboid(txtCustcode.Text);
                txtboId.Text = boid.ToString();
            }
        }

        private void txtboId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Rights_Instrumens_Confirmation_Report_Dse_21_14_BAL objBAL = new Rights_Instrumens_Confirmation_Report_Dse_21_14_BAL();
                string boid = objBAL.GetCustId(txtboId.Text);
                txtCustcode.Text = boid.ToString();
            }
        }

        
        
    }
}
