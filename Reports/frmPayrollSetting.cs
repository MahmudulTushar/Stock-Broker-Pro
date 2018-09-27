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

namespace Reports
{
    public partial class frmPayrollSetting : Form
    {
        public frmPayrollSetting()
        {
            InitializeComponent();
        }

        private string _CommpanyName;
        private string _branchName;
        private string _branchAddress;
        private string _branchContactNumber;

        private int _operationValue;
        public int OperationValue
        {
            get { return _operationValue; }
            set { _operationValue = value; }
        }

       

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            

           if(_operationValue==3)
            {
                this.Cursor = Cursors.WaitCursor;
                GetEmployeeSalaryHistory(dtpMonth.Value);
                this.Cursor = Cursors.Arrow;
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
            catch (Exception)
            {

                throw;
            }
        }

        private void GetEmployeeSalaryHistory(DateTime payrollDate)
        {
            try
            {
                ReportBAL objReportBal = new ReportBAL();
                DataTable dtReportBal = new DataTable();
                cr_SalaryHistory objEmployee = new cr_SalaryHistory();
                frmReportViewer objReportviewer = new frmReportViewer();

                dtReportBal = objReportBal.GetEmployeeSalaryHistory(payrollDate);
                objEmployee.SetDataSource(dtReportBal);

                GetCommonInfo();
                ((TextObject)objEmployee.ReportDefinition.Sections[2].ReportObjects["txtCompanyName"]).Text = _CommpanyName;
                ((TextObject)objEmployee.ReportDefinition.Sections[2].ReportObjects["txtAddress"]).Text = "Branch Name:" + _branchName + "," + _branchAddress + ". Phone:" + _branchContactNumber;

                ((TextObject)objEmployee.ReportDefinition.Sections[2].ReportObjects["txtReport"]).Text ="Salary History For the Month of " + payrollDate.ToString("MMMM-yyyy");



                objReportviewer.crvReportViewer.ReportSource = objEmployee;
                objReportviewer.crvReportViewer.DisplayGroupTree = false;
                objReportviewer.Text = "Salary Sheet of "+payrollDate.ToString("MMMM,yyyy");
                objReportviewer.Show();



            }
            catch (Exception)
            {

                throw;
            }
        }



        private void frmPayrollSetting_Load(object sender, EventArgs e)
        {

        }
    }
}
