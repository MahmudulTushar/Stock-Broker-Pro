using System;
using System.Linq;
using BusinessAccessLayer.BO;
using BusinessAccessLayer.Constants;
using DataAccessLayer;
using System.Data.SqlClient;
using System.Data;

namespace BusinessAccessLayer.BAL
{
    public class SaveImgBAL
    {
        CommonBAL cmbBAL = new CommonBAL();
        private DbConnection _dbConnection;
        public SaveImgBAL()
        {
            _dbConnection = new DbConnection();
        }


        //        public void InsertCustImg(SaveImgBO imgBO,string ImgsavePattern)
        //        {
        //           //string qry = "";
        //           //string qry_ImgExt = "";

        //           //string cheeckQuery = "";
        //           // string tableName = string.Empty;
        //           // string tableName_ImgExt = string.Empty;
        //           //DataTable dataTable=new DataTable();
        //           //byte[]imgByte=new  byte[0];


        //           //if (ImgsavePattern == "1st Acc")
        //           //{
        //           // //   tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_Cust_Image");


        //           //    if (dataTable.Rows.Count > 0)
        //           //    {
        //           //        qry = "UPDATE " + tableName + " SET Photo=@ImageData,Update_Date=@Update_Date where Cust_Code='" +
        //           //              imgBO.CustomerCode + "';";
        //           //    }

        //           //    else
        //           //    {
        //           //        qry = "insert into " + tableName + " ([Cust_Code],[Photo],Update_Date) values(@OriginalPath,@ImageData,@Update_Date)";
        //           //    }


        //           //    SqlParm(qry, imgBO);
        //           //}


        //           //else if (ImgsavePattern == "2nd Acc")
        //           //{
        //           //    tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_Joint_holder_Image");
        //           //    cheeckQuery = "Select Cust_Code from " + tableName + " where Cust_Code='" + imgBO.CustomerCode + "';";
        //           //    dataTable = dtImageSave(cheeckQuery);

        //           //    if (dataTable.Rows.Count > 0)
        //           //    {
        //           //        qry = "UPDATE " + tableName + " SET Photo=@ImageData,Update_Date=@Update_Date where Cust_Code='" + imgBO.CustomerCode + "';";  
        //           //    }

        //           //    else
        //           //    {
        //           //        qry = "insert into " + tableName + " ([Cust_Code],[Photo],Update_Date) values(@OriginalPath,@ImageData,@Update_Date)";
        //           //    }

        //           //    SqlParm(qry,imgBO);

        //           //}


        //           //else if (ImgsavePattern == "1st Noim")
        //           //    {
        //           //        tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_Nominee1_Image");
        //           //        cheeckQuery = "Select Cust_Code from " + tableName + " where Cust_Code='" + imgBO.CustomerCode + "';";
        //           //        dataTable = dtImageSave(cheeckQuery);


        //           //    if (dataTable.Rows.Count > 0)
        //           //    {
        //           //        qry = "UPDATE " + tableName + " SET Photo=@ImageData,Update_Date=@Update_Date where Cust_Code='" + imgBO.CustomerCode + "';";

        //           //    }

        //           //    else
        //           //    {
        //           //        qry = "insert into " + tableName + " ([Cust_Code],[Photo],Update_Date) values(@OriginalPath,@ImageData,@Update_Date)";
        //           //    }


        //           //    SqlParm(qry, imgBO);


        //           //}

        //           //else if (ImgsavePattern == "2nd Noim")
        //           //{
        //           //    tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_Nominee2_Image");
        //           //    cheeckQuery = "Select Cust_Code from " + tableName + "  where Cust_Code='" + imgBO.CustomerCode + "';";
        //           //    dataTable = dtImageSave(cheeckQuery);

        //           //    if (dataTable.Rows.Count > 0)
        //           //    {
        //           //        qry = "UPDATE " + tableName + "  SET Photo=@ImageData,Update_Date=@Update_Date where Cust_Code='" + imgBO.CustomerCode + "';";

        //           //    }

        //           //    else
        //           //    {
        //           //        qry = "insert into " + tableName + " ([Cust_Code],[Photo],Update_Date) values(@OriginalPath,@ImageData,@Update_Date)";
        //           //    }

        //           //    SqlParm(qry,imgBO);
        //           //}


