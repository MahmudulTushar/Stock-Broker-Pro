using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccessLayer;

namespace BusinessAccessLayer.BAL
{
   public class CustomerVerificationInfoBal
    {
       private DbConnection _dbconneciton; 
       public CustomerVerificationInfoBal()
       {
           this._dbconneciton = new DbConnection();
       }
       
       public DataTable Customer_verified(string Id, string Bo_id)
       {
           string query = "";           
           DataTable dt = new DataTable();
           if (Id != "")
           {
               query = @"exec CustomerInfo '"+Id+"','"+Bo_id+"'";
           }
           else
           {
               query = @"exec CustomerInfo '" + Id + "','" + Bo_id + "'";
           }
           try
           {
               this._dbconneciton.ConnectDatabase();
               //this._dbconneciton.ActiveStoredProcedure();
               //this._dbconneciton.AddParameter("@Cust_Code", SqlDbType.VarChar, Id);
               //this._dbconneciton.AddParameter("@Bo_Id", SqlDbType.VarChar, Bo_id);
               dt = this._dbconneciton.ExecuteProByText(query);
           }
           catch (Exception ex)
           {
               throw ex;
           }
           finally
           {
               this._dbconneciton.CloseDatabase();
           }
           return dt;
       }
       public byte[] GetCustomerImagePhoto(string Id, string boid)
       {
           byte[] image = null;
           DataTable dt = new DataTable();
           
           CustomerInfoBAL bal = new CustomerInfoBAL();
           string Cust_Code = Id != string.Empty ? Convert.ToString(bal.GetCustomerCode(boid).Rows[0][0]) : Id;
           string query = "";
           string queryImage = "";
           
           
           if (Id != "")
           {
               query = @" select [Photo]  FROM [SBP_Cust_Image] where [Cust_Code]='" + Id + "'";
               queryImage = @" select [Photo]  FROM [SBP_Cust_Image_ImgExt] where [Cust_Code]='" + Id + "'";
           }
           else
           {
               query = @"select [Photo]  FROM [SBP_Cust_Image] where [Cust_Code]=(select [Cust_Code] from [SBP_Customers] where [BO_ID]='" + boid + "')";
               queryImage = @"select [Photo]  FROM [SBP_Cust_Image_ImgExt] where [Cust_Code]='" + Cust_Code + @"'";
           }

           try
           {
               _dbconneciton.ConnectDatabase_ImageExt();
               dt = _dbconneciton.ExecuteQuery_ImageExt(queryImage);
           }
           catch (Exception ex)
           {
               try
               {
                   _dbconneciton.ConnectDatabase();
                   dt = _dbconneciton.ExecuteQuery(query);
               }
               catch (Exception ext)
               {
                   throw new Exception(ex.Message);
               }
               finally
               {
                   _dbconneciton.CloseDatabase();
               }
           }
           finally
           {
               _dbconneciton.CloseDatabase_ImageExt();
           }

           if (dt.Rows.Count > 0)
           {
               if (dt.Rows[0][0] != DBNull.Value)
               {
                   image = (byte[])dt.Rows[0][0];
               }
           }
           
           return image;
       }
       public byte[] GetCustomerImageSignature(string Id, string boid)
       {
           byte[] image = null;
           DataTable dt = new DataTable();
           CustomerInfoBAL bal = new CustomerInfoBAL();
           string Cust_Code = Id != string.Empty ? Convert.ToString(bal.GetCustomerCode(boid).Rows[0][0]) : Id;
           string queryImage = "";
           string query = "";
           

           if (Id != "")
           {
               query = @" select [Signature] FROM [SBP_Cust_Image] where [Cust_Code]='" + Id + "'";
               queryImage = @" select [Signature]  FROM [SBP_Cust_Image_ImgExt] where [Cust_Code]='" + Id + "'";
           }
           else
           {
               query = @"select [Signature] FROM [SBP_Cust_Image] where [Cust_Code]=(select [Cust_Code] from [SBP_Customers] where [BO_ID]='" + boid + "')";
               queryImage = @"select [Signature]  FROM [SBP_Cust_Image_ImgExt] where [Cust_Code]='" + Cust_Code + @"'";
           }
           try
           {
               _dbconneciton.ConnectDatabase_ImageExt();
               dt = _dbconneciton.ExecuteQuery_ImageExt(queryImage);
           }
           catch (Exception ex)
           {
               try
               {
                   _dbconneciton.ConnectDatabase();
                   dt = _dbconneciton.ExecuteQuery(query);
               }
               catch (Exception ext)
               {
                   throw new Exception(ex.Message);
               }
               finally
               {
                   _dbconneciton.CloseDatabase();
               }
           }
           finally
           {
               _dbconneciton.CloseDatabase_ImageExt();
           }

           if (dt.Rows.Count > 0)
           {
               if (dt.Rows[0][0] != DBNull.Value)
               {
                   image = (byte[])dt.Rows[0][0];
               }
           }

           return image;           
       }
       public byte[] PowerOfAttorneyPic(string id)
       {
           byte[] image = null;
           DataTable dt = new DataTable();
           CustomerInfoBAL bal = new CustomerInfoBAL();
           string Cust_Code = id.Length>7?Convert.ToString(bal.GetCustomerCode(id).Rows[0][0]):id;
           string queryImage = "";
           string query="";
           if (id.Length > 7)
           {
               query = @"select [Photo] from [SBP_POA_Image] where cust_code=(select [Cust_Code] from [SBP_Customers] where [BO_ID]='" + id + "')";
               queryImage = @" select [Photo]  FROM [SBP_POA_Image_ImgExt] where [Cust_Code]='" + Cust_Code + "'";
           }
           else
           {
               query = @"select [Photo] from [SBP_POA_Image] where cust_code='" + Cust_Code + "'";
               queryImage = @" select [Photo]  FROM [SBP_POA_Image_ImgExt] where [Cust_Code]='" + Cust_Code + "'";
                 
           }

           try
           {
               _dbconneciton.ConnectDatabase_ImageExt();
               dt = _dbconneciton.ExecuteQuery_ImageExt(queryImage);
           }
           catch (Exception ex)
           {
               try
               {
                   _dbconneciton.ConnectDatabase();
                   dt = _dbconneciton.ExecuteQuery(query);
               }
               catch (Exception ext)
               {
                   throw new Exception(ex.Message);
               }
               finally
               {
                   _dbconneciton.CloseDatabase();
               }
           }
           finally
           {
               _dbconneciton.CloseDatabase_ImageExt();
           }

           if (dt.Rows.Count > 0)
           {
               if (dt.Rows[0][0] != DBNull.Value)
               {
                   image = (byte[])dt.Rows[0][0];
               }
           }

           return image;    
       }
       public byte[] PowerOfattorneySignature(string id)
       {
           byte[] image = null;
           DataTable dt = new DataTable();
           CustomerInfoBAL bal = new CustomerInfoBAL();
           string Cust_Code = id.Length > 7 ? Convert.ToString(bal.GetCustomerCode(id).Rows[0][0]) : id;
           string queryImage = "";
           string query="";
           if (id.Length > 7)
           {
               query = @"select [Signature] from [SBP_POA_Image] where cust_code=(select [Cust_Code] from [SBP_Customers] where [BO_ID]='" + id + "')";
               queryImage = @" select [Signature]  FROM [SBP_POA_Image_ImgExt] where [Cust_Code]='" + Cust_Code + "'";
           }
           else
           {
               query = @"select [Signature] from [SBP_POA_Image] where cust_code='" + Cust_Code + "'";
               queryImage = @" select [Signature]  FROM [SBP_POA_Image_ImgExt] where [Cust_Code]='" + Cust_Code + "'";
           }
           try
           {
               _dbconneciton.ConnectDatabase_ImageExt();
               dt = _dbconneciton.ExecuteQuery_ImageExt(queryImage);
           }
           catch (Exception ex)
           {
               try
               {
                   _dbconneciton.ConnectDatabase();
                   dt = _dbconneciton.ExecuteQuery(query);
               }
               catch (Exception ext)
               {
                   throw new Exception(ex.Message);
               }
               finally
               {
                   _dbconneciton.CloseDatabase();
               }
           }
           finally
           {
               _dbconneciton.CloseDatabase_ImageExt();
           }

           if (dt.Rows.Count > 0)
           {
               if (dt.Rows[0][0] != DBNull.Value)
               {
                   image = (byte[])dt.Rows[0][0];
               }
           }

           return image;    
       }
       public byte[] NomeneePhoto(string id)
       {
           byte[] image = null;
           DataTable dt = new DataTable();
           CustomerInfoBAL bal = new CustomerInfoBAL();
           string Cust_Code = id.Length > 7 ? Convert.ToString(bal.GetCustomerCode(id).Rows[0][0]) : id;
           string queryImage = "";
           string query = "";
           if (id.Length > 7)
           {
               query = @"select Photo from  [SBP_Nominee1_Image] where [Cust_Code]=(select [Cust_Code] from [SBP_Customers] where [BO_ID]='" + id + "')";
               queryImage = @" select [Photo]  FROM [SBP_Nominee1_Image_ImgExt] where [Cust_Code]='" + Cust_Code + "'";
           }
           else
           {
               query = @"select Photo from  [SBP_Nominee1_Image] where [Cust_Code]='" + Cust_Code + "'";
               queryImage = @" select [Photo]  FROM [SBP_Nominee1_Image_ImgExt] where [Cust_Code]='" + Cust_Code + "'";
           }
           try
           {
               _dbconneciton.ConnectDatabase_ImageExt();
               dt = _dbconneciton.ExecuteQuery_ImageExt(queryImage);
           }
           catch (Exception ex)
           {
               try
               {
                   _dbconneciton.ConnectDatabase();
                   dt = _dbconneciton.ExecuteQuery(query);
               }
               catch (Exception ext)
               {
                   throw new Exception(ex.Message);
               }
               finally
               {
                   _dbconneciton.CloseDatabase();
               }
           }
           finally
           {
               _dbconneciton.CloseDatabase_ImageExt();
           }

           if (dt.Rows.Count > 0)
           {
               if (dt.Rows[0][0] != DBNull.Value)
               {
                   image = (byte[])dt.Rows[0][0];
               }
           }

           return image;    
       }
       public byte[] NomineeSignature(string id)
       {
           byte[] image = null;
           DataTable dt = new DataTable();
           CustomerInfoBAL bal = new CustomerInfoBAL();
           string Cust_Code = id.Length > 7 ? Convert.ToString(bal.GetCustomerCode(id).Rows[0][0]) : id;
           string queryImage = "";
           string query = "";
           if (id.Length > 7)
           {
               query = @" select [Signature] from  [SBP_Nominee1_Image] where [Cust_Code]=(select [Cust_Code] from [SBP_Customers] where [BO_ID]='" + id + "')";
               queryImage = @" select [Signature]  FROM [SBP_Nominee1_Image_ImgExt] where [Cust_Code]='" + Cust_Code + "'";
           }
           else
           {
               query = @" select [Signature] from  [SBP_Nominee1_Image] where [Cust_Code]='" + Cust_Code + "'";
               queryImage = @" select [Signature]  FROM [SBP_Nominee1_Image_ImgExt] where [Cust_Code]='" + Cust_Code + "'";
           }
           try
           {
               _dbconneciton.ConnectDatabase_ImageExt();
               dt = _dbconneciton.ExecuteQuery_ImageExt(queryImage);
           }
           catch (Exception ex)
           {
               try
               {
                   _dbconneciton.ConnectDatabase();
                   dt = _dbconneciton.ExecuteQuery(query);
               }
               catch (Exception ext)
               {
                   throw new Exception(ex.Message);
               }
               finally
               {
                   _dbconneciton.CloseDatabase();
               }
           }
           finally
           {
               _dbconneciton.CloseDatabase_ImageExt();
           }

           if (dt.Rows.Count > 0)
           {
               if (dt.Rows[0][0] != DBNull.Value)
               {
                   image = (byte[])dt.Rows[0][0];
               }
           }

           return image;    
       }
       public byte[] JOintHolderPic(string id)
       {
           byte[] image = null;
           DataTable dt = new DataTable();
           CustomerInfoBAL bal = new CustomerInfoBAL();
           string Cust_Code = id.Length > 7 ? Convert.ToString(bal.GetCustomerCode(id).Rows[0][0]) : id;
           string queryImage = "";
           string query = "";
           if (id.Length > 7)
           {
               query = @"select [Photo] from [SBP_Joint_holder_Image] where cust_code=(select [Cust_Code] from [SBP_Customers] where [BO_ID]='" + id + "')";
               queryImage = @" select [Photo]  FROM [SBP_Joint_holder_Image_ImgExt] where [Cust_Code]='" + Cust_Code + "'";
           }
           else
           {
               query = @"select [Photo] from [SBP_Joint_holder_Image] where cust_code='" + Cust_Code + "'";
               queryImage = @" select [Photo]  FROM [SBP_Joint_holder_Image_ImgExt] where [Cust_Code]='" + Cust_Code + "'";
           }
           try
           {
               _dbconneciton.ConnectDatabase_ImageExt();
               dt = _dbconneciton.ExecuteQuery_ImageExt(queryImage);
           }
           catch (Exception ex)
           {
               try
               {
                   _dbconneciton.ConnectDatabase();
                   dt = _dbconneciton.ExecuteQuery(query);
               }
               catch (Exception ext)
               {
                   throw new Exception(ex.Message);
               }
               finally
               {
                   _dbconneciton.CloseDatabase();
               }
           }
           finally
           {
               _dbconneciton.CloseDatabase_ImageExt();
           }

           if (dt.Rows.Count > 0)
           {
               if (dt.Rows[0][0] != DBNull.Value)
               {
                   image = (byte[])dt.Rows[0][0];
               }
           }

           return image;    
       }
       public byte[] jointholderSignature(string id)
       {
           byte[] image = null;
           DataTable dt = new DataTable();
           CustomerInfoBAL bal = new CustomerInfoBAL();
           string Cust_Code = id.Length > 7 ? Convert.ToString(bal.GetCustomerCode(id).Rows[0][0]) : id;
           string queryImage = "";
           string query = "";
           if (id.Length > 7)
           {
               query = @"select [Signature] from [SBP_Joint_holder_Image] where cust_code=(select [Cust_Code] from [SBP_Customers] where [BO_ID]='" + id + "')";
               queryImage = @" select [Signature]  FROM [SBP_Joint_holder_Image_ImgExt] where [Cust_Code]='" + Cust_Code + "'";
           }
           else
           {
               query = @"select [Signature] from [SBP_Joint_holder_Image] where cust_code='" + Cust_Code + "'";
               queryImage = @" select [Signature]  FROM [SBP_Joint_holder_Image_ImgExt] where [Cust_Code]='" + Cust_Code + "'";
           }

           try
           {
               _dbconneciton.ConnectDatabase_ImageExt();
               dt = _dbconneciton.ExecuteQuery_ImageExt(queryImage);
           }
           catch (Exception ex)
           {
               try
               {
                   _dbconneciton.ConnectDatabase();
                   dt = _dbconneciton.ExecuteQuery(query);
               }
               catch (Exception ext)
               {
                   throw new Exception(ex.Message);
               }
               finally
               {
                   _dbconneciton.CloseDatabase();
               }
           }
           finally
           {
               _dbconneciton.CloseDatabase_ImageExt();
           }

           if (dt.Rows.Count > 0)
           {
               if (dt.Rows[0][0] != DBNull.Value)
               {
                   image = (byte[])dt.Rows[0][0];
               }
           }

           return image;    
       }
    }
}
