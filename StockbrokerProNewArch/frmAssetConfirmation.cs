using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataAccessLayer;
using BusinessAccessLayer.BAL;
using BusinessAccessLayer.BO;


namespace StockbrokerProNewArch
{
    public partial class frmAssetConfirmation : Form
    {
        private DbConnection _dbConnection = new DbConnection();

        public frmAssetConfirmation()
        {
            InitializeComponent();
        }

        private void frmAssetConfirmation_Load(object sender, EventArgs e)
        {
            loadingProcess();              
        }

        private void loadingProcess()
        { 
            starting();
            comboLoad();

            dtpPurchaseDate.Value = DateTime.Today;
            cmbAssetType.Visible = false;
            cmbSubCategory.Visible = false;
            cmbCatagory.Visible = false;
            txtExtra.Visible = false;

            txtAssetType.Visible = true;
            txtAssetName.Visible = true;
            txtCatagory.Visible = true;
            txtQuantity.ReadOnly = true;
            txtQuantity.BackColor = SystemColors.GradientInactiveCaption;
            txtRate.ReadOnly = true;
            txtRate.BackColor = SystemColors.GradientInactiveCaption;
            txtCost.ReadOnly = true;
            txtDepAmount.ReadOnly = true;
            dgvUnSettledAsset.Enabled = true;
            txtSalvageRate.Visible = true;   
            txtSalvageRate.BackColor = SystemColors.Window;
            txtSalvageValue.BackColor = SystemColors.Window;
            txtLifeTime.BackColor = SystemColors.Window;         
            label23.Text = "Asset Entry";
        }
        private void comboLoad()
        {
            AssetSettlementBAL assBal = new AssetSettlementBAL();
            DataTable dt = assBal.getUnSettledData();
            dgvUnSettledAsset.DataSource = dt;

            dgvUnSettledAsset.Columns["assetID"].Visible = false;
            dgvUnSettledAsset.Columns["Model"].Visible = false;
            dgvUnSettledAsset.Columns["LifeTime"].Visible = false;
            dgvUnSettledAsset.Columns["SalvageValue"].Visible = false;
            dgvUnSettledAsset.Columns["DepreciationRate"].Visible = false;
            dgvUnSettledAsset.Columns["DepreciationAmount"].Visible = false;
            dgvUnSettledAsset.Columns["NetBalance"].Visible = false;
            dgvUnSettledAsset.Columns["Status"].Visible = false;
            dgvUnSettledAsset.Columns["Remarks"].Visible = false;
            dgvUnSettledAsset.Columns["EntryDate"].Visible = false;
            dgvUnSettledAsset.Columns["EntryBy"].Visible = false;
            dgvUnSettledAsset.Columns["UpdateDate"].Visible = false;
            dgvUnSettledAsset.Columns["UpdateBy"].Visible = false;
            dgvUnSettledAsset.Columns["TransactiionID"].Visible = false;
            dgvUnSettledAsset.Columns["Expense_ID"].Visible = false;
            dgvUnSettledAsset.Columns["Category_ID"].Visible = false;
            dgvUnSettledAsset.Columns["Branch_ID"].Visible = false;

            ExpenseTransactionBAL expenseTransactionBAL = new ExpenseTransactionBAL();
            DataTable dtExpense = new DataTable();
            dtExpense = expenseTransactionBAL.GetExpenseForAssetSettlement();
            cmbAssetType.DisplayMember = "Expense_Description";
            cmbAssetType.ValueMember = "Expense_ID";
            cmbAssetType.DataSource = dtExpense;
        }

        int asstID = 0;
        private void dgvUnSettledAsset_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            asstID = Convert.ToInt32(dgvUnSettledAsset.SelectedRows[0].Cells["assetID"].Value.ToString());

            AssetSettlementBAL assBal = new AssetSettlementBAL();
            DataTable dt = assBal.getUnSettledDataIntoTexBox(asstID);

            dtpPurchaseDate.Value = Convert.ToDateTime(dt.Rows[0]["Date"].ToString());
            txtAssetType.Text = dt.Rows[0]["Asset_Type"].ToString();
            txtAssetName.Text = dt.Rows[0]["Asset_Name"].ToString();
            txtCatagory.Text = dt.Rows[0]["Catagori"].ToString();
            txtQuantity.Text = dt.Rows[0]["Quantity"].ToString();
            txtRate.Text = dt.Rows[0]["Rate"].ToString();
            txtCost.Text = dt.Rows[0]["Cost"].ToString();
            txtSalvageRate.Text = "10";

