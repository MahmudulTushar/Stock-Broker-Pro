using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;
using System.IO;
using System.Data.SqlClient;
using BusinessAccessLayer.BO;
using ElectronicCommunication.SMS;
using DataAccessLayer;




namespace ElectronicCommunication.Email
{
   public class EmailSend
    {
       SqlDataQuery objDataQuery = new SqlDataQuery();
       EmailMessageGenerate objMessageGenerate = new EmailMessageGenerate();
       Double Amount = 0.0;
       

      

       public void IPOApproveConfirmationEmail()
       {
           string EmailCustCode = string.Empty;
           string IPOStatus = string.Empty;
           string IPOApplicationID = string.Empty;
           string IPOSessionID = string.Empty;
           string MoneyTransactiontype = string.Empty;
           string RefundTye = string.Empty;
           string EmailAddress = string.Empty;
           double Amount = 0.0;
           String CompanyName = string.Empty;
           try
           {
               

               string Conn = SMS_Constant.CallCenter_ConnectionString;//Email_Constant.CallCenter_ConnectionString;
               SqlConnection Connection = new SqlConnection(Conn);
               DataSet adataset = new DataSet();
               SqlDataAdapter aAqldataAdapter = new SqlDataAdapter();
               string Query = "Select Cust_Code,Email,IPO_Status,IPOApplicationID,IPO_Session_ID,MoneyTrans_TypeName,Refund_Name,Amount,Company_Name from tbl_IPOConfirmation_Email Where Status<>1";
               aAqldataAdapter.SelectCommand = new SqlCommand(Query, Connection);
               aAqldataAdapter.Fill(adataset);
               DataTable dt = new DataTable();
               dt = adataset.Tables[0];
               foreach (DataRow dr in dt.Rows)
               {
                   EmailCustCode = dr[0].ToString();
                   IPOStatus = dr[2].ToString();
                   IPOApplicationID = dr[3].ToString();
                   IPOSessionID = dr[4].ToString();
                   MoneyTransactiontype = dr[5].ToString();
                   RefundTye = dr[6].ToString();
                   EmailAddress = dr[1].ToString();
                   Amount=Convert.ToDouble(dr[7].ToString());
                   CompanyName = dr[8].ToString();

                   IPOApproveEmailSend(EmailCustCode,EmailAddress, IPOStatus ,IPOApplicationID,IPOSessionID,MoneyTransactiontype,RefundTye,Amount,CompanyName);                                  
               }              
           }
           catch (Exception)
           {
               throw;
           }           
       }



