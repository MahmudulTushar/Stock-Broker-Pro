using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using ZedGraph;

namespace StockbrokerProNewArch
{
    public partial class AccDashboardLR : Form
    {

        public AccDashboardLR()
        {
            InitializeComponent();
        }

        private void AccDashboard_Load(object sender, EventArgs e)
        {
            ddlSearchCustomer.SelectedIndex = 0;
            txtSearchCustomer.Focus();
        }
       
        private void btnGo_Click(object sender, EventArgs e)
        {
            ClearAll();
            int previllige = 0;
            PrevillizeManagementBAL previllizeManagementBal = new PrevillizeManagementBAL();
            previllige = previllizeManagementBal.GetDashboardUserPrevillize();
            DashboardBAL dashboardBal=new DashboardBAL();
            if(previllige==1)
            {
                GetCustomerDetails();
            }
            else
            {
                int isHidden = 0;
                if (ddlSearchCustomer.SelectedIndex == 0)
                {
                    isHidden = dashboardBal.CheckHiddenCustomer(txtSearchCustomer.Text);
                }
                else
                {
                    isHidden = dashboardBal.CheckHiddenCustomer("dbo.GetCustCodeFromBO("+txtSearchCustomer.Text+")");
                }
                if(isHidden==1)
                {
                    MessageBox.Show("You do not have the access to see this customer", "Warning.");
                }
                else
                {
                    if(dashboardBal.IsLimitedDashboardPrivliage()==1)
                    {
                        if (ddlSearchCustomer.SelectedIndex == 0)
                        {
                            if (dashboardBal.IsLimitedfromDashboard(txtSearchCustomer.Text) == true)
                                GetCustomerDetails();

                            else
                            {
                                MessageBox.Show("No Previllize to See this Information.", "Dashboard", MessageBoxButtons.OK,
                                                MessageBoxIcon.Information);
                            }
                        }

                        else if (ddlSearchCustomer.SelectedIndex == 1)
                        {
                            if (dashboardBal.IsLimitedDashboardByBOID(txtSearchCustomer.Text) == true)
                                GetCustomerDetails();

                            else
                            {
                                MessageBox.Show("No Previllize to See this Information.", "Dashboard", MessageBoxButtons.OK,
                                                MessageBoxIcon.Information);
                            }
                        }

                        else
                        {
                            MessageBox.Show("No Client Information found.", "Dashboard", MessageBoxButtons.OK,
                                               MessageBoxIcon.Information);
                        }

                    }

                    else
                    {
                        GetCustomerDetails();
                    }
                   
                }
            }
        }

        private void ClearAll()
        {
            dgvShareDetails.DataSource = null;
            dgvShareSummery.DataSource = null;
            txtAccountHolderBOId.Text = "";
            txtAccountHolderName.Text = "";
            txtCurMonBal.Text = "";
            txtCurrentBalance.Text = "";
            txtCustCode.Text = "";
            txtLastDT.Text = "";
            txtMatMonBal.Text = "";
            txtMaturedBalance.Text = "";
            txtMarketValue.Text = "";
            lbBuyAvg.Text = "Bug Avg : 00.00";
            lbLastPrice.Text = "Last Price : 00.00";
            lbLastTradeDate.Text = "Last Trade : 00-00-0000";
            lblCompany.Text = "Share Details -";
            txtStatus.Text = "";
            txtgainLoss.Text = "";
        }

