using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StockbrokerProNewArch
{
    public partial class DepRejectionReason : Form
    {
        public static string _rejectionReason = "";
        public DepRejectionReason()
        {
            InitializeComponent();
        }

        private void DepRejectionReason_Load(object sender, EventArgs e)
        {
            txtRejectionReason.Focus();
            lblMsg.Text = "Rejection Reason For Client Code: " + DepositApproval._rejectionCustCode;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            _rejectionReason = txtRejectionReason.Text;
            this.Close();
        }
    }
}
