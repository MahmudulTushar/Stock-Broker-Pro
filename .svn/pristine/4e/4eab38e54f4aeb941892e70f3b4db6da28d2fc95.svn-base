using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using System.Data;
using System.Data.SqlClient;

namespace BusinessAccessLayer.BAL
{
    public class IPO_Instrument_Receive_Report_DSE_21_21_2BAL
    {
        private DbConnection _dbConnection;
        public IPO_Instrument_Receive_Report_DSE_21_21_2BAL()
        {
            _dbConnection = new DbConnection();
        }
        //

        //
        public DataTable GetIPO_Instrument_Receive_ReportData(DateTime Start_Date, DateTime End_Date, string Instrument_ID, string Instrument_Name)
        {
            DataTable data = new DataTable();
            try
            {
                string Query = @"rptIPO_Instrument_Receive_Report_DSE_21_21_2";
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@Start_Date", SqlDbType.DateTime, Start_Date);
                _dbConnection.AddParameter("@End_Date", SqlDbType.DateTime, End_Date);
                _dbConnection.AddParameter("@Instrument_ID", SqlDbType.VarChar, Instrument_ID);
                _dbConnection.AddParameter("@Instrument_Name", SqlDbType.VarChar, Instrument_Name);
                data = _dbConnection.ExecuteProQuery(Query);
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
        public DataTable GetInstrument()
        {
            DataTable data = new DataTable();
            try
            {
                string Query = @"SELECT 'All' as [Comp_Short_Code],
							'0' as Comp_Name
                                union all  
                                select [Comp_Short_Code],Comp_Name
                                FROM [SBP_Company]";
                                //ORDER BY Comp_Short_Code ASC";
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

        #region Get company Name
       
        public DataTable GetCompanyName()
        {
             
            DataTable dt = new DataTable();
            try
            {
                string query = @"select
                                'All' as  Comp_Name,
                                   '0'as [Comp_Short_Code]
                                   union all
                                    select 
                                Comp_Name,[Comp_Short_Code] from SBP_Company";
                this._dbConnection.ConnectDatabase();
                dt = this._dbConnection.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this._dbConnection.CloseDatabase();
            }
             
            return dt;
        }
        #endregion

    }
}
