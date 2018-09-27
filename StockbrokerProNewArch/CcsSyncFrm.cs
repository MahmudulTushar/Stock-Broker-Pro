using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using System.Data.SqlClient;

namespace StockbrokerProNewArch
{
    public partial class CcsSyncFrm : Form
    {
        public CcsSyncFrm()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            btnUpdate.Enabled = false;
            TransferData();
        }

        private void TransferData()
        {
            try
            {
                pbProcess.Value = 1;
                CCSBAL ccsbal = new CCSBAL();
                ccsbal.CCS_EmptyTables();
                //pbProcess.Value += 10;
                //ccsbal.CCS_Customers();
                pbProcess.Value += 15;
                ccsbal.CCS_Company();
                pbProcess.Value += 10;
                ccsbal.CCS_ShareDW();
                pbProcess.Value += 15;
                ccsbal.CCS_Payment();
                pbProcess.Value += 15;
                ccsbal.CCS_ShareBalance();
                pbProcess.Value += 15;
                ccsbal.CCS_ShareDetails();
                pbProcess.Value += 15;
                //ccsbal.CCS_CustomerAccount();
                //pbProcess.Value = 100;

                MessageBox.Show("Data Syncronization Completed Successfully", "Successful Message", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                btnUpdate.Enabled = true;
            }
            catch (Exception exception)
            {

                MessageBox.Show("Data Syncronization Failed. Because: " + exception.Message, "Error Message", MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }

        }

        //private void TransferData()
        //{
        //    pbProcess.Value = 1;
           
        //    SMSSyncBAL ssbal = new SMSSyncBAL();
        //    try
        //    {
        //        try
        //        {
        //            ssbal.Connect_WithoutTransaction_SBP();
        //            ssbal.Connect_WithoutTransaction_SMS();

        //            ssbal.CCS_EmptyTables_UITransApplied();
        //            pbProcess.Value += 0;
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new Exception(ex.Message);
        //        }
        //        finally
        //        {
        //            ssbal.CloseConnection_SBP();
        //            ssbal.CloseConnection_SMS();
        //        }

        //        try
        //        {
        //            ssbal.Connect_WithoutTransaction_SBP();
        //            ssbal.Connect_WithoutTransaction_SMS();
        //            //ShareDW
        //            SqlDataReader ShareDW = ssbal.Get_CCS_ShareDW_UITransApplied();
        //            ssbal.Insert_CCS_ShareDW_UITransApplied(ShareDW);
        //            pbProcess.Value += 20;

        //            //ssbal.Commit_SBP();
        //            //ssbal.Commit_SMS();
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new Exception(ex.Message);
        //        }
        //        finally
        //        {

        //            ssbal.CloseConnection_SBP();
        //            ssbal.CloseConnection_SMS();
        //        }
                
        //        try
        //        {

        //            ssbal.Connect_WithoutTransaction_SBP();
        //            ssbal.Connect_WithoutTransaction_SMS();
        //            //Customer ALL
        //            SqlDataReader Customer = ssbal.GetIPO_Customer_All_UITransApplied();
        //            ssbal.TruncateTable_SMSSyncExport_Customer_All_UITransApplied();
        //            ssbal.InsertTable_SMSSyncExport_Customer_All_UITransApplied(Customer);
        //            pbProcess.Value += 20;
        //        }
        //        catch(Exception ex)
        //        {
        //            throw new Exception(ex.Message);
        //        }
        //        finally
        //        {
        //            ssbal.CloseConnection_SBP();
        //            ssbal.CloseConnection_SMS();
        //        }

        //        try
        //        {
        //            ssbal.Connect_WithoutTransaction_SBP();
        //            ssbal.Connect_WithoutTransaction_SMS();
        //            //Trade Account
        //            ssbal.TruncateTable_SMSSyncExport_Customer_Trade_Account_UITransApplied();
        //            SqlDataReader TradeAccount = ssbal.GetIPO_Customer_Trade_Account_UITransApplied();
        //            ssbal.InsertTable_SMSSyncExport_Customer_Trade_Account_UITransApplied(TradeAccount);
        //            pbProcess.Value += 20;
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new Exception(ex.Message);
        //        }
        //        finally
        //        {
        //            ssbal.CloseConnection_SBP();
        //            ssbal.CloseConnection_SMS();
        //        }
        //        try
        //        {

        //            ssbal.Connect_WithoutTransaction_SBP();
        //            ssbal.Connect_WithoutTransaction_SMS();
        //            //Company
        //            SqlDataReader Company = ssbal.Get_CCS_Company_UITransApplied();
        //            ssbal.Insert_CCS_Company_UITransApplied(Company);
        //            pbProcess.Value += 15;

        //            //ssbal.Commit_SBP();
        //            //ssbal.Commit_SMS();
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new Exception(ex.Message);
        //        }
        //        finally
        //        {
        //            ssbal.CloseConnection_SBP();
        //            ssbal.CloseConnection_SMS();
        //        }

               
        //        try
        //        {
        //            ssbal.Connect_WithoutTransaction_SBP();
        //            ssbal.Connect_WithoutTransaction_SMS();
        //            //Payment
        //            SqlDataReader Payment = ssbal.Get_CCS_Payment_UITransApplied();
        //            ssbal.Insert_CCS_Payment_UITransApplied(Payment);
        //            pbProcess.Value += 15;
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new Exception(ex.Message);
        //        }
        //        finally
        //        {
        //            ssbal.CloseConnection_SBP();
        //            ssbal.CloseConnection_SMS();
        //        }
        //        try
        //        {
        //            ssbal.Connect_WithoutTransaction_SBP();
        //            ssbal.Connect_WithoutTransaction_SMS();
        //            //Share Balance
        //            SqlDataReader ShareBalance = ssbal.Get_CCS_ShareBalance_UITransApplied();
        //            ssbal.Insert_CCS_ShareBalance_UITransApplied(ShareBalance);
        //            pbProcess.Value += 5;
                    
        //            //ssbal.Commit_SBP();
        //            //ssbal.Commit_SMS();
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new Exception(ex.Message);
        //        }
        //        finally
        //        {
        //            ssbal.CloseConnection_SBP();
        //            ssbal.CloseConnection_SMS();
        //        }
        //        try
        //        {
        //            ssbal.Connect_WithoutTransaction_SBP();
        //            ssbal.Connect_WithoutTransaction_SMS();
        //            //Share Details
        //            SqlDataReader ShareDetails = ssbal.Get_CCS_ShareDetails_UITransApplied();
        //            ssbal.Insert_CCS_ShareDetails_UITransApplied(ShareDetails);
        //            pbProcess.Value = 100;
        //            //ssbal.Commit_SBP();
        //            //ssbal.Commit_SMS();
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new Exception(ex.Message);
        //        }
        //        finally
        //        {
        //            ssbal.CloseConnection_SBP();
        //            ssbal.CloseConnection_SMS();
        //        }

        //        MessageBox.Show("Data Syncronization Completed Successfully", "Successful Message", MessageBoxButtons.OK,
        //               MessageBoxIcon.Information);
        //        btnUpdate.Enabled = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Data Syncronization Failed. Because: " + ex.Message, "Error Message", MessageBoxButtons.OK,
        //                          MessageBoxIcon.Error);
        //    }

        //}

        private void CcsSyncFrm_Load(object sender, EventArgs e)
        {
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
