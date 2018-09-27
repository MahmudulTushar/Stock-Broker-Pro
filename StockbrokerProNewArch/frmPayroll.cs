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
    public partial class frmPayroll : Form
    {
        public frmPayroll()
        {
            InitializeComponent();
        }

        private DateTime _seletedMonth;
        public DateTime SeletctedMonth
        {
            get { return _seletedMonth; }
            set { _seletedMonth = value; }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPayrollOperation_Load(object sender, EventArgs e)
        {
            groupBox3.Text = "For the Month: "+_seletedMonth.ToString("MMMM-yyyy");
            GetSalaryInfo(SeletctedMonth);
            GetCommonInfo();

        }

        private void GetCommonInfo()
        {
            try
            {
                EmployeeInformationBAL objEmployeeInfoBal = new EmployeeInformationBAL();
                objEmployeeInfoBal.GetCommonInfo();
                lblTotalDepartment.Text = "Total Department  : " + objEmployeeInfoBal.TotalDepartment.ToString();
                lblTotalJobPosition.Text = "Total Designation  : " + objEmployeeInfoBal.TotalJobPosition.ToString();
                lblTotalEmployee.Text = "Total Employee     : " + objEmployeeInfoBal.TotalRecord.ToString();

            }
            catch (Exception)
            {

                throw;
            }
        }


        private void GetSalaryInfo(DateTime payrollDate)
        {
            try
            {
                EmployeeSalaryInfoBal objEmplyeeSalaryInfo=new EmployeeSalaryInfoBal();
                DataTable dtSalaryInfo=new DataTable();
                dtSalaryInfo = objEmplyeeSalaryInfo.GetEmployeeSalaryInformation(payrollDate);
                dgvSalaryInfo.DataSource = dtSalaryInfo;
                dgvSalaryInfo.Columns[0].Visible = false;
                
                if(dgvSalaryInfo.Rows.Count>0)
                {
                    btnRemoveSalary.Enabled = true;
                    btnRemoveSalary.Text = "Remove Code" + dgvSalaryInfo.SelectedRows[0].Cells[1].Value.ToString();

                }

                else
                {
                    btnRemoveSalary.Enabled = false;
                    btnRemoveSalary.Text = "Remove";

                }

            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                frmViewAllEmployee objEmployeeAllInfo=new frmViewAllEmployee();
                objEmployeeAllInfo.SeletedMonth = _seletedMonth;
                Close();
                objEmployeeAllInfo.ShowDialog();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void dgvSalaryInfo_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if(dgvSalaryInfo.Rows.Count>0)
                {
                    
                    btnRemoveSalary.Enabled = true;
                    btnRemoveSalary.Text = "Remove Code: "+ dgvSalaryInfo.SelectedRows[0].Cells[1].Value.ToString();

                }

                else
                {
                    btnRemoveSalary.Enabled = false;
                    btnRemoveSalary.Text = "Remove Salary";
                }
              


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void RemoveEmployeeSalaryInfo(int SalaryId)
        {
            try
            {
                if(MessageBox.Show("Do you want to Delete this Information?","",MessageBoxButtons.YesNo,MessageBoxIcon.Information)==DialogResult.Yes)
                {
                    EmployeeSalaryInfoBal objEmployeeSalaryInfo=new EmployeeSalaryInfoBal();
                    objEmployeeSalaryInfo.DeleteToSalaryInfo(SalaryId);
                    MessageBox.Show("Secessfully Delete the Information", "", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    GetSalaryInfo(SeletctedMonth);
                    
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
                int salaryId = Int32.Parse(dgvSalaryInfo.SelectedRows[0].Cells[0].Value.ToString());
                RemoveEmployeeSalaryInfo(salaryId);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void dgvSalaryInfo_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                int salaryId = Int32.Parse(dgvSalaryInfo.SelectedRows[0].Cells[0].Value.ToString());
                RemoveEmployeeSalaryInfo(salaryId);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
