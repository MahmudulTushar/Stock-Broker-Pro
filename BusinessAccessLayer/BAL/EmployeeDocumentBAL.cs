using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccessLayer;
using BusinessAccessLayer.BO;

namespace BusinessAccessLayer.BAL
{
   public class EmployeeDocumentBAL
   {

       #region dbconnection
       private DbConnection _dbconnection;
       #endregion

       #region Constructor

       public EmployeeDocumentBAL()
       {
           this._dbconnection = new DbConnection();
       }

       #endregion

       #region Grid Data

       public DataTable GetGridData()
       {
           DataTable dt = new DataTable();
           string query = @" select (Title+First_Name+Last_Name) as Employee_Name
                             ,SBP_Employee_Documents.Employee_ID
                             ,Document_Type
                             ,Document_Name
                             --,Document_Scan
                             from dbo.SBP_Employee_Documents
                             join dbo.SBP_Employee_Master
                             on dbo.SBP_Employee_Documents.Employee_ID=dbo.SBP_Employee_Master.Employee_ID
                             order by SBP_Employee_Documents.Employee_ID";
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

       #region Get Employee Id
       public DataTable GetEmployeeID()
       {
           DataTable dt = new DataTable();
           string query = @"select Employee_ID  , (Title+First_Name+Last_Name) as First_Name from SBP_Employee_Master order by Employee_ID desc";
           try
           {
               this._dbconnection.ConnectDatabase();
               dt=this._dbconnection.ExecuteQuery(query);
           }
           catch (Exception ex)
           {
               throw ex;
           }
           return dt;
       }


       public DataTable GetEmp_Doc_Duplicate(string EmpID)
       {
           DataTable dt = new DataTable();
           string query = @"SELECT Employee_ID
                                FROM SBP_Employee_Documents
                                         WHERE  (Employee_ID = '" + EmpID + "')";
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

       #region Save Data

       public void SaveEmpDocumentInfo(EmployeeDocumentBo bo)
       {
           string query = @"INSERT INTO [HR_Emp_DocFile]
                           (
                            [Emp_ID]                           
                           ,[Emp_NID_Photo]
                           ,Emp_CV_PDF                                                     
                           )
                     VALUES ('" + bo.Employee_Document_ID+ @"' 
                             ,  @NationalID
                             ,  @CVPDF 
                             )";
           try
           {
            
             _dbconnection.Connect_ImageDB();
             _dbconnection.AddParameter("@NationalID", SqlDbType.Binary, bo.National_Id_imag);
            _dbconnection.AddParameter("@CVPDF", SqlDbType.Binary, bo.CV_PDF);          
               this._dbconnection.ExecuteNonQuery(query);


                query = @"INSERT INTO [SBP_Employee_Documents]
                           (
                            [Employee_ID]
                           ,[Document_Type]
                           ,[Document_Name]                        
                           )
                     VALUES ('" + bo.Employee_Document_ID + @"' ,
                              '" + bo.Employee_Document_Type + @"',
                              '" + bo.Employee_Document_Name + @"'                            
                             )";

                _dbconnection.ConnectDatabase(); 
               this._dbconnection.ExecuteNonQuery(query);

           }
           catch (Exception ex)
           {
               throw ex;
           }
         
       }



//       public void SaveEmpDocumentInfo(EmployeeDocumentBo bo)
//       {
//           string query = @"INSERT INTO [SBP_Employee_Documents]
//                           ([Employee_ID]
//                           ,[Document_Type]
//                           ,[Document_Name]
//                           ,National_Id_imag                                                     
//                           ,CV_image)
//                     VALUES ('" + bo.Employee_Document_ID + @"' ,
//                              '" + bo.Employee_Document_Type + @"',
//                              '" + bo.Employee_Document_Name + @"',
//                               @NationalID,                            
//                               @CVPDF 
//                             )";
//           try
//           {
//               // _dbconnection.ConnectDatabase();

//               _dbconnection.Connect_ImageDB();

//               _dbconnection.AddParameter("@NationalID", SqlDbType.Binary, bo.National_Id_imag);
//               _dbconnection.AddParameter("@CVPDF", SqlDbType.Binary, bo.CV_PDF);

//               // _dbconnection.AddParameter("@image", bo.Employee_Document_Image);
//               // _dbconnection.AddParameter("@imageNationalID", System .Convert .ToByte ,bo.Employee_NationalID_Image);
//               this._dbconnection.ExecuteNonQuery(query);

//           }
//           catch (Exception ex)
//           {
//               throw ex;
//           }

//       }


       #endregion

       #region Update Document Info
       public void UpdateDocumentInfo(EmployeeDocumentBo bo, int id)
       {
           string query = @"UPDATE [SBP_Employee_Documents]
                               SET
                                     [Document_Type] ='" + bo.Employee_Document_Type + @"'
                                      ,[Document_Name] ='" + bo.Employee_Document_Name + @"'
                                      ,[Update_Date] =convert(varchar(11),getdate(),106)
                                       ,[Entry_By] = 0
                              WHERE [Employee_ID]='"+id+@"'   
                            ";
           try
           {
               this._dbconnection.ConnectDatabase();
              /// this._dbconnection.AddParameter("@image", SqlDbType.Image, bo.National_Id_imag);
              this._dbconnection.ExecuteNonQuery(query);

                  _dbconnection.Connect_ImageDB();
                 //query = "DELETE  FROM  HR_Emp_DocFile  WHERE  [Emp_ID]  ='" + bo.Employee_Document_ID + "' ";
                 // this._dbconnection.ExecuteNonQuery(query);

              query = @"UPDATE [HR_Emp_DocFile] Set[Emp_NID_Photo]=@NationalID , [Emp_CV_PDF]=@CVPDF  Where  [Emp_ID]  ='" + bo.Employee_Document_ID + "' ";
              
              _dbconnection.AddParameter("@NationalID", SqlDbType.Binary, bo.National_Id_imag);
              _dbconnection.AddParameter("@CVPDF", SqlDbType.Binary, bo.CV_PDF);

              this._dbconnection.ExecuteNonQuery(query);

              _dbconnection.ConnectDatabase();

           }
           catch (Exception ex)
           {
               throw ex;
           }


       }
       #endregion

       #region Image
       public byte[] GetEmployeeDocumentImage(string id)
       {
           byte[] image = null;
           string query = @"SELECT Emp_NID_Photo FROM HR_Emp_DocFile WHERE  (Emp_ID = '" + id + "')";
           DataTable dt = new DataTable();
           try
           {
               _dbconnection.Connect_ImageDB();
             
               dt = this._dbconnection.ExecuteQuery(query);
               if (dt.Rows.Count > 0)
               {
                   if (dt.Rows[0][0] != DBNull.Value)
                   {
                       image = (byte[])dt.Rows[0][0];
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




   }

}