            if (txtSalvageRate.Text != "")
            {
                double sValueCal = Convert.ToDouble(txtSalvageRate.Text);
                double TCos = Convert.ToDouble(txtCost.Text);
                txtSalvageValue.Text = Convert.ToString((sValueCal * TCos) / 100);
            }
            else
            {
                double sValueCal = 0.00;
                double TCos = Convert.ToDouble(txtCost.Text);
                txtSalvageValue.Text = Convert.ToString((sValueCal * TCos) / 100);
            }
            txtLifeTime.Text = dt.Rows[0]["LifeTime"].ToString();
            txtDepAmount.Text = dt.Rows[0]["DepreciationAmount"].ToString();

            txtDepAmount.Text = Convert.ToString((Convert.ToDouble(txtCost.Text)) - (Convert.ToDouble(txtSalvageValue.Text)));

            dtpPurchaseDate.Enabled = false;
            txtSalvageRate.Focus();
            //disableProcess();
        }
        private bool validationOfAssetEntry()
        {
            if (this.txtRate.Text == "")
            {
                MessageBox.Show("Please enter rate...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtRate.Focus();
                return true;
            }
            else if (txtQuantity.Text == "")
            {
                MessageBox.Show("Please Write Quantity...", "Information!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtQuantity.Focus();
                return true;
            }
            else return false;
        }

        private void lblSave_Click(object sender, EventArgs e)
        {
            if (lblSave.Text == "Settle")
            {
                SettleAssetInfo();
                label23_Click(sender, e);
            }
            else if (lblSave.Text == "Save")
            {
                if (validationOfAssetEntry())
                    return;

                SaveAssetInfo();
                label23_Click(sender, e);
            }
        }

        private void SettleAssetInfo()
        {
            if (MessageBox.Show("Want to settle the asset??", "Settlement Alert!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (asstID != 0)
                {
                    double lifeTime = Convert.ToDouble(txtLifeTime.Text);
                    double LTMonth = lifeTime * 12;
                    double SV = Convert.ToDouble(txtSalvageValue.Text);
                    double DepAmt = Convert.ToDouble(txtDepAmount.Text);
                    AssetSettlementBAL asBal = new AssetSettlementBAL();
                    asBal.settleAssetFinally(LTMonth, SV, DepAmt, asstID);
                    asBal.settledAssetSendToDepTable(asstID);

                    comboLoad();
                    MessageBox.Show("Successfully Settled...");
                    loadingProcess();
                }
                else
                {
                    MessageBox.Show("Select a asset first...");
                }
            }
        }

        private void SaveAssetInfo()
        {
            ExpenseTransBO expenseTransBO = new ExpenseTransBO();
            ExpenseTransactionBAL expenseTransactionBAL = new ExpenseTransactionBAL();

            expenseTransBO = InitiallizeBO();
            expenseTransactionBAL.SaveExpenseTransaction(expenseTransBO);
            MessageBox.Show("Asset entry successfully saved. ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);            
        }
        private ExpenseTransBO InitiallizeBO()
        {
            ExpenseTransBO expenseTransBO = new ExpenseTransBO();
            expenseTransBO.Expense_ID = Convert.ToInt32(cmbAssetType.SelectedValue.ToString());
            expenseTransBO.Category_ID = Convert.ToInt32(cmbCatagory.SelectedValue.ToString());

            if (cmbSubCategory.DataSource == null)
            {
                expenseTransBO.sub_catagory_ID = 0;
            }
            else
            {
                expenseTransBO.sub_catagory_ID = Convert.ToInt32(cmbSubCategory.SelectedValue.ToString());
            }

            expenseTransBO.Expense_Date = dtpPurchaseDate.Value;
            expenseTransBO.Payment_Date = dtpPurchaseDate.Value;
            expenseTransBO.Payment_Media = "Cash";
            expenseTransBO.Pay_Bank_Name = "";
            expenseTransBO.Bank_Account_No = "";
            expenseTransBO.Pay_Cheque_No = "";
            expenseTransBO.Branch_ID = GlobalVariableBO._branchId;
            expenseTransBO.Amount = Convert.ToDouble((txtCost.Text.Trim() == string.Empty) ? "0" : txtCost.Text.Trim());
            expenseTransBO.Qquantity = txtQuantity.Text == "" ? 0 : Convert.ToInt32(txtQuantity.Text);
            expenseTransBO.Rate = txtRate.Text == "" ? 0 : Convert.ToDouble(txtRate.Text);
            expenseTransBO.Voucher_No = "";
            expenseTransBO.Approval_Status = 0;
            expenseTransBO.Approved_By = string.Empty;
            expenseTransBO.Remarks = "";

            return expenseTransBO;
        }

        private void disableProcess()
        {
            dtpPurchaseDate.Enabled = false;
            txtAssetType.Enabled = false;
            txtAssetName.Enabled = false;
            txtCatagory.Enabled = false;
            txtQuantity.Enabled = false;
            txtRate.Enabled = false;
            txtCost.Enabled = false;
        }

        //double y=0;
        //private void txtSalvageRate_TextChanged(object sender, EventArgs e)
        //{
        //    if (txtSalvageRate.Text != "")
        //    {
        //        y = Convert.ToDouble(txtSalvageRate.Text);
        //        if (y == 0)
        //        {
        //            txtSalvageValue.Text = Convert.ToString(((Convert.ToDouble(txtCost.Text)) * (Convert.ToDouble(txtSalvageRate.Text))) / 100);
        //        }
        //        else if (y == 1)
        //        {
        //            txtSalvageValue.Text = Convert.ToString(((Convert.ToDouble(txtCost.Text)) * (Convert.ToDouble(txtSalvageRate.Text))) / 100);

        //        }
        //        else if (y > 1)
        //        {
        //            txtSalvageValue.Text = Convert.ToString(((Convert.ToDouble(txtCost.Text)) * (Convert.ToDouble(txtSalvageRate.Text))) / 100);
        //        }
        //    }
        //    else
        //    {
        //        txtSalvageRate.Text = "";
        //        txtSalvageValue.Text = "0.00";
        //    }
        //    //if (txtSalvageRate.Text != "")
        //    //{
        //    //    double salVRate;
        //    //    double tPrice;

        //    //    tPrice = Convert.ToDouble(txtCost.Text);
        //    //    salVRate = Convert.ToDouble(txtSalvageRate.Text);
        //    //    txtSalvageValue.Text = Convert.ToString((tPrice * salVRate) / 100);
        //    //}
        //    //else
        //    //{
        //    //    txtSalvageRate.Text = "";
        //    //    txtSalvageValue.Text = "0.00";
        //    //}
        //}

        private void txtLifeTime_TextChanged(object sender, EventArgs e)
        {
            txtLifeTime.TextChanged -= txtLifeTime_TextChanged;
            if (label23.Text == "Asset Entry")
            {
                 if (txtLifeTime.Text != "")
                    {

                        double totPrice = Convert.ToDouble(txtCost.Text);
                        double SV = Convert.ToDouble(txtSalvageValue.Text);
                        double LT = Convert.ToDouble(txtLifeTime.Text);

                        txtDepAmount.Text = Convert.ToString((totPrice - SV) / LT);
                    }
                 else if (txtLifeTime.Text == "")
                 {
                     txtLifeTime.Text = "";                   
                     double totalCost = Convert.ToDouble(txtCost.Text);
                     double SalVal = Convert.ToDouble(txtSalvageValue.Text);
                     txtDepAmount.Text = Convert.ToString((totalCost - SalVal));
                 }
                 else if (Convert.ToDouble(txtLifeTime.Text)==0.00)
                 {
                     txtDepAmount.Text = "0.00";
                     double totalCost = Convert.ToDouble(txtCost.Text);
                     double SalVal = Convert.ToDouble(txtSalvageValue.Text);
                     txtDepAmount.Text = Convert.ToString((totalCost - SalVal));
                 }
            }
            txtLifeTime.TextChanged += txtLifeTime_TextChanged;
        }

        private void lblCancel_Click(object sender, EventArgs e)
        {
            starting();
            comboLoad();
            asstID = 0;
        }

        private void starting()
        {
            txtAssetType.Text = "";
            txtAssetName.Text = "";
            txtCatagory.Text = "";
            txtQuantity.Text = "0.00";
            txtRate.Text = "0.00";
            txtCost.Text = "0.00";
            txtSalvageRate.Text = "0.00";
            txtSalvageValue.Text = "0.00";
            txtLifeTime.Text = "0.00";
            txtDepAmount.Text = "0.00";
        }

        private void txtSalvageRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                txtLifeTime.Focus();
            }
        }

        private void txtLifeTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                lblSave.Focus();
            }
        }

