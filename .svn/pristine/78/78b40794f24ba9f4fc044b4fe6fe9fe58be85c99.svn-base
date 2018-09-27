using System;
using System.Data;
using BusinessAccessLayer.BO;
using DataAccessLayer;

namespace BusinessAccessLayer.BAL
{
    public class CompanyBAL
    {
        private DbConnection _dbConnection;
        public CompanyBAL()
        {
            _dbConnection = new DbConnection();
        }

        /// <summary>
        /// Edit By Rashedul Hasan on july 29 2015
        /// Add IsMargin Column
        /// </summary>
        /// <param name="companyShortCode"></param>
        /// <returns></returns>
        public void Insert(CompanyBO companyBo)
        {
            string companyQueryString = "";
            companyQueryString = @"SBPSaveCompany";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@CompanyShortCode", SqlDbType.NVarChar, companyBo.CompanyShortCode);
                _dbConnection.AddParameter("@CompanyName", SqlDbType.NVarChar, companyBo.CompanyName);
                _dbConnection.AddParameter("@CompanyCategoryID", SqlDbType.Int, companyBo.CompanyCategoryID);
                _dbConnection.AddParameter("@FaceValue", SqlDbType.Float, companyBo.FaceValue);
                _dbConnection.AddParameter("@MarketLot", SqlDbType.Decimal, companyBo.MarketLot);
                _dbConnection.AddParameter("@ShareType", SqlDbType.VarChar, companyBo.ShareType);
                _dbConnection.AddParameter("@IssuerId", SqlDbType.Decimal, companyBo.IssuerId);
                _dbConnection.AddParameter("@ISINNo", SqlDbType.NVarChar, companyBo.ISINNo);
                _dbConnection.AddParameter("@Remarks ", SqlDbType.NVarChar, companyBo.Remarks);
                _dbConnection.AddParameter("@status ", SqlDbType.Int, companyBo.CompanyStatus);
                _dbConnection.AddParameter("@OpeningDate",SqlDbType.DateTime,companyBo.OpeningDate);
                _dbConnection.AddParameter("@entryBy", SqlDbType.VarChar, GlobalVariableBO._userName);
                _dbConnection.AddParameter("@SectorID", SqlDbType.Int, companyBo.CompanySectorID);
                _dbConnection.AddParameter("@CodeNo",SqlDbType.VarChar,companyBo.CompanyShortNumber);
                _dbConnection.AddParameter("@IsMargin", SqlDbType.Bit, companyBo.IsMargin);
                _dbConnection.ExecuteNonQuery(companyQueryString);
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


        public void Insert_Dealer_Company()
        {
            string companyQueryString = "";
            companyQueryString = @"Dealer_Company";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();             
                _dbConnection.ExecuteNonQuery(companyQueryString);
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

        /// <summary>
        /// Edit By Rashedul Hasan on july 29 2015
        /// Add IsMargin Column
        /// </summary>
        /// <param name="companyShortCode"></param>
        /// <returns></returns>
        /// 

        public void UpdateMargin(string short_code, bool isMargin)
        {

            string queryString = "";
            queryString = @"Update SBP_Company set IsMargin='" + isMargin + "' where Comp_Short_Code='" + short_code + "'";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(queryString);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public DataTable GetAllData()
        {
            DataTable dataTable;
            string queryString = "";
            queryString = @"SELECT Comp_Name,com.Comp_Short_Code,cat.Comp_Category As Category_Name
                            ,ISIN_No
                            ,(SELECT SectorName FROM dbo.SBP_Comp_Sector WHERE dbo.SBP_Comp_Sector.Sector_ID=com.Sector_ID) AS Sector_ID
                            
                            ,(case when IsMargin=1 Then 'Margin' 
			                            When IsMargin=0 Then 'Non_Margin'
			                            Else '' END )As Margin
                            ,IsMargin
	                            
                            FROM SBP_Company As com
                            Join SBP_Comp_Category As cat
                            on com.Comp_Cat_ID=cat.Comp_Cat_ID";
            try
            {
                _dbConnection.ConnectDatabase();
                dataTable = _dbConnection.ExecuteQuery(queryString);
            }
            catch (Exception)
            {
                throw;
            }
            return dataTable;
        }
        public DataTable GetAllData(string companyShortCode)
        {
            DataTable dataTable;
            string queryString = "";
            queryString = "SELECT Comp_Name,Comp_Cat_ID,Face_Value,Market_Lot,Share_Type,Issuer_ID,ISIN_No,Opening_Date,Remarks,(SELECT SectorName FROM dbo.SBP_Comp_Sector WHERE dbo.SBP_Comp_Sector.Sector_ID=dbo.SBP_Company.Sector_ID) AS Sector_ID,Code_No,IsMargin FROM SBP_Company WHERE Comp_Short_Code='" + companyShortCode + "'";
            try
            {
                _dbConnection.ConnectDatabase();
                dataTable = _dbConnection.ExecuteQuery(queryString);
            }
            catch (Exception)
            {
                throw;
            }
            return dataTable;
        }
        //public DataTable GetAllData(string companyShortCode)
        //{
        //    DataTable dataTable;
        //    string queryString = "";
        //    queryString = "SELECT Comp_Name,Comp_Cat_ID,Face_Value,Market_Lot,Share_Type,Issuer_ID,ISIN_No,Opening_Date,Remarks,(SELECT SectorName FROM dbo.SBP_Comp_Sector WHERE dbo.SBP_Comp_Sector.Sector_ID=dbo.SBP_Company.Sector_ID) AS Sector_ID,Code_No FROM SBP_Company WHERE Comp_Short_Code='" + companyShortCode + "'"; 
        //    try
        //    {
        //        _dbConnection.ConnectDatabase();
        //        dataTable = _dbConnection.ExecuteQuery(queryString);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    return dataTable;
        //}
        /// <summary>
        /// Edit By Md Rashedul hasan
        /// Add Ismargin Column
        /// july 29 2015
        /// </summary>
        /// <param name="companyBo"></param>
        public void Update(CompanyBO companyBo)
        {
            string companyQueryString = "";
            companyQueryString = @"SBPUpdateCompany";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@CompanyShortCode", SqlDbType.NVarChar, companyBo.CompanyShortCode);
                _dbConnection.AddParameter("@CompanyName", SqlDbType.NVarChar, companyBo.CompanyName);
                _dbConnection.AddParameter("@CompanyCategoryID", SqlDbType.Int, companyBo.CompanyCategoryID);
                _dbConnection.AddParameter("@FaceValue", SqlDbType.Float, companyBo.FaceValue);
                _dbConnection.AddParameter("@MarketLot", SqlDbType.Int, companyBo.MarketLot);
                _dbConnection.AddParameter("@ShareType", SqlDbType.VarChar, companyBo.ShareType);
                _dbConnection.AddParameter("@IssuerId", SqlDbType.Int, companyBo.IssuerId);
                _dbConnection.AddParameter("@ISINNo", SqlDbType.NVarChar, companyBo.ISINNo);
                _dbConnection.AddParameter("@Remarks ", SqlDbType.NVarChar, companyBo.Remarks);
                _dbConnection.AddParameter("@status ", SqlDbType.Int, companyBo.CompanyStatus);
                _dbConnection.AddParameter("@OpeningDate", SqlDbType.DateTime, companyBo.OpeningDate);
                _dbConnection.AddParameter("@entryBy", SqlDbType.VarChar, GlobalVariableBO._userName);
                _dbConnection.AddParameter("@SectorID",SqlDbType.Int,companyBo.CompanySectorID);
                _dbConnection.AddParameter("@CodeNo",SqlDbType.VarChar,companyBo.CompanyShortNumber);
                _dbConnection.AddParameter("@IsMargin", SqlDbType.Bit, companyBo.IsMargin);
                _dbConnection.ExecuteProQuery(companyQueryString);
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

        public DataTable GetCDBLCompany()
        {
            DataTable dataTable;
            string queryString = "";
            queryString = "SELECT Comp_Short_Code FROM SBP_Company WHERE Share_Type='CDBL'";
            try
            {
                _dbConnection.ConnectDatabase();
                dataTable = _dbConnection.ExecuteQuery(queryString);
            }
            catch (Exception)
            {
                throw;
            }
            return dataTable;

            
        }
        public DataTable GetNonCDBLCompany()
        {
            DataTable dataTable;
            string queryString = "";
            queryString = "SELECT Comp_Short_Code FROM SBP_Company WHERE Share_Type='Non-CDBL'";
            try
            {
                _dbConnection.ConnectDatabase();
                dataTable = _dbConnection.ExecuteQuery(queryString);
            }
            catch (Exception)
            {
                throw;
            }
            return dataTable;


        }



        public void ConvertNonCDBLToCDBL(object companyName)
        {
            string companyQueryString = "";
            companyQueryString = @"SBPConvertNonCDBLToCDBL";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@CompanyShortCode",SqlDbType.NVarChar, companyName);
                _dbConnection.AddParameter("@entryBy", SqlDbType.VarChar, GlobalVariableBO._userName);
                _dbConnection.ExecuteNonQuery(companyQueryString);
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
        public void ConvertCDBLToNonCDBL(object companyName)
        {
            string companyQueryString = "";
            companyQueryString = @"SBPConvertCDBLToNonCDBL";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@CompanyShortCode", SqlDbType.NVarChar, companyName);
                _dbConnection.AddParameter("@entryBy", SqlDbType.VarChar, GlobalVariableBO._userName);
                _dbConnection.ExecuteNonQuery(companyQueryString);
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

        public DataTable GetOldCategory(string companyShortName)
        {
            DataTable dataTable;
            string queryString = "";
            queryString = "SELECT SBP_Company.Comp_Cat_ID,Comp_Category FROM SBP_Company,SBP_Comp_Category WHERE Comp_Short_Code='" + companyShortName + "' AND SBP_Company.Comp_Cat_ID=SBP_Comp_Category.Comp_Cat_ID";
            try
            {
                _dbConnection.ConnectDatabase();
                dataTable = _dbConnection.ExecuteQuery(queryString);
            }
            catch (Exception)
            {
                throw;
            }
            return dataTable;
            
        }

        public bool CheckCompanyDuplicate(string companyShortCode)
        {
            DataTable dataTable;
            string queryString = "";
            queryString = "SELECT Comp_Short_Code FROM SBP_Company WHERE Comp_Short_Code='" + companyShortCode + "'";
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

        //////////// ************ BY DAS && Aditra ************////////////////

        public DataTable GetCompanyShortCodeList()
        {
            DataTable dtCompnyShortCodeList = new DataTable();
            string queryString = "SELECT Comp_Short_Code,ISIN_No FROM SBP_Company ORDER BY Comp_Short_Code ASC";

            try
            {
                _dbConnection.ConnectDatabase();
                dtCompnyShortCodeList = _dbConnection.ExecuteQuery(queryString);
            }
            catch (Exception)
            {
                throw;
            }

            finally
            {
                _dbConnection.CloseDatabase();
            }

            return dtCompnyShortCodeList;
        
        }

        public string GetComponyISINNo(string companyShortCode)
        {
            string CompanyISNONO = "";
            DataTable dataTable = new DataTable();
            string queryString = "SELECT ISIN_No FROM SBP_Company WHERE Comp_Short_Code='" + companyShortCode + "'";

            try
            {
                _dbConnection.ConnectDatabase();
                dataTable = _dbConnection.ExecuteQuery(queryString);

                if (dataTable.Rows.Count > 0)
                {
                    companyShortCode = dataTable.Rows[0]["ISIN_No"].ToString();
                }

                else
                {
                    companyShortCode = "";
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

            return CompanyISNONO;
        }

        public string GetHeadofficeInfo()
        {
            string queryString = "SELECT Branch_Name,Address,Telephone,Fax FROM SBP_Broker_Branch";
            string Info = "";
            DataTable data = new DataTable();

            try
            {
                _dbConnection.ConnectDatabase();
                data = _dbConnection.ExecuteQuery(queryString);

                if (data.Rows.Count > 0)
                {
                    Info = data.Rows[0][0].ToString() + "," + data.Rows[0][1].ToString() + ", Telephone: " + data.Rows[0][2].ToString() + ", Fax: " + data.Rows[0][3].ToString();
                }

                else
                {
                    Info = "";
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

            return Info;
        
        }

        public string GetCompanyName(string CompanyShortCode)
        {
            string queryString = "SELECT Comp_Name FROM dbo.SBP_Company WHERE Comp_Short_Code='"+CompanyShortCode+"'";
            DataTable data=new DataTable();
            string CompanyShortName = "";

            try
            {
                _dbConnection.ConnectDatabase();
                data = _dbConnection.ExecuteQuery(queryString);
                CompanyShortName = data.Rows[0][0].ToString();

            }
            catch (Exception)
            {
                
                throw;
            }

            finally
            {
                _dbConnection.CloseDatabase();
            }

            return CompanyShortName;
        }

        public void ChangeCompanyShortCode(string CompanyShortCode,string CompannyName,string OldCompanyShortName,string OldCompanyName)
        {
            string queryString = "ChangeCompanyShortCode";

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@CompanyShortCode",SqlDbType.VarChar,CompanyShortCode);
                _dbConnection.AddParameter("@CompanyName",SqlDbType.VarChar,CompannyName);
                _dbConnection.AddParameter("@OldCompanyShortName", SqlDbType.VarChar,OldCompanyShortName);
                _dbConnection.AddParameter("@OldCompanyName", SqlDbType.VarChar, OldCompanyName);
                _dbConnection.AddParameter("@EntryBy", SqlDbType.VarChar,GlobalVariableBO._userName);
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
