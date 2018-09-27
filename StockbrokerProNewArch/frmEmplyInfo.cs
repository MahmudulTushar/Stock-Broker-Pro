using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using BusinessAccessLayer.BO;

namespace StockbrokerProNewArch
{
    public partial class frmEmplyInfo : Form
    {
        public frmEmplyInfo()
        {
            InitializeComponent();
        }

        private void addNewEmplyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddNewEmployee objfrmEmpInfo = new frmAddNewEmployee();
            objfrmEmpInfo.Text = "Add New Employee Information";
            objfrmEmpInfo.Show();
        }

        private void frmEmplyInfo_Load(object sender, EventArgs e)
        {
            try
            {
                ddlSearchBy.SelectedIndex = 0;
                LoadEmployeeInfo();
                GetCommonInfo();
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
                EmployeeInformationBAL objEmployeeInfoBal=new EmployeeInformationBAL();
                objEmployeeInfoBal.GetCommonInfo();
                lblDepartment.Text =objEmployeeInfoBal.TotalDepartment.ToString();
                lblJobpostion.Text = objEmployeeInfoBal.TotalJobPosition.ToString();
                lblEmployee.Text= objEmployeeInfoBal.TotalRecord.ToString();

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
                EmployeeInformationBAL objEmployeeInfo=new EmployeeInformationBAL();
                DataTable dtEmployeeInfo=new DataTable();

                dtEmployeeInfo = objEmployeeInfo.GetEmployeeInformation();

                dgvEmployeeInfo.DataSource = dtEmployeeInfo;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void modifyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvEmployeeInfo.Rows.Count > 0)
                {
                    string employeeCode = dgvEmployeeInfo.SelectedRows[0].Cells[0].Value.ToString();
                    GoToModifyEmployeeInfo(employeeCode);
                }
              
            }
            catch (Exception ex )
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void GoToModifyEmployeeInfo(string EmployeeCode)
        {
            try
            {
                if(EmployeeCode=="")
                {
                    MessageBox.Show("No Employee Seleted.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                else
                {
                   frmAddNewEmployee objAddEmployeeInfo=new frmAddNewEmployee();
                    objAddEmployeeInfo.EmployeeCode = EmployeeCode;
                    objAddEmployeeInfo.Text = "Modify Employee information Code-"+EmployeeCode;
                    objAddEmployeeInfo.Show();
                }

            }
            catch (Exception)
            {
                
                throw;
            }

        }

       

       

        private void deleteEmployeeInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if(dgvEmployeeInfo.Rows.Count>0)
                {
                    string employeeCode = dgvEmployeeInfo.SelectedRows[0].Cells[0].Value.ToString();
                    DeleteToEmployeeInfo(employeeCode);
                }

               
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
          
        }

        private void DeleteToEmployeeInfo(string employeeCode)
        {
            try
            {
                if(MessageBox.Show("Do you want to Delete this Information ?","",MessageBoxButtons.YesNo,MessageBoxIcon.Information)==DialogResult.Yes)
                {
                    frmRemarks objRemarks=new frmRemarks();
                    objRemarks.EmployeeCode = employeeCode;
                    objRemarks.ShowDialog();
                    string Remarks = objRemarks.Remarks;

                    if(Remarks!="" && objRemarks.DialogResult==DialogResult.Yes)
                    {
                        EmployeeInformationBAL objEmployeeInfo = new EmployeeInformationBAL();
                        DeleteEmployeeRemorksBO objRemarkBO=new DeleteEmployeeRemorksBO();

                        objRemarkBO.Remarks = Remarks;
                        objRemarkBO.EmployeeCode = employeeCode;
                        objEmployeeInfo.DeleteToEmployeeInfo(employeeCode,objRemarkBO);
                        MessageBox.Show("Data is Secessfully Deleted.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadEmployeeInfo();

                    }
                   
                }
                


            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ddlSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SelectSearchPanel();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void SelectSearchPanel()
        {
            try
            {
                if(ddlSearchBy.SelectedIndex==0)
                {
                    lblSearchName.Text = "Code        :";
                    txtSearchCode.Focus();
                }

                else if(ddlSearchBy.SelectedIndex==1)
                {
                    lblSearchName.Text = "Name        :";
                    txtSearchCode.Focus();
                }

                else
                {
                    lblSearchName.Text = "Contact No :";
                    txtSearchCode.Focus();
                }

            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Search();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Search()
        {
            try
            {
                if(txtSearchCode.Text==String.Empty)
                {
                    MessageBox.Show("Search Code Required.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSearchCode.Focus();
                }

                else
                {
                    EmployeeInformationBAL objEmployeeInfoBal=new EmployeeInformationBAL();
                    DataTable dtEmployeeInfo=new DataTable();

                    if(ddlSearchBy.SelectedIndex==0)
                    {
                        dtEmployeeInfo = objEmployeeInfoBal.GetEmployeeCommonInfoByCode(txtSearchCode.Text);
                        dgvEmployeeInfo.DataSource = dtEmployeeInfo;
                    }

                    else if(ddlSearchBy.SelectedIndex==1)
                    {
                        dtEmployeeInfo = objEmployeeInfoBal.GetEmployeeCommonInfoByName(txtSearchCode.Text);
                        dgvEmployeeInfo.DataSource = dtEmployeeInfo;
                    }

                    else if(ddlSearchBy.SelectedIndex==2)
                    {
                        dtEmployeeInfo = objEmployeeInfoBal.GetEmployeeCommonInfoByContactNumber(txtSearchCode.Text);
                        dgvEmployeeInfo.DataSource = dtEmployeeInfo; 
                    }
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                ddlSearchBy.SelectedIndex = 0;
                LoadEmployeeInfo();
                txtSearchCode.Text = "";
                GetCommonInfo();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

      

    }
}
