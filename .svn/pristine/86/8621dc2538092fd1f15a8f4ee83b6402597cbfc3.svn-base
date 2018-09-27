using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using BusinessAccessLayer.Constants;
using ZedGraph;
using System.IO;
using BusinessAccessLayer.BO;

namespace StockbrokerProNewArch
{
    public partial class AccDashboard : Form
    {
        public string[] quantity;

        public AccDashboard()
        {
            InitializeComponent();
            txtSearchCustomer.Focus();
        }
        private string _filterdColumnName;

        private void AccDashboard_Load(object sender, EventArgs e)
        {
            this.SuspendLayout();
            ddlSearchCustomer.SelectedIndex = 0;
            txtSearchCustomer.Focus();
            //btnIPOAccInfo.Location = new Point(417, 205);
            btnIPOAccInfo.Location = new Point(417, 300);
            //this.Size = new Size(989, 360);
            this.Size = new Size(989, 700);
            Panel3show();
            
        }
        private void btnGo_Click(object sender, EventArgs e)
        {
            ClearAll();
            GetCustomerDetails();

            #region BLOCK CODE
            //int previllige = 0;
            //PrevillizeManagementBAL previllizeManagementBal = new PrevillizeManagementBAL();
            //previllige = previllizeManagementBal.GetDashboardUserPrevillize();
            //DashboardBAL dashboardBal = new DashboardBAL();
            //if (previllige == 1)
            //{
            //    GetCustomerDetails();
            //}
            //else
            //{
            //    int isHidden = 0;
            //    if (ddlSearchCustomer.SelectedIndex == 0)
            //    {
            //        isHidden = dashboardBal.CheckHiddenCustomer(txtSearchCustomer.Text);
            //    }
            //    else
            //    {
            //        isHidden = dashboardBal.CheckHiddenCustomer("dbo.GetCustCodeFromBO(txtSearchCustomer.Text)");
            //    }
            //    if (isHidden == 1)
            //    {
            //        MessageBox.Show("You do not have the access to see this customer", "Warning.");
            //    }
            //    else
            //    {

            //        if (dashboardBal.IsLimitedDashboardPrivliage() == 1)
            //        {
            //            if (ddlSearchCustomer.SelectedIndex == 0)
            //            {
            //                if (dashboardBal.IsLimitedfromDashboard(txtSearchCustomer.Text) == true)
            //                    GetCustomerDetails();

            //                else
            //                {
            //                    MessageBox.Show("No Previllize to See this Information.", "Dashboard", MessageBoxButtons.OK,
            //                                    MessageBoxIcon.Information);
            //                }
            //            }

            //            else if (ddlSearchCustomer.SelectedIndex == 1)
            //            {
            //                if (dashboardBal.IsLimitedDashboardByBOID(txtSearchCustomer.Text) == true)
            //                    GetCustomerDetails();

            //                else
            //                {
            //                    MessageBox.Show("No Previllize to See this Information.", "Dashboard", MessageBoxButtons.OK,
            //                                    MessageBoxIcon.Information);
            //                }
            //            }

            //            else
            //            {
            //                MessageBox.Show("No Client Information found.", "Dashboard", MessageBoxButtons.OK,
            //                                   MessageBoxIcon.Information);
            //            }
            //        }

            //        else
            //        {
            //            GetCustomerDetails();
            //        }

            //    }
            //}
            #endregion
        }

        private void ClearAll()
        {
            dgvShareDetails.DataSource = null;
            dgvShareSummery.DataSource = null;
            txtAccountHolderBOId.Text = "";
            txtAccountHolderName.Text = "";
            txtMoneyBalanceTemp.Text = "";
            txtAvailableWithdrawBalance.Text = "";
            txtTotalAccruedBalance.Text = "";
            txtTotalDepositBalance.Text = "";
            txtCustCode.Text = "";
            txtLastDT.Text = "";
            txtMatMonBal.Text = "";
            txtTotalWithdrawBalance.Text = "";
            txtMarketValue.Text = "";
            lbBuyAvg.Text = "Bug Avg : 00.00";
            lbLastPrice.Text = "Last Price : 00.00";
            lbLastTradeDate.Text = "Last Trade : 00-00-0000";
            lblCompany.Text = "Share Details -";
            lbNetAvg.Text = "Net Avg : 00.00";
            txtStatus_Cust.Text = "";
            txtgainLoss.Text = "";
            txt_status_Bo.Text = "";
            txtStatus_Cust.Text = "";
            txt_RiskValue.Text = "";
            lbltotalbuy.Text = "Total Buy : 00.00";
            txtSpecificGainLoss.Text = "ISN Gain Loss : 00.00";
            lbltotalMarketValue.Text = "Total Market Value : 00.00";


            //IPO
            txtIPODeposit.Text = string.Empty;
            txtIPOWithdraw.Text = string.Empty;
            txtIPOCurMonBal.Text = string.Empty;
            txtIPOMatMonBal.Text = string.Empty;
            txtIPOMarketValue.Text = string.Empty;
        }

