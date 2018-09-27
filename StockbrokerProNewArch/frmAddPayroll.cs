using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using BusinessAccessLayer.BO;

namespace StockbrokerProNewArch
{
    public partial class frmAddPayroll : Form
    {
        public frmAddPayroll()
        {
            InitializeComponent();
        }

        private string _employeeCode;
        public string EmployeeCode
        {
            get { return _employeeCode; }
            set { _employeeCode = value; }
        }

        private DateTime _payrollDate;
        public DateTime PayrollDate
        {
            get { return _payrollDate; }
            set { _payrollDate = value; }
        }

        private DialogResult _confirmSalary;
        public DialogResult ConfirmSalary
        {
            get { return _confirmSalary; }
            set { _confirmSalary = value; }
        }

       

        private void frmAddPayroll_Load(object sender, EventArgs e)
        {
            try
            {
                if (EmployeeCode != "")
                    GetEmployeeInformation();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void GetEmployeeInformation()
        {
            try
            {
                EmployeeInformationBAL objEmployeeInfoBal = new EmployeeInformationBAL();
                DataTable dtEmployeeInformation = new DataTable();

                dtEmployeeInformation = objEmployeeInfoBal.GetEmployeeBasicInformation(EmployeeCode);

                if (dtEmployeeInformation.Rows.Count > 0)
                {

                    txtEmployeeCode.Text =EmployeeCode;
                    txtEmployeeName.Text = dtEmployeeInformation.Rows[0][0].ToString();
                    txtDepartMent.Text = dtEmployeeInformation.Rows[0][1].ToString();
                    txtDesignation.Text = dtEmployeeInformation.Rows[0][2].ToString();
                    txtBasicSalary.Text = dtEmployeeInformation.Rows[0][3].ToString();
                    txtProFund.Text = dtEmployeeInformation.Rows[0][4].ToString();
                    txtOthers.Text = dtEmployeeInformation.Rows[0][5].ToString();


                    if (dtEmployeeInformation.Rows[0][6] != DBNull.Value)
                    {
                        byte[] ImageData = (byte[])(dtEmployeeInformation.Rows[0][6]);

                        if (ImageData != null)
                        {
                            ShowEmployeeImage(ImageData);
                        }
                    }

                   

                    DataTable dtpurposeList=new DataTable();
                    dtpurposeList = objEmployeeInfoBal.GetPurposeInfo(EmployeeCode);
                    dgvPurposeInfo.DataSource = dtpurposeList;
                    dgvPurposeInfo.Columns[2].Visible = false;

                    txtPurposeAmount.Text = objEmployeeInfoBal.GetTotalPurposeAmount(EmployeeCode).ToString();

                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void ShowEmployeeImage(byte[] imagebyte)
        {
            try
            {
                MemoryStream ms = new MemoryStream(imagebyte);
                pcbEmployee.Image = Image.FromStream(ms);

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SaveToDatabase();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void SaveToDatabase()
        {
            try
            {
                EmployeeSalaryInfoBO objemployeeBo=new EmployeeSalaryInfoBO();
                objemployeeBo.EmployeeCode = txtEmployeeCode.Text;
                objemployeeBo.PayrollDate = PayrollDate;
                objemployeeBo.BasicSalary = float.Parse(txtBasicSalary.Text);
                objemployeeBo.ProFund = float.Parse(txtProFund.Text);
                objemployeeBo.OverTime = float.Parse(txtOverTime.Text);
                objemployeeBo.Others = float.Parse(txtOthers.Text);
                objemployeeBo.Bouns = float.Parse(txtBouns.Text);
                objemployeeBo.DeductionAmount = float.Parse(txtDeductionAmount.Text);
                objemployeeBo.DeductionnReason = txtDeductionReason.Text;

                for(int i=0;i<dgvPurposeInfo.Rows.Count;++i)
                {
                    objemployeeBo.PurposeAmount.Add(float.Parse(dgvPurposeInfo.Rows[i].Cells[1].Value.ToString()));
                    objemployeeBo.PurposeId.Add(Int32.Parse(dgvPurposeInfo.Rows[i].Cells[2].Value.ToString()));

                }

                EmployeeSalaryInfoBal objEmployeeInfoBal=new EmployeeSalaryInfoBal();
                objEmployeeInfoBal.InsertIntoSalaryInfo(objemployeeBo);

                MessageBox.Show("Data is Secessfully Saved.","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                _confirmSalary = DialogResult.Yes;
                Close();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void txtOverTime_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if(txtOverTime.Text!=String.Empty)
                {
                    txtGrandTotal.Text =Convert.ToString(float.Parse(txtBasicSalary.Text) -float.Parse(txtProFund.Text) +float.Parse(txtOthers.Text) + float.Parse(txtOverTime.Text)+float.Parse(txtBouns.Text)-float.Parse(txtDeductionAmount.Text)+float.Parse(txtPurposeAmount.Text));
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            _confirmSalary = DialogResult.Cancel;
            Close();
        }
    }
}
