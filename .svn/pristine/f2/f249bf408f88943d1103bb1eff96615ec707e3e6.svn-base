using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using GsmComm.PduConverter;
using BusinessAccessLayer.BAL;
using DataAccessLayer;

namespace ElectronicCommunication.SMS
{
   public class SMSSender
    {
       public int IPOConfirmationSMS()
       {
           string SMSMessage = string.Empty;
           string SMSDestination = string.Empty;
           string SMSCustCode = string.Empty;
           int totalSmsSent = 0;
           
           try
           {
               string Conn = SMS_Constant.CallCenter_ConnectionString;
               SqlConnection Connection = new SqlConnection(Conn);
               DataSet adataset = new DataSet();
               SqlDataAdapter aAqldataAdapter = new SqlDataAdapter();
               string Query = "Select Cust_Code,Message,Destination from tbl_IPO_Confirmation_SMS where Status=0";
               aAqldataAdapter.SelectCommand = new SqlCommand(Query, Connection);
               aAqldataAdapter.Fill(adataset);
               DataTable dt = new DataTable();
               dt = adataset.Tables[0];
                foreach (DataRow dr in dt.Rows)
               {
                   SMSCustCode = dr[0].ToString();
                   SMSMessage = dr[1].ToString();
                   SMSDestination = dr[2].ToString();
                   IPOPushtoSender(SMSCustCode, SMSDestination, SMSMessage);                
               }
               totalSmsSent=dt.Rows.Count;
           }
           catch (Exception)
           {
               throw;
           }
           return totalSmsSent;
       }


     


       public void IPOPushtoSender(string CustCode, string PhoneNumber, string Message)
       {
           try
           {
               string FullMessage = string.Empty;
               if (PhoneNumber.Length > 11 || PhoneNumber.Length == 11)
               {
                   PhoneNumber = PhoneNumber.Replace("+880", "0");
               }

               else
               {
                   //return ;
               }      
                   SendInvalidCustomerNotice(PhoneNumber, Message);
                   DataSqlQuery oDACommonQuery = new DataSqlQuery();
                   oDACommonQuery.IPOConfirmedStatusUpdate(PhoneNumber.Trim());
                   SendMessageloadConsolApplicationtDesign(CustCode, PhoneNumber, Message);
                              

           }
           catch (Exception)
           {              
               throw;
           }
          
       }

       public void SendMessageloadConsolApplicationtDesign(string CustCode , string PhoneNumber, string Message)
       {
           if (Message != "0")
           {
               SMSCommadCode.S++;
           }

           Console.ForegroundColor = ConsoleColor.Yellow;
           Console.Write("Message Sent     : ");
           if (CustCode.Length == 3)
           {
               Console.ForegroundColor = ConsoleColor.Red;
               Console.Write(CustCode + "   ");
           }
           else if (CustCode.Length == 4)
           {
               Console.ForegroundColor = ConsoleColor.Red;
               Console.Write(CustCode + "  ");
           }
           else
           {
               Console.ForegroundColor = ConsoleColor.Red;
               Console.Write(CustCode + " ");
           }          
           Console.ForegroundColor = ConsoleColor.White;
           Console.Write(PhoneNumber +"    ");


           string Messagelist = string.Empty;

           if (Message.Length > 30)
           {
               char[] delimiterChars = { ' ', ','};
               string[] Words = Message.Split(delimiterChars);
               List<string> Messages = new List<string>();
               if (Message.Length > 30)
               {

                   string FullMessageTemp = Message;
                   int i = 0;
                   int stringLength = Message.Length;
                   while (FullMessageTemp.Length > 0)
                   {
                       string EachMessage = string.Empty;
                       while (EachMessage.Length + Words[i].Length < 30)
                       {
                           EachMessage = EachMessage + Words[i] + " ";
                           i++;
                           if (i >= Words.Length)
                               break;
                       }

                       FullMessageTemp = FullMessageTemp.Replace(FullMessageTemp, EachMessage).ToString();
                       Messages.Add(FullMessageTemp);
                       //i++;
                       if (i >= Words.Length)
                           break;
                   }
               }
               int k = 0;
               foreach (string value in Messages)
               {
                   if (k == 0)
                   {
                       Console.ForegroundColor = ConsoleColor.Cyan;
                       Console.Write(Convert.ToString(value) + "\n");
                       Console.ResetColor();
                       k++;
                   }
                   else
                   {
                       Console.ForegroundColor = ConsoleColor.Cyan;
                       Console.Write("\t\t\t\t\t"+Convert.ToString(value) + "\n");
                       Console.ResetColor();
                       k++;
                   }
               }
           }
           else
           {
               Console.ForegroundColor = ConsoleColor.Cyan;
               Console.Write(Convert.ToString(Message) + "\n");
               Console.ResetColor();
           }
           Console.ForegroundColor = ConsoleColor.Yellow;
           Console.WriteLine("\t\t\t\t\t" + "Message Send : " + SMSCommadCode.S);
       }



     
       

