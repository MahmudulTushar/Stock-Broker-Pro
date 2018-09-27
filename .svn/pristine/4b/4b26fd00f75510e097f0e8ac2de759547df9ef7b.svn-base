using System;
using System.Data;
using BusinessAccessLayer.BO;
using DataAccessLayer;

namespace BusinessAccessLayer.BAL
{
    public class AdditionalInformationBAL
    {
        private DbConnection _dbConnection;

        public AdditionalInformationBAL()
        {
            _dbConnection = new DbConnection();
        }
        #region "Insert"
        public void InsertBoCatagory(AdditionalInformationBO additionalInformationBo)
        {
            string queryString = "";
            CommonBAL oCommonBal = new CommonBAL();
            additionalInformationBo.BOCatagoryID = oCommonBal.GenerateID("SBP_BO_Category", "BO_Category_ID");
            queryString = @"SBPSaveBOCategory";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@BOCatagoryID", SqlDbType.Int,additionalInformationBo.BOCatagoryID );
                _dbConnection.AddParameter("@BOCatagory", SqlDbType.VarChar,additionalInformationBo.BOCatagory);
                _dbConnection.ExecuteNonQuery(queryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
        }
        public void InsertCustomerGroup(AdditionalInformationBO additionalInformationBo)
        {
            string queryString = "";
            CommonBAL oCommonBal = new CommonBAL();
            additionalInformationBo.CustomerGroupID = oCommonBal.GenerateID("SBP_Cust_Group", "Cust_Group_ID");
            queryString = @"SBPSaveCustomerGroup"; 
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@CustomerGroupID", SqlDbType.Int, additionalInformationBo.CustomerGroupID);
                _dbConnection.AddParameter("@CustomerGroup", SqlDbType.VarChar, additionalInformationBo.CustomerGroup);
                _dbConnection.AddParameter("@CustomerGroupDescription", SqlDbType.VarChar, additionalInformationBo.CustomerGroupDescription);
                _dbConnection.ExecuteNonQuery(queryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
        }


        //public void InsertOrderChannel(AdditionalInformationBO additionalInformationBo)
        //{

        //    string queryString = "";

        //    CommonBAL oCommonBal = new CommonBAL();


        //    additionalInformationBo.OrderChannelID = oCommonBal.GenerateID("SBP_Order_Channel", "Order_Channel_ID");

        //    queryString = "INSERT INTO SBP_Order_Channel (Order_Channel_ID,Order_Channel,Status)" +
        //        " Values('" + additionalInformationBo.OrderChannelID + "','" + additionalInformationBo.OrderChannel + "','" + additionalInformationBo.OrderChannelStatus + "')";


        //    try
        //    {
        //        _dbConnection.ConnectDatabase();
        //        _dbConnection.StartTransaction();
        //        _dbConnection.ExecuteNonQuery(queryString);
        //        _dbConnection.Commit();
        //    }
        //    catch (Exception)
        //    {
        //        _dbConnection.Rollback();
        //        throw;
        //    }
        //    finally
        //    {
        //        _dbConnection.CloseDatabase();
        //    }
        //}

        public void InsertCompanyCategory(AdditionalInformationBO additionalInformationBo)
        {

            string queryString = "";
            CommonBAL oCommonBal = new CommonBAL();
            additionalInformationBo.CompanyCategoryID = oCommonBal.GenerateID("SBP_Comp_Category", "Comp_Cat_ID");
            queryString = @"SBPSaveCompanyCategory";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@CompanyCategoryID", SqlDbType.Int, additionalInformationBo.CompanyCategoryID);
                _dbConnection.AddParameter("@CompanyCategory", SqlDbType.NVarChar, additionalInformationBo.CompanyCategory);
                _dbConnection.AddParameter("@CompanyCategoryMinDate", SqlDbType.Int, additionalInformationBo.CompanyCategoryMinDate);
                _dbConnection.ExecuteNonQuery(queryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
        }



        public void InsertStatementCycle(AdditionalInformationBO additionalInformationBo)
        {

            string queryString = "";
            CommonBAL oCommonBal = new CommonBAL();
            additionalInformationBo.StatementCycleID = oCommonBal.GenerateID("SBP_Statement_Cycle", "Statement_Cycle_ID");
            queryString = @"SBPSaveStatementCycle";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@StatementCycleID", SqlDbType.Int, additionalInformationBo.StatementCycleID);
                _dbConnection.AddParameter("@StatementCycle", SqlDbType.VarChar, additionalInformationBo.StatementCycle);
                _dbConnection.ExecuteNonQuery(queryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }

        }


        //public void InsertReferenceType(AdditionalInformationBO additionalInformationBo)
        //{

        //    string queryString = "";

        //    CommonBAL oCommonBal = new CommonBAL();


        //    additionalInformationBo.ReferenceTypeID = oCommonBal.GenerateID("SBP_Reference_Type", "Ref_Type_ID");

        //    queryString = "INSERT INTO SBP_Reference_Type (Ref_Type_ID,Reference)" +
        //        " Values('" + additionalInformationBo.ReferenceTypeID + "','" + additionalInformationBo.ReferenceType + "')";


        //    try
        //    {
        //        _dbConnection.ConnectDatabase();
        //        _dbConnection.StartTransaction();
        //        _dbConnection.ExecuteNonQuery(queryString);
        //        _dbConnection.Commit();
        //    }
        //    catch (Exception)
        //    {
        //        _dbConnection.Rollback();
        //        throw;
        //    }
        //    finally
        //    {
        //        _dbConnection.CloseDatabase();
        //    }
        //}


        //public void InsertPaymentMedia(AdditionalInformationBO additionalInformationBo)
        //{

        //    string queryString = "";

        //    CommonBAL oCommonBal = new CommonBAL();


        //    additionalInformationBo.PaymentMediaID = oCommonBal.GenerateID("SBP_Payment_Media", "Payment_Media_ID");

        //    queryString = "INSERT INTO SBP_Payment_Media (Payment_Media_ID,Payment_Media)" +
        //        " Values('" + additionalInformationBo.PaymentMediaID + "','" + additionalInformationBo.PaymentMedia + "')";


        //    try
        //    {
        //        _dbConnection.ConnectDatabase();
        //        _dbConnection.StartTransaction();
        //        _dbConnection.ExecuteNonQuery(queryString);
        //        _dbConnection.Commit();
        //    }
        //    catch (Exception)
        //    {
        //        _dbConnection.Rollback();
        //        throw;
        //    }
        //    finally
        //    {
        //        _dbConnection.CloseDatabase();
        //    }
        //}
        #endregion

        #region "Select"

        public DataTable GetBOCategory()
        {

            string queryString = "";
            DataTable dataTable = new DataTable();

            queryString = "SELECT BO_Category_ID as 'BO Category ID',BO_Category as 'BO Category' FROM SBP_BO_Category";


            try
            {
                _dbConnection.ConnectDatabase();
                //_dbConnection.StartTransaction();
                dataTable = _dbConnection.ExecuteQuery(queryString);
                //_dbConnection.Commit();

                return dataTable;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public DataTable GetBOCategoryCrys()
        {

            string queryString = "";
            DataTable dataTable = new DataTable();

            queryString = "SELECT BO_Category_ID ,BO_Category FROM SBP_BO_Category";


            try
            {
                _dbConnection.ConnectDatabase();
                //_dbConnection.StartTransaction();
                dataTable = _dbConnection.ExecuteQuery(queryString);
                //_dbConnection.Commit();

                return dataTable;
            }
            catch (Exception)
            {

                throw;
            }

        }

     
        public DataTable GetCustomerGroup()
        {

            string queryString = "";
            DataTable dataTable = new DataTable();

            queryString = "SELECT Cust_Group_ID as 'Customer Group ID',Cust_Group as 'Customer Group',Description as 'Description' FROM SBP_Cust_Group";


            try
            {
                _dbConnection.ConnectDatabase();
                dataTable = _dbConnection.ExecuteQuery(queryString);
                return dataTable;
            }
            catch (Exception)
            {

                throw;
            }

        }



        //public DataTable GetReferenceType()
        //{

        //    string queryString = "";
        //    DataTable dataTable = new DataTable();

        //    queryString = "SELECT Ref_Type_ID as 'Reference Type ID',Reference as 'Reference' FROM SBP_Reference_Type";


        //    try
        //    {
        //        _dbConnection.ConnectDatabase();
        //        dataTable = _dbConnection.ExecuteQuery(queryString);
        //        return dataTable;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //}


        public DataTable GetPaymentMedia()
        {

            string queryString = "";
            DataTable dataTable = new DataTable();

            queryString = "SELECT Payment_Media_ID as 'Payment Media ID',Payment_Media as 'Payment Media' FROM SBP_Payment_Media";


            try
            {
                _dbConnection.ConnectDatabase();
                dataTable = _dbConnection.ExecuteQuery(queryString);
                return dataTable;
            }
            catch (Exception)
            {

                throw;
            }

        }

       


        public DataTable GetStatementCycle()
        {

            string queryString = "";
            DataTable dataTable = new DataTable();

            queryString = "SELECT Statement_Cycle_ID as 'Statement Cycle ID',Statement_Cycle as 'Statement Cycle' FROM SBP_Statement_Cycle";


            try
            {
                _dbConnection.ConnectDatabase();
                dataTable = _dbConnection.ExecuteQuery(queryString);
                return dataTable;
            }
            catch (Exception)
            {

                throw;
            }

        }



        public DataTable GetCompanyCategory()
        {

            string queryString = "";
            DataTable dataTable = new DataTable();

            queryString = "SELECT Comp_Cat_ID as 'Company Category ID',Comp_Category as 'Company Category',Min_Date as 'Minimum Date' FROM SBP_Comp_Category";


            try
            {
                _dbConnection.ConnectDatabase();
                dataTable = _dbConnection.ExecuteQuery(queryString);
                return dataTable;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public DataTable GetOrderChannel()
        {

            string queryString = "";
            DataTable dataTable = new DataTable();

            queryString = "SELECT Order_Channel_ID as 'Order Channel ID',Order_Channel as 'Order Channel',Status as 'Status' FROM SBP_Order_Channel";


            try
            {
                _dbConnection.ConnectDatabase();
                dataTable = _dbConnection.ExecuteQuery(queryString);
                return dataTable;
            }
            catch (Exception)
            {

                throw;
            }

        }

        #endregion


        #region "Update"

        public void UpdateBOCategory(AdditionalInformationBO additionalInformationBo)
        {
            string queryString = "";
            queryString = @"SBPUpdateBOCategory";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@BOCatagoryID", SqlDbType.Int, additionalInformationBo.BOCatagoryID);
                _dbConnection.AddParameter("@BOCatagory", SqlDbType.VarChar, additionalInformationBo.BOCatagory);
                _dbConnection.ExecuteNonQuery(queryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
        }

    


        public void UpdateCustomerGroup(AdditionalInformationBO additionalInformationBo)
        {
            string queryString = "";


            queryString = @"SBPUpdateCustomerGroup";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@CustomerGroupID", SqlDbType.Int, additionalInformationBo.CustomerGroupID);
                _dbConnection.AddParameter("@CustomerGroup", SqlDbType.VarChar, additionalInformationBo.CustomerGroup);
                _dbConnection.AddParameter("@CustomerGroupDescription", SqlDbType.VarChar, additionalInformationBo.CustomerGroupDescription);
                _dbConnection.ExecuteNonQuery(queryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
        }


        //public void UpdateReferenceType(AdditionalInformationBO additionalInformationBo)
        //{
        //    string queryString = "";


        //    queryString = "UPDATE SBP_Reference_Type SET Reference='" + additionalInformationBo.ReferenceType + "' WHERE Ref_Type_ID=" + additionalInformationBo.ReferenceTypeID;

        //    try
        //    {
        //        _dbConnection.ConnectDatabase();
        //        _dbConnection.StartTransaction();
        //        _dbConnection.ExecuteNonQuery(queryString);
        //        _dbConnection.Commit();
        //    }
        //    catch (Exception)
        //    {
        //        _dbConnection.Rollback();
        //        throw;
        //    }
        //    finally
        //    {
        //        _dbConnection.CloseDatabase();
        //    }

        //}

        //public void UpdatePaymentMedia(AdditionalInformationBO additionalInformationBo)
        //{
        //    string queryString = "";


        //    queryString = "UPDATE SBP_Payment_Media SET Payment_Media='" + additionalInformationBo.PaymentMedia + "' WHERE Payment_Media_ID=" + additionalInformationBo.PaymentMediaID;

        //    try
        //    {
        //        _dbConnection.ConnectDatabase();
        //        _dbConnection.StartTransaction();
        //        _dbConnection.ExecuteNonQuery(queryString);
        //        _dbConnection.Commit();
        //    }
        //    catch (Exception)
        //    {
        //        _dbConnection.Rollback();
        //        throw;
        //    }
        //    finally
        //    {
        //        _dbConnection.CloseDatabase();
        //    }

        //}

        public void UpdateStatementCycle(AdditionalInformationBO additionalInformationBo)
        {
            string queryString = "";
            queryString = @"SBPUpdateStatementCycle";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@StatementCycleID", SqlDbType.Int, additionalInformationBo.StatementCycleID);
                _dbConnection.AddParameter("@StatementCycle", SqlDbType.VarChar, additionalInformationBo.StatementCycle);
                _dbConnection.ExecuteNonQuery(queryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
        }


        public void UpdateCompanyCategory(AdditionalInformationBO additionalInformationBo)
        {
            string queryString = "";

            queryString = @"SBPUpdateCompanyCategory";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@CompanyCategoryID", SqlDbType.Int, additionalInformationBo.CompanyCategoryID);
                _dbConnection.AddParameter("@CompanyCategory", SqlDbType.NVarChar, additionalInformationBo.CompanyCategory);
                _dbConnection.AddParameter("@CompanyCategoryMinDate", SqlDbType.Int, additionalInformationBo.CompanyCategoryMinDate);
                _dbConnection.ExecuteNonQuery(queryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }

        }
        //public void UpdateOrderChannel(AdditionalInformationBO additionalInformationBo)
        //{
        //    string queryString = "";


        //    queryString = "UPDATE SBP_Order_Channel SET Order_Channel='" + additionalInformationBo.OrderChannel + "',Status=" + additionalInformationBo.OrderChannelStatus + " WHERE Order_Channel_ID=" + additionalInformationBo.OrderChannelID;

        //    try
        //    {
        //        _dbConnection.ConnectDatabase();
        //        _dbConnection.StartTransaction();
        //        _dbConnection.ExecuteNonQuery(queryString);
        //        _dbConnection.Commit();
        //    }
        //    catch (Exception)
        //    {
        //        _dbConnection.Rollback();
        //        throw;
        //    }
        //    finally
        //    {
        //        _dbConnection.CloseDatabase();
        //    }

        //}

        #endregion
    }
}
