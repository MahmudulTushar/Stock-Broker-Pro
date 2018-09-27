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
using DataAccessLayer;
using System.Data.SqlClient;
using BusinessAccessLayer.Constants;
using System.Threading;


namespace StockbrokerProNewArch
{
    public partial class frm_IPOAutoApplicaiton : Form
    {
        private enum FromName { Eligible_Customer, Ineligible_Customer, All_Register_Customer };
        private FromName CurrentFormName;

        IPOProcessBAL AutoBal;
        DataTable dtEligibleCompany = new DataTable();

        double Deposit_Pending_Balance = 0.00;
        double Withdraw_Pending_Balance = 0.00;
        double Total_Balance = 0.00;
        double IPO_Cur_Balance = 0.00;
        double Total_Approved_Pending_Balance = 0.00;
        double GoingBalance = 0.00;
        string Deposit_Transaction_Name = "";
        string Withdraw_Transaction_Name = "";
        string Customer = "";
        

        public frm_IPOAutoApplicaiton()
        {
            InitializeComponent();
            AutoBal = new IPOProcessBAL();
            /*
            DataTable dt = new DataTable();
            dt = AutoBal.Get_TotalRegisterClient_ForAutoApplication();
        
            if (p_FromName == Indication_Forms_Title.EligibleCustomer_For_AutoApplication)
            {
                tabControl1.SelectedIndex = 0;
                CurrentFormName = FromName.Eligible_Customer;
                this.Text = "Eligible Customer For Auto Application";
                btnGetGligible.Text = "GetEligible";
                TxtTotalRegisterClient.Text = "Total Register Client = " + Convert.ToString(dt.Rows.Cast<DataRow>().Count());
            }
            else if (p_FromName == Indication_Forms_Title.InEligibleCustomer_For_AutoApplication)
            {
                tabControl1.SelectedIndex = 1;
                CurrentFormName = FromName.Ineligible_Customer;
                this.Text = "In Eligible Customer For Auto Application";
                btnGetGligible.Text = "GetInEligible";
                TxtTotalRegisterClient.Text = "Total Register Client = " + Convert.ToString(dt.Rows.Cast<DataRow>().Count());
            }
            else if (p_FromName == Indication_Forms_Title.AllRegisterCode_ForAutoApplication)
            {
                tabControl1.SelectedIndex = 2;
                CurrentFormName = FromName.All_Register_Customer;
                this.Text = "All Register Code";
                btnGetGligible.Text = "Get All Register code";
                TxtTotalRegisterClient.Text = "Total Register Client = " + Convert.ToString(dt.Rows.Cast<DataRow>().Count());
                dg_AllRegisterCode.DataSource = dt;
            }
              */
        }

