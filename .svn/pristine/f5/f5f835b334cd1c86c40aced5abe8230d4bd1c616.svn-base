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

namespace StockbrokerProNewArch
{
    public partial class InternetUploadTradePrice : Form
    {
        private DataTable _dataTable;
        private string filePath = string.Empty;
        private string _menuName = string.Empty;
        public InternetUploadTradePrice(string menuName)
        {
            InitializeComponent();
            _menuName = menuName;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFetch_Click(object sender, EventArgs e)
        {
            if (_menuName != "")
            {
                if (ofdFileOpen.ShowDialog() == DialogResult.OK)
                    filePath = ofdFileOpen.FileName;
            }
            if (_menuName != "" && filePath != "")
            {
                FetchWebPriceData();
            }
            else if (_menuName == "")
            {
                FetchWebPriceData();
            }
        }
        private void FetchWebPriceData()
        {
            //string url = "http://webnew.dsebd.org/admin-real/mst.txt";
            string url = "http://www.dsebd.org/mst.txt";
            DateTime tradeDate = DateTime.Today.AddDays(+10);
            DataRow dataRow;
            string[] lines = null;
            string[] rowValues;

            _dataTable = new DataTable();
            try
            {
                if (_menuName == "")
                {
                    Uri uri = new Uri(url);
                    WebRequest req = WebRequest.Create(uri);
                    WebResponse resp = req.GetResponse();
                    Stream stream = resp.GetResponseStream();
                    StreamReader sr = new StreamReader(stream);

                    string webData = sr.ReadToEnd();
                    lines = Regex.Split(webData, "\r\n");
                }
                else if (_menuName != "" && filePath != "")
                {
                    lines = File.ReadAllLines(filePath);
                }
                //for (int i = 0; i < 10; ++i)
                //{
                //    _dataTable.Columns.Add(new DataColumn());
                //}
                //----------------------------------------------//
                //---------------------------------------------//
                _dataTable.Columns.Add(new DataColumn("Company"));
                _dataTable.Columns.Add(new DataColumn("Open Price"));
                _dataTable.Columns.Add(new DataColumn("High Price"));
                _dataTable.Columns.Add(new DataColumn("Low Price"));
                _dataTable.Columns.Add(new DataColumn("Close Price"));
                _dataTable.Columns.Add(new DataColumn("% Change"));
                _dataTable.Columns.Add(new DataColumn("Trade"));
                _dataTable.Columns.Add(new DataColumn("Volume"));
                _dataTable.Columns.Add(new DataColumn("Value(Mn)"));
                _dataTable.Columns.Add(new DataColumn("Trade Date"));

                foreach (string line in lines)
                {
                    if ((line.Trim()).StartsWith("TODAY'S SHARE MARKET"))
                    {
                        string[] datefield = Regex.Split(line, ":");
                        tradeDate = Convert.ToDateTime((datefield[1]).Trim());
                        break;
                    }
                }

                for (int j = 80; j < lines.Length - 50; j++)
                {
                    if (lines[j].TrimStart().StartsWith("PRICES IN ODDLOT TRANSACTIONS")) //(Close Price - YCP)"))//PRICES IN ODDLOT TRANSACTIONS
                    {
                        break;
                    }
                    
                    rowValues = SelectRow(lines[j]);
                    
                    if (rowValues != null)
                    {
                        dataRow = _dataTable.NewRow();
                        dataRow.ItemArray = rowValues;
                        dataRow[9] = tradeDate.ToShortDateString(); 
                        _dataTable.Rows.Add(dataRow);
                        //MessageBox.Show(company + " - " + openp + " - " + highp);
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return;
            }

            dgvPriceData.DataSource = _dataTable;
            lblTotalItem.Text = @"Total records : " + _dataTable.Rows.Count;
        }

        private string[] SelectRow(string arr_row)
        {
            
            string single_Spaced_String = Regex.Replace(arr_row, @"\s{2,}", " ");

            //string str = Regex.Replace(arr_row, "\r\n", "");
            //string str1 = Regex.Replace(str, "  ", " ");
            //str1 = Regex.Replace(str1, "   ", " ");
            //str1 = Regex.Replace(str1, "  ", " ");
            //str1 = Regex.Replace(str1, "  ", " ");

            string[] str2 = Regex.Split(single_Spaced_String.Trim(), " ");

            if (((arr_row).Length == 79 || (arr_row).Length == 80 || (arr_row).Length == 82) && (str2.Length == 9))
            {
                return str2;
            }
            else
            {
                return null;
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                if (_dataTable.Rows.Count > 0)
                {
                    TradePriceBAL tradePriceBal = new TradePriceBAL();
                    tradePriceBal.TruncateTradePriceInfo();
                    tradePriceBal.UploadWebPriceData(_dataTable, "SBP_Trade_Price_Temp");
                    MessageBox.Show("Web Trade Price has successfully uploaded.","Success.");
                    this.Close();
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("Trade Price Upload failed.Error:" + exp.Message);

            }
           
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            ValidateCompany();

            if(lbComapnyName.Items.Count>0)
            {
                this.Height = 649;
                btnUpload.Enabled =false;

            }

            else
            {
                btnUpload.Enabled = true;
                this.Height = 513;
            }

        }

        private void ValidateCompany()
        {
            try
            {
                TradePriceBAL tradePriceBal = new TradePriceBAL();
                DataTable companyDataTable = new DataTable();
                companyDataTable = tradePriceBal.ValidateCompany();
                if (companyDataTable.Rows.Count > 0)
                {
                    lbComapnyName.Items.Clear();
                    for (int i = 0; i < companyDataTable.Rows.Count; i++)
                    {
                        lbComapnyName.Items.Add(companyDataTable.Rows[i]["Instrument_Code"]);
                    }
                }
                else
                {
                    lbComapnyName.Items.Clear();
                }

            }
            catch (Exception exc)
            {

                MessageBox.Show(@"Company Validation Error." + exc.Message);
            }

        }

        private void InternetUploadTradePrice_Load(object sender, EventArgs e)
        {
            if(_menuName!="")
            {
                btnFetch.Text = @"Select a File";
                this.Text = @"Upload Trade Price From DSE Text File";
            }
            else
            {
                btnFetch.Text = @"Fetch Price Data";
                this.Text = @"Upload Trade Price From DSE Site";
            }
        }

    }
}
