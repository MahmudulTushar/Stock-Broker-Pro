using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessAccessLayer.BO;
using DataAccessLayer;

namespace BusinessAccessLayer.BAL
{
   public class CommonInfoBal
    {
        private DbConnection _dbConnection;

        public CommonInfoBal()
        {
            _dbConnection = new DbConnection();
        }

        public DataRow GetCommpanyInfo()
        {
            DataRow drCommpanyInfo = null;
            DataTable dtCommpanyInfo = new DataTable();

            string queryString = "SELECT SBP_Broker_Info.Name,SBP_Broker_Branch.Branch_Name,SBP_Broker_Branch.Address,SBP_Broker_Branch.Telephone FROM SBP_Broker_Branch,SBP_Broker_Info WHERE SBP_Broker_Branch.Branch_ID=" + GlobalVariableBO._branchId + ";";

            try
            {
                dtCommpanyInfo = ExecuteToquery(queryString);

                if (dtCommpanyInfo.Rows.Count > 0)
                {
                    drCommpanyInfo = dtCommpanyInfo.Rows[0];
                }

                else
                {
                    drCommpanyInfo = null;
                }
            }
            catch (Exception)
            {

                throw;
            }

            return drCommpanyInfo;

        }

        public DataRow GetCommpanyDefaultInfo()
        {
            DataRow drCommpanyInfo = null;
            DataTable dtCommpanyInfo = new DataTable();

            string queryString = "SELECT Name AS 'BrokerName',Branch_Name AS 'BranchName',Address,Telephone,Fax FROM dbo.SBP_Broker_Info,dbo.SBP_Broker_Branch WHERE Branch_ID=1";
     
            try
            {
                dtCommpanyInfo = ExecuteToquery(queryString);

                if (dtCommpanyInfo.Rows.Count > 0)
                {
                    drCommpanyInfo = dtCommpanyInfo.Rows[0];
                }

                else
                {
                    drCommpanyInfo = null;
                }
            }
            catch (Exception)
            {

                throw;
            }

            return drCommpanyInfo;

        }      

        public DataTable GetCompanyNameHeadOffice()
        {
            string queryString = "SELECT Name AS 'BrokerName',Branch_Name AS 'BranchName',Address,Telephone,Fax FROM dbo.SBP_Broker_Info,dbo.SBP_Broker_Branch WHERE Branch_ID=1";
            DataTable data = new DataTable();

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

        private DataTable ExecuteToquery(string query)
        {
            DataTable dataTable = new DataTable();

            try
            {
                _dbConnection.ConnectDatabase();
                dataTable = _dbConnection.ExecuteQuery(query);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dataTable;
        }

       public DataTable GetBranchList()
       {
           string queryString = "";
           queryString = "SELECT Branch_ID,Branch_Name FROM SBP_Broker_Branch;";

           DataTable dtList=new DataTable();

           try
           {
               _dbConnection.ConnectDatabase();
               dtList = _dbConnection.ExecuteQuery(queryString);
           }
           catch (Exception)
           {
               
               throw;
           }

           finally
           {
               _dbConnection.CloseDatabase();
           }

           return dtList;


       }

    }
}
