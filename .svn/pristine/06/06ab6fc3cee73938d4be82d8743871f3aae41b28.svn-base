using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using BusinessAccessLayer.BO;
using Reports;
using BusinessAccessLayer.BAL;
using DseReports;
using System.Deployment.Application;

namespace StockbrokerProNewArch
{
    public partial class ParentForm : Form
    {
        private AccountInformation accountInformation;
        private SettingsModule settingsModule;
        private MdiDSE mdiDse;
        private MdiCDBL mdiCdbl;
        private MainReport mainReport;
        private AccDashboard accDashboard;
        private AccDashboardLR accDashboardLR;
        private ImageMainForm imageMainForm;
        private MDIMargin marginAccountMainForm;
        private MDIExpense mdiExpense;

        public ParentForm()
        {
            InitializeComponent();
        }

        private void ParentFormPaint(object sender, PaintEventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
                return;

            var pen = new Pen(Color.SteelBlue, 2);
            var rect = new Rectangle(this.ClientRectangle.X, this.ClientRectangle.Y, this.ClientRectangle.Width, this.ClientRectangle.Height);
            var brBackground = new LinearGradientBrush(rect, Color.FromArgb(70, 108, 155), Color.FromArgb(236, 233, 216), LinearGradientMode.Vertical);
            e.Graphics.FillRectangle(brBackground, rect);
            e.Graphics.DrawRectangle(pen, rect);
        }

        private void ModulePanelPaint(object sender, PaintEventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
                return;

            var pen = new Pen(Color.SteelBlue, 2);
            var rect = new Rectangle(modulePanel.ClientRectangle.X, modulePanel.ClientRectangle.Y, modulePanel.ClientRectangle.Width, modulePanel.ClientRectangle.Height);
            var brBackground = new LinearGradientBrush(rect, Color.FromArgb(86, 100, 116), Color.FromArgb(70, 108, 155), LinearGradientMode.Vertical);
            e.Graphics.FillRectangle(brBackground, rect);
            e.Graphics.DrawRectangle(pen, rect);
        }
       
        private void MainMenubarPaint(object sender, PaintEventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
                return;

            var pen = new Pen(Color.SteelBlue, 2);
            var rect = new Rectangle(mainMenubar.ClientRectangle.X, mainMenubar.ClientRectangle.Y, mainMenubar.ClientRectangle.Width, mainMenubar.ClientRectangle.Height);
            var brBackground = new LinearGradientBrush(rect, Color.FromArgb(170, 208, 255), Color.FromArgb(221, 246, 255), LinearGradientMode.Horizontal);
            e.Graphics.FillRectangle(brBackground, rect);
            e.Graphics.DrawRectangle(pen, rect);
        }

        private void MainStatusbarPaint(object sender, PaintEventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
                return;

            var pen = new Pen(Color.SteelBlue, 2);
            var rect = new Rectangle(MainStatusbar.ClientRectangle.X, MainStatusbar.ClientRectangle.Y, MainStatusbar.ClientRectangle.Width, MainStatusbar.ClientRectangle.Height);
            var brBackground = new LinearGradientBrush(rect, Color.FromArgb(170, 208, 255), Color.FromArgb(221, 246, 255), LinearGradientMode.Horizontal);
            e.Graphics.FillRectangle(brBackground, rect);
            e.Graphics.DrawRectangle(pen, rect);
        }
        private void BackToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (accountInformation == null || accountInformation.IsDisposed)
            {
                accountInformation = new AccountInformation();
                accountInformation.Show();
            }
            else
            {
                if (accountInformation.WindowState == FormWindowState.Minimized)
                    accountInformation.WindowState = FormWindowState.Maximized;
                accountInformation.Activate();
            }
        }

