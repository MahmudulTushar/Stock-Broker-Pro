using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using BusinessAccessLayer.BO;
using System.Data;

namespace BusinessAccessLayer.BAL
{
   public class EmployeeAdditionalInfoBAL
   {
       #region dbconnection
       private DbConnection _dbconnection;
       #endregion

       #region Constructor
       public EmployeeAdditionalInfoBAL()
        {
            this._dbconnection = new DbConnection();
        }
       #endregion

       #region Bank and Branch Nmae query
       public DataTable GetBankName(string id)
        {
            DataTable dtBankName = new DataTable();
            try
            {
                string query = @"select Bank_ID,Bank_Name from dbo.SBP_Bank_Branch_Routing_Info
                                    where Routing_No=" +id;
                this._dbconnection.ConnectDatabase();
                dtBankName = this._dbconnection.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtBankName;
        }

       public DataTable GetBankName()
       {
           DataTable dtBankName = new DataTable();
           try
           {
               string query = @"select ID as Bank_ID,Bank_Name from dbo.SBP_Bank_Info";
                                    
               this._dbconnection.ConnectDatabase();
               dtBankName = this._dbconnection.ExecuteQuery(query);
           }
           catch (Exception ex)
           {
               throw ex;
           }
           return dtBankName;
       }
         

        public DataTable GetBranchname(string id)
        {
            //string Branch_Name = "";
            DataTable dt = new DataTable();
            try
            {
                string query = @"select Branch_ID,Branch_Name from dbo.SBP_Bank_Branch_Routing_Info
                                    where Routing_No=" +id;
                this._dbconnection.ConnectDatabase();
                dt = this._dbconnection.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
            //if (dt.Rows.Count > 0)
            //{
            //    Branch_Name = dt.Rows[0][0].ToString();
            //}
            //return Branch_Name;
        }
        public DataTable GetBranchname( )
        {
            //string Branch_Name = "";
            DataTable dt = new DataTable();
            try
            {
                string query = @"select ID as Branch_ID,Branch_Name from dbo.SBP_Branch_Info";
                                     
                this._dbconnection.ConnectDatabase();
                dt = this._dbconnection.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
            //if (dt.Rows.Count > 0)
            //{
            //    Branch_Name = dt.Rows[0][0].ToString();
            //}
            //return Branch_Name;
        }
       #endregion

       #region Get Bank Branch Route no
        public DataTable GetBranchRoutNo()
        {
            DataTable dt = new DataTable();
            string query = @"select Routing_No from SBP_Bank_Branch_Routing_Info order by Routing_No";
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

       #region Photo
        public bool CheckIsExistPhot(EmployeeBasicInfoBO bo)
        {
            bool result = false;
            DataTable dt = new DataTable();
            string checkQuery = @"select Employee_ID,Employee_Photo 
                                from SBP_Employee_Master where Employee_ID= '" + bo.Employee_Id + "'";
            try
            {
                this._dbconnection.ConnectDatabase();
                dt = this._dbconnection.ExecuteQuery(checkQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            if (dt.Rows.Count > 0)
            {
                result = true;
            }
            return result;

        }
        public void SavetoDataBase(EmployeeBasicInfoBO bo,EmployeeAdditionalInfoBO ado)
        {
            DataTable dt = new DataTable();
            string query = @"UPDATE SBP_Employee_Master 
                            set Employee_Photo=@image where Employee_ID='" + bo.Employee_Id + "'";
            try
            {
                this._dbconnection.ConnectDatabase();
                this._dbconnection.AddParameter("@image", SqlDbType.Image, ado.ImgByte);

                this._dbconnection.ExecuteNonQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       #endregion
   }
}