        private void FrmAutoIPOApplication_Load(object sender, EventArgs e)
        {
            try
            {
                dtEligibleCompany = AutoBal.GetCompanyList_EligibleFor_Application();
                CmbCompanyShortCoede.DataSource = dtEligibleCompany;
                CmbCompanyShortCoede.DisplayMember = "Company_Short_Code";
                CmbCompanyShortCoede.ValueMember = "Session_ID";
                CmbCompanyShortCoede.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        CheckBox chkbox = new CheckBox();
        private void CmbCompanyShortCoede_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int SessionId = (int)CmbCompanyShortCoede.SelectedValue;

        }
        private void LoadGridData_Eligible(int sessionId)
        {
            dg_AutoIPOApplication.AllowUserToAddRows = false;
            dg_AutoIPOApplication.RowHeadersVisible = false;
            dg_AutoIPOApplication.Columns.Clear();
            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            
            chk.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            chk.Name = "chk";
            chk.HeaderText = "Select";
            dg_AutoIPOApplication.Columns.Insert(0, chk);
            dg_AutoIPOApplication.Columns[0].Width = 30;
            //show_chkBox();
            dg_AutoIPOApplication.DataSource = AutoIPOApplication(sessionId);
            dg_AutoIPOApplication.Columns["Cust_Name"].Width = 100;
            //dg_AutoIPOApplication.Columns["Select"].ReadOnly = false;
            dg_AutoIPOApplication.MultiSelect = true;
            //dg_AutoIPOApplication.Columns["Cust_Name"].Width;
            dg_AutoIPOApplication.Columns["TotalAmount_Per_App"].Visible = false;
            dg_AutoIPOApplication.Columns["SessionID"].Visible = false;
            dg_AutoIPOApplication.Columns["SelectionID"].Visible = false;
            dg_AutoIPOApplication.Columns["RefundType_ID"].Visible = false;
            dg_AutoIPOApplication.Columns["Session_Name"].Visible = false;
            dg_AutoIPOApplication.Columns["Child_Balance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dg_AutoIPOApplication.Columns["Child_Next_Balance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dg_AutoIPOApplication.Columns["Parent_First_Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dg_AutoIPOApplication.Columns["Parent_Balance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dg_AutoIPOApplication.Columns["Parent_Next_Balance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dg_AutoIPOApplication.Columns["Parent_Last_Balance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dg_AutoIPOApplication.Columns["Child_Next_Balance"].DefaultCellStyle.BackColor = Color.AliceBlue;
        }

        private void LoadGridData_InEligible(int sessionId)
        {
            dg_InEligibleCustomer.AllowUserToAddRows = false;
            dg_InEligibleCustomer.RowHeadersVisible = false;
            dg_InEligibleCustomer.Columns.Clear();
            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();

            chk.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            chk.Name = "chk";
            chk.HeaderText = "Select";
            dg_InEligibleCustomer.Columns.Insert(0, chk);
            dg_InEligibleCustomer.Columns[0].Width = 30;
            //show_chkBox();
            dg_InEligibleCustomer.DataSource = AutoIPOApplication_InEligible(sessionId);
            dg_InEligibleCustomer.Columns["Cust_Name"].Width = 100;
            //dg_AutoIPOApplication.Columns["Select"].ReadOnly = false;
            dg_InEligibleCustomer.MultiSelect = true;
            //dg_AutoIPOApplication.Columns["Cust_Name"].Width;
            dg_InEligibleCustomer.Columns["TotalAmount_Per_App"].Visible = false;
            dg_InEligibleCustomer.Columns["SessionID"].Visible = false;
            dg_InEligibleCustomer.Columns["SelectionID"].Visible = false;
            dg_InEligibleCustomer.Columns["RefundType_ID"].Visible = false;
            dg_InEligibleCustomer.Columns["Session_Name"].Visible = false;
            dg_InEligibleCustomer.Columns["Child_Balance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dg_InEligibleCustomer.Columns["Parent_Balance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dg_InEligibleCustomer.Columns["Child_Next_Balance"].Visible = false;
            dg_InEligibleCustomer.Columns["Parent_First_Amount"].Visible = false;
            dg_InEligibleCustomer.Columns["Parent_Next_Balance"].Visible = false;
            dg_InEligibleCustomer.Columns["Parent_Last_Balance"].Visible = false;
            dg_InEligibleCustomer.Columns["Child_Next_Balance"].Visible = false;
            dg_InEligibleCustomer.Columns["chk"].Visible = false;
            dg_InEligibleCustomer.Columns["Refund_Name"].Visible = false;
            dg_InEligibleCustomer.Columns["Application_Mode"].Width = 30;
            
        }

        private void LoadDataAfterSave(int SessionID)
        {
            dg_AutoIPOApplication.DataSource = AutoIPOApplication(SessionID);
            dg_AutoIPOApplication.Columns["Cust_Name"].Width = 100;
            dg_AutoIPOApplication.MultiSelect = true;
            dg_AutoIPOApplication.Columns["TotalAmount_Per_App"].Visible = false;
            dg_AutoIPOApplication.Columns["SessionID"].Visible = false;
            dg_AutoIPOApplication.Columns["SelectionID"].Visible = false;
            dg_AutoIPOApplication.Columns["RefundType_ID"].Visible = false;
            dg_AutoIPOApplication.Columns["Session_Name"].Visible = false;
        }
        /*
        private void show_chkBox()
        {
            Rectangle rect = dg_AutoIPOApplication.GetCellDisplayRectangle(0, -1, true);
            // set checkbox header to center of header cell. +1 pixel to position 
            rect.Y = 3;
            rect.X = rect.Location.X + (rect.Width / 4);
            CheckBox checkboxHeader = new CheckBox();
            checkboxHeader.Name = "checkboxHeader";
            //dg_AutoIPOApplication[0, 0].ToolTipText = "Select All Check Box";
            checkboxHeader.Size = new Size(18,18);
             
            checkboxHeader.Location = rect.Location;
            checkboxHeader.CheckedChanged += new EventHandler(checkboxHeader_CheckedChanged);
            dg_AutoIPOApplication.Controls.Add(checkboxHeader);
        }

        private void checkboxHeader_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox headerBox = ((CheckBox)dg_AutoIPOApplication.Controls.Find("checkboxHeader", true)[0]);
            int index = 0;
            for (int i = 0; i <= dg_AutoIPOApplication.RowCount-1; i++)
            {
                if (headerBox.Checked == true)
                {
                    dg_AutoIPOApplication.Rows[i].Cells[0].Value = headerBox.Checked;
                    dg_AutoIPOApplication.Rows[i].Selected = true;
                    index++;
                }
                else
                {
                    dg_AutoIPOApplication.Rows[i].Cells[0].Value = headerBox.Checked;
                    dg_AutoIPOApplication.Rows[i].Selected = false;
                }
            }
            dg_AutoIPOApplication.EndEdit();
            tl_Select_For_Application.Text ="You have Select : "+ Convert.ToString(index);
        }
         */
         
       // DataTable dt = null;
        public DataTable CreaetDataTable()
        {
           DataTable dt = new DataTable();
            dt.Columns.Add("Cust_Code");
            dt.Columns.Add("Parent_Code");
            dt.Columns.Add("Cust_Name");
            dt.Columns.Add("Company");

            //dt.Columns.Add("Money_TransactionType_Name_ID");
            dt.Columns.Add("Session_Name");
            dt.Columns.Add("Child_Balance", typeof(decimal));
            dt.Columns.Add("Child_Next_Balance", typeof(decimal));
            dt.Columns.Add("Parent_First_Amount", typeof(decimal));
            dt.Columns.Add("Parent_Balance", typeof(decimal));
            dt.Columns.Add("Parent_Next_Balance", typeof(decimal));
            dt.Columns.Add("Parent_Last_Balance", typeof(decimal));
            dt.Columns.Add("Refund_Name", typeof(string));
            dt.Columns.Add("RefundType_ID", typeof(int));
            dt.Columns.Add("SelectionID", typeof(string));
            dt.Columns.Add("ApplicationType", typeof(string));
            dt.Columns.Add("Application_Mode", typeof(string));
            dt.Columns.Add("SessionID");
            dt.Columns.Add("TotalAmount_Per_App");
            return dt;

        }
        private DataTable AutoIPOApplication(int sessionID)
        {
            DataTable dt = new DataTable();
            dt = CreaetDataTable();            
            DataTable dtAutoApplicantBalance = new DataTable();
            IPOProcessBAL bal = new IPOProcessBAL();
            DataTable dtAutoApplicantInfo = new DataTable();
            DataTable dtIPOApplicactionData = new DataTable();
             
            string cust_code = "";
            string Parent_code = "";
            string IsAlreadyApplied = "";

            decimal Child_Balance = 0.0M;
            decimal Parent_Balance = 0.0M;
            decimal Withdraw_Balance = 0.0M;
            decimal Parent_Current_Balance = 0.0M;
            decimal Parent_First_Balance = 0.0M;

            dtAutoApplicantBalance = bal.GetIPOAccountBalanceFor_AutoApplication<string>(Convert.ToString(CmbCompanyShortCoede.SelectedValue), "Eligible");
            foreach (DataRow row in dtAutoApplicantBalance.Rows)
            {
                Parent_First_Balance = 0.0M;
                DataRow dr = null;
                DataTable dtChild = new DataTable();
                Parent_First_Balance = Convert.ToDecimal(row["DeductLoackAmountBalance"]);
                if (Convert.ToString(row["Parent_Code"]) != "")
                {
                    dtChild = bal.GetAllChildCode(Convert.ToString(row["Parent_Code"]));
                    //dr["Parent_Balance"] = Convert.ToDouble(row["DeductLoackAmountBalance"]);
                    foreach (DataRow childRow in dtChild.Rows)
                    {
                        IsAlreadyApplied = "";
                        dtIPOApplicactionData=bal.GetIPOApplicationTableDataByCustCode_SessionID_Check_IsAlreadyApply<string>(Convert.ToString(childRow["Child_Code"]),Convert.ToString(sessionID));
                        if (dtIPOApplicactionData.Rows.Count > 0)
                        {
                            IsAlreadyApplied =Convert.ToString(dtIPOApplicactionData.Rows[0]["Cust_Code"]);
                        }
                        if(string.IsNullOrEmpty(IsAlreadyApplied))
                        {
                        dr = dt.NewRow();
                        dtAutoApplicantInfo = bal.GetCustoemrDetailsForPaymentEntry(childRow["Child_Code"].ToString());
                        cust_code = childRow["Child_Code"].ToString();
                        Parent_code = row["Parent_Code"].ToString();
                        
                        //if (cust_code != Parent_code)
                        //{
                            if (Convert.ToDouble(row["DeductLoackAmountBalance"]) > Convert.ToDouble(row["TotalAmount_Per_App"]))
                            {

                                //dr["ID"] = "";
                                dr["Cust_Code"] = cust_code;
                                dr["Parent_Code"] = Parent_code;
                                dr["Cust_Name"] = Convert.ToString(dtAutoApplicantInfo.Rows[0]["Cust_Name"]);
                                Child_Balance = Convert.ToDecimal(dtAutoApplicantInfo.Rows[0]["IPO_Mone_Bal"]);
                                Withdraw_Balance = Convert.ToDecimal(row["TotalAmount_Per_App"]);
                                Parent_Balance = Convert.ToDecimal(row["DeductLoackAmountBalance"]);
                                
                                if (cust_code != Parent_code)
                                {                                    
                                    dr["Child_Balance"] = Child_Balance.ToString("N2");
                                    dr["Child_Next_Balance"] = (Withdraw_Balance + Child_Balance).ToString("N2");
                                    dr["Parent_Balance"] = Parent_Balance.ToString("N2");
                                    Parent_Current_Balance=Parent_Balance - Withdraw_Balance;
                                    dr["Parent_Next_Balance"] = Parent_Current_Balance.ToString("N2");
                                    row["DeductLoackAmountBalance"] = Parent_Current_Balance.ToString("N2");
  
                                }
                                else
                                {
                                    dr["Parent_Balance"] = Parent_Balance.ToString("N2");
                                    Parent_Current_Balance = Parent_Balance - Withdraw_Balance;
                                    dr["Parent_Next_Balance"] = Parent_Current_Balance.ToString("N2");
                                    row["DeductLoackAmountBalance"] = Parent_Current_Balance.ToString("N2");
                                }

                                dr["Company"] = Convert.ToString(row["Company"]);

                                dr["Refund_Name"] = cust_code == Parent_code ? Indication_IPORefundType.Refund_TRIPO : Indication_IPORefundType.Refund_TRPRIPO;
                                dr["RefundType_ID"] = cust_code == Parent_code ? Indication_IPORefundType.Refund_TRIPO_ID : Indication_IPORefundType.Refund_TRPRIPO_ID;
                                //dr["SMSReceiveID"] = "";
                                dr["ApplicationType"] = cust_code == Parent_code ? Indication_IPOPaymentTransaction.AutoRequestType_Single_Application : Indication_IPOPaymentTransaction.AutoRequestType_Apply_Together;
                                dr["TotalAmount_Per_App"]=row["TotalAmount_Per_App"];
                                dr["Application_Mode"] = Indication_IPOPaymentTransaction.Application_Type;
                                dr["SelectionID"] = Parent_code;
                                dr["Company"] = row["Company"];
                                dr["SessionID"] = row["SessionID"];
                                dr["Session_Name"] = row["Session_Name"];
                                dr["Parent_First_Amount"] = Parent_First_Balance.ToString("N2");
                                dt.Rows.Add(dr);

                            }
                        }
                         
                    }
                    IEnumerable<DataRow> rows = dt.Rows.Cast<DataRow>().Where(c => Convert.ToString(c["Parent_Last_Balance"]) == "");
                    rows.ToList().ForEach(r => r.SetField("Parent_Last_Balance", Parent_Current_Balance.ToString("N2")));
                }
                else if (Convert.ToString(row["Parent_Code"]) == "")
                {
                    IsAlreadyApplied = "";
                    dtIPOApplicactionData = bal.GetIPOApplicationTableDataByCustCode_SessionID_Check_IsAlreadyApply<string>(Convert.ToString(row["Cust_Code"]), Convert.ToString(CmbCompanyShortCoede.SelectedValue));
                    if (dtIPOApplicactionData.Rows.Count > 0)
                    {
                        IsAlreadyApplied = Convert.ToString(dtIPOApplicactionData.Rows[0]["Cust_Code"]);
                    }

                    if (string.IsNullOrEmpty(IsAlreadyApplied))
                    {
                        if (Convert.ToDouble(row["DeductLoackAmountBalance"]) > Convert.ToDouble(row["TotalAmount_Per_App"]))
                        {
                            dtAutoApplicantInfo = bal.GetCustoemrDetailsForPaymentEntry(row["Cust_Code"].ToString());
                            cust_code = Convert.ToString(row["Cust_Code"]);
                            Parent_code = Convert.ToString(row["Parent_Code"]);
                            //dtAutoApplicantInfo = bal.GetAutoApplicantInfo(row["Cust_Code"].ToString());
                            dr = dt.NewRow();
                            dr["Cust_Code"] = cust_code;
                            dr["Parent_Code"] = Parent_code;
                            dr["Cust_Name"] = Convert.ToString(dtAutoApplicantInfo.Rows[0]["Cust_Name"]);
                            Child_Balance = Convert.ToDecimal(dtAutoApplicantInfo.Rows[0]["IPO_Mone_Bal"]);
                            Withdraw_Balance = Convert.ToDecimal(row["TotalAmount_Per_App"]);
                            Parent_Balance = Convert.ToDecimal(row["DeductLoackAmountBalance"]);
                            //if (cust_code != Parent_code)
                            //{
                            //    dr["Child_Balance"] = Child_Balance;
                            //    dr["Child_Next_Balance"] = Withdraw_Balance + Child_Balance;
                            //    dr["Parent_Balance"] = Parent_Balance;
                            //    Parent_Current_Balance = Parent_Balance - Withdraw_Balance;
                            //    dr["Parent_Next_Balance"] = Parent_Current_Balance;
                            //    row["DeductLoackAmountBalance"] = Parent_Current_Balance;

                            //}
                            //else
                            //{
                            dr["Parent_Balance"] = Parent_Balance.ToString("N2");
                            dr["Parent_Next_Balance"] = (Parent_Balance - Withdraw_Balance).ToString("N2");
                            //}

                            dr["Company"] = Convert.ToString(row["Company"]);

                            dr["Refund_Name"] = Indication_IPORefundType.Refund_TRIPO;
                            dr["RefundType_ID"] = Indication_IPORefundType.Refund_TRIPO_ID;
                            //dr["SMSReceiveID"] = "";
                            dr["ApplicationType"] = cust_code != Parent_code ? Indication_IPOPaymentTransaction.AutoRequestType_Single_Application : Indication_IPOPaymentTransaction.AutoRequestType_Apply_Together;

                            dr["Application_Mode"] = Indication_IPOPaymentTransaction.Application_Type;
                            dr["SelectionID"] = cust_code;
                            dr["Company"] = row["Company"];
                            dr["SessionID"] = row["SessionID"];
                            dr["TotalAmount_Per_App"] = row["TotalAmount_Per_App"];
                            dr["Session_Name"] = row["Session_Name"];
                            dt.Rows.Add(dr);
                        }
                    } 
                }

            }
            return dt;
             
        }

        private DataTable AutoIPOApplication_InEligible(int sessionID)
        {
            DataTable dt = new DataTable();
            dt = CreaetDataTable();
            
            DataTable dtAutoApplicantBalance = new DataTable();
            IPOProcessBAL bal = new IPOProcessBAL();
            DataTable dtAutoApplicantInfo = new DataTable();
            DataTable dtIPOApplicactionData = new DataTable();

            string cust_code = "";
            string Parent_code = "";
            string IsAlreadyApplied = "";

            decimal Child_Balance = 0.0M;
            decimal Parent_Balance = 0.0M;
            decimal Withdraw_Balance = 0.0M;
            decimal Parent_Current_Balance = 0.0M;
            decimal Parent_First_Balance = 0.0M;
            //decimal Parent_Last_Balance = 0.0M;

            dtAutoApplicantBalance = bal.GetIPOAccountBalanceFor_AutoApplication<string>(Convert.ToString(CmbCompanyShortCoede.SelectedValue), "InEligible");
            foreach (DataRow row in dtAutoApplicantBalance.Rows)
            {
                Parent_First_Balance = 0.0M;
                DataRow dr = null;
                DataTable dtChild = new DataTable();
                Parent_First_Balance = Convert.ToDecimal(row["DeductLoackAmountBalance"]);
                if (Convert.ToString(row["Parent_Code"]) != "")
                {
                    dtChild = bal.GetAllChildCode(Convert.ToString(row["Parent_Code"]));
                    //dr["Parent_Balance"] = Convert.ToDouble(row["DeductLoackAmountBalance"]);
                    foreach (DataRow childRow in dtChild.Rows)
                    {
                        IsAlreadyApplied = "";
                        dtIPOApplicactionData = bal.GetIPOApplicationTableDataByCustCode_SessionID_Check_IsAlreadyApply<string>(Convert.ToString(childRow["Child_Code"]), Convert.ToString(sessionID));
                        if (dtIPOApplicactionData.Rows.Count > 0)
                        {
                            IsAlreadyApplied = Convert.ToString(dtIPOApplicactionData.Rows[0]["Cust_Code"]);
                        }
                        //if (!string.IsNullOrEmpty(IsAlreadyApplied)||string.IsNullOrEmpty(IsAlreadyApplied))
                        if (string.IsNullOrEmpty(IsAlreadyApplied))
                        {
                            dr = dt.NewRow();
                            dtAutoApplicantInfo = bal.GetCustoemrDetailsForPaymentEntry(childRow["Child_Code"].ToString());
                            cust_code = childRow["Child_Code"].ToString();
                            Parent_code = row["Parent_Code"].ToString();

                            //if (cust_code != Parent_code)
                            //{
                            if (Convert.ToDouble(row["DeductLoackAmountBalance"]) < Convert.ToDouble(row["TotalAmount_Per_App"]))
                            {

                                //dr["ID"] = "";
                                dr["Cust_Code"] = cust_code;
                                dr["Parent_Code"] = Parent_code;
                                dr["Cust_Name"] = Convert.ToString(dtAutoApplicantInfo.Rows[0]["Cust_Name"]);
                                Child_Balance = Convert.ToDecimal(dtAutoApplicantInfo.Rows[0]["IPO_Mone_Bal"]);
                                Withdraw_Balance = Convert.ToDecimal(row["TotalAmount_Per_App"]);
                                Parent_Balance = Convert.ToDecimal(row["DeductLoackAmountBalance"]);

                                if (cust_code != Parent_code)
                                {
                                    dr["Child_Balance"] = Child_Balance.ToString("N2");
                                    //dr["Child_Next_Balance"] = (Withdraw_Balance + Child_Balance).ToString("N2");
                                    dr["Parent_Balance"] = Parent_Balance.ToString("N2");
                                    //Parent_Current_Balance = Parent_Balance - Withdraw_Balance;
                                    //dr["Parent_Next_Balance"] = Parent_Current_Balance.ToString("N2");
                                    //row["DeductLoackAmountBalance"] = Parent_Current_Balance.ToString("N2");

                                }
                                else
                                {
                                    dr["Parent_Balance"] = Parent_Balance.ToString("N2");
                                    //Parent_Current_Balance = Parent_Balance - Withdraw_Balance;
                                    dr["Parent_Next_Balance"] = Parent_Current_Balance.ToString("N2");
                                    //row["DeductLoackAmountBalance"] = Parent_Current_Balance.ToString("N2");
                                }

                                dr["Company"] = Convert.ToString(row["Company"]);

                                dr["Refund_Name"] = Indication_IPORefundType.Refund_TRPRIPO;
                                dr["RefundType_ID"] = Indication_IPORefundType.Refund_TRPRIPO_ID;
                                //dr["SMSReceiveID"] = "";
                                //dr["ApplicationType"] = cust_code == Parent_code ? Indication_IPOPaymentTransaction.AutoRequestType_Single_Application : Indication_IPOPaymentTransaction.AutoRequestType_Apply_Together;
                                dr["ApplicationType"] = string.IsNullOrEmpty(IsAlreadyApplied) ? "Insufficient Balance" : "Already Applied";
                                dr["TotalAmount_Per_App"] = row["TotalAmount_Per_App"];
                                dr["Application_Mode"] = Indication_IPOPaymentTransaction.Application_Type;
                                dr["SelectionID"] = Parent_code;
                                dr["Company"] = row["Company"];
                                dr["SessionID"] = row["SessionID"];
                                dr["Session_Name"] = row["Session_Name"];
                                dr["Parent_First_Amount"] = Parent_First_Balance.ToString("N2");
                                dt.Rows.Add(dr);

                            }
                        }

                    }
                    //IEnumerable<DataRow> rows = dt.Rows.Cast<DataRow>().Where(c => Convert.ToString(c["Parent_Last_Balance"]) == "");
                    //rows.ToList().ForEach(r => r.SetField("Parent_Last_Balance", Parent_Current_Balance.ToString("N2")));
                }
                else if (Convert.ToString(row["Parent_Code"]) == "")
                {
                    IsAlreadyApplied = "";
                    dtIPOApplicactionData = bal.GetIPOApplicationTableDataByCustCode_SessionID_Check_IsAlreadyApply<string>(Convert.ToString(row["Cust_Code"]), Convert.ToString(CmbCompanyShortCoede.SelectedValue));
                    if (dtIPOApplicactionData.Rows.Count > 0)
                    {
                        IsAlreadyApplied = Convert.ToString(dtIPOApplicactionData.Rows[0]["Cust_Code"]);
                    }

                    if (string.IsNullOrEmpty(IsAlreadyApplied))
                    {
                        if (Convert.ToDouble(row["DeductLoackAmountBalance"]) < Convert.ToDouble(row["TotalAmount_Per_App"]))
                        {
                            dtAutoApplicantInfo = bal.GetCustoemrDetailsForPaymentEntry(row["Cust_Code"].ToString());
                            cust_code = Convert.ToString(row["Cust_Code"]);
                            Parent_code = Convert.ToString(row["Parent_Code"]);
                            //dtAutoApplicantInfo = bal.GetAutoApplicantInfo(row["Cust_Code"].ToString());
                            dr = dt.NewRow();
                            dr["Cust_Code"] = cust_code;
                            dr["Parent_Code"] = Parent_code;
                            dr["Cust_Name"] = Convert.ToString(dtAutoApplicantInfo.Rows[0]["Cust_Name"]);
                            Child_Balance = Convert.ToDecimal(dtAutoApplicantInfo.Rows[0]["IPO_Mone_Bal"]);
                            Withdraw_Balance = Convert.ToDecimal(row["TotalAmount_Per_App"]);
                            Parent_Balance = Convert.ToDecimal(row["DeductLoackAmountBalance"]);
                            //if (cust_code != Parent_code)
                            //{
                            //    dr["Child_Balance"] = Child_Balance;
                            //    dr["Child_Next_Balance"] = Withdraw_Balance + Child_Balance;
                            //    dr["Parent_Balance"] = Parent_Balance;
                            //    Parent_Current_Balance = Parent_Balance - Withdraw_Balance;
                            //    dr["Parent_Next_Balance"] = Parent_Current_Balance;
                            //    row["DeductLoackAmountBalance"] = Parent_Current_Balance;

                            //}
                            //else
                            //{
                            dr["Parent_Balance"] = Parent_Balance.ToString("N2");
                            //dr["Parent_Next_Balance"] = (Parent_Balance - Withdraw_Balance).ToString("N2");
                            //}

                            dr["Company"] = Convert.ToString(row["Company"]);

                            dr["Refund_Name"] = Indication_IPORefundType.Refund_TRPRIPO;
                            dr["RefundType_ID"] = Indication_IPORefundType.Refund_TRPRIPO_ID;
                            //dr["SMSReceiveID"] = "";
                            //dr["ApplicationType"] = cust_code != Parent_code ? Indication_IPOPaymentTransaction.AutoRequestType_Single_Application : Indication_IPOPaymentTransaction.AutoRequestType_Apply_Together;
                            dr["ApplicationType"] = string.IsNullOrEmpty(IsAlreadyApplied) ? "Insufficient Balance" : "Already Applied";
                            dr["Application_Mode"] = Indication_IPOPaymentTransaction.Application_Type;
                            dr["SelectionID"] = cust_code;
                            dr["Company"] = row["Company"];
                            dr["SessionID"] = row["SessionID"];
                            dr["TotalAmount_Per_App"] = row["TotalAmount_Per_App"];
                            dr["Session_Name"] = row["Session_Name"];
                            dt.Rows.Add(dr);
                        }
                    }
                }

            }
            return dt;

        }


        private void dg_AutoIPOApplication_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
             
            if (e.ColumnIndex == 0)
            {
                bool isChecked = (bool)dg_AutoIPOApplication[e.ColumnIndex, e.RowIndex].EditedFormattedValue;
                dg_AutoIPOApplication.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = !isChecked;
                dg_AutoIPOApplication.Rows[e.RowIndex].Selected = true;
                dg_AutoIPOApplication.EndEdit();

                int k = 0;
                if (e.ColumnIndex == 0)
                {
                    dg_AutoIPOApplication.CommitEdit(DataGridViewDataErrorContexts.Commit);
                    bool current = Convert.ToBoolean(dg_AutoIPOApplication.CurrentRow.Cells["chk"].Value);
                    if (current == false)
                    {
                        for (int i = 0; i <= dg_AutoIPOApplication.RowCount - 1; i++)
                        {
                            //chkcol is checkbox column
                            if (Convert.ToBoolean(dg_AutoIPOApplication.Rows[i].Cells["chk"].Value) == true)
                            {
                                k = Convert.ToInt32(dg_AutoIPOApplication.Rows[i].Cells["SelectionID"].Value);
                                for (int row = 0; row <= dg_AutoIPOApplication.Rows.Count - 1; row++)
                                {
                                    if (Convert.ToInt32(dg_AutoIPOApplication.Rows[row].Cells["SelectionID"].Value) == k)
                                    {
                                        dg_AutoIPOApplication.Rows[row].DataGridView[0, row].Value = false;
                                        dg_AutoIPOApplication.Rows[row].Selected = false;
                                        tl_Select_For_Application.Text = "You have Select : " + Convert.ToString(dg_AutoIPOApplication.Rows.Cast<DataGridViewRow>()
                                                    .Where(c => Convert.ToBoolean(c.Cells["chk"].Value) == true).Count());
                                    }
                                }

                            }

                        }
                    }
                    else if (current == true)
                    {
                        for (int i = 0; i <= dg_AutoIPOApplication.RowCount - 1; i++)
                        {
                            //chkcol is checkbox column
                            if (Convert.ToBoolean(dg_AutoIPOApplication.Rows[i].Cells["chk"].Value) == true)
                            {
                                k = Convert.ToInt32(dg_AutoIPOApplication.Rows[i].Cells["SelectionID"].Value);
                                for (int row = 0; row <= dg_AutoIPOApplication.Rows.Count - 1; row++)
                                {
                                    if (Convert.ToInt32(dg_AutoIPOApplication.Rows[row].Cells["SelectionID"].Value) == k)
                                    {
                                        dg_AutoIPOApplication.Rows[row].DataGridView[0, row].Value = true;
                                        dg_AutoIPOApplication.Rows[row].Selected = true;
                                        tl_Select_For_Application.Text = "You have Select : " + Convert.ToString(dg_AutoIPOApplication.Rows.Cast<DataGridViewRow>()
                                                    .Where(c => Convert.ToBoolean(c.Cells["chk"].Value) == true).Count());
                                    }
                                }

                            }

                        }
                    }

                }
            }
           

        }
        
        private void btnAutoProcess_Click(object sender, EventArgs e)
        {
            try
            {
                Thread theread = new Thread(WaitWindow_Thread);
                isProgressed = true;
                theread.Start();
                AutoApplication();
                //LoadDataAfterSave(Convert.ToInt32(CmbCompanyShortCoede.SelectedValue));
                LoadGridData_Eligible(Convert.ToInt32(CmbCompanyShortCoede.SelectedValue));
                ChkCheckAll.Checked = false;
                isProgressed = false;
                MessageBox.Show("SaveSuccessfully");
            }
            catch (Exception ex)
            {
                isProgressed = false;                
                MessageBox.Show(ex.Message);
            }
        }

        private void ChkCheckAll_CheckedChanged(object sender, EventArgs e)
        {
            int index = 0;
            if (ChkCheckAll.Checked)
            {
                for (int i = 0; i <= dg_AutoIPOApplication.RowCount - 1; i++)
                {
                    dg_AutoIPOApplication.Rows[i].DataGridView[0, i].Value = true;
                    dg_AutoIPOApplication.Rows[i].Selected = true;
                    index++;
                }
            }
            else if(ChkCheckAll.Checked==false)
            {
                for (int i = 0; i <= dg_AutoIPOApplication.RowCount - 1; i++)
                {
                    dg_AutoIPOApplication.Rows[i].DataGridView[0, i].Value = false;
                    dg_AutoIPOApplication.Rows[i].Selected = false;
                    index = 0;
                }
            }
            tl_Select_For_Application.Text = "You have Select : " + Convert.ToString(index);
        }
        private void AutoApplication()
        {
            IPOProcessBAL bal = new IPOProcessBAL();
            CommonBAL common = new CommonBAL();
            DataTable dt_CustList_IPOPayment = new DataTable();             
            string[] SelectionID = null;
            string[] Total_Applicant_Cust_Code = null;
            string[] ApplicationType = null;
            string Paren_Code = "";
             
            if (dg_AutoIPOApplication.Rows.Count > 0)
            {
                 SelectionID = dg_AutoIPOApplication.SelectedRows.Cast<DataGridViewRow>().Select(c =>Convert.ToString(c.Cells["SelectionID"].Value)).Distinct().ToArray();
                 //temp = dg_AutoIPOApplication.Rows.Cast<DataGridViewRow>().AsEnumerable();
            }
            foreach (var row in SelectionID)
            {
                //Above DtCustList IPO Account Casting
                string[] Cust_Code_IPoAcc_dtCustList = null;
                Cust_Code_IPoAcc_dtCustList=dg_AutoIPOApplication.Rows.Cast<DataGridViewRow>()
                .Where(c => Convert.ToString(c.Cells["ApplicationType"].Value) == Indication_IPOPaymentTransaction.AutoRequestType_Apply_Together
                && Convert.ToString(c.Cells["SelectionID"].Value) == Convert.ToString(row)
                && Convert.ToBoolean(c.Cells[0].Value) == true)
                .Select(t => Convert.ToString(t.Cells["Cust_Code"].Value)).ToArray();

                Paren_Code = dg_AutoIPOApplication.Rows.Cast<DataGridViewRow>()
                    .Where(c => Convert.ToString(c.Cells["SelectionID"].Value) == Convert.ToString(row)
                    && Convert.ToBoolean(c.Cells[0].Value) == true)
                    .Select(t => Convert.ToString(t.Cells["Parent_Code"].Value)).Distinct().FirstOrDefault();

                //double[] Amount_IPOAcc_dtCustList = dt_CustList_IPOPayment.Rows.Cast<DataRow>().Select(t => Convert.ToDouble(t["Distributed_Amount"])).ToArray();
                double[] Amount_IPOAcc_dtCustList = dg_AutoIPOApplication.Rows.Cast<DataGridViewRow>()
                    .Where(c => Convert.ToString(c.Cells["ApplicationType"].Value) == Indication_IPOPaymentTransaction.AutoRequestType_Apply_Together
                    && Convert.ToString(c.Cells["SelectionID"].Value) == Convert.ToString(row)
                    && Convert.ToBoolean(c.Cells[0].Value) == true)
                    .Select(t => Convert.ToDouble(t.Cells["TotalAmount_Per_App"].Value)).ToArray();
                string Deposit_Withdraw_IPOAcc_dtCustList = Indication_PaymentMode.Deposit;

                //IPO Charge Added By Md.Rashedul Hasan

                //TransCode IPO Account Casting
                 
                
                 string Cust_Code_IPoAcc_TransCode = dg_AutoIPOApplication.SelectedRows.Cast<DataGridViewRow>()
                     .Where(c => Convert.ToString(c.Cells["SelectionID"].Value) == Convert.ToString(row))
                    //&& Convert.ToString(c.Cells["ApplicationType"].Value) == Indication_IPOPaymentTransaction.AutoRequestType_Single_Application

                    .Select(t => Convert.ToString(t.Cells["SelectionID"].Value)).Distinct().FirstOrDefault();

                double Amount_Withdraw = 0.00;
                double Amount_TransCode = 0.00;
                double ApplicationAmount = 0.00;
                Amount_TransCode = dg_AutoIPOApplication.SelectedRows.Cast<DataGridViewRow>()
                .Where(c => Convert.ToString(c.Cells["ApplicationType"].Value) == Indication_IPOPaymentTransaction.AutoRequestType_Apply_Together
                && Convert.ToString(c.Cells["SelectionID"].Value) == Convert.ToString(row)&& Convert.ToBoolean(c.Cells[0].Value) == true)
                .Select(c => Convert.ToDouble(c.Cells["TotalAmount_Per_App"].Value)).Sum(); ;
                Amount_Withdraw = dg_AutoIPOApplication.SelectedRows.Cast<DataGridViewRow>()
                    .Where(c => Convert.ToString(c.Cells["SelectionID"].Value) == Convert.ToString(row) 
                        && Convert.ToBoolean(c.Cells[0].Value) == true)
                    .Select(c => Convert.ToDouble(c.Cells["TotalAmount_Per_App"].Value)).Sum();
                ApplicationAmount = dg_AutoIPOApplication.SelectedRows.Cast<DataGridViewRow>()
                  .Where(c => Convert.ToString(c.Cells["SelectionID"].Value) == Convert.ToString(row)
                      && Convert.ToBoolean(c.Cells[0].Value) == true)
                  .Select(c => Convert.ToDouble(c.Cells["TotalAmount_Per_App"].Value)).Distinct().FirstOrDefault();
                string Deposit_Withdraw_TransCode = string.Empty;
                if (Deposit_Withdraw_IPOAcc_dtCustList == Indication_PaymentMode.Deposit)
                    Deposit_Withdraw_TransCode = Indication_PaymentMode.Withdraw;
                else
                    Deposit_Withdraw_TransCode = Indication_PaymentMode.Deposit;


                DateTime ReceivedDate = new DateTime();
                ReceivedDate = common.GetCurrentServerDate_FromDB().Date;
                string VoucherNo = "";


                int[] AppliedSessionID = dg_AutoIPOApplication.SelectedRows.Cast<DataGridViewRow>()
                    .Where(c => Convert.ToString(c.Cells["SelectionID"].Value) == Convert.ToString(row)
                        //&& Convert.ToString(c.Cells["ApplicationType"].Value) == Indication_IPOPaymentTransaction.AutoRequestType_Apply_Together
                     )
                    .Select(t => Convert.ToInt32(t.Cells["SessionID"].Value)).Distinct().ToArray();
                int AppliedSessionIDSingle = 0;
                if (AppliedSessionID.Count() == 1)
                    AppliedSessionIDSingle = AppliedSessionID[0];

                string Cust_Code_Payment = Cust_Code_IPoAcc_TransCode;
                double Amount_Payment = 0.00;

                 
                    Amount_Payment = Amount_TransCode;
                string Deposit_Withdraw_Payment = string.Empty;
                Deposit_Withdraw_IPOAcc_dtCustList=Indication_PaymentMode.Deposit;
                if (Deposit_Withdraw_IPOAcc_dtCustList == Indication_PaymentMode.Deposit)
                    Deposit_Withdraw_Payment = Indication_PaymentMode.Withdraw;
                else
                    Deposit_Withdraw_Payment = Indication_PaymentMode.Deposit;

                string[] ChannelType = dg_AutoIPOApplication.SelectedRows.Cast<DataGridViewRow>()
                    .Where(t=> Convert.ToString(t.Cells["SelectionID"].Value)==row)
                    .Select(t => Convert.ToString(t.Cells["Application_Mode"].Value)).ToArray();
                string SessionName = dg_AutoIPOApplication.SelectedRows.Cast<DataGridViewRow>()
                    .Select(c => Convert.ToString(c.Cells["Session_Name"].Value)).FirstOrDefault();
                ApplicationType = dg_AutoIPOApplication.SelectedRows.Cast<DataGridViewRow>()
                    .Where(c => Convert.ToString(c.Cells["SelectionID"].Value) == Convert.ToString(row))
                    .Select(c => Convert.ToString(c.Cells["ApplicationType"].Value)).Distinct().ToArray();
                 
                Dictionary<string,int> Refund=new Dictionary<string,int>();
                foreach (DataGridViewRow S_Row in dg_AutoIPOApplication.SelectedRows.Cast<DataGridViewRow>().Where(c => Convert.ToBoolean(c.Cells[0].Value) == true && Convert.ToString(c.Cells["SelectionID"].Value) == row))
                {
                    if (S_Row.Cells["ApplicationType"].Value.ToString() == Indication_IPOPaymentTransaction.AutoRequestType_Apply_Together)
                    {
                        Refund.Add(S_Row.Cells["Cust_Code"].Value.ToString(), Indication_IPORefundType.Refund_TRPRIPO_ID);
                    }
                    else if (Convert.ToString(S_Row.Cells["ApplicationType"].Value) == Indication_IPOPaymentTransaction.AutoRequestType_Single_Application)
                    {
                        Refund.Add(S_Row.Cells["Cust_Code"].Value.ToString(), Indication_IPORefundType.Refund_TRIPO_ID);
                    }
                }
                string[] RefundInto = Refund.Select(x =>string.Format("{0},{1}", x.Key ,x.Value)).ToArray();
                string name = Refund.Where(c => Convert.ToString(c.Key) == "4509").Select(c =>Convert.ToString(c.Value)).FirstOrDefault();
                IPOProcessBAL ipoBal = new IPOProcessBAL();
                double AppCharge = ipoBal.GetIPO_ChargeDef().Rows.Count > 0 ? Convert.ToDouble(ipoBal.GetIPO_ChargeDef().Rows[0]["AppCharge"]) : 0.00;
                Total_Applicant_Cust_Code = Cust_Code_IPoAcc_dtCustList.Concat(new string[] { Cust_Code_Payment }).ToArray();
                if (Total_Applicant_Cust_Code.Length > 0)
                {
                    try
                    {
                        ipoBal.ConnectDatabase();
                        if (ipoBal.CheckLock_UITrasnApplied() == false)
                        {
                            ipoBal.Lock_UITransApplied();
                            string prefix = ipoBal.GetPrefix_UITransApplied();
                            int serial = ipoBal.GetSerial_UITransApplied();
                            VoucherNo = prefix + "" + serial;
                            DataTable dt1 = new DataTable();
                            string Refund_Referencial = string.Empty;                            
                            Refund_Referencial = Cust_Code_IPoAcc_TransCode;
                            EntryBlanceChecking(Convert.ToString(row), Amount_Withdraw);
                            
                            foreach (string app_type in ApplicationType)
                            {
                                if (app_type == "ApplyTogether")
                                {
                                    dt1 = ipoBal.Insert_Transfer_Auto_IPO_DepositMoneyTransaction_UITransApplied(Cust_Code_IPoAcc_TransCode, Cust_Code_IPoAcc_dtCustList, Amount_TransCode, Amount_IPOAcc_dtCustList, Deposit_Withdraw_TransCode, Deposit_Withdraw_IPOAcc_dtCustList, ReceivedDate, VoucherNo, "", AppliedSessionIDSingle, ChannelType);
                                    ipoBal.Insert_AutoApply_Application_MoneyTransaction_UITransApplied(AppliedSessionID, Cust_Code_IPoAcc_dtCustList, Refund, Refund_Referencial, dt1, Convert.ToInt32(1), new string[] { }, new string[] { }, new string[] { }, ChannelType);
                                    foreach (string Cust_Code in Cust_Code_IPoAcc_dtCustList)
                                    {
                                        ipoBal.Auto_Application_Approval(Cust_Code, AppliedSessionIDSingle, AppCharge, SessionName);
                                    }
                                }
                                else if (app_type == "SingleApplication")
                                {
                                    //EntryBlanceChecking(Convert.ToString(Cust_Code_Payment), ApplicationAmount);
                                    ipoBal.Insert_AutoApply_Application_MoneyTransaction_UITransApplied(AppliedSessionID, new string[] { Cust_Code_Payment }, Refund, Refund_Referencial, dt1, Convert.ToInt32(1), new string[] { Refund_Referencial }, new string[] { }, new string[] { }, ChannelType);
                                    ipoBal.Auto_Application_Approval(Cust_Code_Payment, AppliedSessionIDSingle, AppCharge, SessionName);

                                }
                            }

                            ipoBal.UpdateVoucherNo_UITransApplied(serial + 1);
                            ipoBal.UnLock_UITransApplied();
                        }
                        ipoBal.Commit();

                    }
                    catch (Exception ex)
                    {
                        ipoBal.UnLock_UITransApplied();
                        ipoBal.RollBack();
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        ipoBal.CloseDatabase();
                    }
                }
            }
             
        }

        private void dg_AutoIPOApplication_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //RowCheckBoxClick();
        }
        private void RowCheckBoxClick()
        {
            foreach (DataGridViewRow Row in dg_AutoIPOApplication.Rows)
            {
                
                if (((Row.Cells[0].Value.Equals(true))) && Row.Cells[0].Value != DBNull.Value)
                {
                    this.dg_AutoIPOApplication.Rows[Row.Index].Selected = true;
                    //this.dg_AutoIPOApplication.Rows[Row.Index].Cells["Remarks"].ReadOnly = false;
                    Row.DefaultCellStyle.SelectionBackColor = Color.LightSlateGray;
                }
                else
                {
                    this.dg_AutoIPOApplication.Rows[Row.Index].Selected = false;
                    //this.dg_AutoIPOApplication.Rows[Row.Index].Cells["Select"].ReadOnly = true;
                }
            }
        }

        private void dg_AutoIPOApplication_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dg_AutoIPOApplication.IsCurrentCellDirty)
            {
                dg_AutoIPOApplication.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dg_AutoIPOApplication_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (Convert.ToBoolean(dg_AutoIPOApplication.Rows[e.RowIndex].Cells[0].Value) == true)
                {
                    for (int i = 0; i <= dg_AutoIPOApplication.Rows.Count - 1; i++)
                    {
                        if (Convert.ToBoolean(dg_AutoIPOApplication.Rows[i].Cells[0].Value) == true)
                        {
                            dg_AutoIPOApplication.Rows[i].Selected = true;
                        }
                        if (Convert.ToBoolean(dg_AutoIPOApplication.Rows[i].Cells[0].Value) == false)
                        {
                            dg_AutoIPOApplication.Rows[i].Selected = false;
                        }
                    }
                }
            }

        }

        private void dg_AutoIPOApplication_DataSourceChanged(object sender, EventArgs e)
        {

            tl_Eligible_Client.Text = "Total Eligible Client : ( " + dg_AutoIPOApplication.Rows.Count + " )";
            tl_Select_For_Application.Text = "You have Select : " + dg_AutoIPOApplication.SelectedRows.Cast<DataGridViewRow>().Where(c => Convert.ToBoolean(c.Cells[0].Value) == true).Count();
                //.Select(c => Convert.ToBoolean(c.Cells[0].Value)).Count();
        }

        //Added BY Md.Rashedul Hasan 20-Jan-2015
        /// <summary>
        /// Withdraw Balance Checking For withdraw Transaction
        /// </summary>
        /// <param name="cust_code"></param>
        /// <param name="Distributed_Amount"></param>
        private void EntryBlanceChecking(string cust_code, double Distributed_Amount)
        {
            IPOProcessBAL ACBal = new IPOProcessBAL();
            string[] Total_withdraw_transaction_Name = null;
            string[] Total_Deposit_transaction_Name = null;
            string[] Total_Withdraw_Pending = null;
            string[] Total_Deposit_Pending = null;
            string[] Previous_Balance = null;
            string[] Present_Approve_Pending_Balance = null;
            DataTable dt = new DataTable();
            dt = ACBal.GetIPOAccountInformation(cust_code);
            if (dt.Rows.Count > 0)
            {
                Total_Balance = 0.00;
                Total_Approved_Pending_Balance = 0.00;
                Withdraw_Pending_Balance = 0.00;
                Deposit_Pending_Balance = 0.00;

                Previous_Balance = dt.Rows.OfType<DataRow>().Select(c => Convert.ToString(c["Presenct_Balance"])).ToArray(); ;
                Total_withdraw_transaction_Name = dt.Rows.OfType<DataRow>().Select(c => Convert.ToString(c["Withdraw_Pending_Transaction_Name"])).ToArray();
                Total_Deposit_transaction_Name = dt.Rows.Cast<DataRow>().Select(c => Convert.ToString(c["Deposit_Pending_Transaction_Name"])).ToArray();
                //Deposit_Transaction_Name = dt.Rows[0]["Deposit_Pending_Transaction_Name"].ToString();
                //Withdraw_Transaction_Name = dt.Rows[0]["Withdraw_Pending_Transaction_Name"].ToString();
                Withdraw_Transaction_Name = string.Join(",", Total_withdraw_transaction_Name);
                Deposit_Transaction_Name = string.Join(",", Total_Deposit_transaction_Name);

                Present_Approve_Pending_Balance = dt.Rows.Cast<DataRow>().Select(c => Convert.ToString(c["ApprovePendingBalance"])).ToArray();
                Total_Withdraw_Pending = dt.Rows.OfType<DataRow>().Select(c => Convert.ToString(c["Withdraw_Pending"])).ToArray();
                Total_Deposit_Pending = dt.Rows.OfType<DataRow>().Select(c => Convert.ToString(c["Deposit_Pending"])).ToArray();

                for (int i = 0; i < Previous_Balance.Length; i++)
                {
                    double Hold = 0.00;
                    if (Previous_Balance[i] != "")
                    {
                        Hold = Convert.ToDouble(Previous_Balance[i]);
                        Total_Balance = Hold;
                    }
                }
                for (int i = 0; i < Present_Approve_Pending_Balance.Length; i++)
                {
                    double P_Hold = 0.00;
                    if (Present_Approve_Pending_Balance[i] != "")
                    {
                        P_Hold = Convert.ToDouble(Present_Approve_Pending_Balance[i]);
                        Total_Approved_Pending_Balance = P_Hold;
                    }
                }
                for (int i = 0; i < Total_Withdraw_Pending.Length; i++)
                {
                    double W_con = 0.00;
                    string W_Pending = Total_Withdraw_Pending[i];
                    if (W_Pending == "")
                    {
                        W_Pending = "0";
                        W_con = W_con + Convert.ToDouble(W_Pending);
                    }
                    else
                    {
                        W_con = W_con + Convert.ToDouble(W_Pending);
                    }
                    Withdraw_Pending_Balance = Withdraw_Pending_Balance + W_con;
                }
                for (int i = 0; i < Total_Deposit_Pending.Length; i++)
                {
                    double D_con = 0.00;
                    //Convert.ToDecimal(D_Pending);

                    string D_Pending = Total_Deposit_Pending[i];
                    if (D_Pending == "")
                    {
                        D_Pending = "0";
                        D_con = D_con + Convert.ToDouble(D_Pending);
                    }
                    else
                    {
                        D_con = D_con + Convert.ToDouble(D_Pending);
                    }
                    Deposit_Pending_Balance = Deposit_Pending_Balance + D_con;
                }
                //Convert.ToDecimal(dt.Rows[0]["Withdraw_Pending"]);
                if ((Total_Balance - Withdraw_Pending_Balance) < Distributed_Amount)
                {
                    throw new Exception("Your previous Balance =" + Total_Balance + "\n available withdrawal Balance = " + Total_Approved_Pending_Balance + "\n Total Pendding deposit Amount = " + Deposit_Pending_Balance + " Deposit Transaction Pending By: " + Deposit_Transaction_Name + "\n Total Withdraw Balance = " + Withdraw_Pending_Balance + " Withdraw Transaction Pending By: " + Withdraw_Transaction_Name + "\n For This Cust Code= " + cust_code);
                }
            }

        }

        private void btnGetGligible_Click(object sender, EventArgs e)
        {
            try
            {
                Thread thread = new Thread(WaitWindow_Thread);
                isProgressed = true;
                thread.Start();
                string Total_Client = "";
                if (btnGetGligible.Text == "GetEligible")
                {
                    if (string.IsNullOrEmpty(CmbCompanyShortCoede.Text))
                    {
                        throw new Exception("Select a valid company");
                    }
                    else
                    {
                        LoadGridData_Eligible(Convert.ToInt32(CmbCompanyShortCoede.SelectedValue));
                        Total_Client = "Total Eligible Client : ( " + dg_AutoIPOApplication.Rows.Count + " )";
                        tl_Eligible_Client.Text = Total_Client;
                        Tl_Groupselection.Visible = false;
                    }
                }
                else if (btnGetGligible.Text == "GetInEligible")
                {
                    if (string.IsNullOrEmpty(CmbCompanyShortCoede.Text))
                    {
                        throw new Exception("Select a valid company");

                    }
                    else
                    {
                        LoadGridData_InEligible(Convert.ToInt32(CmbCompanyShortCoede.SelectedValue));
                        Total_Client = "Total InEligible Client : ( " + dg_InEligibleCustomer.Rows.Count + " )";
                        tl_Eligible_Client.Text = Total_Client;
                        Tl_Groupselection.Visible = false;
                    }
                }
                else if (btnGetGligible.Text == "Get All Register code")
                {
                    if (string.IsNullOrEmpty(CmbCompanyShortCoede.Text))
                    {
                        throw new Exception("Select a valid company");
                    }
                    else
                    {
                        GetAllRegisterCode();
                    }
                }
                isProgressed = false;
            }
            catch (Exception ex)
            {
                isProgressed = false;
                MessageBox.Show(ex.Message);
            }
        }
        public static bool isProgressed;
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

         

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = AutoBal.Get_TotalRegisterClient_ForAutoApplication<int>(Convert.ToInt32(CmbCompanyShortCoede.SelectedValue));
            if (tabControl1.SelectedTab == tabControl1.TabPages[0])
            {
                //CmbCompanyShortCoede.SelectedIndex = 0;
                CurrentFormName = FromName.Eligible_Customer;
                this.Text = "Eligible Customer For Auto Application";
                btnGetGligible.Text = "GetEligible";
                //btnGetGligible_Click(sender, e);
                TxtTotalRegisterClient.Text = "Total Register Client = " + Convert.ToString(dt.Rows.Cast<DataRow>().Count());
                Tl_Groupselection.Visible = false;
            }
            else if (tabControl1.SelectedTab == tabControl1.TabPages[1])
            {
                //CmbCompanyShortCoede.SelectedIndex = 0;
                CurrentFormName = FromName.Ineligible_Customer;
                this.Text = "In Eligible Customer For Auto Application";
                btnGetGligible.Text = "GetInEligible";
                //btnGetGligible_Click(sender, e);
                TxtTotalRegisterClient.Text = "Total Register Client = " + Convert.ToString(dt.Rows.Cast<DataRow>().Count());
                Tl_Groupselection.Visible = false;
            }
            else if (tabControl1.SelectedTab == tabControl1.TabPages[2])
            {
                //CmbCompanyShortCoede.SelectedIndex = 0;
                CurrentFormName = FromName.All_Register_Customer;
                this.Text = "All Register Code";
                btnGetGligible.Text = "Get All Register code";
                //btnGetGligible_Click(sender, e);
                //TxtTotalRegisterClient.Text = "Total Register Client = " + Convert.ToString(dt.Rows.Cast<DataRow>().Count());
                //dg_AllRegisterCode.DataSource = dt;
                GetAllRegisterCode();
            }
        }

