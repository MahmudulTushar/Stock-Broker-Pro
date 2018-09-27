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
    public partial class frmMonthCommonReportWind : Form
    {
        public frmMonthCommonReportWind()
        {
            InitializeComponent();
        }

        private void frmMonthCommonReportWind_Load(object sender, EventArgs e)
        {
            GetBranchLIst();
        }

        private void GetBranchLIst()
        {
            try
            {
                CommonInfoBal objComm = new CommonInfoBal();
                DataTable data = new DataTable();

                data = objComm.GetBranchList();


                DataRow dr = data.NewRow();
                dr["Branch_ID"] = 0;
                dr["Branch_Name"] = "All";

                data.Rows.InsertAt(dr, 0);
                ddlBranchList.DataSource = data;
                ddlBranchList.DisplayMember = "Branch_Name";
                ddlBranchList.ValueMember = "Branch_ID";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private string _CommpanyName;
        private string _branchName;
        private string _branchAddress;
        private string _branchContactNumber;

        private int _reportCatagory;
        public int ReportCatagory
        {
            get { return _reportCatagory; }
            set { _reportCatagory = value; }
        }


        private void ChangeToDateTimeFormat()
        {
            if (rbtMonthly.Checked)
            {
                this.dtpFromDate.CustomFormat = "MMMM-yyyy";
                this.dtpToDate.CustomFormat = "MMMM-yyyy";
            }

            else if (rbtYearly.Checked)
            {
                this.dtpFromDate.CustomFormat = "yyyy";
                this.dtpToDate.CustomFormat = "yyyy";
            }

        }

        private void rbtMonthly_CheckedChanged(object sender, EventArgs e)
        {
            ChangeToDateTimeFormat();
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

        private void GetMonthlyWiseOpexReport(DateTime fromDate, DateTime toDate)
        {
            try
            {
                cr_MonthlyOpex objcrMonthlyOpex = new cr_MonthlyOpex();
                DataTable dataTable = new DataTable();
                frmReportViewer objReportviewer = new frmReportViewer();
                RecordLevelFilteringBAL recordLevelFilteringBAL = new RecordLevelFilteringBAL();
                int TempBranchId = -2;
                OpexBAL objOpexBal = new OpexBAL();

                int branchid = Int32.Parse(ddlBranchList.SelectedValue.ToString());

                int resourceId = recordLevelFilteringBAL.GetResourceID(ResourceName.Monthly_Expenditure_Monthly_Opex);
                int criteriaId = recordLevelFilteringBAL.GetCriteriaID(resourceId);


                if (branchid == 0)
                {
                    TempBranchId = Convert.ToInt32(recordLevelFilteringBAL.FilterWorkStation_All(branchid.ToString(), resourceId, criteriaId));
                    if (TempBranchId == 0)
                    {
                        dataTable = objOpexBal.GetAllBranchDailyOpex(fromDate, toDate, TempBranchId);
                    }
                    else
                    {
                        dataTable = objOpexBal.GetAllBranchDailyOpex(fromDate, toDate, TempBranchId);
                        dataTable.Rows.Clear();
                    }
                }
                else
                {
                    TempBranchId = Convert.ToInt32(recordLevelFilteringBAL.FilterBranchID(branchid.ToString(), resourceId, criteriaId));

                    dataTable = objOpexBal.GetMonthwiseMonthlyOpexReport(fromDate, toDate, TempBranchId);
                }
                objcrMonthlyOpex.SetDataSource(dataTable);

                GetCommonInfo();
                ((TextObject)objcrMonthlyOpex.ReportDefinition.Sections[2].ReportObjects["txtCompanyName"]).Text = _CommpanyName;
                ((TextObject)objcrMonthlyOpex.ReportDefinition.Sections[2].ReportObjects["txtAddress"]).Text = "Branch Name:" + _branchName + "," + _branchAddress + ". Phone:" + _branchContactNumber;

                ((TextObject)objcrMonthlyOpex.ReportDefinition.Sections[2].ReportObjects["txtReport"]).Text = "Montly Opex Report : Month Wise";
                ((TextObject)objcrMonthlyOpex.ReportDefinition.Sections[2].ReportObjects["txtFrom"]).Text = fromDate.ToString("dd-MMM-yyyy");
                ((TextObject)objcrMonthlyOpex.ReportDefinition.Sections[2].ReportObjects["txtTo"]).Text = toDate.ToString("dd-MMM-yyyy");
                ((TextObject)objcrMonthlyOpex.ReportDefinition.Sections[2].ReportObjects["txtBranchName"]).Text = ddlBranchList.Text;



                objReportviewer.crvReportViewer.ReportSource = objcrMonthlyOpex;
                objReportviewer.Text = "Monthly Opex Report : Monthly Wise";
                objReportviewer.Show();


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void GetYearWiseOpexReport(DateTime fromDate, DateTime toDate)
        {
            try
            {
                cr_YearlyMonthOpex objcrYearlyOpex = new cr_YearlyMonthOpex();
                DataTable dataTable = new DataTable();
                frmReportViewer objReportviewer = new frmReportViewer();
                RecordLevelFilteringBAL recordLevelFilteringBAL = new RecordLevelFilteringBAL();
                int TempBranchId = -2;
                OpexBAL objOpexBal = new OpexBAL();

                int branchid = Int32.Parse(ddlBranchList.SelectedValue.ToString());
                int resourceId = recordLevelFilteringBAL.GetResourceID(ResourceName.Monthly_Expenditure_Yearly_Month_Opex);
                int criteriaId = recordLevelFilteringBAL.GetCriteriaID(resourceId);

                if (branchid == 0)
                {
                    TempBranchId = Convert.ToInt32(recordLevelFilteringBAL.FilterWorkStation_All(branchid.ToString(), resourceId, criteriaId));
                    if (TempBranchId == 0)
                    {
                        dataTable = objOpexBal.GetAllBranchDailyOpex(fromDate, toDate, TempBranchId);
                    }
                    else
                    {
                        dataTable = objOpexBal.GetAllBranchDailyOpex(fromDate, toDate, TempBranchId);
                        dataTable.Rows.Clear();
                    }
                }
                else
                {
                    TempBranchId = Convert.ToInt32(recordLevelFilteringBAL.FilterBranchID(branchid.ToString(), resourceId, criteriaId));

                    dataTable = objOpexBal.GetYearwiseMonthlyOpexReport(fromDate, toDate, TempBranchId);
                }
                objcrYearlyOpex.SetDataSource(dataTable);

                GetCommonInfo();
                ((TextObject)objcrYearlyOpex.ReportDefinition.Sections[2].ReportObjects["txtCompanyName"]).Text = _CommpanyName;
                ((TextObject)objcrYearlyOpex.ReportDefinition.Sections[2].ReportObjects["txtAddress"]).Text = "Branch Name:" + _branchName + "," + _branchAddress + ". Phone:" + _branchContactNumber;

                ((TextObject)objcrYearlyOpex.ReportDefinition.Sections[2].ReportObjects["txtReport"]).Text = "Montly Opex Report : Year wise";
                ((TextObject)objcrYearlyOpex.ReportDefinition.Sections[2].ReportObjects["txtFrom"]).Text =  fromDate.Year.ToString();
                ((TextObject)objcrYearlyOpex.ReportDefinition.Sections[2].ReportObjects["txtTo"]).Text = toDate.Year.ToString();
                ((TextObject)objcrYearlyOpex.ReportDefinition.Sections[2].ReportObjects["txtBranchName"]).Text = ddlBranchList.Text;



                objReportviewer.crvReportViewer.ReportSource = objcrYearlyOpex;
                objReportviewer.Text = "Monthly Opex Report : Year wise";
                objReportviewer.Show();


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }


        private void btnReport_Click(object sender, EventArgs e)
        {
            if (rbtMonthly.Checked)
            {
                this.Cursor = Cursors.WaitCursor;
                DateTime fromDate = GetFirstDayOfMonth(dtpFromDate.Value);
                DateTime toDate = GetLastDayOfMonth(dtpToDate.Value);
                GetMonthlyWiseOpexReport(fromDate,toDate);
                this.Cursor = Cursors.Arrow;
            }

            if (rbtYearly.Checked)
            {
                this.Cursor = Cursors.WaitCursor;
                GetYearWiseOpexReport(dtpFromDate.Value, dtpToDate.Value);
                this.Cursor = Cursors.Arrow;
            }
        }

        private DateTime GetFirstDayOfMonth(DateTime date)
        {
            return (new DateTime(date.Year, date.Month, 1));
        }

        private DateTime GetLastDayOfMonth(DateTime date)
        {
            DateTime FirstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            return (FirstDayOfMonth.AddMonths(1).AddDays(-1));
        }

       

    }
}
