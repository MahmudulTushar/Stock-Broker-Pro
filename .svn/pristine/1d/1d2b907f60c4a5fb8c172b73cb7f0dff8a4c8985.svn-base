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
    public partial class frmEmployeeApproved : Form
    {
        public frmEmployeeApproved()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmEmployeeHoldiday_Load(object sender, EventArgs e)
        {
            try
            {
                GetUnapprovedLeave();
                GetCommonInfo();
                SeletedEmployeeCode();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void GetUnapprovedLeave()
        {
            try
            {
                EmployeeHolidayBal objEWmployeeHolidayBal=new EmployeeHolidayBal();
                DataTable dtList=new DataTable();

                dtList = objEWmployeeHolidayBal.GetUnapprovedLeaveList();
                dgvEmployeeInfo.DataSource = dtList;
                dgvEmployeeInfo.Columns[0].Visible = false;
                label1.Text = "Total Record : " + dgvEmployeeInfo.Rows.Count.ToString();

                if(dgvEmployeeInfo.Rows.Count>0)
                {
                    btnConfirm.Enabled = true;
                    btnApprovedAll.Enabled = true;
                    btnReject.Enabled = true;
                }

                else
                {
                    btnConfirm.Enabled = false;
                    btnApprovedAll.Enabled = false;
                    btnReject.Enabled = false;
                }


            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private string _employeeCode;
        public String EmployeeCode
        {
            get { return _employeeCode; }
            set { _employeeCode = value; }
        }            

        private void SeletedEmployeeCode()
        {
            try
            {
                if(dgvEmployeeInfo.Rows.Count>0)
                {
                    string  EmployeeCode = dgvEmployeeInfo.SelectedRows[0].Cells[0].Value.ToString();
                    _employeeCode = EmployeeCode;
                    btnConfirm.Text = "Confirm To " + dgvEmployeeInfo.SelectedRows[0].Cells[1].Value.ToString();
                }

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
                EmployeeHolidayBal objEmployeeHoliday = new EmployeeHolidayBal();
                DataTable dtEmployeeInfo = new DataTable();

                dtEmployeeInfo = objEmployeeHoliday.GetEmployeeInformation();
                dgvEmployeeInfo.DataSource = dtEmployeeInfo;

                if(dgvEmployeeInfo.Rows.Count>0)
                {
                    btnConfirm.Enabled = true;
                }

                else
                {
                    btnConfirm.Enabled = false;
                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        private void GetCommonInfo()
        {
            try
            {
                EmployeeInformationBAL objEmployeeInfoBal = new EmployeeInformationBAL();
                objEmployeeInfoBal.GetCommonInfo();
                lblTotalDepartment.Text = "Total Department : " + objEmployeeInfoBal.TotalDepartment.ToString();
                lblTotalJobPosition.Text = "Total Designation : " + objEmployeeInfoBal.TotalJobPosition.ToString();
                lblTotalEmployee.Text = "Total Employee : " + objEmployeeInfoBal.TotalRecord.ToString();

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void dgvEmployeeInfo_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                SeletedEmployeeCode();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if(dgvEmployeeInfo.Rows.Count>0)
                {
                    if(MessageBox.Show("Do you approved this leave.","", MessageBoxButtons.YesNo,MessageBoxIcon.Information)==DialogResult.Yes)
                    {
                        int holidayId = Int32.Parse(dgvEmployeeInfo.SelectedRows[0].Cells[0].Value.ToString());
                        EmployeeHolidayBal objHolidayBal = new EmployeeHolidayBal();
                        objHolidayBal.UpdateToEmployeeLeave(holidayId);

                        MessageBox.Show("Secessfully Approved this Leave.","",MessageBoxButtons.OK,MessageBoxIcon.Information);

                        GetUnapprovedLeave();
                    }
                   
                }
               

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnApprovedAll_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvEmployeeInfo.Rows.Count > 0)
                {
                    if (MessageBox.Show("Do you approved All this leave.", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                       
                        EmployeeHolidayBal objHolidayBal = new EmployeeHolidayBal();
                        objHolidayBal.UpdateAllEmployeeLeave();

                        MessageBox.Show("Secessfully Approved All this Leave.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        GetUnapprovedLeave();
                    }

                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvEmployeeInfo.Rows.Count > 0)
                {
                    if (MessageBox.Show("Do you want to Reject this leave.", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        frmRejectReason objRejectReason=new frmRejectReason();
                        int holidayId = Int32.Parse(dgvEmployeeInfo.SelectedRows[0].Cells[0].Value.ToString());
                        objRejectReason.LeaveId = holidayId;
                        
                        objRejectReason.EmployeeCode = dgvEmployeeInfo.SelectedRows[0].Cells[1].Value.ToString();
                        objRejectReason.ShowDialog();
                        DialogResult dialog = objRejectReason.DialogResultt;

                        if(dialog==DialogResult.Yes)
                        {
                            MessageBox.Show("Secessfully Reject this Leave.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            GetUnapprovedLeave();
                        }
                       
                    }

                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            try
            {
                GetUnapprovedLeave();
                GetCommonInfo();
                SeletedEmployeeCode();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
