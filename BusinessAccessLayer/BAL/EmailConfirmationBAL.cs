using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccessLayer;
using BusinessAccessLayer.BO;

namespace BusinessAccessLayer.BAL
{
   public class EmailConfirmationBAL
    {
       private DbConnection _dbConnection;

       public EmailConfirmationBAL()
       {
           _dbConnection = new DbConnection();
       }

       public DataTable GetEmailConfirmation()
       {
           string queryString = "SELECT [To],[From],Subject,Body FROM SBP_EmailConfirmation";
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

       public void UpdateEmailConfirmation(EmailConfirmationBO objEmailConfirmationBO)
       {
           string queryString = "UPDATE SBP_EmailConfirmation SET [To]='" + objEmailConfirmationBO.To + "',[From]='" + objEmailConfirmationBO.Form + "',Subject='" + objEmailConfirmationBO.Subject + "',Body='" + objEmailConfirmationBO.Body + "'";

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
