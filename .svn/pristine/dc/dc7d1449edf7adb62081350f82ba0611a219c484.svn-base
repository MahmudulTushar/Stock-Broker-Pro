using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using ElectronicCommunication.SMS;
using GsmComm.GsmCommunication;
using System.Runtime.Remoting.Contexts;

namespace StockBrokerProWs
{
    public partial class StockBrokerProWs : ServiceBase
    {
        public StockBrokerProWs()
        {
            InitializeComponent();
            //string sourceName = "SBPPro_Ws";
            //string logName = "SBPPro_Ws";
            //if (!System.Diagnostics.EventLog.SourceExists(EventLog_SBP_Ws.Source))
            //{
            //    System.Diagnostics.EventLog.CreateEventSource(EventLog_SBP_Ws.Source, EventLog_SBP_Ws.Log);

            //}
            //EventLog_SBP_Ws.Source = sourceName;
            //EventLog_SBP_Ws.Log = logName;
        }
               
        protected override void OnStart(string[] args)
        {
            try
            {
                Port_Configured();
                Phone_Connection();
            }
            catch (Exception ex)
            {
                string EventMessage = "On Start ";
                EventLog_SBP_Ws.WriteEntry(EventMessage);
                EventLog_SBP_Ws.WriteEntry("Error: "+ex.Message);
            }

        }

        protected override void OnStop()
        {
            try
            {
                Phone_Disconnection();
            }
            catch (Exception ex)
            {
                string EventMessage = "On Stop ";
                EventLog_SBP_Ws.WriteEntry(EventMessage);
                EventLog_SBP_Ws.WriteEntry("Error: "+ex.Message);
            }
        }

        private void SBP_WsTimer_SMSReceiver_Tick(object sender, EventArgs e)
        {
            try
            {
                SMSReceiver rec = new SMSReceiver();
                rec.Execute_ActionAgainstReceivedMessage();
            }
            catch (Exception ex)
            {
                
                EventLog_SBP_Ws.WriteEntry("Error :"+ex.Message.ToString());
                //LogFile(ex.Message, e.ToString(), ((Control)sender).Name, ex.LineNumber(), this.FindForm().Name);
            }
        }

        private void SBP_WsTimer_SMSSender_Tick(object sender, EventArgs e)
        {
            try
            {
                SMSSender objsender = new SMSSender();
                objsender.IPOConfirmationSMS();
                objsender.SendPushPullSMS();
                objsender.DayendTradeConfirmationSMS();
                objsender.SendTradeConfirmationSMS();
                objsender.DayendTradeConfirmationSMS();
            }
            catch (Exception ex)
            {
                EventLog_SBP_Ws.WriteEntry("Error: "+ex.Message.ToString());
                //LogFile(ex.Message, e.ToString(), ((Control)sender).Name, ex.LineNumber(), this.FindForm().Name);
            }
        }

        public void Port_Configured()
        {
            ModemCommunication.Com_Port = ElectronicCommunication.SMS.SMS_Constant.Modem_Port;
            ModemCommunication.Com_BaudRate = ElectronicCommunication.SMS.SMS_Constant.Modem_BraudRate;
            ModemCommunication.Com_TimeOut = ElectronicCommunication.SMS.SMS_Constant.Modem_TimeOut;
            ModemCommunication.Initialization();
        }

        private void Phone_Connection()
        {
            Port_Configured();
            ModemCommunication.gsObj.PhoneConnected += new EventHandler(Comm_PhoneConnected);
            bool retry;
            ModemCommunication.Open();
            //do
            //{
            //    retry = false;
            //    try
            //    {
                   
                   
            //    }
            //    catch (Exception)
            //    {
            //        retry = true;
            //    }
            //}
            //while (retry);
        }

        private void Phone_Disconnection()
        {
            ModemCommunication.Close();
        }

        public void Comm_PhoneConnected(object sender, EventArgs e)
        {
           
        }

       

       
    }
}
