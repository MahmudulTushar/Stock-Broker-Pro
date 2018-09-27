using System;
using System.Data;
using System.Windows.Forms;
using BusinessAccessLayer.Constants;
using DataAccessLayer;
using BusinessAccessLayer.BO;
using System.Linq;

namespace BusinessAccessLayer.BAL
{
    public class CommonBAL
    {
        private DbConnection _dbConnection;

        public CommonBAL()
        {
            _dbConnection = new DbConnection();
        }
        public string HandlingSingelQuation(string Value)
        {
            if (Value != null)
            {
                if (Value.Contains("'"))
                {
                    Value = Value.Replace("'", "''");
                }
            }
            return Value;
        }

        public long GenerateID(string tableName, string columnName)
        {
            long value = 1;
            DataTable dataTable;
            string queryString = "SELECT MAX(" + columnName + ") FROM " + tableName;

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

            if (dataTable.Rows[0][0] != DBNull.Value)
                value = Convert.ToInt64(dataTable.Rows[0][0].ToString()) + 1;

            return value;
        }

        public int GetMaxID(string tableName, string columnName)
        {
            int value = 1;
            DataTable dataTable;
            string queryString = "SELECT MAX(" + columnName + ") FROM " + tableName;

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

            if (dataTable.Rows[0][0] != DBNull.Value)
                value = Convert.ToInt32(dataTable.Rows[0][0].ToString());

            return value;
        }

        public int GenerateID_ImgExt(string columnName)
        {
            int value = 1;
            DataTable dataTable;
            string queryString = string.Empty;
            string tableName = string.Empty;
            string tableName_ImgExt = string.Empty;

            tableName = Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_Others_Upload").SingleOrDefault().Key;
            tableName_ImgExt = Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_Others_Upload").SingleOrDefault().Value;

            try
            {
                queryString = "SELECT MAX(" + columnName + ") FROM " + tableName_ImgExt;
                _dbConnection.ConnectDatabase_ImageExt();
                dataTable = _dbConnection.ExecuteQuery_ImageExt(queryString);
                if (dataTable.Rows[0][0] != DBNull.Value)
                    value = Convert.ToInt32(dataTable.Rows[0][0].ToString()) + 1;

            }
            catch (Exception ex)
            {
                try
                {

                    _dbConnection.ConnectDatabase();
                    queryString = "SELECT MAX(" + columnName + ") FROM " + tableName;
                    _dbConnection.ConnectDatabase();

                    dataTable = _dbConnection.ExecuteQuery(queryString);
                    if (dataTable.Rows[0][0] != DBNull.Value)
                        value = Convert.ToInt32(dataTable.Rows[0][0].ToString()) + 1;

                }
                catch (Exception ey)
                {
                    throw new Exception(ey.Message);
                }
                finally
                {
                    _dbConnection.CloseDatabase();
                }


            }
            finally
            {
                try
                {
                    _dbConnection.CloseDatabase_ImageExt();
                }
                catch
                {

                }
            }


            return value;
        }

