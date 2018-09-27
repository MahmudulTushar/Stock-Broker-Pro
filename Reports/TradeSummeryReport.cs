using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using BusinessAccessLayer.BO;
using BusinessAccessLayer.Constants;
using CrystalDecisions.CrystalReports.Engine;

namespace Reports
{
    public partial class TradeSummeryReport : Form
    {
        public static DateTime _FromDate;
        public static DateTime _toDate;
        public static string _workStation;
        public static bool _marketType;
        public static int _branchId;

        private string _CommpanyName;
        private string _branchName;
        private string _branchAddress;
        private string _branchContactNumber;

        bool isAllHide = false;
        bool isAllLimit = false;
        bool isExistHide = false;
        bool isExistLimit = false;
        int resourceId;
        int criteriaId;

        public TradeSummeryReport()
        {
            InitializeComponent();
        }

        private void TradeSummeryReport_Load(object sender, EventArgs e)
        {
            LoadWorkStationDDL();
        }

        private void LoadWorkStationDDL()
        {
            DataTable dataTable = new DataTable();
            TradeSummeryBAL tradeSummeryBal = new TradeSummeryBAL();
            dataTable = tradeSummeryBal.GetWorkStationInfo();
            ddlWorkStation.DataSource = dataTable;
            ddlWorkStation.DisplayMember = "UserID";
            ddlWorkStation.ValueMember = "UserID";
            if (ddlWorkStation.HasChildren)
                ddlWorkStation.SelectedIndex = 0;
           
        }

