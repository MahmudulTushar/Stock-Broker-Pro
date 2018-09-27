using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;

namespace CAPEX
{
    public partial class frmCapex : Form
    {
        public frmCapex()
        {
            InitializeComponent();
        }

        private void noDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNoDepreciation objNoDepreciation=new frmNoDepreciation();
            objNoDepreciation.Show();
        }

        private void decliningBalanceDepreciationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void currentAssetListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                GetCurrentAssetList();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message,"Current Asset List",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void GetCurrentAssetList()
        {
            try
            {
                AssetInformationBAL objAssetInformationBal=new AssetInformationBAL();
                DataTable dtCurrentAssetList=new DataTable();
                frmCapexReportViewer objfrmReportViewer=new frmCapexReportViewer();
                cr_CapexCurrentAssetList objcrCurrentAssetList = new cr_CapexCurrentAssetList();

                dtCurrentAssetList = objAssetInformationBal.GetCurrentAssetInfo();
                objcrCurrentAssetList.SetDataSource(dtCurrentAssetList);
                objfrmReportViewer.crvReportView.ReportSource = objcrCurrentAssetList;
                objfrmReportViewer.Text = "Current Asset List";
                objfrmReportViewer.Show();

            }
            catch (Exception)
            {
                
                throw;
            }
        }

      /*  private void GetTotalExpenseList()
        {
            try
            {
                AssetInformationBAL objAssetInformationBal = new AssetInformationBAL();
                DataTable dtTotalExpenseLise = new DataTable();
                frmCapexReportViewer objfrmReportViewer = new frmCapexReportViewer();
                CrTotalExpense objcrTotalAssetList = new CrTotalExpense();

                dtTotalExpenseLise = objAssetInformationBal.GetTotalAssetExpense();
                objcrTotalAssetList.SetDataSource(dtTotalExpenseLise);
                objfrmReportViewer.crvReportView.ReportSource = objcrTotalAssetList;
                objfrmReportViewer.Text = "Total Expense List";
                objfrmReportViewer.Show();

            }
            catch (Exception)
            {

                throw;
            }
        }*/

        private void monthlyExpenseListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCapexMonthlyExpense objfrmExpense=new frmCapexMonthlyExpense();
            objfrmExpense.Text = "Monthly Expense List";
            objfrmExpense.Show();
        }

        private void totalExpenseListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
               // GetTotalExpenseList();
            }
            catch (Exception ex)
            {
                
               MessageBox.Show(ex.Message);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmDeleteCapexInformation objDeleteCapex=new frmDeleteCapexInformation();
            objDeleteCapex.Show();
        }


    }
}
