using System;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;

namespace StockbrokerProNewArch
{
    public partial class TradeCustCodeEditOld : Form
    {
        private string _newCustCode;
        public TradeCustCodeEditOld()
        {
            InitializeComponent();
        }

        private void TradeCustCodeEdit_Load(object sender, EventArgs e)
        {
            LoadData();
            txtNewCustCode.Focus();
        }

        private void LoadData()
        {
            txtOldCustCode.Text = TradeFileProcessOld._oldCustCode;
            txtOldBO.Text = TradeFileProcessOld._oldBo;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(txtNewCustCode.Text.Trim()=="")
            {
                MessageBox.Show("Enter New Client Code.");
                return;
            }
            if (MessageBox.Show("Do you want to continue to Edit the Client Code?", "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    _newCustCode = txtNewCustCode.Text;
                    TradeOldBAL tradeOldBal = new TradeOldBAL();
                    tradeOldBal.UpdateClientCode(_newCustCode,txtOldCustCode.Text,TradeFileProcessOld._IdforUpdate);
                    MessageBox.Show("Client Code Update Done Successfully", "Success.");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Occured." + ex.Message);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