        private void GetCustomerDetails()
        {
            DashboardBAL dashboardBal = new DashboardBAL();
            CommonBAL commbal = new CommonBAL();
            PaymentInfoBAL paymentInfoBal = new PaymentInfoBAL();
            RecordLevelFilteringBAL obj = new RecordLevelFilteringBAL(ResourceName.Limit_Dash_board);
            DataTable dataTable;
            if (ddlSearchCustomer.SelectedIndex == 0)
            {
                string T_custCode = obj.FilterCustCode(txtSearchCustomer.Text, ResourceName.Limit_Dash_board);
                if (T_custCode == "")
                {
                    MessageBox.Show("You are restricted from Dash board");
                }
                dataTable = dashboardBal.GetCustomerDetails(T_custCode, 1);
                txtTotalAccruedBalance.Text = paymentInfoBal.GetCurrentBalaneforAccrued(T_custCode).ToString("N");
                txtAvailableWithdrawBalance.Text = commbal.GetCurrentAvailAbleBalanceForWithdraw(T_custCode).ToString("N");  
                //dataTable = dashboardBal.GetCustomerDetails_FromTemp(T_custCode, 1);
            }
            else
            {
                string T_custCode = obj.FilterCustCode(txtSearchCustomer.Text, ResourceName.Limit_Dash_board);
                if (T_custCode == "")
                {
                    MessageBox.Show("You are restricted from Dash board");
                }
                dataTable = dashboardBal.GetCustomerDetails(T_custCode, 0);
                txtTotalAccruedBalance.Text = paymentInfoBal.GetCurrentBalaneforAccrued(T_custCode).ToString("N");
                txtAvailableWithdrawBalance.Text = commbal.GetCurrentAvailAbleBalanceForWithdraw(T_custCode).ToString("N");  
                //dataTable = dashboardBal.GetCustomerDetails_FromTemp(T_custCode, 0);
            }
            if (dataTable.Rows.Count > 0)
            {
                //Change By Md.Rashedu Hasan Add String Index instead of Int Index
                //Also Change TextBoxt name
                txtCustCode.Text = dataTable.Rows[0]["Cust_Code"].ToString();
                txtAccountHolderBOId.Text = dataTable.Rows[0]["BO_ID"].ToString();
                txtAccountHolderName.Text = dataTable.Rows[0]["Cust_Name"].ToString();
                txtLastDT.Text = dataTable.Rows[0]["Last_Trade_Date"].ToString();
                if (dataTable.Rows[0]["Deposit"] != DBNull.Value)
                    txtTotalDepositBalance.Text = Convert.ToDouble(dataTable.Rows[0]["Deposit"]).ToString("N");
                if (dataTable.Rows[0]["Withdraw"] != DBNull.Value)
                    txtTotalWithdrawBalance.Text = Convert.ToDouble(dataTable.Rows[0]["Withdraw"]).ToString("N");
                //if (dataTable.Rows[0]["Balance"] != DBNull.Value)
                //    txtCurMonBal.Text = Convert.ToDouble(dataTable.Rows[0]["Balance"]).ToString("N");
                if (dataTable.Rows[0]["Share_Balance_Temp"] != DBNull.Value)
                    txtMoneyBalanceTemp.Text = Convert.ToDouble(dataTable.Rows[0]["Share_Balance_Temp"]).ToString("N");
                if (dataTable.Rows[0]["MaturedBalance"] != DBNull.Value)
                    txtMatMonBal.Text = Convert.ToDouble(dataTable.Rows[0]["MaturedBalance"]).ToString("N");
                if (dataTable.Rows[0]["MarketValue"] != DBNull.Value)
                    txtMarketValue.Text = Convert.ToDouble(dataTable.Rows[0]["MarketValue"]).ToString("N");
                if (dataTable.Rows[0]["Cust_Status"] != DBNull.Value)
                    txtStatus_Cust.Text = "B-Off : "+dataTable.Rows[0]["Cust_Status"].ToString();
                if (dataTable.Rows[0]["BO_Status"] != DBNull.Value)
                    txt_status_Bo.Text = "CDBL : " + dataTable.Rows[0]["BO_Status"].ToString();

                ChangeControlColor(txtTotalDepositBalance);
                ChangeControlColor(txtTotalWithdrawBalance);
                ChangeControlColor(txtMoneyBalanceTemp);
                ChangeControlColor(txtMatMonBal);
                ChangeControlColor(txt_status_Bo);
                ChangeControlColor(txtStatus_Cust);              
                txtSearchCustomer.SelectAll();
                dashboardBal.InsertDashboardLog(txtCustCode.Text);
                LoadShareSummery();
                SetGainLoss();

                #region IPo Share Details Grid View Row Clear
                if (dgvIPOShareDetails.Rows.Count > 0)
                {
                    while (dgvIPOShareDetails.Rows.Count > 0)
                    {
                        dgvIPOShareDetails.Rows.RemoveAt(0);

                    }
                }
                #endregion
                #region Ipo Method
                if (btnIPOAccInfo.Text == "IPO Info Hide")
                {
                    IPOResetAll();
                    showIpoacc();
                    LoadIPOShareSummery(checkBox1.Checked, chkIpoAllApply.Checked);
                    IPOGainLoss();
                    quantity = new string[] { txtCustCode.Text };
                }
                #endregion
            }
            else
            {
                ResetAll();
            }
        }

