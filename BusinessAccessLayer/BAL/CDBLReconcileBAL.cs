using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DataAccessLayer;

namespace BusinessAccessLayer.BAL
{
    public class CDBLReconcileBAL
    {
        private DbConnection _dbConnection;
        public CDBLReconcileBAL()
        {
            _dbConnection = new DbConnection();
        }
        public void TruncateCDBLReconcile()
        {
            string queryString = "";
            queryString = "TRUNCATE TABLE SBP_11DPA6UX";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();
                _dbConnection.ExecuteNonQuery(queryString);
                _dbConnection.Commit();
            }
            catch (Exception exception)
            {
                _dbConnection.Rollback();
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
        }

        public void SaveCDBLReconcileInfo(DataTable dataTable, string tableName)
        {
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.BulkCopy(dataTable, tableName);
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

//        public DataTable GetCustWiseShareRecocile()
//        {
//            DataTable dtShareReconcile = null;
//            string quryString = "";
//            quryString = "SELECT CDBL.Cust_Code,CDBL.Comp_Short_Code AS 'Company',CDBL.Balance AS 'CDBL_Share',BackOfc.SBalance AS 'BackOffice_Share',BackOfc.MSBalance AS 'BackOffice_MShare' FROM "+
//                " (SELECT Cust_Code,Comp_Short_Code,SUM(Balance) AS Balance FROM SBP_11DPA6UX GROUP BY Cust_Code,Comp_Short_Code) AS CDBL JOIN (SELECT Cust_Code,Comp_Short_Code,SUM(Balance) AS SBalance,SUM(Matured_Balance) AS MSBalance FROM SBP_Share_Balance_Temp GROUP BY Cust_Code,Comp_Short_Code) AS BackOfc ON (CDBL.Cust_Code=BackOfc.Cust_Code AND CDBL.Comp_Short_Code=BackOfc.Comp_Short_Code)"+
//" WHERE CDBL.Balance<>BackOfc.SBalance OR CDBL.Balance<>BackOfc.MSBalance ";
//            try
//            {
//                _dbConnection.ConnectDatabase();
//                dtShareReconcile = _dbConnection.ExecuteQuery(quryString);
//            }
//            catch (Exception exc)
//            {
//                throw exc;
//            }
//            finally
//            {
//                _dbConnection.CloseDatabase();
//            }
//            return dtShareReconcile;
            
//        }
        public DataTable GetCustWiseShareRecocile()
        {
            DataTable dataTable;
            string queryString = "";
            queryString = @"RptGetShareReconcilation_Missmatch_CustomerWise";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
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
            return dataTable;


        }

        //public DataTable GetCompanyWiseShareRecocile()
        //{
        //    DataTable dtShareReconcile = null;
        //    string quryString = "";
        //    quryString =
        //        "SELECT CDBL.Comp_Short_Code AS 'Company',CDBL.Balance AS 'CDBL_Share',BackOfc.SBalance AS 'BackOffice_Share',BackOfc.MSBalance AS 'BackOffice_MShare',CDBL.Balance-BackOfc.MSBalance AS 'Mismatch'" +
        //        " FROM (SELECT Comp_Short_Code,SUM(Balance) AS Balance FROM SBP_11DPA6UX GROUP BY Comp_Short_Code) AS CDBL JOIN (SELECT Comp_Short_Code,SUM(Balance) AS SBalance,SUM(Matured_Balance) AS MSBalance FROM SBP_Share_Balance_Temp GROUP BY Comp_Short_Code) AS BackOfc ON (CDBL.Comp_Short_Code=BackOfc.Comp_Short_Code)" +
        //        " WHERE CDBL.Balance<>BackOfc.SBalance OR CDBL.Balance<>BackOfc.MSBalance";

        //    try
        //    {
        //        _dbConnection.ConnectDatabase();
        //        dtShareReconcile = _dbConnection.ExecuteQuery(quryString);
        //    }
        //    catch (Exception exc)
        //    {
        //        throw exc;
        //    }
        //    finally
        //    {
        //        _dbConnection.CloseDatabase();
        //    }
        //    return dtShareReconcile;
            
        //}
        public DataTable GetCompanyWiseShareRecocile()
        {
            DataTable dataTable;
            string queryString = "";
            queryString = @"RptGetShareReconcilation_Missmatch_CompanyWise";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
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
            return dataTable;

        }
        public DataTable GetMissMatchReconcilation()
        {
            DataTable dataTable;
            string queryString = "";
            queryString = @"RptGetShareReconcilation_Missmatch";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
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
            return dataTable;
        }


        public DataTable GetDateInfo()
        {
            DataTable dtDateInfo = null;
            string quryString = "";
            quryString = "SELECT GETDATE() AS 'Current_Date',(SELECT MAX(EventDate) FROM SBP_Transactions) AS 'Last_Trade_Date',(SELECT MAX(UDate) FROM SBP_11DPA6UX) AS 'ISIN_Date'";
            try
            {
                _dbConnection.ConnectDatabase();
                dtDateInfo = _dbConnection.ExecuteQuery(quryString);
            }
            catch (Exception exc)
            {
                throw exc;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dtDateInfo;
            
        }
    }
}