       private string getIPOInformation(string Cust_Code)
       {
           string cnn = SMS_Constant.CallCenter_ConnectionString;
           string[] ParendChild = null;
           string CustCode = string.Empty;
           string ShortCode = string.Empty;
           string TradeAccountBalance = string.Empty;
           string IPOAccountBalance = string.Empty;
           string IPOBalance = string.Empty;
           DataSqlQuery dataQuery = new DataSqlQuery();           
           SqlConnection conn = new SqlConnection(cnn);
           DataSet oDataSet = new DataSet();
           SqlDataAdapter SQLDbAdapter = new SqlDataAdapter();
           string query = "Select  Sess.Company_Short_Code as Short_Code,Convert(decimal(28,0),ROUND((Sess.TotalAmount),2))  as TotalAmount,'" + Cust_Code + "' as Cust_Code,Convert(decimal(28,2),ROUND((Select t.Balance from tbl_Customer_Account   as t where t.Cust_Code='" + Cust_Code + "'),2)) AS TradeAcc_Balance,Convert(decimal(28,2),ROUND(ISNULL((Select t.Balance    from tbl_Customer_IPO_Account as t where t.Cust_Code='" + Cust_Code + "'),0),2)) AS IPOAcc_Balance    from [dbksclCallCenter].[dbo].[tbl_IPO_SessionforCompanyInfo] as Sess";
                
           SQLDbAdapter.SelectCommand = new SqlCommand(query, conn);
           SQLDbAdapter.Fill(oDataSet);
           DataTable dt = new DataTable();

           dt = oDataSet.Tables[0];

           var PRegcode = (dataQuery.GetParentChildCheckFormCustCode(Cust_Code));
           if (PRegcode.Count != 0)
           {
               ParendChild = PRegcode.ToArray();
               CustCode = ParendChild[0] + "," + ParendChild[1] + "," + ParendChild[2].ToString();
           }
           else
           {
               CustCode = Cust_Code;
           }           

           string shareSummery ="ID :"+Cust_Code+","+ "Current IPO :";
           foreach (DataRow dr in dt.Rows)
           {
               ShortCode = dr["Short_Code"].ToString();
               IPOBalance = dr["TotalAmount"].ToString();
               TradeAccountBalance =dr["TradeAcc_Balance"].ToString();
               IPOAccountBalance = dr["IPOAcc_Balance"].ToString();               
               if (ShortCode != "")
               {
                 //MessageGenerate  dd = new MessageGenerate();
                 //MessageGenerate.messageStroe(Cust_Code, ShortCode, IPOBalance, TradeAccountBalance, IPOAccountBalance, CustCode);
                 shareSummery = shareSummery + " " + dr["Short_Code"].ToString() + " " + "&" + " " + "Amount:" + dr["TotalAmount"].ToString() + "," + "IPO parent Acc. Balance:" + dr["IPOAcc_Balance"].ToString() + "," + "Trade Acc. Balance:" + dr["TradeAcc_Balance"].ToString() + "," + "SMS Format:" + dr["Short_Code"].ToString() + " " + CustCode + " " + "pmipo rmipo";
               }
               else
               { 
                   DataSqlQuery objdataSqlQuery = new DataSqlQuery();
                   string SMSCode = "SMS09";
                   string sMessage =objdataSqlQuery.GetNotRegisterMessage(SMSCode);
                   shareSummery = sMessage;
               }
           }
           return shareSummery;
       }






