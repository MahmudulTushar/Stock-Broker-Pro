using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using BusinessAccessLayer.BO;
using CrystalDecisions.CrystalReports.Engine;
using Reports;

namespace StockbrokerProNewArch
{
    public partial class CDBLShareReconcile : Form
    {
        public static bool _CustWise;
        public static bool _CompanyWise;
        public static bool _SettlementWise;
        public static bool _MissMatch;
        public static int _branchId;

        private string _CommpanyName;
        private string _branchName;
        private string _branchAddress;
        private string _branchContactNumber;
        
        public CDBLShareReconcile()
        {
            InitializeComponent();
        }
        private void btnStartImport_Click(object sender, EventArgs e)
        {
            try
            {
                UploadProcess();
                MessageBox.Show("File Upload done.", "Success");
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error Occured." + exc.Message);
            }
        }

        private void UploadProcess()
        {
            DataTable cdblRencileDataTable;
            cdblRencileDataTable = ProcessTradeFile(txtFileLocation.Text);
            CDBLReconcileBAL cdblReconcileBal = new CDBLReconcileBAL();
            cdblReconcileBal.TruncateCDBLReconcile();
            cdblReconcileBal.SaveCDBLReconcileInfo(cdblRencileDataTable, "SBP_11DPA6UX");
        }

        private DataTable ProcessTradeFile(string filePath)
        {
            string lineText;
            string[] tempValue;
            char proChar = '~';
            StreamReader streamReader = new StreamReader(filePath);
            DataTable dataTable = new DataTable();
            DataRow dataRow;

            lineText = streamReader.ReadLine();
            tempValue = lineText.Split(proChar);

            for (int i = 0; i < tempValue.Length; ++i)
            {
                dataTable.Columns.Add(new DataColumn());
            }

            do
            {
                string[] values = lineText.Split(proChar);
                dataRow = dataTable.NewRow();
                dataRow.ItemArray = values;
                dataTable.Rows.Add(dataRow);
                lineText = streamReader.ReadLine();
            } while (lineText != null);

            return dataTable;
        }

        private void btnFileLocationBrowser_Click(object sender, EventArgs e)
        {
            if (ofdFileOpen.ShowDialog() == DialogResult.OK)
                txtFileLocation.Text = ofdFileOpen.FileName;
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            ShowReport();
        }

        private void ShowReport()
        {
            _branchId = GlobalVariableBO._branchId;
            _CustWise = rdoCustomerwise.Checked;
            _CompanyWise = rdoShareSummery.Checked;
            _SettlementWise = rdoSattlement.Checked;
            _MissMatch=rdo_MissMatch.Checked;
            CDBLReconcileBAL cdblReconcileBal = new CDBLReconcileBAL();
            DataTable dtcdblReconcile = new DataTable();
            LoadCommonInfo CmmInfo = new LoadCommonInfo();
            if (_MissMatch)
            {
                cr_ShareReconcilation_MissMatch crShareReconcile = new cr_ShareReconcilation_MissMatch();
                CustWiseShareReconcileViewer custShareReconcileViewer = new CustWiseShareReconcileViewer();
                dtcdblReconcile = cdblReconcileBal.GetMissMatchReconcilation();
                crShareReconcile.SetDataSource(dtcdblReconcile);
                GetCommonInfo();
                ((TextObject)crShareReconcile.ReportDefinition.Sections[2].ReportObjects["txtCompanyName"]).Text = _CommpanyName;

                ///// Load Branch Name
                ((TextObject)crShareReconcile.ReportDefinition.Sections[2].ReportObjects["txtBranchName"]).Text = "Branch Name:" + _branchName + "," + _branchAddress + ". Phone:" + _branchContactNumber;

                custShareReconcileViewer.crvCustShareReconcile.ReportSource = crShareReconcile;
                custShareReconcileViewer.Show();
            }
            else if (_CustWise)
            {
                cr_ShareReconcilation_CustomerWise crCustShareReconcile = new cr_ShareReconcilation_CustomerWise();
                CustWiseShareReconcileViewer custShareReconcileViewer = new CustWiseShareReconcileViewer();
                dtcdblReconcile = cdblReconcileBal.GetCustWiseShareRecocile();
                crCustShareReconcile.SetDataSource(dtcdblReconcile);

                GetCommonInfo();
                ((TextObject)crCustShareReconcile.ReportDefinition.Sections[2].ReportObjects["txtCompanyName"]).Text = _CommpanyName;

                ///// Load Branch Name
                ((TextObject)crCustShareReconcile.ReportDefinition.Sections[2].ReportObjects["txtBranchName"]).Text = "Branch Name:" + _branchName + "," + _branchAddress + ". Phone:" + _branchContactNumber;

                custShareReconcileViewer.crvCustShareReconcile.ReportSource = crCustShareReconcile;
                custShareReconcileViewer.Show();
            }
            else if (_CompanyWise)
            {
                cr_ShareReconcilation_CompanyWise crCompanyShareReconcile = new cr_ShareReconcilation_CompanyWise();
                CompanyShareReconcileViewer compShareReconcileViewer = new CompanyShareReconcileViewer();
                dtcdblReconcile = cdblReconcileBal.GetCompanyWiseShareRecocile();
                crCompanyShareReconcile.SetDataSource(dtcdblReconcile);
                GetCommonInfo();
                ((TextObject)crCompanyShareReconcile.ReportDefinition.Sections[2].ReportObjects["txtCompanyName"]).Text = _CommpanyName;

                ///// Load Branch Name
                ((TextObject)crCompanyShareReconcile.ReportDefinition.Sections[2].ReportObjects["txtBranchName"]).Text = "Branch Name:" + _branchName + "," + _branchAddress + ". Phone:" + _branchContactNumber;

                compShareReconcileViewer.crvCompShareReconcile.ReportSource = crCompanyShareReconcile;
                compShareReconcileViewer.Show();
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CDBLShareReconcile_Load(object sender, EventArgs e)
        {
            LoadDateInfo();
        }

        private void LoadDateInfo()
        {
            CDBLReconcileBAL cdblReconcileBal=new CDBLReconcileBAL();
            DataTable dtDateInfo=new DataTable();
            dtDateInfo = cdblReconcileBal.GetDateInfo();
            if (dtDateInfo.Rows.Count > 0)
            {
                if (dtDateInfo.Rows[0]["Current_Date"] != DBNull.Value)
                    lblCurrentDate.Text = dtDateInfo.Rows[0]["Current_Date"].ToString();
                if (dtDateInfo.Rows[0]["Last_Trade_Date"] != DBNull.Value)
                    lblTradeDate.Text = dtDateInfo.Rows[0]["Last_Trade_Date"].ToString();
                if (dtDateInfo.Rows[0]["ISIN_Date"] != DBNull.Value)
                    lblISINDate.Text = dtDateInfo.Rows[0]["ISIN_Date"].ToString();
            }
        }

       
    }
}
