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
using BusinessAccessLayer.Constants.Indication_Reports;
using System.Reflection;
using DataAccessLayer;
using System.Drawing.Imaging;

namespace StockbrokerProNewArch
{
    public partial class frmExpenseTransaction : Form
    {
        private DbConnection _dbConnection = new DbConnection();
        public string Bank_Name;
        public string Check_No;
        public string Check_Date;
        public string Bank_AccNo;
        public string Bank_ID_No;
        public string Account_Purpose;

        private Image _image;
        private string type_Category_Expense = "type_Category_Expense";
        private bool _call_From_Expense = false;
        private bool _call_From_CategoryName = false;

        private bool _zeroIndex_Forwarded_ForExpense = false;
        private bool _zeroIndex_Forwarded_ForCategoryName = false;
        private bool _zeroIndex_Forwarded_ForCategoryType = false;

        private int _TransIdForDelete;

        private Dictionary<string, object> ExpenseTransaction_Cache = new Dictionary<string, object>();
        private enum FormMode { DefaultMode, DailyMode, MonthlyMode, YearlyMode, HalfYearlyMode };


        private List<string> PrevilizePaymentType = new List<string>();
        private readonly PaymentMethods payTypeObj = new PaymentMethods { Cash = "Cash", Cheque = "Cheque" };
        private enum PaymentMedia { Cash, Cheque };

        private struct PaymentMethods
        {
            public string Cash;
            public string Cheque;
        };

        private ExpenseTransactionBAL expbal = new ExpenseTransactionBAL();
        private string NextCityID()
        {
            DataTable dt = new DataTable();
            string queryString = @"select isnull(max(cast(City_ID as numeric)),0)+1 from [BankBook].[dbo].[CityBankBook]";

            dt = expbal.Get_Data(queryString);
            return (dt.Rows[0][0].ToString());
        }
        public string GroupNextID()
        {
            DataTable dt = new DataTable();
            string queryString = "select isnull(max(cast(GroupID as numeric)),0)+1 from [BankBook].[dbo].[CityBankBook]";

            dt = expbal.Get_Data(queryString);
            return (dt.Rows[0][0].ToString());
        }

        public frmExpenseTransaction()
        {
            InitializeComponent();
        }
        //--------------Relation Between Catagories--------------------
        //SELECT * FROM SBP_Expense_Category_Type
        //SELECT * FROM SBP_Expense_Category_Lookup
        //SELECT * FROM SBP_Expense_Lookup

        private void frmExpenseTransaction_Load(object sender, EventArgs e)
        {
            FormLoad();
            showExistingBalance();
        }

