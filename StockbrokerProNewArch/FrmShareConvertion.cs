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

namespace StockbrokerProNewArch
{
    public partial class FrmShareConvertion : Form
    {
        public FrmShareConvertion()
        {
            InitializeComponent();
        }

        string pathFromCompany = string.Empty;
        string pathToCompany = string.Empty;
        DataTable dtFromCompany = new DataTable();
        DataTable dtToCompany = new DataTable();
        CommonBAL cmnBAL = new CommonBAL();

        double SecRatio;
        //int DepositShareWQty = 0;

        private void FrmShareConvertion_Load(object sender, EventArgs e)
        {
            this.Size = new Size(1130, 578);
            pnlError.Visible = false;
            btnSelectFile.Select();
            btnSelectFile.Focus();
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pathFromCompany = openFileDialog1.FileName;
                txtFilepath.Text = pathFromCompany;
                TextFileProcess();

                btnSelectFileToCompany.Focus();
            }
        }

        private bool ProcessValidation()
        {
            double doubleTryParse;

            if (txtFilepath.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please Select File of From Company..", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSelectFile.Focus();
                return true;
            }
            else if (txtFilepath.Text.Trim() != string.Empty & dtFromCompany.Rows.Count <= 0)
            {
                MessageBox.Show("Please Select Correct File of From Company..", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSelectFile.Focus();
                return true;
            }

            else if (txtFilePathToCompany.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please Select File of To Company..", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSelectFileToCompany.Focus();
                return true;
            }
            else if (txtFilePathToCompany.Text.Trim() != string.Empty & dtToCompany.Rows.Count <= 0)
            {
                MessageBox.Show("Please Select Correct File of To Company..", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSelectFileToCompany.Focus();
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

        private void TextFileProcess()
        {
            const char CHAR = '~';
            //DataTable dt = new DataTable();
            StreamReader SR = new StreamReader(pathFromCompany);

            if (pathFromCompany != string.Empty)
            {
                try
                {
                    if (dtFromCompany.Columns.Count == 0)
                    {
                        dtFromCompany.Columns.Add("ISIN");
                        dtFromCompany.Columns.Add("Company Name");
                        dtFromCompany.Columns.Add("BO ID");
                        dtFromCompany.Columns.Add("Custoemr NAME");
                        dtFromCompany.Columns.Add("BO Status");
                        dtFromCompany.Columns.Add("Current Balance");
                        dtFromCompany.Columns.Add("Free Balance");
                        dtFromCompany.Columns.Add("Freeze Balance");
                        dtFromCompany.Columns.Add("Lockin Balance");
                        dtFromCompany.Columns.Add("Pledge Balance");
                        dtFromCompany.Columns.Add("Pending Demat Confirmation");
                        dtFromCompany.Columns.Add("Pending Remat Confirmation");
                        dtFromCompany.Columns.Add("Remlock Balance");
                        dtFromCompany.Columns.Add("Lend Balance");
                        dtFromCompany.Columns.Add("Borrow Balance");
                        dtFromCompany.Columns.Add("Available Lend Balance");
                        dtFromCompany.Columns.Add("Earmark Balance");
                        dtFromCompany.Columns.Add("Elmn Balance");
                        dtFromCompany.Columns.Add("Date");
                    }
                    dtFromCompany.Rows.Clear();
                    while (SR.Peek() >= 0)
                    {
                        string[] Row = SR.ReadLine().Split(CHAR);
                        dtFromCompany.Rows.Add(Row);
                    }
                    dgvLoadFileData.DataSource = dtFromCompany;
                    lblFormCompany.Text = Convert.ToString(dgvLoadFileData.Rows.Count);

                    DataView view = new DataView(dtFromCompany);
                    DataTable distinctValues = view.ToTable(true, "Company Name");
                    cmbFromCompany.DataSource = distinctValues;
                    cmbFromCompany.DisplayMember = "Company Name";
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

        private void btnSelectFileToCompany_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pathToCompany = openFileDialog1.FileName;
                txtFilePathToCompany.Text = pathToCompany;
                TextFileProcessToCompany();

                txtShareWithdrawRate.Focus();
            }
        }
        private void TextFileProcessToCompany()
        {
            const char CHARto = '~';
            //DataTable dt = new DataTable();
            StreamReader SRToCompany = new StreamReader(pathToCompany);

            if (pathToCompany != string.Empty)
            {
                try
                {
                    if (dtToCompany.Columns.Count == 0)
                    {
                        dtToCompany.Columns.Add("ISIN");
                        dtToCompany.Columns.Add("Company Name");
                        dtToCompany.Columns.Add("Sequence No");
                        dtToCompany.Columns.Add("Effective Date");
                        dtToCompany.Columns.Add("BO ID");
                        dtToCompany.Columns.Add("Customer Name");
                        dtToCompany.Columns.Add("BO Category");
                        dtToCompany.Columns.Add("BO Account Status");
                        dtToCompany.Columns.Add("Current Balance");
                        dtToCompany.Columns.Add("Lockin Balance");
                        dtToCompany.Columns.Add("Proc Flag");
                        dtToCompany.Columns.Add("CL12");
                        dtToCompany.Columns.Add("Lock In Exp Date");
                    }

                    dtToCompany.Rows.Clear();
                    while (SRToCompany.Peek() > 0)
                    {
                        string[] Row = SRToCompany.ReadLine().Split(CHARto);
                        dtToCompany.Rows.Add(Row);
                    }
                    dgvToCompany.DataSource = dtToCompany;
                    lblToCompany.Text = Convert.ToString(dgvToCompany.Rows.Count);

                    DataView view = new DataView(dtToCompany);
                    DataTable distinctValues = view.ToTable(true, "Company Name");
                    cmbToCompany.DataSource = distinctValues;
                    cmbToCompany.DisplayMember = "Company Name";
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
     

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (ProcessValidation())
                return;
            
            try
             {
                //PayInTradeBAL ShareProcessBAL = new PayInTradeBAL();
                //ShareProcessBAL.ProcessShareBalance();

                ShareWithdraw();
                ShareDeposit();
                MessageBox.Show("Convertion Process Successful.", "Information...", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private ShareDWBO_Collection ProcessDatatable(DataTable dtFromCompany)
        {
            ShareDWBO_Collection Process_ShareDWBO_Collection = new ShareDWBO_Collection();
            DateTime Time = cmnBAL.GetCurrentServerDate_FromDB();

            foreach (DataRow row in dtFromCompany.Rows)
            {
                if (row["Company Name"].ToString() == cmbFromCompany.Text.Trim())
                {
                    DataTable dt = new DataTable();
                    ShareDWBO shareDwbo = new ShareDWBO();
                    ShareDWBAL shareDwbal = new ShareDWBAL();
                    LockInShareBAL lockbal = new LockInShareBAL();
                    float FloatTryparse;
                    int intTryParse;                    
                    float fractureValue = 0;
                    SecRatio = Convert.ToDouble(txtRatioSecond.Text.Trim());

                    shareDwbo.BO_ID = (row["BO ID"].ToString().Remove(0, 8));
                    shareDwbo.CustCode = shareDwbal.GetCust_CodeByBO_ID((row["BO ID"].ToString()).Remove(0, 8));

                    if (cmbFromCompany.SelectedIndex != -1)
                        shareDwbo.CompanyShortCode = shareDwbal.GetShortCodeByCompanyName(row["Company Name"].ToString());

                    //Check Korte bobe////////////////////////////////////

                    //dt = shareDwbal.GetIssuePrice(shareDwbo.CustCode, shareDwbo.CompanyShortCode);
                    ////if (dt.Rows.Count > 0)
                    ////{
                    //shareDwbo.IssuePrice = float.Parse(dt.Rows[0]["Buy_Rate"].ToString());
                    //shareDwbo.Quantity = Convert.ToInt32(row["Current Balance"].ToString());
                    //shareDwbo.IssueAmount = (shareDwbo.IssuePrice * shareDwbo.Quantity);
                    ////}
                    
                    float MarketPriceByDSE = float.Parse(txtShareWithdrawRate.Text.Trim());
                    string RowDepositShareQty = Convert.ToString(shareDwbo.Quantity * SecRatio);
                    string[] a = RowDepositShareQty.Split(new char[] { '.' });
                    int DepositShareWQty = Convert.ToInt32(a[0]);
                    string fractureQty = "." + a[1];
                    if (shareDwbo.IssueAmount > 0)
                    {
                        shareDwbo.FracValue = (float.Parse(fractureQty) * MarketPriceByDSE);
                        float NetInvestment = (shareDwbo.IssueAmount - shareDwbo.FracValue);
                        shareDwbo.IssueAmount = NetInvestment;
                        shareDwbo.IssuePrice = (shareDwbo.IssueAmount / shareDwbo.Quantity);
                    }

                    shareDwbo.DepositWithdraw = "Withdraw";
                    shareDwbo.DepositType = "Con.("+ shareDwbo.CompanyShortCode + "->" + shareDwbal.GetShortCodeByCompanyName(cmbToCompany.Text.Trim()) + ")";
                    shareDwbo.RecordDate = Time;
                    shareDwbo.Received_Date = Time;
                    shareDwbo.EffectiveDate = Time;
                    shareDwbo.VoucherNo = string.Empty;

                    Process_ShareDWBO_Collection.ADD(shareDwbo);
                }
            }
            return Process_ShareDWBO_Collection;
        }
        private void ShareWithdraw()
        {
            ShareDWBO_Collection CollectionBo = new ShareDWBO_Collection();
            ShareDWBAL shareDwbal = new ShareDWBAL();
           //RatioFinal = Convert.ToDouble(txtRatioSecond.Text.Trim());

            try
            {
                CollectionBo = ProcessDatatable(dtFromCompany);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Process Failed Due to " + ex + "");
                return;
            }

            foreach (ShareDWBO dwBO in CollectionBo)
            {
                //const char CHARto = '~';
                //string cCode = dwBO.CustCode;
                //string BOid = dwBO.BO_ID;
                //string ShCode = dwBO.CompanyShortCode;
                //int WithdrawalShareQty = dwBO.Quantity;
                //float IssuePrice = dwBO.IssuePrice;
                //float MarketPriceByDSE = float.Parse(txtShareWithdrawRate.Text.Trim());
                //float TotaAmt = dwBO.IssueAmount;
                //float fractureValue = 0;

                //SecRatio = Convert.ToDouble(txtRatioSecond.Text.Trim());

                string RowDepositShareQty = Convert.ToString(dwBO.Quantity * SecRatio);
                string[] a = RowDepositShareQty.Split(new char[] { '.' });
                int DepositShareWQty = Convert.ToInt32(a[0]);
                //string fractureQty = "." + a[1];
                //if (TotaAmt > 0)
                //{
                //    fractureValue = (float.Parse(fractureQty) * MarketPriceByDSE);
                //}
                //float NetInvestment = (TotaAmt - fractureValue);

                try
                {
                    shareDwbal.WithdrawForConvertion(dwBO);
                    AddToDataTableWithWithdrawInformation(dwBO.CustCode
                                                        , dwBO.BO_ID
                                                        , dwBO.CompanyShortCode
                                                        , dwBO.Quantity
                                                        , dwBO.IssueAmount
                                                        , DepositShareWQty
                                                        , dwBO.FracValue);
                }
                catch (Exception ex)
                {
                    AddErrorMessageInGridView(dwBO.CustCode, dwBO.BO_ID, ex.Message);
                }
            }
           
            if (dgvErro.Rows.Count > 0)
            {
                this.Size = new Size(1130, 695);
                pnlError.Visible = true;
            }
        }
        private ShareDWBO_Collection ProcessDataTableToCompany()
        {
            ShareDWBO_Collection CollectionBO = new ShareDWBO_Collection();
            DateTime Time = cmnBAL.GetCurrentServerDate_FromDB();

            foreach (DataRow row in dtToCompany.Rows)
            {
                if (row["Company Name"].ToString() == cmbToCompany.Text.Trim())
                {
                    DataTable dt = new DataTable();
                    ShareDWBO shareDwbo = new ShareDWBO();
                    ShareDWBAL shareDwbal = new ShareDWBAL();
                    LockInShareBAL lockbal = new LockInShareBAL();

                    DataRow[] CheckExistance = dtWithdrawInformation.Select("Cust_Code='" + shareDwbal.GetCust_CodeByBO_ID((row["BO ID"].ToString().Remove(0, 8))) + @"'");
                    if (CheckExistance.Length == 1)
                    {
                        shareDwbo.BO_ID = (row["BO ID"].ToString().Remove(0, 8));
                        shareDwbo.CustCode = shareDwbal.GetCust_CodeByBO_ID(shareDwbo.BO_ID);
                        if (cmbToCompany.SelectedIndex != -1)
                            shareDwbo.CompanyShortCode = shareDwbal.GetShortCodeByCompanyName(row["Company Name"].ToString());
                        var RData = dtWithdrawInformation.Select("Cust_Code = '" + shareDwbo.CustCode + @"'");
                        shareDwbo.IssueAmount = float.Parse(RData[0][4].ToString());
                        int DShareQty = Convert.ToInt32(RData[0][5].ToString());
                        shareDwbo.Quantity = DShareQty;
                        shareDwbo.IssuePrice = (shareDwbo.IssueAmount / DShareQty);
                        shareDwbo.DepositWithdraw = "Deposit";
                        //shareDwbo.DepositType = shareDwbal.GetShortCodeByCompanyName(cmbToCompany.Text.Trim()) + "<-" + shareDwbo.CompanyShortCode;
                        //"Con.("+ shareDwbo.CompanyShortCode + "->" + shareDwbal.GetShortCodeByCompanyName(cmbToCompany.Text.Trim()) + ")";
                        shareDwbo.DepositType = "Con.(" + shareDwbo.CompanyShortCode + "<-" + shareDwbal.GetShortCodeByCompanyName(cmbFromCompany.Text.Trim()) + ")";
                        shareDwbo.RecordDate = Time;
                        shareDwbo.Received_Date = Time;
                        shareDwbo.EffectiveDate = Time;
                        shareDwbo.VoucherNo = string.Empty;

                        CollectionBO.ADD(shareDwbo);
                    }
                }             
            }
            return CollectionBO;
        }

        private void ShareDeposit()
        {
            ShareDWBO_Collection CollectionBO = new ShareDWBO_Collection();
            ShareDWBAL shareDwBAL = new ShareDWBAL();

            try
            {
                CollectionBO = ProcessDataTableToCompany();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Process Failed Due to " + ex + "");
                return;
            }
            foreach (ShareDWBO dwBO in CollectionBO)
            {

                //bool exists = dtWithdrawInformation.Select().ToList().Exists(row => row["BO_ID"].ToString().ToUpper() == "" + dwBO.BO_ID + @"");
                
                //if (exists)
                //{
                    try
                   {
                        shareDwBAL.DepositForConvertion(dwBO);
                        //AddToDataTableWithWithdrawInformation(cCode, BOid, ShCode, WithdrawalShareQty, TotaAmt, DepositShareWQty, fractureValue);
                    }
                    catch (Exception ex)
                    {
                        // AddErrorMessageInGridView(cCode, BOid, ex.Message);
                    }

                //}
                //else
                //{

                //}
            }
        }

        DataTable dtWithdrawInformation = new DataTable();
        private void AddToDataTableWithWithdrawInformation(string cCode, string BOid, string ShCode, int Qty, float TotaAmt, int DepositShareWQty, float fractureValue)
        {
            if (dtWithdrawInformation.Rows.Count == 0)
            {
                dtWithdrawInformation.Columns.Add("Cust_Code");
                dtWithdrawInformation.Columns.Add("BO_ID");
                dtWithdrawInformation.Columns.Add("Short_Code");
                dtWithdrawInformation.Columns.Add("WithdrawShareQty");
                dtWithdrawInformation.Columns.Add("Total_Amount");
                //dtWithdrawInformation.Columns.Add("NetInvestment");
                dtWithdrawInformation.Columns.Add("DepositShareQty");
                dtWithdrawInformation.Columns.Add("FractureValue");
            }
            dtWithdrawInformation.Rows.Add(cCode, BOid, ShCode, Qty, TotaAmt, DepositShareWQty, fractureValue);
        }

        private void AddErrorMessageInGridView(string cust_Code, string BO_ID, string Message)
        {
            string[] rowString = new string[] { (dgvErro.Rows.Count + 1).ToString(), cust_Code, BO_ID, Message };
            dgvErro.Rows.Add(rowString);
        }

      

        private void cbIfEqual_CheckedChanged(object sender, EventArgs e)
        {
            if (cbIfEqual.Checked)
            {
                txtRatioSecond.Text = Convert.ToString(1);
                txtRatioSecond.Enabled = false;
                btnProcess.Focus();
            }
            else
            {
                txtRatioSecond.Text = string.Empty;
                txtRatioSecond.Enabled = true;
                txtRatioSecond.Focus();
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
                    btnProcess.Focus();
                }
            }
        }

        private void txtShareWithdrawRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                txtRatioSecond.Focus();
            }
        }
    }
}
