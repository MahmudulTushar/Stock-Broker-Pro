using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;
using BusinessAccessLayer.BAL;
using BusinessAccessLayer.BO;
using System.Net;


namespace StockbrokerProNewArch
{
    public partial class frmAddNewEmployee : Form
    {
        List<int> list = new List<int>();
        private string _employeeCode="";
        public String EmployeeCode
        {
            get { return _employeeCode; }
            set { _employeeCode = value; }
        }

        private string _SemployeeCode = "";
        public  String SemployeeCode
        {
            get { return _SemployeeCode; }
            set { _SemployeeCode = value; }
        }

        private float _houseRent;
        public float HouseRent
        {
            get { return _houseRent; }
            set { _houseRent = value; }
        }

        private float _medical;
        public float Medical
        {
            get { return _medical; }
            set { _medical = value; }
        }

        private float _bouns;
        public float Bouns
        {
            get { return _bouns; }
            set { _bouns = value; }
        }

        private float _insurance;
        public float Insurasnce
        {
            get { return _insurance; }
            set { _insurance = value; }
        }

        private float _profidentFunt;
        public float ProfidentFund
        {
            get { return _profidentFunt; }
            set { _profidentFunt = value; }
        }

        private DataTable _dtEmoployeePurposeList;
        public DataTable dtEmployeePurposeList
        {
            get { return _dtEmoployeePurposeList; }
            set { _dtEmoployeePurposeList = value; }
        }
       
        public frmAddNewEmployee()
        {
            InitializeComponent();
            nudAnnualLeave.TextChanged += new EventHandler(annualTextChange);
            nudSickLeave.TextChanged += new EventHandler(annualTextChange);
            nudMaternityPolicy.TextChanged += new EventHandler(annualTextChange);
            nudPaternityPolicy.TextChanged += new EventHandler(annualTextChange);
        }

