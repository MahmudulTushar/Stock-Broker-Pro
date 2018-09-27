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
    public partial class LatestSharePriceNew : Form
    {
        public LatestSharePriceNew()
        {
            InitializeComponent();
        }
        private int _timeInterval;
        private void LatestSharePriceNew_Load(object sender, EventArgs e)
        {
            InitDataGrid();
            _timeInterval = GetTimeInterval();
            timerRefreshment.Interval = _timeInterval;
            timerRefreshment.Start();
            LoadDataIntoGrid();
        }

        private void LoadDataIntoGrid()
        {
           
            LatestTradePriceBAL latestTradePriceBal = new LatestTradePriceBAL();
            DataTable dataTable = latestTradePriceBal.GetLatestTradePriceNew();
            int r = 0, c= 0;
            foreach (DataRow dataRow in dataTable.Rows)
            {
                if (r % 2 == 0)
                {
                    dtgLatestSharePrice.Rows[r].Cells[c].Style.BackColor = Color.FromArgb(220,230,255);
                    dtgLatestSharePrice.Rows[r].Cells[c + 1].Style.BackColor = Color.FromArgb(220, 230, 255);
                }

                dtgLatestSharePrice.Rows[r].Cells[c].Value = dataRow[0];
                dtgLatestSharePrice.Rows[r].Cells[c+1].Value = Convert.ToDouble(dataRow[1]).ToString("N");

                dtgLatestSharePrice.Columns[c + 1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                double insValue = Convert.ToDouble(dataRow[2]);
                double priceValue = Convert.ToDouble(dataRow[3]);

                if (insValue > 0)
                {
                    dtgLatestSharePrice.Rows[r].Cells[c].Style.ForeColor = Color.Green;
                }
                else if(insValue<0)
                {
                    dtgLatestSharePrice.Rows[r].Cells[c].Style.ForeColor = Color.Red;
                }
                else
                {
                    //dtgLatestSharePrice.Rows[r].Cells[c].Style.ForeColor = Color.FromArgb(100, 100, 200);
                }


                if (priceValue > 0)
                {
                    dtgLatestSharePrice.Rows[r].Cells[c+1].Style.ForeColor = Color.Green;
                }
                else if (priceValue < 0)
                {
                    dtgLatestSharePrice.Rows[r].Cells[c+1].Style.ForeColor = Color.Red;
                }
                else
                {
                    //dtgLatestSharePrice.Rows[r].Cells[c + 1].Style.ForeColor = Color.FromArgb(65, 50, 200);
                }

                ++r;
                if (r > 30)
                {
                    r = 0;
                    c+=3;
                    if(c>=18)
                        break;
                }
            }
            dtgLatestSharePrice.Rows[0].Cells[2].Selected = true;
            //dtgLatestSharePrice.Columns[0].DefaultCellStyle.BackColor = Color.LightSlateGray;
            //dtgLatestSharePrice.Columns[1].DefaultCellStyle.BackColor = Color.LightSteelBlue;
        }

        private void InitDataGrid()
        {
            for (int i = 0; i <= 30; i++)
            {
                dtgLatestSharePrice.Rows.Add();
            }
        }

        private int GetTimeInterval()
        {
            DataTable dataTable=new DataTable();
            LatestTradePriceBAL latestTradePriceBal=new LatestTradePriceBAL();
            dataTable=latestTradePriceBal.GetTimeInterval();
            if (dataTable.Rows.Count > 0)
                return Convert.ToInt32(dataTable.Rows[0][0]);
            else
            {
                return 240000;
            }
        }

        private void timerRefreshment_Tick(object sender, EventArgs e)
        {
            LoadDataIntoGrid();
        }

        private void dtgLatestSharePrice_SelectionChanged(object sender, EventArgs e)
        {
            dtgLatestSharePrice.RowsDefaultCellStyle.SelectionForeColor = dtgLatestSharePrice.Rows[dtgLatestSharePrice.CurrentCell.RowIndex].Cells[
                dtgLatestSharePrice.CurrentCell.ColumnIndex].Style.ForeColor;
        }
    }
}
