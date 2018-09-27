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
    public partial class CashBackPreview : Form
    {
        public CashBackPreview()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CashBackPreview_Load(object sender, EventArgs e)
        {
            LoadGridData();
        }

        private void LoadGridData()
        {
            CashBackRegBAL cashBackRegBal = new CashBackRegBAL();
            DataTable datatable = cashBackRegBal.GetCashbackProcessGridInfo(ProcessCashback._lastCashBackDate);
            dtgCashBackHistory.DataSource = datatable;
            dtgCashBackHistory.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

        }
    }
}
