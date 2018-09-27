using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using System.Data;
using System.Data.SqlClient;

namespace ElectronicCommunication.SMS
{
   public class DataSqlQuery
    {

        private DbConnection _dbConnection;
        public DataSqlQuery()
        {
            _dbConnection = new DbConnection();
            _dbConnection.ConnectionStringSMSSender = SMS_Constant.CallCenter_ConnectionString;
            aDbConnection.ConnectionStringSMSSender = SMS_Constant.CallCenter_ConnectionString;
        }
       public DbConnection aDbConnection = new DbConnection();


       public void InsertReceiveSMS(string Cust_Code, string Sender, string ShortCode, string Full_Message, string ReceiveTime, string Status, string EntryTime)
       {
           try
           {
               string sSQL = "INSERT INTO tbl_Received_ALL_SMS (Cust_Code,Sender, Short_Code, Full_Message, Received_Time,Status,EntryTime)" +
               " Values('" +(Cust_Code)+ "','" + Sender + "','" + ShortCode + "','" + Full_Message + "','" + ReceiveTime + "','" + Status + "','" + EntryTime + "')";
               aDbConnection.ConnectDatabase_SMSSender();
               aDbConnection.ExecuteNonQuery_SMSSender(sSQL);
           }
           catch (Exception exc)
           {
               throw exc;
           }
       }


       public void MoneyTransSMS_StatusUpdate(int SMSID)
       {
           try
           {
               string sSQL;
               //long ID = DBHandler.GenerateID("tbl_Notification", "ID");
               sSQL = "Update tbl_MoneyTransConfirmation_SMS set Status=1 where Status=0 and [SMSID]=" + SMSID;
               aDbConnection.ConnectDatabase_SMSSender();
               aDbConnection.ExecuteNonQuery_SMSSender(sSQL);
           }
           catch (Exception exc)
           {
               throw exc;
           }
       }
       public void InsertSMSfroIPORequest(string CompanyShortName, string Cust_Code, string PaymentType, string RefundType, string ReceivedNumber, string ReferenceNumber, string Text, DateTime DataTime, string Remarks, string Status, string Application_Status)
       {
           try
           {
               string sSQL = "INSERT INTO tbl_IPO_Request (CompanyShortName,Cust_Code, PaymentType, RefundType, ReceivedNumber,ReferenceNumber,Text,DataTime,Remarks,Status,Application_Status)" +
               " Values(" + CompanyShortName + ",'" + Cust_Code + "','" + PaymentType + "','" + RefundType + "','" + ReceivedNumber + "','" + ReferenceNumber + "','" + Text + "','" + DataTime + "','" + Remarks + "','" + Status + "','" + Application_Status + "')";
               aDbConnection.ConnectDatabase_SMSSender();
               aDbConnection.ExecuteNonQuery_SMSSender(sSQL);
           }
           catch (Exception exc)
           {
               throw exc;
           }
       }

       public DataTable GetCompanyShortCode()
       {
           DataTable dataTable = new DataTable();
           string queryString = "";
           queryString = "Select Company_Short_Code from tbl_IPO_SessionforCompanyInfo";
           try
           {
               _dbConnection.ConnectDatabase_SMSSender();
               dataTable = _dbConnection.ExecuteQuery_SMSSender(queryString);
           }
           catch (Exception)
           {
               throw;
           }
           finally
           {
               _dbConnection.CloseDatabase();
           }
           return dataTable;          
       }

       public String CompanyShortCode()
       {
           string Qry = "Select Company_Short_Code from tbl_IPO_SessionforCompanyInfo";
           _dbConnection.ConnectDatabase_SMSSender();
           DataTable MyData = _dbConnection.ExecuteQuery_SMSSender(Qry);
           return MyData.Rows[0][0].ToString();
       }

       


       public string ReceiveID()
       {
           string Qry = "Select ID from [tbl_Received_ALL_SMS] Order by ID DESC";
           _dbConnection.ConnectDatabase_SMSSender();
           DataTable MyData = _dbConnection.ExecuteQuery_SMSSender(Qry);
           return MyData.Rows[0][0].ToString();
       }

