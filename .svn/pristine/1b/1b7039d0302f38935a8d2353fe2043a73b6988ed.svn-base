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
using BusinessAccessLayer.Constants;
using Reports;
using CrystalDecisions.CrystalReports.Engine;

namespace StockbrokerProNewArch
{
    public partial class frm_IPOApplicationProcess : Form
    {

        private DataTable dt_EligableCustomer;
        private DataTable dt_AppliedCustomer;

        private int _dGEligibleCustomer_RowIndex;
        private int _dGAppliedCustomer_RowIndex;
        
        public frm_IPOApplicationProcess()
        {
            InitializeComponent();
            
        }
     

        #region Global Variable
        
        int RowCount;
        int Cust_code;
        DataTable dt_EligibleClient;
        DataTable dt_AppliedClient;
        
        #endregion

        #region Load Combo Box
        private void LoadCombo()
            {
                IPOProcessBAL ipoBal = new IPOProcessBAL();
                
                DataTable dt_Company = ipoBal.GetIPOSessionALL();
                cmb_CompanyName.DataSource = dt_Company;
                cmb_CompanyName.DisplayMember = "Company_Name";
                cmb_CompanyName.ValueMember = "ID";

                cmb_CompanyName.SelectedIndex =- 1;

                DataTable dt_RefundType = ipoBal.GetRefundMethod();
                cmb_RefundType.DataSource = dt_RefundType;
                cmb_RefundType.DisplayMember = "Name";
                cmb_RefundType.ValueMember = "ID";

                cmb_RefundType.SelectedIndex = -1;
            }
        private void LoadSchemaForDataTable()
        {
            IPOProcessBAL ipoBal=new IPOProcessBAL();
            DataTable dt = ipoBal.GetEligibleCustomer(-1);
            dt_EligableCustomer = dt;
            dt_AppliedCustomer = dt;
        }
        #endregion

       

        #region From Load

            private void IpoApplicationProcess_Load(object sender, EventArgs e)
            {
                LoadCombo();
                LoadSchemaForDataTable();
            }
          
        #endregion

        #region        
       
        private void SetDataTableToDataGridView()
        {
            dgvEligibleCustomer.DataSource = dt_EligableCustomer;
           
            dgv_FinalCheck.DataSource = dt_AppliedCustomer;
           
        }

        private void ClearByEligibleCustomer()
        {
            if (dt_AppliedCustomer != null)
                dt_AppliedCustomer.Clear();
            if (dt_EligableCustomer != null)
                dt_EligableCustomer.Clear();
            SetDataTableToDataGridView();
        }

        private void ClearBySelectIPOSession()
        {
            txt_Premium.Text = string.Empty;
            txtSessAmount.Text = string.Empty;
            txtSessName.Text = string.Empty;
            txtSessNoOfShare.Text = string.Empty;
            txtTotalAmount.Text = string.Empty;
        }

        private void Check_Validation()
        {
            if (Convert.ToInt32(cmb_CompanyName.SelectedValue) < 0 || cmb_CompanyName.SelectedValue==null)
            {
                throw new Exception("Please Selecte A Company!!");
            }
            if (Convert.ToInt32(cmb_RefundType.SelectedValue) < 0 || cmb_RefundType.SelectedValue== null)
            {
                throw new Exception("Please Selecte A RefundValue!!");
            }
        }

        #endregion