        //           //else if (ImgsavePattern == "1st Gurd")
        //           //{
        //           //    tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_Guardian1_Image");
        //           //    cheeckQuery = "Select Cust_Code from " + tableName + " where Cust_Code='" + imgBO.CustomerCode + "';";
        //           //    dataTable = dtImageSave(cheeckQuery);


        //           //    if (dataTable.Rows.Count > 0)
        //           //    {
        //           //        qry = "UPDATE " + tableName + "  SET Photo=@ImageData,Update_Date=@Update_Date where Cust_Code='" + imgBO.CustomerCode + "';";

        //           //    }

        //           //    else
        //           //    {
        //           //        qry = "insert into " + tableName + " ([Cust_Code],[Photo],Update_Date) values(@OriginalPath,@ImageData,@Update_Date)";
        //           //    }

        //           //    SqlParm(qry, imgBO);



        //           //}

        //           //else if (ImgsavePattern == "2nd Gurd")
        //           //{
        //           //    tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_Guardian2_Image");
        //           //    cheeckQuery = "Select Cust_Code from " + tableName + " where Cust_Code='" + imgBO.CustomerCode + "';";
        //           //    dataTable = dtImageSave(cheeckQuery);


        //           //    if (dataTable.Rows.Count > 0)
        //           //    {
        //           //        qry = "UPDATE " + tableName + " SET Photo=@ImageData,Update_Date=@Update_Date where Cust_Code='" + imgBO.CustomerCode + "';";

        //           //    }

        //           //    else
        //           //    {
        //           //        qry = "insert into " + tableName + " ([Cust_Code],[Photo],Update_Date) values(@OriginalPath,@ImageData,@Update_Date)";
        //           //    }



        //           //    SqlParm(qry,imgBO);



        //           //}

        //           //else if (ImgsavePattern == "POA")
        //           //{
        //           //    tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_POA_Image");
        //           //    cheeckQuery = "Select Cust_Code from " + tableName + " where Cust_Code='" + imgBO.CustomerCode + "';";
        //           //    dataTable = dtImageSave(cheeckQuery);

        //           //    if (dataTable.Rows.Count > 0)
        //           //    {
        //           //        qry = "UPDATE " + tableName + "SET Photo=@ImageData,Update_Date=@Update_Date where Cust_Code='" + imgBO.CustomerCode + "';"; 
        //           //    }

        //           //    else
        //           //    {
        //           //        qry = "insert into " + tableName + " ([Cust_Code],[Photo],Update_Date) values(@OriginalPath,@ImageData,@Update_Date)";
        //           //    }


        //           //    SqlParm(qry,imgBO);



        //           //}

        //           //else if (ImgsavePattern == "Author")
        //           //{
        //           //    tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_Author_Image");
        //           //    cheeckQuery = "Select Cust_Code from " + tableName + " where Cust_Code='" + imgBO.CustomerCode + "';";
        //           //    dataTable = dtImageSave(cheeckQuery);

        //           //    if (dataTable.Rows.Count > 0)
        //           //    {
        //           //        qry = "UPDATE " + tableName + "SET Photo=@ImageData,Update_Date=@Update_Date where Cust_Code='" + imgBO.CustomerCode + "';";
        //           //    }

        //           //    else
        //           //    {
        //           //        qry = "insert into " + tableName + " ([Cust_Code],[Photo],Update_Date) values(@OriginalPath,@ImageData,@Update_Date)";
        //           //    }


        //           //    SqlParm(qry, imgBO);

        //           //}



        //        }

        //        public void InsertCustImg_ImgExt(SaveImgBO imgBO, string ImgsavePattern)
        //        {
        //            string qry = "";
        //            string qry_ImgExt = "";

        //            string cheeckQuery = "";
        //            string tableName = string.Empty;
        //            string tableName_ImgExt = string.Empty;
        //            DataTable dataTable = new DataTable();
        //            byte[] imgByte = new byte[0];


        //            if (ImgsavePattern == "1st Acc")
        //            {
        //                //   tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_Cust_Image");
        //                tableName =
        //                    Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_Cust_Image").
        //                        SingleOrDefault().Key;
        //                tableName_ImgExt =
        //                    Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_Cust_Image").
        //                        SingleOrDefault().Value;

