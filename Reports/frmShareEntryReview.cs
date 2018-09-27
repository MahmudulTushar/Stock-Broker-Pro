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

namespace Reports
{
    public partial class frmShareEntryReview : Form
    {
        public frmShareEntryReview()
        {
            InitializeComponent();
        }

        
        private string _CommpanyName;
        private string _branchName;
        private string _branchAddress;
        private string _branchContactNumber;
        
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                GetShareReviewEntry(dtpTradeDate.Value);
                this.Cursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GetShareReviewEntry(DateTime date)
        {
            try
            {
                cr_ShareEntryReview objcrReviewShare = new cr_ShareEntryReview();
                DataTable dataTable = new DataTable();
                frmReportViewer objReportviewer = new frmReportViewer();
                ShareDWBAL objShareDW = new ShareDWBAL();
                
                dataTable = objShareDW.GetDayShareSummary(date);
                objcrReviewShare.SetDataSource(dataTable);

                GetCommonInfo();

                ((TextObject)objcrReviewShare.ReportDefinition.Sections[2].ReportObjects["txtCompanyName"]).Text = _CommpanyName;
                ((TextObject)objcrReviewShare.ReportDefinition.Sections[2].ReportObjects["txtAddress"]).Text = "Branch Name:" + _branchName + "," + _branchAddress + ". Phone:" + _branchContactNumber;                
                ((TextObject)objcrReviewShare.ReportDefinition.Sections[2].ReportObjects["txtTradeDate"]).Text =date.ToString("dd-MMM-yyyy");
                
                objReportviewer.crvReportViewer.ReportSource = objcrReviewShare;
                objReportviewer.Text = "Share Review Entry";
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

          private void frmShareEntryReview_Load(object sender, EventArgs e)
          {

          }


    }
}
