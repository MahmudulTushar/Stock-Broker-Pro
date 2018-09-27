using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.Net.Mime;
using System.Threading;
using System.ComponentModel;
using System.Data;
using BusinessAccessLayer.BAL;
using BusinessAccessLayer.BO;
using BusinessAccessLayer.Constants;

namespace ElectronicCommunication.Email
{
   public class MessaGenerateAndSend
    {

       private struct MessaGenerateAndSendAAA
       {
           public EmailTradeConfirmation_NotificationBO MessageInfoBo;
           public MailMessage Mail;
       };

        private SmtpClient client;
        private MailAddress from;
        public MailMessage Mail;
        private List<MessaGenerateAndSendAAA> messagesObjs_tradeConfirm;

       

        public MessaGenerateAndSend()
        {
            try
            {
                SetUp_EmailClient();
                SetUp_From();
            }
            catch (Exception Ex) {throw new Exception(Ex.Message);  }
        }


        private void SetUp_EmailClient()
        {
            client = new SmtpClient("mail.gmail.com",587);
            //client.PortPort = 587,
            //client.EnableSsl= true,

            client.Credentials = new System.Net.NetworkCredential("rezaul0920@gmail.com", "01731186596");
            client.Timeout = 30000;
         }

        private void SetUp_From()
        {
            from = new MailAddress("rezaul0920@gmail.com",
                   "K-Securities",
                System.Text.Encoding.UTF8);
        }

        public void testing()
        {
            try
            {
               
                MailMessage message;

                MailAddress to = new MailAddress("rr80350@gmail.com");
                message = new MailMessage(from, to);

                message.Subject = "Trade Confirmation";
                message.SubjectEncoding = System.Text.Encoding.UTF8;
                message.IsBodyHtml = true;
                SetTradeConfirmationInfoBody_Master(message);
                MailMessage mmmm = SetTradeConfirmationInfoBody_Master(message);
                client.Send(mmmm);
            }
            catch (Exception ex)
            {                
                throw ex;
            }
           
            //Send_Message_TradeConfirmation();
        }


       





        private MailMessage SetTradeConfirmationInfoBody_Master(MailMessage message_dep)
        {
            try
            {

                string someArrows = new string(new char[] { '\u2190', '\u2191', '\u2192', '\u2193' });
                message_dep.Body = @"<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">
                                 <html xmlns=""http://www.w3.org/1999/xhtml"">
                                 <head>
                                 <meta http-equiv=""Content-Type"" content=""text/html; charset=iso-8859-1"" />
                                 </head>
                                  <body>
                                 <table width=""200"" border=""1"">
                                  <tr>
                                  <td>&nbsp;</td>
                                  <td>&nbsp;</td>
                                 <td>&nbsp;</td>
                                 <td>&nbsp;</td>
                                 <td>&nbsp;</td>
                                  </tr>
                                  </table>
                                  </body>
                                  </html>";

                // Include some non-ASCII characters in body and subject. 
                message_dep.Body += Environment.NewLine;// +someArrows;
                message_dep.BodyEncoding = System.Text.Encoding.UTF8;
                message_dep.IsBodyHtml = true;

                // messagesObjs_tradeConfirm.Add(new MessaGenerateAndSendAAA() { Mail = message_dep });
                //client.Send(message_dep);
                return message_dep;
            }
            catch (Exception ex)
            {                
                throw ex;
            }
          
        }



        public string[] Send_Message_TradeConfirmation()
        {
            string[] result = new string[2];
            int success = 0;
            int fail = 0;
            foreach (MessaGenerateAndSendAAA item in messagesObjs_tradeConfirm)
            {
                CCSBAL bal = new CCSBAL();
                CommonBAL comBal = new CommonBAL();
                Thread.Sleep(5000);
                try
                {
                    client.Timeout = 25000;
                    client.Send(item.Mail);

                   // bal.CCS_Email_NotificationSent(item.MessageInfoBo.Cust_Code, Indication_EmailNotification.Email_NotificationType_TradeConfirmation, "HTML Formatted Email", comBal.GetCurrentServerDate().ToShortDateString());
                    //success = success + 1;
                }
                catch (Exception ex)
                {
                    //bal.CCS_Email_NotificationFailure(item.MessageInfoBo.Cust_Code, Indication_EmailNotification.Email_NotificationType_TradeConfirmation, "HTML Formatted Email", comBal.GetCurrentServerDate().ToShortDateString(), ex.Message);
                    //fail = fail + 1;
                }
            }
            //result[0] = Convert.ToString(success);
            //result[1] = Convert.ToString(fail);

            return result;
        }

    }
}
