using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using System.Data;
using BusinessAccessLayer.Constants;

namespace BusinessAccessLayer.BAL
{
    public class paymentOCCPaurpose
    {
        private DbConnection _dbConnection;

        public paymentOCCPaurpose()
        {
            _dbConnection = new DbConnection();
        }

        public void AddOccPaymentPurpose(string OccName, float amount)
        {
            string queryString = "INSERT INTO SBP_Payment_OCC_Purpose(OCC_Purpose,Amount) VALUES ('" + OccName + "'," + amount + ")";

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

        public DataTable GetOCCPurposeList(string callFrom)
        {
            string queryString = string.Empty;
            if (callFrom == Indication_Forms_Title.NewCustomerOpen)
            {
                queryString = "SELECT OCC_ID,OCC_Purpose FROM SBP_Payment_OCC_Purpose WHERE OCC_ID =2";
            }
            else
            {
                queryString = "SELECT OCC_ID,OCC_Purpose FROM SBP_Payment_OCC_Purpose WHERE OCC_ID NOT IN (2,4,9) ORDER BY OCC_ID DESC";
            }
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

        public float GetOOCPurpose(int OCCPurposeID)
        {
            string queryString = "SELECT ISNULL(Amount,0) AS 'Amount' FROM SBP_Payment_OCC_Purpose WHERE OCC_ID=" + OCCPurposeID + "";
            DataTable data = new DataTable();
            float amount = 0;

            try
            {
                _dbConnection.ConnectDatabase();
                data = _dbConnection.ExecuteQuery(queryString);
                amount = float.Parse(data.Rows[0]["Amount"].ToString());
            }

            catch (Exception)
            {
                throw;
            }

            finally
            {
                _dbConnection.CloseDatabase();
            }

            return amount;

        }

        public int GetPaymentOccPurpose()
        {
            string queryString = "SELECT COUNT(*) FROM SBP_Payment_OCC_Purpose";
            DataTable data = new DataTable();
            int totalPaymwentOcc = 0;

            try
            {
                _dbConnection.ConnectDatabase();
                data = _dbConnection.ExecuteQuery(queryString);
                totalPaymwentOcc = Int32.Parse(data.Rows[0][0].ToString());
            }

            catch (Exception)
            {
                throw;
            }

            finally
            {
                _dbConnection.CloseDatabase();
            }

            return totalPaymwentOcc;
        }

        public DataTable GetDeletablePurpose()
        {
            string queryString =
                "SELECT OCC_ID,OCC_Purpose AS 'Purpose',Amount FROM dbo.SBP_Payment_OCC_Purpose WHERE OCC_ID NOT IN (SELECT dbo.SBP_Payment_OOC.OCC_ID FROM dbo.SBP_Payment_OOC)";
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

        public void DeletePurpose(int OOCID)
        {
            string queryString = "DELETE FROM dbo.SBP_Payment_OCC_Purpose WHERE OCC_ID=" + OOCID + "";

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
