using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using System.Threading;

namespace StockbrokerProNewArch.Classes
{
    public class WebDataExportCls
    {
        public void GenerateFile(string foldername)
        {
            try
            {
                ProcessWebData();
                GenerateCompanyProfile(foldername);
                GenerateCustomerProfile(foldername);
                GeneratePaymentHistory(foldername);
                GenerateShareBalance(foldername);
                GenerateShareBalanceDetails(foldername);
                GenerateShareDW(foldername);
                GenerateTransactionDetails(foldername);
                GenerateTradeDetails(foldername);
                GenerateMoneyBalance(foldername);
                MessageBox.Show("All data Successfully Export.", "Export Success.");
            }
            catch (Exception exp)
            {
                MessageBox.Show("Error Occured on Export data." + exp.Message);

            }
        }

        public void GenerateFileForWeb_2014(string foldername, string Change)
        {
            try
            {
                Generate_BrokerInfo_ForWeb_2014(foldername);
                Generate_CompanyProfile_ForWeb_2014(foldername);
                Generate_CustomerProfile_ForWeb_2014(foldername);
                Generate_DseTradingDetail_ForWeb_2014(foldername);
                Generate_MoneyWithdrawalRequest_ForWeb_2014(foldername);
                Generate_MoneyBalance_ForWeb_2014(foldername);
                ////Generate_PaymentHistory_ForWeb_2014(foldername);
                Generate_ShareBalance_ForWeb_2014(foldername);
                Generate_ShareBalanceDetail_ForWeb_2014(foldername);
                ////Generate_ShareDw_ForWeb_2014(foldername);

                if (Change.ToUpper().Trim() == (("New").ToUpper().Trim()))
                {
                    Generate_PaymentHistory_ForWeb_2014_Update(foldername);
                }
                else
                {
                    Generate_PaymentHistory_ForWeb_2014(foldername);
                }
                if (Change.ToUpper().Trim() == (("NEW").ToUpper().Trim()))
                {
                    Generate_ShareDw_ForWeb_2014_Update(foldername);
                }
                else
                {
                    Generate_ShareDw_ForWeb_2014(foldername);
                }
                if (Change.ToUpper().Trim() == (("NEW").ToUpper().Trim()))
                {
                    Generate_TransectionDetail_ForWeb_2014_Update(foldername);
                }
                else
                {
                    Generate_TransectionDetail_ForWeb_2014(foldername);
                } 
                //Generate_TransectionDetail_ForWeb_2014(foldername);
                Generate_Contact_Us_ForWeb_2014(foldername);
                OthersMdi.isProgressed = false;
                MessageBox.Show("All data Successfully Export.", "Export Success.");                
            }
            catch (Exception exp)
            {
                OthersMdi.isProgressed = false;
                MessageBox.Show("Error Occured on Export data." + exp.Message);

            }
        }
       
        private void Generate_BrokerInfo_ForWeb_2014(string FileName)
        {
            WebDataExportBAL webDataExportBal = new WebDataExportBAL();
            DataTable dtMoneyBalance = webDataExportBal.GetBrokerInfo_ForWeb_2014();
            FileName = FileName + "\\broker_Info.txt";

            if (dtMoneyBalance.Rows.Count > 0)
            {
                WriteToTxt(dtMoneyBalance, FileName);
            }
        }

        private void Generate_CompanyProfile_ForWeb_2014(string FileName)
        {
            WebDataExportBAL webDataExportBal = new WebDataExportBAL();
            DataTable dtMoneyBalance = webDataExportBal.GetCompanyProfile_ForWeb_2014();
            FileName = FileName + "\\company_profile.txt";

            if (dtMoneyBalance.Rows.Count > 0)
            {
                WriteToTxt(dtMoneyBalance, FileName);
            }
        }
        
        private void Generate_CustomerProfile_ForWeb_2014(string FileName)//3
        {
            WebDataExportBAL webDataExportBal = new WebDataExportBAL();
            DataTable dtMoneyBalance = webDataExportBal.GetCustomerProfile_ForWeb_2014();
            FileName = FileName + "\\customer_profile.txt";

            if (dtMoneyBalance.Rows.Count > 0)
            {
                WriteToTxt(dtMoneyBalance, FileName);
            }
        }

