using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using BusinessAccessLayer.Constants;

namespace StockbrokerProNewArch
{
    public partial class frm_IPOMoneyRefundProcess : Form
    {
        string MenuName;
        
        public frm_IPOMoneyRefundProcess(string P_MenuName)
        {
            InitializeComponent();
            MenuName = P_MenuName;
            this.Text = MenuName;
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void LoadCombo()
        {
            if (MenuName == Indication_Forms_Title.IPOMoneyRefund_ByTrasfer)
            {
                IPOProcessBAL ipoBal = new IPOProcessBAL();
                DataTable dt = ipoBal.GetIPOSessionALL();
                cmb_SessionName.DataSource = dt;
                cmb_SessionName.DisplayMember = "Company_Name";
                cmb_SessionName.ValueMember = "ID";
                cmb_SessionName.SelectedIndex = -1;
            }
            else if (MenuName == Indication_Forms_Title.IPOMoneyRefund_ByBankTransaction)
            {
                IPOProcessBAL ipoBal = new IPOProcessBAL();
                DataTable dt = ipoBal.GetIPOSessionALL();
                cmb_SessionName.DataSource = dt;
                cmb_SessionName.DisplayMember = "Company_Name";
                cmb_SessionName.ValueMember = "ID";
                cmb_SessionName.SelectedIndex = -1;
            }
        }
        private void LoadGrid()
        {
            if (MenuName == Indication_Forms_Title.IPOMoneyRefund_ByTrasfer)
            {
                IPOProcessBAL ipoBal = new IPOProcessBAL();
                int intTryParse = 0;
                int SessionIDTemp = 0;
                if (int.TryParse(txt_SessionID.Text, out intTryParse))
                {
                    SessionIDTemp = intTryParse;
                }

                DataTable dt = ipoBal.GetRefundInformation_ForTransfer(SessionIDTemp);
                dg_MoneyRefund.DataSource = dt;
            
            }
            else if (MenuName == Indication_Forms_Title.IPOMoneyRefund_ByBankTransaction)
            {
                IPOProcessBAL ipoBal = new IPOProcessBAL();
                int intTryParse = 0;
                int SessionIDTemp = 0;
                if (int.TryParse(txt_SessionID.Text, out intTryParse))
                {
                    SessionIDTemp = intTryParse;
                }

                DataTable dt = ipoBal.GetRefundInformation_ForBankTransfer(SessionIDTemp);
                dg_MoneyRefund.DataSource = dt;
            }

        }

        private void btn_GetApplication_Click(object sender, EventArgs e)
        {
            try
            {
                LoadGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmb_SessionName_SelectedIndexChanged(object sender, EventArgs e)
        {
            IPOProcessBAL ipoBal = new IPOProcessBAL();
            if (cmb_SessionName.ValueMember != string.Empty)
            {

                int id = Convert.ToInt32(cmb_SessionName.SelectedValue);
                txt_SessionName.Text = ipoBal.GetIPOSessionName_CompanyName_BySessionID(id);
                txt_SessionID.Text = Convert.ToString(id);
            }
        }

        private void frm_IPOMoneyRefundProcess_Load(object sender, EventArgs e)
        {
            LoadCombo();
        }

        private void btn_Process_Click(object sender, EventArgs e)
        {
            try
            {
                if (MenuName == Indication_Forms_Title.IPOMoneyRefund_ByTrasfer)
                {
                    IPOProcessBAL ipoBal = new IPOProcessBAL();
                    int intTryParse = 0;
                    int SessionIDTemp = 0;
                    if (int.TryParse(txt_SessionID.Text, out intTryParse))
                    {
                        SessionIDTemp = intTryParse;
                    }

                    ipoBal.RefundProcess_ForTransfer(SessionIDTemp);
                    LoadGrid();
                    MessageBox.Show("Refund SuccessFully Done");
                    
                }
                else if (MenuName == Indication_Forms_Title.IPOMoneyRefund_ByBankTransaction)
                {
                    IPOProcessBAL ipoBal = new IPOProcessBAL();
                    int intTryParse = 0;
                    int SessionIDTemp = 0;
                    if (int.TryParse(txt_SessionID.Text, out intTryParse))
                    {
                        SessionIDTemp = intTryParse;
                    }

                    ipoBal.RefundProcess_ForBankTransfer(SessionIDTemp);
                    LoadGrid();
                    MessageBox.Show("Refund SuccessFully Done");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dg_MoneyRefund_DataSourceChanged(object sender, EventArgs e)
        {
            lbl_Count_Grid.Text = "Count: "+dg_MoneyRefund.Rows.Count;
        }

       
    }
}