       public void IPOInformationConfirmationSMS()
       {
           string SMSMessage = string.Empty;
           string SMSDestination = string.Empty;
           try
           {
               string Conn = SMS_Constant.CallCenter_ConnectionString;// DataAccessLayer.DbConnectionBasic.ConnectionStringSMSSender;
               SqlConnection Connection = new SqlConnection(Conn);
               DataSet adataset = new DataSet();
               SqlDataAdapter aAqldataAdapter = new SqlDataAdapter();
               string Query = "Select Cust_Code,Message,Destination from tbl_IPO_Confirmation_SMS where Status=0 AND Message ='IPO'";
               aAqldataAdapter.SelectCommand = new SqlCommand(Query, Connection);
               aAqldataAdapter.Fill(adataset);
               DataTable dt = new DataTable();
               dt = adataset.Tables[0];
               foreach (DataRow dr in dt.Rows)
               {
                   SMSMessage = dr[0].ToString();
                   SMSDestination = dr[1].ToString();
                   ConfirmationIPOPushtoSender(SMSDestination, SMSMessage);                  
               }
           }
           catch (Exception)
           {
               throw;
           }
       }

       private void ConfirmationIPOPushtoSender(string sSMSSender, string Message)
       {
           try
           {
               if (sSMSSender.Length > 11 || sSMSSender.Length == 11)
               {
                   sSMSSender = sSMSSender.Replace("+880", "0");
               }
               else
               {
                   return;
               }
               SmsSubmitPdu pdu;
               pdu = new SmsSubmitPdu(Message, sSMSSender.Trim(), "");               
               ModemCommunication.gsObj.SendMessage(pdu);
               DataSqlQuery oDACommonQuery = new DataSqlQuery();
               oDACommonQuery.IPOConfirmedStatusUpdate(sSMSSender.Trim());
           }
           catch (Exception exc)
           {
               throw new Exception(exc.Message);
           }
       }


       //------------------------------------------------------------------------

       #region TestFile


       public void LogFile(string CustCode, string SMSSender, string SMSShortCode, string Full_Message)
       {
           string fileName = @"D:\DocXExample.txt";
           StreamWriter log;
           if (!File.Exists(fileName))
           {
               log = new StreamWriter(fileName);
           }
           else
           {
               log = File.AppendText(fileName);
           }
           // Write to the file:
           log.Write(("~") + CustCode + ("~") + SMSSender
               + ("~") + SMSShortCode
               + ("~") + Full_Message
              );

           log.Close();
       }

       public void LogFile11(string sSMSSender)
       {

           StreamWriter log;
           if (!File.Exists("Test11File.txt"))
           {
               log = new StreamWriter("Test11File.txt");
           }
           else
           {
               log = File.AppendText("Test11File.txt");
           }
           // Write to the file:
           log.WriteLine(("~") + sSMSSender
              );

           log.Close();
       }






       #endregion


