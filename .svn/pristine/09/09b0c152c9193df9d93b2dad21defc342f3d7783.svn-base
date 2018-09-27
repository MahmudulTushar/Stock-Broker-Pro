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
    public partial class frm_IPOEFTReturn : Form
    {

        public static string cust_code = "";
        public static decimal Amount = 0M;
        public static string date = "";
        public static string ID = "";
        
        public frm_IPOEFTReturn(string custcode, decimal amount, string date)
        {
            InitializeComponent();
            this.Text = "EFT Return For IPO";
            IPOProcessBAL Bal = new IPOProcessBAL();
            DataTable dt = new DataTable();
            dt=   Bal.Get_EFT_Return_Data(custcode, amount, date);
            if (dt.Rows.Count>0)
            {
                dg_IPOEFTReturn.DataSource = dt;
            }
        }

        private void frm_IPOEFTReturn_Load(object sender, EventArgs e)
        {

        }

        private void dg_IPOEFTReturn_Click(object sender, EventArgs e)
        {
            cust_code = dg_IPOEFTReturn.SelectedRows.Cast<DataGridViewRow>().Select(c => c.Cells["Cust_Code"].Value.ToString()).FirstOrDefault();
            Amount = dg_IPOEFTReturn.SelectedRows.Cast<DataGridViewRow>().Select(c => Convert.ToDecimal(c.Cells["Amount"].Value)).FirstOrDefault();
            date = dg_IPOEFTReturn.SelectedRows.Cast<DataGridViewRow>().Select(c => c.Cells["Received_Date"].Value.ToString()).FirstOrDefault();
            ID = dg_IPOEFTReturn.SelectedRows.Cast<DataGridViewRow>().Select(c => c.Cells["ID"].Value.ToString()).FirstOrDefault();
            this.Close();
        }
    }
}
