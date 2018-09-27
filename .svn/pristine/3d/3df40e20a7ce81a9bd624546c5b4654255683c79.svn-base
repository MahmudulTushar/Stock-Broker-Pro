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

namespace StockbrokerProNewArch
{
    public partial class PaymentMediaMaturity : Form
    {
        public PaymentMediaMaturity()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                PaymentMaturityBO paymentMaturityBo=new PaymentMaturityBO();
                paymentMaturityBo.PaymentMedia = ddlPaymentMedia.Text;
                paymentMaturityBo.MaturityDays = Convert.ToInt32(txtMaturityDays.Text);
                paymentMaturityBo.EffectiveDate = dtEffectiveDate.Value;
                PaymentMaturityBAL paymentMaturityBal = new PaymentMaturityBAL();
                paymentMaturityBal.Insert(paymentMaturityBo);
                MessageBox.Show("Payment Media Maturity Information saved successfully.","Saved.");
                LoadGridData();
            }
            catch (Exception exc)
            {

                MessageBox.Show("Company Category can not changed.Error: " + exc.Message);
            }
        }

        private void LoadGridData()
        {
            PaymentMaturityBAL paymentMaturityBal = new PaymentMaturityBAL();
            DataTable datatable = paymentMaturityBal.GetGridInfo();
            dtgPaymentMaturityInfo.DataSource = datatable;
            dtgPaymentMaturityInfo.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            
        }

        private void PaymentMediaMaturity_Load(object sender, EventArgs e)
        {
            LoadGridData();
        }
    }
}
