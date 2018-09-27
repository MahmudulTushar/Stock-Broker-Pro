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
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;



namespace ElectronicCommunication.Email
{
   public class EmailMessageGenerate
    {


      
       public string Approve_Reject_Message(string Name,string IPOStatus,string CustCode, double Amount, string MoneyTransactionType , String RefundType)
       {      
           string Message = string.Empty;
           #region Approve
           if (IPOStatus.ToLower() == ("Approved").ToLower())
           {
           Message = @"<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">
                     <html xmlns=""http://www.w3.org/1999/xhtml"">
                     <head>
                     <meta http-equiv=""Content-Type"" content=""text/html; charset=iso-8859-1"" />
                     </head>
                     <body>
                      Dear Sir ,<br />
                      Thanks for participating an IPO application of ”<p>" + Name + @"</p>”Regarding the IPO of the Company </br>
                      you are requested to applied application to following bellow-----<br /><br />
                      <p align=""center"">Application Summery of “<p>" + Name+ @"</p>”</p>
                      <table align=""center"" width=""692"" border=""1"" bordercolor=""#999999"">
                        <tr>
                      <td width=""147"" align=""center"" style=""background-color:#CCCCCC""><strong>No. of Application </strong></td>
                      <td width=""140"" align=""center"" style=""background-color:#CCCCCC""><strong> Per  Application price </strong></td>
                      <td width=""151"" align=""center"" style=""background-color:#CCCCCC""><strong>Total  Application price</strong></td>
                      <td width=""138"" align=""center"" style=""background-color:#CCCCCC""><strong>Applied  Money form</strong></td>
                      <td width=""125"" align=""center"" style=""background-color:#CCCCCC""><strong>Refund  to</strong></td>
                       </tr> 
                       <tr>
                      <td align=""center"">1</td>
                      <td align=""center"">" + Amount+@"</td>
                      <td align=""center"">"+Amount+@"</td>
                     <td align=""center"">"+MoneyTransactionType+@"</td>
                      <td align=""center"">"+RefundType+@"</td>
                       </tr>
                      
                      <tr>
                      <td align=""center"">Application  &nbsp;ID's</td>
                      <td colspan=""4"" align=""center"" style=""background-color:#CCCCCC"">" + CustCode + @"</td>
                       </tr>                       
                        </table><br /><br />

                           Thanks a lot for your valuable transaction. <br /><br />
                           K-Securities & Consultants Ltd (KSCL).<br /> 
                           www.ksclbd.com <br /><br /><br /><br />
                           This website's information is based on our actual record. If any of the above details look incorrect,<br />
                           please advise immediately. This is however possible but highly unlikely to find your record inaccurate or missing.<br />
                           This may happened due to malfunction of any/some of web tools that we use to collect and display your data here <br />
                           such as internet connectivity, FTP software, web server malfunction, problem with web database and others.<br /> 
                           We assure you that our master record of actual information is not affected by any of these.<br />

                       </body>
                       </html>
                    ";
           }
           #endregion

           #region Reject
           else if (IPOStatus.ToLower() == ("Rejected").ToLower())
           {
               Message = @"<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">
                     <html xmlns=""http://www.w3.org/1999/xhtml"">
                     <head>
                     <meta http-equiv=""Content-Type"" content=""text/html; charset=iso-8859-1"" />
                     </head>
                     <body>
                      Dear Sir ,<br />
                      Thanks for participating an IPO application of “<b>" + Name+ @"</b>”  Regarding the IPO of the Company </br>
                      you are requested to applied application to following bellow----<br /><br />
                      <p align=""center"">Application Summery of “<b>" + Name+ @"</b>”</p>
                      <table align=""center"" width=""692"" border=""1"" bordercolor=""#999999"">
                        <tr>
                      <td width=""147"" align=""center"" style=""background-color:#CCCCCC""><strong>No. of Application </strong></td>
                      <td width=""140"" align=""center"" style=""background-color:#CCCCCC""><strong> Per  Application price </strong></td>
                      <td width=""151"" align=""center"" style=""background-color:#CCCCCC""><strong>Total  Application price</strong></td>
                      <td width=""138"" align=""center"" style=""background-color:#CCCCCC""><strong>Applied  Money form</strong></td>
                      <td width=""125"" align=""center"" style=""background-color:#CCCCCC""><strong>Refund  to</strong></td>
                       </tr> 
                       <tr>
                      <td align=""center"">1</td>
                      <td align=""center"">" + Amount + @"</td>
                      <td align=""center"">" + Amount + @"</td>
                     <td align=""center"">" + MoneyTransactionType + @"</td>
                      <td align=""center"">" + RefundType + @"</td>
                       </tr>                                           
                        <tr>
                        <td align=""center"">Reject&nbsp;ID's</td>
                        <td colspan=""4"" align=""center"" style=""background-color:#CCCCCC""> " + CustCode + @"</td>
                        </tr>
                        </table><br /><br />

                           Thanks a lot for your valuable transaction. <br /><br />
                           K-Securities & Consultants Ltd (KSCL).<br /> 
                           www.ksclbd.com <br /><br /><br /><br />
                           This website's information is based on our actual record. If any of the above details look incorrect,<br />
                           please advise immediately. This is however possible but highly unlikely to find your record inaccurate or missing.<br />
                           This may happened due to malfunction of any/some of web tools that we use to collect and display your data here <br />
                           such as internet connectivity, FTP software, web server malfunction, problem with web database and others.<br /> 
                           We assure you that our master record of actual information is not affected by any of these.<br />

                       </body>
                       </html>
                    ";
           }
           #endregion

           #region Successful
           else if (IPOStatus.ToLower() == ("Successfull").ToLower())
           {
               Message = @"<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">
                     <html xmlns=""http://www.w3.org/1999/xhtml"">
                     <head>
                     <meta http-equiv=""Content-Type"" content=""text/html; charset=iso-8859-1"" />
                     </head>
                     <body>
                      Dear Sir ,<br />
                      Thanks for participating an IPO application of “<b>" + Name + @"</b>”  Regarding the IPO of the Company </br>
                     you are requested to applied application to following bellow---<br /><br /><br />
                      <p align=""center"">Application Summery of “<b>" + Name + @"</b>”</p>
                      <table align=""center"" width=""692"" border=""1"" bordercolor=""#999999"">
                        <tr>
                      <td width=""147"" align=""center"" style=""background-color:#CCCCCC""><strong>No. of Application </strong></td>
                      <td width=""140"" align=""center"" style=""background-color:#CCCCCC""><strong> Per  Application price </strong></td>
                      <td width=""151"" align=""center"" style=""background-color:#CCCCCC""><strong>Total  Application price</strong></td>
                      <td width=""138"" align=""center"" style=""background-color:#CCCCCC""><strong>Applied  Money form</strong></td>
                      <td width=""125"" align=""center"" style=""background-color:#CCCCCC""><strong>Refund  to</strong></td>
                       </tr> 
                       <tr>
                      <td align=""center"">1</td>
                      <td align=""center"">" + Amount + @"</td>
                      <td align=""center"">" + Amount + @"</td>
                     <td align=""center"">" + MoneyTransactionType + @"</td>
                      <td align=""center"">" + RefundType + @"</td>
                       </tr>                                           
                        <tr>
                        <td align=""center"">Application  &nbsp;ID's</td>
                        <td colspan=""4"" align=""center"" style=""background-color:#CCCCCC""> " + CustCode + @"</td>
                        </tr>
                         <tr>
                        <td align=""center"">Successful  ID&rsquo;s</td>
                        <td colspan=""4"" align=""center"" style=""background-color:#CCCCCC""> " + CustCode + @"</td>
                        </tr>
                        </table><br /><br />

                           Thanks a lot for your valuable transaction. <br /><br />
                           K-Securities & Consultants Ltd (KSCL).<br /> 
                           www.ksclbd.com <br /><br /><br /><br />
                           This website's information is based on our actual record. If any of the above details look incorrect,<br />
                           please advise immediately. This is however possible but highly unlikely to find your record inaccurate or missing.<br />
                           This may happened due to malfunction of any/some of web tools that we use to collect and display your data here <br />
                           such as internet connectivity, FTP software, web server malfunction, problem with web database and others.<br /> 
                           We assure you that our master record of actual information is not affected by any of these.<br />

                       </body>
                       </html>
                    ";
           }
           #endregion

           #region UnSuccessful
           else if (IPOStatus.ToLower() == ("Unsuccessfull").ToLower())
           {
               Message = @"<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">
                     <html xmlns=""http://www.w3.org/1999/xhtml"">
                     <head>
                     <meta http-equiv=""Content-Type"" content=""text/html; charset=iso-8859-1"" />
                     </head>
                     <body>
                      Dear Sir ,<br /><br />
                      Thanks for participating an IPO application of “<b>" + Name + @"</b>”  Regarding the IPO of the Company </br>
                      you are requested to applied application to following bellow---<br /><br /><br />
                      <p align=""center"">Application Summery of “<b>" + Name + @"<b>”</p>
                      <table align=""center"" width=""692"" border=""1"" bordercolor=""#999999"">
                        <tr>
                      <td width=""147"" align=""center"" style=""background-color:#CCCCCC""><strong>No. of Application </strong></td>
                      <td width=""140"" align=""center"" style=""background-color:#CCCCCC""><strong> Per  Application price </strong></td>
                      <td width=""151"" align=""center"" style=""background-color:#CCCCCC""><strong>Total  Application price</strong></td>
                      <td width=""138"" align=""center"" style=""background-color:#CCCCCC""><strong>Applied  Money form</strong></td>
                      <td width=""125"" align=""center"" style=""background-color:#CCCCCC""><strong>Refund  to</strong></td>
                       </tr> 
                       <tr>
                      <td align=""center"" style=""background-color:#CCCCCC"">1</td>
                      <td align=""center"">" + Amount + @"</td>
                      <td align=""center"">" + Amount + @"</td>
                     <td align=""center"">" + MoneyTransactionType + @"</td>
                      <td align=""center"">" + RefundType + @"</td>
                       </tr>                                           
                       <tr>
                        <td align=""center"" style=""background-color:#CCCCCC"">Application  &nbsp;ID's</td>
                        <td colspan=""4"" align=""center""> " + CustCode + @"</td>
                        </tr>
                         <tr>
                        <td align=""center"" style=""background-color:#CCCCCC"">Unsuccessful  ID&rsquo;s</td>
                        <td colspan=""4"" align=""center"" > " + CustCode + @"</td>
                        </tr>
                        </table><br /><br />

                           Thanks a lot for your valuable transaction. <br /><br />
                           K-Securities & Consultants Ltd (KSCL).<br /> 
                           www.ksclbd.com <br /><br /><br /><br />
                           This website's information is based on our actual record. If any of the above details look incorrect,<br />
                           please advise immediately. This is however possible but highly unlikely to find your record inaccurate or missing.<br />
                           This may happened due to malfunction of any/some of web tools that we use to collect and display your data here <br />
                           such as internet connectivity, FTP software, web server malfunction, problem with web database and others.<br /> 
                           We assure you that our master record of actual information is not affected by any of these.<br />
                       </body>
                       </html>
                    ";
           }
           #endregion          

           return Message;
       }


