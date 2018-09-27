using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccessLayer;

namespace BusinessAccessLayer.BAL
{
   public class IPOReportBAL
    {
       private DbConnection _dbConnection;

        public IPOReportBAL()
        {
            this._dbConnection = new DbConnection();
        }



        public DataTable GetIPOCustInfoByBOID(string boId)
        {
            DataTable dataTable;
            string queryString = "";
            queryString = "SELECT SBP_Customers.Cust_Code as 'Cust_Code',Cust_Name,BO_Id,ISNULL(dbo.GetLastTradeDateTimeByCust(dbo.GetCustCodeFromBO('" + boId + "')),'Not Yet Trade') AS 'LTD',(SELECT Cust_Status FROM SBP_Cust_Status WHERE SBP_Cust_Status.Cust_Status_ID=SBP_Customers.Cust_Status_ID)AS Status,(SELECT BO_Status FROM SBP_BO_Status WHERE BO_Status_ID=SBP_Customers.BO_Status_ID) AS 'BO_Status',ISNULL((SELECT SUM(Balance) FROM SBP_Share_Balance_Temp WHERE SBP_Share_Balance_Temp.Cust_Code=SBP_Customers.Cust_Code),0) AS Share_Balance,(SELECT BO_Type FROM SBP_BO_Type WHERE BO_Type_ID=SBP_Customers.BO_Type_ID AND SBP_Customers.BO_ID='" + boId + "') AS 'BO Type'  FROM SBP_Customers,SBP_Cust_Personal_Info WHERE BO_ID='" + boId + "' AND SBP_Customers.Cust_Code=SBP_Cust_Personal_Info.Cust_Code";
            try
            {
                _dbConnection.ConnectDatabase();
                dataTable = _dbConnection.ExecuteQuery(queryString);

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

        public DataTable GetIPOCustInfoByCustCode(string custCode)
        {
            DataTable dataTable;
            string queryString = "";
            queryString = "SELECT SBP_Customers.Cust_Code as 'Cust_Code',Cust_Name,BO_Id,ISNULL(dbo.GetLastTradeDateTimeByCust('" + custCode + "'),'Not Yet Trade') AS 'LTD',(SELECT Cust_Status FROM SBP_Cust_Status WHERE SBP_Cust_Status.Cust_Status_ID=SBP_Customers.Cust_Status_ID)AS Status,(SELECT BO_Status FROM SBP_BO_Status WHERE BO_Status_ID=SBP_Customers.BO_Status_ID) AS 'BO_Status',ISNULL((SELECT SUM(Balance) FROM SBP_Share_Balance_Temp WHERE SBP_Share_Balance_Temp.Cust_Code=SBP_Customers.Cust_Code),0)AS Share_Balance,(SELECT BO_Type FROM SBP_BO_Type WHERE BO_Type_ID=SBP_Customers.BO_Type_ID AND SBP_Customers.Cust_Code='" + custCode + "') AS 'BO Type' FROM SBP_Customers,SBP_Cust_Personal_Info WHERE SBP_Customers.Cust_Code='" + custCode + "' AND SBP_Customers.Cust_Code=SBP_Cust_Personal_Info.Cust_Code";
            try
            {
                _dbConnection.ConnectDatabase();
                dataTable = _dbConnection.ExecuteQuery(queryString);

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

        public DataTable GetIPOCustMoneyLedger(string custCode, DateTime fromDate, DateTime toDate)
        {
            DataTable dtShareDWReview = null;
            string quryString = "";
            quryString = @"RptIPOGetCustomerMoneyLedger";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@custCode", SqlDbType.NVarChar, custCode);
                _dbConnection.AddParameter("@fromDate", SqlDbType.DateTime, fromDate);
                _dbConnection.AddParameter("@toDate", SqlDbType.DateTime, toDate);
                dtShareDWReview = _dbConnection.ExecuteProQuery(quryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dtShareDWReview;

        }

        public DataTable GetIpoCustBasicInfo(string custCode)
        {
            DataTable dtShareDWReview = null;
            string quryString = "";

            quryString = "RptGetCustCodeName";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@custCode", SqlDbType.VarChar, custCode);
                dtShareDWReview = _dbConnection.ExecuteProQuery(quryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dtShareDWReview;

        }

        #region IPORequestToBlockIPOAmount
        public DataTable GetIPORequestToBlockIPOAmount(int SessionID)
        {
            DataTable dt = new DataTable();
            string query = @"rptIPORequestToBlockIPOAmount";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@SessionId", SqlDbType.Int, SessionID);
                dt = _dbConnection.ExecuteProQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dt;
        }
        #endregion

        #region Ipo Daily Report Method
        public DataTable GetDailyTransactionReport(DateTime? FromDate, DateTime? ToDate, string TransactionName, string StatusName, string sessionId)
        {
            DataTable dt = new DataTable();
            string query = @"RptIPODailyReport";
            string query2 = @"exec [RptIPODailyReport] '" + sessionId + "',null,null,'" + TransactionName + "','" + StatusName + "'";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                if (FromDate != null && ToDate != null)
                {
                    _dbConnection.AddParameter("@IPO_Session_ID", SqlDbType.VarChar, sessionId);
                    _dbConnection.AddParameter("@FromDate", SqlDbType.DateTime, FromDate);
                    _dbConnection.AddParameter("@ToDate", SqlDbType.DateTime, ToDate);
                    _dbConnection.AddParameter("@TransType", SqlDbType.VarChar, TransactionName);
                    _dbConnection.AddParameter("@Status", SqlDbType.VarChar, StatusName);
                    dt = _dbConnection.ExecuteProQuery(query);
                }
                else
                {
                    dt = _dbConnection.ExecuteProByText(query2);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dt;
        }
        #endregion

        #region Transaction Type and Transaction Status
        public DataTable GetTransactionStatus()
        {
            DataTable dt = new DataTable();
            string query = @"Select '' as ID,'ALL' as 'Status_Name'
                            UNION ALL
                            select ID,Status_Name from SBP_IPO_MoneyTrans_Status 
                            where ID NOT IN (3,4)";
            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dt;
        }
        public DataTable GetMoneyTransactionTypeName()
        {
            DataTable dt = new DataTable();
            string query = @"Select '' as ID,'ALL' as 'MoneyTransType_Name'
                            UNION ALL
                            select ID,MoneyTransType_Name from SBP_IPO_MoneyTrans_Type 
                            where ID NOT IN (4)";
            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dt;
        }
        #endregion

        #region Ipo Transfer Report

        public DataTable GetIpoTransferReport(string TransactionSearchName, DateTime fromdate, DateTime todate)
        {
            DataTable dt = new DataTable();
            string query = @"RptIPoTransferReport";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@TransactionSearchName", SqlDbType.VarChar, TransactionSearchName);
                _dbConnection.AddParameter("@FromDate", SqlDbType.DateTime, fromdate.ToShortDateString());
                _dbConnection.AddParameter("@ToDate", SqlDbType.DateTime, todate.ToShortDateString());
                dt = _dbConnection.ExecuteProQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this._dbConnection.CloseDatabase();
            }
            return dt;
        }

        #endregion

	    #region IPO Summary Application 
        public DataTable GetSessionName()
        {
            DataTable dt = new DataTable();
            string query = @"select ID,IpoSession_Name from SBP_IPO_Session";
            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dt;
        }

        public DataTable GetIpoSummaryOfApplicationBySessionId(int SessionId)
        {
            DataTable dt = new DataTable();
            string Query = @"RptIPOSummaryOfTheApplication";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@Session_ID", SqlDbType.Int, SessionId);
                dt = _dbConnection.ExecuteProQuery(Query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dt;
        }
        #endregion

        #region IPO Total Transaction List after results
        public DataTable LoadMoneyTransactionTypeName()
        {
            DataTable dt = new DataTable();
            string query = @"Select 0 As ID,'All' AS 'MoneyTransType_Name'
                            Union all
                            select ID,MoneyTransType_Name from SBP_IPO_MoneyTrans_Type where ID not in (4)";
            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dt;
        }
        public DataTable TotalTransactionstatusAfterResults(string PaymentName, int sessionId, DateTime Start, DateTime End)
        {
            DataTable dt = new DataTable();
            string query = @"rptIpo_MoneyTransaction_Status_After_Result";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.AddParameter("@Transaction_Type", SqlDbType.VarChar, PaymentName);
                _dbConnection.AddParameter("@Session_Id", SqlDbType.Int, sessionId);
                _dbConnection.AddParameter("@FormDate", SqlDbType.Date, Start.ToShortDateString());
                _dbConnection.AddParameter("@ToDate", SqlDbType.Date, End.ToShortDateString());
                dt = _dbConnection.ExecuteProQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dt;
        }
        #endregion

        #region IPO Share Balance Report
        /*
        Created By Rashedul Hasan
        On 25 Jan 2015	
        */
        public DataTable GetAllCustomerIPOBalance(DateTime Form, DateTime To)
        {
            DataTable dt = new DataTable();
            //string query = @"rptIPOCustomerSummaryBalanceLedger";
            string execQuery = @"Exec rptIPOCustomerSummaryBalanceLedger '" + Form + "'";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();

                _dbConnection.AddParameter("@Start_Date", SqlDbType.Date, Form.ToShortDateString());
                //_dbConnection.AddParameter("@End_Date", SqlDbType.Date, To);
                //dt = _dbConnection.ExecuteQuery(query);
                dt = _dbConnection.ExecuteProByText(execQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        #endregion

        #region IPO Deposit Summary Info

        public DataTable GetIPODepositSummaryInfo(string SessionId)
        {
            DataTable dt = new DataTable();
            string query = @"rptIPODepositSummaryInfo";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@IPOSessionID", SqlDbType.VarChar, SessionId);
                dt = _dbConnection.ExecuteProQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        #endregion


        #region IPO Forwarding Letter After Result
        public DataTable GetIPOForwardingLetterDataAfterResult(int sessionID, string App_ID)
        {
            DataTable dt = new DataTable();
            string query = "rptIPOForwardingLettertAfterResult";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@SessionId", SqlDbType.Int, sessionID);
                _dbConnection.AddParameter("@Application_No", SqlDbType.VarChar, App_ID);
                dt = _dbConnection.ExecuteProQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }

            return dt;
        }
        #endregion

        #region IPO Unblock And Transfer Letter
        public DataTable GetIPOUnblockAndTransferLetter(int IPOSessionID)
        {
            DataTable dt = new DataTable();
            string query = @"rptIPOUnblockAndTransferLetter";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@Session_ID", SqlDbType.Int, IPOSessionID);
                dt = _dbConnection.ExecuteProQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dt;
        }
        #endregion

        #region IPOSubmissionOfIPOcollectionFile_Hardcopy_And_Softcopy
            public DataTable GetIPOSubmissionOfIPOcollectionFile_Hardcopy_And_Softcopy(int session, string Name, string ApplicantCategory,string ReportType)
            {
                DataTable dt = new DataTable();
                string query = "";
                if (string.IsNullOrEmpty(ReportType))
                {
                    query = @"rptIPOSubmissionOfIPOcollectionFile_Hardcopy_And_Softcopy";
                }
                else if (ReportType == "Authorized")
                {
                    query = @"rptIPOAuthorizedPersonDeclaration";
                }
                try
                {
                    _dbConnection.ConnectDatabase();
                    _dbConnection.ActiveStoredProcedure();
                    _dbConnection.AddParameter("@Session", SqlDbType.Int, session);
                    _dbConnection.AddParameter("@Name", SqlDbType.VarChar, Name);
                    _dbConnection.AddParameter("@RB_NRB", SqlDbType.VarChar, ApplicantCategory);
                    dt = _dbConnection.ExecuteProQuery(query);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    _dbConnection.CloseDatabase();
                }
                return dt;
            }
           
       //v1 
       //public DataTable GetIPOSubmissionOfIPOcollectionFile_Hardcopy_And_Softcopy(int session, string Name)
        //{
        //    DataTable dt = new DataTable();
        //    string query = @"rptIPOSubmissionOfIPOcollectionFile_Hardcopy_And_Softcopy";
        //    try
        //    {
        //        _dbConnection.ConnectDatabase();
        //        _dbConnection.ActiveStoredProcedure();
        //        _dbConnection.AddParameter("@Session", SqlDbType.Int, session);
        //        _dbConnection.AddParameter("@Name", SqlDbType.VarChar, Name);
        //        dt = _dbConnection.ExecuteProQuery(query);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    finally
        //    {
        //        _dbConnection.CloseDatabase();
        //    }
        //    return dt;
        //}
        #endregion

        #region NRB Payment Review
        /// <summary>
        /// Payemnt Review For Non resident Bangladeshi
        /// Added by Md.Rashedul Hasan
        /// </summary>
        /// <param name="branchid"></param>
        /// <param name="FromDate"></param>
        /// <param name="todate"></param>
        /// <returns></returns>
        public DataTable GETIPONRBPaymentReview(int branchid, DateTime FromDate, DateTime todate)
        {
            DataTable dt = new DataTable();
            string query = @"rptIPoNRBPaymentReview";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@Branch_Id", SqlDbType.Int, branchid);
                _dbConnection.AddParameter("@fromDate", SqlDbType.Date, FromDate.Date);
                _dbConnection.AddParameter("@toDate", SqlDbType.Date, todate.Date);
                dt = _dbConnection.ExecuteProQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dt;
        }
        #endregion

        #region NRB Successful Unsuccessful
        public DataTable GetNRBSuccessfulUnsuccessful(string Status, string companyname, string code)
        {
            DataTable dt = new DataTable();
            string query = @"RptIPONrbSuccessfulUnsuccessul";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@Status", SqlDbType.VarChar, Status);
                _dbConnection.AddParameter("@CompanyName", SqlDbType.VarChar, companyname);
                _dbConnection.AddParameter("@Cust_Code", SqlDbType.VarChar, code);
                dt = _dbConnection.ExecuteProQuery(query);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;
        }
        #endregion
     
    }
}
