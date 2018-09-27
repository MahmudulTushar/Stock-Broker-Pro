using System;
using System.Data;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;

namespace StockbrokerProNewArch
{
    public partial class frmCashBackProcess : Form
    {
        public frmCashBackProcess()
        {
            InitializeComponent();
        }
        private void LoadPlanSessionName()
        {
            LoadDDLBAL loadDDLBAL = new LoadDDLBAL();
            DataTable dtData = loadDDLBAL.GetSessionName();
            ddlSessionName.DataSource = dtData;
            ddlSessionName.ValueMember = "ID";
            ddlSessionName.DisplayMember = "Name";

            if (ddlSessionName.HasChildren)
                ddlSessionName.SelectedIndex = 0;
        }
        private void frmCashBackProcess_Load(object sender, EventArgs e)
        {
            try
            {
                LoadPlanSessionName();
            }
            catch
            {
                
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            CashBack_ProcessBAL objBAL=new CashBack_ProcessBAL();
            int _sessionId;
            DateTime processData;
            try
            {
                _sessionId = Convert.ToInt32(ddlSessionName.SelectedValue.ToString());
                processData = dtpProcessDate.Value;
                objBAL.ProcessCashBack(_sessionId, processData);
                LoadPlanSessionName();
                MessageBox.Show(@"Data processed Successfully");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
