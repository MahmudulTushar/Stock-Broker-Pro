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

namespace ElectronicCommunication
{
    public class EmailClient
    {
        private struct MessageObject_MoneyTran
        {
            public EmailMonetyTrans_NotificationBO MessageInfoBo;
            public MailMessage Mail;
        };
        private struct MessageObject_TradeConfirm
        {
            public EmailTradeConfirmation_NotificationBO MessageInfoBo;
            public MailMessage Mail;
        };
        private SmtpClient client;
        private MailAddress from;
        private List<MessageObject_MoneyTran> messagesObjs_moneyTrans;
        private List<MessageObject_TradeConfirm> messagesObjs_tradeConfirm;

        public EmailClient()
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
            client = new SmtpClient("mail.ksclbd.com", 25);
            client.Credentials = new System.Net.NetworkCredential("info@ksclbd.com","@KSCL");
        }

        private void SetUp_From()
        {
            from = new MailAddress("info@ksclbd.com",
                   "K-Securities",
                System.Text.Encoding.UTF8);
        }
             
        public void SetMessages_MoneyTrans()
        {
            DataTable dt = new DataTable();
            CCSBAL bal=new CCSBAL();
            messagesObjs_moneyTrans = new List<MessageObject_MoneyTran>();
            dt = bal.CCS_GetTemp_MoneyTransactionForEmail_ForSending();
          
            foreach (DataRow dr in dt.Rows)
            {
                double doubleTryParse;
                int intTryParse;
                MailAddress to = new MailAddress(dr["Email"].ToString());
                MailMessage message_dep = new MailMessage(from, to);
                EmailMonetyTrans_NotificationBO bo = new EmailMonetyTrans_NotificationBO();
                bo.Cust_Code = dr["Cust_Code"].ToString();
                bo.Entry_Branch_Name = (dr["Branch_Name"].ToString() == Indication_BrokerBranch.HeadOffice) ? (dr["Branch_Name"].ToString()) : (dr["Branch_Name"].ToString() + " Branch");
                bo.VoucherNo = dr["VoucherNo"].ToString();
                bo.ChequekBank = dr["ChequekBank"].ToString();
                bo.ChequeBranch=dr["ChequeBranch"].ToString();
                bo.Payment_Media_No=dr["Payment_Media_No"].ToString();
                bo.Payment_Media=dr["Payment_Media"].ToString();
                bo.Deposit_Withdraw = dr["Deposit_Withdraw"].ToString();
                bo.TransReason = dr["TransReason"].ToString();
                bo.CollectionBranch = (dr["CollectionBranch"].ToString()==Indication_BrokerBranch.HeadOffice)?(dr["CollectionBranch"].ToString()):(dr["CollectionBranch"].ToString()+" Branch");
                bo.ReferenceNo = Convert.ToInt32(dr["ReferenceNo"].ToString());
                double TransactionAmount=0.00;
                if(double.TryParse( dr["Amount"].ToString(),out doubleTryParse))
                    bo.Amount=doubleTryParse;
                double CurrentBalance=0.00;
                if(double.TryParse(dr["Money_Balance"].ToString(),out doubleTryParse))
                    bo.Money_Balance = doubleTryParse;

                if (bo.Deposit_Withdraw == "Deposit")
                {
                    message_dep = SetMoneyDepositInfoBody(message_dep,bo);
                    messagesObjs_moneyTrans.Add(new MessageObject_MoneyTran() { MessageInfoBo = bo, Mail = message_dep });                   
                }
                else if (bo.Deposit_Withdraw == "Withdraw")
                {
                    message_dep = SetMoneyWithdrawInfoBody(message_dep,bo);
                    messagesObjs_moneyTrans.Add(new MessageObject_MoneyTran() { MessageInfoBo = bo, Mail = message_dep });                 
                }
            }
           
        }

