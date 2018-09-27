using System;
using DataAccessLayer;
using System.Data;

namespace BusinessAccessLayer.BAL
{
    public class Bonus_Instrument_Confirmation_Reports_DSE_21_2BAL
    {
        #region Private Field
        private DbConnection _dbConnection;
        #endregion

        #region Constructor
        public Bonus_Instrument_Confirmation_Reports_DSE_21_2BAL()
        {
            _dbConnection = new DbConnection();
        }
        #endregion

        #region Execute Procedure
        public DataTable GetBonusInstrumentConfirmationData(string instrumentID, DateTime fromDate, DateTime toDate, string Investor_ID,string BOID)
        {
            DataTable data = new DataTable();
            try
            {
                string Query = @"rptBonus_Instrument_Confirmation_Report_DSE_21_2";
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@Start_Date", SqlDbType.DateTime, fromDate);
                _dbConnection.AddParameter("@End_Date", SqlDbType.DateTime, toDate);
                _dbConnection.AddParameter("@Instrument_ID", SqlDbType.VarChar, instrumentID);
                _dbConnection.AddParameter("@Investor_ID", SqlDbType.VarChar, Investor_ID);
                _dbConnection.AddParameter("@BO_ID", SqlDbType.VarChar, BOID);
                data = _dbConnection.ExecuteProQuery(Query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this._dbConnection.CloseDatabase();
            }
            return data;
        }
        #endregion

        #region Get Instrument
        public DataTable GetInstrument()
        {
            DataTable data = new DataTable();
            try
            {
                string Query =@"SELECT 'All' as [Comp_Short_Code]
                    UNION ALL
                    SELECT
                    [Comp_Short_Code]
                    FROM [SBP_Company]";
                _dbConnection.ConnectDatabase();
                data = _dbConnection.ExecuteQuery(Query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this._dbConnection.CloseDatabase();
            }
            return data;
        }
        #endregion

        public DataTable GetCustomerInfo(string _custCode, string _boid, string _custName)
        {
            DataTable data = new DataTable();
            try
            {
                string Query = @"rptGetCustCode_BOID_CustName";
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@Investor_ID", SqlDbType.VarChar, _custCode);
                _dbConnection.AddParameter("@BO_ID", SqlDbType.VarChar, _boid);
                _dbConnection.AddParameter("@Investor_Name", SqlDbType.VarChar, _custName);
                data = _dbConnection.ExecuteProQuery(Query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return data;
        }

    }
}
