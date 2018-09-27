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
    public partial class frmRejectedReasonPaymentOCC : Form
    {
        public frmRejectedReasonPaymentOCC()
        {
            InitializeComponent();
        }

        private DialogResult _rejectedReault;

        public DialogResult RejectedReault
        {
            get { return _rejectedReault; }
            set { _rejectedReault = value; }
        }

        public string RejectedReason
        {
            get { return _rejectedReason; }
            set { _rejectedReason = value; }
        }

        public string VoucherNo
        {
            get { return _voucherNo; }
            set { _voucherNo = value; }
        }


        private string _rejectedReason;

        private string _voucherNo;

        private void button1_Click(object sender, EventArgs e)
        {
            _rejectedReault = DialogResult.No;
            Close();
        }

        private void frmRejectedReasonPaymentOCC_Load(object sender, EventArgs e)
        {
            groupBox1.Text = "Rejected Reason || Voucher : " + _voucherNo;
        }

        private void btnRejected_Click(object sender, EventArgs e)
        {
            if(txtRejectedReason.Text.Trim()==String.Empty && MessageBox.Show("Do you want to Rejected Payment \nOCC Information without any  Reason.","",MessageBoxButtons.YesNo,MessageBoxIcon.Information)==System.Windows.Forms.DialogResult.Yes)
            {
                _rejectedReault = DialogResult.Yes;
                _rejectedReason = txtRejectedReason.Text;
                Close();
            }

            else if(txtRejectedReason.Text.Trim()!=String.Empty)
            {
                _rejectedReault = DialogResult.Yes;
                _rejectedReason = txtRejectedReason.Text;
                Close();
            }

            
        }
    }
}
