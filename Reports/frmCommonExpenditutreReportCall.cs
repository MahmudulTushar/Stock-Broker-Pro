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
    public partial class frmCommonExpenditutreReportCall : Form
    {
        public frmCommonExpenditutreReportCall()
        {
            InitializeComponent();
        }

        private string _CommpanyName;
        private string _branchName;
        private string _branchAddress;
        private string _branchContactNumber;


        private void frmCommonExpenditutreReportCall_Load(object sender, EventArgs e)
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

        private void GetCommonOpexReport(DateTime fromDate, DateTime toDate)
        {
            try
            {
                cr_CommonExpenditureReport objcrCommonOpex = new cr_CommonExpenditureReport();
                DataTable dataTable = new DataTable();
                frmReportViewer objReportviewer = new frmReportViewer();
                RecordLevelFilteringBAL recordLevelFilteringBAL = new RecordLevelFilteringBAL();
                int TempBranchId = -2;

                OpexBAL objOpexBal = new OpexBAL();

                int BranchId = Int32.Parse(ddlBranchList.SelectedValue.ToString());

                int resourceId = recordLevelFilteringBAL.GetResourceID(ResourceName.Common_Expenditure);
                int criteriaId = recordLevelFilteringBAL.GetCriteriaID(resourceId);

                if (BranchId == 0)
                {
                    TempBranchId = Convert.ToInt32(recordLevelFilteringBAL.FilterWorkStation_All(BranchId.ToString(), resourceId, criteriaId));
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
                    TempBranchId = Convert.ToInt32(recordLevelFilteringBAL.FilterBranchID(BranchId.ToString(), resourceId, criteriaId));

                    dataTable = objOpexBal.GetCommonOpexReport(fromDate, toDate, TempBranchId);
                }
                objcrCommonOpex.SetDataSource(dataTable);

                GetCommonInfo();
                ((TextObject)objcrCommonOpex.ReportDefinition.Sections[2].ReportObjects["txtCompanyName"]).Text = _CommpanyName;
                ((TextObject)objcrCommonOpex.ReportDefinition.Sections[2].ReportObjects["txtAddress"]).Text = "Branch Name:" + _branchName + "," + _branchAddress + ". Phone:" + _branchContactNumber;

                ((TextObject)objcrCommonOpex.ReportDefinition.Sections[2].ReportObjects["txtReport"]).Text = "Common Expenditure";
                ((TextObject)objcrCommonOpex.ReportDefinition.Sections[2].ReportObjects["txtFrom"]).Text =  fromDate.ToString("yyyy");
                ((TextObject)objcrCommonOpex.ReportDefinition.Sections[2].ReportObjects["txtTo"]).Text = toDate.ToString("yyyy");
                ((TextObject)objcrCommonOpex.ReportDefinition.Sections[2].ReportObjects["txtBranchName"]).Text = ddlBranchList.Text;



                objReportviewer.crvReportViewer.ReportSource = objcrCommonOpex;
                objReportviewer.crvReportViewer.ShowGroupTreeButton = false;
                objReportviewer.Text = "Common Expenditure";
                objReportviewer.Show();


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            GetCommonOpexReport(dtpFromDate.Value, dtpToDate.Value);
            this.Cursor = Cursors.Arrow;

        }
    }
}
