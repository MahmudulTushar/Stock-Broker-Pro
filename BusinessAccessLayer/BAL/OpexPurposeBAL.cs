using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using System.Data;

namespace BusinessAccessLayer.BAL
{
   public class OpexPurposeBAL
   {
       private DbConnection _dbConnection;

       public OpexPurposeBAL()
       {
           _dbConnection=new DbConnection();
       }

       public void InsertOpexPurpose(int CategoryId,string PurposeName)
       {
           string queryString = "INSERT INTO dbo.SBP_Opex_Purpose( Category_ID, Purpose_Name) VALUES (" + CategoryId +
                                ",'" + PurposeName + "')";

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

       public DataTable GetDeletablePurposeList()
       {
           string queryString = "SELECT Purpose_ID,Purpose_Name AS 'Purpose Name',(SELECT dbo.SBP_Expense_Purpose.Purpose_Name FROM dbo.SBP_Expense_Purpose WHERE dbo.SBP_Expense_Purpose.Purpose_Id=dbo.SBP_Opex_Purpose.Category_ID) AS Category,(SELECT Purpose_Type FROM dbo.SBP_Expense_Purpose WHERE dbo.SBP_Expense_Purpose.Purpose_Id=dbo.SBP_Opex_Purpose.Category_ID) AS Type FROM dbo.SBP_Opex_Purpose WHERE dbo.SBP_Opex_Purpose.Purpose_Name NOT IN (SELECT dbo.SBP_OPEX.Purpose FROM dbo.SBP_OPEX)";
           DataTable data=new DataTable();
           try
           {
               _dbConnection.ConnectDatabase();
               data = _dbConnection.ExecuteQuery(queryString);
           }
           catch (Exception)
           {
               
               throw;
           }

           finally
           {
               _dbConnection.CloseDatabase();
           }

           return data;
       }


       public DataTable GetPurposeList(int categoryID)
       {
           string queryString = "SELECT Purpose_ID,Purpose_Name FROM dbo.SBP_Opex_Purpose WHERE Category_ID=" + categoryID + " ORDER BY Purpose_ID DESC";
           DataTable data = new DataTable();
           try
           {
               _dbConnection.ConnectDatabase();
               data = _dbConnection.ExecuteQuery(queryString);
           }
           catch (Exception)
           {

               throw;
           }

           finally
           {
               _dbConnection.CloseDatabase();
           }

           return data;
       }

       public void  DeletePurposeInformation(int PurposeID)
       {
           string queryString = "DELETE SBP_Opex_Purpose WHERE Purpose_ID=" + PurposeID + "";

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

   }
}
