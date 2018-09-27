using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessAccessLayer.BO;
using DataAccessLayer;

namespace BusinessAccessLayer.BAL
{
    public class ClosingChargeDefBAL
    {
         private DbConnection _dbConnection;
         public ClosingChargeDefBAL()
        {
            _dbConnection = new DbConnection();
        }
        public DataTable GetGridInfo()
        {
            DataTable dataTable;
            dataTable = null;
            string queryString = "";
            queryString = "SELECT Ch_ID as 'ID',Closing_Charge as 'Closing Charge Rate',Effective_Date as 'Effective Date' FROM SBP_Account_Closing_Charge ORDER BY Ch_ID";
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

        public void Insert(ClosingChargeBO closingChargeBo)
        {
            string queryString = "";
            CommonBAL commonBAL = new CommonBAL();
            closingChargeBo.ChId = commonBAL.GenerateID("SBP_Account_Closing_Charge", "Ch_ID");

            queryString = @"SBPSaveClosingCharge";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@ChId", SqlDbType.Int, closingChargeBo.ChId);
                _dbConnection.AddParameter("@ClosingChargeRate", SqlDbType.Money, closingChargeBo.ClosingCharge);
                _dbConnection.AddParameter("@EffectiveDate", SqlDbType.DateTime, closingChargeBo.EffectiveDate.ToShortDateString());
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
    }
}
