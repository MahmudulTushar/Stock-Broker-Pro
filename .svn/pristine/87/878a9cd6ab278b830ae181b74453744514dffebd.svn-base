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
    public partial class frmPurpose : Form
    {
        public frmPurpose()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SaveSalaryPurpose();
        }

        private void SaveSalaryPurpose()
        {
            try
            {
                if(txtPurposeName.Text.Trim()==String.Empty)
                {
                    MessageBox.Show("Purpose Name Required.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPurposeName.Focus();
                }

                else
                {
                    EmployeeSalaryInfoBal objEmployee=new EmployeeSalaryInfoBal();
                    objEmployee.InsertSalaryPurpose(txtPurposeName.Text);
                    Close();
                    
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void frmPurpose_Load(object sender, EventArgs e)
        {
            try
            {
                EmployeeSalaryInfoBal objSalary = new EmployeeSalaryInfoBal();
                label3.Text = "Existing Total Facilities : " + objSalary.GetExistingTotalSalayFacilies();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
