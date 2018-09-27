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
using CrystalDecisions.CrystalReports.Engine;

namespace Reports
{
    public partial class VoucherPrinting : Form
    {
        public static DateTime _paymentDate;
        public static bool _clientVoucher;
        public static bool _officevoucher;
         public static int _branchId;
        public VoucherPrinting()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            ShowReport();
        }

        private void ShowReport()
        {
            _branchId = GlobalVariableBO._branchId;
            _paymentDate = Convert.ToDateTime(dtPaymentDate.Value.ToShortDateString());
            _clientVoucher = rdoClinetVoucher.Checked;
            _officevoucher = rdoOfficevoucher.Checked;
            VoucherPrintingBAL voucherPrintingBal = new VoucherPrintingBAL();
            DataTable dtVoucherPrint = new DataTable();
            LoadCommonInfo CmmInfo = new LoadCommonInfo();
            if(_clientVoucher)
            {
                crClientVoucher crClientvoucher = new crClientVoucher();
                ClientVoucherPrintingViewer clientVoucherPrintingViewer = new ClientVoucherPrintingViewer();
                dtVoucherPrint = voucherPrintingBal.GetClientVoucher(_paymentDate);
                crClientvoucher.SetDataSource(dtVoucherPrint);
                ///// Load Company Name
                ((TextObject)crClientvoucher.ReportDefinition.Sections[3].ReportObjects["txtCompanyName"]).Text = CmmInfo.ShowCompanyName();

                ///// Load Branch Name
                ((TextObject)crClientvoucher.ReportDefinition.Sections[3].ReportObjects["txtBranchName"]).Text = CmmInfo.BranchDetails(_branchId);
                clientVoucherPrintingViewer.crvClientVoucherViewer.ReportSource = crClientvoucher;
                clientVoucherPrintingViewer.Show();
            }
            else if (_officevoucher)
            {
                crOfficeVoucher crOfficevoucher = new crOfficeVoucher();
                OfficeVoucherPrintingViewer officeVoucherPrintingViewer = new OfficeVoucherPrintingViewer();
                dtVoucherPrint = voucherPrintingBal.GetClientVoucher(_paymentDate);
                crOfficevoucher.SetDataSource(dtVoucherPrint);
                ///// Load Company Name
                ((TextObject)crOfficevoucher.ReportDefinition.Sections[3].ReportObjects["txtCompanyName"]).Text = CmmInfo.ShowCompanyName();

                ///// Load Branch Name
                ((TextObject)crOfficevoucher.ReportDefinition.Sections[3].ReportObjects["txtBranchName"]).Text = CmmInfo.BranchDetails(_branchId);
                officeVoucherPrintingViewer.crvOfficeVoucherViewer.ReportSource = crOfficevoucher;
                officeVoucherPrintingViewer.Show();
            }
            else
            {
                MessageBox.Show("Please Select the report category first.");
            }
        }

        private void VoucherPrinting_Load(object sender, EventArgs e)
        {
            dtPaymentDate.Value = DateTime.Today;
        }
    }
}