       public string IPOSMSType(string ID)
       {
           string Qry = "Select * from dbo.tbl_IPO_SMS_Type Where ID='" + ID + "'";
           _dbConnection.ConnectDatabase_SMSSender();
           DataTable MyData = _dbConnection.ExecuteQuery_SMSSender(Qry);
           return MyData.Rows[0][1].ToString();
       }

       public string GetReceiveMessage(string ReceiveID)
       {
           string Qry = "Select Full_Message from dbo.tbl_Received_ALL_SMS Where ID='" + ReceiveID + "'";
           _dbConnection.ConnectDatabase_SMSSender();
           DataTable MyData = _dbConnection.ExecuteQuery_SMSSender(Qry);
           return MyData.Rows[0][0].ToString();
       }


       public string GetRegCustCodeFromCustCode(string CustCode)
       {

           try
           {
               string result = "";
               //string CompanyShortname = "";
               string cnn = SMS_Constant.CallCenter_ConnectionString; //DataAccessLayer.DbConnectionBasic.ConnectionStringSMSSender;
               SqlConnection aSqlConnection = new SqlConnection(cnn);
               DataSet aDataset = new DataSet();
               SqlDataAdapter aSqldataadapter = new SqlDataAdapter();
               string Query = "Select Cust_Code from tbl_Confirmation_SMS_Reg where Cust_Code='" + CustCode + "'";

               aSqldataadapter.SelectCommand = new SqlCommand(Query, aSqlConnection);
               aSqldataadapter.Fill(aDataset);
               DataTable dt = new DataTable();

               dt = aDataset.Tables[0];
               foreach (DataRow dr in dt.Rows)
               {
                   result = dr[0].ToString();
               }
               return result;
           }
           catch (Exception)
           {
               throw;
           }

       }


       public string GetCustCodeFromPhoneNo(string PhoneNo)
       {

           try
           {
               if (PhoneNo.Length > 11 || PhoneNo.Length == 11)
               {
                   PhoneNo = PhoneNo.Replace("+880", "0");
               }
               string result = string.Empty;               
               //string CompanyShortname = "";
               string cnn = SMS_Constant.CallCenter_ConnectionString; //DataAccessLayer.DbConnectionBasic.ConnectionStringSMSSender;
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
                   result = dr[0].ToString();                  
                   
               }
               if (result == "")
               {
                   result = "0";
               }               
               return result;
           }
           catch (Exception)
           {
               throw;
           }

       }

