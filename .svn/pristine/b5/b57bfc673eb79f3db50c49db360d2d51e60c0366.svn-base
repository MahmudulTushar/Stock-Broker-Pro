using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using DSE_Reports.Reports;
using CrystalDecisions.CrystalReports.Engine;
 
namespace  DseReports
{
    public partial class frmList_Of_Landing_Clients_DSE_21_28_1 : Form
    {
        #region private field
        string Exchange_name = "";
        DateTime From_date;
        DateTime End_dae;
        #endregion

        #region Constructor
        public frmList_Of_Landing_Clients_DSE_21_28_1()
        {
            InitializeComponent();            
        }
        #endregion

        

        #region Close Form
        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region view report
        private void btnshow_Click(object sender, EventArgs e)
        {
            List_Of_Landing_Clients_DSE_21_28_1BAL objBAL = new List_Of_Landing_Clients_DSE_21_28_1BAL();
            DataTable dt = new DataTable();
            crList_Of_Landing_Clients_DSE_21_28_1 objRPT = new crList_Of_Landing_Clients_DSE_21_28_1();
            frmReportViewer rptviewer = new frmReportViewer();

            Exchange_name = ddlExchangeName.Text;
            From_date = dtpFromdate.Value;
            End_dae = dtpEndDate.Value;

            if (Exchange_name == "DSE"||Exchange_name=="All")
            {
                Exchange_name = "";                 
                dt = objBAL.Lnading_Clients_Dse(Exchange_name, From_date, End_dae);
                objRPT.SetDataSource(dt);
                rptviewer.crvReportViewer.ReportSource = objRPT;
                if (Exchange_name == "DSE")
                {
                    Exchange_name = "DSE";
                }
                else
                {
                    Exchange_name = "All";
                }
                ((TextObject)objRPT.Section2.ReportObjects["txtstartdate"]).Text = Convert.ToDateTime(From_date.ToString()).ToString("dd-MMMM-yyyy");
                ((TextObject)(objRPT.Section2.ReportObjects["txtEndDate"])).Text = Convert.ToDateTime(End_dae.ToString()).ToString("dd-MMMM-yyyy");
                ((TextObject)(objRPT.Section2.ReportObjects["txtExchangeName"])).Text = Exchange_name;
                rptviewer.Show();
            }
            else
            {
                string st_date = Convert.ToString(From_date);
                string en_date = Convert.ToString(End_dae);
                 objBAL.Lnading_Clients_Dse();
                objRPT.SetDataSource(dt);
                rptviewer.crvReportViewer.ReportSource = objRPT;
                ((TextObject)objRPT.Section2.ReportObjects["txtstartdate"]).Text = Convert.ToDateTime(From_date.ToString()).ToString("dd-MMMM-yyyy");
                ((TextObject)(objRPT.Section2.ReportObjects["txtEndDate"])).Text = Convert.ToDateTime(End_dae.ToString()).ToString("dd-MMMM-yyyy");
                ((TextObject)(objRPT.Section2.ReportObjects["txtExchangeName"])).Text = Exchange_name;
                rptviewer.Show();
                }
        }
        #endregion
    }
}
