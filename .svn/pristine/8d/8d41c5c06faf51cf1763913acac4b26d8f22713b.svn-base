using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DataAccessLayer;

namespace BusinessAccessLayer.BAL
{
    public class ShareLimitBAL
    {
        private DbConnection _dbConnection;

        public ShareLimitBAL()
        {
            _dbConnection = new DbConnection();
        }
        public DataTable GetShareLimitData()
        {

            DataTable dataTable;
            //string queryString = "SELECT (SELECT ISIN_No FROM SBP_Company WHERE SBP_Company.Comp_Short_Code=SBP_Share_Balance_Temp.Comp_Short_Code),Comp_Short_Code, (SELECT (SELECT TOP 1 BO_ID FROM SBP_Broker_Info)+BO_ID FROM SBP_Customers WHERE SBP_Customers.Cust_Code=SBP_Share_Balance_Temp.Cust_Code),(SELECT Cust_Name FROM SBP_Cust_Personal_Info WHERE SBP_Cust_Personal_Info.Cust_Code=SBP_Share_Balance_Temp.Cust_Code),SUM(Balance),CASE WHEN(SUM(Matured_Balance)>0) THEN SUM(Matured_Balance) ELSE 0 END,Cust_Code,replace(convert(varchar(11), getdate(), 113),' ','-') FROM SBP_Share_Balance_Temp GROUP BY Comp_Short_Code,Cust_Code HAVING SUM(Balance)>0 ORDER BY Comp_Short_Code ASC";
            string queryString = @"GenerateShareLimit";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                dataTable = _dbConnection.ExecuteProQuery(queryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dataTable;

        }
    }
}
