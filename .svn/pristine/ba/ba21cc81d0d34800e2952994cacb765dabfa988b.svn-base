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
    public partial class frmRegistration_Confirmation_Report_DSE_21_4 : Form
    {
        private  string _custCode;
        private string _boid;
        private  string _custName;
        public frmRegistration_Confirmation_Report_DSE_21_4()
        {
            InitializeComponent();
        }

        private void btnViewReport_Click(object sender, EventArgs e)
        {
            Registration_Confirmation_Reports_DSE_21_4BAL objBAL = new Registration_Confirmation_Reports_DSE_21_4BAL();
            DataTable data = new DataTable();
            frmReportViewer rptviewer = new frmReportViewer();
            crRegistration_Confirmation_Report_DSE_21_4 objrpt = new crRegistration_Confirmation_Report_DSE_21_4();
            _boid = txtByBOID.Text;
            _custCode = txtByCustCode.Text;
            _custName = txtByName.Text;
            try
            {
                CheckValidation();
                //SetCustInfo();
                if (txtByBOID.Text==""&&txtByName.Text=="")
                {
                    _boid = objBAL.GetBoid(_custCode, _custName);
                    _custName = objBAL.GetCustName(_custCode, _boid);
                    //_custCode = objBAL.GetCustCode(_custName, _boid);
                }
                else if (txtByName.Text == string.Empty && txtByCustCode.Text==string.Empty)
                {
                    _custName = objBAL.GetCustName(_custCode, _boid);
                    //_boid = objBAL.GetBoid(_custCode, _custName);
                    _custCode = objBAL.GetCustCode(_custName, _boid);
                    
                }
                else if (txtByCustCode.Text == string.Empty||txtByBOID.Text==string.Empty)
                {
                    _custCode = objBAL.GetCustCode(_custName, _boid);
                    _boid = objBAL.GetBoid(_custCode, _custName);
                    //_custName = objBAL.GetCustName(_custCode, _boid);
                }
                data = objBAL.GetRegistrationConfirmationReportData(_custCode, _boid, _custName);
                objrpt.SetDataSource(data);
                rptviewer.crvReportViewer.ReportSource = objrpt;
                rptviewer.Show();
                ResetCustInfo();
            }
            catch(Exception ex )
            {
                MessageBox.Show(ex.Message);
            }
        }
        //private void SetCustInfo()
        //{
        //    Registration_Confirmation_Reports_DSE_21_4BAL objBAL = new Registration_Confirmation_Reports_DSE_21_4BAL();
        //    DataTable dtcustInfo = new DataTable();
        //    try
        //    {
        //        if (rdbByCustCode.Checked)
        //        {
        //            dtcustInfo = objBAL.GetCustomerInfo(txtByCustCode.Text.Trim(), "", "");
        //            if (dtcustInfo.Rows.Count > 0)
        //            {
        //                _custCode = txtByCustCode.Text;
        //                //_boid = dtcustInfo.Rows[0][0].ToString();
        //                //_custName = dtcustInfo.Rows[0][1].ToString();
        //            }
        //        }

        //        else if (rdbByBOID.Checked)
        //        {
        //            dtcustInfo = objBAL.GetCustomerInfo("", txtByBOID.Text.Trim(), "");
        //            if (dtcustInfo.Rows.Count > 0)
        //            {
        //                _boid = txtByBOID.Text;
        //                //_custCode = dtcustInfo.Rows[0][0].ToString();
        //                //_custName = dtcustInfo.Rows[0][1].ToString();
        //            }
        //        }

        //        else if (rdbByName.Checked)
        //        {
        //            dtcustInfo = objBAL.GetCustomerInfo("", "", txtByName.Text.Trim());
        //            if (dtcustInfo.Rows.Count > 0)
        //            {
        //                _custName = txtByName.Text;
        //                //_custCode = dtcustInfo.Rows[0][0].ToString();
        //                //_boid = dtcustInfo.Rows[0][1].ToString();
        //            }
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        private void ResetCustInfo()
        {
            _custCode = string.Empty;
            _boid = string.Empty;
            _custName = string.Empty;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rdbByCustCode_CheckedChanged(object sender, EventArgs e)
        {
            txtByCustCode.Enabled = rdbByCustCode.Checked;
            if(!rdbByCustCode.Checked)
            {
                txtByCustCode.Text = string.Empty;
            }
        }

        private void rdbByBOID_CheckedChanged(object sender, EventArgs e)
        {
            txtByBOID.Enabled = rdbByBOID.Checked;
            if(!rdbByBOID.Checked)
            {
                txtByBOID.Text = string.Empty;
            }
        }

        private void rdbByName_CheckedChanged(object sender, EventArgs e)
        {
            txtByName.Enabled = rdbByName.Checked;
            if(!rdbByName.Checked)
            {
                txtByName.Text = string.Empty;
            }
        }
        private void CheckValidation()
        {
            if (rdbByCustCode.Checked && txtByCustCode.Text =="")
            {
                throw  new Exception("Customer Code Required");
            }
            if (rdbByBOID.Checked && txtByBOID.Text =="")
            {
                throw new Exception("BOID Required");
            }
            if (rdbByName.Checked && txtByName.Text =="")
            {
                throw new Exception("Customer Name Required");
            }
        }

        private void frmRegistration_Confirmation_Report_DSE_21_4_Load(object sender, EventArgs e)
        {
            if(rdbByCustCode.Checked)
            {
                txtByCustCode.Enabled = true; 
            }
            
        }
    }
}
