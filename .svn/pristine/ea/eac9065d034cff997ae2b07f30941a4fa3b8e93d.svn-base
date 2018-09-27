using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using BusinessAccessLayer.BAL;
using BusinessAccessLayer.BO;

namespace StockbrokerProNewArch
{
    public partial class FrmShareConvertion_Withdraw : Form
    {
        string FPath = string.Empty;
        DataTable dtCompany = new DataTable();
        CommonBAL cmnBAL = new CommonBAL();
        double SecRatio;

        public FrmShareConvertion_Withdraw()
        {
            InitializeComponent();
        }


        private void FrmShareConvertion_Withdraw_Load(object sender, EventArgs e)
        {
            LoadDepositCompanyName();

            this.Size = new Size(884, 510);
            pnlErrorInformation.Visible = false;

            txtFilePath.Text = string.Empty;
            if (dtCompany.Rows.Count > 0)
            {
                dtCompany.Clear();
            }
            txtShareWithdrawRate.Text = string.Empty;
            txtRatioSecond.Text = string.Empty;
            cmbWithCompany.DataSource = null;
        }
        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    FPath = openFileDialog1.FileName;
                    txtFilePath.Text = FPath;
                    TextFileProcess();
                    txtShareWithdrawRate.Focus();
                }
                catch
                {  //          "Please, Rewrite..."+"\r\n"+"It Exceeds The Existing Balance..."
                    MessageBox.Show("File Processing Error..." + "\r\n" + "", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnSelectFile.Focus();
                }
            }
        }

        private void LoadDepositCompanyName()
        {
            DataTable dt = new DataTable();
            dt = cmnBAL.GetAllCompanyName();
            cmbDepositCompany.DataSource = dt;
            cmbDepositCompany.DisplayMember = "Company_Name";
        }

        private void TextFileProcess()
        {
            const char CHAR = '~';
            //DataTable dt = new DataTable();
            StreamReader SR = new StreamReader(FPath);

            if (FPath != string.Empty)
            {
                try
                {
                    if (dtCompany.Columns.Count == 0)
                    {
                        dtCompany.Columns.Add("ISIN");
                        dtCompany.Columns.Add("Company Name");
                        dtCompany.Columns.Add("BO ID");
                        dtCompany.Columns.Add("Custoemr NAME");
                        dtCompany.Columns.Add("BO Status");
                        dtCompany.Columns.Add("Current Balance");
                        dtCompany.Columns.Add("Free Balance");
                        dtCompany.Columns.Add("Freeze Balance");
                        dtCompany.Columns.Add("Lockin Balance");
                        dtCompany.Columns.Add("Pledge Balance");
                        dtCompany.Columns.Add("Pending Demat Confirmation");
                        dtCompany.Columns.Add("Pending Remat Confirmation");
                        dtCompany.Columns.Add("Remlock Balance");
                        dtCompany.Columns.Add("Lend Balance");
                        dtCompany.Columns.Add("Borrow Balance");
                        dtCompany.Columns.Add("Available Lend Balance");
                        dtCompany.Columns.Add("Earmark Balance");
                        dtCompany.Columns.Add("Elmn Balance");
                        dtCompany.Columns.Add("Date");
                    }
                    dtCompany.Rows.Clear();
                    while (SR.Peek() >= 0)
                    {
                        string[] Row = SR.ReadLine().Split(CHAR);
                        dtCompany.Rows.Add(Row);
                    }
                    dgvFileInformation.DataSource = dtCompany;
                    lblCount.Text = Convert.ToString(dgvFileInformation.Rows.Count);

                    DataView view = new DataView(dtCompany);
                    DataTable distinctValues = view.ToTable(true, "ISIN");
                    string IsinNo = distinctValues.Rows[0][0].ToString();
                    DataTable dt = cmnBAL.GetAllCompanyName(IsinNo);
                    cmbWithCompany.DataSource = dt;
                    cmbWithCompany.DisplayMember = "Comp_Name";
                    cmbWithCompany.ValueMember = "ISIN_No";
                }
                catch
                {
                    MessageBox.Show("File Processing Error....");
                }
            }
            else
            {
                MessageBox.Show("No File Found...", "Error..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ProcessValidation()
        {
            double doubleTryParse;

            if (txtFilePath.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please Select File..", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSelectFile.Focus();
                return true;
            }
            else if (txtFilePath.Text.Trim() != string.Empty & dtCompany.Rows.Count <= 0)
            {
                MessageBox.Show("Please Select Correct File..", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSelectFile.Focus();
                return true;
            }

            else if (txtShareWithdrawRate.Text == string.Empty)
            {
                MessageBox.Show("Please Write Share Rate..", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtShareWithdrawRate.Focus();
                return true;
            }
            else if (txtShareWithdrawRate.Text.Trim() == Convert.ToString(0))
            {
                MessageBox.Show("Zero isn't allowed...", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtShareWithdrawRate.Focus();
                return true;
            }
            else if (!double.TryParse(txtShareWithdrawRate.Text.Trim(), out doubleTryParse))
            {
                MessageBox.Show("Write at Correct Formate...", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtShareWithdrawRate.Focus();
                return true;
            }
            else if (txtRatioSecond.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please Write Ratio First...", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtRatioSecond.Focus();
                return true;
            }
            else if (txtRatioSecond.Text.Trim() == Convert.ToString(0))
            {
                MessageBox.Show("Zero isn't allowed...", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtRatioSecond.Focus();
                return true;
            }

            else if (!double.TryParse(txtRatioSecond.Text.Trim(), out doubleTryParse))
            {
                MessageBox.Show("Write at Correct Formate...", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtRatioSecond.Focus();
                return true;
            }
            return false;
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (ProcessValidation())
                return;
            if (MessageBox.Show("Want to Run Withdrawal Process?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                ShareDWBO_Conversion_Collection collectionBO = new ShareDWBO_Conversion_Collection();
                ShareDWBAL BAL = new ShareDWBAL();
                ShareDWBO_Conversion BO = new ShareDWBO_Conversion();

                try
                {
                    collectionBO = ProcessDatatable(dtCompany);
                }
                catch
                {
                    MessageBox.Show("File Process Failed...", "Information!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                foreach (ShareDWBO_Conversion DW_BO in collectionBO)
                {
                    try
                    {
                        BAL.OnlyWithdraw_ForConvertion(DW_BO);
                    }
                    catch (Exception ex)
                    {
                        AddErrorMessageInGridView(DW_BO.CustCode, DW_BO.BO_ID, ex.Message);
                    }
                }
                MessageBox.Show("Share Deposit Process Completed....", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ErrorManagement();
            }
        }

        private void ErrorManagement()
        {
            if (dgvErrorInformation.Rows.Count > 0)
            {
                this.Size = new Size(884, 699);
                pnlErrorInformation.Visible = true;
                lblErrorCount.Text = Convert.ToString(dgvErrorInformation.Rows.Count);
            }
            txtFilePath.Text = string.Empty;
            txtShareWithdrawRate.Text = string.Empty;
            txtRatioSecond.Text = string.Empty;
        }
        private void AddErrorMessageInGridView(string cust_Code, string BO_ID, string Message)
        {
            string[] rowString = new string[] { (dgvErrorInformation.Rows.Count + 1).ToString(), cust_Code, BO_ID, Message };
            dgvErrorInformation.Rows.Add(rowString);
        }
        private ShareDWBO_Conversion_Collection ProcessDatatable(DataTable dtCompany)
        {
            ShareDWBO_Conversion_Collection CollectionBO = new ShareDWBO_Conversion_Collection();
            DateTime Time = cmnBAL.GetCurrentServerDate_FromDB();

            foreach (DataRow row in dtCompany.Rows)
            {
                DataTable dt = new DataTable();
                ShareDWBO_Conversion sBO = new ShareDWBO_Conversion();
                ShareDWBAL sBAL = new ShareDWBAL();
                LockInShareBAL lockbal = new LockInShareBAL();


                SecRatio = Convert.ToDouble(txtRatioSecond.Text.Trim());

                sBO.BO_ID = (row["BO ID"].ToString().Remove(0, 8));
                sBO.CustCode = sBAL.GetCust_CodeByBO_ID((row["BO ID"].ToString()).Remove(0, 8));
                //string isinNo = row["ISIN"].ToString();
                DataTable dtForShortCode = cmnBAL.GetAllCompanyName(Convert.ToString(row["ISIN"].ToString()));
                sBO.CompanyShortCode = dtForShortCode.Rows[0][2].ToString();
                sBO.Quantity = Convert.ToInt32(row["Current Balance"].ToString());
                sBO.LockedInQuantity = Convert.ToInt32(row["Lockin Balance"].ToString());
                sBO.AvailableQuantity = sBO.Quantity - sBO.LockedInQuantity;
                sBO.DepositWithdraw = "Withdraw";
                sBO.RecordDate = Time.Date;
                sBO.Received_Date = Time.Date;
                sBO.EffectiveDate = Time.Date;
                sBO.VoucherNo = string.Empty;
                sBO.OtherCompanyShortCode = sBAL.GetShortCodeByCompanyName(cmbDepositCompany.Text.Trim());
                sBO.DepositType = sBO.CompanyShortCode + "->" + sBO.OtherCompanyShortCode;
                //sBO.DepositType = sBO.CompanyShortCode + "->" + sBAL.GetShortCodeByCompanyName(cmbDepositCompany.Text.Trim());
                sBO.ShareType = "CDBL";

                //dt = sBAL.GetIssuePrice(sBO.CustCode, sBO.CompanyShortCode);

                //sBO.IssuePrice = float.Parse(dt.Rows[0]["Buy_Rate"].ToString());
                //sBO.IssueAmount = (sBO.IssuePrice * sBO.Quantity);

                DataTable dtCommission = new DataTable();
                dtCommission = sBAL.GetCommissionRate(sBO.CustCode);
                double CommissionRate = Convert.ToDouble(dtCommission.Rows[0][0].ToString());

                dt = sBAL.GetIssuePrice(sBO.CustCode, sBO.CompanyShortCode, CommissionRate, Convert.ToDouble(txtShareWithdrawRate.Text.Trim()));
                if (dt.Rows.Count > 0)
                {
                    sBO.IssuePrice = float.Parse(dt.Rows[0]["Buy_Rate"].ToString());
                    sBO.IssueAmount = (sBO.IssuePrice * sBO.Quantity);
                }

                float MarketPriceByDSE = float.Parse(txtShareWithdrawRate.Text.Trim());
                string RowDepositShareQty = Convert.ToString(sBO.Quantity * SecRatio);
                string[] a = RowDepositShareQty.Split(new char[] { '.' });
                sBO.OtherShareQty = Convert.ToInt32(a[0]);
                if (a.Count() == 2)
                {
                    sBO.DB_FracPoint = float.Parse("." + a[1]);
                }

                if (sBO.IssueAmount > 0)
                {
                    sBO.DB_FractureValue = sBO.DB_FracPoint * MarketPriceByDSE;
                    float NetInvestment = (sBO.IssueAmount - sBO.DB_FractureValue);
                    sBO.IssueAmount = NetInvestment;
                    sBO.IssuePrice = (sBO.IssueAmount / sBO.Quantity);
                }
                CollectionBO.ADD(sBO);



                //sBO.DepositWithdraw = "Withdraw";
                //sBO.DepositType = "Con.(" + sBO.CompanyShortCode + "->" + sBAL.GetShortCodeByCompanyName(cmbToCompany.Text.Trim()) + ")";
                //sBO.RecordDate = Time;
                //sBO.Received_Date = Time;
                //sBO.EffectiveDate = Time;
                //sBO.VoucherNo = string.Empty;


                //float MarketPriceByDSE = float.Parse(txtShareWithdrawRate.Text.Trim());
                //string RowDepositShareQty = Convert.ToString(float.Parse(dt.Rows[0]["Matured_Balance"].ToString()) * float.Parse(txtRatioSecond.Text.Trim()));
                //string[] a = RowDepositShareQty.Split(new char[] { '.' });
                //int DepositShareWQty = Convert.ToInt32(a[0]);
                ////string fractureQty = "0";
                //if (a.Count() == 2)
                //{
                //    shareDwbo.DB_FracPoint = float.Parse("." + a[1]);
                //}

                //if (shareDwbo.IssueAmount > 0)
                //{
                //    shareDwbo.DB_FractureValue = ((shareDwbo.DB_FracPoint) * MarketPriceByDSE);
                //    float NetInvestment = (float.Parse(dt.Rows[0]["WithdrawAmount"].ToString()) - shareDwbo.DB_FractureValue);
                //    shareDwbo.IssueAmount = NetInvestment;
                //    shareDwbo.IssuePrice = (shareDwbo.IssueAmount / shareDwbo.Quantity);
                //}
            }
            return CollectionBO;
        }

        private void cbIfEqual_CheckedChanged(object sender, EventArgs e)
        {
            if (cbIfEqual.Checked)
            {
                txtRatioSecond.Text = Convert.ToString(1);
                txtRatioSecond.Enabled = false;
                cmbDepositCompany.Focus();
                ep1.SetError(cmbDepositCompany, "Select Company Name Carefully...");
            }
            else
            {
                txtRatioSecond.Enabled = true;
                txtRatioSecond.Text = string.Empty;
                txtRatioSecond.Focus();
            }
        }
        private void txtShareWithdrawRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                double doubleTryParse;
                if (txtShareWithdrawRate.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please Write Share Rate First...", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtShareWithdrawRate.Focus();
                }
                else if (txtShareWithdrawRate.Text.Trim() == Convert.ToString(0))
                {
                    MessageBox.Show("Zero isn't allowed...", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtShareWithdrawRate.Focus();
                }
                else if (!double.TryParse(txtShareWithdrawRate.Text.Trim(), out doubleTryParse))
                {
                    MessageBox.Show("Write at Correct Formate...", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtShareWithdrawRate.Focus();
                }
                else
                {
                    txtRatioSecond.Focus();
                }
            }
        }

        private void txtRatioSecond_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                double doubleTryParse;
                if (txtRatioSecond.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please Write Ratio First...", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtRatioSecond.Focus();
                }
                else if (txtRatioSecond.Text.Trim() == Convert.ToString(0))
                {
                    MessageBox.Show("Zero isn't allowed...", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtRatioSecond.Focus();
                }
                else if (!double.TryParse(txtRatioSecond.Text.Trim(), out doubleTryParse))
                {
                    MessageBox.Show("Write at Correct Formate...", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtRatioSecond.Focus();
                }
                else
                {
                    ep1.Clear();
                    ep1.SetError(cmbDepositCompany, "Select Company Name Carefully...");
                }
            }
        }
    }
}