        public void SetMessages_TradeConfirmation()
        {
            DataTable dt_Master = new DataTable();
            DataTable dt_Details = new DataTable();
           
            CCSBAL bal = new CCSBAL();
            MailMessage message;
            messagesObjs_tradeConfirm = new List<MessageObject_TradeConfirm>();
            dt_Master = bal.CCS_GetTemp_EmailTradeConfirmation_Master();
            
            if (dt_Master.Rows.Count > 0)
            {
                foreach (DataRow drM in dt_Master.Rows)
                {
                    MailAddress to = new MailAddress(drM["Email"].ToString());
                    message = new MailMessage(from, to);

                    message.Subject = "Trade Confirmation";
                    message.SubjectEncoding = System.Text.Encoding.UTF8;
                    message.IsBodyHtml = true;

                    EmailTradeConfirmation_NotificationBO bo = new EmailTradeConfirmation_NotificationBO();
                    bo.Cust_Code = drM["Cust_Code"].ToString();
                    bo.Cust_Name = drM["Cust_Name"].ToString();
                    bo.Trade_Date = Convert.ToDateTime(drM["Trade_Date"].ToString());
                    bo.Interest = Convert.ToDouble(drM["Interest"].ToString());
                    bo.Pre_Balance = Convert.ToDouble(drM["Pre_Balance"].ToString());
                    bo.TotalOnBuyTotal = Convert.ToDouble(drM["TotalOnBuyTotal"].ToString());
                    bo.TotalOnSellToal = Convert.ToDouble(drM["TotalOnSellTotal"].ToString());
                    bo.TotalOnBalance = Convert.ToDouble(drM["TotalOnBalance"].ToString());
                    bo.TotalOnAmount = Convert.ToDouble(drM["TotalOnAmount"].ToString());
                    bo.TotalOnCommission=Convert.ToDouble(drM["TotalOnCommission"].ToString());
                    bo.TotalOnPayable = Convert.ToDouble(drM["TotalPayable"].ToString());
                    bo.CurrentBalance = Convert.ToDouble(drM["CurrentBalance"].ToString());

                    SetTradeConfirmationInfoBody_Master(message, bo);

                    //Details Executed As Nested
                    dt_Details = bal.CCS_GetTemp_EmailTradeConfirmation_Detials(bo.Cust_Code);
                    if (dt_Details.Rows.Count > 0)
                    {
                        List<EmailTradeConfirmation_NotificationBO> bo_details_List = new List<EmailTradeConfirmation_NotificationBO>();

                        foreach (DataRow dr in dt_Details.Rows)
                        {
                            EmailTradeConfirmation_NotificationBO bo_detais = new EmailTradeConfirmation_NotificationBO();

                            bo_detais.Comp_Short_Code = dr["Comp_Short_Code"].ToString();
                            bo_detais.Buy_Qty = Convert.ToInt32(dr["Buy_Qty"].ToString());
                            bo_detais.Buy_Avg = Convert.ToDouble(dr["Buy_Avg"].ToString());
                            bo_detais.Buy_Total = Convert.ToDouble(dr["Buy_Total"].ToString());
                            bo_detais.Sell_Qty = Convert.ToInt32(dr["Sell_Qty"].ToString());
                            bo_detais.Sell_Avg = Convert.ToDouble(dr["Sell_Avg"].ToString());
                            bo_detais.Sell_Total = Convert.ToDouble(dr["Sell_Total"].ToString());
                            bo_detais.Balance = Convert.ToDouble(dr["Balance"].ToString());
                            bo_detais.Amount = Convert.ToDouble(dr["Amount"].ToString());
                            bo_detais.Commission = Convert.ToDouble(dr["Commission"].ToString());

                            bo_details_List.Add(bo_detais);
                        }
                        SetTradeConfirmationInfoBody_Details(message, bo_details_List);
                    }

                    //Footer Executed
                    SetTradeConfirmationInfoBody_Footer(message, bo);

                    messagesObjs_tradeConfirm.Add(new MessageObject_TradeConfirm() { Mail = message, MessageInfoBo = bo });
                }
            }
        }

