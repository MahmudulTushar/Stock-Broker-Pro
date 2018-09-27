using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DataAccessLayer;

namespace BusinessAccessLayer.BAL
{
    public class VoucherPrintingBAL
    {
         DbConnection _dbConnection;
          public VoucherPrintingBAL()
          {
            _dbConnection = new DbConnection();
          }
      
        public DataTable GetClientVoucher(DateTime paymentDate)
        {
            DataTable dtClientVoucher = null;
            string quryString = "";
            quryString = @"RptGetClientVoucher";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@paymentDate", SqlDbType.DateTime, paymentDate.ToShortDateString());
                dtClientVoucher = _dbConnection.ExecuteProQuery(quryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dtClientVoucher;
        }
    }
}

