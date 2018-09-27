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
    public partial class frmCommonDateReport : Form
    {
        public frmCommonDateReport()
        {
            InitializeComponent();
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

        private void frmCommonDateReport_Load(object sender, EventArgs e)
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

        private void SeleteDatetimeFormat()
        {
            if (rbtnDaily.Checked)
            {
                dtpFrom.CustomFormat = "dd-MM-yyyy";
                dtpTo.CustomFormat = "dd-MM-yyyy";
            }

            else if (rbtMonthly.Checked)
            {
                dtpFrom.CustomFormat = "MMM-yyyy";
                dtpTo.CustomFormat = "MMM-yyyy";

            }

            else if (rbtYearly.Checked)
            {
                dtpFrom.CustomFormat = "yyyy";
                dtpTo.CustomFormat = "yyyy";
            }

            else if (rbtCustomize.Checked)
            {
                dtpFrom.CustomFormat = "dd-MM-yyyy";
                dtpTo.CustomFormat = "dd-MM-yyyy";
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbtnDaily_CheckedChanged(object sender, EventArgs e)
        {
            SeleteDatetimeFormat();
        }

        private void rbtMonthly_CheckedChanged(object sender, EventArgs e)
        {
            SeleteDatetimeFormat();
        }

        private void rbtYearly_CheckedChanged(object sender, EventArgs e)
        {
            SeleteDatetimeFormat();
        }

        private void rbtCustomize_CheckedChanged(object sender, EventArgs e)
        {
            SeleteDatetimeFormat();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            //if (ddlBranchList.Text == "All")
            {
                if (rbtnDaily.Checked)
                {
                    this.Cursor = Cursors.WaitCursor;
                    GetDailyDaywiseOpexReport(dtpFrom.Value, dtpTo.Value);
                    this.Cursor = Cursors.Arrow;
                }

                else if (rbtMonthly.Checked)
                {
                    this.Cursor = Cursors.WaitCursor;
                    DateTime fromDate = GetFirstDayOfMonth(dtpFrom.Value);
                    DateTime Todate = GetLastDayOfMonth(dtpTo.Value);
                    GetMonthlyOpexReport(fromDate, Todate);
                    this.Cursor = Cursors.Arrow;
                }

                else if (rbtYearly.Checked)
                {
                    this.Cursor = Cursors.WaitCursor;
                    GetYearlyOpexReport(dtpFrom.Value, dtpTo.Value);
                    this.Cursor = Cursors.Arrow;
                }

                else if (rbtCustomize.Checked)
                {
                    this.Cursor = Cursors.WaitCursor;
                    GetCustomizedOpexReport(dtpFrom.Value, dtpTo.Value);
                    this.Cursor = Cursors.Arrow;
                }
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

        private void GetDailyDaywiseOpexReport(DateTime fromDate, DateTime toDate)
        {
            try
            {
                cr_groupByBranchDailyOpexReport objcrDailyOpex = new cr_groupByBranchDailyOpexReport();
                DataTable dataTable = new DataTable();
                frmReportViewer objReportviewer = new frmReportViewer();
                RecordLevelFilteringBAL recordLevelFilteringBAL = new RecordLevelFilteringBAL();
                OpexBAL objOpexBal = new OpexBAL();
                int TempBranchId = -2;

                int resourceId = recordLevelFilteringBAL.GetResourceID(ResourceName.Daily_Expenditure_group_By_Branch_Daily_Opex_Report);
                int criteriaId = recordLevelFilteringBAL.GetCriteriaID(resourceId);

                int branchId = Int32.Parse(ddlBranchList.SelectedValue.ToString());

                if (branchId == 0)
                {
                    TempBranchId = Convert.ToInt32(recordLevelFilteringBAL.FilterWorkStation_All(branchId.ToString(), resourceId, criteriaId));
                    if (TempBranchId == 0)
                    {
                        dataTable = objOpexBal.GetAllBranchDailyOpex(fromDate, toDate, TempBranchId);
                    }
                    else
                    {
                        //dataTable = objOpexBal.GetAllBranchDailyOpex(fromDate, toDate, branchId);
                        //dataTable.Rows.Clear();
                        MessageBox.Show("You are restricted");
                        return;
                    }
                }
                else if (branchId != 0)
                {
                    TempBranchId = Convert.ToInt32(recordLevelFilteringBAL.FilterBranchID(branchId.ToString(), resourceId, criteriaId));
                    if (branchId != TempBranchId)
                    {
                        MessageBox.Show("You are restricted");
                        return;
                    }
                    dataTable = objOpexBal.GetAllBranchDailyOpex(fromDate, toDate, TempBranchId);
                }
                objcrDailyOpex.SetDataSource(dataTable);

                GetCommonInfo();
                ((TextObject)objcrDailyOpex.ReportDefinition.Sections[1].ReportObjects["txtCompanyName"]).Text = _CommpanyName;
                ((TextObject)objcrDailyOpex.ReportDefinition.Sections[1].ReportObjects["txtAddress"]).Text = "Branch Name:" + _branchName + "," + _branchAddress + ". Phone:" + _branchContactNumber;

                ((TextObject)objcrDailyOpex.ReportDefinition.Sections[1].ReportObjects["txtReportTitle"]).Text = "Day wise Daily Opex ";
                ((TextObject)objcrDailyOpex.ReportDefinition.Sections[1].ReportObjects["txtFromDate"]).Text = fromDate.ToString("dd-MMM-yyyy");
                ((TextObject)objcrDailyOpex.ReportDefinition.Sections[1].ReportObjects["txtToDate"]).Text = toDate.ToString("dd-MMM-yyyy");
                ((TextObject)objcrDailyOpex.ReportDefinition.Sections[1].ReportObjects["txtBranchName"]).Text = ddlBranchList.Text;



                objReportviewer.crvReportViewer.ReportSource = objcrDailyOpex;
                objReportviewer.Text = "Daily Opex Report : Day wise";
                objReportviewer.Show();


            }
            catch (Exception)
            {

                throw;
            }
        }

        private void GetMonthlyOpexReport(DateTime fromDate, DateTime toDate)
        {
            try
            {
                cr_MonthlyOpex objcrMonthlyOpex = new cr_MonthlyOpex();
                DataTable dataTable = new DataTable();
                frmReportViewer objReportviewer = new frmReportViewer();
                RecordLevelFilteringBAL recordLevelFilteringBAL = new RecordLevelFilteringBAL();
                OpexBAL objOpexBal = new OpexBAL();
                int TempBranchId = -2;
                int BranchId = Int32.Parse(ddlBranchList.SelectedValue.ToString());


                int resourceId = recordLevelFilteringBAL.GetResourceID(ResourceName.Daily_Expenditure_Monthly_Opex);
                int criteriaId = recordLevelFilteringBAL.GetCriteriaID(resourceId);

                if (BranchId == 0)
                {
                    TempBranchId = Convert.ToInt32(recordLevelFilteringBAL.FilterWorkStation_All(BranchId.ToString(), resourceId, criteriaId));
                    if (BranchId != TempBranchId)
                    {
                        MessageBox.Show("You are restricted");
                        return;
                    }
                    else
                    {
                        dataTable = objOpexBal.GetAllBranchDailyOpex(fromDate, toDate, TempBranchId);
                    }
                }
                else
                {
                    TempBranchId = Convert.ToInt32(recordLevelFilteringBAL.FilterBranchID(BranchId.ToString(), resourceId, criteriaId));
                    if (BranchId != TempBranchId)
                    {
                        MessageBox.Show("You are restricted");
                        return;
                    }
                    else
                    {
                        dataTable = objOpexBal.GetMonthwiseDailyOpexReport(fromDate, toDate, TempBranchId);
                    }
                }
                objcrMonthlyOpex.SetDataSource(dataTable);

                GetCommonInfo();
                ((TextObject)objcrMonthlyOpex.ReportDefinition.Sections[2].ReportObjects["txtCompanyName"]).Text = _CommpanyName;
                ((TextObject)objcrMonthlyOpex.ReportDefinition.Sections[2].ReportObjects["txtAddress"]).Text = "Branch Name:" + _branchName + "," + _branchAddress + ". Phone:" + _branchContactNumber;

                ((TextObject)objcrMonthlyOpex.ReportDefinition.Sections[2].ReportObjects["txtReport"]).Text = "Daily Opex Report: Month wise";
                ((TextObject)objcrMonthlyOpex.ReportDefinition.Sections[2].ReportObjects["txtFrom"]).Text = fromDate.ToString("dd-MMM-yyyy");
                ((TextObject)objcrMonthlyOpex.ReportDefinition.Sections[2].ReportObjects["txtTo"]).Text = toDate.ToString("dd-MMM-yyyy");
                ((TextObject)objcrMonthlyOpex.ReportDefinition.Sections[2].ReportObjects["txtBranchName"]).Text = ddlBranchList.Text;


                objReportviewer.crvReportViewer.ReportSource = objcrMonthlyOpex;
                objReportviewer.Text = "Daily Opex Report: Month wise";
                objReportviewer.Show();


            }
            catch (Exception)
            {

                throw;
            }
        }

        private void GetYearlyOpexReport(DateTime fromDate, DateTime toDate)
        {
            try
            {
                cr_YearlyOPex objcrYearlyOpex = new cr_YearlyOPex();
                DataTable dataTable = new DataTable();
                frmReportViewer objReportviewer = new frmReportViewer();
                RecordLevelFilteringBAL recordLevelFilteringBAL = new RecordLevelFilteringBAL();
                int TempBranchId = -2;
                OpexBAL objOpexBal = new OpexBAL();

                int BranchId = Int32.Parse(ddlBranchList.SelectedValue.ToString());

                int resourceId = recordLevelFilteringBAL.GetResourceID(ResourceName.Daily_Expenditure_Yearly_OPex);
                int criteriaId = recordLevelFilteringBAL.GetCriteriaID(resourceId);
                if (BranchId == 0)
                {
                    TempBranchId = Convert.ToInt32(recordLevelFilteringBAL.FilterWorkStation_All(BranchId.ToString(), resourceId, criteriaId));
                    if (BranchId != TempBranchId)
                    {
                        MessageBox.Show("You are restricted");
                        return;
                    }
                    else
                    {
                        dataTable = objOpexBal.GetAllBranchDailyOpex(fromDate, toDate, TempBranchId);
                    }
                }
                else
                {
                    TempBranchId = Convert.ToInt32(recordLevelFilteringBAL.FilterBranchID(BranchId.ToString(), resourceId, criteriaId));
                    if (BranchId != TempBranchId)
                    {
                        MessageBox.Show("You are restricted");
                        return;
                    }
                    else
                    {
                        dataTable = objOpexBal.GetYearlyDailyOpexReport(fromDate, toDate, TempBranchId);
                    }
                }
                objcrYearlyOpex.SetDataSource(dataTable);

                GetCommonInfo();
                ((TextObject)objcrYearlyOpex.ReportDefinition.Sections[2].ReportObjects["txtCompanyName"]).Text = _CommpanyName;
                ((TextObject)objcrYearlyOpex.ReportDefinition.Sections[2].ReportObjects["txtAddress"]).Text = "Branch Name:" + _branchName + "," + _branchAddress + ". Phone:" + _branchContactNumber;

                ((TextObject)objcrYearlyOpex.ReportDefinition.Sections[2].ReportObjects["txtReport"]).Text = "Daily Opex Report: Year wise";
                ((TextObject)objcrYearlyOpex.ReportDefinition.Sections[2].ReportObjects["txtFrom"]).Text = fromDate.ToString("yyyy");
                ((TextObject)objcrYearlyOpex.ReportDefinition.Sections[2].ReportObjects["txtTo"]).Text = toDate.ToString("yyyy");
                ((TextObject)objcrYearlyOpex.ReportDefinition.Sections[2].ReportObjects["txtBranchName"]).Text = ddlBranchList.Text;
                
                objReportviewer.crvReportViewer.ReportSource = objcrYearlyOpex;
                objReportviewer.Text = "Daily Opex Report: Year wise";
                objReportviewer.Show();

            }
            catch (Exception)
            {

                throw;
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

        private void GetCustomizedOpexReport(DateTime fromDate, DateTime toDate)
        {
            try
            {
                cr_CustomizedOpex objcrcustomizedOpex = new cr_CustomizedOpex();
                DataTable dataTable = new DataTable();
                frmReportViewer objReportviewer = new frmReportViewer();
                RecordLevelFilteringBAL recordLevelFilteringBAL = new RecordLevelFilteringBAL();
                OpexBAL objOpexBal = new OpexBAL();
                int TempBranchId = -2;
                int BranchId = Int32.Parse(ddlBranchList.SelectedValue.ToString());
                int resourceId = recordLevelFilteringBAL.GetResourceID(ResourceName.Daily_Expenditure_Customized_Opex);
                int criteriaId = recordLevelFilteringBAL.GetCriteriaID(resourceId);

                if (BranchId == 0)
                {
                    TempBranchId = Convert.ToInt32(recordLevelFilteringBAL.FilterWorkStation_All(BranchId.ToString(), resourceId, criteriaId));
                    if (BranchId != TempBranchId)
                    {
                        MessageBox.Show("You are restricted");
                        return;
                    }
                    else
                    {
                        dataTable = objOpexBal.GetAllBranchDailyOpex(fromDate, toDate, TempBranchId);
                    }
                }
                else
                {
                    TempBranchId = Convert.ToInt32(recordLevelFilteringBAL.FilterBranchID(BranchId.ToString(), resourceId, criteriaId));
                    if (BranchId != TempBranchId)
                    {
                        MessageBox.Show("You are restricted");
                        return;
                    }
                    else
                    {
                        dataTable = objOpexBal.GetCustomizedOpexReport(fromDate, toDate, TempBranchId);
                    }
                }
                objcrcustomizedOpex.SetDataSource(dataTable);

                GetCommonInfo();
                ((TextObject)objcrcustomizedOpex.ReportDefinition.Sections[2].ReportObjects["txtCompanyName"]).Text = _CommpanyName;
                ((TextObject)objcrcustomizedOpex.ReportDefinition.Sections[2].ReportObjects["txtAddress"]).Text = "Branch Name:" + _branchName + "," + _branchAddress + ". Phone:" + _branchContactNumber;

                ((TextObject)objcrcustomizedOpex.ReportDefinition.Sections[2].ReportObjects["txtReport"]).Text = "Daily Opex Report: Customized";
                ((TextObject)objcrcustomizedOpex.ReportDefinition.Sections[2].ReportObjects["txtFrom"]).Text = fromDate.ToString("MMMM-yyyy");
                ((TextObject)objcrcustomizedOpex.ReportDefinition.Sections[2].ReportObjects["txtTo"]).Text = toDate.ToString("MMMM-yyyy");
                ((TextObject)objcrcustomizedOpex.ReportDefinition.Sections[2].ReportObjects["txtBranchName"]).Text = ddlBranchList.Text;



                objReportviewer.crvReportViewer.ReportSource = objcrcustomizedOpex;
                objReportviewer.crvReportViewer.DisplayGroupTree = true;
                objReportviewer.Text = "Daily Opex Report: Customized";
                objReportviewer.Show();


            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
