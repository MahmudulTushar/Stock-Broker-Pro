using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.BO;
using BusinessAccessLayer.BAL;

namespace StockbrokerProNewArch
{
    public partial class frmAddopexPurpose : Form
    {
        public frmAddopexPurpose()
        {
            InitializeComponent();
        }

        private string _expenseType;
        public String ExpenseType
        {
            get { return _expenseType; }
            set { _expenseType= value; }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void btmAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPurpose.Text.Trim() != String.Empty)
                    SavePurposeName();

                else
                {
                    MessageBox.Show("Purpose Name Required.","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    txtPurpose.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SavePurposeName()
        {
            try
            {
                OPexPurposeBO objOpexpurposeBO = new OPexPurposeBO();
                objOpexpurposeBO.OpexPurpose = txtPurpose.Text;
                objOpexpurposeBO.ExpenseType = _expenseType;
                

                OpexBAL objOpexBal = new OpexBAL();

                if(_expenseType!=String.Empty)
                objOpexBal.InsertOpexPurpose(objOpexpurposeBO);

                MessageBox.Show("Secessfully add new Purpose.","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.Close();
             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmAddopexPurpose_Load(object sender, EventArgs e)
        {
            OpexBAL objOpex = new OpexBAL();
            try
            {
                lblTotalCategory.Text = "Existing Category : " + objOpex.GetTotalCategory().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
