using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using BusinessAccessLayer.BO;
using System.Data;

namespace BusinessAccessLayer.BAL
{
    public class EmployeeBasicAndAdditionalInfoBAL
    {
        #region dbconnection
        private DbConnection _dbconnection;
        #endregion

        #region Constructor
        public EmployeeBasicAndAdditionalInfoBAL()
        {
            this._dbconnection = new DbConnection();
        }
        #endregion

        #region Save New Employee information

        public void SaveEmployeeAllInformation(EmployeeBasicInfoBO objBasicBo,EmployeeAdditionalInfoBO objadditionalbo)
        {
            string queryString = "";
            queryString = @"INSERT INTO [SBP_Employee_Master]
           ([Employee_ID]
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
           ,[Emp_Stutse]
           ,[Employee_Photo]
           ,[Update_Date]            
           ,[Entry_By]
          
           )
     VALUES ('" + objBasicBo.Employee_Id + "','"
              + objBasicBo.Employee_Tittle + "','"
              + objBasicBo.Employee_First_Name + "','"
              + objBasicBo.Employee_Last_Name + "','"
              + objBasicBo.Employee_Join_Date + "','"
              + objBasicBo.Employee_Supervisor_Id + "','"
              + objBasicBo.Employee_Departmnent_Name + "','"
              + objBasicBo.Employee_Birth_Date + "','"
              + objadditionalbo.Employee_Bank_Acc_No + "','"
              + objadditionalbo.Employee_Bank_Id + "','"
              + objadditionalbo.Employee_Bank_Name + "','"
              + objadditionalbo.Employee_Branch_Id + "','"
              + objadditionalbo.Employee_Branch_Name + "','"
              + objadditionalbo.Employee_Bank_Route_No + "','"
              + objadditionalbo.Employee_Nationality + "','"
              + objadditionalbo.Employee_National_Id_No + "','"
              + objadditionalbo.Employee_Tin + "','"
              + objadditionalbo.Employee_Passport  + "','"
              + objBasicBo.Employee_Contact_Number + "','"
              + objBasicBo.Employee_Alter_Contact_Number + "','"
              + objBasicBo.Employee_Home_Phone + "','"
              + objBasicBo.Employee_Email + "','"
              + objBasicBo.Employee_Father_Name + "','"
              + objBasicBo.Employee_Mother_Name + "','"
              + objadditionalbo.Employee_Present_Address + "','"
              + objadditionalbo.Employee_Permanent_Address + "','"
              + objBasicBo.Employee_Gender + "','"
              + objBasicBo.Employee_Maritial_Status + "','"
              + objBasicBo.Employee_Discharge_Date + "','"
              + objBasicBo.Employee_Status + "','"
              + objadditionalbo.ImgByte + "',Getdate(),'0')"
             
              
              ;
            try
            {
                this._dbconnection.ConnectDatabase();
                //this._dbconnection.AddParameter("@image", SqlDbType.Image, objadditionalbo.ImgByte);
                this._dbconnection.ExecuteNonQuery(queryString);
                this._dbconnection.CloseDatabase();

                queryString = @"INSERT INTO HR_EmpImageDT
                                                    (
                                                    Emp_ID,
                                                    Emp_Image
                                                    )
                                                    VALUES 
                                                    (
                                                    '" + objBasicBo.Employee_Id + @"'
                                                    ,@EMP_Image
                                                    )
                                  ";
                
                _dbconnection.Connect_ImageDB();
                _dbconnection.AddParameter("@EMP_Image", SqlDbType.Binary, objadditionalbo.ImgByte);

                this._dbconnection.ExecuteNonQuery(queryString);
                this._dbconnection.CloseDatabase();

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

        #region Update Employee Information


        /// <summary>
        /// //////////////////////
       
        public void UpdateEmployeeInformation(EmployeeBasicInfoBO objBasicBo, EmployeeAdditionalInfoBO objadditionalbo, int id)
        {
            if (objBasicBo.Employee_Discharge_Date == Convert.ToDateTime("1930-01-01"))
            {
                objBasicBo.Employee_Discharge_Date = Convert.ToDateTime(null);
            }
            string query = @"UPDATE [SBP_Employee_Master]
                           SET [Employee_ID] = "+objBasicBo.Employee_Id +""
                              +",[Title] = '"+objBasicBo.Employee_Tittle +"'"
                              +",[First_Name] ='"+objBasicBo.Employee_First_Name +"'"
                              +",[Last_Name] ='"+objBasicBo.Employee_Last_Name +"'"
                              +",[Date_Of_Joining] ='"+objBasicBo.Employee_Join_Date +"'"
                              +",[Supervisor_EmpID] ='"+objBasicBo.Employee_Supervisor_Id +"'"
                              +",[Department] = '"+objBasicBo.Employee_Departmnent_Name+"'"
                              +",[Date_of_Birth] ='"+objBasicBo.Employee_Birth_Date+"'"
                              +",[Bank_Account_No] ='"+objadditionalbo.Employee_Bank_Acc_No+"'"
                              +",[Bank_ID] ="+objadditionalbo.Employee_Bank_Id+""
                              +",[Bank_Name] ='"+objadditionalbo.Employee_Bank_Name+"'"
                              +",[Branch_ID] ="+ objadditionalbo.Employee_Branch_Id+""
                              +",[Bank_Branch] ='" +objadditionalbo.Employee_Branch_Name+"'"
                              +",[Bank_Routing_No] ='"+objadditionalbo.Employee_Bank_Route_No+"'"
                              +",[Nationality] ='"+objadditionalbo.Employee_Nationality+"'"
                              +",[National_ID_No] ='"+objadditionalbo.Employee_National_Id_No+"'"
                              +",[TIN] ='"+ objadditionalbo.Employee_Tin+"'"
                              +",[Passport_No] ='"+objadditionalbo.Employee_Passport+"'"
                              +",[Contact_Number] ='"+ objBasicBo.Employee_Contact_Number+"'"
                              +",[Alterate_Contact_Number] ='"+ objBasicBo.Employee_Alter_Contact_Number +"'"
                              +",[Home_Phone] ='"+ objBasicBo.Employee_Home_Phone+"'"
                              +",[Email] ='"+ objBasicBo.Employee_Email+"'"
                              +",[Father_Name] ='"+ objBasicBo.Employee_Father_Name+"'"
                              +",[Mother_Name] ='"+objBasicBo.Employee_Mother_Name+"'"
                              +",[Present_Address] ='"+objadditionalbo.Employee_Present_Address+"'"
                              +",[Permanent_Address] ='"+objadditionalbo.Employee_Permanent_Address+"'"
                              +",[Gender] ='"+objBasicBo.Employee_Gender+"'"
                              +",[Marital_Status] ='"+objBasicBo.Employee_Maritial_Status+"'"
                              +",[Date_Of_Discharge] ='"+ objBasicBo.Employee_Discharge_Date+"'"
                              +",[Employee_Photo]=@image"
                              +",[Update_Date] =Convert(varchar(11),getdate(),106)"
                              +",[Entry_By] =0 WHERE Employee_ID="+id;
            try
            {
                this._dbconnection.ConnectDatabase();
                this._dbconnection.AddParameter("@image", SqlDbType.Image, objadditionalbo.ImgByte);
                this._dbconnection.ExecuteNonQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
/// <summary>
/// //////////////////////////
/// </summary>
/// <param name="id"></param>
/// <returns></returns>


        #endregion

        #region Photo

        public byte[] GetEmployeeImage(string id)
        {
         
            byte[] image=null;
            string query = @"SELECT Emp_ID, Emp_Image  FROM   HR_EmpImageDT Where Emp_ID='" + id + "' ";
            DataTable dt = new DataTable();
            try
            {
                this._dbconnection.Connect_ImageDB();
                dt = this._dbconnection.ExecuteQuery(query);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0][0] !=DBNull.Value)
                    {
                        DataRow row = dt.Rows[0];
                        image = (byte[])row["Emp_Image"];


                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this._dbconnection.CloseDatabase();
            }
            return image;

        }

        #endregion

        #region Delete Employee Info
        public void DeleteEmployeeInfo(int id)
        {
            string query = @"delete from SBP_Employee_Master where Employee_ID ="+id;
            try
            {
                this._dbconnection.ConnectDatabase();
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
