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
using BusinessAccessLayer.BO;
using StockbrokerProNewArch;
using System.Reflection;
using System.Xml;

namespace StockbrokerProNewArch
{
    public partial class SattleNewFile : Form
    {
        private DataTable TradeData;        
        private bool _isOldTradeFile;

        public bool IsOldTradeFile
        {
            get { return _isOldTradeFile; }
            set { _isOldTradeFile = value; }
        }

        public SattleNewFile()
        {
            InitializeComponent();
            
            //Default Value Assign
            _isOldTradeFile = true;
        }

      
        //private void UploadProcess()
        //{
        //    DataTable tradeDataTable;
        //    PayInTradeBAL tradeBal = new PayInTradeBAL(); 
            
        //    //Updated By Shahrior on May 31 2012
        //    if (!IsOldTradeFile)
        //    {
        //        tradeDataTable = ProcessTradeFile(txtFileLocation.Text);
        //        tradeBal.TruncateTradeInfo();
        //        tradeBal.SaveProcessedTradeInfo(tradeDataTable, "SBP_Trade_Temp");
        //    }
        //    else
        //    {
        //        tradeDataTable = ProcessOldTradeFile(txtFileLocation.Text);
        //        tradeBal.TruncateTradeInfoOld();
        //        tradeBal.SaveProcessedTradeInfoOld(tradeDataTable, "SBP_Trade_Temp_Old");                
        //    }
        //    //End Updated
        //}

        private DataTable UploadProcess()
        {
            //DataTable tradeDataTable;
            //tradeDataTable = ProcessTradeFile(txtFileLocation.Text);
            TradeBAL tradeBal = new TradeBAL();
            tradeBal.TruncateTradeInfo();
            tradeBal.SaveProcessedTradeTemp_ByInsertQuery(TradeData);
            return TradeData;
        }

        private DataTable ProcessTradeFile(string filePath)
        {
            string lineText;
            string[] tempValue;
            char proChar = '~';
            StreamReader streamReader = new StreamReader(filePath);
            DataTable dataTable = new DataTable();
            DataRow dataRow;
            lineText = streamReader.ReadLine();
            tempValue = lineText.Split(proChar);

            for (int i = 0; i < tempValue.Length; ++i)
            {
                dataTable.Columns.Add(new DataColumn());
            }

            do
            {
                string[] values = lineText.Split(proChar);
                dataRow = dataTable.NewRow();
                values[7] = CommonMethodBO.GetDateFormat(values[7]).ToShortDateString();
                //values[8] = CommonMethodBO.GetDateFormat(values[8]).ToShortDateString();
                dataRow.ItemArray = values;
                dataTable.Rows.Add(dataRow);
                lineText = streamReader.ReadLine();
            } while (lineText != null);

            return dataTable;
        }
        private DataTable ProcessOldTradeFile(string filePath)
        {
            string lineText;
            string[] tempValue;
            char proChar = '|';
            StreamReader streamReader = new StreamReader(filePath);
            DataTable dataTable = new DataTable();
            DataRow dataRow;
            lineText = streamReader.ReadLine();
            tempValue = lineText.Split(proChar);

            for (int i = 0; i < tempValue.Length; ++i)
            {
                dataTable.Columns.Add(new DataColumn());
            }

            do
            {
                string[] values = lineText.Split(proChar);
                dataRow = dataTable.NewRow();
                values[8] = CommonMethodBO.GetDateFormat(values[8]).ToShortDateString();
                dataRow.ItemArray = values;
                dataTable.Rows.Add(dataRow);
                lineText = streamReader.ReadLine();
            } while (lineText != null);

            return dataTable;
        }
        
        private void btnStartImport_Click(object sender, EventArgs e)
        {
           

                if (ValidateFeild())
                {
                    try
                    {
                        SetTradeFiles_FlexTrade();
                        DataTable dtTradeFileData = new DataTable();
                        CommonBAL commonBal = new CommonBAL();

                        UploadProcess();
                        SattleProcess payInProcessOld = new SattleProcess();
                        payInProcessOld.IsLoadOldTradeFile = IsOldTradeFile;
                        payInProcessOld.ShowDialog();
                        this.Hide();
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show("Error Occured." + exc.Message);
                    }
                }
           
        }
        private bool ValidateFeild()
        {
            if (txtFileLocation.Text.Length.Equals(0))
            {
                MessageBox.Show("Trade File location is a required field.");
                return false;
            }
            return true;
        }

        private void btnFileLocationBrowser_Click(object sender, EventArgs e)
        {
            if (ofdFileOpen.ShowDialog() == DialogResult.OK)
                txtFileLocation.Text = ofdFileOpen.FileName;
        }

        private void SetTradeFiles_FlexTrade()
        {

            try
            {
                string FileLocation = txtFileLocation.Text;
                Assembly asm = Assembly.GetExecutingAssembly();
                //string currentLocation = "C:\\e2eTechnology\\Stock Broker Pro\\Source Code\\Shahrior_SBP_Pro_22_Oct_2014\\Shahrior_SBP_Pro\\SBPXMLSchema";//asm.Location;
                //string currentLocation = "D:\\Shahrior Dev\\Shahrior_SBP_Pro\\SBPXMLSchema";//asm.Location;
                //string currentLocation = Directory.GetCurrentDirectory();// asm.Location.Replace("Stock Broker Pro.exe", "");
                string currentLocation = "\\\\150.1.122.31\\Release For SBP\\SBPXsdFiles";
                string fileLocation = FileLocation;

                XmlDocument xDoc = new XmlDocument();
                xDoc.Schemas.Add(null, currentLocation + "\\Flextrade-BOS-Trades.xsd");
                //xDoc.Schemas.Add(null, "C:\\e2eTechnology\\Flex Trade\\Flex Trade\\140919 Flex XML schema 0.7.4\\Flextrade-BOS-Trades.xsd");
                xDoc.Load(fileLocation);
                xDoc.Validate(new System.Xml.Schema.ValidationEventHandler(SchemaValidation));

                DataSet ds = new DataSet();
                ds.ReadXml(new XmlNodeReader(xDoc));
                TradeBAL bal = new TradeBAL();
                DataTable tempDetails = ds.Tables["Detail"];
                DataTable Details = ds.Tables["Detail"];

                for (int i = 0; i < tempDetails.Rows.Count; i++)
                {
                    try
                    {
                        Details.Rows[i]["Date"] = Convert.ToString(tempDetails.Rows[i]["Date"]).Substring(0, 4)
                            + "-" + Convert.ToString(tempDetails.Rows[i]["Date"]).Substring(4, 2)
                            + "-" + Convert.ToString(tempDetails.Rows[i]["Date"]).Substring(6, 2);

                        Details.Rows[i]["Time"] = Convert.ToString(tempDetails.Rows[i]["Time"]) == "-" ? "" : Convert.ToString(tempDetails.Rows[i]["Time"]);
                    }
                    catch (Exception ex)
                    {
                        string kk = "kamal";
                    }
                }

                TradeData = Details;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        private void SchemaValidation(object obj, System.Xml.Schema.ValidationEventArgs erg)
        {
            if (erg.Exception != null)
            {
                throw new Exception("Schema Voilation: " + erg.Exception.Message);
            }
        }


    }
}
