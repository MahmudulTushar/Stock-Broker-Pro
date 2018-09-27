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
using System.Data.SqlClient;

namespace StockbrokerProNewArch
{
    public partial class WebSmsRegistration : Form
    {
        private GlobalVariableBO.ModeSelection currentMode = GlobalVariableBO.ModeSelection.NewMode;
        public static string _boID = "";
        public static int _custCode = 0;
        bool IsChangedByUser = true;
        public WebSmsRegistration()
        {
            InitializeComponent();
        }
       

        private void ClearAll()
        {
            EnableAll();
            txtClientCode.Text = "";
            txtEmail.Text = "";
            txtMobileNo.Text = "";
            txtRemarks.Text = "";
            chkWeb.Checked = false;
            chkSmsTrade.Checked = false;
            chkECharge.Checked = false;
            txtCustCode.Text = "";
            txtAccountHolderName.Text = "";
            txtAccountHolderBOId.Text = "";
            txtWeb.Text = "";
            txtSms.Text = "";
            txtEcharge.Text = "";
            tr_Eft_Withdraw.Nodes[0].Checked = false;
            tr_Money_Withdraw.Nodes[0].Checked = false;
            tr_Money_Deposit.Nodes[0].Checked = false;
            tr_Eft_Withdraw.Nodes[0].Checked = false;
            tr_Trade_Confirmation.Nodes[0].Checked = false;
        }

        private void LoadSelectedInformation()
        {
            if (currentMode == GlobalVariableBO.ModeSelection.NewMode)
            {
                GetServiceRegistationInfo(false);
            }
            else if (currentMode == GlobalVariableBO.ModeSelection.UpdateMode)
            {
                LoadDataFromDataTable();
            }
        }