        private void dg_AllRegisterCode_DataSourceChanged(object sender, EventArgs e)
        {
            if (dg_AllRegisterCode.Rows.Count > 0)
            {
                //tl_Select_For_Application.Text = "You have registered = " + dg_AllRegisterCode.Rows.Count;
                tl_Eligible_Client.Text = "Total Parent code found = " + dg_AllRegisterCode.Rows.Cast<DataGridViewRow>()
                    .Where(c => Convert.ToInt32(c.Cells["Parent_Code"].Value) != 0)
                    .Select(c => Convert.ToString(c.Cells["Parent_Code"].Value)).Distinct().Count();
            }
        }
        private void GetAllRegisterCode()
        {
            DataTable dt = new DataTable();
            dt = AutoBal.Get_TotalRegisterClient_ForAutoApplication<int>(Convert.ToInt32(CmbCompanyShortCoede.SelectedValue));
            var dtsort = dt.Rows.Cast<DataRow>().OrderBy(t => Convert.ToString(t["Parent_Code"]));
            dg_AllRegisterCode.DataSource = dtsort.CopyToDataTable();
            TxtTotalRegisterClient.Text = "Total Register Client = " + Convert.ToString(dt.Rows.Cast<DataRow>().Count());
            tl_Select_For_Application.Text = "Application Done = " + Convert.ToString(dt.Rows.Cast<DataRow>().Where(t => Convert.ToString(t["App_Cust_Code"]) != "").Count());
            tl_Eligible_Client.Text = "Application not Done = " + Convert.ToString(dt.Rows.Cast<DataRow>().Where(t => Convert.ToString(t["App_Cust_Code"]) == "").Count());
            if (txtSearchParent.Text != "")
            {
                Tl_Groupselection.Visible = true;
                Tl_Groupselection.Text = "Total Register code ( " + dt.Rows.Cast<DataRow>()
                                                            .Where(t => Convert.ToString(t["Parent_Code"]) == txtSearchParent.Text.Trim())
                                                            .Select(t => Convert.ToString(t["Cust_Code"])).Distinct().Count() + ") For ( " + txtSearchParent.Text + " ) parent code";
            }
        }
        private void txtSearchParent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GetAllRegisterCode();
            }
        }
    }
}
