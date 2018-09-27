using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessAccessLayer.BO;
using DataAccessLayer;

namespace BusinessAccessLayer.BAL
{
    public class CashBackPlanBAL
    {
        private DbConnection _dbConnection;

        public CashBackPlanBAL()
        {
            _dbConnection = new DbConnection();
        }
        public void Insert(CashbackPlanBO cashBackPlanBo)
        {
            string queryString = "";
            queryString = @"SBPSaveCashBackPlans";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@planName", SqlDbType.VarChar, cashBackPlanBo.PlanName);
                _dbConnection.AddParameter("@description", SqlDbType.VarChar, cashBackPlanBo.Description);
                _dbConnection.AddParameter("@planDate", SqlDbType.DateTime, cashBackPlanBo.PlanDate.ToShortDateString());
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
        public void UpdateCashBackPlan(CashbackCriteriaBO objBO)
        {
            string query =
                @"UPDATE SBP_Cashback_Plan
                  SET "
                + "[Plan_Name] ='" + objBO.PlanName + "'"
                + ",[Description] = '" + objBO.PlanDescription + "'"
                + ",[Plan_Date] = '" + objBO.PlanDate + "'"
                + ",[Min_Trade_Amount] = " + objBO.MinTradeAmount
                + ",[Rate] = " + objBO.Rate
                + ",[Effective_Date] = '" + objBO.EffectiveDate + "'"
                +",[Entry_Date] = CONVERT(Datetime,CAST(FLOOR(CAST(GETDATE() AS FLOAT)) AS DATETIME))" 
                + ",[Entry_By] = '" + GlobalVariableBO._userName + "'"
                + " WHERE ID=" + objBO.ID;
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(query);
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
            queryString = "SELECT Plan_Name as 'Plan Name',Description,Plan_Date as 'Date' FROM SBP_Cashback_Plans ORDER BY Plan_Name";
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

        public DataTable GetCriteriaGridInfo()
        {

            DataTable dataTable;
            dataTable = null;
            string queryString = "";
            queryString = "SELECT ID,Plan_Name AS 'Plan',Description,Plan_Date AS 'Date',Min_Trade_Amount 'Trd Amount',Rate,Effective_Date AS 'Effe. Date' FROM SBP_Cashback_Plan ORDER BY ID,Plan_Name";
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

        public DataTable GetPlanInfoByPlanID(int _planId)
        {

            DataTable dataTable;
            dataTable = null;
            string queryString = "";
            queryString = "SELECT Plan_Name AS 'Plan Name',Description,Plan_Date,Min_Trade_Amount AS 'Min Trade Amount',Rate,Effective_Date AS 'Effective Date' FROM SBP_Cashback_Plan WHERE ID=" +_planId;
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
        public void InsertCriteria(CashbackCriteriaBO cashBackCriteriaBo)
        {
            string queryString = "";
          //  CommonBAL commonBAL = new CommonBAL();
          //  cashBackCriteriaBo.ID = commonBAL.GenerateID("SBP_Cashback_Plan", "ID");̢

            queryString = @"SBPSaveCashBackPlan";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@planName", SqlDbType.VarChar, cashBackCriteriaBo.PlanName);
                _dbConnection.AddParameter("@planDescription", SqlDbType.VarChar, cashBackCriteriaBo.PlanDescription);
                _dbConnection.AddParameter("@planDate", SqlDbType.DateTime, cashBackCriteriaBo.PlanDate.ToShortDateString());
                _dbConnection.AddParameter("@minTradeAmount", SqlDbType.Money, cashBackCriteriaBo.MinTradeAmount);
                _dbConnection.AddParameter("@Rate", SqlDbType.Float, cashBackCriteriaBo.Rate);
                _dbConnection.AddParameter("@effectiveDate", SqlDbType.DateTime,cashBackCriteriaBo.EffectiveDate.ToShortDateString());
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
