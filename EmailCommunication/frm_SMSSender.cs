using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using DataAccessLayer;
using GsmComm.GsmCommunication;
using System.Data.SqlClient;
using GsmComm.PduConverter;
using System.Text.RegularExpressions;
using System.IO;
using System.Configuration;
using ElectronicCommunication.SMS;



namespace EmailCommunication
{
    public partial class frm_SMSSender : Form
    {
        public int port_Modem = 3;
        public int baudrate_Modem = 9600;//9600;
        public int timeout_Modem = 3;//GsmCommMain.DefaultTimeout;

        #region
        int Interval = 0;
        private int port;
        private int baudRate;
        private int timeout;
        #endregion
        //SendConnectionModem aSendConnection = new SendConnectionModem();
        
        public frm_SMSSender()
        {
            InitializeComponent();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            ModemCommunication.Close();
        }     


        private void frm_SMSSender_Load(object sender, EventArgs e)
        {
            btnReceivedSMS.Enabled = true;
            btnConnect.Enabled = true;
            btnSendSMS.Enabled = true;
            btnClose.Enabled = true;
            LoadCombo();          
            cmbComPortNo.SelectedIndex = 2;
            cmbBaudRate.SelectedIndex = 0;
            cmbTimeout.SelectedIndex = 1;
            
        } 

        private void LoadCombo()
        {
            cmbComPortNo.Items.Add("1");
            cmbComPortNo.Items.Add("2");
            cmbComPortNo.Items.Add("3");
            cmbComPortNo.Items.Add("4");
            cmbComPortNo.Items.Add("5");
            cmbComPortNo.Items.Add("6");
            cmbComPortNo.Items.Add("7");
            cmbComPortNo.Items.Add("8");
            cmbComPortNo.Items.Add("9");
            cmbComPortNo.Items.Add("10");
            cmbComPortNo.Items.Add("11");
            cmbComPortNo.Items.Add("12");
            cmbComPortNo.Items.Add("13");
            cmbComPortNo.Items.Add("14");
            cmbComPortNo.Items.Add("15");
            cmbComPortNo.Items.Add("16");
            cmbComPortNo.Items.Add("17");
            cmbComPortNo.Items.Add("18");
            cmbComPortNo.Items.Add("19");
            cmbComPortNo.Items.Add("20");
            cmbComPortNo.Text = port.ToString();

            cmbBaudRate.Items.Add("9600");
            cmbBaudRate.Items.Add("19200");
            cmbBaudRate.Items.Add("38400");
            cmbBaudRate.Items.Add("57600");
            cmbBaudRate.Items.Add("115200");
            cmbBaudRate.Text = baudRate.ToString();

            cmbTimeout.Items.Add("150");
            cmbTimeout.Items.Add("300");
            cmbTimeout.Items.Add("600");
            cmbTimeout.Items.Add("900");
            cmbTimeout.Items.Add("1200");
            cmbTimeout.Items.Add("1500");
            cmbTimeout.Items.Add("1800");
            cmbTimeout.Items.Add("2000");
            cmbTimeout.Text = timeout.ToString();
        }
        
         private delegate void ConnectedHandler(bool Connected);

         private void OnphoneConnectionChange(bool Connected)
         {
             lbl_phone_status.Text = "CONNECTED";
         }

         public void Comm_PhoneConnected(object sender, EventArgs e)
         {
             this.Invoke(new ConnectedHandler(OnphoneConnectionChange), new object[] { true });
         }
       
        