        private void cmb_CompanyName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_CompanyName.ValueMember !=string.Empty)
            {
                IPOProcessBAL ipoBal=new IPOProcessBAL();
                
                ClearBySelectIPOSession();
                ClearByEligibleCustomer();
                
                int id = Convert.ToInt32(cmb_CompanyName.SelectedValue);
                DataTable dt = ipoBal.GetIPOSessionInfo_BySessionId(id);

                if(dt.Rows.Count>0)
                {
                    txtSessName.Text = Convert.ToString(dt.Rows[0]["IPOSession_Name"]);
                    txtSessAmount.Text = Convert.ToString(dt.Rows[0]["Amount"]);
                    txtSessNoOfShare.Text = Convert.ToString(dt.Rows[0]["No_Of_Share"]);
                    txtTotalAmount.Text = Convert.ToString(dt.Rows[0]["TotalAmount"]);
                    txt_Premium.Text = Convert.ToString(dt.Rows[0]["Premium"]);
                }

            }
        }

        private void btnEligibleClient_Click(object sender, EventArgs e)
        {
            if (cmb_CompanyName.ValueMember != string.Empty)
            {   
                IPOProcessBAL ipoBal = new IPOProcessBAL();
                ClearByEligibleCustomer();
                int id = Convert.ToInt32(cmb_CompanyName.SelectedValue);
                dt_EligableCustomer = ipoBal.GetEligibleCustomer(id);
                SetDataTableToDataGridView();
            }
        }
        
        private void dgvEligibleCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _dGEligibleCustomer_RowIndex = e.RowIndex;
        }

        private void dgvFinalCheck_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _dGAppliedCustomer_RowIndex = e.RowIndex;
           
        }

        private void btnSingleForward_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow dr = dt_EligableCustomer.Rows[_dGEligibleCustomer_RowIndex];
                dt_AppliedCustomer.Rows.Add(dr.ItemArray);
                dt_EligableCustomer.Rows.RemoveAt(_dGEligibleCustomer_RowIndex);
                SetDataTableToDataGridView();
                btnVerify.Visible = true;
                btnVerify.Enabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void btnsingleBackword_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow dr = dt_AppliedCustomer.Rows[_dGAppliedCustomer_RowIndex];
                dt_EligableCustomer.Rows.Add(dr.ItemArray);
                dt_AppliedCustomer.Rows.RemoveAt(_dGAppliedCustomer_RowIndex);
                SetDataTableToDataGridView();
                btnVerify.Visible = false;
                btnVerify.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDoubleForward_Click(object sender, EventArgs e)
        {
            try
            {
                
                for (int i = 0; i <dt_EligableCustomer.Rows.Count; i++)
                {
                    dt_AppliedCustomer.Rows.Add(dt_EligableCustomer.Rows[i].ItemArray);
                }
                dt_EligableCustomer.Clear();
                SetDataTableToDataGridView();
                btnVerify.Visible = true;
                btnVerify.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDoubleBackWard_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < dt_AppliedCustomer.Rows.Count; i++)
                {
                    dt_EligableCustomer.Rows.Add(dt_AppliedCustomer.Rows[i].ItemArray);
                }
                dt_AppliedCustomer.Clear();
                SetDataTableToDataGridView();
                btnVerify.Visible = false;
                btnVerify.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Process_Click(object sender, EventArgs e)
        {
            try
            {
                Check_Validation();
                IPOProcessBAL ipoBal = new IPOProcessBAL();

                string[] Cust_Codes = dt_AppliedCustomer.Rows.Cast<DataRow>().Select(t => Convert.ToString(t["Cust_Code"])).ToArray();
                int SessionID = Convert.ToInt32(cmb_CompanyName.SelectedValue);
                int RefundID=Convert.ToInt32(cmb_RefundType.SelectedValue);

                if (Cust_Codes.Length ==0)
                    throw new Exception("No Customer Found");
                if (SessionID < 0)
                    throw new Exception("No Company Name Selected");
                if (RefundID < 0)
                    throw new Exception("No Refund Type Selected");

                string Refund_Reference=string.Empty;

                if (cmb_RefundType.Text == Indication_IPORefundType.Refund_TRPR)
                {
                   Refund_Reference= txt_Cust_Code_ForReturnTransferParent.Text;
                }
                ipoBal.Insert_ApplyApplication_MoneyTransaction(new int[] { SessionID }, Cust_Codes, RefundID, Refund_Reference,0);
                MessageBox.Show("Application Process Successfully Done But Skip Those Customer Already Applied !!");
                ClearBySelectIPOSession();
                ClearByEligibleCustomer();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmb_RefundType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_RefundType.Text == Indication_IPORefundType.Refund_TRPR)
            {
                txt_Cust_Code_ForReturnTransferParent.Enabled = true;
                txt_Cust_Code_ForReturnTransferParent.Text = string.Empty;
            }
            else
            {
                txt_Cust_Code_ForReturnTransferParent.Enabled = false;
                txt_Cust_Code_ForReturnTransferParent.Text = string.Empty;
            }
        }

        private string[] ref_cust_code;
        private int ref_cust_code_index = 0;

        #region Signature Info
        private void btnVerify_Click(object sender, EventArgs e)
        {
            DataTable dtcode = new DataTable();
            //dtcode = dgv_FinalCheck;

            string[] orderId = dt_AppliedCustomer.Rows.Cast<DataRow>().Select(t => Convert.ToString(t["Cust_Code"])).ToArray();
            //ref_cust_code = orderId;
            //if (ref_cust_code.Length - 1 > ref_cust_code_index)
            //{
            //    ref_cust_code_index++;
            //}
            //else
            //{
            //    ref_cust_code_index = 0;
            //}
            //string ref_cust_code_list = ref_cust_code[ref_cust_code_index];

            //string id = (string)dgv_FinalCheck.SelectedCells[0].Value; 
            string[] sessionId = new string[] {Convert.ToString(cmb_CompanyName.SelectedValue) };
            IPOProcessBAL objBAL = new IPOProcessBAL();
            DataTable dt = new DataTable();
            crIpoApplicationForPublicIssueSignature objrpt = new crIpoApplicationForPublicIssueSignature();
            frmIPOReportViewer viewer = new frmIPOReportViewer();

            dt = objBAL.GetPublicIssueFromBeforeApplication(orderId, sessionId);
            

            objrpt.SetDataSource(dt);
            GetCommonInfo();
            ((TextObject)objrpt.ReportDefinition.Sections[2].ReportObjects["txtreportName"]).Text =
                               "IPO Application for public issue";
            ((TextObject)objrpt.ReportDefinition.Sections[2].ReportObjects["txtCompanyName"]).Text =
                _CommpanyName;
            ///// Load Branch Name
            ((TextObject)objrpt.ReportDefinition.Sections[2].ReportObjects["txtBranchName"]).Text =
                "Branch Name:" + _branchName + "," + _branchAddress + ". Phone:" + _branchContactNumber;
            viewer.crystalReportViewer1.ReportSource = objrpt;
            viewer.StartPosition = FormStartPosition.CenterScreen;
            viewer.ShowDialog(this);
        

        }
        private string _CommpanyName;
        private string _branchName;
        private string _branchAddress;
        private string _branchContactNumber;
        private void GetCommonInfo()
        {

            try
            {
                CommonInfoBal objCommonInfoBal = new CommonInfoBal();
                DataRow drCommonInfo = null;

                drCommonInfo = objCommonInfoBal.GetCommpanyInfo();

                if (drCommonInfo != null)
                {
                    _CommpanyName = drCommonInfo.Table.Rows[0][0].ToString();
                    _branchName = drCommonInfo.Table.Rows[0][1].ToString();
                    _branchAddress = drCommonInfo.Table.Rows[0][2].ToString();
                    _branchContactNumber = drCommonInfo.Table.Rows[0][3].ToString();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        private void btnImageVerify_Click(object sender, EventArgs e)
        {
            string[] orderId = dt_AppliedCustomer.Rows.Cast<DataRow>().Select(t => Convert.ToString(t["Cust_Code"])).ToArray();
            ref_cust_code = orderId;
            if (ref_cust_code.Length - 1 > ref_cust_code_index)
            {
                ref_cust_code_index++;
            }

            else
            {
                ref_cust_code_index = 0;
            }
            string ref_cust_code_list = ref_cust_code[ref_cust_code_index];
            frmCustomerVerificationInfo info = new frmCustomerVerificationInfo(orderId);
            info.StartPosition = FormStartPosition.CenterScreen;
            info.ShowDialog(this);

        }
    }
}
