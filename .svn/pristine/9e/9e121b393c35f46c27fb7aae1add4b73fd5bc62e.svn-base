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
    public partial class frmImageListReport : Form
    {
        private string _CommpanyName;
        private string _branchName;
        private string _branchAddress;
        private string _branchContactNumber;

        public frmImageListReport()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                AccountImageList();
                this.Cursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AccountImageList()
        {
            try
            {
                SaveImgBAL objImage = new SaveImgBAL();
                DataTable data = new DataTable();
                cr_AccountImageList objcrAccountImageList = new cr_AccountImageList();
                frmReportViewer objfrmReportViewer = new frmReportViewer();

                data = objImage.GetAccountImageList(ddlDoucmentType.SelectedIndex);
                objcrAccountImageList.SetDataSource(data);

                
                ((TextObject)objcrAccountImageList.ReportDefinition.Sections[2].ReportObjects["txtReportType"]).Text =ddlDoucmentType.Text + " Report";

                GetCommonInfo();
                ((TextObject)objcrAccountImageList.ReportDefinition.Sections[2].ReportObjects["txtCompanyName"]).Text = _CommpanyName;
                ((TextObject)objcrAccountImageList.ReportDefinition.Sections[2].ReportObjects["txtAddress"]).Text = "Branch Name:" + _branchName + "," + _branchAddress + ". Phone:" + _branchContactNumber;


                objfrmReportViewer.Text = "Account Image List";
                objfrmReportViewer.crvReportViewer.DisplayGroupTree = false;
                objfrmReportViewer.crvReportViewer.ReportSource = objcrAccountImageList;
                objfrmReportViewer.Show();


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

        private void frmImageListReport_Load(object sender, EventArgs e)
        {
            ddlDoucmentType.SelectedIndex = 0;
        }

    }
}