       public string Successfull_Unsuccessfull_MessageIN_ParentChild(string Name,string TotalCustCode, string Successfull, string Unsuccessfull, DataTable Data, Double Amount) 
        {
          string result = string.Empty;

          string[] SuccessfullArray = Successfull.Split(',');
          string[] UNSuccessfullArray = Unsuccessfull.Split(',');
          int A = 0;
          int U = 0;
          foreach (string Value in SuccessfullArray)
          {
              if (Value != "")
              {
                  A++;
              }
          }
          foreach (string Value in UNSuccessfullArray)
          {
              if (Value != "")
              {
                  U++;
              }             
          }

          {
              result = @"<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">
                     <html xmlns=""http://www.w3.org/1999/xhtml"">
                     <head>
                     <meta http-equiv=""Content-Type"" content=""text/html; charset=iso-8859-1"" />
                     </head>
                     <body>
                      Dear Sir ,<br />
                      Thanks for participating an IPO application of “<b>" + Name + @"</b>”  Regarding the IPO of the Company </br>
                      you have been applied application. The Successful & Unsuccessful result to following bellow---<br /><br />
                      <p align=""center"">Application Summery of “<b>" + Name + @"</b>”</p>
                      <table align=""center"" width=""692"" border=""1"" bordercolor=""#999999"">
                        <tr>
                      <td width=""147"" align=""center"" style=""background-color:#CCCCCC""><strong>No. of Application </strong></td>
                      <td width=""140"" align=""center"" style=""background-color:#CCCCCC""><strong> Per  Application price </strong></td>
                      <td width=""151"" align=""center"" style=""background-color:#CCCCCC""><strong>Total  Application price</strong></td>
                      <td width=""138"" align=""center"" style=""background-color:#CCCCCC""><strong>Applied  Money form</strong></td>
                      <td width=""125"" align=""center"" style=""background-color:#CCCCCC""><strong>Refund  to</strong></td>
                       </tr>"
                        + CreateTable(Data,Amount) +
                        @"<tr>
                        <td align=""center"" style=""background-color:#CCCCCC"">Application  &nbsp;ID's</td>
                        <td colspan=""4"" align=""center""> " + TotalCustCode + @"</td>
                        </tr>
                         <tr>
                        <td align=""center"" style=""background-color:#CCCCCC"">Successful  ID&rsquo;s</td>
                        <td colspan=""4"" align=""center"" > " + Successfull + @"  Count : " + A + @"</td>
                        </tr>
                         <tr>
                          <td align=""center"" style=""background-color:#CCCCCC"">Unsuccessful  ID&rsquo;s</td>
                         <td colspan=""4"" align=""center""> " + Unsuccessfull + @"  Count : " +U+ @"</td>
                        </tr>
                        </table><br /><br />

                           Thanks a lot for your valuable transaction. <br /><br />
                           K-Securities & Consultants Ltd (KSCL).<br /> 
                           www.ksclbd.com <br /><br /><br /><br />
                           This website's information is based on our actual record. If any of the above details look incorrect,<br />
                           please advise immediately. This is however possible but highly unlikely to find your record inaccurate or missing.<br />
                           This may happened due to malfunction of any/some of web tools that we use to collect and display your data here <br />
                           such as internet connectivity, FTP software, web server malfunction, problem with web database and others.<br /> 
                           We assure you that our master record of actual information is not affected by any of these.<br />

                       </body>
                       </html>
                    ";
          }
          return result;
      }