        private void settingsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (settingsModule == null || settingsModule.IsDisposed)
            {
                settingsModule = new SettingsModule();
                settingsModule.Show();
            }
            else
            {
                if (settingsModule.WindowState == FormWindowState.Minimized)
                    settingsModule.WindowState = FormWindowState.Maximized;
                settingsModule.Activate();
            }
        }

        private void tESAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mdiDse == null || mdiDse.IsDisposed)
            {
                mdiDse = new MdiDSE();
                mdiDse.Show();
            }
            else
            {
                if (mdiDse.WindowState == FormWindowState.Minimized)
                    mdiDse.WindowState = FormWindowState.Maximized;
                mdiDse.Activate();
            }
        }

        private void cDBLManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mdiCdbl == null || mdiCdbl.IsDisposed)
            {
                mdiCdbl = new MdiCDBL();
                mdiCdbl.Show();
            }
            else
            {
                if (mdiCdbl.WindowState == FormWindowState.Minimized)
                    mdiCdbl.WindowState = FormWindowState.Maximized;
                mdiCdbl.Activate();
            }
        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mainReport == null || mainReport.IsDisposed)
            {
                mainReport = new MainReport();
                mainReport.Show();
            }
            else
            {
                if (mainReport.WindowState == FormWindowState.Minimized)
                    mainReport.WindowState = FormWindowState.Maximized;
                mainReport.Activate();
            }
        }

        private void ParentForm_Load(object sender, EventArgs e)
        {
            ResetPrevillize();
            LoadPrevillize();
            lbUserName.Text = GlobalVariableBO._userName.ToUpper();
            slblBranch.Text = GlobalVariableBO._branchName.ToUpper();
            lbLoginDateTime.Text = DateTime.Now.ToString("dd-MM-yyyy  hh:mm:ss tt");
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                lbl_PublishedVersion.Text = string.Format("v{0}", ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString(4));
            }
        }

        private void LoadPrevillize()
        {
            DataTable previllizeDataTable = new DataTable();
            PrevillizeManagementBAL previllizeManagementBal = new PrevillizeManagementBAL();
            previllizeDataTable = previllizeManagementBal.GetUserPrevillize();
            for (int i = 0; i < previllizeDataTable.Rows.Count; i++)
            {
                SetPrevillize(previllizeDataTable.Rows[i][0].ToString());
            }

        }

        private void SetPrevillize(string previllize)
        {
            switch (previllize)
            {
                case "Image Management":
                    imagesAndDocumentsToolStripMenuItem.Visible = true;
                    btnImagesDoc.Enabled = true;
                    break;
                case "HR Management":
                    button2.Visible = true;                   
                    break;
                default:
                    break;
            }
        }

        private void ResetPrevillize()
        {
            btnImagesDoc.Enabled = false;
            imagesAndDocumentsToolStripMenuItem.Visible = false;
            button2.Visible = false;

        }

        private void ParentFormFormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Sure You Want To Logout ?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.No)
                e.Cancel = true;
            else
            {
                try
                {
                    LoginManagementBAL loginManagementBal = new LoginManagementBAL();
                    loginManagementBal.UpdateLoggedinStatus(GlobalVariableBO._userName, 0);
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Fail to update Loggedin Status. Because: " + exception.Message);
                }
            }
        }

        private void imagesAndDocumentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (imageMainForm == null || imageMainForm.IsDisposed)
            {
                imageMainForm = new ImageMainForm();
                imageMainForm.Show();
            }
            else
            {
                if (imageMainForm.WindowState == FormWindowState.Minimized)
                    imageMainForm.WindowState = FormWindowState.Maximized;
                imageMainForm.Activate();
            }
        }

        private void marginAccountManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (marginAccountMainForm == null || marginAccountMainForm.IsDisposed)
            {
                marginAccountMainForm = new MDIMargin();
                marginAccountMainForm.Show();
            }
            else
            {
                if (marginAccountMainForm.WindowState == FormWindowState.Minimized)
                    marginAccountMainForm.WindowState = FormWindowState.Maximized;
                marginAccountMainForm.Activate();
            }

        }

        private void deshboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OthersMdi othersMdi = new OthersMdi();
            othersMdi.Show();
        }

        private void passwordChangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePasswordForm changePasswordForm = new ChangePasswordForm();
            changePasswordForm.Show();
        }

        private void lockWindowtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Sure you want to lock screen?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.No)
                return;
            LockWindow lockWindow = new LockWindow();
            lockWindow.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            if (mdiExpense == null || mdiExpense.IsDisposed)
            {
                mdiExpense = new MDIExpense();
                mdiExpense.Show();
            }
            else
            {
                if (mdiExpense.WindowState == FormWindowState.Minimized)
                    mdiExpense.WindowState = FormWindowState.Maximized;
                mdiExpense.Activate();
            }
        }

        private void deshboardToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Screen Srn = Screen.PrimaryScreen;
            if (Srn.Bounds.Width < 900)
            {
                if (accDashboardLR == null || accDashboardLR.IsDisposed)
                {
                    accDashboardLR = new AccDashboardLR();
                    accDashboardLR.Show();
                }
                else
                {
                    if (accDashboardLR.WindowState == FormWindowState.Minimized)
                        accDashboardLR.WindowState = FormWindowState.Maximized;
                    accDashboardLR.Activate();
                }
            }
            else
            {

                if (accDashboard == null || accDashboard.IsDisposed)
                {
                    accDashboard = new AccDashboard();
                    accDashboard.Show();
                }
                else
                {
                    if (accDashboard.WindowState == FormWindowState.Minimized)
                        accDashboard.WindowState = FormWindowState.Maximized;
                    accDashboard.Activate();
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void managementViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManagementView managementView = new ManagementView();
            managementView.Show();
        }

        private void branchwiseTreeReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BranchReport branchReport = new BranchReport();
            branchReport.Show();
        }

        private void customerDashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Screen Srn = Screen.PrimaryScreen;
            if (Srn.Bounds.Width < 900)
            {
                if (accDashboardLR == null || accDashboardLR.IsDisposed)
                {
                    accDashboardLR = new AccDashboardLR();
                    accDashboardLR.Show();
                }
                else
                {
                    if (accDashboardLR.WindowState == FormWindowState.Minimized)
                        accDashboardLR.WindowState = FormWindowState.Maximized;
                    accDashboardLR.Activate();
                }
            }
            else
            {

                if (accDashboard == null || accDashboard.IsDisposed)
                {
                    accDashboard = new AccDashboard();
                    accDashboard.Show();
                }
                else
                {
                    if (accDashboard.WindowState == FormWindowState.Minimized)
                        accDashboard.WindowState = FormWindowState.Maximized;
                    accDashboard.Activate();
                }
            }
        }

        private void priceDashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LatestSharePriceNew latestSharePriceNew = new LatestSharePriceNew();
            latestSharePriceNew.Show();
        }

        private void searchCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchCust searchCust = new SearchCust();
            searchCust.Show();
        }

        private void btn_IPOProcess_Click(object sender, EventArgs e)
        {
            MDIIPOProcess frm = new MDIIPOProcess();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MdiDseReports frm = new MdiDseReports();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HRModule frm = new HRModule();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void marginNonMargineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Market_Value frm = new frm_Market_Value();
            //frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }
    }
}
