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
    public partial class frmApprovedLeave : Form
    {
        public frmApprovedLeave()
        {
            InitializeComponent();
        }

        private string _employeeCode;
        public String EmployeeCode
        {
            get { return _employeeCode; }
            set { _employeeCode = value; }

        }

        private void frmApprovedLeave_Load(object sender, EventArgs e)
        {
            if (EmployeeCode != String.Empty)
                groupBox1.Text = "Leave List of " + EmployeeCode;

            try
            {
                GetHolidayList();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnCLose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GetHolidayList()
        {
            try
            {
                EmployeeHolidayBal objEmployeeHolidayBal=new EmployeeHolidayBal();
                DataTable dtList=new DataTable();

                dtList = objEmployeeHolidayBal.GetEmlpoyeeLeaveList(EmployeeCode);
                dgvLeaveList.DataSource = dtList;
                dgvLeaveList.Columns[0].Visible = false;
                label1.Text = "Record: " + dtList.Rows.Count.ToString();
            }
            catch (Exception)
            {
                
                throw;
            }
        }


    }
}