        //                cheeckQuery = "Select Cust_Code from " + tableName + " where Cust_Code='" + imgBO.CustomerCode + "';";
        //                dataTable = dtImageSave(cheeckQuery);


        //                if (dataTable.Rows.Count > 0)
        //                {
        //                    qry = "UPDATE " + tableName + " SET Photo=@ImageData,Update_Date=@Update_Date where Cust_Code='" +
        //                          imgBO.CustomerCode + "';";
        //                }

        //                else
        //                {
        //                    qry = "insert into " + tableName + " ([Cust_Code],[Photo],Update_Date) values(@OriginalPath,@ImageData,@Update_Date)";
        //                }


        //                SqlParm(qry, imgBO);
        //            }


        //            else if (ImgsavePattern == "2nd Acc")
        //            {
        //                tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_Joint_holder_Image");
        //                cheeckQuery = "Select Cust_Code from " + tableName + " where Cust_Code='" + imgBO.CustomerCode + "';";
        //                dataTable = dtImageSave(cheeckQuery);

        //                if (dataTable.Rows.Count > 0)
        //                {
        //                    qry = "UPDATE " + tableName + " SET Photo=@ImageData,Update_Date=@Update_Date where Cust_Code='" + imgBO.CustomerCode + "';";
        //                }

        //                else
        //                {
        //                    qry = "insert into " + tableName + " ([Cust_Code],[Photo],Update_Date) values(@OriginalPath,@ImageData,@Update_Date)";
        //                }

        //                SqlParm(qry, imgBO);

        //            }


        //            else if (ImgsavePattern == "1st Noim")
        //            {
        //                tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_Nominee1_Image");
        //                cheeckQuery = "Select Cust_Code from " + tableName + " where Cust_Code='" + imgBO.CustomerCode + "';";
        //                dataTable = dtImageSave(cheeckQuery);


        //                if (dataTable.Rows.Count > 0)
        //                {
        //                    qry = "UPDATE " + tableName + " SET Photo=@ImageData,Update_Date=@Update_Date where Cust_Code='" + imgBO.CustomerCode + "';";

        //                }

        //                else
        //                {
        //                    qry = "insert into " + tableName + " ([Cust_Code],[Photo],Update_Date) values(@OriginalPath,@ImageData,@Update_Date)";
        //                }


        //                SqlParm(qry, imgBO);


        //            }

        //            else if (ImgsavePattern == "2nd Noim")
        //            {
        //                tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_Nominee2_Image");
        //                cheeckQuery = "Select Cust_Code from " + tableName + "  where Cust_Code='" + imgBO.CustomerCode + "';";
        //                dataTable = dtImageSave(cheeckQuery);

        //                if (dataTable.Rows.Count > 0)
        //                {
        //                    qry = "UPDATE " + tableName + "  SET Photo=@ImageData,Update_Date=@Update_Date where Cust_Code='" + imgBO.CustomerCode + "';";

        //                }

        //                else
        //                {
        //                    qry = "insert into " + tableName + " ([Cust_Code],[Photo],Update_Date) values(@OriginalPath,@ImageData,@Update_Date)";
        //                }

        //                SqlParm(qry, imgBO);
        //            }


        //            else if (ImgsavePattern == "1st Gurd")
        //            {
        //                tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_Guardian1_Image");
        //                cheeckQuery = "Select Cust_Code from " + tableName + " where Cust_Code='" + imgBO.CustomerCode + "';";
        //                dataTable = dtImageSave(cheeckQuery);


        //                if (dataTable.Rows.Count > 0)
        //                {
        //                    qry = "UPDATE " + tableName + "  SET Photo=@ImageData,Update_Date=@Update_Date where Cust_Code='" + imgBO.CustomerCode + "';";

        //                }

        //                else
        //                {
        //                    qry = "insert into " + tableName + " ([Cust_Code],[Photo],Update_Date) values(@OriginalPath,@ImageData,@Update_Date)";
        //                }

        //                SqlParm(qry, imgBO);



        //            }

        //            else if (ImgsavePattern == "2nd Gurd")
        //            {
        //                tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_Guardian2_Image");
        //                cheeckQuery = "Select Cust_Code from " + tableName + " where Cust_Code='" + imgBO.CustomerCode + "';";
        //                dataTable = dtImageSave(cheeckQuery);


