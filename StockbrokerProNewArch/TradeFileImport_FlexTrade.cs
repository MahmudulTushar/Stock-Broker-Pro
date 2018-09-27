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
using System.Xml;
using System.Reflection;
using System.Linq;

namespace StockbrokerProNewArch
{
    public partial class TradeFileImport_FlexTrade : Form
    {
        private DataTable TradeData;
        private string FileName;

        public TradeFileImport_FlexTrade()
        {
            InitializeComponent();
            TradeData=new DataTable();
        }


        private DataTable UploadProcess()
        {
            //DataTable tradeDataTable;
            //tradeDataTable = ProcessTradeFile(txtFileLocation.Text);
            TradeBAL tradeBal = new TradeBAL();
            tradeBal.TruncateTradeInfo();
            tradeBal.SaveProcessedTradeTemp_ByInsertQuery (TradeData);
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
                //values[8] = DateTime.ParseExact(values[8], "dd-MM-yyyy", null).ToShortDateString();  
                dataRow.ItemArray = values;
                dataTable.Rows.Add(dataRow);
                lineText = streamReader.ReadLine();
            } while (lineText != null);

            return dataTable;
        }


        private void btnFileLocationBrowser_Click(object sender, EventArgs e)
        {
            if (ofdFileOpen.ShowDialog() == DialogResult.OK)
            {
                txtFileLocation.Text = ofdFileOpen.FileName;
                FileName = ofdFileOpen.SafeFileName;
            }
            
        }

        private void btnStartImport_Click(object sender, EventArgs e)
        {
            if (ValidateFeild())
            {
                try
                {
                    SetTradeFiles_FlexTrade();
                    DateTime tradeDate = GetTradeDateFromFile_FlexTrade();
                    DataTable dtTradeFileData = new DataTable();
                    CommonBAL commonBal = new CommonBAL();
                    if (commonBal.IsUpload(tradeDate, "tradeFile"))
                    {
                        MessageBox.Show("These Data File has allready imported.");
                        return;
                    }
                    else
                    {

                        dtTradeFileData= UploadProcess();
                        TradeFileProcess_FlexTrade tradeFileProcess = new TradeFileProcess_FlexTrade();
                        //tradeFileProcess.MdiParent = this.Parent;
                        tradeFileProcess.Show();
                        this.Hide();
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Error Occured." + exc.Message);
                }
            }
        }

        private DateTime GetTradeDateFromFile()
        {
            char proChar = '~';
            StreamReader streamReader = new StreamReader(txtFileLocation.Text);
            string[] values = streamReader.ReadLine().Split(proChar);
            DateTime tradeDate = Convert.ToDateTime(values[7]);
            return tradeDate;
        }

        private DateTime GetTradeDateFromFile_FlexTrade()
        {
            try
            {
                DateTime resultDate = new DateTime();

                string dateString = FileName.Substring(0, 8);
                DateTime FileNameDate = Convert.ToDateTime( dateString.Substring(0, 4)
                                    + "-" + dateString.Substring(4, 2)
                                    + "-" + dateString.Substring(6, 2));
                DateTime[] FileDate = TradeData.Rows.Cast<DataRow>()
                    .ToList().Select(t => Convert.ToDateTime(Convert.ToString(t["Date"]))).Distinct().ToArray();

                if (FileDate.Length > 1)
                    throw new Exception("File Contain Two Date");
                if (FileNameDate == FileDate[0])
                    resultDate=FileNameDate;
                
                return resultDate;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
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

        private void SetTradeFiles_FlexTrade()
        {

            try 
            {
                string FileLocation = txtFileLocation.Text;
                Assembly asm = Assembly.GetExecutingAssembly();
                //string currentLocation = "C:\\e2eTechnology\\Stock Broker Pro\\Source Code\\Shahrior_SBP_Pro_22_Oct_2014\\Shahrior_SBP_Pro\\SBPXMLSchema";//asm.Location;
                //string currentLocation = "D:\\Shahrior Dev\\Shahrior_SBP_Pro\\SBPXMLSchema";//asm.Location;
                lbl_Test.Text = asm.Location;
                //string currentLocation = Directory.GetCurrentDirectory();// asm.Location.Replace("Stock Broker Pro.exe", "");
                //string currentLocation = "D:\\SBPXsdFiles";
                string currentLocation = "\\\\150.1.122.31\\Release For SBP\\SBPXsdFiles";
                //string currentLocation = "C:\\Users\\KSCL03\\Desktop\\SBPXsdFiles";
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
                
                TradeData=Details;
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
