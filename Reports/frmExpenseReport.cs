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
using BusinessAccessLayer.Constants.Indication_Reports;
using CrystalDecisions.Shared;


namespace Reports
{
    public partial class frmExpenseReport : Form
    {
        public frmExpenseReport()
        {
            InitializeComponent();
        }

        private int Selected_Branch_ID;
        private int Selected_CategoryType_ID;
        private int Selected_FrequencyID;

        private string Selected_Branch_Name;
        private string Selected_FrequencyName;
        private string Selected_CategoryType_Name;

        private DateTime Selected_FromDate;
        private DateTime Selected_ToDate;

        private string _CommpanyName;
        private string _branchName;
        private string _branchAddress;
        private string _branchContactNumber;

        private int _reportCatagory;
        private enum FormMode { DefaultMode, DailyReportMode, MonthlyReportMode, YearlyReportMode };

        public int ReportCatagory
        {
            get { return _reportCatagory; }
            set { _reportCatagory = value; }
        }

        private void frmCommonDateReport_Load(object sender, EventArgs e)
        {
            GetBranchLIst();
            GetExpenseCategoryTypeList();
            GetExpenseFrequencyList();
            
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
                cmb_Branch.DataSource = data;
                cmb_Branch.DisplayMember = "Branch_Name";
                cmb_Branch.ValueMember = "Branch_ID";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void GetExpenseCategoryTypeList()
        {
            try
            {
                ExpenseEntryBAL exBal = new ExpenseEntryBAL();
                DataTable data = new DataTable();

                data = exBal.GetCategoryType();

                DataRow dr = data.NewRow();
                dr["Category_Type_ID"] = 0;
                dr["Category_Type"] = "All";

                data.Rows.InsertAt(dr, 0);
                cmb_CatgType.DataSource = data;
                cmb_CatgType.DisplayMember = "Category_Type";
                cmb_CatgType.ValueMember = "Category_Type_ID";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void GetExpenseFrequencyList()
        {
            try
            {
                ExpenseEntryBAL exBal = new ExpenseEntryBAL();
                DataTable data = new DataTable();

                data = exBal.GetExpenseFrequency();

                DataRow dr = data.NewRow();
                dr["Frequency_ID"] = 0;
                dr["Frequency_Name"] = "All";

                data.Rows.InsertAt(dr, 0);
                cmb_ExpsFrequency.DataSource = data;
                cmb_ExpsFrequency.DisplayMember = "Frequency_Name";
                cmb_ExpsFrequency.ValueMember = "Frequency_ID";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ExecuteFormMode(FormMode md)
        {
            switch (md)
            {
                case FormMode.DefaultMode:

                    dt_FromDate.CustomFormat = "dd-MMM-yyyy";
                    dt_ToDate.CustomFormat = "dd-MMM-yyyy";
                    rdBtn_Daily.Enabled = true;
                    rdBtn_Monthly.Enabled = true;
                    rdBtn_Yearly.Enabled = true;
                    
                    rdBtn_Daily.Checked = true;
                    rdBtn_Monthly.Checked = false;
                    rdBtn_Yearly.Checked = false;
                    rd_ExpenseDate.Checked = true;
                    break;
                case FormMode.DailyReportMode:
                    dt_FromDate.CustomFormat = "dd-MMM-yyyy";
                    dt_ToDate.CustomFormat = "dd-MMM-yyyy";
                    rdBtn_Daily.Enabled = true;
                    rdBtn_Monthly.Enabled = true;
                    rdBtn_Yearly.Enabled = true;

                    rdBtn_Daily.Checked = true;
                    rdBtn_Monthly.Checked = false;
                    rdBtn_Yearly.Checked = false;
                    rd_ExpenseDate.Checked = true;
                    break;
                case FormMode.MonthlyReportMode:
                    dt_FromDate.CustomFormat = "MMM-yyyy";
                    dt_ToDate.CustomFormat = "MMM-yyyy";
                    rdBtn_Daily.Enabled = false;
                    rdBtn_Monthly.Enabled = true;
                    rdBtn_Yearly.Enabled = true;

                    rdBtn_Daily.Checked = false;
                    rdBtn_Monthly.Checked = true;
                    rdBtn_Yearly.Checked = false;
                    rd_ExpenseDate.Checked = true;
                    break;
                case FormMode.YearlyReportMode:
                    dt_FromDate.CustomFormat = "yyyy";
                    dt_ToDate.CustomFormat = "yyyy";
                    rdBtn_Daily.Enabled = false;
                    rdBtn_Monthly.Enabled = false;
                    rdBtn_Yearly.Enabled = true;

                    rdBtn_Daily.Checked = false;
                    rdBtn_Monthly.Checked = false;
                    rdBtn_Yearly.Checked = true;
                    rd_ExpenseDate.Checked = true;
                    break;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                ShowReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

        private void ShowReport()
        {
            ExpenseEntryBAL exBal = new ExpenseEntryBAL();

            Selected_Branch_ID = Convert.ToInt32(cmb_Branch.SelectedValue);
            Selected_CategoryType_ID = Convert.ToInt32(cmb_CatgType.SelectedValue);
            Selected_FrequencyID = Convert.ToInt32(cmb_ExpsFrequency.SelectedValue);

            Selected_FrequencyName = (string)cmb_ExpsFrequency.Text;
            Selected_CategoryType_Name = (string)cmb_CatgType.Text;
            Selected_Branch_Name = (string)cmb_Branch.Text;

            Selected_FromDate = (DateTime)dt_FromDate.Value;
            Selected_ToDate = (DateTime)dt_ToDate.Value;

            string grouping=string.Empty;

            if(rdBtn_Daily.Checked)
                grouping=Indication_ExpenseReports.Expense_Grouping_Daily;
            else if(rdBtn_Monthly.Checked)
                grouping=Indication_ExpenseReports.Expense_Grouping_Monthly;
            else if(rdBtn_Yearly.Checked)
                grouping=Indication_ExpenseReports.Expense_Grouping_Yearly;

            GetReport(Selected_Branch_ID, Selected_CategoryType_ID, Selected_FrequencyID, Selected_FromDate, Selected_ToDate, grouping);
            //}
            //else if (Selected_FrequencyName == Indication_ExpenseReports.Expense_Frequency_Monthly || Selected_FrequencyName == Indication_ExpenseReports.Expense_Frequency_HalfYearly && Selected_CategoryType_Name != "All")
            //{
            //    Selected_FromDate = new DateTime(dt_FromDate.Value.Year, dt_FromDate.Value.Month, 1);
            //    Selected_ToDate = new DateTime(dt_ToDate.Value.Year, dt_ToDate.Value.Month, DateTime.DaysInMonth(dt_ToDate.Value.Year, dt_ToDate.Value.Month));

            //    GetReport(Selected_Branch_ID, Selected_CategoryType_ID, Selected_FrequencyID, Selected_FromDate, Selected_ToDate, grouping);
            //}
            //else if (Selected_FrequencyName == Indication_ExpenseReports.Expense_Frequency_Yearly && Selected_CategoryType_Name != "All")
            //{
            //    Selected_FromDate = new DateTime(((DateTime)(dt_FromDate.Value)).Year, 1, 1);
            //    Selected_ToDate = new DateTime(dt_ToDate.Value.Year, 12, 31);

            //    GetReport(Selected_Branch_ID, Selected_CategoryType_ID, Selected_FrequencyID, Selected_FromDate, Selected_ToDate, grouping);
            //}
            //else
            //{
            //    throw new Exception("Category All Or Frequency All Are Invalid Entry");
            //}

        }

        private void cmb_ExpsFrequency_SelectedIndexChanged(object sender, EventArgs e)
        {
            var data = (string)((System.Data.DataRowView)cmb_ExpsFrequency.SelectedItem).Row.ItemArray[1];

            if (data == "All")
            {
                ExecuteFormMode(FormMode.DefaultMode);
            }
            else if (data == Indication_ExpenseReports.Expense_Frequency_Daily)
            {
                ExecuteFormMode(FormMode.DailyReportMode);
            }
            else if (data == Indication_ExpenseReports.Expense_Frequency_Monthly || data == Indication_ExpenseReports.Expense_Frequency_HalfYearly)
            {
                ExecuteFormMode(FormMode.MonthlyReportMode);
            }
            else if (data == Indication_ExpenseReports.Expense_Frequency_Yearly)
            {
                ExecuteFormMode(FormMode.YearlyReportMode);
            }
        }

        //private void GetReport(int BranchID, int CatgId, int FreqId, DateTime fromDate, DateTime toDate, string Grouping)
        //{
        //    try
        //    {
        //        if (Grouping == Indication_ExpenseReports.Expense_Grouping_Monthly)
        //        {
        //            cr_MonthlyOpex objcrmonthlyopex = new cr_MonthlyOpex();
        //            DataTable datatable = new DataTable();
        //            frmReportViewer objreportviewer = new frmReportViewer();
        //            RecordLevelFilteringBAL recordlevelfilteringbal = new RecordLevelFilteringBAL();
        //            ExpenseEntryBAL exbal = new ExpenseEntryBAL();
        //            int tempbranchid = -2;

        //            int resourceid = recordlevelfilteringbal.GetResourceID(ResourceName.Daily_Expenditure_Monthly_Opex);
        //            int criteriaid = recordlevelfilteringbal.GetCriteriaID(resourceid);

        //            if (BranchID == Indication_BrokerBranch.HeadOffice_ID)
        //            {
        //                tempbranchid = Convert.ToInt32(recordlevelfilteringbal.FilterWorkStation_All(BranchID.ToString(), resourceid, criteriaid));

        //                if (BranchID != tempbranchid)
        //                {
        //                    MessageBox.Show("you are restricted");
        //                    return;
        //                }
        //                else
        //                {
        //                    datatable = exbal.GetReport(CatgId, FreqId, BranchID, fromDate, toDate);
        //                }
        //            }
        //            else
        //            {
        //                tempbranchid = Convert.ToInt32(recordlevelfilteringbal.FilterBranchID(BranchID.ToString(), resourceid, criteriaid));
        //                if (BranchID != tempbranchid)
        //                {
        //                    MessageBox.Show("you are restricted");
        //                    return;
        //                }
        //                else
        //                {
        //                    datatable = exbal.GetReport(CatgId, FreqId, BranchID, fromDate, toDate);
        //                }
        //            }
        //            objcrmonthlyopex.SetDataSource(datatable);

        //            GetCommonInfo();
        //            ((TextObject)objcrmonthlyopex.ReportDefinition.Sections[2].ReportObjects["txtcompanyname"]).Text = _CommpanyName;
        //            ((TextObject)objcrmonthlyopex.ReportDefinition.Sections[2].ReportObjects["txtaddress"]).Text = "Branch name:" + _branchName + "," + _branchAddress + ". Phone:" + _branchContactNumber;

        //            ((TextObject)objcrmonthlyopex.ReportDefinition.Sections[2].ReportObjects["txtreport"]).Text = Selected_CategoryType_Name +" Report: Monthly Wise";
        //            ((TextObject)objcrmonthlyopex.ReportDefinition.Sections[2].ReportObjects["txtfrom"]).Text = fromDate.ToString("dd-mmm-yyyy");
        //            ((TextObject)objcrmonthlyopex.ReportDefinition.Sections[2].ReportObjects["txtto"]).Text = toDate.ToString("dd-mmm-yyyy");
        //            ((TextObject)objcrmonthlyopex.ReportDefinition.Sections[2].ReportObjects["txtbranchname"]).Text = _branchName;


        //            objreportviewer.crvReportViewer.ReportSource = objcrmonthlyopex;
        //            objreportviewer.Text = Selected_CategoryType_Name + " Report: Monthly wise";
        //            objreportviewer.Show();
        //        }
        //        else if (Grouping == Indication_ExpenseReports.Expense_Grouping_Daily)
        //        {
        //            cr_DailyOpex objctDailyOpex = new cr_DailyOpex();
        //            DataTable datatable = new DataTable();
        //            frmReportViewer objreportviewer = new frmReportViewer();
        //            RecordLevelFilteringBAL recordlevelfilteringbal = new RecordLevelFilteringBAL();
        //            ExpenseEntryBAL exbal = new ExpenseEntryBAL();
        //            int tempbranchid = -2;

        //            int resourceid = recordlevelfilteringbal.GetResourceID(ResourceName.Daily_Expenditure_Monthly_Opex);
        //            int criteriaid = recordlevelfilteringbal.GetCriteriaID(resourceid);

        //            if (BranchID == Indication_BrokerBranch.HeadOffice_ID)
        //            {
        //                tempbranchid = Convert.ToInt32(recordlevelfilteringbal.FilterWorkStation_All(BranchID.ToString(), resourceid, criteriaid));

        //                if (BranchID != tempbranchid)
        //                {
        //                    MessageBox.Show("you are restricted");
        //                    return;
        //                }
        //                else
        //                {
        //                    datatable = exbal.GetReport(CatgId, FreqId, BranchID, fromDate, toDate);
        //                }
        //            }
        //            else
        //            {
        //                tempbranchid = Convert.ToInt32(recordlevelfilteringbal.FilterBranchID(BranchID.ToString(), resourceid, criteriaid));
        //                if (BranchID != tempbranchid)
        //                {
        //                    MessageBox.Show("you are restricted");
        //                    return;
        //                }
        //                else
        //                {
        //                    datatable = exbal.GetReport(CatgId, FreqId, BranchID, fromDate, toDate);
        //                }
        //            }
        //            objctDailyOpex.SetDataSource(datatable);

        //            GetCommonInfo();
        //            ((TextObject)objctDailyOpex.ReportDefinition.Sections[2].ReportObjects["txtcompanyname"]).Text = _CommpanyName;
        //            ((TextObject)objctDailyOpex.ReportDefinition.Sections[2].ReportObjects["txtaddress"]).Text = "Branch Name:" + _branchName + "," + _branchAddress + ". Phone:" + _branchContactNumber;

        //            ((TextObject)objctDailyOpex.ReportDefinition.Sections[2].ReportObjects["txtreport"]).Text = Selected_CategoryType_Name+" Report: Daily Wise";
        //            ((TextObject)objctDailyOpex.ReportDefinition.Sections[2].ReportObjects["txtfrom"]).Text = fromDate.ToString("dd-mmm-yyyy");
        //            ((TextObject)objctDailyOpex.ReportDefinition.Sections[2].ReportObjects["txtto"]).Text = toDate.ToString("dd-mmm-yyyy");
        //            //((TextObject)objctDailyOpex.ReportDefinition.Sections[2].ReportObjects["txtbranchname"]).Text = _branchName;


        //            objreportviewer.crvReportViewer.ReportSource = objctDailyOpex;
        //            objreportviewer.Text = Selected_CategoryType_Name + " Report: Daily wise";
        //            objreportviewer.Show();
        //        }
        //        else if (Grouping == Indication_ExpenseReports.Expense_Grouping_Yearly)
        //        {

        //            cr_YearlyOPex objctYearlyOpex = new cr_YearlyOPex();
        //            DataTable datatable = new DataTable();
        //            frmReportViewer objreportviewer = new frmReportViewer();
        //            RecordLevelFilteringBAL recordlevelfilteringbal = new RecordLevelFilteringBAL();
        //            ExpenseEntryBAL exbal = new ExpenseEntryBAL();
        //            int tempbranchid = -2;

        //            int resourceid = recordlevelfilteringbal.GetResourceID(ResourceName.Daily_Expenditure_Monthly_Opex);
        //            int criteriaid = recordlevelfilteringbal.GetCriteriaID(resourceid);

        //            if (BranchID == Indication_BrokerBranch.HeadOffice_ID)
        //            {
        //                tempbranchid = Convert.ToInt32(recordlevelfilteringbal.FilterWorkStation_All(BranchID.ToString(), resourceid, criteriaid));

        //                if (BranchID != tempbranchid)
        //                {
        //                    MessageBox.Show("you are restricted");
        //                    return;
        //                }
        //                else
        //                {
        //                    datatable = exbal.GetReport(CatgId, FreqId, BranchID, fromDate, toDate);
        //                }
        //            }
        //            else
        //            {
        //                tempbranchid = Convert.ToInt32(recordlevelfilteringbal.FilterBranchID(BranchID.ToString(), resourceid, criteriaid));
        //                if (BranchID != tempbranchid)
        //                {
        //                    MessageBox.Show("you are restricted");
        //                    return;
        //                }
        //                else
        //                {
        //                    datatable = exbal.GetReport(CatgId, FreqId, BranchID, fromDate, toDate);
        //                }
        //            }
        //            objctYearlyOpex.SetDataSource(datatable);

        //            GetCommonInfo();
        //            ((TextObject)objctYearlyOpex.ReportDefinition.Sections[2].ReportObjects["txtcompanyname"]).Text = _CommpanyName;
        //            ((TextObject)objctYearlyOpex.ReportDefinition.Sections[2].ReportObjects["txtaddress"]).Text = "branch name:" + _branchName + "," + _branchAddress + ". phone:" + _branchContactNumber;

        //            ((TextObject)objctYearlyOpex.ReportDefinition.Sections[2].ReportObjects["txtreport"]).Text = Selected_CategoryType_Name+ " Report: Yearly wise";
        //            ((TextObject)objctYearlyOpex.ReportDefinition.Sections[2].ReportObjects["txtfrom"]).Text = fromDate.ToString("dd-mmm-yyyy");
        //            ((TextObject)objctYearlyOpex.ReportDefinition.Sections[2].ReportObjects["txtto"]).Text = toDate.ToString("dd-mmm-yyyy");
        //            ((TextObject)objctYearlyOpex.ReportDefinition.Sections[2].ReportObjects["txtbranchname"]).Text = _branchName;


        //            objreportviewer.crvReportViewer.ReportSource = objctYearlyOpex;
        //            objreportviewer.Text = Selected_CategoryType_Name + " Report: Yearly wise";
        //            objreportviewer.Show();
        //        }



        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        
        //}

        private void GetReport(int BranchID, int CatgId, int FreqId, DateTime fromDate, DateTime toDate, string Grouping)
        {
            try
            {
                    cr_ExpenseReport objcrmonthlyopex = new cr_ExpenseReport();
                    DataTable datatable = new DataTable();
                    frmReportViewer objreportviewer = new frmReportViewer();
                    RecordLevelFilteringBAL recordlevelfilteringbal = new RecordLevelFilteringBAL();
                    ExpenseEntryBAL exbal = new ExpenseEntryBAL();
                    bool IsExpensedate = false;

                    int tempbranchid = -2;

                    int resourceid = recordlevelfilteringbal.GetResourceID(ResourceName.Daily_Expenditure_Monthly_Opex);
                    int criteriaid = recordlevelfilteringbal.GetCriteriaID(resourceid);

                    if (rd_ExpenseDate.Checked)
                        IsExpensedate = rd_ExpenseDate.Checked;                    

                    if (BranchID == Indication_BrokerBranch.HeadOffice_ID)
                    {
                        tempbranchid = Convert.ToInt32(recordlevelfilteringbal.FilterWorkStation_All(BranchID.ToString(), resourceid, criteriaid));

                        if (BranchID != tempbranchid)
                        {
                            MessageBox.Show("you are restricted");
                            return;
                        }
                        else
                        {
                            datatable = exbal.GetReport(CatgId, FreqId, BranchID, fromDate, toDate, IsExpensedate);
                        }
                    }
                    else
                    {
                        tempbranchid = Convert.ToInt32(recordlevelfilteringbal.FilterBranchID(BranchID.ToString(), resourceid, criteriaid));
                        if (BranchID != tempbranchid)
                        {
                            MessageBox.Show("you are restricted");
                            return;
                        }
                        else
                        {
                            datatable = exbal.GetReport(CatgId, FreqId, BranchID, fromDate, toDate, IsExpensedate);
                        }
                    }
                    ParameterDiscreteValue pdv=new ParameterDiscreteValue();
                    pdv.Value=(object)Grouping;
                    
                    objcrmonthlyopex.SetDataSource(datatable);
                    GetCommonInfo();

                    ((TextObject)objcrmonthlyopex.ReportDefinition.Sections[2].ReportObjects["txtcompanyname"]).Text = _CommpanyName;
                    ((TextObject)objcrmonthlyopex.ReportDefinition.Sections[2].ReportObjects["txtaddress"]).Text = "Branch Name:" + _branchName + "," + _branchAddress + ". Phone:" + _branchContactNumber; ;

                    ((TextObject)objcrmonthlyopex.ReportDefinition.Sections[2].ReportObjects["txtfrom"]).Text = fromDate.ToString("dd-MMM-yyyy") + " To " + toDate.ToString("dd-MMM-yyyy");
                    //((TextObject)objcrmonthlyopex.ReportDefinition.Sections[2].ReportObjects["txtto"]).Text = toDate.ToString("dd-mmm-yyyy");
                    ((TextObject)objcrmonthlyopex.ReportDefinition.Sections[2].ReportObjects["txtDate"]).Text = IsExpensedate ? "Expense Date" : "Payment Date";
                    objcrmonthlyopex.ParameterFields["GroupingDate"].CurrentValues.Add(pdv);
                    objreportviewer.crvReportViewer.ReportSource = objcrmonthlyopex;
                    objreportviewer.Text = "Expense Report ";
                    objreportviewer.Show();

            }
            catch (Exception)
            {

                throw;
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ExpenseOrPayment"></param>
        /// <param name="sorting">NEW added Sorting</param>
        private void MonthlyexpenseReport(string ExpenseOrPayment,string sorting)
        {
            ExpenseEntryBAL bal = new ExpenseEntryBAL();
            DataTable dt = new DataTable();
            dt = bal.GetMonthlyExpenseReport((DateTime)dt_FromDate.Value, (DateTime)dt_ToDate.Value, ExpenseOrPayment);
            crExpenseMonthly cr = new crExpenseMonthly();
            frmReportViewer objreportviewer = new frmReportViewer();
            cr.SetDataSource(dt);
            GetCommonInfo();

            ((TextObject)cr.ReportDefinition.Sections[2].ReportObjects["txtcompanyname"]).Text = _CommpanyName;
            ((TextObject)cr.ReportDefinition.Sections[2].ReportObjects["txtaddress"]).Text = "Branch Name:" + _branchName + "," + _branchAddress + ". Phone:" + _branchContactNumber; ;

            ((TextObject)cr.ReportDefinition.Sections[2].ReportObjects["txtfromDate"]).Text = dt_FromDate.Value.Date.ToShortDateString();
            ((TextObject)cr.ReportDefinition.Sections[2].ReportObjects["txtto"]).Text = dt_ToDate.Value.Date.ToShortDateString();
            ((TextObject)cr.ReportDefinition.Sections[2].ReportObjects["Sorting"]).Text = sorting;
            objreportviewer.crvReportViewer.ReportSource = cr;
            objreportviewer.Show();
        }

        private void btnMonthly_Click(object sender, EventArgs e)
        {
            if (rd_PaymentDate.Checked)
                MonthlyexpenseReport("Payment","Accroding to Payment Date");
            else if (rd_ExpenseDate.Checked)
                MonthlyexpenseReport("Expense","According to Expense Date");
        }

      
    }
}
