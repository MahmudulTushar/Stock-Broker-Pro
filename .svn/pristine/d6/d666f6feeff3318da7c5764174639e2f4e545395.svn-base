using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using CrystalDecisions.CrystalReports.Engine;

namespace CAPEX
{
    public partial class frmCapexMonthlyExpense : Form
    {
        public frmCapexMonthlyExpense()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMonthlyExpense_Load(object sender, EventArgs e)
        {

        }

       

        private void btnview_Click(object sender, EventArgs e)
        {
           try
            {
                if(checkToDatepickerValue())
                ShowMonthlyExpenseReport(dtpFromDate.Value,dtpToDate.Value);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Monthly Expense", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpFromDate.Focus();
            }
        }

        private bool checkToDatepickerValue()
        {
            bool status = false;

            try
            {
                if(dtpFromDate.Value>dtpToDate.Value)
                {
                    status = false;
                    MessageBox.Show("From Date nust be before than To Date","",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    dtpFromDate.Focus();
                }

                else
                {
                    status = true;
                }

            }
            catch (Exception)
            {
                
                throw;
            }

            return status;
        }

        private void ShowMonthlyExpenseReport(DateTime FromDate,DateTime ToDate)
        {
            try
            {
                AssetInformationBAL objAssetInfoBal=new AssetInformationBAL();
                DataTable dtMonthlyExpenseInfo = new DataTable();
                cr_CapexMonthlyExpenseReport objcrMonthlyExpenseInfo = new cr_CapexMonthlyExpenseReport();
                frmCapexReportViewer objfrmMonthlyExpenseInfo=new frmCapexReportViewer();

                dtMonthlyExpenseInfo = objAssetInfoBal.GetMonthlyCapexReport(FromDate,ToDate);
                objcrMonthlyExpenseInfo.SetDataSource(dtMonthlyExpenseInfo);

                ((TextObject)objcrMonthlyExpenseInfo.ReportDefinition.Sections[2].ReportObjects["txtFromDate"]).Text ="Fom: " + dtpFromDate.Value.ToString("MM-dd-yyyy");
                ((TextObject)objcrMonthlyExpenseInfo.ReportDefinition.Sections[2].ReportObjects["txtToDate"]).Text = "To: " + dtpToDate.Value.ToString("MM-dd-yyyy");

                objfrmMonthlyExpenseInfo.Text = "Monthly Expense Report";
                objfrmMonthlyExpenseInfo.crvReportView.ReportSource = objcrMonthlyExpenseInfo;
                objfrmMonthlyExpenseInfo.Show();


            }
            catch (Exception)
            {
                
                throw;
            }

        }
    }
}
