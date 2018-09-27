using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using DSE_Reports.Reports;
using CrystalDecisions.CrystalReports.Engine;

namespace DseReports
{
    public partial class frmBroker_Comission_Report_DSE_24_1 : Form
    {
        #region Call business Object
        Broker_Comission_Report_DSE_24_1BAL objBAL = new Broker_Comission_Report_DSE_24_1BAL();
        #endregion

        #region constructor
        public frmBroker_Comission_Report_DSE_24_1()
        {
            InitializeComponent();
            LoadComboBox();
            ComboBoxSelection();
        }
        #endregion

        #region Declare Field
        DateTime Start_date;
        DateTime End_date;
        string Branch = "";
        string Exchange = "";
        string Trader = "";
        string Selection_type = "";
        #endregion

        #region View Report
        private void btnShow_Click(object sender, EventArgs e)
        {
            Broker_Comission_Report_DSE_24_1BAL objBAL = new Broker_Comission_Report_DSE_24_1BAL();
            crrptBroker_Comission_Report_DSE_24_1 objRPT = new crrptBroker_Comission_Report_DSE_24_1();
            frmReportViewer Viewer = new frmReportViewer();
            DataTable dt = new DataTable();
            Start_date = dtpStart.Value;
            End_date = dtpEnd.Value;
            Branch = cmbbranch.Text;
            Exchange = cmbexchange.Text;
            Trader = cmbtrader.Text;
            Selection_type=cmbselection.Text;
            if (Selection_type == "All")
            {
                Exchange = "";
                Trader = "";
                dt = objBAL.Broker_Comission(Start_date, End_date, Exchange, Trader, Selection_type);
                objRPT.SetDataSource(dt);
                Viewer.crvReportViewer.ReportSource = objRPT;
                Exchange = "All";
                ((TextObject)objRPT.Section2.ReportObjects["txtStartDate"]).Text = Start_date.ToString("dd-MMMM-yyyy");
                ((TextObject)objRPT.Section2.ReportObjects["txtEndDate"]).Text = End_date.ToString("dd-MMMM-yyyy");
                ((TextObject)objRPT.Section2.ReportObjects["txtBranch"]).Text = Branch;
                ((TextObject)objRPT.Section2.ReportObjects["txtexchange"]).Text = Exchange;
                ((TextObject)objRPT.Section2.ReportObjects["txtTrader"]).Text = Trader;
                Viewer.Show();
            }
            else if (Selection_type == "Exchange")
            {
                if(cmbexchange.Text=="CSE")
                {

                }                 
                else
                { 
                    Selection_type = "";
                    Branch = "";
                    Exchange = "";
                    dt = objBAL.Broker_Comission_Trade(Start_date, End_date, Exchange, Branch, Selection_type);
                    objRPT.SetDataSource(dt);
                    
                }
                Branch = "All";
                Trader = "All";
                if (Exchange == "DSE")
                {
                    Exchange = "DSE";
                }
                else if (Exchange == "CSE")
                {
                    Exchange = "CSE";
                }
                else
                {
                    Exchange = "All";
                }
                Viewer.crvReportViewer.ReportSource = objRPT;
                ((TextObject)objRPT.Section2.ReportObjects["txtStartDate"]).Text = Start_date.ToString("dd-MMMM-yyyy");
                ((TextObject)objRPT.Section2.ReportObjects["txtEndDate"]).Text = End_date.ToString("dd-MMMM-yyyy");
                ((TextObject)objRPT.Section2.ReportObjects["txtBranch"]).Text = Branch;
                ((TextObject)objRPT.Section2.ReportObjects["txtexchange"]).Text = Exchange;
                ((TextObject)objRPT.Section2.ReportObjects["txtTrader"]).Text = Trader;
                Viewer.Show();
                
            }
            else if (Selection_type == "Branch")
            {
                Exchange = "DSE";
                dt = objBAL.Broker_Comission_Trade(Start_date, End_date, Exchange, Branch, Selection_type);
                objRPT.SetDataSource(dt);
                Viewer.crvReportViewer.ReportSource = objRPT;
                Trader = "All";
                Exchange = "All";
                ((TextObject)objRPT.Section2.ReportObjects["txtStartDate"]).Text = Start_date.ToString("dd-MMMM-yyyy");
                ((TextObject)objRPT.Section2.ReportObjects["txtEndDate"]).Text = End_date.ToString("dd-MMMM-yyyy");
                ((TextObject)objRPT.Section2.ReportObjects["txtBranch"]).Text = Branch;
                ((TextObject)objRPT.Section2.ReportObjects["txtexchange"]).Text = Exchange;
                ((TextObject)objRPT.Section2.ReportObjects["txtTrader"]).Text = Trader;
                Viewer.Show();
            }
            else if (Selection_type == "Trader")
            {
                Exchange = "DSE";
                dt = objBAL.Broker_Comission_Trade(Start_date, End_date, Exchange, Trader, Selection_type);
                objRPT.SetDataSource(dt);
                Viewer.crvReportViewer.ReportSource = objRPT;
                Exchange = "All";
                Branch = "All";
                ((TextObject)objRPT.Section2.ReportObjects["txtStartDate"]).Text = Start_date.ToString("dd-MMMM-yyyy");
                ((TextObject)objRPT.Section2.ReportObjects["txtEndDate"]).Text = End_date.ToString("dd-MMMM-yyyy");
                ((TextObject)objRPT.Section2.ReportObjects["txtBranch"]).Text = Branch;
                ((TextObject)objRPT.Section2.ReportObjects["txtexchange"]).Text = Exchange;
                ((TextObject)objRPT.Section2.ReportObjects["txtTrader"]).Text = Trader;
                Viewer.Show();
            }

        }
        #endregion

