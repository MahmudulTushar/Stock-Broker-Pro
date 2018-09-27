using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using BusinessAccessLayer.BO;
using CrystalDecisions.CrystalReports.Engine;
using Reports;
using BusinessAccessLayer.Constants;

namespace Reports
{
    public partial class BuySellReport : Form
    {
        public static DateTime _transDate;
        public static bool _CustWise;
        public static bool _InstruWise;
        public static int _branchId;

        private string _CommpanyName;
        private string _branchName;
        private string _branchAddress;
        private string _branchContactNumber;

        private string _filterdColumnName;

        public BuySellReport()
        {
            InitializeComponent();
        }
        private void btnBuyList_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            ShowBuyReport();
            this.Cursor = Cursors.Arrow;
        }
        public  void ShowBuyReport()
        {
            _branchId = GlobalVariableBO._branchId;
            _transDate = Convert.ToDateTime(dtTransactionDate.Value.ToShortDateString());
            _CustWise = rdoCustwise.Checked;
            _InstruWise = rdoInstruWise.Checked;
            BuyShareListReviewBAL buyShareListReviewBal = new BuyShareListReviewBAL();
            DataTable dtBuyShareListReview = new DataTable();
            LoadCommonInfo CmmInfo = new LoadCommonInfo();

            if(_CustWise)
            {
                crCustWiseBuyShareList crBuyShareListReview = new crCustWiseBuyShareList();
                CustWiseBuyShareListReportViewer buyShareListReportViewer = new CustWiseBuyShareListReportViewer();
                dtBuyShareListReview = buyShareListReviewBal.GetCustWiseBuyShareList(_transDate);

                _filterdColumnName = dtBuyShareListReview.Columns[0].ToString();
                RecordLevelFilteringBAL obj = new RecordLevelFilteringBAL(dtBuyShareListReview, _filterdColumnName, ResourceName.Buy_Sale_Report_Cust_Wise_Buy_Share_List);
                dtBuyShareListReview = obj.GetRecordLevelFilteredData();


                crBuyShareListReview.SetDataSource(dtBuyShareListReview);

                GetCommonInfo();
                ((TextObject) crBuyShareListReview.ReportDefinition.Sections[2].ReportObjects["txtCompanyName"]).Text =_CommpanyName;
                ((TextObject)crBuyShareListReview.ReportDefinition.Sections[2].ReportObjects["txtBranchName"]).Text = "Branch Name:" + _branchName + "," + _branchAddress + ". Phone:" + _branchContactNumber;
               
                if (_transDate != null)
                {
                    ((TextObject)crBuyShareListReview.ReportDefinition.Sections[2].ReportObjects["txtReportDuration"]).Text = "Transaction Date: " + _transDate.ToString("dd MMMM,yyyy");
                }
                buyShareListReportViewer.crvBuyShareList.ReportSource = crBuyShareListReview;
                buyShareListReportViewer.Show();
            }
            else if (_InstruWise)
            {
                crInstruWiseBuyList crInstruWiseBuylist = new crInstruWiseBuyList();
                InstruWiseBuyReportViewer instruWiseBuyReportViewer = new InstruWiseBuyReportViewer();
            
                dtBuyShareListReview = buyShareListReviewBal.GetInstruWiseBuyShareList(_transDate);

                _filterdColumnName = dtBuyShareListReview.Columns[2].ToString();
                RecordLevelFilteringBAL obj = new RecordLevelFilteringBAL(dtBuyShareListReview, _filterdColumnName, ResourceName.Buy_Sale_Report_Cust_Wise_Buy_Share_List);
                dtBuyShareListReview = obj.GetRecordLevelFilteredData();

                crInstruWiseBuylist.SetDataSource(dtBuyShareListReview);

                GetCommonInfo();
                ((TextObject)crInstruWiseBuylist.ReportDefinition.Sections[2].ReportObjects["txtCompanyName"]).Text = _CommpanyName;
                ((TextObject)crInstruWiseBuylist.ReportDefinition.Sections[2].ReportObjects["txtBranchName"]).Text = "Branch Name:" + _branchName + "," + _branchAddress + ". Phone:" + _branchContactNumber;
                if (_transDate != null)
                {
                    ((TextObject)crInstruWiseBuylist.ReportDefinition.Sections[2].ReportObjects["txtReportDuration"]).Text = "Transaction Date: " + _transDate.ToString("dd  MMMM,yyyy");
                }
                instruWiseBuyReportViewer.crvInstruWiseBuyList.ReportSource = crInstruWiseBuylist;
                instruWiseBuyReportViewer.Show();
            }
            else
            {
                MessageBox.Show("Please Select the report category first.");
            }
           
        }
        private void btnSellList_Click(object sender, EventArgs e)
        {
            ShowSellReport();
        }
      

       
        public void ShowSellReport()
        {
            _branchId = GlobalVariableBO._branchId;
            _transDate = Convert.ToDateTime(dtTransactionDate.Value.ToShortDateString());
            _CustWise = rdoCustwise.Checked;
            _InstruWise = rdoInstruWise.Checked;
            SellShareListReviewBAL sellShareListReviewBal = new SellShareListReviewBAL();
            DataTable dtSellShareListReview = new DataTable();
           
            if (_CustWise)
            {
                crCustWiseSellShareList crSellShareListReview = new crCustWiseSellShareList();
                CustWiseSellShareListReportViewer sellShareListReportViewer = new CustWiseSellShareListReportViewer();
                dtSellShareListReview = sellShareListReviewBal.GetCustWiseSellShareList(_transDate);

                _filterdColumnName = dtSellShareListReview.Columns[0].ToString();
                RecordLevelFilteringBAL obj = new RecordLevelFilteringBAL(dtSellShareListReview, _filterdColumnName, ResourceName.Buy_Sale_Report_Cust_Wise_Buy_Share_List);
                dtSellShareListReview = obj.GetRecordLevelFilteredData();

                crSellShareListReview.SetDataSource(dtSellShareListReview);

                GetCommonInfo();
                ((TextObject)crSellShareListReview.ReportDefinition.Sections[2].ReportObjects["txtCompanyName"]).Text =_CommpanyName;
                ((TextObject)crSellShareListReview.ReportDefinition.Sections[2].ReportObjects["txtBranchName"]).Text = "Branch Name:" + _branchName + "," + _branchAddress + ". Phone:" + _branchContactNumber;
                if (_transDate != null)
                {
                    ((TextObject)crSellShareListReview.ReportDefinition.Sections[2].ReportObjects["txtReportDuration"]).Text = "Transaction Date: " + _transDate.ToString("dd-MMM-yy");
                }
                sellShareListReportViewer.crvSellShareList.ReportSource = crSellShareListReview;
                sellShareListReportViewer.Show();
            }
            else if (_InstruWise)
            {
                crInstruWiseSellShareList crInstruWiseSellSharelist = new crInstruWiseSellShareList();
                InstruWiseSellReportViewer insWiseSellReport = new InstruWiseSellReportViewer();
                dtSellShareListReview = sellShareListReviewBal.GetInstruWiseSellShareList(_transDate);

                _filterdColumnName = dtSellShareListReview.Columns[2].ToString();
                RecordLevelFilteringBAL obj = new RecordLevelFilteringBAL(dtSellShareListReview, _filterdColumnName, ResourceName.Buy_Sale_Report_Cust_Wise_Buy_Share_List);
                dtSellShareListReview = obj.GetRecordLevelFilteredData();

                crInstruWiseSellSharelist.SetDataSource(dtSellShareListReview);

                GetCommonInfo();
                ((TextObject)crInstruWiseSellSharelist.ReportDefinition.Sections[2].ReportObjects["txtCompanyName"]).Text = _CommpanyName;
                ((TextObject)crInstruWiseSellSharelist.ReportDefinition.Sections[2].ReportObjects["txtBranchName"]).Text = "Branch Name:" + _branchName + "," + _branchAddress + ". Phone:" + _branchContactNumber;
                if (_transDate != null)
                {
                    ((TextObject)crInstruWiseSellSharelist.ReportDefinition.Sections[2].ReportObjects["txtReportDuration"]).Text = "Transaction Date: " + _transDate.ToString("dd-MMM-yy");
                }
                insWiseSellReport.crvInstruWiseSellReportViewer.ReportSource = crInstruWiseSellSharelist;
                insWiseSellReport.Show();
            }
            else
            {
                MessageBox.Show("Please Select the report category first.");
            }
        }

