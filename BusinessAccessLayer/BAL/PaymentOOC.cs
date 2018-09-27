﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using BusinessAccessLayer.BAL;
using BusinessAccessLayer.BO;
using System.Data;
using BusinessAccessLayer.Constants;
using System.Data.SqlClient;

namespace BusinessAccessLayer.BAL
{
    public class PaymentOOC
    {
        private DbConnection _dbConnection;  

        public PaymentOOC()
        {
            _dbConnection = new DbConnection();
        }
        public void ConnectDatabase()
        {
            _dbConnection.ConnectDatabase();
            _dbConnection.StartTransaction();
        }

        public void CloseDatabase()
        {
            _dbConnection.CloseDatabase();
        }

        public void Commit()
        {
            _dbConnection.Commit();
        }

        public void RollBack()
        {
            _dbConnection.Rollback();
        }

        public SqlTransaction GetTransaction()
        {
            return _dbConnection.GetTransaction();
        }
        public void SetTransaction(SqlTransaction trans)
        {
            _dbConnection.SetTransaction(trans);
        }

       

        public DataTable CustomerInfo(string custCode)
        {
            string queryString = "SELECT SBP_Customers.BO_ID,(SELECT BO_Status FROM SBP_BO_Status WHERE BO_Status_ID=SBP_Customers.BO_Status_ID) AS 'BO_Status',SBP_Cust_Personal_Info.Cust_Name,(SELECT ISNULL(SUM(Balance),0)FROM SBP_Money_Balance_Temp WHERE SBP_Money_Balance_Temp.Cust_Code=SBP_Customers.Cust_Code) AS 'CurrentBalence',(SELECT ISNULL(SUM(Matured_Balance),0)FROM SBP_Money_Balance_Temp WHERE SBP_Money_Balance_Temp.Cust_Code=SBP_Customers.Cust_Code) AS 'Matured Balence',SBP_Cust_Status.Cust_Status FROM SBP_Cust_Personal_Info,SBP_CUstomers,SBP_Cust_Status WHERE SBP_Customers.Cust_Code='" + custCode + "' AND SBP_Cust_Personal_Info.Cust_Code=SBP_Customers.Cust_Code AND  SBP_Customers.Cust_Status_ID=SBP_Cust_Status.Cust_Status_ID;";
            DataTable data = new DataTable();

            try
            {
                _dbConnection.ConnectDatabase();
                data = _dbConnection.ExecuteQuery(queryString);
            }

            catch (Exception)
            {
                throw;
            }

            finally
            {
                _dbConnection.CloseDatabase();
            }

            return data;
        }

        public void InsertToDatabse(PaymentOOCBO objPaymentOOCBO)
        {
            string queryString = @"INSERT INTO SBP_Payment_OOC(Cust_Code,Payment_Media,OCC_ID,Payment_Date,Amount,Voucher,Payment_Period,Remarks,Branch_ID,Entry_By,Entry_Date,Status) 
            VALUES ('" + objPaymentOOCBO.Cust_Code + "','" + objPaymentOOCBO.PaymentMedia + "'," + objPaymentOOCBO.OCCPurpose + ",'" + objPaymentOOCBO.OCC_PaymentDate.ToShortDateString() + "'," + objPaymentOOCBO.OCC_Amount + ",'" + objPaymentOOCBO.OCC_VoucherNo + "','" + objPaymentOOCBO.PaymentPeriod + "','" + objPaymentOOCBO.Remarks + "'," + GlobalVariableBO._branchId + ",'" + GlobalVariableBO._userName + "',CAST(FLOOR(CAST(GETDATE() AS FLOAT)) AS DATETIME),0)";

            try
            {
                _dbConnection.ConnectDatabase();
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
        public void InsertToTRInfo(PaymentOOCBO paymentOCCBO)
        {
            string queryStringPaymentPostingDeposit = string.Empty;
            CommonBAL commonBAL = new CommonBAL();
            long PaymentIdDeposit = commonBAL.GenerateID("SBP_Payment_Posting_Request", "Payment_ID");

            queryStringPaymentPostingDeposit = @"INSERT INTO SBP_Payment_Posting_Request(
                                                 --Payment_ID
                                                --,
                                                Cust_code
                                                ,Amount
                                                ,Received_Date
                                                ,Payment_Media
                                                ,Maturity_Days
                                                ,Payment_Media_No
                                                ,Payment_Media_Date
                                                ,Bank_ID
                                                ,Bank_Name
                                                ,Branch_ID
                                                ,Bank_Branch 
                                                ,RoutingNo 
                                                ,BankAccNo 
                                                ,Received_By
                                                ,Deposit_Withdraw         
                                                ,Payment_Approved_By           
                                                ,Payment_Approved_Date         
                                                ,Remarks                    
                                                ,Entry_Date          
                                                ,Entry_By                                         
                                                ,Deposit_Bank_Name
                                                ,Deposit_Branch_Name
                                                ,Approval_Status
                                                ,Vouchar_SN
                                                ,Trans_Reason
                                                ,Media_Type
                                                ,OnlineOrderNo
                                                ,Entry_Branch_ID
                                                )"
                                             +
                                             " VALUES("
                                             //+ PaymentIdDeposit
                                             //+ "," 
                                             + "'"+paymentOCCBO.Cust_Code
                                             + "'," + paymentOCCBO.OCC_Amount
                                             + ",'" + paymentOCCBO.OCC_PaymentDate.ToString("MM-dd-yyyy")
                                             + "','Cash" //+ paymentOCCBO.PaymentMedia
                                             + "',NULL"
                                             + ",'" + ""  //Payment_Media_No
                                             + "','" + paymentOCCBO.OCC_PaymentDate.ToString("MM-dd-yyyy") // PaymentMediaDate.ToString("MM-dd-yyyy")
                                              + "',NULL"  // paymentOCCBO.Bank_ID
                                              + ",'" + string.Empty //paymentOCCBO.BankName
                                              + "',NULL" //paymentOCCBO.Branch_ID
                                              + ",'" + string.Empty //paymentOCCBO.BranchName
                                              + "','" + string.Empty //paymentOCCBO.RoutingNo
                                              + "','" + string.Empty //paymentOCCBO.BankAccNo
                                              + "','" + string.Empty //paymentOCCBO.RecievedBy
                                              + "','" + "Withdraw" // Indication_Fixed_VoucherNo_TransReason.BORenewal_DepositWithdraw  //paymentOCCBO.DepositWithdraw
                                              + "','" + string.Empty // paymentOCCBO.PaymentApprovedBy
                                              + "'," + "NULL" //((Convert.ToString(paymentOCCBO.PaymentApprovedDate) == string.Empty) ? "null" : "'" + paymentOCCBO.PaymentApprovedDate.Value.ToString("MM-dd-yyyy") + "'")
                                              + ",'" + paymentOCCBO.Remarks
                                              + "',CAST(FLOOR(CAST(GETDATE() AS FLOAT)) AS DATETIME)"
                                              + ",'" + GlobalVariableBO._userName
                                              + "','" + ""
                                              + "','" + ""
                                              + "',0,'"
                                              + Indication_Fixed_VoucherNo_TransReason.GetOCC_VoucherNo()//  paymentOCCBO.VoucherNo //.VoucherSlNo
                                              + "','" + paymentOCCBO.PaymentOCCPurpose//Trans_Reason
                                              + "','" + paymentOCCBO.MediaType//Trans_Reason
                                              + "','" + paymentOCCBO.TAX_ID//Trans_Reason
                                              + "'," + GlobalVariableBO._branchId
                                           + ")";

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(queryStringPaymentPostingDeposit);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }

        }

        public void InsertToTRInfo(PaymentOOCBO paymentOCCBO,SqlTransaction tran)
        {
            string queryStringPaymentPostingDeposit = string.Empty;
            CommonBAL commonBAL = new CommonBAL();
            long PaymentIdDeposit = commonBAL.GenerateID("SBP_Payment_Posting_Request", "Payment_ID");

            queryStringPaymentPostingDeposit = @"INSERT INTO SBP_Payment_Posting_Request(
                                                 --Payment_ID
                                                --,
                                                Cust_code
                                                ,Amount
                                                ,Received_Date
                                                ,Payment_Media
                                                ,Maturity_Days
                                                ,Payment_Media_No
                                                ,Payment_Media_Date
                                                ,Bank_ID
                                                ,Bank_Name
                                                ,Branch_ID
                                                ,Bank_Branch 
                                                ,RoutingNo 
                                                ,BankAccNo 
                                                ,Received_By
                                                ,Deposit_Withdraw         
                                                ,Payment_Approved_By           
                                                ,Payment_Approved_Date         
                                                ,Remarks                    
                                                ,Entry_Date          
                                                ,Entry_By                                         
                                                ,Deposit_Bank_Name
                                                ,Deposit_Branch_Name
                                                ,Approval_Status
                                                ,Vouchar_SN
                                                ,Trans_Reason
                                                ,Entry_Branch_ID
                                                )"
                                             +
                                             " VALUES("
                                             + PaymentIdDeposit
                                             + ",'" + paymentOCCBO.Cust_Code
                                             + "'," + paymentOCCBO.OCC_Amount
                                             + ",'" + paymentOCCBO.OCC_PaymentDate.ToString("MM-dd-yyyy")
                                             + "','Cash" //+ paymentOCCBO.PaymentMedia
                                             + "',NULL"
                                             + ",'" + ""  //Payment_Media_No
                                             + "','" + paymentOCCBO.OCC_PaymentDate.ToString("MM-dd-yyyy") // PaymentMediaDate.ToString("MM-dd-yyyy")
                                              + "',NULL"  // paymentOCCBO.Bank_ID
                                              + ",'" + string.Empty //paymentOCCBO.BankName
                                              + "',NULL" //paymentOCCBO.Branch_ID
                                              + ",'" + string.Empty //paymentOCCBO.BranchName
                                              + "','" + string.Empty //paymentOCCBO.RoutingNo
                                              + "','" + string.Empty //paymentOCCBO.BankAccNo
                                              + "','" + string.Empty //paymentOCCBO.RecievedBy
                                              + "','" + "Withdraw" // Indication_Fixed_VoucherNo_TransReason.BORenewal_DepositWithdraw  //paymentOCCBO.DepositWithdraw
                                              + "','" + string.Empty // paymentOCCBO.PaymentApprovedBy
                                              + "'," + "NULL" //((Convert.ToString(paymentOCCBO.PaymentApprovedDate) == string.Empty) ? "null" : "'" + paymentOCCBO.PaymentApprovedDate.Value.ToString("MM-dd-yyyy") + "'")
                                              + ",'" + paymentOCCBO.Remarks
                                              + "',CAST(FLOOR(CAST(GETDATE() AS FLOAT)) AS DATETIME)"
                                              + ",'" + GlobalVariableBO._userName
                                              + "','" + ""
                                              + "','" + ""
                                              + "',0,'"
                                              + Indication_Fixed_VoucherNo_TransReason.GetOCC_VoucherNo()//  paymentOCCBO.VoucherNo //.VoucherSlNo
                                              + "','" + paymentOCCBO.PaymentOCCPurpose//Trans_Reason
                                              + "'," + GlobalVariableBO._branchId
                                           + ")";