        private void lblSave_MouseHover(object sender, EventArgs e)
        {
            lblSave.ForeColor = System.Drawing.Color.Red;
        }

        private void lblSave_MouseLeave(object sender, EventArgs e)
        {
            lblSave.ForeColor = System.Drawing.Color.Navy;
        }

        private void lblCancel_MouseHover(object sender, EventArgs e)
        {
            lblCancel.ForeColor = System.Drawing.Color.Red;
        }

        private void lblCancel_MouseLeave(object sender, EventArgs e)
        {
            lblCancel.ForeColor = System.Drawing.Color.Navy;
        }

        private void label23_Click(object sender, EventArgs e)
        {
            if (label23.Text == "Asset Entry")
            {
                //txtSalvageRate.TextChanged -= txtSalvageRate_TextChanged;               
                txtQuantity.Text = "0.00";
                txtRate.Text = "0.00";
                txtCost.Text = "0.00";
                txtSalvageRate.Text = "0.00";
                txtSalvageValue.Text = "0.00";               
                txtLifeTime.Text = "0";
                txtDepAmount.Text = "0.00";
                assetMode();
                //txtSalvageRate.TextChanged -= txtSalvageRate_TextChanged;
            }
            else if (label23.Text == "Settlement Process")
            {
                loadingProcess();
                lblSave.Text = "Settle";
            }
        }