       public string Approve_Reject_MessageIN_ParentChild(string Name,string ApproveCustCode, string RejectCustCode, DataTable Data, Double Amount)
       {
           string result = string.Empty;

          
           {
               result = @"<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">
                     <html xmlns=""http://www.w3.org/1999/xhtml"">
                     <head>
                     <meta http-equiv=""Content-Type"" content=""text/html; charset=iso-8859-1"" />
                     </head>
                     <body>
                      Dear Sir ,</br>
                      Thanks for participating an IPO application of “" + Name + @"”  Regarding the IPO of the Company </br>
                      you are requested to applied application to following bellow--------</br></br>
                      <p align=""center"">Application Summery of “" + Name + @"”</p>
                      <table align=""center"" width=""692"" border=""1"" bordercolor=""#999999"">
                        <tr>
                      <td width=""147"" align=""center"" style=""background-color:#CCCCCC""><strong>No. of Application </strong></td>
                      <td width=""140"" align=""center"" style=""background-color:#CCCCCC""><strong> Per  Application price </strong></td>
                      <td width=""151"" align=""center"" style=""background-color:#CCCCCC""><strong>Total  Application price</strong></td>
                      <td width=""138"" align=""center"" style=""background-color:#CCCCCC""><strong>Applied  Money form</strong></td>
                      <td width=""125"" align=""center"" style=""background-color:#CCCCCC""><strong>Refund  to</strong>
                      </td>"
                       + CreateTable(Data,Amount) +                      
                     @"
                     <tr>
                    <td align=""center"">Application  &nbsp;ID's</td>
                    <td colspan=""4"" align=""center"" style=""background-color:#CCCCCC"">" + ApproveCustCode + @"</td>
                    </tr>
                     <tr>
                     <td align=""center"">Reject&nbsp;ID's</td>
                      <td colspan=""4"" align=""center"" style=""background-color:#CCCCCC"">" + RejectCustCode + @"</td>
                     </tr>                        
                        </table>

                       </body>
                       </html>
                    ";
           }
           return result;
       }  



