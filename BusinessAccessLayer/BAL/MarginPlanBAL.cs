using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessAccessLayer.BO;
using DataAccessLayer;

namespace BusinessAccessLayer.BAL
{
    public class MarginPlanBAL
    {
        private DbConnection _dbConnection;
        public MarginPlanBAL()
        {
            _dbConnection = new DbConnection();
        }
        public bool CheckCustomerCodeDuplicate(string custCode)
        {
            DataTable dataTable;
            string queryString = "";
            queryString = "SELECT Cust_Code FROM SBP_Margin_Charge_Plan WHERE Cust_Code='" + custCode + "'";
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
            if (dataTable.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Insert(MarginPlanBO marginPlanBo)
        {
            string queryString = "";
            queryString = @"SBPSaveMarginChargePlan";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@CustCode", SqlDbType.NVarChar, marginPlanBo.CustCode);
                _dbConnection.AddParameter("@PlanName", SqlDbType.VarChar, marginPlanBo.PlanName);
                _dbConnection.AddParameter("@EffectiveCount", SqlDbType.Int, marginPlanBo.EffectiveCount);
                _dbConnection.AddParameter("@ChargeRate", SqlDbType.Float,marginPlanBo.ChargeRate );
                if(marginPlanBo.CommissionRate > 0)
                     _dbConnection.AddParameter("@CommissionRate", SqlDbType.Float, marginPlanBo.CommissionRate);
                _dbConnection.AddParameter("@FreeAmount", SqlDbType.Money, marginPlanBo.FreeAmount);
                _dbConnection.AddParameter("@MarginRatio", SqlDbType.Float, marginPlanBo.MarginRatio);
                _dbConnection.AddParameter("@Remarks", SqlDbType.VarChar,marginPlanBo.Remarks);
                _dbConnection.AddParameter("@EDate", SqlDbType.DateTime,marginPlanBo.EDate.ToShortDateString() );
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

        public void Update(MarginPlanBO marginPlanBo)
        {
            string queryString = "";
            queryString = @"SBPUpdateMarginChargePlan";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@CustCode", SqlDbType.NVarChar, marginPlanBo.CustCode);
                _dbConnection.AddParameter("@PlanName", SqlDbType.VarChar, marginPlanBo.PlanName);
                _dbConnection.AddParameter("@EffectiveCount", SqlDbType.Int, marginPlanBo.EffectiveCount);
                _dbConnection.AddParameter("@ChargeRate", SqlDbType.Float, marginPlanBo.ChargeRate);
                if(marginPlanBo.CommissionRate > 0)
                      _dbConnection.AddParameter("@CommissionRate", SqlDbType.Float, marginPlanBo.CommissionRate);
                _dbConnection.AddParameter("@FreeAmount", SqlDbType.Money, marginPlanBo.FreeAmount);
                _dbConnection.AddParameter("@MarginRatio", SqlDbType.Float, marginPlanBo.MarginRatio);
                _dbConnection.AddParameter("@Remarks", SqlDbType.VarChar, marginPlanBo.Remarks);
                _dbConnection.AddParameter("@EDate", SqlDbType.DateTime, marginPlanBo.EDate.ToShortDateString());
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
      
        public void UpdateCommissionInfo(double cRate,string rmarks, string cCode)
        {
            string query = @"UPDATE [SBP_Database].[dbo].[SBP_Margin_Charge_Plan]
                            set Commission_Rate=" + cRate + @"
                               ,Remark='" + rmarks + @"'
                            where Cust_Code='" + cCode + @"'";
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

        public DataTable GetAllData(string custCode)
        {
            DataTable dataTable;
            string queryString = "";
            queryString = @"SELECT   Cust_Code 
		                            ,Plan_Name
		                            ,Effective_Count
		                            ,Charge_Rate
		                            ,Commission_Rate
		                            ,Free_Amount
		                            ,M_Ratio
		                            ,Remark
		                            ,E_Date 
                            FROM SBP_Margin_Charge_Plan 
                            WHERE Cust_Code='" + custCode + @"'";
            try
            {
                _dbConnection.ConnectDatabase();
                dataTable = _dbConnection.ExecuteQuery(queryString);
            }
            catch (Exception)
            {
                throw;
            }
            return dataTable;
        
        }

        public bool CheckCustomerCodeExist(string custCode)
        {
            DataTable dataTable;
            string queryString = "";
            queryString = "SELECT Cust_Code FROM SBP_Customers WHERE Cust_Code='" + custCode + "'";
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
            if (dataTable.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DataTable GetmarginPlanData()
        {
            string queryString = @"SELECT  Cust_Code AS 'Customer Code'
                                          ,(SELECT Cust_Name 
                                                   FROM dbo.SBP_Cust_Personal_Info 
                                                   WHERE dbo.SBP_Cust_Personal_Info.Cust_Code=dbo.SBP_Margin_Charge_Plan.Cust_Code) AS 'Customer Name'
                                           ,Plan_Name AS 'Plan Name'
                                           ,Effective_Count AS 'Effective Days'
                                           ,Charge_Rate AS 'Charge Rate'
                                           ,Commission_Rate as 'Commission Rate'
                                           ,Free_Amount AS 'Free Amount'
                                           ,M_Ratio AS 'Margin Ratio'
                                           ,Remark
                                           ,E_Date AS 'Effective Date' 
                                    FROM dbo.SBP_Margin_Charge_Plan
                                    order by Entry_Date desc";
            DataTable data=new DataTable();

            try
            {
                _dbConnection.ConnectDatabase();
                data = _dbConnection.ExecuteQuery(queryString);
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
