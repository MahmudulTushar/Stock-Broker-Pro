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
    public partial class frmUnapprovedHolidayInfo : Form
    {
        public frmUnapprovedHolidayInfo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private int _leaveId;
        public int LeaveId
        {
            get { return _leaveId; }
            set { _leaveId = value; }
        }

        private void frmUnapprovedHolidayInfo_Load(object sender, EventArgs e)
        {
            try
            {
                LeajveDetailsInfo();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void LeajveDetailsInfo()
        {
            try
            {

                EmployeeHolidayBal objEmployeeHoliday=new EmployeeHolidayBal();
                DataTable dtList=new DataTable();

                dtList = objEmployeeHoliday.GetLeaveDetailsInfo(_leaveId);

                if(dtList.Rows.Count>0)
                {
                    lblEmployeeCode.Text = "Employee Code: " + dtList.Rows[0]["EmployeeCode"].ToString();
                    lblCatagory.Text = "Leave Catagory: " + dtList.Rows[0]["HolidayType"].ToString();
                    txtLeaveFrom.Text = dtList.Rows[0]["FromDate"].ToString();
                    txtDuration.Text = dtList.Rows[0]["HoliDay"].ToString();
                    txtReamarks.Text = dtList.Rows[0]["Remarks"].ToString();
                    txtReason.Text = dtList.Rows[0]["Reason"].ToString();
                    txtReject.Text = dtList.Rows[0]["RejectRemarks"].ToString();
                    lblStatus.Text = "Status: " + dtList.Rows[0]["Status"].ToString();
                    lblEmployeeName.Text = "Name : " + dtList.Rows[0]["Name"].ToString();

                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