        private void showExistingBalance()
        {
            if (cmbPaymentType.Text == "Cash")
            {
                DataTable dtAccTransaction = new DataTable();
                DataTable dtUnapprovedExpense = new DataTable();
                double unApprovedBalance;
                string query = @"select SUM(DrAmt-CrAmt) from AccTransaction as at
                                group by at.Branch_ID
                                having Branch_ID=" + GlobalVariableBO._branchId + "";
                string query1 = @"select isnull(SUM(Amount),0) as balance from SBP_Expense_Transaction
                                where Branch_ID=" + GlobalVariableBO._branchId + @" and Approval_Status=0
                                group by Approval_Status";
                dtAccTransaction = expbal.Get_Data(query);
                dtUnapprovedExpense = expbal.Get_Data(query1);

                if (dtAccTransaction.Rows.Count == 1 && dtUnapprovedExpense.Rows.Count == 1)
                {
                    unApprovedBalance = (Convert.ToDouble(dtAccTransaction.Rows[0][0].ToString())) - (Convert.ToDouble(dtUnapprovedExpense.Rows[0][0].ToString()));
                    lblEBalance.Text = unApprovedBalance.ToString();
                }
                else if (dtAccTransaction.Rows.Count == 1 && dtUnapprovedExpense.Rows.Count == 0)
                {
                    unApprovedBalance = (Convert.ToDouble(dtAccTransaction.Rows[0][0].ToString()));
                    lblEBalance.Text = unApprovedBalance.ToString();
                }
                    //////////////////////////////////////////////
                else if (dtAccTransaction.Rows.Count == 0 && dtUnapprovedExpense.Rows.Count == 1)
                {
                    unApprovedBalance = (Convert.ToDouble(dtUnapprovedExpense.Rows[0][0].ToString()))*-1;
                    lblEBalance.Text = unApprovedBalance.ToString();
                }
                    ///////////////////////////////////////////////
                else
                {
                    lblEBalance.Text = "0.00";
                }
            }
            else if (cmbPaymentType.Text == "Cheque")
            {
                DataTable dt = new DataTable();
                double IndividualBankBalance;
                string queryBankBalance = @"select SUM(DebitAmount-CrediteAmount) 
                                            from BankBook.dbo.TranactionApprovedata
                                            where BankId=" + Bank_ID_No + " and StatusforDelation='A'";
                dt = expbal.Get_Data(queryBankBalance);
                if (dt.Rows.Count == 1)
                {
                    IndividualBankBalance = Convert.ToDouble(dt.Rows[0][0].ToString());
                    lblEBalance.Text = IndividualBankBalance.ToString();
                }
                else
                {
                    lblEBalance.Text = "0.00";
                }
            }
        }
        private void cmbPaymentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPaymentType.Text == "Cheque")
            {
                FrmPopup frm = new FrmPopup();
                this.Hide();
                frm.Show();
            }
            else 
            {
                cmbPaymentType.Focus();
                gbCheckInformation.Visible = false;
                lblBankIDNo.Visible = false;
                lblAccountPurpose.Visible = false;


                lblBankName.Text = "";
                lblCheckNo.Text = "";
                lblCheckDate.Text = "";
                lblBank_accNo.Text = "";
                lblBankIDNo.Text = "";
                lblAccountPurpose.Text = "";
                setCheck();
                showExistingBalance();
            }
            
        }
        private void ddlPaymentType_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (cmbPaymentType.Text == "Cash")
            {
                lblEBalance.Visible = true;
            }
            else
            {

            }
            if (cmbPaymentType.Text == "Cheque")
            {
                label32.Visible = false;
                lblEBalance.Visible = false;
                FrmPopup frm = new FrmPopup();
                this.Hide();
                frm.Show();
            }

            else
            {
                lblEBalance.Visible = true;
            }
        }

        private void FormLoad()
        {
            cmbPaymentType.Focus();
            gbCheckInformation.Visible = false;
            lblBankIDNo.Visible = false;
            lblAccountPurpose.Visible = false;

            LoadComboData();
            LoadCacheData();
            LoadDataIntoGrid();
            LoadPaymentType();

            lblBankName.Text = Bank_Name;
            lblCheckNo.Text = Check_No;
            lblCheckDate.Text = Check_Date;
            lblBank_accNo.Text = Bank_AccNo;
            lblBankIDNo.Text = Bank_ID_No;
            lblAccountPurpose.Text = Account_Purpose;
            setCheck();
        }

        private DataTable loadLable()
        {
            DataTable dt = new DataTable();
            string queryString = @"select BankName FROM [BankBook].[dbo].[BankInfo] where BankAcc='" + Check_No + "'";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ExecuteQuery(queryString);
            }
            catch
            {
                throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dt;
        }

        private void setCheck()
        {
            if (lblBankName.Text != "")
            {
                cmbPaymentType.SelectedIndex = 1;
                ddlExpenseName.Focus();
                gbCheckInformation.Visible = true;
            }
            else
            {
                cmbPaymentType.SelectedIndex = 0;
            }
        }

        private void LoadPaymentType()
        {
            FieldInfo[] paymentTypeFields = payTypeObj.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public);
            foreach (FieldInfo field in paymentTypeFields)
            {
                PrevilizePaymentType.Add(field.GetValue(payTypeObj).ToString());
            }

            if (PrevilizePaymentType.Count > 0)
            {
                foreach (string pMedia in PrevilizePaymentType)
                {
                    cmbPaymentType.Items.Add(pMedia);
                }
            }

        }

        private void LoadCacheData()
        {
            ExpenseTransactionBAL expenseTransactionBAL = new ExpenseTransactionBAL();
            DataTable dtCache = new DataTable();
            IEnumerable<DataRow> query = expenseTransactionBAL.GetTypeCategoryExpenseData().AsEnumerable().ToList()
                .Where(t => t["Expense_ID"] != DBNull.Value &&
                           t["Category_Type_ID"] != DBNull.Value &&
                           t["Category_ID"] != DBNull.Value
                      );
            if (query.Count() > 0)
            {
                dtCache = query.CopyToDataTable<DataRow>();
            }

            ExpenseTransaction_Cache.Add(type_Category_Expense, dtCache);

            #region
            //var Category_type = (ExpenseTransaction_Cache.Where(t => t.Key ==type_Category_Expense)
            //                    .Select(t => t.Value).SingleOrDefault() as DataTable).AsEnumerable()
            //                    .Select(t => new { Key = t["Category_Type_ID"], Value = t["Category_Type"] }).GroupBy(t => t.Key)
            //                    .Select(g => new KeyValuePair<int,string>(Convert.ToInt32(g.Key), Convert.ToString(g.Max(t => t.Value)))).ToList();


            //Category_type.Insert(0,(new KeyValuePair<int, string>(0,"Select Data")));
            //ddlCategoryType.ValueMember = "Key";
            //ddlCategoryType.DisplayMember = "Value";
            //ddlCategoryType.DataSource = Category_type.ToList();

            //var Category = (ExpenseTransaction_Cache.Where(t => t.Key == type_Category_Expense)
            //                    .Select(t => t.Value).SingleOrDefault() as DataTable).AsEnumerable()
            //                    .Select(t => new { Key = t["Category_ID"], Value = t["Category_Name"] }).GroupBy(t => t.Key)
            //                    .Select(g => new KeyValuePair<int, string>(Convert.ToInt32(g.Key), Convert.ToString(g.Max(t => t.Value)))).ToList();


            //Category.Insert(0, (new KeyValuePair<int, string>(0, "Select Data")));
            //ddlCategoryName.ValueMember = "Key";
            //ddlCategoryName.DisplayMember = "Value";
            //ddlCategoryName.DataSource = Category.ToList();
            #endregion         
            var Expense = (ExpenseTransaction_Cache.Where(t => t.Key == type_Category_Expense)
                                .Select(t => t.Value).SingleOrDefault() as DataTable).AsEnumerable().Where(t => t["Expense_ID"] != DBNull.Value)// || t["Category_Type_ID"] != DBNull.Value || t["Category_ID"] != DBNull.Value)
                                .Select(t => new { Key = t["Expense_ID"], Value = t["Expense_Description"] }).GroupBy(t => t.Key)
                                .Select(g => new KeyValuePair<int, string>(Convert.ToInt32(g.Key), Convert.ToString(g.Max(t => t.Value)))).ToList();


            Expense.Insert(0, (new KeyValuePair<int, string>(0, "Please Select an Item")));
            ddlExpenseName.ValueMember = "Key";
            ddlExpenseName.DisplayMember = "Value";
            ddlExpenseName.DataSource = Expense.ToList();
        }

        private void LoadComboData()
        {
            ExpenseTransactionBAL expenseTransactionBAL = new ExpenseTransactionBAL();
            DataTable dtCategory = new DataTable();
            DataTable dtExpense = new DataTable();
            DataTable dtCategoryType = new DataTable();
            DataTable dtUsers = new DataTable();
            //DataTable dtSubCategory = new DataTable();

            //dtSubCategory = expenseTransactionBAL.GetSubCategoryName();

            dtCategory = expenseTransactionBAL.GetCategory();
            dtExpense = expenseTransactionBAL.GetExpense();
            dtCategoryType = expenseTransactionBAL.GetAllCategoryType();
            dtUsers = expenseTransactionBAL.GetUsers();
            ddlCategoryType.ValueMember = dtCategoryType.Columns[0].ToString();
            ddlCategoryType.DisplayMember = dtCategoryType.Columns[1].ToString();
            ddlCategoryName.DataSource = dtCategory;
            ddlCategoryName.ValueMember = dtCategory.Columns[0].ToString();
            ddlCategoryName.DisplayMember = dtCategory.Columns[1].ToString();
            ddlPurchaserEmp.ValueMember = dtUsers.Columns[0].ToString();
            ddlPurchaserEmp.DisplayMember = dtUsers.Columns[1].ToString();
            DataRow drExpenseCategory = dtCategory.NewRow();
            DataRow drCategoryType = dtCategoryType.NewRow();
            DataRow drPuchaseEmployee = dtUsers.NewRow();
            drExpenseCategory[0] = 0;
            drExpenseCategory[1] = "Please Select an Item";
            dtCategory.Rows.InsertAt(drExpenseCategory, 0);
            drCategoryType[0] = 0;
            drCategoryType[1] = "Please Select an Item";
            dtCategoryType.Rows.InsertAt(drCategoryType, 0);
            drPuchaseEmployee[0] = 0;
            drPuchaseEmployee[1] = "Please Select An Item";
            dtUsers.Rows.InsertAt(drPuchaseEmployee, 0);
            ddlCategoryType.DataSource = null;
            ddlCategoryName.DataSource = null;
            ddlPurchaserEmp.DataSource = null;
            ddlCategoryType.DataSource = dtCategoryType;
            ddlCategoryName.DataSource = dtCategory;
            ddlPurchaserEmp.DataSource = dtUsers;
        }

        private void FormModeExecution(FormMode fm)
        {
            DateTime processed_ExpenseDate;
            switch (fm)
            {
                case FormMode.DefaultMode:
                    dtpExpenseDate.CustomFormat = "dd-MMM-yyyy";
                    dtSearchDate.CustomFormat = "dd-MMM-yyyy";
                    ddlCategoryType.Enabled = false;
                    ddlCategoryName.Enabled = false;
                    break;
                case FormMode.DailyMode:
                    dtpExpenseDate.CustomFormat = "dd-MMM-yyyy";
                    dtSearchDate.CustomFormat = "dd-MMM-yyyy";
                    ddlCategoryType.Enabled = false;
                    ddlCategoryName.Enabled = false;
                    dtSearchDate.Value = dtpExpenseDate.Value;
                    break;
                case FormMode.MonthlyMode:
                    dtpExpenseDate.CustomFormat = "MMM-yyyy";
                    dtSearchDate.CustomFormat = "MMM-yyyy";
                    processed_ExpenseDate = new DateTime(dtpExpenseDate.Value.Year, dtpExpenseDate.Value.Month, DateTime.DaysInMonth(dtpExpenseDate.Value.Year, dtpExpenseDate.Value.Month));
                    dtpExpenseDate.Value = processed_ExpenseDate;
                    processed_ExpenseDate = new DateTime(dtSearchDate.Value.Year, dtSearchDate.Value.Month, DateTime.DaysInMonth(dtSearchDate.Value.Year, dtSearchDate.Value.Month));
                    dtSearchDate.Value = processed_ExpenseDate;
                    ddlCategoryType.Enabled = false;
                    ddlCategoryName.Enabled = false;
                    break;
                case FormMode.YearlyMode:
                    dtpExpenseDate.CustomFormat = "yyyy";
                    dtSearchDate.CustomFormat = "yyyy";
                    processed_ExpenseDate = new DateTime(dtpExpenseDate.Value.Year, 12, 31);
                    dtpExpenseDate.Value = processed_ExpenseDate;
                    processed_ExpenseDate = new DateTime(dtSearchDate.Value.Year, 12, 31);
                    dtSearchDate.Value = processed_ExpenseDate;
                    ddlCategoryType.Enabled = false;
                    ddlCategoryName.Enabled = false;
                    break;
                case FormMode.HalfYearlyMode:
                    dtpExpenseDate.CustomFormat = "MMM-yyyy";
                    dtSearchDate.CustomFormat = "MMM-yyyy";
                    if (dtpExpenseDate.Value.Month > 6)
                        processed_ExpenseDate = new DateTime(dtpExpenseDate.Value.Year, 12, 31);
                    else
                        processed_ExpenseDate = new DateTime(dtpExpenseDate.Value.Year, 06, 30);
                    dtpExpenseDate.Value = processed_ExpenseDate;

                    if (dtpExpenseDate.Value.Month > 6)
                        processed_ExpenseDate = new DateTime(dtSearchDate.Value.Year, 12, 31);
                    else
                        processed_ExpenseDate = new DateTime(dtSearchDate.Value.Year, 06, 30);
                    dtSearchDate.Value = processed_ExpenseDate;
                    ddlCategoryType.Enabled = false;
                    ddlCategoryName.Enabled = false;
                    break;
            }
        }

        private void btnBrowseLogo_Click(object sender, EventArgs e)
        {
            if (ofdVoucher.ShowDialog() != DialogResult.Cancel)
            {
                txtLogoPath.Text = ofdVoucher.FileName;
                _image = Image.FromFile(txtLogoPath.Text);
                picVouchar.Image = _image;
                //SendKeys.Send("{TAB}");
                txtRemarks.Focus();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetField();
            showExistingBalance();
        }
        private void ResetField()
        {
            CommonBAL objBal = new CommonBAL();
            txtLogoPath.Text = "";
            txtVoucherNo.Text = "";
            _image = null;
            picVouchar.Image = null;
            ddlCategoryType.SelectedIndex = 0;
            ddlPurchaserEmp.SelectedIndex = -1;
            ddlExpenseName.SelectedIndex = 0;
            ddlCategoryName.SelectedIndex = 0;
            dtpExpenseDate.Value = objBal.GetCurrentServerDate();
            dtpPaymentDate.Value = objBal.GetCurrentServerDate();
            txtAmount.Text = string.Empty;
            txtQuantity.Text = string.Empty;
            txtVoucherNo.Text = string.Empty;
            txtRemarks.Text = string.Empty;

            lblBankName.Text = null;
            lblCheckNo.Text = null;
            lblCheckDate.Text = null;
            lblBank_accNo.Text = null;
            lblBankIDNo.Text = null;
            lblAccountPurpose.Text = null;
            gbCheckInformation.Visible = false;
        }

        private void ResetField_AfterSave()
        {
            txtLogoPath.Text = "";
            txtVoucherNo.Text = "";
            _image = null;
            picVouchar.Image = null;
            ddlCategoryType.SelectedIndex = 0;
            ddlPurchaserEmp.SelectedIndex = -1;
            //ddlExpenseName.SelectedIndex = 0;
            ddlCategoryName.SelectedIndex = 0;
            //dtpExpenseDate.Value = DateTime.Today;
            //dtpPaymentDate.Value = DateTime.Today;
            txtAmount.Text = string.Empty;
            txtQuantity.Text = string.Empty;
            txtVoucherNo.Text = string.Empty;
            txtRemarks.Text = string.Empty;

            lblBankName.Text = null;
            lblCheckNo.Text = null;
            lblCheckDate.Text = null;
            lblBank_accNo.Text = null;
            lblBankIDNo.Text = null;
            lblAccountPurpose.Text = null;
            gbCheckInformation.Visible = false;

            txtRate.Text = "";

        }
        private void btnSave_Click(object sender, EventArgs e)
        {

            if (Validation())
                return;

            if (cmbPaymentType.Text == "Cheque")
            {
                saveCheckInfo();
                cmbPaymentType.SelectedIndex = 0;
            }
            else
            {
                if (Convert.ToInt32(ddlExpenseName.SelectedValue.ToString()) > 0)
                {
                    SaveExpenseInfo();
                    showExistingBalance();
                }
                else
                {
                    MessageBox.Show("Please Select Expense Name.");
                }
                
            }
        }

        private bool Validation()
        {
            if (ddlExpenseName.Text == "Please Select an Item")
            {
                MessageBox.Show("Please Select Expense Name.", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ddlExpenseName.Focus();
                return true;
            }
            else if (txtAmount.Text == "" || txtAmount.Text == "0")
            {
                MessageBox.Show("Please Insurt Amount.", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAmount.Focus();
                return true;
            }
            else if (txtVoucherNo.Text == "")
            {
                MessageBox.Show("Please Enter Voucher No.", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtVoucherNo.Focus();
                return true;
            }            
            else return false;
        }

        private ExpenseTransBO InitiallizeBO()
        {
            string sID = "";
            ExpenseTransBO expenseTransBO = new ExpenseTransBO();
            expenseTransBO.Expense_ID = Convert.ToInt32(ddlExpenseName.SelectedValue.ToString());
            expenseTransBO.Category_ID = Convert.ToInt32(ddlCategoryName.SelectedValue.ToString());

            if (cmbSubCategory.SelectedValue == null)
            {
                expenseTransBO.sub_catagory_ID = 0;
            }
            else
            {
                sID = (cmbSubCategory.SelectedValue.ToString());
                if(!string.IsNullOrEmpty(sID))
                    expenseTransBO.sub_catagory_ID=Convert.ToInt32(sID);
                else
                  expenseTransBO.sub_catagory_ID = 0; 
            }

            expenseTransBO.Expense_Date = dtpExpenseDate.Value;
            expenseTransBO.Payment_Date = dtpPaymentDate.Value;
            expenseTransBO.Payment_Media = "Cash";
            expenseTransBO.Pay_Bank_Name = "";
            expenseTransBO.Bank_Account_No = "";
            expenseTransBO.Pay_Cheque_No = "";
            expenseTransBO.Branch_ID = GlobalVariableBO._branchId;
            expenseTransBO.Amount = Convert.ToDouble((txtAmount.Text.Trim() == string.Empty) ? "0" : txtAmount.Text.Trim());
            expenseTransBO.Qquantity = txtQuantity.Text == "" ? 0 : Convert.ToInt32(txtQuantity.Text);
            expenseTransBO.Rate = txtRate.Text == "" ? 0 : Convert.ToDouble(txtRate.Text);
            expenseTransBO.Voucher_No = txtVoucherNo.Text;
            expenseTransBO.Approval_Status = 0;
            expenseTransBO.Approved_By = string.Empty;
            expenseTransBO.Remarks = txtRemarks.Text.Trim();
            if (txtLogoPath.Text.Trim() != "")
                expenseTransBO.Voucher_Image = GetImageBytes(txtLogoPath.Text);

            return expenseTransBO;
        }

        private ExpenseTransBO InitiallizeBOForCheque()
        {
            ExpenseTransBO expenseTransBO = new ExpenseTransBO();
            expenseTransBO.Expense_ID = Convert.ToInt32(ddlExpenseName.SelectedValue.ToString());
            expenseTransBO.Category_ID = Convert.ToInt32(ddlCategoryName.SelectedValue.ToString());

            if (cmbSubCategory.DataSource == null)
            {
                expenseTransBO.sub_catagory_ID = 0;
            }
            else
            {
                if(!string.IsNullOrEmpty(cmbSubCategory.Text))
                   expenseTransBO.sub_catagory_ID = Convert.ToInt32(cmbSubCategory.SelectedValue.ToString());
            }

            expenseTransBO.Expense_Date = dtpExpenseDate.Value;
            expenseTransBO.Payment_Date = dtpPaymentDate.Value;
            expenseTransBO.Payment_Media = cmbPaymentType.Text;
            expenseTransBO.Pay_Bank_Name = lblBankName.Text;
            expenseTransBO.Bank_Account_No = lblBank_accNo.Text;
            expenseTransBO.Pay_Cheque_No = lblCheckNo.Text;
            expenseTransBO.Branch_ID = GlobalVariableBO._branchId;
            expenseTransBO.Amount = Convert.ToDouble((txtAmount.Text.Trim() == string.Empty) ? "0" : txtAmount.Text.Trim());
            expenseTransBO.Qquantity = txtQuantity.Text == "" ? 0 : Convert.ToInt32(txtQuantity.Text);
            expenseTransBO.Rate = txtRate.Text == "" ? 0 : Convert.ToDouble(txtRate.Text);
            expenseTransBO.Voucher_No = txtVoucherNo.Text;
            expenseTransBO.Approval_Status = 0;
            expenseTransBO.Approved_By = string.Empty;
            expenseTransBO.Remarks = txtRemarks.Text.Trim();
            if (txtLogoPath.Text.Trim() != "")
                expenseTransBO.Voucher_Image = GetImageBytes(txtLogoPath.Text);
            return expenseTransBO;
        }
        private void saveCheckInfo()
        {
            ExpenseTransBO expenseTransBO = new ExpenseTransBO();
            ExpenseTransactionBAL expenseTransactionBAL = new ExpenseTransactionBAL();

            int selected_ExpenseName = Convert.ToInt32(ddlExpenseName.SelectedValue);
            string frequencyName = expenseTransactionBAL.GetExpenseFrequency(selected_ExpenseName);
            DateTime processed_ExpenseDate = dtpExpenseDate.Value;
            if (frequencyName == Indication_ExpenseReports.Expense_Frequency_Monthly)
                processed_ExpenseDate = new DateTime(dtpExpenseDate.Value.Year, dtpExpenseDate.Value.Month, DateTime.DaysInMonth(dtpExpenseDate.Value.Year, dtpExpenseDate.Value.Month));
            else if (frequencyName == Indication_ExpenseReports.Expense_Frequency_Yearly)
                processed_ExpenseDate = new DateTime(dtpExpenseDate.Value.Year, 12, 31);
            else if (frequencyName == Indication_ExpenseReports.Expense_Frequency_HalfYearly)
            {
                if (dtpExpenseDate.Value.Month > 6)
                    processed_ExpenseDate = new DateTime(dtpExpenseDate.Value.Year, 12, 31);
                else
                    processed_ExpenseDate = new DateTime(dtpExpenseDate.Value.Year, 06, 30);
            }
            dtpExpenseDate.Value = processed_ExpenseDate;
            expenseTransBO = InitiallizeBOForCheque();
            expenseTransactionBAL.SaveExpenseTransaction(expenseTransBO);   //saveCheckInfoForExpenseSave
            MessageBox.Show("Expense Info successfully saved. ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ResetField_AfterSave();
            //FormLoad();
            //SendKeys.Send("{TAB}");
        }

        private void SaveExpenseInfo()
        {
            try
            {
                ExpenseTransBO expenseTransBO = new ExpenseTransBO();
                ExpenseTransactionBAL expenseTransactionBAL = new ExpenseTransactionBAL();

                int selected_ExpenseName = Convert.ToInt32(ddlExpenseName.SelectedValue);
                string frequencyName = expenseTransactionBAL.GetExpenseFrequency(selected_ExpenseName);
                DateTime processed_ExpenseDate = dtpExpenseDate.Value;
                if (frequencyName == Indication_ExpenseReports.Expense_Frequency_Monthly)
                    processed_ExpenseDate = new DateTime(dtpExpenseDate.Value.Year, dtpExpenseDate.Value.Month, DateTime.DaysInMonth(dtpExpenseDate.Value.Year, dtpExpenseDate.Value.Month));
                else if (frequencyName == Indication_ExpenseReports.Expense_Frequency_Yearly)
                    processed_ExpenseDate = new DateTime(dtpExpenseDate.Value.Year, 12, 31);
                else if (frequencyName == Indication_ExpenseReports.Expense_Frequency_HalfYearly)
                {
                    if (dtpExpenseDate.Value.Month > 6)
                        processed_ExpenseDate = new DateTime(dtpExpenseDate.Value.Year, 12, 31);
                    else
                        processed_ExpenseDate = new DateTime(dtpExpenseDate.Value.Year, 06, 30);
                }

                dtpExpenseDate.Value = processed_ExpenseDate;
                expenseTransBO = InitiallizeBO();
               
                expenseTransactionBAL.SaveExpenseTransaction(expenseTransBO);

                ResetField_AfterSave();
                //FormLoad();
                MessageBox.Show("Expense Info successfully saved. ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exc)   // Convert.ToDouble((txtAmount.Text.Trim() == string.Empty) ? "0" : txtAmount.Text.Trim())
            {
                MessageBox.Show("Expense Info saved unsuccessful.Because of the error:" + exc.Message);
            }
        }

        private void LoadDataIntoGrid()
        {
            ExpenseTransactionBAL expenseTransactionBAL = new ExpenseTransactionBAL();
            DataTable datatable = expenseTransactionBAL.GetGridData(dtSearchDate.Value, GlobalVariableBO._branchId);
            dgvExpenseTransInfo.DataSource = datatable;
            dgvExpenseTransInfo.Columns["Transaction_ID"].Visible = false;
            dgvExpenseTransInfo.Columns["Expense_ID"].Visible = false;
            dgvExpenseTransInfo.Columns["Category_ID"].Visible = false;
            dgvExpenseTransInfo.Columns["Branch"].Visible = false;
            dgvExpenseTransInfo.Columns["Purchaser"].Visible = false;
            dgvExpenseTransInfo.Columns["Entry By"].Visible = false;
            dgvExpenseTransInfo.Columns["Entry Date"].Visible = false;
            dgvExpenseTransInfo.Columns["Voucher"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvExpenseTransInfo.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvExpenseTransInfo.Columns["Amount"].DefaultCellStyle.Format = "N2";

            lblTotalRecord.Text = "Total Record : " + datatable.Rows.Count.ToString();
        }

//-----------Image resize and convert to byte-------------
        private static ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }



        private byte[] GetImageBytes(string fileName)
        {
            MemoryStream stream = new MemoryStream();
            try
            {   //-----------Image size compression -------------
                Bitmap bmp1 = new Bitmap(fileName);
                ImageCodecInfo jgpEncoder = GetEncoder(ImageFormat.Jpeg);
                System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
                EncoderParameters myEncoderParameters = new EncoderParameters(1);
                EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 20L);
                myEncoderParameters.Param[0] = myEncoderParameter;

                ///convert to byte formate 
                bmp1.Save(stream, jgpEncoder, myEncoderParameters);
                bmp1.Dispose();

                ////////////Previous Work without compression
                //Bitmap image = new Bitmap(fileName);
                //image.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
                //image.Dispose();
                return stream.ToArray();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wrong Image File." + ex.Message);
            }
            return null;
        }


        //--------End to image convert to byte-----------


        private void ddlCategoryType_DropDown(object sender, EventArgs e)
        {
            ddlCategoryType.AutoCompleteMode = AutoCompleteMode.None;
        }

        private void ddlCategoryType_DropDownClosed(object sender, EventArgs e)
        {
            ddlCategoryType.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }

        private void ddlCategoryType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (ddlCategoryType.DroppedDown)
                {
                    ddlCategoryType.DroppedDown = false;
                }
            }
        }

        private void ddlCategoryType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!_call_From_Expense)
                {
                    int typeId = Convert.ToInt32(ddlCategoryType.SelectedValue.ToString());
                    //if(!_zeroIndex_Forwarded_ForCategoryType)
                    //{
                    LoadCategoryNameByTypeId(typeId);
                    //}
                    //else
                    //{
                    //_zeroIndex_Forwarded_ForCategoryType = false;
                    //}
                }
            }
            catch
            {

            }
        }

        private void ddlCategoryType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (!_call_From_Expense)
                {
                    int typeId = Convert.ToInt32(ddlCategoryType.SelectedValue.ToString());
                    //if (!_zeroIndex_Forwarded_ForCategoryType)
                    //{
                    LoadCategoryNameByTypeId(typeId);
                    //}
                    //else
                    //{
                    //    _zeroIndex_Forwarded_ForCategoryType = false;
                    //}
                }
            }
            catch
            {

            }
        }

        //------------------------------------//
        private void ddlExpenseCategory_DropDown(object sender, EventArgs e)
        {
            ddlCategoryName.AutoCompleteMode = AutoCompleteMode.None;
        }

        private void ddlExpenseCategory_DropDownClosed(object sender, EventArgs e)
        {
            ddlCategoryName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }

        //private void ddlExpenseCategory_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        if (ddlCategoryName.DroppedDown)
        //        {
        //            ddlCategoryName.DroppedDown = false;
        //        }              
        //    }
        //}

        private void ddlExpenseCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!_call_From_Expense)
                {
                    int CategoryId = Convert.ToInt32(ddlCategoryName.SelectedValue.ToString());
                    //if(_zeroIndex_Forwarded_ForCategoryName)
                    //{
                    SetCategoryTypeAndLoadExpenseNameByCagegoryId(CategoryId);
                    //}
                    //else
                    //{
                    //    _zeroIndex_Forwarded_ForCategoryName = false;
                    //}
                }
            }
            catch
            {

            }
        }

        private void ddlExpenseCategory_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (!_call_From_Expense)
                {
                    int CategoryId = Convert.ToInt32(ddlCategoryName.SelectedValue.ToString());
                    //if (!_zeroIndex_Forwarded_ForCategoryName)
                    //{
                    SetCategoryTypeAndLoadExpenseNameByCagegoryId(CategoryId);
                    //}
                    //else
                    //{
                    //    _zeroIndex_Forwarded_ForCategoryName = false;
                    //}
                }
            }
            catch
            {

            }
        }

        //------------------------------------//
        private void ddlExpenseName_DropDown(object sender, EventArgs e)
        {
            ddlExpenseName.AutoCompleteMode = AutoCompleteMode.None;
        }

        private void ddlExpenseName_DropDownClosed(object sender, EventArgs e)
        {
            ddlExpenseName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }

        //private void ddlExpenseName_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        e.Handled = true;
        //        if (ddlExpenseName.DroppedDown)
        //        {
        //            ddlExpenseName.DroppedDown = false;
        //        }
        //        e.Handled = true;
        //        SendKeys.Send("{TAB}");                
        //    }
        //}

        private void ddlExpenseName_SelectedIndexChanged(object sender, EventArgs e)////////////////////////////////////////////////////////////////////
        {
            try
            {
                _call_From_Expense = true;
                int expenseId = Convert.ToInt32(ddlExpenseName.SelectedValue.ToString());              
                {
                    LoadCategoryTypeAndCategoryNameByExpenseId(expenseId);
                    ExpenseTransactionBAL transBal = new ExpenseTransactionBAL();
                    string FrequencyName = transBal.GetExpenseFrequency(Convert.ToInt32(ddlExpenseName.SelectedValue));
                    if (FrequencyName == Indication_ExpenseReports.Expense_Frequency_Monthly)
                        FormModeExecution(FormMode.MonthlyMode);
                    else if (FrequencyName == Indication_ExpenseReports.Expense_Frequency_Yearly)
                        FormModeExecution(FormMode.YearlyMode);
                    else if (FrequencyName == Indication_ExpenseReports.Expense_Frequency_HalfYearly)
                        FormModeExecution(FormMode.HalfYearlyMode);
                    else
                        FormModeExecution(FormMode.DefaultMode);
                    LoadDataIntoGrid();

                    string queryForCatID = @"select category_ID from SBP_Expense_Lookup
                                         where expense_ID=" + expenseId + "";
                    DataTable dtCatID = new DataTable();
                    dtCatID = transBal.Get_Data(queryForCatID);
                    if (dtCatID.Rows.Count > 0)
                    { 
                        if (Convert.ToInt32(dtCatID.Rows[0][0]) == 9)
                        {
                            txtRate.Enabled = true;
                            txtQuantity.Enabled = true;
                            
                            txtAmount.Enabled = false;
                        }
                        else
                        {
                            txtRate.Enabled = false;
                            txtQuantity.Enabled = false;

                            txtAmount.Enabled = true;
                        }
                    }
                    

                    string query = @"select Sub_Category_Type_ID,Sub_Category_Type_Name 
                                            from SBP_Expense_Sub_Category_Type
                                            where ExpenseID=" + expenseId + " ";
                    DataTable dt = new DataTable();
                    dt = transBal.Get_Data(query);
                    if (dt.Rows.Count > 0)
                    {
                        cmbSubCategory.Text = "";
                        cmbSubCategory.Enabled = true;
                        //cmbSubCategory.Focus();
                        cmbSubCategory.DataSource = dt;
                        cmbSubCategory.DisplayMember = "Sub_Category_Type_Name";
                        cmbSubCategory.ValueMember = "Sub_Category_Type_ID";
                    }
                    else
                    {
                        cmbSubCategory.Text = "";
                        cmbSubCategory.Enabled = false;
                        //cmbSubCategory.Focus();
                        cmbSubCategory.DataSource = dt;
                        cmbSubCategory.DisplayMember = "Sub_Category_Type_Name";
                        cmbSubCategory.ValueMember = "Sub_Category_Type_ID";
                    }                    
                }
            }
            catch
            {

            }
            _call_From_Expense = false;
        }

        private void ddlExpenseName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                _call_From_Expense = true;
                int expenseId = Convert.ToInt32(ddlExpenseName.SelectedValue.ToString());

                LoadCategoryTypeAndCategoryNameByExpenseId(expenseId);
                ExpenseTransactionBAL transBal = new ExpenseTransactionBAL();
                string FrequencyName = transBal.GetExpenseFrequency(Convert.ToInt32(ddlExpenseName.SelectedValue));
                if (FrequencyName == Indication_ExpenseReports.Expense_Frequency_Monthly)
                    FormModeExecution(FormMode.MonthlyMode);
                else if (FrequencyName == Indication_ExpenseReports.Expense_Frequency_Yearly)
                    FormModeExecution(FormMode.YearlyMode);
                else if (FrequencyName == Indication_ExpenseReports.Expense_Frequency_HalfYearly)
                    FormModeExecution(FormMode.HalfYearlyMode);
                else
                    FormModeExecution(FormMode.DefaultMode);
                LoadDataIntoGrid();

                string queryForCatID = @"select category_ID from SBP_Expense_Lookup
                                         where expense_ID=" + expenseId + "";
                DataTable dtCatID = new DataTable();
                dtCatID = transBal.Get_Data(queryForCatID);
                if (dtCatID.Rows.Count > 0)
                {
                    if (Convert.ToInt32(dtCatID.Rows[0][0]) == 9)
                    {
                        txtRate.Enabled = true;
                        txtQuantity.Enabled = true;
                    }
                    else
                    {
                        txtRate.Enabled = false;
                        txtQuantity.Enabled = false;
                    }
                }
         


                string query = @"select Sub_Category_Type_ID,Sub_Category_Type_Name 
                                            from SBP_Expense_Sub_Category_Type
                                            where ExpenseID=" + expenseId + " ";
                DataTable dt = new DataTable();
                dt = transBal.Get_Data(query);
                if (dt.Rows.Count > 0)
                {
                    cmbSubCategory.Text = "";
                    cmbSubCategory.Enabled = true;
                    //cmbSubCategory.Focus();
                    cmbSubCategory.DataSource = dt;
                    cmbSubCategory.DisplayMember = "Sub_Category_Type_Name";
                    cmbSubCategory.ValueMember = "Sub_Category_Type_ID";
                }
                else
                {
                    cmbSubCategory.Text = "";
                    cmbSubCategory.Enabled = false;
                    //cmbSubCategory.Focus();
                    cmbSubCategory.DataSource = dt;
                    cmbSubCategory.DisplayMember = "Sub_Category_Type_Name";
                    cmbSubCategory.ValueMember = "Sub_Category_Type_ID";
                }  
            }
            catch
            {

            }
            _call_From_Expense = false;
        }
        private void LoadCagegoryName(int typeId)
        {
            var dtCagegoryName = (ExpenseTransaction_Cache.Where(t => t.Key == type_Category_Expense)
                          .Select(t => t.Value).SingleOrDefault() as DataTable).AsEnumerable()
                          .Where(t => Convert.ToInt32(t["Category_Type_ID"]) == typeId)
    .Select(t => new { Key = t["Category_ID"], Value = t["Category_Name"] }).GroupBy(t => t.Key)
    .Select(g => new KeyValuePair<int, string>(Convert.ToInt32(g.Key), Convert.ToString(g.Max(t => t.Value)))).ToList();

            dtCagegoryName.Insert(0, (new KeyValuePair<int, string>(0, "Please Select an Item")));
            _zeroIndex_Forwarded_ForCategoryType = true;
            ddlCategoryName.DataSource = null;
            _zeroIndex_Forwarded_ForCategoryType = false;
            ddlCategoryName.ValueMember = "Key";
            ddlCategoryName.DisplayMember = "Value";
            _zeroIndex_Forwarded_ForCategoryName = true;
            ddlCategoryName.DataSource = dtCagegoryName;
            _zeroIndex_Forwarded_ForCategoryName = false;

            ddlCategoryName.SelectedIndex = 0;
        }

        private void LoadCategoryNameByTypeId(int typeId)
        {
            if (typeId != 0)
            {
                LoadCagegoryName(typeId);
            }
            else
            {
                LoadAllCategoryData();
            }
        }

        private void SetCategoryTypeByExpenseId(int expenseId)
        {
            var Category_type = (ExpenseTransaction_Cache.Where(t => t.Key == type_Category_Expense)
                                .Select(t => t.Value).SingleOrDefault() as DataTable).AsEnumerable().Where(t => Convert.ToInt32(t["Expense_ID"]) == expenseId)//.Where(t => t["Expense_ID"] != DBNull.Value)
                                .Select(t => new { Key = t["Category_Type_ID"], Value = t["Category_Type"] }).GroupBy(t => t.Key)
                                .Select(g => new KeyValuePair<int, string>(Convert.ToInt32(g.Key), Convert.ToString(g.Max(t => t.Value)))).ToList();
            ddlCategoryType.SelectedValue = Category_type[0].Key;

        }

        private void SetCategoryTypeByCategoryId(int cagegoryId)
        {
            var Category_type = (ExpenseTransaction_Cache.Where(t => t.Key == type_Category_Expense)//.Where(t => t["Category_ID"] != DBNull.Value)
                                     .Select(t => t.Value).SingleOrDefault() as DataTable).AsEnumerable().Where(
                                         t => Convert.ToInt32(t["Category_ID"]) == cagegoryId)
                .Select(t => new { Key = t["Category_Type_ID"], Value = t["Category_Type"] }).GroupBy(t => t.Key)
                .Select(
                    g => new KeyValuePair<int, string>(Convert.ToInt32(g.Key), Convert.ToString(g.Max(t => t.Value)))).
                ToList();
            if (!_zeroIndex_Forwarded_ForCategoryType)
            {
                ddlCategoryType.SelectedValue = Category_type[0].Key;
            }
            else
            {
                _zeroIndex_Forwarded_ForCategoryType = false;
            }

        }

        private void SetCategoryName(int expenseId)
        {
            var dtCategoryName = (ExpenseTransaction_Cache.Where(t => t.Key == type_Category_Expense)
                                          .Select(t => t.Value).SingleOrDefault() as DataTable).AsEnumerable().Where(t => Convert.ToInt32(t["Expense_ID"]) == expenseId)//.Where(t => t["Expense_ID"] != DBNull.Value)
                    .Select(t => new { Key = t["Category_ID"], Value = t["Category_Name"] }).GroupBy(t => t.Key)
                    .Select(g => new KeyValuePair<int, string>(Convert.ToInt32(g.Key), Convert.ToString(g.Max(t => t.Value)))).ToList();
            ddlCategoryName.SelectedValue = dtCategoryName[0].Key;
        }

        private void LoadCategoryTypeAndCategoryNameByExpenseId(int expenseId)
        {
            if (expenseId != 0)
            {
                SetCategoryTypeByExpenseId(expenseId);
                SetCategoryName(expenseId);
            }
            else
            {
                if ((!_zeroIndex_Forwarded_ForCategoryName) && (!_zeroIndex_Forwarded_ForExpense))
                {
                    LoadAllCategoryData();
                    ddlCategoryType.SelectedIndex = 0;
                    ddlCategoryName.SelectedIndex = 0;
                }
                else
                {
                    _zeroIndex_Forwarded_ForCategoryName = false;
                    _zeroIndex_Forwarded_ForExpense = false;
                }
                //ddlExpenseName.SelectedIndex = 0;
            }
        }

        private void LoadAllCategoryData()
        {
            var Category = (ExpenseTransaction_Cache.Where(t => t.Key == type_Category_Expense)
                    .Select(t => t.Value).SingleOrDefault() as DataTable).AsEnumerable()//.Where(t => t["Category_ID"] != DBNull.Value)
                    .Select(t => new { Key = t["Category_ID"], Value = t["Category_Name"] }).GroupBy(t => t.Key)
                    .Select(g => new KeyValuePair<int, string>(Convert.ToInt32(g.Key), Convert.ToString(g.Max(t => t.Value)))).ToList();
            Category.Insert(0, (new KeyValuePair<int, string>(0, "Please Select an Item")));
            ddlCategoryName.DataSource = null;
            ddlCategoryName.ValueMember = "Key";
            ddlCategoryName.DisplayMember = "Value";
            ddlCategoryName.DataSource = Category.ToList();
            ddlCategoryName.SelectedIndex = 0;

        }

        private void LoadAllExpenseData()
        {
            var Expense = (ExpenseTransaction_Cache.Where(t => t.Key == type_Category_Expense)
                                .Select(t => t.Value).SingleOrDefault() as DataTable).AsEnumerable()//.Where(t => t["Expense_ID"] != DBNull.Value)
                                .Select(t => new { Key = t["Expense_ID"], Value = t["Expense_Description"] }).GroupBy(t => t.Key)
                                .Select(g => new KeyValuePair<int, string>(Convert.ToInt32(g.Key), Convert.ToString(g.Max(t => t.Value)))).ToList();

            Expense.Insert(0, (new KeyValuePair<int, string>(0, "Please Select an Item")));
            ddlExpenseName.ValueMember = "Key";
            ddlExpenseName.DisplayMember = "Value";
            ddlExpenseName.DataSource = Expense.ToList();
            ddlExpenseName.SelectedIndex = 0;
        }

        private void LoadExpenseNameByCagegoryId(int CategoryId)
        {
            var ExpenseName = (ExpenseTransaction_Cache.Where(t => t.Key == type_Category_Expense)
                       .Select(t => t.Value).SingleOrDefault() as DataTable).AsEnumerable().Where( //.Where(t => t["Expense_ID"] != DBNull.Value)
                           t => Convert.ToInt32(t["Category_ID"]) == CategoryId)
    .Select(t => new { Key = t["Expense_ID"], Value = t["Expense_Description"] }).GroupBy(t => t.Key)
    .Select(
        g =>
        new KeyValuePair<int, string>(Convert.ToInt32(g.Key), Convert.ToString(g.Max(t => t.Value)))).
    ToList();
            ExpenseName.Insert(0, (new KeyValuePair<int, string>(0, "Please Select an Item")));
            ddlExpenseName.ValueMember = "Key";
            ddlExpenseName.DisplayMember = "Value";
            _zeroIndex_Forwarded_ForExpense = true;
            ddlExpenseName.DataSource = ExpenseName;
            _zeroIndex_Forwarded_ForExpense = false;
            ddlExpenseName.SelectedIndex = 0;
        }

        private void SetCategoryTypeAndLoadExpenseNameByCagegoryId(int CategoryId)
        {
            if (CategoryId != 0)
            {
                SetCategoryTypeByCategoryId(CategoryId);
                LoadExpenseNameByCagegoryId(CategoryId);
            }
            else
            {
                LoadAllExpenseData();
            }
        }



        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvExpenseTransInfo.Rows.Count > 0)
                {
                    int TransId = Int32.Parse(dgvExpenseTransInfo.SelectedRows[0].Cells[0].Value.ToString());
                    ViewExpenseInfo(TransId);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ViewExpenseInfo(int transId)
        {
            try
            {
                ExpenseTransactionBAL expenseTransactionBAL = new ExpenseTransactionBAL();
                DataTable dtRecordInfo = new DataTable();

                dtRecordInfo = expenseTransactionBAL.GetDataByTransactionId(transId);

                if (dtRecordInfo.Rows.Count > 0)
                {
                    ddlCategoryType.Text = dtRecordInfo.Rows[0]["Category_Type"].ToString();
                    ddlCategoryName.Text = dtRecordInfo.Rows[0]["Category"].ToString();
                    ddlExpenseName.Text = dtRecordInfo.Rows[0]["Expense"].ToString();
                    dtpExpenseDate.Value = Convert.ToDateTime(dtRecordInfo.Rows[0]["Expense Date"]);
                    dtpPaymentDate.Value = Convert.ToDateTime(dtRecordInfo.Rows[0]["Payment Date"]);
                    txtAmount.Text = Convert.ToDouble(dtRecordInfo.Rows[0]["Amount"].ToString()).ToString();
                    txtVoucherNo.Text = dtRecordInfo.Rows[0]["Voucher No"].ToString();
                    txtRemarks.Text = dtRecordInfo.Rows[0]["Remarks"].ToString();

                    byte[] ImageBytes = (byte[])((dtRecordInfo.Rows[0]["Voucher Image"] == DBNull.Value) ? new byte[0] : dtRecordInfo.Rows[0]["Voucher Image"]);

                    if (ImageBytes.Length != 0)
                    {
                        MemoryStream ms = new MemoryStream(ImageBytes);
                        _image = Image.FromStream(ms);
                        picVouchar.Image = _image;
                    }

                    else
                    {
                        _image = null;
                        picVouchar.Image = _image;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ExpenseTransactionBAL eBAL = new ExpenseTransactionBAL();
            try
            {
                if (dgvExpenseTransInfo.SelectedRows.Count > 0)
                {
                    int transId = Int32.Parse(dgvExpenseTransInfo.SelectedRows[0].Cells[0].Value.ToString());
                    int voucherId = Int32.Parse(dgvExpenseTransInfo.SelectedRows[0].Cells[11].Value.ToString());


                    if (eBAL.IsApprovedOrNot(transId))
                    {
                        DeleteRecordInfo(transId, voucherId);
                        LoadDataIntoGrid();
                        ResetField();
                    }
                    else
                    {
                        MessageBox.Show("Approved data isn't appllicable for deletion..", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                else
                {
                    MessageBox.Show("No Information is Selected.", "Delete Info Check", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        

        private void DeleteRecordInfo(int transId, int voucherId)
        {
            try
            {
                ExpenseTransactionBAL expenseTransactionBAL = new ExpenseTransactionBAL();

                if (MessageBox.Show("Do you want to delete this Record", "Delete Message", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    expenseTransactionBAL.DeleteExpenseTransData(transId, voucherId);
                    MessageBox.Show("Data has been deleted successfully", "Delete Message", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void picVouchar_Click(object sender, EventArgs e)
        {
            if (_image == null)
                return;

            ImageViewer imageViewer = new ImageViewer(_image);
            imageViewer.ShowDialog();
        }

        private void dtSearchDate_ValueChanged(object sender, EventArgs e)
        {
            DateTime processed_ExpenseDate;
            _call_From_Expense = true;
            int expenseId = Convert.ToInt32(ddlExpenseName.SelectedValue.ToString());

            LoadCategoryTypeAndCategoryNameByExpenseId(expenseId);
            ExpenseTransactionBAL transBal = new ExpenseTransactionBAL();
            string FrequencyName = transBal.GetExpenseFrequency(Convert.ToInt32(ddlExpenseName.SelectedValue));
            if (FrequencyName == Indication_ExpenseReports.Expense_Frequency_Monthly)
            {
                processed_ExpenseDate = new DateTime(dtpExpenseDate.Value.Year, dtpExpenseDate.Value.Month, DateTime.DaysInMonth(dtpExpenseDate.Value.Year, dtpExpenseDate.Value.Month));
                dtpExpenseDate.Value = processed_ExpenseDate;
                processed_ExpenseDate = new DateTime(dtSearchDate.Value.Year, dtSearchDate.Value.Month, DateTime.DaysInMonth(dtSearchDate.Value.Year, dtSearchDate.Value.Month));
                dtSearchDate.Value = processed_ExpenseDate;
            }
            else if (FrequencyName == Indication_ExpenseReports.Expense_Frequency_Yearly)
            {

                processed_ExpenseDate = new DateTime(dtpExpenseDate.Value.Year, 12, 31);
                dtpExpenseDate.Value = processed_ExpenseDate;
                processed_ExpenseDate = new DateTime(dtSearchDate.Value.Year, 12, 31);
                dtSearchDate.Value = processed_ExpenseDate;
            }
            else if (FrequencyName == Indication_ExpenseReports.Expense_Frequency_HalfYearly)
            {
                if (dtpExpenseDate.Value.Month > 6)
                    processed_ExpenseDate = new DateTime(dtpExpenseDate.Value.Year, 12, 31);
                else
                    processed_ExpenseDate = new DateTime(dtpExpenseDate.Value.Year, 06, 30);
                dtpExpenseDate.Value = processed_ExpenseDate;

                if (dtpExpenseDate.Value.Month > 6)
                    processed_ExpenseDate = new DateTime(dtSearchDate.Value.Year, 12, 31);
                else
                    processed_ExpenseDate = new DateTime(dtSearchDate.Value.Year, 06, 30);
                dtSearchDate.Value = processed_ExpenseDate;
            }
            LoadDataIntoGrid();
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            //if (txtAmount.Text == string.Empty)
            //    txtAmount.Text = "0";
        }

        private void dtpExpenseDate_ValueChanged(object sender, EventArgs e)
        {
            DateTime processed_ExpenseDate;
            _call_From_Expense = true;
            int expenseId = Convert.ToInt32(ddlExpenseName.SelectedValue.ToString());

            LoadCategoryTypeAndCategoryNameByExpenseId(expenseId);
            ExpenseTransactionBAL transBal = new ExpenseTransactionBAL();
            string FrequencyName = transBal.GetExpenseFrequency(Convert.ToInt32(ddlExpenseName.SelectedValue));
            if (FrequencyName == Indication_ExpenseReports.Expense_Frequency_Monthly)
            {
                processed_ExpenseDate = new DateTime(dtpExpenseDate.Value.Year, dtpExpenseDate.Value.Month, DateTime.DaysInMonth(dtpExpenseDate.Value.Year, dtpExpenseDate.Value.Month));
                dtpExpenseDate.Value = processed_ExpenseDate;
                dtSearchDate.Value = processed_ExpenseDate;
            }
            else if (FrequencyName == Indication_ExpenseReports.Expense_Frequency_Yearly)
            {

                processed_ExpenseDate = new DateTime(dtpExpenseDate.Value.Year, 12, 31);
                dtpExpenseDate.Value = processed_ExpenseDate;
                dtSearchDate.Value = processed_ExpenseDate;
            }
            else if (FrequencyName == Indication_ExpenseReports.Expense_Frequency_HalfYearly)
            {
                if (dtpExpenseDate.Value.Month > 6)
                    processed_ExpenseDate = new DateTime(dtpExpenseDate.Value.Year, 12, 31);
                else
                    processed_ExpenseDate = new DateTime(dtpExpenseDate.Value.Year, 06, 30);
                dtpExpenseDate.Value = processed_ExpenseDate;
                dtSearchDate.Value = processed_ExpenseDate;
            }

            dtSearchDate.Value = dtpExpenseDate.Value;

        }

        private void dtpPaymentDate_ValueChanged(object sender, EventArgs e)
        {
            DateTime processed_ExpenseDate;
            _call_From_Expense = true;
            int expenseId = Convert.ToInt32(ddlExpenseName.SelectedValue.ToString());

            LoadCategoryTypeAndCategoryNameByExpenseId(expenseId);
            ExpenseTransactionBAL transBal = new ExpenseTransactionBAL();
            string FrequencyName = transBal.GetExpenseFrequency(Convert.ToInt32(ddlExpenseName.SelectedValue));
            if (FrequencyName == Indication_ExpenseReports.Expense_Frequency_Monthly)
            {
                processed_ExpenseDate = new DateTime(dtpExpenseDate.Value.Year, dtpExpenseDate.Value.Month, DateTime.DaysInMonth(dtpExpenseDate.Value.Year, dtpExpenseDate.Value.Month));
                dtpExpenseDate.Value = processed_ExpenseDate;
                dtSearchDate.Value = processed_ExpenseDate;
            }
            else if (FrequencyName == Indication_ExpenseReports.Expense_Frequency_Yearly)
            {

                processed_ExpenseDate = new DateTime(dtpExpenseDate.Value.Year, 12, 31);
                dtpExpenseDate.Value = processed_ExpenseDate;
                dtSearchDate.Value = processed_ExpenseDate;
            }
            else if (FrequencyName == Indication_ExpenseReports.Expense_Frequency_HalfYearly)
            {
                if (dtpExpenseDate.Value.Month > 6)
                    processed_ExpenseDate = new DateTime(dtpExpenseDate.Value.Year, 12, 31);
                else
                    processed_ExpenseDate = new DateTime(dtpExpenseDate.Value.Year, 06, 30);
                dtpExpenseDate.Value = processed_ExpenseDate;
                dtSearchDate.Value = processed_ExpenseDate;
            }
        }

        //private void dtpExpenseDate_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        e.Handled = true;
        //        SendKeys.Send("{TAB}");
        //    }
        //}

        //private void dtpPaymentDate_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        e.Handled = true;
        //        SendKeys.Send("{TAB}");
        //    }
        //}

        //private void txtAmount_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        e.Handled = true;
        //        SendKeys.Send("{TAB}");
        //    }
        //}

        //private void txtRemarks_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        e.Handled = true;
        //        SendKeys.Send("{TAB}");
        //    }
        //}

        //private void btnSave_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        e.Handled = true;
        //        SendKeys.Send("{TAB}");
        //    }
        //}

        //private void txtVoucherNo_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        e.Handled = true;
        //        SendKeys.Send("{TAB}");
        //    }           
        //}


        //---------------------
        private void cmbPaymentType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                ddlExpenseName.Focus();
            }
        }
        //-------------------
        private void ddlExpenseName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (cmbSubCategory.Enabled == true)
                {
                    e.Handled = true;
                    cmbSubCategory.Focus();
                }
                else
                {
                    e.Handled = true;
                    dtpExpenseDate.Focus();
                }
            }
//            ExpenseTransactionBAL transBal = new ExpenseTransactionBAL();
//            int expenseId = Convert.ToInt32(ddlExpenseName.SelectedValue.ToString());
//            string queryForCatID = @"select category_ID from SBP_Expense_Lookup
//                                         where expense_ID=" + expenseId + "";
//            DataTable dtCatID = new DataTable();
//            dtCatID = transBal.Get_Data(queryForCatID);

            //if (e.KeyChar == 13)
            //{
            //    if (cmbSubCategory.Enabled == true)
            //    {
            //        e.Handled = true;
            //        cmbSubCategory.Focus();
            //    }
            //    else if (dtCatID.Rows.Count > 0)
            //    {
            //        if (Convert.ToInt32(dtCatID.Rows[0][0]) == 9)
            //        {
            //            e.Handled = true;
            //            txtQuantity.Focus();
            //        }
            //        else
            //        {
            //            e.Handled = true;
            //            txtAmount.Focus();
            //        }
            //    }
            //}
        }
        //private void dtpExpenseDate_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == 13)
        //    {
        //        e.Handled = true;
        //        dtpPaymentDate.Focus();
        //    }            
        //}

        //private void dtpPaymentDate_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == 13)
        //    {
        //        e.Handled = true;
        //        txtAmount.Focus();
        //    }
        //}


        //---------------------
        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                txtVoucherNo.Focus();
            }
        }
        //--------------
        private void txtVoucherNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                btnBrowseLogo.Focus();
            }
        }

        //private void ddlPurchaserEmp_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == 13)
        //    {
        //        e.Handled = true;
        //        btnBrowseLogo.Focus();
        //    }
        //}

        //private void btnBrowseLogo_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == 13)
        //    {
        //        e.Handled = true;
        //        txtRemarks.Focus();
        //    }
        //}
        //-------------------
        private void txtRemarks_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                btnSave.Focus();
            }
        }

        private void ddlCategoryName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                cmbPaymentType.Focus();
            }
        }
        //---------------------------
        private void dtpExpenseDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                dtpPaymentDate.Focus();
            }
        }
        //------------------
        private void dtpPaymentDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtQuantity.Enabled == true)
                {
                    e.Handled = true;
                    txtQuantity.Focus();
                }
                else
                { 
                    e.Handled = true;
                txtAmount.Focus();
                }                
            }
        }

        private void cmbSubCategory_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                dtpExpenseDate.Focus();
            }
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                txtRate.Focus();
            }
        }

        private void txtRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                txtVoucherNo.Focus();
            }
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            double doubleTryParse;

            if (txtQuantity.Text != "")
            {
                double qty = 0;
                if (double.TryParse(txtQuantity.Text, out doubleTryParse))
                    qty = doubleTryParse;

                double rate = 0;
                if (double.TryParse(txtRate.Text, out doubleTryParse))
                    rate = doubleTryParse;

                txtAmount.Text = Convert.ToString(qty * rate);
                txtAmount.Enabled = false;
            }
            else
            {
                txtQuantity.Text = "";
                txtAmount.Text = "";
            }
        }

        private void txtRate_TextChanged(object sender, EventArgs e)
        {
            double doubleTryParse;

            if (txtRate.Text != "")
            {
                double qty = 0;
                if (double.TryParse(txtQuantity.Text, out doubleTryParse))
                    qty = doubleTryParse;

                double rate = 0;
                if (double.TryParse(txtRate.Text, out doubleTryParse))
                    rate = doubleTryParse;

                txtAmount.Text = Convert.ToString(qty * rate);
            }
            else
            {
                txtRate.Text = "";
                txtAmount.Text = "";
            }
        }
    }
}
