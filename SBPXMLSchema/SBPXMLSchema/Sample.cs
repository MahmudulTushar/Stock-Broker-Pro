using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SBPXMLSchema
{
    private class Sample
    {
        

        private Sample()
        {
            
            //Need Data Filledup By Loop After retrived Data From BAL- Here Only Require ClientRegistrationArray

            List<ClientRegistration> crList = new List<ClientRegistration>();
            
            SBPXMLSchema.ClientRegistration crReg1 = new SBPXMLSchema.ClientRegistration();
            crReg1.AccountType = SBPXMLSchema.AccountType.Normal;
            crReg1.Address = "Adress1";
            crReg1.BOID = "0123456789102";
            crReg1.BranchID = "1";
            crReg1.ClientCode = "100003";
            crReg1.DealerID = "0123467";
            crReg1.ICNo = "012345678";
            crReg1.Name = "1 Shahrior";
            crReg1.ShortName = "Kamal";
            crReg1.ShortSellingAllowed = SBPXMLSchema.BooleanYesNo.Yes;
            crReg1.Tel = "012345678";
            crReg1.WithNetAdjustment = SBPXMLSchema.BooleanYesNo.Yes;

            SBPXMLSchema.ClientRegistration crReg2 = new SBPXMLSchema.ClientRegistration();
            crReg2.AccountType = SBPXMLSchema.AccountType.Normal;
            crReg2.Address = "Adress2";
            crReg2.BOID = "0123456789102";
            crReg2.BranchID = "1";
            crReg2.ClientCode = "100003";
            crReg2.DealerID = "0123467";
            crReg2.ICNo = "012345678";
            crReg2.Name = "2 Shahrior";
            crReg2.ShortName = "Kamal";
            crReg2.ShortSellingAllowed = SBPXMLSchema.BooleanYesNo.Yes;
            crReg2.Tel = "012345678";
            crReg2.WithNetAdjustment = SBPXMLSchema.BooleanYesNo.Yes;

            SBPXMLSchema.ClientRegistration crReg3 = new SBPXMLSchema.ClientRegistration();
            crReg3.AccountType = SBPXMLSchema.AccountType.Normal;
            crReg3.Address = "Adress3";
            crReg3.BOID = "0123456789102";
            crReg3.BranchID = "1";
            crReg3.ClientCode = "100003";
            crReg3.DealerID = "0123467";
            crReg3.ICNo = "012345678";
            crReg3.Name = "3 Shahrior";
            crReg3.ShortName = "Kamal";
            crReg3.ShortSellingAllowed = SBPXMLSchema.BooleanYesNo.Yes;
            crReg3.Tel = "012345678";
            crReg3.WithNetAdjustment = SBPXMLSchema.BooleanYesNo.Yes;

            crList.Add(crReg1);
            crList.Add(crReg2);
            crList.Add(crReg3);


            List<ClientLimits> cLmList = new List<ClientLimits>();

            ClientLimits cLm1 = new ClientLimits();
            cLm1.BranchID = "1";
            cLm1.Cash = 50000; // Cash Limit 
            cLm1.ClientCode = "10003";
            cLm1.Margin = new MarginLimit() { Deposit = 4000, MarginRatio = 1, MarginRatioSpecified = true }; // Loan Within The Limit
            cLm1.MaxCapitalBuy = 4000; // Highest He Can Buy
            cLm1.MaxCapitalBuySpecified = true; // Need To confirm from Rakimul
            cLm1.MaxCapitalSell = 6000; //Need To Confirm From Rakimul
            cLm1.MaxCapitalSellSpecified = true;  //Need To Confirm From Rakimul
            cLm1.NetTransaction = 00000; //Need To Confirm From Rakimul
            cLm1.NetTransactionSpecified = true; //Need To Confirm From Rakimul
            cLm1.TotalTransaction = 000000; //Need To Confirm From Rakimul
            cLm1.TotalTransactionSpecified = true; //Need To Confirm From Rakimul

            ClientLimits cLm2 = new ClientLimits();
            cLm2.BranchID = "1";
            cLm2.Cash = 50000; // Cash Limit 
            cLm2.ClientCode = "102";
            cLm2.Margin = new MarginLimit() { Deposit = 4000, MarginRatio = 1, MarginRatioSpecified = true }; // Loan Within The Limit
            cLm2.MaxCapitalBuy = 4000; // Highest He Can Buy
            cLm2.MaxCapitalBuySpecified = true; // Need To confirm from Rakimul
            cLm2.MaxCapitalSell = 6000; //Need To Confirm From Rakimul
            cLm2.MaxCapitalSellSpecified = true;  //Need To Confirm From Rakimul
            cLm2.NetTransaction = 00000; //Need To Confirm From Rakimul
            cLm2.NetTransactionSpecified = true; //Need To Confirm From Rakimul
            cLm2.TotalTransaction = 000000; //Need To Confirm From Rakimul
            cLm2.TotalTransactionSpecified = true; //Need To Confirm From Rakimul

            ClientLimits cLm3 = new ClientLimits();
            cLm3.BranchID = "1";
            cLm3.Cash = 50000; // Cash Limit 
            cLm3.ClientCode = "105";
            cLm3.Margin = new MarginLimit() { Deposit = 4000, MarginRatio = 1, MarginRatioSpecified = true }; // Loan Within The Limit
            cLm3.MaxCapitalBuy = 4000; // Highest He Can Buy
            cLm3.MaxCapitalBuySpecified = true; // Need To confirm from Rakimul
            cLm3.MaxCapitalSell = 6000; //Need To Confirm From Rakimul
            cLm3.MaxCapitalSellSpecified = true;  //Need To Confirm From Rakimul
            cLm3.NetTransaction = 00000; //Need To Confirm From Rakimul
            cLm3.NetTransactionSpecified = true; //Need To Confirm From Rakimul
            cLm3.TotalTransaction = 000000; //Need To Confirm From Rakimul
            cLm3.TotalTransactionSpecified = true; //Need To Confirm From Rakimul

            cLmList.Add(cLm1);
            cLmList.Add(cLm2);
            cLmList.Add(cLm3);

            
            
            // Now Final Object Populate This is Scalar Not Array

            Clients cs = new Clients();

            cs.BrokerID="01112222";// Need to Confirm From Rakimul
            //cs.Deactivate // If There Any Deactive Client Having Then
            cs.Register = crList.ToArray();
            cs.Limits = cLmList.ToArray();
            cs.ProcessingMode = SBPXMLSchema.ProcessingMode.BatchInsertOrUpdate;

            try{
            SBPXMLSchema.XMLExport xprt=new XMLExport(XMLExportType.Clients,cs,@"C:\e2eTechnology\Client.xml");
            }
            catch(Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }

        }
    
    }
}