        private MailMessage SetTradeConfirmationInfoBody_Master(MailMessage message_dep,EmailTradeConfirmation_NotificationBO bo)
        {
            string someArrows = new string(new char[] { '\u2190', '\u2191', '\u2192', '\u2193' });
            message_dep.Body = @"<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">
                            <html xmlns=""http://www.w3.org/1999/xhtml"">
                            <head>
                            <meta http-equiv=""Content-Type"" content=""text/html; charset=iso-8859-1"" />
                            <title>Untitled Document</title>
                            <style type=""text/css"">
                            <!--
                            .style7 {font-family: ""Times New Roman"", Times, serif}
                            .style9 {font-family: ""Times New Roman"", Times, serif; font-weight: bold; }
                            .style13 {font-weight: bold; font-size: 29px;}
                            .style14 {font-weight: bold; font-size: 22px}
                            .style15 {font-size: small}
                            -->
                            </style>
                            </head>

                            <body>
                            <table width=""732"" border=""0"">
                              <tr>
                                <td height=""34"" valign=""bottom"" ><strong style=""font-size: 26px;"">K-Securities &amp; Consultants Ltd. </strong></td>
                              </tr>
                              <tr>
                                <td><span class=""style15"">Head Office: Suite #604 (5th Floor), 158-160, Motijheel C/A,  </span></td>
                              </tr>
                              <tr >
                                <td align=""left"" valign=""top"" ><span class=""style15"">Modhumita Building, Dhaka-1000.</span> <a href=""http://www.ksclbd.com"">www.ksclbd.com
                                <hr></a></td>
                              </tr>
                              <tr>
                                <td>&nbsp;</td>
                              </tr>
                            </table>
                            <table width=""732"" border=""0"">
                              <tr>
                                <td align=""center""><span class=""style14""><strong style=""font-size: 20px;"">TRADE CONFIRMATION</strong></span></td>
                              </tr>
                            </table>
                            <p>&nbsp;</p>
                            <table width=""732"" border=""0"">
                              <tr>
                                <th width=""89"" align=""left"" valign=""top"">Cust Code</th>
                                <th width=""18"" align=""center"" valign=""top""><strong>:</strong></th>
                                <th width=""590"" align=""left"" valign=""top""><div align=""left""> " + bo.Cust_Code+@" </div></th>
                              </tr>
                              <tr>
                                <th width=""89"" align=""left"" valign=""top"">Name</th>
                                <th width=""18"" align=""center"" valign=""top""><strong>: </strong></th>
                                <th width=""590"" align=""left"" valign=""top""><div align=""left""> "+bo.Cust_Name+@" </div></th>
                              </tr>
                              <tr>
                                <th align=""left"" valign=""top"">Trade Trade</th>
                                <th align=""center"" valign=""top""><strong>: </strong></th>
                                <th align=""left"" valign=""top""><div align=""left""> "+bo.Trade_Date.ToShortDateString()+@" </div></th>
                              </tr>
                              <tr>
                                <th align=""left"" valign=""top"">&nbsp;</th>
                                <th align=""center"" valign=""top"">&nbsp;</th>
                                <th align=""left"" valign=""top"">&nbsp;</th>
                              </tr>
                            </table>
                            <table width=""732"" border=""2"">
                              <tr>
                                <th width=""73"" rowspan=""2"" align=""center"" bgcolor=""#CCCCCC""><span class=""style7"">Instrument Name</span></th>
                                <th colspan=""3"" align=""center"" bgcolor=""#CCCCCC""><span class=""style7"">Buy</span></th>
                                <th colspan=""3"" align=""center"" bgcolor=""#CCCCCC""><span class=""style7"">Sell</span></th>
                                <th colspan=""3"" align=""center"" bgcolor=""#CCCCCC""><span class=""style7"">Balance</span></th>
                              </tr>
                              <tr>
                                <th width=""53"" align=""center""><span class=""style7"">Qty</span></th>
                                <th width=""53"" align=""center""><span class=""style7"">Avg</span></th>
                                <th width=""67"" align=""center""><span class=""style7"">Amount</span></th>
                                <th width=""53"" align=""center""><span class=""style7"">Qty</span></th>
                                <th width=""53"" align=""center""><span class=""style7"">Avg</span></th>
                                <th width=""67"" align=""center""><span class=""style7"">Amount</span></th>
                                <th width=""53"" align=""center""><span class=""style7"">Qty</span></th>
                                <th width=""53"" align=""center""><span class=""style7""> Amount</span></th>
                                <th width=""67"" align=""center""><span class=""style7"">Comm.</span></th>
                              </tr>";

            // Include some non-ASCII characters in body and subject. 
            message_dep.Body += Environment.NewLine;// +someArrows;
            message_dep.BodyEncoding = System.Text.Encoding.UTF8;
            return message_dep;
        }

