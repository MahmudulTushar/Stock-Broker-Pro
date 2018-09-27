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
using System.IO;
using System.Globalization;
using System.Text.RegularExpressions;
using Reports;
using DataAccessLayer;
using CrystalDecisions.Shared;

namespace StockbrokerProNewArch
{
    public partial class HRModule : Form
    {

        string EmpStatus = "Active";
      //  string MaritStatus = string.Empty;

        #region Mode Selection
        private GlobalVariableBO.ModeSelection _EmployeeInfoBasicCurrentMode = GlobalVariableBO.ModeSelection.NewMode;        
        private GlobalVariableBO.ModeSelection _EmployeeReferenceCurrentMode = GlobalVariableBO.ModeSelection.NewMode;
        private GlobalVariableBO.ModeSelection _EmployeeEmergencyCurrentMode = GlobalVariableBO.ModeSelection.NewMode;
        private GlobalVariableBO.ModeSelection _EmployeeBranchCurrent = GlobalVariableBO.ModeSelection.NewMode;
        private GlobalVariableBO.ModeSelection _EmployeeDocumentCurrent = GlobalVariableBO.ModeSelection.NewMode;
        private GlobalVariableBO.ModeSelection _EmployeePayrollCurrent = GlobalVariableBO.ModeSelection.NewMode;
        #endregion

        #region Constructor
        public HRModule()
        {
            InitializeComponent();
            
        }
        #endregion

        #region Global variable
        private int _EMPID;
        private int RowId;
        private int _New_Id;
        private string id = "0";

        private void GetName()
        {
            if (TabHrModule.SelectedTab == TabHrModule.TabPages[1])
            {
                if (CmbrefEmployeeid.SelectedIndex >= 0)
                {
                    id = CmbrefEmployeeid.SelectedValue.ToString();
                 //   EmpRefName.Text = objEmpBranMapBAL.GetEmployeeName(id);
                    EmpRefName.Text = id;

                }                 
            }
            else if (TabHrModule.SelectedTab == TabHrModule.TabPages[2])
            {
                id = CmbEmpEmrId.SelectedValue.ToString();
              //  EmpEmrName.Text = objEmpBranMapBAL.GetEmployeeName(id);
                EmpEmrName.Text = id;
            }
            else if (TabHrModule.SelectedTab == TabHrModule.TabPages[4])
            {
                id = cmbEmpDocumentId.SelectedValue.ToString();
               // EmpDocumentName.Text = objEmpBranMapBAL.GetEmployeeName(id);
                EmpDocumentName.Text = id;
            }
            else if (TabHrModule.SelectedTab == TabHrModule.TabPages[5])
            {
               
                id = cmbEmpPayrollId.SelectedValue.ToString();
               // empPayrollName.Text = objEmpBranMapBAL.GetEmployeeName(id);
                empPayrollName.Text = id;
            }
             
        }

        #endregion

        #region call Business Layer
        EmployeeBasicInfoBAL objBALBaic = new EmployeeBasicInfoBAL();
        EmployeeAdditionalInfoBAL objBALAdditional = new EmployeeAdditionalInfoBAL();
        EmployeeBasicAndAdditionalInfoBAL objAdditionalAndBasic = new EmployeeBasicAndAdditionalInfoBAL();
        EmployeeReferenceBAL objEmpRef = new EmployeeReferenceBAL();
        EmployeeEmergencyBAL objEmpEmrBAL = new EmployeeEmergencyBAL();
        EmployeeDocumentBAL objEmpDocumentBAL = new EmployeeDocumentBAL();
        EmployeeBranchMapBAL objEmpBranMapBAL = new EmployeeBranchMapBAL();
        EmployeePayrollBAL objEmpPayrollBAL = new EmployeePayrollBAL();
        #endregion

        #region Employee Basic and Additional Information

        #region Employee Additional Info

        private EmployeeAdditionalInfoBO InitializeEmployeeAdditionalInfoBO()
        {
            EmployeeAdditionalInfoBO objaddbo = new EmployeeAdditionalInfoBO();
            objaddbo.Employee_Nationality = txtNationality.Text;
            objaddbo.Employee_National_Id_No = txtnationalId.Text;
            objaddbo.Employee_Tin = txtTin.Text;
            objaddbo.Employee_Passport = txtpassportNo.Text;
            objaddbo.Employee_Bank_Name = cmbbankname.Text;
            objaddbo.Employee_Bank_Id = cmbbankname.SelectedValue.ToString();
            objaddbo.Employee_Branch_Name = cmbbranchname.Text;
            objaddbo.Employee_Branch_Id = cmbbranchname.SelectedValue.ToString();
            objaddbo.Employee_Bank_Acc_No = txtBankAccountNo.Text;
            objaddbo.Employee_Bank_Route_No = CmbBankRouteNo.SelectedValue.ToString();
            objaddbo.Employee_Present_Address = txtPresentAddr.Text;
            objaddbo.Employee_Permanent_Address = txtPermanetAddr.Text;
            objaddbo.ImgByte = GetImageByte(ofdImageBrowse.FileName);           
            return objaddbo;
        }

        private void EnableEmployeeAdditionalInfo()
        {
            txtNationality.Enabled = true;
            txtnationalId.Enabled = true;
            txtTin.Enabled = true;
            txtpassportNo.Enabled = true;
            txtBankAccountNo.Enabled = true;
            CmbBankRouteNo.Enabled = true;
            txtPermanetAddr.Enabled = true;
            txtPresentAddr.Enabled = true;
        }

        private void DisableEmployeeAdditionalInfo()
        {
            txtNationality.Enabled = false;
            txtnationalId.Enabled = false;
            txtTin.Enabled = false;
            txtpassportNo.Enabled = false;
            cmbbankname.Enabled = false;
            cmbbranchname.Enabled = false;
            txtBankAccountNo.Enabled = false;
            CmbBankRouteNo.Enabled = false;
            txtPermanetAddr.Enabled = false;
            txtPresentAddr.Enabled = false;
        }

        private void ClearEmployeeAdditionalInfo()
        {            
            txtNationality.Text = string.Empty;
            txtnationalId.Text = string.Empty;
            txtTin.Text = string.Empty;
            txtpassportNo.Text = string.Empty;
            txtBankAccountNo.Text= string.Empty;            
            txtPermanetAddr.Text = string.Empty;
            txtPresentAddr.Text = string.Empty;
            if (CmbBankRouteNo.Items.Count > 0)
                CmbBankRouteNo.SelectedIndex = 1;
        }

        private bool IsValidEmployeeAdditionalInfo()
        {
            bool result = true;
            if (txtNationality.Text.Trim() == string.Empty)
            {

                MessageBox.Show("Employee Nationality is required");
                result = false;
                txtNationality.Focus();
            }
            else if (txtnationalId.Text.Trim() == string.Empty)
            {
                
                MessageBox.Show("Employee national Id is required");
                result = false;
                txtnationalId.Focus();
            }
            else if (txtBankAccountNo.Text.Trim() == string.Empty)
            {
                
                MessageBox.Show("Employee Bank account no is required");
                result = false;
                txtBankAccountNo.Focus();
            }
            else if (txtPresentAddr.Text.Trim() == string.Empty)
            {
                
                MessageBox.Show("Employee present address is required");
                result = false;
                txtPresentAddr.Focus();
            }
            else if (txtPermanetAddr.Text.Trim() == string.Empty)
            {
                
                MessageBox.Show("Employee parmanent is required");
                result = false;
                txtPermanetAddr.Focus();

            }
            else if (txtImgLocation.Text.Trim() == "")
            {
                MessageBox.Show("Your Necessary Image is required");
                result = false;
            }
            else if (picPhoto.Image  == null )
            {
                MessageBox.Show("Your Necessary Image is required");
                result = false;
            }
            return result;
        }

        #endregion

        #region Employee Basic info

        private void GetComboBoxId()
        {
            DataTable dt = new DataTable();
            dt=objBALBaic.GetComboId();
            cmbempId.DataSource = dt;
            cmbempId.DisplayMember = dt.Columns[0].ToString();
            cmbempId.ValueMember = dt.Columns[0].ToString();
        }

        private void GetDepartment()
        {
            DataTable dt = new DataTable();
            dt = objBALBaic.GetDepartment();
            CmbDepartment.DataSource = dt;
            CmbDepartment.DisplayMember = dt.Columns[0].ToString();
            CmbDepartment.ValueMember = dt.Columns[0].ToString();
        }

        private EmployeeBasicInfoBO InitializeEmployeeBasicInfoBo()
        {
            EmployeeBasicInfoBO objBO = new EmployeeBasicInfoBO();
            if (_EmployeeInfoBasicCurrentMode == GlobalVariableBO.ModeSelection.UpdateMode)
            {
                objBO.Employee_Id = int.Parse(cmbempId.Text);
            }
            else
            {
                
                objBO.Employee_Id = int.Parse(txtEmpNewId.Text);
            }
            objBO.Employee_Tittle = cmbTittle.Text;
            objBO.Employee_First_Name = txtFirstName.Text;
            objBO.Employee_Last_Name = txtLastName.Text;
            objBO.Employee_Gender = txtGender.Text;
            objBO.Employee_Father_Name = txtFatherName.Text;
            objBO.Employee_Mother_Name = txtMtoherName.Text;
            objBO.Employee_Maritial_Status = txtMaritialStatus.Text;             
            objBO.Employee_Join_Date = dtpJoin.Value;
            objBO.Employee_Birth_Date = dtpDateofBirth.Value;
            objBO.Employee_Discharge_Date = dtpDischarge.Value;
            objBO.Employee_Departmnent_Name = CmbDepartment.Text;
            objBO.Employee_Contact_Number = txtcontact.Text;
            objBO.Employee_Alter_Contact_Number = txtSecondCont.Text;
            objBO.Employee_Home_Phone = txtHomePhon.Text;
            objBO.Employee_Email = txEmail.Text;
            objBO.Employee_Supervisor_Id = cmbSupervisorId.Text.ToString() ;
            objBO.Employee_Status = EmpStatus;
            return objBO;
        }

        private void EnableEmployeeBasicInfo()
        {
            cmbempId.Enabled = true;
            cmbTittle.Enabled = true;
            txtFirstName.Enabled = true;
            txtLastName.Enabled = true;
            txtGender.Enabled = true;
            txtFatherName.Enabled = true;
            txtMtoherName.Enabled = true;
            txtMaritialStatus.Enabled = true;            
            dtpJoin.Enabled = true;
            dtpDischarge.Enabled = true;
            dtpDateofBirth.Enabled = true;
            CmbDepartment.Enabled = true;
            txtcontact.Enabled = true;
            txtSecondCont.Enabled = true;
            txtHomePhon.Enabled = true;
            txEmail.Enabled = true;
            cmbSupervisorId.Enabled = true;
        }

        private void DisableEmployeeBasicInfo()
        {
            cmbempId.Enabled = false;
            cmbTittle.Enabled = false;
            txtFirstName.Enabled = false;
            txtLastName.Enabled = false;
            txtGender.Enabled = false;
            txtFatherName.Enabled = false;
            txtMtoherName.Enabled = false;
            txtMaritialStatus.Enabled = false;
            dtpJoin.Enabled = false;
            dtpDischarge.Enabled = false;
            dtpDateofBirth.Enabled = false;
            CmbDepartment.Enabled = false;
            txtcontact.Enabled = false;
            txtSecondCont.Enabled = false;
            txtHomePhon.Enabled = false;
            txEmail.Enabled = false;
            cmbSupervisorId.Enabled = false;
        }

        private void ClearEmployeeBasicInfo()
        {
            EnableEmployeeBasicInfo();
            cmbempId.Text = string.Empty;
            cmbTittle.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtGender.Text = string.Empty;
            txtFatherName.Text = string.Empty;
            txtMtoherName.Text = string.Empty;
            txtMaritialStatus.Text = string.Empty;             
            dtpJoin.Text = string.Empty;
            dtpDischarge.Text = string.Empty;
            dtpDateofBirth.Text = string.Empty;
            CmbDepartment.Text = string.Empty;
            txtcontact.Text = string.Empty;
            txtSecondCont.Text = string.Empty;
            txtHomePhon.Text = string.Empty;
            txEmail.Text = string.Empty;
            cmbSupervisorId.Text = string.Empty;

        }
        
        private void txEmail_Leave(object sender, EventArgs e)
        {
            //string input = txEmail.Text;
            //if(input.Contains("@")&&input.Contains("."))
            //{
            //    MessageBox.Show("Valid Email Address");
            //}            
            //else
            //{
            //    MessageBox.Show("Email Invalid");
            //    txEmail.Focus();
            // }
        }