       #region MultipleCustCode
      public List<string> GetCustCodeMultipleFromPhoneNo(string PhoneNo)
       {

           try
           {
               if (PhoneNo.Length > 11 || PhoneNo.Length == 11)
               {
                   PhoneNo = PhoneNo.Replace("+880", "0");
               }               
               List<string> listresult = new List<string>();              
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
                   listresult.Add(dr[0].ToString());
                   
               }               
               return listresult;
           }
           catch (Exception)
           {
               throw;
           }

       }
       #endregion


      #region ParentChildCheck
      public List<string> GetParentChildCheckFormCustCode(string Cust_Code)
      {

          try
          {
              
              List<string> result = new List<string>();               
              string cnn = SMS_Constant.CallCenter_ConnectionString;
              SqlConnection aSqlConnection = new SqlConnection(cnn);
              DataSet aDataset = new DataSet();
              SqlDataAdapter aSqldataadapter = new SqlDataAdapter();
              string Query = "SELECT [Registration_ID],[Parent_Code],[Child_Code],[Owner_CustCode],[Owner_Parent_Name] ,[Owner_Mobile] FROM [tbl_AccountGrouping_Info] as info WHERE info.Parent_Code='"+Cust_Code+"' OR info.Parent_Code=( Select t.Parent_Code From [tbl_AccountGrouping_Info] as t Where t.Child_Code='"+Cust_Code+"') OR  info.Owner_CustCode='" + Cust_Code + "'";

              aSqldataadapter.SelectCommand = new SqlCommand(Query, aSqlConnection);
              aSqldataadapter.Fill(aDataset);
              DataTable dt = new DataTable();

              dt = aDataset.Tables[0];
            
                  foreach (DataRow dr in dt.Rows)
                  {
                      result.Add(dr[2].ToString());                
                  }             
              return result;
          }
          catch (Exception)
          {
              throw;
          }

      }
      #endregion

      public long GetCustCodeFromPhoneNoBuySell(string PhoneNo)
       {

           try
           {
               long result =0;
               //string CompanyShortname = "";
               string cnn = SMS_Constant.CallCenter_ConnectionString; //DataAccessLayer.DbConnectionBasic.ConnectionStringSMSSender;
               SqlConnection aSqlConnection = new SqlConnection(cnn);
               DataSet aDataset = new DataSet();
               SqlDataAdapter aSqldataadapter = new SqlDataAdapter();
               string Query = "Select Cust_Code from tbl_Confirmation_SMS_Reg Where Mobile='" + PhoneNo + "'";

               aSqldataadapter.SelectCommand = new SqlCommand(Query, aSqlConnection);
               aSqldataadapter.Fill(aDataset);
               DataTable dt = new DataTable();

               dt = aDataset.Tables[0];
               //foreach (DataRow dr in dt.Rows)
               //{
               //    result =(dr[0].ToString());
               //}
               return result;
           }
           catch (Exception)
           {
               throw;
           }

       }

       public string GetCompanyShortCodeFromCompanyShortCode(string CompanyCode)
       {

           try
           {
               string result = string.Empty;
               //string CompanyShortname = "";
               string cnn = SMS_Constant.CallCenter_ConnectionString; //DataAccessLayer.DbConnectionBasic.ConnectionStringSMSSender;
               SqlConnection aSqlConnection = new SqlConnection(cnn);
               DataSet aDataset = new DataSet();
               SqlDataAdapter aSqldataadapter = new SqlDataAdapter();
               string Query = "Select Company_Short_Code from tbl_company_all where Company_Short_Code='" + CompanyCode + "'";

               aSqldataadapter.SelectCommand = new SqlCommand(Query, aSqlConnection);
               aSqldataadapter.Fill(aDataset);
               DataTable dt = new DataTable();

               dt = aDataset.Tables[0];
               foreach (DataRow dr in dt.Rows)
               {
                   result = dr[0].ToString();
               }
               return result;
           }
           catch (Exception)
           {
               throw;
           }

       }


       public void IPOConfirmedStatusUpdate(string SMSSender)
       {
           try
           {
               string sSQL;
               sSQL = "Update tbl_IPO_Confirmation_SMS set status=1,DeliveryDateTime='" + String.Format("{0:dd-MMM-yyyy HH:mm:ss tt}", System.DateTime.Now) + "' where Status=0 and Destination=" + SMSSender;
               aDbConnection.ConnectDatabase_SMSSender();
               aDbConnection.ExecuteNonQuery_SMSSender(sSQL);
           }
           catch (Exception exc)
           {
               throw exc;
           }
       }


       public long GenerateOrderID(string sTableName, string sFieldName)
       {
           string cnn = SMS_Constant.CallCenter_ConnectionString; //DataAccessLayer.DbConnectionBasic.ConnectionStringSMSSender;
           SqlConnection conn = new SqlConnection(cnn);
           DataSet oDataSet = new DataSet();
           SqlDataAdapter SQLDbAdapter = new SqlDataAdapter();
           string query = "select isnull(max(cast(Order_Id as numeric)),0)+1 from tbl_order_place  where Order_Channel not in('Online')";
           SQLDbAdapter.SelectCommand = new SqlCommand(query, conn);
           SQLDbAdapter.Fill(oDataSet);
           DataTable dt = new DataTable();

           dt = oDataSet.Tables[0];

           long maxid = 0;

           foreach (DataRow dr in dt.Rows)
           {
               if (dr[0] == DBNull.Value)
               {
                   maxid = 100000000 + 1;
               }
               else
               {
                   maxid = Convert.ToInt64(dr[0].ToString());
               }
           }
           if (maxid <= 0)
           {
               maxid = 100000000 + 1;
           }
           else
           {
               maxid = maxid + 1;
           }
           return maxid;
       }



       public void ReceivedStatusUpdate(string SMSSender, string SMSShortCode)
       {
           try
           {
               string sSQL;              
               sSQL = "Update tbl_Received_SMS set status=1 where Status=0 and Sender='" + SMSSender + "' and Short_Code='" + SMSShortCode + "'";
               aDbConnection.ConnectDatabase_SMSSender();
               aDbConnection.ExecuteNonQuery_SMSSender(sSQL);

           }
           catch (Exception exc)
           {
               throw exc;
           }
       }

       public void DayendTradeConfirmedStatusUpdate(string SMSSender)
       {
           try
           {
               string sSQL;
               //long ID = DBHandler.GenerateID("tbl_Notification", "ID");
               sSQL = "Update tbl_Trade_Confirmation_SMS set status=1,DeliveryDateTime='" + String.Format("{0:dd-MMM-yyyy HH:mm:ss tt}", System.DateTime.Now) + "' where Status=0 and Destination=" + SMSSender;
               aDbConnection.ConnectDatabase_SMSSender();
               aDbConnection.ExecuteNonQuery_SMSSender(sSQL);
           }
           catch (Exception exc)
           {
               throw exc;
           }
       }

       public void TradeConfirmedStatusUpdate(string SMSSender)
       {
           try
           {
               string sSQL;              
               sSQL = "Update tbl_SMS_Server set status=1 where Status=0 and Destination=" + SMSSender;
               aDbConnection.ConnectDatabase_SMSSender();
               aDbConnection.ExecuteNonQuery_SMSSender(sSQL);
           }
           catch (Exception exc)
           {
               throw exc;
           }
       }



       public string GetNotRegisterMessage(string SMSID)
       {

           try
           {
              
               string result = string.Empty;               
               string cnn = SMS_Constant.CallCenter_ConnectionString;
               SqlConnection aSqlConnection = new SqlConnection(cnn);
               DataSet aDataset = new DataSet();
               SqlDataAdapter aSqldataadapter = new SqlDataAdapter();
               string Query = "Select Message from tbl_MessageStoreHouse where SMSID='" + SMSID + "'";

               aSqldataadapter.SelectCommand = new SqlCommand(Query, aSqlConnection);
               aSqldataadapter.Fill(aDataset);
               DataTable dt = new DataTable();

               dt = aDataset.Tables[0];
               foreach (DataRow dr in dt.Rows)
               {
                   result = dr[0].ToString();
               }
               if (result == "")
               {
                   result = "0";
               }
               return result;
           }
           catch (Exception)
           {
               throw;
           }

       }

       public List<string> GetIPOCompanyShortCodeSearch()
       {

           try
           {

               List<string> ResultList = new List<string>();
               string cnn = SMS_Constant.CallCenter_ConnectionString;
               SqlConnection aSqlConnection = new SqlConnection(cnn);
               DataSet aDataset = new DataSet();
               SqlDataAdapter aSqldataadapter = new SqlDataAdapter();
               string Query = "Select Company_Short_Code from dbo.tbl_IPO_SessionforCompanyInfo";

               aSqldataadapter.SelectCommand = new SqlCommand(Query, aSqlConnection);
               aSqldataadapter.Fill(aDataset);
               DataTable dt = new DataTable();

               dt = aDataset.Tables[0];
               foreach (DataRow dr in dt.Rows)
               {
                   ResultList.Add(dr[0].ToString());
                   
               }
               return ResultList;
           }
           catch (Exception)
           {
               throw;
           }

       }
      

    }
}
