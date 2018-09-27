using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Net;
using DataAccessLayer;
using System.Data.SqlClient;

namespace BusinessAccessLayer.BAL
{
    public enum FlexTpExportFileType {ClientRegistration,ClientLimit };
    public class FlexTpSyncBal
    {
        private DbConnection _dbConnection;

        public FlexTpSyncBal()
        {
            _dbConnection = new DbConnection();
        }

        public void ConnectDatabase()
        {
            _dbConnection.ConnectDatabase();
            _dbConnection.StartTransaction();
        }

        public void CloseDatabase()
        {
            _dbConnection.CloseDatabase();
        }

        public void Commit()
        {
            _dbConnection.Commit();
        }

        public void RollBack()
        {
            _dbConnection.Rollback();
        }

        public SqlTransaction GetTransaction()
        {
            return _dbConnection.GetTransaction();
        }

        public void SetTransaction(SqlTransaction trans)
        {
            _dbConnection.SetTransaction(trans);
        }

        public DbConnection GetConnection()
        {
            return _dbConnection;
        }
        public void SetConnection(DbConnection con)
        {

            _dbConnection = con;
        }

        public void RefillRecent_ClientRegistration()
        {
            string result = string.Empty;
            string quryString = "SBP_FlexTP_Refill_ClientRegistration";

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.ExecuteProQuery(quryString);
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

        public void RefillRecent_ClientRegistration_UITransApplied()
        {
            string result = string.Empty;
            string quryString = "SBP_FlexTP_Refill_LatestClintsLimit";

            try
            {
                //_dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.ExecuteProQuery(quryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                //_dbConnection.CloseDatabase();
            }

        }

        public void RefillRecent_ClientLimit()
        {
            string result = string.Empty;
            string quryString = "SBP_FlexTP_Refill_LatestClintsLimit";

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
               _dbConnection.ExecuteProQuery(quryString);
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

        public void RefillRecent_ClientLimit_UITransApplied()
        {
            string result = string.Empty;
            string quryString = "SBP_FlexTP_Refill_ClientRegistration";

            try
            {
               // _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.ExecuteProQuery(quryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
               // _dbConnection.CloseDatabase();
            }

        }
        
        public DataTable GetRecentClientRegistration()
        {
            DataTable dt = new DataTable();
            string result = string.Empty;
            string quryString = "Select * From SBP_FlexTP_ClientRegistration Where ISProcessed=0";

            try
            {
                _dbConnection.ConnectDatabase();
                dt=_dbConnection.ExecuteQuery(quryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }

            return dt;
        }

        public DataTable GetRecentClientRegistration_UITransApplied()
        {
            DataTable dt = new DataTable();
            string result = string.Empty;
            string quryString = @"SELECT [ID]
                              ,[Cust_Code]
                              ,(
                                CASE 
                                    WHEN ISNULL([Assigned_WorkStation],'')<>'' THEN [Assigned_WorkStation] 
                                    ELSE 'KSLTRDR002'
                                END
                              )AS Assigned_WorkStation
                              ,[Branch_ID]
                              ,'12023500'+[BOID] AS BOID
                              ,[WithNetAdjustment]
                              ,[Cust_Name]
                              ,[Short_Name]
                              ,[Address]
                              ,[Tel]
                              ,[ICNo]
                              ,[AccountType]
                              ,[ShortSellingAllowed]
                              ,[ProcessingMode]
                              ,[RcVersion_Cust]
                              ,[RcVersion_Add]
                              ,[RcVersion_Per]
                              ,[RcVersion_Cont]
                              ,[RcVersionDate]
                              ,[ISProcessed]
                              ,[Process_ID]
                              ,[ProcessedDate]
                          FROM [SBP_FlexTP_ClientRegistration] Where ISProcessed=0";

            try
            {
                //_dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(quryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                //_dbConnection.CloseDatabase();
            }

            return dt;
        }

        public DataTable GetRecentClientLimit()
        {
            DataTable dt = new DataTable();

            string result = string.Empty;
            string quryString = "SBP_FlexTP_GetLatesClientLimit";

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                dt=_dbConnection.ExecuteQuery(quryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }

            return dt;
        }

        public DataTable GetRecentClientLimit_UITransApplied()
        {
            DataTable dt = new DataTable();

            string result = string.Empty;
            string quryString = @"SBP_FlexTP_GetLatesClientLimit";

            try
            {
               // _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                dt = _dbConnection.ExecuteQuery(quryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                //_dbConnection.CloseDatabase();
            }

            return dt;
        }

        public void UpdateFtpTransferInformation_ClientRegistration_UITransApplied(string FileName, FlexTpExportFileType FileType, DataTable dt)        
        {
            string result = string.Empty;
            int NewId = 0;

            try
            {
                //_dbConnection.ConnectDatabase();
                
                string quryString_Insert_ProcessRecord =
                    @"  INSERT INTO [SBP_Database].[dbo].[SBP_FlexTP_ExportInfo]
                       (
                            [FileName]
                           ,[FileType]
                           ,[IsExported]
                           ,[ExportDate]
                       )
                       VALUES 
                       (
                              '"+FileName+@"'
                              ,'" + FileType.ToString() + @"'
                              ,1
                              ,GETDATE()
                       ) 
                       Select Scope_Identity()     
                    ";
               DataTable newId_dt=_dbConnection.ExecuteQuery(quryString_Insert_ProcessRecord);
               if (newId_dt.Rows.Count > 0)
                   NewId = Convert.ToInt32(newId_dt.Rows[0][0].ToString());

                
                foreach (DataRow dr in dt.Rows)
                {
                    string quryString_Update_Record = 
                    @"  
                        UPDATE [SBP_FlexTP_ClientRegistration]
                        SET [ISProcessed]=1,[Process_ID]="+NewId+@",[ProcessedDate]=GETDATE()
                        WHERE ID="+dr["ID"].ToString()+@"
                    ";
                    _dbConnection.ExecuteNonQuery(quryString_Update_Record);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                //_dbConnection.CloseDatabase();
            } 
        }


        public void UpdateFtpTransferInformation_ClientLimit_UITransApplied(string FileName, FlexTpExportFileType FileType, DataTable dt)
        {
            string result = string.Empty;
            int NewId = 0;

            try
            {
                //_dbConnection.ConnectDatabase();

                string quryString_Insert_ProcessRecord =
                    @"  INSERT INTO [SBP_Database].[dbo].[SBP_FlexTP_ExportInfo]
                       (
                            [FileName]
                           ,[FileType]
                           ,[IsExported]
                           ,[ExportDate]
                       )
                       VALUES 
                       (
                              '" + FileName + @"'
                              ,'" + FileType.ToString() + @"'
                              ,1
                              ,GETDATE()
                       ) 
                       Select Scope_Identity()     
                    ";
                DataTable newId_dt = _dbConnection.ExecuteQuery(quryString_Insert_ProcessRecord);
                if (newId_dt.Rows.Count > 0)
                    NewId = Convert.ToInt32(newId_dt.Rows[0][0].ToString());


                foreach (DataRow dr in dt.Rows)
                {
                    string quryString_Update_Record =
                    @"  
                        UPDATE [SBP_FlexTP_ClientLimit]
                        SET [ISProcessed]=1,[Process_ID]=" + NewId + @",[ProcesssedDate]=GETDATE()
                        WHERE Cust_Code='" + dr["Cust_Code"].ToString() + @"' AND [ISProcessed]=0
                    ";
                    _dbConnection.ExecuteNonQuery(quryString_Update_Record);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                //_dbConnection.CloseDatabase();
            }
        }
    }
}