        private MailMessage SetTradeConfirmationInfoBody_Footer(MailMessage message_dep, EmailTradeConfirmation_NotificationBO bo)
        {
            string someArrows = new string(new char[] { '\u2190', '\u2191', '\u2192', '\u2193' });
            
                message_dep.Body = message_dep.Body+
                            @"<tr>
                                <td>&nbsp;</td>
                                <td colspan=""3"" align=""right""><span class=""style9"">"+bo.TotalOnBuyTotal.ToString("0.00")+@"</span></td>
                                <td colspan=""3"" align=""right""><span class=""style9"">" + bo.TotalOnSellToal.ToString("0.00") + @"</span></td>
                                <td colspan=""2"" align=""right""><span class=""style9"">" + bo.TotalOnAmount.ToString("0.00") + @"</span></td>
                                <td align=""right""><span class=""style9"">" + bo.TotalOnCommission.ToString("0.00") + @"</span></td>
                              </tr>
                            </table>
                            <table width=""732"" border=""0"">
                              <tr>
                                <td>&nbsp;</td>
                              </tr>
                              <tr>
                                <td>&nbsp;</td>
                              </tr>
                            </table>
                            <table width=""732"" border=""0"" bgcolor=""#CCCCCC"">
                              <tr>
                                <td width=""110""><strong>Interest Charge</strong></td>
                                <td width=""8"" align=""center""><strong>:</strong></td>
                                <td width=""94"" align=""right""><strong>" + bo.Interest.ToString("0.00") + @" </strong></td>
                                <td width=""80"" align=""left"">&nbsp;</td>
                                <td width=""289"" align=""left""> Ledger Balance Before Trading (" +bo.Trade_Date.ToShortDateString()+@")</td>
                                <td width=""114"" align=""right""> " + bo.Pre_Balance.ToString("0.00") + @" </td>
                              </tr>
                              <tr>
                                <td><strong>Amount Payable</strong></td>
                                <td align=""center""><strong>:</strong></td>
                                <td align=""right""><strong>  " + bo.TotalOnPayable.ToString("0.00") + @" </strong></td>
                                <td>&nbsp;</td>
                                <td>Net Amount Of Trading </td>
                                <td align=""right"">" + bo.TotalOnPayable.ToString("0.00") + @" </td>
                              </tr>
                              <tr>
                                <td>&nbsp;</td>
                                <td align=""center"">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td><strong>Current Ledger Balance </strong></td>
                                <td align=""right""><strong>" + bo.CurrentBalance.ToString("0.00") + @" </strong></td>
                              </tr>
                            </table>
                            <blockquote>
                              <p>&nbsp;</p>
                            </blockquote>
                            <table width=""280"" border=""0"">
                              <tr>
                                <td width=""274"">Thanks  a lot for your valuable  transaction. </td>
                              </tr>
                              <tr>
                                <td>&nbsp;</td>
                              </tr>
                              <tr>
                                <td><p>K-Securities &amp; Consultants ltd.<br />
                                </p></td>
                              </tr>
                              <tr>
                                <td></td>
                              </tr>
                              <tr>
                                <td>This website's information are based on our actual record.  If any of the above details look incorrect, please advise immediately. This is however possible but highly unlikely to find your record inaccurate or missing. This may happened due to malfunction of any/some of web tools that we use to collect and display your data here such as internet connectivity, FTP software, web server malfunction,  problem with web database and others. We assure you that our master record of actual information is not affected by any of these.</td>
                              </tr>   
                            </table>
                            <blockquote>
                              <p>&nbsp;</p>
                            </blockquote>
                            </body>
                            </html>";

              
            message_dep.BodyEncoding = System.Text.Encoding.UTF8;
            return message_dep;
        }
        private MailMessage SetTradeConfirmationInfoBody_Details(MailMessage message_dep, List<EmailTradeConfirmation_NotificationBO> boList)
        {
            string someArrows = new string(new char[] { '\u2190', '\u2191', '\u2192', '\u2193' });

            foreach (EmailTradeConfirmation_NotificationBO item in boList)
            {
                message_dep.Body = message_dep.Body + @"<tr>
                                                    <td>"+item.Comp_Short_Code+@"</td>
                                                    <td align=""right"">" + item.Buy_Qty + @"</td>
                                                    <td align=""right"">" + item.Buy_Avg.ToString("0.00") + @"</td>
                                                    <td align=""right"">" + item.Buy_Total.ToString("0.00") + @"</td>
                                                    <td align=""right"">" + item.Sell_Qty + @"</td>
                                                    <td align=""right"">" + item.Sell_Avg.ToString("0.00") + @"</td>
                                                    <td align=""right"">" + item.Sell_Total.ToString("0.00") + @"</td>
                                                    <td align=""right"">" + item.Balance + @"</td>
                                                    <td align=""right"">" +item.Amount.ToString("0.00")+@"</td>
                                                    <td align=""right"">"+item.Commission.ToString("0.00")+@"</td>
                                                  </tr>";
              // Include some non-ASCII characters in body and subject. 
              message_dep.Body += Environment.NewLine;// +someArrows;   
            }
           

            message_dep.BodyEncoding = System.Text.Encoding.UTF8;
            return message_dep;
        }
        

