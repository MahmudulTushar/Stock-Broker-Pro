using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.BO;
using BusinessAccessLayer.BAL;
using Reports;
using CrystalDecisions.CrystalReports.Engine;

namespace StockbrokerProNewArch
{
    public partial class frmPaymentReviewReportCall : Form
    {
        public frmPaymentReviewReportCall()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            ReportView();
            this.Cursor = Cursors.Arrow;
        }

        private void ReportView()
        {
            try
            {
                CompanyBAL objCompanyBal = new CompanyBAL();
                PaymentReviewBAL paymentBAL = new PaymentReviewBAL();
                DataTable dtPaymentReview = new DataTable();
                crPaymentReview1 crPayment = new crPaymentReview1();
                frmPaymenrReportViewer paymentViewer = new frmPaymenrReportViewer();
                LoadCommonInfo CmmInfo = new LoadCommonInfo();
                BranchManagementBAL objBranchManagement = new BranchManagementBAL();

                dtPaymentReview = paymentBAL.GneratePaymentReviewByBranchWise(dtpFromDate.Value, dtpToDate.Value);
                crPayment.SetDataSource(dtPaymentReview);

                ///// Load Company Name
                ((TextObject)crPayment.ReportDefinition.Sections[2].ReportObjects["txtCompanyName"]).Text = CmmInfo.ShowCompanyName();

                ///// Load Branch Name
                ((TextObject)crPayment.ReportDefinition.Sections[2].ReportObjects["txtBranchName"]).Text = objCompanyBal.GetHeadofficeInfo();
                ////Load Date
                ((TextObject)crPayment.ReportDefinition.Sections[2].ReportObjects["txtReportDuration"]).Text = "Review Duration: " + dtpFromDate.Value.ToString("dd-MM-yyyy") + " " + dtpToDate.Value.ToString("dd-MM-yyyy");
                ((TextObject)crPayment.ReportDefinition.Sections[2].ReportObjects["txtBranch"]).Text = "Branch : "+objBranchManagement.GetBranchName();

                paymentViewer.crvPaymentReview.ReportSource = crPayment;
                paymentViewer.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void GetBranchName()
        {
            try
            {
                BranchManagementBAL objBranchManagement = new BranchManagementBAL();
                groupBox1.Text = "Payment Review of " + objBranchManagement.GetBranchName();
                label1.Text = "Branch: " + objBranchManagement.GetBranchName();
             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmPaymentReviewReportCall_Load(object sender, EventArgs e)
        {
            GetBranchName();
        }
    }
}
