using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using StockbrokerProNewArch.Classes;

namespace StockbrokerProNewArch
{
    public partial class DataLoader : Form
    {
        private DataTable _dataTable;
        private int _counter;
        public DataLoader()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            FetchData();
        }

        /*private void FetchData()
        {
            string url = "http://webnew.dsebd.org/admin-real/datafile/quotes.txt";
            DateTime tradeDate = DateTime.Today.AddDays(+10);

            _dataTable = new DataTable();
            _dataTable.Columns.Add(new DataColumn("Company"));
            _dataTable.Columns.Add(new DataColumn("Open Price"));
            DataRow dataRow;
            try
            {
                WebRequest req = WebRequest.Create(url);
                WebResponse resp = req.GetResponse();
                Stream stream = resp.GetResponseStream();
                StreamReader sr = new StreamReader(stream);

                string webData = sr.ReadToEnd();
                webData = webData.Replace("\n", ";");
                webData = webData.Replace("\t", "");
                webData = webData.Replace("  ", ",");

                string[] lines = webData.Split(';');

                foreach (string line in lines)
                {
                    string[] words = line.Split(',');
                    if (words.Length == 2)
                    {
                        dataRow = _dataTable.NewRow();
                        dataRow.ItemArray = words;
                        _dataTable.Rows.Add(dataRow);
                    }
                }
                sr.Close();
                GeneratePLTP();

                lbLastUpdated.Text = "Last Updated : " + DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss tt");
                string[] data = new string[2] {DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss tt"),"Success"};
                dgvLog.Rows.Add(data);
            }
            catch
            {
                string[] data = new string[2] { DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss tt"), "Error" };
                dgvLog.Rows.Add(data); 
            }
        }*/

        private void FetchData()
        {
            CommonBAL objBal = new CommonBAL();
            string url = "http://www.dsebd.org/index.php";
            DateTime tradeDate = objBal.GetCurrentServerDate().AddDays(+10);

            _dataTable = new DataTable();
            _dataTable.Columns.Add(new DataColumn("Company"));
            _dataTable.Columns.Add(new DataColumn("SaleP"));
            _dataTable.Columns.Add(new DataColumn("Chng"));
            _dataTable.Columns.Add(new DataColumn("Per"));
            DataRow dataRow;
            try
            {
                WebRequest req = WebRequest.Create(url);
                WebResponse resp = req.GetResponse();
                Stream stream = resp.GetResponseStream();
                StreamReader sr = new StreamReader(stream);

                string webData = sr.ReadToEnd();

                HTMLSearchResult searcher = new HTMLSearchResult();
                HTMLSearchResult r;
                r = searcher.GetTagData(webData, "marquee", 1).GetTagData("tr");

                webData = HtmlRemoval.StripTagsCharArray(r.TAGData);
                webData = webData.Replace("&nbsp", "");
                webData = webData.Replace(";;;;", ";");
                webData = webData.Replace(";;;", ";");

                string[] lines = webData.Split('%');

                foreach (string line in lines)
                {
                    string[] words = line.Split(';');
                    if (words.Length == 4)
                    {
                        dataRow = _dataTable.NewRow();
                        dataRow.ItemArray = words;
                        _dataTable.Rows.Add(dataRow);
                    }
                }
                sr.Close();
                GeneratePLTP();

                lbLastUpdated.Text = "Last Updated : " + DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss tt");
                string[] data = new string[2] { DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss tt"), "Success" };
                dgvLog.Rows.Add(data);
            }
            catch
            {
                string[] data = new string[2] { DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss tt"), "Error" };
                dgvLog.Rows.Add(data);
            }
        }

        private void GeneratePLTP()
        {
            DataLoaderBAL dataLoaderBal = new DataLoaderBAL();
            dataLoaderBal.InsertDataGeneratePLTP(_dataTable);
        }

        private void timerFetchCount_Tick(object sender, EventArgs e)
        {
            lbUpdateCount.Text = _counter.ToString();
            if(_counter < 0)
            {
                lbUpdateCount.Text = "Fetching...";
                lbUpdateCount.Refresh();
                timerFetchCount.Stop();
                FetchData();
                ResetCountValue();
                timerFetchCount.Start();
            }
            --_counter;
        }

        private void DataLoader_Load(object sender, EventArgs e)
        {
            ResetCountValue();
            timerFetchCount.Start();
        }

        private void numInterval_ValueChanged(object sender, EventArgs e)
        {
            ResetCountValue();
        }

        private void ResetCountValue()
        {
            _counter = Convert.ToInt16(numInterval.Value);
        }

        private void chkAutoFetch_CheckedChanged(object sender, EventArgs e)
        {
            if(chkAutoFetch.Checked)
            {
                ResetCountValue();
                timerFetchCount.Start();
            }
            else
            {
                ResetCountValue();
                lbUpdateCount.Text = "Stopped";
                timerFetchCount.Stop();
            }
        }
    }
}
