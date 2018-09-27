using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Data.SqlClient;
using System.Configuration;

namespace Reports
{
    public partial class Frm_CryRpt_Display : Form
    {
        ReportDocument _RptDoc;
        string _RptFormula;

        public Frm_CryRpt_Display()
        {
            InitializeComponent();
        }

        public void ShowDialog(ReportDocument RptDoc, string RptFormula)
        {

            _RptDoc = RptDoc;
            _RptFormula = RptFormula;
            this.ShowDialog();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void RptLoad()
        {
            try
            {
                if (_RptDoc != null)
                {
                    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(ConfigurationManager.ConnectionStrings["sqlcon"].ToString());


                    ConnectionInfo ci = new ConnectionInfo();

                    ci.UserID = builder.UserID;
                    ci.Password = builder.Password;
                    ci.ServerName = builder.DataSource;
                    ci.DatabaseName = builder.InitialCatalog;


                    foreach (CrystalDecisions.CrystalReports.Engine.Table tbl in _RptDoc.Database.Tables)
                    {
                        TableLogOnInfo logon = tbl.LogOnInfo;
                        logon.ConnectionInfo = ci;
                        tbl.ApplyLogOnInfo(logon);
                        tbl.Location = tbl.Location;
                    }

                    crystalReportViewer1.ReportSource = _RptDoc;

                    if (_RptFormula != string.Empty && _RptFormula != null)
                    {
                      crystalReportViewer1.SelectionFormula = _RptFormula;
                    }
                    crystalReportViewer1.RefreshReport();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void Frm_CryRpt_Display_Load(object sender, EventArgs e)
        {
            try
            {
                RptLoad();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Unabele to Open Repot");
            }
        }

        private void crystalReportViewer1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
