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
       private DbConnection _dbConnection;

       public CustomerBO_DP29BAL()
       {
           _dbConnection=new DbConnection();
       }
       public void BeginTransaction()
       {
          _dbConnection.StartTransaction();
       }
       public void CommitTransaction()
       {
           _dbConnection.Commit();
       }
       public void RollBackTransaction()
       {
           _dbConnection.Rollback();
       }
       public void ConnectionOpen()
       {
           _dbConnection.ConnectDatabase();
       }
       public void CloseConnection()
       {
           _dbConnection.CloseDatabase();
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

       private string PopulateQryStr_InsertCustomerBO_DP29(CustomerBO_DP29 objCustomer_DP29BO)
       {
           string queryString = @"INSERT INTO SBP_DP29 (
                             BO_ID
                            ,BO_Type
                            ,BO_Category
                            ,Full_Name
                            ,Short_Name
                            ,Address
                            ,City
                            ,State
                            ,Country
                            ,[Purpose_Code]
                            ,Residency
                            ,Telphone_Number
                            ,Fax
                            ,Email
                            ,[Internal_Reference_Number]
                            ,[Setup_Date]
                            ,BO_Status
                            ,[Closure_Date]
                            ,[BO Father_Husband]
                            ,BO_Mother
                            ,[Bank_Name]
                            ,[Branch_Name]
                            ,Account_Number
                            ,Routing_No
                            ,Bank_Identification_Code
                            ,IBAN
                            ,SWIFT_Code  

                            ,Suspense_Flag
                            ,Bo_Suspened_Date
                            ,Suspense_Reason_Code
                            ,Second_Holder_Name
                            ,Occupation
                            ,Date_of_Birth
                            ,Gender
                            ,BO_Nationality
                            ,Tax_ID_Number                           
                            ,Origin_of_BO

                            ) 
                    VALUES " +
                  "('" 
                  + objCustomer_DP29BO.BoId 
                  + "','" + objCustomer_DP29BO.BoType 
                  + "','" + objCustomer_DP29BO.BoCategory
                  + "','" + objCustomer_DP29BO.CustomerFullName.Replace("'", "''")
                  + "','" + objCustomer_DP29BO.CustomerShortName.Replace("'", "''") 
                  + "','" + objCustomer_DP29BO.Address.Replace("'","''")
                  + "','" + objCustomer_DP29BO.City.Replace("'", "''")
                  + "','" + objCustomer_DP29BO.Satate.Replace("'", "''")
                  + "','" + objCustomer_DP29BO.Country.Replace("'", "''")
                  + "','" + objCustomer_DP29BO.PurposeCode.Replace("'", "''")
                  + "','" + objCustomer_DP29BO.Residency.Replace("'", "''")
                  + "','" + objCustomer_DP29BO.Phone.Replace("'", "''")
                  + "','" + objCustomer_DP29BO.Fax.Replace("'", "''")
                  + "','" + objCustomer_DP29BO.Email.Replace("'", "''")
                  + "','" + objCustomer_DP29BO.InternalReferenceNo
                  + "','" + objCustomer_DP29BO.SetupDate
                  + "','" + objCustomer_DP29BO.BoStatus 
                  + "','" + objCustomer_DP29BO.ClosureDate
                  + "','" + objCustomer_DP29BO.FatherName.Replace("'", "''")
                  + "','" + objCustomer_DP29BO.MotherName.Replace("'", "''")
                  + "','" + objCustomer_DP29BO.BankName.Replace("'", "''")
                  + "','" + objCustomer_DP29BO.BranchName.Replace("'", "''")
                  + "','" + objCustomer_DP29BO.AccountNo.Replace("'", "''")
                  + "','" + objCustomer_DP29BO.Routing_No.Replace("'", "''")
                  + "','" + objCustomer_DP29BO.Bank_Identification_Code.Replace("'", "''")
                  + "','" + objCustomer_DP29BO.IBAN.Replace("'", "''")
                  + "','" + objCustomer_DP29BO.SWIFT_Code.Replace("'", "''")

                  + "','" + objCustomer_DP29BO.Suspense_Flag.Replace("'", "''") 
                  + "','" + objCustomer_DP29BO.Bo_Suspened_Date.Replace("'", "''")
                  + "','" + objCustomer_DP29BO.Suspense_Reason_Code.Replace("'", "''")
                  + "','" + objCustomer_DP29BO.Second_Holder_Name.Replace("'", "''")
                  + "','" + objCustomer_DP29BO.Occupation.Replace("'", "''") 
                  + "','" + objCustomer_DP29BO.Date_of_Birth.Replace("'", "''") 
                  + "','" + objCustomer_DP29BO.Gender.Replace("'", "''") 
                  + "','" + objCustomer_DP29BO.BO_Nationality.Replace("'", "''") 
                  + "','" + objCustomer_DP29BO.Tax_ID_Number.Replace("'", "''") 
                  + "','" + objCustomer_DP29BO.Origin_of_BO.Replace("'", "''") 
                  
                  + "')";

           return queryString; 
       }
       
       public void InsertCustomerBO_DP29_WithTransaction(CustomerBO_DP29 objCustomer_DP29BO)
       {
           //string queryString = "INSERT INTO SBP_DP29 (BO_ID,BO_Type,BO_Category,Full_Name,Short_Name,Address,City,State,Country,[Purpose_Code],Residency,Telphone_Number,Fax,Email,[Internal_Reference_Number],[Setup_Date],BO_Status,[Closure_Date],[BO Father_Husband],BO_Mother,[Bank_Name],[Branch_Name],Account_Number) VALUES " +
           //    "('" + objCustomer_DP29BO.BoId + "','" + objCustomer_DP29BO.BoType + "','" + objCustomer_DP29BO.BoCategory + "','" + objCustomer_DP29BO.CustomerFullName + "','" + objCustomer_DP29BO.CustomerShortName + "','" + objCustomer_DP29BO.Address + "','" + objCustomer_DP29BO.City + "','" + objCustomer_DP29BO.Satate + "','" + objCustomer_DP29BO.Country + "','" + objCustomer_DP29BO.PurposeCode + "','" + objCustomer_DP29BO.Residency + "','" + objCustomer_DP29BO.Phone + "','" + objCustomer_DP29BO.Fax + "','" + objCustomer_DP29BO.Email + "','" + objCustomer_DP29BO.InternalReferenceNo + "','" + objCustomer_DP29BO.SetupDate + "','" + objCustomer_DP29BO.BoStatus + "','" + objCustomer_DP29BO.ClosureDate + "','" + objCustomer_DP29BO.FatherName + "','" + objCustomer_DP29BO.MotherName + "','" + objCustomer_DP29BO.BankName + "','" + objCustomer_DP29BO.BranchName + "','" + objCustomer_DP29BO.AccountNo + "')";
           string qryStr = PopulateQryStr_InsertCustomerBO_DP29(objCustomer_DP29BO);
           try
           {
               _dbConnection.ConnectDatabase();
               _dbConnection.ExecuteNonQuery(qryStr);
           }
           catch (Exception ex)
           {
               
               throw ex;
           }          
       }

       public void InsertCustomerBO_DP29(CustomerBO_DP29 objCustomer_DP29BO)
       {
           //string queryString = "INSERT INTO SBP_DP29 (BO_ID,BO_Type,BO_Category,Full_Name,Short_Name,Address,City,State,Country,[Purpose_Code],Residency,Telphone_Number,Fax,Email,[Internal_Reference_Number],[Setup_Date],BO_Status,[Closure_Date],[BO Father_Husband],BO_Mother,[Bank_Name],[Branch_Name],Account_Number) VALUES " +
           //    "('"+objCustomer_DP29BO.BoId + "','" + objCustomer_DP29BO.BoType + "','" + objCustomer_DP29BO.BoCategory + "','" + objCustomer_DP29BO.CustomerFullName + "','" + objCustomer_DP29BO.CustomerShortName +"','"+ objCustomer_DP29BO.Address + "','" + objCustomer_DP29BO.City + "','" + objCustomer_DP29BO.Satate + "','" + objCustomer_DP29BO.Country + "','" + objCustomer_DP29BO.PurposeCode + "','" + objCustomer_DP29BO.Residency + "','" + objCustomer_DP29BO.Phone + "','" + objCustomer_DP29BO.Fax + "','" + objCustomer_DP29BO.Email + "','" + objCustomer_DP29BO.InternalReferenceNo + "','" + objCustomer_DP29BO.SetupDate + "','" + objCustomer_DP29BO.BoStatus + "','" + objCustomer_DP29BO.ClosureDate + "','" + objCustomer_DP29BO.FatherName + "','" + objCustomer_DP29BO.MotherName + "','" + objCustomer_DP29BO.BankName + "','" + objCustomer_DP29BO.BranchName + "','" + objCustomer_DP29BO.AccountNo  +"')";

           string qryStr = PopulateQryStr_InsertCustomerBO_DP29(objCustomer_DP29BO);
           try
           {
               _dbConnection.ConnectDatabase();
               _dbConnection.ExecuteNonQuery(qryStr);
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

       private string PopulateQueryStr_UpdateCustomerBO_DP29(CustomerBO_DP29 obj)
       {
           string queryString = "UPDATE  [SBP_Database].[dbo].[SBP_DP29] "
                              + "  SET "
                              + "  [BO_Type]='" + obj.BoType + "'"
                              + ", [BO_Category]='" + obj.BoCategory + "'"
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
                              + ", [Setup_Date]='" + obj.SetupDate+ "'"
                              + ", [BO_Status]='" + obj.BoStatus + "'"
                              + ", [Closure_Date]='" + obj.ClosureDate+ "'"
                              + ", [BO Father_Husband]='" + obj.FatherName + "'"
                              + ", [BO_Mother]='" + obj.MotherName + "'"
                              + ", [Bank_Name]='" + obj.BankName+ "'"
                              + ", [Branch_Name]='" + obj.BranchName + "'"
                              + ", [Account_Number]='" + obj.AccountNo + "' "
                              + ", [Routing_No]='" + obj.Routing_No + "' "
                              + ", [Bank_Identification_Code]='" + obj.Bank_Identification_Code + "' "
                              + ", [IBAN]='" + obj.IBAN + "' "
                              + ", [SWIFT_Code]='" + obj.SWIFT_Code + "' "

                              + ", [Suspense_Flag]='" + obj.Suspense_Flag + "' "
                              + ", [Bo_Suspened_Date]='" + obj.Bo_Suspened_Date + "' "
                              + ", [Suspense_Reason_Code]='" + obj.Suspense_Reason_Code + "' "
                              + ", [Second_Holder_Name]='" + obj.Second_Holder_Name + "' "
                              + ", [Occupation]='" + obj.Occupation + "' "
                              + ", [Date_of_Birth]='" + obj.Date_of_Birth + "' "
                              + ", [Gender]='" + obj.Gender + "' "
                              + ", [BO_Nationality]='" + obj.BO_Nationality + "' "
                              + ", [Tax_ID_Number]='" + obj.Tax_ID_Number + "' "
                              + ", [Origin_of_BO]='" + obj.Origin_of_BO + "' "                            


                              + ", [IsForcedAccClosed]=Convert(bit,'" + Convert.ToInt16(obj.IsForcedAccClosed) + "')"
                              + "  WHERE SUBSTRING(BO_ID,9,8)='" + obj.BoId + "'";
           return queryString; 
       }

       public void UpdateCustomerBO_DP29_WithTransaction(CustomerBO_DP29 obj)
       {
           string queryString = PopulateQueryStr_UpdateCustomerBO_DP29(obj);

           try
           {
               _dbConnection.ConnectDatabase();
               _dbConnection.ExecuteNonQuery(queryString);
           }
           catch (Exception ex)
           {

               throw ex;
           }
       }

       public void UpdateCustomerBO_DP29(CustomerBO_DP29 obj)
       {
           string queryString = PopulateQueryStr_UpdateCustomerBO_DP29(obj);         

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

       public DataTable GetDP29MissMatchReport()
       {
           DataTable dataTable = new DataTable();
           //string CustCode;
           string queryStringDP29 = @"RptGetDP29MissMatchReport";
           try
           {
               _dbConnection.ConnectDatabase();
               _dbConnection.ActiveStoredProcedure();
               dataTable = _dbConnection.ExecuteProQuery(queryStringDP29);
               //_dbConnection.ActiveStoredProcedure();

               //_dbConnection.Commit();
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
                                + ", [Fax] As [Fax]"
                                + ", [Email] As [Email]"
                                + ", [Setup_Date] As [SetupDate]"
                                + ", [BO_Status] As [BoStatus]"
                                + ", [Closure_Date] As [ClosureDate]"
                                + ", [BO Father_Husband] As [FatherName]"
                                + ", [BO_Mother] As [MotherName]"
                                + ", [Bank_Name] As [BankName]"
                                + ", [Branch_Name] As [BranchName]"
                                + ", [Account_Number] As [AccountNo]"
                                + ",[Routing_No]"
                                + ",[Bank_Identification_Code]"
                                + ",[IBAN]"
                                + ",[SWIFT_Code]"
                                 + ",[Suspense_Flag]"
                                  + ",[Bo_Suspened_Date]"
                                  + ",[Suspense_Reason_Code]"
                                  + ",[Second_Holder_Name]"
                                  + ",[Occupation]"
                                  + ",[Date_of_Birth]" 
                                  + ",[Gender]" 
                                  + ",[BO_Nationality]"
                                  + ",[Tax_ID_Number]"
                                  + ",[Origin_of_BO]"   
                                + ", [IsForcedAccClosed] As [IsForcedAccClosed]"
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
                                + ",[Routing_No]"
                                 + ",[Bank_Identification_Code]"
                                + ",[IBAN]"
                                + ",[SWIFT_Code]"
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
                   objTemp.Routing_No = Convert.ToString(dr["Routing_No"]);
                   objTemp.Bank_Identification_Code = Convert.ToString(dr["Bank_Identification_Code"]);
                   objTemp.IBAN = Convert.ToString(dr["IBAN"]);
                   objTemp.SWIFT_Code = Convert.ToString(dr["SWIFT_Code"]);
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

       public void UpdateRowDP29(

             string BOID
           , bool Is_BO_Type
           , bool Is_BO_Category
           , bool Is_Full_Name
            ,bool Is_Short_Name
           , bool Is_Address
           , bool Is_City
           , bool Is_State
            ,bool Is_Country
           , bool Is_Purpose_Code
           , bool Is_Residency
           , bool Is_Telphone_Number
           , bool Is_Fax
           , bool Is_Email
           , bool Is_Internal_Reference_Number
           , bool Is_Setup_Date
           , bool Is_BO_Status
           , bool Is_BOFather_Husband
           , bool Is_BO_Mother
           , bool Is_Bank_Name
           , bool Is_Branch_Name
           , bool Is_Account_Number
           , bool Is_Routing_No
           , bool Is_Bank_Identification_Code
           , bool Is_IBAN
           , bool Is_SWIFT_Code

           , bool Is_Suspense_Flag
           , bool Is_Bo_Suspened_Date
           , bool Is_Suspense_Reason_Code
           , bool Is_Second_Holder_Name
           , bool Is_Occupation
           , bool Is_Date_of_Birth
           , bool Is_Gender
           , bool Is_BO_Nationality
           , bool Is_Tax_ID_Number
           , bool Is_Origin_of_BO          
           
           )

       {
           //string CustCode;
           string queryStringUpdateDP29 = @"DP29Update";
           try
           {
               //_dbConnection.ConnectDatabase();
               //_dbConnection.StartTransaction();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@BOID", SqlDbType.NVarChar, BOID);
                _dbConnection.AddParameter("@Is_BO_Type",SqlDbType.Bit,Convert.ToInt32(Is_BO_Type));
                _dbConnection.AddParameter("@Is_BO_Category",SqlDbType.Bit,Convert.ToInt32(Is_BO_Category));
                _dbConnection.AddParameter("@Is_Full_Name",SqlDbType.Bit,Convert.ToInt32(Is_Full_Name));
                _dbConnection.AddParameter("@Is_Short_Name",SqlDbType.Bit,Convert.ToInt32(Is_Short_Name));
                _dbConnection.AddParameter("@Is_Address",SqlDbType.Bit,Convert.ToInt32(Is_Address));
                _dbConnection.AddParameter("@Is_City",SqlDbType.Bit,Convert.ToInt32(Is_City));
                _dbConnection.AddParameter("@Is_State",SqlDbType.Bit,Convert.ToInt32(Is_State));
                _dbConnection.AddParameter("@Is_Country",SqlDbType.Bit,Convert.ToInt32(Is_Country));
                _dbConnection.AddParameter("@Is_Purpose_Code",SqlDbType.Bit,Convert.ToInt32(Is_Purpose_Code));
                _dbConnection.AddParameter("@Is_Residency",SqlDbType.Bit,Convert.ToInt32(Is_Residency));
                _dbConnection.AddParameter("@Is_Telphone_Number",SqlDbType.Bit,Convert.ToInt32(Is_Telphone_Number));
                _dbConnection.AddParameter("@Is_Fax",SqlDbType.Bit,Convert.ToInt32(Is_Fax));
                _dbConnection.AddParameter("@Is_Email",SqlDbType.Bit,Convert.ToInt32(Is_Email));
                _dbConnection.AddParameter("@Is_Internal_Reference_Number",SqlDbType.Bit,Convert.ToInt32(Is_Internal_Reference_Number));
                _dbConnection.AddParameter("@Is_Setup_Date",SqlDbType.Bit,Convert.ToInt32(Is_Setup_Date));
                _dbConnection.AddParameter("@Is_BO_Status",SqlDbType.Bit,Convert.ToInt32(Is_BO_Status));
                _dbConnection.AddParameter("@Is_BOFather_Husband", SqlDbType.Bit, Convert.ToInt32(Is_BOFather_Husband));
                _dbConnection.AddParameter("@Is_BO_Mother",SqlDbType.Bit,Convert.ToInt32(Is_BO_Mother));
                _dbConnection.AddParameter("@Is_Bank_Name",SqlDbType.Bit,Convert.ToInt32(Is_Bank_Name));
                _dbConnection.AddParameter("@Is_Branch_Name",SqlDbType.Bit,Convert.ToInt32(Is_Branch_Name));

                _dbConnection.AddParameter("@Is_Routing_No", SqlDbType.Bit, Convert.ToInt32(Is_Routing_No));

                _dbConnection.AddParameter("@Is_Bank_Identification_Code", SqlDbType.Bit, Convert.ToInt32(Is_Bank_Identification_Code));
                _dbConnection.AddParameter("@Is_IBAN", SqlDbType.Bit, Convert.ToInt32(Is_IBAN));
                _dbConnection.AddParameter("@Is_SWIFT_Code", SqlDbType.Bit, Convert.ToInt32(Is_SWIFT_Code));

                _dbConnection.AddParameter("@Is_Suspense_Flag", SqlDbType.Bit, Convert.ToInt32(Is_Suspense_Flag));
                _dbConnection.AddParameter("@Is_Bo_Suspened_Date", SqlDbType.Bit, Convert.ToInt32(Is_Bo_Suspened_Date));
                _dbConnection.AddParameter("@Is_Suspense_Reason_Code", SqlDbType.Bit, Convert.ToInt32(Is_Suspense_Reason_Code));
                _dbConnection.AddParameter("@Is_Second_Holder_Name", SqlDbType.Bit, Convert.ToInt32(Is_Second_Holder_Name));
                _dbConnection.AddParameter("@Is_Occupation", SqlDbType.Bit, Convert.ToInt32(Is_Occupation));
                _dbConnection.AddParameter("@Is_Date_of_Birth", SqlDbType.Bit, Convert.ToInt32(Is_Date_of_Birth));
                _dbConnection.AddParameter("@Is_Gender", SqlDbType.Bit, Convert.ToInt32(Is_Gender));
                _dbConnection.AddParameter("@Is_BO_Nationality", SqlDbType.Bit, Convert.ToInt32(Is_BO_Nationality));
                _dbConnection.AddParameter("@Is_Tax_ID_Number", SqlDbType.Bit, Convert.ToInt32(Is_Tax_ID_Number));
                _dbConnection.AddParameter("@Is_Origin_of_BO", SqlDbType.Bit, Convert.ToInt32(Is_Origin_of_BO));
      


                _dbConnection.AddParameter("@Is_Account_Number", SqlDbType.Bit, Convert.ToInt32(Is_Account_Number));
                //_dbConnection.ExecuteProQuery(queryStringUpdateDP29);
                _dbConnection.ExecuteNonQuery(queryStringUpdateDP29);
                //_dbConnection.ActiveStoredProcedure();

                //_dbConnection.Commit();
           }
           catch (Exception exception)
           {
               //_dbConnection.Rollback();

               throw exception;
           }
           finally
           {
               //_dbConnection.CloseDatabase();
           }

       }

       public List<string> GetBO_Status(string Cust_Code)
       {
           List<string> result = new List<string>();
           DataTable dataTable;
           string query = "  SELECT  BO_Status "
                        + ",BO_Category "
                        + " FROM dbo.SBP_DP29 "
                        + " WHERE Internal_Reference_Number ='" + Cust_Code + "'";
           try
           {
               _dbConnection.ConnectDatabase();
               dataTable = _dbConnection.ExecuteQuery(query);
               if (dataTable.Rows.Count > 0)
               {
                   result.Add(dataTable.Rows[0][0].ToString());
                   result.Add(dataTable.Rows[0][1].ToString());
               }
           }
           catch (Exception exception)
           {
               throw exception;
           }
           finally
           {
               _dbConnection.CloseDatabase();
           }
           return result;
       }

       public List<string> GetBO_Status(string Cust_Code, string BOID)
       {
           DataTable dataTable;
           List<string> result = new List<string>();
           string query = "  SELECT  BO_Status "
                        + ",BO_Category "
                        + " FROM dbo.SBP_DP29 "
                        + " WHERE Internal_Reference_Number ='" + Cust_Code + "'" + " AND " + "SUBSTRING(BO_ID,9,8)='" + BOID + "'";
           try
           {
               _dbConnection.ConnectDatabase();
               dataTable = _dbConnection.ExecuteQuery(query);
               if (dataTable.Rows.Count > 0)
               {
                   result.Add(dataTable.Rows[0][0].ToString());
                   result.Add(dataTable.Rows[0][1].ToString());
               }
           }
           catch (Exception exception)
           {
               throw exception;
           }
           finally
           {
               _dbConnection.CloseDatabase();
           }
           return result;
       }

       public DataTable GetDP29AllData_ForUpdateDatabase()
       {
           DataTable dataTable;
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
                                + ", [Routing_No]"
                                + ", [Bank_Identification_Code]"
                                + ", [IBAN]"
                                + ", [SWIFT_Code]"
                                 + ",[Suspense_Flag]"
                                  + ",[Bo_Suspened_Date]"
                                  + ",[Suspense_Reason_Code]"
                                  + ",[Second_Holder_Name]"
                                  + ",[Occupation]"
                                  + ",[Date_of_Birth]"
                                  + ",[Gender]"
                                  + ",[BO_Nationality]"
                                  + ",[Tax_ID_Number]"
                                  + ",[Origin_of_BO]" 
                                + "FROM [SBP_Database].[dbo].[SBP_DP29]"
                                +" WHERE "
                                +" Internal_Reference_Number NOT IN ('95','98','99')"
                                +" AND "
                                +" Internal_Reference_Number is not null"
                                +" AND "
                                +" Internal_Reference_Number NOT LIKE '%[^0-9]%' ";
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
