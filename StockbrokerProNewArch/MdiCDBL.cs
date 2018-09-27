using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using BusinessAccessLayer.BO;
using System.Threading;

namespace StockbrokerProNewArch
{
    public partial class MdiCDBL : Form
    {
        public static bool isProgressed;
        public MdiCDBL()
        {
            InitializeComponent();
        }

        private void newAccountInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewAccHolderInfo newAccHolderInfo = new NewAccHolderInfo();
            newAccHolderInfo.MdiParent = this;
            newAccHolderInfo.Show();
        }

        private void modifiedAccountHoldersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModifyAccHolderInfo modifyAccHolderInfo = new ModifyAccHolderInfo();
            modifyAccHolderInfo.MdiParent = this;
            modifyAccHolderInfo.Show();
        }

        private void additionalHoldersInformatioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdditionalHolderInfo additionalHolderInfo = new AdditionalHolderInfo();
            additionalHolderInfo.MdiParent = this;
            additionalHolderInfo.Show();
        }

        private void bOCloseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            BOCloseUpload boCloseUpload = new BOCloseUpload();
            boCloseUpload.MdiParent = this;
            boCloseUpload.Show();
        }

        private void iPOSharesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IPOShareUpload ipoShareUpload = new IPOShareUpload();
            ipoShareUpload.MdiParent = this;
            ipoShareUpload.Show();
        }

        private void bonusSharesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BonusUpload bonusUpload = new BonusUpload();
            bonusUpload.MdiParent = this;
            bonusUpload.Show();
        }

        private void rightShareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RightUpload bonusRightStock = new RightUpload();
            bonusRightStock.MdiParent = this;
            bonusRightStock.Show();
        }

        private void DemateShareToolStripMenuItemClick(object sender, EventArgs e)
        {
            DematUpload dematUpload = new DematUpload();
            dematUpload.MdiParent = this;
            dematUpload.Show();
        }

        private void StockSplitsToolStripMenuItemClick(object sender, EventArgs e)
        {
            StockSplitUpload stockSplitUpload = new StockSplitUpload();
            stockSplitUpload.MdiParent = this;
            stockSplitUpload.Show();
        }

        private void ProcessDataToolStripMenuItemClick(object sender, EventArgs e)
        {
            //if (MessageBox.Show("Confirmation Message", "Sure you want to process", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                //DatabaseInitialProcessing();
        }


        private void MdiCDBL_Load(object sender, EventArgs e)
        {
            ResetPrevillize();
            LoadPrevillize();
        }

        //private void LoadPrevillize()
        //{
        //    DataTable previllizeDataTable = new DataTable();
        //    PrevillizeManagementBAL previllizeManagementBal = new PrevillizeManagementBAL();
        //    previllizeDataTable = previllizeManagementBal.GetUserPrevillize();
        //    for (int i = 0; i < previllizeDataTable.Rows.Count; i++)
        //    {
        //        SetPrevillize(previllizeDataTable.Rows[i][0].ToString());
        //    }
        //}

        private void LoadPrevillize()
        {
            bool result = false;
            DataTable RoleWithUserprevillizeDataTable = new DataTable();
            DataTable RolewisePrevillizeDataTable = new DataTable();
            PrevillizeManagementBAL previllizeManagementBal = new PrevillizeManagementBAL();
            //previllizeDataTable = previllizeManagementBal.GetUserPrevillize();
            RoleWithUserprevillizeDataTable = previllizeManagementBal.GetAssignedPrevillize();
            if (RoleWithUserprevillizeDataTable.Rows.Count > 0)
            {
                for (int i = 0; i < RoleWithUserprevillizeDataTable.Rows.Count; i++)
                {
                    if (RoleWithUserprevillizeDataTable.Rows[i][0].ToString().ToLower() == GlobalVariableBO._userName.ToLower())
                    {
                        result = true;
                        break;
                    }
                }
                if (result)
                {
                    for (int i = 0; i < RoleWithUserprevillizeDataTable.Rows.Count; i++)
                    {
                        if (RoleWithUserprevillizeDataTable.Rows[i][0].ToString().ToLower() == GlobalVariableBO._userName.ToLower())
                        {
                            SetPrevillize(RoleWithUserprevillizeDataTable.Rows[i]["Previllize"].ToString());
                        }
                    }
                }

                //  DeactiveMenu();
            }
            else if (RoleWithUserprevillizeDataTable.Rows.Count == 0)
            {
                RolewisePrevillizeDataTable = previllizeManagementBal.GetRoleWisePrevillize();

                for (int i = 0; i < RolewisePrevillizeDataTable.Rows.Count; i++)
                {
                    SetPrevillize(RolewisePrevillizeDataTable.Rows[i]["Previllize"].ToString());
                }
                //   DeactiveMenu();
            }
        }

        private void SetPrevillize(string previllize)
        {
            switch (previllize)
            {
                case "New BO Upload":
                    newAccountInformationToolStripMenuItem.Visible = true;
                    break;
                case "Additional Holder Upload":
                    additionalHoldersInformatioToolStripMenuItem.Visible = true;
                    break;
                case "BO Modification Upload":
                    modifiedAccountHoldersToolStripMenuItem.Visible = true;
                    break;
                case "BO Close Upload":
                    bOCloseToolStripMenuItem1.Visible = true;
                    break;
                case "IPO Share Upload":
                    iPOSharesToolStripMenuItem.Visible = true;
                    break;
                case "Bonus Share Upload":
                    bonusSharesToolStripMenuItem.Visible = true;
                    break;
                case "Right Share Upload":
                    rightShareToolStripMenuItem.Visible = true;
                    break;
                case "Demat Share Upload":
                    demateShareToolStripMenuItem.Visible = true;
                    break;
                case "Stock Split Share Upload":
                    stockSplitsToolStripMenuItem.Visible = true;
                    break;
                case "Sattlement":
                    settlementFileGeToolStripMenuItem.Visible = true;
                    generatePayoutFileToolStripMenuItem1.Visible = true;
                    break;
                //case "Process Data":
                //processDataToolStripMenuItem.Visible = true;
                //break;
                case "CDBL Share Reconcile":
                    cDBLShareReconciliationToolStripMenuItem.Visible = true;
                    break;

                case "Process Uploaded Shares":
                    processUploadedSharesToolStripMenuItem.Visible = true;
                    break;

                case "DP 29 File Upload":
                    toolStripMenuItem2.Visible = true;
                    break;

                case "Lock In Shares":
                    lockInShareUploadtoolStripMenuItem.Visible = true;
                    break;

                case "Process Update Dash Board":
                    pToolStripMenuItem.Visible = true;
                    break;
                case "Generate Payin File - MSA Plus":
                    settlementToolStripMenuItem.Visible = true;
                    break;

                case "Generate Payout File - MSA Plus":
                    generatePayoutFileToolStripMenuItem.Visible = true;
                    break;

                case "Free LockIn Share":
                    freeLockInShareToolStripMenuItem.Visible = true;
                    break;
                case "Share Conversion Process":
                    shareConversionProcessToolStripMenuItem.Visible = true;
                    break;
                default:
                    break;
            }
        }

        private void ResetPrevillize()
        {
            newAccountInformationToolStripMenuItem.Visible = false;
            additionalHoldersInformatioToolStripMenuItem.Visible = false;
            modifiedAccountHoldersToolStripMenuItem.Visible = false;
            bOCloseToolStripMenuItem1.Visible = false;
            iPOSharesToolStripMenuItem.Visible = false;
            pToolStripMenuItem.Visible = false;
            generatePayoutFileToolStripMenuItem.Visible = false;
            bonusSharesToolStripMenuItem.Visible = false;
            rightShareToolStripMenuItem.Visible = false;
            demateShareToolStripMenuItem.Visible = false;
            stockSplitsToolStripMenuItem.Visible = false;
            processUploadedSharesToolStripMenuItem.Visible = false;
            settlementToolStripMenuItem.Visible = false;
            //processDataToolStripMenuItem.Visible = false;
            settlementFileGeToolStripMenuItem.Visible = false;
            generatePayoutFileToolStripMenuItem1.Visible = false;
            cDBLShareReconciliationToolStripMenuItem.Visible = false;
            toolStripMenuItem2.Visible = false;
            lockInShareUploadtoolStripMenuItem.Visible = false;
            freeLockInShareToolStripMenuItem.Visible = false;
            shareConversionProcessToolStripMenuItem.Visible = false;
        }

        private void cDBLShareReconciliationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CDBLShareReconcile cdblShareReconcile=new CDBLShareReconcile{MdiParent = this};
            cdblShareReconcile.Show();

        }

        private void settlementNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PayInImport payInImport = new PayInImport();
            payInImport.Show();
        }

        private void settlementPreviousToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sattlementOld sattlementOld=new sattlementOld();
            sattlementOld.Show();
        }

        private void settlementFileGeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SattleNewFile snf = new SattleNewFile();
            snf.IsOldTradeFile = true;
            snf.MdiParent = this;
            snf.Show();
        }

        private void generatePayoutFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PayoutForm payoutForm = new PayoutForm();
            payoutForm.Show();
        }

        private void settlementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SattleNewFile snf = new SattleNewFile();
            snf.IsOldTradeFile = false;
            snf.MdiParent = this;
            snf.Show();
            
            
            //try
            //{
            //    PayInTradeBAL tradeFileBal = new PayInTradeBAL();
            //    DataTable datatable = tradeFileBal.GeneratePayInData();
            //    if (datatable.Rows.Count > 1)
            //    {
            //        Write(datatable, GeneratePayinFileName());
            //    }
            //    else
            //    {
            //        MessageBox.Show("No Data for export.");
            //    }

            //}
            //catch (Exception exc)
            //{
            //    MessageBox.Show("Error occured." + exc.Message);
            //}
        }
        public void Write(DataTable dt, string sFileName)
        {
            StreamWriter sw = null;
            try
            {
                SaveFileDialog oDialog = new SaveFileDialog();
                oDialog.Filter = "Payin files | *.01";
                oDialog.FileName = sFileName;

                if (oDialog.ShowDialog() == DialogResult.OK)
                {
                    sFileName = oDialog.FileName;
                }

                if (sFileName != null)
                {
                    sw = new StreamWriter(sFileName, false);
                    foreach (DataRow row in dt.Rows)
                    {
                        sw.WriteLine(row[0].ToString());
                    }
                    sw.Close();

                    MessageBox.Show("Report saved with file: " + sFileName, "To Text", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    //oEXLApp.ActiveWorkbook.Close(false, Missing.Value, Missing.Value);
                    MessageBox.Show("Cannot export to Text...", "Can't export", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Invalid Operation : \n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GeneratePayinFileName()
        {
            return "01023500" + DateTime.Today.ToString("ddMMyyyy") + ".01";
        }

        private void generatePayoutFileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PayoutForm payoutForm = new PayoutForm();
            payoutForm.MdiParent = this;
            payoutForm.Show();
        }

        private void processUploadedSharesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                PayInTradeBAL tradeFileBal = new PayInTradeBAL();
                tradeFileBal.ProcessShareBalance();
                MessageBox.Show("Shares has been processed successfully", "Success Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error occured." + exc.Message);
            }
        } 

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
           // frm_Import_DP29 objDP29 = new frm_Import_DP29();
           //// frm_DP29 objDP29=new frm_DP29();
           // objDP29.MdiParent = this;
           // objDP29.Show();

            frm_DP29File_DataMatch fDD = new frm_DP29File_DataMatch();
            fDD.MdiParent = this;
            fDD.Show();





        }

        private void LockInShareUploadtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            LockInShareUpload frm = new LockInShareUpload();
            frm.MdiParent = this;
            frm.Show();
        }

        private void freeLockInShareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_LockInFree frm = new frm_LockInFree();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void pToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DashboardBAL bal = new DashboardBAL();
                Thread thrd = new Thread(WaitWindow_Thread);
                isProgressed = true;
                thrd.Start();
                bal.DashBoard_Details_UpdateByCurrentData();
                isProgressed = false;
                MessageBox.Show("Dash Board Updated Successfully");
            }
            catch (Exception ex)
            {
                isProgressed = false;
                MessageBox.Show(ex.Message);
            }
        }
        private void WaitWindow_Thread()
        {
            WaitWindow waitWindow = new WaitWindow();
            waitWindow.Show();
            while (isProgressed)
            {
                waitWindow.Refresh();
            }
            waitWindow.Close();
        }

        private void dscOtcMarketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_otc_marker frm = new frm_otc_marker();              
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void shareConversionProcessFullToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmShareConvertion frm = new FrmShareConvertion();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void shareConversionProcessDepositToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmShareConvertion_Deposit frm = new FrmShareConvertion_Deposit();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void shareConversionProcessWithdrawToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmShareConvertion_Withdraw frm = new FrmShareConvertion_Withdraw();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void shareConversionProcessDepositUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConversionUpdateTest frm = new frmConversionUpdateTest();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void shareConversionProcessWithdrawUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConversionWithdrawalUpdate frm = new frmConversionWithdrawalUpdate();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        } 

        
    }
}
