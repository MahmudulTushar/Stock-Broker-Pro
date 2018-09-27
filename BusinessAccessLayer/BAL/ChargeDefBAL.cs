using System;
using System.Data;
using BusinessAccessLayer.BO;
using DataAccessLayer;

namespace BusinessAccessLayer.BAL
{
    public class ChargeDefBAL
    {
        private DbConnection _dbConnection;
        public ChargeDefBAL()
        {
            _dbConnection = new DbConnection();
        }
        public void Insert(ChargeDefBO chargeDefBo)
        {
            string queryString = "";
            CommonBAL commonBAL = new CommonBAL();
            chargeDefBo.ChDefId = commonBAL.GenerateID("SBP_Ch_Def_All", "Ch_ID");

            queryString = @"SBPSaveChargeDef";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@ChDefId", SqlDbType.Int,chargeDefBo.ChDefId);
                _dbConnection.AddParameter("@ChItem", SqlDbType.VarChar, chargeDefBo.ChItem);
                _dbConnection.AddParameter("@ChItemDescription", SqlDbType.VarChar, chargeDefBo.ChItemDescription );
                _dbConnection.AddParameter("@Category", SqlDbType.VarChar,chargeDefBo.Category);
                _dbConnection.AddParameter("@MinCh", SqlDbType.Money, chargeDefBo.MinCh);
                _dbConnection.AddParameter("@ChRate", SqlDbType.Decimal, chargeDefBo.ChRate);
                _dbConnection.AddParameter("@EffectiveDate", SqlDbType.DateTime,chargeDefBo.EffectiveDate.ToShortDateString());
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
            queryString = "SELECT Ch_ID as 'ID',Ch_Item as 'Charge Item',Ch_Category AS 'Category',Ch_Description as 'Description',Ch_Min_Fee as 'Min. Charge',Ch_Rate as 'Rate',Ch_Effective_Date as 'Effective Date' FROM SBP_Ch_Def_All ORDER BY Ch_ID";
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
