using System;
using System.Data;
using DataAccessLayer;
using BusinessAccessLayer.BO;

namespace BusinessAccessLayer.BAL
{
    public class LoginManagementBAL
    {
        private DbConnection _dbConnection;
        public LoginManagementBAL()
        {
            _dbConnection = new DbConnection();
        }


        public void InsertLogRecord()
        {
            string Dt = DateTime.Now.ToString("dd-MMM-yyyy");
            string queryString = "";
            queryString = "INSERT INTO SBP_User_Log (User_Name,Login_Time,Entry_Date)" +
            " Values('" + GlobalVariableBO._userName + "','" + Dt + "',GETDATE())";

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();
                _dbConnection.ExecuteNonQuery(queryString);
                _dbConnection.Commit();
            }
            catch (Exception)
            {
                _dbConnection.Rollback();
                throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
        }

        private string _employeeCode;
        public string EmployeeCode
        {
            get { return _employeeCode; }
            set { _employeeCode = value; }
        }

        private bool _isActive=false;
        public bool IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }

      


        public int UserPassCheck(string userName, string passWord)
        {
            int _nbranchId = 0;
            DataTable dataTable = new DataTable();
            string queryString = "";
            queryString = "SELECT SBP_Users.Branch_ID,SBP_Users.EmployeeCode,SBP_Users.IS_Active FROM SBP_Users,SBP_Broker_Branch WHERE User_Name='" + userName + "' and Password='" + passWord + "' and SBP_Users.Branch_ID=SBP_Broker_Branch.Branch_ID and SBP_Broker_Branch.IS_Active=1";
            try
            {
                _dbConnection.ConnectDatabase();
                dataTable = _dbConnection.ExecuteQuery(queryString);
                if (dataTable.Rows.Count > 0)
                {
                    _nbranchId = Convert.ToInt16(dataTable.Rows[0][0].ToString());
                    _employeeCode = dataTable.Rows[0][1].ToString();
                    _isActive = (bool) dataTable.Rows[0]["IS_Active"];
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }

            return _nbranchId;
        }
        public int CheckLoggedinStatus(string userName)
        {
            int loggedin = 0;
            DataTable dataTable = new DataTable();
            string queryString = "";
            queryString = "SELECT IsLoggedin FROM SBP_Users WHERE User_Name='" + userName + "'";
            try
            {
                _dbConnection.ConnectDatabase();
                dataTable = _dbConnection.ExecuteQuery(queryString);
                if (dataTable.Rows.Count > 0)
                {
                    loggedin = Convert.ToInt16(dataTable.Rows[0][0]);
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }

            return loggedin;
        }

        public void UpdateLoggedinStatus(string userName,int status)
        {
            string queryString = "UPDATE SBP_Users SET IsLoggedin=" + status + ",LoggedinTime=GETDATE() WHERE User_Name='" + userName +"';";

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(queryString);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
        }
        public string GetBranchName(int branchId)
        {
            DataTable dataTable = new DataTable();
            string branchName = "";
            string queryString = "SELECT Branch_Name FROM SBP_Broker_Branch WHERE Branch_ID=" + branchId;
            try
            {
                _dbConnection.ConnectDatabase();
                dataTable = _dbConnection.ExecuteQuery(queryString);
                if (dataTable.Rows.Count > 0)
                {
                    branchName = dataTable.Rows[0][0].ToString();
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }

            return branchName;
        }
        public DataTable LoadLoggedinUsers()
        {
            DataTable dataTable = new DataTable();
            string queryString = "SELECT User_Name AS 'User Name',Name AS 'Full Name',Role_Name AS 'Role',(SELECT Branch_Name FROM SBP_Broker_Branch WHERE SBP_Broker_Branch.Branch_ID=SBP_Users.Branch_ID) AS 'Branch',CONVERT(VARCHAR,LoggedinTime,100) AS 'Loggedin Time',DATEDIFF(mi,LoggedinTime,GETDATE()) AS 'Duration(minutes)'FROM SBP_Users WHERE IsLoggedin=1";
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
    }
}