        private void assetMode()
        {
            txtAssetType.Visible = false;
            cmbAssetType.Visible = true;
            cmbAssetType.Location = new Point(149, 47);
            cmbAssetType.Focus();

            txtAssetName.Visible = false;
            cmbSubCategory.Visible = true;
            cmbSubCategory.Location = new Point(149, 72);

            txtCatagory.Visible = false;
            cmbCatagory.Visible = true;
            cmbCatagory.Location = new Point(149, 96);

            txtQuantity.ReadOnly = false;
            txtQuantity.Text = "1";
            txtQuantity.BackColor = SystemColors.Window;
            txtRate.ReadOnly = false;
            txtRate.BackColor = SystemColors.Window;

            txtSalvageRate.ReadOnly = true;
            txtSalvageRate.BackColor = SystemColors.GradientInactiveCaption;
            txtSalvageValue.ReadOnly = true;
            txtSalvageValue.BackColor = SystemColors.GradientInactiveCaption;
            txtLifeTime.ReadOnly = true;
            txtLifeTime.BackColor = SystemColors.GradientInactiveCaption;

            dgvUnSettledAsset.Enabled = false;



            lblSave.Text = "Save";
            label23.Text = "Settlement Process";
        }

        private void cmbAssetType_TextChanged(object sender, EventArgs e)
        {
            cmbAssetType.TextChanged -= cmbAssetType_TextChanged;

            int exID;
            exID = Convert.ToInt32(cmbAssetType.SelectedValue.ToString());

            string query = @"select Sub_Category_Type_ID,Sub_Category_Type_Name 
                                    from SBP_Expense_Sub_Category_Type
                                    where ExpenseID=" + exID + " ";

            string query1 = @"select Category_ID,Category_Name from SBP_Expense_Category_Lookup
                                    where Category_ID in (select  Category_ID from SBP_Expense_Lookup 
                                    where Expense_ID="+exID+")";

            ExpenseTransactionBAL etb = new ExpenseTransactionBAL();
            DataTable dtSubCategory = new DataTable();
            DataTable dtCategoryName = new DataTable();
            dtCategoryName = etb.Get_Data(query1);
            cmbCatagory.DataSource = dtCategoryName;
            cmbCatagory.DisplayMember = "Category_Name";
            cmbCatagory.ValueMember = "Category_ID";
            
            //check
            //txtCatagory.Text = dtCategoryName.Rows[0][1].ToString();

            dtSubCategory = etb.Get_Data(query);
            if (dtSubCategory.Rows.Count > 0)
            {
                cmbSubCategory.Enabled = true;
                cmbSubCategory.DataSource = dtSubCategory;
                cmbSubCategory.DisplayMember = "Sub_Category_Type_Name";
                cmbSubCategory.ValueMember = "Sub_Category_Type_ID";
            }
            else
            {
                cmbSubCategory.Enabled = false;
                cmbSubCategory.DataSource = null;
            }

            cmbAssetType.TextChanged += cmbAssetType_TextChanged;
        }