        private void annualTextChange(object sender, EventArgs e)
        {
            try
            {
                txtTotalHoliday.Text =
                   Convert.ToString(Int32.Parse(nudAnnualLeave.Value.ToString()) +
                                    Int32.Parse(nudSickLeave.Value.ToString()) +
                                    Int32.Parse(nudMaternityPolicy.Value.ToString()) +
                                    Int32.Parse(nudPaternityPolicy.Value.ToString()));

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshPersonalInput();
        }

        private void RefreshPersonalInput()
        {
            txtNationality.Text = "";
            txtNationalID.Text = "";
            txtMobileNumber.Text = "";
            txtHousePhone.Text = "";
            txtEmployeeName.Text = "";
            txtEmployeeCode.Text = "";
            txtEmailAddress.Text = "";
            txtAddress.Text = "";
            txtFatherName.Text = "";
            txtMotherName.Text = "";
            txtPassportNumber.Text = "";
            txtAlternativeMob.Text = "";
            txtReferenceName.Text = "";
            txtReferenceAddress.Text = "";
            txtReferenceEmail.Text = "";
            txtReferencePhone.Text = "";
            txtReferenceProfession.Text = "";
            txtReportTo.Text = "";
            txtRemarks.Text = "";
            txtRealtionShip.Text = "";
            txtRecuritedBy.Text = "";
            txtSpecialInstruction.Text = "";
            txtTinNumber.Text = "";
            txtTotalPurposeAmount.Text = "0.00";
            txtTotalHoliday.Text = "0";
            txtPurposeAmount.Text = "";
            txtPictureLocation.Text = "";
            txtPersonName.Text = "";
            txtPassportNumber.Text = "";
            txtOthers.Text = "0.00";
            txtNationality.Text = "";
            txtFatherName.Text = "";
            txtMotherName.Text = "";
            txtMedicalCondition.Text = "";
            txtMedicalInsuranceDetails.Text = "";
            txtJobResponsiblity.Text = "";
            txtHousePhone.Text = "";
            txtBankName.Text = "";
            txtBasicSalary.Text = "0.00";
            txtBranchName.Text = "";
            txtAccountNo.Text = "";
            nudSickLeave.Text = "0";
            nudPaternityPolicy.Text = "0";
            nudMaternityPolicy.Text = "0";
            nudAnnualLeave.Text = "0";
            dgvSalaryInfo.DataSource = null;
            dgvSalaryInfo.Rows.Clear();
            txtContactAddress.Text = "";
            pcbEmployeeImage.Image = null;
            txtProAmount.Text = "0.00";
            txtProfindRate.Text = "0.00";
            txtContactNumber.Text = "";
            txtEmployeeCode.Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if(EmployeeCode!=String.Empty)
                {
                    if(CheeckToBlankPersonalInfo())
                    {
                        if (ValidationToEmailAddress() == false)
                        {
                            MessageBox.Show("Correct Email Adrrss Required.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtEmailAddress.Focus();
                        }

                        else
                        {
                            UpdateEmployeePersonalinfo(EmployeeCode);
                        }
                        
                    }
                    
                }

                else
                {
                    if (CheeckToBlankPersonalInfo())
                    {
                        if (ValidationToEmailAddress() == false)
                        {
                            MessageBox.Show("Correct Email Adrrss Required.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtEmailAddress.Focus();
                        }

                        else
                        {
                            SaveEmployeePersonalInfoToDatabase();
                        }
                    }
                    
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            
        }

        private void SaveEmployeePersonalInfoToDatabase()
        {
            EmployeeInformationBAL objEmployeePersonalInfoBal = new EmployeeInformationBAL();

            try
            {
                
                if(ValidationToInput())
                {

                    if(objEmployeePersonalInfoBal.IsExistEmployeeCode(txtEmployeeCode.Text)==false )
                    {
                        EmployeePersonalInfoBO objEmployeePersonalInfo = new EmployeePersonalInfoBO();
                        objEmployeePersonalInfo.EmployeeCode = txtEmployeeCode.Text;
                        objEmployeePersonalInfo.EmployeeName = txtEmployeeName.Text;
                        objEmployeePersonalInfo.Address = txtAddress.Text;
                        objEmployeePersonalInfo.Gender = ddlGener.Text;
                        objEmployeePersonalInfo.DOB = dtpBOD.Value;
                        objEmployeePersonalInfo.FillingStatus = ddlFillingStatus.Text;
                        objEmployeePersonalInfo.Nationality = txtNationality.Text;
                        objEmployeePersonalInfo.NationalID = txtNationalID.Text;
                        objEmployeePersonalInfo.ContactNumber = txtMobileNumber.Text;
                        objEmployeePersonalInfo.AlternativePhoneNumber = txtAlternativeMob.Text;
                        objEmployeePersonalInfo.HomePhone = txtHousePhone.Text;
                        objEmployeePersonalInfo.NationalID = txtNationalID.Text;
                        objEmployeePersonalInfo.EmailAddress = txtEmailAddress.Text;
                        objEmployeePersonalInfo.FatherName = txtFatherName.Text;
                        objEmployeePersonalInfo.MotherName = txtMotherName.Text;
                        objEmployeePersonalInfo.PassportNo = txtPassportNumber.Text;
                        objEmployeePersonalInfo.ReferenceName = txtReferenceName.Text;
                        objEmployeePersonalInfo.ReferenceProfession = txtReferenceProfession.Text;
                        objEmployeePersonalInfo.ReferencePhoneNumber = txtReferencePhone.Text;
                        objEmployeePersonalInfo.ReferenceEmailAddress = txtReferenceEmail.Text;
                        objEmployeePersonalInfo.ReferenceAddress = txtReferenceAddress.Text;
                        objEmployeePersonalInfo.EmployeeTitle = ddlEmployeeTitle.Text;

                        EmployeePaymentBO objEmployeePaymentBO = new EmployeePaymentBO();
                        objEmployeePaymentBO.EmployeeCode = txtEmployeeCode.Text;
                        objEmployeePaymentBO.JoinDate = dtpJoinDate.Value;
                        objEmployeePaymentBO.Department = ddlDepartment.Text;
                        objEmployeePaymentBO.JoinPosition = ddlJobPosition.Text;
                        objEmployeePaymentBO.JobResponsibility = txtJobResponsiblity.Text;
                        objEmployeePaymentBO.PaymentBy = ddlPaymentBy.Text;
                        objEmployeePaymentBO.BankName = txtBankName.Text;
                        objEmployeePaymentBO.BankBranchName = txtBranchName.Text;
                        objEmployeePaymentBO.AccountNo = txtAccountNo.Text;

                        objEmployeePaymentBO.BasicSalary = float.Parse(txtBasicSalary.Text);
                        objEmployeePaymentBO.Others = float.Parse(txtOthers.Text);

                        objEmployeePaymentBO.BanchName = ddlBranchName.Text;
                        objEmployeePaymentBO.ReportTo = txtReportTo.Text;
                        objEmployeePaymentBO.RecuritBy = txtRecuritedBy.Text;
                        objEmployeePaymentBO.TinNumber = txtTinNumber.Text;
                        objEmployeePaymentBO.ProFund = float.Parse(txtProAmount.Text);


                        EmployeeDoucmentBO objEmployeeDoucment = new EmployeeDoucmentBO();

                        if (txtPictureLocation.Text != String.Empty)
                        {
                            byte[] image = GetImageBytes(ofdImage.FileName);
                            objEmployeeDoucment.EmployeeCode = txtEmployeeCode.Text;
                            objEmployeeDoucment.Image = image;
                        }

                        else
                        {
                            objEmployeeDoucment.EmployeeCode = "";
                        }


                        ///////********** Employee Holiday BO ***********///////
                        Employee_HolidayBO objEmployeeHolidayBO=new Employee_HolidayBO();
                        objEmployeeHolidayBO.EmployeeCode = txtEmployeeCode.Text;
                        objEmployeeHolidayBO.YearlyHoliday = Int32.Parse(nudAnnualLeave.Value.ToString());
                        objEmployeeHolidayBO.SickLeave = Int32.Parse(nudSickLeave.Value.ToString());
                        objEmployeeHolidayBO.MaternityPolicy = Int32.Parse(nudMaternityPolicy.Value.ToString());
                        objEmployeeHolidayBO.PaternityPolicy = Int32.Parse(nudPaternityPolicy.Value.ToString());
                        objEmployeeHolidayBO.Remarks = txtRemarks.Text;

                        //////////// ****** Employee Emgergency **************///
                        Employee_EmergencyBO objEmployeeEmgergencyBO=new Employee_EmergencyBO();
                        objEmployeeEmgergencyBO.EmployeeCode = txtEmployeeCode.Text;
                        objEmployeeEmgergencyBO.MedicalDisability = txtMedicalCondition.Text;
                        objEmployeeEmgergencyBO.ContactPersonName = txtPersonName.Text;
                        objEmployeeEmgergencyBO.RelationShip = txtRealtionShip.Text;
                        objEmployeeEmgergencyBO.ContactNumber = txtContactNumber.Text;
                        objEmployeeEmgergencyBO.Adddress = txtAddress.Text;
                        objEmployeeEmgergencyBO.MedicalInsurance = txtMedicalInsuranceDetails.Text;
                        objEmployeeEmgergencyBO.SpecialInstruction = txtSpecialInstruction.Text;
                        objEmployeeEmgergencyBO.BloodGroup = ddlBloodGroup.Text;

                        ///////////********* EmployeePurposeAmount ************////
                        SalaryPurposeBO objSalaryPurposeBO=new SalaryPurposeBO();
                        objSalaryPurposeBO.EmployeeCode = txtEmployeeCode.Text;

                        for (int i = 0; i <dgvSalaryInfo.Rows.Count; i++)
                        {
                            objSalaryPurposeBO.PurposeAmount.Add(float.Parse(dgvSalaryInfo.Rows[i].Cells[1].Value.ToString()));
                            objSalaryPurposeBO.PurposeId.Add(Int32.Parse(dgvSalaryInfo.Rows[i].Cells[2].Value.ToString()));
                        }



                        objEmployeePersonalInfoBal.InsertEmployeelInformation(objEmployeePersonalInfo, objEmployeePaymentBO, objEmployeeDoucment, objEmployeeHolidayBO, objEmployeeEmgergencyBO,objSalaryPurposeBO);
                        MessageBox.Show("Data Secessfully Saved.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        /////// Refresh All Input 
                        RefreshPersonalInput();
                        RefreshBasicInput();  
                    }

                    else
                    {
                        MessageBox.Show("Already Exist this Employee Code.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtEmployeeCode.Focus();
                    }
                   

                 
                    
                }

               
               

            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void UpdateEmployeePersonalinfo(string EmployeeCode)
        {
            try
            {

                if (ValidationToInput())
                {

                    EmployeePersonalInfoBO objEmployeePersonalInfo = new EmployeePersonalInfoBO();

                    objEmployeePersonalInfo.EmployeeName = txtEmployeeName.Text;
                    objEmployeePersonalInfo.Address = txtAddress.Text;
                    objEmployeePersonalInfo.Gender = ddlGener.Text;
                    objEmployeePersonalInfo.DOB = dtpBOD.Value;
                    objEmployeePersonalInfo.FillingStatus = ddlFillingStatus.Text;
                    objEmployeePersonalInfo.Nationality = txtNationality.Text;
                    objEmployeePersonalInfo.NationalID = txtNationalID.Text;
                    objEmployeePersonalInfo.ContactNumber = txtMobileNumber.Text;
                    objEmployeePersonalInfo.HomePhone = txtHousePhone.Text;
                    objEmployeePersonalInfo.NationalID = txtNationalID.Text;
                    objEmployeePersonalInfo.EmailAddress = txtEmailAddress.Text;
                    objEmployeePersonalInfo.FatherName = txtFatherName.Text;
                    objEmployeePersonalInfo.MotherName = txtMotherName.Text;
                    objEmployeePersonalInfo.PassportNo = txtPassportNumber.Text;
                    objEmployeePersonalInfo.EmployeeTitle = ddlEmployeeTitle.Text;
                    objEmployeePersonalInfo.ReferenceName = txtReferenceName.Text;
                    objEmployeePersonalInfo.ReferenceProfession = txtReferenceProfession.Text;
                    objEmployeePersonalInfo.ReferencePhoneNumber = txtReferencePhone.Text;
                    objEmployeePersonalInfo.ReferenceEmailAddress = txtReferenceEmail.Text;
                    objEmployeePersonalInfo.ReferenceAddress = txtReferenceAddress.Text;
                    objEmployeePersonalInfo.EmployeeTitle = ddlEmployeeTitle.Text;
                    


                    EmployeePaymentBO objEmployeePaymentBO = new EmployeePaymentBO();
                    objEmployeePaymentBO.JoinDate = dtpJoinDate.Value;
                    objEmployeePaymentBO.Department = ddlDepartment.Text;
                    objEmployeePaymentBO.JoinPosition = ddlJobPosition.Text;
                    objEmployeePaymentBO.JobResponsibility = txtJobResponsiblity.Text;
                    objEmployeePaymentBO.PaymentBy = ddlPaymentBy.Text;
                    objEmployeePaymentBO.BankName = txtBankName.Text;
                    objEmployeePaymentBO.BankBranchName = txtBranchName.Text;
                    objEmployeePaymentBO.AccountNo = txtAccountNo.Text;
                    objEmployeePaymentBO.BasicSalary = float.Parse(txtBasicSalary.Text);
                    objEmployeePaymentBO.Others = float.Parse(txtOthers.Text);
                    objEmployeePaymentBO.ProFund = float.Parse(txtProAmount.Text);

                    EmployeeDoucmentBO objEmployeeDoucment = new EmployeeDoucmentBO();

                    if(txtPictureLocation.Text!=String.Empty)
                    {
                        byte[] image = GetImageBytes(ofdImage.FileName);
                        objEmployeeDoucment.Image = image;

                    }

                    else
                    {
                        objEmployeeDoucment.Image = null;
                    }


                    objEmployeePaymentBO.BanchName = ddlBranchName.Text;
                    objEmployeePaymentBO.ReportTo = txtReportTo.Text;
                    objEmployeePaymentBO.RecuritBy = txtRecuritedBy.Text;
                    objEmployeePaymentBO.TinNumber = txtTinNumber.Text;

                    ///////********** Employee Holiday BO ***********///////
                    Employee_HolidayBO objEmployeeHolidayBO = new Employee_HolidayBO();
                    objEmployeeHolidayBO.EmployeeCode = txtEmployeeCode.Text;
                    objEmployeeHolidayBO.YearlyHoliday = Int32.Parse(nudAnnualLeave.Value.ToString());
                    objEmployeeHolidayBO.YearlyHolidayTaken = 0;
                    objEmployeeHolidayBO.SickLeave = Int32.Parse(nudSickLeave.Value.ToString());
                    objEmployeeHolidayBO.SickLeaveTaken = 0;
                    objEmployeeHolidayBO.MaternityPolicy = Int32.Parse(nudMaternityPolicy.Value.ToString());
                    objEmployeeHolidayBO.PaternityPolicy = Int32.Parse(nudPaternityPolicy.Value.ToString());
                    objEmployeeHolidayBO.Remarks = txtRemarks.Text;

                    //////////// ****** Employee Emgergency **************///
                    Employee_EmergencyBO objEmployeeEmgergencyBO = new Employee_EmergencyBO();
                    objEmployeeEmgergencyBO.EmployeeCode = txtEmployeeCode.Text;
                    objEmployeeEmgergencyBO.MedicalDisability = txtMedicalCondition.Text;
                    objEmployeeEmgergencyBO.ContactPersonName = txtPersonName.Text;
                    objEmployeeEmgergencyBO.RelationShip = txtRealtionShip.Text;
                    objEmployeeEmgergencyBO.ContactNumber = txtContactNumber.Text;
                    objEmployeeEmgergencyBO.Adddress = txtAddress.Text;
                    objEmployeeEmgergencyBO.MedicalInsurance = txtMedicalInsuranceDetails.Text;
                    objEmployeeEmgergencyBO.SpecialInstruction = txtSpecialInstruction.Text;
                    objEmployeeEmgergencyBO.BloodGroup = ddlBloodGroup.Text;

                    ///////////********* EmployeePurposeAmount ************////
                    SalaryPurposeBO objSalaryPurposeBO = new SalaryPurposeBO();
                    objSalaryPurposeBO.EmployeeCode = txtEmployeeCode.Text;

                    for (int i = 0; i < dgvSalaryInfo.Rows.Count; i++)
                    {
                        objSalaryPurposeBO.PurposeAmount.Add(float.Parse(dgvSalaryInfo.Rows[i].Cells[1].Value.ToString()));
                        objSalaryPurposeBO.EmployeePurposeId.Add(Int32.Parse(dgvSalaryInfo.Rows[i].Cells[2].Value.ToString()));
                        objSalaryPurposeBO.PurposeId.Add(Int32.Parse(dgvSalaryInfo.Rows[i].Cells[3].Value.ToString()));
                    }




                   
                    EmployeeInformationBAL objEmployeePersonalInfoBal = new EmployeeInformationBAL();
                    objEmployeePersonalInfoBal.UpdateEmployeeInformation(EmployeeCode, objEmployeePersonalInfo, objEmployeePaymentBO, objEmployeeDoucment,objEmployeeEmgergencyBO,objEmployeeHolidayBO,objSalaryPurposeBO);
                    MessageBox.Show("Data Secessfully Updated.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private bool ValidationToEmailAddress()
        {
            if(txtEmailAddress.Text!=String.Empty)
            {
                
                string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                      @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                      @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
                Regex re = new Regex(strRegex);
                if (re.IsMatch(txtEmailAddress.Text))
                    return (true);
                else
                    return (false);
            }

            else if(txtReferenceEmail.Text.Trim()!=String.Empty)
            {
                string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                     @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                     @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
                Regex re = new Regex(strRegex);
                if (re.IsMatch(txtReferenceEmail.Text))
                    return (true);
                else
                    return (false);
            }

            else
            {
                return (true);
            }
          
        }

        private bool CheeckToBlankPersonalInfo()
        {
            bool status = false;

            if(txtEmployeeCode.Text==String.Empty)
            {
                status = false;
                MessageBox.Show("Employee Code Required ?","",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                txtEmployeeCode.Focus();
            }

            else if (txtEmployeeName.Text == String.Empty)
            {
                status = false;
                MessageBox.Show("Employee Name Required ?", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmployeeName.Focus();
            }

            else if (txtAddress.Text == String.Empty)
            {
                status = false;
                MessageBox.Show("Employee Address Required ?", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddress.Focus();
            }

            else if (txtEmployeeName.Text == String.Empty)
            {
                status = false;
                MessageBox.Show("Employee Name Required ?", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmployeeName.Focus();
            }

            else if (txtNationality.Text == String.Empty)
            {
                status = false;
                MessageBox.Show("Employee Nationality Required ?", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNationality.Focus();
            }

            else if (txtNationalID.Text == String.Empty)
            {
                status = false;
                MessageBox.Show("Employee Nationa ID Required ?", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNationalID.Focus();
            }

            else if (txtMobileNumber.Text == String.Empty)
            {
                status = false;
                MessageBox.Show("Employee Mobile Number Required ?", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMobileNumber.Focus();
            }

            else
            {
                status = true;
            }
            return status;
        }

        private void frmAddNewEmployee_Load(object sender, EventArgs e)
        {
            
            try
            {
                GetBranchList();
                
                if(EmployeeCode!=String.Empty)
                {
                    GetEmployeeInformation();
                    GetList();
                }

                else
                {
                    ShowdtgColumnHeader();

                    ddlEmployeeTitle.SelectedIndex = 0;
                    txtEmployeeCode.Focus();
                    ddlGener.SelectedIndex = 0;
                    ddlBloodGroup.SelectedIndex = 0;
                    ddlFillingStatus.SelectedIndex = 0;
                    ddlPaymentBy.SelectedIndex = 0;
                    GetDepartmerntList();
                    GetJobpositionList();
                }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void GetBranchList()
        {
            try
            {
                CommonInfoBal objCommonInfo=new CommonInfoBal();
                DataTable dtList=new DataTable();

                dtList = objCommonInfo.GetBranchList();
                ddlBranchName.DataSource = dtList;
                ddlBranchName.DisplayMember = "Branch_Name";

            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void ViewEmployeeInformation(string employeeCode)
        {
            try
            {
                if(employeeCode!=String.Empty)
                {
                    GetEmployeeInformation();
                    btnAdd.Visible = false;
                    btnRefresh.Enabled = false;
                    

                }

            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void GetEmployeeInformation()
        {
            try
            {
                EmployeeInformationBAL objEmployeeInfoBal=new EmployeeInformationBAL();
                DataTable dtEmployeeInformation=new DataTable();

                dtEmployeeInformation = objEmployeeInfoBal.GetEmployeeInformation(EmployeeCode);

                if(dtEmployeeInformation.Rows.Count>0)
                {
                    txtEmployeeCode.Text = dtEmployeeInformation.Rows[0][0].ToString();
                    txtEmployeeCode.ReadOnly = true;
                    txtEmployeeCode.BackColor = SystemColors.InactiveCaptionText;
                    txtEmployeeCode.BorderStyle = BorderStyle.FixedSingle;

                    txtEmployeeName.Text = dtEmployeeInformation.Rows[0][1].ToString();
                    txtFatherName.Text = dtEmployeeInformation.Rows[0][2].ToString();
                    txtMotherName.Text = dtEmployeeInformation.Rows[0][3].ToString();
                    txtAddress.Text = dtEmployeeInformation.Rows[0][4].ToString();

                    ddlGener.Text = dtEmployeeInformation.Rows[0][5].ToString();

                    dtpBOD.Value = Convert.ToDateTime(dtEmployeeInformation.Rows[0][6].ToString());

                    ddlBloodGroup.Text = dtEmployeeInformation.Rows[0][7].ToString();
                    ddlFillingStatus.Text = dtEmployeeInformation.Rows[0][8].ToString();
                    txtNationality.Text = dtEmployeeInformation.Rows[0][9].ToString();
                    txtNationalID.Text = dtEmployeeInformation.Rows[0][10].ToString();
                    txtMobileNumber.Text = dtEmployeeInformation.Rows[0][11].ToString();
                    txtHousePhone.Text = dtEmployeeInformation.Rows[0][12].ToString();
                    txtEmailAddress.Text = dtEmployeeInformation.Rows[0][13].ToString();
                    txtPassportNumber.Text = dtEmployeeInformation.Rows[0][14].ToString();

                  

                    dtpJoinDate.Value = Convert.ToDateTime(dtEmployeeInformation.Rows[0][15].ToString());
                    ddlDepartment.Text = dtEmployeeInformation.Rows[0][16].ToString();
                    ddlJobPosition.Text = dtEmployeeInformation.Rows[0][17].ToString();
                    txtJobResponsiblity.Text = dtEmployeeInformation.Rows[0][18].ToString();
                    ddlPaymentBy.Text = dtEmployeeInformation.Rows[0][19].ToString();

                    if (ddlPaymentBy.SelectedIndex == 1)
                    {
                        txtBankName.Text = dtEmployeeInformation.Rows[0][20].ToString();
                        txtBranchName.Text = dtEmployeeInformation.Rows[0][21].ToString();
                        txtAccountNo.Text = dtEmployeeInformation.Rows[0][22].ToString();

                    }

                    txtBasicSalary.Text = dtEmployeeInformation.Rows[0]["BasicSalary"].ToString();
                    txtOthers.Text = dtEmployeeInformation.Rows[0]["Others"].ToString();
                    txtProAmount.Text = dtEmployeeInformation.Rows[0]["ProvidentFund"].ToString();


                    if (dtEmployeeInformation.Rows[0]["Image"] != DBNull.Value)
                    {
                        byte[] ImageData = (byte[])(dtEmployeeInformation.Rows[0]["Image"]);

                        if (ImageData != null)
                        {
                            ShowEmployeeImage(ImageData);
                        }
                    }

                    ddlBranchName.Text = dtEmployeeInformation.Rows[0]["BranchName"].ToString();
                    txtReportTo.Text = dtEmployeeInformation.Rows[0]["ReportTo"].ToString();


                    txtAlternativeMob.Text = dtEmployeeInformation.Rows[0]["AlternativeNumber"].ToString();
                    txtReferenceName.Text = dtEmployeeInformation.Rows[0]["Reference_Name"].ToString();
                    txtReferenceProfession.Text = dtEmployeeInformation.Rows[0]["Reference_Profession"].ToString();
                    txtReferencePhone.Text = dtEmployeeInformation.Rows[0]["Reference_Phone"].ToString();
                    txtReferenceEmail.Text = dtEmployeeInformation.Rows[0]["Reference_Email"].ToString();
                    txtReferenceAddress.Text = dtEmployeeInformation.Rows[0]["Reference_Address"].ToString();
                    txtRecuritedBy.Text = dtEmployeeInformation.Rows[0]["RecuritedBy"].ToString();
                    txtTinNumber.Text = dtEmployeeInformation.Rows[0]["TinNumber"].ToString();
                    txtMedicalCondition.Text = dtEmployeeInformation.Rows[0]["Employee_Disability"].ToString();
                    txtPersonName.Text = dtEmployeeInformation.Rows[0]["Contact_Person_Name"].ToString();
                    txtRealtionShip.Text = dtEmployeeInformation.Rows[0]["RelationShip"].ToString();
                    txtContactNumber.Text = dtEmployeeInformation.Rows[0]["Contact_Number"].ToString();
                    txtContactAddress.Text = dtEmployeeInformation.Rows[0]["Contact_Address"].ToString();
                    txtMedicalInsuranceDetails.Text = dtEmployeeInformation.Rows[0]["Insurance_Details"].ToString();
                    txtSpecialInstruction.Text = dtEmployeeInformation.Rows[0]["Special_Instruction"].ToString();
                    nudAnnualLeave.Text = dtEmployeeInformation.Rows[0]["Yearly_Holiday"].ToString();
                    nudSickLeave.Text = dtEmployeeInformation.Rows[0]["Sick_Leave"].ToString();
                    nudMaternityPolicy.Text = dtEmployeeInformation.Rows[0]["Maternity_Policy"].ToString();
                    nudPaternityPolicy.Text = dtEmployeeInformation.Rows[0]["Paternity_Policy"].ToString();
                    txtRemarks.Text = dtEmployeeInformation.Rows[0]["Remarks"].ToString();
                    ddlEmployeeTitle.Text = dtEmployeeInformation.Rows[0]["Title"].ToString();

                    GetEmployeePurposeAmount();


                }

            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void GetEmployeePurposeAmount()
        {
            try
            {
                EmployeeInformationBAL objEmployeeBal=new EmployeeInformationBAL();
                DataTable dtList=new DataTable();

                dtList = objEmployeeBal.GetEmployeeSaLaryPurposeInfo(EmployeeCode);
                dgvSalaryInfo.DataSource = dtList;
                dgvSalaryInfo.Columns[2].Visible = false;
                dgvSalaryInfo.Columns[3].Visible = false;

                _dtEmoployeePurposeList = dtList;

                if(dgvSalaryInfo.Rows.Count>0)
                {
                    btnDelete.Enabled = true;
                }

                else
                {
                    btnDelete.Enabled = false;
                }

                GetTotalPurposeAmount();

            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void ShowEmployeeImage(byte []imagebyte)
        {
            try
            {
                MemoryStream ms=new MemoryStream(imagebyte);
                pcbEmployeeImage.Image = Image.FromStream(ms);

            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void GetDepartmerntList()
        {
            try
            {
                EmployeeInformationBAL objEmployeeInfoBal=new EmployeeInformationBAL();
                DataTable dtDepartmentList=new DataTable();

                dtDepartmentList = objEmployeeInfoBal.GetDepartmentList();
                ddlDepartment.DisplayMember = "Department";
                ddlDepartment.DataSource = dtDepartmentList;
             
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void GetJobpositionList()
        {
            try
            {
                EmployeeInformationBAL objEmployeeInfoBal = new EmployeeInformationBAL();
                DataTable dtjpbmpositionlist= new DataTable();

               
                dtjpbmpositionlist= objEmployeeInfoBal.GetJobPositionList();
                ddlJobPosition.DisplayMember = "Designation";
                ddlJobPosition.DataSource = dtjpbmpositionlist;
               

            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void txtNationalID_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((!Regex.IsMatch(e.KeyChar.ToString(), "\\d+")) && txtNationalID.Text!=String.Empty)
                    e.Handled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void txtEmployeeCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if(e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
                {
                    txtEmployeeName.Focus();
                }

            }
            catch 
            {
             
            }
        }

        private void txtEmployeeName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                {
                    txtFatherName.Focus();
                }

            }
            catch
            {

            }
        }

        private void txtAddress_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                {
                    ddlGener.Focus();
                }

            }
            catch
            {

            }
        }

        private void ddlGener_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                {
                    dtpBOD.Focus();
                }

            }
            catch
            {

            }
        }

        private void dtpBOD_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                {
                    ddlBloodGroup.Focus();
                }

            }
            catch
            {

            }
        }

        private void ddlBloodGroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                {
                    ddlFillingStatus.Focus();
                }

            }
            catch
            {

            }

        }

        private void ddlFillingStatus_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                {
                    txtNationality.Focus();
                }

            }
            catch
            {

            }
        }

        private void txtNationality_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                {
                    txtNationalID.Focus();
                }

            }
            catch
            {

            }
        }

        private void txtNationalID_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                {
                   txtMobileNumber.Focus();
                }

            }
            catch
            {

            }
        }

        private void txtMobileNumber_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                {
                    txtHousePhone.Focus();
                }

            }
            catch
            {

            }
        }

        private void txtHousePhone_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                {
                    txtEmailAddress.Focus();
                }

            }
            catch
            {

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void btnBasicRefresh_Click(object sender, EventArgs e)
        {
            RefreshBasicInput();
        }

        private void RefreshBasicInput()
        {
            txtJobResponsiblity.Text = "";
            txtBasicSalary.Text = "0.00";
            txtOthers.Text = "0.00";
            txtGrandTotal.Text = "0.00";
            txtAccountNo.Text = "";
            txtBankName.Text = "";
            txtBranchName.Text = "";
            txtPictureLocation.Text = "";
        }

       

        private void ActivateBankInormation()
        {
            if(ddlPaymentBy.SelectedIndex==1)
            {
                txtBankName.Enabled = true;
                txtAccountNo.Enabled = true;
                txtBranchName.Enabled = true;
                txtBankName.BackColor = SystemColors.Window;
                txtBranchName.BackColor = SystemColors.Window;
                txtAccountNo.BackColor = SystemColors.Window;
                txtBankName.Focus();
            }

            else
            {
                txtBankName.Enabled =false;
                txtAccountNo.Enabled = false;
                txtBranchName.Enabled = false;
                txtBankName.BackColor = SystemColors.InactiveCaptionText;
                txtBranchName.BackColor = SystemColors.InactiveCaptionText;
                txtAccountNo.BackColor = SystemColors.InactiveCaptionText;
                txtBasicSalary.Focus();
            }
        }

        private void ddlPaymentBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ActivateBankInormation();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

       


        private void btnBasicAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidationToInput())
                {
                    EmployeePaymentBO objEmployeePaymentBO = new EmployeePaymentBO();

                    objEmployeePaymentBO.EmployeeCode =SemployeeCode;
                    objEmployeePaymentBO.JoinDate = dtpJoinDate.Value;
                    objEmployeePaymentBO.Department = ddlDepartment.Text;
                    objEmployeePaymentBO.JoinPosition = ddlJobPosition.Text;
                    objEmployeePaymentBO.JobResponsibility = txtJobResponsiblity.Text;
                    objEmployeePaymentBO.PaymentBy = ddlPaymentBy.Text;
                    objEmployeePaymentBO.BankName = txtBankName.Text;
                    objEmployeePaymentBO.BankBranchName = txtBranchName.Text;
                    objEmployeePaymentBO.AccountNo = txtAccountNo.Text;

                    objEmployeePaymentBO.BasicSalary = float.Parse(txtBasicSalary.Text);
                    objEmployeePaymentBO.HouseRent =HouseRent;
                    objEmployeePaymentBO.Medical = Medical;
                    objEmployeePaymentBO.Insurance = Insurasnce;
                    objEmployeePaymentBO.Allowance = Bouns;
                    objEmployeePaymentBO.ProFund = ProfidentFund;
                    objEmployeePaymentBO.Others = float.Parse(txtOthers.Text);

                    EmployeeInformationBAL objEmployeeInfoBal = new EmployeeInformationBAL();

                    if(EmployeeCode!=String.Empty)
                    {
                        objEmployeeInfoBal.UpdateEmployeeBasicInfo(EmployeeCode,objEmployeePaymentBO);
                        MessageBox.Show("Data is Secessfully Updated", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       
                    }

                    else if(SemployeeCode!=String.Empty)
                    {
                        objEmployeeInfoBal.InsertEmployeePayment(objEmployeePaymentBO);

                        MessageBox.Show("Data is Secessfully Saved", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshBasicInput();
                    }

                   


                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }

        private bool ValidationToInput()
        {
            bool status = false;

            if(txtEmployeeCode.Text==String.Empty)
            {
              
                status = false;
                MessageBox.Show("Employee Code Required.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmployeeCode.Focus();
              
            }

            else if(txtEmployeeName.Text==String.Empty)
            {
                status = false;
                MessageBox.Show("Employee Name Required.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmployeeName.Focus();
            }

            else if (ddlDepartment.Text == String.Empty)
            {
                status = false;
                MessageBox.Show("Department Name Required.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ddlDepartment.Focus();
            }

            else if (ddlJobPosition.Text == String.Empty)
            {
                status = false;
                MessageBox.Show("Job Designation Required.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ddlJobPosition.Focus();
            }

            else if (txtJobResponsiblity.Text == String.Empty)
            {
                status = false;
                MessageBox.Show("Job Responsibility Required.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtJobResponsiblity.Focus();
            }

            else if (txtBasicSalary.Text == String.Empty)
            {
                status = false;
                MessageBox.Show("Basic Salary Required.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBasicSalary.Focus();
            }

           

            else if (txtOthers.Text == String.Empty)
            {
                status = false;
                MessageBox.Show("Other Amount Required.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmployeeName.Focus();
            }

            else if(txtJobResponsiblity.Text==String.Empty)
            {
                status = false;
                MessageBox.Show("Job Respoinsibility Required.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtJobResponsiblity.Focus();
            }

            

            else
            {
                status = true;
            }




            return status;
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tcEmployeeInformation.SelectedTab =tcDoucment;
        }

        private void btnImageBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                if(ofdImage.ShowDialog()!=DialogResult.Cancel)
                {
                    txtPictureLocation.Text = ofdImage.FileName;
                    pcbEmployeeImage.Image = Image.FromFile(txtPictureLocation.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        

        private void btnDocSave_Click(object sender, EventArgs e)
        {
            try
            {
                if(EmployeeCode!=String.Empty)
                {
                    UpdateEmployeeImage(EmployeeCode);
                }

                else if(SemployeeCode!=String.Empty)
                {
                    SaveEmployeeDoucment();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void  SaveEmployeeDoucment()
        {
            try
            {
                byte[] image = GetImageBytes(ofdImage.FileName);

                EmployeeDoucmentBO objEmployeeDoucment=new EmployeeDoucmentBO();
                objEmployeeDoucment.EmployeeCode =SemployeeCode;
                objEmployeeDoucment.Image = image;
              
                EmployeeInformationBAL objEmployeeBal=new EmployeeInformationBAL();
                objEmployeeBal.InsertEmployeeDoucment(objEmployeeDoucment);
                MessageBox.Show("Secessfully Save Employee Picture","",MessageBoxButtons.OK,MessageBoxIcon.Information);
             


            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void UpdateEmployeeImage(string employeeCode)
        {
            try
            {
                byte[] image = GetImageBytes(ofdImage.FileName);

                EmployeeDoucmentBO objEmployeeDoucment = new EmployeeDoucmentBO();
                objEmployeeDoucment.Image = image;

                EmployeeInformationBAL objEmployeeBal = new EmployeeInformationBAL();
                objEmployeeBal.UpdateEmployeeImage(employeeCode,image);
                MessageBox.Show("Secessfully Updated Employee Picture", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private byte[] GetImageBytes(string ImageFile)
        {
         
            MemoryStream stream=new MemoryStream();
            Bitmap bitmap=new Bitmap(ImageFile);

            try
            {
               
                bitmap.Save(stream,ImageFormat.Bmp);
                bitmap.Dispose();
            }
            catch (Exception)
            {
                
                throw;
            }

            return stream.ToArray();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFatherName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                {
                    txtMotherName.Focus();
                }

            }
            catch
            {

            }
        }

        private void txtMotherName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                {
                    txtAddress.Focus();
                }

            }
            catch
            {

            }
        }

       
        private void txtAccomAmount_TextChanged_1(object sender, EventArgs e)
        {
           try
            {
                if(txtBasicSalary.Text!=String.Empty)
                txtGrandTotal.Text =Convert.ToString(float.Parse(txtBasicSalary.Text)+float.Parse(txtTotalPurposeAmount.Text)+float.Parse(txtOthers.Text)-float.Parse(txtProAmount.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       

        private void nudAnnualLeave_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtTotalHoliday.Text =
                    Convert.ToString(Int32.Parse(nudAnnualLeave.Value.ToString()) +
                                     Int32.Parse(nudSickLeave.Value.ToString()) +
                                     Int32.Parse(nudMaternityPolicy.Value.ToString()) +
                                     Int32.Parse(nudPaternityPolicy.Value.ToString()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void btnAddPurpose_Click(object sender, EventArgs e)
        {
            try
            {
                frmPurpose objPurpose=new frmPurpose();
                objPurpose.ShowDialog();
                GetList();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GetList()
        {
            try
            {
                EmployeeSalaryInfoBal objEmployeeSalryBal=new EmployeeSalaryInfoBal();
                DataTable dtList=new DataTable();

                dtList = objEmployeeSalryBal.GetSalaryPuerposeList();
                ddlPaymentPurpose.DataSource = dtList;
                ddlPaymentPurpose.DisplayMember = "PurposeName";
                ddlPaymentPurpose.ValueMember = "PurposeId";

            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void ShowdtgColumnHeader()
        {

            try
            {
                

                
                dgvSalaryInfo.Columns.Add("Purpose", "Purpose Name");
                dgvSalaryInfo.Columns.Add("Amount", "Amount Tk.");
                dgvSalaryInfo.Columns.Add("purposeId", "purposeId");
                dgvSalaryInfo.Columns[2].Visible = false;

                GetList();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void btnAddAmount_Click(object sender, EventArgs e)
        {
            try
            {

                bool status = false;

                if(EmployeeCode!=String.Empty)
                {

                    for (int index = 0; index < dgvSalaryInfo.Rows.Count; ++index)
                    {
                        if (Int32.Parse(dgvSalaryInfo.Rows[index].Cells[3].Value.ToString()) == Int32.Parse(ddlPaymentPurpose.SelectedValue.ToString()))
                        {
                            MessageBox.Show(ddlPaymentPurpose.Text + " already Exists.", "",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtPurposeAmount.Focus();
                            status = true;
                            break;
                        }
                    }

                    if(status==false)
                    {
                        DataRow dataRow = dtEmployeePurposeList.NewRow();
                        dataRow["PurposeName"] = ddlPaymentPurpose.Text;
                        dataRow["Amount"] = txtPurposeAmount.Text;
                        dataRow["Employee_Purpose_Id"] = 0;
                        dataRow["purposeId"] = ddlPaymentPurpose.SelectedValue.ToString();
                        dtEmployeePurposeList.Rows.InsertAt(dataRow, dgvSalaryInfo.Rows.Count);
                        dgvSalaryInfo.DataSource = dtEmployeePurposeList;
                        dgvSalaryInfo.Columns[2].Visible = false;
                        dgvSalaryInfo.Columns[3].Visible = false;
                    }
                    

                }

                else
                {
                   

                    if (txtPurposeAmount.Text.Trim() == String.Empty)
                    {
                        MessageBox.Show(ddlPaymentPurpose.Text + " Amount Required.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtPurposeAmount.Focus();
                    }

                    else
                    {
                        float test;

                        if (float.TryParse(txtPurposeAmount.Text, out test) == false)
                        {
                            MessageBox.Show(ddlPaymentPurpose.Text + " Amount Should be Tk. Type.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtPurposeAmount.Focus();
                        }

                        else
                        {


                            if (list.Count == 0)
                            {
                                dgvSalaryInfo.Rows.Add();
                                dgvSalaryInfo.Rows[dgvSalaryInfo.Rows.Count - 1].Cells[0].Value = ddlPaymentPurpose.Text;
                                dgvSalaryInfo.Rows[dgvSalaryInfo.Rows.Count - 1].Cells[1].Value = txtPurposeAmount.Text;
                                dgvSalaryInfo.Rows[dgvSalaryInfo.Rows.Count - 1].Cells[2].Value = ddlPaymentPurpose.SelectedValue.ToString();
                                list.Add(Int32.Parse(ddlPaymentPurpose.SelectedValue.ToString()));
                                status = true;
                            }

                            else
                            {
                                for (int index = 0; index < list.Count; ++index)
                                {
                                    if (list[index] == Int32.Parse(ddlPaymentPurpose.SelectedValue.ToString()))
                                    {
                                        MessageBox.Show(ddlPaymentPurpose.Text + " already Exists.", "",
                                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        txtPurposeAmount.Focus();
                                        status = true;
                                        break;
                                    }

                                }

                                if (status == false)
                                {
                                    dgvSalaryInfo.Rows.Add();
                                    dgvSalaryInfo.Rows[dgvSalaryInfo.Rows.Count - 1].Cells[0].Value = ddlPaymentPurpose.Text;
                                    dgvSalaryInfo.Rows[dgvSalaryInfo.Rows.Count - 1].Cells[1].Value = txtPurposeAmount.Text;
                                    dgvSalaryInfo.Rows[dgvSalaryInfo.Rows.Count - 1].Cells[2].Value = ddlPaymentPurpose.SelectedValue.ToString();
                                    list.Add(Int32.Parse(ddlPaymentPurpose.SelectedValue.ToString()));

                                }
                            }


                            if (txtBasicSalary.Text != String.Empty)
                                txtGrandTotal.Text = Convert.ToString(float.Parse(txtBasicSalary.Text) + float.Parse(txtTotalPurposeAmount.Text) + float.Parse(txtOthers.Text)-float.Parse(txtProAmount.Text));



                        }
                    }
                    
                }

              

                if(dgvSalaryInfo.Rows.Count>0)
                {
                    btnDelete.Enabled = true;
                }

                else
                {
                    btnDelete.Enabled = false;
                }

                GetTotalPurposeAmount();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void GetTotalPurposeAmount()
        {
            try
            {
                float sum = 0;
                for (int i = 0; i <dgvSalaryInfo.Rows.Count; i++)
                {
                    sum = sum + float.Parse(dgvSalaryInfo.Rows[i].Cells[1].Value.ToString());
                }

                txtTotalPurposeAmount.Text = sum.ToString();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do you want to Delete this purpose.", "", MessageBoxButtons.YesNo,
                             MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    int EmployeePurposeId = Int32.Parse(dgvSalaryInfo.SelectedRows[0].Cells[2].Value.ToString());

                    if (EmployeeCode != String.Empty && EmployeePurposeId!=0)
                    {
                        EmployeeInformationBAL objEmployeeInfoBal=new EmployeeInformationBAL();
                        objEmployeeInfoBal.DeleteEmployeePurposeAmount(EmployeePurposeId);

                        int rowIndex = dgvSalaryInfo.SelectedRows[0].Index;
                        dgvSalaryInfo.Rows.RemoveAt(rowIndex);
                    }

                    else
                    {
                        int rowIndex = dgvSalaryInfo.SelectedRows[0].Index;
                        dgvSalaryInfo.Rows.RemoveAt(rowIndex);
                    }

                    GetTotalPurposeAmount();
               
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void txtTotalPurposeAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtBasicSalary.Text != String.Empty)
                    txtGrandTotal.Text = Convert.ToString(float.Parse(txtBasicSalary.Text) + float.Parse(txtTotalPurposeAmount.Text) + float.Parse(txtOthers.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ddlPaymentPurpose_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPurposeAmount.Focus();
        }

        private void chbProfund_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                FalseToReadlyOnlyTxtbox(chbProfund, txtProfindRate, txtProAmount, rbtProfundRate, rbtProAmount);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void FalseToReadlyOnlyTxtbox(CheckBox chbbox, TextBox txtRate, TextBox txtAmount, RadioButton rbtrate, RadioButton rbtAmount)
        {
            try
            {
                if (chbbox.Checked == true)
                {
                    if (rbtrate.Checked)
                    {
                        txtRate.ReadOnly = false;
                        txtAmount.Text = "0.00";
                        txtAmount.ReadOnly = true;
                        txtRate.Focus();


                    }

                    else if (rbtAmount.Checked)
                    {
                        txtAmount.ReadOnly = false;
                        txtRate.Text = "0.00";
                        txtRate.ReadOnly = true;
                        txtAmount.Focus();
                    }



                }

                else if (chbbox.Checked == false)
                {
                    txtAmount.ReadOnly = true;
                    txtRate.ReadOnly = true;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void rbtProfundRate_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                FalseToReadlyOnlyTxtbox(chbProfund, txtProfindRate, txtProAmount, rbtProfundRate,rbtProAmount);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void rbtProAmount_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                FalseToReadlyOnlyTxtbox(chbProfund, txtProfindRate, txtProAmount, rbtProfundRate, rbtProAmount);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void txtProfindRate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CalcuateRateValue(txtProfindRate, txtProAmount, rbtProfundRate, rbtProAmount);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void CalcuateRateValue(TextBox txtRate, TextBox txtAmount, RadioButton rbtrate, RadioButton rbtAmount)
        {
            try
            {
                if (txtAmount.Text != String.Empty && txtRate.Text != String.Empty)
                {
                    if (rbtrate.Checked)
                    {
                        txtAmount.Text = Convert.ToString((float.Parse(txtBasicSalary.Text) * float.Parse(txtRate.Text)) / 100);
                    }

                    txtGrandTotal.Text =
                        Convert.ToString(float.Parse(txtBasicSalary.Text) + float.Parse(txtTotalPurposeAmount.Text) +
                                         float.Parse(txtOthers.Text) -float.Parse(txtProAmount.Text));
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void txtProAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtProAmount.Text != String.Empty)
                    txtGrandTotal.Text =
                           Convert.ToString(float.Parse(txtBasicSalary.Text) + float.Parse(txtTotalPurposeAmount.Text) +
                                            float.Parse(txtOthers.Text) - float.Parse(txtProAmount.Text));
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }



    }
}