        private void LoadDataFromDataTable()
        {
            DataTable dtServiceReg = new DataTable();
            ServiceRegistrationBAL serviceRegBal = new ServiceRegistrationBAL();
            if (!String.IsNullOrEmpty(txtClientCode.Text.Trim()))
                dtServiceReg = serviceRegBal.GetAllData(txtClientCode.Text);

            if (dtServiceReg.Rows.Count > 0)
            {
                GetServiceRegistationInfo(true);

                txtClientCode.Text = dtServiceReg.Rows[0]["Cust_Code"].ToString();
                txtEmail.Text = dtServiceReg.Rows[0]["Email"].ToString();
                txtMobileNo.Text = dtServiceReg.Rows[0]["Mobile_No"].ToString();
                txtRemarks.Text = dtServiceReg.Rows[0]["Remarks"].ToString();
                if (dtServiceReg.Rows[0]["Reg_Date"]!=DBNull.Value)
                    dtRegDate.Value = Convert.ToDateTime(dtServiceReg.Rows[0]["Reg_Date"]);
                if (Convert.ToInt16(dtServiceReg.Rows[0]["Web_Service"] == DBNull.Value ? 0 : dtServiceReg.Rows[0]["Web_Service"]) == 1)
                {
                    chkWeb.Checked = true;
                }
                else
                {
                    chkWeb.Checked = false;
                }
                if (Convert.ToInt16(dtServiceReg.Rows[0]["SMS_Trade"] == DBNull.Value ? 0 : dtServiceReg.Rows[0]["SMS_Trade"]) == 1)
                {
                    chkSmsTrade.Checked = true;
                }
                else
                {
                    chkSmsTrade.Checked = false;
                }

                if (Convert.ToInt16(dtServiceReg.Rows[0]["SMS_Confirmation"] == DBNull.Value ? 0 : dtServiceReg.Rows[0]["SMS_Confirmation"]) == 1)
                {
                    tr_Trade_Confirmation.Nodes[0].Nodes["Sms_Trade_Confirmation"].Checked = true;
                }
                else
                {
                    tr_Trade_Confirmation.Nodes[0].Nodes["Sms_Trade_Confirmation"].Checked = false;
                }
                if (Convert.ToInt16(dtServiceReg.Rows[0]["Trade_Confirmation_Email"] == DBNull.Value ? 0 : dtServiceReg.Rows[0]["Trade_Confirmation_Email"]) == 1)
                {
                    tr_Trade_Confirmation.Nodes[0].Nodes["Email_Trade_Confirmation"].Checked = true;
                }
                else
                {
                    tr_Trade_Confirmation.Nodes[0].Nodes["Email_Trade_Confirmation"].Checked = false;
                }
                if (Convert.ToInt16(dtServiceReg.Rows[0]["E_Charge"] == DBNull.Value ? 0 : dtServiceReg.Rows[0]["E_Charge"]) == 1)
                {
                    chkECharge.Checked = true;
                }
                else
                {
                    chkECharge.Checked = false;
                }
                if (Convert.ToInt16(dtServiceReg.Rows[0]["SMS_MoneyDeposit_Confirmation"] == DBNull.Value ? 0 : dtServiceReg.Rows[0]["SMS_MoneyDeposit_Confirmation"]) == 1)
                {
                    tr_Money_Deposit.Nodes[0].Nodes["Sms_Money_Deposit"].Checked = true;
                }
                else
                {
                    tr_Money_Deposit.Nodes[0].Nodes["Sms_Money_Deposit"].Checked = false;
                }
                if (Convert.ToInt16(dtServiceReg.Rows[0]["MoneyDeposit_Confirmation_Email"] == DBNull.Value ? 0 : dtServiceReg.Rows[0]["MoneyDeposit_Confirmation_Email"]) == 1)
                {
                    tr_Money_Deposit.Nodes[0].Nodes["Email_Money_Deposit"].Checked = true;
                }
                else
                {
                    tr_Money_Deposit.Nodes[0].Nodes["Email_Money_Deposit"].Checked = false;
                }

                if (Convert.ToInt16(dtServiceReg.Rows[0]["SMS_MoneyWithdraw_Confirmation"] == DBNull.Value ? 0 : dtServiceReg.Rows[0]["SMS_MoneyWithdraw_Confirmation"]) == 1)
                {
                    tr_Money_Withdraw.Nodes[0].Nodes["Sms_Money_Withdraw"].Checked = true;
                }
                else
                {
                     tr_Money_Withdraw.Nodes[0].Nodes["Sms_Money_Withdraw"].Checked = false;
                }
                if (Convert.ToInt16(dtServiceReg.Rows[0]["MoneyWithdraw_Confirmation_Email"] == DBNull.Value ? 0 : dtServiceReg.Rows[0]["MoneyWithdraw_Confirmation_Email"]) == 1)
                {
                    tr_Money_Withdraw.Nodes[0].Nodes["Email_Money_Withdraw"].Checked = true;
                }
                else
                {
                    tr_Money_Withdraw.Nodes[0].Nodes["Email_Money_Withdraw"].Checked = false;
                }
                if (Convert.ToInt16(dtServiceReg.Rows[0]["SMS_EFTWithdraw_Confirmation"] == DBNull.Value ? 0 : dtServiceReg.Rows[0]["SMS_EFTWithdraw_Confirmation"]) == 1)
                {
                    tr_Eft_Withdraw.Nodes[0].Nodes["Sms_Eft_Withdraw"].Checked = true;
                }
                else
                {
                    tr_Eft_Withdraw.Nodes[0].Nodes["Sms_Eft_Withdraw"].Checked = false;
                }
                if (Convert.ToInt16(dtServiceReg.Rows[0]["EFTWithdraw_Confirmation_Email"] == DBNull.Value ? 0 : dtServiceReg.Rows[0]["EFTWithdraw_Confirmation_Email"]) == 1)
                {
                    tr_Eft_Withdraw.Nodes[0].Nodes["Email_Eft_Withdraw"].Checked = true;
                }
                else
                {
                    tr_Eft_Withdraw.Nodes[0].Nodes["Email_Eft_Withdraw"].Checked = false;
                }
                EnableAll();
                txtClientCode.Enabled = false;
            }
            else
            {
                //btnUpdate.Enabled = false;
                //btnUpdate.BackColor = Color.Gray;
                //btnNew.Enabled = true;
                //btnNew.ResetBackColor();
                //ClearAll();
                //DisableAll();
                MessageBox.Show("This Client Code is not registered...", "Error Message",MessageBoxButtons.OK,MessageBoxIcon.Error);
                txtClientCode.Focus();
            }
        }

