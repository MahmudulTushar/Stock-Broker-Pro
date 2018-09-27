using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GsmComm.GsmCommunication;
using GsmComm.PduConverter;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Data;
using DataAccessLayer;

namespace ElectronicCommunication.SMS
{
   public class SMSReceiver
    {
       public DbConnection aDbConnection = new DbConnection();
       public DataSqlQuery objDataSqlQuery = new DataSqlQuery();
       ParsedSMS Smsload = new ParsedSMS();
       private ParsedSMS objParsedSMS;
       public SMSReceiver()
       {
           aDbConnection.ConnectionStringSMSSender = SMS_Constant.CallCenter_ConnectionString;
       }

       public string Execute_ActionAgainstReceivedMessage()
       {
           //int totalSmsReceived = 0;
           string FullMessageshow = string.Empty;           
           List<SmsPdu> smsObjs=new List<SmsPdu>();
           try
           {
               smsObjs = ModemCommunication.ReadMessage();
               foreach (var smsObj in smsObjs)
               {
                   // INSERT TO THE DATABASE FULLTEXT AND SHORTTEXT
                    
                   var dpdu = (SmsDeliverPdu)smsObj;
                   string[] regCust_Code = GetCustCodeFromPhoneNo(dpdu.OriginatingAddress).ToArray();
                   var RegCustCode = string.Join(",", regCust_Code);                   
                   String ReceivedTime = string.Empty;
                   string EntryTime = string.Empty;
                   string SMSSender = string.Empty;
                   string Short_Code = dpdu.UserDataText;
                   string FullMessage = dpdu.UserDataText;

                   FullMessageshow = dpdu.OriginatingAddress + " - " + FullMessage;                  
                   if (RegCustCode == "")
                   {
                       RegCustCode = "NULL";
                   }
                   Smsload.SMSText = FullMessage;
                   SMSSender = dpdu.OriginatingAddress;
                   ReceivedTime = dpdu.SCTimestamp.ToString();
                   ReceivedTime = String.Format("{0:dd-MMM-yyyy HH:mm:ss tt}", ReceivedTime);
                   EntryTime = String.Format("{0:dd-MMM-yyyy HH:mm:ss tt}", System.DateTime.Now);
                   objDataSqlQuery.InsertReceiveSMS(RegCustCode, SMSSender, Short_Code, FullMessage, ReceivedTime, "0", EntryTime);


                   ReceiveSMSParser prs = new ReceiveSMSParser(smsObj);
                   ParsedSMS prsSMSObj = prs.GetParsedSMSObject();
                   List<Database_Details> dbActions = prsSMSObj.DatabaseDetais;
                   if (prsSMSObj.DatabaseDetais.Where(t => t.Action == Database_Action.Add).ToList().Count > 0)
                   {
                       List<string> values = GetInsertStateMent(prsSMSObj);
                       try
                       {
                           aDbConnection.ConnectDatabase_SMSSender();
                           aDbConnection.StartTransaction_SMSSender();
                           foreach (string eachStatement in values)
                           {
                              aDbConnection.ExecuteNonQuery_SMSSender(eachStatement);
                           }
                           aDbConnection.Commit_SMSSender();
                       }
                       catch (Exception ex)
                       {
                           aDbConnection.Rollback_SMSSender();
                       }
                       finally
                       {
                           aDbConnection.CloseDatabase_SMSSender();
                       }
                   }
                   else if (prsSMSObj.DatabaseDetais.Where(t => t.Action == Database_Action.Update).ToList().Count > 0)
                   {

                   }
                   else if (prsSMSObj.DatabaseDetais.Where(t => t.Action == Database_Action.Delete).ToList().Count > 0)
                   {

                   }

               }
           }
           catch (Exception ex)
           {
               //Console.WriteLine(ex.ToString());
               throw ex;
           }
           return FullMessageshow ; //= FullMessage;         
       }

       public List<string> GetCustCodeFromPhoneNo(string PhoneNo)
       {
         
           try
           {
               if (PhoneNo.Length > 11 || PhoneNo.Length == 11)
               {
                   PhoneNo = PhoneNo.Replace("+880", "0");
               }
               List<string> result = new List<string>();
              
               string cnn = SMS_Constant.CallCenter_ConnectionString; 
               SqlConnection aSqlConnection = new SqlConnection(cnn);
               DataSet aDataset = new DataSet();
               SqlDataAdapter aSqldataadapter = new SqlDataAdapter();
               string Query = "Select Cust_Code from tbl_Confirmation_SMS_Reg Where Mobile='" + PhoneNo + "'";

               aSqldataadapter.SelectCommand = new SqlCommand(Query, aSqlConnection);
               aSqldataadapter.Fill(aDataset);
               DataTable dt = new DataTable();

               dt = aDataset.Tables[0];
               foreach (DataRow dr in dt.Rows)
               {
                   result.Add(dr[0].ToString());
               }
               return result;
           }
           catch (Exception)
           {
               throw;
           }
          
       }

