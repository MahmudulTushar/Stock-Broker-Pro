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
    public partial class RejectionReason : Form
    {
        public static string _rejectionReason = "";
        public RejectionReason()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            _rejectionReason = txtRejectionReason.Text;
            this.Close();
        }

        private void RejectionReason_Load(object sender, EventArgs e)
        {
            txtRejectionReason.Focus();
            lblMsg.Text = "Rejection Reason For Client Code: " + CheckRequisitionApproval._rejectionCustCode;
        }
    }
}
