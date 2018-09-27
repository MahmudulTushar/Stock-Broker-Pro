using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessAccessLayer.BO;
using DataAccessLayer;

namespace BusinessAccessLayer.BAL
{
    public class MarginChargeDefBAL
    {
        
        private DbConnection _dbConnection;
        public MarginChargeDefBAL()
        {
            _dbConnection = new DbConnection();
        }
        public DataTable GetGridInfo()
        {
            DataTable dataTable;
            dataTable = null;
            string queryString = "";
            queryString = "SELECT ID,Plan_Name as 'Plan Name',Charge_Rate as 'Charge Rate',Effective_Count as 'Effective Count',Effective_Date as 'Effective Date',Remarks FROM SBP_Margin_Charge_Def ORDER BY ID";
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

        public void Insert(MarginChargeDefBO marginChargeDefBo)
        {

            string queryString = "";
            CommonBAL commonBAL = new CommonBAL();
            marginChargeDefBo.Id = commonBAL.GenerateID("SBP_Margin_Charge_Def", "ID");

            queryString = @"SBPSaveMarginCharge";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@ChDefId", SqlDbType.Int, marginChargeDefBo.Id);
                _dbConnection.AddParameter("@PlanName", SqlDbType.NVarChar, marginChargeDefBo.PlanName);
                _dbConnection.AddParameter("@ChargeRate", SqlDbType.Float, marginChargeDefBo.ChargeRate);
                _dbConnection.AddParameter("@EffectiveCount", SqlDbType.Int, marginChargeDefBo.EffectiveCount);
                _dbConnection.AddParameter("@effectiveDate", SqlDbType.DateTime, marginChargeDefBo.EffectiveDate.ToShortDateString());
                _dbConnection.AddParameter("@remarks", SqlDbType.VarChar, marginChargeDefBo.Remarks);
                _dbConnection.AddParameter("@entryBy", SqlDbType.VarChar,GlobalVariableBO._userName);
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