        //double z = 0;
        //private void txtSalvageValue_TextChanged(object sender, EventArgs e)
        //{
        //    txtSalvageValue.TextChanged -= txtSalvageValue_TextChanged;

        //    if (txtSalvageRate.Text != "")
        //    {
        //        z = Convert.ToDouble(txtSalvageRate.Text);
        //        if (z == 0)
        //        {
        //            txtSalvageRate.Text = Convert.ToString(((Convert.ToDouble(txtSalvageValue.Text)/(Convert.ToDouble(txtCost.Text))*100)));
                    
        //        }
        //        else if (z == 1)
        //        {
        //            txtSalvageRate.Text = Convert.ToString(((Convert.ToDouble(txtSalvageValue.Text) / (Convert.ToDouble(txtCost.Text)) * 100)));

        //        }
        //        else if (z > 1)
        //        {
        //            if(txtSalvageValue.Text=="")
        //                {
        //                    txtSalvageValue.Text = "0.00";
        //                }
        //            txtSalvageRate.Text = Convert.ToString(((Convert.ToDouble(txtSalvageValue.Text) / (Convert.ToDouble(txtCost.Text)) * 100)));
        //        }
        //    }
        //    else
        //    {
        //        txtSalvageRate.Text = "";
        //        txtSalvageValue.Text = "0.00";
        //    }
        //    //double costPrice = Convert.ToDouble(txtCost.Text);
        //    //if(txtSalvageValue.Text=="")
        //    //{
        //    //    txtSalvageValue.Text = "0";
        //    //}
        //    //double SV = Convert.ToDouble(txtSalvageValue.Text);
        //    //txtSalvageRate.Text = Convert.ToString((SV/costPrice)*100);

        //    txtSalvageValue.TextChanged += txtSalvageValue_TextChanged;
        //}

        //double x = 0;
        //private void txtRate_TextChanged(object sender, EventArgs e)
        //{
        //    txtRate.TextChanged -= txtRate_TextChanged;

        //    if (txtRate.Text != "")
        //    {
        //        x = Convert.ToDouble(txtQuantity.Text);
        //        if (x == 0)
        //        {
        //            txtCost.Text = Convert.ToString(Convert.ToDouble(txtRate.Text) * (Convert.ToDouble(txtQuantity.Text)));
        //        }
        //        else if (x == 1)
        //        {
        //            txtCost.Text = Convert.ToString(Convert.ToDouble(txtRate.Text) * (Convert.ToDouble(txtQuantity.Text)));
                   
        //        }
        //        else if (x > 1)
        //        {
        //            txtCost.Text = Convert.ToString(Convert.ToDouble(txtRate.Text) * (Convert.ToDouble(txtQuantity.Text)));
        //        }
        //    }
        //    else
        //    {
        //        txtRate.Text = "";
        //        txtCost.Text = "";
        //    }            
        //    txtRate.TextChanged += txtRate_TextChanged;
        //}
       
