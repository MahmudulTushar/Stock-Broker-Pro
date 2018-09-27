using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DataAccessLayer;

namespace BusinessAccessLayer.BAL
{
    public class LoadRPTCustomerInfo
    {
        private DbConnection _dbConnection;
        private int _CustGropId;

        public LoadRPTCustomerInfo()
        {
            _dbConnection = new DbConnection();
        }

        public DataTable LoadCustomerInfo(string ReportPatten, DateTime startDate, DateTime endDate)
        {
            DataTable dataTable;
            dataTable = null;
            string queryString = "";

            if (ReportPatten == "All")
            {
                queryString = @"RptLoadCustomerInfoAll";
                try
                {
                    _dbConnection.ConnectDatabase();
                    _dbConnection.ActiveStoredProcedure();
                    _dbConnection.AddParameter("@startDate", SqlDbType.DateTime, startDate);
                    _dbConnection.AddParameter("@endDate", SqlDbType.DateTime, endDate);
                    dataTable = _dbConnection.ExecuteProQuery(queryString);
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

            else if (ReportPatten == "Active")
            {
                queryString = @"RptLoadCustomerInfoActive";
                try
                {
                    _dbConnection.ConnectDatabase();
                    _dbConnection.ActiveStoredProcedure();
                    _dbConnection.AddParameter("@startDate", SqlDbType.DateTime, startDate);
                    _dbConnection.AddParameter("@endDate", SqlDbType.DateTime, endDate);
                    dataTable = _dbConnection.ExecuteProQuery(queryString);
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

            else if (ReportPatten == "Inactive")
            {
                queryString = @"RptLoadCustomerInfoInActive";
                try
                {
                    _dbConnection.ConnectDatabase();
                    _dbConnection.ActiveStoredProcedure();
                    _dbConnection.AddParameter("@startDate", SqlDbType.DateTime, startDate);
                    _dbConnection.AddParameter("@endDate", SqlDbType.DateTime, endDate);
                    dataTable = _dbConnection.ExecuteProQuery(queryString);
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

            else
            {
                if (_CustGropId != -1)
                {
                    int groupId=FindoutGroudId(ReportPatten);
                    
                    queryString = @"RptLoadCustomerInfoGroupID";
                    try
                    {
                        _dbConnection.ConnectDatabase();
                        _dbConnection.ActiveStoredProcedure();
                        _dbConnection.AddParameter("@groupID", SqlDbType.Int, groupId);
                        _dbConnection.AddParameter("@startDate", SqlDbType.DateTime, startDate);
                        _dbConnection.AddParameter("@endDate", SqlDbType.DateTime, endDate);
                        dataTable = _dbConnection.ExecuteProQuery(queryString);
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
            return dataTable;
        }

        public int FindoutGroudId(string CustGroupName)
        {
            DataTable dtCustGroup;
            dtCustGroup = null;

            string queryStringCustGroup = "";
            queryStringCustGroup = "Select Cust_Group_ID from SBP_Cust_Group where Cust_Group='" + CustGroupName + "'";

            try
            {
                _dbConnection.ConnectDatabase();
                dtCustGroup = _dbConnection.ExecuteQuery(queryStringCustGroup);
                _CustGropId = Int32.Parse(dtCustGroup.Rows[0][0].ToString());
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }

            return _CustGropId;
        }

    }
}