        //                if (dataTable.Rows.Count > 0)
        //                {
        //                    qry = "UPDATE " + tableName + " SET Photo=@ImageData,Update_Date=@Update_Date where Cust_Code='" + imgBO.CustomerCode + "';";

        //                }

        //                else
        //                {
        //                    qry = "insert into " + tableName + " ([Cust_Code],[Photo],Update_Date) values(@OriginalPath,@ImageData,@Update_Date)";
        //                }



        //                SqlParm(qry, imgBO);



        //            }

        //            else if (ImgsavePattern == "POA")
        //            {
        //                tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_POA_Image");
        //                cheeckQuery = "Select Cust_Code from " + tableName + " where Cust_Code='" + imgBO.CustomerCode + "';";
        //                dataTable = dtImageSave(cheeckQuery);

        //                if (dataTable.Rows.Count > 0)
        //                {
        //                    qry = "UPDATE " + tableName + "SET Photo=@ImageData,Update_Date=@Update_Date where Cust_Code='" + imgBO.CustomerCode + "';";
        //                }

        //                else
        //                {
        //                    qry = "insert into " + tableName + " ([Cust_Code],[Photo],Update_Date) values(@OriginalPath,@ImageData,@Update_Date)";
        //                }


        //                SqlParm(qry, imgBO);



        //            }

        //            else if (ImgsavePattern == "Author")
        //            {
        //                tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_Author_Image");
        //                cheeckQuery = "Select Cust_Code from " + tableName + " where Cust_Code='" + imgBO.CustomerCode + "';";
        //                dataTable = dtImageSave(cheeckQuery);

        //                if (dataTable.Rows.Count > 0)
        //                {
        //                    qry = "UPDATE " + tableName + "SET Photo=@ImageData,Update_Date=@Update_Date where Cust_Code='" + imgBO.CustomerCode + "';";
        //                }

        //                else
        //                {
        //                    qry = "insert into " + tableName + " ([Cust_Code],[Photo],Update_Date) values(@OriginalPath,@ImageData,@Update_Date)";
        //                }


        //                SqlParm(qry, imgBO);

        //            }



        //        }


        //        public void InsertSignature(SaveImgBO imgBO, string ImgsavePattern)

        //        {

        //            string qry = "";
        //            string cheeckQuery = "";
        //            string tableName = string.Empty;
        //            DataTable dataTable=new DataTable();


        //            if (ImgsavePattern == "1st Account Holder")
        //            {
        //                tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_Cust_Image");
        //                cheeckQuery = "Select Cust_Code from "+tableName + " where Cust_Code='" + imgBO.CustomerCode + "';";
        //                dataTable = dtImageSave(cheeckQuery);


        //                if (dataTable.Rows.Count > 0)
        //                {
        //                    qry = "UPDATE " + tableName + " SET Signature=@ImageData,Update_Date=@Update_Date where Cust_Code='" + imgBO.CustomerCode + "';";

        //                }

        //                else
        //                {

        //                    qry = "insert into "+tableName + " ([Cust_Code],[Signature],Update_Date) values(@OriginalPath,@ImageData,@Update_Date)";
        //                }



        //                SqlParm(qry, imgBO);



        //            }



        //            else  if (ImgsavePattern == "2nd Account Holder")
        //            {
        //                tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_Joint_holder_Image");
        //                cheeckQuery = "Select Cust_Code from " + tableName + " where Cust_Code='" + imgBO.CustomerCode + "';";
        //                dataTable = dtImageSave(cheeckQuery);



        //                if (dataTable.Rows.Count > 0)
        //                {

        //                    qry = "UPDATE " + tableName + " SET Signature=@ImageData,Update_Date=@Update_Date where Cust_Code='" + imgBO.CustomerCode + "';";


        //                }

        //                else
        //                {

        //                    qry = "insert into " + tableName + " ([Cust_Code],[Signature],Update_Date) values(@OriginalPath,@ImageData,@Update_Date)";
        //                }


        //                SqlParm(qry, imgBO);


        //            }




