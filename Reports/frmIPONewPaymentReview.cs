using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;

using CrystalDecisions.CrystalReports.Engine;

namespace Reports
{
    public partial class frmIPONewPaymentReview : Form
    {
        private string _CommpanyName;
        private string _branchName;
        private string _branchAddress;
        private string _branchContactNumber;
        private string _filterdColumnName;

        public frmIPONewPaymentReview()
        {
             
                InitializeComponent();
             
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CHKRB.Checked)
            {
                GetNewPaymentReview();
                //ChkNRB.Checked = false;
            }
            else if (ChkNRB.Checked)
            {
                GetNRBPaymentReview();
                //CHKRB.Checked = false;
            }
            else
            {
                MessageBox.Show("Checked Resident OR non Resident");
            }

        }
        private void GetNRBPaymentReview()
        {
            IPOReportBAL bal = new IPOReportBAL();
            DataTable dtPaymentReview_NRB = new DataTable();
            crIPONRBPayementReview crPayment = new crIPONRBPayementReview();
            frmIPOReportViewer paymentViewer = new frmIPOReportViewer();
            LoadCommonInfo CmmInfo = new LoadCommonInfo();

            int selected_BranchID = Convert.ToInt32(cmb_Branch_Name.SelectedValue);

            dtPaymentReview_NRB = bal.GETIPONRBPaymentReview(selected_BranchID, dtpFromDate.Value, dtpToDate.Value);
            crPayment.SetDataSource(dtPaymentReview_NRB);
            GetCommonInfo();
            ///// Load Company Name
            ((TextObject)crPayment.ReportDefinition.Sections[2].ReportObjects["txtCompanyName"]).Text = _CommpanyName;

            ///// Load Branch Name
            ((TextObject)crPayment.ReportDefinition.Sections[2].ReportObjects["txtAddress"]).Text = _branchName + "," + _branchAddress + ",Phone: " + _branchContactNumber;

            ////Load Date
            ((TextObject)crPayment.ReportDefinition.Sections[2].ReportObjects["txtFromDate"]).Text = dtpFromDate.Value.ToString("dd-MMM-yyyy") + " To " + dtpToDate.Value.ToString("dd-MMM-yyyy");
            paymentViewer.crystalReportViewer1.ReportSource = crPayment;
            paymentViewer.Show();

        }

