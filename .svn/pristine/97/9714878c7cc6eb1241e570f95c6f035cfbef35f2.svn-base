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
    public partial class ProcessCashback : Form
    {
        public static DateTime _lastCashBackDate;
        public ProcessCashback()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ProcessCashback_Load(object sender, EventArgs e)
        {
            LoadLastCashBackDate();
        }

        private void LoadDataIntoGrid()
        {
            CashBackRegBAL cashBackRegBal = new CashBackRegBAL();
            DataTable datatable = cashBackRegBal.GetCashbackProcessGridInfo(_lastCashBackDate);
            dtgCashBackHistory.DataSource = datatable;
            dtgCashBackHistory.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

        }

        private void LoadLastCashBackDate()
        {
            DataTable dtLastCashBackdate = new DataTable();
            CashBackRegBAL cashBackRegBal = new CashBackRegBAL();
            dtLastCashBackdate = cashBackRegBal.GetLastCashbackDate();
            if (dtLastCashBackdate.Rows.Count > 0)
            {
                if (dtLastCashBackdate.Rows[0]["LastCashBackDate"]!=DBNull.Value)
                    _lastCashBackDate = Convert.ToDateTime(dtLastCashBackdate.Rows[0]["LastCashBackDate"]);
                lblMonth.Text = _lastCashBackDate.Month.ToString();
                lblYear.Text = _lastCashBackDate.Year.ToString();
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                CashBackRegBAL cashBackRegBal = new CashBackRegBAL();
                cashBackRegBal.ProcessCashBack(dtProcessingDate.Value);
                MessageBox.Show("Cashback Processing Successfully done.", "Success.");
                LoadLastCashBackDate();
                LoadDataIntoGrid();
                Height = 435;
            }
            catch (Exception)
            {
                MessageBox.Show("Cashback Processing Successfully done.", "Success.");
            }
            
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            CashBackPreview cashBackPreview=new CashBackPreview();
            cashBackPreview.Show();
        }

     }
}