        //            else if (ImgsavePattern == "1st Nominee")
        //            {
        //                tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_Nominee1_Image");
        //                cheeckQuery = "Select Cust_Code from " + tableName + " where Cust_Code='" + imgBO.CustomerCode + "';";
        //                dataTable = dtImageSave(cheeckQuery);



        //                if (dataTable.Rows.Count > 0)
        //                {

        //                    qry = "UPDATE " + tableName + " SET Signature=@ImageData,Update_Date=@Update_Date where Cust_Code='" + imgBO.CustomerCode + "';";


        //                }

        //                else
        //                {

        //                    qry = "insert into " + tableName + " ([Cust_Code],[Signature],Update_Date) values(@OriginalPath,@ImageData,@Update_Date)";
        //                }


        //                SqlParm(qry, imgBO);


        //            }



        //            else if (ImgsavePattern == "2nd Nominee")
        //            {

        //                tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_Nominee2_Image");
        //                cheeckQuery = "Select Cust_Code from " + tableName + " where Cust_Code='" + imgBO.CustomerCode + "';";
        //                dataTable = dtImageSave(cheeckQuery);



        //                if (dataTable.Rows.Count > 0)
        //                {


        //                    qry = "UPDATE " + tableName + " SET Signature=@ImageData,Update_Date=@Update_Date where Cust_Code='" + imgBO.CustomerCode + "';";


        //                }

        //                else
        //                {

        //                    qry = "insert into " + tableName + " ([Cust_Code],[Signature],Update_Date) values(@OriginalPath,@ImageData,@Update_Date)";
        //                }


        //                SqlParm(qry, imgBO);
        //            }


        //            else if (ImgsavePattern == "1st Gurdian")
        //            {
        //                tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_Guardian1_Image");
        //                cheeckQuery = "Select Cust_Code from " + tableName + " where Cust_Code='" + imgBO.CustomerCode + "';";
        //                dataTable = dtImageSave(cheeckQuery);



        //                if (dataTable.Rows.Count > 0)
        //                {

        //                    qry = "UPDATE " + tableName + " SET Signature=@ImageData,Update_Date=@Update_Date where Cust_Code='" + imgBO.CustomerCode + "';";


        //                }

        //                else
        //                {

        //                    qry = "insert into " + tableName + " ([Cust_Code],[Signature],Update_Date) values(@OriginalPath,@ImageData,@Update_Date)";
        //                }


        //                SqlParm(qry, imgBO);
        //            }


        //            else if (ImgsavePattern == "2nd Gurdian")
        //            {

        //                tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_Guardian2_Image");
        //                cheeckQuery = "Select Cust_Code from " + tableName + " where Cust_Code='" + imgBO.CustomerCode + "';";
        //                dataTable = dtImageSave(cheeckQuery);



        //                if (dataTable.Rows.Count > 0)
        //                {

        //                    qry = "UPDATE " + tableName + " SET Signature=@ImageData,Update_Date=@Update_Date where Cust_Code='" + imgBO.CustomerCode + "';";


        //                }

        //                else
        //                {

        //                    qry = "insert into " + tableName + " ([Cust_Code],[Signature],Update_Date) values(@OriginalPath,@ImageData,@Update_Date)";
        //                }


        //                SqlParm(qry, imgBO); 

        //            }


        //            else if (ImgsavePattern == "Power OF Attorney")
        //            {
        //                tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_POA_Image");

        //                cheeckQuery = "Select Cust_Code from " + tableName + " where Cust_Code='" + imgBO.CustomerCode + "';";
        //                dataTable = dtImageSave(cheeckQuery);



        //                if (dataTable.Rows.Count > 0)
        //                {

        //                    qry = "UPDATE " + tableName + " SET Signature=@ImageData,Update_Date=@Update_Date where Cust_Code='" + imgBO.CustomerCode + "';";


        //                }

        //                else
        //                {

        //                    qry = "insert into " + tableName + " ([Cust_Code],[Signature],Update_Date) values(@OriginalPath,@ImageData,@Update_Date)";
        //                }


        //                SqlParm(qry, imgBO);

        //            }

        //            else if (ImgsavePattern == "Authorized Person")
        //            {
        //                tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_Author_Image");

        //                cheeckQuery = "Select Cust_Code from " + tableName + " where Cust_Code='" + imgBO.CustomerCode + "';";
        //                dataTable = dtImageSave(cheeckQuery);



