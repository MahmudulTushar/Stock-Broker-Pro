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
using BusinessAccessLayer.Constants;

namespace Reports
{
    public partial class frmReportFormPeriod : Form
    {
        public frmReportFormPeriod()
        {
            InitializeComponent();
        }

        private string _title;

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        private string _CommpanyName;
        private string _branchName;
        private string _branchAddress;
        private string _branchContactNumber;
        private string _filterdColumnName;

        private void frmReportFormPeriod_Load(object sender, EventArgs e)
        {
            lblTitle.Text = _title;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_title.Equals("New Payment Review Report"))
            {
                this.Cursor = Cursors.WaitCursor;
                GetNewPaymentReview();
                this.Cursor = Cursors.Arrow;
            }
        }

        private void GetNewPaymentReview()
        {
            try
            {
                PaymentReviewBAL paymentBAL = new PaymentReviewBAL();
                DataTable dtPaymentReview = new DataTable();
                cr_NewPaymentReview crPayment = new cr_NewPaymentReview();
                frmPaymenrReportViewer paymentViewer = new frmPaymenrReportViewer();
                LoadCommonInfo CmmInfo = new LoadCommonInfo();

                int issorted = 0;
                int isAccountsView = 0;

                if (chbOder.Checked)
                    issorted = 1;
                else
                {
                    issorted = 0;
                }
             
                dtPaymentReview = paymentBAL.GnerateNewPaymentReview(dtpFromDate.Value,dtpToDate.Value,issorted);

                _filterdColumnName = dtPaymentReview.Columns[1].ToString();
                RecordLevelFilteringBAL obj = new RecordLevelFilteringBAL(dtPaymentReview, _filterdColumnName, ResourceName.New_Payment_Review);
                dtPaymentReview = obj.GetRecordLevelFilteredData();

                crPayment.SetDataSource(dtPaymentReview);

                GetCommonInfo();
                ///// Load Company Name
                ((TextObject)crPayment.ReportDefinition.Sections[2].ReportObjects["txtCompanyName"]).Text =_CommpanyName;

                ///// Load Branch Name
                ((TextObject)crPayment.ReportDefinition.Sections[2].ReportObjects["txtAddress"]).Text =_branchName + "," + _branchAddress + ",Phone: "+ _branchContactNumber ;

                ////Load Date
                ((TextObject)crPayment.ReportDefinition.Sections[2].ReportObjects["txtFromDate"]).Text =  dtpFromDate.Value.ToString("dd-MMM-yyyy") + " To " + dtpToDate.Value.ToString("dd-MMM-yyyy");

                paymentViewer.crvPaymentReview.DisplayGroupTree =false;
                paymentViewer.crvPaymentReview.ReportSource = crPayment;
                paymentViewer.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"",MessageBoxButtons.OK,MessageBoxIcon.Information);
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
