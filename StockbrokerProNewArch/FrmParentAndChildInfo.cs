using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.BO;
using BusinessAccessLayer.BAL;
using BusinessAccessLayer.Constants;
using System.IO;
using System.Runtime.InteropServices;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Threading;

namespace StockbrokerProNewArch
{
    public partial class FrmParentAndChildInfo : Form
    {
        string Cust_Status = "";
        public FrmParentAndChildInfo()
        {
            InitializeComponent();
            cmbOwnerparent.SelectedIndex = 0;
            
        }

        ParentAndChildBAL objBal = new ParentAndChildBAL();
        CustomerBAL customer = new CustomerBAL();

        #region Parent Info

        #region Private Field and method

        private string ParentCode = "";
        private string ChildCode = "";
        public static bool isProgressed;

        private void Add(string ParentCode)
        {
            //string Parent_Code = cmb_ParentCode_ParentChild.Text;
            string Parent_Code = ParentCode;
            string Child_Code = txtChildCode.Text;
            string Chil_BoId = txtchildBoId.Text;
            string Parent_Name = txtParentName.Text;
            string Owner_Name = txtHandelerName.Text;
            string Parent_Gender = txtParentgender.Text;
            string Parent_Profession = txtParentProfession.Text;
            string parent_Email = txtParentEmail.Text;
            string Parent_Cell = txtparentCell.Text;
            string parent_land = txtParentLand.Text;
            string Parent_Present_addr = txtparentPresentAddress.Text;
            string parent_Permanent_add = txtparentPermanetaddr.Text;
            dgvParentInfo.Rows.Add(new object[] { Parent_Code, Child_Code, Chil_BoId, Parent_Name, Owner_Name, Parent_Gender, Parent_Profession, parent_Email, Parent_Cell, parent_land, Parent_Present_addr, parent_Permanent_add });

        }

        
        private void WaitWindow_Thread()
        {
            WaitWindow waitWindow = new WaitWindow();
            waitWindow.Show();
            while (isProgressed)
            {
                waitWindow.Refresh();
            }
            waitWindow.Close();
        }

        private void Clear()
        {
            txtChildCode.Text = "";
            txtchildBoId.Text = "";
            txtParentName.Text = "";
            txtHandelerName.Text = "";
            txtParentgender.Text = "";
            txtParentProfession.Text = "";
            txtParentEmail.Text = "";
            txtparentCell.Text = "";
            txtParentLand.Text = "";
            txtparentPresentAddress.Text = "";
            txtparentPermanetaddr.Text = "";
        }

        private ParentAndChildBO InitializeBO()
        {
            ParentAndChildBO bo = new ParentAndChildBO();
            foreach (DataGridViewRow row in dgvParentInfo.Rows)
            {
                if (row.IsNewRow)
                    continue;
                bo.Parent_Code = (string)row.Cells["Parent_Code"].Value ?? string.Empty;
                bo.Child_Code = (string)row.Cells["Child_Code"].Value ?? string.Empty;
                bo.Chil_BoId = (string)row.Cells["Chil_BoId"].Value ?? string.Empty;
                bo.Parent_Name = (string)row.Cells["Parent_Name"].Value ?? string.Empty;
                bo.Handeler_Name = (string)row.Cells["Owner_Name"].Value ?? string.Empty;
                bo.Parent_Gender = (string)row.Cells["Parent_Gender"].Value ?? string.Empty;
                bo.Parent_Profession = (string)row.Cells["Parent_Profession"].Value ?? string.Empty;
                bo.parent_Email = (string)row.Cells["parent_Email"].Value ?? string.Empty;
                bo.parent_land = (string)row.Cells["parent_land"].Value ?? string.Empty;
                bo.Parent_Cell = (string)row.Cells["Parent_Cell"].Value ?? string.Empty;
                bo.Parent_Present_addr = (string)row.Cells["Parent_Present_addr"].Value ?? string.Empty;
                bo.parent_Permanent_add = (string)row.Cells["parent_Permanent_add"].Value ?? string.Empty;
                objBal.SaveParentInfo(bo);
            }
            return bo;
        }
        private void LoadParentandChildData(string id)
        {
            DataTable dt = new DataTable();
            dt = objBal.GetparentChildInfo(id);
            txtChildCode.Text = dt.Rows[0]["CODE"].ToString();
            txtchildBoId.Text = dt.Rows[0]["BO ID"].ToString();
            txtParentName.Text = dt.Rows[0]["NAME"].ToString();
            txtParentgender.Text = dt.Rows[0]["GENDER"].ToString();
            txtParentProfession.Text = dt.Rows[0]["PROFESSION"].ToString();
            txtParentEmail.Text = dt.Rows[0]["MAIL"].ToString();
            txtparentPresentAddress.Text = dt.Rows[0]["ADDRESS"].ToString();
            txtParentLand.Text = dt.Rows[0]["PHONE"].ToString();
            txtparentCell.Text = dt.Rows[0]["CELL"].ToString();
        }

        private void ParentInfo(string id)
        {
            ParentAndChildBO bo = new ParentAndChildBO();
            DataTable dt = new DataTable();
            dt = objBal.GetparentChildInfo(id);
            bo.Parent_Code = dt.Rows[0]["CODE"].ToString();
            bo.Child_Code = dt.Rows[0]["CODE"].ToString();
            bo.Chil_BoId = dt.Rows[0]["BO ID"].ToString();
            bo.Parent_Name = dt.Rows[0]["NAME"].ToString();
            bo.Parent_Gender = dt.Rows[0]["GENDER"].ToString();
            bo.Parent_Profession = dt.Rows[0]["PROFESSION"].ToString();
            bo.parent_Email = dt.Rows[0]["MAIL"].ToString();
            bo.Parent_Present_addr = dt.Rows[0]["ADDRESS"].ToString();
            bo.parent_land = dt.Rows[0]["PHONE"].ToString();
            bo.Parent_Cell = dt.Rows[0]["CELL"].ToString();
            objBal.SaveParentInfo(bo);
        }

        #endregion