        private bool IsvalidEmployeeBasicInfo()
        {
            bool result = true;
            
            if (txtFirstName.Text.Trim() == "")
            {
                
                MessageBox.Show("Please Enter Employee First Name");
                result = false;
                txtFirstName.Focus();
            }
            else if (txtLastName.Text.Trim() == "")
            {
                
                MessageBox.Show("Please Enter Employee Last Name");
                result = false;
                txtLastName.Focus();
            }
            else if (cmbTittle.Text.Trim() == "")
            {
                
                MessageBox.Show("Please select Employee Tittle Name");
                result = false;
                cmbTittle.Focus();
            }
            else if (txtGender.Text.Trim() == "")
            {
                
                MessageBox.Show("Please Enter Employee Gender male Or Female");
                result = false;
                txtGender.Focus();
            }
            else if (txtFatherName.Text.Trim() == "")
            {
                
                MessageBox.Show("Please Enter Employee Father Name");
                result = false;
                txtFatherName.Focus();
            }
            else if (txtMtoherName.Text.Trim() == "")
            {
                
                MessageBox.Show("Please Enter Employee Mother Name");
                result = false;
                txtMtoherName.Focus();
            }
            else if (txtMaritialStatus.Text.Trim() == "")
            {
                
                MessageBox.Show("Please Enter Employee Maritial Status");
                result = false;
                txtMaritialStatus.Focus();
            }
            else if (dtpDateofBirth.Value.ToString() == "")
            {
                
                MessageBox.Show("Please Enter Employee Birth date");
                result = false;
                dtpDateofBirth.Focus();
            }
            else if (dtpJoin.Value.ToString() == "")
            {
                
                MessageBox.Show("Please Enter Employee Join Date");
                result = false;
                dtpJoin.Focus();
            }

            else if (CmbDepartment.Text.Trim() == "")
            {
                
                MessageBox.Show("Please Enter Employee Department Name");
                result = false;
                CmbDepartment.Focus();
            }
            else if (txtcontact.Text.Trim() == "")
            {
               
                MessageBox.Show("Please Enter Employee Contact Number");
                result = false;
                txtcontact.Focus();
            }            
            return result;
        }

        #endregion

        #region Load Employee information