            try
            {
                _dbConnection.SetTransaction(tran);
                _dbConnection.ExecuteNonQuery(queryStringPaymentPostingDeposit);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public void InsertToTRInfo(PaymentOOCBO objPaymentOOCBO)
        //{
        //    //string queryPayment = "INSERT INTO SBP_Payment(Cust_code,Amount,Received_Date,Payment_Media,Deposit_Withdraw,Voucher_Sl_No,Trans_Reason,Entry_Date,Entry_By,Entry_Branch_ID) VALUES('" + objPaymentOOCBO.Cust_Code + "'," + objPaymentOOCBO.Amount + ",'" + objPaymentOOCBO.PaymentDate.ToShortDateString() + "','" + objPaymentOOCBO.PaymentMedia + "','Withdraw','" + objPaymentOOCBO.VoucherNo + "','" + objPaymentOOCBO.PaymentOCCPurpose + "',CAST(FLOOR(CAST(GETDATE() AS FLOAT)) AS DATETIME),'" + GlobalVariableBO._userName + "'," + GlobalVariableBO._branchId + ");";
        //    //string queryMoneyBalence = "INSERT INTO SBP_Money_Balance_Temp(Cust_Code,Sell_Deposit,Buy_Withdraw,Balance,Matured_Balance,Remarks,Rec_Date) VALUES('"+objPaymentOOCBO.Cust_Code+"',0,"+objPaymentOOCBO.Amount+",0-"+objPaymentOOCBO.Amount+",0-"+objPaymentOOCBO.Amount+",'"+objPaymentOOCBO.PaymentOCCPurpose+"','"+objPaymentOOCBO.PaymentDate.ToShortDateString()+"');";
        //    string queryStringPaymentOCC = "INSERT INTO SBP_Payment_OOC(Cust_Code,Payment_Media,OCC_ID,Payment_Date,Amount,Voucher,Payment_Period,Remarks,Branch_ID,Entry_By,Entry_Date,Status) VALUES ('" + objPaymentOOCBO.Cust_Code + "','" + objPaymentOOCBO.PaymentMedia + "'," + objPaymentOOCBO.OCCPurpose + ",'" + objPaymentOOCBO.OCC_PaymentDate.ToShortDateString() + "'," + objPaymentOOCBO.OCC_Amount + ",'" + objPaymentOOCBO.OCC_VoucherNo + "','" + objPaymentOOCBO.PaymentPeriod.ToShortDateString() + "','" + objPaymentOOCBO.Remarks + "'," + GlobalVariableBO._branchId + ",'" + GlobalVariableBO._userName + "',CAST(FLOOR(CAST(GETDATE() AS FLOAT)) AS DATETIME),0)";



        //    try
        //    {
        //        _dbConnection.ConnectDatabase();
        //        _dbConnection.ExecuteNonQuery(queryStringPaymentOCC);

        //    }

        //    catch (Exception)
        //    {


        //        throw;
        //    }

        //    finally
        //    {
        //        _dbConnection.CloseDatabase();
        //    }

        //}
        public void InsertNewCustomer(string custCode)
        {
            string insertQuery = @"INSERT INTO [dbo].[SBP_Customers]
                                    (
                                    [Cust_Code]
                                    , [Cust_Group_ID]
                                    , [Special_Remarks]
                                    , [Cust_Open_Date]
                                    , [Cust_Close_Date]
                                    , [Cust_Status_ID]
                                    , [Parent_Cust_Code]
                                    , [BO_ID]
                                    , [BO_Category_ID]
                                    , [BO_Type_ID]
                                    , [BO_Open_Date]
                                    , [BO_Close_Date]
                                    , [BO_Status_ID]
                                    , [Is_Officer_Director_SE]
                                    , [SE_Name_Address]
                                    , [Entry_Date]
                                    , [Entry_By]
                                    , [Branch_ID]
                                    , [Neg_Counter]
                                    , [Counter_Updated]
                                    , [Pin]
                                    )
                                    VALUES
                                    ("

                                    + "'" + custCode + "'"
                                    + @",1
                                    , NULL 
                                    , NULL
                                    , NULL
                                    , 3
                                    , NULL
                                    , NULL
                                    , NULL
                                    , NULL
                                    , NULL
                                    , NULL
                                    , NULL
                                    , NULL
                                    , NULL
                                    , NULL
                                    , NULL
                                    , NULL
                                    , NULL
                                    , NULL
                                    , NULL
                                    )";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(insertQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
        }

        public void InsertNewCustomer_UITransApplied(string custCode)
        {
            string insertQuery = @"INSERT INTO [dbo].[SBP_Customers]
                                    (
                                    [Cust_Code]
                                    , [Cust_Group_ID]
                                    , [Special_Remarks]
                                    , [Cust_Open_Date]
                                    , [Cust_Close_Date]
                                    , [Cust_Status_ID]
                                    , [Parent_Cust_Code]
                                    , [BO_ID]
                                    , [BO_Category_ID]
                                    , [BO_Type_ID]
                                    , [BO_Open_Date]
                                    , [BO_Close_Date]
                                    , [BO_Status_ID]
                                    , [Is_Officer_Director_SE]
                                    , [SE_Name_Address]
                                    , [Entry_Date]
                                    , [Entry_By]
                                    , [Branch_ID]
                                    , [Neg_Counter]
                                    , [Counter_Updated]
                                    , [Pin]
                                    )
                                    VALUES
                                    ("

                                    + "'" + custCode + "'"
                                    + @",1
                                    , NULL 
                                    , NULL
                                    , NULL
                                    , 3
                                    , NULL
                                    , NULL
                                    , NULL
                                    , NULL
                                    , NULL
                                    , NULL
                                    , NULL
                                    , NULL
                                    , NULL
                                    , NULL
                                    , NULL
                                    , NULL
                                    , NULL
                                    , NULL
                                    , NULL
                                    )";
            try
            {
                //_dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(insertQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //finally
            //{
            //    _dbConnection.CloseDatabase();
            //}
        }

        public void InsertNewCustomer(string custCode,SqlTransaction trans)
        {
            string insertQuery = @"INSERT INTO [dbo].[SBP_Customers]
                                    (
                                    [Cust_Code]
                                    , [Cust_Group_ID]
                                    , [Special_Remarks]
                                    , [Cust_Open_Date]
                                    , [Cust_Close_Date]
                                    , [Cust_Status_ID]
                                    , [Parent_Cust_Code]
                                    , [BO_ID]
                                    , [BO_Category_ID]
                                    , [BO_Type_ID]
                                    , [BO_Open_Date]
                                    , [BO_Close_Date]
                                    , [BO_Status_ID]
                                    , [Is_Officer_Director_SE]
                                    , [SE_Name_Address]
                                    , [Entry_Date]
                                    , [Entry_By]
                                    , [Branch_ID]
                                    , [Neg_Counter]
                                    , [Counter_Updated]
                                    , [Pin]
                                    )
                                    VALUES
                                    ("

                                    + "'" + custCode + "'"
                                    + @",1
                                    , NULL 
                                    , NULL
                                    , NULL
                                    , 3
                                    , NULL
                                    , NULL
                                    , NULL
                                    , NULL
                                    , NULL
                                    , NULL
                                    , NULL
                                    , NULL
                                    , NULL
                                    , NULL
                                    , NULL
                                    , NULL
                                    , 0
                                    , NULL
                                    , NULL
                                    )";
            try
            {
                //_dbConnection.ConnectDatabase();
                _dbConnection.SetTransaction(trans);
                _dbConnection.ExecuteNonQuery(insertQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //finally
            //{
            //    _dbConnection.CloseDatabase();
            //}
        }

        public void  InsertPaymentPostingRequestByTitle_UITransApplied(PaymentOOCBO paymentOCCBO, string titleName)
        {
            double doubleTryParse;
            BO_Opening_InformationBAL TotalChargeBAL = new BO_Opening_InformationBAL();
            DataTable dtBOOpenCharge = TotalChargeBAL.GetLastChargeHistory();
            //double totalBOOpeningCharge = Convert.ToDouble(dtBOOpenCharge.Rows[0]["TotalCharge"].ToString());

            var HouseCh = (from DataRow a in dtBOOpenCharge.Rows where a["Ch_Item"].ToString() == "BO Open Charge_House" select a["Ch_Rate"]).FirstOrDefault();
            double H_CH = 0;
            if (double.TryParse(HouseCh.ToString(), out doubleTryParse))
                H_CH = doubleTryParse;

            var CDBLch = (from DataRow a in dtBOOpenCharge.Rows where a["Ch_Item"].ToString() == "BO Open Charge_CDBL" select a["Ch_Rate"]).FirstOrDefault();
            double C_CH = 0;
            if (double.TryParse(CDBLch.ToString(), out doubleTryParse))
                C_CH = doubleTryParse;

            double totalBOOpeningCharge = (H_CH + C_CH);


            string queryString_PaymentPostingWithdraw = string.Empty;
            string queryString_PaymentPostingDeposit = string.Empty;
            string queryString_InsertNewCustomer = string.Empty;
            string queryString_GetNewID_PaymentPostingReques = string.Empty;

            DataTable dt = new DataTable();

            //CommonBAL commonBAL = new CommonBAL();
            //int PaymentIdDeposit = commonBAL.GenerateID("SBP_Payment_Posting_Request", "Payment_ID");
            string PaymentIdWithdraw = ""; //PaymentIdDeposit + 1;// commonBAL.GenerateID("SBP_Payment_Posting_Request", "Payment_ID");

            try
            {

                //_dbConnection.ConnectDatabase();
                //_dbConnection.StartTransaction();

                
                queryString_PaymentPostingWithdraw = @"
                                            INSERT INTO SBP_Payment_Posting_Request(
                                             --Payment_ID
                                            Cust_code
                                            ,Amount
                                            ,Received_Date
                                            ,Payment_Media
                                            ,Maturity_Days
                                            ,Payment_Media_No
                                            ,Payment_Media_Date
                                            ,Bank_ID
                                            ,Bank_Name
                                            ,Branch_ID
                                            ,Bank_Branch 
                                            ,RoutingNo 
                                            ,BankAccNo 
                                            ,Received_By
                                            ,Deposit_Withdraw         
                                            ,Payment_Approved_By           
                                            ,Payment_Approved_Date         
                                            ,Remarks                    
                                            ,Entry_Date          
                                            ,Entry_By                                         
                                            ,Deposit_Bank_Name
                                            ,Deposit_Branch_Name
                                            ,Approval_Status
                                            ,Vouchar_SN
                                            ,Trans_Reason
                                            ,Entry_Branch_ID
                                            )"
                                            +
                                            " VALUES("
                    //+ PaymentIdWithdraw
                                            + "'" + paymentOCCBO.Cust_Code
                                            //+ "'," + Indication_TransWithFixedAmount.BO_Renewal_Charge //paymentOCCBO.Amount
                                            + "'," + totalBOOpeningCharge //paymentOCCBO.Amount
                                            + ",'" + paymentOCCBO.Annual_PaymentDate.ToString("MM-dd-yyyy")
                                            + "','" + paymentOCCBO.PaymentMedia
                                            + "',NULL"
                                            + ",'" + ""  //Payment_Media_No
                                            + "','" + paymentOCCBO.Annual_PaymentDate.ToString("MM-dd-yyyy") // PaymentMediaDate.ToString("MM-dd-yyyy")
                                             + "',NULL"  // paymentOCCBO.Bank_ID
                                             + ",'" + string.Empty //paymentOCCBO.BankName
                                             + "',NULL" //paymentOCCBO.Branch_ID
                                             + ",'" + string.Empty //paymentOCCBO.BranchName
                                             + "','" + string.Empty //paymentOCCBO.RoutingNo
                                             + "','" + string.Empty //paymentOCCBO.BankAccNo
                                             + "','" + string.Empty //paymentOCCBO.RecievedBy
                                             + "','" + Indication_Fixed_VoucherNo_TransReason.BORenewal_DepositWithdraw  //paymentOCCBO.DepositWithdraw
                                             + "','" + string.Empty // paymentOCCBO.PaymentApprovedBy
                                             + "'," + "NULL" //((Convert.ToString(paymentOCCBO.PaymentApprovedDate) == string.Empty) ? "null" : "'" + paymentOCCBO.PaymentApprovedDate.Value.ToString("MM-dd-yyyy") + "'")
                                             + ",'" + paymentOCCBO.Remarks
                                             + "',CAST(FLOOR(CAST(GETDATE() AS FLOAT)) AS DATETIME)"
                                             + ",'" + GlobalVariableBO._userName
                                             + "','" + ""
                                             + "','" + ""
                                             + "',0,'"
                                             + Indication_Fixed_VoucherNo_TransReason.GetBORenewal_VoucherNo(paymentOCCBO.PaymentPeriod)//  paymentOCCBO.VoucherNo //.VoucherSlNo
                                             + "','" + paymentOCCBO.Trans_Reason //Trans_Reason
                                             + "'," + GlobalVariableBO._branchId
                                          + ")";
                _dbConnection.ExecuteNonQuery(queryString_PaymentPostingWithdraw);

                queryString_GetNewID_PaymentPostingReques = "SELECT SCOPE_IDENTITY()";

                dt = _dbConnection.ExecuteQuery(queryString_GetNewID_PaymentPostingReques);
                if (dt.Rows.Count > 0)
                    PaymentIdWithdraw = dt.Rows[0][0].ToString();
                if (PaymentIdWithdraw == "")
                    throw new Exception("Error occured in new identity to retrieve from database !!");                      
                queryString_PaymentPostingDeposit = @"                                                 
                                                    INSERT INTO SBP_Payment_Posting_Request(
                                                     --Payment_ID
                                                    Cust_code
                                                    ,Amount
                                                    ,Received_Date
                                                    ,Payment_Media
                                                    ,Maturity_Days
                                                    ,Payment_Media_No
                                                    ,Payment_Media_Date
                                                    ,Bank_ID
                                                    ,Bank_Name
                                                    ,Branch_ID
                                                    ,Bank_Branch 
                                                    ,RoutingNo 
                                                    ,BankAccNo 
                                                    ,Received_By
                                                    ,Deposit_Withdraw         
                                                    ,Payment_Approved_By           
                                                    ,Payment_Approved_Date         
                                                    ,Remarks                    
                                                    ,Entry_Date          
                                                    ,Entry_By                                         
                                                    ,Deposit_Bank_Name
                                                    ,Deposit_Branch_Name
                                                    ,Approval_Status
                                                    ,Vouchar_SN
                                                    ,Trans_Reason
                                                    ,Entry_Branch_ID
                                                    )"
                                                 +
                                                 " VALUES("
                                                 //+ PaymentIdDeposit
                                                 + "'" + paymentOCCBO.Cust_Code+"'"
                                                 + "," + paymentOCCBO.Annual_Amount//Indication_TransWithFixedAmount.BO_Renewal_Charge //paymentOCCBO.Amount
                                                 + ",'" + paymentOCCBO.Annual_PaymentDate.ToString("MM-dd-yyyy")+"'"
                                                 + ",'" + paymentOCCBO.PaymentMedia+"'"
                                                 + ",NULL"
                                                 + ",'" +string.Empty +"'"  //Payment_Media_No
                                                 + ",'" + paymentOCCBO.Annual_PaymentDate.ToString("MM-dd-yyyy")+"'" // PaymentMediaDate.ToString("MM-dd-yyyy")
                                                  + ",NULL"  // paymentOCCBO.Bank_ID
                                                  + ",'" + string.Empty+"'" //paymentOCCBO.BankName
                                                  + ",NULL" //paymentOCCBO.Branch_ID
                                                  + ",'" + string.Empty+"'" //paymentOCCBO.BranchName
                                                  + ",'" + string.Empty+"'" //paymentOCCBO.RoutingNo
                                                  + ",'" + string.Empty+"'" //paymentOCCBO.BankAccNo
                                                  + ",'" + string.Empty+"'" //paymentOCCBO.RecievedBy
                                                  + ",'" + "Deposit"+"'" // Indication_Fixed_VoucherNo_TransReason.BORenewal_DepositWithdraw  //paymentOCCBO.DepositWithdraw
                                                  + ",'" + string.Empty+"'" // paymentOCCBO.PaymentApprovedBy
                                                  + "," + "NULL" //((Convert.ToString(paymentOCCBO.PaymentApprovedDate) == string.Empty) ? "null" : "'" + paymentOCCBO.PaymentApprovedDate.Value.ToString("MM-dd-yyyy") + "'")
                                                  + ",'" + paymentOCCBO.Remarks+"'"
                                                  + ",CAST(FLOOR(CAST(GETDATE() AS FLOAT)) AS DATETIME)"
                                                  + ",'" + GlobalVariableBO._userName+"'"
                                                  + ",'" + string.Empty+"'"
                                                  + ",'" + string.Empty + "'"
                                                  + ",0"
                                                  + ",'"+paymentOCCBO.Annual_VoucherNo+"'"  //Indication_Fixed_VoucherNo_TransReason.GetBORenewal_VoucherNo(paymentOCCBO.PaymentPeriod)//  paymentOCCBO.VoucherNo //.VoucherSlNo
                                                  + ",'" + Indication_Fixed_VoucherNo_TransReason.BO_DUE_TransReason+"'"  //Trans_Reason
                                                  + "," + GlobalVariableBO._branchId
                                               + ")";
                _dbConnection.ExecuteNonQuery(queryString_PaymentPostingDeposit);

                if (titleName == Indication_Forms_Title.NewCustomerOpen)
                {
                    queryString_InsertNewCustomer = @"INSERT INTO SBP_Payment_OOC(
                                        Cust_Code
                                        ,Payment_Media
                                        ,OCC_ID
                                        ,Payment_Date
                                        ,Amount
                                        ,Voucher
                                        ,Payment_Period
                                        ,Remarks
                                        ,Branch_ID
                                        ,Entry_By
                                        ,Entry_Date
                                        ,Status
                                        ) 
                                        VALUES 
                                        ('"
                                            + paymentOCCBO.Cust_Code
                                            + "','" + paymentOCCBO.PaymentMedia
                                            + "'," + paymentOCCBO.OCCPurpose
                                            + ",'" + paymentOCCBO.OCC_PaymentDate.ToShortDateString()
                                            + "'," +
                                            (paymentOCCBO.OCC_Amount)
                                            + ",'" + paymentOCCBO.OCC_VoucherNo
                                            + "','" + paymentOCCBO.PaymentPeriod
                                            + "','" + paymentOCCBO.Remarks
                                            + "'," + GlobalVariableBO._branchId
                                            + ",'" + GlobalVariableBO._userName
                                            + "',CAST(FLOOR(CAST(GETDATE() AS FLOAT)) AS DATETIME),0)";

                    _dbConnection.ExecuteNonQuery(queryString_InsertNewCustomer);
                }   
                //_dbConnection.Commit();
            }
            catch (Exception ex)
            {
               // _dbConnection.Rollback();
                throw ex;
            }
            //finally
            //{
            //    _dbConnection.CloseDatabase();
            //}

        }

        public DataTable duplicateCustCodeCheck(string CustCode)
        {
            DataTable dt = new DataTable();
            string Query = @"Select Cust_Code from SBP_Customers Where Cust_Code='"+CustCode+"'";
            _dbConnection.ConnectDatabase();
            dt = _dbConnection.ExecuteQuery(Query);
            return dt;
        }


        public void InsertPaymentPostingRequestByTitle(PaymentOOCBO paymentOCCBO, string titleName)
        {
            string queryString_PaymentPostingWithdraw = string.Empty;
            string queryString_PaymentPostingDeposit = string.Empty;
            string queryString_InsertNewCustomer = string.Empty;
            string queryString_GetNewID_PaymentPostingReques = string.Empty;

            DataTable dt = new DataTable();

            //CommonBAL commonBAL = new CommonBAL();
            //int PaymentIdDeposit = commonBAL.GenerateID("SBP_Payment_Posting_Request", "Payment_ID");
            int PaymentIdWithdraw = 0; //PaymentIdDeposit + 1;// commonBAL.GenerateID("SBP_Payment_Posting_Request", "Payment_ID");

            try
            {

                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();

                queryString_PaymentPostingWithdraw = @"
                                            INSERT INTO SBP_Payment_Posting_Request(
                                             --Payment_ID
                                            Cust_code
                                            ,Amount
                                            ,Received_Date
                                            ,Payment_Media
                                            ,Maturity_Days
                                            ,Payment_Media_No
                                            ,Payment_Media_Date
                                            ,Bank_ID
                                            ,Bank_Name
                                            ,Branch_ID
                                            ,Bank_Branch 
                                            ,RoutingNo 
                                            ,BankAccNo 
                                            ,Received_By
                                            ,Deposit_Withdraw         
                                            ,Payment_Approved_By           
                                            ,Payment_Approved_Date         
                                            ,Remarks                    
                                            ,Entry_Date          
                                            ,Entry_By                                         
                                            ,Deposit_Bank_Name
                                            ,Deposit_Branch_Name
                                            ,Approval_Status
                                            ,Vouchar_SN
                                            ,Trans_Reason
                                            ,Entry_Branch_ID
                                            )"
                                            +
                                            " VALUES("
                    //+ PaymentIdWithdraw
                                            + "'" + paymentOCCBO.Cust_Code
                                            + "'," + Indication_TransWithFixedAmount.BO_Renewal_Charge //paymentOCCBO.Amount
                                            + ",'" + paymentOCCBO.Annual_PaymentDate.ToString("MM-dd-yyyy")
                                            + "','" + paymentOCCBO.PaymentMedia
                                            + "',NULL"
                                            + ",'" + ""  //Payment_Media_No
                                            + "','" + paymentOCCBO.Annual_PaymentDate.ToString("MM-dd-yyyy") // PaymentMediaDate.ToString("MM-dd-yyyy")
                                             + "',NULL"  // paymentOCCBO.Bank_ID
                                             + ",'" + string.Empty //paymentOCCBO.BankName
                                             + "',NULL" //paymentOCCBO.Branch_ID
                                             + ",'" + string.Empty //paymentOCCBO.BranchName
                                             + "','" + string.Empty //paymentOCCBO.RoutingNo
                                             + "','" + string.Empty //paymentOCCBO.BankAccNo
                                             + "','" + string.Empty //paymentOCCBO.RecievedBy
                                             + "','" + Indication_Fixed_VoucherNo_TransReason.BORenewal_DepositWithdraw  //paymentOCCBO.DepositWithdraw
                                             + "','" + string.Empty // paymentOCCBO.PaymentApprovedBy
                                             + "'," + "NULL" //((Convert.ToString(paymentOCCBO.PaymentApprovedDate) == string.Empty) ? "null" : "'" + paymentOCCBO.PaymentApprovedDate.Value.ToString("MM-dd-yyyy") + "'")
                                             + ",'" + paymentOCCBO.Remarks
                                             + "',CAST(FLOOR(CAST(GETDATE() AS FLOAT)) AS DATETIME)"
                                             + ",'" + GlobalVariableBO._userName
                                             + "','" + ""
                                             + "','" + ""
                                             + "',0,'"
                                             + Indication_Fixed_VoucherNo_TransReason.GetBORenewal_VoucherNo(paymentOCCBO.PaymentPeriod)//  paymentOCCBO.VoucherNo //.VoucherSlNo
                                             + "','" + paymentOCCBO.Trans_Reason //Trans_Reason
                                             + "'," + GlobalVariableBO._branchId
                                          + ")";
                _dbConnection.ExecuteNonQuery(queryString_PaymentPostingWithdraw);

                queryString_GetNewID_PaymentPostingReques = "SELECT SCOPE_IDENTITY()";

                dt = _dbConnection.ExecuteQuery(queryString_GetNewID_PaymentPostingReques);
                if (dt.Rows.Count > 0)
                    PaymentIdWithdraw = Convert.ToInt32(dt.Rows[0][0].ToString());
                if (PaymentIdWithdraw == 0)
                    throw new Exception("Error occured in new identity to retrieve from database !!");
                //}
                queryString_PaymentPostingDeposit = @"                                                 
                                                    INSERT INTO SBP_Payment_Posting_Request(
                                                     --Payment_ID
                                                    Cust_code
                                                    ,Amount
                                                    ,Received_Date
                                                    ,Payment_Media
                                                    ,Maturity_Days
                                                    ,Payment_Media_No
                                                    ,Payment_Media_Date
                                                    ,Bank_ID
                                                    ,Bank_Name
                                                    ,Branch_ID
                                                    ,Bank_Branch 
                                                    ,RoutingNo 
                                                    ,BankAccNo 
                                                    ,Received_By
                                                    ,Deposit_Withdraw         
                                                    ,Payment_Approved_By           
                                                    ,Payment_Approved_Date         
                                                    ,Remarks                    
                                                    ,Entry_Date          
                                                    ,Entry_By                                         
                                                    ,Deposit_Bank_Name
                                                    ,Deposit_Branch_Name
                                                    ,Approval_Status
                                                    ,Vouchar_SN
                                                    ,Trans_Reason
                                                    ,Entry_Branch_ID
                                                    )"
                                                 +
                                                 " VALUES("
                    //+ PaymentIdDeposit
                                                 + "'" + paymentOCCBO.Cust_Code + "'"
                                                 + "," + paymentOCCBO.Annual_Amount//Indication_TransWithFixedAmount.BO_Renewal_Charge //paymentOCCBO.Amount
                                                 + ",'" + paymentOCCBO.Annual_PaymentDate.ToString("MM-dd-yyyy") + "'"
                                                 + ",'" + paymentOCCBO.PaymentMedia + "'"
                                                 + ",NULL"
                                                 + ",'" + string.Empty + "'"  //Payment_Media_No
                                                 + ",'" + paymentOCCBO.Annual_PaymentDate.ToString("MM-dd-yyyy") + "'" // PaymentMediaDate.ToString("MM-dd-yyyy")
                                                  + ",NULL"  // paymentOCCBO.Bank_ID
                                                  + ",'" + string.Empty + "'" //paymentOCCBO.BankName
                                                  + ",NULL" //paymentOCCBO.Branch_ID
                                                  + ",'" + string.Empty + "'" //paymentOCCBO.BranchName
                                                  + ",'" + string.Empty + "'" //paymentOCCBO.RoutingNo
                                                  + ",'" + string.Empty + "'" //paymentOCCBO.BankAccNo
                                                  + ",'" + string.Empty + "'" //paymentOCCBO.RecievedBy
                                                  + ",'" + "Deposit" + "'" // Indication_Fixed_VoucherNo_TransReason.BORenewal_DepositWithdraw  //paymentOCCBO.DepositWithdraw
                                                  + ",'" + string.Empty + "'" // paymentOCCBO.PaymentApprovedBy
                                                  + "," + "NULL" //((Convert.ToString(paymentOCCBO.PaymentApprovedDate) == string.Empty) ? "null" : "'" + paymentOCCBO.PaymentApprovedDate.Value.ToString("MM-dd-yyyy") + "'")
                                                  + ",'" + paymentOCCBO.Remarks + "'"
                                                  + ",CAST(FLOOR(CAST(GETDATE() AS FLOAT)) AS DATETIME)"
                                                  + ",'" + GlobalVariableBO._userName + "'"
                                                  + ",'" + string.Empty + "'"
                                                  + ",'" + string.Empty + "'"
                                                  + ",0"
                                                  + ",'" + paymentOCCBO.Annual_VoucherNo + "'"  //Indication_Fixed_VoucherNo_TransReason.GetBORenewal_VoucherNo(paymentOCCBO.PaymentPeriod)//  paymentOCCBO.VoucherNo //.VoucherSlNo
                                                  + ",'" + Indication_Fixed_VoucherNo_TransReason.BO_DUE_TransReason + "'"  //Trans_Reason
                                                  + "," + GlobalVariableBO._branchId
                                               + ")";
                _dbConnection.ExecuteNonQuery(queryString_PaymentPostingDeposit);

                if (titleName == Indication_Forms_Title.NewCustomerOpen)
                {
                    queryString_InsertNewCustomer = @"INSERT INTO SBP_Payment_OOC(
                                        Cust_Code
                                        ,Payment_Media
                                        ,OCC_ID
                                        ,Payment_Date
                                        ,Amount
                                        ,Voucher
                                        ,Payment_Period
                                        ,Remarks
                                        ,Branch_ID
                                        ,Entry_By
                                        ,Entry_Date
                                        ,Status
                                        ) 
                                        VALUES 
                                        ('"
                                            + paymentOCCBO.Cust_Code
                                            + "','" + paymentOCCBO.PaymentMedia
                                            + "'," + paymentOCCBO.OCCPurpose
                                            + ",'" + paymentOCCBO.OCC_PaymentDate.ToShortDateString()
                                            + "'," +
                                            (paymentOCCBO.OCC_Amount)
                                            + ",'" + paymentOCCBO.OCC_VoucherNo
                                            + "','" + paymentOCCBO.PaymentPeriod
                                            + "','" + paymentOCCBO.Remarks
                                            + "'," + GlobalVariableBO._branchId
                                            + ",'" + GlobalVariableBO._userName
                                            + "',CAST(FLOOR(CAST(GETDATE() AS FLOAT)) AS DATETIME),0)";

                    _dbConnection.ExecuteNonQuery(queryString_InsertNewCustomer);
                }
                _dbConnection.Commit();
            }
            catch (Exception ex)
            {
                _dbConnection.Rollback();
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }

        }

        public DataTable GetPaymentOOcReport(DateTime fromDate, DateTime toDate)
        {
            string queryString = @"SELECT 
                MainOCC.Payment_Date
                ,MainOCC.Cust_Code AS 'Client Code'
                ,(
	                SELECT Cust_Name 
	                FROM SBP_Cust_Personal_Info 
	                WHERE SBP_Cust_Personal_Info.Cust_Code=MainOCC.Cust_Code
                ) AS 'Client Name'
                ,(
	                SELECT OCC_Purpose 
	                FROM SBP_Payment_OCC_Purpose 
	                WHERE SBP_Payment_OCC_Purpose.OCC_ID=MainOCC.OCC_ID
                ) AS 'Purpose'
                ,MainOCC.Voucher
                ,CAST(YEAR(MainOCC.Payment_Period)AS VARCHAR(15)) AS 'Period'
                ,MainOCC.Payment_Media AS 'Media'
                ,MainOCC.Amount
                ,(
	                SELECT Branch_Name 
	                FROM dbo.SBP_Broker_Branch 
	                WHERE Branch_ID=MainOCC.Branch_ID
                ) AS Branch_Name 
                FROM  SBP_Payment_OOC as MainOCC
                WHERE 
                MainOCC.Payment_Date>='" + fromDate.ToShortDateString() + @"' AND MainOCC.Payment_Date<='" + toDate.ToShortDateString() + @"' AND MainOCC.Status=1 
                AND NOT 
                (
		                MainOCC.OCC_ID=9 AND MainOCC.Cust_Code IN ( Select t.Cust_Code From SBP_Cust_Close As t) 
                )

                UNION  

                SELECT 
                Cust_Close_Date AS 'Payment_Date'
                ,Cust_Code AS 'Client Code'
                ,(
	                SELECT Cust_Name 
	                FROM SBP_Cust_Personal_Info 
	                WHERE SBP_Cust_Personal_Info.Cust_Code=SBP_Cust_Close.Cust_Code
                ) AS 'Client Name'
                ,'Account Close' AS Purpose
                , Voucher_No AS 'Voucher'
                , '-' AS Period
                , Payment_Media AS Media
                , Closing_Charge AS Amount
                , (
	                SELECT Branch_Name 
	                FROM dbo.SBP_Broker_Branch 
	                WHERE Branch_ID=SBP_Cust_Close.Entry_Branch_ID
                ) AS Branch_Name 
                FROM SBP_Cust_Close 
                WHERE 
                CAST (FLOOR(CAST (Cust_Close_Date AS FLOAT)) AS DATETIME )>= '" + fromDate.ToShortDateString() + @"' AND CAST (FLOOR(CAST (Cust_Close_Date AS FLOAT)) AS DATETIME )<='" + toDate.ToShortDateString() + @"'";
            DataTable data = new DataTable();

            try
            {
                _dbConnection.ConnectDatabase();
                data = _dbConnection.ExecuteQuery(queryString);
            }
            catch (Exception)
            {
                throw;
            }

            finally
            {
                _dbConnection.CloseDatabase();
            }

            return data;
        }

        public DataTable GetPaymentOccInfo(DateTime date, string TitleName, int FilterId)
        {
            string queryString = string.Empty;
            if (TitleName == Indication_Forms_Title.NewCustomerOpen || TitleName == Indication_Forms_Title.BORenewal)
            {
                #region
                //               queryString = @"SELECT 
                //                              [Payment_ID]
                //                            , [Cust_Code]
                //                            , [Amount]
                //                            , [Received_Date] AS [Rec.Date]
                //                            , [Payment_Media] AS [P.Media]
                //                            , [Payment_Media_Date] AS [P.Media Date]
                //                            , [Deposit_Withdraw] AS [D/W]
                //                            , [Payment_Approved_By] AS [Approved By]
                //                            , [Payment_Approved_Date] AS [Approved Date]
                //                            , [Vouchar_SN] AS [Voucher]
                //                            , [Trans_Reason] AS [Trans Reasons]
                //                            , [Remarks]
                //                            , [Entry_Date] AS [Entry Date]
                //                            , [Entry_By] AS [Entry By]
                //                            ,(
                //                            CASE	
                //                                WHEN	
                //                                    [Approval_Status]=0 
                //                                THEN 'Pending'
                //                                
                //                                WHEN [Approval_Status]=1 
                //                                THEN 'Approved'
                //                                
                //                             ELSE  
                //                             'Rejected'
                //                             END	
                //                             )
                //                             AS [Status]
                //                            , [Rejection_Reason] AS [Rej Reason]
                //                            , [Entry_Branch_ID] AS [Branch]
                //                            FROM [dbo].[SBP_Payment_Posting_Request]
                //                            WHERE
                //                            [Payment_Media]='Cash' 
                //                            AND [Deposit_Withdraw]='Withdraw' 
                //                            --AND [Vouchar_SN] LIKE 'BAC%' 
                //                            AND [Trans_Reason] LIKE 'BAC-%' AND Entry_Branch_ID =" + GlobalVariableBO._branchId;
                #endregion
                queryString = @"GetBO_Open_Renewal";
            }
            else
            {
                //queryString = "SELECT Payment_OOC_ID,Cust_Code AS 'Cust Code',(SELECT Cust_Name FROM dbo.SBP_Cust_Personal_Info WHERE dbo.SBP_Cust_Personal_Info.Cust_Code=dbo.SBP_Payment_OOC.Cust_Code) AS 'Client Name',(SELECT OCC_Purpose FROM dbo.SBP_Payment_OCC_Purpose WHERE dbo.SBP_Payment_OCC_Purpose.OCC_ID=dbo.SBP_Payment_OOC.OCC_ID) AS 'Purpose',Payment_Media AS 'Media',Voucher AS 'Voucher',Payment_Period AS Period,dbo.SBP_Payment_OOC.Amount AS 'Amount',Remarks,CASE WHEN Status=0 THEN 'Pending' WHEN Status=1 THEN 'Approved' ELSE 'Rejected' END AS 'Status' FROM dbo.SBP_Payment_OOC WHERE Payment_Date='" + date.ToShortDateString() + "' AND Branch_ID=" + GlobalVariableBO._branchId + ";";
                queryString =
                    @"SELECT 
                                    Payment_OOC_ID
                                    ,Cust_Code AS 'Cust Code'
                                    ,
                                    (
	                                    SELECT Cust_Name 
	                                    FROM dbo.SBP_Cust_Personal_Info 
	                                    WHERE dbo.SBP_Cust_Personal_Info.Cust_Code=dbo.SBP_Payment_OOC.Cust_Code
                                    ) AS 'Client Name'
                                    ,
                                    (
	                                    SELECT OCC_Purpose 
	                                    FROM dbo.SBP_Payment_OCC_Purpose 
	                                    WHERE dbo.SBP_Payment_OCC_Purpose.OCC_ID=dbo.SBP_Payment_OOC.OCC_ID
                                    ) AS 'Purpose'
                                    ,Payment_Media AS 'Media'
                                    ,Voucher AS 'Voucher'
                                    ,Payment_Period AS Period
                                    ,dbo.SBP_Payment_OOC.Amount AS 'Amount'
                                    ,'' AS 'Media_Type'
                                    ,'' AS 'OnlineOrderNo'
                                    ,Remarks
                                    ,CASE 
	                                    WHEN Status=0 
		                                    THEN 'Pending' 
	                                    WHEN Status=1 
		                                    THEN 'Approved' 
	                                    ELSE 'Rejected' 
                                    END 
                                    AS 'Status' 
                                    FROM dbo.SBP_Payment_OOC 
                                    WHERE Payment_Date='" +
                                    date.ToShortDateString() + "'"
                                    + @" AND Branch_ID=" + GlobalVariableBO._branchId
                                    +
                                    @"
                                    UNION

                                    SELECT 
                                        ppr.Payment_ID 
                                        ,ppr.Cust_Code 
                                        ,
                                        (
                                            SELECT Cust_Name 
                                            FROM dbo.SBP_Cust_Personal_Info 
                                            WHERE dbo.SBP_Cust_Personal_Info.Cust_Code=ppr.Cust_Code
                                        )
                                        ,ppr.Trans_Reason
                                        ,ppr.Payment_Media
                                        ,ppr.Vouchar_SN
                                        ,ppr.Received_Date
                                        ,ppr.Amount
                                        ,ppr.Media_Type
                                        ,ppr.OnlineOrderNo 
                                        ,ppr.Remarks
                                        ,CASE 
		                                    WHEN Approval_Status=0 
			                                    THEN 'Pending' 
		                                    WHEN Approval_Status=1 
			                                    THEN 'Approved' 
		                                    ELSE 'Rejected' 
	                                    END 

                                        FROM dbo.SBP_Payment_Posting_Request AS ppr	
                                        WHERE Payment_Media='Cash'
                                        AND Vouchar_SN = 'OCC-C'
                                        AND ppr.Received_Date='" +
                                        date.ToShortDateString() + "'"
                                        + @"
                                        AND ppr.Entry_Branch_ID=" + GlobalVariableBO._branchId;
            }
            DataTable data = new DataTable();

            try
            {
                _dbConnection.ConnectDatabase();
                if (TitleName == Indication_Forms_Title.NewCustomerOpen || TitleName == Indication_Forms_Title.BORenewal)
                {
                    _dbConnection.ActiveStoredProcedure();
                    _dbConnection.AddParameter("@payment_Date", SqlDbType.DateTime, date);
                    _dbConnection.AddParameter("@FilterId", SqlDbType.Int, FilterId);
                    data = _dbConnection.ExecuteProQuery(queryString);
                }
                else
                {
                    data = _dbConnection.ExecuteQuery(queryString);
                }

            }
            catch (Exception)
            {

                throw;
            }

            finally
            {
                _dbConnection.CloseDatabase();
            }

            return data;
        }

        public float GetAmount(DateTime date)
        {
            string stringQuery = "SELECT ISNULL(SUM(Amount),0) FROM  dbo.SBP_Payment_OOC WHERE Payment_Date='" + date.ToShortDateString() + "' AND Branch_ID=" + GlobalVariableBO._branchId + ";";
            float amount = 0;

            try
            {
                DataTable data = new DataTable();
                _dbConnection.ConnectDatabase();
                data = _dbConnection.ExecuteQuery(stringQuery);

                amount = float.Parse(data.Rows[0][0].ToString());

            }
            catch (Exception)
            {

                throw;
            }

            finally
            {
                _dbConnection.CloseDatabase();
            }

            return amount;
        }

        public DataTable GetDeletedPaymentOccInfoByDate(DateTime date)
        {
            string queryString = "SELECT Payment_OOC_ID,Payment_Date AS Date,Cust_Code AS 'Cust Code',(SELECT Cust_Name FROM dbo.SBP_Cust_Personal_Info WHERE dbo.SBP_Cust_Personal_Info.Cust_Code=dbo.SBP_Payment_OOC.Cust_Code) AS 'Client Name',(SELECT OCC_Purpose FROM dbo.SBP_Payment_OCC_Purpose WHERE dbo.SBP_Payment_OCC_Purpose.OCC_ID=dbo.SBP_Payment_OOC.OCC_ID) AS 'Purpose',Payment_Media AS 'Media',Voucher AS 'Voucher',Payment_Period AS Period,dbo.SBP_Payment_OOC.Amount AS 'Amount Tk.',Remarks,CASE WHEN Status=0 THEN 'Pending' WHEN Status=1 THEN 'Approved' ELSE 'Rejected' END AS 'Status',Rejected_Reason FROM dbo.SBP_Payment_OOC WHERE Payment_Date='" + date.ToShortDateString() + "'";
            DataTable data = new DataTable();

            try
            {
                _dbConnection.ConnectDatabase();
                data = _dbConnection.ExecuteQuery(queryString);
            }
            catch (Exception)
            {

                throw;
            }

            finally
            {
                _dbConnection.CloseDatabase();
            }

            return data;
        }

        public DataTable GetPaymentOCCInfo(string searchCode)
        {
            string queryString = "SELECT Payment_OOC_ID,Payment_Date AS Date,Cust_Code AS 'Cust Code',(SELECT Cust_Name FROM dbo.SBP_Cust_Personal_Info WHERE dbo.SBP_Cust_Personal_Info.Cust_Code=dbo.SBP_Payment_OOC.Cust_Code) AS 'Client Name',(SELECT OCC_Purpose FROM dbo.SBP_Payment_OCC_Purpose WHERE dbo.SBP_Payment_OCC_Purpose.OCC_ID=dbo.SBP_Payment_OOC.OCC_ID) AS 'Purpose',Payment_Media AS 'Media',Voucher AS 'Voucher',Payment_Period AS Period,dbo.SBP_Payment_OOC.Amount AS 'Amount Tk.',Remarks,CASE WHEN Status=0 THEN 'Pending' WHEN Status=1 THEN 'Approved' ELSE 'Rejected' END AS 'Status',Rejected_Reason FROM dbo.SBP_Payment_OOC WHERE 0=0 " + searchCode + " ;";
            DataTable data = new DataTable();

            try
            {
                _dbConnection.ConnectDatabase();
                data = _dbConnection.ExecuteQuery(queryString);
            }
            catch (Exception)
            {

                throw;
            }

            finally
            {
                _dbConnection.CloseDatabase();
            }

            return data;
        }

        public DataTable GetDeletedPaymentOccInfoByVoucher(string VoucherNo)
        {
            string queryString = "SELECT Payment_OOC_ID,Payment_Date AS Date,Cust_Code AS 'Cust Code',(SELECT Cust_Name FROM dbo.SBP_Cust_Personal_Info WHERE dbo.SBP_Cust_Personal_Info.Cust_Code=dbo.SBP_Payment_OOC.Cust_Code) AS 'Client Name',(SELECT OCC_Purpose FROM dbo.SBP_Payment_OCC_Purpose WHERE dbo.SBP_Payment_OCC_Purpose.OCC_ID=dbo.SBP_Payment_OOC.OCC_ID) AS 'Purpose',Payment_Media AS 'Media',Voucher AS 'Voucher',Payment_Period AS Period,dbo.SBP_Payment_OOC.Amount AS 'Amount Tk.',Remarks,CASE WHEN Status=0 THEN 'Pending' WHEN Status=1 THEN 'Approved' ELSE 'Rejected' END AS 'Status',Rejected_Reason FROM dbo.SBP_Payment_OOC WHERE Voucher='" + VoucherNo + "';";
            DataTable data = new DataTable();

            try
            {
                _dbConnection.ConnectDatabase();
                data = _dbConnection.ExecuteQuery(queryString);
            }
            catch (Exception)
            {

                throw;
            }

            finally
            {
                _dbConnection.CloseDatabase();
            }

            return data;
        }

        public string GetCustomerStatus(string custCode)
        {
            string custStatus = string.Empty;
            string queryString = @"SELECT  Cust_Status
                                FROM dbo.SBP_Cust_Status
                                WHERE Cust_Status_ID=
                                (
                                SELECT Cust_Status_ID 
                                FROM dbo.SBP_Customers
                                WHERE Cust_Code='" + custCode + "')";
            DataTable data = new DataTable();

            try
            {
                _dbConnection.ConnectDatabase();
                data = _dbConnection.ExecuteQuery(queryString);
                if (data.Rows.Count > 0)
                {
                    custStatus = data.Rows[0][0].ToString();
                }
            }
            catch (Exception)
            {

                throw;
            }

            finally
            {
                _dbConnection.CloseDatabase();
            }

            return custStatus;
        }

        public DataTable GetDeletedPaymentOccInfoByPurposeId(int PurposeOCCId)
        {
            string queryString = "SELECT Payment_OOC_ID,Payment_Date AS Date,Cust_Code AS 'Cust Code',(SELECT Cust_Name FROM dbo.SBP_Cust_Personal_Info WHERE dbo.SBP_Cust_Personal_Info.Cust_Code=dbo.SBP_Payment_OOC.Cust_Code) AS 'Client Name',(SELECT OCC_Purpose FROM dbo.SBP_Payment_OCC_Purpose WHERE dbo.SBP_Payment_OCC_Purpose.OCC_ID=dbo.SBP_Payment_OOC.OCC_ID) AS 'Purpose',Payment_Media AS 'Media',Voucher AS 'Voucher',Payment_Period AS Period,dbo.SBP_Payment_OOC.Amount AS 'Amount Tk.',Remarks,CASE WHEN Status=0 THEN 'Pending' WHEN Status=1 THEN 'Approved' ELSE 'Rejected' END AS 'Status',Rejected_Reason FROM dbo.SBP_Payment_OOC WHERE OCC_ID=" + PurposeOCCId + " ;";
            DataTable data = new DataTable();

            try
            {
                _dbConnection.ConnectDatabase();
                data = _dbConnection.ExecuteQuery(queryString);
            }
            catch (Exception)
            {

                throw;
            }

            finally
            {
                _dbConnection.CloseDatabase();
            }

            return data;
        }

        public void DeletePaymentOCCInfo(string OccId)
        {
            string queryString = string.Empty;
            
                queryString = "DELETE FROM SBP_Payment_OOC WHERE Payment_OOC_ID=" + OccId + ";";
            try
            {
                _dbConnection.ConnectDatabase();
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="PaymentID"></param>
        /// <param name="Occid"></param>
        public void DeltePostingAndOccid(string[] PaymentID, string Occid)
        {
            string queryString = string.Empty;
            string queryString_occ = string.Empty;
            string final_query = string.Empty;
            if (PaymentID.Length > 0)
            {
                queryString = @"DELETE FROM SBP_Payment_Posting_Request WHERE Payment_ID IN (" + string.Join(",", PaymentID.Select(c => c.ToString()).ToArray()) + ")";
            }
            if (Occid != "")
            {
                queryString_occ = "DELETE FROM SBP_Payment_OOC WHERE Payment_OOC_ID=" + Occid + "";
            }
            final_query = queryString + queryString_occ;
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(queryString + queryString_occ);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DeleteCustCode(string CustCode)
        {
            string Query = "Delete SBP_Customers Where Cust_Code='"+CustCode+"'";
            _dbConnection.ConnectDatabase();
            _dbConnection.ExecuteNonQuery(Query);
        }

        public void DeletePaymentOCCInfoFromPaymentPostingRequest(string OccId)
        {
            string queryString = string.Empty;
            
                queryString = "DELETE FROM SBP_Payment_Posting_Request WHERE Payment_ID=" + OccId + ";";
            
            try
            {
                _dbConnection.ConnectDatabase();
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
        public void DeleteFromPaymentPostingRequest(int paymentId, string withdraw_voucherNo, string deposit_withdraw)
        {
            string queryString = string.Empty;
            string queryStringDeleteExtraRecord = string.Empty;
            string transReson = string.Empty;
            int withdrawPaymentId = 0;
            string[] tempTransreason = new string[2];

            if (deposit_withdraw == "Withdraw")
            {
                queryString = @"DELETE FROM SBP_Payment_Posting_Request WHERE Payment_ID=" + paymentId;
                queryStringDeleteExtraRecord = @"DELETE
                                                  FROM dbo.SBP_Payment_Posting_Request 
                                                  WHERE REPLACE(Trans_Reason,'" + withdraw_voucherNo + "_','')=CONVERT(VARCHAR(50)," + paymentId + " )";
            }
            else if (deposit_withdraw == "Deposit")
            {
                transReson = Get_TransReasonByPaymentId(paymentId);
                tempTransreason = transReson.Split('_');
                withdrawPaymentId = Convert.ToInt32(tempTransreason[1]);
                queryString = @"DELETE FROM SBP_Payment_Posting_Request WHERE Payment_ID=" + paymentId;
                queryStringDeleteExtraRecord = @"DELETE FROM SBP_Payment_Posting_Request WHERE Payment_ID=" + withdrawPaymentId;
            }
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(queryString);
                _dbConnection.ExecuteNonQuery(queryStringDeleteExtraRecord);
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
        public string Get_TransReasonByPaymentId(int paymentId)
        {
            string transReason = string.Empty;
            DataTable dataTable = new DataTable();
            string queryString =
                @"SELECT Trans_Reason  FROM dbo.SBP_Payment_Posting_Request
                                  WHERE Payment_ID=" +
                paymentId;
            try
            {
                _dbConnection.ConnectDatabase();
                dataTable = _dbConnection.ExecuteQuery(queryString);
                if (dataTable.Rows.Count > 0)
                {
                    transReason = dataTable.Rows[0][0].ToString();
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return transReason;
        }

        public void DeletePaymentOCCTRInformation(string OccId)
        {
            string queryString = "DELETE FROM SBP_Payment_OOC WHERE Payment_OOC_ID=" + OccId + ";";
            string quueryStringPayment = "DELETE FROM dbo.SBP_Payment WHERE Voucher_Sl_No='" + OccId + "' AND Trans_Reason='OCC'";

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();
                _dbConnection.ExecuteNonQuery(queryString);
                _dbConnection.ExecuteNonQuery(quueryStringPayment);
                _dbConnection.Commit();
            }
            catch (Exception)
            {
                _dbConnection.Rollback();
                throw;
            }

            finally
            {
                _dbConnection.CloseDatabase();
            }
        }

//        public DataTable GetApprovedableInfoBybranch(int branchId)
//        {
//            string queryString = "";

//            if (branchId == 0)
//                // queryString = "SELECT Payment_OOC_ID,Payment_Date AS Date,Cust_Code AS 'Cust Code',(SELECT Cust_Name FROM dbo.SBP_Cust_Personal_Info WHERE dbo.SBP_Cust_Personal_Info.Cust_Code=dbo.SBP_Payment_OOC.Cust_Code) AS 'Client Name',(SELECT OCC_Purpose FROM dbo.SBP_Payment_OCC_Purpose WHERE dbo.SBP_Payment_OCC_Purpose.OCC_ID=dbo.SBP_Payment_OOC.OCC_ID) AS 'Purpose',Payment_Media AS 'Media',Voucher AS 'Voucher',Payment_Period AS Period,dbo.SBP_Payment_OOC.Amount AS 'Amount Tk.',Remarks,(SELECT Branch_Name FROM dbo.SBP_Broker_Branch WHERE Branch_ID=dbo.SBP_Payment_OOC.Branch_ID) AS 'Branch Name' FROM dbo.SBP_Payment_OOC WHERE Status=0;";
//                queryString = @"SELECT 
//                                 Payment_OOC_ID
//                                ,Payment_Date AS Date
//                                ,Cust_Code AS 'Cust Code'
//                                ,
//                                (
//	                                SELECT Cust_Name 
//	                                FROM dbo.SBP_Cust_Personal_Info 
//	                                WHERE dbo.SBP_Cust_Personal_Info.Cust_Code=dbo.SBP_Payment_OOC.Cust_Code
//                                ) AS 'Client Name'
//                                ,
//                                (
//	                                SELECT OCC_Purpose 
//	                                FROM dbo.SBP_Payment_OCC_Purpose 
//	                                WHERE dbo.SBP_Payment_OCC_Purpose.OCC_ID=dbo.SBP_Payment_OOC.OCC_ID
//                                ) AS 'Purpose'
//                                ,Payment_Media AS 'Media'
//                                ,Voucher AS 'Voucher'
//                                ,Payment_Period AS Period
//                                ,dbo.SBP_Payment_OOC.Amount AS 'Amount Tk.'
//                                ,Remarks
//                                ,
//                                (
//	                                SELECT Branch_Name 
//	                                FROM dbo.SBP_Broker_Branch 
//	                                WHERE Branch_ID=dbo.SBP_Payment_OOC.Branch_ID
//                                ) AS 'Branch Name' 
//                                FROM dbo.SBP_Payment_OOC WHERE Status=0
//
//                                UNION
//
//                                SELECT 
//                                ppr.Payment_ID 
//                                ,ppr.Received_Date 
//                                ,ppr.Cust_Code 
//                                ,
//                                (
//	                                SELECT Cust_Name 
//	                                FROM dbo.SBP_Cust_Personal_Info 
//	                                WHERE dbo.SBP_Cust_Personal_Info.Cust_Code=ppr.Cust_Code
//                                )
//                                ,ppr.Trans_Reason
//                                ,Payment_Media
//                                ,Vouchar_SN
//                                ,Received_Date
//                                ,ppr.Amount
//                                ,Remarks
//                                ,
//                                (
//	                                SELECT Branch_Name 
//	                                FROM dbo.SBP_Broker_Branch 
//	                                WHERE Branch_ID=ppr.Entry_Branch_ID
//                                ) 
//
//                                FROM dbo.SBP_Payment_Posting_Request AS ppr	
//                                WHERE Payment_Media='Cash'
//                                AND Vouchar_SN = 'OCC-C'
//                                AND Approval_Status=0";
//            else
//            {
//                //queryString = "SELECT Payment_OOC_ID,Payment_Date AS Date,Cust_Code AS 'Cust Code',(SELECT Cust_Name FROM dbo.SBP_Cust_Personal_Info WHERE dbo.SBP_Cust_Personal_Info.Cust_Code=dbo.SBP_Payment_OOC.Cust_Code) AS 'Client Name',(SELECT OCC_Purpose FROM dbo.SBP_Payment_OCC_Purpose WHERE dbo.SBP_Payment_OCC_Purpose.OCC_ID=dbo.SBP_Payment_OOC.OCC_ID) AS 'Purpose',Payment_Media AS 'Media',Voucher AS 'Voucher',Payment_Period AS Period,dbo.SBP_Payment_OOC.Amount AS 'Amount Tk.',Remarks,(SELECT Branch_Name FROM dbo.SBP_Broker_Branch WHERE Branch_ID=dbo.SBP_Payment_OOC.Branch_ID) AS 'Branch Name' FROM dbo.SBP_Payment_OOC WHERE Status=0 AND dbo.SBP_Payment_OOC.Branch_ID=" + branchId + ";";
//                queryString = @"SELECT 
//                                 Payment_OOC_ID
//                                ,Payment_Date AS Date
//                                ,Cust_Code AS 'Cust Code'
//                                ,
//                                (
//                                    SELECT Cust_Name 
//                                    FROM dbo.SBP_Cust_Personal_Info 
//                                    WHERE dbo.SBP_Cust_Personal_Info.Cust_Code=dbo.SBP_Payment_OOC.Cust_Code
//                                ) AS 'Client Name'
//                                ,
//                                (
//                                    SELECT OCC_Purpose 
//                                    FROM dbo.SBP_Payment_OCC_Purpose 
//                                    WHERE dbo.SBP_Payment_OCC_Purpose.OCC_ID=dbo.SBP_Payment_OOC.OCC_ID
//                                ) AS 'Purpose'
//                                ,Payment_Media AS 'Media'
//                                ,Voucher AS 'Voucher'
//                                ,Payment_Period AS Period
//                                ,dbo.SBP_Payment_OOC.Amount AS 'Amount Tk.'
//                                ,Remarks
//                                ,
//                                (
//                                    SELECT Branch_Name 
//                                    FROM dbo.SBP_Broker_Branch 
//                                    WHERE Branch_ID=dbo.SBP_Payment_OOC.Branch_ID
//                                ) AS 'Branch Name' 
//                                FROM dbo.SBP_Payment_OOC WHERE Status=0
//                                AND dbo.SBP_Payment_OOC.Branch_ID=" + branchId 
//                                + @"
//                                UNION
//
//                                SELECT 
//                                ppr.Payment_ID 
//                                ,ppr.Received_Date 
//                                ,ppr.Cust_Code 
//                                ,
//                                (
//                                    SELECT Cust_Name 
//                                    FROM dbo.SBP_Cust_Personal_Info 
//                                    WHERE dbo.SBP_Cust_Personal_Info.Cust_Code=ppr.Cust_Code
//                                )
//                                ,ppr.Trans_Reason
//                                ,Payment_Media
//                                ,Vouchar_SN
//                                ,Received_Date
//                                ,ppr.Amount
//                                ,Remarks
//                                ,
//                                (
//                                    SELECT Branch_Name 
//                                    FROM dbo.SBP_Broker_Branch 
//                                    WHERE Branch_ID=ppr.Entry_Branch_ID
//                                ) 
//
//                                FROM dbo.SBP_Payment_Posting_Request AS ppr	
//                                WHERE ppr.Payment_Media='Cash'
//                                AND ppr.Vouchar_SN = 'OCC-C'
//                                AND ppr.Approval_Status=0 AND ppr.Entry_Branch_ID=" + branchId ;
//            }

//            DataTable data = new DataTable();

//            try
//            {
//                _dbConnection.ConnectDatabase();
//                data = _dbConnection.ExecuteQuery(queryString);
//            }
//            catch (Exception)
//            {

//                throw;
//            }

//            finally
//            {
//                _dbConnection.CloseDatabase();
//            }

//            return data;
//        }


        public DataTable GetApprovedableInfoBybranch(int branchId)
        {
            string queryString = "";

            if (branchId == 0)
                // queryString = "SELECT Payment_OOC_ID,Payment_Date AS Date,Cust_Code AS 'Cust Code',(SELECT Cust_Name FROM dbo.SBP_Cust_Personal_Info WHERE dbo.SBP_Cust_Personal_Info.Cust_Code=dbo.SBP_Payment_OOC.Cust_Code) AS 'Client Name',(SELECT OCC_Purpose FROM dbo.SBP_Payment_OCC_Purpose WHERE dbo.SBP_Payment_OCC_Purpose.OCC_ID=dbo.SBP_Payment_OOC.OCC_ID) AS 'Purpose',Payment_Media AS 'Media',Voucher AS 'Voucher',Payment_Period AS Period,dbo.SBP_Payment_OOC.Amount AS 'Amount Tk.',Remarks,(SELECT Branch_Name FROM dbo.SBP_Broker_Branch WHERE Branch_ID=dbo.SBP_Payment_OOC.Branch_ID) AS 'Branch Name' FROM dbo.SBP_Payment_OOC WHERE Status=0;";
                queryString = @"SELECT 
                                 Payment_OOC_ID
                                ,Payment_Date AS Date
                                ,Cust_Code AS 'Cust Code'
                                ,
                                (
	                                SELECT Cust_Name 
	                                FROM dbo.SBP_Cust_Personal_Info 
	                                WHERE dbo.SBP_Cust_Personal_Info.Cust_Code=dbo.SBP_Payment_OOC.Cust_Code
                                ) AS 'Client Name'
                                ,
                                (
	                                SELECT OCC_Purpose 
	                                FROM dbo.SBP_Payment_OCC_Purpose 
	                                WHERE dbo.SBP_Payment_OCC_Purpose.OCC_ID=dbo.SBP_Payment_OOC.OCC_ID
                                ) AS 'Purpose'
                                ,Payment_Media AS 'Media'
                                ,Voucher AS 'Voucher'
                                ,Payment_Period AS Period
                                ,dbo.SBP_Payment_OOC.Amount AS 'Amount Tk.'
                                ,'' AS 'Media_Type'
                                ,'' AS 'OnlineOrderNo'
                                ,Remarks
                                ,
                                (
	                                SELECT Branch_Name 
	                                FROM dbo.SBP_Broker_Branch 
	                                WHERE Branch_ID=dbo.SBP_Payment_OOC.Branch_ID
                                ) AS 'Branch Name' 
                                FROM dbo.SBP_Payment_OOC WHERE Status=0

                                UNION

                                SELECT 
                                ppr.Payment_ID 
                                ,ppr.Received_Date 
                                ,ppr.Cust_Code 
                                ,
                                (
	                                SELECT Cust_Name 
	                                FROM dbo.SBP_Cust_Personal_Info 
	                                WHERE dbo.SBP_Cust_Personal_Info.Cust_Code=ppr.Cust_Code
                                )
                                ,ppr.Trans_Reason
                                ,Payment_Media
                                ,Vouchar_SN
                                ,Received_Date
                                ,ppr.Amount
                                 ,ppr.Media_Type
                                 ,ppr.OnlineOrderNo 
                                ,Remarks
                                ,
                                (
	                                SELECT Branch_Name 
	                                FROM dbo.SBP_Broker_Branch 
	                                WHERE Branch_ID=ppr.Entry_Branch_ID
                                ) 

                                FROM dbo.SBP_Payment_Posting_Request AS ppr	
                                WHERE Payment_Media='Cash'
                                AND Vouchar_SN = 'OCC-C'
                                AND Approval_Status=0";
            else
            {
                //queryString = "SELECT Payment_OOC_ID,Payment_Date AS Date,Cust_Code AS 'Cust Code',(SELECT Cust_Name FROM dbo.SBP_Cust_Personal_Info WHERE dbo.SBP_Cust_Personal_Info.Cust_Code=dbo.SBP_Payment_OOC.Cust_Code) AS 'Client Name',(SELECT OCC_Purpose FROM dbo.SBP_Payment_OCC_Purpose WHERE dbo.SBP_Payment_OCC_Purpose.OCC_ID=dbo.SBP_Payment_OOC.OCC_ID) AS 'Purpose',Payment_Media AS 'Media',Voucher AS 'Voucher',Payment_Period AS Period,dbo.SBP_Payment_OOC.Amount AS 'Amount Tk.',Remarks,(SELECT Branch_Name FROM dbo.SBP_Broker_Branch WHERE Branch_ID=dbo.SBP_Payment_OOC.Branch_ID) AS 'Branch Name' FROM dbo.SBP_Payment_OOC WHERE Status=0 AND dbo.SBP_Payment_OOC.Branch_ID=" + branchId + ";";
                queryString = @"SELECT 
                                 Payment_OOC_ID
                                ,Payment_Date AS Date
                                ,Cust_Code AS 'Cust Code'
                                ,
                                (
                                    SELECT Cust_Name 
                                    FROM dbo.SBP_Cust_Personal_Info 
                                    WHERE dbo.SBP_Cust_Personal_Info.Cust_Code=dbo.SBP_Payment_OOC.Cust_Code
                                ) AS 'Client Name'
                                ,
                                (
                                    SELECT OCC_Purpose 
                                    FROM dbo.SBP_Payment_OCC_Purpose 
                                    WHERE dbo.SBP_Payment_OCC_Purpose.OCC_ID=dbo.SBP_Payment_OOC.OCC_ID
                                ) AS 'Purpose'
                                ,Payment_Media AS 'Media'
                                ,Voucher AS 'Voucher'
                                ,Payment_Period AS Period
                                ,dbo.SBP_Payment_OOC.Amount AS 'Amount Tk.'
                                ,Remarks
                                ,
                                (
                                    SELECT Branch_Name 
                                    FROM dbo.SBP_Broker_Branch 
                                    WHERE Branch_ID=dbo.SBP_Payment_OOC.Branch_ID
                                ) AS 'Branch Name' 
                                FROM dbo.SBP_Payment_OOC WHERE Status=0
                                AND dbo.SBP_Payment_OOC.Branch_ID=" + branchId
                                + @"
                                UNION

                                SELECT 
                                ppr.Payment_ID 
                                ,ppr.Received_Date 
                                ,ppr.Cust_Code 
                                ,
                                (
                                    SELECT Cust_Name 
                                    FROM dbo.SBP_Cust_Personal_Info 
                                    WHERE dbo.SBP_Cust_Personal_Info.Cust_Code=ppr.Cust_Code
                                )
                                ,ppr.Trans_Reason
                                ,Payment_Media
                                ,Vouchar_SN
                                ,Received_Date
                                ,ppr.Amount
                                ,Remarks
                                ,
                                (
                                    SELECT Branch_Name 
                                    FROM dbo.SBP_Broker_Branch 
                                    WHERE Branch_ID=ppr.Entry_Branch_ID
                                ) 

                                FROM dbo.SBP_Payment_Posting_Request AS ppr	
                                WHERE ppr.Payment_Media='Cash'
                                AND ppr.Vouchar_SN = 'OCC-C'
                                AND ppr.Approval_Status=0 AND ppr.Entry_Branch_ID=" + branchId;
            }

            DataTable data = new DataTable();

            try
            {
                _dbConnection.ConnectDatabase();
                data = _dbConnection.ExecuteQuery(queryString);
            }
            catch (Exception)
            {

                throw;
            }

            finally
            {
                _dbConnection.CloseDatabase();
            }

            return data;
        }

        public DataTable GetApprovablePaymentOCCInfoBYDate(DateTime date)
        {
            string queryString = "SELECT Payment_OOC_ID,Payment_Date AS Date,Cust_Code AS 'Cust Code',(SELECT Cust_Name FROM dbo.SBP_Cust_Personal_Info WHERE dbo.SBP_Cust_Personal_Info.Cust_Code=dbo.SBP_Payment_OOC.Cust_Code) AS 'Client Name',(SELECT OCC_Purpose FROM dbo.SBP_Payment_OCC_Purpose WHERE dbo.SBP_Payment_OCC_Purpose.OCC_ID=dbo.SBP_Payment_OOC.OCC_ID) AS 'Purpose',Payment_Media AS 'Media',Voucher AS 'Voucher',Payment_Period AS Period,dbo.SBP_Payment_OOC.Amount AS 'Amount Tk.',Remarks,(SELECT Branch_Name FROM dbo.SBP_Broker_Branch WHERE Branch_ID=dbo.SBP_Payment_OOC.Branch_ID) AS 'Branch Name' FROM dbo.SBP_Payment_OOC WHERE Status=0 AND Payment_Date=" + date.ToShortDateString() + ";";
            DataTable data = new DataTable();

            try
            {
                _dbConnection.ConnectDatabase();
                data = _dbConnection.ExecuteQuery(queryString);
            }
            catch (Exception)
            {

                throw;
            }

            finally
            {
                _dbConnection.CloseDatabase();
            }

            return data;


        }

        public void ApprovedPaymentOCCByID(string PaymentOCCId)
        {
            string queryString = "UPDATE dbo.SBP_Payment_OOC SET Status=1,Status_Date=CAST(FLOOR(CAST(GETDATE() AS FLOAT)) AS DATETIME) WHERE Payment_OOC_ID=" + PaymentOCCId + ";";

            try
            {
                _dbConnection.ConnectDatabase();
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

        public void RejectedPaymentOccByID(int PaymentOCCId, string RejectedReason, string voucherNo)
        {
            string queryString = string.Empty;
            if(voucherNo==Indication_Fixed_VoucherNo_TransReason.OCC_VoucherNo)
            {
                //queryString = "UPDATE dbo.SBP_Payment_OOC SET Status=2,Status_Date=CAST(FLOOR(CAST(GETDATE() AS FLOAT)) AS DATETIME),Rejected_Reason='" + RejectedReason + "' WHERE Payment_OOC_ID=" + PaymentOCCId + ";";
                queryString =
                    @"UPDATE dbo.SBP_Payment_Posting_Request
                                SET Approval_Status=2
                                ,Rejection_Reason='" +
                    RejectedReason + "' WHERE Payment_ID=" + PaymentOCCId;
            }
            else
            {
                queryString = "UPDATE dbo.SBP_Payment_OOC SET Status=2,Status_Date=CAST(FLOOR(CAST(GETDATE() AS FLOAT)) AS DATETIME),Rejected_Reason='" + RejectedReason + "' WHERE Payment_OOC_ID=" + PaymentOCCId + ";";
            }

            try
            {
                _dbConnection.ConnectDatabase();
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

        public bool IsTRPaymentOOC(string paymentID )
        {
            string queryString = @"SELECT * FROM dbo.SBP_Payment_Posting_Request 
                                    WHERE Payment_Media='Cash'
                                    AND Vouchar_SN = 'OCC-C'
                                    AND Approval_Status=0
                                    AND Payment_ID=" + paymentID ;
            bool isTR = false;

            try
            {
                DataTable data = new DataTable();
                _dbConnection.ConnectDatabase();
                data = _dbConnection.ExecuteQuery(queryString);

                if (data.Rows.Count>0)
                {
                    isTR = true;
                }

                else
                {
                    isTR = false;
                }

            }
            catch (Exception)
            {

                throw;
            }

            finally
            {
                _dbConnection.CloseDatabase();
            }

            return isTR;
        }

        public void ApprovedPaymentOCCTRInformationByVoucherNo(string paymentId)
        {
            string queryString_Payment_withdraw = "";
            string queryString_Payment_Deposit99 = "";
            string queryUpdateDepPosting = "";
            CommonBAL cmBal = new CommonBAL();

            queryString_Payment_withdraw =
                @"INSERT INTO SBP_Payment
                                                    (
                                                    Cust_code
                                                    ,Amount
                                                    ,Received_Date
                                                    ,Payment_Media
                                                    ,Received_By
                                                    ,Deposit_Withdraw
                                                    ,Voucher_Sl_No
                                                    ,Trans_Reason
                                                    ,Payment_Approved_By
                                                    ,Payment_Approved_Date
                                                    ,Remarks
                                                    ,Entry_Date
                                                    ,Entry_By
                                                    ,Requisition_ID
                                                     )
                                                     SELECT 
                                                     Cust_Code
                                                    ,Amount
                                                    ,Received_Date
                                                    ,Payment_Media
                                                    ,Received_By
                                                    ,Deposit_Withdraw
                                                    ,Vouchar_SN
                                                    ,Trans_Reason
                                                    ,Payment_Approved_By
                                                    ,Payment_Approved_Date
                                                    ,Remarks
                                                    ,Entry_Date
                                                    ,Entry_By
                                                    ,Payment_ID
                                                    FROM SBP_Payment_Posting_Request
                                                    WHERE Payment_ID=" + paymentId;

            

            queryString_Payment_Deposit99 = @"INSERT INTO SBP_Payment
                                                (
                                                Cust_code
                                                ,Amount
                                                ,Received_Date
                                                ,Payment_Media
                                                ,Received_By
                                                ,Deposit_Withdraw
                                                ,Voucher_Sl_No
                                                ,Trans_Reason
                                                ,Payment_Approved_By
                                                ,Payment_Approved_Date
                                                ,Remarks,Entry_Date
                                                ,Entry_By
                                                ,Requisition_ID
                                                )
                                                SELECT 
                                                 '99'
                                                ,Amount
                                                ,Received_Date
                                                ,Payment_Media
                                                ,Received_By
                                                ,'Deposit'
                                                ,Vouchar_SN
                                                ,Cust_code
                                                ,Payment_Approved_By
                                                ,Payment_Approved_Date
                                                ,Remarks
                                                ,Entry_Date
                                                ,Entry_By
                                                ,NULL
                                                FROM SBP_Payment_Posting_Request
                                                WHERE Payment_ID=" + paymentId;


            queryUpdateDepPosting = "UPDATE SBP_Payment_Posting_Request"
                               + " SET Approval_Status=1,"
                               + " Payment_Approved_Date='" + cmBal.GetCurrentServerDate().ToString("MM-dd-yyyy") + "'"
                               + " WHERE Payment_ID ="+ paymentId;

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();
                _dbConnection.ExecuteNonQuery(queryString_Payment_withdraw);
                _dbConnection.ExecuteNonQuery(queryString_Payment_Deposit99);
                _dbConnection.ExecuteNonQuery(queryUpdateDepPosting);
                _dbConnection.Commit();
            }
            catch (Exception)
            {
                _dbConnection.Rollback();
                throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
        }

        public double GetBO_OpenCharge(int paymentPurposeId)
        {
            double BO_OpenCharge = 0;
            DataTable data = new DataTable();
            string queryString = @"SELECT  [Amount] 
                                  FROM [dbo].[SBP_Payment_OCC_Purpose]
                                  WHERE [OCC_ID]=" + paymentPurposeId;
            try
            {
                _dbConnection.ConnectDatabase();
                data = _dbConnection.ExecuteQuery(queryString);
                if (data.Rows.Count > 0)
                {
                    BO_OpenCharge = double.Parse(data.Rows[0][0].ToString());
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return BO_OpenCharge;
        }

        public bool IsCustomerExist(string custCode)
        {
            bool exist = true;
            DataTable data = new DataTable();
            string queryString = @"SELECT *  
                                FROM dbo.SBP_Customers
                                WHERE Cust_Code='" + custCode + "'";
            try
            {
                _dbConnection.ConnectDatabase();
                data = _dbConnection.ExecuteQuery(queryString);
                if (data.Rows.Count == 0)
                {
                    exist = false;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return exist;
        }
        public bool IsReceivedBoOpen(string paymentoccId, string voucherNo)
        {
            string queryString = string.Empty;
            bool result = false;
            DataTable dt = new DataTable();
            if (voucherNo != Indication_Fixed_VoucherNo_TransReason.OCC_VoucherNo)
            {
                queryString = @"select * from dbo.SBP_Payment_OOC
                        where Payment_OOC_ID=" +
                              paymentoccId + "' AND Status=1";
            }
            else if (voucherNo == Indication_Fixed_VoucherNo_TransReason.OCC_VoucherNo)
            {
                queryString = @"SELECT *  FROM dbo.SBP_Payment_Posting_Request
                                WHERE Payment_ID="+paymentoccId +" AND Approval_Status=1";
            }
            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(queryString);
                if (dt.Rows.Count > 0)
                {
                    result = true;
                }
            }
            catch
            {
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return result;
        }
    }

}