        private void SetGainLoss()
        {
            try
            {
                double doubleTryParse;
                double mrkValue=0.00;
                double MoneyBalanceTemp = 0.00;
                double TotalWithdrawBalance = 0.00;
                double TotalDepositBalance = 0.00;

                if(double.TryParse(Convert.ToString(txtMarketValue.Text), out doubleTryParse))
                    mrkValue=doubleTryParse;
                doubleTryParse = 0.00;
                if (double.TryParse(Convert.ToString(txtMoneyBalanceTemp.Text), out doubleTryParse))
                    MoneyBalanceTemp = doubleTryParse;
                doubleTryParse = 0.00;
                if (double.TryParse(Convert.ToString(txtTotalWithdrawBalance.Text), out doubleTryParse))
                    TotalWithdrawBalance = doubleTryParse;
                doubleTryParse = 0.00;
                if (double.TryParse(Convert.ToString(txtTotalDepositBalance.Text), out doubleTryParse))
                    TotalDepositBalance = doubleTryParse;

                txtgainLoss.Text = (mrkValue + MoneyBalanceTemp + TotalWithdrawBalance - TotalDepositBalance).ToString("N");
                txt_RiskValue.Text = "RV : " + (mrkValue - (-1)*MoneyBalanceTemp).ToString("N");
                ChangeControlColor(txt_RiskValue);
            }
            catch 
            {
            }
        }

        private void SetSpecificGainLoss(double GainLoass)
        {
            try
            {
                double mrkValue = 0.00;
                string v = lbltotalMarketValue.Text;
                int index = (lbltotalMarketValue.Text).IndexOf(":");
               
                if (index != -1)
                {
                    mrkValue =Convert.ToDouble(v.Remove(0,index+1).Trim());
                }
                txtSpecificGainLoss.Text = "ISN Gain/Loss : " + (GainLoass+mrkValue).ToString("N");
            }
            catch
            {
            }
        }

