using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;

namespace StockbrokerProNewArch
{
    public partial class frmViewAllEmployee : Form
    {
        public frmViewAllEmployee()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private DateTime _seletedMonth;
        public DateTime SeletedMonth
        {
            get { return _seletedMonth; }
            set { _seletedMonth = value; }
        }

        private void frmViewAllEmployee_Load(object sender, EventArgs e)
        {
            try
            {
                LoadEmployeeInfo();
                GetCommonInfo();
                ActiveToSalaryConfirmation();
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
                EmployeeInformationBAL objEmployeeInfoBal = new EmployeeInformationBAL();
                objEmployeeInfoBal.GetCommonInfo();
                lblTotalDepartment.Text= "Total Department  : " + objEmployeeInfoBal.TotalDepartment.ToString();
                lblTotalJobPosition.Text= "Total Designation  : " + objEmployeeInfoBal.TotalJobPosition.ToString();
                lblTotalEmployee.Text="Total Employee     : " + objEmployeeInfoBal.TotalRecord.ToString();

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void LoadEmployeeInfo()
        {
            try
            {
                EmployeeSalaryInfoBal objEmployeeSalaryInfo = new EmployeeSalaryInfoBal();
                DataTable dtEmployeeInfo = new DataTable();

                dtEmployeeInfo = objEmployeeSalaryInfo.GetEmployeeConfirmationSalary(SeletedMonth);
                dgvEmployeeInfo.DataSource = dtEmployeeInfo;
                groupBox1.Text = "For the Month of "+SeletedMonth.ToString("dd-MMM-yyyy");

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void dgvEmployeeInfo_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void ActiveToSalaryConfirmation()
        {
            try
            {
                if(dgvEmployeeInfo.SelectedRows.Count>0)
                {
                    btnConfirmSalary.Enabled = true;
                    btnConfirmSalary.Text = "Salary For " + dgvEmployeeInfo.SelectedRows[0].Cells[0].Value.ToString();
                }

                else
                {
                    btnConfirmSalary.Enabled = false;
                    btnConfirmSalary.Text = "Confirmation";
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void dgvEmployeeInfo_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                ActiveToSalaryConfirmation();

              
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void dgvEmployeeInfo_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                GOToSalaryConfirmationAction();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void GOToSalaryConfirmationAction()
        {
            try
            {
                if (dgvEmployeeInfo.SelectedRows.Count > 0)
                {
                    string employeecode = dgvEmployeeInfo.SelectedRows[0].Cells[0].Value.ToString();
                    frmAddPayroll objpayroll = new frmAddPayroll();
                    objpayroll.PayrollDate = SeletedMonth;
                    objpayroll.Text = "Salary Information of " + employeecode;
                    objpayroll.EmployeeCode = employeecode;
                    objpayroll.ShowDialog();

                    if(objpayroll.ConfirmSalary==DialogResult.Yes)
                    {
                        LoadEmployeeInfo();
                    }
                }

                else
                {
                    btnConfirmSalary.Enabled = false;
                    btnConfirmSalary.Text = "Salary Confirmation";
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void btnConfirmSalary_Click(object sender, EventArgs e)
        {
            try
            {
                GOToSalaryConfirmationAction();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