       public string CreateTable(DataTable data,Double Amount)
       {
            string result = string.Empty;            
            List<string> Value = new List<string>();       


            foreach (DataRow dr in data.Rows)
             {
                 Double TotalAmount = 0.00;
                 string Count = dr[0].ToString();
                 TotalAmount = Amount * Convert.ToDouble(Count);
                 result = @"<tr>
                     <td align=""center"" style=""background-color:#CCCCCC"">" + dr[0].ToString() + @"</td>
                     <td align=""center"">" + (Amount.ToString("0.00")) + @"</td>
                     <td align=""center"">" + TotalAmount.ToString("0.00") + @"</td>
                     <td align=""center"">" + dr[1].ToString() + @"</td>
                     <td align=""center"">" + dr[2].ToString() + @"</td>
                     </tr>";                
                 Value.Add(result);                 
            }
           string[] ResultArray = Value.ToArray();
           result = String.Join("", ResultArray);          
           return result;           
        }


       public string CreateTableForSuccessfullAndUnSuccessfull(DataTable data, long Amount)
       {
           string result = string.Empty;
           string Design = string.Empty;
           List<string> Value = new List<string>();
           List<string> listDesign = new List<string>();


           foreach (DataRow dr in data.Rows)
           {
               long TotalAmount = 0;
               string Count = dr[0].ToString();
               TotalAmount = Amount * Convert.ToInt32(Count);
               result = @"<tr>
                     <td align=""center"">" + dr[0].ToString() + @"</td>
                     <td align=""center"">" + (Amount) + @"</td>
                     <td align=""center"">" + TotalAmount + @"</td>
                     <td align=""center"">" + dr[1].ToString() + @"</td>
                     <td align=""center"">" + dr[2].ToString() + @"</td>
                     </tr>";

               Design = "No. of Application " +dr[0].ToString()+"Per Application price " + Amount + "Applied Money form "
                        + dr[1].ToString() + "Refund to :" + dr[2].ToString();
               Value.Add(result);
               listDesign.Add(Design);
           }
           string[] ResultArray = Value.ToArray();
           result = String.Join("", ResultArray);
           string[] DesignArray = listDesign.ToArray();
           Design = string.Join(",  ", DesignArray);
           ConsoleApplication_MessageGenerate(Design);
           return result;
       }
       public string ConsoleApplication_MessageGenerate(string Code)
       {
           string result = string.Empty;
           result = Code;
           return result;
       }

    }
}
