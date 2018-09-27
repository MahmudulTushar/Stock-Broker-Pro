using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using System.Data;
using BusinessAccessLayer.BO;
using System.Data.SqlClient;

namespace BusinessAccessLayer.BAL
{
    public class BO_Opening_InformationBAL
    {
        private DbConnection _dbConnection;

        public BO_Opening_InformationBAL()
        {
            _dbConnection = new DbConnection();
        }

        public void saveBoOpeningInfo(BO_Opening_InformationBO BoOpInfoBO)
        
        {
            _dbConnection.ConnectDatabase();

            string query = @"INSERT INTO [SBP_Database].[dbo].[SBP_BO_OpeningInformation]
                           (
                            [Name]
                           ,[CellNo]
                           ,[OpDate]
                           ,[Qty]
                           ,[Price]
                           ,[TotalPrice]
                           ,[FrmNoFast]
                           ,[FrmNoLast]
                           ,[BranchId]
                           ,[CreateDate]
                           ,[CreateBy]
                           ,[Remarks]
                            )
                     VALUES
                           ('" + BoOpInfoBO.Name 
                              + "','" + BoOpInfoBO.CellNo
                              + "','" + BoOpInfoBO.OpDate.ToString("yyyy-MM-dd")
                              + "'," + BoOpInfoBO.Qty
                              + "," + BoOpInfoBO.Price
                              + "," + BoOpInfoBO.TotalPrice
                              + "," + BoOpInfoBO.FrmNoFast
                              + "," + BoOpInfoBO.FrmNoLast
                              + "," + BoOpInfoBO.BranchId
                              + ",'" + BoOpInfoBO.CreateDate.ToString("yyyy-MM-dd")
                              + "','" + BoOpInfoBO.CreateBy 
                              + "','" + BoOpInfoBO.Remarks + "')";
            _dbConnection.ExecuteNonQuery(query);
            _dbConnection.CloseDatabase();
        }

        public DataTable Get_Data(string query)
        {

            DataTable dtable;
            _dbConnection.ConnectDatabase();
            _dbConnection.StartTransaction();
            dtable = _dbConnection.ExecuteQuery(query);
            _dbConnection.Commit();

            return dtable;
        }

        public DataTable GetSearchData(string searchDate)
        {
            DataTable dtable;
            string sqlData = @"select b.OpDate as Dates
                                ,b.Name as Client_Name
                                ,b.CellNo as Mobile_No
                                ,b.Qty as Quantity
                                ,b.Price
                                ,b.TotalPrice as Total
                                ,b.FrmNoFast as First_Form_No
                                ,b.FrmNoLast as Last_FormNo 
                                from SBP_BO_OpeningInformation as b
                                where b.OpDate='" + searchDate + @"'
                                ORDER BY SlNo DESC ";

            _dbConnection.ConnectDatabase();
            _dbConnection.StartTransaction();
            dtable = _dbConnection.ExecuteQuery(sqlData);
            _dbConnection.Commit();

            return dtable;
        }

        public DataTable GetSearchDataForDelete(string DateTimeFirst, string DateTimeLast, string formNoFirst)
        {
            DataTable dtable;
            string sqlQuery = @"select
                                  OpDate as Dates
                                 ,Name as Client_Name
                                 ,CellNo as Mobile_No
                                 ,Qty as Quantity
                                 ,Price
                                 ,TotalPrice as Total
                                 ,FrmNoFast as First_Form_No
                                 ,FrmNoLast as Last_FormNo 
                                from SBP_BO_OpeningInformation
                                where OpDate between '" + DateTimeFirst + "' and '" + DateTimeLast + @"'
                                and FrmNoFast LIKE '" + formNoFirst + @"%'
                                ORDER BY SlNo DESC";

            _dbConnection.ConnectDatabase();
            _dbConnection.StartTransaction();
            dtable = _dbConnection.ExecuteQuery(sqlQuery);
            _dbConnection.Commit();

            return dtable;
        }
        public DataTable GetSearchDataForDeleteLast(string DateTimeFirst, string DateTimeLast, string formNoLast)
        {
            DataTable dtable;
            string sqlQuery = @"select
                                  OpDate as Dates
                                 ,Name as Client_Name
                                 ,CellNo as Mobile_No
                                 ,Qty as Quantity
                                 ,Price
                                 ,TotalPrice as Total
                                 ,FrmNoFast as First_Form_No
                                 ,FrmNoLast as Last_FormNo 
                                from SBP_BO_OpeningInformation
                                where OpDate between '" + DateTimeFirst + "' and '" + DateTimeLast + @"'
                                and FrmNoLast LIKE '" + formNoLast + @"%'
                                ORDER BY SlNo DESC";

            _dbConnection.ConnectDatabase();
            _dbConnection.StartTransaction();
            dtable = _dbConnection.ExecuteQuery(sqlQuery);
            _dbConnection.Commit();

            return dtable;
        }
     
        public DataTable getBoInfo(DateTime FromDate, DateTime ToDate)
        {
            DataTable dt = null;
            string query = "";
            query = @"rptBoOpeningInformationForReport";

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@StartDate",SqlDbType.DateTime,FromDate);
                _dbConnection.AddParameter("@EndDate",SqlDbType.DateTime,ToDate);
                dt = _dbConnection.ExecuteProQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dt;
        }

        public DataTable getCashInHandInfo(DateTime FromDate, DateTime ToDate)
        {
            DataTable dt = null;
            string query = "";
            query = @"RptCashInHandForReport";

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@fromDate", SqlDbType.DateTime, FromDate);
                _dbConnection.AddParameter("@toDate", SqlDbType.DateTime, ToDate);
                dt = _dbConnection.ExecuteProQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dt;
        }

        public void DeleteBoInformation(DateTime opDate, string mobilNo, string FrmNoFast, string frmNoLast)
        {
            string deleteBoInformation = @"delete SBP_BO_OpeningInformation
                                            where OpDate='"+opDate+ @"' 
	                                              and CellNo='"+mobilNo+ @"' 
	                                              and FrmNoFast="+FrmNoFast+ @"
	                                              and FrmNoLast=" + frmNoLast + @"
                                                  ";
            
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();
                _dbConnection.ExecuteNonQuery(deleteBoInformation);           
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

        public DataTable GetChargeHistory()
        {
            DataTable dt = new DataTable();
//            string query = @"SELECT Ch_ID,Ch_Item,Ch_Rate,(SELECT SUM(Ch_Rate)
//									                            FROM SBP_Ch_Def_All
//									                            WHERE Ch_ID IN (16,17)) AS 'TotalCharge'
//                            FROM SBP_Ch_Def_All
//                            WHERE Ch_ID IN (16,17)";

            string query = @"SELECT  Ch_ID AS 'ID'
                                    ,Ch_Item AS 'Charge Name'
		                            ,Ch_Rate AS 'Amount'
		                            ,CONVERT(VARCHAR(11),Ch_Effective_Date,106) AS 'Eff. Date'
		                            ,Entry_By AS 'Entry By'	
                            FROM SBP_Ch_Def_All
                            WHERE Ch_Item IN ('BO Open Charge_House','BO Open Charge_CDBL')
                            ORDER BY Ch_ID DESC";
            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dt;
        }
        public DataTable GetLastChargeHistory()
        {
            DataTable dt = new DataTable();
            string query = @"SELECT TOP 2    Ch_ID
			                                ,Ch_Item
			                                ,Ch_Rate
                                FROM SBP_Ch_Def_All AS C
                                WHERE Ch_Item IN ('BO Open Charge_House','BO Open Charge_CDBL')
                                ORDER BY Ch_ID DESC";
            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dt;
        }

        public void UpdateCharges(string HouseCharge, string CDBLCharge)
        {
            _dbConnection.ConnectDatabase();
//            string query = @"UPDATE SBP_Ch_Def_All
//                                    SET Ch_Rate=" + HouseCharge + @"
//                                    WHERE Ch_Item='BO Open Charge_House'
//                                    
//                                    UPDATE SBP_Ch_Def_All
//                                    SET Ch_Rate=" + CDBLCharge + @"
//                                    WHERE Ch_Item='BO Open Charge_CDBL'";

            string ID_Checking = @"SELECT MAX(Ch_ID)+1 AS 'Nex1',MAX(Ch_ID)+2 AS 'Nex2' FROM SBP_Ch_Def_All";

            DataTable dt = _dbConnection.ExecuteQuery(ID_Checking);
            int House_ID = Convert.ToInt32(dt.Rows[0][0].ToString());
            int CDBL_ID = Convert.ToInt32(dt.Rows[0][1].ToString());

            string query = @"INSERT INTO [SBP_Database].[dbo].[SBP_Ch_Def_All]
                                                       ([Ch_ID]
                                                       ,[Ch_Item]
                                                       ,[Ch_Description]
                                                       ,[Ch_Category]
                                                       ,[Ch_Min_Fee]
                                                       ,[Ch_Rate]
                                                       ,[Ch_Effective_Date]
                                                       ,[Entry_Date]
                                                       ,[Entry_By])
                                                 VALUES
                                                       (" + House_ID + @"
                                                       ,'BO Open Charge_House'
                                                       ,'Total BO Open House Charge'
                                                       ,'House'
                                                       ,0.00
                                                       ," + HouseCharge + @"
                                                       ,'" + GlobalVariableBO._currentServerDate.ToShortDateString() + @"'
                                                       ,'" + GlobalVariableBO._currentServerDate.ToShortDateString() + @"'
                                                       ,'" + GlobalVariableBO._userName + @"')
                                                       
                                      

                                            INSERT INTO [SBP_Database].[dbo].[SBP_Ch_Def_All]
                                                       ([Ch_ID]
                                                       ,[Ch_Item]
                                                       ,[Ch_Description]
                                                       ,[Ch_Category]
                                                       ,[Ch_Min_Fee]
                                                       ,[Ch_Rate]
                                                       ,[Ch_Effective_Date]
                                                       ,[Entry_Date]
                                                       ,[Entry_By])
                                                 VALUES
                                                       (" + CDBL_ID + @"
                                                       ,'BO Open Charge_CDBL'
                                                       ,'Total BO Open CDBL Charge'
                                                       ,'CDBL'
                                                       ,0.00
                                                       ," + CDBLCharge + @"
                                                       ,'" + GlobalVariableBO._currentServerDate.ToShortDateString() + @"'
                                                       ,'" + GlobalVariableBO._currentServerDate.ToShortDateString() + @"'
                                                       ,'" + GlobalVariableBO._userName + @"')";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
        }
    }
}
