using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DseReports
{
    public partial class MdiDseReports : Form
    {
        public MdiDseReports()
        {
            InitializeComponent();
        }

        private void bonusInstrumentConfirmationReportsDSE212ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBonus_Instrument_Confirmation_ReportDSE_21_2 DSE_21_2 = new frmBonus_Instrument_Confirmation_ReportDSE_21_2();
            DSE_21_2.Show();
        }

        private void bonusInstrumentReceiveReportDSE213ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBonus_Instrument_Receive_Report_DSE_21_3 DSE_21_3 =new frmBonus_Instrument_Receive_Report_DSE_21_3();
            DSE_21_3.Show();
        }

        private void registrationConfirmationReportsDSE214ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRegistration_Confirmation_Report_DSE_21_4 DSE_21_4 = new frmRegistration_Confirmation_Report_DSE_21_4();
            DSE_21_4.Show();
        }

        private void bOModificationReportDSE215ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBO_Modification_Report_DSE_21_5 DSE_21_5 = new frmBO_Modification_Report_DSE_21_5();
            DSE_21_5.Show();
        }

        private void bOClosingReportDSE216ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBOClosing_Report_DSE_21_6 DSE_21_6 = new frmBOClosing_Report_DSE_21_6();
            DSE_21_6.Show();
        }

        private void payOutConfirmationReportDSE2111ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPay_Out_Confirmation_Report_DSE_21_11 Dse_21_11 = new frmPay_Out_Confirmation_Report_DSE_21_11();
            Dse_21_11.Show();
        }

        private void portfolioStatementInvestorWiseDSE221ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPortfolio_Statement_Investor_Wise_DSE_22_1 DSE_22_1 = new frmPortfolio_Statement_Investor_Wise_DSE_22_1();
            DSE_22_1.Show();
        }

        private void clientAccountStatusReportDSE2412ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmClient_Account_Status_Report_DSE_24_12 DSE_24_12 = new frmClient_Account_Status_Report_DSE_24_12();
            DSE_24_12.Show();
        }

        private void rightsInstrumensConfirmationReportDse2114ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRights_Instrumens_Confirmations_Reports_Dse_21_14 Dse_21_14 = new frmRights_Instrumens_Confirmations_Reports_Dse_21_14();
            Dse_21_14.Show();
        }

        private void rightInstrumentReceivedReportDSE2115ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRights_Instruments_Received_Reports_DSE_21_15 DSE_21_15 = new frmRights_Instruments_Received_Reports_DSE_21_15();
            DSE_21_15.Show();
        }

        private void iPOInstrumentReceiveReportDSE21212ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIPO_Instrument_Receive_Report_DSE_21_21_2 DSE_21_21_2 = new frmIPO_Instrument_Receive_Report_DSE_21_21_2();
            DSE_21_21_2.Show();
        }

        private void listOfPledgeClientsDSE21261ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmList_Of_Pledge_Clients_DSE_21_26_1 DSE_21_26_1 = new frmList_Of_Pledge_Clients_DSE_21_26_1();
            DSE_21_26_1.Show();
        }

        private void listOfLandingClientsDSE21281ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmList_Of_Landing_Clients_DSE_21_28_1 DSE_21_28_1 =new frmList_Of_Landing_Clients_DSE_21_28_1();
            DSE_21_28_1.Show();
        }

        private void frmPortfolioStatementInstrumnetWiseDSE223ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPortfolio_Statement_Instrumnet_Wise_DSE_22_3 Wise_DSE_22_3 = new frmPortfolio_Statement_Instrumnet_Wise_DSE_22_3();
            Wise_DSE_22_3.Show();
        }

        private void brokerComissionReportDSE241ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBroker_Comission_Report_DSE_24_1 DSE_24_1 = new frmBroker_Comission_Report_DSE_24_1();
            DSE_24_1.Show();
        }

        private void clientLedgerDetailReportDSE2410ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmClient_Ledger_Detail_Report_DSE_24_10 DSE_24_1 =new frmClient_Ledger_Detail_Report_DSE_24_10();
            DSE_24_1.Show();
        }

        private void instrumentWiseStockStatusReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }
    }
}