        private void txtRate_TextChanged(object sender, EventArgs e)
        {
            int intTryParse;
            double doubleTryParse;

            if (txtRate.Text != "")
            {
                double rate = 0;
                if (double.TryParse(txtRate.Text, out doubleTryParse))
                    rate = doubleTryParse;

                int qty = 0;
                if (int.TryParse(txtQuantity.Text, out intTryParse))
                    qty = intTryParse;

                txtCost.Text = Convert.ToString(rate * qty);
            }
            else
            {
                txtRate.Text = "";
                txtCost.Text = "0";
            }
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            int intTryParse;
            double doubleTryParse;

            if (txtQuantity.Text != "")
            {
                int qty = 0;
                if (int.TryParse(txtQuantity.Text, out intTryParse))
                    qty = intTryParse;

                double rate = 0;
                if (double.TryParse(txtRate.Text, out doubleTryParse))
                    rate = doubleTryParse;

                txtCost.Text = Convert.ToString(rate * qty);
            }
            else
            {
                txtQuantity.Text = "";
                txtCost.Text = "0";
            }
        }
        private void cmbAssetType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (label23.Text == "Settlement Process")
            {
                if (e.KeyChar == 13)
                {
                   e.Handled = true;
                   cmbSubCategory.Focus();
                }
            }
        }

        private void txtAssetName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (label23.Text == "Settlement Process")
            {
                if (e.KeyChar == 13)
                {
                    e.Handled = true;
                    txtQuantity.Focus();
                }
            }
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (label23.Text == "Settlement Process")
            {
                if (e.KeyChar == 13)
                {
                    e.Handled = true;
                    txtRate.Focus();
                }
            }
        }

        private void label23_MouseHover(object sender, EventArgs e)
        {
            label23.ForeColor = System.Drawing.Color.Red;
        }

        private void label23_MouseLeave(object sender, EventArgs e)
        {
            label23.ForeColor = System.Drawing.Color.Navy;
        }

        double y = 0;
        private void txtSalvageRate_TextChanged(object sender, EventArgs e)
        {
            txtSalvageRate.TextChanged -= txtSalvageRate_TextChanged;
             if (txtSalvageRate.Text != "")
             {
                 y = Convert.ToDouble(txtSalvageRate.Text);
                 if (y == 0)
                 {
                     txtSalvageValue.Text = Convert.ToString(((Convert.ToDouble(txtCost.Text)) * (Convert.ToDouble(txtSalvageRate.Text))) / 100);
                     txtDepAmount.Text = Convert.ToString((Convert.ToDouble(txtCost.Text)) - (Convert.ToDouble(txtSalvageValue.Text)));
                 }
                 else if (y == 1)
                 {
                     txtSalvageValue.Text = Convert.ToString(((Convert.ToDouble(txtCost.Text)) * (Convert.ToDouble(txtSalvageRate.Text))) / 100);
                     txtDepAmount.Text = Convert.ToString((Convert.ToDouble(txtCost.Text)) - (Convert.ToDouble(txtSalvageValue.Text)));
                 }
                 else if (y > 1)
                 {
                     txtSalvageValue.Text = Convert.ToString(((Convert.ToDouble(txtCost.Text)) * (Convert.ToDouble(txtSalvageRate.Text))) / 100);
                     txtDepAmount.Text = Convert.ToString((Convert.ToDouble(txtCost.Text)) - (Convert.ToDouble(txtSalvageValue.Text)));
                 }
             }
             else
             {
                 txtSalvageRate.Text = "";         //Change
                 txtSalvageValue.Text = "0.00";
             }
             txtSalvageRate.TextChanged += txtSalvageRate_TextChanged;
        }

        private void txtSalvageValue_TextChanged(object sender, EventArgs e)        
        {
            txtSalvageValue.TextChanged -= txtSalvageValue_TextChanged;
            if(txtSalvageValue.Text != "")
            {
                double sv = Convert.ToDouble(txtSalvageValue.Text);
                double costP = Convert.ToDouble(txtCost.Text);
                if (sv == 0 && costP == 0) 
                {
                    txtSalvageRate.Text = "0.00";
                }
                else if (sv == 0 || costP == 0)
                {
                    txtSalvageRate.Text = "0.00";
                }
                else
                {
                    txtSalvageRate.Text = Convert.ToString((sv / costP) * 100);    //Problem
                }
                
            }
            else
            {
                txtSalvageRate.Text = "";   //Change
            }
            txtSalvageValue.TextChanged += txtSalvageValue_TextChanged;
        }

        //private void txtSalvageRate_TextChanged(object sender, EventArgs e)
        //{
        //    if (txtSalvageRate.Text != "")
        //    {
        //        double salVRate;
        //        double tPrice;

        //        tPrice = Convert.ToDouble(txtCost.Text);               
        //        salVRate = Convert.ToDouble(txtSalvageRate.Text);
        //        txtSalvageValue.Text = Convert.ToString((tPrice * salVRate) / 100);
        //    }
        //    else
        //    {
        //        txtSalvageRate.Text = "";
        //        txtSalvageValue.Text = "0.00";
        //    }
        //}
    }
}

