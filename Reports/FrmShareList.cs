using System;
using System.Data;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;

namespace Reports
{
    public partial class FrmShareList : Form
    {
        public FrmShareList()
        {
            InitializeComponent();
        }

        private void FrmShareList_Load(object sender, EventArgs e)
        {
            LoadUserId();
        }

        void LoadUserId()
        {
            DataTable dataTable = new DataTable();

            ShareListBAL shareListBAL = new ShareListBAL();
            dataTable = shareListBAL.GetUserIdInfo();
            cmbUserId.DataSource = dataTable;

            cmbUserId.DisplayMember = "UserID";
            cmbUserId.ValueMember = "UserID";

            if (cmbUserId.HasChildren)
                cmbUserId.SelectedIndex = 0;
        }

        private void btnShareReport_Click(object sender, EventArgs e)
        {
            ShareListViewer reportForm = new ShareListViewer();
            reportForm.dtTo = dtpTo.Value;
            reportForm.dtFrom = dtpFrom.Value;

            if (cmbUserId.Text == "ALL")
            {
                reportForm.workStation = "";
            }
            else
            {
                reportForm.workStation = cmbUserId.Text;
            }

            reportForm.Show();

           
        }

        private void cmbUserId_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ShareListViewer rep = new ShareListViewer();
            rep.workStation = cmbUserId.Text;
        }

    }
}