        private MailMessage SetMoneyDepositInfoBody(MailMessage message_dep, EmailMonetyTrans_NotificationBO bo)
        {
            string someArrows = new string(new char[] { '\u2190', '\u2191', '\u2192', '\u2193' });         
            if(bo.Payment_Media=="Cash" && bo.Deposit_Withdraw=="Deposit")
            {
                message_dep.Body = @"Dear sir or madam," + Environment.NewLine +
                @"We have received Cash Tk." + bo.Amount.ToString("0.00") + " against the client ID: " + bo.Cust_Code + "  at " + bo.Entry_Branch_Name + ". Deposit Voucher number:" + bo.VoucherNo + " . End of day your account balance is Tk. " + bo.Money_Balance.ToString("0.00") + "" + Environment.NewLine + Environment.NewLine +
                @"Thanks a lot for your valuable transaction." + Environment.NewLine + Environment.NewLine +
                @"K-Securities & Consultants ltd." + Environment.NewLine +// someArrows +
                //@"Member: # 122" + Environment.NewLine +
                @"www.ksclbd.com";

                // Include some non-ASCII characters in body and subject. 
                message_dep.Body += Environment.NewLine; 
                message_dep.Body+="This website's information are based on our actual record. If any of the above details look incorrect, please advise immediately. This is however possible but highly unlikely to find your record inaccurate or missing. This may happened due to malfunction of any/some of web tools that we use to collect and display your data here such as internet connectivity, FTP software, web server malfunction,  problem with web database and others. We assure you that our master record of actual information is not affected by any of these.";
                message_dep.Body += Environment.NewLine;
            }
            else if (bo.Payment_Media == "EFT" && bo.Deposit_Withdraw == "Deposit")
            {
               message_dep.Body = @"Dear sir or madam," + Environment.NewLine +
                @"We have received EFT /Fund Transfer Tk. " + bo.Amount.ToString("0.00") + " against the client ID: " + bo.Cust_Code + " at " + bo.Entry_Branch_Name + ". Deposit Voucher number: " + bo.VoucherNo + ". End of day your account balance is Tk. " + bo.Money_Balance.ToString("0.00") + "" + Environment.NewLine + Environment.NewLine +
                @"Thanks a lot for your valuable transaction." + Environment.NewLine + Environment.NewLine +
                @"K-Securities & Consultants ltd." + Environment.NewLine +
                //@"Member: # 122" + Environment.NewLine +
                @"www.ksclbd.com";

                // Include some non-ASCII characters in body and subject. 
                message_dep.Body += Environment.NewLine;
                message_dep.Body+="This website's information are based on our actual record.  If any of the above details look incorrect, please advise immediately. This is however possible but highly unlikely to find your record inaccurate or missing. This may happened due to malfunction of any/some of web tools that we use to collect and display your data here such as internet connectivity, FTP software, web server malfunction,  problem with web database and others. We assure you that our master record of actual information is not affected by any of these.";
                message_dep.Body += Environment.NewLine;
            }
            else if (bo.Payment_Media == "Check" && bo.Deposit_Withdraw == "Deposit")
            {
                message_dep.Body = @"Dear sir or madam," + Environment.NewLine +
                @"We have received cheque Tk. " + bo.Amount.ToString("0.00") + " against the client ID: " + bo.Cust_Code + " at " + bo.Entry_Branch_Name + ". Received cheque is ‘" + bo.ChequekBank + ", " + bo.ChequeBranch + ", cheque No: " + bo.Payment_Media_No + "’, Deposit Voucher number: " + bo.VoucherNo + ". End of day your account balance is Tk. " + bo.Money_Balance.ToString("0.00") + "" + Environment.NewLine + Environment.NewLine +
                @"Thanks a lot for your valuable transaction." + Environment.NewLine + Environment.NewLine +
                @"K-Securities & Consultants ltd." + Environment.NewLine +
                //@"Member: # 122" + Environment.NewLine +
                @"www.ksclbd.com";

                // Include some non-ASCII characters in body and subject. 
                message_dep.Body += Environment.NewLine;
                message_dep.Body+="This website's information are based on our actual record.  If any of the above details look incorrect, please advise immediately. This is however possible but highly unlikely to find your record inaccurate or missing. This may happened due to malfunction of any/some of web tools that we use to collect and display your data here such as internet connectivity, FTP software, web server malfunction,  problem with web database and others. We assure you that our master record of actual information is not affected by any of these.";
                message_dep.Body += Environment.NewLine;
            }
            else if (bo.Payment_Media.Contains(Indication_PaymentTransaction.Return_Indicator) && bo.Deposit_Withdraw == "Deposit")
            {
                message_dep.Body = @"Dear sir or madam," + Environment.NewLine +
                @"We have received " + bo.Payment_Media.Replace(Indication_PaymentTransaction.Return_Indicator,"") + " " + Indication_PaymentTransaction.Return_Indicator + " Tk. " + bo.Amount.ToString("0.00") + " against the client ID: " + bo.Cust_Code + " at " + bo.Entry_Branch_Name + ". Deposit Voucher number: " + bo.VoucherNo + ". End of day your account balance is Tk. " + bo.Money_Balance.ToString("0.00") + "" + Environment.NewLine + Environment.NewLine +
                @"Thanks a lot for your valuable transaction." + Environment.NewLine + Environment.NewLine +
                @"K-Securities & Consultants ltd." + Environment.NewLine +
                    //@"Member: # 122" + Environment.NewLine +
                @"www.ksclbd.com";

                // Include some non-ASCII characters in body and subject. 
                message_dep.Body += Environment.NewLine;
                message_dep.Body += "This website's information are based on our actual record.  If any of the above details look incorrect, please advise immediately. This is however possible but highly unlikely to find your record inaccurate or missing. This may happened due to malfunction of any/some of web tools that we use to collect and display your data here such as internet connectivity, FTP software, web server malfunction,  problem with web database and others. We assure you that our master record of actual information is not affected by any of these.";
                message_dep.Body += Environment.NewLine;
            }
            //if (bo.Payment_Media == "TR" && bo.Deposit_Withdraw == "Deposit")
            //{
            //    message_dep.Body = @"Dear sir or madam," + Environment.NewLine +
            //    @"We have received Cash Transfer Tk." + bo.Amount + @" (Client ID : " + bo.TransReason + @" )against the client ID: " + bo.Cust_Code + "  at " + bo.Entry_Branch_Name + ". Deposit Voucher number:" + bo.VoucherNo + " . End of day your account balance is Tk. " + bo.Money_Balance + "" + Environment.NewLine + Environment.NewLine +
            //    @"Thanks a lot for your valuable transaction." + Environment.NewLine + Environment.NewLine +
            //    @"K-Securities & Consultants ltd." + Environment.NewLine +// someArrows +
            //    @"Member: # 122" + Environment.NewLine +
            //    @"www.ksclbd.com";

            //    // Include some non-ASCII characters in body and subject. 
            //    message_dep.Body += Environment.NewLine;
            //}

            message_dep.BodyEncoding = System.Text.Encoding.UTF8;
            message_dep.Subject = "Money Deposit Notification";
            message_dep.SubjectEncoding = System.Text.Encoding.UTF8;

            return message_dep;
        }

