using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DataAccessLayer;
using MySql.Data.MySqlClient;
using BusinessAccessLayer.Constants;
using System.Data.SqlClient;

namespace BusinessAccessLayer.BAL
{
    public class WebDataExportBAL
    {
        private DbConnection _dbConnection;
        MySqlConnection Webconnection;
        MySqlTransaction WebTransaction;

        string mySqlConnection = //"DRIVER={MySQL ODBC 3.51 Driver};" +
         
        
        //New Pattern
        //@"Server=prelude.websitewelcome.com;" +
        //"Port=3306;" +
        //"Database=ksclbdco_ks;" +
        //"User Id=ksclbdco;" +
        //"Password=16Dec08;" +
        //"Allow Zero Datetime=false;" +
        //"Convert Zero Datetime=true;";

        @"server= 148.72.232.146;
            userid=ksclbdco;
            Database=ksclbdco_ks;
            password=KoNcvt%hi2Upvj;
            database=ksclbdco_ks;";

        public WebDataExportBAL()
        {
            _dbConnection = new DbConnection();
            Webconnection = new MySqlConnection(mySqlConnection);
            WebTransaction = null;
        }

        public void Connect_SBP()
        {
            _dbConnection.ConnectDatabase();
            _dbConnection.StartTransaction();
        }

        public void Connect_Web()
        {
            Webconnection.Open();
            WebTransaction = Webconnection.BeginTransaction();
        }

        public void Connect_WithoutTransaction_SBP()
        {
            _dbConnection.ConnectDatabase();
            // _dbConnection.StartTransaction();
        }

        public void CloseConnection_SBP()
        {
            _dbConnection.ConnectDatabase();
        }

        public void CloseConnection_Web()
        {
            Webconnection.Close();
            WebTransaction = null;
        }


        public void Commit_SBP()
        {
            _dbConnection.Commit();

        }
        public void Commit_Web()
        {
            WebTransaction.Commit();
        }

        public void Rollback_SBP()
        {
            _dbConnection.Rollback();

        }
        public void Rollback_Web()
        {
            WebTransaction.Rollback();
        }

        public void Connect_SMS()
        {
            _dbConnection.ConnectDatabase_SMSSender();
            _dbConnection.StartTransaction_SMSSender();
        }

        public void Connect_WithoutTransaction_SMS()
        {
            _dbConnection.ConnectDatabase_SMSSender();
            //_dbConnection.StartTransaction_SMSSender();
        }

        public void CloseConnection_SMS()
        {
            _dbConnection.CloseDatabase_SMSSender();
        }

        public void Commit_SMS()
        {
            _dbConnection.Commit_SMSSender();
        }

        public void Rollback_SMS()
        {
            _dbConnection.Rollback_SMSSender();
        }

        public SqlConnection GetConnection()
        {
            return _dbConnection.GetConnection();
        }

        public void SetConnection(SqlConnection con)
        {
            _dbConnection.SetConnection(con);
        }

        public SqlConnection GetConnection_SMS()
        {
            return _dbConnection.GetConnection_SMSSender();
        }

        public void SetConnection_SMS(SqlConnection con)
        {
            _dbConnection.SetConnection_SMSSender(con);
        }

        public SqlTransaction GetTransaction()
        {
            return _dbConnection.GetTransaction();
        }

        public void SetTransaction(SqlTransaction trans)
        {
            _dbConnection.SetTransaction(trans);
        }

        public SqlTransaction GetTransaction_SMS()
        {
            return _dbConnection.GetTransaction_SMSSender();
        }

        public void SetTransaction_SMS(SqlTransaction trans)
        {
            _dbConnection.SetTransaction_SMSSender(trans);
        }


