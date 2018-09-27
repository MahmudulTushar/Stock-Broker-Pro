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
using CrystalDecisions.CrystalReports.Engine;
using Reports;
using BusinessAccessLayer.Constants;

namespace Reports
{
    public partial class ShareListViewer : Form
    {
        public DateTime dtTo;
        public DateTime dtFrom;
        public string workStation;
        public ShareListViewer()
        {
            InitializeComponent();
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            LoadReport();
            this.Cursor = Cursors.Arrow;
        }

        private void LoadReport()
        {
            ShareListBAL shareBal = new ShareListBAL();
            DataTable dtParticipatoryInfo = new DataTable();

            dtParticipatoryInfo = shareBal.GetParticipatoryInfo();

            ShareListBO shareListBo = new ShareListBO();
            shareListBo.DtTo = dtTo;
            shareListBo.DtFrom = dtFrom;
            shareListBo.WorkStation = workStation;
            DataTable dataTable = new DataTable();



            RecordLevelFilteringBAL recordLevelFilteringBAL = new RecordLevelFilteringBAL();
            string TempWorkstation = "";

            int resourceId = recordLevelFilteringBAL.GetResourceID(ResourceName.Workstation_wise_Trade_Share_List);
            int criteriaId = recordLevelFilteringBAL.GetCriteriaID(resourceId);

            if (workStation == "All")
            {
                TempWorkstation = recordLevelFilteringBAL.FilterWorkStation_All(workStation, resourceId, criteriaId);
                if (TempWorkstation == "All")
                {
                    dataTable = shareBal.GetShareInfo(shareListBo);
                }

                else
                {
                    dataTable = shareBal.GetShareInfo(shareListBo);
                    dataTable.Rows.Clear();
                }
            }
            else
            {
                dataTable = shareBal.GetShareInfo(shareListBo);

                TempWorkstation = recordLevelFilteringBAL.FilterWorkStation(workStation, resourceId, criteriaId);
                if (TempWorkstation == "")
                    dataTable.Rows.Clear();
            }

            crShareReport crShareListReport = new crShareReport();

            ((TextObject)crShareListReport.ReportDefinition.ReportObjects["txtCompanyName"]).Text = dtParticipatoryInfo.Rows[0]["Name"].ToString();
            ((TextObject)crShareListReport.ReportDefinition.ReportObjects["txtBranchName"]).Text = dtParticipatoryInfo.Rows[0]["Branch_Name"].ToString() + " Branch" + dtParticipatoryInfo.Rows[0]["Address"].ToString();
            if (shareListBo.DtFrom != null && shareListBo.DtTo != null)
            {
                ((TextObject)crShareListReport.ReportDefinition.Sections[2].ReportObjects["txtReportDuration"]).Text = "From " + shareListBo.DtFrom.ToShortDateString() + " To " + shareListBo.DtTo.ToShortDateString();

            }

            crShareListReport.SetDataSource(dataTable);
            CrvShareList.ReportSource = crShareListReport;

        }
    }
}