        private void Generate_DseTradingDetail_ForWeb_2014(string FileName)//4
        {
            WebDataExportBAL webDataExportBal = new WebDataExportBAL();
            DataTable dtMoneyBalance = webDataExportBal.GetDseTradingDetail_ForWeb_2014();
            FileName = FileName + "\\dse_trading_detail.txt";

            if (dtMoneyBalance.Rows.Count > 0)
            {
                WriteToTxt(dtMoneyBalance, FileName);
            }
        }

        private void Generate_MoneyWithdrawalRequest_ForWeb_2014(string FileName)//5
        {
            WebDataExportBAL webDataExportBal = new WebDataExportBAL();
            try
            {
                webDataExportBal.CreateWeb2014Export_Temp();
                DataTable dt = webDataExportBal.GetPendingMoneyWithdrawReq_FromWeb();
                webDataExportBal.InsertIntoWeb2014_DataExportTemp(dt);
                DataTable dtMoneyBalance = webDataExportBal.GetMoneyWithdrawalRequest_ForWeb_2014();
                FileName = FileName + "\\money_withdrawal_request.txt";

                if (dtMoneyBalance.Rows.Count > 0)
                {
                    WriteToTxt(dtMoneyBalance, FileName);
                }
                webDataExportBal.DropWeb2014Export_Temp();
            }
            catch (Exception ex)
            {
                webDataExportBal.DropWeb2014Export_Temp();
                throw ex;
            }
        }

        private void Generate_MoneyBalance_ForWeb_2014(string FileName)//6
        {
            WebDataExportBAL webDataExportBal = new WebDataExportBAL();
            DataTable dtMoneyBalance = webDataExportBal.GetMoneyBalance_ForWeb_2014();
            FileName = FileName + "\\money_balance.txt";

            if (dtMoneyBalance.Rows.Count > 0)
            {
                WriteToTxt(dtMoneyBalance, FileName);
            }
        }

        private void Generate_PaymentHistory_ForWeb_2014(string FileName)//7
        {
            WebDataExportBAL webDataExportBal = new WebDataExportBAL();
            DataTable dtMoneyBalance = webDataExportBal.GetPaymentHistory_ForWeb_2014();
            FileName = FileName + "\\payment_history.txt";

            if (dtMoneyBalance.Rows.Count > 0)
            {
                WriteToTxt(dtMoneyBalance, FileName);
            }
        }


        private void Generate_PaymentHistory_ForWeb_2014_Update(string FileName)//7
        {
            WebDataExportBAL webDataExportBal = new WebDataExportBAL();
            DataTable dtMoneyBalance = webDataExportBal.GetPaymentHistory_ForWeb_2014_Update();
            FileName = FileName + "\\payment_history.txt";

            if (dtMoneyBalance.Rows.Count > 0)
            {
                WriteToTxt(dtMoneyBalance, FileName);
            }
        }





        private void Generate_ShareDw_ForWeb_2014_Update(string FileName)//10
        {
            WebDataExportBAL webDataExportBal = new WebDataExportBAL();
            DataTable dtMoneyBalance = webDataExportBal.GetShareDw_ForWeb_2014_Update();
            FileName = FileName + "\\share_dw.txt";

            if (dtMoneyBalance.Rows.Count > 0)
            {
                WriteToTxt(dtMoneyBalance, FileName);
            }
        }










        private void Generate_TransectionDetail_ForWeb_2014_Update(string FileName)//11
        {
            WebDataExportBAL webDataExportBal = new WebDataExportBAL();
            DataTable dtMoneyBalance = webDataExportBal.GetTransectionDetail_ForWeb_2014_Update();
            FileName = FileName + "\\transection_detail.txt";

            if (dtMoneyBalance.Rows.Count > 0)
            {
                WriteToTxt(dtMoneyBalance, FileName);
            }
        }


        private void Generate_ShareBalance_ForWeb_2014(string FileName)//8
        {
            WebDataExportBAL webDataExportBal = new WebDataExportBAL();
            DataTable dtMoneyBalance = webDataExportBal.GetShareBalance_ForWeb_2014();
            FileName = FileName + "\\share_balance.txt";

            if (dtMoneyBalance.Rows.Count > 0)
            {
                WriteToTxt(dtMoneyBalance, FileName);
            }
        }