       public void IPOApproveEmailSend(string CustCode,string Email, string IPOStatus , string IPOApplicationID, string IPOSessionID ,string TransactionType , string RefundType,double Amount, String CompanyName)
       {

           //string CompanyName = objDataQuery.GetIPOCompanyName(IPOSessionID);
           string EmailAddress = Email;//objDataQuery.GetRegCustCodeFromCustCodeForEmail(CustCode);

           if (EmailAddress != "")
           {
             //-----------------  ParentChild Cheaking -----------------

               string ParentCode = objDataQuery.GetParentCheck(CustCode);
               List<string> ChildCode = new List<string>();
               if (ParentCode != "")
               {
                   ChildCode = objDataQuery.GetRegCustCodeFromParentChildCheakingForEmail(ParentCode);
               }

               if (ChildCode.Count > 0)
               {
                   string[] regChildCode = ChildCode.ToArray();

                   List<string> ApproveCustCodeList = new List<string>();
                   List<string> RejectCustCodeList = new List<string>();
                   List<string> SuccessfullCustCodeList = new List<string>();
                   List<String> UnSuccessfullyCustCodeList = new List<string>();

                   string ListApproveCustCode = string.Empty;
                   string ListRejectCustCode = string.Empty;
                   string ListSuccessfullCustCode = string.Empty;
                   string ListUnSuccessfullCustCode = string.Empty;
                  
                   int i = 0;                  
  
                   foreach (string Value in regChildCode)
                   {
                       
                       string Status = objDataQuery.GetIPOChildSystem(Value, IPOSessionID);

                       if (Status.ToLower() == ("Approved").ToLower())
                       {
                           //Amount = objDataQuery.GetIPOAmountForParentChlid(Value, IPOSessionID);
                           ApproveCustCodeList.Add(Value); 
                       }
                       else if (Status.ToLower() == ("Rejected").ToLower())
                       {
                           //Amount = objDataQuery.GetIPOAmountForParentChlid(Value, IPOSessionID);
                           RejectCustCodeList.Add(Value);                         
                       }
                       else if (Status.ToLower() == ("Successfull").ToLower())
                       {
                           //Amount = objDataQuery.GetIPOAmountForParentChlid(Value, IPOSessionID);
                           SuccessfullCustCodeList.Add(Value);                                                  
                       }
                       else if (Status.ToLower() == ("Unsuccessfull").ToLower())
                       {
                           //Amount = objDataQuery.GetIPOAmountForParentChlid(Value, IPOSessionID);
                           UnSuccessfullyCustCodeList.Add(Value);                          
                       }
                       i++;

                       if (Convert.ToString(regChildCode.Length) == Convert.ToString(i.ToString()))
                       {
                           string[] ArrayApproveCustCode = ApproveCustCodeList.ToArray();
                           ListApproveCustCode = string.Join(",", ArrayApproveCustCode);

                           string[] ArrayrejectCustCode = RejectCustCodeList.ToArray();
                           ListRejectCustCode = string.Join(",", ArrayrejectCustCode);

                           string[] ArraySuccessfullCustCode = SuccessfullCustCodeList.ToArray();
                           ListSuccessfullCustCode = string.Join(",", ArraySuccessfullCustCode);

                           string[] ArrayUnSuccessfullCustCode = UnSuccessfullyCustCodeList.ToArray();
                           ListUnSuccessfullCustCode = string.Join(",", ArrayUnSuccessfullCustCode);

                           if (ListSuccessfullCustCode != "" && ListUnSuccessfullCustCode != "" 
                              || ListSuccessfullCustCode =="" && ListUnSuccessfullCustCode !="" 
                               || ListSuccessfullCustCode !="" && ListUnSuccessfullCustCode =="")
                           {
                               string TotalCustCode = string.Empty;

                               if (ListSuccessfullCustCode != "" && ListUnSuccessfullCustCode !="")
                               {
                                   TotalCustCode = ListSuccessfullCustCode + "," + ListUnSuccessfullCustCode;
                               }
                               else if(ListSuccessfullCustCode == "")
                               {
                                   TotalCustCode = ListUnSuccessfullCustCode;
                               }
                               else if (ListUnSuccessfullCustCode == "")
                               {
                                   TotalCustCode = ListSuccessfullCustCode;
                               }
                               DataTable Data = new DataTable();
                               Data = objDataQuery.GetIPOApprove_RejectDegion(IPOSessionID, TotalCustCode);
                               string Text = objMessageGenerate.Successfull_Unsuccessfull_MessageIN_ParentChild(CompanyName,TotalCustCode, ListSuccessfullCustCode, ListUnSuccessfullCustCode, Data, Amount);
                               string Subject = "Regarding Result of IPO Lottery of " + CompanyName + ". You Applied ";
                               string Message = "Company Name :" + CompanyName + "Application ID :" + TotalCustCode + "Successful ID’s: " + ListSuccessfullCustCode + "Unsuccessful ID’s: " + ListUnSuccessfullCustCode
                                   + "  Application Price :" + Amount + " Applied Money form :" + TransactionType + " Refund to :" + RefundType;
                               EmailSendAAAA(EmailAddress, Subject, Text, TotalCustCode, IPOSessionID, Message);                              
                           }
                           else if (ListApproveCustCode != "" && ListRejectCustCode != ""
                              || ListApproveCustCode == "" && ListRejectCustCode != ""
                               || ListApproveCustCode != "" && ListRejectCustCode == "")
                           {                              
                               string TotalCustCode = string.Empty;
                               if (ListRejectCustCode != "" && ListApproveCustCode !="")
                               {
                                  TotalCustCode = ListApproveCustCode + "," + ListRejectCustCode;
                               }
                               else if(ListRejectCustCode =="")
                               {
                                   TotalCustCode = ListApproveCustCode;
                               }
                               else if (ListApproveCustCode == "")
                               {
                                   TotalCustCode = ListRejectCustCode;
                               }
                               DataTable Data = new DataTable();
                               Data = objDataQuery.GetIPOApprove_RejectDegion(IPOSessionID, TotalCustCode);
                               string Text = objMessageGenerate.Approve_Reject_MessageIN_ParentChild(CompanyName, ListApproveCustCode, ListRejectCustCode,Data,Amount);
                               string Message = "Company Name :" + CompanyName + "Application ID,s :" + ListApproveCustCode + " Reject ID : " + ListRejectCustCode + "  Application Price :" +
                                        Amount;
                               string Subject = "Status of Applications Made for the IPO- " +CompanyName;
                               EmailSendAAAA(EmailAddress, "IPo Info", Text, TotalCustCode, IPOSessionID, Message);
                           }
                       }
                   }

                   
               
               }
               else
               {
                   
                   if (IPOStatus.ToLower() == ("Approved").ToLower())
                   {
                       //string ToTalAmount = (Amount) //objDataQuery.GetIPOAmount(CustCode, IPOSessionID);
                       string Text = objMessageGenerate.Approve_Reject_Message(CompanyName, IPOStatus,CustCode,Amount,TransactionType,RefundType);
                       string Message = "Company Name :" + CompanyName + "Application ID :" +CustCode+ "  Application Price :"+
                                        Amount + " Applied Money form :" + TransactionType + " Refund to :" + RefundType;
                       EmailSendAAAA(EmailAddress, "Confirmation of Successful Application", Text, CustCode, IPOSessionID, Message);
                   }
                   else if (IPOStatus.ToLower() == ("Rejected").ToLower())
                   {
                       //string Amount = objDataQuery.GetIPOAmount(CustCode, IPOSessionID);
                       string Text = objMessageGenerate.Approve_Reject_Message(CompanyName, IPOStatus, CustCode, Amount, TransactionType, RefundType);
                       string Message = "Company Name :" + CompanyName + "Rejected ID :" + CustCode + "  Application Price :" +
                                       Amount + " Applied Money form :" + TransactionType + " Refund to :" + RefundType;
                       EmailSendAAAA(EmailAddress, "Application Rejected", Text, CustCode, IPOSessionID, Message);
                   }
                   else if (IPOStatus.ToLower() == ("Successfull").ToLower())
                   {
                       //string Amount = objDataQuery.GetIPOAmount(CustCode, IPOSessionID);
                       string Text = objMessageGenerate.Approve_Reject_Message(CompanyName, IPOStatus, CustCode, Amount, TransactionType, RefundType);
                       string Message = "Company Name :" + CompanyName + "Application ID :" + CustCode + " Successfull ID: " + CustCode + "  Application Price :" +
                                      Amount + " Applied Money form :" + TransactionType + " Refund to :" + RefundType;
                       string Subject = "Regarding Result of IPO Lottery of " + CompanyName + " . You Applied ";
                       EmailSendAAAA(EmailAddress, Subject, Text, CustCode, IPOSessionID, Message);
                   }
                   else if (IPOStatus.ToLower() == ("Unsuccessfull").ToLower())
                   {
                       //string Amount = objDataQuery.GetIPOAmount(CustCode, IPOSessionID);
                       string Text = objMessageGenerate.Approve_Reject_Message(CompanyName, IPOStatus, CustCode, Amount, TransactionType, RefundType);
                       string Message = "Company Name :" + CompanyName + "Application ID :" + CustCode + " Unsuccessfull ID: " + CustCode + "  Application Price :" +
                                      Amount + " Applied Money form :" + TransactionType + " Refund to :" + RefundType;
                       string Subject = "Regarding Result of IPO Lottery of "+CompanyName+". You Applied ";
                       EmailSendAAAA(EmailAddress, Subject, Text, CustCode, IPOSessionID, Message);
                   }
               }
  
            // ----------------  End ParentChild Cheaking --------------

           }
           else
           {
           }
       }


      



