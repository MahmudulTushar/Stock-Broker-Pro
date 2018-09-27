using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccessLayer;
namespace BusinessAccessLayer.BAL
{
    public class TaxStatementBAL
    {
        DbConnection _dbConnection;
        public TaxStatementBAL()
        {
            _dbConnection = new DbConnection();
        }

        public DataSet GetData(string custCode, DateTime StartDate, DateTime EndDate)
        {
            DataSet PaymentReceiptSummary = null;
            string queryString = "";
            queryString = @"RptTaxStatement";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@FromDate", SqlDbType.DateTime, StartDate);
                _dbConnection.AddParameter("@ToDate", SqlDbType.DateTime, EndDate);
                _dbConnection.AddParameter("@Cust_Code", SqlDbType.NVarChar, custCode);
                PaymentReceiptSummary = _dbConnection.ExecuteProQueryDataset(queryString);

            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return PaymentReceiptSummary;
        }

    }
}
