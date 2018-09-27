using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessAccessLayer.BO;
using DataAccessLayer;

namespace BusinessAccessLayer.BAL
{
    public class BankReconcileBAL
    {
         private DbConnection _dbConnection;
         public BankReconcileBAL()
         {
             _dbConnection = new DbConnection();
         }
       

        public void ProcessDatabase(CityBankBO citybankBo)
        {
           
            string QueryString = "";
            QueryString = "INSERT INTO SBP_City_Bank_Data(Cheque_Date,Description,Cheque_No,Debit,Credit,Balance)" +
                            " VALUES('" + citybankBo.ChequeDate + "','" + citybankBo.Description + "','" + citybankBo.ChequeNo + "','" + citybankBo.Debit + "', '" + citybankBo.Credit + "','" + citybankBo.Balance + "')";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();
                _dbConnection.ExecuteNonQuery(QueryString);
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

        public void TruncateCityBankTable()
        {
            string truQueryString = "TRUNCATE TABLE dbo.SBP_City_Bank_Data";

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(truQueryString);
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

        public bool IsInsert(CityBankBO cityBankBo)
        {
            DataTable dataTable;
            string queryString ="SELECT Cheque_Date,Description,Cheque_No,Debit,Credit,Balance FROM SBP_City_Bank_Data WHERE Cheque_Date='" +cityBankBo.ChequeDate + "' AND Description='" + cityBankBo.Description + "' AND Cheque_No='" +cityBankBo.ChequeNo + "' AND Debit='" + cityBankBo.Debit + "' AND Credit='" + cityBankBo.Credit + "'";  //AND Balance='" + cityBankBo.Balance + "'";
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
            {
                return false;
            }
        }

        public  DataTable BalanceMissmatchList()
        {
            
            string queryString = "SELECT dbo.SBP_City_Bank_Data.Cheque_Date AS Date," +
                                 "dbo.SBP_City_Bank_Data.Description AS Description,dbo.SBP_City_Bank_Data.Cheque_No AS 'Cheque No'," +
                                 "dbo.SBP_City_Bank_Data.Debit,'Balance Missmatch' AS Remarks " +
                                 "FROM dbo.SBP_City_Bank_Data,dbo.SBP_Payment WHERE dbo.SBP_Payment.Payment_Media_No=dbo.SBP_City_Bank_Data.Cheque_No AND " +
                                 " Cheque_Date BETWEEN (SELECT MIN(Cheque_Date) FROM dbo.SBP_City_Bank_Data) AND (SELECT MAX(Cheque_Date) FROM dbo.SBP_City_Bank_Data) AND " +
                                 "dbo.SBP_Payment.Amount<>CONVERT(MONEY,dbo.SBP_City_Bank_Data.Debit) AND dbo.SBP_Payment.Deposit_Withdraw='Withdraw' AND dbo.SBP_City_Bank_Data.Cheque_No!=''";
            DataTable data=new DataTable();

            try
            {
                _dbConnection.ConnectDatabase();
                data=_dbConnection.ExecuteQuery(queryString);
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

        public DataTable GetChequeMissmatch()
        {
            string queryString = "SBP_CityChequeMissmatch";
            DataTable data = new DataTable();

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                data = _dbConnection.ExecuteProQuery(queryString);
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