        private void GetNewPaymentReview()
        {
            try
            {
                IPOPaymentReviewBAL paymentBAL = new IPOPaymentReviewBAL();
                DataTable dtPaymentReview = new DataTable();
                crIPONewPaymentReview crPayment = new crIPONewPaymentReview();
                frmIPOReportViewer paymentViewer = new frmIPOReportViewer();
                LoadCommonInfo CmmInfo = new LoadCommonInfo();

                int issorted = 0;
                int isAccountsView = 0;

                if (chbOder.Checked)
                    issorted = 1;
                else
                {
                    issorted = 0;
                }
                int selected_BranchID=Convert.ToInt32(cmb_Branch_Name.SelectedValue);
                dtPaymentReview = paymentBAL.GnerateIPOPaymentReview(dtpFromDate.Value, dtpToDate.Value, issorted, selected_BranchID);

                //_filterdColumnName = dtPaymentReview.Columns[1].ToString();
                //RecordLevelFilteringBAL obj = new RecordLevelFilteringBAL(dtPaymentReview, _filterdColumnName, ResourceName.New_Payment_Review);
                //dtPaymentReview = obj.GetRecordLevelFilteredData();

                crPayment.SetDataSource(dtPaymentReview);

                GetCommonInfo();
                ///// Load Company Name
                ((TextObject)crPayment.ReportDefinition.Sections[2].ReportObjects["txtCompanyName"]).Text = _CommpanyName;

                ///// Load Branch Name
                ((TextObject)crPayment.ReportDefinition.Sections[2].ReportObjects["txtAddress"]).Text = _branchName + "," + _branchAddress + ",Phone: " + _branchContactNumber;

                ////Load Date
                ((TextObject)crPayment.ReportDefinition.Sections[2].ReportObjects["txtFromDate"]).Text = dtpFromDate.Value.ToString("dd-MMM-yyyy") + " To " + dtpToDate.Value.ToString("dd-MMM-yyyy");

                paymentViewer.crystalReportViewer1.DisplayGroupTree = false;
                paymentViewer.crystalReportViewer1.ReportSource = crPayment;
                paymentViewer.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        BrokerInfoBAL bal = new BrokerInfoBAL();

        private void LoadCombo()
        {
            Cmb_Session.DataSource = bal.GetIPoSession();

            Cmb_Session.DisplayMember = "IPOSession_Name";
            Cmb_Session.ValueMember = "ID";
          //  Cmb_Session.SelectedItem = "All";
            Cmb_Session.SelectedIndex = -1;
            
        }

        private void frmIPONewPaymentReview_Load(object sender, EventArgs e)
        {
            LoadCombo();
            LoadSessionCmbo();
            Cmb_Session.Enabled = false;
        }

        private void LoadSessionCmbo()
        {
            BrokerInfoBAL bal = new BrokerInfoBAL();
            DataTable dt = new DataTable();
            dt = bal.GetBrokerBranchName();
            cmb_Branch_Name.DataSource = dt;
            cmb_Branch_Name.DisplayMember = "Branch_Name";
            cmb_Branch_Name.ValueMember = "Branch_ID";
            cmb_Branch_Name.SelectedIndex = 0;
        }

        private void ChkNRB_CheckedChanged(object sender, EventArgs e)
        {
            if (CHKRB.Checked)
            {
                CHKRB.Checked = false;
            }            
        }

        private void CHKRB_CheckedChanged(object sender, EventArgs e)
        {
            if (CHKRB.Checked)
            {
                ChkNRB.Checked = false;
            }            
        }


        private void Btt_ViewRpt_Click(object sender, EventArgs e)
        {
            //create by nobin /

            Frm_CryRpt_Display CryRpt_Display = new Frm_CryRpt_Display();

            DateTime _date;
            string _FormDate = "";
            string _ToDate = "";
            _date = DateTime.Parse(FormDate.Text);
            _FormDate = _date.ToString();

            _date = DateTime.Parse(ToDate.Text);
            _ToDate = _date.ToString();

            if (RadMulti_Trans.Checked == true)
            {

                Rpt_IPO_Mony_Transcetion Mony_trans = new Rpt_IPO_Mony_Transcetion();

                if (Cmb_Session.SelectedIndex == -1)
                {

                    DataTable dt = bal.IPO_Money_Trns(_FormDate, _ToDate);
                    Mony_trans.SetDataSource(dt);

                    string RptFormula = "{V_IPO_Money_Trns.Deposit_Type}<>'Single_Transaction'";
                    CryRpt_Display.ShowDialog(Mony_trans, RptFormula);
                }
                else
                {
                    ///IPo Appliction all showing singal and applay thogether. requrment rakimul vai. by nobin

                    DataTable dt = bal.IPO_Money_Trns(_FormDate, _ToDate);
                    Mony_trans.SetDataSource(dt);

                    string RptFormula = "{V_IPO_Money_Trns.IPO_SessionID}=" + Cmb_Session.SelectedValue + " ";
                    CryRpt_Display.ShowDialog(Mony_trans, RptFormula);
                }

            }

            else if (RadSingle_Trans.Checked == true)
            {
                Rpt_IPO_Mony_Transcetion Mony_trans = new Rpt_IPO_Mony_Transcetion();

                DataTable dt = bal.IPO_Single_Trans(_FormDate, _ToDate);
                Mony_trans.SetDataSource(dt);

                string RptFormula = "{V_IPO_Money_Trns.Deposit_Type}='Single_Transaction' ";
                CryRpt_Display.ShowDialog(Mony_trans, RptFormula);
            }

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void RadMulti_Trans_CheckedChanged(object sender, EventArgs e)
        {
            Cmb_Session.Enabled = true;
        }

        private void RadSingle_Trans_CheckedChanged(object sender, EventArgs e)
        {
            Cmb_Session.Enabled = false;
            
        }

        private void dtpFromDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpToDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void ToDate_ValueChanged(object sender, EventArgs e)
        {

        }


       

       
    }
}
