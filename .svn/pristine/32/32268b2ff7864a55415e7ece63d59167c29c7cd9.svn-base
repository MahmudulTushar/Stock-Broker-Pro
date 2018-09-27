using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using CrystalDecisions.CrystalReports.Engine;
using BusinessAccessLayer.BAL;
using System.IO;
using System.Globalization;

namespace DseReports
{
    public partial class frmBonus_Instrument_Confirmation_ReportDSE_21_2 : Form
    {
        #region private field
        private string _custCode;
        private string _boid;
        private string _instrumentId;
        #endregion

        #region constructor
        public frmBonus_Instrument_Confirmation_ReportDSE_21_2()
        {
            InitializeComponent();
        }
        #endregion

        #region Load Form
        private void frmBonus_Instrument_Confirmation_ReportDSE_21_2_Load(object sender, EventArgs e)
        {
            Bonus_Instrument_Confirmation_Reports_DSE_21_2BAL objBAL = new Bonus_Instrument_Confirmation_Reports_DSE_21_2BAL();
            DataTable dataTable =new DataTable();
            dataTable = objBAL.GetInstrument();
            ddlInstrumentID.DataSource = dataTable;
            ddlInstrumentID.DisplayMember = "Comp_Short_Code";

            rdbAll.Checked = true;

        }
        #endregion

        #region view report
        private void btnViewReport_Click(object sender, EventArgs e)
        {
            Bonus_Instrument_Confirmation_Reports_DSE_21_2BAL objBAL = new Bonus_Instrument_Confirmation_Reports_DSE_21_2BAL();
            DataTable data = new DataTable();
            frmReportViewer rptviewer = new frmReportViewer();
            crBonus_Instrument_Confirmation_Report_DSE_21_2 objrpt = new crBonus_Instrument_Confirmation_Report_DSE_21_2();

            try
            {
                CheckValidation();
                SetCustInfo();

                data = objBAL.GetBonusInstrumentConfirmationData(_instrumentId, dtpFromDate.Value, dtpToDate.Value, _custCode,_boid);
                objrpt.SetDataSource(data);
                rptviewer.crvReportViewer.ReportSource = objrpt;
                ((TextObject)objrpt.Section2.ReportObjects["txtStartDate"]).Text = Convert.ToDateTime(dtpFromDate.Value.ToString()).ToString("dd/MM/yyyy");
                ((TextObject)(objrpt.Section2.ReportObjects["txtEndDate"])).Text = Convert.ToDateTime(dtpToDate.Value.ToShortDateString()).ToString("dd/MM/yyyy"); 
                rptviewer.Show();
                ResetInputInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        #endregion

        #region Custinfo
        private void SetCustInfo()
        {
            Bonus_Instrument_Confirmation_Reports_DSE_21_2BAL objBAL = new Bonus_Instrument_Confirmation_Reports_DSE_21_2BAL();
            DataTable dtcustInfo = new DataTable();
            try
            {
                if(rdbAll.Checked)
                {
                    _custCode = "All";
                }
                if (rdbByCustCode.Checked)
                {
                    dtcustInfo = objBAL.GetCustomerInfo(txtByCustCode.Text.Trim(), "", "");
                    if (dtcustInfo.Rows.Count > 0)
                    {
                        _custCode = txtByCustCode.Text;
                        _boid = dtcustInfo.Rows[0][0].ToString();
                    }
                }

                else if (rdbByBOID.Checked)
                {
                    dtcustInfo = objBAL.GetCustomerInfo("", txtByBOID.Text.Trim(), "");
                    if (dtcustInfo.Rows.Count > 0)
                    {
                        _boid = txtByBOID.Text;
                        _custCode = dtcustInfo.Rows[0][0].ToString();
                    }
                }
                _instrumentId = ddlInstrumentID.Text.Trim();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Close Button
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region check validation
        private void CheckValidation()
        {
            if (rdbByCustCode.Checked && txtByCustCode.Text == "")
            {
                throw new Exception("Customer Code Required");
            }
            if (rdbByBOID.Checked && txtByBOID.Text == "")
            {
                throw new Exception("BOID Required");
            }
            if(ddlInstrumentID.SelectedIndex==-1)
            {
                throw new Exception("Instrument Name Required");
            }
        }
        #endregion

        #region Reset Field
        private void ResetInputInfo()
        {
            _custCode = string.Empty;
            _boid = string.Empty;
            _instrumentId = string.Empty;
        }
        #endregion

        #region All radio Button
        private void rdbByCustCode_CheckedChanged(object sender, EventArgs e)
        {
            txtByCustCode.Enabled = rdbByCustCode.Checked;
            if (!rdbByCustCode.Checked)
            {
                txtByCustCode.Text = string.Empty;
            }
        }

        private void rdbByBOID_CheckedChanged(object sender, EventArgs e)
        {
            txtByBOID.Enabled = rdbByBOID.Checked;
            if (!rdbByBOID.Checked)
            {
                txtByBOID.Text = string.Empty;
            }
        }

        private void rdbAll_CheckedChanged(object sender, EventArgs e)
        {
            if(rdbAll.Checked)
            {
                _custCode = "All";
            }
        }
        #endregion

        private void txtByBOID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