        //                if (dataTable.Rows.Count > 0)
        //                {

        //                    qry = "UPDATE " + tableName + " SET Signature=@ImageData,Update_Date=@Update_Date where Cust_Code='" + imgBO.CustomerCode + "';";


        //                }

        //                else
        //                {

        //                    qry = "insert into " + tableName + " ([Cust_Code],[Signature],Update_Date) values(@OriginalPath,@ImageData,@Update_Date)";
        //                }


        //                SqlParm(qry, imgBO);


        //            }
        //        }

        //        private DataTable dtImageSave(string query)
        //        {
        //            DataTable dtImage;
        //            dtImage = null;

        //            try
        //            {
        //                _dbConnection.ConnectDatabase_ImageExt();
        //                dtImage = _dbConnection.ExecuteQuery_ImageExt(query);
        //            }
        //            catch (Exception)
        //            {
        //                throw;
        //            }
        //            finally
        //            {
        //                _dbConnection.CloseDatabase_ImageExt();
        //            }

        //            return dtImage;

        //        }

        //        private void SqlParm(string query, SaveImgBO imgBO)
        //        {
        //            string connectionString = string.Empty; 

        //            if(GlobalVariableBO._isExist_SBP_Database_ImageExt)
        //            {
        //                connectionString = _dbConnection.ConnectionStringImageExt;
        //            }
        //            else
        //            {
        //                connectionString = _dbConnection.ConnectionString;
        //            }
        //            SqlConnection CN = new SqlConnection(connectionString);

        //            SqlCommand SqlCom = new SqlCommand(query, CN);
        //            SqlCom.Parameters.Add(new SqlParameter("@OriginalPath", (object)imgBO.CustomerCode));
        //            SqlCom.Parameters.Add(new SqlParameter("@ImageData", (object)imgBO.ImageArrayByte));
        //            SqlCom.Parameters.Add(new SqlParameter("@Update_Date", (object)cmbBAL.GetCurrentServerDate()));

        //            CN.Open();
        //            SqlCom.ExecuteNonQuery();
        //            CN.Close();

        //        }

