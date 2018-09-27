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
    public partial class frmAddUser : Form
    {
        #region variable declaration

        private int ResourceID;
        private int CriteriaID;
        private string Hide_Limit;
        private string RoleName = string.Empty;
        private string PrevillizeName=string.Empty;
        private int PrevillizeID;
        private int rowIndex;
        private string userName = string.Empty;

        #endregion

        public frmAddUser(string hide_limit, int resourceId)
        {
            InitializeComponent();
            Hide_Limit = hide_limit;
            ResourceID = resourceId;
        }
        public frmAddUser(string rolename, string prevId, string prevName, int rowindex)
        {
            InitializeComponent();
            RoleName = rolename;
            PrevillizeName = prevName;
            PrevillizeID = Int32.Parse(prevId);
            rowIndex = rowindex;

        }

        //private void CheckExistingUser()
        //{
        //    UserManagementBAL objUserManagementBAL = new UserManagementBAL();
        //    DataTable data = new DataTable();
        //    if (PrevillizeName == "")
        //    {
        //        data = objUserManagementBAL.GetExistingUserList(Hide_Limit, ResourceID);   
        //    }
        //    else
        //    {
        //        data = objUserManagementBAL.GetExistingRolewithUser(RoleName, PrevillizeID,PrevillizeName);    
        //    }
        //    for (int i = 0; i < dgvUserList.Rows.Count; i++)
        //    {
        //        for (int x = 0; x < data.Rows.Count; x++)
        //        {
        //            if (dgvUserList.Rows[x].Cells["User_Name"].Value.ToString() == data.Rows[i][0].ToString())
        //            {
        //                dgvUserList.Rows[x].Cells["select"].Value = true;
        //                continue;
        //            }
        //            else
        //            {
        //                dgvUserList.Rows[x].Cells["select"].Value = false;
        //                continue;
        //            }
        //        }
        //    }

        //}
        private void LoadCustCodeList()
        {
            UserManagementBAL objUserManagementBAL = new UserManagementBAL();
            DataTable data = new DataTable();
            if (RoleName == "")
            {
                data = objUserManagementBAL.GetExistingUserList(Hide_Limit, ResourceID);  //objUserManagementBAL.GetUserList("");
            }
            else
            {
                //data = objUserManagementBAL.GetUserList(RoleName);
                data = objUserManagementBAL.GetUserWithIsSelectValue(RoleName, PrevillizeID);
            }
            dgvUserList.DataSource = data;
            //for (int i = 0; i < data.Rows.Count; i++)
            //{
            //    int x = dgvUserList.Rows.Add();
            //    dgvUserList.Rows[x].Cells["UserName"].Value = data.Rows[i][1].ToString();
            //    dgvUserList.Rows[x].Cells["IsSelected"].Value = Convert.ToBoolean(data.Rows[i][0].ToString());
            //}
            //CheckExistingUser();

        }
        private void LoadCriteriaName()
        {
            UserManagementBAL objUserManagementBAL = new UserManagementBAL();
            DataTable data = new DataTable();
            data = objUserManagementBAL.GetCriteriaName(ResourceID);  //objUserManagementBAL.GetUserList("");
            ddlCriteriaName.DataSource = data;
            ddlCriteriaName.ValueMember = "Criteria_ID";
            ddlCriteriaName.DisplayMember = "Criteria_Name";
        }

        private void LoadUserList()
        {
            UserManagementBAL objUserManagementBAL = new UserManagementBAL();
            DataTable data = new DataTable();
            if (RoleName == "")
            {
                data = objUserManagementBAL.GetExistingUserList(Hide_Limit, ResourceID,CriteriaID);  //objUserManagementBAL.GetUserList("");
            }
            else
            {
                //data = objUserManagementBAL.GetUserList(RoleName);
            data = objUserManagementBAL.GetUserWithIsSelectValue(RoleName,PrevillizeID);
            }
            dgvUserList.DataSource = data;

            dgvUserList.Columns["UserName"].ReadOnly = true;          

        }

        private void LoadRefCodeList(string selectQuery)
        {
            UserManagementBAL objUserManagementBAL = new UserManagementBAL();
            DataTable data = new DataTable();
            data = objUserManagementBAL.GetExistingRefCodeList(Hide_Limit, selectQuery, ResourceID, CriteriaID);  //objUserManagementBAL.GetUserList("");
            bindingSource_dgvAddCustCode.DataSource = data;
            //dgvAddCustCode.DataSource = data;
        }

        private void frmAddUser_Load(object sender, EventArgs e)
        {
            frmSpecialClientDashboard spclient = (frmSpecialClientDashboard)Application.OpenForms["frmSpecialClientDashboard"];
            try
            {
                if (RoleName == "")
                {
                    LoadCriteriaName();
                    LoadUserList();
                    SetBlankDataSource();
                }
                else
                {
                    //  btnAdd.Visible = false;237, 455
                    LoadUserList();
                    this.Width = 237;
                    this.Height = 455;
                    this.MaximumSize = new Size(237, 455);
                    btnClose.Location = new Point(180, 363); 
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
          //  if (RoleName == "")
          //  {
          //      frmSpecialClientDashboard spclient =(frmSpecialClientDashboard) Application.OpenForms["frmSpecialClientDashboard"];
          //      //foreach (DataGridViewRow row in dgvUserList.Rows)
          //      //{
          //      //    try
          //      //    {
          //      //        if ((bool)row.Cells["IsSelected"].Value == true)
          //      //            spclient.user.Add(row.Cells["UserName"].Value.ToString());
          //      //    }
          //      //    catch (Exception ex)
          //      //    {

          //      //    }
          //      //}

          //  }
          //  else
          //  {
          //      GrantPrevillize rolewithuser = (GrantPrevillize)Application.OpenForms["GrantPrevillize"];
          //      foreach (DataGridViewRow row in dgvUserList.Rows)
          //      {
          //          try
          //          {
          //              if ((bool)row.Cells["IsSelected"].Value == true)
          //                  rolewithuser.userList.Add(row.Cells["UserName"].Value.ToString());
          //          }
          //          catch
          //          {

          //          }
          //      }
          //  }
          ////  MessageBox.Show("User successfully added");
          //  this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                GrantPrevillize grantPrevillize = (GrantPrevillize)Application.OpenForms["GrantPrevillize"];
                //foreach (DataGridViewRow row in dgvUserList.Rows)
                //{
                //    try
                //    {
                //        if ((bool)row.Cells["Select"].Value == true)
                //            grantPrevillize.userList.Add(row.Cells["UserName"].Value.ToString());
                //    }
                //    catch
                //    {

                //    }
                //}
                //grantPrevillize.LoadPrevData();
                //this.Close();
                if (RoleName != "")
                {
                    PrevillizeManagementBAL prevBAL = new PrevillizeManagementBAL();
                    if (prevBAL.IsExistRoleAndPrevillize(RoleName, PrevillizeName, PrevillizeID) && prevBAL.IsExistRolePrevillizeAndUserName(RoleName, PrevillizeName, PrevillizeID))
                    {
                        prevBAL.DeleteFromPrevilizes("", RoleName, PrevillizeID, PrevillizeName);
                    }
                    grantPrevillize.LoadAfterDeleteRoleAndPrev(rowIndex);
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvUserList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            GrantPrevillize grantPrevillize = (GrantPrevillize)Application.OpenForms["GrantPrevillize"];
            frmSpecialClientDashboard spclient = (frmSpecialClientDashboard)Application.OpenForms["frmSpecialClientDashboard"];

            PrevillizeManagementBAL prevBAL = new PrevillizeManagementBAL();

            try
            {
                if (
                    (e.ColumnIndex == 0)
                    && (dgvUserList.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue != null)
                    && ((bool)dgvUserList.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue == true)
                   )
                {
                  //  userName = dgvUserList.Rows[e.RowIndex].Cells["UserName"].Value.ToString();
                    // GrantPrevillize.PrevwithRole userList = new GrantPrevillize.PrevwithRole();
                    //userList.userName = dgvUserList.Rows[e.RowIndex].Cells["UserName"].Value.ToString();
                    //userList.roleName=RoleName;
                    //userList.prevID = PrevillizeID.ToString();
                    //userList.prevName=PrevillizeName;
                    //userList.action = grantPrevillize.insertIndicator;
                    //grantPrevillize.finalList.Add(userList);
                    //if (!prevBAL.IsExists(dgvUserList.Rows[e.RowIndex].Cells["User_Name"].Value.ToString(), RoleName, PrevillizeID, PrevillizeName))
                    // {
                    //if (RoleName == "")
                    //{
                    //    int indexTemp = spclient.InsertUser.FindIndex(t => t == dgvUserList.Rows[e.RowIndex].Cells["UserName"].Value);
                    //    if (indexTemp != -1)
                    //    {
                    //        spclient.InsertUser.RemoveAt(indexTemp);
                    //    }
                    //    else
                    //    {
                    //        spclient.InsertUser.Add(dgvUserList.Rows[e.RowIndex].Cells["UserName"].Value.ToString());
                    //    }
                    //}

                    //else
                    //{
                    if (RoleName != "")
                    {
                        prevBAL.InsertIntoPrevillize(dgvUserList.Rows[e.RowIndex].Cells["UserName"].Value.ToString(), RoleName, PrevillizeID, PrevillizeName);
                        tsslabel.Text = "Data Saved Successfull";
                    }
                   // }
                    //{
                    //     MessageBox.Show("User already exist");
                    //LoadUserList();
                    // }
                }
                else if ((e.ColumnIndex == 0)
                    && (dgvUserList.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue != null)
                    && ((bool)dgvUserList.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue == false))
                {
                    //  DeleteRoleWithoutUser(previllize_ID, previllize_Name);
                    //List<int> indexTobeDeleted = new List<int>();
                    //var DeletedRecords = grantPrevillize.finalList.Where(t => t.roleName == RoleName && t.prevID == PrevillizeID.ToString() && t.userName == dgvUserList.Rows[e.RowIndex].Cells["UserName"].Value.ToString() && t.action == grantPrevillize.insertIndicator).ToList().FirstOrDefault();

                    //int indexTemp = grantPrevillize.finalList.FindIndex(t => t.roleName == DeletedRecords.roleName && t.prevID == DeletedRecords.prevID && t.userName == DeletedRecords.userName && t.action == DeletedRecords.action);
                    //if (RoleName == "")
                    //{
                    //    int indexTemp = spclient.InsertUser.FindIndex(t => t == dgvUserList.Rows[e.RowIndex].Cells["UserName"].Value);
                    //    if (indexTemp == -1)
                    //    {
                    //        spclient.DeleteUser.Add(dgvUserList.Rows[e.RowIndex].Cells["UserName"].Value.ToString());
                    //    }
                    //    else
                    //    {
                    //        spclient.InsertUser.Remove(dgvUserList.Rows[e.RowIndex].Cells["UserName"].Value.ToString());
                    //    }

                    //}
                    ////if (indexTemp!=-1)
                    ////grantPrevillize.finalList.RemoveAt(indexTemp);
                    ////else
                    ////{
                    ////    grantPrevillize.finalList.Add(new GrantPrevillize.PrevwithRole { action = grantPrevillize.deleteIndicator, roleName = RoleName , prevID= PrevillizeID.ToString(),  prevName = PrevillizeName ,userName = dgvUserList.Rows[e.RowIndex].Cells["UserName"].Value.ToString() });
                    ////}
                    //else
                    //{
                    if (RoleName != "")
                    {
                        prevBAL.DeleteFromPrevilizes(dgvUserList.Rows[e.RowIndex].Cells["UserName"].Value.ToString(), RoleName, PrevillizeID, PrevillizeName);
                        tsslabel.Text = "Data delete Successfull";
                    }
                }
                if (RoleName != "")
                {
                    LoadUserList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmAddUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            
                PrevillizeManagementBAL prevBAL = new PrevillizeManagementBAL();
                GrantPrevillize grantPrevillize = (GrantPrevillize)Application.OpenForms["GrantPrevillize"];
                //frmSpecialClientDashboard spclient = (frmSpecialClientDashboard)Application.OpenForms["frmSpecialClientDashboard"];
               
                //LimitedDashboardBAL objLimitedClientDashboardBAL = new LimitedDashboardBAL();
                //HideCustomerBAL objHideCustomerBAL = new HideCustomerBAL();

                //GrantPrevillize grantPrevillize = (GrantPrevillize)Application.OpenForms["GrantPrevillize"];
                //var prevWithNouser = grantPrevillize.finalList.Where(t =>t.action==grantPrevillize.insertIndicator && t.roleName == RoleName && t.prevID == PrevillizeID.ToString() && t.userName == "").FirstOrDefault();
                //var prevWithuser = grantPrevillize.finalList.Where(t => t.action == grantPrevillize.insertIndicator && t.roleName == RoleName && t.prevID == PrevillizeID.ToString() && t.userName != "");
                //if (prevWithuser.Count() > 0)
                //{
                //    int indexTemp = grantPrevillize.finalList.FindIndex(t => t.action == grantPrevillize.insertIndicator && t.roleName == prevWithNouser.roleName && t.prevID == prevWithNouser.prevID && t.userName == prevWithNouser.userName);
                //    if (indexTemp != -1)
                //    {
                //        grantPrevillize.finalList.RemoveAt(indexTemp);
                //    }
                //}

                //var prevDeleteWithNouser = grantPrevillize.finalList.Where(t => t.action == grantPrevillize.deleteIndicator && t.roleName == RoleName && t.prevID == PrevillizeID.ToString() && t.userName == "").FirstOrDefault();
                //var prevDeleteWithuser = grantPrevillize.finalList.Where(t => t.action == grantPrevillize.deleteIndicator && t.roleName == RoleName && t.prevName == PrevillizeName && t.userName != "");
                //if (prevWithuser.Count() > 0)
                //{
                //    int indexTemp = grantPrevillize.finalList.FindIndex(t => t.action == grantPrevillize.deleteIndicator && t.roleName == prevWithNouser.roleName && t.prevID == prevWithNouser.prevID && t.userName == prevWithNouser.userName);
                //    if (indexTemp != -1)
                //    {
                //        grantPrevillize.finalList.RemoveAt(indexTemp);
                //    }
                //}
                try
                {
                    if (RoleName != "")
                    {
                        if (prevBAL.IsExistRoleAndPrevillize(RoleName, PrevillizeName, PrevillizeID) && prevBAL.IsExistRolePrevillizeAndUserName(RoleName, PrevillizeName, PrevillizeID))
                        {
                            prevBAL.DeleteFromPrevilizes("", RoleName, PrevillizeID, PrevillizeName);
                        }
                        grantPrevillize.LoadAfterDeleteRoleAndPrev(rowIndex);
                    }
                    //else if (Hide_Limit=="Limit" && spclient.DeleteUser.Count > 0)
                    //{
                    //    objLimitedClientDashboardBAL.DeleteLimitedClientDashboard(spclient.DeleteUser, ResourceID,CriteriaID);
                    //}
                    //else if (Hide_Limit == "Hide" && spclient.DeleteUser.Count > 0)
                    //{
                    //    objHideCustomerBAL.DeleteHideClientDashboard(spclient.DeleteUser, ResourceID, CriteriaID);
                    //}
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        }

        private void dgvUserList_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //// If the data source raises an exception when a cell value is  
            //// commited, display an error message. 
            //if (e.Exception != null && e.Context == DataGridViewDataErrorContexts.Commit)
            //{
            //    MessageBox.Show("value must be unique.");
            //}
        }

        private void dgvAddCustCode_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            LimitedDashboardBAL objLimitedClientDashboardBAL = new LimitedDashboardBAL();
            HideCustomerBAL objHideCustomerBAL = new HideCustomerBAL();
            if (
                (e.ColumnIndex == 0)
                && (dgvAddCustCode.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue != null)
                && ((bool)dgvAddCustCode.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue == true)
               )
            {
                if (Hide_Limit == "Limit")
                {
                    foreach (DataGridViewRow dgvrow in dgvUserList.SelectedRows)
                    {
                        if ((bool)dgvrow.Cells["IsSelected"].FormattedValue == true)
                        {
                            if (!objLimitedClientDashboardBAL.IsExists(dgvrow.Cells["UserName"].FormattedValue.ToString(), dgvAddCustCode.Rows[e.RowIndex].Cells["Ref_Code"].EditedFormattedValue.ToString(), ResourceID, CriteriaID))
                            {
                                objLimitedClientDashboardBAL.InsertLimitedClientIntoDashboard(dgvrow.Cells["UserName"].FormattedValue.ToString(), ResourceID, dgvAddCustCode.Rows[e.RowIndex].Cells["Ref_Code"].EditedFormattedValue.ToString(), CriteriaID);
                                tsslabel.Text = "Data Saved Successfull";
                               // tsslabel.BackColor = Color.Green;
                            }
                        }
                    }
                }
                else if (Hide_Limit == "Hide")
                {
                    foreach (DataGridViewRow dgvrow in dgvUserList.SelectedRows)
                    {
                        if ((bool)dgvrow.Cells["IsSelected"].FormattedValue == true)
                        {
                            if (!objHideCustomerBAL.IsExists(dgvrow.Cells["UserName"].FormattedValue.ToString(), dgvAddCustCode.Rows[e.RowIndex].Cells["Ref_Code"].EditedFormattedValue.ToString(), ResourceID, CriteriaID))
                            {
                                objHideCustomerBAL.SaveHideCustomer(dgvAddCustCode.Rows[e.RowIndex].Cells["Ref_Code"].EditedFormattedValue.ToString(), dgvrow.Cells["UserName"].FormattedValue.ToString(), ResourceID, CriteriaID);
                                tsslabel.Text = "Data Saved Successfull";
                               // tsslabel.BackColor = Color.Green;
                            }
                        }
                    }

                }
            }
            else if (
                (e.ColumnIndex == 0)
                && (dgvAddCustCode.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue != null)
                && ((bool)dgvAddCustCode.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue == false)
               )
            {
                if (Hide_Limit == "Limit" || Hide_Limit == null)
                {
                    foreach (DataGridViewRow dgvrow in dgvUserList.SelectedRows)
                    {
                        if ((bool)dgvrow.Cells["IsSelected"].FormattedValue == true)
                        {
                            objLimitedClientDashboardBAL.DeleteLimitedClientIntoDashboard(dgvrow.Cells["UserName"].FormattedValue.ToString(), ResourceID, dgvAddCustCode.Rows[e.RowIndex].Cells["Ref_Code"].EditedFormattedValue.ToString(), CriteriaID);
                            tsslabel.Text = "Data delete Successfull";
                           // tsslabel.BackColor = Color.Red;
                        }
                    }
                }
                else
                {
                    foreach (DataGridViewRow dgvrow in dgvUserList.SelectedRows)
                    {
                        if ((bool)dgvrow.Cells["IsSelected"].FormattedValue == true)
                        {
                            objHideCustomerBAL.DeleteHideClientDashboard(dgvAddCustCode.Rows[e.RowIndex].Cells["Ref_Code"].EditedFormattedValue.ToString(), dgvrow.Cells["UserName"].FormattedValue.ToString(), ResourceID, CriteriaID);
                            tsslabel.Text = "Data delete Successfull";
                           // tsslabel.BackColor = Color.Red;
                        }
                    }
                }
            }


        }

        private void dgvUserList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            userName = dgvUserList.Rows[e.RowIndex].Cells["UserName"].Value.ToString();
        }
        private void Change_Grid_Header_ColumnName(int criteriaId)
        {
            switch (criteriaId)
            {
                case 1:
                    dgvAddCustCode.Columns[1].HeaderText = "Cust Code";
                    break;
                case 2:
                    dgvAddCustCode.Columns[1].HeaderText = "Branch";
                    dgvAddCustCode.Columns[2].HeaderText = "Branch Name";
                    break;
                case 3:
                    dgvAddCustCode.Columns[1].HeaderText = "Work Station";
                    dgvAddCustCode.Columns[2].HeaderText = "Branch Name";
                    break;
            }
        }
        private void ddlCriteriaName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CriteriaID = Convert.ToInt32(ddlCriteriaName.SelectedValue);
                Change_Grid_Header_ColumnName(CriteriaID);
                LoadUserList();
            }
            catch
            {
            }
        }
        private void LoadClientList()
        {
            this.Cursor = Cursors.WaitCursor;
            string excQuery = "";
            string selectQuery = "Select ";
            string unionQuery = " UNION ALL ";
            string userStartQt = "'";
            string userEndQt = "'";
            int initialcount = 1;
            int totalselectedrow = 0;

            //excQuery=""+selectQuery;
            foreach (DataGridViewRow dgvrow in dgvUserList.SelectedRows)
            {
                if ((bool)dgvrow.Cells["IsSelected"].FormattedValue == true)
                {
                    totalselectedrow++;
                }
            }
            //  totalselectedrow = dgvUserList.SelectedRows.Count;
            foreach (DataGridViewRow dgvrow in dgvUserList.SelectedRows)
            {
                if ((bool)dgvrow.Cells["IsSelected"].FormattedValue == true)
                {
                    //if check dgvrow is the last instance? "FALSE"
                    if (initialcount != totalselectedrow)
                        excQuery = excQuery + selectQuery + userStartQt + dgvrow.Cells["UserName"].FormattedValue.ToString() + userEndQt + unionQuery;
                    //else dgvrow is the last instance? "TRUE"
                    else if (initialcount == totalselectedrow)
                        excQuery = excQuery + selectQuery + userStartQt + dgvrow.Cells["UserName"].FormattedValue.ToString() + userEndQt;
                    initialcount++;
                }
            }
            LoadRefCodeList(excQuery);
            this.Cursor = null;
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            btnNext.Enabled = false;
            LoadClientList();  
        }

        private void dgvAddCustCode_SelectionChanged(object sender, EventArgs e)
        {
            tsslabel.Text = "";
        }

        private void SetBlankDataSource()
        {
            DataTable data = new DataTable();
            data.Columns.Add("Select", typeof(bool));
            data.Columns.Add("Ref_Code", typeof(string));
            data.Columns.Add("Ref_Name", typeof(string));
            bindingSource_dgvAddCustCode.DataSource = data;
            //dgvAddCustCode.DataSource = data;
        }
        private void dgvUserList_SelectionChanged(object sender, EventArgs e)
        {
            if (Hide_Limit != "")
            {
                try
                {
                    btnNext.Enabled = true;
                    SetBlankDataSource();
                }
                catch(Exception ex)
                {
                }
            }
        }

        
    }
}
