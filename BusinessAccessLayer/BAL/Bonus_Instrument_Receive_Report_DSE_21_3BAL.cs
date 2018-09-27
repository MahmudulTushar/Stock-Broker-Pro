using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using System.Data;
using System.Data.SqlClient;


namespace BusinessAccessLayer.BAL
{
   public class Bonus_Instrument_Receive_Report_DSE_21_3BAL
    {
        private DbConnection _dbConnection;
        public Bonus_Instrument_Receive_Report_DSE_21_3BAL()
        {
            _dbConnection = new DbConnection();
        }

        public DataTable BonusInstrumentReceiveReportData( DateTime fromDate, DateTime toDate, string instrumentID,string instrumentName)
        {
            DataTable data = new DataTable();
            try
            {
                string Query = @"exec rptBonus_Instrument_Receive_Report_DSE_21_3 '"+fromDate.ToShortDateString()+"','"+toDate.ToShortDateString()+"','"+instrumentID+"','"+instrumentName+"'";
                //string Query = @"rptBonus_Instrument_Receive_Report_DSE_21_3";
                _dbConnection.ConnectDatabase();
                //_dbConnection.ActiveStoredProcedure();
                //_dbConnection.AddParameter("@Start_Date", SqlDbType.DateTime, fromDate.ToShortDateString());
                //_dbConnection.AddParameter("@End_Date", SqlDbType.DateTime, toDate);
                //_dbConnection.AddParameter("@Instrument_ID", SqlDbType.VarChar, instrumentID);
                //_dbConnection.AddParameter("@Instrument_Name", SqlDbType.VarChar, instrumentName);
                data = _dbConnection.ExecuteProByText(Query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return data;
        }

        public DataTable GetInstrumentID()
        {
            DataTable data = new DataTable();
            try
            {
                string Query = @"SELECT 
                                [Comp_Short_Code]
                                FROM [SBP_Company]
                                ORDER BY Comp_Short_Code ASC";
                _dbConnection.ConnectDatabase();
                data = _dbConnection.ExecuteQuery(Query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return data;
        }

        public DataTable GetInstrumentName()
        {
            DataTable data = new DataTable();
            try
            {
                string Query = @"SELECT 
                                [Comp_Name]
                                FROM [SBP_Company]
                                ORDER BY Comp_Short_Code ASC";
                _dbConnection.ConnectDatabase();
                data = _dbConnection.ExecuteQuery(Query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return data;
        }

        public string  GetInstrumentNameByID(string id)
        {
            string tempname = "";
            DataTable data = new DataTable();
            try
            {
                string Query = @"SELECT 
                                [Comp_Name]
                                FROM [SBP_Company]
                                WHERE Comp_Short_Code='"+id +"'";
                _dbConnection.ConnectDatabase();
                data = _dbConnection.ExecuteQuery(Query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            if(data.Rows.Count>0)
            {
                tempname = data.Rows[0][0].ToString();
            }
            return tempname;
        }

        public string GetInstrumentIDByName(string name)
        {
            string tempid = "";
            DataTable data = new DataTable();
            try
            {
                string Query = @"SELECT 
                                Comp_Short_Code
                                FROM [SBP_Company]
                                WHERE [Comp_Name]='" + name + "'";
                _dbConnection.ConnectDatabase();
                data = _dbConnection.ExecuteQuery(Query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            if (data.Rows.Count > 0)
            {
                tempid = data.Rows[0][0].ToString();
            }
            return tempid;
        }
    }
}
