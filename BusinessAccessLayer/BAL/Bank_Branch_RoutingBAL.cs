using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using BusinessAccessLayer.BO;
using System.Data;

namespace BusinessAccessLayer.BAL
{
   public class Bank_Branch_RoutingBAL
    {
       private DbConnection _dbConnection;
       public Bank_Branch_RoutingBAL()
        {
            _dbConnection = new DbConnection();
        }
   
        public DataTable GetGridData()
        { 
            DataTable data = new DataTable();
            string query = @" SELECT bbri.[ID]
                              ,Bank_ID
                              ,Bank_Name
                              ,Branch_ID
                              ,Branch_Name
                              ,Routing_No
                              ,District_ID
                              ,District_Name
                              ,Thana_ID
                              ,Thana_Name
                          FROM SBP_Bank_Branch_Routing_Info AS bbri";

                          //INNER JOIN dbo.SBP_Bank_Info AS bnk
                          //ON bbri.[Bank_ID]=bnk.ID
                          //INNER JOIN dbo.SBP_Branch_Info AS brn
                          //ON bbri.[Branch_ID]=brn.ID
                          //INNER JOIN dbo.SBP_District_Info AS dist
                          //ON bbri.[District_ID]=dist.ID
                          //INNER JOIN  dbo.SBP_Thana_Info AS thn
                          //ON bbri.[Thana_ID]=thn.ID";
                          
            try
            {
                _dbConnection.ConnectDatabase();
                data = _dbConnection.ExecuteQuery(query);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return data;
        }

        public DataTable GetBankName()
        {
            DataTable data = new DataTable();
            string query = @" SELECT [ID]
                              ,[Bank_Code]
                              ,[Bank_Name] AS Bank_Name
                              ,[Bank_Code]+'-'+[Bank_Name] AS Bank_Code_Name
                              FROM [SBP_Bank_Info]";
            try
            {
                _dbConnection.ConnectDatabase();
                data = _dbConnection.ExecuteQuery(query);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return data;
        }
        public DataTable GetBranchName()
        {
            DataTable data = new DataTable();
            string query = @" SELECT [ID]
                              ,[Branch_Code]
                              ,[Branch_Name] AS Branch_Name
                              ,[Branch_Code]+'-'+[Branch_Name] AS Branch_Code_Name
                              FROM [SBP_Branch_Info]";
            try
            {
                _dbConnection.ConnectDatabase();
                data = _dbConnection.ExecuteQuery(query);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return data;
        }

        public DataTable GetBranchName(int BankID)
        {
            DataTable data = new DataTable();
            string query = @" SELECT [Branch_ID] AS Branch_ID
                              ,[Branch_Name] AS Branch_Name
                              FROM [SBP_Bank_Branch_Routing_Info] 
                              WHERE Bank_ID=" + BankID+"";
            try
            {
                _dbConnection.ConnectDatabase();
                data = _dbConnection.ExecuteQuery(query);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return data;
        }

        public DataTable GetDistrictName()
        {
            DataTable data = new DataTable();
            string query = @" SELECT [ID]
                              ,[District_Code]
                              ,[District_Name] AS [District_Name]
                              ,[District_Code]+'-'+[District_Name] AS District_Code_Name
                              FROM [SBP_District_Info]";
            try
            {
                _dbConnection.ConnectDatabase();
                data = _dbConnection.ExecuteQuery(query);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return data;
        }

        public DataTable GetThanaName()
        {
            DataTable data = new DataTable();
            string query = @" SELECT [ID]
                              ,[Thana_Code]
                              ,[Thana_Name] AS [Thana_Name]  
                              ,[Thana_Code]+'-'+[Thana_Name] AS Thana_Code_Name
                              FROM [SBP_Thana_Info]";
            try
            {
                _dbConnection.ConnectDatabase();
                data = _dbConnection.ExecuteQuery(query);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return data;
        }

        public DataTable GetBankInfoByBankID(int _id)
        {
            string Bank_Code = "";
            DataTable data = new DataTable();
            string query = @" SELECT [Bank_Code]
                              ,[Bank_Name]
                              FROM [SBP_Bank_Info]
                              WHERE [ID]=" + _id;
            try
            {
                _dbConnection.ConnectDatabase();
                data = _dbConnection.ExecuteQuery(query);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return data;
        }
        
        public DataTable GetBranchInfoByBranchID(int _id)
        {
            string Branch_Code = "";
            DataTable data = new DataTable();
            string query = @" SELECT [Branch_Code]
                              ,[Branch_Name]  
                              FROM [SBP_Branch_Info]
                              WHERE [ID]=" + _id;
            try
            {
                _dbConnection.ConnectDatabase();
                data = _dbConnection.ExecuteQuery(query);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
           
            return data;
        }
        public DataTable GetDistrictInfoByDistictID(int _id)
        {
            string District_Code = "";
            DataTable data = new DataTable();
            string query = @" SELECT [District_Code]
                              ,[District_Name]   
                              FROM [SBP_District_Info]
                              WHERE [ID]=" + _id;
            try
            {
                _dbConnection.ConnectDatabase();
                data = _dbConnection.ExecuteQuery(query);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            
            return data;
        }
        public DataTable GetThanaInfoByThanaID(int _id)
        {
            string Thana_Code = "";
            DataTable data = new DataTable();
            string query = @" SELECT [Thana_Code]
                              ,[Thana_Name]  
                              FROM [SBP_Thana_Info]
                              WHERE [ID]=" + _id;
            try
            {
                _dbConnection.ConnectDatabase();
                data = _dbConnection.ExecuteQuery(query);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
           
            return data;
        }
        public void SaveBankBranchRouting(Bank_Branch_RoutingBO objBO)
        {

            string QueryString = "";
            QueryString = @"INSERT INTO SBP_Bank_Branch_Routing_Info
                           (
                            [Bank_ID]
                           ,[Bank_Code]
                           ,[Bank_Name]
                           ,[Branch_ID]
                           ,[Branch_Code]
                           ,[Branch_Name]
                           ,[Routing_No]
                           ,[District_ID]
                           ,[District_Code]
                           ,[District_Name]
                           ,[Thana_ID]
                           ,[Thana_Code]
                           ,[Thana_Name]
                           ,[Entry_Date]
                           ,[Entry_by])
                     VALUES
                           ("
                            + objBO.Bank_Id
                           + ",'" + objBO.Bank_Code + "'"
                           + ",'" + objBO.Bank_Name + "'"
                           +","+objBO.Branch_Id
                           + ",'" + objBO.Branch_Code + "'"
                           + ",'" + objBO.Branch_Name + "'"
                           +",'"+objBO.RoutingNo +"'"
                           +","+objBO.District_Id
                           + ",'" + objBO.District_Code + "'"
                           + ",'" + objBO.District_Name + "'"
                           +","+objBO.Thana_Id
                           + ",'" + objBO.Thana_Code + "'"
                           + ",'" + objBO.Thana_Name + "'"
                           + ",(CAST(FLOOR(CAST(GETDATE() AS FLOAT)) AS DATETIME))"
                           + ",'" + GlobalVariableBO._userName + "'"                          
                          + ")";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(QueryString);
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
        public void UpdateBankBranchRoutingInfo(Bank_Branch_RoutingBO objBO, int _bankBranchRoutingId)
        {

            string QueryString = "";
            QueryString = @"UPDATE SBP_Bank_Branch_Routing_Info
                            SET
                            [Bank_ID]="+objBO.Bank_Id
                           +",[Bank_Code]='" + objBO.Bank_Code + "'"
                           +",[Bank_Name]='" + objBO.Bank_Name + "'"
                           +",[Branch_ID]="+objBO.Branch_Id
                           +",[Branch_Code]='" + objBO.Branch_Code + "'"
                           +",[Branch_Name]='" + objBO.Branch_Name + "'"
                           +",[Routing_No]='"+objBO.RoutingNo +"'"
                           +",[District_ID]="+objBO.District_Id
                           +",[District_Code]='" + objBO.District_Code + "'"
                           +",[District_Name]='" + objBO.District_Name + "'"
                           +",[Thana_ID]="+objBO.Thana_Id
                           +",[Thana_Code]='" + objBO.Thana_Code + "'"
                           +",[Thana_Name]='" + objBO.Thana_Name + "'"
                           + " WHERE ID=" + _bankBranchRoutingId;

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(QueryString);
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

        public void DeletebBankBranchRoutingInfo(int _bankBranchRoutingId)
        {
            string query = "DELETE FROM SBP_Bank_Branch_Routing_Info WHERE ID=" + _bankBranchRoutingId;
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
