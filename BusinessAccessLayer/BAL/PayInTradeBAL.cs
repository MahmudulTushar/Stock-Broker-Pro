using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DataAccessLayer;
using BusinessAccessLayer.BO;

namespace BusinessAccessLayer.BAL
{
    public class PayInTradeBAL
    {
        private DbConnection _dbConnection;

        public PayInTradeBAL()
        {
            _dbConnection = new DbConnection();
        }

        public void SaveProcessedTradeInfo(DataTable dataTable, string tableName)
        {
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.BulkCopy(dataTable, tableName);
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

        public DataTable GetGridData()
        {
            DataTable dataTable;
            string queryString = "SELECT Customer as 'Customer Code',BOID,InstrumentCode as 'Company Short Name',ISIN,InstrumentCategory as 'Company Category',BuySellFlag as 'Buy/Sell',TradeQty as 'Trade Quantity',TradePrice as 'Trade Price',EventDate as 'Event Date' From SBP_Trade_Temp";
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

        public DataTable GetGridDataOld()
        {
            DataTable dataTable;
            string queryString = "SELECT * From SBP_Trade_Temp_Old";
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

        public DataTable GetTradedataByWorkstation()
        {

            DataTable dataTable;
            string queryString = "SELECT * FROM SBP_SmsConfTemp";
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

        public DataTable ValidateBOID()
        {
            DataTable dataTable;
            string queryString = "SELECT DISTINCT(BOID) From SBP_Trade_Temp WHERE BOID NOT IN (SELECT BO_ID From SBP_Customers)";
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

        public DataTable ValidateCustCode()
        {
            DataTable dataTable;
            string queryString = "SELECT DISTINCT(Customer) From SBP_Trade_Temp WHERE Customer NOT IN (SELECT Cust_Code From SBP_Customers)";
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

        public DataTable ValidateCompany()
        {
            DataTable dataTable;
            string queryString = "SELECT DISTINCT(InstrumentCode) From SBP_Trade_Temp WHERE InstrumentCode NOT IN (SELECT Comp_Short_Code From SBP_Company)";

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

        public DataTable ValidateCompanyCategory()
        {
            DataTable dataTable;
            string queryString = "SELECT DISTINCT(InstrumentCategory) From SBP_Trade_Temp WHERE InstrumentCategory NOT IN (SELECT Comp_Category From SBP_Company,SBP_Comp_Category WHERE SBP_Comp_Category.Comp_Cat_ID=SBP_Company.Comp_Cat_ID )";
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

        public DataTable ValidateISIN()
        {
            DataTable dataTable;
            string queryString = "SELECT DISTINCT(ISIN) From SBP_Trade_Temp WHERE ISIN NOT IN (SELECT ISIN_No From SBP_Company)";
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

        public DataTable ValidateGroupMisMatch()
        {
            DataTable dataTable;
            string queryString = "Select DISTINCT(InstrumentCode) as 'Company',Comp_Category as 'Old Category',InstrumentCategory as 'New Category' FROM SBP_Company,SBP_Comp_Category,SBP_Trade_Temp"
             + " WHERE SBP_Company.Comp_Cat_ID=SBP_Comp_Category.Comp_Cat_ID AND SBP_Company.Comp_Short_Code=InstrumentCode AND SBP_Comp_Category.Comp_Category !=InstrumentCategory";
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

        public void TruncateTradeInfo()
        {
            string queryString = "";
            queryString = "TRUNCATE TABLE SBP_Trade_Temp";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();
                _dbConnection.ExecuteNonQuery(queryString);
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


        public DataTable GetPayInData()
        {
            DataTable dataTable;
            string queryString = "SELECT  BOID,dbo.GetIssuerID(InstrumentCode) as 'IssuerID',TradeQty,Customer,TradeQty,InstrumentCode,EventDate,InstrumentCategory From SBP_Trade_Temp WHERE BuySellFlag='S'";
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
        public DataTable GetPayOutData()
        {
            DataTable dataTable;
            string queryString = "SELECT dbo.GetIssuerID(InstrumentCode) as 'IssuerID',TradeQty,Customer,BOID,TradeQty,ISIN,InstrumentCode,EventDate,InstrumentCategory From SBP_Trade_Temp WHERE BuySellFlag='B'";
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

        public DataTable GetPayInDataOld()
        {
            DataTable dataTable;
            string queryString ="SELECT  dbo.GetBOFromCustCode(customer) AS 'BOID',dbo.GetIssuerID(InstrumentCode) AS 'IssuerID',TradeQty,Customer,TradeQty,InstrumentCode,EventDate,(SELECT Comp_Category FROM SBP_Company,SBP_Comp_Category WHERE Comp_Short_Code=InstrumentCode AND SBP_Company.Comp_Cat_ID=SBP_Comp_Category.Comp_Cat_ID) AS InstrumentCategory From SBP_Trade_Temp_Old WHERE BuySellFlag='S'";
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

        public DataTable GetPayOutDataOld()
        {
            DataTable dataTable;
            string queryString ="SELECT dbo.GetIssuerID(InstrumentCode) as 'IssuerID',TradeQty,Customer,dbo.GetBOFromCustCode(customer) AS 'BOID',TradeQty,(SELECT ISIN_No FROM SBP_Company WHERE Comp_Short_Code=InstrumentCode) AS 'ISIN' ,InstrumentCode,EventDate,(SELECT Comp_Category FROM SBP_Company,SBP_Comp_Category WHERE Comp_Short_Code=InstrumentCode AND SBP_Company.Comp_Cat_ID=SBP_Comp_Category.Comp_Cat_ID) AS InstrumentCategory From SBP_Trade_Temp_Old WHERE BuySellFlag='B'";
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

        public void GeneratePayInDataByTradeFileTemp()
        {
            string queryString = @"GeneratePayinByTradeFile";
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
        public void GeneratePayInDataByOldTradeFileTemp()
        {
            string queryString = @"GeneratePayinByOldTradeFile";
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

        public DataTable GetSattlePayInData()
        {
            DataTable dataTable;
            string queryString = "SELECT REPLACE(STR(COUNT(ExecDate),7,0),' ','0')+REPLACE(STR(SUM(CONVERT(int,TradeQty)),13,0),' ','0')+' ADMIN'+'023500'+'10',0 AS SettlementID FROM SBP_Payin UNION SELECT ExecDate+BOID+CounterBOID+BrokerCode+ISIN+TradeQty+PayFlag+CustCode+CONVERT(char(12),SettlementID),SettlementID FROM SBP_Payin ORDER BY SettlementID ASC";
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

        public DataTable GetSattlePayOutData()
        {
            DataTable dataTable;
            string queryString = @"PayoutNewFile";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
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

        public void GeneratePayOutData(int minDays, string group)
        {
            string queryString = @"GeneratePayout";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@minDays", SqlDbType.Int, minDays);
                _dbConnection.AddParameter("@group", SqlDbType.VarChar, group);
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

        public DataTable MH_GetPayOutData()
        {
            DataTable dataTable;
            string queryString = @"SELECT REPLACE(STR(COUNT(ExecDate),7,0),' ','0')+REPLACE(STR(SUM(CONVERT(int,TradeQty)),13,0),' ','0')+' ADMIN'+'023500'+'10',0 AS SettlementID FROM SBP_Payin UNION SELECT ExecDate+BOID+CounterBOID+BrokerCode+ISIN+TradeQty+PayFlag+CustCode+CONVERT(char(12),SettlementID),SettlementID FROM SBP_Payin ORDER BY SettlementID ASC";
            try
            {
                _dbConnection.ConnectDatabase();;
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

        public void GenerateSpotPayOutData(int minDays)
        {
            string queryString = @"GenerateSpotPayout";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@minDays", SqlDbType.Int, minDays);
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

        public DataTable MH_GetSpotPayOutData()
        {
            DataTable dataTable;
            string queryString = @"SELECT REPLACE(STR(COUNT(ExecDate),7,0),' ','0')+REPLACE(STR(SUM(CONVERT(int,TradeQty)),13,0),' ','0')+' ADMIN'+'023500'+'10',0 AS SettlementID FROM SBP_Payin UNION SELECT ExecDate+BOID+CounterBOID+BrokerCode+ISIN+TradeQty+PayFlag+CustCode+CONVERT(char(12),SettlementID),SettlementID FROM SBP_Payin ORDER BY SettlementID ASC";
            try
            {
                _dbConnection.ConnectDatabase(); ;
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

        public DataTable GeneratePayInData()
        {
            DataTable dataTable;
            string queryString = @"PayinNewFile";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
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

        public DataTable ShowEditPayin()
        {
            DataTable dataTable;
            //string queryString = "SELECT SettlementID,CustCode AS 'Customer Code',BOID,(SELECT Comp_Short_Code FROM SBP_Company WHERE ISIN_No=ISIN) AS Instrument,CONVERT(INT,TradeQty) AS 'Quantity',ISIN,CounterBOID FROM SBP_Payin";
            string queryString = "SELECT SettlementID,CustCode AS [Customer Code],BOID,(SELECT Comp_Short_Code FROM SBP_Company WHERE ISIN_No=ISIN) AS Instrument,CONVERT(INT,TradeQty) AS Quantity,ISIN,CounterBOID FROM SBP_Payin";
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

        public void SaveProcessedTradeInfoOld(DataTable tradeDataTable, string tableName)
        {
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.BulkCopy(tradeDataTable, tableName);
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

        public void SaveProcessedTradeTemp(DataTable tradeDataTable, string tableName)
        {
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.BulkCopy(tradeDataTable, tableName);
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

        public void TruncateTradeInfoOld()
        {
            string queryString = "TRUNCATE TABLE SBP_Trade_Temp_Old";
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
        public void TruncateTradeTemp()
        {
            string queryString = "TRUNCATE TABLE SBP_Trade_Temp";
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


        public DataTable ValidateCustCodeOld()
        {
            DataTable dataTable;
            string queryString = "SELECT DISTINCT(Customer) From SBP_Trade_Temp_Old WHERE Customer NOT IN (SELECT Cust_Code From SBP_Customers)";
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

        public DataTable ValidateCompanyOld()
        {

            DataTable dataTable;
            string queryString = "SELECT DISTINCT(InstrumentCode) From SBP_Trade_Temp_Old WHERE InstrumentCode NOT IN (SELECT Comp_Short_Code From SBP_Company)";

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

        /******************************************************************************/
        public DataTable GetCustInfo(string custCode)
        {

            DataTable dataTable;
            string queryString = "SELECT SBP_Customers.Cust_Code,Cust_Name,(SELECT BO_ID FROM dbo.SBP_Broker_Info)+BO_ID AS BOID FROM SBP_Customers,dbo.SBP_Cust_Personal_Info WHERE dbo.SBP_Customers.Cust_Code=dbo.SBP_Cust_Personal_Info.Cust_Code AND dbo.SBP_Customers.Cust_Code='" + custCode + "'";

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

        public void SaveUpdatesToPayin(string custCode, string boId, int settleId,string quantity,PayinBO objPayinBO)
        {
            string queryString = "";
            if (objPayinBO.Paylog.Equals("I"))
            {
                queryString = "UPDATE SBP_Payin SET CustCode='" + custCode + "',BOID='" + boId +
                              "',TradeQty=REPLACE(STR(" + Convert.ToInt32(quantity) +
                              ",12,0),' ','0') WHERE SettlementID=" + settleId;
            }
            else
            {
                queryString = "UPDATE SBP_Payin SET CustCode='" + custCode + "',CounterBOID='" + boId + "',TradeQty=REPLACE(STR(" + Convert.ToInt32(quantity) + ",12,0),' ','0') WHERE SettlementID=" + settleId;
            }

            string UpdateLogQuery = "INSERT INTO SBP_Payinout_Log (CodeFrom,CodeTo,PreviosQuantity,Quantity,PayFlag,ISIN,Status,EventDate,EntryBy) VALUES ('" + objPayinBO.CustomerCodeFrom + "','" + custCode + "'," + objPayinBO.PreviousQuantity + "," + quantity + ",'" + objPayinBO.Paylog + "','" + objPayinBO.CompanyISIN + "','EDIT',GETDATE(),'" + GlobalVariableBO._userName + "')";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();
                _dbConnection.ExecuteNonQuery(queryString);
                _dbConnection.ExecuteNonQuery(UpdateLogQuery);
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

        public void ProcessSmsConf()
        {
            string queryString = @"ProcessSmsConf";
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

        public void ProcessShareBalance()
        {
            string queryString = @"GenerateShareBalanceTemp";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.TimeoutPeriod = 5000;
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
    }
}
