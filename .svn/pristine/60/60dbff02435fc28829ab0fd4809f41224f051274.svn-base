using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using CrystalDecisions.CrystalReports.Engine;
using System.Xml;
namespace Reports
{
    public partial class ClientPayableRecounciliationStatement : Form
    {
        public static DateTime _reportDate;
        public ClientPayableRecounciliationStatement()
        {
            InitializeComponent();
        }

        private void btnGentrateReport_Click(object sender, EventArgs e)
        {

            XmlDataDocument xml = new XmlDataDocument();

            xml.Load(@"XML Document\ReportsFormat.xml");

            XmlNodeList nodeList = xml.SelectNodes("/crClientPayableReconciliationStatement.rpt/CheckValue");

            foreach (XmlNode node in nodeList)
            {

                if (node["FirstAmount"].InnerText != "" || node["SecondAmount"].InnerText != "" || node["Remarks"].InnerText != "")  //returns empty or ""
                    MessageBox.Show(String.Format("Data From xml is {0} {1} {2}", node["FirstAmount"].InnerText, node["SecondAmount"].InnerText, node["Remarks"].InnerText));
                if (node["FirstAmount"].InnerText == "" || node["FirstAmount"].InnerText == "" || node["Remarks"].InnerText == "")  //returns empty or ""
                    MessageBox.Show(String.Format("Data From xml is {0} {1} {2}", node["FirstAmount"].InnerText, node["SecondAmount"].InnerText, node["Remarks"].InnerText));
            }

          /* 
            double payable=0.0;
            double receivable = 0.0;
            payable = 47311025.39;
            receivable = -14820280.88;
            receivable = payable + receivable;
            _reportDate = Convert.ToDateTime(dtpReportDate.Value.ToShortDateString());

            ClientPayableRecounciliationStatementBAL ClientPayableRecounciliationStatementBAL = new ClientPayableRecounciliationStatementBAL();
            DataTable data = new DataTable();
          //  data = ClientPayableRecounciliationStatementBAL.GetStatement(_reportDate);

            frmReportViewer frmReportViewer = new frmReportViewer();
            crClientPayableReconciliationStatement crClientPayableReconciliationStatement = new crClientPayableReconciliationStatement();


            ((TextObject)crClientPayableReconciliationStatement.ReportDefinition.Sections[2].ReportObjects["txtDate"]).Text = _reportDate.ToShortDateString();//String.Format("{0:#,###0.00}", Convert.ToDouble(TaxDataSet.Tables[2].Rows[0][0]));// DepositWithdraw.Rows[0][0].ToString();
            ((TextObject)crClientPayableReconciliationStatement.ReportDefinition.Sections[2].ReportObjects["txtPayableClientsAmount1"]).Text = String.Format("{0:#,###0.00}", Convert.ToDouble(payable));// DepositWithdraw.Rows[0][1].ToString();
            ((TextObject)crClientPayableReconciliationStatement.ReportDefinition.Sections[2].ReportObjects["txtreceivableClientsAmount1"]).Text = String.Format("{0:#,###0.00}", Convert.ToDouble(receivable));//DepositWithdraw.Rows[0][1].ToString();
                //((TextObject)crClientPayableReconciliationStatement.ReportDefinition.Sections[2].ReportObjects["Market_Value_Total"]).Text = String.Format("{0:#,###0.00}", Convert.ToDouble(TaxDataSet.Tables[2].Rows[0][2]));//DepositWithdraw.Rows[0][1].ToString();
           

          //  crClientPayableReconciliationStatement.SetDataSource(data);
            frmReportViewer.crvReportViewer.ReportSource = crClientPayableReconciliationStatement;
            frmReportViewer.Show();
           * */

        }
    }
}