       public int SendPushPullSMS()
       {
           string CustCode = "";
           string SMSSender = "";
           string SMSShortCode = "";
           String Full_Message = "";
           int totalSmsSent = 0;
           try
           {
               string cnn = SMS_Constant.CallCenter_ConnectionString;
               SqlConnection Conn = new SqlConnection(cnn);
               DataSet aDataset = new DataSet();
               SqlDataAdapter aSqlDataAdapter = new SqlDataAdapter();
               String query = "Select Cust_Code,Sender,Short_Code,Full_Message from tbl_Received_SMS Where Status=0";
               aSqlDataAdapter.SelectCommand = new SqlCommand(query, Conn);
               aSqlDataAdapter.Fill(aDataset);
               DataTable dt = new DataTable();

               dt = aDataset.Tables[0];
               foreach (DataRow dr in dt.Rows)
               {
                   CustCode = "" + dr[0].ToString();
                   SMSSender = dr[1].ToString();
                   SMSShortCode = dr[2].ToString();
                   Full_Message = dr[3].ToString();

                   if (CustCode != "")
                   {
                       PushtoSender(Convert.ToInt64(CustCode), SMSSender, SMSShortCode, CustCode);
                   }
                   else
                   {
                       PushtoSender(0, SMSSender, SMSShortCode,CustCode);                       
                   }
               }
               totalSmsSent = dt.Rows.Count;

           }
           catch (Exception)
           {
               throw;
           }
           return totalSmsSent;
       }
       public void PushtoSender(long CustomerID, string sSMSSender, string SMSShortCode, string CustCode)
       {
           try
           {
               string FullMessage = string.Empty;
               if (sSMSSender.Length > 11 || sSMSSender.Length == 11)
               {
                   sSMSSender = sSMSSender.Replace("+880", "0");
               }
               else
               {
                   return;
               }
               if (CustomerID < 1)
               {
                   CustomerID = GetCustomerID_FromReg(0, sSMSSender);
               }
               else
               {
                   CustomerID = GetCustomerID_FromReg(CustomerID, sSMSSender);
               }
               string PushMessage = "";
               if (SMSShortCode.ToUpper().Trim() == "SS")
               {
                   PushMessage = GetShareSummery(CustomerID);
               }
               else if (SMSShortCode.ToUpper().Trim() == "CB")
               {
                   PushMessage = GetCurrentBalance(CustomerID);
               }
               else if (SMSShortCode.ToUpper().Trim() == "LPR" || SMSShortCode.ToUpper().Trim() == "LP")
               {
                   PushMessage = getLastPaymentReceived(CustomerID);
               }
               else if (SMSShortCode.ToUpper().Trim() == "AS" || SMSShortCode.ToUpper().Trim() == "ACS")
               {
                   PushMessage = getAccountSummery(CustomerID);
               }
               else
               {
                   return;
               }
               if (CustomerID < 1)
               {
                   PushMessage = "Your mobile number is not tag with your customer id.please do contact with KSCL.";
               }
             
               SmsSubmitPdu pdu;

               if (PushMessage.Length > 160)
               {
                   PushMessage = SplitStringAt(160, PushMessage);
                   string[] word = PushMessage.Split('|');
                   PushMessage = word[0];

                   pdu = new SmsSubmitPdu(PushMessage, sSMSSender.Trim());
                   ModemCommunication.gsObj.SendMessage(pdu);                  
                   SendMessageloadConsolApplicationtDesign(CustCode, sSMSSender, PushMessage);
                   
                   PushMessage = word[1];
                   pdu = new SmsSubmitPdu(PushMessage, sSMSSender.Trim());
                   ModemCommunication.gsObj.SendMessage(pdu);
                   SendMessageloadConsolApplicationtDesign(CustCode, sSMSSender, PushMessage);
               }
               else
               {
                   pdu = new SmsSubmitPdu(PushMessage, sSMSSender.Trim(), "");  // "" indicate SMSC No
                   ModemCommunication.gsObj.SendMessage(pdu);
                   SendMessageloadConsolApplicationtDesign(CustCode, sSMSSender, PushMessage);
               }

               DataSqlQuery oDACommonQuery = new DataSqlQuery();
               oDACommonQuery.ReceivedStatusUpdate("+88" + sSMSSender.Trim(), SMSShortCode);
           }
           catch (Exception)
           {
               throw;
           }
       }    


       private long GetCustomerID_FromReg(long CustCode, string SMSSender)
       {
           try
           {
               if (SMSSender.Length > 11 || SMSSender.Length == 11)
               {
                   SMSSender = SMSSender.Replace("+880", "0");
               }
               else
               {
                   return 0;
               }
               string cnn = SMS_Constant.CallCenter_ConnectionString;//DataAccessLayer.DbConnectionBasic.ConnectionStringSMSSender;
               SqlConnection aSqlConnection = new SqlConnection(cnn);
               DataSet aDataset = new DataSet();
               SqlDataAdapter aSqldataadapter = new SqlDataAdapter();
               string Query = string.Empty;
               if (CustCode == 0)
               {
                   Query = "Select TOP 1 Cust_Code from tbl_Confirmation_SMS_Reg Where Mobile='" + SMSSender + "' ORDER BY Convert(int,Cust_Code) ASC";
               }
               else
               {
                   Query = "Select TOP 1 Cust_Code from tbl_Confirmation_SMS_Reg Where Mobile='" + SMSSender + "' AND Cust_Code='" + Convert.ToString(CustCode) + "' ORDER BY Convert(int,Cust_Code) ASC";
               }
               aSqldataadapter.SelectCommand = new SqlCommand(Query, aSqlConnection);
               aSqldataadapter.Fill(aDataset);
               DataTable dt = new DataTable();

               dt = aDataset.Tables[0];

               long CustomerCode = 0;
               foreach (DataRow dr in dt.Rows)
               {
                   CustomerCode = Convert.ToInt32(dr[0].ToString());
                   if (CustCode == CustomerCode)
                   {
                       CustomerCode = CustCode;
                       return CustomerCode;
                   }
               }
               return CustomerCode;

           }
           catch (Exception)
           {
               throw;
           }
       }

