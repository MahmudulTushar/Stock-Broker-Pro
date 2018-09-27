using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using BusinessAccessLayer.BAL;


namespace Reports
{
    public partial class frmToday_Transactions_Customer_List : Form
    {
        Today_Transactions_Customer_ListBAL objBAL = new Today_Transactions_Customer_ListBAL();

        private string _CommpanyName;
        private string _branchName;
        private string _branchAddress;
        private string _branchContactNumber;

        public frmToday_Transactions_Customer_List()
        {
            InitializeComponent();
            GetCommonInfo();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            crToday_Transactions_Customer_List objRPT = new crToday_Transactions_Customer_List();
            frmPaymenrReportViewer paymentViewer = new frmPaymenrReportViewer();
            DataTable dt = new DataTable();
            dt = objBAL.Today_Transactions_Customer(dtpToday.Value);
            objRPT.SetDataSource(dt);
            ((TextObject)objRPT.ReportDefinition.Sections[2].ReportObjects["txtCompanyName"]).Text = _CommpanyName;
            ((TextObject)objRPT.ReportDefinition.Sections[2].ReportObjects["txtAddress"]).Text = _branchName + "," + _branchAddress + ",Phone: " + _branchContactNumber;
            ((TextObject)objRPT.ReportDefinition.Sections[2].ReportObjects["txtTradeDate"]).Text = dtpToday.Value.ToString("dd-MMM-yyyy");
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
