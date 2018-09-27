using System;
using System.Data;
using BusinessAccessLayer.BO;
using DataAccessLayer;

namespace BusinessAccessLayer.BAL
{
    public class HoliDayBAL
    {
        private DbConnection _dbConnection;
        public HoliDayBAL()
        {
            _dbConnection = new DbConnection();
        }
        public void SaveOthersHoliday(HolidayBO holydayBo)
        {
            string queryString = "";
            CommonBAL comBAL = new CommonBAL();
           // holydayBo.SlNo = comBAL.GenerateID("SBP_Holiday", "Sl_No");
            queryString = @"SBPSaveHoliday"; 
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
               //_dbConnection.AddParameter("@SlNo", SqlDbType.Int, holydayBo.SlNo);
                _dbConnection.AddParameter("@HolydayDate", SqlDbType.DateTime, holydayBo.HolydayDate.ToShortDateString());
                _dbConnection.AddParameter("@Purpose", SqlDbType.VarChar, holydayBo.Purpose);
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

        public DataTable GetAllHoliday()
        {
            DataTable dataTable;
            string queryString = "SELECT Sl_No AS 'Serial No',Holiday_Date AS 'Holiday Date',Purpose,Entry_By From SBP_Holiday";
            try
            {
                _dbConnection.ConnectDatabase();
                dataTable = _dbConnection.ExecuteQuery(queryString);
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

        public void Update(HolidayBO holydayBo, int holidayIdForUpdate)
        {
            string queryStringIns = "";
            queryStringIns = @"SBPUpdateHoliday";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@SlNo", SqlDbType.Int, holidayIdForUpdate);
                _dbConnection.AddParameter("@HolydayDate", SqlDbType.DateTime, holydayBo.HolydayDate.ToShortDateString());
                _dbConnection.AddParameter("@Purpose", SqlDbType.VarChar, holydayBo.Purpose);
                _dbConnection.AddParameter("@entryBy", SqlDbType.VarChar, GlobalVariableBO._userName);
                _dbConnection.ExecuteNonQuery(queryStringIns);
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

        public bool CheckHolidayDuplicate(DateTime holidayDate)
        {
            DataTable dataTable;
            string queryString = "";
            queryString = "SELECT Holiday_Date FROM SBP_Holiday WHERE Holiday_Date='" + holidayDate + "'";
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
        public void DeleteHoliday(int holidayIdForDelete)
        {
            string queryString = "";
            queryString = "DELETE FROM SBP_Holiday WHERE Sl_No=" + holidayIdForDelete;
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
    }
}
