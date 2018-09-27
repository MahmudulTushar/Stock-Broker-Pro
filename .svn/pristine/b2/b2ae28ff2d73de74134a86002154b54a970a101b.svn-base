using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using System.Data;
using BusinessAccessLayer.BO;

namespace BusinessAccessLayer.BAL
{
    public class CriteriaListBAL
    {
        private DbConnection _dbConnection;
        public CriteriaListBAL()
        {
            _dbConnection = new DbConnection();
        }
        public DataTable GetBranchList()
        {
            string queryString = "SELECT Branch_ID,Branch_Name FROM SBP_Broker_Branch";
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

        public DataTable GetWorkStationList()
        {
            string queryString = "SELECT WorkStation_Name FROM SBP_Workstation";
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

        public int GetCriteriaID(int resourceID)
        {
            string queryString = "SELECT Criteria_ID FROM SBP_Criteria_Resource WHERE Resource_ID=" + resourceID;
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
            if (data.Rows.Count > 0)
                return Convert.ToInt32(data.Rows[0][0]);
            else
                return 0;
        }
        public int CriteriaIDForCustCodeHide(int resourceID)
        {
            string queryString = "SELECT Criteria_ID FROM SBP_Hide_Customer WHERE Resource_ID=" + resourceID;
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
            if (data.Rows.Count > 0)
                return Convert.ToInt32(data.Rows[0][0]);
            else
                return 0;
        }
        public int CriteriaIDForCustCodeLimit(int resourceID)
        {
            string queryString = "SELECT Criteria_ID FROM SBP_Limited_Dashbord WHERE Resource_ID=" + resourceID;
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
            if (data.Rows.Count > 0)
                return Convert.ToInt32(data.Rows[0][0]);
            else
                return 0;
        }

    }
}
