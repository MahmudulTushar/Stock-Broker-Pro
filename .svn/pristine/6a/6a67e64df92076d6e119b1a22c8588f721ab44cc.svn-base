using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessAccessLayer.BO;
using DataAccessLayer;

namespace BusinessAccessLayer.BAL
{
    public class CustomerCommisionInfoBAL
    {
         private DbConnection _dbConnection;
         public CustomerCommisionInfoBAL()
        {
            _dbConnection = new DbConnection();
        }
        public DataTable GetGridInfo()
        {
            DataTable dataTable;
            dataTable = null;
            string queryString = "";
            queryString = "SELECT Commission_ID as 'ID',Cust_Group as 'Group',Min_Commission as 'Min. Commission',Commission as 'Rate',Share_Type as 'Category',Effective_Date as 'Effective Date' FROM SBP_Cust_Commissions,SBP_Cust_Group Where SBP_Cust_Commissions.Cust_Group_ID=SBP_Cust_Group.Cust_Group_ID ORDER BY Commission_ID";
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

        public void Insert(CustomerCommisionBO commisionBo)
        {
            CommonBAL commonBAL = new CommonBAL();
            commisionBo.CommID = commonBAL.GenerateID("SBP_Cust_Commissions", "Commission_ID");
            string queryString = "";
            queryString = @"SBPSaveCustCommissionDef";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@CommID", SqlDbType.Int, commisionBo.CommID);
                _dbConnection.AddParameter("@GroupId", SqlDbType.Int, commisionBo.GroupId);
                _dbConnection.AddParameter("@MinComm", SqlDbType.Money, commisionBo.MinComm);
                _dbConnection.AddParameter("@GroupCommRate", SqlDbType.Money, commisionBo.GroupCommRate);
                _dbConnection.AddParameter("@Category", SqlDbType.VarChar, commisionBo.Category);
                _dbConnection.AddParameter("@EffectiveFrom", SqlDbType.DateTime, commisionBo.EffectiveFrom);
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
