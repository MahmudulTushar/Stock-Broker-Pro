using System;
using System.Data;
using BusinessAccessLayer.BO;
using DataAccessLayer;
using BusinessAccessLayer.Constants;
namespace BusinessAccessLayer.BAL
{
    public class CustomerBAL
    {
        private DbConnection _dbConnection;

        public CustomerBAL()
        {
            _dbConnection = new DbConnection();
        }

        public void ProcessDatabase(CustomerBO customerBo)
        {

            //txtTotalCharge.Text = dt.Rows[0]["TotalCharge"].ToString();
            //txtHouseCharge.Text = dt.Rows[0]["Ch_Rate"].ToString();
            //txtCDBLCharge.Text = dt.Rows[1]["Ch_Rate"].ToString();

            BO_Opening_InformationBAL TotalChargeBAL = new BO_Opening_InformationBAL();
            DataTable dtBOOpenCharge = TotalChargeBAL.GetChargeHistory();
            //double totalBOOpeningCharge = Convert.ToDouble(dtBOOpenCharge.Rows[0]["TotalCharge"].ToString());
            //double HouseCharge = Convert.ToDouble(dtBOOpenCharge.Rows[0]["Ch_Rate"].ToString());
            //double CDBLCharge = Convert.ToDouble(dtBOOpenCharge.Rows[1]["Ch_Rate"].ToString());
            double HouseCharge = Convert.ToDouble(dtBOOpenCharge.Rows[1]["Amount"].ToString());
            double CDBLCharge = Convert.ToDouble(dtBOOpenCharge.Rows[0]["Amount"].ToString());
            double totalBOOpeningCharge = HouseCharge + CDBLCharge;

            string queryStringBasicInfo = "";
            string queryStringPersonalInfo = "";
            string queryStringContactsInfo = "";
            string queryStringAdditionalInfo = "";
            string queryStringBankInfo = "";
            string queryStringPassportInfo = "";
            string queryStringJointholder = "";
            string queryStringInsertAnnualWithdraw = string.Empty;
            string queryString_GetNewID_PaymentPostingReques=string.Empty;
            string queryString_UpdateAnnualDeposit=string.Empty;
            string queryString_Payment_Deposit98=string.Empty;
            string queryIntoSBP_Income_Entry_HouseCharge100 = string.Empty;
            string queryIntoSBP_Income_Entry_CDBL_Charge400 = string.Empty;
            int PaymentIdWithdraw = 0;
            
            string custStatus = null;

            custStatus = CheckCustomerStatus(customerBo.CustomerCode);
            if (custStatus != Indication_Cust_Status.Pending && custStatus != string.Empty)
                throw new Exception("BO Id is not new");
            else if (custStatus == string.Empty)
                throw new Exception("This Customer Is Not Entried In The System Yet");

            else if (custStatus == Indication_Cust_Status.Pending)
            {
                queryStringBasicInfo =
                    @"UPDATE SBP_Customers 
                        SET "
                    + " Cust_Open_Date=GETDATE()"
                    + ",Cust_Status_ID=1"
                    + ",BO_ID='" + customerBo.BoId
                    + "',BO_Category_ID=" + customerBo.BoCategoryID
                    + ",BO_Type_ID=" + customerBo.BoTypeID
                    + ",BO_Open_Date=GETDATE()"
                    + ",BO_Status_ID=1"
                    + ",Entry_Date=GETDATE()"
                    + ",Entry_By='" + GlobalVariableBO._userName + "'"
                    + " WHERE Cust_Code= '" + customerBo.CustomerCode + "'";
            }

            queryStringPersonalInfo = @"INSERT INTO SBP_Cust_Personal_Info (Cust_Code,Cust_Name,Father_Name,Mother_Name,DOB,Gender,Occupation,FirstHolderNID,SecondHolderNID,ThirdHolderNID,Entry_Date,Entry_By)" +
                " VALUES('" + customerBo.CustomerCode + "','" + customerBo.CustomerName + "','" + customerBo.FatherName + "','" + customerBo.MotherName + "','" + customerBo.BirthDate.ToShortDateString() + "','" + customerBo.Sex + "','" + customerBo.Occupation + "','" + customerBo.firstHolder_NID + "','" + customerBo.secondHolder_NID + "','" + customerBo.thirdHolder_NID + "',GETDATE(),'" + GlobalVariableBO._userName + "')";

            queryStringContactsInfo = @"INSERT INTO SBP_Cust_Contact_Info (Cust_Code, Address1,Address2,Address3,City_Name,Post_Code,Division_Name,Country_Name,Mobile,Fax,Email,Entry_Date,Entry_By)" +
              " VALUES('" + customerBo.CustomerCode + "','" + customerBo.Address1 + "','" + customerBo.Address2 + "','" + customerBo.Address3 + "','" + customerBo.City + "','" + customerBo.PostalCode + "','" + customerBo.District + "','" + customerBo.Country + "','" + customerBo.Phone + "','" + customerBo.Fax + "','" + customerBo.Email + "',GETDATE(),'" + GlobalVariableBO._userName + "')";

            queryStringAdditionalInfo = @"INSERT INTO SBP_Cust_Additional_Info (Cust_Code, Recidency,Nationality,Statement_Cycle_ID,Entry_Date,Entry_By)" +
               " VALUES('" + customerBo.CustomerCode + "','" + customerBo.Residence + "','" + customerBo.Nationality + "'," + customerBo.StatementCycleID + ",GETDATE(),'" + GlobalVariableBO._userName + "')";

            queryStringBankInfo = @"INSERT INTO SBP_Cust_Bank_Info (Cust_Code,Bank_ID, Bank_Name,Branch_ID,Branch_Name,Account_No,Routing_No,Is_EDC,Is_Tax_Exemption,TIN,SWIFT_Code,IBAN,Entry_Date,Entry_By)" +
              " VALUES('" + customerBo.CustomerCode + "'," + customerBo.BankId + ",'" + customerBo.BankName + "'," + customerBo.BranchId + ",'" + customerBo.BranchName + "','" + customerBo.AccountNo + "','" + customerBo.Routing_No + "'," + customerBo.Edc + "," + customerBo.TaxExemption + ",'" + customerBo.Tin + "','" + customerBo.SWIFT_Code + "','" + customerBo.IBAN + "',GETDATE(),'" + GlobalVariableBO._userName + "')";

            queryStringPassportInfo = @"INSERT INTO SBP_Cust_Passport_Info(Cust_Code, Passport_No,Issue_Place,Issue_Date,Expire_Date,Entry_Date,Entry_By)" +
            " VALUES('" + customerBo.CustomerCode + "','" + customerBo.PassportNo + "','" + customerBo.PassportIssuePlace + "','" + customerBo.PassportIssueDate + "','" + customerBo.PassportExpiryDate + "',GETDATE(),'" + GlobalVariableBO._userName + "')";

            queryStringJointholder = "INSERT INTO SBP_Joint_holder (Cust_Code,Joint_Name,Entry_Date,Entry_By) VALUES ('" + customerBo.CustomerCode + "','" + customerBo.SecoundHolder + "',GETDATE(),'" + GlobalVariableBO._userName + "')";

            queryStringInsertAnnualWithdraw = @"
                                               INSERT INTO SBP_Payment(
                                                 --Payment_ID
                                                Cust_code
                                                ,Amount
                                                ,Received_Date
                                                ,Payment_Media
                                                ,Maturity_Days                                               
                                                ,Received_By
                                                ,Deposit_Withdraw         
                                                ,Payment_Approved_By           
                                                ,Payment_Approved_Date         
                                                ,Remarks                    
                                                ,Entry_Date          
                                                ,Entry_By 
                                                ,Voucher_Sl_No
                                                ,Trans_Reason
                                                ,Entry_Branch_ID
                                            )"
                                            +
                                            " VALUES("
                                            //+ PaymentIdWithdraw
                                            + "'" + customerBo.CustomerCode+"'"
                                            //+ "," + Indication_TransWithFixedAmount.BO_Renewal_Charge //paymentOCCBO.Amount 
                                            + "," + totalBOOpeningCharge //paymentOCCBO.Amount 
                                            + ",'" + customerBo.BO_Open_Date+"'"
                                            + ",'" + Indication_PaymentTransaction.Cash+@"'"
                                            + ",NULL"
                                             + ",'" + string.Empty+"'" //paymentOCCBO.RecievedBy
                                             + ",'" + Indication_Fixed_VoucherNo_TransReason.BORenewal_DepositWithdraw+"'"  //paymentOCCBO.DepositWithdraw
                                             + ",'" + GlobalVariableBO._userName+@"'" // paymentOCCBO.PaymentApprovedBy
                                             + ",GETDATE()" //((Convert.ToString(paymentOCCBO.PaymentApprovedDate) == string.Empty) ? "null" : "'" + paymentOCCBO.PaymentApprovedDate.Value.ToString("MM-dd-yyyy") + "'")
                                             + ",'" + string.Empty+"'"
                                             + ",CAST(FLOOR(CAST(GETDATE() AS FLOAT)) AS DATETIME)"
                                             + ",'"+ GlobalVariableBO._userName+@"'"
                                             + ",'" + Indication_Fixed_VoucherNo_TransReason.GetBORenewal_VoucherNo(customerBo.BO_Open_Date.Value)+@"'"//  paymentOCCBO.VoucherNo //.VoucherSlNo
                                             + ",'" + Indication_Fixed_VoucherNo_TransReason.GetBORenewal_TransReason(customerBo.BO_Open_Date.Value)+@"'" //Trans_Reason
                                             + "," + GlobalVariableBO._branchId 
                                          + ")";
            
            queryString_GetNewID_PaymentPostingReques = "SELECT SCOPE_IDENTITY()";

            queryIntoSBP_Income_Entry_HouseCharge100 = @"INSERT INTO [SBP_Database].[dbo].[SBP_IncomeEntry]
                                                           ([VoucherSLNo]
                                                           ,[RcvDate]
                                                           ,[RcvFrom]
                                                           ,[ClientCode]
                                                           ,[Dr_Cr]
                                                           ,[Dr_Amount]
                                                           ,[Cr_Amount]
                                                           ,[Purpose]
                                                           ,[TrnType]
                                                           ,[AccHead]
                                                           ,[AccSubHead]
                                                           ,[RoutingNo]
                                                           ,[BankName]
                                                           ,[BankBranchName]
                                                           ,[DistrictName]
                                                           ,[ChequeNo]
                                                           ,[PayDate]
                                                           ,[Status]
                                                           ,[BrokerBranchID]
                                                           ,[EntryDate]
                                                           ,[EntryBy]
                                                           ,[UpdateDate]
                                                           ,[UpdateBy])
                                                     VALUES
                                                           ('" + Indication_Fixed_VoucherNo_TransReason.GetBORenewal_VoucherNo(customerBo.BO_Open_Date.Value) + @"'
                                                           ,'" +customerBo.BO_Open_Date+@"'
                                                           ,'"+customerBo.CustomerName+@"'
                                                           ,"+customerBo.CustomerCode+@"
                                                           ,'Deposit'
                                                           ," + HouseCharge + @"
                                                           ,0.00
                                                           ,'BO Opening Charge(CDBL)'
                                                           ,'" +Indication_PaymentTransaction.Cash+ @"'
                                                           ,'I003'
                                                           ,'I003i'
                                                           ,''
                                                           ,''
                                                           ,''
                                                           ,''
                                                           ,''
                                                           ,''
                                                           ,'Approved'
                                                           ," + GlobalVariableBO._branchId+@"
                                                           ,'"+GlobalVariableBO._currentServerDate+@"'
                                                           ,'"+GlobalVariableBO._userName+@"'
                                                           ,'" + GlobalVariableBO._currentServerDate + @"'
                                                           ,'" + GlobalVariableBO._userName + @"')";
            queryIntoSBP_Income_Entry_CDBL_Charge400 = @"INSERT INTO [SBP_Database].[dbo].[SBP_IncomeEntry]
                                                           ([VoucherSLNo]
                                                           ,[RcvDate]
                                                           ,[RcvFrom]
                                                           ,[ClientCode]
                                                           ,[Dr_Cr]
                                                           ,[Dr_Amount]
                                                           ,[Cr_Amount]
                                                           ,[Purpose]
                                                           ,[TrnType]
                                                           ,[AccHead]
                                                           ,[AccSubHead]
                                                           ,[RoutingNo]
                                                           ,[BankName]
                                                           ,[BankBranchName]
                                                           ,[DistrictName]
                                                           ,[ChequeNo]
                                                           ,[PayDate]
                                                           ,[Status]
                                                           ,[BrokerBranchID]
                                                           ,[EntryDate]
                                                           ,[EntryBy]
                                                           ,[UpdateDate]
                                                           ,[UpdateBy])
                                                     VALUES
                                                           ('" + Indication_Fixed_VoucherNo_TransReason.GetBORenewal_VoucherNo(customerBo.BO_Open_Date.Value) + @"'
                                                           ,'" + customerBo.BO_Open_Date + @"'
                                                           ,'" + customerBo.CustomerName + @"'
                                                           ," + customerBo.CustomerCode + @"
                                                           ,'Deposit'
                                                           ," + CDBLCharge + @"
                                                           ,0.00
                                                           ,'BO Opening Charge'
                                                           ,'" + Indication_PaymentTransaction.Cash + @"'
                                                           ,'I003'
                                                           ,'I003ii'
                                                           ,''
                                                           ,''
                                                           ,''
                                                           ,''
                                                           ,''
                                                           ,''
                                                           ,'Approved'
                                                           ," + GlobalVariableBO._branchId + @"
                                                           ,'" + GlobalVariableBO._currentServerDate + @"'
                                                           ,'" + GlobalVariableBO._userName + @"'
                                                           ,'" + GlobalVariableBO._currentServerDate + @"'
                                                           ,'" + GlobalVariableBO._userName + @"')";

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();
                _dbConnection.ExecuteNonQuery(queryStringBasicInfo);
                _dbConnection.ExecuteNonQuery(queryStringPersonalInfo);
                _dbConnection.ExecuteNonQuery(queryStringContactsInfo);
                _dbConnection.ExecuteNonQuery(queryStringAdditionalInfo);
                _dbConnection.ExecuteNonQuery(queryStringBankInfo);
                _dbConnection.ExecuteNonQuery(queryStringPassportInfo);
                _dbConnection.ExecuteNonQuery(queryStringJointholder);
                _dbConnection.ExecuteNonQuery(queryStringInsertAnnualWithdraw);
               

                DataTable dt = _dbConnection.ExecuteQuery(queryString_GetNewID_PaymentPostingReques);
                if (dt.Rows.Count > 0)
                    PaymentIdWithdraw = Convert.ToInt32(dt.Rows[0][0].ToString());
                if (PaymentIdWithdraw == 0)
                    throw new Exception("Error occured in new identity to retrieve from database !!");

                _dbConnection.ExecuteNonQuery(queryIntoSBP_Income_Entry_HouseCharge100);
                _dbConnection.ExecuteNonQuery(queryIntoSBP_Income_Entry_CDBL_Charge400);
                
                queryString_UpdateAnnualDeposit = @"
                                                IF EXISTS (Select * From SBP_Payment as t Where t.Trans_Reason='" + Indication_Fixed_VoucherNo_TransReason.BO_DUE_TransReason + "' AND t.Cust_Code='" + customerBo.CustomerCode + @"' AND t.Deposit_Withdraw='Deposit')
                                                BEGIN 
                                                    UPDATE SBP_Payment SET [Trans_Reason]='" + Indication_Fixed_VoucherNo_TransReason.GetBORenewal_VoucherNo(customerBo.BO_Open_Date.Value) + "_" + PaymentIdWithdraw + "' WHERE Trans_Reason='" + Indication_Fixed_VoucherNo_TransReason.BO_DUE_TransReason + "' AND Cust_Code='" + customerBo.CustomerCode + @"' AND Deposit_Withdraw='Deposit'
                                                END
                                                ELSE 
                                                BEGIN
                                                    RAISERROR ('Customer Annual Deposit Not Approved Or Not Entered',16,1) 
                                                END
                ";
                queryString_Payment_Deposit98 = @"INSERT INTO SBP_Payment
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
                                                ,Entry_Branch_ID
                                                )
                                                SELECT 
                                                 '98'
                                                ,Amount
                                                ,Received_Date
                                                ,Payment_Media
                                                ,Received_By
                                                ,'Deposit'
                                                ,Voucher_Sl_No
                                                ,Cust_code
                                                ,Payment_Approved_By
                                                ,Payment_Approved_Date
                                                ,Remarks
                                                ,Entry_Date
                                                ,Entry_By
                                                ,Payment_ID
                                                ,Entry_Branch_ID
                                                FROM SBP_Payment
                                                WHERE Payment_ID=" + PaymentIdWithdraw;
                _dbConnection.ExecuteNonQuery(queryString_UpdateAnnualDeposit);
                _dbConnection.ExecuteNonQuery(queryString_Payment_Deposit98);
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
        public DataTable GetBankBranchIDByBankBranchName(string bankName, string branchName)
        {
            DataTable dataTable = new DataTable();
            string qury;
            qury = "";

            qury = @"SELECT Bank_ID,Branch_ID FROM dbo.SBP_Bank_Branch_Routing_Info
                     WHERE Bank_Name='" + bankName + "' AND Branch_Name ='" + branchName + "'";

            try
            {
                _dbConnection.ConnectDatabase();
                dataTable = _dbConnection.ExecuteQuery(qury);
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

        public void UpdateDatabase(CustomerBO customerBo)
        {
            string queryString = @"UPDATE customer_all SET ct_name='',[fathers_name/ceo/husame]='',sex='',ct_address='',telephone='',nationality='',[date]='',bo_id='',ac_type='')";

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

        public void ProcessCustomerModification(string queryString)
        {
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

        public void Update_BankID_BranchID_In_SBPCustBankInfo()
        {
            string queryString = "";
            queryString = @"SBPUpdate_BankID_BranchID";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
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

        public bool CheckBoId(string boId)
        {
            string queryString = @"SELECT Cust_Code FROM SBP_Customers WHERE BO_ID='" + boId + "';";
            DataTable dataTable;
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

            if (dataTable.Rows.Count > 0)
                return true;
            else
                return false;
        }

        ////////////////////// DAS &&& Adithra //////////////
        public DataTable GetCustomerInfo(string customerCode)
        {
            string customerBOID = "";
            DataTable dtRecord = new DataTable();
            string queryString = "SELECT BO_ID,Cust_Code,(SELECT Cust_Name FROM dbo.SBP_Cust_Personal_Info WHERE dbo.SBP_Cust_Personal_Info.Cust_Code=dbo.SBP_Customers.Cust_Code) AS CustName,(SELECT Cust_Status FROM dbo.SBP_Cust_Status WHERE Cust_Status_ID=dbo.SBP_Customers.Cust_Status_ID) AS Status FROM SBP_Customers WHERE Cust_Code='" + customerCode + "'";

            try
            {
                _dbConnection.ConnectDatabase();
                dtRecord = _dbConnection.ExecuteQuery(queryString);
            }
            catch (Exception)
            {
                throw;
            }

            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dtRecord;

        }

        public DataTable GetBankBranchRoutingInfo(string routingNo)
        {
            DataTable dtRoutingNo = new DataTable();
            string queryString =
                @"SELECT Bank_ID,Bank_Name,Branch_ID,Branch_Name,Routing_No FROM dbo.SBP_Bank_Branch_Routing_Info
                                   WHERE Routing_No='" + routingNo + "'";

            try
            {
                _dbConnection.ConnectDatabase();
                dtRoutingNo = _dbConnection.ExecuteQuery(queryString);
            }
            catch (Exception)
            {
                throw;
            }

            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dtRoutingNo;

        }
        
        public DataTable GetBankBranchRoutingInfo(string bankName, string branchName)
        {
            string routingNo = "";
            DataTable dtRoutingNo = new DataTable();
            string queryString = @"SELECT Bank_ID,Branch_ID,Routing_No FROM dbo.SBP_Bank_Branch_Routing_Info
                                   WHERE Bank_Name='" + bankName + "' AND Branch_Name='" + branchName + "'";

            try
            {
                _dbConnection.ConnectDatabase();
                dtRoutingNo = _dbConnection.ExecuteQuery(queryString);
            }
            catch (Exception)
            {
                throw;
            }

            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dtRoutingNo;

        }

        public string CheckCustomerStatus(string custCode)
        {
            string Cust_Status = string.Empty;
            DataTable dtCust_Status_ID = new DataTable();
            string queryString = @"select csid.Cust_Status
                                    from dbo.SBP_Cust_Status as csid
                                    join dbo.SBP_Customers as c
                                    on csid.Cust_Status_ID=c.Cust_Status_ID
                                    where c.Cust_Code='" + custCode + "'";

            try
            {
                _dbConnection.ConnectDatabase();
                dtCust_Status_ID = _dbConnection.ExecuteQuery(queryString);
                if (dtCust_Status_ID.Rows.Count > 0)
                {
                    Cust_Status = dtCust_Status_ID.Rows[0][0].ToString();
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
            return Cust_Status;

        }

        public string getCustCode(string boId)
        {
            string queryString = @"SELECT Cust_Code FROM SBP_Customers WHERE BO_ID='" + boId + "';";
            DataTable dataTable;
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

            string Data = dataTable.Rows[0][0].ToString();
            return Data;

        }

    }
}