        private void LoadEmployeeAllInfo()
        {
            DataTable dtgrid = new DataTable();
            dtgrid = objBALBaic.GetEmployeeAllBasicInfo();
            //dgvEmployeeInfo.DataSource = dtgrid;
            //dgvEmployeeInfo.Columns["Employee_ID"].Visible = false;
            if (_EmployeeInfoBasicCurrentMode == GlobalVariableBO.ModeSelection.UpdateMode)
            {
                dgvEmployeeInfo.DataSource = dtgrid;
                int nRowIndex = RowId;
                dgvEmployeeInfo.Rows[nRowIndex].Selected = true;
                dgvEmployeeInfo.Rows[nRowIndex].Cells[0].Selected = true;

            }
            else
            {
                dgvEmployeeInfo.DataSource = dtgrid;
                DisableAllEmpdocumnentInfo();
                //dgvEmployeeInfo.Columns[1].Visible = false;
                dgvEmployeeInfo.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
            


        }

        private void LoadSupervisorId()
        {
            DataTable dt = new DataTable();
            dt = objBALBaic.GetSuperVisorId();
            cmbSupervisorId.DataSource = dt;
            cmbSupervisorId.DisplayMember = dt.Columns[1].ToString();
            cmbSupervisorId.ValueMember = dt.Columns[0].ToString();
        }

        #endregion

        #region Employee Basic and additional Information

        private void txtEmployeeId_Leave(object sender, EventArgs e)
        {
            if (cmbempId.Text == objBALBaic.GetEmployeeId(cmbempId.Text))
            {
                int New_Id = objBALBaic.GetNewEmployeeId();
                New_Id = New_Id + 1;
                MessageBox.Show("Employee Id Already exist You can able to enter from " + New_Id + " to More");
            }

        }

        private void InitiateBasicnAndUpdateButton()
        {
           // btnEmployeeInfoUpdate.Enabled = false;
           // btnEmployeeInfoNew.Enabled = true;
            DisableEmployeeBasicInfo();
            DisableEmployeeAdditionalInfo();
        }

        public void NewEmployeeId()
        {
             _New_Id = objBALBaic.GetNewEmployeeId();
             txtEmpNewId.Text = (_New_Id + 1).ToString();
        }

        private void btnEmployeeInfoClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIdCheck_Click(object sender, EventArgs e)
        {
            txtEmpNewId.Enabled = true ;
            NewEmployeeId();

            dtpDischarge.Enabled = false;
            btnEmployeeInfoSave.Enabled = true;
        }

        private void btnEmployeeInfoNew_Click(object sender, EventArgs e)
        {
            _EmployeeInfoBasicCurrentMode = GlobalVariableBO.ModeSelection.NewMode;
           // btnEmployeeInfoNew.Enabled = false;
          //  btnEmployeeInfoNew.BackColor = Color.Gray;
          //  btnEmployeeInfoUpdate.Enabled = true;
          //  btnEmployeeInfoUpdate.ResetBackColor();
            ClearEmployeeBasicInfo();
            ClearEmployeeAdditionalInfo();            
            EnableEmployeeBasicInfo();
            EnableEmployeeAdditionalInfo();
            cmbTittle.SelectedIndex = 0;
            cmbSupervisorId.SelectedIndex =-1;
            cmbempId.Visible = false;
            btnIdCheck.Visible = true;
            txtEmpNewId.Visible = true;

            red_GenderM.Checked = false;
            red_Gendr_F.Checked = false;
            red_Maritial_NO.Checked = false;
            red_Maritial_Yess.Checked = false;

            txtEmpNewId.Enabled = false;

            btnIdCheck.Enabled = true;
            btnEmployeeInfoUpdate.Enabled = false;
          
            GetDepartment();

            dtpDischarge.Enabled = false;
        //    btnEmployeeInfoSave.Enabled = true ;

            picPhoto.Image = null;
            txtEmpNewId.Text = string.Empty;
        }
         private DbConnection _dbconnection =new DbConnection ();   
 
        private void btnEmployeeInfoUpdate_Click(object sender, EventArgs e)
        {
          //  objaddbo.ImgByte = GetImageByte(ofdImageBrowse.FileName);
            btnIdCheck.Enabled = false;
             byte[] arr;
                ImageConverter converter = new ImageConverter();
                arr = (byte[])converter.ConvertTo(picPhoto.Image, typeof(byte[]));


            string query = @"   UPDATE [SBP_Employee_Master]
                                SET
                                      [Title] = '" + cmbTittle.Text + @"'
                                     ,[First_Name] ='" + txtFirstName.Text + @"'
                                     ,[Last_Name] ='" + txtLastName.Text + @"'
                                     ,[Date_Of_Joining] ='" + dtpJoin.Value.ToString("yyyy-MM-dd") + @"'
                                     ,[Supervisor_EmpID] ='" + cmbSupervisorId.Text + @"'
                                     ,[Department] = '" + CmbDepartment.Text + @"'
                                     ,[Date_of_Birth] ='" + dtpDateofBirth.Value.ToString("yyyy-MM-dd") + @"'
                                     ,[Bank_Account_No] ='" + txtBankAccountNo.Text + @"'
                                     ,[Bank_ID] =" + cmbbranchname.SelectedValue.ToString() + @"
                                     ,[Bank_Name] ='" + cmbbankname.Text + @"'
                                     ,[Branch_ID] ='" + cmbbranchname.SelectedValue.ToString() + @"'
                                     ,[Bank_Branch] ='" + cmbbranchname.Text + @"'
                                     ,[Bank_Routing_No] ='" + CmbBankRouteNo.SelectedValue.ToString() + @"'
                                     ,[Nationality] ='" + txtNationality.Text + @"'
                                     ,[National_ID_No] ='" + txtnationalId.Text + @"'
                                     ,[TIN] ='" + txtTin.Text + @"'
                                     ,[Passport_No] ='" + txtpassportNo.Text + @"'
                                     ,[Contact_Number] ='" + txtcontact.Text + @"'
                                    ,[Alterate_Contact_Number] ='" + txtSecondCont.Text + @"'
                                    ,[Home_Phone] ='" + txtHomePhon.Text + @"'
                                    ,[Email] ='" + txEmail.Text + @"'
                                    ,[Father_Name] ='" + txtFatherName.Text + @"'
                                    ,[Mother_Name] ='" + txtMtoherName.Text + @"'
                                    ,[Present_Address] ='" + txtPresentAddr.Text + @"'
                                    ,[Permanent_Address] ='" + txtPermanetAddr.Text + @"'
                                    ,[Gender] ='" + txtGender.Text + @"'
                                    ,[Marital_Status] ='" + txtMaritialStatus.Text + @"'
                                    ,[Date_Of_Discharge] ='" + dtpDischarge.Value .ToString ("yyyy-MM-dd")+ @"'
                                  
                                    --,[Update_Date] ='Convert(varchar(11), getdate(), 106)' 
                                    ,[Entry_By] =0                                    
                                  WHERE Employee_ID= '" + _EMPID + @"'

                         ";

            string queryString = @" UPDATE HR_EmpImageDT set Emp_Image=@EMP_Image where (Emp_ID='" + _EMPID + @"')  ";
            
            try
            {
                this._dbconnection.ConnectDatabase();
                this._dbconnection.ExecuteNonQuery(query); 
                

                _dbconnection.Connect_ImageDB();
                 _dbconnection.AddParameter("@EMP_Image", SqlDbType.Binary, arr);
                this._dbconnection.ExecuteNonQuery(queryString);

                
                MessageBox.Show("Update successfully");
                LoadEmployeeAllInfo(); 
                this._dbconnection.CloseDatabase(); 
            }
            catch (Exception ex)
            {
                this._dbconnection.CloseDatabase();
                MessageBox.Show("Update Unsuccessfully");
            }

                        
            
            //btnEmployeeInfoNew.ResetBackColor();
            //ClearEmployeeBasicInfo();
            //DisableEmployeeBasicInfo();
            //ClearEmployeeAdditionalInfo();
            //DisableEmployeeAdditionalInfo();

            //btnIdCheck.Visible = false;
            //txtEmpNewId.Visible = false;
            //cmbempId.Visible = true;

            //GetComboBoxId();
        }

        private void btnEmployeeInfoReset_Click(object sender, EventArgs e)
        {
            if (_EmployeeInfoBasicCurrentMode == GlobalVariableBO.ModeSelection.UpdateMode)
            {
                ClearEmployeeBasicInfo();
                DisableEmployeeBasicInfo();
                ClearEmployeeAdditionalInfo();
                DisableEmployeeAdditionalInfo();
               
            }
            else
            {
                ClearEmployeeBasicInfo();
                EnableEmployeeBasicInfo();
                ClearEmployeeAdditionalInfo();
                EnableEmployeeAdditionalInfo();
            }
            btnEmployeeInfoUpdate.Enabled = false;
        }

        private void btnEmployeeInfoSave_Click(object sender, EventArgs e)
        {
            EmployeeBasicAndAdditionalInfoBAL objAddAndBasic = new EmployeeBasicAndAdditionalInfoBAL();
            EmployeeAdditionalInfoBO AdditionalBo = new EmployeeAdditionalInfoBO();
            EmployeeBasicInfoBO BasicBo = new EmployeeBasicInfoBO();
            
            switch (_EmployeeInfoBasicCurrentMode)
            {
                case GlobalVariableBO.ModeSelection.NewMode:
                    try
                    {
                        AdditionalBo = InitializeEmployeeAdditionalInfoBO();
                        BasicBo = InitializeEmployeeBasicInfoBo();
                        
                        if (IsvalidEmployeeBasicInfo() )
                        {
                            /*&& IsValidEmployeeAdditionalInfo()*/
                            if (IsValidEmployeeAdditionalInfo())
                            {
                                Basic.SelectedTab = Basic.TabPages[0];
                                
                                objAddAndBasic.SaveEmployeeAllInformation(BasicBo, AdditionalBo);
                            MessageBox.Show("Data save successfully");
                            ClearEmployeeAdditionalInfo();
                            ClearEmployeeBasicInfo();
                            LoadEmployeeAllInfo();

                            }
                           
                        }
                        
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case GlobalVariableBO.ModeSelection.UpdateMode:
                    try
                    {
                        AdditionalBo = InitializeEmployeeAdditionalInfoBO();
                        BasicBo = InitializeEmployeeBasicInfoBo();
                        objAddAndBasic.UpdateEmployeeInformation(BasicBo, AdditionalBo, _EMPID);
                        MessageBox.Show("Update successfully");
                        ClearEmployeeAdditionalInfo();
                        ClearEmployeeBasicInfo();
                        LoadEmployeeAllInfo();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
            }
        }

        #endregion

        #region Photo
        private void btnupload_Click(object sender, EventArgs e)
        {
            //EmployeeAdditionalInfoBO objaddbo = new EmployeeAdditionalInfoBO();
            //OpenFileDialog open = new OpenFileDialog();
            //open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            //if (open.ShowDialog() == DialogResult.OK)
            //if(ImageBrowse.ShowDialog()==DialogResult.OK)
            //{
                //EmployeePicture.Image = new Bitmap(open.FileName);
                // textBox1.Text = open.FileName;
                //txtImgLocation.Text = open.FileName;
                //EmployeePicture.Image = Image.FromFile(txtImgLocation.Text);
                //objaddbo.ImgByte = GetImageByte(open.FileName);
                //txtImgLocation.Text = ImageBrowse.FileName;
                //picPhoto.Image = Image.FromFile(txtImgLocation.Text);
                //objaddbo.ImgByte = GetImageByte(ImageBrowse.FileName);                
            //}
            if (txtEmpNewId.Text.Trim() == string.Empty || cmbempId.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Employee Id is required.", "Image Upload", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmpNewId.Focus();
                return;
            }
            if (txtImgLocation.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Imasge File Path Required to upload Image.", "Image Upload", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnImgBrowse.Focus();
                return;
            }
            EmployeeAdditionalInfoBO objaddbo = new EmployeeAdditionalInfoBO();
            EmployeeBasicInfoBO objBasicBo=new EmployeeBasicInfoBO();
            objaddbo.ImgByte = GetImageByte(ofdImageBrowse.FileName);
            //if (objaddbo.ImgByte != null)
            //{
            //    if (objBALAdditional.CheckIsExistPhot(objBasicBo)==true)
            //    {
            //        objBALAdditional.SavetoDataBase(
            //    }
            //}
            
        }
        
        #endregion

        #region Load Bank Info

        private void LoadBankInfo()
        {
            DataTable dt = new DataTable();
            dt = objBALAdditional.GetBankName();
            cmbbankname.DataSource = dt;
            cmbbankname.DisplayMember = dt.Columns["Bank_Name"].ToString();
            cmbbankname.ValueMember = dt.Columns["Bank_ID"].ToString();   
        }
        private void LoadBranchInfo()
        {
            DataTable dt = new DataTable();
            //string id = (cmbbankname.SelectedValue).ToString();
            //int EID = int.Parse(id);
            dt = objBALAdditional.GetBranchname();
            cmbbranchname.DataSource = dt;
            cmbbranchname.DisplayMember = dt.Columns["Branch_Name"].ToString();
            cmbbranchname.ValueMember = dt.Columns["Branch_ID"].ToString();
        }
        private void LoadBankRouteInfo()
        {
            DataTable dt = new DataTable();
            dt = objBALAdditional.GetBranchRoutNo();
            CmbBankRouteNo.DataSource = dt;
            CmbBankRouteNo.DisplayMember = dt.Columns[0].ToString();
            CmbBankRouteNo.ValueMember = dt.Columns[0].ToString();
            if (CmbBankRouteNo.Items.Count > 0)
                CmbBankRouteNo.SelectedIndex = 1;
        }

        private void CmbBankRouteNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbBankRouteNo.SelectedIndex>0)
            {
                DataTable dtBank = new DataTable();
                DataTable dtBranch = new DataTable();

                dtBank = objBALAdditional.GetBankName(CmbBankRouteNo.SelectedValue.ToString());
                //cmbbankname.DataSource = dtBank;
                cmbbankname.SelectedValue = int.Parse(dtBank.Rows[0]["Bank_ID"].ToString());

                dtBranch = objBALAdditional.GetBranchname(CmbBankRouteNo.SelectedValue.ToString());
                //cmbbranchname.DataSource = dtBranch;
                cmbbranchname.SelectedValue =  int.Parse(dtBranch.Rows[0]["Branch_ID"].ToString());
            }
        }
        
        #endregion

        private void red_GenderM_CheckedChanged(object sender, EventArgs e)
        {
            txtGender.Text  = "Male";
        }

        private void red_Gendr_F_CheckedChanged(object sender, EventArgs e)
        {
            txtGender.Text = "Fmale";
        }

        private void red_Maritial_Yess_CheckedChanged(object sender, EventArgs e)
        {
            txtMaritialStatus .Text= "Yes";
        }

        private void red_Maritial_NO_CheckedChanged(object sender, EventArgs e)
        {
            txtMaritialStatus.Text = "No";
        }

        #endregion

        #region Employee Reference Information        

        #region Grid Data
        private void LoadEmpReference()
        {
            DataTable dtReferenceGrid = new DataTable();
            dtReferenceGrid = objEmpRef.GetEmployeeReferenceInfo();
            //dgvEmployeeInfo.DataSource = dtReferenceGrid;
            if (_EmployeeReferenceCurrentMode == GlobalVariableBO.ModeSelection.UpdateMode)
            {
                dgvEmployeeInfo.DataSource = dtReferenceGrid;
                int nRowIndex = RowId;
                dgvEmployeeInfo.Rows[nRowIndex].Selected = true;
                dgvEmployeeInfo.Rows[nRowIndex].Cells[0].Selected = true;

            }
            else
            {
                dgvEmployeeInfo.DataSource = dtReferenceGrid;
                DisableAllEmpdocumnentInfo();
                //dgvEmployeeInfo.Columns[1].Visible = false;
                dgvEmployeeInfo.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
        }
        #endregion

        #region Reference Info

        private void GetAllEmployeeId()
        {
            DataTable dt = new DataTable();
            dt = objEmpRef.GetEmployeeId();
            CmbrefEmployeeid.DataSource = dt;
            CmbrefEmployeeid.DisplayMember = dt.Columns[1].ToString();
            CmbrefEmployeeid.ValueMember = dt.Columns[0].ToString();
        }

        private EmployeeReferenceInfoBO InitializeEmpReferenceInfoBO()
        {

            EmployeeReferenceInfoBO objRefempBo = new EmployeeReferenceInfoBO();
            objRefempBo.Ref_Employee_ID = int.Parse(EmpRefName.Text);
            objRefempBo.Ref_Employee_Name = txtrefName.Text;
            objRefempBo.Ref_Employee_Profession = txtRefProfession.Text;
            objRefempBo.Ref_Employee_Phone = txtRefPhone.Text;            
            objRefempBo.Ref_Employee_Email = txtRefEmail.Text;
            objRefempBo.Ref_Employee_Address = txtrefaddress.Text;
            return objRefempBo;
        }

        private void ClearAllReferenceinfo()
        {
            CmbrefEmployeeid.Text = "";
            EmpRefName.Text = "";
            txtRefProfession.Text = "";
            txtRefPhone.Text = "";
            txtRefEmail.Text = "";
            txtrefaddress.Text = "";
            txtrefName.Text = "";
        }

        private void EnableAllEmpReferenceInfo()
        {
            CmbrefEmployeeid.Enabled = true;
            txtrefName.Enabled = true;
            txtRefProfession.Enabled=true;
                txtRefPhone.Enabled=true;
                txtRefEmail.Enabled=true;
                txtrefaddress.Enabled = true;
        }

        private void DisableAllEmpReferenceInfo()
        {
            CmbrefEmployeeid.Enabled = false;
            txtrefName.Enabled = false;
            txtRefProfession.Enabled = false;
            txtRefPhone.Enabled = false;
            txtRefEmail.Enabled = false;
            txtrefaddress.Enabled = false;
        }

        private bool IsValidEmpReferenceInfo()
        {
            bool result=true;

            if (txtrefName.Text.Trim() == "")
            {
                
                MessageBox.Show("Employee Reference Name is required");
                result = false;
                txtrefName.Focus();
            }
            else if (txtRefPhone.Text.Trim() == "")
            {
                MessageBox.Show("Employee Reference Phone is required");
                result = false;
                txtRefPhone.Focus();
            }
            else if (txtRefProfession.Text.Trim() == "")
            {
                MessageBox.Show("Employee Reference Profession is required");
                result = false;
                txtRefProfession.Focus();
            }

            else if (txtrefaddress.Text.Trim() == "")
            {
                throw new Exception("Employee Reference Address is Required");
            }

            else if (txtRefPhone.MaxLength <12)
            {
                txtRefPhone.ForeColor = Color.Red; 

                MessageBox.Show("Employee Reference Phone Number Error");
                result = false;
                txtRefPhone.Focus();
            }

            return result;
        }

        private void btnEmployeeReferenceNew_Click(object sender, EventArgs e)
        {
            _EmployeeReferenceCurrentMode = GlobalVariableBO.ModeSelection.NewMode;
            btnEmployeeReferenceNew.Enabled = false;
            btnEmployeeReferenceNew.BackColor = Color.Gray;
            //btnEmployeeReferenceUpdate.Enabled = true;
            //btnEmployeeReferenceUpdate.ResetBackColor();
            ClearAllReferenceinfo();
            EnableAllEmpReferenceInfo();
            GetAllEmployeeId();
            GetName();

            btnEmployeeReferenceSave.Enabled = true;
            btnEmployeeReferenceUpdate.Enabled = false;

        }

        private void btnEmployeeReferenceUpdate_Click(object sender, EventArgs e)
        {
            EmployeeReferenceInfoBO enpRefBO = new EmployeeReferenceInfoBO();
            try
            {

              
                    enpRefBO = InitializeEmpReferenceInfoBO();
                    objEmpRef.UpdatEEmployeeReferenceInfo(enpRefBO, _EMPID);
                    MessageBox.Show("Update Successfully");
                    ClearAllReferenceinfo();
                    LoadEmpReference();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            
            _EmployeeReferenceCurrentMode = GlobalVariableBO.ModeSelection.UpdateMode;
            //btnEmployeeReferenceUpdate.Enabled = false;
            //btnEmployeeReferenceUpdate.BackColor = Color.Gray;
            //btnEmployeeReferenceNew.Enabled = true;
            btnEmployeeReferenceNew.ResetBackColor();
            ClearAllReferenceinfo();
            DisableAllEmpReferenceInfo();
        }
        private void btnEmployeeReferenceReset_Click(object sender, EventArgs e)
        {
            if (_EmployeeReferenceCurrentMode == GlobalVariableBO.ModeSelection.UpdateMode)
            {
                ClearAllReferenceinfo();
                DisableAllEmpReferenceInfo();
            }
            else
            {
                ClearAllReferenceinfo();
                EnableAllEmpReferenceInfo();
            }
            btnEmployeeReferenceNew.Enabled = true;
        }

        private void btnEmployeeReferenceSave_Click(object sender, EventArgs e)
        {
            EmployeeReferenceInfoBO enpRefBO = new EmployeeReferenceInfoBO();
            switch (_EmployeeReferenceCurrentMode)
            {
                case GlobalVariableBO.ModeSelection.NewMode:
                    try
                    {
                        if (IsValidEmpReferenceInfo())
                        {
                            enpRefBO = InitializeEmpReferenceInfoBO();
                            objEmpRef.SaveEmployeeReferenceInfo(enpRefBO);
                            MessageBox.Show("Saved Successfully");
                            ClearAllReferenceinfo();
                            LoadEmpReference();


                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case GlobalVariableBO.ModeSelection.UpdateMode:
                    try
                    {
                        
                        if (IsValidEmpReferenceInfo())
                        {
                            enpRefBO = InitializeEmpReferenceInfoBO();
                            objEmpRef.UpdatEEmployeeReferenceInfo(enpRefBO, _EMPID);
                            MessageBox.Show("Update Successfully");
                            ClearAllReferenceinfo();
                            LoadEmpReference();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
            }
        }
        private void InitUpdateButton()
        {
            //btnEmployeeReferenceUpdate.Enabled = false;
            //btnEmployeeReferenceNew.Enabled = true;
            DisableAllEmpReferenceInfo();
        }

        private void btnEmployeeReferenceClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
        
        #endregion

        #region Employee Emergency Information

        #region Load Grid Data
        private void LoadEmpEmrGridData()
        {
            DataTable dt = new DataTable();
            dt = objEmpEmrBAL.GetEmployeeReferenceInfo();
            //dgvEmployeeInfo.DataSource = dt;
            //dgvEmployeeInfo.Columns["Employee_ID"].Visible = false;
            if (_EmployeeEmergencyCurrentMode == GlobalVariableBO.ModeSelection.UpdateMode)
            {
                dgvEmployeeInfo.DataSource = dt;
                int nRowIndex = RowId;
                dgvEmployeeInfo.Rows[nRowIndex].Selected = true;
                dgvEmployeeInfo.Rows[nRowIndex].Cells[0].Selected = true;

            }
            else
            {
                dgvEmployeeInfo.DataSource = dt;
                DisableAllEmpdocumnentInfo();
                //dgvEmployeeInfo.Columns[1].Visible = false;
                dgvEmployeeInfo.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
             
        }
        #endregion

        #region Employee Emergency Information
        private EmployeeEmergencyBO InitializeEmpEmrInfo()
        {
            EmployeeEmergencyBO empEmrBo = new EmployeeEmergencyBO();
            empEmrBo.Employee_Emr_ID = EmpEmrName.Text;
            empEmrBo.Employee_Emr_Blood_Group = CmbEmrBloddGroup.Text;
            empEmrBo.Employee_Emr_Contact_Person = TxtEmrContPerson.Text;
            empEmrBo.Employee_Emr_Relationship = TxtEmrRelation.Text;
            empEmrBo.Employee_Emr_Contact_Number = txtEmrContNmbr.Text;
            empEmrBo.Employee_Emr_Contact_Address = txtEmrContAddress.Text;
            empEmrBo.Employee_Emr_Insurance_Details = TxtEmrInsurance.Text;
            empEmrBo.Employee_Emr_Special_Instruction = TxtEmrSpecialInstruction.Text;
            empEmrBo.Employee_Emr_Remarks = TxtEmrRemarks.Text;
            return empEmrBo;
        }

        private void ClearEmpEmrInfo()
        {
            CmbEmpEmrId.Text = "";
            CmbEmrBloddGroup.Text = "";
            TxtEmrContPerson.Text = "";
            TxtEmrRelation.Text = "";
            txtEmrContNmbr.Text = "";
            txtEmrContAddress.Text = "";
            TxtEmrInsurance.Text = "";
            TxtEmrSpecialInstruction.Text = "";
            TxtEmrRemarks.Text = "";
            EmpEmrName.Text = "";
        }

        private void EnableEmpEmrInfo()
        {
            CmbEmpEmrId.Enabled = true;
            CmbEmrBloddGroup.Enabled = true;
            TxtEmrContPerson.Enabled = true;
            TxtEmrRelation.Enabled = true;
            txtEmrContNmbr.Enabled = true;
            txtEmrContAddress.Enabled = true;
            TxtEmrInsurance.Enabled = true;
            TxtEmrSpecialInstruction.Enabled = true;
            TxtEmrRemarks.Enabled = true;
        }

        private void DisableEmpEmrInfo()
        {
            CmbEmpEmrId.Enabled = false;
            CmbEmrBloddGroup.Enabled = false;
            TxtEmrContPerson.Enabled = false;
            TxtEmrRelation.Enabled = false;
            txtEmrContNmbr.Enabled = false;
            txtEmrContAddress.Enabled = false;
            TxtEmrInsurance.Enabled = false;
            TxtEmrSpecialInstruction.Enabled = false;
            TxtEmrRemarks.Enabled = false;
        }

        private bool isValidEmpEmrInfo()
        {
            bool result = true;
            if (CmbEmpEmrId.Text.Trim() == "")
            {
                
                MessageBox.Show("Employee Id require");
                result = false;
                CmbEmpEmrId.Focus();
            }
            else if (CmbEmrBloddGroup.Text.Trim() == "")
            {
                MessageBox.Show("Blood group require");
                result = false;
                
                CmbEmrBloddGroup.Focus();
            }
            else if (TxtEmrContPerson.Text.Trim() == "")
            {
                
                MessageBox.Show("Contact Person Require");
                result = false;
                TxtEmrContPerson.Focus();
            }
            else if (TxtEmrRelation.Text.Trim() == "")
            {
              
                MessageBox.Show("Relationship empty");
                result = false;
                TxtEmrRelation.Focus();
            }
            else if (txtEmrContNmbr.Text.Trim() == "")
            {
               
                MessageBox.Show("Contact Number Empty");
                result = false;
                txtEmrContNmbr.Focus();
            }
            else if (txtEmrContAddress.Text.Trim() == "")
            {
                
                MessageBox.Show("Address Field Empty");
                result = false;
                txtEmrContAddress.Focus();
            }
            return result;
        }

        private void InitEmrUpdateButton()
        {
            BtnEmployeeEmergencyNew.Enabled = true;
          //  BtnEmployeeEmergencyUpdate.Enabled = false;            
            DisableEmpEmrInfo();
        }

        private void GetEmployeeId()
        {
            DataTable dt = new DataTable();
            dt = objEmpEmrBAL.GetEmployeeEmrId();
            CmbEmpEmrId.DataSource = dt;
            CmbEmpEmrId.DisplayMember = dt.Columns[1].ToString();
            CmbEmpEmrId.ValueMember = dt.Columns[0].ToString();
        }

        private void BtnEmployeeEmergencyNew_Click(object sender, EventArgs e)
        {
            _EMPID = 0;
            _EmployeeEmergencyCurrentMode = GlobalVariableBO.ModeSelection.NewMode;
            BtnEmployeeEmergencyNew.Enabled = false;
            BtnEmployeeEmergencyNew.BackColor = Color.Gray;
          //  BtnEmployeeEmergencyUpdate.Enabled = true;
            BtnEmployeeEmergencyNew.ResetBackColor();
            ClearEmpEmrInfo();
            EnableEmpEmrInfo();             
            GetEmployeeId();
            GetName();
            BtnEmployeeEmergencySave.Enabled = true ;
            BtnEmployeeEmergencyUpdate.Enabled = false;
        }

        private void BtnEmployeeEmergencyUpdate_Click(object sender, EventArgs e)
        {
            EmployeeEmergencyBO objEmpEmrBo = new EmployeeEmergencyBO();
            try
            {
                objEmpEmrBo = InitializeEmpEmrInfo();
                if (isValidEmpEmrInfo() == true)
                {
                    objEmpEmrBAL.UpdateEmployeeEmergencyInfo(objEmpEmrBo, _EMPID);
                    MessageBox.Show("Update successfully");
                    ClearEmpEmrInfo();
                    DisableEmpEmrInfo();
                    LoadEmpEmrGridData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            
            
            _EmployeeEmergencyCurrentMode = GlobalVariableBO.ModeSelection.UpdateMode;
          //  BtnEmployeeEmergencyUpdate.Enabled = false;
         //   BtnEmployeeEmergencyUpdate.BackColor = Color.Gray;
            BtnEmployeeEmergencyNew.Enabled = true;
            BtnEmployeeEmergencyNew.ResetBackColor();
            ClearEmpEmrInfo();
            DisableEmpEmrInfo();
        }

        private void BtnEmployeeEmergencyReset_Click(object sender, EventArgs e)
        {
            if (_EmployeeEmergencyCurrentMode == GlobalVariableBO.ModeSelection.UpdateMode)
            {
                _EMPID = 0;
                ClearEmpEmrInfo();
                DisableEmpEmrInfo();
            }
            else
            {
                ClearEmpEmrInfo();
                EnableAllEmpReferenceInfo();
            }
        }

        private void BtnEmployeeEmergencySave_Click(object sender, EventArgs e)
        {
            EmployeeEmergencyBO objEmpEmrBo = new EmployeeEmergencyBO();
            switch (_EmployeeEmergencyCurrentMode)
            {
                case GlobalVariableBO.ModeSelection.NewMode:
                    try
                    {
                        objEmpEmrBo = InitializeEmpEmrInfo();
                        if (isValidEmpEmrInfo()==true)
                        {
                            objEmpEmrBAL.SaveEmpEmrInfo(objEmpEmrBo);
                            MessageBox.Show("Saved Successfully");
                            ClearEmpEmrInfo();
                            LoadEmpEmrGridData();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case GlobalVariableBO.ModeSelection.UpdateMode:
                    try
                    {
                        objEmpEmrBo=InitializeEmpEmrInfo();
                        if(isValidEmpEmrInfo()==true)
                        {
                            objEmpEmrBAL.UpdateEmployeeEmergencyInfo(objEmpEmrBo, _EMPID);
                            MessageBox.Show("Update successfully");
                            ClearEmpEmrInfo();
                            DisableEmpEmrInfo();
                            LoadEmpEmrGridData();
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
            }
        }
        private void BtnEmployeeEmergencyClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
         
        #endregion

        #endregion

        #region Employee Payroll Information

        private void LoadAllemployeePayrollInfo()
        {
            DataTable dt = new DataTable();
            dt = objEmpPayrollBAL.LoadallEmployeePayrollInfoGridData();
            //dgvEmployeeInfo.DataSource = dt;
            //dgvEmployeeInfo.Columns["Employee_ID"].Visible = false;
            if (_EmployeePayrollCurrent == GlobalVariableBO.ModeSelection.UpdateMode)
            {
                dgvEmployeeInfo.DataSource = dt;
                int nRowIndex = RowId;
                dgvEmployeeInfo.Rows[nRowIndex].Selected = true;
                dgvEmployeeInfo.Rows[nRowIndex].Cells[0].Selected = true;

            }
            else
            {
                dgvEmployeeInfo.DataSource = dt;
                DisableAllEmpdocumnentInfo();
                //dgvEmployeeInfo.Columns[1].Visible = false;
                dgvEmployeeInfo.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
        }

        private EmployeePayrollBo InitializeEmpPayroolInfo()
        {
            EmployeePayrollBo empBo = new EmployeePayrollBo();
            empBo.Emp_Payroll_ID = empPayrollName.Text;
            empBo.Emp_Payroll_Basic = txtempPayrollBasicAmount.Text;
            empBo.Emp_payroll_House_Rent = txtempHouseRent.Text;
            empBo.Emp_Payroll_Transport = txtempTransPort.Text;
            empBo.Emp_Payroll_Medical_Allowance = txtempPayrollMedical.Text;
            empBo.Emp_Payroll_LFA = txtempPayrollLFA.Text;
            empBo.Emp_Payroll_Gross = txtempPayrollGrossSalary.Text;
            empBo.Emp_Payroll_Provident = txtempPayrollProvinent.Text;
            empBo.Emp_Payroll_Eid = txtempPayrollEidBonus.Text;
            empBo.Emp_Payroll_Other = txtempPayrollOtherAllowance.Text;
            empBo.Emp_Payroll_Remarks = txtemppayrollRemarks.Text;
            empBo.Emp_Payroll_Effective_From =Convert .ToDateTime ( dtpEmpPayrollForm.Value.ToString ("yyyy-MM-dd"));
            empBo.Emp_Payroll_Effictive_To =dtpEmpPayrollTo.Value;
            return empBo;
        }

        private void EnableEmpPayrollInfo()
        {
            cmbEmpPayrollId.Enabled = true;
            txtempPayrollBasicAmount.Enabled=true;
            txtempHouseRent.Enabled=true;
            txtempTransPort.Enabled=true;
            txtempPayrollMedical.Enabled=true;
            txtempPayrollLFA.Enabled=true;
            txtempPayrollGrossSalary.Enabled=true;
            txtempPayrollProvinent.Enabled = true;
            txtempPayrollEidBonus.Enabled = true;
            txtempPayrollOtherAllowance.Enabled = true;
            txtemppayrollRemarks.Enabled = true;
            dtpEmpPayrollForm.Enabled = true;
            dtpEmpPayrollTo.Enabled = true;
        }

        private void DisableEmployeePayrollInfo()
        {
            cmbEmpPayrollId.Enabled = false;
            txtempPayrollBasicAmount.Enabled = false;
            txtempHouseRent.Enabled = false;
            txtempTransPort.Enabled = false;
            txtempPayrollMedical.Enabled = false;
            txtempPayrollLFA.Enabled = false;
            txtempPayrollGrossSalary.Enabled = false;
            txtempPayrollProvinent.Enabled = false;
            txtempPayrollEidBonus.Enabled = false;
            txtempPayrollOtherAllowance.Enabled = false;
            txtemppayrollRemarks.Enabled = false;
            dtpEmpPayrollForm.Enabled = false;
            dtpEmpPayrollTo.Enabled = false;
        }

        private void ClearEmpPayrollInfo()
        {
            cmbEmpPayrollId.Text = "";
            txtempPayrollBasicAmount.Text = "0";
            txtempHouseRent.Text = "0";
            txtempTransPort.Text = "0";
            txtempPayrollMedical.Text = "0";
            txtempPayrollLFA.Text = "0";
            txtempPayrollGrossSalary.Text = "0";
            txtempPayrollProvinent.Text = "0";
            txtempPayrollEidBonus.Text = "0";
            txtempPayrollOtherAllowance.Text = "0";
            txtemppayrollRemarks.Text = "0";
            dtpEmpPayrollForm.ResetText();
            dtpEmpPayrollTo.ResetText();
            empPayrollName.Text = "";
        }

        private bool IsValidEmpPayrollInfo()
        {
            bool result = true;
            
            if (txtempPayrollBasicAmount.Text == "")
            {
                //MessageBox.Show("Basic amount field empty");
                txtempPayrollBasicAmount.Text = "0";
            }
            else if (txtempHouseRent.Text == "")
            {
                //MessageBox.Show("House Rent field Empty");
                txtempHouseRent.Text = "0";
            }

            else if (txtempTransPort.Text == "")
            {
                //MessageBox.Show("TransPort field Empty");
                txtempTransPort.Text = "0";
            }
            else if (txtempPayrollMedical.Text == "")
            {
                //MessageBox.Show("Medical Field empty");
                txtempPayrollMedical.Text = "0";
            }
            else if (txtempPayrollLFA.Text == "")
            {
                //MessageBox.Show("Employee LFA field Empty and only numeric digit are allowed");
                txtempPayrollLFA.Text = "0";
            }

            else if (txtempPayrollGrossSalary.Text == "")
            {
                //MessageBox.Show("Gross Salary Field empty");
                txtempPayrollGrossSalary.Text = "0";
            }
            else if (txtempPayrollProvinent.Text == "")
            {
                //MessageBox.Show("Provident Fund field Empty");
                txtempPayrollProvinent.Text = "0";
            }
            else if (txtempPayrollEidBonus.Text == "")
            {
                //MessageBox.Show("Eid bonus Empty");
                txtempPayrollEidBonus.Text = "0";
            }

            else if (txtempPayrollOtherAllowance.Text == "")
            {
                //MessageBox.Show("Other Allowances is empty");
                txtempPayrollOtherAllowance.Text = "0";
            }
            else if (txtemppayrollRemarks.Text == "")
            {
                //MessageBox.Show("Remarks is Empty");
                txtemppayrollRemarks.Text = "0";
            }
            return result;
        }

        private void InitPayrollUpdateButton()
        {
            BtnEmployeePayrollNew.Enabled = true;
          //  BtnEmployeePayrollUpdate.Enabled = false;
            DisableEmployeePayrollInfo();
        }

        private void BtnEmployeePayrollNew_Click(object sender, EventArgs e)
        {
            _EMPID = 0;
            _EmployeePayrollCurrent = GlobalVariableBO.ModeSelection.NewMode;
            BtnEmployeePayrollNew.Enabled = false;
            BtnEmployeePayrollNew.BackColor = Color.Gray;
         //   BtnEmployeePayrollUpdate.Enabled = true;
          //  BtnEmployeePayrollUpdate.ResetBackColor();
            ClearEmpPayrollInfo();
            EnableEmpPayrollInfo();
            GetEmpPayrolId();
            GetName();
            BtnEmployeePayrollSave.Enabled = true;
            BtnEmployeePayrollUpdate.Enabled = false;
        }

        private void BtnEmployeePayrollUpdate_Click(object sender, EventArgs e)
        {
            EmployeePayrollBo PayrollBo = new EmployeePayrollBo();
            try
            {
                PayrollBo = InitializeEmpPayroolInfo();

                bool effectiveall = checkBox2.Checked  ;

                objEmpPayrollBAL.UpdateEmpPayroll(PayrollBo, _EMPID, effectiveall);
                    MessageBox.Show("Update Successfully");
                    ClearEmpPayrollInfo();
                    DisableEmployeePayrollInfo();
                    LoadAllemployeePayrollInfo();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            
            _EmployeePayrollCurrent = GlobalVariableBO.ModeSelection.UpdateMode;
           // BtnEmployeePayrollUpdate.Enabled = false;
          //  BtnEmployeePayrollUpdate.BackColor = Color.Gray;
            BtnEmployeePayrollNew.Enabled = true;
            BtnEmployeePayrollNew.ResetBackColor();
            ClearEmpPayrollInfo();
            DisableEmployeePayrollInfo();
        }

        private void BtnEmployeePayrollReset_Click(object sender, EventArgs e)
        {
            if (_EmployeePayrollCurrent == GlobalVariableBO.ModeSelection.UpdateMode)
            {
                _EMPID = 0;
                ClearEmpPayrollInfo();
                DisableEmployeePayrollInfo();
            }
            else
            {
                ClearEmpEmrInfo();
                EnableEmpPayrollInfo();
            }
        }

        private void GetEmpPayrolId()
        {
            DataTable dt = new DataTable();
            dt = objEmpPayrollBAL.GetEmployeePayrooID();
            cmbEmpPayrollId.DataSource = dt;
            cmbEmpPayrollId.DisplayMember = dt.Columns[1].ToString();
            cmbEmpPayrollId.ValueMember = dt.Columns[0].ToString();
        }

        private void BtnEmployeePayrollSave_Click(object sender, EventArgs e)
        {
            EmployeePayrollBo PayrollBo = new EmployeePayrollBo();

            DataTable dt = objEmpPayrollBAL.GetEmployeePayrooID_Ext(empPayrollName.Text);
            if (dt.Rows.Count <= 0)
            {
                switch (_EmployeePayrollCurrent)
                {
                    case GlobalVariableBO.ModeSelection.NewMode:
                        try
                        {
                            PayrollBo = InitializeEmpPayroolInfo();
                            if (IsValidEmpPayrollInfo())
                            {
                                objEmpPayrollBAL.Save_Employee_Payroll(PayrollBo);
                                MessageBox.Show("Saved Successfully");
                                ClearEmpPayrollInfo();
                                LoadAllemployeePayrollInfo();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        break;

                }
            }
            else
            {
                MessageBox.Show("Employ ID is Duplicate!! ");
            }
        }

        private void BtnEmployeePayrollClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Emplopyee Brach Map

        #region Load ComboBox
        private void LoadComboBox()
        {
            DataTable dtEmpid = new DataTable();
            dtEmpid = objEmpBranMapBAL.GetEmployeeID();
            cmbemployeeBranid.DataSource = dtEmpid;
            cmbemployeeBranid.DisplayMember = dtEmpid.Columns[0].ToString();
            cmbemployeeBranid.ValueMember = dtEmpid.Columns[0].ToString();
            
            DataTable dtBranchInfo = new DataTable();
            dtBranchInfo = objEmpBranMapBAL.GetBranchNameOrId();
            cmbBranMapId.DataSource = dtBranchInfo;
            cmbBranMapId.DisplayMember = dtBranchInfo.Columns[1].ToString();
            cmbBranMapId.ValueMember = dtBranchInfo.Columns[0].ToString();

            DataTable dtworkStation = new DataTable();
            dtworkStation = objEmpBranMapBAL.GetWorkStationName();
            cmbEmpBranworkstaionName.DataSource = dtworkStation;
            cmbEmpBranworkstaionName.DisplayMember = dtworkStation.Columns[0].ToString();
            cmbEmpBranworkstaionName.ValueMember = dtworkStation.Columns[0].ToString();

            string id = cmbemployeeBranid.SelectedValue.ToString();
         //   EmpBranMapName.Text = objEmpBranMapBAL.GetEmployeeName(id);
            EmpBranMapName.Text = id;
        }        
        private void cmbemployeeBranid_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbemployeeBranid.SelectedIndex == 0)
            {
                string id = cmbemployeeBranid.SelectedValue.ToString();
             //   EmpBranMapName.Text = objEmpBranMapBAL.GetEmployeeName(id);
                EmpBranMapName.Text = id;
            }
            else
            {
                string id = cmbemployeeBranid.SelectedValue.ToString();
               // EmpBranMapName.Text = objEmpBranMapBAL.GetEmployeeName(id);
                EmpBranMapName.Text = id;
            }
        }

        #endregion

        #region Initialize Field Value
        private EmployeeBranchMapBO InitializeAllEmpBranchMapInfo()
        {
            EmployeeBranchMapBO EmpBranBo = new EmployeeBranchMapBO();
            EmpBranBo.Branch_Map_Employee_ID = (cmbemployeeBranid.SelectedValue).ToString();
            if (cmbBranMapId.SelectedValue == null)
            {
                EmpBranBo.Branch_Map_Employee_Brach_ID =objEmpBranMapBAL.GetBranchId(cmbBranMapId.Text);
            }
            else
            {
                EmpBranBo.Branch_Map_Employee_Brach_ID = cmbBranMapId.SelectedValue.ToString();
            }
            EmpBranBo.Branch_Map_Employee_WorkStation_ID = cmbEmpBranworkstaionName.Text;
            EmpBranBo.Branch_Map_Employee_From_Date =Convert.ToDateTime(EmpBranchMapDtpFrom.Value.ToShortDateString());
            EmpBranBo.Branch_Map_Employee_To_Date = Convert.ToDateTime(EmpBranMapdtpTo.Value.ToShortDateString());
            return EmpBranBo;
        }
        private void EnableEmpBranMapInfo()
        {
            cmbemployeeBranid.Enabled = true;
            cmbBranMapId.Enabled = true;
            cmbEmpBranworkstaionName.Enabled = true;
            EmpBranchMapDtpFrom.Enabled = true;
            EmpBranMapdtpTo.Enabled = true;
        }
        private void DisableEmpBranMapInfo()
        {
            cmbemployeeBranid.Enabled = false;
            cmbBranMapId.Enabled = false;
            cmbEmpBranworkstaionName.Enabled = false;
            EmpBranchMapDtpFrom.Enabled = false;
            EmpBranMapdtpTo.Enabled = false;
        }
        private void ClearEmpBranInfo()
        {
            cmbemployeeBranid.Text = "";
            EmpBranMapName.Text = "";
            cmbBranMapId.Text = "";
            cmbEmpBranworkstaionName.Text = "";
            EmpBranchMapDtpFrom.ResetText();
            EmpBranMapdtpTo.ResetText();
        }
        private bool isValidEmpBranMapInfo()
        {
            bool result = true;
            if (cmbemployeeBranid.Text.Trim() == "")
            {
                
                MessageBox.Show("Employee Id Field Empty");
                result = false;
                cmbemployeeBranid.Focus();
            }
            else if (cmbBranMapId.Text.Trim() == "")
            {
               
                MessageBox.Show("Please select your Branch Name");
                result = false;
                cmbBranMapId.Focus();
            }
            else if (cmbEmpBranworkstaionName.Text.Trim() == "")
            {
                MessageBox.Show("Please select your Branch Name");
                result = false;
                cmbEmpBranworkstaionName.Focus();
            }
            return result;
        }
        #endregion

        #region Button Click
        private void BtnEmployeeBranchMappingNew_Click(object sender, EventArgs e)
        {
            _EmployeeBranchCurrent = GlobalVariableBO.ModeSelection.NewMode;
            EnableEmpBranMapInfo();
            //BtnEmployeeBranchMappingUpdate.Enabled = true;
          //  BtnEmployeeBranchMappingUpdate.ResetBackColor();             
            LoadComboBox();
             GetNewEmployeeId();
            BtnEmployeeBranchMappingNew.Enabled = false;
            EnableEmpBranMapInfo();
            cmbEmpBranworkstaionName.SelectedIndex = -1;

            BtnEmployeeBranchMappingSave.Enabled = true ;
            BtnEmployeeBranchMappingUpdate.Enabled = false;
        }

        private void BtnEmployeeBranchMappingUpdate_Click(object sender, EventArgs e)
        {
            EmployeeBranchMapBO empbranbo = new EmployeeBranchMapBO();
            try
            {
                empbranbo = InitializeAllEmpBranchMapInfo();
                if (isValidEmpBranMapInfo())
                {
                    objEmpBranMapBAL.UpdateBranchMapping(empbranbo, _EMPID);
                    MessageBox.Show("Update successfully");
                    ClearEmpBranInfo();
                    LoadEmpBranMapGridData();
                }
                else
                {
                    MessageBox.Show("Please Select a row");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            
            _EmployeeBranchCurrent = GlobalVariableBO.ModeSelection.UpdateMode;            
            BtnEmployeeBranchMappingNew.Enabled = false;
            BtnEmployeeBranchMappingNew.ResetBackColor();
        }
        private void BtnEmployeeBranchMappingReset_Click(object sender, EventArgs e)
        {
            if (_EmployeeBranchCurrent == GlobalVariableBO.ModeSelection.NewMode)
            {
                BtnEmployeeBranchMappingNew.Enabled = false;
                BtnEmployeeBranchMappingNew.ResetBackColor();
               // BtnEmployeeBranchMappingUpdate.Enabled = true;
            }
            else
            {
                BtnEmployeeBranchMappingNew.Enabled = true;
                BtnEmployeeBranchMappingNew.ResetBackColor();
             //   BtnEmployeeBranchMappingUpdate.Enabled = false;
            }
            //BtnEmployeeBranchMappingUpdate.ResetBackColor();
        }
        private void BtnEmployeeBranchMappingSave_Click(object sender, EventArgs e)
        {
            EmployeeBranchMapBO empbranbo = new EmployeeBranchMapBO();
            switch (_EmployeeBranchCurrent)
            {
                case GlobalVariableBO.ModeSelection.NewMode:
                    try{
                        empbranbo = InitializeAllEmpBranchMapInfo();
                        if (isValidEmpBranMapInfo())
                        {
                            objEmpBranMapBAL.SaveBranchMaping(empbranbo);
                            MessageBox.Show("Saved Successfully");
                            ClearEmpBranInfo();
                            LoadEmpBranMapGridData();
                        }
                    }
                    catch(Exception ex)
                    {
                        throw ex;
                    }
                    break;
                case GlobalVariableBO.ModeSelection.UpdateMode:
                    try
                    {
                        empbranbo = InitializeAllEmpBranchMapInfo();
                        if (isValidEmpBranMapInfo())
                        {
                            objEmpBranMapBAL.UpdateBranchMapping(empbranbo, _EMPID);
                            MessageBox.Show("Update successfully");
                            ClearEmpBranInfo();
                            LoadEmpBranMapGridData();
                        }
                        else
                        {
                            MessageBox.Show("Please Select a row");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
            }
        }
        private void BtnEmployeeBranchMappingClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Get New Id
        private void GetNewEmployeeId()
        {
            //string New_Id = objEmpBranMapBAL.GetEmpBranMapId();
            //int ID = int.Parse(New_Id) + 1;
            //return ID.ToString();
            DataTable dt = new DataTable();
            dt = objEmpBranMapBAL.GetEmpBranMapId();
            cmbemployeeBranid.DataSource = dt;

            cmbemployeeBranid.DisplayMember = dt.Columns[1].ToString();
            cmbemployeeBranid.ValueMember = dt.Columns[0].ToString();
        }
        #endregion

        #region Load Grid data
        private void LoadEmpBranMapGridData()
        {
            DataTable dt = new DataTable();
            dt=objEmpBranMapBAL.LoadEmpBranMapGridData();
            if (_EmployeeBranchCurrent == GlobalVariableBO.ModeSelection.UpdateMode)
            {
                dgvEmployeeInfo.DataSource = dt;
                int nRowIndex = RowId;
                dgvEmployeeInfo.Rows[nRowIndex].Selected = true;
                dgvEmployeeInfo.Rows[nRowIndex].Cells[0].Selected = true;
                
            }
            else
            {
                dgvEmployeeInfo.DataSource = dt;
                //dgvEmployeeInfo.Columns[1].Visible = false;
            }
                
        }
        private void InitiateBranMapdata()
        {
            BtnEmployeeBranchMappingNew.Enabled = true;
          // BtnEmployeeBranchMappingUpdate.Enabled = false;            
            DisableEmpBranMapInfo();
        }
        
        #endregion

        #endregion

        #region Employee Document Info

        #region Load Grid Data
        public void LoadEmployeedocumentInfo()
        {
            DataTable dt = new DataTable();
            dt=objEmpDocumentBAL.GetGridData();
            if (_EmployeeDocumentCurrent == GlobalVariableBO.ModeSelection.UpdateMode)
            {
                dgvEmployeeInfo.DataSource = dt;
                int nRowIndex = RowId;
                dgvEmployeeInfo.Rows[nRowIndex].Selected = true;
                dgvEmployeeInfo.Rows[nRowIndex].Cells[0].Selected = true;
                
            }
            else
            {
                dgvEmployeeInfo.DataSource = dt;                 
                DisableAllEmpdocumnentInfo();
                //dgvEmployeeInfo.Columns[1].Visible = false;
                dgvEmployeeInfo.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
        }
        #endregion         

        #region Employee Document Info
        private EmployeeDocumentBo InitializeEmpDocumentInfo()
        {
            EmployeeDocumentBo bo = new EmployeeDocumentBo();
            bo.Employee_Document_ID = EmpDocumentName.Text;
            bo.Employee_Document_Name = txtDocumentName.Text;
            bo.Employee_Document_Type = txtEmpDocumentType.Text;

          if (  txtDocuemtLocation.Text!=string .Empty )
              bo.National_Id_imag = GetImageByte(txtDocuemtLocation.Text);

          if (txtDocuemtLocationIDCord.Text != string.Empty)
          {
              FileStream fStream = File.OpenRead(txtDocuemtLocationIDCord.Text);
              byte[] contents = new byte[fStream.Length];
              fStream.Read(contents, 0, (int)fStream.Length);
              bo.CV_PDF = contents;
          }

            return bo;
        }
        
        private void ClearEmpDocumentInfo()
        {
            cmbEmpDocumentId.Text = "";
            txtDocumentName.Text = "";
            txtEmpDocumentType.Text = "";
            EmpDocumentName.Text = "";             

        }
        private void EnableAllDocumentInfo()
        {
            cmbEmpDocumentId.Enabled = true;
            txtDocumentName.Enabled = true;
            txtEmpDocumentType.Enabled = true;
        }
        private void DisableAllEmpdocumnentInfo()
        {
            cmbEmpDocumentId.Enabled = false;
            txtDocumentName.Enabled = false;
            txtEmpDocumentType.Enabled = false;
        }

        private bool isValidData()
        {
            bool result = true;
            if (txtDocumentName.Text.Trim() == "")
            {
                
                MessageBox.Show("Document Name field Empty");
                result = false;
                txtDocumentName.Focus();
            }
            else if (txtEmpDocumentType.Text.Trim() == "")
            {
                
                MessageBox.Show("Document type field Empty");
                result = false;
                txtEmpDocumentType.Focus();
            }
            //else if (txtDocuemtLocation.Text.Trim() == "")
            //{
            //    MessageBox.Show("Please Select Your Necessary Image");
            //    result = false;
            //}
            //else if (txtDocuemtLocationIDCord.Text.Trim() == "")
            //{
            //    MessageBox.Show("Please Select Your Necessary Image");
            //    result = false;
            //}

            return result;
        }

        private void BtnEmployeeDocumentNew_Click(object sender, EventArgs e)
        {
            _EmployeeDocumentCurrent = GlobalVariableBO.ModeSelection.NewMode;
            BtnEmployeeDocumentNew.Enabled = false;
            BtnEmployeeDocumentNew.ResetBackColor();
            EmpDocumentName.Text = string.Empty;

            txtEmpDocumentType.Text = string.Empty;
            txtDocumentName.Text = string.Empty;
           // BtnEmployeeDocumentUpdate.Enabled = true;
          //  BtnEmployeeDocumentUpdate.ResetBackColor();
            EnableAllDocumentInfo();
            GetEmployeedocumentId();
            cmbEmpDocumentId.SelectedIndex = 0;
            GetName();


            button1.Enabled = true;
            button4.Enabled = false;
            picDocumentImage.Image = null;
            
        }
        
        private void BtnEmployeeDocumentUpdate_Click(object sender, EventArgs e)
        {
            EmployeeDocumentBo EDBO = new EmployeeDocumentBo();
            try
            {
                EDBO = InitializeEmpDocumentInfo();
                if (isValidData())
                {
                    objEmpDocumentBAL.UpdateDocumentInfo(EDBO, _EMPID);
                    MessageBox.Show("Update Successfully");
                    ClearEmpDocumentInfo();
                    LoadEmployeedocumentInfo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            _EmployeeDocumentCurrent = GlobalVariableBO.ModeSelection.UpdateMode;
            BtnEmployeeDocumentNew.Enabled = true;
            BtnEmployeeDocumentNew.ResetBackColor();
           // BtnEmployeeDocumentUpdate.Enabled = false;
          //  BtnEmployeeDocumentUpdate.ResetBackColor();
            DisableAllEmpdocumnentInfo();
             
        }
        private void GetEmployeedocumentId()
        {
            DataTable dt = new DataTable();
            dt=objEmpDocumentBAL.GetEmployeeID();
            cmbEmpDocumentId.DataSource = dt;
            cmbEmpDocumentId.DisplayMember = dt.Columns[1].ToString();
            cmbEmpDocumentId.ValueMember = dt.Columns[0].ToString();
                

        }
        private void InitiateUpdate()
        {
         //   BtnEmployeeDocumentUpdate.Enabled = false;
            BtnEmployeeDocumentNew.Enabled = true;
            DisableAllEmpdocumnentInfo();
        }

        private void BtnEmployeeDocumentSave_Click(object sender, EventArgs e)
        {
            
            DataTable dt = new DataTable();
            dt = objEmpDocumentBAL.GetEmp_Doc_Duplicate(EmpDocumentName.Text);

            if (dt.Rows.Count <= 0)
            {
                EmployeeDocumentBo EDBO = new EmployeeDocumentBo();
                switch (_EmployeeDocumentCurrent)
                {
                    case GlobalVariableBO.ModeSelection.NewMode:
                        try
                        {
                            EDBO = InitializeEmpDocumentInfo();
                            if (isValidData())
                            {
                                objEmpDocumentBAL.SaveEmpDocumentInfo(EDBO);
                                MessageBox.Show("Data save successfully");
                                ClearEmpDocumentInfo();
                                LoadEmployeedocumentInfo();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        break;
                    case GlobalVariableBO.ModeSelection.UpdateMode:
                        try
                        {
                            EDBO = InitializeEmpDocumentInfo();
                            if (isValidData())
                            {
                                objEmpDocumentBAL.UpdateDocumentInfo(EDBO, _EMPID);
                                MessageBox.Show("Update Successfully");
                                ClearEmpDocumentInfo();
                                LoadEmployeedocumentInfo();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        break;
                }
            }
            else
            {
                MessageBox.Show("Employ ID is Duplicate!! ");
            }

        }
        private void BtnEmployeeDocumentClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BtnEmployeeDocumentReset_Click(object sender, EventArgs e)
        {
            if (_EmployeeDocumentCurrent == GlobalVariableBO.ModeSelection.UpdateMode)
            {   
                DisableAllEmpdocumnentInfo();
                ClearEmpDocumentInfo();
            }
            else
            {
                DisableAllEmpdocumnentInfo();
                ClearEmpDocumentInfo();
            }

            picDocumentImage.Image = null;
            
        }
        #endregion

        #endregion

        #region Form Load
        private void HRModule_Load(object sender, EventArgs e)
        {           
            
            LoadEmployeeAllInfo();
            InitiateBasicnAndUpdateButton();            
            //if (CmbBankRouteNo.SelectedIndex == 0)
            //{
                LoadBankInfo();
                LoadBranchInfo();
            //}
                LoadBankRouteInfo();
                LoadSupervisorId();

                dateTimePicker1.Text = DateTime.Now.ToString("MMMMM-yyyy");
                dateTimePicker2.Text = DateTime.Now.ToString("MMMMM-yyyy");




        }
        #endregion  
      
       

        #region Tab selection

        private void TabHrModule_Selecting(object sender, TabControlCancelEventArgs e)
        {
            try
            {
                if(TabHrModule.SelectedTab==TabHrModule.TabPages[0])
                {
                    
                    LoadEmployeeAllInfo();
                    InitiateBasicnAndUpdateButton();
                    
                }                
                else if (TabHrModule.SelectedTab == TabHrModule.TabPages[1])
                {
                    LoadEmpReference();
                    InitUpdateButton();
                }
                else if (TabHrModule.SelectedTab == TabHrModule.TabPages[2])
                {
                    LoadEmpEmrGridData();
                    InitEmrUpdateButton();                   
                }
                else if (TabHrModule.SelectedTab == TabHrModule.TabPages[3])
                {
                    LoadEmpBranMapGridData();
                    DisableEmpBranMapInfo();
                    InitiateBranMapdata();
                }
                else if (TabHrModule.SelectedTab == TabHrModule.TabPages[4])
                {
                    LoadEmployeedocumentInfo();
                    InitiateUpdate();
                    
                }
                else if (TabHrModule.SelectedTab == TabHrModule.TabPages[5])
                {
                    LoadAllemployeePayrollInfo();
                    InitPayrollUpdateButton();                     
                }
                
            }
            catch 
            {
            }
        }
        #endregion

        #region Delete Information
        private void btnEmployeeInfoCancel_Click(object sender, EventArgs e)
        {
            if (TabHrModule.SelectedTab == TabHrModule.TabPages[0])
            {
                if (_EMPID != 0)
                {
                    try
                    {
                        objAdditionalAndBasic.DeleteEmployeeInfo(_EMPID);
                        MessageBox.Show("Deleted successfully");
                        ClearEmployeeAdditionalInfo();
                        ClearEmployeeBasicInfo();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else if (TabHrModule.SelectedTab == TabHrModule.TabPages[1])
            {
                EmployeeReferenceBAL refBal = new EmployeeReferenceBAL();
                if (_EMPID != 0)
                {
                    try
                    {
                        refBal.DelEmprefId(_EMPID);
                        MessageBox.Show("Data Deleted Successfully");
                        ClearAllReferenceinfo();
                        LoadEmpReference();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Please Select an Item to Delete");
                }
                _EMPID = 0;
            }
            else if (TabHrModule.SelectedTab == TabHrModule.TabPages[2])
            {
                if (_EMPID != 0)
                {
                    try
                    {
                        objEmpEmrBAL.DeleteEmpEmrInfo(_EMPID);
                        MessageBox.Show("Delete Successfully");
                        ClearEmpEmrInfo();
                        LoadEmpEmrGridData();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                else
                {
                    MessageBox.Show("Please select an item to delete");
                }
                _EMPID = 0;
            }
            else if (TabHrModule.SelectedTab == TabHrModule.TabPages[3])
            {
                if (_EMPID != 0)
                {
                    try
                    {
                        objEmpBranMapBAL.DeleteEmployeeBranMap(_EMPID);
                        MessageBox.Show("Delete Successfully");
                        ClearEmpBranInfo();
                        LoadEmpBranMapGridData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Please select an item to be deleted");
                }
                _EMPID = 0;
            }
            else if (TabHrModule.SelectedTab == TabHrModule.TabPages[5])
            {
                if (_EMPID != 0)
                {
                    try
                    {
                        objEmpPayrollBAL.DeletePayrollMaster(_EMPID);
                        MessageBox.Show("Deleted Successfully");
                        ClearEmpPayrollInfo();
                        LoadAllemployeePayrollInfo();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Please Select an item for delete");
                }
                _EMPID = 0;
            }

        }
        #endregion

        #region Image
        private byte[] GetImageByte(string fileName)
        {
            if (fileName != "")
            {
                MemoryStream stream = new MemoryStream();
                try
                {
                    Bitmap image = new Bitmap(fileName);
                    image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    image.Dispose();

                    //_length = stream.Length;

                    return stream.ToArray();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Image byte conversion failed. Error:" + ex.Message);
                }

                
            }
            return null;
           
        }

        private MemoryStream GetEmployeeImage(string id)
        {
            MemoryStream ms = null;
            byte[] ImgByteArray = new byte[0];
            ImgByteArray= objAdditionalAndBasic.GetEmployeeImage(id);
            if (ImgByteArray != null)
            ms = new MemoryStream(ImgByteArray);
           
            return ms;
        }

        private MemoryStream GetDocumentImage(string Id)
        {
            MemoryStream ms = null;
            byte[] ImgByteArray = new byte[0];
            ImgByteArray = objEmpDocumentBAL.GetEmployeeDocumentImage(Id);
            if (ImgByteArray != null)
            {
                ms = new MemoryStream(ImgByteArray);
            }
            return ms;
        }
        #endregion

        #region Grid View

        private void dgvEmployeeInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (TabHrModule.SelectedTab == TabHrModule.TabPages[0])
            {
                try
                {

                    btnEmployeeInfoUpdate.Enabled = true;
                     btnIdCheck.Enabled = false;

                   // if (_EmployeeInfoBasicCurrentMode == GlobalVariableBO.ModeSelection.UpdateMode)
                   // {
                        RowId = e.RowIndex;
                        DataGridViewRow dr = dgvEmployeeInfo.CurrentRow;
                        ClearEmployeeBasicInfo();
                        EnableEmployeeBasicInfo();
                        EnableEmployeeAdditionalInfo();

                        _EMPID = int.Parse(dr.Cells["Employee_ID"].Value.ToString());
                        txtEmpNewId.Text = _EMPID.ToString ();

                       

                        cmbempId.Text = _EMPID.ToString();

                        cmbTittle.Text = dr.Cells["Title"].Value.ToString();
                        txtFirstName.Text = dr.Cells["First_Name"].Value.ToString();
                        txtLastName.Text = dr.Cells["Last_Name"].Value.ToString();

                        txtGender.Text = dr.Cells["Gender"].Value.ToString();
                        if (txtGender.Text == "Male")
                        {
                            red_GenderM.Checked = true;
                        }
                        else if (txtGender.Text == "Fmale")
                        {
                            red_Gendr_F.Checked = true;
                        }


                        txtFatherName.Text = dr.Cells["Father_Name"].Value.ToString();
                        txtMtoherName.Text = dr.Cells["Mother_Name"].Value.ToString();

                        txtMaritialStatus.Text = dr.Cells["Marital_Status"].Value.ToString();
                        if (txtMaritialStatus.Text == "Yes")
                        {
                            red_Maritial_Yess.Checked = true;
                        }
                        else if (txtMaritialStatus.Text == "No")
                        {
                            red_Maritial_NO.Checked = true;
                        }

                        CmbDepartment.Text = dr.Cells["Department"].Value.ToString();
                        txtcontact.Text = dr.Cells["Contact_Number"].Value.ToString();
                        txtSecondCont.Text = dr.Cells["Alterate_Contact_Number"].Value.ToString();
                        txtHomePhon.Text = dr.Cells["Home_Phone"].Value.ToString();
                        txEmail.Text = dr.Cells["Email"].Value.ToString();
                        LoadSupervisorId();
                        cmbSupervisorId.Text     = dr.Cells["Supervisor_EmpID"].Value.ToString();

                        txtNationality.Text = dr.Cells["Nationality"].Value.ToString();
                        txtnationalId.Text = dr.Cells["National_ID_No"].Value.ToString();

                        txtpassportNo.Text = dr.Cells["Passport_No"].Value.ToString();
                 

                        txtTin.Text = dr.Cells["TIN"].Value.ToString();
                        cmbbankname.Text = dr.Cells["Bank_Name"].Value.ToString();
                        cmbbranchname.Text = dr.Cells["Bank_Branch"].Value.ToString();
                        txtBankAccountNo.Text = dr.Cells["Bank_Account_No"].Value.ToString();
                        CmbBankRouteNo.Text = dr.Cells["Bank_Routing_No"].Value.ToString();
                        txtPermanetAddr.Text = dr.Cells["Permanent_Address"].Value.ToString();
                        txtPresentAddr.Text = dr.Cells["Present_Address"].Value.ToString();

                        //dtpJoin.Value = Convert.ToDateTime(dr.Cells["Date_Of_Joining"].Value.ToString());
                        if (Convert.ToString(dr.Cells["Date_Of_Joining"].Value) != string.Empty)
                        {
                            dtpJoin.Value = Convert.ToDateTime(dr.Cells["Date_Of_Joining"].Value.ToString());                            
                            //dtpJoin.Value = Convert.ToDateTime("1930-01-01");
                        }
                        else
                        {
                            //dtpJoin.Format = DateTimePickerFormat.Custom;
                            dtpJoin.CustomFormat = " ";
                            
                        }
                        if (Convert.ToString(dr.Cells["Date_Of_Discharge"].Value) != string.Empty)
                        {
                            dtpDischarge.Value = Convert.ToDateTime(dr.Cells["Date_Of_Discharge"].Value.ToString());

                        }
                        else
                        {
                          // dtpDischarge.Format = DateTimePickerFormat.Custom;
                            //dtpDischarge.CustomFormat = " ";
                            dtpDischarge.Value = Convert.ToDateTime("1930-01-01");
                        }
                        if (Convert.ToString(dr.Cells["Date_of_Birth"].Value) != string.Empty)
                        {
                            //dtpDateofBirth.Value = Convert.ToDateTime("1930-01-01");                            
                            dtpDateofBirth.Value = Convert.ToDateTime(dr.Cells["Date_of_Birth"].Value.ToString());
                        }
                        else
                        {
                            //dtpDateofBirth.Format = DateTimePickerFormat.Custom;
                            dtpDateofBirth.CustomFormat = " ";
                        }

                        EmployeeBasicInfoBAL EmpClass = new EmployeeBasicInfoBAL();
                       
                        //DataTable dti = EmpClass.Get_EmpImage(_EMPID.ToString());
                        //MemoryStream st = GetEmployeeImage(Convert.ToString(_EMPID));
                        //picPhoto.Image = Image.FromStream(st);

                          //dtpUpdate.Value = Convert.ToDateTime(dr.Cells["Update_Date"].Value.ToString());
                        MemoryStream st = GetEmployeeImage(Convert.ToString(_EMPID));
                       picPhoto.Image = null;

                        if (st != null)
                        {

                          
                            picPhoto.Image = Image.FromStream(st);
                           // picPhoto.Image = Image.FromStream(GetEmployeeImage(Convert.ToString(_EMPID)));
                        }
                        else
                        {
                            picPhoto.Image = null;
                        }

                        txtEmpNewId.Enabled = false;
                        //picPhoto.Image =Image.FromStream(GetEmployeeImage(Convert.ToString(_EMPID)));
                   // }

                        btnIdCheck.Enabled = false;
                        btnEmployeeInfoSave.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (TabHrModule.SelectedTab == TabHrModule.TabPages[1])
            {
                try
                {
                    //if (_EmployeeReferenceCurrentMode == GlobalVariableBO.ModeSelection.UpdateMode)
                    //{                        
                        RowId = e.RowIndex;
                        DataGridViewRow dt = dgvEmployeeInfo.CurrentRow;
                        EnableAllEmpReferenceInfo();
                        _EMPID = int.Parse(dt.Cells[1].Value.ToString());
                        CmbrefEmployeeid.Text  = dt.Cells["Name"].Value.ToString();
                        EmpRefName.Text = _EMPID.ToString();
                        txtrefName.Text = dt.Cells["Reference_Name"].Value.ToString();
                        txtRefProfession.Text = dt.Cells["Reference_Profession"].Value.ToString();
                        
                        txtRefPhone.Text = dt.Cells["Reference_Phone"].Value.ToString();
                        txtRefEmail.Text = dt.Cells["Reference_Email"].Value.ToString();
                        txtrefaddress.Text = dt.Cells["Reference_Address"].Value.ToString();

                        btnEmployeeReferenceUpdate.Enabled = true;
                        btnEmployeeReferenceSave.Enabled = false;
                   // }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (TabHrModule.SelectedTab == TabHrModule.TabPages[2])
            {
                try
                {
                   // if (_EmployeeEmergencyCurrentMode == GlobalVariableBO.ModeSelection.UpdateMode)
                 //   {
                        RowId = e.RowIndex;
                        DataGridViewRow dt = dgvEmployeeInfo.CurrentRow;
                        EnableEmpEmrInfo();
                        _EMPID = int.Parse(dt.Cells["Employee_ID"].Value.ToString());
                        CmbEmpEmrId.SelectedText  = dt.Cells[0].Value.ToString();
                        EmpEmrName.Text =  _EMPID.ToString();


                        CmbEmrBloddGroup.Text = dt.Cells["Blood_Group"].Value.ToString();
                        TxtEmrContPerson.Text = dt.Cells["Emergency_Contact_Person"].Value.ToString();
                        TxtEmrRelation.Text = dt.Cells["RelationShip"].Value.ToString();
                        txtEmrContNmbr.Text = dt.Cells["Contact_Number"].Value.ToString();
                        txtEmrContAddress.Text = dt.Cells["Contact_Address"].Value.ToString();
                        TxtEmrInsurance.Text = dt.Cells["Insurance_Details"].Value.ToString();
                        TxtEmrSpecialInstruction.Text = dt.Cells["Special_Instruction"].Value.ToString();
                        TxtEmrRemarks.Text = dt.Cells["Remarks"].Value.ToString();
                  //  }

                        BtnEmployeeEmergencySave.Enabled = false;
                        BtnEmployeeEmergencyUpdate.Enabled = true;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (TabHrModule.SelectedTab == TabHrModule.TabPages[3])
            {
                try
                {
                    //if (_EmployeeBranchCurrent == GlobalVariableBO.ModeSelection.UpdateMode)
                    //{
                        RowId = e.RowIndex;
                        DataGridViewRow dr = dgvEmployeeInfo.CurrentRow;
                        EnableEmpBranMapInfo();
                        _EMPID = int.Parse(dr.Cells["Employee_ID"].Value.ToString());
                        cmbemployeeBranid.Text = dr.Cells["Name"].Value.ToString();
                        EmpBranMapName.Text = _EMPID.ToString();
                        cmbBranMapId.Text = dr.Cells[2].Value.ToString();
                        cmbEmpBranworkstaionName.Text = dr.Cells["Workstation_ID"].Value.ToString();
                        if (Convert.ToString(dr.Cells["Effective_To_Date"].Value) != string.Empty)
                        {
                            EmpBranMapdtpTo.Value = Convert.ToDateTime(dr.Cells["Effective_To_Date"].Value.ToString());
                        }
                        else
                        {
                            EmpBranMapdtpTo.Value = Convert.ToDateTime("1930-01-01");

                        }
                        if (Convert.ToString(dr.Cells["Effective_From_Date"].Value) != string.Empty)
                        {
                            EmpBranchMapDtpFrom.Value = Convert.ToDateTime(dr.Cells["Effective_From_Date"].Value.ToString());
                        }
                        else
                        {
                            EmpBranchMapDtpFrom.Value = Convert.ToDateTime("1930-01-01");
                        }
                   // }

                        BtnEmployeeBranchMappingSave.Enabled = false;
                        BtnEmployeeBranchMappingUpdate.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (TabHrModule.SelectedTab == TabHrModule.TabPages[4])
            {
                try
                {
                    //if (_EmployeeDocumentCurrent == GlobalVariableBO.ModeSelection.UpdateMode)
                    //{
                        RowId = e.RowIndex;
                        DataGridViewRow dr = dgvEmployeeInfo.CurrentRow;
                        EnableAllDocumentInfo();
                        _EMPID = int.Parse(dr.Cells["Employee_ID"].Value.ToString());
                        cmbEmpDocumentId.Text = dr.Cells["Employee_Name"].Value.ToString();
                        EmpDocumentName.Text = _EMPID.ToString();
                        txtEmpDocumentType.Text = dr.Cells["Document_Type"].Value.ToString();
                        txtDocumentName.Text = dr.Cells["Document_Name"].Value.ToString();


                        picDocumentImage.Image = null;
                        MemoryStream st = GetDocumentImage(Convert.ToString(_EMPID));
                        if (st != null)
                        {
                            picDocumentImage.Image = Image.FromStream(st);
                            
                        }
                        else
                        {
                            picDocumentImage.Image = null;
                        }

                        button1.Enabled = false;
                        button4.Enabled = true;
                       
                   // }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (TabHrModule.SelectedTab == TabHrModule.TabPages[5])
            {
                try
                {
                    //if (_EmployeePayrollCurrent == GlobalVariableBO.ModeSelection.UpdateMode)
                    //{
                        RowId = e.RowIndex;
                        DataGridViewRow dt = dgvEmployeeInfo.CurrentRow;
                        EnableEmpPayrollInfo();
                        _EMPID = int.Parse(dt.Cells["Employee_ID"].Value.ToString());
                        cmbEmpPayrollId.Text = dt.Cells[0].Value.ToString();
                        empPayrollName.Text=_EMPID.ToString();
                        txtempPayrollBasicAmount.Text = dt.Cells[2].Value.ToString();
                        txtempHouseRent.Text = dt.Cells["House_Rent_Amount"].Value.ToString();
                        txtempTransPort.Text = dt.Cells["Transport_Allownce"].Value.ToString();
                        txtempPayrollMedical.Text = dt.Cells["Medical_Allownce"].Value.ToString();
                        txtempPayrollLFA.Text = dt.Cells["LFA_Allownce"].Value.ToString();
                        txtempPayrollGrossSalary.Text = dt.Cells["Gross_Salary"].Value.ToString();
                        txtempPayrollProvinent.Text = dt.Cells["Provident_Fund"].Value.ToString();
                        txtempPayrollEidBonus.Text = dt.Cells["Eid_Bonus"].Value.ToString();
                        txtempPayrollOtherAllowance.Text = dt.Cells["Other_Allownce"].Value.ToString();
                        txtemppayrollRemarks.Text = dt.Cells["Remarks"].Value.ToString();
                        if (Convert.ToString(dt.Cells["Effective_From"].Value) != string.Empty)
                        {
                            dtpEmpPayrollForm.Value = Convert.ToDateTime(dt.Cells["Effective_From"].Value.ToString());
                        }
                        else
                        {
                            dtpEmpPayrollForm.Value = Convert.ToDateTime("1930-01-01");
                        }
                        if (Convert.ToString(dt.Cells["Effective_To"].Value) != string.Empty)
                        {
                            dtpEmpPayrollTo.Value = Convert.ToDateTime(dt.Cells["Effective_To"].Value.ToString());
                        }
                        else
                        {
                            dtpEmpPayrollTo.Value = Convert.ToDateTime("1930-01-01");
                        }
                    //}

                        BtnEmployeePayrollSave.Enabled = false;
                        BtnEmployeePayrollUpdate.Enabled = true;
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }
        #endregion

        private void dgvEmployeeInfo_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Error happened " + e.Context.ToString());

            if (e.Context == DataGridViewDataErrorContexts.Commit)
            {
                MessageBox.Show("Commit error");
            }
            if (e.Context == DataGridViewDataErrorContexts.CurrentCellChange)
            {
                MessageBox.Show("Cell change");
            }
            if (e.Context == DataGridViewDataErrorContexts.Parsing)
            {
                MessageBox.Show("parsing error");
            }
            if (e.Context == DataGridViewDataErrorContexts.LeaveControl)
            {
                MessageBox.Show("leave control error");
            }

            if ((e.Exception) is ConstraintException)
            {
                DataGridView view = (DataGridView)sender;
                view.Rows[e.RowIndex].ErrorText = "an error";
                view.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "an error";
                e.ThrowException = false;
            }
        }

        private void TabHrModule_SelectedIndexChanged(object sender, EventArgs e)
        {

        }        
        
        #region Allow Numeric Digit
        private void txtHomePhon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)&&e.KeyChar!='+')
            {
                e.Handled = true;
            }
        
        }

        private void txtContactNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '+')
            {
                e.Handled = true;
            }
        }

        private void txtalterContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '+')
            {
                e.Handled = true;
            }
        }

        private void txtEmrContNmbr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '+')
            {
                e.Handled = true;
            }
        }

        private void txtempPayrollEidBonus_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txtempPayrollMedical_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txtempPayrollProvinent_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txtempPayrollBasicAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txtempPayrollGrossSalary_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txtempHouseRent_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txtempTransPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }
        private void txtRefPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '+')
            {
                e.Handled = true;
            }
        }
        #endregion

        private void BtnEmployeeEmergencyClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Browse Image
        private void btnImgBrowse_Click(object sender, EventArgs e)
        {
            if (ofdImageBrowse.ShowDialog() != DialogResult.Cancel)
            {
                txtImgLocation.Text = ofdImageBrowse.FileName;
                picPhoto.Image = Image.FromFile(txtImgLocation.Text);
                btnStartUpload.Enabled = true;
            }
        }
        

        private void btndocumentImageBrowse_Click(object sender, EventArgs e)
        {
            if (ofdImageBrowse.ShowDialog() != DialogResult.Cancel)
            {
                txtDocuemtLocation.Text = ofdImageBrowse.FileName;
                picDocumentImage.Image = Image.FromFile(txtDocuemtLocation.Text);
                btnStartDocumentUpload.Enabled = true;
            }
        }
        


        #endregion

        private void btnStartDocumentUpload_Click(object sender, EventArgs e)
        {
            if (cmbEmpDocumentId.Text==string.Empty)
            {
                MessageBox.Show("Employee Id is required.", "Image Upload", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbEmpDocumentId.Focus();
                return;
            }
            if (txtDocuemtLocation.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Imasge File Path Required to upload Image.", "Image Upload", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btndocumentImageBrowse.Focus();
                return;
            }
            EmployeeDocumentBo bo = new EmployeeDocumentBo();
            bo.National_Id_imag = GetImageByte(ofdImageBrowse.FileName);
            
        }
    
        private void button6_Click(object sender, EventArgs e)
        {
            Frm_Emp_CV_View frm = new Frm_Emp_CV_View();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void btn_CVPDF_Find_Click(object sender, EventArgs e)
        {

            OpenFileDialog dlg = new OpenFileDialog();
            // set file filter of dialog 
            dlg.Filter = "pdf files (*.pdf) |*.pdf;";
            dlg.ShowDialog();
            if (dlg.FileName != null)
            {
                txtDocuemtLocationIDCord.Text = dlg.FileName;               

                FileStream fStream = File.OpenRead(txtDocuemtLocationIDCord.Text);
                byte[] contents = new byte[fStream.Length];
                fStream.Read(contents, 0, (int)fStream.Length);
                axAcroPDF1.src = txtDocuemtLocationIDCord.Text;
            }
           
        }

        private void btn_CVPDF_DocUpload_Click(object sender, EventArgs e)
        {
            if (cmbEmpDocumentId.Text == string.Empty)
            {
                MessageBox.Show("Employee Id is required.", "Image Upload", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbEmpDocumentId.Focus();
                return;
            }
            if (txtDocuemtLocationIDCord.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Imasge File Path Required to upload Image.", "Image Upload", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btndocumentImageBrowse.Focus();
                return;
            }
            EmployeeDocumentBo bo = new EmployeeDocumentBo();
            bo.CV_PDF = GetImageByte(ofdImageBrowse.FileName);
        }

        private void groupBox23_Enter(object sender, EventArgs e)
        {

        }

        private void tabEmployeeDocument_Click(object sender, EventArgs e)
        {

        }

        private void picPhoto_Click(object sender, EventArgs e)
        {

            frm_Hr_EmpImageView frm = new frm_Hr_EmpImageView();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.EmpImage = picPhoto.Image;
            frm.Show();
        }

        private void btn_Salari_Click(object sender, EventArgs e)
        {            
            Frm_CryRpt_Display CryRpt_Display = new Frm_CryRpt_Display();
           
            Emp_SalaryLetter rpt = new Emp_SalaryLetter();

            string RptFormula = "{V_Emp_Payroll_WithAccNO.Effective_Month}='" + dateTimePicker1.Value.ToString("MM") + "' ";
        
            CryRpt_Display.ShowDialog(rpt, RptFormula);

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Frm_CryRpt_Display CryRpt_Display = new Frm_CryRpt_Display();

            HR_SalarySheet rpt = new HR_SalarySheet();
            
            string RptFormula =" {V_hr_emp_salarySheet.Effective_Month}='" + dateTimePicker2.Value.ToString("MM")+"'  ";

            CryRpt_Display.ShowDialog(rpt, RptFormula);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                dtpDischarge.Enabled = true;
                EmpStatus = "Inactive";
            }
            else
                dtpDischarge.Enabled = false;          
                EmpStatus = "Active";

        }

        private void CmbrefEmployeeid_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (CmbrefEmployeeid.SelectedIndex >= 0)
            {
                id = CmbrefEmployeeid.SelectedValue.ToString();
                //   EmpRefName.Text = objEmpBranMapBAL.GetEmployeeName(id);
                EmpRefName.Text = id;

            }
        }

        private void CmbEmpEmrId_SelectionChangeCommitted(object sender, EventArgs e)
        {
            id = CmbEmpEmrId.SelectedValue.ToString();
            //  EmpEmrName.Text = objEmpBranMapBAL.GetEmployeeName(id);
            EmpEmrName.Text = id;
        }

        private void cmbEmpDocumentId_SelectionChangeCommitted(object sender, EventArgs e)
        {
            id = cmbEmpDocumentId.SelectedValue.ToString();
            // EmpDocumentName.Text = objEmpBranMapBAL.GetEmployeeName(id);
            EmpDocumentName.Text = id;
        }

        private void cmbEmpPayrollId_SelectionChangeCommitted(object sender, EventArgs e)
        {
            id = cmbEmpPayrollId.SelectedValue.ToString();
            // empPayrollName.Text = objEmpBranMapBAL.GetEmployeeName(id);
            empPayrollName.Text = id;
        }

        private void picDocumentImage_Click(object sender, EventArgs e)
        {
            frm_Hr_EmpImageView frm = new frm_Hr_EmpImageView();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.EmpImage = picDocumentImage.Image;
            frm.Show();
        }


    

       

    }
}
