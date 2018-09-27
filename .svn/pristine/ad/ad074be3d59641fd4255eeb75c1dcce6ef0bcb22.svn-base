using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using BusinessAccessLayer.BAL;

namespace StockbrokerProNewArch.Classes
{
   public class WebDataExportOld
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
               
            }
            catch (Exception)
            {
                throw;

            }
        }

        private void ProcessWebData()
        {
            try
            {
                WebDataExportBALOld objWebdataExportBAL =new WebDataExportBALOld();
                objWebdataExportBAL.ProcessWebData();
            }
            catch (Exception)
            {
                throw;
            }

        }

        private void GenerateMoneyBalance(string foldername)
        {
            WebDataExportBALOld webDataExportBal =new WebDataExportBALOld();
            DataTable dtMoneyBalance = webDataExportBal.GetMoneyBalance();
            if (dtMoneyBalance.Rows.Count > 0)
            {
                WriteMoneyBalance(dtMoneyBalance, foldername);
            }
        }

        private void WriteMoneyBalance(DataTable dtMoneyBalance, string foldername)
        {
            int i = 0;
            string sFileName = foldername + "\\web_money_balance.txt";
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
            catch (Exception)
            {
                throw;
            }

        }

        private void GenerateTradeDetails(string foldername)
        {
            WebDataExportBALOld webDataExportBal = new WebDataExportBALOld();
            DataTable dtTradeDetails = webDataExportBal.GetTradeDetails();
            if (dtTradeDetails.Rows.Count > 0)
            {
                WriteTradeDetails(dtTradeDetails, foldername);
            }

        }

        private void WriteTradeDetails(DataTable dtTradeDetails, string foldername)
        {
            int i = 0;
            string sFileName = foldername + "\\web_trade_detail.txt";
            StreamWriter sw = null;
            try
            {
                if (sFileName != null)
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
            catch (Exception)
            {
                throw;
            }

        }

        private void GenerateTransactionDetails(string foldername)
        {
            WebDataExportBALOld webDataExportBal =new WebDataExportBALOld();
            DataTable dtTransactionDetails = webDataExportBal.GetTransactionDetails();
            if (dtTransactionDetails.Rows.Count > 0)
            {
                WriteTransactionDetails(dtTransactionDetails, foldername);
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
            catch (Exception)
            {
                throw;
            }

        }

        private void GenerateShareDW(string foldername)
        {
            WebDataExportBALOld webDataExportBal =new WebDataExportBALOld();
            DataTable dtshareDW = webDataExportBal.GetShareDW();
            if (dtshareDW.Rows.Count > 0)
            {
                WriteShareDW(dtshareDW, foldername);
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
            catch (Exception)
            {
                throw;
            }


        }

        private void GenerateShareBalanceDetails(string foldername)
        {
            WebDataExportBALOld webDataExportBal =new WebDataExportBALOld();
            DataTable dtshareBalanceDetails = webDataExportBal.GetShareBalanceDetails();
            if (dtshareBalanceDetails.Rows.Count > 0)
            {
                WriteShareBalanceDetails(dtshareBalanceDetails, foldername);
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
            catch (Exception)
            {
                throw;
            }

        }

        private void GenerateShareBalance(string foldername)
        {
            WebDataExportBALOld webDataExportBal =new WebDataExportBALOld();
            DataTable dtshareBalance = webDataExportBal.GetShareBalance();
            if (dtshareBalance.Rows.Count > 0)
            {
                WriteShareBalance(dtshareBalance, foldername);
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

            catch (Exception)
            {
                throw;
            }

        }

        private void GeneratePaymentHistory(string foldername)
        {
            WebDataExportBALOld webDataExportBal =new WebDataExportBALOld();
            DataTable dtpayment = webDataExportBal.GetPaymentHistory();
            if (dtpayment.Rows.Count > 0)
            {
                WritePaymentHistory(dtpayment, foldername);
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

            catch (Exception)
            {
                throw;
            }
        }

        private void GenerateCustomerProfile(string foldername)
        {
            WebDataExportBALOld webDataExportBal =new WebDataExportBALOld();
            DataTable dtCustomer = webDataExportBal.GetCustomerProfile();
            if (dtCustomer.Rows.Count > 0)
            {
                WriteCustomerProfile(dtCustomer, foldername);
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

            catch (Exception)
            {
                throw;
            }

        }

        private void GenerateCompanyProfile(string foldername)
        {
            WebDataExportBALOld webDataExportBal =new WebDataExportBALOld();
            DataTable dtCompany = webDataExportBal.GetCompanyProfile();
            if (dtCompany.Rows.Count > 0)
            {
                WriteCompanyProfile(dtCompany, foldername);
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

            catch (Exception)
            {
                throw;
            }
        }
    }
}
