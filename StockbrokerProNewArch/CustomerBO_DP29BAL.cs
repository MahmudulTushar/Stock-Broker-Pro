using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using BusinessAccessLayer.BO;
using System.Data;
using System.Data.SqlClient;

namespace BusinessAccessLayer.BAL
{
   public class CustomerBO_DP29BAL
   {
       string  error;
       private DbConnection _dbConnection;

       public CustomerBO_DP29BAL()
       {
           _dbConnection=new DbConnection();
       }

       public bool Check_CustCodeBOID(string Cust_Code,string BO_ID)
       {
           bool result = false;
           DataTable data=new DataTable();

           string queryString = "SELECT *" +
                                "FROM [SBP_Database].[dbo].[SBP_Customers]" +
                                "WHERE Cust_Code='" + Cust_Code + "' And [BO_ID]='" + BO_ID + "';";
           try
           {
               _dbConnection.ConnectDatabase();               
               data=_dbConnection.ExecuteQuery(queryString);
               if (data.Rows.Count > 0)
                   result = true;               
           }
           catch (Exception ex) 
           {
               throw ex;
           }
           finally
           {
               _dbConnection.CloseDatabase();
           }

           return result;
       }

       public bool Check_BOSatusChangedFlow(string Cust_Code,string New_BOStatus)
       {
           bool result = true;
           DataTable data = new DataTable();
           string queryString = "SELECT " +
                                    "(" +
                                        "SELECT t.[BO_Status] " +
                                        "FROM [SBP_Database].[dbo].[SBP_BO_Status] as t" +
                                        " WHERE t.[BO_Status_ID]=[SBP_Customers].BO_Status_ID" +
                                    ")" +
                                " FROM [SBP_Database].[dbo].[SBP_Customers]" +
                                " WHERE Cust_Code='" + Cust_Code + "'";
           try
           {
               _dbConnection.ConnectDatabase();
               data = _dbConnection.ExecuteQuery(queryString);
               if (data.Rows.Count > 0)
               {
                   if (Convert.ToString(data.Rows[0][0]).ToUpper() == "CLOSED" && New_BOStatus.ToUpper() == "ACTIVE")
                       result = false;
               }
                
           }
           catch (Exception ex)
           {
               throw ex;
           }
           finally
           {
               _dbConnection.CloseDatabase();
           }

           return result;
       }

       public bool Check_SetUpDateChanged(string Cust_Code, string New_SetUpDate)
       {
           bool result = false;
           DataTable data = new DataTable();
           DateTime dtNewTryParse = new DateTime();
           DateTime dtOldTryParse = new DateTime();
           string queryString = "SELECT BO_Open_Date " +
                                "FROM [SBP_Database].[dbo].[SBP_Customers]" +
                                "WHERE Cust_Code='" + Cust_Code + "' ";
           try
           {
               _dbConnection.ConnectDatabase();
               data = _dbConnection.ExecuteQuery(queryString);
               if (data.Rows.Count > 0)
               {
                   if (DateTime.TryParse(New_SetUpDate, out dtNewTryParse) && DateTime.TryParse(data.Rows[0][0].ToString(), out dtOldTryParse))
                   {
                       if (dtOldTryParse != dtNewTryParse)
                           result = true;
                   }

               }
           }
           catch (Exception ex)
           {
               throw ex;
           }
           finally
           {
               _dbConnection.CloseDatabase();
           }

           return result;
       }