        private void btnShareReport_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            ShowTradeSummeryReport();
            this.Cursor = Cursors.Arrow;
        }
        private void SetExistingPrevillizeState()
        {
            RecordLevelFilteringBAL recordLevelFilteringBAL = new RecordLevelFilteringBAL();
           
            resourceId = recordLevelFilteringBAL.GetResourceID(ResourceName.Trade_Summery_Report_default);
            criteriaId = recordLevelFilteringBAL.GetCriteriaID(resourceId);

            isAllLimit = recordLevelFilteringBAL.Check_All_Limit(resourceId, criteriaId);
            isAllHide = recordLevelFilteringBAL.Check_All_Hide(resourceId, criteriaId);
            isExistLimit = recordLevelFilteringBAL.isExistLimit(resourceId, criteriaId);
            isExistHide = recordLevelFilteringBAL.isExistHide(resourceId, criteriaId);
        }
        public void ShowTradeSummeryReport()
        {
            _workStation = "";
            _branchId = GlobalVariableBO._branchId;
            _FromDate = dtpFrom.Value;
            _toDate = dtpTo.Value;
            _marketType = chkMarketType.Checked;
            _workStation = ddlWorkStation.Text;
            if (_workStation == "All")
               _workStation = "0";
            TradeSummeryBAL tradeSummeryBal = new TradeSummeryBAL();
            RecordLevelFilteringBAL recordLevelFilteringBAL = new RecordLevelFilteringBAL();

            GetCommonInfo();
            resourceId = recordLevelFilteringBAL.GetResourceID(ResourceName.Trade_Summery_Report_default);
            criteriaId = recordLevelFilteringBAL.GetCriteriaID(resourceId);

            if (_marketType)
            {
                crSpotTradeSummery crSpotTradeSumm = new crSpotTradeSummery();
                SpotTradeSummeryReportViewer spotTradeSummeryReport = new SpotTradeSummeryReportViewer();
                DataTable dtSpotTradeSummery = new DataTable();



                string TempWorkstation = "";
             //   SetExistingPrevillizeState();
               // FilterAllWorkStation
                if (_workStation == "0")
                {
                    TempWorkstation = recordLevelFilteringBAL.FilterWorkStation_All(_workStation, resourceId, criteriaId);
                    if (TempWorkstation != "")
                    {
                        dtSpotTradeSummery = tradeSummeryBal.GetSpotTradeSummery(_FromDate, _toDate);
                    }
                    //else if (!isAllLimit && !isAllHide && !isExistLimit && !isExistHide)
                    //{

                    //    dtSpotTradeSummery = tradeSummeryBal.GetSpotTradeSummery(_FromDate, _toDate);
                    //}
                    else
                    {
                        dtSpotTradeSummery = tradeSummeryBal.GetSpotTradeSummery(_FromDate, _toDate);
                        dtSpotTradeSummery.Rows.Clear();
                    }
                }
                else
                {
                    dtSpotTradeSummery = tradeSummeryBal.GetSpotTradeSummery(_FromDate, _toDate);
                    TempWorkstation = recordLevelFilteringBAL.FilterWorkStation(_workStation, resourceId, criteriaId);
                    if (TempWorkstation == "")
                        dtSpotTradeSummery.Rows.Clear();
                }
                crSpotTradeSumm.SetDataSource(dtSpotTradeSummery);
                ((TextObject)crSpotTradeSumm.ReportDefinition.Sections[2].ReportObjects["txtCompanyName"]).Text = _CommpanyName;
                ((TextObject)crSpotTradeSumm.ReportDefinition.Sections[2].ReportObjects["txtDuration"]).Text = "From " + _FromDate.ToString("dd-MMM-yyyy") + " To " + _toDate.ToString("dd-MMM-yyyy");
                ((TextObject)crSpotTradeSumm.ReportDefinition.Sections[2].ReportObjects["txtBranchName"]).Text = "Branch Name:" + _branchName + "," + _branchAddress + ". Phone:" + _branchContactNumber;
                spotTradeSummeryReport.crvSpotTradeSummery.ReportSource = crSpotTradeSumm;
                spotTradeSummeryReport.crvSpotTradeSummery.DisplayGroupTree = false;
                spotTradeSummeryReport.Show();
            }
            else
            {
                crTradeSummery crTradeSumm = new crTradeSummery();
                TradeSummeryReportViewer tradeSummeryReport = new TradeSummeryReportViewer();
                DataTable dtTradeSummery = new DataTable();
                DataTable dtCashFlow=new DataTable();
                string TempWorkstation = "";


                //int resourceId = recordLevelFilteringBAL.GetResourceID(ResourceName.Trade_Summery_Report_default);
                //int criteriaId = recordLevelFilteringBAL.GetCriteriaID(resourceId);

                if (_workStation == "0")
                {
                    //isAllLimit = recordLevelFilteringBAL.Check_All_Limit(resourceId, criteriaId);
                    //isAllHide = recordLevelFilteringBAL.Check_All_Hide(resourceId, criteriaId);
                    //isExistLimit = recordLevelFilteringBAL.isExistLimit(resourceId, criteriaId);
                    //isExistHide = recordLevelFilteringBAL.isExistHide(resourceId, criteriaId);
                    TempWorkstation = recordLevelFilteringBAL.FilterWorkStation_All(_workStation, resourceId, criteriaId);
                    if (TempWorkstation != "")
                    {
                        dtTradeSummery = tradeSummeryBal.GetTradeSummery(_workStation, _FromDate, _toDate);
                        dtCashFlow = tradeSummeryBal.GetCashflowReport(_FromDate, _toDate);
                    }
                    else
                    {
                        dtTradeSummery = tradeSummeryBal.GetTradeSummery(_workStation, _FromDate, _toDate);
                        dtCashFlow = tradeSummeryBal.GetCashflowReport(_FromDate, _toDate);
                        dtTradeSummery.Rows.Clear();
                        dtCashFlow.Rows.Clear();
                    }                    
                }

                else
                {
                    dtCashFlow = tradeSummeryBal.GetCashflowReport(_FromDate, _toDate);
                    TempWorkstation = recordLevelFilteringBAL.FilterWorkStation(_workStation, resourceId, criteriaId);
                    if (TempWorkstation == "")
                        dtCashFlow.Rows.Clear();
                    dtTradeSummery = tradeSummeryBal.GetTradeSummery(TempWorkstation, _FromDate, _toDate);

                }
                crTradeSumm.SetDataSource(dtTradeSummery);
                ((TextObject)crTradeSumm.ReportDefinition.Sections[2].ReportObjects["txtDuration"]).Text = "From " + _FromDate.ToString("dd-MMM-yyyy") + " To " + _toDate.ToString("dd-MMM-yyyy");
                ((TextObject)crTradeSumm.ReportDefinition.Sections[2].ReportObjects["txtCompanyName"]).Text = _CommpanyName;
                ((TextObject)crTradeSumm.ReportDefinition.Sections[2].ReportObjects["txtBranchName"]).Text = "Branch Name:" + _branchName + "," + _branchAddress + ". Phone:" + _branchContactNumber;
               
                crTradeSumm.Subreports[0].SetDataSource(dtCashFlow);
                tradeSummeryReport.crvTradeSummery.ReportSource = crTradeSumm;
                tradeSummeryReport.Show();
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

       
    }
}
