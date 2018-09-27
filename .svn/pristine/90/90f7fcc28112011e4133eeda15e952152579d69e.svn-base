using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using BusinessAccessLayer.BO;
using DataAccessLayer;

namespace StockbrokerProNewArch
{
    public partial class frmPreDefineAmountOfLiabilities : Form
    {
        private DbConnection _dbConnection;
        ExpenseTransactionBAL BAL = new ExpenseTransactionBAL();
        double doubleTryParse;

        public frmPreDefineAmountOfLiabilities()
        {
            InitializeComponent();
        }

        private void frmPreDefineAmountOfLiabilities_Load(object sender, EventArgs e)
        {
            LoadcmbLiabilitiesName();
            gridviewLoad();
            RefreshAll();

            txtLiabilitiesName.Visible = false;
        }

        private void LoadcmbLiabilitiesName()
        {
            DataTable dt;
            dt = BAL.GetLiabilitiesName();
            cmbLiabilitiesName.ViewColumn = 0;
            cmbLiabilitiesName.Data = dt;
        }

        private bool Checkvalidation()
        {
           if (cmbLiabilitiesName.Text == "")
           {
               MessageBox.Show("Please Select Liability Name...");
               cmbLiabilitiesName.Focus();
               return true;
           }
           else if (txtPaymentAmount.Text == "")
           {
               MessageBox.Show("Please Write Amount...");
               txtPaymentAmount.Focus();
               return true;
           }
           else if (!double.TryParse(txtPaymentAmount.Text.Trim(), out doubleTryParse))
           {
               MessageBox.Show("Please Write Correct Formate...");
               txtPaymentAmount.Focus();
               return true;
           }
           else if(!(rbYearly.Checked || rbHalfYearly.Checked || rbQuarterly.Checked || rbMonthly.Checked))
           {
               MessageBox.Show("Select Period...");
               return true;
           }
           
           else return false;
        }
        private DefineLiabilitiesBO InitializeDLBO()
        {
            DefineLiabilitiesBO dlBO=new DefineLiabilitiesBO();
            //dlBO.Lib_Name=txtLiabilitiesName.Text;
            dlBO.Lib_Name = cmbLiabilitiesName.Text;
            if(rbYearly.Checked == true)
            {
                dlBO.Deduction_Period = rbYearly.Text;
            }
            else if (rbHalfYearly.Checked == true)
            {
                dlBO.Deduction_Period = rbHalfYearly.Text;
            }
            else if (rbQuarterly.Checked == true)
            {
                dlBO.Deduction_Period = rbQuarterly.Text;
            }
            else if (rbMonthly.Checked == true)
            {
                dlBO.Deduction_Period = rbMonthly.Text;
            }
                       
            dlBO.Payment_Amount = Convert.ToDouble(txtPaymentAmount.Text.Trim());
            dlBO.Remarks = txtRemarks.Text;
            dlBO.Status = "Settled";
            dlBO.Entry_Date = dtpSettledDate.Value;
            dlBO.Entry_By = GlobalVariableBO._userName;
            dlBO.Update_Date = dtpSettledDate.Value;
            dlBO.Update_By = GlobalVariableBO._userName;

            return dlBO;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Checkvalidation())
                return; 

            DefineLiabilitiesBO dlBO = new DefineLiabilitiesBO();
            ExpenseTransactionBAL etBAL = new ExpenseTransactionBAL();
            dlBO = InitializeDLBO();
            etBAL.saveSettledLiabilities(dlBO);
            MessageBox.Show("Liabilities predefinition Saved Successfully....", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            gridviewLoad();
            RefreshAll();
            //txtLiabilitiesName.Focus();
            cmbLiabilitiesName.Focus();
        }

        private void RefreshAll()
        {
            //txtLiabilitiesName.Text = "";
            cmbLiabilitiesName.Text = "";
            rbMonthly.Checked = false;
            rbYearly.Checked = false;
            txtPaymentAmount.Text = "";
            txtRemarks.Text = "";
            //txtLiabilitiesName.Focus();            
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;

            cmbLiabilitiesName.Focus();
        }

