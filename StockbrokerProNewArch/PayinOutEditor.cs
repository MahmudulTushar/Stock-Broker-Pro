using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;

namespace StockbrokerProNewArch
{
    public partial class PayinOutEditor : Form
    {
        public PayinOutEditor()
        {
            InitializeComponent();
        }

        private string _payLog;
        public string Paylog
        {
            get { return _payLog; }
            set { _payLog = value; }
        }


        private void PayinOutEditor_Load(object sender, EventArgs e)
        {
            LoadEditableData();
        }
        private void LoadEditableData()
        {
            PayInTradeBAL tradeFileBal = new PayInTradeBAL();
            DataTable data = tradeFileBal.ShowEditPayin();
            dgvData.DataSource = data;
            dgvData.Columns[5].Visible = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(dgvData.Rows.Count <= 0)
                return;

            int rowIndex = dgvData.SelectedRows[0].Index;
            if(rowIndex<0)
                return;

            int settleId = Convert.ToInt32(dgvData.Rows[rowIndex].Cells[0].Value);
            string cusCode = dgvData.Rows[rowIndex].Cells[1].Value.ToString();
            int quantity = Int32.Parse(dgvData.Rows[rowIndex].Cells[4].Value.ToString());

            SettleEditEntry settleEditEntry = new SettleEditEntry(settleId, cusCode,quantity);
            settleEditEntry.PayLog = _payLog;
            settleEditEntry.ISIN = dgvData.Rows[rowIndex].Cells[5].Value.ToString();
            settleEditEntry.ShowDialog();
            LoadEditableData();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddPayinout objPay = new frmAddPayinout();
            objPay.Text = "Add New Sattlement Information";
            objPay.PayLog =_payLog;
            objPay.ShowDialog();
            if(objPay.DialogOK==DialogResult.Yes)
            LoadEditableData();
        }

    }
}
