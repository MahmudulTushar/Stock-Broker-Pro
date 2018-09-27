using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using BusinessAccessLayer.BO;
using BusinessAccessLayer.BAL;
using System.Threading;


namespace StockbrokerProNewArch
{
    public partial class FrmShareConvertion_Deposit : Form
    {
        string FPath = string.Empty;
        DataTable dtCompany = new DataTable();
        CommonBAL cmnBAL = new CommonBAL();

        public FrmShareConvertion_Deposit()
        {
            InitializeComponent();
        }
        private void FrmShareConvertion_Deposit_Load(object sender, EventArgs e)
        {
            this.Size = new Size(882, 511);
            pnlErrorInformation.Visible = false;

            txtFilePath.Text = string.Empty;
            if (dtCompany.Rows.Count > 0)
            {
                dtCompany.Clear();
            }
            txtShareWithdrawRate.Text = string.Empty;
            txtRatioSecond.Text = string.Empty;
            LoadWithdrawCompanyName();
            cmbDepositCompany.DataSource = null;
        }

        private void LoadWithdrawCompanyName()
        {
            DataTable dt = new DataTable();
            dt = cmnBAL.GetAllCompanyName();
            cmbCompanyName.DataSource = dt;
            cmbCompanyName.DisplayMember = "Company_Name";
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    FPath = openFileDialog1.FileName;
                    txtFilePath.Text = FPath;
                    TextFileProcessToCompany();
                    LoadDepositCompanyName();
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
            DataView view = new DataView(dtCompany);
            DataTable distinctValues = view.ToTable(true, "ISIN");
            string IsinNo = distinctValues.Rows[0][0].ToString();
            DataTable dt = cmnBAL.GetAllCompanyName(IsinNo);
            cmbDepositCompany.DataSource = dt;
            cmbDepositCompany.DisplayMember = "Comp_Name";
        }
        private void TextFileProcessToCompany()
        {
            const char CHARto = '~';
            StreamReader SRToCompany = new StreamReader(FPath);

            if (FPath != string.Empty)
            {
                try
                {
                    if (dtCompany.Columns.Count == 0)
                    {
                        dtCompany.Columns.Add("ISIN");
                        dtCompany.Columns.Add("Company Name");
                        dtCompany.Columns.Add("Sequence No");
                        dtCompany.Columns.Add("Effective Date");
                        dtCompany.Columns.Add("BO ID");
                        dtCompany.Columns.Add("Customer Name");
                        dtCompany.Columns.Add("BO Category");
                        dtCompany.Columns.Add("BO Account Status");
                        dtCompany.Columns.Add("Current Balance");
                        dtCompany.Columns.Add("Lockin Balance");
                        dtCompany.Columns.Add("Proc Flag");
                        //dtCompany.Columns.Add("CL12");
                        dtCompany.Columns.Add("Lock In Exp Date");
                    }
                    //List<String> list = columns.ToList(); // <- to List which is mutable
                    //list.RemoveAt(MY_INT_HERE);           // <- remove 
                    //string[] columns = list.ToArray(); 

                    //var list = new List<string>(strItems);
                    //list.Remove("3");
                    //strItems = list.ToArray();

                    dtCompany.Rows.Clear();
                    while (SRToCompany.Peek() > 0)
                    {
                        string[] Row = SRToCompany.ReadLine().Split(CHARto);

                        var list = new List<string>(Row);
                        list.Remove("           ");
                        Row = list.ToArray();
                        dtCompany.Rows.Add(Row);


                        //string[] Row = SRToCompany.ReadLine().Split(CHARto);                       
                        //dtCompany.Rows.Add(Row);
                    }
                    dgvFileInformation.DataSource = dtCompany;
                    lblCount.Text = Convert.ToString(dgvFileInformation.Rows.Count);
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
            //"Please, Rewrite..."+"\r\n"+"It Exceeds The Existing Balance..."
            //if (MessageBox.Show("Want to Run Deposit Process?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)

            if (MessageBox.Show("Want to Run Deposit Process? Check Items...." + "\r\n" + "\r\n" + "Market Rate : " + txtShareWithdrawRate.Text.Trim() + "" + "\r\n" + "Share Ratio : 1:" + txtRatioSecond.Text.Trim() + "" + "\r\n" + "With Company: " + cmbCompanyName.Text.Trim() + "" + "\r\n" + "Dep. Company: " + cmbDepositCompany.Text.Trim() + "", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                ShareDWBO_Conversion_Collection collectionBO = new ShareDWBO_Conversion_Collection();
                ShareDWBAL BAL = new ShareDWBAL();
                ShareDWBO_Conversion BO = new ShareDWBO_Conversion();

                try
                {
                    collectionBO = ProcessFileData();
                }
                catch
                {
                    MessageBox.Show("File Process Failed...", "Information!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    BAL.CloseDatabase();
                    BAL.ConnectDatabase();
                    BAL.StartTransaction();

                    BAL.Truncate_SBP_ShareDepInfoForConversion();
                    foreach (ShareDWBO_Conversion DW_BO in collectionBO)
                    {
                        BAL.OnlyDeposit_ForConvertion(DW_BO);
                    }
                    BAL.CommitTransaction();
                    //BAL.BulkCopy(dtCompany, "SBP_ShareDepInfoForConversion");

                    MessageBox.Show("Share Deposit Process Completed....", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ErrorManagement();
                }
                catch
                {
                    BAL.RollBackTransaction();
                    MessageBox.Show("Share Deposit Porcess Failed...", "Information!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    BAL.CloseDatabase();
                }
            }
        }
        private void ErrorManagement()
        {
            ShareDWBAL BAL = new ShareDWBAL();
            DataTable dt = BAL.getNullBuyRate();
            if (dt.Rows.Count > 0)
            {
                this.Size = new Size(882, 697);
                pnlErrorInformation.Visible = true;
                dgvErrorInformation.DataSource = dt;
                lblErrorCount.Text = (dgvErrorInformation.Rows.Count).ToString();
            }
            else
            {
                //dgvFileInformation.DataSource = null;
            }

            txtShareWithdrawRate.Text = string.Empty;
            txtRatioSecond.Text = string.Empty;
            cmbDepositCompany.DataSource = null;
            ep1.Clear();
        }
        private ShareDWBO_Conversion_Collection ProcessFileData()
        {
            ShareDWBO_Conversion_Collection CollectionBO = new ShareDWBO_Conversion_Collection();
            DateTime Time = cmnBAL.GetCurrentServerDate_FromDB();

            foreach (DataRow row in dtCompany.Rows)
            {
                DataTable dt = new DataTable();
               
                ShareDWBO_Conversion shareDwbo = new ShareDWBO_Conversion();
                ShareDWBAL shareDwbal = new ShareDWBAL();
                LockInShareBAL lockbal = new LockInShareBAL();

                shareDwbo.BO_ID = (row["BO ID"].ToString().Remove(0, 8));
                shareDwbo.CustCode = shareDwbal.GetCust_CodeByBO_ID(shareDwbo.BO_ID);
                shareDwbo.CustName = row["Customer Name"].ToString();
                string[] sb = row["Current Balance"].ToString().Trim().Split(new char[] { '.' });
                shareDwbo.Quantity = Convert.ToInt32(sb[0]);
                string[] lb = row["Lockin Balance"].ToString().Trim().Split(new char[] { '.' });
                shareDwbo.LockedInQuantity = Convert.ToInt32(lb[0]);
                shareDwbo.AvailableQuantity = shareDwbo.Quantity - shareDwbo.LockedInQuantity;
                shareDwbo.Lockedin_Expiry_Date = Convert.ToDateTime(row["Lock In Exp Date"].ToString());
                //shareDwbo.Quantity = Convert.ToInt32(row["Current Balance"].ToString().Trim());
                shareDwbo.CompanyShortCode = shareDwbal.GetShortCodeByCompanyName(row["Company Name"].ToString());
                // String WithdrawalCompanyShortCode = shareDwbal.GetShortCodeByCompanyName(cmbCompanyName.Text.Trim());
                shareDwbo.OtherCompanyShortCode = shareDwbal.GetShortCodeByCompanyName(cmbCompanyName.Text.Trim());

                shareDwbo.DepositWithdraw = "Deposit";
                shareDwbo.RecordDate = Time.Date;
                shareDwbo.Received_Date = Time.Date;
                shareDwbo.EffectiveDate = Time.Date;
                shareDwbo.DepositType = shareDwbo.CompanyShortCode + "<-" + shareDwbo.OtherCompanyShortCode;
                float MarketPriceByDSE = float.Parse(txtShareWithdrawRate.Text.Trim());
                DataTable dtCommission = new DataTable();
                dtCommission = shareDwbal.GetCommissionRate(shareDwbo.CustCode);
                double CommissionRate = Convert.ToDouble(dtCommission.Rows[0][0].ToString());

                dt = shareDwbal.GetIssuePrice(shareDwbo.CustCode, shareDwbo.OtherCompanyShortCode, CommissionRate, Convert.ToDouble(txtShareWithdrawRate.Text.Trim()));
                if (dt.Rows.Count > 0)
                {
                    shareDwbo.IssueAmount = float.Parse(dt.Rows[0]["WithdrawAmount"].ToString());
                    shareDwbo.IssuePrice = (shareDwbo.IssueAmount / shareDwbo.Quantity);
                }
                string RowDepositShareQty = Convert.ToString(float.Parse(dt.Rows[0]["Matured_Balance"].ToString()) * float.Parse(txtRatioSecond.Text.Trim()));
                string[] a = RowDepositShareQty.Split(new char[] { '.' });
                int DepositShareWQty = Convert.ToInt32(a[0]);
                //string fractureQty = "0";
                if (a.Count() == 2)
                {
                    shareDwbo.DB_FracPoint = float.Parse("." + a[1]);
                }

                if (shareDwbo.IssueAmount > 0)
                {
                    shareDwbo.DB_FractureValue = (shareDwbo.DB_FracPoint * MarketPriceByDSE);
                    //float NetInvestment = (float)Math.Round((shareDwbo.IssueAmount - shareDwbo.DB_FractureValue), 6);
                    //float NewInvestment = (shareDwbo.IssueAmount - shareDwbo.DB_FractureValue);
                    //shareDwbo.IssueAmount = NewInvestment;
                    shareDwbo.IssueAmount = (shareDwbo.IssueAmount - shareDwbo.DB_FractureValue);
                    //shareDwbo.IssueAmount = (float)Math.Round((shareDwbo.IssueAmount - shareDwbo.DB_FractureValue), 2);
                    shareDwbo.IssuePrice = shareDwbo.IssueAmount / shareDwbo.Quantity;
                    //shareDwbo.IssuePrice = ((float)Math.Round((shareDwbo.IssueAmount - shareDwbo.DB_FractureValue), 2) / shareDwbo.Quantity);
                }

                shareDwbo.DB_ShareBalance = Convert.ToInt32(dt.Rows[0]["Matured_Balance"].ToString());

                shareDwbo.DB_ShareAfterRatio = float.Parse(RowDepositShareQty);
                shareDwbo.DB_NewShareRate = shareDwbo.IssuePrice;
                shareDwbo.DB_TotalShareValue = shareDwbo.IssueAmount;
                shareDwbo.DB_NewInvestment = shareDwbo.IssueAmount;

                //shareDwbo.BO_ID = (row["BO ID"].ToString().Remove(0, 8));
                //shareDwbo.CustCode = shareDwbal.GetCust_CodeByBO_ID(shareDwbo.BO_ID);
                //shareDwbo.CompanyShortCode = shareDwbal.GetShortCodeByCompanyName(row["Company Name"].ToString());
                // var RData = dtWithdrawInformation.Select("Cust_Code = '" + shareDwbo.CustCode + @"'");
                //shareDwbo.IssueAmount = float.Parse(RData[0][4].ToString());
                //int DShareQty = Convert.ToInt32(RData[0][5].ToString());
                //shareDwbo.Quantity = DShareQty;
                //shareDwbo.IssuePrice = (shareDwbo.IssueAmount / DShareQty);               
                //shareDwbo.DepositType = shareDwbo.CompanyShortCode + "<-" + shareDwbal.GetShortCodeByCompanyName(cmbCompanyName.Text.Trim());
                //shareDwbo.RecordDate = Time;
                //shareDwbo.Received_Date = Time;
                //shareDwbo.EffectiveDate = Time;
                //shareDwbo.VoucherNo = string.Empty;

                CollectionBO.ADD(shareDwbo);

            }
            return CollectionBO;
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
                    ep1.SetError(cmbCompanyName, "Select Company Name Carefully...");
                }
            }
        }

        private void cmbCompanyName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                btnProcess.Focus();
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

        private void cbIfEqual_CheckedChanged(object sender, EventArgs e)
        {
            if (cbIfEqual.Checked)
            {
                txtRatioSecond.Text = Convert.ToString(1);
                txtRatioSecond.Enabled = false;
                cmbCompanyName.Focus();
                ep1.SetError(cmbCompanyName, "Select Company Name Carefully...");
            }
            else
            {
                txtRatioSecond.Enabled = true;
                txtRatioSecond.Text = string.Empty;
                txtRatioSecond.Focus();
            }
        }
    }
}
