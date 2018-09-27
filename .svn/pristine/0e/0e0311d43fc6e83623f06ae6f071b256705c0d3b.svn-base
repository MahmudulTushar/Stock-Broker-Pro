using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using BusinessAccessLayer.BAL;

namespace Reports
{
    public partial class frmClient_Today_Sale_Info : Form
    {

        Client_Today_Sale_InfoBAL objBAL = new Client_Today_Sale_InfoBAL();

        private string _CommpanyName;
        private string _branchName;
        private string _branchAddress;
        private string _branchContactNumber;
        
        public frmClient_Today_Sale_Info()
        {
            InitializeComponent();
            GetCommonInfo();
        }

        private void btnshow_Click(object sender, EventArgs e)
        {
            crClient_Today_Sale_Info objRPT = new crClient_Today_Sale_Info();
            frmPaymenrReportViewer paymentViewer = new frmPaymenrReportViewer();
             DataTable dt = new DataTable();
            dt = objBAL.Client_Today_Sale(dtpTradeDate.Value);
            objRPT.SetDataSource(dt);
            ((TextObject)objRPT.ReportDefinition.Sections[2].ReportObjects["txtCompanyName"]).Text = _CommpanyName;
            ((TextObject)objRPT.ReportDefinition.Sections[2].ReportObjects["txtAddress"]).Text = _branchName + "," + _branchAddress + ",Phone: " + _branchContactNumber;
            ((TextObject)objRPT.ReportDefinition.Sections[2].ReportObjects["txtTradeDate"]).Text = dtpTradeDate.Value.ToString("dd-MMM-yyyy");
            paymentViewer.crvPaymentReview.ReportSource = objRPT;
            paymentViewer.Show();
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