        public bool Check_ImageDatabase_ExistOrNot(string databaseName)
        {
            bool exist = false;
            DataTable dataTable;
            const string queryString = @"USE master
                                   SELECT name, DB_ID(name) AS DB_ID
                                   FROM sysdatabases
                                   ORDER BY dbid";

            try
            {
                _dbConnection.ConnectDatabase();
                dataTable = _dbConnection.ExecuteQuery(queryString);
                if (dataTable.Rows.Count > 0)
                {
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        if (dataTable.Rows[i]["name"].ToString() == databaseName)
                        {
                            exist = true;
                            break;
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }

            return exist;
        }
        public void NumberValidate(string text, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
                return;
            double res;
            if (!double.TryParse(text + e.KeyChar.ToString(), out res))
            {
                e.Handled = true;
            }

        }
        public int GetIdByName(string nameValue, string idColumn, string nameColumn, string tableName)
        {
            string queryString = "SELECT " + idColumn + " FROM " + tableName + " WHERE " + nameColumn + "='" + nameValue +
                                 "';";

            DataTable dataTable;

            try
            {
                _dbConnection.ConnectDatabase();
                dataTable = _dbConnection.ExecuteQuery(queryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }

            if (dataTable.Rows.Count > 0)
            {
                return Convert.ToInt16(dataTable.Rows[0][0].ToString());
            }
            else
            {
                return 0;
            }
        }
        public bool IsUpload(DateTime tradeDate, string fileName)
        {
            DataTable dataTable;
            string queryString = "SELECT Upload_Date From SBP_Upload_History WHERE File_Name='" + fileName + "' AND Upload_Date='" + tradeDate + "'";
            try
            {
                _dbConnection.ConnectDatabase();
                dataTable = _dbConnection.ExecuteQuery(queryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            if (dataTable.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DataTable LoadImagePurpose(string CustCode)
        {
            DataTable dtable;
            dtable = null;

            string qury;
            qury = "";

            qury = "Select Purpose from SBP_Others_Upload Where Cust_Code='" + CustCode + "' group by Purpose;";

            try
            {
                _dbConnection.ConnectDatabase();
                dtable = _dbConnection.ExecuteQuery(qury);
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

        public DataTable LoadImagePurpose_ImgExt(string CustCode)
        {
            DataTable dtable;
            dtable = null;
            string tableNaem = string.Empty;
            string qury;
            qury = "";
            tableNaem =
                Indication_Fixed_DatabaseName.TableName_ImageExt.Where(s => s.Key == "SBP_Others_Upload").
                    SingleOrDefault().Value;
            qury = "Select Purpose from " + tableNaem + " Where Cust_Code='" + CustCode + "' group by Purpose;";

            try
            {
                _dbConnection.ConnectDatabase_ImageExt();
                dtable = _dbConnection.ExecuteQuery_ImageExt(qury);
            }
            catch (Exception)
            {
                try
                {
                    _dbConnection.ConnectDatabase();
                    dtable = _dbConnection.ExecuteQuery(qury);
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
                _dbConnection.CloseDatabase_ImageExt();
            }

            return dtable;

        }

        public DateTime GetCurrentServerDate()
        {
            DateTime result = new DateTime();
            result = GetCurrentServerDate_FromDB();
            /*
             * Updated by Shahrior
             * On 25 January 2015
             */
            //if (result != GlobalVariableBO._currentServerDate)
            //    result = GlobalVariableBO._currentServerDate;
            return result;
        }

        public DateTime GetCurrentServerDate_FromDB()
        {
            DateTime result = new DateTime();
            DataTable dt = new DataTable();
            string quryString = "Select GETDATE()";
            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(quryString);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                        result = Convert.ToDateTime(dt.Rows[0][0]);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }

            return result;
        }
        
        public DateTime GetCompanyStartDate()
        {
            DateTime result = new DateTime();
            result = Convert.ToDateTime("01-08-2004");
            return result;
        }

        public double GetCurrentAvailAbleBalanceForWithdraw(string Cust_Code )
        {
            DataTable dt = new DataTable();
            double result = 0.00;
            double AccrudBalance = 0.00;

            string boStatus = string.Empty;
            string qryStr =
                        @"Select 
                        ISNULL(
                        (
                        Select 
                        t.BO_Status
                        From dbo.SBP_BO_Status as t
                        Where t.BO_Status_ID=cust.BO_Status_ID
                        ),'') as status
                        From SBP_Customers as cust
                        Where cust.Cust_Code='" + Cust_Code + @"'";
            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(qryStr);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            if (dt.Rows.Count > 0)
                boStatus = dt.Rows[0][0].ToString();

            PaymentInfoBAL bal = new PaymentInfoBAL();
            result = bal.GetCurrentBalane(Cust_Code);

            AccrudBalance = Convert.ToDouble(bal.GetCurrentBalaneforAccrued(Cust_Code).ToString("N"));

            if (boStatus == Constants.Indication_AccBOStatus.Active && result > Constants.Validation.Payment_MinimumBalanceHave_InWithdraw_ForActive)
            {
                result = (result - Constants.Validation.Payment_MinimumBalanceHave_InWithdraw_ForActive) - AccrudBalance;
            }
            else if (boStatus == Constants.Indication_AccBOStatus.Active && result <= Constants.Validation.Payment_MinimumBalanceHave_InWithdraw_ForActive)
            {
                result = 0.00;
            }
            else if (boStatus == Constants.Indication_AccBOStatus.Closed && result > Constants.Validation.Payment_MinimumBalanceHave_InWithdraw_ForColsed)
            {
                result = (result - Constants.Validation.Payment_MinimumBalanceHave_InWithdraw_ForColsed) - AccrudBalance;
            }
            else if (boStatus == Constants.Indication_AccBOStatus.Closed && result < Constants.Validation.Payment_MinimumBalanceHave_InWithdraw_ForColsed)
            {
                result = 0.00;
            }

            return result;
        }

        public string GetSBPTempFileLocation()
        { 
            return  "\\\\150.1.122.30\\Sbp_TempDirectory";
        }

        public DataTable GetAllCompanyName()
        {
            DataTable dt = new DataTable();
            string query = @"select Distinct(Comp_Name) as 'Company_Name' from SBP_Company order by Comp_Name asc";
            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dt;
        }
        public DataTable GetAllCompanyName(string ISIN_NO)
        {
            DataTable dt = new DataTable();
            string query = @"select ISIN_No,Comp_Name,Comp_Short_Code
                                from SBP_Company where ISIN_No='" + ISIN_NO + @"'";
            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dt;
        }
        public string GetCompanyCategory(string cat)
        {
            string ctg = string.Empty;
            DataTable dt = new DataTable();
            string query = @"SELECT Comp_Category 
                                FROM SBP_Comp_Category AS T
                                WHERE T.Comp_Cat_ID = (
						                                SELECT Comp_Cat_ID FROM SBP_Company AS C
						                                WHERE C.Comp_Short_Code='" + cat + @"'
                                                       )";
            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(query);

                return ctg = dt.Rows[0][0].ToString();
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
