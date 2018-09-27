using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using ZedGraph;

namespace StockbrokerProNewArch
{
    public partial class CustomerInside : Form
    {
        private string _custCode = "";
        private string _boID = "";
        public CustomerInside()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            ResetAll();
            SearchCustomerInformation();
        }

        private void ResetAll()
        {
            zg1.GraphPane.CurveList.Clear();
            zg1.GraphPane.GraphObjList.Clear();
            zg1.Refresh();
        }

        private void SearchCustomerInformation()
        {
            if (txtSearchCustomer.Text.Trim() != "")
            {
                if (ddlSearchCustomer.SelectedItem.Equals("BO Id"))
                {
                    LoadInfoByBO();
                }
                else
                {
                    LoadInfoByCustCode();
                }
               
            }
        }

        private void LoadInfoByCustCode()
        {
            _custCode = txtSearchCustomer.Text;
            CustomerInsideBAL customerInsideBal=new CustomerInsideBAL();
            if (customerInsideBal.CustCodeDoesExist(_custCode))
            {
                LoadBasicInfo();
                LoadBalanceInfo();
                LoadMarginCBInfo();
                CreateChart(zg1);
            }
            else
            {
                MessageBox.Show("Customer code does not exist.", "Invalid Customer code.");
                return;
            }
        }
        public void CreateChart(ZedGraphControl zgc)
        {
            GraphPane myPane = zgc.GraphPane;
            myPane.CurveList.Clear();
            zgc.GraphPane.GraphObjList.Clear();

            myPane.Title.Text = "Trading Frequrncy";
            myPane.XAxis.Title.Text = "Date";
            myPane.YAxis.Title.Text = "Amount";

            CustomerInsideBAL customerInsideBal = new CustomerInsideBAL();
            DataTable dataTable = customerInsideBal.GetCustGraphValues(txtClientCode.Text);
            PointPairList list = new PointPairList();

            foreach (DataRow dataRow in dataTable.Rows)
            {
                list.Add((double)new XDate(Convert.ToDateTime(dataRow[0])), Convert.ToDouble(dataRow[1]));
            }

            StickItem stickItem = myPane.AddStick("Customer", list, Color.Black);
            stickItem.Color = Color.Red;
            stickItem.Line.Width = 2;

            myPane.XAxis.Type = AxisType.Date;
            myPane.Chart.Fill = new Fill(Color.White, Color.FromArgb(255, 255, 166), 45.0F);
            zgc.AxisChange();
            zg1.Refresh();
        }
        private void CreateGraph(ZedGraphControl zgc)
        {
            GraphPane myPane = zgc.GraphPane;

            // Set the titles and axis labels
            //myPane.Title.Text = "My Test Graph";
            //myPane.XAxis.Title.Text = "X Value";
            //myPane.YAxis.Title.Text = "My Y Axis";

            // Make up some data points from the Sine function
            PointPairList list = new PointPairList();
            for (double x = 0; x < 6; x++)
            {
                list.Add(x, x);
            }

            // Generate a blue curve with circle symbols, and "My Curve 2" in the legend
            LineItem myCurve = myPane.AddCurve("", list, Color.Blue, SymbolType.None);
            // Fill the area under the curve with a white-red gradient at 45 degrees
            //myCurve.Line.Fill = new Fill(Color.White, Color.Red, 45F);
            // Make the symbols opaque by filling them with white
            //myCurve.Symbol.Fill = new Fill( Color.White );

            // Fill the axis background with a color gradient
            //myPane.Chart.Fill = new Fill( Color.White, Color.LightGoldenrodYellow, 45F );

            // Fill the pane background with a color gradient
            //myPane.Fill = new Fill( Color.White, Color.FromArgb( 220, 220, 255 ), 45F );

            // Calculate the Axis Scale Ranges
            zgc.AxisChange();
            zg1.Refresh();
        }