        private void Generate_ShareBalanceDetail_ForWeb_2014(string FileName)//9
        {
            WebDataExportBAL webDataExportBal = new WebDataExportBAL();
            DataTable dtMoneyBalance = webDataExportBal.GetShareBalanceDetail_ForWeb_2014();
            FileName = FileName + "\\share_balance_detail.txt";

            if (dtMoneyBalance.Rows.Count > 0)
            {
                WriteToTxt(dtMoneyBalance, FileName);
            }
        }

        private void Generate_ShareDw_ForWeb_2014(string FileName)//10
        {
            WebDataExportBAL webDataExportBal = new WebDataExportBAL();
            DataTable dtMoneyBalance = webDataExportBal.GetShareDw_ForWeb_2014();
            FileName = FileName + "\\share_dw.txt";

            if (dtMoneyBalance.Rows.Count > 0)
            {
                WriteToTxt(dtMoneyBalance, FileName);
            }
        }

        private void Generate_TransectionDetail_ForWeb_2014(string FileName)//11
        {
            WebDataExportBAL webDataExportBal = new WebDataExportBAL();
            DataTable dtMoneyBalance = webDataExportBal.GetTransectionDetail_ForWeb_2014();
            FileName = FileName + "\\transection_detail.txt";

            if (dtMoneyBalance.Rows.Count > 0)
            {
                WriteToTxt(dtMoneyBalance, FileName);
            }
        }
        private void Generate_Contact_Us_ForWeb_2014(string FileName)//12
        {
            
            WebDataExportBAL webDataExportBal = new WebDataExportBAL();
            try
            {
                webDataExportBal.CreateWeb2014Export_Temp();
                DataTable dt = webDataExportBal.GetOpenUserQueryReq_FromWeb();
                webDataExportBal.InsertIntoWeb2014_DataExportTemp(dt);
                DataTable dtMoneyBalance = webDataExportBal.GetContact_Us_ForWeb_2014();
                FileName = FileName + "\\contact_us.txt";

                if (dtMoneyBalance.Rows.Count > 0)
                {
                    WriteToTxt(dtMoneyBalance, FileName);
                }
                webDataExportBal.DropWeb2014Export_Temp();
            }
            catch (Exception ex)
            {
                webDataExportBal.DropWeb2014Export_Temp();
                throw ex;
            }
            
        }