        #region Button Click and Event handler
        private void BtnAdd_Click(object sender, EventArgs e)
        {            
            Add(cmb_ParentCode_ParentChild.Text.Trim());
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (DialogResult.Yes == (MessageBox.Show("Is your Registration is complete Against This Parent Code? ", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)))
                {
                    ParentAndChildBAL bal = new ParentAndChildBAL();
                    InitializeBO();
                    MessageBox.Show("Data save successfully");
                    dgvParentInfo.Rows.Clear();
                    string[] Child = bal.GetallChildCode(cmb_ParentCode_ParentChild.Text);
                    bal.UpdateRegistraionChildCode(new string[]{}, cmb_ParentCode_ParentChild.Text);
                    LoadparentChildDetails();
                    LbalParentChildAdd.Text = "";
                    UpdateRealTimeParentChildInformation();
                    ChildCount.Text = "Count : " + dgvParentInfo.Rows.Count;
                }
                    
                 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
         }
        private void UpdateRealTimeParentChildInformation()
        {
            SMSSyncBAL bal = new SMSSyncBAL();
            try
            {
                bal.Connect_SBP();
                bal.Connect_SMS();

                SqlDataReader DataReader = bal.GetIPO_AccountGrouping_Info_UITransApplied();
                bal.TruncateTable_SMSSyncExport_AccountGrouping_Info_UITransApplied();
                bal.InsertTable_SMSSyncExport_AccountGrouping_Info_UITransApplied(DataReader);

                bal.Commit_SBP();
                bal.Commit_SMS();
            }
            catch (Exception ex)
            {
                bal.Rollback_SBP();
                bal.Rollback_SMS();
                throw new Exception(ex.Message);
            }
            finally
            {
                bal.CloseConnection_SBP();
                bal.CloseConnection_SMS();
            }
        }

        private void FrmParentAndChildInfo_Load(object sender, EventArgs e)
        {
            LoadParentCode();
            ResetPrevillize();
            LoadPrevilize();
        }

        private void LoadParentCode()
        {
            if (!(String.IsNullOrEmpty(txtCustCode.Text)))
            {
                _parent_Code = txtCustCode.Text;
            }
            else if (!(String.IsNullOrEmpty(cmb_ParentCode_Owner.Text)))
            {
                _parent_Code = cmb_ParentCode_Owner.Text;
            }
            else if (!(String.IsNullOrEmpty(cmb_ParentCode_ParentChild.Text)))
            {
                _parent_Code = cmb_ParentCode_ParentChild.Text;
            }
        }