        private MailMessage SetMoneyWithdrawInfoBody(MailMessage message_dep, EmailMonetyTrans_NotificationBO bo)
        {
            string someArrows = new string(new char[] { '\u2190', '\u2191', '\u2192', '\u2193' });
            if (bo.Payment_Media == "Cash" && bo.Deposit_Withdraw == "Withdraw")
            {
                message_dep.Body = @"Dear sir or madam," + Environment.NewLine +
                @"As per request of you, We have Withdrawal Cash Tk." + bo.Amount.ToString("0.00") + " against the client ID: " + bo.Cust_Code + "  at " + bo.Entry_Branch_Name + ". Withdrawal Voucher number:" + bo.VoucherNo + " . End of day your account balance is Tk. " + bo.Money_Balance.ToString("0.00") + "" + Environment.NewLine + Environment.NewLine +
                @"Thanks a lot for your valuable transaction." + Environment.NewLine + Environment.NewLine +
                @"K-Securities & Consultants ltd." + Environment.NewLine +// someArrows +
                //@"Member: # 122" + Environment.NewLine +
                @"www.ksclbd.com";

                // Include some non-ASCII characters in body and subject. 
                message_dep.Body += Environment.NewLine;
                message_dep.Body+="This website's information are based on our actual record.  If any of the above details look incorrect, please advise immediately. This is however possible but highly unlikely to find your record inaccurate or missing. This may happened due to malfunction of any/some of web tools that we use to collect and display your data here such as internet connectivity, FTP software, web server malfunction,  problem with web database and others. We assure you that our master record of actual information is not affected by any of these.";
                message_dep.Body += Environment.NewLine;

            }
            else if (bo.Payment_Media == "EFT" && bo.Deposit_Withdraw == "Withdraw")
            {
                message_dep.Body = @"Dear sir or madam," + Environment.NewLine +
                @"As per request of you, We have Withdrawal EFT /Fund Transfer Tk. " + bo.Amount.ToString("0.00") + " against the client ID: " + bo.Cust_Code + " at " + bo.Entry_Branch_Name + ". Withdrawal Voucher number: " + bo.VoucherNo + ". End of day your account balance is Tk. " + bo.Money_Balance.ToString("0.00") + ". " +
                @"Your bank account will be settled after 2 working days from today." + Environment.NewLine + Environment.NewLine +
                @"Thanks a lot for your valuable transaction." + Environment.NewLine + Environment.NewLine +
                @"K-Securities & Consultants ltd." + Environment.NewLine +// someArrows +
                //@"Member: # 122" + Environment.NewLine +
                @"www.ksclbd.com";

                // Include some non-ASCII characters in body and subject. 
                message_dep.Body += Environment.NewLine;
                message_dep.Body+="This website's information are based on our actual record.  If any of the above details look incorrect, please advise immediately. This is however possible but highly unlikely to find your record inaccurate or missing. This may happened due to malfunction of any/some of web tools that we use to collect and display your data here such as internet connectivity, FTP software, web server malfunction,  problem with web database and others. We assure you that our master record of actual information is not affected by any of these.";
                message_dep.Body += Environment.NewLine;

            }
            else if (bo.Payment_Media == "Check" && bo.Deposit_Withdraw == "Withdraw")
            {
                message_dep.Body = @"Dear sir or madam," + Environment.NewLine +
                @"As per request of you, We have Withdrawal Cheque Tk. " + bo.Amount.ToString("0.00") + @" against the client ID: " + bo.Cust_Code + @". Your Collection Branch: " + bo.CollectionBranch + ". You will be able to collect your cheque after " + (bo.CollectionBranch == Indication_BrokerBranch.HeadOffice ? "2" : "4") + " working Days from today. End of day your account balance is Tk. " + bo.Money_Balance.ToString("0.00") + "" + Environment.NewLine + Environment.NewLine +
                @"Thanks a lot for your valuable transaction." + Environment.NewLine + Environment.NewLine + 
                @"K-Securities & Consultants ltd." + Environment.NewLine +// someArrows +
                //@"Member: # 122" + Environment.NewLine+
                @"www.ksclbd.com";

                // Include some non-ASCII characters in body and subject. 
                message_dep.Body += Environment.NewLine;//+someArrows;
                message_dep.Body+="This website's information are based on our actual record.  If any of the above details look incorrect, please advise immediately. This is however possible but highly unlikely to find your record inaccurate or missing. This may happened due to malfunction of any/some of web tools that we use to collect and display your data here such as internet connectivity, FTP software, web server malfunction,  problem with web database and others. We assure you that our master record of actual information is not affected by any of these.";
                message_dep.Body += Environment.NewLine;

            }
            else if (bo.Payment_Media == Indication_PaymentTransaction.Cheque_Return && bo.Deposit_Withdraw == Indication_PaymentMode.Withdraw)
            {
                message_dep.Body = @"Dear sir or madam," + Environment.NewLine +
                @"We have Withdrawal Cheque Return Tk. " + bo.Amount.ToString("0.00") + " against the client ID: " + bo.Cust_Code + " at " + bo.Entry_Branch_Name + ". Your return cheque is ‘" + bo.ChequekBank + ", " + bo.ChequeBranch + ", cheque No: " + bo.Payment_Media_No + "’, Withdrawal Voucher number: " + bo.VoucherNo + ". End of day your account balance is Tk. " + bo.Money_Balance.ToString("0.00") + "" + Environment.NewLine + Environment.NewLine +
                @"Thanks a lot for your valuable transaction." + Environment.NewLine + Environment.NewLine +
                @"K-Securities & Consultants ltd." + Environment.NewLine +
                    //@"Member: # 122" + Environment.NewLine +
                @"www.ksclbd.com";

                // Include some non-ASCII characters in body and subject. 
                message_dep.Body += Environment.NewLine;
                message_dep.Body+="This website's information are based on our actual record.  If any of the above details look incorrect, please advise immediately. This is however possible but highly unlikely to find your record inaccurate or missing. This may happened due to malfunction of any/some of web tools that we use to collect and display your data here such as internet connectivity, FTP software, web server malfunction,  problem with web database and others. We assure you that our master record of actual information is not affected by any of these.";
                message_dep.Body += Environment.NewLine;
            }
            else if (bo.Payment_Media.Contains(Indication_PaymentTransaction.Return_Indicator) && bo.Deposit_Withdraw == "Withdraw")
            {
                message_dep.Body = @"Dear sir or madam," + Environment.NewLine +
                 @"As per request of you, We have Withdrawal " + bo.Payment_Media.Replace(Indication_PaymentTransaction.Return_Indicator,"") + " " + Indication_PaymentTransaction.Return_Indicator + " Tk." + bo.Amount.ToString("0.00") + " against the client ID: " + bo.Cust_Code + "  at " + bo.Entry_Branch_Name + ". Withdrawal Voucher number:" + bo.VoucherNo + " . End of day your account balance is Tk. " + bo.Money_Balance.ToString("0.00") + "" + Environment.NewLine + Environment.NewLine +
                 @"Thanks a lot for your valuable transaction." + Environment.NewLine + Environment.NewLine +
                 @"K-Securities & Consultants ltd." + Environment.NewLine +// someArrows +
                    //@"Member: # 122" + Environment.NewLine +
                 @"www.ksclbd.com";

                // Include some non-ASCII characters in body and subject. 
                message_dep.Body += Environment.NewLine;
                message_dep.Body += "This website's information are based on our actual record.  If any of the above details look incorrect, please advise immediately. This is however possible but highly unlikely to find your record inaccurate or missing. This may happened due to malfunction of any/some of web tools that we use to collect and display your data here such as internet connectivity, FTP software, web server malfunction,  problem with web database and others. We assure you that our master record of actual information is not affected by any of these.";
                message_dep.Body += Environment.NewLine;

            }
            //if (bo.Payment_Media == "TR" && bo.Deposit_Withdraw == "Withdraw")
            //{
            //    message_dep.Body = @"Dear sir or madam," + Environment.NewLine +
            //    @"As per request of you, We have Withdrawal Cash Transfer  Tk." + bo.Amount + " (Client ID : " + bo.TransReason + ") against the client ID: " + bo.Cust_Code + "  at " + bo.Entry_Branch_Name + ". Withdrawal Voucher number:" + bo.VoucherNo + " . End of day your account balance is Tk. " + bo.Money_Balance + "" + Environment.NewLine + Environment.NewLine +
            //    @"Thanks a lot for your valuable transaction." + Environment.NewLine + Environment.NewLine +
            //    @"K-Securities & Consultants ltd." + Environment.NewLine +// someArrows +
            //    @"Member: # 122" + Environment.NewLine +
            //    @"www.ksclbd.com";

            //    // Include some non-ASCII characters in body and subject. 
            //    message_dep.Body += Environment.NewLine;
            //}

            message_dep.BodyEncoding = System.Text.Encoding.UTF8;
            message_dep.Subject = "Money Withdraw Notification"; 
            message_dep.SubjectEncoding = System.Text.Encoding.UTF8;

            return message_dep;
        }

