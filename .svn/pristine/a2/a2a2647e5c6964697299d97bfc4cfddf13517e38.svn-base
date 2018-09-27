using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using System.Data;

namespace BusinessAccessLayer.BAL
{
   public class EmailSyncBAL
    {

        private string _CustCode;
        private DateTime _Year;

        public DateTime Year
        {
            get { return _Year; }
            set { _Year = value; }
        }

        public string CustCode
        {
            get { return _CustCode; }
            set { _CustCode = value; }
        }

        private Int32 _ID;

        public Int32 ID
        {
            get { return _ID; }
            set { _ID = value; }
        } 

       private DbConnection _dbConnection;

       public EmailSyncBAL()
        {
            _dbConnection = new DbConnection();
        }



       public DataTable LoadTax_Certification()
       {
           DataTable dtable;
           dtable = null;

           string qury;
           qury = "";

           qury = @"Select ID
                           ,RegCustCode AS 'Register Cust Code'
                           ,Customer_Name
                           ,Cust_Code
                           ,Year
                           ,ReceiveID
                           ,Sending_EmailAddress AS 'Email Address'
                           ,Media 
                           from dbo.tbl_Report_Sending_Email_SMS
                           Where Status=0 AND SMSType='Tax Certificate'";

           try
           {
               _dbConnection.ConnectDatabase_SMSSender();
               dtable = _dbConnection.ExecuteQuery_SMSSender(qury);
           }
           catch (Exception)
           {
               throw;
           }
           finally
           {
               _dbConnection.CloseDatabase();
           }

           return dtable;
       }



       public void UPDATE_TAXCertification(Int32 ID , string Status)
       {
           string query = @"UPDATE tbl_Report_Sending_Email_SMS SET
                                                      Status='" +Status+ @"'
                                                      Where ID='"+ID+"'";
           try
           {
               _dbConnection.ConnectDatabase_SMSSender();
               _dbConnection.ExecuteNonQuery_SMSSender(query);
               _dbConnection.CloseDatabase_SMSSender();
           }
           catch (Exception ex)
           {
               throw ex;
           }
           finally
           {
               _dbConnection.CloseDatabase();
           }
       }
    }
}
