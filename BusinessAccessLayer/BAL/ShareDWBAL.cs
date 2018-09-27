using System;
using System.Data;
using BusinessAccessLayer.BO;
using DataAccessLayer;

namespace BusinessAccessLayer.BAL
{
    public class ShareDWBAL
    {
        private DbConnection _dbConnection;
        public ShareDWBAL()
        {
            _dbConnection = new DbConnection();
        }
        public void ConnectDatabase()
        { _dbConnection.ConnectDatabase(); }
        public void CloseDatabase()
        { _dbConnection.CloseDatabase(); }
        public void StartTransaction()
        { _dbConnection.StartTransaction(); }
        public void CommitTransaction()
        { _dbConnection.Commit(); }
        public void RollBackTransaction()
        { _dbConnection.Rollback(); }
        public void BulkCopy(DataTable dt, string TableName)
        {
            _dbConnection.BulkCopy(dt, TableName);
        }


        public string GetCust_CodeByBO_ID(string BO_ID)
        {
            DataTable dt = new DataTable();
            string CCode = string.Empty;
            string query = @"SELECT Cust_Code,BO_ID FROM SBP_Customers WHERE BO_ID ='" + BO_ID + @"'";
            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(query);
                CCode = dt.Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return CCode;
        }

        public string GetShortCodeByCompanyName(string CompanyName)
        {
            DataTable dt = new DataTable();
            string SCode = string.Empty;
            string query = @"select Comp_Short_Code,Comp_Name
                            from SBP_Company 
                            where Comp_Name like '%" + CompanyName + @"%'";
            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(query);

                if (dt.Rows.Count>0)
                {
                    if (CompanyName == string.Empty)
                    {
                        SCode = "Unknown";
                    }
                    else
                    { 
                        SCode = dt.Rows[0][0].ToString();
                    }                    
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
            return SCode;
        }
        public DataTable GetCommissionRate(string custCode)
        {
            DataTable dt;
            string query = @"declare @CommissionRate numeric(18,2)
                              set @CommissionRate=ISNULL((SELECT Commission_Rate FROM SBP_Margin_Charge_Plan as mp where mp.Cust_Code='" + custCode + @"'),.5)
                              select @CommissionRate";
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
        public DataTable GetIssuePrice(string custCode, string ShortCode, double CommissionRate, double marketPrice)
        {
//            string query = @"SELECT
//	                                 Comp_Short_Code
//	                                ,Matured_Balance	  
//                                  ,Buy_Rate	  
//                                  ,Market_Rate
//                                  ,(Matured_Balance*Buy_Rate) as WithdrawAmount
//                            FROM dbo.V_RPT_Portfolio_PE
//                            where Cust_Code='" + custCode + @"' And Comp_Short_Code='" + ShortCode + @"'";

//            string query = @"SELECT t.Comp_Short_Code as 'ShortCode'
//                                  ,SUM(t.Balance) as 'TotalShareBalance'
//                                  ,SUM(t.Matured_Balance) AS 'MaturedShareBalance'
//                                  ,SUM(t.Buy_Total) AS 'BuyTotal'
//                                  ,((SUM(t.Buy_Total)*.30)/100) as 'BuyCommission'
//                                  ,SUM(t.Buy_Total)+((SUM(t.Buy_Total)*.30)/100) as 'TotalCost'
//                                  ,SUM(t.Buy_Total)/SUM(t.Matured_Balance) AS 'BuyRateWithoutCommission'
//                                  ,(SUM(t.Buy_Total)+((SUM(t.Buy_Total)*.30)/100))/SUM(t.Matured_Balance) as 'BuyRateWithCommission'
//                                  ,(SELECT Commission_Rate FROM SBP_Margin_Charge_Plan as mp where mp.Cust_Code=t.Cust_Code) as 'CommissionRate'
//                            FROM SBP_Share_Balance_Temp as t
//                            where t.Cust_Code=215 And t.Comp_Short_Code='SPPCL'
//                            GROUP BY t.Comp_Short_Code, t.Cust_Code
//                            HAVING SUM(t.Balance)>0
//                            ";

            DataTable dt = new DataTable();
            string query = @"SELECT Comp_Short_Code as 'Comp_Short_Code'
                                  ,SUM(Matured_Balance) AS 'Matured_Balance'
                                  ,(SUM(Buy_Total)+((SUM(Buy_Total)*" + CommissionRate + @")/100))/SUM(Matured_Balance) as 'Buy_Rate'
                                  ," + marketPrice + @" as 'Market_Rate'
                                  ,(SUM(Matured_Balance)*(SUM(Buy_Total)+((SUM(Buy_Total)*" + CommissionRate + @")/100))/SUM(Matured_Balance)) as 'WithdrawAmount'
                            FROM SBP_Share_Balance_Temp
                            where Cust_Code='" + custCode + @"' And Comp_Short_Code='" + ShortCode + @"'
                            GROUP BY Comp_Short_Code, Cust_Code
                            HAVING SUM(Balance)>0";
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
        public DataTable GetShareBalanceByCCodeAndShortCode(string CCode, string ShortCode)
        {
            DataTable dt = new DataTable();
            string query = @"select Cust_Code,Comp_Short_Code,SUM(Matured_Balance) as S_Balance
                                from SBP_Share_Balance_Temp
                                where Cust_Code='" + CCode + @"' AND Comp_Short_Code='" + ShortCode + @"'
                                group by Cust_Code,Comp_Short_Code";
            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(query);
            }
            catch (Exception ex) { throw ex; }
            finally { _dbConnection.CloseDatabase(); } return dt;
        }
        public DataTable GetDepositInformationFromDB_Table(string CCode,string bID,  string withCompShortCode)
        {
            DataTable dt = new DataTable();
            string query = @"select * 
                                from SBP_ShareDepInfoForConversion
                                where Cust_Code='" + CCode + @"' and BOID='" + bID + @"' And WithdrawCompanyShortCode='" + withCompShortCode + @"'";
            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(query);
            }
            catch (Exception ex) { throw ex; }           
            finally { _dbConnection.CloseDatabase(); } return dt;
        }
        public DataTable getNullBuyRate()
        {
            DataTable dt;
            string query = @"Select  Cust_Code
		                            ,CustomerName
		                            ,BOID
		                            ,DB_ShareBalance as 'DB_Share'
		                            ,DepositQty as 'File_Share'
		                            ,DB_FracPoint as 'FracShare' 
		                            ,DB_NewShareRate as 'Buy_Rate'
                            from SBP_ShareDepInfoForConversion
                            where DB_NewShareRate=0";
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
        public void Truncate_SBP_ShareDepInfoForConversion()
        {
            string Query = @"truncate table SBP_ShareDepInfoForConversion";
            try
            {
                _dbConnection.ExecuteNonQuery(Query);
            }
            catch
            { throw; }
        }
        public void UpdateRecord_Withdraw(ShareDWBO_Conversion sBO)
        {
//            string query = @"UPDATE TestSBP.dbo.SBP_Share_DW
//                                    SET Deposit_Type='" + sBO.DepositType + @"',Issue_Price=" + sBO.IssuePrice + @", Issue_Amount=" + sBO.IssueAmount + @" ,FractureValue=" + sBO.DB_FractureValue + @"
//                                    Where Comp_Short_Code='SUMITPOWER' 
//                                    AND Deposit_Type='IPO'
//                                    And Deposit_Withdraw='Deposit' 
//                                    AND Received_Date='2016-10-09 00:00:00.000' AND Quantity=" + sBO.Quantity + @" AND Cust_Code=" + sBO.CustCode + @"";

            string query = @"UPDATE [TestSBP].[dbo].[SBP_Share_DW]
                                SET Deposit_Type='" + sBO.DepositType + @"',Issue_Price=" + sBO.IssuePrice + @",Issue_Amount=" + sBO.IssueAmount + @",FractureValue=" + sBO.DB_FractureValue + @"
                                Where Comp_Short_Code='SPPCL' 
                                And Deposit_Withdraw='Withdraw' 
                                And Share_DW_ID>205989 
                                AND Vouchar_No='74DP131016' 
                                AND FractureValue IS NULL
                                AND Quantity=" + sBO.Quantity + @"
                                AND Cust_Code=" + sBO.CustCode + @"";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(query);
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
        public void UpdateRecord_ForConversion(ShareDWBO_Conversion sBO)
        {
            string query = @"UPDATE [SBP_Database].[dbo].[SBP_Share_DW]
                                    SET Deposit_Type='" + sBO.DepositType + @"',Issue_Price=" + sBO.IssuePrice + @", Issue_Amount=" + sBO.IssueAmount + @" ,FractureValue=" + sBO.DB_FractureValue + @"
                                    Where Comp_Short_Code='SUMITPOWER' 
                                    AND Deposit_Type='IPO'
                                    And Deposit_Withdraw='Deposit' 
                                    AND Received_Date='2016-10-09 00:00:00.000' AND Quantity=" + sBO.Quantity + @" AND Cust_Code=" + sBO.CustCode + @"";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(query);
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
        public void OnlyWithdraw_ForConvertion(ShareDWBO_Conversion sbo)
        {
            ShareDWBAL sBAL = new ShareDWBAL();
            DataTable dt = new DataTable();

            dt = GetDepositInformationFromDB_Table(sbo.CustCode, sbo.BO_ID, sbo.CompanyShortCode);
            if (dt.Rows.Count == 0)
                throw new Exception("Error. Try again and check Company Name carefully.");
            if (sbo.Quantity != Convert.ToInt32(dt.Rows[0]["DB_ShareBalance"].ToString()))
                throw new Exception("File Quantity Is Not Equal to Database Quantity.");
            if (sbo.OtherShareQty != Convert.ToInt32(dt.Rows[0]["DepositQty"].ToString()))
                throw new Exception("Deposited Quantity does not match according the file.");
            //if (sbo.IssuePrice != float.Parse(dt.Rows[0]["DB_NewShareRate"].ToString()))
            //    throw new Exception("Deposited Share Rate does not match according the file.");
            //if (sbo.IssueAmount != float.Parse(dt.Rows[0]["DB_TotalShareValue"].ToString()))
            //    throw new Exception("Deposited total share amount does not match according the file.");
            //if (sbo.DB_FracPoint != float.Parse(dt.Rows[0]["DB_FracPoint"].ToString()))
            //    throw new Exception("Deposited Fracture value does not match according the file.");


            string SBP_Share_DW = @"INSERT INTO [SBP_Database].[dbo].[SBP_Share_DW]
                                       ([Cust_Code]
                                       ,[Comp_Short_Code]
                                       ,[Quantity]
                                       ,[Lockedin_Quantity]
                                       ,[Available_Quantity]
                                       ,[Lockedin_Expiry_Date]
                                       ,[Deposit_Withdraw]
                                       ,[Record_Date]
                                       ,[Received_Date]
                                       ,[Effective_Date]
                                       ,[Vouchar_No]
                                       ,[No_Script]
                                       ,[Deposit_Type]
                                       ,[Share_Type]
                                       ,[Issue_Price]
                                       ,[Issue_Amount]
                                       ,[Entry_Date]
                                       ,[Entry_By]
                                       ,[FractureValue])
                                 VALUES
                                       ('" + sbo.CustCode + @"'
                                       ,'" + sbo.CompanyShortCode + @"'
                                       ," + sbo.Quantity + @"
                                       ," + sbo.LockedInQuantity + @"
                                       ," + sbo.AvailableQuantity + @"
                                       ,'" + sbo.Lockedin_Expiry_Date + @"'
                                       ,'" + sbo.DepositWithdraw + @"'
                                       ,'" + sbo.Received_Date + @"'
                                       ,'" + sbo.Received_Date + @"'
                                       ,'" + sbo.EffectiveDate + @"'
                                       ,'" + sbo.VoucherNo + @"'
                                       ," + sbo.NoScript + @"
                                       ,'" + sbo.DepositType + @"'
                                       ,'CDBL'
                                       ," + sbo.IssuePrice + @"
                                       ," + sbo.IssueAmount + @"
                                       ,'" + sbo.Received_Date + @"'
                                       ,'" + GlobalVariableBO._userName + @"'
                                       ," + sbo.DB_FractureValue + @")";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(SBP_Share_DW);
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

        public void OnlyDeposit_ForConvertion(ShareDWBO_Conversion sbo)
        {
            string SBP_Share_DW = @"INSERT INTO [SBP_Database].[dbo].[SBP_Share_DW]
                                       ([Cust_Code]
                                       ,[Comp_Short_Code]
                                       ,[Quantity]
                                       ,[Lockedin_Quantity]
                                       ,[Available_Quantity]
                                       ,[Lockedin_Expiry_Date]
                                       ,[Deposit_Withdraw]
                                       ,[Record_Date]
                                       ,[Received_Date]
                                       ,[Effective_Date]
                                       ,[Vouchar_No]
                                       ,[No_Script]
                                       ,[Deposit_Type]
                                       ,[Share_Type]
                                       ,[Issue_Price]
                                       ,[Issue_Amount]
                                       ,[Entry_Date]
                                       ,[Entry_By]
                                       ,[FractureValue])
                                 VALUES
                                       ('" + sbo.CustCode + @"'
                                       ,'" + sbo.CompanyShortCode + @"'
                                       ," + sbo.Quantity + @"
                                       ," + sbo.LockedInQuantity + @"
                                       ," + sbo.AvailableQuantity + @"
                                       ,'" + sbo.Lockedin_Expiry_Date + @"'
                                       ,'" + sbo.DepositWithdraw + @"'
                                       ,'" + sbo.Received_Date + @"'
                                       ,'" + sbo.Received_Date + @"'
                                       ,'" + sbo.EffectiveDate + @"'
                                       ,'" + sbo.VoucherNo + @"'
                                       ," + sbo.NoScript + @"
                                       ,'" + sbo.DepositType + @"'
                                       ,'CDBL'
                                       ," + sbo.IssuePrice + @"
                                       ," + sbo.IssueAmount + @"
                                       ,'" + sbo.Received_Date + @"'
                                       ,'" + GlobalVariableBO._userName + @"'
                                       ," + sbo.DB_FractureValue + @")";

            string SBP_ShareDepInfoForConversion = @"INSERT INTO [SBP_Database].[dbo].[SBP_ShareDepInfoForConversion]
                                       ([DepositCompanyShortCode]
                                       ,[WithdrawCompanyShortCode]
                                       ,[EffectiveDate]
                                       ,[Cust_Code]
                                       ,[BOID]
                                       ,[CustomerName]
                                       ,[DepositQty]
                                       ,[LockinBalance]
                                       ,[LockInExpDate]
                                       ,[DB_ShareBalance]
                                       ,[DB_ShareAfterRatio]
                                       ,[DB_FracPoint]
                                       ,[DB_NewShareRate]
                                       ,[DB_TotalShareValue]
                                       ,[DB_FractureValue]
                                       ,[DB_NewInvestment]
                                       ,[UserName]
                                       ,[EntryDate])
                                 VALUES
                                       ('" + sbo.CompanyShortCode + @"'
                                       ,'" + sbo.OtherCompanyShortCode + @"'
                                       ,'" + sbo.EffectiveDate + @"'
                                       ,'" + sbo.CustCode + @"'
                                       ,'" + sbo.BO_ID + @"'
                                       ,'" + sbo.CustName + @"'
                                       ," + sbo.Quantity + @"
                                       ," + sbo.LockedInQuantity + @"
                                       ,'" + sbo.Lockedin_Expiry_Date + @"'
                                       ," + sbo.DB_ShareBalance + @"
                                       ," + sbo.DB_ShareAfterRatio + @"
                                       ," + sbo.DB_FracPoint + @"
                                       ," + sbo.DB_NewShareRate + @"
                                       ," + sbo.DB_TotalShareValue + @"
                                       ," + sbo.DB_FractureValue + @"
                                       ," + sbo.DB_NewInvestment + @"
                                       ,'" + GlobalVariableBO._userName + @"'
                                       ,'" + sbo.RecordDate + @"')";

            try
            {
                //_dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(SBP_Share_DW);
                _dbConnection.ExecuteNonQuery(SBP_ShareDepInfoForConversion);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

//        public void OnlyDeposit_ForConvertion(ShareDWBO_Conversion shareDwbo)
//        {
//            System.Data.SqlTypes.SqlDateTime nullDate = System.Data.SqlTypes.SqlDateTime.Null;

//            string queryString = string.Empty;
//            string queryString_DBStore = string.Empty;
//            CommonBAL commonBAL = new CommonBAL();
//            shareDwbo.ShareDwId = commonBAL.GenerateID("SBP_Share_DW", "Share_DW_ID");
//            queryString = @"SBPSaveShareDW";
////            queryString_DBStore = @"INSERT INTO [SBP_Database].[dbo].[SBP_ShareDepInfoForConversion]
////                                                                   ([CompanyShortCode]
////                                                                   ,[EffectiveDate]
////                                                                   ,[BOID]
////                                                                   ,[CurrentBalance]
////                                                                   ,[LockinBalance]
////                                                                   ,[LockInExpDate]
////                                                                   ,[DB_ShareBalance]
////                                                                   ,[DB_ShareAfterRatio]
////                                                                   ,[DB_FracPoint]
////                                                                   ,[DB_NewShareRate]
////                                                                   ,[DB_TotalShareValue]
////                                                                   ,[DB_FractureValue]
////                                                                   ,[DB_NewInvestment])
////                                                             VALUES
////                                                                   ('" + shareDwbo.CompanyShortCode + @"'
////                                                                   ,'" + shareDwbo.EffectiveDate + @"'
////                                                                   ,'"+shareDwbo.BO_ID+@"'
////                                                                   ,"+shareDwbo.Quantity+@"
////                                                                   ,"+shareDwbo.LockedInQuantity+@"
////                                                                   ,'"+shareDwbo.Lockedin_Expiry_Date+@"'
////                                                                   ,<DB_ShareBalance, int,>
////                                                                   ,<DB_ShareAfterRatio, float,>
////                                                                   ,<DB_FracPoint, float,>
////                                                                   ,<DB_NewShareRate, float,>
////                                                                   ,<DB_TotalShareValue, float,>
////                                                                   ,<DB_FractureValue, float,>
////                                                                   ,<DB_NewInvestment, float,>)";
//            try
//            {
//                //_dbConnection.ConnectDatabase();
//                _dbConnection.ActiveStoredProcedure();
//                _dbConnection.AddParameter("@ShareDwId", SqlDbType.Int, shareDwbo.ShareDwId);
//                _dbConnection.AddParameter("@CustCode", SqlDbType.NVarChar, shareDwbo.CustCode);
//                _dbConnection.AddParameter("@CompanyShortCode", SqlDbType.NVarChar, shareDwbo.CompanyShortCode);
//                _dbConnection.AddParameter("@Quantity", SqlDbType.Int, shareDwbo.Quantity);
//                _dbConnection.AddParameter("@DepositWithdraw", SqlDbType.NVarChar, shareDwbo.DepositWithdraw);
//                _dbConnection.AddParameter("@RecordDate", SqlDbType.DateTime, shareDwbo.RecordDate == DateTime.MinValue ? nullDate : shareDwbo.RecordDate.Date);
//                _dbConnection.AddParameter("@Received_Date", SqlDbType.DateTime, shareDwbo.Received_Date == DateTime.MinValue ? nullDate : shareDwbo.Received_Date.Date);
//                _dbConnection.AddParameter("@EffectiveDate", SqlDbType.DateTime, shareDwbo.EffectiveDate == DateTime.MinValue ? nullDate : shareDwbo.EffectiveDate.Date);
//                _dbConnection.AddParameter("@Lockedin_Quantity", SqlDbType.Int, shareDwbo.LockedInQuantity);
//                _dbConnection.AddParameter("@Available_Quantity", SqlDbType.Int, shareDwbo.AvailableQuantity);
//                _dbConnection.AddParameter("@Lockedin_Expiry_Date", SqlDbType.DateTime, shareDwbo.Lockedin_Expiry_Date == DateTime.MinValue ? nullDate : shareDwbo.Lockedin_Expiry_Date.Date);
//                _dbConnection.AddParameter("@VoucherNo ", SqlDbType.NVarChar, shareDwbo.VoucherNo);
//                _dbConnection.AddParameter("@NoScript", SqlDbType.Int, shareDwbo.NoScript);
//                _dbConnection.AddParameter("@DepositType", SqlDbType.VarChar, shareDwbo.DepositType);
//                _dbConnection.AddParameter("@ShareType ", SqlDbType.VarChar, shareDwbo.ShareType);
//                _dbConnection.AddParameter("@IssuePrice", SqlDbType.Float, shareDwbo.IssuePrice);
//                _dbConnection.AddParameter("@IssueAmount", SqlDbType.Float, shareDwbo.IssueAmount);
//                _dbConnection.AddParameter("@CDBLCharge", SqlDbType.Float, shareDwbo.CDBLCharge);
//                _dbConnection.AddParameter("@entryBy", SqlDbType.VarChar, GlobalVariableBO._userName);
//                _dbConnection.AddParameter("@FracValue", SqlDbType.Float, shareDwbo.DB_FractureValue);
//                _dbConnection.ExecuteProQuery(queryString);
//            }
//            catch (Exception exception)
//            {
//                throw exception;
//            }
//            finally
//            {
//                //_dbConnection.CloseDatabase();
//            }
//        }
        public void DepositForConvertion(ShareDWBO shareDwbo)
        {

            System.Data.SqlTypes.SqlDateTime nullDate = System.Data.SqlTypes.SqlDateTime.Null;

            string queryString = "";
            CommonBAL commonBAL = new CommonBAL();
            shareDwbo.ShareDwId = commonBAL.GenerateID("SBP_Share_DW", "Share_DW_ID");
            queryString = @"SBPSaveShareDW";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@ShareDwId", SqlDbType.Int, shareDwbo.ShareDwId);
                _dbConnection.AddParameter("@CustCode", SqlDbType.NVarChar, shareDwbo.CustCode);
                _dbConnection.AddParameter("@CompanyShortCode", SqlDbType.NVarChar, shareDwbo.CompanyShortCode);
                _dbConnection.AddParameter("@Quantity", SqlDbType.Int, shareDwbo.Quantity);
                 _dbConnection.AddParameter("@DepositWithdraw", SqlDbType.NVarChar, shareDwbo.DepositWithdraw);
                _dbConnection.AddParameter("@RecordDate", SqlDbType.DateTime, shareDwbo.RecordDate == DateTime.MinValue ? nullDate : shareDwbo.RecordDate.Date);
                _dbConnection.AddParameter("@Received_Date", SqlDbType.DateTime, shareDwbo.Received_Date == DateTime.MinValue ? nullDate : shareDwbo.Received_Date.Date);
                _dbConnection.AddParameter("@EffectiveDate", SqlDbType.DateTime, shareDwbo.EffectiveDate == DateTime.MinValue ? nullDate : shareDwbo.EffectiveDate.Date);
                _dbConnection.AddParameter("@Lockedin_Quantity", SqlDbType.Int, shareDwbo.LockedInQuantity);
                _dbConnection.AddParameter("@Available_Quantity", SqlDbType.Int, shareDwbo.AvailableQuantity);
                _dbConnection.AddParameter("@Lockedin_Expiry_Date", SqlDbType.DateTime, shareDwbo.Lockedin_Expiry_Date == DateTime.MinValue ? nullDate : shareDwbo.Lockedin_Expiry_Date.Date);
                _dbConnection.AddParameter("@VoucherNo ", SqlDbType.NVarChar, shareDwbo.VoucherNo);
                _dbConnection.AddParameter("@NoScript", SqlDbType.Int, shareDwbo.NoScript);
                _dbConnection.AddParameter("@DepositType", SqlDbType.VarChar, shareDwbo.DepositType);
                _dbConnection.AddParameter("@ShareType ", SqlDbType.VarChar, shareDwbo.ShareType);
                _dbConnection.AddParameter("@IssuePrice", SqlDbType.Float, shareDwbo.IssuePrice);
                _dbConnection.AddParameter("@IssueAmount", SqlDbType.Float, shareDwbo.IssueAmount);
                _dbConnection.AddParameter("@CDBLCharge", SqlDbType.Float, shareDwbo.CDBLCharge);
                _dbConnection.AddParameter("@entryBy", SqlDbType.VarChar, GlobalVariableBO._userName);
                _dbConnection.AddParameter("@FracValue", SqlDbType.Float, shareDwbo.FracValue);
                _dbConnection.ExecuteProQuery(queryString);
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
        public void WithdrawForConvertion(ShareDWBO shareDwbo)
        {
            //////////////////           "Please, Rewrite..."+"\r\n"+"It Exceeds The Existing Balance..."
            DataTable dt = new DataTable();
            string CCode = shareDwbo.CustCode;
            string ShortCode = shareDwbo.CompanyShortCode;
            dt = GetShareBalanceByCCodeAndShortCode(CCode, ShortCode);
            if (shareDwbo.Quantity > Convert.ToInt32(dt.Rows[0]["S_Balance"].ToString()))
                throw new Exception("File Quantity Is More Than Actual Quantity...." + "\r\n" + "File Qty is " + shareDwbo.Quantity + @" and Actual Qty is " + dt.Rows[0]["S_Balance"].ToString() + @"");
            else if (shareDwbo.Quantity < Convert.ToInt32(dt.Rows[0]["S_Balance"].ToString()))
                throw new Exception("File Quantity Is Less Than Actual Quantity...." + "\r\n" + "File Qty is " + shareDwbo.Quantity + @" and Actual Qty is " + dt.Rows[0]["S_Balance"].ToString() + @"");
            //////////////////

            System.Data.SqlTypes.SqlDateTime nullDate = System.Data.SqlTypes.SqlDateTime.Null;

            string queryString = "";
            CommonBAL commonBAL = new CommonBAL();
            shareDwbo.ShareDwId = commonBAL.GenerateID("SBP_Share_DW", "Share_DW_ID");
            queryString = @"SBPSaveShareDW";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@ShareDwId", SqlDbType.Int, shareDwbo.ShareDwId);
                _dbConnection.AddParameter("@CustCode", SqlDbType.NVarChar, shareDwbo.CustCode);
                _dbConnection.AddParameter("@CompanyShortCode", SqlDbType.NVarChar, shareDwbo.CompanyShortCode);
                _dbConnection.AddParameter("@Quantity", SqlDbType.Int, shareDwbo.Quantity);
                _dbConnection.AddParameter("@DepositWithdraw", SqlDbType.NVarChar, shareDwbo.DepositWithdraw);
                _dbConnection.AddParameter("@RecordDate", SqlDbType.DateTime, shareDwbo.RecordDate == DateTime.MinValue ? nullDate : shareDwbo.RecordDate.Date);
                _dbConnection.AddParameter("@Received_Date", SqlDbType.DateTime, shareDwbo.Received_Date == DateTime.MinValue ? nullDate : shareDwbo.Received_Date.Date);
                _dbConnection.AddParameter("@EffectiveDate", SqlDbType.DateTime, shareDwbo.EffectiveDate == DateTime.MinValue ? nullDate : shareDwbo.EffectiveDate.Date);
                _dbConnection.AddParameter("@Lockedin_Quantity", SqlDbType.Int, shareDwbo.LockedInQuantity);
                _dbConnection.AddParameter("@Available_Quantity", SqlDbType.Int, shareDwbo.AvailableQuantity);
                _dbConnection.AddParameter("@Lockedin_Expiry_Date", SqlDbType.DateTime, shareDwbo.Lockedin_Expiry_Date == DateTime.MinValue ? nullDate : shareDwbo.Lockedin_Expiry_Date.Date);
                _dbConnection.AddParameter("@VoucherNo ", SqlDbType.NVarChar, shareDwbo.VoucherNo);
                _dbConnection.AddParameter("@NoScript", SqlDbType.Int, shareDwbo.NoScript);
                _dbConnection.AddParameter("@DepositType", SqlDbType.VarChar, shareDwbo.DepositType);
                _dbConnection.AddParameter("@ShareType ", SqlDbType.VarChar, shareDwbo.ShareType);
                _dbConnection.AddParameter("@IssuePrice", SqlDbType.Float, shareDwbo.IssuePrice);
                _dbConnection.AddParameter("@IssueAmount", SqlDbType.Float, shareDwbo.IssueAmount);
                _dbConnection.AddParameter("@CDBLCharge", SqlDbType.Float, shareDwbo.CDBLCharge);
                _dbConnection.AddParameter("@entryBy", SqlDbType.VarChar, GlobalVariableBO._userName);
                _dbConnection.AddParameter("@FracValue", SqlDbType.Float, shareDwbo.FracValue);
                _dbConnection.ExecuteProQuery(queryString);
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

        public void Insert(ShareDWBO shareDwbo)
        {
            System.Data.SqlTypes.SqlDateTime nullDate =System.Data.SqlTypes.SqlDateTime.Null;

            string queryString = "";
            CommonBAL commonBAL = new CommonBAL();
            shareDwbo.ShareDwId = commonBAL.GenerateID("SBP_Share_DW", "Share_DW_ID");
            queryString = @"SBPSaveShareDW";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@ShareDwId", SqlDbType.Int, shareDwbo.ShareDwId);
                _dbConnection.AddParameter("@CustCode", SqlDbType.NVarChar, shareDwbo.CustCode);
                _dbConnection.AddParameter("@CompanyShortCode", SqlDbType.NVarChar, shareDwbo.CompanyShortCode);
                _dbConnection.AddParameter("@Quantity", SqlDbType.Int, shareDwbo.Quantity);
                _dbConnection.AddParameter("@DepositWithdraw", SqlDbType.NVarChar, shareDwbo.DepositWithdraw);
                _dbConnection.AddParameter("@RecordDate", SqlDbType.DateTime, shareDwbo.RecordDate == DateTime.MinValue ? nullDate : shareDwbo.RecordDate.Date);
                _dbConnection.AddParameter("@Received_Date", SqlDbType.DateTime, shareDwbo.Received_Date == DateTime.MinValue ? nullDate : shareDwbo.Received_Date.Date);
                _dbConnection.AddParameter("@EffectiveDate", SqlDbType.DateTime, shareDwbo.EffectiveDate == DateTime.MinValue ? nullDate : shareDwbo.EffectiveDate.Date);
                _dbConnection.AddParameter("@Lockedin_Quantity", SqlDbType.Int, shareDwbo.LockedInQuantity);
                _dbConnection.AddParameter("@Available_Quantity", SqlDbType.Int, shareDwbo.AvailableQuantity);
                _dbConnection.AddParameter("@Lockedin_Expiry_Date", SqlDbType.DateTime, shareDwbo.Lockedin_Expiry_Date == DateTime.MinValue ? nullDate : shareDwbo.Lockedin_Expiry_Date.Date);
                _dbConnection.AddParameter("@VoucherNo ", SqlDbType.NVarChar, shareDwbo.VoucherNo);
                _dbConnection.AddParameter("@NoScript", SqlDbType.Int,  shareDwbo.NoScript);
                _dbConnection.AddParameter("@DepositType", SqlDbType.VarChar, shareDwbo.DepositType );
                _dbConnection.AddParameter("@ShareType ", SqlDbType.VarChar,  shareDwbo.ShareType);
                _dbConnection.AddParameter("@IssuePrice", SqlDbType.Float, shareDwbo.IssuePrice );
                _dbConnection.AddParameter("@IssueAmount", SqlDbType.Float, shareDwbo.IssueAmount );
                _dbConnection.AddParameter("@CDBLCharge", SqlDbType.Float, shareDwbo.CDBLCharge);
                _dbConnection.AddParameter("@entryBy", SqlDbType.VarChar, GlobalVariableBO._userName);
                _dbConnection.AddParameter("@FracValue", SqlDbType.Float, shareDwbo.FracValue);
                _dbConnection.ExecuteProQuery(queryString);
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


        public decimal GetCommissionSearch(string Cust_Code, string ShareType)
        {
            decimal data = 0; ;
            string queryString = "";
            if (!string.IsNullOrEmpty(ShareType))
            {
                queryString = @"DECLARE @GroupID INT
                            DECLARE @Commission FLOAT
                            DECLARE @Commission1 FLOAT
                            DECLARE @FinalCommission FLOAT


                            SET @GroupID = (Select Cust_Group_ID from SBP_Customers Where Cust_Code='" + Cust_Code + @"')
                            SET @Commission =(Select com.Commission FROM SBP_Cust_Commissions as com
		                            WHERE com.Cust_Group_ID=@GroupID
		                            AND com.Share_Type='" + ShareType + @"'
		                            AND com.Effective_Date=(
					                            SELECT MAX(t.Effective_Date) 
					                            FROM SBP_Cust_Commissions as t 
					                            WHERE t.Cust_Group_ID=@GroupID
					                            AND t.Share_Type='" + ShareType + @"'
		                            ))		
                            		
                            SET @Commission1 =(Select ISNULL((Commission_Rate/100),0) AS 'Commission' from SBP_Margin_Charge_Plan 
                            Where Cust_Code ='" + Cust_Code + @"' AND ISNULL(Commission_Rate,0)> 0 )


                            IF (@Commission1 > 0 )
                                SET @FinalCommission = @Commission1
                            ELSE
                                 SET @FinalCommission = @Commission
                             Select @FinalCommission ";
                try
                {
                    _dbConnection.ConnectDatabase();
                    DataTable dt = _dbConnection.ExecuteQuery(queryString);
                    foreach (DataRow dr in dt.Rows)
                    {
                        data = Convert.ToDecimal(dr[0].ToString());
                    }

                }
                catch (Exception)
                {
                    throw;
                }
            }
            return data;
        }



        public void Insert_OTC_Share(OTCMarketBo oTCMarketBo)
        {

            string queryStringInsLog = "";
            queryStringInsLog = @"INSERT INTO [SBP_Otc_Share_DW]
                                           ([Cust_Code]
                                           ,[Deposit_Withdraw]
                                           ,[Comp_Short_Code]
                                           ,[Share_Type]
                                           ,[TradeQty]
                                           ,[TradePrice]
                                           ,[Value]
                                           ,[HowlaCharge]
                                           ,[LagaCharge]
                                           ,[Tax]
                                           ,[VoucherNo]
                                           ,[TransferCode]
                                           ,[Remark]
                                           ,[CreatedBy]
                                           ,[LastModifiedDate])
                                     VALUES
                                           ('" + oTCMarketBo.Cust_Code + @"'
                                           ,'" + oTCMarketBo.Deposit_Withdraw + @"'
                                           ,'" + oTCMarketBo.Comp_Short_Code + @"'
                                           ,'" + oTCMarketBo.Share_Type + @"'
                                          ,'" + oTCMarketBo.TradeQty + @"'
                                          ,'" + oTCMarketBo.TradePrice + @"'
                                          ,'" + oTCMarketBo.Value + @"'
                                          ,'" + oTCMarketBo.HowlaCharge + @"'
                                          ,'" + oTCMarketBo.LagaCharge + @"'
                                          ,'" + oTCMarketBo.Tax + @"'
                                          ,'" + oTCMarketBo.VoucherNo + @"'
                                          ,'" + oTCMarketBo.TransferCode + @"'
                                          ,'" + oTCMarketBo.Remark + @"'
                                          ,'" + GlobalVariableBO._userName + @"'
                                          ,GETDATE())";

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();
                _dbConnection.ExecuteNonQuery(queryStringInsLog);
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

        public DataTable GetCompanyName(string companyShortCode)
        {
            DataTable dataTable;
            string queryString = "";
            queryString = "SELECT Comp_Name FROM SBP_Company,SBP_Share_DW WHERE SBP_Share_DW.Comp_Short_Code=SBP_Company.Comp_Short_Code AND SBP_Share_DW.Comp_Short_Code='" + companyShortCode + "'";
            try
            {
                _dbConnection.ConnectDatabase();
                dataTable = _dbConnection.ExecuteQuery(queryString);
            }
            catch (Exception)
            {
                throw;
            }
            return dataTable;
        }

        public DataTable GetLockedinQty(string companyShortCode)
        {
            DataTable dataTable;
            string queryString = "";
            queryString = "SELECT SUM(Lockedin_Quantity) as 'LockedinQty' FROM SBP_Share_DW WHERE Comp_Short_Code='" + companyShortCode + "'";
            try
            {
                _dbConnection.ConnectDatabase();
                dataTable = _dbConnection.ExecuteQuery(queryString);
            }
            catch (Exception)
            {
                throw;
            }
            return dataTable;
        }

        public void FreeLockedInShare(string companyShortCode)
        {
            string queryString = "";
            queryString = @"SBPFreeLockedInShare";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@companyShortCode", SqlDbType.NVarChar,companyShortCode);
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

        public bool CheckShareQtyDoesAvail(int Quantity, string CustCode, string companyName)
        {
            DataTable dataTable;
            string queryString = "";
            queryString = " SELECT DISTINCT(Cust_Code)FROM SBP_Share_Balance_Temp WHERE Cust_Code='"+CustCode+"' AND Comp_Short_Code='"+companyName+"' AND "+Quantity+" <= (SELECT SUM(Matured_Balance) AS 'AvailQty' FROM SBP_Share_Balance_Temp WHERE Cust_Code='"+CustCode+"' AND Comp_Short_Code='"+companyName+"')";
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
            if (dataTable.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckShareDoesExist(string companyName, string CustCode)
        {
            DataTable dataTable;
            string queryString = "";
            queryString = "SELECT Comp_Short_Code FROM SBP_Share_Balance_Temp WHERE Comp_Short_Code='" + companyName + "' AND Cust_Code='" + CustCode + "'";
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
            if (dataTable.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
           
        }

        public DataTable SearchForDelete(string criteriaString)
        {
            DataTable dataTable;
            dataTable = null;
            string queryString = "";
            queryString = "SELECT Share_DW_ID,Cust_Code as 'Customer Code',Comp_Short_Code AS 'Company',Vouchar_No AS 'Vouchar No',Deposit_Withdraw AS 'Deposit/Withdraw',Received_Date AS 'Received Date',Deposit_Type AS 'Type' FROM SBP_Share_DW WHERE 0=0 " + criteriaString + "";
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

        public void DeleteShareDW(int shareDWID)
        {
            string queryStringDel = "";
            string queryStringInsLog = "";
            queryStringInsLog = "INSERT INTO SBP_Share_DW_Delete_Log(Sl_No,Share_DW_ID,Cust_Code,Comp_Short_Code,Quantity,Lockedin_Quantity,Available_Quantity,Deposit_Withdraw,Received_Date,Effective_Date,Vouchar_No,No_Script,Deposit_Type,Share_Type,Issue_Price,Issue_Amount,CDBL_Charge,Entry_Date,Entry_By,Delete_Date,Deleted_By) SELECT " + GetSlNo() + ","+shareDWID+",Cust_Code,Comp_Short_Code,Quantity,Lockedin_Quantity,Available_Quantity,Deposit_Withdraw,Received_Date,Effective_Date,Vouchar_No,No_Script,Deposit_Type,Share_Type,Issue_Price,Issue_Amount,CDBL_Charge,Entry_Date,Entry_By,GETDATE(),'" + GlobalVariableBO._userName + "' FROM SBP_Share_DW WHERE Share_DW_ID=" + shareDWID + "";
            queryStringDel = "DELETE FROM SBP_Share_DW WHERE Share_DW_ID=" + shareDWID + "";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();
                _dbConnection.ExecuteNonQuery(queryStringInsLog);
                _dbConnection.ExecuteNonQuery(queryStringDel);
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

        private long GetSlNo()
        {
            CommonBAL commonBAL = new CommonBAL();
            long SlNo = commonBAL.GenerateID("SBP_Share_DW_Delete_Log", "Sl_No");
            return SlNo;
        }

        public void ShareDWInitialProcessing()
        {
            try
            {
                GenerateShareBalanceTemp();
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void GenerateShareBalanceTemp()
        {
            string queryString = @"EXECUTE GenerateShareBalanceTemp;";

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

        public DataTable GetDayShareSummary(DateTime date)
        {
            string queryString = "SELECT Cust_Code AS 'Client Code',(SELECT Cust_Name FROM dbo.SBP_Cust_Personal_Info WHERE dbo.SBP_Cust_Personal_Info.Cust_Code=dbo.SBP_Share_DW.Cust_Code) AS 'Client Name',Comp_Short_Code AS 'Company',ISNULL(Vouchar_No,'') AS 'Vouchar',Quantity AS 'Quantity', Deposit_Withdraw AS 'Deposit/Withdraw',Issue_Price AS 'Price'  FROM dbo.SBP_Share_DW WHERE Received_Date='" + date.ToString("yyyy-MM-dd") + "'";
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

        public DataTable GetShareDWInfoData(DateTime ReceivedDate)
        {
            string queryString ="SELECT Cust_Code AS 'Client Code',(SELECT Cust_Name FROM dbo.SBP_Cust_Personal_Info WHERE dbo.SBP_Cust_Personal_Info.Cust_Code=dbo.SBP_Share_DW.Cust_Code) AS 'Client Name',Comp_Short_Code AS 'Company Name',Quantity,Issue_Price AS 'Issue Price',Issue_Amount AS 'Issue Amount',Vouchar_No AS 'Voucher No',No_Script AS 'Script No',Deposit_Withdraw AS 'Withdraw/Deposit',Deposit_Type AS 'Deposit Type',Share_Type AS 'Share Type',Record_Date AS 'Record Date' FROM dbo.SBP_Share_DW WHERE Received_Date='"+ReceivedDate.ToShortDateString()+"'";
            DataTable data=new DataTable();

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
    }
}
