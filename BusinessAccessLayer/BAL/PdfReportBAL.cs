using System;
using System.Data;
using BusinessAccessLayer.BO;
using DataAccessLayer;


namespace BusinessAccessLayer.BAL
{
    public class PdfReportBAL
    {
        private DbConnection _dbConnection;

        public PdfReportBAL()
        {
            _dbConnection = new DbConnection();
        }


        public void InsertData(PdfReportBO testClassBo)
        {

            string queryString = "";

            CommonBAL oCommonBal = new CommonBAL();


            testClassBo.RelationshipID = oCommonBal.GenerateID("SBP_Relationship", "Relationship_ID");

            queryString = "INSERT INTO SBP_Relationship (Relationship_ID,Relation)" +
               " Values(" + testClassBo.RelationshipID + ",'" + testClassBo.Relationship + "')";


            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();
                _dbConnection.ExecuteNonQuery(queryString);
                _dbConnection.Commit();
            }
            catch (Exception)
            {
                _dbConnection.Rollback();
                throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
        }


        #region "Select"

        public DataTable GetImage(PdfReportBO pdfReportBo)
        {

            string queryString = "";
            DataTable dataTable = new DataTable();


            //   queryString = "SELECT Image FROM Images  WHERE Cust_Code=" + pdfReportBo.CustomerCode;

            queryString = @" SELECT SBP_Cust_Image.Photo as 'Cust_Photo'
                                   ,SBP_Cust_Image.Signature as 'Cust_Signature'
                                   ,SBP_Nominee1_Image.Photo as 'Nominee1_Photo'
                                   ,SBP_Nominee1_Image.Signature as 'Nominee1_Signature'
                                   ,SBP_Joint_holder_Image.Photo as 'Joint_Acc_Holdr_Photo'
                                   ,SBP_Joint_holder_Image.Signature as 'Joint_Acc_Holdr_Signature'
                                   , SBP_Author_Image.Photo as 'Authorized_Person_Photo'
                                   ,SBP_Author_Image.Signature as 'Authorized_Person_Signature'
                                   ,SBP_Nominee2_Image.Photo as 'Nominee2_Photo'
                                   ,SBP_Nominee2_Image.Signature as 'Nominee2_Signature'
                                   , SBP_Guardian1_Image.Photo as 'Gurdian1_Photo'
                                   ,SBP_Guardian1_Image.Signature as 'Gurdian1_Signature'
                                   ,SBP_Guardian2_Image.Photo as 'Gurdian2_Photo'
                                   ,SBP_Guardian2_Image.Signature as 'Gurdian2_Signature'
                                   ,SBP_POA_Image.Photo as 'POA_Photo'
                                   ,SBP_POA_Image.Signature as 'POA_Signature'
                                   ,SBP_Broker_Info.Directors_Signature AS 'Director_Signature'
                                   ,SBP_Broker_Info.Default_Signature AS 'Default_Signature' 
                            FROM dbo.SBP_Cust_Image_ImgExt as SBP_Cust_Image
	                             LEFT OUTER JOIN dbo.SBP_Nominee1_Image_ImgExt as SBP_Nominee1_Image
		                            ON SBP_Cust_Image.Cust_Code=SBP_Nominee1_Image.Cust_Code 
	                             LEFT OUTER JOIN dbo.SBP_Joint_holder_Image_ImgExt as SBP_Joint_holder_Image
		                            ON SBP_Cust_Image.Cust_Code=SBP_Joint_holder_Image.Cust_Code
	                             LEFT OUTER JOIN dbo.SBP_Nominee2_Image_ImgExt as SBP_Nominee2_Image
		                            ON SBP_Cust_Image.Cust_Code=SBP_Nominee2_Image.Cust_Code 
	                             LEFT OUTER JOIN dbo.SBP_Guardian1_Image_ImgExt as SBP_Guardian1_Image
		                            ON SBP_Cust_Image.Cust_Code=SBP_Guardian1_Image.Cust_Code 
	                             LEFT OUTER JOIN dbo.SBP_Guardian2_Image_ImgExt as SBP_Guardian2_Image
		                            ON SBP_Cust_Image.Cust_Code=SBP_Guardian2_Image.Cust_Code 
	                             LEFT OUTER JOIN dbo.SBP_Author_Image_ImgExt as SBP_Author_Image
		                            ON SBP_Cust_Image.Cust_Code=SBP_Author_Image.Cust_Code 
	                             LEFT OUTER JOIN  dbo.SBP_POA_Image_ImgExt as SBP_POA_Image
		                            ON SBP_Cust_Image.Cust_Code=SBP_POA_Image.Cust_Code,SBP_Database.dbo.SBP_Broker_Info as SBP_Broker_Info
                            WHERE SBP_Cust_Image.Cust_Code='" + pdfReportBo.CustomerCode + "'";
                

            //Previous Code
                //" SELECT SBP_Cust_Image.Photo as 'Cust_Photo',SBP_Cust_Image.Signature as 'Cust_Signature',SBP_Nominee1_Image.Photo as 'Nominee_Photo',SBP_Nominee1_Image.Signature as 'Nominee_Signature',SBP_Joint_holder_Image.Photo as 'Joint_Acc_Holdr_Photo',SBP_Joint_holder_Image.Signature as 'Joint_Acc_Holdr_Signature',"
                //          + " SBP_Author_Image.Photo as 'Authorized_Person_Photo',SBP_Author_Image.Signature as 'Authorized_Person_Signature',"
                //          + "SBP_Nominee2_Image.Photo as 'Nominee2_Photo',SBP_Nominee2_Image.Signature as 'Nominee2_Signature',"
                //          + " SBP_Guardian1_Image.Photo as 'Gurdian1_Photo',SBP_Guardian1_Image.Signature as 'Gurdian1_Signature',"
                //          + "SBP_Guardian2_Image.Photo as 'Gurdian2_Photo',SBP_Guardian2_Image.Signature as 'Gurdian2_Signature',"
                //          + "SBP_POA_Image.Photo as 'POA_Photo',SBP_POA_Image.Signature as 'POA_Signature',"
                //          +"SBP_Broker_Info.Directors_Signature AS 'Director_Signature',"
                //          +"SBP_Broker_Info.Default_Signature AS 'Default_Signature'"
                //          + " FROM SBP_Cust_Image LEFT OUTER JOIN SBP_Nominee1_Image ON SBP_Cust_Image.Cust_Code=SBP_Nominee1_Image.Cust_Code LEFT OUTER JOIN SBP_Joint_holder_Image ON SBP_Cust_Image.Cust_Code=SBP_Joint_holder_Image.Cust_Code LEFT OUTER JOIN SBP_Nominee2_Image ON SBP_Cust_Image.Cust_Code=SBP_Nominee2_Image.Cust_Code LEFT OUTER JOIN SBP_Guardian1_Image ON SBP_Cust_Image.Cust_Code=SBP_Guardian1_Image.Cust_Code LEFT OUTER JOIN SBP_Guardian2_Image ON SBP_Cust_Image.Cust_Code=SBP_Guardian2_Image.Cust_Code LEFT OUTER JOIN SBP_Author_Image ON SBP_Cust_Image.Cust_Code=SBP_Author_Image.Cust_Code LEFT OUTER JOIN SBP_POA_Image ON SBP_Cust_Image.Cust_Code=SBP_POA_Image.Cust_Code,SBP_Broker_Info"
                //          + "  WHERE SBP_Cust_Image.Cust_Code='" + pdfReportBo.CustomerCode+"'";

            try
            {
                _dbConnection.ConnectDatabase_ImageExt();
               
                dataTable = _dbConnection.ExecuteQuery_ImageExt(queryString);

                return dataTable;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public DataTable GetCustomerPersonalInfo(PdfReportBO pdfReportBo)
        {

            string queryString = "";
            DataTable dataTable = new DataTable();


            queryString = "SELECT Cust_Name,Father_Name,Mother_Name,DOB,Gender,National_ID,SBP_Customers.BO_ID,Special_Remarks,BO_Type,BO_Status,BO_Category,BO_Open_Date,Occupation,Cust_Open_Date, CDBL_Participant_ID,SBP_Broker_Info.BO_ID"
                + " FROM SBP_Broker_Info,SBP_Customers LEFT OUTER JOIN SBP_Cust_Personal_Info  ON SBP_Cust_Personal_Info.Cust_Code=SBP_Customers.Cust_Code LEFT OUTER JOIN SBP_BO_Type ON SBP_BO_Type.BO_Type_ID=SBP_Customers.BO_Type_ID LEFT OUTER JOIN SBP_BO_Status ON SBP_BO_Status.BO_Status_ID=SBP_Customers.BO_Status_ID LEFT OUTER JOIN SBP_BO_Category ON SBP_BO_Category.BO_Category_ID=SBP_Customers.BO_Category_ID "
                + "WHERE SBP_Customers.Cust_Code='" + pdfReportBo.CustomerCode+"'";
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

        public DataTable GetCustomerAdditionalInfo(PdfReportBO pdfReportBo)
        {

            string queryString = "";
            DataTable dataTable = new DataTable();


            queryString = "SELECT Nationality,Address1,Address2,Address3,City_Name,Division_Name,Country_Name,Phone,Mobile,Email,Passport_No,Issue_Place,Expire_Date,Bank_Name,Branch_Name,Account_No,Is_EDC,Is_Tax_Exemption,TIN,Post_Code,Fax,Comp_Reg_No,Issue_Date,Recidency,Statement_Cycle,Internal_Ref_No,Comp_Reg_Date,Acc_Link_Request,Acc_Link_BO_ID,Standing_Ins"
                          + " FROM SBP_Cust_Additional_Info LEFT OUTER JOIN SBP_Cust_Passport_Info ON SBP_Cust_Passport_Info.Cust_Code=SBP_Cust_Additional_Info.Cust_Code LEFT OUTER JOIN SBP_Cust_Contact_Info ON SBP_Cust_Contact_Info.Cust_Code=SBP_Cust_Additional_Info.Cust_Code LEFT OUTER JOIN SBP_Cust_Bank_Info ON  SBP_Cust_Bank_Info.Cust_Code=SBP_Cust_Additional_Info.Cust_Code LEFT OUTER JOIN SBP_Statement_Cycle ON SBP_Statement_Cycle.Statement_Cycle_ID=SBP_Cust_Additional_Info.Statement_Cycle_ID"
                          + " WHERE SBP_Cust_Additional_Info.Cust_Code= '" + pdfReportBo.CustomerCode+"'";

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


        public DataTable GetAuthorizedPerson(PdfReportBO pdfReportBo)
        {

            string queryString = "";
            DataTable dataTable = new DataTable();


            queryString = "SELECT Name,Relationship,DOB,National_ID,Percentage,Is_Officer_Director_SE,SE_Name_Address,Author_Name,Author_Address,Author_Mobile,Intro_Name,Intro_Address,Joint_Name,Joint_Father_Name,Joint_Mother_Name,Joint_DOB,Joint_Gender,Joint_Nationality,Joint_Address,Joint_National_ID,Joint_Phone,Joint_Mobile,Joint_Email,Remarks,SBP_Intro_Author.Intro_BO_ID,Operation_Ins" +
                " FROM SBP_Customers LEFT OUTER JOIN SBP_Nominee1 ON SBP_Customers.Cust_Code=SBP_Nominee1.Cust_Code LEFT OUTER JOIN SBP_Intro_Author ON SBP_Customers.Cust_Code=SBP_Intro_Author.Cust_Code LEFT OUTER JOIN SBP_Joint_holder ON SBP_Customers.Cust_Code=SBP_Joint_holder.Cust_Code" +
                " WHERE SBP_Customers.Cust_Code ='" + pdfReportBo.CustomerCode+"'";
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

        public DataTable GetOtherInfo(PdfReportBO pdfReportBo)
        {

            string queryString = "";
            DataTable dataTable = new DataTable();

            queryString = "SELECT SBP_Broker_Info.Name,SBP_Broker_Info.Exchange_Name,SBP_Broker_Info.Trade_ID FROM SBP_Broker_Info";

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



        public DataTable GetServiceInfo(PdfReportBO pdfReportBo)
        {

            string queryString = "";
            DataTable dataTable = new DataTable();

            queryString = "select a.Web_Service,a.SMS_Trade,a.SMS_Confirmation,b.Routing_No from SBP_Service_Registration a join SBP_Cust_Bank_Info b on a.Cust_Code=b.Cust_Code where a.Cust_Code='" + pdfReportBo.CustomerCode + "'";

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


        public DataTable GetCustomerName(PdfReportBO pdfReportBo)
        {
            string queryString = "";
            DataTable dataTable = new DataTable();
            queryString = "select Cust_Name from SBP_Cust_Personal_Info where Cust_Code='" + pdfReportBo.CustomerCode + "'";
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


        public DataTable GetNomineeGurdian(PdfReportBO pdfReportBo)
        {

            string queryString = "";
            DataTable dataTable = new DataTable();

            queryString = "SELECT SBP_Nominee1.Address,SBP_Nominee1.City,SBP_Nominee1.Division,SBP_Nominee1.Post_Code,SBP_Nominee1.Country,SBP_Nominee1.Phone,SBP_Nominee1.Mobile,SBP_Nominee1.Fax,SBP_Nominee1.Email,SBP_Nominee1.DOB,SBP_Nominee1.Nationality,SBP_Nominee1.Residency,"
                              + " SBP_Nominee1.Passport_No,SBP_Nominee1.Issue_Date,SBP_Nominee1.Expire_Date,SBP_Nominee1.Issue_Place,"
                              + " SBP_Nominee2.Name,SBP_Nominee2.Relationship,SBP_Nominee2.Percentage,SBP_Nominee2.Address,SBP_Nominee2.City,SBP_Nominee2.Division,SBP_Nominee2.Post_Code,SBP_Nominee2.Country,SBP_Nominee2.Phone,SBP_Nominee2.Mobile,SBP_Nominee2.Fax,SBP_Nominee2.Email,SBP_Nominee2.DOB,SBP_Nominee2.Nationality,SBP_Nominee2.Residency,"
                              + " SBP_Nominee2.Passport_No,SBP_Nominee2.Issue_Date,SBP_Nominee2.Expire_Date,SBP_Nominee2.Issue_Place,"
                              + " SBP_Guardian1.Name,SBP_Guardian1.Address,SBP_Guardian1.City,SBP_Guardian1.Division,SBP_Guardian1.Country,SBP_Guardian1.Post_Code,SBP_Guardian1.Phone,SBP_Guardian1.Mobile,SBP_Guardian1.Fax,SBP_Guardian1.Email,SBP_Guardian1.DOB,SBP_Guardian1.Nationality,SBP_Guardian1.Residency,SBP_Guardian1.Passport_No,SBP_Guardian1.Issue_Date,SBP_Guardian1.Expire_Date,SBP_Guardian1.Issue_Place,SBP_Guardian1.Relationship,SBP_Guardian1.Minor_Date,SBP_Guardian1.Maturity_Date,"
                              + " SBP_Guardian2.Name,SBP_Guardian2.Address,SBP_Guardian2.City,SBP_Guardian2.Division,SBP_Guardian2.Country,SBP_Guardian2.Post_Code,SBP_Guardian2.Phone,SBP_Guardian2.Mobile,SBP_Guardian2.Fax,SBP_Guardian2.Email,SBP_Guardian2.DOB,SBP_Guardian2.Nationality,SBP_Guardian2.Residency,SBP_Guardian2.Passport_No,SBP_Guardian2.Issue_Date,SBP_Guardian2.Expire_Date,SBP_Guardian2.Issue_Place,SBP_Guardian2.Relationship,SBP_Guardian2.Minor_Date,SBP_Guardian2.Maturity_Date"

                              + " FROM SBP_Nominee1 LEFT OUTER JOIN SBP_Nominee2 ON SBP_Nominee1.Cust_Code=SBP_Nominee2.Cust_Code LEFT OUTER JOIN SBP_Guardian1 ON SBP_Guardian1.Cust_Code=SBP_Nominee1.Cust_Code LEFT OUTER JOIN SBP_Guardian2 ON SBP_Guardian2.Cust_Code=SBP_Nominee1.Cust_Code"
                              + " WHERE SBP_Nominee1.Cust_Code='" + pdfReportBo.CustomerCode+"'";

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

        public DataTable GetPowerOfAttorney(PdfReportBO pdfReportBo)
        {

            string queryString = "";
            DataTable dataTable = new DataTable();

            queryString = "SELECT Name,Address,City,Division,Country,Post_Code,Phone,Mobile,Fax,Email,Passport_No,Issue_Date,"
                          + "Expire_Date,Issue_Place,Nationality,Residency,DOB,Effective_From,Effective_To,Remarks"
                          + " FROM SBP_POA"
                          + " WHERE SBP_POA.Cust_Code='" + pdfReportBo.CustomerCode+"'";


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
    }
}
