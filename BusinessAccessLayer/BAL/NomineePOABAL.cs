using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessAccessLayer.BO;
using DataAccessLayer;

namespace BusinessAccessLayer.BAL
{
    public class NomineePOABAL
    {
        private DbConnection _dbConnection;
        public NomineePOABAL()
        {
            _dbConnection = new DbConnection();
        }

        public void Insert(string customerCode, Nominee1InfoBO nominee1Bo, Nominee2InfoBO nominee2Bo, Guardian1InfoBO guardian1Bo, Guardian2InfoBO guardian2Bo, PowerOfAttorneyInfoBO poaBO)
        {
            string nom1QueryString = "";
            string nom2QueryString = "";
            string guar1QueryString = "";
            string guar2QueryString = "";
            string poaQueryString = "";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();

                nom1QueryString = @"SBPSaveNominee1Info";
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@CustCode", SqlDbType.NVarChar,customerCode);
                _dbConnection.AddParameter("@Nominee1Name", SqlDbType.VarChar, nominee1Bo.Nominee1Name);
                _dbConnection.AddParameter("@Nominee1Dob", SqlDbType.DateTime,nominee1Bo.Nominee1Dob);
                _dbConnection.AddParameter("@Nominee1Nationality", SqlDbType.NVarChar,nominee1Bo.Nominee1Nationality);
                _dbConnection.AddParameter("@Nominee1Address", SqlDbType.VarChar, nominee1Bo.Nominee1Address);
                _dbConnection.AddParameter("@Nominee1City", SqlDbType.NVarChar, nominee1Bo.Nominee1City);
                _dbConnection.AddParameter("@Nominee1PostCode", SqlDbType.NVarChar,nominee1Bo.Nominee1PostCode);
                _dbConnection.AddParameter("@Nominee1Division", SqlDbType.NVarChar,nominee1Bo.Nominee1Division);
                _dbConnection.AddParameter("@Nominee1Country", SqlDbType.NVarChar,nominee1Bo.Nominee1Country );
                _dbConnection.AddParameter("@Nominee1Telephone", SqlDbType.NVarChar,  nominee1Bo.Nominee1Telephone);
                _dbConnection.AddParameter("@Nominee1Mobile", SqlDbType.NVarChar,nominee1Bo.Nominee1Mobile);
                _dbConnection.AddParameter("@Nominee1Fax", SqlDbType.NVarChar,  nominee1Bo.Nominee1Fax);
                _dbConnection.AddParameter("@Nominee1Email", SqlDbType.NVarChar,nominee1Bo.Nominee1Email );
                _dbConnection.AddParameter("@Nominee1PassportNo", SqlDbType.NVarChar,nominee1Bo.Nominee1PassportNo );
                _dbConnection.AddParameter("@Nominee1IssuePlace", SqlDbType.NVarChar,nominee1Bo.Nominee1IssuePlace);
                _dbConnection.AddParameter("@Nominee1IssueDate", SqlDbType.DateTime, nominee1Bo.Nominee1IssueDate);
                _dbConnection.AddParameter("@Nominee1ExpireDate", SqlDbType.DateTime,nominee1Bo.Nominee1ExpireDate);
                _dbConnection.AddParameter("@Nominee1Residency", SqlDbType.NVarChar,nominee1Bo.Nominee1Residency);
                _dbConnection.AddParameter("@Nominee1Relation", SqlDbType.NVarChar,nominee1Bo.Nominee1Relation);
                _dbConnection.AddParameter("@Nominee1Percentage", SqlDbType.Float, nominee1Bo.Nominee1Percentage);
                _dbConnection.AddParameter("@Nominee1NationalId", SqlDbType.NVarChar,nominee1Bo.Nominee1NationalId);
                _dbConnection.AddParameter("@entryBy", SqlDbType.VarChar, GlobalVariableBO._userName);
                _dbConnection.ExecuteNonQuery(nom1QueryString);



                 nom2QueryString = @"SBPSaveNominee2Info";
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@CustCode", SqlDbType.NVarChar,customerCode);
                _dbConnection.AddParameter("@Nominee2Name", SqlDbType.VarChar, nominee2Bo.Nominee2Name);
                _dbConnection.AddParameter("@Nominee2Dob", SqlDbType.DateTime,nominee2Bo.Nominee2Dob);
                _dbConnection.AddParameter("@Nominee2Nationality", SqlDbType.NVarChar,nominee2Bo.Nominee2Nationality);
                _dbConnection.AddParameter("@Nominee2Address", SqlDbType.VarChar, nominee2Bo.Nominee2Address);
                _dbConnection.AddParameter("@Nominee2City", SqlDbType.NVarChar, nominee2Bo.Nominee2City);
                _dbConnection.AddParameter("@Nominee2PostCode", SqlDbType.NVarChar,nominee2Bo.Nominee2PostCode);
                _dbConnection.AddParameter("@Nominee2Division", SqlDbType.NVarChar,nominee2Bo.Nominee2Division);
                _dbConnection.AddParameter("@Nominee2Country", SqlDbType.NVarChar,nominee2Bo.Nominee2Country );
                _dbConnection.AddParameter("@Nominee2Telephone", SqlDbType.NVarChar,  nominee2Bo.Nominee2Telephone);
                _dbConnection.AddParameter("@Nominee2Mobile", SqlDbType.NVarChar,nominee2Bo.Nominee2Mobile);
                _dbConnection.AddParameter("@Nominee2Fax", SqlDbType.NVarChar,  nominee2Bo.Nominee2Fax);
                _dbConnection.AddParameter("@Nominee2Email", SqlDbType.NVarChar,nominee2Bo.Nominee2Email );
                _dbConnection.AddParameter("@Nominee2PassportNo", SqlDbType.NVarChar,nominee2Bo.Nominee2PassportNo );
                _dbConnection.AddParameter("@Nominee2IssuePlace", SqlDbType.NVarChar,nominee2Bo.Nominee2IssuePlace);
                _dbConnection.AddParameter("@Nominee2IssueDate", SqlDbType.DateTime, nominee2Bo.Nominee2IssueDate);
                _dbConnection.AddParameter("@Nominee2ExpireDate", SqlDbType.DateTime,nominee2Bo.Nominee2ExpireDate);
                _dbConnection.AddParameter("@Nominee2Residency", SqlDbType.NVarChar,nominee2Bo.Nominee2Residency);
                _dbConnection.AddParameter("@Nominee2Relation", SqlDbType.NVarChar,nominee2Bo.Nominee2Relation);
                _dbConnection.AddParameter("@Nominee2Percentage", SqlDbType.Float, nominee2Bo.Nominee2Percentage);
                _dbConnection.AddParameter("@Nominee2NationalId", SqlDbType.NVarChar, nominee2Bo.Nominee2NationalId);
                _dbConnection.AddParameter("@entryBy", SqlDbType.VarChar, GlobalVariableBO._userName);
                _dbConnection.ExecuteNonQuery(nom2QueryString);

                
                guar1QueryString = @"SBPSaveGuardian1Info"; 
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@CustCode", SqlDbType.NVarChar,customerCode);
                _dbConnection.AddParameter("@Guardian1Name", SqlDbType.VarChar, guardian1Bo.Guardian1Name );
                _dbConnection.AddParameter("@Guardian1DOB", SqlDbType.DateTime, guardian1Bo.Guardian1DOB.ToShortDateString());
                _dbConnection.AddParameter("@Guardian1Nationality", SqlDbType.NVarChar,guardian1Bo.Guardian1Nationality);
                _dbConnection.AddParameter("@Guardian1Address", SqlDbType.VarChar, guardian1Bo.Guardian1Address );
                _dbConnection.AddParameter("@Guardian1City", SqlDbType.NVarChar, guardian1Bo.Guardian1City);
                _dbConnection.AddParameter("@Guardian1PostCode", SqlDbType.NVarChar,guardian1Bo.Guardian1PostCode);
                _dbConnection.AddParameter("@Guardian1Division", SqlDbType.NVarChar, guardian1Bo.Guardian1Division );
                _dbConnection.AddParameter("@Guardian1Country", SqlDbType.NVarChar, guardian1Bo.Guardian1Country);
                _dbConnection.AddParameter("@Guardian1Telephone", SqlDbType.NVarChar,guardian1Bo.Guardian1Telephone);
                _dbConnection.AddParameter("@Guardian1Mobile", SqlDbType.NVarChar,guardian1Bo.Guardian1Mobile);
                _dbConnection.AddParameter("@Guardian1Fax", SqlDbType.NVarChar, guardian1Bo.Guardian1Fax);
                _dbConnection.AddParameter("@Guardian1Email", SqlDbType.NVarChar,guardian1Bo.Guardian1Email);
                _dbConnection.AddParameter("@Guardian1PassportNo", SqlDbType.NVarChar, guardian1Bo.Guardian1PassportNo);
                _dbConnection.AddParameter("@Guardian1IssuePlace", SqlDbType.NVarChar,guardian1Bo.Guardian1IssuePlace);
                _dbConnection.AddParameter("@Guardian1IssueDate", SqlDbType.DateTime,  guardian1Bo.Guardian1IssueDate.ToShortDateString());
                _dbConnection.AddParameter("@Guardian1ExpireDate", SqlDbType.DateTime,guardian1Bo.Guardian1ExpireDate.ToShortDateString());
                _dbConnection.AddParameter("@Guardian1Residency", SqlDbType.NVarChar,guardian1Bo.Guardian1Residency);
                _dbConnection.AddParameter("@Guardian1Relation", SqlDbType.NVarChar,guardian1Bo.Guardian1Relation);
                _dbConnection.AddParameter("@Guardian1DoBofMinor", SqlDbType.DateTime, guardian1Bo.Guardian1DoBofMinor.ToShortDateString());
                _dbConnection.AddParameter("@Guardian1MaturityDateMinor", SqlDbType.DateTime,guardian1Bo.Guardian1MaturityDateMinor.ToShortDateString());
                _dbConnection.AddParameter("@entryBy", SqlDbType.VarChar, GlobalVariableBO._userName);
                _dbConnection.ExecuteNonQuery(guar1QueryString);
                
                guar2QueryString = @"SBPSaveGuardian2Info"; 
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@CustCode", SqlDbType.NVarChar,customerCode);
                _dbConnection.AddParameter("@Guardian2Name", SqlDbType.VarChar, guardian2Bo.Guardian2Name );
                _dbConnection.AddParameter("@Guardian2DOB", SqlDbType.DateTime, guardian2Bo.Guardian2DOB.ToShortDateString());
                _dbConnection.AddParameter("@Guardian2Nationality", SqlDbType.NVarChar,guardian2Bo.Guardian2Nationality);
                _dbConnection.AddParameter("@Guardian2Address", SqlDbType.VarChar, guardian2Bo.Guardian2Address );
                _dbConnection.AddParameter("@Guardian2City", SqlDbType.NVarChar, guardian2Bo.Guardian2City);
                _dbConnection.AddParameter("@Guardian2PostCode", SqlDbType.NVarChar,guardian2Bo.Guardian2PostCode);
                _dbConnection.AddParameter("@Guardian2Division", SqlDbType.NVarChar, guardian2Bo.Guardian2Division );
                _dbConnection.AddParameter("@Guardian2Country", SqlDbType.NVarChar, guardian2Bo.Guardian2Country);
                _dbConnection.AddParameter("@Guardian2Telephone", SqlDbType.NVarChar,guardian2Bo.Guardian2Telephone);
                _dbConnection.AddParameter("@Guardian2Mobile", SqlDbType.NVarChar,guardian2Bo.Guardian2Mobile);
                _dbConnection.AddParameter("@Guardian2Fax", SqlDbType.NVarChar, guardian2Bo.Guardian2Fax);
                _dbConnection.AddParameter("@Guardian2Email", SqlDbType.NVarChar,guardian2Bo.Guardian2Email);
                _dbConnection.AddParameter("@Guardian2PassportNo", SqlDbType.NVarChar, guardian2Bo.Guardian2PassportNo);
                _dbConnection.AddParameter("@Guardian2IssuePlace", SqlDbType.NVarChar,guardian2Bo.Guardian2IssuePlace);
                _dbConnection.AddParameter("@Guardian2IssueDate", SqlDbType.DateTime,  guardian2Bo.Guardian2IssueDate.ToShortDateString());
                _dbConnection.AddParameter("@Guardian2ExpireDate", SqlDbType.DateTime,guardian2Bo.Guardian2ExpireDate.ToShortDateString());
                _dbConnection.AddParameter("@Guardian2Residency", SqlDbType.NVarChar,guardian2Bo.Guardian2Residency);
                _dbConnection.AddParameter("@Guardian2Relation", SqlDbType.NVarChar,guardian2Bo.Guardian2Relation);
                _dbConnection.AddParameter("@Guardian2DoBofMinor", SqlDbType.DateTime, guardian2Bo.Guardian2DoBofMinor.ToShortDateString());
                _dbConnection.AddParameter("@Guardian2MaturityDateMinor", SqlDbType.DateTime,guardian2Bo.Guardian2MaturityDateMinor.ToShortDateString());
                _dbConnection.AddParameter("@entryBy", SqlDbType.VarChar, GlobalVariableBO._userName);
                _dbConnection.ExecuteNonQuery(guar2QueryString);


                poaQueryString = @"SBPSavePOAInfo";
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@CustCode", SqlDbType.NVarChar,customerCode);
                _dbConnection.AddParameter("@POAName", SqlDbType.VarChar, poaBO.POAName);
                _dbConnection.AddParameter("@POADob", SqlDbType.DateTime, poaBO.POADob.ToShortDateString());
                _dbConnection.AddParameter("@POANationality", SqlDbType.NVarChar,poaBO.POANationality);
                _dbConnection.AddParameter("@POAAddress", SqlDbType.VarChar, poaBO.POAAddress);
                _dbConnection.AddParameter("@POACity", SqlDbType.NVarChar, poaBO.POACity);
                _dbConnection.AddParameter("@POAPostCode", SqlDbType.NVarChar,poaBO.POAPostCode);
                _dbConnection.AddParameter("@POADivision", SqlDbType.NVarChar, poaBO.POADivision);
                _dbConnection.AddParameter("@POACountry", SqlDbType.NVarChar, poaBO.POACountry);
                _dbConnection.AddParameter("@POATelephone", SqlDbType.NVarChar,poaBO.POATelephone);
                _dbConnection.AddParameter("@POAMobile", SqlDbType.NVarChar, poaBO.POAMobile);
                _dbConnection.AddParameter("@POAFax", SqlDbType.NVarChar, poaBO.POAFax);
                _dbConnection.AddParameter("@POAEmail", SqlDbType.NVarChar,poaBO.POAEmail);
                _dbConnection.AddParameter("@POAPassportNo", SqlDbType.NVarChar, poaBO.POAPassportNo);
                _dbConnection.AddParameter("@POAIssuePlace", SqlDbType.NVarChar,poaBO.POAIssuePlace);
                _dbConnection.AddParameter("@POAIssueDate", SqlDbType.DateTime,  poaBO.POAIssueDate.ToShortDateString());
                _dbConnection.AddParameter("@POAExpireDate", SqlDbType.DateTime,poaBO.POAExpireDate.ToShortDateString());
                _dbConnection.AddParameter("@POAResidency", SqlDbType.NVarChar,poaBO.POAResidency);
                _dbConnection.AddParameter("@POAEffectiveFrom", SqlDbType.DateTime,poaBO.POAEffectiveFrom.ToShortDateString());
                _dbConnection.AddParameter("@POAEffectiveTo", SqlDbType.DateTime,poaBO.POAEffectiveTo.ToShortDateString());
                _dbConnection.AddParameter("@POARemarks", SqlDbType.VarChar,poaBO.POARemarks);
                _dbConnection.AddParameter("@entryBy", SqlDbType.VarChar, GlobalVariableBO._userName);
                _dbConnection.ExecuteNonQuery(poaQueryString);
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

        public DataTable GetAllData(string custCode)
        {
            DataTable dataTable;
            string queryString = "";
            queryString ="SELECT SBP_Nominee1.Name AS n1Name,SBP_Nominee1.Address as n1Address,SBP_Nominee1.City as n1City,SBP_Nominee1.Division as n1Division,SBP_Nominee1.Country as n1Country,SBP_Nominee1.Post_Code as n1PostCode,SBP_Nominee1.Phone as n1Phone,SBP_Nominee1.Mobile as n1Mobile,SBP_Nominee1.Fax as n1Fax,SBP_Nominee1.Email as n1Email,SBP_Nominee1.DOb as n1DOB,SBP_Nominee1.Nationality as n1Nationality,SBP_Nominee1.Residency as n1Residency,SBP_Nominee1.Passport_No as n1PassNo,SBP_Nominee1.Issue_Date as n1IssueDate,SBP_Nominee1.Expire_Date as n1Expire,SBP_Nominee1.Issue_Place as n1IssuePlace,SBP_Nominee1.Relationship as n1Relation,SBP_Nominee1.Percentage as n1Percentage,SBP_Nominee1.National_ID as n1NationalID," +
                "SBP_Nominee2.Name AS n2Name,SBP_Nominee2.Address as n2Address,SBP_Nominee2.City as n2City,SBP_Nominee2.Division as n2Division,SBP_Nominee2.Country as n2Country,SBP_Nominee2.Post_Code as n2PostCode,SBP_Nominee2.Phone as n2Phone,SBP_Nominee2.Mobile as n2Mobile,SBP_Nominee2.Fax as n2Fax,SBP_Nominee2.Email as n2Email,SBP_Nominee2.DOb as n2DOB,SBP_Nominee2.Nationality as n2Nationality,SBP_Nominee2.Residency as n2Residency,SBP_Nominee2.Passport_No as n2PassNo,SBP_Nominee2.Issue_Date as n2IssueDate,SBP_Nominee2.Expire_Date as n2Expire,SBP_Nominee2.Issue_Place as n2IssuePlace,SBP_Nominee2.Relationship as n2Relation,SBP_Nominee2.Percentage as n2Percentage,SBP_Nominee2.National_ID as n2NationalID," +
                "SBP_Guardian1.Name as g1Name,SBP_Guardian1.Address as g1Address,SBP_Guardian1.City as g1City,SBP_Guardian1.Division as g1Division,SBP_Guardian1.Country as g1Country,SBP_Guardian1.Post_Code as g1PostCode,SBP_Guardian1.Phone as g1Phone,SBP_Guardian1.Mobile as g1Mobile,SBP_Guardian1.Fax as g1Fax,SBP_Guardian1.Email as g1Email,SBP_Guardian1.DOB as g1DOB,SBP_Guardian1.Nationality as g1Nationality,SBP_Guardian1.Residency as g1Residency,SBP_Guardian1.Passport_No as g1PassNo,SBP_Guardian1.Issue_Date as g1IssueDate,SBP_Guardian1.Expire_Date as g1Expire,SBP_Guardian1.Issue_Place as g1IssuePlace,SBP_Guardian1.Relationship as g1Relation,SBP_Guardian1.Minor_Date as g1Minor,SBP_Guardian1.Maturity_Date as g1Mature," +
                "SBP_Guardian2.Name as g2Name,SBP_Guardian2.Address as g2Address,SBP_Guardian2.City as g2City,SBP_Guardian2.Division as g2Division,SBP_Guardian2.Country as g2Country,SBP_Guardian2.Post_Code as g2PostCode,SBP_Guardian2.Phone as g2Phone,SBP_Guardian2.Mobile as g2Mobile,SBP_Guardian2.Fax as g2Fax,SBP_Guardian2.Email as g2Email,SBP_Guardian2.DOB as g2DOB,SBP_Guardian2.Nationality as g2Nationality,SBP_Guardian2.Residency as g2Residency,SBP_Guardian2.Passport_No as g2PassNo,SBP_Guardian2.Issue_Date as g2IssueDate,SBP_Guardian2.Expire_Date as g2Expire,SBP_Guardian2.Issue_Place as g2IssuePlace,SBP_Guardian2.Relationship as g2Relation,SBP_Guardian2.Minor_Date as g2Minor,SBP_Guardian2.Maturity_Date as g2Mature," +
                "SBP_POA.Name as pName,SBP_POA.Address as pAddress,SBP_POA.City as pCity,SBP_POA.Division as pDivision,SBP_POA.Country as pCountry,SBP_POA.Post_Code as pPostCode,SBP_POA.Phone as pPhone,SBP_POA.Mobile as pMobile,SBP_POA.Fax as pFax,SBP_POA.Email as pEmail,SBP_POA.Passport_No as pPassNo,SBP_POA.Issue_Date as pIssueDate,SBP_POA.Expire_Date as pExpire,SBP_POA.Issue_Place as pIssuePlace,SBP_POA.Nationality as pNationality,SBP_POA.Residency as pResidency,SBP_POA.DOB as pDOB,SBP_POA.Effective_From,SBP_POA.Effective_To,SBP_POA.Remarks" +
                " FROM SBP_Nominee1,SBP_Nominee2,SBP_Guardian1,SBP_Guardian2,SBP_POA WHERE SBP_Nominee1.Cust_Code=SBP_Nominee2.Cust_Code AND SBP_Nominee2.Cust_Code=SBP_Guardian1.Cust_Code AND SBP_Guardian1.Cust_Code=SBP_Guardian2.Cust_Code AND SBP_Guardian2.Cust_Code=SBP_POA.Cust_Code AND SBP_Nominee1.Cust_Code= '"+custCode+"'";
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

        public void Update(string customerCode, Nominee1InfoBO nominee1Bo, Nominee2InfoBO nominee2Bo, Guardian1InfoBO guardian1Bo, Guardian2InfoBO guardian2Bo, PowerOfAttorneyInfoBO poaBO)
        {
            string nom1QueryString = "";
            string nom2QueryString = "";
            string guar1QueryString = "";
            string guar2QueryString = "";
            string poaQueryString = "";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();

                if (Exists("SELECT * FROM SBP_Nominee1 WHERE Cust_Code='" + customerCode + "'"))
                {
                    nom1QueryString = @"SBPUpdateNominee1Info";
                    _dbConnection.ActiveStoredProcedure();
                    _dbConnection.AddParameter("@CustCode", SqlDbType.NVarChar, customerCode);
                    _dbConnection.AddParameter("@Nominee1Name", SqlDbType.VarChar, nominee1Bo.Nominee1Name);
                    _dbConnection.AddParameter("@Nominee1Dob", SqlDbType.DateTime, nominee1Bo.Nominee1Dob);
                    _dbConnection.AddParameter("@Nominee1Nationality", SqlDbType.NVarChar, nominee1Bo.Nominee1Nationality);
                    _dbConnection.AddParameter("@Nominee1Address", SqlDbType.VarChar, nominee1Bo.Nominee1Address);
                    _dbConnection.AddParameter("@Nominee1City", SqlDbType.NVarChar, nominee1Bo.Nominee1City);
                    _dbConnection.AddParameter("@Nominee1PostCode", SqlDbType.NVarChar, nominee1Bo.Nominee1PostCode);
                    _dbConnection.AddParameter("@Nominee1Division", SqlDbType.NVarChar, nominee1Bo.Nominee1Division);
                    _dbConnection.AddParameter("@Nominee1Country", SqlDbType.NVarChar, nominee1Bo.Nominee1Country);
                    _dbConnection.AddParameter("@Nominee1Telephone", SqlDbType.NVarChar, nominee1Bo.Nominee1Telephone);
                    _dbConnection.AddParameter("@Nominee1Mobile", SqlDbType.NVarChar, nominee1Bo.Nominee1Mobile);
                    _dbConnection.AddParameter("@Nominee1Fax", SqlDbType.NVarChar, nominee1Bo.Nominee1Fax);
                    _dbConnection.AddParameter("@Nominee1Email", SqlDbType.NVarChar, nominee1Bo.Nominee1Email);
                    _dbConnection.AddParameter("@Nominee1PassportNo", SqlDbType.NVarChar, nominee1Bo.Nominee1PassportNo);
                    _dbConnection.AddParameter("@Nominee1IssuePlace", SqlDbType.NVarChar, nominee1Bo.Nominee1IssuePlace);
                    _dbConnection.AddParameter("@Nominee1IssueDate", SqlDbType.DateTime, nominee1Bo.Nominee1IssueDate);
                    _dbConnection.AddParameter("@Nominee1ExpireDate", SqlDbType.DateTime, nominee1Bo.Nominee1ExpireDate);
                    _dbConnection.AddParameter("@Nominee1Residency", SqlDbType.NVarChar, nominee1Bo.Nominee1Residency);
                    _dbConnection.AddParameter("@Nominee1Relation", SqlDbType.NVarChar, nominee1Bo.Nominee1Relation);
                    _dbConnection.AddParameter("@Nominee1Percentage", SqlDbType.Float, nominee1Bo.Nominee1Percentage);
                    _dbConnection.AddParameter("@Nominee1NationalId", SqlDbType.NVarChar, nominee1Bo.Nominee1NationalId);
                    _dbConnection.AddParameter("@entryBy", SqlDbType.VarChar, GlobalVariableBO._userName);
                    _dbConnection.ExecuteNonQuery(nom1QueryString);
                }
                else
                {
                    nom1QueryString = @"SBPSaveNominee1Info";
                    _dbConnection.ActiveStoredProcedure();
                    _dbConnection.AddParameter("@CustCode", SqlDbType.NVarChar, customerCode);
                    _dbConnection.AddParameter("@Nominee1Name", SqlDbType.VarChar, nominee1Bo.Nominee1Name);
                    _dbConnection.AddParameter("@Nominee1Dob", SqlDbType.DateTime, nominee1Bo.Nominee1Dob);
                    _dbConnection.AddParameter("@Nominee1Nationality", SqlDbType.NVarChar, nominee1Bo.Nominee1Nationality);
                    _dbConnection.AddParameter("@Nominee1Address", SqlDbType.VarChar, nominee1Bo.Nominee1Address);
                    _dbConnection.AddParameter("@Nominee1City", SqlDbType.NVarChar, nominee1Bo.Nominee1City);
                    _dbConnection.AddParameter("@Nominee1PostCode", SqlDbType.NVarChar, nominee1Bo.Nominee1PostCode);
                    _dbConnection.AddParameter("@Nominee1Division", SqlDbType.NVarChar, nominee1Bo.Nominee1Division);
                    _dbConnection.AddParameter("@Nominee1Country", SqlDbType.NVarChar, nominee1Bo.Nominee1Country);
                    _dbConnection.AddParameter("@Nominee1Telephone", SqlDbType.NVarChar, nominee1Bo.Nominee1Telephone);
                    _dbConnection.AddParameter("@Nominee1Mobile", SqlDbType.NVarChar, nominee1Bo.Nominee1Mobile);
                    _dbConnection.AddParameter("@Nominee1Fax", SqlDbType.NVarChar, nominee1Bo.Nominee1Fax);
                    _dbConnection.AddParameter("@Nominee1Email", SqlDbType.NVarChar, nominee1Bo.Nominee1Email);
                    _dbConnection.AddParameter("@Nominee1PassportNo", SqlDbType.NVarChar, nominee1Bo.Nominee1PassportNo);
                    _dbConnection.AddParameter("@Nominee1IssuePlace", SqlDbType.NVarChar, nominee1Bo.Nominee1IssuePlace);
                    _dbConnection.AddParameter("@Nominee1IssueDate", SqlDbType.DateTime, nominee1Bo.Nominee1IssueDate);
                    _dbConnection.AddParameter("@Nominee1ExpireDate", SqlDbType.DateTime, nominee1Bo.Nominee1ExpireDate);
                    _dbConnection.AddParameter("@Nominee1Residency", SqlDbType.NVarChar, nominee1Bo.Nominee1Residency);
                    _dbConnection.AddParameter("@Nominee1Relation", SqlDbType.NVarChar, nominee1Bo.Nominee1Relation);
                    _dbConnection.AddParameter("@Nominee1Percentage", SqlDbType.Float, nominee1Bo.Nominee1Percentage);
                    _dbConnection.AddParameter("@Nominee1NationalId", SqlDbType.NVarChar, nominee1Bo.Nominee1NationalId);
                    _dbConnection.AddParameter("@entryBy", SqlDbType.VarChar, GlobalVariableBO._userName);
                    _dbConnection.ExecuteNonQuery(nom1QueryString);
                
                }

                if (Exists("SELECT * FROM SBP_Nominee2 WHERE Cust_Code='" + customerCode + "'"))
                {
                    nom2QueryString = @"SBPUpdateNominee2Info";
                    _dbConnection.ActiveStoredProcedure();
                    _dbConnection.AddParameter("@CustCode", SqlDbType.NVarChar, customerCode);
                    _dbConnection.AddParameter("@Nominee2Name", SqlDbType.VarChar, nominee2Bo.Nominee2Name);
                    _dbConnection.AddParameter("@Nominee2Dob", SqlDbType.DateTime, nominee2Bo.Nominee2Dob);
                    _dbConnection.AddParameter("@Nominee2Nationality", SqlDbType.NVarChar, nominee2Bo.Nominee2Nationality);
                    _dbConnection.AddParameter("@Nominee2Address", SqlDbType.VarChar, nominee2Bo.Nominee2Address);
                    _dbConnection.AddParameter("@Nominee2City", SqlDbType.NVarChar, nominee2Bo.Nominee2City);
                    _dbConnection.AddParameter("@Nominee2PostCode", SqlDbType.NVarChar, nominee2Bo.Nominee2PostCode);
                    _dbConnection.AddParameter("@Nominee2Division", SqlDbType.NVarChar, nominee2Bo.Nominee2Division);
                    _dbConnection.AddParameter("@Nominee2Country", SqlDbType.NVarChar, nominee2Bo.Nominee2Country);
                    _dbConnection.AddParameter("@Nominee2Telephone", SqlDbType.NVarChar, nominee2Bo.Nominee2Telephone);
                    _dbConnection.AddParameter("@Nominee2Mobile", SqlDbType.NVarChar, nominee2Bo.Nominee2Mobile);
                    _dbConnection.AddParameter("@Nominee2Fax", SqlDbType.NVarChar, nominee2Bo.Nominee2Fax);
                    _dbConnection.AddParameter("@Nominee2Email", SqlDbType.NVarChar, nominee2Bo.Nominee2Email);
                    _dbConnection.AddParameter("@Nominee2PassportNo", SqlDbType.NVarChar, nominee2Bo.Nominee2PassportNo);
                    _dbConnection.AddParameter("@Nominee2IssuePlace", SqlDbType.NVarChar, nominee2Bo.Nominee2IssuePlace);
                    _dbConnection.AddParameter("@Nominee2IssueDate", SqlDbType.DateTime, nominee2Bo.Nominee2IssueDate);
                    _dbConnection.AddParameter("@Nominee2ExpireDate", SqlDbType.DateTime, nominee2Bo.Nominee2ExpireDate);
                    _dbConnection.AddParameter("@Nominee2Residency", SqlDbType.NVarChar, nominee2Bo.Nominee2Residency);
                    _dbConnection.AddParameter("@Nominee2Relation", SqlDbType.NVarChar, nominee2Bo.Nominee2Relation);
                    _dbConnection.AddParameter("@Nominee2Percentage", SqlDbType.Float, nominee2Bo.Nominee2Percentage);
                    _dbConnection.AddParameter("@Nominee2NationalId", SqlDbType.NVarChar, nominee2Bo.Nominee2NationalId);
                    _dbConnection.AddParameter("@entryBy", SqlDbType.VarChar, GlobalVariableBO._userName);
                    _dbConnection.ExecuteNonQuery(nom2QueryString);
                }
                else
                {
                    nom2QueryString = @"SBPSaveNominee2Info";
                    _dbConnection.ActiveStoredProcedure();
                    _dbConnection.AddParameter("@CustCode", SqlDbType.NVarChar, customerCode);
                    _dbConnection.AddParameter("@Nominee2Name", SqlDbType.VarChar, nominee2Bo.Nominee2Name);
                    _dbConnection.AddParameter("@Nominee2Dob", SqlDbType.DateTime, nominee2Bo.Nominee2Dob);
                    _dbConnection.AddParameter("@Nominee2Nationality", SqlDbType.NVarChar, nominee2Bo.Nominee2Nationality);
                    _dbConnection.AddParameter("@Nominee2Address", SqlDbType.VarChar, nominee2Bo.Nominee2Address);
                    _dbConnection.AddParameter("@Nominee2City", SqlDbType.NVarChar, nominee2Bo.Nominee2City);
                    _dbConnection.AddParameter("@Nominee2PostCode", SqlDbType.NVarChar, nominee2Bo.Nominee2PostCode);
                    _dbConnection.AddParameter("@Nominee2Division", SqlDbType.NVarChar, nominee2Bo.Nominee2Division);
                    _dbConnection.AddParameter("@Nominee2Country", SqlDbType.NVarChar, nominee2Bo.Nominee2Country);
                    _dbConnection.AddParameter("@Nominee2Telephone", SqlDbType.NVarChar, nominee2Bo.Nominee2Telephone);
                    _dbConnection.AddParameter("@Nominee2Mobile", SqlDbType.NVarChar, nominee2Bo.Nominee2Mobile);
                    _dbConnection.AddParameter("@Nominee2Fax", SqlDbType.NVarChar, nominee2Bo.Nominee2Fax);
                    _dbConnection.AddParameter("@Nominee2Email", SqlDbType.NVarChar, nominee2Bo.Nominee2Email);
                    _dbConnection.AddParameter("@Nominee2PassportNo", SqlDbType.NVarChar, nominee2Bo.Nominee2PassportNo);
                    _dbConnection.AddParameter("@Nominee2IssuePlace", SqlDbType.NVarChar, nominee2Bo.Nominee2IssuePlace);
                    _dbConnection.AddParameter("@Nominee2IssueDate", SqlDbType.DateTime, nominee2Bo.Nominee2IssueDate);
                    _dbConnection.AddParameter("@Nominee2ExpireDate", SqlDbType.DateTime, nominee2Bo.Nominee2ExpireDate);
                    _dbConnection.AddParameter("@Nominee2Residency", SqlDbType.NVarChar, nominee2Bo.Nominee2Residency);
                    _dbConnection.AddParameter("@Nominee2Relation", SqlDbType.NVarChar, nominee2Bo.Nominee2Relation);
                    _dbConnection.AddParameter("@Nominee2Percentage", SqlDbType.Float, nominee2Bo.Nominee2Percentage);
                    _dbConnection.AddParameter("@Nominee2NationalId", SqlDbType.NVarChar, nominee2Bo.Nominee2NationalId);
                    _dbConnection.AddParameter("@entryBy", SqlDbType.VarChar, GlobalVariableBO._userName);
                    _dbConnection.ExecuteNonQuery(nom2QueryString);
 

                }
                if (Exists("SELECT * FROM SBP_Guardian1 WHERE Cust_Code='" + customerCode + "'"))
                {
                    guar1QueryString = @"SBPUpdateGuardian1Info";
                    _dbConnection.ActiveStoredProcedure();
                    _dbConnection.AddParameter("@CustCode", SqlDbType.NVarChar, customerCode);
                    _dbConnection.AddParameter("@Guardian1Name", SqlDbType.VarChar, guardian1Bo.Guardian1Name);
                    _dbConnection.AddParameter("@Guardian1DOB", SqlDbType.DateTime, guardian1Bo.Guardian1DOB.ToShortDateString());
                    _dbConnection.AddParameter("@Guardian1Nationality", SqlDbType.NVarChar, guardian1Bo.Guardian1Nationality);
                    _dbConnection.AddParameter("@Guardian1Address", SqlDbType.VarChar, guardian1Bo.Guardian1Address);
                    _dbConnection.AddParameter("@Guardian1City", SqlDbType.NVarChar, guardian1Bo.Guardian1City);
                    _dbConnection.AddParameter("@Guardian1PostCode", SqlDbType.NVarChar, guardian1Bo.Guardian1PostCode);
                    _dbConnection.AddParameter("@Guardian1Division", SqlDbType.NVarChar, guardian1Bo.Guardian1Division);
                    _dbConnection.AddParameter("@Guardian1Country", SqlDbType.NVarChar, guardian1Bo.Guardian1Country);
                    _dbConnection.AddParameter("@Guardian1Telephone", SqlDbType.NVarChar, guardian1Bo.Guardian1Telephone);
                    _dbConnection.AddParameter("@Guardian1Mobile", SqlDbType.NVarChar, guardian1Bo.Guardian1Mobile);
                    _dbConnection.AddParameter("@Guardian1Fax", SqlDbType.NVarChar, guardian1Bo.Guardian1Fax);
                    _dbConnection.AddParameter("@Guardian1Email", SqlDbType.NVarChar, guardian1Bo.Guardian1Email);
                    _dbConnection.AddParameter("@Guardian1PassportNo", SqlDbType.NVarChar, guardian1Bo.Guardian1PassportNo);
                    _dbConnection.AddParameter("@Guardian1IssuePlace", SqlDbType.NVarChar, guardian1Bo.Guardian1IssuePlace);
                    _dbConnection.AddParameter("@Guardian1IssueDate", SqlDbType.DateTime, guardian1Bo.Guardian1IssueDate.ToShortDateString());
                    _dbConnection.AddParameter("@Guardian1ExpireDate", SqlDbType.DateTime, guardian1Bo.Guardian1ExpireDate.ToShortDateString());
                    _dbConnection.AddParameter("@Guardian1Residency", SqlDbType.NVarChar, guardian1Bo.Guardian1Residency);
                    _dbConnection.AddParameter("@Guardian1Relation", SqlDbType.NVarChar, guardian1Bo.Guardian1Relation);
                    _dbConnection.AddParameter("@Guardian1DoBofMinor", SqlDbType.DateTime, guardian1Bo.Guardian1DoBofMinor.ToShortDateString());
                    _dbConnection.AddParameter("@Guardian1MaturityDateMinor", SqlDbType.DateTime, guardian1Bo.Guardian1MaturityDateMinor.ToShortDateString());
                    _dbConnection.AddParameter("@entryBy", SqlDbType.VarChar, GlobalVariableBO._userName);
                    _dbConnection.ExecuteNonQuery(guar1QueryString);
                }
                else
                {
                    guar1QueryString = @"SBPSaveGuardian1Info";
                    _dbConnection.ActiveStoredProcedure();
                    _dbConnection.AddParameter("@CustCode", SqlDbType.NVarChar, customerCode);
                    _dbConnection.AddParameter("@Guardian1Name", SqlDbType.VarChar, guardian1Bo.Guardian1Name);
                    _dbConnection.AddParameter("@Guardian1DOB", SqlDbType.DateTime, guardian1Bo.Guardian1DOB.ToShortDateString());
                    _dbConnection.AddParameter("@Guardian1Nationality", SqlDbType.NVarChar, guardian1Bo.Guardian1Nationality);
                    _dbConnection.AddParameter("@Guardian1Address", SqlDbType.VarChar, guardian1Bo.Guardian1Address);
                    _dbConnection.AddParameter("@Guardian1City", SqlDbType.NVarChar, guardian1Bo.Guardian1City);
                    _dbConnection.AddParameter("@Guardian1PostCode", SqlDbType.NVarChar, guardian1Bo.Guardian1PostCode);
                    _dbConnection.AddParameter("@Guardian1Division", SqlDbType.NVarChar, guardian1Bo.Guardian1Division);
                    _dbConnection.AddParameter("@Guardian1Country", SqlDbType.NVarChar, guardian1Bo.Guardian1Country);
                    _dbConnection.AddParameter("@Guardian1Telephone", SqlDbType.NVarChar, guardian1Bo.Guardian1Telephone);
                    _dbConnection.AddParameter("@Guardian1Mobile", SqlDbType.NVarChar, guardian1Bo.Guardian1Mobile);
                    _dbConnection.AddParameter("@Guardian1Fax", SqlDbType.NVarChar, guardian1Bo.Guardian1Fax);
                    _dbConnection.AddParameter("@Guardian1Email", SqlDbType.NVarChar, guardian1Bo.Guardian1Email);
                    _dbConnection.AddParameter("@Guardian1PassportNo", SqlDbType.NVarChar, guardian1Bo.Guardian1PassportNo);
                    _dbConnection.AddParameter("@Guardian1IssuePlace", SqlDbType.NVarChar, guardian1Bo.Guardian1IssuePlace);
                    _dbConnection.AddParameter("@Guardian1IssueDate", SqlDbType.DateTime, guardian1Bo.Guardian1IssueDate.ToShortDateString());
                    _dbConnection.AddParameter("@Guardian1ExpireDate", SqlDbType.DateTime, guardian1Bo.Guardian1ExpireDate.ToShortDateString());
                    _dbConnection.AddParameter("@Guardian1Residency", SqlDbType.NVarChar, guardian1Bo.Guardian1Residency);
                    _dbConnection.AddParameter("@Guardian1Relation", SqlDbType.NVarChar, guardian1Bo.Guardian1Relation);
                    _dbConnection.AddParameter("@Guardian1DoBofMinor", SqlDbType.DateTime, guardian1Bo.Guardian1DoBofMinor.ToShortDateString());
                    _dbConnection.AddParameter("@Guardian1MaturityDateMinor", SqlDbType.DateTime, guardian1Bo.Guardian1MaturityDateMinor.ToShortDateString());
                    _dbConnection.AddParameter("@entryBy", SqlDbType.VarChar, GlobalVariableBO._userName);
                    _dbConnection.ExecuteNonQuery(guar1QueryString);
                }
                if (Exists("SELECT * FROM SBP_Guardian2 WHERE Cust_Code='" + customerCode + "'"))
                {
                    guar2QueryString = @"SBPUpdateGuardian2Info";
                    _dbConnection.ActiveStoredProcedure();
                    _dbConnection.AddParameter("@CustCode", SqlDbType.NVarChar, customerCode);
                    _dbConnection.AddParameter("@Guardian2Name", SqlDbType.VarChar, guardian2Bo.Guardian2Name);
                    _dbConnection.AddParameter("@Guardian2DOB", SqlDbType.DateTime, guardian2Bo.Guardian2DOB.ToShortDateString());
                    _dbConnection.AddParameter("@Guardian2Nationality", SqlDbType.NVarChar, guardian2Bo.Guardian2Nationality);
                    _dbConnection.AddParameter("@Guardian2Address", SqlDbType.VarChar, guardian2Bo.Guardian2Address);
                    _dbConnection.AddParameter("@Guardian2City", SqlDbType.NVarChar, guardian2Bo.Guardian2City);
                    _dbConnection.AddParameter("@Guardian2PostCode", SqlDbType.NVarChar, guardian2Bo.Guardian2PostCode);
                    _dbConnection.AddParameter("@Guardian2Division", SqlDbType.NVarChar, guardian2Bo.Guardian2Division);
                    _dbConnection.AddParameter("@Guardian2Country", SqlDbType.NVarChar, guardian2Bo.Guardian2Country);
                    _dbConnection.AddParameter("@Guardian2Telephone", SqlDbType.NVarChar, guardian2Bo.Guardian2Telephone);
                    _dbConnection.AddParameter("@Guardian2Mobile", SqlDbType.NVarChar, guardian2Bo.Guardian2Mobile);
                    _dbConnection.AddParameter("@Guardian2Fax", SqlDbType.NVarChar, guardian2Bo.Guardian2Fax);
                    _dbConnection.AddParameter("@Guardian2Email", SqlDbType.NVarChar, guardian2Bo.Guardian2Email);
                    _dbConnection.AddParameter("@Guardian2PassportNo", SqlDbType.NVarChar, guardian2Bo.Guardian2PassportNo);
                    _dbConnection.AddParameter("@Guardian2IssuePlace", SqlDbType.NVarChar, guardian2Bo.Guardian2IssuePlace);
                    _dbConnection.AddParameter("@Guardian2IssueDate", SqlDbType.DateTime, guardian2Bo.Guardian2IssueDate.ToShortDateString());
                    _dbConnection.AddParameter("@Guardian2ExpireDate", SqlDbType.DateTime, guardian2Bo.Guardian2ExpireDate.ToShortDateString());
                    _dbConnection.AddParameter("@Guardian2Residency", SqlDbType.NVarChar, guardian2Bo.Guardian2Residency);
                    _dbConnection.AddParameter("@Guardian2Relation", SqlDbType.NVarChar, guardian2Bo.Guardian2Relation);
                    _dbConnection.AddParameter("@Guardian2DoBofMinor", SqlDbType.DateTime, guardian2Bo.Guardian2DoBofMinor.ToShortDateString());
                    _dbConnection.AddParameter("@Guardian2MaturityDateMinor", SqlDbType.DateTime, guardian2Bo.Guardian2MaturityDateMinor.ToShortDateString());
                    _dbConnection.AddParameter("@entryBy", SqlDbType.VarChar, GlobalVariableBO._userName);
                    _dbConnection.ExecuteNonQuery(guar2QueryString);
                }
                else
                {
                    guar2QueryString = @"SBPSaveGuardian2Info";
                    _dbConnection.ActiveStoredProcedure();
                    _dbConnection.AddParameter("@CustCode", SqlDbType.NVarChar, customerCode);
                    _dbConnection.AddParameter("@Guardian2Name", SqlDbType.VarChar, guardian2Bo.Guardian2Name);
                    _dbConnection.AddParameter("@Guardian2DOB", SqlDbType.DateTime, guardian2Bo.Guardian2DOB.ToShortDateString());
                    _dbConnection.AddParameter("@Guardian2Nationality", SqlDbType.NVarChar, guardian2Bo.Guardian2Nationality);
                    _dbConnection.AddParameter("@Guardian2Address", SqlDbType.VarChar, guardian2Bo.Guardian2Address);
                    _dbConnection.AddParameter("@Guardian2City", SqlDbType.NVarChar, guardian2Bo.Guardian2City);
                    _dbConnection.AddParameter("@Guardian2PostCode", SqlDbType.NVarChar, guardian2Bo.Guardian2PostCode);
                    _dbConnection.AddParameter("@Guardian2Division", SqlDbType.NVarChar, guardian2Bo.Guardian2Division);
                    _dbConnection.AddParameter("@Guardian2Country", SqlDbType.NVarChar, guardian2Bo.Guardian2Country);
                    _dbConnection.AddParameter("@Guardian2Telephone", SqlDbType.NVarChar, guardian2Bo.Guardian2Telephone);
                    _dbConnection.AddParameter("@Guardian2Mobile", SqlDbType.NVarChar, guardian2Bo.Guardian2Mobile);
                    _dbConnection.AddParameter("@Guardian2Fax", SqlDbType.NVarChar, guardian2Bo.Guardian2Fax);
                    _dbConnection.AddParameter("@Guardian2Email", SqlDbType.NVarChar, guardian2Bo.Guardian2Email);
                    _dbConnection.AddParameter("@Guardian2PassportNo", SqlDbType.NVarChar, guardian2Bo.Guardian2PassportNo);
                    _dbConnection.AddParameter("@Guardian2IssuePlace", SqlDbType.NVarChar, guardian2Bo.Guardian2IssuePlace);
                    _dbConnection.AddParameter("@Guardian2IssueDate", SqlDbType.DateTime, guardian2Bo.Guardian2IssueDate.ToShortDateString());
                    _dbConnection.AddParameter("@Guardian2ExpireDate", SqlDbType.DateTime, guardian2Bo.Guardian2ExpireDate.ToShortDateString());
                    _dbConnection.AddParameter("@Guardian2Residency", SqlDbType.NVarChar, guardian2Bo.Guardian2Residency);
                    _dbConnection.AddParameter("@Guardian2Relation", SqlDbType.NVarChar, guardian2Bo.Guardian2Relation);
                    _dbConnection.AddParameter("@Guardian2DoBofMinor", SqlDbType.DateTime, guardian2Bo.Guardian2DoBofMinor.ToShortDateString());
                    _dbConnection.AddParameter("@Guardian2MaturityDateMinor", SqlDbType.DateTime, guardian2Bo.Guardian2MaturityDateMinor.ToShortDateString());
                    _dbConnection.AddParameter("@entryBy", SqlDbType.VarChar, GlobalVariableBO._userName);
                    _dbConnection.ExecuteNonQuery(guar2QueryString);
                
                }

                if (Exists("SELECT * FROM SBP_POA WHERE Cust_Code='" + customerCode + "'"))
                {
                    poaQueryString = @"SBPUpdatePOAInfo";
                    _dbConnection.ActiveStoredProcedure();
                    _dbConnection.AddParameter("@CustCode", SqlDbType.NVarChar, customerCode);
                    _dbConnection.AddParameter("@POAName", SqlDbType.VarChar, poaBO.POAName);
                    _dbConnection.AddParameter("@POADob", SqlDbType.DateTime, poaBO.POADob.ToShortDateString());
                    _dbConnection.AddParameter("@POANationality", SqlDbType.NVarChar, poaBO.POANationality);
                    _dbConnection.AddParameter("@POAAddress", SqlDbType.VarChar, poaBO.POAAddress);
                    _dbConnection.AddParameter("@POACity", SqlDbType.NVarChar, poaBO.POACity);
                    _dbConnection.AddParameter("@POAPostCode", SqlDbType.NVarChar, poaBO.POAPostCode);
                    _dbConnection.AddParameter("@POADivision", SqlDbType.NVarChar, poaBO.POADivision);
                    _dbConnection.AddParameter("@POACountry", SqlDbType.NVarChar, poaBO.POACountry);
                    _dbConnection.AddParameter("@POATelephone", SqlDbType.NVarChar, poaBO.POATelephone);
                    _dbConnection.AddParameter("@POAMobile", SqlDbType.NVarChar, poaBO.POAMobile);
                    _dbConnection.AddParameter("@POAFax", SqlDbType.NVarChar, poaBO.POAFax);
                    _dbConnection.AddParameter("@POAEmail", SqlDbType.NVarChar, poaBO.POAEmail);
                    _dbConnection.AddParameter("@POAPassportNo", SqlDbType.NVarChar, poaBO.POAPassportNo);
                    _dbConnection.AddParameter("@POAIssuePlace", SqlDbType.NVarChar, poaBO.POAIssuePlace);
                    _dbConnection.AddParameter("@POAIssueDate", SqlDbType.DateTime, poaBO.POAIssueDate.ToShortDateString());
                    _dbConnection.AddParameter("@POAExpireDate", SqlDbType.DateTime, poaBO.POAExpireDate.ToShortDateString());
                    _dbConnection.AddParameter("@POAResidency", SqlDbType.NVarChar, poaBO.POAResidency);
                    _dbConnection.AddParameter("@POAEffectiveFrom", SqlDbType.DateTime, poaBO.POAEffectiveFrom.ToShortDateString());
                    _dbConnection.AddParameter("@POAEffectiveTo", SqlDbType.DateTime, poaBO.POAEffectiveTo.ToShortDateString());
                    _dbConnection.AddParameter("@POARemarks", SqlDbType.VarChar, poaBO.POARemarks);
                    _dbConnection.AddParameter("@entryBy", SqlDbType.VarChar, GlobalVariableBO._userName);
                    _dbConnection.ExecuteNonQuery(poaQueryString);
                }
                else
                {
                    poaQueryString = @"SBPSavePOAInfo";
                    _dbConnection.ActiveStoredProcedure();
                    _dbConnection.AddParameter("@CustCode", SqlDbType.NVarChar, customerCode);
                    _dbConnection.AddParameter("@POAName", SqlDbType.VarChar, poaBO.POAName);
                    _dbConnection.AddParameter("@POADob", SqlDbType.DateTime, poaBO.POADob.ToShortDateString());
                    _dbConnection.AddParameter("@POANationality", SqlDbType.NVarChar, poaBO.POANationality);
                    _dbConnection.AddParameter("@POAAddress", SqlDbType.VarChar, poaBO.POAAddress);
                    _dbConnection.AddParameter("@POACity", SqlDbType.NVarChar, poaBO.POACity);
                    _dbConnection.AddParameter("@POAPostCode", SqlDbType.NVarChar, poaBO.POAPostCode);
                    _dbConnection.AddParameter("@POADivision", SqlDbType.NVarChar, poaBO.POADivision);
                    _dbConnection.AddParameter("@POACountry", SqlDbType.NVarChar, poaBO.POACountry);
                    _dbConnection.AddParameter("@POATelephone", SqlDbType.NVarChar, poaBO.POATelephone);
                    _dbConnection.AddParameter("@POAMobile", SqlDbType.NVarChar, poaBO.POAMobile);
                    _dbConnection.AddParameter("@POAFax", SqlDbType.NVarChar, poaBO.POAFax);
                    _dbConnection.AddParameter("@POAEmail", SqlDbType.NVarChar, poaBO.POAEmail);
                    _dbConnection.AddParameter("@POAPassportNo", SqlDbType.NVarChar, poaBO.POAPassportNo);
                    _dbConnection.AddParameter("@POAIssuePlace", SqlDbType.NVarChar, poaBO.POAIssuePlace);
                    _dbConnection.AddParameter("@POAIssueDate", SqlDbType.DateTime, poaBO.POAIssueDate.ToShortDateString());
                    _dbConnection.AddParameter("@POAExpireDate", SqlDbType.DateTime, poaBO.POAExpireDate.ToShortDateString());
                    _dbConnection.AddParameter("@POAResidency", SqlDbType.NVarChar, poaBO.POAResidency);
                    _dbConnection.AddParameter("@POAEffectiveFrom", SqlDbType.DateTime, poaBO.POAEffectiveFrom.ToShortDateString());
                    _dbConnection.AddParameter("@POAEffectiveTo", SqlDbType.DateTime, poaBO.POAEffectiveTo.ToShortDateString());
                    _dbConnection.AddParameter("@POARemarks", SqlDbType.VarChar, poaBO.POARemarks);
                    _dbConnection.AddParameter("@entryBy", SqlDbType.VarChar, GlobalVariableBO._userName);
                    _dbConnection.ExecuteNonQuery(poaQueryString);

                }
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

        private bool Exists(string query)
        {
            DataTable dataTable;
            try
            {
                _dbConnection.ConnectDatabase();
                dataTable = _dbConnection.ExecuteQuery(query);

            }
            catch (Exception)
            {
                throw;
            }
            //finally
            //{
            //    _dbConnection.CloseDatabase();
            //}
            if (dataTable.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        public bool CheckTable(string custCode)
        {
            DataTable dataTable;
            string queryString = "";
            queryString = "SELECT Cust_Code FROM SBP_Nominee1 WHERE Cust_Code='" + custCode + "'";
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
    }
}
