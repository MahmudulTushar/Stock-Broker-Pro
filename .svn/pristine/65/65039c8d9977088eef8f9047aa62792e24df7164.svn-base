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
    public partial class frmSpecialClientDashboard : Form
    {
        private string hide_imit;
        public List<string > InsertUser=new List<string>();
        public List<string> DeleteUser = new List<string>();

        public frmSpecialClientDashboard()
        {
            InitializeComponent();
        }

        public frmSpecialClientDashboard(string hidelimit)
        {
            InitializeComponent();
            hide_imit = hidelimit;
            if (hide_imit == "Hide")
                this.Text = "Hide Accounts Set";
        }
        
        private int criteriaID;
        private int resource_ID;
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSpecialClientDashboard_Load(object sender, EventArgs e)
        {
        
            // GetUserList();
            GetResourceList();
            try
            {
                if (hide_imit == "Limit" || hide_imit == null)
                {
                    //GetLimitedClientList(InsertUser, resource_ID, criteriaID);
                }
                else
                {
                    //GetHiddenClientList(InsertUser, resource_ID, criteriaID);
                }
            }
            catch
            {
                
            }
        }

        //private void GetUserList()
        //{
        //    try
        //    {
        //        UserManagementBAL objUserManagementBAL = new UserManagementBAL();
        //        DataTable data = new DataTable();
        //        data = objUserManagementBAL.GetUserList();
        //        ddlUserName.DataSource = data;
        //        ddlUserName.ValueMember = "User_Name";
        //        ddlUserName.DisplayMember = "User_Name";
        //        ddlUserName.SelectedIndex = 0;
        //    }
        //    catch (Exception ex)
        //    {

        //        MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}
        private void GetResourceList()
        {
            UserManagementBAL objUserManagementBAL = new UserManagementBAL();
            DataTable data = new DataTable();
            DataTable dtuser=new DataTable();
            data = objUserManagementBAL.GetResourceList();
            dtuser = objUserManagementBAL.GetUserList("");
            //              ddlResourceName.DataSource = data;
            for (int i = 0; i < data.Rows.Count; i++)
            {
                int x = dgvcriteria.Rows.Add();
                dgvcriteria.Rows[x].Cells["ResourceID"].Value = data.Rows[i]["Resource_ID"].ToString();
                dgvcriteria.Rows[x].Cells["Criteria_ID"].Value = data.Rows[i]["Criteria_ID"].ToString();
                dgvcriteria.Rows[x].Cells["ResourceName"].Value = data.Rows[i]["Resource_Name"].ToString();
            }

            //               ddlResourceName.ValueMember = data.Columns[0].ToString();
            //             ddlResourceName.DisplayMember =  data.Columns[1].ToString();
            //             ddlResourceName.SelectedIndex = 0;
        }
        ////public void GetLimitedClientList()
        ////{
        ////    try
        ////    {
        ////        LimitedDashboardBAL objLimitedDashboardBAL = new LimitedDashboardBAL();
        ////        DataTable data = new DataTable();
        ////        //if (criteriaID == 0)
        ////        //    criteriaID = 1;
        ////        data = objLimitedDashboardBAL.GetLimitedClientList(ddlUserName.Text, Convert.ToInt32(ddlResourceName.SelectedValue), criteriaID);
        ////        dgvLimitedClient.DataSource = data;
        ////        dgvLimitedClient.Columns[0].Visible = false;
        ////        dgvLimitedClient.Columns["Entry Date"].DefaultCellStyle.Format = "dd MMM yyyy";
        ////        dgvLimitedClient.Columns["Entry Date"].DefaultCellStyle.Alignment =
        ////        DataGridViewContentAlignment.MiddleRight;
        ////        lblUserName.Text = "User Name : " + ddlUserName.Text;
        ////        lblRecord.Text = "Record : " + dgvLimitedClient.Rows.Count;
        ////    }
        ////    catch
        ////    {
        ////    }
        ////}
        
        //public void GetLimitedClientList(List<string> username,int resourceid,int criteriaid)
        //{
        //    try
        //    {
        //        LimitedDashboardBAL objLimitedDashboardBAL = new LimitedDashboardBAL();
        //        DataTable data = new DataTable();
        //        //if (criteriaID == 0)
        //        //    criteriaID = 1;
        //        data = objLimitedDashboardBAL.GetLimitedClientList(InsertUser, resourceid, criteriaid);
        //        dgvLimitedClient.DataSource = data;
        //        if (data.Rows.Count > 0)
        //        {
        //            dgvLimitedClient.Columns[0].Visible = false;
        //            dgvLimitedClient.Columns["Entry Date"].DefaultCellStyle.Format = "dd MMM yyyy";
        //            dgvLimitedClient.Columns["Entry Date"].DefaultCellStyle.Alignment =
        //            DataGridViewContentAlignment.MiddleRight;
        //            // lblUserName.Text = "User Name : " + ddlUserName.Text;
        //            lblRecord.Text = "Record : " + dgvLimitedClient.Rows.Count;
        //        }
        //    }
        //    catch
        //    {
        //    }
        //}
       // private void GetHiddenClientList(List<string> username, int resourceid, int criteriaid)
       // {
       //     try
       //     {
       //         HideCustomerBAL hideCustomerBal = new HideCustomerBAL();
       //         DataTable datatable = hideCustomerBal.GetGridData(username, resourceid, criteriaid);
       //         dgvLimitedClient.DataSource = datatable;
       //         dgvLimitedClient.Columns[0].Visible = false;
       //         dgvLimitedClient.Columns["Entry Date"].DefaultCellStyle.Format = "dd MMM yyyy";
       //         dgvLimitedClient.Columns["Entry Date"].DefaultCellStyle.Alignment =
       //         DataGridViewContentAlignment.MiddleRight;
       ////         lblUserName.Text = "User Name : " + ddlUserName.Text;
       //         lblRecord.Text = "Record : " + dgvLimitedClient.Rows.Count;

       //     }
       //     catch
       //     {

       //     }

       // }

       // //private void GetCustmerInfo()
       // //{
       // //    try
       // //    {
       // //        if (txtClientCode.Text.Trim() == string.Empty)
       // //        {
       // //            MessageBox.Show("Cilent Indentfication Code Required.", "Client Information", MessageBoxButtons.OK,
       // //                            MessageBoxIcon.Information);
       // //            txtClientCode.Focus();
       // //        }

       // //        else
       // //        {
       // //            CustomerBAL objCustomerBAL = new CustomerBAL();
       // //            DataTable data = new DataTable();
       // //            data = objCustomerBAL.GetCustomerInfo(txtClientCode.Text);

       // //            if (data.Rows.Count > 0)
       // //            {
       // //                txtName.Text = data.Rows[0]["CustName"].ToString();
       // //                txtFinalCustCode.Text = data.Rows[0]["Cust_Code"].ToString();
       // //                txtClientStatus.Text = data.Rows[0]["Status"].ToString();
       // //                txtBOID.Text = data.Rows[0]["BO_ID"].ToString();

       // //                if (txtClientStatus.Text.Equals("Active"))
       // //                {
       // //                    txtClientStatus.BackColor = Color.DarkGreen;
       // //                    txtClientStatus.ForeColor = Color.White;
       // //                }

       // //                else
       // //                {
       // //                    txtClientStatus.BackColor = Color.DarkSalmon;
       // //                    txtClientStatus.ForeColor = Color.White;
       // //                }
       // //            }

       // //            else
       // //            {
       // //                MessageBox.Show("No Client Found.", "Client Information", MessageBoxButtons.OK,
       // //                          MessageBoxIcon.Information);
       // //                txtClientCode.Focus();
       // //            }
       // //        }


       // //    }
       // //    catch (Exception ex)
       // //    {

       // //        MessageBox.Show(ex.Message);
       // //    }
       // //}

       // //private void txtClientCode_KeyDown(object sender, KeyEventArgs e)
       // //{
       // //    if (e.KeyCode.ToString() == "Return")
       // //    {
       // //        GetCustmerInfo();
       // //    }
       // //}

       // //private void btnAdd_Click(object sender, EventArgs e)
       // //{
       // //    string referenceCode = string.Empty;
       // //    bool result = false;
       // //    try
       // //    {
       // //        //if(ddlUserName.Text.Trim()==string.Empty)
       // //        //{
       // //        //    MessageBox.Show("User Name Required to Limit the Client from Dashboard",
       // //        //                   "Limited Dashboard", MessageBoxButtons.OK, MessageBoxIcon.Information);
       // //        //    ddlUserName.Focus();
       // //        //}

       // //        //else if (ddlResourceName.Text.Trim() == string.Empty)
       // //        //{
       // //        //    MessageBox.Show("Resource Name Required to Limit the Client from Dashboard",
       // //        //                   "Limited Dashboard", MessageBoxButtons.OK, MessageBoxIcon.Information);
       // //        //    ddlResourceName.Focus();
       // //        //}

       // //        //else if(txtFinalCustCode.Text.Trim()==String.Empty)
       // //        //{
       // //        //    MessageBox.Show("Client Code Required to Limit the client\n from the Limited Dashboard",
       // //        //                    "Limited Dashboard", MessageBoxButtons.OK, MessageBoxIcon.Information);
       // //        //    txtClientCode.Focus();
       // //        //}
       // //        if (criteriaID == 2)
       // //        {
       // //            if (ddlCriteriaID.Text == "")
       // //            {
       // //                MessageBox.Show("Branch Name Required");
       // //                return;
       // //            }
       // //            else
       // //            {
       // //                referenceCode = ddlCriteriaID.SelectedValue.ToString();
       // //            }

       // //        }
       // //        else if (criteriaID == 3)
       // //        {
       // //            if (ddlCriteriaID.Text == "")
       // //            {
       // //                MessageBox.Show("Workstation Name Required");
       // //                return;
       // //            }
       // //            else
       // //            {
       // //                if (ddlCriteriaID.Text == "All")
       // //                    referenceCode = "0";
       // //                else
       // //                    referenceCode = ddlCriteriaID.Text;
       // //            }


       // //        }
       // //        else if (criteriaID == 1)
       // //        {
       // //            if (txtFinalCustCode.Text == "")
       // //            {
       // //                MessageBox.Show("CustCode Required");
       // //                return;
       // //            }
       // //            else
       // //            {
       // //                referenceCode = txtFinalCustCode.Text;
       // //                criteriaID = 1;
       // //            }


       // //        }

       // //        //else
       // //        //{
       // //        LimitedDashboardBAL objLimitedClientDashboardBAL = new LimitedDashboardBAL();

       // //        if (criteriaID == 2)
       // //        {
       // //            result = objLimitedClientDashboardBAL.IsExists(ddlUserName.Text, referenceCode,
       // //                                                   Convert.ToInt32(ddlResourceName.SelectedValue), criteriaID);
       // //        }
       // //        else if (criteriaID == 3)
       // //        {
       // //            result = objLimitedClientDashboardBAL.IsExists(ddlUserName.Text, referenceCode,
       // //                                                   Convert.ToInt32(ddlResourceName.SelectedValue), criteriaID);
       // //        }
       // //        else if (criteriaID == 1)
       // //        {
       // //            result = objLimitedClientDashboardBAL.IsExists(ddlUserName.Text, referenceCode,
       // //                                                           Convert.ToInt32(ddlResourceName.SelectedValue));
       // //        }
       // //        //     if (objLimitedClientDashboardBAL.IsExists(ddlUserName.Text, referenceCode, Convert.ToInt32(ddlResourceName.SelectedValue)) == false)


       // //        if (result == false)
       // //        {
       // //            if (MessageBox.Show("Do you want to Limit the Client from Dashboard ?", "Limited Dashboard", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
       // //            {

       // //                objLimitedClientDashboardBAL.InsertLimitedClientIntoDashboard(ddlUserName.Text, Convert.ToInt32(ddlResourceName.SelectedValue), referenceCode, criteriaID);
       // //                MessageBox.Show("Sucessfully Limited the Client from Dashboard", "Limited Dashboard",
       // //                                MessageBoxButtons.OK, MessageBoxIcon.Information);
       // //          //      GetLimitedClientList();
       // //                if (txtClientCode.Text != "")
       // //                    ClearText();
       // //                // criteriaID = 0;
       // //            }
       // //        }

       // //        else
       // //        {
       // //            MessageBox.Show("Data already Limited from Dashboard", "Limited Dashboard",
       // //                                MessageBoxButtons.OK, MessageBoxIcon.Information);
       // //        }


       // //        // }
       // //    }
       // //    catch (Exception ex)
       // //    {

       // //        MessageBox.Show(ex.Message);
       // //    }
       // //}
       // //private void ClearText()
       // //{
       // //    txtClientCode.Text = "";
       // //    txtFinalCustCode.Text = "";
       // //    txtName.Text = "";
       // //    txtClientStatus.Text = "";
       // //    txtBOID.Text = "";
       // //}
        //private void btnDelete_Click(object sender, EventArgs e)
        //{
        //    if (dgvLimitedClient.Rows.Count > 0)
        //    {
        //        int deleteID = Int32.Parse(dgvLimitedClient.SelectedRows[0].Cells[0].Value.ToString());
        //        DeleteClient(deleteID);
        //    }
        //    else
        //    {
        //        MessageBox.Show("No Client Exists for the User.", "Limited Dashboard.", MessageBoxButtons.OK,
        //                        MessageBoxIcon.Information);
        //    }
        //}

        //private void DeleteClient(int deleteID)
        //{
        //    try
        //    {
        //        if (MessageBox.Show("Do you want to Delete the client from the Limited Dashboard?", "Limited Dashboard", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        //        {
        //            LimitedDashboardBAL objLimitedDashboardBAL = new LimitedDashboardBAL();
        //            HideCustomerBAL hideCustomerBal = new HideCustomerBAL();
        //            if (hide_imit == "Limit" || hide_imit == null)
        //            {
        //                objLimitedDashboardBAL.DeleteClientFromLimitedDashBoard(deleteID);
        //            }
        //            else
        //            {
        //                hideCustomerBal.DeleteClientFromHiddenDashBoard(deleteID); 
        //            }
        //            MessageBox.Show("Sucessfully Deleted the Client from the Limited Dashboard.", "Delete Operation",
        //                            MessageBoxButtons.OK, MessageBoxIcon.None);
        //            if (hide_imit == "Limit" || hide_imit == null)
        //            {
        //                GetLimitedClientList(InsertUser, resource_ID, criteriaID);
        //            }
        //            else
        //            {
        //                GetHiddenClientList(InsertUser, resource_ID, criteriaID);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        MessageBox.Show(ex.Message);
        //    }
        //}

        private void ddlUserName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (hide_imit == "Limit" || hide_imit == null)
                {
                    //GetLimitedClientList(InsertUser, resource_ID, criteriaID);
                }
                else
                {
                    //GetHiddenClientList(InsertUser, resource_ID, criteriaID);
                }
            }
            catch
            {
            }
        }

        private void ddlResourceName_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    SetCriteriaState(Convert.ToInt32(ddlResourceName.SelectedValue));
            //    GetLimitedClientList();
            //}
            //catch
            //{
            //}
        }
        //private void SetCriteriaState(int resourceID)
        //{
        //    CriteriaListBAL criteriaListBAL = new CriteriaListBAL();
        //    DataTable data = new DataTable();
        //    //criteriaID = 0;
        //    criteriaID = criteriaListBAL.GetCriteriaID(resourceID);
        //    if (criteriaID == 2)
        //    {
        //        data = criteriaListBAL.GetBranchList();
        //        DataRow dr = data.NewRow();
        //        dr["Branch_ID"] = 0;
        //        dr["Branch_Name"] = "All";

        //        data.Rows.InsertAt(dr, 0);

        //        ddlCriteriaID.DataSource = null;
        //        ddlCriteriaID.DataSource = data;
        //        //for (int i = 0; i < data.Rows.Count; i++)
        //        //{
        //        //    ddlCriteriaID.Items.Add(data.Rows[i][1].ToString());
        //        //}
        //        ddlCriteriaID.ValueMember = data.Columns[0].ToString();
        //        ddlCriteriaID.DisplayMember = data.Columns[1].ToString();
        //        ddlCriteriaID.Visible = true;
        //        txtClientCode.Visible = false;
        //        lblClientCode.Text = "Branch Name:";
        //    }
        //    else if (criteriaID == 3)
        //    {
        //        data = criteriaListBAL.GetWorkStationList();
        //        DataRow dr = data.NewRow();
        //        dr["WorkStation_Name"] = "All";

        //        data.Rows.InsertAt(dr, 0);

        //        ddlCriteriaID.DataSource = null;
        //        ddlCriteriaID.DataSource = data;

        //        //for (int i = 0; i < data.Rows.Count; i++)
        //        //{
        //        //    ddlCriteriaID.Items.Add(data.Rows[i][0].ToString());
        //        //}
        //        ddlCriteriaID.ValueMember = data.Columns[0].ToString();
        //        ddlCriteriaID.DisplayMember = data.Columns[0].ToString();
        //        ddlCriteriaID.Visible = true;
        //        txtClientCode.Visible = false;
        //        lblClientCode.Text = "Workstation Name:";
        //    }
        //    else
        //    {
        //        ddlCriteriaID.Visible = false;
        //        txtClientCode.Visible = true;
        //        ddlCriteriaID.DataSource = null;
        //        lblClientCode.Text = "Client Code :";
        //    }

        //}

        private void dgvcriteria_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CriteriaListBAL criteriaListBAL = new CriteriaListBAL();
            DataTable dtTable = new DataTable();
            criteriaID = criteriaListBAL.GetCriteriaID(Convert.ToInt32(dgvcriteria[1, e.RowIndex].Value));
            resource_ID = Convert.ToInt32(dgvcriteria[1, e.RowIndex].Value);
            if ((dgvcriteria.CurrentCell.ColumnIndex == 5 || dgvcriteria.CurrentCell.ColumnIndex == 4) &&
                     (dgvcriteria.Rows[e.RowIndex].Cells["Select"].EditedFormattedValue != null &&
                      (bool)dgvcriteria.Rows[e.RowIndex].Cells["Select"].EditedFormattedValue == false))
            {
                MessageBox.Show("Please Select Resource first");
                return;
            }
            if (dgvcriteria.Rows[e.RowIndex].Cells["Select"].EditedFormattedValue != null &&
                (bool) dgvcriteria.Rows[e.RowIndex].Cells["Select"].EditedFormattedValue == true &&
                (hide_imit == "Limit" || hide_imit == null))
            {
                //GetLimitedClientList(InsertUser, resource_ID, criteriaID);
            }
            else if (dgvcriteria.Rows[e.RowIndex].Cells["Select"].EditedFormattedValue != null &&
                     (bool) dgvcriteria.Rows[e.RowIndex].Cells["Select"].EditedFormattedValue == true && hide_imit == "Hide")
            {
                //GetHiddenClientList(InsertUser, resource_ID, criteriaID);
            }
            else
            {
                //criteriaID = 0;
                //resource_ID = 0;
                //dgvLimitedClient.DataSource = dtTable;
            }
            if (dgvcriteria.CurrentCell.ColumnIndex == 4 &&
                (dgvcriteria.Rows[e.RowIndex].Cells["Select"].EditedFormattedValue != null &&
                 (bool) dgvcriteria.Rows[e.RowIndex].Cells["Select"].EditedFormattedValue == true))
            {
                InsertUser.Clear();
                DeleteUser.Clear();
                frmAddUser adduser = new frmAddUser(hide_imit, resource_ID);
                adduser.Show();
            }

            if (dgvcriteria.CurrentCell.ColumnIndex == 5 &&
                (dgvcriteria.Rows[e.RowIndex].Cells["Select"].EditedFormattedValue != null &&
                 (bool) dgvcriteria.Rows[e.RowIndex].Cells["Select"].EditedFormattedValue == true))
            {
                frmAddReferenceCode addrefcode = new frmAddReferenceCode(InsertUser,DeleteUser, resource_ID, criteriaID,
                                                                         hide_imit);
                addrefcode.Show();
            }
            //else 
        }

        private void dgvcriteria_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //if (dgvcriteria.CurrentCell.ColumnIndex == 4)
            //{
            //    if (e.Control is Button)
            //    {
            //        Button btnAddReferenceCode;
            //        btnAddReferenceCode = e.Control as Button;
            //        btnAddReferenceCode.Click += new EventHandler(btnAddReferenceCode_Click);
            //    }

            //}
        }
        //private void btnAddReferenceCode_Click(object sender, EventArgs e)
        //{
        //    frmAddReferenceCode addrefcode = new frmAddReferenceCode(Resource_ID,criteriaID);
        //    addrefcode.Show();
        //}
    }
}
