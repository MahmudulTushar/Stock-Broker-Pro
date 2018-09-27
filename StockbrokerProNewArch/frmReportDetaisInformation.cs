using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAcessLayer.BAL;
using CrystalDecisions.CrystalReports.Engine;

namespace SBP_Payroll_Pro
{
    public partial class frmReportDetaisInformation : Form
    {
        public frmReportDetaisInformation()
        {
            InitializeComponent();
        }


        private string _CommpanyName;
        private string _branchName;
        private string _branchAddress;
        private string _branchContactNumber;

        private int _reportValue;
        public int ReportValue
        {
            get { return _reportValue; }
            set { _reportValue = value; }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmReportDetaisInformation_Load(object sender, EventArgs e)
        {
            try
            {
                GetEmployeeList();
                GetEmployeeInfo(ddlEmoloyeeList.Text);
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message);
            }
        }

        private void GetEmployeeList()
        {
            try
            {
                ReportBAL objReportBal = new ReportBAL();
                DataTable dtEmployeeList = new DataTable();


                dtEmployeeList = objReportBal.GetEmployeeCode();
                ddlEmoloyeeList.DisplayMember = "EmployeeCode"; 
                ddlEmoloyeeList.DataSource = dtEmployeeList;
                          


            }
            catch (Exception)
            {

                throw;
            }
        }

        private void GetEmployeeInfo(string emoployeeCode)
        {
            try
            {
                ReportBAL objReportBal=new ReportBAL();
                DataTable dtEmployeeInfo=new DataTable();
                dtEmployeeInfo = objReportBal.GetEmployeeCommonInfo(emoployeeCode);

                txtName.Text = dtEmployeeInfo.Rows[0][0].ToString();
                txtDepartment.Text = dtEmployeeInfo.Rows[0][1].ToString();
                txtDesignation.Text = dtEmployeeInfo.Rows[0][2].ToString();

            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            try
            {
                if(_reportValue==1)
                {
                    GetEmployeeDatailsInfo(ddlEmoloyeeList.Text);
                }

                else if(_reportValue==2)
                {
                    GetEmployeewiseSalaryHistory(ddlEmoloyeeList.Text);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
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

        private void GetEmployeeDatailsInfo(string EmployeeCode)
        {
            try
            {
                ReportBAL objReportBal=new ReportBAL();
                DataTable dtReportBal=new DataTable();
                cr_EmployeeDetaisInformation objEmployee=new cr_EmployeeDetaisInformation();
                frmReportViewer objReportviewer=new frmReportViewer();

                dtReportBal = objReportBal.GetEmployeeDetailsInfo(EmployeeCode);
                objEmployee.SetDataSource(dtReportBal);

                GetCommonInfo();
                ((TextObject)objEmployee.ReportDefinition.Sections[2].ReportObjects["txtCompanyName"]).Text = _CommpanyName;
                ((TextObject)objEmployee.ReportDefinition.Sections[2].ReportObjects["txtAddress"]).Text = "Branch Name:" + _branchName + "," + _branchAddress + ". Phone:" + _branchContactNumber;


                objReportviewer.crvReportViewer.ReportSource = objEmployee;
                objReportviewer.crvReportViewer.DisplayGroupTree = false;
                
                objReportviewer.Text = "Personal Profile";
                objReportviewer.Show();



            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void GetEmployeewiseSalaryHistory(string EmployeeCode)
        {
            try
            {
                ReportBAL objReportBal = new ReportBAL();
                DataTable dtReportBal = new DataTable();
                cr_EmployeeWiseSalaryHistory objEmployee = new cr_EmployeeWiseSalaryHistory();
                frmReportViewer objReportviewer = new frmReportViewer();

                dtReportBal = objReportBal.GetEmployeeWiseSalaryHistoy(EmployeeCode);
                objEmployee.SetDataSource(dtReportBal);

                GetCommonInfo();
                ((TextObject)objEmployee.ReportDefinition.Sections[2].ReportObjects["txtCompanyName"]).Text = _CommpanyName;
                ((TextObject)objEmployee.ReportDefinition.Sections[2].ReportObjects["txtAddress"]).Text = "Branch Name:" + _branchName + "," + _branchAddress + ". Phone:" + _branchContactNumber;

                ((TextObject)objEmployee.ReportDefinition.Sections[2].ReportObjects["txtEmployeeCode"]).Text = EmployeeCode;
                ((TextObject)objEmployee.ReportDefinition.Sections[2].ReportObjects["txtName"]).Text =txtName.Text;
                ((TextObject)objEmployee.ReportDefinition.Sections[2].ReportObjects["txtDepartment"]).Text = txtDepartment.Text;
                ((TextObject)objEmployee.ReportDefinition.Sections[2].ReportObjects["txtDesignation"]).Text = txtDesignation.Text;


                objReportviewer.crvReportViewer.ReportSource = objEmployee;
                objReportviewer.crvReportViewer.DisplayGroupTree = false;
                objReportviewer.Text = "Personal Salary Report";
                objReportviewer.Show();



            }
            catch (Exception)
            {

                throw;
            }
        }


        private void ddlEmoloyeeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GetEmployeeInfo(ddlEmoloyeeList.Text);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }


    }
}
