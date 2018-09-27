using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessAccessLayer.BO;
using DataAccessLayer;

namespace BusinessAccessLayer.BAL
{
    public class IPOChargeBAL
    {
        private DbConnection _dbConnection;
        public IPOChargeBAL()
        {
            _dbConnection = new DbConnection();
        }
        public DataTable GetGridInfo()
        {
            DataTable dataTable;
            dataTable = null;
            string queryString = "";
            queryString = "SELECT Sl_No as 'Serial No',Comp_Short_Code as 'Company Short Code',Comp_Name as 'Company Name',Share_Type as 'Company Type',Commission,Effective_Date as 'Effective From' FROM SBP_Ch_Def_IPO ORDER BY Sl_No";
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

        public DataTable GetAllData(string companyShortCode)
        {
            DataTable dataTable;
            string queryString = "";
            queryString ="SELECT Comp_Name,Share_Type FROM SBP_Company WHERE Comp_Short_Code='" +companyShortCode + "'"; 
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

        public void Insert(IPOChargeDefBO ipoChargeDefBo)
        {
            string queryString = "";
            CommonBAL commonBAL = new CommonBAL();
            ipoChargeDefBo.SlNo = commonBAL.GenerateID("SBP_Ch_Def_IPO", "Sl_No");
            queryString = @"SBPSaveIPOChargeDef";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@SlNo", SqlDbType.Int, ipoChargeDefBo.SlNo);
                _dbConnection.AddParameter("@CompShortCode", SqlDbType.NVarChar, ipoChargeDefBo.CompShortCode);
                _dbConnection.AddParameter("@CompName", SqlDbType.NVarChar, ipoChargeDefBo.CompName);
                _dbConnection.AddParameter("@ShareType", SqlDbType.VarChar, ipoChargeDefBo.ShareType);
                _dbConnection.AddParameter("@Commision", SqlDbType.Money, ipoChargeDefBo.Commision);
                _dbConnection.AddParameter("@EffectiveDate", SqlDbType.DateTime, ipoChargeDefBo.EffectiveDate.ToShortDateString());
                _dbConnection.AddParameter("@remark1", SqlDbType.VarChar, ipoChargeDefBo.Remarks1);
                _dbConnection.AddParameter("@remark2", SqlDbType.VarChar, ipoChargeDefBo.Remarks2);
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
