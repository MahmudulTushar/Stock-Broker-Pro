using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessAccessLayer.BO;
using DataAccessLayer;

namespace BusinessAccessLayer.BAL
{
    public class DashboardBAL
    {
        private DbConnection _dbConnection;

        public DashboardBAL()
        {
            _dbConnection = new DbConnection();
        }

        #region IPO DashBoard Process
        public void IPODashBoardProcess()
        {
            string query = @"SBP_IPODashboardProcess";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@EntryBy", SqlDbType.VarChar, GlobalVariableBO._userName);
                _dbConnection.AddParameter("@Branch_ID", SqlDbType.Int, GlobalVariableBO._branchId);
                _dbConnection.ExecuteProQuery(query);
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
        #endregion

        public DataTable GetCustomerDetails(string code, int isCustCode)
        {
            DataTable dataTable;
            string queryString = @"ShowCustomerDetailsForDashBoard";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@custCode", SqlDbType.NVarChar, code);
                _dbConnection.AddParameter("@isCustCode", SqlDbType.Int, isCustCode);
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

        public void IPODashboardProcessIndividualCustCode(int custCode)
        {
            string query = @"SBP_IPODashboardProcessIndividualCustCode";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@EntryBy", SqlDbType.VarChar, GlobalVariableBO._userName);
                _dbConnection.AddParameter("@Branch_ID", SqlDbType.Int, GlobalVariableBO._branchId);
                _dbConnection.AddParameter("@custCode", SqlDbType.Int, custCode);
                _dbConnection.ExecuteProQuery(query);
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

        public DataTable GetCustomerDetails_FromTemp(string code, int isCustCode)
        {
            DataTable dataTable;
            string queryString = @"DashboardProcess";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@isDashboardProcess", SqlDbType.Int, 0);
		        _dbConnection.AddParameter("@isGetCustDetails", SqlDbType.Int, 1);
		        _dbConnection.AddParameter("@isCustCode", SqlDbType.Int, isCustCode);
		        _dbConnection.AddParameter("@filterCustCode", SqlDbType.VarChar, code);
		        _dbConnection.AddParameter("@isGetShareSummary", SqlDbType.Int, 0);
		        _dbConnection.AddParameter("@isPrev", SqlDbType.Int, 0);
		        _dbConnection.AddParameter("@isGetShareDetails", SqlDbType.Int, 0);
		        _dbConnection.AddParameter("@filterComp_Short_Code", SqlDbType.VarChar, '0');
		        _dbConnection.AddParameter("@isGetShareDetailsExtr", SqlDbType.Int, 0);
		        _dbConnection.AddParameter("@EntryBy", SqlDbType.Int, '0');
		        _dbConnection.AddParameter("@BranchID", SqlDbType.Int, 0);

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

        public DataTable GetShareSummery(string code, int isPrev)
        {
            DataTable dataTable;
            string queryString = "";

            queryString = @"ShowShareSummeryForDashBoard";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@custCode", SqlDbType.NVarChar, code);
                _dbConnection.AddParameter("@isPrev", SqlDbType.Int, isPrev);
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

        public DataTable GetShareSummery_FromTemp(string code, int isPrev)
        {
            DataTable dataTable;
            string queryString = @"DashboardProcess";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@isDashboardProcess", SqlDbType.Int, 0);
                _dbConnection.AddParameter("@isGetCustDetails", SqlDbType.Int, 0);
                _dbConnection.AddParameter("@isCustCode", SqlDbType.Int, 1);
                _dbConnection.AddParameter("@filterCustCode", SqlDbType.VarChar, code);
                _dbConnection.AddParameter("@isGetShareSummary", SqlDbType.Int, 1);
                _dbConnection.AddParameter("@isPrev", SqlDbType.Int, isPrev);
                _dbConnection.AddParameter("@isGetShareDetails", SqlDbType.Int, 0);
                _dbConnection.AddParameter("@filterComp_Short_Code", SqlDbType.VarChar, '0');
                _dbConnection.AddParameter("@isGetShareDetailsExtr", SqlDbType.Int, 0);
                _dbConnection.AddParameter("@EntryBy", SqlDbType.Int, '0');
                _dbConnection.AddParameter("@BranchID", SqlDbType.Int, 0);

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

        public DataTable GetShareDetails(string custCode,string compCode)
        {
            DataTable dataTable;
            string queryString = "";

            queryString = @"ShowShareDetailsForDashBoard";
                       
            //******Probable Trade Date*****(SELECT CONVERT(varchar(11),MDate,103) FROM SBP_Temp_Probable_Trade_Days WHERE [ID]=(SELECT [ID] FROM SBP_Transactions,SBP_Temp_Probable_Trade_Days WHERE  Customer="+custCode+" AND InstrumentCode='"+compCode+"' AND EventDate=MDate)+MaturityDays)
            //"SELECT CONVERT(varchar(11),Trade_Date,103) AS 'Date',Buy_Total AS 'Buy Total',Buy_Avg AS 'Buy Avg',Sell_Total AS 'Sell Total',Sell_Avg AS 'Sell Avg','' AS 'Break Event Price','' AS 'Prabably Mature',Remarks FROM SBP_Share_Balance_Temp WHERE Comp_Short_Code='" + compCode + "' AND Cust_Code=" + custCode;
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@custCode", SqlDbType.NVarChar, custCode);
                _dbConnection.AddParameter("@compShortCode", SqlDbType.NVarChar, compCode);
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

        public DataTable GetShareDetails_FromTemp(string custCode, string compCode)
        {
            DataTable dataTable;
            string queryString = @"DashboardProcess";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@isDashboardProcess", SqlDbType.Int, 0);
                _dbConnection.AddParameter("@isGetCustDetails", SqlDbType.Int, 0);
                _dbConnection.AddParameter("@isCustCode", SqlDbType.Int, 1);
                _dbConnection.AddParameter("@filterCustCode", SqlDbType.VarChar, custCode);
                _dbConnection.AddParameter("@isGetShareSummary", SqlDbType.Int, 0);
                _dbConnection.AddParameter("@isPrev", SqlDbType.Int, 0);
                _dbConnection.AddParameter("@isGetShareDetails", SqlDbType.Int, 1);
                _dbConnection.AddParameter("@filterComp_Short_Code", SqlDbType.VarChar, compCode);
                _dbConnection.AddParameter("@isGetShareDetailsExtr", SqlDbType.Int, 0);
                _dbConnection.AddParameter("@EntryBy", SqlDbType.Int, '0');
                _dbConnection.AddParameter("@BranchID", SqlDbType.Int, 0);

                dataTable = _dbConnection.ExecuteProQuery(queryString);
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dataTable;
        }

       

        /// <summary>
        /// Add Market value,Gain loss,Total Buy March 2015
        /// Margin Type added on 25 Aug 2015
        /// By Rashedul Hasan
        /// </summary>
        /// <param name="compCode"></param>
        /// <param name="custCode"></param>
        /// <returns></returns>
        public DataTable GetShareDetailsExtr(string compCode, string custCode)
        {
            DataTable dataTable;
            string queryString = "";

            queryString = @"
                        Declare @MarketValue Decimal
                        Set @MarketValue=(
					                        SELECT SUM(Balance*TempT.Close_Price) As MarketValue
					                        FROM SBP_Share_Balance_Temp,
						                        (
							                        SELECT DISTINCT t.Instrument_Code, t.Close_Price 
							                        FROM SBP_Trade_Price as t
							                        WHERE t.Trade_Date=
								                        (
									                        SELECT MAX(c.Trade_Date) 
									                        FROM SBP_Trade_Price as c 
									                        WHERE c.Trade_Date<=GETDATE() 
									                        AND c.Instrument_Code= t.Instrument_Code
									                        And c.Instrument_Code='" + compCode + @"'
								                        )
							                        And t.Instrument_Code='" + compCode + @"'
						                        ) AS TempT 
					                        WHERE 
					                        SBP_Share_Balance_temp.Comp_short_code=TempT.Instrument_Code 
					                        AND SBP_Share_Balance_Temp.Cust_Code='" + custCode + @"'
					                        And SBP_Share_Balance_Temp.Comp_short_code='" + compCode + @"'
	                                    )
                        SELECT
                        T.ClosingPrice
                        ,T.LastTradeDate
                        ,T.BuyAvg
                        ,dbo.GetNetAvg_WithClosingPrice('" + custCode + @"',GETDATE(),'" + compCode + @"',T.ClosingPrice) as NetAvg
                        ,T.CompCatName
                        ,T.MarketValue
                        ,T.Total_Buy
                        ,T.Gain_Loss
                        ,T.Margin_Type
                        FROM 
                        (
	                        SELECT dbo.GetLastClosingPrice('" + compCode + @"') as ClosingPrice
	                        ,dbo.GetLastTradeDate('" + compCode + @"','" + custCode + @"') as LastTradeDate
	                        ,dbo.GetBuyAvg('" + custCode + @"',GETDATE(),'" + compCode + @"') as BuyAvg
	                        --,dbo.GetNetAvg('" + custCode + @"',GETDATE(),'" + compCode + @"')
	                        ,dbo.GetCompCatName('" + compCode + @"') as CompCatName
	                        ,@MarketValue As MarketValue
                            ,[dbo].[GetISNTotalBuy] ('" + custCode + @"',GETDATE(),'" + compCode + @"') As Total_Buy
                            ,[dbo].[GetISNValue]('" + custCode + @"',GETDATE(),'" + compCode + @"') As Gain_Loss
                            ,(
                            Select M.Margin_Type From SBP_Company as C
                            Join SBP_Comp_Margin_NonMargin as M
                            on c.IsMargin=m.ID
                            Where C.Comp_Short_Code='" + compCode + @"'      
                            ) As Margin_Type
                        ) AS T
            ";

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

        //Old v2
        ///// <summary>
        //        /// Add Market value,Gain loss,Total Buy
        //        /// By Rashedul Hasan
        //        /// </summary>
        //        /// <param name="compCode"></param>
        //        /// <param name="custCode"></param>
        //        /// <returns></returns>
        //        public DataTable GetShareDetailsExtr(string compCode, string custCode)
        //        {
        //            DataTable dataTable;
        //            string queryString = "";

        //            queryString = @"
        //                        Declare @MarketValue Decimal
        //                        Set @MarketValue=(
        //					                        SELECT SUM(Balance*TempT.Close_Price) As MarketValue
        //					                        FROM SBP_Share_Balance_Temp,
        //						                        (
        //							                        SELECT DISTINCT t.Instrument_Code, t.Close_Price 
        //							                        FROM SBP_Trade_Price as t
        //							                        WHERE t.Trade_Date=
        //								                        (
        //									                        SELECT MAX(c.Trade_Date) 
        //									                        FROM SBP_Trade_Price as c 
        //									                        WHERE c.Trade_Date<=GETDATE() 
        //									                        AND c.Instrument_Code= t.Instrument_Code
        //									                        And c.Instrument_Code='" + compCode + @"'
        //								                        )
        //							                        And t.Instrument_Code='" + compCode + @"'
        //						                        ) AS TempT 
        //					                        WHERE 
        //					                        SBP_Share_Balance_temp.Comp_short_code=TempT.Instrument_Code 
        //					                        AND SBP_Share_Balance_Temp.Cust_Code='" + custCode + @"'
        //					                        And SBP_Share_Balance_Temp.Comp_short_code='" + compCode + @"'
        //	                                    )
        //                        SELECT
        //                        T.ClosingPrice
        //                        ,T.LastTradeDate
        //                        ,T.BuyAvg
        //                        ,dbo.GetNetAvg_WithClosingPrice('" + custCode + @"',GETDATE(),'" + compCode + @"',T.ClosingPrice) as NetAvg
        //                        ,T.CompCatName
        //                        ,T.MarketValue
        //                        ,T.Total_Buy
        //                        ,T.Gain_Loss
        //                        FROM 
        //                        (
        //	                        SELECT dbo.GetLastClosingPrice('" + compCode + @"') as ClosingPrice
        //	                        ,dbo.GetLastTradeDate('" + compCode + @"','" + custCode + @"') as LastTradeDate
        //	                        ,dbo.GetBuyAvg('" + custCode + @"',GETDATE(),'" + compCode + @"') as BuyAvg
        //	                        --,dbo.GetNetAvg('" + custCode + @"',GETDATE(),'" + compCode + @"')
        //	                        ,dbo.GetCompCatName('" + compCode + @"') as CompCatName
        //	                        ,@MarketValue As MarketValue
        //                            ,[dbo].[GetISNTotalBuy] ('" + custCode + @"',GETDATE(),'" + compCode + @"') As Total_Buy
        //                            ,[dbo].[GetISNValue]('" + custCode + @"',GETDATE(),'" + compCode + @"') As Gain_Loss
        //                        ) AS T
        //            ";

        //            try
        //            {
        //                _dbConnection.ConnectDatabase();
        //                dataTable = _dbConnection.ExecuteQuery(queryString);
        //            }
        //            catch (Exception)
        //            {
        //                throw;
        //            }
        //            finally
        //            {
        //                _dbConnection.CloseDatabase();
        //            }
        //            return dataTable;
        //        }
                
        //Old Copy v1
        //        public DataTable GetShareDetailsExtr(string compCode, string custCode)
        //        {
        //            DataTable dataTable;
        //            string queryString = "";

        //            queryString = @"SELECT
        //            T.ClosingPrice
        //            ,T.LastTradeDate
        //            ,T.BuyAvg
        //            ,dbo.GetNetAvg_WithClosingPrice('" + custCode + @"',GETDATE(),'" + compCode + @"',T.ClosingPrice) as NetAvg
        //            ,T.CompCatName
        //            ,T.MarketValue
        //            ,T.Total_Buy
        //            ,T.Gain_Loss
        //            FROM 
        //            (
        //	            SELECT dbo.GetLastClosingPrice('" + compCode + @"') as ClosingPrice
        //	            ,dbo.GetLastTradeDate('" + compCode + @"','" + custCode + @"') as LastTradeDate
        //	            ,dbo.GetBuyAvg('" + custCode + @"',GETDATE(),'" + compCode + @"') as BuyAvg
        //	            --,dbo.GetNetAvg('" + custCode + @"',GETDATE(),'" + compCode + @"')
        //	            ,dbo.GetCompCatName('" + compCode + @"') as CompCatName
        //	            ,(
        //					SELECT SUM(Balance*TempT.Close_Price) As MarketValue
        //					FROM SBP_Share_Balance_Temp,
        //						(
        //							SELECT DISTINCT t.Instrument_Code, t.Close_Price 
        //							FROM SBP_Trade_Price as t
        //							WHERE t.Trade_Date=
        //								(
        //									SELECT MAX(c.Trade_Date) 
        //									FROM SBP_Trade_Price as c 
        //									WHERE c.Trade_Date<=GETDATE() 
        //									AND c.Instrument_Code= t.Instrument_Code
        //									And c.Instrument_Code='" + compCode + @"'
        //								)
        //							And t.Instrument_Code='" + compCode + @"'
        //						) AS TempT 
        //					WHERE 
        //					SBP_Share_Balance_temp.Comp_short_code=TempT.Instrument_Code 
        //					AND SBP_Share_Balance_Temp.Cust_Code='" + custCode + @"'
        //					And SBP_Share_Balance_Temp.Comp_short_code='" + compCode + @"'
        //	            )As MarketValue
        //                ,(Select SUM(buy_Total) From SBP_Share_Balance_Temp where Cust_Code='" + custCode + @"' and Comp_Short_Code='" + compCode + @"') As Total_Buy
        //                ,[dbo].[GetISNValue]('" + custCode + @"',GETDATE(),'" + compCode + @"') As Gain_Loss
        //            ) AS T
        //            ";

        //            try
        //            {
        //                _dbConnection.ConnectDatabase();
        //                dataTable = _dbConnection.ExecuteQuery(queryString);
        //            }
        //            catch (Exception)
        //            {
        //                throw;
        //            }
        //            finally
        //            {
        //                _dbConnection.CloseDatabase();
        //            }
        //            return dataTable;
        //        }

        //        public DataTable GetShareDetailsExtr(string compCode,string custCode)
        //        {
        //            DataTable dataTable;
        //            string queryString = "";

        //            queryString = @"SELECT
        //            T.ClosingPrice
        //            ,T.LastTradeDate
        //            ,T.BuyAvg
        //            ,dbo.GetNetAvg_WithClosingPrice('" + custCode + @"',GETDATE(),'" + compCode + @"',T.ClosingPrice) as NetAvg
        //            ,T.CompCatName
        //            FROM 
        //            (
        //	            SELECT dbo.GetLastClosingPrice('"+compCode+@"') as ClosingPrice
        //	            ,dbo.GetLastTradeDate('"+compCode+@"','"+custCode+@"') as LastTradeDate
        //	            ,dbo.GetBuyAvg('"+custCode+@"',GETDATE(),'"+compCode+@"') as BuyAvg
        //	            --,dbo.GetNetAvg('"+custCode+@"',GETDATE(),'"+compCode+@"')
        //	            ,dbo.GetCompCatName('" + compCode + @"') as CompCatName
        //            ) AS T
        //            ";

        //            try
        //            {
        //                _dbConnection.ConnectDatabase();
        //                dataTable = _dbConnection.ExecuteQuery(queryString);
        //            }
        //            catch (Exception)
        //            {
        //                throw;
        //            }
        //            finally
        //            {
        //                _dbConnection.CloseDatabase();
        //            }
        //            return dataTable;
        //        }

        public DataTable GetShareDetailsExtr_FromTemp(string compCode, string custCode)
        {
            DataTable dataTable;
            string queryString = @"DashboardProcess";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@isDashboardProcess", SqlDbType.Int, 0);
                _dbConnection.AddParameter("@isGetCustDetails", SqlDbType.Int, 0);
                _dbConnection.AddParameter("@isCustCode", SqlDbType.Int, 1);
                _dbConnection.AddParameter("@filterCustCode", SqlDbType.VarChar, custCode);
                _dbConnection.AddParameter("@isGetShareSummary", SqlDbType.Int, 0);
                _dbConnection.AddParameter("@isPrev", SqlDbType.Int, 0);
                _dbConnection.AddParameter("@isGetShareDetails", SqlDbType.Int, 0);
                _dbConnection.AddParameter("@filterComp_Short_Code", SqlDbType.VarChar, compCode);
                _dbConnection.AddParameter("@isGetShareDetailsExtr", SqlDbType.Int, 1);
                _dbConnection.AddParameter("@EntryBy", SqlDbType.Int, '0');
                _dbConnection.AddParameter("@BranchID", SqlDbType.Int, 0);

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

        public void DashBoard_Details_Populate()
        {
            DataTable dataTable;
            string queryString = @"DashboardProcess";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@isDashboardProcess", SqlDbType.Int, 1);
                _dbConnection.AddParameter("@isGetCustDetails", SqlDbType.Int, 0);
                _dbConnection.AddParameter("@isCustCode", SqlDbType.Int, 0);
                _dbConnection.AddParameter("@filterCustCode", SqlDbType.VarChar, string.Empty);
                _dbConnection.AddParameter("@isGetShareSummary", SqlDbType.Int, 0);
                _dbConnection.AddParameter("@isPrev", SqlDbType.Int, 0);
                _dbConnection.AddParameter("@isGetShareDetails", SqlDbType.Int, 0);
                _dbConnection.AddParameter("@filterComp_Short_Code", SqlDbType.VarChar, string.Empty);
                _dbConnection.AddParameter("@isGetShareDetailsExtr", SqlDbType.Int, 0);
                _dbConnection.AddParameter("@EntryBy", SqlDbType.Int, '0');
                _dbConnection.AddParameter("@BranchID", SqlDbType.Int, 0);

                _dbConnection.ExecuteProQuery(queryString);
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

        public void DashBoard_Details_UpdateByCurrentData()
        {
            DataTable dataTable;
            string queryString = @"UpdateDashBoard_ByCurrentData";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.ExecuteProQuery(queryString);
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

        public void Execute_GenereateMoneyBalanceTemp(string Cust_Code)
        {

            DataTable dataTable;
            string queryString = @"GenerateMoneyBalanceTemp_ByCust_Code";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@Cust_Code", SqlDbType.VarChar, Cust_Code);
                _dbConnection.ExecuteProQuery(queryString);
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

        public DataTable GetCompGraphValues(string compCode, DateTime dateFrom, DateTime dateTo)
        {
            DataTable dataTable;
            string queryString = "";

            //NI
            queryString = "SELECT Trade_Date,ISNULL(AVG(Close_Price),0),ISNULL(AVG(Total_Trade),0),ISNULL(AVG(Volume),0),ISNULL(AVG(Trade_Value),0) FROM SBP_Trade_Price WHERE Instrument_Code='" + compCode + "' AND Trade_Date BETWEEN '" + dateFrom.ToShortDateString() + "' AND '" + dateTo.ToShortDateString() + "' GROUP BY Trade_Date ORDER BY Trade_Date ASC";

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

        public DataTable GetCompGraphValuesByVolume(string compCode)
        {
            DataTable dataTable;
            string queryString = "";

            //NI
            queryString = "SELECT TOP 30 Trade_Date,Volume FROM SBP_Trade_Price WHERE Instrument_Code='" + compCode + "' ORDER BY Trade_Date DESC";

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

        public void InsertDashboardLog(string custCode)
        {
            CommonBAL commonBAL = new CommonBAL();
            //int slNo = commonBAL.GenerateID("SBP_Dashboard_Log", "Sl_No");

            //string queryString = "INSERT INTO SBP_Dashboard_Log(Sl_No,User_Name,Cust_Code,Log_time) Values(" + slNo + ",'" + GlobalVariableBO._userName + "','" + custCode + "',GETDATE())";
            string queryString = "INSERT INTO SBP_Dashboard_Log(User_Name,Cust_Code,Log_time) Values('" + GlobalVariableBO._userName + "','" + custCode + "',GETDATE())";
            try
            {
                _dbConnection.ConnectDatabase();
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


        public int CheckHiddenCustomer(string custCode)
        {
            DataTable dataTable;
            string queryString = "";

            queryString = "SELECT Reference_Code AS Cust_Code FROM SBP_Hide_Customer WHERE Reference_Code='" + custCode + "'";

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
                return 1;
            else
            {
                return 0;
            }
        }

        public bool IsLimitedfromDashboard(string ClientCode)
        {
            string queryString = "SELECT * FROM dbo.SBP_Limited_Dashbord WHERE User_Name='" + GlobalVariableBO._userName + "' AND Reference_Code='" + ClientCode + "'";
            DataTable data=new DataTable();
            bool IsLimited = false;

            try
            {
                _dbConnection.ConnectDatabase();
                data = _dbConnection.ExecuteQuery(queryString);

                if(data.Rows.Count>0)
                    IsLimited = true;
                else
                {
                    IsLimited = false;
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

            return IsLimited;
        }

        public bool IsLimitedDashboardByBOID(string BO_ID)
        {
            string queryString =
                "SELECT * FROM dbo.SBP_Limited_Dashbord WHERE User_Name='" + GlobalVariableBO._userName + "' AND Reference_Code=(SELECT Cust_Code FROM dbo.SBP_Customers WHERE BO_ID='" + BO_ID + "')";

            DataTable data = new DataTable();
            bool IsLimited = false;

            try
            {
                _dbConnection.ConnectDatabase();
                data = _dbConnection.ExecuteQuery(queryString);

                if (data.Rows.Count > 0)
                    IsLimited = true;
                else
                {
                    IsLimited = false;
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

            return IsLimited;
        }

        public int IsLimitedDashboardPrivliage()
        {
            string queryString =
                "SELECT * FROM dbo.SBP_Previllizes WHERE Role_Name=(SELECT dbo.SBP_Users.Role_Name FROM dbo.SBP_Users WHERE dbo.SBP_Users.User_Name='"+GlobalVariableBO._userName+"') AND Previllize='Limited Client Dashboard'";
            DataTable data = new DataTable();
            int IslimitedDashboard = 0;

            try
            {
                _dbConnection.ConnectDatabase();
                data = _dbConnection.ExecuteQuery(queryString);

                if (data.Rows.Count > 0)
                {
                    IslimitedDashboard = 1;
                }

                else
                {
                    IslimitedDashboard = 0;
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

            return IslimitedDashboard;
        }

    }
}
