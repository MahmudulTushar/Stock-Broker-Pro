using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using BusinessAccessLayer.BO;
using System.Data;

namespace BusinessAccessLayer.BAL
{
   public class ChargeInfoBAL
    {
        private DbConnection _dbConnection;
        public ChargeInfoBAL()
        {
            _dbConnection = new DbConnection();
        }
        #region charge Master
        public DataTable GetChargeInfoGridData()
        {
            DataTable data = new DataTable();
            string query = @" SELECT [ID]
                              ,[ChargeName]
                              ,[ChargeDesc]
                          FROM SBP_Transaction_ChargeInfo";
            try
            {
                _dbConnection.ConnectDatabase();
                data = _dbConnection.ExecuteQuery(query);
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

        public void SaveChargeInfo(ChargeInfoBO objBO)
        {

            string QueryString = "";
            QueryString = @"INSERT INTO dbo.SBP_Transaction_ChargeInfo
                            (
                              [ChargeName]
                            , [ChargeDesc]
                            )
                            VALUES
                            ("
                          + "'" + objBO.Charge_Name + "'"
                          + ",'" + objBO.Charge_Desc + "'"
                          + ")";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(QueryString);
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

        public void UpdateChargeInfo(ChargeInfoBO objBO, int chargeId)
        {
            string query = @"UPDATE SBP_Transaction_ChargeInfo 
                             SET ChargeName='"+objBO.Charge_Name +"'"
                            + ", ChargeDesc='" + objBO.Charge_Desc + "'"
                            +" WHERE ID=" + chargeId;
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

        public void DeleteChargeInfo(int chargeId)
        {
            string query = "DELETE FROM SBP_Transaction_ChargeInfo WHERE ID=" + chargeId;
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
        #endregion charge Master

        #region Charge Details

        public DataTable GetChargeName()
        {
            DataTable data = new DataTable();
            string query = @" SELECT [ID]
                              ,[ChargeName]                              
                          FROM SBP_Transaction_ChargeInfo";
            try
            {
                _dbConnection.ConnectDatabase();
                data = _dbConnection.ExecuteQuery(query);
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
        public DataTable GetChargeDetailsInfoGridData()
        {
            DataTable data = new DataTable();
            string query = @" SELECT *
                              
                          FROM SBP_Transaction_ChargeDetails";
            try
            {
                _dbConnection.ConnectDatabase();
                data = _dbConnection.ExecuteQuery(query);
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
        public void SaveChargeDetailsInfo(ChargeInfoBO objBO)
        {

            string QueryString = "";
            QueryString = @"INSERT INTO SBP_Transaction_ChargeDetails
                                (
                                  [Charge_ID]
                                , [Charge_Name]
                                , [Minimum_Effective_Amount]
                                , [Charge_Rate]
                                , [Charge_Amount]
                                )
                                VALUES
                                ("
                                    + objBO.ChargeId
                                    + ",'" + objBO.Charge_Name + "'"
                                    + "," + objBO.Min_Effective_Amount
                                    + "," + objBO.Charge_Rate
                                    + "," + objBO.Charge_Amount
                             + ")";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(QueryString);
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

        public void UpdateChargeDetailsInfo(ChargeInfoBO objBO, int chargeDetaisId)
        {
            string query = @"UPDATE SBP_Transaction_ChargeDetails 
                             SET Charge_Name='" + objBO.Charge_Name + "'"
                            + ", Charge_ID=" + objBO.ChargeId
                            + ", Minimum_Effective_Amount=" + objBO.Min_Effective_Amount
                            + ", Charge_Rate=" + objBO.Charge_Rate
                            + ", Charge_Amount=" + objBO.Charge_Amount
                            + " WHERE ID=" + chargeDetaisId;
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

        public void DeleteChargeDetailsInfo(int chargeDetailsId)
        {
            string query = "DELETE FROM SBP_Transaction_ChargeDetails WHERE ID=" + chargeDetailsId;
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

        public int GetChargeDetailsIdByChargeId(int chargeId)
        {
            DataTable data = new DataTable();
            int chargeDetailsId = 0;
            string query = @" SELECT [ID]
                          FROM SBP_Transaction_ChargeDetails WHERE Charge_ID=" + chargeId;
            try
            {
                _dbConnection.ConnectDatabase();
                data = _dbConnection.ExecuteQuery(query);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            if (data.Rows.Count > 0)
            {
                chargeDetailsId = Convert.ToInt32(data.Rows[0][0].ToString());
            }
            return chargeDetailsId;
        }
        #endregion
    }
}