        public DataTable GetAccountImageList(int type)
        {
            string queryString = "SBP_AccountImageList";
            DataTable data = new DataTable();

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ActiveStoredProcedure();
                _dbConnection.AddParameter("@type", SqlDbType.Int, type);
                data = _dbConnection.ExecuteProQuery(queryString);
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

        //        public bool IsExistCustomer(SaveImgBO imgBO, string ImgsavePattern)
        //        {

        //            string cheeckQuery = "";
        //            string cheeckQuery_ImgExt = "";
        //            bool IsExistPhoto = false;
        //            string tableName = string.Empty;
        //            string tableName_ImgExt = string.Empty;


        //                if (ImgsavePattern == "1st Acc")
        //                {
        //                    // tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_Cust_Image");
        //                    tableName =
        //                        Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_Cust_Image").
        //                            SingleOrDefault().Key;
        //                   cheeckQuery = "Select Cust_Code from " +tableName +" where Cust_Code='" + imgBO.CustomerCode + "';";

        //                    IsExistPhoto =IsExistCustomer(imgBO,cheeckQuery);
        //                }
        //                else if (ImgsavePattern == "2nd Acc")
        //                {
        //                    // tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_Joint_holder_Image");
        //                    tableName =
        //                        Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_Joint_holder_Image").
        //                            SingleOrDefault().Key;
        //                    cheeckQuery = "Select Cust_Code from " + tableName + " where Cust_Code='" + imgBO.CustomerCode + "';";
        //                    IsExistPhoto = IsExistCustomer(imgBO,cheeckQuery);
        //                }

        //             else if (ImgsavePattern == "1st Noim")
        //             {
        //                 //tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_Nominee1_Image");
        //                 tableName =
        //                     Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_Nominee1_Image").
        //                         SingleOrDefault().Key;

        //                   cheeckQuery = "Select Cust_Code from " + tableName + " where Cust_Code='" + imgBO.CustomerCode + "';";


        //                 IsExistPhoto = IsExistCustomer(imgBO,cheeckQuery);
        //             }

        //            else if (ImgsavePattern == "2nd Noim")
        //            {
        //                //tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_Nominee2_Image");
        //                tableName =
        //                    Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_Nominee2_Image").
        //                        SingleOrDefault().Key;

        //               cheeckQuery = "Select Cust_Code from " + tableName + "  where Cust_Code='" + imgBO.CustomerCode + "';";

        //                IsExistPhoto = IsExistCustomer(imgBO,cheeckQuery);
        //            }

        //            else if (ImgsavePattern == "1st Gurd")
        //            {
        //                //tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_Guardian1_Image");
        //                tableName =
        //                    Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_Guardian1_Image").
        //                        SingleOrDefault().Key;

        //               cheeckQuery = "Select Cust_Code from " + tableName + " where Cust_Code='" + imgBO.CustomerCode + "';";
        //                IsExistPhoto = IsExistCustomer(imgBO,cheeckQuery);
        //            }

        //            case "Guardian2":
        //                    //tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_Guardian2_Image");
        //                    tableName = Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_Guardian2_Image").SingleOrDefault().Key;

        //                    cheeckQuery = "Select Cust_Code,Photo from " + tableName + " where Cust_Code='" +
        //                                  singleImageBo.CustCode + "';";
        //                    IsExistPhoto = CheckExistingPhoto(cheeckQuery);
        //                    break;

        //                case "POA":
        //                    //tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_POA_Image");
        //                    tableName = Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_POA_Image").SingleOrDefault().Key;

        //                    cheeckQuery = "Select Cust_Code,Photo from " + tableName + " where Cust_Code='" +
        //                                  singleImageBo.CustCode + "';";
        //                    IsExistPhoto = CheckExistingPhoto(cheeckQuery);
        //                    break;

        //                case "Author":
        //                    // tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_Author_Image");
        //                    tableName = Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_Author_Image").SingleOrDefault().Key;

        //                    cheeckQuery = "Select Cust_Code,Photo from " + tableName + " where Cust_Code='" +
        //                                  singleImageBo.CustCode + "';";
        //                    IsExistPhoto = CheckExistingPhoto(cheeckQuery);
        //                    break;

        //                default:
        //                    IsExistPhoto = false;
        //                    break;
        //            }

        //            return IsExistPhoto;

        //        }

        //        public bool IsExistCustomer_ImgExt( SingleImageBO singleImageBo)
        //        {

        //            string cheeckQuery = "";
        //            string cheeckQuery_ImgExt = "";
        //            bool IsExistPhoto = false;
        //            string tableName = string.Empty;
        //            string tableName_ImgExt = string.Empty;
        //            switch (singleImageBo.ImageSelectionMode)
        //            {
        //                case "1st Account Holder":
        //                    // tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_Cust_Image");
        //                    tableName_ImgExt = Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_Cust_Image").SingleOrDefault().Value;

        //                    cheeckQuery_ImgExt = "Select Cust_Code,Photo from " + tableName_ImgExt + " where Cust_Code='" +
        //                                  singleImageBo.CustCode + "';";

        //                    IsExistPhoto = CheckExistingPhoto_ImgExt(cheeckQuery_ImgExt);
        //                    break;

        //                case "2nd Account Holder":
        //                    // tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_Joint_holder_Image");
        //                    tableName_ImgExt = Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_Joint_holder_Image").SingleOrDefault().Value;

        //                    cheeckQuery_ImgExt =
        //                        "Select Cust_Code,Photo from " + tableName_ImgExt + " where Cust_Code='" +
        //                        singleImageBo.CustCode + "';";

        //                    IsExistPhoto = CheckExistingPhoto_ImgExt(cheeckQuery_ImgExt);
        //                    break;

        //                case "Nominee1":
        //                    //tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_Nominee1_Image");
        //                    tableName_ImgExt = Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_Nominee1_Image").SingleOrDefault().Value;

        //                    cheeckQuery_ImgExt =
        //                        "Select Cust_Code,Photo from " + tableName_ImgExt + " where Cust_Code='" +
        //                        singleImageBo.CustCode + "';";

        //                    IsExistPhoto = CheckExistingPhoto_ImgExt(cheeckQuery_ImgExt);
        //                    break;

        //                case "Nominee2":
        //                    //tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_Nominee2_Image");
        //                    tableName_ImgExt = Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_Nominee2_Image").SingleOrDefault().Value;

        //                    cheeckQuery_ImgExt = "Select Cust_Code,Photo from " + tableName_ImgExt + " where Cust_Code='" +
        //                                  singleImageBo.CustCode + "';";

        //                    IsExistPhoto = CheckExistingPhoto_ImgExt(cheeckQuery_ImgExt);
        //                    break;

        //                case "Guardian1":
        //                    //tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_Guardian1_Image");
        //                    tableName_ImgExt = Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_Guardian1_Image").SingleOrDefault().Value;

        //                    cheeckQuery_ImgExt = "Select Cust_Code,Photo from " + tableName_ImgExt + " where Cust_Code='" +
        //                                  singleImageBo.CustCode + "';";
        //                    IsExistPhoto = CheckExistingPhoto_ImgExt(cheeckQuery_ImgExt);
        //                    break;

        //                case "Guardian2":
        //                    //tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_Guardian2_Image");
        //                    tableName_ImgExt = Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_Guardian2_Image").SingleOrDefault().Value;

        //                    cheeckQuery_ImgExt = "Select Cust_Code,Photo from " + tableName_ImgExt + " where Cust_Code='" +
        //                                                      singleImageBo.CustCode + "';";
        //                    IsExistPhoto = CheckExistingPhoto_ImgExt(cheeckQuery_ImgExt);
        //                    break;

        //                case "POA":
        //                    //tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_POA_Image");
        //                    tableName_ImgExt = Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_POA_Image").SingleOrDefault().Value;

        //                    cheeckQuery_ImgExt = "Select Cust_Code,Photo from " + tableName_ImgExt + " where Cust_Code='" +
        //                                  singleImageBo.CustCode + "';";
        //                    IsExistPhoto = CheckExistingPhoto_ImgExt(cheeckQuery_ImgExt);
        //                    break;

        //                case "Author":
        //                    // tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_Author_Image");
        //                    tableName_ImgExt = Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_Author_Image").SingleOrDefault().Value;

        //                    cheeckQuery_ImgExt = "Select Cust_Code,Photo from " + tableName_ImgExt + " where Cust_Code='" +
        //                                  singleImageBo.CustCode + "';";
        //                    IsExistPhoto = CheckExistingPhoto_ImgExt(cheeckQuery_ImgExt);
        //                    break;

        //                default:
        //                    IsExistPhoto = false;
        //                    break;
        //            }

        //            return IsExistPhoto;

        //        }

        //        private bool CheckExistingCustomer(string queryString)
        //        {
        //            bool IsExistingPhoto = false;
        //            DataTable data = new DataTable();

        //            try
        //            {
        //                _dbConnection.ConnectDatabase();
        //                data = _dbConnection.ExecuteQuery(queryString);

        //                if (data.Rows.Count > 0)
        //                {
        //                    if (data.Rows[0][1] == DBNull.Value)
        //                        IsExistingPhoto = false;
        //                    else
        //                    {
        //                        IsExistingPhoto = true;
        //                    }

        //                }

        //                else
        //                {
        //                    IsExistingPhoto = false;
        //                }
        //            }
        //            catch (Exception)
        //            {

        //                throw;
        //            }

        //            finally
        //            {
        //                _dbConnection.CloseDatabase_ImageExt();
        //            }

        //            return IsExistingPhoto;

        //        }

        //        private bool CheckExistingCustomer_ImgExt(string queryString_ImgExt)
        //        {
        //            bool IsExistingPhoto = false;
        //            DataTable data = new DataTable();

        //            try
        //            {
        //                _dbConnection.ConnectDatabase_ImageExt();
        //                data = _dbConnection.ExecuteQuery_ImageExt(queryString_ImgExt);

        //                if (data.Rows.Count > 0)
        //                {
        //                    if (data.Rows[0][1] == DBNull.Value)
        //                        IsExistingPhoto = false;
        //                    else
        //                    {
        //                        IsExistingPhoto = true;
        //                    }

        //                }

        //                else
        //                {
        //                    IsExistingPhoto = false;
        //                }
        //            }
        //            catch (Exception)
        //            {

        //                throw;
        //            }

        //            finally
        //            {
        //                _dbConnection.CloseDatabase_ImageExt();
        //            }

        //            return IsExistingPhoto;



        //        }

    }
}
