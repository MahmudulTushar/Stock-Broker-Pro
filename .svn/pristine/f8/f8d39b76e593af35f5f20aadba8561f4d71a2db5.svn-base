using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using System.Data;
using BusinessAccessLayer.BO;
namespace BusinessAccessLayer.BAL
{
    public class SearchForm
    {
        DbConnection _dbConnection;

        public SearchForm()
        {
            _dbConnection = new DbConnection();
        }

        public DataTable dtLoadForm(string Cust_code, string imgPurpose)
        {
            DataTable dtForm;
            dtForm = null;

            string queryExt;
            string query;

            //query = "Select SBP_Others_Upload.Image,SBP_Customers.BO_ID from SBP_Others_Upload,SBP_Customers where SBP_Others_Upload.Cust_Code='" + Cust_code + "' and SBP_Others_Upload.Purpose='" + imgPurpose + "' and SBP_Others_Upload.Cust_Code=SBP_Customers.Cust_Code ;";
            queryExt =
                @"Select  TOP 1
                    (
                     CASE 
                     WHEN SBP_Others_Upload.Image IS NULL
                     THEN ext.Image
                     ELSE SBP_Others_Upload.Image
                     END
                     ) AS 'Image'
                    ,SBP_Customers.BO_ID 

                    from SBP_Others_Upload,SBP_Customers,[SBP_Database_ImageExt].[dbo].[SBP_Others_Upload_ImgExt] AS ext 
                    where SBP_Others_Upload.Cust_Code=ext.Cust_Code 
                    --AND SBP_Others_Upload.Purpose=ext.Purpose
                    and ext.Purpose='" +
                imgPurpose + "'"
                + " and SBP_Others_Upload.Cust_Code=SBP_Customers.Cust_Code "
                + " AND SBP_Others_Upload.Cust_Code='" + Cust_code + "'";
            query =
                @"Select 
                    
                     SBP_Others_Upload.Image
                    ,SBP_Customers.BO_ID 

                    from SBP_Others_Upload,SBP_Customers
                    where SBP_Others_Upload.Cust_Code=SBP_Customers.Cust_Code
                    and SBP_Others_Upload.Purpose='" +
                imgPurpose + "'"
                + " AND SBP_Others_Upload.Cust_Code='" + Cust_code + "'";
            try
            {
                _dbConnection.ConnectDatabase();
                dtForm = _dbConnection.ExecuteQuery(queryExt);
            }
            catch (Exception)
            {
                try
                {
                    _dbConnection.ConnectDatabase();
                    dtForm = _dbConnection.ExecuteQuery(query);
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
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dtForm;
        }
    }
}
