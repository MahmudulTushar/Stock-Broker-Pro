using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GsmComm.PduConverter;
using System.Data;
using System.Text.RegularExpressions;


namespace ElectronicCommunication.SMS
{
   public  class MessageGenerate
    {       
      
       

       public static string IPORegErrorMessage(string Key)
       {
           string Message = string.Empty;
           DataSqlQuery data = new DataSqlQuery();
           string SMSCode = "SMS08";
           string sMessage = data.GetNotRegisterMessage(SMSCode);
           Message = sMessage.Replace("_", Key);
           return Message;

       }

       public static string ReplaceAll(string input, string[] words)
       {
           string wordlist = string.Join("|", words);
           Regex rx = new Regex(wordlist, RegexOptions.Compiled);
           return rx.Replace(input, m => "");
       }
       public static string  Get_SMSText_IPOSuccessfull(string[] CustCode)
       {
           DataSqlQuery data = new DataSqlQuery();
           string Message = string.Empty;
           string SMSCode = "SMS06";          
           string Cust_Code = string.Join(",", CustCode);
           string sMessage = data.GetNotRegisterMessage(SMSCode);
           Message = sMessage.Replace("_", Cust_Code);
           return Message;      
       }

       public static string Get_SMSText_IPOApproverSuccessFully(string[] CustCode,string CompanyShortName)
       { 
           DataSqlQuery data = new DataSqlQuery();
           string Message = string.Empty;
           string SMSCode = "SMS11";  
           string Cust_Code = string.Join(",", CustCode);
           string sMessage = data.GetNotRegisterMessage(SMSCode);
           Message = sMessage.Replace("_", Cust_Code);
           Message = Message.Replace("-", CompanyShortName);
           return Message;
       }

       public static string Get_SMSText_IPOResultProcessingMessage(string[] SuccessFullCustCode, string[] UnSuccessFullCustCode,string CompanyShortCode)
       {
           DataSqlQuery data = new DataSqlQuery();
           string Message = string.Empty;
           string SMSCode = "SMS12";
           string SuccessfullCust_Code = string.Join(",", SuccessFullCustCode);
           string UnSuccessCust_Code = string.Join(",", UnSuccessFullCustCode);
           string sMessage = data.GetNotRegisterMessage(SMSCode);
           Message = sMessage.Replace("_", SuccessfullCust_Code);
           Message = Message.Replace("-", UnSuccessCust_Code);
           Message = Message.Replace("~", CompanyShortCode);
           return Message;
       }

       public static string Get_IPODefaultMessage(String ReceiveMessage)
       {
           DataSqlQuery data = new DataSqlQuery();
           string message = string.Empty;
           List<string> CustCode = new List<string>();
           string SMSCode = "SMS03";
           string sMessage = data.GetNotRegisterMessage(SMSCode);

           var Company_Short_Code = data.GetIPOCompanyShortCodeSearch();
           string[] ArryCompanyShortCode = Company_Short_Code.ToArray();
           string FullIPOCompanyShortCode = string.Join(",", ArryCompanyShortCode);

           string[] Input_CustCode = null;
           var listtmp = new List<string>(Regex.Split(ReceiveMessage, @"\D+"));
           Input_CustCode = listtmp.Where(t => !string.IsNullOrEmpty(Convert.ToString(t))).ToArray();

           if (Input_CustCode.Length > 0)
           {
               int i = 0;
               foreach (string Value in Input_CustCode)
               {                   
                   CustCode.Add(Value);
                   i++;
                   if (i == 2)
                   {
                       break;
                   }
               }
           }
           string[] Cust_Code = CustCode.ToArray();
           String FinalCustCode = String.Join(",", Cust_Code);

           message = sMessage.Replace("_", FullIPOCompanyShortCode);
           message = message.Replace("102", FinalCustCode);

           if (Input_CustCode.Length > 1)
           {
               message = message.Replace("pIPO", "Pmipo");
               message = message.Replace("rIPO", "Pmtrade");
           }

           return message;
       }

     



    }
}
