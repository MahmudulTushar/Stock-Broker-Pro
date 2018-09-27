using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using BusinessAccessLayer.Constants;

namespace Reports
{
    public partial class frmIPOSubmissionOfIPOcollectionFile_Hardcopy_And_Softcopy : Form
    {
        IPOProcessBAL bal = new IPOProcessBAL();
        IPOReportBAL R_Bal = new IPOReportBAL();
        DataTable dt = new DataTable();
        string name = "";
        int SessionID = 0;

        public frmIPOSubmissionOfIPOcollectionFile_Hardcopy_And_Softcopy()
        {
            InitializeComponent();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadComboData()
        {
            
            dt = bal.GetCompanyShortCodeAndSessionID();
            cmbShortCodeAndsessionID.DataSource = dt;
            cmbShortCodeAndsessionID.DisplayMember = "code";
            cmbShortCodeAndsessionID.ValueMember = "ID";
            cmbShortCodeAndsessionID.SelectedIndex = 0;
            cmbrbNrb.SelectedIndex = 0;
        }

        private void btnShowReport_Click(object sender, EventArgs e)
        {
            if (cmbrbNrb.Text == "RB")
            {
                name = txtName.Text;
                SessionID =Convert.ToInt32(cmbShortCodeAndsessionID.SelectedValue);
                dt = R_Bal.GetIPOSubmissionOfIPOcollectionFile_Hardcopy_And_Softcopy(SessionID, name,cmbrbNrb.Text,"");
                crIPOSubmissionOfIPOcollectionFile_Hardcopy_And_Softcopy crobj = new crIPOSubmissionOfIPOcollectionFile_Hardcopy_And_Softcopy();
                frmReportViewer view = new frmReportViewer();
                crobj.SetDataSource(dt);
                view.crvReportViewer.ReportSource = crobj;
                view.Show();
            }
            else if (cmbrbNrb.Text == "NRB")
            {
                name = txtName.Text;
                SessionID =Convert.ToInt32(cmbShortCodeAndsessionID.SelectedValue);
                dt = R_Bal.GetIPOSubmissionOfIPOcollectionFile_Hardcopy_And_Softcopy(SessionID, name, cmbrbNrb.Text,"");
                crIPONRBReportToDesc crobj = new crIPONRBReportToDesc();
                frmReportViewer view = new frmReportViewer();
                crobj.SetDataSource(dt);
                view.crvReportViewer.ReportSource = crobj;
                view.Show();
            }
        }

        private void frmIPOSubmissionOfIPOcollectionFile_Hardcopy_And_Softcopy_Load(object sender, EventArgs e)
        {
            LoadComboData();
        }

        private void btnAuthorized_Click(object sender, EventArgs e)
        {
            SessionID = Convert.ToInt32(cmbShortCodeAndsessionID.SelectedValue);
            dt = R_Bal.GetIPOSubmissionOfIPOcollectionFile_Hardcopy_And_Softcopy(SessionID, name, cmbrbNrb.Text, btnAuthorized.Text);
            cr_IPOAuthorizePersonDeclaration crobj = new cr_IPOAuthorizePersonDeclaration();
            frmReportViewer view = new frmReportViewer();
            crobj.SetDataSource(dt);
            view.crvReportViewer.ReportSource = crobj;
            view.Show();
        }
    }
}
