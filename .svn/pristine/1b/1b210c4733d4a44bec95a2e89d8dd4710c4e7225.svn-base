using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using BusinessAccessLayer.BO;
using System.Data;



namespace BusinessAccessLayer.BAL
{
   public class EmployeeInformationBAL
   {
       private DbConnection _dbConnection;

       public EmployeeInformationBAL()
       {
           _dbConnection=new DbConnection();
       }

       public void InsertEmployeelInformation(EmployeePersonalInfoBO objEmployeePersonalInfo, EmployeePaymentBO objEmployeePaymentBO, EmployeeDoucmentBO objEmployeeDoucmentBO,Employee_HolidayBO obJEmployeeHolidayBO,Employee_EmergencyBO objEmgergoBO,SalaryPurposeBO objSalaryPurposeBO)
       {
           string personalqueryString = "";
           personalqueryString =
               "INSERT INTO SBP_Employee_PersonalInfo (EmployeeCode,Title,[Name],[FatherName],[MotherName],[Address],Gender,DOB,FillingStatus,Nationality,NationalID,ContactNumber,HomePhone,EmailAddress,PassportNo,AlternativeNumber,Reference_Name,Reference_Profession,Reference_Phone,Reference_Email,Reference_Address) VALUES ('" +
               objEmployeePersonalInfo.EmployeeCode + "','" + objEmployeePersonalInfo.EmployeeTitle + "','" + objEmployeePersonalInfo.EmployeeName + "','" +
               objEmployeePersonalInfo.FatherName+"','"+ objEmployeePersonalInfo.MotherName + "','"+
               objEmployeePersonalInfo.Address + "','" + objEmployeePersonalInfo.Gender + "','" +
               objEmployeePersonalInfo.DOB  + "','" +
               objEmployeePersonalInfo.FillingStatus + "','" +
               objEmployeePersonalInfo.Nationality + "','" + objEmployeePersonalInfo.NationalID + "','" +
               objEmployeePersonalInfo.ContactNumber + "','" +
               objEmployeePersonalInfo.HomePhone + "','" + objEmployeePersonalInfo.EmailAddress + "','"+
               objEmployeePersonalInfo .PassportNo + "','" + objEmployeePersonalInfo.AlternativePhoneNumber + "','" + objEmployeePersonalInfo.ReferenceName + "','" + objEmployeePersonalInfo.ReferenceProfession + "','" + objEmployeePersonalInfo.ReferencePhoneNumber + "','" + objEmployeePersonalInfo.ReferenceEmailAddress + "','" + objEmployeePersonalInfo.ReferenceAddress  + "')";

           string PaymentqueryString =
               "INSERT INTO SBP_Employee_PaymentInfo (EmployeeCode,[JoinDate],Department,Designation,Responsiblity,PaymentMedia,BankName,BankBranchName,AccountNo,BasicSalary,ProvidentFund,Others,EntryDate,IsActive,BranchName,ReportTo,RecuritedBy,TinNumber) VALUES ('" +
               objEmployeePaymentBO.EmployeeCode + "','" + objEmployeePaymentBO.JoinDate + "','" +
               objEmployeePaymentBO.Department + "','" + objEmployeePaymentBO.JoinPosition + "','" +
               objEmployeePaymentBO.JobResponsibility + "','" + objEmployeePaymentBO.PaymentBy + "','" + objEmployeePaymentBO.BankBranchName + "','" +
               objEmployeePaymentBO.BankName + "','" + objEmployeePaymentBO.AccountNo + "'," +
               objEmployeePaymentBO.BasicSalary + "," + objEmployeePaymentBO.ProFund + "," + objEmployeePaymentBO.Others + ",GETDATE(),1,'"+objEmployeePaymentBO.BanchName+ "','" + objEmployeePaymentBO.ReportTo + "','" + objEmployeePaymentBO.RecuritBy + "','" + objEmployeePaymentBO.TinNumber +"')";


           string HolidayQueryString = "";
           HolidayQueryString =
               "INSERT INTO SBP_Employee_Holiday (EmployeeCode,Yearly_Holiday,Sick_Leave,Maternity_Policy,Paternity_Policy,Remarks) VALUES ('" +
               obJEmployeeHolidayBO.EmployeeCode + "'," + obJEmployeeHolidayBO.YearlyHoliday + "," +
               obJEmployeeHolidayBO.SickLeave + "," +
               obJEmployeeHolidayBO.MaternityPolicy + "," + obJEmployeeHolidayBO.PaternityPolicy + ",'" +
               obJEmployeeHolidayBO.Remarks + "')";

           string EmgergencyQueryString = "INSERT INTO SBP_Employee_Emergency (EmployeeCode,Employee_Disability,BloodGroup,Contact_Person_Name,RelationShip,Contact_Number,Contact_Address,Insurance_Details,Special_Instruction) VALUES ('" + objEmgergoBO.EmployeeCode + "','" + objEmgergoBO.MedicalDisability + "','" + objEmgergoBO.BloodGroup + "','" + objEmgergoBO.ContactPersonName + "','" + objEmgergoBO.RelationShip + "','" + objEmgergoBO.ContactNumber + "','" + objEmgergoBO.Adddress + "','" + objEmgergoBO.MedicalInsurance + "','" + objEmgergoBO.SpecialInstruction + "')";
               
         


           try
           {
               _dbConnection.ConnectDatabase();
               _dbConnection.StartTransaction();
               _dbConnection.ExecuteNonQuery(personalqueryString);
               _dbConnection.ExecuteNonQuery(PaymentqueryString);
               _dbConnection.ExecuteNonQuery(HolidayQueryString);
               _dbConnection.ExecuteNonQuery(EmgergencyQueryString);

               if(objEmployeeDoucmentBO.EmployeeCode!="")
               {
                   string doucementqueryString = "INSERT INTO SBP_Employee_Doucment VALUES(@EmployeeCode,@ImageData)";
                   _dbConnection.AddParameter("@EmployeeCode", SqlDbType.VarChar, objEmployeeDoucmentBO.EmployeeCode);
                   _dbConnection.AddParameter("@ImageData", SqlDbType.Image, objEmployeeDoucmentBO.Image);
                   _dbConnection.ExecuteNonQuery(doucementqueryString);
               }

               for(int i=0;i<objSalaryPurposeBO.PurposeAmount.Count;++i)
               {
                   string queryString = "INSERT INTO SBP_Employee_PurposeAmount (EmployeeCode,purposeId,Amount) VALUES ('"+objSalaryPurposeBO.EmployeeCode + "'," + objSalaryPurposeBO.PurposeId[i] + "," + objSalaryPurposeBO.PurposeAmount[i]+")";
                   _dbConnection.ExecuteNonQuery(queryString);
              
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

       public void InsertEmployeePayment(EmployeePaymentBO objEmployeePaymentBO)
       {
           string queryString = "";

           queryString =
               "INSERT INTO SBP_Employee_PaymentInfo (EmployeeCode,[JoinDate],Department,Designation,Responsiblity,PaymentMedia,BankName,BankBranchName,AccountNo,BasicSalary,HouseRent,Medical,MobileBill,Insurance,Allowance,ProvidentFund,OverTime,Others,EntryDate,IsActive) VALUES ('" +
               objEmployeePaymentBO.EmployeeCode + "','" + objEmployeePaymentBO.JoinDate + "','" +
               objEmployeePaymentBO.Department + "','" + objEmployeePaymentBO.JoinPosition + "','" +
               objEmployeePaymentBO.JobResponsibility + "','" + objEmployeePaymentBO.PaymentBy + "','" + objEmployeePaymentBO.BankBranchName + "','"+
               objEmployeePaymentBO.BankName + "','" + objEmployeePaymentBO.AccountNo + "',"+
               objEmployeePaymentBO.BasicSalary + "," + objEmployeePaymentBO.HouseRent+ "," +
               objEmployeePaymentBO.Medical + "," + objEmployeePaymentBO.MobileBill + ","+
               objEmployeePaymentBO.Insurance + "," + objEmployeePaymentBO.Allowance + "," + objEmployeePaymentBO.ProFund + "," +objEmployeePaymentBO.OverTime + "," + objEmployeePaymentBO.Others + ",GETDATE(),0)";

           try
           {
               _dbConnection.ConnectDatabase();
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

       public  void InsertEmployeeDoucment(EmployeeDoucmentBO objEmployeeDoucmentBO)
       {
           string queryString = "";
           queryString = "INSERT INTO SBP_Employee_Doucment VALUES(@EmployeeCode,@ImageData)";
           try
           {
               _dbConnection.ConnectDatabase();
               _dbConnection.AddParameter("@EmployeeCode",SqlDbType.VarChar,objEmployeeDoucmentBO.EmployeeCode);
               _dbConnection.AddParameter("@ImageData",SqlDbType.Image,objEmployeeDoucmentBO.Image);
               _dbConnection.ExecuteNonQuery(queryString);
           }
           catch (Exception)
           {
               
               throw;
           }
       }

       public bool IsExistEmployeeCode(string EmployeeCode)
       {
           bool status = false;

           string queryString = "";
           queryString = "SELECT * FROM  SBP_Employee_PersonalInfo WHERE EmployeeCode='" + EmployeeCode + "'";

           DataTable datatable=new DataTable();
          

           try
           {
               _dbConnection.ConnectDatabase();
               datatable = _dbConnection.ExecuteQuery(queryString);

               if(datatable.Rows.Count>0)
               {
                   status = true;
               }

               else
               {
                   status = false;
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

           return status;
       }

       public DataTable GetEmployeeInformation()
       {
           string queryString = "";
           queryString = "SELECT EP.EmployeeCode AS 'Employee Code',EP.Name AS 'Employee Name',EP.ContactNumber AS 'ContactNumber',EB.Department AS 'Department',EB.Designation AS 'Desgination',EB.BranchName AS 'Branch Name' FROM SBP_Employee_PaymentInfo EB,SBP_Employee_PersonalInfo EP WHERE EP.EmployeeCode=EB.EmployeeCode AND EB.IsActive=1 ORDER BY EB.EmployeeCode DESC";

           DataTable dtEmployeeInfo=new DataTable();

           try
           {
               _dbConnection.ConnectDatabase();
               dtEmployeeInfo = _dbConnection.ExecuteQuery(queryString);

           }
           catch (Exception)
           {
               
               throw;
           }

           finally
           {
               _dbConnection.CloseDatabase();
           }

           return dtEmployeeInfo;
       }

      

       public DataTable GetDepartmentList()
       {
           string queryString = "";
           queryString = "SELECT DISTINCT Department FROM SBP_Employee_PaymentInfo";

           DataTable dtDepartmentList=new DataTable();

           try
           {
               _dbConnection.ConnectDatabase();
               dtDepartmentList = _dbConnection.ExecuteQuery(queryString);
           }
           catch (Exception)
           {
               
               throw;
           }

           finally
           {
               _dbConnection.CloseDatabase();
           }

           return dtDepartmentList;

       }

       public DataTable GetJobPositionList()
       {
           string queryString = "";
           queryString = "SELECT DISTINCT Designation FROM SBP_Employee_PaymentInfo;";

           DataTable dtJobpositionlist=new DataTable();

           try
           {
               _dbConnection.ConnectDatabase();
               dtJobpositionlist = _dbConnection.ExecuteQuery(queryString);
           }
           catch (Exception)
           {
               throw;
           }

           finally
           {
               _dbConnection.CloseDatabase();
           }

           return dtJobpositionlist;

       }

       public DataTable GetEmployeeInformation(string employeeCode)
       {
           string queryString = "";
           queryString = "SELECT EP.EmployeeCode,EI.[Name],EI.FatherName,EI.MotherName,EI.Address,"+
           "EI.Gender,EI.DOB,EE.BloodGroup,EI.FillingStatus,EI.Nationality,EI.NationalID,"+
           "EI.ContactNumber,EI.Homephone,EI.EmailAddress,EI.PassportNo,"+
           "EP.JoinDate,EP.Department,EP.Designation,EP.Responsiblity,"+
           "EP.PaymentMedia,EP.BankName,EP.BankBranchName,EP.AccountNo,EP.BasicSalary,"+
           "EP.Others,EP.ProvidentFund,ED.Image,EP.BranchName,EP.ReportTo,EI.AlternativeNumber,EI.Reference_Name,EI.Reference_Profession,EI.Reference_Phone,EI.Reference_Email,EI.Reference_Address,EP.RecuritedBy,EP.TinNumber,EH.Yearly_Holiday,EH.Sick_Leave,EH.Maternity_Policy,EH.Remarks,EH.Paternity_Policy,EE.Employee_Disability,EE.Contact_Person_Name,EE.RelationShip,EE.Contact_Number,EE.Contact_Address,EE.Insurance_Details,EE.Special_Instruction,EI.Title FROM SBP_Employee_PersonalInfo EI,SBP_Employee_PaymentInfo EP,SBP_Employee_Emergency EE,SBP_Employee_Holiday EH" +
           " LEFT JOIN SBP_Employee_Doucment ED ON ED.EmployeeCode='"+ employeeCode+
           "' WHERE EP.EmployeeCode='" + employeeCode + "' AND EI.EmployeeCode='" + employeeCode + "' AND EE.EmployeeCode='" + employeeCode + "' AND EH.EmployeeCode='" + employeeCode + "';";

           DataTable dtEmployeeInfo=new DataTable();

           try
           {
               _dbConnection.ConnectDatabase();
               dtEmployeeInfo = _dbConnection.ExecuteQuery(queryString);
           }
           catch (Exception)
           {
               
               throw;
           }

           finally
           {
               _dbConnection.CloseDatabase();
           }

           return dtEmployeeInfo;
       }

       public DataTable GetEmployeeCommonInfoByCode(string employeeCode)
       {
           string queryString = "";
           queryString = "SELECT EI.Name AS 'Name',EI.Address" +
           ",EI.NationalID AS 'National ID'," +
           "EI.ContactNumber AS 'Contact Number'," +
           "EP.Department,EP.Designation," +
           "CAST(EP.BasicSalary AS FLOAT) AS 'Basic Salary Tk.', CAST(EP.BasicSalary+" +
           "EP.HouseRent+EP.Medical+EP.Insurance+EP.Allowance+EP.ProvidentFund+" +
           "EP.Others AS FLOAT) AS 'Grand Salary TK.' FROM SBP_Employee_PersonalInfo EI,SBP_Employee_PaymentInfo EP" +
           " WHERE EP.EmployeeCode='" + employeeCode + "' AND EI.EmployeeCode='" + employeeCode + "';";

           DataTable dtEmployeeInfo = new DataTable();

           try
           {
               _dbConnection.ConnectDatabase();
               dtEmployeeInfo = _dbConnection.ExecuteQuery(queryString);
           }
           catch (Exception)
           {

               throw;
           }

           finally
           {
               _dbConnection.CloseDatabase();
           }

           return dtEmployeeInfo;
       }

       public DataTable GetEmployeeCommonInfoByName(string EmployeeName)
       {
           string queryString = "";
           queryString = "SELECT EP.EmployeeCode AS 'Code',EI.Address" +
           ",EI.NationalID AS 'National ID'," +
           "EI.ContactNumber AS 'Contact No'," +
           "EP.Department,EP.Designation," +
           "CAST(EP.BasicSalary AS FLOAT) AS 'Basic Salary Tk.', CAST(EP.BasicSalary+" +
           "EP.HouseRent+EP.Medical+EP.Insurance+EP.Allowance+EP.ProvidentFund+" +
           "EP.Others AS FLOAT) AS 'Grand Salary Tk.' FROM SBP_Employee_PersonalInfo EI,SBP_Employee_PaymentInfo EP" +
           " WHERE EI.Name='" + EmployeeName + "' AND EI.EmployeeCode=EP.EmployeeCode;";

           DataTable dtEmployeeInfo = new DataTable();

           try
           {
               _dbConnection.ConnectDatabase();
               dtEmployeeInfo = _dbConnection.ExecuteQuery(queryString);
           }
           catch (Exception)
           {

               throw;
           }

           finally
           {
               _dbConnection.CloseDatabase();
           }

           return dtEmployeeInfo;
       }

       public DataTable GetEmployeeCommonInfoByContactNumber(string ContactNumber)
       {
           string queryString = "";
           queryString = "SELECT EP.EmployeeCode AS 'Code',EI.Name AS 'Name',EI.Address" +
           ",EI.NationalID AS 'National ID'," +
           "EP.Department,EP.Designation," +
           "CAST(EP.BasicSalary AS FLOAT) AS 'Basic Salary Tk.', CAST(EP.BasicSalary+" +
           "EP.HouseRent+EP.Medical+EP.Insurance+EP.Allowance+EP.ProvidentFund+" +
           "EP.Others AS FLOAT) AS 'Grand Salary Tk.' FROM SBP_Employee_PersonalInfo EI,SBP_Employee_PaymentInfo EP" +
           " WHERE EI.ContactNumber='" + ContactNumber + "' AND EI.EmployeeCode=EP.EmployeeCode;";

           DataTable dtEmployeeInfo = new DataTable();

           try
           {
               _dbConnection.ConnectDatabase();
               dtEmployeeInfo = _dbConnection.ExecuteQuery(queryString);
           }
           catch (Exception)
           {

               throw;
           }

           finally
           {
               _dbConnection.CloseDatabase();
           }

           return dtEmployeeInfo;
       }




       public void UpdateEmployeeInformation(string employeeCode, EmployeePersonalInfoBO objEmployeePersonalBO, EmployeePaymentBO objEmployeePaymentBO, EmployeeDoucmentBO objEmployeeDoucment,Employee_EmergencyBO objEmployeeEmgerBO,Employee_HolidayBO objEmployeeHolidayBO,SalaryPurposeBO objSalaryPurposeBO)
       {
           string personalqueryString = "";
           personalqueryString = "UPDATE SBP_Employee_PersonalInfo SET [Name]='"+ objEmployeePersonalBO.EmployeeName + "',FatherName='"+objEmployeePersonalBO.FatherName +
           "',MotherName='"+ objEmployeePersonalBO.MotherName + "',Address='"+ objEmployeePersonalBO.Address + "',Gender='" + objEmployeePersonalBO.Gender+
           "',DOB='" + objEmployeePersonalBO.DOB + "',FillingStatus='"+ objEmployeePersonalBO.FillingStatus +
           "',Nationality='"+ objEmployeePersonalBO.Nationality + "',NationalID='"+ objEmployeePersonalBO.NationalID +"',ContactNumber='"+ objEmployeePersonalBO.ContactNumber + 
           "',Homephone='"+ objEmployeePersonalBO.HomePhone + "',EmailAddress='"+ objEmployeePersonalBO.EmailAddress + "',PassportNo='"+ objEmployeePersonalBO.PassportNo + "',Title='" + objEmployeePersonalBO.EmployeeTitle + "',AlternativeNumber='" + objEmployeePersonalBO.AlternativePhoneNumber + "',Reference_Name='" + objEmployeePersonalBO.ReferenceName + "',Reference_Profession='" + objEmployeePersonalBO.ReferenceProfession + "',Reference_Phone='" + objEmployeePersonalBO.ReferencePhoneNumber + "',Reference_Email='" + objEmployeePersonalBO.ReferenceEmailAddress + "',Reference_Address='" + objEmployeePersonalBO.ReferenceAddress+
           "' WHERE EmployeeCode='"+ employeeCode+"';";

           string paymenqueryString = "UPDATE SBP_Employee_PaymentInfo SET JoinDate='" + objEmployeePaymentBO.JoinDate +
              "',Department='" + objEmployeePaymentBO.Department + "',Designation='" + objEmployeePaymentBO.JoinPosition + "',Responsiblity='" + objEmployeePaymentBO.JobResponsibility +
          "',PaymentMedia='" + objEmployeePaymentBO.PaymentBy + "',BankName='" + objEmployeePaymentBO.BankName +
          "',BankBranchName='" + objEmployeePaymentBO.BankBranchName + "',AccountNo='" + objEmployeePaymentBO.AccountNo +
          "',BasicSalary=" + objEmployeePaymentBO.BasicSalary+
          ",Others=" + objEmployeePaymentBO.Others + ",ProvidentFund=" + objEmployeePaymentBO.ProFund + ",BranchName='" + objEmployeePaymentBO.BanchName + "',ReportTo='" + objEmployeePaymentBO.ReportTo + "',RecuritedBy='" + objEmployeePaymentBO.RecuritBy + "',TinNumber='" + objEmployeePaymentBO.TinNumber + "' WHERE EmployeeCode='" + employeeCode + "';";


           string EmgergencyString = "UPDATE SBP_Employee_Emergency SET Employee_Disability='" + objEmployeeEmgerBO.MedicalDisability + "',BloodGroup='" + objEmployeeEmgerBO.BloodGroup + "',Contact_Person_Name='" + objEmployeeEmgerBO.ContactPersonName + "',RelationShip='" + objEmployeeEmgerBO.RelationShip + "',Contact_Number='" + objEmployeeEmgerBO.ContactNumber + "',Contact_Address='" + objEmployeeEmgerBO.Adddress + "',Insurance_Details='" + objEmployeeEmgerBO.MedicalInsurance + "',Special_Instruction='" + objEmployeeEmgerBO.SpecialInstruction+"' WHERE EmployeeCode='" + employeeCode + "';";
           string HolidayString = "UPDATE SBP_Employee_Holiday SET Yearly_Holiday=" + objEmployeeHolidayBO.YearlyHoliday + ",Sick_Leave=" + objEmployeeHolidayBO.SickLeave + ",Maternity_Policy=" + objEmployeeHolidayBO.MaternityPolicy + ",Paternity_Policy="+objEmployeeHolidayBO.PaternityPolicy+",Remarks='" + objEmployeeHolidayBO.Remarks + "' WHERE EmployeeCode='" + employeeCode + "';";

          

    
           try
           {
               _dbConnection.ConnectDatabase();
               _dbConnection.StartTransaction();
               _dbConnection.ExecuteNonQuery(personalqueryString);
               _dbConnection.ExecuteNonQuery(paymenqueryString);
               _dbConnection.ExecuteNonQuery(EmgergencyString);
               _dbConnection.ExecuteNonQuery(HolidayString);

              

               for (int i = 0; i < objSalaryPurposeBO.PurposeAmount.Count;++i)
               {
                   string PurposequeryString = "";
                   if(objSalaryPurposeBO.EmployeePurposeId[i]==0)
                   {
                       PurposequeryString = "INSERT INTO SBP_Employee_PurposeAmount(EmployeeCode,purposeId,Amount) VALUES ('" + employeeCode + "'," + objSalaryPurposeBO.PurposeId[i] + "," + objSalaryPurposeBO.PurposeAmount[i] + ");";
                   }

                   else
                   {
                       PurposequeryString = "UPDATE SBP_Employee_PurposeAmount SET purposeId=" + objSalaryPurposeBO.PurposeId[i] + ",Amount=" + objSalaryPurposeBO.PurposeAmount[i] + " WHERE Employee_Purpose_Id=" + objSalaryPurposeBO.EmployeePurposeId[i] + ";";
                   }

                   _dbConnection.ExecuteNonQuery(PurposequeryString);
                  
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

           if (objEmployeeDoucment.Image != null)
           {
               string doucmentqueryString = "SaveEmployeeDoc";
               _dbConnection.ConnectDatabase();
               _dbConnection.ActiveStoredProcedure();
               _dbConnection.AddParameter("@imageBytes", SqlDbType.Image, objEmployeeDoucment.Image);
               _dbConnection.AddParameter("@employeeCode", SqlDbType.VarChar, employeeCode);
               _dbConnection.ExecuteNonQuery(doucmentqueryString);
               _dbConnection.CloseDatabase();
           }


       }

       public void UpdateEmployeeBasicInfo(string employeeCode,EmployeePaymentBO objEmployeePaymentBO)
       {
           string queryString = "";
           queryString = "UPDATE SBP_Employee_PaymentInfo SET JoinDate='"+ objEmployeePaymentBO.JoinDate + 
               "',Department='"+ objEmployeePaymentBO.Department +"',Designation='"+ objEmployeePaymentBO.JoinPosition+"',Responsiblity='"+ objEmployeePaymentBO.JobResponsibility+
           "',PaymentMedia='" + objEmployeePaymentBO.PaymentBy + "',BankName='" + objEmployeePaymentBO.BankName +
           "',BankBranchName='" + objEmployeePaymentBO.BankBranchName + "',AccountNo='"+ objEmployeePaymentBO.AccountNo + 
           "',BasicSalary="+ objEmployeePaymentBO.BasicSalary +",HouseRent="+ objEmployeePaymentBO.HouseRent +
           ",Medical="+ objEmployeePaymentBO.Medical+ ",MobileBill="+ objEmployeePaymentBO.MobileBill+",Insurance="+ objEmployeePaymentBO.Insurance
           + ",Allowance=" + objEmployeePaymentBO.Allowance + ",ProvidentFund=" + objEmployeePaymentBO.ProFund + ",OverTime="+ objEmployeePaymentBO.OverTime +
           ",Others=" + objEmployeePaymentBO.Others + " WHERE EmployeeCode='" + employeeCode + "';";

           try
           {
               _dbConnection.ConnectDatabase();
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

       public void UpdateEmployeeImage(string EmployeeCode,byte []Imagebytes)
       {
           string queryString = "";
           queryString = "SaveEmployeeDoc";

           try
           {
               _dbConnection.ConnectDatabase();
               _dbConnection.ActiveStoredProcedure();
               _dbConnection.AddParameter("@imageBytes", SqlDbType.Image, Imagebytes);
               _dbConnection.AddParameter("@employeeCode", SqlDbType.VarChar, EmployeeCode);
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

       public void DeleteToEmployeeInfo(string employeeCode, DeleteEmployeeRemorksBO objRemarksBO)
       {
           string PersonInfoQuery = "DELETE FROM SBP_Employee_PersonalInfo WHERE EmployeeCode='" + employeeCode + "'";
           string PaymentQuery = "DELETE FROM SBP_Employee_PaymentInfo WHERE EmployeeCode='" + employeeCode + "'";
           string doucmentQuery = "DELETE FROM SBP_Employee_Doucment WHERE EmployeeCode='" + employeeCode + "'";
           string emgergenceQuery = "DELETE FROM SBP_Employee_Emergency WHERE EmployeeCode='" + employeeCode + "'";
           string holidayQuery = "DELETE FROM SBP_Employee_Holiday WHERE EmployeeCode='" + employeeCode + "'";
           string querySalaryPurpose = "DELETE FROM SBP_Employee_PurposeAmount WHERE EmployeeCode='" + employeeCode + "'";

          string  RemarksqueryString = "INSERT INTO SBP_DeleteEmployee_Remarks (EmployeeCode,Remarks,EntryDate) VALUES ('" + objRemarksBO.EmployeeCode + "','" + objRemarksBO.Remarks + "',GETDATE())";

           try
           {
               _dbConnection.ConnectDatabase();
               _dbConnection.StartTransaction();
               _dbConnection.ExecuteNonQuery(PersonInfoQuery);
               _dbConnection.ExecuteNonQuery(PaymentQuery);
               _dbConnection.ExecuteNonQuery(doucmentQuery);
               _dbConnection.ExecuteNonQuery(emgergenceQuery);
               _dbConnection.ExecuteNonQuery(holidayQuery);
               _dbConnection.ExecuteNonQuery(querySalaryPurpose);
               _dbConnection.ExecuteNonQuery(RemarksqueryString);
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

      
       private int _totalRecord;
       public int TotalRecord
       {
           get { return _totalRecord; }
           set { _totalRecord = value; }
       }

       private int _totalJobPosition;
       public int TotalJobPosition
       {
           get { return _totalJobPosition; }
           set { _totalJobPosition = value; }
       }

       private int _totalDepartment;
       public int TotalDepartment
       {
           get { return _totalDepartment; }
           set { _totalDepartment = value; }
       }

       public void GetCommonInfo()
       {
           string queryString = "SELECT (SELECT COUNT(*) FROM SBP_Employee_PaymentInfo),(SELECT COUNT( DISTINCT Department) FROM SBP_Employee_PaymentInfo),(SELECT COUNT(DISTINCT Designation)FROM SBP_Employee_PaymentInfo)";

           try
           {
               _dbConnection.ConnectDatabase();
               DataTable dtInfo = _dbConnection.ExecuteQuery(queryString);

               _totalRecord = Int32.Parse(dtInfo.Rows[0][0].ToString());
               _totalDepartment = Int32.Parse(dtInfo.Rows[0][1].ToString());
               _totalJobPosition = Int32.Parse(dtInfo.Rows[0][2].ToString());
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

       public DataTable GetEmployeeBasicInformation(string employeeCode)
       {
           string queryString = "";
           queryString = "SELECT EI.[Name]," +
           "EP.Department,EP.Designation,CAST(EP.BasicSalary AS FLOAT)," +
           "CAST(EP.ProvidentFund AS FLOAT)," +
           "CAST(EP.Others AS FLOAT),ED.Image FROM SBP_Employee_PersonalInfo EI,SBP_Employee_PaymentInfo EP" +
           " LEFT JOIN SBP_Employee_Doucment ED ON ED.EmployeeCode='" + employeeCode +
           "' WHERE EP.EmployeeCode='" + employeeCode + "' AND EI.EmployeeCode='" + employeeCode + "';";

           DataTable dtEmployeeInfo = new DataTable();

           try
           {
               _dbConnection.ConnectDatabase();
               dtEmployeeInfo = _dbConnection.ExecuteQuery(queryString);
           }
           catch (Exception)
           {

               throw;
           }

           finally
           {
               _dbConnection.CloseDatabase();
           }

           return dtEmployeeInfo;
       }

       public DataTable GetPurposeInfo(string employeeCode)
       {
           string queryString = "SELECT SBP_Salary_Purpose.PurposeName AS 'Facilities',SBP_Employee_PurposeAmount.Amount,SBP_Employee_PurposeAmount.purposeId FROM SBP_Salary_Purpose,SBP_Employee_PurposeAmount WHERE EmployeeCode='" + employeeCode + "' AND SBP_Employee_PurposeAmount.purposeId=SBP_Salary_Purpose.purposeId";
           DataTable dtList=new DataTable();

           try
           {
               _dbConnection.ConnectDatabase();
               dtList = _dbConnection.ExecuteQuery(queryString);
           }
           catch (Exception)
           {
               
               throw;
           }

           finally
           {
               _dbConnection.CloseDatabase();
           }

           return dtList;
       }

       public float GetTotalPurposeAmount(String employeeCode)
       {
           string queryString = "SELECT ISNULL(SUM(Amount),0) FROM SBP_Employee_PurposeAmount WHERE EmployeeCode='" + employeeCode + "'";
           DataTable dlTotal=new DataTable();

           float amount;

           try
           {
               _dbConnection.ConnectDatabase();
               dlTotal = _dbConnection.ExecuteQuery(queryString);
               amount = float.Parse(dlTotal.Rows[0][0].ToString());
           }
           catch (Exception)
           {
               
               throw;
           }

           finally
           {
               _dbConnection.CloseDatabase();
           }

           return amount;


       }

       public DataTable GetEmployeeSaLaryPurposeInfo(string employeeCode)
       {
           string queryString = "";
           queryString = "SELECT PurposeName,Amount,Employee_Purpose_Id,SA.purposeId FROM SBP_Salary_Purpose SP,SBP_Employee_PurposeAmount SA WHERE SA.EmployeeCode='" + employeeCode + "' AND SA.purposeId=SP.purposeId";

           DataTable dtList=new DataTable();

           try
           {
               _dbConnection.ConnectDatabase();
               dtList = _dbConnection.ExecuteQuery(queryString);
           }
           catch (Exception)
           {
               
               throw;
           }

           finally
           {
               _dbConnection.CloseDatabase();
           }

           return dtList;

       }

      public void DeleteEmployeePurposeAmount(int employeePurposeId)
      {

          string queryString = "";
          queryString = "DELETE FROM SBP_Employee_PurposeAmount WHERE Employee_Purpose_Id=" + employeePurposeId + "";

          try
          {
              _dbConnection.ConnectDatabase();
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