        private void GetCustomerDetails()
        {
            DashboardBAL dashboardBal = new DashboardBAL();
            DataTable dataTable;
            if (ddlSearchCustomer.SelectedIndex == 0)
            {
                dataTable = dashboardBal.GetCustomerDetails(txtSearchCustomer.Text, 1);
            }
            else
            {
                dataTable = dashboardBal.GetCustomerDetails(txtSearchCustomer.Text, 0);
            }
            if (dataTable.Rows.Count > 0)
            {
                txtCustCode.Text = dataTable.Rows[0][0].ToString();
                txtAccountHolderBOId.Text = dataTable.Rows[0][1].ToString();
                txtAccountHolderName.Text = dataTable.Rows[0][2].ToString();
                txtLastDT.Text = dataTable.Rows[0][3].ToString();
                if (dataTable.Rows[0][4] != DBNull.Value)
                    txtCurrentBalance.Text = Convert.ToDouble(dataTable.Rows[0][4]).ToString("N");
                if (dataTable.Rows[0][5] != DBNull.Value)
                    txtMaturedBalance.Text = Convert.ToDouble(dataTable.Rows[0][5]).ToString("N");
                if (dataTable.Rows[0][6] != DBNull.Value)
                    txtCurMonBal.Text = Convert.ToDouble(dataTable.Rows[0][6]).ToString("N");
                if (dataTable.Rows[0][7] != DBNull.Value)
                    txtMatMonBal.Text = Convert.ToDouble(dataTable.Rows[0][7]).ToString("N");
                if (dataTable.Rows[0][8] != DBNull.Value)
                    txtMarketValue.Text = Convert.ToDouble(dataTable.Rows[0][8]).ToString("N");
                if (dataTable.Rows[0][9] != DBNull.Value)
                    txtStatus.Text = dataTable.Rows[0][9].ToString();

                ChangeControlColor(txtCurrentBalance);
                ChangeControlColor(txtMaturedBalance);
                ChangeControlColor(txtCurMonBal);
                ChangeControlColor(txtMatMonBal);
                txtSearchCustomer.SelectAll();
                dashboardBal.InsertDashboardLog(txtCustCode.Text);
                LoadShareSummery();
                SetGainLoss();
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
                txtgainLoss.Text = (double.Parse(txtMarketValue.Text) + double.Parse(txtCurMonBal.Text) +
                                   double.Parse(txtMaturedBalance.Text) - double.Parse(txtCurrentBalance.Text)).ToString("N");
            }
            catch
            {
            }
        }

        private void LoadShareSummery()
        {
            DashboardBAL dashboardBal = new DashboardBAL();
            dgvShareSummery.DataSource = dashboardBal.GetShareSummery(txtCustCode.Text, Convert.ToInt16(chkShowPrev.Checked));
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
            txtCurrentBalance.Text = "";
            txtMaturedBalance.Text = "";
            txtCurMonBal.Text = "";
            txtMatMonBal.Text = "";
            
            dgvShareSummery.DataSource = null;
            dgvShareDetails.DataSource = null;
            txtSearchCustomer.SelectAll();
        }

        private void LoadShareDetails(string custCode, string compCode)
        {
            lblCompany.Text = "Share Details - " + compCode;
            DashboardBAL dashboardBal = new DashboardBAL();

            DataTable dataTable = dashboardBal.GetShareDetailsExtr(compCode,custCode);
            if (dataTable.Rows.Count > 0)
            {
                lbLastPrice.Text = "Last Price : " + Convert.ToDouble(dataTable.Rows[0][0]).ToString("N");
                lbLastTradeDate.Text = "Last Trade :" + dataTable.Rows[0][1].ToString();
                lbBuyAvg.Text = "Buy Avg : " + Convert.ToDecimal(dataTable.Rows[0][2]).ToString("N");
            }


            dgvShareDetails.DataSource = dashboardBal.GetShareDetails(custCode, compCode);
            if (dgvShareDetails.Rows.Count > 0)
            {
                dgvShareDetails.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvShareDetails.Columns[1].DefaultCellStyle.Format = "N";
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

        private void dgvShareSummery_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvShareSummery.SelectedRows.Count == 0)
                return;
            LoadShareDetails(txtCustCode.Text, dgvShareSummery.Rows[dgvShareSummery.CurrentRow.Index].Cells[0].Value.ToString());
        }

        private void chkShowPrev_CheckedChanged(object sender, EventArgs e)
        {
            LoadShareSummery();
            frm_Market_Value frm = new frm_Market_Value();
            frm.ShowDialog(this);
        }

        private void lbLastPrice_Click(object sender, EventArgs e)
        {

        }

        private void lblCompany_TextChanged(object sender, EventArgs e)
        {
            if (dgvShareSummery.Rows.Count > 0)
            {
                this.lblCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            }

            else
            {
                this.lblCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            }
        }

        private void lblCompany_Click(object sender, EventArgs e)
        {
            if (dgvShareSummery.Rows.Count > 0)
            {              
                Graphs objgraph = new Graphs();
                objgraph.CompanyShortCode = dgvShareSummery.SelectedRows[0].Cells["Company"].Value.ToString();
                objgraph.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm_Market_Value frm = new frm_Market_Value();
            frm.ShowDialog(this);
        }

          
    }
}
