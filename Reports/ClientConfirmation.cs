using System;
using System.Data;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using BusinessAccessLayer.BO;
using CrystalDecisions.CrystalReports.Engine;
using BusinessAccessLayer.Constants;
namespace Reports
{
    public partial class ClientConfirmation : Form
    {
        public static bool _viewReport;
        public static bool _printOfficeCopy;
        public static bool _printClientCopy;
        public static DateTime _transDate;
        public static string _boID = "";
        public static string _custCode = "";
        public static int _branchId;

        private string _filterdColumnName;

        public ClientConfirmation()
        {
            InitializeComponent();
        }

        private void ClientConfirmation_Load(object sender, EventArgs e)
        {
            ddlSearchCustomer.SelectedIndex = 0;
            rdoViewReport.Checked = true;

        }

        private void txtSearchCustomer_KeyDown(object sender, KeyEventArgs e)
        {
           
            if (e.KeyCode.ToString() == "Return")
            {
                if (txtSearchCustomer.Text.Trim() == "")
                {
                    MessageBox.Show("Atfirst Enter a customer code/BO Id.");
                }
                else
                {
                    LoadCustInfo();
                }
            }
        }
        private void LoadCustInfo()
        {
            DataTable custDateTable = new DataTable();
            CustomerInfoBAL customerInfoBAL = new CustomerInfoBAL();
            if (ddlSearchCustomer.SelectedItem.Equals("BO Id"))
            {
                _boID = txtSearchCustomer.Text;
                custDateTable = customerInfoBAL.GetCustInfoByBOID(_boID);
                if (custDateTable.Rows.Count > 0)
                {
                    int _custCode = Convert.ToInt32(custDateTable.Rows[0][0].ToString());
                    txtCustCode.Text = custDateTable.Rows[0][0].ToString();
                    txtAccountHolderName.Text = custDateTable.Rows[0][1].ToString();
                    txtAccountHolderBOId.Text = custDateTable.Rows[0][2].ToString();
                }
                else
                {
                    MessageBox.Show("No customer found.");
                }
            }
            else
            {
                _custCode = txtSearchCustomer.Text;
                custDateTable = customerInfoBAL.GetCustInfoByCustCode(_custCode);
                if (custDateTable.Rows.Count > 0)
                {
                    txtCustCode.Text = custDateTable.Rows[0][0].ToString();
                    txtAccountHolderName.Text = custDateTable.Rows[0][1].ToString();
                    txtAccountHolderBOId.Text = custDateTable.Rows[0][2].ToString();
                }
                else
                {
                    MessageBox.Show("No customer found.");
                }
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            ShowClientConfirmationReport();
        }
        public void ShowClientConfirmationReport()
        {

            _branchId = GlobalVariableBO._branchId;
            _viewReport = rdoViewReport.Checked;
            _printClientCopy = rdoClientCopy.Checked;
            _printOfficeCopy = rdoOfficeCopy.Checked;
            _transDate = Convert.ToDateTime(dtTransDate.Value.ToShortDateString());
            _custCode = txtCustCode.Text;

            ClientConfirmationBAL clientConfirmationBal = new ClientConfirmationBAL();
            LoadCommonInfo CmmInfo = new LoadCommonInfo();

            if (_viewReport)
            {
                if (txtCustCode.Text.Trim() == "")
                {
                    MessageBox.Show("Select a customer first.", "Warning!");
                    return;
                }

                crClientConfirmation crClientConfirm = new crClientConfirmation();
                ClientConfirmationViewer clientConfirmation = new ClientConfirmationViewer();
                DataTable dtClientBasicData=new DataTable();
                DataTable dtClientConfirmation = new DataTable();

                RecordLevelFilteringBAL obj = new RecordLevelFilteringBAL(ResourceName.Customer_Confirmation_default);
               // _filterdColumnName = obj.GetFilteredColumnName(ResourceName.Customer_Confirmation_default);

                string T_custCode = obj.FilterCustCode(_custCode, ResourceName.Customer_Confirmation_default);

                if (T_custCode == "")
                {
                    MessageBox.Show("You are restricted ");
                    return;
                }
                dtClientBasicData = clientConfirmationBal.GetClientBasicData(T_custCode, _transDate);


                if(dtClientBasicData.Rows.Count>0)
                {
                    ((TextObject)crClientConfirm.ReportDefinition.Sections[2].ReportObjects["txtCustName"]).Text = dtClientBasicData.Rows[0]["Cust_Name"].ToString();
                    ((TextObject) crClientConfirm.ReportDefinition.Sections[2].ReportObjects["txtCustCode"]).Text =dtClientBasicData.Rows[0]["Cust_Code"].ToString();
                    ((TextObject) crClientConfirm.ReportDefinition.Sections[2].ReportObjects["txtTradeDate"]).Text =dtClientBasicData.Rows[0]["Trade_Date"].ToString();
                    ((TextObject) crClientConfirm.ReportDefinition.Sections[4].ReportObjects["txtTradeDate2"]).Text ="(" +dtClientBasicData.Rows[0]["Trade_Date"].ToString() + ")";
                   // ((TextObject) crClientConfirm.ReportDefinition.Sections[4].ReportObjects["txtTradeDate3"]).Text =dtClientBasicData.Rows[0]["Trade_Date"].ToString();
                    ((TextObject)crClientConfirm.ReportDefinition.Sections[4].ReportObjects["txtInterestCharge"]).Text = dtClientBasicData.Rows[0]["Interest"].ToString();
                    
                }

                string temp_custCode = obj.FilterCustCode(_custCode, ResourceName.Customer_Confirmation_default);
                dtClientConfirmation = clientConfirmationBal.GetClientConfirmation(temp_custCode, _transDate);

                crClientConfirm.SetDataSource(dtClientConfirmation);
                ///// Load Company Name
                ((TextObject)crClientConfirm.ReportDefinition.Sections[2].ReportObjects["txtCompanyName"]).Text = CmmInfo.ShowCompanyName();

                ///// Load Branch Name
                ((TextObject)crClientConfirm.ReportDefinition.Sections[2].ReportObjects["txtBranchName"]).Text = CmmInfo.BranchDetails(_branchId);
                clientConfirmation.crvClientConfirmationReportViewer.ReportSource = crClientConfirm;
                clientConfirmation.Show();
            }
            else if (_printClientCopy)
            {
                crClientConfirmationClientCopy crClientCopy = new crClientConfirmationClientCopy();
                ClientConfirmationClientCopyViewer clientCopyViewer = new ClientConfirmationClientCopyViewer();
                DataTable dtClientConfClientCopy = new DataTable();
                dtClientConfClientCopy = clientConfirmationBal.getClientConfirmationClientCopy(_transDate);

                _filterdColumnName = dtClientConfClientCopy.Columns[0].ToString();
                RecordLevelFilteringBAL obj = new RecordLevelFilteringBAL(dtClientConfClientCopy, _filterdColumnName, ResourceName.Customer_Confirmation_ClientCopy);
                dtClientConfClientCopy = obj.GetRecordLevelFilteredData();

                crClientCopy.SetDataSource(dtClientConfClientCopy);
                //Load Trade date
                ((TextObject)crClientCopy.ReportDefinition.Sections[2].ReportObjects["txtTradeDate"]).Text =dtTransDate.Value.ToShortDateString();
                ((TextObject)crClientCopy.ReportDefinition.Sections[3].ReportObjects["txtTradeDate2"]).Text = dtTransDate.Value.ToShortDateString();
                ((TextObject)crClientCopy.ReportDefinition.Sections[3].ReportObjects["txtTradeDate3"]).Text = dtTransDate.Value.ToShortDateString();
                ///// Load Company Name
                ((TextObject)crClientCopy.ReportDefinition.Sections[1].ReportObjects["txtCompanyName"]).Text = CmmInfo.ShowCompanyName();

                ///// Load Branch Name
                ((TextObject)crClientCopy.ReportDefinition.Sections[1].ReportObjects["txtBranchName"]).Text = CmmInfo.BranchDetails(_branchId);
                clientCopyViewer.crvClientConfirmationClientCopyViewer.ReportSource = crClientCopy;
                clientCopyViewer.Show();
            }
            else if (_printOfficeCopy)
            {
                crClientConfirmationOfficeCopy crOfficeCopy = new crClientConfirmationOfficeCopy();
                ClientConfirmationOfficeCopyViewer officeCopyViewer = new ClientConfirmationOfficeCopyViewer();
                DataTable dtClientConfOfficeCopy = new DataTable();
                dtClientConfOfficeCopy = clientConfirmationBal.GetClientConfirmationOfficeCopy(_transDate);

                _filterdColumnName = dtClientConfOfficeCopy.Columns[0].ToString();
                RecordLevelFilteringBAL obj = new RecordLevelFilteringBAL(dtClientConfOfficeCopy, _filterdColumnName, ResourceName.Customer_Confirmation_OfficeCopy);
                dtClientConfOfficeCopy = obj.GetRecordLevelFilteredData();

                crOfficeCopy.SetDataSource(dtClientConfOfficeCopy);
                //Load Trade date
                ((TextObject)crOfficeCopy.ReportDefinition.Sections[2].ReportObjects["txtTradeDate"]).Text = dtTransDate.Value.ToShortDateString();
                ((TextObject)crOfficeCopy.ReportDefinition.Sections[3].ReportObjects["txtTradeDate2"]).Text = dtTransDate.Value.ToShortDateString();
                ((TextObject)crOfficeCopy.ReportDefinition.Sections[3].ReportObjects["txtTradeDate3"]).Text = dtTransDate.Value.ToShortDateString();
                ///// Load Company Name
                ((TextObject)crOfficeCopy.ReportDefinition.Sections[1].ReportObjects["txtCompanyName"]).Text = CmmInfo.ShowCompanyName();

                ///// Load Branch Name
                ((TextObject)crOfficeCopy.ReportDefinition.Sections[1].ReportObjects["txtBranchName"]).Text = CmmInfo.BranchDetails(_branchId);
                officeCopyViewer.crvClientConfirmationOfficeCopyViewer.ReportSource = crOfficeCopy;
                officeCopyViewer.Show();

            }
            else
            {
                MessageBox.Show("Please Select the report category first.");
            }

        }

        private void rdoViewReport_CheckedChanged(object sender, EventArgs e)
        {
            txtCustCode.Text = "";
            txtAccountHolderName.Text = "";
            txtAccountHolderBOId.Text = "";
            ddlSearchCustomer.Enabled = rdoViewReport.Checked;
            txtSearchCustomer.Enabled=rdoViewReport.Checked;
        }

        private void rdoClientCopy_CheckedChanged(object sender, EventArgs e)
        {
            txtCustCode.Text = "";
            txtAccountHolderName.Text = "";
            txtAccountHolderBOId.Text = "";
            ddlSearchCustomer.Enabled = rdoViewReport.Checked;
            txtSearchCustomer.Enabled = rdoViewReport.Checked;
        }

        private void rdoOfficeCopy_CheckedChanged(object sender, EventArgs e)
        {
            txtCustCode.Text = "";
            txtAccountHolderName.Text = "";
            txtAccountHolderBOId.Text = "";
            ddlSearchCustomer.Enabled = rdoViewReport.Checked;
            txtSearchCustomer.Enabled = rdoViewReport.Checked;
        }
    }
}
