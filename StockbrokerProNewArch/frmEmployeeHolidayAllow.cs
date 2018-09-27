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
    public partial class frmEmployeeHolidayAllow : Form
    {
        public frmEmployeeHolidayAllow()
        {
            InitializeComponent();
        }

        private string _employeeCode;

        private int _restHolidy;
        public int RestHoliday
        {
            get { return _restHolidy; }
            set { _restHolidy = value; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmEmployeeHolidayAllow_Load(object sender, EventArgs e)
        {
            try
            {
                groupBox2.Text = "Information of " + EmployeeCode;
                lblEmployeeCode.Text = "Code: " + EmployeeCode;
                EmployeeHolidayBal objEmployeeHoliday=new EmployeeHolidayBal();
                lblEmployeeName.Text = "Name: " + objEmployeeHoliday.GetEmployeeName(EmployeeCode);
                ddlHolidayType.SelectedIndex = 0;

                GetHolidayInfo();
                GetHolidayList();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void GetHolidayList()
        {
            try
            {
                EmployeeHolidayBal objHolidayBal=new EmployeeHolidayBal();
                DataTable dtList=new DataTable();
                dtList = objHolidayBal.GetEmployeeHoliday(_employeeCode);
                dgvEmployeeHoliday.DataSource = dtList;
                dgvEmployeeHoliday.Columns[0].Visible = false;

                if(dgvEmployeeHoliday.Rows.Count>0)
                {
                    btnDelete.Enabled = true;
                    btndetails.Enabled = true;
                }

                else
                {
                    btnDelete.Enabled = false;
                    btndetails.Enabled = false;
                }

            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void GetHolidayInfo()
        {
            try
            {

             EmployeeHolidayBal objEmnployeeHolidayBal=new EmployeeHolidayBal();

                if(ddlHolidayType.SelectedIndex==1)
                {
                    objEmnployeeHolidayBal.GetEmployeeSickHolidayInfo(EmployeeCode,dtpStartDate.Value);
                    groupBox1.Text = "Sick Leave Information";
                }
             

                else if(ddlHolidayType.SelectedIndex==0)
                {
                    objEmnployeeHolidayBal.GetEmployeeHolidayInfo(EmployeeCode,dtpStartDate.Value);
                    groupBox1.Text = "Annual Leave Information";
                   
                }

                else if(ddlHolidayType.SelectedIndex==2)
                {
                    objEmnployeeHolidayBal.GetMaternityPolicy(EmployeeCode,dtpStartDate.Value);
                    groupBox1.Text = "Maternity Policy Information";
                }

                else if(ddlHolidayType.SelectedIndex==3)
                {
                    objEmnployeeHolidayBal.GetPaternityPolicy(EmployeeCode,dtpStartDate.Value);
                    groupBox1.Text = "Paternity Policy Information";
                }


                txtTotalHoilDay.Text = objEmnployeeHolidayBal.TotalHoliday.ToString();
                txtTakenHoliday.Text = objEmnployeeHolidayBal.TakenHoliday.ToString();
                txtRestHoliday.Text = objEmnployeeHolidayBal.RestHoliday.ToString();
                _restHolidy = objEmnployeeHolidayBal.RestHoliday;
                nudLeave.Maximum = objEmnployeeHolidayBal.RestHoliday;



            }
            catch (Exception)
            {
                
                throw;
            }
        }

       

        private void txtDay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "\\d+"))
                e.Handled = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                SaveToholiday();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void SaveToholiday()
        {
            try
            {
                if (nudLeave.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("Number of Holiday Required.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    nudLeave.Focus();
                }
                
                else if(txtReason.Text==String.Empty)
                {
                    MessageBox.Show("Leave Reaason Required.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtReason.Focus();
                }


                else if (Int32.Parse(nudLeave.Text) <= 0)
                {
                    MessageBox.Show("Holiday must be grater than 0.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    nudLeave.Focus();
                }

              

                else
                {

                    if (Int32.Parse(nudLeave.Text) > _restHolidy)
                     MessageBox.Show("This Holiday is not Allowed.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Taken_HolidayBO objHolidayBO = new Taken_HolidayBO();
                    objHolidayBO.EmployeeCode = _employeeCode;
                    objHolidayBO.StartDate = dtpStartDate.Value;
                    objHolidayBO.Holiday = Int32.Parse(nudLeave.Value.ToString());
                    objHolidayBO.HolidayType = ddlHolidayType.Text;
                    objHolidayBO.Remarks = txtRemarks.Text;
                    objHolidayBO.Reason = txtReason.Text;

                    EmployeeHolidayBal objEmployeeBal = new EmployeeHolidayBal();
                    objEmployeeBal.InsertHoliday(objHolidayBO);

                    MessageBox.Show("Secessfully Saved this Holiday.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    GetHolidayList();
                    GetHolidayInfo();

                    nudLeave.Text = "";
                    txtRemarks.Text = "";
                    txtReason.Text = "";


                }

            }
            catch (Exception)
            {
                
                throw;
            }
          
        }

        private void ddlHolidayType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GetHolidayInfo();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteToEmployeeHoliday();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteToEmployeeHoliday()
        {
            try
            {
                if(dgvEmployeeHoliday.Rows.Count>0)
                {
                    int HolidayId = Int32.Parse(dgvEmployeeHoliday.SelectedRows[0].Cells[0].Value.ToString());

                    if(MessageBox.Show("Do you want to Delete this Information.","",MessageBoxButtons.YesNo,MessageBoxIcon.Information)==System.Windows.Forms.DialogResult.Yes)
                    {
                        EmployeeHolidayBal objemployeeHolidalBal
                            =new EmployeeHolidayBal();

                        if(objemployeeHolidalBal.IsDeletable(HolidayId))
                        {
                            objemployeeHolidalBal.DeleteToHoliday(HolidayId);

                            MessageBox.Show("Secessfully Delete this Information.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            GetHolidayInfo();
                            GetHolidayList();
                        }

                        else
                        {
                            MessageBox.Show("This leave can not delete.","",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        }
                      

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
            nudLeave.Minimum = 1;             
            txtReason.Text = "";
            txtRemarks.Text = "";

        }

        private void btnApprovedLeave_Click(object sender, EventArgs e)
        {
            frmApprovedLeave objApproved=new frmApprovedLeave();
            objApproved.EmployeeCode = EmployeeCode;
            objApproved.Show();
        }

        private void dgvEmployeeHoliday_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                frmUnapprovedHolidayInfo objUnapprovedInfo=new frmUnapprovedHolidayInfo();
                objUnapprovedInfo.Text = "Leave Details Information of " + _employeeCode;
                
                if(dgvEmployeeHoliday.Rows.Count>0)
                {
                    int leaveId = Int32.Parse(dgvEmployeeHoliday.SelectedRows[0].Cells[0].Value.ToString());
                    objUnapprovedInfo.LeaveId = leaveId;
                    objUnapprovedInfo.Show();

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btndetails_Click(object sender, EventArgs e)
        {
            try
            {
                frmUnapprovedHolidayInfo objUnapprovedInfo = new frmUnapprovedHolidayInfo();
                objUnapprovedInfo.Text = "Leave Details Information of " + _employeeCode;

                if (dgvEmployeeHoliday.Rows.Count > 0)
                {
                    int leaveId = Int32.Parse(dgvEmployeeHoliday.SelectedRows[0].Cells[0].Value.ToString());
                    objUnapprovedInfo.LeaveId = leaveId;
                    objUnapprovedInfo.Show();

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                GetHolidayInfo();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
