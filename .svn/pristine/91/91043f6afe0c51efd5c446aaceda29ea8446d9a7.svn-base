using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using System.Data;

namespace BusinessAccessLayer.BAL
{
   public class ReportBAL
   {
       private DbConnection _dbConnection;

       public ReportBAL()
       {
           _dbConnection=new DbConnection();
       }

       public DataTable GetEmployeeCode()
       {
           string queryString = "";
           queryString = "SELECT EmployeeCode FROM SBP_Employee_PaymentInfo";

           DataTable dtEmployeeList=new DataTable();
           try
           {
               _dbConnection.ConnectDatabase();
               dtEmployeeList = _dbConnection.ExecuteQuery(queryString);

           }
           catch (Exception)
           {
               
               throw;
           }

           finally
           {
               _dbConnection.CloseDatabase();
           }

           return dtEmployeeList;
       }

       public DataTable GetEmployeeCommonInfo(string employeeCode)
       {
           string queryString = "";
           queryString = "SELECT EP.Name,EB.Department,EB.Designation FROM SBP_Employee_PaymentInfo EB,SBP_Employee_PersonalInfo EP WHERE EP.EmployeeCode=EB.EmployeeCode AND EB.EmployeeCode='" + employeeCode + "'";

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

       public DataTable GetEmployeeDetailsInfo(String employeeCode)
       {
           string queryString = "SELECT EP.EmployeeCode,EI.[Name],EI.FatherName,EI.MotherName,EI.Address," +
           "EI.Gender,EI.DOB,EM.BloodGroup,EI.FillingStatus,EI.Nationality,EI.NationalID," +
           "EI.ContactNumber,EI.Homephone,EI.EmailAddress,EI.PassportNo,EP.TinNumber," +
           "EP.BranchName,EP.JoinDate,EP.Department,EP.Designation,EP.Responsiblity,EP.ReportTo," +
           "EP.PaymentMedia,EP.BankName,EP.BankBranchName,EP.AccountNo,EP.BasicSalary," +
           "(SELECT SUM(ProvidentFund) FROM dbo.SBP_Employee_Salary_Info WHERE EmployeeCode='" + employeeCode + "') AS 'ProvidentFund'," +
           "EP.Others,ED.Image,EP.BranchName,EP.ReportTo,(SELECT SUM(Amount) FROM SBP_Employee_PurposeAmount EPA WHERE EPA.EmployeeCode=EP.EmployeeCode) AS 'TotalFacilities',(EP.BasicSalary-EP.ProvidentFund+EP.Others+(SELECT SUM(Amount) FROM SBP_Employee_PurposeAmount EPA WHERE EPA.EmployeeCode=EP.EmployeeCode)) AS 'Total',EI.Reference_Name,EI.Reference_Profession,EI.Reference_Phone,EI.Reference_Email,EI.Reference_Address FROM SBP_Employee_PersonalInfo EI,SBP_Employee_PaymentInfo EP,SBP_Employee_Emergency EM" +
           " LEFT JOIN SBP_Employee_Doucment ED ON ED.EmployeeCode='" + employeeCode +
           "' WHERE EP.EmployeeCode='" + employeeCode + "' AND EI.EmployeeCode='" + employeeCode + "' AND EM.EmployeeCode='"+employeeCode+"';";

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

       public DataTable GetEmployeePurposeList(string employeeCode)
       {
           string queryString = "SELECT PurposeName,Amount FROM SBP_Salary_Purpose,SBP_Employee_PurposeAmount WHERE EmployeeCode='" + employeeCode + "' AND SBP_Salary_Purpose.purposeId=SBP_Employee_PurposeAmount.purposeId";
           DataTable dtList = new DataTable();

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

       public DataTable GetEmployeeWiseSalaryHistoy(string employeeCode)
       {
           string queryString = "SELECT PayrollDate,BasicSalary,(SELECT SUM(Amount) FROM SBP_Employee_SalaryPurpose_Info EPA WHERE EPA.SalaryID=SBP_Employee_Salary_Info.SalaryID) AS 'Total Facilities',Others,Bouns,OverTime,ProvidentFund,DeductionAmount,(BasicSalary+Others+Bouns+OverTime-ProvidentFund-DeductionAmount+(SELECT SUM(Amount) FROM SBP_Employee_SalaryPurpose_Info EPA WHERE EPA.SalaryID=SBP_Employee_Salary_Info.SalaryID)) AS 'Total'FROM dbo.SBP_Employee_Salary_Info WHERE dbo.SBP_Employee_Salary_Info.EmployeeCode='" + employeeCode + "';";

           DataTable dtSalaryInfo=new DataTable();

           try
           {
               _dbConnection.ConnectDatabase();
               dtSalaryInfo = _dbConnection.ExecuteQuery(queryString);

           }
           catch (Exception)
           {
               
               throw;
           }

           finally
           {
               _dbConnection.CloseDatabase();
           }

           return dtSalaryInfo;
       }

       public DataTable GetEmployeeSalaryHistory(DateTime payrollDate)
       {

           int Month = payrollDate.Month;
           int Year = payrollDate.Year;

           string queryString = "SELECT SB.EmployeeCode,SP.Name,SB.Department,SB.Designation,ss.BasicSalary,(SELECT SUM(Amount) FROM SBP_Employee_SalaryPurpose_Info EPA WHERE EPA.SalaryID=ss.SalaryID) AS 'Total Facilities',ss.Others,ss.ProvidentFund,ss.Bouns,ss.OverTime,ss.DeductionAmount,(ss.BasicSalary+ss.Others-ss.ProvidentFund+ss.Bouns+ss.OverTime-ss.DeductionAmount + (SELECT SUM(Amount) FROM SBP_Employee_SalaryPurpose_Info EPA WHERE EPA.SalaryID=ss.SalaryID)) AS 'Total' FROM dbo.SBP_Employee_Salary_Info SS,dbo.SBP_Employee_PersonalInfo SP,dbo.SBP_Employee_PaymentInfo SB WHERE SB.EmployeeCode=SP.EmployeeCode AND SB.EmployeeCode=SS.EmployeeCode AND (MONTH(SS.PayrollDate)=" + Month + " AND YEAR(ss.PayrollDate)=" + Year + ");";

           DataTable dtSalaryInfo = new DataTable();

           try
           {
               _dbConnection.ConnectDatabase();
               dtSalaryInfo = _dbConnection.ExecuteQuery(queryString);

           }
           catch (Exception)
           {

               throw;
           }

           finally
           {
               _dbConnection.CloseDatabase();
           }

           return dtSalaryInfo;
       }

       public DataTable GetEmployeeInfo()
       {

           string queryString = "SELECT SB.EmployeeCode,SP.Name,SB.Department,SB.Designation,SP.ContactNumber,SB.BasicSalary,(SELECT SUM(Amount) FROM SBP_Employee_PurposeAmount EPA WHERE EPA.EmployeeCode=SB.EmployeeCode) AS 'Facilities',SB.Others,SB.ProvidentFund,(SB.BasicSalary+SB.Others-SB.ProvidentFund+(SELECT SUM(Amount) FROM SBP_Employee_PurposeAmount EPA WHERE EPA.EmployeeCode=SB.EmployeeCode)) AS 'Total' FROM dbo.SBP_Employee_PersonalInfo SP,dbo.SBP_Employee_PaymentInfo SB WHERE SB.EmployeeCode=SP.EmployeeCode AND SB.IsActive=1 ;";

           DataTable dtSalaryInfo = new DataTable();

           try
           {
               _dbConnection.ConnectDatabase();
               dtSalaryInfo = _dbConnection.ExecuteQuery(queryString);

           }
           catch (Exception)
           {

               throw;
           }

           finally
           {
               _dbConnection.CloseDatabase();
           }

           return dtSalaryInfo;
       }

    

       public DataTable GetNettingSumery(DateTime date)
       {
           string queryString = "SP_FinNetting";

           DataTable data = new DataTable();
           try
           {
               _dbConnection.ConnectDatabase();
               _dbConnection.TimeoutPeriod = 5000;
               _dbConnection.ActiveStoredProcedure();
               _dbConnection.AddParameter("@date", SqlDbType.DateTime, date.ToString("yyyy-MM-dd"));
               data = _dbConnection.ExecuteProQuery(queryString);
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

       public DataTable GetTurnOver(int month, int year)
       {
           string queryString = "SELECT UserID AS 'WorkStation', SUM(TotalShareValue)AS 'TradeAmount' FROM SBP_Transactions WHERE MONTH(EventDate)=" + month+ " AND YEAR(EventDate)=" + year+ " GROUP BY UserID";

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

       
   }
}
