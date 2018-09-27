using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessAccessLayer.BO;
using DataAccessLayer;

namespace BusinessAccessLayer.BAL
{
    public class PaymentMaturityBAL
    {
        private DbConnection _dbConnection;
        public PaymentMaturityBAL()
        {
            _dbConnection = new DbConnection();
        }
        public void Insert(PaymentMaturityBO paymentMaturityBo)
        {
            string queryString = "";
            CommonBAL commonBAL = new CommonBAL();
            paymentMaturityBo.Id = commonBAL.GenerateID("SBP_Payment_Media_Maturity", "ID");

            queryString = @"SBPSavePaymentMediaMaturity";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@Id", SqlDbType.Int, paymentMaturityBo.Id);
                _dbConnection.AddParameter("@PaymentMedia", SqlDbType.VarChar, paymentMaturityBo.PaymentMedia);
                _dbConnection.AddParameter("@MaturityDays", SqlDbType.Int, paymentMaturityBo.MaturityDays);
                _dbConnection.AddParameter("@effectiveDate", SqlDbType.DateTime, paymentMaturityBo.EffectiveDate);
                _dbConnection.AddParameter("@entryBy", SqlDbType.VarChar, GlobalVariableBO._userName);
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

        public DataTable GetGridInfo()
        {
            DataTable dataTable;
            dataTable = null;
            string queryString = "";
            queryString = "SELECT ID,Payment_Media as 'Payment Media',Maturity_Days AS 'Matured Period',Effective_Date as 'Effective Date' FROM SBP_Payment_Media_Maturity";
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
    }
}
