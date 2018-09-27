using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DataAccessLayer;
using BusinessAccessLayer.BO;

namespace BusinessAccessLayer.BAL
{
   public class EmployeeHolidayBal
   {
       private DbConnection _dbConnection;

       public EmployeeHolidayBal()
       {
           _dbConnection=new DbConnection();
       }

       public DataTable GetEmployeeInformation()
       {
         
           string queryString = "";
           queryString = "SELECT EP.EmployeeCode AS 'Employee Code',EP.Name AS 'Employee Name',EP.ContactNumber AS 'ContactNumber',EB.Department AS 'Department',EB.Designation AS 'Desgination',EB.BranchName AS 'Branch Name' FROM SBP_Employee_PaymentInfo EB,SBP_Employee_PersonalInfo EP WHERE EP.EmployeeCode=EB.EmployeeCode AND EB.IsActive=1 ORDER BY EB.EmployeeCode DESC";

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

       private int _totalHoliday;
       public int TotalHoliday
       {
           get { return _totalHoliday; }
           set { _totalHoliday = value; }
       }

       private int _takenHoliday;
       public int TakenHoliday
       {
           get { return _takenHoliday; }
           set { _takenHoliday = value; }
       }

       private int _restHoliday;
       public int RestHoliday
       {
           get { return _restHoliday; }
           set { _restHoliday = value; }
       }

       public void  GetEmployeeHolidayInfo(string EmployeeCode,DateTime fromDate)
       {

         
          string queryString = "GetAnnualLeave";

           DataTable dtHolidayList=new DataTable();

           try
           {
               
               
               _dbConnection.ConnectDatabase();
               _dbConnection.ActiveStoredProcedure();
               _dbConnection.AddParameter("@EmployeeCode", SqlDbType.VarChar, EmployeeCode);
               _dbConnection.AddParameter("@fromDate", SqlDbType.DateTime, fromDate);
               dtHolidayList = _dbConnection.ExecuteProQuery(queryString);

               if(dtHolidayList.Rows.Count>0)
               {
                   _totalHoliday = Int32.Parse(dtHolidayList.Rows[0][0].ToString());
                   _takenHoliday = Int32.Parse(dtHolidayList.Rows[0][1].ToString());
                   _restHoliday = Int32.Parse(dtHolidayList.Rows[0][2].ToString());

               }

               else
               {
                   _totalHoliday = 0;
                   _takenHoliday = 0;
                   _restHoliday = 0;
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

       }

       public void GetEmployeeSickHolidayInfo(string EmployeeCode,DateTime fromDate)
       {

          
           string queryString = "GetSickLeave";
           DataTable dtHolidayList = new DataTable();

           try
           {


               _dbConnection.ConnectDatabase();
               _dbConnection.ActiveStoredProcedure();
               _dbConnection.AddParameter("@EmployeeCode", SqlDbType.VarChar, EmployeeCode);
               _dbConnection.AddParameter("@fromDate", SqlDbType.DateTime, fromDate);
               dtHolidayList = _dbConnection.ExecuteProQuery(queryString);

               if(dtHolidayList.Rows.Count>0)
               {
                   _totalHoliday = Int32.Parse(dtHolidayList.Rows[0][0].ToString());
                   _takenHoliday = Int32.Parse(dtHolidayList.Rows[0][1].ToString());
                   _restHoliday = Int32.Parse(dtHolidayList.Rows[0][2].ToString());


               }

               else
               {
                   _totalHoliday = 0;
                   _takenHoliday = 0;
                   _restHoliday = 0;
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
       }

       public bool CheckToRefreshAnnualHoliday(string employeeCode)
       {
           string queryString = "";
           queryString = "SELECT ISNULL(Yearly_Holiday,0) FROM SBP_Employee_Holiday SH,SBP_Employee_PaymentInfo SP WHERE DATEADD(YEAR,1,SP.JoinDate)<=GETDATE() AND SP.EmployeeCode=SH.EmployeeCode AND SH.EmployeeCode='" + employeeCode + "'";

           bool status = false;
           DataTable dtList=new DataTable();

           try
           {
              _dbConnection.ConnectDatabase();
               dtList = _dbConnection.ExecuteQuery(queryString);

               if(dtList.Rows.Count>0)
               {
                   status = true;
                   _totalHoliday = Int32.Parse(dtList.Rows[0][0].ToString());
                   
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

       public bool CheckToRefreshSickHoliday(string employeeCode)
       {
           string queryString = "";
           queryString = "SELECT ISNULL(Sick_Leave,0) FROM SBP_Employee_Holiday SH,SBP_Employee_PaymentInfo SP WHERE DATEADD(YEAR,1,SP.JoinDate)<=GETDATE() AND SP.EmployeeCode=SH.EmployeeCode AND SH.EmployeeCode='" + employeeCode + "'";

           bool status = false;
           DataTable dtList = new DataTable();

           try
           {
               _dbConnection.ConnectDatabase();
               dtList = _dbConnection.ExecuteQuery(queryString);

               if (dtList.Rows.Count > 0)
               {
                   status = true;
                   _totalHoliday = Int32.Parse(dtList.Rows[0][0].ToString());
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

       public void GetMaternityPolicy(string employeeCode,DateTime fromDate)
       {
           
           string queryString = "GetMaternityLeave";

           
           DataTable dtList = new DataTable();

           try
           {
               _dbConnection.ConnectDatabase();
               _dbConnection.ActiveStoredProcedure();
               _dbConnection.AddParameter("@fromDate", SqlDbType.DateTime, fromDate);
               _dbConnection.AddParameter("@EmployeeCode", SqlDbType.VarChar, employeeCode);
               dtList = _dbConnection.ExecuteProQuery(queryString);

               if(dtList.Rows.Count>0)
               {
                   _totalHoliday = Int32.Parse(dtList.Rows[0][0].ToString());
                   _takenHoliday = Int32.Parse(dtList.Rows[0][1].ToString());
                   _restHoliday = Int32.Parse(dtList.Rows[0][2].ToString());

               }

               else
               {
                   _totalHoliday = 0;
                   _takenHoliday = 0;
                   _restHoliday = 0;
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


       }

       public void GetPaternityPolicy(string employeeCode,DateTime fromDate)
       {
           string queryString = "";
           queryString = "GetPaternityLeave";


           DataTable dtList = new DataTable();

           try
           {
               _dbConnection.ConnectDatabase();
               _dbConnection.ActiveStoredProcedure();
               _dbConnection.AddParameter("@fromDate", SqlDbType.DateTime, fromDate);
               _dbConnection.AddParameter("@EmployeeCode", SqlDbType.VarChar, employeeCode);
               dtList = _dbConnection.ExecuteProQuery(queryString);

               if(dtList.Rows.Count>0)
               {
                   _totalHoliday = Int32.Parse(dtList.Rows[0][0].ToString());
                   _takenHoliday = Int32.Parse(dtList.Rows[0][1].ToString());
                   _restHoliday = Int32.Parse(dtList.Rows[0][2].ToString());
               }

               else
               {
                   _totalHoliday = 0;
                   _takenHoliday = 0;
                   _restHoliday = 0;
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

       }


       public void InsertHoliday(Taken_HolidayBO objTakenBO)
       {
           string queryString = "";
           queryString =
               "INSERT INTO SBP_Employee_TakenHoliday (EmployeeCode,HolidayType,HolidayStartDate,HoliDay,Remarks,Reason,IsApproved,EntryDate) VALUES ('" +
               objTakenBO.EmployeeCode + "','" + objTakenBO.HolidayType + "','" + objTakenBO.StartDate + "'," +
               objTakenBO.Holiday + ",'" + objTakenBO.Remarks + "','" + objTakenBO.Reason + "',0," + "GETDATE());";

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

       public DataTable GetEmployeeHoliday(string employeeCode)
       {
           string queryString = "SELECT HolidayID,HolidayType AS 'Leave Catagory',CONVERT(VARCHAR(12),HolidayStartDate,105) AS 'Start Date',HoliDay AS 'No. of Day',Reason,Remarks,CASE IsApproved WHEN 0 THEN 'Pending' WHEN 2 THEN 'Reject' END AS 'Status' FROM SBP_Employee_TakenHoliday WHERE EmployeeCode='" + employeeCode + "' AND IsApproved!=1  ORDER BY HolidayID DESC";
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

       public void DeleteToHoliday(int HolidayID)
       {
           string queryString = "";
           queryString = "DELETE FROM SBP_Employee_TakenHoliday WHERE HolidayID=" + HolidayID + " AND IsApproved=0";

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

       public bool IsDeletable(int holidayId)
       {
           string queryString = "";
           queryString = "SELECT * FROM SBP_Employee_TakenHoliday WHERE HolidayID=" + holidayId + " AND IsApproved=0";

           DataTable dtList=new DataTable();
           bool Status = false;

           try
           {
               _dbConnection.ConnectDatabase();
               dtList = _dbConnection.ExecuteQuery(queryString);

               if(dtList.Rows.Count>0)
               {
                   Status = true;
               }

               else
               {
                   Status = false;
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

           return Status;
       }

       public DataTable GetEmlpoyeeLeaveList(string employeeCode)
       {
           string queryString = "";
           queryString = "SELECT HolidayID,HolidayType AS 'Leave Catagory',CONVERT(VARCHAR(12),HolidayStartDate,105) AS 'Leave From',HoliDay AS 'Durnation',Remarks,Reason FROM SBP_Employee_TakenHoliday WHERE EmployeeCode='" + employeeCode + "' AND IsApproved=1;";

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

       public void UpdateToEmployeeLeave(int holidayId)
       {
           string queryString = "";
           queryString = "UPDATE SBP_Employee_TakenHoliday SET IsApproved=1 WHERE HolidayID=" + holidayId + ";";

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

       public void UpdateAllEmployeeLeave()
       {
           string queryString = "";
           queryString = "UPDATE SBP_Employee_TakenHoliday SET IsApproved=1 WHERE IsApproved=0;";

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

       public DataTable GetUnapprovedLeaveList()
       {
           string queryString = "";
           queryString = "SELECT SHT.HolidayID,SP.EmployeeCode,SE.Name,SP.Department,SP.Designation,SHT.HolidayType AS 'Leave Type',CONVERT(VARCHAR(12),SHT.HolidayStartDate,105) AS 'Leave From',SHT.HoliDay AS 'Duration'  FROM SBP_Employee_TakenHoliday SHT,SBP_Employee_PaymentInfo SP,SBP_Employee_PersonalInfo SE WHERE SHT.IsApproved=0 AND SHT.EmployeeCode=SP.EmployeeCode AND SHT.EmployeeCode=SE.EmployeeCode;";

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

       

       public void RejectToemployeeLeave(int holidayId,string Remarks)
       {
           string queryString = "";
           queryString = "UPDATE SBP_Employee_TakenHoliday SET IsApproved=2,RejectRemarks='"+Remarks+"' WHERE HolidayID=" + holidayId + ";";

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

       public DataTable GetLeaveDetailsInfo(int leaveid)
       {
           string queryString = "";
           queryString = "SELECT ST.EmployeeCode,ST.HolidayType,CONVERT(VARCHAR(12),ST.HolidayStartDate,105) AS 'FromDate',ST.HoliDay,ST.Remarks,ST.Reason,ST.RejectRemarks,CASE ST.IsApproved WHEN 0 THEN 'Pending' WHEN 2 THEN 'Rejected' END AS Status,SP.Name FROM SBP_Employee_TakenHoliday ST,SBP_Employee_PersonalInfo SP WHERE ST.HolidayID=" + leaveid + " AND ST.EmployeeCode=SP.EmployeeCode;";

           DataTable dtlist=new DataTable();

           try
           {
               _dbConnection.ConnectDatabase();
               dtlist = _dbConnection.ExecuteQuery(queryString);
           }
           catch (Exception)
           {
               
               throw;
           }

           finally
           {
               _dbConnection.CloseDatabase();
           }

           return dtlist;


       }

       public string GetEmployeeName(string employeeCode)
       {
           string queryString = "";
           queryString = "SELECT [Name] FROM SBP_Employee_PersonalInfo WHERE EmployeeCode='" + employeeCode + "';";

           string employeeName = "";
           DataTable dtList=new DataTable();

           try
           {
               _dbConnection.ConnectDatabase();
               dtList = _dbConnection.ExecuteQuery(queryString);

               if (dtList.Rows.Count > 0)
                   employeeName = dtList.Rows[0][0].ToString();
           }
           catch (Exception)
           {
               
               throw;
           }

           finally
           {
               _dbConnection.CloseDatabase();
           }

           return employeeName;
       }

       
   }
}
