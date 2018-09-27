using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StockbrokerProNewArch
{
    public partial class frmRemarks : Form
    {
        public frmRemarks()
        {
            InitializeComponent();
        }

        private string _employeeCode;
        public string EmployeeCode
        {
            get { return _employeeCode; }
            set { _employeeCode = value; }
        }

        private string _remarks;
        public string Remarks
        {
            get { return _remarks; }
            set { _remarks = value; }
        }

        private DialogResult _dialogResult;
        

        private void btnClose_Click(object sender, EventArgs e)
        {
            _remarks = "";
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if(txtRemarks.Text.Trim()==String.Empty)
                {
                    MessageBox.Show("Delete Remarks Required.","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                {
                    _remarks = txtRemarks.Text;
                    _dialogResult = DialogResult.Yes;
                    Close();
                }
               
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
        }

        private void frmRemarks_Load(object sender, EventArgs e)
        {
            txtEmployeeCode.Text = EmployeeCode;
        }
    }
}
