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
    public partial class frmAddReferenceCode : Form
    {
        private int resourceid;
        private int criteriaid;
        private List<string > Insertusername=new List<string>();
        private List<string> Deleteusername = new List<string>();

        List<bool> result;
        int increment;

        private string MenuName;
        string referenceCode = string.Empty;

        public frmAddReferenceCode(List<string> InsertuserName, List<string> DeleteuserName, int resourceID, int criteriaID, string menuname)
        {
            InitializeComponent();
            Insertusername = InsertuserName;
            Deleteusername = DeleteuserName;
            resourceid = resourceID;
            criteriaid = criteriaID;
            MenuName = menuname;
        }

        private void txtClientCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "Return")
            {
                GetCustmerInfo();
            }

        }
        private void GetCustmerInfo()
        {
            try
            {
                if (txtClientCode.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Cilent Indentfication Code Required.", "Client Information", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    txtClientCode.Focus();
                }

                else
                {
                    CustomerBAL objCustomerBAL = new CustomerBAL();
                    DataTable data = new DataTable();
                    data = objCustomerBAL.GetCustomerInfo(txtClientCode.Text);

                    if (data.Rows.Count > 0)
                    {
                        txtName.Text = data.Rows[0]["CustName"].ToString();
                        txtFinalCustCode.Text = data.Rows[0]["Cust_Code"].ToString();
                        txtClientStatus.Text = data.Rows[0]["Status"].ToString();
                        txtBOID.Text = data.Rows[0]["BO_ID"].ToString();

                        if (txtClientStatus.Text.Equals("Active"))
                        {
                            txtClientStatus.BackColor = Color.DarkGreen;
                            txtClientStatus.ForeColor = Color.White;
                        }

                        else
                        {
                            txtClientStatus.BackColor = Color.DarkSalmon;
                            txtClientStatus.ForeColor = Color.White;
                        }
                    }

                    else
                    {
                        MessageBox.Show("No Client Found.", "Client Information", MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);
                        txtClientCode.Focus();
                    }
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void GetGridData(string menuname)
        {
            UserManagementBAL objUserManagementBAL = new UserManagementBAL();
            DataTable data = new DataTable();
            SetCriteriaState();
            data = objUserManagementBAL.GetRestrictedReferenceCodeList(resourceid, menuname, Insertusername);
            dgvReferenceCode.DataSource = data;
        }

        private void frmAddReferenceCode_Load(object sender, EventArgs e)
        {
            if (MenuName != "" || MenuName !=null)
            {
                this.Text = "Add Reference Code " + "For Hide Customer Dashboard";
            }
            else
            {
                this.Text = "Add Reference Code " + "For Limited Customer Dashboard"; 
            }
            GetGridData(MenuName);
        }
        private void SetCriteriaState()
        {
            CriteriaListBAL criteriaListBAL = new CriteriaListBAL();
            DataTable data = new DataTable();
            //criteriaID = 0;
            if (criteriaid == 2)
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
                txtClientCode.Visible = false;
                lblClientCode.Text = "Branch Name:";
            }
            else if (criteriaid == 3)
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
                txtClientCode.Visible = false;
                lblClientCode.Text = "Workstation Name:";
            }
            else
            {
                ddlCriteriaID.Visible = false;
                txtClientCode.Visible = true;
                ddlCriteriaID.DataSource = null;
                lblClientCode.Text = "Client Code :";
            }

        }
        private void ClearText()
        {
            txtClientCode.Text = "";
            txtFinalCustCode.Text = "";
            txtName.Text = "";
            txtClientStatus.Text = "";
            txtBOID.Text = "";
        }
        private bool IsValid()
        {
            bool result = true;
            if (criteriaid == 2)
            {
                if (ddlCriteriaID.Text == "")
                {
                    MessageBox.Show("Branch Name Required");
                    result = false;
                }
                else
                {
                    referenceCode = ddlCriteriaID.SelectedValue.ToString();
                }
            }
            else if (criteriaid == 3)
            {
                if (ddlCriteriaID.Text == "")
                {
                    MessageBox.Show("Workstation Name Required");
                    result = false;
                }
                else
                {
                    if (ddlCriteriaID.Text == "All")
                        referenceCode = "0";
                    else
                        referenceCode = ddlCriteriaID.Text;
                }
            }
            else if (criteriaid == 1)
            {
                if (txtFinalCustCode.Text == "")
                {
                    MessageBox.Show("CustCode Required");
                    result = false;
                }
                else
                {
                    referenceCode = txtFinalCustCode.Text;
                }
            }
            return result;
        }
        private List<bool> DuplicateCheck()
        {
            LimitedDashboardBAL objLimitedClientDashboardBAL = new LimitedDashboardBAL();
            HideCustomerBAL objHideCustomerBAL = new HideCustomerBAL();
            //foreach (string nuseName in username)
            //{
                if (criteriaid == 2 && MenuName == "")
                {
                    result=(objLimitedClientDashboardBAL.IsExists(Insertusername, referenceCode, resourceid, criteriaid));

                }
                else if (criteriaid == 2 && MenuName != "")
                {
                    result=(objHideCustomerBAL.IsExists(Insertusername, referenceCode, resourceid, criteriaid));
                }

                else if (criteriaid == 3 && MenuName == "")
                {
                    result=(objLimitedClientDashboardBAL.IsExists(Insertusername, referenceCode, resourceid, criteriaid));
                }
                else if (criteriaid == 3 && MenuName != "")
                {
                    result=(objHideCustomerBAL.IsExists(Insertusername, referenceCode, resourceid, criteriaid));
                }

                else if (criteriaid == 1 && MenuName == "")
                {
                    result = (objLimitedClientDashboardBAL.IsExists(Insertusername, referenceCode, resourceid, criteriaid));
                }
                else if (criteriaid == 1 && MenuName != "")
                {
                    result = (objHideCustomerBAL.IsExists(Insertusername, referenceCode, resourceid, criteriaid));
                }
          //  }
            return result;
        }
        private void btnAddCode_Click(object sender, EventArgs e)
        {
            LimitedDashboardBAL objLimitedClientDashboardBAL = new LimitedDashboardBAL();
            HideCustomerBAL objHideCustomerBAL = new HideCustomerBAL();
            string name = "";
            List<bool> exist;
            //if (Deleteusername.Count > 0)
            //{
            //    objLimitedClientDashboardBAL.DeleteLimitedClientDashboard(Deleteusername, resourceid, referenceCode, criteriaid);
            //}

            if (IsValid())
            {
                exist = DuplicateCheck();
                try
                {
                    foreach (bool duplicate in exist)
                    {
                        name = Insertusername[increment];
                        if (duplicate == false)
                        {
                            //if (
                            //    MessageBox.Show(@"Do you want to Limit the Client from Dashboard ?", @"Limited Dashboard",
                            //                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            //{
                            if (MenuName == "" || MenuName == null)
                            {
                                objLimitedClientDashboardBAL.InsertLimitedClientIntoDashboard(name, resourceid,
                                                                                              referenceCode, criteriaid);
                            }
                            else
                            {
                                objHideCustomerBAL.SaveHideCustomer(referenceCode, name, resourceid, criteriaid);
                            }
                            ClearText();
                            // }
                        }
                        else
                        {
                            //MessageBox.Show(@"Data already Restricted from Dashboard", @"Restrict Dashboard",
                            //                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        increment++;
                    }
                    MessageBox.Show(@"Sucessfully Restricted the Client from Dashboard", @"Restricted Dashboard",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GetGridData(MenuName);

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            increment = 0;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //RefreshParentDatagridview();
            this.Close();
        }

        private void frmAddReferenceCode_FormClosed(object sender, FormClosedEventArgs e)
        {
            //RefreshParentDatagridview();
        }

        //private void RefreshParentDatagridview()
        //{
        //    LimitedDashboardBAL objLimitedDashboardBAL = new LimitedDashboardBAL();
        //    HideCustomerBAL hideCustomerBal = new HideCustomerBAL();

        //    DataTable data = new DataTable();
        //    try
        //    {
        //        if (MenuName == "" || MenuName == null)
        //        {
        //            data = objLimitedDashboardBAL.GetLimitedClientList(Insertusername, resourceid, criteriaid);
        //        }
        //        else
        //        {
        //            data = hideCustomerBal.GetGridData(Insertusername, resourceid, criteriaid);
        //        }
        //        frmSpecialClientDashboard spclient =
        //            (frmSpecialClientDashboard)Application.OpenForms["frmSpecialClientDashboard"];
        //        spclient.dgvLimitedClient.DataSource = data;
        //        spclient.dgvLimitedClient.Refresh();
        //    }
        //    catch 
        //    {
                
                
        //    }
        //}

    }
}