       private string GetShareSummery(long CustomerID)
       {
           try
           {
               String ShareSummery = string.Empty;
               string cnn = SMS_Constant.CallCenter_ConnectionString;//DataAccessLayer.DbConnectionBasic.ConnectionStringSMSSender;
               SqlConnection aSqlConnection = new SqlConnection(cnn);
               DataSet aDataset = new DataSet();
               SqlDataAdapter asqldataAdapter = new SqlDataAdapter();
               string Query = "Select Company_Short_Code,Balance,Matured_Balance from tbl_Share_Balance Where Cust_Code=" + CustomerID + " AND Balance<>0";
               asqldataAdapter.SelectCommand = new SqlCommand(Query, aSqlConnection);
               asqldataAdapter.Fill(aDataset);
               DataTable dt = new DataTable();

               dt = aDataset.Tables[0];
               if (dt.Rows.Count == 0)
               {
                   ShareSummery ="ID:" + Convert.ToString(CustomerID) + ","+ "This custcode share is not available.";
               }
               else
               {
                    ShareSummery = "ID:" + Convert.ToString(CustomerID);
               }
               foreach (DataRow dr in dt.Rows)
               {
                   string CompanyShortCode = dr[0].ToString();
                   string Balance = dr[1].ToString();
                   string MutualBalance = dr[2].ToString();
                   if (Balance == MutualBalance)
                   {
                       ShareSummery = ShareSummery + "" + dr[0].ToString() + "" + dr[1].ToString();
                   }
                   else if (Balance != "" && MutualBalance != "" && Balance != MutualBalance)
                   {
                       ShareSummery = ShareSummery + "" + dr[0].ToString() + "" + dr[1].ToString() + "/" + dr[2].ToString();
                   }                  
               
               }
               return ShareSummery;
           }
           catch (Exception)
           {
               throw;
           }
       }

       private string GetCurrentBalance(long CustomerID)
       {
           try
           {
               string cnn = SMS_Constant.CallCenter_ConnectionString;//DataAccessLayer.DbConnectionBasic.ConnectionStringSMSSender;
               SqlConnection aConn = new SqlConnection(cnn);
               DataSet aDataSet = new DataSet();
               SqlDataAdapter adataAdapter = new SqlDataAdapter();
               string Query = "Select Last_Update,Cust_Code,Cast(Balance as decimal(20,2)) from tbl_Customer_Account Where Cust_Code=" + CustomerID;
               adataAdapter.SelectCommand = new SqlCommand(Query, aConn);
               adataAdapter.Fill(aDataSet);

               DataTable dt = new DataTable();

               dt = aDataSet.Tables[0];
               string CurrentBalance = "";
               foreach (DataRow dr in dt.Rows)
               {
                   CurrentBalance = CurrentBalance + "Date : " + dr[0].ToString() + " ID: " + dr[1].ToString() + " Balance : " + dr[2].ToString();
               }
               return CurrentBalance;
           }
           catch (Exception)
           {
               throw;
           }
       }

       private string getLastPaymentReceived(long CustomerID)
       {
           try
           {
               string cnn = SMS_Constant.CallCenter_ConnectionString;//DataAccessLayer.DbConnectionBasic.ConnectionStringSMSSender;
               SqlConnection conn = new SqlConnection(cnn);
               DataSet oDataSet = new DataSet();
               SqlDataAdapter SQLDbAdapter = new SqlDataAdapter();
               string query = "Select Cust_Code,Received_Date,Amount"
                              + " from dbo.tbl_Cust_Paymnet_All"
                              + " where Deposit_Withdraw='Deposit'"
                              + " and Cust_Code=" + CustomerID
                              + " and  Received_Date=(Select Max(Received_Date) from dbo.tbl_Cust_Paymnet_All where Deposit_Withdraw='Deposit' and Cust_Code=" + CustomerID + ")";
               SQLDbAdapter.SelectCommand = new SqlCommand(query, conn);
               SQLDbAdapter.Fill(oDataSet);
               DataTable dt = new DataTable();

               dt = oDataSet.Tables[0];

               string LPR = "";
               foreach (DataRow dr in dt.Rows)
               {
                   LPR = LPR + " ID :" + dr[0].ToString() + " Deposit Date : " + String.Format("{0:dd-MMM-yyyy}", Convert.ToDateTime(dr[1].ToString())) + " Amount : " + dr[2].ToString();
               }
               query = "";
               DataSet oDataSet1 = new DataSet();
               query = "Select Cust_Code,Received_Date,Amount"
                             + " from dbo.tbl_Cust_Paymnet_All"
                             + " where Deposit_Withdraw='Withdraw'"
                             + " and Cust_Code=" + CustomerID
                             + " and  Received_Date=(Select Max(Received_Date) from dbo.tbl_Cust_Paymnet_All where Deposit_Withdraw='Withdraw' and Cust_Code=" + CustomerID + ")";
               SQLDbAdapter.SelectCommand = new SqlCommand(query, conn);
               SQLDbAdapter.Fill(oDataSet1);
               DataTable dt1 = new DataTable();

               dt1 = oDataSet1.Tables[0];
               foreach (DataRow dr in dt1.Rows)
               {
                   LPR = LPR + " Withdraw Date : " + String.Format("{0:dd-MMM-yyyy}", Convert.ToDateTime(dr[1].ToString())) + " Amount : " + dr[2].ToString();
               }
               return LPR;

           }
           catch (Exception)
           {
               throw;
           }
       }

