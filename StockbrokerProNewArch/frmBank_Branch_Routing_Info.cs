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
    public partial class frmBank_Branch_Routing_Info : Form
    {
        private GlobalVariableBO.ModeSelection _bankInfocurrentMode = GlobalVariableBO.ModeSelection.NewMode;
        private GlobalVariableBO.ModeSelection _branchInfocurrentMode = GlobalVariableBO.ModeSelection.NewMode;
        private GlobalVariableBO.ModeSelection _districtInfocurrentMode = GlobalVariableBO.ModeSelection.NewMode;
        private GlobalVariableBO.ModeSelection _thanaInfocurrentMode = GlobalVariableBO.ModeSelection.NewMode;
        private GlobalVariableBO.ModeSelection _bankbranchroutingInfocurrentMode = GlobalVariableBO.ModeSelection.NewMode;

        public frmBank_Branch_Routing_Info()
        {
            InitializeComponent();
        }

        #region Global Variable
        private int _bankId;
        private int _branchId;
        private int _districtId;
        private int _thanaId;

        private string _bankCode;
        private string _branchCode;
        private string _districtCode;
        private string _thanaCode;
        private int _bankBranchRoutingId;
        private string _bankName;
        private string _branchName;
        private string _thanaName;
        private string _districtName;
        #endregion Global Variable

        #region Bank Info
        private Bank_NameBO InitializeBankInfoBO()
        {
            Bank_NameBO objBO = new Bank_NameBO();
            objBO.Bank_Code = txtBankCode.Text;
            objBO.BankName = txtBankName.Text;
            objBO.Description = txtDescription.Text;
            return objBO;
        }
        private void ClearAllBankInfo()
        {
            EnableAllBankInfo();
            txtBankCode.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtBankName.Text = string.Empty;
        }
        private void EnableAllBankInfo()
        {
            txtBankCode.Enabled = true;
            txtDescription.Enabled = true;
            txtBankName.Enabled = true;
        }
        private void DisableAllBankInfo()
        {
            txtBankCode.Enabled = false;
            txtDescription.Enabled = false;
            txtBankName.Enabled = false;
        }
        private bool IsValidBankInfoInputData()
        {
            bool result = true;
            if (txtBankCode.Text == "")
            {
                result = false;
                throw new Exception("Bank Code Required");
            }
            else if (txtBankName.Text == "")
            {
                result = false;
                throw new Exception("Bank Name Required");
            }

            return result;
        }

        private void LoadBankInfoGridData()
        {
            DataTable dtgrid = new DataTable();
            Bank_NameBAL objBAL = new Bank_NameBAL();
            dtgrid = objBAL.GetGridData();
            dgvBankInfo.DataSource = dtgrid;
            dgvBankInfo.Columns[0].Visible=false;
            dgvBankInfo.Columns[1].DefaultCellStyle.Format = "D3";
            dgvBankInfo.Columns[4].DefaultCellStyle.Format = "dd-MM-yyyy";
        }

        private void btnBankInfoNew_Click(object sender, EventArgs e)
        {
            _bankId = 0;
            _bankInfocurrentMode = GlobalVariableBO.ModeSelection.NewMode;
            btnBankInfoNew.Enabled = false;
            btnBankInfoNew.BackColor = Color.Gray;
            btnBankInfoUpdate.Enabled = true;
            btnBankInfoUpdate.ResetBackColor();
            ClearAllBankInfo();
        }
        private void btnBankInfoUpdate_Click(object sender, EventArgs e)
        {
            _bankInfocurrentMode = GlobalVariableBO.ModeSelection.UpdateMode;
            btnBankInfoUpdate.Enabled = false;
            btnBankInfoUpdate.BackColor = Color.Gray;
            btnBankInfoNew.Enabled = true;
            btnBankInfoNew.ResetBackColor();
            ClearAllBankInfo();
            DisableAllBankInfo();
        }
        private void btnBankInfoReset_Click(object sender, EventArgs e)
        {
            if (_bankInfocurrentMode == GlobalVariableBO.ModeSelection.UpdateMode)
            {
                _bankId = 0;
                ClearAllBankInfo();
                DisableAllBankInfo();
            }
            else
            {
                ClearAllBankInfo();
                EnableAllBankInfo();
            }
        }
        private void btnSaveBankInfo_Click(object sender, EventArgs e)
        {
            Bank_NameBO objBO = new Bank_NameBO();
            Bank_NameBAL objBAL = new Bank_NameBAL();
            switch (_bankInfocurrentMode)
            {
                case GlobalVariableBO.ModeSelection.NewMode:
                    try
                    {
                        objBO = InitializeBankInfoBO();
                        if (IsValidBankInfoInputData())
                        {
                            objBAL.SaveBankName(objBO);
                            MessageBox.Show(@"Data Saved Successfully");
                            ClearAllBankInfo();
                            LoadBankInfoGridData();
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
                            objBO = InitializeBankInfoBO();
                            if (IsValidBankInfoInputData())
                            {
                                objBAL.UpdateBankInfo(objBO,_bankId);
                                MessageBox.Show("Update Bank Info Successfully");
                                ClearAllBankInfo();
                                LoadBankInfoGridData();
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
            btnBankInfoNew.Enabled = false;
        }
        private void frmBank_Info_Load(object sender, EventArgs e)
        {
            try
            {
                LoadBankInfoGridData();
                InitUpdateButton();
            }
            catch
            {
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Bank_NameBAL objBAL = new Bank_NameBAL();
            if (_bankId != 0)
            {
                try
                {
                    objBAL.DeletebBankName(_bankId);
                    MessageBox.Show(@"Data Deleted Successfully");
                    ClearAllBankInfo();
                    LoadBankInfoGridData();
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
            _bankId = 0;

        }

        private void dgvBankInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_bankInfocurrentMode == GlobalVariableBO.ModeSelection.UpdateMode)
            {

                try
                {
                    DataGridViewRow dr = dgvBankInfo.CurrentRow;
                    EnableAllBankInfo();
                    _bankId = 0;
                    _bankId = Int32.Parse(dr.Cells[0].Value.ToString());
                    txtBankCode.Text= dr.Cells["Bank_Code"].Value.ToString();
                    txtBankName.Text=dr.Cells["Bank_Name"].Value.ToString();
                    txtDescription.Text=dr.Cells["Description"].Value.ToString();
                }
                catch
                {
                    _bankId = 0;
                }
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void dgvBankInfo_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                dgvBankInfo.Rows[0].Selected = false;
            }
            catch
            {

            }

        }
        #endregion Bank Info

        #region Branch Info

        private Branch_NameBO InitializeBranchInfoBO()
        {
            Branch_NameBO objBO = new Branch_NameBO();
            objBO.Branch_Code = txtBranchCode.Text;
            objBO.BranchName = txtBranchName.Text;
            objBO.Description = txtBranchDescription.Text;
            return objBO;
        }
        private void ClearAllBranchInfo()
        {
            EnableAllBranchInfo();
            txtBranchCode.Text = string.Empty;
            txtBranchDescription.Text = string.Empty;
            txtBranchName.Text = string.Empty;
        }
        private void EnableAllBranchInfo()
        {
            txtBranchCode.Enabled = true;
            txtBranchDescription.Enabled = true;
            txtBranchName.Enabled = true;
        }
        private void DisableAllBranchInfo()
        {
            txtBranchCode.Enabled = false;
            txtBranchDescription.Enabled = false;
            txtBranchName.Enabled = false;
        }
        private bool IsValidBranchInfoInputData()
        {
            bool result = true;
            if (txtBranchCode.Text == "")
            {
                throw new Exception("Branch Code Required");
            }
            else if (txtBranchName.Text == "")
            {
                throw new Exception("Branch Name Required");
            }

            return result;
        }

        private void LoadBranchInfoGridData()
        {
            DataTable dtgrid = new DataTable();
            Branch_NameBAL objBAL = new Branch_NameBAL();
            dtgrid = objBAL.GetGridData();
            dgvBranchInfo.DataSource = dtgrid;
            dgvBranchInfo.Columns[0].Visible = false;
            dgvBranchInfo.Columns[1].DefaultCellStyle.Format = "D3";
            dgvBranchInfo.Columns[4].DefaultCellStyle.Format = "dd-MM-yyyy";
        }
        private void btnBranchInfoNew_Click(object sender, EventArgs e)
        {
            _branchId = 0;
            _branchInfocurrentMode = GlobalVariableBO.ModeSelection.NewMode;
            btnBranchInfoNew.Enabled = false;
            btnBranchInfoNew.BackColor = Color.Gray;
            btnBranchInfoUpdate.Enabled = true;
            btnBranchInfoUpdate.ResetBackColor();
            ClearAllBranchInfo();
        }
        

        private void btnBranchInfoUpdate_Click(object sender, EventArgs e)
        {
            _branchInfocurrentMode = GlobalVariableBO.ModeSelection.UpdateMode;
            btnBranchInfoUpdate.Enabled = false;
            btnBranchInfoUpdate.BackColor = Color.Gray;
            btnBranchInfoNew.Enabled = true;
            btnBranchInfoNew.ResetBackColor();
            ClearAllBranchInfo();
            DisableAllBranchInfo();

        }

        private void btnBranchInfoReset_Click(object sender, EventArgs e)
        {
            if (_branchInfocurrentMode == GlobalVariableBO.ModeSelection.UpdateMode)
            {
                _branchId = 0;
                ClearAllBranchInfo();
                DisableAllBranchInfo();
            }
            else
            {
                ClearAllBranchInfo();
                EnableAllBranchInfo();
            }
        }

        private void btnBranchSave_Click(object sender, EventArgs e)
        {
            Branch_NameBO objBO = new Branch_NameBO();
            Branch_NameBAL objBAL = new Branch_NameBAL();
            switch (_branchInfocurrentMode)
            {
                case GlobalVariableBO.ModeSelection.NewMode:
                    try
                    {
                        objBO = InitializeBranchInfoBO();
                        if (IsValidBranchInfoInputData())
                        {
                            objBAL.SaveBranchName(objBO);
                            MessageBox.Show(@"Data Saved Successfully");
                            ClearAllBranchInfo();
                            LoadBranchInfoGridData();
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
                        objBO = InitializeBranchInfoBO();
                        if (IsValidBranchInfoInputData())
                        {
                            objBAL.UpdateBranchInfo(objBO,_branchId);
                            MessageBox.Show(@"Branch Info Updated Successfully");
                            ClearAllBranchInfo();
                            LoadBranchInfoGridData();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
            }

        }

        private void btnBranchClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBranchDelete_Click(object sender, EventArgs e)
        {
            Branch_NameBAL objBAL = new Branch_NameBAL();
            if (_branchId != 0)
            {
                try
                {
                    objBAL.DeletebBranchName(_branchId);
                    MessageBox.Show(@"Data Deleted Successfully");
                    ClearAllBranchInfo();
                    LoadBranchInfoGridData();
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
            _branchId = 0;
        }
        private void dgvBranchInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_branchInfocurrentMode == GlobalVariableBO.ModeSelection.UpdateMode)
            {

                try
                {
                    DataGridViewRow dr = dgvBranchInfo.CurrentRow;
                    EnableAllBranchInfo();
                    _branchId = 0;
                    _branchId = Int32.Parse(dr.Cells[0].Value.ToString());
                    txtBranchCode.Text = dr.Cells["Branch_Code"].Value.ToString();
                    txtBranchName.Text = dr.Cells["Branch_Name"].Value.ToString();
                    txtBranchDescription.Text = dr.Cells["Description"].Value.ToString();
                }
                catch
                {
                    _branchId = 0;
                }
            }
        }
        private void dgvBranchInfo_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                dgvBranchInfo.Rows[0].Selected = false;
            }
            catch
            {

            }

        }
        #endregion Branch Info

        #region District Info
        private District_NameBO InitializeDistrictInfoBO()
        {
            District_NameBO objBO = new District_NameBO();
            objBO.District_Code = txtDistrictCode.Text;
            objBO.DistrictName = txtDistrictName.Text;
            objBO.District_Description = txtDistrictDescription.Text;
            return objBO;
        }
        private void ClearAllDistrictInfo()
        {
            EnableAllDistrictInfo();
            txtDistrictCode.Text = string.Empty;
            txtDistrictDescription.Text = string.Empty;
            txtDistrictName.Text = string.Empty;
        }

        private void EnableAllDistrictInfo()
        {
            txtDistrictCode.Enabled = true;
            txtDistrictDescription.Enabled = true;
            txtDistrictName.Enabled = true;
        }
        private void DisableAllDistrictInfo()
        {
            txtDistrictCode.Enabled = false;
            txtDistrictDescription.Enabled = false;
            txtDistrictName.Enabled = false;
        }
        private bool IsValidDistrictInfoInputData()
        {
            bool result = true;
            if (txtDistrictCode.Text == "")
            {
                throw new Exception("District ID Required");
            }
            else if (txtDistrictName.Text == "")
            {
                throw new Exception("District Name Required");
            }

            return result;
        }

        private void LoadDistrictInfoGridData()
        {
            DataTable dtgrid = new DataTable();
            District_NameBAL objBAL = new District_NameBAL();
            dtgrid = objBAL.GetGridData();
            dgvDistrictInfo.DataSource = dtgrid;
            dgvDistrictInfo.Columns[0].Visible = false;
            dgvDistrictInfo.Columns[1].DefaultCellStyle.Format = "D3";
            dgvDistrictInfo.Columns[4].DefaultCellStyle.Format = "dd-MM-yyyy";
        }
        private void btnDistrictInfoNew_Click(object sender, EventArgs e)
        {
            _districtId = 0;
            _districtInfocurrentMode = GlobalVariableBO.ModeSelection.NewMode;
            btnDistrictInfoNew.Enabled = false;
            btnDistrictInfoNew.BackColor = Color.Gray;
            btnDistrictInfoUpdate.Enabled = true;
            btnDistrictInfoUpdate.ResetBackColor();
            ClearAllDistrictInfo();
        }
       
        private void btnDistrictInfoUpdate_Click(object sender, EventArgs e)
        {
            _districtInfocurrentMode = GlobalVariableBO.ModeSelection.UpdateMode;
            btnDistrictInfoUpdate.Enabled = false;
            btnDistrictInfoUpdate.BackColor = Color.Gray;
            btnDistrictInfoNew.Enabled = true;
            btnDistrictInfoNew.ResetBackColor();
            ClearAllDistrictInfo();
            DisableAllDistrictInfo();
        }

        private void btnDistrictInfoReset_Click(object sender, EventArgs e)
        {
            if (_districtInfocurrentMode == GlobalVariableBO.ModeSelection.UpdateMode)
            {
                _branchId = 0;
                ClearAllDistrictInfo();
                DisableAllDistrictInfo();
            }
            else
            {
                ClearAllDistrictInfo();
                EnableAllDistrictInfo();
            }
        }
        private void btnDistrictSave_Click(object sender, EventArgs e)
        {
            District_NameBO objBO = new District_NameBO();
            District_NameBAL objBAL = new District_NameBAL();
            switch (_districtInfocurrentMode)
            {
                case GlobalVariableBO.ModeSelection.NewMode:
                    try
                    {
                        objBO = InitializeDistrictInfoBO();
                        if (IsValidDistrictInfoInputData())
                        {
                            objBAL.SaveDistrictName(objBO);
                            MessageBox.Show(@"Data Saved Successfully");
                            ClearAllDistrictInfo();
                            LoadDistrictInfoGridData();
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
                        objBO = InitializeDistrictInfoBO();
                        if (IsValidDistrictInfoInputData())
                        {
                            objBAL.UpdateDistrictInfo(objBO,_districtId);
                            MessageBox.Show(@"District Info Updated Successfully");
                            ClearAllDistrictInfo();
                            LoadDistrictInfoGridData();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
            }
        }

        private void btnDistrictClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDistrictDelete_Click(object sender, EventArgs e)
        {
            District_NameBAL objBAL = new District_NameBAL();
            if (_districtId != 0)
            {
                try
                {
                    objBAL.DeletebDistrictName(_districtId);
                    MessageBox.Show(@"Data Deleted Successfully");
                    ClearAllDistrictInfo();
                    LoadDistrictInfoGridData();
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
            _districtId = 0;
        }
        private void dgvDistrictInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_districtInfocurrentMode == GlobalVariableBO.ModeSelection.UpdateMode)
            {

                try
                {
                    DataGridViewRow dr = dgvDistrictInfo.CurrentRow;
                    EnableAllDistrictInfo();
                    _districtId = 0;
                    _districtId = Int32.Parse(dr.Cells[0].Value.ToString());
                    txtDistrictCode.Text = dr.Cells["District_Code"].Value.ToString();
                    txtDistrictName.Text = dr.Cells["District_Name"].Value.ToString();
                    txtDistrictDescription.Text = dr.Cells["Description"].Value.ToString();
                }
                catch
                {
                    _districtId = 0;
                }
            }
        }
        private void dgvDistrictInfo_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                dgvDistrictInfo.Rows[0].Selected = false;
            }
            catch
            {

            }

        }
        #endregion District Info

        
        #region Thana Info
        private Thana_NameBO InitializeThanaInfoBO()
        {
            Thana_NameBO objBO = new Thana_NameBO();
            objBO.Thana_Code = txtThanaCode.Text;
            objBO.ThanaName = txtThanaName.Text;
            objBO.Thana_Description = txtThanaDescription.Text;
            return objBO;
        }
        private void ClearAllThanaInfo()
        {
            EnableAllThanaInfo();
            txtThanaCode.Text = string.Empty;
            txtThanaDescription.Text = string.Empty;
            txtThanaName.Text = string.Empty;
        }

        private void EnableAllThanaInfo()
        {
            txtThanaCode.Enabled = true;
            txtThanaDescription.Enabled = true;
            txtThanaName.Enabled = true;
        }
        private void DisableAllThanaInfo()
        {
            txtThanaCode.Enabled = false;
            txtThanaDescription.Enabled = false;
            txtThanaName.Enabled = false;
        }
        private bool IsValidThanaInfoInputData()
        {
            bool result = true;
            if (txtThanaCode.Text == "")
            {
                throw new Exception("Thana Code Required");
            }
            else if (txtThanaName.Text == "")
            {
                throw new Exception("Thana Name Required");
            }

            return result;
        }

        private void LoadThanaInfoGridData()
        {
            DataTable dtgrid = new DataTable();
            Thana_NameBAL objBAL = new Thana_NameBAL();
            dtgrid = objBAL.GetGridData();
            dgvThanaInfo.DataSource = dtgrid;
            dgvThanaInfo.Columns[0].Visible = false;
            dgvThanaInfo.Columns[1].DefaultCellStyle.Format = "D3";
            dgvThanaInfo.Columns[4].DefaultCellStyle.Format = "dd-MM-yyyy";
        }
        private void btnThanaInfoNew_Click(object sender, EventArgs e)
        {
            _thanaId = 0;
            _thanaInfocurrentMode = GlobalVariableBO.ModeSelection.NewMode;
            btnThanaInfoNew.Enabled = false;
            btnThanaInfoNew.BackColor = Color.Gray;
            btnThanaInfoUpdate.Enabled = true;
            btnThanaInfoUpdate.ResetBackColor();
            ClearAllThanaInfo();
        }

        private void btnThanaInfoUpdate_Click(object sender, EventArgs e)
        {
            _thanaInfocurrentMode = GlobalVariableBO.ModeSelection.UpdateMode;
            btnThanaInfoUpdate.Enabled = false;
            btnThanaInfoUpdate.BackColor = Color.Gray;
            btnThanaInfoNew.Enabled = true;
            btnThanaInfoNew.ResetBackColor();
            ClearAllThanaInfo();
            DisableAllThanaInfo();
        }

        private void btnThanaInfoReset_Click(object sender, EventArgs e)
        {
            if (_thanaInfocurrentMode == GlobalVariableBO.ModeSelection.UpdateMode)
            {
                _thanaId = 0;
                ClearAllThanaInfo();
                DisableAllThanaInfo();
            }
            else
            {
                ClearAllThanaInfo();
                EnableAllThanaInfo();
            }
        }

        private void btnThanaSave_Click(object sender, EventArgs e)
        {
            Thana_NameBO objBO = new Thana_NameBO();
            Thana_NameBAL objBAL = new Thana_NameBAL();
            switch (_thanaInfocurrentMode)
            {
                case GlobalVariableBO.ModeSelection.NewMode:
                    try
                    {
                        objBO = InitializeThanaInfoBO();
                        if (IsValidThanaInfoInputData())
                        {
                            objBAL.SaveThanaName(objBO);
                            MessageBox.Show(@"Data Saved Successfully");
                            ClearAllThanaInfo();
                            LoadThanaInfoGridData();
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
                        objBO = InitializeThanaInfoBO();
                        if (IsValidThanaInfoInputData())
                        {
                            objBAL.UpdateThanaInfo(objBO,_thanaId);
                            MessageBox.Show(@"Data Saved Successfully");
                            ClearAllThanaInfo();
                            LoadThanaInfoGridData();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    break;
            }

        }

        private void btnThanaClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThanaDelete_Click(object sender, EventArgs e)
        {
            Thana_NameBAL objBAL = new Thana_NameBAL();
            if (_thanaId != 0)
            {
                try
                {
                    objBAL.DeletebThanaName(_thanaId);
                    MessageBox.Show(@"Data Deleted Successfully");
                    ClearAllThanaInfo();
                    LoadThanaInfoGridData();
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
            _thanaId = 0;
        }

        private void dgvThanaInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_thanaInfocurrentMode == GlobalVariableBO.ModeSelection.UpdateMode)
            {

                try
                {
                    DataGridViewRow dr = dgvThanaInfo.CurrentRow;
                    EnableAllThanaInfo();
                    _thanaId = 0;
                    _thanaId = Int32.Parse(dr.Cells[0].Value.ToString());
                    txtThanaCode.Text = dr.Cells["Thana_Code"].Value.ToString();
                    txtThanaName.Text = dr.Cells["Thana_Name"].Value.ToString();
                    txtThanaDescription.Text = dr.Cells["Description"].Value.ToString();
                }
                catch
                {
                    _thanaId = 0;
                }
            }
        }
        private void dgvThanaInfo_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                dgvThanaInfo.Rows[0].Selected = false;
            }
            catch
            {

            }
        }
        #endregion Thana Info


        #region Bank Branch Routing Info

        private void LoadBankBranchRoutingInfo()
        {
            InitializeBankName();
            InitializeBranchName();
            InitializeDistrictName();
            InitializeThanaName();
            LoadBankBranchRoutingInfoGridData();
            ddlBankName.SelectedIndex = -1;
            ddlBranchName.SelectedIndex = -1;
            ddlDistrictName.SelectedIndex = -1;
            ddlThanaName.SelectedIndex = -1;
        }

        private void InitializeBankName()
        {
            DataTable dtBankName = new DataTable();
            Bank_Branch_RoutingBAL objBAL = new Bank_Branch_RoutingBAL();
            dtBankName = objBAL.GetBankName();
            ddlBankName.DataSource = dtBankName;
            ddlBankName.ValueMember = dtBankName.Columns["ID"].ToString();
            ddlBankName.DisplayMember = dtBankName.Columns["Bank_Code_Name"].ToString();
        }
        private void InitializeBranchName()
        {
            DataTable dtBranchName = new DataTable();
            Bank_Branch_RoutingBAL objBAL = new Bank_Branch_RoutingBAL();
            dtBranchName = objBAL.GetBranchName();
            ddlBranchName.DataSource = dtBranchName;
            ddlBranchName.ValueMember = dtBranchName.Columns["ID"].ToString();
            ddlBranchName.DisplayMember = dtBranchName.Columns["Branch_Code_Name"].ToString();
        }
        private void InitializeDistrictName()
        {
            DataTable dtDistrictName = new DataTable();
            Bank_Branch_RoutingBAL objBAL = new Bank_Branch_RoutingBAL();
            dtDistrictName = objBAL.GetDistrictName();
            ddlDistrictName.DataSource = dtDistrictName;
            ddlDistrictName.ValueMember = dtDistrictName.Columns["ID"].ToString();
            ddlDistrictName.DisplayMember = dtDistrictName.Columns["District_Code_Name"].ToString();
        }
        private void InitializeThanaName()
        {
            DataTable dtThanaName = new DataTable();
            Bank_Branch_RoutingBAL objBAL = new Bank_Branch_RoutingBAL();
            dtThanaName = objBAL.GetThanaName();
            ddlThanaName.DataSource = dtThanaName;
            ddlThanaName.ValueMember = dtThanaName.Columns["ID"].ToString();
            ddlThanaName.DisplayMember = dtThanaName.Columns["Thana_Code_Name"].ToString();
            ddlThanaName.SelectedIndex = -1;
        }
        private Bank_Branch_RoutingBO InitializeBankBranchRoutingInfoBO()
        {
            try
            {
                int intTryParse;

                Bank_Branch_RoutingBO objBO = new Bank_Branch_RoutingBO();
                objBO.Bank_Id = Convert.ToInt32(ddlBankName.SelectedValue.ToString());
                objBO.Bank_Code = _bankCode;
                objBO.Bank_Name = _bankName;
                objBO.Branch_Id = Convert.ToInt32(ddlBranchName.SelectedValue.ToString());
                objBO.Branch_Code = _branchCode;
                objBO.Branch_Name = _branchName;
                objBO.District_Id = Convert.ToInt32(ddlDistrictName.SelectedValue.ToString());
                objBO.District_Code = _districtCode;
                objBO.District_Name = _districtName;
                if (int.TryParse(Convert.ToString(ddlThanaName.SelectedValue), out intTryParse))
                {
                    objBO.Thana_Id = intTryParse;
                    objBO.Thana_Code = _thanaCode;
                    objBO.Thana_Name = _thanaName;
                }
                objBO.RoutingNo = txtRoutingNo.Text.Trim();

                return objBO;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private bool IsValidBankBranchRoutingInfoInputData()
        {
            bool result = true;
            if (Convert.ToString(ddlBankName.SelectedValue) == "")
            {
                throw new Exception("Bank Name Required");
            }
            else if (Convert.ToString(ddlBranchName.SelectedValue) == "")
            {
                throw new Exception("Branch Name Required");
            }
            else if(Convert.ToString(ddlDistrictName.SelectedValue)=="")
            {
                throw new Exception("District Name Required");
            }
            //else if (Convert.ToString(ddlThanaName.SelectedValue) == "")
            //{
            //    throw new Exception("Thana Name Required");
            //}
            else if (txtRoutingNo.Text == "")
            {
                throw new Exception("Routing No Required");
            }
            return result;
        }
        private void LoadBankBranchRoutingInfoGridData()
        {
            DataTable dtgrid = new DataTable();
            Bank_Branch_RoutingBAL objBAL = new Bank_Branch_RoutingBAL();
            dtgrid = objBAL.GetGridData();
            dgvBankBranchRouting.DataSource = dtgrid;
            dgvBankBranchRouting.Columns[0].Visible = false;
            dgvBankBranchRouting.Columns["Bank_ID"].Visible = false;
            dgvBankBranchRouting.Columns["Branch_ID"].Visible = false;
            dgvBankBranchRouting.Columns["District_ID"].Visible = false;
            dgvBankBranchRouting.Columns["Thana_ID"].Visible = false;
            //dgvBankBranchRouting.Columns[1].DefaultCellStyle.Format = "D3";
            //dgvBankBranchRouting.Columns[4].DefaultCellStyle.Format = "dd-MM-yyyy";
        }
        private void ResetCode()
        {
            _bankCode = "";
            _branchCode = "";
            _districtCode = "";
            _thanaCode = "";
        }

        private void EnableAllBankBranchRoutingInfo()
        {
            ddlBankName.Enabled = true;
            ddlBranchName.Enabled = true;
            ddlDistrictName.Enabled = true;
            ddlThanaName.Enabled = true;
            txtRoutingNo.Enabled = true;
        }
        private void DisableAllBankBranchRoutingInfo()
        {
            ddlBankName.Enabled = false;
            ddlBranchName.Enabled = false;
            ddlDistrictName.Enabled = false;
            ddlThanaName.Enabled = false;
            txtRoutingNo.Enabled = false;
        }
        private void ClearAllBankBranchRoutingInfo()
        {
            EnableAllBankBranchRoutingInfo();
            ddlBankName.SelectedIndex = -1;
            ddlBranchName.SelectedIndex = -1;
            ddlDistrictName.SelectedIndex = -1;
            ddlThanaName.SelectedIndex = -1;
            txtRoutingNo.Text = string.Empty;
        }

        private void btnBankBranchRoutingInfoNew_Click(object sender, EventArgs e)
        {
            _thanaId = 0;
            _bankbranchroutingInfocurrentMode = GlobalVariableBO.ModeSelection.NewMode;
            btnBankBranchRoutingInfoNew.Enabled = false;
            btnBankBranchRoutingInfoNew.BackColor = Color.Gray;
            btnBankBranchRoutingInfoUpdate.Enabled = true;
            btnBankBranchRoutingInfoUpdate.ResetBackColor();
            ClearAllBankBranchRoutingInfo();
        }


        private void btnBankBranchRoutingInfoUpdate_Click(object sender, EventArgs e)
        {
            _bankbranchroutingInfocurrentMode = GlobalVariableBO.ModeSelection.UpdateMode;
            btnBankBranchRoutingInfoUpdate.Enabled = false;
            btnBankBranchRoutingInfoUpdate.BackColor = Color.Gray;
            btnBankBranchRoutingInfoNew.Enabled = true;
            btnBankBranchRoutingInfoNew.ResetBackColor();
            ClearAllBankBranchRoutingInfo();
            DisableAllBankBranchRoutingInfo();
        }

        private void btnBankBranchRoutingInfoReset_Click(object sender, EventArgs e)
        {
            if (_bankbranchroutingInfocurrentMode == GlobalVariableBO.ModeSelection.UpdateMode)
            {
                _bankBranchRoutingId = 0;
                ClearAllBankBranchRoutingInfo();
                DisableAllBankBranchRoutingInfo();
            }
            else
            {
                ClearAllBankBranchRoutingInfo();
                EnableAllBankBranchRoutingInfo();
            }
        }

        private void btnBankBranchRoutingSave_Click(object sender, EventArgs e)
        {
            Bank_Branch_RoutingBO objBO = new Bank_Branch_RoutingBO();
            Bank_Branch_RoutingBAL objBAL = new Bank_Branch_RoutingBAL();
            switch (_bankbranchroutingInfocurrentMode)
            {
                case GlobalVariableBO.ModeSelection.NewMode:
                    try
                    {
                        objBO = InitializeBankBranchRoutingInfoBO();
                        if (IsValidBankBranchRoutingInfoInputData())
                        {
                            objBAL.SaveBankBranchRouting(objBO);
                            MessageBox.Show(@"Data Saved Successfully");
                            ResetCode();
                            ClearAllBankBranchRoutingInfo();
                            LoadBankBranchRoutingInfoGridData();
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
                        objBO = InitializeBankBranchRoutingInfoBO();
                        if (IsValidBankBranchRoutingInfoInputData())
                        {
                            objBAL.UpdateBankBranchRoutingInfo(objBO,_bankBranchRoutingId);
                            MessageBox.Show(@"Updated Successfully");
                            ResetCode();
                            ClearAllBankBranchRoutingInfo();
                            LoadBankBranchRoutingInfoGridData();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    break;
            }

        }

        private void btnBankBranchRoutingClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBankBranchRoutingDelete_Click(object sender, EventArgs e)
        {
            Bank_Branch_RoutingBAL objBAL = new Bank_Branch_RoutingBAL();
            if (_bankBranchRoutingId != 0)
            {
                try
                {
                    objBAL.DeletebBankBranchRoutingInfo(_bankBranchRoutingId);
                    MessageBox.Show(@"Data Deleted Successfully");
                    ClearAllBankBranchRoutingInfo();
                    LoadBankBranchRoutingInfoGridData();
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
            _bankBranchRoutingId = 0;
        }

        private void dgvBankBranchRouting_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_bankbranchroutingInfocurrentMode == GlobalVariableBO.ModeSelection.UpdateMode)
            {

                try
                {
                    DataGridViewRow dr = dgvBankBranchRouting.CurrentRow;
                    EnableAllBankBranchRoutingInfo();
                    _bankBranchRoutingId = 0;
                    _bankBranchRoutingId = Int32.Parse(dr.Cells[0].Value.ToString());

                    ddlBankName.SelectedValue = dr.Cells["Bank_ID"].Value.ToString();
                    ddlBranchName.SelectedValue = dr.Cells["Branch_ID"].Value.ToString();
                    txtRoutingNo.Text = dr.Cells["Routing_No"].Value.ToString();
                    ddlDistrictName.SelectedValue = dr.Cells["District_ID"].Value.ToString();
                    ddlThanaName.SelectedValue = dr.Cells["Thana_ID"].Value.ToString();

                }
                catch
                {
                    _bankBranchRoutingId = 0;
                }
            }
        }

        private void dgvBankBranchRouting_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                dgvBankBranchRouting.Rows[0].Selected = false;
            }
            catch
            {
                
            }
        }

        private void ddlBankName_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bank_Branch_RoutingBAL objBAL = new Bank_Branch_RoutingBAL();
            try
            {
                DataTable dt=objBAL.GetBankInfoByBankID(Int32.Parse(ddlBankName.SelectedValue.ToString()));
                _bankCode = Convert.ToString(dt.Rows[0]["Bank_Code"]);
                _bankName = Convert.ToString(dt.Rows[0]["Bank_Name"]);
            }
            catch
            {
            }
        }

        private void ddlBranchName_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bank_Branch_RoutingBAL objBAL = new Bank_Branch_RoutingBAL();
            try
            {
                DataTable dt = objBAL.GetBranchInfoByBranchID(Int32.Parse(ddlBranchName.SelectedValue.ToString()));
                _branchCode = Convert.ToString(dt.Rows[0]["Branch_Code"]);
                _branchName = Convert.ToString(dt.Rows[0]["Branch_Name"]);
            }
            catch
            {
            }
        }

        private void ddlDistrictName_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bank_Branch_RoutingBAL objBAL = new Bank_Branch_RoutingBAL();
            try
            {
                DataTable dt = objBAL.GetDistrictInfoByDistictID(Int32.Parse(ddlDistrictName.SelectedValue.ToString()));
                _districtCode = Convert.ToString(dt.Rows[0]["District_Code"]);
                _districtName = Convert.ToString(dt.Rows[0]["District_Name"]);
                
            }
            catch
            {
            }
        }

        private void ddlThanaName_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bank_Branch_RoutingBAL objBAL = new Bank_Branch_RoutingBAL();
            try
            {
                DataTable dt = objBAL.GetThanaInfoByThanaID(Int32.Parse(ddlThanaName.SelectedValue.ToString()));
                _thanaCode = Convert.ToString(dt.Rows[0]["Thana_Code"]);
                _thanaName = Convert.ToString(dt.Rows[0]["Thana_Name"]);                
            }
            catch
            {
            }
        }
        #endregion Bank Branch Routing Info

        #region tabpage selecting 
        private void tabBankBranchRoutingInfo_Selecting(object sender, TabControlCancelEventArgs e)
        {
            try
            {                                                     
                if (tabBankBranchRoutingInfo.SelectedTab == tabBankBranchRoutingInfo.TabPages[0])
                {
                    LoadBankInfoGridData();
                }
                else if (tabBankBranchRoutingInfo.SelectedTab == tabBankBranchRoutingInfo.TabPages[1])
                {
                    LoadBranchInfoGridData();
                    btnBranchInfoNew.Enabled = false;
                }
                else if (tabBankBranchRoutingInfo.SelectedTab == tabBankBranchRoutingInfo.TabPages[2])
                {
                    LoadDistrictInfoGridData();
                    btnDistrictInfoNew.Enabled = false;
                }
                else if (tabBankBranchRoutingInfo.SelectedTab == tabBankBranchRoutingInfo.TabPages[3])
                {
                    LoadThanaInfoGridData();
                    btnThanaInfoNew.Enabled = false;
                }
                else if (tabBankBranchRoutingInfo.SelectedTab == tabBankBranchRoutingInfo.TabPages[4])
                {
                    LoadBankBranchRoutingInfo();
                    btnBankBranchRoutingInfoNew.Enabled = false;
                }
            }
            catch
            {
                
            }

        }
        #endregion tabpage selecting

    }
}
