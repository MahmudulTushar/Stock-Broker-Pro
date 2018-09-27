using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using BusinessAccessLayer.BO;
using System.Data;


namespace BusinessAccessLayer.BAL
{
   public class EmployeeReferenceBAL
    {
        #region dbconnection
        private DbConnection _dbconnection;
        #endregion

        #region Constructor
        public EmployeeReferenceBAL()
        {
            this._dbconnection = new DbConnection();
        }
        #endregion

        #region Load Grid Data
        public DataTable GetEmployeeReferenceInfo()
        {
            DataTable dt = new DataTable();
            try
            {
                string query = @"select distinct (First_Name+Last_Name) as Name
                                , sbp_employee_reference.Employee_ID
                                , Reference_Name
                                , Reference_Profession
                                , Reference_Phone
                                , Reference_Email
                                , Reference_Address 
                                from sbp_employee_reference join SBP_Employee_Master  
                                on  sbp_employee_reference.Employee_Id=SBP_Employee_Master.Employee_Id
                                order by sbp_employee_reference.Employee_Id asc";
                this._dbconnection.ConnectDatabase();
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
        #endregion

        #region Get Employee Id
        public DataTable GetEmployeeId()
        {
            DataTable dt = new DataTable();
            string query = "select Employee_ID, (Title+First_Name+Last_Name) as First_Name from SBP_Employee_Master order by Employee_ID desc";
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

        #region Delete Employee reference info
        public void DelEmprefId(int empid)
        {
            string query = @"delete from SBP_Employee_Reference where Employee_ID ='"+empid+"'";
            try
            {
                this._dbconnection.ConnectDatabase();
                this._dbconnection.ExecuteNonQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this._dbconnection.CloseDatabase();
            }
        }
        #endregion

        #region Save Employee reference Info
        public void SaveEmployeeReferenceInfo(EmployeeReferenceInfoBO objbo)
        {
            string query = @"INSERT INTO [SBP_Employee_Reference]
           ([Employee_ID]
           ,[Reference_Name]
           ,[Reference_Profession]
           ,[Reference_Phone]
           ,[Reference_Email]
           ,[Reference_Address]
           ,[Updated_Date]
           ,[Entry_By])
     VALUES ("+objbo.Ref_Employee_ID+",'"
              +objbo.Ref_Employee_Name+"','"
              + objbo.Ref_Employee_Profession +"','"
              +objbo.Ref_Employee_Phone+"','"
              +objbo.Ref_Employee_Email+"','"
              + objbo.Ref_Employee_Address + "',convert(varchar(11),getdate(),106),0)";
            try
            {
                this._dbconnection.ConnectDatabase();
                this._dbconnection.ExecuteNonQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this._dbconnection.CloseDatabase();
            }
        }
        #endregion

        #region Update Employee Reference Info
        public void UpdatEEmployeeReferenceInfo(EmployeeReferenceInfoBO UpEmpBo, int Id)
        {
            string query = @"UPDATE [SBP_Employee_Reference]
                            SET 
                            [Reference_Name] = '"+UpEmpBo.Ref_Employee_Name +"'"
                          +",[Reference_Profession] = '"+UpEmpBo.Ref_Employee_Profession+"'"
                          +",[Reference_Phone] = '"+UpEmpBo.Ref_Employee_Phone+"'"
                          +",[Reference_Email] = '"+UpEmpBo.Ref_Employee_Email+"'"
                          +",[Reference_Address] = '"+UpEmpBo.Ref_Employee_Address+"'"
                          +",[Updated_Date] = convert(varchar(11),getdate())"
                          + ",[Entry_By] = 0" + " WHERE Employee_Id="+Id+"";
            try
            {
                this._dbconnection.ConnectDatabase();
                this._dbconnection.ExecuteNonQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this._dbconnection.CloseDatabase();
            }

        }
        #endregion


    }
}