        public void CreateWeb2014Export_Temp()
        {
           
            string queryString = @"CREATE TABLE Web2014_DataExportTemp
                                (
                                    ref_1 varchar(200)
                                    ,ref_2 varchar(200)
                                    ,ref_3 varchar(200)
                                    ,ref_4 varchar(200)
                                    ,ref_5 varchar(200)
                                );";
            
            try
            {
                _dbConnection.ConnectDatabase();             
                _dbConnection.ExecuteNonQuery(queryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
         
        }

        public void CreateWeb2014_IPO_Export_Temp()
        {

            string queryString = @"CREATE TABLE Web2014_DataExportTemp
                                (
                                    ref_1 varchar(200)
                                    ,ref_2 varchar(200)
                                    ,ref_3 varchar(200)
                                    ,ref_4 varchar(200)
                                    ,ref_5 varchar(200)
                                );";

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(queryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }

        }

        public void DropWeb2014Export_Temp()
        {
          
            string queryString = @"DROP TABLE Web2014_DataExportTemp";

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(queryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }

        }

        public DataTable GetPendingMoneyWithdrawReq_FromWeb()
        {
            DataTable dt=new DataTable();
            MySqlConnection connection = new MySqlConnection(mySqlConnection);
            //MySqlTransaction trans = connection.BeginTransaction();
            try
            {
                string query = @"SELECT request_id
                                FROM  `money_withdrawal_request` 
                                WHERE STATUS =  'Pending'
                                GROUP BY request_id;";
                MySqlDataAdapter da = new MySqlDataAdapter(query, connection);
                connection.Open();
                da.Fill(dt);
                //trans.Commit();
            }
            catch (Exception ex)
            {
                //trans.Rollback();
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return dt;
        }

        public DataTable GetOpenUserQueryReq_FromWeb()
        {
            DataTable dt = new DataTable();
            MySqlConnection connection = new MySqlConnection(mySqlConnection);
            //MySqlTransaction trans = connection.BeginTransaction();
            try
            {
                string query = @"SELECT contact_us_id  
                            FROM  `contact_us` 
                            WHERE contact_status =  'Open'
                            GROUP BY contact_us_id ;"; 
                MySqlDataAdapter da = new MySqlDataAdapter(query, connection);
                connection.Open();
                da.Fill(dt);
                //trans.Commit();
            }
            catch (Exception ex)
            {
                //trans.Rollback();
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return dt;
        }

        public void InsertIntoWeb2014_DataExportTemp(DataTable dt)
        {
            //string queryString = "SELECT Code_No,Comp_Name,Comp_Short_Code,(SELECT Comp_Category FROM SBP_Comp_Category WHERE Comp_Cat_ID=SBP_Company.Comp_Cat_ID),Face_Value,Market_Lot,Share_Type FROM SBP_Company;";
            string queryString=string.Empty;
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();

                foreach (DataRow dr in dt.Rows)
                {
                    queryString = @"INSERT INTO Web2014_DataExportTemp(ref_1)VALUES('"+dr[0].ToString()+"')";
                    _dbConnection.ExecuteNonQuery(queryString);
                }
                _dbConnection.Commit();
            }
            catch (Exception exception)
            {
                _dbConnection.Rollback();
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }           
        }

        public DataTable GetBrokerInfo_ForWeb_2014()
        {
            DataTable dataTable;
            string queryString = @"SBPWebDataExport";
            //string queryString = "SELECT Code_No,Comp_Name,Comp_Short_Code,(SELECT Comp_Category FROM SBP_Comp_Category WHERE Comp_Cat_ID=SBP_Company.Comp_Cat_ID),Face_Value,Market_Lot,Share_Type FROM SBP_Company;";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@NavigationSwitch", SqlDbType.Int, 1);
                dataTable = _dbConnection.ExecuteProQuery(queryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dataTable;

        
        }
       
        public DataTable GetCompanyProfile_ForWeb_2014()//2
        {
            DataTable dataTable;
            string queryString = @"SBPWebDataExport";
            //string queryString = "SELECT Code_No,Comp_Name,Comp_Short_Code,(SELECT Comp_Category FROM SBP_Comp_Category WHERE Comp_Cat_ID=SBP_Company.Comp_Cat_ID),Face_Value,Market_Lot,Share_Type FROM SBP_Company;";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@NavigationSwitch", SqlDbType.Int, 2);
                dataTable = _dbConnection.ExecuteProQuery(queryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dataTable;


        }
        public DataTable GetCustomerProfile_ForWeb_2014()//3
        {
            DataTable dataTable;
            string queryString = @"SBPWebDataExport";
            //string queryString = "SELECT Code_No,Comp_Name,Comp_Short_Code,(SELECT Comp_Category FROM SBP_Comp_Category WHERE Comp_Cat_ID=SBP_Company.Comp_Cat_ID),Face_Value,Market_Lot,Share_Type FROM SBP_Company;";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@NavigationSwitch", SqlDbType.Int, 3);
                dataTable = _dbConnection.ExecuteProQuery(queryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dataTable;


        }
        public DataTable GetDseTradingDetail_ForWeb_2014()//4
        {
            DataTable dataTable;
            string queryString = @"SBPWebDataExport";
            //string queryString = "SELECT Code_No,Comp_Name,Comp_Short_Code,(SELECT Comp_Category FROM SBP_Comp_Category WHERE Comp_Cat_ID=SBP_Company.Comp_Cat_ID),Face_Value,Market_Lot,Share_Type FROM SBP_Company;";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@NavigationSwitch", SqlDbType.Int, 4);
                dataTable = _dbConnection.ExecuteProQuery(queryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dataTable;


        }
        public DataTable GetMoneyWithdrawalRequest_ForWeb_2014()//5
        {
            DataTable dataTable;
            string queryString = @"SBPWebDataExport";
            //string queryString = "SELECT Code_No,Comp_Name,Comp_Short_Code,(SELECT Comp_Category FROM SBP_Comp_Category WHERE Comp_Cat_ID=SBP_Company.Comp_Cat_ID),Face_Value,Market_Lot,Share_Type FROM SBP_Company;";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@NavigationSwitch", SqlDbType.Int, 5);
                dataTable = _dbConnection.ExecuteProQuery(queryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dataTable;


        }
        public DataTable GetMoneyBalance_ForWeb_2014()//6
        {
            DataTable dataTable;
            string queryString = @"SBPWebDataExport";
            //string queryString = "SELECT Code_No,Comp_Name,Comp_Short_Code,(SELECT Comp_Category FROM SBP_Comp_Category WHERE Comp_Cat_ID=SBP_Company.Comp_Cat_ID),Face_Value,Market_Lot,Share_Type FROM SBP_Company;";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@NavigationSwitch", SqlDbType.Int, 6);
                dataTable = _dbConnection.ExecuteProQuery(queryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dataTable;


        }
        public DataTable GetPaymentHistory_ForWeb_2014()//7
        {
            DataTable dataTable;
            string queryString = @"SBPWebDataExport";
            //string queryString = "SELECT Code_No,Comp_Name,Comp_Short_Code,(SELECT Comp_Category FROM SBP_Comp_Category WHERE Comp_Cat_ID=SBP_Company.Comp_Cat_ID),Face_Value,Market_Lot,Share_Type FROM SBP_Company;";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@NavigationSwitch", SqlDbType.Int, 7);
                dataTable = _dbConnection.ExecuteProQuery(queryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dataTable;


        }


        public DataTable GetPaymentHistory_ForWeb_2014_Update()//7
        {
            DataTable dataTable;
            string queryString = @"SBPWebDataExportUpdate";
            //string queryString = "SELECT Code_No,Comp_Name,Comp_Short_Code,(SELECT Comp_Category FROM SBP_Comp_Category WHERE Comp_Cat_ID=SBP_Company.Comp_Cat_ID),Face_Value,Market_Lot,Share_Type FROM SBP_Company;";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@NavigationSwitch", SqlDbType.Int, 7);
                dataTable = _dbConnection.ExecuteProQuery(queryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dataTable;


        }








        public DataTable GetShareDw_ForWeb_2014_Update()//10
        {
            DataTable dataTable;
            string queryString = @"SBPWebDataExportUpdate";
            //string queryString = "SELECT Code_No,Comp_Name,Comp_Short_Code,(SELECT Comp_Category FROM SBP_Comp_Category WHERE Comp_Cat_ID=SBP_Company.Comp_Cat_ID),Face_Value,Market_Lot,Share_Type FROM SBP_Company;";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@NavigationSwitch", SqlDbType.Int, 10);
                dataTable = _dbConnection.ExecuteProQuery(queryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dataTable;


        }










        public DataTable GetTransectionDetail_ForWeb_2014_Update()//11
        {
            DataTable dataTable;
            string queryString = @"SBPWebDataExportUpdate";
            //string queryString = "SELECT Code_No,Comp_Name,Comp_Short_Code,(SELECT Comp_Category FROM SBP_Comp_Category WHERE Comp_Cat_ID=SBP_Company.Comp_Cat_ID),Face_Value,Market_Lot,Share_Type FROM SBP_Company;";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@NavigationSwitch", SqlDbType.Int, 11);
                dataTable = _dbConnection.ExecuteProQuery(queryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dataTable;


        }





        public DataTable GetShareBalance_ForWeb_2014()//8
        {
            DataTable dataTable;
            string queryString = @"SBPWebDataExport";
            //string queryString = "SELECT Code_No,Comp_Name,Comp_Short_Code,(SELECT Comp_Category FROM SBP_Comp_Category WHERE Comp_Cat_ID=SBP_Company.Comp_Cat_ID),Face_Value,Market_Lot,Share_Type FROM SBP_Company;";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@NavigationSwitch", SqlDbType.Int, 8);
                dataTable = _dbConnection.ExecuteProQuery(queryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dataTable;


        }
        public DataTable GetShareBalanceDetail_ForWeb_2014()//9
        {
            DataTable dataTable;
            string queryString = @"SBPWebDataExport";
            //string queryString = "SELECT Code_No,Comp_Name,Comp_Short_Code,(SELECT Comp_Category FROM SBP_Comp_Category WHERE Comp_Cat_ID=SBP_Company.Comp_Cat_ID),Face_Value,Market_Lot,Share_Type FROM SBP_Company;";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@NavigationSwitch", SqlDbType.Int,9);
                dataTable = _dbConnection.ExecuteProQuery(queryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dataTable;


        }
        public DataTable GetShareDw_ForWeb_2014()//10
        {
            DataTable dataTable;
            string queryString = @"SBPWebDataExport";
            //string queryString = "SELECT Code_No,Comp_Name,Comp_Short_Code,(SELECT Comp_Category FROM SBP_Comp_Category WHERE Comp_Cat_ID=SBP_Company.Comp_Cat_ID),Face_Value,Market_Lot,Share_Type FROM SBP_Company;";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@NavigationSwitch", SqlDbType.Int,10);
                dataTable = _dbConnection.ExecuteProQuery(queryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dataTable;


        }
        public DataTable GetTransectionDetail_ForWeb_2014()//11
        {
            DataTable dataTable;
            string queryString = @"SBPWebDataExport";
            //string queryString = "SELECT Code_No,Comp_Name,Comp_Short_Code,(SELECT Comp_Category FROM SBP_Comp_Category WHERE Comp_Cat_ID=SBP_Company.Comp_Cat_ID),Face_Value,Market_Lot,Share_Type FROM SBP_Company;";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@NavigationSwitch", SqlDbType.Int, 11);
                dataTable = _dbConnection.ExecuteProQuery(queryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dataTable;


        }
        public DataTable GetContact_Us_ForWeb_2014()//12
        {
            DataTable dataTable;
            string queryString = @"SBPWebDataExport";
            //string queryString = "SELECT Code_No,Comp_Name,Comp_Short_Code,(SELECT Comp_Category FROM SBP_Comp_Category WHERE Comp_Cat_ID=SBP_Company.Comp_Cat_ID),Face_Value,Market_Lot,Share_Type FROM SBP_Company;";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@NavigationSwitch", SqlDbType.Int, 12);
                dataTable = _dbConnection.ExecuteProQuery(queryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dataTable;


        }
        public DataTable GetCompanyProfile()
        {
            DataTable dataTable;
            string queryString = "SELECT Code_No,Comp_Name,Comp_Short_Name,Comp_Group,Face_Value,Market_Lot,Share_Type FROM dbo.SBP_WebCompanyProfile";
            //string queryString = "SELECT Code_No,Comp_Name,Comp_Short_Code,(SELECT Comp_Category FROM SBP_Comp_Category WHERE Comp_Cat_ID=SBP_Company.Comp_Cat_ID),Face_Value,Market_Lot,Share_Type FROM SBP_Company;";
            try
            {
                _dbConnection.ConnectDatabase();
                dataTable = _dbConnection.ExecuteQuery(queryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dataTable;

        }

        public DataTable GetCustomerProfile()
        {
            DataTable dataTable;
            //string queryString = "SELECT SBP_Customers.Cust_Code,(SELECT '\"'+Cust_Name+'\"' FROM SBP_Cust_Personal_Info WHERE SBP_Cust_Personal_Info.Cust_Code=SBP_Customers.Cust_Code),(SELECT '\"'+Address1+'\"' FROM SBP_Cust_Contact_Info WHERE SBP_Cust_Contact_Info.Cust_Code=SBP_Customers.Cust_Code),'\"'+BO_ID+'\"',CASE WHEN(BO_Type_ID=1) THEN '\"I\"' ELSE '\"J\"' END,(SELECT '\"'+Phone+'\"' FROM SBP_Cust_Contact_Info WHERE SBP_Cust_Contact_Info.Cust_Code=SBP_Customers.Cust_Code),(SELECT '\"'+Mobile+'\"' FROM SBP_Cust_Contact_Info WHERE SBP_Cust_Contact_Info.Cust_Code=SBP_Customers.Cust_Code) FROM SBP_Customers,SBP_Service_Registration WHERE SBP_Customers.Cust_Code =SBP_Service_Registration.Cust_Code";
            /*string queryString = "SELECT SBP_Customers.Cust_Code,personal.Cust_Name,personal.Father_Name,personal.Gender,additional.Nationality,"+
                                 "personal.DOB,personal.Occupation,contact.Address1+contact.Address2+contact.Address3,SBP_Customers.BO_ID,"+
                                 "CASE WHEN(SBP_Customers.BO_Type_ID=1) THEN 'I' ELSE 'J' END,contact.Phone,contact.Mobile,SBP_Customers.Pin," +
                                 "bank.Bank_Name,bank.Branch_Name,bank.Account_No FROM SBP_Customers LEFT JOIN dbo.SBP_Cust_Personal_Info personal ON SBP_Customers.Cust_Code=personal.Cust_Code "+
                                 " LEFT JOIN dbo.SBP_Cust_Contact_Info contact ON SBP_Customers.Cust_Code=contact.Cust_Code "+
                                 " LEFT JOIN dbo.SBP_Cust_Additional_Info additional ON SBP_Customers.Cust_Code=additional.Cust_Code "+
                                 " LEFT JOIN dbo.SBP_Cust_Bank_Info bank ON SBP_Customers.Cust_Code=bank.Cust_Code "+
                                 " WHERE SBP_Customers.Cust_Code IN (SELECT Cust_Code FROM SBP_Service_Registration WHERE Web_Service=1)";*/
            string queryString = " SELECT Cust_Code ,Cust_Name , Father_Name , Gender , Nationality , Address,DOB ,Occupation ,BO_ID ,BO_Type ,Phone ,Mobile ,Pin ,Bank_Name ,Branch_Name ,Account_No FROM dbo.SBP_WebCustomerProfile";

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.TimeoutPeriod = 10000;
                dataTable = _dbConnection.ExecuteQuery(queryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dataTable;
            
        }

        public DataTable GetPaymentHistory()
        {
            DataTable dataTable;
            string queryString = "SELECT Cust_Code ,Received_Date ,Deposit_Withdraw ,Amount ,Description ,Payment_Media_No ,Voucher_SL_No FROM dbo.SBP_WebPaymenthistory";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.TimeoutPeriod = 10000;
                dataTable = _dbConnection.ExecuteQuery(queryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dataTable;
           
        }

        public DataTable GetShareBalance()
        {
            DataTable dataTable;
            string queryString = "SELECT Cust_Code ,Comp_short_Code ,Balance ,Matured_Balance ,Company_Group ,BuyAvg ,GainLoss FROM dbo.SBP_WebShareBalance";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.TimeoutPeriod = 10000;
                dataTable = _dbConnection.ExecuteQuery(queryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dataTable;
        }

        public DataTable GetShareBalanceDetails()
        {
            DataTable dataTable;
            string queryString = "SELECT Cust_Code ,Company_Short_Code ,Trade_Date ,Buy_Qty ,Sell_Qty ,Balance ,Remarks ,Buy_Total ,Buy_Avg ,Sell_Total , Sell_Avg FROM dbo.SBP_WebShareBalanceDetails ";
         try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.TimeoutPeriod = 10000;
                dataTable = _dbConnection.ExecuteQuery(queryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dataTable;
        }

        public DataTable GetShareDW()
        {
            DataTable dataTable;
            string queryString = "SELECT Cust_Code ,Received_Date ,Comp_Short_Code ,Quantity ,Deposit_Withdraw , No_Script ,Voucher_No  FROM dbo.SBP_WebShareDW";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.TimeoutPeriod = 10000;
                dataTable = _dbConnection.ExecuteQuery(queryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dataTable;
        }

        public DataTable GetTransactionDetails()
        {
            DataTable dataTable;
            string queryString = "SELECT Customer ,EventDate ,EventTime ,Instrument_Code ,BuySellFlag , Instrument_Catagory ,TradeQty ,TradePrice ,TotalShareValue, Commission ,UserID FROM dbo.SBP_WebTransactions";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.TimeoutPeriod = 10000;
                dataTable = _dbConnection.ExecuteQuery(queryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dataTable;
            
        }

        public DataTable GetTradeDetails()
        {
            DataTable dataTable;
            string queryString = "SELECT Instrument_Code ,Open_price ,High_Price ,Low_Price ,Close_Price ,Change ,Total_Trade ,Volume ,Trade_Value ,Trade_Date FROM dbo.SBP_WebTradeDetails";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.TimeoutPeriod = 10000;
                dataTable = _dbConnection.ExecuteQuery(queryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dataTable;
            
        }

        public DataTable GetMoneyBalance()
        {
            DataTable dataTable;
            
            string queryMoneyBalance = "SELECT Cust_Code,Balance,Deposit,Withdraw,Entry_Date,Matured_Balance,Gain_Loss,Market_Value FROM dbo.SBP_WebMoneyBalanceTemp";
             try
            {
                _dbConnection.ConnectDatabase();
                dataTable = _dbConnection.ExecuteQuery(queryMoneyBalance);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dataTable;
            
            
        }

        public void ProcessWebData()
        {
            string queryString = "SP_ProcessWebData";

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.TimeoutPeriod = 500;
                _dbConnection.ExecuteNonQuery(queryString);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
         
        }

        public DataTable GetDataWeb_AccountGroupingInfo()//11
        {
            DataTable dataTable;
            
//            string queryString = @"
//                                    Select 
//                                    'INSERT INTO ipo_parent_child(parent_id, child_id, child_name, child_account_type, child_BO_Id, owner_id)
//                                    VALUES('+Convert(varchar(100),Parent_Code)+','+Child_Code+','+''''+ISNULL(Child_Name,'')+''''+','+''''+ISNULL(Child_Account_Type,'')+''''+','+''''+ISNULL(Child_BO_ID,'')+''''+','+Convert(varchar(100),Owner_CustCode)+')'
//                                    From tbl_AccountGrouping_Info as info
//                                    Where 
//                                    --info.Last_Updated_Date>=ISNULL((Select MAX(t.ActivityDate) From tbl_WebImportExportLog as t Where t.ActivityName='AccountGroupingInfo' AND t.ActivityFlag='Export'),'2014-01-01') 
//                                    info.Parent_Code<>info.Child_Code
//                                    AND 
//                                    (
//                                        info.Parent_Code IN (Select reg.Cust_Code From tbl_Confirmation_SMS_Reg as reg Where reg.WebService=1)
//                                        OR
//                                        info.Child_Code IN (Select reg.Cust_Code From tbl_Confirmation_SMS_Reg as reg Where reg.WebService=1)
//                                    )
//                    ";

            string queryString = @"
                                    Select *,al.BankAccRouingNo as BankAccRouingNo
                                    From tbl_AccountGrouping_Info as info
                                    JOIN tbl_Customer_All as al
                                    ON info.Child_Code=al.Cust_Code
                                    Where 
                                    info.Parent_Code<>info.Child_Code
                                    AND 
                                    (
                                    info.Parent_Code IN (Select reg.Cust_Code From tbl_Confirmation_SMS_Reg as reg Where reg.WebService=1)
                                    )
                                    AND WebSyncFlag=0

            ";


            try
            {
                
                dataTable = _dbConnection.ExecuteQuery_SMSSender(queryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            
            return dataTable;


        }
        
        public DataTable GetData_IPOCompany_SessionInfo()//11
        {
            DataTable dataTable;
            
//            string queryString_Insert_ToTemp = @"
//                                    Select 
//                                    'INSERT INTO TempTable_NewEntryIPOCompany VALUE ('+ISNULL(CONVERT(VARCHAR(100),comp_sess.IPO_Company_ID),'0')+','+''''+ISNULL(comp_sess.Company_Name,'')+''''+','+''''+ISNULL(comp_sess.Company_Address,'')+''''+','+ISNULL(CONVERT(VARCHAR(100),comp_sess.IPO_Company_Bank_ID),'0')+','+''''+ISNULL(comp_sess.IPO_Company_Bank_Name,'')+''''+','+ISNULL(CONVERT(VARCHAR(100),comp_sess.IPO_Company_Branch_ID),'0')+','+''''+ISNULL(comp_sess.IPO_Company_Branch_Name,'')+''''+','+''''+ISNULL(comp_sess.IPO_Company_BankAcc_No,'')+''''+','+''''+ISNULL(comp_sess.IPO_Company_RoutingNo,'')+''''+')'
//                                    From [tbl_IPO_SessionforCompanyInfo] as comp_sess
//                                    Where comp_sess.[Status]=0
//
//            ";

            string queryString_Insert_ToTemp = @"
                                    Select  [ID]
                                  ,[Company_Short_Code]
                                  ,[Company_Name]
                                  ,[Company_Address]
                                  ,[IPO_SessionID]
                                  ,[IPO_SessionName]
                                  ,[No_Of_Share]
                                  ,[Amount]
                                  ,[ToTal_ShareValue]
                                  ,[Premium]
                                  ,( comp_sess.TotalAmount+(Select SUM(c.Ch_Rate) From [tbl_IPO_Charge] as c Where c.[Ch_Item] IN ('IPO App','IPO App Refund') ) )AS TotalAmount
                                  ,[CutofDate]
                                  ,[IPO_Company_ID]
                                  ,[IPO_Company_Name]
                                  ,[IPO_Company_Address]
                                  ,[IPO_Company_Bank_ID]
                                  ,[IPO_Company_Bank_Name]
                                  ,[IPO_Company_Branch_ID]
                                  ,[IPO_Company_Branch_Name]
                                  ,[IPO_Company_BankAcc_No]
                                  ,[IPO_Company_RoutingNo]
                                  ,[IPOSession_Desc]
                                  ,[Application_Type_ID]
                                  ,[Total_Share_Value]
                                  ,[IsMaturedForTrade]
                                  ,(CASE WHEN comp_sess.[Status]=0 THEN 1 ELSE 0 END ) AS [Status]
                                  ,[WebSyncFlag]                                 
                                    From [tbl_IPO_SessionforCompanyInfo] as comp_sess
                                    Where comp_sess.[Status]=0 AND comp_sess.WebSyncFlag=0

            ";


            try
            {
                dataTable = _dbConnection.ExecuteQuery_SMSSender(queryString_Insert_ToTemp);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            
            return dataTable;


        }

        public DataTable GetIpo_Session_For_IPO_Web_2015()//11
        {
            DataTable dataTable;
//          string queryString=@"
//                                Select
//                                ISNULL(CONVERT(VARCHAR(100),sess.ID),'0')
//                                ,ISNULL(sess.IPOSession_Name,'')
//                                ,ISNULL(sess.IPOSession_Desc,'')
//                                ,ISNULL(CONVERT(VARCHAR(100),sess.IPO_Company_ID),'0')
//                                ,ISNULL(CONVERT(VARCHAR(100),sess.Application_Type_ID),'0')
//                                ,CONVERT(VARCHAR(10),sess.Session_Date,111)
//                                ,CONVERT(VARCHAR(100),sess.No_Of_Share)
//                                ,CONVERT(VARCHAR(100),sess.Amount)
//                                ,CONVERT(VARCHAR(100),sess.Total_Share_Value)
//                                ,CONVERT(VARCHAR(100),sess.Premium)
//                                ,CONVERT(VARCHAR(100),sess.TotalAmount)
//                                ,ISNULL(CONVERT(VARCHAR(100),sess.IsMaturedForTrade),'0')
//                                ,CONVERT(VARCHAR(100),CASE WHEN sess.Status=0 THEN 1 ELSE 0 END)
//                                From SBP_IPO_Company_Info as comp
//                                JOIN SBP_IPO_Session as sess
//                                ON sess.IPO_Company_ID=comp.ID
//                                Where sess.[Status]=0            
//            ";

//          string queryString_Insert = @"
//                                    Select 
//                                    'INSERT INTO ipo_session VALUE ('+ISNULL(CONVERT(VARCHAR(100),sess.ID),'0')+','+''''+ISNULL(sess.IPOSession_Name,'')+''''+','+''''+ISNULL(sess.IPOSession_Desc,'')+''''+','+ISNULL(CONVERT(VARCHAR(100),sess.IPO_Company_ID),'0')+','+ISNULL(CONVERT(VARCHAR(100),sess.Application_Type_ID),'0')+','+''''+CONVERT(VARCHAR(10),sess.Session_Date,111)+''''+','+CONVERT(VARCHAR(100),sess.No_Of_Share)+','+CONVERT(VARCHAR(100),sess.Amount)+','+CONVERT(VARCHAR(100),sess.Total_Share_Value)+','+CONVERT(VARCHAR(100),sess.Premium)+','+CONVERT(VARCHAR(100),sess.TotalAmount)+','+ISNULL(CONVERT(VARCHAR(100),sess.IsMaturedForTrade),'0')+','+CONVERT(VARCHAR(100),CASE WHEN sess.Status=0 THEN 1 ELSE 0 END)+')'
//                                    From SBP_IPO_Company_Info as comp
//                                    JOIN SBP_IPO_Session as sess
//                                    ON sess.IPO_Company_ID=comp.ID
//                                    Where sess.[Status]=0
//          ";

            string queryString_Insert_ToTemp = @"
                                    Select 
                                    'INSERT INTO TempTable_NewEntryIPOSession VALUE ('+ISNULL(CONVERT(VARCHAR(100),comp_sess.IPO_SessionID),'0')+','+''''+ISNULL(comp_sess.IPO_SessionName,'')+''''+','+''''+ISNULL(comp_sess.IPOSession_Desc,'')+''''+','+ISNULL(CONVERT(VARCHAR(100),comp_sess.IPO_Company_ID),'0')+','+ISNULL(CONVERT(VARCHAR(100),comp_sess.Application_Type_ID),'0')+','+''''+CONVERT(VARCHAR(10),comp_sess.CutofDate,111)+''''+','+CONVERT(VARCHAR(100),comp_sess.No_Of_Share)+','+CONVERT(VARCHAR(100),comp_sess.Amount)+','+CONVERT(VARCHAR(100),comp_sess.Total_Share_Value)+','+CONVERT(VARCHAR(100),comp_sess.Premium)+','+CONVERT(VARCHAR(100),comp_sess.TotalAmount+(Select SUM(c.Ch_Rate) From [tbl_IPO_Charge] as c Where c.[Ch_Item] IN ('IPO App','IPO App Refund')))+','+ISNULL(CONVERT(VARCHAR(100),CONVERT(INT,comp_sess.IsMaturedForTrade)),'0')+','+CONVERT(VARCHAR(100),CASE WHEN comp_sess.[Status]=0 THEN 1 ELSE 0 END)+')'
                                    From [tbl_IPO_SessionforCompanyInfo] as comp_sess
                                    Where comp_sess.[Status]=0  
            ";
            try
            {
                _dbConnection.ConnectDatabase_SMSSender();
                dataTable = _dbConnection.ExecuteQuery_SMSSender(queryString_Insert_ToTemp);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase_SMSSender();
            }
            return dataTable;


        }

        public DataTable GetIpo_RecentIPOAccountBalance_ForWeb_UITransApplied()
        {
            DataTable dt;
            
            string queryString = @" 
                                        
                                        SELECT *
                                        FROM [dbksclCallCenter].[dbo].[tbl_Customer_IPO_Account]  as ipoAcc
                                        WHERE
                                        (     
                                            ipoAcc.Cust_Code IN (Select reg.Cust_Code From tbl_Confirmation_SMS_Reg as reg JOIN tbl_AccountGrouping_Info as acc ON reg.Cust_Code=acc.Child_Code Where reg.WebService=1)
                                            OR
                                            ipoAcc.Cust_Code IN (	
							                                            Select acc.Child_Code
							                                            From tbl_AccountGrouping_Info as acc
							                                            Where acc.Child_Code<>acc.Parent_Code
							                                            AND acc.Parent_Code IN (
														                                            Select reg.Cust_Code
														                                            From tbl_Confirmation_SMS_Reg as reg
														                                            Where reg.WebService=1
							                                            )
                                            )
                                        )
                                        AND ipoAcc.WebSyncFlag=0
                                        
                                    ";


            try
            {
                //_dbConnection.ConnectDatabase_SMSSender();
                dt = _dbConnection.ExecuteQuery_SMSSender(queryString);
                //dataTable_Update = _dbConnection.ExecuteQuery_SMSSender(queryString_Update);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                //_dbConnection.CloseDatabase_SMSSender();
            }

            return dt;
        }

        public void UploadDataWeb_RecentIPOAccountBalance_UITransApplied(DataTable dt)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = Webconnection;
                
                string queryForInsertTemp = string.Empty;
                string queryForDelete = string.Empty;
                foreach(DataRow dr in dt.Rows)
                {
                    queryForDelete = "DELETE FROM ipo_moneytransfer_request WHERE Cust_ID=" + dr["Cust_Code"] + "" + " AND Deposit_Withdraw=2" + ";";

                    cmd.CommandText = queryForDelete;
                    cmd.ExecuteNonQuery();
                    
                    queryForInsertTemp = @" 
                                    INSERT INTO ipo_moneytransfer_request(
                                        Cust_ID
                                        ,Received_Date
                                        ,Amount
                                        ,Deposit_Withdraw 
                                        ,Approval_Status
                                        ,Approval_Date
                                        ,Remarks
                                    ) VALUES(" + dr["Cust_Code"] + "," + "'" + dr["last_update"] + "'" + "," + dr["Balance"] + "," + "2" + "," + "1" + "," + "'" + dr["last_update"] +"'"+ "," + "'" + " " + "'" + ")" + ";";

                    cmd.CommandText = queryForInsertTemp;
                    cmd.ExecuteNonQuery();
                }
                
                //string finalCommandText =dropTempTable+" "+ queryCreateTemp + " " + queryForInsertTemp + " " + queryForInsertFromTemp + " " + queryForUpdate + " " + dropTempTable;
                //cmd.CommandText = finalCommandText;
                //cmd.ExecuteNonQuery();
                
                //_dbConnection.Commit_SMSSender();

                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateWebSyncFlag_RecentIPOAccountBalance(DataTable dt)
        {

            try
            {
                string query_Customer = string.Empty;

                foreach (DataRow dr in dt.Rows)
                {
                    query_Customer = "UPDATE [tbl_Customer_IPO_Account] SET [WebSyncFlag]=1 WHERE [Cust_Code] =" + dr["Cust_Code"] + "";
                    _dbConnection.ExecuteNonQuery_SMSSender(query_Customer);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable GetIpo_RecentTradeAccountBalance_ForWeb_UITransApplied()
        {
            DataTable dt;

            string queryString = @" 
                                        SELECT *
                                        FROM [dbksclCallCenter].[dbo].[tbl_Customer_Account] as trdAcc
                                        WHERE
                                        (     
                                            trdAcc.Cust_Code IN (Select reg.Cust_Code From tbl_Confirmation_SMS_Reg as reg Where reg.WebService=1)
                                        )
                                        AND trdAcc.WebSyncFlag=0
                                        
                                    ";


            try
            {
                //_dbConnection.ConnectDatabase_SMSSender();
                dt = _dbConnection.ExecuteQuery_SMSSender(queryString);
                //dataTable_Update = _dbConnection.ExecuteQuery_SMSSender(queryString_Update);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                //_dbConnection.CloseDatabase_SMSSender();
            }

            return dt;
        }

        public void UploadDataWeb_RecentTradeAccountBalance_UITransApplied(DataTable dt)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = Webconnection;

                string queryForUpdateTemp = string.Empty;
                
                foreach (DataRow dr in dt.Rows)
                {
                    queryForUpdateTemp = @" 
                                    UPDATE money_balance
                                    SET customer_id=" + dr["Cust_Code"] + ",balance=" + dr["Balance"] + ",deposit=" + dr["Deposit"] + ",withdraw=" + dr["Withdraw"] + ",matured_balance=" + dr["Balance"] + ",last_update='" + dr["last_update"] + @"' 
                                    WHERE customer_id=" + dr["Cust_Code"] + ";";

                    cmd.CommandText = queryForUpdateTemp;
                    cmd.ExecuteNonQuery();
                }

                //string finalCommandText =dropTempTable+" "+ queryCreateTemp + " " + queryForInsertTemp + " " + queryForInsertFromTemp + " " + queryForUpdate + " " + dropTempTable;
                //cmd.CommandText = finalCommandText;
                //cmd.ExecuteNonQuery();

                //_dbConnection.Commit_SMSSender();


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateWebSyncFlag_RecentTradeAccountBalance(DataTable dt)
        {

            try
            {
                string query_Customer = string.Empty;

                foreach (DataRow dr in dt.Rows)
                {
                    query_Customer = "UPDATE [tbl_Customer_Account] SET [WebSyncFlag]=1 WHERE [Cust_Code] =" + dr["Cust_Code"] + "";
                    _dbConnection.ExecuteNonQuery_SMSSender(query_Customer);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        public void UploadDataWeb_SessionInfo(DataTable dt)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = Webconnection;
            
            try
            {
                foreach (DataRow dr in dt.Rows)
                {
                    string deleteQuery = "DELETE FROM ipo_session WHERE id=" + dr["IPO_SessionID"] + ";";
                    cmd.CommandText = deleteQuery;
                    cmd.ExecuteNonQuery();

                    string InsertQuery = "INSERT INTO ipo_session VALUE ("+dr["IPO_SessionID"]+","+"'"+dr["IPO_SessionName"]+"'"+","+"'"+dr["IPOSession_Desc"]+"'"+","+dr["IPO_Company_ID"]+","+dr["Application_Type_ID"]+","+"'"+dr["CutofDate"]+"'"+","+dr["No_Of_Share"]+","+dr["Amount"]+","+dr["Total_Share_Value"]
                        +","+dr["Premium"]+","+dr["TotalAmount"]+","+dr["IsMaturedForTrade"]+","+dr["Status"]+")"+@";";
                    cmd.CommandText = InsertQuery;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UploadDataWeb_CompanyInfo(DataTable dt)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = Webconnection;
            
            try
            {
                
                foreach(DataRow dr in dt.Rows)
                {
                    string deleteCompany = "DELETE FROM ipo_company WHERE id=" + Convert.ToString(dr["IPO_Company_ID"]) + @";";
                        cmd.CommandText = deleteCompany;
                        cmd.ExecuteNonQuery();

                        string queryInsertFromTemp = "INSERT INTO ipo_company VALUE (" + dr["IPO_Company_ID"] + "," + "'" + dr["Company_Name"] + "'" + "," + "'" + dr["Company_Address"] + "'" + "," + dr["IPO_Company_Bank_ID"] + "," + "'" + dr["IPO_Company_Bank_Name"] + "'" + "," + dr["IPO_Company_Branch_ID"] + "," + "'" + dr["IPO_Company_Branch_Name"] + "'" + "," + "'" + dr["IPO_Company_BankAcc_No"] + "'" + "," + "'" + dr["IPO_Company_RoutingNo"] + "'" + ")"+@";";
                        cmd.CommandText = queryInsertFromTemp;
                        cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
                        
        }

        public void UpdateWebSyncFlag_IPOCompany_SessionData(DataTable dt)
        {

            try
            {
                string query_Customer = string.Empty;

                foreach (DataRow dr in dt.Rows)
                {
                    query_Customer = "UPDATE [tbl_IPO_SessionforCompanyInfo] SET [WebSyncFlag]=1 WHERE [ID] =" + dr["ID"] + "";
                    _dbConnection.ExecuteNonQuery_SMSSender(query_Customer);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public void UploadDataWeb_AccountGroupingInfo(DataTable dt)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = Webconnection;

            try
            {
                string[] ParentCodeArray=dt.Rows.Cast<DataRow>().Select(t=> Convert.ToString(t["Parent_Code"])).Distinct().ToArray();
                foreach(string everyParentCode in ParentCodeArray)
                {
                    string deleteQuery = "DELETE FROM ipo_parent_child Where parent_id=" + everyParentCode + ";";
                    cmd.CommandText = deleteQuery;
                    cmd.ExecuteNonQuery();
                }

                foreach (DataRow dr in dt.Rows)
                {

                    string insertQuery = @"INSERT INTO ipo_parent_child(parent_id, child_id, child_name, child_account_type, child_BO_Id, owner_id, child_rounting_no)
                                    VALUES(" + dr["Parent_Code"] + "," + dr["Child_Code"] + "," + "'" + dr["Child_Name"] + "'" + "," + "'" + dr["Child_Account_Type"] + "'" + "," + "'" + dr["Child_BO_ID"] + "'" + "," + dr["Owner_CustCode"] + "," + "'" + dr["BankAccRouingNo"] + "'" + ");";
                    cmd.CommandText = insertQuery;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
            finally
            {
                
            }
        }

        public void UpdateWebSyncFlag_AccountGroupingInfo(DataTable dt)
        {

            try
            {
                string query_Customer = string.Empty;
                
                string[] ParentCodeArray = dt.Rows.Cast<DataRow>().Select(t => Convert.ToString(t["Parent_Code"])).Distinct().ToArray();
                foreach (string everyParentCode in ParentCodeArray)
                {
                    string queryCustomer = "UPDATE [tbl_AccountGrouping_Info] SET [WebSyncFlag]=1 WHERE [Parent_Code] ='" + everyParentCode + "'";
                    _dbConnection.ExecuteNonQuery_SMSSender(queryCustomer);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable GetData_IPoApplication_MoneyTransaction_UITransApllied()
        {
            DataTable dt = new DataTable();
            try
            {
               string queryString =
                                @"SELECT app.[ID]
                                  ,app.[Cust_Code]
                                  ,[IPO_Session_ID]
                                  ,[IPO_Session_Name]
                                  ,[Application_ID]
                                  ,app.[Status]
                                  ,[ChannelID]
                                  ,[ChannelType]
                                  ,[WebSyncFalg]
                                  ,[app_id]
                                  ,[App_With_IPO_MoneyTransfer_Request_ID]
                                  ,[Parent_With_IPO_MoneyTransfer_Request_ID]
                                  ,[child_Dep_IPO_MoneyTransfer_Request_ID]
                                  ,[FreeTrns_IPO_MoneyTransfer_Request_ID]
                                  ,[ActionDate] AS ActionDate
                                  ,[ActionDesc] AS ActionDesc  
                                FROM [tbl_IPO_SessionApplications] as app
                                JOIN [tbl_Web_Request] as req
                                ON app.[ChannelID]=req.ID
                                AND app.[ChannelType]='" +Indication_IPOPaymentTransaction.ChannelType_Web+@"'
                                AND app.WebSyncFalg=0";
               
                dt=_dbConnection.ExecuteQuery_SMSSender(queryString);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
            return dt;
        }

        public void UploadDataWeb_IPOApplication_MoneyTransaction_UITransApplied(DataTable dt)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = Webconnection;

            try
            {
                List<DataRow> ApplicationData_Approved = dt.Rows.Cast<DataRow>().Where(t => Convert.ToString(t["app_id"]) != string.Empty && Convert.ToString(t["app_id"]) != "0" && Convert.ToString(t["Status"]) == "Approved").ToList();
                List<DataRow> ApplicationData_Rejected = dt.Rows.Cast<DataRow>().Where(t => Convert.ToString(t["app_id"]) != string.Empty && Convert.ToString(t["app_id"]) != "0" && Convert.ToString(t["Status"]) == "Rejected").ToList();
                List<DataRow> App_WithData_Approved = dt.Rows.Cast<DataRow>().Where(t => Convert.ToString(t["App_With_IPO_MoneyTransfer_Request_ID"]) != string.Empty && Convert.ToString(t["App_With_IPO_MoneyTransfer_Request_ID"]) != "0" && Convert.ToString(t["Status"]) == "Approved").ToList();
                List<DataRow> App_WithData_Rejected = dt.Rows.Cast<DataRow>().Where(t => Convert.ToString(t["App_With_IPO_MoneyTransfer_Request_ID"]) != string.Empty && Convert.ToString(t["App_With_IPO_MoneyTransfer_Request_ID"]) != "0" && Convert.ToString(t["Status"]) == "Rejected").ToList();
                List<DataRow> Parent_WithData_Approved = dt.Rows.Cast<DataRow>().Where(t => Convert.ToString(t["Parent_With_IPO_MoneyTransfer_Request_ID"]) != string.Empty && Convert.ToString(t["Parent_With_IPO_MoneyTransfer_Request_ID"]) != "0" && Convert.ToString(t["Status"]) == "Approved").ToList();
                List<DataRow> Parent_WithData_Rejected = dt.Rows.Cast<DataRow>().Where(t => Convert.ToString(t["Parent_With_IPO_MoneyTransfer_Request_ID"]) != string.Empty && Convert.ToString(t["Parent_With_IPO_MoneyTransfer_Request_ID"]) != "0" && Convert.ToString(t["Status"]) == "Rejected").ToList();
                List<DataRow> child_DepData_Approved = dt.Rows.Cast<DataRow>().Where(t => Convert.ToString(t["child_Dep_IPO_MoneyTransfer_Request_ID"]) != string.Empty && Convert.ToString(t["child_Dep_IPO_MoneyTransfer_Request_ID"]) != "0" && Convert.ToString(t["Status"]) == "Approved").ToList();
                List<DataRow> child_DepData_Rejected = dt.Rows.Cast<DataRow>().Where(t => Convert.ToString(t["child_Dep_IPO_MoneyTransfer_Request_ID"]) != string.Empty && Convert.ToString(t["child_Dep_IPO_MoneyTransfer_Request_ID"]) != "0" && Convert.ToString(t["Status"]) == "Rejected").ToList();
                List<DataRow> FreeTrnsData_Approved = dt.Rows.Cast<DataRow>().Where(t => Convert.ToString(t["FreeTrns_IPO_MoneyTransfer_Request_ID"]) != string.Empty && Convert.ToString(t["FreeTrns_IPO_MoneyTransfer_Request_ID"]) != "0" && Convert.ToString(t["Status"]) == "Approved").ToList();
                List<DataRow> FreeTrnsData_Rejected = dt.Rows.Cast<DataRow>().Where(t => Convert.ToString(t["FreeTrns_IPO_MoneyTransfer_Request_ID"]) != string.Empty && Convert.ToString(t["FreeTrns_IPO_MoneyTransfer_Request_ID"]) != "0" && Convert.ToString(t["Status"]) == "Rejected").ToList();

              
                string query_ApplicationData=string.Empty;
                foreach (DataRow dr in ApplicationData_Approved)
                {
                    query_ApplicationData =query_ApplicationData+ @"UPDATE ipo_application SET Application_Satus=1,Action_Date='" + dr["ActionDate"] + "' ,Action_Description='" + dr["ActionDesc"] + "'" + " WHERE id=" + dr["app_id"] + ";";
                    cmd.CommandText = query_ApplicationData;
                    cmd.ExecuteNonQuery();
                }
                string query_App_WithData = string.Empty;
                foreach (DataRow dr in App_WithData_Approved)
                {
                    query_App_WithData =query_App_WithData+ @"UPDATE ipo_moneytransfer_request SET Approval_Status=1,Approval_Date='" + dr["ActionDate"] + "', Rejected_Reason='" + dr["ActionDesc"] + "'" + " WHERE IPO_MoneyTransfer_Request_ID=" + dr["App_With_IPO_MoneyTransfer_Request_ID"] + ";";
                    cmd.CommandText = query_App_WithData;
                    cmd.ExecuteNonQuery();
                }
                string query_Parent_WithData = string.Empty;
                foreach (DataRow dr in Parent_WithData_Approved)
                {
                    query_Parent_WithData =query_Parent_WithData+ @"UPDATE ipo_moneytransfer_request SET Approval_Status=1,Approval_Date='" + dr["ActionDate"] + "', Rejected_Reason='" + dr["ActionDesc"] + "'" + " WHERE IPO_MoneyTransfer_Request_ID=" + dr["Parent_With_IPO_MoneyTransfer_Request_ID"] + ";";
                    cmd.CommandText = query_Parent_WithData;
                    cmd.ExecuteNonQuery();
                }
                string query_child_DepData = string.Empty;
                foreach (DataRow dr in child_DepData_Approved)
                {
                    query_child_DepData =query_child_DepData+ @"UPDATE ipo_moneytransfer_request SET Approval_Status=1,Approval_Date='" + dr["ActionDate"] + "', Rejected_Reason='" + dr["ActionDesc"] + "'" + " WHERE IPO_MoneyTransfer_Request_ID=" + dr["child_Dep_IPO_MoneyTransfer_Request_ID"] + ";";
                    cmd.CommandText = query_child_DepData;
                    cmd.ExecuteNonQuery();
                }
                string query_FreeTrnsData = string.Empty;
                foreach (DataRow dr in FreeTrnsData_Approved)
                {
                    query_FreeTrnsData =query_FreeTrnsData+ @"UPDATE ipo_moneytransfer_request SET Approval_Status=1,Approval_Date='" + dr["ActionDate"] + "', Rejected_Reason='" + dr["ActionDesc"] + "'" + " WHERE IPO_MoneyTransfer_Request_ID=" + dr["FreeTrns_IPO_MoneyTransfer_Request_ID"] + ";";
                    cmd.CommandText = query_FreeTrnsData;
                    cmd.ExecuteNonQuery();
                }

                string query_ApplicationData_Rejected = string.Empty;
                foreach (DataRow dr in ApplicationData_Rejected)
                {
                    query_ApplicationData_Rejected = query_ApplicationData_Rejected + @"UPDATE ipo_application SET Application_Satus=4,Action_Date='" + dr["ActionDate"] + "' ,Action_Description='" + dr["ActionDesc"] + "'" + " WHERE id=" + dr["app_id"] + ";";
                    cmd.CommandText = query_ApplicationData_Rejected;
                    cmd.ExecuteNonQuery();
                }
                string query_App_WithData_Rejected = string.Empty;
                foreach (DataRow dr in App_WithData_Rejected)
                {
                    query_App_WithData_Rejected = query_App_WithData_Rejected + @"UPDATE ipo_moneytransfer_request SET Approval_Status=2,Approval_Date='" + dr["ActionDate"] + "', Rejected_Reason='" + dr["ActionDesc"] + "'" + " WHERE IPO_MoneyTransfer_Request_ID=" + dr["App_With_IPO_MoneyTransfer_Request_ID"] + ";";
                    cmd.CommandText = query_App_WithData_Rejected;
                    cmd.ExecuteNonQuery();
                }
                string query_Parent_WithData_Rejected = string.Empty;
                foreach (DataRow dr in Parent_WithData_Rejected)
                {
                    query_Parent_WithData_Rejected = query_Parent_WithData_Rejected + @"UPDATE ipo_moneytransfer_request SET Approval_Status=2,Approval_Date='" + dr["ActionDate"] + "', Rejected_Reason='" + dr["ActionDesc"] + "'" + " WHERE IPO_MoneyTransfer_Request_ID=" + dr["Parent_With_IPO_MoneyTransfer_Request_ID"] + ";";
                    cmd.CommandText = query_Parent_WithData_Rejected;
                    cmd.ExecuteNonQuery();
                }
                string query_child_DepData_Rejected = string.Empty;
                foreach (DataRow dr in child_DepData_Rejected)
                {
                    query_child_DepData_Rejected = query_child_DepData_Rejected + @"UPDATE ipo_moneytransfer_request SET Approval_Status=2,Approval_Date='" + dr["ActionDate"] + "', Rejected_Reason='" + dr["ActionDesc"] + "'" + " WHERE IPO_MoneyTransfer_Request_ID=" + dr["child_Dep_IPO_MoneyTransfer_Request_ID"] + ";";
                    cmd.CommandText = query_child_DepData_Rejected;
                    cmd.ExecuteNonQuery();
                }
                string query_FreeTrnsData_Rejected = string.Empty;
                foreach (DataRow dr in FreeTrnsData_Rejected)
                {
                    query_FreeTrnsData_Rejected = query_FreeTrnsData_Rejected + @"UPDATE ipo_moneytransfer_request SET Approval_Status=2,Approval_Date='" + dr["ActionDate"] + "', Rejected_Reason='" + dr["ActionDesc"] + "'" + " WHERE IPO_MoneyTransfer_Request_ID=" + dr["FreeTrns_IPO_MoneyTransfer_Request_ID"] + ";";
                    cmd.CommandText = query_FreeTrnsData_Rejected;
                    cmd.ExecuteNonQuery();
                }


//                connection.Open();
//                trans = connection.BeginTransaction();
//                string FinalQuery =
//                    query_ApplicationData + @" 
//                " + query_App_WithData + @"
//                " + query_Parent_WithData + @" 
//                " + query_child_DepData + @" 
//                " + query_FreeTrnsData + @"
//                " + query_ApplicationData_Rejected + @" 
//                " + query_App_WithData_Rejected + @"
//                " + query_Parent_WithData_Rejected + @" 
//                " + query_child_DepData_Rejected + @" 
//                " + query_FreeTrnsData_Rejected+""; 
//                cmd.CommandText = FinalQuery;
//                cmd.ExecuteNonQuery();
                //trans.Commit();
            }
            catch (Exception ex)
            {
                //trans.Rollback();
                throw new Exception(ex.Message);
            }
            finally
            {
                //connection.Close();
            }

        }

        public void UpdateWebSyncFlag_IPOApplication_MoneyTransaction_UITransApplied(DataTable dt)
        {
            
            try
            {
                string[] IDArray = dt.Rows.Cast<DataRow>().Select(t => Convert.ToString(t["ID"])).ToArray();
                string query_Customer = string.Empty;
                foreach (string id in IDArray)
                {
                    query_Customer = "UPDATE [tbl_IPO_SessionApplications] SET [WebSyncFalg]=1 WHERE [ID] IN (" + id + ")";
                    _dbConnection.ExecuteNonQuery_SMSSender(query_Customer);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        public DataTable GetData_FreeMoneyTransaction_UITransApplied()
        {
            DataTable dt = new DataTable();
            try
            {
                string queryString =
                                 @"SELECT st.[ID]
                                ,[Trans_ID]
                                ,st.[Cust_Code]
                                ,[Received_Date]
                                ,[Amount]
                                ,[Deposit_Withdraw]
                                ,[TransactionType]
                                ,[Trans_Reason]
                                ,st.[Remarks]
                                ,st.[Status]
                                ,[ActionDate]
                                ,[ActionDesc]
                                ,[ChannelID]
                                ,[ChannelType]
                                ,ISNULL(free.[FreeTrns_IPO_MoneyTransfer_Request_ID],0) AS [FreeTrns_IPO_MoneyTransfer_Request_ID]
                                ,ISNULL(freeTrta.Trade_With_IPO_MoneyTransfer_Request_ID,0) as [Trade_With_IPO_MoneyTransfer_Request_ID]
                                ,ISNULL(freeTrta.child_Dep_IPO_MoneyTransfer_Request_ID,0) as [child_Dep_IPO_MoneyTransfer_Request_ID]
                                ,[WebSyncFalg]
                                FROM [tbl_MoneyTransactionRequest_Status] as st
                                LEFT OUTER JOIN 
                                (Select * From tbl_Web_Request as t Where ISNULL(t.FreeTrns_IPO_MoneyTransfer_Request_ID,0)<>0) AS free
                                ON st.ChannelID=free.ID AND st.[WebSyncFalg]=0 AND st.[ChannelType]='" + Indication_IPOPaymentTransaction.ChannelType_Web + @"'
                                LEFT OUTER JOIN 
                                (Select * From tbl_Web_Request as t Where ISNULL(t.[Trade_With_IPO_MoneyTransfer_Request_ID],0)<>0 AND ISNULL(t.child_Dep_IPO_MoneyTransfer_Request_ID,0)<>0) AS freeTrta
                                ON st.ChannelID=freeTrta.ID AND st.[WebSyncFalg]=0 AND st.[ChannelType]='" + Indication_IPOPaymentTransaction.ChannelType_Web + @"'";
                dt = _dbConnection.ExecuteQuery_SMSSender(queryString);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
           
            return dt;
        }

        public void UploadDataWeb_FreeMoneyTransaction_UITransApplied(DataTable dt)
        {


            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = Webconnection;

            try
            {

                List<DataRow> TRTA_TradeData_Approved = dt.Rows.Cast<DataRow>().Where(t => Convert.ToString(t["Status"]) == "Approved" && Convert.ToInt32(t["Trade_With_IPO_MoneyTransfer_Request_ID"]) != 0 && Convert.ToInt32(t["child_Dep_IPO_MoneyTransfer_Request_ID"]) != 0).ToList();
                List<DataRow> TRTA_TradeData_Rejected = dt.Rows.Cast<DataRow>().Where(t => Convert.ToString(t["Status"]) == "Rejected" && Convert.ToInt32(t["Trade_With_IPO_MoneyTransfer_Request_ID"]) != 0 && Convert.ToInt32(t["child_Dep_IPO_MoneyTransfer_Request_ID"]) != 0).ToList();

                List<DataRow> TRTA_IPOData_Approved = dt.Rows.Cast<DataRow>().Where(t => Convert.ToString(t["Status"]) == "Approved" && Convert.ToInt32(t["Trade_With_IPO_MoneyTransfer_Request_ID"]) != 0 && Convert.ToInt32(t["child_Dep_IPO_MoneyTransfer_Request_ID"]) != 0).ToList();
                List<DataRow> TRTA_IPOData_Rejected = dt.Rows.Cast<DataRow>().Where(t => Convert.ToString(t["Status"]) == "Rejected" && Convert.ToInt32(t["Trade_With_IPO_MoneyTransfer_Request_ID"]) != 0 && Convert.ToInt32(t["child_Dep_IPO_MoneyTransfer_Request_ID"]) != 0).ToList();

                //TRTA Trade Data
                string query_TRTA_TradeData_Approved = string.Empty;
                foreach (DataRow dr in TRTA_TradeData_Approved)
                {
                    query_TRTA_TradeData_Approved = query_TRTA_TradeData_Approved + @"UPDATE money_withdrawal_request SET Status='Approved',action_date='" + dr["ActionDate"] + "'  WHERE request_id=" + dr["Trade_With_IPO_MoneyTransfer_Request_ID"] + ";";
                    cmd.CommandText = query_TRTA_TradeData_Approved;
                    cmd.ExecuteNonQuery();
                }

                string query_TRTA_TradeData_Rejected = string.Empty;
                foreach (DataRow dr in TRTA_TradeData_Rejected)
                {
                    query_TRTA_TradeData_Rejected = query_TRTA_TradeData_Rejected + @"UPDATE money_withdrawal_request SET Status='Rejected',action_date='" + dr["ActionDate"] + "' WHERE request_id=" + dr["Trade_With_IPO_MoneyTransfer_Request_ID"] + ";";
                    cmd.CommandText = query_TRTA_TradeData_Rejected;
                    cmd.ExecuteNonQuery();
                }

                
                //TRTA IPO Data
                string query_TRTA_IPOData_Approved = string.Empty;
                foreach (DataRow dr in TRTA_IPOData_Approved)
                {
                    query_TRTA_IPOData_Approved = query_TRTA_IPOData_Approved + @"UPDATE ipo_moneytransfer_request SET Approval_Status=1,Approval_Date='" + dr["ActionDate"] + "', Rejected_Reason='" + dr["ActionDesc"] + "'" + " WHERE IPO_MoneyTransfer_Request_ID=" + dr["child_Dep_IPO_MoneyTransfer_Request_ID"] + ";";
                    cmd.CommandText = query_TRTA_IPOData_Approved;
                    cmd.ExecuteNonQuery();
                }

                string query_TRTA_IPOData_Rejected = string.Empty;
                foreach (DataRow dr in TRTA_IPOData_Rejected)
                {
                    query_TRTA_IPOData_Rejected = query_TRTA_IPOData_Rejected + @"UPDATE ipo_moneytransfer_request SET Approval_Status=2,Approval_Date='" + dr["ActionDate"] + "', Rejected_Reason='" + dr["ActionDesc"] + "'" + " WHERE IPO_MoneyTransfer_Request_ID=" + dr["child_Dep_IPO_MoneyTransfer_Request_ID"] + ";";
                    cmd.CommandText = query_TRTA_IPOData_Rejected;
                    cmd.ExecuteNonQuery();
                }
                
                //Free IPO Data
                List<DataRow> FreeTrnsData_Approved = dt.Rows.Cast<DataRow>().Where(t => Convert.ToString(t["Status"]) == "Approved" && Convert.ToInt32(t["FreeTrns_IPO_MoneyTransfer_Request_ID"])!=0).ToList();
                List<DataRow> FreeTrnsData_Rejected = dt.Rows.Cast<DataRow>().Where(t => Convert.ToString(t["Status"]) == "Rejected" && Convert.ToInt32(t["FreeTrns_IPO_MoneyTransfer_Request_ID"]) != 0).ToList();

                string query_FreeTrnsData_Approved = string.Empty;
                foreach (DataRow dr in FreeTrnsData_Approved)
                {
                    query_FreeTrnsData_Approved = query_FreeTrnsData_Approved + @"UPDATE ipo_moneytransfer_request SET Approval_Status=1,Approval_Date='" + dr["ActionDate"] + "', Rejected_Reason='" + dr["ActionDesc"] + "'" + " WHERE IPO_MoneyTransfer_Request_ID=" + dr["FreeTrns_IPO_MoneyTransfer_Request_ID"] + ";";
                    cmd.CommandText = query_FreeTrnsData_Approved;
                    cmd.ExecuteNonQuery();
                }
                
                string query_FreeTrnsData_Rejected = string.Empty;
                foreach (DataRow dr in FreeTrnsData_Rejected)
                {
                    query_FreeTrnsData_Rejected = query_FreeTrnsData_Rejected + @"UPDATE ipo_moneytransfer_request SET Approval_Status=2,Approval_Date='" + dr["ActionDate"] + "', Rejected_Reason='" + dr["ActionDesc"] + "'" + " WHERE IPO_MoneyTransfer_Request_ID=" + dr["FreeTrns_IPO_MoneyTransfer_Request_ID"] + ";";
                    cmd.CommandText = query_FreeTrnsData_Rejected;
                    cmd.ExecuteNonQuery();
                }
                
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
            finally
            {
               
            }

        }

        public void UpdateWebSyncFlag_FreeMoneyTransaction_UITransApplied(DataTable dt)
        {

            try
            {
                string[] IDArray = dt.Rows.Cast<DataRow>().Select(t => Convert.ToString(t["ID"])).ToArray();
                
                string query_Customer = string.Empty;
                foreach (string id in IDArray)
                {
                    query_Customer = "UPDATE [tbl_MoneyTransactionRequest_Status] SET [WebSyncFalg]=1 WHERE [ID]=" + id + "";
                    _dbConnection.ExecuteNonQuery_SMSSender(query_Customer);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }            
        }

        public DataTable GetData_UpdatedRegistration_UITransApplied()
        {
            DataTable dt = new DataTable();
            try
            {
                string queryString =
                                 @"
                                    SELECT custAll.[Cust_Code]
                                          ,custAll.[Cust_Name]
                                          ,custAll.[Gender]
                                          ,custAll.[Guardian]
                                          ,custAll.[Mother_name]
                                          ,custAll.[Father_Husband_Name]
                                          ,custAll.[Cust_Address]
                                          ,custAll.[telephone]
                                          ,custAll.[mobile]
                                          ,custAll.[nationality]
                                          ,custAll.[Recidency]
                                          ,custAll.[DateOfBirth]
                                          ,custAll.[Occupation]
                                          ,custAll.[authorized_name]
                                          ,custAll.[authorized_address]
                                          ,custAll.[PinCode]
                                          ,custAll.[BankName]
                                          ,custAll.[BranchName]
                                          ,custAll.[BankAccoNo]
                                          ,custAll.[BankAccRouingNo]
                                          ,custAll.[bo_id]
                                          ,custAll.[BO_Status]
                                          ,custAll.[BO_Open_date]
                                          ,custAll.[BO_Close_date]
                                          ,custAll.[AC_Type]
                                          ,custAll.[AC_Status]
                                          ,custAll.[AC_Closed_date]
                                    FROM [tbl_Customer_All] as custAll
                                    JOIN [tbl_Confirmation_SMS_Reg] AS reg
                                    ON custAll.Cust_Code=reg.Cust_Code
                                    Where reg.WebService=1 AND reg.WebSyncFlag=0
                            ";

                
                dt = _dbConnection.ExecuteQuery_SMSSender(queryString);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
           
            return dt;
        }

        public void UploadDataWeb_CustomerProfile_UITransApplied(DataTable dt)
        {

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = Webconnection; 

            try
            {
                string query_Customer = string.Empty;
                string query_delete = string.Empty;
                foreach (DataRow dr in dt.Rows)
                {
                    query_delete = string.Empty;
                    query_delete = "DELETE FROM customer_profile WHERE customer_id =" + dr["Cust_Code"] + ";";
                    cmd.CommandText = query_delete;
                    cmd.ExecuteNonQuery();

                    query_Customer = string.Empty;
                    query_Customer = @"
                    INSERT INTO `customer_profile`(`customer_id`, `name`, `father_husband_name`, `mother_name`, `sex`, `nationality`, `date_of_birth`, `occupation`, `address`, `bo_id`, `ac_type`, `telephone`, `mobile`, `pincode`, `bank_name`, `bank_branch_name`, `bank_account_no`, `bank_account_routing_no`, `bo_status`)
                    VALUES(" + dr["Cust_Code"] +
                             "," + "'" + dr["Cust_Name"] + "'" +
                             "," + "'" + dr["Father_Husband_Name"] + "'" +
                             "," + "'" + dr["Mother_name"] + "'" + 
                             "," + "'" + dr["Gender"] + "'" + 
                             "," + "'" + dr["nationality"] + "'" + 
                             "," + "'" + dr["DateOfBirth"] + @"'" + 
                             "," + "'" + dr["Occupation"] + "'" + 
                             "," + "'" + dr["Cust_Address"] + "'" + 
                             "," + "'" + dr["bo_id"] + "'" + 
                             "," + "'" + dr["AC_Type"] + "'" + 
                             "," + "'" + dr["telephone"] + "'" + 
                             "," + "'" + dr["mobile"] + "'" + 
                             "," + "'" + dr["PinCode"] + "'"
                             + "," + "'" + dr["BankName"] + "'" + 
                             "," + "'" + dr["BranchName"] + "'" + 
                             "," + "'" + dr["BankAccoNo"] + "'" + 
                             "," + "'" + dr["BankAccRouingNo"]+ "'"+
                             ","+ "'" + dr["BO_Status"] + "'"+");";
                    cmd.CommandText = query_Customer;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public void UpdateWebSyncFlag_CustomerProfile_UITransApplied(DataTable dt)
        {

            try
            { 
                string[] cust_CodeArray = dt.Rows.Cast<DataRow>().Select(t => Convert.ToString(t["Cust_Code"])).ToArray();
                string query_Customer = string.Empty;
                foreach (string Cust_Code in cust_CodeArray)
                {
                    query_Customer = "UPDATE [tbl_Confirmation_SMS_Reg] SET [WebSyncFlag]=1 WHERE [Cust_Code]=" + Cust_Code + "";
                    _dbConnection.ExecuteNonQuery_SMSSender(query_Customer);
                }
            }
            catch (Exception ex)
            {
               throw new Exception(ex.Message);
            }
           
        }

        public void DeleteData_Customer_Profile_UITransApplied(DataTable dt)
        {

            MySqlConnection connection = new MySqlConnection(mySqlConnection);
            MySqlTransaction trans = null;

            string query = string.Empty;
            string[] Cust_Code = dt.Rows.Cast<DataRow>().Select(t => Convert.ToString(t["Cust_Code"])).ToArray();
            string JoinedCust_Code = (Cust_Code.Length > 0 ? String.Join(",", Cust_Code) : "0");
            query = "DELETE FROM customer_profile WHERE customer_id IN (" + JoinedCust_Code + ");";

            CommonBAL comBAL = new CommonBAL();
            

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;

                connection.Open();
                trans = connection.BeginTransaction();
                string FinalQuery = query;
                cmd.CommandText = FinalQuery;
                cmd.ExecuteNonQuery();
                trans.Commit();
            }
            catch (Exception exception)
            {
                trans.Rollback();
                throw new Exception(exception.Message);
            }
            finally
            {
                connection.Close();
            }
        }
      

        

    }
}
