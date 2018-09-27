using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using BusinessAccessLayer.BO;
using System.Data;

namespace BusinessAccessLayer.BAL
{
   public class EmployeeBasicInfoBAL
    {
        #region dbconnection
        private DbConnection _dbconnection;
        #endregion

        #region Constructor
        public EmployeeBasicInfoBAL()
        {
            this._dbconnection = new DbConnection();
        }
        #endregion

        #region Load All Employee Information into Grid
        public DataTable GetEmployeeAllBasicInfo()
        {
            DataTable dt = new DataTable();
            string query = @"SELECT [Employee_ID]
                          ,[Title]
                          ,[First_Name]
                          ,[Last_Name]
                          ,[Date_Of_Joining]
                          ,[Supervisor_EmpID]
                          ,[Department]
                          ,[Date_of_Birth]
                          ,[Bank_Account_No]
                          ,[Bank_ID]
                          ,[Bank_Name]
                          ,[Branch_ID]
                          ,[Bank_Branch]
                          ,[Bank_Routing_No]
                          ,[Nationality]
                          ,[National_ID_No]
                          ,[TIN]
                          ,[Passport_No]
                          ,[Contact_Number]
                          ,[Alterate_Contact_Number]
                          ,[Home_Phone]
                          ,[Email]
                          ,[Father_Name]
                          ,[Mother_Name]
                          ,[Present_Address]
                          ,[Permanent_Address]
                          ,[Gender]
                          ,[Marital_Status]
                          ,[Date_Of_Discharge]
                          --,[Employee_Photo]
                          --,[Update_Date]
                          --,[Entry_By]
                      FROM [SBP_Employee_Master]";
            try
            {
                this._dbconnection.ConnectDatabase();
                dt=this._dbconnection.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this._dbconnection.CloseDatabase();
            }
            return dt;
        }
        #endregion

        #region Get Employee Id
        public string GetEmployeeId(string id)
        {
            string employeeId = "";
            DataTable dt = new DataTable();
            try
            {
                string query = @"select Employee_ID from dbo.SBP_Employee_Master where Employee_ID= '"+id+"'";
                this._dbconnection.ConnectDatabase();
                dt=this._dbconnection.ExecuteQuery(query);
            }
            catch (Exception ed)
            {
                throw ed;
            }
            if (dt.Rows.Count > 0)
            {
                employeeId = dt.Rows[0][0].ToString();
            }
            return employeeId;
        }
        #endregion

        #region GetDepartMent
        public DataTable GetDepartment()
        {
            DataTable dt = new DataTable();
            string query = @"select distinct Department from dbo.SBP_Employee_Master order by Department asc";
            try
            {
                this._dbconnection.ConnectDatabase();
                dt=this._dbconnection.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this._dbconnection.CloseDatabase();
            }
            return dt;
        }
        #endregion

        #region Get new Employee id
        public int GetNewEmployeeId()
        {
            string NewId = "";
            DataTable dt = new DataTable();
            try
            {
//                string query = @"declare @NewEmpId int
//                                    select @NewEmpId= case when max(Employee_ID) is null then 0 else max(Employee_ID) end 
//                                    from SBP_Employee_Master
//                                    set @NewEmpId=@NewEmpId+1";
               string query = @"select isnull(max(Employee_ID),0) from SBP_Employee_Master";
                this._dbconnection.ConnectDatabase();
                dt=this._dbconnection.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            if (dt.Rows.Count > 0)
            {
                NewId = dt.Rows[0][0].ToString();
            }
            return int.Parse(NewId);
            //return dt;
        }
        #endregion

        #region Get Employee Id for comboBox
        public DataTable GetComboId()
        {
            DataTable dt = new DataTable();
            string query = @"select Employee_ID from SBP_Employee_Master order by Employee_ID asc";
            try
            {
                this._dbconnection.ConnectDatabase();
                dt = this._dbconnection.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        #endregion

        #region SupervisorId

        public DataTable GetSuperVisorId()
        {
            DataTable dt = new DataTable();
            string query = @"select Employee_ID,First_Name from SBP_Employee_Master order by Employee_ID asc";
            try
            {
                this._dbconnection.ConnectDatabase();
                dt = this._dbconnection.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        #endregion


        public DataTable Get_EmpImage(String EmpID )
        {
            DataTable dt = new DataTable();
            string query = @"SELECT Emp_ID, Emp_Image  FROM  HR_EmpImageDT Where Emp_ID='"+EmpID +"' ";
            try
            {
                this._dbconnection.Connect_ImageDB();
                dt = this._dbconnection.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this._dbconnection.CloseDatabase();
            }
            return dt;
        }



    }
}
