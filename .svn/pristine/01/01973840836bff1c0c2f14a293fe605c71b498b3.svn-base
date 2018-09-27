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
    public partial class frmRejectReason : Form
    {
        public frmRejectReason()
        {
            InitializeComponent();
        }

        private string _employeeCode;
        public String EmployeeCode
        {
            get { return _employeeCode; }
            set { _employeeCode = value; }
        }

        private int _leaveId;
        public int LeaveId
        {
            get { return _leaveId; }
            set { _leaveId = value; }
        }

        private DialogResult _dialogResult;
        public DialogResult DialogResultt
        {
            get { return _dialogResult; }
            set { _dialogResult = value; }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            _dialogResult = DialogResult.No;
            this.Close();
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtReason.Text.Trim()!=String.Empty)
                {
                    EmployeeHolidayBal objHolidayBal = new EmployeeHolidayBal();
                    objHolidayBal.RejectToemployeeLeave(_leaveId,txtReason.Text);
                    _dialogResult = DialogResult.Yes;
                    this.Close();
                }

                else
                {
                    MessageBox.Show("Reject Reason Required.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtReason.Focus();
                }
               
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void frmRejectReason_Load(object sender, EventArgs e)
        {
            if (EmployeeCode != String.Empty)
                lblEmployeeCode.Text = EmployeeCode;
        }
    }
}
