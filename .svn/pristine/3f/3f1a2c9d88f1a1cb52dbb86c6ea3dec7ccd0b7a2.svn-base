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
using Reports;

namespace StockbrokerProNewArch
{
    public partial class frmPaymentOOCReport : Form
    {
        private string _CommpanyName;
        private string _branchName;
        private string _branchAddress;
        private string _branchContactNumber;

        public frmPaymentOOCReport()
        {
            InitializeComponent();
        }

      

        private void btnReport_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                GetPaymentOOC();
                this.Cursor = Cursors.Arrow;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void GetPaymentOOC()
        {
            try
            {
                cr_PaymentOOC objcrPaymentOcc = new cr_PaymentOOC(); 
                DataTable dataTable = new DataTable();
                frmReportViewer objReportviewer = new frmReportViewer();
                PaymentOOC objPaymentOOC=new PaymentOOC();
             


                dataTable = objPaymentOOC.GetPaymentOOcReport(dtpFromDate.Value,dtpToDate.Value);
                objcrPaymentOcc.SetDataSource(dataTable);

                GetCommonInfo();

                ((TextObject)objcrPaymentOcc.ReportDefinition.Sections[2].ReportObjects["txtCompanyName"]).Text = _CommpanyName;
                ((TextObject)objcrPaymentOcc.ReportDefinition.Sections[2].ReportObjects["txtAddress"]).Text = "Branch Name:" + _branchName + "," + _branchAddress + ". Phone:" + _branchContactNumber;


                ((TextObject)objcrPaymentOcc.ReportDefinition.Sections[2].ReportObjects["txtFromDate"]).Text = "Period : "+dtpFromDate.Value.ToString("dd-MMM-yyyy") + " To " + dtpToDate.Value.ToString("dd-MMM-yyyy");
               
                objReportviewer.crvReportViewer.ReportSource = objcrPaymentOcc;
                objReportviewer.Text = "Payment OOC Report";
                objReportviewer.crvReportViewer.DisplayGroupTree = false;
                objReportviewer.Show();


            }
            catch (Exception)
            {

                throw;
            }
        }

        private void GetCommonInfo()
        {

            try
            {
                CommonInfoBal objCommonInfoBal = new CommonInfoBal();
                DataRow drCommonInfo = null;

                drCommonInfo = objCommonInfoBal.GetCommpanyInfo();

                if (drCommonInfo != null)
                {
                    _CommpanyName = drCommonInfo.Table.Rows[0][0].ToString();
                    _branchName = drCommonInfo.Table.Rows[0][1].ToString();
                    _branchAddress = drCommonInfo.Table.Rows[0][2].ToString();
                    _branchContactNumber = drCommonInfo.Table.Rows[0][3].ToString();


                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
