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
    public partial class frmAllParentChildInformation : Form
    {
        public frmAllParentChildInformation()
        {
            InitializeComponent();
        }

        ParentAndChildBAL bal = new ParentAndChildBAL();
        private string _CommpanyName;
        private string _branchName;
        private string _branchAddress;
        private string _branchContactNumber;
        

        private void frmAllParentChildInformation_Load(object sender, EventArgs e)
        {
             
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ParentChildGroupCode = TxtCustCode.Text;
            //string NonParentChildCode = cmbnonGroupCode.Text;
            DataTable dt = new DataTable();
            CrParentChildInfo rpt = new CrParentChildInfo();
            frmReportViewer view = new frmReportViewer();             
                dt = bal.GetAllChild_ShareAndMoney_Information(ParentChildGroupCode);            
             
            rpt.SetDataSource(dt);
            GetCommonInfo();
            ((TextObject)rpt.ReportDefinition.Sections[2].ReportObjects["txtCompanyName"]).Text = _CommpanyName;
            ((TextObject)rpt.ReportDefinition.Sections[2].ReportObjects["txtAddress"]).Text = _branchAddress;
           ((TextObject)rpt.ReportDefinition.Sections[2].ReportObjects["txtReportName"]).Text = "All Account Information";
            view.crvReportViewer.ReportSource = rpt;
            view.Show();
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

        //private void LoadCombobox()
        //{
        //    if (ChkGroupCode.Checked == true)
        //    {
        //        DataTable dtParentCode = new DataTable();

        //        dtParentCode = bal.GetParentCode();
        //        cmbParentCode.DataSource = dtParentCode;
        //        cmbParentCode.DisplayMember = dtParentCode.Columns[0].ToString();
        //        cmbParentCode.ValueMember = dtParentCode.Columns[0].ToString();
        //    }
        //    else if (ChkNonGroupCode.Checked == true)
        //    {
        //        DataTable dtAllActiveCode = new DataTable();                 
        //        dtAllActiveCode = bal.GetAllActiveCustomerCode();
        //        cmbnonGroupCode.DataSource = dtAllActiveCode;
        //        cmbnonGroupCode.DisplayMember = dtAllActiveCode.Columns[0].ToString();
        //        cmbnonGroupCode.ValueMember = dtAllActiveCode.Columns[0].ToString();
        //    }
        //}

        private void ChkNonGroupCode_CheckedChanged(object sender, EventArgs e)
        {
            //if (ChkNonGroupCode.Checked == true)
            //{
            //    cmbnonGroupCode.Enabled = true;
            //    cmbParentCode.Enabled = false;
            //    ChkGroupCode.Checked = false;
            //    cmbParentCode.Text = "";
            //    LoadCombobox();
            //}
            //else
            //{
            //    //cmbnonGroupCode.Enabled = false;
            //    cmbParentCode.Enabled = false;
            //}
        }

        private void ChkGroupCode_CheckedChanged(object sender, EventArgs e)
        {
            //if (ChkGroupCode.Checked == true)
            //{
            //    cmbParentCode.Enabled = true;
            //    cmbnonGroupCode.Enabled = false;
            //    ChkNonGroupCode.Checked = false;
            //    cmbnonGroupCode.Text = "";
            //    LoadCombobox();
            //}
            //else
            //{
            //    cmbnonGroupCode.Enabled = false;
            //    //cmbParentCode.Enabled = false;
            //}
        }
    }
}
