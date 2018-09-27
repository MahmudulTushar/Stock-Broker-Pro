using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using BusinessAccessLayer.BO;
using System.Data;

namespace BusinessAccessLayer.BAL
{
    
   public class EmployeePayrollBAL
   {
       #region dbconnection
       private DbConnection _dbconnection;
       #endregion

       #region Constructor
       public EmployeePayrollBAL()
        {
            this._dbconnection = new DbConnection();
        }
       #endregion

       #region Load Grid Data
       public DataTable LoadallEmployeePayrollInfoGridData()
        {
            DataTable dt = new DataTable();
            try
            {
                string query = @"select (sm.title+sm.First_Name +sm.Last_name) as [Employee Name],sp.Employee_ID
                                ,sp.Basic_Amount,sp.House_Rent_Amount,sp.Transport_Allownce
                                ,sp.Medical_Allownce,sp.LFA_Allownce,sp.Provident_Fund,sp.Gross_Salary
                                ,sp.Eid_Bonus,sp.Other_Allownce,sp.Remarks,sp.Effective_From
                                ,sp.Effective_To,sp.Entry_By
                                From SBP_Employee_Payroll_Master sp
                                join SBP_Employee_Master sm
                                on sp.Employee_ID=sm.Employee_ID";

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
       public DataTable GetEmployeePayrooID()
       {
           DataTable dt = new DataTable();
           string query = @"select Employee_ID ,(Title+' '+First_Name+' '+Last_Name) from SBP_Employee_Master order by Employee_ID desc";
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

       #region Get Employee Id for Payroll
       public DataTable GetEmployeePayrooID_Ext(String empID)
       {
           DataTable dt = new DataTable();
           string query = @"SELECT  Employee_ID FROM dbo.SBP_Employee_Payroll_Master
                                                                WHERE  (Employee_ID ='"+empID+"')";
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



        #region Save Payroll Master
        public void Save_Employee_Payroll(EmployeePayrollBo bo)
        {
            string query = @"INSERT INTO [SBP_Employee_Payroll_Master]
                       ([Employee_ID]
                       ,[Basic_Amount]
                       ,[House_Rent_Amount]
                       ,[Transport_Allownce]
                       ,[Medical_Allownce]
                       ,[LFA_Allownce]
                       ,[Provident_Fund]
                       ,[Gross_Salary]
                       ,[Eid_Bonus]
                       ,[Other_Allownce]
                       ,[Remarks]
                       ,[Effective_From]
                       ,[Effective_To]
                       ,[Update_Date]
                       ,[Entry_By])
                         VALUES ("+bo.Emp_Payroll_ID+","
                          +bo.Emp_Payroll_Basic+","
                          +bo.Emp_payroll_House_Rent+","
                          +bo.Emp_Payroll_Transport+","
                          +bo.Emp_Payroll_Medical_Allowance+","
                          +bo.Emp_Payroll_LFA+","
                          +bo.Emp_Payroll_Provident+","
                          +bo.Emp_Payroll_Gross+","
                          +bo.Emp_Payroll_Eid+","
                          +bo.Emp_Payroll_Other+",'"
                          +bo.Emp_Payroll_Remarks+"','"
                          +bo.Emp_Payroll_Effective_From.ToString ("yyyy-MM-dd")+"','"
                          + bo.Emp_Payroll_Effictive_To.ToString("yyyy-MM-dd") + "',convert(varchar(11),getdate(),106),0)";
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

        #region Update Payroll master
        public void UpdateEmpPayroll(EmployeePayrollBo UpBo, int id,bool efficetive)
        { 
            string query=string .Empty ;

            if (efficetive == true)
            {
                query = @"UPDATE [SBP_Employee_Payroll_Master]
                               SET 
                                        [Effective_From] ='" + UpBo.Emp_Payroll_Effective_From.ToString("yyyy-MM-dd") + @"',
                                        [Effective_To]='" + UpBo.Emp_Payroll_Effictive_To.ToString("yyyy-MM-dd") + @"'
                                 
                                 ";

            }
            else
            {
                query = @"UPDATE [SBP_Employee_Payroll_Master]
                               SET 
                                     [Employee_ID] = '" + UpBo.Emp_Payroll_ID + "'"
                                     + ",[Basic_Amount] ='" + UpBo.Emp_Payroll_Basic + "'"
                                     + ",[House_Rent_Amount] ='" + UpBo.Emp_payroll_House_Rent + "'"
                                     + ",[Transport_Allownce] ='" + UpBo.Emp_Payroll_Transport + "'"
                                     + ",[Medical_Allownce] ='" + UpBo.Emp_Payroll_Medical_Allowance + "'"
                                     + ",[LFA_Allownce] ='" + UpBo.Emp_Payroll_LFA + "'"
                                     + ",[Provident_Fund] ='" + UpBo.Emp_Payroll_Provident + "'"
                                     + ",[Gross_Salary] = '" + UpBo.Emp_Payroll_Gross + "'"
                                     + ",[Eid_Bonus] = '" + UpBo.Emp_Payroll_Eid + "'"
                                     + ",[Other_Allownce] = '" + UpBo.Emp_Payroll_Other + "'"
                                     + ",[Remarks] ='" + UpBo.Emp_Payroll_Remarks + "'"
                                     + ",[Effective_From] ='" + UpBo.Emp_Payroll_Effective_From.ToString("yyyy-MM-dd") + "'"
                                     + ", [Effective_To]='" + UpBo.Emp_Payroll_Effictive_To.ToString("yyyy-MM-dd") + "'"
                                     + ",[Update_Date] = getdate()"
                                     + ",[Entry_By] = 0   WHERE Employee_ID='" + id + @"'
                                         
                                  ";
            }
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

        #region Delete Payroll Master
        public void DeletePayrollMaster(int id)
        {
            string query = @"delete from SBP_Employee_Payroll_Master where Employee_ID="+id;
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
