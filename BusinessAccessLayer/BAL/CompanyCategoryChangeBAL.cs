using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessAccessLayer.BO;
using DataAccessLayer;

namespace BusinessAccessLayer.BAL
{
    public class CompanyCategoryChangeBAL
    {
        private DbConnection _dbConnection;
        public CompanyCategoryChangeBAL()
        {
            _dbConnection = new DbConnection();
        }
        public DataTable GetGridInfo()
        {
            DataTable dataTable;
            dataTable = null;
            string queryString = "";
            queryString = "SELECT Sl_No as 'Serial No',Comp_Short_Code as 'Company Short Name',(SELECT Comp_Category FROM SBP_Comp_Category WHERE Comp_Cat_ID=Old_Category_ID) as 'Old Category',(SELECT Comp_Category FROM SBP_Comp_Category WHERE Comp_Cat_ID=New_Category_ID) as 'New Category',Effective_Date as 'Effective Date' FROM SBP_Comp_Cat_Log";
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

        public void Insert(CompanyCategoryChangeBO changeBo)
        {
            string compCatChangeQryString = "";
            CommonBAL commonBAL = new CommonBAL();
            changeBo.SlNo = commonBAL.GenerateID("SBP_Comp_Cat_Log", "Sl_No");
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();
                compCatChangeQryString = @"SBPSaveCompCatChange";
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@SlNo", SqlDbType.Int, changeBo.SlNo);
                _dbConnection.AddParameter("@CompShortCode", SqlDbType.NVarChar, changeBo.CompShortCode);
                _dbConnection.AddParameter("@OldCategoryId", SqlDbType.Int, changeBo.OldCategoryId);
                _dbConnection.AddParameter("@NewCategoryId", SqlDbType.Int, changeBo.NewCategoryId);
                _dbConnection.AddParameter("@EffectiveDate", SqlDbType.DateTime, changeBo.EffectiveDate);
                _dbConnection.AddParameter("@entryBy", SqlDbType.VarChar, GlobalVariableBO._userName);
                _dbConnection.ExecuteNonQuery(compCatChangeQryString);
                _dbConnection.Commit();
                
            }
            catch (Exception exception)
            {
                _dbConnection.Rollback();
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
        }
    }
}
