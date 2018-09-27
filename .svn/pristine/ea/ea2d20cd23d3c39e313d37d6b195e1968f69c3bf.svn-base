using System;
using System.Windows.Forms;
using DataAccessLayer;
using BusinessAccessLayer.BO;
using BusinessAccessLayer.BAL;
using System.Data;
using Reports;
using CrystalDecisions.CrystalReports.Engine;
//using BankBook.Components.AppSystem;
//using BankBookApplication.Components.DAL;
//using BankBook.Report.ReportValue;
//using BankBookApplication.Report;

namespace StockbrokerProNewArch
{
    public partial class FrmBO_OpeningForm : Form
    {
        private DbConnection _dbConnection;
        BO_Opening_InformationBO BoOpInfoBO = new BO_Opening_InformationBO();
        BO_Opening_InformationBAL BoOpInfoBAL = new BO_Opening_InformationBAL();
        cr_BoOpeningInformation cr_BoOpeningInformation = new cr_BoOpeningInformation();
              

        public static DateTime _fromDate;
        public static DateTime _toDate;
        private string _CommpanyName;
        private string _branchName;
        private string _branchAddress;
        private string _branchContactNumber;

        public FrmBO_OpeningForm()
        {
            InitializeComponent();          
        }
        private void SetTabIndex() 
        {
            int Index = 0;
            txtName.TabIndex = Index;
            Index += 1;
            txtMobileNo.TabIndex = Index;
            Index += 1;
            txtQuantity.TabIndex = Index;
            Index += 1;
            txtFormNo.TabIndex = Index;
            Index += 1;
            btnSave.TabIndex = Index;
        }
       

        private void FrmBO_OpeningForm_Load(object sender, EventArgs e)
        {
            SetTabIndex();
            txtName.Focus();
            GridViewLoging();  //note: Bo1
            gbReport.Visible = false;
        }

        private void GridViewLoging()
        {
            BO_Opening_InformationBAL BoOpInfoBAL = new BO_Opening_InformationBAL();
            string DateTime = Convert.ToString(pDate.Value.ToString("yyyy-MM-dd"));
            string sqlData = @"select b.OpDate as Dates
                                ,b.Name as Client_Name
                                ,b.CellNo as Mobile_No
                                ,b.Qty as Quantity
                                ,b.Price
                                ,b.TotalPrice as Total
                                ,b.FrmNoFast as First_Form_No
                                ,b.FrmNoLast as Last_FormNo 
                                from SBP_BO_OpeningInformation as b
                                where b.OpDate='" + DateTime+ @"'
                                ORDER BY SlNo DESC ";

            dgvFormInformation.DataSource = BoOpInfoBAL.Get_Data(sqlData);
            lblCount.Text = Convert.ToString(dgvFormInformation.Rows.Count-1);
        }

        private BO_Opening_InformationBO InitiallizeBoOpInfo()
        {
            BO_Opening_InformationBO BoOpInfoBO = new BO_Opening_InformationBO();
            BoOpInfoBO.Sl_No = 0;
            BoOpInfoBO.Name = txtName.Text.Trim();
            BoOpInfoBO.CellNo = txtMobileNo.Text;
            BoOpInfoBO.OpDate = Convert.ToDateTime(pDate.Value);
            BoOpInfoBO.Qty = Convert.ToInt32(txtQuantity.Text);
            BoOpInfoBO.Price = 50;  
            BoOpInfoBO.TotalPrice = Convert.ToDouble((txtTotalAmount.Text.Trim() == string.Empty) ? "0" : txtTotalAmount.Text.Trim());
            BoOpInfoBO.FrmNoFast = Convert.ToInt32(txtFormNo.Text);
            BoOpInfoBO.FrmNoLast = Convert.ToInt32(txtFormNoLast.Text);
            BoOpInfoBO.BranchId = GlobalVariableBO._branchId;
            BoOpInfoBO.CreateDate = System.DateTime.Now;
            BoOpInfoBO.CreateBy = GlobalVariableBO._userName;
            BoOpInfoBO.Remarks = txtRemarks.Text.Trim();

            return BoOpInfoBO;
        }
        private void Bo_Data_insrt()
        {
            BO_Opening_InformationBO BoInfo = new BO_Opening_InformationBO();
            BoInfo = InitiallizeBoOpInfo();
            BoOpInfoBAL.saveBoOpeningInfo(BoInfo);            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (InputValidationProcess())
                return;

            Bo_Data_insrt();
            
            MessageBox.Show("BO opening information Saved Successfully....", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            GridViewLoging();
            refreshProcess();
        }

        private bool InputValidationProcess()  //document file : InputValidationProcess
        
        {
            //if (this.txtName.Text == "")
            //{
            //    MessageBox.Show("Please Enter Customer Name.", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    this.txtName.Focus();
            //    return true;
            //}
            if (this.txtMobileNo.Text == "")
            {
                MessageBox.Show("Please Enter Cell Number.", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtMobileNo.Focus();
                return true;
            }
            else if (this.txtMobileNo.Text.Length != 11)
            {
                lblMobileNoError.Text = "Check Mobile Number.";
                lblMobileNoError.Visible = true;               
                this.txtMobileNo.Focus();
                return true;
            }
            else if (this.txtQuantity.Text == "")
            {
                MessageBox.Show("Please Enter Quantity.", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtQuantity.Focus();
                return true;
            }
            else if (this.txtFormNo.Text == "")
            {
                MessageBox.Show("Please Enter From No", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtFormNo.Focus();
                return true;
            }
           
            else return false;
        }

        private void refreshProcess()    // document file
        {
            txtName.Text = "";
            txtMobileNo.Text = "";
            pDate.Text = "";
            txtQuantity.Text = "";
            txtTotalAmount.Text = "";
            txtFormNo.Text = "";
            txtFormNoLast.Text = "";
            txtRemarks.Text = "";
            txtName.Focus();
            lblMobileNoError.Visible = false;
            gbReport.Visible = false;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refreshProcess();
        }

        private void txtQuantity_TextChanged_1(object sender, EventArgs e)  //document File : txtQuantity_TextChanged_1
        {
            if (txtQuantity.Text != "")
            {
                x = Convert.ToInt32(txtQuantity.Text);
                if(x==0)
                {
                    txtTotalAmount.Text = Convert.ToString(Convert.ToDecimal(txtQuantity.Text) * 50);
                }
                else if (x == 1)
                {
                    txtTotalAmount.Text = Convert.ToString(Convert.ToDecimal(txtQuantity.Text) * 50);
                    txtFormNoLast.Enabled = false;
                } 
                else if(x>1)
                {
                txtTotalAmount.Text = Convert.ToString(Convert.ToDecimal(txtQuantity.Text) * 50);
                } 
            }
            else
            {
                txtQuantity.Text = "";
                txtTotalAmount.Text = "";
            }
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                txtMobileNo.Focus();
            }
        }

        

        private void txtMobileNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                txtQuantity.Focus();
            }
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                txtFormNo.Focus();
            }
        }

