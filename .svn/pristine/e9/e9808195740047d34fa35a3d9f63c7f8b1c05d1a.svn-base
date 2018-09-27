using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GsmComm.GsmCommunication;
using BusinessAccessLayer.BAL;
using GsmComm.PduConverter;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Data;


namespace ElectronicCommunication.SMS
{
    public class SMSSegregation
    {
        private ParsedSMS parsedObj;
        DataSqlQuery objData = new DataSqlQuery();
        public SMSSegregation()
        {
        }
        #region IPORequest
        
        
        public List<object> IPORequest(SmsPdu pdu)
        {           
            List<object> resultList = new List<object>();
            //===================================================
            try
            {
                if (pdu is SmsDeliverPdu)
                {
                    SmsDeliverPdu dpdu = (SmsDeliverPdu)pdu;
                    String Text = dpdu.UserDataText.ToLower();
                    string SMSCode = string.Empty;
                    string output_PaymentType = string.Empty;
                    string output_RefundType = string.Empty;
                    string output_CompanyCode = string.Empty;
                    string ErrorMsg = string.Empty;
                    string[] output_CustCode = null;
                    string output_Message = dpdu.UserDataText;
                    string output_PnoneNumber = dpdu.OriginatingAddress;
                    

                    if (dpdu.OriginatingAddress.Length > 11 || dpdu.OriginatingAddress.Length == 11)
                    {
                        dpdu.OriginatingAddress = dpdu.OriginatingAddress.Replace("+880", "0");
                    }

                    var RegCode =(objData.GetCustCodeMultipleFromPhoneNo(dpdu.OriginatingAddress));

                    string Output_RegCustCode = string.Join(",", RegCode.ToArray());
                    if (Output_RegCustCode != "")
                    {
                        SMSCode = SMSCode + SMSCommadCode.IPORegCust_Code + "-";
                    }
                    else
                    {
                        SMSCode = SMSCode + SMSCommadCode.IPODefault_Code + "-";
                    }                                    

                    char[] delimiterChars = { ' ', ',', '.', ':', '\t', '/', '_', ';', '.',};
                    string[] Word = Text.Split(delimiterChars);                    

                    List<string> listCustCodeforMessage = new List<string>();
                    string[] Input_CustCode = null;
                    var listtmp = new List<string>(Regex.Split(Text, @"\D+"));
                    Input_CustCode = listtmp.Where(t => !string.IsNullOrEmpty(Convert.ToString(t))).ToArray();

                    string[] RegCodeforarray = Output_RegCustCode.Split(',');  

                    #region NewWork

                    var listRegCustCode = string.Join(",", RegCodeforarray);
                    var listMessageplaceCustCode = string.Join(",", Input_CustCode);
                    if (listRegCustCode.Contains(listMessageplaceCustCode))
                    {
                        output_CustCode = Input_CustCode;
                        SMSCode = SMSCode + SMSCommadCode.IPOCustomerFound + "-";                       
                    }
                    else if (listRegCustCode.Length == listMessageplaceCustCode.Length)
                    {
                        List<string> ValidationRegCode = new List<string>();
                        foreach (string value in Input_CustCode)
                        {
                            if (!RegCodeforarray.Contains(value))
                            {                                
                                ValidationRegCode.Add((value).ToString());
                               
                            }
                        }
                        if (ValidationRegCode.Count == 0)
                        {
                            output_CustCode = Input_CustCode;
                            SMSCode = SMSCode + SMSCommadCode.IPOCustomerFound + "-";
                        }
                       
                    }
                    else 
                    {
                        string[] RegCodeforParentAndChildCode = null;
                        //---------- Parent Child ------------------------

                        List<KeyValuePair<string, string[]>> objectsGot = new List<KeyValuePair<string, string[]>>();
                        foreach (string Rreg in RegCodeforarray)
                        {
                            var PRegcode = (objData.GetParentChildCheckFormCustCode(Rreg.ToString()));
                            RegCodeforParentAndChildCode = PRegcode.ToArray();
                            objectsGot.Add(new KeyValuePair<string, string[]>(Rreg.ToString(), (string[])RegCodeforParentAndChildCode));

                        }

                        string Code = string.Empty;
                        if (RegCodeforParentAndChildCode.Length != 0)
                        {
                            foreach (var tmp in objectsGot)
                            {
                                DataSqlQuery objdataSqlQuery = new DataSqlQuery();                            
                                string ErrorMsg_Tmp = MessageGenerate.IPORegErrorMessage(tmp.Key);
                                int l = 1;
                                int invalidFound = 0;
                                foreach (string value in Input_CustCode)
                                {
                                    if (!tmp.Value.Contains(value) && l < Input_CustCode.Length)
                                    {
                                        ErrorMsg_Tmp = ErrorMsg_Tmp + value + ",";
                                        invalidFound++;
                                    }
                                    else if (!tmp.Value.Contains(value))
                                    {
                                        ErrorMsg_Tmp = ErrorMsg_Tmp + value;
                                        invalidFound++;
                                    }
                                    l++;
                                }
                                if (invalidFound == 0)
                                {
                                    output_CustCode = Input_CustCode;
                                    SMSCode = SMSCode + SMSCommadCode.IPOCustomerFound + "-";
                                    Output_RegCustCode = tmp.Key;
                                    break;
                                }
                                else
                                {
                                    string SMSCodelastPart = "SMS07";
                                    string sMessage = objdataSqlQuery.GetNotRegisterMessage(SMSCodelastPart);
                                    ErrorMsg = ErrorMsg_Tmp + sMessage;
                                }
                            }
                        }
                        else
                        {
                            output_CustCode = Input_CustCode;
                            SMSCode = SMSCode + SMSCommadCode.DefaultCode + "-";
                        }
                    }
                    resultList.Add(Output_RegCustCode);

                    if (ErrorMsg != "")
                    {
                        output_CustCode = Input_CustCode;
                        SMSCode = SMSCode + SMSCommadCode.DefaultCode + "-";
                    }

                    //---------- End Parent Child -------------------

                    #endregion                          
                  //- ---------- IPO Company Select ------------------
                    string Comapnt_ShortCode = "";
                    string IpoCompanyShortCode = string.Empty;
                    Comapnt_ShortCode = Word[0].ToLower();
                    if (Comapnt_ShortCode != "")
                    {
                         IpoCompanyShortCode = GetCompany_Short_Code_FromReg(Comapnt_ShortCode);
                    }
                    if (IpoCompanyShortCode != "")
                    {
                        output_CompanyCode = Comapnt_ShortCode;
                        resultList.Add(output_CompanyCode);
                        SMSCode = SMSCode + SMSCommadCode.IPOCompanyFound + "-";
                    }
                    else if (IpoCompanyShortCode == "")
                    {
                        SMSCode = SMSCode + SMSCommadCode.IPODefault_Code + "-";
                    }
                    //--------------------  End Company Select -----------------

                    if (ErrorMsg == "")
                    {
                        resultList.Add(Input_CustCode);
                    }
                    else
                    {
                        resultList.Add(Input_CustCode);
                    }

                    string IPO_PaymentType = "pIPO,ptrade,pmIPO,PmTrade";
                    string[] IPO_paymenttype = IPO_PaymentType.Split(',');
                    foreach (string PType in IPO_paymenttype)
                    {
                        if (Word.Contains(PType.ToLower()))
                        {
                            output_PaymentType = PType.ToLower();
                        }
                    }
                    resultList.Add(output_PaymentType);
                    if (output_PaymentType != "")
                    {
                        SMSCode = SMSCode + SMSCommadCode.IPOPaymentType + "-";
                    }
                    else if (output_PaymentType == "")
                    {
                        SMSCode = SMSCode + SMSCommadCode.IPODefault_Code + "-";
                    }
                    string IPO_RefundType = "rIPO,rtrade,rEFT,rmIPO,rmTrade";
                    string[] IPO_refundtype = IPO_RefundType.Split(',');
                    foreach (string RType in IPO_refundtype)
                    {
                        if (Word.Contains(RType.ToLower()))
                        {
                            output_RefundType = RType.ToLower();
                        }
                    }
                    resultList.Add(output_RefundType);
                    if (output_RefundType != "")
                    {
                        SMSCode = SMSCode + SMSCommadCode.IPORefundType;
                    }
                    else if(output_RefundType == "")
                    {
                        SMSCode = SMSCode + SMSCommadCode.IPODefault_Code ;
                    }
                    string ReceiveID = objData.ReceiveID();

                    resultList.Add(output_Message);
                    resultList.Add(output_PnoneNumber);
                    resultList.Add(ReceiveID);
                    resultList.Add(ErrorMsg);
                    resultList.Add(SMSCode);

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            //========================
            return resultList;            
        }
        #endregion 

        #region For Placing Order (Buy) in Market Price:

        public List<object> BuyOrderRequest(SmsPdu pdu)
        {
            List<object> ResultList = new List<object>();
            try
            {
                if(pdu is SmsDeliverPdu)
                {
                    SmsDeliverPdu   bpdu = (SmsDeliverPdu)pdu;
                    string Text = bpdu.UserDataText.ToUpper();
                    string SMSCode = string.Empty;
                    string Output_CompanyShortCode = string.Empty;
                    long Output_ShareQuantity = 0;
                    string Output_BuyorSellOrder = string.Empty;
                    string Output_MarketPrice = string.Empty;
                    long Output_RegCustCode = 0;
                    string OutPut_OrderRange = string.Empty;
                    long OutPut_OrderID = 0;
                    string Output_Message = bpdu.UserDataText;
                    string Output_PhoneNumber = bpdu.OriginatingAddress;                   
                    char[] delimiterChars = { ' ', ',', '.', ':', '\t', '/', ';', '.', };
                    string[] Word = Text.Split(delimiterChars);
                    string[] Message = Word.Where(t => !string.IsNullOrEmpty(Convert.ToString(t))).ToArray();


                    Output_RegCustCode = Convert.ToInt64(objData.GetCustCodeFromPhoneNo(bpdu.OriginatingAddress));
                    if (Output_RegCustCode != 0)
                    {
                        SMSCode = SMSCode + SMSCommadCode.RegCust_Code+"-";
                    }
                    else
                    {
                        SMSCode = SMSCode + SMSCommadCode.DefaultCode + "-";
                    }


                    string CompanyShortCode = Message[0].ToUpper();
                    string ComShortCode = objData.GetCompanyShortCodeFromCompanyShortCode(CompanyShortCode);
                    if (ComShortCode != "")
                    {
                        Output_CompanyShortCode = ComShortCode;
                        SMSCode =SMSCode+ SMSCommadCode.CompanyShortCode + "-"; 
                    }
                    else if (ComShortCode == "")
                    {
                        SMSCode =SMSCode+ SMSCommadCode.DefaultCode + "-"; 
                    }



                    if (Message.Length > 2)
                    {
                        if (IsTextValidated(Message[1].ToString()) == true)
                        {
                            long Quentaty = Convert.ToInt64(Message[1]);
                            if (Quentaty != 0)
                            {
                                Output_ShareQuantity = Convert.ToInt64(Quentaty);
                                SMSCode = SMSCode + SMSCommadCode.ShareQuentity + "-";
                            }
                            else if (Quentaty == 0)
                            {
                                SMSCode =SMSCode+ SMSCommadCode.DefaultCode + "-";
                            }
                        }
                    }
                    if (Output_ShareQuantity == 0)
                    {
                        SMSCode =SMSCode+ SMSCommadCode.DefaultCode + "-";
                    }



                    string BuyandSellOrder = "B,S";
                    string Order = "";
                    string[] BuyorSellOrder = BuyandSellOrder.Split(',');

                    foreach (string OrderType in BuyorSellOrder)
                    {
                        if (Message.Contains(OrderType))
                        {
                            Order = OrderType;
                            if (Order == "B")
                            {
                                Output_BuyorSellOrder = "Buy";
                                SMSCode = SMSCode + SMSCommadCode.BuyOrder + "-";
                            }
                            else if (Order == "S")
                            {
                                Output_BuyorSellOrder = "Sell";
                                SMSCode = SMSCode + SMSCommadCode.BuyOrder + "-";
                            }
                            else
                            {
                                SMSCode = SMSCode + SMSCommadCode.DefaultCode + "-";
                            }
                        }                        
                    }
                    if (Output_BuyorSellOrder == "")
                    {
                        SMSCode = SMSCode + SMSCommadCode.DefaultCode + "-";
                    }


                    string MarketPrise = "MP";
                    string PriceRange = "";
                    if (Message.Length == 4)
                    {
                        PriceRange = Message[3].ToString();
                        if (Message.Length > 4)
                        {
                            string[] Input_PriceRange = null;
                            var listtmp = new List<string>(Regex.Split(Text, @"\D+"));
                            Input_PriceRange = listtmp.Where(t => !string.IsNullOrEmpty(Convert.ToString(t))).ToArray();
                            PriceRange = Input_PriceRange[1].ToString() + "-" + Input_PriceRange[2].ToString();

                        }

                        if (Message.Contains(MarketPrise))
                        {
                            Output_MarketPrice = "Market Price";                           
                            SMSCode = SMSCode + SMSCommadCode.MarketPrice;
                        }
                        else if (PriceRange != "")
                        {
                            Output_MarketPrice = PriceRange;
                            SMSCode = SMSCode + SMSCommadCode.MarketPrice ;
                        }
                        else
                        {
                            SMSCode = SMSCode + SMSCommadCode.DefaultCode;
                        }
                    }
                    else
                    {
                        SMSCode = SMSCode + SMSCommadCode.DefaultCode;
                    }



                   


                    OutPut_OrderID = objData.GenerateOrderID("tbl_order_place", "Order_ID");

                    
                    ResultList.Add(Output_RegCustCode);
                    ResultList.Add(Output_CompanyShortCode);
                    ResultList.Add(Output_ShareQuantity);
                    ResultList.Add(Output_BuyorSellOrder);
                    ResultList.Add(Output_MarketPrice);                 
                    ResultList.Add(Output_PhoneNumber);
                    ResultList.Add(OutPut_OrderID);
                    ResultList.Add(SMSCode);
                    
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return ResultList;
        }
        #endregion       

        #region SmsForSummery
        public List<object> SMSforSummery(SmsPdu pdu)
        {
            List<object> ResultListShareSummert = new List<object>();
            try
            {
                if (pdu is SmsDeliverPdu)
                {
                    SmsDeliverPdu Apdu = (SmsDeliverPdu)pdu;
                    String text = Apdu.UserDataText.ToUpper();
                    string Output_PhoneNumber = Apdu.OriginatingAddress;
                    string Output_message = Apdu.UserDataText.ToUpper();
                    char[] delimiterChars = { ' ', ',', '.', ':', '\t', '/', ';', '.', };
                    string[] message = Output_message.Split(delimiterChars);
                    string SMSCode = string.Empty;
                    
                    long Output_RegCustCode = 0;
                    string Output_ShortCode =string.Empty;
                    Output_RegCustCode = Convert.ToInt32(objData.GetCustCodeFromPhoneNo(Apdu.OriginatingAddress));

                    if (Output_RegCustCode != 0)
                    {
                        SMSCode = SMSCommadCode.SM_RegCustCode + "-";
                    }
                    else
                    {
                        SMSCode = SMSCode + SMSCommadCode.SM_DefaultCode + "-"; 
                    }
                   
                    if (message.Length == 1)
                    {
                        string defaultMessage = "SS,AS,LPR,CB";
                        string[] InputMessage = defaultMessage.Split(',');
                        foreach (string ShortCode in InputMessage)
                        {
                            if (Output_message.Contains(ShortCode.ToUpper()))
                            {
                                Output_ShortCode = ShortCode.ToUpper();
                            }
                        }
                    }
                    if (Output_ShortCode != "")
                    {
                        SMSCode = SMSCode+ SMSCommadCode.SM_ShortCode;
                    }
                    else
                    {
                        SMSCode = SMSCode+ SMSCommadCode.SM_DefaultCode;
                    }
                   

                    DateTime ReceiveTime = Convert.ToDateTime(System.DateTime.Now);
                    ResultListShareSummert.Add(Output_RegCustCode);
                    ResultListShareSummert.Add(Output_PhoneNumber);
                    ResultListShareSummert.Add(Output_ShortCode);
                    ResultListShareSummert.Add(Output_message);
                    ResultListShareSummert.Add(ReceiveTime);
                    ResultListShareSummert.Add(SMSCode);
                    
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return ResultListShareSummert;
        }
        #endregion      

        #region IPOInformation
        public List<object> IPOInformation(SmsPdu SmsPdu)
        {
            List<object> resultIpoInformation = new List<object>();
            try
            {
                if (SmsPdu is SmsDeliverPdu)
                {
                    SmsDeliverPdu Ipdu = (SmsDeliverPdu)SmsPdu;
                    String Text = Ipdu.UserDataText.ToUpper();
                    char[] delimiterChars = { ' ', ',', '.', ':', '\t', '/', ';', '.', };
                    string[] Word = Text.Split(delimiterChars);
                    string PhoneNumber = Ipdu.OriginatingAddress;
                    long Output_RegCustCode = 0;
                    string Output_Message = string.Empty;
                    string SMSCode = string.Empty;
                    Output_RegCustCode = Convert.ToInt32(objData.GetCustCodeFromPhoneNo(Ipdu.OriginatingAddress));
                    //var RegCode = (objData.GetCustCodeMultipleFromPhoneNo(Ipdu.OriginatingAddress));
                    //Output_RegCustCode = string.Join(",", RegCode.ToArray());
                    string IPOInformation = "IPO";
                    if (Output_RegCustCode != 0)
                    {
                        SMSCode = SMSCommadCode.IPOInfoRegCustCOde + "-";
                    }
                    else
                    {
                        SMSCode = SMSCommadCode.IPODefault_Code + "-";
                    }


                    if (Word.Length == 1  || Word.Length <= 1)
                    {                        
                            if (Word.Contains(IPOInformation))
                            {
                                Output_Message = IPOInformation;
                            }
                        
                    }
                    if (Output_Message != "")
                    {
                        SMSCode = SMSCode + SMSCommadCode.IPOInfoCode;
                    }
                    else
                    {
                        SMSCode =SMSCode +  SMSCommadCode.IPODefault_Code;
                    }
                    DateTime ReceiveTime = System.DateTime.Now;
                    string ReceiveID = objData.ReceiveID();
                    string IPOType = objData.IPOSMSType("3");



                    resultIpoInformation.Add(Output_RegCustCode);
                    resultIpoInformation.Add(Output_Message);
                    resultIpoInformation.Add(PhoneNumber);
                    resultIpoInformation.Add(ReceiveTime);
                    resultIpoInformation.Add(ReceiveID);
                    resultIpoInformation.Add(IPOType);
                    resultIpoInformation.Add(SMSCode);
                   
                }

            }
            catch (Exception)
            {                
                throw;
            }
            return resultIpoInformation;
        }
        #endregion


        #region Deposite/Withdraw
        public List<object> Deposite_Withdraw(SmsPdu SmsPdu)
        {
            List<object> Result_Deposite_Withdraw = new List<object>();
            try
            {
                if (SmsPdu is SmsDeliverPdu)
                {
                    SmsDeliverPdu Dpdu = (SmsDeliverPdu)SmsPdu;
                    string Text = Dpdu.UserDataText.ToUpper();
                    char[] delimiterChars = { ' ', ',', '.', ':', '\t', '/', '_', ';', '.',};
                    string[] Word = Text.Split(delimiterChars);
                    string RegCustCode = string.Empty;
                    string Deposite_Withdraw = string.Empty;
                    string Trade_IPO = string.Empty;
                    string Amount = string.Empty;
                    string ErrorMsg = string.Empty;
                    string[] output_CustCode = null;                   
                    string SMSCode = String.Empty;
                    string Search_ReceiveID = string.Empty;
                    string[] Cust_Code = null;
                    string PhoneNumber = string.Empty;

                    if (Dpdu.OriginatingAddress.Length > 11 || Dpdu.OriginatingAddress.Length == 11)
                    {
                        PhoneNumber = Dpdu.OriginatingAddress.Replace("+880", "0");
                    }

                    var RegCode = (objData.GetCustCodeMultipleFromPhoneNo(Dpdu.OriginatingAddress));
                    RegCustCode = string.Join(",", RegCode.ToArray());
                    if (RegCustCode != "")
                    {
                        SMSCode = SMSCommadCode.Deposite_Withdraw_RegCustCode + "-";
                    }
                    else
                    {
                        SMSCode = SMSCommadCode.Deposite_Withdraw_Default + "-";
                    }

                    
                    //-------------- Deposite/Withdraw Check---------
                    string DefaultText = "D,W,Deposite,Withdraw";
                    string[] DefaulttextArray = DefaultText.ToUpper().Split(',');

                    foreach (string Value in DefaulttextArray)
                    {
                        if (Word.Contains(Value.ToUpper()))
                        {
                            if (Value == "D" || Value == "DEPOSITE")
                            {
                                Deposite_Withdraw = "Deposite";
                                break;
                            }
                            else if (Value == "W" || Value == "WITHDRAW")
                            {
                                Deposite_Withdraw = "Withdraw";
                                break;
                            }
                        }
                    }

                    if (Deposite_Withdraw != "")
                    {
                        SMSCode = SMSCode + SMSCommadCode.Deposite_Withdraw_Found + "-"; 
                    }
                    else
                    {
                        SMSCode = SMSCode + SMSCommadCode.Deposite_Withdraw_Default + "-"; 
                    }
                    //--------------- End Deposite/Withdraw Check ------------


                   //--------------- Check Trade / IPO ----------------------
                    string message = "Trade,Ipo,I,P";
                    string[] Message = message.ToUpper().Split(',');
                    foreach (string Value in Message)
                    {
                        if (Word.Contains(Value.ToUpper()))
                        {
                            if (Value == "TRADE" || Value == "T")
                            {
                                Trade_IPO = "Trade";
                                break;
                            }
                           else if (Value == "IPO" || Value == "I")
                            {
                                Trade_IPO = "IPO";
                                break;
                            }
                        }
                    }
                    if (Trade_IPO != "")
                    {
                        SMSCode = SMSCode + SMSCommadCode.Deposite_Withdraw_Trade_Ipo + "-";
                    }
                    else
                    {
                        SMSCode = SMSCode + SMSCommadCode.Deposite_Withdraw_Default + "-";
                    }
                    //---------------END Trade / IPO ----------

                    //----------------  Search Amount ------

                    List<string> listAmount = new List<string>();
                    listAmount = Word.ToList();

                    foreach (string value in Word)
                    {
                        if (value == "TRADE" || value == "T")
                        {
                            break;
                        }
                        else if (value == "IPO" || value == "I")
                        {
                            break;
                        }
                        else
                        {
                            listAmount.Remove(value);
                        }
                    }

                    string[] TAmount = listAmount.ToArray();
                    string textAmount = string.Join(",",TAmount);
                    string[] Input_Amount = null;
                    var listtmpAmount = new List<string>(Regex.Split(textAmount, @"\D+"));
                    Input_Amount = listtmpAmount.Where(t => !string.IsNullOrEmpty(Convert.ToString(t))).ToArray();
                    Amount = string.Join(",", Input_Amount);
                    if (Amount != "")
                    {
                        SMSCode = SMSCode + SMSCommadCode.Deposite_Withdraw_Amount + "-";
                    }
                    else
                    {
                        SMSCode = SMSCode + SMSCommadCode.Deposite_Withdraw_Default + "-";
                    }

                    //---------------- End Search Amount ----



                    //--------- Check Cust_Code --------------

                    List<string> listCust_Code = new List<string>();

                    foreach (string value in Word)
                    {
                        if (value == "TRADE" || value == "T")
                        {
                            break;
                        }
                        else if (value == "IPO" || value == "I")
                        {
                            break;
                        }
                        else
                        {
                            listCust_Code.Add(value);
                        }
                    }
                    string[] CustCode = listCust_Code.ToArray();
                    string[] Input_CustCode = null;
                    string textCustCode = string.Join(",", CustCode);
                    var listtmp = new List<string>(Regex.Split(textCustCode, @"\D+"));
                    Input_CustCode = listtmp.Where(t => !string.IsNullOrEmpty(Convert.ToString(t))).ToArray();

                    string[] ARegCode = RegCode.ToArray();
                    var listRegCode = string.Join(",", ARegCode);
                    var listPlaceCustCode = string.Join(",", Input_CustCode);
                    if (listPlaceCustCode == listRegCode)
                    {
                        output_CustCode = Input_CustCode;
                        SMSCode = SMSCode + SMSCommadCode.Deposite_Withdraw_CustCode;
                    }
                    else
                    {
                        string[] RegCodeforParentAndChildCode = null;
                        //---------- Parent Child ------------------------
                        string[] Reg_CustCode = RegCode.ToArray();
                        List<KeyValuePair<string, string[]>> objectsGot = new List<KeyValuePair<string, string[]>>();
                        foreach (string Rreg in Reg_CustCode)
                        {
                            var PRegcode = (objData.GetParentChildCheckFormCustCode(Rreg.ToString()));
                            RegCodeforParentAndChildCode = PRegcode.ToArray();
                            objectsGot.Add(new KeyValuePair<string, string[]>(Rreg.ToString(), (string[])RegCodeforParentAndChildCode));

                        }

                        if (Reg_CustCode.Length > 0)
                        {
                            string Code = string.Empty;
                            if (RegCodeforParentAndChildCode.Length != 0)
                            {
                                foreach (var tmp in objectsGot)
                                {
                                    DataSqlQuery objdataSqlQuery = new DataSqlQuery();



                                    string ErrorMsg_Tmp = MessageGenerate.IPORegErrorMessage(tmp.Key);
                                    int l = 1;
                                    int invalidFound = 0;
                                    foreach (string value in Input_CustCode)
                                    {
                                        if (!tmp.Value.Contains(value) && l < Input_CustCode.Length)
                                        {
                                            ErrorMsg_Tmp = ErrorMsg_Tmp + value + ",";
                                            invalidFound++;
                                        }
                                        else if (!tmp.Value.Contains(value))
                                        {
                                            ErrorMsg_Tmp = ErrorMsg_Tmp + value;
                                            invalidFound++;
                                        }
                                        l++;
                                    }
                                    if (invalidFound == 0)
                                    {
                                        output_CustCode = Input_CustCode;
                                        SMSCode = SMSCode + SMSCommadCode.Deposite_Withdraw_CustCode;
                                        RegCustCode = tmp.Key;
                                        break;
                                    }
                                    else
                                    {
                                        string FirstSMSCode = "SMS07";
                                        string sMessageFirstpart = objdataSqlQuery.GetNotRegisterMessage(FirstSMSCode);
                                        ErrorMsg = ErrorMsg_Tmp + sMessageFirstpart;
                                    }
                                }
                            }
                        }
                        else
                        {
                            output_CustCode = Input_CustCode;
                            SMSCode = SMSCode + SMSCommadCode.Deposite_Withdraw_Default;
                        }

                    }

                    if (ErrorMsg != "")
                    {
                        output_CustCode = Input_CustCode;
                        SMSCode = SMSCode + SMSCommadCode.Deposite_Withdraw_Default;
                    }                
                    //--------- End Cust_ Code ----------------


                    //---------  Receive ID ------------------
                    string ReceiveID = string.Empty;
                    Search_ReceiveID = objData.ReceiveID();
                    string ReceiveMessage = objData.GetReceiveMessage(Search_ReceiveID);
                    string Phone_Message = Dpdu.UserDataText;
                    if (Phone_Message.Contains(ReceiveMessage))
                    {
                        ReceiveID = Search_ReceiveID;
                    }
                    //------------  End receive ID ------------


                    Result_Deposite_Withdraw.Add(RegCustCode);
                    Result_Deposite_Withdraw.Add(Deposite_Withdraw);
                    Result_Deposite_Withdraw.Add(Trade_IPO);
                    Result_Deposite_Withdraw.Add(Amount);
                    Result_Deposite_Withdraw.Add(output_CustCode);
                    Result_Deposite_Withdraw.Add(PhoneNumber);
                    Result_Deposite_Withdraw.Add(ReceiveID);
                    Result_Deposite_Withdraw.Add(Phone_Message);
                    Result_Deposite_Withdraw.Add(ErrorMsg);                  
                    Result_Deposite_Withdraw.Add(SMSCode);

                }

            }
            catch (Exception)
            {                
                throw;
            }
            return Result_Deposite_Withdraw;
            
        }

        #endregion


        #region SMSFormat

        public List<object> SMSFormat(SmsPdu SmsPdu)
        {
            List<object> SmsFormat = new List<object>();
            try
            {
                if (SmsPdu is SmsDeliverPdu)
                {
                    SmsDeliverPdu Fpdu = (SmsDeliverPdu)SmsPdu;
                    string Text = Fpdu.UserDataText.ToUpper();
                    string PhoneNumber = Fpdu.OriginatingAddress;
                    string SMSCode = string.Empty;
                    long Output_RegCustCode = 0;
                    Output_RegCustCode = Convert.ToInt32(objData.GetCustCodeFromPhoneNo(Fpdu.OriginatingAddress));

                    if (Output_RegCustCode != 0)
                    {
                        SMSCode = SMSCommadCode.Format_RegCustCode;
                    }
                    else
                    {
                        SMSCode = SMSCommadCode.IPODefault_Code;
                    }                   

                }
            }
            catch
            {
            }
            return SmsFormat;
        }

        #endregion

        private bool IsTextValidated(string strTextEntry)
        {
            Regex objNotWholePattern = new Regex("[^0-9]");
            return !objNotWholePattern.IsMatch(strTextEntry)
                 && (strTextEntry != "");
        }

        public string ShareSummary(string SMSText)
        {
            string result = string.Empty;

            return result;
        }
        public string SMSTrade(string SMSText)
        {
            string result = string.Empty;

            return result;
        }

        private void SendInvalidCustomerNotice(string sSMSSender, string sMesssage)
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
                string PushMessage = "";
                PushMessage = sMesssage;
                SmsSubmitPdu pdu;
                pdu = new SmsSubmitPdu(sMesssage, sSMSSender.Trim(), "");
                //CommSettingBAL.Comm.SendMessage(pdu);
                ModemCommunication.gsObj.SendMessage(pdu);
                return;

            }
            catch (Exception)
            {
                throw;
            }
        }

        #region NewWork

        public string GetCompany_Short_Code_FromReg(string CustCode)
        {
            try
            {
                string cnn = SMS_Constant.CallCenter_ConnectionString;
                SqlConnection aSqlConnection = new SqlConnection(cnn);
                DataSet aDataset = new DataSet();
                SqlDataAdapter aSqldataadapter = new SqlDataAdapter();
                string Query = string.Empty;
                if (CustCode != "")
                {
                    Query = "Select * from tbl_IPO_SessionforCompanyInfo Where Company_Short_Code='" + CustCode + "'";
                }

                aSqldataadapter.SelectCommand = new SqlCommand(Query, aSqlConnection);
                aSqldataadapter.Fill(aDataset);
                DataTable dt = new DataTable();

                dt = aDataset.Tables[0];

                string CustomerCode = "";
                foreach (DataRow dr in dt.Rows)
                {
                    CustomerCode = (dr[0].ToString());
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

       


        #endregion


    }
}
