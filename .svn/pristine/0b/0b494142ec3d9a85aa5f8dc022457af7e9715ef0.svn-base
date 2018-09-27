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
    public partial class frm_Accrued_Interest : Form
    {
        public frm_Accrued_Interest()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            InitialDataProcessingBAL initialDataProcessingBal = new InitialDataProcessingBAL();
            initialDataProcessingBal.ExecuteProcess_Accrude(Convert.ToDateTime(dtFromDate.Value),Convert.ToDateTime(dtToDate.Value));           
            MessageBox.Show("Data Processed Successfully", "Success.", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
