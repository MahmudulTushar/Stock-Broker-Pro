using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DataAccessLayer;

namespace BusinessAccessLayer.BAL
{
    public class SearchCustBAL
    {
         private DbConnection _dbConnection;
         public SearchCustBAL()
        {
            _dbConnection = new DbConnection();
        }

        public DataTable SearchCustomer(string criteriaString)
        {
            DataTable dataTable;
            dataTable = null;
            string queryString = "";
            queryString = "SELECT SBP_Customers.Cust_Code as 'Customer Code',Cust_Name as 'Customer Name',Father_Name as 'Father_Name',Address1 as 'Address',Mobile,BO_ID as 'BO ID',BO_Open_Date as 'BO Open Date',Bank_Name as 'Bank Name',Account_No as 'Account No' FROM SBP_Customers left outer join SBP_Cust_Bank_Info ON SBP_Customers.Cust_Code=SBP_Cust_Bank_Info.Cust_Code left outer join SBP_Cust_Contact_Info ON SBP_Customers.Cust_Code= SBP_Cust_Contact_Info.Cust_Code left outer join SBP_Cust_Personal_Info ON SBP_Customers.Cust_Code= SBP_Cust_Personal_Info.Cust_Code"+
                " WHERE 0=0 "+criteriaString+"";
            try
            {
                _dbConnection.ConnectDatabase();
                dataTable = _dbConnection.ExecuteQuery(queryString);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dataTable;
            
        }
    }
}