        private void LoadShareSummery()
        {
            DashboardBAL dashboardBal = new DashboardBAL();
            dgvShareSummery.DataSource = dashboardBal.GetShareSummery(txtCustCode.Text, Convert.ToInt16(chkShowPrev.Checked));
            //dgvShareSummery.DataSource = dashboardBal.GetShareSummery_FromTemp(txtCustCode.Text, Convert.ToInt16(chkShowPrev.Checked));
            if (dgvShareSummery.Rows.Count > 0)
            {
                dgvShareSummery.Columns[0].Width = 150;
                dgvShareSummery.Columns[1].DefaultCellStyle.Padding = new Padding(0, 0, 5, 0);
                dgvShareSummery.Columns[2].DefaultCellStyle.Padding = new Padding(0, 0, 5, 0);
                dgvShareSummery.Columns[0].DefaultCellStyle.ForeColor = Color.Green;
                dgvShareSummery.Columns[1].DefaultCellStyle.ForeColor = Color.Blue;
                dgvShareSummery.Columns[2].DefaultCellStyle.Font = new Font(dgvShareDetails.Font, FontStyle.Bold);
                dgvShareSummery.Columns[2].DefaultCellStyle.ForeColor = Color.DarkRed;
                dgvShareSummery.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvShareSummery.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }
        private void ChangeControlColor(TextBox textBox)
        {
            double tempDouble;
            if (textBox.Name.ToLower().Contains("status"))
            {
                if (textBox.Text.ToLower().Contains("closed"))
                    textBox.ForeColor = Color.Red;
                else
                    textBox.ForeColor = Color.Blue;
                return;
            }
            if (textBox.Text.Contains("RV : "))
            {
                var temp = Convert.ToDouble(textBox.Text.Replace("RV : ",""));
                if (temp < 0)
                {
                    textBox.ForeColor = Color.Red;
                }
                else
                {
                    textBox.ForeColor = Color.Green;
                }
              
                return;
            }

            if (textBox.Text.Length.Equals(0))
                return;
            tempDouble = Convert.ToDouble(textBox.Text);
            
            if(tempDouble<0)
            {
                textBox.ForeColor = Color.Red;
            }
            else
            {
                textBox.ForeColor = Color.Green;
            }
        }


        private void ResetAll()
        {
            txtCustCode.Text = "";
            txtAccountHolderBOId.Text = "";
            txtAccountHolderName.Text = "";
            txtLastDT.Text = "";
            txtTotalDepositBalance.Text = "";
            txtTotalWithdrawBalance.Text = "";
            txtMoneyBalanceTemp.Text = "";
            txtMatMonBal.Text = "";
            txt_status_Bo.Text = "";
            txtStatus_Cust.Text = "";
            txt_RiskValue.Text = "";
            
            dgvShareSummery.DataSource = null;
            dgvShareDetails.DataSource = null;
            txtSearchCustomer.SelectAll();
        }


        private void LoadShareDetails(string custCode, string compCode)
        {
            double doubleTryParse;
            decimal decimalTryParse;
            double gainloss = 0.00;
            string Margin = "";
            lblCompany.Text = "Share Details - " + compCode;
            DashboardBAL dashboardBal = new DashboardBAL();

            DataTable dataTable = dashboardBal.GetShareDetailsExtr(compCode, custCode);
            //DataTable dataTable = dashboardBal.GetShareDetailsExtr_FromTemp(compCode, custCode);

            if (dataTable.Rows.Count > 0)
            {

                if (double.TryParse(Convert.ToString(dataTable.Rows[0][0]), out doubleTryParse))
                    lbLastPrice.Text = "YCP : " + doubleTryParse.ToString("N");
                lbLastTradeDate.Text = "Last Trade: " + dataTable.Rows[0][1].ToString();
                if (decimal.TryParse(Convert.ToString(dataTable.Rows[0][2]), out decimalTryParse))
                    lbBuyAvg.Text = "Buy Avg : " + decimalTryParse.ToString("N");
                if (decimal.TryParse(Convert.ToString(dataTable.Rows[0][3]), out decimalTryParse))
                    lbNetAvg.Text = "Net Avg : " + decimalTryParse.ToString("N");
                lblCompany.Text = lblCompany.Text + " ( " + dataTable.Rows[0][4].ToString() + " ) ";
                if (Convert.ToString(dataTable.Rows[0]["Margin_Type"]) == "Margin")
                {
                    LblMargin.Text = Convert.ToString(dataTable.Rows[0]["Margin_Type"]);
                    LblMargin.ForeColor = Color.DarkGreen;
                }
                else if (Convert.ToString(dataTable.Rows[0]["Margin_Type"]) == "Non_Margin")
                {
                    LblMargin.Text = "Non Margin";
                    LblMargin.ForeColor = Color.SaddleBrown;
                }
                else
                {
                    LblMargin.Text = "";
                }

                if (double.TryParse(Convert.ToString(dataTable.Rows[0]["MarketValue"]), out doubleTryParse))
                {
                    lbltotalMarketValue.Text = "Market Value : " + Convert.ToString(doubleTryParse);//.ToString("N");
                }
                if (double.TryParse(Convert.ToString(dataTable.Rows[0]["Total_Buy"]), out doubleTryParse))
                {
                    lbltotalbuy.Text = "Total Buy : " + doubleTryParse.ToString("N");
                }
                if (double.TryParse(Convert.ToString(dataTable.Rows[0]["Gain_Loss"].ToString()), out doubleTryParse))
                {
                    gainloss = doubleTryParse;
                }
                SetSpecificGainLoss(gainloss);
            }


            dgvShareDetails.DataSource = dashboardBal.GetShareDetails(custCode, compCode);
            //dgvShareDetails.DataSource = dashboardBal.GetShareDetails_FromTemp(custCode, compCode);
            if (dgvShareDetails.Rows.Count > 0)
            {
                dgvShareDetails.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //dgvShareDetails.Columns[1].DefaultCellStyle.Format = "N";
                dgvShareDetails.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvShareDetails.Columns[2].DefaultCellStyle.Format = "N";
                dgvShareDetails.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvShareDetails.Columns[3].DefaultCellStyle.Format = "N";
                dgvShareDetails.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvShareDetails.Columns[4].DefaultCellStyle.Format = "N";
                dgvShareDetails.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvShareDetails.Columns[5].DefaultCellStyle.Format = "N";

            }
        }

        //Old Script
        //private void LoadShareDetails(string custCode, string compCode)
        //{
        //    double doubleTryParse;
        //    decimal decimalTryParse;
        //    double gainloss = 0.00;
        //    lblCompany.Text = "Share Details - " + compCode;
        //    DashboardBAL dashboardBal = new DashboardBAL();

        //    DataTable dataTable = dashboardBal.GetShareDetailsExtr(compCode,custCode);
        //    //DataTable dataTable = dashboardBal.GetShareDetailsExtr_FromTemp(compCode, custCode);
        //    if (dataTable.Rows.Count > 0)
        //    {

        //        if (double.TryParse(Convert.ToString(dataTable.Rows[0][0]),out doubleTryParse))
        //            lbLastPrice.Text = "YCP : " + doubleTryParse.ToString("N");
        //        lbLastTradeDate.Text = "Last Trade: " + dataTable.Rows[0][1].ToString();
        //        if(decimal.TryParse(Convert.ToString(dataTable.Rows[0][2]),out decimalTryParse))
        //            lbBuyAvg.Text = "Buy Avg : " + decimalTryParse.ToString("N");
        //        if (decimal.TryParse(Convert.ToString(dataTable.Rows[0][3]), out decimalTryParse))
        //            lbNetAvg.Text = "Net Avg : " + decimalTryParse.ToString("N");
        //        lblCompany.Text = lblCompany.Text +" ( "+ dataTable.Rows[0][4].ToString()+" ) ";
        //        if (double.TryParse(Convert.ToString(dataTable.Rows[0]["MarketValue"]), out doubleTryParse))
        //        {
        //            lbltotalMarketValue.Text = "Market Value : " + Convert.ToString(doubleTryParse);//.ToString("N");
        //        }
        //        if (double.TryParse(Convert.ToString(dataTable.Rows[0]["Total_Buy"]), out doubleTryParse))
        //        {
        //            lbltotalbuy.Text = "Total Buy : " + doubleTryParse.ToString("N");
        //        }
        //        if(double.TryParse(Convert.ToString(dataTable.Rows[0]["Gain_Loss"].ToString()),out doubleTryParse))
        //        {
        //            gainloss = doubleTryParse;
        //        }
        //        SetSpecificGainLoss(gainloss);
        //    }


        //    dgvShareDetails.DataSource = dashboardBal.GetShareDetails(custCode, compCode);
        //    //dgvShareDetails.DataSource = dashboardBal.GetShareDetails_FromTemp(custCode, compCode);
        //    if (dgvShareDetails.Rows.Count > 0)
        //    {
        //        dgvShareDetails.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        //        //dgvShareDetails.Columns[1].DefaultCellStyle.Format = "N";
        //        dgvShareDetails.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        //        dgvShareDetails.Columns[2].DefaultCellStyle.Format = "N";
        //        dgvShareDetails.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        //        dgvShareDetails.Columns[3].DefaultCellStyle.Format = "N";
        //        dgvShareDetails.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        //        dgvShareDetails.Columns[4].DefaultCellStyle.Format = "N";
        //        dgvShareDetails.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        //        dgvShareDetails.Columns[5].DefaultCellStyle.Format = "N";
                
        //    }
        //}

        private void dgvShareSummery_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvShareSummery.SelectedRows.Count == 0)
                return;
            LoadShareDetails(txtCustCode.Text, dgvShareSummery.Rows[dgvShareSummery.CurrentRow.Index].Cells[0].Value.ToString());
        }