       private string getAccountSummery(long CustomerID)
       {
           try
           {
               string cnn = SMS_Constant.CallCenter_ConnectionString;//DataAccessLayer.DbConnectionBasic.ConnectionStringSMSSender;
               SqlConnection conn = new SqlConnection(cnn);
               DataSet oDataSet = new DataSet();
               SqlDataAdapter SQLDbAdapter = new SqlDataAdapter();
               string query = "Select Cust_Code,cast(Balance as decimal(20,2))Balance, CAST(Deposit as decimal(20,2))Deposit, cast(Withdraw as decimal(20,2))Withdraw, last_update"
                   + " from dbo.tbl_Customer_Account"
                   + " where Cust_Code=" + CustomerID;
               SQLDbAdapter.SelectCommand = new SqlCommand(query, conn);
               SQLDbAdapter.Fill(oDataSet);
               DataTable dt = new DataTable();

               dt = oDataSet.Tables[0];

               string AS = "";
               foreach (DataRow dr in dt.Rows)
               {
                   AS = AS + " ID :" + dr[0].ToString() + " Balance : " + dr[1].ToString() + " Total Deposit : " + dr[2].ToString() + " Total Withdraw : " + dr[3].ToString() + " Last Update : " + String.Format("{0:dd-MMM-yyyy}", Convert.ToDateTime(dr[4].ToString()));
               }
               query = "";
               query = "SELECT     dbo.tbl_Share_Balance.Cust_Code,dbo.tbl_Daily_trade_details.TradeDate,"
                         + "cast(SUM(dbo.tbl_Daily_trade_details.Closep*dbo.tbl_Share_Balance.Matured_Balance)as decimal(20,2)) TotalSharePrice"
                         + " FROM         dbo.tbl_Share_Balance LEFT OUTER JOIN"
                         + " dbo.tbl_Daily_trade_details ON dbo.tbl_Share_Balance.Company_Short_Code = dbo.tbl_Daily_trade_details.Company_Short_Code"
                         + " where tbl_Daily_trade_details.TradeDate=(Select max(TradeDate) from tbl_Daily_trade_details)"
                         + " and Cust_Code=" + CustomerID
                         + " Group by  dbo.tbl_Share_Balance.Cust_Code,dbo.tbl_Daily_trade_details.TradeDate";
               DataSet oDataSet1 = new DataSet();
               SQLDbAdapter.SelectCommand = new SqlCommand(query, conn);
               SQLDbAdapter.Fill(oDataSet1);
               DataTable dt1 = new DataTable();

               dt1 = oDataSet1.Tables[0];

               foreach (DataRow dr in dt1.Rows)
               {
                   AS = AS + " Mkt Value :" + dr[2].ToString() + " Date : " + String.Format("{0:dd-MMM-yyyy}", Convert.ToDateTime(dr[1].ToString()));
               }
               return AS;

           }
           catch (Exception)
           {
               throw;
           }
       }

       string SplitStringAt(int number, string contents)
       {
           try
           {
               if ((number == 0) || (number < 0) || (number > contents.Length))
               {
                   throw new ArgumentOutOfRangeException("Number");
               }
               else
               {
                   int count = 0;

                   StringBuilder _string = new StringBuilder();

                   foreach (char c in contents.ToCharArray())
                   {
                       if (count == number)
                       {
                           count = 0;
                           _string.Append("|");
                       }
                       else
                       {
                           _string.Append(c);
                           count++;
                       }
                   }

                   return _string.ToString();
               }

           }
           catch (Exception)
           {
               throw;
           }
       }