        private void gridviewLoad()
        {
            ExpenseTransactionBAL etBAL = new ExpenseTransactionBAL();
            string sqlQuery = @"SELECT [LibID] as Liability_ID
                                      ,[LibName] as Liability_Name
                                      ,[DeductionPeriod] as Period
                                      ,[PaymentAmount] as Amount
                                      ,[Remarks] as Remarks 
                                      , CONVERT(VARCHAR(11),[UpdateDate],106) as Last_Update   
                                  FROM [SBP_Database].[dbo].[SBP_LiabilitiesPreDefine]
                                  ORDER by Liability_ID desc";
            dgvPaybleExpense.DataSource = etBAL.Get_Data(sqlQuery);
            label8.Text = Convert.ToString(dgvPaybleExpense.Rows.Count);
        }

     
        private void cmbLiabilitiesName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                txtPaymentAmount.Focus();
                //rbYearly.Checked = true;
            }
        }
        private void cmbLiabilitiesName_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == 13)
            //{
            //    e.Handled = true;
            //    txtPaymentAmount.Focus();
            //}
        }

        private void txtPaymentAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                rbYearly.Focus();
            }
        }
       

        private void rbYearly_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==13)
            {
                e.Handled = true;
                btnSave.Focus();         
            }
        }
        private void rbHalfYearly_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==13)
            {
                e.Handled = true;
                btnSave.Focus();                
            }
        }
        private void rbMonthly_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                btnSave.Focus();
            }
        }
        private void rbQuarterly_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                btnSave.Focus();
            }
        }

      

        int libiID;
        private void btnView_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            btnUpdate.Enabled = true;
            try
            {
                if (dgvPaybleExpense.Rows.Count >0 )
                {
                    libiID = Int32.Parse(dgvPaybleExpense.SelectedRows[0].Cells[0].Value.ToString());

                    ExpenseTransactionBAL etBAL = new ExpenseTransactionBAL();
                    DataTable dt = new DataTable();
                    dt = etBAL.GetDataByLiabilitiesID(libiID);

                    if(dt.Rows.Count >0 )
                    { 
                        //txtLiabilitiesName.Text=dt.Rows[0]["Liability_Name"].ToString();
                        cmbLiabilitiesName.Text = dt.Rows[0]["Liability_Name"].ToString();
                        if (dt.Rows[0]["Period"].ToString() == "Monthly")
                        {
                            rbMonthly.Checked = true;
                        }
                        else if (dt.Rows[0]["Period"].ToString() == "Yearly")
                        {
                            rbYearly.Checked = true;
                        }
                        txtPaymentAmount.Text = dt.Rows[0]["Amount"].ToString();
                        txtRemarks.Text = dt.Rows[0]["Remarks"].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    gridviewLoad();
        //    RefreshAll(); 
        //}
        private DefineLiabilitiesBO InitializeDLBOForUpdate()
        {
            DefineLiabilitiesBO dlBO = new DefineLiabilitiesBO();
            
            dlBO.Update_Date = dtpSettledDate.Value;
            //dlBO.Lib_Name = txtLiabilitiesName.Text;
            dlBO.Lib_Name = cmbLiabilitiesName.Text;
            if (rbMonthly.Checked == true)
            {
                dlBO.Deduction_Period = rbMonthly.Text;
            }
            else
            {
                dlBO.Deduction_Period = rbYearly.Text;
            }
            dlBO.Payment_Amount = Convert.ToDouble(txtPaymentAmount.Text.Trim());
            dlBO.Remarks = txtRemarks.Text;
            dlBO.Status = "Settled";            
            dlBO.Update_Date = dtpSettledDate.Value;
            dlBO.Update_By = GlobalVariableBO._userName;

            return dlBO;
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {            
            if (Checkvalidation())
                return;

            DefineLiabilitiesBO dlBO = new DefineLiabilitiesBO();
            ExpenseTransactionBAL etBAL = new ExpenseTransactionBAL();
            dlBO = InitializeDLBOForUpdate();
            etBAL.UpdateSettledLiabilities(dlBO, libiID);
            MessageBox.Show("Liabilities predefinition Update Successfully....", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            gridviewLoad();
            RefreshAll();            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dtpSettledDate.Value = DateTime.Now;
            //txtLiabilitiesName.Text = "";
            cmbLiabilitiesName.Text = "";
            txtPaymentAmount.Text = "";
            txtRemarks.Text = "";
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }

       
    }
}