        #region Load ComboBox
        public void LoadComboBox()
        {
           
            DataTable dtBranch = new DataTable();
            DataTable dtTrader = new DataTable();
            

            dtBranch = objBAL.GetBranchName();
            cmbbranch.DataSource = dtBranch;
            cmbbranch.ValueMember = dtBranch.Columns[0].ToString();
            cmbbranch.DisplayMember = dtBranch.Columns[0].ToString();

            dtTrader = objBAL.GetTraderName();
            cmbtrader.DataSource = dtTrader;
            cmbtrader.ValueMember = dtTrader.Columns[0].ToString();
            cmbtrader.DisplayMember = dtTrader.Columns[0].ToString();
        }
        #endregion

        #region ComboBoxSelection
        public void ComboBoxSelection()
        {
            cmbselection.SelectedIndex = 0;
            cmbtrader.Enabled = false;
            cmbbranch.Enabled = false;
            cmbexchange.Enabled = false;          
        }
        #endregion
                
        #region combobox selection changed
        private void cmbselection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbselection.Text == "Exchange")
            {
                cmbexchange.Enabled = true;
                cmbbranch.Enabled = false;
                cmbtrader.Enabled = false;
                cmbtrader.SelectedIndex = 0;
                cmbbranch.SelectedIndex = 0;
                
            }
            else if (cmbselection.Text == "All")
            {
                cmbexchange.Enabled = false;
                cmbbranch.Enabled = false;
                cmbtrader.Enabled = false;
                cmbtrader.SelectedIndex = 0;
                cmbbranch.SelectedIndex = 0;
                cmbexchange.SelectedIndex = 0;
                cmbexchange.Refresh();
                cmbbranch.Refresh();
                cmbtrader.Refresh();
            }
            else if (cmbselection.Text == "Trader")
            {
                cmbexchange.Enabled = false;
                cmbbranch.Enabled = false;
                cmbtrader.Enabled = true;
                cmbexchange.SelectedIndex = 0;
                cmbbranch.SelectedIndex = 0;
                cmbexchange.Refresh();
                cmbbranch.Refresh();
            }
            else if (cmbselection.Text == "Branch")
            {
                cmbexchange.Enabled = false;
                cmbbranch.Enabled = true;
                cmbtrader.Enabled = false;
                cmbexchange.SelectedIndex = 0;
                cmbtrader.SelectedIndex = 0;
                cmbtrader.Refresh();
                cmbbranch.Refresh();
            }
        }
        #endregion

        #region Close Button
        private void btnClsoe_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void btnClsoe_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
