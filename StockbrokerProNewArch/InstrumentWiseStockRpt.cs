using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;
using DataAccessLayer;
using BusinessAccessLayer.BAL;
using BusinessAccessLayer.BO;
using BusinessAccessLayer.Constants;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using StockbrokerProNewArchForm;
using DataAccessLayer;

namespace StockbrokerProNewArch
{
    public partial class InstrumentWiseStockRpt : Form
    {
        public InstrumentWiseStockRpt()
        {
            InitializeComponent();
        }

        public DbConnection _dbConnection;
        public DateTime FromDt;
        public DateTime toDt;
        public DateTime durationToDate;
        public string proc;
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnRpt_Click(object sender, EventArgs e)
        {
           
            toDt = to.Value;
            proc = @"InstrumentWiseStockStatusReport";
            DataTable data = new DataTable();
            _dbConnection = new DbConnection();
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
              //  _dbConnection.AddParameter("@fromDate", SqlDbType.DateTime, FromDt.ToShortDateString());
                _dbConnection.AddParameter("@toDate", SqlDbType.DateTime, toDt.ToShortDateString());
                data = _dbConnection.ExecuteProQuery(proc);
            }
            catch (Exception)
            {

                throw;
            }

            finally
            {
                _dbConnection.CloseDatabase();
            }
             StockStatusRpt r = new StockStatusRpt();

          //  r.Database.Tables["InstRpt"].SetDataSource(data);

            //   crvRpt.ReportSource = null;

            r.SetDataSource(data);
            dseLedgerViewer dlv = new dseLedgerViewer();
            dlv.crystalReportViewer1.ReportSource = r;
            dlv.Show();
        }
    }
}
