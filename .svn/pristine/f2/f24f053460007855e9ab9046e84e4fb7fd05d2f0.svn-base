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
    public partial class HideCustomer : Form
    {
        private int _SlNo;
        private string menuName;
        public HideCustomer(string MenuName)
        {
            InitializeComponent();
            menuName = MenuName;
        }
        private int criteriaID;

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HideCustomer_Load(object sender, EventArgs e)
        {
            Init();
            ResetAll();
            GetUserList();
            GetResourceList();
            ddlSearchCustomer.SelectedIndex = 0;
            txtSearchCustomer.Focus();
 //           LoadDataIntoGrid();
        }
        private void GetUserList()
        {
            try
            {
                HideCustomerBAL hideCustomerBal = new HideCustomerBAL();
                DataTable data = new DataTable();
                data = hideCustomerBal.GetUserList();
                ddlUserName.DataSource = data;
                ddlUserName.ValueMember = "User_Name";
                ddlUserName.DisplayMember = "User_Name";
                ddlUserName.SelectedIndex = 0;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void GetResourceList()
        {
            HideCustomerBAL hideCustomerBal = new HideCustomerBAL();
            DataTable data = new DataTable();
            data = hideCustomerBal.GetResourceList();
            ddlResourceName.DataSource = data;
            ddlResourceName.ValueMember = data.Columns[0].ToString();
            ddlResourceName.DisplayMember = data.Columns[1].ToString();
            ddlResourceName.SelectedIndex = 0;
        }

        private void Init()
        {
            btnRemove.Enabled = false;
            btnAdd.Enabled = true;
          
        }

        //private void LoadDataIntoGrid()
        //{
        //    try
        //    {
        //        HideCustomerBAL hideCustomerBal = new HideCustomerBAL();
        //        DataTable datatable = hideCustomerBal.GetGridData(ddlUserName.Text, Convert.ToInt32(ddlResourceName.SelectedValue), criteriaID);
        //        dtgHiddenCustomer.DataSource = datatable;
        //        this.dtgHiddenCustomer.Columns[0].Visible = false;
        //        dtgHiddenCustomer.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        //        lblRecord.Text = "Total Record : " + dtgHiddenCustomer.Rows.Count;

        //    }
        //    catch 
        //    {
                
        //    }

        //}
        private void ClearText()
        {
            txtSearchCustomer.Text = "";
            txtCustCode.Text = "";
            txtAccountHolderName.Text = "";
            txtAccountHolderBOId.Text = "";
        }
        //private void btnAdd_Click(object sender, EventArgs e)
        //{
        //    //if(txtCustCode.Text.Trim()=="")
        //    //{
        //    //    MessageBox.Show("Select a Customer Code.", "Warning");
        //    //    return;
        //    //}
        //    //if(txtSearchCustomer.Text.Trim()!=txtCustCode.Text.Trim())
        //    //{
        //    //    MessageBox.Show("Press Enter to Load the customer.", "Warning.");
        //    //    return;
        //    //}
        //    HideCustomerBAL objHideCustomerBAL = new HideCustomerBAL();
        //    string referenceCode = string.Empty;
        //    bool result = false;
        //    try
        //    {
        //        if(criteriaID==2)
        //        {
        //            if (ddlCriteriaID.Text=="")
        //            {
        //                MessageBox.Show("Branch Name Required");
        //                return;
        //            }
        //            else
        //            {
        //                referenceCode = ddlCriteriaID.SelectedValue.ToString();
        //            }
                    
        //        }
        //        else if (criteriaID == 3)
        //        {
        //            if (ddlCriteriaID.Text == "")
        //            {
        //                MessageBox.Show("Workstation Name Required");
        //                return;
        //            }
        //            else
        //            {
        //                if (ddlCriteriaID.Text == "All")
        //                    referenceCode = "0";
        //                else
        //                    referenceCode = ddlCriteriaID.Text;
        //            }
 
                    
        //        }
        //        else if (criteriaID == 1)
        //        {
        //            if (txtSearchCustomer.Text == "")
        //            {
        //                MessageBox.Show("CustCode Required");
        //                return;
        //            }
        //            else
        //            {
        //                if(ddlSearchCustomer.SelectedIndex==1)
        //                {
        //                    referenceCode = objHideCustomerBAL.GetCustCodeByBOID(txtSearchCustomer.Text);
        //                    criteriaID = 1; 
        //                }
        //                else
        //                {
        //                    referenceCode = txtSearchCustomer.Text;
        //                    criteriaID = 1; 
        //                }
        //            }

                    
        //        }

        //        //else
        //        //{

        //            if (criteriaID == 2)
        //            {
        //                result = objHideCustomerBAL.IsExists(ddlUserName.Text, referenceCode,
        //                                                      Convert.ToInt32(ddlResourceName.SelectedValue),criteriaID);
        //            }
        //            else if (criteriaID == 3)
        //            {
        //                result = objHideCustomerBAL.IsExists(ddlUserName.Text, referenceCode,
        //                                                      Convert.ToInt32(ddlResourceName.SelectedValue),criteriaID);
        //            }
        //            else if (criteriaID == 1)
        //            {
        //                result = objHideCustomerBAL.IsExists(ddlUserName.Text, referenceCode,
        //                                                               Convert.ToInt32(ddlResourceName.SelectedValue));
        //            }
        //       //     if (objLimitedClientDashboardBAL.IsExists(ddlUserName.Text, referenceCode, Convert.ToInt32(ddlResourceName.SelectedValue)) == false)
        //            if (result == false)
        //            {
        //                if (MessageBox.Show(@"Do you want to Limit the Client from Dashboard ?", @"Limited Dashboard", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        //                {

        //                    objHideCustomerBAL.SaveHideCustomer(referenceCode, ddlUserName.Text, Convert.ToInt32(ddlResourceName.SelectedValue), criteriaID);
        //                    MessageBox.Show(@"Customer has hidden successfully.", @"Success");
        //                    LoadDataIntoGrid();
        //                    //if (txtClientCode.Text != "")
        //                    ClearText();
        //                    // criteriaID = 0;
        //                }
        //            }

        //            else
        //            {
        //                MessageBox.Show(@"Data already Hidden from Dashboard", @"Hidden Dashboard",
        //                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            }


        //        // }
        //    }
        //    catch (Exception ex)
        //    {

        //        MessageBox.Show(ex.Message);
        //    }


        //  //  SaveHideCustomer();
        //}

        //private void SaveHideCustomer()
        //{
        //    try
        //    {
        //        HideCustomerBAL hideCustomerBal = new HideCustomerBAL();
        //        if (IsHidden())
        //        {
        //            hideCustomerBal.SaveHideCustomer(referenceCode, ddlUserName.Text, Convert.ToInt32(ddlResourceName.SelectedValue), criteriaID);
        //            MessageBox.Show("Customer has hidden successfully.", "Success");
        //            LoadDataIntoGrid();
        //        }
        //        else
        //        {
        //            MessageBox.Show("The Customer has allready hidden.");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Can not hide the customer. Error: " + ex.Message, "Failed");
        //    }

        //}

        private bool IsHidden()
        {
            HideCustomerBAL hideCustomerBal = new HideCustomerBAL();
            if (hideCustomerBal.CheckDuplicate(txtCustCode.Text,ddlUserName.Text,Convert.ToInt32(ddlResourceName.SelectedValue)))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btnResetBasicInfo_Click(object sender, EventArgs e)
        {
            Init();
        }

        private void dtgHiddenCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnAdd.Enabled = false;
            btnRemove.Enabled = true;
            foreach (DataGridViewRow row in this.dtgHiddenCustomer.SelectedRows)
            {
               txtCustCode.Text=dtgHiddenCustomer[1, row.Index].Value.ToString();
               txtSearchCustomer.Text = dtgHiddenCustomer[1, row.Index].Value.ToString();
                _SlNo = Convert.ToInt32(dtgHiddenCustomer[0, row.Index].Value);
                HideCustomerBAL hideCustomerBal=new HideCustomerBAL();
                DataTable dataTable=new DataTable();
                dataTable=hideCustomerBal.GetCustomerDetails(txtCustCode.Text, 1);
                if (dataTable.Rows.Count > 0)
                {
                    txtAccountHolderBOId.Text = dataTable.Rows[0][1].ToString();
                    txtAccountHolderName.Text = dataTable.Rows[0][2].ToString();
                    txtSearchCustomer.SelectAll();
                }
            }   
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(@"Do you want to continue to Delete the Customer: " + txtAccountHolderName.Text + "?", "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    HideCustomerBAL hideCustomerBal = new HideCustomerBAL();
                    hideCustomerBal.DeleteClientFromHiddenDashBoard(_SlNo);
                    MessageBox.Show(@"Hidden Customer visible successfully.", @"Success");
                    ClearText();
                  //  LoadDataIntoGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(@"Can not visible the hidden customer. Error: " + ex.Message, @"Failed");
                }
            }

        }
        private void btnGo_Click(object sender, EventArgs e)
        {
            GetCustomerDetails();
        }
        private void GetCustomerDetails()
         {
            HideCustomerBAL hideCustomerBal = new HideCustomerBAL();
            DataTable dataTable;
            if(ddlSearchCustomer.SelectedIndex == 0)
            {
                dataTable = hideCustomerBal.GetCustomerDetails(txtSearchCustomer.Text, 1);
            }
            else
            {
                dataTable = hideCustomerBal.GetCustomerDetails(txtSearchCustomer.Text, 0);
            }

            if(dataTable.Rows.Count>0)
            {
                txtCustCode.Text = dataTable.Rows[0][0].ToString();
                txtAccountHolderBOId.Text = dataTable.Rows[0][1].ToString();
                txtAccountHolderName.Text = dataTable.Rows[0][2].ToString();
                txtSearchCustomer.SelectAll();
                
            }
            else
            {
                ResetAll();
            }
    
             
         }

        private void ResetAll()
        {
            txtCustCode.Text = "";
            txtAccountHolderBOId.Text = "";
            txtAccountHolderName.Text = "";
            txtSearchCustomer.SelectAll();
        }

        private void ddlSearchCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "Return")
            {
                GetCustomerDetails();
            }
        }

        private void ddlUserName_SelectedIndexChanged(object sender, EventArgs e)
        {
     //       LoadDataIntoGrid();
        }

        private void ddlResourceName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SetCriteriaState(Convert.ToInt32(ddlResourceName.SelectedValue));
 //               LoadDataIntoGrid();
            }
            catch
            {
            }

        }
        private void SetCriteriaState(int resourceID)
        {
            CriteriaListBAL criteriaListBAL = new CriteriaListBAL();
            DataTable data = new DataTable();
            //criteriaID = 0;
            criteriaID = criteriaListBAL.GetCriteriaID(resourceID);
            if (criteriaID == 2)
            {
                data = criteriaListBAL.GetBranchList();
                DataRow dr = data.NewRow();
                dr["Branch_ID"] = 0;
                dr["Branch_Name"] = "All";

                data.Rows.InsertAt(dr, 0);
                ddlCriteriaID.DataSource = null;
                ddlCriteriaID.DataSource = data;
                //for (int i = 0; i < data.Rows.Count; i++)
                //{
                //    ddlCriteriaID.Items.Add(data.Rows[i][1].ToString());
                //}
                ddlCriteriaID.ValueMember = data.Columns[0].ToString();
                ddlCriteriaID.DisplayMember = data.Columns[1].ToString();
                ddlCriteriaID.Visible = true;
                lblCriteriaName.Text = "Branch Name :";
                lblCriteriaName.Visible = true;
                txtSearchCustomer.Visible = false;
                ddlSearchCustomer.Visible = false;
            }
            else if (criteriaID == 3)
            {
                data = criteriaListBAL.GetWorkStationList();

                DataRow dr = data.NewRow();
                dr["WorkStation_Name"] = "All";

                data.Rows.InsertAt(dr, 0);

                ddlCriteriaID.DataSource = null;
                ddlCriteriaID.DataSource = data;

                //for (int i = 0; i < data.Rows.Count; i++)
                //{
                //    ddlCriteriaID.Items.Add(data.Rows[i][0].ToString());
                //}
                ddlCriteriaID.ValueMember = data.Columns[0].ToString();
                ddlCriteriaID.DisplayMember = data.Columns[0].ToString();
                ddlCriteriaID.Visible = true;
                lblCriteriaName.Text = "Workstation Name :";
                lblCriteriaName.Visible = true;
                txtSearchCustomer.Visible = false;
                ddlSearchCustomer.Visible = false;
            }
            else
            {
                ddlCriteriaID.Visible = false;
                txtSearchCustomer.Visible = true;
                ddlCriteriaID.DataSource = null;
                lblCriteriaName.Visible = false;
                ddlSearchCustomer.Visible = true;
            }

        }

          

        private void txtSearchCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
                GetCustomerDetails();
        }

 
    }
}
