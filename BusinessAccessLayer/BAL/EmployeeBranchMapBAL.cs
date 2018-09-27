using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using BusinessAccessLayer.BO;
using System.Data;

namespace BusinessAccessLayer.BAL
{
   public class EmployeeBranchMapBAL
    {
        #region dbconnection
        private DbConnection dbconnection;
        #endregion

        #region Constructor

        public EmployeeBranchMapBAL()
        {
            this.dbconnection = new DbConnection();
        }
        #endregion
       
        #region Load ComboBox
        public DataTable GetEmployeeID()
        {
            DataTable dt = new DataTable();
            string query = @"select Employee_ID from SBP_Employee_Master order by Employee_ID desc";
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
        public string GetEmployeeName(string Id)
        {
            string EmpId="";
            DataTable dt = new DataTable();
            string query = @"select (Title+First_Name+Last_Name) as Name from dbo.SBP_Employee_Master
                            where Employee_ID = " + Id;
            try
            {
                this.dbconnection.ConnectDatabase();
                dt = this.dbconnection.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //return dt;
            if (dt.Rows.Count > 0)
            {
                EmpId = dt.Rows[0][0].ToString();
            }
            return EmpId;
        }
        public DataTable GetBranchNameOrId()
        {
            DataTable dt = new DataTable();
            string query = @"select Branch_ID,Branch_Name from dbo.SBP_Broker_Branch";
            try
            {
                this.dbconnection.ConnectDatabase();
                dt=this.dbconnection.ExecuteQuery(query);
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
        public DataTable GetWorkStationName()
        {
            DataTable dt = new DataTable();
            string query = @"select 'N/A' as 'WorkStation_Name'
                            union
                            select WorkStation_Name from dbo.SBP_Workstation
                            order By WorkStation_Name desc";
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

        #region Branch Id by BranchName
        public string GetBranchId(string Name)
        {
            string Id = "";
            DataTable dt = new DataTable();
            string query = @" select Branch_ID from dbo.SBP_Broker_Branch where Branch_Name='"+Name+"'";
            try
            {
                this.dbconnection.ConnectDatabase();
                dt=this.dbconnection.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            if (dt.Rows.Count > 0)
            {
                Id = dt.Rows[0][0].ToString();
            }
            return Id;
        }
        #endregion

        #region Load Grid Data
        public DataTable LoadEmpBranMapGridData()
        {
            DataTable dt = new DataTable();
            string query = @"select 
                             (Title+First_Name+Last_Name) as Name
                             ,SBP_Employee_Branch_Mapping.Employee_ID
                             ,(select Branch_Name from SBP_Broker_Branch 
                                where SBP_Broker_Branch.Branch_ID =Broker_Branch_ID) As [Branch Name]
                             ,Effective_From_Date
                             ,Effective_To_Date
                             ,Workstation_ID
                             from SBP_Employee_Branch_Mapping 
                             join SBP_Employee_Master
                             on SBP_Employee_Branch_Mapping.Employee_ID=SBP_Employee_Master.Employee_ID
                             order by SBP_Employee_Branch_Mapping.Employee_ID asc";
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

        #region Get New Employee Id
        //public string GetEmpBranMapId()
        //{
        //    DataTable dt = new DataTable();
        //    string Id = "";
        //    string query = @"select max(Employee_ID) from SBP_Employee_Branch_Mapping";
        //    try
        //    {
        //        this.dbconnection.ConnectDatabase();
        //       dt= this.dbconnection.ExecuteQuery(query);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    if (dt.Rows.Count > 0)
        //    {
        //        Id = dt.Rows[0][0].ToString();
        //    }
        //    return Id;
             
        //}
        public DataTable GetEmpBranMapId()
        {
            DataTable dt = new DataTable();
            string query = @"select Employee_ID , (Title+First_Name+Last_Name) from SBP_Employee_Master order by Employee_ID desc";
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

        #region Save Branch Mapping
        public void SaveBranchMaping(EmployeeBranchMapBO mapBo)
        {
            string query = @"INSERT INTO [SBP_Employee_Branch_Mapping]
                           ([Employee_ID]
                           ,[Broker_Branch_ID]
                           ,[Effective_From_Date]
                           ,[Effective_To_Date]
                           ,[Workstation_ID]
                           ,[Update_Date]
                           ,[Entry_By])
                             VALUES ("+mapBo.Branch_Map_Employee_ID+",'"
                            +mapBo.Branch_Map_Employee_Brach_ID+"','"
                            + mapBo.Branch_Map_Employee_From_Date.ToString ("yyyy-MM-dd")+"','"
                            + mapBo.Branch_Map_Employee_To_Date.ToString("yyyy-MM-dd") + "','"
                            +mapBo.Branch_Map_Employee_WorkStation_ID+"',getdate(),0)";
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

        #region Update Branch Mapping
        public void UpdateBranchMapping(EmployeeBranchMapBO braBo, int Id)
        {
            string query = @"UPDATE [SBP_Employee_Branch_Mapping]
                               SET [Employee_ID] = "+braBo.Branch_Map_Employee_ID+""
                                  +",[Broker_Branch_ID] ='"+braBo.Branch_Map_Employee_Brach_ID+"'"
                                  + ",[Effective_From_Date] ='" + braBo.Branch_Map_Employee_From_Date.ToString("yyyy-MM-dd") + "'"
                                  + ",[Effective_To_Date] ='" + braBo.Branch_Map_Employee_To_Date.ToString("yyyy-MM-dd") + "'"
                                  +",[Workstation_ID] ='"+braBo.Branch_Map_Employee_WorkStation_ID+"'"
                                  +",[Update_Date] = getdate()"
                                  + ",[Entry_By] =0 WHERE [Employee_ID]=" + Id + "";
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

        #region Delete Branch Mapping
        public void DeleteEmployeeBranMap(int id)
        {
            string query = @"delete from dbo.SBP_Employee_Branch_Mapping where Employee_ID="+id;
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