        private void SaveServiceRegInfo()
        {
            if (txtClientCode.Text.Trim() == "")
            {
                MessageBox.Show("Please Fill the customer code.");
                return;
            }
            if (chkWeb.Checked && txtEmail.Text.Trim() == "")
            {
                MessageBox.Show("Please Fill the E-mail Address.");
                txtEmail.Focus();
                return;
            }
            if (( tr_Trade_Confirmation.Nodes[0].Nodes["Sms_Trade_Confirmation"].Checked || chkSmsTrade.Checked ) && txtMobileNo.Text.Trim() == "")
            {
                MessageBox.Show("Please Fill the Mobile No.");
                txtMobileNo.Focus();
                return;
            }
            try
            {
                ServiceRegistrationBO serviceRegBo = new ServiceRegistrationBO();
                serviceRegBo.CustCode = txtClientCode.Text;
                serviceRegBo.WebService = Convert.ToInt32(chkWeb.Checked);
                serviceRegBo.SmsConf = Convert.ToInt32( tr_Trade_Confirmation.Nodes[0].Nodes["Sms_Trade_Confirmation"].Checked);
                serviceRegBo.SmsTrade = Convert.ToInt32(chkSmsTrade.Checked);
                serviceRegBo.ECharge = Convert.ToInt32(chkECharge.Checked);
                serviceRegBo.EMail = txtEmail.Text;
                serviceRegBo.Mobile = txtMobileNo.Text;
                serviceRegBo.Remarks = txtRemarks.Text;
                serviceRegBo.RegDate = dtRegDate.Value;
                serviceRegBo.Sms_Money_Deposit = Convert.ToInt32(tr_Money_Deposit.Nodes[0].Nodes["Sms_Money_Deposit"].Checked);
                serviceRegBo.Sms_Money_Withdraw = Convert.ToInt32(tr_Money_Withdraw.Nodes[0].Nodes["Sms_Money_Withdraw"].Checked);
                serviceRegBo.Sms_Eft_Withdraw = Convert.ToInt32(tr_Eft_Withdraw.Nodes[0].Nodes["Sms_Eft_Withdraw"].Checked);
                serviceRegBo.Email_Money_Deposit = Convert.ToInt32(tr_Money_Deposit.Nodes[0].Nodes["Email_Money_Deposit"].Checked);
                serviceRegBo.Email_Money_Withdraw = Convert.ToInt32(tr_Money_Withdraw.Nodes[0].Nodes["Email_Money_Withdraw"].Checked);
                serviceRegBo.Email_Eft_Withdraw = Convert.ToInt32(tr_Eft_Withdraw.Nodes[0].Nodes["Email_Eft_Withdraw"].Checked);
                serviceRegBo.Email_Trade_Confirmation = Convert.ToInt32(tr_Trade_Confirmation.Nodes[0].Nodes["Email_Trade_Confirmation"].Checked);
                
                ServiceRegistrationBAL serviceRegBal = new ServiceRegistrationBAL();
                switch (currentMode)
                {
                    case GlobalVariableBO.ModeSelection.NewMode:
                        try
                        {
                            if (IsValidateField())
                            {
                                serviceRegBal.Insert(serviceRegBo);
                                MessageBox.Show("Service Registration has successfully saved.","Save Succeed.");
                                ClearAll();
                                txtClientCode.Focus();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Service Registration unsuccessful because of the error :" + ex.Message);
                            
                        }
                        break;
                    case GlobalVariableBO.ModeSelection.UpdateMode:
                        try
                        {
                            serviceRegBal.Update(serviceRegBo);
                            MessageBox.Show(" Service Registration has successfully updated.","Update Succeed.");
                            btnUpdate.Enabled = false;
                            btnUpdate.BackColor = Color.Gray;
                            btnNew.Enabled = true;
                            btnNew.ResetBackColor();
                            ClearAll();
                            DisableAll();
                            txtClientCode.Focus();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Service Registration update unsuccessful because of the error :" + ex.Message);
                           
                        }
                        break;
                    case GlobalVariableBO.ModeSelection.NoneMode:
                        MessageBox.Show("You have select none mode.Please select a mode.");
                        break;
                }
            }
            catch (Exception exc)
            {

                MessageBox.Show(exc.Message);
            }
        }

        private bool IsValidateField()
        {
            if (IsDuplicateCustomerCode())
            {
                MessageBox.Show("This Customer has allready registered. Instead of insertion You can update.");
                return false;
            }
            else
            {
                return true;
            }

        }
       
        private bool IsDuplicateCustomerCode()
        {
            ServiceRegistrationBAL serviceRegBal = new ServiceRegistrationBAL();
            if (serviceRegBal.CheckCustomerCodeDuplicate(txtClientCode.Text))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void WebSmsRegistration_Load(object sender, EventArgs e)
        {
            ClearAll();
            LoadDataIntoGrid();
            DefultTreeModeLoad();
        }
        private void DefultTreeModeLoad()
        {
            tr_Eft_Withdraw.ExpandAll();
            tr_Money_Deposit.ExpandAll();
            tr_Money_Withdraw.ExpandAll();
            tr_Trade_Confirmation.ExpandAll();
        }

        private void LoadDataIntoGrid()
        {
            ServiceRegistrationBAL serviceRegBal = new ServiceRegistrationBAL();
            DataTable datatable = serviceRegBal.GetAllRegisteredClient();
            dtgRegisterInfo.DataSource = datatable;
            dtgRegisterInfo.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

      
        }

        private void DisableAll()
        {
            txtRemarks.Enabled = false;
            txtMobileNo.Enabled = false;
            txtEmail.Enabled = false;
            chkWeb.Enabled = false;
            tr_Trade_Confirmation.Enabled = false;
            chkSmsTrade.Enabled = false;
            chkECharge.Enabled = false;
            dtRegDate.Enabled = false;
        }
        private void EnableAll()
        {
            txtClientCode.Enabled = true;
            txtRemarks.Enabled = true;
            txtMobileNo.Enabled = true;
            txtEmail.Enabled = true;
            chkWeb.Enabled = true;
             tr_Trade_Confirmation.Enabled = true;
            chkSmsTrade.Enabled = true;
            chkECharge.Enabled = true;
            dtRegDate.Enabled = true;

        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtClientCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "Return")
            {
                LoadSelectedInformation();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            currentMode = GlobalVariableBO.ModeSelection.UpdateMode;
            btnUpdate.Enabled = false;
            btnUpdate.BackColor = Color.Gray;
            btnNew.Enabled = true;
            btnNew.ResetBackColor();
            ClearAll();
            DisableAll();
            txtClientCode.Focus();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            currentMode = GlobalVariableBO.ModeSelection.NewMode;
            btnNew.Enabled = false;
            btnNew.BackColor = Color.Gray;
            btnUpdate.Enabled = true;
            btnUpdate.ResetBackColor();
            ClearAll();
            txtClientCode.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveServiceRegInfo();
            //UpdateRealTimeServiceRegistration();
        }

        private void UpdateRealTimeServiceRegistration()
        {
            SMSSyncBAL bal = new SMSSyncBAL();
            try
            {
                bal.Connect_SBP();
                bal.Connect_SMS();

                SqlDataReader DataReader = bal.GetIPO_ServiceRegistration_UITransApplied();
                bal.TruncateTable_SMSSyncExport_Confirmation_SMS_Reg_UITransApplied();
                bal.InsertTable_SMSSyncExport_Confirmation_SMS_Reg_UITransApplied(DataReader);

                bal.Commit_SBP();
                bal.Commit_SMS();
            }
            catch(Exception ex) 
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

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "Return")
            {
                SaveServiceRegInfo();
            }
        }

        private void txtClientCode_Leave(object sender, EventArgs e)
        {
            if (txtClientCode.Text.Equals(""))
                return;
            else
            {
                if (currentMode == GlobalVariableBO.ModeSelection.NewMode)
                {
                    LoadSelectedInformation();
                }
            }
        }

        private void GetServiceRegistationInfo(bool isUpdate)
        {
            try
            {
                ServiceRegistrationBAL objServiceRegistationBAL = new ServiceRegistrationBAL();
                DataTable data = new DataTable();

                data = objServiceRegistationBAL.GetServiceRegistationInfo(txtClientCode.Text);

                if (data.Rows.Count > 0)
                {
                    if (!data.Rows[0]["isReg"].ToString().Trim().Equals("NR") && currentMode == GlobalVariableBO.ModeSelection.NewMode)
                    {
                        MessageBox.Show("This Account is already Registered. Please update if required", "Exists Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtClientCode.Text = "";
                        txtClientCode.Focus();
                        return;
                    }

                    txtCustCode.Text = data.Rows[0]["Cust_Code"].ToString();
                    txtAccountHolderBOId.Text = data.Rows[0]["BO_ID"].ToString();
                    txtAccountHolderName.Text = data.Rows[0]["Cust_Name"].ToString();
                    txtWeb.Text = data.Rows[0]["Web"].ToString();
                    txtSms.Text = data.Rows[0]["Sms"].ToString();
                    txtEcharge.Text = data.Rows[0]["Trade"].ToString();
                    if (!isUpdate)
                    {
                        txtEmail.Text = data.Rows[0]["Email"].ToString();
                        txtMobileNo.Text = data.Rows[0]["Mobile"].ToString();
                    }
                }

                else
                {
                    txtCustCode.Text = "";
                    txtAccountHolderName.Text = "";
                    txtAccountHolderBOId.Text = "";
                    txtWeb.Text = "";
                    txtSms.Text = "";
                    txtEcharge.Text = "";
                    MessageBox.Show("No Customer Found.","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    txtClientCode.Focus();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void tr_Money_Deposit_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Parent != null)
            {
                if (e.Node.Checked == true && e.Node.Parent.Checked == false)
                {
                    IsChangedByUser = false;
                    e.Node.Parent.Checked = e.Node.Checked;
                }
                if (e.Node.Checked == false && e.Node.Parent.Checked == true)
                {
                    bool allNodeChecked = false;
                    foreach (TreeNode item in e.Node.Parent.Nodes)
                    {
                        if (item.Checked)
                        {
                            allNodeChecked = item.Checked;
                            break;
                        }
                    }
                    if (allNodeChecked == false)
                    {
                        IsChangedByUser = false;
                        e.Node.Parent.Checked = e.Node.Checked;
                    }
                }
            }
            else
            {
                if (IsChangedByUser)
                {
                    bool parent = e.Node.Checked;
                    foreach (TreeNode item in e.Node.Nodes)
                    {
                        item.Checked = parent;
                    }
                }
                else
                {
                    IsChangedByUser = true;
                }
            }
        }

        private void tr_Money_Withdraw_AfterCheck(object sender, TreeViewEventArgs e)
        {
           
            if (e.Node.Parent != null)
            {
                if (e.Node.Checked == true && e.Node.Parent.Checked == false)
                {
                    IsChangedByUser = false;
                    e.Node.Parent.Checked = e.Node.Checked;
                    //Eft Inactive
                    if(e.Node.Text=="SMS")
                        tr_Eft_Withdraw.Nodes[0].Nodes["Sms_Eft_Withdraw"].Checked = e.Node.Checked;
                    else if (e.Node.Text=="Email")
                        tr_Eft_Withdraw.Nodes[0].Nodes["Email_Eft_Withdraw"].Checked = e.Node.Checked;
                }
                else if (e.Node.Checked == false && e.Node.Parent.Checked == true)
                {
                    bool allNodeChecked = false;
                    foreach (TreeNode item in e.Node.Parent.Nodes)
                    {
                        if (item.Checked)
                        {
                            allNodeChecked = item.Checked;
                            break;
                        }
                    }

                    if (allNodeChecked == false)
                    {
                        IsChangedByUser = false;
                        e.Node.Parent.Checked = e.Node.Checked;
                        //Eft Inactive
                        tr_Eft_Withdraw.Nodes[0].Checked = e.Node.Checked;
                    }
                    //Eft Inactive
                    else
                    {
                        if (e.Node.Text == "SMS")
                            tr_Eft_Withdraw.Nodes[0].Nodes["Sms_Eft_Withdraw"].Checked = e.Node.Checked;
                        else if (e.Node.Text == "Email")
                            tr_Eft_Withdraw.Nodes[0].Nodes["Email_Eft_Withdraw"].Checked = e.Node.Checked;
                    }

                }
                //Eft Inactive
                else
                {
                    if (e.Node.Text == "SMS")
                        tr_Eft_Withdraw.Nodes[0].Nodes["Sms_Eft_Withdraw"].Checked = e.Node.Checked;
                    else if (e.Node.Text == "Email")
                        tr_Eft_Withdraw.Nodes[0].Nodes["Email_Eft_Withdraw"].Checked = e.Node.Checked;
                }
            }
            else
            {
                if (IsChangedByUser)
                {
                    bool parent = e.Node.Checked;
                   
                    foreach (TreeNode item in e.Node.Nodes)
                    {
                        item.Checked = parent;
                    }
                    //Eft Inactive
                    tr_Eft_Withdraw.Nodes[0].Checked = parent;
                }
                else
                {
                    IsChangedByUser = true;
                }
            }
        }

        private void tr_Eft_Withdraw_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Parent != null)
            {
                if (e.Node.Checked == true && e.Node.Parent.Checked == false)
                {
                    IsChangedByUser = false;
                    e.Node.Parent.Checked = e.Node.Checked;
                }
                if (e.Node.Checked == false && e.Node.Parent.Checked == true)
                {
                    bool allNodeChecked = false;
                    foreach (TreeNode item in e.Node.Parent.Nodes)
                    {
                        if (item.Checked)
                        {
                            allNodeChecked = item.Checked;
                            break;
                        }
                    }
                    if (allNodeChecked == false)
                    {
                        IsChangedByUser = false;
                        e.Node.Parent.Checked = e.Node.Checked;
                    }
                }
            }
            else
            {
                if (IsChangedByUser)
                {
                    bool parent = e.Node.Checked;
                    foreach (TreeNode item in e.Node.Nodes)
                    {
                        item.Checked = parent;
                    }
                }
                else
                {
                    IsChangedByUser = true;
                }
            }
        }

        private void tr_Trade_Confirmation_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Parent != null)
            {
                if (e.Node.Checked == true && e.Node.Parent.Checked == false)
                {
                    IsChangedByUser = false;
                    e.Node.Parent.Checked = e.Node.Checked;
                }
                if (e.Node.Checked == false && e.Node.Parent.Checked == true)
                {
                    bool allNodeChecked = false;
                    foreach (TreeNode item in e.Node.Parent.Nodes)
                    {
                        if (item.Checked)
                        {
                            allNodeChecked = item.Checked;
                            break;
                        }
                    }
                    if (allNodeChecked == false)
                    {
                        IsChangedByUser = false;
                        e.Node.Parent.Checked = e.Node.Checked;
                    }
                }
            }
            else
            {
                if (IsChangedByUser)
                {
                    bool parent = e.Node.Checked;
                    foreach (TreeNode item in e.Node.Nodes)
                    {
                        item.Checked = parent;
                    }
                }
                else
                {
                    IsChangedByUser = true;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearAll();
            txtClientCode.Focus();
        }

        private void btn_WebUplod_Click(object sender, EventArgs e)
        {

            try
            {
                ServiceRegistrationBAL serviceRegBal = new ServiceRegistrationBAL();

                if (txtCustCode.Text != string.Empty)
                {
                    string custcode = txtClientCode.Text;
                    SaveServiceRegInfo();
                    serviceRegBal.Post_For_WebUPdate(custcode);

                    MessageBox.Show("Set for Web Update Customer Service Information Successfully !!!");
                }
                else
                {
                    MessageBox.Show("Select A Customer For Web Update data !!!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Set for Web Update Customer Service Information Unsuccessfully  !!!"+ " "+ex);
            }
        }
    }
}
