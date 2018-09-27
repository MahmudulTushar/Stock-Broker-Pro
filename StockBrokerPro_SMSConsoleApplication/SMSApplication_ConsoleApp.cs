using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ElectronicCommunication.SMS;
using System.Threading;
using GsmComm.GsmCommunication;
using ElectronicCommunication.Email;
using System.Configuration;
using ElectronicCommunication.Web;
using System.Data.Common;
using DataAccessLayer;


namespace StockBrokerPro_SMSConsoleApplication
{
    public class SMSApplication_ConsoleApp
    {

        public Timer SBPSMSConsole_Timer_SMSSender;
        public Timer SBPSMSConsole_Timer_SMSReceiver;
        public Timer SBPSMSConsole_Timer_EmailSender;

        public TimerCallback SBPSMSConsole_TimerCallBack_SMSSender;
        public TimerCallback SBPSMSConsole_TimerCallBack_SMSReceiver;
        public TimerCallback SBPSMSConsole_TimerCallBack_EmailSender;
        WebSenderReceiver obj;
        
        public void ConsolApplicatinDesign()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("**");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("**");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("**");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("**");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("**");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("**");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("**");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("**");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("**");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("**");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("**");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\t" + "WellCome To SMS Service" + "\t");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("**");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("**");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("**");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("**");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("**");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("**");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("**");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("**");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("**");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("**");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("**" + "\n\n");
        }
        
        public SMSApplication_ConsoleApp()
        {
            Console.ForegroundColor = ConsoleColor.White;
            obj = new WebSenderReceiver();

            try
            {
                Port_Configured();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Modem Configuration Fialed......!!");
            }
            
            try
            {
                Phone_Connection();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Modem Connection Fialed......!!");
            }
            
            try
            {
                DatabaseConfigured();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Database Configured Fialed......!!");
            }
            try
            {
                Configuration_DataAccessLayer();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Configuration Data Access Layer Fialed......!!");
            }
            
            Console.ResetColor();
            ConsolApplicatinDesign();
           
 
           for (; ; )
           {
               //For SMS 
               try
                {
                   
                     
                    

                }
                catch (Exception ex)
                {
                   
                }
               
               //For Email
               try
               {
                   //Thread.Sleep(3);
                   //SBP_WsTimer_EmailSender_Tick(null);

               }
               catch (Exception ex)
               {
                  
               }

               //For Web 
               try
               {
                   obj.ImportIPO_NewApplication_MoneyTransactionRequest();
                   obj.DataProcessIPO_Create_Application_Transaction_Request_FromWeb();
                   obj.ExportIPO_CustomerProfile();
                   obj.ExportIPO_Session_Company();
                   obj.ExportIPO_ParentChinldInfo();
                   obj.ExportStatusIPO_ApplicationStatus();
                   obj.ExportStatusIPO_MoneyTransaction();
                   obj.ExportIPO_AccountBalance();
                   

                   //Thread.Sleep(2000);
               }
               catch (Exception ex)
               {
                   Console.WriteLine("Web Auto Fetch Error!! " + ex.Message);
               }
            }
        }

        ~SMSApplication_ConsoleApp()
        {
            try
            {
                Phone_Disconnection();
            }
            catch (Exception ex)
            {
                string EventMessage = "On Stop";
            }
        }

        public void InitializeTicker()
        {
            //SBPSMSConsole_TimerCallBack_SMSSender = new TimerCallback(SBP_WsTimer_SMSSender_Tick);
            //SBPSMSConsole_TimerCallBack_SMSReceiver = new TimerCallback(SBP_WsTimer_SMSReceiver_Tick);
            SBPSMSConsole_TimerCallBack_EmailSender = new TimerCallback(SBP_WsTimer_EmailSender_Tick);

            SBPSMSConsole_Timer_EmailSender = new System.Threading.Timer(SBPSMSConsole_TimerCallBack_EmailSender, null, 0, 100);
            //SBPSMSConsole_Timer_SMSSender = new System.Threading.Timer(SBPSMSConsole_TimerCallBack_SMSSender, null, 0, 100);
            //SBPSMSConsole_Timer_SMSReceiver = new System.Threading.Timer(SBPSMSConsole_TimerCallBack_SMSReceiver, null, 0, 100);
        }

