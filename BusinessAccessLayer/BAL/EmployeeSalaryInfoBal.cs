using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessAccessLayer.BO;
using DataAccessLayer;

namespace BusinessAccessLayer.BAL
{
   public class EmployeeSalaryInfoBal
   {
       private DbConnection _dbConnection;

       public EmployeeSalaryInfoBal()
       {
           _dbConnection=new DbConnection();
       }

       public void InsertIntoSalaryInfo(EmployeeSalaryInfoBO objEmployeeSalaryInfoBO)
       {

           string queryString = "";
           queryString = "INSERT INTO SBP_Employee_Salary_Info (EmployeeCode,[PayrollDate],BasicSalary,ProvidentFund,OverTime,Others,Bouns,DeductionAmount,DeductionReason,EntryDate) VALUES ('" +
               objEmployeeSalaryInfoBO.EmployeeCode + "','" + objEmployeeSalaryInfoBO.PayrollDate + "'," + objEmployeeSalaryInfoBO.BasicSalary + "," + objEmployeeSalaryInfoBO.ProFund + "," +
               objEmployeeSalaryInfoBO.OverTime + "," + objEmployeeSalaryInfoBO.Others + "," +
               objEmployeeSalaryInfoBO.Bouns + "," + objEmployeeSalaryInfoBO.DeductionAmount + ",'" + objEmployeeSalaryInfoBO.DeductionnReason + "'," + "GETDATE())";

           try
           {
               _dbConnection.ConnectDatabase();
               _dbConnection.StartTransaction();
               _dbConnection.ExecuteNonQuery(queryString);

               for(int i=0;i<objEmployeeSalaryInfoBO.PurposeId.Count;++i)
               {
                   string purposeQuery = "INSERT INTO SBP_Employee_SalaryPurpose_Info(SalaryID,purposeId,Amount) VALUES (IDENT_CURRENT('SBP_Employee_Salary_Info')," + objEmployeeSalaryInfoBO.PurposeId[i] + "," + objEmployeeSalaryInfoBO.PurposeAmount[i] + ")";
                   _dbConnection.ExecuteNonQuery(purposeQuery);
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

       public DataTable GetEmployeeConfirmationSalary(DateTime payrolldate)
       {
           int month = payrolldate.Month;
           int year = payrolldate.Year;

           string queryString = "";
           queryString = "SELECT EP.EmployeeCode AS 'Employee Code',EP.Name AS 'Employee Name',EP.ContactNumber AS 'ContactNumber',EB.Department AS 'Department',EB.Designation AS 'Desgination',EB.BranchName AS 'Branch Name' FROM SBP_Employee_PaymentInfo EB,SBP_Employee_PersonalInfo EP WHERE EP.EmployeeCode=EB.EmployeeCode AND EB.IsActive=1 AND EP.EmployeeCode NOT IN (SELECT EmployeeCode FROM SBP_Employee_Salary_Info WHERE MONTH(PayrollDate)=" + month + " AND YEAR(PayrollDate)=" + year + ")  ORDER BY EB.EmployeeCode DESC";

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

       public DataTable GetEmployeeSalaryInformation(DateTime payrolldate)
       {
           int month = payrolldate.Month;
           int year = payrolldate.Year;

          string queryString ="SELECT ES.SalaryID,EP.EmployeeCode AS 'Employee Code',EP.Name AS 'Employee Name',EP.ContactNumber AS 'ContactNumber',EB.Department AS 'Department',EB.Designation AS 'Desgination',CAST(ES.BasicSalary-ES.ProvidentFund+ES.OverTime+ES.Others+ES.Bouns-ES.DeductionAmount+(SELECT SUM(Amount) FROM SBP_Employee_SalaryPurpose_Info EPA WHERE EPA.SalaryID=ES.SalaryID) AS FLOAT)  AS 'Gross Salary' FROM SBP_Employee_PaymentInfo EB,SBP_Employee_PersonalInfo EP,SBP_Employee_Salary_Info ES WHERE EP.EmployeeCode=EB.EmployeeCode AND EB.IsActive=1 AND ES.EmployeeCode=EB.EmployeeCode AND (MONTH(ES.PayrollDate)=" + month + " AND YEAR(ES.PayrollDate)=" + year + ") ORDER BY EB.EmployeeCode ASC";
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

     

       public void DeleteToSalaryInfo(int SalaryId)
       {
           string queryString = "";
           queryString = "DELETE FROM SBP_Employee_Salary_Info WHERE SalaryID=" + SalaryId + "";
           string queryPurpose = "DELETE FROM SBP_Employee_SalaryPurpose_Info WHERE SalaryID=" + SalaryId + "";

           try
           {
               _dbConnection.ConnectDatabase();
               _dbConnection.StartTransaction();
               _dbConnection.ExecuteNonQuery(queryString);
               _dbConnection.ExecuteNonQuery(queryPurpose);
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

       public void InsertSalaryPurpose(string purposeName)
       {
           string queryString = "";
           queryString = "INSERT INTO SBP_Salary_Purpose (PurposeName) VALUES ('"+purposeName+"')";

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

       public int GetExistingTotalSalayFacilies()
       {
           string queryString = "SELECT COUNT(*) FROM SBP_Salary_Purpose";
           int ExistingPurpose =0 ;
           DataTable data = new DataTable();

           try
           {
               _dbConnection.ConnectDatabase();
               data = _dbConnection.ExecuteQuery(queryString);
               ExistingPurpose = Int32.Parse(data.Rows[0][0].ToString());
           }

           catch (Exception)
           {
               throw;
           }

           finally
           {
               _dbConnection.CloseDatabase();
           }

           return ExistingPurpose;
       }

       public DataTable GetSalaryPuerposeList()
       {
           string queryString = "";
           queryString = "SELECT PurposeId,PurposeName FROM SBP_Salary_Purpose ORDER BY PurposeId DESC";

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


   }
}
