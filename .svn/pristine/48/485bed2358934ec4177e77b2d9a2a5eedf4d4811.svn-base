using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using Reports;
using CrystalDecisions.CrystalReports.Engine;

namespace StockbrokerProNewArch
{
    public partial class Frm_HeadWiseIncomeLedger : Form
    {

        IncomeEntryBAL BAL = new IncomeEntryBAL();
        private string _CommpanyName;
        private string _branchName;
        private string _branchAddress;
        private string _branchContactNumber;

        public Frm_HeadWiseIncomeLedger()
        {
            InitializeComponent();
        }

        private void ChkExInterest_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkExInterest.Checked == true)
            {
                ChkExCommission.Checked = false;
                ChkExIPOCharge.Checked = false;
                ChkExBOOpeningCharge.Checked = false;
                ChkExBOCloseCharge.Checked = false;
                ChkExTaxCharge.Checked = false;
                ChkExTransmissionCharge.Checked = false;
                ChkExDemetCharge.Checked = false;
                ChkExCustodian.Checked = false;
                ChkExBankInterest.Checked = false;

                chkExTaxChargeBank.Checked = false;
                chkExTransChargeBank.Checked = false;
                chkExDemetChargeBank.Checked = false;
                chkCustodianChargeBank.Checked = false;
            }
            else 
            {
                //
            }
        }

        private void ChkExCommission_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkExCommission.Checked == true)
            {
                ChkExInterest.Checked = false;
                ChkExIPOCharge.Checked = false;
                ChkExBOOpeningCharge.Checked = false;
                ChkExBOCloseCharge.Checked = false;
                ChkExTaxCharge.Checked = false;
                ChkExTransmissionCharge.Checked = false;
                ChkExDemetCharge.Checked = false;
                ChkExCustodian.Checked = false;
                ChkExBankInterest.Checked = false;

                chkExTaxChargeBank.Checked = false;
                chkExTransChargeBank.Checked = false;
                chkExDemetChargeBank.Checked = false;
                chkCustodianChargeBank.Checked = false;
            }
            else
            { 
                //
            }
        }

        private void ChkExIPOCharge_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkExIPOCharge.Checked == true)
            {
                ChkExInterest.Checked = false;
                ChkExCommission.Checked = false;
                ChkExBOOpeningCharge.Checked = false;
                ChkExBOCloseCharge.Checked = false;
                ChkExTaxCharge.Checked = false;
                ChkExTransmissionCharge.Checked = false;
                ChkExDemetCharge.Checked = false;
                ChkExCustodian.Checked = false;
                ChkExBankInterest.Checked = false;

                chkExTaxChargeBank.Checked = false;
                chkExTransChargeBank.Checked = false;
                chkExDemetChargeBank.Checked = false;
                chkCustodianChargeBank.Checked = false;
            }
            else
            { 
                //
            }
        }

        private void ChkExBOOpeningCharge_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkExBOOpeningCharge.Checked == true)
            {
                ChkExInterest.Checked = false;
                ChkExCommission.Checked = false;
                ChkExIPOCharge.Checked = false;
                ChkExBOCloseCharge.Checked = false;
                ChkExTaxCharge.Checked = false;
                ChkExTransmissionCharge.Checked = false;
                ChkExDemetCharge.Checked = false;
                ChkExCustodian.Checked = false;
                ChkExBankInterest.Checked = false;

                chkExTaxChargeBank.Checked = false;
                chkExTransChargeBank.Checked = false;
                chkExDemetChargeBank.Checked = false;
                chkCustodianChargeBank.Checked = false;
            }
            else
            { 
                //
            }
        }

        private void ChkExBOCloseCharge_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkExBOCloseCharge.Checked == true)
            {
                ChkExInterest.Checked = false;
                ChkExCommission.Checked = false;
                ChkExIPOCharge.Checked = false;
                ChkExBOOpeningCharge.Checked = false;
                ChkExTaxCharge.Checked = false;
                ChkExTransmissionCharge.Checked = false;
                ChkExDemetCharge.Checked = false;
                ChkExCustodian.Checked = false;
                ChkExBankInterest.Checked = false;

                chkExTaxChargeBank.Checked = false;
                chkExTransChargeBank.Checked = false;
                chkExDemetChargeBank.Checked = false;
                chkCustodianChargeBank.Checked = false;
            }
            else
            { 
                //
            }
        }

        private void ChkExTaxCharge_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkExTaxCharge.Checked == true)
            {
                ChkExInterest.Checked = false;
                ChkExCommission.Checked = false;
                ChkExIPOCharge.Checked = false;
                ChkExBOOpeningCharge.Checked = false;
                ChkExBOCloseCharge.Checked = false;
                ChkExTransmissionCharge.Checked = false;
                ChkExDemetCharge.Checked = false;
                ChkExCustodian.Checked = false;
                ChkExBankInterest.Checked = false;

                chkExTaxChargeBank.Checked = false;
                chkExTransChargeBank.Checked = false;
                chkExDemetChargeBank.Checked = false;
                chkCustodianChargeBank.Checked = false;
            }
            else
            { 
                //
            }
        }

        private void ChkExTransmissionCharge_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkExTransmissionCharge.Checked)
            {
                ChkExInterest.Checked = false;
                ChkExCommission.Checked = false;
                ChkExIPOCharge.Checked = false;
                ChkExBOOpeningCharge.Checked = false;
                ChkExBOCloseCharge.Checked = false;
                ChkExTaxCharge.Checked = false;
                ChkExDemetCharge.Checked = false;
                ChkExCustodian.Checked = false;
                ChkExBankInterest.Checked = false;

                chkExTaxChargeBank.Checked = false;
                chkExTransChargeBank.Checked = false;
                chkExDemetChargeBank.Checked = false;
                chkCustodianChargeBank.Checked = false;
            }
            else
            { 
                //
            }
        }

        private void ChkExDemetCharge_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkExDemetCharge.Checked == true)
            {
                ChkExInterest.Checked = false;
                ChkExCommission.Checked = false;
                ChkExIPOCharge.Checked = false;
                ChkExBOOpeningCharge.Checked = false;
                ChkExBOCloseCharge.Checked = false;
                ChkExTaxCharge.Checked = false;
                ChkExTransmissionCharge.Checked = false;
                ChkExCustodian.Checked = false;
                ChkExBankInterest.Checked = false;

                chkExTaxChargeBank.Checked = false;
                chkExTransChargeBank.Checked = false;
                chkExDemetChargeBank.Checked = false;
                chkCustodianChargeBank.Checked = false;
            }
            else
            { 
                //
            }
        }

        private void ChkExCustodian_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkExCustodian.Checked == true)
            {
                ChkExInterest.Checked = false;
                ChkExCommission.Checked = false;
                ChkExIPOCharge.Checked = false;
                ChkExBOOpeningCharge.Checked = false;
                ChkExBOCloseCharge.Checked = false;
                ChkExTaxCharge.Checked = false;
                ChkExTransmissionCharge.Checked = false;
                ChkExDemetCharge.Checked = false;
                ChkExBankInterest.Checked = false;

                chkExTaxChargeBank.Checked = false;
                chkExTransChargeBank.Checked = false;
                chkExDemetChargeBank.Checked = false;
                chkCustodianChargeBank.Checked = false;
            }
            else
            { 
                //
            }
        }

        private void ChkExBankInterest_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkExBankInterest.Checked == true)
            {
                ChkExInterest.Checked = false;
                ChkExCommission.Checked = false;
                ChkExIPOCharge.Checked = false;
                ChkExBOOpeningCharge.Checked = false;
                ChkExBOCloseCharge.Checked = false;
                ChkExTaxCharge.Checked = false;
                ChkExTransmissionCharge.Checked = false;
                ChkExDemetCharge.Checked = false;
                ChkExCustodian.Checked = false;

                chkExTaxChargeBank.Checked = false;
                chkExTransChargeBank.Checked = false;
                chkExDemetChargeBank.Checked = false;
                chkCustodianChargeBank.Checked = false;
            }
            else
            { 
                //
            }
        }
        private void chkExTaxChargeBank_CheckedChanged(object sender, EventArgs e)
        {
            if (chkExTaxChargeBank.Checked == true)
            {
                ChkExInterest.Checked = false;
                ChkExCommission.Checked = false;
                ChkExIPOCharge.Checked = false;
                ChkExBOOpeningCharge.Checked = false;
                ChkExBOCloseCharge.Checked = false;
                ChkExTaxCharge.Checked = false;
                ChkExTransmissionCharge.Checked = false;
                ChkExDemetCharge.Checked = false;
                ChkExCustodian.Checked = false;
                ChkExBankInterest.Checked = false;

                chkExTransChargeBank.Checked = false;
                chkExDemetChargeBank.Checked = false;
                chkCustodianChargeBank.Checked = false;
            }
        }

        private void chkExTransChargeBank_CheckedChanged(object sender, EventArgs e)
        {
            if (chkExTransChargeBank.Checked == true)
            {
                ChkExInterest.Checked = false;
                ChkExCommission.Checked = false;
                ChkExIPOCharge.Checked = false;
                ChkExBOOpeningCharge.Checked = false;
                ChkExBOCloseCharge.Checked = false;
                ChkExTaxCharge.Checked = false;
                ChkExTransmissionCharge.Checked = false;
                ChkExDemetCharge.Checked = false;
                ChkExCustodian.Checked = false;
                ChkExBankInterest.Checked = false;

                chkExTaxChargeBank.Checked = false;
                chkExDemetChargeBank.Checked = false;
                chkCustodianChargeBank.Checked = false;
            }

        }

        private void chkExDemetChargeBank_CheckedChanged(object sender, EventArgs e)
        {
            if (chkExDemetChargeBank.Checked == true)
            {
                ChkExInterest.Checked = false;
                ChkExCommission.Checked = false;
                ChkExIPOCharge.Checked = false;
                ChkExBOOpeningCharge.Checked = false;
                ChkExBOCloseCharge.Checked = false;
                ChkExTaxCharge.Checked = false;
                ChkExTransmissionCharge.Checked = false;
                ChkExDemetCharge.Checked = false;
                ChkExCustodian.Checked = false;
                ChkExBankInterest.Checked = false;

                chkExTaxChargeBank.Checked = false;
                chkExTransChargeBank.Checked = false;
                chkCustodianChargeBank.Checked = false;
            }

        }

        private void chkCustodianChargeBank_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCustodianChargeBank.Checked == true)
            {
                ChkExInterest.Checked = false;
                ChkExCommission.Checked = false;
                ChkExIPOCharge.Checked = false;
                ChkExBOOpeningCharge.Checked = false;
                ChkExBOCloseCharge.Checked = false;
                ChkExTaxCharge.Checked = false;
                ChkExTransmissionCharge.Checked = false;
                ChkExDemetCharge.Checked = false;
                ChkExCustodian.Checked = false;
                ChkExBankInterest.Checked = false;

                chkExTaxChargeBank.Checked = false;
                chkExTransChargeBank.Checked = false;
                chkExDemetChargeBank.Checked = false;
            }
        }

        private bool ValidationCheck()
        {
            if (
                ChkExInterest.Checked == false &&
                ChkExCommission.Checked == false &&
                ChkExIPOCharge.Checked == false &&
                ChkExBOOpeningCharge.Checked == false &&
                ChkExBOCloseCharge.Checked == false &&
                ChkExTaxCharge.Checked == false &&
                ChkExTransmissionCharge.Checked == false &&
                ChkExDemetCharge.Checked == false &&
                ChkExCustodian.Checked == false &&
                ChkExBankInterest.Checked == false &&
                chkExTaxChargeBank.Checked == false &&
                chkExTransChargeBank.Checked == false &&
                chkExDemetChargeBank.Checked == false &&
                chkCustodianChargeBank.Checked == false
                )
            {
                MessageBox.Show("Please Select One First...", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            else return false;
        }

        private void btnShowReport_Click(object sender, EventArgs e)
        {
            if (ValidationCheck())
                return;

            GetCommonInfo();

            if (ChkExInterest.Checked == true)
            {
                cr_LedgerReport_IPOCharge Report = new cr_LedgerReport_IPOCharge();
                frmReportViewer viewer = new frmReportViewer();
                DataTable reportData = new DataTable();

                string FromDate = dtpFromDate.Value.ToString("yyyy-MM-dd");
                string ToDate = dtpToDate.Value.ToString("yyyy-MM-dd");

                string ReportDate = "" + dtpFromDate.Value.ToString("MMM dd, yyyy") + "  To  " + dtpToDate.Value.ToString("MMM dd, yyyy") + "";

                reportData = BAL.LedgerReport_Interest(FromDate, ToDate);

                if (reportData.Rows.Count > 0)
                {
                    double OpBal = Convert.ToDouble(reportData.Rows[0][6].ToString());
                    string BB = string.Format("{0:0.00}", OpBal);

                    ((TextObject)Report.ReportDefinition.Sections[1].ReportObjects["txtCompanyName"]).Text = _CommpanyName;
                    ((TextObject)Report.ReportDefinition.Sections[1].ReportObjects["txtBranchName"]).Text = _branchName + ", " + _branchAddress + ", " + "Phone: " + _branchContactNumber;

                    ((TextObject)Report.ReportDefinition.Sections[1].ReportObjects["txtReportName"]).Text = "Ledger (Interest)";
                    ((TextObject)Report.ReportDefinition.Sections[1].ReportObjects["txtDate"]).Text = "Date Period : " + ReportDate + "";
                    ((TextObject)Report.ReportDefinition.Sections[1].ReportObjects["txtHeadCode"]).Text = "Head Code : I005";
                    ((TextObject)Report.ReportDefinition.Sections[1].ReportObjects["txtBBalance"]).Text = "Beginning Balance : " + BB + "";

                    Report.SetDataSource(reportData);
                    viewer.crvReportViewer.ReportSource = Report;
                    viewer.Show();
                }
                else
                {
                    MessageBox.Show("No Record Found Within Date Range...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dtpFromDate.Focus();
                }
            }
            else if (ChkExCommission.Checked == true)
            {
                cr_LedgerReport_IPOCharge Report = new cr_LedgerReport_IPOCharge();
                frmReportViewer viewer = new frmReportViewer();
                DataTable reportData = new DataTable();

                string FromDate = dtpFromDate.Value.ToString("yyyy-MM-dd");
                string ToDate = dtpToDate.Value.ToString("yyyy-MM-dd");

                string ReportDate = "" + dtpFromDate.Value.ToString("MMM dd, yyyy") + "  To  " + dtpToDate.Value.ToString("MMM dd, yyyy") + "";

                reportData = BAL.LedgerReport_Commission(FromDate, ToDate);

                if (reportData.Rows.Count > 0)
                {
                    double OpBal = Convert.ToDouble(reportData.Rows[0][6].ToString());
                    string BB = string.Format("{0:0.00}", OpBal);

                    //Additional Amount Information
                    DataTable AddData = new DataTable();
                    AddData = BAL.LedgerReport_Commission_AddInfo(FromDate, ToDate);



                    ((TextObject)Report.ReportDefinition.Sections[1].ReportObjects["txtCompanyName"]).Text = _CommpanyName;
                    ((TextObject)Report.ReportDefinition.Sections[1].ReportObjects["txtBranchName"]).Text = _branchName + ", " + _branchAddress + ", " + "Phone: " + _branchContactNumber;

                    ((TextObject)Report.ReportDefinition.Sections[1].ReportObjects["txtReportName"]).Text = "Ledger (Commission Charge)";
                    ((TextObject)Report.ReportDefinition.Sections[1].ReportObjects["txtDate"]).Text = "Date Period : " + ReportDate + "";
                    ((TextObject)Report.ReportDefinition.Sections[1].ReportObjects["txtHeadCode"]).Text = "Head Code : I001";
                    ((TextObject)Report.ReportDefinition.Sections[1].ReportObjects["txtBBalance"]).Text = "Beginning Balance : " + BB + "";

                    //Additional Information
                    ((TextObject)Report.ReportDefinition.Sections[1].ReportObjects["txtCollectedCommission"]).Text = "Total Commission";
                    ((TextObject)Report.ReportDefinition.Sections[1].ReportObjects["txtLaga"]).Text = "Laga Charge";
                    ((TextObject)Report.ReportDefinition.Sections[1].ReportObjects["txtHowla"]).Text = "Howla Charge";
                    ((TextObject)Report.ReportDefinition.Sections[1].ReportObjects["txtTax"]).Text = "Tax Charge";
                    ((TextObject)Report.ReportDefinition.Sections[1].ReportObjects["Text20"]).Text = ":";
                    ((TextObject)Report.ReportDefinition.Sections[1].ReportObjects["Text24"]).Text = ":";
                    ((TextObject)Report.ReportDefinition.Sections[1].ReportObjects["Text25"]).Text = ":";
                    ((TextObject)Report.ReportDefinition.Sections[1].ReportObjects["Text26"]).Text = ":";
                    ((TextObject)Report.ReportDefinition.Sections[1].ReportObjects["txtCollectedCommissionAmount"]).Text = string.Format("{0:0.00}", Convert.ToDouble(AddData.Rows[0][0].ToString()));
                    ((TextObject)Report.ReportDefinition.Sections[1].ReportObjects["txtLagaAmount"]).Text = string.Format("{0:0.00}", Convert.ToDouble(AddData.Rows[0][1].ToString()));
                    ((TextObject)Report.ReportDefinition.Sections[1].ReportObjects["txtHowlaAmount"]).Text = string.Format("{0:0.00}", Convert.ToDouble(AddData.Rows[0][2].ToString()));
                    ((TextObject)Report.ReportDefinition.Sections[1].ReportObjects["txtTaxAmount"]).Text = string.Format("{0:0.00}", Convert.ToDouble(AddData.Rows[0][3].ToString()));


                    Report.SetDataSource(reportData);
                    viewer.crvReportViewer.ReportSource = Report;
                    viewer.Show();
                }
                else
                {
                    MessageBox.Show("No Record Found Within Date Range...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dtpFromDate.Focus();
                }
            }
            else if (ChkExIPOCharge.Checked == true)
            {
                cr_LedgerReport_IPOCharge Report = new cr_LedgerReport_IPOCharge();
                frmReportViewer viewer = new frmReportViewer();
                DataTable reportData = new DataTable();

                string FromDate = dtpFromDate.Value.ToString("yyyy-MM-dd");
                string ToDate = dtpToDate.Value.ToString("yyyy-MM-dd");

                string ReportDate = "" + dtpFromDate.Value.ToString("MMM dd, yyyy") + "  To  " + dtpToDate.Value.ToString("MMM dd, yyyy") + "";

                reportData = BAL.LedgerReport_IPOCharge(FromDate, ToDate);


                if (reportData.Rows.Count > 0)
                {
                    double OpBal = Convert.ToDouble(reportData.Rows[0][6].ToString());
                    string BB = string.Format("{0:0.00}", OpBal);

                    ((TextObject)Report.ReportDefinition.Sections[1].ReportObjects["txtCompanyName"]).Text = _CommpanyName;
                    ((TextObject)Report.ReportDefinition.Sections[1].ReportObjects["txtBranchName"]).Text = _branchName + ", " + _branchAddress + ", " + "Phone: " + _branchContactNumber;

                    ((TextObject)Report.ReportDefinition.Sections[1].ReportObjects["txtReportName"]).Text = "Ledger (IPO Charge)";
                    ((TextObject)Report.ReportDefinition.Sections[1].ReportObjects["txtDate"]).Text = "Date Period : " + ReportDate + "";
                    ((TextObject)Report.ReportDefinition.Sections[1].ReportObjects["txtHeadCode"]).Text = "Head Code : I002";
                    ((TextObject)Report.ReportDefinition.Sections[1].ReportObjects["txtBBalance"]).Text = "Beginning Balance : " + BB + "";

                    Report.SetDataSource(reportData);
                    viewer.crvReportViewer.ReportSource = Report;
                    viewer.Show();
                }
                else
                {
                    MessageBox.Show("No Record Found Within Date Range...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dtpFromDate.Focus();
                }                

            }
            else if (ChkExBOOpeningCharge.Checked == true)
            {
                cr_LedgerReport_IPOCharge Report = new cr_LedgerReport_IPOCharge();
                frmReportViewer viewer = new frmReportViewer();
                DataTable reportData = new DataTable();

                string FromDate = dtpFromDate.Value.ToString("yyyy-MM-dd");
                string ToDate = dtpToDate.Value.ToString("yyyy-MM-dd");

                string ReportDate = "" + dtpFromDate.Value.ToString("MMM dd, yyyy") + "  To  " + dtpToDate.Value.ToString("MMM dd, yyyy") + "";

                reportData = BAL.LedgerReport_BOOpeningCharge(FromDate, ToDate);


                if (reportData.Rows.Count > 0)
                {
                    double OpBal = Convert.ToDouble(reportData.Rows[0][6].ToString());
                    string BB = string.Format("{0:0.00}", OpBal);

                    ((TextObject)Report.ReportDefinition.Sections[1].ReportObjects["txtCompanyName"]).Text = _CommpanyName;
                    ((TextObject)Report.ReportDefinition.Sections[1].ReportObjects["txtBranchName"]).Text = _branchName + ", " + _branchAddress + ", " + "Phone: " + _branchContactNumber;

                    ((TextObject)Report.ReportDefinition.Sections[1].ReportObjects["txtReportName"]).Text = "Ledger (BO Opening Charge)";
                    ((TextObject)Report.ReportDefinition.Sections[1].ReportObjects["txtDate"]).Text = "Date Period : " + ReportDate + "";
                    ((TextObject)Report.ReportDefinition.Sections[1].ReportObjects["txtHeadCode"]).Text = "Head Code : I007i";
                    ((TextObject)Report.ReportDefinition.Sections[1].ReportObjects["txtBBalance"]).Text = "Beginning Balance : " + BB + "";

                    Report.SetDataSource(reportData);
                    viewer.crvReportViewer.ReportSource = Report;
                    viewer.Show();
                }
                else
                {
                    MessageBox.Show("No Record Found Within Date Range...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dtpFromDate.Focus();
                }
            }
            else if (ChkExBOCloseCharge.Checked == true)
            {
                cr_LedgerReport_IPOCharge Report = new cr_LedgerReport_IPOCharge();
                frmReportViewer viewer = new frmReportViewer();
                DataTable reportData = new DataTable();

                string FromDate = dtpFromDate.Value.ToString("yyyy-MM-dd");
                string ToDate = dtpToDate.Value.ToString("yyyy-MM-dd");

                string ReportDate = "" + dtpFromDate.Value.ToString("MMM dd, yyyy") + "  To  " + dtpToDate.Value.ToString("MMM dd, yyyy") + "";

                reportData = BAL.LedgerReport_BOClosingCharge(FromDate, ToDate);


                if (reportData.Rows.Count > 0)
                {
                    double OpBal = Convert.ToDouble(reportData.Rows[0][6].ToString());
                    string BB = string.Format("{0:0.00}", OpBal);

                    ((TextObject)Report.ReportDefinition.Sections[1].ReportObjects["txtCompanyName"]).Text = _CommpanyName;
                    ((TextObject)Report.ReportDefinition.Sections[1].ReportObjects["txtBranchName"]).Text = _branchName + ", " + _branchAddress + ", " + "Phone: " + _branchContactNumber;

                    ((TextObject)Report.ReportDefinition.Sections[1].ReportObjects["txtReportName"]).Text = "Ledger (BO Closing Charge)";
                    ((TextObject)Report.ReportDefinition.Sections[1].ReportObjects["txtDate"]).Text = "Date Period : " + ReportDate + "";
                    ((TextObject)Report.ReportDefinition.Sections[1].ReportObjects["txtHeadCode"]).Text = "Head Code : I007ii";
                    ((TextObject)Report.ReportDefinition.Sections[1].ReportObjects["txtBBalance"]).Text = "Beginning Balance : " + BB + "";

                    Report.SetDataSource(reportData);
                    viewer.crvReportViewer.ReportSource = Report;
                    viewer.Show();
                }
                else
                {
                    MessageBox.Show("No Record Found Within Date Range...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dtpFromDate.Focus();
                }
            }
            else if (ChkExTaxCharge.Checked == true)
            {
                cr_LedgerReport_IPOCharge Report = new cr_LedgerReport_IPOCharge();
                frmReportViewer viewer = new frmReportViewer();
                DataTable reportData = new DataTable();

                string FromDate = dtpFromDate.Value.ToString("yyyy-MM-dd");
                string ToDate = dtpToDate.Value.ToString("yyyy-MM-dd");

                string ReportDate = "" + dtpFromDate.Value.ToString("MMM dd, yyyy") + "  To  " + dtpToDate.Value.ToString("MMM dd, yyyy") + "";

                reportData = BAL.LedgerReport_TaxCharge(FromDate, ToDate);


                if (reportData.Rows.Count > 0)
                {
                    double OpBal = Convert.ToDouble(reportData.Rows[0][6].ToString());
                    string BB = string.Format("{0:0.00}", OpBal);

                    ((TextObject)Report.ReportDefinition.Sections[1].ReportObjects["txtCompanyName"]).Text = _CommpanyName;
                    ((TextObject)Report.ReportDefinition.Sections[1].ReportObjects["txtBranchName"]).Text = _branchName + ", " + _branchAddress + ", " + "Phone: " + _branchContactNumber;

                    ((TextObject)Report.ReportDefinition.Sections[1].ReportObjects["txtReportName"]).Text = "Ledger (Tax Charge)";
                    ((TextObject)Report.ReportDefinition.Sections[1].ReportObjects["txtDate"]).Text = "Date Period : " + ReportDate + "";
                    ((TextObject)Report.ReportDefinition.Sections[1].ReportObjects["txtHeadCode"]).Text = "Head Code : I007iii";
                    ((TextObject)Report.ReportDefinition.Sections[1].ReportObjects["txtBBalance"]).Text = "Beginning Balance : " + BB + "";

                    Report.SetDataSource(reportData);
                    viewer.crvReportViewer.ReportSource = Report;
                    viewer.Show();
                }
                else
                {
                    MessageBox.Show("No Record Found Within Date Range...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dtpFromDate.Focus();
                }
            }
            else if (ChkExTransmissionCharge.Checked == true)
            {
                cr_LedgerReport_IPOCharge Report = new cr_LedgerReport_IPOCharge();
                frmReportViewer viewer = new frmReportViewer();
                DataTable reportData = new DataTable();

                string FromDate = dtpFromDate.Value.ToString("yyyy-MM-dd");
                string ToDate = dtpToDate.Value.ToString("yyyy-MM-dd");

                string ReportDate = "" + dtpFromDate.Value.ToString("MMM dd, yyyy") + "  To  " + dtpToDate.Value.ToString("MMM dd, yyyy") + "";

                reportData = BAL.LedgerReport_TransmissionCharge(FromDate, ToDate);


                if (reportData.Rows.Count > 0)
                {
                    double OpBal = Convert.ToDouble(reportData.Rows[0][6].ToString());
                    string BB = string.Format("{0:0.00}", OpBal);

                    ((TextObject)Report.ReportDefinition.Sections[1].ReportObjects["txtCompanyName"]).Text = _CommpanyName;
                    ((TextObject)Report.ReportDefinition.Sections[1].ReportObjects["txtBranchName"]).Text = _branchName + ", " + _branchAddress + ", " + "Phone: " + _branchContactNumber;

                    ((TextObject)Report.ReportDefinition.Sections[1].ReportObjects["txtReportName"]).Text = "Ledger (Transmission Charge)";
                    ((TextObject)Report.ReportDefinition.Sections[1].ReportObjects["txtDate"]).Text = "Date Period : " + ReportDate + "";
                    ((TextObject)Report.ReportDefinition.Sections[1].ReportObjects["txtHeadCode"]).Text = "Head Code : I007v";
                    ((TextObject)Report.ReportDefinition.Sections[1].ReportObjects["txtBBalance"]).Text = "Beginning Balance : " + BB + "";

                    Report.SetDataSource(reportData);
                    viewer.crvReportViewer.ReportSource = Report;
                    viewer.Show();
                }
                else
                {
                    MessageBox.Show("No Record Found Within Date Range...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dtpFromDate.Focus();
                }
            }
            else if (ChkExDemetCharge.Checked == true)
            {
                cr_LedgerReport_IPOCharge Report = new cr_LedgerReport_IPOCharge();
                frmReportViewer viewer = new frmReportViewer();
                DataTable reportData = new DataTable();

                string FromDate = dtpFromDate.Value.ToString("yyyy-MM-dd");
                string ToDate = dtpToDate.Value.ToString("yyyy-MM-dd");

                string ReportDate = "" + dtpFromDate.Value.ToString("MMM dd, yyyy") + "  To  " + dtpToDate.Value.ToString("MMM dd, yyyy") + "";

                reportData = BAL.LedgerReport_DemetCharge(FromDate, ToDate);


                if (reportData.Rows.Count > 0)
                {
                    double OpBal = Convert.ToDouble(reportData.Rows[0][6].ToString());
                    string BB = string.Format("{0:0.00}", OpBal);

                    ((TextObject)Report.ReportDefinition.Sections[1].ReportObjects["txtCompanyName"]).Text = _CommpanyName;
                    ((TextObject)Report.ReportDefinition.Sections[1].ReportObjects["txtBranchName"]).Text = _branchName + ", " + _branchAddress + ", " + "Phone: " + _branchContactNumber;

                    ((TextObject)Report.ReportDefinition.Sections[1].ReportObjects["txtReportName"]).Text = "Ledger (Demet Charge)";
                    ((TextObject)Report.ReportDefinition.Sections[1].ReportObjects["txtDate"]).Text = "Date Period : " + ReportDate + "";
                    ((TextObject)Report.ReportDefinition.Sections[1].ReportObjects["txtHeadCode"]).Text = "Head Code : I007iv";
                    ((TextObject)Report.ReportDefinition.Sections[1].ReportObjects["txtBBalance"]).Text = "Beginning Balance : " + BB + "";

                    Report.SetDataSource(reportData);
                    viewer.crvReportViewer.ReportSource = Report;
                    viewer.Show();
                }
                else
                {
                    MessageBox.Show("No Record Found Within Date Range...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dtpFromDate.Focus();
                }
            }
            else if (ChkExCustodian.Checked == true)
            {
                cr_LedgerReport_IPOCharge Report = new cr_LedgerReport_IPOCharge();
                frmReportViewer viewer = new frmReportViewer();
                DataTable reportData = new DataTable();

                string FromDate = dtpFromDate.Value.ToString("yyyy-MM-dd");
                string ToDate = dtpToDate.Value.ToString("yyyy-MM-dd");

                string ReportDate = "" + dtpFromDate.Value.ToString("MMM dd, yyyy") + "  To  " + dtpToDate.Value.ToString("MMM dd, yyyy") + "";

                reportData = BAL.LedgerReport_CustodianCharge(FromDate, ToDate);


                if (reportData.Rows.Count > 0)
                {
                    double OpBal = Convert.ToDouble(reportData.Rows[0][6].ToString());
                    string BB = string.Format("{0:0.00}", OpBal);

                    ((TextObject)Report.ReportDefinition.Sections[1].ReportObjects["txtCompanyName"]).Text = _CommpanyName;
                    ((TextObject)Report.ReportDefinition.Sections[1].ReportObjects["txtBranchName"]).Text = _branchName + ", " + _branchAddress + ", " + "Phone: " + _branchContactNumber;

                    ((TextObject)Report.ReportDefinition.Sections[1].ReportObjects["txtReportName"]).Text = "Ledger (Custodian Charge)";
                    ((TextObject)Report.ReportDefinition.Sections[1].ReportObjects["txtDate"]).Text = "Date Period : " + ReportDate + "";
                    ((TextObject)Report.ReportDefinition.Sections[1].ReportObjects["txtHeadCode"]).Text = "Head Code : I007vi";
                    ((TextObject)Report.ReportDefinition.Sections[1].ReportObjects["txtBBalance"]).Text = "Beginning Balance : " + BB + "";

                    Report.SetDataSource(reportData);
                    viewer.crvReportViewer.ReportSource = Report;
                    viewer.Show();
                }
                else
                {
                    MessageBox.Show("No Record Found Within Date Range...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dtpFromDate.Focus();
                }
            }
            else if (ChkExBankInterest.Checked == true)
            {
                cr_LedgerReport_IPOCharge Report = new cr_LedgerReport_IPOCharge();
                frmReportViewer viewer = new frmReportViewer();
                DataTable reportData = new DataTable();

                string FromDate = dtpFromDate.Value.ToString("yyyy-MM-dd");
                string ToDate = dtpToDate.Value.ToString("yyyy-MM-dd");

                string ReportDate = "" + dtpFromDate.Value.ToString("MMM dd, yyyy") + "  To  " + dtpToDate.Value.ToString("MMM dd, yyyy") + "";

                reportData = BAL.LedgerReport_BankInterestCharge(FromDate, ToDate);


                if (reportData.Rows.Count > 0)
                {
                    double OpBal = Convert.ToDouble(reportData.Rows[0][6].ToString());
                    string BB = string.Format("{0:0.00}", OpBal);

                    ((TextObject)Report.ReportDefinition.Sections[1].ReportObjects["txtCompanyName"]).Text = _CommpanyName;
                    ((TextObject)Report.ReportDefinition.Sections[1].ReportObjects["txtBranchName"]).Text = _branchName + ", " + _branchAddress + ", " + "Phone: " + _branchContactNumber;

                    ((TextObject)Report.ReportDefinition.Sections[1].ReportObjects["txtReportName"]).Text = "Ledger (Bank Interest)";
                    ((TextObject)Report.ReportDefinition.Sections[1].ReportObjects["txtDate"]).Text = "Date Period : " + ReportDate + "";
                    ((TextObject)Report.ReportDefinition.Sections[1].ReportObjects["txtHeadCode"]).Text = "Head Code : I004i";
                    ((TextObject)Report.ReportDefinition.Sections[1].ReportObjects["txtBBalance"]).Text = "Beginning Balance : " + BB + "";

                    Report.SetDataSource(reportData);
                    viewer.crvReportViewer.ReportSource = Report;
                    viewer.Show();
                }
                else
                {
                    MessageBox.Show("No Record Found Within Date Range...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dtpFromDate.Focus();
                }
            }
            else if (chkExTaxChargeBank.Checked == true)
            {
                cr_LedgerReport_IPOCharge Report = new cr_LedgerReport_IPOCharge();
                frmReportViewer viewer = new frmReportViewer();
                DataTable reportData = new DataTable();

                string FromDate = dtpFromDate.Value.ToString("yyyy-MM-dd");
                string ToDate = dtpToDate.Value.ToString("yyyy-MM-dd");

                string ReportDate = "" + dtpFromDate.Value.ToString("MMM dd, yyyy") + "  To  " + dtpToDate.Value.ToString("MMM dd, yyyy") + "";

                reportData = BAL.LedgerReport_TaxCertCharge_Bank(FromDate, ToDate);


                if (reportData.Rows.Count > 0)
                {
                    double OpBal = Convert.ToDouble(reportData.Rows[0][6].ToString());
                    string BB = string.Format("{0:0.00}", OpBal);

                    ((TextObject)Report.ReportDefinition.Sections[1].ReportObjects["txtCompanyName"]).Text = _CommpanyName;
                    ((TextObject)Report.ReportDefinition.Sections[1].ReportObjects["txtBranchName"]).Text = _branchName + ", " + _branchAddress + ", " + "Phone: " + _branchContactNumber;

                    ((TextObject)Report.ReportDefinition.Sections[1].ReportObjects["txtReportName"]).Text = "Ledger (Tax Cet. Charge Bank)";
                    ((TextObject)Report.ReportDefinition.Sections[1].ReportObjects["txtDate"]).Text = "Date Period : " + ReportDate + "";
                    ((TextObject)Report.ReportDefinition.Sections[1].ReportObjects["txtHeadCode"]).Text = "Head Code : I008i";
                    ((TextObject)Report.ReportDefinition.Sections[1].ReportObjects["txtBBalance"]).Text = "Beginning Balance : " + BB + "";

                    Report.SetDataSource(reportData);
                    viewer.crvReportViewer.ReportSource = Report;
                    viewer.Show();
                }
                else
                {
                    MessageBox.Show("No Record Found Within Date Range...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dtpFromDate.Focus();
                }
            }
            else if (chkExTransChargeBank.Checked == true)
            { 
                //
            }
            else if (chkExDemetChargeBank.Checked == true)
            { 
                //
            }
            else if (chkCustodianChargeBank.Checked == true)
            { 
                //
            }
            else
            {

            }
        }
        private void GetCommonInfo()
        {
            try
            {
                CommonInfoBal objCommonInfoBal = new CommonInfoBal();
                DataRow drCommonInfo = null;

                drCommonInfo = objCommonInfoBal.GetCommpanyInfo();

                if (drCommonInfo != null)
                {
                    _CommpanyName = drCommonInfo.Table.Rows[0][0].ToString();
                    _branchName = drCommonInfo.Table.Rows[0][1].ToString();
                    _branchAddress = drCommonInfo.Table.Rows[0][2].ToString();
                    _branchContactNumber = drCommonInfo.Table.Rows[0][3].ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
