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
    public partial class frmMonthlyExpense : Form
    {
        private string _CommpanyName;
        private string _branchName;
        private string _branchAddress;
        private string _branchContactNumber;

        public frmMonthlyExpense()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMonthlyExpense_Load(object sender, EventArgs e)
        {

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

       

        private void btnview_Click(object sender, EventArgs e)
        {
           try
            {
                
                ShowMonthlyExpenseReport(dtpFromDate.Value,dtpToDate.Value);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Monthly Expense", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpFromDate.Focus();
            }
        }

 
        private void ShowMonthlyExpenseReport(DateTime FromDate,DateTime ToDate)
        {
            try
            {
                AssetInformationBAL objAssetInfoBal=new AssetInformationBAL();
                DataTable dtMonthlyExpenseInfo = new DataTable();
                cr_MonthlyExpenseReport objcrMonthlyExpenseInfo=new cr_MonthlyExpenseReport();
                frmReportViewer objfrmMonthlyExpenseInfo=new frmReportViewer();
                RecordLevelFilteringBAL recordLevelFilteringBAL = new RecordLevelFilteringBAL();
                int TempBranchId = -2;

                dtMonthlyExpenseInfo = objAssetInfoBal.GetMonthlyCapexReport(FromDate, ToDate);

                int branchid = Int32.Parse(dtMonthlyExpenseInfo.Rows[0][10].ToString());
                int resourceId = recordLevelFilteringBAL.GetResourceID(ResourceName.Monthly_Expense_List);
                int criteriaId = recordLevelFilteringBAL.GetCriteriaID(resourceId);


                TempBranchId = Convert.ToInt32(recordLevelFilteringBAL.FilterBranchID(branchid.ToString(), resourceId, criteriaId));
                if (TempBranchId == -1)
                    dtMonthlyExpenseInfo.Rows.Clear();

                objcrMonthlyExpenseInfo.SetDataSource(dtMonthlyExpenseInfo);

                ((TextObject)objcrMonthlyExpenseInfo.ReportDefinition.Sections[2].ReportObjects["txtFromDate"]).Text ="Fom: " + dtpFromDate.Value.ToString("MM-dd-yyyy");
                ((TextObject)objcrMonthlyExpenseInfo.ReportDefinition.Sections[2].ReportObjects["txtToDate"]).Text = "To: " + dtpToDate.Value.ToString("MM-dd-yyyy");

                GetCommonInfo();
                ((TextObject)objcrMonthlyExpenseInfo.ReportDefinition.Sections[2].ReportObjects["txtCompanyName"]).Text = _CommpanyName;
                ((TextObject)objcrMonthlyExpenseInfo.ReportDefinition.Sections[2].ReportObjects["txtAddress"]).Text = "Branch Name:" + _branchName + "," + _branchAddress + ". Phone:" + _branchContactNumber;


                objfrmMonthlyExpenseInfo.Text = "Monthly Expense Report";
                objfrmMonthlyExpenseInfo.crvReportViewer.ReportSource = objcrMonthlyExpenseInfo;
                objfrmMonthlyExpenseInfo.Show();


            }
            catch (Exception)
            {
                
                throw;
            }

        }
    }
}