       public void EmailSendAAAA(string EmailAddress, string Subject, String Body, string CustCode, String IPOSessionID, String ShowMessage)
       {
           string senderID = "info@ksclbd.com";
           const string senderPassword = "@KSCL";

           try
           {
               SmtpClient smtp = new SmtpClient();
               smtp = new SmtpClient("mail.ksclbd.com", 25);
               smtp.Credentials = new System.Net.NetworkCredential(senderID, senderPassword);

               //SmtpClient smtp = new SmtpClient
               //{
               //    Host = "mail.ksclbd.com",
               //    Port = 25,
               //    EnableSsl = true,
               //    DeliveryMethod = SmtpDeliveryMethod.Network,
               //    Credentials = new System.Net.NetworkCredential(senderID, senderPassword),
               //    Timeout = 30000,
               //};
               MailAddress from = new MailAddress("info@ksclbd.com",
                   "K-Securities");
               MailAddress to = new MailAddress(EmailAddress);
               MailMessage message = new MailMessage(from,to);
               message.Subject = Subject;
               message.Body = Body;
               message.BodyEncoding = System.Text.Encoding.UTF8;
               message.IsBodyHtml = true;
               smtp.Send(message);

               String[] CustCodeArray = CustCode.Split(',');
               foreach (String value in CustCodeArray)
               {
                   objDataQuery.UpdateIPOEmailConfiramation(value, "1", IPOSessionID);
                   SendMessageloadConsolApplicationtDesign(value, EmailAddress, ShowMessage);                                   
               }
               IPOApproveConfirmationEmail();   
           }


           catch (Exception ex)
           {
               objDataQuery.UpdateIPOEmailConfiramationForFailureReason(CustCode, IPOSessionID, "2", ex.Message);               //throw ex;
              
           }
       }




       public void SendMessageloadConsolApplicationtDesign(string CustCode, string EmailAddress, string Message)
       {
           if (Message != "0")
           {
              // SMSCommadCode.S++;
           }

           Console.ForegroundColor = ConsoleColor.Yellow;
           Console.Write("Email Sent     : ");
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
           Console.Write(EmailAddress + "    ");


           string Messagelist = string.Empty;

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
                       Console.Write("\t\t\t\t\t" + Convert.ToString(value) + "\n");
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
           //Console.ForegroundColor = ConsoleColor.Yellow;
           //Console.WriteLine("\t\t\t\t\t" + "Message Send : " + SMSCommadCode.S);
       }


    }
}
