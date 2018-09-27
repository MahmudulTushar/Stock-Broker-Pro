using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GsmComm.GsmCommunication;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using GsmComm.PduConverter;

namespace ElectronicCommunication.SMS
{
    public  class ModemCommunication   
    {
        
        public static GsmCommMain gsObj;
      
        
        private static int _com_Port = 0;

        public static int Com_Port
        {
            get { return ModemCommunication._com_Port; }
            set { ModemCommunication._com_Port = value; }
        }
        private static int _com_BaudRate = 0;

        public static int Com_BaudRate
        {
            get { return ModemCommunication._com_BaudRate; }
            set { ModemCommunication._com_BaudRate = value; }
        }
        private static int _com_TimeOut = 0;

        public static int Com_TimeOut
        {
            get { return ModemCommunication._com_TimeOut; }
            set { ModemCommunication._com_TimeOut = value; }
        }       

        public static void Initialization()
        {
            gsObj = new GsmCommMain(Com_Port, Com_BaudRate, Com_TimeOut);
        }

        public static void Open()
        {
            if (!gsObj.IsOpen())
                gsObj.Open();
        }

        public static void Close()
        {
            if (gsObj.IsOpen())
                gsObj.Close();
        }

        public static List<SmsPdu> ReadMessage_New(int i)
        {
            List<SmsPdu> result = new List<SmsPdu>();
            SmsPdu pdu = new SmsDeliverPdu() { UserDataText = EmailComm_Indications.DefaultSMS_Dash, OriginatingAddress = "+8801731186596" };
            result.Add(pdu);
            return result;
        }

        public static List<SmsPdu> ReadMessage()
        {
            List<SmsPdu> result = new List<SmsPdu>();
            string Storage = GetMessageStorage();
            DecodedShortMessage[] msgs = gsObj.ReadMessages(PhoneMessageStatus.ReceivedUnread, Storage);
            foreach (var obj in msgs)
                result.Add(obj.Data);
            return result;
        }

        public static void SendMessage(SmsSubmitPdu pdu)
        {
            gsObj.SendMessage(pdu);
        }

        public static void SendMessage(SmsSubmitPdu[] pdus)
        {
            gsObj.SendMessages(pdus);
        }

        public static bool IsConnected()
        {
            return gsObj.IsConnected();
        }

        public static bool IsOpened()
        {
            return gsObj.IsOpen();
        }

        public static string GetMessageStorage()
        {
            string storage = string.Empty;
            storage = PhoneStorageType.Phone;
            //string aaa = PhoneStorageType.Sim;

            if (storage.Length == 0)
                throw new ApplicationException("Unknown message storage.");
            else
                return storage;
        }

       

    }
}
