﻿using System;
using System.Data;
using System.Windows.Forms;
using BusinessAccessLayer.BO;
using DataAccessLayer;

namespace BusinessAccessLayer.BAL
{
    public class CustomerInfoBAL
    {
        private DbConnection _dbConnection;
        public CustomerInfoBAL()
        {
            _dbConnection = new DbConnection();
        }


        public void Insert(CustomerBasicInfoBO basicInfoBO, CustomerPersonalInfoBO personalInfoBO, CustomerContactDetailsBO contactDetailsBO, CustomerAdditionalInfoBO additionalInfoBO, CustomerBankDetailsBO bankDetailsBO, CustomerPassportInfoBO passportInfoBO, JointAccountHolderInfoBO jointHolderInfoBo, AuthorInroducerBO authorInroBO)
        {
            string queryStringBasicInfo = "";
            string queryStringPersonalInfo = "";
            string queryStringContactsInfo = "";
            string queryStringAdditionalInfo = "";
            string queryStringBankInfo = "";
            string queryStringPassportInfo = "";
            string queryStringJointInfo = "";
            string queryStringAuthor = "";

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();
                queryStringBasicInfo = @"SBPSaveCustBasicInfo";
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@CustCode", SqlDbType.NVarChar, basicInfoBO.CustCode);
                _dbConnection.AddParameter("@CustGroup", SqlDbType.Int, basicInfoBO.CustGroup);
                _dbConnection.AddParameter("@SpecialInstrution", SqlDbType.VarChar, basicInfoBO.SpecialInstrution);
                _dbConnection.AddParameter("@CustParentCode", SqlDbType.Int, basicInfoBO.CustParentCode);
                _dbConnection.AddParameter("@CustOpenDate", SqlDbType.DateTime, basicInfoBO.CustOpenDate.ToShortDateString());
                _dbConnection.AddParameter("@CustStatus", SqlDbType.Int, basicInfoBO.CustStatus);
                _dbConnection.AddParameter("@Cust_Trans_Status_ID", SqlDbType.Int, basicInfoBO.Transaction_Status_ID);
                _dbConnection.AddParameter("@BOID", SqlDbType.NVarChar, basicInfoBO.BOID);
                _dbConnection.AddParameter("@BOCategory", SqlDbType.Int, basicInfoBO.BOCategory);
                _dbConnection.AddParameter("@BOType", SqlDbType.Int, basicInfoBO.BOType);
                _dbConnection.AddParameter("@BOStatus", SqlDbType.Int, basicInfoBO.BOStatus);
                _dbConnection.AddParameter("@BOOpenDate ", SqlDbType.DateTime, basicInfoBO.BOOpenDate.ToShortDateString());
                _dbConnection.AddParameter("@IsDirSE", SqlDbType.Int, basicInfoBO.IsDirSE);
                _dbConnection.AddParameter("@NameAddressSE", SqlDbType.VarChar, basicInfoBO.NameAddressSE);
                _dbConnection.AddParameter("@entryBy", SqlDbType.VarChar, GlobalVariableBO._userName);
                _dbConnection.ExecuteNonQuery(queryStringBasicInfo);

                queryStringPersonalInfo = @"SBPSaveCustPersonalInfo";
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@CustCode", SqlDbType.NVarChar, personalInfoBO.CustCode);
                _dbConnection.AddParameter("@AccountHolder", SqlDbType.VarChar, personalInfoBO.AccountHolder);
                _dbConnection.AddParameter("@FatherName", SqlDbType.VarChar, personalInfoBO.FatherName);
                _dbConnection.AddParameter("@MotherName", SqlDbType.VarChar, personalInfoBO.MotherName);
                _dbConnection.AddParameter("@DOB", SqlDbType.DateTime, personalInfoBO.DOB.ToShortDateString());
                _dbConnection.AddParameter("@Gender", SqlDbType.NVarChar, personalInfoBO.Gender);
                _dbConnection.AddParameter("@Occupation", SqlDbType.VarChar, personalInfoBO.Occupation);
                _dbConnection.AddParameter("@NationalID", SqlDbType.VarChar, personalInfoBO.NationalID);
                _dbConnection.AddParameter("@entryBy", SqlDbType.VarChar, GlobalVariableBO._userName);
                _dbConnection.ExecuteNonQuery(queryStringPersonalInfo);

                queryStringContactsInfo = @"SBPSaveCustContactsInfo";
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@CustCode", SqlDbType.NVarChar, contactDetailsBO.CustCode);
                _dbConnection.AddParameter("@Address1", SqlDbType.VarChar, contactDetailsBO.Address1);
                _dbConnection.AddParameter("@Address2", SqlDbType.VarChar, contactDetailsBO.Address2);
                _dbConnection.AddParameter("@Address3", SqlDbType.VarChar, contactDetailsBO.Address3);
                _dbConnection.AddParameter("@CityName", SqlDbType.VarChar, contactDetailsBO.CityName);
                _dbConnection.AddParameter("@PostCode", SqlDbType.NVarChar, contactDetailsBO.PostCode);
                _dbConnection.AddParameter("@DivisionName", SqlDbType.VarChar, contactDetailsBO.DivisionName);
                _dbConnection.AddParameter("@CountryName", SqlDbType.VarChar, contactDetailsBO.CountryName);
                _dbConnection.AddParameter("@Telephone", SqlDbType.NVarChar, contactDetailsBO.Telephone);
                _dbConnection.AddParameter("@Mobile", SqlDbType.NVarChar, contactDetailsBO.Mobile);
                _dbConnection.AddParameter("@CustomerFax", SqlDbType.NVarChar, contactDetailsBO.CustomerFax);
                _dbConnection.AddParameter("@CustomerEmail", SqlDbType.NVarChar, contactDetailsBO.CustomerEmail);
                _dbConnection.AddParameter("@entryBy", SqlDbType.VarChar, GlobalVariableBO._userName);
                _dbConnection.ExecuteNonQuery(queryStringContactsInfo);

                queryStringAdditionalInfo = @"SBPSaveCustAdditionalInfo";
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@CustCode", SqlDbType.NVarChar, additionalInfoBO.CustCode);
                _dbConnection.AddParameter("@Residency", SqlDbType.VarChar, additionalInfoBO.Residency);
                _dbConnection.AddParameter("@Assigned_WorkStation", SqlDbType.VarChar, additionalInfoBO.AssignedWorkstation);
                _dbConnection.AddParameter("@Net_Adjustment", SqlDbType.VarChar, additionalInfoBO.Net_Adjustment);
                _dbConnection.AddParameter("@Nationality", SqlDbType.NVarChar, additionalInfoBO.Nationality);
                _dbConnection.AddParameter("@StatementCycleID", SqlDbType.Int, additionalInfoBO.StatementCycleID);
                _dbConnection.AddParameter("@InternalRefNo", SqlDbType.NVarChar, additionalInfoBO.InternalRefNo);
                _dbConnection.AddParameter("@CompanyRegNo", SqlDbType.NVarChar, additionalInfoBO.CompanyRegNo);
                _dbConnection.AddParameter("@CompanyRegDate", SqlDbType.DateTime, additionalInfoBO.CompanyRegDate.ToShortDateString());
                _dbConnection.AddParameter("@IsAccLinkRequest", SqlDbType.Bit, additionalInfoBO.IsAccLinkRequest);
                _dbConnection.AddParameter("@AccLinkBo", SqlDbType.NVarChar, additionalInfoBO.AccLinkBo);
                _dbConnection.AddParameter("@IsStandingIns", SqlDbType.Bit, additionalInfoBO.IsStandingIns);
                _dbConnection.AddParameter("@entryBy", SqlDbType.VarChar, GlobalVariableBO._userName);
                _dbConnection.ExecuteNonQuery(queryStringAdditionalInfo);

                queryStringBankInfo = @"SBPSaveCustBankInfo";
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@CustCode", SqlDbType.NVarChar, bankDetailsBO.CustCode);
                _dbConnection.AddParameter("@Bank_ID", SqlDbType.Int, bankDetailsBO.Bank_ID);
                _dbConnection.AddParameter("@BankName", SqlDbType.VarChar, bankDetailsBO.BankName);
                _dbConnection.AddParameter("@Branch_ID", SqlDbType.Int, bankDetailsBO.Branch_ID);
                _dbConnection.AddParameter("@BranchName", SqlDbType.VarChar, bankDetailsBO.BranchName);
                _dbConnection.AddParameter("@AccountNo", SqlDbType.NVarChar, bankDetailsBO.AccountNo);
                _dbConnection.AddParameter("@Account_Type", SqlDbType.NVarChar, bankDetailsBO.AccountType);
                _dbConnection.AddParameter("@IsEDC", SqlDbType.Bit, bankDetailsBO.IsEDC);
                _dbConnection.AddParameter("@IsTaxExemption", SqlDbType.Bit, bankDetailsBO.IsTaxExemption);
                _dbConnection.AddParameter("@TIN", SqlDbType.NVarChar, bankDetailsBO.TIN);
                _dbConnection.AddParameter("@SWIFT_Code", SqlDbType.NVarChar, bankDetailsBO.SWIFT_Code);
                _dbConnection.AddParameter("@IBAN", SqlDbType.NVarChar, bankDetailsBO.IBAN);
                _dbConnection.AddParameter("@Routing_No", SqlDbType.NVarChar, bankDetailsBO.Routing_No);
                _dbConnection.AddParameter("@District_Name", SqlDbType.NVarChar, bankDetailsBO.District_Name);
                _dbConnection.AddParameter("@entryBy", SqlDbType.VarChar, GlobalVariableBO._userName);
                _dbConnection.ExecuteNonQuery(queryStringBankInfo);

                queryStringPassportInfo = @"SBPSaveCustPassportInfo";
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@CustCode", SqlDbType.NVarChar, passportInfoBO.CustCode);
                _dbConnection.AddParameter("@PassportNo", SqlDbType.NVarChar, passportInfoBO.PassportNo);
                _dbConnection.AddParameter("@IssuePlace", SqlDbType.NVarChar, passportInfoBO.IssuePlace);
                _dbConnection.AddParameter("@IssueDate", SqlDbType.DateTime, passportInfoBO.IssueDate.ToShortDateString());
                _dbConnection.AddParameter("@ExpireDate", SqlDbType.DateTime, passportInfoBO.ExpireDate.ToShortDateString());
                _dbConnection.AddParameter("@entryBy", SqlDbType.VarChar, GlobalVariableBO._userName);
                _dbConnection.ExecuteNonQuery(queryStringPassportInfo);

                queryStringJointInfo = @"SBPSaveJointInfo";
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@JointCustCode", SqlDbType.NVarChar, jointHolderInfoBo.JointCustCode);
                _dbConnection.AddParameter("@JointName", SqlDbType.VarChar, jointHolderInfoBo.JointName);
                _dbConnection.AddParameter("@JointFatherName", SqlDbType.VarChar, jointHolderInfoBo.JointFatherName);
                _dbConnection.AddParameter("@JointMotherName", SqlDbType.VarChar, jointHolderInfoBo.JointMotherName);
                _dbConnection.AddParameter("@JointDOB", SqlDbType.DateTime, jointHolderInfoBo.JointDOB.ToShortDateString());
                _dbConnection.AddParameter("@JointSex", SqlDbType.VarChar, jointHolderInfoBo.JointSex);
                _dbConnection.AddParameter("@JointNationality", SqlDbType.VarChar, jointHolderInfoBo.JointNationality);
                _dbConnection.AddParameter("@JointNationalId", SqlDbType.NVarChar, jointHolderInfoBo.JointNationalId);
                _dbConnection.AddParameter("@JointAddress", SqlDbType.VarChar, jointHolderInfoBo.JointAddress);
                _dbConnection.AddParameter("@JoitnPhone", SqlDbType.NVarChar, jointHolderInfoBo.JoitnPhone);
                _dbConnection.AddParameter("@JointMobile ", SqlDbType.NVarChar, jointHolderInfoBo.JointMobile);
                _dbConnection.AddParameter("@JointEmail", SqlDbType.NVarChar, jointHolderInfoBo.JointEmail);
                _dbConnection.AddParameter("@JointOperatedBy", SqlDbType.NVarChar, jointHolderInfoBo.JointOperatedBy);
                _dbConnection.AddParameter("@entryBy", SqlDbType.VarChar, GlobalVariableBO._userName);
                _dbConnection.ExecuteNonQuery(queryStringJointInfo);

                queryStringAuthor = @"SBPSaveIntroAuthorInfo";
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@AuthorCustCode", SqlDbType.NVarChar, authorInroBO.AuthorCustCode);
                _dbConnection.AddParameter("@AuthorName", SqlDbType.VarChar, authorInroBO.AuthorName);
                _dbConnection.AddParameter("@AuthorAddress", SqlDbType.VarChar, authorInroBO.AuthorAddress);
                _dbConnection.AddParameter("@AuthorMobile", SqlDbType.NVarChar, authorInroBO.AuthorMobile);
                _dbConnection.AddParameter("@IntroName", SqlDbType.VarChar, authorInroBO.IntroName);
                _dbConnection.AddParameter("@IntroAddress", SqlDbType.VarChar, authorInroBO.IntroAddress);
                _dbConnection.AddParameter("@IntroBOID", SqlDbType.NVarChar, authorInroBO.IntroBOID);
                _dbConnection.AddParameter("@IntroRemarks", SqlDbType.VarChar, authorInroBO.IntroRemarks);
                _dbConnection.AddParameter("@entryBy", SqlDbType.VarChar, GlobalVariableBO._userName);
                _dbConnection.ExecuteNonQuery(queryStringAuthor);
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


        public string Default_Work_Station()
        {
            string Result = string.Empty;
            DataTable dt = new DataTable();
            string Query = @"Select Work_Station_Name from dbo.SBP_Default_Workstation";

            _dbConnection.ConnectDatabase();
            dt = _dbConnection.ExecuteQuery(Query);

            foreach (DataRow dr in dt.Rows)
            {
                Result = dr[0].ToString();
            }
            if (dt.Rows.Count == 0)
            {
                Result = "";
            }
            return Result;

        }
        public bool CheckBOIdDuplicate(string BoId)
        {
            DataTable dataTable;
            string queryString = "";
            queryString = "SELECT BO_ID FROM SBP_Customers WHERE BO_ID='" + BoId + "'";
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

        public bool CheckCustomerCodeDuplicate(string custCode)
        {
            DataTable dataTable;
            string queryString = "";
            queryString = "SELECT Cust_Code FROM SBP_Customers WHERE Cust_Code='" + custCode + "'";
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
        public void Update(CustomerBasicInfoBO basicInfoBO, CustomerPersonalInfoBO personalInfoBO, CustomerContactDetailsBO contactDetailsBO, CustomerAdditionalInfoBO additionalInfoBO, CustomerBankDetailsBO bankDetailsBO, CustomerPassportInfoBO passportInfoBO, JointAccountHolderInfoBO jointHolderInfoBo, AuthorInroducerBO authorInroBO, CustomerModificationLogBO custModLogBo)
        {
            string queryStringBasicInfo = "";
            string queryStringPersonalInfo = "";
            string queryStringContactsInfo = "";
            string queryStringAdditionalInfo = "";
            string queryStringBankInfo = "";
            string queryStringPassportInfo = "";
            string queryStringJointInfo = "";
            string queryStringAuthor = "";

            CommonBAL commonBAL = new CommonBAL();
            custModLogBo.SlNo = commonBAL.GenerateID("SBP_Cust_Modification_Log", "Sl_No");
            //queryStringLog = "INSERT INTO SBP_Cust_Modification_Log(Sl_No,Cust_Code,Cust_Group,Special_Remarks,Cust_Open_Date,Cust_Close_Date,Cust_Status,Parent_Cust_Code,BO_ID,BO_Category,BO_Type,BO_Open_Date,Is_Officer_Director_SE,SE_Name_Address,Cust_Name,Father_Name,Mother_Name,DOB,Gender,Occupation,National_ID,Address1,Address2,Address3,City_Name,Post_Code,Division_Name,Country_Name,Phone,Mobile,Fax,Email,Recidency,Nationality,Statement_Cycle,Internal_Ref_No,Comp_Reg_No,Comp_Reg_Date,Acc_Link_Request,Acc_Link_BO_ID,Standing_Ins,Bank_Name,Branch_Name,Account_No,Is_EDC,Is_Tax_Exemption,TIN,Passport_No,Issue_Place,Issue_Date,Expire_Date,Joint_Name,Joint_Father_Name,Joint_Mother_Name,Joint_DOB,Joint_Gender,Joint_Nationality,Joint_National_ID,Joint_Address,Joint_Phone,Joint_Mobile,Joint_Email,Operation_Ins,Author_Name,Author_Address,Author_Mobile,Intro_Name,Intro_Address,Intro_BO_ID,Remarks,Modification_Time,Modification_Date,Modified_By)" +
            //    " VALUES(" + custModLogBo.SlNo + ",'" + custModLogBo.CustCode + "','" + custModLogBo.CustGroup + "','" + custModLogBo.SpecialInstruction + "','" + custModLogBo.CustomerOpenDate.ToShortDateString() + "',GETDATE(),'" + custModLogBo.CustStatus + "','" + custModLogBo.CustParentCode + "','" + custModLogBo.BoId + "','" + custModLogBo.BoCategory + "','" + custModLogBo.BoType + "','" + custModLogBo.BoOpenDate.ToShortDateString() + "'," + custModLogBo.IsDirSe + ",'" + custModLogBo.NameAddressSe + "','" + custModLogBo.AccountHolder + "','" + custModLogBo.FatherName + "','" + custModLogBo.MotherName + "','" + custModLogBo.DOb.ToShortDateString() + "','" + custModLogBo.Gender + "','" + custModLogBo.Occupation + "','" + custModLogBo.NationalId + "','" + custModLogBo.Address1 + "','" + custModLogBo.Address2 + "','" + custModLogBo.Address2 + "','" + custModLogBo.CityName + "','" + custModLogBo.PostCode + "'," + "'" + custModLogBo.DivisionName + "','" + custModLogBo.CountryName + "','" + custModLogBo.Telephone + "','" + custModLogBo.Mobile + "','" + custModLogBo.Fax + "','" + custModLogBo.Email + "','" + custModLogBo.Residency + "','" + custModLogBo.Nationality + "','" + custModLogBo.StatementCycle + "','" + custModLogBo.InternalRefNo + "','" + custModLogBo.CompanyRegNo + "','" + custModLogBo.CompanyRegDate.ToShortDateString() + "'," + custModLogBo.IsAccLinkRequest + ",'" + custModLogBo.AccLinkBo + "'," + custModLogBo.IsStandingIns + ",'" + custModLogBo.BankName + "','" + custModLogBo.BranchName + "','" + custModLogBo.AccountNo + "'," + custModLogBo.IsEdc + "," + custModLogBo.IsTaxExemption + ",'" + custModLogBo.Tin + "','" + custModLogBo.PassportNo + "','" + custModLogBo.IssuePlace + "','" + custModLogBo.IssueDate.ToShortDateString() + "','" + custModLogBo.ExpireDate.ToShortDateString() + "','" + custModLogBo.JointName + "','" + custModLogBo.JointFatherName + "','" + custModLogBo.JointMotherName + "','" + custModLogBo.JointDob.ToShortDateString() + "','" + custModLogBo.JointSex + "','" + custModLogBo.JointNationality + "','" + custModLogBo.JointNationalId + "'," + "'" + custModLogBo.JointAddress + "','" + custModLogBo.JoitnPhone + "','" + custModLogBo.JointMobile + "','" + custModLogBo.JointEmail + "','" + custModLogBo.OperatedBy + "','" + custModLogBo.AuthorName + "','" + custModLogBo.AuthorAddress + "','" + custModLogBo.AuthorMobile + "','" + custModLogBo.IntroName + "','" + custModLogBo.IntroAddress + "','" + custModLogBo.IntroBOID + "','" + custModLogBo.IntroRemarks + "',GETDATE(),GETDATE(),'" + GlobalVariableBO._userName + "')";

          

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();
                //_dbConnection.ExecuteNonQuery(queryStringLog);
                queryStringBasicInfo = @"SBPUpdateCustBasicInfo";
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@CustCode", SqlDbType.NVarChar, basicInfoBO.CustCode);
                _dbConnection.AddParameter("@CustGroup", SqlDbType.Int, basicInfoBO.CustGroup);
                _dbConnection.AddParameter("@SpecialInstrution", SqlDbType.VarChar, basicInfoBO.SpecialInstrution);
                _dbConnection.AddParameter("@CustParentCode", SqlDbType.Int, basicInfoBO.CustParentCode);
                _dbConnection.AddParameter("@CustOpenDate", SqlDbType.DateTime, basicInfoBO.CustOpenDate.ToShortDateString());
                _dbConnection.AddParameter("@Cust_Trans_Status_ID", SqlDbType.Int, basicInfoBO.Transaction_Status_ID);
                _dbConnection.AddParameter("@BOID", SqlDbType.NVarChar, basicInfoBO.BOID);
                _dbConnection.AddParameter("@BOCategory", SqlDbType.Int, basicInfoBO.BOCategory);
                _dbConnection.AddParameter("@BOType", SqlDbType.Int, basicInfoBO.BOType);
                _dbConnection.AddParameter("@BOOpenDate ", SqlDbType.DateTime, basicInfoBO.BOOpenDate.ToShortDateString());
                _dbConnection.AddParameter("@IsDirSE", SqlDbType.Int, basicInfoBO.IsDirSE);
                _dbConnection.AddParameter("@NameAddressSE", SqlDbType.VarChar, basicInfoBO.NameAddressSE);
                _dbConnection.AddParameter("@entryBy", SqlDbType.VarChar, GlobalVariableBO._userName);
                _dbConnection.AddParameter("@boStatusId", SqlDbType.Int, basicInfoBO.BOStatus); 
                
                _dbConnection.ExecuteNonQuery(queryStringBasicInfo);

                //if ( _dbConnection.ExecuteQuery("SELECT * FROM SBP_Cust_Personal_Info WHERE Cust_Code='" + personalInfoBO.CustCode+"'").Rows.Count>0)
                if (Exists("SELECT * FROM SBP_Cust_Personal_Info WHERE Cust_Code='" + personalInfoBO.CustCode + "'"))
                {
                    queryStringPersonalInfo = @"SBPUpdateCustPersonalInfo";
                    _dbConnection.ActiveStoredProcedure();
                    _dbConnection.AddParameter("@CustCode", SqlDbType.NVarChar, personalInfoBO.CustCode);
                    _dbConnection.AddParameter("@AccountHolder", SqlDbType.VarChar, personalInfoBO.AccountHolder);
                    _dbConnection.AddParameter("@FatherName", SqlDbType.VarChar, personalInfoBO.FatherName);
                    _dbConnection.AddParameter("@MotherName", SqlDbType.VarChar, personalInfoBO.MotherName);
                    _dbConnection.AddParameter("@DOB", SqlDbType.DateTime, personalInfoBO.DOB.ToShortDateString());
                    _dbConnection.AddParameter("@Gender", SqlDbType.NVarChar, personalInfoBO.Gender);
                    _dbConnection.AddParameter("@Occupation", SqlDbType.VarChar, personalInfoBO.Occupation);
                    _dbConnection.AddParameter("@NationalID", SqlDbType.VarChar, personalInfoBO.NationalID);
                    _dbConnection.AddParameter("@entryBy", SqlDbType.VarChar, GlobalVariableBO._userName);
                    _dbConnection.ExecuteNonQuery(queryStringPersonalInfo);
                }
                else
                {
                    queryStringPersonalInfo = @"SBPSaveCustPersonalInfo";
                    _dbConnection.ActiveStoredProcedure();
                    _dbConnection.AddParameter("@CustCode", SqlDbType.NVarChar, personalInfoBO.CustCode);
                    _dbConnection.AddParameter("@AccountHolder", SqlDbType.VarChar, personalInfoBO.AccountHolder);
                    _dbConnection.AddParameter("@FatherName", SqlDbType.VarChar, personalInfoBO.FatherName);
                    _dbConnection.AddParameter("@MotherName", SqlDbType.VarChar, personalInfoBO.MotherName);
                    _dbConnection.AddParameter("@DOB", SqlDbType.DateTime, personalInfoBO.DOB.ToShortDateString());
                    _dbConnection.AddParameter("@Gender", SqlDbType.NVarChar, personalInfoBO.Gender);
                    _dbConnection.AddParameter("@Occupation", SqlDbType.VarChar, personalInfoBO.Occupation);
                    _dbConnection.AddParameter("@NationalID", SqlDbType.VarChar, personalInfoBO.NationalID);
                    _dbConnection.AddParameter("@entryBy", SqlDbType.VarChar, GlobalVariableBO._userName);
                    _dbConnection.ExecuteNonQuery(queryStringPersonalInfo);

                }
                if (Exists("SELECT * FROM SBP_Cust_Contact_Info WHERE Cust_Code='" + contactDetailsBO.CustCode + "'"))
                {
                    queryStringContactsInfo = @"SBPUpdateCustContactsInfo";
                    _dbConnection.ActiveStoredProcedure();
                    _dbConnection.AddParameter("@CustCode", SqlDbType.NVarChar, contactDetailsBO.CustCode);
                    _dbConnection.AddParameter("@Address1", SqlDbType.VarChar, contactDetailsBO.Address1);
                    _dbConnection.AddParameter("@Address2", SqlDbType.VarChar, contactDetailsBO.Address2);
                    _dbConnection.AddParameter("@Address3", SqlDbType.VarChar, contactDetailsBO.Address3);
                    _dbConnection.AddParameter("@CityName", SqlDbType.VarChar, contactDetailsBO.CityName);
                    _dbConnection.AddParameter("@PostCode", SqlDbType.NVarChar, contactDetailsBO.PostCode);
                    _dbConnection.AddParameter("@DivisionName", SqlDbType.VarChar, contactDetailsBO.DivisionName);
                    _dbConnection.AddParameter("@CountryName", SqlDbType.VarChar, contactDetailsBO.CountryName);
                    _dbConnection.AddParameter("@Telephone", SqlDbType.NVarChar, contactDetailsBO.Telephone);
                    _dbConnection.AddParameter("@Mobile", SqlDbType.NVarChar, contactDetailsBO.Mobile);
                    _dbConnection.AddParameter("@CustomerFax", SqlDbType.NVarChar, contactDetailsBO.CustomerFax);
                    _dbConnection.AddParameter("@CustomerEmail", SqlDbType.NVarChar, contactDetailsBO.CustomerEmail);
                    _dbConnection.AddParameter("@entryBy", SqlDbType.VarChar, GlobalVariableBO._userName);
                    _dbConnection.ExecuteNonQuery(queryStringContactsInfo);
                }
                else
                {
                    queryStringContactsInfo = @"SBPSaveCustContactsInfo";
                    _dbConnection.ActiveStoredProcedure();
                    _dbConnection.AddParameter("@CustCode", SqlDbType.NVarChar, contactDetailsBO.CustCode);
                    _dbConnection.AddParameter("@Address1", SqlDbType.VarChar, contactDetailsBO.Address1);
                    _dbConnection.AddParameter("@Address2", SqlDbType.VarChar, contactDetailsBO.Address2);
                    _dbConnection.AddParameter("@Address3", SqlDbType.VarChar, contactDetailsBO.Address3);
                    _dbConnection.AddParameter("@CityName", SqlDbType.VarChar, contactDetailsBO.CityName);
                    _dbConnection.AddParameter("@PostCode", SqlDbType.NVarChar, contactDetailsBO.PostCode);
                    _dbConnection.AddParameter("@DivisionName", SqlDbType.VarChar, contactDetailsBO.DivisionName);
                    _dbConnection.AddParameter("@CountryName", SqlDbType.VarChar, contactDetailsBO.CountryName);
                    _dbConnection.AddParameter("@Telephone", SqlDbType.NVarChar, contactDetailsBO.Telephone);
                    _dbConnection.AddParameter("@Mobile", SqlDbType.NVarChar, contactDetailsBO.Mobile);
                    _dbConnection.AddParameter("@CustomerFax", SqlDbType.NVarChar, contactDetailsBO.CustomerFax);
                    _dbConnection.AddParameter("@CustomerEmail", SqlDbType.NVarChar, contactDetailsBO.CustomerEmail);
                    _dbConnection.AddParameter("@entryBy", SqlDbType.VarChar, GlobalVariableBO._userName);
                    _dbConnection.ExecuteNonQuery(queryStringContactsInfo);

                }
                if (Exists("SELECT * FROM SBP_Cust_Additional_Info WHERE Cust_Code='" + additionalInfoBO.CustCode + "'"))
                {
                    queryStringAdditionalInfo = @"SBPUpdateCustAdditionalInfo";
                    _dbConnection.ActiveStoredProcedure();
                    _dbConnection.AddParameter("@CustCode", SqlDbType.NVarChar, additionalInfoBO.CustCode);
                    _dbConnection.AddParameter("@Residency", SqlDbType.VarChar, additionalInfoBO.Residency);
                    _dbConnection.AddParameter("@Assigned_WorkStation", SqlDbType.VarChar, additionalInfoBO.AssignedWorkstation);
                    _dbConnection.AddParameter("@Net_Adjustment", SqlDbType.VarChar, additionalInfoBO.Net_Adjustment);
                    _dbConnection.AddParameter("@Nationality", SqlDbType.NVarChar, additionalInfoBO.Nationality);
                    _dbConnection.AddParameter("@StatementCycleID", SqlDbType.Int, additionalInfoBO.StatementCycleID);
                    _dbConnection.AddParameter("@InternalRefNo", SqlDbType.NVarChar, additionalInfoBO.InternalRefNo);
                    _dbConnection.AddParameter("@CompanyRegNo", SqlDbType.NVarChar, additionalInfoBO.CompanyRegNo);
                    _dbConnection.AddParameter("@CompanyRegDate", SqlDbType.DateTime, additionalInfoBO.CompanyRegDate.ToShortDateString());
                    _dbConnection.AddParameter("@IsAccLinkRequest", SqlDbType.Bit, additionalInfoBO.IsAccLinkRequest);
                    _dbConnection.AddParameter("@AccLinkBo", SqlDbType.NVarChar, additionalInfoBO.AccLinkBo);
                    _dbConnection.AddParameter("@IsStandingIns", SqlDbType.Bit, additionalInfoBO.IsStandingIns);
                    _dbConnection.AddParameter("@entryBy", SqlDbType.VarChar, GlobalVariableBO._userName);
                    _dbConnection.ExecuteNonQuery(queryStringAdditionalInfo);
                }
                else
                {
                    queryStringAdditionalInfo = @"SBPSaveCustAdditionalInfo";
                    _dbConnection.ActiveStoredProcedure();
                    _dbConnection.AddParameter("@CustCode", SqlDbType.NVarChar, additionalInfoBO.CustCode);
                    _dbConnection.AddParameter("@Residency", SqlDbType.VarChar, additionalInfoBO.Residency);
                    _dbConnection.AddParameter("@Assigned_WorkStation", SqlDbType.VarChar, additionalInfoBO.AssignedWorkstation);
                    _dbConnection.AddParameter("@Net_Adjustment", SqlDbType.VarChar, additionalInfoBO.Net_Adjustment);
                    _dbConnection.AddParameter("@Nationality", SqlDbType.NVarChar, additionalInfoBO.Nationality);
                    _dbConnection.AddParameter("@StatementCycleID", SqlDbType.Int, additionalInfoBO.StatementCycleID);
                    _dbConnection.AddParameter("@InternalRefNo", SqlDbType.NVarChar, additionalInfoBO.InternalRefNo);
                    _dbConnection.AddParameter("@CompanyRegNo", SqlDbType.NVarChar, additionalInfoBO.CompanyRegNo);
                    _dbConnection.AddParameter("@CompanyRegDate", SqlDbType.DateTime, additionalInfoBO.CompanyRegDate.ToShortDateString());
                    _dbConnection.AddParameter("@IsAccLinkRequest", SqlDbType.Bit, additionalInfoBO.IsAccLinkRequest);
                    _dbConnection.AddParameter("@AccLinkBo", SqlDbType.NVarChar, additionalInfoBO.AccLinkBo);
                    _dbConnection.AddParameter("@IsStandingIns", SqlDbType.Bit, additionalInfoBO.IsStandingIns);
                    _dbConnection.AddParameter("@entryBy", SqlDbType.VarChar, GlobalVariableBO._userName);
                    _dbConnection.ExecuteNonQuery(queryStringAdditionalInfo);
                }



                if (Exists("SELECT * FROM SBP_Cust_Bank_Info WHERE Cust_Code='" + bankDetailsBO.CustCode + "'"))
                {
                    queryStringBankInfo = @"SBPUpdateCustBankInfo";
                    _dbConnection.ActiveStoredProcedure();
                    _dbConnection.AddParameter("@CustCode", SqlDbType.NVarChar, bankDetailsBO.CustCode);
                    _dbConnection.AddParameter("@Bank_ID", SqlDbType.Int, bankDetailsBO.Bank_ID);
                    _dbConnection.AddParameter("@BankName", SqlDbType.VarChar, bankDetailsBO.BankName);
                    _dbConnection.AddParameter("@Branch_ID", SqlDbType.Int, bankDetailsBO.Branch_ID);
                    _dbConnection.AddParameter("@BranchName", SqlDbType.VarChar, bankDetailsBO.BranchName);
                    _dbConnection.AddParameter("@AccountNo", SqlDbType.NVarChar, bankDetailsBO.AccountNo);
                    _dbConnection.AddParameter("@Account_Type", SqlDbType.NVarChar, bankDetailsBO.AccountType);
                    _dbConnection.AddParameter("@IsEDC", SqlDbType.Bit, bankDetailsBO.IsEDC);
                    _dbConnection.AddParameter("@IsTaxExemption", SqlDbType.Bit, bankDetailsBO.IsTaxExemption);
                    _dbConnection.AddParameter("@TIN", SqlDbType.NVarChar, bankDetailsBO.TIN);
                    _dbConnection.AddParameter("@SWIFT_Code", SqlDbType.NVarChar, bankDetailsBO.SWIFT_Code);
                    _dbConnection.AddParameter("@IBAN", SqlDbType.NVarChar, bankDetailsBO.IBAN);
                    _dbConnection.AddParameter("@Routing_No", SqlDbType.NVarChar, bankDetailsBO.Routing_No);
                    _dbConnection.AddParameter("@District_Name", SqlDbType.NVarChar, bankDetailsBO.District_Name);

                    _dbConnection.AddParameter("@entryBy", SqlDbType.VarChar, GlobalVariableBO._userName);
                    _dbConnection.ExecuteNonQuery(queryStringBankInfo);
                }
                else
                {
                    queryStringBankInfo = @"SBPSaveCustBankInfo";
                    _dbConnection.ActiveStoredProcedure();
                    _dbConnection.AddParameter("@CustCode", SqlDbType.NVarChar, bankDetailsBO.CustCode);
                    _dbConnection.AddParameter("@Bank_ID", SqlDbType.Int, bankDetailsBO.Bank_ID);
                    _dbConnection.AddParameter("@BankName", SqlDbType.VarChar, bankDetailsBO.BankName);
                    _dbConnection.AddParameter("@Branch_ID", SqlDbType.Int, bankDetailsBO.Branch_ID);
                    _dbConnection.AddParameter("@BranchName", SqlDbType.VarChar, bankDetailsBO.BranchName);
                    _dbConnection.AddParameter("@AccountNo", SqlDbType.NVarChar, bankDetailsBO.AccountNo);
                    _dbConnection.AddParameter("@Account_Type", SqlDbType.NVarChar, bankDetailsBO.AccountType);
                    _dbConnection.AddParameter("@IsEDC", SqlDbType.Bit, bankDetailsBO.IsEDC);
                    _dbConnection.AddParameter("@IsTaxExemption", SqlDbType.Bit, bankDetailsBO.IsTaxExemption);
                    _dbConnection.AddParameter("@TIN", SqlDbType.NVarChar, bankDetailsBO.TIN);
                    _dbConnection.AddParameter("@SWIFT_Code", SqlDbType.NVarChar, bankDetailsBO.SWIFT_Code);
                    _dbConnection.AddParameter("@IBAN", SqlDbType.NVarChar, bankDetailsBO.IBAN);
                    _dbConnection.AddParameter("@Routing_No", SqlDbType.NVarChar, bankDetailsBO.Routing_No);
                    _dbConnection.AddParameter("@District_Name", SqlDbType.NVarChar, bankDetailsBO.District_Name);

                    _dbConnection.AddParameter("@entryBy", SqlDbType.VarChar, GlobalVariableBO._userName);
                    _dbConnection.ExecuteNonQuery(queryStringBankInfo);

                }

                if (Exists("SELECT * FROM SBP_Cust_Passport_Info WHERE Cust_Code='" + passportInfoBO.CustCode + "'"))
                {

                    queryStringPassportInfo = @"SBPUpdateCustPassportInfo";
                    _dbConnection.ActiveStoredProcedure();
                    _dbConnection.AddParameter("@CustCode", SqlDbType.NVarChar, passportInfoBO.CustCode);
                    _dbConnection.AddParameter("@PassportNo", SqlDbType.NVarChar, passportInfoBO.PassportNo);
                    _dbConnection.AddParameter("@IssuePlace", SqlDbType.NVarChar, passportInfoBO.IssuePlace);
                    _dbConnection.AddParameter("@IssueDate", SqlDbType.DateTime, passportInfoBO.IssueDate.ToShortDateString());
                    _dbConnection.AddParameter("@ExpireDate", SqlDbType.DateTime, passportInfoBO.ExpireDate.ToShortDateString());
                    _dbConnection.AddParameter("@entryBy", SqlDbType.VarChar, GlobalVariableBO._userName);
                    _dbConnection.ExecuteNonQuery(queryStringPassportInfo);
                }
                else
                {
                 queryStringPassportInfo = @"SBPSaveCustPassportInfo";
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@CustCode", SqlDbType.NVarChar, passportInfoBO.CustCode);
                _dbConnection.AddParameter("@PassportNo", SqlDbType.NVarChar, passportInfoBO.PassportNo);
                _dbConnection.AddParameter("@IssuePlace", SqlDbType.NVarChar, passportInfoBO.IssuePlace);
                _dbConnection.AddParameter("@IssueDate", SqlDbType.DateTime, passportInfoBO.IssueDate.ToShortDateString());
                _dbConnection.AddParameter("@ExpireDate", SqlDbType.DateTime, passportInfoBO.ExpireDate.ToShortDateString());
                _dbConnection.AddParameter("@entryBy", SqlDbType.VarChar, GlobalVariableBO._userName);
                _dbConnection.ExecuteNonQuery(queryStringPassportInfo);
                }




                if (Exists("SELECT * FROM SBP_Joint_holder WHERE Cust_Code='" + jointHolderInfoBo.JointCustCode + "'"))
                {
                    queryStringJointInfo = @"SBPUpdateJointInfo";
                    _dbConnection.ActiveStoredProcedure();
                    _dbConnection.AddParameter("@JointCustCode", SqlDbType.NVarChar, jointHolderInfoBo.JointCustCode);
                    _dbConnection.AddParameter("@JointName", SqlDbType.VarChar, jointHolderInfoBo.JointName);
                    _dbConnection.AddParameter("@JointFatherName", SqlDbType.VarChar, jointHolderInfoBo.JointFatherName);
                    _dbConnection.AddParameter("@JointMotherName", SqlDbType.VarChar, jointHolderInfoBo.JointMotherName);
                    _dbConnection.AddParameter("@JointDOB", SqlDbType.DateTime, jointHolderInfoBo.JointDOB.ToShortDateString());
                    _dbConnection.AddParameter("@JointSex", SqlDbType.VarChar, jointHolderInfoBo.JointSex);
                    _dbConnection.AddParameter("@JointNationality", SqlDbType.VarChar, jointHolderInfoBo.JointNationality);
                    _dbConnection.AddParameter("@JointNationalId", SqlDbType.NVarChar, jointHolderInfoBo.JointNationalId);
                    _dbConnection.AddParameter("@JointAddress", SqlDbType.VarChar, jointHolderInfoBo.JointAddress);
                    _dbConnection.AddParameter("@JoitnPhone", SqlDbType.NVarChar, jointHolderInfoBo.JoitnPhone);
                    _dbConnection.AddParameter("@JointMobile ", SqlDbType.NVarChar, jointHolderInfoBo.JointMobile);
                    _dbConnection.AddParameter("@JointEmail", SqlDbType.NVarChar, jointHolderInfoBo.JointEmail);
                    _dbConnection.AddParameter("@JointOperatedBy", SqlDbType.NVarChar, jointHolderInfoBo.JointOperatedBy);
                    _dbConnection.AddParameter("@entryBy", SqlDbType.VarChar, GlobalVariableBO._userName);
                    _dbConnection.ExecuteNonQuery(queryStringJointInfo);
                }
                else
                {
                    queryStringJointInfo = @"SBPSaveJointInfo";
                    _dbConnection.ActiveStoredProcedure();
                    _dbConnection.AddParameter("@JointCustCode", SqlDbType.NVarChar, jointHolderInfoBo.JointCustCode);
                    _dbConnection.AddParameter("@JointName", SqlDbType.VarChar, jointHolderInfoBo.JointName);
                    _dbConnection.AddParameter("@JointFatherName", SqlDbType.VarChar, jointHolderInfoBo.JointFatherName);
                    _dbConnection.AddParameter("@JointMotherName", SqlDbType.VarChar, jointHolderInfoBo.JointMotherName);
                    _dbConnection.AddParameter("@JointDOB", SqlDbType.DateTime, jointHolderInfoBo.JointDOB.ToShortDateString());
                    _dbConnection.AddParameter("@JointSex", SqlDbType.VarChar, jointHolderInfoBo.JointSex);
                    _dbConnection.AddParameter("@JointNationality", SqlDbType.VarChar, jointHolderInfoBo.JointNationality);
                    _dbConnection.AddParameter("@JointNationalId", SqlDbType.NVarChar, jointHolderInfoBo.JointNationalId);
                    _dbConnection.AddParameter("@JointAddress", SqlDbType.VarChar, jointHolderInfoBo.JointAddress);
                    _dbConnection.AddParameter("@JoitnPhone", SqlDbType.NVarChar, jointHolderInfoBo.JoitnPhone);
                    _dbConnection.AddParameter("@JointMobile ", SqlDbType.NVarChar, jointHolderInfoBo.JointMobile);
                    _dbConnection.AddParameter("@JointEmail", SqlDbType.NVarChar, jointHolderInfoBo.JointEmail);
                    _dbConnection.AddParameter("@JointOperatedBy", SqlDbType.NVarChar, jointHolderInfoBo.JointOperatedBy);
                    _dbConnection.AddParameter("@entryBy", SqlDbType.VarChar, GlobalVariableBO._userName);
                    _dbConnection.ExecuteNonQuery(queryStringJointInfo);
                }


                if (Exists("SELECT * FROM SBP_INTRO_AUTHOR WHERE Cust_Code='" + jointHolderInfoBo.JointCustCode + "'"))
                {
                    queryStringAuthor = @"SBPUpdateIntroAuthorInfo";
                    _dbConnection.ActiveStoredProcedure();
                    _dbConnection.AddParameter("@AuthorCustCode", SqlDbType.NVarChar, authorInroBO.AuthorCustCode);
                    _dbConnection.AddParameter("@AuthorName", SqlDbType.VarChar, authorInroBO.AuthorName);
                    _dbConnection.AddParameter("@AuthorAddress", SqlDbType.VarChar, authorInroBO.AuthorAddress);
                    _dbConnection.AddParameter("@AuthorMobile", SqlDbType.NVarChar, authorInroBO.AuthorMobile);
                    _dbConnection.AddParameter("@IntroName", SqlDbType.VarChar, authorInroBO.IntroName);
                    _dbConnection.AddParameter("@IntroAddress", SqlDbType.VarChar, authorInroBO.IntroAddress);
                    _dbConnection.AddParameter("@IntroBOID", SqlDbType.NVarChar, authorInroBO.IntroBOID);
                    _dbConnection.AddParameter("@IntroRemarks", SqlDbType.VarChar, authorInroBO.IntroRemarks);
                    _dbConnection.AddParameter("@entryBy", SqlDbType.VarChar, GlobalVariableBO._userName);
                    _dbConnection.ExecuteNonQuery(queryStringAuthor);
                }
                else
                {
                    queryStringAuthor = @"SBPSaveIntroAuthorInfo";
                    _dbConnection.ActiveStoredProcedure();
                    _dbConnection.AddParameter("@AuthorCustCode", SqlDbType.NVarChar, authorInroBO.AuthorCustCode);
                    _dbConnection.AddParameter("@AuthorName", SqlDbType.VarChar, authorInroBO.AuthorName);
                    _dbConnection.AddParameter("@AuthorAddress", SqlDbType.VarChar, authorInroBO.AuthorAddress);
                    _dbConnection.AddParameter("@AuthorMobile", SqlDbType.NVarChar, authorInroBO.AuthorMobile);
                    _dbConnection.AddParameter("@IntroName", SqlDbType.VarChar, authorInroBO.IntroName);
                    _dbConnection.AddParameter("@IntroAddress", SqlDbType.VarChar, authorInroBO.IntroAddress);
                    _dbConnection.AddParameter("@IntroBOID", SqlDbType.NVarChar, authorInroBO.IntroBOID);
                    _dbConnection.AddParameter("@IntroRemarks", SqlDbType.VarChar, authorInroBO.IntroRemarks);
                    _dbConnection.AddParameter("@entryBy", SqlDbType.VarChar, GlobalVariableBO._userName);
                    _dbConnection.ExecuteNonQuery(queryStringAuthor);
                }
                _dbConnection.Commit();
            }
            catch (Exception)
            {
                _dbConnection.Rollback();
                throw;
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
//            queryString = "SELECT SBP_Customers.Cust_Code,Cust_Group_ID,Special_Remarks,Cust_Open_Date,Cust_Close_Date,Cust_Status_ID,Cust_Trans_Status_ID,Parent_Cust_Code,BO_ID,BO_Category_ID,BO_Type_ID,BO_Open_Date,BO_Close_Date,BO_Status_ID,Is_Officer_Director_SE,SE_Name_Address,Cust_Name,Father_Name,Mother_Name,DOB,Gender,Occupation,National_ID,Address1,Address2,Address3," +
//"City_Name,Post_Code,Division_Name,Country_Name,Phone,Mobile,Fax,Email,Recidency,Nationality,Statement_Cycle_ID,Internal_Ref_No,Comp_Reg_No,Comp_Reg_Date,Acc_Link_Request,Acc_Link_BO_ID,Standing_Ins,SBP_Cust_Bank_Info.Bank_ID,Bank_Name,SBP_Cust_Bank_Info.Branch_ID,Branch_Name,Account_No,Account_Type,Is_EDC,Is_Tax_Exemption,TIN,SWIFT_Code,IBAN,Routing_No,District_Name,Passport_No,Issue_Place,Issue_Date,Expire_Date,Joint_Name,Joint_Father_Name,Joint_Mother_Name," +
//"Joint_DOB,Joint_Gender,Joint_Nationality,Joint_National_ID,Joint_Address,Joint_Phone,Joint_Mobile,Joint_Email,Operation_Ins,Author_Name,Author_Address,Author_Mobile,Intro_Name,Intro_Address,Intro_BO_ID,Remarks" +
//" FROM SBP_Customers LEFT OUTER JOIN SBP_Cust_Personal_info ON SBP_Customers.Cust_Code=SBP_Cust_Personal_info.Cust_Code LEFT OUTER JOIN SBP_Cust_Contact_Info ON SBP_Customers.Cust_Code=SBP_Cust_Contact_Info.Cust_Code LEFT OUTER JOIN SBP_Cust_Additional_Info ON SBP_Customers.Cust_Code=SBP_Cust_Additional_Info.Cust_Code LEFT OUTER JOIN SBP_Cust_Bank_Info ON SBP_Customers.Cust_Code=SBP_Cust_Bank_Info.Cust_Code" +
//" LEFT OUTER JOIN SBP_Cust_Passport_Info ON SBP_Customers.Cust_Code=SBP_Cust_Passport_Info.Cust_Code LEFT OUTER JOIN SBP_Joint_holder ON SBP_Customers.Cust_Code=SBP_Joint_holder.Cust_Code LEFT OUTER JOIN SBP_Intro_Author ON SBP_Customers.Cust_Code=SBP_Intro_Author.Cust_Code WHERE SBP_Customers.Cust_Code='" + custCode + "'";

            queryString = "SELECT SBP_Customers.Cust_Code,SBP_Customers.BO_Status_ID,Cust_Group_ID,Special_Remarks,Cust_Open_Date,Cust_Close_Date,Cust_Status_ID,Cust_Trans_Status_ID,Parent_Cust_Code,BO_ID,BO_Category_ID,BO_Type_ID,BO_Open_Date,BO_Close_Date,BO_Status_ID,Is_Officer_Director_SE,SE_Name_Address,Cust_Name,Father_Name,Mother_Name,DOB,Gender,Occupation,National_ID,Address1,Address2,Address3," +
"City_Name,Post_Code,Division_Name,Country_Name,Phone,Mobile,Fax,Email,Recidency,Assigned_WorkStation,Net_Adjustment,Nationality,Statement_Cycle_ID,Internal_Ref_No,Comp_Reg_No,Comp_Reg_Date,Acc_Link_Request,Acc_Link_BO_ID,Standing_Ins,SBP_Cust_Bank_Info.Bank_ID,Bank_Name,SBP_Cust_Bank_Info.Branch_ID,Branch_Name,Account_No,Account_Type,Is_EDC,Is_Tax_Exemption,TIN,SWIFT_Code,IBAN,Routing_No,District_Name,Passport_No,Issue_Place,Issue_Date,Expire_Date,Joint_Name,Joint_Father_Name,Joint_Mother_Name," +
"Joint_DOB,Joint_Gender,Joint_Nationality,Joint_National_ID,Joint_Address,Joint_Phone,Joint_Mobile,Joint_Email,Operation_Ins,Author_Name,Author_Address,Author_Mobile,Intro_Name,Intro_Address,Intro_BO_ID,Remarks" +
" FROM SBP_Customers LEFT OUTER JOIN SBP_Cust_Personal_info ON SBP_Customers.Cust_Code=SBP_Cust_Personal_info.Cust_Code LEFT OUTER JOIN SBP_Cust_Contact_Info ON SBP_Customers.Cust_Code=SBP_Cust_Contact_Info.Cust_Code LEFT OUTER JOIN SBP_Cust_Additional_Info ON SBP_Customers.Cust_Code=SBP_Cust_Additional_Info.Cust_Code LEFT OUTER JOIN SBP_Cust_Bank_Info ON SBP_Customers.Cust_Code=SBP_Cust_Bank_Info.Cust_Code" +
" LEFT OUTER JOIN SBP_Cust_Passport_Info ON SBP_Customers.Cust_Code=SBP_Cust_Passport_Info.Cust_Code LEFT OUTER JOIN SBP_Joint_holder ON SBP_Customers.Cust_Code=SBP_Joint_holder.Cust_Code LEFT OUTER JOIN SBP_Intro_Author ON SBP_Customers.Cust_Code=SBP_Intro_Author.Cust_Code WHERE SBP_Customers.Cust_Code='" + custCode + "'";
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

        public DataTable GetCustomerCode(string boID)
        {
            DataTable dataTable=new DataTable();
            string queryString = "";
            queryString = "SELECT Cust_Code FROM SBP_Customers WHERE BO_ID='" + boID + "'";
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

        public DataTable GetCustInfoByBOID(string boId)
        {
            DataTable dataTable;
            string queryString = "";
            queryString = "SELECT SBP_Customers.Cust_Code as 'Cust_Code',Cust_Name,BO_Id,ISNULL(dbo.GetLastTradeDateTimeByCust(dbo.GetCustCodeFromBO('" + boId + "')),'Not Yet Trade') AS 'LTD',(SELECT Cust_Status FROM SBP_Cust_Status WHERE SBP_Cust_Status.Cust_Status_ID=SBP_Customers.Cust_Status_ID)AS Status,(SELECT BO_Status FROM SBP_BO_Status WHERE BO_Status_ID=SBP_Customers.BO_Status_ID) AS 'BO_Status',ISNULL((SELECT SUM(Balance) FROM SBP_Share_Balance_Temp WHERE SBP_Share_Balance_Temp.Cust_Code=SBP_Customers.Cust_Code),0) AS Share_Balance,(SELECT BO_Type FROM SBP_BO_Type WHERE BO_Type_ID=SBP_Customers.BO_Type_ID AND SBP_Customers.BO_ID='" + boId + "') AS 'BO Type'  FROM SBP_Customers,SBP_Cust_Personal_Info WHERE BO_ID='" + boId + "' AND SBP_Customers.Cust_Code=SBP_Cust_Personal_Info.Cust_Code";
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

        public DataTable IsExistNewCustomerCode(string custCode)
        {
            DataTable dataTable;
            string queryString = "";
            queryString = "SELECT Cust_Code,BO_ID FROM SBP_Customers WHERE Cust_Code='" + custCode + "'";
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

        /// <summary>
        /// Update By Rashedul Hasan On 11 may 2015
        /// Add only residency column for NRB Application
        /// </summary>
        /// <param name="custCode"></param>
        /// <returns></returns>
        public DataTable GetCustInfoByCustCode(string custCode)
        {
            DataTable dataTable;
            string queryString = "";
            queryString = "SELECT SBP_Customers.Cust_Code as 'Cust_Code',Cust_Name,BO_Id,(Select Recidency From SBP_Cust_Additional_Info where Cust_Code=SBP_Customers.Cust_Code And Cust_Code='" + custCode + "') As Recidency,ISNULL(dbo.GetLastTradeDateTimeByCust('" + custCode + "'),'Not Yet Trade') AS 'LTD',(SELECT Cust_Status FROM SBP_Cust_Status WHERE SBP_Cust_Status.Cust_Status_ID=SBP_Customers.Cust_Status_ID)AS Status,(SELECT BO_Status FROM SBP_BO_Status WHERE BO_Status_ID=SBP_Customers.BO_Status_ID) AS 'BO_Status',ISNULL((SELECT SUM(Balance) FROM SBP_Share_Balance_Temp WHERE SBP_Share_Balance_Temp.Cust_Code=SBP_Customers.Cust_Code),0)AS Share_Balance,(SELECT BO_Type FROM SBP_BO_Type WHERE BO_Type_ID=SBP_Customers.BO_Type_ID AND SBP_Customers.Cust_Code='" + custCode + "') AS 'BO Type' FROM SBP_Customers,SBP_Cust_Personal_Info WHERE SBP_Customers.Cust_Code='" + custCode + "' AND SBP_Customers.Cust_Code=SBP_Cust_Personal_Info.Cust_Code";
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

        public DataTable Flex_Tp_Cash_Limit_Cust_Searching(string Cust_Code)
        {
            DataTable dt = new DataTable();
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                string Proc = "Proc_Flex_TP_Cash_Limit_Cust_Wise";
                _dbConnection.AddParameter("@Cust_Code", SqlDbType.VarChar, Cust_Code);
                dt = _dbConnection.ExecuteProQuery(Proc);
                _dbConnection.CloseDatabase();

            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }
        public void CloseCustomer(CustomerCloseInfoBO closeInfoBo)
        {
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();
                CommonBAL commonBAL = new CommonBAL();
                string closeCustQry = "";
                closeCustQry = @"SBPCloseCustomer";
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@CustCode", SqlDbType.NVarChar, closeInfoBo.CustCode);
                _dbConnection.AddParameter("@ClosingCharge", SqlDbType.Float, closeInfoBo.ClosingCharge);
                _dbConnection.AddParameter("@VoucherNo", SqlDbType.NVarChar, closeInfoBo.VoucherNo);
                _dbConnection.AddParameter("@ClosingDate", SqlDbType.DateTime, closeInfoBo.ClosingDate);
                _dbConnection.AddParameter("@entryBy", SqlDbType.VarChar, GlobalVariableBO._userName);
                _dbConnection.AddParameter("@paymentMedia", SqlDbType.VarChar, closeInfoBo.PaymentMedia);
                _dbConnection.AddParameter("@Branch_ID", SqlDbType.Int, GlobalVariableBO._branchId);
                _dbConnection.ExecuteNonQuery(closeCustQry);
                _dbConnection.Commit();
            }
            catch (Exception)
            {
                _dbConnection.Rollback();
                throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
        }

        public bool CheckClosingStatus(string custCode)
        {
            DataTable dataTable;
            string queryString = "";
            queryString = "SELECT SBP_Customers.Cust_Code FROM SBP_Customers WHERE Cust_Code='" + custCode + "' AND Cust_Status_ID=2";
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
                return false;
            }
            else
            {
                return true;
            }

        }

        public DataTable GetAllDataForLog(string custCode)
        {
            DataTable dataTable;
            string queryString = "";
            queryString = "SELECT SBP_Customers.Cust_Code,SBP_Customers.BO_Status_ID,Cust_Group,Special_Remarks,Cust_Open_Date,Cust_Close_Date,Cust_Status,Parent_Cust_Code,BO_ID,BO_Category,BO_Type,BO_Open_Date,Is_Officer_Director_SE,SE_Name_Address,Cust_Name,Father_Name,Mother_Name,DOB,Gender,Occupation,National_ID,Address1,Address2,Address3,City_Name,Post_Code,Division_Name,Country_Name,Phone,Mobile,Fax,Email,Recidency,Nationality,Statement_Cycle,Internal_Ref_No,Comp_Reg_No,Comp_Reg_Date,Acc_Link_Request,Acc_Link_BO_ID,Standing_Ins," +
"SBP_Cust_Bank_Info.Bank_ID,Bank_Name,SBP_Cust_Bank_Info.Branch_ID,Branch_Name,Account_No,Account_Type,Is_EDC,Is_Tax_Exemption,TIN,SWIFT_Code,IBAN,Routing_No,District_Name,Passport_No,Issue_Place,Issue_Date,Expire_Date,Joint_Name,Joint_Father_Name,Joint_Mother_Name,Joint_DOB,Joint_Gender,Joint_Nationality,Joint_National_ID,Joint_Address,Joint_Phone,Joint_Mobile,Joint_Email,Operation_Ins,Author_Name,Author_Address,Author_Mobile,Intro_Name,Intro_Address,Intro_BO_ID,Remarks" +
" FROM SBP_Customers LEFT OUTER JOIN SBP_Cust_Personal_info ON SBP_Customers.Cust_Code=SBP_Cust_Personal_info.Cust_Code LEFT OUTER JOIN SBP_Cust_Contact_Info ON SBP_Customers.Cust_Code=SBP_Cust_Contact_Info.Cust_Code LEFT OUTER JOIN SBP_Cust_Additional_Info ON SBP_Customers.Cust_Code=SBP_Cust_Additional_Info.Cust_Code LEFT OUTER JOIN SBP_Cust_Bank_Info ON SBP_Customers.Cust_Code=SBP_Cust_Bank_Info.Cust_Code" +
" LEFT OUTER JOIN SBP_Cust_Passport_Info ON SBP_Customers.Cust_Code=SBP_Cust_Passport_Info.Cust_Code LEFT OUTER JOIN SBP_Joint_holder ON SBP_Customers.Cust_Code=SBP_Joint_holder.Cust_Code LEFT OUTER JOIN SBP_Intro_Author ON SBP_Customers.Cust_Code=SBP_Intro_Author.Cust_Code LEFT OUTER JOIN SBP_Cust_Status ON SBP_Customers.Cust_Status_ID=SBP_Cust_Status.Cust_Status_ID LEFT OUTER JOIN SBP_Cust_Group ON SBP_Customers.Cust_Group_ID=SBP_Cust_Group.Cust_Group_ID" +
" LEFT OUTER JOIN SBP_Statement_Cycle ON SBP_Cust_Additional_Info.Statement_Cycle_ID=SBP_Statement_Cycle.Statement_Cycle_ID LEFT OUTER JOIN SBP_BO_Category ON SBP_Customers.BO_Category_ID=SBP_BO_Category.BO_Category_ID LEFT OUTER JOIN SBP_BO_Type ON SBP_Customers.BO_Type_ID=SBP_BO_Type.BO_Type_ID WHERE SBP_Customers.Cust_Code='" + custCode + "'";
           
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

        public float GetCurrentBalane(string custCode)
        {
            float currentBalance = 0;
            DataTable dataTable;
            string queryString = "SELECT dbo.GetCurrentMoneyBalance('" + custCode + "')";

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

            if (dataTable.Rows[0][0] != DBNull.Value)
                currentBalance = float.Parse(dataTable.Rows[0][0].ToString());

            return currentBalance;
        }

        public float GetMaturedBalane(string custCode)
        {
            float matureBalance = 0;
            DataTable dataTable;
            string queryString = "SELECT dbo.GetCurrentMoneyBalance('" + custCode + "')";

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

            if (dataTable.Rows[0][0] != DBNull.Value)
                matureBalance = float.Parse(dataTable.Rows[0][0].ToString());

            return matureBalance;
        }

        public DataTable GetDefaultRedeemedAmnt()
        {
            DataTable dataTable;
            string queryString = "";
            queryString = "SELECT TOP 1 Closing_Charge FROM SBP_Account_Closing_Charge WHERE Effective_Date=(SELECT MAX(Effective_Date) FROM SBP_Account_Closing_Charge) ORDER BY Ch_ID DESC";
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

        public bool IsPending(string Cust_Code)
        {
            DataTable dataTable;
            bool isPending = false;
            string queryString = "";
            queryString = @"SELECT * 
                            FROM dbo.SBP_Customers 
                            WHERE Cust_Code='" + Cust_Code + "' AND Cust_Status_ID=3 ";
            try
            {
                _dbConnection.ConnectDatabase();
                dataTable = _dbConnection.ExecuteQuery(queryString);
                if (dataTable.Rows.Count > 0)
                {
                    isPending = true;
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
            return isPending;
        }

        public void UpdatePendingStatus(string cust_code)
        {
            string updateQuery = "";
            updateQuery = @"UPDATE
                            dbo.SBP_Customers 
                            SET Cust_Status_ID=1, BO_Status_ID=1
                            WHERE Cust_Code='" + cust_code + "' AND Cust_Status_ID=3";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(updateQuery);
            }
            catch
            {
                throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
        }

        /// <summary>
        /// Only Work Station Load 
        /// Rashedul Hasan
        /// 08-July-2015
        /// </summary>
        /// <returns></returns>
        public DataTable GetWorkStationName()
        {
            DataTable dt = new DataTable();
            string query = @"select 'N/A' as 'WorkStation_Name'
                            union
                            select WorkStation_Name from dbo.SBP_Workstation
                            order By WorkStation_Name desc";
            try
            {
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


    }
}