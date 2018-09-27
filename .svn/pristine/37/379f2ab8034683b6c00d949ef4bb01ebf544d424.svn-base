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
    public partial class frmDseLeadger : Form
    {
        public frmDseLeadger()
        {
            InitializeComponent();
        }
        public DbConnection _dbConnection;
        public  DateTime FromDt;
        public  DateTime toDt;
        public DateTime durationToDate;
        public string proc;
        
        private void button1_Click(object sender, EventArgs e)
        {
            FromDt = FromDate.Value;
            toDt = Todate.Value;
            proc = @"RptDseShareLedger";
            DataTable data = new DataTable();
            _dbConnection = new DbConnection();
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@fromDate", SqlDbType.DateTime, FromDt.ToShortDateString());
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
            rptDseLedger r = new rptDseLedger();

            r.Database.Tables["dseLedg"].SetDataSource(data);

            //   crvRpt.ReportSource = null;


            dseLedgerViewer dlv = new dseLedgerViewer();
            dlv.crystalReportViewer1.ReportSource = r;
            dlv.Show();


         //   crystalReportViewer1.ReportSource = r;

        }

        private void frmDseLeadger_Load(object sender, EventArgs e)
        {

        }
//function for showing Payment Date Wise DSE Summary Ledger
        private void button2_Click(object sender, EventArgs e)
        {
            TradeSummeryBAL tradeSummeryBal = new TradeSummeryBAL();
            
            string query,Query2;
            FromDt = FromDate.Value;
            DateTime durationFromDate = FromDate.Value;
           // DateTime Frm = Convert.ToDateTime(FromDt);
            //query = @"select top 1 EventDate from SBP_Transactions where EventDate<'"+FromDt.ToShortDateString()+"' order by EventDate desc ";
            query = @"select top 1 EventDate from (select top 5 EventDate,ROW_NUMBER() over (Order by EventDate ) as u from SBP_Database.dbo.SBP_Transactions WHERE EventDate <'" + FromDt.ToShortDateString() + @"' group by EventDate Order by EventDate desc) as p order by u";
            DateTime PrevDayOfFrm=FromDt;
            string pvDt;
            DataTable DTPrevDayOfFrm = tradeSummeryBal.GetPrevFrmDate(query);
            //try
            //{
            //    _dbConnection.ConnectDatabase();
            //    DTPrevDayOfFrm = _dbConnection.ExecuteQuery(query);
            //}
            //catch (Exception)
            //{
            //    throw;
            //}
            if (DTPrevDayOfFrm.Rows.Count > 0)
            {
                pvDt = DTPrevDayOfFrm.Rows[0]["EventDate"].ToString();
                PrevDayOfFrm = Convert.ToDateTime(pvDt);
            }
            else
            {
                PrevDayOfFrm = FromDt;
            }
            toDt = Todate.Value;
            Query2 = @"select top 1 EventDate from SBP_Database.dbo.SBP_Transactions where EventDate>'" + toDt + @"' order by EventDate";
            DataTable to = tradeSummeryBal.GetPrevFrmDate(Query2);
            if (to.Rows.Count > 0)
            {
                string toDate = to.Rows[0]["EventDate"].ToString();
                toDt = Convert.ToDateTime(toDate);
            }
            else
            {
                toDt=Todate.Value;
            }
            // toDt = Todate.Value;
            durationToDate = Todate.Value;
            //Store Procedure to get Payment Date Share Ledger
            proc = @"RptExportDseShareLedger";
            DataTable data = new DataTable();
            _dbConnection = new DbConnection();
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@durationFromDate", SqlDbType.DateTime, durationFromDate.ToShortDateString());
                _dbConnection.AddParameter("@durationToDate", SqlDbType.DateTime, durationToDate.ToShortDateString());
                _dbConnection.AddParameter("@fromDate", SqlDbType.DateTime, PrevDayOfFrm.ToShortDateString());
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
            rptPayDseLedger r = new rptPayDseLedger();

            r.Database.Tables["payLedgDT"].SetDataSource(data);

            //   crvRpt.ReportSource = null;


            dseLedgerViewer Obj = new dseLedgerViewer();
            Obj.crystalReportViewer1.ReportSource = r;
            Obj.Show();
        }
    }
}
