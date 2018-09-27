using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccessLayer;

namespace BusinessAccessLayer.BAL
{
    public class LoadCommonInfo
    {
        private DbConnection _dbConnection;

        public LoadCommonInfo()
        {
            _dbConnection = new DbConnection();
        }

        public string ShowCompanyName()
        {
            DataTable dataTable;
            dataTable = null;
            string queryString = "";
            string ComName;

            queryString = "SELECT Name FROM SBP_Broker_Info;";
            try
            {
                _dbConnection.ConnectDatabase();
                dataTable = _dbConnection.ExecuteQuery(queryString);
            }
            catch (Exception exc)
            {

                throw exc;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            ComName = dataTable.Rows[0]["Name"].ToString();
            return ComName;
        }
       
        public DataTable ShowBranchName(int branchId)
        {
            DataTable dtBranchInfo = null;
            string queryString = "";
            queryString = "Select Branch_Name,Address from SBP_Broker_Branch where Branch_ID=" + branchId + "";
            try
            {
                _dbConnection.ConnectDatabase();
                dtBranchInfo = _dbConnection.ExecuteQuery(queryString);

            }
            catch (Exception exc)
            {
                
                throw exc ;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dtBranchInfo;
        }
        public string BranchDetails(int branchId)
        {
            DataTable dtBranchDetail=ShowBranchName(branchId);
            string BranchDetails = "";
            BranchDetails = dtBranchDetail.Rows[0]["Branch_Name"].ToString();
            BranchDetails = BranchDetails+"\n"+ dtBranchDetail.Rows[0]["Address"].ToString();
            return BranchDetails;

        }
    }
}