        private void LoadMarginCBInfo()
        {
            CustomerInsideBAL customerInsideBal = new CustomerInsideBAL();
            DataTable dtmarginInfo = new DataTable();
            dtmarginInfo = customerInsideBal.GetCustMarginInfo(_custCode);
            if (dtmarginInfo.Rows.Count > 0)
            {
                txtPlanName.Text = dtmarginInfo.Rows[0]["Plan_Name"].ToString();
                txtChargeRate.Text = dtmarginInfo.Rows[0]["Charge_Rate"].ToString();
                txtFreeAmount.Text = dtmarginInfo.Rows[0]["Free_Amount"].ToString();
                txtMarginRatio.Text = dtmarginInfo.Rows[0]["M_Ratio"].ToString();
            }
            DataTable dtCashBack=new DataTable();
            dtCashBack = customerInsideBal.GetCashbackInfo(_custCode);
            if (dtCashBack.Rows.Count > 0)
            {
                txtCBPlanName.Text = dtCashBack.Rows[0]["Plan_Name"].ToString();
                txtCBRate.Text = dtCashBack.Rows[0]["CB_Rate"].ToString();
                txtMinTrade.Text = dtCashBack.Rows[0]["Min_Trade_Amount"].ToString();
                txtLastCBDate.Text = dtCashBack.Rows[0]["CB_Last_Paid"].ToString();
            }
        }

        private void LoadBalanceInfo()
        {
            CustomerInsideBAL customerInsideBal = new CustomerInsideBAL();
            DataTable dtmoneybalanceInfo = new DataTable();
            dtmoneybalanceInfo = customerInsideBal.GetCustMoneyBalanceInfo(_custCode);
            if (dtmoneybalanceInfo.Rows.Count > 0)
            {
                txtCurrentBalance.Text = dtmoneybalanceInfo.Rows[0]["CurrentBalance"].ToString();
                txtMaturedBalance.Text = dtmoneybalanceInfo.Rows[0]["MaturedBalance"].ToString();
                txtTotalDeposit.Text = dtmoneybalanceInfo.Rows[0]["TotalDeposit"].ToString();
                txtTotalWithdraw.Text = dtmoneybalanceInfo.Rows[0]["TotalWithdraw"].ToString();
                txtMaturedShareBalance.Text = dtmoneybalanceInfo.Rows[0]["MaturedShareBalance"].ToString();
                txtCurrentShareBalance.Text = dtmoneybalanceInfo.Rows[0]["CurrentShareBalance"].ToString();
            }
            
        }

        private void LoadBasicInfo()
        {
            CustomerInsideBAL customerInsideBal=new CustomerInsideBAL();
            DataTable dtbasicInfo=new DataTable();
            dtbasicInfo = customerInsideBal.GetCustBasicInfo(_custCode);
            if(dtbasicInfo.Rows.Count>0)
            {
                txtClientCode.Text = dtbasicInfo.Rows[0]["Cust_Code"].ToString();
                txtClientName.Text = dtbasicInfo.Rows[0]["Cust_Name"].ToString();
                txtAddress.Text = dtbasicInfo.Rows[0]["Address"].ToString();
                txtBranch.Text= dtbasicInfo.Rows[0]["Branch"].ToString();
                txtBOId.Text = dtbasicInfo.Rows[0]["BO_Id"].ToString();
                txtMobile.Text = dtbasicInfo.Rows[0]["Mobile"].ToString();
                txtTelephone.Text = dtbasicInfo.Rows[0]["Phone"].ToString();
            }
        }

        private void LoadInfoByBO()
        {
            CustomerInsideBAL customerInsideBal = new CustomerInsideBAL();
            _boID = txtSearchCustomer.Text;
            _custCode = customerInsideBal.GetCustCodeFromBO(_boID);
            if(_custCode.Trim()=="")
            {
                MessageBox.Show("BO ID Not Exists", "Invalid BO");
                return;
            }
            else
            {
                LoadBasicInfo();
                LoadBalanceInfo();
                LoadMarginCBInfo();
            }
           
        }
        private void CustomerInside_Load(object sender, EventArgs e)
        {
            ddlSearchCustomer.SelectedIndex = 0;
            txtSearchCustomer.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