        public void Port_Configured()
        {
            ModemCommunication.Com_Port = SMS_Constant.Modem_Port;//Convert.ToInt32(cmbComPortNo.Text);
            ModemCommunication.Com_BaudRate = SMS_Constant.Modem_BraudRate;//Convert.ToInt32(cmbBaudRate.Text);
            ModemCommunication.Com_TimeOut = SMS_Constant.Modem_TimeOut;//Convert.ToInt32(cmbTimeout.Text);
            ModemCommunication.Initialization();           
        }
        private void SMSconnection()
        {
            try
            {
                Port_Configured();
                Phone_Connection();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //private void Phone_Connection()
        //{
        //    Port_Configured();
        //    ModemCommunication.gsObj.PhoneConnected += new EventHandler(Comm_PhoneConnected);
        //    Cursor.Current = Cursors.WaitCursor;
        //    bool retry;
        //    do
        //    {
        //        retry = false;
        //        try
        //        {
        //            Cursor.Current = Cursors.WaitCursor;
        //            ModemCommunication.Open();
        //            Cursor.Current = Cursors.Default;
        //        }
        //        catch (Exception)
        //        {
        //            Cursor.Current = Cursors.Default;
        //            if (MessageBox.Show(this, "Unable to open the port.", "Error",
        //                MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning) == DialogResult.Retry)
        //                retry = true;
        //            else
        //            {
        //                Close();
        //                return;
        //            }
        //        }
        //    }
        //    while (retry);

        //}
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
    


        private void btnTestConnect_Click(object sender, EventArgs e)
        {
            Port_Configured();                  
            Cursor.Current = Cursors.WaitCursor;
           
            try
            {
                
                ModemCommunication.Open();
                while (!ModemCommunication.IsConnected())
                {
                    Cursor.Current = Cursors.Default;
                    if (MessageBox.Show(this, "No Phone Connectd.", "Connected Setup", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation) == DialogResult.Cancel)
                    {
                        ModemCommunication.Close();
                        return;
                    }
                    Cursor.Current = Cursors.WaitCursor;
                }
                ModemCommunication.Close();

            }
            catch (Exception ex)
            {
                LogFile(ex.Message, e.ToString(), ((Control)sender).Name,  this.FindForm().Name);
                MessageBox.Show(this, "Connection error:" + ex.Message, "Connection Setup", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MessageBox.Show(this, "Successfully Connection to the phone.", "Connection Setup", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnConnect.Enabled = true;
        }
      

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnConnect.Text.ToUpper() == "CONNECT")
                {
                    
                        SMSconnection();
                        btnSendSMS.Enabled = false;
                        tmrSendSMS.Enabled = true;
                        btnConnect.Text = "DISCONNECT";
                        btnClose.Enabled = true;
                        lbl_phone_status.Text = "CONNECT";
                        btnReceivedSMS.Enabled = true;
                        btnSendSMS.Enabled = true;
                    
                }
                else
                {
                    btnConnect.Text = "CONNECT";
                    tmrSendSMS.Enabled = false;
                    btnClose.Enabled = true;
                    btnReceivedSMS.Enabled = true;
                    lbl_phone_status.Text = "DISCONNECT";
                    btnClose.Enabled = true;                   
                    ModemCommunication.Close();

                }

            }
            catch (Exception ex)
            {
                LogFile(ex.Message, e.ToString(), ((Control)sender).Name, this.FindForm().Name);               
            }
        }

        private void btnSendSMS_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                SMSSender objsender = new SMSSender();
                 //objsender.IPOConfirmationSMS();
                 objsender.SendPushPullSMS();
                 objsender.DayendTradeConfirmationSMS();
                 objsender.SendTradeConfirmationSMS();
                 objsender.DayendTradeConfirmationSMS();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                LogFile(ex.Message, e.ToString(), ((Control)sender).Name,  this.FindForm().Name);
            }
        }


        #region LogFile


       

        public void LogFile(string sExceptionName, string sModuleName, string sControlName, string sFormName)
        {
           
            string fileName = @"D:\logfile.txt";
            StreamWriter log;
            if (!File.Exists(fileName))
            {
                log = new StreamWriter(fileName);
            }
            else
            {
                log = File.AppendText(fileName);
            }            
            log.WriteLine(DateTime.Now + ("~") + sExceptionName + ("~") + sModuleName
                + ("~") + sControlName               
                + ("~") + sFormName);

            log.Close();
        }


        #endregion
        
        private void tmrSendSMS_Tick(object sender, EventArgs e)
        {
            //if (Convert.ToInt16(txtInterVal.Text) >= 1)
            ////if (Convert.ToInt16("5") >= 1) //Change
            //{
            //    Interval = Interval + 1;
            //}
            //if (Convert.ToInt16(txtInterVal.Text) == Interval)
            ////if (Convert.ToInt16("5") == Interval) //Change
            //{
            //    Interval = 0;
            //    tmrSendSMS.Enabled = false;
            //    btnSendSMS_Click(sender, e);
            //    btnReceivedSMS_Click(sender, e);
            //    tmrSendSMS.Enabled = true;
                
            //}
        }

        private void btnReceivedSMS_Click(object sender, EventArgs e)
        {
            try
            {              
               SMSReceiver rec = new SMSReceiver();               
               rec.Execute_ActionAgainstReceivedMessage();
            }
            catch (Exception ex)
            {
                LogFile(ex.Message, e.ToString(), ((Control)sender).Name, this.FindForm().Name);
            }
          
        }


      




        #region Received SMS
  
        private void MessageReceived()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ModemCommunication mdmObj = new ModemCommunication();
              
            }
            catch (Exception)
            {                
                throw;
            }

        }   
        

     
       

        #endregion  
        
        public static string Left(string param, int length)
        {
            string Result = param.Substring(0, length);
            return Result;
        }
        public static string Right(string param , int length)
        {
            string result = param.Substring(param.Length -length, length);
            return result;
        }
        public static string Mid(string param, int startIndex, int length)
        {
            string result = param.Substring(startIndex, length);           
            return result;
        }

        public static string Mid(string param, int startIndex)
        {
            string result = param.Substring(startIndex);           
            return result;
        }

       

      

       
    }
}
