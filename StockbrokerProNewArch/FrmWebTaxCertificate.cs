using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;

namespace StockbrokerProNewArch
{
    public partial class FrmWebTaxCertificate : Form
    {

        EmailSyncBAL objEmailSyncBAL = new EmailSyncBAL();
        public delegate void DataToWebTaxCertificate(EmailSyncBAL bo);
        public DataToWebTaxCertificate pp_deligate;
        public FrmWebTaxCertificate()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void LoadData()
        {
            DataTable dt = new DataTable();
            dt = objEmailSyncBAL.LoadTax_Certification();
            dtgTaxCertification.DataSource = dt;
            dtgTaxCertification.Columns["ID"].Visible = false;
        }

        private void FrmWebTaxCertificate_Load(object sender, EventArgs e)
        {
            LoadData();
            btnFetch.Enabled = false;
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dtgTaxCertification.Rows.Count; i++)
            {
                if (dtgTaxCertification.Rows[i].Selected == true)
                {
                    objEmailSyncBAL.CustCode = dtgTaxCertification.Rows[i].Cells["Cust_Code"].Value.ToString();
                    DateTime Date = Convert.ToDateTime(dtgTaxCertification.Rows[i].Cells["Year"].Value + "-07-" + "01");
                    objEmailSyncBAL.ID = Convert.ToInt32(dtgTaxCertification.Rows[i].Cells["ID"].Value.ToString());
                    objEmailSyncBAL.Year = Date;                  
                    pp_deligate(objEmailSyncBAL);
                }
            }
            this.Close();
        }
    }
}
