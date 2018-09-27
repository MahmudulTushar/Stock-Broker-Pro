﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DataAccessLayer;

namespace BusinessAccessLayer.BAL
{
    public class TradeSummeryBAL
    {
        private DbConnection _dbConnection;

        public TradeSummeryBAL()
        {
            _dbConnection = new DbConnection();
        }
        public DataTable GetWorkStationInfo()
        {
            string queryString = "";
            DataTable dataTable = new DataTable();

            queryString = "SELECT UserID='All'"
                + "UNION "
                + "SELECT  distinct UserID FROM SBP_Transactions";

            try
            {
                _dbConnection.ConnectDatabase();

                dataTable = _dbConnection.ExecuteQuery(queryString);

                return dataTable;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable GetTradeSummery(string workStation, DateTime fromDate, DateTime toDate)
        {
            DataTable dtTradeSummery = null;
            string quryString = @"RptNewGetTradeSummery";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@workStation",SqlDbType.NVarChar,workStation);
                _dbConnection.AddParameter("@fromDate", SqlDbType.DateTime, fromDate.ToShortDateString());
                _dbConnection.AddParameter("@toDate", SqlDbType.DateTime, toDate.ToShortDateString());
                dtTradeSummery = _dbConnection.ExecuteProQuery(quryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dtTradeSummery;         
        }

        public DataTable GetSpotTradeSummery(DateTime fromDate, DateTime toDate)
        {
            DataTable dtSpotTradeSummery = null;
            string quryString = @"RptGetSpotTradeSummery";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@fromDate", SqlDbType.DateTime, fromDate.ToShortDateString());
                _dbConnection.AddParameter("@toDate", SqlDbType.DateTime, toDate.ToShortDateString());
                dtSpotTradeSummery = _dbConnection.ExecuteProQuery(quryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dtSpotTradeSummery;   
        }

        public DataTable GetCashflowReport(DateTime fromDate,DateTime toDate)
        {
            DataTable data=new DataTable();
            string queryString = "RPT_Cashflow";

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@fromDate",SqlDbType.DateTime,fromDate.ToShortDateString());
                _dbConnection.AddParameter("@toDate",SqlDbType.DateTime,toDate.ToShortDateString());
                data=_dbConnection.ExecuteProQuery(queryString);
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

        // function for Payment date wise Dse Ledger to extract Previous fromdate
        public DataTable GetPrevFrmDate(string queryString)
        {
            DataTable dataTable = new DataTable();

            try
            {
                _dbConnection.ConnectDatabase();

                dataTable = _dbConnection.ExecuteQuery(queryString);

                return dataTable;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}