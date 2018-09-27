using System;
using System.Data;
using BusinessAccessLayer.BO;
using DataAccessLayer;

namespace BusinessAccessLayer.BAL
{
    public class BranchManagementBAL
    {
        private DbConnection _dbConnection;
        public BranchManagementBAL()
        {
            _dbConnection = new DbConnection();
        }


        public void Insert(BranchManagementBO branchMngmntBO)
        {
            string queryString = "";
            CommonBAL commonBAL = new CommonBAL();
            branchMngmntBO.BranchId = commonBAL.GenerateID("SBP_Broker_Branch", "Branch_ID");
            queryString = @"SBPSaveBranch";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@branchID", SqlDbType.Int,branchMngmntBO.BranchId);
                _dbConnection.AddParameter("@branchName", SqlDbType.VarChar,branchMngmntBO.BranchName);
                _dbConnection.AddParameter("@address", SqlDbType.VarChar, branchMngmntBO.BranchAddress);
                _dbConnection.AddParameter("@telePhone", SqlDbType.VarChar,branchMngmntBO.TelePhone);
                _dbConnection.AddParameter("@fax", SqlDbType.VarChar, branchMngmntBO.Fax);
                _dbConnection.AddParameter("@eMail", SqlDbType.VarChar, branchMngmntBO.Email);
                _dbConnection.AddParameter("@web", SqlDbType.VarChar, branchMngmntBO.Web);
                _dbConnection.AddParameter("@openDate", SqlDbType.DateTime,branchMngmntBO.BranchOpeningdate.ToShortDateString());
                _dbConnection.AddParameter("@isActive ", SqlDbType.Int,branchMngmntBO.BranchIsActive );
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

        public DataTable GetAllBranches()
        {
            DataTable dataTable;
            dataTable = null;
            string queryString = "";
            queryString = "SELECT Branch_ID as 'Branch ID',Branch_Name as 'Branch Name',Address,Telephone,Fax,Email,Web,Open_Date as 'Opening Date',Close_Date as 'Closing Date',IS_Active as 'Is Active',Entry_Date as 'Entry Date' FROM SBP_Broker_Branch ORDER BY Branch_ID";
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
        public void Update(BranchManagementBO branchMngmntBO, int branchIDforupdate)
        {
            string queryString = "";
            queryString = @"SBPUpdateBranch";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@branchID", SqlDbType.Int,branchIDforupdate);
                _dbConnection.AddParameter("@branchName", SqlDbType.VarChar,branchMngmntBO.BranchName);
                _dbConnection.AddParameter("@address", SqlDbType.VarChar, branchMngmntBO.BranchAddress);
                _dbConnection.AddParameter("@telePhone", SqlDbType.VarChar,branchMngmntBO.TelePhone);
                _dbConnection.AddParameter("@fax", SqlDbType.VarChar, branchMngmntBO.Fax);
                _dbConnection.AddParameter("@eMail", SqlDbType.VarChar, branchMngmntBO.Email);
                _dbConnection.AddParameter("@web", SqlDbType.VarChar, branchMngmntBO.Web);
                _dbConnection.AddParameter("@openDate", SqlDbType.DateTime,branchMngmntBO.BranchOpeningdate.ToShortDateString());
                _dbConnection.AddParameter("@isActive ", SqlDbType.Int,branchMngmntBO.BranchIsActive );
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

        public bool CheckBranchDuplicate(string branchName)
        {
            DataTable dataTable;
            string queryString = "";
            queryString = "SELECT Branch_Name FROM SBP_Broker_Branch WHERE Branch_Name='" + branchName + "'";
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
        public void CloseBranch(int branchId)
        {
            string queryString = "";
            queryString = @"SBPBranchClosing";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@branchID", SqlDbType.Int, branchId);
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

        public DataTable LoadDDLClosableBranch()
        {
            DataTable dataTable;
            dataTable = null;
            string queryString = "";
            queryString = "SELECT * FROM SBP_Broker_Branch Where Is_Active=1";
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


        public string GetBranchName()
        {
            string queryString = "SELECT Branch_Name FROM SBP_Broker_Branch WHERE Branch_ID=" + GlobalVariableBO._branchId + "";
            DataTable dtRecord = new DataTable();
            string BranchName = "";

            try
            {
                _dbConnection.ConnectDatabase();
                dtRecord = _dbConnection.ExecuteQuery(queryString);

                if(dtRecord.Rows.Count>0)
                BranchName = dtRecord.Rows[0][0].ToString();

                else
                BranchName = "";
            }

            catch (Exception)
            {
                throw;
            }

            finally
            {
                _dbConnection.CloseDatabase();
            }

            return BranchName;
        }
        
    }
}
