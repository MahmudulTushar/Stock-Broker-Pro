using System;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using BusinessAccessLayer.Constants;

namespace StockbrokerProNewArch
{
    public partial class TradeCustCodeEditNew : Form
    {
        private string _newCustCode;
        private string MenuName;
        public TradeCustCodeEditNew(string MenuName_P)
        {
            InitializeComponent();
            MenuName = MenuName_P;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtNewCustCode.Text.Trim() == "")
            {
                MessageBox.Show("Enter New Client Code.");
                return;
            }
            if (MessageBox.Show("Do you want to continue to Edit the Client Code?", "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {   
                    _newCustCode = txtNewCustCode.Text;
                    TradeBAL tradeBal = new TradeBAL();
                    if (MenuName == Indication_Forms_Title.TradeCust_CodeEditNew_MSAPlus)
                    {
                        tradeBal.UpdateClientCode(_newCustCode, txtOldCustCode.Text, TradeFileProcess._IdforUpdate);
                    }
                    else if (MenuName == Indication_Forms_Title.TradeCust_CodeEditNew_FlexTrade)
                    {
                        tradeBal.UpdateClientCode_FlexTrade(_newCustCode, txtOldCustCode.Text, TradeFileProcess_FlexTrade._IdforUpdate);
                    }
                    MessageBox.Show("Client Code Update Done Successfully", "Success.");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Occured." + ex.Message);
                }
            }
        }

        private void TradeCustCodeEditNew_Load(object sender, EventArgs e)
        {
            LoadData();
            txtNewCustCode.Focus();
        }

        private void LoadData()
        {
            if (MenuName == Indication_Forms_Title.TradeCust_CodeEditNew_MSAPlus)
            {
                txtOldCustCode.Text = TradeFileProcess._oldCustCode;
                txtOldBO.Text = TradeFileProcess._oldBo;
            }
            else if (MenuName == Indication_Forms_Title.TradeCust_CodeEditNew_FlexTrade)
            {
                txtOldCustCode.Text = TradeFileProcess_FlexTrade._oldCustCode;
                txtOldBO.Text = TradeFileProcess_FlexTrade._oldBo;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
