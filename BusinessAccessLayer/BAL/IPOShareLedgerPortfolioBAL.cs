using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using System.Data;

namespace BusinessAccessLayer.BAL
{
    public class IPOShareLedgerPortfolioBAL
    {
        private DbConnection _dbConnection; 
        public IPOShareLedgerPortfolioBAL()
        {
            this._dbConnection = new DbConnection();
        }

        public DataTable GetShareLedegerPortfolio(string _code, DateTime date)
        {
            DataTable dt = new DataTable();
            string query = @"exec [RptIPO_ShareLedger_New] '"+_code+"','"+date.ToShortDateString()+"'";
            try
            {
                this._dbConnection.ConnectDatabase();
                this._dbConnection.ActiveStoredProcedure();
                //this._dbConnection.AddParameter("@Cust_Code", SqlDbType.VarChar, _code);
                //this._dbConnection.AddParameter("@Date", SqlDbType.DateTime, date);
                dt = this._dbConnection.ExecuteProByText(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this._dbConnection.ConnectDatabase();
            }
            return dt;
        }
    }
}