        private void btnParentsearch_Click(object sender, EventArgs e)
        {
            ParentCode = cmb_ParentCode_ParentChild.Text;
            if (ParentCode != objBal.checkCustCode(ParentCode))
            {
                MessageBox.Show("Please provide valid customer code");
            }
            else
            {
                if (ParentCode == objBal.CheckParentandchildCode(ParentCode, "", ""))
                {
                    MessageBox.Show("Parent Code is already exist in Parent Code so able to add child code for this parent code", "Parent Code", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (ParentCode == objBal.CheckParentandchildCode("", ParentCode, ""))
                {
                    MessageBox.Show("Child Code is already exist in child Code so provide your Valid child code", "Child code", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    LoadParentandChildData(ParentCode);
                    Add(ParentCode);
                    Clear();
                    txtChildCode.Focus();
                    groupBox2.Visible = true;
                    btnOwnerInfo.Visible = true;
                    dgvParentInfo.Visible = true;
                    dgvparentChildShow.Visible = true;
                    LbalParentChildAdd.Text = "Count : " + dgvParentInfo.Rows.Count;
                }
            }
        }
         
        private void txtChildCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (Char)Keys.Enter)
                {
                    ChildCode = txtChildCode.Text.Trim(); ;
                    Cust_Status = customer.CheckCustomerStatus(ChildCode);
                    if (Cust_Status == "Active")
                    {
                        if (ChildCode != objBal.checkCustCode(ChildCode))
                        {
                            MessageBox.Show("Please provide valid customer code");
                        }
                        else
                        {
                            if (ChildCode == objBal.CheckParentandchildCode("", ChildCode, ""))
                            {
                                MessageBox.Show("Child Code is already exist");
                            }
                            else
                            {
                                if (dgvParentInfo.Rows.Cast<DataGridViewRow>().Where(t => Convert.ToString(t.Cells["Child_Code"].Value) == ChildCode).Count() == 0)
                                {
                                    LoadParentandChildData(ChildCode);
                                    Add(cmb_ParentCode_ParentChild.Text.Trim());
                                    Clear();
                                    groupBox2.Visible = true;
                                    btnOwnerInfo.Visible = true;
                                    dgvParentInfo.Visible = true;
                                    dgvparentChildShow.Visible = true;
                                    //LbalParentChildAdd.Text = "Count : " + dgvParentInfo.Rows.Count;
                                    ChildCount.Text = "Count : " + dgvParentInfo.Rows.Count;
                                    dgvParentInfo.FirstDisplayedScrollingRowIndex = dgvParentInfo.Rows.IndexOf(dgvParentInfo.Rows.Cast<DataGridViewRow>().Last());
                                    dgvParentInfo.Rows.OfType<DataGridViewRow>().Last().Selected = true;
                                }
                                else
                                {
                                    MessageBox.Show("Child Code is already exist grid so try another child code", "" + MessageBoxIcon.Error);
                                }
                            }

                        }
                    }
                    else
                    {
                        throw new Exception(txtChildCode.Text.Trim() + " is " + Cust_Status + "\n only ACTIVE Code are allowed");
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
         
        private void btnchildsearch_Click(object sender, EventArgs e)
        {
            try
            {
                ChildCode = txtChildCode.Text;
                Cust_Status = customer.CheckCustomerStatus(ChildCode);
                if (Cust_Status == "Active")
                {
                    if (ChildCode != objBal.checkCustCode(ChildCode))
                    {
                        MessageBox.Show("Please provide valid customer code");
                    }
                    else
                    {
                        if (ChildCode == objBal.CheckParentandchildCode("", ChildCode, ""))
                        {
                            MessageBox.Show("Child Code is already exist");
                        }
                        else
                        {
                            LoadParentandChildData(ChildCode);
                            Add(cmb_ParentCode_ParentChild.Text.Trim());
                            Clear();
                            groupBox2.Visible = true;
                            btnOwnerInfo.Visible = true;
                            dgvParentInfo.Visible = true;
                            dgvparentChildShow.Visible = true;
                            //LbalParentChildAdd.Text = "Count : " + dgvParentInfo.Rows.Count;
                            TotalCount.Text = "Count : " + dgvParentInfo.Rows.Count;
                        }

                    }
                }
                else
                {
                    throw new Exception(_parent_Code + " is " + Cust_Status + "\n only ACTIVE Code are allowed");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


         
        private void btnGridRowDelete_Click(object sender, EventArgs e)
        {
            if (dgvparentChildShow.SelectedRows.Count>0)
            {
                DataTable dt = new DataTable();
                string selectedChild = dgvparentChildShow.CurrentRow.Cells["Child_Code"].Value.ToString();
                if (DialogResult.Yes == MessageBox.Show("Are you sure to Delete This Data", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    objBal.DeleteClient(selectedChild);
                    LoadparentChildDetails();                         
                }
            }
        }


         
        private void btnsearch_Click(object sender, EventArgs e)
        {
            DataTable dtParent = new DataTable();
            DataTable dtowner = new DataTable();
            ParentAndChildBAL bal = new ParentAndChildBAL();
            dtParent = bal.GetAllParentChildOwnerInfo(txtsearch.Text);

            dgvparentChildShow.DataSource = dtParent;
            if (dtParent.Rows.Count > 0)
            {
                _parent_Code = dgvparentChildShow.Rows[0].Cells["Parent_Code"].Value.ToString();                
                txtCustCode.Text = _parent_Code;
                LoadPaentInfo(_parent_Code);               
                dgvparentChildShow.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            }

        }
        #endregion
        #endregion

        #region Owner info
        private ParentAndChildBO InitialiseOwnerInfo()
        {
            ParentAndChildBO bo = new ParentAndChildBO();            
            bo.Parent_Code = cmb_ParentCode_Owner.Text;
            bo.Owner_name = txtownername.Text;
            bo.Owner_gender = cmbOwnerGender.Text;
            bo.Owner_profession = txtownerprofession.Text;
            bo.Owner_email = txtownerEmail1.Text;
            bo.Owner_Email_1 = txtownerEmail2.Text;
            bo.Owner_Email_2 = txtownerEmail3.Text;
            bo.Owner_cell = txtownercontactcell.Text;
            bo.Owner_land = txtownercontactland.Text;
            bo.Owner_present_addr = txtownerpresentaddr.Text;
            bo.Owner_permanent_add = txtownerpermanentaddr.Text;
            return bo;
        }
        private void ClearOwner()
        {
   
            txtownername.Text="";
            cmbOwnerGender.Text = "";
            txtownerprofession.Text="";
            txtParentEmail.Text="";
            txtownercontactcell.Text="";
            txtownercontactland.Text="";
            txtownerpresentaddr.Text="";
            txtownerpermanentaddr.Text="";
            txtownerEmail1.Text = "";
            txtownerEmail2.Text = "";
            txtownerEmail3.Text = "";
        }
        private void btnOwnerInfo_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtownercontactcell.Text == "")
                {
                    MessageBox.Show("Contact cell 1 is Mandatory", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    objBal.SaveOwnerInfo(InitialiseOwnerInfo(),(int)cmb_ParentCode_Owner.SelectedValue);
                    ClearOwner();
                    MessageBox.Show("Save Successfully");
                    dgwnerInfo.DataSource = objBal.GetAllownerInformation();
                    dgwnerInfo.Columns["Registration_id"].Visible = false;
                    dgwnerInfo.Columns["Handeler_Name"].Visible = false;
                    dgwnerInfo.FirstDisplayedScrollingRowIndex = dgwnerInfo.Rows.IndexOf(dgwnerInfo.Rows.Cast<DataGridViewRow>().Last());
                    dgwnerInfo.Rows.Cast<DataGridViewRow>().Last().Selected = true;
                    UpdateRealTimeParentChildInformation();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
             
        }
        #endregion

        

        private void txtownercontactcell_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '+')
            {
                e.Handled = true;
            }
        }

        private void txtownercontactland_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '+')
            {
                e.Handled = true;
            }
             
        }

        private void txtownerEmail_Leave(object sender, EventArgs e)
        {
            if (txtownerEmail1.Text != string.Empty)
            {
                if (!(txtownerEmail1.Text.Contains("@") && txtownerEmail1.Text.Contains(".")))
                {
                    MessageBox.Show("Invalid email address", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtownerEmail1.Focus();
                }
            }
        }

        
        private void btnImgBrowse_Click(object sender, EventArgs e)
        {
            if (ofdImagebrowse.ShowDialog() == DialogResult.OK)
            {
                txtImgLocation.Text = ofdImagebrowse.FileName;
                RegPic.Image = Image.FromFile(txtImgLocation.Text);
                btnStartUpload.Enabled = true;
            }
        }
       
        private void frmParentChildImage_Load(object sender, EventArgs e)
        {            
            LoadParentChildInfo();
        }

        private MemoryStream Photo(string Code)
        {
            MemoryStream Ms = null;
            byte[] imageByte = new byte[0];
            imageByte = objBal.GetParetnIamge(Code);
            if (imageByte != null)
            {
                Ms = new MemoryStream(imageByte);
            }
            return Ms;
        }

        private MemoryStream LoadRegistrationImage(string code)
        {
            MemoryStream ms = null;
            byte[] imagebute = new byte[0];
            imagebute = objBal.GetAllRegistrationImage(code);
            if (imagebute != null)
            {
                ms = new MemoryStream(imagebute);
            }
            return ms;
        }
        private MemoryStream LoadRegisterOwnerImage(string parent)
        {
            MemoryStream ms = null;
            byte[] iamgeByte = new byte[0];
            iamgeByte = objBal.GetRegisterOwnerImage(parent);
            if (iamgeByte != null)
            {
                ms = new MemoryStream(iamgeByte);
            }
            return ms;
        }
        private void LoadParentChildInfo()
        {
             
            DataTable dt = new DataTable();
            dt = objBal.GetParentChildImgeAccountInfo(_parent_Code);
            if (dt.Rows.Count > 0)
            {
                txtCustCode.Text = dt.Rows[0]["Cust_Code"].ToString();
                txtAccountHolderName.Text = dt.Rows[0]["Customer"].ToString();
                txtAccountHolderBOId.Text = dt.Rows[0]["Bo Id"].ToString();
            }
        }

        private byte[] GetImageByte(string fileName)
        {
            MemoryStream ms = new MemoryStream();
            try
            {
                Bitmap image = new Bitmap(fileName);
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                image.Dispose();
                return ms.ToArray();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Image byte conversion failed. Error:" + ex.Message);
            }
            return null;

        }

        private void btnStartUpload_Click(object sender, EventArgs e)
        {
            try
            {
                if (RegPic.Image != null)
                {
                    if (string.IsNullOrEmpty(txtRegistrationParent.Text))
                    {
                        txtRegistrationParent.Focus();
                        throw new Exception("Please provide your valid parent Code");
                    }
                    else if (string.IsNullOrEmpty(txtCustCode.Text))
                    {
                        txtCustCode.Focus();
                        throw new Exception("Please provide your valid parent Code");
                    }
                    else
                    {
                        if (txtRegistrationParent.Text == txtCustCode.Text)
                        {
                            ParentChildRegistrationBO bo = new ParentChildRegistrationBO();
                            bo.Parent_Code = txtRegistrationParent.Text;
                            bo.Registration_Image = GetImageByte(ofdImagebrowse.FileName);
                            bo.UserName = GlobalVariableBO._userName;
                            bo.Child_Code = objBal.GetallChildCode("");
                            objBal.InsertParentChildRegistrationInfo(bo);
                            ParentInfo(txtCustCode.Text);
                            MessageBox.Show("Save Successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnStartUpload.Enabled = false;
                            UpdateRealTimeParentChildInformation();

                        }
                        else
                        {
                            throw new Exception("Parent code and Account information code is not match" + MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please Upload Registration image");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        string _parent_Code = "";
        private void tabParentChild_Selecting(object sender, TabControlCancelEventArgs e)
        {
            try
            {
                Thread thread = new Thread(WaitWindow_Thread);
                isProgressed = true;
                thread.Start();
                if (tabParentChild.SelectedTab == tabParentChild.TabPages[0])
                {
                    _parent_Code = txtCustCode.Text;
                    LoadPaentInfo(_parent_Code);
                    LoadRegistrationImage();
                    LoadOwnerImage();
                    TotalCount.Visible = false;
                    ChildCount.Visible = false;
                }
                else if (tabParentChild.SelectedTab == tabParentChild.TabPages[1])
                {
                    TotalCount.Visible = true;
                    ChildCount.Visible = false;
                    DataTable dtowner = new DataTable();
                    dtowner = objBal.GetRegistrationIdAndParentCode_ForOwner();
                    cmb_ParentCode_Owner.DataSource = dtowner;
                    cmb_ParentCode_Owner.DisplayMember = dtowner.Columns["Parent_Code"].ToString();
                    cmb_ParentCode_Owner.ValueMember = dtowner.Columns["Registration_ID"].ToString();
                    cmbOwnerGender.SelectedIndex = 0;
                    cmb_ParentCode_Owner.Enabled = true;
                    txtownername.Enabled = true;
                    if (cmb_ParentCode_Owner.Text == "")
                    {
                        dgwnerInfo.DataSource = objBal.GetAllownerInformation();
                        dgwnerInfo.Columns["Owner_Id"].Visible = false;
                        dgwnerInfo.Columns["Registration_id"].Visible = false;

                    }
                    else
                    {                        
                        dgwnerInfo.DataSource = objBal.GetAllownerInformation();
                        dgwnerInfo.Columns["Owner_Id"].Visible = false;                        
                        string parent_code = cmb_ParentCode_Owner.Text;
                        string[] CheckGridCode=dgwnerInfo.Rows.OfType<DataGridViewRow>().Select(c=>Convert.ToString(c.Cells["Parent_Id"].Value)).ToArray();
                            if (CheckGridCode.Contains(parent_code))
                            {
                                MessageBox.Show("This code is Already owner = " + parent_code + " Unable to Owner this code again ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                cmb_ParentCode_Owner.Focus();
                            }
                    }
                }
                else if (tabParentChild.SelectedTab == tabParentChild.TabPages[2])
                {
                    TotalCount.Visible = true;
                    ChildCount.Visible = true;
                    DataTable dtParent = new DataTable();
                    dtParent = objBal.GetRegistrationIdAndParentCode_ForParenChildDetails();
                    cmb_ParentCode_ParentChild.DataSource = dtParent;
                    cmb_ParentCode_ParentChild.DisplayMember = dtParent.Columns["Parent_Code"].ToString();
                    cmb_ParentCode_ParentChild.ValueMember = dtParent.Columns["Registration_ID"].ToString();
                    if (cmb_ParentCode_ParentChild.Text == "")
                    {
                         
                        LoadparentChildDetails();
                    }
                    else
                    {                        
                        LoadparentChildDetails();
                        
                    }                    
                }
                else if (tabParentChild.SelectedTab == tabParentChild.TabPages[3])
                {
                     
                    if (!string.IsNullOrEmpty(txt_SearchParent.Text.Trim()))
                    {
                        LoadparentChildDetails(txt_SearchParent.Text.Trim());
                        ParentChild_UpdateAndDelte();
                    }
                    else if (string.IsNullOrEmpty(txt_SearchParent.Text.Trim()))
                    {
                        ParentChild_UpdateAndDelte();
                    }
                      
                    dg_ParentCildInfoUpdate.DataSource = null;
                    dg_ParentCildInfoUpdate.Columns["Remove"].Visible = false;
                    
                }
                isProgressed = false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        private void ParentChild_UpdateAndDelte()
        {
            
            dg_ParentCildInfoUpdate.Columns.Clear();
            TotalCount.Visible = true;
            ChildCount.Visible = false;
            dg_ParentCildInfoUpdate.AllowUserToAddRows = false;
            dg_ParentCildInfoUpdate.RowHeadersVisible = false;
            DataGridViewButtonColumn btnRemove = new DataGridViewButtonColumn();
            dg_ParentCildInfoUpdate.Columns.Add(btnRemove);
            btnRemove.Name = "Remove";
            btnRemove.Text = "Delete";
            btnRemove.UseColumnTextForButtonValue = true;
            if (!string.IsNullOrEmpty(txt_SearchParent.Text.Trim()))
            {/*
                dg_ParentCildInfoUpdate.DataSource = objBal.GetAllParentChildDetails();
                dg_ParentCildInfoUpdate.Columns["Handeler_Name"].Visible = false;
                dg_ParentCildInfoUpdate.Columns["Handler_Name"].Visible = false;
                dg_ParentCildInfoUpdate.Columns["Remove"].Width = 50;
                TotalCount.Text = "Count : " + dg_ParentCildInfoUpdate.Rows.Count;
               */
                LoadparentChildDetails(txt_SearchParent.Text.Trim());
            }
             
            
        }
        
        private void LoadparentChildDetails()
        {
            DataTable dt = new DataTable();        
            dt = objBal.GetAllParentChildDetails();
            dgvparentChildShow.DataSource = dt;
           dgvparentChildShow.Columns["Handeler_Name"].Visible = false;
           dgvparentChildShow.Columns["Handler_Name"].Visible = false;
           TotalCount.Text = "Count : " + dgvparentChildShow.Rows.Count;
        }
        private void LoadparentChildDetails(string parent_code)
        {
            
            DataTable dt_parent = new DataTable();
            dt_parent = objBal.GetAllParentChildDetails();
            var parent = dt_parent.Rows.Cast<DataRow>()
                .Where(c => Convert.ToString(c["Parent_Code"]) == txt_SearchParent.Text.Trim()).ToList();
            dt_parent = parent.CopyToDataTable();
            dg_ParentCildInfoUpdate.DataSource = dt_parent;
             
            dg_ParentCildInfoUpdate.Columns["Handeler_Name"].Visible = false;
            dg_ParentCildInfoUpdate.Columns["Handler_Name"].Visible = false;
            dg_ParentCildInfoUpdate.Columns["Remove"].Visible = true;
            dg_ParentCildInfoUpdate.Columns["Remove"].Width = 50;
            TotalCount.Text = "Count : " + dg_ParentCildInfoUpdate.Rows.Count;
        }

        private void LoadPaentInfo(string code)
        {
            DataTable dt = new DataTable();
            dt = objBal.LoadparentInfo(code);
            if (dt.Rows.Count > 0)
            {
                txtCustCode.Text = dt.Rows[0]["Cust_Code"].ToString();
                txtAccountHolderBOId.Text = dt.Rows[0]["Bo_Id"].ToString();
                txtAccountHolderName.Text = dt.Rows[0]["Cust_Name"].ToString();
            }
        }

        private void LoadRegistrationImage()
        {
            MemoryStream ms = LoadRegistrationImage(_parent_Code);
            if (ms != null)
            {
                RegPic.Image = Image.FromStream(ms);
            }
            else
            {
                RegPic.Image = null;
            }            
        }
        private void LoadOwnerImage()
        {
            MemoryStream ms = LoadRegistrationImage(_parent_Code);
            if (ms != null)
            {
                RegPic.Image = Image.FromStream(ms);
            }
            else
            {
                RegPic.Image = null;
            }         
        }

        private void txtRegistrationParent_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                _parent_Code = txtRegistrationParent.Text;
                string[] arr = objBal.GetallChildCode(_parent_Code);
                string CheckRegistratinParentCode = "";
                string RegistrationId = objBal.CheckParentCodeFromReistration(_parent_Code);
                Cust_Status = customer.CheckCustomerStatus(_parent_Code);
                if (e.KeyCode == Keys.Enter)
                {

                    if (Cust_Status == "Active")
                    {
                        if (arr != null)
                        {
                            CheckRegistratinParentCode = objBal.CheckParentCodeFromRegistration(arr);
                        }
                        if (_parent_Code == objBal.CheckParentCodeIsExist(_parent_Code))
                        {
                            LoadRegistrationImage();
                            LoadParentChildInfo();
                        }
                        else if (_parent_Code == objBal.CheckPaentCodeForParentcodesearchFromRegistration(_parent_Code))
                        {
                            LoadRegistrationImage();
                            LoadParentChildInfo();
                            MessageBox.Show("Owner Information and parent child details information not update\n For this code = " + _parent_Code);
                        }
                        else if (arr != null)
                        {
                            if (arr.Contains(_parent_Code))
                            {
                                MessageBox.Show("Registration is Complete For this = " + _parent_Code + "", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                _parent_Code = objBal.CheckParentCodeFromRegistration(arr);
                                LoadOwnerImage();
                                LoadPaentInfo(_parent_Code);
                                btnImgBrowse.Enabled = false;
                                LoadParentChildInfo();
                            }
                        }
                        else if (CheckRegistratinParentCode != "" || RegistrationId != "")
                        {
                            MessageBox.Show("Registration is Complete For this = " + _parent_Code + "", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            LoadRegistrationImage();
                            LoadOwnerImage();
                            LoadParentChildInfo();
                        }
                        else
                        {
                            LoadParentChildInfo();
                            btnImgBrowse.Enabled = true;
                        }
                    }
                    else
                    {
                        if (DialogResult.Yes == (MessageBox.Show(_parent_Code + " is " + Cust_Status + "\n Do you want to Continue?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)))
                        {

                            if (arr != null)
                            {
                                CheckRegistratinParentCode = objBal.CheckParentCodeFromRegistration(arr);
                            }
                            if (_parent_Code == objBal.CheckParentCodeIsExist(_parent_Code))
                            {
                                LoadRegistrationImage();
                                LoadParentChildInfo();
                            }
                            else if (_parent_Code == objBal.CheckPaentCodeForParentcodesearchFromRegistration(_parent_Code))
                            {
                                LoadRegistrationImage();
                                LoadParentChildInfo();
                                MessageBox.Show("Owner Information and parent child details information not update\n For this code = " + _parent_Code);
                            }
                            else if (arr != null)
                            {
                                if (arr.Contains(_parent_Code))
                                {
                                    MessageBox.Show("Registration is Complete For this = " + _parent_Code + "", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    _parent_Code = objBal.CheckParentCodeFromRegistration(arr);
                                    LoadOwnerImage();
                                    LoadPaentInfo(_parent_Code);
                                    btnImgBrowse.Enabled = false;
                                    LoadParentChildInfo();
                                }
                            }
                            else if (CheckRegistratinParentCode != "" || RegistrationId != "")
                            {
                                MessageBox.Show("Registration is Complete For this = " + _parent_Code + "", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                LoadRegistrationImage();
                                LoadOwnerImage();
                                LoadParentChildInfo();
                            }
                            else
                            {
                                LoadParentChildInfo();
                                btnImgBrowse.Enabled = true;
                            }

                        }


 
                        //throw new Exception(_parent_Code + " is " + Cust_Status + "\n only ACTIVE Code are allowed");
                    }





                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
        private void txtsearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DataTable dtParent = new DataTable();
                DataTable dtowner = new DataTable();
                ParentAndChildBAL bal = new ParentAndChildBAL();
                DataTable dt = bal.GetAllParentChildOwnerInfo(txtsearch.Text);
                dgvparentChildShow.DataSource = dt;
                if (dt.Rows.Count > 0)
                {
                    dgvparentChildShow.DataSource = dt;                    
                }
                
               
            }
        }


        private void txtownerEmail2_Leave(object sender, EventArgs e)
        {
            if (txtownerEmail2.Text != string.Empty)
            {
                if (!(txtownerEmail2.Text.Contains("@") && txtownerEmail2.Text.Contains(".")))
                {
                    MessageBox.Show("Invalid email address", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtownerEmail2.Focus();
                }
            }
        }

        private void txtownerEmail3_Leave(object sender, EventArgs e)
        {
            if (txtownerEmail3.Text != string.Empty)
            {
                if (!(txtownerEmail3.Text.Contains("@") && txtownerEmail3.Text.Contains(".")))
                {
                    MessageBox.Show("Invalid email address", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtownerEmail2.Focus();
                }
            }
        }

         

        private void txtownercontactcell_Leave(object sender, EventArgs e)
        {
            if (txtownercontactcell.Text == string.Empty)
            {
                MessageBox.Show("Contact Cell  1 Is Madatory", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RegPic_Click(object sender, EventArgs e)
        {
            MemoryStream ms = LoadRegistrationImage(_parent_Code);
            if (ms != null)
            {
                FrmRegistratinImageViewer imageViewer = new FrmRegistratinImageViewer(Image.FromStream(ms));
                imageViewer.Show();
            }
            else
            {
            }

        }

        private void dgwnerInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ClearOwner();
            int RowIndex = dgwnerInfo.Rows[e.RowIndex].Index;            
            txtownerEmail1.Text = dgwnerInfo.Rows[RowIndex].Cells["Handeler_Email_1"].Value.ToString();
            txtownerEmail2.Text = dgwnerInfo.Rows[RowIndex].Cells["Handeler_Email_2"].Value.ToString();
            txtownerEmail3.Text = dgwnerInfo.Rows[RowIndex].Cells["Handeler_Email_3"].Value.ToString();
            cmb_ParentCode_Owner.Text = dgwnerInfo.Rows[RowIndex].Cells["Parent_Id"].Value.ToString();
            txtownername.Text = dgwnerInfo.Rows[RowIndex].Cells["Handeler_Parent_Name"].Value.ToString(); 
            cmbOwnerGender.Text = dgwnerInfo.Rows[RowIndex].Cells["Hadeler_Gender"].Value.ToString(); 
            txtownerprofession.Text = dgwnerInfo.Rows[RowIndex].Cells["Handelr_Occupation"].Value.ToString(); 
            txtownercontactcell.Text = dgwnerInfo.Rows[RowIndex].Cells["Hadeler_Contact_Mobile"].Value.ToString(); 
            txtownercontactland.Text = dgwnerInfo.Rows[RowIndex].Cells["Handeler_Contact_Land"].Value.ToString(); 
            txtownerpresentaddr.Text = dgwnerInfo.Rows[RowIndex].Cells["Handeler_Present_Address"].Value.ToString(); 
            txtownerpermanentaddr.Text = dgwnerInfo.Rows[RowIndex].Cells["Handeler_Permanent_Address"].Value.ToString(); 
            cmb_ParentCode_Owner.Enabled = false;
            txtownername.Enabled = false;
        }

        private void btnUpdateOwner_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtownercontactcell.Text == "")
                {
                    MessageBox.Show("Contact cell 1 is Mandatory", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtownercontactcell.Focus();
                }
                else
                {
                    objBal.UpdateParentChildOwnerDetails(InitialiseOwnerInfo());
                    ClearOwner();
                    MessageBox.Show("Update Successfully");
                    dgwnerInfo.DataSource = objBal.GetAllownerInformation();
                    dgwnerInfo.Columns["Handeler_Name"].Visible = false;
                    cmb_ParentCode_Owner.Enabled = true;
                    cmb_ParentCode_Owner.Enabled = true;
                    UpdateRealTimeParentChildInformation();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvparentChildShow_DataSourceChanged(object sender, EventArgs e)
        {
            TotalCount.Text = "Count : " + dgvparentChildShow.Rows.Count;
        }

        private void dgwnerInfo_DataSourceChanged(object sender, EventArgs e)
        {
            TotalCount.Text = "Count : " + dgwnerInfo.Rows.Count;
        }

        private void dgvParentInfo_DataSourceChanged(object sender, EventArgs e)
        {
            ChildCount.Text = "Count : " + dgvParentInfo.Rows.Count;
        }

        private void BtnRegistrationDelete_Click(object sender, EventArgs e)
        {
            try
            {
                objBal.DeleteParentChild_LOG(Convert.ToInt32(txtRegistrationParent.Text));                
                MessageBox.Show("Data Deleted Successfully");
                txtRegistrationParent.Text = "";
                txtCustCode.Text = "";
                txtAccountHolderName.Text = "";
                txtAccountHolderBOId.Text = "";
                RegPic.Image = null;
                btnStartUpload.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
             
        }

        private void BtnChildInfoDelete_Click(object sender, EventArgs e)
        {
            if (this.dgvParentInfo.SelectedRows.Count > 0)
            {
                dgvParentInfo.Rows.RemoveAt(this.dgvParentInfo.SelectedRows[0].Index);
            }
        }

        private void dg_ParentCildInfoUpdate_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                try
                {
                    string Child_Code = dg_ParentCildInfoUpdate.Rows[e.RowIndex].Cells["Child_Code"].Value.ToString();
                    //.Columns["Child_Code"]
                    if (DialogResult.Yes == MessageBox.Show("Are You Sure to Delete this code ( " + Child_Code + " ) record", "Delete Info", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {
                        objBal.Delete_Parent_Child_Details(Child_Code);
                        MessageBox.Show("Child Record Delete Successfull " + Child_Code + "", "Delete", MessageBoxButtons.OK);
                        ParentChild_UpdateAndDelte();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void txt_childtoAddGroup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    Cust_Status = customer.CheckCustomerStatus(txt_childtoAddGroup.Text.Trim());
                    if (Cust_Status == "Active")
                    {
                        
                        btn_Update.Focus();
                    }
                    else
                    {
                        throw new Exception(txt_childtoAddGroup.Text + " is " + Cust_Status + "\n only ACTIVE Code are allowed");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void txt_Parent_Update_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txt_childtoAddGroup.Focus();
            }
        }

        private void LoadParentImage_ForUpdate()
        {
            MemoryStream ms = LoadRegistrationImage(txt_SearchParent.Text.Trim());
            if (ms != null)
            {
                UpdaeRegPic.Image = Image.FromStream(ms);
            }
            else
            {
                UpdaeRegPic.Image = null;
            }
        }

        private void txt_SearchParent_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                DataTable dt_parent = new DataTable();
                string CheckParentCodeIsExist = "";
                txt_Parent_Update.Text = "";
                txt_childtoAddGroup.Text = "";
                if (e.KeyCode == Keys.Enter)
                {
                    Thread thread = new Thread(WaitWindow_Thread);
                    isProgressed = true;
                    thread.Start();
                    Cust_Status = customer.CheckCustomerStatus(txt_SearchParent.Text.Trim());
                    if (Cust_Status == "Active")
                    {
                        CheckParentCodeIsExist = objBal.CheckPaentCodeForParentcodesearchFromRegistration(txt_SearchParent.Text.Trim());
                        if (string.IsNullOrEmpty(CheckParentCodeIsExist))
                        {
                            txt_SearchParent.Focus();
                            isProgressed = false;
                            MessageBox.Show("This code is not a parent code. \n Provide your valid parent code", "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            LoadParentImage_ForUpdate();
                            textBox3.Text = txt_SearchParent.Text.Trim();
                            dt = objBal.GetAllownerInformation();
                            textBox3.Text = dt.Rows.Cast<DataRow>()
                                .Where(c => Convert.ToString(c["Parent_Id"]).Trim() == txt_SearchParent.Text.Trim())
                                .Select(t => Convert.ToString(t["Parent_Id"]).Trim()).FirstOrDefault();
                            txt_UpdateownerName.Text = dt.Rows.Cast<DataRow>()
                                .Where(c => Convert.ToString(c["Parent_Id"]).Trim() == txt_SearchParent.Text.Trim())
                                .Select(t => Convert.ToString(t["Handeler_Parent_Name"]).Trim()).FirstOrDefault();
                            txtUpdate_ownerCell.Text = dt.Rows.Cast<DataRow>()
                                .Where(c => Convert.ToString(c["Parent_Id"]).Trim() == txt_SearchParent.Text.Trim())
                                .Select(t => Convert.ToString(t["Hadeler_Contact_Mobile"]).Trim()).FirstOrDefault();
                            txtOwnerEmail.Text = dt.Rows.Cast<DataRow>()
                                .Where(c => Convert.ToString(c["Parent_Id"]).Trim() == txt_SearchParent.Text.Trim())
                                .Select(t => Convert.ToString(t["Handeler_Email_1"]).Trim()).FirstOrDefault();
                            Cmb_UpdateGender.Text = dt.Rows.Cast<DataRow>()
                                .Where(c => Convert.ToString(c["Parent_Id"]).Trim() == txt_SearchParent.Text.Trim())
                                .Select(t => Convert.ToString(t["Hadeler_Gender"]).Trim()).FirstOrDefault();
                            LoadparentChildDetails(txt_SearchParent.Text.Trim());
                        }
                    }
                    else
                    {
                        isProgressed = false;
                        throw new Exception(txt_SearchParent.Text + " is " + Cust_Status + "\n only ACTIVE Code are allowed");

                    }
                    isProgressed = false;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
         
        private void UpdaeRegPic_Click(object sender, EventArgs e)
        {
            MemoryStream ms = LoadRegistrationImage_Update(txt_SearchParent.Text.Trim());
            if (ms != null)
            {
                FrmRegistratinImageViewer imageViewer = new FrmRegistratinImageViewer(Image.FromStream(ms));
                imageViewer.Show();
            }
            else
            {

            }
        }
        private MemoryStream LoadRegistrationImage_Update(string code)
        {
            MemoryStream ms = null;
            byte[] imagebute = new byte[0];
            imagebute = objBal.GetAllRegistrationImage(code);
            if (imagebute != null)
            {
                ms = new MemoryStream(imagebute);
            }
            return ms;
        }

        private void btn_Updae_Image_Click(object sender, EventArgs e)
        {
            if (UpdaeRegPic.Image != null)
            {
                if (ofdImagebrowse.ShowDialog() == DialogResult.OK)
                {
                    txtUpdateImage.Text = ofdImagebrowse.FileName;
                    UpdaeRegPic.Image = Image.FromFile(txtUpdateImage.Text);
                    btn_UpdaeImage.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("This Customer is not register yet", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btn_UpdaeImage_Click(object sender, EventArgs e)
        {
            if (UpdaeRegPic.Image != null)
            {
                if (string.IsNullOrEmpty(txt_SearchParent.Text))
                {
                    throw new Exception("Please Provider Your Valid Paent Code");
                }
                if (!string.IsNullOrEmpty(txtOwnerEmail.Text.Trim()))
                {
                    if (Validation.IsValidEmail(txtOwnerEmail.Text.Trim()) == false)
                    {
                        MessageBox.Show("Email is invalid");
                    }
                }

                if (!string.IsNullOrEmpty(txtUpdate_ownerCell.Text.Trim()))
                {
                    if (Validation.IsValidPhonNumber(txtUpdate_ownerCell.Text.Trim()) == false)
                    {
                        txtUpdate_ownerCell.Focus();
                        MessageBox.Show("Number Format is invalid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                try
                {
                    ParentChildRegistrationBO bo = new ParentChildRegistrationBO();
                    ParentAndChildBO P_Bo = new ParentAndChildBO();
                    bo.Parent_Code = txt_SearchParent.Text;
                    bo.Registration_Image = GetImageByte(ofdImagebrowse.FileName);
                    P_Bo.Parent_Name = txt_UpdateownerName.Text.Trim();
                    P_Bo.Owner_cell = txtUpdate_ownerCell.Text.Trim();
                    P_Bo.Owner_Email_1 = txtOwnerEmail.Text.Trim();
                    P_Bo.Parent_Gender = Cmb_UpdateGender.Text.Trim();
                    objBal.Update_Parent_Registration_Image(bo, P_Bo);
                    MessageBox.Show("Update successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_childtoAddGroup.Enabled = true;
                    txt_Parent_Update.Text = txt_SearchParent.Text;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void txt_SearchParent_Leave(object sender, EventArgs e)
        {
            try
            {
                string CheckParentCodeIsExist = "";
                txt_Parent_Update.Text = "";
                txt_childtoAddGroup.Text = "";
                if (!string.IsNullOrEmpty(txt_SearchParent.Text.Trim()))
                {
                    Cust_Status = customer.CheckCustomerStatus(txt_SearchParent.Text.Trim());
                    if (Cust_Status == "Active")
                    {
                        CheckParentCodeIsExist = objBal.CheckPaentCodeForParentcodesearchFromRegistration(txt_SearchParent.Text.Trim());
                        if (string.IsNullOrEmpty(CheckParentCodeIsExist))
                        {
                            txt_SearchParent.Focus();
                            MessageBox.Show("This code is not a parent code. \n Provide your valid parent code", "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            DataTable dt = new DataTable();
                            LoadParentImage_ForUpdate();
                            dt = objBal.GetAllownerInformation();
                            textBox3.Text = dt.Rows.Cast<DataRow>()
                                .Where(c => Convert.ToString(c["Parent_Id"]).Trim() == txt_SearchParent.Text.Trim())
                                .Select(t => Convert.ToString(t["Parent_Id"]).Trim()).FirstOrDefault();
                            txt_UpdateownerName.Text = dt.Rows.Cast<DataRow>()
                                .Where(c => Convert.ToString(c["Parent_Id"]).Trim() == txt_SearchParent.Text.Trim())
                                .Select(t => Convert.ToString(t["Handeler_Parent_Name"]).Trim()).FirstOrDefault();
                            txtUpdate_ownerCell.Text = dt.Rows.Cast<DataRow>()
                                .Where(c => Convert.ToString(c["Parent_Id"]).Trim() == txt_SearchParent.Text.Trim())
                                .Select(t => Convert.ToString(t["Hadeler_Contact_Mobile"]).Trim()).FirstOrDefault();
                            txtOwnerEmail.Text = dt.Rows.Cast<DataRow>()
                                .Where(c => Convert.ToString(c["Parent_Id"]).Trim() == txt_SearchParent.Text.Trim())
                                .Select(t => Convert.ToString(t["Handeler_Email_1"]).Trim()).FirstOrDefault();
                            Cmb_UpdateGender.Text = dt.Rows.Cast<DataRow>()
                                .Where(c => Convert.ToString(c["Parent_Id"]).Trim() == txt_SearchParent.Text.Trim())
                                .Select(t => Convert.ToString(t["Hadeler_Gender"]).Trim()).FirstOrDefault();
                            LoadparentChildDetails(txt_SearchParent.Text.Trim());
                        }
                    }
                    else
                    {
                        throw new Exception(txt_SearchParent.Text + " is " + Cust_Status + "\n only ACTIVE Code are allowed");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
                
        }
        /*
        public static bool IsValidEmail(string inputEmail)
        {
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputEmail))
                return (true);
            else
                return (false);
        }
        public static bool IsValidPhonNumber(string strPhoneNumber)
        {
            string MatchPhoneNumberPattern = @"^\(?([0-9]{4})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$";
           if (strPhoneNumber!= null) return Regex.IsMatch(strPhoneNumber, MatchPhoneNumberPattern );
           else return false;
        }
        */
        /// <summary>
        /// Set Previlize For client Account Information
        /// Add By Md.Rashedul Hasan
        /// </summary>
        private void SetPrevillize(string Previllize)
        {
            switch (Previllize)
            {
                case "Parent Child Registration Delete":
                    BtnRegistrationDelete.Visible = true;
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Load Previlize For client Account Information
        /// Add By Md.Rashedul Hasan
        /// </summary>
        private void LoadPrevilize()
        {
            bool result = false;
            DataTable RoleWiseUserPrevillizeDatatable = new DataTable();
            DataTable RoleWisePrevillizeDataTable = new DataTable();
            PrevillizeManagementBAL previllizeManagementBal = new PrevillizeManagementBAL();

            RoleWisePrevillizeDataTable = previllizeManagementBal.GetRoleWisePrevillize();


            RoleWiseUserPrevillizeDatatable = previllizeManagementBal.GetAssignedPrevillize();
            if (RoleWiseUserPrevillizeDatatable.Rows.Count > 0)
            {
                for (int i = 0; i < RoleWiseUserPrevillizeDatatable.Rows.Count; i++)
                {
                    if (RoleWiseUserPrevillizeDatatable.Rows[i][0].ToString().ToLower() == GlobalVariableBO._userName.ToLower())
                    {
                        result = true;
                        break;
                    }
                }
                if (result)
                {
                    for (int j = 0; j < RoleWiseUserPrevillizeDatatable.Rows.Count; j++)
                    {
                        if (RoleWiseUserPrevillizeDatatable.Rows[j][0].ToString().ToLower() == GlobalVariableBO._userName.ToLower())
                        {
                            SetPrevillize(RoleWiseUserPrevillizeDatatable.Rows[j]["Previllize"].ToString());
                        }
                    }
                }
                DeactiveMenu();
            }
            else if (RoleWiseUserPrevillizeDatatable.Rows.Count == 0)
            {
                RoleWisePrevillizeDataTable = previllizeManagementBal.GetRoleWisePrevillize();

                for (int k = 0; k < RoleWisePrevillizeDataTable.Rows.Count; k++)
                {
                    SetPrevillize(RoleWisePrevillizeDataTable.Rows[k]["Previllize"].ToString());
                }
                DeactiveMenu();
            }
        }



        private void DeactiveMenu()
        {
        }

        /// <summary>
        /// Reset Previlize For client Account Information
        /// Add By Md.Rashedul Hasan
        /// </summary>
        public void ResetPrevillize()
        {
            BtnRegistrationDelete.Visible = false;

        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txt_childtoAddGroup.Text.Trim()))
                {
                    MessageBox.Show("Provide your child code \n For update parent child Grouping");
                }
                else
                {

                    Cust_Status = customer.CheckCustomerStatus(txt_childtoAddGroup.Text.Trim());
                    if (Cust_Status == "Active")
                    {
                        UpdateParentChildInfo();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateParentChildInfo()
        {

            if (string.IsNullOrEmpty(objBal.CheckParentandchildCode("", txt_childtoAddGroup.Text.Trim(), "")))
            {
                
                //AddChildCodeDetails(txt_childtoAddGroup.Text.Trim(), tabParentChild.SelectedTab.Name);
                if (DialogResult.Yes == (MessageBox.Show("Is your Registration is complete Against This Parent Code? ", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)))
                {
                    LoadParentandChildData(txt_childtoAddGroup.Text.Trim());
                    Add(txt_Parent_Update.Text.Trim());
                    InitializeBO();
                    objBal.UpdateRegistraionChildCode(new string[] { }, txt_Parent_Update.Text);
                    MessageBox.Show("Data save successfully");
                    dgvParentInfo.Rows.Clear();
                    //ParentChild_UpdateAndDelte();
                    LoadparentChildDetails(txt_SearchParent.Text.Trim());
                    txt_childtoAddGroup.Text = "";
                    txt_childtoAddGroup.Focus();
                }
            }
            else
            {
                txt_childtoAddGroup.Focus();
                MessageBox.Show("Child Code Already exist");
            }
        }
       
    }
}