        private void WriteToTxt(DataTable dtMoneyBalance, string FileName)
        {
            int i = 0;
            string sFileName = FileName; 
            StreamWriter sw = null;
            try
            {
                if (sFileName != null)
                {
                    sw = new StreamWriter(sFileName, false);
                    foreach (DataRow row in dtMoneyBalance.Rows)
                    {
                        object[] array = row.ItemArray;

                        for (i = 0; i < array.Length - 1; i++)
                        {
                            sw.Write(array[i].ToString() + "~");
                        }
                        sw.WriteLine(array[i].ToString());
                    }
                    sw.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid Operation : \n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void ProcessWebData()
        {
            try
            {
                WebDataExportBAL objWebdataExportBAL = new WebDataExportBAL();
                objWebdataExportBAL.ProcessWebData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        
        }

        private void GenerateMoneyBalance(string foldername)
        {
            WebDataExportBAL webDataExportBal = new WebDataExportBAL();
            DataTable dtMoneyBalance = webDataExportBal.GetMoneyBalance();
            if (dtMoneyBalance.Rows.Count > 0)
            {
                WriteMoneyBalance(dtMoneyBalance,foldername);
            }
        }

        private void WriteMoneyBalance(DataTable dtMoneyBalance, string foldername)
        {
            int i = 0;
            string sFileName = foldername+"\\web_money_balance.txt";
            StreamWriter sw = null;
            try
            {
                if (sFileName != null)
                {
                    sw = new StreamWriter(sFileName, false);
                    foreach (DataRow row in dtMoneyBalance.Rows)
                    {
                        object[] array = row.ItemArray;

                        for (i = 0; i < array.Length - 1; i++)
                        {
                            sw.Write(array[i].ToString() + "~");
                        }
                        sw.WriteLine(array[i].ToString());
                    }
                    sw.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid Operation : \n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void GenerateTradeDetails(string foldername)
        {
            WebDataExportBAL webDataExportBal = new WebDataExportBAL();
            DataTable dtTradeDetails = webDataExportBal.GetTradeDetails();
            if (dtTradeDetails.Rows.Count > 0)
            {
                WriteTradeDetails(dtTradeDetails,foldername);
            }

        }

        private void WriteTradeDetails(DataTable dtTradeDetails, string foldername)
        {
            int i = 0;
            string sFileName = foldername+"\\web_trade_detail.txt";
            StreamWriter sw = null;
            try
            {if (sFileName != null)
                {
                    sw = new StreamWriter(sFileName, false);
                    foreach (DataRow row in dtTradeDetails.Rows)
                    {
                        object[] array = row.ItemArray;

                        for (i = 0; i < array.Length - 1; i++)
                        {
                            sw.Write(array[i].ToString() + "~");
                        }
                        sw.WriteLine(array[i].ToString());
                    }
                    sw.Close();
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid Operation : \n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void GenerateTransactionDetails(string foldername)
        {
            WebDataExportBAL webDataExportBal = new WebDataExportBAL();
            DataTable dtTransactionDetails = webDataExportBal.GetTransactionDetails();
            if (dtTransactionDetails.Rows.Count > 0)
            {
                WriteTransactionDetails(dtTransactionDetails,foldername);
            }
        }

        private void WriteTransactionDetails(DataTable dtTransactionDetails, string foldername)
        {
            int i = 0;
            string sFileName = foldername + "\\web_transection_detail.txt";
            StreamWriter sw = null;
            try
            {
                if (sFileName != null)
                {
                    sw = new StreamWriter(sFileName, false);
                    foreach (DataRow row in dtTransactionDetails.Rows)
                    {
                        object[] array = row.ItemArray;

                        for (i = 0; i < array.Length - 1; i++)
                        {
                            sw.Write(array[i].ToString() + "~");
                        }
                        sw.WriteLine(array[i].ToString());
                    }
                    sw.Close();
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid Operation : \n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void GenerateShareDW(string foldername)
        {
            WebDataExportBAL webDataExportBal = new WebDataExportBAL();
            DataTable dtshareDW = webDataExportBal.GetShareDW();
            if (dtshareDW.Rows.Count > 0)
            {
                WriteShareDW(dtshareDW,foldername);
            }
        }

        private void WriteShareDW(DataTable dtshareDw, string foldername)
        {
            int i = 0;
            string sFileName = foldername + "\\web_share_dw.txt";
            StreamWriter sw = null;
            try
            {
                if (sFileName != null)
                {
                    sw = new StreamWriter(sFileName, false);
                    foreach (DataRow row in dtshareDw.Rows)
                    {
                        object[] array = row.ItemArray;

                        for (i = 0; i < array.Length - 1; i++)
                        {
                            sw.Write(array[i].ToString() + "~");
                        }
                        sw.WriteLine(array[i].ToString());
                    }
                    sw.Close();
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid Operation : \n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void GenerateShareBalanceDetails(string foldername)
        {
            WebDataExportBAL webDataExportBal = new WebDataExportBAL();
            DataTable dtshareBalanceDetails = webDataExportBal.GetShareBalanceDetails();
            if (dtshareBalanceDetails.Rows.Count > 0)
            {
                WriteShareBalanceDetails(dtshareBalanceDetails,foldername);
            }

        }

        private void WriteShareBalanceDetails(DataTable dtshareBalanceDetails, string foldername)
        {
            int i = 0;
            string sFileName = foldername + "\\web_share_balance_detail.txt";
            StreamWriter sw = null;
            try
            {
                if (sFileName != null)
                {
                    sw = new StreamWriter(sFileName, false);
                    foreach (DataRow row in dtshareBalanceDetails.Rows)
                    {
                        object[] array = row.ItemArray;

                        for (i = 0; i < array.Length - 1; i++)
                        {
                            sw.Write(array[i].ToString() + "~");
                        }
                        sw.WriteLine(array[i].ToString());
                    }
                    sw.Close();
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid Operation : \n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void GenerateShareBalance(string foldername)
        {
            WebDataExportBAL webDataExportBal = new WebDataExportBAL();
            DataTable dtshareBalance = webDataExportBal.GetShareBalance();
            if (dtshareBalance.Rows.Count > 0)
            {
                WriteShareBalance(dtshareBalance,foldername);
            }

        }

        private void WriteShareBalance(DataTable dtshareBalance, string foldername)
        {
            int i = 0;
            string sFileName = foldername + "\\web_share_balance.txt";
            StreamWriter sw = null;
            try
            {
               
                if (sFileName != null)
                {
                    sw = new StreamWriter(sFileName, false);
                    foreach (DataRow row in dtshareBalance.Rows)
                    {
                        object[] array = row.ItemArray;

                        for (i = 0; i < array.Length - 1; i++)
                        {
                            sw.Write(array[i].ToString() + "~");
                        }
                        sw.WriteLine(array[i].ToString());
                    }
                    sw.Close();
                   

                }
               
            }

            catch (Exception ex)
            {
                MessageBox.Show("Invalid Operation : \n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void GeneratePaymentHistory(string foldername)
        {
            WebDataExportBAL webDataExportBal = new WebDataExportBAL();
            DataTable dtpayment = webDataExportBal.GetPaymentHistory();
            if (dtpayment.Rows.Count > 0)
            {
                WritePaymentHistory(dtpayment,foldername);
            }
        }

        private void WritePaymentHistory(DataTable dtpayment, string foldername)
        {
            int i = 0;
            string sFileName = foldername + "\\web_payment_history.txt";
            StreamWriter sw = null;
            try
            {
               
                if (sFileName != null)
                {
                    sw = new StreamWriter(sFileName, false);
                    foreach (DataRow row in dtpayment.Rows)
                    {
                        object[] array = row.ItemArray;

                        for (i = 0; i < array.Length - 1; i++)
                        {
                            sw.Write(array[i].ToString() + "~");
                        }
                        sw.WriteLine(array[i].ToString());
                    }
                    sw.Close();
                   

                }
              
            }

            catch (Exception ex)
            {
                MessageBox.Show("Invalid Operation : \n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenerateCustomerProfile(string foldername)
        {
            WebDataExportBAL webDataExportBal = new WebDataExportBAL();
            DataTable dtCustomer = webDataExportBal.GetCustomerProfile();
            if (dtCustomer.Rows.Count > 0)
            {
                WriteCustomerProfile(dtCustomer,foldername);
            }
        }

        private void WriteCustomerProfile(DataTable dtCustomer, string foldername)
        {
            int i = 0;
            string sFileName = foldername + "\\web_customer_profile.txt";
            StreamWriter sw = null;
            try
            {
                if (sFileName != null)
                {
                    sw = new StreamWriter(sFileName, false);
                    foreach (DataRow row in dtCustomer.Rows)
                    {
                        object[] array = row.ItemArray;

                        for (i = 0; i < array.Length - 1; i++)
                        {
                            sw.Write(array[i].ToString() + "~");
                        }
                        sw.WriteLine(array[i].ToString());
                    }
                    sw.Close();
                   

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Invalid Operation : \n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void GenerateCompanyProfile(string foldername)
        {
            WebDataExportBAL webDataExportBal = new WebDataExportBAL();
            DataTable dtCompany = webDataExportBal.GetCompanyProfile();
            if (dtCompany.Rows.Count > 0)
            {
                WriteCompanyProfile(dtCompany,foldername);
            }
        }

        private void WriteCompanyProfile(DataTable dtCompany, string foldername)
        {
            int i = 0;
            string sFileName = foldername + "\\web_company_profile.txt";
            StreamWriter sw = null;
            try
            {
                if (sFileName != null)
                {
                    sw = new StreamWriter(sFileName, false);
                    foreach (DataRow row in dtCompany.Rows)
                    {
                        object[] array = row.ItemArray;

                        for (i = 0; i < array.Length - 1; i++)
                        {
                            sw.Write(array[i].ToString() + "~");
                        }
                        sw.WriteLine(array[i].ToString());
                    }
                    sw.Close();
                 
                }
               
            }

            catch (Exception ex)
            {
                MessageBox.Show("Invalid Operation : \n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
