using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using BusinessAccessLayer.BO;
using System.Data;

namespace BusinessAccessLayer.BAL
{
   public class EmployeeEmergencyBAL
   {
       #region dbconnection
       private DbConnection dbconnection;
       #endregion

       #region Constructor
       public EmployeeEmergencyBAL()
       {
           this.dbconnection = new DbConnection();
       }
       #endregion

       #region Load grid data
       public DataTable GetEmployeeReferenceInfo()
       {
           DataTable dt = new DataTable();
           string query = @"select (First_Name+' '+ Last_Name) as Name
                            , sbp_employee_Emergency.Employee_ID
                            ,Emergency_Contact_Person
                            ,Blood_Group
                            ,RelationShip
                            ,sbp_employee_Emergency.Contact_Number
                            ,Contact_Address
                            ,Insurance_Details
                            ,Special_Instruction
                            ,Remarks
                            from sbp_employee_Emergency   join SBP_Employee_Master  
                            on  sbp_employee_Emergency.Employee_Id=SBP_Employee_Master.Employee_Id
                            order by sbp_employee_Emergency.Employee_Id asc";
           try
           {
               this.dbconnection.ConnectDatabase();
               dt = this.dbconnection.ExecuteQuery(query);
           }
           catch (Exception ex)
           {
               throw ex;
           }
           finally
           {
               this.dbconnection.CloseDatabase();
           }
           return dt;
       }
       #endregion

       #region Get Employee id
       public DataTable GetEmployeeEmrId()
       {
           DataTable dt = new DataTable();
           string query = "select Employee_ID ,(Title+' '+First_Name+' '+Last_Name) from SBP_Employee_Master order by Employee_ID desc";
           try
           {
               this.dbconnection.ConnectDatabase();
               dt = this.dbconnection.ExecuteQuery(query);
           }
           catch (Exception ex)
           {
               throw ex;
           }
           return dt;
       }
       #endregion

       #region Save Employee Emergency Info
       public void SaveEmpEmrInfo(EmployeeEmergencyBO EmrBo)
       {
           string query = @"INSERT INTO [SBP_Employee_Emergency]
           ([Employee_ID]
           ,[Blood_Group]
           ,[Emergency_Contact_Person]
           ,[RelationShip]
           ,[Contact_Number]
           ,[Contact_Address]
           ,[Insurance_Details]
           ,[Special_Instruction]
           ,[Remarks]
           ,[Update_Date]
           ,[Entry_By])
     VALUES ("+EmrBo.Employee_Emr_ID+",'"
              +EmrBo.Employee_Emr_Blood_Group.ToUpper()+"','"
              +EmrBo.Employee_Emr_Contact_Person+"','"
              +EmrBo.Employee_Emr_Relationship+"','"
              +EmrBo.Employee_Emr_Contact_Number+"','"
              +EmrBo.Employee_Emr_Contact_Address+"','"
              +EmrBo.Employee_Emr_Insurance_Details+"','"
              +EmrBo.Employee_Emr_Special_Instruction+"','"
              + EmrBo.Employee_Emr_Remarks + "',convert(varchar(11),getdate()),0)";
           try
           {
               this.dbconnection.ConnectDatabase();
               this.dbconnection.ExecuteNonQuery(query);

           }
           catch (Exception ex)
           {
               throw ex;
           }
           finally
           {
               this.dbconnection.CloseDatabase();
           }
       }
       #endregion

       #region Delete Employee Emergency Info
       public void DeleteEmpEmrInfo(int Id)
       {
           string query = @"delete from SBP_Employee_Reference where Employee_ID = "+Id;
           try
           {
               this.dbconnection.ConnectDatabase();
               this.dbconnection.ExecuteNonQuery(query);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       #endregion

       #region Update Employee Emergency
       public void UpdateEmployeeEmergencyInfo(EmployeeEmergencyBO bo, int id)
       {
           string query = @"UPDATE [SBP_Employee_Emergency]
                                SET [Employee_ID] = "+bo.Employee_Emr_ID+"" 
                              +",[Blood_Group] ='"+bo.Employee_Emr_Blood_Group.ToUpper()+"'"
                              +",[Emergency_Contact_Person] ='"+bo.Employee_Emr_Contact_Person+"'"
                              +",[RelationShip] ='"+bo.Employee_Emr_Relationship+"'"
                              +",[Contact_Number] ='"+bo.Employee_Emr_Contact_Number+"'"
                              +",[Contact_Address] ='"+bo.Employee_Emr_Contact_Address+"'"
                              +",[Insurance_Details] ='"+ bo.Employee_Emr_Insurance_Details+"'"
                              +",[Special_Instruction] ='"+bo.Employee_Emr_Special_Instruction+"'"
                              +",[Remarks] ='"+bo.Employee_Emr_Remarks+"'"
                              +",[Update_Date] = convert(varchar(11),getdate())"
                              +",[Entry_By] =0"
                         +"WHERE  [Employee_ID] ="+id;
           try
           {
               this.dbconnection.ConnectDatabase();
               this.dbconnection.ExecuteNonQuery(query);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       #endregion
   }
}
