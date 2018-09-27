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
    public class ReceiveSMSParser
    {

        public struct DefaultMatching
        {
            public string Key;
            public int DiffValue;
            public int MatchValue;
            public int NoOccaranceNoMatchString;
            public int Percentage_NoMatchString;
            public int CountKeys;
        };
        public ParsedSMS parsedObj;
        private SmsPdu pdu;
        public DataSqlQuery objdataSqlQuery = new DataSqlQuery();
        public ReceiveSMSParser(SmsPdu pdu_P)
        {
            try
            {
                parsedObj = new ParsedSMS();
                pdu = pdu_P;
                Parsing(pdu_P);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        
        public ParsedSMS GetParsedSMSObject()
        {
                        return parsedObj;            
        }
        
        public void Parsing(SmsPdu pdu)
        {
            
            SMSSegregation sgr=new SMSSegregation();
            List<KeyValuePair<string, object>> objectsGot = new List<KeyValuePair<string, object>>();
            objectsGot.Add(new KeyValuePair<string, object>(SMSCommadCode.Deposite_Withdraw, (object)sgr.Deposite_Withdraw(pdu)));
            objectsGot.Add(new KeyValuePair<string, object>(SMSCommadCode.SM_ShareSummery, (object)sgr.SMSforSummery(pdu)));
            objectsGot.Add(new KeyValuePair<string, object>( SMSCommadCode.IPORequest, (object)sgr.IPORequest(pdu)));
            objectsGot.Add(new KeyValuePair<string, object>(SMSCommadCode.IPOInformation, (object)sgr.IPOInformation(pdu)));
            objectsGot.Add(new KeyValuePair<string, object>(SMSCommadCode.BuyOrderForMarketPrice, (object)sgr.BuyOrderRequest(pdu)));

            if (Convert.ToString(((List<object>)objectsGot.Where(t => t.Key == SMSCommadCode.IPORequest).Select(t => t.Value).ToList()[0]).Last()) == SMSCommadCode.IPORequest)
            {
                var list = (List<object>)objectsGot.Where(t => t.Key == SMSCommadCode.IPORequest).Select(t => t.Value).ToList()[0];
                Action_IpoRequest((string)list[0], (string)list[1], (string[])list[2], (string)list[3], (string)list[4], pdu.UserDataText, (pdu as SmsDeliverPdu).OriginatingAddress, (string)list[7]);
            }
            else if (Convert.ToString(((List<object>)objectsGot.Where(t => t.Key == SMSCommadCode.IPOInformation).Select(t => t.Value).ToList()[0]).Last()) == SMSCommadCode.IPOInformation)
            {
                var list = (List<object>)objectsGot.Where(t => t.Key == SMSCommadCode.IPOInformation).Select(t => t.Value).ToList()[0];
                Action_IPOInformation((long)list[0], (string)list[1], (string)list[2], (DateTime)list[3], (String)list[4], (string)list[5]);          
            }
           else if (Convert.ToString(((List<object>)objectsGot.Where(t => t.Key == SMSCommadCode.BuyOrderForMarketPrice).Select(t => t.Value).ToList()[0]).Last()) == SMSCommadCode.BuyOrderForMarketPrice)
            {
                var list = (List<object>)objectsGot.Where(t => t.Key == SMSCommadCode.BuyOrderForMarketPrice).Select(t => t.Value).ToList()[0];
                Action_SMSOrder((long)list[0], (string)list[1], (long)list[2], (string)list[3], (string)list[4], (string)list[5], (long)list[6]);
          
            }
            else if (Convert.ToString(((List<object>)objectsGot.Where(t => t.Key == SMSCommadCode.SM_ShareSummery).Select(t => t.Value).ToList()[0]).Last()) == SMSCommadCode.SM_ShareSummery)
            {
                var list = (List<object>)objectsGot.Where(t => t.Key == SMSCommadCode.SM_ShareSummery).Select(t => t.Value).ToList()[0];
                Action_SMSShareSummery((long)list[0], (string)list[1], (string)list[2], (string)list[3],(DateTime)list[4]);
          
            }
            else if (Convert.ToString(((List<object>)objectsGot.Where(t => t.Key == SMSCommadCode.Deposite_Withdraw).Select(t => t.Value).ToList()[0]).Last()) == SMSCommadCode.Deposite_Withdraw)
            {
                var list = (List<object>)objectsGot.Where(t => t.Key == SMSCommadCode.Deposite_Withdraw).Select(t => t.Value).ToList()[0];
                Action_Deposite_Withdraw((string)list[0], (string)list[1], (string)list[2], (string)list[3], (string[])list[4], (string)list[5], (string)list[6], (string)list[7]);

            }
            else
            {
                Action_Default(objectsGot);
            }
        }

        #region Action_IpoRequest
        public void Action_IpoRequest(string regCust_Code,string IpoCompanyShortCode,string[] CustCode, string PaymentMethod,string RefuncMethod,string SMSFullText,string FromPhoneNo ,string ReceiveID)
        {
            try
            {
                string Fullmessage = string.Empty;
                ParsedSMS pSms = new ParsedSMS();
                pSms.DatabaseDetais = new List<Database_Details>();
                int i = 1;
                foreach (string Cust_Code in CustCode)
                {

                    List<Database_Details> tempList = new List<Database_Details>(){
                                                 new Database_Details(){TableName=EmailComm_Indications.TableName_IPORequest,FieldName="CompanyShortName",Value="'"+IpoCompanyShortCode+"'",Condition="",RowNumber=i.ToString(),Action=Database_Action.Add},
                                                 new Database_Details(){TableName=EmailComm_Indications.TableName_IPORequest,FieldName="Cust_Code",Value="'"+Cust_Code+"'",Condition="",RowNumber=i.ToString(),Action=Database_Action.Add},
                                                 new Database_Details(){TableName=EmailComm_Indications.TableName_IPORequest,FieldName="PaymentType",Value="'"+PaymentMethod+"'",Condition="",RowNumber=i.ToString(),Action=Database_Action.Add},
                                                 new Database_Details(){TableName=EmailComm_Indications.TableName_IPORequest,FieldName="RefundType",Value="'"+RefuncMethod+"'",Condition="",RowNumber=i.ToString(),Action=Database_Action.Add},
                                                 new Database_Details(){TableName=EmailComm_Indications.TableName_IPORequest,FieldName="ReceivedNumber",Value="'"+FromPhoneNo+"'",Condition="",RowNumber=i.ToString(),Action=Database_Action.Add},
                                                 new Database_Details(){TableName=EmailComm_Indications.TableName_IPORequest,FieldName="ReferenceNumber",Value="'"+(regCust_Code)+"'",Condition="",RowNumber=i.ToString(),Action=Database_Action.Add}, 
                                                 new Database_Details(){TableName=EmailComm_Indications.TableName_IPORequest,FieldName="ReceiveID",Value="'"+(ReceiveID)+"'",Condition="",RowNumber=i.ToString(),Action=Database_Action.Add},                                                
                                                 new Database_Details(){TableName=EmailComm_Indications.TableName_IPORequest,FieldName="Text",Value="'"+SMSFullText+"'",Condition="",RowNumber=i.ToString(),Action=Database_Action.Add},
                                                 new Database_Details(){TableName=EmailComm_Indications.TableName_IPORequest,FieldName="DataTime",Value="'"+DateTime.Now+"'",Condition="",RowNumber=i.ToString(),Action=Database_Action.Add},
                                                 new Database_Details(){TableName=EmailComm_Indications.TableName_IPORequest,FieldName="Remarks",Value="'"+string.Empty+"'",Condition="",RowNumber=i.ToString(),Action=Database_Action.Add},
                                                 new Database_Details(){TableName=EmailComm_Indications.TableName_IPORequest,FieldName="Status",Value="0",Condition="",RowNumber=i.ToString(),Action=Database_Action.Add}

                    };
                    pSms.DatabaseDetais.AddRange(tempList);
                    i++;
                }
                parsedObj = pSms;                
                string ssMessage = MessageGenerate.Get_SMSText_IPOSuccessfull(CustCode);               
                SendInvalidCustomerNotice(FromPhoneNo, ssMessage);               
                SendMessageloadConsolApplication(regCust_Code, FromPhoneNo, ssMessage);

            }
            catch (Exception ex)
            {
                
            }

        }

        #endregion

        #region Action_IPOInformation

        public void Action_IPOInformation(long RegCustCode, string Message, string Destination, DateTime Receivetime,string ReceiveID , string IPOType)
        {
            try
            {
                string PushPull = getIPOInformation(Convert.ToString(RegCustCode));
                ParsedSMS pSms = new ParsedSMS();
                pSms.DatabaseDetais = new List<Database_Details>();
                int i = 1;
                {
                    List<Database_Details> tempList = new List<Database_Details>() {
                         new Database_Details(){TableName=EmailComm_Indications.TableName_IPODefaultInformation,FieldName="Cust_Code",Value="'"+RegCustCode+"'",Condition="",RowNumber=i.ToString(),Action=Database_Action.Add},
                         new Database_Details(){TableName=EmailComm_Indications.TableName_IPODefaultInformation,FieldName="Message",Value="'"+PushPull+"'",Condition="",RowNumber=i.ToString(),Action=Database_Action.Add},                          
                         new Database_Details(){TableName=EmailComm_Indications.TableName_IPODefaultInformation,FieldName="Destination",Value="'"+Destination+"'",Condition="",RowNumber=i.ToString(),Action=Database_Action.Add},                          
                         new Database_Details(){TableName=EmailComm_Indications.TableName_IPODefaultInformation,FieldName="DeliveryDateTime",Value="'"+Receivetime+"'",Condition="",RowNumber=i.ToString(),Action=Database_Action.Add},
                         new Database_Details(){TableName=EmailComm_Indications.TableName_IPODefaultInformation,FieldName="Status",Value="0",Condition="",RowNumber=i.ToString(),Action=Database_Action.Add},
                         new Database_Details(){TableName=EmailComm_Indications.TableName_IPODefaultInformation,FieldName="ReferenceID",Value="'"+ReceiveID+"'",Condition="",RowNumber=i.ToString(),Action=Database_Action.Add},
                         new Database_Details(){TableName=EmailComm_Indications.TableName_IPODefaultInformation,FieldName="SMSType",Value="'"+IPOType+"'",Condition="",RowNumber=i.ToString(),Action=Database_Action.Add},
                    };
                    pSms.DatabaseDetais.AddRange(tempList);
                    i++;
                }
                parsedObj = pSms;
            }
            catch (Exception ex)
            {

            }

        }

        #endregion

        #region Action_SMSOrder
        public void Action_SMSOrder(long RegCustCode, string CompanyShortCode, long quantity, string BuyorSell, string MarketPrice, string PhoneNumber,long OrderID)
        {
            try
            {
                ParsedSMS pSms = new ParsedSMS();
                pSms.DatabaseDetais = new List<Database_Details>();
                int i = 1;
                {

                    List<Database_Details> tempList = new List<Database_Details>(){
                                                 new Database_Details(){TableName=EmailComm_Indications.TableName_OrderInformation,FieldName="Order_Id",Value="'"+Convert.ToInt64(OrderID)+"'",Condition="",RowNumber=i.ToString(),Action=Database_Action.Add},
                                                 new Database_Details(){TableName=EmailComm_Indications.TableName_OrderInformation,FieldName="Cust_Code",Value="'"+Convert.ToInt64(RegCustCode)+"'",Condition="",RowNumber=i.ToString(),Action=Database_Action.Add},
                                                 new Database_Details(){TableName=EmailComm_Indications.TableName_OrderInformation,FieldName="Company_Short_Code",Value="'"+CompanyShortCode+"'",Condition="",RowNumber=i.ToString(),Action=Database_Action.Add},
                                                 new Database_Details(){TableName=EmailComm_Indications.TableName_OrderInformation,FieldName="Quantity",Value="'"+Convert.ToInt64(quantity)+"'",Condition="",RowNumber=i.ToString(),Action=Database_Action.Add},
                                                 new Database_Details(){TableName=EmailComm_Indications.TableName_OrderInformation,FieldName="Order_Range",Value="'"+MarketPrice+"'",Condition="",RowNumber=i.ToString(),Action=Database_Action.Add},
                                                 new Database_Details(){TableName=EmailComm_Indications.TableName_OrderInformation,FieldName="Order_Type",Value="'"+BuyorSell+"'",Condition="",RowNumber=i.ToString(),Action=Database_Action.Add},
                                                 new Database_Details(){TableName=EmailComm_Indications.TableName_OrderInformation,FieldName="Market_Type",Value="'Public'",Condition="",RowNumber=i.ToString(),Action=Database_Action.Add},                                                
                                                 new Database_Details(){TableName=EmailComm_Indications.TableName_OrderInformation,FieldName="Order_Channel",Value="'SMS'",Condition="",RowNumber=i.ToString(),Action=Database_Action.Add},
                                                 new Database_Details(){TableName=EmailComm_Indications.TableName_OrderInformation,FieldName="Expiry_Date",Value="'"+DateTime.Today.Date.ToShortDateString()+"'",Condition="",RowNumber=i.ToString(),Action=Database_Action.Add},
                                                 new Database_Details(){TableName=EmailComm_Indications.TableName_OrderInformation,FieldName="Submission_Date",Value="'"+DateTime.Today.Date.ToShortDateString()+"'",Condition="",RowNumber=i.ToString(),Action=Database_Action.Add},
                                                 new Database_Details(){TableName=EmailComm_Indications.TableName_OrderInformation,FieldName="Order_Time",Value="'"+String.Format("{0:HH:mm:ss tt}", System.DateTime.Now)+"'",Condition="",RowNumber=i.ToString(),Action=Database_Action.Add},
                                                 new Database_Details(){TableName=EmailComm_Indications.TableName_OrderInformation,FieldName="Status",Value="0",Condition="",RowNumber=i.ToString(),Action=Database_Action.Add},
                                                 new Database_Details(){TableName=EmailComm_Indications.TableName_OrderInformation,FieldName="Remarks",Value="'"+string.Empty+"'",Condition="",RowNumber=i.ToString(),Action=Database_Action.Add}, 
                                                // new Database_Details(){TableName=EmailComm_Indications.TableName_OrderInformation,FieldName="Order_Price",Value="'"+Convert.ToInt64(string.Empty)+"'",Condition="",RowNumber=i.ToString(),Action=Database_Action.Add},
                                                 //new Database_Details(){TableName=EmailComm_Indications.TableName_OrderInformation,FieldName="Executed_Quantity",Value="'"+Convert.ToInt64(string.Empty)+"'",Condition="",RowNumber=i.ToString(),Action=Database_Action.Add},
                                                 //new Database_Details(){TableName=EmailComm_Indications.TableName_OrderInformation,FieldName="Executed_Price",Value="'"+Convert.ToInt64(string.Empty)+"'",Condition="",RowNumber=i.ToString(),Action=Database_Action.Add},
                                                 //new Database_Details(){TableName=EmailComm_Indications.TableName_OrderInformation,FieldName="Executed_By",Value="'"+string.Empty+"'",Condition="",RowNumber=i.ToString(),Action=Database_Action.Add},
                                                 new Database_Details(){TableName=EmailComm_Indications.TableName_OrderInformation,FieldName="Entry_by",Value="'"+PhoneNumber+"'",Condition="",RowNumber=i.ToString(),Action=Database_Action.Add},
                                                 new Database_Details(){TableName=EmailComm_Indications.TableName_OrderInformation,FieldName="Entry_date",Value="'"+DateTime.Today.Date.ToShortDateString()+"'",Condition="",RowNumber=i.ToString(),Action=Database_Action.Add}, 
                                                 new Database_Details(){TableName=EmailComm_Indications.TableName_OrderInformation,FieldName="Captured",Value="'"+string.Empty+"'",Condition="",RowNumber=i.ToString(),Action=Database_Action.Add},
                                                 new Database_Details(){TableName=EmailComm_Indications.TableName_OrderInformation,FieldName="Execution_Media",Value="'"+string.Empty+"'",Condition="",RowNumber=i.ToString(),Action=Database_Action.Add}





                    };
                    pSms.DatabaseDetais.AddRange(tempList);
                    i++;
                }
                parsedObj = pSms;
            }
            catch (Exception ex)
            {

            }

        }
        #endregion

        #region Action_SMSShareSummery
        public void Action_SMSShareSummery(long RegCustCode, string PhoneNumber, string ShortCode, string FullMessage, DateTime Receivedate)
        {
            try
            {
                ParsedSMS pSms = new ParsedSMS();
                pSms.DatabaseDetais = new List<Database_Details>();
                int i = 1;
                {

                    List<Database_Details> tempList = new List<Database_Details>(){
                                                 new Database_Details(){TableName=EmailComm_Indications.TableName_ShareSummeryInformation,FieldName="Cust_Code",Value="'"+Convert.ToInt64(RegCustCode)+"'",Condition="",RowNumber=i.ToString(),Action=Database_Action.Add},
                                                 new Database_Details(){TableName=EmailComm_Indications.TableName_ShareSummeryInformation,FieldName="Sender",Value="'"+PhoneNumber+"'",Condition="",RowNumber=i.ToString(),Action=Database_Action.Add},
                                                 new Database_Details(){TableName=EmailComm_Indications.TableName_ShareSummeryInformation,FieldName="Short_Code",Value="'"+ShortCode+"'",Condition="",RowNumber=i.ToString(),Action=Database_Action.Add},
                                                 new Database_Details(){TableName=EmailComm_Indications.TableName_ShareSummeryInformation,FieldName="Full_Message",Value="'"+FullMessage+"'",Condition="",RowNumber=i.ToString(),Action=Database_Action.Add},
                                                 new Database_Details(){TableName=EmailComm_Indications.TableName_ShareSummeryInformation,FieldName="Received_Time",Value="'"+Convert.ToDateTime(Receivedate)+"'",Condition="",RowNumber=i.ToString(),Action=Database_Action.Add},
                                                 new Database_Details(){TableName=EmailComm_Indications.TableName_ShareSummeryInformation,FieldName="Status",Value="0",Condition="",RowNumber=i.ToString(),Action=Database_Action.Add},
                                                 new Database_Details(){TableName=EmailComm_Indications.TableName_ShareSummeryInformation,FieldName="EntryTime",Value="'"+(System.DateTime.Now.ToShortDateString())+"'",Condition="",RowNumber=i.ToString(),Action=Database_Action.Add}                                                
                                                




                    };
                    pSms.DatabaseDetais.AddRange(tempList);
                    i++;
                }
                parsedObj = pSms;
            }
            catch (Exception ex)
            {

            }

        }

        #endregion

        #region Action_Deposite_Withdraw
        public void Action_Deposite_Withdraw(string RegCustCode, string Deposite_Withdraw, string Trade_IPO, string Amount, string[] output_CustCode, string PhoneNumber, string ReceiveID,string Message)
        {
            try
            {
                if (output_CustCode.Length > 0)
                {
                    ParsedSMS pSms = new ParsedSMS();
                    pSms.DatabaseDetais = new List<Database_Details>();
                    int i = 1;
                    {

                        foreach (string value in output_CustCode)
                        {
                            List<Database_Details> tempList = new List<Database_Details>(){
                                                 new Database_Details(){TableName=EmailComm_Indications.TableName_Deposite_Withdraw,FieldName="Cust_Code",Value="'"+(value)+"'",Condition="",RowNumber=i.ToString(),Action=Database_Action.Add},
                                                 new Database_Details(){TableName=EmailComm_Indications.TableName_Deposite_Withdraw,FieldName="Deposite_Withdraw",Value="'"+Deposite_Withdraw+"'",Condition="",RowNumber=i.ToString(),Action=Database_Action.Add},
                                                 new Database_Details(){TableName=EmailComm_Indications.TableName_Deposite_Withdraw,FieldName="Amount",Value="'"+Amount+"'",Condition="",RowNumber=i.ToString(),Action=Database_Action.Add},
                                                 new Database_Details(){TableName=EmailComm_Indications.TableName_Deposite_Withdraw,FieldName="Reg_Cust_Code",Value="'"+RegCustCode+"'",Condition="",RowNumber=i.ToString(),Action=Database_Action.Add},
                                                 new Database_Details(){TableName=EmailComm_Indications.TableName_Deposite_Withdraw,FieldName="PaymentType",Value="'"+Trade_IPO+"'",Condition="",RowNumber=i.ToString(),Action=Database_Action.Add},
                                                 new Database_Details(){TableName=EmailComm_Indications.TableName_Deposite_Withdraw,FieldName="Sender",Value="'"+PhoneNumber+"'",Condition="",RowNumber=i.ToString(),Action=Database_Action.Add},
                                                 new Database_Details(){TableName=EmailComm_Indications.TableName_Deposite_Withdraw,FieldName="Text",Value="'"+Message+"'",Condition="",RowNumber=i.ToString(),Action=Database_Action.Add},
                                                 new Database_Details(){TableName=EmailComm_Indications.TableName_Deposite_Withdraw,FieldName="ReceiveID",Value="'"+ReceiveID+"'",Condition="",RowNumber=i.ToString(),Action=Database_Action.Add},
                                                 new Database_Details(){TableName=EmailComm_Indications.TableName_Deposite_Withdraw,FieldName="DateTime",Value="'"+(System.DateTime.Now)+"'",Condition="",RowNumber=i.ToString(),Action=Database_Action.Add},
                                                 new Database_Details(){TableName=EmailComm_Indications.TableName_Deposite_Withdraw,FieldName="Status",Value="'"+0+"'",Condition="",RowNumber=i.ToString(),Action=Database_Action.Add}                                               
                                                



                    
                    };
                            pSms.DatabaseDetais.AddRange(tempList);
                            i++;
                        }
                    }
                    parsedObj = pSms;
                }
                else
                {
                    string SMSCode = "SMS15";
                    string sMessage = objdataSqlQuery.GetNotRegisterMessage(SMSCode);
                    SendInvalidCustomerNotice(PhoneNumber, sMessage);
                    SendMessageloadConsolApplication("", PhoneNumber, sMessage);
                }
            }                  
            catch (Exception ex)
            {

            }          

        }

        #endregion

        #region Action_Default
        public void Action_Default(List<KeyValuePair<string,object>> objectGot)
        {
            try
            {
               
                List<DefaultMatching> comparingResult = new List<DefaultMatching>();

                foreach (var value in objectGot.ToList())
                {
                    string ValueCode = Convert.ToString(((List<object>)value.Value).Last());
                    string KeyCode = Convert.ToString((string)value.Key);
                    int compareValue_Diff = LevenshteinDistance.Compute_Difference(KeyCode, ValueCode);
                    int compareValue_Match = LevenshteinDistance.Compute_Matching(KeyCode, ValueCode);
                    int noOfOccNoMatchString = LevenshteinDistance.GetNoOfMissMatchCode(ValueCode);
                    int percentage_noOfOccNoMatchString= KeyCode.Split('-').Length!=0?(noOfOccNoMatchString/KeyCode.Split('-').Length)*100:0;
                    int CountKeys = LevenshteinDistance.Get_KeyCount(ValueCode, KeyCode);
                    comparingResult.Add(new DefaultMatching() { Key = KeyCode, DiffValue = compareValue_Diff, MatchValue = compareValue_Match, NoOccaranceNoMatchString = noOfOccNoMatchString, Percentage_NoMatchString = percentage_noOfOccNoMatchString, CountKeys = CountKeys });
                    
                }
                var comp = comparingResult.ToList();

                var comparingResultSorted = comparingResult.OrderByDescending(t => t.CountKeys).ThenBy(t => t.Percentage_NoMatchString).ThenByDescending(t => t.MatchValue).ThenBy(t => t.DiffValue).ToList();

                string HigestPossibleCode = comparingResultSorted.First().Key;
                var valueTemp=comparingResultSorted.First();
                int NoOfOccarance_HighestPossibleCode = comparingResultSorted.Where(t => t.MatchValue == valueTemp.MatchValue && t.NoOccaranceNoMatchString == valueTemp.NoOccaranceNoMatchString && t.DiffValue == valueTemp.DiffValue).Count();
                
                if (HigestPossibleCode == SMSCommadCode.IPORequest && NoOfOccarance_HighestPossibleCode==1)
                {
                    List<object> resultList = (List<object>)objectGot.Where(t => t.Key == SMSCommadCode.IPORequest).Select(t => t.Value).FirstOrDefault();
                    string regCustCode = string.Empty;
                    string Message = string.Empty;
                    string Destination = string.Empty;
                    string CellNumber = string.Empty;
                    string PhoneNumber = string.Empty;
                    string RemoveList = string.Empty;
                    string SMSCodelist = string.Empty;
                    string FullMessage = string.Empty;

                    object[] Result = null;
                    Result = resultList.ToArray();
                    regCustCode = Result[0].ToString();
                    Message = Result[5].ToString();
                    Destination = Result[6].ToString();
                    RemoveList = Result[8].ToString();
                    SMSCodelist = Result[9].ToString();                   

                    foreach (object value in Result)
                    {
                        if (value.ToString().Length > 11 || value.ToString().Length == 11)
                        {
                            CellNumber = value.ToString().Replace("+880", "0");
                        }

                        if (IsTextValidated(CellNumber) == true)
                        {
                            PhoneNumber = CellNumber;
                        }
                    }

                    if (Destination.Length > 11 || Destination.Length == 11)
                    {
                        Destination = Destination.Replace("+880", "0");
                    }
                    if (regCustCode == "")
                    {
                        string SMSCode = "SMS01";
                        string sMessage = objdataSqlQuery.GetNotRegisterMessage(SMSCode);
                        SendInvalidCustomerNotice(Destination, sMessage);                       
                        SendMessageloadConsolApplication("",Destination,sMessage);
                        return;
                    }
                    else if (SMSCodelist == "105-***-107-108-109")
                    {
                        SendInvalidCustomerNotice(Destination, RemoveList);                       
                        SendMessageloadConsolApplication(regCustCode,Destination,RemoveList);
                    }
                    else
                    {                        
                        string IPO_DefaultMessage = MessageGenerate.Get_IPODefaultMessage(Message);
                        SendInvalidCustomerNotice(Destination, IPO_DefaultMessage);
                        SendMessageloadConsolApplication(regCustCode, Destination, IPO_DefaultMessage);
                    }


                    //ParsedSMS pSms = new ParsedSMS();
                    //pSms.DatabaseDetais = new List<Database_Details>();
                    //int i = 1;
                    //{
                    //     List<Database_Details> tempList = new List<Database_Details>() {
                    //     new Database_Details(){TableName=EmailComm_Indications.TableName_IPODefaultInformation,FieldName="Cust_Code",Value="'"+regCustCode+"'",Condition="",RowNumber=i.ToString(),Action=Database_Action.Add},
                    //     new Database_Details(){TableName=EmailComm_Indications.TableName_IPODefaultInformation,FieldName="Message",Value="'"+Message+"'",Condition="",RowNumber=i.ToString(),Action=Database_Action.Add},                          
                    //     new Database_Details(){TableName=EmailComm_Indications.TableName_IPODefaultInformation,FieldName="Destination",Value="'"+Destination+"'",Condition="",RowNumber=i.ToString(),Action=Database_Action.Add},                          
                    //     new Database_Details(){TableName=EmailComm_Indications.TableName_IPODefaultInformation,FieldName="DeliveryDateTime",Value="'"+DateTime.Today.Date.ToShortDateString()+"'",Condition="",RowNumber=i.ToString(),Action=Database_Action.Add},
                    //     new Database_Details(){TableName=EmailComm_Indications.TableName_IPODefaultInformation,FieldName="Status",Value="0",Condition="",RowNumber=i.ToString(),Action=Database_Action.Add},

                    //};
                    //    pSms.DatabaseDetais.AddRange(tempList);
                    //    i++;
                    //}
                    //parsedObj = pSms;
                }
                else if (HigestPossibleCode == SMSCommadCode.IPOInformation && NoOfOccarance_HighestPossibleCode == 1)
                {
                    List<object> ResultList = (List<object>)objectGot.Where(t => t.Key == SMSCommadCode.IPOInformation).Select(t => t.Value).FirstOrDefault();
                   
                    object[] Result = null;
                    Result = ResultList.ToArray();
                    string RegCustCode = string.Empty;
                    string PhoneNumber = string.Empty;
                    string FullMessage = string.Empty;

                    RegCustCode = Result[0].ToString();
                    PhoneNumber = Result[2].ToString();

                    if (PhoneNumber.Length > 11 || PhoneNumber.Length == 11)
                    {
                        PhoneNumber = PhoneNumber.Replace("+880", "0");
                    }
                    if (RegCustCode == "0")
                    {
                        string SMSCode = "SMS01";
                        string sMessage = objdataSqlQuery.GetNotRegisterMessage(SMSCode);
                        SendInvalidCustomerNotice(PhoneNumber, sMessage);                        
                        SendMessageloadConsolApplication("",PhoneNumber,sMessage);
                        return;
                    }

                }
                else if (HigestPossibleCode == SMSCommadCode.BuyOrderForMarketPrice && NoOfOccarance_HighestPossibleCode == 1)
                {
                    List<object> resultListMarketprice = (List<object>)objectGot.Where(t => t.Key == SMSCommadCode.BuyOrderForMarketPrice).Select(t => t.Value).FirstOrDefault();

                    object[] Result = resultListMarketprice.ToArray();
                    string CellNumber = string.Empty;
                    string PhoneNumber = string.Empty;
                    string RegCustCode = string.Empty;
                    string FullMessage = string.Empty;

                    RegCustCode = Result[0].ToString();
                    foreach (object value in Result)
                    {
                        if (value.ToString().Length > 11 || value.ToString().Length == 11)
                        {
                            CellNumber = value.ToString().Replace("+880", "0");
                        }

                        if (IsTextValidated(CellNumber) == true)
                        {
                            PhoneNumber = CellNumber;
                        }
                    }

                    if (RegCustCode == "0")
                    {
                        string SMSCode = "SMS01";
                        string sMessage = objdataSqlQuery.GetNotRegisterMessage(SMSCode);
                        SendInvalidCustomerNotice(PhoneNumber, sMessage);                       
                        SendMessageloadConsolApplication("",PhoneNumber,sMessage);
                        return;
                    }
                    string SMSCodeformat = "SMS04";
                    string sssMessage = objdataSqlQuery.GetNotRegisterMessage(SMSCodeformat);
                    SendInvalidCustomerNotice(PhoneNumber, sssMessage);                   
                    SendMessageloadConsolApplication(RegCustCode,PhoneNumber,sssMessage);
                    return;
                }
                else if (HigestPossibleCode == SMSCommadCode.SM_ShareSummery && NoOfOccarance_HighestPossibleCode == 1)
                {
                    List<object> resultListSharySummery = (List<object>)objectGot.Where(t => t.Key == SMSCommadCode.SM_ShareSummery).Select(t => t.Value).FirstOrDefault();
                    object[] Result = resultListSharySummery.ToArray();
                    string PnoneNumber = string.Empty;
                    string regCustCode = Result[0].ToString();
                    string CellNumber = string.Empty;
                    string FullMessage = string.Empty;

                    foreach (object value in Result)
                    {
                        if (value.ToString().Length > 11 || value.ToString().Length == 11)
                        {
                            CellNumber = value.ToString().Replace("+880", "0");
                        }

                        if (IsTextValidated(CellNumber) == true)
                        {
                            PnoneNumber = CellNumber;
                        }
                    }

                    if (regCustCode == "0")
                    {
                        string SMSCode = "SMS01";
                        string sMessage = objdataSqlQuery.GetNotRegisterMessage(SMSCode);
                        SendInvalidCustomerNotice(PnoneNumber, sMessage);                        
                        SendMessageloadConsolApplication("",PnoneNumber,sMessage);
                        return;
                    }
                }
                else if (HigestPossibleCode == SMSCommadCode.Deposite_Withdraw && NoOfOccarance_HighestPossibleCode == 1)
                {
                    List<object> resultListDeposite_WithDraw = (List<object>)objectGot.Where(t => t.Key == SMSCommadCode.Deposite_Withdraw).Select(t => t.Value).FirstOrDefault();
                    object[] Result = resultListDeposite_WithDraw.ToArray();
                    string PhoneNumber = string.Empty;
                    string regCustCode = string.Empty;
                    string CellNumber = string.Empty;
                    string SMSCodelist = string.Empty;
                    string ErrMessage = string.Empty;
                    string FullMessage = string.Empty;

                    foreach (object value in Result)
                    {
                        if (value.ToString().Length > 11 || value.ToString().Length == 11)
                        {
                            CellNumber = value.ToString().Replace("+880", "0");
                        }

                        if (IsTextValidated(CellNumber) == true)
                        {
                            PhoneNumber = CellNumber;
                        }
                    }
                    SMSCodelist = Result[9].ToString();
                    regCustCode = Result[0].ToString();
                    ErrMessage = Result[8].ToString();

                    if (SMSCodelist == "901-***-903-904-905")
                    {
                        string SMSCodeplace = "SMS13";
                        string sMessageplace = objdataSqlQuery.GetNotRegisterMessage(SMSCodeplace);
                        SendInvalidCustomerNotice(PhoneNumber, sMessageplace);                      
                        SendMessageloadConsolApplication(regCustCode,PhoneNumber,sMessageplace);
                    }
                    else if (SMSCodelist == "***-902-903-904-905")
                    {
                        string SMSCode = "SMS01";
                        string sMessage = objdataSqlQuery.GetNotRegisterMessage(SMSCode);
                        SendInvalidCustomerNotice(PhoneNumber, sMessage);                       
                        SendMessageloadConsolApplication("",PhoneNumber,sMessage);
                    }
                    else if(ErrMessage != "")                   
                    {                      
                        SendInvalidCustomerNotice(PhoneNumber, ErrMessage);
                        FullMessage =regCustCode+"-"+ ErrMessage + " - " + PhoneNumber;
                        SendMessageloadConsolApplication(regCustCode,PhoneNumber,ErrMessage);
                    }
                    else if (SMSCodelist == "901-902-903-***-905")
                    {
                        string SMSCode = "SMS13";
                        string sMessage = objdataSqlQuery.GetNotRegisterMessage(SMSCode);
                        SendInvalidCustomerNotice(PhoneNumber, sMessage);                       
                        SendMessageloadConsolApplication(regCustCode,PhoneNumber,sMessage);
                    }                  

                    
                }
                else
                {
                    List<object> resultListSharySummery = (List<object>)objectGot.Select(t => t.Value).FirstOrDefault();
                    object[] ListValue = resultListSharySummery.ToArray();
                    string PhoneNumber = string.Empty;
                    string CellNumber = string.Empty;
                    string CustCode = string.Empty;
                    string FullMessage = string.Empty;
                    CustCode = ListValue[0].ToString();
                    foreach (object value in resultListSharySummery)
                    {
                        if (value.ToString().Length > 11 || value.ToString().Length == 11)
                        {
                            CellNumber = value.ToString().Replace("+880", "0");
                        }

                        if (IsTextValidated(CellNumber) == true)
                        {
                            PhoneNumber = CellNumber;
                        }
                    }

                    if (CustCode == "" || CustCode == "0")
                    {
                        string SMSCodeforreg = "SMS01";
                        string sMessagereg = objdataSqlQuery.GetNotRegisterMessage(SMSCodeforreg);
                        SendInvalidCustomerNotice(PhoneNumber, sMessagereg);                      
                        SendMessageloadConsolApplication("",PhoneNumber,sMessagereg);
                        return;
                    }
                    else
                    {
                        string SMSCode = "SMS02";
                        string sMessage = objdataSqlQuery.GetNotRegisterMessage(SMSCode);
                        SendInvalidCustomerNotice(PhoneNumber, sMessage);                       
                        SendMessageloadConsolApplication(CustCode,PhoneNumber,sMessage);
                        return;                       
                    }
                }             
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }

        }


        #endregion




        private string getIPOInformation(string Cust_Code)
        {
            string cnn = SMS_Constant.CallCenter_ConnectionString;
            string[] ParendChild = null;
            string CustCode = string.Empty;
            string ShortCode = string.Empty;
            string TradeAccountBalance = string.Empty;
            string IPOAccountBalance = string.Empty;
            string IPOBalance = string.Empty;
            DataSqlQuery dataQuery = new DataSqlQuery();
            SqlConnection conn = new SqlConnection(cnn);
            DataSet oDataSet = new DataSet();
            SqlDataAdapter SQLDbAdapter = new SqlDataAdapter();
            string query = "Select  Sess.Company_Short_Code as Short_Code,Convert(decimal(28,0),ROUND((Sess.TotalAmount),2))  as TotalAmount,'" + Cust_Code + "' as Cust_Code,Convert(decimal(28,2),ROUND((Select t.Balance from tbl_Customer_Account   as t where t.Cust_Code='" + Cust_Code + "'),2)) AS TradeAcc_Balance,Convert(decimal(28,2),ROUND(ISNULL((Select t.Balance    from tbl_Customer_IPO_Account as t where t.Cust_Code='" + Cust_Code + "'),0),2)) AS IPOAcc_Balance    from [dbksclCallCenter].[dbo].[tbl_IPO_SessionforCompanyInfo] as Sess";

            SQLDbAdapter.SelectCommand = new SqlCommand(query, conn);
            SQLDbAdapter.Fill(oDataSet);
            DataTable dt = new DataTable();

            dt = oDataSet.Tables[0];

            var PRegcode = (dataQuery.GetParentChildCheckFormCustCode(Cust_Code));
            if (PRegcode.Count != 0)
            {
                ParendChild = PRegcode.ToArray();
                CustCode = ParendChild[0] + "," + ParendChild[1] + "," + ParendChild[2].ToString();
            }
            else
            {
                CustCode = Cust_Code;
            }

            string shareSummery = "ID :" + Cust_Code + "," + "Current IPO :";
            foreach (DataRow dr in dt.Rows)
            {
                ShortCode = dr["Short_Code"].ToString();
                IPOBalance = dr["TotalAmount"].ToString();
                TradeAccountBalance = dr["TradeAcc_Balance"].ToString();
                IPOAccountBalance = dr["IPOAcc_Balance"].ToString();
                if (ShortCode != "")
                {
                    //MessageGenerate  dd = new MessageGenerate();
                    //MessageGenerate.messageStroe(Cust_Code, ShortCode, IPOBalance, TradeAccountBalance, IPOAccountBalance, CustCode);
                    shareSummery = shareSummery + " " + dr["Short_Code"].ToString() + " " + "&" + " " + "Amount:" + dr["TotalAmount"].ToString() + "," + "IPO parent Acc. Balance:" + dr["IPOAcc_Balance"].ToString() + "," + "Trade Acc. Balance:" + dr["TradeAcc_Balance"].ToString() + "," + "SMS Format:" + dr["Short_Code"].ToString() + " " + CustCode + " " + "pmipo rmipo";
                }
                else
                {
                    DataSqlQuery objdataSqlQuery = new DataSqlQuery();
                    string SMSCode = "SMS09";
                    string sMessage = objdataSqlQuery.GetNotRegisterMessage(SMSCode);
                    shareSummery = sMessage;
                }
            }
            return shareSummery;
        }







        public void SendMessageloadConsolApplication(string CustCode, string PhoneNumber, String Message)
        {
            if (Message != "")
            {
                SMSCommadCode.S++;
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Message Sent     : ");
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
            else if (CustCode.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(CustCode + "      ");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(CustCode + " ");
            }        
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(PhoneNumber+"\t");

            if (Message.Length > 30)
            {
                char[] delimiterChars = { ' ', ','};
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
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t\t\t\t\t" + "Message Send : " + SMSCommadCode.S);
        }


        private bool IsTextValidated(string strTextEntry)
        {
            Regex objNotWholePattern = new Regex("[^0-9]");
            return !objNotWholePattern.IsMatch(strTextEntry)
                 && (strTextEntry != "");
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
                if (sMesssage.Length > 160)
                {
                    List<string> Messages = new List<string>();
                    string[] Words = sMesssage.Split(' ');
                    string FullMessageTemp = sMesssage;
                    int i = 0;
                    int stringLength = sMesssage.Length;
                    while (FullMessageTemp.Length > 0)
                    {
                        string EachMessage = string.Empty;
                        while (EachMessage.Length + Words[i].Length < 160)
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
                    foreach (string Value in Messages)
                    {
                        SmsSubmitPdu pdu;
                        pdu = new SmsSubmitPdu(Value, sSMSSender.Trim(), "");
                        ModemCommunication.gsObj.SendMessage(pdu);
                        return;
                    }
                }
                else
                {
                    string PushMessage = "";
                    PushMessage = sMesssage;
                    SmsSubmitPdu pdu;
                    pdu = new SmsSubmitPdu(PushMessage, sSMSSender.Trim(), "");
                    ModemCommunication.gsObj.SendMessage(pdu);
                    return;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }


            }
        }  