       public int SendTradeConfirmationSMS()
       {
           string SMSMessage = "";
           string SMSDestination = "";
           int totalSmsSent = 0;
           try
           {
               string Conn = SMS_Constant.CallCenter_ConnectionString;
               SqlConnection Connection = new SqlConnection(Conn);
               DataSet adataset = new DataSet();
               SqlDataAdapter aAqldataAdapter = new SqlDataAdapter();
               string Query = "Select Message,Destination from tbl_SMS_Server Where Status=0";
               aAqldataAdapter.SelectCommand = new SqlCommand(Query, Connection);
               aAqldataAdapter.Fill(adataset);
               DataTable dt = new DataTable();
               dt = adataset.Tables[0];
               foreach (DataRow dr in dt.Rows)
               {
                   SMSMessage = dr[0].ToString();
                   SMSDestination = dr[1].ToString();
                   ConfirmationPushtoSender(SMSDestination, SMSMessage);                   
               }
               totalSmsSent = dt.Rows.Count;
           }
           catch (Exception)
           {
               throw;
           }
           return totalSmsSent;
       }
       private void ConfirmationPushtoSender(string sSMSSender, string message)
       {
           try
           {
               string Fullmessage = string.Empty;
               if (sSMSSender.Length > 11 || sSMSSender.Length == 11)
               {
                   sSMSSender = sSMSSender.Replace("+880", "0");
               }
               else
               {
                   return;
               }
               SmsSubmitPdu pdu;
               pdu = new SmsSubmitPdu(message, sSMSSender.Trim(), "");
               ModemCommunication.gsObj.SendMessage(pdu);
              
               DataSqlQuery aDaCommonquery = new DataSqlQuery();
               aDaCommonquery.TradeConfirmedStatusUpdate(sSMSSender.Trim());
               SendMessageloadConsolApplicationtDesign("0", sSMSSender, message);

           }
           catch (Exception)
           {

               throw;
           }
       }
       public int DayendTradeConfirmationSMS()
       {
           string CustCode = "";
           string SMSMessage = "";
           string SMSDestination = "";
           int totalSmsSent = 0;
           try
           {
               string cnn = SMS_Constant.CallCenter_ConnectionString;
               SqlConnection asqlConnection = new SqlConnection(cnn);
               DataSet aDataSet = new DataSet();
               SqlDataAdapter aDataAdapter = new SqlDataAdapter();
               string Query = "Select Cust_Code,Message,Destination from tbl_Trade_Confirmation_SMS Where Status=0";
               aDataAdapter.SelectCommand = new SqlCommand(Query, asqlConnection);
               aDataAdapter.Fill(aDataSet);

               DataTable dt = new DataTable();
               dt = aDataSet.Tables[0];

               foreach (DataRow dr in dt.Rows)
               {
                   CustCode = dr[0].ToString();
                   SMSMessage = dr[1].ToString();
                   SMSDestination = dr[2].ToString();
                   DayendTradeConfirmationPushtosender(CustCode, SMSDestination, "ID:" + CustCode + " " + SMSMessage);
               }
               totalSmsSent = dt.Rows.Count;
           }
           catch (Exception)
           {
               throw;
           }
           return totalSmsSent;
       }

       private void DayendTradeConfirmationPushtosender(string Custcode ,string sSMSSender, string Message)
       {

           try
           {
               string Fullmessage = string.Empty;
               if (sSMSSender.Length > 11 || sSMSSender.Length == 11)
               {
                   sSMSSender = sSMSSender.Replace("+880", "0");
               }

               else
               {
                   return;
               }
               // Send an SMS message
               SmsSubmitPdu pdu;
               // The straightforward version

               if (Message.Length > 160)
               {
                   Message = SplitStringAt(160, Message);
                   string[] word = Message.Split('|');
                   Message = word[0];

                   pdu = new SmsSubmitPdu(Message, sSMSSender.Trim(), "");// "" indicate SMSC No    
                   ModemCommunication.SendMessage(pdu);
                   SendMessageloadConsolApplicationtDesign(Custcode, sSMSSender, Message);

                   Message = word[1];
                   pdu = new SmsSubmitPdu(Message, sSMSSender.Trim(), "");  // "" indicate SMSC No
                   ModemCommunication.SendMessage(pdu);
                   SendMessageloadConsolApplicationtDesign(Custcode, sSMSSender, Message);
               }
               else
               {
                   pdu = new SmsSubmitPdu(Message, sSMSSender.Trim(), "");                  
                   ModemCommunication.SendMessage(pdu);
                   SendMessageloadConsolApplicationtDesign(Custcode, sSMSSender, Message);
               }              
               DataSqlQuery oDACommonQuery = new DataSqlQuery();
               oDACommonQuery.DayendTradeConfirmedStatusUpdate(sSMSSender.Trim());
           }
           catch (Exception)
           {
               //MessageBox.Show(exc.Message); 
               throw;
           }
       }