       public List<string> GetInsertStateMent(ParsedSMS p_sms)
       {
           List<string> result = new List<string>();

            //ADD
           string StartStateMent="INSERT INTO ";
           string StateMent = StartStateMent;
           
           string[] tables_Add = p_sms.DatabaseDetais.Where(t => t.Action == Database_Action.Add).Select(t => t.TableName).Distinct().ToArray();
           
           foreach (string eachTable in tables_Add)
           {
               string[] rowNumbers = p_sms.DatabaseDetais.Where(t => t.Action == Database_Action.Add && t.TableName == eachTable).Select(t => t.RowNumber).Distinct().ToArray();
               foreach (string eachRowNumber in rowNumbers)
               {
                   StateMent = StateMent + " " + eachTable + " (";
                   var values = p_sms.DatabaseDetais.Where(t => t.Action == Database_Action.Add && t.TableName == eachTable && t.RowNumber == eachRowNumber).Select(t => new { Column = t.FieldName, Value = t.Value }).ToList();
                   int k = 1;
                   for (int i = 0; i < values.Count; i++)
                   {
                       if (k < values.Count)
                           StateMent = StateMent + values[i].Column + ",";
                       else
                           StateMent = StateMent + values[i].Column;
                       k++;
                   }
                   StateMent = StateMent + ") " + "VALUES(";

                   k = 1;
                   for (int i = 0; i < values.Count; i++)
                   {
                       if (k < values.Count)
                           StateMent = StateMent + values[i].Value + ",";
                       else
                           StateMent = StateMent + values[i].Value;
                       k++;
                   }
                   StateMent = StateMent + ");";
                   result.Add(StateMent);
                   StateMent = StartStateMent;
               }
           }
           
           return result;
       }

       #region NoWork
       //public void InsertMessage()
       //{
       //    SmsDeliverPdu data = new SmsDeliverPdu();
       //    System.Windows.Forms.ListViewItem Item = new  System.Windows.Forms.ListViewItem(data.OriginatingAddress);        
       //    objParsedSMS.FromMobileNo = data.OriginatingAddress;
       //    objParsedSMS.SMSText = data.UserDataText;                  
       //    long dCustCode = 0;
       //    string sCode = "";
       //    string[] word = objParsedSMS.SMSText.Split(',');
          
       //    if (word.Length == 1)
       //    {
       //        dCustCode = 0;
       //        objParsedSMS.SMSText = word[0];
       //    }
       //    if (word.Length > 1 && word.Length <= 2)
       //    {
       //        if (word[1] != "")
       //        {
       //            dCustCode = Convert.ToInt64(Convert.ToString(word[0]) == string.Empty ? "0" : Convert.ToString(word[0]));
       //            objParsedSMS.SMSText = word[1];
       //        }
       //    }
       //    if (word.Length == 5 && IsTextValidated(word[0].ToString()) == true)
       //    {
       //        dCustCode = Convert.ToInt64(word[0]);
       //    }
       //    objParsedSMS.Cust_Code = GetCustomerID_FromReg(dCustCode, objParsedSMS.FromMobileNo);
       //    if (objParsedSMS.SMSText.Length > 2 && objParsedSMS.SMSText.Length < 4)
       //    {
       //        sCode = objParsedSMS.SMSText.Substring(0, 3);
       //    }
       //    else if (objParsedSMS.SMSText.Length == 2)
       //    {
       //        sCode = objParsedSMS.SMSText.Substring(0, 2);
       //    }

       //    string ShortName = objParsedSMS.SMSText;           
       //    objParsedSMS.CompanyShortName = GetIPOCompanyShortName_FromReg(ShortName);
       //    objParsedSMS.PaymentType = objParsedSMS.SMSText;
       //    objParsedSMS.RefundType = objParsedSMS.SMSText;
       //    //objParsedSMS.SMSDateTime = Convert.ToDateTime(String.Format("{0:dd-MMM-yyyy HH:mm:ss tt}", System.DateTime.Now));


       //    //objDataSqlQuery.InsertSMSfroIPO(objParsedSMS.CompanyShortName, objParsedSMS.Cust_Code, objParsedSMS.PaymentType, objParsedSMS.RefundType, objParsedSMS.FromMobileNo, objParsedSMS.SMSText, objParsedSMS.SMSDateTime);          
       //}
       #endregion


      
       public string GetIPOCompanyShortName_FromReg(string IPOCompanyShortName)
       {
           try
           {    
               string CompanyShortname = "";
               string cnn = SMS_Constant.CallCenter_ConnectionString;//DataAccessLayer.DbConnectionBasic.ConnectionStringSMSSender;
               SqlConnection aSqlConnection = new SqlConnection(cnn);
               DataSet aDataset = new DataSet();
               SqlDataAdapter aSqldataadapter = new SqlDataAdapter();
               string Query = "Select Company_Short_Code from tbl_IPOCompanyInfo where Company_Short_Code='" + IPOCompanyShortName + "'";
               
               aSqldataadapter.SelectCommand = new SqlCommand(Query, aSqlConnection);
               aSqldataadapter.Fill(aDataset);
               DataTable dt = new DataTable();

               dt = aDataset.Tables[0];               
               foreach (DataRow dr in dt.Rows)
               {
                   CompanyShortname= dr[0].ToString(); 
               }
               return CompanyShortname; 
           }
           catch (Exception)
           {
               throw;
           }
       }

     
       private bool IsTextValidated(string strTextEntry)
       {
           Regex objNotWholePattern = new Regex("[^0-9]");
           return !objNotWholePattern.IsMatch(strTextEntry)
                && (strTextEntry != "");
       }
    }
}
