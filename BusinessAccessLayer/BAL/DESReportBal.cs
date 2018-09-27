using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using System.Data;

namespace BusinessAccessLayer.BAL
{
   public class DESReportBal
   {
       private DbConnection _dbConnection;

       public DESReportBal()
       {
           _dbConnection=new DbConnection();
       }

       public DataTable GetportfulyReportInfo()
       {
           DataTable dtPortfulyReportInfo=new DataTable();

           string queryString = "";
           queryString = "DSE_PortfolioByInvestor";

           try
           {
             _dbConnection.ConnectDatabase();
             _dbConnection.ActiveStoredProcedure();
             dtPortfulyReportInfo = _dbConnection.ExecuteProQuery(queryString);
                
           }
           catch (Exception)
           {
               
               throw;
           }

           finally
           {
               _dbConnection.CloseDatabase();
           }

           return dtPortfulyReportInfo;
       }

       public DataTable GetPortfulyInstrumentReport()
       {
           DataTable dtPortfulyInstrumentReport=new DataTable();
           string queryString = "";
           queryString = "DSE_PortfolioByInstrument";

           try
           {
               _dbConnection.ConnectDatabase();
               _dbConnection.ActiveStoredProcedure();
               dtPortfulyInstrumentReport = _dbConnection.ExecuteProQuery(queryString);

           }
           catch (Exception)
           {

               throw;
           }

           finally
           {
               _dbConnection.CloseDatabase();
           }

           return  dtPortfulyInstrumentReport;
       }

       public DataTable GetCurrentStockValueByInvestorReport()
       {
           DataTable dtPortfulyInstrumentReport = new DataTable();
           string queryString = "";
           queryString = "DSE_23_2";

           try
           {
               _dbConnection.ConnectDatabase();
               _dbConnection.ActiveStoredProcedure();
               dtPortfulyInstrumentReport = _dbConnection.ExecuteProQuery(queryString);

           }
           catch (Exception)
           {

               throw;
           }

           finally
           {
               _dbConnection.CloseDatabase();
           }

           return dtPortfulyInstrumentReport;

       }

       public DataTable Get_DSE_22_1_Report(string CustomerCode,DateTime ToDate)
       {
           DataTable dt_dse_22_1_info=new DataTable();

           string queryString = "SBP_ShareLedger_New";

           try
           {
               _dbConnection.ConnectDatabase();
               _dbConnection.TimeoutPeriod = 1000;
               _dbConnection.ActiveStoredProcedure();
               _dbConnection.AddParameter("@custCode",SqlDbType.VarChar,CustomerCode);
               _dbConnection.AddParameter("@toDate", SqlDbType.DateTime, ToDate);
               dt_dse_22_1_info = _dbConnection.ExecuteProQuery(queryString);
               _dbConnection.TimeoutPeriod = 30;
           }
           catch (Exception)
           {

               throw;
           }

           finally
           {
               _dbConnection.CloseDatabase();
           }
           

           return dt_dse_22_1_info;
       }

       public DataTable Get_DSE_22_3_Report(string CompanyCode)
       {
           DataTable dt_dse_22_3_info = new DataTable();

           string queryString = "DSE_22_3";

           try
           {
               _dbConnection.ConnectDatabase();
               _dbConnection.ActiveStoredProcedure();
               _dbConnection.AddParameter("@compCode", SqlDbType.VarChar,CompanyCode);
               dt_dse_22_3_info = _dbConnection.ExecuteProQuery(queryString);

           }
           catch (Exception)
           {

               throw;
           }

           finally
           {
               _dbConnection.CloseDatabase();
           }


           return dt_dse_22_3_info;
       }

       public DataTable Get_DSE_23_1_Report(string CustCode)
       {
           DataTable dt_dse_23_1_info = new DataTable();

           string queryString = "DSE_23_1";

           try
           {
               _dbConnection.ConnectDatabase();
               _dbConnection.ActiveStoredProcedure();
               _dbConnection.AddParameter("@custCode", SqlDbType.VarChar,CustCode);
               dt_dse_23_1_info = _dbConnection.ExecuteProQuery(queryString);

           }
           catch (Exception)
           {

               throw;
           }

           finally
           {
               _dbConnection.CloseDatabase();
           }


           return dt_dse_23_1_info;
       }

       public DataTable Get_DSE_23_5_Report(string CompanyCode)
       {
           DataTable dt_dse_23_5_info = new DataTable();

           string queryString = "DSE_23_5";

           try
           {
               _dbConnection.ConnectDatabase();
               _dbConnection.ActiveStoredProcedure();
               _dbConnection.AddParameter("@compCode", SqlDbType.VarChar, CompanyCode);
               dt_dse_23_5_info = _dbConnection.ExecuteProQuery(queryString);

           }
           catch (Exception)
           {

               throw;
           }

           finally
           {
               _dbConnection.CloseDatabase();
           }


           return dt_dse_23_5_info;
       }

       public DataTable Get_DSE_23_5_2()
       {
           DataTable datatable = new DataTable();
           string queryString = "";
           queryString = "DSE_23_5_2";

           try
           {
               _dbConnection.ConnectDatabase();
               _dbConnection.ActiveStoredProcedure();
               datatable= _dbConnection.ExecuteProQuery(queryString);

           }
           catch (Exception)
           {

               throw;
           }

           finally
           {
               _dbConnection.CloseDatabase();
           }

           return datatable;

       }

       public DataTable Get_DSE_23_6_Report(DateTime InventpryDate)
       {
           DataTable dataTable = new DataTable();

           string queryString = "DSE_23_6";

           try
           {
               _dbConnection.ConnectDatabase();
               _dbConnection.ActiveStoredProcedure();
               _dbConnection.AddParameter("@date", SqlDbType.DateTime,InventpryDate.ToString("MM-dd-yyyy"));
               dataTable = _dbConnection.ExecuteProQuery(queryString);

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

       public DataTable Get_DSE_23_7_Report()
       {
           DataTable datatable = new DataTable();
           string queryString = "";
           queryString = "DSE_23_7";

           try
           {
               _dbConnection.ConnectDatabase();
               _dbConnection.ActiveStoredProcedure();
               datatable = _dbConnection.ExecuteProQuery(queryString);

           }
           catch (Exception)
           {

               throw;
           }

           finally
           {
               _dbConnection.CloseDatabase();
           }

           return datatable;
       }

       public DataTable Get_DSE_24_1_Report(DateTime fromDate,DateTime Todate)
       {
           DataTable dataTable = new DataTable();

           string queryString = "DSE_24_1";

           try
           {
               _dbConnection.ConnectDatabase();
               _dbConnection.ActiveStoredProcedure();
               _dbConnection.AddParameter("@dateFrom", SqlDbType.DateTime, fromDate.ToString("MM-dd-yyyy"));
               _dbConnection.AddParameter("@dateTo", SqlDbType.DateTime, Todate.ToString("MM-dd-yyyy"));
               dataTable = _dbConnection.ExecuteProQuery(queryString);

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

       public DataTable Get_DSE_24_2_Report(DateTime fromDate, DateTime Todate)
       {
           DataTable dataTable = new DataTable();

           string queryString = "DSE_24_2";

           try
           {
               _dbConnection.ConnectDatabase();
               _dbConnection.ActiveStoredProcedure();
               _dbConnection.AddParameter("@dateFrom", SqlDbType.DateTime, fromDate.ToString("MM-dd-yyyy"));
               _dbConnection.AddParameter("@dateTo", SqlDbType.DateTime, Todate.ToString("MM-dd-yyyy"));
               dataTable = _dbConnection.ExecuteProQuery(queryString);

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