       public bool Check_ClosureDateChanged(string Cust_Code, string New_ClosureDate)
       {
           bool result = false;
           DateTime dtNewTryParse=new DateTime();
           DateTime dtOldTryParse = new DateTime();
           DataTable data = new DataTable();
           string queryString = "SELECT BO_Close_Date " +
                                "FROM [SBP_Database].[dbo].[SBP_Customers]" +
                                "WHERE Cust_Code='" + Cust_Code + "' ";
           try
           {
               _dbConnection.ConnectDatabase();
               data = _dbConnection.ExecuteQuery(queryString);
               if (data.Rows.Count > 0)
               {
                   if (DateTime.TryParse(New_ClosureDate, out dtNewTryParse) && DateTime.TryParse(data.Rows[0][0].ToString(), out dtOldTryParse))
                   {
                       if (dtOldTryParse != dtNewTryParse)
                           result = true;
                   }
               }
           }
           catch (Exception ex)
           {
               throw ex;
           }
           finally
           {
               _dbConnection.CloseDatabase();
           }

           return result;
       }
       
       public void InsertCustomerBO_DP29(CustomerBO_DP29 objCustomer_DP29BO)
       {
           string queryString = "INSERT INTO SBP_DP29 (BO_ID,BO_Type,BO_Category,Full_Name,Short_Name,Address,City,State,Country,[Purpose_Code],Residency,Telphone_Number,Fax,Email,[Internal_Reference_Number],[Setup_Date],BO_Status,[Closure_Date],[BO Father_Husband],BO_Mother,[Bank_Name],[Branch_Name],Account_Number) VALUES " +
               "('"+objCustomer_DP29BO.BoId + "','" + objCustomer_DP29BO.BoType + "','" + objCustomer_DP29BO.BoCategory + "','" + objCustomer_DP29BO.CustomerFullName + "','" + objCustomer_DP29BO.CustomerShortName +"','"+ objCustomer_DP29BO.Address + "','" + objCustomer_DP29BO.City + "','" + objCustomer_DP29BO.Satate + "','" + objCustomer_DP29BO.Country + "','" + objCustomer_DP29BO.PurposeCode + "','" + objCustomer_DP29BO.Residency + "','" + objCustomer_DP29BO.Phone + "','" + objCustomer_DP29BO.Fax + "','" + objCustomer_DP29BO.Email + "','" + objCustomer_DP29BO.InternalReferenceNo + "','" + objCustomer_DP29BO.SetupDate + "','" + objCustomer_DP29BO.BoStatus + "','" + objCustomer_DP29BO.ClosureDate + "','" + objCustomer_DP29BO.FatherName + "','" + objCustomer_DP29BO.MotherName + "','" + objCustomer_DP29BO.BankName + "','" + objCustomer_DP29BO.BranchName + "','" + objCustomer_DP29BO.AccountNo  +"')";

           try
           {
               _dbConnection.ConnectDatabase();
               _dbConnection.ExecuteNonQuery(queryString);
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
       public void UpdateCustomerBO_DP29(CustomerBO_DP29 obj)
       {
           string queryString =
                                "UPDATE  [SBP_Database].[dbo].[SBP_DP29] "
                                + "SET "
                                + " [BO_Type]='" + obj.BoType+ "'"
                                + ", [BO_Category]='" +obj.BoCategory +"'"
                                + ", [Full_Name]='" + obj.CustomerFullName + "'"
                                + ", [Short_Name]='" + obj.CustomerShortName + "'"
                                + ", [Address]='" + obj.Address + "'"
                                + ", [City]='" + obj.City + "'"
                                + ", [State]='" + obj.Satate + "'"
                                + ", [Country]='" + obj.Country + "'"
                                + ", [Purpose_Code]='" + obj.PurposeCode + "'"
                                + ", [Residency]='" + obj.Residency + "'"
                                + ", [Telphone_Number]='" + obj.Phone + "'"
                                + ", [Fax]='" + obj.Fax + "'"
                                + ", [Email]='" + obj.Email + "'"
                                + ", [Internal_Reference_Number]='" + obj.InternalReferenceNo + "'"
                                + ", [Setup_Date]='" + obj.SetupDate + "'"
                                + ", [BO_Status]='" + obj.BoStatus + "'"
                                + ", [Closure_Date]='" + obj.ClosureDate + "'"
                                + ", [BO Father_Husband]='" + obj.FatherName + "'"
                                + ", [BO_Mother]='" + obj.MotherName + "'"
                                + ", [Bank_Name]='" + obj.BankName + "'"
                                + ", [Branch_Name]='" + obj.BranchName + "'"
                                + ", [Account_Number]='" + obj.AccountNo + "' "
                                + "WHERE SUBSTRING(BO_ID,9,8)='" + obj.BoId + "'";                

           try
           {
               _dbConnection.ConnectDatabase();
               _dbConnection.ExecuteNonQuery(queryString);
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
       public void TruncateDP29()
       {
           string queryString = "Truncate Table SBP_DP29"; 

           try
           {
               _dbConnection.ConnectDatabase();
               _dbConnection.ExecuteNonQuery(queryString);
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
       //public DataTable GetClientBOInfo()
       //{
       //    //string count = "hjh";
       //    //string queryString ="SELECT Internal_Reference_Number AS 'Client Code',SUBSTRING(BO_ID,9,8) AS 'BO ID',BO_Type AS 'Bo Type',BO_Category AS 'BO Category',Short_Name,Full_Name AS 'Name',Address,City,State,Country,Purpose_Code AS 'Purpose Code',Residency,Telphone_Number,Fax,Email,Setup_Date AS 'Open Date',BO_Status AS 'BO Status',Closure_Date AS 'Close Date',[BO Father_Husband] AS 'Father Name',BO_Mother AS 'Mother Name',Bank_Name AS 'Bank Name',Branch_Name AS 'Branch Name',Account_Number AS 'Account Number' FROM dbo.SBP_DP29";
       //    string queryString =   "  Select "
       //                         + ", [Internal_Reference_Number] As [Cust Code]"
       //                         + ", SUBSTRING(BO_ID,9,8) AS [Bo Id] "
       //                         + ", [BO_Type] As [Bo Type]"
       //                         + ", [BO_Category] As [Bo Category]"
       //                         + ", [Full_Name] As [FullName]"
       //                         + ", [Short_Name] As [ShortName]"
       //                         + ", [Address] As [Address]"
       //                         + ", [City] As [City]"
       //                         + ", [State] As [State]"
       //                         + ", [Country] As [Country]"
       //                         + ", [Purpose_Code] As [Purp.Code]"
       //                         + ", [Residency] As [Residency]"
       //                         + ", [Telphone_Number] As [Phone]"
       //                         + ", [Fax] As [Email]"
       //                         + ", [Email] As [Fax]"                                
       //                         + ", [Setup_Date] As [Setup Date]"
       //                         + ", [BO_Status] As [Bo Status]"
       //                         + ", [Closure_Date] As [Closure Date]"
       //                         + ", [BO Father_Husband] As [Father Name]"
       //                         + ", [BO_Mother] As [Mother Name]"
       //                         + ", [Bank_Name] As [Bank Name]"
       //                         + ", [Branch_Name] As [Branch Name]"
       //                         + ", [Account_Number] As [Account No]"
       //                         + ", '' As [Remarks]"
       //                         + "FROM [SBP_Database].[dbo].[SBP_DP29]";
       //    DataTable data = new DataTable();

       //    try
       //    {
       //        _dbConnection.ConnectDatabase();
       //        data = _dbConnection.ExecuteQuery(queryString);

       //    }
       //    catch (Exception)
       //    {

       //        throw;
       //    }

       //    finally
       //    {
       //        _dbConnection.CloseDatabase();
       //    }

       //    return data;

           
       //}
       public DataTable GetClientBOInfo()
       {
           //string count = "hjh";
           //string queryString ="SELECT Internal_Reference_Number AS 'Client Code',SUBSTRING(BO_ID,9,8) AS 'BO ID',BO_Type AS 'Bo Type',BO_Category AS 'BO Category',Short_Name,Full_Name AS 'Name',Address,City,State,Country,Purpose_Code AS 'Purpose Code',Residency,Telphone_Number,Fax,Email,Setup_Date AS 'Open Date',BO_Status AS 'BO Status',Closure_Date AS 'Close Date',[BO Father_Husband] AS 'Father Name',BO_Mother AS 'Mother Name',Bank_Name AS 'Bank Name',Branch_Name AS 'Branch Name',Account_Number AS 'Account Number' FROM dbo.SBP_DP29";
           string queryString = "  Select "
                                + "[Internal_Reference_Number] As [InternalReferenceNo]"
                                + ", SUBSTRING(BO_ID,9,8) AS [BoId] "
                                + ", [BO_Type] As [BoType]"
                                + ", [BO_Category] As [BoCategory]"
                                + ", [Full_Name] As [CustomerFullName]"
                                + ", [Short_Name] As [CustomerShortName]"
                                + ", [Address] As [Address]"
                                + ", [City] As [City]"
                                + ", [State] As [Satate]"
                                + ", [Country] As [Country]"
                                + ", [Purpose_Code] As [PurposeCode]"
                                + ", [Residency] As [Residency]"
                                + ", [Telphone_Number] As [Phone]"
                                + ", [Fax] As [Email]"
                                + ", [Email] As [Fax]"
                                + ", [Setup_Date] As [SetupDate]"
                                + ", [BO_Status] As [BoStatus]"
                                + ", [Closure_Date] As [ClosureDate]"
                                + ", [BO Father_Husband] As [FatherName]"
                                + ", [BO_Mother] As [MotherName]"
                                + ", [Bank_Name] As [BankName]"
                                + ", [Branch_Name] As [BranchName]"
                                + ", [Account_Number] As [AccountNo]"
                                //+ ", '' As [Remarks]"
                                + "FROM [SBP_Database].[dbo].[SBP_DP29]";
           DataTable data = new DataTable();

           try
           {
               _dbConnection.ConnectDatabase();
               data = _dbConnection.ExecuteQuery(queryString);

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
       public CustomerBO_DP29 GetClientBOInfo(string BoId)
       {
           CustomerBO_DP29 obj = new CustomerBO_DP29();
           //string count = "hjh";
           //string queryString ="SELECT Internal_Reference_Number AS 'Client Code',SUBSTRING(BO_ID,9,8) AS 'BO ID',BO_Type AS 'Bo Type',BO_Category AS 'BO Category',Short_Name,Full_Name AS 'Name',Address,City,State,Country,Purpose_Code AS 'Purpose Code',Residency,Telphone_Number,Fax,Email,Setup_Date AS 'Open Date',BO_Status AS 'BO Status',Closure_Date AS 'Close Date',[BO Father_Husband] AS 'Father Name',BO_Mother AS 'Mother Name',Bank_Name AS 'Bank Name',Branch_Name AS 'Branch Name',Account_Number AS 'Account Number' FROM dbo.SBP_DP29";
           string queryString = "  Select SUBSTRING(BO_ID,9,8) AS [BO_ID] "
                                + ", [BO_Type] As [BO_Type]"
                                + ", [BO_Category] As [BO_Category]"
                                + ", [Full_Name] As [Full_Name]"
                                + ", [Short_Name] As [Short_Name]"
                                + ", [Address] As [Address]"
                                + ", [City] As [City]"
                                + ", [State] As [State]"
                                + ", [Country] As [Country]"
                                + ", [Purpose_Code] As [Purpose_Code]"
                                + ", [Residency] As [Residency]"
                                + ", [Telphone_Number] As [Telphone_Number]"
                                + ", [Fax] As [Fax]"
                                + ", [Email] As [Email]"
                                + ", [Internal_Reference_Number] As [Internal_Reference_Number]"
                                + ", [Setup_Date] As [Setup_Date]"
                                + ", [BO_Status] As [BO_Status]"
                                + ", [Closure_Date] As [Closure_Date]"
                                + ", [BO Father_Husband] As [BO Father_Husband]"
                                + ", [BO_Mother] As [BO_Mother]"
                                + ", [Bank_Name] As [Bank_Name]"
                                + ", [Branch_Name] As [Branch_Name]"
                                + ", [Account_Number] As [Account_Number]"
                                + ", [Remarks] As [Remarks]"
                                + "FROM [SBP_Database].[dbo].[SBP_DP29]"
                                + "WHERE SUBSTRING(BO_ID,9,8)='" + BoId + "'";

           
           try
           {
               _dbConnection.ConnectDatabase();
               SqlDataReader dr = _dbConnection.ExecuteReader(queryString);
               while (dr.Read())
               {
                   CustomerBO_DP29 objTemp = new CustomerBO_DP29();

                   objTemp.BoId = Convert.ToString(dr["BO_ID"]);
                   objTemp.BoType = Convert.ToString(dr["BO_Type"]);
                   objTemp.BoCategory = Convert.ToString(dr["BO_Category"]);
                   objTemp.CustomerFullName = Convert.ToString(dr["Full_Name"]);
                   objTemp.CustomerShortName = Convert.ToString(dr["Short_Name"]);
                   objTemp.Address = Convert.ToString(dr["Address"]);
                   objTemp.City = Convert.ToString(dr["City"]);
                   objTemp.Satate = Convert.ToString(dr["State"]);
                   objTemp.Country = Convert.ToString(dr["Country"]);
                   objTemp.PurposeCode = Convert.ToString(dr["Purpose_Code"]);
                   objTemp.Residency = Convert.ToString(dr["Residency"]);
                   objTemp.Phone = Convert.ToString(dr["Telphone_Number"]);
                   objTemp.Email = Convert.ToString(dr["Fax"]);
                   objTemp.Fax = Convert.ToString(dr["Email"]);
                   objTemp.InternalReferenceNo = Convert.ToString(dr["Internal_Reference_Number"]);
                   objTemp.SetupDate = Convert.ToString(dr["Setup_Date"]);
                   objTemp.BoStatus = Convert.ToString(dr["BO_Status"]);
                   objTemp.ClosureDate = Convert.ToString(dr["Closure_Date"]);
                   objTemp.FatherName = Convert.ToString(dr["BO Father_Husband"]);
                   objTemp.MotherName = Convert.ToString(dr["BO_Mother"]);
                   objTemp.BankName = Convert.ToString(dr["Bank_Name"]);
                   objTemp.BranchName = Convert.ToString(dr["Branch_Name"]);
                   objTemp.AccountNo = Convert.ToString(dr["Account_Number"]);
                   objTemp.Remarks = Convert.ToString(dr["Remarks"]);
                   obj = objTemp;                                     
               }

               dr.Close();
           }
           catch (Exception)
           {
               throw;           
           }           
           finally
           {
               
               _dbConnection.CloseDatabase();
           }
          
           return obj;


       }

       public void UpdateDP29(DataTable dtDP29)
       {
           string BOID;
           string e="";
           string queryStringUpdateDP29 = @"DP29Update";
           try
           {
               _dbConnection.ConnectDatabase();
               _dbConnection.StartTransaction();

               for (int i = 0; i < dtDP29.Rows.Count; i++)
               {
                   if (i == 25619)
                   {
                       int k = 0;
                       k = k + 1;
                   }
                   
                   if (Check_CustCodeBOID(dtDP29.Rows[i]["InternalReferenceNo"].ToString(), dtDP29.Rows[i]["BoId"].ToString())==false)
                       continue;
                   else if (Check_BOSatusChangedFlow(dtDP29.Rows[i]["InternalReferenceNo"].ToString(), dtDP29.Rows[i]["BoStatus"].ToString()) == false)
                       continue;
                   else if (Check_SetUpDateChanged(dtDP29.Rows[i]["InternalReferenceNo"].ToString(), dtDP29.Rows[i]["SetupDate"].ToString())==true)
                       continue;
                   else if (Check_ClosureDateChanged(dtDP29.Rows[i]["InternalReferenceNo"].ToString(), dtDP29.Rows[i]["ClosureDate"].ToString()) == true)
                       continue;
                   else
                   {
                       BOID = dtDP29.Rows[i]["BoId"].ToString();
                       _dbConnection.ConnectDatabase();
                       _dbConnection.ActiveStoredProcedure();
                       _dbConnection.AddParameter("@BOID", SqlDbType.NVarChar, BOID);
                       _dbConnection.ExecuteProQuery(queryStringUpdateDP29);
                   }
                   error = BOID;
               }
               _dbConnection.Commit();
           }
           catch (Exception exception)
           {
               _dbConnection.Rollback();
               error.ToString();
           }
           finally
           {
               _dbConnection.CloseDatabase();
           }

       }
       //public string DeleteFromDP29(string BO_ID)
       //{
       //   // _dbConnection.ConnectDatabase();
       //    string deleteQuery = " DELETE FROM dbo.SBP_DP29 WHERE BO_ID='" + BO_ID + "'";
       //   // _dbConnection.ExecuteNonQuery(deleteQuery);
       //    return deleteQuery;
       //}
       public DataTable GetDP29Data()
       {
           DataTable dataTable;
           string queryString = "SELECT * FROM dbo.SBP_DP29";
           try
           {
               _dbConnection.ConnectDatabase();
               dataTable = _dbConnection.ExecuteQuery(queryString);
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

       //public void InsertDatabase(CustomerBO_DP29 customerBo_DP29)
       //{
       //    string queryStringBasicInfo = "";
       //    string queryStringPersonalInfo = "";
       //    string queryStringContactsInfo = "";
       //    string queryStringAdditionalInfo = "";
       //    string queryStringBankInfo = "";
       //    string queryStringPassportInfo = "";
       //    string queryStringJointholder = "";

       //    queryStringBasicInfo = @"INSERT INTO SBP_Customers (Cust_Code, Cust_Open_Date,Cust_Status_ID,BO_ID,BO_Category_ID,BO_Type_ID,BO_Open_Date,BO_Status_ID,Entry_Date,Entry_By)" +
       //        " VALUES('" + customerBo_DP29.InternalReferenceNo + "',GETDATE(),1,'" + customerBo.BoId + "'," + customerBo.BoCategoryID + "," + customerBo.BoTypeID + ",GETDATE(),1,GETDATE(),'" + GlobalVariableBO._userName + "')";

       //    queryStringPersonalInfo = @"INSERT INTO SBP_Cust_Personal_Info (Cust_Code,Cust_Name,Father_Name,Mother_Name,DOB,Gender,Occupation,Entry_Date,Entry_By)" +
       //      " VALUES('" + customerBo.CustomerCode + "','" + customerBo.CustomerName + "','" + customerBo.FatherName + "','" + customerBo.MotherName + "','" + customerBo.BirthDate.ToShortDateString() + "','" + customerBo.Sex + "','" + customerBo.Occupation + "',GETDATE(),'" + GlobalVariableBO._userName + "')";

       //    queryStringContactsInfo = @"INSERT INTO SBP_Cust_Contact_Info (Cust_Code, Address1,Address2,Address3,City_Name,Post_Code,Division_Name,Country_Name,Mobile,Fax,Email,Entry_Date,Entry_By)" +
       //      " VALUES('" + customerBo.CustomerCode + "','" + customerBo.Address1 + "','" + customerBo.Address2 + "','" + customerBo.Address3 + "','" + customerBo.City + "','" + customerBo.PostalCode + "','" + customerBo.District + "','" + customerBo.Country + "','" + customerBo.Phone + "','" + customerBo.Fax + "','" + customerBo.Email + "',GETDATE(),'" + GlobalVariableBO._userName + "')";

       //    queryStringAdditionalInfo = @"INSERT INTO SBP_Cust_Additional_Info (Cust_Code, Recidency,Nationality,Statement_Cycle_ID,Entry_Date,Entry_By)" +
       //       " VALUES('" + customerBo.CustomerCode + "','" + customerBo.Residence + "','" + customerBo.Nationality + "'," + customerBo.StatementCycleID + ",GETDATE(),'" + GlobalVariableBO._userName + "')";

       //    queryStringBankInfo = @"INSERT INTO SBP_Cust_Bank_Info (Cust_Code, Bank_Name,Branch_Name,Account_No,Is_EDC,Is_Tax_Exemption,TIN,Entry_Date,Entry_By)" +
       //      " VALUES('" + customerBo.CustomerCode + "','" + customerBo.BankName + "','" + customerBo.BranchName + "','" + customerBo.AccountNo + "'," + customerBo.Edc + "," + customerBo.TaxExemption + ",'" + customerBo.Tin + "',GETDATE(),'" + GlobalVariableBO._userName + "')";
       //    queryStringPassportInfo = @"INSERT INTO SBP_Cust_Passport_Info(Cust_Code, Passport_No,Issue_Place,Issue_Date,Expire_Date,Entry_Date,Entry_By)" +
       //    " VALUES('" + customerBo.CustomerCode + "','" + customerBo.PassportNo + "','" + customerBo.PassportIssuePlace + "','" + customerBo.PassportIssueDate + "','" + customerBo.PassportExpiryDate + "',GETDATE(),'" + GlobalVariableBO._userName + "')";

       //    queryStringJointholder = "INSERT INTO SBP_Joint_holder (Cust_Code,Joint_Name,Entry_Date,Entry_By) VALUES ('" + customerBo.CustomerCode + "','" + customerBo.SecoundHolder + "',GETDATE(),'" + GlobalVariableBO._userName + "')";

       //    try
       //    {
       //        _dbConnection.ConnectDatabase();
       //        _dbConnection.StartTransaction();
       //        _dbConnection.ExecuteNonQuery(queryStringBasicInfo);
       //        _dbConnection.ExecuteNonQuery(queryStringPersonalInfo);
       //        _dbConnection.ExecuteNonQuery(queryStringContactsInfo);
       //        _dbConnection.ExecuteNonQuery(queryStringAdditionalInfo);
       //        _dbConnection.ExecuteNonQuery(queryStringBankInfo);
       //        _dbConnection.ExecuteNonQuery(queryStringPassportInfo);
       //        _dbConnection.ExecuteNonQuery(queryStringJointholder);
       //        _dbConnection.Commit();
       //    }
       //    catch (Exception exception)
       //    {
       //        _dbConnection.Rollback();
       //        throw exception;
       //    }
       //    finally
       //    {
       //        _dbConnection.CloseDatabase();
       //    }
       //}

       //public void UpdateDatabase(CustomerBO customerBo)
       //{
       //    string queryStringBasicInfo = "";
       //    string queryStringPersonalInfo = "";
       //    string queryStringContactsInfo = "";
       //    string queryStringAdditionalInfo = "";
       //    string queryStringBankInfo = "";
       //    string queryStringPassportInfo = "";
       //    string queryStringJointholder = "";

       //    queryStringBasicInfo = @" INTO SBP_Customers (Cust_Code, Cust_Open_Date,Cust_Status_ID,BO_ID,BO_Category_ID,BO_Type_ID,BO_Open_Date,BO_Status_ID,Entry_Date,Entry_By)" +
       //        " VALUES('" + customerBo.CustomerCode + "',GETDATE(),1,'" + customerBo.BoId + "'," + customerBo.BoCategoryID + "," + customerBo.BoTypeID + ",GETDATE(),1,GETDATE(),'" + GlobalVariableBO._userName + "')";

       //    queryStringPersonalInfo = @"INSERT INTO SBP_Cust_Personal_Info (Cust_Code,Cust_Name,Father_Name,Mother_Name,DOB,Gender,Occupation,Entry_Date,Entry_By)" +
       //      " VALUES('" + customerBo.CustomerCode + "','" + customerBo.CustomerName + "','" + customerBo.FatherName + "','" + customerBo.MotherName + "','" + customerBo.BirthDate.ToShortDateString() + "','" + customerBo.Sex + "','" + customerBo.Occupation + "',GETDATE(),'" + GlobalVariableBO._userName + "')";

       //    queryStringContactsInfo = @"INSERT INTO SBP_Cust_Contact_Info (Cust_Code, Address1,Address2,Address3,City_Name,Post_Code,Division_Name,Country_Name,Mobile,Fax,Email,Entry_Date,Entry_By)" +
       //      " VALUES('" + customerBo.CustomerCode + "','" + customerBo.Address1 + "','" + customerBo.Address2 + "','" + customerBo.Address3 + "','" + customerBo.City + "','" + customerBo.PostalCode + "','" + customerBo.District + "','" + customerBo.Country + "','" + customerBo.Phone + "','" + customerBo.Fax + "','" + customerBo.Email + "',GETDATE(),'" + GlobalVariableBO._userName + "')";

       //    queryStringAdditionalInfo = @"INSERT INTO SBP_Cust_Additional_Info (Cust_Code, Recidency,Nationality,Statement_Cycle_ID,Entry_Date,Entry_By)" +
       //       " VALUES('" + customerBo.CustomerCode + "','" + customerBo.Residence + "','" + customerBo.Nationality + "'," + customerBo.StatementCycleID + ",GETDATE(),'" + GlobalVariableBO._userName + "')";

       //    queryStringBankInfo = @"INSERT INTO SBP_Cust_Bank_Info (Cust_Code, Bank_Name,Branch_Name,Account_No,Is_EDC,Is_Tax_Exemption,TIN,Entry_Date,Entry_By)" +
       //      " VALUES('" + customerBo.CustomerCode + "','" + customerBo.BankName + "','" + customerBo.BranchName + "','" + customerBo.AccountNo + "'," + customerBo.Edc + "," + customerBo.TaxExemption + ",'" + customerBo.Tin + "',GETDATE(),'" + GlobalVariableBO._userName + "')";
       //    queryStringPassportInfo = @"INSERT INTO SBP_Cust_Passport_Info(Cust_Code, Passport_No,Issue_Place,Issue_Date,Expire_Date,Entry_Date,Entry_By)" +
       //    " VALUES('" + customerBo.CustomerCode + "','" + customerBo.PassportNo + "','" + customerBo.PassportIssuePlace + "','" + customerBo.PassportIssueDate + "','" + customerBo.PassportExpiryDate + "',GETDATE(),'" + GlobalVariableBO._userName + "')";

       //    queryStringJointholder = "INSERT INTO SBP_Joint_holder (Cust_Code,Joint_Name,Entry_Date,Entry_By) VALUES ('" + customerBo.CustomerCode + "','" + customerBo.SecoundHolder + "',GETDATE(),'" + GlobalVariableBO._userName + "')";

       //    try
       //    {
       //        _dbConnection.ConnectDatabase();
       //        _dbConnection.StartTransaction();
       //        _dbConnection.ExecuteNonQuery(queryStringBasicInfo);
       //        _dbConnection.ExecuteNonQuery(queryStringPersonalInfo);
       //        _dbConnection.ExecuteNonQuery(queryStringContactsInfo);
       //        _dbConnection.ExecuteNonQuery(queryStringAdditionalInfo);
       //        _dbConnection.ExecuteNonQuery(queryStringBankInfo);
       //        _dbConnection.ExecuteNonQuery(queryStringPassportInfo);
       //        _dbConnection.ExecuteNonQuery(queryStringJointholder);
       //        _dbConnection.Commit();
       //    }
       //    catch (Exception exception)
       //    {
       //        _dbConnection.Rollback();
       //        throw exception;
       //    }
       //    finally
       //    {
       //        _dbConnection.CloseDatabase();
       //    }
       //}


       

   }
}
