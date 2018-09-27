using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using Reports;
using CrystalDecisions.CrystalReports.Engine;

namespace StockbrokerProNewArch
{
    public partial class FrmIPOTotalApplicationList : Form
    {
        public FrmIPOTotalApplicationList()
        {
            InitializeComponent();
        }
        IPOProcessBAL bal = new IPOProcessBAL();
        private void LoadComboData()
        {
            DataTable dt = new DataTable();
            dt = bal.GetCompanyShortCodeAndSessionID();
            cmbsessionIdByName.DataSource = dt;
            cmbsessionIdByName.DisplayMember = dt.Columns["code"].ToString();
            cmbsessionIdByName.ValueMember = dt.Columns["ID"].ToString();

        }

        private void FrmIPOTotalApplicationList_Load(object sender, EventArgs e)
        {
            LoadComboData();
            if (cmbsessionIdByName.Items.Count > 0)
                cmbsessionIdByName.SelectedIndex = 0;
        }

        private void btnshowreport_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string sessionid = "";
            crTotalApplicationList crlist = new crTotalApplicationList();
            frmIPOReportViewer viewer = new frmIPOReportViewer();
            if (cmbsessionIdByName.Items.Count>0)
            {
                 sessionid = cmbsessionIdByName.SelectedValue.ToString();
            }
            
            dt = bal.GetTotalApplicationList(sessionid);
            crlist.SetDataSource(dt);

            //GetCommonInfo();
            //((TextObject)crlist.ReportDefinition.Sections[2].ReportObjects["txtreportName"]).Text =
            //                   "Total Application List";
            //((TextObject)crlist.ReportDefinition.Sections[2].ReportObjects["txtCompanyName"]).Text =
            //    _CommpanyName;
            /////// Load Branch Name
            //((TextObject)crlist.ReportDefinition.Sections[2].ReportObjects["txtBranchName"]).Text =
            //    "Branch Name:" + _branchName + "," + _branchAddress + ". Phone:" + _branchContactNumber;
            viewer.crystalReportViewer1.ReportSource = crlist;
            viewer.Show();

        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string _CommpanyName;
        private string _branchName;
        private string _branchAddress;
        private string _branchContactNumber;
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