        private void BuySellReport_Load(object sender, EventArgs e)
        {
            rdoCustwise.Checked = true;
        }

        private void btnBuySellNetAmount_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            ShowBuySellReport();
            this.Cursor = Cursors.Arrow;
        }
        
        public void ShowBuySellReport()
        {
            _transDate = Convert.ToDateTime(dtTransactionDate.Value.ToShortDateString());
            _branchId = GlobalVariableBO._branchId;
            SellShareListReviewBAL sellShareListReviewBal = new SellShareListReviewBAL();
            DataTable dtBuySellNetAmntReview = new DataTable();
           
            crBuySellNetAmnt crBuySellNetamnt = new crBuySellNetAmnt();
            BuySellNetAmntReportViewer buySellNetAmntViewer = new BuySellNetAmntReportViewer();
            dtBuySellNetAmntReview = sellShareListReviewBal.GetBuySellNetAmnt(_transDate);

            crBuySellNetamnt.SetDataSource(dtBuySellNetAmntReview);

            GetCommonInfo();
            ((TextObject) crBuySellNetamnt.ReportDefinition.Sections[2].ReportObjects["txtCompanyName"]).Text =_CommpanyName;
            ((TextObject)crBuySellNetamnt.ReportDefinition.Sections[2].ReportObjects["txtBranchName"]).Text = _branchName + "," + _branchAddress + ". Phone:" + _branchContactNumber;
           

            if (_transDate != null)
            {
                ((TextObject)crBuySellNetamnt.ReportDefinition.Sections[2].ReportObjects["txtReportDuration"]).Text = "Transaction Date: " + _transDate.ToString("dd-MMMM-yyyy");
            }
            buySellNetAmntViewer.crvBuySellNetAmnt.ReportSource = crBuySellNetamnt;
            buySellNetAmntViewer.Show();
            
        }

        private void GetCommonInfo()
        {

            try
            {
                CommonInfoBal objCommonInfoBal = new CommonInfoBal();
                DataRow drCommonInfo = null;

                drCommonInfo = objCommonInfoBal.GetCommpanyDefaultInfo();

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