        public void Port_Configured()
        {
            Console.ForegroundColor = ConsoleColor.White;

            ModemCommunication.Com_Port = Convert.ToInt32(ConfigurationManager.AppSettings["Port"]);
            ModemCommunication.Com_BaudRate =Convert.ToInt32(ConfigurationManager.AppSettings["BraudRate"]);
            ModemCommunication.Com_TimeOut =Convert.ToInt32(ConfigurationManager.AppSettings["Timeout"]);
            
            
            ModemCommunication.Initialization();
            Console.WriteLine("Modem Configuration ......" + Convert.ToString(ModemCommunication.Com_Port));
            Console.WriteLine("Port:      " + Convert.ToString(ModemCommunication.Com_Port));
            Console.WriteLine("BaudRate:  " + Convert.ToString(ModemCommunication.Com_BaudRate));
            Console.WriteLine("TimeOut:   " + Convert.ToString(ModemCommunication.Com_TimeOut));
            Console.ResetColor();
        }

        private void Phone_Connection()
        {
            try
            {

                ModemCommunication.gsObj.PhoneConnected += new EventHandler(Comm_PhoneConnected);
                bool retry;
                ModemCommunication.Open();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Modem Successfully Opened    - " + DateTime.Today);
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        private void DatabaseConfigured()
        {
            Email_Constant.CallCenter_ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["sqlconSMSSender"].ConnectionString);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Database Configuration ......");           
            Console.ResetColor();
        }

        private void Configuration_DataAccessLayer()
        {
            DbConnectionBasic.ConnectionStringSMSSender = ConfigurationManager.ConnectionStrings["sqlconSMSSender"].ToString();
            
        }

        private void Phone_Disconnection()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.White;
                ModemCommunication.Close();
                Console.WriteLine("Modem Successfully Closed  - " + DateTime.Today);
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Comm_PhoneConnected(object sender, EventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Modem Successfully Connected - " + DateTime.Today);
            Console.ResetColor();
        }




        private void SBP_WsTimer_SMSSender_Tick(object state)
        {
            try
            {
                string Message = string.Empty;
                string FullMessage = string.Empty;

                int totalSmsSent = 0;
                SMSSender objsender = new SMSSender();
                //totalSmsSent = totalSmsSent + objsender.IPOConfirmationSMS();
                totalSmsSent = totalSmsSent + objsender.SendPushPullSMS();
                totalSmsSent = totalSmsSent + objsender.DayendTradeConfirmationSMS();
                totalSmsSent = totalSmsSent + objsender.SendTradeConfirmationSMS();


            }
            catch (Exception ex)
            {
                //Phone_Disconnection();
                Phone_Connection();
            }
        }


        private void SBP_WsTimer_EmailSender_Tick(object state)
        {
            try
            {
                EmailSend objEmailSend = new EmailSend();
                objEmailSend.IPOApproveConfirmationEmail();

            }
            catch (Exception)
            {
                throw;
            }
        }

        private void SBP_WsTimer_SMSReceiver_Tick(object state)
        {
            try
            {
                string FullMessageshow = string.Empty;
                SMSReceiver rec = new SMSReceiver();
                FullMessageshow = rec.Execute_ActionAgainstReceivedMessage();

                if (FullMessageshow != "")
                {
                    ADDConSoleApplication(FullMessageshow);
                }
                //string Storge = ModemCommunication.GetMessageStorage();
                //ModemCommunication.gsObj.DeleteMessages(DeleteScope.Read, Storge);
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.ToString());
                //Phone_Disconnection();
                Phone_Connection();
            }
        }


        public void ADDConSoleApplication(string FullMessageshow)
        {
            string[] arraymessagelist = FullMessageshow.Split('-');
            string Phonenumber = arraymessagelist[0].ToString();
            string Message = arraymessagelist[1].ToString();
            if (Message != "")
            {
                SMSCommadCode.K++;
            }
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Message Received : " + "\t");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(Phonenumber + "\t");

            if (Message.Length > 30)
            {
                char[] delimiterChars = { ' ', ',' };
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
                }
                int k = 0;
                foreach (string value in Messages)
                {
                    if (k == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(Convert.ToString(value) + "\n");
                        Console.ResetColor();
                        k++;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("\t\t\t\t\t" + Convert.ToString(value) + "\n");
                        Console.ResetColor();
                        k++;
                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(Convert.ToString(Message) + "\n");
                Console.ResetColor();
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t\t\t\t\t" + "Message Receive : " + SMSCommadCode.K);
        }



        internal void Close()
        {
            throw new NotImplementedException();
        }
    }
}