        private void txtFormNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                btnSave.Focus();
            }
        }

        private void btnSave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                btnRefresh.Focus();
            }
        }

        private void txtFormNoLast_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                btnSave.Focus();
            }
        }

        int x = 0;
        private void txtFormNo_TextChanged(object sender, EventArgs e)
        {
            if(txtFormNo.Text !="")
            {
                x = Convert.ToInt32(txtFormNo.Text);
                if(x == 1)
                {
                    txtFormNoLast.Text = Convert.ToString((Convert.ToDecimal(txtFormNo.Text)) + (Convert.ToDecimal(txtQuantity.Text)) - 1);
                }
                
                else if(x > 1)
                {
                    txtFormNoLast.Text = Convert.ToString((Convert.ToDecimal(txtFormNo.Text))+(Convert.ToDecimal(txtQuantity.Text))-1);                 
                }
               
            }
            else
            {
                txtFormNoLast.Text = "";
            }
        }

        private void pDateSearch_ValueChanged(object sender, EventArgs e)
        {
            BO_Opening_InformationBAL BoOpInfoBAL = new BO_Opening_InformationBAL();
            string searchDate = Convert.ToString(pDateSearch.Value.ToString("yyyy-MM-dd"));
            dgvFormInformation.DataSource = BoOpInfoBAL.GetSearchData(searchDate);
            lblCount.Text = Convert.ToString(dgvFormInformation.Rows.Count);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            gbReport.Visible = true;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            ShowBoReport();
        }

        public void ShowBoReport()
        {
            frmIPOReportViewer viewer = new frmIPOReportViewer();
            _fromDate = Convert.ToDateTime(pRptStartDate.Value.ToShortDateString());
            _toDate = Convert.ToDateTime(pRptEndDate.Value.ToShortDateString());

            DataTable dtBoInfo = new DataTable();
            dtBoInfo = BoOpInfoBAL.getBoInfo(_fromDate, _toDate);
            cr_BoOpeningInformation.SetDataSource(dtBoInfo);
            GetCommonInfo();

            ((TextObject)cr_BoOpeningInformation.ReportDefinition.Sections[2].ReportObjects["txtCompanyName"]).Text =
               _CommpanyName;         
            ((TextObject)cr_BoOpeningInformation.ReportDefinition.Sections[2].ReportObjects["txtBranchName"]).Text =
                "Branch Name:" + _branchName + "," + _branchAddress + ". Phone:" + _branchContactNumber;
            ((TextObject)cr_BoOpeningInformation.ReportDefinition.Sections[2].ReportObjects["txtduration"]).Text =
                    "Duration : " + pRptStartDate.Value.ToString("dd-MMM-yyyy") + " To " +
                    pRptEndDate.Value.ToString("dd-MMM-yyyy");

            
            viewer.crystalReportViewer1.ReportSource = cr_BoOpeningInformation;
            viewer.Show();
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
            catch (Exception)
            {

                throw;
            }
        }
    }
}


