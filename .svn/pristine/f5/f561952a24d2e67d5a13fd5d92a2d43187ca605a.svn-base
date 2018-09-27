using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using ZedGraph;

namespace StockbrokerProNewArch
{
    public partial class Graphs : Form
    {
        public Graphs()
        {
            InitializeComponent();
        }

        private string _companyShortCode = "";
        public string CompanyShortCode
        {
            get { return _companyShortCode; }
            set { _companyShortCode = value; }
        }


        private void btnDrawGraph_Click(object sender, EventArgs e)
        {
            CreateChart(zg1);
        }
        public void CreateChart(ZedGraphControl zgc)
        {
            GraphPane myPane = zgc.GraphPane;
            myPane.CurveList.Clear();
            zgc.GraphPane.GraphObjList.Clear();

            myPane.Title.Text = ddlCompanyName.SelectedValue.ToString();
            myPane.XAxis.Title.Text = "Date";

            DashboardBAL dashboardBal = new DashboardBAL();
            DataTable dataTable = dashboardBal.GetCompGraphValues(ddlCompanyName.SelectedValue.ToString(), dtpDateFrom.Value, dtpDateTo.Value);

            PointPairList list = new PointPairList();
            PointPairList list2 = new PointPairList();
            PointPairList list3 = new PointPairList();
            PointPairList list4 = new PointPairList();

            foreach (DataRow dataRow in dataTable.Rows)
            {
                list.Add((double)new XDate(Convert.ToDateTime(dataRow[0])), Convert.ToDouble(dataRow[1]));
                list2.Add((double)new XDate(Convert.ToDateTime(dataRow[0])), Convert.ToDouble(dataRow[2]));
                list3.Add((double)new XDate(Convert.ToDateTime(dataRow[0])), Convert.ToDouble(dataRow[3]));
                list4.Add((double)new XDate(Convert.ToDateTime(dataRow[0])), Convert.ToDouble(dataRow[4]));
            }

            if (chkClosePrice.Checked)
            {
                myPane.YAxis.Title.Text = "Close Price";
                myPane.AddCurve("Close Price", list, Color.Red, SymbolType.None);
            }
            if (chkTotalTrade.Checked)
            {
                myPane.YAxis.Title.Text = "Total Trade";
                myPane.AddCurve("Total Trade", list2, Color.Green, SymbolType.None);
            }
            if (chkTotalVolume.Checked)
            {
                myPane.YAxis.Title.Text = "Volume";
                myPane.AddCurve("Volume", list3, Color.Blue, SymbolType.None);
            }
            if (chkLastValue.Checked)
            {
                myPane.YAxis.Title.Text = "Value";
                myPane.AddCurve("Value", list4, Color.Black, SymbolType.None);
            }

            myPane.XAxis.Type = AxisType.Date;
            myPane.Chart.Fill = new Fill(Color.White, Color.FromArgb(205, 215, 196), 45.0F);
            zgc.AxisChange();
            zg1.Refresh();
        }
        private void LoadCompany()
        {
            LoadDDLBAL loadDDLBAL = new LoadDDLBAL();
            DataTable dtData = loadDDLBAL.LoadDDL("SBP_Company");
            ddlCompanyName.DataSource = dtData;
            ddlCompanyName.DisplayMember = "Comp_Short_Code";
            ddlCompanyName.ValueMember = "Comp_Short_Code";
            if (ddlCompanyName.HasChildren)
                ddlCompanyName.SelectedIndex = 0;
        }

        private void Graphs_Load(object sender, EventArgs e)
        {
            ddlGraphStyle.SelectedIndex = 0;
             dtpDateFrom.Value = dtpDateFrom.Value.AddMonths(-3);
            LoadCompany();

            if(!_companyShortCode.Equals(""))
            {
                ddlCompanyName.Text = _companyShortCode;
            }

            CreateChart(zg1);

        }
    }
}