        private void chkShowPrev_CheckedChanged(object sender, EventArgs e)
        {
            LoadShareSummery();
        }

        private void lbLastPrice_Click(object sender, EventArgs e)
        {

        }      

        private void lblCompany_Click(object sender, EventArgs e)
        {

        }

        private void lblCompany_TextChanged(object sender, EventArgs e)
        {
            if(dgvShareSummery.Rows.Count>0)
            {
                this.lblCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
           
            }

            else
            {
                this.lblCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
           
            }
        }

        private void showIpoacc()
        {
            IPODashBoardBAL dashBal = new IPODashBoardBAL();
            DataTable dt = new DataTable();
            //txtShowFist.Text = txtSearchCustomer.Text;
            if (ddlSearchCustomer.SelectedIndex == 0)
            {
                if (txtSearchCustomer.Text == "")
                {
                    MessageBox.Show("please provide your Customer code or Bo id");
                }
                else
                {
                    dt = dashBal.GetIpoHoldersInfo(txtSearchCustomer.Text, "");
                    if (dt.Rows.Count > 0)
                    {
                        txtIPORBorNRB.Text = dt.Rows[0]["RB NRB"].ToString();
                        txtIPOJointHolderName.Text = dt.Rows[0]["joint holder name"].ToString();
                        txtIPOAccountType.Text = dt.Rows[0]["AC Type"].ToString();
                        txtIPOPowerOfAttorny.Text = dt.Rows[0]["POA"].ToString();
                        txtIPONominee.Text = dt.Rows[0]["Nominee"].ToString();
                        chkIpoAllApply.Checked = false;
                    }
                    MemoryStream ms = GetEmployeeImageDashBoard(txtSearchCustomer.Text);
                    if (ms != null)
                    {
                        IpoSignaturePic.Image = Image.FromStream(ms);
                    }
                    else
                    {
                        IpoSignaturePic.Image = null;
                    }
                }
            }
            else
            {
                if (txtSearchCustomer.Text == "")
                {
                    MessageBox.Show("please provide your Customer code or Bo id");
                }
                else
                {
                    dt = dashBal.GetIpoHoldersInfo("", txtSearchCustomer.Text);
                    if (dt.Rows.Count > 0)
                    {
                        txtIPORBorNRB.Text = dt.Rows[0]["RB NRB"].ToString();
                        txtIPOJointHolderName.Text = dt.Rows[0]["joint holder name"].ToString();
                        txtIPOAccountType.Text = dt.Rows[0]["AC Type"].ToString();
                        txtIPOPowerOfAttorny.Text = dt.Rows[0]["POA"].ToString();
                        txtIPONominee.Text = dt.Rows[0]["Nominee"].ToString();
                    }
                    MemoryStream ms = GetEmployeeImageDashBoard(txtSearchCustomer.Text);
                    if (ms != null)
                    {
                        IpoSignaturePic.Image = Image.FromStream(ms);
                    }
                    else
                    {
                        IpoSignaturePic.Image = null;
                    }
                }
            }
        }