       private void SendMoneyTransSMS()
       {
           string SMSMessage = "";
           string SMSDestination = "";
           int Id = 0;
           try
           {
               string cnn = SMS_Constant.CallCenter_ConnectionString; //DataAccessLayer.DbConnectionBasic.ConnectionStringSMSSender;
               SqlConnection conn = new SqlConnection(cnn);
               DataSet oDataSet = new DataSet();
               SqlDataAdapter OleDbAdapter = new SqlDataAdapter();
               string query = "Select SMSID,Message,Destination from tbl_MoneyTransConfirmation_SMS Where Status=0";
               OleDbAdapter.SelectCommand = new SqlCommand(query, conn);
               OleDbAdapter.Fill(oDataSet);
               DataTable dt = new DataTable();
               dt = oDataSet.Tables[0];
               foreach (DataRow dr in dt.Rows)
               {
                   Id = Convert.ToInt32(dr[0].ToString());
                   SMSMessage = dr[1].ToString();
                   SMSDestination = dr[2].ToString();
                   MoneyTrans_ConfirmationPushtoSender(SMSDestination, SMSMessage, Id);
               }
           }
           catch (Exception ex)
           {
               //MessageBox.Show(ex.Message);
           }
       }

       private void MoneyTrans_ConfirmationPushtoSender(string sSMSSender, string Message, int SMSID)
       {

           try
           {
               if (sSMSSender.Length > 11 || sSMSSender.Length == 11)
               {
                   sSMSSender = sSMSSender.Replace("+880", "0");
               }

               else
               {
                   return;
               }
               // Send an SMS message
               SmsSubmitPdu pdu;
               // The straightforward version

               pdu = new SmsSubmitPdu(Message, sSMSSender.Trim(), "");  // "" indicate SMSC No             
               ModemCommunication.gsObj.SendMessage(pdu);
               //string CurrentDateTime = String.Format("{0:dd-MMM-yyyy HH:mm:ss tt}", System.DateTime.Now);
               DataSqlQuery oDACommonQuery = new DataSqlQuery();
               oDACommonQuery.MoneyTransSMS_StatusUpdate(SMSID);
           }
           catch (Exception exc)
           {
               //MessageBox.Show(exc.Message);
           }
       }

       //-----------------------------------------------------------------------




       public void SendInvalidCustomerNotice(string sSMSSender, string sMesssage)
       {
           try
           {
               if (sSMSSender.Length > 11 || sSMSSender.Length == 11)
               {
                   sSMSSender = sSMSSender.Replace("+880", "0");
               }

               else
               {
                   return;
               }
               if (sMesssage.Length > 160)
               {
                   List<string> Messages = new List<string>();
                   string[] Words = sMesssage.Split(' ');
                   string FullMessageTemp = sMesssage;
                   int i = 0;
                   int stringLength = sMesssage.Length;
                   while (FullMessageTemp.Length > 0)
                   {
                       string EachMessage = string.Empty;
                       while (EachMessage.Length + Words[i].Length < 160)
                       {
                           EachMessage = EachMessage + Words[i] + "  ";
                           i++;
                           if (i >= Words.Length)
                               break;
                       }

                       FullMessageTemp = FullMessageTemp.Replace(FullMessageTemp, EachMessage).ToString();
                       Messages.Add(FullMessageTemp);
                       //i++;
                       if (i >= Words.Length)
                           break;
                   }
                   foreach (string Value in Messages)
                   {
                       SmsSubmitPdu pdu;
                       pdu = new SmsSubmitPdu(Value, sSMSSender.Trim(), "");
                       ModemCommunication.gsObj.SendMessage(pdu);
                       return;
                   }
               }
               else
               {
                   string PushMessage = "";
                   PushMessage = sMesssage;
                   SmsSubmitPdu pdu;
                   pdu = new SmsSubmitPdu(PushMessage, sSMSSender.Trim(), "");
                   ModemCommunication.gsObj.SendMessage(pdu);
                   return;
               }

           }
           catch (Exception)
           {
               throw;
           }
       }







       #region TestingFile




       public void InsertFile(string sExceptionName, string sModuleName)
       {

           string fileName = @"D:\DataInsertFile.txt";
           StreamWriter log;
           if (!File.Exists(fileName))
           {
               log = new StreamWriter(fileName);
           }
           else
           {
               log = File.AppendText(fileName);
           }
           log.WriteLine(sExceptionName + ("~") + sModuleName );

           log.Close();
       }


       #endregion

    }
}
