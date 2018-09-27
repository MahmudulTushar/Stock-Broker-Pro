using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Reflection;
using System.Data;
using System.Xml.Schema;
using System.Data.Common;
using BusinessAccessLayer.BAL;

namespace SBPXMLSchema
{
    public class Sample
    {
        public Sample()
        {
            
            ////Need Data Filledup By Loop After retrived Data From BAL- Here Only Require ClientRegistrationArray

            //List<ClientRegistration> crList = new List<ClientRegistration>();
            
            //SBPXMLSchema.ClientRegistration crReg1 = new SBPXMLSchema.ClientRegistration();
            //crReg1.AccountType = SBPXMLSchema.AccountType.N;
            //crReg1.Address = "Adress1";
            //crReg1.BOID = "0123456789102";
            ////crReg1.BranchID = "1";
            //crReg1.ClientCode = "100003";
            //crReg1.DealerID = "0123467";
            //crReg1.ICNo = "012345678";
            //crReg1.Name = "1 Shahrior";
            //crReg1.ShortName = "Kamal";
            //crReg1.ShortSellingAllowed = SBPXMLSchema.BooleanYesNo.Yes;
            //crReg1.Tel = "012345678";
            //crReg1.WithNetAdjustment = SBPXMLSchema.BooleanYesNo.Yes;

            //SBPXMLSchema.ClientRegistration crReg2 = new SBPXMLSchema.ClientRegistration();
            //crReg2.AccountType = SBPXMLSchema.AccountType.N;
            //crReg2.Address = "Adress2";
            //crReg2.BOID = "0123456789102";
            ////crReg2.BranchID = "1";
            //crReg2.ClientCode = "100003";
            //crReg2.DealerID = "0123467";
            //crReg2.ICNo = "012345678";
            //crReg2.Name = "2 Shahrior";
            //crReg2.ShortName = "Kamal";
            //crReg2.ShortSellingAllowed = SBPXMLSchema.BooleanYesNo.Yes;
            //crReg2.Tel = "012345678";
            //crReg2.WithNetAdjustment = SBPXMLSchema.BooleanYesNo.Yes;

            //SBPXMLSchema.ClientRegistration crReg3 = new SBPXMLSchema.ClientRegistration();
            //crReg3.AccountType = SBPXMLSchema.AccountType.N;
            //crReg3.Address = "Adress3";
            //crReg3.BOID = "0123456789102";
            ////crReg3.BranchID = "1";
            //crReg3.ClientCode = "100003";
            //crReg3.DealerID = "0123467";
            //crReg3.ICNo = "012345678";
            //crReg3.Name = "3 Shahrior";
            //crReg3.ShortName = "Kamal";
            //crReg3.ShortSellingAllowed = SBPXMLSchema.BooleanYesNo.Yes;
            //crReg3.Tel = "012345678";
            //crReg3.WithNetAdjustment = SBPXMLSchema.BooleanYesNo.Yes;

            //crList.Add(crReg1);
            //crList.Add(crReg2);
            //crList.Add(crReg3);

            //List<ClientLimits> cLmList = new List<ClientLimits>();

            //ClientLimits cLm1 = new ClientLimits();
            ////cLm1.BranchID = "1";
            //cLm1.Cash = 50000; // Cash Limit 
            //cLm1.ClientCode = "10003";
            //cLm1.Margin = new MarginLimit() { Deposit = 4000, MarginRatio = 1, MarginRatioSpecified = true }; // Loan Within The Limit
            //cLm1.MaxCapitalBuy = 4000; // Highest He Can Buy
            //cLm1.MaxCapitalBuySpecified = true; // Need To confirm from Rakimul
            //cLm1.MaxCapitalSell = 6000; //Need To Confirm From Rakimul
            //cLm1.MaxCapitalSellSpecified = true;  //Need To Confirm From Rakimul
            //cLm1.NetTransaction = 00000; //Need To Confirm From Rakimul
            //cLm1.NetTransactionSpecified = true; //Need To Confirm From Rakimul
            //cLm1.TotalTransaction = 000000; //Need To Confirm From Rakimul
            //cLm1.TotalTransactionSpecified = true; //Need To Confirm From Rakimul

            //ClientLimits cLm2 = new ClientLimits();
            ////cLm2.BranchID = "1";
            //cLm2.Cash = 50000; // Cash Limit 
            //cLm2.ClientCode = "102";
            //cLm2.Margin = new MarginLimit() { Deposit = 4000, MarginRatio = 1, MarginRatioSpecified = true }; // Loan Within The Limit
            //cLm2.MaxCapitalBuy = 4000; // Highest He Can Buy
            //cLm2.MaxCapitalBuySpecified = true; // Need To confirm from Rakimul
            //cLm2.MaxCapitalSell = 6000; //Need To Confirm From Rakimul
            //cLm2.MaxCapitalSellSpecified = true;  //Need To Confirm From Rakimul
            //cLm2.NetTransaction = 00000; //Need To Confirm From Rakimul
            //cLm2.NetTransactionSpecified = true; //Need To Confirm From Rakimul
            //cLm2.TotalTransaction = 000000; //Need To Confirm From Rakimul
            //cLm2.TotalTransactionSpecified = true; //Need To Confirm From Rakimul

            //ClientLimits cLm3 = new ClientLimits();
            ////cLm3.BranchID = "1";
            //cLm3.Cash = 50000; // Cash Limit 
            //cLm3.ClientCode = "105";
            //cLm3.Margin = new MarginLimit() { Deposit = 4000, MarginRatio = 1, MarginRatioSpecified = true }; // Loan Within The Limit
            //cLm3.MaxCapitalBuy = 4000; // Highest He Can Buy
            //cLm3.MaxCapitalBuySpecified = true; // Need To confirm from Rakimul
            //cLm3.MaxCapitalSell = 6000; //Need To Confirm From Rakimul
            //cLm3.MaxCapitalSellSpecified = true;  //Need To Confirm From Rakimul
            //cLm3.NetTransaction = 00000; //Need To Confirm From Rakimul
            //cLm3.NetTransactionSpecified = true; //Need To Confirm From Rakimul
            //cLm3.TotalTransaction = 000000; //Need To Confirm From Rakimul
            //cLm3.TotalTransactionSpecified = true; //Need To Confirm From Rakimul

            //cLmList.Add(cLm1);
            //cLmList.Add(cLm2);
            //cLmList.Add(cLm3);

            //// Now Final Object Populate This is Scalar Not Array

            //Clients cs = new Clients();

            //cs.BrokerID="01112222";// Need to Confirm From Rakimul
            ////cs.Deactivate // If There Any Deactive Client Having Then
            //cs.Register = crList.ToArray();
            //cs.Limits = cLmList.ToArray();
            //cs.ProcessingMode = SBPXMLSchema.ProcessingMode.BatchInsertOrUpdate;

            //try{
            //    SBPXMLSchema.XMLExport xprt=new XMLExport(XMLExportType.Clients,cs,@"C:\e2eTechnology\Client.xml");
            //}
            //catch(Exception ex)
            //{
            //    //MessageBox.Show(ex.Message);
            //}

            
            //dt.Action = ;

            try
            {
                Assembly asm = Assembly.GetExecutingAssembly();
                //Stream strm = asm.GetManifestResourceStream("SBPXMLSchema.Flextrade-BOS-Clients.xsd");
                //XmlReader xSchemaReader = XmlReader.Create(strm);
                //while (xSchemaReader.Read())
                //{

                //}
                //XmlSchema schema = XmlSchema.Read(xSchemaReader,new  ValidationEventHandler(SchemaValidation));

                string currentLocation = "D:\\Shahrior Dev\\Shahrior_SBP_Pro\\SBPXMLSchema";//asm.Location;
                string fileLocation="C:\\Users\\KSCLIT\\Desktop\\Flex Trade\\Sample Trade Share XML Document\\140915-113910-trades-AAL.xml";

                //XmlReaderSettings xrdSetting = new XmlReaderSettings();
                //xrdSetting.ValidationType = ValidationType.Schema;
                
                ////xrdSetting.Schemas.Add(null,xSchemaReader);
                //xrdSetting.Schemas.Add(null, currentLocation + "\\Flextrade-BOS-Trades.xsd");
                //xrdSetting.ValidationEventHandler += new System.Xml.Schema.ValidationEventHandler(SchemaValidation);
                XmlDocument xDoc = new XmlDocument();
                xDoc.Schemas.Add(null, currentLocation + "\\Flextrade-BOS-Trades.xsd");
                //xDoc.Schemas.Add(null, "C:\\e2eTechnology\\Flex Trade\\Flex Trade\\140919 Flex XML schema 0.7.4\\Flextrade-BOS-Trades.xsd");
                xDoc.Load(fileLocation);
                xDoc.Validate(new System.Xml.Schema.ValidationEventHandler(SchemaValidation));

                //XmlReader xReader = XmlReader.Create(new StringReader(xDoc.InnerXml), xrdSetting);
                //while (xReader.Read())
                //{

                //}
                DataSet ds = new DataSet();
                ds.ReadXml(new XmlNodeReader(xDoc));
                TradeBAL bal = new TradeBAL();
                DataTable tempDetails = ds.Tables["Detail"];
                DataTable Details = ds.Tables["Detail"];
                for(int i=0; i<tempDetails.Rows.Count; i++)
                {
                    Details.Rows[i]["Date"] = Convert.ToString(tempDetails.Rows[i]["Date"]).Substring(0, 4) 
                        +"-"+ Convert.ToString(tempDetails.Rows[i]["Date"]).Substring(4, 2) 
                        +"-"+ Convert.ToString(tempDetails.Rows[i]["Date"]).Substring(6, 2);

                    Details.Rows[i]["Time"] = Convert.ToString(tempDetails.Rows[i]["Time"]) == "-" ? DateTime.Today.Date.ToString() : DateTime.Today.Date.ToShortDateString() + " " + Convert.ToString(tempDetails.Rows[i]["Time"]);
                }
                bal.SaveProcessedTradeInfo(Details, "SBP_Transaction_FlexTrade_Temp");
                

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
            //XmlDocument xdoc = new XmlDocument();
            //xdoc.xm
            //xdoc.Schemas.Add("http://www.w3.org/2001/XMLSchema", "Flextrade-BOS-Trades.xsd");

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