        private void btnIPOAccInfo_Click(object sender, EventArgs e)
        {

            if (btnIPOAccInfo.Text == "IPO Info Show")
            {
                ResetPrevillize();
                LoadPrevilize();

                panel2.Visible = true;
                panel2.Location = new Point(8, 240);                
                panel3.Visible = false;
                //panel1.Size = new Size(962, 195);
                panel1.Size = new Size(962, 570);
                btnIPOAccInfo.Location = new Point(417, 545);
                btnverification.Location = new Point(585, 514);
                //this.Size = new Size(989, 670);
                this.Size = new Size(972, 620);
                IPOResetAll();
                showIpoacc();
                LoadIPOShareSummery(checkBox1.Checked,chkIpoAllApply.Checked);
                IPOGainLoss();
                quantity = new string[] { txtCustCode.Text };
                btnIPOAccInfo.Text = "IPO Info Hide";
                IpoSignaturePic.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else if (btnIPOAccInfo.Text == "IPO Info Hide")
            {                
                Panel3show();
            }

            
        }
        private void Panel3show()
        {
            //panel1.Size = new Size(962, 412);
            panel1.Size = new Size(962, 520);
            panel3.Visible = true;
            panel2.Visible = false;
            //btnIPOAccInfo.Location = new Point(417, 420);
            btnIPOAccInfo.Location = new Point(417, 460);
            btnverification.Location = new Point(585, 420);
            //this.Size = new Size(989, 580);
            this.Size = new Size(972, 520);
            btnIPOAccInfo.Text = "IPO Info Show";
        }

        

        private void AccDashboard_KeyDown(object sender, KeyEventArgs e)
        {            
            if(e.KeyCode==Keys.ControlKey&&e.KeyCode==Keys.D)
            {
                btnIPOAccInfo.PerformClick();
                e.SuppressKeyPress = true;                
            }
        }

        private void AccDashboard_KeyPress(object sender, KeyPressEventArgs e)
        {
             
        }

        private void btnIPOAccInfo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey && e.KeyCode == Keys.D)
            {
                btnIPOAccInfo.PerformClick();
                e.SuppressKeyPress = true;
                //showIpoacc();
            }
        }

        
        private void IPOResetAll()
        {
            txtIPOAccountType.Text = "";
            txtIPOJointHolderName.Text = "";
            txtIPONominee.Text = "";
            txtIPORBorNRB.Text = "";
            txtIPOPowerOfAttorny.Text = "";            
            dgvIPOShareSummery.DataSource = null;
            dgvIPOShareDetails.DataSource = null;
            txtSearchCustomer.SelectAll();
        }
        /// <summary>
        /// Update By Md.rashedul Hasan on 04-Feb-2015
        /// </summary>
        /// <param name="custCode"></param>
        /// <param name="compCode"></param>
        private void LoadIPOShareDetails(string custCode, string compCode)
        {
            //double doubleTryParse;
            //decimal decimalTryParse;

            IPOlblCompany.Text = "Share Details - " + compCode;
            IPODashBoardBAL dashboardBal = new IPODashBoardBAL();

            //DataTable dataTable = dashboardBal.GetShareDetailsExtr(compCode,custCode);
            DataTable dataTable = dashboardBal.IPOShareDetails(custCode, compCode);
            if (dataTable.Rows.Count > 0)
            {
                IPOlblCompany.Text = IPOlblCompany.Text + " ( TK. " + dataTable.Rows[0]["TotalAmount"].ToString() + " ) ";

            }


            //dgvShareDetails.DataSource = dashboardBal.GetShareDetails(custCode, compCode);
            dgvIPOShareDetails.DataSource = dashboardBal.IPOShareDetails(custCode, compCode);
            if (dgvIPOShareDetails.Rows.Count > 0)
            {
                if (dgvIPOShareDetails.ColumnCount == 1)
                {
                    dgvIPOShareDetails.DataSource = null;
                }
                else
                {
                    dgvIPOShareDetails.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    //   dgvIPOShareDetails.Columns[1].DefaultCellStyle.Format = "N";
                    dgvIPOShareDetails.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvIPOShareDetails.Columns[2].DefaultCellStyle.Format = "N";
                    dgvIPOShareDetails.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvIPOShareDetails.Columns[3].DefaultCellStyle.Format = "N";
                }

            }
        }
        
        private void LoadIPOShareSummery(bool previousShareSummary, bool AllipoApply)
        {
            IPODashBoardBAL dashboardBal = new IPODashBoardBAL();            
            DataTable dtAllIpoapply = new DataTable();
            DataTable dtIPOShageSummary = new DataTable();
           
            dgvIPOShareSummery.DataSource = null;
            //dgvShareSummery.DataSource = dashboardBal.GetShareSummery(txtCustCode.Text, Convert.ToInt16(chkShowPrev.Checked));

            if (AllipoApply)
            {
                //dtAllIpoapply.Rows.Clear();
                dtAllIpoapply = dashboardBal.AllIpoapply(txtCustCode.Text);
                if (dtAllIpoapply.Rows.Count > 0)
                    dgvIPOShareSummery.DataSource = dtAllIpoapply;
                //dgvIPOShareSummery.Columns["Amount"].Visible = false;
            }
            else
            {
                //dtIPOShageSummary.Rows.Clear();
                dtIPOShageSummary = dashboardBal.IPOShageSummary(txtCustCode.Text);
                if (dtIPOShageSummary.Rows.Count > 0)
                {
                    dgvIPOShareSummery.DataSource = dtIPOShageSummary;
                    //dgvIPOShareSummery.Columns["Amount"].Visible = false;
                }
            }
        }
        /****************************************End 04-Feb-2015***************************************/
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           //LoadIPOShareSummery(checkBox1.Checked, chkIpoAllApply.Checked);
        }

        private void dgvIPOShareSummery_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvIPOShareSummery.SelectedRows.Count == 0)
                return;
            LoadIPOShareDetails(txtCustCode.Text, dgvIPOShareSummery.Rows[dgvIPOShareSummery.CurrentRow.Index].Cells[0].Value.ToString().Trim());

        }

        private void IPOlblCompany_TextChanged(object sender, EventArgs e)
        {
            if (dgvIPOShareSummery.Rows.Count > 0)
            {
                this.IPOlblCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                
            }

            else
            {
                this.IPOlblCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            }
        }

        private void IPOlblCompany_Click(object sender, EventArgs e)
        {
            if (dgvIPOShareSummery.Rows.Count > 0)
            {
                Graphs objgraph = new Graphs();
                objgraph.CompanyShortCode = dgvIPOShareSummery.SelectedRows[0].Cells["Company"].Value.ToString();
                objgraph.Show();
            }
        }

        private void chkIpoAllApply_CheckedChanged(object sender, EventArgs e)
        {

            LoadIPOShareSummery(checkBox1.Checked, chkIpoAllApply.Checked);
                
        }

        private void IPOGainLoss()
        {
            IPODashBoardBAL dash = new IPODashBoardBAL();
            DataTable dt = new DataTable();
            dt = dash.IpoAccountinfo(txtCustCode.Text);
            //if (dt.Rows[0][0] != DBNull.Value)
            //    txtMatMonBal.Text = Convert.ToDouble(dataTable.Rows[0][7]).ToString("N");
            if (dt.Rows.Count > 0)
            {
                txtIPODeposit.Text = dt.Rows[0]["Total_Deposit"].ToString();
                txtIPOWithdraw.Text = dt.Rows[0]["Total_Withdraw"].ToString();
                txtIPOCurMonBal.Text = dt.Rows[0]["Current_Money_Balance"].ToString();
                txtIPOMatMonBal.Text = dt.Rows[0]["Matured_Money_Balance"].ToString();
                txtIPOMarketValue.Text = dt.Rows[0]["Total_Market_Value"].ToString();
            }
        }

        

        private void txtSearchCustomer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                updateProcess();
                ClearAll();
                GetCustomerDetails();
            }
        }


        private void updateProcess()
        {

            DashboardBAL bal = new DashboardBAL();
            bal.IPODashboardProcessIndividualCustCode(Convert.ToInt32(txtSearchCustomer.Text));
        }

        private MemoryStream GetEmployeeImageDashBoard(string id)
        {
            CustomerVerificationInfoBal objBAL = new CustomerVerificationInfoBal();
            MemoryStream ms = null;
            byte[] imageBute = new byte[0];
            string Cust_Code=string.Empty;
            string BO_ID=string.Empty;
            if(id.Length>7)
                BO_ID=id;
            else 
                Cust_Code=id;
            imageBute = objBAL.GetCustomerImageSignature(Cust_Code, BO_ID);
            if (imageBute != null)
            {
                ms = new MemoryStream(imageBute);
            }
            return ms;
        }

        

        private void IpoSignaturePic_MouseEnter(object sender, EventArgs e)
        {
            IpoSignaturePic.SizeMode = PictureBoxSizeMode.StretchImage;
            IpoSignaturePic.Size = new Size(156, 65);
            IpoSignaturePic.Location = new Point(0, 15);
            gpImage.Size = new Size(160, 90);
            IpoSignaturePic.Cursor = Cursors.Hand;
            
        }

        private void IpoSignaturePic_MouseLeave(object sender, EventArgs e)
        {
            IpoSignaturePic.SizeMode = PictureBoxSizeMode.Zoom;
            IpoSignaturePic.Size = new Size(141, 67);
            gpImage.Size = new Size(154, 93);
            IpoSignaturePic.Location = new Point(7, 20);
            IpoSignaturePic.Cursor = Cursors.Hand;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmCustomerVerificationInfo info = new frmCustomerVerificationInfo(quantity);
            info.Show();
        }

        private void btnverification_Click(object sender, EventArgs e)
        {
            frmCustomerVerificationInfo info = new frmCustomerVerificationInfo(quantity);
            info.Show();
        }

        private void IpoSignaturePic_Click(object sender, EventArgs e)
        {
            frmCustomerVerificationInfo info = new frmCustomerVerificationInfo(quantity);
            info.StartPosition = FormStartPosition.CenterScreen;
            info.ShowDialog(this);
        }

        /// <summary>
        /// Set Previlize For client Account Information
        /// Add By Md.Rashedul Hasan
        /// </summary>
        private void SetPrevillize(string Previllize)
        {
            switch (Previllize)
            {
                case "Dash Board Signature Verification":
                    IpoSignaturePic.Visible = true;
                    break;               

                default:
                    break;
            }
        }

        /// <summary>
        /// Load Previlize For client Account Information
        /// Add By Md.Rashedul Hasan
        /// </summary>
        private void LoadPrevilize()
        {
            bool result = false;
            DataTable RoleWiseUserPrevillizeDatatable = new DataTable();
            DataTable RoleWisePrevillizeDataTable = new DataTable();
            PrevillizeManagementBAL previllizeManagementBal = new PrevillizeManagementBAL();

            RoleWisePrevillizeDataTable = previllizeManagementBal.GetRoleWisePrevillize();


            RoleWiseUserPrevillizeDatatable = previllizeManagementBal.GetAssignedPrevillize();
            if (RoleWiseUserPrevillizeDatatable.Rows.Count > 0)
            {
                for (int i = 0; i < RoleWiseUserPrevillizeDatatable.Rows.Count; i++)
                {
                    if (RoleWiseUserPrevillizeDatatable.Rows[i][0].ToString().ToLower() == GlobalVariableBO._userName.ToLower())
                    {
                        result = true;
                        break;
                    }
                }
                if (result)
                {
                    for (int j = 0; j < RoleWiseUserPrevillizeDatatable.Rows.Count; j++)
                    {
                        if (RoleWiseUserPrevillizeDatatable.Rows[j][0].ToString().ToLower() == GlobalVariableBO._userName.ToLower())
                        {
                            SetPrevillize(RoleWiseUserPrevillizeDatatable.Rows[j]["Previllize"].ToString());
                        }
                    }
                }
                DeactiveMenu();
            }
            else if (RoleWiseUserPrevillizeDatatable.Rows.Count == 0)
            {
                RoleWisePrevillizeDataTable = previllizeManagementBal.GetRoleWisePrevillize();

                for (int k = 0; k < RoleWisePrevillizeDataTable.Rows.Count; k++)
                {
                    SetPrevillize(RoleWisePrevillizeDataTable.Rows[k]["Previllize"].ToString());
                }
                DeactiveMenu();
            }
        }



        private void DeactiveMenu()
        {
        }

        /// <summary>
        /// Reset Previlize For client Account Information
        /// Add By Md.Rashedul Hasan
        /// </summary>
        public void ResetPrevillize()
        {
            IpoSignaturePic.Visible = false;
             
        }

       

       

      
       
    }
}
