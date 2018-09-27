using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using BusinessAccessLayer.BO;
using System.Threading;
using CrystalDecisions.CrystalReports.Engine;
using Reports;
using BusinessAccessLayer.Constants;

namespace Reports
{
    public partial class frmReview : Form
    {
        public static DateTime _fromDate;
        public static DateTime _toDate;
        public static  int  _branchId;
        private string _filterdColumnName;

        public frmReview()
        {
            InitializeComponent();
        }

        private void btnPaymentReview_Click(object sender, EventArgs e)
        {
            ShowPaymentReviewReport();
        }
        
        public void ShowPaymentReviewReport()
        {
            _branchId = GlobalVariableBO._branchId;
            _fromDate = Convert.ToDateTime(dtpFrom.Value.ToShortDateString());
            _toDate = Convert.ToDateTime(dtpTO.Value.ToShortDateString());
            PaymentReviewBAL paymentBAL = new PaymentReviewBAL();
            DataTable dtPaymentReview = new DataTable();
            crPaymentReview1 crPayment = new crPaymentReview1();
            frmPaymenrReportViewer paymentViewer = new frmPaymenrReportViewer();
            LoadCommonInfo CmmInfo = new LoadCommonInfo();
            dtPaymentReview = paymentBAL.GneratePaymentReview(_fromDate,_toDate);

            //_filterdColumnName = dtPaymentReview.Columns[1].ToString();
            //RecordLevelFilteringBAL obj = new RecordLevelFilteringBAL(dtPaymentReview, _filterdColumnName, ResourceName.Review_Report_Payment_Review);
            //dtPaymentReview = obj.GetRecordLevelFilteredData();

            crPayment.SetDataSource(dtPaymentReview);

           ///// Load Company Name
           ((TextObject)crPayment.ReportDefinition.Sections[2].ReportObjects["txtCompanyName"]).Text = CmmInfo.ShowCompanyName();

           ///// Load Branch Name
           ((TextObject)crPayment.ReportDefinition.Sections[2].ReportObjects["txtBranchName"]).Text = CmmInfo.BranchDetails(_branchId);
           ////Load Date
           if (_fromDate != null && _toDate != null)
           {
               ((TextObject)crPayment.ReportDefinition.Sections[2].ReportObjects["txtReportDuration"]).Text = "From " + _fromDate.ToShortDateString() + " To " + _toDate.ToShortDateString();

           }
           paymentViewer.crvPaymentReview.ReportSource = crPayment;
           paymentViewer.Show();
        }

        private void btnDepositeWithdrawl_Click(object sender, EventArgs e)
        {
           ShowShareDWReviewReport();

        }
       
        public void ShowShareDWReviewReport()
        {
            _branchId = GlobalVariableBO._branchId;
            _fromDate = Convert.ToDateTime(dtpFrom.Value.ToShortDateString());
            _toDate = Convert.ToDateTime(dtpTO.Value.ToShortDateString());
            ShareDWReviewBAL shareDwReviewBal = new ShareDWReviewBAL();
            DataTable dtShareDWReview = new DataTable();
            crShareDWReview crShareDwReview = new crShareDWReview();
            frmShareDWReviewReportViewer shareDWReportViewer = new frmShareDWReviewReportViewer();
            LoadCommonInfo CmmInfo = new LoadCommonInfo();
            dtShareDWReview = shareDwReviewBal.GetShareDWReview(_fromDate, _toDate);

            //_filterdColumnName = dtShareDWReview.Columns[1].ToString();
            //RecordLevelFilteringBAL obj = new RecordLevelFilteringBAL(dtShareDWReview, _filterdColumnName, ResourceName.Review_Report_Share_DW_Review);
            //dtShareDWReview = obj.GetRecordLevelFilteredData();

            crShareDwReview.SetDataSource(dtShareDWReview);

            ///// Load Company Name
            ((TextObject)crShareDwReview.ReportDefinition.Sections[2].ReportObjects["txtCompanyName"]).Text = CmmInfo.ShowCompanyName();

            ///// Load Branch Name
            ((TextObject)crShareDwReview.ReportDefinition.Sections[2].ReportObjects["txtBranchName"]).Text = CmmInfo.BranchDetails(_branchId);
            ////Load Date
            if (_fromDate != null && _toDate != null)
            {
                ((TextObject)crShareDwReview.ReportDefinition.Sections[2].ReportObjects["txtReportDuration"]).Text = "From " + _fromDate.ToShortDateString() + " To " + _toDate.ToShortDateString();

            }
             shareDWReportViewer.crvShareReview.ReportSource = crShareDwReview;
            shareDWReportViewer.Show();
        }
    }
}