        public string IfEmptyValueThen(string Label,object value)
        {
            string result = string.Empty;
            if (value == null || value == DBNull.Value)
            {
                result = Label + value;
            }
           
            return result;
        }

        public string[] Send_Message_MoneyTrans()
        {
            string[] result = new string[2];
            int success = 0;
            int fail = 0;
            foreach (MessageObject_MoneyTran item in messagesObjs_moneyTrans)
            {
                CCSBAL bal = new CCSBAL();
                CommonBAL comBal = new CommonBAL();
                
                Thread.Sleep(5000);
                try
                {
                    
                    client.Timeout = 15000;
                    //string userState = "Test Message";
                    client.Send(item.Mail);
                    if (item.MessageInfoBo.Payment_Media == "EFT" && item.MessageInfoBo.Deposit_Withdraw == "Withdraw")
                        bal.CCS_Email_NotificationSent(item.MessageInfoBo.Cust_Code,item.MessageInfoBo.ReferenceNo, Indication_EmailNotification.Email_NotificationType_EftWithdraw, string.Empty, comBal.GetCurrentServerDate().ToShortDateString());
                    else if (item.MessageInfoBo.Payment_Media != "EFT" && item.MessageInfoBo.Deposit_Withdraw == "Withdraw")
                        bal.CCS_Email_NotificationSent(item.MessageInfoBo.Cust_Code,item.MessageInfoBo.ReferenceNo, Indication_EmailNotification.Email_NotificationType_MoneyWithdraw, string.Empty, comBal.GetCurrentServerDate().ToShortDateString());
                    else if (item.MessageInfoBo.Deposit_Withdraw == "Deposit")
                        bal.CCS_Email_NotificationSent(item.MessageInfoBo.Cust_Code, item.MessageInfoBo.ReferenceNo, Indication_EmailNotification.Email_NotificationType_MoneyDeposit, string.Empty, comBal.GetCurrentServerDate().ToShortDateString());
                    success = success + 1;
                }
                catch (Exception ex)
                {
                    if (item.MessageInfoBo.Payment_Media == "EFT" && item.MessageInfoBo.Deposit_Withdraw == "Withdraw")
                        bal.CCS_Email_NotificationFailure(item.MessageInfoBo.Cust_Code, item.MessageInfoBo.ReferenceNo, Indication_EmailNotification.Email_NotificationType_EftWithdraw, string.Empty, comBal.GetCurrentServerDate().ToShortDateString(), ex.Message);
                    else if (item.MessageInfoBo.Payment_Media != "EFT" && item.MessageInfoBo.Deposit_Withdraw == "Withdraw")
                        bal.CCS_Email_NotificationFailure(item.MessageInfoBo.Cust_Code, item.MessageInfoBo.ReferenceNo, Indication_EmailNotification.Email_NotificationType_MoneyWithdraw, string.Empty, comBal.GetCurrentServerDate().ToShortDateString(), ex.Message);
                    else if (item.MessageInfoBo.Deposit_Withdraw == "Deposit")
                        bal.CCS_Email_NotificationFailure(item.MessageInfoBo.Cust_Code, item.MessageInfoBo.ReferenceNo, Indication_EmailNotification.Email_NotificationType_MoneyDeposit, string.Empty, comBal.GetCurrentServerDate().ToShortDateString(), ex.Message);
                    fail = fail + 1;
                }
                item.Mail.Dispose();
            }
            result[0] = Convert.ToString(success);
            result[1] = Convert.ToString(fail);

            return result;
        }
       

        public string[] Send_Message_TradeConfirmation()
        {
            string[] result = new string[2];
            int success = 0;
            int fail = 0;
            foreach (MessageObject_TradeConfirm item in messagesObjs_tradeConfirm)
            {
                CCSBAL bal = new CCSBAL();
                CommonBAL comBal = new CommonBAL();
                Thread.Sleep(5000);
                try
                {
                    client.Timeout =25000;
                    client.Send(item.Mail);
                    
                    bal.CCS_Email_NotificationSent(item.MessageInfoBo.Cust_Code, Indication_EmailNotification.Email_NotificationType_TradeConfirmation, "HTML Formatted Email", comBal.GetCurrentServerDate().ToShortDateString());
                    success = success + 1;
                }
                catch (Exception ex)
                {
                    bal.CCS_Email_NotificationFailure(item.MessageInfoBo.Cust_Code, Indication_EmailNotification.Email_NotificationType_TradeConfirmation, item.Mail.Body, comBal.GetCurrentServerDate().ToShortDateString(), ex.Message);
                    fail = fail + 1;
                }
            }
            result[0] = Convert.ToString(success);
            result[1] = Convert.ToString(fail);
            
            return result;
        }
    }
}
